package com.windsor.node.plugin.icisnpdes40.submission;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Properties;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.spi.PersistenceProvider;
import javax.sql.DataSource;
import javax.xml.bind.JAXBElement;
import javax.xml.namespace.QName;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.hibernate.cfg.Environment;
import org.hibernate.ejb.HibernatePersistence;
import org.springframework.dao.DataAccessException;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.SqlOutParameter;
import org.springframework.jdbc.object.StoredProcedure;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.icisnpdes40.dao.JdbcIcisWorkflowDao;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;
import com.windsor.node.plugin.icisnpdes40.generated.HeaderData;
import com.windsor.node.plugin.icisnpdes40.generated.ObjectFactory;
import com.windsor.node.plugin.icisnpdes40.generated.PayloadData;
import com.windsor.node.plugin.icisnpdes40.hibernate.IcisNpdesStagingPersistenceUnitInfo;
import com.windsor.node.plugin.icisnpdes40.xml.validate.XmlValidator;
import com.windsor.node.plugin.icisnpdes40.xml.validate.jaxb.JaxbXmlValidator;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public abstract class AbstractIcisNpdesSubmission extends BaseWnosJaxbPlugin {

    /**
     * ETL Procedure Name: The name of the ETL stored procedure. If blank,
     * assume it is executed independently.
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_ETL_PROCEDURE_NAME = new PluginServiceParameterDescriptor(
            "ETL Procedure Name", PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.FALSE);
    
    /**
     * ICIS User ID: The ICIS UserID to insert into the XML Header. It is the
     * ICIS user account under which to perform the submission.
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_ICIS_USER_ID = new PluginServiceParameterDescriptor(
            "ICIS User ID", PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.TRUE);
    
    /**
     * Author: Test text to insert into the Header element's Author tag.
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_AUTHOR = new PluginServiceParameterDescriptor(
            "Author", PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.FALSE);

    /**
     * Organization: The text to insert into the Header element's Organization
     * tag.
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_ORGANIZATION = new PluginServiceParameterDescriptor(
            "Organization", PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.FALSE);

    /**
     * Contact Info: The text to insert into the Header element's ContactInfo
     * tag.
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_CONTACT_INFO = new PluginServiceParameterDescriptor(
            "Contact Info", PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.FALSE);

    /**
     * Notification Email Addresses: A semicolon-deliminated list of email
     * addresses. Each address will be added to the XML header submission,
     * instructing CDX to send email notifications when submissions are received
     * by CDX and when processing finished (either completed or failed).
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS = new PluginServiceParameterDescriptor(
            "Notification Email Addresses",
            PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE);
   
    /**
     * Submission Partner Name: The name of the Network Partner configured in
     * OpenNode2 for the CDX endpoint that the submission data will be sent to.
     * If no partner is set, the XML file created by the plugin will not be
     * submitted. This is useful for manual auditing purposes.
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_SUBMISSION_PARTNER_NAME = new PluginServiceParameterDescriptor(
            "Submission Partner Name",
            PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE);
   
   private DataSource dataSource;
   
   private EntityManagerFactory emf;
   
   private SettingServiceProvider settingService;
   
   private IdGenerator idGenerator;
   
   private CompressionService zipService;
   
   private JdbcTransactionDao transactionDao;
   
   private JdbcIcisWorkflowDao icisWorkflowDao;

   private PartnerDao partnerDao;

   public AbstractIcisNpdesSubmission() {

       /**
        * This service will be published for the following end points?
        */
       setPublishForEN11(true);
       setPublishForEN20(true);
       
       getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
               
       /**
        * Data source
        */
       getDataSources().put(ARG_DS_SOURCE, (DataSource)null);
       
       /**
        * Service Configuration arguments
        */
       getConfigurationArguments().put(SERVICE_PARAM_ETL_PROCEDURE_NAME.getName(), "");
       getConfigurationArguments().put(SERVICE_PARAM_ICIS_USER_ID.getName(), "");       
       getConfigurationArguments().put(SERVICE_PARAM_AUTHOR.getName(), "");
       getConfigurationArguments().put(SERVICE_PARAM_ORGANIZATION.getName(), "");
       getConfigurationArguments().put(SERVICE_PARAM_CONTACT_INFO.getName(), "");
       getConfigurationArguments().put(SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS.getName(), "");
       getConfigurationArguments().put(SERVICE_PARAM_SUBMISSION_PARTNER_NAME.getName(), "");       
   }

    /**
     * All inheritors must create a List<PayloadData> of one or more PayloadData
     * document elements, it is intended that only the complete and total ICIS
     * Submission Service implementer will return more than one.
     * 
     * @param em
     * @return
     */
    public abstract List<PayloadData> createAllPayloads(EntityManager em);

    /**
     * Generates a node document.
     * 
     * Returns null if there is no data to send.
     * 
     * @return The payload {@link Document}.
     * @throws XmlGenerationException
     */
    private Document generateNodeDocument(NodeTransaction nodeTransaction, String docId, String tempFilePath) throws XmlGenerationException, EmptyIcisStagingLocalDatabaseResultsException {
        
        /**
         * Attempt to find data from staging tables...
         */
        List<PayloadData> payloads = createAllPayloads(emf.createEntityManager());
        
        /**
         * No staging data to send, throw exception for process method to catch
         */
        if (payloads.size() == 0) {
            throw new EmptyIcisStagingLocalDatabaseResultsException();
        }

        /**
         * Always use an ObjectFactory to create JAXB created objects
         */
        ObjectFactory objectFactory = new ObjectFactory();

        /**
         * Create ICIS XML document
         */
        com.windsor.node.plugin.icisnpdes40.generated.Document document = objectFactory.createDocument();

        document.setHeader(makeHeaderData(objectFactory));

        document.setPayload(payloads);

        /**
         * TODO Consider pushing OpenNode2 Document creation and writing up one
         * more class level, this is pretty identical functionality.
         */
        try {

            /**
             * com.windsor.node.plugin.icisnpdes40.generated.Document is defined
             * in the XSD in a funny manner, causing ObjectFactory to not create
             * all utility methods for it so manually create the JAXBElement for
             * it
             */
            writeDocument(new JAXBElement<com.windsor.node.plugin.icisnpdes40.generated.Document>(new QName(
                            "http://www.exchangenetwork.net/schema/icis/4", "Document"),
                            com.windsor.node.plugin.icisnpdes40.generated.Document.class, null, document), tempFilePath);

            Document doc = makeDocument(nodeTransaction, docId, tempFilePath);
            
            nodeTransaction.getDocuments().add(doc);
            
            return doc;

        } catch (Exception e) {
            throw new XmlGenerationException("Error while creating document: " + tempFilePath, e);
        }
    }

    /**
     * Is the generated ICIS XML valid?
     * 
     * @return Is the generated ICIS XML valid?
     */
    private boolean isXmlPayloadDocumentNotValid(String xmlDocFilePath) throws Exception {
        
        String schemaFilePath = getXsdFilePath();
        
        XmlValidator validator = new JaxbXmlValidator(schemaFilePath);

        return validator.validate(new FileInputStream(xmlDocFilePath)).hasErrors();
    }

    /**
     * Returns the absolute file path to the ICIS XSD, which is bundled with the
     * plugin.
     * 
     * @return The abolute file path to the ICIS XSD.
     */
    private String getXsdFilePath() {
        
        String xsd = FilenameUtils.concat(getPluginSourceDir().getAbsolutePath(), "xsd/index.xsd");
        
        debug("XSD file path: " + xsd);
        
        return xsd;
    }

    /**
     * Builds a Node client and submits the transaction.
     * 
     * @return The resulting node transaction id.
     * @throws CDXSubmissionException
     *             When submission fails for any reason
     */
    private String submitToCdx(String partnerName, NodeTransaction nodeTransaction, ProcessContentResult result) throws CDXSubmissionException, PartnerIdentityNotFoundException {
        
        try {

            PartnerIdentity partner;
            
            try {
                partner = makePartner(partnerName, result);
            } catch (PartnerIdentityNotFoundException e) {
                throw e;
            }
            
            NodeClientService client = makeNodeClient(partner);
            
            nodeTransaction.updateWithPartnerDetails(partner);
            
            debug(result, "Submitting to partner URL: " + partner.getUrl());
            
            nodeTransaction = client.submit(nodeTransaction);
            
            getTransactionDao().save(nodeTransaction);
            
            return nodeTransaction.getNetworkId();
            
        } catch (Exception e) {
            throw new CDXSubmissionException(e.getMessage(), e);
        }
    }
    
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {
        
        /**
         * Initialize a new result object.
         */
        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);

        debug(result, "ICIS-NPDES plugin process starting.");
        
        try {

            /**
             * Validate workflow state: Attempt to find the current 'Pending'
             * workflow record. If the workflow state is invalid an
             * InvalidWorkflowStateException will be thrown and process will
             * exit.
             */
            debug(result, "Checking for a pending workflow record.");
            
            IcisWorkflow workflow = getPendingWorkflow();
            
            if (workflow == null) {
                
                debug(result, "A pending workflow was not found.");
                
                if (isETLProcedureNotConfigured()) {
                    
                    debug(result, "ETL stored procedure not configured.");
                    
                    return completed(result, "ETL stored procedure is not configured, node transaction status set to Completed.");
                    
                } else {}

                /**
                 * Execute ETL stored procedure when a 'Pending' workflow record
                 * cannot be found and a stored procedure name is configured as
                 * a service parameter.
                 */
                try {
                    
                    debug(result, "Attempting to execute ETL stored procedure {" + getConfigValueAsString(SERVICE_PARAM_ETL_PROCEDURE_NAME.getName(), false) + "}.");
                    
                    workflow = executeETLStoredProcedure();
                    
                    if (workflow == null) {
                        return completed(result, "ETL Procedure did not create a new workflow. Exiting.");
                    }

                    debug(result, "ETL stored procedure successfully executed. Workflow {" + workflow.getId() + "} created.");
                    
                } catch (ETLExecutionException e) {
                    String error = String.format("Error executing ETL: %s Exiting.", e.getMessage());
                    error(error, e);
                    return failed(result, error);
                }
                
            } else {
                debug(result, "Pending workflow {" + workflow.getId() + "} was found.");
            }
            
            if (isStagingDataAlreadySubmitted(workflow)) {
                
                debug(result, "Workflow record indicates staging data has already been submitted.");
                
                return completed(result, String.format("Pending workflow %s exists waiting for processing/download. Exiting.", workflow.getId()));
            }

            /**
             * Create temporary file to generate XML file.
             */
            String docId = getIdGenerator().createId();
            
            String icisXmlDocumentFilePath = makeTemporaryFilename(docId);
            
            /**
             * Generate and validate XML
             */
            try {
                
                debug(result, "Attempting to generate document.");
                
                Document doc = generateNodeDocument(transaction, docId, icisXmlDocumentFilePath);
                
                result.getDocuments().add(doc);

                /**
                 * TODO Is this really needed?
                 */
                result.setPaginatedContentIndicator(
                        new PaginationIndicator(
                                transaction.getRequest().getPaging().getStart(), 
                                transaction.getRequest().getPaging().getCount(), true));
                
                result.setStatus(CommonTransactionStatusCode.Pending);
                
                /**
                 * TODO When & where do we need to save the transaction?
                 */
                getTransactionDao().save(transaction);
                
                debug(result, "Node document successfully generated.");
                
            } catch (EmptyIcisStagingLocalDatabaseResultsException eisldre) {
                
                String msg = "ETL flagged no data for submission. Exiting.";
                completeWorkflow(workflow, msg);
                return completed(result, msg);
                
            } catch (XmlGenerationException xml) {
                
                /**
                 * TODO More error checking?
                 */                
                error(xml);
            }
            
            debug("Starting XML validation.");
            
            if (isXmlPayloadDocumentNotValid(icisXmlDocumentFilePath)) {
                
                String msg = "XML did not pass schema validation. Exiting";
                
                debug(result, msg);
                
                failWorkflow(workflow, msg);
                
                return failed(result, msg);
            }

            debug(result, "XML is valid.");    
            
            debug(result, "Checking service configuration parameter {" + SERVICE_PARAM_SUBMISSION_PARTNER_NAME.getName() + "}.");
            
            if (isSubmissionPartnerNameServiceParameterNotConfigured()) {
                String msg = "No endpoint configured. Exiting.";
                debug(msg);
                completeWorkflow(workflow, msg);
                return completed(result, msg);
            }
            
            String partnerName = getConfigValueAsString(SERVICE_PARAM_SUBMISSION_PARTNER_NAME.getName(), false);
            
            /**
             * Submit to CDX
             */
            try {
                
                debug(result, "Submitting node transaction to {" + partnerName + "}.");
                
                String submissionTransactionId = submitToCdx(partnerName, transaction, result);
                
                debug(result, "Submission completed successfully.");
                
                /**
                 * Update ICS_SUBM_TRACK workflow table.
                 */
                workflow.setSubmissionDate(new Date());
                workflow.setSubmissionTransactionId(submissionTransactionId);
                workflow.setSubmissionTransactionStatus("Pending");
                workflow.setSubmissionStatusDate(new Date());
                
                getIcisWorkflowDao().save(workflow);
                
                debug(result, "Workflow record updated.");
                
                debug(result, "ICIS-NPDES plugin process completed successfully.");
                
                return completed(result, "Submission completed successfully. Exiting.");
                
            } catch (PartnerIdentityNotFoundException pnfe) {
                
                failWorkflow(workflow, pnfe.getMessage());
                
                return failed(result, pnfe.getMessage());
                
            } catch (CDXSubmissionException e) {

                String msg = "Error submitting document to endpoint: " + e.getMessage() + " Exiting.";
                
                failWorkflow(workflow, msg);
                
                return failed(result, msg);
            }

        } catch (InvalidWorkflowStateException iwse) {
            return failed(result, iwse.getMessage());
        } catch (Exception e) {
            
            error("Unknown exception while processing.", e);
            
            return failed(result, String.format("Unknown exception while processing NPDES source data: %s", e.getMessage()));
        }
    }
   
    /**
     * TODO Document me
     * 
     * @param partnerName
     * @return
     * @throws PartnerIdentityNotFoundException
     */
    private PartnerIdentity makePartner(String partnerName, ProcessContentResult result) throws PartnerIdentityNotFoundException {

        debug(result, "Looking for partner named " + partnerName);

        List<?> partners = partnerDao.get();

        for (int i = 0; i < partners.size(); i++) {

            PartnerIdentity testPartner = (PartnerIdentity) partners.get(i);
            
            debug(result, "Found partner named " + testPartner.getName());

            if (testPartner.getName().equals(partnerName)) {

                debug(result, "Found partner match");
                
                return testPartner;
            }
        }
        throw new PartnerIdentityNotFoundException("No partner with the name {" + partnerName + "} found.");
    }
    
    /**
     * TODO Document me
     * 
     * @param partner
     * @return
     */
    protected NodeClientService makeNodeClient(PartnerIdentity partner) {

        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory().makeService(NodeClientFactory.class);

        String msg = "Creating Node Client with partner ";
        debug(msg + partner);
        
        return clientFactory.makeAndConfigure(partner);
    }
    
    /**
     * Returns an empty list.
     * 
     * {@inheritDoc}
     */
   @Override
   public List<PluginServiceParameterDescriptor> getParameters() {
       return new ArrayList<PluginServiceParameterDescriptor>();
   }

   /**
    * Returns null.
    * 
    * {@inheritDoc}
    */
   @Override
   public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
       return null;
   }
   
   @Override
   public void afterPropertiesSet() {
       
       setDataSource((DataSource)getDataSources().get(ARG_DS_SOURCE));
       setSettingService((SettingServiceProvider)getServiceFactory().makeService(SettingServiceProvider.class));
       setIdGenerator((IdGenerator)getServiceFactory().makeService(IdGenerator.class));
       setZipService((CompressionService)getServiceFactory().makeService(ZipCompressionService.class));
       setPartnerDao((PartnerDao)getServiceFactory().makeService(PartnerDao.class));
       setTransactionDao((JdbcTransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));

       initEntityManagerFactory(getDataSource());
   
       setIcisWorkflowDao(new JdbcIcisWorkflowDao(getDataSource()));
   }   

   /**
    * Returns a populated {@link HeaderData} to send to ICIS.
    * 
    * TODO - Determine if these <HeaderData> values need to be set.
    * 
    * @return a populated {@link HeaderData} to send.
    */
   private HeaderData makeHeaderData(ObjectFactory objectFactory) {
       HeaderData header = objectFactory.createHeaderData();
       
       /**
        * Random document id
        */
       String docId = getIdGenerator().createId();
       
       header.setId(docId.substring(1, 31));
       header.setAuthor(getConfigValueAsString(SERVICE_PARAM_AUTHOR.getName(), false));
       header.setCreationTime(new Date());
       header.setOrganization(getConfigValueAsString(SERVICE_PARAM_ORGANIZATION.getName(), false));

       // header.setComment();
       // header.setContactInfo();
       // header.setDataService();
       // header.setTitle();
       
       return header;
   }
   
    /**
     * Generates a temporary file name based on the class name and document id.
     * 
     * @param docId
     *            the document guid
     * @return file name
     */
   private String makeTemporaryFilename(String docId) {

        return FilenameUtils.concat(
                getSettingService().getTempDir().getAbsolutePath(), 
                "ICIS-NPDES_" + this.getClass().getSimpleName() + docId + ".xml");
    }
    
   /**
    * Initialize the local {@link EntityManagerFactory}.
    */
   private void initEntityManagerFactory(DataSource dataSource) {
       
       /***
        * Get a reference to the configured DataSource, we'll get the connection info from it
        */
       
       try {

           Properties jpaProperties = new Properties();
           
           jpaProperties.put(Environment.DATASOURCE, dataSource);
           
           // jpaProperties.put(Environment.SHOW_SQL, Boolean.TRUE);
           // jpaProperties.put(Environment.FORMAT_SQL, Boolean.TRUE);
           
           PersistenceProvider provider = new HibernatePersistence();
           
           emf = provider.createContainerEntityManagerFactory(new IcisNpdesStagingPersistenceUnitInfo(jpaProperties), jpaProperties);
           
       } catch (Exception e) {
           e.printStackTrace();
       }
   }

   protected Document makeDocument(NodeTransaction transaction, String docId, String tempFilePath) throws IOException {
        
        Document doc = new Document();
        doc.setDocumentId(docId);
        doc.setId(docId);

        if (transaction.getRequest().getType() != RequestType.Query) {
            String zippedFilePath = getZipService().zip(tempFilePath);
            doc.setType(CommonContentType.ZIP);
            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
        } else {
            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(tempFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(tempFilePath)));
        }
        return doc;
    }
    
   public SettingServiceProvider getSettingService() {
       return settingService;
   }

   public IdGenerator getIdGenerator() {
       return idGenerator;
   }

   public CompressionService getZipService() {
       return zipService;
   }

   public void setSettingService(SettingServiceProvider settingService) {
       this.settingService = settingService;
   }

   public void setIdGenerator(IdGenerator idGenerator) {
       this.idGenerator = idGenerator;
   }

   public void setZipService(CompressionService zipService) {
       this.zipService = zipService;
   }
       
   public JdbcTransactionDao getTransactionDao() {
       return transactionDao;
   }

   public void setTransactionDao(JdbcTransactionDao transactionDao) {
       this.transactionDao = transactionDao;
   }

   public DataSource getDataSource() {
       return dataSource;
   }
   
   public void setDataSource(DataSource dataSource) {
       this.dataSource = dataSource;
   }

   public JdbcIcisWorkflowDao getIcisWorkflowDao() {
       return icisWorkflowDao;
   }

   public void setIcisWorkflowDao(JdbcIcisWorkflowDao icisWorkflowDao) {
       this.icisWorkflowDao = icisWorkflowDao;
   }
   
   public PartnerDao getPartnerDao() {
       return partnerDao;
   }

   public void setPartnerDao(PartnerDao partnerDao) {
       this.partnerDao = partnerDao;
   }
   
   //////////////////////////////////////////////////////////////////////////////////////////////
   //////////////////////////////////////////////////////////////////////////////////////////////

    /**
    * Returns the current 'Pending' workflow.
    * 
    * @return the current pending workflow.
    * @throws InvalidWorkflowStateException
    *             When there are more than one pending workflows found or ETL
    *             completed and/or change detection timestamps not found.
    */
   private IcisWorkflow getPendingWorkflow() throws InvalidWorkflowStateException {
        
       if (moreThanOnePendingWorkflowRecord()) {
           throw new InvalidWorkflowStateException("Invalid workflow state. More than one pending workflow exists. Exiting.");
       }
       
       IcisWorkflow wf = getIcisWorkflowDao().findPendingWorkflow();
       
       if (wf != null && isETLCompletedAndChangeDetectionTimestampsNotFound(wf)) {
           throw new InvalidWorkflowStateException("Invalid workflow state. ETL completed timestamp and/or change detection timestamp not found. Exiting.");
       }
       return wf;
   }

   /**
    * Has the staging data been submitted to CDX? Determine by the presence of
    * the submitted date.
    * 
    * @param currentPendingWorkflow
    *            the current pending workflow.
    * @return staging data submitted to CDX?
    */
   private boolean isStagingDataAlreadySubmitted(IcisWorkflow currentPendingWorkflow) {
       
       if (currentPendingWorkflow != null
               && currentPendingWorkflow.getSubmissionDate() != null) {
           return Boolean.TRUE;
       }
       
       return Boolean.FALSE;
   }

   /**
    * Is there more than one 'Pending' workflow tracking record in the
    * database?
    * 
    * @return Is there more than one 'Pending' workflow tracking record in the
    *         database?
    */
   private boolean moreThanOnePendingWorkflowRecord() {    
       return getIcisWorkflowDao().countPendingWorkflows() > 1;
   }

   /**
    * Check the record for the presence of an ETL completed date/time and a
    * change detection date/time, indicating that the most recent task in the
    * workflow was completion of the ETL and change detection process.
    * 
    * @param workflow
    *            the workflow
    * @return Are the ETL completed and change detection time stamps present in
    *         the workflow tracking record?
    */
   private boolean isETLCompletedAndChangeDetectionTimestampsNotFound(IcisWorkflow workflow) {
       
       return (workflow.getDetectionChangeCompletionDate() == null || 
               workflow.getEtlCompletionDate() == null);
   }
   
   /**
    * Is this service not configured with an ETL stored procedure?
    * 
    * @return is an ETL stored procedure not configured.
    */
   private boolean isETLProcedureNotConfigured() {
       
       debug("Checking for a configured service parameter with the name " + SERVICE_PARAM_ETL_PROCEDURE_NAME.getName());
       
       return StringUtils.isEmpty(getConfigValueAsString(SERVICE_PARAM_ETL_PROCEDURE_NAME.getName(), false));
   }
   
   /**
    * Executes the ETL stored procedure and returns the newly created workflow
    * record. If no workflow was created during the execution, null will be
    * returned.
    * 
    * TODO - Instead of returning null, throw a meaningful custom exception.
    * 
    * @return a workflow id
    * @throws ETLExecutionException
    *             when unable to execute stored procedure.
    */
   private IcisWorkflow executeETLStoredProcedure() throws ETLExecutionException {

       if (isETLProcedureNotConfigured()) {
           throw new ETLExecutionException("An ETL stored procedure is not configured.");
       }
       
       try {
           
           String sprocName = getConfigValueAsString(SERVICE_PARAM_ETL_PROCEDURE_NAME.getName(), true);
           
           String workflowId = new ETLStoredProcedure(getDataSource(), sprocName).execute();
           
           if (workflowId == null) return null;
           
           return getIcisWorkflowDao().loadById(workflowId);
           
       } catch (Exception e) {
           error(e);
           throw new ETLExecutionException(e.getMessage(), e);
       }
   }

   /**
    * Check to see if an endpoint is configured in the service configuration.
    * 
    * @return Is an endpoint configured in the service configuration.
    */
   private boolean isSubmissionPartnerNameServiceParameterNotConfigured() {
       return StringUtils.isEmpty(getConfigValueAsString(SERVICE_PARAM_SUBMISSION_PARTNER_NAME.getName(), false));
   }
   
   /**
    * Updates the workflow columns in the ICS_SUBM_TRACK table.
    * 
    * @param workflow
    *            the value to update the WORKFLOW_STAT column with.
    * @param workflowStatusMessage
    *            the value to update the WORKFLOW_MESSAGE column with.
    */
   private void completeWorkflow(IcisWorkflow workflow, String workflowStatusMessage) {
       workflow.setWorkflowStatus("Completed");
       workflow.setWorkflowStatusMessage(workflowStatusMessage);
       getIcisWorkflowDao().save(workflow);
   }
   
   /**
    * Updates the workflow columns in the ICS_SUBM_TRACK table.
    * 
    * @param workflow
    *            the value to update the WORKFLOW_STAT column with.
    * @param workflowStatusMessage
    *            the value to update the WORKFLOW_MESSAGE column with.
    */
   private void failWorkflow(IcisWorkflow workflow, String workflowStatusMessage) {
       workflow.setWorkflowStatus("Failed");
       workflow.setWorkflowStatusMessage(workflowStatusMessage);
       getIcisWorkflowDao().save(workflow);
   }
   
   /**
    * Updates the {@link ProcessContentResult} as failed, returns the same
    * instance passed in as the first argument.
    * 
    * @param result
    *            the {@link ProcessContentResult} to update.
    * @param msg
    *            the failure message.
    * @return the same instance passed in as the first argument.
    */
   private ProcessContentResult failed(ProcessContentResult result, String msg) {
       result.getAuditEntries().add(new ActivityEntry(messageFilter(msg)));
       result.setStatus(CommonTransactionStatusCode.Failed);
       result.setSuccess(Boolean.FALSE);
       return result;
   }
   
   /**
    * Updates the {@link ProcessContentResult} as completed, returns the same
    * instance passed in as the first argument.
    * 
    * @param result
    *            the {@link ProcessContentResult} to update.
    * @param msg
    *            the failure message.
    * @return the same instance passed in as the first argument.
    */
   private ProcessContentResult completed(ProcessContentResult result, String msg) {
       result.getAuditEntries().add(new ActivityEntry(messageFilter(msg)));
       result.setStatus(CommonTransactionStatusCode.Completed);
       result.setSuccess(Boolean.TRUE);
       return result;
   }
   
   private String messageFilter(String msg) {
       return "[icisnpdes40] " + msg;
   }
   
   /**
    * Thrown when exception occurs while executing the ETL stored procedure.
    */
   class ETLExecutionException extends Exception {
       
       private static final long serialVersionUID = 1L;

       public ETLExecutionException(String msg, Throwable t) {
           super(msg, t);
       }
       
       public ETLExecutionException(String msg) {
           super(msg);
       }
   }

   /**
    * Thrown when exception occurs while generating XML document.
    */
   class XmlGenerationException extends Exception {
       
       private static final long serialVersionUID = 1L;

       public XmlGenerationException(String msg, Throwable t) {
           super(msg, t);
       }
   }

   /**
    * Thrown when exception occurs while sending document to CDX.
    */
   class CDXSubmissionException extends Exception {
       
       private static final long serialVersionUID = 1L;

       public CDXSubmissionException(String msg, Throwable t) {
           super(msg, t);
       }
   }
   
   /**
    * Thrown when no staging data to submit is found.
    */
   class EmptyIcisStagingLocalDatabaseResultsException extends Exception {
       
       private static final long serialVersionUID = 1L;

       public EmptyIcisStagingLocalDatabaseResultsException() { }
       
   }
   
   /**
    * Thrown if the workflow is in an invalid state.
    */
   class InvalidWorkflowStateException extends Exception {
       
       private static final long serialVersionUID = 1L;

       public InvalidWorkflowStateException(String msg) {
           super(msg);
       }
   }

    /**
     * Thrown when a {@link PartnerIdentity} cannot be found in the Node
     * metadata store.
     */
   class PartnerIdentityNotFoundException extends Exception {
       
       private static final long serialVersionUID = 1L;

       public PartnerIdentityNotFoundException(String msg) {
           super(msg);
       }
   }
   
   /**
    * Wrapper class to execute ETL stored procedure.
    */
   class ETLStoredProcedure extends StoredProcedure {
       
       private static final String OUT_WORKFLOW_ID = "p_ics_subm_track_id";

       /**
        * Default constructor.
        * 
        * @param dataSource
        *            the configured {@link DataSource} containing the ETL
        *            stored procedure.
        * @param sprocName
        *            the name of the ETL stored procedure.
        */
       public ETLStoredProcedure(DataSource dataSource, String sprocName) {
           super(dataSource, StringUtils.trim(sprocName));
           declareParameter(new SqlOutParameter(OUT_WORKFLOW_ID, Types.VARCHAR, new RowMapper() {
               
               @Override
               public Object mapRow(ResultSet rs, int rowNum) throws SQLException {
                   return rs.getString(OUT_WORKFLOW_ID);
               }
           }));
           compile();
       }

       /**
        * Execute the ETL stored procedure returning the workflow id.
        * 
        * @return workflow id.
        * @throws DataAccessException
        *             when execution fails.
        */
       @SuppressWarnings({"rawtypes", "unchecked"})
       public String execute() throws DataAccessException {     
           Map<String, String> out = super.execute(new HashMap());
           return out.get(OUT_WORKFLOW_ID);
       }        
   }

    private void debug(ProcessContentResult result, String message) {
        result.getAuditEntries().add(new ActivityEntry(messageFilter(message)));
        logger.debug(message);
    }

}

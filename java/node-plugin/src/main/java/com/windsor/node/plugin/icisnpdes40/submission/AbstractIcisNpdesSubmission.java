package com.windsor.node.plugin.icisnpdes40.submission;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;
import javax.xml.bind.JAXBElement;
import javax.xml.namespace.QName;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.common.xml.validation.ValidationResult;
import com.windsor.node.plugin.common.xml.validation.Validator;
import com.windsor.node.plugin.common.xml.validation.jaxb.JaxbXmlValidator;
import com.windsor.node.plugin.icisnpdes40.dao.IcisEntityManagerFactory;
import com.windsor.node.plugin.icisnpdes40.dao.IcisWorkflowDao;
import com.windsor.node.plugin.icisnpdes40.dao.jdbc.JdbcIcisWorkflowDao;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;
import com.windsor.node.plugin.icisnpdes40.generated.HeaderData;
import com.windsor.node.plugin.icisnpdes40.generated.NameType;
import com.windsor.node.plugin.icisnpdes40.generated.ObjectFactory;
import com.windsor.node.plugin.icisnpdes40.generated.PayloadData;
import com.windsor.node.plugin.icisnpdes40.generated.Property;
import com.windsor.node.plugin.icisnpdes40.submission.exception.CDXSubmissionException;
import com.windsor.node.plugin.icisnpdes40.submission.exception.ETLExecutionException;
import com.windsor.node.plugin.icisnpdes40.submission.exception.EmptyIcisStagingLocalDatabaseResultsException;
import com.windsor.node.plugin.icisnpdes40.submission.exception.InvalidWorkflowStateException;
import com.windsor.node.plugin.icisnpdes40.submission.exception.PartnerIdentityNotFoundException;
import com.windsor.node.plugin.icisnpdes40.submission.exception.XmlGenerationException;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.ServiceFactory;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public abstract class AbstractIcisNpdesSubmission extends BaseWnosJaxbPlugin {

    /**
     * Activity audit message prefix
     */
    private static final String ACTIVITY_AUDIT_PREFIX = "[icisnpdes4]";

    /**
     * The prefix to be prepended to the name of the  XML file.
     */
    private static final String FILE_PREFIX = "ICIS-NPDES_";

    /**
     * XML file extension.
     */
    private static final String FILE_EXTENSION_XML = "xml";

    /**
     * XSD file path.
     */
    private static final String XSD_RELATIVE_FILE_PATH = "xsd/index.xsd";

    /**
     * A static {@link QName} instance of the Document.
     */
    private static final QName DOCUMENT_QNAME = new QName("http://www.exchangenetwork.net/schema/icis/4", "Document");

    /**
     * ETL Procedure Name: The name of the ETL stored procedure. If blank,
     * assume it is executed independently.
     */
    private static final PluginServiceParameterDescriptor SERVICE_PARAM_ETL_PROCEDURE_NAME = new PluginServiceParameterDescriptor(
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

    /**
     * Validate Xml (true or false): Should the service validate the xml before submitting to ICIS
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_VALIDATE_XML = new PluginServiceParameterDescriptor(
            "Validate Xml (true or false)",
            PluginServiceParameterDescriptor.TYPE_BOOLEAN, Boolean.FALSE);


    /**
     * All service configuration parameters configurable in the Node Admin website.
     */
    private static final PluginServiceParameterDescriptor[] ALL_SERVICE_PARAMS = {
                                                                    SERVICE_PARAM_ETL_PROCEDURE_NAME,
                                                                    SERVICE_PARAM_ICIS_USER_ID,
                                                                    SERVICE_PARAM_AUTHOR,
                                                                    SERVICE_PARAM_ORGANIZATION,
                                                                    SERVICE_PARAM_CONTACT_INFO,
                                                                    SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS,
                                                                    SERVICE_PARAM_SUBMISSION_PARTNER_NAME,
                                                                    SERVICE_PARAM_VALIDATE_XML};

    /**
     * ICIS Staging Local database datasource.
     */
   private DataSource dataSource;

   /**
    * Entity Manager Factory
    */
   private EntityManagerFactory emf;

   private SettingServiceProvider settingService;

   private IdGenerator idGenerator;

   private CompressionService zipService;

   private TransactionDao transactionDao;

   private IcisWorkflowDao icisWorkflowDao;

   private PartnerDao partnerDao;

    public AbstractIcisNpdesSubmission() {

       getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);

       /**
        * Data source
        */
       getDataSources().put(ARG_DS_SOURCE, (DataSource)null);

       /**
        * Service Configuration arguments
        */
       setupServiceConfigParameters();
   }

    /**
     * Configures service configuration parameters.
     */
    private void setupServiceConfigParameters() {
        for (PluginServiceParameterDescriptor p : getPluginServiceParameterDescriptors()) {
            getConfigurationArguments().put(p.getName(), "");
        }
    }

    /**
     * Returns an array of {@link PluginServiceParameterDescriptor} the user
     * will need configure through the Node Admin web interface.
     *
     * @return an array of {@link PluginServiceParameterDescriptor} the user
     *         will need configure through the Node Admin web interface.
     */
   private PluginServiceParameterDescriptor[] getPluginServiceParameterDescriptors() {
       return ALL_SERVICE_PARAMS;
   }

    /**
     * All inheritors must create a List<PayloadData> of one or more PayloadData
     * document elements, it is intended that only the complete and total ICIS
     * Submission Service implementer will return more than one.
     *
     * @param em
     * @return
     */
    public abstract List<PayloadData> createAllPayloads(ProcessContentResult result, EntityManager em);

    /**
     * {@inheritDoc}
     *
     * Submits the Staging Local data to CDX.
     */
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        try {

            /**
             * Initialize a new result object.
             */
            ProcessContentResult result = new ProcessContentResult();
            result.setStatus(CommonTransactionStatusCode.Failed);
            result.setSuccess(Boolean.FALSE);

            debug(result, "ICIS-NPDES plugin process starting.");

            try {

                /**
                 * Validate Workflow State:
                 *
                 * Attempt to find the current 'Pending'
                 * workflow record. If the workflow state is invalid an
                 * InvalidWorkflowStateException will be thrown and process will
                 * exit.
                 */
                debug(result, "Checking for a pending workflow record.");

                IcisWorkflow workflow = findPendingWorkflow();

                if (workflow == null) {

                    debug(result, "...Pending workflow was not found.");

                    debug(result, "Checking for a configured ETL stored procedure.");

                    if (isETLProcedureNotConfigured()) {

                        debug(result, "...ETL stored procedure not configured. Exiting.");

                        return updateProcessAsCompleted(result, "ETL stored procedure is not configured, node transaction status set to Completed.");

                    } else {
                        debug(result, "...Found " + getConfigValueAsString(SERVICE_PARAM_ETL_PROCEDURE_NAME.getName(), false));
                    }

                    /**
                     * Execute ETL stored procedure when a 'Pending' workflow record
                     * cannot be found and a stored procedure name is configured as
                     * a service parameter.
                     */
                    try {

                        debug(result, "Executing ETL stored procedure.");

                        workflow = executeETLStoredProcedure();

                        if (workflow == null) {
                            return updateProcessAsCompleted(result, "...ETL stored procedure did not create a new workflow. Exiting.");
                        }

                        debug(result, "...ETL stored procedure successfully executed, workflow with id " + workflow.getId() + " created.");

                    } catch (ETLExecutionException e) {
                        String error = String.format("...Problem executing stored procedure, returned error: %s.", e.getMessage());
                        error(error, e);
                        return updateProcessAsFailed(result, error);
                    }

                } else {
                    debug(result, "...Pending workflow found.");
                }


                if (isStagingDataAlreadySubmitted(workflow)) {
                    return updateProcessAsCompleted(result, String.format("...Pending workflow %s exists waiting for processing/download. Exiting.", workflow.getId()));
                }

                /**
                 * Create temporary file to generate XML file.
                 */
                String docId = getIdGenerator().createId();

                String icisXmlDocumentFilePath = makeTemporaryFilename(docId);

                /**
                 * Generate and validate XML.
                 */
                try {

                    debug(result, "Attempting to generate OpenNode2 document.");

                    Document doc = generateNodeDocument(result, transaction, docId, icisXmlDocumentFilePath);

                    //result.getDocuments().add(doc);

                    result.setStatus(CommonTransactionStatusCode.Pending);

                    getTransactionDao().save(transaction);

                    debug(result, "...OpenNode2 document successfully generated.");

                } catch (EmptyIcisStagingLocalDatabaseResultsException eisldre) {
                    String msg = "...ETL flagged no data for submission. Exiting.";
                    updateWorkflowStatusAsCompleted(workflow, msg);
                    return updateProcessAsCompleted(result, msg);

                } catch (XmlGenerationException xmle) {
                    String error = String.format("...Problem generating document, returned error: %s.", xmle.getMessage());
                    error(error, xmle);
                    return updateProcessAsFailed(result, error);
                }

                /**
                 * Save NodeTransaction before schema validation.
                 */
                getTransactionDao().save(transaction);

                /**
                 * Skip the XML validation?
                 */
                if (!isSkipXmlValidation()) {

                    debug(result, "Starting XML validation.");
                    String validationDocId = getIdGenerator().createId();
                    if (isXmlPayloadDocumentNotValid(result, transaction, validationDocId, icisXmlDocumentFilePath)) {

                        String msg = "XML did not pass schema validation. Exiting";

                        updateWorkflowStatusAsFailed(workflow, msg);

                        /**
                         * Save NodeTransaction when there are validation errors.
                         */
                        getTransactionDao().save(transaction);

                        return updateProcessAsFailed(result, msg);
                    }

                    debug(result, "...XML is valid.");
                }

                /**
                 * Determine if a partner name service configuration parameter is
                 * set.
                 */
                debug(result, "Checking service parameter '" + SERVICE_PARAM_SUBMISSION_PARTNER_NAME.getName() + "' for a network partner name.");

                String partnerName = getConfigValueAsString(SERVICE_PARAM_SUBMISSION_PARTNER_NAME.getName(), false);

                if (isSubmissionPartnerNameServiceParameterNotConfigured()) {
                    String msg = "...Service parameter not configured. Exiting.";
                    updateWorkflowStatusAsCompleted(workflow, msg);
                    return updateProcessAsCompleted(result, msg);
                } else {
                    debug(result, "...Found network partner '"+partnerName+"'.");
                }

                /**
                 * Submit to CDX
                 */
                try {

                    debug(result, "Attempting to submit node transaction.");

                    String submissionTransactionId = executeSubmissionToCDX(partnerName, transaction, result);
                    //DANGER set to NodeTransaction object's actual network id!
                    transaction.setNetworkId(submissionTransactionId);

                    getTransactionDao().save(transaction);

                    debug(result, "...Successfully submitted node transaction.");

                    /**
                     * Update ICS_SUBM_TRACK workflow table.
                     */
                    debug(result, "Attempting to update workflow state.");

                    workflow.setSubmissionDate(new Date());
                    workflow.setSubmissionTransactionId(submissionTransactionId);
                    workflow.setSubmissionTransactionStatus("Pending");
                    workflow.setSubmissionStatusDate(new Date());
                    workflow.setWorkflowStatusMessage("The ICIS data has been submitted");

                    getIcisWorkflowDao().save(workflow);

                    debug(result, "...Workflow state successfully saved.");

                    return updateProcessAsCompleted(result, "ICIS-NPDES plugin completed successfully. Exiting.");

                } catch (PartnerIdentityNotFoundException pnfe) {

                    updateWorkflowStatusAsFailed(workflow, pnfe.getMessage());

                    return updateProcessAsFailed(result, pnfe.getMessage());

                } catch (CDXSubmissionException e) {

                    String msg = "...Error submitting document to endpoint: " + e.getMessage() + " Exiting.";

                    updateWorkflowStatusAsFailed(workflow, msg);

                    return updateProcessAsFailed(result, msg);
                }

            } catch (InvalidWorkflowStateException iwse) {
                return updateProcessAsFailed(result, iwse.getMessage());
            } catch (Exception e) {
                error("Unknown exception while processing.", e);
                return updateProcessAsFailed(result, String.format("Unknown exception while processing NPDES source data: %s", e.getMessage()));
            }
        } finally {
            if (emf != null) {
                emf.close();
            }
        }
    }

    /**
     * Generates a node document.
     *
     * Returns null if there is no data to send.
     *
     * @return The payload {@link Document}.
     * @throws XmlGenerationException
     */
    private Document generateNodeDocument(ProcessContentResult result, NodeTransaction nodeTransaction, String docId, String tempFilePath) throws XmlGenerationException, EmptyIcisStagingLocalDatabaseResultsException {

        /**
         * Attempt to find data from staging tables...
         */
        List<PayloadData> payloads = createAllPayloads(result, emf.createEntityManager());

        /**
         * No staging data to send, throw exception for process method to catch
         */
        if (payloads.isEmpty()) {
            throw new EmptyIcisStagingLocalDatabaseResultsException();
        }

        try {

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
             * com.windsor.node.plugin.icisnpdes40.generated.Document is defined
             * in the XSD in a funny manner, causing ObjectFactory to not create
             * all utility methods for it so manually create the JAXBElement for
             * it.
             */
            writeDocument(new JAXBElement<com.windsor.node.plugin.icisnpdes40.generated.Document>(DOCUMENT_QNAME,
                            com.windsor.node.plugin.icisnpdes40.generated.Document.class, null, document), tempFilePath);

            Document doc = makeDocument(nodeTransaction.getRequest().getType(), docId, tempFilePath);

            nodeTransaction.getDocuments().add(doc);

            return doc;

        } catch (Exception e) {
            throw new XmlGenerationException("Error while generating document: " + tempFilePath, e);
        }
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

    /**
     * Initializes this service.
     */
    @Override
    public void afterPropertiesSet() {

        setDataSource(getDataSources().get(ARG_DS_SOURCE));
        setSettingService((SettingServiceProvider) getServiceFactory().makeService(SettingServiceProvider.class));
        setIdGenerator((IdGenerator) getServiceFactory().makeService(IdGenerator.class));
        setZipService((CompressionService) getServiceFactory().makeService(ZipCompressionService.class));
        setPartnerDao((PartnerDao) getServiceFactory().makeService(PartnerDao.class));
        setTransactionDao((JdbcTransactionDao) getServiceFactory().makeService(JdbcTransactionDao.class));

        emf = IcisEntityManagerFactory.initEntityManagerFactory(getDataSource());

        setIcisWorkflowDao(new JdbcIcisWorkflowDao(getDataSource()));
    }

    /**
     * Returns the current 'Pending' workflow.
     *
     * @return the current pending workflow.
     * @throws InvalidWorkflowStateException
     *             When there are more than one pending workflows found or ETL
     *             completed and/or change detection timestamps not found.
     */
    private IcisWorkflow findPendingWorkflow()
            throws InvalidWorkflowStateException {

        if (isMoreThanOnePendingWorkflowRecord()) {
            throw new InvalidWorkflowStateException(
                    "Invalid workflow state. More than one pending workflow exists. Exiting.");
        }

        IcisWorkflow wf = getIcisWorkflowDao().findPendingWorkflow();

        if (wf != null
                && isETLCompletedAndChangeDetectionTimestampsNotFound(wf)) {
            throw new InvalidWorkflowStateException(
                    "Invalid workflow state. ETL completed timestamp and/or change detection timestamp not found. Exiting.");
        }
        return wf;
    }


    /**
     * Builds a Node client and submits the transaction.
     *
     * @return The resulting node transaction id.
     * @throws CDXSubmissionException
     *             When submission fails for any reason
     */
    private String executeSubmissionToCDX(String partnerName, NodeTransaction nodeTransaction, ProcessContentResult result) throws CDXSubmissionException, PartnerIdentityNotFoundException {

        try {

            PartnerIdentity partner;

            try {
                partner = findPartnerIdentityByPartnerName(partnerName, result);
            } catch (PartnerIdentityNotFoundException e) {
                throw e;
            }

            NodeClientService client = makeNodeClient(partner);

            nodeTransaction.updateWithPartnerDetails(partner);

            debug(result, "...Submitting transaction to URL " + partner.getUrl() );

            nodeTransaction = client.submit(nodeTransaction);

            getTransactionDao().save(nodeTransaction);

            return nodeTransaction.getNetworkId();

        } catch (Exception e) {
            throw new CDXSubmissionException(e.getMessage(), e);
        }
    }

    /**
     * Executes the ETL stored procedure and returns the newly created workflow
     * record. If no workflow was created during the execution, null will be
     * returned.
     *
     * @return a workflow id
     * @throws ETLExecutionException
     *             when unable to execute stored procedure.
     */
    private IcisWorkflow executeETLStoredProcedure()
            throws ETLExecutionException {

        if (isETLProcedureNotConfigured()) {
            throw new ETLExecutionException(
                    "An ETL stored procedure is not configured.");
        }

        try {

            String sprocName = getConfigValueAsString(
                    SERVICE_PARAM_ETL_PROCEDURE_NAME.getName(), true);

            String workflowId = new ETLStoredProcedure(getDataSource(),
                    sprocName).execute();

            if (workflowId == null)
                return null;

            return getIcisWorkflowDao().loadById(workflowId);

        } catch (Exception e) {
            error(e);
            throw new ETLExecutionException(e.getMessage(), e);
        }
    }

   /**
    * Returns a new {@link PartnerIdentity} using the supplied partner name.
    *
    * @param partnerName
    *            The name of partner used for look up.
    * @return A new {@link PartnerIdentity} using the supplied partner name.
    * @throws PartnerIdentityNotFoundException
    *             When a {@link PartnerIdentity} cannot be found.
    */
   private PartnerIdentity findPartnerIdentityByPartnerName(String partnerName, ProcessContentResult result) throws PartnerIdentityNotFoundException {

       List<?> partners = partnerDao.get();

       for (int i = 0; i < partners.size(); i++) {

           PartnerIdentity testPartner = (PartnerIdentity) partners.get(i);

           if (testPartner.getName().equals(partnerName)) {
               return testPartner;
           }
       }
       throw new PartnerIdentityNotFoundException("No network partner with name '" + partnerName + "' found.");
   }

   /**
    * Returns a {@link NodeClientService} from the {@link ServiceFactory}.
    *
    * @param partner
    *            The {@link PartnerIdentity} to communicate with.
    * @return A {@link NodeClientService} from the {@link ServiceFactory}.
    */
   protected NodeClientService makeNodeClient(PartnerIdentity partner) {

       NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory().makeService(NodeClientFactory.class);

       String msg = "Creating Node Client with partner ";

       debug(msg + partner);

       return clientFactory.makeAndConfigure(partner);
   }

   /**
    * Returns a populated {@link HeaderData} to send to ICIS.
    *
    * @return a populated {@link HeaderData} to send.
    */
   private HeaderData makeHeaderData(ObjectFactory objectFactory) {

       HeaderData header = objectFactory.createHeaderData();

       /**
        * Max length is 30 characters.
        */
       header.setId(getConfigValueAsString(SERVICE_PARAM_ICIS_USER_ID.getName(), false));

       /**
        * Use the service parameter as the author.
        */
       header.setAuthor(getConfigValueAsString(SERVICE_PARAM_AUTHOR.getName(),
               false));

       header.setContactInfo(getConfigValueAsString(SERVICE_PARAM_CONTACT_INFO.getName(),
               false));

       header.setOrganization(getConfigValueAsString(SERVICE_PARAM_ORGANIZATION.getName(),
               false));

       /**
        * Email notification property
        */
       String emailNotifications = getConfigValueAsString(SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS.getName(), false);

       if (StringUtils.isNotEmpty(emailNotifications)) {

           String separator = null;
           Property email;

           /**
            * Try splitting on "," and ";"
            */
           if (StringUtils.contains(emailNotifications, ",")) {
               separator = ",";
           } else if (StringUtils.contains(emailNotifications, ";")) {
               separator = ";";
           }

           if (StringUtils.isNotEmpty(separator)) {
               for (String e : StringUtils.split(emailNotifications, separator)) {
                   email = new Property();
                   email.setName(NameType.E_MAIL);
                   email.setValue(e);
                   header.getProperty().add(email);
               }
           } else {
               email = new Property();
               email.setName(NameType.E_MAIL);
               email.setValue(emailNotifications);
               header.getProperty().add(email);
           }

       }


       /**
        * Source property
        */
       Property source = new Property();
       source.setName(NameType.SOURCE);
       source.setValue("FullBatch");
       header.getProperty().add(source);


       /**
        * Created now.
        */
       header.setCreationTime(new Date());

       /**
        * Use the service as the organization.
        */
       header.setOrganization(getConfigValueAsString(
               SERVICE_PARAM_ORGANIZATION.getName(), false));

       return header;
   }

   /**
    * Generates a temporary xml file name based on the class name and document
    * id.
    *
    * @param docId
    *            is the document GUID.
    * @return The file name.
    */
  private String makeTemporaryFilename(String docId) {

       return FilenameUtils.concat(
               getSettingService().getTempDir().getAbsolutePath(),
               FILE_PREFIX + this.getClass().getSimpleName() + docId + "." + FILE_EXTENSION_XML);
   }

   /**
    * Returns a new Node2 {@link Document} instance based on the type of
    * request, document id, and absolute file path.
    *
    * @param requestType
    *            The type of node transaction request.
    * @param documentId
    *            The document identifier.
    * @param absolutefilePath
    *            The absolute file path to the content of the document.
    * @return A {@link Document}
    * @throws IOException
    *             Occurs when there is a problem accessing the file system to
    *             set the document content.
    */
    protected Document makeDocument(RequestType requestType, String documentId, String absolutefilePath) throws IOException {

        Document doc = new Document();
        doc.setDocumentId(documentId);
        doc.setId(documentId);

        if (!RequestType.Query.equals(requestType)) {
            String zippedFilePath = getZipService().zip(absolutefilePath);
            doc.setType(CommonContentType.ZIP);
            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(
                    zippedFilePath)));
        } else {
            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(absolutefilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(absolutefilePath)));
        }
        return doc;
    }

    /**
     * Returns the absolute file path to the ICIS XSD, which is bundled with the
     * plugin.
     *
     * @return The absolute file path to the ICIS XSD.
     */
    private String makeXsdFilePath() {
        return FilenameUtils.concat(getPluginSourceDir().getAbsolutePath(),
                XSD_RELATIVE_FILE_PATH);
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
    * Is the generated ICIS XML valid? If so, report errors.
    *
    * @param result
    *            The ProcessContentResult context.
    * @param xmlDocFilePath
    *            the file path to the generate xml to validate.
    * @return Is the generated ICIS XML valid?
    * @throws Exception
    *             When validation cannot be executed normally.
    */
   private boolean isXmlPayloadDocumentNotValid(ProcessContentResult result, NodeTransaction nodeTransaction, String docId, String xmlDocFilePath) throws Exception {

       if (isSkipXmlValidation()) return false;

       String schemaFilePath = makeXsdFilePath();

       Validator validator = new JaxbXmlValidator(schemaFilePath);

       ValidationResult validationResult = validator.validate(new FileInputStream(xmlDocFilePath));

       if (validationResult.hasErrors()) {

            debug(result,
                    "The generated xml document is not valid according to the xml schema.  Review " +
                    "the \"Validation Errors\" file for a summary of the validation errors");

            /**
             * Create a ValidationErrors.txt file and append it to the node
             * transaction docs collection.
             */
            String filename = FilenameUtils.concat(
                    getSettingService().getTempDir().getAbsolutePath(),
                    "Validation_Errors_" + this.getClass().getSimpleName() + docId + ".txt");

            File errorsFile = new File(filename);
            FileUtils.writeLines(errorsFile, validationResult.errors());

            Document doc = new Document();
            doc.setDocumentId(docId);
            doc.setId(docId);
            doc.setDocumentName("Validation Errors.txt");
            doc.setType(CommonContentType.Flat);
            doc.setDocumentStatus(CommonTransactionStatusCode.Completed);
            doc.setContent(FileUtils.readFileToByteArray(errorsFile));
            nodeTransaction.getDocuments().add(doc);
       }

       return validationResult.hasErrors();
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
       return StringUtils.isEmpty(getConfigValueAsString(SERVICE_PARAM_ETL_PROCEDURE_NAME.getName(), false));
   }

   /**
    * Is there more than one 'Pending' workflow tracking record in the
    * database?
    *
    * @return Is there more than one 'Pending' workflow tracking record in the
    *         database?
    */
   private boolean isMoreThanOnePendingWorkflowRecord() {
       return getIcisWorkflowDao().countPendingWorkflows() > 1;
   }

   /**
    * {@inheritDoc}
    */
   @Override
   public Boolean isPublishForEN11() {
       return Boolean.TRUE;
   }

   /**
    * {@inheritDoc}
    */
   @Override
   public Boolean isPublishForEN20() {
       return Boolean.TRUE;
   }

   /**
    * Skip XML validation?
    *
    * @return Skip XML validation?
    */
   private boolean isSkipXmlValidation() {
       String validate = getConfigurationArguments().get(SERVICE_PARAM_VALIDATE_XML.getName());
       return !Boolean.valueOf(validate);
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
    * Updates the workflow columns in the ICS_SUBM_TRACK table.
    *
    * @param workflow
    *            the value to update the WORKFLOW_STAT column with.
    * @param workflowStatusMessage
    *            the value to update the WORKFLOW_MESSAGE column with.
    */
   private void updateWorkflowStatusAsCompleted(IcisWorkflow workflow, String workflowStatusMessage) {
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
   private void updateWorkflowStatusAsFailed(IcisWorkflow workflow, String workflowStatusMessage) {
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
   private ProcessContentResult updateProcessAsFailed(ProcessContentResult result, String msg) {
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
   private ProcessContentResult updateProcessAsCompleted(ProcessContentResult result, String msg) {
       result.getAuditEntries().add(new ActivityEntry(messageFilter(msg)));
       result.setStatus(CommonTransactionStatusCode.Completed);
       result.setSuccess(Boolean.TRUE);
       return result;
   }

    /**
     * Adds a new {@link ActivityEntry} to {@link ProcessContentResult} and
     * calls {@link Logger#debug(String)}.
     *
     * @param result
     *            The {@link ProcessContentResult} instance to append the
     *            message to.
     * @param message
     *            The message to append to the {@link ProcessContentResult} and
     *            debug message.
     */
    protected final void debug(ProcessContentResult result, String message) {
        result.getAuditEntries().add(new ActivityEntry(messageFilter(message)));
        logger.debug(message);
    }

    /**
     * Returns a read friendly {@link String} to be used as
     * {@link ActivityEntry} audit message.
     *
     * @param message
     *            The string to be made read friendly.
     * @return A read friendly String.
     */
    private String messageFilter(String message) {
        return ACTIVITY_AUDIT_PREFIX + " " + message;
    }

    /**
     * Getters & Setters
     */

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

    public TransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public DataSource getDataSource() {
        return dataSource;
    }

    public void setDataSource(DataSource dataSource) {
        this.dataSource = dataSource;
    }

    public IcisWorkflowDao getIcisWorkflowDao() {
        return icisWorkflowDao;
    }

    public void setIcisWorkflowDao(IcisWorkflowDao icisWorkflowDao) {
        this.icisWorkflowDao = icisWorkflowDao;
    }

    public PartnerDao getPartnerDao() {
        return partnerDao;
    }

    public void setPartnerDao(PartnerDao partnerDao) {
        this.partnerDao = partnerDao;
    }
}

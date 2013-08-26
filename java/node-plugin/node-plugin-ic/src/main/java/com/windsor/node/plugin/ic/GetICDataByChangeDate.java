package com.windsor.node.plugin.ic;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.StringWriter;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.persistence.EntityManagerFactory;
import javax.persistence.TypedQuery;
import javax.sql.DataSource;
import javax.xml.bind.JAXBElement;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.time.DateUtils;
import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.ic.dao.ICDao;
import com.windsor.node.plugin.ic.dao.ICEntityManagerFactory;
import com.windsor.node.plugin.ic.dao.jdbc.JdbcICDao;
import com.windsor.node.plugin.ic.fixeddomain.AffiliateDataType;
import com.windsor.node.plugin.ic.fixeddomain.AffiliateListDataType;
import com.windsor.node.plugin.ic.fixeddomain.ICLocationDataType;
import com.windsor.node.plugin.ic.fixeddomain.ICLocationListDataType;
import com.windsor.node.plugin.ic.fixeddomain.InstitutionalControlsDocumentDataType;
import com.windsor.node.plugin.ic.fixeddomain.InstrumentDataType;
import com.windsor.node.plugin.ic.fixeddomain.InstrumentListDataType;
import com.windsor.node.plugin.ic.fixeddomain.ObjectFactory;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public class GetICDataByChangeDate extends BaseWnosJaxbPlugin
{
    private static final String FILE_PREFIX = "IC_";
    private static final String FILE_EXTENSION_XML = "xml";

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService zipService;
    private TransactionDao transactionDao;
    private PartnerDao partnerDao;
    private EntityManagerFactory emf;
    private ICDao icDao;

    public static final PluginServiceParameterDescriptor CHANGE_DATE = new PluginServiceParameterDescriptor(
                    "ChangeDate ",
                    PluginServiceParameterDescriptor.TYPE_DATE,
                    Boolean.TRUE,
                    "Date since any data element of an institutional control has been modified. Response will include all institutional controls that have changed on or after this date.\n\n Format of input date is YYYY-MM-DD.");
    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(GetICDataByChangeDate.class.getName());
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Used to support the creation and maintenance of a replica set of institutional control data across partners (i.e., data synchronization).");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetICDataByChangeDate.class.getCanonicalName());
    }

    public GetICDataByChangeDate()
    {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getDataSources().put(ARG_DS_SOURCE, (DataSource)null);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
    }

    @Override
    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();

        DataSource dataSource = getDataSources().get(ARG_DS_SOURCE);

        setSettingService((SettingServiceProvider)getServiceFactory().makeService(SettingServiceProvider.class));
        setIdGenerator((IdGenerator)getServiceFactory().makeService(IdGenerator.class));
        setZipService((CompressionService) getServiceFactory().makeService(ZipCompressionService.class));
        setTransactionDao((TransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));
        setPartnerDao((PartnerDao)getServiceFactory().makeService(JdbcPartnerDao.class));

        setEmf(ICEntityManagerFactory.initEntityManagerFactory(dataSource));
        setIcDao(new JdbcICDao(dataSource));
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(CHANGE_DATE);
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        //transaction.setOperation("ProcessICDoc");//Do we need an operation?

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.getAuditEntries().add(new ActivityEntry("Starting IC GetICDataByChangeDate processing."));

        try
        {
            validateFlowState(transaction, result);

            //Assemble the 3 lists, Instrument, Affiliation, and Locations (the real pain)
            List<InstrumentDataType> instruments = createInstrumentPayload(transaction);
            ObjectFactory fact = new ObjectFactory();
            InstrumentListDataType instrumentListDataType = fact.createInstrumentListDataType();
            instrumentListDataType.setInstrument(instruments);

            List<AffiliateDataType> affiliates = createAffiliatePayload(transaction);
            AffiliateListDataType affiliateListDataType = fact.createAffiliateListDataType();
            affiliateListDataType.setAffiliate(affiliates);

            List<ICLocationDataType> locations = createLocationPayload(transaction);
            ICLocationListDataType icLocationListDataType = fact.createICLocationListDataType();
            icLocationListDataType.setICLocation(locations);

            InstitutionalControlsDocumentDataType institutionalControlsDocumentDataType = fact.createInstitutionalControlsDocumentDataType();
            institutionalControlsDocumentDataType.setInstrumentList(instrumentListDataType);

            JAXBElement<?> jaxbElement = fact.createInstitutionalControlsDocument(institutionalControlsDocumentDataType);

            String docId = getIdGenerator().createId();
            String tempFilePath = makeTemporaryFilename(docId);
            jaxbElement = processHeaderDirectives(jaxbElement, docId, transaction.getOperation(), transaction, Boolean.TRUE);
            writeDocument(jaxbElement, tempFilePath);
            Document doc = makeDocument(transaction.getRequest().getType(), docId, tempFilePath);
            transaction.getDocuments().add(doc);
        }
        catch(Exception e)
        {
            StringWriter sw = new StringWriter();
            PrintWriter pw = new PrintWriter(sw);
            e.printStackTrace(pw);
            result.getAuditEntries().add(new ActivityEntry("Error during IC processing: \n" + sw.toString()));
            return result;
        }
        finally
        {
            if(getEmf() != null)
            {
                getEmf().close();
            }
            getTransactionDao().save(transaction);
        }

        result.getAuditEntries().add(new ActivityEntry("Successfully completed IC processing. Exiting."));
        result.setSuccess(true);
        result.setStatus(CommonTransactionStatusCode.Completed);

        return result;
    }

    private String makeTemporaryFilename(String docId)
    {
        return FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), FILE_PREFIX + this.getClass().getSimpleName()
                        + docId + "." + FILE_EXTENSION_XML);
    }

    protected Document makeDocument(RequestType requestType, String documentId, String absolutefilePath) throws IOException
    {
        Document doc = new Document();
        doc.setDocumentId(documentId);
        doc.setId(documentId);

        if(!RequestType.Query.equals(requestType))
        {
            String zippedFilePath = getZipService().zip(absolutefilePath);
            doc.setType(CommonContentType.ZIP);
            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
        }
        else
        {
            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(absolutefilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(absolutefilePath)));
        }
        return doc;
    }

    private List<ICLocationDataType> createLocationPayload(NodeTransaction transaction)
    {
        //load all the InstrumentDataType objects that fit the solicit/query params
        Map<String, Object> params = loadParameters(transaction);
        List<String> ids = getIcDao().findIntrumentIdsByCriteria(params);

        //FIXME will only support up to 1000 ids, make loop
        TypedQuery<ICLocationDataType> query = getEmf().createEntityManager()
                        .createQuery("FROM " + ICLocationDataType.class.getSimpleName() + " where dbid in (:listOfIds) ",
                                     ICLocationDataType.class);
        query.setParameter("listOfIds", ids);
        List<ICLocationDataType> results = query.getResultList();

        return results;
    }

    private List<AffiliateDataType> createAffiliatePayload(NodeTransaction transaction)
    {
      //load all the InstrumentDataType objects that fit the solicit/query params
        Map<String, Object> params = loadParameters(transaction);
        List<String> ids = getIcDao().findAffiliateIdsByCriteria(params);

        //FIXME will only support up to 1000 ids, make loop
        TypedQuery<AffiliateDataType> query = getEmf().createEntityManager()
                        .createQuery("FROM " + AffiliateDataType.class.getSimpleName() + " where dbid in (:listOfIds) ",
                                     AffiliateDataType.class);
        query.setParameter("listOfIds", ids);
        List<AffiliateDataType> results = query.getResultList();

        return results;
    }

    private List<InstrumentDataType> createInstrumentPayload(NodeTransaction transaction)
    {
        //load all the InstrumentDataType objects that fit the solicit/query params
        Map<String, Object> params = loadParameters(transaction);
        List<String> ids = getIcDao().findLocationIdsByCriteria(params);

        //FIXME will only support up to 1000 ids, make loop
        TypedQuery<InstrumentDataType> query = getEmf().createEntityManager()
                        .createQuery("FROM " + InstrumentDataType.class.getSimpleName() + " where dbid in (:listOfIds) ",
                                     InstrumentDataType.class);
        query.setParameter("listOfIds", ids);
        List<InstrumentDataType> results = query.getResultList();

        return results;
    }

    private Map<String, Object> loadParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        //determine which endpoint the request came in on, seriously, why haven't I automated this by now?
        //can't check which endpoint version because some endpoints opt to not send by name despite being v2.1
        //Blame Canada
        if(transaction.getRequest().getParameters().get(CHANGE_DATE.getName()) != null)
        {
            params = getNamedParameters(transaction);
        }
        else
        {
            params = getOrderedParameters(transaction);
        }
        return params;
    }

    private Map<String, Object> getOrderedParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        String[] args = transaction.getRequest().getParameterValues();
        if(args.length >= 1)
        {
            String changeDate = args[0];
            Date parsedChangeDate = null;
            try
            {
                parsedChangeDate = DateUtils.parseDate(changeDate, new String[]{"yyyy/MM/dd", "yyyy-MM-dd"});
            }
            catch(ParseException e)
            {
                logger.error("Unparseable date passed in for Change Date:  " + changeDate);
                throw new WinNodeException("Unparseable date passed in for Change Date:  " + changeDate);
            }
            params.put(CHANGE_DATE.getName(), parsedChangeDate);
        }
        else
        {
            logger.error("Change Date is required but null was passed.");
            throw new RuntimeException("Change Date is required but null was passed.");
        }
        return params;
    }

    private Map<String, Object> getNamedParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();
        if(namedParams.get(CHANGE_DATE.getName()) != null)
        {
            String changeDate = (String)namedParams.get(CHANGE_DATE.getName());
            Date parsedChangeDate = null;
            try
            {
                parsedChangeDate = DateUtils.parseDate(changeDate, new String[]{"yyyy/MM/dd", "yyyy-MM-dd"});
            }
            catch(ParseException e)
            {
                logger.error("Unparseable date passed in for Change Date:  " + changeDate);
                throw new RuntimeException("Unparseable date passed in for Change Date:  " + changeDate);
            }
            params.put(CHANGE_DATE.getName(), parsedChangeDate);
        }
        else
        {
            logger.error(CHANGE_DATE.getName() + " is required but null was passed.");
            throw new WinNodeException(CHANGE_DATE.getName() + " is required but null was passed.");
        }
        return params;
    }

    private void validateFlowState(NodeTransaction transaction, ProcessContentResult result)
    {
        // TODO Check for flow state pre-conditions, e.g. at least one record requirement, etc.
        //None so far?
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }

    public SettingServiceProvider getSettingService()
    {
        return settingService;
    }

    public void setSettingService(SettingServiceProvider settingService)
    {
        this.settingService = settingService;
    }

    public IdGenerator getIdGenerator()
    {
        return idGenerator;
    }

    public void setIdGenerator(IdGenerator idGenerator)
    {
        this.idGenerator = idGenerator;
    }

    public CompressionService getZipService()
    {
        return zipService;
    }

    public void setZipService(CompressionService zipService)
    {
        this.zipService = zipService;
    }

    public TransactionDao getTransactionDao()
    {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao)
    {
        this.transactionDao = transactionDao;
    }

    public PartnerDao getPartnerDao()
    {
        return partnerDao;
    }

    public void setPartnerDao(PartnerDao partnerDao)
    {
        this.partnerDao = partnerDao;
    }

    public EntityManagerFactory getEmf()
    {
        return emf;
    }

    public void setEmf(EntityManagerFactory emf)
    {
        this.emf = emf;
    }

    public ICDao getIcDao()
    {
        return icDao;
    }

    public void setIcDao(ICDao icDao)
    {
        this.icDao = icDao;
    }
}

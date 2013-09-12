package com.windsor.node.plugin.ic;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.Serializable;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Query;
import javax.sql.DataSource;
import javax.xml.bind.JAXBElement;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.data.dao.PartnerDao;
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

public abstract class AbstractICPlugin extends BaseWnosJaxbPlugin implements Serializable
{
    private static final long serialVersionUID = 1L;

    protected static final String FILE_PREFIX = "IC_";

    protected static final String FILE_EXTENSION_XML = "xml";

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService zipService;
    private TransactionDao transactionDao;
    private PartnerDao partnerDao;
    private EntityManagerFactory emf;
    private ICDao icDao;

    protected abstract Map<String, Object> loadParameters(NodeTransaction transaction);

    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.getAuditEntries().add(new ActivityEntry("Starting IC processing."));

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
            institutionalControlsDocumentDataType.setAffiliateList(affiliateListDataType);
            institutionalControlsDocumentDataType.setICLocationList(icLocationListDataType);

            JAXBElement<?> jaxbElement = fact.createInstitutionalControlsDocument(institutionalControlsDocumentDataType);

            String docId = getIdGenerator().createId();
            String tempFilePath = makeTemporaryFilename(docId);
            jaxbElement = processHeaderDirectives(jaxbElement, docId, transaction.getOperation(), transaction);
            writeDocument(jaxbElement, tempFilePath);
            Document doc = makeDocument(transaction.getRequest().getType(), docId, tempFilePath);
            transaction.getDocuments().add(doc);
            result.getDocuments().add(doc);
        }
        catch(Exception e)
        {
            StringWriter sw = new StringWriter();
            PrintWriter pw = new PrintWriter(sw);
            e.printStackTrace(pw);
            result.getAuditEntries().add(new ActivityEntry("Error during IC processing: \n" + sw.toString()));
            //return result;
            if(WinNodeException.class.isAssignableFrom(e.getClass()))
            {
                throw (WinNodeException)e;
            }
            throw new WinNodeException(e);
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

    protected String makeTemporaryFilename(String docId)
    {
        return FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), FILE_PREFIX + this.getClass().getSimpleName()
                        + docId + "." + FILE_EXTENSION_XML);
    }

    protected List<ICLocationDataType> createLocationPayload(NodeTransaction transaction)
    {
        //load all the InstrumentDataType objects that fit the solicit/query params
        Map<String, Object> params = loadParameters(transaction);
        List<String> ids = getIcDao().findLocationIdsByCriteria(params);

        if(ids == null || ids.size() < 1)
        {
            return new ArrayList<ICLocationDataType>();
        }

        //FIXME will likely only support up to 1000 ids, make loop
        /*TypedQuery<ICLocationDataType> query = getEmf().createEntityManager()
                        .createQuery("FROM " + ICLocationDataType.class.getSimpleName() + " where dbid in (:listOfIds) ",
                                     ICLocationDataType.class);
        query.setParameter("listOfIds", ids);*/
        // FIXME TypedQuery doesn't work because of Hibernate's inability to create an EntityManager with a reference to
        // a particular classloader, this breaks things like OSGI and loading plugins in a child classloader (which
        // OpenNode2 does), open a ticket or look for a workaround
        Query query = getEmf().createEntityManager()
                              .createQuery("select loc FROM " + ICLocationDataType.class.getSimpleName()
                                                           + " loc where loc.dbid in (:listOfIds) ");//left join fetch loc.landParcel
        query.setParameter("listOfIds", ids);
        //query.setParameter("listOfIds", "IC_LOC_1");
        @SuppressWarnings("unchecked")
        List<ICLocationDataType> results = query.getResultList();

        return results;
    }

    protected List<AffiliateDataType> createAffiliatePayload(NodeTransaction transaction)
    {
        //load all the InstrumentDataType objects that fit the solicit/query params
        Map<String, Object> params = loadParameters(transaction);
        List<String> ids = getIcDao().findAffiliateIdsByCriteria(params);

        if(ids == null || ids.size() < 1)
        {
            return new ArrayList<AffiliateDataType>();
        }

        //FIXME will likely only support up to 1000 ids, make loop
        /*TypedQuery<AffiliateDataType> query = getEmf().createEntityManager()
                        .createQuery("FROM " + AffiliateDataType.class.getSimpleName() + " where dbid in (:listOfIds) ",
                                     AffiliateDataType.class);
        query.setParameter("listOfIds", ids);*/
        Query query = getEmf().createEntityManager()
                        .createQuery("FROM " + AffiliateDataType.class.getSimpleName() + " where dbid in (:listOfIds) ");
        query.setParameter("listOfIds", ids);
        @SuppressWarnings("unchecked")
        List<AffiliateDataType> results = query.getResultList();

        return results;
    }

    protected List<InstrumentDataType> createInstrumentPayload(NodeTransaction transaction)
    {
        //load all the InstrumentDataType objects that fit the solicit/query params
        Map<String, Object> params = loadParameters(transaction);
        List<String> ids = getIcDao().findIntrumentIdsByCriteria(params);

        if(ids == null || ids.size() < 1)
        {
            return new ArrayList<InstrumentDataType>();
        }

        //FIXME will likely only support up to 1000 ids, make loop
        /*TypedQuery<InstrumentDataType> query = getEmf().createEntityManager()
                        .createQuery("FROM " + InstrumentDataType.class.getSimpleName() + " where dbid in (:listOfIds) ",
                                     InstrumentDataType.class);
        query.setParameter("listOfIds", ids);*/
        Query query = getEmf().createEntityManager()
                        .createQuery("FROM " + InstrumentDataType.class.getSimpleName() + " where dbid in (:listOfIds) ");
        query.setParameter("listOfIds", ids);
        @SuppressWarnings("unchecked")
        List<InstrumentDataType> results = (List<InstrumentDataType>)query.getResultList();

        return results;
    }

    protected void validateFlowState(NodeTransaction transaction, ProcessContentResult result)
    {
        // TODO Check for flow state pre-conditions, e.g. at least one record requirement, etc.
        //None so far?
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

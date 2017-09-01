package com.windsor.node.plugin.common;

import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.domain.DocumentHeaderType;
import com.windsor.node.plugin.common.domain.DocumentPayloadType;
import com.windsor.node.plugin.common.domain.ExchangeNetworkDocumentType;
import com.windsor.node.plugin.common.domain.NameValuePair;
import com.windsor.node.plugin.common.domain.ObjectFactory;
import com.windsor.node.plugin.common.domain.v1.DocHeader;
import com.windsor.node.plugin.common.domain.v1.ExchangeNetworkDocument;
import com.windsor.node.plugin.common.domain.v1.Payload;
import com.windsor.node.service.helper.id.UUIDGenerator;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public abstract class BaseWnosJaxbPlugin extends BaseWnosPlugin
{

    private static DatatypeFactory datatypeFactory;
    private static Map<String, JAXBContext> contexts = new HashMap<>();

    {
        try {
            datatypeFactory = DatatypeFactory.newInstance();
        } catch (DatatypeConfigurationException e) {
            throw new RuntimeException(e);
        }
    }

    public static final String ARG_HEADER_DOCUMENT_TITLE = "Document Title";
    public static final String ARG_HEADER_KEYWORDS = "Keywords";
    protected Logger logger = LoggerFactory.getLogger(BaseWnosJaxbPlugin.class);

    protected JAXBElement<?> processHeaderDirectives(JAXBElement<?> jaxbElement, String docId, String operation, NodeTransaction transaction)
    {
        return processHeaderDirectives(jaxbElement, docId, operation, transaction, Boolean.FALSE);
    }

    protected JAXBElement<?> processHeaderDirectives(JAXBElement<?> jaxbElement, String docId, String operation, NodeTransaction transaction, Boolean forceHeaderUse)
    {
        String addHeader = getConfigValueAsStringNoFail(ARG_ADD_HEADER);
        if(!"true".equalsIgnoreCase(addHeader) && !forceHeaderUse)
        {
            return jaxbElement;
        }
        ObjectFactory fact = new ObjectFactory();
        ExchangeNetworkDocumentType exchangeNetworkDocumentType = fact.createExchangeNetworkDocumentType();
        exchangeNetworkDocumentType.setId(UUIDGenerator.makeId());

        DocumentHeaderType documentHeader = fact.createDocumentHeaderType();
        exchangeNetworkDocumentType.setHeader(documentHeader);
        String authorName = getConfigValueAsStringNoFail(ARG_HEADER_AUTHOR);
        documentHeader.setAuthorName((StringUtils.isNotBlank(authorName) ? authorName: ""));
        String contactInfo = getConfigValueAsStringNoFail(ARG_HEADER_CONTACT_INFO);
        documentHeader.setSenderContact((StringUtils.isNotBlank(contactInfo) ? contactInfo: ""));
        String orgName = getConfigValueAsStringNoFail(ARG_HEADER_ORG_NAME);
        String payloadName = getConfigValueAsStringNoFail(ARG_HEADER_PAYLOAD_OP);
        String documentTitle = getConfigValueAsStringNoFail(ARG_HEADER_DOCUMENT_TITLE);
        String keywords = getConfigValueAsStringNoFail(ARG_HEADER_KEYWORDS);
        documentHeader.setOrganizationName((StringUtils.isNotBlank(orgName) ? orgName: ""));
        if(StringUtils.isNotBlank(documentTitle))
        {
            documentHeader.setDocumentTitle(documentTitle);
        }
        else
        {
            documentHeader.setDocumentTitle(operation + docId);
        }
        if(StringUtils.isNotBlank(keywords))
        {
            documentHeader.setKeywords(keywords);
        }
        documentHeader.setCreationDateTime(getDocumentCreationDateTime());
        documentHeader.setDataFlowName(transaction.getRequest().getFlowName());
        documentHeader.setDataServiceName(transaction.getRequest().getService().getName());
        
        List<String> additionalPropertyNames = getAdditionalPropertyNames();
        if (additionalPropertyNames != null) {
        	List<NameValuePair> properties = documentHeader.getProperty();
	        for (String propertyName : additionalPropertyNames) {
	        	NameValuePair pair = new NameValuePair();
	        	String value = getConfigValueAsStringNoFail(propertyName);
	        	if (StringUtils.isNotBlank(value)) {
	        		pair.setPropertyName(propertyName);
	        		pair.setPropertyValue(value);
	        		properties.add(pair);
	        	}
	        }
        }

        DocumentPayloadType documentPayloadType = fact.createDocumentPayloadType();
        exchangeNetworkDocumentType.getPayload().add(documentPayloadType);
        documentPayloadType.setId(docId);
        if(StringUtils.isNotBlank(payloadName))
        {
            documentPayloadType.setOperation(payloadName);
        }
        documentPayloadType.setAny(jaxbElement);

        return fact.createDocument(exchangeNetworkDocumentType);
    }
    
    protected JAXBElement<?> processV1HeaderDirectives(JAXBElement<?> jaxbElement, String docId, String operation, NodeTransaction transaction, Boolean forceHeaderUse)
    {
        String addHeader = getConfigValueAsStringNoFail(ARG_ADD_HEADER);
        if(!"true".equalsIgnoreCase(addHeader) && !forceHeaderUse)
        {
            return jaxbElement;
        }
        com.windsor.node.plugin.common.domain.v1.ObjectFactory fact = new com.windsor.node.plugin.common.domain.v1.ObjectFactory();
        ExchangeNetworkDocument exchangeNetworkDocument = fact.createExchangeNetworkDocument();
        exchangeNetworkDocument.setId(UUIDGenerator.makeId());

        DocHeader docHeader = fact.createDocHeader();
        exchangeNetworkDocument.setHeader(docHeader);
        String authorName = getConfigValueAsStringNoFail(ARG_HEADER_AUTHOR);
        docHeader.setAuthor(StringUtils.isNotBlank(authorName) ? authorName: "");
        String contactInfo = getConfigValueAsStringNoFail(ARG_HEADER_CONTACT_INFO);
        docHeader.setContactInfo(StringUtils.isNotBlank(contactInfo) ? contactInfo: "");
        String orgName = getConfigValueAsStringNoFail(ARG_HEADER_ORG_NAME);
        String payloadName = getConfigValueAsStringNoFail(ARG_HEADER_PAYLOAD_OP);
        String title = getConfigValueAsStringNoFail(ARG_HEADER_TITLE);
        docHeader.setOrganization(StringUtils.isNotBlank(orgName) ? orgName: "");
        if(StringUtils.isNotBlank(title))
        {
            docHeader.setTitle(title);
        }
        else
        {
            docHeader.setTitle(operation + docId);
        }
        docHeader.setCreationTime(getDocumentCreationDateTime());
        docHeader.setDataService(transaction.getRequest().getService().getName());

        List<String> additionalPropertyNames = getAdditionalPropertyNames();
        if (additionalPropertyNames != null) {
            List<NameValuePair> properties = documentHeader.getProperty();
            for (String propertyName : additionalPropertyNames) {
                NameValuePair pair = new NameValuePair();
                String value = getConfigValueAsStringNoFail(propertyName);
                if (StringUtils.isNotBlank(value)) {
                    pair.setPropertyName(propertyName);
                    pair.setPropertyValue(value);
                    properties.add(pair);
                }
            }
        }

        List<String> additionalNameValuePropertyNames = getAdditionalNameValueProperties();
        if (additionalNameValuePropertyNames != null) {
        	List<com.windsor.node.plugin.common.domain.v1.NameValuePair> properties = docHeader.getProperty();
	        for (String propertyName : additionalNameValuePropertyNames) {
	        	com.windsor.node.plugin.common.domain.v1.NameValuePair pair = new com.windsor.node.plugin.common.domain.v1.NameValuePair();
	        	String value = getConfigValueAsStringNoFail(propertyName);
	        	if (StringUtils.isNotBlank(value)) {
	        		pair.setName(propertyName);
	        		pair.setValue(value);
	        		properties.add(pair);
	        	}
	        }
        }

        Payload documentPayloadType = fact.createPayload();
        exchangeNetworkDocument.getPayload().add(documentPayloadType);
        if(StringUtils.isNotBlank(payloadName))
        {
            documentPayloadType.setOperation(payloadName);
        }
        documentPayloadType.setAny(jaxbElement);

        return fact.createDocument(exchangeNetworkDocument);
    }
    
    protected List<String> getAdditionalPropertyNames() {
    	return null;
    }

    protected List<String> getAdditionalNameValuePropertyNames() {
        return null;
    }

    private XMLGregorianCalendar getDocumentCreationDateTime()
    {
        return datatypeFactory.newXMLGregorianCalendar(new GregorianCalendar());
    }

    protected void writeDocument(JAXBElement<?> document, String pathname) throws JAXBException, IOException
    {
    	Object value  = document.getValue();
        Class<?> clazz = value.getClass();
        StringBuffer packageNames = new StringBuffer(clazz.getPackage().getName());
        //if a header is used the JAXB classes are in a different package, both must be included for the engine to function properly.
        if(value instanceof ExchangeNetworkDocumentType)
        {
            ExchangeNetworkDocumentType doc = (ExchangeNetworkDocumentType)document.getValue();
            for(int i = 0; i < doc.getPayload().size(); i++)
            {
                packageNames.insert(0, ":").insert(0, ((JAXBElement<?>)doc.getPayload().get(i).getAny()).getValue().getClass().getPackage().getName());
            }
        } else if(value instanceof ExchangeNetworkDocument)
        {
        	ExchangeNetworkDocument doc = (ExchangeNetworkDocument)document.getValue();
            for(int i = 0; i < doc.getPayload().size(); i++)
            {
                packageNames.insert(0, ":").insert(0, ((JAXBElement<?>)doc.getPayload().get(i).getAny()).getValue().getClass().getPackage().getName());
            }
        }
        String key = packageNames.toString();
        JAXBContext context = contexts.get(key);
        if (context == null) {
            context = JAXBContext.newInstance(key, clazz.getClassLoader());
            contexts.put(key, context);
        }
        Marshaller m = context.createMarshaller();
        m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
        m.marshal(document, new FileOutputStream(pathname));
    }

    public String getConfigValueAsStringNoFail(String key)
    {

        if(StringUtils.isBlank(key))
        {
            return null;
        }
        logger.debug("Looking for: " + key);
        if(!getConfigurationArguments().containsKey(key))
        {
            return null;
        }

        String value = getConfigurationArguments().get(key);
        if(StringUtils.isBlank(value))
        {
            return null;
        }
        return value;
    }
}

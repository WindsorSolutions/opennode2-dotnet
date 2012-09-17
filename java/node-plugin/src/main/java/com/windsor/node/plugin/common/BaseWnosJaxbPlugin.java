package com.windsor.node.plugin.common;

import java.io.FileOutputStream;
import java.io.IOException;
import java.util.GregorianCalendar;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.domain.DocumentHeaderType;
import com.windsor.node.plugin.common.domain.DocumentPayloadType;
import com.windsor.node.plugin.common.domain.ExchangeNetworkDocumentType;
import com.windsor.node.plugin.common.domain.ObjectFactory;

public abstract class BaseWnosJaxbPlugin extends BaseWnosPlugin
{
    protected Logger logger = LoggerFactory.getLogger(BaseWnosJaxbPlugin.class);

    protected JAXBElement<?> processHeaderDirectives(JAXBElement<?> jaxbElement, String docId, String operation, NodeTransaction transaction)
    {
        String addHeader = (String)getConfigValueAsString(ARG_ADD_HEADER, false);
        if(!"true".equalsIgnoreCase(addHeader))
        {
            return jaxbElement;
        }
        ObjectFactory fact = new ObjectFactory();
        ExchangeNetworkDocumentType exchangeNetworkDocumentType = fact.createExchangeNetworkDocumentType();
        exchangeNetworkDocumentType.setId(docId);

        DocumentHeaderType documentHeader = fact.createDocumentHeaderType();
        exchangeNetworkDocumentType.setHeader(documentHeader);
        String authorName = (String)getConfigValueAsString(ARG_HEADER_AUTHOR, false);
        documentHeader.setAuthorName((StringUtils.isNotBlank(authorName) ? authorName: ""));
        String contactInfo = (String)getConfigValueAsString(ARG_HEADER_CONTACT_INFO, false);
        documentHeader.setSenderContact((StringUtils.isNotBlank(contactInfo) ? contactInfo: ""));
        String orgName = (String)getConfigValueAsString(ARG_HEADER_ORG_NAME, false);
        documentHeader.setOrganizationName((StringUtils.isNotBlank(orgName) ? orgName: ""));
        /*String payloadOp = (String)getConfigValueAsString(ARG_HEADER_PAYLOAD_OP, false);
        documentHeader.setSenderContact((StringUtils.isNotBlank(payloadOp) ? payloadOp: ""));*/
        documentHeader.setDocumentTitle(operation + docId);
        documentHeader.setCreationDateTime(getDocumentCreationDateTime());
        documentHeader.setDataFlowName(transaction.getRequest().getFlowName());
        documentHeader.setDataServiceName(transaction.getRequest().getService().getName());

        DocumentPayloadType documentPayloadType = fact.createDocumentPayloadType();
        exchangeNetworkDocumentType.getPayload().add(documentPayloadType);
        documentPayloadType.setId(docId);
        documentPayloadType.setOperation(operation);
        documentPayloadType.setAny(jaxbElement);

        return fact.createDocument(exchangeNetworkDocumentType);
    }

    private XMLGregorianCalendar getDocumentCreationDateTime()
    {
        DatatypeFactory datatypeFactory = null;
        try
        {
            datatypeFactory = DatatypeFactory.newInstance();
        }
        catch(DatatypeConfigurationException e)
        {
            logger.warn("A serious configuration error occured when trying to create a factory to handle XML date objects, recovering, but no dates can be parsed or included in file.",
                        e.getMessage());
            return null;
        }
        return datatypeFactory.newXMLGregorianCalendar(new GregorianCalendar());
    }

    protected void writeDocument(JAXBElement<?> document, String pathname) throws JAXBException, IOException
    {
        Class<?> clazz = document.getValue().getClass();
        StringBuffer packageNames = new StringBuffer(clazz.getPackage().getName());
        //if a header is used the JAXB classes are in a different package, both must be included for the engine to function properly.
        if(document.getValue() instanceof ExchangeNetworkDocumentType)
        {
            ExchangeNetworkDocumentType doc = (ExchangeNetworkDocumentType)document.getValue();
            for(int i = 0; i < doc.getPayload().size(); i++)
            {
                //prepend the package name of every package with JAXBElement domain elements in it
                packageNames.insert(0, ":").insert(0, ((JAXBElement<?>)doc.getPayload().get(i).getAny()).getValue().getClass().getPackage().getName());
            }
        }
        JAXBContext context = JAXBContext.newInstance(packageNames.toString(), clazz.getClassLoader());
        Marshaller m = context.createMarshaller();
        m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
        m.marshal(document, new FileOutputStream(pathname));
    }
}

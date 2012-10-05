package com.windsor.node.plugin.wqx.xml;

import javax.xml.XMLConstants;
import javax.xml.stream.XMLStreamException;
import javax.xml.stream.XMLStreamWriter;

import com.windsor.node.plugin.common.xml.stream.ElementWriterException;
import com.windsor.node.plugin.wqx.domain.OperationType;
import com.windsor.node.plugin.wqx.domain.Header;

public class DeleteXmlOutputStreamWriter extends AbstractWqxOutputStreamWriter {

    private final String organizationIdentifier;

    public DeleteXmlOutputStreamWriter(Header headerData, String organizationIdentifier) throws ElementWriterException {
        super(headerData);
        this.organizationIdentifier = organizationIdentifier;
    }

    @Override
    protected void writeWqxHeaderElement(XMLStreamWriter out) throws ElementWriterException {
        try {

            out.writeStartElement(XmlConstants.NS_WQX_DEFAULT, "WQXDelete");

            out.writeNamespace("xsd", XMLConstants.W3C_XML_SCHEMA_NS_URI);
            out.writeNamespace("xsi", XMLConstants.W3C_XML_SCHEMA_INSTANCE_NS_URI);

            out.writeDefaultNamespace(XmlConstants.NS_WQX_DEFAULT);

            out.writeStartElement(XmlConstants.NS_WQX_DEFAULT, "OrganizationDelete");

            writeOrganizationIdentifier(out);

        } catch (XMLStreamException e) {
            throw new ElementWriterException(e);
        }
    }

    @Override
    protected String operation() {
        return OperationType.Delete.operation();
    }

    private void writeOrganizationIdentifier(XMLStreamWriter out) throws ElementWriterException {
        try {
            out.writeStartElement(XmlConstants.NS_WQX_DEFAULT, "OrganizationIdentifier");
            out.writeCharacters(organizationIdentifier);
            out.writeEndElement();
        } catch (XMLStreamException e) {
            throw new ElementWriterException(e);
        }
    }
}
package com.windsor.node.plugin.wqx.xml;

import javax.xml.XMLConstants;
import javax.xml.stream.XMLStreamException;
import javax.xml.stream.XMLStreamWriter;

import com.windsor.node.plugin.common.xml.stream.ElementWriterException;
import com.windsor.node.plugin.wqx.domain.OperationType;
import com.windsor.node.plugin.wqx.domain.Header;

public class UpdateInsertXmlOutputStreamWriter extends AbstractWqxOutputStreamWriter {

    public UpdateInsertXmlOutputStreamWriter(Header headerData) throws ElementWriterException {
        super(headerData);
    }

    @Override
    protected void writeWqxHeaderElement(XMLStreamWriter out) throws ElementWriterException {

        try {

            out.writeStartElement(XmlConstants.NS_WQX_DEFAULT, "WQX");

            out.writeNamespace("xsd", XMLConstants.W3C_XML_SCHEMA_NS_URI);
            out.writeNamespace("xsi", XMLConstants.W3C_XML_SCHEMA_INSTANCE_NS_URI);

            out.writeDefaultNamespace(XmlConstants.NS_WQX_DEFAULT);

            out.writeStartElement(XmlConstants.NS_WQX_DEFAULT, "Organization");

        } catch (XMLStreamException e) {
            throw new ElementWriterException(e);
        }
    }

    @Override
    protected String operation() {
        return OperationType.UpdateInsert.operation();
    }
}
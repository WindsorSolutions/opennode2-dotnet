package com.windsor.node.plugin.wqx.xml;

import java.util.GregorianCalendar;

import javax.xml.XMLConstants;
import javax.xml.bind.DatatypeConverter;
import javax.xml.stream.XMLStreamException;
import javax.xml.stream.XMLStreamWriter;

import org.apache.commons.lang.StringUtils;

import com.windsor.node.plugin.common.xml.stream.ElementStreamWriter;
import com.windsor.node.plugin.common.xml.stream.ElementWriterException;
import com.windsor.node.plugin.wqx.domain.Header;
import com.windsor.node.plugin.wqx.domain.generated.OrganizationDataType;

public abstract class AbstractWqxOutputStreamWriter extends ElementStreamWriter {

    private final Header headerData;

    public AbstractWqxOutputStreamWriter(final Header headerData) throws ElementWriterException {
        /**
         * Any class from the c.w.n.p.wqx.domain.generated package will work
         */
        super(new Class [] { OrganizationDataType.class } );

        this.headerData = headerData;
    }

    protected boolean isWriteHeader() {
        return Boolean.TRUE;
    }

    protected abstract void writeWqxHeaderElement(XMLStreamWriter out) throws ElementWriterException;

    protected abstract String operation();

    @Override
    protected void onAfterOpen(final XMLStreamWriter out) throws ElementWriterException {

        try {

            if (isWriteHeader()) {

                out.setDefaultNamespace(XmlConstants.NS_WQX_ENHEADER);

                /*
                 * <Document>
                 */
                out.writeStartElement(XmlConstants.NS_WQX_ENHEADER, "Document");

                out.writeNamespace("xsd", XMLConstants.W3C_XML_SCHEMA_NS_URI);
                out.writeNamespace("xsi", XMLConstants.W3C_XML_SCHEMA_INSTANCE_NS_URI);
                out.writeAttribute(XmlConstants.NS_WQX_ENHEADER, "Id", headerData.getDocumentId());

                /*
                 * <Header>
                 */
                out.writeStartElement(XmlConstants.NS_WQX_ENHEADER, "Header");

                writeHeaderElement(out, "Author", headerData.getAuthor());
                writeHeaderElement(out, "Organization", headerData.getOrganization());
                writeHeaderElement(out, "Title", headerData.getTitle());
                writeHeaderElement(out, "CreationTime", DatatypeConverter.printDateTime(new GregorianCalendar()));
                writeHeaderElement(out, "Comment", headerData.getComment());
                writeHeaderElement(out, "ContactInfo", headerData.getContactInfo());

                out.writeEndElement();

                /*
                 * <Payload>
                 */
                out.writeStartElement(XmlConstants.NS_WQX_ENHEADER, "Payload");

                out.writeAttribute("Operation", getOperation());

            }

            /*
             * <WQX>
             */
            out.setDefaultNamespace(XmlConstants.NS_WQX_DEFAULT);

            writeWqxHeaderElement(out);

        } catch (final XMLStreamException e) {
            throw new ElementWriterException(e);
        }
    }

    private void writeHeaderElement(final XMLStreamWriter out, final String element, final String data) throws ElementWriterException {
        try {
            out.writeStartElement(XmlConstants.NS_WQX_ENHEADER, element);
            out.writeCharacters(data);
            out.writeEndElement();
        } catch (final XMLStreamException e) {
            throw new ElementWriterException(e);
        }
    }

    private String getOperation() {
        return (StringUtils.isNotEmpty(operation()) ? operation() : "");
    }
}

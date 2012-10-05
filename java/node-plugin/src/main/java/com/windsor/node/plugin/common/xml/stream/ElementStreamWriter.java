package com.windsor.node.plugin.common.xml.stream;

import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.io.Writer;
import java.util.ArrayList;
import java.util.List;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.stream.FactoryConfigurationError;
import javax.xml.stream.XMLOutputFactory;
import javax.xml.stream.XMLStreamException;
import javax.xml.stream.XMLStreamWriter;

import org.apache.commons.lang3.StringUtils;

/**
 * TODO Document me.
 *
 */
public class ElementStreamWriter implements ElementWriter {

    private XMLStreamWriter out;

    private Marshaller marshaller;

    public ElementStreamWriter(Class<?>...classesToBeBound) throws ElementWriterException {
        try {
            JAXBContext context = JAXBContext.newInstance(makeContextPath(classesToBeBound), this.getClass().getClassLoader());
            marshaller = context.createMarshaller();
            marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, isFormattedOutput());
            marshaller.setProperty(Marshaller.JAXB_FRAGMENT, isFragment());
        } catch (Exception e) {
            throw new ElementWriterException(e);
        }
    }

    private String makeContextPath(Class<?>...classesToBeBound) {

        List<String> packages = new ArrayList<String>();

        for (Class<?> k : classesToBeBound) {
             packages.add(k.getPackage().getName());
        }

        return StringUtils.join(packages, ":");
    }

    protected boolean isFragment() {
        return Boolean.TRUE;
    }

    protected boolean isFormattedOutput() {
        return Boolean.TRUE;
    }

    @Override
    public void open(OutputStream outputStream) throws ElementWriterException {

        try {

            onBeforeOpen();

            Writer writer = new OutputStreamWriter(outputStream, "UTF-8");

            XMLOutputFactory outFactory = XMLOutputFactory.newFactory();

            outFactory.setProperty(XMLOutputFactory.IS_REPAIRING_NAMESPACES, true);

            out = outFactory.createXMLStreamWriter(writer);

            out.writeStartDocument("UTF-8", "1.0");

            onAfterOpen(out);

        } catch (XMLStreamException e) {
            throw new ElementWriterException("Unable to create XML stream writer from outputstream {" + outputStream + "}.", e);
        } catch (FactoryConfigurationError e) {
            throw new ElementWriterException("Unable to create XML stream writer from outputstream {" + outputStream + "}.", e);
        } catch (UnsupportedEncodingException e) {
            throw new ElementWriterException(e);
        }
    }

    @Override
    public void write(JAXBElement<?> element) throws ElementWriterException {
        try {
            marshaller.marshal(element, out);
        } catch (JAXBException e) {
            throw new ElementWriterException("Unable to marshal element {" + element + "} XML stream.", e);
        }
    }

    @Override
    public void close() throws ElementWriterException {
        try {
            onBeforeClose(out);
            out.close();
            onAfterClose();
        } catch (XMLStreamException e) {
            throw new ElementWriterException("Unable to close XML stream writer {" + out + "}.", e);
        }
    }

    protected void onBeforeOpen() throws ElementWriterException { }

    protected void onAfterOpen(XMLStreamWriter out) throws ElementWriterException { }

    protected void onBeforeClose(XMLStreamWriter out) throws ElementWriterException {
        try {
            out.writeEndDocument();
        } catch (XMLStreamException e) {
            throw new ElementWriterException("Unable to write end of document {" + out + "}.", e);
        }
    }

    protected void onAfterClose() {}

}

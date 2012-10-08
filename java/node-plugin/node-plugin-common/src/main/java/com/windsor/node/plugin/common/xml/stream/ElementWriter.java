package com.windsor.node.plugin.common.xml.stream;

import java.io.OutputStream;

import javax.xml.bind.JAXBElement;

public interface ElementWriter {

    void open(OutputStream out) throws ElementWriterException;

    void write(JAXBElement<?> element) throws ElementWriterException;

    void close() throws ElementWriterException;

}

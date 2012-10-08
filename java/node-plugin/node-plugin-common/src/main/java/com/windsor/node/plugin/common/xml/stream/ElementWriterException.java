package com.windsor.node.plugin.common.xml.stream;

public class ElementWriterException extends RuntimeException {

    private static final long serialVersionUID = 1L;

    public ElementWriterException(Throwable t) {
        super(t.getLocalizedMessage(), t);
    }

    public ElementWriterException(String message, Throwable t) {
        super(message, t);
    }
}

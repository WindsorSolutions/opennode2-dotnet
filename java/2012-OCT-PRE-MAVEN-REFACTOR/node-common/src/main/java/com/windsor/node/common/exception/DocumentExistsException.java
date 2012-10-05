package com.windsor.node.common.exception;

import java.io.Serializable;

public class DocumentExistsException extends WinNodeException implements Serializable
{
    private static final long serialVersionUID = 751985153107587166L;

    public DocumentExistsException()
    {
        super();
    }

    public DocumentExistsException(String message, ENExceptionCodeType code)
    {
        super(message, code);
    }

    public DocumentExistsException(String message, Throwable cause, ENExceptionCodeType code)
    {
        super(message, cause, code);
    }

    public DocumentExistsException(String message, Throwable cause)
    {
        super(message, cause);
    }

    public DocumentExistsException(String message)
    {
        super(message);
    }

    public DocumentExistsException(Throwable cause, ENExceptionCodeType code)
    {
        super(cause, code);
    }

    public DocumentExistsException(Throwable cause)
    {
        super(cause);
    }

}

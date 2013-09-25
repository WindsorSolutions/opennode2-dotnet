package com.windsor.node.web.exception;

import com.windsor.node.common.exception.ENExceptionCodeType;
import com.windsor.node.common.exception.WinNodeException;

public class RestException extends WinNodeException
{
    private static final long serialVersionUID = -154593859987002407L;

    public RestException()
    {
        super();
    }

    public RestException(String message, ENExceptionCodeType code)
    {
        super(message, code);
    }

    public RestException(String message, Throwable cause, ENExceptionCodeType code)
    {
        super(message, cause, code);
    }

    public RestException(String message, Throwable cause)
    {
        super(message, cause);
    }

    public RestException(String message)
    {
        super(message);
    }

    public RestException(Throwable cause, ENExceptionCodeType code)
    {
        super(cause, code);
    }

    public RestException(Throwable cause)
    {
        super(cause);
    }
}

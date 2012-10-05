package com.windsor.node.data.dao;

import java.io.Serializable;

public class ArgumentValue implements Serializable
{
    private static final long serialVersionUID = -1968240439349215292L;
    private Object value;
    public Object getValueAsString()
    {
        if(value != null)
        {
            return value.toString();
        }
        return value;
    }
    public Object getValue()
    {
        return value;
    }
    public void setValue(Object value)
    {
        this.value = value;
    }
}

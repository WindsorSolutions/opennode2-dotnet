package com.windsor.node.plugin.uic;

public enum UicOperationType
{
    DELETE_INSERT("Delete-Insert"), DELETE("Delete");

    private static final long serialVersionUID = 2L;
    private String typeString;

    private UicOperationType(String typeString)
    {
        this.typeString = typeString;
    }

    public String toString()
    {
        return this.typeString;
    }
}
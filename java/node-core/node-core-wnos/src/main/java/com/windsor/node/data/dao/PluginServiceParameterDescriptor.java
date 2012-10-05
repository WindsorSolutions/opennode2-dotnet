package com.windsor.node.data.dao;

import java.io.Serializable;

public class PluginServiceParameterDescriptor implements Serializable
{
    private static final long serialVersionUID = -6208666800394939135L;
    public final static String TYPE_UNDEFINED = "java.lang.Object";
    public final static String TYPE_STRING = "java.lang.String";
    public final static String TYPE_LONG = "java.lang.Long";
    public final static String TYPE_DATE = "java.util.Date";
    public final static String TYPE_BOOLEAN = "java.lang.Boolean";
    private String name;
    private String type = PluginServiceParameterDescriptor.TYPE_UNDEFINED;
    private Boolean required = Boolean.TRUE;
    private String description = "No Description Provided";
    private String defaultValue;
    /**
     * Parameter will be considered required
     * @param name
     * @param type
     */
    public PluginServiceParameterDescriptor(String name, String type)
    {
        this.name = name;
        this.type = type;
    }
    public PluginServiceParameterDescriptor(String name, String type, Boolean required)
    {
        this(name, type);
        if(required != null)
        {
            this.required = required;
        }
    }
    /**
     * Parameter will be considered required
     * @param name
     * @param type
     * @param description
     */
    public PluginServiceParameterDescriptor(String name, String type, String description)
    {
        this(name, type);
        this.description = description;
    }
    public PluginServiceParameterDescriptor(String name, String type, Boolean required, String description)
    {
        this(name, type, required);
        this.description = description;
    }
    public PluginServiceParameterDescriptor(String name, String type, Boolean required, String description, String defaultValue)
    {
        this(name, type, required, description);
        this.defaultValue = defaultValue;
    }

    public String getType()
    {
        return type;
    }
    public void setType(String type)
    {
        this.type = type;
    }
    public String getName()
    {
        return name;
    }
    public void setName(String name)
    {
        this.name = name;
    }
    public Boolean getRequired()
    {
        return required;
    }
    public void setRequired(Boolean required)
    {
        this.required = required;
    }
    public String getDescription()
    {
        return description;
    }
    public void setDescription(String description)
    {
        this.description = description;
    }
    public String getDefaultValue()
    {
        return defaultValue;
    }
    public void setDefaultValue(String defaultValue)
    {
        this.defaultValue = defaultValue;
    }
    @Override
    public String toString()
    {
        return "PluginParameterDescriptor [name=" + name + ", type=" + type + ", required=" + required
                        + ", description=" + description + ", defaultValue=" + defaultValue + "]";
    }
}

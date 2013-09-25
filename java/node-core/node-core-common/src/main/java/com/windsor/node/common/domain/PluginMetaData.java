package com.windsor.node.common.domain;

import java.io.Serializable;

public class PluginMetaData implements Serializable
{
    private static final long serialVersionUID = -8642538906602739691L;

    private String name;
    private String fullName;
    private String description;
    private String version;
    private String helpText;

    public PluginMetaData()
    {
    }
    public String getName()
    {
        return name;
    }
    public void setName(String name)
    {
        this.name = name;
    }
    public String getDescription()
    {
        return description;
    }
    public void setDescription(String description)
    {
        this.description = description;
    }
    public String getVersion()
    {
        return version;
    }
    public void setVersion(String version)
    {
        this.version = version;
    }
    public String getFullName()
    {
        return fullName;
    }
    public void setFullName(String fullName)
    {
        this.fullName = fullName;
    }
    public String getHelpText()
    {
        return helpText;
    }
    public void setHelpText(String helpText)
    {
        this.helpText = helpText;
    }

    @Override
    public String toString()
    {
        return "PluginMetaData [name=" + name + ", fullName=" + fullName + ", description=" + description + ", version=" + version + ", helpText="
                        + helpText + "]";
    }
}

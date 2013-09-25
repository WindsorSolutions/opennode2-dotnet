package com.windsor.node.common.domain;

import java.io.Serializable;

public class PluginServiceImplementorDescriptor implements Serializable
{
    private static final long serialVersionUID = 6486628171046702312L;

    private String name;
    private String description;
    private String className;

    public PluginServiceImplementorDescriptor()
    {
        
    }

    public PluginServiceImplementorDescriptor(String name, String description, String version, String className)
    {
        super();
        this.name = name;
        this.description = description;
        this.className = className;
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

    public String getClassName()
    {
        return className;
    }

    public void setClassName(String className)
    {
        this.className = className;
    }

    @Override
    public String toString()
    {
        return "PluginServiceImplementorDescriptor [name=" + name + ", description=" + description + ", className=" + className + "]";
    }
}

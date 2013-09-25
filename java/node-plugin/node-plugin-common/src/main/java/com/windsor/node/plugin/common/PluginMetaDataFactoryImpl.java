package com.windsor.node.plugin.common;

import java.util.Properties;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import com.windsor.node.common.PluginMetaDataFactory;
import com.windsor.node.common.domain.PluginMetaData;

public class PluginMetaDataFactoryImpl implements PluginMetaDataFactory
{
    protected final Logger logger = LoggerFactory.getLogger(PluginMetaDataFactoryImpl.class);

    @Override
    public PluginMetaData createPluginMetaData()
    {
        PluginMetaData pluginMetaData = new PluginMetaData();
        Properties props = new Properties();
        try
        {
            props.load(PluginMetaDataFactoryImpl.class.getClassLoader().getResourceAsStream("plugin-data.properties"));
        }
        catch(Exception e)
        {
            logger.error("Unable to load properties for PluginMetaData due to Exception, recovering but some functionality may be unavailable.", e);
        }
        pluginMetaData.setName(props.getProperty("name"));
        pluginMetaData.setFullName(props.getProperty("full.name"));
        pluginMetaData.setDescription(props.getProperty("description"));
        pluginMetaData.setVersion(props.getProperty("version"));
        pluginMetaData.setHelpText(props.getProperty("help.text"));
        return pluginMetaData;
    }
}

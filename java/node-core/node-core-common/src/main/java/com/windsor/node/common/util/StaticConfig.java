package com.windsor.node.common.util;

public class StaticConfig
{
    public static String SSL_CONFIG;

    public String getSslConfig()
    {
        return StaticConfig.SSL_CONFIG;
    }

    public void setSslConfig(String sslConfig)
    {
        StaticConfig.SSL_CONFIG = sslConfig;
    }
}

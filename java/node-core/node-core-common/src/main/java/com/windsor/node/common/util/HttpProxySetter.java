/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

package com.windsor.node.common.util;

import java.io.Serializable;
import java.util.Properties;
import org.springframework.beans.factory.InitializingBean;

/**
 * Contrary to name will set HTTP and HTTPS proxy config
 * @author tmurdock
 */
public class HttpProxySetter implements InitializingBean, Serializable
{

    private static final long serialVersionUID = 1;

    private String httpHostName;
    private String httpPortNumber;
    private String httpsHostName;
    private String httpsPortNumber;
    private boolean useProxyConfig = false;

    public void afterPropertiesSet() throws Exception
    {
        if(useProxyConfig)
        {
            Properties props = new Properties(System.getProperties());
            setProperty(props, "http.proxySet", "true");
            setProperty(props, "http.proxyHost", httpHostName);
            setProperty(props, "http.proxyPort", httpPortNumber);
            setProperty(props, "https.proxyHost", httpsHostName);
            setProperty(props, "https.proxyPort", httpsPortNumber);
            Properties newprops = new Properties(props);
            System.setProperties(newprops);
        }
    }

    private void setProperty(Properties props, String key, String value)
    {
        {
            props.remove(key);
        }
        props.put(key, value);
    }

    public String getHttpHostName()
    {
        return httpHostName;
    }

    public void setHttpHostName(String httpHostName)
    {
        this.httpHostName = httpHostName;
    }

    public String getHttpPortNumber()
    {
        return httpPortNumber;
    }

    public void setHttpPortNumber(String httpPortNumber)
    {
        this.httpPortNumber = httpPortNumber;
    }

    public String getHttpsHostName()
    {
        return httpsHostName;
    }

    public void setHttpsHostName(String httpsHostName)
    {
        this.httpsHostName = httpsHostName;
    }

    public String getHttpsPortNumber()
    {
        return httpsPortNumber;
    }

    public void setHttpsPortNumber(String httpsPortNumber)
    {
        this.httpsPortNumber = httpsPortNumber;
    }

    public boolean isUseProxyConfig()
    {
        return useProxyConfig;
    }

    public void setUseProxyConfig(boolean useProxyConfig)
    {
        this.useProxyConfig = useProxyConfig;
    }
}
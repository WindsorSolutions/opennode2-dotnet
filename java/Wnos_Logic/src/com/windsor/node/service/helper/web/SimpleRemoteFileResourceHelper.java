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

package com.windsor.node.service.helper.web;

import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.service.helper.RemoteFileResourceHelper;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class SimpleRemoteFileResourceHelper implements
        RemoteFileResourceHelper, InitializingBean {

    private static final Logger logger = Logger
            .getLogger(SimpleRemoteFileResourceHelper.class);

    private SettingServiceProvider settingProvider;

    public void afterPropertiesSet() {

        if (settingProvider == null) {
            throw new RuntimeException("SettingProvider not set");
        }

    }

    /**
     * getBytesFromURL
     */
    public byte[] getBytesFromURL(String address) {

        try {

            URL url = new URL(address);
            URLConnection conn = url.openConnection();
            InputStream fis = conn.getInputStream();
            ByteArrayOutputStream byteArrOut = new ByteArrayOutputStream();

            int ln;
            byte[] buf = new byte[1024 * 12];
            while ((ln = fis.read(buf)) != -1) {
                byteArrOut.write(buf, 0, ln);
            }
            return byteArrOut.toByteArray();

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while getting content from Url: "
                    + address, ex);
        }

    }

    public void setSettingProvider(SettingServiceProvider settingProvider) {
        this.settingProvider = settingProvider;
    }

}
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

package com.windsor.node.service.helper.header;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Iterator;
import java.util.Map;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.service.helper.HeaderDocumentHelper;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class SimpleHeaderDocumentHelper implements HeaderDocumentHelper,
        InitializingBean {

    private final Logger logger = LoggerFactory
            .getLogger(SimpleHeaderDocumentHelper.class);

    private static final Format formatter = new SimpleDateFormat(
            "yyyy-MM-dd'T'HH:mm:ss");

    private SettingServiceProvider settingProvider;

    public void afterPropertiesSet() {

        if (settingProvider == null) {
            throw new RuntimeException("SettingProvider not set");
        }

    }

    public byte[] makeHeader(String author, String title, String serviceName,
            String contactInfo, String[] notifications,
            String organizationName, Map properties, String sensitivity,
            String payloadOperation, byte[] payload) {

        OutputStreamWriter out = null;

        File resultFile = new File(settingProvider.getTempFilePath(".xml"));

        try {

            OutputStream fos = new FileOutputStream(resultFile);
            OutputStream bout = new BufferedOutputStream(fos, 1024 * 16);
            out = new OutputStreamWriter(bout, "UTF-8");

            // Xml
            out.write("<?xml version=\"1.0\" ");
            out.write("encoding=\"UTF-8\"?>");

            // Document
            out
                    .write("<Document xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ");
            out
                    .write("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
            out.write("Id=\"\" ");
            out
                    .write("xmlns=\"http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd\">\n");

            // Header
            out.write("<Header xmlns=\"\">");
            out.write("<Author>" + author + "</Author>");
            out.write("<Organization>" + organizationName + "</Organization>");
            out.write("<Title>" + title + "</Title>");
            out.write("<CreationTime>" + formatter.format(new Date())
                    + "</CreationTime>");
            out.write("<DataService>" + serviceName + "</DataService>");
            out.write("<ContactInfo>" + contactInfo + "</ContactInfo>");

            if (notifications != null) {
                for (int i = 0; i < notifications.length; i++) {
                    out.write("<Notification>" + notifications[i]
                            + "</Notification>");
                }
            }

            out.write("<Sensitivity>" + sensitivity + "</Sensitivity>");

            if (properties != null) {

                Iterator propsKeyValuePair = properties.entrySet().iterator();

                while (propsKeyValuePair.hasNext()) {

                    Map.Entry entry = (Map.Entry) propsKeyValuePair.next();

                    out.write("<Property>");
                    out.write("<name>" + entry.getKey() + "</name>");
                    out.write("<value>" + entry.getValue() + "</value>");
                    out.write("</Property>");

                }
            }

            out.write("</Header>");

            // Payload
            out.write("<Payload Operation=\"" + payloadOperation
                    + "\" xmlns=\"\">");

            out.write(new String(payload));

            out.write("</Payload></Document>");

            out.close();

            return FileUtils.readFileToByteArray(resultFile);

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error whole building header: "
                    + ex.getMessage());

        }

    }

    public File makeHeader(String author, String title, String serviceName,
            String contactInfo, String[] notifications,
            String organizationName, Map properties, String sensitivity,
            String payloadOperation, File payload) {

        try {

            logger.debug("Getting bytes from payload");
            byte[] source = FileUtils.readFileToByteArray(payload);

            logger.debug("Making header");
            byte[] target = makeHeader(author, title, serviceName, contactInfo,
                    notifications, organizationName, properties, sensitivity,
                    payloadOperation, source);

            File resultFile = new File(FilenameUtils.concat(settingProvider
                    .getTempDir().getAbsolutePath(), "Header-"
                    + payload.getName()));

            logger.debug("Writting source bytes to datatarget file: " + resultFile);
            FileUtils.writeByteArrayToFile(resultFile, target);

            logger.debug("Header made");
            return resultFile;

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error while making header: "
                    + ex.getMessage(), ex);
        }

    }

    public void setSettingProvider(SettingServiceProvider settingProvider) {
        this.settingProvider = settingProvider;
    }

}

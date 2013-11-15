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

package com.windsor.node.service.helper.email;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.InputStream;
import java.rmi.RemoteException;
import java.util.List;
import java.util.Map;
import javax.mail.internet.MimeMessage;
import org.apache.commons.lang3.StringUtils;
import org.apache.velocity.app.VelocityEngine;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.core.io.ByteArrayResource;
import org.springframework.core.io.FileSystemResource;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.springframework.mail.javamail.MimeMessagePreparator;
import org.springframework.ui.velocity.VelocityEngineUtils;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.exception.WinNodeException;

public class EmailMessagePreparator implements InitializingBean,
        MimeMessagePreparator {

    protected final Logger logger = LoggerFactory.getLogger(this.getClass());

    private VelocityEngine velocityEngine;

    private String template;

    private String from;

    private String to;

    private String subject;

    private Map data;

    private File attachment;
    private List<Document> attachments;

    public void configure(String to, Map data) {
        this.to = to;
        this.data = data;
        this.attachment = null;
    }

    public void configure(String to, Map data, File attachment) {
        this.to = to;
        this.data = data;
        this.attachment = attachment;
    }

    public void configure(String to, Map data, List<Document> attachments) {
        this.to = to;
        this.data = data;
        this.attachments = attachments;
    }

    /**
     * Override of the Spring implementation of property validation after
     * initialization
     */
    public void afterPropertiesSet() {
        try {

            if (StringUtils.isBlank(template)) {
                throw new RemoteException("Template file does not exist");
            }

            if (velocityEngine == null) {
                throw new RemoteException("Velocity Engine Not Set");
            }

            if (!velocityEngine.resourceExists(template)) {
                throw new RemoteException("Velocity unable to find template: "
                        + template);
            }

        } catch (Exception ex) {
            throw new RuntimeException(ex);
        }

    }

    /**
     * @param msg
     *            MimeMessage
     * @throws Exception
     *             during runtime
     */
    public void prepare(MimeMessage msg) throws Exception
    {

        MimeMessageHelper helper = null;
        try
        {

            boolean isAttachments = attachment != null || (attachments != null && attachments.size() > 0);
            helper = new MimeMessageHelper(msg, isAttachments);

            helper.setFrom(from);
            helper.setTo(to);
            helper.setSubject(subject);

            //TODO Set UTF-8 encoding for the new 3rd param (1 based counting) to get rid of deprecated 
            helper.setText(VelocityEngineUtils.mergeTemplateIntoString(velocityEngine, template, data), true);

            if(attachment != null)
            {
                helper.addAttachment(attachment.getName(), new FileSystemResource(attachment));
            }
            if(attachments != null && attachments.size() > 0)
            {
                for(int i = 0; i < attachments.size(); i++)
                {
                    Document document = attachments.get(i);
                    if(document != null)
                    {
                        ByteArrayResource resource = new ByteArrayResource(document.getContent());
                        helper.addAttachment(document.getDocumentName(), resource);
                    }
                }
            }
        }
        catch(Exception ex)
        {
            logger.error("Error while preparing message: " + ex.getMessage());
            if(helper != null)
            {
                logger.error(helper.toString());
            }
            logger.error(ex.getMessage(), ex);

            throw new WinNodeException("Error while preparing message: " + ex.getMessage(), ex);
        }
    }

    public void setVelocityEngine(VelocityEngine velocityEngine) {
        this.velocityEngine = velocityEngine;
    }

    public void setTemplate(String template) {
        this.template = template;
    }

    public void setFrom(String from) {
        this.from = from;
    }

    public void setTo(String to) {
        this.to = to;
    }

    public void setSubject(String subject) {
        this.subject = subject;
    }

    public void setData(Map data) {
        this.data = data;
    }

}

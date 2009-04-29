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

package com.windsor.node.plugin.common.staging;

import java.util.List;
import java.util.Map;

import org.apache.log4j.Logger;

import com.windsor.node.plugin.common.dao.TextLoader;

public abstract class BaseXmlStaging implements XmlStaging {

    protected Logger logger = Logger.getLogger(getClass());

    protected TextLoader loader;

    protected StringBuffer xmlBuffer = null;

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.plugin.common.XmlStaging#execute(java.lang.String,
     * boolean)
     */
    public void execute(StringBuffer xml, boolean isFinal) {

        logger.trace("execute xml: " + xml);

        if (null == loader) {

            throw new RuntimeException("TextLoader not set");
        }

        if (xmlBuffer == null) {

            logger.debug("Starting new document buffer");

            xmlBuffer = new StringBuffer();

            logger.debug("Buffering " + getDocumentOpen());

            xmlBuffer.append(getDocumentOpen());
        }

        if (null != xml) {

            logger.debug("Appending to document buffer");

            xmlBuffer.append(xml);
        }

        if (isFinal) {

            logger.debug("Buffering " + getDocumentClose());

            xmlBuffer.append(getDocumentClose());

            logger.debug("Closing document buffer");

            try {

                loader.loadText(xmlBuffer.toString());

            } catch (Exception e) {

                throw new RuntimeException(e.getMessage(), e);

            } finally {

                xmlBuffer = null;
            }

        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.common.XmlStaging#getStartTag(java.lang.String)
     */
    public String getStartTag(String tagname) {

        return "<" + tagname + ">";
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.common.XmlStaging#getEndTag(java.lang.String)
     */
    public String getEndTag(String tagname) {

        return "</" + tagname + ">";
    }

    public TextLoader getTextLoader() {
        return loader;
    }

    public void setTextLoader(TextLoader loader) {
        this.loader = loader;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.plugin.common.XmlStaging#getDocumentClose()
     */
    public abstract String getDocumentClose();

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.plugin.common.XmlStaging#getDocumentOpen()
     */
    public abstract String getDocumentOpen();

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.plugin.common.XmlStaging#getListElementMap()
     */
    public abstract Map getListElementMap();

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.plugin.common.XmlStaging#getListNames()
     */
    public abstract List getListNames();

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.plugin.common.XmlStaging#setBatchSize(int)
     */
    public abstract void setBatchSize(int batchSize);

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.plugin.common.XmlStaging#getBatchSize()
     */
    public abstract int getBatchSize();
}
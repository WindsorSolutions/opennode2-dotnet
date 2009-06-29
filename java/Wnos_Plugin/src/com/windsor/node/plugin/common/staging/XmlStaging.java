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

import com.windsor.node.plugin.common.XmlFileToClobProcessor;
import com.windsor.node.plugin.common.dao.TextLoader;

/**
 * Provides support to {@link XmlFileToClobProcessor XmlFileToClobProcessor},
 * allowing parsed content to be written to any appropriate data store (e.g., an
 * RDBMS or filesystem, etc.).
 * 
 */
public interface XmlStaging {

    /**
     * Process the Xml content.
     * 
     * @param xml
     *            a chunk of Xml text
     * @param isFinal
     *            indicates whether this is the final piece of a well-formed Xml
     *            payload
     */
    void execute(StringBuffer xml, boolean isFinal);

    /**
     * @return the maxmimum number of list elements to be written at once
     */
    int getBatchSize();

    /**
     * @param the
     *            maxmimum number of list elements to be written at once
     */
    void setBatchSize(int size);

    /**
     * @return the names of top-level lists in the Xml file being staged
     */
    List getListNames();

    /**
     * Keys are names of top-level lists, values are Lists of top-level list
     * elements.
     * 
     * @return the Map of list names to element-name lists
     */
    Map getListElementMap();

    /**
     * @return the opening tag of the document being processed
     */
    String getDocumentOpen();

    /**
     * @return the closing tag of the document being processed
     */
    String getDocumentClose();

    /**
     * @param tagname
     * @return &lt;tagname&gt;
     */
    String getStartTag(String tagname);

    /**
     * @param tagname
     * @return &lt;/tagname&gt;
     */
    String getEndTag(String tagname);

    /**
     * For loading text to a data store.
     * 
     * @param loader
     */
    void setTextLoader(TextLoader loader);

    /**
     * @return the TextLoader implementation
     */
    TextLoader getTextLoader();
}

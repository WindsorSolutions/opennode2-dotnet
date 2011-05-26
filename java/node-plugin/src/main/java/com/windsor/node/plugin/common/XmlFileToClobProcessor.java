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

package com.windsor.node.plugin.common;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.Iterator;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.plugin.common.staging.XmlStaging;

/**
 * Reads an Xml file into a database column of type CLOB, and invokes a stored
 * procedure for processing the data.
 * 
 * <p>
 * In a typical scenario, a file is submitted to a DataService and read into a
 * staging database. Then a stored procedure is called to store the stored Xml
 * into relational tables. The related {@link XmlStaging XmlStaging}
 * implementation takes care of the database interactions.
 * </p>
 * 
 * <p>
 * This class assumes an XML file that consists of top-level elements that
 * contain sequences of other elements. We can specify a batchSize value, which
 * limits the number of list items buffered for inserting into the database. We
 * don't use a SAX parser, because we don't want to handle every element.
 * </p>
 * 
 */
public class XmlFileToClobProcessor {

    protected Logger logger = LoggerFactory.getLogger(getClass());

    private XmlStaging xmlStaging;

    private static final String XML_PREAMBLE = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

    /**
     * Constructor.
     * 
     * @param dataSource
     *            DataSource providing access to the staging database
     * @param procedureName
     *            name of the stored procedure that will further process the
     *            data
     * @param batchSize
     *            max number of top-level elements to be loaded before writing
     *            the list/document closing tags
     */
    public XmlFileToClobProcessor(XmlStaging xmlStaging) {

        this.xmlStaging = xmlStaging;

    }

    public void processXmlFile(String filename) {

        String listName = null;// , listStart = null, listEnd = null;

        try {

            FileReader fr = new FileReader(filename);
            BufferedReader br = new BufferedReader(fr);

            StringBuffer xmlBuf = null;

            Iterator listNameIter = xmlStaging.getListNames().iterator();

            while (listNameIter.hasNext()) {

                xmlBuf = newBufferIfNull(xmlBuf);

                listName = (String) listNameIter.next();

                /*
                 * Is this list limited by batchSize? If xmlStaging doesn't have
                 * a list of element names to count for this list, then just
                 * copy lines
                 */
                if (xmlStaging.getListElementMap().get(listName) == null) {

                    copyList(br, listName);

                } else {
                    /*
                     * if the list is limited by batchSize, xmlStaging has a
                     * list of element names to count
                     */

                    copyListWithSizeLimit(br, listName);
                }
            }

        } catch (FileNotFoundException fnfe) {

            String msg = "File " + filename + " not found";
            logger.error(msg);
            throw new RuntimeException(msg, fnfe);

        } catch (IOException ioe) {

            String msg = "Problem reading file " + filename;
            logger.error(msg);
            throw new RuntimeException(msg, ioe);
        }

    }

    private StringBuffer newBufferIfNull(StringBuffer xmlBuf) {

        if (xmlBuf == null) {

            xmlBuf = new StringBuffer();

            logger.debug("initialized xmlBuf");
        }

        return xmlBuf;
    }

    private void bufferLine(StringBuffer xmlBuf, String line) {

        logger.trace("buffering line: " + line);
        xmlBuf.append(line.trim());
    }

    /**
     * Copies a list from the input file to a well-formed xml packet.
     * 
     * @param br
     * @param listName
     * @throws IOException
     */
    private void copyList(BufferedReader br, String listName)
            throws IOException {

        String line = null;
        String listStart = xmlStaging.getStartTag(listName);
        String listEnd = xmlStaging.getEndTag(listName);

        logger.debug("Copying list " + listName + " verbatim");

        StringBuffer xmlBuf = null;

        boolean continueList = false;

        /* process one line at a time */
        while ((line = br.readLine()) != null) {

            xmlBuf = newBufferIfNull(xmlBuf);

            if (StringUtils.contains(line, listStart)) {

                logger.debug("found list starting tag " + listStart
                        + " in file");
                continueList = true;
            }

            if (continueList) {

                bufferLine(xmlBuf, line);
            }

            if (StringUtils.contains(line, listEnd)) {

                logger.debug("found list ending tag " + listEnd + " in file");

                continueList = false;
                xmlStaging.execute(xmlBuf, false);
                xmlBuf = null;

                /* break out of readLine loop */
                break;
            }

        }
        /* end while readLine.... */
    }

    /**
     * Copies a list from the input file to a well-formed xml packet, limited by
     * the batchSize set in the XmlStaging implementation; each list goes to an
     * individual output packet.
     * 
     * 
     * @param br
     * @param listName
     * @throws IOException
     */
    private void copyListWithSizeLimit(BufferedReader br, String listName)
            throws IOException {

        String line = null;
        String listStart = xmlStaging.getStartTag(listName);
        String listEnd = xmlStaging.getEndTag(listName);

        logger.debug("Copying list " + listName + " with batchSize = "
                + xmlStaging.getBatchSize());

        StringBuffer xmlBuf = null;

        List elementsToCount = (List) xmlStaging.getListElementMap().get(
                listName);

        Iterator elementIter = elementsToCount.iterator();

        while (elementIter.hasNext()) {

            String elementName = (String) elementIter.next();

            String elementEnd = xmlStaging.getEndTag(elementName);

            int listItemCount = 0;

            boolean continueList = false;

            /* process one line at a time */
            while ((line = br.readLine()) != null) {

                /*
                 * ignore file preamble - this is an issue only if a batched
                 * list is at the start of the file
                 */

                if (StringUtils.contains(line, XML_PREAMBLE)
                        || StringUtils.contains(line, xmlStaging
                                .getDocumentOpen())) {
                    line = br.readLine();
                }

                if (xmlBuf == null) {

                    xmlBuf = newBufferIfNull(xmlBuf);

                    if (!continueList) {

                        logger.debug("(re)starting list " + listName);
                        bufferLine(xmlBuf, listStart);
                        continueList = true;
                    }
                }

                if (StringUtils.contains(line, listStart)) {

                    logger.debug("found list starting tag " + listStart
                            + " in file");

                    continueList = true;

                } else if (StringUtils.contains(line, listEnd)) {

                    logger.debug("found list ending tag " + listEnd
                            + " in file");

                    /* close the list */
                    continueList = false;
                    listItemCount = 0;
                    bufferLine(xmlBuf, line);
                    xmlStaging.execute(xmlBuf, true);
                    xmlBuf = null;

                    /* move on to the next list */
                    break;

                } else if (StringUtils.contains(line, elementEnd)) {

                    listItemCount++;
                    boolean isFinal = false;

                    /* have we hit the batchSize limit? */
                    if (xmlStaging.getBatchSize() > 0
                            && listItemCount == xmlStaging.getBatchSize()) {

                        logger.debug("reached batchSize of "
                                + xmlStaging.getBatchSize());

                        /* explicitly close the list */
                        continueList = false;
                        listItemCount = 0;
                        bufferLine(xmlBuf, line);
                        bufferLine(xmlBuf, listEnd);
                        isFinal = true;

                    } else {

                        bufferLine(xmlBuf, line);
                        continueList = true;
                    }

                    xmlStaging.execute(xmlBuf, isFinal);

                    /*
                     * continue reading input until we see the list end in the
                     * input file
                     */
                    xmlBuf = null;

                } else {
                    /* just copy lines that don't meet any of the prior tests */
                    bufferLine(xmlBuf, line);
                }
            }
            /* end while readLine.... */
        }
        /* end looping over list elements */
    }
}

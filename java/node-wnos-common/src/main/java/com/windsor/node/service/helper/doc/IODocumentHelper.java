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

package com.windsor.node.service.helper.doc;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.service.helper.DocumentHelper;
import com.windsor.node.util.IOUtil;

public class IODocumentHelper implements DocumentHelper, InitializingBean {

    /** Logger for this class and subclasses */
    private static final Logger logger = LoggerFactory
            .getLogger(IODocumentHelper.class);

    private String ioRepositoryPath;

    /**
     * afterPropertiesSet
     */
    public void afterPropertiesSet() {

        if (ioRepositoryPath == null) {
            throw new RuntimeException("Repository path not set");
        }

        File rootDir = new File(ioRepositoryPath);

        if (!rootDir.exists()) {
            throw new RuntimeException("Repository path invalid");
        }

        if (!rootDir.isDirectory()) {
            throw new RuntimeException(
                    "Repository path valid, but not a directory");
        }

    }

    /**
     * deleteDocuments
     */
    public void deleteDocuments(String transactionID) {

        try {

            File tranFile = getTransactionDir(transactionID);

            logger.debug("tranFile: " + tranFile);

            FileUtils.forceDelete(tranFile);

        } catch (Exception ex) {
            logger.error("Error while executting deleteDocuments:"
                    + ex.getMessage());
            throw new RuntimeException("Error while getting document:", ex);
        }

    }

    /**
     * getDocumentContent
     */
    public byte[] getDocumentContent(String transactionID, String documentID) {

        try {

            File docFile = getTransactionDocument(transactionID, documentID,
                    true);

            logger.debug("docFile: " + docFile);

            if (docFile == null || !docFile.exists() || !docFile.isFile()) {
                throw new RuntimeException(
                        "Unable to find a document. May indicate a discrepancy "
                                + "between the docs in DB and IO repository!");
            }

            return FileUtils.readFileToByteArray(docFile);

        } catch (Exception ex) {
            logger.error("Error while executting getDocumentContent:"
                    + ex.getMessage());
            throw new RuntimeException("Error while getting document:", ex);
        }
    }

    /**
     * getDocumentList
     */
    public String[] getDocumentList(String transactionID) {
        try {

            List files = new ArrayList();

            File[] allFiles = getTransactionDir(transactionID).listFiles();

            for (int i = 0; i < allFiles.length; i++) {

                if (allFiles[i].isFile()) {

                    logger.debug("file: " + allFiles[i].getName());

                    files.add(allFiles[i].getName());
                }
            }

            return (String[]) files.toArray();

        } catch (Exception ex) {
            logger.error("Error while executting getDocumentList:"
                    + ex.getMessage());
            throw new RuntimeException("Error while getting document:", ex);
        }
    }

    /**
     * saveDocument
     */
    public void saveDocument(String documentID, String transactionID,
            byte[] documentContent) {

        try {

            File newFile = getTransactionDocument(transactionID, documentID,
                    false);

            logger.debug("Writting content to: " + newFile);

            FileUtils.writeByteArrayToFile(newFile, documentContent);

        } catch (Exception ex) {
            logger.error("Error while executting saveDocument:"
                    + ex.getMessage());
            throw new RuntimeException("Error while saving document:", ex);
        }

    }

    /*
     * Private Methods
     */

    private File getTransactionDocument(String transactionID,
            String documentID, boolean throwOnNull) throws RuntimeException {

        File dir = getTransactionDir(transactionID);

        logger.debug("Transaction Directory Path: " + dir);

        String transactionFilePath = FilenameUtils.concat(
                dir.getAbsolutePath(), IOUtil.cleanForPath(documentID));

        logger.debug("Transaction File Path: " + transactionFilePath);

        File doc = new File(transactionFilePath);

        if (throwOnNull && !doc.exists()) {
            throw new RuntimeException("file not found: "
                    + doc.getAbsolutePath());
        }

        return doc;

    }

    private File getTransactionDir(String transactionID)
            throws RuntimeException {

        if (StringUtils.isBlank(transactionID)) {
            throw new RuntimeException("transactionID not set.");
        }

        File tranDir = new File(FilenameUtils.concat(ioRepositoryPath, IOUtil
                .cleanForPath(transactionID)));

        logger.debug("Testing Transaction Dir: " + tranDir);

        if (!tranDir.exists()) {

            logger.debug("Creating Transaction Dir: " + tranDir);

            if (!tranDir.mkdir()) {
                throw new RuntimeException(
                        "Unable to create the necessary transaction directory: "
                                + tranDir.getAbsolutePath());
            }
        }

        return tranDir;

    }

    /*
     * Properties
     */

    public void setIoRepositoryPath(String ioRepositoryPath) {
        this.ioRepositoryPath = ioRepositoryPath;
    }

}

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

package com.windsor.node.worker.util;

import java.io.File;
import java.io.IOException;
import java.util.Date;

import org.apache.commons.io.FileUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.util.DateUtil;
import com.windsor.node.worker.NodeWorker;

public class TempCleanupWorker extends NodeWorker implements InitializingBean {

    private int keepFileForNumberOfHours = 3;

    public TempCleanupWorker() {
        super();
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();
    }

    /**
     * Dows nto throw an error
     */
    public void run() {

        try {

            logger.debug("getting temp files");

            File[] tempFiles = getNosConfig().getTempDir().listFiles();
            logger.debug("found: " + tempFiles.length);

            Date yesterday = DateUtil.getNextNHour(DateUtil.getNow(),
                    -keepFileForNumberOfHours);
            logger.debug("compare date: " + yesterday);

            for (int i = 0; i < tempFiles.length; i++) {

                logger.debug("test: " + tempFiles[i]);

                try {

                    Date fileLastModDate = new Date(tempFiles[i].lastModified());
                    logger.debug("file modified date: " + fileLastModDate);

                    if (fileLastModDate.before(yesterday)) {
                        logger.debug("deleting: " + tempFiles[i]);
                        FileUtils.forceDelete(tempFiles[i]);
                    }

                } catch (IOException fde) {
                    logger.error("error while deleting file: " + tempFiles[i]);
                    logger.error(fde.getMessage(), fde);
                }

            }

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
        }

    }

    public void setKeepFileForNumberOfHours(int keepFileForNumberOfHours) {
        this.keepFileForNumberOfHours = keepFileForNumberOfHours;
    }

}
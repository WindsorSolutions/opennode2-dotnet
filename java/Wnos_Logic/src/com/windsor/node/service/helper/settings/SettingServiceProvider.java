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

package com.windsor.node.service.helper.settings;

import java.io.File;

import org.apache.commons.io.FilenameUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.SettingsService;
import com.windsor.node.service.helper.email.EmailNotificationHelper;
import com.windsor.node.service.helper.id.UUIDGenerator;

public class SettingServiceProvider implements SettingsService,
        InitializingBean {

    /** Logger for this class and subclasses */
    private static final Logger logger = Logger
            .getLogger(EmailNotificationHelper.class);

    private IdGenerator idGenerator;
    private File tempDir;
    private File logDir;

    public void afterPropertiesSet() {

        if (idGenerator == null) {
            idGenerator = new UUIDGenerator();
        }

        if (tempDir == null) {
            throw new RuntimeException("TempDir not set");
        }

        if (!tempDir.exists()) {
            throw new RuntimeException("TempDir set but does not exist: "
                    + tempDir);
        }

        if (!tempDir.canWrite()) {
            throw new RuntimeException("TempDir exists but not writeable: "
                    + tempDir);
        }

        if (logDir == null) {
            throw new RuntimeException("logDir not set");
        }

        if (!logDir.exists()) {
            throw new RuntimeException("logDir set but does not exist: "
                    + logDir);
        }

        if (!logDir.canRead()) {
            throw new RuntimeException("logDir exist but not readable: "
                    + logDir);
        }

    }

    public File getLogDir() {
        return logDir;
    }

    public String getLogFilePath() {

        return logDir.getAbsolutePath();
    }

    public File getTempDir() {
        return tempDir;
    }

    public String getTempFilePath() {

        return FilenameUtils.concat(tempDir.getAbsolutePath(), idGenerator
                .createId());

    }

    public String getTempFilePath(String ext) {

        logger.debug("getTempFilePath: " + ext);

        return FilenameUtils.concat(tempDir.getAbsolutePath(), idGenerator
                .createId()
                + "." + ext);

    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

    public void setTempDir(File tempDir) {
        this.tempDir = tempDir;
    }

    public void setLogDir(File logDir) {
        this.logDir = logDir;
    }

}
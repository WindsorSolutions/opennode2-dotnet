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

import java.io.BufferedOutputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;

import javax.sql.DataSource;

import org.apache.commons.lang3.time.StopWatch;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.ProcessContentResult;

public abstract class BaseDocumentBuilder implements DocumentBuilder {

    protected StopWatch stopWatch;

    protected Logger logger = LoggerFactory.getLogger(getClass());

    protected BaseDocumentBuilder() {

        stopWatch = new StopWatch();
    }

    public abstract void buildDocument(DataSource ds, String targetFilePath,
            ProcessContentResult result);

    public abstract void buildDocument(DataSource ds, String targetFilePath,
            ProcessContentResult result, int maxListItems);

    protected void makeEntry(ProcessContentResult result, String message) {
        logger.debug(message);
        result.getAuditEntries().add(new ActivityEntry(message));
    }

    protected void makeErrorEntry(ProcessContentResult result, String message) {
        logger.error(message);
        result.getAuditEntries().add(new ActivityEntry(message));
    }

    protected OutputStreamWriter getWriter(String targetFilePath)
            throws UnsupportedEncodingException, FileNotFoundException {
        OutputStreamWriter out;
        out = new OutputStreamWriter(new BufferedOutputStream(
                new FileOutputStream(targetFilePath), 1024 * 24), "UTF-8");
        return out;
    }

    protected StopWatch getStopWatch() {
        return stopWatch;
    }

    protected void setStopWatch(StopWatch stopWatch) {
        this.stopWatch = stopWatch;
    }

}

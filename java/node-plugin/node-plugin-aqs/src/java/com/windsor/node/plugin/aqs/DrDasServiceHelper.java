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

/**
 * 
 */
package com.windsor.node.plugin.aqs;

import java.net.MalformedURLException;
import java.net.URL;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.plugin.aqs.wsdl.AQDEDataSoap;
import com.windsor.node.plugin.aqs.wsdl.AQDEDataSoapStub;

/**
 * @author mchmarny
 * 
 */
public class DrDasServiceHelper {

    public final Logger logger = LoggerFactory.getLogger(getClass());

    private final AQDEDataSoap stub;
    private final ByIndexOrNameMap args;
    private final String schemaVersion;

    public class MonitorServiceArgList {
        public static final int fileGenerationPurposeCode = 0;
        public static final int substanceName = 1;
        public static final int monitorType = 2;
        public static final int stateName = 3;
        public static final int countyName = 4;
        public static final int cityName = 5;
        public static final int tribeName = 6;
        public static final int facilitySiteIdentifier = 7;
        public static final int minLatitudeMeasure = 8;
        public static final int maxLatitudeMeasure = 9;
        public static final int minLongitudeMeasure = 10;
        public static final int maxLongitudeMeasure = 11;
        public static final int lastUpdatedDate = 12;
    }

    public class RawDataServiceArgList {
        public static final int fileGenerationPurposeCode = 0;
        public static final int beginDate = 1;
        public static final int beginTime = 2;
        public static final int endDate = 3;
        public static final int endTime = 4;
        public static final int timeType = 5;
        public static final int sampleDuration = 6;
        public static final int substanceName = 7;
        public static final int monitorType = 8;
        public static final int dataValidityCode = 9;
        public static final int dataApprovalIndicator = 10;
        public static final int stateName = 11;
        public static final int countyName = 12;
        public static final int cityName = 13;
        public static final int tribeName = 14;
        public static final int facilitySiteIdentifier = 15;
        public static final int minLatitudeMeasure = 16;
        public static final int maxLatitudeMeasure = 17;
        public static final int minLongitudeMeasure = 18;
        public static final int maxLongitudeMeasure = 19;
        public static final int lastUpdatedDate = 20;
        public static final int includeMonitorDetails = 21;
        public static final int includeEventData = 22;
    }

    public DrDasServiceHelper(String url, ByIndexOrNameMap args,
            String schemaVersion) {

        logger.info("Service Url: " + url);
        logger
                .info("Args: "
                        + StringUtils.join(args.toValueStringArray(), "|"));
        logger.info("Schema: " + schemaVersion);

        this.args = args;
        this.schemaVersion = schemaVersion;

        URL serviceUrl = null;
        try {
            serviceUrl = new URL(url);
        } catch (MalformedURLException mfe) {
            throw new RuntimeException("Invalid Reporter Service Url: " + url,
                    mfe);
        }

        try {
            this.stub = new AQDEDataSoapStub(serviceUrl, null);
        } catch (Throwable aex) {
            throw new RuntimeException(
                    "Error while initializing Reporter Service with: "
                            + serviceUrl + " Message: " + aex.getMessage(), aex);
        }
    }

    private String getAsString(Object val) {
        if (val == null) {
            return null;
        } else {
            String valStr = (String) val;
            if (StringUtils.isBlank(valStr)) {
                return null;
            } else {
                return StringUtils.trimToEmpty(valStr);
            }
        }
    }

    public byte[] executeMonitorData() throws Exception {

        String resultXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
        resultXml += stub
                .queryAQSMonitorData(
                        getAsString(args
                                .get(MonitorServiceArgList.fileGenerationPurposeCode)),
                        getAsString(args
                                .get(MonitorServiceArgList.substanceName)),
                        getAsString(args.get(MonitorServiceArgList.monitorType)),
                        getAsString(args.get(MonitorServiceArgList.stateName)),
                        getAsString(args.get(MonitorServiceArgList.countyName)),
                        getAsString(args.get(MonitorServiceArgList.cityName)),
                        getAsString(args.get(MonitorServiceArgList.tribeName)),
                        getAsString(args
                                .get(MonitorServiceArgList.facilitySiteIdentifier)),
                        getAsString(args
                                .get(MonitorServiceArgList.minLatitudeMeasure)),
                        getAsString(args
                                .get(MonitorServiceArgList.maxLatitudeMeasure)),
                        getAsString(args
                                .get(MonitorServiceArgList.minLongitudeMeasure)),
                        getAsString(args
                                .get(MonitorServiceArgList.maxLongitudeMeasure)),
                        getAsString(args
                                .get(MonitorServiceArgList.lastUpdatedDate)),
                        schemaVersion);

        logger.debug("resultXml: " + resultXml);

        return resultXml.getBytes();
    }

    /**
     * executeRawData
     * 
     * @param args
     * @param schemaVersion
     * @param requestId
     * @return
     * @throws Exception
     */
    public String executeRawData(String requestId) throws Exception {

        String resultFilePath = stub
                .solicitAQSRawData(
                        getAsString(args
                                .get(RawDataServiceArgList.fileGenerationPurposeCode)),
                        getAsString(args.get(RawDataServiceArgList.beginDate)),
                        getAsString(args.get(RawDataServiceArgList.beginTime)),
                        getAsString(args.get(RawDataServiceArgList.endDate)),
                        getAsString(args.get(RawDataServiceArgList.endTime)),
                        getAsString(args.get(RawDataServiceArgList.timeType)),
                        getAsString(args
                                .get(RawDataServiceArgList.sampleDuration)),
                        getAsString(args
                                .get(RawDataServiceArgList.substanceName)),
                        getAsString(args.get(RawDataServiceArgList.monitorType)),
                        getAsString(args
                                .get(RawDataServiceArgList.dataValidityCode)),
                        getAsString(args
                                .get(RawDataServiceArgList.dataApprovalIndicator)),
                        getAsString(args.get(RawDataServiceArgList.stateName)),
                        getAsString(args.get(RawDataServiceArgList.countyName)),
                        getAsString(args.get(RawDataServiceArgList.cityName)),
                        getAsString(args.get(RawDataServiceArgList.tribeName)),
                        getAsString(args
                                .get(RawDataServiceArgList.facilitySiteIdentifier)),
                        getAsString(args
                                .get(RawDataServiceArgList.minLatitudeMeasure)),
                        getAsString(args
                                .get(RawDataServiceArgList.maxLatitudeMeasure)),
                        getAsString(args
                                .get(RawDataServiceArgList.minLongitudeMeasure)),
                        getAsString(args
                                .get(RawDataServiceArgList.maxLongitudeMeasure)),
                        getAsString(args
                                .get(RawDataServiceArgList.lastUpdatedDate)),
                        getAsString(args
                                .get(RawDataServiceArgList.includeMonitorDetails)),
                        getAsString(args
                                .get(RawDataServiceArgList.includeEventData)),
                        schemaVersion, requestId, "false");

        logger.info("resultFilePath: " + resultFilePath);

        return resultFilePath;

    }

}

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
 * AQDEDataSoap.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis WSDL2Java emitter.
 */

package com.windsor.node.plugin.aqs.wsdl;

public interface AQDEDataSoap extends java.rmi.Remote {
    public java.lang.String solicitAQSRawData(
            java.lang.String fileGenerationPurposeCode,
            java.lang.String beginDate, java.lang.String beginTime,
            java.lang.String endDate, java.lang.String endTime,
            java.lang.String timeType, java.lang.String sampleDuration,
            java.lang.String substanceName, java.lang.String monitorType,
            java.lang.String dataValidityCode,
            java.lang.String dataApprovalIndicator, java.lang.String stateName,
            java.lang.String countyName, java.lang.String cityName,
            java.lang.String tribeName,
            java.lang.String facilitySiteIdentifier,
            java.lang.String minLatitudeMeasure,
            java.lang.String maxLatitudeMeasure,
            java.lang.String minLongitudeMeasure,
            java.lang.String maxLongitudeMeasure,
            java.lang.String lastUpdatedDate,
            java.lang.String includeMonitorDetails,
            java.lang.String includeEventData, java.lang.String schemaVersion,
            java.lang.String requestId, java.lang.String compressionEnabled)
            throws java.rmi.RemoteException;

    public java.lang.String queryAQSRawData(
            java.lang.String fileGenerationPurposeCode,
            java.lang.String beginDate, java.lang.String beginTime,
            java.lang.String endDate, java.lang.String endTime,
            java.lang.String timeType, java.lang.String sampleDuration,
            java.lang.String substanceName, java.lang.String monitorType,
            java.lang.String dataValidityCode,
            java.lang.String dataApprovalIndicator, java.lang.String stateName,
            java.lang.String countyName, java.lang.String cityName,
            java.lang.String tribeName,
            java.lang.String facilitySiteIdentifier,
            java.lang.String minLatitudeMeasure,
            java.lang.String maxLatitudeMeasure,
            java.lang.String minLongitudeMeasure,
            java.lang.String maxLongitudeMeasure,
            java.lang.String lastUpdatedDate,
            java.lang.String includeMonitorDetails,
            java.lang.String includeEventData, java.lang.String schemaVersion)
            throws java.rmi.RemoteException;

    public java.lang.String queryAQSMonitorData(
            java.lang.String fileGenerationPurposeCode,
            java.lang.String substanceName, java.lang.String monitorType,
            java.lang.String stateName, java.lang.String countyName,
            java.lang.String cityName, java.lang.String tribeName,
            java.lang.String facilitySiteIdentifier,
            java.lang.String minLatitudeMeasure,
            java.lang.String maxLatitudeMeasure,
            java.lang.String minLongitudeMeasure,
            java.lang.String maxLongitudeMeasure,
            java.lang.String lastUpdatedDate, java.lang.String schemaVersion)
            throws java.rmi.RemoteException;
}
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

/*
 * Created on Sep 20, 2004
 *
 */
package com.windsor.node.ws1.util;

import java.rmi.RemoteException;

import javax.xml.parsers.DocumentBuilderFactory;

import org.apache.axis.AxisFault;
import org.apache.log4j.Logger;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

/**
 * @author mchmarny
 * 
 */
public final class NodeFault {

    public static final int E_INVALIDSQL = 0;

    public static final int E_UNKNOWNUSER = 1;

    public static final int E_INVALIDPARAMETER = 2;

    public static final int E_ACCESSRIGHT = 3;

    public static final int E_TRANSACTIONID = 4;

    public static final int E_UNKNOWNMETHOD = 5;

    public static final int E_SERVICEUNAVAILABLE = 6;

    public static final int E_ACCESSDENIED = 7;

    public static final int E_INVALIDTOKEN = 8;

    public static final int E_TOKENEXPIREDTOKEN = 9;

    public static final int E_FILENOTFOUND = 10;

    public static final int E_VALIDATIONFAILED = 11;

    public static final int E_SERVERBUSY = 12;

    public static final int E_ROWIDOUTOFRANGE = 13;

    public static final int E_FEATUREUNSUPPORTED = 14;

    public static final int E_INVALIDFILENAME = 15;

    public static final int E_INVALIDFILETYPE = 16;

    public static final int E_INVALIDDATAFLOW = 17;

    public static final int E_INTERNALERROR = 18;

    public static final int E_AUTHMETHOD = 19;

    public static final String[] NODE_FAULT_CODES = { "E_INVALIDSQL",
            "E_UNKNOWNUSER", "E_INVALIDPARAMETER", "E_ACCESSRIGHT",
            "E_TRANSACTIONID", "E_UNKNOWNMETHOD", "E_SERVICEUNAVAILABLE",
            "E_ACCESSDENIED", "E_INVALIDTOKEN", "E_TOKENEXPIREDTOKEN",
            "E_FILENOTFOUND", "E_VALIDATIONFAILED", "E_SERVERBUSY",
            "E_ROWIDOUTOFRANGE", "E_FEATUREUNSUPPORTED", "E_INVALIDFILENAME",
            "E_INVALIDFILETYPE", "E_INVALIDDATAFLOW", "E_INTERNALERROR",
            "E_AUTHMETHOD" };

    private static final Logger LOGGER = Logger.getLogger(NodeFault.class);


    private NodeFault() {
    }
    
    /**
     * 
     * @param faultCode
     * @param faultDetail
     * @throws RemoteException
     */
    public static void throwFault(int faultCodeID, String faultDetail)
            throws RemoteException {

        AxisFault fault = new AxisFault();

        String falutDetails = "faultdetail";
        String faulterrorCode = "errorcode";
        String faultDescription = "description";

        try {

            // FAULT

            // fault.setFaultCode("soapenv:Client");
            fault.setFaultCodeAsString("soapenv:Client");

            fault.setFaultString(faultDetail);

            fault.setFaultActor("cdx.wsdl");

            fault.clearFaultDetails();

            // DETAIL

            Document document = DocumentBuilderFactory.newInstance()
                    .newDocumentBuilder().newDocument();

            Element faultDetails = document.createElement(falutDetails);

            Element errorCode = document.createElement(faulterrorCode);
            errorCode.appendChild(document
                    .createTextNode(NODE_FAULT_CODES[faultCodeID]));

            faultDetails.appendChild(errorCode);

            Element description = document.createElement(faultDescription);
            description.appendChild(document.createTextNode(faultDetail));
            faultDetails.appendChild(description);

            fault.setFaultDetail(new Element[] { faultDetails });

        } catch (Exception ex) {
            LOGGER.error("Error while trying to generate Node Fault: "
                    + ex.getMessage(), ex);
        }

        LOGGER.error("dumpToString: \n\n" + fault.dumpToString());

        throw fault;

    }

}
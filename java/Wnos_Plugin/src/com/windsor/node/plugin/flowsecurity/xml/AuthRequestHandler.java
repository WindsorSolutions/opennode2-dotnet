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

package com.windsor.node.plugin.flowsecurity.xml;

import java.sql.Timestamp;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;
import org.xml.sax.ext.DefaultHandler2;

import com.windsor.node.common.domain.flowsecurity.AuthRequestElementType;
import com.windsor.node.common.domain.flowsecurity.AuthorizationRequest;
import com.windsor.node.common.domain.flowsecurity.FlowRequest;
import com.windsor.node.util.DateUtil;

/**
 * SAX Document Handler for Flow Security authorization requests - maps an xml
 * payload to a single AutorizationRequest instance.
 * 
 * <p>
 * Stateful, not thread-safe.
 * </p>
 * 
 */
public class AuthRequestHandler extends DefaultHandler2 {

    private AuthorizationRequest authRequest;
    private AuthRequestElementType currentElement;
    private StringBuffer characterBuffer;
    private StringBuffer nodeIdsBuffer;
    private boolean readingElement = false;

    private Logger logger = Logger.getLogger(getClass());

    public AuthRequestHandler() {
        super();
    }

    public void startDocument() throws SAXException {

        logger.trace("startDocument");
        authRequest = new AuthorizationRequest();
    }

    public void startElement(String uri, String localName, String qName,
            Attributes attributes) {

        String elementName;

        if (StringUtils.isBlank(uri)) {
            elementName = qName;
        } else {
            elementName = localName;
        }

        logger.trace("startElement: " + elementName);

        currentElement = AuthRequestElementType.valueOf(elementName);

        if (!currentElement.equals(AuthRequestElementType.AuthorizationRequest)) {
            readingElement = true;
            /*
             * since the xsd defines no nested sub-elements, we can create a new
             * buffer for element content here
             */
            characterBuffer = new StringBuffer();
        }
    }

    public void endElement(String uri, String localName, String qName) {

        String elementName;

        if (StringUtils.isBlank(uri)) {
            elementName = qName;
        } else {
            elementName = localName;
        }

        logger.trace("endElement: " + elementName);

        if (!elementName.equals(AuthRequestElementType.AuthorizationRequest
                .name())) {

            handleElement(elementName);
            readingElement = false;
        }
    }

    private Timestamp getTimestampFromString(String elementData) {

        return DateUtil.xmlDateTimeToJdbcTimestamp(elementData);

    }

    private void addNodeId(String elementData) {

        if (null == nodeIdsBuffer) {
            nodeIdsBuffer = new StringBuffer();
        }

        if (StringUtils.isNotBlank(nodeIdsBuffer.toString())) {
            nodeIdsBuffer.append(", ");
        }

        nodeIdsBuffer.append(elementData);

    }

    private void addFlowRequest(String elementData) {

        FlowRequest fr = new FlowRequest();
        fr.setFlowName(elementData);
        authRequest.getRequestedFlows().add(fr);

    }

    public void characters(char[] ch, int start, int length) {

        if (readingElement) {

            if (null == characterBuffer) {
                throw new RuntimeException("characterBuffer cannot be null");
            }

            for (int i = start; i < start + length; i++) {
                characterBuffer.append(ch[i]);
            }

            logger.trace("characterBuffer: " + characterBuffer.toString());
        }
    }

    public void endDocument() throws SAXException {

        authRequest.setRequestedNodeIds(nodeIdsBuffer.toString());

        logger.trace("endDocument");
        logger.trace("authRequest: " + authRequest);
    }

    private void handleElement(String elementName) {

        String elementData = characterBuffer.toString();

        characterBuffer = null;

        switch (currentElement) {

        case GeneratedOn:
            /* convert elementData to jdbc timestamp format */
            authRequest
                    .setRequestGeneratedOn(getTimestampFromString(elementData));
            break;

        case AccountExistsInNaas:
            authRequest.setExistsInNaas(Boolean.parseBoolean(elementData));
            break;

        case RequestType:
            authRequest.setRequestType(elementData);
            break;

        case NaasUsername:
            authRequest.setNaasUserName(elementData);
            break;

        case FullName:
            authRequest.setFullName(elementData);
            break;

        case OrganizationAffiliation:
            authRequest.setOrgAffiliation(elementData);
            break;

        case TelephoneNumber:
            authRequest.setPhoneNumber(elementData);
            break;

        case EmailAddress:
            authRequest.setEmailAddress(elementData);
            break;

        case AffiliatedNodeId:
            authRequest.setAffiliatedNodeId(elementData);
            break;

        case AffiliatedCounty:
            authRequest.setAffiliatedCounty(elementData);
            break;

        case PurposeDescription:
            authRequest.setPurposeDescription(elementData);
            break;

        case RequestedDataSourceNames:
            addFlowRequest(elementData);
            break;

        case RequestedNodeIds:
            addNodeId(elementData);
            break;

        default:
            break;

        }

    }

    public void error(SAXParseException e) {

        logger.error("SAX Error at line #" + e.getLineNumber() + ", column #"
                + e.getColumnNumber() + "\nMessage: " + e.getMessage());
    }

    public void fatalError(SAXParseException e) {

        logger.error("SAX Fatal Error at line #" + e.getLineNumber()
                + ", column #" + e.getColumnNumber() + "\nMessage: "
                + e.getMessage());
    }

    public void warning(SAXParseException e) {

        logger.warn("SAX Warning at line #" + e.getLineNumber() + ", column #"
                + e.getColumnNumber() + "\nMessage: " + e.getMessage());
    }

    public AuthorizationRequest getAuthRequest() {
        return authRequest;
    }
}

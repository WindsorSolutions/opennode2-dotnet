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
 * Endpoint2FaultMessage.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:24:30 EDT)
 */

package com.windsor.node.ws2;

import net.exchangenetwork.www.schema.node._2.ErrorCodeList;
import net.exchangenetwork.www.schema.node._2.NodeFaultDetailType;

public class Endpoint2FaultMessage extends java.lang.Exception {

    private static final long serialVersionUID = 1;

    private NodeFaultDetailType faultMessage = new NodeFaultDetailType();

    public Endpoint2FaultMessage() {
        super("Endpoint2FaultMessage");
        faultMessage.setDescription("Error description not defined");
        faultMessage.setErrorCode(ErrorCodeList.E_Unknown);
    }

    public Endpoint2FaultMessage(String s) {
        super(s);
        faultMessage.setDescription(s);
        faultMessage.setErrorCode(ErrorCodeList.E_Unknown);
    }

    public Endpoint2FaultMessage(NodeFaultDetailType faultMessage) {
        super(faultMessage.getDescription());
        this.faultMessage = faultMessage;
    }

    public Endpoint2FaultMessage(String s, Throwable ex) {
        super(s, ex);
        faultMessage.setDescription(s);
        faultMessage.setErrorCode(ErrorCodeList.E_Unknown);
    }

    public void setFaultMessage(NodeFaultDetailType msg) {
        faultMessage = msg;
    }

    public NodeFaultDetailType getFaultMessage() {
        return faultMessage;
    }

    @Override
    public String toString()
    {
        return "Endpoint2FaultMessage [faultMessage=" + faultMessage + "]";
    }
}
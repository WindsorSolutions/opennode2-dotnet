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

package com.windsor.node.ws2.util;

import net.exchangenetwork.www.schema.node._2.ErrorCodeList;
import net.exchangenetwork.www.schema.node._2.NodeFaultDetailType;

import org.apache.axiom.om.OMElement;
import org.apache.axis2.AxisFault;
import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;

import com.windsor.node.ws2.Endpoint2FaultMessage;

public class FaultUtil {

	private static final Logger logger = Logger.getLogger(FaultUtil.class
			.getName());

	/**
	 * parseNodeFault
	 * 
	 * @param ex
	 * @return
	 */
	public static Endpoint2FaultMessage parseNodeFault(Exception ex) {

		logger.error("Parsing Exception: " + ex);

		Endpoint2FaultMessage result = null;

		if (ex == null) {
			result = new Endpoint2FaultMessage("Null Exception");
		}

		if (ex instanceof AxisFault) {

			AxisFault fault = (AxisFault) ex;
			logger.error(fault);

			if (fault.getDetail() == null) {
				result = new Endpoint2FaultMessage("Null Node fault detail");
			}

			try {

				// org.apache.axiom.om
				OMElement faultElt = fault.getDetail();
				logger.debug(faultElt);

				NodeFaultDetailType faultDetail = NodeFaultDetailType.Factory
						.parse(faultElt.getXMLStreamReader());

				logger.debug(faultDetail);

				if (StringUtils.isNotBlank(ex.getMessage())) {
					faultDetail.setDescription(ex.getMessage() + " ("
							+ faultDetail.getErrorCode() + "-"
							+ faultDetail.getDescription() + ")");
				}

				result = new Endpoint2FaultMessage(faultDetail);

			} catch (Exception innerEx) {

				String exMessage = "Error while parsing fault:"
						+ innerEx.getMessage();
				logger.error(exMessage, innerEx);
				result = new Endpoint2FaultMessage(exMessage, innerEx);
			}

		} else {
			logger.error(ex);
			result = new Endpoint2FaultMessage(ex.getMessage(), ex);
		}

		logger.error(result);
		return result;

	}

	public static final Endpoint2FaultMessage makeFault(ErrorCodeList code,
			String description) {

		Endpoint2FaultMessage fault = new Endpoint2FaultMessage();
		NodeFaultDetailType details = new NodeFaultDetailType();
		details.setErrorCode(code);
		details.setDescription(description);
		fault.setFaultMessage(details);
		return fault;

	}

}
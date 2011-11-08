<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
    <tr>
        <td id="sidebarPane" align="left"><%@ include file="/WEB-INF/jsp/_bar.jsp"%></td>
        <td id="contentPane">

        <div id="pageTitle"><fmt:message key="secTitle" /></div>
        <div class="introText"><fmt:message key="secIntroText" /></div>

        <p style="clear: both;" />

        <div class="sectionHead">
            <fmt:message key="secAuthReqMgrSectionTitle" />
        </div>
        <div class="introText"><fmt:message key="secAuthReqMgrIntroText" /></div>

        <c:if test="${error != null}">
            <div class="error"><c:out value="${error}"></c:out></div>
        </c:if>
		
        <c:choose>
            <c:when test="${ model.noRequestsPending }" >
                <div class="introText"><strong>No pending Authorization Requests.</strong></div>
            </c:when>
            <c:otherwise>				
            <c:forEach var="authRequest" items="${model.authRequests}" varStatus="status">
                <form method="post" action="authrequest-submit.htm">
		            <table id="wrapperTable" width="100%" cellpadding="2" cellspacing="0">
	                    <tr style="background-color: #83ACCA; color:#FFF;">
	                        <td width="4%" align="right">
	                            <img alt="" src="img/user.png" style="border: 0; vertical-align: middle; padding-right: 3px;" />
	                        </td>
	                        <td width="32%" nowrap="nowrap" >
	                            <input type="hidden" name="id" value="<c:out value="${authRequest.id}" />" />
	                            <strong><c:out value="${authRequest.fullName}" /></strong>
                                <input type="hidden" name="fullName" value="<c:out value="${authRequest.fullName}" />" />
	                        </td>
	                        <td width="32%" align="center" nowrap="nowrap" >
	                            <strong>(<c:out value="${authRequest.emailAddress}" />)</strong>
	                        </td>
	                        <td width="32%" align="right" nowrap="nowrap" >
	                            Requested:&nbsp;<fmt:formatDate type="date" pattern="MM/dd/yyyy" value="${authRequest.requestGeneratedOn}" />
	                            <input type="hidden" name="requestGeneratedOn" value="<c:out value="${authRequest.requestGeneratedOn}" />"/>
	                        </td>
	                    </tr>
	                    <tr>
	                        <td></td>
	                        <td colspan="3">
	                            <table id="formTable" width="100%" cellpadding="2" cellspacing="0" class="basicTable">
		                            <tr>
		                                <td class="listlabel"style="text-align: right; vertical-align: top;">
		                                    Affiliated State:
		                                </td>
		                                <td>
		                                    <c:out value="${authRequest.affiliatedNodeId}" />
                                               <input type="hidden" name="affiliatedNodeId" value="<c:out value="${authRequest.affiliatedNodeId}" />" />
		                                </td>
		                            </tr>
		                            <tr>
	                                    <td class="listlabel"style="text-align: right; vertical-align: top;">
		                                    Organization:
		                                </td>
		                                <td>
	                                        <c:out value="${authRequest.orgAffiliation}" />
                                               <input type="hidden" name="orgAffiliation" value="<c:out value="${authRequest.orgAffiliation}" />" />
		                                </td>
		                            </tr>
			                            <tr>
		                                    <td class="listlabel"style="text-align: right; vertical-align: top;">
			                                    Contact Email:
			                                </td>
			                                <td>
		                                        <c:out value="${authRequest.emailAddress}" />
                                                <input type="hidden" name="emailAddress" value="<c:out value="${authRequest.emailAddress}" />" />
			                                </td>
			                            </tr>
			                            <tr>
		                                    <td class="listlabel"style="text-align: right; vertical-align: top;">
			                                    Contact Phone #:
			                                </td>
			                                <td>
		                                        <c:out value="${authRequest.phoneNumber}" />
                                                <input type="hidden" name="phoneNumber" value="<c:out value="${authRequest.phoneNumber}" />" />
			                                </td>
			                            </tr>
			                            <tr>
		                                    <td class="listlabel"style="text-align: right; vertical-align: top;">
		                                        Request Purpose:
			                                </td>
			                                <td>
		                                        <c:out value="${authRequest.purposeDescription}" />
                                                <input type="hidden" name="purposeDescription" value="<c:out value="${authRequest.purposeDescription}" />" />
			                                </td>
			                            </tr>
		                                <tr>
		                                    <td class="listlabel"style="text-align: right; vertical-align: top;">
		                                        Requested Flows:
		                                    </td>
		
		                                    <td>
		                                    <table id="formTable" width="100%" cellpadding="2" cellspacing="0" class="basicTable">
		                                    
		                                            <c:forEach var="requestedFlow" items="${authRequest.requestedFlows}" varStatus="status">
		                                              <tr class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when><c:otherwise>rowEven</c:otherwise></c:choose>">
		                                                <td width="4%" align="right" valign="middle">
		                                                    <label for="<c:out value="requestedFlows[${status.index}].accessGranted" />">
		                                                      <img alt="" src="img/flow2.gif" style="border: 0; padding-right: 3px;" />
		                                                    </label>
		                                                </td>
		                                                <td  width="76%" nowrap="nowrap">
		                                                  <input type="hidden" 
		                                                      name="<c:out value="requestedFlows[${status.index}].id" />" 
		                                                      value="<c:out value="${requestedFlow.id}" />" />
		                                                  <label for="<c:out value="requestedFlows[${status.index}].accessGranted" />">
		                                                      <c:out value="${requestedFlow.flowName}" />
		                                                  </label>
                                                          <input type="hidden" 
                                                              name="<c:out value="requestedFlows[${status.index}].flowName" />" 
                                                              value="<c:out value="${requestedFlow.flowName}" />" />
		                                                </td>
		                                                 <td nowrap="nowrap" width="20%" align="right" valign="middle" style="text-align: right">
		                                                    <input type="checkbox" 
                                                                id="<c:out value="requestedFlows[${status.index}].accessGranted" />"
		                                                        name="<c:out value="requestedFlows[${status.index}].accessGranted" />"/>
		                                                    <label for="<c:out value="requestedFlows[${status.index}].accessGranted" />">Allow</label>
		                                                 </td>
		                                              </tr>
		                                            </c:forEach>
		                                        </table>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td class="listlabel"style="text-align: right; vertical-align: top;">
		                                        Comments:
		                                    </td>
                                            <td>
		                                        <input type="text" 
		                                            name="authorizationComments" 
		                                            value="<c:out value="${authRequest.authorizationComments}" />" 
		                                            class="textbox"
		                                            align="right"  
		                                            style="width: 98%;" />
		                                    </td>
		                                </tr>
			                            <tr>
			                                <td colspan="2" class="command" align="right">
				                                <input type="submit" 
				                                    name="accept" 
				                                    value="Accept"
				                                    class="button" /> 
				                                <input type="submit" 
				                                    name="reject"
				                                    value="Reject" 
				                                    class="button" />
			                                </td>
			                            </tr>
				                    </table>
				                </td>
				            </tr>
		                </table>
                    </form>
		        </c:forEach>
            </c:otherwise>
        </c:choose>
    </td>
</tr>
</table>



<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
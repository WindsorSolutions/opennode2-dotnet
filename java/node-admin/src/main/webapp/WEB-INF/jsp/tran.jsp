<%@ include file="/WEB-INF/jsp/_head.jsp"%>


<table id="contentTable">
    <tr>

        <td id="contentPane">

        <div id="pageTitle"><fmt:message key="tranTitle" /></div>
        <div class="introText"><fmt:message key="tranIntroText" /></div>

        <p style="clear: both;" />

        <div style="clear: both; text-align: right; margin-bottom: 10px">
        <c:if test="${model.tran.networkEndpointUrl != null}">
            <input type="button" id="downloadButton" value="Download" class="button" style="width:120px" 
                onclick="window.location.href='download.htm?transactionId=<c:out value="${model.tran.id}" />'" />
        </c:if>
        <c:if test="${model.tran.networkEndpointUrl != null}">
            <input type="button" id="getStatusButton" value="Get Status" class="button"  style="width:120px" 
                onclick="window.location.href='getStatus.htm?transactionId=<c:out value="${model.tran.id}" />'" />
        </c:if>
            <form method="post" action="activity.htm" style="display:inline">
                <input type="submit" value="Back" class="button" style="width:120px"  />
            </form>
        </div>

        <c:choose>
            <c:when test="${model.tran != null}">

                <table id="formTable" width="750" cellpadding="2" cellspacing="0">

                            <tr style="background-color: #83ACCA; color:#FFF;">
                <td colspan="2"><strong>Transaction Details</strong></td>
            </tr>

                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Transaction Id:</td>
                        <td class="ctrl"><c:out value="${model.tran.id}" /></td>
                    </tr>
                    
                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Network Id:</td>
                        <td class="ctrl"><c:out value="${model.tran.networkId}" /></td>
                    </tr>
                    
                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Current Status:</td>
                        <td class="ctrl"><c:out value="${model.tran.status.status}" /></td>
                    </tr>

                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Status Details:</td>
                        <td class="ctrl"><c:out value="${model.tran.status.description}" /></td>
                    </tr>

                    <%-- <c:if test="${model.tran.webMethod != null}"> --%>
                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Service Type:</td>
                        <td class="ctrl"><c:out value="${model.tran.webMethod.name}" /></td>
                    </tr>
                    <%-- </c:if> --%>

                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Exchange:</td>
                        <td class="ctrl">
                        <c:if test="${model.tran.flow.secured}"><img 
                            alt="Protected flow: requires a policy in addition to the NAAS token" 
                            src="img/icon_padlock.gif" 
                            style="border: 0; vertical-align: middle; padding-right: 3px;" />
                        </c:if><c:out value="${model.tran.flow.name}" /></td>
                    </tr>

                    <%-- <c:if test="${model.tran.operation != null}"> --%>
                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Data Operation:</td>
                        <td class="ctrl"><c:out value="${model.tran.operation}" /></td>
                    </tr>
                    <%-- </c:if> --%>

                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Last Modified By:</td>
                        <td class="ctrl"><c:out value="${model.tran.creator.naasUserName}" /></td>
                    </tr>

                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;">Last Modified On:</td>
                        <td class="ctrl"><fmt:formatDate type="both" dateStyle="long" 
                        timeStyle="long" value="${model.tran.modifiedOn}" />
                        </td>
                    </tr>

                    <c:if test="${model.tran.request != null}">

                            <tr style="background-color: #83ACCA; color:#FFF;">
                <td colspan="2"><strong>Request Details</strong></td>
            </tr>

                        <tr>
                            <td class="label" width="50" style="text-align: right; vertical-align: top;">Name:</td>
                            <td class="ctrl"><c:out
                                value="${model.tran.request.service.name}" /></td>
                        </tr>
                        
                        <tr>
                            <td class="label" width="50" style="text-align: right; vertical-align: top;">Implementor:</td>
                            <td class="ctrl"><c:out
                                value="${model.tran.request.service.implementingClassName}" /></td>
                        </tr>
                        
                        <tr>
                            <td class="label" width="50" style="text-align: right; vertical-align: top;">Rows:</td>
                            <td class="ctrl"><c:out
                                value="${model.tran.request.paging.start}" /> to <c:out
                                value="${model.tran.request.paging.count}" /></td>
                        </tr>


                        <tr>
                            <td class="label" width="50" style="text-align: right; vertical-align: top;">Type:</td>
                            <td class="ctrl"><c:out
                                value="${model.tran.request.type.name}" /></td>
                        </tr>


                        <c:if test="${model.tran.request.parameters != null}">

                        <tr>
                            <td class="label" width="50" style="text-align: right; vertical-align: top;">Arguments:</td>
                            <td class="ctrl"><ul>
                                <c:forEach var="arg" 
                                           items="${model.tran.request.parameterValues}" 
                                           varStatus="argStatus">
                                    <li>
                                        <c:out value="${arg}" />
                                    </li>
                                </c:forEach>
                            </ul>
                            </td>
                        </tr>
                        </c:if>
                        
                        
                        
                        <c:if test="${model.tran.request.recipients != null}">
                        <tr>
                            <td class="label" width="50" style="text-align: right; vertical-align: top;">Recipients:</td>
                            <td class="ctrl"><ul>
                                <c:forEach var="rec" items="${model.tran.request.recipients}" 
                                varStatus="recStatus">
                                    <li>
                                        <c:out value="${rec}" />
                                    </li>
                                </c:forEach>
                            </ul>
                            </td>
                        </tr>
                        </c:if>
                        
                        <c:if test="${model.tran.request.notifications != null}">
                        <tr>
                            <td class="label" width="50" style="text-align: right; vertical-align: top;">Notifications:</td>
                            <td class="ctrl"><ul>
                                <c:forEach var="notif" items="${model.tran.request.notifications}" 
                                varStatus="notifStatus">
                                    <li>
                                        <c:out value="${notif.value}" />:<c:out value="${notif.key}" />
                                    </li>
                                </c:forEach>
                            </ul>
                            </td>
                        </tr>
                        </c:if>
                        
                    
                    </c:if>
                    
                    <c:if test="${model.tran.documents != null}">
                    
                                        
                    <tr style="background-color: #83ACCA; color:#FFF;">
                        <td colspan="2"><strong>Documents Details</strong></td>
                    </tr>
                
                
                    <tr>
                        <td class="label" width="50" style="text-align: right; vertical-align: top;"><span>Documents:</span></td>
                        <td class="ctrl">
                          <table border="0" cellpadding="1" cellspacing="0">
                            <c:forEach var="doc" items="${model.tran.documents}" varStatus="docStatus">    
                              <tr>
                                <td nowrap="nowrap" valign="top">
                                    <img src="img/icon_attachment.gif" align="top" style="border-width:0px;vertical-align:top">File:
                                </td>
                                <td><a href="doc.htm?tid=<c:out value="${model.tran.id}" />&id=<c:out value="${doc.id}" />&name=<c:out value="${doc.documentName}" />"><c:out value="${doc.documentName}" />&nbsp;(<c:out value="${doc.type.name}" />)</a></td>
                              </tr>
                            </c:forEach>
                            </table>
                        </td>
                    </tr>
                    </c:if>

                </table>




            </c:when>
            
            <c:otherwise>
            
            <div class="error">Unable to find transaction with that Id.</div>
            
            </c:otherwise>
            
        </c:choose>

        </td>

    </tr>

</table>



<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
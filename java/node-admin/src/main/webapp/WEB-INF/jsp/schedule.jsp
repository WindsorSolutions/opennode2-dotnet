<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
    <tr>
        <td id="sidebarPane" align="left"><%@ include
            file="/WEB-INF/jsp/_bar.jsp"%></td>
        <td id="contentPane">

        <div id="pageTitle"><fmt:message key="scheduleTitle" /></div>
        <div class="introText"><fmt:message key="scheduleIntroText" /></div>

        <p style="clear: both;" />
        <div class="sectionHead"><fmt:message key="scheduleSectionTitle" /></div>
        <div class="introText"><fmt:message key="scheduleSectionIntroText" /></div>
            
        <c:if test="${error != null}">
            <div class="error"><c:out value="${error}"></c:out></div>
        </c:if>

        <div style="clear: both; text-align: right; margin-bottom: 10px">
        <input type="button" name="cmdNew" value="Add" class="button"
            onclick="location.href='schedule-edit.htm'" style="width: 85px" /></div>

        <c:forEach var="flow" items="${model.flows}" varStatus="flowStatus">
        <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
            <tr style="background-color: #83ACCA; color:#FFF;">
                <td width="2%" align="right">
	                <img alt="" src="img/flow2.gif" style="border: 0; vertical-align: middle; padding-right: 3px;" />
	            </td>
	            <td width="93%">
	                <strong><c:out value="${flow.name}" /></strong>
	                <c:if test="${flow.secured == true}">&nbsp;(Protected)</c:if>
	            </td>
	            <td width="5%" align="right">&nbsp;</td>
            </tr>
            <c:forEach var="schedule" items="${model.schedules}" varStatus="status">
                <c:choose>
                    <c:when test="${row eq 'rowEven' or row eq null}">
                        <c:set var="row" value="rowOdd"/>
                    </c:when>
                    <c:otherwise>
                        <c:set var="row" value="rowEven"/>
                    </c:otherwise>
                </c:choose>
                
                <c:if test="${flow.id eq schedule.flowId}">
                <tr class="<c:out value="${row}"/>">

                    <td width="5%" align="center">
	                    <c:choose>
	                        <c:when test="${schedule.executeStatus == 'Success'}">
	                            <img title="OK" src="img/flag_green.gif" alt="OK" align="middle" style="border-width: 0px;" />
	                        </c:when>
	                        <c:when test="${schedule.executeStatus == 'Running'}">
	                            <img title="RUNNING" src="img/flag_white.gif" alt="RUNNING" align="middle" style="border-width: 0px;" />
	                        </c:when>
	                        <c:otherwise>
	                            <img title="ERROR" src="img/flag_red.gif" alt="ERROR" align="middle" style="border-width: 0px;"  />
	                        </c:otherwise>
	                    </c:choose>
                    </td>

                    <td width="90%" nowrap="nowrap">
                        <strong>
                            <a href="schedule-edit.htm?id=<c:out value="${schedule.id}" />" class="blacktext">
                                <c:out value="${schedule.name}" />
                                <c:if test="${schedule.active == null || schedule.active == \"\" }">
                                    <c:out value="[Inactive]" />
                                </c:if>
                            </a>
                        </strong>
                    </td>

                    <td width="5%" align="right">
                        <input type="image" title="Edit"
                        src="img/action_go.gif" alt="Edit" align="middle"
                        style="border-width: 0px;"
                        onclick="location.href='schedule-edit.htm?id=<c:out value="${schedule.id}" />'" />
                    </td>
                </tr>
                
                <c:choose>
                        <c:when test="${schedule.executeStatus == 'Running' }">

<tr    class="<c:out value="${row}"/>">

                    <td>&nbsp;</td>
                    <td colspan="2" class="ctrl">Running...</td>

                </tr>
                        </c:when>
                        <c:otherwise>
                
                
                    
                        
                <tr    class="<c:out value="${row}"/>">

                    <td>&nbsp;</td>
                    <td colspan="2" class="ctrl">Last Executed:&nbsp;<c:choose>
                        <c:when test="${schedule.lastExecutedOn == null}">
                            Never
                        </c:when>
                        <c:otherwise>
                            <c:out value="${schedule.lastExecutedOn}" />
                        </c:otherwise>
                    </c:choose>&nbsp;&nbsp; Next Run:&nbsp;<c:choose>
                        <c:when test="${schedule.nextRunOn == null}">
                            Never
                        </c:when>
                        <c:when test="${schedule.runNow == true}">
                            Now (or very soon...)
                        </c:when>
                        <c:otherwise>
                            <c:out value="${schedule.nextRunOn}" />
                        </c:otherwise>
                    </c:choose>
                    
                    </td>

                </tr>
                
                <c:choose>
                <c:when test="${schedule.executeStatus == 'Success' }">
                    <c:set var="hasError" value=""/>
                </c:when>
                <c:otherwise>
                    <c:set var="hasError" value="error"/>
                </c:otherwise>
                </c:choose>
                
                <tr class="<c:out value="${row}"/>">
                    <td>&nbsp;</td>
                    <td colspan="2" class="<c:out value="${hasError}"/>">
                        <div style="text-decoration:underline; cursor: pointer" onClick="showInfo('info<c:out value="${status.index}" />')">Last Run Info:</div>
                        
                        <div style="font: 1.0em Courier; display:none;" id="info<c:out value="${status.index}" />">
                            <pre><c:out value="${schedule.lastExecutionInfo}" escapeXml="false" />
                        </pre></div>
                        
                    </td>
                </tr>                
                
                        </c:otherwise>
                    </c:choose>
                </c:if>
            </c:forEach>
        </table>
        <br /><br />
        </c:forEach>
        </td>
    </tr>
</table>

<script type="text/javascript">  
    
function showInfo(id) {
    //alert(id);
    $("#" + id).slideToggle();
}

</script>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
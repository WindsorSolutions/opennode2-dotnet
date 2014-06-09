<%@ include file="/WEB-INF/jsp/_head.jsp"%>


<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="flowTitle" /></div>
        <div class="introText"><fmt:message key="flowIntroText" /></div>

		<p style="clear: both;" />

				<div class="sectionHead"><fmt:message key="flowListSectionTitle" /></div>
				<div class="introText"><fmt:message key="flowListSectionIntroText" /></div>
				
				<c:if test="${error != null}">
			     <div class="error"><c:out value="${error}"></c:out></div>
		        </c:if>

				<div style="clear: both; text-align: right; margin-bottom: 10px">
				<input type="button" name="cmdNew" value="Add Exchange" class="button"
					onclick="location.href='flow-edit.htm'" style="width:120px"  /></div>

				<c:if test="${model.flows != null}">
					<c:out value="${flow.id}" />

						<c:forEach var="flow" items="${model.flows}" varStatus="flowStatus">
						
							<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
							<tr style="background-color: #83ACCA; color:#FFF;">
								<td width="2%" align="right">
                                    <img alt="" src="img/flow2.gif"
                                      style="border: 0; vertical-align: middle; padding-right: 3px;" />
                                </td>
                                <td width="93%">
								    <strong><a href="flow-edit.htm?id=<c:out value="${flow.id}" />" class="whitetext"><c:out value="${flow.name}" /></strong>
									<c:if test="${flow.secured == true}">&nbsp;(Protected)</c:if></a>
                                    <c:if test="${flow.pluginExists == false}">&nbsp;<span style="color:darkred; font-weight:bold">(No Plugin Uploaded)</span></c:if></a>
								</td>
								<td width="5%" align="right">
									<input type="image"
										title="Edit" src="img/application_form_edit.png" alt="Edit Exchange"
										align="middle" style="border-width: 0px;"
										onclick="location.href='flow-edit.htm?id=<c:out value="${flow.id}" />'" />
								</td>

							</tr>
							
							<c:forEach var="srv" items="${flow.services}" varStatus="serviceStatus">

							<tr class="<c:choose>
									<c:when test="${serviceStatus.index % 2 == 0}">rowOdd</c:when>
									<c:otherwise>rowEven</c:otherwise>
								</c:choose>">
								
								<td width="2%"></td>
								<td nowrap="nowrap" width="93%">
								    <img alt="" src="img/icon_world_dynamic.gif"
									   style="border: 0; vertical-align: middle; padding-right: 3px;" />
									<strong><a href="service-edit.htm?id=<c:out value="${srv.id}" />" class="blacktext"><c:out value="${srv.name}" /></strong>&nbsp;
									(<c:out value="${srv.type}" /><c:if test="${srv.active == false}">&nbsp;[disabled]</c:if>)
                                    <c:if test="${srv.noAuthRequired}">&nbsp;[<span style="color: darkorange; font-weight: bold">No Auth Required</span>]</c:if></a>
								</td>
								<td width="5%" align="right">
								    <input type="image"
										title="Edit Service" src="img/application_form_edit.png" alt="Edit Service"
										align="middle" style="border-width: 0px;"
										onclick="location.href='service-edit.htm?id=<c:out value="${srv.id}" />'" />
								</td>
							</tr>
						</c:forEach>
							
							<tr style="background-color: #ffffff;">
								<td colspan="3" align="right" valign="top">
								    <input type="button" name="cmdNew" value="Add Service" class="button"
										onclick="location.href='service-edit.htm?fid=<c:out value="${flow.id}" />'" 
										style="width:120px" />
								</td>
							</tr>
							</table><br/>
							
						</c:forEach>
				</c:if>
	
		</td>
	</tr>
</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
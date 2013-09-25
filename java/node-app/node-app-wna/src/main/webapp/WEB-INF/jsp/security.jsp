<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<script type="text/javascript">
<!--
function goto(searchValue){
	window.location.href="policy-edit.htm?id="+searchValue;
}
//-->
</script>

<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left">
		  <%@ include file="/WEB-INF/jsp/_bar.jsp"%>
	    </td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="secTitle" /></div>
        <div class="introText"><fmt:message key="secIntroText" /></div>

		<p style="clear: both;" />
		<c:choose>

			<c:when test="${model.viewIndex == 1}">

				<div class="sectionHead"><fmt:message key="secAccountSectionTitle" /></div>
				<div class="introText"><fmt:message key="secAccountIntroText" /></div>

				<c:if test="${error != null}">
					<div class="error"><c:out value="${error}"></c:out></div>
				</c:if>

				<c:if test="${model.naasUsers != null}">

					<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
						<tr>
							<td class="ctrl" width="5%">
								Search
							</td>
							<td colspan="2" class="ctrl" width="95%">
								<input type="text" id="userSearch" class="textbox" style="width: 93%"/>
							</td>
						</tr>
						<tr>
							<td colspan="3" style="text-align: center">
								- or -
							</td>
						</tr>
						<tr>

							<td class="label" width="5%" nowrap="nowrap"><img
								alt="" src="img/user.png"
								style="border: 0; vertical-align: middle; padding-right: 3px; float: right;" /></td>
							<td class="ctrl" width="95%">
								<select name="listUsers" style="vertical-align: middle; width: 100%;"
									onChange="if (this.selectedIndex > 0) window.location='policy-edit.htm?id='+this.options[this.selectedIndex].value;">
									<option></option>
									<c:forEach var="user" items="${model.naasUsers}"
										varStatus="status">
	
										<option value="<c:out value="${user}" />"><c:out
											value="${user}" /></option>
	
									</c:forEach>
								</select>
							</td>
							<td class="label" width="10" nowrap="nowrap" align="right"><input
								type="image" src="img/action_refresh.gif"
								alt="Refresh accounts from NAAS" align="middle"
								style="border-width: 0px;"
								onclick="location.href='security.htm?bi=1&refresh=true'" /></td>
						</tr>

					</table>

				</c:if>

			</c:when>
			<c:otherwise>

				<div class="sectionHead"><fmt:message key="secAccountSectionTitle" /></div>
				<div class="introText"><fmt:message key="secAccountIntroText" /></div>

				<c:if test="${error != null}">
					<div class="error"><c:out value="${error}"></c:out></div>
				</c:if>


				<div style="clear: both; text-align: right; margin-bottom: 10px">
				<input type="button" name="cmdNew" value="Add User" class="button"
					onclick="location.href='account-new.htm'" /></div>

				<c:if test="${model.localUsers != null}">

					<table id="formTable" width="100%" cellpadding="2" cellspacing="0">

						<c:forEach var="user" items="${model.localUsers}"
							varStatus="status">

							<tr
								class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when><c:otherwise>rowEven</c:otherwise></c:choose>">
								<td width="95%" nowrap="nowrap">								    
                                    <a href="account-edit.htm?id=<c:out value="${user.id}" />">
	                                    <c:choose>
											<c:when test="${user.active}">
												<img alt="User" src="img/user.png"
													style="border: 0; vertical-align: middle; padding-right: 3px;" />
											</c:when>
											<c:otherwise>
												<img alt="Inactive" src="img/page_user_light.gif"
													style="border: 0; vertical-align: middle; padding-right: 3px;" />
											</c:otherwise>
								        </c:choose>
								    </a> 
								    <a href="account-edit.htm?id=<c:out value="${user.id}" />" class="blacktext"><c:out value="${user.naasUserName}" />&nbsp;( <c:choose>
									<c:when test="${user.active}">
										<c:out value="${user.affiliationCode}" />/<c:out value="${user.role.description}" />
									</c:when>
									<c:otherwise>
										<span class="error">Inactive</span>
									</c:otherwise>
								</c:choose>)</a></td>
								<td width="5%" style="text-align: right"><input type="image"
									title="Edit" src="img/application_form_edit.png" alt="Edit"
									style="border-width: 0px;"
									onclick="location.href='account-edit.htm?id=<c:out value="${user.id}" />'" /></td>

							</tr>

						</c:forEach>

					</table>

				</c:if>

			</c:otherwise>

		</c:choose>
		</td>

	</tr>

</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
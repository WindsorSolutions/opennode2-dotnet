<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include
			file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

        <div id="pageTitle"><fmt:message key="secTitle" /></div>
        <div class="introText"><fmt:message key="secIntroText" /></div>

		<div class="sectionHead"><fmt:message key="secAccountNewSectionTitle" /></div>
		<div class="introText"><fmt:message key="secAccountNewIntroText" /></div>

		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}"></c:out></div>
		</c:if>

		<form method="post" action="account-new.htm">


		<table id="formTable" width="100%" cellpadding="2" cellspacing="0">

			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;">Email:</td>
				<td class="ctrl" width="95%"><spring:bind
					path="command.naasUserName">
					<input name="naasUserName" type="text" class="textbox"  style="width: 95%;" />
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>

		<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;">System&nbsp;Role:</td>
				<td class="ctrl" width="5%"><spring:bind path="command.role">
					<select id="<c:out value="${status.expression}" />" name="<c:out value="${status.expression}" />"
						style="vertical-align: middle; width: 96%;" >
						<c:forEach var="sysRole" items="${model.sysRoles}"
							varStatus="rowSatus">
							<option value="<c:out value="${sysRole}" />"
								<c:if test="${ sysRole == command.role }">selected</c:if>><c:out
								value="${sysRole}" /></option>
						</c:forEach>
					</select>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>

			<tr>
				<td class="command" colspan="2" align="right">
					<input type="button" name="cancel" value="Cancel" class="button" onclick="location.href='security.htm'" /> 
					<input type="submit" name="save" value="Save" class="button" />
					<input type="submit" name="savepol" value="Save and Manage Policies" class="button" />
				</td>
			</tr>

		</table>


		</form>
		</td>

	</tr>

</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
<%@ include file="/WEB-INF/jsp/_head.jsp"%>



<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include
			file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

        <div id="pageTitle"><fmt:message key="secTitle" /></div>
        <div class="introText"><fmt:message key="secIntroText" /></div>

		<div class="sectionHead">
		  <c:out value="${model.nodeId}"></c:out> &nbsp;<fmt:message key="secAccountEditSectionTitle" />
		</div>
		<div class="introText"><fmt:message key="secAccountEditIntroText" /></div>

		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}"></c:out></div>
		</c:if>
		
		<c:if test="${model.nodeId != command.affiliationCode}">
				<div><strong>Warning</strong>: NAAS modifications disabled. Account not affiliated with the local Node: <c:out value="${model.nodeId}"></c:out>.</div>
		</c:if>

		<form method="post" action="account-edit.htm">
		

		<table id="formTable" width="100%" cellpadding="2" cellspacing="0">

			<tr>
				<td class="label" width="50" style="text-align: right; vertical-align: top;"><img alt=""
					src="img/user.png"
					style="border: 0; vertical-align: middle; padding-right: 3px;" />Email:</td>
				<td class="ctrl"><spring:bind
					path="command.naasUserName">
					<c:out value="${status.value}" />
				</spring:bind> <spring:bind path="command.id">
					<input type="hidden" name="id"
						value="<c:out value="${status.value}" />" />
				</spring:bind></td>
			</tr>

			<tr>
				<td class="label" width="50" style="text-align: right; vertical-align: top;">System&nbsp;Role:</td>
				<td class="ctrl"><spring:bind path="command.role">
					<select id="<c:out value="${status.expression}" />" name="<c:out value="${status.expression}" />"
						style="vertical-align: middle; width: 95%;" >
						<c:forEach var="sysRole" items="${model.sysRoles}"
							varStatus="rowSatus">
							<option value="<c:out value="${sysRole}" />"
								<c:if test="${ sysRole == command.role }">selected</c:if>><c:out
								value="${sysRole.description}" /></option>
						</c:forEach>
					</select>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>
			
			<tr>
				<td class="label" width="50" style="text-align: right; vertical-align: top;">Affiliation:</td>
				<td class="ctrl"><spring:bind path="command.affiliationCode"><c:out value="${status.value}" />
					<input type="hidden" name="<c:out value="${status.expression}" />" 
						   value="<c:out value="${status.value}" />" />
				</spring:bind></td>
			</tr>

			<tr>
				<td class="label" width="50" style="text-align: right; vertical-align: top;">Active:</td>
				<td class="ctrl"><spring:bind path="command.active">
					<input type="hidden" name="_<c:out value="${status.expression}" />" />
						<lable for=""><input type="checkbox" name="<c:out value="${status.expression}" />"
							<c:if test="${status.value == true}">checked</c:if> />
							Making account inactive will prevent that account from 
							accessing the Node Admin as well as the Node Service</lable>
							<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>


			<tr>
				<td class="command" colspan="2" align="right"><spring:bind
					path="command.id">
					<input type="button" name="cancel"
						onclick="location.href='security.htm?bi=0'" value="Cancel"
						class="button" />
					<input type="submit" name="save" value="Save" class="button" />
					<input type="submit" name="delete" value="Delete"
						<c:if test="${model.nodeId != command.affiliationCode}">disabled="yes"</c:if>
						onclick="return confirm('Are you sure you want to delete this account? Account will also be deleted in NAAS but only set it to inactive locally to preserv its history.');"
						class="button" />
				</spring:bind></td>

			</tr>
			
			<tr>
				<td class="command" colspan="2" align="right"><spring:bind
					path="command.id">
					<input type="submit" name="reset" value="Reset Password"
						<c:if test="${model.nodeId != command.affiliationCode}">disabled="yes"</c:if>
						onclick="return confirm('Are you sure you want reset this account? Account will also be reset in NAAS!');"
						class="button" />
					<input type="submit" name="savepol" value="Save and Manage Policies" class="button" />
				</spring:bind></td>

			</tr>



		</table>
		</form>
		</td>

	</tr>

</table>



<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
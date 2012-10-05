<%@ include file="/WEB-INF/jsp/_head.jsp"%>


<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left">&nbsp;</td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="authTitle" /></div>
		<div class="introText"><fmt:message key="authIntroText" /></div>

		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}"></c:out></div>
		</c:if>

        <form method="post" >
		<table id="formTable" width="400" cellpadding="0" cellspacing="0">

			<tr>
				<td class="label" width="50">Account:</td>
				<td class="ctrl">
				<spring:bind path="command.username">
					<input type="text" name="<c:out value="${status.expression}" />"
						value="<c:out value="${status.value}" />" class="textbox"
						style="width: 95%;" size="95%"/>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind>
				</td>
			</tr>
			<tr>
				<td class="label" width="50">Password:</td>
				<td class="ctrl"><spring:bind path="command.password">
					<input type="password"
						name="<c:out value="${status.expression}" />"
						value="<c:out value="${status.value}" />" class="textbox"
						style="width: 95%;" size="95%"/>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>

			<tr>
				<td class="command" colspan="2" align="right"><input
					type="submit" value="Login" class="button" /></td>
			</tr>

		</table>
		</form>
		</td>

	</tr>

</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
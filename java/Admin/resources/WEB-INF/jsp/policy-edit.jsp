<%@ include file="/WEB-INF/jsp/_head.jsp"%>



<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include
			file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

        <div id="pageTitle"><fmt:message key="secTitle" /></div>
        <div class="introText"><fmt:message key="secIntroText" /></div>

		<div class="sectionHead"><fmt:message key="secPolicyEditSectionTitle" /></div>
		<div class="introText"><fmt:message key="secPolicyEditIntroText" /></div>

		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}"></c:out></div>
		</c:if>

		<form method="post" action="policy-edit.htm">

		<table id="formTable" width="100%" cellpadding="2" cellspacing="0">


			<tr>
				<td class="label" width="5%" nowrap><img alt=""
					src="img/page_user_dark.gif"
					style="border: 0; vertical-align: middle; padding-right: 3px;" /></td>
				<td class="ctrl" width="95%"><spring:bind path="command.account.naasUserName">
					<c:out value="${status.value}" />
				</spring:bind> <spring:bind path="command.account.naasUserName">
					<input type="hidden" name="<c:out value="${status.expression}" />"
						value="<c:out value="${status.value}" />" />
				</spring:bind></td>
			</tr>

			<tr>
				<td class="label" width="5%" nowrap>Affiliate:</td>
				<td class="ctrl" width="95%"><c:out
					value="${command.account.affiliationCode}" /></td>
			</tr>


			<tr>
				<td class="label" style="width: 20%;" nowrap>Flows&nbsp;Access:</td>
				<td class="ctrl"><div><img align="left" alt="" src="img/icon_padlock.gif"
					style="border: 0; vertical-align: middle; padding-right: 3px;" /><fmt:message key="secPolicyEditProtectedInfo" /></div>
				<table id="formTable" width="100%" cellpadding="2" cellspacing="0">

					<c:forEach var="ass" items="${command.flowAssignemnts}"
						varStatus="status">

						<tr
							class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when>
									<c:otherwise>rowEven</c:otherwise></c:choose>">

							<td width="10" nowrap><c:choose>
								<c:when test="${ass.flowProtected == true}">
									<img
										alt="Protected flow: requires a policy in addition to the NAAS token"
										src="img/icon_padlock.gif"
										style="border: 0; vertical-align: middle; padding-right: 3px;" />
								</c:when>
								<c:otherwise>
									&nbsp;
								</c:otherwise>
							</c:choose></td>

							<td nowrap><c:out value="${ass.label}" /></td>
							<td align="right"><input type="checkbox" name="selectedFlow"
								value="<c:out value="${ass.flowId}" />"
								<c:if test="${ass.assigned == true}">checked</c:if>
								<c:if test="${ass.flowProtected == false}">disabled</c:if> /></td>

						</tr>

					</c:forEach>

				</table>

				</td>
			</tr>



			<tr>
				<td class="command" colspan="2" align="right"><input
					type="button" name="cmdEdit"
					onclick="location.href='account-edit.htm?id=<c:out value="${command.account.id}" />'" 
					value="Edit Local Role"
					class="button" /> <input
					type="button" name="cmdCancel"
					onclick="location.href='security.htm?bi=1'" value="Cancel"
					class="button" /> <input type="submit" name="cmdSave" value="Save"
					class="button" /></td>

			</tr>



		</table>
		</form>
		</td>

	</tr>

</table>


<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
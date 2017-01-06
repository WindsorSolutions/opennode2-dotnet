<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include
			file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="configTitle" /></div>

		<div class="sectionHead"><fmt:message
			key="configArgsSectionTitle" /></div>
		<div class="introText"><fmt:message key="configArgsIntroText" /></div>
		
		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}"></c:out></div>
		</c:if>
		
		<form method="post" action="config-arg.htm">

		<table id="formTable" width="100%" cellpadding="2" cellspacing="0">

		<spring:bind path="command.id">
            <input type="hidden" name="id" value="<c:out value="${status.value}" />" />
        </spring:bind>

			<tr>
				<td class="label" width="50" style="text-align: right; vertical-align: top;"><img alt=""
					src="img/icon_settings.gif"
					style="border: 0; vertical-align: middle; padding-right: 3px;" />Name:
				</td>
				<td class="ctrl" width="750">
				<spring:bind path="command.name">
				<c:choose>
				<c:when test="${(status.value == null || status.value == '') && status.errorMessage ==''}">
					<input type="text" name="name" value="<c:out value="${status.value}" />"
						class="textbox" size="50" maxlength="50" />
					<input type="hidden" name="editmode" value="false" />
				</c:when>
                <c:when test="${(status.value != null || status.value != '') && (status.errorMessage != '' || status.errorMessage != null)}">
                    <input type="text" name="name" value="<c:out value="${status.value}" />"
                        class="textbox" size="50" maxlength="50" />
                    <input type="hidden" name="editmode" value="false" />
                </c:when>
				<c:otherwise>
					<c:out value="${status.value}" />
					<input type="hidden" name="name" value="<c:out value="${status.value}" />"/>
					<input type="hidden" name="editmode" value="true" />
				</c:otherwise>
			</c:choose>
			<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>
			<tr>

				<td class="label" width="50" style="text-align: right; vertical-align: top;">Value:</td>
				<td class="ctrl"><spring:bind path="command.value">
					<textarea name="value" class="textbox" rows=" 2" cols="53"><c:out value="${status.value}" /></textarea>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>

			<tr>
				<td class="label" width="50" style="text-align: right; vertical-align: top;">Description:</td>
				<td class="ctrl"><spring:bind path="command.description">
					<textarea name="description" class="textbox" rows=" 4" cols="53"><c:out value="${status.value}" /></textarea>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>

			<tr>
				<td class="command" colspan="2" align="right">
				<spring:bind path="command.id">
				<input type="button" value="Cancel" class="button" onclick="location.href='config.htm?bi=0'" /> 
				<input type="submit" value="Save" class="button" name="save" /> 
				<input type="submit" value="Delete" class="button" name="delete" 
					<c:if test="${status.value == null}">disabled="yes"</c:if>
					onclick="return confirm('Are you sure you want to delete this configuration item?');" />
				</spring:bind></td>
			</tr>
		</table>
		</form>
		</td>

	</tr>

</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
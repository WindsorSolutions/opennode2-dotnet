<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include
			file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="flowTitle" /></div>

		<div class="sectionHead"><fmt:message
			key="flowItemSectionTitle" /></div>
		<div class="introText"><fmt:message
			key="flowItemSectionIntroText" /></div>

		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}"></c:out></div>
		</c:if>

		<form method="post" action="flow-edit.htm">

		<table id="formTable" width="100%" cellpadding="2" cellspacing="0">


			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;"><img src="img/help.png"
                    alt="Help" style="border: 0; vertical-align: middle; padding-right: 3px;" onclick="showHelp('helpText')" />Name:</td>
				<td class="ctrl" width="95%">
				
					<spring:bind path="command.id">
						<input type="hidden" name="id" value="<c:out value="${status.value}" />" />
					</spring:bind>
				
					<c:choose>
						<c:when test="${command.name == null || command.id == ''}">
							<spring:bind path="command.name">
							<input type="text" name="<c:out value="${status.expression}" />" 
									value="<c:out value="${status.value}" />" class="textbox"  style="width: 95%;" />
							<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
							</spring:bind>
						</c:when>
						
						<c:otherwise>
							<spring:bind path="command.name">
							<c:out value="${status.value}" />
							<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
							</spring:bind>
							
							
							<spring:bind path="command.modifiedById">
								<input type="hidden" name="<c:out value="${status.expression}" />" 
									value="<c:out value="${status.value}" />" />
								<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
							</spring:bind>
						</c:otherwise>
					
					</c:choose>
				
				</td>
			</tr>
            <tr>
                <td colspan="2"><div id="helpText" style="display:none"><c:out value="${pluginMetaData.helpText}" /></div></td>
            </tr>

			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;">Contact:</td>
				<td class="ctrl" width="95%"><spring:bind path="command.contactUserId">
					<select id="<c:out value="${status.expression}" />" name="<c:out value="${status.expression}" />"
						style="vertical-align: middle; width: 96%;">
						<option value="" /></option>
						<c:forEach var="sysUser" items="${model.contacts}"
							varStatus="rowSatus">
							<option value="<c:out value="${sysUser.id}" />"
								<c:if test="${ sysUser.id == command.contactUserId }">selected</c:if> ><c:out
								value="${sysUser.naasUserName}" /></option>
						</c:forEach>
					</select>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>

			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;">Web&nbsp;Info:</td>
				<td class="ctrl" width="95%"><spring:bind path="command.infoUrl">
					<input type="text" name="<c:out value="${status.expression}" />" 
						value="<c:out value="${status.value}" />" class="textbox"  style="width: 95%;" />
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>

			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;"><label for="Protected">Protected:</label></td>
				<td class="ctrl" width="95%"><spring:bind path="command.secured">
					<input type="hidden" name="_<c:out value="${status.expression}"/>">
        			<input type="checkbox" id="Protected" name="<c:out value="${status.expression}"/>" value="true"
           			 <c:if test="${status.value}">checked</c:if>/>
				</spring:bind>
				<fmt:message key="flowItemDefaultSecurityText" />
				</td>
			</tr>

            <tr>
                <td class="label" colspan="2" style="text-align: left; vertical-align: top;">Latest Uploaded Plugin Data</td>
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Plugin Name:</td>
                <td class="ctrl" width="95%"><c:out value="${pluginMetaData.name}" /></td>
            </tr>

            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Plugin Full Name:</td>
                <td class="ctrl" width="95%"><c:out value="${pluginMetaData.fullName}" /></td>
            </tr>

            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Plugin Description:</td>
                <td class="ctrl" width="95%"><c:out value="${pluginMetaData.description}" /></td>
            </tr>

            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Plugin Version:</td>
                <td class="ctrl" width="95%"><c:out value="${pluginMetaData.version}" /></td>
            </tr>


			<tr>
				<td class="command" colspan="2" align="right"><spring:bind path="command.id">

					<input type="button" name="cancel"
						onclick="location.href='flow.htm'" value="Cancel"
						class="button" />
					<input type="submit" name="cmdSave" value="Save" class="button" />
					
					<c:if test="${ status.value != null }">
					<input type="submit" name="delete" value="Delete"
						onclick="return confirm('Are you sure you want to delete this data flow?');"
						class="button" /></c:if>
				</spring:bind></td>

			</tr>



		</table>
		</form>
		</td>

	</tr>

</table>
<script type="text/javascript">  
function showHelp(id) {
    $("#" + id).slideToggle();
}

</script>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
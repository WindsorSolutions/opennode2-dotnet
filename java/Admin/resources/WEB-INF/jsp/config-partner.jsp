<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include
			file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="configTitle" /></div>

		<div class="sectionHead"><fmt:message
			key="configPartnerSectionTitle" /></div>
		<div class="introText"><fmt:message key="configPartnerIntroText" /></div>

		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}"></c:out></div>
		</c:if>

		<form method="post" action="config-partner.htm">

		<table id="formTable" width="100%" cellpadding="2" cellspacing="0">

			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;"><img alt=""
					src="img/page_url.gif"
					style="border: 0; vertical-align: middle; padding-right: 3px;" />Name:</td>
				<td class="ctrl" width="95%"><spring:bind path="command.name">
					<input type="text" name="<c:out value="${status.expression}" />" 
						class="textbox" maxlength="50" value="<c:out value="${status.value}" />">
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind><spring:bind path="command.id">
					<input type="hidden" name="id" value="<c:out value="${status.value}" />"/>
				</spring:bind></td>
			</tr>

			<tr>
				<td class="label"  width="5%" style="text-align: right; vertical-align: top;">Version:</td>
				<td class="ctrl"  width="95%"><spring:bind path="command.version">
					<select id="<c:out value="${status.expression}" />" 
					        name="<c:out value="${status.expression}" />" 
					        style="width:96%"
					        class="select" >
						<c:forEach var="ver" items="${model.endpointVersions}">
							<option value="<c:out value="${ver}" />"
								<c:if test="${command.version == ver}">selected</c:if> 
							><c:out value="${ver}" /></option>
						</c:forEach>
					</select>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>
			
			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;">Endpoint:</td>
				<td class="ctrl" width="95%"><spring:bind path="command.url">
					<textarea id="url" name="<c:out value="${status.expression}" />" 
						class="textbox" rows=" 4" cols="53"><c:out value="${status.value}" /></textarea>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind></td>
			</tr>

			<tr>
				<td class="command" colspan="2" align="right" >
				<spring:bind path="command.id">
				<input type="button" value="Cancel" class="button" onclick="location.href='config.htm?bi=2'" /> 
				<input type="submit" value="Save" class="button" name="save" onclick="return isUrl();" /> 
				<input type="submit" value="Delete" class="button" name="delete" 
					<c:if test="${status.value == null || status.value == ''}">disabled="yes"</c:if>
					onclick="return confirm('Are you sure you want to delete this partner item?');" />
				</spring:bind>
				</td>
			</tr>
		</table>
		</form>
		</td>

	</tr>

</table>

 <script type="text/javascript">  
 

function isUrl() {
	var s = $("#url").val();
   	var regexp = /(http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/
	if (regexp.test(s)){
		return true;
	}else{
		alert("Invalid endpoint url");
		return false;
	}
}
                         
 </script> 

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
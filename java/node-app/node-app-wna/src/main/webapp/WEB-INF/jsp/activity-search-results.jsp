<%@ include file="/WEB-INF/jsp/_head.jsp"%>



<table id="contentTable" width="100%">
	<tr>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="activityTitle" /></div>
        <div class="introText"><fmt:message key="activityIntroText" /></div>
		<div class="sectionHead"><fmt:message key="activityResultTitle" /></div>
		<div class="introText"><fmt:message key="activityResultIntroText" /></div>
		
		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}" /></div>
		</c:if>
		
		
		<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
			
			<tr style="background-color: #83ACCA; color:#FFF;">
				<td colspan="2"><strong>Search Criteria</strong></td>
			</tr>
			<tr>
				<td valign="top">
					<c:out value="${criteria}" escapeXml="false" />
				</td>
				<td align="right" valign="middle">
					<input type="button" name="cmdRefine" value="Refine" 
					class="button" onclick="location.href='activity.htm'" 
					style="width:150px"  />
				</td>
			</tr>
		</table>
		
		<%@ include file="/WEB-INF/jsp/activity-result.jsp"%>
		
		</td>

	</tr>

</table>






<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
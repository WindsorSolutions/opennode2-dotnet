<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
	<tr>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="activityTitle" /></div>
        <div class="introText"><fmt:message key="activityIntroText" /></div>
		<div class="sectionHead"><fmt:message key="activitySectionTitle" /></div>
		<div class="introText"><fmt:message key="activitySectionIntroText" /></div>

		<%@ include file="/WEB-INF/jsp/activity-search-form.jsp" %>
        
		</td>

	</tr>

</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
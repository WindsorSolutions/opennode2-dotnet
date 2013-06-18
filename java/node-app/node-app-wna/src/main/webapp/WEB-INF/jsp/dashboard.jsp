<%@ include file="/WEB-INF/jsp/_head.jsp"%>


<table id="contentTable" width="750" cellpadding="5" cellspacing="0">

	<tr>
		<td colspan="2" valign="top">
		<div id="pageTitle"><fmt:message key="dashboardTitle" /></div>
		</td>
	</tr>
	<tr>
	    <td colspan="2" valign="top">
        <div class="introText"><fmt:message key="dashboardIntroText" /></div>
        </td>
	</tr>
	<tr>
		<td valign="top">
		<div class="sectionHead">Transaction Type Overview</div>
		<img
			src="http://chart.apis.google.com/chart?cht=p3&amp;chs=400x150&amp;chd=t:<c:out value="${model.transactionChartData}" />&amp;chl=<c:out value="${model.transactionChartLabel}" />"
			alt="Chart: Transaction Type Overview"
			style="border-width: 0px; height: 150px; width: 400px;" />
		</td>
		<td valign="top">
            <jsp:include page="heartbeat.jsp"></jsp:include>
		</td>
	</tr>
	<tr>
		<td valign="top"><br clear="all" />
		<div class="sectionHead">Most Active Users</div>
		<img
			src="http://chart.apis.google.com/chart?chxt=y,x&amp;chxl=0:<c:out value="${model.activeUserChartYaxisLabel}" />1:<c:out value="${model.activeUserChartXaxisLabel}" />&amp;cht=bvs&amp;chd=t:<c:out value="${model.activeUserChartData}" />&amp;chbh=30,50&amp;chco=FFCC66|CCFF99|FFFFCC|CCCCCC|FFCCCC&amp;chds=0,<c:out value="${model.activeUserChartMaxNumber}" />&amp;chs=400x150"
			alt="Chart: Most Active Users"
			style="border-width: 0px; height: 150px; width: 400px;" />
		</td>
        <td valign="top">
        <c:forEach items="${model.feeds}" var="item">
            <c:set var="feed" value="${item}" scope="request" />
            <jsp:include page="rss/feed.jsp"></jsp:include>
            <br>
        </c:forEach>
        </td>
	</tr>
	<tr>
	    <td colspan="2">
	    <br clear="all" />
        <div class="sectionHead">Most Recent Transactions</div>
        <br clear="all" />
        <%@ include file="/WEB-INF/jsp/activity-result.jsp"%>
        </td>
	</tr>
</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
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

<script type="text/javascript">
    $(document).ready(function()
    {
        var data = $.ajax({url: "heartbeat.htm", cache:false, dataType: "json",
            success: function(json, textStatus)
            {
                var greenCheck = '<img style="border: 0; vertical-align: middle; padding-right: 3px;" title="Information" alt="Information" src="img/accept.png">';
                var redBang = '<img style="border: 0; vertical-align: middle; padding-right: 3px;" title="Error" alt="Error" src="img/exclamation.png">';
                
                if("success" == json.wneresult)
                {
                    $("#wne-endpoint").html(greenCheck + "v1.1:  " + json.wneendpoint);
                }
                else
                {
                    $("#wne-endpoint").html(redBang + "v1.1:  " + json.wneendpoint);
                }

                if("success" == json.wne2result)
                {
                    $("#wne2-endpoint").html(greenCheck + "v2.1:  " + json.wne2endpoint);
                }
                else
                {
                    $("#wne2-endpoint").html(redBang + "v2.1:  " + json.wne2endpoint);
                }

                if("success" == json.wnrestresult)
                {
                    $("#wnrest-endpoint").html(greenCheck + "REST:  " + json.wnrestendpoint);
                }
                else
                {
                    $("#wnrest-endpoint").html(redBang + "REST:  " + json.wnrestendpoint);
                }
            }
        });
    });
</script>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
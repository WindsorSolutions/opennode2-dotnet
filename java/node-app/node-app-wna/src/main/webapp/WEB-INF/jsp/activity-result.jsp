

					<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
					
							<tr>
								<th>&nbsp;</th>
								<th>What</th>
                                <th>Exchange</th>
								<!-- <th>Operation</th> -->
								<th>Who</th>
                                <th>When</th>
                                <th>&nbsp;</th>
							</tr>

						<c:forEach var="activity" items="${result}" varStatus="status">

							<tr
								class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when>
								<c:otherwise>rowEven</c:otherwise></c:choose>">
								<td align="center" style="width:20px;white-space:nowrap;">
								<img style="border: 0; vertical-align: middle; padding-right: 3px;" 
								<c:choose>
									
									<c:when test="${activity.type == 'AdminAuth'}">
										title="Admin authentication" alt="Admin authentication" src="img/key_go.png" 
									</c:when>
									<c:when test="${activity.type == 'ServiceAuth'}">
										title="Service Authentication" alt="Service Authentication" src="img/key_go.png" 
									</c:when>
									<c:when test="${activity.type == 'Audit'}">
										title="Admin management audit" alt="Admin management audit" src="img/connect.png" 
									</c:when>
									<c:when test="${activity.type == 'Error'}">
										title="Error" alt="Error" src="img/exclamation.png" 
									</c:when>
									<c:otherwise>
										title="Information" alt="Information" src="img/accept.png" 
									</c:otherwise>
								</c:choose>
							/>
								
								</td>
	                            <td style="width:120px;white-space:nowrap;"><c:out value="${activity.type}" />
	                            <c:if test="${activity.webMethod != null }">&nbsp;(<c:out value="${activity.webMethod}" />)</c:if></td>
                                <td align="center" style="white-space:nowrap;"><c:out value="${activity.flowName}" /></td>
                                <%-- <td align="center" style="white-space:nowrap;"><c:out value="${activity.flowName}" /></td> --%>
								<td nowrap="nowrap"><c:out value="${activity.userName}" /> (<c:out value="${activity.ip}" />)</td>
                                <td  style="width:140px;white-space:nowrap;"><fmt:formatDate type="both" dateStyle="short" timeStyle="short" 
                                    value="${activity.modifiedOn}" /></td>
	                            <td width="10" align="right" nowrap="nowrap">
	                                <c:if test="${activity.transactionId != null }">
		                                <a href="tran.htm?id=<c:out value="${activity.transactionId}" />">
		                                <img src="img/zoom.png" alt="View Transaction Detail" border="0" />
	                                </a>
	                                </c:if>
                                </td>
								<td width="10" align="right">
								<input type="image"
									title="Show Activity Detail" src="img/control-double-270-small.png" alt="Show Activity Detail"
									border="0" 
									onClick="showDetail('detail<c:out value="${status.index}" />','<c:out value="${activity.id}" />');" /></td>
							</tr>
							<tr>
								<td colspan="7"><div style="display:none;" id="detail<c:out value="${status.index}" />"></div></td>
							</tr>

						</c:forEach>

					</table>
					
<script type="text/javascript">  
function showDetail(d, id){
	if($("#" + d).html() == ''){
		$("#" + d).load("data.htm?cmd=activity&id=" + id, [], function(){$("#" + d).slideToggle()});
	}else{
		$("#" + d).slideToggle();
	}
}
</script>
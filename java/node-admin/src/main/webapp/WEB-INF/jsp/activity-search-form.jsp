
		<form method="post">

        <c:set var="any" value="[Any]"/>

		<table id="formTable" width="750" cellpadding="2" cellspacing="0">

			<tr>
                <td class="label" style="width: 100px">Exchange:</td>
                <td class="ctrl" style="width: 200px">
                
	                <spring:bind path="command.flowId">
	                    <select name="<c:out value="${status.expression}" />" style="width: 200px" id="flowId">
	                </spring:bind>
	                
	                <option value=""><c:out value="${any}" /></option>
	                
	                <spring:bind path="command.exchanges">
	                    <c:forEach items="${status.value}" var="exchange">
	                        <c:if test="${exchange.name != any}"> 
	                        	<option value="<c:out value="${exchange.id}" />"
	                        	<c:if test="${ exchange.id == command.flowId }">selected</c:if> 
	                        	>
	                        </c:if>
	                            <c:out value="${exchange.name}" />
	                        </option>
	                    </c:forEach>
	                </spring:bind>
	                
                	</select>
                </td>
                
                <td class="label" style="width: 100px">Date&nbsp;Range:</td>
                <td nowrap="nowrap" align="left">
                	From:&nbsp;<spring:bind path="command.createdFrom"><input type="text" name="<c:out value="${status.expression}" />"
									value="<c:out value="${status.value}" />" class="cal" style="width: 95px;" /></spring:bind>&nbsp;
				    To:&nbsp;<spring:bind path="command.createdTo"><input type="text" name="<c:out value="${status.expression}" />"
									value="<c:out value="${status.value}" />" class="cal" style="width: 95px;" /></spring:bind>
			
                </td>
			</tr>
			
			<tr>
				<td class="label" style="width: 100px">Entry&nbsp;Type:</td>
				<td class="ctrl" style="width: 200px">
					<spring:bind path="command.type">
					    <select name="<c:out value="${status.expression}" />" style="width: 200px" id="entryTypes">
	                </spring:bind>
	                <option value=""><c:out value="${any}" /></option>
	                <spring:bind path="command.activityTypeNames">
	                    <c:forEach items="${status.value}" var="activityType">
	                        <c:if test="${activityType != any}"> <option value="<c:out value="${activityType}" />"
	                        <c:if test="${ activityType == command.type }">selected</c:if> 
	                        ></c:if>
	                            <c:out value="${activityType}" />
	                        </option>
	                    </c:forEach>
	                </spring:bind>
				</select>
				</td>
				
                <td class="label" style="width: 100px">By&nbsp;User:</td>
                <td class="ctrl" style="width: 300px">
	                <spring:bind path="command.createdById">
	                    <select name="<c:out value="${status.expression}" />" style="width: 299px" id="accountList">
	                </spring:bind>
	                <option value=""><c:out value="${any}" /></option>
	                <spring:bind path="command.accountList">
	                    <c:forEach items="${status.value}" var="acctName">
	                        <c:if test="${acctName != any}"> <option value="<c:out value="${acctName}" />"
	                        <c:if test="${ acctName == command.createdById }">selected</c:if> 
	                        ></c:if>
	                            <c:out value="${acctName}" />
	                        </option>
	                    </c:forEach>
	                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
	                </spring:bind>              
                </td>
			</tr>

			<tr>
				<td class="label" style="width: 100px">From&nbsp;IP:</td>
				<td class="ctrl" style="width: 200px">
					<spring:bind path="command.ip">
	                    <select name="<c:out value="${status.expression}" />" style="width: 200px" id="ipList">
	                </spring:bind>
                	<option value=""><c:out value="${any}" /></option>
	                <spring:bind path="command.ipList">
	                    <c:forEach items="${status.value}" var="ipAddr">
	                        <c:if test="${ipAddr != any}"> <option value="<c:out value="${ipAddr}" />"
	                        <c:if test="${ ipAddr == command.ip }">selected</c:if> 
	                        ></c:if>
	                            <c:out value="${ipAddr}" />
	                        </option>
	                    </c:forEach>
						<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
					</spring:bind>
				</td>
				
                <td class="label" style="width: 100px">Transaction&nbsp;Id:</td>
                <td class="ctrl" style="width: 300px">
	                <spring:bind path="command.transactionId">
	                    <input type="text" id="transactionList"
	                        name="<c:out value="${status.expression}" />"
	                        value="<c:out value="${status.value}" />" 
	                        class="textbox" style="width:295px;" />
	                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
	                </spring:bind>
                </td>
			</tr>

			<tr>
				<td class="label" style="width: 100px">Content:</td>
				<td class="ctrl" colspan="3"  style="width: 600px">
					<spring:bind path="command.detailContains">
						<input type="text" name="<c:out value="${status.expression}" />"
							value="<c:out value="${status.value}" />" 
							class="textbox" style="width: 618px" />
						<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
					</spring:bind>
				</td>

			</tr>
			<tr>
			
				<td class="label" style="width: 100px">Max&nbsp;Records:</td>
				<td class="ctrl" style="width: 200px"><spring:bind path="command.maxRecords">
					<select id="<c:out value="${status.expression}" />" name="<c:out value="${status.expression}" />" style="width: 60px" >
							<option value="50" <c:if test="${ \"50\" == command.maxRecords }">selected</c:if> >50</option>
							<option value="100" <c:if test="${ \"100\" == command.maxRecords }">selected</c:if> >100</option>
							<option value="500" <c:if test="${ \"500\" == command.maxRecords }">selected</c:if> >500</option>
							<option value="1000" <c:if test="${ \"1000\" == command.maxRecords }">selected</c:if> >1000</option>
					</select>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
				</spring:bind>
				</td>
			
				<td class="command" align="right" colspan="2">
					<input type="submit" name="cmdSearch" value="Search" id="cmdSearch" class="button" />
					<input type="Reset" name="cmdReset" value="Reset" class="button" />
				</td>
			</tr>
		</table>

		</form>
		
        <c:if test="${error != null}">
            <div class="error" style="text-align: center; padding: 8px"><c:out value="${error}"></c:out></div>
        </c:if>
        
        <script type="text/javascript">  		

		$(document).ready(function() {
			
			<c:if test="${model.result == null}">
				
				$("#transactionList").autocomplete([<c:forEach var="transactionListItem" items="${model.lookup.transactionList}">
						"<c:out value="${transactionListItem}" />",
					</c:forEach>" "],
					{
						delay:10,
						minChars:1,
						matchSubset:1,
						autoFill:true,
						maxItemsToShow:10
					}
				);
				
				
			</c:if>
				
			});
		
		</script>
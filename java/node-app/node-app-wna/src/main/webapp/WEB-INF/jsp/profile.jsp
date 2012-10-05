<%@ include file="/WEB-INF/jsp/_head.jsp"%>


<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left">
		    <%@ include file="/WEB-INF/jsp/_bar.jsp"%>
		</td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="profileTitle" /></div>
                    <div class="introText"><fmt:message key="profileIntroText" /></div>

		<p style="clear: both;" /><c:if test="${model.account != null}">

			<c:set var="usr" value="${model.account}"></c:set>
			
			

			<form method="post" action="profile.htm"><input type="hidden"
				name="userId" value="<c:out value="${usr.id}" />" /> <input
				type="hidden" name="cmd"
				value="<c:out value="${model.viewIndex}" />" /> <c:choose>

				<%--Profile sidebar selected --%>
				<c:when test="${model.viewIndex == 0}">

					<div class="sectionHead"><fmt:message key="profileSectionTitle" /></div>
					<div class="introText"><fmt:message key="profileSectionIntroText" /></div>

					<c:if test="${error != null}">
						<div class="error"><c:out value="${error}"></c:out></div>
					</c:if>




					<table id="formTable" width="100%" cellpadding="2" cellspacing="0">


						<tr>
							<td class="label" style="width: 20%;" nowrap="nowrap"><img alt=""
								src="img/user.png"
								style="border: 0; vertical-align: middle; padding-right: 3px;" /></td>
							<td class="ctrl"><c:out value="${usr.naasUserName}" /></td>
						</tr>

						<tr>
							<td class="label" style="width: 20%;" nowrap="nowrap">System&nbsp;Role:</td>
							<td class="ctrl"><c:out value="${usr.role}" /></td>
						</tr>

						<tr>
							<td class="label" style="width: 20%;" nowrap="nowrap">Active:</td>
							<td class="ctrl"><c:choose>
								<c:when test="${usr.active}">Yes</c:when>
								<c:otherwise>No</c:otherwise>
							</c:choose></td>
						</tr>

						<tr>
							<td class="label" style="width: 20%;" nowrap="nowrap">Last&nbsp;Modified&nbsp;By:</td>
							<td class="ctrl"><c:out value="${usr.modifiedById}" /></td>
						</tr>

						<tr>
							<td class="label" style="width: 20%;" nowrap="nowrap">Last&nbsp;Modified&nbsp;On:</td>
							<td class="ctrl"><fmt:formatDate
								pattern="MMMMM dd, yyyy hh:mm a" value="${usr.modifiedOn}" /></td>
						</tr>

						<c:if test="${usr.role != 'Admin'}">
							<tr>
								<td class="label" style="width: 20%;" nowrap="nowrap">Assigned&nbsp;Flows:</td>
								<td class="ctrl">
								<ul>
									<c:forEach var="policy" items="${usr.policies}">
										<li><c:out value="${policy.typeQualifier}" /></li>
									</c:forEach>
								</ul>
								</td>
							</tr>
						</c:if>

					</table>




				</c:when>

				<%--Change Password sidebar selected --%>
				<c:when test="${model.viewIndex == 1}">

					<div class="sectionHead"><fmt:message
						key="profilePasswordSectionTitle" /></div>
					<div class="introText"><fmt:message
						key="profilePasswordSectionIntroText" /></div>

					<c:if test="${error != null}">
						<div class="error"><c:out value="${error}"></c:out></div>
					</c:if>

					<table id="formTable" width="400" cellpadding="0" cellspacing="0">

						<tr>
							<td class="label"><img alt="" src="img/user.png"
								style="border: 0; vertical-align: middle; padding-right: 3px;" /></td>
							<td class="ctrl"><c:out value="${usr.naasUserName}" /></td>
						</tr>

						<tr>
							<td class="label">Current&nbsp;Password:</td>
							<td class="ctrl"><input type="password" class="textbox"
								maxlength="255" name="p1" /></td>
						</tr>
						<tr>
							<td class="label">New&nbsp;Password:</td>
							<td class="ctrl"><input type="password" class="textbox"
								maxlength="255" name="p2" /></td>
						</tr>
						<tr>
							<td class="label">Confirm:</td>
							<td class="ctrl"><input type="password" class="textbox"
								maxlength="255" name="p3" /></td>
						</tr>

						<tr>
							<td class="command" colspan="2" align="right"><input
								type="button" name="cancel"
								onclick="location.href='profile.htm?bi=1'" value="Cancel"
								class="button" /> <input type="submit" name="save"
								value="Change Password" class="button" /></td>
						</tr>

					</table>


				</c:when>


				<c:when test="${model.viewIndex == 2}">
					<%--Notification sidebar selected --%>
					<div class="sectionHead"><fmt:message
						key="profileNotifSectionTitle" /></div>
					<div class="introText"><fmt:message
						key="profileNotifSectionIntroText" /></div>

					<c:if test="${error != null}">
						<div class="error"><c:out value="${error}"></c:out></div>
					</c:if>


					<c:if test="${model.notifs != null}">

						<div><c:out value="${item.user.naasUserName}" /></div>

						<table id="formTable" width="100%" cellpadding="2" cellspacing="0">

							<c:forEach var="notif" items="${model.notifs}" varStatus="status">

								<tr
									class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when>
								<c:otherwise>rowEven</c:otherwise></c:choose>">
									<td nowrap="nowrap" valign="middle"><strong><c:out value="${notif.flow.name}" /></strong></td>

									<td class="ctrl" nowrap="nowrap" valign="middle"><input
										id="<c:out value="${notif.flow.id}${deliminator}OnSolicit" />"
										type="checkbox" <c:if test="${notif.onSolicit}">checked</c:if>
										value="<c:out value="${notif.flow.id}${deliminator}OnSolicit" />"
										name="notifReq" /><label
										for="<c:out value="${notif.flow.id}${deliminator}OnSolicit" />">Solicit</label>
									</td>

									<td class="ctrl" nowrap="nowrap" valign="middle"><input
										id="<c:out value="${notif.flow.id}${deliminator}OnQuery" />"
										type="checkbox" <c:if test="${notif.onQuery}">checked</c:if>
										value="<c:out value="${notif.flow.id}${deliminator}OnQuery" />"
										name="notifReq" /><label
										for="<c:out value="${notif.flow.id}${deliminator}OnQuery" />">Query</label>
									</td>

									<td class="ctrl" nowrap="nowrap" valign="middle"><input
										id="<c:out value="${notif.flow.id}${deliminator}OnSubmit" />"
										type="checkbox" <c:if test="${notif.onSubmit}">checked</c:if>
										value="<c:out value="${notif.flow.id}${deliminator}OnSubmit" />"
										name="notifReq" /><label
										for="<c:out value="${notif.flow.id}${deliminator}OnSubmit" />">Submit</label>
									</td>

									<td class="ctrl" nowrap="nowrap" valign="middle"><input
										id="<c:out value="${notif.flow.id}${deliminator}OnNotify" />"
										type="checkbox" <c:if test="${notif.onNotify}">checked</c:if>
										value="<c:out value="${notif.flow.id}${deliminator}OnNotify" />"
										name="notifReq" /><label
										for="<c:out value="${notif.flow.id}${deliminator}OnNotify" />">Notify</label>
									</td>

									<td class="ctrl" nowrap="nowrap" valign="middle"><input
										id="<c:out value="${notif.flow.id}${deliminator}OnSchedule" />"
										type="checkbox"
										<c:if test="${notif.onSchedule}">checked</c:if>
										value="<c:out value="${notif.flow.id}${deliminator}OnSchedule" />"
										name="notifReq" /><label
										for="<c:out value="${notif.flow.id}${deliminator}OnSchedule" />">Schedule</label>
									</td>

									<td class="ctrl" nowrap="nowrap" valign="middle"><input
										id="<c:out value="${notif.flow.id}${deliminator}OnDownload" />"
										type="checkbox"
										<c:if test="${notif.onDownload}">checked</c:if>
										value="<c:out value="${notif.flow.id}${deliminator}OnDownload" />"
										name="notifReq" /><label
										for="<c:out value="${notif.flow.id}${deliminator}OnDownload" />">Download</label>
									</td>

									<td class="ctrl" nowrap="nowrap" valign="middle"><input
										id="<c:out value="${notif.flow.id}${deliminator}OnExecute" />"
										type="checkbox" <c:if test="${notif.onExecute}">checked</c:if>
										value="<c:out value="${notif.flow.id}${deliminator}OnExecute" />"
										name="notifReq" /><label
										for="<c:out value="${notif.flow.id}${deliminator}OnExecute" />">Execute</label>
									</td>

									<td class="ctrl" nowrap="nowrap" valign="middle"><a href="#"
										onclick="toggleCheck('<c:out value="${notif.flow.id}${deliminator}" />');">Toggle</a></td>

								</tr>

							</c:forEach>

							<tr>
								<td class="command" colspan="9" align="right"><input
									type="button" name="cancel"
									onclick="location.href='profile.htm?bi=0'" value="Cancel"
									class="button" /> <input type="submit" name="save"
									value="Save" class="button" /></td>
							</tr>

						</table>

					</c:if>

				</c:when>
			</c:choose></form>

		</c:if>
		</td>

	</tr>

</table>

<script type="text/javascript">  

 
 	
 
	function toggleCheck(flow){

		var boxTypes = ["Solicit", "Query", "Notify", "Submit", "Schedule", "Execute", "Download"];
		
		jQuery.each(boxTypes, function() {
		
			var boxId = "#" + flow + "On" + this;

			//alert("Id: " + boxId);
			//alert("Object: " + $(boxId));
			//alert("Attr: " + $(boxId).attr("checked"));
			
	      	if($(boxId).attr("checked")) {
		        $(boxId).attr("checked", "")
		    } else {
		    	$(boxId).attr("checked", "checked")
		    }
	     
	 	});	
	
	}
                                    
 </script>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
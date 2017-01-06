<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include
			file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="configTitle" /></div>
		
		<div class="introText"><fmt:message key="configIntroText" /></div>

		<p style="clear: both;" /><c:choose>

			<c:when test="${model.viewIndex == 0}">
				<div class="sectionHead"><fmt:message
					key="configArgsSectionTitle" /></div>
				<div class="introText"><fmt:message key="configArgsIntroText" /></div>

				<c:if test="${error != null}">
					<div class="error"><c:out value="${error}"></c:out></div>
				</c:if>

				<div style="clear: both; text-align: right; margin-bottom: 10px">
				<input type="button" name="cmdNew" value="Add Argument" class="button"
					onclick="location.href='config-arg.htm'" /></div>

				<c:if test="${model.args != null}">
					<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
						<c:forEach var="arg" items="${model.args}" varStatus="status">
							<tr
								class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when><c:otherwise>rowEven</c:otherwise></c:choose>">
								<td width="10" nowrap="nowrap">
								    <a href="config-arg.htm?id=<c:out value="${arg.id}" />">
								        <img alt="" src="img/icon_settings.gif" style="border: 0; vertical-align: middle; padding-right: 3px;" />
								    </a>
								</td>
								<td width="*"><strong><a href="config-arg.htm?id=<c:out value="${arg.name}" />" class="blacktext" ><c:out value="${arg.name}" /></a></strong>:</td>
								<td width="*" align="right"><a href="config-arg.htm?id=<c:out value="${arg.id}" />" class="blacktext" ><c:out value="${arg.value}" /></a></td>
								<td width="10" align="right"><input type="image"
									title="Edit" src="img/application_form_edit.png" alt="Edit"
									align="middle" style="border-width: 0px;"
									onclick="location.href='config-arg.htm?id=<c:out value="${arg.id}" />'" /></td>
							</tr>
						</c:forEach>
					</table>
				</c:if>
			</c:when>

			<c:when test="${model.viewIndex == 1}">
				<div class="sectionHead"><fmt:message
					key="configConnSectionTitle" /></div>
				<div class="introText"><fmt:message key="configConnIntroText" /></div>

				<c:if test="${error != null}">
					<div class="error"><c:out value="${error}"></c:out></div>
				</c:if>

				<div style="clear: both; text-align: right; margin-bottom: 10px">
				<input type="button" name="cmdNew" value="Add Data Source" class="button"
					onclick="location.href='config-conn.htm'" /></div>

				<c:if test="${model.conns != null}">
					<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
						<c:forEach var="conn" items="${model.conns}" varStatus="status">
							<tr class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when><c:otherwise>rowEven</c:otherwise></c:choose>">
								<td width="10"  nowrap="nowrap">
								    <a href="config-conn.htm?id=<c:out value="${conn.id}" />" >
								        <img alt="" src="img/list_links.gif" style="border: 0; vertical-align: middle; padding-right: 3px;" />
								    </a>
								</td>
								<td width="*"><strong><a href="config-conn.htm?id=<c:out value="${conn.id}" />" class="blacktext"><c:out value="${conn.code}" /></a></strong>:</td>
								<td width="*" align="right"><a href="config-conn.htm?id=<c:out value="${conn.id}" />" class="blacktext"><c:out value="${conn.providerType}" /></a></td>
								<td width="10" align="right"><input type="image"
									title="Edit" src="img/application_form_edit.png" alt="Edit"
									align="middle" style="border-width: 0px;"
									onclick="location.href='config-conn.htm?id=<c:out value="${conn.id}" />'" /></td>
							</tr>
						</c:forEach>
					</table>
				</c:if>
			</c:when>

			<c:otherwise>
				<div class="sectionHead"><fmt:message
					key="configPartnerSectionTitle" /></div>
				<div class="introText"><fmt:message
					key="configPartnerIntroText" /></div>

				<c:if test="${error != null}">
					<div class="error"><c:out value="${error}"></c:out></div>
				</c:if>

				<div style="clear: both; text-align: right; margin-bottom: 10px">
				<input type="button" name="cmdNew" value="Add Partner" class="button"
					onclick="location.href='config-partner.htm'" /></div>

				<c:if test="${model.partners != null}">
					<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
						<c:forEach var="partner" items="${model.partners}"
							varStatus="status">
							<tr class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when><c:otherwise>rowEven</c:otherwise></c:choose>">
								<td width="10" nowrap rowspan="2">
								    <a href="config-partner.htm?id=<c:out value="${partner.id}" />">
								        <img alt="" src="img/page_url.gif" style="border: 0; vertical-align: middle; padding-right: 3px;" />
								    </a>
								</td>
								<td width="*"><strong><a href="config-partner.htm?id=<c:out value="${partner.id}" />" class="blacktext"><c:out value="${partner.name}" /></a></strong></td>
								<td width="10" align="right"  nowrap rowspan="2"><input type="image"
									title="Edit" src="img/application_form_edit.png" alt="Edit"
									align="middle" style="border-width: 0px;"
									onclick="location.href='config-partner.htm?id=<c:out value="${partner.id}" />'" /></td>
							</tr>
							<tr class="<c:choose><c:when test="${status.index % 2 == 0}">rowOdd</c:when><c:otherwise>rowEven</c:otherwise></c:choose>">
								<td width="*"><a href="config-partner.htm?id=<c:out value="${partner.id}" />" class="blacktext"><c:out value="${partner.url}" /></a></td>
							</tr>
						</c:forEach>
					</table>
				</c:if>
			</c:otherwise>
		</c:choose>
		</td>
	</tr>
</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
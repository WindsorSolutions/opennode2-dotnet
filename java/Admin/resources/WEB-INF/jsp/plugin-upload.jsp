<%@ include file="/WEB-INF/jsp/_head.jsp"%>


<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left"><%@ include
			file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">

		<div id="pageTitle"><fmt:message key="flowTitle" /></div>
        <div class="introText"><fmt:message key="flowIntroText" /></div>
            <p style="clear: both;" />
				<div class="sectionHead"><fmt:message key="flowListPluginSectionTitle" /></div>
				<div class="introText"><fmt:message key="flowListPluginSectionIntroText" /></div>
				
				<c:if test="${error != null}">
                     <div class="error"><c:out value="${error}" /></div>
                </c:if>

				<form action="plugin-upload.htm" method="post" enctype="multipart/form-data">
				<table id="formTable" width="310" cellpadding="2" cellspacing="0">
				    
					<tr>
						<td class="label" width="5%" style="text-align: right; vertical-align: top;">Plugin:</td>
			            <td class="ctrl" width="95%" style="vertical-align: top;">
			            
				            <div><b><tt><big>
				                <input type="file" name="file" 
        				            style="color:#630; background:#ffc none; font-family:Courier,monospace; font-weight:bold; font-size: .9em;">
				            </big></tt></b></div>
			            
			            </td>
			    	</tr>
			    	<tr>
			    		<td class="label" width="5%" style="text-align: right; vertical-align: top;">Exchange:</td>
			    		<td class="ctrl" width="95%" style="vertical-align: top;">
			    		
							<select name="flowId" style="vertical-align: bottom; width: 100%;">
								<option value="" /></option>
								<c:forEach var="flow" items="${model.flows}">
									<option value="<c:out value="${flow.id}" />" ><c:out value="${flow.name}" /></option>
								</c:forEach>
							</select>
			    		
			    		</td>
			    	</tr>
			    	
			    	<tr>
						<td class="command" colspan="2" align="right">
						  <input type="button" 
			     		      name="cancel"
            				  onclick="location.href='flow.htm'" 
            				  value="Cancel"
						      class="button" />					
						<input type="submit" name="cmdUpload" 
							   value="Upload Plugin" 
							   id="cmdUpload" class="button" />
						</td>
					</tr>
				
				</table>
				</form>

		</td>

	</tr>

</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
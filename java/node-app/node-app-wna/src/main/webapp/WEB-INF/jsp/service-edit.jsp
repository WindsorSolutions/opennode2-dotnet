<%@ include file="/WEB-INF/jsp/_head.jsp"%>
<script type="text/javascript">
$(document).ready(function() {
    var implementorsMap = new Object();
    <c:forEach items="${pluginServiceImplementorDescriptors}" var="descriptor" varStatus="status">
    implementorsMap['<c:out value="${descriptor.name}" />'] = '<c:out value="${descriptor.description}" />';
    </c:forEach>

    var splitClassName = $(".jqServiceimplementingClassName option:selected").text().split(".");
    var selectedClassName = splitClassName[splitClassName.length - 1].trim();
    $("#implementorDescriptionSpan").text(implementorsMap[selectedClassName]);

    $(".jqServiceimplementingClassName").change(function(){
        var splitClassName = $(".jqServiceimplementingClassName option:selected").text().split(".");
        var selectedClassName = splitClassName[splitClassName.length - 1].trim();
        $("#implementorDescriptionSpan").text(implementorsMap[selectedClassName]);
    });
});
</script>
<table id="contentTable">
	<tr>
		<td id="sidebarPane" align="left">
		  <%@ include file="/WEB-INF/jsp/_bar.jsp"%></td>
		<td id="contentPane">
        
		<div id="pageTitle"><fmt:message key="flowTitle" /></div>

		<div class="sectionHead"><fmt:message key="flowServiceSectionTitle" /></div>
		<div class="introText"><fmt:message key="flowServiceSectionIntroText" /></div>

		<c:if test="${error != null}">
			<div class="error"><c:out value="${error}"></c:out></div>
		</c:if>

		<form method="post" action="service-edit.htm">

		<table id="formTable" width="100%" cellpadding="2" cellspacing="0">

            <!-- EXCHANGE -->
			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;">
				    Exchange:
				</td>
				<td class="ctrl" width="95%">
			       <c:out value="${command.flowName}" />
                    <spring:bind path="command.service.flowId">
                        <input type="hidden" name="<c:out value="${status.expression}" />" 
                            value="<c:out value="${status.value}" />" />
                    </spring:bind>
				</td>
			</tr>
		
            <!-- SERVICE -->
			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;">Service&nbsp;Name:</td>
				<td class="ctrl" width="95%">
					<spring:bind path="command.service.name">
						<input type="text" name="<c:out value="${status.expression}" />" 
							value="<c:out value="${status.value}" />" class="textbox"  style="width: 95%;" />
						<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> >
						  <c:out value="${status.errorMessage}" />
					    </span>
					</spring:bind>
					
					<spring:bind path="command.service.id">
						<input type="hidden" name="<c:out value="${status.expression}" />" 
							value="<c:out value="${status.value}" />" />
					</spring:bind>
				</td>
			</tr>
			
            <!-- IMPLEMENTERS -->
			<tr>
				<td class="label" width="5%" style="text-align: right; vertical-align: top;">Implementer:</td>
				<td class="ctrl" width="95%">
                    <spring:bind path="command.service.implementingClassName">
					<select id="<c:out value="${status.expression}" />" name="<c:out value="${status.expression}" />"
						style="vertical-align: middle; width: 96%;" class="jqServiceimplementingClassName">
						<option value="" /></option>
						<c:forEach var="implementer" items="${command.implementers}"
							varStatus="rowSatus">
							<option value="<c:out value="${implementer}" />"
								<c:if test="${ implementer == command.service.implementingClassName }">selected</c:if> >
								<c:out value="${implementer}" />
							</option>
						</c:forEach>
					</select>
					<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> >
					   <c:out value="${status.errorMessage}" />
				   </span>
                   </spring:bind>
				</td>
			</tr>
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Implementer Description:</td>
                <td class="ctrl" width="95%"><span id="implementorDescriptionSpan"></span></td>
            </td>
			
			<c:if test="${ (command.service.id != null) && (command.service.id != \"\") }">
	            <!-- TYPES -->
				<tr>
					<td class="label" width="5%" style="text-align: right; vertical-align: top;">Type:</td>
					<td class="ctrl" width="95%"><spring:bind path="command.service.type">
						<select id="<c:out value="${status.expression}" />" 
							name="<c:out value="${status.expression}" />"
							style="vertical-align: middle; width: 96%;">
							<c:forEach var="srvType" items="${command.service.supportedTypes}">
								<option value="<c:out value="${srvType}" />"
									<c:if test="${srvType == command.service.type}">selected</c:if> > 
								<c:out value="${srvType}" /></option>
							</c:forEach>
						</select>
						<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> >
						   <c:out value="${status.errorMessage}" />
					   </span>
					</spring:bind></td>
				</tr>

                <tr>
                    <td class="label" width="5%" style="text-align: right; vertical-align: top;"><label for="noAuthRequired">No Auth Required:</label></td>
                    <td class="ctrl" width="95%">
                        <form:checkbox id="noAuthRequired" style="vertical-align: middle;" path="command.service.noAuthRequired" />
                        &nbsp;Making service No Auth Required will make it available to unauthenticated users (Note: No Auth Required does not override a Flow marked Protected, if this service's Flow is marked Protected, this flag will not take effect.)
                    </td>
                </tr>
				
				<tr>
					<td class="label" width="5%" style="text-align: right; vertical-align: top;"><label for="Active">Active:</label></td>
					<td class="ctrl" width="95%"><spring:bind path="command.service.active">
						<input type="hidden" name="_<c:out value="${status.expression}"/>">
	        			<input type="checkbox" id="Active" style="vertical-align: middle;" 
	        			name="<c:out value="${status.expression}"/>" value="true"
	           			 <c:if test="${status.value}">checked</c:if>/>
	           			 &nbsp;Making service inactive will prevent it from being accessible using the Web Service interface.
						<span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> >
						   <c:out value="${status.errorMessage}" />
						   </span>
					</spring:bind>
					</td>
				</tr>
				
				<!-- ARGS -->
				<c:if test="${command.service.args[0] != null}">
				<tr>
					<td class="label" width="5%" style="text-align: right; vertical-align: top;">Arguments:</td>
					<td class="ctrl" width="95%">
						<table width="95%" cellpadding="1" cellspacing="1">
							<c:forEach var="arg" items="${command.service.args}" varStatus="argStatus">
								<tr>
									<td><spring:bind path="command.service.args[${argStatus.index}].key">
									Key:&nbsp;<strong><c:out value="${status.value}" /></strong>
									<input type="hidden" name="<c:out value="${status.value}"/>" 
										value="<c:out value="${status.expression}"/>" />
									</spring:bind></td>	
									<td align="right">Use&nbsp;global&nbsp;value<spring:bind path="command.service.args[${argStatus.index}].global">
											<input type="hidden" name="_<c:out value="${status.expression}"/>">
						        			<input type="checkbox" name="<c:out value="${status.expression}"/>" value="true" 
						        			style="vertical-align: middle;" <c:if test="${status.value}">checked</c:if> 
						           			onclick="switchArgType(this, <c:out value="${argStatus.index}" />);" 
									/></spring:bind></td>						
								</tr>
								
								<tr>
									<td colspan="2">
										<select id="argG<c:out value="${argStatus.index}" />" 
											onchange="setArgValue(this, <c:out value="${argStatus.index}" />);" 
											style="width: 100%;display:<c:choose><c:when 
											test="${arg.global}">block</c:when><c:otherwise>none</c:otherwise></c:choose>;">
											<option value="" /></option>
											<c:forEach var="gArg" items="${model.globalArgs}">
												<option value="<c:out value="${gArg.id}" />"
													<c:if test="${gArg.id == arg.value}">selected</c:if> >
													<c:out value="${gArg.id}" />
												</option>
											</c:forEach>
										</select>
										<spring:bind path="command.service.args[${argStatus.index}].value">
										<input id="argM<c:out value="${argStatus.index}" />" type="text" 
										name="<c:out value="${status.expression}" />" 
											value="<c:out value="${status.value}" />" class="textbox"  
											style="width: 99%;display:<c:choose><c:when 
											test="${arg.global}">none</c:when><c:otherwise>block</c:otherwise></c:choose>;" />
										</spring:bind>
									</td>
									
								</tr>
							</c:forEach>
						</table>
					</td>
				</tr>
				</c:if>
				
				<!-- DATA SOURCES -->
	            <c:if test="${command.service.dataSources[0] != null}">
				<tr>
					<td class="label" width="5%" style="text-align: right; vertical-align: top;">Data&nbsp;Sources:</td>
					<td class="ctrl" width="95%">
							<c:forEach var="conn" items="${command.service.dataSources}" varStatus="connStatus">
								<table width="100%" cellpadding="2" cellspacing="0">
								     <tr>
										<td><spring:bind path="command.service.dataSources[${connStatus.index}].code">
										Key:&nbsp;<strong><c:out value="${status.value}" /></strong>
										<input type="hidden" name="<c:out value="${status.expression}"/>" 
											value="<c:out value="${status.value}"/>" />
										</spring:bind>
										</td>
									</tr>
									<tr>
										<td>
										<spring:bind path="command.service.dataSources[${connStatus.index}].id">
										<select id="<c:out value="${status.expression}" />" 
										name="<c:out value="${status.expression}" />" style="vertical-align: middle; width: 95%;">
											<c:forEach var="sysConn" items="${model.sysConnections}" varStatus="connStatus">
												<option value="<c:out value="${sysConn.id}" />" 
												<c:if test="${sysConn.id == status.value}">selected</c:if>>
												<c:out value="${sysConn.code}" /></option>
											</c:forEach>
										</select>
										</spring:bind>
										</td>
									</tr>
								</table>
							</c:forEach>
					</td>
				</tr>
	            </c:if>
			
			</c:if>

            <!-- BUTTONS -->
			<tr>
				<td class="command" colspan="2" align="right">
					<input type="button" name="cancel"
						onclick="location.href='flow.htm'" value="Cancel"
						class="button" />
					<c:choose>
						<c:when test="${ (command.service.id == null) || (command.service.id == \"\") || (command.service.implementingClassName == \"\") }">
							<input type="submit" name="next" value="Next" class="button" />
						</c:when>
						<c:otherwise>
							<input type="submit" name="save" value="Save" class="button" />
							<input type="submit" name="delete" value="Delete"
						onclick="return confirm('Are you sure you want to delete this service?\nAny schedule using this service will be made inactive.');"
						class="button" />
						</c:otherwise>
					</c:choose>
						
				</td>
			</tr>
			
		</table>
		</form>
		</td>

	</tr>
</table>

 <script type="text/javascript">   
 
 
 	function setArgValue(list, index){
 	
		var text = document.getElementById('argM' + index);
		
		if (list.selectedIndex > -1){
			text.value = list.options[list.selectedIndex].value;
		}
		
		//alert(text.value);
 	}
 
	function switchArgType(box, index){
	
		$("#argM" + index).toggle().val("");
		$("#argG" + index).toggle().children("option").attr("selected", false);
	
	}
                                    
 </script> 

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
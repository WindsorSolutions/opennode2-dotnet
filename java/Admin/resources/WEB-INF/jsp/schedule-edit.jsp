<%@ include file="/WEB-INF/jsp/_head.jsp"%>



<table id="contentTable">
    <tr>
        <td id="sidebarPane" align="left"><%@ include
            file="/WEB-INF/jsp/_bar.jsp"%></td>
        <td id="contentPane">

        <div id="pageTitle"><fmt:message key="scheduleTitle" /></div>
        <div class="introText"><fmt:message key="scheduleIntroText" /></div>

        <div class="sectionHead"><fmt:message key="scheduleItemSectionTitle" /></div>
        <div class="introText"><fmt:message key="scheduleItemSectionIntroText" /></div>

        <c:if test="${error != null}">
            <div class="error"><c:out value="${error}"></c:out></div>
        </c:if>

        <form method="post" action="schedule-edit.htm">
        
            <spring:bind path="command.id">
                <input type="hidden" 
                       name="<c:out value="${status.expression}" />" 
                       value="<c:out value="${status.value}" />" />
            </spring:bind>

        <table id="formTable" width="100%" cellpadding="2" cellspacing="0">     
        
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Name:</td>
                <td class="ctrl" width="95%">
                <spring:bind path="command.name">
                    <input type="text"
                           name="<c:out value="${status.expression}" />" 
                           value="<c:out value="${status.value}" />" class="textbox" />
                           <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                </spring:bind>
                </td>
            </tr>
            
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;"><label for="active">Active:</label></td>
                <td class="ctrl" width="95%">
	                <spring:bind path="command.active">
	                    <input type="hidden" name="_<c:out value="${status.expression}"/>">
	                    <input type="checkbox" id="active" 
	                       name="<c:out value="${status.expression}"/>" 
	                       value="true" 
	                       <c:if test="${status.value}">checked</c:if>
	                       onClick="flipSaveAndRunNow()"
	                     />
	                     <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
	                </spring:bind>                    
                </td>
            </tr>
            
            <!-- FLOW -->
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Exchange:</td>
                <td class="ctrl" width="5%">
                <spring:bind path="command.flowId">
                    <select id="flowId"
                        onchange="setServiceList(this.options[selectedIndex].value); return true;" 
                        name="<c:out value="${status.expression}" />" 
                        style="width:96%" >
                        <option value=""></option>
                        <c:forEach var="flow" items="${model.flows}">
                            <option value="<c:out value="${flow.id}" />"
                                <c:if test="${ flow.id == command.flowId }">selected</c:if> 
                            ><c:out value="${flow.name}" /></option>
                        </c:forEach>
                    </select>
                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="error=${status.errorMessage}" /></span>
                </spring:bind></td>
            </tr>
            
            <!-- AVAILABILITY -->
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Availability:</td>
                <td class="ctrl" width="95%">
                
                    <table cellpadding="2" cellspacing="1">
                        <tr>
                            <td>Starts&nbsp;On</td>
                            <td>&nbsp;&nbsp;&nbsp;</td>
                            <td>Ends&nbsp;On</td>
                        </tr>
                        <tr>
                            <td valign="top">
                            <spring:bind path="command.startOn">
                                <input id="startOn" 
                                       type="text" 
                                       name="<c:out value="${status.expression}" />" 
                                       size="20" 
                                       maxlength="20" 
                                       value="<c:out value="${status.value}" />" 
                                       class="cal" 
                                       style="width:130px;" 
                                       readonly  />
                                <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                            </spring:bind>
                            </td>
                            <td></td>
                            <td valign="top">
                            <spring:bind path="command.endOn">
                                <input id="endOn" type="text" name="<c:out value="${status.expression}" />" 
                                    size="20" maxlength="20"
                                value="<c:out value="${status.value}" />" class="cal" 
                                    style="width:130px;" readonly  />
                                <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                            </spring:bind>
                            </td>
                            
                        </tr>
                    </table>
                    
                </td>
            </tr>
            
            
            <!-- FREQUENCY -->
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Frequency:</td>
                <td class="ctrl" width="95%">
                
                    <table cellpadding="2" cellspacing="1">
                            <tr>
                                <td valign="top">Every</td>
                                <td valign="top">
                                <spring:bind path="command.frequency">
                                    <input id="frequencyNum" 
                                           type="text" 
                                           name="<c:out value="${status.expression}" />" 
                                           style="width: auto" 
                                           value="<c:out value="${status.value}" />" 
                                           class="textbox" 
                                           size="4" 
                                           maxlength="3" />
                                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                                </spring:bind>
                                </td>
                                <td valign="top">
                                <spring:bind path="command.frequencyType">
                                    <select id="frequencyType" name="<c:out value="${status.expression}" />" 
                                        style="width: auto" onchange="setFrequencyLogic()">
                                        <c:forEach var="freq" items="${model.frequencyTypes}">
                                            <option value="<c:out value="${freq}" />" 
                                            <c:if test="${ freq == command.frequencyType }">selected</c:if> >
                                        <c:out value="${freq}" /></option>
                                        </c:forEach>
                                    </select>
                                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                                </spring:bind>
                                </td>
                            </tr>
                    </table>
                
                </td>
            </tr>
            
            
            <!-- SOURCE -->
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Data&nbsp;Source:</td>
                <td class="ctrl" width="95%">
                
                    <table cellpadding="2" cellspacing="1" width="100%">
                        <tr>
                            <td width="*" colspan="2">
                                <c:choose>
                                    <c:when test="${command.sourceType == 'LocalService' || command.sourceType == 'None' || command.sourceType == null || command.sourceType == ''}" >
                                       <c:set var="sourceTypeName" value="LocalService" />
                                    </c:when>
                                    <c:otherwise>
                                       <c:set var="sourceTypeName" value="${command.sourceType}" />
                                    </c:otherwise>
                                </c:choose>
                                <spring:bind path="command.sourceType">
                                    
                                    <table cellpadding="1" cellspacing="1">
                                        <tr><td>
                                            <label for="sourceLocalService">
                                            <img src="img/page_extension.gif" border="0" alt="Local Service" align="bottom" />
                                            <input type="radio" id="sourceLocalService" name="<c:out value="${status.expression}"/>" 
                                            <c:if test="${sourceTypeName == 'LocalService'}"> 
                                               checked 
                                            </c:if> 
                                            value="LocalService" 
                                            onClick="formatServiceType(1); switchTargetType('None'); return true;" />
                                            Results of local service execution</label>
                                        </td></tr>
                                        <tr><td>
                                            <label for="sourceWebServiceSolicit">
                                            <img src="img/page_url.gif" border="0" alt="Web Service" align="bottom" />
                                            <input type="radio" id="sourceWebServiceSolicit" name="<c:out value="${status.expression}"/>" 
                                            <c:if test="${sourceTypeName == 'WebServiceSolicit'}"> checked </c:if> value="WebServiceSolicit" 
                                            onClick="formatServiceType(2); return true;" />
                                            Results of partner service solicit (Transaction Id)</label>
                                        </td></tr>
                                        <tr><td>
                                            <label for="sourceWebServiceQuery">
                                            <img src="img/page_url.gif" border="0" alt="Web Service" align="bottom" />
                                            <input type="radio" id="sourceWebServiceQuery" name="<c:out value="${status.expression}"/>" 
                                            <c:if test="${sourceTypeName == 'WebServiceQuery'}"> checked </c:if> value="WebServiceQuery" 
                                            onClick="formatServiceType(3); switchTargetType('None'); return true;" />
                                            Results of partner service query (XML)</label>
                                        </td></tr>
                                        <tr><td>
                                            <label for="sourceFile">
                                            <img src="img/page_text.gif" border="0" alt="File" align="bottom" />
                                            <input type="radio" id="sourceFile" name="<c:out value="${status.expression}"/>" 
                                            <c:if test="${sourceTypeName == 'File'}"> checked </c:if> value="File" 
                                            onClick="formatServiceType(4); switchTargetType('None'); return true;" />
                                            File system resource (network path)</label>
                                        </td></tr>
                                    </table>
                                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                                </spring:bind>
                                
                                <c:choose>
                                    <c:when test="${sourceTypeName == 'File'}">
                                        <c:set var="sourceTypeF" value="block"/>
                                        <c:set var="sourceTypeS" value="none"/>
                                        <c:set var="sourceTypeP" value="none"/>
                                        <c:set var="sourceTypeL" value="block"/>
                                        <c:set var="sourceTypeLV" value="Path:"/>
                                        <c:set var="sourceTypeA" value="none"/>
                                        <c:set var="sourceTypeO" value="none"/>
                                    </c:when>
                                    <c:when test="${sourceTypeName == 'LocalService'}">
                                        <c:set var="sourceTypeF" value="none"/>
                                        <c:set var="sourceTypeS" value="block"/>
                                        <c:set var="sourceTypeP" value="none"/>
                                        <c:set var="sourceTypeL" value="block"/>
                                        <c:set var="sourceTypeLV" value="Service:"/>
                                        <c:set var="sourceTypeA" value="block"/>
                                        <c:set var="sourceTypeO" value="none"/>
                                    </c:when>
                                    <c:when test="${sourceTypeName == 'WebServiceSolicit' || sourceTypeName == 'WebServiceQuery'}">
                                        <c:set var="sourceTypeF" value="none"/>
                                        <c:set var="sourceTypeS" value="none"/>
                                        <c:set var="sourceTypeP" value="block"/>
                                        <c:set var="sourceTypeL" value="block"/>
                                        <c:set var="sourceTypeLV" value="Partner:"/>
                                        <c:set var="sourceTypeA" value="block"/>
                                        <c:set var="sourceTypeO" value="block"/>
                                    </c:when>
                                    <c:otherwise>
                                        <c:set var="sourceTypeF" value="none"/>
                                        <c:set var="sourceTypeS" value="none"/>
                                        <c:set var="sourceTypeP" value="none"/>
                                        <c:set var="sourceTypeL" value="none"/>
                                        <c:set var="sourceTypeLV" value=""/>
                                        <c:set var="sourceTypeA" value="none"/>
                                        <c:set var="sourceTypeO" value="none"/>
                                    </c:otherwise>
                                </c:choose>
                            
                            <div id="fromLabel" style="display:<c:out value="${sourceTypeL}"/>;" ><c:out value="${sourceTypeLV}" /></div>
                                                        
                                <div id="sourceTypeF" style="display:<c:out value="${sourceTypeF}"/>;" >                    
                                <spring:bind path="command.sourceId">
                                    <input id="sourceCommonId" type="text" name="<c:out value="${status.expression}" />" 
                                    value="<c:out value="${status.value}" />" class="textbox" 
                                    style="width:95%;" />
                                    <c:if test="${status.errorMessage != \"\" && status.errorMessage != null}">
                                       <c:set var="sourceErrorMessage" value="${status.errorMessage}" />
                                    </c:if>
                                </spring:bind>
                                </div>
                                
                                <!-- SERVICE DROP-DOWN -->
                                <div id="sourceTypeS" style="display:<c:out value="${sourceTypeS}"/>;" > 
                                <select id="sourceServiceList" name="serviceList" 
                                    onchange="$('#sourceCommonId').val(this.options[selectedIndex].value)"  
                                    style="width:96%;">
                                    <c:choose>
                                        <c:when test="${command.flowId == null || command.flowId ==''}">
                                            <option value=""></option>
                                        </c:when>
                                        <c:otherwise>
                                            <c:forEach var="service" items="${command.services}">
                                                <option value="<c:out value="${service.key}" />" 
                                                <c:if test="${command.sourceId == service.key}"> selected </c:if>>
                                                <c:out value="${service.value}" />
                                                </option>
                                            </c:forEach>
                                        </c:otherwise>
                                    </c:choose>
                                </select>
                                </div>
                                
                                <!-- PARTNER DROP-DOWN -->
                                <div id="sourceTypeP" style="display:<c:out value="${sourceTypeP}"/>;" >    
                                <select id="sourcePartnerList" name="partnerList" 
                                onchange="$('#sourceCommonId').val(this.options[selectedIndex].value)"  
                                style="width:96%;">
                                        <option value=""></option>
                                    <c:forEach var="partner" items="${model.partners}">
                                        <option value="<c:out value="${partner.id}" />" 
                                            <c:if test="${command.sourceId == partner.id}"> selected </c:if>
                                        ><c:out value="${partner.name}" /></option>
                                    </c:forEach>
                                </select>
                                </div>
                                
                                <!-- display sourceId error message regardless of what source type is selected -->
                                <c:if test="${sourceErrorMessage != \"\" || sourceErrorMessage != null}">
                                    <div id="sourceIdErrorDisplay" style="display:block;">
                                        <span class="error"><c:out value="${sourceErrorMessage}" /></span>
                                    </div>
                                </c:if>
                                
                                
                            <!-- PARTNER OPERATION -->
                            <div id="sourceOperationLabel" 
                                 style="display:<c:out value="${sourceTypeO}"/>;">Operation name:</div>

                                <spring:bind path="command.sourceOperation">
                                <input id="sourceOperation" type="text" name="<c:out value="${status.expression}" />" 
                                    value="<c:out value="${status.value}" />" class="textbox" 
                                    style="width:95%; display:<c:out value="${sourceTypeO}"/>;" />
                                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                                </spring:bind>
                        
                                <!-- SERVICE ARGUMENTS -->
                            <div id="sourceArgsLabel" 
                                 style="display:<c:out value="${sourceTypeA}"/>;">Arguments:</div>

                                <spring:bind path="command.sourceArgs">
                                    <textarea id="sourceArgs" name="<c:out value="${status.expression}" />" rows="4" cols="20" 
                                    class="textbox" style="display:<c:out value="${sourceTypeA}"/>; width:95%;"><c:out value="${status.value}" /></textarea>
                                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                                </spring:bind>
                                
                            
                            </td>
                        </tr>
                    </table>
                    
                    
                </td>
            </tr>
            <!-- SOURCE END -->
            
            
            <!-- TARGET -->
            <tr>
                <td class="label" width="5%" style="text-align: right; vertical-align: top;">Result&nbsp;Process:</td>
                <td class="ctrl" width="95%">
                
                    <table cellpadding="2" cellspacing="1" width="100%">
                        <tr>
                            <td width="*" colspan="2">
                                
                                <spring:bind path="command.targetType">
                                    <table cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td>
                                            <fmt:message key="scheduleItemTargetText" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <label for="targetRadioNone">
                                            <img src="img/page_text.gif" border="0" alt="None" align="bottom" />
                                            <input type="radio" id="targetRadioNone" name="<c:out value="${status.expression}"/>" 
                                            <c:if test="${command.targetType == 'None' || command.targetType == null || command.targetType == ''}"> checked </c:if> value="None" 
                                            onClick="switchTargetType('None'); return true;" />
                                            None</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <label for="targetPartner" >
                                            <img src="img/page_link.gif" border="0" alt="Partner" align="bottom" />
                                            <input type="radio" id="targetPartner" name="<c:out value="${status.expression}"/>" 
                                            <c:if test="${command.targetType == 'Partner'}"> checked </c:if> value="Partner" 
                                            onClick="switchTargetType('Partner'); return true;" />
                                            Submit result to an Exchange Network partner</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <label for="targetSchematron">
                                            <img src="img/page_tick.gif" border="0" alt="Schematron" align="bottom" />
                                            <input type="radio" id="targetSchematron" name="<c:out value="${status.expression}"/>" 
                                            <c:if test="${command.targetType == 'Schematron'}"> checked </c:if> value="Schematron" 
                                            onClick="switchTargetType('Schematron'); return true;" />
                                            Submit result to Schematron service for validation</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <label for="targetFile">
                                            <img src="img/action_save.gif" border="0" alt="File" align="bottom" />
                                            <input type="radio" id="targetFile" name="<c:out value="${status.expression}"/>" 
                                            <c:if test="${command.targetType == 'File'}"> checked </c:if> value="File" 
                                            onClick="switchTargetType('File'); return true;" />
                                            Save uncompressed result to a network path location</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="targetEmail">
                                                <img src="img/page_attachment.gif" border="0" alt="Email" align="bottom" />
                                                <input type="radio" id="targetEmail" name="<c:out value="${status.expression}"/>" 
                                                <c:if test="${command.targetType == 'Email'}"> checked </c:if> value="Email" 
                                                onClick="switchTargetType('Email'); return true;" />
                                                Send compressed result as an email attachment</label>
                                            </td>
                                        </tr>
                                    </table>
                                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                                </spring:bind>
                                
                            </td>
                        </tr>
                        <tr>
                            <td width="5%" valign="middle"><div id="targetCommonIdLabel" style="display:
                                <c:choose>
                                     <c:when test="${command.targetType == 'File' || command.targetType == 'Email' || command.targetType == 'Partner'}">
                                         block
                                     </c:when>
                                     <c:otherwise>none</c:otherwise>
                                </c:choose>;">To:</div>
                            </td>
                            <td class="ctrl" valign="top" width="95%">
                             <spring:bind path="command.targetId">
                                 <input type="text" id="targetCommonId" name="<c:out value="${status.expression}" />" value="<c:out value="${status.value}" />"  class="textbox" style="display:
                                 <c:choose>
                                     <c:when test="${command.targetType == 'File' || command.targetType == 'Email'}">
                                         block
                                     </c:when>
                                     <c:otherwise>none</c:otherwise>
                                    </c:choose>;" />
                                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                                </spring:bind>
                                
                                <select id="targetPartnerList" name="partnerList" 
                                onchange="$('#targetCommonId').val(this.options[selectedIndex].value)"  
                                style=" width: 96%; display:<c:choose><c:when 
                                test="${command.targetType == 'Partner'}">block</c:when><c:otherwise>none</c:otherwise></c:choose>;">
                                        <option value=""></option>
                                        <c:forEach var="partner" items="${model.partners}">
                                            <option value="<c:out value="${partner.id}" />" 
                                            <c:if test="${command.targetId == partner.id}"> selected </c:if>
                                            ><c:out value="${partner.name}" /></option>
                                        </c:forEach>
                                </select>                                   
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <!-- TARGET END -->
            
            
            <!-- COMMAND -->

            <tr>
                <td class="command" colspan="2" align="right">
                
                <c:if test="${command.executeStatus == 'Running' }">
                    <span class="error">Schedule is currently being executed. 
                    Please wait until it is finished before making changes.</span>
                </c:if>
                                    
    
                    <input type="button" name="cancel"
                           onclick="location.href='schedule.htm?bi=0'" 
                           value="Cancel" class="button" />
                           
                    <input type="submit" name="save" 
                           value="Save" class="button" />
                           
                    <input type="submit" name="delete" value="Delete"
                        <c:if test="${command.id == null || command.id == \"\" }">
                          <c:out value='disabled="true"' />
                        </c:if>
                        onclick="return confirm('Are you sure you want to delete this schedule?');"
                        class="button" />

                    <input id="saveAndRunNow" type="submit" name="now" 
                        <c:if test="${command.active == null || command.active == \"\" }">
                            <c:out value='disabled="true"' />
                        </c:if>
                        onclick="return setRunNowAndSave()" 
                        value="Save and Run Now" 
                        class="button" />
                        
                    <spring:bind path="command.runNow">
                        <input type="hidden" name="_<c:out value="${status.expression}"/>">
                        <input type="checkbox" id="runNow" name="<c:out value="${status.expression}"/>" value="true" style="display:none;" 
                           <c:if test="${status.value}">checked</c:if>
                        />
                    </spring:bind>
                            
                </td>
            </tr>
        </table> <!-- Form Table -->
        </form>
        </td>
    </tr>
</table> <!-- Content Table -->

<script type="text/javascript">

	function flipSaveAndRunNow() {

		currentState = $("#saveAndRunNow").attr("disabled");
		$("#saveAndRunNow").attr("disabled", !currentState);
		return true;
	}

    function setServiceList(flowId){ 
        $("#sourceTypeS").load("service-list.htm?flowId=" + flowId, [], function(){$("#sourceTypeS").show()});
    }

    function setRunNowAndSave(){
    
        $("#runNow").attr("checked", true); 
        return true;    
    
    }

    function setFrequencyLogic(){
    
        switch($("#frequencyType").val())
        {
        
            case 'Once':
                $("#endOn").val($("#startOn").val());
                $("#frequencyNum").val("0").attr("disabled", true); 
                break;
                
            case 'Hourly':
            case 'Daily':
            case 'Weekly':
            case 'Monthly':
                $("#frequencyNum").val("1");
                $("#frequencyNum").removeAttr("disabled");  
                break;
                
            default:
                break;  
            
        }
        
    }
 
 
    function switchTargetType(targetType){
    
        //reset everything to start with
        $("#targetCommonId").hide().val("");
        $("#targetPartnerList").hide();
        $("#targetCommonIdLabel").hide();
        
        switch(targetType){
        
            case 'None':
                $("#targetRadioNone").attr("checked", "checked");
                break;
                
            case 'Partner':
                $("#targetCommonIdLabel").show();
                $("#targetPartnerList").show();
                break;
                
            case 'File':
            case 'Email':
                $("#targetCommonIdLabel").show();
                $("#targetCommonId").show();
                break;
                
            default:
                break;  
        }
            
    }
 
 
    function formatServiceType(sourceType){
    
        $("#sourceTypeF").hide().val("");
        $("#sourceTypeS").hide();
        $("#sourceTypeP").hide();
        
        $("#sourceArgs").hide().val("");
        $("#sourceArgsLabel").hide();
        $("#fromLabel").hide().val("");
        $("#sourceOperationLabel").hide();
        $("#sourceOperation").hide().val("");
        $("#fromValueCtrl").hide();
        
        
        $("input[@name='targetType']").attr('disabled', false);
        $("input[@name='targetType']").attr('checked', false);
        
        switch(sourceType){
        
            case 1:
                $("#sourceTypeS").show();
                $("#sourceArgs").show();
                $("#sourceArgsLabel").show();
                $("#fromLabel").show().html("Service:");
                $("#fromValueCtrl").show();
                break;
            
            case 2:
                $("#sourceTypeP").show();
                $("#sourceArgs").show();
                $("#sourceArgsLabel").show();
                $("#fromLabel").show().html("Partner:");
                $("#sourceOperationLabel").show();
                $("#sourceOperation").show();
                $("#fromValueCtrl").show();
                $("input[@name='targetType']").attr('disabled', true);
                break;
                
            case 3:
                $("#sourceTypeP").show();
                $("#sourceArgs").show();
                $("#sourceArgsLabel").show();
                $("#fromLabel").show().html("Partner:");
                $("#sourceOperationLabel").show();
                $("#sourceOperation").show();
                $("#fromValueCtrl").show();
                break;
                
            case 4:
                $("#sourceTypeF").show();
                $("#fromLabel").show().html("Path:");
                $("#fromValueCtrl").show();
                $("#sourceCommonId").val("");
                break;
                
            default:
                $("#sourceCommonId").show();
                break;
        
        }
            
    }
                                    
</script> 

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
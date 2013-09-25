                                    <%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>
                                    <%
                                        response.setHeader("Cache-Control","no-cache"); //HTTP 1.1
                                        response.setHeader("Pragma","no-cache"); //HTTP 1.0
                                        response.setDateHeader ("Expires", 0); //prevent caching at the proxy server
                                    %>
                                    <c:if test="${not empty model.parameterDescriptors[0]}">
                                    <div id="sourceArgsLabel" class="label" style="text-align:left">Arguments <span style="font-weight:normal; width:10em; white-space:normal; vertical-align:bottom">(Arguments in <span style="font-weight:bold">bold</span> are required by the service)</span></div>
                                    </c:if>
                                    <div>
                                    <c:forEach var="parameterDescriptor" items="${model.parameterDescriptors}" varStatus="loop">
                                        <div>
                                            <span class="label" style="text-align:left; display: inline-block; <c:choose><c:when test='${parameterDescriptor.required}'>font-weight:bold;</c:when><c:otherwise>font-weight:normal;</c:otherwise></c:choose> width:10em; white-space:normal; vertical-align:bottom"><c:out value="${parameterDescriptor.name}" />:&nbsp;&nbsp;</span>
                                            <span style="vertical-align:bottom;">
                                                <input type="hidden" id="scheduleArguments[<c:out value='${loop.index}' />].argumentKey" name="scheduleArguments[<c:out value='${loop.index}' />].argumentKey" 
                                                    value="<c:out value='${parameterDescriptor.name}' />" />
                                                <input id="scheduleArguments[<c:out value='${loop.index}' />].argumentValue" name="scheduleArguments[<c:out value='${loop.index}' />].argumentValue" size="20" maxlength="1024" 
                                                    value="<c:out value='${model.parameterValues[loop.index].argumentValue}' />" /><img src="img/help.png" alt="Help" align="middle" style="border-width: 0px;" onclick="showHelp('helpText<c:out value="${loop.index}" />')" /></span>
                                            <div id="helpText<c:out value='${loop.index}' />" style="display:none"><c:out value="${parameterDescriptor.description}" /></div>
                                        </div>
                                    </c:forEach>
                                    </div>

<script type="text/javascript">  
function showHelp(id) {
    $("#" + id).slideToggle();
}

</script>
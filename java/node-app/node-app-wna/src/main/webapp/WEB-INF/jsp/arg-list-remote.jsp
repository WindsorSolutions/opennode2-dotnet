<%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>
<%
    response.setHeader("Cache-Control","no-cache"); //HTTP 1.1
    response.setHeader("Pragma","no-cache"); //HTTP 1.0
    response.setDateHeader ("Expires", 0); //prevent caching at the proxy server
%>

                                    <div id="sourceArgsLabel" class="label" style="text-align:left">Arguments <span style="font-weight:normal; width:10em; white-space:normal; vertical-align:bottom">(Enter Name in first field and Value in second field for each argument)</span></div>
                                    <div id="scheduleArgumentsContainerDiv">
                                    <c:forEach var="scheduleArgument" items="${scheduleArguments}" varStatus="loop">
                                        <div id="scheduleArgumentDiv<c:out value='${loop.index}' />" class="scheduleArgumentDiv" data-index="<c:out value='${loop.index}' />">
                                            <span style="vertical-align:bottom;">
                                                <input id="scheduleArguments[<c:out value='${loop.index}' />].argumentKey" name="scheduleArguments[<c:out value='${loop.index}' />].argumentKey" size="20" maxlength="255" 
                                                    value="<c:out value='${scheduleArguments[loop.index].argumentKey}' />" />
                                                <input id="scheduleArguments[<c:out value='${loop.index}' />].argumentValue" name="scheduleArguments[<c:out value='${loop.index}' />].argumentValue" size="30" maxlength="1024" 
                                                    value="<c:out value='${scheduleArguments[loop.index].argumentValue}' />" />
                                                <img class="deleteParameterX" alt="Delete Parameter" src="img/red-x.png">
                                            </span>
                                        </div>
                                    </c:forEach>
                                    </div>
                                    <div ><img id="addParameterPlus" alt="Add New Parameter" src="img/plus.png">&nbsp;Add New Parameter</div>



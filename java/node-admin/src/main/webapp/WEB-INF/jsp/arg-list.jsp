                                    <%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>
                                    <c:if test="${not empty model.parameterDescriptors[0]}">
                                    <div id="sourceArgsLabel" class="label" style="text-align:left">Arguments</div>
                                    </c:if>
                                    <div>
                                    <c:forEach var="parameterDescriptor" items="${model.parameterDescriptors}" varStatus="loop">
                                        <span class="label" style="text-align:left; font-weight:normal"><c:out value="${parameterDescriptor.name}" />:&nbsp;&nbsp;</span>
                                        <input id="scheduleArguments[<c:out value='${loop.index}' />].argumentValue" name="scheduleArguments[<c:out value='${loop.index}' />].argumentValue" size="20" maxlength="4000" 
                                            value="<c:out value='${model.parameterValues[loop.index].argumentValue}' />" />
                                        <br />
                                    </c:forEach>
                                    </div>
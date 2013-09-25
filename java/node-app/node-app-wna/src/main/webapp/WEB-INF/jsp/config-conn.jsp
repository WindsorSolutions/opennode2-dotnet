<%@ include file="/WEB-INF/jsp/_head.jsp"%>

<table id="contentTable">
    <tr>
        <td id="sidebarPane" align="left"><%@ include
            file="/WEB-INF/jsp/_bar.jsp"%></td>
        <td id="contentPane">

        <div id="pageTitle"><fmt:message key="configTitle" /></div>

        <div class="sectionHead"><fmt:message
            key="configConnSectionTitle" /></div>
        <div class="introText"><fmt:message key="configConnIntroText" /></div>
        
        <c:if test="${error != null}">
            <div class="error"><c:out value="${error}"></c:out></div>
        </c:if>
        <span class="greentext"><c:out value="${connectionMessage}" /></span>

        <form method="post" action="config-conn.htm">
        <spring:bind path="command.id">
        <input type="hidden" name="id" value="<c:out value="${status.value}" />" />
        </spring:bind>
        <table id="formTable" width="100%" cellpadding="2" cellspacing="0">

            <tr>
                <td class="label" width="50" style="text-align: right; vertical-align: top;"><img alt=""
                    src="img/list_links.gif"
                    style="border: 0; vertical-align: middle; padding-right: 3px;" />Name:
                </td>
                <td class="ctrl" width="750">
                <spring:bind path="command.code">
                    <input type="text" name="code" value="<c:out value="${status.value}" />" 
                    class="textbox" size="50" maxlength="50" />
                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                </spring:bind></td>
            </tr>
            <tr>

                <td class="label" width="50" style="text-align: right; vertical-align: top;">Provider:</td>
                <td class="ctrl">
                    <form:select path="command.providerType" items="${jdbcProviderTypes}" cssClass="select" />
                </td>
            </tr>

            <tr>
                <td class="label" width="50" style="text-align: right; vertical-align: top;">Connection:</td>
                <td class="ctrl"><spring:bind path="command.connectionString">
                    <textarea name="connectionString" class="textbox" rows=" 4" cols="53"><c:out value="${status.value}" /></textarea>
                    <span class="error" <c:if test="${status.errorMessage == \"\"}">style="display:none;"</c:if> ><c:out value="${status.errorMessage}" /></span>
                </spring:bind></td>
            </tr>

            <tr>
                <td class="command" colspan="2" align="right">
                <spring:bind path="command.code">
                <input type="submit" value="Check Connection" class="button" name="check" onclick="return isUrl();" />
                <input type="button" value="Cancel" class="button" onclick="location.href='config.htm?bi=1'" /> 
                <input type="submit" value="Save" class="button" name="save" /> 
                <input type="submit" value="Delete" class="button" name="delete" 
                    <c:if test="${status.value == null || status.value == ''}">disabled="yes"</c:if>
                    onclick="return confirm('Are you sure you want to delete this data source item?');" />
                </spring:bind></td>
            </tr>
        </table>
        </form>
        </td>

    </tr>

</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>
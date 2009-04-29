<%@ page session="true"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jstl/fmt" %>
<%@page isErrorPage="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>OpenNode2 Administration Utility</title>
<link rel="stylesheet" type="text/css" href="static/css/admin.css" />
<meta name="ROBOTS" content="NOINDEX, NOFOLLOW" />
<link rel="SHORTCUT ICON" href="favicon.ico" />
</head>

<body>
<div id="titleArea">
        <div id="title">OpenNode2 Administration Utility</div>
        <div style="clear: both"></div>
</div>
<!--  for the white background  -->
<div class="body">
<br class="layoutSpacerTop" />

<table id="contentTable">
    <tr>
        <td id="sidebarPane" align="left">&nbsp;</td>
        <td id="contentPane">
        <div id="pageTitle">An Unexpected Error Occurred</div>

        <div class="introText">
        <p>An unexpected error occurred, and has been logged.
        The details of this error appear below. The &quot;Return&quot; 
        button takes you back to the screen displayed prior to the error.</p>
        </div>
        </td>
    </tr>
    <tr>
        <td align="left">&nbsp;</td>
            <td class="command" align="right">
                <input type="button"
                 class="button"  
                 name="returnBtn" 
                 value="Return"
                 onclick="history.back();"/>
            </td>
     </tr>
    <tr>
        <td align="left">&nbsp;</td>
        <td>
        <div class="introText">
        <!-- <p>If this error persists, please contact the 
        <a href="mailto:<fmt:message key="adminSupportEmail" />">Node Administrator</a>. </p> -->
        <hr /> 
        <p><b>Exception:</b></p>
        <%
            if ((exception != null ) 
                    && (exception instanceof ServletException)) {
              
            ServletException servletException = (ServletException) exception;
        %>
            <%= "<p>Error message: " + servletException.getMessage() + "</p>" %>
            <%= "<p>Exception: " + servletException + "</p>" %>
            <%= "<p>Root cause: " + servletException.getRootCause() + "</p>" %>
            <%= "<p>Nested cause" + servletException.getRootCause().getCause() + "</p>" %>
        
        <%
            } else {
        %>
        
            <%= "<p>Error message: " + exception.getMessage() + "</p>" %>
            <%= "<p>Exception: " + exception + "</p>" %>
            <%= "<p>Root cause: " + exception.getCause() + "</p>" %>
            
        <% 
            }
        %>
        </div>
        </td>
    </tr>
</table>

<%@ include file="/WEB-INF/jsp/_foot.jsp"%>


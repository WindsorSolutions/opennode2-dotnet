<%@ page session="true"%>
<%@ page errorPage="error.jsp" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jstl/fmt" %>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title><fmt:message key="appTitle" /></title>
<meta name="ROBOTS" content="NOINDEX, NOFOLLOW" />
<link rel="SHORTCUT ICON" href="favicon.ico" />


<script src="<c:url value="static/js/admin.js"/>" type="text/javascript"></script>
<script src="<c:url value="static/js/jquery.js"/>" type="text/javascript"></script>

<script src="<c:url value="static/js/jquery1.1.compatibility.js"/>" type="text/javascript"></script>
<script src="<c:url value="static/js/jquery.autocomplete.js"/>" type="text/javascript"></script>
<script src="<c:url value="static/js/jQueryBGIFrame.js"/>" type="text/javascript"></script>
<script src="<c:url value="static/js/jQuery.datePicker.js"/>" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="<c:url value="static/css/jquery.autocomplete.css"/>" media="screen" />
<link rel="stylesheet" type="text/css" href="<c:url value="static/css/admin.css"/>" />
<link rel="stylesheet" type="text/css" href="<c:url value="static/css/calendar.css"/>" />

<jsp:include page="ajax.jsp"></jsp:include>
</head>
<body>
<div id="titleArea">
		<div id="title"><fmt:message key="appTitle" /></div>
		<div id="tabs">
		<ul>
			<c:choose>
				<c:when test="${model.visit == null}">&nbsp;</c:when>
				<c:otherwise>
					<li <c:if test="${model.tab == null || model.tab == 0}">class="current"</c:if> >
					   <a href="dashboard.htm">
						  <span><img alt="" src="img/page_dynamic.gif" />Dashboard</span>
					   </a>
					</li>
                </c:otherwise>
            </c:choose>
					
                <c:if test='${model.visit.userAccount.role == "Admin"}'>
					
					<li <c:if test="${model.tab != null && model.tab == 1}">class="current"</c:if> >
					   <a href="config.htm">
					       <span><img alt="" src="img/page_settings.gif" />Configuration</span>
					   </a>
				    </li>
					<li <c:if test="${model.tab != null && model.tab == 2}">class="current"</c:if> >
					   <a href="security.htm">
					       <span><img alt="" src="img/page_security.gif" />Security</span>
				       </a>
			        </li>
				    <li <c:if test="${model.tab != null && model.tab == 3}">class="current"</c:if> >
	       		       <a href="flow.htm">
			     	        <span><img alt="" src="img/page_dynamic.gif" />Exchange</span>
    		           </a>
			        </li>
		        </c:if>
                <c:if test="${model.visit != null}">
					<li <c:if test="${model.tab != null && model.tab == 4}">class="current"</c:if> >
					   <a href="schedule.htm">
					       <span><img alt="" src="img/date.gif" />Schedules</span>
				       </a>
			       </li>
				    <li <c:if test="${model.tab != null && model.tab == 5}">class="current"</c:if> >
				        <a href="activity.htm">
				            <span><img alt="" src="img/page_tick.gif" />Activity</span>
			            </a>
		            </li>
					<li <c:if test="${model.tab != null && model.tab == 6}">class="current"</c:if> >
						<a href="profile.htm">
						   <span><img alt="" src="img/page_user.gif" />Profile</span>
					    </a>
			         </li>
                </c:if>
		</ul>
		</div>
		<div style="clear: both"></div>
</div>
<!--  for the white background  -->
<div class="body">

<c:if test="${model.visit != null}">
<div class="userInfo">
	<c:out value="${model.visit.userAccount.naasUserName}" />
		&nbsp;as&nbsp;<c:out value="${model.visit.userAccount.role}" />
		&nbsp;|&nbsp;<a href="exit.htm">Sign out</a>
</div>
</c:if>

<br class="layoutSpacerTop" />


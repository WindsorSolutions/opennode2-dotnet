<%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>

<c:if test="${feed != null }">

<div class="sectionHead"><strong><c:out value="${feed.title}" escapeXml="false"/></strong></div>
<div class="introText"><c:out value="${feed.description}" escapeXml="false"/></div>


<c:if test="${empty feed.items}">
    <div class="newsTitle">No news available.</div>
</c:if>

<c:forEach items="${feed.items}" var="item">
    <div class="newsTitle">
    	<img alt="" src="img/comment_yellow.gif" />
    	<a href="<c:out value="${item.url}" escapeXml="false"/>" target="_blank"><c:out value="${item.title}" escapeXml="false"/></a>
    </div>
    <div class="newsTime"><c:out value="${item.date}" escapeXml="false"/></div>
    <div class="newsDescr"><c:out value="${item.body}" escapeXml="false"/></div>
</c:forEach>

</c:if>
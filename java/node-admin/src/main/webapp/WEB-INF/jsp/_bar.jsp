<c:if test="${model.bars != null}">
	<div id="menu">
	<ul>
		<c:forEach var="bar" items="${model.bars}" varStatus="status">
			<li>
				 <a href="<c:out value="${bar.link}"/>"
					<c:if test="${bar.active}">class="current"</c:if> >
					<c:out value="${bar.text}" />
				</a>
			</li>
		</c:forEach>
	</ul>
	</div>
</c:if>
<%@ page session="true"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jstl/core"%>


<table width="100%" cellpadding="1" cellspacing="0" bgcolor="#ffffff">

	<c:if test="${model.cmd == 'activity'}">



		<c:forEach var="activityItem" items="${model.activityList}" varStatus="status">

			<tr>
				<td width="15">&nbsp;</td>
				<td nowrap width="15%" class="ctrl" valign="top"><c:out
					value="${activityItem.modifiedOn}" /></td>
				<td class="ctrl" valign="top" width="*"><c:out
					value="${activityItem.message}" /></td>
			</tr>
			
			<tr><td colspan="3"><img src="img/1_DCDCDC.gif" width="100%" height="1" vspace="0" hspace="0" border="0" /></td></tr>

		</c:forEach>



	</c:if>

</table>


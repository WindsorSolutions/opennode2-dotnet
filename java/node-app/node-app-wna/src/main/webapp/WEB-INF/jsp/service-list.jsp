
<%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>
                                <select id="sourceServiceList" name="serviceList" 
                                    onchange="$('#sourceCommonId').val(this.options[selectedIndex].value); loadArgList();"  
                                    style="width:96%;">
                                        <option value=""></option>
                                    <c:forEach var="service" items="${model.services}">
                                        <option value="<c:out value="${service.key}" />" 
                                            <c:if test="${model.sourceId == service.key}"> selected </c:if>>
                                          <c:out value="${service.value}" />
                                        </option>
                                    </c:forEach>
                                </select>
<script type="text/javascript">
    $(document).ready(function()
    {
        $("#sourceServiceList").change(function()
        {
            loadLocalArgList();
            $('#sourceCommonId').val(this.options[selectedIndex].value);
        });
    });
</script>
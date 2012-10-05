<%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>
<script type="text/javascript">
<!--
$(document).ready(function(){
	$('.findDataSource').autocomplete('<c:url value="/ajax/datasources.htm"/>', simpleOptions);
	$('#userSearch').autocomplete('<c:url value="/ajax/accounts.htm"/>', simpleOptions);
	$("#userSearch").result(function(event, data, formatted) {
		if (data){
			goto(data);
		}
	});
	$('input.cal').calendar();
});

var simpleOptions = {
    minChars: 1,
    max: 10,
    delay: 100,
    formatItem: function(row, i, max){
        return row;
    },
    formatResult: function(row, i, max){
        return row;
    },
    width: 500
}


//-->
</script>
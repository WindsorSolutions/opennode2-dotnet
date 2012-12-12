<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" >
	<xsl:output method="html"/>
	<xsl:template match="/" xpath-default-namespace="http://www.exchangenetwork.net/schema/ends/2">
		<html>
			<head>
				<title>OpenNode2 Web Services</title>
				<style type="text/css">
					body {font-family:'bulo_regularregular', Arial, Helvetica, sans-serif;}
					th {padding: 0 10 0 10; text-align:left;}
					td {padding: 0 10 0 10;}
					h3 {margin: 0px; padding: 05;}
					table {font-size:0.8em;}
					a.expand {text-decoration:none;color:#404040;}
					a.expand:visited {color:#404040;}
			</style>
			<script language="JavaScript" type="text/javascript">
			    function doMenu(item) {
			        obj = document.getElementById(item);
			        col = document.getElementById("x" + item);
			        if (obj.style.display == "none") {
			            obj.style.display = "block";
			            col.innerHTML = "[-] ";
			        }
			        else {
			            obj.style.display = "none";
			            col.innerHTML = "[+] ";
			        }
			    }
            </script> 
			</head>
			<body style="font-family:arial">
				<h2>OpenNode2 Web Services</h2>
				<xsl:for-each select="NetworkNodes/NetworkNodeDetails" xpath-default-namespace="http://www.exchangenetwork.net/schema/ends/2">
					Node Identifier: <xsl:value-of select="NodeIdentifier"/><br/>
					Node Address: <a>
											<xsl:attribute name="href">
												<xsl:value-of select="NodeAddress" /><xsl:value-of select="NodeAddress"/>
											</xsl:attribute>
											<xsl:attribute name="target">blank</xsl:attribute>
											</a><br/>
					Organization Identifier: <xsl:value-of select="OrganizationIdentifier"/><br/>
					<br/>
					<xsl:call-template name="ServiceDetailTemplate"/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
	
	<xsl:template xpath-default-namespace="http://www.exchangenetwork.net/schema/ends/2" match="NetworkNodes/NetworkNodeDetails/NodeServiceList" name="ServiceDetailTemplate">
		<xsl:for-each-group select="NodeServiceList/Service" group-by="Dataflow">
			<div style="height:2.2em;width:800px;background-color:#E0E0E0;border: none;margin-bottom: 3px;">
			<h3>
				<a>
					<xsl:attribute name="class">expand</xsl:attribute>
					<xsl:attribute name="href">JavaScript:doMenu('main<xsl:value-of select="position()"/>');</xsl:attribute> <xsl:attribute name="id">xmain<xsl:value-of select="position()"/></xsl:attribute>[+] 
				</a>
				<xsl:value-of select="Dataflow"/> (<xsl:value-of select="count(current-group())"/> Services)
			</h3>
			</div>
			<div>
				<xsl:attribute name="id">main<xsl:value-of select="position()"/></xsl:attribute> <xsl:attribute name="style">padding-left:10; display:none;</xsl:attribute>
				<xsl:for-each select="current-group()">
					<h4><xsl:value-of select="ServiceIdentifier"/> (<xsl:value-of select="MethodName"/>)</h4>
					<div style="padding-left:5;">
						<xsl:value-of select="ServiceDescription"/><br/>
						<xsl:choose>
							<xsl:when test="ServiceDocumentURL!=''">
								<a><xsl:attribute name="href"><xsl:value-of select="ServiceDocumentURL"/></xsl:attribute>More Info</a><br/>
							</xsl:when>
						</xsl:choose>
						<table>
							<tbody>
								<tr>
									<th>Parameter Name</th>
									<th>Required</th>
									<th>Sort Order</th>
								</tr>
								<xsl:for-each select="Parameter">
									<tr>
										<td><xsl:value-of select="@ParameterName"/></td>
										<td><xsl:value-of select="@ParameterRequiredIndicator"/></td>
										<td><xsl:value-of select="@ParameterSortIndex"/></td>
									</tr>
								</xsl:for-each>
							</tbody>
						</table>
					</div>
				</xsl:for-each>
			</div> 
		</xsl:for-each-group>
	</xsl:template>
	
</xsl:stylesheet>

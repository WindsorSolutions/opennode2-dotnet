<%@ Page language="c#" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Test</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
        
        <asp:button id="btnTest" text="Test" OnClick="WriteTest" runat="server"/>
        
        <script runat="server">
       
            void WriteTest(Object sender, EventArgs e)
            {
            
				Response.Write("<h1>NODE SETUP TEST UTILITY</h1>");
                Response.Write("<h2>Header Info</h2>");
                Response.Write("<pre>");
                foreach(string header in System.Web.HttpContext.Current.Request.Headers)
                {
                    foreach(string headerValue in System.Web.HttpContext.Current.Request.Headers.GetValues(header))
                    {
                        Response.Write(string.Format("Header Name: {0}\t\tHeader Value: {1}\n\r", 
                            header ,headerValue));
                    }
                } 
                Response.Write("</pre>");
      
                Response.Write("<h2>Request Info</h2>");
                Response.Write("<pre>");
                foreach(string request in System.Web.HttpContext.Current.Request.Params)
                {
                    Response.Write(string.Format("Request Name: {0}\t\tRequest Value: {1}\n\r", request, 
                        System.Web.HttpContext.Current.Request[request].ToString()));
                } 
                Response.Write("</pre>");
                
            }

        </script>

        </form>
    </body>
</HTML>



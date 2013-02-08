<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsBar.ascx.cs" Inherits="Windsor.Node2008.Admin.Secure.NewsBar" %>

<p style="clear:both;" />

<asp:Repeater runat="server" ID="listChannels" onitemcreated="listChannels_ItemCreated">

    <ItemTemplate>
    
    <div>
    
        <div class="sectionHead"><strong><%# Server.HtmlEncode((string)Eval("Title"))%></strong></div>
        <div class="introText"><%# Server.HtmlEncode((string)Eval("Description"))%></div>
        <div>
        
        <asp:Repeater runat="server" ID="listItems" DataSource='<%# Eval("Items") %>'>

            <ItemTemplate>
                
                <div>
                   
                   <div class="newsTitle"><img alt="" src="../Images/UI/balloon.png" /><%# Server.HtmlEncode((string)Eval("Title"))%></div> 
                   <div class="newsTime"><%# Server.HtmlEncode(Eval("PubDate").ToString())%></div> 
                   <div class="newsDescr"><%# Server.HtmlEncode((string)Eval("Description"))%></div> 
                    
                </div>
            
            </ItemTemplate>

        
        </asp:Repeater>
        
        </div>
 
 
    </div>
    
    </ItemTemplate>
    
                <SeparatorTemplate>
                <br />
            </SeparatorTemplate>

</asp:Repeater>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsBar.ascx.cs" Inherits="Windsor.Node2008.Admin.Secure.NewsBar" %>

<p style="clear:both;" />

<asp:Repeater runat="server" ID="listChannels" onitemcreated="listChannels_ItemCreated">

    <ItemTemplate>
    
    <div>
    
        <div class="sectionHead"><strong><%# Eval("Title")%></strong></div>
        <div class="introText"><%# Eval("Description")%></div>
        <div>
        
        <asp:Repeater runat="server" ID="listItems" DataSource='<%# Eval("Items") %>'>

            <ItemTemplate>
                
                <div>
                   
                   <div class="newsTitle"><img alt="" src="../Images/comment_yellow.gif" /><%# Eval("Title")%></div> 
                   <div class="newsTime"><%# Eval("PubDate")%></div> 
                   <div class="newsDescr"><%# Eval("Description")%></div> 
                    
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SimpleList.ascx.cs" Inherits="Windsor.Node2008.Admin.Controls.SimpleList" %>
<div class="sectionHead">
    <%= Config.SectionHeadline%></div>
<div class="introText">
    <asp:Repeater ID="introParagraphs" runat="server">
        <ItemTemplate>
            <p>
                <%# Container.DataItem %></p>
        </ItemTemplate>
    </asp:Repeater>
</div>
<asp:Panel ID="buttonPanel" runat="server" Style="clear: both; text-align: right; margin-bottom: 10px">
    <asp:Button ID="secondaryButton" runat="server" CssClass="button" Visible="false" />
    <asp:Button ID="mainButton" runat="server" CssClass="button" Visible="true" OnClick="OnMainButtonClick" />
</asp:Panel>
<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
    <asp:Repeater runat="server" ID="repeaterList">
        <ItemTemplate>
            <tr class="rowOdd" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                <td width="10px">
                    <img alt="" src='<%= Config.LinkItemImageUri %>' style="border: 0; vertical-align: middle; padding-right: 4px;" />
                </td>
                <td runat="server" id="valueNameItem" width="100%">
                    <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel" title="Edit"><strong>
                        <%# Server.HtmlEncode((string)Eval("Value.Name")) %></strong><%# !string.IsNullOrEmpty((string)Eval("Value.Description")) ? "&nbsp;&nbsp;(" + Server.HtmlEncode((string)Eval("Value.Description")) + ")" : "" %> </a>
                </td>
                <td width="10px" align="right">
                    <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>'>
                        <img src="../Images/UI/application_form_edit.png" alt="Edit" title="Edit" align="middle" style="border-width: 0px; vertical-align: middle; padding-right: 4px;" />
                    </a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

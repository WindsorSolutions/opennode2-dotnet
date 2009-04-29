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
<asp:Panel ID="buttonPanel" runat="server" style="clear: both; text-align: right; margin-bottom: 10px">
    <asp:Button ID="secondaryButton" runat="server" CssClass="button" Visible="false" />
    <asp:Button ID="mainButton" runat="server" CssClass="button" Visible="true" OnClick="OnMainButtonClick" />
</asp:Panel>
<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
    <asp:Repeater runat="server" ID="repeaterList">
        <ItemTemplate>
            <tr class="rowOdd">
                <td width="10">
                    <img alt="" src='<%= Config.LinkItemImageUri %>' style="border: 0; vertical-align: middle; padding-right: 3px;" />
                </td>
                <td>
                    <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel">
                        <strong><%# Eval("Value.Name") %></strong>&nbsp;&nbsp;(<%# Eval("Value.Description")%>)
                    </a>
                </td>
                <td width="10" align="right">
                    <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>'>
                        <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="absmiddle" style="border-width: 0px;" />
                    </a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="rowEven">
                <td width="10">
                    <img alt="" src='<%= Config.LinkItemImageUri %>' style="border: 0; vertical-align: middle; padding-right: 3px;" />
                </td>
                <td>
                    <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel">
                        <strong><%# Eval("Value.Name") %></strong>&nbsp;&nbsp;(<%# Eval("Value.Description")%>)
                    </a>
                </td>
                <td width="10" align="right">
                    <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>'>
                        <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="absmiddle" style="border-width: 0px;" />
                    </a>
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
</table>

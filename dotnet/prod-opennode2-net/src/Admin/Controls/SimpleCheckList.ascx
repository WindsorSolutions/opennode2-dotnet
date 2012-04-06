<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SimpleCheckList.ascx.cs" Inherits="Windsor.Node2008.Admin.Controls.SimpleCheckList" %>
<div class="sectionHead"><%= Config.SectionHeadline%></div>
<div class="introText">
<asp:Repeater ID="introParagraphs" runat="server">
    <ItemTemplate>
        <p><%# Container.DataItem %></p>
    </ItemTemplate>
</asp:Repeater>
<br/>
</div>

<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
    <asp:Repeater runat="server" ID="repeaterList">
        <ItemTemplate>
		    <tr class="rowOdd">
				    <td width="20"><img alt="" src='<%= Config.LinkItemImageUri %>'
					    style="border: 0; vertical-align: middle; padding-right: 3px;" /></td>
					<td align="left">
                        <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel">
                            <strong><%# Eval("Value.Name") %></strong>
                        </a>
					</td>
				    <td width="*" align="right"><%# Eval("Value.Description")%></td>
				    <td align="right" nowrap="nowrap">
				        <asp:CheckBox ID="checkBox" runat="server" />
				        <asp:Label ID="checkTag" runat="server" Visible="false"/>
				    </td>
			</tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
 		    <tr class="rowEven">
				    <td width="20"><img alt="" src='<%= Config.LinkItemImageUri %>'
					    style="border: 0; vertical-align: middle; padding-right: 3px;" /></td>
					<td align="left">
                        <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel">
                            <strong><%# Eval("Value.Name") %></strong>
                        </a>
					</td>
				    <td width="*" align="right"><%# Eval("Value.Description")%></td>
				    <td align="right" nowrap="nowrap">
				        <asp:CheckBox ID="checkBox" runat="server" />
				        <asp:Label ID="checkTag" runat="server" Visible="false"/>
				    </td>
			</tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
</table>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SimpleStackList.ascx.cs" Inherits="Windsor.Node2008.Admin.Controls.SimpleStackList" %>
<div class="sectionHead"><%= Config.SectionHeadline%></div>
<div class="introText">
<asp:Repeater ID="introParagraphs" runat="server">
    <ItemTemplate>
        <p><%# Container.DataItem %></p>
    </ItemTemplate>
</asp:Repeater>
</div>

<div style="clear: both; text-align: right; margin-bottom: 10px">		
	<input type="button" name="cmdNew" value='<%= Config.DetailItemLinkText %>'  class="button" onclick="location.href='<%= Config.DetailItemLinkUri %>'" />
</div>

<table id="formTable" width="100%" cellpadding="2" cellspacing="0">
    <asp:Repeater runat="server" ID="repeaterList">
        <ItemTemplate>
		    <tr class="rowOdd">
				    <td width="10"><img alt="" src='<%= Config.LinkItemImageUri %>'
					    style="border: 0; vertical-align: middle; padding-right: 3px;" /></td>
				    <td runat="server" id="valueNameItem" width="100%" ><%# Eval("Value.Name") %></td>
				    <td width="10" align="right">
				        <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>'>
				            <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="absmiddle" style="border-width: 0px;" />
				        </a>
				    </td>
			</tr>
			<tr class="rowOdd" >
			    <td>&nbsp;</td>
			    <td runat="server" id="valueDescriptionItem" width="100%" colspan="2" class="ctrl" align="left"><%# Eval("Value.Description")%></td>
			</tr>
			<tr runat="server" id="customRow" class="rowOdd" visible="false">
			    <td>&nbsp;</td>
			    <td runat="server" id="customRowContent" width="100%" colspan="2" class="ctrl" ></td>
			</tr>
       </ItemTemplate>
        <AlternatingItemTemplate>
		    <tr class="rowEven">
				    <td width="10"><img alt="" src='<%= Config.LinkItemImageUri %>'
					    style="border: 0; vertical-align: middle; padding-right: 3px;" /></td>
				    <td runat="server" id="valueNameItem" width="100%" ><%# Eval("Value.Name") %></td>
				    <td width="10" align="right">
				        <a href='<%= Config.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>'>
				            <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="absmiddle" style="border-width: 0px;" />
				        </a>
				    </td>
			</tr>
			<tr class="rowEven" >
			    <td>&nbsp;</td>
			    <td runat="server" id="valueDescriptionItem" width="100%" colspan="2" class="ctrl" align="left"><%# Eval("Value.Description")%></td>
			</tr>
			<tr runat="server" id="customRow" class="rowEven" visible="false">
			    <td>&nbsp;</td>
			    <td runat="server" id="customRowContent" width="100%" colspan="2" class="ctrl" ></td>
			</tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
</table>

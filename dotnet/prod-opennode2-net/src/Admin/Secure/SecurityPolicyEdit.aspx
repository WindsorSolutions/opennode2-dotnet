<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SecurityPolicyEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.SecurityPolicyEdit" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="../Controls/SimpleCheckList.ascx" TagName="SimpleCheckList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecureContentHolder" runat="server">
    <div id="pageTitle">
        <%= SectionTitle %></div>
    <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
    </div>
    <asp:HiddenField ID="idCtrl" runat="server" />
    <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td class="label" align="right">
                <img alt="" src='../Images/page_user_dark.gif' style="border: 0; vertical-align: middle; padding-right: 3px;" />
                User:
            </td>
            <td class="ctrl" width="500" style="text-align: left">
                <%= DataItem.NaasAccount %>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right">
                Created by:
            </td>
            <td class="ctrl" width="500" style="text-align: left">
                <%= UserInfo.Owner %>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right">
                NAAS Role:
            </td>
            <td class="ctrl" width="500" style="text-align: left">
                <%= UserInfo.UserGroup %>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right">
                Affiliate:
            </td>
            <td class="ctrl" width="500" style="text-align: left">
                <%= UserInfo.Affiliate %>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right; vertical-align: top">
                Flows Access:
            </td>
            <td class="ctrl" width="500" style="text-align: left">
                <asp:Label runat="server" Font-Size="Smaller">Note: 'Allow' indicates that the user may access the associated flow.</asp:Label>
            </td>
        </tr>
        <tr>
            <uc1:SimpleCheckList ID="list" runat="server" />
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <input type="button" value="Cancel" class="button" onclick="location.href='../Secure/SecurityPolicy.aspx'" />
                <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SavePolicies" />
            </td>
        </tr>
    </table>
    <table id="Table1" width="100%" cellpadding="2" cellspacing="0">
    </table>
</asp:Content>

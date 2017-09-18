<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ConfigEndpointUserEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ConfigEndpointUserEdit"
    Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SecureContentHolder" runat="server">
    <div id="pageTitle">
        <%= SectionTitle %>
    </div>
    <div class="sectionHead">
        <%= SectionHeadline %>
    </div>
    <div class="introText">
        <asp:Repeater ID="introParagraphs" runat="server">
            <ItemTemplate>
                <p>
                    <%# Container.DataItem %>
                </p>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
    </div>
    <div runat="server" id="divPageNote" visible="false" class="note" enableviewstate="false">
    </div>
    <asp:HiddenField ID="idCtrl" runat="server" />
    <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td class="label" width="50" style="text-align: right; vertical-align: top">Username:</td>
            <td class="ctrl" width="750">
                <asp:DropDownList ID="usernameDropDownList" runat="server" CssClass="textbox"></asp:DropDownList>
                <asp:Label ID="usernameLabel" runat="server"></asp:Label>
                <asp:CustomValidator ID="usernameValidator" runat="server" ErrorMessage="Required" ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="usernameDropDownList" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right; vertical-align: top">Test NAAS Password:</td>
            <td class="ctrl">
                <uc3:PasswordTextBox ID="testNaasPasswordCtrl" runat="server" Text="" CssClass="textbox" TextMode="Password" Wrap="False" />
                <asp:CustomValidator ID="testPasswordCtrlValidator" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="Please enter a password." ValidateEmptyText="True" OnServerValidate="ServerValidateTestOrProdPassword" ControlToValidate="testNaasPasswordCtrl" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right; vertical-align: top">Prod NAAS Password:</td>
            <td class="ctrl">
                <uc3:PasswordTextBox ID="prodNaasPasswordCtrl" runat="server" Text="" CssClass="textbox" TextMode="Password" Wrap="False" />
                <asp:CustomValidator ID="prodPasswordCtrlValidator" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="Please enter a password." ValidateEmptyText="True" OnServerValidate="ServerValidateTestOrProdPassword" ControlToValidate="prodNaasPasswordCtrl" />
            </td>
        </tr>
        <tr>
            <td class="command" align="left">
                <asp:Button Text="Add Endpoint User" CssClass="button" runat="server" ID="addEndpointUserBtn" OnClick="OnAddEndpointUser" CausesValidation="false" />
            </td>
            <td class="command" colspan="100%" align="right">
                <asp:Button Text="Check Passwords" CssClass="button" runat="server" ID="checkPasswordsBtn" OnClick="OnCheckPasswords" CausesValidation="False" />
                <input type="button" value="Cancel" class="button" onclick="location.href = 'ConfigEndpointUser.aspx'" />
                <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SaveDataItem" />
                <asp:Button Text="Remove" CssClass="button" runat="server" ID="removeBtn" CausesValidation="false"
                    OnClientClick="return confirm('Are you sure you want to remove this endpoint user?');" OnClick="RemoveDataItem" />
            </td>
        </tr>
    </table>
</asp:Content>

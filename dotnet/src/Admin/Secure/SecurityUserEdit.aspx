<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SecurityUserEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.SecurityUserEdit" Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>

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
    <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false"/>
    <asp:HiddenField ID="idCtrl" runat="server" />
    <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td class="label" style="text-align: right; width: 186px; vertical-align: top" nowrap="nowrap">
                Username:
            </td>
            <td class="ctrl" width="750">
                <asp:TextBox ID="nameCtrl" runat="server" Text="" CssClass="textbox" />
                <asp:RequiredFieldValidator ID="idCtrlVal" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="Required" ControlToValidate="nameCtrl" EnableClientScript="false"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="nameCtrl" CssClass="error" Display="Dynamic" ErrorMessage="Invalid format, must be an email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" EnableClientScript="false"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr id="passwordCtrlRow" runat="server">
            <td class="label" style="text-align: right; width: 186px; vertical-align: top" nowrap="nowrap">
                Password:
            </td>
            <td class="ctrl" width="750">
                <uc3:PasswordTextBox ID="passwordCtrl" runat="server" Text="" CssClass="textbox" TextMode="Password" />
                <asp:RequiredFieldValidator ID="requiredFieldValidatorPassword" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="Required" ControlToValidate="passwordCtrl" EnableClientScript="false"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Passwords do not match" ValidateEmptyText="False" OnServerValidate="ServerValidatePasswordsMatch" ControlToValidate="passwordCtrl"/>
            </td>
        </tr>
        <tr id="confirmPasswordCtrlRow" runat="server">
            <td class="label" style="text-align: right; width: 186px; vertical-align: top" nowrap="nowrap">
                Confirm Password:
            </td>
            <td class="ctrl" width="750">
                <uc3:PasswordTextBox ID="confirmPasswordCtrl" runat="server" Text="" CssClass="textbox" TextMode="Password" />
                <asp:RequiredFieldValidator ID="requiredFieldValidatorConfirmPassword" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="Required" ControlToValidate="confirmPasswordCtrl" EnableClientScript="false"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr >
            <td class="label" style="text-align: right; width: 186px; vertical-align: top" nowrap="nowrap">
                <asp:Label ID="affiliateLabel" runat="server" Text="Affiliate:"/>
            </td>
            <td class="ctrl" width="750">
                <asp:Label ID="affiliateValue" runat="server" Text=""/>
            </td>
        </tr>
        <tr>
            <td class="label" style="text-align: right; width: 186px;">
                Role:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="roleCtrl" runat="server" CssClass="textbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label" style="text-align: right; width: 186px; vertical-align: top" nowrap="nowrap">
                Active:
            </td>
            <td class="ctrl">
                <asp:CheckBox ID="activeCtrl" runat="server" Text="Note: making this user inactive will prevent this user from accessing the Node Admin as well as the Node Service" Font-Size="Smaller" />
            </td>
        </tr>
        <tr>
            <td class="label" style="text-align: right; width: 186px; vertical-align: top" nowrap="nowrap">
                <asp:Label ID="IsDemoUserLabel" runat="server" Text="Demo User:"/>
            </td>
            <td class="ctrl">
                <asp:CheckBox ID="IsDemoUserCheckBox" runat="server" Text="Note: making this user a demo user will disable some functionality of the Node Admin for the user" Font-Size="Smaller" AutoPostBack="True" oncheckedchanged="IsDemoUserCheckBox_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <input type="button" value="Cancel" class="button" onclick="location.href='SecurityUser.aspx'" />
                <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SaveDataItem" />
                <asp:Button Text="Delete" CssClass="button" runat="server" ID="deleteBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this user?  In addition to deleting the user from this Node, the user account will also be deleted from NAAS.');" OnClick="DeleteDataItem" />
            </td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <asp:Button Text="Reset Password" CssClass="button" runat="server" ID="resetBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to reset password for this user?');" OnClick="ResetDataItem" />
                <asp:Button Text="Save and Manage Policies" CssClass="button" runat="server" ID="savePolicyBtn" OnClick="SaveDataItem" />
            </td>
        </tr>
    </table>
</asp:Content>

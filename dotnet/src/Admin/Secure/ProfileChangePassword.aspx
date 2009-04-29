<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ProfileChangePassword.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ProfileChangePassword" Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>
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
    
    <asp:HiddenField ID="idCtrl" runat="server" />
    <table id="formTable" width="600px" cellpadding="2" cellspacing="0">
        <tr>
            <td class="label" style="width: 143px" vertical-align:top" align="right">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/page_user_dark.gif"/>
                <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
            </td>
            <td class="cntl">
                <asp:Label ID="nameValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label" style="width: 143px; vertical-align:top" align="right">
                <asp:Label ID="Label2" runat="server" Text="Current Password:"></asp:Label>
            </td>
            <td class="cntl" nowrap="nowrap">
                <uc3:PasswordTextBox ID="currentPasswordValue" runat="server" Width="95%" TextMode="Password"/>
                <asp:RequiredFieldValidator ID="validator6" runat="server" EnableClientScript="false"
                        Display="Dynamic" ErrorMessage="Please enter a password" ControlToValidate="currentPasswordValue"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="label" style="width: 143px; vertical-align:top" align="right">
                <asp:Label ID="Label3" runat="server" Text="New Password:"></asp:Label>
            </td>
            <td class="cntl">
                <uc3:PasswordTextBox ID="newPasswordValue1" runat="server" Width="95%" TextMode="Password"/>
                <asp:RequiredFieldValidator ID="validator2" runat="server" EnableClientScript="false"
                        Display="Dynamic" ErrorMessage="Please enter a password" ControlToValidate="newPasswordValue1"></asp:RequiredFieldValidator>
                <asp:CustomValidator id="CustomValidator2" runat="server"
                    ErrorMessage="New passwords do not match"
                    ValidateEmptyText="False"
                    OnServerValidate="ServerValidateNewPasswordsMatch"
                    ControlToValidate="newPasswordValue1" />
            </td>
        </tr>
        <tr>
            <td class="label" style="width: 143px; vertical-align:top" align="right">
                <asp:Label ID="Label4" runat="server" Text="Confirm:"></asp:Label>
            </td>
            <td class="cntl">
                <uc3:PasswordTextBox ID="newPasswordValue2" runat="server" Width="95%" TextMode="Password"/>
                <asp:RequiredFieldValidator ID="validator3" runat="server" EnableClientScript="false"
                        Display="Dynamic" ErrorMessage="Please enter a password" ControlToValidate="newPasswordValue2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <input type="button" value="Cancel" class="button" onclick="location.href='Profile.aspx'" />
                <asp:Button Text="Change Password" CssClass="button" runat="server" Id="changePasswordBtn" OnClick="OnChangePassword"  />
            </td>
        </tr>
    </table>
</asp:Content>

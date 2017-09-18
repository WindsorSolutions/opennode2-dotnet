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
            <td class="label" style="width: 143px; vertical-align:top" align="right">
                <asp:Image ID="Image1" runat="server" ImageUrl="../Images/UI/user.png"/>
                <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
            </td>
            <td class="cntl">
                <asp:Label ID="nameValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label" style="width: 143px; vertical-align:top" align="right">
                <asp:Label ID="Label2" runat="server" Text="Current Password:"></asp:Label>
                <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" ControlToValidate="currentPasswordValue" OnServerValidate="ServerValidateCurrentPassword"></asp:CustomValidator>
            </td>
            <td class="cntl" nowrap="nowrap">
                <uc3:PasswordTextBox ID="currentPasswordValue" runat="server" Width="95%" TextMode="Password"/>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="label" style="vertical-align:middle; text-align:left; font-size:90%" align="left" valign="middle">
                <asp:BulletedList ID="BulletedList1" runat="server">
                    <asp:ListItem>A password must have at least 8 characters </asp:ListItem>
                    <asp:ListItem>A password must contain at least one uppercase character </asp:ListItem>
                    <asp:ListItem>A password must contain at least one numerical character (&#39;0&#39;-&#39;9&#39;) </asp:ListItem>
                    <asp:ListItem>A password must contain no more than 2 repetitive letters (i.e., aaa, ccc) </asp:ListItem>
                    <asp:ListItem>A password should not contain easily identifiable words </asp:ListItem>
                </asp:BulletedList>
            </td>
        </tr>
        <tr>
            <td class="label" style="width: 143px; vertical-align:top" align="right">
                <asp:Label ID="Label3" runat="server" Text="New Password:"></asp:Label>
                <asp:CustomValidator id="CustomValidator2" runat="server"
                    Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidateNewPassword1"
                    ControlToValidate="newPasswordValue1" />
            </td>
            <td class="cntl">
                <uc3:PasswordTextBox ID="newPasswordValue1" runat="server" Width="95%" TextMode="Password"/>
            </td>
        </tr>
        <tr>
            <td class="label" style="width: 143px; vertical-align:top" align="right">
                <asp:Label ID="Label4" runat="server" Text="Confirm New Password:"></asp:Label>
                <asp:CustomValidator id="CustomValidator3" runat="server"
                    Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidateNewPassword2"
                    ControlToValidate="newPasswordValue2" />
            </td>
            <td class="cntl">
                <uc3:PasswordTextBox ID="newPasswordValue2" runat="server" Width="95%" TextMode="Password"/>
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

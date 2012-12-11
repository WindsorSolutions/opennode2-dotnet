<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SecurityBulkAddUsers.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.SecurityBulkAddUsers" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="../Controls/SimpleCheckList.ascx" TagName="SimpleCheckList" TagPrefix="uc1" %>
<%@ Register Src="../Controls/UpdateProgressCntl.ascx" TagName="UpdateProgressCntl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecureContentHolder" runat="server">

    <script type="text/javascript">
        function RefreshNaasUsersUpdatePanel() {
            __doPostBack('<%= textNaasUserFilter.ClientID %>', '');
        };
    </script>

    <div id="pageTitle">
        <%= SectionTitle %>
    </div>
    <div class="sectionHead">
        <%= GetSectionHeadline() %>
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
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
            </div>
            <asp:HiddenField ID="idCtrl" runat="server" />
            <table id="formTable" width="700px" cellpadding="1" cellspacing="0" style="padding-right: 4px">
                <tr id="addUsersEditCtrlRow" runat="server">
                    <td class="label" style="width: 20%; text-align: right; vertical-align: top; white-space: nowrap">
                        <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Images/UI/user.png" Style="padding-right: 4px" />
                        Add Users:
                        <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidateUsernames" ControlToValidate="nameCtrl" />
                    </td>
                    <td class="ctrl" style="width: 40%; vertical-align: top">
                        <asp:TextBox ID="nameCtrl" runat="server" Text="" CssClass="textbox" Height="130px" TextMode="MultiLine" />
                    </td>
                    <td class="ctrl" style="width: 40%; vertical-align: middle" valign="middle">
                        <asp:Panel ID="Panel1" runat="server" GroupingText="&nbsp;Username Lookup" Font-Size="90%" BackColor="#DCDCDC">
                            <div style="margin: 4px; margin-left: 8px; margin-right: 8px">
                                <asp:TextBox ID="textNaasUserFilter" runat="server" Width="98%" Style="border-color: #555555; border-width: 1px; margin-bottom: 4px; color: #555555; font-size: 90%" onkeyup="RefreshNaasUsersUpdatePanel();" OnTextChanged="textNaasUserFilter_TextChanged" onfocus="ON2SetTextBoxPositionToEnd(this)"></asp:TextBox>
                                <asp:ListBox ID="listNaasUsers" runat="server" Rows="5" SelectionMode="Multiple" Width="100%" Style="border-color: #555555; color: #555555; font-size: 90%" AutoPostBack="True" OnSelectedIndexChanged="listNaasUsers_SelectedIndexChanged" />
                                <asp:LinkButton ID="addSelectedUsers" runat="server" Style="font-size: 90%; text-decoration: underline" CausesValidation="false" OnClick="addSelectedUsers_Click"><< Add Selected Users</asp:LinkButton>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr id="createUsersInNaasEditCtrlRow" runat="server">
                    <td class="label" style="text-align: right; vertical-align: top; white-space: nowrap">
                        Create Users In NAAS:
                    </td>
                    <td class="ctrl" colspan="2">
                        <asp:CheckBox ID="createInNaasCheckBox" runat="server" Text=" Note: If checked and users do not exist in NAAS, create them.  If not checked and users do not exist in NAAS, they will not be added to the node." Font-Italic="true" Font-Size="Smaller" Checked="true" AutoPostBack="True" OnCheckedChanged="createInNaasCheckBox_CheckedChanged" />
                    </td>
                </tr>
                <tr id="passwordCtrlRow" runat="server">
                    <td class="label" style="text-align: right; vertical-align: bottom; white-space: nowrap">
                        Password:
                        <asp:CustomValidator ID="passwordCtrlValidator" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidatePassword" ControlToValidate="passwordCtrl" />
                    </td>
                    <td class="ctrl" style="vertical-align: bottom">
                        <uc3:PasswordTextBox ID="passwordCtrl" runat="server" Text="" CssClass="textbox" TextMode="Password" Wrap="False" />
                    </td>
                    <td class="ctrl" style="vertical-align: middle;" valign="middle" rowspan="2">
                        <asp:Panel ID="Panel2" runat="server" GroupingText="&nbsp;A password must:" Font-Size="90%" BackColor="#DCDCDC">
                            <div style="margin: 4px; margin-left: 8px; margin-right: 8px; font-size: 90%; color: #555555">
                                &bull;&nbsp;have at least 8 characters<br />
                                &bull;&nbsp;contain at least one uppercase character<br />
                                &bull;&nbsp;contain at least one numerical character (&#39;0&#39;-&#39;9&#39;)<br />
                                &bull;&nbsp;contain no more than 2 repetitive letters (i.e., aaa, ccc)<br />
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr id="confirmPasswordCtrlRow" runat="server">
                    <td class="label" style="text-align: right; vertical-align: top; white-space: nowrap">
                        Confirm Password:
                        <asp:CustomValidator ID="confirmPasswordCtrlValidator" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidateConfirmPassword" ControlToValidate="confirmPasswordCtrl" />
                    </td>
                    <td class="ctrl" style="vertical-align: top;">
                        <uc3:PasswordTextBox ID="confirmPasswordCtrl" runat="server" Text="" CssClass="textbox" TextMode="Password" Wrap="False" />
                    </td>
                </tr>
                <tr id="usernameCtrlRow" runat="server">
                    <td class="label" style="width: 20%; text-align: right; vertical-align: top; white-space: nowrap">
                        <asp:Image ID="Image2" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Images/UI/user.png" Style="padding-right: 4px" />
                        Username:
                    </td>
                    <td class="ctrl" style="width: 80%;">
                        <asp:Label ID="nameValue" runat="server" />
                    </td>
                </tr>
                <tr id="affiliateCtrlRow" runat="server">
                    <td class="label" style="text-align: right; vertical-align: top; white-space: nowrap">
                        Affiliate:
                    </td>
                    <td align="left" style="white-space: nowrap" colspan="2">
                        <asp:Label ID="affiliateValue" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="text-align: right; width: 20%; vertical-align: top; white-space: nowrap">
                        Active:
                    </td>
                    <td class="ctrl" colspan="2">
                        <asp:CheckBox ID="activeCtrl" runat="server" Style="width: 80%" Text=" Note: Making users inactive will prevent them from accessing both the node Administration Utility and the node Endpoints." Font-Italic="true" Font-Size="Smaller" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="text-align: right; vertical-align: top; white-space: nowrap">
                        Role:
                    </td>
                    <td class="ctrl" colspan="2">
                        <asp:DropDownList ID="roleCtrl" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="roleCtrl_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="exchangeAccessCtrlRow" runat="server">
                    <td class="label" style="text-align: right; vertical-align: top; white-space: nowrap">
                        Exchange Access:
                    </td>
                    <td class="ctrl" colspan="2">
                        <table id="flowsTable" width="100%" cellpadding="3" cellspacing="0" style="border-width: 1px; border-color: #555555; border-style: solid">
                            <asp:Repeater runat="server" ID="flowRepeaterList" OnItemDataBound="flowRepeaterList_ItemDataBound">
                                <ItemTemplate>
                                    <tr class='<%# Container.ItemIndex % 2 == 0 ? "rowEven" : "rowOdd" %>'>
                                        <td width="20px" style="padding-left: 4px;">
                                            <img alt="" src="../Images/UI/globe-network.png" style="border: 0; vertical-align: middle; padding-right: 3px;" />
                                        </td>
                                        <td style="white-space: nowrap">
                                            <asp:Label ID="FlowName" runat="server" Text='<%# GetFlowName((string)Eval("FlowName"), (bool)Eval("IsProtected"))%>' Font-Bold="True" />
                                            <asp:Label ID="FlowCode" runat="server" Text='<%# Eval("FlowName")%>' Visible="false" />
                                        </td>
                                        <td align="right" style="white-space: nowrap;">
                                            <asp:Label ID="flowRoleAccessLabel" runat="server" Text="Access: " />
                                        </td>
                                        <td width="150px" align="left" style="white-space: nowrap; padding-left: 6px;">
                                            <asp:HiddenField ID="flowIsProtected" runat="server" Value="False" />
                                            <asp:Label ID="flowRoleLabel" runat="server" />
                                            <asp:DropDownList ID="flowRoleCtrl" runat="server" Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
                <tr id="exchangeAccessLabelRow" runat="server">
                    <td class="label" style="text-align: right; vertical-align: top; white-space: nowrap">
                        Exchange Access:
                    </td>
                    <td class="ctrl" colspan="2" style="font-size: smaller; font-style: italic; vertical-align: middle">
                        Note: Administrators have full access to all flows.
                    </td>
                </tr>
                <tr>
                    <td class="command" colspan="1" align="left">
                        <asp:Button Text="Reset Password" CssClass="button" runat="server" ID="resetPasswordBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to reset this user\'s password?\n\nClicking OK will reset the user\'s password to a randomly generated value, and the user will be sent an email with the new password.');" OnClick="OnResetPassword" />
                    </td>
                    <td class="command" colspan="2" align="right">
                        <input type="button" value="Cancel" class="button" onclick="location.href='SecurityUser.aspx'" />
                        <asp:Button Text="Add Users" CssClass="button" runat="server" ID="addUsersBtn" OnClick="OnAddUsers" />
                        <asp:Button Text="Save" CssClass="button" runat="server" ID="saveUserBtn" OnClick="OnSaveUser" />
                        <asp:Button Text="Delete" CssClass="button" runat="server" ID="deleteUserBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this user?\n\nIn addition to deleting the user from this Node, the user account will also be deleted from NAAS.');" OnClick="OnDeleteUser" />
                        <asp:Button Text="Remove" CssClass="button" runat="server" ID="removeUserBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to remove this user from the node?');" OnClick="OnRemoveUser" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:UpdateProgressCntl ID="UpdateProgressCntl" runat="server" />
</asp:Content>

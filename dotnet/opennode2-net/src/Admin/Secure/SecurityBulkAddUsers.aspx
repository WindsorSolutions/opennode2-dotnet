<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SecurityBulkAddUsers.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.SecurityBulkAddUsers" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="../Controls/SimpleCheckList.ascx" TagName="SimpleCheckList" TagPrefix="uc1" %>
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
    <table id="formTable" width="100%" cellpadding="1" cellspacing="0">
        <tr>
            <td class="label" style="text-align: right; width: 166px; vertical-align: top; height: 83px;" nowrap="nowrap">
                Usernames:
                <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidateUsernames" ControlToValidate="nameCtrl" />
            </td>
            <td class="ctrl" width="750" style="height: 83px">
                <asp:TextBox ID="nameCtrl" runat="server" Text="" CssClass="textbox" Height="94px" TextMode="MultiLine" />
            </td>
        </tr>
        <tr id="passwordCtrlRow" runat="server">
            <td class="label" style="text-align: right; width: 166px; vertical-align: middle" nowrap="nowrap">
                Password:
                <asp:CustomValidator ID="CustomValidator3" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidatePassword" ControlToValidate="passwordCtrl" />
            </td>
            <td class="ctrl" width="750">
                <uc3:PasswordTextBox ID="passwordCtrl" runat="server" Text="" CssClass="textbox" TextMode="Password" Wrap="False" />
            </td>
        </tr>
        <tr id="confirmPasswordCtrlRow" runat="server">
            <td class="label" style="text-align: right; width: 166px; vertical-align: middle" nowrap="nowrap">
                Confirm Password:
                <asp:CustomValidator ID="CustomValidator2" runat="server" Display="Dynamic" CssClass="error" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidateConfirmPassword" ControlToValidate="confirmPasswordCtrl" />
            </td>
            <td class="ctrl" width="750">
                <uc3:PasswordTextBox ID="confirmPasswordCtrl" runat="server" Text="" CssClass="textbox" TextMode="Password" Wrap="False" />
            </td>
        </tr>
        <tr>
            <td class="label" style="text-align: right; width: 166px; vertical-align: middle" nowrap="nowrap">
                Create In NAAS:
            </td>
            <td align="left" nowrap="nowrap">
                <asp:CheckBox ID="createInNaasCheckBox" runat="server" Text="If users do not exist in NAAS, create them" />
            </td>
        </tr>
        <tr>
            <td class="label" style="text-align: right; width: 166px; vertical-align: middle" nowrap="nowrap">
                Role:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="roleCtrl" runat="server" CssClass="textbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label" style="text-align: right; width: 166px; vertical-align: top" nowrap="nowrap">
                Secure Flows Access:
            </td>
            <td class="ctrl">
                <table id="Table1" width="100%" cellpadding="0" cellspacing="0" style="border-width: thin; border-color: #dcdcdc; border-style: solid">
                    <asp:Repeater runat="server" ID="flowRepeaterList">
                        <ItemTemplate>
                            <tr class="rowOdd">
                                <td width="20">
                                    <img alt="" src="../Images/Flow2.gif" style="border: 0; vertical-align: middle; padding-right: 3px;" />
                                </td>
                                <td align="left">
                                    <a href="" class="listlabel"><strong>
                                        <%# Eval("FlowName")%></strong> </a>
                                </td>
                                <td width="*" align="right">
                                    <%# Eval("Description")%>
                                </td>
                                <td align="right" nowrap="nowrap">
                                    <asp:CheckBox ID="checkBox" runat="server" />
                                    <asp:Label ID="flowId" runat="server" Visible="false" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="rowEven">
                                <td width="20">
                                    <img alt="" src="../Images/Flow2.gif" style="border: 0; vertical-align: middle; padding-right: 3px;" />
                                </td>
                                <td align="left">
                                    <a href="" class="listlabel"><strong>
                                        <%# Eval("FlowName")%></strong> </a>
                                </td>
                                <td width="*" align="right">
                                    <%# Eval("Description")%>
                                </td>
                                <td align="right" nowrap="nowrap">
                                    <asp:CheckBox ID="checkBox" runat="server" />
                                    <asp:Label ID="flowId" runat="server" Visible="false" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <input type="button" value="Cancel" class="button" onclick="location.href='SecurityUser.aspx'" />
                <asp:Button Text="Add Users" CssClass="button" runat="server" ID="addUsersBtn" OnClick="OnAddUsers" />
            </td>
        </tr>
    </table>
</asp:Content>

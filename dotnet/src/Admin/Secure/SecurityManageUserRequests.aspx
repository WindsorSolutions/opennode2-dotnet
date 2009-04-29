<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SecurityManageUserRequests.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.SecurityManageUserRequests" Title="Manage User Requests" MaintainScrollPositionOnPostback="true" %>

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
    <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false" />
    <asp:HiddenField ID="idCtrl" runat="server" />
    <table id="wrapperTable" width="640px" cellpadding="2" cellspacing="0" class="basicTable">
        <asp:Repeater runat="server" ID="userRepeaterList" OnItemDataBound="userRepeaterList_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td colspan="100%">
                        <div runat="server" id="itemDivPageError" visible="false" class="error" enableviewstate="false" />
                    </td>
                </tr>
                <tr style="background-color: #83ACCA; height: 21px">
                    <td width="20">
                        <img alt="" src='..\Images\page_user_dark.gif' style="border: 0; vertical-align: middle; padding-right: 3px;" />
                    </td>
                    <td width="100%" style="color: White; font-weight: bold;">
                        <%#UserDisplayName(Container.DataItem)%>
                    </td>
                    <td align="right" nowrap="nowrap" style="color: White;">
                        <%#RequestDateDisplayName(Container.DataItem)%>
                    </td>
                </tr>
                <tr>
                    <td />
                    <td colspan="2">
                        <table id="formTable" width="100%" cellpadding="2" cellspacing="0" class="basicTable">
                            <tr>
                                <td class="labelplain">
                                    Affiliated State:
                                </td>
                                <td class="controlplain">
                                    <%#Eval("AffiliatedNodeId")%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelplain">
                                    Organization:
                                </td>
                                <td class="controlplain">
                                    <%#Eval("OrganizationAffiliation")%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelplain">
                                    Contact Email:
                                </td>
                                <td class="controlplain">
                                    <%#Eval("EmailAddress")%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelplain">
                                    Contact Phone #:
                                </td>
                                <td class="controlplain">
                                    <%#Eval("TelephoneNumber")%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelplain">
                                    Request Purpose:
                                </td>
                                <td class="controlplain">
                                    <%#Eval("PurposeDescription")%>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelplain" style="vertical-align: top">
                                    Requested Flows:
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="noFlowsLabel" CssClass="controlplain" Visible="false" Text="NONE" />
                                    <table id="formTable" width="100%" cellpadding="1" cellspacing="0">
                                        <asp:Repeater runat="server" ID="flowRepeaterList">
                                            <ItemTemplate>
                                                <tr class='<%# Container.ItemIndex % 2 == 0 ? "rowOdd" : "rowEven" %>'>
                                                    <td width="20">
                                                        <img alt="" src="../Images/Flow2.gif" style="border: 0; vertical-align: middle; padding-right: 3px;" />
                                                    </td>
                                                    <td class="controlplain" nowrap="nowrap">
                                                        <%#FlowDisplayName(Container.DataItem)%>
                                                    </td>
                                                    <td class="controlplain" nowrap="nowrap" style="text-align: right">
                                                        <asp:CheckBox ID="allowCheckBox" runat="server" Text="Allow" />
                                                        <asp:Label ID="allowCheckTag" runat="server" Visible="false" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelplain">
                                    Comments:
                                </td>
                                <td class="controlplain">
                                    <asp:TextBox ID="commentsTextBox" Width="98%" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="padding-top: 0px">
                                <td colspan="100%" align="right" style="padding: 0px">
                                    <asp:Button Text="Accept" CssClass="button" runat="server" ID="acceptServiceBtn" Height="25px" OnCommand="OnAcceptClick" CommandArgument='<%#Eval("Id")%>' />
                                    <asp:Button Text="Reject" CssClass="button" runat="server" ID="rejectServiceBtn" Height="25px" OnCommand="OnDenyClick" CommandArgument='<%#Eval("Id")%>' />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

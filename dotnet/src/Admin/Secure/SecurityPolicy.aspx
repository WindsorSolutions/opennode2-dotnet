<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SecurityPolicy.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.SecurityPolicy" Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>

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
    <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td width="10" align="center">
                <img alt="" src="../Images/page_user_dark.gif" style="border: 0; vertical-align: middle; padding-right: 3px; float: right;" />
            </td>
            <td class="ctrl" width="98%">
                <asp:DropDownList runat="server" ID="listNaasUsers" AutoPostBack="True" OnSelectedIndexChanged="GetUser" Width="98%">
                </asp:DropDownList>
            </td>
            <td width="10" align="center">
                <asp:ImageButton ImageUrl="../Images/refresh.png" AlternateText="Refresh accounts from NAAS" BorderWidth="0" ImageAlign="AbsMiddle" runat="server" ID="refreshUsersBtn" OnClick="RefreshList" />
            </td>
        </tr>
    </table>
</asp:Content>

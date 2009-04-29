<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.Profile" Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>
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
    <table id="formTable" width="500px" cellpadding="2" cellspacing="0">
        <tr>
            <td class="label">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/page_user_dark.gif"/>
                <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
            </td>
            <td class="cntl">
                <asp:Label ID="nameValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="Label2" runat="server" Text="System Role:"></asp:Label>
            </td>
            <td class="cntl">
                <asp:Label ID="systemRoleValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="Label3" runat="server" Text="Active:"></asp:Label>
            </td>
            <td class="cntl">
                <asp:Label ID="activeValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="Label4" runat="server" Text="Last Modified By:"></asp:Label>
            </td>
            <td class="cntl">
                <asp:Label ID="lastModifiedByValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="Label5" runat="server" Text="Last Modified On:"></asp:Label>
            </td>
            <td class="cntl">
                <asp:Label ID="lastModifiedOnValue" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

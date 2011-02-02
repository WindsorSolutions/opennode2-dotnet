<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SecurityPolicy.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.SecurityPolicy" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="aspajax" %>
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
            <td class="label">
                NAAS Name Filter:
            </td>
            <td class="ctrl">
                <asp:TextBox ID="textNaasUserFilter" runat="server" onkeyup="RefreshNaasUsersUpdatePanel();" ontextchanged="textNaasUserFilter_TextChanged" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td/>
            <td class="ctrl" width="100%">
                <aspajax:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="listNaasUsers" runat="server" Rows="16" SelectionMode="Single" Width="100%" style="border-color:#3D7BAD"/>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="textNaasUserFilter" />
<aspajax:AsyncPostBackTrigger ControlID="textNaasUserFilter"></aspajax:AsyncPostBackTrigger>
                    </Triggers>
                </aspajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <asp:Button Text="Select" CssClass="button" runat="server" ID="selectBtn" onclick="selectBtn_Click" />
                <asp:Button Text="Refresh Users" CssClass="button" runat="server" ID="refreshUsersBtn" CausesValidation="false" OnClick="RefreshList" OnClientClick="return confirm('Are you sure you want to refresh the NAAS user list? This process may take a few minutes to complete.');"/>
            </td>
        </tr>
    </table>
</asp:Content>

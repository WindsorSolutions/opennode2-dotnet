<%@ Page Language="C#" MasterPageFile="~/AnonMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Windsor.Node2008.Admin.Error" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AnonContentHolder" runat="server">
    <table width="100%" >
        <tr>
            <td>
            <asp:Label ID="Label2" runat="server" Font-Size="Medium" Height="24px" Text="An unexpected error occured in the application:" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="MessageBox" runat="server" Font-Size="Small" Height="100%"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

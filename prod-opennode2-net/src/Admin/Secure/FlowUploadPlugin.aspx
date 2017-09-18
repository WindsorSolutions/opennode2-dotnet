<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlowUploadPlugin.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.FlowUploadPlugin" Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>

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
            <td class="label" style="width: 2px; white-space:nowrap; vertical-align:top">
                Plugin:
            </td>
            <td class="ctrl">
                <asp:FileUpload ID="fileUpload" runat="server" Width="100%"  />
                <asp:CustomValidator ID="fileUploadValidator" runat="server" ErrorMessage="Please choose a plugin file" ValidateEmptyText="True" OnServerValidate="ServerValidateFileUpload" ControlToValidate="fileUpload" />
            </td>
        </tr>
        <tr>
            <td class="label" style="width: 2px">
                Exchange:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="flowDropDownList" runat="server" Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <asp:Button Text="Cancel" CssClass="button" runat="server" OnClick="CancelItem" CausesValidation="false" />
                <asp:Button Text="Upload" CssClass="button" runat="server" ID="saveBtn" OnClick="UploadPlugin" />
            </td>
        </tr>
    </table>
</asp:Content>

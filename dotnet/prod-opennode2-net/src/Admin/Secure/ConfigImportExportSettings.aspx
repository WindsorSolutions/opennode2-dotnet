<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ConfigImportExportSettings.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ConfigImportExportSettings" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/UpdateProgressCntl.ascx" TagName="UpdateProgressCntl" TagPrefix="uc1" %>
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
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
            </div>
            <div runat="server" id="divPageNote" visible="false" class="note" enableviewstate="false">
            </div>
            <table id="formTable" width="600px" cellpadding="2" cellspacing="0" style="border-style: none">
                <tr style="background-color: #83ACCA">
                    <td colspan="2" style="white-space: nowrap; color: White; font-weight: bold;">
                        <img alt="" src='../Images/UI/application-dock.png' style="border: 0; vertical-align: middle; padding-top: 2px; padding-bottom: 2px; padding-right: 3px; padding-left: 3px;" />
                        Import Settings
                    </td>
                </tr>
                <tr>
                    <td class="label" style="width: 20px; white-space: nowrap; vertical-align: middle">
                        Import Settings File:
                        <asp:CustomValidator ID="fileUploadValidator" runat="server" ErrorMessage="*" ValidateEmptyText="True" OnServerValidate="ServerValidateImportFileUpload" Display="Dynamic" />
                    </td>
                    <td class="ctrl" style="vertical-align: middle;">
                        <asp:FileUpload ID="fileUpload" runat="server" Width="100%" />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top">
                        Import Action:
                    </td>
                    <td class="ctrl" style="vertical-align: top;">
                        <asp:DropDownList ID="importActionDropDown" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top;">
                        Settings To Import:
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="*" OnServerValidate="ServerValidateImportSettings" Display="Dynamic" />
                    </td>
                    <td class="ctrl" style="vertical-align: top;">
                        <asp:DropDownList ID="importSettingsTypeDropDown" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="importSettingsTypeDropDown_SelectedIndexChanged" CausesValidation="false">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top; padding-top: 8px">
                    </td>
                    <td class="ctrl" style="vertical-align: middle;">
                        <asp:CheckBoxList ID="importSettingsCheckBoxList" Width="100%" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button Text="Import" CssClass="button" Height="24px" Width="80px" runat="server" ID="importBtn" OnCommand="OnImport" />
                    </td>
                </tr>
                <tr style="background-color: #FFFFFF">
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr style="background-color: #83ACCA">
                    <td colspan="2" style="white-space: nowrap; color: White; font-weight: bold;">
                        <img alt="" src='../Images/UI/application-dock-180.png' style="border: 0; vertical-align: middle; padding-top: 2px; padding-bottom: 2px; padding-right: 3px; padding-left: 3px;" />
                        Export Settings
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top;">
                        Settings To Export:
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="*" OnServerValidate="ServerValidateExportSettings" Display="Dynamic" />
                    </td>
                    <td class="ctrl" style="vertical-align: top;">
                        <asp:DropDownList ID="exportSettingsTypeDropDown" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="exportSettingsTypeDropDown_SelectedIndexChanged" CausesValidation="false">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top; padding-top: 8px">
                    </td>
                    <td class="ctrl" style="vertical-align: middle;">
                        <asp:CheckBoxList ID="exportSettingsCheckBoxList" Width="100%" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button Text="Export" CssClass="button" Height="24px" Width="80px" runat="server" ID="exportBtn" OnCommand="OnExport" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="exportBtn" />
            <asp:PostBackTrigger ControlID="importBtn" />
        </Triggers>
    </asp:UpdatePanel>
    <uc1:updateprogresscntl id="UpdateProgressCntl" runat="server" />
</asp:Content>

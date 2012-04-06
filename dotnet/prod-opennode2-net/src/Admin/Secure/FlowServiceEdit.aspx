<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlowServiceEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.FlowServiceEdit" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

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
            <asp:HiddenField ID="idCtrl" runat="server" />
            <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top">
                        <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Images/UI/globe-network.png" Style="padding-right: 3px" />Exchange:
                    </td>
                    <td class="ctrl" style="vertical-align: top">
                        <asp:Label ID="flowNameLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top">
                        Name:
                    </td>
                    <td class="ctrl" style="width: 100%; vertical-align: top">
                        <asp:TextBox ID="nameEdit" runat="server" Text="" Width="500px" />
                        <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="Required" ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="nameEdit" />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top">
                        Implementer:
                    </td>
                    <td class="ctrl" style="vertical-align: top">
                        <asp:DropDownList ID="implementerDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="implementerDropDownList_SelectedIndexChanged" Width="500px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top">
                        Type:
                    </td>
                    <td class="ctrl" style="vertical-align: top">
                        <asp:DropDownList ID="typeDropDownList" runat="server" Width="500px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="label" style="white-space: nowrap; vertical-align: top">
                        Active:
                    </td>
                    <td class="ctrl" style="vertical-align: top">
                        <asp:CheckBox ID="activeCheckBox" runat="server" Text="Note: Making this service inactive will prevent it from being accessible using the Web Service interface." Font-Italic="true" Font-Size="Smaller" CausesValidation="false" />
                    </td>
                </tr>
                <tr id="argumentsTableRow" runat="server">
                    <td class="label" style="white-space: nowrap; vertical-align: top">
                        Arguments:
                    </td>
                    <td class="ctrl" style="vertical-align: top">
                        <table id="argsTable" width="95%" cellpadding="0" cellspacing="0">
                            <asp:Repeater ID="argsRepeater" runat="server" OnItemDataBound="argsRepeater_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 100%; vertical-align: middle">
                                            <asp:Label ID="keyValueLabel" runat="server" Width="100%" Font-Bold="True" Font-Size="X-Small" Text='<%# Eval("Key")%>' Enabled='<%# !DisableRepeaterEditing() %>' />
                                        </td>
                                        <td align="right" style="white-space: nowrap; vertical-align: middle" valign="middle">
                                            <asp:CheckBox ID="globalValueCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="OnGlobalValueCheckBoxChanged" TextAlign="Left" Text="Use global value " Font-Size="X-Small" CausesValidation="false" Style="vertical-align: middle" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="width: 100%; vertical-align: middle; padding-bottom:12px">
                                            <asp:DropDownList ID="argGlobalValueDropDownList" runat="server" Width="100%" />
                                            <asp:TextBox ID="argValueEdit" runat="server" Text="" Width="100%" />
                                            <asp:CustomValidator ID="CustomValidator11" runat="server" ErrorMessage="Required" OnServerValidate="ServerValidateGlobalValue" ControlToValidate="argGlobalValueDropDownList" Display="Dynamic" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
                <tr id="dataSourcesTableRow" runat="server">
                    <td class="label" style="white-space: nowrap; vertical-align: top">
                        Data Sources:
                    </td>
                    <td class="ctrl" style="vertical-align: top">
                        <table id="dataSourcesTable" width="95%" cellpadding="0" cellspacing="0">
                            <asp:Repeater ID="dataSourcesRepeater" runat="server" OnItemDataBound="dataSources_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 100%; vertical-align: middle">
                                            <asp:Label ID="dsKeyValueLabel" runat="server" Width="100%" Font-Bold="True" Font-Size="X-Small" Text='<%# Eval("Key")%>' Enabled='<%# !DisableRepeaterEditing() %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; vertical-align: middle; padding-bottom:12px">
                                            <asp:DropDownList ID="dataSourcesDropDownList" runat="server" Width="100%" />
                                            <asp:CustomValidator ID="CustomValidator10" runat="server" ErrorMessage="Required" OnServerValidate="ServerValidateDataSource" ControlToValidate="dataSourcesDropDownList" Display="Dynamic" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="command" colspan="2" align="right">
                        <asp:Button Text="Cancel" CssClass="button" runat="server" ID="cancelBtn" OnClick="CancelItem" CausesValidation="false" />
                        <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SaveDataItem" />
                        <asp:Button Text="Delete" CssClass="button" runat="server" ID="deleteBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this service?');" OnClick="DeleteDataItem" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:UpdateProgressCntl ID="UpdateProgressCntl" runat="server" />
</asp:Content>

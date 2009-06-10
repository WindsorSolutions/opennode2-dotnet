<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlowServiceEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.FlowServiceEdit" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

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
            <td class="label" width="50">
                <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="..\Images\Flow2.gif" style="padding-right: 3px" />Exchange:
            </td>
            <td id="flowNameLabel" class="ctrl" runat="server">
            </td>
        </tr>
        <tr>
            <td class="label" style="vertical-align:top" width="50">
                Name:
            </td>
            <td class="ctrl" width="100%">
                <asp:TextBox ID="nameEdit" runat="server" Text="" Width="500px" />
                <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="Required" ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="nameEdit" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50">
                Implementer:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="implementerDropDownList" runat="server" AutoPostBack="True" Font-Size="X-Small" OnSelectedIndexChanged="implementerDropDownList_SelectedIndexChanged" Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label" width="50">
                Type:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="typeDropDownList" runat="server" Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
<%--        <tr>
            <td class="label" width="50">
                Publish For:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="publishDropDownList" runat="server" Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
--%>        <tr>
            <td class="label" width="50" style="vertical-align: top">
                Active:
            </td>
            <td class="ctrl">
                <asp:CheckBox ID="activeCheckBox" runat="server" Text="Note: Making this service inactive will prevent it from being accessible using the Web Service interface." Font-Size="Smaller" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="vertical-align: top">
                Arguments:
            </td>
            <td class="ctrl">
                <table id="argsTable" width="95%" cellpadding="2" cellspacing="0">
                    <asp:Repeater ID="argsRepeater" runat="server" OnItemDataBound="argsRepeater_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Key:" Width="32px"></asp:Label>
                                    <asp:Label ID="keyValueLabel" runat="server" Width="250px" Font-Bold="True" Text='<%# Eval("Key")%>'/>
                                </td>
                                <td align="right" nowrap="nowrap">
                                    <asp:CheckBox ID="globalValueCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="OnGlobalValueCheckBoxChanged" TextAlign="Left" Text="Use global value " Font-Size="X-Small" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="100%">
                                    <asp:DropDownList ID="argGlobalValueDropDownList" runat="server" Width="500px" />
                                    <asp:TextBox ID="argValueEdit" runat="server" Text="" Width="500px" />
                                    <asp:CustomValidator ID="CustomValidator11" runat="server" ErrorMessage="Required" OnServerValidate="ServerValidateGlobalValue" ControlToValidate="argGlobalValueDropDownList" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="vertical-align: top">
                Data Sources:
            </td>
            <td class="ctrl">
                <table id="dataSourcesTable" width="95%" cellpadding="2" cellspacing="0">
                    <asp:Repeater ID="dataSourcesRepeater" runat="server" OnItemDataBound="dataSources_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Key:" Width="32px"></asp:Label>
                                    <asp:Label ID="dsKeyValueLabel" runat="server" Width="250px" Font-Bold="True" Text='<%# Eval("Key")%>'/>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="100%">
                                    <asp:DropDownList ID="dataSourcesDropDownList" runat="server" Width="500px" />
                                    <asp:CustomValidator ID="CustomValidator10" runat="server" ErrorMessage="Required" OnServerValidate="ServerValidateDataSource" ControlToValidate="dataSourcesDropDownList" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <asp:Button Text="Cancel" CssClass="button" runat="server" OnClick="CancelItem" CausesValidation="false" />
                <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SaveDataItem" />
                <asp:Button Text="Delete" CssClass="button" runat="server" ID="deleteBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this service?');" OnClick="DeleteDataItem" />
            </td>
        </tr>
    </table>
</asp:Content>

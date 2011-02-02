<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ConfigDsEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ConfigDsEdit" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

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
    <div runat="server" id="divPageNote" visible="false" class="note" enableviewstate="false">
    </div>
    <asp:HiddenField ID="idCtrl" runat="server" />
    <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td class="label" width="50" style="text-align: right; vertical-align: top">
                Name:
            </td>
            <td class="ctrl" width="750">
                <asp:TextBox ID="codeCtrl" runat="server" Text="" CssClass="textbox" />
                <asp:CustomValidator ID="nameValidator" runat="server" ErrorMessage="Required" ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="codeCtrl" EnableClientScript="False" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right">
                Provider:
            </td>
            <td class="ctrl" width="750">
                <asp:DropDownList ID="providerCtrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right; vertical-align: top">
                Connection:
            </td>
            <td class="ctrl">
                <asp:TextBox ID="connectionCtrl" CssClass="textbox" Rows="8" Columns="53" runat="server" Height="80px" Text="" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="Required" ControlToValidate="connectionCtrl" EnableClientScript="False"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="command" align="left">
                <asp:Button Text="Add Data Source" CssClass="button" runat="server" ID="addDataSourceBtn" OnClick="OnAddDataSource" CausesValidation="false" />
            </td>
            <td class="command" colspan="100%" align="right">
                <asp:Button Text="Check Connection" CssClass="button" runat="server" ID="checkConnectionBtn" OnClick="OnCheckConnection" CausesValidation="False" />
                <input type="button" value="Cancel" class="button" onclick="location.href='ConfigDs.aspx'" />
                <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SaveDataItem" />
                <asp:Button Text="Delete" CssClass="button" runat="server" ID="deleteBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this data source item?');" OnClick="DeleteDataItem" />
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FlowEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.FlowEdit" Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>

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
        <tr style="vertical-align:middle">
            <td class="label" width="50" nowrap="nowrap">
                <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="..\Images\Flow2.gif" style="padding-right: 3px"/>Name:
            </td>
            <td class="ctrl" width="100%">
                <asp:TextBox ID="nameEdit" runat="server" Text="" Width="500px" style="vertical-align:middle"/>
                <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="Required" ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="nameEdit"/>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" nowrap="nowrap">
                Description:</td>
            <td class="ctrl" width="100%">
                <asp:TextBox ID="descriptionTextBox" runat="server" Text="" Width="500px" Height="43px" TextMode="MultiLine" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50">
                Contact:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="contactsDropDownList" runat="server" Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label" width="50">
                Web Info:
            </td>
            <td class="ctrl">
                <asp:TextBox ID="webInfoTextBox" runat="server" Text="" Width="500px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="false" Display="Dynamic" ErrorMessage="Please enter a url" ControlToValidate="webInfoTextBox"/>
                <asp:RegularExpressionValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="false" Display="Dynamic" ErrorMessage="Please enter a valid url" ControlToValidate="webInfoTextBox" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"/>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="vertical-align:top">
                Protected:
            </td>
            <td class="ctrl">
                <asp:CheckBox ID="protectedCheckBox" runat="server" Text="Note: 'Protected' indicates that any access to this flow requires a policy.  Otherwise, only a valid, authenticated token is required to access the flow. (Query, Solicit, Download, etc.)" Font-Size="Smaller" />
            </td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <asp:Button Text="Cancel" CssClass="button" runat="server" OnClick="CancelItem" CausesValidation="false" />
                <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SaveDataItem" />
                <asp:Button Text="Delete" CssClass="button" runat="server" ID="deleteBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this exchange?');" OnClick="DeleteDataItem" />
            </td>
        </tr>
    </table>
</asp:Content>

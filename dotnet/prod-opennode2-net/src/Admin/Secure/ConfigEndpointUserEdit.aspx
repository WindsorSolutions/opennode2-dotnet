<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    Codebehind="ConfigEndpointUserEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ConfigEndpointUserEdit"
    Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>

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
            <td class="label" width="50" style="text-align: right; vertical-align:top">Name:</td>
            <td class="ctrl" width="750">
                <asp:TextBox ID="nameCtrl" runat="server" Text=""  CssClass="textbox"/>
                <asp:CustomValidator ID="nameValidator" runat="server" ErrorMessage="Required" ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="nameCtrl"/>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right; vertical-align:top">Endpoint URL:</td>
            <td class="ctrl">
                <asp:TextBox ID="endpointCtrl" CssClass="textbox" Rows="5" Columns="53" runat="server" Text="" Height="43px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="error"
                        Display="Dynamic" ErrorMessage="Required" ControlToValidate="endpointCtrl" EnableClientScript="False"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="endpointCtrl"
                    CssClass="error" Display="Dynamic" ErrorMessage="Invalid Format" ValidationExpression="^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$" EnableClientScript="False"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="label" width="50" style="text-align: right">Version:</td>
            <td class="ctrl">
                <asp:DropDownList ID="versionCtrl" runat="server" CssClass="textbox"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="command" align="left">
                <asp:Button Text="Add Partner" CssClass="button" runat="server" ID="addPartnerBtn" OnClick="OnAddPartner" CausesValidation="false" />
            </td>
            <td class="command" colspan="100%" align="right">
                <asp:Button Text="Check Connection" CssClass="button" runat="server" ID="checkConnectionBtn" OnClick="OnCheckConnection" CausesValidation="False" />
                <input type="button" value="Cancel" class="button" onclick="location.href='ConfigEndpointUser.aspx'" />
                <asp:Button Text="Save" CssClass="button" runat="server" Id="saveBtn" OnClick="SaveDataItem"  />
                <asp:Button Text="Delete" CssClass="button" runat="server" Id="deleteBtn" CausesValidation="false" 
                OnClientClick="return confirm('Are you sure you want to delete this partner?');" OnClick="DeleteDataItem" />
            </td>
        </tr>
    </table>
</asp:Content>

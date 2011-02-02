<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.Transaction" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

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
    <table id="formTable" width="750px" cellpadding="2" cellspacing="0">
        <tr>
            <td class="label" style="width: 25%; white-space: nowrap">
                Transaction Id:
            </td>
            <td class="ctrl" style="width: 75%">
                <asp:Label ID="transactionIdCtrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap">
                Current Status:
            </td>
            <td class="ctrl">
                <asp:Image ID="transactionStatusImage" runat="server" Style="vertical-align: middle" />
                <asp:Label ID="transactionCurrentStatusCtrl" runat="server" Style="vertical-align: middle" />
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap">
                Status Details:
            </td>
            <td class="ctrl">
                <asp:Label ID="transactionStatusDetails" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap">
                Service Type:
            </td>
            <td class="ctrl">
                <asp:Label ID="transactionServiceTypeCtrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap">
                Exchange:
            </td>
            <td class="ctrl">
                <asp:Label ID="transactionFlowNameCtrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap">
                Data Operation:
            </td>
            <td class="ctrl">
                <asp:Label ID="transactionOperationNameCtrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap">
                Last Modified By:
            </td>
            <td class="ctrl">
                <asp:Label ID="transactionModifiedByCtrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap">
                Last Modified On:
            </td>
            <td class="ctrl">
                <asp:Label ID="transactionModifiedOnCtrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap" style="vertical-align: top">
                <asp:Label ID="Label3" runat="server" Text="Documents:" />
            </td>
            <td class="ctrl">
                <table border="0" cellpadding="1" cellspacing="0">
                    <asp:Repeater ID="listTranDocs" runat="server" DataSource='<%# Tran.Documents %>'>
                        <ItemTemplate>
                            <tr>
                                <td style="white-space: nowrap" valign="top">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icon_attachment.gif" ImageAlign="Top" Style="vertical-align: top" />File:&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="linkDoc" CommandName='<%# Eval("Id")%>' CommandArgument='<%# Eval("Type")%>' Text='<%# DocumentDisplayName(Container.DataItem)%>' OnCommand="DownloadDocument"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td class="label" style="white-space: nowrap; vertical-align: top">
                Activity Details:
            </td>
            <td class="ctrl">
                <asp:Label ID="transactionActivityDetails" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ctrl" colspan="2">
                <table id="transactionNetworkIdTable" runat="server" cellspacing="0" style="background-color: #D4DDE4; margin-top: 6px" width="100%">
                    <tr>
                        <td class="label" style="width: 25%; white-space: nowrap">
                            Endpoint Transaction Id:
                        </td>
                        <td class="ctrl" style="width: 75%; white-space: nowrap">
                            <asp:Label ID="transactionNetworkIdCtrl" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label" style="white-space: nowrap">
                            Url:
                        </td>
                        <td class="ctrl">
                            <asp:Label ID="networkUrl" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label" style="white-space: nowrap">
                            Version:
                        </td>
                        <td class="ctrl">
                            <asp:Label ID="networkVersion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label" style="vertical-align: middle; white-space: nowrap">
                            Status:
                        </td>
                        <td class="ctrl" style="white-space: nowrap">
                            <asp:Label ID="networkStatus" runat="server" Style="vertical-align: middle; margin-right: 3px" />
                            <asp:ImageButton ImageUrl="../Images/refresh.png" AlternateText="Refresh network status" ToolTip="Refresh network status" BorderWidth="0" ImageAlign="AbsMiddle" runat="server" ID="refreshNetworkStatusBtn" OnClick="OnRefreshNetworkStatus" CausesValidation="False" />
                            <asp:Label ID="Label1" runat="server" Style="vertical-align: middle; margin-right: 3px" Text="Refresh" Font-Size="Smaller" />
                            <asp:ImageButton ImageUrl="../Images/document_view.png" AlternateText="Download network documents" ToolTip="Download network documents" BorderWidth="0" ImageAlign="AbsMiddle" runat="server" ID="downloadNetworkDocumentsBtn" OnClick="OnDownloadNetworkDocuments" CausesValidation="False" Style="padding-left: 12px" />
                            <asp:Label ID="Label2" runat="server" Style="vertical-align: middle; margin-right: 3px" Text="Documents" Font-Size="Smaller" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="BackBtnTableRow" runat="server">
            <td colspan="2" align="right">
                <input id="BackButton" runat="server" class="button" type="button" value="Back" name="ClickBack" causesvalidation="false" enableviewstate="false" />
            </td>
        </tr>
    </table>
</asp:Content>

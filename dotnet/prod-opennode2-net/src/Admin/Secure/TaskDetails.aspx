<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TaskDetails.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.TaskDetails" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

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
            <asp:Timer ID="timer" runat="server" Interval="1500" Enabled="false" EnableViewState="False" />
            <div runat="server" id="divPageError" visible="false" class="error" EnableViewState="False" />
            <asp:HiddenField ID="idCtrl" runat="server" />
            <table id="formTable" width="620px" cellpadding="2" cellspacing="0">
                <tr>
                    <td class="label" nowrap="nowrap">
                        Task:
                    </td>
                    <td class="ctrl">
                        <asp:Label ID="taskNameCtrl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="label" nowrap="nowrap">
                        Created By:
                    </td>
                    <td class="ctrl">
                        <asp:Label ID="transactionCreatedByCtrl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="label" nowrap="nowrap">
                        Current Status:
                    </td>
                    <td class="ctrl">
                        <asp:Image ID="transactionStatusImage" runat="server" Style="vertical-align: middle" EnableViewState="False" />
                        <asp:Label ID="transactionCurrentStatusCtrl" runat="server" Style="vertical-align: middle" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td class="label" nowrap="nowrap">
                        Status Details:
                    </td>
                    <td class="ctrl">
                        <asp:Label ID="transactionStatusDetails" runat="server" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="width: 25%" nowrap="nowrap">
                        Transaction Id:
                    </td>
                    <td class="ctrl" style="width: 75%">
                        <asp:Label ID="transactionIdCtrl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="label" nowrap="nowrap" style="vertical-align: top">
                        <asp:Label runat="server" Text="Status details:" />
                    </td>
                    <td class="ctrl">
                        <table border="0" cellpadding="1" cellspacing="0" style="margin-top: -6px">
                            <asp:Repeater ID="listDetails" runat="server" EnableViewState="False">
                                <ItemTemplate>
                                    <tr>
                                        <td class="ctrl">
                                            <asp:Image ID="transactionStatusImage" runat="server" Style="vertical-align: middle" ImageUrl='<%# GetActivityStatusImageUrl(Eval("StatusType"))%>' />
                                            <asp:Label ID="transactionCurrentStatusCtrl" runat="server" Style="vertical-align: middle" Text='<%# Eval("Message")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
                <tr id="BackBtnTableRow" runat="server">
                    <td colspan="2" align="right">
                <input id="BackButton" runat="server" class="button" type="button" value="Back" name="ClickBack" causesvalidation="false" enableviewstate="false" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

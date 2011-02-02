<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.Schedule" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SecureContentHolder" runat="server">
    <div id="pageTitle">
        <%= SectionTitle %></div>
    <div class="sectionHead">
        <%= ListConfig.SectionHeadline%>
    </div>
    <div class="introText">
        <asp:Repeater ID="introParagraphs" runat="server">
            <ItemTemplate>
                <p>
                    <%# Container.DataItem %></p>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div style="clear: both; text-align: right; margin-bottom: 10px">
        <input type="button" name="cmdNew" value='<%= ListConfig.DetailItemLinkText %>' class="button" onclick="location.href='<%= ListConfig.DetailItemLinkUri %>'" />
    </div>
    <%--    <asp:UpdatePanel ID="updatePnl" runat="server">
        <ContentTemplate>
--%>
    <table id="formTable" width="100%" cellpadding="2" cellspacing="0" style="border-style: none">
        <asp:Repeater runat="server" ID="flowRepeaterList">
            <ItemTemplate>
                <tr style="background-color: #83ACCA">
                    <td width="20">
                        <img alt="" src='..\Images\Flow2.gif' style="border: 0; vertical-align: middle; padding-right: 3px;" />
                    </td>
                    <td width="100%">
                        <a style="color: White; font-weight: bold;">
                            <%#Eval("Value")%>
                        </a>
                        <%--                            <a href='../Secure/FlowEdit.aspx?id=<%#Eval("Key")%>' style="color: White; font-weight: bold;">
                                <%#Eval("Value")%>
                            </a>
--%>
                    </td>
                    <td width="10" align="right">
                        <%--                            <a href='../Secure/FlowEdit.aspx?id=<%#Eval("Key")%>'>
                                <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="middle" style="border-width: 0px;" />
                            </a>
--%>
                    </td>
                </tr>
                <asp:Repeater runat="server" ID="repeaterList">
                    <ItemTemplate>
                        <tr class="rowOdd">
                            <td width="10" nowrap="nowrap">
                                <asp:Image ID="executeStatusImage" runat="server" />
                            </td>
                            <td runat="server" id="valueNameItem" width="100%">
                                <a href='<%= ListConfig.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel" style="font-weight: bold;">
                                    <%#Eval("Value.Name")%>
                                </a>
                            </td>
                            <td width="10" align="right">
                                <a href='<%= ListConfig.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>'>
                                    <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="middle" style="border-width: 0px;" />
                                </a>
                            </td>
                        </tr>
                        <tr runat="server" id="valueDescriptionRow" class="rowOdd">
                            <td>
                                &nbsp;
                            </td>
                            <td runat="server" id="valueDescriptionItem" width="100%" colspan="2" class="ctrl" align="left">
                                <%# Eval("Value.Description")%>
                            </td>
                        </tr>
                        <tr runat="server" id="lastRunInfoRow" class="rowOdd" visible="false">
                            <td>
                                &nbsp;
                            </td>
                            <td class="ctrl">
                                <asp:LinkButton ID="lastRunInfoButton" runat="server" OnClick="lastRunInfoButton_Click" Font-Underline="True">Show Last Run Info >></asp:LinkButton>
                            </td>
                            <td id="Td1" width="10" align="right">
                                <asp:ImageButton ID="transactionImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/text_view.gif" OnCommand="OnViewTransactionDetailClick" />
                            </td>
                        </tr>
                        <tr runat="server" id="lastRunTextRow" class="rowOdd" visible="false">
                            <td>
                                &nbsp;
                            </td>
                            <td runat="server" id="Td2" width="100%" colspan="2" class="ctrl">
                                <asp:Label ID="infoTextLabel" runat="server" />
                                <asp:HiddenField ID="activityIdField" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="rowEven">
                            <td width="10" nowrap="nowrap">
                                <asp:Image ID="executeStatusImage" runat="server" />
                            </td>
                            <td runat="server" id="valueNameItem" width="100%">
                                <a href='<%= ListConfig.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel" style="font-weight: bold;">
                                    <%#Eval("Value.Name")%>
                                </a>
                            </td>
                            <td width="10" align="right">
                                <a href='<%= ListConfig.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>'>
                                    <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="absmiddle" style="border-width: 0px;" />
                                </a>
                            </td>
                        </tr>
                        <tr runat="server" id="valueDescriptionRow" class="rowEven">
                            <td>
                                &nbsp;
                            </td>
                            <td runat="server" id="valueDescriptionItem" width="100%" colspan="2" class="ctrl" align="left">
                                <%# Eval("Value.Description")%>
                            </td>
                        </tr>
                        <tr runat="server" id="lastRunInfoRow" class="rowEven" visible="false">
                            <td>
                                &nbsp;
                            </td>
                            <td class="ctrl">
                                <asp:LinkButton ID="lastRunInfoButton" runat="server" OnClick="lastRunInfoButton_Click" Font-Underline="True">Show Last Run Info >></asp:LinkButton>
                            </td>
                            <td id="Td1" width="10" align="right">
                                <asp:ImageButton ID="transactionImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/text_view.gif" OnCommand="OnViewTransactionDetailClick" />
                            </td>
                        </tr>
                        <tr runat="server" id="lastRunTextRow" class="rowEven" visible="false">
                            <td>
                                &nbsp;
                            </td>
                            <td runat="server" id="Td2" width="100%" colspan="2" class="ctrl">
                                <asp:Label ID="infoTextLabel" runat="server" />
                                <asp:HiddenField ID="activityIdField" runat="server" />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                </tr>
                <tr style="background-color: White">
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>
--%></asp:Content>

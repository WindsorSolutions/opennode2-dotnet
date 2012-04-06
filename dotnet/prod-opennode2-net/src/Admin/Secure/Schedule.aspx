<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.Schedule" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="../Controls/UpdateProgressCntl.ascx" TagName="UpdateProgressCntl" TagPrefix="uc1" %>
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
        <asp:Button Text="Add Schedule" CssClass="button" runat="server" ID="addScheduleBtn" OnClick="OnAddScheduleClick" />
    </div>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
            </div>
            <table id="formTable" width="100%" cellpadding="2" cellspacing="0" style="border-style: none">
                <asp:Repeater runat="server" ID="flowRepeaterList">
                    <ItemTemplate>
                        <tr style="background-color: #83ACCA">
                            <td style="width: 20px">
                                <img alt="" src='../Images/UI/globe-network.png' style="border: 0; vertical-align: middle; padding-top: 2px; padding-bottom: 2px; padding-right: 3px; padding-left: 3px;" />
                            </td>
                            <td style="width: 100%">
                                <a style="color: White; font-weight: bold;">
                                    <%#Eval("Value")%>
                                </a>
                            </td>
                            <td style="width: 20px" align="right">
                            </td>
                        </tr>
                        <asp:Repeater runat="server" ID="repeaterList">
                            <ItemTemplate>
                                <tr class="rowOdd" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                    <td>
                                        <asp:Image ID="scheduleImage" runat="server" Style="padding-left: 4px; padding-right: 4px" ImageUrl="../Images/UI/time.png" />
                                        <asp:HiddenField ID="hiddenScheduleId" runat="server" Value='<%# Eval("Key") %>'/>
                                    </td>
                                    <td runat="server" id="valueNameItem">
                                        <a href='<%= ListConfig.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel" style="font-weight: bold;" title="<%#ScheduleToolTipEditName(Container.DataItem)%>">
                                            <%#ScheduleDisplayName(Container.DataItem)%>
                                        </a>
                                    </td>
                                    <td align="right" style="white-space: nowrap">
                                        <asp:ImageButton ID="runNowImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/arrow_rotate_clockwise.png" Style="padding-left: 4px; vertical-align: middle" OnCommand="OnRunNowClick" />
                                        <a href='<%= ListConfig.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' title="<%#ScheduleToolTipEditName(Container.DataItem)%>">
                                            <img src="<%#ScheduleEditImageUrl(Container.DataItem)%>" alt="" align="middle" style="border-width: 0px; padding-left: 4px; padding-right: 4px; vertical-align: middle" />
                                        </a>
                                    </td>
                                </tr>
                                <tr runat="server" id="valueDescriptionRow" class="rowOdd" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td runat="server" id="valueDescriptionItem" colspan="2" class="ctrl" align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr runat="server" id="lastRunInfoRow" class="rowOdd" visible="false" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                    <td>
                                        <asp:Image ID="executeStatusImage" runat="server" Style="padding-left: 4px; padding-right: 4px" ImageUrl="../Images/UI/time.png" />
                                    </td>
                                    <td class="ctrl">
                                        <asp:LinkButton ID="lastRunInfoButton" runat="server" OnClick="lastRunInfoButton_Click" Font-Underline="True">Show Last Run Info >></asp:LinkButton>
                                    </td>
                                    <td id="Td1" align="right">
                                        <asp:ImageButton ID="transactionImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/zoom.png" Style="padding-right: 4px" OnCommand="OnViewTransactionDetailClick" />
                                    </td>
                                </tr>
                                <tr runat="server" id="lastRunTextRow" class="rowOdd" visible="false" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td runat="server" id="Td2" colspan="2" class="ctrl">
                                        <asp:Label ID="infoTextLabel" runat="server" />
                                        <asp:HiddenField ID="activityIdField" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="PageTimer" />
        </Triggers>
    </asp:UpdatePanel>
    <uc1:UpdateProgressCntl ID="UpdateProgressCntl" runat="server" />
    <asp:Timer ID="PageTimer" runat="server" Interval="45000" OnTick="PageTimer_Tick" />
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.Schedule" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="../Controls/UpdateProgressCntl.ascx" TagName="UpdateProgressCntl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecureContentHolder" runat="server">
    <div id="pageTitle">
        <%= SectionTitle %>
    </div>
    <div class="sectionHead">
        <%= ListConfig.SectionHeadline%>
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
            <div>
                <table id="wrapperTable" width="100%" cellpadding="0" cellspacing="0" border="0" class="basicTable">
                    <tr>
                        <td class="command" align="left" style="width: 100%;">
                            <asp:LinkButton ID="ExpandAllLinkButton" runat="server" CausesValidation="false" Style="padding-right: 12px" ToolTip="Show All Schedules" OnClick="ExpandAllLinkButton_Click">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/UI/expand_16.png" Style="vertical-align: middle; padding-right: 2px" />
                                <asp:Label ID="Label1" runat="server" Style="vertical-align: middle">Show All Schedules</asp:Label>
                            </asp:LinkButton>
                            <asp:LinkButton ID="CollapseAllLinkButton" runat="server" CausesValidation="false" ToolTip="Hide All Schedules" OnClick="CollapseAllLinkButton_Click">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/UI/collapse_16.png" Style="vertical-align: middle; padding-right: 2px" />
                                <asp:Label ID="Label2" runat="server" Style="vertical-align: middle">Hide All Schedules</asp:Label>
                            </asp:LinkButton>
                        </td>
                        <td class="command" align="right">
                            <asp:Button Text="Add Schedule" CssClass="button" runat="server" ID="addScheduleBtn" OnClick="OnAddScheduleClick" />
                        </td>
                    </tr>
                </table>
                <table id="formTable" width="600px" cellpadding="2" cellspacing="0" style="border-style: none">
                    <asp:Repeater runat="server" ID="flowRepeaterList">
                        <ItemTemplate>
                            <tr runat="server" style="background-color: #83ACCA">
                                <td style="width: 20px; white-space: nowrap">
                                    <asp:ImageButton ID="expandCollapseSchedulesImageButton" runat="server" CausesValidation="false" Style="vertical-align: middle;"
                                        OnClick="OnExpandCollapseSchedulesClick" CommandArgument='<%#Eval("Key")%>' />
                                    <img alt="" src='../Images/UI/globe-network.png' style="border: 0; vertical-align: middle; padding-top: 2px; padding-bottom: 2px; padding-right: 3px; padding-left: 3px;" />
                                </td>
                                <td style="width: 100%">
                                    <a style="color: White; font-weight: bold;">
                                        <%#Server.HtmlEncode((string)Eval("Value"))%>
                                    </a>
                                </td>
                                <td style="width: 20px" align="right">
                                </td>
                            </tr>
                            <asp:Repeater runat="server" ID="repeaterList">
                                <ItemTemplate>
                                    <tr runat="server" class="rowOdd" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                        <td class="listItemLeftCell">
                                            <asp:Image ID="scheduleImage" runat="server" Style="padding-left: 4px; padding-right: 4px" ImageUrl="../Images/UI/time.png" />
                                            <asp:HiddenField ID="hiddenScheduleId" runat="server" Value='<%# Eval("Key") %>' />
                                        </td>
                                        <td runat="server" id="valueNameItem">
                                            <a href='<%= ListConfig.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' class="listlabel" style="font-weight: bold;" title="<%#ScheduleToolTipEditName(Container.DataItem)%>">
                                                <%#ScheduleDisplayName(Container.DataItem)%>
                                            </a>
                                        </td>
                                        <td align="right" style="white-space: nowrap" class="listItemRightCell">
                                            <asp:ImageButton ID="runNowImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/arrow_rotate_clockwise.png" Style="padding-left: 4px; vertical-align: middle" OnCommand="OnRunNowClick"
                                                OnClientClick="return confirm('Are you sure you want to run this schedule?');" />
                                            <a href='<%= ListConfig.DetailItemLinkUri %>?id=<%# UriEscapeDataString(Eval("Key")) %>' title="<%#ScheduleToolTipEditName(Container.DataItem)%>">
                                                <img src="<%#ScheduleEditImageUrl(Container.DataItem)%>" alt="" align="middle" style="border-width: 0px; padding-left: 4px; padding-right: 4px; vertical-align: middle" />
                                            </a>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="valueDescriptionRow" class="rowOdd" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                        <td class="listItemLeftCell">
                                            &nbsp;
                                        </td>
                                        <td runat="server" id="valueDescriptionItem" colspan="2" class="ctrl listItemRightCell" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr runat="server" id="lastRunInfoRow" class="rowOdd" visible="false" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                        <td class="listItemLeftCell">
                                            <asp:Image ID="executeStatusImage" runat="server" Style="padding-left: 4px; padding-right: 4px" ImageUrl="../Images/UI/time.png" />
                                        </td>
                                        <td class="ctrl">
                                            <asp:LinkButton ID="lastRunInfoButton" runat="server" OnClick="lastRunInfoButton_Click" Font-Underline="True">Show Last Run Info >></asp:LinkButton>
                                        </td>
                                        <td id="Td1" align="right" class="listItemRightCell">
                                            <asp:ImageButton ID="transactionImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/zoom.png" Style="padding-right: 4px" OnCommand="OnViewTransactionDetailClick" />
                                        </td>
                                    </tr>
                                    <tr runat="server" id="lastRunTextRow" class="rowOdd" visible="false" style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                        <td class="listItemLeftCell listItemBottomCell">
                                            &nbsp;
                                        </td>
                                        <td runat="server" id="Td2" colspan="2" class="ctrl listItemRightCell">
                                            <asp:Label ID="infoTextLabel" runat="server" />
                                            <asp:HiddenField ID="activityIdField" runat="server" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td class="listItemBottomCell" style="height: 10px; width: 100%; background-color: White" colspan="3">
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="PageTimer" />
        </Triggers>
    </asp:UpdatePanel>
    <uc1:UpdateProgressCntl ID="UpdateProgressCntl" runat="server" />
    <asp:Timer ID="PageTimer" runat="server" Interval="5000" OnTick="PageTimer_Tick" />
</asp:Content>

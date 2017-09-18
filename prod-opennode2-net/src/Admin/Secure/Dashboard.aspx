<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.Dashboard" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="GChartControl.ascx" TagName="GChartControl" TagPrefix="uc1" %>
<%@ Register Src="NewsBar.ascx" TagName="NewsBar" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/UpdateProgressCntl.ascx" TagName="UpdateProgressCntl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecureContentHolder" runat="server">
    <div id="pageTitle">
        <%= SectionTitle %></div>
    <div>
        <p>
            The Dashboard tab provides a brief summary of the key information concerning the status and operation of the Node. This information includes an illustration of the high volume transactions being executed against the Node, and the most active users of the Node, as well as an RSS which provides a summary of important information and news relevant to users of the Node. This area will be used to provide users with update and important service information related to the operation of the Node.
            <br/>
        </p>
    </div>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="2" cellspacing="0">
                <tr>
                    <td style="width: 400">
                        <uc1:GChartControl ID="ChartTop" runat="server" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td rowspan="3" style="width: 100%" valign="top">
                        <uc2:NewsBar ID="NewsSideBar" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="sectionHead">
                            <strong>Most Active Users</strong></div>
                        <img src="ImageRequestHandler.ashx" alt="Chart" style="border: 0;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="recentTransactionsPanel" runat="server" CssClass="sectionHead">
                            <asp:Label runat="server" Text="Recent Activity" />
                            <asp:GridView ID="recentTransactionsGridView" runat="server" AutoGenerateColumns="False" GridLines="None" Width="100%" Font-Names="Verdana,Arial,Helvetica,sans-serif" Font-Size="Small" OnRowDataBound="recentTransactionsGridView_RowDataBound" BorderStyle="Solid" BorderWidth="3px" Font-Bold="False" CellPadding="3" BorderColor="#90B4CF" ForeColor="Black" HorizontalAlign="Center">
                                <RowStyle BackColor="#E3ECF3" Font-Size="Smaller" Wrap="True" />
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Image ID="activityTypeImage" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" Width="20px"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="What" ReadOnly="True" DataField="What" SortExpression="What">
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" Width="120px"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Exchange" ReadOnly="True" DataField="FlowName" SortExpression="FlowName">
                                        <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Operation" ReadOnly="True" DataField="Operation" SortExpression="Operation">
                                        <ItemStyle HorizontalAlign="Left" Wrap="True"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Who" ReadOnly="True" DataField="Who" SortExpression="Who">
                                        <ItemStyle HorizontalAlign="Left" Wrap="True"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="When" ReadOnly="True" DataField="ModifiedOn" SortExpression="ModifiedOn" ItemStyle-Width="140px" DataFormatString="{0:yyyy-MM-dd HH:mm}" ItemStyle-Wrap="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
                                        <ItemStyle Wrap="False" Width="140px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="viewTaskDetailImageButton" runat="server" CausesValidation="false" ImageUrl='<%# Container.DataItemIndex % 2 == 0 ? "../Images/UI/task_even.gif" : "../Images/UI/task_odd.gif"%>' ToolTip='<%# string.Format("View Task Detail: {0}", Eval("TransactionId"))%>' OnCommand="OnViewTaskDetailClick" CommandArgument='<%# Eval("TransactionId")%>' Visible='<%# !string.IsNullOrEmpty((string)Eval("TransactionId")) && IsTaskMethod(Eval("Method"))%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="viewTransactionDetailImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/zoom.png" ToolTip='<%# string.Format("View Transaction Detail: {0}", Eval("TransactionId"))%>' OnCommand="OnViewTransactionDetailClick" CommandArgument='<%# Eval("TransactionId")%>' Visible='<%# !string.IsNullOrEmpty((string)Eval("TransactionId"))%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="moreInfoImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/control-double-270-small.png" ToolTip="Show Activity Detail" OnClick="OnMoreInfoClick" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Left" BackColor="#90B4CF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Wrap="False" />
                                <AlternatingRowStyle BackColor="Gainsboro" Wrap="False" />
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:UpdateProgressCntl ID="UpdateProgressCntl" runat="server" />
</asp:Content>

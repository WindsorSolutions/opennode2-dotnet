<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ActivitySearchCriteria.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ActivitySearchCriteria"
    Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/UpdateProgressCntl.ascx" TagName="UpdateProgressCntl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecureContentHolder" runat="server">
    <div id="pageTitle">
        <%= SectionTitle %></div>
    <div class="sectionHead">
        <%= SectionHeadline%></div>
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
            <asp:HiddenField ID="idCtrl" runat="server" />
            <asp:Panel ID="pnl1" runat="server" DefaultButton="searchBtn">
                <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
                    <tr>
                        <td class="label" style="width: 120px; white-space: nowrap; vertical-align: middle">
                            Exchange:
                        </td>
                        <td style="vertical-align: middle; padding-right: 12px">
                            <asp:DropDownList ID="exchangeDropDownList" runat="server" Width="300px" />
                        </td>
                        <td class="label" style="vertical-align: middle; white-space: nowrap; vertical-align: top">
                            Operation:
                        </td>
                        <td style="vertical-align: middle; padding-right: 12px">
                            <asp:DropDownList ID="operationDropDownList" runat="server" Width="350px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label" style="white-space: nowrap; vertical-align: top">
                            Date Range:
                        </td>
                        <td align="left" style="vertical-align: top; white-space: nowrap">
                            <table id="Table1" cellpadding="2" cellspacing="0">
                                <tr align="left" valign="middle" style="vertical-align: middle">
                                    <td valign="middle" style="vertical-align: middle">
                                        From:
                                    </td>
                                    <td valign="middle" style="vertical-align: middle">
                                        <asp:TextBox ID="fromDateImageButton" Width='80px' runat="server"></asp:TextBox>
                                        <asp:ImageButton runat="Server" ID="fromCalImage" ImageUrl="~/Images/UI/calendar-blue.png"
                                            AlternateText="Click to show calendar" Style="vertical-align: middle; padding-bottom: 2px" /><br />
                                        <cc1:CalendarExtender ID="fromDateCalendarExtender" runat="server" TargetControlID="fromDateImageButton"
                                            Format="yyyy-MM-dd" PopupButtonID="fromCalImage" />
                                    </td>
                                </tr>
                                <tr align="left" valign="middle" style="vertical-align: middle">
                                    <td valign="middle" style="vertical-align: middle">
                                        To:
                                    </td>
                                    <td valign="middle" style="vertical-align: middle">
                                        <asp:TextBox ID="toDateImageButton" Width='80px' runat="server"></asp:TextBox>
                                        <asp:ImageButton runat="Server" ID="toCalImage" ImageUrl="~/Images/UI/calendar-blue.png"
                                            AlternateText="Click to show calendar" Style="vertical-align: middle; padding-bottom: 2px" /><br />
                                        <cc1:CalendarExtender ID="toDateCalendarExtender" runat="server" TargetControlID="toDateImageButton"
                                            Format="yyyy-MM-dd" PopupButtonID="toCalImage" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="label" style="white-space: nowrap; vertical-align: top">
                            Activity Type:
                        </td>
                        <td style="vertical-align: top; padding-top: 4px">
                            <asp:DropDownList ID="nodeMethodTypeDropdown" runat="server" Width="350px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label" style="white-space: nowrap; vertical-align: middle">
                            Entry Type:
                        </td>
                        <td style="vertical-align: middle">
                            <asp:DropDownList ID="activityTypeCtrl" runat="server" Width="300px" />
                        </td>
                        <td class="label" style="white-space: nowrap; vertical-align: middle">
                            By User:
                        </td>
                        <td class="ctrl" style="vertical-align: middle">
                            <asp:DropDownList ID="byUserCtrl" runat="server" Width="350px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label" style="white-space: nowrap; vertical-align: middle">
                            From IP:
                        </td>
                        <td style="vertical-align: middle">
                            <asp:DropDownList ID="fromIpCtrl" runat="server" Width="300px" />
                        </td>
                        <td class="label" style="white-space: nowrap; vertical-align: middle">
                            Transaction Id:
                        </td>
                        <td style="vertical-align: middle">
                            <asp:TextBox ID="transactionIdCtrl" runat="server" Width="350px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label" style="white-space: nowrap; vertical-align: middle">
                            Content:
                        </td>
                        <td colspan="3" style="vertical-align: middle">
                            <asp:TextBox ID="contentCtrl" runat="server" Width="99%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label" style="white-space: nowrap; vertical-align: middle">
                            Results/Page:
                        </td>
                        <td style="vertical-align: middle">
                            <asp:TextBox ID="resultsPerPage" runat="server" Width="60px" AutoPostBack="True"
                                OnTextChanged="resultsPerPage_TextChanged" />
                        </td>
                        <td class="command" colspan="2" align="right">
                            <asp:Button Text="Search" CssClass="button" runat="server" ID="searchBtn" OnClick="OnClickSearch" />
                            <asp:Button Text="Reset" CssClass="button" runat="server" ID="resetBtn" CausesValidation="false"
                                OnClick="OnClickReset" />
                            <asp:Button ID="DeleteAllButton" Text="Delete All" CssClass="button" runat="server"
                                OnClick="OnDeleteAllActivities" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete all activities that match the current search criteria?\n\nIMPORTANT: Activities cannot be recovered once deleted.');" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div runat="server" id="noItemsDiv" visible="false" class="error" enableviewstate="false"
                style="text-align: center; padding: 8px">
                No Items Found
            </div>
            <asp:GridView ID="resultsGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                GridLines="None" Width="100%" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                Font-Size="Small" OnRowDataBound="resultsGridView_RowDataBound" AllowPaging="True"
                BorderStyle="Solid" BorderWidth="3px" Font-Bold="False" CellPadding="3" OnSorting="resultsGridView_Sorting"
                BorderColor="#90B4CF" ForeColor="Black" EnableViewState="False" HorizontalAlign="Center">
                <PagerSettings Position="TopAndBottom" />
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
                    <asp:BoundField HeaderText="When" ReadOnly="True" DataField="ModifiedOn" SortExpression="ModifiedOn"
                        ItemStyle-Width="140px" DataFormatString="{0:yyyy-MM-dd HH:mm}" ItemStyle-Wrap="False"
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="False">
                        <ItemStyle Wrap="False" Width="140px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="viewTaskDetailImageButton" runat="server" CausesValidation="false"
                                ImageUrl='<%# Container.DataItemIndex % 2 == 0 ? "../Images/UI/task_even.gif" : "../Images/UI/task_odd.gif"%>'
                                ToolTip='<%# string.Format("View Task Detail: {0}", Eval("TransactionId"))%>'
                                OnCommand="OnViewTaskDetailClick" CommandArgument='<%# Eval("TransactionId")%>'
                                Visible='<%# !string.IsNullOrEmpty((string)Eval("TransactionId")) && IsTaskMethod(Eval("Method"))%>' />
                        </ItemTemplate>
                        <ItemStyle Width="10px" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="viewTransactionDetailImageButton" runat="server" CausesValidation="false"
                                ImageUrl="../Images/UI/zoom.png" ToolTip='<%# string.Format("View Transaction Detail: {0}", Eval("TransactionId"))%>'
                                OnCommand="OnViewTransactionDetailClick" CommandArgument='<%# Eval("TransactionId")%>'
                                Visible='<%# !string.IsNullOrEmpty((string)Eval("TransactionId"))%>' />
                        </ItemTemplate>
                        <ItemStyle Width="10px" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="moreInfoImageButton" runat="server" CausesValidation="false"
                                ImageUrl="../Images/UI/control-double-270-small.png" ToolTip="Show Activity Detail"
                                OnClick="OnMoreInfoClick" />
                        </ItemTemplate>
                        <ItemStyle Width="10px" Wrap="False" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle HorizontalAlign="Left" BackColor="#90B4CF" BorderColor="Black" BorderStyle="Solid"
                    BorderWidth="1px" Wrap="False" />
                <AlternatingRowStyle BackColor="Gainsboro" Wrap="False" />
                <PagerTemplate>
                    <table width="100%">
                        <tr align="left" valign="middle">
                            <td style="white-space: nowrap">
                                <asp:ImageButton ID="firstPageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/arrow_double_left.gif"
                                    OnClick="OnFirstPageClick" ToolTip="First" />
                            </td>
                            <td style="white-space: nowrap">
                                <asp:ImageButton ID="previousPageButton" runat="server" CausesValidation="false"
                                    ImageUrl="../Images/UI/arrow_left.gif" OnClick="OnPreviousPageClick" ToolTip="Previous" />
                            </td>
                            <td style="white-space: nowrap">
                                <asp:Label ID="currentPageLabel" runat="server" Text="Page 1 of 2" Font-Size="Smaller"
                                    Font-Underline="False"></asp:Label>
                            </td>
                            <td style="white-space: nowrap">
                                <asp:ImageButton ID="nextPageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/arrow_right.gif"
                                    ToolTip="Next" OnClick="OnNextPageClick" />
                            </td>
                            <td style="white-space: nowrap">
                                <asp:ImageButton ID="lastPageButton" runat="server" CausesValidation="false" ImageUrl="../Images/UI/arrow_double_right.gif"
                                    ToolTip="Last" OnClick="OnLastPageClick" />
                            </td>
                            <td class="command" align="right" style="width: 100%; white-space: nowrap">
                            </td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:UpdateProgressCntl ID="UpdateProgressCntl" runat="server" />
</asp:Content>

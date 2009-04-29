<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ActivitySearchCriteria.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ActivitySearchCriteria" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
    <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
    </div>
    <asp:HiddenField ID="idCtrl" runat="server" />
    <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td class="label" nowrap="nowrap" style="width: 120px">
                Exchange:
            </td>
            <td>
                <asp:DropDownList ID="exchangeDropDownList" runat="server" Width="200px" />
            </td>
            <td class="label" nowrap="nowrap" style="width: 120px">
                Date Range:
            </td>
            <td nowrap="nowrap" colspan="3" align="left">
                <table id="Table1" cellpadding="2" cellspacing="0">
                    <tr align="left" valign="middle" style="vertical-align: middle">
                        <td>
                            From:
                        </td>
                        <td valign="middle">
                            <asp:TextBox ID="fromDateImageButton" Width='80px' runat="server"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="fromCalImage" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" /><br />
                            <cc1:CalendarExtender ID="fromDateCalendarExtender" runat="server" TargetControlID="fromDateImageButton" Format="yyyy-MM-dd" PopupButtonID="fromCalImage" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;To:
                        </td>
                        <td valign="middle">
                            <asp:TextBox ID="toDateImageButton" Width='80px' runat="server"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="toCalImage" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" /><br />
                            <cc1:CalendarExtender ID="toDateCalendarExtender" runat="server" TargetControlID="toDateImageButton" Format="yyyy-MM-dd" PopupButtonID="toCalImage" />
                        </td>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Must be a valid date" ValidateEmptyText="False" OnServerValidate="ServerValidateDate" ControlToValidate="fromDateImageButton" />
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Must be a valid date" ValidateEmptyText="False" OnServerValidate="ServerValidateDate" ControlToValidate="toDateImageButton" />
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="label" nowrap="nowrap" style="width: 120px">
                Entry Type:
            </td>
            <td>
                <asp:DropDownList ID="activityTypeCtrl" runat="server" Width="150px" />
            </td>
            <td class="label" nowrap="nowrap" style="width: 120px">
                By User:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="byUserCtrl" runat="server" Width="350px" />
            </td>
        </tr>
        <tr>
            <td class="label" nowrap="nowrap" style="width: 120px">
                From IP:
            </td>
            <td>
                <asp:DropDownList ID="fromIpCtrl" runat="server" Width="150px" />
            </td>
            <td class="label" nowrap="nowrap" style="width: 120px">
                Transaction Id:
            </td>
            <td>
                <asp:TextBox ID="transactionIdCtrl" runat="server" Width="350px" />
            </td>
        </tr>
        <tr>
            <td class="label" nowrap="nowrap" style="width: 120px" valign="top">
                Content:
            </td>
            <td colspan="3">
                <asp:TextBox ID="contentCtrl" runat="server" Width="99%" />
            </td>
        </tr>
        <tr>
            <td class="label" nowrap="nowrap" style="width: 120px" valign="top">
                Results/Page:
            </td>
            <td>
                <asp:TextBox ID="resultsPerPage" runat="server" Width="60px" AutoPostBack="True" OnTextChanged="resultsPerPage_TextChanged" />
            </td>
            <td class="command" colspan="2" align="right">
                <asp:Button Text="Search" CssClass="button" runat="server" ID="searchBtn" OnClick="OnClickSearch" />
                <asp:Button Text="Reset" CssClass="button" runat="server" ID="resetBtn" CausesValidation="false" OnClick="OnClickReset" />
            </td>
        </tr>
    </table>
    <div runat="server" id="noItemsDiv" visible="false" class="error" enableviewstate="false" style="text-align: center; padding: 8px">
        No Items Found
    </div>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
--%>            <asp:GridView ID="resultsGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" GridLines="None" Width="100%" Font-Names="Verdana,Arial,Helvetica,sans-serif" Font-Size="Small" OnRowDataBound="resultsGridView_RowDataBound" AllowPaging="True" BorderStyle="Solid" BorderWidth="3px" Font-Bold="False" CellPadding="3" OnSorting="resultsGridView_Sorting" BorderColor="#90B4CF" ForeColor="Black" EnableViewState="False" HorizontalAlign="Center">
                <PagerSettings Position="TopAndBottom" />
                <RowStyle BackColor="#E3ECF3" Font-Size="Smaller" Wrap="True" />
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-Width="20px" ItemStyle-Wrap="False" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="activityTypeImage" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="What" ReadOnly="True" DataField="What" SortExpression="What" ItemStyle-Width="120px" ItemStyle-Wrap="False" />
                    <asp:BoundField HeaderText="When" ReadOnly="True" DataField="ModifiedOn" SortExpression="ModifiedOn" ItemStyle-Width="140px" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ItemStyle-Wrap="False" />
                    <asp:BoundField DataField="Who" HeaderText="Who" SortExpression="Who" ReadOnly="True" />
                    <asp:BoundField HeaderText="Exchange" ReadOnly="True" DataField="FlowName" ItemStyle-Wrap="True" SortExpression="FlowName" />
                    <asp:BoundField HeaderText="Operation" ReadOnly="True" DataField="Operation" ItemStyle-Wrap="True" SortExpression="Operation" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="viewTaskDetailImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/task.png" ToolTip='<%# string.Format("View Task Detail: {0}", Eval("TransactionId"))%>' OnCommand="OnViewTaskDetailClick" CommandArgument='<%# Eval("TransactionId")%>' Visible='<%# !string.IsNullOrEmpty((string)Eval("TransactionId")) && IsTaskMethod(Eval("Method"))%>' />
                        </ItemTemplate>
                        <ItemStyle Width="10px" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="viewTransactionDetailImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/text_view.gif" ToolTip='<%# string.Format("View Transaction Detail: {0}", Eval("TransactionId"))%>' OnCommand="OnViewTransactionDetailClick" CommandArgument='<%# Eval("TransactionId")%>' Visible='<%# !string.IsNullOrEmpty((string)Eval("TransactionId"))%>' />
                        </ItemTemplate>
                        <ItemStyle Width="10px" Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="moreInfoImageButton" runat="server" CausesValidation="false" ImageUrl="../Images/action_go.gif" ToolTip="Show Activity Detail" OnClick="OnMoreInfoClick" />
                        </ItemTemplate>
                        <ItemStyle Width="10px" Wrap="False" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle HorizontalAlign="Left" BackColor="#90B4CF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Wrap="False" />
                <AlternatingRowStyle BackColor="Gainsboro" Wrap="False" />
                <PagerTemplate>
                    <table>
                        <tr align="left" valign="middle">
                            <td>
                                <asp:ImageButton ID="firstPageButton" runat="server" CausesValidation="false" ImageUrl="~/Images/arrow_double_left.gif" OnClick="OnFirstPageClick" ToolTip="First" />
                            </td>
                            <td>
                                <asp:ImageButton ID="previousPageButton" runat="server" CausesValidation="false" ImageUrl="~/Images/arrow_left.gif" OnClick="OnPreviousPageClick" ToolTip="Previous" />
                            </td>
                            <td>
                                <asp:Label ID="currentPageLabel" runat="server" Text="Page 1 of 2" Font-Size="Smaller" Font-Underline="False"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="nextPageButton" runat="server" CausesValidation="false" ImageUrl="~/Images/arrow_right.gif" ToolTip="Next" OnClick="OnNextPageClick" />
                            </td>
                            <td>
                                <asp:ImageButton ID="lastPageButton" runat="server" CausesValidation="false" ImageUrl="~/Images/arrow_double_right.gif" ToolTip="Last" OnClick="OnLastPageClick" />
                            </td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
<%--        </ContentTemplate>
    </asp:UpdatePanel>
--%></asp:Content>

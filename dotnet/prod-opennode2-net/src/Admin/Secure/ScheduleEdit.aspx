<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ScheduleEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ScheduleEdit" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/UpdateProgressCntl.ascx" TagName="UpdateProgressCntl" TagPrefix="uc1" %>
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
            <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
            </div>
            <asp:HiddenField ID="idCtrl" runat="server" />
            <table id="formTable" width="600px" cellpadding="2" cellspacing="0">
                <tr>
                    <td />
                    <td>
                        <table id="Table4" width="100%" cellpadding="2" cellspacing="0">
                            <tr>
                                <td valign="top" width="10">
                                    <asp:Image ID="iconAlert" runat="server" HeaderText="Please correct the following errors:" ImageUrl="~/Images/UI/exclamation_alert.png" />
                                </td>
                                <td>
                                    <asp:ValidationSummary ID="validationSummary" runat="server" HeaderText="Please correct the following errors:" Width="98%" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="label" width="100px" style="white-space:nowrap">
                                    <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Images/UI/time.png" style="padding-right: 3px"/>Name:
                        <asp:CustomValidator ID="NameValidator" runat="server" Display="Dynamic" ErrorMessage="A name is required." ValidateEmptyText="True" EnableClientScript="False" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="nameEdit" Text="*" />
                    </td>
                    <td class="ctrl">
                        <asp:TextBox ID="nameEdit" runat="server" Text="" Width="350px" />
                        <asp:CheckBox ID="activeCheckBox" runat="server" Text="Active" />
                        <asp:CustomValidator ID="CustomValidator3" runat="server" Display="Dynamic" ErrorMessage="" ValidateEmptyText="True" EnableClientScript="False" OnServerValidate="ServerValidateActive" ControlToValidate="nameEdit" Text="*" />
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Exchange:
                        <asp:CustomValidator ID="ExchangeValidator" runat="server" Display="Dynamic" ErrorMessage="An exchange is required." ValidateEmptyText="True" EnableClientScript="False" OnServerValidate="ServerValidateNotSelectedControl" ControlToValidate="flowDropDownList" Text="*" />
                    </td>
                    <td class="ctrl">
                        <asp:DropDownList ID="flowDropDownList" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="flowDropDownList_SelectedIndexChanged" />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="vertical-align: top">
                        Availability:
                        <asp:CustomValidator ID="AvailabilityValidator" runat="server" Display="Dynamic" ErrorMessage="" ValidateEmptyText="False" EnableClientScript="False" OnServerValidate="ServerValidateStartEndDates" ControlToValidate="startDateImageButton" Text="*" />
                    </td>
                    <td class="ctrl" valign="top">
                        <table id="formTable1" width="100%" cellpadding="0" cellspacing="0">
                            <tr style="vertical-align: top" valign="top">
                                <td style="width: 70px; white-space: nowrap; vertical-align: top; padding-bottom: 6px" align="right" valign="top">
                                    <asp:Label ID="startsOnLabel" runat="server" Text="Starts On:&nbsp;" Style=""></asp:Label>
                                </td>
                                <td style="vertical-align: top" valign="top">
                                    <asp:TextBox ID="startDateImageButton" Width="90px" runat="server"></asp:TextBox>
                                    <asp:ImageButton runat="Server" ID="startCalImage" ImageUrl="~/Images/UI/calendar-blue.png" AlternateText="Click to show calendar" Style="vertical-align: middle; padding-bottom:2px" /><br />
                                    <cc1:CalendarExtender ID="startDateCalendarExtender" runat="server" TargetControlID="startDateImageButton" Format="yyyy-MM-dd" PopupButtonID="startCalImage" />
                                </td>
                            </tr>
                            <tr style="vertical-align: top" valign="top">
                                <td style="white-space: nowrap; vertical-align: top; padding-bottom: 6px" align="right" valign="top">
                                    <asp:Label ID="endsOnLabel" runat="server" Text="Ends On:&nbsp;" />
                                </td>
                                <td>
                                    <asp:TextBox ID="endDateImageButton" Width='90px' runat="server"></asp:TextBox>
                                    <asp:ImageButton runat="Server" ID="endCalImage" ImageUrl="~/Images/UI/calendar-blue.png" AlternateText="Click to show calendar" Style="vertical-align: middle; padding-bottom:2px"  /><br />
                                    <cc1:CalendarExtender ID="endDateCalendarExtender" runat="server" TargetControlID="endDateImageButton" Format="yyyy-MM-dd" PopupButtonID="endCalImage" />
                                </td>
                            </tr>
                            <tr>
                                <td width="70" align="right" nowrap="nowrap">
                                    <asp:Label ID="runTimeLabel" runat="server" Text="Run Time:&nbsp;"></asp:Label>
                                    <asp:CustomValidator ID="CustomValidator5" runat="server" Display="Dynamic" ErrorMessage="A valid run time is required." ValidateEmptyText="True" EnableClientScript="False" OnServerValidate="ServerValidateRunTime" ControlToValidate="runTimeTextBox" Text="*" />
                                </td>
                                <td id="Td1" runat="server">
                                    <asp:TextBox ID="runTimeTextBox" runat="server" Width="90px" Wrap="False" />
                                    <asp:Label ID="runTimeFormatLabel" runat="server" Text="(hh:mm am/pm)"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Frequency:
                        <asp:CustomValidator ID="FrequencyValidator" runat="server" Display="Dynamic" ErrorMessage="A frequency value between 1 and 100 is required." ValidateEmptyText="True" EnableClientScript="False" OnServerValidate="ServerValidateFrequency" ControlToValidate="frequencyValue" Text="*" />
                    </td>
                    <td class="ctrl">
                        <asp:TextBox ID="frequencyValue" runat="server" Width="30" Style="vertical-align: middle" />
                        <asp:DropDownList ID="frequencyQualifier" runat="server" Width="100" />
                    </td>
                </tr>
                <tr>
                    <td class="label" style="vertical-align: top">
                        Data Source:
                        <asp:CustomValidator ID="DataSourceValidator" runat="server" Display="Dynamic" ErrorMessage="" ValidateEmptyText="True" EnableClientScript="False" OnServerValidate="ServerValidateDataSource" ControlToValidate="dataSourceRadioButtonList" Text="*" />
                    </td>
                    <td class="ctrl" style="vertical-align: top; padding-right: 8px">
                        <asp:Panel ID="Panel1" runat="server" Style="padding-bottom: 4px; padding-left: 4px" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="3px" Width="98%">
                            <asp:RadioButtonList ID="dataSourceRadioButtonList" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="dataSourceRadioButtonList_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="LocalService">Results of local service execution</asp:ListItem>
                                <asp:ListItem Value="WebServiceSolicit">Results of partner service solicit (Transaction Id)</asp:ListItem>
                                <asp:ListItem Value="WebServiceQuery">Results of partner service query (Xml)</asp:ListItem>
                                <asp:ListItem Value="File">File system resource (network path)</asp:ListItem>
                            </asp:RadioButtonList>
                            <table id="Table1" width="98%" cellpadding="2" cellspacing="0" style="margin-top: 3px; margin-bottom: 3px">
                                <tr valign="middle">
                                    <td align="right" nowrap="nowrap">
                                        <asp:Label ID="fromLabel" runat="server" Text="From:" />
                                    </td>
                                    <td width="100%">
                                        <asp:TextBox ID="fileSourceTextBox" runat="server" Width="90%"></asp:TextBox>
                                        <asp:DropDownList ID="sourceLocalServiceDropDownList" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="sourceLocalServiceDropDownList_SelectedIndexChanged" />
                                        <asp:DropDownList ID="sourcePartnerDropDownList" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="sourcePartnerDropDownList_SelectedIndexChanged" />
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" nowrap="nowrap">
                                        <asp:Label ID="sourceExchangeLabel" runat="server" Text="Exchange:" />
                                    </td>
                                    <td width="100%">
                                        <asp:TextBox ID="sourceExchangeTextBox" runat="server" Width="90%" />
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" nowrap="nowrap">
                                        <asp:Label ID="sourceRequestLabel" runat="server" Text="Request:" />
                                    </td>
                                    <td width="100%">
                                        <asp:TextBox ID="sourceRequestTextBox" runat="server" Width="90%" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="additionalArgumentsPanel" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="3px" Width="98%">
                                <table id="Table2" width="100%" cellpadding="2" cellspacing="0">
                                    <tr valign="middle">
                                        <td>
                                            <asp:Label ID="additionalArgumentsLabel" runat="server" Text="Additional Parameters:" Style="margin-right: 8px" Enabled='<%# !DisableEditing() %>'/>
                                            <asp:RadioButton ID="byNameValueRadioButton" runat="server" Text="By Name" Checked="true" GroupName="ByNameOrIndexGroup" OnCheckedChanged="byValueRadioButton_CheckedChanged" AutoPostBack="True" />
                                            <asp:RadioButton ID="byValueRadioButton" runat="server" Text="By Index" GroupName="ByNameOrIndexGroup" OnCheckedChanged="byIndexRadioButton_CheckedChanged" AutoPostBack="True" />
                                        </td>
                                        <td />
                                        <td />
                                        <td />
                                    </tr>
                                </table>
                                <asp:Panel ID="nameValueArgsPanel" runat="server" Width="100%">
                                    <table id="nameValueArgsTable" width="100%" cellpadding="2" cellspacing="0">
                                        <asp:Repeater runat="server" ID="nameValueArgsRepeaterList">
                                            <HeaderTemplate>
                                                <tr class="rowEven">
                                                    <td style="width: 40%">
                                                        <asp:Label ID="argNameHeaderLabel" runat="server" Text='Name' Font-Bold="True" Enabled='<%# !DisableEditing() %>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="argValueHeaderLabel" runat="server" Text='Value' Font-Bold="True" Enabled='<%# !DisableEditing() %>' />
                                                    </td>
                                                    <td style="width: 14px; padding-left: 8px">
                                                        <asp:ImageButton ID="addArgButtonNameValueHeader" runat="server" Width="100%" ToolTip="Add Argument" ImageUrl="~/Images/UI/plus.png" ImageAlign="NotSet" CommandName="Add" CommandArgument="-1" OnCommand="OnSourceArgsNameValueClick" CausesValidation="False" Visible='<%# !DisableEditing() %>' />
                                                    </td>
                                                    <td />
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="rowOdd" align="left">
                                                    <td style="width: 40%">
                                                        <asp:TextBox ID="argName" runat="server" Width="97%" Text='<%# Eval("Key") %>' Enabled='<%# !DisableEditing() %>'></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="argValue" runat="server" Width="97%" Text='<%# Eval("Value") %>' Enabled='<%# !DisableEditing() %>'></asp:TextBox>
                                                    </td>
                                                    <td style="width: 14px; padding-left: 8px">
                                                        <asp:ImageButton ID="addArgButtonNameValueRow" runat="server" Width="100%" ToolTip="Add Argument" ImageUrl="~/Images/UI/plus.png" CommandName="Add" CommandArgument='<%# Container.ItemIndex%>' OnCommand="OnSourceArgsNameValueClick" CausesValidation="False" Visible='<%# !DisableEditing() %>' />
                                                    </td>
                                                    <td style="width: 14px">
                                                        <asp:ImageButton ID="deleteArgButton" runat="server" Width="100%" ToolTip="Delete Argument" ImageUrl="~/Images/UI/cross.png" CommandName="Delete" CommandArgument='<%# Container.ItemIndex%>' OnCommand="OnSourceArgsNameValueClick" CausesValidation="false" Visible='<%# !DisableEditing() %>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="valueArgsPanel" runat="server" Width="100%" Visible="false">
                                    <table id="Table3" width="100%" cellpadding="2" cellspacing="0">
                                        <asp:Repeater runat="server" ID="valueArgsRepeaterList">
                                            <HeaderTemplate>
                                                <tr class="rowEven">
                                                    <td>
                                                        <asp:Label ID="argValueHeaderLabel" runat="server" Text='Value' Font-Bold="True" Enabled='<%# !DisableEditing() %>' />
                                                    </td>
                                                    <td style="width: 14px; padding-left: 8px">
                                                        <asp:ImageButton ID="addArgButtonValueHeader" runat="server" Width="100%" ToolTip="Add Argument" ImageUrl="~/Images/UI/plus.png" ImageAlign="NotSet" CommandName="Add" CommandArgument="-1" OnCommand="OnSourceArgsNameValueClick" CausesValidation="False" Visible='<%# !DisableEditing() %>' />
                                                    </td>
                                                    <td />
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="rowOdd" align="left">
                                                    <td nowrap="nowrap" valign="middle">
                                                        <asp:Label runat="server" CssClass="label" Text='<%# Container.ItemIndex + 1%>' Width="25px" Style="text-align: right; vertical-align: middle" />
                                                        <asp:TextBox ID="argValue" runat="server" Width="85%" Text='<%# Container.DataItem %>' Wrap="false" Enabled='<%# !DisableEditing() %>' />
                                                    </td>
                                                    <td style="width: 14px; padding-left: 8px">
                                                        <asp:ImageButton ID="addArgButtonValueRow" runat="server" Width="100%" ToolTip="Add Argument" ImageUrl="~/Images/UI/plus.png" CommandName="Add" CommandArgument='<%# Container.ItemIndex%>' OnCommand="OnSourceArgsNameValueClick" CausesValidation="False" Visible='<%# !DisableEditing() %>' />
                                                    </td>
                                                    <td style="width: 14px">
                                                        <asp:ImageButton ID="deleteArgButton" runat="server" Width="100%" ToolTip="Delete Argument" ImageUrl="~/Images/UI/cross.png" CommandName="Delete" CommandArgument='<%# Container.ItemIndex%>' OnCommand="OnSourceArgsNameValueClick" CausesValidation="false" Visible='<%# !DisableEditing() %>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="label" width="50" style="vertical-align: top">
                        Result Process:
                        <asp:CustomValidator ID="ResultProcessValidator" runat="server" Display="Dynamic" ErrorMessage="" ValidateEmptyText="True" EnableClientScript="False" OnServerValidate="ServerValidateResultProcess" ControlToValidate="resultProcessRadioButtonList" Text="*" />
                    </td>
                    <td class="ctrl" align="left" style="vertical-align: top; padding-right: 8px">
                        <asp:Panel ID="Panel2" runat="server" Style="padding-bottom: 4px; padding-left: 4px" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="3px" Width="98%">
                            <asp:Label ID="ResultProcessDescLabel" runat="server" Text="In addition to the saving the results in the Node binary repository, the results of this schedule can be further processed using one of the following options:" Width="100%" Enabled='<%# !DisableEditing() %>'></asp:Label>
                            <asp:RadioButtonList ID="resultProcessRadioButtonList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="resultProcessRadioButtonList_SelectedIndexChanged">
                                <asp:ListItem>None</asp:ListItem>
                                <asp:ListItem Value="Partner">Submit result to an Exchange Network partner</asp:ListItem>
                                <asp:ListItem Value="Schematron">Submit result to Schematron service for validation</asp:ListItem>
                                <asp:ListItem Value="File">Save compressed result to a network directory location</asp:ListItem>
                                <asp:ListItem Value="Email">Send compressed result as an email attachment</asp:ListItem>
                                <asp:ListItem Value="LocalService">Submit results to local service</asp:ListItem>
                            </asp:RadioButtonList>
                            <table id="Table5" width="98%" cellpadding="2" cellspacing="0">
                                <tr valign="middle">
                                    <td align="right" nowrap="nowrap" valign="middle">
                                        <asp:Label ID="toTargetLabel" runat="server" Text="To:" />
                                    </td>
                                    <td width="100%" nowrap="nowrap" valign="middle">
                                        <asp:DropDownList ID="resultPartnerDropDownList" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="resultPartnerDropDownList_SelectedIndexChanged" />
                                        <asp:TextBox ID="fileTargetTextBox" runat="server" Width="90%"></asp:TextBox>
                                        <asp:TextBox ID="emailTargetTextBox" runat="server" Width="90%"></asp:TextBox>
                                        <asp:DropDownList ID="destinationSubmitServiceDropDownList" runat="server" Width="90%" />
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" nowrap="nowrap">
                                        <asp:Label ID="resultExchangeLabel" runat="server" Text="Exchange:" />
                                    </td>
                                    <td width="100%">
                                        <asp:TextBox ID="resultExchangeTextBox" runat="server" Width="90%" />
                                    </td>
                                </tr>
                                <tr valign="middle">
                                    <td align="right" nowrap="nowrap">
                                        <asp:Label ID="resultOperationLabel" runat="server" Text="Operation:" />
                                    </td>
                                    <td width="100%">
                                        <asp:TextBox ID="resultOperationTextBox" runat="server" Width="90%" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="label" width="50">
                        Audit:
                    </td>
                    <td class="ctrl">
                        <asp:Label ID="auditLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="command" colspan="2" align="right">
                        <asp:Button Text="Cancel" CssClass="button" runat="server" ID="cancelBtn" OnClick="CancelItem" CausesValidation="false" />
                        <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SaveDataItem" />
                        <asp:Button Text="Delete" CssClass="button" runat="server" ID="deleteBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this scheduled item?');" OnClick="DeleteDataItem" />
                        <asp:Button Text="Save and Run Now" CssClass="button" runat="server" ID="runNowBtn" CausesValidation="false" OnClick="RunNow" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:UpdateProgressCntl ID="UpdateProgressCntl" runat="server" />
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ScheduleEdit.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ScheduleEdit" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
    <table id="formTable" width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td />
            <td>
                <table id="Table4" width="100%" cellpadding="2" cellspacing="0">
                    <tr>
                        <td valign="top" width="10">
                            <asp:Image ID="iconAlert" runat="server" HeaderText="Please correct the following errors:" ImageUrl="~/Images/icon_alert.gif" />
                        </td>
                        <td>
                            <asp:ValidationSummary ID="validationSummary" runat="server" HeaderText="Please correct the following errors:" Width="98%"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="label" width="50">
                Name:
            </td>
            <td class="ctrl">
                <asp:TextBox ID="nameEdit" runat="server" Text="" Width="350px" />
                <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="Schedule name is required." ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="nameEdit" Text="*" />
                <asp:CheckBox ID="activeCheckBox" runat="server" Text="Active" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50">
                Exchange:
            </td>
            <td class="ctrl">
                <asp:DropDownList ID="flowDropDownList" runat="server" Width="350px" AutoPostBack="True" onselectedindexchanged="flowDropDownList_SelectedIndexChanged" />
                <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage="Schedule exchange is required." ValidateEmptyText="True" OnServerValidate="ServerValidateNotSelectedControl" ControlToValidate="flowDropDownList" Text="*" />
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="vertical-align: top">
                Availability:
            </td>
            <td class="ctrl" valign="top">
                <table id="formTable1" width="100%" cellpadding="2" cellspacing="0">
                    <tr valign="middle">
                        <td width="70" align="right" nowrap="nowrap">
                            <asp:Label ID="Label1" runat="server" Text="Starts On:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="startDateImageButton" Width='90px' runat="server"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="startCalImage" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" /><br />
                            <cc1:CalendarExtender ID="startDateCalendarExtender" runat="server" TargetControlID="startDateImageButton" Format="yyyy-MM-dd" PopupButtonID="startCalImage" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="A valid start date is required." ValidateEmptyText="True" OnServerValidate="ServerValidateDate" ControlToValidate="startDateImageButton" Text="*" />
                            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Start date must be less than end date." ValidateEmptyText="False" OnServerValidate="ServerValidateStartEndDates" ControlToValidate="startDateImageButton" Text="*" />
                        </td>
                    </tr>
                    <tr>
                        <td width="70" align="right" nowrap="nowrap">
                            <asp:Label ID="Label4" runat="server" Text="Ends On:" />
                        </td>
                        <td>
                            <asp:TextBox ID="endDateImageButton" Width='90px' runat="server"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="endCalImage" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" /><br />
                            <cc1:CalendarExtender ID="endDateCalendarExtender" runat="server" TargetControlID="endDateImageButton" Format="yyyy-MM-dd" PopupButtonID="endCalImage" />
                            <asp:CustomValidator ID="vldCode" runat="server" ErrorMessage="A valid end date is required." ValidateEmptyText="True" OnServerValidate="ServerValidateDate" ControlToValidate="endDateImageButton" Text="*" />
                        </td>
                    </tr>
                    <tr>
                        <td width="70" align="right" nowrap="nowrap">
                            <asp:Label ID="Label2" runat="server" Text="Run Time:"></asp:Label>
                        </td>
                        <td id="Td1" runat="server">
                            <asp:TextBox ID="runTimeTextBox" runat="server" Width="90px" Wrap="False" />
                            <asp:Label ID="Label3" runat="server" Text="(hh:mm am/pm)"></asp:Label>
                            <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="A valid run time is required." ValidateEmptyText="True" OnServerValidate="ServerValidateRunTime" ControlToValidate="runTimeTextBox" Text="*" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="label" width="100">
                Frequency:
            </td>
            <td class="ctrl">
                <asp:TextBox ID="frequencyValue" runat="server" Width="30" Style="vertical-align: middle" />
                <asp:DropDownList ID="frequencyQualifier" runat="server" Width="100" />
                <asp:RangeValidator ID="frequencyValueValidator" runat="server" CssClass="error" Text="*" ErrorMessage="A frequency value between 1 and 100 is required." ControlToValidate="frequencyValue" EnableClientScript="false" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="frequencyValueRequiredFieldValidator" runat="server" CssClass="error" Text="*" ErrorMessage="A frequency qualifier is required." ControlToValidate="frequencyValue" EnableClientScript="false"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="label" width="100" style="vertical-align: top">
                Data Source:
            </td>
            <td class="ctrl">
                <asp:RadioButtonList ID="dataSourceRadioButtonList" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="dataSourceRadioButtonList_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="LocalService">Results of local service execution</asp:ListItem>
                    <asp:ListItem Value="WebServiceSolicit">Results of partner service solicit (Transaction Id)</asp:ListItem>
                    <asp:ListItem Value="WebServiceQuery">Results of partner service query (Xml)</asp:ListItem>
                    <asp:ListItem Value="File">File system resource (network path)</asp:ListItem>
                </asp:RadioButtonList>
                <table id="Table1" width="98%" cellpadding="2" cellspacing="0">
                    <tr valign="middle">
                        <td align="right" nowrap="nowrap">
                            <asp:Label ID="fromLabel" runat="server" Text="From:" />
                        </td>
                        <td width="100%">
                            <asp:TextBox ID="fileSourceTextBox" runat="server" Width="90%"></asp:TextBox>
                            <asp:DropDownList ID="sourceLocalServiceDropDownList" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="sourceLocalServiceDropDownList_SelectedIndexChanged" />
                            <asp:DropDownList ID="sourcePartnerDropDownList" runat="server" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="sourcePartnerDropDownList_SelectedIndexChanged" />
                            <asp:CustomValidator ID="fileSourceTextBoxValidator" runat="server" ErrorMessage="A file system resource path is required." ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="fileSourceTextBox" Text="*" />
                <asp:CustomValidator ID="sourcePartnerDropDownListValidator" runat="server" ErrorMessage="Source partner is required." ValidateEmptyText="True" OnServerValidate="ServerValidateNotSelectedControl" ControlToValidate="sourcePartnerDropDownList" Text="*" />
                <asp:CustomValidator ID="sourceLocalServiceDropDownListValidator" runat="server" ErrorMessage="Source local service is required." ValidateEmptyText="True" OnServerValidate="ServerValidateNotSelectedControl" ControlToValidate="sourceLocalServiceDropDownList" Text="*" />
                        </td>
                    </tr>
                    <tr valign="middle">
                        <td align="right" nowrap="nowrap">
                            <asp:Label ID="sourceExchangeLabel" runat="server" Text="Exchange:" />
                        </td>
                        <td width="100%">
                            <asp:TextBox ID="sourceExchangeTextBox" runat="server" Width="90%" />
                            <asp:CustomValidator ID="customValidatorSourceExchange" runat="server" ErrorMessage="Source exchange is required." ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="sourceExchangeTextBox" Text="*" />
                        </td>
                    </tr>
                    <tr valign="middle">
                        <td align="right" nowrap="nowrap">
                            <asp:Label ID="sourceRequestLabel" runat="server" Text="Request:" />
                        </td>
                        <td width="100%">
                            <asp:TextBox ID="sourceRequestTextBox" runat="server" Width="90%" />
                            <asp:CustomValidator ID="customValidatorSourceRequest" runat="server" ErrorMessage="Source request is required." ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="sourceRequestTextBox" Text="*" />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="additionalArgumentsPanel" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="3px" Width="98%">
                    <table id="Table2" width="100%" cellpadding="2" cellspacing="0">
                        <tr valign="middle">
                            <td>
                                <asp:Label ID="additionalArgumentsLabel" runat="server" Text="Additional Parameters:" Style="margin-right: 8px" />
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
                                        <td style="width: 30%">
                                            <asp:Label ID="argName" runat="server" Text='Name' Font-Bold="True" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='Value' Font-Bold="True" />
                                        </td>
                                        <td style="width: 14px; padding-left: 8px">
                                            <asp:ImageButton ID="addArgButton" runat="server" Width="100%" ToolTip="Add Argument" ImageUrl="~/Images/Add2.png" ImageAlign="NotSet" CommandName="Add" CommandArgument="-1" OnCommand="OnSourceArgsNameValueClick" CausesValidation="false"/>
                                        </td>
                                        <td />
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="rowOdd" align="left">
                                        <td style="width: 30%">
                                            <asp:TextBox ID="argName" runat="server" Width="97%" Text='<%# Eval("Key") %>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="argValue" runat="server" Width="97%" Text='<%# Eval("Value") %>'></asp:TextBox>
                                        </td>
                                        <td style="width: 14px; padding-left: 8px">
                                            <asp:ImageButton ID="addArgButton" runat="server" Width="100%" ToolTip="Add Argument" ImageUrl="~/Images/Add2.png" CommandName="Add" CommandArgument='<%# Container.ItemIndex%>' OnCommand="OnSourceArgsNameValueClick" CausesValidation="false"/>
                                        </td>
                                        <td style="width: 14px">
                                            <asp:ImageButton ID="deleteArgButton" runat="server" Width="100%" ToolTip="Delete Argument" ImageUrl="~/Images/Delete2.png" CommandName="Delete" CommandArgument='<%# Container.ItemIndex%>' OnCommand="OnSourceArgsNameValueClick" CausesValidation="false"/>
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
                                            <asp:Label ID="Label6" runat="server" Text='Value' Font-Bold="True" />
                                        </td>
                                        <td style="width: 14px; padding-left: 8px">
                                            <asp:ImageButton ID="addArgButton" runat="server" Width="100%" ToolTip="Add Argument" ImageUrl="~/Images/Add2.png" ImageAlign="NotSet" CommandName="Add" CommandArgument="-1" OnCommand="OnSourceArgsNameValueClick" CausesValidation="false"/>
                                        </td>
                                        <td />
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="rowOdd" align="left">
                                        <td nowrap="nowrap" valign="middle">
                                            <asp:Label runat="server" CssClass="label" Text='<%# Container.ItemIndex + 1%>' Width="25px" style="text-align:right; vertical-align:middle"/>
                                            <asp:TextBox ID="argValue" runat="server" Width="85%" Text='<%# Container.DataItem %>' Wrap="false" />
                                        </td>
                                        <td style="width: 14px; padding-left: 8px">
                                            <asp:ImageButton ID="addArgButton" runat="server" Width="100%" ToolTip="Add Argument" ImageUrl="~/Images/Add2.png" CommandName="Add" CommandArgument='<%# Container.ItemIndex%>' OnCommand="OnSourceArgsNameValueClick" CausesValidation="false"/>
                                        </td>
                                        <td style="width: 14px">
                                            <asp:ImageButton ID="deleteArgButton" runat="server" Width="100%" ToolTip="Delete Argument" ImageUrl="~/Images/Delete2.png" CommandName="Delete" CommandArgument='<%# Container.ItemIndex%>' OnCommand="OnSourceArgsNameValueClick" CausesValidation="false"/>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="label" width="50" style="vertical-align: top">
                Result Process:
            </td>
            <td class="ctrl" align="left">
                <asp:Label ID="Label5" runat="server" Text="In addition to the saving the results in the Node binary repository, the results of this schedule can be further processed using one of the following options:" Width="100%"></asp:Label>
                <asp:RadioButtonList ID="resultProcessRadioButtonList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="resultProcessRadioButtonList_SelectedIndexChanged">
                    <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem Value="Partner">Submit result to an Exchange Network partner</asp:ListItem>
                    <asp:ListItem Value="Schematron">Submit result to Schematron service for validation</asp:ListItem>
                    <asp:ListItem Value="File">Save compressed result to a network directory location</asp:ListItem>
                    <asp:ListItem Value="Email">Send compressed result as an email attachment</asp:ListItem>
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
                            <asp:CustomValidator ID="fileTargetTextBoxValidator" runat="server" ErrorMessage="A valid network directory location is required." ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="fileTargetTextBox" Text="*" />
                            <asp:CustomValidator ID="emailTargetTextBoxValidator" runat="server" ErrorMessage="A valid email is required to send the compressed result." ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="emailTargetTextBox" Text="*" />
                 <asp:CustomValidator ID="resultPartnerDropDownListValidator" runat="server" ErrorMessage="Submit partner is required." ValidateEmptyText="True" OnServerValidate="ServerValidateNotSelectedControl" ControlToValidate="resultPartnerDropDownList" Text="*" />
                       </td>
                    </tr>
                    <tr valign="middle">
                        <td align="right" nowrap="nowrap">
                            <asp:Label ID="resultExchangeLabel" runat="server" Text="Exchange:" />
                        </td>
                        <td width="100%">
                            <asp:TextBox ID="resultExchangeTextBox" runat="server" Width="90%" />
                            <asp:CustomValidator ID="resultExchangeTextBoxValidator" runat="server" ErrorMessage="Result exchange is required." ValidateEmptyText="True" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="resultExchangeTextBox" Text="*" />
                        </td>
                    </tr>
                    <tr valign="middle">
                        <td align="right" nowrap="nowrap">
                            <asp:Label ID="resultOperationLabel" runat="server" Text="Operation:" />
                        </td>
                        <td width="100%">
                            <asp:TextBox ID="resultOperationTextBox" runat="server" Width="90%" />
                            <asp:CustomValidator ID="resultOperationTextBoxValidator" runat="server" ErrorMessage="Result operation is required." ValidateEmptyText="False" OnServerValidate="ServerValidateRequiredIfVisible" ControlToValidate="resultOperationTextBox" Text="*" />
                        </td>
                    </tr>
                </table>
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
                <asp:Button Text="Cancel" CssClass="button" runat="server" OnClick="CancelItem" CausesValidation="false" />
                <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="SaveDataItem" />
                <asp:Button Text="Delete" CssClass="button" runat="server" ID="deleteBtn" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this scheduled item?');" OnClick="DeleteDataItem" />
                <asp:Button Text="Save and Run Now" CssClass="button" runat="server" ID="runNowBtn" CausesValidation="false" OnClick="RunNow" />
            </td>
        </tr>
    </table>
</asp:Content>

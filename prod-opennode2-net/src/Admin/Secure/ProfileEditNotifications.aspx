<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ProfileEditNotifications.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ProfileEditNotifications" Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>

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
    <table id="formTable" width="600px" cellpadding="2" cellspacing="0">
        <asp:Repeater runat="server" ID="repeaterList">
            <ItemTemplate>
                <tr class="rowOdd">
                    <td width="20">
                        <img alt="" src="../Images/UI/globe-network.png" style="border: 0; vertical-align: middle; padding-right: 3px;" />
                    </td>
                    <td align="left">
                        <%# Server.HtmlEncode((string)Eval("Value.Name"))%>
                    </td>
                    <td width="100%" align="right">
                        <asp:CheckBoxList ID="checkBoxList" runat="server" RepeatDirection="Horizontal" CellSpacing="6">
                            <asp:ListItem Value="OnSolicit">Solicit</asp:ListItem>
                            <asp:ListItem Value="OnQuery">Query</asp:ListItem>
                            <asp:ListItem Value="OnSubmit">Submit</asp:ListItem>
                            <asp:ListItem Value="OnNotify">Notify</asp:ListItem>
                            <asp:ListItem Value="OnDownload">Download</asp:ListItem>
                            <asp:ListItem Value="OnExecute">Execute</asp:ListItem>
                            <asp:ListItem Value="OnSchedule">Schedule</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="toggleButton" runat="server" Text="Toggle" OnClick="OnToggleClick" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="rowEven">
                    <td width="20">
                        <img alt="" src="../Images/UI/globe-network.png" style="border: 0; vertical-align: middle; padding-right: 3px;" />
                    </td>
                    <td align="left">
                        <%# Server.HtmlEncode((string)Eval("Value.Name"))%>
                    </td>
                    <td width="100%" align="right">
                        <asp:CheckBoxList ID="checkBoxList" runat="server" RepeatDirection="Horizontal" CellSpacing="6">
                            <asp:ListItem Value="OnSolicit">Solicit</asp:ListItem>
                            <asp:ListItem Value="OnQuery">Query</asp:ListItem>
                            <asp:ListItem Value="OnSubmit">Submit</asp:ListItem>
                            <asp:ListItem Value="OnNotify">Notify</asp:ListItem>
                            <asp:ListItem Value="OnDownload">Download</asp:ListItem>
                            <asp:ListItem Value="OnExecute">Execute</asp:ListItem>
                            <asp:ListItem Value="OnSchedule">Schedule</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="toggleButton" runat="server" Text="Toggle" OnClick="OnToggleClick" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
        <tr>
            <td class="command" colspan="100%" align="right">
                <input type="button" value="Cancel" class="button" onclick="location.href='Profile.aspx'" />
                <asp:Button Text="Save" CssClass="button" runat="server" ID="saveBtn" OnClick="OnSaveClick" />
            </td>
        </tr>
    </table>
</asp:Content>

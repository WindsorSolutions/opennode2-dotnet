<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Flow.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.Flow" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

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
    <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
    </div>
    <asp:HiddenField ID="idCtrl" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div>
                <table id="wrapperTable" width="600px" cellpadding="0" cellspacing="0" border="0" class="basicTable">
                    <tr>
                        <td class="command" align="left" style="width: 100%;">
                            <asp:LinkButton ID="ExpandAllLinkButton" runat="server" CausesValidation="false" Style="padding-right: 12px" ToolTip="Expand all flows" OnClick="ExpandAllLinkButton_Click">
                            <asp:Image runat="server" ImageUrl="~/Images/UI/expand_16.png" style="vertical-align:middle"/>
                            Expand All
                            </asp:LinkButton>
                            <asp:LinkButton ID="CollapseAllLinkButton" runat="server" CausesValidation="false" ToolTip="Collapse all flows" OnClick="CollapseAllLinkButton_Click">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/UI/collapse_16.png" Style="vertical-align: middle" />
                                Collapse All
                            </asp:LinkButton>
                        </td>
                        <td class="command" align="right">
                            <asp:Button Text="Add Exchange" CssClass="button" runat="server" ID="addExchangeBtn" OnClick="OnAddFlowClick" />
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="flowRepeaterList">
                        <ItemTemplate>
                            <tr style="background-color: #83ACCA">
                                <td style="width: 100%; padding: 2px; text-align: left" align="left">
                                    <asp:ImageButton ID="expandCollapseServicesImageButton" runat="server" CausesValidation="false" Style="vertical-align: middle;"
                                        OnClick="OnExpandCollapseServicesClick" CommandArgument='<%#Eval("Id")%>' />
                                    <a href='../Secure/FlowEdit.aspx?id=<%#Eval("Id")%>' style="color: White; font-weight: bold;" title="<%#FlowToolTipEditName(Container.DataItem)%>">
                                        <img src="../Images/UI/globe-network.png" alt="" align="middle" style="border-width: 0px; vertical-align: middle; padding-top: 2px; padding-bottom: 2px; padding-right: 3px; padding-left: 3px;" />
                                        <%#FlowDisplayName(Container.DataItem)%>
                                    </a>
                                </td>
                                <td style="width: 30px" align="right">
                                    <a href='../Secure/FlowEdit.aspx?id=<%#Eval("Id")%>' title="<%#FlowToolTipEditName(Container.DataItem)%>">
                                        <img src="../Images/UI/application_form_edit.png" align="middle" style="border-width: 0px; padding-left: 4px; padding-right: 4px;" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <asp:Repeater runat="server" ID="serviceRepeaterList">
                                <ItemTemplate>
                                    <tr style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC": "background-color: #DCDCDC; color: #3366CC"%>'>
                                        <td style="width: 100%; padding: 2px; text-align: left" align="left">
                                            <a href='../Secure/FlowServiceEdit.aspx?serviceid=<%#Eval("Id")%>&flowid=<%#Eval("FlowId")%>' title="<%#ServiceToolTipEditName(Container.DataItem)%>" class="listlabel">
                                                <img src="../Images/UI/block.png" alt="" align="middle" style="border-width: 0px; vertical-align: middle; padding-left: 12px; padding-right: 4px" />
                                                <strong><%#ServiceDisplayName(Container.DataItem)%></strong>&nbsp;&nbsp;(<%#ServiceDisplayDescription(Container.DataItem)%>) 
                                            </a>
                                        </td>
                                        <td style="width: 30px" align="right">
                                            <a href='../Secure/FlowServiceEdit.aspx?serviceid=<%#Eval("Id")%>&flowid=<%#Eval("FlowId")%>'>
                                                <img src="../Images/UI/application_form_edit.png" title="<%#ServiceToolTipEditName(Container.DataItem)%>" align="middle" alt="" style="border-width: 0px; padding-left: 4px; padding-right: 4px;" />
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr style="<%#FlowServicesDisplay(Container.DataItem)%>">
                                <td colspan="2" align="right" style="width: 100%">
                                    <asp:Button Text="Add Service" CssClass="button" Height="24px" Width="92px" runat="server" ID="addServiceBtn" Visible='<%#CanEditFlowByName((string)Eval("FlowName"))%>' OnCommand="OnAddService" CommandArgument='<%#Eval("Id")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px; width: 100%" colspan="2">
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:UpdateProgressCntl ID="UpdateProgressCntl" runat="server" />
</asp:Content>

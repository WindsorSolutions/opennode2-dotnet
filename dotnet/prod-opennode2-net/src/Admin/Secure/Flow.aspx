<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Flow.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.Flow" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

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
    <table id="wrapperTable" width="600px" cellpadding="2" cellspacing="0" class="basicTable">
        <tr>
            <td class="command" colspan="3" align="right">
                <asp:Button Text="Add Exchange" CssClass="button" runat="server" ID="addExchangeBtn" OnClick="OnAddFlowClick" />
            </td>
        </tr>
        <asp:Repeater runat="server" ID="flowRepeaterList">
            <ItemTemplate>
                <tr>
                    <tr style="background-color: #83ACCA">
                        <td style="width:100%">
                            <a href='../Secure/FlowEdit.aspx?id=<%#Eval("Id")%>' style="color: White; font-weight: bold;" title="<%#FlowToolTipEditName(Container.DataItem)%>">
                                <img src="../Images/UI/globe-network.png" alt="" align="middle" style="border-width: 0px; vertical-align: middle; padding-top: 2px; padding-bottom: 2px; padding-right: 3px; padding-left: 3px;" />
                                <%#FlowDisplayName(Container.DataItem)%>
                            </a>
                        </td>
                        <td style="width:20px" align="right">
                            <a href='../Secure/FlowEdit.aspx?id=<%#Eval("Id")%>' title="<%#FlowToolTipEditName(Container.DataItem)%>">
                                <img src="../Images/UI/application_form_edit.png" align="middle" style="border-width: 0px;padding-left:4px;padding-right:4px;" alt="" />
                            </a>
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="serviceRepeaterList">
                        <ItemTemplate>
                            <tr style='<%# Container.ItemIndex % 2 == 0 ? "background-color: #E3ECF3; color: #3366CC" : "background-color: #DCDCDC; color: #3366CC"%>'>
                                <td style="width:100%">
                                    <a href='../Secure/FlowServiceEdit.aspx?serviceid=<%#Eval("Id")%>&flowid=<%#Eval("FlowId")%>' title="<%#ServiceToolTipEditName(Container.DataItem)%>" class="listlabel">
                                        <img src="../Images/UI/block.png" alt="" align="middle" style="border-width: 0px; vertical-align: middle; padding-left:4px; padding-right:4px" />
                                        <strong><%#ServiceDisplayName(Container.DataItem)%></strong>&nbsp;&nbsp;(<%#ServiceDisplayDescription(Container.DataItem)%>) 
                                </a>
                                </td>
                                <td style="width:10px" align="right">
                                    <a href='../Secure/FlowServiceEdit.aspx?serviceid=<%#Eval("Id")%>&flowid=<%#Eval("FlowId")%>'>
                                        <img src="../Images/UI/application_form_edit.png" title="<%#ServiceToolTipEditName(Container.DataItem)%>" align="middle" alt="" style="border-width: 0px;padding-left:4px;padding-right:4px; " />
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Button Text="Add Service" CssClass="button" Height="24px" Width="92px" runat="server" ID="addServiceBtn" Visible='<%#CanEditFlowByName((string)Eval("FlowName"))%>' OnCommand="OnAddService" CommandArgument='<%#Eval("Id")%>' />
                        </td>
                    </tr>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

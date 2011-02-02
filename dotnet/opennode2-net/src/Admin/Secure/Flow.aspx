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
                        <td width="20">
                            <img alt="" src='..\Images\Flow2.gif' style="border: 0; vertical-align: middle; padding-right: 3px;" />
                        </td>
                        <td width="100%">
                            <a href='../Secure/FlowEdit.aspx?id=<%#Eval("Id")%>' style="color: White; font-weight: bold;">
                                <%#FlowDisplayName(Container.DataItem)%>
                            </a>
                        </td>
                        <td width="10" align="right">
                            <a href='../Secure/FlowEdit.aspx?id=<%#Eval("Id")%>'>
                                <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="absmiddle" style="border-width: 0px;" />
                            </a>
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="serviceRepeaterList">
                        <ItemTemplate>
                            <tr style="background-color: #E3ECF3; color: #3366CC">
                                <td width="20" />
                                <td width="100%">
                                    <a href='../Secure/FlowServiceEdit.aspx?serviceid=<%#Eval("Id")%>&flowid=<%#Eval("FlowId")%>' class="listlabel">
                                        <img src="../Images/icon_world_dynamic.gif" alt="Edit" align="absmiddle" style="border-width: 0px; vertical-align: middle; padding-right: 3px;" />
                                        <strong><%#ServiceDisplayName(Container.DataItem)%></strong>&nbsp;&nbsp;(<%#ServiceDisplayDescription(Container.DataItem)%>) 
                                </a>
                                </td>
                                <td width="10" align="right">
                                    <a href='../Secure/FlowServiceEdit.aspx?serviceid=<%#Eval("Id")%>&flowid=<%#Eval("FlowId")%>'>
                                        <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="absmiddle" style="border-width: 0px;" />
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #DCDCDC; color: #3366CC">
                                <td width="20" />
                                <td width="100%">
                                    <a href='../Secure/FlowServiceEdit.aspx?serviceid=<%#Eval("Id")%>&flowid=<%#Eval("FlowId")%>' class="listlabel">
                                        <img src="../Images/icon_world_dynamic.gif" alt="Edit" align="absmiddle" style="border-width: 0px; vertical-align: middle; padding-right: 3px;" />
                                        <strong><%#ServiceDisplayName(Container.DataItem)%></strong>&nbsp;&nbsp;(<%#ServiceDisplayDescription(Container.DataItem)%>) 
                                    </a>
                                </td>
                                <td width="10" align="right">
                                    <a href='../Secure/FlowServiceEdit.aspx?serviceid=<%#Eval("Id")%>&flowid=<%#Eval("FlowId")%>'>
                                        <img src="../Images/action_go.gif" alt="Edit" title="Edit" align="absmiddle" style="border-width: 0px;" />
                                    </a>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="100%" align="right">
                            <asp:Button Text="Add Service" CssClass="button" Height="24px" Width="92px" runat="server" ID="addServiceBtn" OnCommand="OnAddService" CommandArgument='<%#Eval("Id")%>' />
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

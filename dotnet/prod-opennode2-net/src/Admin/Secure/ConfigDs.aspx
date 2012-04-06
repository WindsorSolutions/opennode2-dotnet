<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ConfigDs.aspx.cs" Inherits="Windsor.Node2008.Admin.Secure.ConfigDs" Title="Untitled Page" MaintainScrollPositionOnPostback="true"%>

<%@ Register Src="../Controls/SimpleList.ascx" TagName="SimpleList" TagPrefix="uc1" %>
<%@ Register Src="../Controls/SimpleStackList.ascx" TagName="SimpleStackList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SecureContentHolder" runat="server">

    <div id="pageTitle"><%= SectionTitle %></div>

    <uc1:SimpleStackList ID="list" runat="server" />
</asp:Content>

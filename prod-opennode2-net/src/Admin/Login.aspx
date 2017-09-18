<%@ Page Language="C#" MasterPageFile="~/AnonMaster.Master" AutoEventWireup="true"
    Codebehind="Login.aspx.cs" Inherits="Windsor.Node2008.Admin.Login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AnonContentHolder" runat="server">
    <div id="pageTitle">
        Welcome to OpenNode2 Admin</div>
    <div class="introText">
        <p>
            The purpose of this application is to enable you to manage all aspects of the operation of your Network Node.  If you encounter any problems when using the Node Admin, please contact the Node Administrator by clicking on the support link at the bottom of each page.</p>
        <p>
            Please enter your NAAS user account and password to login to the Node Admin.
        </p>
        <br>&nbsp;</br>
    </div>
    
    <div runat="server" id="divPageError" visible="false" class="error" enableviewstate="false">
    
    </div>
    
    <table id="formTable" width="400" cellpadding="0" cellspacing="0">        
        <tr>
            <td class="label" width="50">
                Account:</td>
            <td class="ctrl">
                <input runat="server" id="username" type="text" name="username" class="textbox" style="width: 95%;"
                    size="95" /><asp:RequiredFieldValidator ID="usernameVal" runat="server" CssClass="error"
                        Display="Dynamic" ErrorMessage="Required" ControlToValidate="username"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="label" width="50">
                Password:</td>
            <td class="ctrl">
                <input runat="server" id="password" type="password" name="password" class="textbox"
                    style="width: 95%;" size="95" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" CssClass="error" Display="Dynamic" ErrorMessage="Required" ControlToValidate="password"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="command" colspan="2" align="right">
                <asp:Button Text="Login" CssClass="button" runat="server" ID="loginBtn" OnClick="DoLogin" />
<%--                <input runat="server" id="submit" type="submit" value="Login" class="button" causesvalidation="true" />
--%>            </td>
        </tr>
    </table>
</asp:Content>

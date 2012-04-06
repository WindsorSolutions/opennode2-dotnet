<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateProgressCntl.ascx.cs" Inherits="Windsor.Node2008.Admin.Controls.UpdateProgressCntl" %>
<asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel" ID="UpdateProgress" runat="server" Visible="true" DisplayAfter="300">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <img alt="Loading" src="../Images/UI/Progress_white.gif" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

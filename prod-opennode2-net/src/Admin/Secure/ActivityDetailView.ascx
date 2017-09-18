<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityDetailView.ascx.cs" Inherits="Windsor.Node2008.Admin.Secure.ActivityDetailView" %>
<asp:GridView ID="activityDetailGridView" runat="server" AutoGenerateColumns="False" ShowHeader="False" BackColor="White" CellPadding="3" CellSpacing="1" ForeColor="Black" GridLines="Horizontal" onrowdatabound="activityDetailGridView_RowDataBound">
    <RowStyle Wrap="True" />
    <Columns>
        <asp:BoundField DataField="TimeStamp" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd HH:mm:ss.fff}" >
            <ItemStyle Wrap="False" VerticalAlign="Top" />
        </asp:BoundField>
        <asp:BoundField DataField="Message" ReadOnly="True">
            <ItemStyle Wrap="True" />
        </asp:BoundField>
    </Columns>
</asp:GridView>

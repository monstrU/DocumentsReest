<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocNames.aspx.cs" Inherits="DocumentsReestr.PopupButtons.PopUpPages.DocNames" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Справочник типов документов</title>
    <link href="/DefaultTheme/main.css" rel="stylesheet" />
    <link href="/DefaultTheme/container.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Типы документов</h2>
        <asp:GridView ID="gvDocNames" runat="server" AutoGenerateColumns="False"  DataKeyNames="DocNameId,Name,TermExecutionDays" ItemType="DomainModel.DocNameModel" OnSelectedIndexChanged="gvDocNames_SelectedIndexChanged" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:CommandField SelectText="выбрать" ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="шаблонное название" />
                <asp:BoundField DataField="TermExecutionDays" HeaderText="срок исполнения в днях" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </div>
        <div>
            <asp:Button ID="btnCancel" runat="server" Text="отменить" />
        </div>
    </form>
</body>
</html>

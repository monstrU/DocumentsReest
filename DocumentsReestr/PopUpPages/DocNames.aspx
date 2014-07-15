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
        <asp:GridView ID="gvDocNames" runat="server" AutoGenerateColumns="False"  DataKeyNames="DocNameId,Name,TermExecutionDays" ItemType="DomainModel.DocNameModel" OnSelectedIndexChanged="gvDocNames_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:CommandField SelectText="выбрать" ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="шаблонное название" />
                <asp:BoundField DataField="TermExecutionDays" HeaderText="срок исполнения в днях" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
        <div>
            <asp:Button ID="btnCancel" runat="server" Text="отменить" />
        </div>
    </form>
</body>
</html>

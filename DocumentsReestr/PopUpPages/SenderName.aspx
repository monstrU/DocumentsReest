<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SenderName.aspx.cs" Inherits="DocumentsReestr.PopupButtons.PopUpPages.SenderName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/DefaultTheme/main.css" rel="stylesheet" />
    <link href="/DefaultTheme/container.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Отправители документов</h2>
            <asp:GridView ID="gvSenders" runat="server" AutoGenerateColumns="False" ItemType="ReestrModel.DocSender" DataKeyNames="DocSenderId,SenderName" OnSelectedIndexChanged="gvSenders_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField SelectText="выбрать" ShowSelectButton="True" />
                    <asp:BoundField DataField="SenderName" HeaderText="отправитель" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="btnCancel" runat="server" Text="отменить" />
        </div>
    </form>
</body>
</html>

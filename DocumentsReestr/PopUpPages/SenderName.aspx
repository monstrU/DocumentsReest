<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SenderName.aspx.cs" Inherits="DocumentsReestr.PopupButtons.PopUpPages.SenderName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Отправители документов</h2>
            <asp:GridView ID="gvSenders" runat="server" AutoGenerateColumns="False" ItemType="ReestrModel.DocSender" DataKeyNames="DocSenderId, SenderName" OnSelectedIndexChanged="gvSenders_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="выбрать" ShowSelectButton="True" />
                    <asp:BoundField DataField="SenderName" HeaderText="отправитель" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="btnCancel" runat="server" Text="отменить" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocNames.aspx.cs" Inherits="DocumentsReestr.PopupButtons.PopUpPages.DocNames" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Справочник типов документов</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Типы документов</h2>
        <asp:GridView ID="gvDocNames" runat="server" AutoGenerateColumns="False"  DataKeyNames="DocNameId" ItemType="DomainModel.DocNameModel">
            <Columns>
                <asp:CommandField SelectText="выбрать" ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="шаблонное название" />
                <asp:BoundField DataField="TermExecutionDays" HeaderText="срок исполнения в днях" />
            </Columns>
        </asp:GridView>
    </div>
        <div>
            <asp:Button ID="btnSave" runat="server" Text="сохранить" />
            <asp:Button ID="btnCancel" runat="server" Text="отменить" />
        </div>
    </form>
</body>
</html>

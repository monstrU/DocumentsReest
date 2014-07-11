<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentCard.aspx.cs" Inherits="DocumentsReestr.PopupButtons.PopUpPages.DocumentCard" %>

<%@ Register TagPrefix="asp" Namespace="RCO.PopUpButtons" Assembly="PopUpButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Карта документа</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView ID="fvDocument" runat="server">
                <InsertItemTemplate>
                    <table>
                        <tr>
                            <td>название документа</td>
                            <td>
                                <asp:TextBox ID="txtDocName" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>дата приема</td>
                            <td>
                                <asp:TextBox ID="txtDateAdmission" runat="server"></asp:TextBox><asp:PopUpButton runat="server" ID="pbtnDocName" Url="~/PopUpPages/DocNames.aspx" windowWidth="600px" windowHeight="500px" Text="..." IsResizable="True"></asp:PopUpButton></td>
                        </tr>
                        <tr>
                            <td>ФИО отправителя</td>
                            <td>
                                <asp:TextBox ID="txtSenderName" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>срок исполнения</td>
                            <td>
                                <asp:TextBox ID="txtTermExecution" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>комментарии</td>
                            <td>
                                <asp:TextBox ID="txtComments" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </InsertItemTemplate>
            </asp:FormView>
        </div>
        <div>
            <asp:Label runat="server" ID="lblError" EnableViewState="false" CssClass="error_box"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnOk" runat="server" Text="сохранить" OnClick="btnOk_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="отменить" />
        </div>
    </form>
</body>
</html>

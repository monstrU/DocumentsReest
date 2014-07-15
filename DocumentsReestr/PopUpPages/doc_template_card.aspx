<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doc_template_card.aspx.cs" Inherits="DocumentsReestr.PopupButtons.PopUpPages.doc_template_card" %>

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
            <asp:FormView ID="fvDocTemplate" runat="server" ItemType="DomainModel.DocNameModel" CellPadding="4" ForeColor="#333333">
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <InsertItemTemplate>
                    <table>
                        <tr>
                            <td>название документа</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>дата исполнения в днях</td>
                            <td>
                                <asp:TextBox ID="txtTermExecution" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </InsertItemTemplate>
                <EditItemTemplate>
                      <table>
                        <tr>
                            <td>название документа</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" Text="<%# Item.Name %>"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>дата исполнения в днях</td>
                            <td>
                                <asp:TextBox ID="txtTermExecution" runat="server" Text="<%# Item.TermExecutionDays %>"></asp:TextBox></td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:FormView>
        </div>
        <div>
            <asp:Label runat="server" EnableViewState="False" CssClass="error_box" ID="lblError"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnSave" runat="server" Text="сохранить" OnClick="btnSave_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="удалить" OnClick="btnDelete_Click"  />
            <asp:Button ID="btnCancel" runat="server" Text="отменить" />
        </div>
    </form>
</body>
</html>

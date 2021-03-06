﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doc_template_card.aspx.cs" Inherits="DocumentsReestr.PopupButtons.PopUpPages.doc_template_card" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Справочник типов документов</title>
    <link href="/DefaultTheme/main.css" rel="stylesheet" />
    <link href="/DefaultTheme/container.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/jquery.filter_input.js"></script>
</head>
    <script>
            $(document).ready(function() {
                $('.numeric_box').filter_input({ regex: '[0-9]' });
            });
    </script>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView ID="fvDocTemplate" runat="server" ItemType="DomainModel.DocNameModel" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Both">
                <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <InsertItemTemplate>
                    <table>
                        <tr>
                            <td>название документа</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDocName" ControlToValidate="txtName" runat="server" ErrorMessage="*" Display="Dynamic" CssClass="error_validator"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>дата исполнения в днях</td>
                            <td>
                                <asp:TextBox ID="txtTermExecution" runat="server" CssClass="numeric_box"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTermExecution" ControlToValidate="txtTermExecution" runat="server" ErrorMessage="*" Display="Dynamic" CssClass="error_validator"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </InsertItemTemplate>
                <EditItemTemplate>
                      <table>
                        <tr>
                            <td>название документа</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" Text="<%# Item.Name %>"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDocName" ControlToValidate="txtName" runat="server" ErrorMessage="*" Display="Dynamic" CssClass="error_validator"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>дата исполнения в днях</td>
                            <td>
                                <asp:TextBox ID="txtTermExecution" runat="server" Text="<%# Item.TermExecutionDays %>"  CssClass="numeric_box"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTermExecution" ControlToValidate="txtTermExecution" runat="server" ErrorMessage="*" Display="Dynamic" CssClass="error_validator"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
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

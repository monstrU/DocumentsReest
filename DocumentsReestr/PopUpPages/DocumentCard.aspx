<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentCard.aspx.cs" Inherits="DocumentsReestr.PopupButtons.PopUpPages.DocumentCard" %>

<%@ Register TagPrefix="asp" Namespace="RCO.PopUpButtons" Assembly="PopUpButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Карточка документа</title>
    <link href="/DefaultTheme/themes/base/jquery.ui.all.css" rel="stylesheet" />
    <link href="/DefaultTheme/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/jquery.ui.core.js"></script>
    <script src="/Scripts/jquery.ui.datepicker.js"></script>
    <script src="/Scripts/jquery.ui.datepicker-ru.js"></script>
    <script src="/Scripts/jquery.maskedinput.min.js"></script>
    <style type="text/css">
        .datepicker {
            width: 12ex;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $.datepicker.setDefaults($.datepicker.regional["ru"]);

            $(".datepicker").mask("99.99.9999");
            $(".datepicker").datepicker(
            {
                changeMonth: true,
                changeYear: true
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView ID="fvDocument" runat="server" RenderOuterTable="False" ItemType="DomainModel.DocumentModel">
                <InsertItemTemplate>
                    <table>
                        <tr>
                            <td>название документа</td>
                            <td>
                                <asp:TextBox ID="txtDocName" runat="server"></asp:TextBox>
                                <asp:PopUpButton runat="server" ID="pbtnDocName" Url="~/PopUpPages/DocNames.aspx" windowWidth="600px" windowHeight="500px" Text="..." IsResizable="True" PostBack="True" OnAfterChildClose="pbtnDocName_OnAfterChildClose"></asp:PopUpButton></td>
                        </tr>
                        <tr>
                            <td>дата приема</td>
                            <td>
                                <asp:TextBox ID="txtDateAdmission" runat="server" CssClass="datepicker"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ФИО отправителя</td>
                            <td>
                                <asp:TextBox ID="txtSenderName" runat="server"></asp:TextBox>
                                <asp:PopUpButton runat="server" ID="pbtnFio" Url="~/PopUpPages/SenderName.aspx" windowWidth="600px" windowHeight="500px" Text="..." IsResizable="True" PostBack="True" OnAfterChildClose="pbtnFio_OnAfterChildClose"></asp:PopUpButton>
                            </td>
                        </tr>
                        <tr>
                            <td>срок исполнения</td>
                            <td>
                                <asp:TextBox ID="txtTermExecution" runat="server" CssClass="datepicker"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>комментарии</td>
                            <td>
                                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox></td>
                        </tr>

                    </table>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <table>
                        <tr>
                            <td>название документа</td>
                            <td>
                                <asp:TextBox ID="txtDocName" runat="server" Text='<%# Item.Name %>'></asp:TextBox>
                                <asp:PopUpButton runat="server" ID="pbtnDocName" Url="~/PopUpPages/DocNames.aspx" windowWidth="600px" windowHeight="500px" Text="..." IsResizable="True" PostBack="True" OnAfterChildClose="pbtnDocName_OnAfterChildClose"></asp:PopUpButton></td>
                        </tr>
                        <tr>
                            <td>дата приема</td>
                            <td>
                                <asp:TextBox ID="txtDateAdmission" runat="server" CssClass="datepicker" Text="<%# Item.DateAdmission %>"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ФИО отправителя</td>
                            <td>
                                <asp:TextBox ID="txtSenderName" runat="server" Text="<%# Item.SenderName %>"></asp:TextBox>
                                <asp:PopUpButton runat="server" ID="pbtnFio" Url="~/PopUpPages/SenderName.aspx" windowWidth="600px" windowHeight="500px" Text="..." IsResizable="True" PostBack="True" OnAfterChildClose="pbtnFio_OnAfterChildClose"></asp:PopUpButton>
                            </td>
                        </tr>
                        <tr>
                            <td>срок исполнения</td>
                            <td>
                                <asp:TextBox ID="txtTermExecution" runat="server" CssClass="datepicker" Text="<%# Item.TermExecution %>"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>комментарии</td>
                            <td>
                                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="5" Text="<%# Item.Comments %>"></asp:TextBox></td>
                        </tr>
                    </table>
                    <input type="hidden" id="idDocId" clientidmode="Static" runat="server"  value="<%# Item.DocumentId %>"/>
                    
                </EditItemTemplate>

            </asp:FormView>

            <input type="hidden" id="idDocNameText" clientidmode="Static" runat="server" />
            <input type="hidden" id="idDocNameId" clientidmode="Static" runat="server" />
            <input type="hidden" id="idTermExecution" clientidmode="Static" runat="server" />

            <input type="hidden" id="idSenderId" clientidmode="Static" runat="server" />
            <input type="hidden" id="idSenderName" clientidmode="Static" runat="server" />
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

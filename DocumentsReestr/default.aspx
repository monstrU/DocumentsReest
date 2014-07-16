<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/default.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DocumentsReestr._default" %>

<%@ Register TagPrefix="asp" Namespace="RCO.PopUpButtons" Assembly="PopUpButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="phContent" runat="server">
    <div class="info_box">
        <h2>Входящие документы</h2>
        <div class="search_box">
            <table>
                <tr>
                    <td>дата приема</td>
                    <td>с
                    <asp:TextBox ID="txtFromDateAdmission" runat="server" CssClass="datepicker"></asp:TextBox>
                        по
                    <asp:TextBox ID="txtToDateAdmission" runat="server" CssClass="datepicker"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="text" placeholder="отправитель" id="idSender" runat="server" />

                        <input type="text" placeholder="название документа" id="idDocName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="button_block">
                        <asp:RadioButtonList ID="rbtnPeriodFilter" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">все</asp:ListItem>
                            <asp:ListItem>исполнить сегодня</asp:ListItem>
                            <asp:ListItem>просрочено</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>

                </tr>
                <tr>
                    <td colspan="2" class="button_block">
                        <asp:Button ID="btnSearch" runat="server" Text="поиск" OnClick="btnSearch_Click" />
                        &nbsp;<asp:Label ID="lblError" runat="server" Text="" EnableViewState="False" CssClass="error_box"></asp:Label></td>
                </tr>
            </table>
            <div class="export_box">
                <asp:ImageButton ID="ibtnWord" runat="server" ToolTip="экспорт в Word" OnClick="ibtnWord_Click" ImageUrl="Images/word_icon.png" Height="30px" />
                <asp:ImageButton ID="ibtnCsv" runat="server" OnClick="ibtnCsv_Click" ToolTip="экспорт в  csv" ImageUrl="Images/csv_text.png" Height="30px" />
                <asp:ImageButton ID="ibtnPdf" runat="server" OnClick="ibtnPdf_OnClick" ToolTip="экспорт в  pdf" ImageUrl="Images/pdf2.jpg" Height="30px" />
            </div>
        </div>
        <div class="search_box">
            <asp:GridView ID="gvDocuments" runat="server" ItemType="DomainModel.DocumentModel" AutoGenerateColumns="False" DataKeyNames="DocumentId" OnRowDataBound="gvDocuments_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="gvDocuments_PageIndexChanging" PageSize="20">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:PopUpButton runat="server" ID="pbtnAdd" CssClass="header_command" Text="новый" Url="~/PopUpPages/DocumentCard.aspx" IsDialog="False" isShowAddressBar="False" OnAfterChildClose="pbtnAdd_AfterChildClose" PostBack="True" windowHeight="400px" windowWidth="500px" IsResizable="True" ControlShowType="HyperLink">
                                <PostParams>
                                    <asp:paramItem Key="add" KeyValue="1" />
                                </PostParams>
                            </asp:PopUpButton>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:PopUpButton ID="pbtnEditDoc" runat="server" Text="ред" ControlShowType="HyperLink" Url="~/PopUpPages/DocumentCard.aspx" IsDialog="False" isShowAddressBar="False" OnAfterChildClose="pbtnEditDoc_AfterChildClose" PostBack="True" windowHeight="400px" windowWidth="500px" IsResizable="true">
                            </asp:PopUpButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DocNumber" HeaderText="номер документа" />
                    <asp:BoundField DataField="NameCalculated" HeaderText="название" />
                    <asp:BoundField DataField="DateAdmission" HeaderText="дата приема" DataFormatString="{0:dd.MM.yyyy}" />
                    <asp:BoundField DataField="TermExecutionCalculated" HeaderText="срок исполнения" />
                    <asp:BoundField DataField="ControlTermExecutionModel" HeaderText="контрольный срок исполнения" DataFormatString="{0:dd.MM.yyyy}" />
                    <asp:BoundField DataField="DocSender.SenderName" HeaderText="отправитель" />

                    <asp:BoundField DataField="Comments" HeaderText="комментарий" />
                </Columns>
                <EmptyDataTemplate>
                    [<asp:PopUpButton runat="server" ID="pbtnAdd" Text="новый" Url="~/PopUpPages/DocumentCard.aspx" IsDialog="False" isShowAddressBar="False" OnAfterChildClose="pbtnAdd_AfterChildClose" PostBack="True" windowHeight="400px" windowWidth="500px" IsResizable="True" ControlShowType="HyperLink">
                        <PostParams>
                            <asp:paramItem Key="add" KeyValue="1" />
                        </PostParams>
                    </asp:PopUpButton>]
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </div>




    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="phBottom" runat="server">
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
</asp:Content>

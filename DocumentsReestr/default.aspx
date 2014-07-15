<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/default.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DocumentsReestr._default" %>

<%@ Register TagPrefix="asp" Namespace="RCO.PopUpButtons" Assembly="PopUpButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="phContent" runat="server">
    <div class="info_box">
        <asp:PopUpButton runat="server" ID="pbtnAdd" Text="добавить" Url="~/PopUpPages/DocumentCard.aspx" IsDialog="False" isShowAddressBar="False" OnAfterChildClose="pbtnAdd_AfterChildClose" PostBack="True" windowHeight="400px" windowWidth="500px" IsResizable="True">
            <PostParams>
                <asp:paramItem Key="add" KeyValue="1" />
            </PostParams>
        </asp:PopUpButton>



        <asp:GridView ID="gvDocuments" runat="server" ItemType="DomainModel.DocumentModel" AutoGenerateColumns="False" DataKeyNames="DocumentId" OnRowDataBound="gvDocuments_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate><asp:PopUpButton ID="pbtnEditDoc" runat="server" Text="ред" ControlShowType="HyperLink" Url="~/PopUpPages/DocumentCard.aspx" IsDialog="False" isShowAddressBar="False" OnAfterChildClose="pbtnAdd_AfterChildClose" PostBack="True" windowHeight="400px" windowWidth="500px" IsResizable="true">
                                  </asp:PopUpButton></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DocNumber" HeaderText="номер документа" />
                <asp:BoundField DataField="NameCalculated" HeaderText="название" />
                <asp:BoundField DataField="DateAdmission" HeaderText="дата приема" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="TermExecutionCalculated" HeaderText="срок исполнения"  />
                <asp:BoundField DataField="ControlTermExecutionCalculated" HeaderText="контрольный срок исполнения" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="DocSender.SenderName" HeaderText="отправитель" />
                
                <asp:BoundField DataField="Comments" HeaderText="комментарий" />
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="phBottom" runat="server">
</asp:Content>

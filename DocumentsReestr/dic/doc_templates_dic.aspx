<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/default.Master" AutoEventWireup="true" CodeBehind="doc_templates_dic.aspx.cs" Inherits="DocumentsReestr.PopupButtons.dic.doc_templates_dic" %>

<%@ Register TagPrefix="asp1" Namespace="RCO.PopUpButtons" Assembly="PopUpButton" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="phContent" runat="server">
    <h2>Шаблоны документов</h2>
    <asp1:PopUpButton ID="pbtnAddDoc" runat="server" Text="новый"  Url="~/PopUpPages/doc_template_card.aspx" IsDialog="False" isShowAddressBar="False" OnAfterChildClose="pbtnAddDoc_OnAfterChildClose" PostBack="True" windowHeight="400px" windowWidth="500px">
        <PostParams>
            <asp1:paramItem Key="add" KeyValue="1" />
        </PostParams>
    </asp1:PopUpButton>
    <asp:GridView ID="gvDocNames" runat="server" AutoGenerateColumns="False" DataKeyNames="DocNameId,Name,TermExecutionDays" ItemType="DomainModel.DocNameModel" OnRowCreated="gvDocNames_RowCreated">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp1:PopUpButton ID="pbtnEditDoc" runat="server" Text="ред" ControlShowType="HyperLink" Url="~/PopUpPages/doc_template_card.aspx" IsDialog="False" isShowAddressBar="False" OnAfterChildClose="pbtnEditDoc_OnAfterChildClose" PostBack="True" windowHeight="400px" windowWidth="500px">
                    </asp1:PopUpButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="шаблонное название" />
            <asp:BoundField DataField="TermExecutionDays" HeaderText="срок исполнения в днях" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="phBottom" runat="server">
</asp:Content>

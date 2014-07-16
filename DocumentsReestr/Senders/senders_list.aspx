<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/default.Master" AutoEventWireup="true" CodeBehind="senders_list.aspx.cs" Inherits="DocumentsReestr.PopupButtons.Senders.senders_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="phContent" runat="server">
    <h2>Справочник отправителей</h2>
           <asp:GridView ID="gvSenders" runat="server" AutoGenerateColumns="False" ItemType="ReestrModel.DocSender" DataKeyNames="DocSenderId,SenderName"  CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="phBottom" runat="server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/default.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DocumentsReestr._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="phContent" runat="server">
    <div class="info_box">
                    
                    

                        
                        <asp:GridView ID="gvDocuments" runat="server" ItemType="ReestrModel.DocumentModel" AutoGenerateColumns="False" DataKeyNames="DocumentId">
                            <Columns>
                                <asp:BoundField DataField="DocNumber" HeaderText="номер" />
                                <asp:BoundField DataField="Name" HeaderText="название" />
                                <asp:BoundField DataField="DateAdmission" HeaderText="дата приема" DataFormatString="{0:dd.MM.yyyy}"/>
                            </Columns>
                        </asp:GridView>

                        
                        
                    
                </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="phBottom" runat="server">
</asp:Content>

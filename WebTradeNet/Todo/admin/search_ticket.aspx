<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="search_ticket.aspx.vb" Inherits="admin_search_ticket" title="Search Ticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Search Ticket</h2>
<hr />
<asp:TextBox ID="txt_search" runat="server" Width="78%"></asp:TextBox><asp:Button ID="btn_go" runat="server" Text=" Search " Width="20%"/>
    <br />
    <br />
    <hr />
    <div id="Disp_search_result" runat="server"></div>
</asp:Content>


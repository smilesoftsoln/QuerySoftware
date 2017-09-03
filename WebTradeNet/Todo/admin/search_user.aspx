<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="search_user.aspx.vb" Inherits="admin_search_user" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Search User</h2>
<hr />
Enter Keyword : <br />
    <asp:TextBox ID="txt_search" runat="server" Width="78%"></asp:TextBox><asp:Button ID="btn_go" runat="server" Text=" Search " Width="20%"/>
    <br />
    <br />
    <hr />
    <div id="disp_result" runat="server"></div>
</asp:Content>


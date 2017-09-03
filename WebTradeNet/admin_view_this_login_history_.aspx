<%@ Page Language="VB" MasterPageFile="~/admin_controls_master.master" AutoEventWireup="false" CodeFile="admin_view_this_login_history_.aspx.vb" Inherits="admin_view_this_login_history_" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h4>
    Login History Of  : 
    <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label>
</h4>
<div id="Disp_result_login_history" runat="server"></div>
</asp:Content>


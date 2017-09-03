<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="Online_users.aspx.vb" Inherits="admin_Online_users" title="Online Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css">
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Online Users</h2>
<hr />
<div id="disp_online_stts" runat="server"></div>
<script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
</script>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/todo/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="delly_login_report.aspx.vb" Inherits="admin_delly_login_report" title="Login Report (ALL)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css">
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Login Report (ALL)</h2>
<hr />
<div id="disp_all_login_report" runat="server"></div>
<script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
</script>

</asp:Content>


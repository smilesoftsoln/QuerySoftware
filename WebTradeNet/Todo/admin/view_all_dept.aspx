<%@ Page Language="VB" MasterPageFile="~/todo/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="view_all_dept.aspx.vb" Inherits="admin_view_all_dept" title="View All Departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css">
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>View All Departments</h2>
<hr />
<div id="disp_all_branchs" runat="server"></div>
<script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
</script>
[<a href="add_new_dept.aspx">Add New Department</a>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<a href="edit_dept.aspx" >Edit Department</a>]
</asp:Content>


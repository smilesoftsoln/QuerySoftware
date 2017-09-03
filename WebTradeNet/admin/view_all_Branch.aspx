<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="view_all_Branch.aspx.vb" Inherits="admin_view_all_Branch" title="View All Branch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css">
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>View All Branch</h2>
<hr />
<div id="disp_all_branchs" runat="server"></div>
<script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
</script>
[ <a href="add_new_branch.aspx">Add New Branch</a> ] &nbsp;&nbsp;&nbsp;&nbsp; [ <a href="edit_branch.aspx">Edit Branch</a> ]
</asp:Content>


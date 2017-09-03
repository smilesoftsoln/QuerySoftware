<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_view_all_branches.aspx.cs" Inherits="admin_admin_view_all_branches" Title="Untitled Page" %>

<asp:Content ID = "content2" runat = "server" ContentPlaceHolderID ="head">
    <link href="jTable/css/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
    <script src="jTable/lib/jquery/jquery.js" type="text/javascript"></script>
    <script src="jTable/flexigrid.js" type="text/javascript"></script>
</asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    
  <%--  <script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
    </script>
    [ <a href="add_new_branch.aspx">Add New Branch</a> ] &nbsp;&nbsp;&nbsp;&nbsp; [ <a href="edit_branch.aspx">Edit Branch</a> ]--%>
    
<div id="disp_all_branchs" runat="server" align="center"></div>

</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="manage_hod.aspx.vb" Inherits="admin_manage_hod" title="Manage Departments & HOD's" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css">
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Manage Departments & HOD's</h2>
<hr />

    
        <b>Departments & HODs</b>
        <div id="disp_depts_n_hods" runat="server"></div>
    <hr />
        <b>HOD Less Departments</b>
        <div id="disp_hol_less_depts" runat="server"></div>
     <hr />
        <b>Departments Less HODs</b>
        <div id="disp_dept_less_hods" runat="server"></div>


<script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
</script>


</asp:Content>


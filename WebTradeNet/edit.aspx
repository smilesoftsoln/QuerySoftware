<%@ Page Language="VB" MasterPageFile="~/admin_controls_master.master" AutoEventWireup="false" CodeFile="edit.aspx.vb" Inherits="edit" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h4>
    Edit Options
</h4>
<hr />
<table width="100%" class="tbl_gw">
    <tr class="tbl_gw_spl">
        <td style="width:50%">
            User Site
        </td>
        <td style="width:50%">
            Dept. Site
        </td>
    </tr>
    <tr>
        <td style="width:50%" valign="top" >
            <ul>
                <li><a href="edit_branch_employee.aspx">Branch Employee</a> </li>
                <li><a href="edit_branch_head.aspx">Branch Head</a></li>
                <li><a href="edit_dept_emp.aspx">Department Employee</a></li>
                <li><a href="edit_Dept_HOD.aspx">Head Of Department</a></li>
                <li><a href="edit_Dept_ADMIN.aspx">Admin</a></li>
            </ul>
        </td>
        <td style="width:50%" valign="top" >
            <ul>
                <li><a href="edit_branch_info.aspx">Branch</a></li>
                <li><a href="edit_dept_info.aspx">Department</a></li>
            </ul>
        </td>
    </tr>
</table>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="add_new_dept.aspx.vb" Inherits="admin_add_new_dept" title="Add New Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="scripts/jquery.js" type="text/javascript"></script>
<script src="scripts/jquery_002.js" type="text/javascript"></script>
<link rel="stylesheet" href="scripts/validationEngine.css" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Add New Department</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;text-align:left;">
        <tr>
            <td>
                Department Name : 
            </td>
            <td>                
                <asp:TextBox ID="txt_dept_name" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Department Description : 
            </td>
            <td>                
                <asp:TextBox ID="txt_dept_desc" runat="server" class="validate[required],length[0,100]]" name="developername" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Select Management : 
            </td>
            <td>                
                <asp:DropDownList ID="cbo_manage" runat="server" class="validate[required],length[0,100]]" name="developername">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_dept_submit" runat="server" Text="Complete" Width="100%" />
            </td>
        </tr>
    </table>
</asp:Content>


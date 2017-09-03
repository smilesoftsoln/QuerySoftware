<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="add_new_branch.aspx.vb" Inherits="admin_add_new_branch" title="Add New Branch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="scripts/jquery.js" type="text/javascript"></script>
<script src="scripts/jquery_002.js" type="text/javascript"></script>
<link rel="stylesheet" href="scripts/validationEngine.css" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Add New Branch</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;text-align:left;">
        <tr>
            <td>
                Branch Name : 
            </td>
            <td>                
                <asp:TextBox ID="txt_branch_name" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Branch Description : 
            </td>
            <td>                
                <asp:TextBox ID="txt_branch_desc" runat="server" class="validate[required],length[0,100]]" name="developername" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_dept_submit" runat="server" Text="Complete" Width="100%" />
            </td>
        </tr>
    </table>
   </asp:Content>


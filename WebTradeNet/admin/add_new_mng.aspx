<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="add_new_mng.aspx.vb" Inherits="admin_add_new_mng" title="Add New Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Add New Management</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;text-align:left;">
        <tr>
            <td>
                Management Name : 
            </td>
            <td>                
                <asp:TextBox ID="txt_mng_name" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Management Description : 
            </td>
            <td>                
                <asp:TextBox ID="txt_mng_desc" runat="server" class="validate[required],length[0,100]]" name="developername" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_mng_submit" runat="server" Text="Complete" Width="100%" />
            </td>
        </tr>
    </table>
</asp:Content>


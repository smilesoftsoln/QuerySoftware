<%@ Page Language="VB" MasterPageFile="~/todo/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="edit_mng.aspx.vb" Inherits="admin_edit_mng" title="Edit Management Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Edit Management Details</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;">
    <tr>
        <td >
            Select Management :
        </td>
        <td>
            <asp:DropDownList ID="cbo_mngs" runat="server" AutoPostBack="True" Width="175px" class="validate[required],length[0,100]]" name="developername" >
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Management Name :
        </td>
        <td>
            <asp:TextBox ID="txt_mng_name" runat="server" Width="175px" class="validate[required],length[0,100]]" name="developername" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Management Description :
        </td>
        <td>
            <asp:TextBox ID="txt_mng_desc" runat="server" TextMode="MultiLine" Width="175px" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btn_update" runat="server" Text="Update" />
        </td>
    </tr>
</table>
</asp:Content>


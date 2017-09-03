<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="edit_branch.aspx.vb" Inherits="admin_edit_branch" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Edit Branch Details</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;">
    <tr>
        <td >
            Select Branch :
        </td>
        <td>
            <asp:DropDownList ID="cbo_branchs" runat="server" AutoPostBack="True" Width="175px" class="validate[required],length[0,100]]" name="developername" >
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Branch Name :
        </td>
        <td>
            <asp:TextBox ID="txt_branch_name" runat="server" Width="175px" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Branch Details :
        </td>
        <td>
            <asp:TextBox ID="txt_branch_desc" runat="server" TextMode="MultiLine" Width="175px" class="validate[required],length[0,100]]" name="developername" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btn_update" runat="server" Text="Update" />
        </td>
    </tr>
</table>
</asp:Content>


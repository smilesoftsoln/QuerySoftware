<%@ Page Language="VB" MasterPageFile="~/todo/admin_Pnl.master" AutoEventWireup="false" CodeFile="add_new_user.aspx.vb" Inherits="admin_add_new_user" Trace="false" ValidateRequest="false" title="Add New User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="scripts/jquery.js" type="text/javascript"></script>
<script src="scripts/jquery_002.js" type="text/javascript"></script>
<link rel="stylesheet" href="scripts/validationEngine.css" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Add New User</h2>
[BE : Branch Employee ][ BH: Branch Head ][ DE : Department Employee ][ HOD: Head Of Department ] 
<hr />
<table style="80%;margin-left:auto;margin-right:auto;text-align:left;">
    <tr>
        <td>
            Select User Type :
        </td>
        <td>
            <asp:DropDownList ID="cbo_user_typ" runat="server" class="validate[required],length[0,100]]" name="developername">
                <asp:ListItem>BE</asp:ListItem>
                <asp:ListItem>BH</asp:ListItem>
                <asp:ListItem>DE</asp:ListItem>
                <asp:ListItem>HOD</asp:ListItem>
                <asp:ListItem Value="MNGT">MNGT</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Choose UserName :
        </td>
        <td>
            <asp:TextBox ID="txt_username" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Password :
        </td>
        <td>
            <asp:TextBox ID="txt_pwd" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Confirm Password :
        </td>
        <td>
            <asp:TextBox ID="txt_conf_pwd" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <hr />
        </td>
    </tr>
    <tr>
        <td>
            Name :
        </td>
        <td>
            <asp:TextBox ID="txt_name" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Email id : 
        </td>
        <td>
            <asp:TextBox ID="txt_email" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Phone Number :
        </td>
        <td>
            <asp:TextBox ID="txt_phone" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td colspan="2">
            <br />
            <asp:Button ID="btn_submit" runat="server" Text="Next >>" Width="100%" />
        </td>
    </tr>
    
</table>
</asp:Content>


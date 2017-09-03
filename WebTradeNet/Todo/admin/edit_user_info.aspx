<%@ Page Language="VB" MasterPageFile="~/todo/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="edit_user_info.aspx.vb" Inherits="admin_edit_user_info" title="Edit User Info." %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Edit User Info.</h2>
<hr />
    <table style="margin-left:auto;margin-right:auto;">
            <tr>
                <td colspan="2">
                    <b><asp:Label ID="lbl_name" runat="server" Text=""></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    UserName :
                </td>
                <td>
                    <asp:TextBox ID="txt_username" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True" ></asp:TextBox>
                    <asp:Label ID="lbl_username" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Name :
                </td>
                <td>
                    <asp:TextBox ID="txt_name"  runat="server" class="validate[required],length[0,100]]" name="developername" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Phone Number :
                </td>
                <td>
                    <asp:TextBox ID="txt_phone"  runat="server" class="validate[required],length[0,100]]" name="developername" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    E-mail id :
                </td>
                <td>
                    <asp:TextBox ID="txt_email" runat="server" class="validate[required],length[0,100]]" name="developername" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password
                </td>
                <td style="height:30px;">
                    <asp:Label ID="lbl_password" runat="server" Text="********" Width="70px" ></asp:Label>
                    <asp:TextBox ID="txt_pass" Visible="false" runat="server" class="validate[required],length[0,100]]" name="developername" Width="70px" ></asp:TextBox>
                    <asp:LinkButton ID="btn_show_password" runat="server">Show Password</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 26px">
                    <asp:Button ID="btn_submit" runat="server" Text=" Update " />
                </td>
            </tr>
    </table>
</asp:Content>


<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_To_favorites.aspx.vb" Inherits="Add_To_favorites" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>|| TnCAREe ||</title>
    <link href="Style_admin.css" type="text/css" rel="stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
    <div class="data_admin_mid_main_top_3"><img src="images/Favorites.ico" style="width: 22px; height: 20px;float:left;clear:left;"/> Add To favorites</div>
    <div style="width:490px;margin-left:auto;margin-right:auto;">
        <table>
            <tr>
                <td style="width: 129px">
                    Title :
                </td>
                <td style="width: 329px">
                    <asp:TextBox ID="txt_title" runat="server" Width="342px" Font-Size="10px" Height="14px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 129px">
                    URL :
                </td>
                <td style="width: 329px">
                    <asp:TextBox ID="txt_url" runat="server" Width="342px" Font-Size="10px" Height="14px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="width:100%;text-align:center;margin-top:10px;">
        <asp:ImageButton ID="btn_add" runat="server" ImageUrl="~/images/New_ticket_Submit.jpg" />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/New_ticket_cancel.jpg" />
        </div>
        </div>
    </form>
</body>
</html>

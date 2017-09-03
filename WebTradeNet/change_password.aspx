<%@ Page Language="VB" AutoEventWireup="false" CodeFile="change_password.aspx.vb" Inherits="change_password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="layout.css" type="text/css" rel="stylesheet"  />
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <style type="text/css">
        .style1
        {
            width: 27%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Panel ID="Panel1" runat="server">
    <div class="test_1">
        <table width="490">
            <tr>
                <td style="width:100%;background-color:#A9B8C2" colspan="2">
                    Change Password :
                </td>
                
            </tr>
            <tr>
                <td class="style1" >
                    Username :
                </td>
                <td>
                    <asp:TextBox ID="txt_u_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Current Password  : 
                </td>
                <td>
                    <asp:TextBox ID="txt_this_pwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    New Password : 
                </td>
                <td>
                    <asp:TextBox ID="txt_new_pwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Confirm Password
			    </td>
			     <td>
                    <asp:TextBox ID="txt_conf_pwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/images/btn_submit.jpg" />
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </asp:Panel>
    </div>
    </form>
</body>
</html>

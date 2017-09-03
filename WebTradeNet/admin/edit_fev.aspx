<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit_fev.aspx.vb" Inherits="admin_edit_fev" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
        <link href="Style_admin.css" type="text/css" rel="stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
    <div  class="test_2">
        <asp:Panel ID="pnl_select" runat="server">
            <table>
                <tr>
                    <td style="width: 129px">
                        Select : 
                    </td>
                    <td style="width: 329px">
                        <asp:DropDownList ID="cbo_fevos" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnl_details" runat="server" Visible="false">
        <table>
            <tr>
                <td style="width: 129px">
                    Edit Title :
                </td>
                <td style="width: 329px">
                    <asp:TextBox ID="txt_title" runat="server" Width="342px" Font-Size="10px" Height="14px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 129px">
                    Edit URL :
                </td>
                <td style="width: 329px">
                    <asp:TextBox ID="txt_url" runat="server" Width="342px" Font-Size="10px" Height="14px"></asp:TextBox>
                </td>
            </tr>
            
        </table>
        <div style="width:100%;text-align:center;margin-top:10px;">
        <asp:ImageButton ID="btn_submit" runat="server" ImageUrl="images/btn_submit3.jpg" />
        <asp:ImageButton ID="btn_delete" runat="server" ImageUrl="images/Btn_delete3.jpg" />
        <asp:ImageButton ID="btn_cancel" runat="server"  ImageUrl="images/btn_calcel3.jpg" />
        
        </div>
        </asp:Panel>
        
        </div>
    </form>
</body>
</html>

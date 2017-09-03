<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admin_change_erer_date.aspx.vb" Inherits="admin_change_erer_date" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <link href="layout.css" type="text/css" rel="stylesheet"  />
    <style type="text/css">
        .style1
        {
            width: 27%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="test_1">
        <table width="490">
            <tr>
                <td style="width:100%;background-color:#A9B8C2" colspan="2">
                    Change Emergency Date :
                </td>
                
            </tr>
            <tr>
                <td class="style1" >
                    Topic :
                </td>
                <td>
                    <asp:Label ID="lbl_topic" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                Emergency Date :
                </td>
                <td>
                    <asp:TextBox ID="txt_emer_date" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="comm_btns2">
                        
                                       
				        <asp:LinkButton ID="btn_change" runat="server">Change</asp:LinkButton>
                       
                                       
				    </div>	
			    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

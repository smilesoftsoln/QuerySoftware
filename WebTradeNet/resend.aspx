<%@ Page Language="VB" AutoEventWireup="false" CodeFile="resend.aspx.vb" Inherits="resend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Department</title>
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
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
        <div class="test_1">
        <table width="490">
            <tr>
                <td style="width:100%;background-color:#A9B8C2" colspan="2">
                    ReSend :
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
                Reason  : 
                </td>
                <td>
                    <asp:TextBox ID="txt_why" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td colspan="2">
                    <div class="comm_btns2">
                        
                                       
				        <asp:LinkButton ID="btn_change" runat="server">ReSend</asp:LinkButton>
                       
                                       
				    </div>	
			    </td>
            </tr>
        </table>
    </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="50px" Width="125px" Visible="false">
        <h2>Ticket Resent successfully</h2>
        <a href="user_login_next.aspx">Home</a>
        </asp:Panel>
    </form>
</body>
</html>

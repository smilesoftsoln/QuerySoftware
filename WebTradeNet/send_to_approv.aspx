<%@ Page Language="VB" AutoEventWireup="false" CodeFile="send_to_approv.aspx.vb" Inherits="send_to_approv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Send Approval</title>
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
    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
        <div class="test_1">
        <table width="490">
            <tr>
                <td style="width:100%;background-color:#A9B8C2" colspan="2">
                    <b>Approval Note</b>
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="height: 30px" >
                    Topic :
                </td>
                <td style="height: 30px">
                    <asp:Label ID="lbl_topic" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Send To :
                </td>
                <td>
                    <asp:RadioButtonList ID="rdb_to" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>HOD</asp:ListItem>
                        <asp:ListItem>MNG</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                Comments Of Sender  : 
                </td>
                <td>
                    <asp:TextBox ID="txt_why" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td colspan="2">
                    <div class="comm_btns2">
                        
                                       
				        <asp:LinkButton ID="btn_change" runat="server">Send &raquo;</asp:LinkButton>
                       
                                       
				    </div>	
			    </td>
            </tr>
        </table>
    </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="50px" Width="125px" Visible="false">
        <h2>Approval Sent successfully</h2>
        
        </asp:Panel>
    </div>
    </form>
</body>
</html>

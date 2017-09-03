<%@ Page Language="VB" AutoEventWireup="false" CodeFile="change_department.aspx.vb" Inherits="change_department" %>

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
    <div class="test_1">
        <asp:Panel ID="Panel1" runat="server">
        <table width="490">
            <tr>
                <td style="width:100%;background-color:#A9B8C2" colspan="2">
                    <h4>Change Department</h4> 
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
                <td class="style1">
                To Dept: 
                </td>
                <td>
                    <asp:DropDownList ID="cbo_depts" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="comm_btns2">
                        
                                       
				        <asp:LinkButton ID="btn_change" runat="server">Submit >></asp:LinkButton>
                       
                                       
				    </div>	
			    </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <h4>Department Changed Successfully !</h4>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

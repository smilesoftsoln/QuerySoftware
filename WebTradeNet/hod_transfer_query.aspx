<%@ Page Language="VB" AutoEventWireup="false" CodeFile="hod_transfer_query.aspx.vb" Inherits="hod_transfer_query" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="div_blockone"  class="click3">
     		    <table style="width:100%;">
     		        <tr style="background-color:#33CCFF;">
     		            <td colspan="2">
     		                Transfer Query
     		            </td>
     		        </tr>
     		        <tr>
     		            <td colspan="2">
                             <asp:Label ID="lbl_ticket_t_sub" runat="server" Text=""></asp:Label>
                             <br />
                             (<asp:Label ID="lbl_tick_id" runat="server" Text=""></asp:Label>)
                             <hr />
     		            </td>
     		        </tr>
     		        <tr>
     		            <td style="width:50%;">
     		                Current :
     		            </td>
     		            <td style="width:50%;">
                             <asp:Label ID="lbl_current" runat="server" Text=""></asp:Label>
                             <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
     		            </td>
     		        </tr>
     		        <tr>
     		            <td>
     		                Transfer To Emp.:

     		            </td>
     		            <td>
                             <asp:DropDownList ID="cbo_em_list" runat="server">
                             </asp:DropDownList>
     		            </td>
     		        </tr>
     		        <tr>
     		            <td colspan="2" align="center">
                             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/btn_submit.jpg"  onMouseDown="this.src='images/btn_submit_click.jpg';" onMouseOver="this.src='images/btn_submit_hover.jpg';" onMouseUp="this.src='~/images/btn_submit.jpg';"  onMouseOut="this.src='images/btn_submit.jpg';"/>
                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_cancel.jpg"/>
     		            </td>
     		        </tr>
     		    </table>
     		</div>
    </div>
    </form>
</body>
</html>

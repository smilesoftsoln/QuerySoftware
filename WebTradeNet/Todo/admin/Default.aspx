<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <link href="../Login_style.css" rel="stylesheet" type="text/css"  />
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="co_name">
    <img src="../images/Company_main.jpg" /><br /> Admin Login
</div>
<div >
<table class="main_bg" height="100%">
	<tr>
		<td>
					
					<div class="tbl2">
					<table border="0" width="100%">  
						<tr>
							<td height="62" style="mnbtns" valign="top" align="right">
								<img src="../images/space.gif" border="0" usemap="#Map"  />
						    </td>
						</tr>
						<tr>
							<td height="109" valign="top" class="login_td"> 
							  
							  	<table>
									<tr>
										<td>
										    <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
&nbsp;</td>
									</tr>
									<tr>
										<td>
											<asp:TextBox ID="txt_uName" runat="server"></asp:TextBox>
&nbsp;</td>
									</tr>
									<tr>
										<td>
											<asp:TextBox ID="txt_pwd" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;</td>
									</tr>
								</table>
							
							</td>
						</tr>
						<tr>
							<td class="tbl_btn_td">
								<asp:ImageButton ID="btn_submit" runat="server" 
                                    ImageUrl="../images/space.gif" />
&nbsp;<asp:ImageButton ID="btn_clear" runat="server" ImageUrl="../images/space.gif" />
&nbsp;</td>
						</tr>
					</table>
					
					</div>
					
		</td>
	</tr>
</table>
</div>

<map name="Map" id="Map"><area shape="rect" coords="81,0,113,16" href="close.html" />
<area shape="rect" coords="57,-4,80,19" href="restore" />
<area shape="rect" coords="34,-9,54,18" href="minimise.html" />
    </form>
</body>
</html>

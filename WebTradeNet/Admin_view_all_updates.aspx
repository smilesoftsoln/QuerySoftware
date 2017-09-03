<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin_view_all_updates.aspx.vb" Inherits="Admin_view_all_updates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <link href="layout.css" type="text/css" rel="stylesheet"  />
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_page">
	<div class="top">
		<div class="top_left"> 
			<a href="#"><img src="images/TN_CAREE.jpg" /></a>
		</div>
		<div class="top_right">
			<a href="#">Welcome <asp:Label ID="lbl_welcome" runat="server" Text="Label"></asp:Label> </a> | 
			
			
                <asp:LinkButton ID="LinkButton1" runat="server">Log Out</asp:LinkButton> 
		</div>
	</div>
	
	<div class="menu_1">
		<a href="Admin_login_Next.aspx">Home</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
	</div>	
	
	<div class="welcome_pan">
		TradeNet Department Employee Login
	</div>
	<div class="main_panal">
		<div class="admin_updater_long">
			<div class="admin_updater_long_top">
				<img src="images/Admin_Login_Next_updater_long_ico.jpg"  align="middle"/> Updates
			</div>
			<div class="admin_updater_long_mid">
			    <div id="disp_all_updates" runat="server"></div>
			</div>
			<div class="admin_updater_long_bottom"></div>
		</div>
		<div class="search_links">
		    <a href="JavaScript:history.back()"><< Back</a>
		    <a href="Admin_search_updates.aspx">Search Update</a>
            
		</div>
		
		
            
            
	</div>
	
	
</div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin_search_updates.aspx.vb" Inherits="Admin_search_updates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css" title="custom-new-style-rg.css" />
<script src="highslide/inplace2.js" type="text/javascript"></script>

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
		
		
		
		<asp:Panel ID="panal_post_comm" runat="server" Visible=true>
            
            <div class="PC_main_pan3">
						<div class="PC_main_pan_top">
							<img src="images/logo_search.jpg"  align="middle" /> Search Update
						</div>
						<div class="PC_main_pan_mid">
							Search :  <asp:TextBox ID="txt_search" runat="server" Width="638px"></asp:TextBox>
                                    <div class="comm_btns">
                                        
                                        <asp:LinkButton ID="btn_post" runat="server">Go >></asp:LinkButton>
									</div>	
						</div>
						<div class="PC_main_pan_bottom"></div>
				</div>
            </asp:Panel>
            
        <asp:Panel ID="pnl_search_resut" runat="server" Visible=false>
        <div class="admin_updater_long">
			<div class="admin_updater_long_top">
				<img src="images/Admin_Login_Next_updater_long_ico.jpg"  align="middle"/> Search 
                Result For &#39;<asp:Label ID="lbl_titl" runat="server" Font-Italic="True" 
                    Text="Label"></asp:Label>
                &#39;
			</div>
			<div class="admin_updater_long_mid">
			    <div id="disp_search_updates" runat="server"></div>
			</div>
			<div class="admin_updater_long_bottom"></div>
		</div>
        </asp:Panel>
            <div class="search_links">
		    <a href="JavaScript:history.back()"><< Back</a>
		    <a href="Admin_login_Next.aspx" >Home</a>
            
		</div>
	</div>
	
	
</div>


<DIV style="right:1px; visibility: visible; bottom:1px; " id="topbar2">
	<TABLE width="100%">
		<TBODY><TR>
			<TD width="100%" valign="bottom">
			Developed at IT Department (TradeNet Kolhapur)  	
			</TD>
		</TR>
	</TBODY></TABLE>
</DIV>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="view_ticket.aspx.vb" Inherits="view_ticket" %>

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
			<a href="#">Welcome 
                <asp:Label ID="lbl_uname_1" runat="server" Text="Label"></asp:Label></a> | 
			
			<asp:LinkButton ID="LinkButton2" runat="server">Log Out</asp:LinkButton>
		</div>
	</div>
	
	<div class="menu_1">
		<a href="User_login_next.aspx">Home</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
	</div>	
	
	<div class="welcome_pan">
		
	</div>
	
	<div class="main_panal">
		<div class="main_panal_left">
			<div class="main_panal_left_inside">
				<a href="Create_new_ticket.aspx">
					Create New Ticket !
				</a>
				<a href="#">
					Search Query
				</a>
			</div>
		</div>
		<div class="main_panal_right">
			<div class="vt_main_pan">				
				<div class="vt_main_pan_top_top" id="pz"></div>
				<div class="vt_main_pan_top_mid">
                    <asp:Label ID="lbl_ticket_sub" runat="server" Text=""></asp:Label> 
                    <asp:Label ID="lbl_subid" runat="server" Font-Bold="True" Font-Size="12px"  CssClass="sub_id"></asp:Label>
				</div>
				<div class="vt_main_pan_top_bottom"></div>
				
				<div class="vt_main_pan_mid">
				<div class="welcome_pan2">
				        <table style="width:100%">
				            <tr>
				                <td style="width:50%">
				                    Ticket Id : <asp:Label ID="lbl_t_id" runat="server" ></asp:Label>
				                </td>
				                <td style="width:50%">
				                    Sent From Branch : <asp:Label ID="lbl_from" runat="server" Text=""></asp:Label>
				                </td>
				            </tr>
				            <tr>
				                <td>
				                    Author : <asp:Label ID="lbl_auther" runat="server" Text=""></asp:Label>
				                </td>
				                <td>
				                    To : <asp:Label ID="lbl_to" runat="server" Text=""></asp:Label>
				                </td>
				            </tr>
				            <tr>
				                <td>
				                    Posted On : <asp:Label ID="lbl_crtr_date" runat="server" Text=""></asp:Label>
				                </td>
				                <td>
				                    Now : <asp:Label ID="lbl_now" runat="server" Text=""></asp:Label>
				                </td>
				            </tr>
				            <tr>
				                <td>
				                    Attachment : <asp:Label ID="lbl_attch" runat="server" Text=""></asp:Label>
				                </td>
				                <td>
				                    Estimated time : <asp:Label ID="lbl_est_time" runat="server" Text=""></asp:Label>
				                </td>
				            </tr>
				        </table>
				    </div>
				    
                    <asp:Label ID="lbl_ticket_desc"  runat="server" Text=""></asp:Label>
						<div class="creater_"  style="overflow:auto;"> 
						    <div id="disp_crtr"  style="overflow:auto;" runat="server"></div>
						     <br />
                            
						</div>
						
						<div  style="overflow:auto;" class="View_ticket_comment">
							<img src="images/View_ticket_coment_logo.jpg"  align="middle" /> Comments
							<img src="images/View_ticket_comment_bar.jpg" style="margin-top:5px;" />
							
							
						</div>
						<div style="overflow:auto;" class="VT_comments">
						 
							<div id="dip_comments"  style="overflow:auto;" runat="server"></div>
						</div>
				</div>
				
				<div class="vt_main_pan_bottom_top"></div>
				<div class="vt_main_pan_bottom_mid">
					<a href="JavaScript:history.back()">Back  </a>|
                    
					<span id="Disp_stts_link" runat="server"></span>
					<asp:LinkButton ID="btn_resend_tick" runat="server" Visible="false">| RESEND Ticket</asp:LinkButton>
					<strong>
                        <asp:LinkButton ID="LinkButton1" runat="server">
                            <img src="images/btn_reply.jpg"  align="right" onMouseOver="this.src='images/btn_reply_hover.jpg';" onMouseOut="this.src='images/btn_reply.jpg';"
/>
                        </asp:LinkButton>
                   </strong>
				</div>
				<div class="vt_main_pan_bottom_bottom"></div>
			
			
			
			</div>
            <asp:Panel ID="panal_post_comm" runat="server" Visible="False">
            
            <div class="PC_main_pan">
						<div class="PC_main_pan_top">
							<img src="images/post_comment_logo.jpg"  align="middle" /> Post Comment
						</div>
						<div class="PC_main_pan_mid">
							<asp:TextBox ID="txt_post_" runat="server" Height="93px" TextMode="MultiLine" 
                                Width="696px"></asp:TextBox>
                                <div class="vs_post_tabs">
                                            <div class="vs_tabs">
                                                <asp:Panel ID="pnl_visible" runat="server" Visible="false">
                                                Visible To : 
                                                <br />
                                                <asp:CheckBox ID="chk_oll" runat="server" />ALL,
                                                <asp:CheckBox ID="chk_branch" runat="server" />Branch,
                                                <asp:CheckBox ID="chk_DE" runat="server" />Dept. Emp.,
                                                <asp:CheckBox ID="chk_HOD" runat="server" />HOD,
                                                <asp:CheckBox ID="chk_admin" runat="server" />ADMIN</asp:Panel>
                                                
                                                <p>
                                                <asp:FileUpload ID="fUpp" runat="server" style="margin-top: 0px" />
                                                </p>
                                            </div>
                                            <div class="comm_btns">
                                                <asp:LinkButton ID="btn_cancel" runat="server">Cancel</asp:LinkButton>
                                                <asp:LinkButton ID="btn_post" runat="server">Post</asp:LinkButton>
									        </div>	
							    </div>        
						</div>
						<div class="PC_main_pan_bottom"></div>
				</div>
            </asp:Panel>
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

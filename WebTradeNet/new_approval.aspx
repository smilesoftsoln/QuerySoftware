<%@ Page Language="VB" AutoEventWireup="false" CodeFile="new_approval.aspx.vb" Inherits="new_approval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>New Approvals</title>
    <link href="highslide/styles.css" rel="stylesheet" type="text/css">
    <link href="layout.css" type="text/css" rel="stylesheet"  />
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
		<div id="ddtopmenubar" class="mattblackmenu">
		<a href="#"><< Back</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#" rel="Therapy">
					My Account
				</a>
				</div>
	</div>
	    <div class="main_panal_right2">
			<div class="vt_main_pan2" >				
				<div class="vt_main_pan_top_top" id="pz"></div>
				<div class="vt_main_pan_top_mid">
                    <asp:Label ID="lbl_ticket_sub" runat="server" Text=""></asp:Label> 
				</div>
				<div class="vt_main_pan_top_bottom"></div>
				
				<div class="vt_main_pan_mid">
				<div class="welcome_pan2">
				        <table style="width:100%">
				            <tr>
				                <td style="width:50%">
				                    Ticket Id : <asp:Label ID="Label1" runat="server" ></asp:Label>
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
				                    Attachment :&nbsp;
                                    <asp:HyperLink ID="HyperLink1" runat="server" Style="font-weight: normal; color: blue" Visible="False">[HyperLink1]</asp:HyperLink>
                                    <asp:Label ID="lbl_attch" runat="server" Text="" style="font-weight: normal; color: black; font-family: Arial; text-decoration: none"></asp:Label></td>
				                <td>
				                    Estimated time : <asp:Label ID="lbl_est_time" runat="server" Text=""></asp:Label>
				                </td>
				            </tr>
				            <tr>
				            <td>
				            
				            </td>
				                <td  align="left">
				                    <span id="disp_reciver_de_details" runat="server"></span>
                                    <asp:LinkButton ID="LinkButton2" runat="server" Visible="False">(Change)</asp:LinkButton>
				                </td>
				            </tr>
				            
				        </table>
				    </div>
                    <asp:Label ID="lbl_ticket_desc" runat="server" Text=""></asp:Label>
						<div class="creater_"> 
						    <div id="disp_crtr" runat="server"></div>
						     <br />
						</div>
						
						<div class="View_ticket_comment">
							<img src="images/View_ticket_coment_logo.jpg"  align="middle" /> Comments
							<img src="images/View_ticket_comment_bar.jpg" style="margin-top:5px;" />
							
							
						</div>
						<div class="VT_comments">
						 
							<div id="dip_comments" runat="server"></div>
                            <asp:Panel ID="pnl_app" runat="server" >
                                <div class="app">
                                    <asp:Label ID="lbl_app_note" runat="server" Text="Label"></asp:Label>
                                    <hr />
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                                                    <asp:ListItem>APPROVE</asp:ListItem>
                                                    <asp:ListItem>DISAPPROVE</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                Reason<br /> 
                                                <asp:TextBox ID="txt_resone" runat="server" Height="46px" TextMode="MultiLine" Width="175px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <br />
                                                <asp:Button ID="btn_submit" runat="server" Text="Submit" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
						</div>
						
				</div>
				
				<div class="vt_main_pan_bottom_top"></div>
				<div class="vt_main_pan_bottom_mid">
					<a href="JavaScript:history.back()">Back </a>|
					<span id="Disp_stts_link" runat="server"></span>
					
					
					
				</div>
				<div class="vt_main_pan_bottom_bottom"></div>
			
			
			
			</div>
            
		</div>
	    
	</div>
    </form>
</body>
</html>

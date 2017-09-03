<%@ Page Language="VB" AutoEventWireup="false" ValidateRequest="false"  Trace="false" CodeFile="Admin_view_ticket.aspx.vb" Inherits="view_ticket_" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
      <LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css" title="custom-new-style-rg.css" /><script src="highslide/inplace2.js" type="text/javascript"></script>
    <link href="layout.css" type="text/css" rel="stylesheet"  />
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <script type="text/javascript" src="highslide/highslide.js"></script>
<script type="text/javascript" src="highslide/highslide-html.js"></script>
<LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg.css" title="custom-new-style-rg.css">
<script type="text/javascript" src="highslide/jquery-strech.js"></script>
<script src="highslide/custom-scripts-in.js" type="text/javascript"></script>
<link href="highslide/other-styles.css" rel="stylesheet" type="text/css">
<link href="highslide/styles.css" rel="stylesheet" type="text/css">
<script type="text/javascript">    
    hs.graphicsDir = 'highslide/graphics/';
    hs.outlineType = 'rounded-white';
    hs.outlineWhileAnimating = true;
    hs.objectLoadTime = 'after';
</script>
<style type="text/css">
.highslide-html {
    background-image:url('images/rise_mid.jpg');
    background-repeat:repeat-y;
   	background-color:#FFFFFF;
}
.highslide-html-content {
	position: absolute;
    display: none;
    width:500px;
    
}
.highslide-loading {
    display: block;
	color: black;
	font-size: 8pt;
	font-family: sans-serif;
	font-weight: bold;
    text-decoration: none;
	padding: 0px;
	border:0px solid black;
    background-color: white;
}

.control {
	float: right;
    display: block;
	margin: 0 0px;
	font-size: 9pt;
    font-weight: bold;
	text-decoration: none;
	text-transform: uppercase;
	color: #999;
}
.control:hover {
	color: black !important;
}
.highslide-move {
    cursor: move;
    background-image:url('images/rise_top.jpg');
    background-repeat:no-repeat;
    height:25px;
    background-color:Transparent;
}

.highslide-display-block {
    display: block;
    
}
.highslide-display-none {
    display: none;
}
a img
{
    border:0px;	
}
</style>


    <script type="text/javascript">

/***********************************************
* Show Hint script- © Dynamic Drive (www.dynamicdrive.com)
* This notice MUST stay intact for legal use
* Visit http://www.dynamicdrive.com/ for this script and 100s more.
***********************************************/
		
var horizontal_offset="9px" //horizontal offset of hint box from anchor link

/////No further editting needed

var vertical_offset="0" //horizontal offset of hint box from anchor link. No need to change.
var ie=document.all
var ns6=document.getElementById&&!document.all

function getposOffset(what, offsettype){
var totaloffset=(offsettype=="left")? what.offsetLeft : what.offsetTop;
var parentEl=what.offsetParent;
while (parentEl!=null){
totaloffset=(offsettype=="left")? totaloffset+parentEl.offsetLeft : totaloffset+parentEl.offsetTop;
parentEl=parentEl.offsetParent;
}
return totaloffset;
}

function iecompattest(){
return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
}

function clearbrowseredge(obj, whichedge){
var edgeoffset=(whichedge=="rightedge")? parseInt(horizontal_offset)*-1 : parseInt(vertical_offset)*-1
if (whichedge=="rightedge"){
var windowedge=ie && !window.opera? iecompattest().scrollLeft+iecompattest().clientWidth-30 : window.pageXOffset+window.innerWidth-40
dropmenuobj.contentmeasure=dropmenuobj.offsetWidth
if (windowedge-dropmenuobj.x < dropmenuobj.contentmeasure)
edgeoffset=dropmenuobj.contentmeasure+obj.offsetWidth+parseInt(horizontal_offset)
}
else{
var windowedge=ie && !window.opera? iecompattest().scrollTop+iecompattest().clientHeight-15 : window.pageYOffset+window.innerHeight-18
dropmenuobj.contentmeasure=dropmenuobj.offsetHeight
if (windowedge-dropmenuobj.y < dropmenuobj.contentmeasure)
edgeoffset=dropmenuobj.contentmeasure-obj.offsetHeight
}
return edgeoffset
}

function showhint(menucontents, obj, e, tipwidth){
if ((ie||ns6) && document.getElementById("hintbox")){
dropmenuobj=document.getElementById("hintbox")
dropmenuobj.innerHTML=menucontents
dropmenuobj.style.left=dropmenuobj.style.top=-500
if (tipwidth!=""){
dropmenuobj.widthobj=dropmenuobj.style
dropmenuobj.widthobj.width=tipwidth
}
dropmenuobj.x=getposOffset(obj, "left")
dropmenuobj.y=getposOffset(obj, "top")
dropmenuobj.style.left=dropmenuobj.x-clearbrowseredge(obj, "rightedge")+obj.offsetWidth+"px"
dropmenuobj.style.top=dropmenuobj.y-clearbrowseredge(obj, "bottomedge")+"px"
dropmenuobj.style.visibility="visible"
obj.onmouseout=hidetip
}
}

function hidetip(e){
dropmenuobj.style.visibility="hidden"
dropmenuobj.style.left="-500px"
}

function createhintbox(){
var divblock=document.createElement("div")
divblock.setAttribute("id", "hintbox")
document.body.appendChild(divblock)
}

if (window.addEventListener)
window.addEventListener("load", createhintbox, false)
else if (window.attachEvent)
window.attachEvent("onload", createhintbox)
else if (document.getElementById)
window.onload=createhintbox

</script>
<style type="text/css">

#hintbox{ 
position:absolute;
top: 0;
width: 150px; 
padding: 3px;
border:1px solid black;
font:normal 11px Verdana;
line-height:18px;
z-index:100;
border-right: 3px solid #989696;
border-bottom: 3px solid #989696;
visibility: hidden;
}

.hintanchor{ 
font-weight: bold;
color: navy;
margin: 3px 8px;
}

</style>
</head>
<body>
<script type="text/javascript">

loadTopMenu = function() 

{	

if (document.all&&document.getElementById) 

 {		

  menunavParent = document.getElementById("nav");	

   for (x=0; x < menunavParent.childNodes.length; x++) 
     {		
        menunode = menunavParent.childNodes[x];

           if (menunode.nodeName=="LI") 
             {			
             menunode.onmouseover=function() 
                {				
                this.className+=" over";			
                }			
               menunode.onmouseout=function() 
                {				
                  this.className=this.className.replace(" over", "");
	  }
           }
        }
     }
}
window.onload=loadTopMenu;
</script>
    <form id="form1" runat="server">
    <div class="main_page">
	<div class="top">
		<div class="top_left"> 
			<a href="#"><img src="images/TN_CAREE.jpg" /></a>
		</div>
		<div class="top_right">
			
            <asp:Label ID="UserLabel1" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="LinkButton2" runat="server">Log Out</asp:LinkButton>
		</div>
	</div>
	
	<div class="menu_1">
		<div id="Disp_home_link" runat="server"></div>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
	</div>	
	
	<div class="welcome_pan">
		TradeNet.com
	</div>
	
	<div class="main_panal">
		<div class="main_panal_left">
			<div class="main_panal_left_inside" target="_blank">
			<!--	<a href="mail/inbox.aspx">
					Check Inbox
				</a>
				<a href="mail/Default.aspx" target="_blank">
					Swich to TradeNet Mail
				</a> -->
				            <a href="JavaScript:history.back()"><< Back  </a>
                            <div id="disp_fwd_query" runat="server"></div>
                            <span id="Disp_stts_link" runat="server"></span>
                            <div id="send_message" runat="server" style="width: 50%;" visible="true"></div>
				           <!-- <div id="disp_change_dept" style="width:50%; display:none" visible="false" runat="server"></div>-->
                            <div id="disp_sent_to_approval" runat="server" style="width: 50%;" visible="true"></div>
                             
                            
			</div>
		</div>
		<div class="main_panal_right">
			<div class="vt_main_pan">				
				<div class="vt_main_pan_top_top"></div>
				<div class="vt_main_pan_top_mid">
					
                    <asp:Label ID="lbl_ticket_sub" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lbl_t_id" runat="server" Font-Bold="True" Font-Size="12px"  CssClass=""></asp:Label>
                     
				</div>
				<div class="vt_main_pan_top_bottom"></div>
				
				<div class="vt_main_pan_mid">
				    <div class="welcome_pan2">
				        <table style="width:100%">
				            <tr>
				                <td style="width:50%">
				                    Ticket Id : <asp:Label ID="lbl_subid" runat="server" ></asp:Label>
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
				                    &nbsp;</td>
				                <td>
				                    You Recived/Last Status Change:-<asp:Label ID="Last_Status_Change_Label1" runat="server" 
                                        Text=""></asp:Label>
				                </td>
				            </tr>
				            <tr>
				                <td>
				                    Attachment : <asp:Label ID="lbl_attch" runat="server" Text=""></asp:Label>
				                </td>
				                <td>
				                    Remining time : <asp:Label ID="lbl_est_time" runat="server" ForeColor="#FF5050"></asp:Label> (hh:mm:ss)
				                </td>
				            </tr>
				        </table>
				    </div>
                    <asp:Label ID="lbl_ticket_desc" runat="server" Text=""></asp:Label>
						<div class="creater_" style="overflow:auto"> 
						    <div id="disp_crtr" style="overflow:auto" runat="server"></div>
						    <br />
                            <asp:Label ID="lbl_alltch" runat="server" Text=""></asp:Label>
						</div>
						
						<div class="View_ticket_comment"  style="overflow:auto" >
							<img src="images/View_ticket_coment_logo.jpg"  align="middle" /> Comments
							<img src="images/View_ticket_comment_bar.jpg" style="margin-top:5px;" />
							
							
						</div>
						
						
						<div class="VT_comments"  style="overflow:auto;">
						 
							<div id="dip_comments"  style="overflow:auto;" runat="server"></div>
							
							<asp:Panel ID="pnl_app" runat="server" Visible="false">
                                <div class="app">
                                   <b>Approval Note : -</b> 
                                   <div style="padding-left:20px;">
                                       <b>Q :</b> <asp:Label ID="lbl_app_crtr" runat="server" ForeColor="Navy"></asp:Label>
                                       <hr />
                                   </div>
                                   <div style="padding-left:20px;">
                                      <b>A :</b> <asp:Label ID="lbl_app_rcvr" runat="server" ForeColor="#400040"></asp:Label>
                                       <hr />
                                   </div>
                                    Result: 
                                    <asp:Label ID="lbl_result" runat="server" Text=""></asp:Label>
                                </div>
                            </asp:Panel>
                            <div style="padding-left:20px; background-color :InfoBackground; display: none;"   
                                id="msges" runat="server" >
                            
                            </div>
						</div>
				</div>
				
				<div class="vt_main_pan_bottom_top"></div>
				<div class="vt_main_pan_bottom_mid">
					    <div class="vt_main_pan_bottom_mid_left">
                            <asp:Button ID="btn_delete" runat="server" Text="Delete Ticket" 
                                Visible="False" />
					    </div>
					    <div class="vt_main_pan_bottom_mid_right">
					    
					    <asp:LinkButton ID="LinkButton1" runat="server">
                            <img src="images/btn_reply.jpg"  align="right"/>
                        </asp:LinkButton>
					    </div>
				</div>	 
				<div class="vt_main_pan_bottom_bottom"></div>
			
			
			
			</div>
			<br />
			<br />
			
            <asp:Panel ID="panal_post_comm" runat="server" Visible="False">
            
            <div class="PC_main_pan">
						<div class="PC_main_pan_top">
							<img src="images/post_comment_logo.jpg"  align="middle" /> Post Comment
						</div>
						<div class="PC_main_pan_mid">
<%--                            <asp:RequiredFieldValidator ControlToValidate="txt_post__" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
--%>							
<asp:TextBox ID="txt_post__" runat="server" Height="93px" TextMode="MultiLine" 
                                Width="696px" Visible="false"></asp:TextBox>
                                <FTB:FreeTextBox id="txt_post_"  
			                                Focus="true"
			                                SupportFolder="aspnet_client/"
			                                JavaScriptLocation="ExternalFile" 
			                                ButtonImagesLocation="ExternalFile"
			                                ToolbarImagesLocation="ExternalFile"
			                                ToolbarStyleConfiguration="Office2000"			
			                                toolbarlayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,Delete,InsertTable;"
			                                runat="Server"
			                                GutterBackColor="red" AllowHtmlMode="False" ButtonSet="Office2000" 
                                        SslUrl="/" ToolbarBackColor="SkyBlue" AutoParseStyles="True" 
                                                ButtonDownImage="False" Width="97%" EnableHtmlMode="False" HtmlModeDefaultsToMonoSpaceFont="False" BreakMode="LineBreak"		 
			                                />
			                                <br />
                                <div class="vs_post_tabs">
                                    
                                    <asp:FileUpload ID="fUpp" runat="server" style="margin-top: 0px" />
                                            <div class="comm_btns">
                                                <asp:LinkButton ID="btn_cancel" runat="server">Cancel</asp:LinkButton>
                                                <asp:LinkButton ID="btn_post" OnClick ="btn_post_Click" runat="server">Post</asp:LinkButton>
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

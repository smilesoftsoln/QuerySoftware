<%@ Page Language="VB" AutoEventWireup="false" CodeFile="main_admin_login_Next.aspx.vb" Inherits="main_admin_login_Next" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <META HTTP-EQUIV="REFRESH" CONTENT="300">
    <LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg.css" title="custom-new-style-rg.css">
<script src="highslide/inplace.js" type="text/javascript"></script>
<link href="layout.css" type="text/css" rel="stylesheet"  />
<script type="text/javascript" src="highslide/highslide.js"></script>
<script type="text/javascript" src="highslide/highslide-html.js"></script>
<script type="text/javascript" src="highslide/jquery-strech.js"></script>
<script src="highslide/custom-scripts-in.js" type="text/javascript"></script>
<link href="highslide/other-styles.css" rel="stylesheet" type="text/css" />
<link href="highslide/styles.css" rel="stylesheet" type="text/css" />
<LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css" title="custom-new-style-rg.css" />
<script src="highslide/inplace2.js" type="text/javascript"></script>
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
var horizontal_offset="9px" //horizontal offset of hint box from anchor link
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

#hintbox{ /*CSS for pop up hint box */
position:absolute;
top: 0;
background-color: lightyellow;
width: 150px; /*Default width of hint.*/ 
padding: 3px;
border:1px solid black;
font:normal 11px Verdana;
line-height:18px;
z-index:100;
border-right: 3px solid #989696;
border-bottom: 3px solid #989696;
visibility: hidden;
}

.hintanchor{ /*CSS for link that shows hint onmouseover*/
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
			<a href="#">Welcome <asp:Label ID="lbl_welcome" runat="server" Text="Label"></asp:Label> </a> | 
			
			
                <asp:LinkButton ID="LinkButton1" runat="server">Log Out</asp:LinkButton> 
		</div>
	</div>
	
	<div class="menu_1">
		<a href="#">Home</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
	</div>	
	
	<div class="welcome_pan">
		<div class="welcome_pan_left">
		    <b>TradeNet Administrator Login </b> <br />
            <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label><br />
            Login ID :<asp:Label ID="lbl_login_ID" runat="server"></asp:Label><br />
           Now : <asp:Label ID="lbl_now" runat="server" Text=""></asp:Label><br />
            Last Login : <asp:Label ID="lbl_last_login" runat="server" Text="Not Available"></asp:Label>
		</div>
		<div class="welcome_pan_right">
            
          <!--  <a href="mail/inbox.aspx" target="_blank">Inbox (<asp:Label ID="lbl_mails" runat="server" Text="0"></asp:Label>)</a>
            <a href="mail/Default.aspx" target="_blank">Switch to TradeNet Mailbox</a> -->
            
           <div>
                <a href="admin_controls.aspx" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 980, objectHeight: 900} )" class="highslide"> Admin Controls</a>
                    <div class="highslide-html-content" id="highslide-html" style="width: 980px">
	                <div class="highslide-move" style="border: 0; height: 25px; padding: 0px; cursor: default">
	                   <div class="data_admin_mid_main_top_3">
	                      <div style="float:left;clear:left;">
	                      Admin Controls
	                      </div>
	                       <div>
	                        <a href="#" onclick="return hs.close(this)" class="control">
	                                <img src="images/spacer.gif" width="50px" height="25px;" aling="right"  />
	                            </a>
	                       </div>
	                           
	                    </div>
	                
	                </div>
	                <div class="highslide-body" id="hod_runn_main"></div>
                    </div>
            </div>
            <a href="Admin_view_all_ticks.aspx" >View All Tickets</a>
             
		</div>
	</div>
	<div class="main_panal">
		<div class="admin_updater_long">
			<div class="admin_updater_long_top">
				<img src="images/Admin_Login_Next_updater_long_ico.jpg"  align="middle"/> Tickets
			</div>
			<div class="admin_updater_long_mid">
			    <div id="Disp_unread_ticks" runat="server"></div>
			</div>
			<div class="admin_updater_long_bottom"></div>
		</div>
		<div class="search_links">
		    <a href="JavaScript:history.back()"><< Back</a>
            <asp:LinkButton ID="LinkButton2" runat="server">Search Ticket</asp:LinkButton>
		</div>
		
		<asp:Panel ID="panal_post_comm" runat="server" Visible=false>
            
            <div class="PC_main_pan2">
						<div class="PC_main_pan_top">
							<img src="images/logo_search.jpg"  align="middle" /> Search Ticket
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
	</div>
</div>
<%--<DIV style="left:0px; visibility: visible; right: 0px; bottom:0px; " id="topbar">
	<TABLE width="100%">
		<TBODY><TR>
			<TD width="100%" valign="bottom">
			<div id="container">
		<div id="squish-stretch-main">
			<div class="content_myaccount" style="position: relative ! important;">
				<div>
					<div id="afc">
						<a href="#">
			                <IMG src="./images/addressbook.jpg" alt="Get Quote" border="0">
			            </a>
							<div id="tt1">
								<ul style="background: none repeat scroll 0% 0% rgb(255, 255, 255); bottom: 50px; margin-left: -47px; -moz-background-inline-policy:continuous; display: none;">
									<li>
										<div style="margin: 0pt; padding: 0pt; position: absolute; width: 20px; height: 16px; right: 2px; top: 4px; z-index: 1000;" id="test">
											 <a style="margin: 0pt; padding: 0pt; display: inline; width: 16px; height: 16px;" id="close" href="#"> 
												<img alt="close" src="images/close1.gif" border="0" height="16" width="16">
												</a> 
										</div>
										<div class="myaccount-popbox-tt">
											<div class="samp_2">
											    <div id="disp_addBook" runat="server"></div>
											</div>
										</div>
									</li>
								</ul>
							</div>
						</div>
					</div>
				
		</div>
	</div>
</div>
			</TD>
		</TR>
		
	</TBODY></TABLE>
</DIV>--%>
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

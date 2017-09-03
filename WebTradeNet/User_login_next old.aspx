<%@ Page Language="VB" AutoEventWireup="false" CodeFile="User_login_next.aspx.vb" Inherits="User_login_next" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css" title="custom-new-style-rg.css" />
<script src="highslide/inplace2.js" type="text/javascript"></script>

    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <link href="layout.css" type="text/css" rel="stylesheet"  />
    <script type="text/javascript" src="highslide/highslide.js"></script>
<script type="text/javascript" src="highslide/highslide-html.js"></script>
<link rel="stylesheet" type="text/css" href="highslide/ddlevelsmenu-base.css">
    <link rel="stylesheet" type="text/css" href="highslide/ddlevelsmenu-topbar.css">
    <script type="text/javascript" src="highslide/ddlevelsmenu.js"></script>
<link rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg.css" title="custom-new-style-rg.css" />
<script type="text/javascript" src="highslide/jquery-strech.js"></script>
<script src="highslide/custom-scripts-in.js" type="text/javascript"></script>
<link href="highslide/other-styles.css" rel="stylesheet" type="text/css" />
<link href="highslide/styles.css" rel="stylesheet" type="text/css" />


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
			<a href="#">Welcome <asp:Label ID="lbl_uname_1" runat="server" Text=""></asp:Label></a> | 
			
            <asp:LinkButton ID="btn_logout" runat="server">Log Out</asp:LinkButton>
		</div>
	</div>
	
	<div class="menu_1">
		<a href="User_login_next.aspx">Home</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
        <asp:LinkButton ID="LinkButton1" runat="server">Old Website</asp:LinkButton></div>	
	
	<div class="welcome_pan">
		<div class="welcome_pan_left"> 
		Welcome to Trade Net Customer Support Login (Branch site Display)<br />
		<asp:Label ID="lbl_uname" runat="server" Text="" Visible="false"></asp:Label>&nbsp;
		Name of User : <asp:Label ID="lbl_Emp_name" runat="server" Text=""></asp:Label><br />
		Loginer Type :<asp:Label ID="lbl_emp_typ" runat="server" Text=""></asp:Label><br />
		Branch Details : <asp:Label ID="lbl_branch_det" runat="server" Text=""></asp:Label><br />
        Last Login : <asp:Label ID="lbl_last_login" runat="server" Text=""></asp:Label><br />
		</div>
		<div class="welcome_pan_right">
            <asp:Panel ID="pnl_for_BH" runat="server" Visible="false">
           <div>
                 <a href="bh_view_running_ticks.aspx" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 980, objectHeight: 900} )" class="highslide">View Runing Queries</a> 
                    <div class="highslide-html-content" id="highslide-html" style="width: 980px">
	                <div class="highslide-move" style="border: 0; height: 25px; padding: 0px; cursor: default">
	                   <div class="data_admin_mid_main_top_3">
	                       <div style="float:left;clear:left;">
	                       View Runing Queries 
	                       </div>
	                            <a href="#" onclick="return hs.close(this)" class="control">
	                                <img src="images/spacer.gif" width="50px" height="25px;" aling="right"  />
	                            </a>
	                    </div> 
	                
	                </div>
	                <div class="highslide-body" id="hod_runn_main"></div>
                    </div>
            </div>
            <!-- <a href="mail/inbox.aspx" target="_blank">Inbox (<asp:Label ID="lbl_mails" runat="server" Text="0"></asp:Label>)</a>
            <a href="mail/Default.aspx" target="_blank">Switch to TradeNet Mailbox</a> -->
           <a href="bh_view_all_ticks.aspx" >View All Queries</a> 
         
            </asp:Panel>
		</div>
	</div>
	
	<div class="main_panal">
		<div class="main_panal_left">
			<div class="main_panal_left_inside" style="width: 44px">
			<div id="ddtopmenubar" class="mattblackmenu">
				<a href="Create_new_ticket.aspx">
					Create New Ticket !
				</a>
				<!-- <a href="mail/inbox.aspx" target="_blank">
					Inbox(<asp:Label ID="lbl_inbox" runat="server" Text="0"></asp:Label>) -->
				
				<a href="user_search_tickets.aspx"> <!--  target="_blank" -->
					Search Ticket
				</a>
                <a href="#" target="_blank"rel="Therapy">
					My Account
				</a>
			</div>
				
			</div>
		</div>
		<SCRIPT type="text/javascript">
ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</SCRIPT> 
<UL id="Therapy" class="ddsubmenustyle" style="z-index: 1000; width: auto; height: auto; overflow-x: visible; overflow-y: visible; opacity: 1; left: 0px; top: -1000px; visibility: hidden; ">
                <LI>
                    <div>
                <a href="change_password.aspx" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 500, objectHeight: 250} )" class="highslide">Change Password</a>
                    <div class="highslide-html-content" id="highslide-html" style="width: 500px">
	                <div class="highslide-move" style="border: 0; height: 25px; padding: 0px; cursor: default">
	                   <div class="data_admin_mid_main_top_3">
	                       <div style="float:left;clear:left;">
	                        Change Password
	                       </div>
	                            <a href="#" onclick="return hs.close(this)" class="control">
	                                <img src="images/close1.gif" width="20px" height="25px;" aling="right"  />
	                            </a>
	                    </div>
	                
	                </div>
	                <div class="highslide-body" id="hod_runn_main"></div>
                    </div>
            </div>
                </LI>
               
            </UL>
		<div class="main_panal_right">
		
           
				
			
		
			<div class="updater">
				<div class="updater_top"><img src="images/tiket.jpg"  /> Recent Running Ticekts</div>
				<div id="disp_ticketd" runat="server"></div>
				<div class="updater_bottom"></div>
			</div>
			
			<div class="updater">
				<div class="updater_top"><img src="images/tiket2.jpg"  />Recent Solved Ticekts</div>
				<div id="disp_solved_ticketd" runat="server"></div>
				<div class="updater_bottom"></div>
			</div>
			
			<div class="updater">
				<div class="updater_top"><img src="images/updates.jpg"  /><asp:Label ID="lbl_up_title" runat="server" Text="Letest Updates"></asp:Label></div>
				<div class="updater_mid">
				    <div id="disp_updates" runat="server"></div>	
				    <div class="em_p_lnks">
			        <a href="user_view_all_updates.aspx">View All Updates</a>
			        <a href="user_search_updates.aspx">Search Update</a>
			    </div>	
			    </div>
				<div class="updater_bottom"></div>
			</div>
			
			
		</div>	
	</div>
</div>


<DIV style="right:1px; visibility: visible; bottom:1px; " id="topbar2">
	<TABLE width="100%">
		<TBODY><TR>
			<TD width="100%" valign="bottom">
 Developed at IT Department (TradeNet Kolhapur)  			</TD>
		</TR>
	</TBODY></TABLE>
</DIV>
    </form>
</body>
</html>

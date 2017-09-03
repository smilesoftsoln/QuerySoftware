<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin_login_Next.aspx.vb" Inherits="Admin_login_Next" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <link href="layout.css" type="text/css" rel="stylesheet"  />
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
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
			<a href="#">Welcome ------ </a> | 
			
			<asp:LinkButton ID="LinkButton2" runat="server">Log Out</asp:LinkButton> 
		</div>
	</div>
	
	<div class="menu_1">
		<a href="#">Home</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
        <asp:LinkButton ID="LinkButton3" runat="server">Old Website</asp:LinkButton></div>	
	
	<div class="welcome_pan">
		TradeNet Department Employee Login
	</div>
	
	<div class="main_panal">
		<div class="admin_updater_left">
			<div class="admin_updater_left_top">
				<img src="images/Admin_Login_Next_Updater_ico.jpg"  /> Updates
			</div>
			<div class="admin_updater_left_mid">
			    <div id="disp_updates" runat="server"></div>
			    <div class="em_p_lnks">
			        <a href="Admin_view_all_updates.aspx">View All Updates</a>
			        <a href="Admin_search_updates.aspx">Search Update</a>
			    </div>
			</div>
			<div class="admin_updater_left_bottom"></div>
		</div>
		<div class="admin_updater_right">
			<div class="admin_updater_right_top">
				<img src="images/Admin_Login_Next_updater_right_ico.jpg" align="middle" /> Emergency Panal
			</div>
			<div class="admin_updater_right_mid">
			    <div id="Disp_emergencyes" runat="server"></div>
			    <div class="em_p_lnks">
                    <asp:LinkButton ID="btn_late_ticks" runat="server">Late Tickets (<asp:Label ID="lbl_late_ticks" runat="server" Text="0"></asp:Label>) <asp:Image ID="img_arrow" runat="server" ImageUrl="~/images/arrow_down.jpg" /></asp:LinkButton>
                   
			        <a href="#">View All</a>
			        <a href="#">Change Emergency Date</a>
			    </div>
			</div>
			<div class="admin_updater_right_bottom"></div>
		</div>
        <asp:Panel ID="pnl_latetics" runat="server" Visible=false>
        <div class="admin_updater_right" style="padding-top:30px;" >
			<div class="admin_updater_right_top">
				<img src="images/Admin_Login_Next_updater_right_ico.jpg" align="middle" /> Late Tickets 
				<span class="test2"><asp:LinkButton ID="LinkButton1" runat="server">(-)</asp:LinkButton></span>
			</div>
			<div class="admin_updater_right_mid">
			    <div id="Disp_late_all_ticks" runat="server"></div>
			</div>
			<div class="admin_updater_right_bottom"></div>
		</div>
        </asp:Panel>
		
	</div>
	<div class="main_panal">
		<div class="admin_updater_long">
			<div class="admin_updater_long_top">
				<img src="images/Admin_Login_Next_updater_long_ico.jpg"  align="middle"/> New Tickets
			</div>
			<div class="admin_updater_long_mid">
			    <div id="Disp_unread_ticks" runat="server"></div>
			</div>
			<div class="admin_updater_long_bottom"></div>
		</div>
	</div>
	
	<div class="main_panal">
		<div class="admin_updater_long">
			<div class="admin_updater_long_top">
				<img src="images/Admin_Login_Next_updater_long_ico.jpg"  align="middle"/> Assigned Incompleted Tasks
			</div>
			<div class="admin_updater_long_mid"></div>
			<div class="admin_updater_long_bottom"></div>
		</div>
	</div>
</div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bh_view_all_ticks.aspx.vb" Inherits="bh_view_all_ticks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css" title="custom-new-style-rg.css" />
<script src="highslide/inplace2.js" type="text/javascript"></script>
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <link href="layout.css" type="text/css" rel="stylesheet"  />
<script type="text/javascript" src="highslide/highslide.js"></script>
<script type="text/javascript" src="highslide/highslide-html.js"></script>
<link rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg.css" title="custom-new-style-rg.css">
<script type="text/javascript" src="highslide/jquery-strech.js"></script>
<script src="highslide/custom-scripts-in.js" type="text/javascript"></script>
<link href="highslide/other-styles.css" rel="stylesheet" type="text/css">
<link href="highslide/styles.css" rel="stylesheet" type="text/css">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" href="Date_picker/style.css" type="text/css" media="screen" />
	<script type="text/javascript" src="Date_picker/mootools-1.2-core.js"></script>
	<script type="text/javascript" src="Date_picker/_class.datePicker.js"></script>
	 <link href="layout.css" type="text/css" rel="stylesheet"  />
	 <script type="text/javascript">//<![CDATA[
	window.addEvent('domready',function(){

		//Ejemplo 1
		$('fecha01').datePicker();

		//Ejemplo 2
		$('fecha02').datePicker({
			klass: 'datePicker',
			days: ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'],
			draggable: true,
			position: {x:'right',y:'top'},
			offset: {x:10,y:-100},
			firstday: 3
		},'click');

		//Ejemplo 3
		var fecha03 = $('fecha03').getPrevious();
		var dp3 = $('fecha03').datePicker({
			format: '%DD %d, %MM %Y | %D %d %M %y | %Y-%m-%d',
			from: [2008,10,11],
			to: [2009,0,24],
			initial: [2008,10,18],
			setInitial: true,
			updateElement: false,
			onShow: function(container){
				container.fade('hide').fade('in');
			},
			onHide: function(container){
				container.fade('out');
			},
			onUpdate: function(){
				fecha03.set('html',this.format());
			}
		},'click');

		var inputs03 = $('sample3').getElements('input,button').associate(['fecha','formato','set']);
		inputs03.set.addEvent('click',function(){
			var date = inputs03.fecha.value.split('/');
			dp3.setFullDate(date[2].toInt(),date[1].toInt()-1,date[0].toInt());
			dp3.options.format = inputs03.formato.value;
			dp3.update();
		});

		//Ejemplo 4
		var hoy = new Date();
		var salidaFrom = new Date(hoy.getFullYear(),hoy.getMonth(),hoy.getDate()+7);
		salidaFrom = [salidaFrom.getFullYear(),salidaFrom.getMonth(),salidaFrom.getDate()];

		var dpFechaRetorno = $('fecha05_2').datePicker();
		var dpFechaSalida = $('fecha05_1').datePicker({
			from: salidaFrom,
			initial: salidaFrom,
			setInitial: true,
			onUpdate: function(date){
				var retornoFrom = new Date(date.y,date.m,date.d+14);
				var retornoTo = new Date(date.y,date.m,date.d+14+30);
				dpFechaRetorno.options.from = [retornoFrom.getFullYear(),retornoFrom.getMonth(),retornoFrom.getDate()];
				dpFechaRetorno.options.to = [retornoTo.getFullYear(),retornoTo.getMonth(),retornoTo.getDate()];
				dpFechaRetorno.setFullDate(date.y,date.m,date.d+14).update();
			}
		});

	});
	//]]></script>
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
			<a href="#">Welcome <asp:Label ID="lbl_welcome" runat="server" Text="Label"></asp:Label> </a> | 
			
			
                <asp:LinkButton ID="LinkButton1" runat="server">Log Out</asp:LinkButton> 
		</div>
	</div>
	
	<div class="menu_1">
		<a href="User_login_next.aspx"  >Home</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
	</div>	
	
	<div class="welcome_pan">
		Trade Net Customer Support Login 
	</div>
	<div class="welcome_pan3">
		Advance Option :<br />
        <asp:RadioButtonList ID="rdb_opns" runat="server" 
            RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" 
            EnableTheming="True" RepeatLayout="Flow">
            <asp:ListItem Selected="True">ALL</asp:ListItem>
            <asp:ListItem>Solved</asp:ListItem>
            <asp:ListItem>UnSolved</asp:ListItem>
            <asp:ListItem>Follow Up</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btn_go" runat="server" Text="Go" />
	</div>
	<div class="main_panal">
		<div class="admin_updater_long">
			<div class="admin_updater_long_top">
				<img src="images/Admin_Login_Next_updater_long_ico.jpg"  align="middle"/> All Queryes
			</div>
			<div class="admin_updater_long_mid">
			    <div id="disp_all_updates" runat="server"></div>
			</div>
			<div class="admin_updater_long_bottom"></div>
		</div>
		<div class="search_links">
		    <a href="JavaScript:history.back()"><< Back</a>
		    <a href="hod_search_tick_by_dept.aspx">Search Ticket</a>
            <asp:LinkButton ID="LinkButton3" runat="server">View Deleted Tickets</asp:LinkButton></div>
		
		
           
            
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

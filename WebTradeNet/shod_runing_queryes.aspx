<%@ Page Language="VB" AutoEventWireup="false" CodeFile="shod_runing_queryes.aspx.vb" Inherits="shod_runing_queryes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css" title="custom-new-style-rg.css" />
    <script src="highslide/inplace2.js" type="text/javascript"></script>
    <link href="layout.css" type="text/css" rel="stylesheet"  />
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
<script type="text/javascript">    
    hs.graphicsDir = 'highslide/graphics/';
    hs.outlineType = 'rounded-white';
    hs.outlineWhileAnimating = true;
    hs.objectLoadTime = 'after';
</script>
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
    <asp:Panel ID="pnl_main" runat="server">
    <div class="hod_runn_main">
        <div class="ff_window">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td >
                    <img src="images/nev_btns.jpg" border="0" usemap="#Map" />
                    <map name="Map" id="Map">
                    <area shape="circle" coords="18,18,13" href="JavaScript:history.back()" />
                    <area shape="circle" coords="53,17,12" href="JavaScript:history.forward()" />
                    </map>
                </td>
                <td class="spcl_td_style">
                     Search : 
                    <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>
                    
                </td>
                <td class="spcl_td_style">
                    <asp:LinkButton ID="LinkButton1" runat="server">View Queries By Employee</asp:LinkButton>
                </td>
            </tr>
        </table>
        
            
           
      </div>
        
        
        
        <asp:Panel ID="pnl_main_" runat="server">
            <div id="disp_result" runat="server"></div>
        </asp:Panel>
        <asp:Panel ID="pnl_search" runat="server" Visible="false">
            <div id="disp_search_result" runat="server"></div>
        </asp:Panel>
    </div>
    </asp:Panel>
    

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

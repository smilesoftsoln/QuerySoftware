<%@ Page Language="VB" AutoEventWireup="false" CodeFile="shod_login_Next.aspx.vb"
    Inherits="shod_login_Next" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <link rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css"
        title="custom-new-style-rg.css" />



   
    
    <script src="highslide/inplace2.js" type="text/javascript"></script>

    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <meta http-equiv="REFRESH" content="300">
    <link href="layout.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="highslide/highslide.js"></script>

    <script type="text/javascript" src="highslide/highslide-html.js"></script>

    <link rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg.css" title="custom-new-style-rg.css">

    <script type="text/javascript" src="highslide/jquery-strech.js"></script>

    <script src="highslide/custom-scripts-in.js" type="text/javascript"></script>

    <link href="highslide/other-styles.css" rel="stylesheet" type="text/css">
    <link href="highslide/styles.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="highslide/ddlevelsmenu-base.css">
    <link rel="stylesheet" type="text/css" href="highslide/ddlevelsmenu-topbar.css">

    <script type="text/javascript" src="highslide/ddlevelsmenu.js"></script>

    <script src="jTable/lib/jquery/jquery.js" type="text/javascript"></script>
     <script src="js/jquery.messagebar.js" type="text/javascript"></script>
    <%--<script type="text/javascript">    
    hs.graphicsDir = 'highslide/graphics/';
    hs.outlineType = 'rounded-white';
    hs.outlineWhileAnimating = true;
    hs.objectLoadTime = 'after';
    </script>--%>

    <style type="text/css">
        .highslide-html
        {
            background-image: url( 'images/rise_mid.jpg' );
            background-repeat: repeat-y;
            background-color: #FFFFFF;
        }
        .highslide-html-content
        {
            position: absolute;
            display: none;
            width: 500px;
        }
        .highslide-loading
        {
            display: block;
            color: black;
            font-size: 8pt;
            font-family: sans-serif;
            font-weight: bold;
            text-decoration: none;
            padding: 0px;
            border: 0px solid black;
            background-color: white;
        }
        .control
        {
            float: right;
            display: block;
            margin: 0 0px;
            font-size: 9pt;
            font-weight: bold;
            text-decoration: none;
            text-transform: uppercase;
            color: #999;
        }
        .control:hover
        {
            color: black !important;
        }
        .highslide-move
        {
            cursor: move;
            background-image: url( 'images/rise_top.jpg' );
            background-repeat: no-repeat;
            height: 25px;
            background-color: Transparent;
        }
        .highslide-display-block
        {
            display: block;
        }
        .highslide-display-none
        {
            display: none;
        }
        a img
        {
            border: 0px;
        }
        #message_bar
        {
            padding:10px;	
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

    <script type="text/javascript">
var horizontal_offset="9px"
var vertical_offset="0" 
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
        #hintbox
        {
            /*CSS for pop up hint box */
            position: absolute;
            top: 0;
            background-color: lightyellow;
            width: 150px; /*Default width of hint.*/
            padding: 3px;
            border: 1px solid black;
            font: normal 11px Verdana;
            line-height: 18px;
            z-index: 100;
            border-right: 3px solid #989696;
            border-bottom: 3px solid #989696;
            visibility: hidden;
        }
        .hintanchor
        {
            /*CSS for link that shows hint onmouseover*/
            font-weight: bold;
            color: navy;
            margin: 3px 8px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function(){
            $('#ShowSubList').click(function(){
                $('#DispNone').removeClass('DispNone');
                $('#DispNone').addClass('DispY');
            });
            
            $('#ifClose').click(function(){
                $('#DispNone').removeClass('DispY');
                $('#DispNone').addClass('DispNone');
            });
            $('.ifClose').click(function(){
                $('#DispNoneALL').removeClass('DispY');
                $('#DispNoneALL').addClass('DispNone');
            });
            
            $("#ViewAllApps").click(function(){
                $('#AppRovles').removeClass('DispNone');
                $('#AppRovles').addClass('DispY');
            });
            
            $('.AppClose').click(function(){
                $('#AppRovles').removeClass('DispY');
                $('#AppRovles').addClass('DispNone');
            });
        });
    </script>
    
    <script type="text/javascript">
        $(document).ready(function(){
            $('#ShowSubListALL').click(function(){
                $('#DispNoneALL').removeClass('DispNone');
                $('#DispNoneALL').addClass('DispY');
            });
            
            $('#ifClose').click(function(){
                $('#DispNoneALL').removeClass('DispY');
                $('#DispNoneALL').addClass('DispNone');
            });
        });
    </script>
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
    <div id="message_bar" style="display:none;">
        <div id="alerts" runat="server"></div>
    </div>
  

<script type="text/javascript">

$(document).ready(function() {
     $('.vista').click(function(event){
        event.preventDefault();
        $('#message_bar').displayMessage({
          color : 'white',
          skin : 'vista'
        });
     });
});
</script>
    <div class="main_page">
        <div class="top">
            <div class="top_left">
                <a href="#">
                    <img src="images/TN_CAREE.jpg" /></a>
            </div>
            <div class="top_right">
                Welcome
                    <asp:Label ID="lbl_welcome" runat="server" Text=""></asp:Label>
                |
                <asp:LinkButton ID="LinkButton1" runat="server">Log Out</asp:LinkButton>
                <br />
            </div>
        </div>
        <div class="menu_1">
            <div id="ddtopmenubar" class="mattblackmenu">
                <a href="#">Home</a> <a href="#">About Us</a> <a href="#">Support</a> <a href="#"
                    rel="Therapy">My Account</a> <a href="Todo/hod_login_next.aspx" rel="" target="_blank">My
                        Task Master</a>
                        <span id="msgsSpan" runat="server">
                        
                        </span>
            </div>
        </div>
        <div class="welcome_pan">
            <div class="welcome_pan_left">
                TradeNet Super Head Of Department
                <asp:Label ID="Label1" runat="server" Text="SHOD"></asp:Label>
                Panel:<br />
                <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label><br />
                Department :
                <asp:Label ID="lbl_dept" runat="server" Text=""></asp:Label><br />
                Now :
                <asp:Label ID="lbl_now" runat="server" Text=""></asp:Label><br />
                Last Login :
                <asp:Label ID="lbl_last_login" runat="server" Text="Not Available"></asp:Label>
            </div>
            <div class="welcome_pan_right">
                <div>
                    <a href="shod_runing_queryes.aspx" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 900, objectHeight: 800} )"
                        class="highslide">View Running Queries</a>
                    <div class="highslide-html-content" id="highslide-html" style="width: 900px">
                        <div class="highslide-move" style="border: 0; height: 25px; padding: 0px; cursor: default">
                            <div class="data_admin_mid_main_top_3">
                                <div style="float: left; clear: left;">
                                    View Running Queries
                                </div>
                                <a href="#" onclick="return hs.close(this)" class="control">
                                    <img src="images/close1.gif" width="25px" height="25px;" aling="right" alt="" />
                                </a>
                            </div>
                        </div>
                        <div class="highslide-body" id="hod_runn_main">
                        </div>
                    </div>
                </div>
                <div>
                    <%--<a href="hod_online_users.aspx" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 900, objectHeight: 800} )"
                        class="highslide">Online Users</a>--%>
                    <%--<div class="highslide-html-content" id="Div1" style="width: 900px">
                        <div class="highslide-move" style="border: 0; height: 25px; padding: 0px; cursor: default">
                            <div class="data_admin_mid_main_top_3">
                                <div style="float: left; clear: left;">
                                    Online Users
                                </div>
                                <a href="#" onclick="return hs.close(this)" class="control">
                                    <img src="images/close1.gif" width="25px" height="25px;" aling="right" alt="" />
                                </a>
                            </div>
                        </div>
                        <div class="highslide-body" id="Div2">
                        </div>
                    </div>--%>
                </div>
                <!-- <a href="mail/inbox.aspx" target="_blank">Inbox (<asp:Label ID="lbl_mails" runat="server" Text="0"></asp:Label>)</a>
            <a href="mail/Default.aspx" target="_blank">Switch to TradeNet Mailbox</a> -->
                <a href="hod_view_all_ticks.aspx">View All Queries</a>
                <asp:Label ID="lbl_tot_apps" runat="server" Text=""></asp:Label>
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <a href="Admin_view_all_ticks.aspx">View All departments Queries</a>
                </asp:Panel>
                <div id="t_subList" runat="server">
                </div>
                <div id="T_appList" runat="server"></div>
                <span id="informToCnt" runat="server"></span>
                
                <div id="t_subListALL" runat="server">
                </div>
                <span id="informToCntALL" runat="server"></span>
            </div>
        </div>
        <div class="main_panal">
        <div class="admin_updater_long">
                <div class="admin_updater_long_top">
                    <img src="images/Admin_Login_Next_updater_long_ico.jpg" align="middle" />&nbsp; 
                    Tickets Escalated To Management
                    
                </div>
                <div class="admin_updater_long_mid">
                    <div id="Div3" runat="server">
                    </div>
                </div>
            </div>
            <div class="admin_updater_long">
                <div class="admin_updater_long_top">
                    <img src="images/Admin_Login_Next_updater_long_ico.jpg" align="middle" /> All
                    Tickets&nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/images/Btn_Export_2.gif" />
                </div>
                <div class="admin_updater_long_mid">
                    <div id="Disp_unread_ticks" runat="server">
                    </div>
                </div>
                <div class="admin_updater_long_bottom">
                </div>
            </div>
            <div class="search_links">
                <a href="JavaScript:history.back()"><< Back</a>
                <asp:LinkButton ID="LinkButton2" runat="server">Search Ticket</asp:LinkButton>
            </div>
            <asp:Panel ID="panal_post_comm" runat="server" Visible="false">
                <div class="PC_main_pan2">
                    <div class="PC_main_pan_top">
                        <img src="images/logo_search.jpg" align="middle" />
                        Search Ticket
                    </div>
                    <div class="PC_main_pan_mid">
                        Search :
                        <asp:TextBox ID="txt_search" runat="server" Width="638px"></asp:TextBox>
                        <div class="comm_btns">
                            <asp:LinkButton ID="btn_post" runat="server">Go >></asp:LinkButton>
                        </div>
                    </div>
                    <div class="PC_main_pan_bottom">
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

    <script type="text/javascript">
ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
    </script>

    <ul id="Therapy" class="ddsubmenustyle" style="z-index: 1000; width: auto; height: auto;
        overflow-x: visible; overflow-y: visible; opacity: 1; left: 0px; top: -1000px;
        visibility: hidden;">
        <li>
            <div>
                <a href="change_password.aspx" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 500, objectHeight: 250} )"
                    class="highslide">Change Password</a>
                <div class="highslide-html-content" id="highslide-html" style="width: 500px">
                    <div class="highslide-move" style="border: 0; height: 25px; padding: 0px; cursor: default">
                        <div class="data_admin_mid_main_top_3">
                            <div style="float: left; clear: left;">
                                Change Password
                            </div>
                            <a href="#" onclick="return hs.close(this)" class="control">
                                <img src="images/close1.gif" width="20px" height="25px;" aling="right" />
                            </a>
                        </div>
                    </div>
                    <div class="highslide-body" id="hod_runn_main">
                    </div>
                </div>
            </div>
        </li>
    </ul>
    <div style="right: 1px; visibility: visible; bottom: 1px;" id="topbar2">
        <table width="100%">
            <tbody>
                <tr>
                    <td width="100%" valign="bottom">
                        Developed at IT Department (TradeNet Kolhapur)  	
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="view_all_ticks.aspx.vb" Inherits="admin_view_all_ticks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View All Tickets</title>
    <script src="scripts/jquery.js" type="text/javascript"></script>
<script src="scripts/jquery_002.js" type="text/javascript"></script>
<link rel="stylesheet" href="scripts/validationEngine.css" type="text/css" />
    
<link href="admin_panal_style.css" type="text/css" rel="stylesheet"  />
<script type="text/javascript">
        var ns4=document.layers
        var ie4=document.all
        var ns6=document.getElementById&&!document.all
        var dragswitch=0
        var nsx
        var nsy
        var nstemp
        function drag_dropns(name){
        if (!ns4)
        return
        temp=eval(name)
        temp.captureEvents(Event.MOUSEDOWN | Event.MOUSEUP)
        temp.onmousedown=gons
        temp.onmousemove=dragns
        temp.onmouseup=stopns
        }
        function gons(e){
        temp.captureEvents(Event.MOUSEMOVE)
        nsx=e.x
        nsy=e.y
        }
        function dragns(e){
        if (dragswitch==1){
        temp.moveBy(e.x-nsx,e.y-nsy)
        return false
        }
        }
        function stopns(){
        temp.releaseEvents(Event.MOUSEMOVE)
        }
        function drag_drop(e){
        if (ie4&&dragapproved){
        crossobj.style.left=tempx+event.clientX-offsetx
        crossobj.style.top=tempy+event.clientY-offsety
        return false
        }
        else if (ns6&&dragapproved){
        crossobj.style.left=tempx+e.clientX-offsetx+"px"
        crossobj.style.top=tempy+e.clientY-offsety+"px"
        return false
        }
        }
        function initializedrag(e){
        crossobj=ns6? document.getElementById("showimage") : document.all.showimage
        var firedobj=ns6? e.target : event.srcElement
        var topelement=ns6? "html" : document.compatMode && document.compatMode!="BackCompat"? "documentElement" : "body"
        while (firedobj.tagName!=topelement.toUpperCase() && firedobj.id!="dragbar"){
        firedobj=ns6? firedobj.parentNode : firedobj.parentElement
        }
        if (firedobj.id=="dragbar"){
        offsetx=ie4? event.clientX : e.clientX
        offsety=ie4? event.clientY : e.clientY
        tempx=parseInt(crossobj.style.left)
        tempy=parseInt(crossobj.style.top)
        dragapproved=true
        document.onmousemove=drag_drop
        }
        }
        document.onmouseup=new Function("dragapproved=false")
        function hidebox(){
        crossobj=ns6? document.getElementById("showimage") : document.all.showimage
        if (ie4||ns6)
        crossobj.style.visibility="hidden"
        else if (ns4)
        document.showimage.visibility="hide"
        }
        </script>
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
	padding: 2px;
	border: 1px solid black;
    background-color: white;
}

.control {
	float: right;
    display: block;
	margin: 0 5px;
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
    height:22px;
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
<script type="text/javascript" src="highslide/highslide.js"></script>
<script type="text/javascript" src="highslide/highslide-html.js"></script>
</head>
<body>
    <form id="form1" runat="server">
  <div class="web_page">
		<div class="top">
			<div style="float:right;clear:right;padding-right:10px;padding-top:5px;">
                <asp:LinkButton ID="LinkButton1" runat="server">Log Out</asp:LinkButton>
		    </div>
		</div>
		<div class="menu">
			<a id="homelink" runat="server" href="Login_Next.aspx" >Home</a>
			<a href="JavaScript:history.back()">&laquo;  Back</a>
			<a href="JavaScript:history.forward()">Forward &raquo;</a>
		</div>
		
		<div class="main_body">
			<div></div>
			<iframe src="../Admin_view_all_ticks.aspx" width="100%" height="440px;" frameborder="0" >

</iframe>
		</div>
	</div>
    </form>
</body>
</html>

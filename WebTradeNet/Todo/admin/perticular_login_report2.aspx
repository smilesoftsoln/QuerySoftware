<%@ Page Language="VB" AutoEventWireup="false" CodeFile="perticular_login_report2.aspx.vb" Inherits="admin_perticular_login_report2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>Perticular Login Report</title>
    <script src="scripts/jquery.js" type="text/javascript"></script>
<script src="scripts/jquery_002.js" type="text/javascript"></script>
<link rel="stylesheet" href="scripts/validationEngine.css" type="text/css" />
<link href="admin_panal_style.css" type="text/css" rel="stylesheet"  />

<link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css" />
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>

<script type="text/javascript" src="Date_picker/mootools-1.2-core.js"></script>
<script type="text/javascript" src="Date_picker/_class.datePicker.js"></script>
<script type="text/javascript">//<![CDATA[
	window.addEvent('domready',function(){
		$('fecha01').datePicker();
		$('fecha02').datePicker();
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
.highslide-html 
{
    background-image:url('images/rise_mid.jpg');
    background-repeat:repeat-y;
}
.highslide-html-content 
{
	position: absolute;
    display: none;
    width:500px;
}
.highslide-loading 
{
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

.control 
{
	float: right;
    display: block;
	margin: 0 5px;
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
    background-image:url('images/rise_top.jpg');
    background-repeat:no-repeat;
    height:22px;
    background-color:Transparent;
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
    border:0px;	
}
</style>
<script type="text/javascript" src="highslide/highslide.js"></script>
<script type="text/javascript" src="highslide/highslide-html.js"></script>
<link rel="stylesheet" href="Date_picker/style.css" type="text/css" media="screen" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="web_page">
		<div class="top">
		</div>
		<div class="menu">
			<a href="Login_Next.aspx">Home</a>
			<a href="JavaScript:history.back()">&laquo;  Back</a>
			<a href="JavaScript:history.forward()">Forward &raquo;</a>
		</div>
		<div class="main_body">
			<div class="main_body_left">
				<ul>
					<li> 
							<span class="span_1">Favorites </span>
							<ul>
								<div id="disp_fev" runat="server"></div>
							</ul>
					</li>
					
				</ul>
				<ul>
				    <li>
					    <span class="span_1"><asp:LinkButton ID="btn_add_to_fev" runat="server">Add To Favorites</asp:LinkButton></span>
					</li>
					<li>
					    <div class="span_1">
					        <a href="edit_fev.aspx" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',objectWidth:500, objectHeight: 150} )" class="highslide">Edit Favorites</a>
					        <div class="highslide-html-content" id="highslide-html">
	                        <div class="highslide-move" style="border: 0; height: 18px; padding: 2px; cursor: default">
	                            <div class="data_admin_mid_main_top_3">
	                                
	                            Edit Favorites
	                            <a href="#" onclick="return hs.close(this)" class="control">
	                                <img src="../images/spacer.gif" width="50px" height="30px;" aling="right"  />
	                            </a>
	                            </div>
	                        </div><div class="highslide-body"></div>
	                        </div>
					    </div>
					</li>
				</ul>
			</div>
			<div class="main_body_right">
				<h2>Perticular Login Report</h2>
<hr />
<div class="welcome_pan">

<table>
    <tr>
        <td>
        <fieldset class="fieldset_css">
            <legend>
                Select Type
           </legend>
        <asp:DropDownList ID="cbo_users" runat="server">
            
        </asp:DropDownList>
    </fieldset>
        </td>
        <td>
            
         <fieldset >
            <legend>
                Select Date
            </legend>
          From   
            <asp:TextBox ID="fecha01" runat="server" ></asp:TextBox> To <asp:TextBox ID="fecha02" runat="server"></asp:TextBox>
               
         </fieldset>
           
            
            
        </td>
        <td>
            <div >
            
            <asp:Button ID="btn_go" runat="server" Text=" Go »» " /><br />
            <asp:Button ID="btn_export" runat="server" Text="Export" /><br />
            
            </div>
        </td>
    </tr>
</table>

    
    
    
    
    
</div>
<hr />
<div id="disp_result" runat="server"></div>
<script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
</script>
			</div>
		</div>
	</div>
	 <div id="Disp_alertbox" runat="server"></div>
    </form>
</body>
</html>

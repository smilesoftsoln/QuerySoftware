<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admin_view_tickets_by_timespan.aspx.vb" Inherits="admin_view_tickets_by_timespan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
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
		<a href="main_admin_login_Next.aspx" >Home</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
	</div>	
	
	<div class="welcome_pan">
		Trade Net Customer Support Admin Login 
	</div>
	<div class="main_panal">
		
		
		
		<asp:Panel ID="panal_post_comm" runat="server" Visible="true">
            
            <div class="PC_main_pan3">
						<div class="PC_main_pan_top">
							<img src="images/logo_search.jpg"  align="middle" />Get Tickets By Timespan
						</div>
						<div class="PC_main_pan_mid">
						    <div id="cont">
                            <!-- EJEMPLO 1 -->
                                Select Date : <asp:TextBox ID="fecha01" runat="server"></asp:TextBox> To <asp:TextBox ID="fecha02" runat="server"></asp:TextBox> 
                                <asp:Button ID="btn_go" runat="server" Text=" GO > " />
                            </div>
						</div>
						<div class="PC_main_pan_bottom"></div>
				</div>
            </asp:Panel>
            
        <asp:Panel ID="pnl_search_resut" runat="server" Visible="false">
        <div class="admin_updater_long">
			<div class="admin_updater_long_top">
				<img src="images/Admin_Login_Next_updater_long_ico.jpg"  align="middle"/> Tickets <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 
               
			</div>
			<div class="admin_updater_long_mid">
			    <div id="Disp_timespan_ticks" runat="server"></div>
			</div>
			<div class="admin_updater_long_bottom"></div>
		</div>
        </asp:Panel>
            <div class="search_links">
		    <a href="JavaScript:history.back()"><< Back</a>
		    <a href="main_admin_login_Next.aspx">Home</a>
            
		</div>
	</div>
	
	
</div>
    </form>
</body>
</html>

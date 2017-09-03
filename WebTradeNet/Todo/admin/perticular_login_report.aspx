<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="perticular_login_report.aspx.vb" Inherits="admin_perticular_login_report" title="Perticular Login Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css" />
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="Date_picker/style.css" type="text/css" media="screen" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <br />
            <asp:Button ID="btn_go" runat="server" Text=" Go »» " /><br />
            
            </div>
        </td>
    </tr>
</table>

    
    
    
    
    
</div>
</asp:Content>


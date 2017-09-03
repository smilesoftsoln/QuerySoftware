﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin_view_all_ticks.aspx.vb"
    Inherits="Admin_view_all_ticks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <link rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css"
        title="custom-new-style-rg.css" />

    <script src="highslide/inplace2.js" type="text/javascript"></script>

    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <link href="layout.css" type="text/css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="Date_picker/style.css" type="text/css" media="screen" />

    <script type="text/javascript" src="Date_picker/mootools-1.2-core.js"></script>

    <script type="text/javascript" src="Date_picker/_class.datePicker.js"></script>

    <link href="layout.css" type="text/css" rel="stylesheet" />

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
        #hintbox
        {
            /*CSS for pop up hint box */
            position: absolute;
            top: 0;
            background-color: Yellow;
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
        .otherdate
        {
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
function DIV1_onclick() {

}

    </script>

    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tool1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="main_page2">
        <div class="welcome_pan4">
            <div class="potion_pan">
                Advance Option :<br />
                <asp:RadioButtonList ID="rdb_opns" runat="server" CellPadding="0" CellSpacing="0"
                    EnableTheming="True" RepeatLayout="Flow">
                    <asp:ListItem Selected="True">ALL</asp:ListItem>
                    <asp:ListItem>Solved</asp:ListItem>
                    <asp:ListItem>UnSolved</asp:ListItem>
                    <asp:ListItem>FOLLOW UP</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <!-- -->
            <div class="potion_pan">
                <asp:Panel ID="Panel1" runat="server">
                    Select Department :<br />
                    <asp:DropDownList ID="cbo_depts" runat="server">
                    </asp:DropDownList>
                </asp:Panel>
                <div>
                    Select Branch :
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cbo_brances" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="potion_pan">
                <asp:Panel ID="Panel2" runat="server" Visible="true">
                    <div id="cont">
                        Select Date :
                        <br />
                        <asp:UpdatePanel ID="upcal" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtdatefrom" runat="server" Width="75px" Enabled="False"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Admin_Login_Next_updater_long_ico.jpg" /><!-- -->
                                <div id="divcal1" runat="server" visible="false" style="position: absolute; top: 150px;
                                    left: 398px;  ">
                                    <asp:Calendar ID="cal" OtherMonthDayStyle-CssClass="otherdate"
                                        TodayDayStyle-Font-Bold="true" TodayDayStyle-BackColor="White" 
                                        OtherMonthDayStyle-Font-Strikeout="true" runat="server" BackColor="White" 
                                        BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                                        ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                        <TodayDayStyle BackColor="#CCCCCC" />
                                        <OtherMonthDayStyle Font-Strikeout="True" Height="0px" Width="0px" />
                                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                                            VerticalAlign="Bottom" />
                                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                                            Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                    </asp:Calendar>
                                    <asp:Calendar ID="Calendar1" OtherMonthDayStyle-CssClass="otherdate"
                                        TodayDayStyle-Font-Bold="true" TodayDayStyle-BackColor="White"  
                                        OtherMonthDayStyle-Font-Strikeout="true" runat="server" BackColor="White" 
                                        BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                                        ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                        <TodayDayStyle BackColor="#CCCCCC" />
                                        <OtherMonthDayStyle Font-Strikeout="True" Height="0px" Width="0px" />
                                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                                            VerticalAlign="Bottom" />
                                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                                            Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                    </asp:Calendar>
                                </div>
                                To
                                <asp:TextBox ID="txtdateto"  Enabled="False" runat="server" Width="75px"></asp:TextBox>
                              <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Admin_Login_Next_updater_long_ico.jpg" /><!-- -->
                              
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="cal" EventName="SelectionChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        Select Sender :<br />
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cboSender" runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </div>
            <div class="potion_pan">
                Select Type :<br />
                <asp:DropDownList ID="cbo_type" runat="server">
                    <asp:ListItem>ALL</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Escalated</asp:ListItem>
                    <asp:ListItem>Transferred</asp:ListItem>
                    <asp:ListItem>DELETED</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:ImageButton ID="btn_go" runat="server" ImageUrl="~/images/btn_go_2.gif" />
            <br />
            <asp:ImageButton ID="btn_exp" runat="server" ImageUrl="~/images/btn_export.gif" />
            <asp:LinkButton ID="LinkButton3" runat="server">ReSet</asp:LinkButton>
        </div>
        <div class="welcome_pan4">
            <table width="40%">
                <tr>
                    <td>
                        <img src="images/typ_escelated.jpg" />
                        Escalated
                    </td>
                    <td>
                        <img src="images/typ_normal.JPG" />
                        Normal
                    </td>
                    <td>
                        <img src="images/typ_transferd.jpg" />
                        Transferred
                    </td>
                    <td>
                        <img src="images/typ_deleted.jpg" />
                        Deleted
                    </td>
                </tr>
            </table>
        </div>
        <div class="main_panal">
            <div class="admin_updater_long">
                <div class="admin_updater_long_top">
                    <img src="images/Admin_Login_Next_updater_long_ico.jpg" align="middle" />
                    <asp:Label ID="pnl_ticket_typ" runat="server" Text=""></asp:Label>
                </div>
                <div class="admin_updater_long_mid" id="DIV1" language="javascript" onclick="return DIV1_onclick()">
                    <div id="Disp_unread_ticks" runat="server">
                    </div>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="false" CellPadding="4" GridLines="None"
                        EnableTheming="True" ForeColor="#333333" EnableSortingAndPagingCallbacks="True"
                        PageSize="10000">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <br />
                    <br />
                    <div style="display: none;" runat="server">
                        <asp:GridView ID="GridView2" runat="server" CellPadding="4" EnableTheming="False"
                            ForeColor="#333333" BorderStyle="Solid">
                            <RowStyle BackColor="White" ForeColor="#000" />
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#000" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="admin_updater_long_bottom">
                </div>
            </div>
            <hr />
            <div class="search_links">
                <a href="JavaScript:history.back()">&lt;&lt; Back
                    <asp:LinkButton ID="LinkButton2" runat="server" Visible="false">Search Ticket</asp:LinkButton>
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
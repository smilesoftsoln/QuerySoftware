
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Create_new_ticket.aspx.vb" ValidateRequest="false"  Trace="false" Inherits="Create_new_ticket" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script src="highslide/jquery.js" type="text/javascript"></script>
<script src="highslide/jquery_002.js" type="text/javascript"></script>
<link rel="stylesheet" href="highslide/validationEngine.css" type="text/css">
    <title>TradeNet</title>
    <LINK rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css" title="custom-new-style-rg.css" />
    <script src="highslide/inplace2.js" type="text/javascript"></script>
    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <link href="layout.css" type="text/css" rel="stylesheet"  />
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
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_page">
	<div class="top">
		<div class="top_left"> 
			<a href="#"><img src="images/TN_CAREE.jpg" /></a>
		</div>
		<div class="top_right">
			<a href="#">Welcome 
                <asp:Label ID="lbl_uname_1" runat="server"></asp:Label> </a> | 
			
			 <asp:LinkButton ID="btn_logout" runat="server">Log Out</asp:LinkButton>
		</div>
	</div>
	
	<div class="menu_1">
		<a href="User_login_next.aspx">Home</a>
		<a href="#">About Us</a>
		<a href="#">Support</a>
		<a href="#">Join Us</a>
	</div>	
	
	<div class="welcome_pan">
		Welcome to Trade Net Customer Support Login, 
	</div>
	
	<div class="main_panal">
		<div class="main_panal_left">
			<div class="main_panal_left_inside">
				<a href="Create_new_ticket.aspx">
					Create New Ticket !
				</a>
				
			</div>
		</div>
		<div class="main_panal_right">
			<div class="new_ticket_main">
				<div class="new_ticket_top">
					<img src="images/New_ticket_ico.jpg"  align="middle"/> New Ticket
				</div>
				<div class="new_ticket_mid">
						<table>
						        <tr>
									<td width="148" style="height: 74px" >
										To Department :
									</td>
									<td style="height: 74px">
                                        <asp:DropDownList ID="cbo_depts" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:DropDownList>
                                        <asp:Panel ID="pnl_for_BH" runat="server" Wrap="False" CssClass="css_direct_to" 
                                            Visible="False">
                                            Direct To : <asp:RadioButtonList ID="rdb_direct" runat="server"  
                                                RepeatDirection="Horizontal" Width="116px" RepeatLayout="Flow" 
                                                Height="19px" >
                                                <asp:ListItem>HOD</asp:ListItem>
                                                    </asp:RadioButtonList>
                                        </asp:Panel>
                                    </td>
								</tr>
								<tr>
									<td width="148" >
										Subject :
									</td>
									<td>
										<asp:TextBox ID="txt_sub" runat="server" class="validate[required]" name="developername" Width="390px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ErrorMessage="Required Field" ControlToValidate="txt_sub"></asp:RequiredFieldValidator>
                                    </td>
								</tr>
								<tr>
									<td>
										Description :
									</td>
									<td>
										 <asp:TextBox ID="txt_desc" runat="server" Height="161px" TextMode="MultiLine"  class="validate[required],length[0,4000]]" name="developername"
                                            Width="390px"></asp:TextBox> 
                                            <%--<FTB:FreeTextBox id="txt_desc"  
			                                Focus="true"
			                                SupportFolder="aspnet_client/"
			                                JavaScriptLocation="ExternalFile" 
			                                ButtonImagesLocation="ExternalFile"
			                                ToolbarImagesLocation="ExternalFile"
			                                ToolbarStyleConfiguration="Office2000"			
			                                toolbarlayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,Delete,InsertTable;"
			                                runat="Server"
			                                GutterBackColor="red" AllowHtmlMode="False" ButtonSet="Office2000" 
                                        SslUrl="/" ToolbarBackColor="SkyBlue" AutoParseStyles="True" 
                                                ButtonDownImage="False" Width="100%" EnableHtmlMode="False" HtmlModeDefaultsToMonoSpaceFont="False" BreakMode="LineBreak"		 
			                                />--%>
&nbsp;</td>
								</tr>
								
								
								<tr>
									<td>
                                        Attachment :
									</td>
									<td>
										<asp:FileUpload ID="fUpp" runat="server" />
&nbsp;</td>
								</tr>
								
								<tr>
									<td>
										
									</td>
									<td>
										<asp:ImageButton ID="btn_submit" runat="server" 
                                            ImageUrl="images/New_ticket_Submit.jpg" />
&nbsp;  <a href="create_new_ticket.aspx" ><img src="images/New_ticket_cancel.jpg" /></a>
&nbsp;</td>
								</tr>
						</table>
				</div>
				<div class="new_ticket_bottom"></div>
			
			</div>
		</div>	
	</div>
</div>
<div id="Disp_this" runat="server"></div>


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

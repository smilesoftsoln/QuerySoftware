<%@ Page Language="VB" AutoEventWireup="false" CodeFile="hod_view_tixk_nvsbl.aspx.vb"
    Inherits="hod_view_tixk_nvsbl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TradeNet</title>
    <link rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css"
        title="custom-new-style-rg.css" />

    <script src="highslide/inplace2.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" href="highslide/custom-new-style-rg2.css"
        title="custom-new-style-rg.css" />

    <script src="jTable/lib/jquery/jquery.js" type="text/javascript"></script>

    <script src="highslide/inplace2.js" type="text/javascript"></script>


    <link href="images/tn_ico_logo.gif" rel="icon" type="image/vnd.microsoft.icon" />
    <link href="layout.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .click3
        {
            width: 300px;
            height: auto;
            border: 2px solid #3abfce;
            position: absolute;
            background: #c5eff3;
            display: none;
            margin: 100px 0 0 300px;
            padding-bottom: 10px;
        }
        *html .click3
        {
            margin: -130px 0 0 -350px;
        }
        .DispNN
        {
            display:none;	
            font-size:40px;
        }
    </style>
    
    <script type="text/javascript">
    $(document).ready(function(){   
        $('#infTo').addClass('DispNN');
        $('#Inform_ToID').click(function(){
            $('#infTo').removeClass('DispNN'); 
            $('#infTo').addClass('infTo');   
        });
        
        $('#ifClose').click(function(){
            $('#infTo').addClass('DispNN');
        });
        
        $('#Button3').click(function(){
            $('#infTo').addClass('DispNN');
        });
        
        $('#txt_comment').click(function(){
            if(document.getElementById("txt_comment").value=="Comment")
            {
                document.getElementById("txt_comment").value="";
            }
        });
    });
    </script>

    <script type="text/javascript">
  		var xmlhttp=null;
		function showDiv(id)
		{
	
			 if(id==3)
			{
				document.getElementById('div_block_all').style.display='none';
				document.getElementById('div_verfication_all').style.display='none';
				document.getElementById('div_unblock_all').style.display='none';
				document.getElementById('div_unblockone').style.display='none';
				document.getElementById('div_result').style.display='none';
				document.getElementById('div_confirm_one').style.display='none';
				document.getElementById('div_confirm_all').style.display='none';
				document.getElementById('div_blockone').style.display='block';
				document.getElementById('div_checkall').style.display='none';
				document.getElementById('div_checkone').style.display='none';
				document.getElementById('div_verfication_unblock_all').style.display='none';
				document.getElementById('txt_from').value="";
				document.getElementById('txt_to').value="";
				document.getElementById('txt_from').focus();				
			}
			
		}
		function cancel1()
			{
				document.getElementById('div_block_all').style.display='none';
				document.getElementById('div_verfication_all').style.display='none';
				document.getElementById('div_unblock_all').style.display='none';
				document.getElementById('div_verfication_unblock_all').style.display='none';
				document.getElementById('div_confirm_all').style.display='none';
				document.getElementById('div_confirm_unblockall').style.display='none';				
				document.getElementById('div_blockone').style.display='none';
				document.getElementById('div_confirm_one').style.display='none';
				document.getElementById('div_unblockone').style.display='none';	
				document.getElementById('div_confirm_unblockone').style.display='none';		
				document.getElementById('div_checkall').style.display='none';	
				document.getElementById('div_checkone').style.display='none';
				document.getElementById('div_verfication_blockone').style.display='none';
				document.getElementById('div_verfication_unblockone').style.display='none';				
				document.getElementById('div_result').style.display='none';
			}
    </script>

    <script type="text/javascript">    
    hs.graphicsDir = 'highslide/graphics/';
    hs.outlineType = 'rounded-white';
    hs.outlineWhileAnimating = true;
    hs.objectLoadTime = 'after';
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
        .style1
        {
            background-image: url('images/View_ticket_top_top.jpg' );
            width: 725px;
            height: 14px;
            background-repeat: no-repeat;
        }
        .style2
        {
            background-image: url('images/View_ticket_bottom_bottom.jpg' );
            height: 52px;
            width: 726px;
            background-repeat: no-repeat;
        }
        .style3
        {
            width: 100%;
            height: 87px;
        }
    </style>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <div id="div_block_all" style="display: none;" class="click2">
    </div>
    <div id="div_confirm_all" style="display: none;" class="click2">
    </div>
    <div id="div_verfication_all" style="display: none;" class="click2">
        <div style="height: 25px; background: none repeat scroll 0% 0%  rgb(165, 187, 68);
            font: 18px/25px normal Arial,Helvetica,sans-serif;">
        </div>
    </div>
    <div id="div_unblock_all" style="display: none;" class="click2">
        <div style="height: 25px; background: none repeat scroll 0% 0% rgb(165, 187, 68);
            font: 18px/25px normal Arial,Helvetica,sans-serif;">
        </div>
    </div>
    <div id="div_confirm_unblockall" style="display: none;" class="click2">
    </div>
    <div id="div_verfication_unblock_all" style="display: none;" class="click2">
    </div>
    <div id="div_blockone" style="display: none;" class="click3">
        <table style="width: 100%;">
            <tr style="background-color: #33CCFF;">
                <td colspan="2">
                    Transfer Query
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl_ticket_t_sub" runat="server" Text=""></asp:Label>
                    <br />
                    (<asp:Label ID="lbl_tick_id" runat="server" Text=""></asp:Label>)
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="width: 50%;">
                    Current :
                </td>
                <td style="width: 50%;">
                    <asp:Label ID="lbl_current" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Transfer To Emp.:
                </td>
                <td>
                    <asp:DropDownList ID="cbo_em_list" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/btn_submit.jpg"
                        onMouseDown="this.src='images/btn_submit_click.jpg';" onMouseOver="this.src='images/btn_submit_hover.jpg';"
                        onMouseUp="this.src='~/images/btn_submit.jpg';" onMouseOut="this.src='images/btn_submit.jpg';" />
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_cancel.jpg" />
                </td>
            </tr>
        </table>
    </div>
    <div id="div_confirm_one" style="display: none;" class="click3">
    </div>
    <div id="div_verfication_blockone" style="display: none;" class="click3">
    </div>
    <div id="div_unblockone" style="display: none;" class="click3">
    </div>
    <div id="div_confirm_unblockone" style="display: none;" class="click3">
    </div>
    <div id="div_verfication_unblockone" style="display: none;" class="click3">
    </div>
    <div id="div_result" style="display: none;" class="click1">
    </div>
    <div id="div_result1" style="" class="click">
    </div>

    

    <style>
        .DispNone
        {
            display: none;
        }
    </style>

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

    <div class="hod_runn_main">
        <div class="main_panal_right2">
            <div class="vt_main_pan2">
                <div class="style1" id="pz">
                </div>
                <div class="vt_main_pan_top_mid">
                    <asp:Label ID="lbl_ticket_sub" runat="server" Text=""></asp:Label>
                </div>
                <div class="vt_main_pan_top_bottom">
                </div>
                <div class="vt_main_pan_mid">
                    <div class="welcome_pan2">
                        <table class="style3">
                            <tr>
                                <td style="width: 50%">
                                    Ticket Id :
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                                <td style="width: 50%">
                                    Sent From Branch :
                                    <asp:Label ID="lbl_from" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Author :
                                    <asp:Label ID="lbl_auther" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    To :
                                    <asp:Label ID="lbl_to" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Posted On :
                                    <asp:Label ID="lbl_crtr_date" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    Now :
                                    <asp:Label ID="lbl_now" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Attachment :
                                    <asp:Label ID="lbl_attch" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    Estimated time :
                                    <asp:Label ID="lbl_est_time" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <span id="disp_reciver_de_details" runat="server"></span>
                                    <asp:LinkButton ID="LinkButton1" runat="server">(Change)</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Label ID="lbl_ticket_desc" runat="server" Text=""></asp:Label>
                    <div class="creater_">
                        <div id="disp_crtr" runat="server">
                        </div>
                        <br />
                    </div>
                    <div class="View_ticket_comment">
                        <img src="images/View_ticket_coment_logo.jpg" align="middle" />
                        Comments
                        <img src="images/View_ticket_comment_bar.jpg" style="margin-top: 5px;" />
                    </div>
                    <div class="VT_comments">
                        <div id="dip_comments" runat="server">
                        </div>
                        <asp:Panel ID="pnl_app" runat="server" Visible="false">
                            <div class="app">
                                <b>Approval Note : -</b>
                                <div style="padding-left: 20px;">
                                    <b>Q :</b>
                                    <asp:Label ID="lbl_app_crtr" runat="server" ForeColor="Navy"></asp:Label>
                                    <hr />
                                </div>
                                <div style="padding-left: 20px;">
                                    <b>A :</b>
                                    <asp:Label ID="lbl_app_rcvr" runat="server" ForeColor="#400040"></asp:Label>
                                    <hr />
                                </div>
                                Result:
                                <asp:Label ID="lbl_result" runat="server" Text=""></asp:Label>
                            </div>
                        </asp:Panel>
                        <div id="info_comm" runat="server">
                        </div>
                    </div>
                </div>
                <div class="vt_main_pan_bottom_top">
                </div>
                <div class="vt_main_pan_bottom_mid">
                    <a href="JavaScript:history.back()">Back </a>| <span id="Disp_stts_link" runat="server">
                    </span>| <a href="#" runat="server"   id="Inform_ToID">Inform To</a>
                </div>
                <div class="style2">
                    <%--<asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="dept_name" DataValueField="id">
                    </asp:CheckBoxList>--%>
                   <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>"
                        SelectCommand="SELECT [dept_name], [id] FROM [tbl_dept_master]"></asp:SqlDataSource>
                    <asp:Button ID="Button1" runat="server" Text="Inform To" />--%>
                </div>
            </div>
        </div>
    </div>
    <div id="infTo">
        Inform To <img id="ifClose" src="images/typ_deleted.jpg" />
        <hr />
        <div id="infToDeptList">
            <asp:CheckBoxList ID="ChkList" runat="server">
                
            </asp:CheckBoxList>
        </div>
        <hr />
        <asp:TextBox ID="txt_comment" Text="Comment" TextMode="MultiLine" Width="100%" runat="server"></asp:TextBox>
        <hr />
        <div>
            <asp:Button ID="Button2" runat="server" Text="send" />
            <input id="Button3" type="button" value="Cancel" />
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

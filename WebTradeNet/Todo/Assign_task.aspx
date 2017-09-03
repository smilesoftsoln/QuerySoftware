<%@ Page Language="C#" MasterPageFile="~/todo/task_panel.master" AutoEventWireup="true" CodeFile="Assign_task.aspx.cs" Inherits="Admin_Assign_todo" Title="Untitled Page" ValidateRequest="false" %>
 <%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<script runat="server">

    
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
 <style type="text/css">
     .btnsubmit
        {
	        color:#330033;
	        width: 50px;
	        background-color: #FFFFDF; 	       	
	        font-size:16px;	
	        font-weight:bold;
        }
.btnsubmit:hover
            {
	            color:Red;
	            width: 50px;	            
	            font-size:16px;
	            background-color: #FFFFDF; 
	            font-weight:bold;
            }
 </style>
<script src="../aspnet_client/FTB-FreeTextBox.js" type="text/javascript"></script>
 <script src="Extension.min.js" type="text/javascript"></script>
<ajax:ToolkitScriptManager runat="server" ID="ss"></ajax:ToolkitScriptManager>
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                        Font-Bold="True">Home</asp:LinkButton>
<table width = "100%">    
    <tr>
                <td width = "100%" align = "right">
    <asp:Label ID="lblloginer" runat="server" Font-Bold="True" Font-Size="Small" 
        ForeColor="Blue" Text="User Controls"></asp:Label>
        </td>
    </tr>
</table> 
 

    <table width= "100%">       
        
         <tr style="height:40px">
        
           <td width = "20%" >
            
               &nbsp;</td> 
           
           <td width = "20%" >
                
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Date :-"></asp:Label>
                
           </td> 
           
           <td width = "60%" >
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               <ajax:CalendarExtender   ID="CalDateExtender" TargetControlID="TextBox1" runat="server" 
                    ></ajax:CalendarExtender>
                </td> 
        </tr>
       
      
        
        <tr style="height:40px">
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Time :-"></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:DropDownList ID="ddhourlist" runat="server" Height="22px" Width="43px">
               </asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddminlist" runat="server" Height="22px" Width="42px">
               </asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddampmlist" runat="server" Height="22px" Width="66px">
               </asp:DropDownList>
           
           </td> 
        </tr>   
        
       
        
        
        <tr>
        
           <td width = "20%">
            
               &nbsp;</td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select User :- "></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:DropDownList ID="dduserlist" runat="server" Height="22px" Width="137px" 
                   AutoPostBack="True" 
                   onselectedindexchanged="dduserlist_SelectedIndexChanged">
               </asp:DropDownList>
           
           &nbsp;
                
               <asp:Label ID="lblcaption" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Branch :- "></asp:Label>
                
           &nbsp;
           
               <asp:DropDownList ID="dd_all_list" runat="server" Height="22px" Width="137px" 
                   AutoPostBack="True" 
                   onselectedindexchanged="dd_all_list_SelectedIndexChanged">
               </asp:DropDownList>
           
           </td> 
        </tr>        
       
        
         <tr style="height:40px">
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Employee :-"></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:DropDownList ID="ddemplist" runat="server" Height="22px" Width="250px" 
                   AutoPostBack="True" 
                   onselectedindexchanged="ddemplist_SelectedIndexChanged">
               </asp:DropDownList>
           
           </td>          
        </tr>
        
         <tr style="height:40px">
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Priority :-"></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:RadioButton ID="chknormal" runat="server" Text="Normal" 
                   GroupName="priority" Checked="True" />
&nbsp;&nbsp;
               <asp:RadioButton ID="chkhigh" runat="server" Text="High" GroupName="priority" 
                   />
           
           </td>      
        </tr>
        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%">                
               <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Subject :-"></asp:Label>                
           </td> 
           
           <td width = "60%">           
               <asp:TextBox ID="txtsubject" runat="server" Width="381px"></asp:TextBox>
           </td>          
        </tr>
        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%" valign="top">                
               <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Description :-"></asp:Label>                
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               </td> 
           
                    <td width = "60%">
                       <asp:TextBox ID="FreeTextBox1" runat="server" Height="150px" 
                               TextMode="MultiLine"    
                          Width="402px"></asp:TextBox>
                    </td>           
                     
        </tr>          
        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%">                
               &nbsp;</td> 
           
           <td width = "60%" align="left" id="txt_desc">                    
              <asp:Button ID ="btnsubmit" runat="server" Text="Assign Task" 
                   CssClass = "btnsubmit" Width="147px" 
                   onclick="btnsubmit_Click" style="height: 26px" Height="34px" ></asp:Button>           
             </td>          
        </tr>            
        
    </table>
    
   <%-- <table width="100%">
    <tr>
        <td>
            <asp:Calendar ID="clddate" runat="server" ></asp:Calendar>
        </td>
        
        <td>
            
        </td>        
     
    </tr>
</table>--%>


</asp:Content>



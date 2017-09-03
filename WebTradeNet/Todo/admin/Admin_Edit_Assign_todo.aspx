<%@ Page Language="C#" MasterPageFile="~/todo/admin/admin_todo_panel.master" AutoEventWireup="true" CodeFile="Admin_Edit_Assign_todo.aspx.cs" Inherits="Admin_Edit_Assign_todo" Title="Untitled Page" ValidateRequest="false" %>
<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="AjaxControlToolkit" %>
<script runat="server">

  
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<script src="../aspnet_client/FTB-FreeTextBox.js" type="text/javascript"></script>

 

    <table width= "100%">       
        
         <tr style="height:40px">
        
           <td width = "20%" >
             <AjaxControlToolkit:ToolkitScriptManager runat="server" ID="er"></AjaxControlToolkit:ToolkitScriptManager>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                   ControlToValidate="DateTextBox1" ErrorMessage="Please Select End Date" 
                   Enabled="False"></asp:RequiredFieldValidator>
            
           </td> 
           
           <td width = "20%" >
                
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select End Date :-"></asp:Label>
                
           </td> 
           
           <td width = "60%" >
                   <asp:TextBox ID="DateTextBox1"   autocomplete="off" runat="server"></asp:TextBox>
                <AjaxControlToolkit:CalendarExtender  ID="calw" runat="server" TargetControlID="DateTextBox1" Format="dd-MMM-yyyy"  ></AjaxControlToolkit:CalendarExtender>

             </td> 
        </tr>
       
      
        
        <tr style="height:40px">
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select End Time :-"></asp:Label>
                
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
            
           </td> 
           
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
               <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Type :-"></asp:Label>                
           </td> 
           
           <td width = "60%">           
               <asp:DropDownList ID="ddtodotype" runat="server" Height="22px" Width="137px" 
                   AutoPostBack="True" 
                   onselectedindexchanged="ddtodotype_SelectedIndexChanged">
                   <asp:ListItem Value="1" Text="Daily"></asp:ListItem>
                   <asp:ListItem Value="2">Weekly</asp:ListItem>
                   <asp:ListItem Value="3">Monthly</asp:ListItem>
               </asp:DropDownList>           
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           
               <asp:DropDownList ID="ddselectday" runat="server" Height="22px" Width="137px" 
                   onselectedindexchanged="ddselectday_SelectedIndexChanged" Visible="False" 
                   AutoPostBack="True">
                  
               </asp:DropDownList>           
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
                                    >
                       </asp:TextBox>
                    </td>           
                     
        </tr>          
        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%">                
               &nbsp;</td> 
           
           <td width = "60%" align="left" id="txt_desc">                    
              <asp:Button ID ="btnsubmit" runat="server" Text="Submit" Width="147px" 
                   onclick="btnsubmit_Click" style="height: 26px" ></asp:Button>           
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

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    </asp:Content>



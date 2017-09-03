<%@ Page Language="C#" MasterPageFile="~/todo/admin/admin_todo_panel.master" AutoEventWireup="true" CodeFile="admin_temp.aspx.cs" Inherits="admin_admin_temp" Title="Untitled Page" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<script runat="server">

    
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="../aspnet_client/FTB-FreeTextBox.js" type="text/javascript"></script>

<table width = "100%">
    <tr>
        <td width = "5%">
        
        </td>
        
         <td width = "15%">
         <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=" TODO ID :-"></asp:Label>
        </td>
        
         <td width = "20%">
        <asp:Label ID="lbltodoid" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=" "></asp:Label>
        </td>
        
         <td width = "50%" rowspan="6">
        <asp:TextBox ID="FreeTextBox1" runat="server" Height="150px" 
                                   >
                       </asp:TextBox>
        </td>
    
    </tr>
    
    
    <tr>
        <td width = "5%">
        
        </td>
        
         <td width = "10%">
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="End Date & Time :-"></asp:Label>
        </td>
        
         <td width = "20%">
        <asp:Label ID="lblenddatetime" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=""></asp:Label>
        </td>
        
    </tr>
    
     <tr>
        <td width = "5%">
        
        </td>
        
         <td width = "10%">
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="From :-"></asp:Label>
        </td>
        
         <td width = "20%">
        <asp:Label ID="lblfrom" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=""></asp:Label>
        </td>
        
    </tr>
    
     <tr>
        <td width = "5%">
        
        </td>
        
         <td width = "10%">
        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="To :-"></asp:Label>
        </td>
        
         <td width = "20%">
        <asp:Label ID="lblto" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=""></asp:Label>
        </td>
        
    </tr>
    
     <tr>
        <td width = "5%">
        
        </td>
        
         <td width = "10%">
        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Priority :-"></asp:Label>
        </td>
        
         <td width = "20%">
        <asp:Label ID="lblpriority" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=""></asp:Label>
        </td>
        
    </tr>
    
     <tr>
        <td width = "5%">
        
        </td>
        
         <td width = "10%">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Type :-"></asp:Label>
        </td>
        
         <td width = "20%">
        <asp:Label ID="lbltype" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=""></asp:Label>
        </td>
        
    </tr>
  
     <tr>
        <td width = "5%">
        
        </td>
        
         <td width = "10%">
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Subject :-"></asp:Label>
        </td>
        
         <td width = "20%" colspan="2">
        <asp:Label ID="lblsubject" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" ForeColor="#FF5050"></asp:Label>
        </td>
        
    </tr>
</table>
 

   <%-- <table width= "100%">       
        
         <tr style="height:40px">
        
           <td width = "20%" >
            
               &nbsp;</td> 
           
           <td width = "20%" >
                
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select End Date :-"></asp:Label>
                
           </td> 
           
           <td width = "60%" >
                
               <asp:Label ID="lblcaption0" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Branch :- "></asp:Label>
                
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
           
&nbsp;&nbsp;<asp:Label ID="lblcaption1" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Branch :- "></asp:Label>
                
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
           
           &nbsp;
                
               <asp:Label ID="lblcaption" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Branch :- "></asp:Label>
                
           &nbsp;
           
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
           
               <asp:Label ID="lblcaption2" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Branch :- "></asp:Label>
                
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
           
&nbsp;&nbsp;
                          
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
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           
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
                                    ToolbarBackColor="SkyBlue" ToolbarImagesLocation="ExternalFile" 
                                    ToolbarStyleConfiguration="Office2003" AllowHtmlMode="False" 
                            Focus="False">
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
                   style="height: 26px" ></asp:Button>           
             </td>          
        </tr>            
        
    </table>--%>
    
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
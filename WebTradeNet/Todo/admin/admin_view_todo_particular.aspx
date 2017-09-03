<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_view_todo_particular.aspx.cs" Inherits="admin_admin_view_todo_particular" Title="Untitled Page" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../aspnet_client/FTB-FreeTextBox.js" type="text/javascript"></script>

 

    <table width= "100%">       
        
         <tr style="height:40px">
        
           <td width = "20%" >
            
               &nbsp;</td> 
           
           <td width = "20%" >
                
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="ID"></asp:Label>
                
           </td> 
           
           <td width = "60%" >
               <asp:Label ID="lbl_id" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Type"></asp:Label>                
             </td> 
        </tr>
       
      
        
        <tr style="height:40px">
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="End Date &amp; Time :-"></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:Label ID="lbl_enddatetime" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Type"></asp:Label>                
           
           </td> 
        </tr>   
        
       
        
        
        <tr>
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="User :- "></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:DropDownList ID="dduserlist" runat="server" Height="22px" Width="137px" 
                   AutoPostBack="True" 
                   >
               </asp:DropDownList>
           
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
                   Font-Size="Small" Text="Employee :-"></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Type"></asp:Label>                
           
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
           
               &nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Type "></asp:Label>                
           
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
               <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Type"></asp:Label>                
               &nbsp;</td>          
        </tr>

        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%">                
               <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Subject :-"></asp:Label>                
           </td> 
           
           <td width = "60%">           
               <asp:TextBox ID="txtsubject" runat="server" Width="330px" ReadOnly="True"></asp:TextBox>
           </td>          
        </tr>
        
        <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%">                
               <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Subject :-"></asp:Label>                
           </td> 
           
           <td width = "60%">  
            <asp:TextBox ID="FreeTextBox1" runat="server" Height="150px" 
                                  >
                       </asp:TextBox>         
               &nbsp;</td>          
        </tr>
        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%" >                
               &nbsp;</td> 
           
           <td width = "60%" align="left" >                    
              <asp:Button ID ="btnsubmit" runat="server" Text="Edit" Width="147px" 
                    style="height: 26px" ></asp:Button>           
             </td>          
        </tr>            
        
    </table>
</asp:Content>


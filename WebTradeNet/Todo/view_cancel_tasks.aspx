<%@ Page Language="C#" MasterPageFile="~/todo/view_todo_panel.master" validateRequest = "false" AutoEventWireup="true" CodeFile="view_cancel_tasks.aspx.cs" Inherits="view_todo" Title="Untitled Page" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="~/todo/aspnet_client/FTB-FreeTextBox.js" type="text/javascript"></script>
    
 
<table width = "100%">
    <tr>
<td width="100%" align ="right">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">Back</asp:LinkButton>
</td>
</tr>
</table>
<table width = "100%">

    <tr rowspan="3">
        <td width = "5%">
        
        </td>
        
         <td width = "15%">
         <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=" TASK ID :-"></asp:Label>
        </td>
        
         <td width = "20%">
        <asp:Label ID="lbltaskid" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text=" "></asp:Label>
        </td>
        
         <td width = "50%" rowspan="6" >
         <asp:TextBox ID="FreeTextBox1" runat="server" Height="150px" 
                     ReadOnly="True">
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
<hr width = "100%" style="background-color: #0000FF" />
<table  width="100%">    
      <tr>
        <td width="20%">
        
            &nbsp;</td>
        <td width="60%" align="center" >
        
        
            <asp:Button ID="btncancel" runat="server" Font-Names="Arial Rounded MT Bold" 
                onclick="btncancel_Click" Text="Cancel" Width="103px" />
          </td>
        <td width="20%">
        
        </td>
        
    </tr>
</table>
</asp:Content>


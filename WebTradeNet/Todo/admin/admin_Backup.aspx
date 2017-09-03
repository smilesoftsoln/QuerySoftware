<%@ Page Language="C#" MasterPageFile="~/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_Backup.aspx.cs" Inherits="admin_admin_Backup" Title="Untitled Page" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "Take a Backup" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>                
                <td style="width: 200px"> </td>               
                <td style="width: 200px"> </td>                                  
            </tr>
            
             <tr>                
                <td class="style1">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Backup" 
                        Width="116px" Height="32px" />
                 </td>
                <td class="style1"></td>
            </tr>            
            <tr>                
                <td style="width: 200px"> 
                    &nbsp;</td>               
                <td style="width: 200px"> </td>          
            </tr>            
        </table>



</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
     
    <style type="text/css">
        .style1
        {
            width: 200px;
            height: 62px;
        }
    </style>

</asp:Content>



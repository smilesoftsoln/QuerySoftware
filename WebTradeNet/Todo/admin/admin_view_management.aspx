<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_view_management.aspx.cs" Inherits="admin_admin_view_management" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="adminstyle.css" rel="stylesheet" type="text/css" />
    <table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "View Management" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>                
                <td style="width: 200px">                
                <td style="width: 200px">                                   
            </tr>
            
             <tr>                
                <td style="width: 200px">
                    &nbsp;<td style="width: 200px">
            </tr>            
            <tr>                
                <td style="width: 200px">                
                <td style="width: 200px">                
            </tr>            
        </table>
        
        <div id ="viewmanagement" runat ="server" align="center">     
           
        </div>
</asp:Content>


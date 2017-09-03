<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_view_department.aspx.cs" Inherits="admin_admin_view_department" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="adminstyle.css" rel="stylesheet" type="text/css" />
 <table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "View Department" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>                
                <td style="width: 200px">                
                <td style="width: 200px"> 
                <a href="admin_create_department.aspx">Add New Dartment</a> 
            </tr>
            
             <tr>                
                <td style="width: 200px">
            
                    &nbsp;<td style="width: 200px">
                 <a href="admin_edit_dept.aspx">Edit Dartment</a>     
            </tr>            
            <tr>                
                <td style="width: 200px">                
                <td style="width: 200px">                
            </tr>            
        </table>
        
        <div id ="viewdepartment" runat ="server" align="center">     
           
        </div>
</asp:Content>


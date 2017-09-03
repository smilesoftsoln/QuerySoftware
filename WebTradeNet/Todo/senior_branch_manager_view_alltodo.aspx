<%@ Page Language="C#" MasterPageFile="~/todo/senior_branch_manager.master" AutoEventWireup="true" CodeFile="senior_branch_manager_view_alltodo.aspx.cs" Inherits="senior_branch_manager_view_alltodo" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "View todo" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>                
               <%-- <td style="width: 200px">                
                <td style="width: 200px"> 
                <a href="">Add New Dartment</a> 
                </td>
                </td>--%>
            </tr>
            
            <%-- <tr>                
                <td style="width: 200px">
            
                    &nbsp;<td style="width: 200px">
                 <a href="">Edit Dartment</a> 
                 </td>   
                 </td> 
            </tr>            
            <tr>                
                <td style="width: 200px">  </td>              
                <td style="width: 200px">   </td>             
            </tr>            --%>
        </table>
        
        <div id ="view_srbmng_todo" runat ="server" align="center">     
           
        </div>
</asp:Content>


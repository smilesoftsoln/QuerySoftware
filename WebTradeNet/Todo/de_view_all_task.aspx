<%@ Page Language="C#" MasterPageFile="~/todo/dept.master" AutoEventWireup="true" CodeFile="de_view_all_task.aspx.cs" Inherits="de_view_all_todo" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "View Task" ID="Label1" Font-Bold="True" 
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
        
        <div id ="view_de_task" runat ="server" align="center">     
           
        </div>
</asp:Content>


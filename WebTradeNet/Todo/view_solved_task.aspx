<%@ Page Language="C#" MasterPageFile="~/todo/task_panel.master" AutoEventWireup="true" CodeFile="view_solved_task.aspx.cs" Inherits="view_assigned_task" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style type="text/css">

.table_1	
{
}	
    .table_1 th
    {
	    color:#0000FF	   
    }
    .table_1 td
    {
	    font-family:Arial;
	    font-size:12px;
	    font-weight:bold;
    }


</style>

<style type="text/css">

a
{
	font-family:Arial, Helvetica, sans-serif;
	font-size:12px;
	color:Maroon;
	font-weight:bold;
	text-decoration:none; 	
}
a:hover
{
	text-decoration:underline;
	color:WindowFrame;
}

</style>

<table width="100%">
<tr>
    <td width="100%" align="left">
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            Font-Bold="True">HOME</asp:LinkButton>
    </td>    
</tr>
</table> 

<table id="Table1" width="100%" runat="server" class="table_1" >
        <tr>
            <td width="100%">
                <div id = "div_show" runat = "server" ></div>                
            </td>
        </tr>
    </table>

  
</asp:Content>


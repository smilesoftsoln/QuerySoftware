<%@ Page Language="C#" MasterPageFile="~/todo/task_panel.master" AutoEventWireup="true" CodeFile="view_assigned_task.aspx.cs" Inherits="view_assigned_task" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">

a
{
	font-family:Arial, Helvetica, sans-serif;
	font-size:12px;
	color:Red;
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
            ForeColor="#990000">HOME</asp:LinkButton>
    </td>    
</tr>
</table>

    <table width="100%">
        <tr>
            <td width="10%">
            </td>
            
            <td width="30%" align="right">
                <asp:Label ID="Label2" runat="server" Text="Select Type"></asp:Label>
            </td>
            
            <td width="20%" align="center">
                <asp:DropDownList ID="ddtype" runat="server" 
                     style="height: 22px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Solved</asp:ListItem>
                    <asp:ListItem>Unsolved</asp:ListItem>
                    <asp:ListItem>Overdue</asp:ListItem>
                    <asp:ListItem>Canceled</asp:ListItem>
                </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
            
            <td width="30%" >
                    <asp:Button ID="btnview" runat="server" onclick="btnview_Click" Text="View" 
                    Width="123px" />
            </td>
               
            </td>
            
            <td width="10%">
                &nbsp;</td>
        </tr>
            <tr>
                <td >
                
                </td>
            </tr>
                  <tr>
                        <td >
                        
                        </td>
                </tr> 
             <tr>
                <td >
                
                </td>
            </tr> 
                    
    </table>


 <div id = "view_self_assigned_task" runat ="server" >
    
    </div>

    
</asp:Content>


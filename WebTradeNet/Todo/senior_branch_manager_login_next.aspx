﻿<%@ Page Language="C#" MasterPageFile="~/todo/senior_branch_manager.master" AutoEventWireup="true" CodeFile="senior_branch_manager_login_next.aspx.cs" Inherits="senior_branch_manager_login_next" Title="Untitled Page" %>

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
	font-size:11px;
	font-weight:bold;
}

</style>

     <table width = "100%">
        <tr>
            <td width="100%">
                <%-- <table width = "100%">
                    <tr>
                        <td align = "right">
                         <asp:Label ID = "Label1" runat = "server" Text = "Welcome:- " 
                              Font-Bold="True" Font-Size="Large" ForeColor="Gray" ></asp:Label>
                             <asp:Label ID = "lblloginer" runat = "server" Text = "User Controls" 
                              Font-Bold="True" Font-Size="Large" ForeColor="Blue" ></asp:Label>
                        </td>
                    </tr>
                    
                   
                </table>--%>
                   <table width = "100%">
                    <tr>
                        <td width = "60%">
                         <asp:Label ID = "lblmanageid" runat = "server" Text = "User Controls" 
                              Font-Bold="True" Font-Size="Small" ForeColor="Blue" ></asp:Label>
                        
                        </td>                    
                        
                        <td width = "20%" align = "right">
                            <asp:Label ID = "Label1" runat = "server" Text = "Welcome:- " 
                              Font-Bold="True" Font-Size="Small" ForeColor="Gray" ></asp:Label>
                        
                        </td>
                        <td align = "left" width = "20%">                          
                         
                             <asp:Label ID = "lblloginer" runat = "server" Text = "User Controls" 
                              Font-Bold="True" Font-Size="Small" ForeColor="Blue" ></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td width = "60%" align="center" rowspan="2">
                        
                        
                <asp:Label ID = "lblusercontrols" runat = "server" Text = "User Controls" 
                 Font-Bold="True" Font-Size="Large" ForeColor="Red" ></asp:Label>
                        
                        
                        </td>                    
                        
                        <td width = "20%" align = "right">
                            <asp:Label ID = "Label3" runat = "server" Text = "User Type :- " 
                              Font-Bold="True" Font-Size="Small" ForeColor="Gray" ></asp:Label>
                        
                        </td>
                        <td align = "left" width = "20%">                          
                         
                            <asp:Label ID = "lblusertype" runat = "server" Text = "User Controls" 
                              Font-Bold="True" Font-Size="Small" ForeColor="Blue" ></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        
                        <td width = "20%" align = "right">
                            &nbsp;</td>
                        <td align = "left" width = "20%">                          
                         
                            &nbsp;</td>
                    </tr>                                       
                </table>
                  </td>
            </tr>
</table>           
                        
                        <table width="100%" bgcolor="#999966">
                          <tr>
                                <td width="20%">
                                    <ul>
                                       <li><a href="senior_branch_manager_view_alltodo.aspx">View All ToDo</a></li>
						                <li><a href="senior_branch_manager_view_all_Task.aspx">View All Task's</a></li>               
						                <li><a href="view_assigned_task.aspx">View Assigned Task</a></li>						                
                                    </ul>
                                </td>
                                 <td width="20%">
                                    <ul>
                                         <li><a href="Assign_task.aspx?parameter=1">Assign Task Self</a></li>
						                 <li><a href="Assign_task.aspx">Assign Task</a></li> 
             
                                    </ul>
                                </td>
                                <td width="20%">
                                    <ul>
                                         <li><a href="view_solved_task.aspx">View Solved Task</a></li>
                                         <li><a href="view_overdue_task.aspx">View Overdue Task</a>&nbsp;
                                <asp:Label ID="lbl_overdue" runat="server" Font-Bold="True" ForeColor="#003300" 
                                    Text="L" Visible="False"></asp:Label>
                                &nbsp;<asp:Image ID="img_overd_alert" runat="server" ImageUrl="~/images/LIGHT.gif" 
                                    Visible="False" />
                                            </li> 
						                  <li><a href="View_login_information.aspx">View Login Information</a></li>            
                                    </ul>
                                </td>
                           </tr>    
                        </table> 
                        
                        
                        <table width="100%" class="table_1">
                 <tr >
                     <td width="50%" align="center">
                         <asp:Label ID="Label4" runat="server" Text="Today's TODO" Font-Size="Medium" 
                             ForeColor="#CC0000" Font-Bold="True"></asp:Label>
                     
                         <div id ="div_todays_todo" runat="server">
                         
                         </div>
                     </td>
                     
                     <td width="50%" align="center">
                     
                      <asp:Label ID="Label5" runat="server" Text="Today's Task's" Font-Size="Medium" 
                             ForeColor="#CC0000" Font-Bold="True"></asp:Label>
                             
                            <div id ="div_todays_task" runat="server">
                            
                            
                         
                            </div>
                     </td>
                 </tr>
                   </table>
                 <table width="100%" class="table_1">
                 <tr >
                     <td width="100%" align="center">
                     
                     <asp:Label ID="Label6" runat="server" Text="Assigned Task" Font-Size="Medium" 
                             ForeColor="#CC0000" Font-Bold="True"></asp:Label>
                             
                          <div id ="div_assigned_task" runat="server">
                         
                         </div>
                     </td>                   
                 </tr>
               </table>   
   
</asp:Content>


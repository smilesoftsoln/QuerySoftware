<%@ Page Language="C#" MasterPageFile="~/todo/branchhead.master" AutoEventWireup="true" CodeFile="branchhead_login_next.aspx.cs" Inherits="branchhead_login_next" Title="Untitled Page" %>

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
                <%--<table width = "100%">
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
                            <asp:Label ID = "Label2" runat = "server" Text = "Branch Name :- " 
                              Font-Bold="True" Font-Size="Small" ForeColor="Gray" ></asp:Label>
                        
                        </td>
                        <td align = "left" width = "20%">                          
                         
                            <asp:Label ID = "lblbranchname" runat = "server" Text = "User Controls" 
                              Font-Bold="True" Font-Size="Small" ForeColor="Blue" ></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        
                        <td width = "20%" align = "right">
                            <asp:Label ID = "Label3" runat = "server" Text = "User Type :- " 
                              Font-Bold="True" Font-Size="Small" ForeColor="Gray" ></asp:Label>
                        
                        </td>
                        <td align = "left" width = "20%">                          
                         
                            <asp:Label ID = "lblusertype" runat = "server" Text = "User Controls" 
                              Font-Bold="True" Font-Size="Small" ForeColor="Blue" ></asp:Label>
                        </td>
                    </tr>
                                       
                </table>
                
                </td>
            </tr>
</table>

<table width="100%" bgcolor="#999966">
                 <tr>
                  <td width="20%">
                        <ul>
                        <li><asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click" >Assign Todo</asp:LinkButton></li>
                        <li>  <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Assign Todo Self</asp:LinkButton>
						</li><li><asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">View Todo Assigned to Me</asp:LinkButton></li> 
					<li>	 <asp:LinkButton ID="LinkButton3" runat="server" 
                            onclick="LinkButton3_Click"  >View Todo Assigned by Me</asp:LinkButton></li> 
						
                        
                          
                       
                        </ul>
                    </td>
                    <td width="20%">

                    <ul>                  
						<%--<li><a href="branchhead_viewall_todo.aspx">View All ToDo</a></li>--%>
						<li><a href="branchhead_view_all_task.aspx">View All Task Assigned To Me</a></li>
						<li><a href="view_assigned_task.aspx">View All Assigned Tasks By Me</a></li>
                       
                         </ul>
                    </td>
                    <td width="20%">
                    <ul>
                        <li><a href="Assign_task.aspx">Assign Task</a></li>
						<li><a href="Assign_task.aspx?parameter=1">Assign Task Self</a></li>
						 
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
                      <%--  <li><a href="View_login_information.aspx">View Login Information</a></li>--%>
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
                     
                     <asp:Label ID="Label6" runat="server" Text="Unsolved Tasks Assigned By Me" Font-Size="Medium" 
                             ForeColor="#CC0000" Font-Bold="True"></asp:Label>
                             
                          <div id ="div_assigned_task" runat="server">
                         
                         </div>
                     </td>                   
                 </tr>
               </table>
                                  
 
</asp:Content>


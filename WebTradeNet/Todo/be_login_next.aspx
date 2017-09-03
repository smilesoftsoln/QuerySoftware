<%@ Page Language="C#" MasterPageFile="~/todo/branch.master" AutoEventWireup="true" CodeFile="be_login_next.aspx.cs" Inherits="be_login_next" Title="Untitled Page" %>

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
                        <td width = "60%" rowspan="2" align = "center">
                        
                        
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
                        <li>  <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Assign Todo Self</asp:LinkButton>
						</li><li><asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">View Todo Assigned to Me</asp:LinkButton></li> 
					<li>	 <asp:LinkButton ID="LinkButton3" runat="server" 
                            onclick="LinkButton3_Click"  >View Todo Assigned by Me</asp:LinkButton></li> 
						
                        
                          
                       
                        </ul>
                    </td>
                    <td width="20%">
                        <ul>
                           <%-- <li><a href="be_view_alltodo.aspx">View All ToDo</a></li>--%>
                            <li><a href="be_view_all_task.aspx"> View All Tasks Assigned To Me</a></li>					
						    
                               
                        </ul>
                    </td>
                    <td width="20%">
                        <ul>
                        <li><a href="Assign_task.aspx?parameter=1">Assign Task Self</a></li>
                        <li><a href="view_overdue_task.aspx">View Overdue Task</a>
                                <asp:Label ID="lbl_overdue" runat="server" Font-Bold="True" ForeColor="#003300" 
                                    Text="L" Visible="False"></asp:Label>
                                &nbsp;<asp:Image ID="img_overd_alert" runat="server" ImageUrl="~/images/LIGHT.gif" 
                                    Visible="False" />
                                            </li>                        
						<li><a href="view_solved_task.aspx">View Solved Task's</a></li> 
						</ul>
                    </td>                   
                 </tr>    
                 </table> 
                 
                 <table width="100%" class="table_1">
                 <tr >
                     <td width="50%" align="center">
                         <asp:Label ID="Label4" runat="server" Text="Today's TODO" Font-Size="Medium" 
                             ForeColor="#CC0000"></asp:Label>
                     
                         <div id ="div_todays_todo" runat="server">
                         
                         </div>
                     </td>
                     
                     <td width="50%" align="center">
                     
                      <asp:Label ID="Label5" runat="server" Text="Today's Task's" Font-Size="Medium" 
                             ForeColor="#CC0000"></asp:Label>
                             
                            <div id ="div_todays_task" runat="server">
                            
                            
                         
                            </div>
                     </td>
                 </tr>
                   </table>
                 <table width="100%" class="table_1">
                 <tr >
                     <td width="100%" align="center">
                     
                     <asp:Label ID="Label6" runat="server" Text="Unsolved Task Assigned By Me " Font-Size="Medium" 
                             ForeColor="#CC0000"></asp:Label>
                             
                          <div id ="div_assigned_task" runat="server">
                         
                         </div>
                     </td>                   
                 </tr>
               </table>
                                                  
</asp:Content>


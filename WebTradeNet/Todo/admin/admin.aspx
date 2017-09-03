<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/todo/admin/master_admin.master" CodeFile="admin.aspx.cs" Inherits="admin_admin" %>


<asp:Content ID="mainpanel" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="adminstyle.css" rel="stylesheet" type="text/css" />
    
    <table width = "100%">
        <tr>
            <td width = "15%">
            
            </td>
            <td width = "85%">
            
            <table width = "100%">
        <tr>
            <td width = "50%">
                          <asp:Label ID = "lblusercontrols" runat = "server" Text = "User Controls" 
                            Font-Bold="True" Font-Size="Large" ForeColor="Red" ></asp:Label>
                        <ul>
							<li><a href="admin_create_user.aspx">Add New User</a></li>
							<li><a href="admin_view_all_user.aspx">View All Users</a></li>
						<%--	<li><a href="">Search User</a></li>
                           <!-- <li><a href="Online_users.aspx">View Online Users</a></li> -->
							<li><a href="../View_login_information.aspx">View Login Information</a></li>--%>
					        
					</ul>
            </td>
            
             <%--<td width = "50%">
                         <asp:Label ID = "Label1" 
                            runat = "server" Text = "Department Controls" 
                            Font-Bold="True" Font-Size="Large" ForeColor="Red" ></asp:Label>
                     <ul>
							
							<li><a href="admin_create_department.aspx">Add New Departments</a></li>
							<li><a href="admin_edit_dept.aspx">Edit Department info.</a></li>
							<li><a href="admin_view_department.aspx">View All Departments</a></li>
							<li><a href="admin_assign_srmng_to_dept.aspx">Assign Department to Sr Manager</a></li>
							<li><a href="Admin_asign_exist_hod.aspx">Assign Exist HOD To Department</a></li>
							<li><a href="Admin_transfer_dept.aspx">Transfer Department</a></li>                           
                            
						
					</ul>
            
            </td>--%>
        </tr>
        
        
        <tr>
            <%--<td width = "50%">
                          <asp:Label ID = "Label2" runat = "server" Text = "Branch Controls" 
                            Font-Bold="True" Font-Size="Large" ForeColor="Red" ></asp:Label>
                        <ul>
							<li><a href="admin_create_branch.aspx">Add New Branch</a></li>
							<li><a href="admin_edit_branch.aspx">Edit Branch Details</a></li>
                            <li><a href="admin_view_all_branches.aspx">View All Branches</a></li>
                            <li><a href="admin_assign_srbmng_to_branch.aspx">Assign Branch To Sr Branch Manager</a></li>
                            <li><a href="Admin_asign_exist_bh.aspx">Assign Exist BH To Branch</a></li>
                            <li><a href="Admin_transfer_branch.aspx">Transfer Branch</a></li>					    
					    </ul>
            </td>--%>
            
             <%--<td width = "50%">
                        
                        <asp:Label ID = "Label3" 
                            runat = "server" Text = "Management Controls" 
                            Font-Bold="True" Font-Size="Large" ForeColor="Red" ></asp:Label>
                     <ul>
							
							<li><a href="admin_new_management.aspx">Add New Management</a></li>
							<li><a href="admin_edit_management.aspx">Edit Management Info.</a></li>
                            <li><a href="admin_view_management.aspx">View All Managements.</a></li>
						
					</ul>
            
            </td>--%>
        </tr>       
        
        <tr width = "50%">
            <td>
                          <asp:Label ID = "Label4" runat = "server" Text = "TODO Controls" 
                            Font-Bold="True" Font-Size="Large" ForeColor="Red" ></asp:Label>
                        <ul>
							<li><a href="Admin_Assign_todo.aspx">Assign TODO</a></li>
							<li><a href="view_all_todo.aspx">View All TODO's</a></li>
                            
					    </ul>
            </td>
            
             <%--<td width = "50%">
                        
                        <asp:Label ID = "Label5" 
                            runat = "server" Text = "Other Controls" 
                            Font-Bold="True" Font-Size="Large" ForeColor="Red" ></asp:Label>
                     <ul>
							
							<li><a href="admin_view_dept_and_hod.aspx">View Department and HOD</a></li>
                            <li><a href="admin_view_branch_and_branch_heads.aspx">View Branch and Branch Heads</a></li>
                            <li><a href="admin_Backup.aspx">Take Backup</a></li>
						</ul>
					
            
            </td>--%>
        </tr>         
        
    </table>
            
            
            </td>
            
        </tr>
    </table>
    
    

</asp:Content>  
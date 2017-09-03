<%@ Page Language="VB" Debug="true" AutoEventWireup="false" CodeFile="login_Next.aspx.vb" Inherits="login_Next" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" validateRequest=false >

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<link href="layOut.css" type="text/css" rel="stylesheet"  />
    <style type="text/css">
        .style2
        {
            width: 102%;
            height: 57px;
        }
        </style>
</head>
<body>
	<form id="form1" runat="server">
	<div class="page">
		<div class="top">
			<div class="top_left">
					<div class="top_img">
						<a href="#">
							<img src="images/top.jpg"  />
						</a>
					</div>
			</div>
			<div class="top_right">
				<div class="top_right_user_info">
				
				    <span lang="en-us">Welcome </span>
                    <asp:Label ID="lbl_name" runat="server" Text="Label"></asp:Label>
                    <span lang="en-us">&nbsp;</span><asp:Label ID="lbl_id" runat="server" Text="1"></asp:Label>
				
				</div>
			</div>	
		</div>
		<div class="nav">
			<div class="nav_left">
				&nbsp;<asp:Label ID="lbl_date" runat="server" Text="Label"></asp:Label>
			</div>
			<div class="nav_rigth">
				<asp:LinkButton ID="lnkbtn_Home" runat="server" 
                    PostBackUrl="~/Todo/login_Next.aspx">Home</asp:LinkButton>
&nbsp;<a href="#">About Us</a>
				<a href="#">My Account</a>
				<a href="#">Settings</a><asp:LinkButton ID="LinkButton1" runat="server" 
                    PostBackUrl="~/Default.aspx">Log out</asp:LinkButton>
&nbsp;</div>
		</div>
		
		<div class="task_pan">
			<div class="task_pan_left">
				<div class="task_pan_left_top">
					Tasks
				<%--</divTasks--%>
				</div>
				<div class="task_pan_left_mid" hidefocus="hidefocus" unselectable="on">
                    
                    
                    <table class="style2">
                        <tr>
                            <td>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                               
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="4" 
                                    DataSourceID="SqlDataSource2" Font-Size="Smaller" ForeColor="#333333" 
                                    PageSize="5" 
                                    DataMember="DefaultView" Height="150px" HorizontalAlign="Left" 
                                    Width="475px" AllowSorting="True" DataKeyNames="id">
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" >
                                            <ItemStyle Width="20px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="subject" HeaderText="subject" 
                                            SortExpression="subject" >
                                            <ItemStyle Width="60px" Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EndingOn" HeaderText="EndingOn" 
                                            SortExpression="EndingOn" >
                                            <ItemStyle Width="180px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" 
                                            SortExpression="AssignedTo" >
                                            <ItemStyle Width="160px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Status" HeaderText="Status" 
                                            SortExpression="Status" >
                                            <ItemStyle Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Priority" HeaderText="Priority" 
                                            SortExpression="Priority" >
                                            <ItemStyle Width="20px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" 
                                        BorderStyle="Dotted" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                
                                <br />
                                <br />
                                
                                <br />
                                <br />
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" CellPadding="4" 
                                    DataSourceID="SqlDataSource1" Font-Size="Smaller" ForeColor="#333333" 
                                    Height="20px" HorizontalAlign="Left" PageSize="5" Width="475px" 
                                    AutoGenerateColumns="False" AllowSorting="True" 
                                    AutoGenerateSelectButton="True" DataKeyNames="id">
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <EmptyDataRowStyle Font-Size="Smaller" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                                        <asp:BoundField DataField="Subject" HeaderText="Subject" 
                                            SortExpression="Subject" >
                                            <ItemStyle Font-Size="Small" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EndingOn" HeaderText="EndingOn" 
                                            SortExpression="EndingOn" >
                                            <ItemStyle Font-Size="Small" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Creator" HeaderText="Creator" 
                                            SortExpression="Creator" >
                                            <ItemStyle Font-Size="Small" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Status" HeaderText="Status" 
                                            SortExpression="Status" />
                                        <asp:BoundField DataField="Priority" HeaderText="Priority" 
                                            SortExpression="Priority" />
                                    </Columns>
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" 
                                        BorderStyle="Dotted" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle Font-Size="Smaller" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
                                    SelectCommand="SELECT t.id, t.subject AS Subject, t.enddatetime AS EndingOn, l.name_ AS Creator, s.[desc] AS Status, p.[desc] AS Priority FROM tbl_tasks AS t INNER JOIN tbl_status AS s ON t.statusid = s.id INNER JOIN tbl_priority AS p ON t.priorityid = p.id INNER JOIN tbl_loginer_master AS l ON t.creator = l.id WHERE (t.assignedto = @assignedto) AND (t.statusid &lt;&gt; 4)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lbl_id" DefaultValue="" Name="assignedto" 
                                            PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
                                    SelectCommand="SELECT t.id, t.enddatetime AS EndingOn, l.name_ AS AssignedTo, s.[desc] AS Status, p.[desc] AS Priority, t.subject FROM tbl_tasks AS t INNER JOIN tbl_status AS s ON t.statusid = s.id INNER JOIN tbl_priority AS p ON t.priorityid = p.id INNER JOIN tbl_loginer_master AS l ON t.assignedto = l.id WHERE (t.creator = 1)"></asp:SqlDataSource>
                                <br />
                                <br />
                                <br />
                            </td>
                            
                        </tr>
                    </table>
                    
                    
                </div> <br />
                                <br />
                                <br />
                                <br />
                                 
                                
				<div class="options_pan">
					<asp:LinkButton ID="lnkbtn_assigntask" runat="server" 
                        PostBackUrl="~/Todo/Assign_task.aspx" Width="106px">Assign Task</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        PostBackUrl="~/Todo/Assigned task.aspx">Task assigned by me</asp:LinkButton>
				    <%--</span>--%>
				    <asp:LinkButton ID="LinkButton5" runat="server" 
                        PostBackUrl="~/Todo/Allticks.aspx" Visible="False">View 
                    all Tasks</asp:LinkButton>
				</div>
			</div>
			
			<div class="task_pan_right">
				<div class="task_pan_right_top"></div>
				<div class="task_pan_right_mid">
				<asp:GridView ID="GridView3" runat="server" AllowPaging="True" CellPadding="4" 
                                    DataSourceID="SqlDataSource3" Font-Size="Smaller" ForeColor="#333333" 
                                    Height="100px" HorizontalAlign="Left" PageSize="5" 
                        Width="475px" AutoGenerateColumns="False" AllowSorting="True" 
                        DataKeyNames="id">
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <EmptyDataRowStyle Font-Size="Smaller" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                                            SortExpression="id" />
                                        <asp:BoundField DataField="Subject" HeaderText="Subject" 
                                            SortExpression="Subject" />
                                        <asp:BoundField DataField="EndingOn" HeaderText="EndingOn" 
                                            SortExpression="EndingOn" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" 
                                            SortExpression="Status" />
                                        <asp:BoundField DataField="Priority" HeaderText="Priority" 
                                            SortExpression="Priority" />
                                    </Columns>
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" 
                                        BorderStyle="Dotted" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle Font-Size="Smaller" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
				
				
				
				    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" SelectCommand="SELECT td.id, t.subject AS Subject, td.enddatetime AS EndingOn, 
	   s.[desc] AS Status, p.[desc] AS Priority
FROM   tbl_todo_master t,tbl_todo_details td,tbl_status s,tbl_priority p
WHERE  td.master_id = t.id 
	   and s.id = td.statusid
	   and p.id = td.priorityid
   and td.statusid &lt;&gt; 4
	   and DATEDIFF(day, GETDATE(), td.enddatetime) &lt;= 1">
                    </asp:SqlDataSource>
				
				
				
				</div>
				
				  <br />
                                
                                
                                <br />
                                <br />
                                <br />
				
				<div class="options_pan">
					<asp:LinkButton ID="LinkButton3" runat="server" 
                        PostBackUrl="~/Assign_task.aspx" Width="113px">Assign Task to self</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton4" runat="server" 
                        PostBackUrl="~/View_full_todo.aspx" Enabled="False" Width="109px">View full ToDo</asp:LinkButton>
				    <%--</span>--%>
				    <asp:LinkButton ID="lnkbtn_reports" runat="server">Reports</asp:LinkButton>
				</div>
			</div>
		</div>
	</div>
    </form>
</body>
</html>

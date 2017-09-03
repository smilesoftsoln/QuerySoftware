<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Todo/TD.master" CodeFile="All_task_admin.aspx.vb" Inherits="Todo_Alltask" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

                <p>
                    <br />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" DataKeyNames="ID">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="id" SortExpression="id" />
                <asp:BoundField DataField="createdatetime" HeaderText="createdatetime" 
                    SortExpression="createdatetime" />
                <asp:BoundField DataField="enddatetime" HeaderText="enddatetime" 
                    SortExpression="enddatetime" />
                <asp:BoundField DataField="subject" HeaderText="subject" 
                    SortExpression="subject" />
                <asp:BoundField DataField="creator" HeaderText="creator" 
                    SortExpression="creator" />
                <asp:BoundField DataField="assignedto" HeaderText="assignedto" 
                    SortExpression="assignedto" />
                <asp:BoundField DataField="statusid" HeaderText="statusid" 
                    SortExpression="statusid" />
                <asp:BoundField DataField="branchid" HeaderText="branchid" 
                    SortExpression="branchid" />
                <asp:BoundField DataField="remark" HeaderText="remark" 
                    SortExpression="remark" />
            </Columns>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
            SelectCommand="select t.id as ID,t.createdatetime as [Create Date],t.enddatetime as [End Date],t.subject as Subject, lm.name_ as [Emp. Name], s.&quot;desc&quot; as Status, p.&quot;desc&quot; as Priority, d.dept_name as [Dept. Name], l.short_key as [Post] 
from   
tbl_tasks as t,
tbl_dept_master as d,
tbl_levels as l,
tbl_priority as p, 
tbl_status as s, 
tbl_loginer_master as lm
where 
lm.id = t.assignedto and 
s.id=t.statusid and 
p.id = t.priorityid and 
d.id = t.deptid and 
l.id = t.levelid and
t.creator= t.creator 
order by t.id
">
        </asp:SqlDataSource>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>

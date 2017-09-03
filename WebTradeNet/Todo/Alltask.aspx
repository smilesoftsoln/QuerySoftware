<%@ Page Language="VB" AutoEventWireup="false" Debug = "true"  MasterPageFile ="~/Todo/TD.master" CodeFile="Alltask.aspx.vb" Inherits="Allticks" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<asp:Content ID = "content1" runat = server ContentPlaceHolderID =ContentPlaceHolder1>
    <div class="admin_updater_long_top">
		<img src="images/Admin_Login_Next_updater_long_ico.jpg"  align="middle"/> All 
        Tasks<br />
&nbsp;<table style="width: 100%">
            <tr>
                <td align="center">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                        DataSourceID="sql_datasource_tasks_all" Font-Size="Small" ForeColor="#333333" 
                        Height="242px" Width="950px" GridLines="Vertical">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="select" >
                                <ItemStyle Width="10px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
                                <ItemStyle Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Subject" HeaderText="Subject" 
                                SortExpression="Subject">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TO" HeaderText="TO" 
                                SortExpression="Emp. Name">
                                <ItemStyle Width="150px" Font-Size="X-Small" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FROM" HeaderText="FROM" SortExpression="FROM">
                                <ItemStyle Font-Size="X-Small" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dept. Name" HeaderText="Dept. Name" 
                                SortExpression="Dept. Name">
                                <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="End Date" HeaderText="End Date" 
                                SortExpression="End Date">
                                <ItemStyle Width="135px" Font-Size="X-Small" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Priority" HeaderText="Priority" 
                                SortExpression="Priority">
                                <ItemStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Post" HeaderText="Post" SortExpression="Post">
                                <ItemStyle Width="60px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <br />
                    <asp:SqlDataSource ID="sql_datasource_tasks_all" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" SelectCommand="     select t.id as ID,t.createdatetime as [Create Date],

      t.enddatetime as [End Date],t.subject as Subject, 

      lm.name_ as [TO],lmm.name_ as [FROM], s.&quot;desc&quot; as Status,

     p.&quot;desc&quot; as Priority, d.dept_name as [Dept. Name], l.short_key as [Post]
 
  from   
  tbl_tasks as t,
  tbl_dept_master as d,
  tbl_levels as l,
  tbl_priority as p, 
  tbl_status as s, 
  tbl_loginer_master as lm,
 tbl_loginer_master as lmm
  where 
  lm.id = t.assignedto and
lmm.id = t.creator and 
  s.id=t.statusid and 
  p.id = t.priorityid and 
  d.id = t.deptid and 
  l.id = t.levelid and
  t.creator= t.creator
  order by t.id
"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
	</div>
</asp:Content>


<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
   
</body>
</html>--%>
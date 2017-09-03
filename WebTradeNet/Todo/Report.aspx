<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Todo/TD.master" CodeFile="Report.aspx.vb" Inherits="Report1" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
--%><asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

    <p style="width: 647px">
        <asp:Label ID="lbl_id" runat="server" Text="1" Visible="False"></asp:Label>
				
    </p>
    <p style="width: 647px">
        &nbsp;<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    <asp:Panel ID="Panel1" runat="server" Height="500px" BackColor="#DDEEFF" 
        BorderColor="#FF99FF" BorderStyle="Outset" CssClass="colCopy" Width="950px">
        <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="58px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Status&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Width="101px">
        </asp:DropDownList>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Button" />
        &nbsp;<br />
        &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="900px" Font-Size="Smaller" BorderColor="#FFCCCC" 
            BorderStyle="Double" HorizontalAlign="Center">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Create Date" HeaderText="Create Date" 
                    SortExpression="Create Date" />
                <asp:BoundField DataField="End Date" HeaderText="End Date" 
                    SortExpression="End Date" />
                <asp:BoundField DataField="Subject" HeaderText="Subject" 
                    SortExpression="Subject" />
                <asp:BoundField DataField="Priority" HeaderText="Priority" 
                    SortExpression="Priority" />
                <asp:BoundField DataField="Dept. Name" HeaderText="Dept. Name" 
                    SortExpression="Dept. Name" />
                <asp:BoundField DataField="Post" HeaderText="Post" SortExpression="Post" />
                <asp:BoundField DataField="TO" HeaderText="TO" SortExpression="TO" />
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                BorderStyle="Solid" />
            <EditRowStyle BackColor="#2461BF" Font-Size="XX-Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
            
            SelectCommand="SELECT t.id AS ID, t.createdatetime AS [Create Date], t.enddatetime AS [End Date], t.subject AS Subject, e.name_ AS [TO], p.[desc] AS Priority, d.dept_name AS [Dept. Name], l.short_key AS Post 
FROM tbl_tasks AS t 
INNER JOIN tbl_loginer_master AS lm ON t.deptid = lm.forign_id 
INNER JOIN tbl_loginer_master AS e ON t.assignedto = e.id and t.deptid = e.forign_id
INNER JOIN tbl_status AS s ON t.statusid = s.id 
INNER JOIN tbl_priority AS p ON t.priorityid = p.id 
INNER JOIN tbl_levels AS l ON t.levelid = l.id 
INNER JOIN tbl_dept_master AS d ON t.deptid = d.id 
WHERE (s.id = @statusassigned and lm.id=@loginerId) ORDER BY ID">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="statusassigned" 
                    PropertyName="SelectedValue" />
                <asp:Parameter DefaultValue="1" Name="loginerId" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    </p>
    <br />
    <br />
                <p style="width: 647px">
                    &nbsp;</p>
                <p style="width: 647px">
    </p>
                <p style="width: 647px">
    </p>
    <p style="width: 708px">
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
    <p>
    </p>

</asp:Content>

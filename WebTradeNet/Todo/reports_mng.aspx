<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Todo/TD.master" CodeFile="reports_mng.aspx.vb" Inherits="Todo_reports_mng" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

                <p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            DataSourceID="SqlDataSource3" DataTextField="desc" DataValueField="id" 
            RepeatDirection="Horizontal" AutoPostBack="True">
        </asp:RadioButtonList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
            SelectCommand="SELECT * FROM [tbl_status]"></asp:SqlDataSource>
        </p>
        <table style="width: 100%; height: 89px;" __designer:mapid="4f">
            <tr __designer:mapid="81">
                <td style="width: 212px" __designer:mapid="82">
                    <asp:Panel ID="pnl_dept" runat="server" Width="187px">
                        <br />
                        Select Dept&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownList2" runat="server" 
                            DataSourceID="SqlDataSource4" DataTextField="dept_name" 
                            DataValueField="id" AutoPostBack="True" style="height: 22px">
                        </asp:DropDownList>
                        <br />
                        &nbsp;&nbsp;<asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
                            SelectCommand="SELECT [id], [dept_name] FROM [tbl_dept_master]">
                        </asp:SqlDataSource>
                    </asp:Panel>
                </td>
                <td __designer:mapid="84">
                    &nbsp;&nbsp;
                    <asp:Panel ID="pnl_branch" runat="server" Width="220px">
                        &nbsp;Select Branch&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" 
                            DataSourceID="SqlDataSource5" DataTextField="branch_name" 
                            DataValueField="id" AutoPostBack="True">
                        </asp:DropDownList>
                        <br />
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
                            SelectCommand="SELECT [id], [branch_name] FROM [tbl_branch_master]">
                        </asp:SqlDataSource>
                    </asp:Panel>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Submit" Width="78px" />
                    &nbsp;</td>
            </tr>
        </table>
        <p>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        </p>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataSourceID="SqlDataSource7" Font-Size="Smaller" ForeColor="#333333" 
            GridLines="None" BorderColor="#666699" BorderStyle="Outset" 
            HorizontalAlign="Center" Width="900px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Create Date" HeaderText="Create Date" 
                    SortExpression="Create Date" />
                <asp:BoundField DataField="End Date" HeaderText="End Date" 
                    SortExpression="End Date" />
                <asp:BoundField DataField="Subject" HeaderText="Subject" 
                    SortExpression="Subject" />
                <asp:BoundField DataField="TO" HeaderText="TO" SortExpression="TO" />
                <asp:BoundField DataField="Priority" HeaderText="Priority" 
                    SortExpression="Priority" />
                <asp:BoundField DataField="branch. Name" HeaderText="branch. Name" 
                    SortExpression="branch. Name" />
                <asp:BoundField DataField="Post" HeaderText="Post" SortExpression="Post" />
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <p>
    </p>
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BorderColor="#666699" 
            BorderStyle="Outset" CellPadding="4" DataSourceID="SqlDataSource6" 
            Font-Size="Smaller" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Center" Width="900px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
            ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
            SelectCommand="SELECT t.id AS ID, t.createdatetime AS [Create Date], t.enddatetime AS [End Date], t.subject AS Subject, lm.name_ AS [TO], p.[desc] AS Priority, d.branch_name AS [Branch Name], l.short_key AS Post 
FROM tbl_tasks AS t 
INNER JOIN tbl_loginer_master AS lm ON t.assignedto = lm.id 
INNER JOIN tbl_status AS s ON t.statusid = s.id 
INNER JOIN tbl_priority AS p ON t.priorityid = p.id 
INNER JOIN tbl_branch_master AS d ON t.branchid = d.id 
INNER JOIN tbl_levels AS l ON t.levelid = l.id 
WHERE (s.id = @param) and (d.id =@param2) ORDER BY ID">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadioButtonList1" Name="param" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DropDownList2" Name="param2" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;<p>
        &nbsp;<asp:SqlDataSource ID="SqlDataSource7" runat="server" 
            ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
            
            
            SelectCommand="SELECT t.id AS ID, t.createdatetime AS [Create Date], t.enddatetime AS [End Date], t.subject AS Subject, lm.name_ AS [TO], p.[desc] AS Priority, b.branch_name AS [branch. Name], l.short_key AS Post FROM tbl_tasks AS t INNER JOIN tbl_loginer_master AS lm ON t.assignedto = lm.id INNER JOIN tbl_status AS s ON t.statusid = s.id INNER JOIN tbl_priority AS p ON t.priorityid = p.id INNER JOIN tbl_branch_master AS b ON t.branchid = b.id INNER JOIN tbl_levels AS l ON t.levelid = l.id WHERE (s.id = @param) AND (b.id = @param2) ORDER BY ID">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadioButtonList1" Name="param" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DropDownList3" Name="param2" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>

<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Todo/TD.master" CodeFile="Assigned task.aspx.vb" Inherits="Todo_Assigned_task" %>


<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

                
    <br />
    <asp:Label ID="lbl_id" runat="server" Text="1" Visible="False"></asp:Label>
                    
                    <table style="width: 160%">
                        <tr>
                            <td style="width: 427px">
                                <table class="style5">
                                    <tr>
                                        <td class="style8" style="width: 298px; height: 36px">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style8" style="width: 298px; height: 204px">
                                            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                                                CellPadding="4" DataSourceID="SqlDataSource4" Font-Size="Smaller" 
                                                ForeColor="#333333" Height="20px" HorizontalAlign="Left" PageSize="5" 
                                                Width="475px" DataKeyNames="id">
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                <EmptyDataRowStyle Font-Size="Smaller" />
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                                                    <asp:BoundField DataField="Subject" HeaderText="Subject" 
                                                        SortExpression="Subject" />
                                                    <asp:BoundField DataField="EndingOn" HeaderText="EndingOn" 
                                                        SortExpression="EndingOn" />
                                                    <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" 
                                                        SortExpression="AssignedTo" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" 
                                                        SortExpression="Status" />
                                                    <asp:BoundField DataField="Priority" HeaderText="Priority" 
                                                        SortExpression="Priority" />
                                                </Columns>
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#FFCC66" BorderStyle="Dotted" Font-Bold="True" 
                                                    ForeColor="Navy" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle Font-Size="Smaller" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                            
                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" SelectCommand="SELECT     t.id, t.subject AS Subject, t.enddatetime AS EndingOn, l.name_ AS AssignedTo, s.[desc] AS Status, p.[desc] AS Priority
FROM         tbl_tasks AS t INNER JOIN
                      tbl_status AS s ON t.statusid = s.id INNER JOIN
                      tbl_priority AS p ON t.priorityid = p.id INNER JOIN
                      tbl_loginer_master AS l ON t.assignedto = l.id
WHERE     (t.creator = @creator and t.statusid &lt;&gt; 4)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lbl_id" DefaultValue="1" Name="creator" 
                                                        PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                                
                                    
                                        <td class="style8" style="height: 204px; width: 525px">
                                            <br />
                                            <asp:TextBox ID="txt_desc" runat="Server" 
                                                ReadOnly="True" Width="75%" />
                                            <br />
                                            <br />
                                            <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Btn_cancel" runat="server" BackColor="Red" Font-Bold="True" 
        ForeColor="White" Text="Cancel Task" Width="104px" />
                                            <br />
                                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Lbl_Remark" runat="server" ForeColor="#37408E" Text="Remark"></asp:Label>
                                            <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="Txt_remark" runat="server" Height="53px" TextMode="MultiLine" 
        Width="171px"></asp:TextBox>
                                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Btn_Submit" runat="server" Text="Submit" />
			                                <br />
                                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <br />
                           
                    </table>
                    <br />
                    <br />

    <br />
    <br />

                <asp:Panel ID="Panel1" runat="server" Height="231px" Width="813px">
                    <br />
                    <asp:GridView ID="GridView5" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                        CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" 
                        Font-Size="Smaller" ForeColor="#333333" Height="20px" HorizontalAlign="Left" 
                        Width="500px">
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <EmptyDataRowStyle Font-Size="Smaller" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                            <asp:BoundField DataField="Column1" HeaderText="Type" 
                                SortExpression="Column1" />
                            <asp:BoundField DataField="subject" HeaderText="subject" 
                                SortExpression="subject" />
                        </Columns>
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" BorderStyle="Dotted" Font-Bold="True" 
                            ForeColor="Navy" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle Font-Size="Smaller" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" SelectCommand="SELECT [id], 'Daily',[subject] 
FROM [tbl_todo_master] where periodtype=1
union
SELECT [id], 'Weekly',[subject] 
FROM [tbl_todo_master] where periodtype=2
union 
SELECT [id], 'Monthly',[subject] 
FROM [tbl_todo_master] where periodtype=3
order by 2"></asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                    <br />
                </asp:Panel>

</asp:Content>

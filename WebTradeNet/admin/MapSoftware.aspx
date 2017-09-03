<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="MapSoftware.aspx.vb" Inherits="admin_MapSoftware" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<table>
<tr>
<td>

     <asp:Label ID="Label1" runat="server" Text="Select Employee Login :"></asp:Label>

</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="EmpDataSource1" DataTextField="username_" 
        DataValueField="username_">
    </asp:DropDownList>
    <asp:SqlDataSource ID="EmpDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString2 %>" 
        SelectCommand="SELECT DISTINCT [username_] FROM [tbl_loginer_master]">
    </asp:SqlDataSource>
    </td>
<td rowspan="4">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="MappDataSource1">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Software" HeaderText="Software" 
                SortExpression="Software" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="MessageLabel4" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
    <asp:SqlDataSource ID="MappDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString2 %>" 
        SelectCommand="SELECT DISTINCT [Software] FROM [SoftwareMapping] WHERE ([UserName] = @UserName)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="UserName" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="Label2" runat="server" Text="Employee Name :"></asp:Label>

</td>
<td><asp:Label ID="NameLabel4" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td>

    <asp:Label ID="Label3" runat="server" Text="Software"></asp:Label>

</td>
<td>
    <asp:DropDownList ID="DropDownList2" runat="server" 
        DataSourceID="SoftwREDataSource1" DataTextField="Software_Name" 
        DataValueField="Software_Name">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SoftwREDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString2 %>" 
        SelectCommand="SELECT DISTINCT [Software_Name] FROM [Software Suite]">
    </asp:SqlDataSource>
    </td>
</tr>
<tr>
<td>

    &nbsp;</td>
<td>
    <asp:Button ID="Button3" runat="server" Text="Assign" />
    <asp:Button ID="Button4" runat="server" Text="Remove" />
    </td>
</tr>
</table></center>
</asp:Content>


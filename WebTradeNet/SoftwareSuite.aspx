<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SoftwareSuite.aspx.vb" Inherits="SoftwareSuite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <center>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/TradeNet.JPG" />
            <br />
            <asp:Image ID="Image2" runat="server" Height="38px" 
                ImageUrl="~/images/Softsuite.JPG" />
            <br />
            <table width="100%">
            <tr>
            <td>
            
                <asp:Label Visible="false"  ID="LoginTypeLabel1" runat="server" Text=""></asp:Label>
            
            </td>
            <td align="right">
                <asp:Label ID="LoginLabel1" runat="server" Text=""></asp:Label>
                [<asp:LinkButton ID="LinkButton1" runat="server">Exit</asp:LinkButton>]
            </td>
            </tr>
            </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
            <RowStyle BorderStyle="Solid" BorderWidth="1" BorderColor="Black"  BackColor="#EFF3FB" />
            <Columns>
               
                <asp:CommandField SelectText="Open" ShowSelectButton="True" />
               
                <asp:BoundField DataField="Software" HeaderText="Software" 
                    SortExpression="Software" />
                      
            </Columns>
            
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1" BorderColor="Black"  BackColor="#EFF3FB" />
        </asp:GridView></center>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString2 %>" 
            SelectCommand="SELECT DISTINCT [Software]  FROM [SoftwareMapping] WHERE ([UserName] = @UserName)">
            <SelectParameters>
                <asp:SessionParameter Name="UserName" SessionField="login" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
       
    
    </div>
    </form>
</body>
</html>

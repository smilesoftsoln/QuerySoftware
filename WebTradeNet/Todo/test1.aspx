<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test1.aspx.vb" Inherits="test1" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <eo:Grid ID="Grid1" runat="server" AllowColumnReorder="True" 
        AllowNewItem="True" AllowPaging="True" Font-Bold="False" Font-Italic="False" 
        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
        GoToBoxVisible="True">
        <ItemStyles>
            <eo:GridItemStyleSet>
            </eo:GridItemStyleSet>
        </ItemStyles>
        <Columns>
            <eo:StaticColumn DataType="String" HeaderText="Full Name" Name="FullName" 
                SortOrder="Ascending" Text="Test Full Name">
            </eo:StaticColumn>
            <eo:StaticColumn HeaderText="Address" Name="Address" Text="Test Address">
            </eo:StaticColumn>
            <eo:StaticColumn HeaderText="City" Name="City" Text="Test City">
            </eo:StaticColumn>
            <eo:StaticColumn HeaderText="State" Name="State" Text="Test State">
            </eo:StaticColumn>
        </Columns>
    </eo:Grid>
    </form>
</body>
</html>

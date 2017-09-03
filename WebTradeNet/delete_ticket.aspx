<%@ Page Language="VB" AutoEventWireup="false" CodeFile="delete_ticket.aspx.vb" Inherits="delete_ticket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" >
        Are You Sure To Delete This Ticket ?
    <br />
            <asp:Button ID="Btn_ok" runat="server" Text="Done !" />
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" />
        </asp:Panel>
    
        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <a href="JavaScript:history.back()"><< Back</a>
    </div>
    </form>
</body>
</html>

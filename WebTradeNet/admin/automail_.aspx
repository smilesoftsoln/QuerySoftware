<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="automail_.aspx.vb" Inherits="admin_automail_" title="Auto generate Report Of Unsolved Queries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Auto generate Report Of Unsolved Queries</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;text-align:left;">
    <tr>
        <td>
             <asp:Button ID="Button1" runat="server" Text=" Generate Unsolved Report !" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
        </td>
    </tr>
</table>
   
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/admin_controls_master.master" AutoEventWireup="false" CodeFile="user_info.aspx.vb" Inherits="user_info" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr>
        <td colspan="2">
            <b>User Info.
        </td>
    </tr>
    <tr>
        <td>
            Name : 
        </td>
        <td>
            <asp:Label ID="lbl_name" runat="server" Text="Not Include"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Username :
        </td>
        <td>
            <asp:Label ID="lbl_username" runat="server" Text="Not Include"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Loginer ID :
        </td>
        <td>
            <asp:Label ID="lbl_l_id" runat="server" Text="Not Include"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Designation :
        </td>
        <td>
            <asp:Label ID="lbl_Designation" runat="server" Text="Not Include"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Desc :
        </td>
        <td>
            <asp:Label ID="lbl_desc" runat="server" Text="Not Include"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Joining Date :
        </td>
        <td>
            <asp:Label ID="lbl_j_date" runat="server" Text="Not Include"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            E-mail ID :
        </td>
        <td>
            <asp:Label ID="lbl_email_ud" runat="server" Text="Not Include"></asp:Label>    
        </td>
    </tr>
    <tr>
        <td>
            <a href="JavaScript:history.back()"><< Back</a>
        </td>
    </tr>
</table>
</asp:Content>


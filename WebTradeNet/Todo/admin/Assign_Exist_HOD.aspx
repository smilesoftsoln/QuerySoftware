<%@ Page Language="VB" MasterPageFile="~/todo/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="Assign_Exist_HOD.aspx.vb" Inherits="admin_Assign_Exist_HOD" title="Assign Exist HOD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Assign Existing HOD</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;text-align:left;">
    <tr>
        <td>
            For Depertment<br />
            (HOD Less Depaetments)
        </td>
        <td>
            <asp:DropDownList ID="cbo_depts" runat="server" class="validate[required],length[0,100]]" name="developername">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Select HOD
        </td>
        <td>
            <asp:DropDownList ID="cbo_hods" runat="server" class="validate[required],length[0,100]]" name="developername">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btn_submit" runat="server" Text="Submit" Width="100%" />
        </td>
    </tr>
</table>
</asp:Content>


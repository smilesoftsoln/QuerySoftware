<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="edit_dept.aspx.vb" Inherits="admin_edit_dept" title="Edit Department Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Edit Department Details</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;">
    <tr>
        <td >
            Select Department :
        </td>
        <td style="width: 184px">
            <asp:DropDownList ID="cbo_depts" runat="server" AutoPostBack="True" Width="175px" class="validate[required],length[0,100]]" name="developername" >
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Department Name :
        </td>
        <td style="width: 184px">
            <asp:TextBox ID="txt_depts_name" runat="server" Width="175px" class="validate[required],length[0,100]]" name="developername" ></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td style="height: 40px">
            Department Description :
            <br />
        </td>
        <td style="width: 184px; height: 40px">
            <asp:TextBox ID="txt_dept_desc" runat="server" Width="175px" class="validate[required],length[0,100]]" name="developername" TextMode="MultiLine" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 27px">
            Select Management :
        </td>
        <td style="width: 184px; height: 27px">
            <asp:DropDownList ID="cbo_mgmt" runat="server" AutoPostBack="True" Width="175px" class="validate[required],length[0,100]]" name="developername" Height="21px" >
            </asp:DropDownList></td>
    </tr>
    
    <tr>
        <td colspan="2" align="center" style="height: 24px">
            <asp:Button ID="btn_update" runat="server" Text="Update" />
        </td>
    </tr>
</table>
</asp:Content>


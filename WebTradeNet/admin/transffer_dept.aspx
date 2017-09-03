<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="transffer_dept.aspx.vb" Inherits="admin_transffer_dept" title="Transfer Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Transfer Department</h2>
<hr />
<table style="margin-left:auto;margin-right:auto;text-align:left;">
    <tr>
        <td>
            Select Department :            
        </td>
        <td>
            <asp:DropDownList ID="cbo_depts" runat="server" class="validate[required],length[0,100]]" name="developername" Width="120px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            To HOD :
        </td>
        <td>
            <asp:DropDownList ID="cbo_hods" runat="server" class="validate[required],length[0,100]]" name="developername" Width="120px">
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td colspan="2">
            <asp:Panel ID="pnl_chk" runat="server">
            
            <fieldset >
                <legend>
                    Confirm
               </legend>
           <asp:CheckBox ID="CheckBox1" runat="server" /> I am sure to Transfer this department
           </fieldset>
                
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btn_submit" runat="server" Text="Transfer " Width="100%" />
        </td>
    </tr>
</table>
</asp:Content>



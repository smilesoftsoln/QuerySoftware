<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="add_new_user_stape_2.aspx.vb" Inherits="admin_add_new_user_stape_2" title="Add New User Stape 2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="scripts/jquery.js" type="text/javascript"></script>
<script src="scripts/jquery_002.js" type="text/javascript"></script>
<link rel="stylesheet" href="scripts/validationEngine.css" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Add New User</h2>
<hr />
<div id="msg" runat="server" style="color:Red;font-weight:bold;">

</div>
    <asp:Label ID="LBL_INFO" runat="server" Text=""></asp:Label>
<asp:Panel ID="pnl_BE" runat="server" Height="50px" Width="100%" Visible="false">
    <table style="margin-left:auto;margin-right:auto;text-align:left;">
        <tr>
            <td>
                Select Branch : 
            </td>
            <td>                
                <asp:DropDownList ID="cbo_branch" runat="server" class="validate[required],length[0,100]]" name="developername">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_submit" runat="server" Text="Complete" Width="100%" />
            </td>
        </tr>
    </table>
</asp:Panel>



<asp:Panel ID="pnl_DE" runat="server" Height="50px" Width="100%" Visible="false">
    <table style="margin-left:auto;margin-right:auto;text-align:left;">
        <tr>
            <td>
                Select Department : 
            </td>
            <td>                
                <asp:DropDownList ID="cbo_depts" runat="server" class="validate[required],length[0,100]]" name="developername">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_dept_submit" runat="server" Text="Complete" Width="100%" />
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnl_HOD" runat="server" Height="50px" Width="100%" Visible="false">
    <table style="margin-left:auto;margin-right:auto;text-align:left;">
        <tr>
            <td>
                Select Department : 
            </td>
            <td>                
                <asp:DropDownList ID="cbo_depts_1_hod" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_sub_hod" runat="server" Text="Complete" Width="100%" Visible="False" />
            </td>
        </tr>
    </table>
</asp:Panel>


<asp:Panel ID="pnl_mng" runat="server" Height="50px" Width="100%" Visible="false">
    <table style="margin-left:auto;margin-right:auto;text-align:left;">
        <tr>
            <td>
                Select Management : 
            </td>
            <td>                
                <asp:DropDownList ID="cbo_mngs" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_sub_mng" runat="server" Text="Complete" Width="100%" Visible="False" />
            </td>
        </tr>
    </table>
</asp:Panel>


</asp:Content>


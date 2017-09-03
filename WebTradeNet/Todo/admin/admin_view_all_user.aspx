<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_view_all_user.aspx.cs" Inherits="admin_admin_view_all_user" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2>View All Users</h2>
    [BE : Branch Employee ][ BH: Branch Head ][ DE : Department Employee ][ HOD: Head
    Of Department ]
<hr />

<div class="welcome_pan">

<table width = "100%">
    <tr>
        <td>
        <fieldset class="fieldset_css">
            <legend>
                Select Type
           </legend>
        <asp:DropDownList ID="dduser" runat="server" AutoPostBack="True" 
                 
                style="margin-bottom: 0px" 
                onselectedindexchanged="dduser_SelectedIndexChanged">
        </asp:DropDownList>
    </fieldset>
        </td>
        <td style="width:250px;">
        
        <asp:Panel ID="pnl_be" runat="server" Visible="false">
                <fieldset  class="fieldset_css">
                        <legend>
                            Select Branch
                       </legend>
                    <asp:DropDownList ID="ddlist_branch" runat="server">
                    </asp:DropDownList>
                </fieldset>
            </asp:Panel>
            
            <asp:Panel ID="pnl_de" runat="server" Visible="false">
                <fieldset>
                        <legend>
                            Select Department
                       </legend>
                    <asp:DropDownList ID="ddlist_dept" runat="server">
                    </asp:DropDownList>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="pnl_mng" runat="server" Visible="false">
                <fieldset>
                        <legend>
                            Select management
                       </legend>
                    <asp:DropDownList ID="ddlist_mng" runat="server">
                    </asp:DropDownList>
                </fieldset>
            </asp:Panel>
        </td>
        <td>
            <div style="float:right;clear:right;display:block;">
            <br />
            <asp:Button ID="btnview" runat="server" Text="VIEW" onclick="btnview_Click" /><br />
            
            </div>
        </td>
    </tr>    
        
</div>

<div id = "view" runat = "server" width = "100%" >
    <table width = "100%" >
        <div id = "div_view" runat ="server" >
        
        </div>
    </table>
</div> 


</asp:Content>


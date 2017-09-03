<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="view_all_users.aspx.vb" Inherits="admin_view_all_users" title="View All Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css">
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>View All Users</h2>
    [BE : Branch Employee ][ BH: Branch Head ][ DE : Department Employee ][ HOD: Head
    Of Department ]
<hr />
<div class="welcome_pan">

<table>
    <tr>
        <td>
        <fieldset class="fieldset_css">
            <legend>
                Select Type
           </legend>
        <asp:DropDownList ID="cbo_typ" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True">ALL</asp:ListItem>
            <asp:ListItem>BE</asp:ListItem>
            <asp:ListItem>BH</asp:ListItem>
            <asp:ListItem>DE</asp:ListItem>
            <asp:ListItem>HOD</asp:ListItem>
              <asp:ListItem>SHOD</asp:ListItem>

          
            <asp:ListItem>MNG</asp:ListItem>
        </asp:DropDownList>
    </fieldset>
        </td>
        <td style="width:250px;">
            <asp:Panel ID="pnl_be" runat="server" Visible="false">
                <fieldset  class="fieldset_css">
                        <legend>
                            Select Branch
                       </legend>
                    <asp:DropDownList ID="cbo_be" runat="server">
                    </asp:DropDownList>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="pnl_de" runat="server" Visible="false">
                <fieldset>
                        <legend>
                            Select Department
                       </legend>
                    <asp:DropDownList ID="cbo_dept" runat="server">
                    </asp:DropDownList>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="pnl_mng" runat="server" Visible="false">
                <fieldset>
                        <legend>
                            Select management
                       </legend>
                    <asp:DropDownList ID="cbo_mng" runat="server">
                    </asp:DropDownList>
                </fieldset>
            </asp:Panel>
        </td>
        <td>
            <div style="float:right;clear:right;display:block;">
            <br />
            <asp:Button ID="btn_go" runat="server" Text=" Go »» " /><br />
            
            </div>
        </td>
    </tr>
</table>

    
    
    
    
    
</div>

<div id="disp_users" runat="server"></div>
<script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
</script>
</asp:Content>


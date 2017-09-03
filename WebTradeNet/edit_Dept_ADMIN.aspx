<%@ Page Language="VB" MasterPageFile="~/admin_controls_master.master" AutoEventWireup="false" CodeFile="edit_Dept_ADMIN.aspx.vb" Inherits="edit_Dept_ADMIN" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h4>
    Edit Options
</h4>

<asp:Panel ID="Panel1" runat="server" GroupingText="Edit Admin Info."  Width="750px" CssClass="for_alpha_panal">
   Select Username : 
    <asp:DropDownList ID="cbo_user" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <asp:Label ID="lbl_user" runat="server" Visible="False"></asp:Label>
</asp:Panel>

<asp:Panel ID="pnl_edit_info" runat="server" GroupingText="Edit Info." Visible="false" Width="750px" CssClass="for_alpha_panal">
<table cellpadding="0" cellspacing="0" style="width:60%;margin-left:auto;margin-right:auto;">
            <tr>
                <td style="width:50%"> 
                    Full Name 
                </td>
                <td style="width:50%">
                    <asp:TextBox ID="txt_f_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            
             
             <tr>
                <td>
                    UserName 
                </td>
                <td>
                    <asp:TextBox ID="txt_username" runat="server" AutoPostBack="True" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
             
             
             
             <tr>
                <td>
                    Email Id 
                </td>
                <td>
                    <asp:TextBox ID="txt_email" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td colspan="2" align="center">
                <p>
                    <asp:ImageButton ID="btn_ok" runat="server" 
                        ImageUrl="~/images/btn_done.gif" />
                    <asp:ImageButton ID="btn_cancel" runat="server" 
                        ImageUrl="~/images/btn_cancel_2.gif" />
                 </p>
                </td>
             </tr>
            
            </table>
</asp:Panel>
</asp:Content>

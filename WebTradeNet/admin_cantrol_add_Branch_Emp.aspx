<%@ Page Language="VB" MasterPageFile="~/admin_controls_master.master" AutoEventWireup="false" CodeFile="admin_cantrol_add_Branch_Emp.aspx.vb" Inherits="admin_cantrol_add_Branch_Emp" title="TradeNet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="admin_contr_main_right_insede_top">
        Add Branch Employee
    </div>
    <div class="admin_contr_main_right_insede_mid">
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
                    Choose UserName 
                </td>
                <td>
                    <asp:TextBox ID="txt_username" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Choose Password 
                </td>
                <td>
                    <asp:TextBox ID="txt_c_pass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Confirm Password 
                </td>
                <td>
                    <asp:TextBox ID="txt_conf_pass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                   Select Branch
                </td>
                <td>
                    <asp:DropDownList ID="cbo_branchs" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>
                    Phone Number 
                </td>
                <td>
                    <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox>
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
                <td>
                    Working As
                </td>
                <td>
                    <asp:DropDownList ID="cbo_w_post" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="BE">Branch Employee</asp:ListItem>
                        <asp:ListItem Value="BH">Branch Head</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    
                    <asp:ImageButton ID="btn_submit" runat="server" 
                        onMouseDown="this.src='images/btn_create_mouse_down.jpg';" 
                        onMouseOver="this.src='images/btn_create_hove.jpg';" 
                        onMouseUp="this.src='~/images/btn_create.jpg';"  onMouseOut="this.src='images/btn_create.jpg';"
                        ImageUrl="~/images/btn_create.jpg" />
                    
                    <asp:ImageButton ID="btn_cancel" runat="server"  
                        onMouseDown="this.src='images/btn_cancel_down.jpg';" 
                        onMouseOver="this.src='images/btn_cancel_hover.jpg';" 
                        onMouseUp="this.src='~/images/btn_cancel_bb.jpg';"  onMouseOut="this.src='images/btn_cancel_bb.jpg';"
                        ImageUrl="~/images/btn_cancel_bb.jpg" />
                    
                </td>
            </tr>
        </table>
    </div>
    <div class="admin_contr_main_right_insede_bottom">
    </div>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/admin_controls_master.master" AutoEventWireup="false" CodeFile="admin_cantrol_add_Branch.aspx.vb" Inherits="admin_cantrol_add_Branch" title="TradeNet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="admin_contr_main_right_insede_top">
        Add New Branch Entry
    </div>
    <div class="admin_contr_main_right_insede_mid">
        <table cellpadding="0" cellspacing="0" style="width:60%;margin-left:auto;margin-right:auto;vertical-align:top;">
            <tr>
                <td style="width:50%"> 
                    Branch Display Name 
                </td>
                <td style="width:50%">
                    <asp:TextBox ID="txt_b_name" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Branch Description :
                </td>
                <td>
                    <asp:TextBox ID="txt_desc" runat="server" Height="104px" TextMode="MultiLine"></asp:TextBox>
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


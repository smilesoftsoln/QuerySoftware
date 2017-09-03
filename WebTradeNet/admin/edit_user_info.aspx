<%@ Page Language="VB" MasterPageFile="~/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="edit_user_info.aspx.vb" Inherits="admin_edit_user_info" title="Edit User Info." %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Edit User Info.</h2>
<hr />
<div id="msg" runat="server" style="color:Red;font-weight:bold;">

</div>

    <table visible="false" style="margin-left:auto;margin-right:auto;">
            <tr>
                <td colspan="2">
                    <b><asp:Label ID="lbl_name" runat="server" Text=""></asp:Label></b>
                </td>
            </tr>
        <asp:Label ID="lbl_username" runat="server" Visible="false" Text="Label"></asp:Label>
    </table>
    <table style="margin-left:auto;margin-right:auto;text-align:left;">
    <tr>
        <td>
            Select User Type :
        </td>
        <td>
            <asp:DropDownList ID="cbo_user_typ" runat="server" 
                  name="developername" 
                AutoPostBack="True" Enabled="False" EnableTheming="True">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>BE</asp:ListItem>
                <asp:ListItem>BH</asp:ListItem>
                <asp:ListItem>DE</asp:ListItem>
                <asp:ListItem>HOD</asp:ListItem>
                <asp:ListItem>SRMNG</asp:ListItem>
                <asp:ListItem>SHOD</asp:ListItem>
               
                <asp:ListItem>MNG</asp:ListItem>
                 
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
   
 
    <asp:Label ID="LBL_INFO" runat="server" Text=""></asp:Label>
     
<asp:Panel ID="pnl_BE1" runat="server"   Visible="false">
     
                Select Branch : 
                          
                <asp:DropDownList ID="cbo_branch" runat="server"  name="developername">
                </asp:DropDownList>
            
</asp:Panel>


 
<asp:Panel ID="pnl_DE1" runat="server"   Visible="false">
     
         
                Select Department : 
                         
                <asp:DropDownList ID="cbo_depts" AutoPostBack ="true"  runat="server" class="validate[required],length[0,100]]" name="developername">
                </asp:DropDownList>
            
                
     
</asp:Panel>
 
<asp:Panel ID="pnl_HOD1" runat="server"     Visible="false">
  
                Select Department : 
                       
                <asp:DropDownList ID="cbo_depts_1_hod" runat="server"  name="developername" AutoPostBack="True">
                </asp:DropDownList>
             
              
</asp:Panel>
 
<asp:Panel ID="pnl_mng1" runat="server"   Visible="false">
     
                <asp:DropDownList ID="cbo_mngs" runat="server"   name="developername" AutoPostBack="True">
                </asp:DropDownList>
           
</asp:Panel>

 
</tr>
    <tr>
        <td>
            UserName :    <td>
            <asp:TextBox ID="UserNameTextBox1" runat="server" 
                class="validate[required],length[0,100]]" name="developername" 
                AutoPostBack="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Password :
        </td>
        <td>
            <asp:TextBox ID="txt_pwd" runat="server" 
                class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Password : 
        </td>
        <td>
            <asp:TextBox ID="txt_conf_pwd" runat="server" 
                class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <hr />
        </td>
    </tr>
    <tr>
        <td>
            Name :
        </td>
        <td>
            <asp:TextBox ID="NameTextBox2" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Email id : 
        </td>
        <td>
            <asp:TextBox ID="EmailTextBox3" runat="server" 
                class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Phone Number :
        </td>
        <td>
            <asp:TextBox ID="PhoneTextBox4" runat="server" 
                class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td colspan="2">
            <br />
            <asp:Button ID="Button1" runat="server" Text="Update" Width="100%" />
        </td>
    </tr>
    
</table>
</asp:Content>


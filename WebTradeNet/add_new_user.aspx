<%@ Page Language="VB" MasterPageFile="admin_Pnl.master" AutoEventWireup="false" CodeFile="add_new_user.aspx.vb" Inherits="admin_add_new_user" title="Add New User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="scripts/jquery.js" type="text/javascript"></script>
<script src="scripts/jquery_002.js" type="text/javascript"></script>
<link rel="stylesheet" href="scripts/validationEngine.css" type="text/css">
    <style type="text/css">
        #step2
        {
            height: 129px;
            width: 343px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Add New User</h2>
[BE : Branch Employee ][ BH: Branch Head ][ DE : Department Employee ][ HOD: Head Of Department ] 
<hr />
<div id="msg" runat="server" style="color:Red;font-weight:bold;">

</div>

<table style="margin-left:auto;margin-right:auto;text-align:left;">
    <tr>
        <td>
            Select User Type :
        </td>
        <td>
            <asp:DropDownList ID="cbo_user_typ" runat="server" 
                class="validate[required],length[0,100]]" name="developername" 
                AutoPostBack="True">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>BE</asp:ListItem>
                <asp:ListItem>BH</asp:ListItem>
                <asp:ListItem>DE</asp:ListItem>
                <asp:ListItem>HOD</asp:ListItem>
                   <asp:ListItem>SHOD</asp:ListItem>
             
                <asp:ListItem>SRMNG</asp:ListItem>
               
                <asp:ListItem>MNG</asp:ListItem>
                 
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
   
 
    <asp:Label ID="LBL_INFO" runat="server" Text=""></asp:Label>
     
<asp:Panel ID="pnl_BE1" runat="server"   Visible="false">
     
                Select Branch : 
                          
                <asp:DropDownList ID="cbo_branch" runat="server" class="validate[required],length[0,100]]" name="developername">
                </asp:DropDownList>
            
</asp:Panel>


 
<asp:Panel ID="pnl_DE1" runat="server"   Visible="false">
     
         
                Select Department : 
                         
                <asp:DropDownList ID="cbo_depts" runat="server" class="validate[required],length[0,100]]" name="developername">
                </asp:DropDownList>
            
                
     
</asp:Panel>
 
<asp:Panel ID="pnl_HOD1" runat="server"     Visible="false">
  
                Select Department : 
                       
                <asp:DropDownList ID="cbo_depts_1_hod" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True">
                </asp:DropDownList>
             
              
</asp:Panel>
 
<asp:Panel ID="pnl_mng1" runat="server"   Visible="false">
     
                <asp:DropDownList ID="cbo_mngs" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True">
                </asp:DropDownList>
           
</asp:Panel>

 
</tr>
    <tr>
        <td>
            Choose UserName :
        </td>
        <td>
            <asp:TextBox ID="txt_username" runat="server" class="validate[required],length[0,100]]" name="developername" AutoPostBack="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Password :
        </td>
        <td>
            <asp:TextBox ID="txt_pwd" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Confirm Password :
        </td>
        <td>
            <asp:TextBox ID="txt_conf_pwd" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
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
            <asp:TextBox ID="txt_name" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Email id : 
        </td>
        <td>
            <asp:TextBox ID="txt_email" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Phone Number :
        </td>
        <td>
            <asp:TextBox ID="txt_phone" runat="server" class="validate[required],length[0,100]]" name="developername"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td>
            Responsible For Query Resolution
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>NO</asp:ListItem>
                <asp:ListItem>YES</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    
    <tr>
        <td colspan="2">
            <br />
            <asp:Button ID="btn_submit" runat="server" Text="Save" Width="100%" />
        </td>
    </tr>
    
</table>

</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_create_user.aspx.cs" Inherits="admin_admin_create_user" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
        <asp:Label runat = "server" Text = "Create User" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>
                
                <td style="width: 200px">
                
                   <asp:Label runat ="server" Text = "[BE]" Font-Bold="True" ForeColor="#000099" ></asp:Label> : Branch Employee</td>
                
                <td style="width: 200px">
                
                    <asp:Label ID="Label2" runat ="server" Text = "[HOD]" Font-Bold="True" ForeColor="#000099" ></asp:Label> : Head of Dept</td>
            </tr>
            
             <tr>
                
                <td style="width: 200px">
                
                    <asp:Label ID="Label3" runat ="server" Text = "[SRMNG]" Font-Bold="True" ForeColor="#000099" ></asp:Label> :Senior Manager</td>
                
                <td style="width: 200px">
                
                    <asp:Label ID="Label4" runat ="server" Text = "[MNG]" Font-Bold="True" ForeColor="#000099" ></asp:Label>: Management</td>
            </tr>
            
            
            <tr>
                
                <td style="width: 200px">
                
                   
            </tr>
            
        </table>
    </div>
    
    
    <script type ="text/javascript">
     .tbl_padding
     {
        vertical-align:top;
	    padding-left:30px;
     }   
    </script> 
    <br />
    <table width = "100%" style="height: 4px">
        <tr>
            <td style="background-color: #C0C0C0">
            </td>
        </tr>
    
    </table>
    
    <div>
        <table width = "100%">
            <tr>
            
                <td>
                    
                        <table width = "100%" >
                            <tr>
                                <td style="width: 188px; height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                        ControlToValidate="ddselectuser" ErrorMessage="Please Select User" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px; height: 35px;" >
                                        <asp:Label ID = "lblusertype" runat = "server"  Text = "Select User Type :- " ></asp:Label>  
                                </td>
                                
                                <td style="height: 35px; height: 35px;" >
                                        <asp:DropDownList ID = "ddselectuser" runat = "server" Width = "200px" 
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddselectuser_SelectedIndexChanged" 
                                            style="height: 22px" ></asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 188px;height: 35px;"  >
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                        ControlToValidate="txtusername" ErrorMessage="Please enter Login ID" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;"  >
                                        <asp:Label ID = "Label7" runat = "server"  Text = "Login ID :-" ></asp:Label>  
                                </td>
                                
                                <td style="height: 35px" >
                                        <asp:TextBox ID = "txtusername" runat = "server" Width = "200px" 
                                            ontextchanged="txtusername_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>
                            
                             <tr>
                                <td style="width: 188px;height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                        ControlToValidate="txtpassword" ErrorMessage="Please Enter Password" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;"  >
                                        <asp:Label ID = "Label8" runat = "server"  Text = "Password :-" ></asp:Label>  
                                </td>
                                
                                <td style="height: 35px">
                                        <asp:TextBox ID = "txtpassword" runat = "server" Width = "200px" 
                                            ontextchanged="txtpassword_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>
                            
                             <tr>
                                <td style="width: 188px;height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                        ControlToValidate="txtconfirmpass" ErrorMessage="Please Enter Confirm Password" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;"  >
                                        <asp:Label ID = "Label9" runat = "server"  Text = "Confirm Password :-" ></asp:Label>  
                                </td>
                                
                                <td style="height: 35px">
                                        <asp:TextBox ID = "txtconfirmpass" runat = "server" Width = "200px" 
                                            ontextchanged="txtconfirmpass_TextChanged" ></asp:TextBox>
                                </td>
                                
                            </tr>
                            
                                <td colspan="3" style="background-color: #C0C0C0">
                                
                                </td>  
                                                           
                            
                            
                             <tr>
                                <td style="width: 188px;height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                        ControlToValidate="txtname" ErrorMessage="Please Enter Name" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;">
                                        <asp:Label ID = "Label10" runat = "server"  Text = "Name :-" ></asp:Label>  
                                </td>
                                
                                <td style="height: 35px">
                                        <asp:TextBox ID = "txtname" runat = "server" Width = "200px" 
                                            ontextchanged="txtname_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>
                            
                            
                           
                           <tr>
                                <td style="width: 188px;height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                        ControlToValidate="txtemail" ErrorMessage="Please Enter Email ID" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;">
                                        <asp:Label ID = "Label11" runat = "server"  Text = "Email ID :-" ></asp:Label>  
                                </td>
                                
                                <td style="height: 35px">
                                        <asp:TextBox ID = "txtemail" runat = "server" Width = "200px" ></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 188px;height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                        ControlToValidate="txtphoneno" ErrorMessage="Please Enter Phone No" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;">
                                        <asp:Label ID = "Label12" runat = "server"  Text = "Phone No. :-" ></asp:Label>  
                                </td>
                                
                                <td style="height: 35px">
                                        <asp:TextBox ID = "txtphoneno" runat = "server" Width = "200px" ></asp:TextBox>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td style="width: 188px;height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                        ControlToValidate="ddparameter" ErrorMessage="Please Select Parameter" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            
                                <td style="width: 170px;height: 35px;">
                                        <asp:Label ID = "lblcaption" runat = "server"  Text = "Phone No. :-" ></asp:Label>  
                                </td>
                                
                                <td style="height: 35px">
                                        <asp:DropDownList ID = "ddparameter" runat = "server" Width = "200px" ></asp:DropDownList>
                                </td>
                            </tr>
                                            
                            
                              <tr>
                                <td style="height: 35px;" align="center" colspan="3">
                                
                                        <asp:Button ID = "btnsave" runat = "server"  Text = "Add User" 
                                        Width="141px"  Height="36px" onclick="btnsave_Click" ></asp:Button>  
                                
                                </td>
                            
                            </tr>        
                            
                             <tr>
                                <td style="height: 35px;" align="center" colspan="3">
                                
                                
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        ShowMessageBox="True" ShowSummary="False" />
                                
                                
                                </td>                            
                            </tr>                            
                        </table> 
                        
                </td>
            </tr>
        </table> 
    </div>

</asp:Content>


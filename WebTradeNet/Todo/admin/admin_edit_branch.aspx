<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_edit_branch.aspx.cs" Inherits="admin_admin_edit_branch" Title="Untitled Page" %>

<script runat="server">

   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



  <table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "Edit Branch" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>                
                <td style="width: 200px">                
                <td style="width: 200px">                                   
            </tr>
            
             <tr>                
                <td style="width: 200px">
                    &nbsp;<td style="width: 200px">
            </tr>            
            <tr>                
                <td style="width: 200px">                
                    &nbsp;<td style="width: 200px">                
            </tr>            
        </table>
        
        
        
        <script type ="text/javascript">
     .tbl_padding
     {
        vertical-align:top;
	    padding-left:30px;
     }   
    </script>       
        
        <table width = "100%">
            <tr>
            
                <td>
                        
                       
                        
                        <table width = "100%" >
                         <tr>
                                <td style="width: 188px; height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        Display="None" ErrorMessage="Please Select Branch Name" 
                                        ControlToValidate="ddbranch" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px; height: 35px;" >
                                        <asp:Label ID = "Label2" runat = "server"  Text = "Select Branch :- " ></asp:Label> <asp:Label id = "Label3" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>   
                                </td>
                                
                                <td style="height: 35px; height: 35px;" >
                                        <asp:DropDownList ID = "ddbranch" runat = "server" Width = "200px" 
                                            AutoPostBack="True" onselectedindexchanged="ddbranch_SelectedIndexChanged" ></asp:DropDownList>
                                </td>
                            </tr>
                        
                        
                            <tr>
                                <td style="width: 188px; height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        Display="None" ErrorMessage="Please enter Branch Name" 
                                        ControlToValidate="txtbranch" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px; height: 35px;" >
                                        <asp:Label ID = "lblusertype" runat = "server"  Text = "Enter Branch Name :- " ></asp:Label> <asp:Label id = "star1" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>   
                                </td>
                                
                                <td style="height: 35px; height: 35px;" >
                                        <asp:TextBox ID="txtbranch" runat="server" Width="193px"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 188px;height: 35px;"  >
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtdescription" Display="None" 
                                        ErrorMessage="Please enter Branch Description" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;"  >
                                        <asp:Label ID = "Label7" runat = "server"  Text = "Description :-" ></asp:Label>  <asp:Label id = "star2" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>
                                </td>
                                
                                <td style="height: 35px" >
                                        <asp:TextBox ID = "txtdescription" runat = "server" Width = "200px" ></asp:TextBox>
                                </td>
                            </tr>
                            
                            
                             <tr>
                                <td style="width: 188px;height: 35px;"  >
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="ddmanagement" Display="None" 
                                        ErrorMessage="Please Select Management" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;"  >
                                        <asp:Label ID = "Label4" runat = "server"  Text = "Select Management :-" ></asp:Label>  <asp:Label id = "Label5" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>
                                </td>
                                
                                <td style="height: 35px" >
                                        <asp:DropDownList ID = "ddmanagement" runat = "server" Width = "200px"></asp:DropDownList>
                                </td>
                            </tr>
                                         
                            
                              <tr>
                                <td style="height: 35px;" align="center" colspan="3">
                                
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" Height="36px" />
                                
                                        <asp:Button ID = "btnupdate" runat = "server"  Text = "Update" 
                                        Width="120px" onclick="btnupdate_Click"  ></asp:Button>  
                                
                                </td>
                            
                            </tr>                            
                        </table> 
                        
                </td>
            </tr>
        </table>


</asp:Content>


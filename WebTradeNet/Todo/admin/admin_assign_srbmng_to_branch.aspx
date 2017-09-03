<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_assign_srbmng_to_branch.aspx.cs" Inherits="admin_admin_assign_srmng_to_dept" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="adminstyle.css" rel="stylesheet" type="text/css" />
<table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "Assign Sr.Branch Manager To Branch" ID="Label1" Font-Bold="True" 
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
                <td style="width: 200px">                
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
                                        ControlToValidate="ddsrbmng" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px; height: 35px;" >
                                        <asp:Label ID = "Label2" runat = "server"  Text = "Select Sr.Branch Manager :- " ></asp:Label> <asp:Label id = "Label3" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>   
                                </td>
                                
                                <td style="height: 35px; height: 35px;" >
                                        <asp:DropDownList ID = "ddsrbmng" runat = "server" Width = "200px" 
                                            AutoPostBack="True" ></asp:DropDownList>
                                </td>
                            </tr>
                        
                        
                            <tr>
                                <td style="width: 188px; height: 35px;">
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        Display="None" ErrorMessage="Please enter Branch Name" 
                                        ControlToValidate="ddbranch" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px; height: 35px;" >
                                        <asp:Label ID = "lblusertype" runat = "server"  Text = "Select Branch :- " ></asp:Label> <asp:Label id = "star1" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>   
                                </td>
                                
                                <td style="height: 35px; height: 35px;" >
                                        <asp:DropDownList ID = "ddbranch" runat = "server" Width = "200px" 
                                            AutoPostBack="True" ></asp:DropDownList>
                                </td>
                            </tr>
                              <tr>
                                <td style="height: 35px;" align="center" colspan="3">
                                
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" Height="36px" />
                                
                                        <asp:Button ID = "btnassign" runat = "server"  Text = "Assign" 
                                        Width="120px" onclick="btnassign_Click"  ></asp:Button>  
                                
                                </td>
                            
                            </tr>                            
                        </table> 
                        
                </td>
            </tr>
        </table>
</asp:Content>


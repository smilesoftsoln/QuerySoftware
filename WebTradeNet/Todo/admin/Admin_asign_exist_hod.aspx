<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="Admin_asign_exist_hod.aspx.cs" Inherits="admin_Admin_asign_exist_hod" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "Assign Existing HOD" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>                
                <td style="width: 200px"> </td>               
                <td style="width: 200px"> </td>                                  
            </tr>
            
             <tr>                
                <td style="width: 200px"></td>
                <td style="width: 200px"></td>
            </tr>            
            <tr>                
                <td style="width: 200px"> </td>               
                <td style="width: 200px"> </td>          
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
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        Display="None" ErrorMessage="Please Select Department" 
                                        ControlToValidate="ddselectdept" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px; height: 35px;" >
                                        <asp:Label ID = "lblusertype" runat = "server"  Text = "For Department:- " ></asp:Label> <asp:Label id = "star1" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>   
                                </td>
                                
                                <td style="height: 35px; height: 35px;" >
                                        
                                        <asp:DropDownList ID="ddselectdept" runat="server" Width="200px" 
                                            AutoPostBack="True"></asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 188px;height: 35px;"  >
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="ddselecthod" Display="None" 
                                        ErrorMessage="Please Select HOD" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;"  >
                                        <asp:Label ID = "Label7" runat = "server"  Text = "Select HOD:-" ></asp:Label>  <asp:Label id = "star2" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>
                                </td>
                                
                                <td style="height: 35px" >
                                        <asp:DropDownList ID="ddselecthod" runat="server" Width="200px" 
                                            AutoPostBack="True" CausesValidation="false"></asp:DropDownList>
                                </td>
                            </tr>
                            
                                         
                            
                              <tr>
                                <td style="height: 35px;" align="center" colspan="3">
                                
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" />
                                
                                        <asp:Button ID = "btnsave" runat = "server"  Text = "Save" 
                                        Width="120px" onclick="btnsave_Click" CausesValidation="false" ></asp:Button>  
                                
                                </td>
                            
                            </tr>                            
                        </table> 
                        
                </td>
            </tr>
        </table>

</asp:Content>


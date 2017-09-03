<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_create_department.aspx.cs" Inherits="admin_admin_create_department" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "Create Department" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>                
                <td style="width: 200px">                
                <td style="width: 200px">                                   
            </tr>
            
             <tr>                
                <td style="width: 200px">
                <td style="width: 200px">
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
                                
                                    
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtdept" Display="None" 
                                        ErrorMessage="Please Enter Department Name" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                                    
                                
                                </td>
                            
                                <td style="width: 170px; height: 35px;" >
                                        <asp:Label ID = "lbldept" runat = "server"  Text = "Department Name :- " ></asp:Label> <asp:Label id = "star1" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>   
                                </td>
                                
                                <td style="height: 35px; height: 35px;" >
                                        <asp:TextBox ID = "txtdept" runat = "server" Width = "200px" ></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 188px;height: 35px;"  >                               
                                   
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtdescription" Display="None" 
                                        ErrorMessage="Please Enter Description " SetFocusOnError="True"></asp:RequiredFieldValidator>
                                   
                                
                                </td>
                            
                                <td style="width: 170px;height: 35px;"  >
                                        <asp:Label ID = "Label7" runat = "server"  Text = "Description :-" ></asp:Label>  <asp:Label id = "star2" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>
                                </td>
                                
                                <td style="height: 35px" >
                                        <asp:TextBox ID = "txtdescription" runat = "server" Width = "200px" 
                                            TextMode="MultiLine" ></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="height: 35px">
                                        
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="ddselectmngmnt" Display="None" 
                                        ErrorMessage="Please Select Management"></asp:RequiredFieldValidator>
                                        
                                </td>
                                
                                <td style="height: 35px">                                                                              
                                     <asp:Label ID = "Label2" runat = "server"  Text = "Select Management :-" ></asp:Label>
                                &nbsp;<asp:Label id = "star3" runat = "server" Text = " *" ForeColor = "Red"></asp:Label>
                                </td>
                                
                                 <td style="height: 35px">
                                   <asp:DropDownList ID = "ddselectmngmnt" runat = "server" Width = "200px" 
                                         AutoPostBack="True" ></asp:DropDownList>
                                </td>
                            </tr>
                            
                                         
                            
                              <tr>
                                <td style="height: 35px;" align="center" colspan="3">
                                
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        DisplayMode="List" ShowMessageBox="True" ShowSummary="False" />
                                
                                    <asp:Button ID ="btnsave" runat="server" Text="Save" Width="120px" 
                                        onclick="btnsave_Click" ></asp:Button >
                                                             
                                </td>
                            
                            </tr>                            
                        </table> 
                        
                </td>
            </tr>
        </table>


</asp:Content>


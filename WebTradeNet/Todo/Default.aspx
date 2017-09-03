<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style3
        {
            height: 33px;
        }
        .style4
        {
            height: 32px;
        }
        .style5
        {
            height: 20px;
        }
        .style6
        {
            height: 48px;
        }
        .style7
        {
            width: 47%;
        }
        .style8
        {
            height: 48px;
            width: 47%;
        }
        .style9
        {
            height: 20px;
            width: 47%;
        }
        .style10
        {
            height: 32px;
            width: 47%;
        }
        .style11
        {
            height: 33px;
            width: 47%;
        }
        .style12
        {
            height: 100px;
        }
        .style13
        {
            height: 61px;
        }
    </style>
</head>
<body bgcolor="#ecdccc">
    <form id="form1" runat="server">
        
    
    
       <div width = "100%">
        <table width = "100%">
        <tr align ="center">
            <td>
                <asp:Image ID = "imghead" runat = "server" ImageUrl="~/images/todo.png" />
            </td>
        </tr> 
            
        </table>
       
       </div>
    
        <div>
            <table width = "100%">
                <tr>
                    <td class="style12">
                    
                    </td>
                </tr>
                
                <tr>
                    <td>
                    <div style="background-position: center center; background-image: url('images/loginpanel.jpg'); background-repeat: no-repeat; height: 204px; background-attachment: scroll;">
                        <table width = "100%">
                            <tr>
                                <td class="style7">
                                
                                </td>
                                <td width = "55%">
                                
                                </td>                                
                            </tr>
                            
                            <tr>
                                <td class="style8">
                                
                                </td>
                                <td width = "55%" class="style6">
                                
                                </td>                                
                            </tr>
                            
                            <tr>
                                <td class="style9">
                                
                                </td>
                                <td width = "55%" class="style5">
                                
                                </td>                                
                            </tr>
                            
                            <tr>
                                <td class="style10">
                                
                                </td>
                                <td width = "55%" class="style4">
                                
                                    <asp:TextBox ID="txtloginid" runat="server" Width="250px" 
                                        ontextchanged="txtloginid_TextChanged"></asp:TextBox>
                                
                                </td>                                
                            </tr>
                            
                            <tr>
                                <td class="style11">
                                
                                </td>
                                <td width = "55%" class="style3">
                                
                                    <asp:TextBox ID="txtpassword" runat="server" Width="250px" TextMode ="Password" ></asp:TextBox>
                                
                                </td>                                
                            </tr>
                            
                              <tr >
                                <td width = "30%" align="right" class="style13" >
                                    <asp:Button ID = "btnsubmit" runat = "server" text = "Submit" Height="35px" 
                                        Width="153px" onclick="btnsubmit_Click" Font-Bold="False" 
                                        Font-Names="Microsoft Sans Serif" ToolTip="Click Here To Login" />
                                </td>
                                <td width = "70%" class="style13">
                                
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                      <asp:Button ID = "btnclear" runat = "server" text = "Clear" Height="35px" 
                                        Width="153px" Font-Bold="False" Font-Names="Microsoft Sans Serif" 
                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                        ToolTip="Click Here To Clear the Fields" />
                                
                                
                                </td>                                
                            </tr>
                            
                            
                            
                            
                        </table> 
                    </div>
                    </td>
                </tr>
            </table> 
        </div>
        
    
   

    
       <%-- <table width = "100%" style="height:500px">
                        
            <tr align ="center">
                <td width = "30%">
                
                </td>
                
                <td >
                
                <div style="background-image: url('images/loginpanel.jpg'); height: 200px; width: 600px;">
                        <asp:TextBox ID = "txtloginid" runat = "server" Text = "" Width = "100px" ></asp:TextBox>
                    
                </div>
                </td>           
                
                <td width = "30%"> 
                    
                </td>
            </tr>
            
            </table>
    --%>
  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtloginid" EnableTheming="True" 
                ErrorMessage="Please enter loginid" ForeColor="#ECDCCC" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtpassword" Display="Dynamic" 
                ErrorMessage="Please enter password" ForeColor="#ECDCCC" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ShowMessageBox="True" ShowSummary="False" />
  
    </form>
</body>
</html>

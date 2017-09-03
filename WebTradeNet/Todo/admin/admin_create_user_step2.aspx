<%@ Page Language="C#" MasterPageFile="~/todo/admin/master_admin.master" AutoEventWireup="true" CodeFile="admin_create_user_step2.aspx.cs" Inherits="admin_admin_create_user_step2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
    <table width="100%">
        <tr>
            <td style="width: 380px; height: 37px;">
            <asp:Label ID="lbladdnewuser" runat="server" Text="Add New User" Font-Bold="True" 
                    Font-Names="Arial Black" Font-Size="X-Large" ForeColor="Maroon"></asp:Label>
            
            </td>            
        </tr>
        
        <tr>
            <td style="width: 380px">
               <asp:Label ID="Label1" runat="server" 
                    Text="Please Select a Department For User:-" Font-Bold="True"></asp:Label>
            </td> 
                      
        </tr>
                <tr>
                    <td style="width: 380px">
                         <br />                                                               
                    </td>
                </tr>        
        
        <tr>
            <td align="right" style="width: 380px">
               <asp:Label ID="Label2" runat="server" Text="Select Department:-"></asp:Label>
            </td>
            
            <td align="left">
               <asp:DropDownList ID="dddepartmetnt" runat="server" Width="150px" ></asp:DropDownList>   
            </td>
        </tr>
        
                <tr>
                    <td style="width: 380px">
                         <br />                                                               
                    </td>
                </tr>     
        
        <tr>
        
            <td align="center"colspan="2">           
                <asp:Button ID="btncomplete" runat="server" Text="Compelete" Width="100px" 
                    onclick="btncomplete_Click"></asp:Button >       
            </td>
        </tr> 
        
        
                  <tr>
                    <td style="width: 380px">
                         <br />                                                               
                    </td>
                </tr>            
        
    </table>

</div>
</asp:Content>


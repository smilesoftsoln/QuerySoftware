<%@ Page Language="VB" MasterPageFile="~/admin_controls_master.master" AutoEventWireup="false" CodeFile="view_all_users.aspx.vb" Inherits="view_all_users" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4>All Users</h4>
<hr />
    <!-- <table class="tbl_gw">
            <tr class="tbl_gw_spl">
                <td style="width:10%">
                    LoginerID
                </td>
                <td style="width:40%">
                    UserName
                </td>
                <td style="width:40%">
                    Name 
                </td>
                <td style="width:10%" >
                    Type Of Emp.
                </td>
            </tr>
     </table>         
<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1"  DataKeyField="id"  Width="100%">          
             <ItemTemplate>
               <table class="tbl_gw">
            <tr>
                <td style="width:10%">
                     <%#Eval("id")%>
                </td>
                <td style="width:40%">
                     <%#Eval("username_")%>
                </td>
                <td style="width:40%">
                    <%#Eval("display_name")%>
                </td>
                <td style="width:10%">
                     <%#Eval("who_is")%>
                </td>
                
            </tr>
     </table>  
</ItemTemplate>
              
</asp:DataList>-->
<div id="Disp_users" runat="server"></div>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:sri_sri_projecterConnectionString %>" 
    SelectCommand="select * from tbl_loginers_master">
</asp:SqlDataSource>
</asp:Content>


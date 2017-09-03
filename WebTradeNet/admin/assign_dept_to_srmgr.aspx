<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/admin/admin_Pnl.master" CodeFile="assign_dept_to_srmgr.aspx.vb" Inherits="admin_assign_dept_to_srmgr" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

                <h2 class="style1">
                    Assign Dept to Sr Mgr<br />
                    <br />
                    <br />
    <table style="margin-left:auto;margin-right:auto;text-align:left;" 
        __designer:mapid="d">
        <tr>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-style: normal; color: #000000">
                Select Dept : 
            </td>
            <td>                
                <asp:DropDownList ID="ddl_dept" runat="server" 
                    class="validate[required],length[0,100]]" name="developername" 
                    DataSourceID="SqlDataSource1" DataTextField="dept_name" 
                    DataValueField="id" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
                    SelectCommand="SELECT [id], [dept_name] FROM [tbl_dept_master]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-style: normal; color: #000000">
                Select Sr Mgr: 
            </td>
            <td>                
                <asp:DropDownList ID="ddl_srmgr" runat="server" 
                    class="validate[required],length[0,100]]" name="developername" 
                    DataSourceID="SqlDataSource2" DataTextField="name_" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
                    SelectCommand="SELECT [id], [name_] FROM [tbl_loginer_master] WHERE ([post_] = @post_)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="SRMNG" Name="post_" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_submit" runat="server" Text="Assign" Width="100%" />
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_status" runat="server"></asp:Label>
    </h2>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            height: 754px;
        }
    </style>

</asp:Content>

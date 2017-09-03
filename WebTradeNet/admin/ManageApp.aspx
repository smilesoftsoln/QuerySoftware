<%@ Page Language="VB" MasterPageFile="admin_Pnl.master" AutoEventWireup="false" CodeFile="ManageApp.aspx.vb" Inherits="admin_ManageApp" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Map Application Link</h2>
[BE : Branch Employee ][ BH: Branch Head ][ DE : Department Employee ][ HOD: Head Of Department ] 
<asp:ListView ID="ListView1" runat="server" DataSourceID="SoftDataSource1" 
        DataKeyNames="SoftwareId" InsertItemPosition="LastItem">
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                    Text="Delete" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
            <td>
                <asp:Label ID="SoftwareIdLabel" runat="server" 
                    Text='<%# Eval("SoftwareId") %>' />
            </td>
            <td>
                <asp:Label ID="Software_NameLabel" runat="server" 
                    Text='<%# Eval("Software_Name") %>' />
            </td>
            <td>
                <asp:Label ID="UseRoleLabel" runat="server" Text='<%# Eval("UseRole") %>' />
            </td>
            <td>
                <asp:Label ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                    Text="Delete" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
            <td>
                <asp:Label ID="SoftwareIdLabel" runat="server" 
                    Text='<%# Eval("SoftwareId") %>' />
            </td>
            <td>
                <asp:Label ID="Software_NameLabel" runat="server" 
                    Text='<%# Eval("Software_Name") %>' />
            </td>
            <td>
                <asp:Label ID="UseRoleLabel" runat="server" Text='<%# Eval("UseRole") %>' />
            </td>
            <td>
                <asp:Label ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="">
            <tr>
                <td>
                    No data was returned.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                    Text="Insert" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Clear" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="Software_NameTextBox" runat="server" 
                    Text='<%# Bind("Software_Name") %>' />
            </td>
            <td>
                <asp:TextBox ID="UseRoleTextBox" runat="server" Text='<%# Bind("UseRole") %>' />
            </td>
            <td>
                <asp:TextBox ID="LinkTextBox" runat="server" Text='<%# Bind("Link") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                        <tr runat="server" style="">
                            <th runat="server">
                            </th>
                            <th runat="server">
                                SoftwareId</th>
                            <th runat="server">
                                Software_Name</th>
                            <th runat="server">
                                UseRole</th>
                            <th runat="server">
                                Link</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style="">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                ShowLastPageButton="True" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <EditItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancel" />
            </td>
            <td>
                <asp:Label ID="SoftwareIdLabel1" runat="server" 
                    Text='<%# Eval("SoftwareId") %>' />
            </td>
            <td>
                <asp:TextBox ID="Software_NameTextBox" runat="server" 
                    Text='<%# Bind("Software_Name") %>' />
            </td>
            <td>
                <asp:TextBox ID="UseRoleTextBox" runat="server" Text='<%# Bind("UseRole") %>' />
            </td>
            <td>
                <asp:TextBox ID="LinkTextBox" runat="server" Text='<%# Bind("Link") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <SelectedItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                    Text="Delete" />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
            <td>
                <asp:Label ID="SoftwareIdLabel" runat="server" 
                    Text='<%# Eval("SoftwareId") %>' />
            </td>
            <td>
                <asp:Label ID="Software_NameLabel" runat="server" 
                    Text='<%# Eval("Software_Name") %>' />
            </td>
            <td>
                <asp:Label ID="UseRoleLabel" runat="server" Text='<%# Eval("UseRole") %>' />
            </td>
            <td>
                <asp:Label ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>
<asp:SqlDataSource ID="SoftDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString2 %>" 
    DeleteCommand="DELETE FROM [Software Suite] WHERE [SoftwareId] = @SoftwareId" 
    InsertCommand="INSERT INTO [Software Suite] ([Software_Name], [UseRole], [Link]) VALUES (@Software_Name, @UseRole, @Link)" 
    SelectCommand="SELECT * FROM [Software Suite]" 
    UpdateCommand="UPDATE [Software Suite] SET [Software_Name] = @Software_Name, [UseRole] = @UseRole, [Link] = @Link WHERE [SoftwareId] = @SoftwareId">
    <DeleteParameters>
        <asp:Parameter Name="SoftwareId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="Software_Name" Type="String" />
        <asp:Parameter Name="UseRole" Type="String" />
        <asp:Parameter Name="Link" Type="String" />
        <asp:Parameter Name="SoftwareId" Type="Int32" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="Software_Name" Type="String" />
        <asp:Parameter Name="UseRole" Type="String" />
        <asp:Parameter Name="Link" Type="String" />
    </InsertParameters>
</asp:SqlDataSource>
<hr />

</asp:Content>


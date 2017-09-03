<%@ Page Language="VB" MasterPageFile="admin_Pnl.master" AutoEventWireup="false" CodeFile="Backup_Restore.aspx.vb" Inherits="admin_Backup_Restore" %>
<%@ Register namespace="JavaScriptControls" tagprefix="cc1" %>

                
<%--<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">--%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
<asp:Panel ID="Panel1" runat="server" CssClass="style1">
        <asp:RadioButtonList ID="rdb_1" runat="server" AutoPostBack="True">
            <asp:ListItem>BackUp Database</asp:ListItem>
        </asp:RadioButtonList><br />
        <asp:Panel ID="pnl_backup" runat="server" Visible="false">
            <fieldset style="width:514px;">
                 <legend>
			        Take Backup Now :
		        </legend>
		        <%--<asp:Button ID="btn_backup" runat="server" Text="Take Backup" Width="514px" Font-Bold="True" Font-Italic="False" Height="41px" />--%>
		        <div>
    <%--<cc1:pleasewaitbutton id="PleaseWaitButton1" runat="server" PleaseWaitImage="images/pleaseWait.gif" Text="Click Me." PleaseWaitType="ImageThenText" PleaseWaitText="<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Backing Up  : Please Wait... </b>" Width="514px" Font-Bold="True" Font-Italic="False" Height="41px"></cc1:pleasewaitbutton>--%>
    </div>
            </fieldset></asp:Panel>
        
        <asp:Panel ID="pnl_restore" runat="server" Visible="false">
             <fieldset style="width:514px;">
                 <legend>
			        Restore Database :
		        </legend>
		        <%--<asp:Button ID="btn_backup" runat="server" Text="Take Backup" Width="514px" Font-Bold="True" Font-Italic="False" Height="41px" />--%>
		        <b>Last Backup Date : <asp:Label ID="lbl_last_bk_date" runat="server" Text=""></asp:Label></b><br />
                 <asp:Panel ID="pnl_sure" runat="server">
                  <asp:CheckBox ID="cho_ok" runat="server" /> I am sure to Restore Database .<br />
                 </asp:Panel>
                 
		        <div>
    <%--<cc1:pleasewaitbutton id="PleaseWaitButton2" runat="server" PleaseWaitImage="images/pleaseWait.gif" Text="Click Me." PleaseWaitType="ImageThenText" PleaseWaitText="<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Restoring Database  : Please Wait... </b>" Width="514px" Font-Bold="True" Font-Italic="False" Height="41px"></cc1:pleasewaitbutton>--%>
    </div>
            </fieldset></asp:Panel>
    </asp:Panel>



    </asp:Content>


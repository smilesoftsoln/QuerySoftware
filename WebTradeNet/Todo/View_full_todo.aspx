<%@ Page Language="VB" AutoEventWireup="false" CodeFile="View_full_todo.aspx.vb" Inherits="Default3" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="layOut.css" type="text/css" rel="stylesheet"  />
    <style type="text/css">
        .style5
        {
            width: 111%;
        }
        .style7
        {
            width: 475px;
            height: 50px;
        }
        .style8
        {
            height: 50px;
        }
        .style9
        {
            width: 422px;
            height: 23px;
            background-image: url('images/task_pan_top.png');
            background-repeat: no-repeat;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
            color: #5F5F5F;
            font-weight: bold;
            padding-top: 10px;
            padding-left: 40px;
        }
        .style10
        {
            width: 462px;
            height: 344px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="page">
		<div class="top">
			<div class="top_left">
					<div class="top_img">
						<a href="#">
							<img src="images/top.jpg"  />
						</a>
					</div>
			</div>
			<div class="top_right">
				<div class="top_right_user_info">
				
				    <span lang="en-us">Welcome </span>
                    <asp:Label ID="lbl_name" runat="server" Text="Label"></asp:Label>
                    <span lang="en-us">&nbsp;</span><asp:Label ID="lbl_id" runat="server" Text="84"></asp:Label>
				
				</div>
			</div>	
		</div>
		<div class="nav">
			<div class="nav_left">
				&nbsp;<asp:Label ID="lbl_date" runat="server" Text="Label"></asp:Label>
			</div>
			<div class="nav_rigth">
				<asp:LinkButton ID="lnkbtn_Home" runat="server" 
                    PostBackUrl="~/Todo/login_Next.aspx">Home</asp:LinkButton>
&nbsp;<a href="#">About Us</a>
				<a href="#">My Account</a>
				<a href="#">Settings</a>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Log 
                out</asp:LinkButton>
&nbsp;</div>
			</div>
			</div>
    <table class="style5">
        <tr>
            <td class="style7">
            <div class="style9" style="border: thin solid #C0C0C0">
					Tasks
				<asp:Label ID="lbl_id0" runat="server" Text="1" Visible="False"></asp:Label>
				
				    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:tn_CAREE_bitaConnectionString %>" 
                        SelectCommand="SELECT [desc] FROM [tbl_tasks] WHERE ([id] = @id)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lbl_id" DefaultValue="1" Name="id" 
                                PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
				</div>
                <div class="style10" align=right style="border: thin solid #C0C0C0">
                <FTB:FreeTextBox id="txt_desc"  
			                                Focus="true"
			                                SupportFolder="aspnet_client/"
			                                JavaScriptLocation="ExternalFile" 
			                                ButtonImagesLocation="ExternalFile"
			                                ToolbarImagesLocation="ExternalFile"
			                                ToolbarStyleConfiguration="Office2000"			
			                                toolbarlayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,Delete,InsertTable;"
			                                runat="Server"
			                                GutterBackColor="red" AllowHtmlMode="False" ButtonSet="Office2000" 
                                        SslUrl="/" ToolbarBackColor="SkyBlue" AutoParseStyles="True" 
                                                ButtonDownImage="False" Width="75%" 
                EnableHtmlMode="False" HtmlModeDefaultsToMonoSpaceFont="False" 
                BreakMode="LineBreak" Height="200px" ReadOnly="True"		 
			                                />
			</div>
			</td>
            <td class="style8">
                </td>
        </tr>
        </table>
    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:Button ID="Btn_complete" runat="server" BackColor="#006600" 
        Font-Bold="True" ForeColor="White" Height="25px" Text="Complete" 
        Width="104px" />
    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;</span><asp:Button ID="Btn_incomplete" runat="server" BackColor="Red" Font-Bold="True" 
        ForeColor="White" Text="Incomplete" Width="104px" />
        <span lang="en-us">&nbsp;</span><br />
    <br />
    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:Label ID="Lbl_Remark" runat="server" ForeColor="#37408E" Text="Remark"></asp:Label>
    <br />
    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:TextBox ID="Txt_remark" runat="server" Height="53px" TextMode="MultiLine" 
        Width="171px"></asp:TextBox>
    <br />
    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:Button ID="Btn_Submit" runat="server" Text="Submit" />
			</div>
			<p>
                <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </span>
                <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
			</form>
</body>
</html>

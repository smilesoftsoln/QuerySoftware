<%@ Page Language="C#" MasterPageFile="~/todo/view_todo_panel.master" AutoEventWireup="true" CodeFile="View_login_information.aspx.cs" Inherits="View_login_information" Title="Untitled Page" %>
<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width = "100%">
        <tr>
             <td align = "center">
                 <asp:Label ID="Label4" runat="server" Text="View Login Information" 
                     Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>   
            <td align = "right">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    onclick="LinkButton1_Click">| HOME |</asp:LinkButton>
            </td>    
        </tr>
        <tr>
            <td colspan="2">
                <table width = "100%">
                    <tr>
                        <td width = "30%" >
                            
                        </td>
                        <td width = "20%" >
                            <asp:Label ID="Label1" runat="server" Text="Select Post"></asp:Label>
                        </td>
                        <td width = "50%" >
                            <asp:DropDownList ID="dduserlist" runat="server" Height="22px" Width="250px" 
                                   AutoPostBack="True" 
                                   onselectedindexchanged="dduserlist_SelectedIndexChanged">
                             </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td width = "30%" >
                            
                        </td>
                        <td width = "20%" >
                            <asp:Label ID="lblcaption" runat="server" Text="Select "></asp:Label>
                        </td>
                        <td width = "50%" >
                                       
                               <asp:DropDownList ID="dd_all_list" runat="server" Height="22px" Width="250px" 
                                   AutoPostBack="True" 
                                   onselectedindexchanged="dd_all_list_SelectedIndexChanged">
                               </asp:DropDownList>                          
           
                        </td>
                    </tr>
                    
                    <tr>
                        <td width = "30%" >
                            
                        </td>
                        <td width = "20%" >
                               <asp:Label ID="Label3" runat="server" Text="Select Employee"></asp:Label>
                        </td>
                        <td width = "50%" >                                           
                           <asp:DropDownList ID="ddemplist" runat="server" Height="22px" Width="250px" 
                               AutoPostBack="True" 
                               onselectedindexchanged="ddemplist_SelectedIndexChanged">
                           </asp:DropDownList>           
           
                        </td>
                    </tr>
                    
                     <tr>
                        <td width = "30%" >
                            
                        </td>
                        <td width = "20%" >
                            
                            <asp:Label ID="Label2" runat="server" Text="From" ForeColor="#CC0000"></asp:Label>
               <eo:DatePicker ID="dtfrom" runat="server" DisabledDates="" 
                   SelectedDates="" ControlSkinID="None" DayCellHeight="15" DayCellWidth="31" 
                   DayHeaderFormat="Short" OtherMonthDayVisible="True" PickerFormat="dd/MM/yyyy" 
                   TitleFormat="MMMM, yyyy" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" 
                   TitleRightArrowImageUrl="DefaultSubMenuIcon" VisibleDate="2012-03-01" 
                   MinValidDate="2012-01-01" MonthGridLineColor="Aqua">
                   <TodayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040401');color:#1176db;" />
                   <SelectedDayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040403');color:Brown;" />
                   <DisabledDayStyle CssText="font-family:Verdana;font-size:8pt;color: gray" />
                   <FooterTemplate>
                       <table border="0" cellPadding="0" cellspacing="5" 
                           style="font-size: 11px; font-family: Verdana">
                           <tr>
                               <td width="30">
                               </td>
                               <td valign="center">
                                   <img src="{img:00040401}"></img></td>
                               <td valign="center">
                                   Today: {var:today:MM/dd/yyyy}</td>
                           </tr>
                       </table>
                   </FooterTemplate>
                   <MonthSelectorStyle CssText="" />
                   <PickerStyle CssText="" />
                   <CalendarStyle CssText="background-color:#ffffe1;border-bottom-color:Silver;border-bottom-style:double;border-bottom-width:1px;border-left-color:Silver;border-left-style:double;border-left-width:1px;border-right-color:Silver;border-right-style:double;border-right-width:1px;border-top-color:Silver;border-top-style:double;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" />
                   <TitleArrowStyle CssText="cursor: hand" />
                   <DayHoverStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040402');color:#1c7cdc;" />
                   <MonthStyle CssText="cursor:hand;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;" />
                   <TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" />
                   <WeekendDayHoverStyle CssText="background-color:red;border-bottom-color:#ffffcc;border-left-color:#ffffcc;border-right-color:#ffffcc;border-top-color:#ffffcc;" />
                   <DayHeaderStyle CssText="font-family:Verdana;font-size:8pt;border-bottom: #f5f5f5 1px solid" />
                   <DayStyle CssText="font-family:Verdana;font-size:8pt;" />
               </eo:DatePicker>
                            
                        </td>
                        <td width = "50%" >
                        
                            <asp:Label ID="Label5" runat="server" Text="To" ForeColor="#CC0000"></asp:Label>
                         <eo:DatePicker ID="dtto" runat="server" DisabledDates="" 
                   SelectedDates="" ControlSkinID="None" DayCellHeight="15" DayCellWidth="31" 
                   DayHeaderFormat="Short" OtherMonthDayVisible="True" PickerFormat="dd/MM/yyyy" 
                   TitleFormat="MMMM, yyyy" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" 
                   TitleRightArrowImageUrl="DefaultSubMenuIcon" VisibleDate="2012-03-01" 
                   MinValidDate="2012-01-01" MonthGridLineColor="Aqua">
                   <TodayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040401');color:#1176db;" />
                   <SelectedDayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040403');color:Brown;" />
                   <DisabledDayStyle CssText="font-family:Verdana;font-size:8pt;color: gray" />
                   <FooterTemplate>
                       <table border="0" cellPadding="0" cellspacing="5" 
                           style="font-size: 11px; font-family: Verdana">
                           <tr>
                               <td width="30">
                               </td>
                               <td valign="center">
                                   <img src="{img:00040401}"></img></td>
                               <td valign="center">
                                   Today: {var:today:MM/dd/yyyy}</td>
                           </tr>
                       </table>
                   </FooterTemplate>
                   <MonthSelectorStyle CssText="" />
                   <PickerStyle CssText="" />
                   <CalendarStyle CssText="background-color:#ffffe1;border-bottom-color:Silver;border-bottom-style:double;border-bottom-width:1px;border-left-color:Silver;border-left-style:double;border-left-width:1px;border-right-color:Silver;border-right-style:double;border-right-width:1px;border-top-color:Silver;border-top-style:double;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" />
                   <TitleArrowStyle CssText="cursor: hand" />
                   <DayHoverStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040402');color:#1c7cdc;" />
                   <MonthStyle CssText="cursor:hand;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;" />
                   <TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" />
                   <WeekendDayHoverStyle CssText="background-color:red;border-bottom-color:#ffffcc;border-left-color:#ffffcc;border-right-color:#ffffcc;border-top-color:#ffffcc;" />
                   <DayHeaderStyle CssText="font-family:Verdana;font-size:8pt;border-bottom: #f5f5f5 1px solid" />
                   <DayStyle CssText="font-family:Verdana;font-size:8pt;" />
               </eo:DatePicker>
                         </td>
                    </tr>
                    
                    <tr>
                        <td width = "30%" >
                            
                        </td>
                        <td width = "20%" >
                            
                        </td>
                        <td width = "50%" >
                            <asp:Button ID="btnview" runat="server" Text="View" Width="129px" 
                                onclick="btnview_Click" style="height: 26px" />  
                        </td>
                    </tr>
                    
                </table>
            
            </td>  
        </tr>
    </table>
    <div id ="view_login_info" runat ="server" align="center">
    
    </div>
</asp:Content>


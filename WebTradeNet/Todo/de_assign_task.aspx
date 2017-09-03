<%@ Page Language="C#" MasterPageFile="~/todo/dept.master" AutoEventWireup="true" CodeFile="de_assign_task.aspx.cs" Inherits="Admin_Assign_todo" Title="Untitled Page" ValidateRequest="false" %>
<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<script runat="server">
        
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="aspnet_client/FTB-FreeTextBox.js" type="text/javascript"></script>

 

    <table width= "100%">       
        
         <tr style="height:40px">
        
           <td width = "20%" >
            
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                   ControlToValidate="DatePicker1" ErrorMessage="Please Select End Date" 
                   Enabled="False"></asp:RequiredFieldValidator>
            
           </td> 
           
           <td width = "20%" >
                
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select End Date :-"></asp:Label>
                
           </td> 
           
           <td width = "60%" >
               <eo:DatePicker ID="DatePicker1" runat="server" DisabledDates="" 
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
       
      
        
        <tr style="height:40px">
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select End Time :-"></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:DropDownList ID="ddhourlist" runat="server" Height="22px" Width="43px">
               </asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddminlist" runat="server" Height="22px" Width="42px">
               </asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddampmlist" runat="server" Height="22px" Width="66px">
               </asp:DropDownList>
           
           </td> 
        </tr>   
        
       
        
        
        <tr>
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select User :- "></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:DropDownList ID="dduserlist" runat="server" Height="22px" Width="137px" 
                   AutoPostBack="True" 
                   onselectedindexchanged="dduserlist_SelectedIndexChanged">
               </asp:DropDownList>
           
           &nbsp;
                
               <asp:Label ID="lblcaption" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Branch :- "></asp:Label>
                
           &nbsp;
           
               <asp:DropDownList ID="dd_all_list" runat="server" Height="22px" Width="137px" 
                   AutoPostBack="True" 
                   onselectedindexchanged="dd_all_list_SelectedIndexChanged">
               </asp:DropDownList>
           
           </td> 
        </tr>        
       
        
         <tr style="height:40px">
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Select Employee :-"></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:DropDownList ID="ddemplist" runat="server" Height="22px" Width="250px" 
                   AutoPostBack="True">
               </asp:DropDownList>
           
           </td>          
        </tr>
        
         <tr style="height:40px">
        
           <td width = "20%">
            
           </td> 
           
           <td width = "20%">
                
               <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Priority :-"></asp:Label>
                
           </td> 
           
           <td width = "60%">
           
               <asp:RadioButton ID="chknormal" runat="server" Text="Normal" 
                   GroupName="priority" Checked="True" />
&nbsp;&nbsp;
               <asp:RadioButton ID="chkhigh" runat="server" Text="High" GroupName="priority" 
                   />
           
           </td>      
        </tr>
        
        
       <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%">                
               <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Type :-"></asp:Label>                
           </td> 
           
           <td width = "60%">           
               <asp:DropDownList ID="ddtodotype" runat="server" Height="22px" Width="137px" 
                   AutoPostBack="True" 
                   onselectedindexchanged="ddtodotype_SelectedIndexChanged">
                   <asp:ListItem Value="1">Daily</asp:ListItem>
                   <asp:ListItem Value="2">Weekly</asp:ListItem>
                   <asp:ListItem Value="3">Monthly</asp:ListItem>
               </asp:DropDownList>           
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           
               <asp:DropDownList ID="ddselectday" runat="server" Height="22px" Width="137px" 
                    Visible="False" 
                   AutoPostBack="True">
                  
               </asp:DropDownList>           
           </td>          
        </tr>

        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%">                
               <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Subject :-"></asp:Label>                
           </td> 
           
           <td width = "60%">           
               <asp:TextBox ID="txtsubject" runat="server" Width="381px"></asp:TextBox>
           </td>          
        </tr>
        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%" valign="top">                
               <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" 
                   Font-Size="Small" Text="Description :-"></asp:Label>                
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          </td> 
           
                    <td width = "60%">
                       <asp:TextBox ID="FreeTextBox1" runat="server" Height="150px" 
                              >
                       </asp:TextBox>
                    </td>           
                     
        </tr>          
        
         <tr style="height:40px">        
           <td width = "20%">            
           </td> 
           
           <td width = "20%">                
               &nbsp;</td> 
           
           <td width = "60%" align="left" id="txt_desc">                    
              <asp:Button ID ="btnsubmit" runat="server" Text="Submit" Width="147px" 
                   onclick="btnsubmit_Click" style="height: 26px" ></asp:Button>           
             </td>          
        </tr>            
        
    </table>
    
   <%-- <table width="100%">
    <tr>
        <td>
            <asp:Calendar ID="clddate" runat="server" ></asp:Calendar>
        </td>
        
        <td>
            
        </td>        
     
    </tr>
</table>--%>


</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    </asp:Content>



<%@ Page Language="C#" MasterPageFile="~/todo/mng_master.master" AutoEventWireup="true" CodeFile="mng_view_all_task.aspx.cs" Inherits="be_view_alltodo" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

      var popupWindow = null;
      function Popup(status, url) {
          if (status != 0) {
              if (popup != null) popup.focus();
              else {
                  var popup = open(url, "popups", "width=500,height=500");
                  popupWindow = popup;
              }
          }
          else {
              if (popupWindow != null) {
                  popupWindow.close();
              }
          }
      }
</script>
 <table width = "100%">
            <tr>
                <td rowspan="3" style="width: 307px" align="center">
                    
                        <asp:Label runat = "server" Text = "View Task" ID="Label1" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="#990000" ></asp:Label>
                    
                </td>                
               <%-- <td style="width: 200px">                
                <td style="width: 200px"> 
                <a href="">Add New Dartment</a> 
                </td>
                </td>--%>
            </tr>
            
            <%-- <tr>                
                <td style="width: 200px">
            
                    &nbsp;<td style="width: 200px">
                 <a href="">Edit Dartment</a> 
                 </td>   
                 </td> 
            </tr>            
            <tr>                
                <td style="width: 200px">  </td>              
                <td style="width: 200px">   </td>             
            </tr>            --%>
        </table>
        
        <div id ="view_be_task" runat ="server" align="center">     
           
        </div>
</asp:Content>


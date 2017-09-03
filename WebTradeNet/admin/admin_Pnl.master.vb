Imports System.Data.SqlClient
Partial Class admin_Pnl
    Inherits System.Web.UI.MasterPage
    Dim weldone_con As New projecterNM.projectercon
    Dim commfubcs As New somman_functions_NM.commen_funcs
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Public sepm As Integer = 0
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim stream_fev As String = ""
        command("sp_get_tbl_Favorites_master")
        rdr = cmd.ExecuteReader
        While rdr.Read
            stream_fev &= " <li><a href=""" & rdr("url") & """>" & rdr("title") & "</a></li>"
        End While
        disp_fev.InnerHtml = stream_fev
        Dim strim As String = ""

        Dim i As String '= commfubcs.alerts()
        If i = "0" Then
        Else
            strim &= " <div id=""showimage"" style=""position:absolute;left:20px;bottom:20px;"">"
            strim &= "<table border=""0"" >"
            strim &= "       <tr>"
            strim &= "     <td width=""100%"">"
            strim &= "       <table id=""Table_01""  border=""0"" cellpadding=""0"" cellspacing=""0"">"
            strim &= "              <tr>"
            strim &= "		                <td colspan=""2"" style=""background-image:url('images/Untitled-1_03.gif');width:193px;height:21px;"" class=""alert_heading"">"
            strim &= "<span class=""txt_pan"">     <img src=""images/ico_alpha_Exclamation_16x16.png"" align=""midle""> Alert !</span>"
            strim &= "<span class=""close_btn""><img src=""images/space.gif"" width=""25"" height=""20"" onClick=""hidebox();return false""> <span>"
            strim &= "              </td>"
            strim &= "       </tr>"
            strim &= "        <tr>"
            strim &= "              <td style=""background-image:url('images/Untitled-1_05.jpg');width:49px;height:0px;"">"
            strim &= "            </td>"
            strim &= "          <td style=""background-image:url('images/Untitled-1_06.jpg');width:149px;height:0px;"">"
            strim &= "              </td>"
            strim &= "        </tr>"
            strim &= "        <tr>"
            strim &= "            <td colspan=""2"" style=""background-image:url('images/Untitled-1_07.jpg');width:198px;height:5px;"">"
            strim &= "              </td>"
            strim &= "          </tr>"
            strim &= "      <tr>"
            strim &= "             <td colspan=""2"" style=""background-image:url('images/Untitled-1_08.jpg');width:188px;height:50px;padding:5px;font-familly:arial;"" class=""alert_css_1"">"
            'strim &= 'commfubcs.alerts()
            strim &= "            <input type=""button"" value=""    Hide This    "" style=""float:right;clear:right"" onClick=""hidebox();return false"" />"
            strim &= "              </td>"
            strim &= "         </tr>"
            strim &= "         <tr>"
            strim &= "              <td colspan=""2"" style=""background-image:url('images/Untitled-1_09.gif');width:198px;height:12px;"">"
            strim &= "               </td>"
            strim &= "         </tr>"
            strim &= "        <tr>"
            strim &= "        </tr>"
            strim &= "    </table>"
            strim &= "  </td>"
            strim &= "   </tr>"
            strim &= "   </table>"
            strim &= "  </div>"
        End If
        'Disp_alertbox.InnerHtml = strim
    End Sub
    Protected Sub btn_add_to_fev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_add_to_fev.Click
        Dim this_title As String = Page.Title()
        Dim this_url As String = Request.Url.ToString
        Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">window.open('Add_To_favorites.aspx?title=" & this_title & "&url=" & this_url & "?TradeNetStockBroking.com', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')</script>")
    End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Response.Cookies("user")("login") = "false"
    '    Session.Clear()
    '    Response.Cookies.Clear()
    '    Response.Redirect("../Default.aspx")
    'End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Cookies("user")("login") = "false"
        ' Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("../Default.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            command("BackupDB_")
            cmd.Parameters.Add("@PathbackNm", "D:\DB_Back\Back_" & Now.Day() & "_" & Now.Month() & "_" & Now.Year())
            cmd.ExecuteNonQuery()
            Response.Cookies("user")("login") = "false"
            '  Session.Clear()
            Response.Cookies.Clear()
            Response.Redirect("../Default.aspx")
        Catch ex As Exception
            Page.RegisterStartupScript("ss", "<script type=""text\JavaScript"">alert('Backup Failed\n" & ex.Message & "')</script>")
            ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Key1", "alert('BackUp Failed \nPlease Log Out again and cancel to BackUp Option !');", True)
        End Try

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        'Response.Redirect("../SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
        Response.Redirect("../Default.aspx")

    End Sub
End Class


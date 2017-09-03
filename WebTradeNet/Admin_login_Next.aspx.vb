Imports System.Data.SqlClient
Partial Class Admin_login_Next
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("Default.aspx")
        Dim strim As String = ""
        Dim count_ As Integer = 0
        Try
            If Request.Cookies("admin")("login") = "false" Then
                Response.Redirect("User_login.aspx")
            End If

        Catch ex As Exception
            Response.Redirect("User_login.aspx")
        End Try

        command("sp_get_ticket_by_unread")
        rdr = cmd.ExecuteReader
        While rdr.Read
            count_ = count_ + 1
        End While
        Dim i As Integer = 0
        Dim arru_ids(count_ + 1) As Integer
        Dim arr_u_name(count_ + 1) As String
        command("sp_get_ticket_by_unread")
        rdr = cmd.ExecuteReader
        i = 0
        While rdr.Read
            arru_ids(i) = rdr("creater_id")
            i = i + 1
        End While
        i = 0
        While i < count_
            command("sp_get_user_by_id")
            cmd.Parameters.AddWithValue("@uid", arru_ids(i))
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                arr_u_name(i) = rdr("display_name")
            End If
            i = i + 1
        End While
        i = 0
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:70%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= " By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "	                Date"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        command("sp_get_ticket_by_unread")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td style=""width:70%"">"
            strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("t_id") & "&TradeNetStockbriking.com.html"">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "	            <td style=""width:15%"">"
            strim &= arr_u_name(i)
            strim &= "	            </td>"
            strim &= "	            <td style=""width:15%"" class=""date_ticks"">"
            strim &= rdr("date_")
            strim &= "	            </td>"
            strim &= "	        </tr>"
            i = i + 1
        End While
        If i = 0 Then
            strim = "<span style=""margin-left:20px;"">No New Unread Tickets !</span>"
        End If
        strim &= "	    </table>"
        strim &= "<a href=""Admin_view_all_ticks.aspx#"" style=""float:right;margin-right:20px;"">view All</a> "
        Disp_unread_ticks.InnerHtml = strim
        i = 0
        Dim upd_strim As String =""
        command("sp_get_un_admin_updates")
        rdr = cmd.ExecuteReader
        upd_strim &= " <ul>"
        While rdr.Read
            upd_strim &= "<li >"
            upd_strim &= rdr("update_") & "...... <a href=""test2.aspx?upid=" & rdr("up_id") & "&url=" & Request.Url.ToString & "&ThisIsProgrammer.php "">OK </a>"
            upd_strim &= "					</li>"
            i = i + 1
        End While
        upd_strim &= "</ul>		"
        If i = 0 Then
            upd_strim = "No Unread Updates"
        End If
        disp_updates.InnerHtml = upd_strim
        Dim disp_ten As Integer = 0
        count_ = 0
        command("sp_ticks_by_emer")
        rdr = cmd.ExecuteReader
        While rdr.Read
            count_ = count_ + 1
        End While
        Dim arr_tids(count_ + 1) As Integer
        Dim ar_ticks(count_ + 1) As String
        Dim arrr_stts(count_ + 1) As String
        Dim arr_emer_dates(count_ + 1) As Date
        i = 0
        strim = ""
        strim &= "<table width=""99%"">"
        strim &= "       <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "<td width=""50%"">"
        strim &= "Ticket"
        strim &= "</td>"
        strim &= "<td width=""44%"">"
        strim &= "Emergency"
        strim &= "   </td>"
        strim &= " <td width=""5%"">"
        strim &= ""
        strim &= "</td>"
        strim &= " </tr>"
        command("sp_ticks_by_emer")
        rdr = cmd.ExecuteReader
        While rdr.Read
            arr_tids(i) = rdr("t_id")
            ar_ticks(i) = rdr("t_sub")
            arrr_stts(i) = rdr("t_stts")
            'arr_emer_dates(i) = rdr("emergency_")
            i = i + 1
        End While
        i = 0
        While i < count_
            command("sp_get_ticket_stts_by_id")
            cmd.Parameters.AddWithValue("@tid", arr_tids(i))
            Dim this_date As Date
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                ' this_date = rdr("emergency_")
            End If
            If this_date.Year() < Now.Year() Or this_date.Month() < Now.Month() Then
            Else
                Dim day_ As Integer
                Dim month_ As Integer
                Dim year_ As Integer
                Dim em_date As String = ""
                year_ = this_date.Year() - Now.Year()
                month_ = this_date.Month() - Now.Month()
                day_ = this_date.Day() - Now.Day()
                If this_date.Month() = Now.Month() And day_ < 0 Then
                Else
                    If Not year_ = 0 Then
                        em_date &= year_ & " Year "
                    End If
                    If Not month_ = 0 Then
                        em_date &= month_ & "Month "
                    End If
                    If Not day_ = 0 Then
                        em_date &= day_ & " Day "
                    End If
                    If disp_ten <= 10 Then
                        strim &= "       <tr>"

                        strim &= "<td style=""padding-left:5px;"">"
                        strim &= "<a href=""Admin_view_ticket.aspx?tid=" & arr_tids(i) & "&TradeNetStockBroking.com"">" & ar_ticks(i) & "</a>"
                        strim &= "</td>"
                        strim &= "<td  >"
                        strim &= em_date & "left :-" & arr_emer_dates(i)
                        strim &= "   </td>"
                        strim &= " <td>"
                        strim &= "<a href=""JavaScript:return false()"" OnClick=""window.open('admin_change_erer_date.aspx?tid=" & rdr("t_id") & "&TNCaree.php ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')""><img src=""images/chnage_emer_date_logo.jpg"" onMouseover=""showhint('Click Here To Change Emergency Date for topic " & ar_ticks(i) & " ', this, event, '150px')""/></a>"
                        strim &= "</td>"
                        strim &= " </tr>"
                        disp_ten = disp_ten + 1
                    End If
                End If
            End If
            i = i + 1
        End While
        strim &= "  </table>"
        Disp_emergencyes.InnerHtml = strim
        count_ = 0
        strim = ""
        i = 0

        'command("sp_ticks_by_emer_late")
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        ' count_ = count_ + 1
        ' End While
        'lbl_late_ticks.Text = count_

        strim &= "<table width=""99%"">"
        strim &= "       <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "<td width=""60%"">"
        strim &= "Ticket"
        strim &= "</td>"
        strim &= "<td width=""34%"">"
        strim &= "Emergency"
        strim &= "   </td>"
        strim &= " <td width=""5%"">"
        strim &= ""
        strim &= "</td>"
        strim &= " </tr>"

        ' command("sp_ticks_by_emer_late")
        ' rdr = cmd.ExecuteReader
        ' While rdr.Read
        ' strim &= "<td style=""padding-left:5px;"">"
        'strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html"">" & rdr("t_sub") & "</a>"
        'strim &= "</td>"
        'strim &= "<td  >"
        'strim &= rdr("emergency_")
        'strim &= "   </td>"
        'strim &= " <td>"
        'strim &= "<a href=""JavaScript:return false()"" OnClick=""window.open('admin_change_erer_date.aspx?tid=" & rdr("t_id") & "&Suraj.php ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')""><img src=""images/chnage_emer_date_logo.jpg"" onMouseover=""showhint('Click Here To Change Emergency Date for topic " & ar_ticks(i) & " ', this, event, '150px')""/></a>"
        'strim &= "</td>"
        'strim &= " </tr>"
        'End While
        strim &= "  </table>"
        Disp_late_all_ticks.InnerHtml = strim

    End Sub

    Protected Sub btn_late_ticks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_late_ticks.Click
       

        If pnl_latetics.Visible = False Then
            pnl_latetics.Visible = True
            img_arrow.ImageUrl = "~/images/arrow_upp.jpg"
        Else
            pnl_latetics.Visible = False
            img_arrow.ImageUrl = "~/images/arrow_down.jpg"
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        pnl_latetics.Visible = False
        img_arrow.ImageUrl = "~/images/arrow_down.jpg"
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()
        '==============

        Response.Cookies("user")("login") = "false"
        ' Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("http://10.53.143.45:81/WebTradeNet/BACKUP")
    End Sub
End Class

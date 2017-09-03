Imports System.Data.SqlClient
Partial Class main_admin_login_Next
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd3 As New SqlCommand
    Dim rdr3 As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Sub command3(ByVal strcmd As String)
        cmd3.CommandType = Data.CommandType.StoredProcedure
        cmd3.CommandText = strcmd
        cmd3.Connection = weldone_con.ConObj
        cmd3.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        
        '==============loginer details feed in top informer=================
        Dim loginerID As Integer = Session.Item("loginerID")
        lbl_login_ID.Text = loginerID
        Dim emp_id_ As Integer

        command("sp_get_details_by_loginerID")
        cmd.Parameters.AddWithValue("@loginerID", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_name.Text = " " & rdr("display_name")
            lbl_welcome.Text = rdr("display_name")
            emp_id_ = rdr("forign_id")
            Session.Item("emp_id_") = emp_id_
            Page.Title = "TradeNet ADMIN: " & rdr("display_name")
        End If

       
        lbl_now.Text = Now()
        lbl_last_login.Text = Session.Item("last_login")
        '====================================================================

        Dim count_ As Integer = 0
        Dim i As Integer = 0
        Dim strim As String = ""

        command("sp_get_al_tickets_for_admin")
        rdr = cmd.ExecuteReader
        While rdr.Read
            count_ = count_ + 1
        End While

        Dim arrname(count_ + 1) As String
        Dim arr_uids(count_ + 1) As String

        command("sp_get_al_tickets_for_admin")
        rdr = cmd.ExecuteReader
        While rdr.Read
            arr_uids(i) = rdr("creater_id")
            i = i + 1
        End While

        i = 0
        While i < count_
            command("sp_get_user_by_id")
            cmd.Parameters.AddWithValue("@uid", arr_uids(i))
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                arrname(i) = rdr("display_name")
            End If
            i = i + 1
        End While

        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:54%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:18%"">"
        strim &= " By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:18%"">"
        strim &= "	                Date"
        strim &= "	            </td>"

        
        strim &= "	        </tr>"
        i = 0
        command("sp_get_al_tickets_for_admin")
        rdr = cmd.ExecuteReader
        While rdr.Read
            Dim rec_date As DateTime = System.Convert.ToDateTime(rdr("last_update_date"))
            Dim today_date As DateTime = System.Convert.ToDateTime(Now())
            Dim ts As New TimeSpan()
            today_date.Subtract(rec_date)
            Dim hnd_stts As String = rdr("now_hand_in")
            Dim minuts As Integer = ts.Minutes
            Dim hours As Integer = 0
            Dim ticket_id As Integer = rdr("t_id")
            hours = ts.Days * 24
            hours = hours + ts.Hours
            Dim days As Integer = ts.Days()
            Dim ia As Integer = 0
            While ia <= days
                Dim pri_days As Date = DateTime.Now.AddDays(-ia)
                If pri_days.DayOfWeek = DayOfWeek.Sunday Then
                    hours = hours - 24
                End If
                ia = ia + 1
            End While

            If hours > 48 And Not hnd_stts = "ADMIN" Then
                command3("sp_update_hand_stts_by_tid")
                cmd3.Parameters.AddWithValue("@tid", ticket_id)
                cmd3.Parameters.AddWithValue("@hnd_stts", "ADMIN")
                cmd3.ExecuteNonQuery()

                command3("sp_chage_q_stts_by_tid")
                cmd3.Parameters.AddWithValue("@tid", ticket_id)
                cmd3.ExecuteNonQuery()

                Response.Redirect("hod_login_Next.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
            End If
            strim &= "	        <tr >"
            strim &= "	            <td style=""width:54%"">"
            strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "	            <td style=""width:18%"">"
            strim &= arrname(i)
            strim &= "	            </td>"
            strim &= "	            <td style=""width:10%"" class=""date_ticks"">"
            strim &= rdr("t_stts")
            strim &= "	            </td>"

            strim &= "	            <td style=""width:18%"" class=""date_ticks"">"
            strim &= rdr("date_")
            strim &= "	            </td>"


            strim &= "	        </tr>"
            i = i + 1
        End While
        If i = 0 Then
            strim = "<span style=""margin-left:20px;"">No New Unread Tickets !</span>"
        End If
        strim &= "	    </table>"
        Disp_unread_ticks.InnerHtml = strim
        '============ addressbook ============
        strim = ""
        strim &= "<table >"
        strim &= "<tr class=""ex_tr_cls3"">"
        strim &= "<td>"
        strim &= "Name"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "LoginerID"
        strim &= "</td>"
        strim &= "</tr>"
        Dim ae As Integer = 0
        command("sp_get_addressbook")
        rdr = cmd.ExecuteReader
        While rdr.Read
            If ae = 0 Then
                strim &= "<tr class=""ex_tr_cls1"">"
                strim &= "<td>"
                strim &= rdr("display_name")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("id")
                strim &= "</td>"
                ae = 1
            Else
                strim &= "<tr  class=""ex_tr_cls2"">"
                strim &= "<td>"
                strim &= rdr("display_name")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("id")
                strim &= "</td>"
                ae = 0
            End If
           
        End While
        strim &= "</table>"
        'disp_addBook.InnerHtml = strim
        '=====================================
        Try
            If Request.Cookies("mainadmin")("login") = "false" Then
                Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
            End If
           
        Catch ex As Exception
            Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
        End Try
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Cookies("admin")("login") = "false"
        ' Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("hod/")
    End Sub
End Class

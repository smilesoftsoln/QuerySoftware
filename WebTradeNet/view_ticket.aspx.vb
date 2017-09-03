Imports System.Data.SqlClient
Partial Class view_ticket
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Request.Cookies("user")("login") = "false") Then
                Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
            End If
        Catch ex As Exception
        End Try
        loginerID = Session.Item("loginerID")
        Dim tid As Integer = Request.QueryString("tid")
        Dim crtrID As Integer
        Dim crtr_date As New Date
        Dim attch As String
        Dim stts_ As String
        Dim crtr As String = ""
        Dim stts_2 As String = ""
        Dim rec_date As DateTime
        Dim today_date As DateTime
        Dim ts As New TimeSpan()
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()

        '===========besic info fill===========
        command("sp_view_ticket")
        cmd.Parameters.AddWithValue("@t_id", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_t_id.Text = rdr("disp_id")
            rec_date = System.Convert.ToDateTime(rdr("last_update_date"))
            today_date = System.Convert.ToDateTime(Now())
            lbl_ticket_sub.Text = rdr("t_sub")
            Page.Title = "TradeNet : " & rdr("t_sub")
            lbl_ticket_desc.Text = rdr("t_desc")
            lbl_from.Text = rdr("branch_name")
            crtr_date = rdr("last_update_date")
            attch = rdr("attatchment_url")
            lbl_subid.Text = rdr("disp_id")
            lbl_to.Text = "Department of " & rdr("dept_name")
            crtr &= "<a href=""#?uid=" & crtrID & " "">" & rdr("name_") & "</A> "
            lbl_auther.Text = rdr("name_")
            lbl_crtr_date.Text = rdr("last_update_date")
            lbl_now.Text = Now()
            lbl_uname_1.Text = rdr("name_")
            Disp_stts_link.InnerHtml = rdr("t_stts")
            stts_2 = rdr("t_stts")
            If attch = "No" Then
                lbl_attch.Text = "No"
            Else
                lbl_attch.Text = "<a href=""test_3.aspx?fid=" & attch & " "" target=""_blank"">Download Attachment</a>"
            End If

        End If
        ts = today_date.Subtract(rec_date)
        lbl_est_time.Text = ts.ToString
        '============= Get comments==============
        Dim comments As String = ""
        Dim i As Integer = 0
        command("sp_get_comments")
        cmd.Parameters.AddWithValue("@t_id", tid)
        rdr = cmd.ExecuteReader
        While rdr.Read
            comments &= "<div class=""VT_comments2"">"
            comments &= rdr("comment_")
            comments &= ""
            Dim tmp_attch As String = rdr("attch_url")
            If tmp_attch = "NO" Then
            Else
                comments &= "<div class=""post_dwnld_link""><a href=""test_3.aspx?fid=" & tmp_attch & " "" target=""_blank"">Download Attachment</a></div>"
            End If
            comments &= "<div class=""creater_"" id=""post_creater""> - By <a href=""#"">" & rdr("name_") & "  (" & rdr("desc_") & ")</A> (" & rdr("date_") & ")</div>"
            comments &= "</div>"
            i = i + 1
        End While
        If i = 0 Then
            comments = ""
        End If
        dip_comments.InnerHtml = comments
        '=========== stts work
        LinkButton1.Visible = False
        If stts_2 = "SOLVED" Then
            LinkButton1.Visible = False
            btn_resend_tick.Visible = True
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If panal_post_comm.Visible = True Then
            panal_post_comm.Visible = False
        Else
            panal_post_comm.Visible = True
            panal_post_comm.Focus()
        End If
    End Sub
    Protected Sub btn_post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_post.Click
        Dim tid As Integer = Request.QueryString("tid")
        Dim t_sub As String = ""
        Dim user As String = ""
        loginerID = Session.Item("loginerID")
        Dim deptType As String = Session.Item("loginerTYP")
        If deptType = "" Then
            Response.Redirect("User_Login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
        End If
        Dim loginerTYP As String = Session.Item("loginerTYP")
        Dim attch As String = "NO"
        Dim fileext As String
        Dim this_attch As String = "NO"

        If fUpp.HasFile Then
            fileext = System.IO.Path.GetExtension(fUpp.FileName)
            Dim ext As String = IO.Path.GetExtension(fUpp.FileName).ToLower
            this_attch = "Attatchments/" & Today.Year & Today.Month & Now.Minute & Now.Second & Now.Millisecond & ext
            fUpp.SaveAs(Server.MapPath(this_attch))
        End If

        Dim tickterid As Integer
        Dim sub_ As String = ""
        command("sp_get_ticket")
        cmd.Parameters.AddWithValue("@tid", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            sub_ = rdr("t_sub")
            tickterid = rdr("creater_id")
        End If
        MsgBox(loginerID)
        If Not txt_post_.Text = "" Then
            command("sp_insert_comment_")
            cmd.Parameters.AddWithValue("@t_id", tid)
            cmd.Parameters.AddWithValue("@comm_", txt_post_.Text)
            cmd.Parameters.AddWithValue("@crtr_id", loginerID)
            cmd.Parameters.AddWithValue("@attch_url", this_attch)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("view_ticket.aspx?tid=" & tid & "&TnCAREeisgrate.html&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
            End If
        End If
    End Sub

    Protected Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        panal_post_comm.Visible = False
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()


        Response.Cookies("user")("login") = "false"
        ' Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub

    Protected Sub btn_resend_tick_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_resend_tick.Click
        Dim tid As Integer = Request.QueryString("tid")
        Dim lid As Integer = Session.Item("loginerID")
        Response.Redirect("resend.aspx?tid=" & tid & "&lid=" & lid & "&&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
    End Sub
End Class

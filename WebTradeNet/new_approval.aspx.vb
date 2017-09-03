Imports System.Data.SqlClient
Partial Class new_approval
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
        Dim tid As Integer = Request.QueryString("t_id")
        Dim crtrID As Integer
        Dim crtr_date As DateTime
        Dim attch As String
        Dim stts_ As String
        Dim crtr As String
        Dim to_dept_id As Integer
        Dim rec_date As DateTime
        Dim today_date As DateTime
        Dim ts As New TimeSpan()
        Dim pro_to As Integer
        Dim reciver_De_loginer_id As Integer
        Dim details As String = ""
        Dim loginerID As Integer = Session.Item("loginerID")

        Dim for_reciver As String = ""
        Dim for_reciver2 As String = ""

        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_welcome.Text = rdr("name_")
        End If
        command("sp_view_ticket")
        cmd.Parameters.AddWithValue("@t_id", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then

            Label1.Text = rdr("disp_id")
            'MsgBox(rdr("disp_id"))
            rec_date = System.Convert.ToDateTime(rdr("last_update_date"))
            today_date = System.Convert.ToDateTime(Now())
            lbl_ticket_sub.Text = rdr("t_sub")
            Page.Title = "TradeNet : " & rdr("t_sub")
            lbl_ticket_desc.Text = rdr("t_desc")
            lbl_from.Text = rdr("branch_name")
            crtr_date = rdr("last_update_date")
            attch = rdr("attatchment_url")

            lbl_to.Text = "Department of " & rdr("dept_name")
            crtr &= "<a href=""#?uid=" & crtrID & " "">" & rdr("name_") & "</A> "
            lbl_auther.Text = rdr("name_")
            lbl_crtr_date.Text = rdr("last_update_date")
            lbl_now.Text = Now()
            Disp_stts_link.InnerHtml = rdr("t_stts")
            If attch = "NO" Or attch = "No" Then
                lbl_attch.Text = "No"
            Else
                lbl_attch.Text = "<a href=""test_3.aspx?fid=" & attch & " "" target=""_blank"" >Download Attachment</a>"
                lbl_attch.Visible = False
                HyperLink1.Target = "_blank"
                HyperLink1.NavigateUrl = "test_3.aspx?fid=" & attch
                HyperLink1.Visible = True
                HyperLink1.Text = "Download Attachment"
            End If
            stts_ &= "<a href=""JavaScript:return false()"" > Status : " & rdr("t_stts") & " </a> |"
            reciver_De_loginer_id = rdr("pro_to_emp_id")

        End If
        command("sp_get_username_")
        cmd.Parameters.AddWithValue("@id", reciver_De_loginer_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            details &= "Sender : " & rdr("username_")
        End If

        for_reciver &= details
        'Label2.Text = reciver_De_loginer_id
        ts = today_date.Subtract(rec_date)
        lbl_est_time.Text = ts.ToString
        disp_reciver_de_details.InnerHtml = for_reciver

        If Session.Item("loginerTYP") = "HOD" Then

        End If




        lbl_crtr_date.Text = crtr_date
        lbl_now.Text = Now()

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
        '============
        'unread stts
        '============
        If Session.Item("admin") = "admin" Then
            command("sp_get_ticket_stts_by_id")
            cmd.Parameters.AddWithValue("@tid", tid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                If rdr("t_stts") = "STILL UNREAD" Then
                    command("sp_update_un_stts")
                    cmd.Parameters.AddWithValue("@tid", tid)
                    If cmd.ExecuteNonQuery Then
                        command("sp_user_update_fill")
                        cmd.Parameters.AddWithValue("@userID", crtrID)
                        cmd.Parameters.AddWithValue("@update_", "Project Admin has been read your new ticket named ' " & lbl_ticket_sub.Text & " ', On " & Now() & " ")
                        cmd.ExecuteNonQuery()
                    End If
                End If
            End If
        End If
        Dim comm_count As Integer = 0


        '========== approval note
        Dim strim As String
        Dim app_id As Integer = Request.QueryString("app_id")
        command("sp_get_approvals_id")
        cmd.Parameters.AddWithValue("@id", app_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_app_note.Text = rdr("note_crtr")
        End If

    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        Dim app_id As Integer = Request.QueryString("app_id")
        If RadioButtonList1.SelectedValue = "" Then
        Else
            command("sp_update_approve")
            cmd.Parameters.AddWithValue("@app_id", app_id)
            cmd.Parameters.AddWithValue("@note_", txt_resone.Text)
            cmd.Parameters.AddWithValue("@stts", RadioButtonList1.SelectedValue)
            If cmd.ExecuteNonQuery Then
                pnl_app.Visible = False
                If Session.Item("loginerTYP") = "HOD" Then
                    Response.Redirect("hod_login_Next.aspx")
                ElseIf Session.Item("loginerTYP") = "MNG" Then
                    Response.Redirect("mng_login_next.aspx")
                End If
            End If
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()
        '==========

        Response.Cookies("admin")("login") = "false"
        'Session.Clear()
        'Session.Abandon()
        Response.Cookies.Clear()
        Response.Redirect("")

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

    End Sub
End Class

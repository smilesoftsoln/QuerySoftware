Imports System.Data.SqlClient
Imports projecterNM
Partial Class hod_view_tixk_nvsbl
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
        Dim tid As Integer = Request.QueryString("tid")
        Dim loginerID As Integer = Session.Item("loginerID")
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
        Dim Current_dept_id As Integer = Session.Item("DEPT_ID")
        '        CheckBoxList1.Visible = False
        '        Button1.Visible = False



        Dim for_reciver As String = ""
        Dim for_reciver2 As String = ""

        command("sp_view_ticket")
        cmd.Parameters.AddWithValue("@t_id", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then

            Label1.Text = rdr("disp_id")
            rec_date = System.Convert.ToDateTime(rdr("last_update_date"))
            today_date = System.Convert.ToDateTime(Now())
            lbl_ticket_sub.Text = rdr("t_sub")
            Page.Title = "TradeNet : " & rdr("t_sub")
            lbl_ticket_desc.Text = rdr("t_desc")
            lbl_from.Text = rdr("branch_name")
            crtr_date = rdr("last_update_date")
            attch = rdr("attatchment_url")
            'Current_dept_id = rdr("dept_id")

            lbl_to.Text = "Department of " & rdr("dept_name")
            crtr &= "<a href=""#?uid=" & crtrID & " "">" & rdr("name_") & "</A> "
            lbl_auther.Text = rdr("name_")
            lbl_crtr_date.Text = rdr("last_update_date")
            lbl_now.Text = Now()
            Disp_stts_link.InnerHtml = rdr("t_stts")
            If Disp_stts_link.InnerHtml <> "SOLVED" Then '****************BY AHIJEET
                Inform_ToID.Visible = False
            End If
            If attch = "NO" Or attch = "No" Then
                lbl_attch.Text = "No"
            Else
                lbl_attch.Text = "<a href=""test_3.aspx?fid=" & attch & " "" target=""_blank"">Download Attachment</a>"
            End If
            stts_ &= "<a href=""JavaScript:return false()"" > Status : " & rdr("t_stts") & " </a> |"
            reciver_De_loginer_id = rdr("pro_to_emp_id")

        End If
        command("sp_get_username_")
        cmd.Parameters.AddWithValue("@id", reciver_De_loginer_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            details &= "Reciver : " & rdr("username_")
        End If

        for_reciver &= details
        Label2.Text = reciver_De_loginer_id
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

        dip_comments.InnerHtml = comments


        Dim loginerTYP As String = Session.Item("loginerTYP")
        Dim disp_hom_link As String = ""
        If loginerTYP = "ADMIN" Then
            LinkButton1.Visible = False
        ElseIf loginerTYP = "HOD" Then
            If Not stts_.Contains("SOLVED") Then
                LinkButton1.Visible = True
                '                CheckBoxList1.Visible = False
                'Button1.Visible = False

            End If

        ElseIf loginerTYP = "DE" Then
            LinkButton1.Visible = False
        Else
            LinkButton1.Visible = False
        End If

        If loginerTYP = "HOD" Then
            If stts_.Contains("SOLVED") Then
                '                CheckBoxList1.Visible = True
                'Button1.Visible = True

            End If
        End If

        ' approval note 


        command("sp_get_app_by_t_id")
        Dim result As String = ""
        cmd.Parameters.AddWithValue("@tid", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_app_crtr.Text = rdr("note_crtr")
            lbl_app_rcvr.Text = rdr("note_rcvr")
            result = rdr("stts")
            pnl_app.Visible = True
        End If
        If result = "DISAPPROVE" Then
            lbl_result.Text = "<sapn style=""color:red;""><b>DISAPPROVE</b></span>"
        ElseIf result = "FREEZ" Then
            lbl_result.Text = "<sapn style=""color:black;"">Wating</span>"
        ElseIf result = "APPROVE" Then
            lbl_result.Text = "<sapn style=""color:green;""><b>APPROVE</b></span>"
        End If



        command("sp_get_all_depts")
        rdr = cmd.ExecuteReader
        While rdr.Read
            Dim li As New ListItem
            li.Value = rdr("id")
            li.Text = rdr("dept_name")
            ChkList.Items.Insert(0, li)
        End While




        ChkList.Visible = True
        i = 0
        While i < ChkList.Items.Count()
            command("Get_Informs")
            cmd.Parameters.AddWithValue("@Ticket_id", tid)
            cmd.Parameters.AddWithValue("@To_Dept_ID", ChkList.Items.Item(i).Value)
            cmd.Parameters.AddWithValue("@From_Dept_id", Current_dept_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                ChkList.Items.Item(i).Selected = True
                ChkList.Items.Item(i).Enabled = False

            End If
            i = i + 1
        End While

        command("inform_to_chk_dept")
        cmd.Parameters.AddWithValue("@Ticket_id", tid)
        cmd.Parameters.AddWithValue("@hod_loginer_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Dim throwScript As String = "<script type=""text/javascript"">    $(document).ready(function(){                $('#Inform_ToID').addClass('DispNN');    });    </script>"
            Page.RegisterStartupScript("s", throwScript)
            info_comm.InnerHtml = "Inform To Comment : " & rdr("Comment") & " <br>-(" & rdr("Date_") & ")"
            Dim infoID As Integer = rdr("Infto_id")
            If rdr("Rd_Stts") = "N" Then
                command("change_info_stts")
                cmd.Parameters.AddWithValue("@Infto_id", infoID)
                cmd.Parameters.AddWithValue("@new_stts", "Y")
                cmd.ExecuteNonQuery()
            End If
        End If

    End Sub

   
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim now_to_l_id As Integer = cbo_em_list.SelectedValue

        Dim this_l_id As Integer = Label2.Text
        Dim forign_id As Integer
        Dim disp_id As Double = Double.Parse(lbl_tick_id.Text)
        Dim tid As Integer = Request.QueryString("tid")

        command("sp_get_forign_id_by_loginer_id")
        cmd.Parameters.AddWithValue("@loginer_id", now_to_l_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            forign_id = rdr("forign_id")
        End If

        command("sp_update_reciver_by_disp_id")
        cmd.Parameters.AddWithValue("@disp_id", disp_id)
        cmd.Parameters.AddWithValue("@new_recv_id", forign_id)
        If cmd.ExecuteNonQuery Then
            Response.Redirect("hod_view_tixk_nvsbl.aspx?tid=" & tid & "&?AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim tid As Integer = Request.QueryString("tid")
        Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">window.open('hod_transfer_query.aspx?tid=" & tid & "&html ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=200')</script>")
        'Response.Redirect("hod_transfer_query.aspx?tid=" & tid)
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim depts As New Queue
    '    Dim tid As Integer = Request.QueryString("tid")
    '    Dim fieldDeptId As New DBField
    '    Dim fieldTicketId As New DBField
    '    Dim db As New projectercon

    '    'For i As Integer = 0 To CheckBoxList1.Items.Count - 1
    '    '    If CheckBoxList1.Items(i).Selected = True Then
    '    '        fieldDeptId.value = CheckBoxList1.Items(i).Value()
    '    '        fieldDeptId.dataType = 2
    '    '        fieldTicketId.value = tid
    '    '        fieldTicketId.dataType = 2
    '    '        depts.Enqueue(fieldDeptId)
    '    '        depts.Enqueue(fieldTicketId)
    '    '        db.InsertRecordIntoTable("tbl_informto_master", depts, False)
    '    '    End If
    '    'Next
    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        Try
            Dim i As Integer = 0
            Dim sentCnt = 0
            While i < ChkList.Items.Count()
                If ChkList.Items.Item(i).Selected = True Then
                    SendinformTo(ChkList.Items(i).Value, ChkList.Items(i).Text)
                    sentCnt = sentCnt + 1
                End If
                i = i + 1
            End While

            If sentCnt = 0 Then
                RegisterStartupScript("sa", "<script language=""JavaScript"">alert('Informs Cant Sent !')</script>")
            Else
                RegisterStartupScript("sa", "<script language=""JavaScript"">alert('Informs Sent Successfully !')</script>")
                ChkList.Visible = False
                Response.Redirect(Request.Url.ToString)
            End If


        Catch ex As Exception

        End Try

    End Sub

    Sub SendinformTo(ByVal toDeptID As Integer, ByVal toDeptName As String)
        Dim tid As Integer = Request.QueryString("tid")
        Dim Current_dept_id As Integer

        command("sp_view_ticket1")
        cmd.Parameters.AddWithValue("@t_id", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Current_dept_id = rdr("dept_id")
            'Current_dept_id = rdr("id")
        End If

        command("insert_Inform_To_")
        cmd.Parameters.AddWithValue("@Ticket_id", tid)
        cmd.Parameters.AddWithValue("@Comment", txt_comment.Text)
        cmd.Parameters.AddWithValue("@To_Dept_ID", toDeptID)
        cmd.Parameters.AddWithValue("@From_Dept_id", Current_dept_id)
        rdr = cmd.ExecuteReader()
        If rdr.Read Then
            If rdr("val") = "FALSE" Then
                RegisterStartupScript("sa", "<script language=""JavaScript"">alert('Inform Cant Sent to Department " & toDeptName & "!')</script>")
            End If
        End If


    End Sub
End Class

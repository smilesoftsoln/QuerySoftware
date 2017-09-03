Imports System.Web.HttpResponse
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Data
Imports System

Imports System.Net
Imports Microsoft.VisualBasic
Imports System.Web.UI.WebControls


Namespace somman_functions_NM
    Public Class commen_funcs
        Dim weldone_con As New projecterNM.projectercon
        Shared weldone_con1 As New projecterNM.projectercon
        Dim cmd As New SqlCommand
        Shared cmd1 As New SqlCommand
        Dim rdr As SqlDataReader
        Shared rdr1 As SqlDataReader
        Dim cmd3 As New SqlCommand
        Dim rdr3 As SqlDataReader
        Dim loginerID As Integer
        Shared ConTodo As String
        Shared SqlCon As SqlConnection

        Sub command(ByVal strcmd As String)
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.CommandText = strcmd
            cmd.Connection = weldone_con.ConObj
            cmd.Parameters.Clear()
        End Sub
        Shared Sub commandshare(ByVal strcmd As String)
            cmd1.CommandType = Data.CommandType.StoredProcedure
            cmd1.CommandText = strcmd
            cmd1.Connection = weldone_con1.ConObj
            cmd1.Parameters.Clear()
        End Sub
        Sub command3(ByVal strcmd As String)
            cmd3.CommandType = Data.CommandType.StoredProcedure
            cmd3.CommandText = strcmd
            cmd3.Connection = weldone_con.ConObj
            cmd3.Parameters.Clear()
        End Sub

        Shared Sub constringTodo()
            Dim rootWebConfig As System.Configuration.Configuration
            rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/WebTradeNet")
            Dim connString As System.Configuration.ConnectionStringSettings
            If (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0) Then
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings("myconstring")
                If Not (connString.ConnectionString = Nothing) Then
                    '  Console.WriteLine("Northwind connection string = {0}", connString.ConnectionString)

                    ConTodo = connString.ConnectionString

                Else
                    ' Console.WriteLine("No Northwind connection string")
                End If
            End If
        End Sub


        Public Shared Sub escalateTask()
            constringTodo()
            SqlCon = New SqlConnection(ConTodo)
            Dim dttasks As New DataTable

            SqlCon.Open()
            cmd1 = New SqlCommand
            cmd1.Connection = SqlCon
            cmd1.CommandText = "select * from t_m_task where Status='U' and enddate<=getdate() "
            rdr1 = cmd1.ExecuteReader
            If rdr1.HasRows Then


                dttasks.Load(rdr1)

            End If

            rdr1.Close()

            For Each drw As DataRow In dttasks.Rows
                Dim creator_name As String = ""
                Dim assign_to_name As String = ""
                Dim creator_email As String = ""
                Dim assign_to_email As String = ""
                cmd1 = New SqlCommand
                cmd1.Connection = SqlCon
                cmd1.CommandText = "select name,email_id  from t_m_login  where id='" + drw("creator").ToString + "'  "
                rdr1 = cmd1.ExecuteReader
                If rdr1.HasRows Then

                    rdr1.Read()
                    creator_name = rdr1("name").ToString
                    creator_email = rdr1("email_id").ToString


                End If

                rdr1.Close()
                cmd1 = New SqlCommand
                cmd1.Connection = SqlCon
                cmd1.CommandText = "select name,email_id  from t_m_login  where id='" + drw("assign_to").ToString + "'  "
                rdr1 = cmd1.ExecuteReader
                If rdr1.HasRows Then

                    rdr1.Read()
                    assign_to_name = rdr1("name").ToString
                    assign_to_email = rdr1("email_id").ToString


                End If
                If (creator_email.Equals(assign_to_email)) Then
                    MailSend(assign_to_email, "Task:-" + drw("id").ToString + " Subject:-" + drw("subject").ToString + " OverDue ", "Dear " + assign_to_name + ",<br/>" + "Task " + drw("subject").ToString + " Assigned To You By YourSelf  is overdue ", "Task Overdue")

                Else
                    MailSend(creator_email, "Task:-" + drw("id").ToString + " Subject:-" + drw("subject").ToString + " OverDue ", "Dear " + creator_name + ",<br/>" + "Task " + drw("subject").ToString + " Assigned To " + assign_to_name + " By You is overdue", "Task Overdue")
                    MailSend(assign_to_email, "Task:-" + drw("id").ToString + " Subject:-" + drw("subject").ToString + " OverDue ", "Dear " + assign_to_name + ",<br/>" + "Task " + drw("subject").ToString + " Assigned To You By " + creator_name + "  is overdue ", "Task Overdue")

                End If

                rdr1.Close()
                cmd1 = New SqlCommand
                cmd1.Connection = SqlCon
                cmd1.CommandText = "update     t_m_task set Status='O'   where Status='U' and id=" + drw("id").ToString + " and enddate<=getdate() "
                cmd1.ExecuteNonQuery()
                cmd1 = New SqlCommand
                cmd1.Connection = SqlCon
                cmd1.CommandText = "insert into t_m_task_overdue values ('" + drw("id").ToString + "','" + drw("enddate").ToString + "','" + drw("creator").ToString + "','" + drw("assign_to").ToString + "','" + drw("usertype").ToString + "','" + drw("branch").ToString + "','" + drw("dept").ToString + "','" + drw("priority").ToString + "','" + drw("subject").ToString + "','" + drw("descp").ToString + "','O')"
                cmd1.ExecuteNonQuery()

                ''id
                '  ' enddate()
                '  creator()
                '  assign_to()
                '  usertype()
                '  branch()
                '  dept()
                '  priority()
                '  subject()
                '  descp()
                '  Status



            Next




            '()
            'enddate()
            '()
            '()
            '()
            'branch()
            'dept()
            'priority()
            '()
            '()
            'Status
            'SolvedDate()


            SqlCon.Close()

        End Sub



        'Public Function alerts()
        '    Dim strim As String = ""
        '    Dim i As Integer = 0
        '    command("sp_get_alert_from_loginer")
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        strim &= "<p><u>Paniding User info</u> :<br> for user <i><b>" & rdr("name_") & " (" & rdr("post_") & ") </i></b> Some Feilds Are Empty <br>"
        '        strim &= "<a href=""add_new_user_stape_2.aspx?loginerID=" & rdr("id") & "&post_=" & rdr("post_") & "&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAm"">Fix Issue</a></p>"
        '        i = i + 1
        '    End While

        '    command("sp_get_alert_from_dept")
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        strim &= "<p><u>HOD Less Department</u> :<br> For the <i><b>" & rdr("dept_name") & " </i></b> HOD Not mentioned<br>"
        '        strim &= "<a href=""Assign_Exist_HOD.aspx"">Manage HOD</a></p>"
        '        i = i + 1
        '    End While

        '    command("sp_get_alert_from_managements")
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        strim &= "<p><u>User Less Management</u> :<br> For the <i><b>" & rdr("mng_name") & " </i></b> Manager Not mentioned<br>"
        '        strim &= "<a href=""Assign_Exist_HOD.aspx"">Manage HOD</a></p>"
        '        i = i + 1
        '    End While

        '    If i <= 0 Then
        '        Return i
        '    Else
        '        Return strim
        '    End If


        'End Function


        Public Shared Sub Escalate_query()
            'MsgBox("hi")

            Dim counter_ As Integer = 0
            Try
                commandshare("sp_ticket")
                rdr1 = cmd1.ExecuteReader
                While rdr1.Read
                    counter_ = counter_ + 1
                End While

                Dim arr_t_ids(counter_ + 1) As Integer

                Dim i As Integer = 0
                commandshare("sp_ticket")
                rdr1 = cmd1.ExecuteReader
                While rdr1.Read
                    arr_t_ids(i) = rdr1("id")
                    i = i + 1
                End While
                i = 0
                While i < counter_
                    commandshare("sp_get_ticket_stts_by_id")
                    cmd1.Parameters.AddWithValue("@tid", arr_t_ids(i))
                    rdr1 = cmd1.ExecuteReader
                    If rdr1.Read Then
                        Dim disp_id As Integer = rdr1("disp_id")
                        Dim t_sub As String = rdr1("t_sub")
                        Dim to_dept_id As Integer = rdr1("to_dept_id")
                        Dim to_de As Integer = rdr1("Pro_to_emp_id")
                        Dim dept_name As String = ""
                        Dim t_from As String = ""
                        Dim t_to As String = ""
                        Dim date_rec As DateTime
                        Dim rec_date As DateTime
                        If Not String.IsNullOrEmpty(rdr1("stts_chng_date").ToString()) Then
                            rec_date = System.Convert.ToDateTime(rdr1("stts_chng_date"))
                        Else
                            rec_date = System.Convert.ToDateTime(rdr1("last_update_date"))

                        End If
                        date_rec = System.Convert.ToDateTime(rdr1("last_update_date"))
                        Dim today_date As DateTime = System.Convert.ToDateTime(Now())
                        Dim ts As New TimeSpan()
                        ts = today_date.Subtract(rec_date)
                        Dim minuts As Integer = ts.Minutes
                        Dim hours As Integer = 0
                        Dim ticket_id As Integer = rdr1("id")
                        hours = ts.Days * 24
                        hours = hours + ts.Hours
                        Dim days As Integer = ts.Days()
                        Dim ia As Integer = 0
                        ' MsgBox(ticket_id & ":" & hours)
                        While ia <= days
                            Dim pri_days As Date = DateTime.Now.AddDays(-ia)
                            If pri_days.DayOfWeek = DayOfWeek.Sunday Then
                                hours = hours - 24
                            End If
                            ia = ia + 1
                        End While

                        'If hours > 24 Then

                        commandshare("sp_get_ticket_by_t_id")
                        cmd1.Parameters.AddWithValue("@t_id", ticket_id)
                        rdr1 = cmd1.ExecuteReader

                        If rdr1.Read Then
                            Dim creater_name As String = ""
                            Dim creater_branch As String = ""
                            Dim inhand As String = rdr1("now_hand_in")
                            Dim type As String = rdr1("q_typ")
                            Dim creater_id As Double = Convert.ToDouble(rdr1("creater_id"))
                            Dim branch_id As Double = Convert.ToDouble(rdr1("from_branch_id"))
                            Dim cmd4 As New SqlCommand
                            Dim weldone_con As New projecterNM.projectercon
                            cmd4.Connection = weldone_con.ConObj
                            cmd4.CommandText = "select tbl_loginer_master.name_,tbl_branch_master.branch_name from tbl_loginer_master  ,tbl_branch_master where tbl_loginer_master.id=" & creater_id & " and tbl_branch_master.id=" & branch_id
                            Dim rdr12 As SqlDataReader
                            rdr12 = cmd4.ExecuteReader
                            If rdr12.Read Then
                                creater_name = rdr12(0).ToString
                                creater_branch = rdr12(1).ToString

                            End If

                            If inhand = "DE" Then
                                Dim kij As Integer
                                kij = 9
                            End If
                            If rdr1("now_hand_in") = "HOD" And rdr1("t_stts") = "UNSOLVED" And hours >= 24 Then
                                commandshare("sp_upadte_escal2")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)

                                cmd1.ExecuteNonQuery()
                                commandshare("sp_get_hod_by_dept_id")
                                cmd1.Parameters.AddWithValue("@dept_id", to_dept_id)

                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    dept_name = rdr1("dept_name")
                                    t_from = rdr1("name_") & "(HOD)"
                                End If
                                rdr1.Close()
                                If dept_name.Equals("CUSTOMERCARE") Then
                                    commandshare("sp_update_hand_stts_by_tid")
                                    cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                    cmd1.Parameters.AddWithValue("@hnd_stts", "SHOD")
                                    cmd1.ExecuteNonQuery()

                                Else

                                    commandshare("sp_update_hand_stts_by_tid")
                                    cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                    cmd1.Parameters.AddWithValue("@hnd_stts", "MNG")
                                    cmd1.ExecuteNonQuery()
                                End If
                               

                                commandshare("sp_chage_q_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.ExecuteNonQuery()

                                'commandshare("sp_get_mng_email_by_tkt_id")
                                'cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)
                                'Dim this_email_id As String = ""
                                'rdr1 = cmd1.ExecuteReader
                                'If rdr1.Read Then
                                '    this_email_id = rdr1("email_id")
                                '    t_to = rdr1("name_") & "(MNG)"
                                'End If
                                'escalation log entry
                                commandshare("sp_get_hod_by_dept_id")
                                cmd1.Parameters.AddWithValue("@dept_id", to_dept_id)

                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    dept_name = rdr1("dept_name")
                                    t_from = rdr1("name_") & "(HOD)"
                                End If
                                Dim this_email_id As String = ""
                                If dept_name.Equals("CUSTOMERCARE") Then
                                    commandshare("sp_get_shod_email_by_tkt_id")
                                    cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)
                                    'Dim this_email_id As String = ""
                                    rdr1 = cmd1.ExecuteReader
                                    If rdr1.Read Then
                                        this_email_id = rdr1("email_id")
                                        t_to = rdr1("name_") & "(SHOD)"
                                    End If

                                Else

                                    commandshare("sp_get_mng_email_by_tkt_id")
                                    cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)

                                    rdr1 = cmd1.ExecuteReader
                                    If rdr1.Read Then
                                        this_email_id = rdr1("email_id")
                                        t_to = rdr1("name_") & "(MNG)"
                                    End If
                                End If
                               
                                commandshare("insert_escal_log")
                                cmd1.Parameters.AddWithValue("@disp_tid", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@escal_date", DateTime.Now)
                                cmd1.Parameters.AddWithValue("@t_from", t_from)
                                cmd1.Parameters.AddWithValue("@t_to", t_to)
                                cmd1.ExecuteNonQuery()
                                'escal insert done
                                commandshare("insert_penalty")
                                cmd1.Parameters.AddWithValue("@tick_id", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@user", t_from)
                                cmd1.ExecuteNonQuery()

                                commandshare("update_penalty2")

                                cmd1.Parameters.AddWithValue("@tid", disp_id)
                                cmd1.Parameters.AddWithValue("@penalty", 1)
                                cmd1.ExecuteNonQuery()
                                Try
                                    Call MailSend(this_email_id, "WebTradeNet: You Have Recieved a Escalated Query : " & disp_id, "You have Recieved Escalated Query . Subject :" & t_sub & "<br/>Department:" & dept_name & " <br/> From User:- " & t_from & "<br/> Date  Recieved To First User:-" & date_rec & "<br/> Issued by " & creater_name & "(" + creater_branch + ")", "Query Software")
                                Catch ex As Exception

                                End Try
                            ElseIf rdr1("now_hand_in") = "MNG" And rdr1("q_typ") = "ESCALATED" Then
                                '  ElseIf rdr("now_hand_in") = "DE" And rdr("t_stts") = "FOLLOW UP" And hours >= 120 Then
                            ElseIf rdr1("now_hand_in") = "DE" And rdr1("t_stts") = "FOLLOW UP" And hours >= 48 Then
                                commandshare("sp_upadte_escal1")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)

                                cmd1.ExecuteNonQuery()
                                commandshare("sp_update_hand_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.Parameters.AddWithValue("@hnd_stts", "HOD")
                                cmd1.ExecuteNonQuery()

                                commandshare("sp_chage_q_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.ExecuteNonQuery()

                                commandshare("sp_get_hod_by_dept_id")
                                cmd1.Parameters.AddWithValue("@dept_id", to_dept_id)
                                Dim this_email_id As String = ""
                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    dept_name = rdr1("dept_name")
                                    this_email_id = rdr1("email_id")
                                    t_to = rdr1("name_") & "(HOD)"
                                End If
                                commandshare("sp_get_loginer_details")
                                cmd1.Parameters.AddWithValue("@id", to_de)
                                '  Dim this_email_id As String = ""
                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then

                                    t_from = rdr1("name_") & "(DE)"
                                End If
                                commandshare("insert_escal_log")
                                cmd1.Parameters.AddWithValue("@disp_tid", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@escal_date", DateTime.Now)
                                cmd1.Parameters.AddWithValue("@t_from", t_from)
                                cmd1.Parameters.AddWithValue("@t_to", t_to)
                                cmd1.ExecuteNonQuery()
                                'escal log done 
                                commandshare("insert_penalty")
                                cmd1.Parameters.AddWithValue("@tick_id", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@user", t_from)
                                cmd1.ExecuteNonQuery()
                                commandshare("update_penalty1")
                                cmd1.Parameters.AddWithValue("@tid", disp_id)
                                cmd1.Parameters.AddWithValue("@penalty", 1)
                                cmd1.ExecuteNonQuery()
                                Try
                                    Call MailSend(this_email_id, "WebTradeNet: You Have Recieved a Escalated Query : " & disp_id, "You have Recieved Escalated Query . Subject :" & t_sub & "<br/>Department:" & dept_name & " <br/> From User:- " & t_from & "<br/> Date  Recieved To First User:-" & date_rec & "<br/> Issued by " & creater_name + "(" & creater_branch & ")", "Query Software")
                                Catch ex As Exception

                                End Try
                            ElseIf rdr1("now_hand_in") = "HOD" And rdr1("t_stts") = "FOLLOW UP" And hours >= 48 Then
                                commandshare("sp_upadte_escal2")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)

                                cmd1.ExecuteNonQuery()
                                commandshare("sp_get_hod_by_dept_id")
                                cmd1.Parameters.AddWithValue("@dept_id", to_dept_id)

                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    dept_name = rdr1("dept_name")
                                    t_from = rdr1("name_") & "(HOD)"
                                End If
                                rdr1.Close()

                                'commandshare("sp_update_hand_stts_by_tid")
                                'cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                'cmd1.Parameters.AddWithValue("@hnd_stts", "MNG")
                                'cmd1.ExecuteNonQuery()
                                If dept_name.Equals("CUSTOMERCARE") Then
                                    commandshare("sp_update_hand_stts_by_tid")
                                    cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                    cmd1.Parameters.AddWithValue("@hnd_stts", "SHOD")
                                    cmd1.ExecuteNonQuery()

                                Else

                                    commandshare("sp_update_hand_stts_by_tid")
                                    cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                    cmd1.Parameters.AddWithValue("@hnd_stts", "MNG")
                                    cmd1.ExecuteNonQuery()
                                End If
                                commandshare("sp_chage_q_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.ExecuteNonQuery()

                                'commandshare("sp_get_mng_email_by_tkt_id")
                                'cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)
                                'Dim this_email_id As String = ""
                                'rdr1 = cmd1.ExecuteReader
                                'If rdr1.Read Then
                                '    this_email_id = rdr1("email_id")
                                '    t_to = rdr1("name_") & "(MNG)"
                                'End If

                                Dim this_email_id As String = ""
                                If dept_name.Equals("CUSTOMERCARE") Then
                                    commandshare("sp_get_shod_email_by_tkt_id")
                                    cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)
                                    'Dim this_email_id As String = ""
                                    rdr1 = cmd1.ExecuteReader
                                    If rdr1.Read Then
                                        this_email_id = rdr1("email_id")
                                        t_to = rdr1("name_") & "(SHOD)"
                                    End If

                                Else

                                    commandshare("sp_get_mng_email_by_tkt_id")
                                    cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)

                                    rdr1 = cmd1.ExecuteReader
                                    If rdr1.Read Then
                                        this_email_id = rdr1("email_id")
                                        t_to = rdr1("name_") & "(MNG)"
                                    End If
                                End If





                                commandshare("sp_get_hod_by_dept_id")
                                cmd1.Parameters.AddWithValue("@dept_id", to_dept_id)

                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    dept_name = rdr1("dept_name")
                                    t_from = rdr1("name_") & "(HOD)"
                                End If
                                commandshare("insert_escal_log")
                                cmd1.Parameters.AddWithValue("@disp_tid", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@escal_date", DateTime.Now)
                                cmd1.Parameters.AddWithValue("@t_from", t_from)
                                cmd1.Parameters.AddWithValue("@t_to", t_to)
                                cmd1.ExecuteNonQuery()
                                'escal done
                                commandshare("insert_penalty")
                                cmd1.Parameters.AddWithValue("@tick_id", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@user", t_from)
                                cmd1.ExecuteNonQuery()
                                commandshare("update_penalty2")

                                cmd1.Parameters.AddWithValue("@tid", disp_id)
                                cmd1.Parameters.AddWithValue("@penalty", 1)
                                cmd1.ExecuteNonQuery()
                                Try
                                    Call MailSend(this_email_id, "WebTradeNet: You Have Recieved a Escalated Query : " & disp_id, "You have Recieved Escalated Query . Subject :" & t_sub & "<br/>Department:" & dept_name & " <br/> From User:- " & t_from & "<br/> Date  Recieved To First User:-" & date_rec & "<br/> Issued by " & creater_name & "(" & creater_branch & ")", "Query Software")
                                Catch ex As Exception

                                End Try
                            ElseIf rdr1("now_hand_in") = "SHOD" And rdr1("t_stts") = "UNSOLVED" And hours >= 24 Then
                                commandshare("sp_upadte_escal2")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)

                                cmd1.ExecuteNonQuery()
                                commandshare("sp_update_hand_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.Parameters.AddWithValue("@hnd_stts", "MNG")
                                cmd1.ExecuteNonQuery()

                                commandshare("sp_chage_q_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.ExecuteNonQuery()

                                commandshare("sp_get_mng_email_by_tkt_id")
                                cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)
                                Dim this_email_id As String = ""
                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    this_email_id = rdr1("email_id")
                                    t_to = rdr1("name_") & "(MNG)"
                                End If
                                commandshare("sp_get_hod_by_dept_id")
                                cmd1.Parameters.AddWithValue("@dept_id", to_dept_id)

                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    dept_name = rdr1("dept_name")
                                    t_from = "(SHOD)"
                                End If
                                commandshare("sp_get_shod_email_by_tkt_id")
                                cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)
                                'Dim this_email_id As String = ""
                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    ''   this_email_id = rdr1("email_id")
                                    t_from = rdr1("name_") & "(SHOD)"
                                End If
                                commandshare("insert_escal_log")
                                cmd1.Parameters.AddWithValue("@disp_tid", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@escal_date", DateTime.Now)
                                cmd1.Parameters.AddWithValue("@t_from", t_from)
                                cmd1.Parameters.AddWithValue("@t_to", t_to)
                                cmd1.ExecuteNonQuery()
                                'escal done
                                commandshare("insert_penalty")
                                cmd1.Parameters.AddWithValue("@tick_id", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@user", t_from)
                                cmd1.ExecuteNonQuery()
                                commandshare("update_penalty2")

                                cmd1.Parameters.AddWithValue("@tid", disp_id)
                                cmd1.Parameters.AddWithValue("@penalty", 1)
                                cmd1.ExecuteNonQuery()
                                Try
                                    Call MailSend(this_email_id, "WebTradeNet: You Have Recieved a Escalated Query : " & disp_id, "You have Recieved Escalated Query . Subject :" & t_sub & "<br/>Department:" & dept_name & " <br/> From User:- " & t_from & "<br/> Date  Recieved To First User:-" & date_rec & "<br/> Issued by " & creater_name & "(" & creater_branch & ")", "Query Software")
                                Catch ex As Exception

                                End Try
                            ElseIf rdr1("now_hand_in") = "SHOD" And rdr1("t_stts") = "FOLLOW UP" And hours >= 48 Then
                                commandshare("sp_upadte_escal2")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)

                                cmd1.ExecuteNonQuery()
                                commandshare("sp_update_hand_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.Parameters.AddWithValue("@hnd_stts", "MNG")
                                cmd1.ExecuteNonQuery()

                                commandshare("sp_chage_q_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.ExecuteNonQuery()

                                commandshare("sp_get_mng_email_by_tkt_id")
                                cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)
                                Dim this_email_id As String = ""
                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    this_email_id = rdr1("email_id")
                                    t_to = rdr1("name_") & "(MNG)"
                                End If
                                commandshare("sp_get_hod_by_dept_id")
                                cmd1.Parameters.AddWithValue("@dept_id", to_dept_id)

                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    dept_name = rdr1("dept_name")
                                    t_from = rdr1("name_") & "(SHOD)"
                                End If
                                commandshare("sp_get_shod_email_by_tkt_id")
                                cmd1.Parameters.AddWithValue("@tkt_id", ticket_id)
                                'Dim this_email_id As String = ""
                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    ''   this_email_id = rdr1("email_id")
                                    t_from = rdr1("name_") & "(SHOD)"
                                End If
                                commandshare("insert_escal_log")
                                cmd1.Parameters.AddWithValue("@disp_tid", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@escal_date", DateTime.Now)
                                cmd1.Parameters.AddWithValue("@t_from", t_from)
                                cmd1.Parameters.AddWithValue("@t_to", t_to)
                                cmd1.ExecuteNonQuery()
                                'escal done
                                commandshare("insert_penalty")
                                cmd1.Parameters.AddWithValue("@tick_id", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@user", t_from)
                                cmd1.ExecuteNonQuery()
                                commandshare("update_penalty2")

                                cmd1.Parameters.AddWithValue("@tid", disp_id)
                                cmd1.Parameters.AddWithValue("@penalty", 1)
                                cmd1.ExecuteNonQuery()
                                Try
                                    Call MailSend(this_email_id, "WebTradeNet: You Have Recieved a Escalated Query : " & disp_id, "You have Recieved Escalated Query . Subject :" & t_sub & "<br/>Department:" & dept_name & " <br/> From User:- " & t_from & "<br/> Date  Recieved To First User:-" & date_rec & "<br/> Issued by " & creater_name & "(" & creater_branch & ")", "Query Software")
                                Catch ex As Exception

                                End Try
                            ElseIf rdr1("now_hand_in") = "DE" And rdr1("t_stts") = "UNSOLVED" And hours >= 24 Then
                                commandshare("sp_upadte_escal1")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.ExecuteNonQuery()
                                commandshare("sp_update_hand_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.Parameters.AddWithValue("@hnd_stts", "HOD")
                                cmd1.ExecuteNonQuery()

                                commandshare("sp_chage_q_stts_by_tid")
                                cmd1.Parameters.AddWithValue("@tid", ticket_id)
                                cmd1.ExecuteNonQuery()

                                commandshare("sp_get_hod_by_dept_id")
                                cmd1.Parameters.AddWithValue("@dept_id", to_dept_id)
                                Dim this_email_id As String = ""
                                rdr1 = cmd1.ExecuteReader
                                If rdr1.Read Then
                                    dept_name = rdr1("dept_name")
                                    this_email_id = rdr1("email_id")
                                    t_to = rdr1("name_") & "(HOD)"
                                End If
                                commandshare("sp_get_loginer_details")
                                cmd1.Parameters.AddWithValue("@id", to_de)
                                '  Dim this_email_id As String = ""
                                rdr1 = cmd1.ExecuteReader

                                If rdr1.Read Then

                                    t_from = rdr1("name_") & "(DE)"
                                End If
                                commandshare("insert_escal_log")
                                cmd1.Parameters.AddWithValue("@disp_tid", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@escal_date", DateTime.Now)
                                cmd1.Parameters.AddWithValue("@t_from", t_from)
                                cmd1.Parameters.AddWithValue("@t_to", t_to)
                                cmd1.ExecuteNonQuery()
                                'escal log done 
                                commandshare("insert_penalty")
                                cmd1.Parameters.AddWithValue("@tick_id", disp_id)
                                cmd1.Parameters.AddWithValue("@dept", dept_name)
                                cmd1.Parameters.AddWithValue("@t_sub", t_sub)
                                cmd1.Parameters.AddWithValue("@user", t_from)
                                cmd1.ExecuteNonQuery()
                                commandshare("update_penalty1")
                                cmd1.Parameters.AddWithValue("@tid", disp_id)
                                cmd1.Parameters.AddWithValue("@penalty", "1")
                                cmd1.ExecuteNonQuery()
                                Try
                                    Call MailSend(this_email_id, "WebTradeNet: You Have Recieved a Escalated Query : " & disp_id, "You have Recieved Escalated Query . Subject :" & t_sub & "<br/>Department:" & dept_name & " <br/> From User:- " & t_from & "<br/> Date  Recieved To First User:-" & date_rec + "<br/> Issued by " + creater_name + "(" + creater_branch + ")", "Query Software")
                                Catch ex As Exception

                                End Try
                            End If
                        End If

                    End If

                    i = i + 1
                End While




            Catch ex As Exception

            End Try


            '**************PENALTY INCREAMENT
            Dim dt As System.Data.DataTable
            rdr1.Close()
            'SqlCon.Close()
            'SqlCon.Open()

            dt = New System.Data.DataTable()
            commandshare("select_penalty_all")
            rdr1 = cmd1.ExecuteReader
            If rdr1.HasRows Then
                dt.Load(rdr1)
            End If



            Dim increment As Integer = 0


            For Each row As DataRow In dt.Rows
                Dim user As String = row.Item("User")

                Dim pnltydate As DateTime = row.Item("pnlty_date")

                Dim penalty As Integer = row.Item("penalty")

                Dim tid As Integer = row.Item("tick_id")

                Dim date1 As String = pnltydate.ToString("HH:mm")
                Dim date2 As String = DateTime.Now.ToString(("HH:mm"))

                '     Dim hour As Integer=DateTime.Now.Hour-
                Dim fulldate1 As String = pnltydate.ToString("MM/dd/yyyy HH:mm")
                Dim fulldate2 As String = DateTime.Now.ToString("MM/dd/yyyy HH:mm")
                If fulldate1 <> fulldate2 Then


                    If (date1.Equals(date2)) Then
                        commandshare("update_penalty")
                        cmd1.Parameters.AddWithValue("@tid", tid)
                        cmd1.Parameters.AddWithValue("@user", user)
                        penalty = penalty + 1
                        cmd1.Parameters.AddWithValue("@penalty", penalty)
                        cmd1.ExecuteNonQuery()
                        If user.Contains("DE") Then
                            commandshare("update_penalty1")
                            cmd1.Parameters.AddWithValue("@tid", tid)
                            cmd1.Parameters.AddWithValue("@penalty", penalty)
                            cmd1.ExecuteNonQuery()
                        Else
                            commandshare("update_penalty2")

                            cmd1.Parameters.AddWithValue("@tid", tid)
                            cmd1.Parameters.AddWithValue("@penalty", penalty)
                            cmd1.ExecuteNonQuery()
                        End If


                    End If
                End If
            Next row




        End Sub
        Public Sub FillList(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByVal strCmd As String, Optional ByVal i As Integer = 0, Optional ByVal fld As Integer = 0, Optional ByVal strHead As String = "Select")
            Dim objCon As New projecterNM.projectercon
            Dim cmd As New SqlCommand
            Dim rdr As SqlDataReader
            cmd.Connection = objCon.ConObj
            cmd.CommandText = strCmd
            ddl.Items.Add(New ListItem(strHead, " "))
            rdr = cmd.ExecuteReader
            Dim j As Integer
            ddl.Items.Clear()
            ddl.Items.Add(New ListItem("Select", "0"))
            While rdr.Read
                If fld <> 0 Then
                    'inavaDa
                    ddl.Items.Add(New ListItem(rdr(fld), rdr(0)))
                Else
                    ddl.Items.Add(New ListItem(rdr(1), rdr(0)))
                End If

                If i <> 0 Then
                    If rdr(0) = i Then
                        ddl.Items(j + 1).Selected = True
                    End If
                End If
                j += 1
            End While
            rdr.Close()
            cmd.Dispose()

        End Sub
        Public Shared Sub auto_mail()
            Dim strim As String = ""
            Dim this_stts As String = "Solved"
            Dim arr_tot_depts As Integer = 0
            Dim i As Integer = 0


            commandshare("sp_get_all_depts")
            rdr1 = cmd1.ExecuteReader
            While rdr1.Read
                arr_tot_depts = arr_tot_depts + 1
            End While
            Dim depts(arr_tot_depts + 1) As Integer
            Dim depts_hods_email(arr_tot_depts + 1) As String
            commandshare("sp_get_all_depts")
            rdr1 = cmd1.ExecuteReader
            While rdr1.Read
                depts(i) = rdr1("id")
                depts_hods_email(i) = rdr1("email_id")
                i = i + 1
            End While
            i = 0
            While i <= arr_tot_depts

                strim = ""
                strim &= " <table width=""100%"" border=""1"">"
                strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
                strim &= "	            <td style=""width:9%"" colspan=""7"">"
                strim &= ""
                strim &= "	            </td>"
                strim &= "	        </tr>"
                strim &= "<tr class=""updater_mid_tr_spl"">"
                strim &= "<td width=""10%"">"
                strim &= "<b>Ticket ID</b>"
                strim &= "</td>"
                strim &= "<td width=""35%"">"
                strim &= "<b>Subject</b>"
                strim &= "</td>"
                strim &= "<td width=""7%"">"
                strim &= "<b>Type</b>"
                strim &= "</td>"
                strim &= "</td>"
                strim &= "<td width=""10%"">"
                strim &= "<b>Follower</b>"
                strim &= "</td>"
                strim &= "<td width=""10%"">"
                strim &= "<b>From</b>"
                strim &= "</td>"
                strim &= "<td width=""10%"">"
                strim &= "<b>To</b>"
                strim &= "</td>"
                strim &= "<td width=""10%"">"
                strim &= "<b>Date</b>"
                strim &= "</td>"
                strim &= "<td width=""10%""> "
                strim &= "<b>Status</b>"
                strim &= "</td>"
                strim &= "</tr>"

                commandshare("sp_view_all_queryes_2")
                ' cmd1.Parameters.AddWithValue("@t_stts", this_stts)
                cmd1.Parameters.AddWithValue("@q_typ", "%%")
                cmd1.Parameters.AddWithValue("@to_dept_id", depts(i))
                rdr1 = cmd1.ExecuteReader
                While rdr1.Read
                    strim &= "	        <tr >"
                    strim &= "	            <td >"
                    strim &= rdr1("disp_id")
                    strim &= "	            </td>"
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= rdr1("t_sub")
                    strim &= "	            </td>"
                    strim &= "<td width=""5%"">"
                    If rdr1("q_typ") = "NORMAL" Then
                        strim &= "NORMAL"
                    ElseIf rdr1("q_typ") = "Transferred" Or rdr1("q_typ") = "TRANSFERED" Then
                        strim &= "TRANSFERED"
                    ElseIf rdr1("q_typ") = "ESCALATED" Then
                        strim &= "ESCALATED"
                    ElseIf rdr1("q_typ") = "DELETE" Or rdr1("q_typ") = "DELETED" Then
                        strim &= "DELETE"
                    End If
                    strim &= "</td>"

                    strim &= "	            <td >"
                    strim &= rdr1("now_hand_in")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr1("branch_name") & "<br>(" & rdr1("auther") & ")"
                    strim &= "	            </td>"
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= rdr1("dept_name") & "<br>(" & rdr1("username_") & ")"
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr1("last_update_date")
                    strim &= "	            </td>"
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= rdr1("t_stts")
                    strim &= "	            </td>"
                    strim &= "	        </tr>"


                End While
                strim &= "</table>"
                Call MailSend(depts_hods_email(i), "Todays Unsolved Tickets (" & Today() & ")", strim, "Query Software")

                i = i + 1
            End While


            '============================ to BH ==================
            Dim tot_branch_ As Integer = 0
            i = 0
            strim = ""

            commandshare("sp_get_BH_email")
            rdr1 = cmd1.ExecuteReader
            While rdr1.Read
                tot_branch_ = tot_branch_ + 1
            End While


            Dim branch_ids(tot_branch_ + 1) As Integer
            Dim branch_mngr_emails(tot_branch_ + 1) As String

            commandshare("sp_get_BH_email")
            rdr1 = cmd1.ExecuteReader
            While rdr1.Read
                branch_ids(i) = rdr1("branch_id")
                branch_mngr_emails(i) = rdr1("email_id")
                i = i + 1
            End While
            i = 0
            While i <= tot_branch_
                strim = ""
                strim &= " <table width=""100%"" border=""1"">"
                strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
                strim &= "	            <td style=""width:9%"" colspan=""7"">"
                strim &= ""
                strim &= "	            </td>"
                strim &= "	        </tr>"
                strim &= "<tr class=""updater_mid_tr_spl"">"
                strim &= "<td width=""10%"">"
                strim &= "<b>Ticket ID</b>"
                strim &= "</td>"
                strim &= "<td width=""35%"">"
                strim &= "<b>Subject</b>"
                strim &= "</td>"
                strim &= "<td width=""5%"">"
                strim &= "<b>Type</b>"
                strim &= "</td>"
                strim &= "</td>"
                strim &= "<td width=""10%"">"
                strim &= "<b>Follower</b>"
                strim &= "</td>"
                strim &= "<td width=""10%"">"
                strim &= "<b>From</b>"
                strim &= "</td>"
                strim &= "<td width=""10%"">"
                strim &= "<b>To</b>"
                strim &= "</td>"

                strim &= "<td width=""10%""> "
                strim &= "<b>Status</b>"
                strim &= "</td>"
                strim &= "</tr>"

                commandshare("sp_view_all_queryes_to_BH")

                cmd1.Parameters.AddWithValue("@from_branch_id", branch_ids(i))

                rdr1 = cmd1.ExecuteReader
                While rdr1.Read
                    strim &= "	        <tr >"
                    strim &= "	            <td >"
                    strim &= rdr1("disp_id")
                    strim &= "	            </td>"
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= rdr1("t_sub")
                    strim &= "	            </td>"
                    strim &= "<td width=""5%"">"
                    If rdr1("q_typ") = "NORMAL" Then
                        strim &= "NORMAL"
                    ElseIf rdr1("q_typ") = "Transferred" Or rdr1("q_typ") = "TRANSFERED" Then
                        strim &= "TRANSFERED"
                    ElseIf rdr1("q_typ") = "ESCALATED" Then
                        strim &= "ESCALATED"
                    ElseIf rdr1("q_typ") = "DELETE" Or rdr1("q_typ") = "DELETED" Then
                        strim &= "DELETE"
                    End If
                    strim &= "</td>"

                    strim &= "	            <td >"
                    strim &= rdr1("now_hand_in")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr1("branch_name") & "<br>(" & rdr1("auther") & ")"
                    strim &= "	            </td>"
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= rdr1("dept_name") & "<br>(" & rdr1("username_") & ")"
                    strim &= "	            </td>"

                    strim &= "	            <td class=""date_ticks"">"
                    strim &= rdr1("t_stts")
                    strim &= "	            </td>"
                    strim &= "	        </tr>"

                End While
                strim &= "</table>"
                Call MailSend(branch_mngr_emails(i), "Todays Unsolved Tickets (" & Today() & ")", strim, "Query Software")
                i = i + 1
            End While


        End Sub

        Public Sub sp_err_curr_1()
            command("sp_err_curr_1")
            cmd.ExecuteNonQuery()
        End Sub
        Public Shared Function MailSend(ByVal MailTo As String, ByVal MailSubject As String, ByVal MailBody As String, ByVal sender As String, Optional ByVal AttachedFileName As String = "") As Boolean
            Dim objEmail As New Mail.MailMessage()
            Dim smtpMail As New Mail.SmtpClient
            Dim AttachedFile As Mail.Attachment
            If (MailTo.Contains("tradenetstockbroking.in")) Then

                smtpMail.Port = 25
                smtpMail.Credentials = New System.Net.NetworkCredential("query@tradenetstockbroking.in", "query12") 'New System.Net.NetworkCredential("info@dattadoor.com", "123456")
                'smtpMail.Host = "123.252.207.39" '"mail.dattadoor.com" '"smtp.gmail.com
                smtpMail.Host = "10.53.251.9" '"mail.dattadoor.com" '"smtp.gmail.com
                objEmail.From = New Mail.MailAddress("query@tradenetstockbroking.in", sender)

            Else
                smtpMail.Port = 25
                smtpMail.Credentials = New System.Net.NetworkCredential("query@tradenetstockbroking.com", "que123") 'New System.Net.NetworkCredential("info@dattadoor.com", "123456")
                smtpMail.Host = "tradenetstockbroking.com" '"mail.dattadoor.com" '"smtp.gmail.com
                objEmail.From = New Mail.MailAddress("query@tradenetstockbroking.com", sender)

            End If
            Try
                objEmail.Bcc.Add("techsupport2@tradenetstockbroking.in")

                objEmail.To.Add(MailTo)
            Catch ex As Exception

            End Try

            'objEmail.CC.Add("ccare03@tradenetstockbroking.in")
            If AttachedFileName.ToString <> "" Then
                AttachedFile = New Mail.Attachment(AttachedFileName)
                objEmail.Attachments.Add(AttachedFile)
            End If
            objEmail.Subject = MailSubject
            objEmail.IsBodyHtml = True
            objEmail.Body = MailBody
            objEmail.Priority = Mail.MailPriority.High
            Try
                smtpMail.Send(objEmail)
            Catch ex As Exception
            End Try
            Return True
        End Function

        'Public Sub automailing()
        '    Dim strim As String = ""
        '    Dim mng_id As Integer
        '    Dim this_stts As String = "UnSolved"
        '    Dim arr_tot_depts As Integer = 0
        '    Dim i As Integer = 0
        '    Dim date_from As Date = "23/11/1990"
        '    Dim date_to As Date = Now

        '    date_from = Today() & " 01:01:01"
        '    date_to = Today() & " 23:59:59"

        '    command("sp_get_all_depts")
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        arr_tot_depts = arr_tot_depts + 1
        '    End While
        '    Dim depts(arr_tot_depts + 1) As Integer
        '    Dim depts_hods_email(arr_tot_depts + 1) As String
        '    command("sp_get_all_depts")
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        depts(i) = rdr("id")
        '        depts_hods_email(i) = rdr("email_id")
        '        i = i + 1
        '    End While
        '    i = 0
        '    While i <= arr_tot_depts
        '        strim &= " <table width=""100%"" border=""1"">"
        '        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        '        strim &= "	            <td style=""width:9%"" colspan=""7"">"
        '        strim &= "Running Ticktes Till - " & Today()
        '        strim &= "	            </td>"
        '        strim &= "	        </tr>"
        '        strim &= "<tr class=""updater_mid_tr_spl"">"
        '        strim &= "<td width=""10%"">"
        '        strim &= "Ticket ID"
        '        strim &= "</td>"
        '        strim &= "<td width=""35%"">"
        '        strim &= "Subject"
        '        strim &= "</td>"
        '        strim &= "<td width=""5%"">"
        '        strim &= "TYP"
        '        strim &= "</td>"
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"">"
        '        strim &= "Follower"
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"">"
        '        strim &= "From"
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"">"
        '        strim &= "To"
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"">"
        '        strim &= "Date"
        '        strim &= "</td>"
        '        strim &= "<td width=""10%""> "
        '        strim &= "Status"
        '        strim &= "</td>"
        '        strim &= "</tr>"

        '        command("sp_view_all_queryes")
        '        cmd.Parameters.AddWithValue("@t_stts", this_stts)
        '        cmd.Parameters.AddWithValue("@date_from", date_from)
        '        cmd.Parameters.AddWithValue("@date_to", date_to)
        '        cmd.Parameters.AddWithValue("@q_typ", "%%")
        '        cmd.Parameters.AddWithValue("@to_dept_id", depts(i))
        '        rdr = cmd.ExecuteReader
        '        While rdr.Read
        '            strim &= "	        <tr >"
        '            strim &= "	            <td >"
        '            strim &= rdr("disp_id")
        '            strim &= "	            </td>"
        '            strim &= "	            <td class=""date_ticks"">"
        '            strim &= rdr("t_sub")
        '            strim &= "	            </td>"
        '            strim &= "<td width=""5%"">"
        '            If rdr("q_typ") = "NORMAL" Then
        '                strim &= "NORMAL"
        '            ElseIf rdr("q_typ") = "Transferred" Or rdr("q_typ") = "TRANSFERED" Then
        '                strim &= "TRANSFERED"
        '            ElseIf rdr("q_typ") = "ESCALATED" Then
        '                strim &= "ESCALATED"
        '            ElseIf rdr("q_typ") = "DELETE" Or rdr("q_typ") = "DELETED" Then
        '                strim &= "DELETE"
        '            End If
        '            strim &= "</td>"

        '            strim &= "	            <td >"
        '            strim &= rdr("now_hand_in")
        '            strim &= "	            </td>"
        '            strim &= "	            <td  class=""date_ticks"">"
        '            strim &= rdr("branch_name") & "<br>(" & rdr("auther") & ")"
        '            strim &= "	            </td>"
        '            strim &= "	            <td class=""date_ticks"">"
        '            strim &= rdr("dept_name") & "<br>(" & rdr("username_") & ")"
        '            strim &= "	            </td>"
        '            strim &= "	            <td  class=""date_ticks"">"
        '            strim &= rdr("last_update_date")
        '            strim &= "	            </td>"
        '            strim &= "	            <td class=""date_ticks"">"
        '            strim &= rdr("t_stts")
        '            strim &= "	            </td>"
        '            strim &= "	        </tr>"

        '        End While


        '        i = i + 1
        '    End While


        '    '===============================================================
        '    Dim tot_arr As Integer = 0

        '    Dim heading_ As String = ""
        '    Dim typ As String

        '    typ = "%%"

        '    'Dim date_from As Date = "23/11/1990"
        '    'Dim date_to As Date = Now
        '    Dim dept_id As String







        '    heading_ &= " -Till " & Now()


        '    Dim dept_id_(tot_arr + 1) As Integer
        '    'Dim i As Integer = 0




        '    command("sp_get_depts_by_mng_id")
        '    cmd.Parameters.AddWithValue("@mng_id", mng_id)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        dept_id_(i) = rdr("dept_id")
        '        i = i + 1
        '    End While



        '    i = 0

        '    strim &= " <table width=""100%"" border=""1"">"
        '    strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        '    strim &= "	            <td style=""width:9%"" colspan=""7"">"
        '    strim &= "Running Ticktes Till - " & Today()
        '    strim &= "	            </td>"
        '    strim &= "	        </tr>"
        '    strim &= "<tr class=""updater_mid_tr_spl"">"
        '    strim &= "<td width=""10%"">"
        '    strim &= "Ticket ID"
        '    strim &= "</td>"
        '    strim &= "<td width=""35%"">"
        '    strim &= "Subject"
        '    strim &= "</td>"
        '    strim &= "<td width=""5%"">"
        '    strim &= "TYP"
        '    strim &= "</td>"
        '    strim &= "</td>"
        '    strim &= "<td width=""10%"">"
        '    strim &= "Follower"
        '    strim &= "</td>"
        '    strim &= "<td width=""10%"">"
        '    strim &= "From"
        '    strim &= "</td>"
        '    strim &= "<td width=""10%"">"
        '    strim &= "To"
        '    strim &= "</td>"
        '    strim &= "<td width=""10%"">"
        '    strim &= "Date"
        '    strim &= "</td>"
        '    strim &= "<td width=""10%""> "
        '    strim &= "Status"
        '    strim &= "</td>"
        '    strim &= "</tr>"

        '    command("sp_view_all_queryes")
        '    cmd.Parameters.AddWithValue("@t_stts", this_stts)
        '    cmd.Parameters.AddWithValue("@date_from", date_from)
        '    cmd.Parameters.AddWithValue("@date_to", date_to)
        '    cmd.Parameters.AddWithValue("@q_typ", q_typ)
        '    cmd.Parameters.AddWithValue("@to_dept_id", dept_id)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read

        '        strim &= "	        <tr >"
        '        strim &= "	            <td >"
        '        strim &= rdr("disp_id")
        '        strim &= "	            </td>"
        '        strim &= "	            <td class=""date_ticks"">"
        '        strim &= rdr("t_sub")
        '        strim &= "	            </td>"
        '        strim &= "<td width=""5%"">"
        '        If rdr("q_typ") = "NORMAL" Then
        '            strim &= "NORMAL"
        '        ElseIf rdr("q_typ") = "Transferred" Or rdr("q_typ") = "TRANSFERED" Then
        '            strim &= "TRANSFERED"
        '        ElseIf rdr("q_typ") = "ESCALATED" Then
        '            strim &= "ESCALATED"
        '        ElseIf rdr("q_typ") = "DELETE" Or rdr("q_typ") = "DELETED" Then
        '            strim &= "DELETE"
        '        End If
        '        strim &= "</td>"

        '        strim &= "	            <td >"
        '        strim &= rdr("now_hand_in")
        '        strim &= "	            </td>"
        '        strim &= "	            <td  class=""date_ticks"">"
        '        strim &= rdr("branch_name") & "<br>(" & rdr("auther") & ")"
        '        strim &= "	            </td>"
        '        strim &= "	            <td class=""date_ticks"">"
        '        strim &= rdr("dept_name") & "<br>(" & rdr("username_") & ")"
        '        strim &= "	            </td>"
        '        strim &= "	            <td  class=""date_ticks"">"
        '        strim &= rdr("last_update_date")
        '        strim &= "	            </td>"
        '        strim &= "	            <td class=""date_ticks"">"
        '        strim &= rdr("t_stts")
        '        strim &= "	            </td>"
        '        strim &= "	        </tr>"

        '    End While
        '    i = i + 1




        '    strim &= "	    </table>"

        '    System.we()
        '    Response.ContentType = "application/xls"
        '    Response.AddHeader("content-disposition", "attachment;filename=" & Now.Year() & Now.Month() & Now.Day() & ".xls")
        '    Response.Charset = ""
        '    Dim tw As New System.IO.StringWriter()
        '    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        '    Dim frm As HtmlForm = New HtmlForm()
        '    Me.Controls.Add(frm)
        '    frm.RenderControl(hw)
        '    Response.Write("<h5>" & heading_ & "</h5>")
        '    Response.Write(strim)
        '    tw.Write("hi2")
        '    Response.End()
        'End Sub


        ' EOD mail for tasks


        Public Shared Sub TaskEOD_Mail_creator()
            constringTodo()
            SqlCon = New SqlConnection(ConTodo)
            Dim dttasks As New DataTable

            SqlCon.Open()
            cmd1 = New SqlCommand
            cmd1.Connection = SqlCon
            cmd1.CommandText = "select distinct creator from t_m_task where Status!='S' and enddate<=getdate() "
            rdr1 = cmd1.ExecuteReader
            If rdr1.HasRows Then


                dttasks.Load(rdr1)

            End If

            rdr1.Close()

            For Each drw As DataRow In dttasks.Rows
                ' Dim creator_name As String = ""
                Dim creator_name As String = ""
                Dim creator_email As String = ""
                Dim creator As String = ""
                'cmd1 = New SqlCommand
                'cmd1.Connection = SqlCon
                'cmd1.CommandText = "select name,email_id  from t_m_login  where id='" + drw("creator").ToString + "'  "
                'rdr1 = cmd1.ExecuteReader
                'If rdr1.HasRows Then

                '    rdr1.Read()
                '    creator_name = rdr1("name").ToString
                '    creator_email = rdr1("email_id").ToString


                'End If

                rdr1.Close()
                cmd1 = New SqlCommand
                cmd1.Connection = SqlCon
                cmd1.CommandText = "select name,email_id  from t_m_login  where id='" + drw("creator").ToString + "'  "
                rdr1 = cmd1.ExecuteReader
                If rdr1.HasRows Then

                    rdr1.Read()
                    creator_name = rdr1("name").ToString
                    creator = rdr1("email_id").ToString


                End If
                rdr1.Close()

                Dim dtOverdue As New DataTable

                cmd1 = New SqlCommand
                cmd1.Connection = SqlCon
                '  cmd1.CommandText = "select  id,subject,descp from t_m_task where Status!='S' and  Status!='C' and enddate<=getdate() and creator='" + drw("creator").ToString + "'  "
                cmd1.CommandText = "select  tmt.id,tmt.subject,tmt.descp, tmt.enddate,tml.name as assinged_to from t_m_task tmt,t_m_login tml where tmt.Status!='S' and  tmt.Status!='C' and tmt.enddate<=getdate() and tmt.creator='" + drw("creator").ToString + "' and tmt.assign_to=tml.id "

                rdr1 = cmd1.ExecuteReader
                If rdr1.HasRows Then


                    dtOverdue.Load(rdr1)

                End If

                rdr1.Close()

                Dim tasks As String

                tasks = DataTableToHTMLTable(dtOverdue).ToUpper()


                'If (creator_email.Equals(assign_to_email)) Then
                '    MailSend(assign_to_email, "Task:-" + drw("id").ToString + " Subject:-" + drw("subject").ToString + " OverDue ", "Dear " + assign_to_name + ",<br/>" + "Task " + drw("subject").ToString + " Assigned To You By YourSelf  is overdue ", "Task Overdue")

                'Else
                'MailSend(creator_email, "Task:-" + drw("id").ToString + " Subject:-" + drw("subject").ToString + " OverDue ", "Dear " + creator_name + ",<br/>" + "Task " + drw("subject").ToString + " Assigned To " + assign_to_name + " By You is overdue", "Task Overdue")
                If dtOverdue.Rows.Count > 0 Then
                    MailSend(creator, "Todays OverDue/Unsolved Task assigned by You  " + creator_name, "Dear " + creator_name + ",<br/>" + "Following  Tasks assigned by you are pending to you<br/> " + tasks, "Task Overdue")

                End If

                'End If

                rdr1.Close()
                'cmd1 = New SqlCommand
                'cmd1.Connection = SqlCon
                'cmd1.CommandText = "update     t_m_task set Status='O'   where Status='U' and id=" + drw("id").ToString + " and enddate<=getdate() "
                'cmd1.ExecuteNonQuery()
                'cmd1 = New SqlCommand
                'cmd1.Connection = SqlCon
                'cmd1.CommandText = "insert into t_m_task_overdue values ('" + drw("id").ToString + "','" + drw("enddate").ToString + "','" + drw("creator").ToString + "','" + drw("assign_to").ToString + "','" + drw("usertype").ToString + "','" + drw("branch").ToString + "','" + drw("dept").ToString + "','" + drw("priority").ToString + "','" + drw("subject").ToString + "','" + drw("descp").ToString + "','O')"
                'cmd1.ExecuteNonQuery()

                ''id
                '  ' enddate()
                '  creator()
                '  assign_to()
                '  usertype()
                '  branch()
                '  dept()
                '  priority()
                '  subject()
                '  descp()
                '  Status



            Next




            '()
            'enddate()
            '()
            '()
            '()
            'branch()
            'dept()
            'priority()
            '()
            '()
            'Status
            'SolvedDate()


            SqlCon.Close()

        End Sub


        Public Shared Sub TaskEOD_Mail_assign_to()
            constringTodo()
            SqlCon = New SqlConnection(ConTodo)
            Dim dttasks As New DataTable

            SqlCon.Open()
            cmd1 = New SqlCommand
            cmd1.Connection = SqlCon
            cmd1.CommandText = "select distinct assign_to from t_m_task where Status!='S' and enddate<=getdate() "
            rdr1 = cmd1.ExecuteReader
            If rdr1.HasRows Then


                dttasks.Load(rdr1)

            End If

            rdr1.Close()

            For Each drw As DataRow In dttasks.Rows
                Dim creator_name As String = ""
                Dim assign_to_name As String = ""
                Dim creator_email As String = ""
                Dim assign_to_email As String = ""
                'cmd1 = New SqlCommand
                'cmd1.Connection = SqlCon
                'cmd1.CommandText = "select name,email_id  from t_m_login  where id='" + drw("creator").ToString + "'  "
                'rdr1 = cmd1.ExecuteReader
                'If rdr1.HasRows Then

                '    rdr1.Read()
                '    creator_name = rdr1("name").ToString
                '    creator_email = rdr1("email_id").ToString


                'End If

                rdr1.Close()
                cmd1 = New SqlCommand
                cmd1.Connection = SqlCon
                cmd1.CommandText = "select name,email_id  from t_m_login  where id='" + drw("assign_to").ToString + "'  "
                rdr1 = cmd1.ExecuteReader
                If rdr1.HasRows Then

                    rdr1.Read()
                    assign_to_name = rdr1("name").ToString
                    assign_to_email = rdr1("email_id").ToString


                End If
                rdr1.Close()

                Dim dtOverdue As New DataTable

                cmd1 = New SqlCommand
                cmd1.Connection = SqlCon
                '                cmd1.CommandText = "select  id,subject,descp from t_m_task where Status!='S' and  Status!='C' and enddate<=getdate() and assign_to='" + drw("assign_to").ToString + "'  "
                cmd1.CommandText = "select  tmt.id,tmt.subject,tmt.descp, tmt.enddate,tml.name as assined_by from t_m_task tmt,t_m_login tml where tmt.Status!='S' and  tmt.Status!='C' and tmt.enddate<=getdate() and tmt.assign_to='" + drw("assign_to").ToString + "' and tmt.creator=tml.id  "

                rdr1 = cmd1.ExecuteReader
                If rdr1.HasRows Then


                    dtOverdue.Load(rdr1)

                End If

                rdr1.Close()

                Dim tasks As String

                tasks = DataTableToHTMLTable(dtOverdue).ToUpper()


                'If (creator_email.Equals(assign_to_email)) Then
                '    MailSend(assign_to_email, "Task:-" + drw("id").ToString + " Subject:-" + drw("subject").ToString + " OverDue ", "Dear " + assign_to_name + ",<br/>" + "Task " + drw("subject").ToString + " Assigned To You By YourSelf  is overdue ", "Task Overdue")

                'Else
                'MailSend(creator_email, "Task:-" + drw("id").ToString + " Subject:-" + drw("subject").ToString + " OverDue ", "Dear " + creator_name + ",<br/>" + "Task " + drw("subject").ToString + " Assigned To " + assign_to_name + " By You is overdue", "Task Overdue")
                If dtOverdue.Rows.Count > 0 Then
                    MailSend(assign_to_email, "Todays OverDue/Unsolved Task assigned to you..  " + assign_to_name, "Dear " + assign_to_name + ",<br/>" + "Following  Tasks are pending to you<br/> " + tasks, "Task Overdue")

                End If

                'End If

                rdr1.Close()
                'cmd1 = New SqlCommand
                'cmd1.Connection = SqlCon
                'cmd1.CommandText = "update     t_m_task set Status='O'   where Status='U' and id=" + drw("id").ToString + " and enddate<=getdate() "
                'cmd1.ExecuteNonQuery()
                'cmd1 = New SqlCommand
                'cmd1.Connection = SqlCon
                'cmd1.CommandText = "insert into t_m_task_overdue values ('" + drw("id").ToString + "','" + drw("enddate").ToString + "','" + drw("creator").ToString + "','" + drw("assign_to").ToString + "','" + drw("usertype").ToString + "','" + drw("branch").ToString + "','" + drw("dept").ToString + "','" + drw("priority").ToString + "','" + drw("subject").ToString + "','" + drw("descp").ToString + "','O')"
                'cmd1.ExecuteNonQuery()

                ''id
                '  ' enddate()
                '  creator()
                '  assign_to()
                '  usertype()
                '  branch()
                '  dept()
                '  priority()
                '  subject()
                '  descp()
                '  Status



            Next




            '()
            'enddate()
            '()
            '()
            '()
            'branch()
            'dept()
            'priority()
            '()
            '()
            'Status
            'SolvedDate()


            SqlCon.Close()

        End Sub


        Public Shared Function DataTableToHTMLTable(ByVal inTable As DataTable) As String
            Dim dString As New StringBuilder
            dString.Append("<table cellspacing='0'>")
            dString.Append(GetHeader(inTable))
            dString.Append(GetBody(inTable))
            dString.Append("</table>")
            Return dString.ToString
        End Function

        Private Shared Function GetHeader(ByVal dTable As DataTable) As String
            Dim dString As New StringBuilder

            dString.Append("<thead style='border: 1px solid #000000'><tr style='border: 1px solid #000000'>")
            For Each dColumn As DataColumn In dTable.Columns
                dString.AppendFormat("<th style='border: 1px solid #000000'>{0}</th>", dColumn.ColumnName)
            Next
            dString.Append("</tr></thead>")

            Return dString.ToString
        End Function

        Private Shared Function GetBody(ByVal dTable As DataTable) As String
            Dim dString As New StringBuilder

            dString.Append("<tbody style='border: 1px solid #000000'>")

            For Each dRow As DataRow In dTable.Rows
                dString.Append("<tr style='border: 1px solid #000000'>")
                For dCount As Integer = 0 To dTable.Columns.Count - 1
                    dString.AppendFormat("<td style='border: 1px solid #000000'>{0}</td>", dRow(dCount))
                Next
                dString.Append("</tr>")
            Next
            dString.Append("</tbody>")

            Return dString.ToString()
        End Function


        '
        '
        '
        '







    End Class
End Namespace
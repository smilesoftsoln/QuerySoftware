Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace somman_functions_NM
    Public Class commen_funcs
        Dim weldone_con As New projecterNM.projectercon
        Dim cmd As New SqlCommand
        Dim rdr As SqlDataReader
        Dim cmd3 As New SqlCommand
        Dim rdr3 As SqlDataReader
        Dim loginerID As Integer
        Sub command(ByVal strcmd As String)
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.CommandText = strcmd
            cmd.Connection = weldone_con.ConObj
            cmd.Parameters.Clear()
        End Sub
        Sub command3(ByVal strcmd As String)
            cmd3.CommandType = Data.CommandType.StoredProcedure
            cmd3.CommandText = strcmd
            cmd3.Connection = weldone_con.ConObj
            cmd3.Parameters.Clear()
        End Sub

        Public Function alerts()
            Dim strim As String = ""
            Dim i As Integer = 0
            command("sp_get_alert_from_loginer")
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "<p><u>Paniding User info</u> :<br> for user <i><b>" & rdr("name_") & " (" & rdr("post_") & ") </i></b> Some Feilds Are Empty <br>"
                strim &= "<a href=""add_new_user_stape_2.aspx?loginerID=" & rdr("id") & "&post_=" & rdr("post_") & "&Documents and Settings/Sri Sri/My Documents/Down_18_12_2010/Call Center India, call center outsourcing, call center service, Inbound call center.htm"">Fix Issue</a></p>"
                i = i + 1
            End While

            command("sp_get_alert_from_dept")
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "<p><u>HOD Less Department</u> :<br> For the <i><b>" & rdr("dept_name") & " </i></b> HOD Not mentioned<br>"
                strim &= "<a href=""Assign_Exist_HOD.aspx"">Assign Existing HOD</a><a href=""Assign_Exist_HOD.aspx"">Create HOD</a></p>"
                i = i + 1
            End While

            command("sp_get_alert_from_managements")
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "<p><u>User Less Management</u> :<br> For the <i><b>" & rdr("mngt_name") & " </i></b> Manager Not mentioned<br>"
                strim &= "<a href=""add_new_user.aspx"">ADD Manager</a></p>"
                i = i + 1
            End While

            If i <= 0 Then
                Return i
            Else
                Return strim
            End If


        End Function
        Public Sub Escalate_query()
            'MsgBox("hi")
            Dim counter_ As Integer = 0
            command("sp_ticket")
            rdr = cmd.ExecuteReader
            While rdr.Read
                counter_ = counter_ + 1
            End While

            Dim arr_t_ids(counter_ + 1) As Integer

            Dim i As Integer = 0
            command("sp_ticket")
            rdr = cmd.ExecuteReader
            While rdr.Read
                arr_t_ids(i) = rdr("id")
                i = i + 1
            End While
            i = 0
            While i < counter_
                command("sp_get_ticket_stts_by_id")
                cmd.Parameters.AddWithValue("@tid", arr_t_ids(i))
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    Dim rec_date As DateTime = System.Convert.ToDateTime(rdr("last_update_date"))
                    Dim today_date As DateTime = System.Convert.ToDateTime(Now())
                    Dim ts As New TimeSpan()
                    ts = today_date.Subtract(rec_date)
                    Dim minuts As Integer = ts.Minutes
                    Dim hours As Integer = 0
                    Dim ticket_id As Integer = rdr("id")
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

                    If hours > 24 And hours <= 48 Then
                        command3("sp_update_hand_stts_by_tid")
                        cmd3.Parameters.AddWithValue("@tid", ticket_id)
                        cmd3.Parameters.AddWithValue("@hnd_stts", "HOD")
                        cmd3.ExecuteNonQuery()

                        command3("sp_chage_q_stts_by_tid")
                        cmd3.Parameters.AddWithValue("@tid", ticket_id)
                        cmd3.ExecuteNonQuery()

                    ElseIf hours > 48 Then
                        command3("sp_update_hand_stts_by_tid")
                        cmd3.Parameters.AddWithValue("@tid", ticket_id)
                        cmd3.Parameters.AddWithValue("@hnd_stts", "MNG")
                        cmd3.ExecuteNonQuery()

                        command3("sp_chage_q_stts_by_tid")
                        cmd3.Parameters.AddWithValue("@tid", ticket_id)
                        cmd3.ExecuteNonQuery()

                    ElseIf hours > 0 And hours <= 24 Then
                        command3("sp_update_hand_stts_by_tid")
                        cmd3.Parameters.AddWithValue("@tid", ticket_id)
                        cmd3.Parameters.AddWithValue("@hnd_stts", "DE")
                        cmd3.ExecuteNonQuery()

                        'command3("sp_chage_q_stts_by_tid")
                        'cmd3.Parameters.AddWithValue("@tid", ticket_id)
                        'cmd3.ExecuteNonQuery()

                    ElseIf hours > 48 Then
                        command3("sp_update_hand_stts_by_tid")
                        cmd3.Parameters.AddWithValue("@tid", ticket_id)
                        cmd3.Parameters.AddWithValue("@hnd_stts", "MNG")
                        cmd3.ExecuteNonQuery()

                        command3("sp_chage_q_stts_by_tid")
                        cmd3.Parameters.AddWithValue("@tid", ticket_id)
                        cmd3.ExecuteNonQuery()

                    End If
                Else

                End If
                i = i + 1
            End While

        End Sub

        Public Sub sp_err_curr_1()
            command("sp_err_curr_1")
            cmd.ExecuteNonQuery()
        End Sub
        
    End Class
End Namespace
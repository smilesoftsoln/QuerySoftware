Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.CSharp
Imports System.Net
Partial Class resend
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
        Dim t_id As Integer = Request.QueryString("tid")
        command("sp_get_ticket_by_t_id")
        cmd.Parameters.AddWithValue("@t_id", t_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_topic.Text = rdr("t_sub")
        End If
    End Sub

    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        Dim t_id As Integer = Request.QueryString("tid")
        Dim deptType As String = Session.Item("loginerTYP")
        Dim lid As Integer = Request.QueryString("lid")
        If txt_why.Text = "" Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Please Mention The Reason of ReSending Ticket')</script>")
        Else
            Dim now_hand_in As String = ""
            Dim tid As Integer = Request.QueryString("tid")
            Dim resend_to As String = ""

            Dim to_dept_id As String = ""
            Dim disp_id As String = ""
            Dim subject As String = ""

            command("sp_get_ticket_by_t_id")
            cmd.Parameters.AddWithValue("@t_id", tid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                now_hand_in = rdr("now_hand_in")
                to_dept_id = rdr("to_dept_id")
                disp_id = rdr("disp_id")
                subject = rdr("t_sub")
            End If
            rdr.Close()


            If now_hand_in = "DE" Then
                resend_to = "HOD"

            ElseIf now_hand_in = "HOD" Then
                resend_to = "MNG"
            ElseIf now_hand_in = "MNG" Then
                resend_to = "HOD"
            End If
            command("sp_resend_tick")
            cmd.Parameters.AddWithValue("@tid", tid)
            cmd.Parameters.AddWithValue("@res_to", resend_to)
            If cmd.ExecuteNonQuery Then
                command("sp_insert_comment_")
                cmd.Parameters.AddWithValue("@t_id", t_id)
                cmd.Parameters.AddWithValue("@comm_", "<u>ReSend Note :</u> " & txt_why.Text)
                cmd.Parameters.AddWithValue("@crtr_id", lid)
                cmd.Parameters.AddWithValue("@attch_url", "NO")
                If cmd.ExecuteNonQuery Then
                    command("sp_chage_q_stts_by_tid")
                    cmd.Parameters.AddWithValue("@tid", t_id)
                    If cmd.ExecuteNonQuery() Then
                        Panel1.Visible = False
                        Panel2.Visible = True
                        Dim to_dept_email As String = ""
                        If resend_to.Equals("HOD") Then


                            Dim conn As SqlConnection = weldone_con.ConObj
                            cmd = conn.CreateCommand


                            cmd.CommandText = "select tlm.email_id from tbl_loginer_master tlm,tbl_dept_master tdm where tlm.post_='" + resend_to + "' and  tdm.id=" + to_dept_id + " and tlm.id=tdm.hod_loginer_id"

                            rdr = cmd.ExecuteReader


                            If rdr.HasRows Then
                                rdr.Read()
                                to_dept_email = rdr("email_id").ToString
                            End If
                            rdr.Close()

                        End If

                        If resend_to.Equals("MNG") Then
                            Dim conn As SqlConnection = weldone_con.ConObj
                            cmd = conn.CreateCommand

                            cmd.CommandText = "select tlm.email_id from tbl_loginer_master tlm,tbl_dept_master tdm where tlm.post_='" + resend_to + "' and tlm.forign_id=tdm.manage_id "

                            rdr = cmd.ExecuteReader


                            If rdr.HasRows Then
                                rdr.Read()
                                to_dept_email = rdr("email_id").ToString
                            End If
                            rdr.Close()

                        End If



                        Call MailSend(to_dept_email, "WebTradeNet: You Have Received a Resent Query :  " & disp_id, "You have received New Query . About : " & subject & " ")

                        'Call MailSend(disp_email, "WebTradeNet: You Have Posted a New Query :  " & disp_id, "You have Posted New Query . About : " & txt_sub.Text & "  To  " & this_name & " (" & to_branch & ")<br />" & txt_desc.Text)

                    End If
                End If
            End If
        End If
    End Sub
    Public Function MailSend(ByVal MailTo As String, ByVal MailSubject As String, ByVal MailBody As String, Optional ByVal AttachedFileName As String = "") As Boolean
        Dim objEmail As New Mail.MailMessage()
        Dim smtpMail As New Mail.SmtpClient
        Dim AttachedFile As Mail.Attachment
        If (MailTo.Contains("tradenetstockbroking.in")) Then

            smtpMail.Port = 25
            smtpMail.Credentials = New System.Net.NetworkCredential("query@tradenetstockbroking.in", "query12") 'New System.Net.NetworkCredential("info@dattadoor.com", "123456")
            smtpMail.Host = "123.252.207.39" '"mail.dattadoor.com" '"smtp.gmail.com
            objEmail.From = New Mail.MailAddress("query@tradenetstockbroking.in", "Query Software")
            objEmail.CC.Add("ccare03@tradenetstockbroking.in")
        Else
            smtpMail.Port = 25
            smtpMail.Credentials = New System.Net.NetworkCredential("query@tradenetstockbroking.com", "que123") 'New System.Net.NetworkCredential("info@dattadoor.com", "123456")
            smtpMail.Host = "tradenetstockbroking.com" '"mail.dattadoor.com" '"smtp.gmail.com
            objEmail.From = New Mail.MailAddress("query@tradenetstockbroking.com", "Query Software")
            objEmail.CC.Add("sharmila@tradenetstockbroking.com")
            'objEmail.CC.Add("techsupport@tradenetstockbroking.com")
        End If
        Try
            objEmail.To.Add(MailTo)
        Catch ex As Exception

        End Try


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



End Class


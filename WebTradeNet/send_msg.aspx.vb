Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Net

Partial Class send_msg
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Dim deID As Integer

    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim t_id As Integer = Request.QueryString("tid")
        command("sp_get_ticket_by_t_id")
        cmd.Parameters.AddWithValue("@t_id", t_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_topic.Text = rdr("t_sub")
            deID = rdr("Pro_to_emp_id")
        End If
        If Session.Item("loginerTYP") = "HOD" Then
            rdb_to.Items(0).Enabled = False
        End If
        If Session.Item("loginerTYP") = "MNG" Then
            rdb_to.Items(1).Enabled = False
        End If
        If Session.Item("loginerTYP") = "DE" Then
            rdb_to.Items(2).Enabled = False
        End If
    End Sub

    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        Dim t_id As Integer = Request.QueryString("tid")
        Dim deptType As String = Session.Item("loginerTYP")
        Dim dept_id As Integer = Session.Item("DEPT_ID")
        Dim lid As Integer = Request.QueryString("lid")
        Dim sender1 As String = ""
        If Session.Item("loginerTYP") = "MNG" Then
            'Department ID depending on Query ID
            command("sp_get_ticket_by_t_id")
            cmd.Parameters.AddWithValue("@t_id", t_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                dept_id = rdr("to_dept_id")

                ' Call MailSend(mailid, "WebTradeNet: You Have Message a New Approval For Ticket :" & t_id, "You have Received New Message: " & txt_why.Text)

            End If

        End If

        If txt_why.Text = "" Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Please Mention Message for Ticket')</script>")
        Else
             
            Dim receiver As String = ""

            
            Dim mailid As String = ""
             
            If rdb_to.Items(0).Selected = True Then
                command("sp_get_hod_by_dept_id")
                cmd.Parameters.AddWithValue("@dept_id", dept_id)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    receiver &= rdr("name_") & ","


                    mailid = rdr("email_id")
                    Call MailSend(mailid, "WebTradeNet: You Have Message a New Approval For Ticket :" & t_id, "You have Received New Message: " & txt_why.Text)

                End If
            End If
            If rdb_to.Items(1).Selected = True Then
                command("sp_get_mng_email_by_tkt_id")
                cmd.Parameters.AddWithValue("@tkt_id", t_id)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    receiver &= rdr("name_") & ","
                    mailid = rdr("email_id")
                    Call MailSend(mailid, "WebTradeNet: You Have Received a New Message For Ticket :" & t_id, "You have Received New Message: " & txt_why.Text)

                End If
            End If
            If rdb_to.Items(2).Selected = True Then
                command("sp_get_details_by_loginer_ID")
                cmd.Parameters.AddWithValue("@loginerID", deID)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    receiver &= rdr("name_") & ","
                    mailid = rdr("email_id")
                    Call MailSend(mailid, "WebTradeNet: You Have Received a New Message For Ticket :" & t_id, "You have Received New Message: " & txt_why.Text)

                End If
            End If



            command("sp_get_details_by_loginer_ID")
            cmd.Parameters.AddWithValue("@loginerID", lid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                sender1 = rdr("name_")

            End If


            command("insert_msg")
            cmd.Parameters.AddWithValue("@tktid", t_id)
            cmd.Parameters.AddWithValue("@sender", sender1)
            cmd.Parameters.AddWithValue("@msg", txt_why.Text)

            cmd.Parameters.AddWithValue("@msg_time", DateTime.Now)
            cmd.Parameters.AddWithValue("@receiver", receiver)
            cmd.ExecuteNonQuery()

            Panel1.Visible = False
            Panel2.Visible = True
            End If





    End Sub
    Public Function MailSend(ByVal MailTo As String, ByVal MailSubject As String, ByVal MailBody As String, Optional ByVal AttachedFileName As String = "") As Boolean
        Dim objEmail As New Mail.MailMessage()
        Dim smtpMail As New Mail.SmtpClient
        Dim AttachedFile As Mail.Attachment
        smtpMail.Port = 25
        smtpMail.Credentials = New System.Net.NetworkCredential("query@tradenetstockbroking.in", "query12") 'New System.Net.NetworkCredential("info@dattadoor.com", "123456")
        smtpMail.Host = "123.252.207.39" '"mail.dattadoor.com" '"smtp.gmail.com
        objEmail.From = New Mail.MailAddress("query@tradenetstockbroking.in", "Query Software")
        Try
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
End Class

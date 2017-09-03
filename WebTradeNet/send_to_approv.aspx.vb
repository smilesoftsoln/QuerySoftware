Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Net

Partial Class send_to_approv
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
        If Session.Item("loginerTYP") = "HOD" Then
            rdb_to.Items(0).Enabled = False
        End If
        If Session.Item("loginerTYP") = "MNG" Then
            rdb_to.Items(0).Enabled = False
        End If
        If Session.Item("loginerTYP") = "MNG" Then
            rdb_to.Items(1).Enabled = False
        End If
    End Sub

    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        Dim t_id As Integer = Request.QueryString("tid")
        Dim deptType As String = Session.Item("loginerTYP")
        Dim dept_id As Integer = Session.Item("DEPT_ID")
        Dim lid As Integer = Request.QueryString("lid")


        If txt_why.Text = "" Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Please Mention The Reason of ReSending Ticket')</script>")
        Else
            command("sp_get_app_by_t_id")
            cmd.Parameters.AddWithValue("@tid", t_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                rdr.Close()
                'MsgBox("sd")
                Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('You Wrote Already One Approval Note For This Ticket ,Hance You cant Make another Approval Note !')</script>")
            Else
                rdr.Close()
                command("sp_insert_approval")
                cmd.Parameters.AddWithValue("@t_id", t_id)
                cmd.Parameters.AddWithValue("@id_crtr", lid)
                cmd.Parameters.AddWithValue("@note_crtr", txt_why.Text)
                cmd.Parameters.AddWithValue("@to_", rdb_to.SelectedValue)
                cmd.Parameters.AddWithValue("@id_rcvr", 0)
                cmd.Parameters.AddWithValue("@dept_id", dept_id)
                Dim mailid As String = ""
                If cmd.ExecuteNonQuery Then
                    command("sp_chaneg_ticker_stts")
                    cmd.Parameters.AddWithValue("@tid", t_id)
                    If cmd.ExecuteNonQuery() Then
                        If rdb_to.Items(0).Selected = True Then
                            command("sp_get_hod_by_dept_id")
                            cmd.Parameters.AddWithValue("@dept_id", dept_id)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                mailid = rdr("email_id")
                                Call MailSend(mailid, "WebTradeNet: You Have Received a New Approval For Ticket :" & t_id, "You have Received New Approval: " & txt_why.Text)

                            End If
                        End If
                        If rdb_to.Items(1).Selected = True Then
                            command("sp_get_mng_email_by_tkt_id")
                            cmd.Parameters.AddWithValue("@tkt_id", t_id)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                mailid = rdr("email_id")
                                Call MailSend(mailid, "WebTradeNet: You Have Received a New Approval For Ticket :" & t_id, "You have Received New Approval: " & txt_why.Text)

                            End If
                        End If




                        Panel1.Visible = False
                        Panel2.Visible = True
                    End If
                End If
            End If
           
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

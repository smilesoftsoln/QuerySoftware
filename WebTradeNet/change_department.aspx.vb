Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.CSharp
Imports System.Net
Partial Class change_department
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

        If Not Page.IsPostBack Then
            Dim this_top As String = Request.QueryString("")
            command("sp_get_depts")
            rdr = cmd.ExecuteReader
            cbo_depts.Items.Add("")
            While rdr.Read
                cbo_depts.Items.Add(rdr("dept_name"))
            End While
        End If
       
    End Sub

    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        Dim t_id As Integer = Request.QueryString("tid")
        Dim dept_id As Integer
        loginerID = Session.Item("loginerID")
        Dim deptType As String = Session.Item("loginerTYP")

        If txt_why.Text = "" Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Please Mention the Reason about why you forwarding this ticket !')</script>")
        Else
            command("sp_get_dept_id_by_name")
            cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                dept_id = rdr("id")
            End If

            '========geting pro_to_dept_emoID ==========
            Dim dept_count As Integer = 0
            Dim pro_to_dept_emoID As Integer = 0
            Dim i As Integer = 0
            command("sp_get_ranking_dept_wise")
            cmd.Parameters.AddWithValue("@dept_id", dept_id)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dept_count = dept_count + 1
            End While

            Dim arr_emp_id(dept_count + 1) As Integer
            Dim arr_emp_stt(dept_count + 1) As String

            command("sp_get_ranking_dept_wise")
            cmd.Parameters.AddWithValue("@dept_id", dept_id)
            rdr = cmd.ExecuteReader
            While rdr.Read
                arr_emp_id(i) = rdr("emp_id")
                arr_emp_stt(i) = rdr("emp_stt")
                i = i + 1
            End While

            i = 0
            While i <= dept_count
                If arr_emp_stt(i) = "NO" Then
                    pro_to_dept_emoID = arr_emp_id(i)
                    i = dept_count + 1
                End If
                i = i + 1
            End While

            If pro_to_dept_emoID = 0 Then
                command("sp_update_stt_yes")
                cmd.Parameters.AddWithValue("@dept_id", dept_id)
                cmd.ExecuteNonQuery()
                pro_to_dept_emoID = arr_emp_id(0)
            End If

            '===========================================

            command("sp_change_dept_by_t_id")
            cmd.Parameters.AddWithValue("@new_dept_id", dept_id)
            cmd.Parameters.AddWithValue("@t_id", t_id)
            cmd.Parameters.AddWithValue("@pro_to_dept_emoID", pro_to_dept_emoID)
            If cmd.ExecuteNonQuery Then
                lbl_topic.Visible = False
                cbo_depts.ValidationGroup = False
                command("sp_update_single_stt_yes")
                cmd.Parameters.AddWithValue("@empid", pro_to_dept_emoID)
                If cmd.ExecuteNonQuery() Then
                    command("sp_insert_podt")
                    cmd.Parameters.AddWithValue("@ticket_id", t_id)
                    cmd.Parameters.AddWithValue("@post_", "<u>Dept. to Dept. Forwarded Note:</u> " & txt_why.Text)
                    cmd.Parameters.AddWithValue("@creater_id", loginerID)
                    cmd.Parameters.AddWithValue("@crtr_typ", deptType)

                    If cmd.ExecuteNonQuery Then
                        Dim this_email_id As String
                        Dim disp_id As Integer
                        command("sp_get_details_from_dept_master_by_id")
                        cmd.Parameters.AddWithValue("@id", pro_to_dept_emoID)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            this_email_id = rdr("email_id")
                        End If

                        command("sp_get_ticket")
                        cmd.Parameters.AddWithValue("@tid", t_id)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            disp_id = rdr("disp_id")
                        End If

                        Dim disp_name As String = ""
                        command("sp_get_details_by_loginerID")
                        cmd.Parameters.AddWithValue("@loginerID", loginerID)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            disp_name = rdr("name_")
                        End If
                        Call MailSend(this_email_id, "WebTradeNet: You Have Recievd a New Query : " & disp_id, "You have recived New Query . About :" & lbl_topic.Text & " From" & disp_name)
                        txt_why.Visible = False
                        cbo_depts.Visible = False
                        btn_change.Visible = False
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
        objEmail.From = New Mail.MailAddress("query@tradenetstockbroking.in")
        objEmail.To.Add(MailTo)
        objEmail.CC.Add("ccare03@tradenetstockbroking.in")
        If AttachedFileName.ToString <> "" Then
            AttachedFile = New Mail.Attachment(AttachedFileName)
            objEmail.Attachments.Add(AttachedFile)
        End If
        objEmail.Subject = MailSubject
        objEmail.IsBodyHtml = True
        objEmail.Body = MailBody
        objEmail.Priority = Mail.MailPriority.High
        'SmtpMail.SmtpServer  = "localhost"
        Try
            smtpMail.Send(objEmail)
        Catch ex As Exception
        End Try
        'Response.Write("Mail Send Successful")
        Return True
    End Function

    
End Class

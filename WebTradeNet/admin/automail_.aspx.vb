Imports System.Data.SqlClient
'Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Net

Partial Class admin_automail_
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim comm_dns As New somman_functions_NM.commen_funcs
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strim As String = ""
        Dim this_stts As String = "Solved"
        Dim arr_tot_depts As Integer = 0
        Dim i As Integer = 0

        Label1.Visible = True
        Label1.Text = "Please Wait...<br>Generating Report !"
        Button1.Enabled = False

        command("sp_get_all_depts")
        rdr = cmd.ExecuteReader
        While rdr.Read
            arr_tot_depts = arr_tot_depts + 1
        End While
        Dim depts(arr_tot_depts + 1) As Integer
        Dim depts_hods_email(arr_tot_depts + 1) As String
        command("sp_get_all_depts")
        rdr = cmd.ExecuteReader
        While rdr.Read
            depts(i) = rdr("id")
            depts_hods_email(i) = rdr("email_id")
            i = i + 1
        End While
        i = 0
        While i <= arr_tot_depts
            'MsgBox(depts_hods_email(i))
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

            command("sp_view_all_queryes_2")
            'cmd.Parameters.AddWithValue("@t_stts", this_stts)
            cmd.Parameters.AddWithValue("@q_typ", "%%")
            cmd.Parameters.AddWithValue("@to_dept_id", depts(i))
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "	        <tr >"
                strim &= "	            <td >"
                strim &= rdr("disp_id")
                strim &= "	            </td>"
                strim &= "	            <td class=""date_ticks"">"
                strim &= rdr("t_sub")
                strim &= "	            </td>"
                strim &= "<td width=""5%"">"
                If rdr("q_typ") = "NORMAL" Then
                    strim &= "NORMAL"
                ElseIf rdr("q_typ") = "Transferred" Or rdr("q_typ") = "TRANSFERED" Then
                    strim &= "TRANSFERED"
                ElseIf rdr("q_typ") = "ESCALATED" Then
                    strim &= "ESCALATED"
                ElseIf rdr("q_typ") = "DELETE" Or rdr("q_typ") = "DELETED" Then
                    strim &= "DELETE"
                End If
                strim &= "</td>"

                strim &= "	            <td >"
                strim &= rdr("now_hand_in")
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("branch_name") & "<br>(" & rdr("auther") & ")"
                strim &= "	            </td>"
                strim &= "	            <td class=""date_ticks"">"
                strim &= rdr("dept_name") & "<br>(" & rdr("username_") & ")"
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("last_update_date")
                strim &= "	            </td>"
                strim &= "	            <td class=""date_ticks"">"
                strim &= rdr("t_stts")
                strim &= "	            </td>"
                strim &= "	        </tr>"


            End While
            strim &= "</table>"
            Call MailSend(depts_hods_email(i), "Todays Unsolved Tickets (" & Today() & ")", strim)

            i = i + 1
        End While


        '============================ to BH ==================
        Dim tot_branch_ As Integer = 0
        i = 0
        strim = ""

        command("sp_get_BH_email")
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_branch_ = tot_branch_ + 1
        End While

        'MsgBox("tot_branch_ = " & tot_branch_)

        Dim branch_ids(tot_branch_ + 1) As Integer
        Dim branch_mngr_emails(tot_branch_ + 1) As String

        command("sp_get_BH_email")
        rdr = cmd.ExecuteReader
        While rdr.Read
            branch_ids(i) = rdr("branch_id")
            branch_mngr_emails(i) = rdr("email_id")
            '            MsgBox("sdsda = " & branch_ids(i))
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

            command("sp_view_all_queryes_to_BH")

            cmd.Parameters.AddWithValue("@from_branch_id", branch_ids(i))

            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "	        <tr >"
                strim &= "	            <td >"
                strim &= rdr("disp_id")
                strim &= "	            </td>"
                strim &= "	            <td class=""date_ticks"">"
                strim &= rdr("t_sub")
                strim &= "	            </td>"
                strim &= "<td width=""5%"">"
                If rdr("q_typ") = "NORMAL" Then
                    strim &= "NORMAL"
                ElseIf rdr("q_typ") = "Transferred" Or rdr("q_typ") = "TRANSFERED" Then
                    strim &= "TRANSFERED"
                ElseIf rdr("q_typ") = "ESCALATED" Then
                    strim &= "ESCALATED"
                ElseIf rdr("q_typ") = "DELETE" Or rdr("q_typ") = "DELETED" Then
                    strim &= "DELETE"
                End If
                strim &= "</td>"

                strim &= "	            <td >"
                strim &= rdr("now_hand_in")
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("branch_name") & "<br>(" & rdr("auther") & ")"
                strim &= "	            </td>"
                strim &= "	            <td class=""date_ticks"">"
                strim &= rdr("dept_name") & "<br>(" & rdr("username_") & ")"
                strim &= "	            </td>"

                strim &= "	            <td class=""date_ticks"">"
                strim &= rdr("t_stts")
                strim &= "	            </td>"
                strim &= "	        </tr>"
                'MsgBox(branch_mngr_emails(i))
            End While
            strim &= "</table>"
            Call MailSend(branch_mngr_emails(i), "Todays Unsolved Tickets (" & Today() & ")", strim)
            i = i + 1
        End While

        Label1.Visible = True
        Label1.Text = "Reports Generated Successfully !<br> Please Check Your Mail !"
        Button1.Enabled = False
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

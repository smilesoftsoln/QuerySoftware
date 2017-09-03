Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.CSharp
Imports System.Net
Partial Class Create_new_ticket
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
        btn_submit.Enabled = True

        Try
            If Request.Cookies("admin")("login") = "false" Then
                Response.Redirect("User_login.aspx?")
            End If

        Catch ex As Exception
            Response.Redirect("User_login.aspx")
        End Try

        loginerID = Session.Item("loginerID")

        If Not Page.IsPostBack Then
            command("sp_get_departments")
            cbo_depts.Items.Add("")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_depts.Items.Add(rdr("dept_name"))
            End While
        End If
        Dim loginerTYP As String = Session.Item("loginerTYP")
        Dim strim As String = ""
        Dim t_count As Integer = 0
        Dim emp_id_ As Integer
        Dim who_is As String = ""
        Dim forign_id As String = ""
        command("sp_get_details_by_loginer_ID")
        cmd.Parameters.AddWithValue("@loginerID", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_uname_1.Text = rdr("name_")
            emp_id_ = rdr("forign_id")
            Session.Item("emp_id_") = emp_id_
            who_is = rdr("post_")
            forign_id = rdr("forign_id")
        End If
        If who_is = "BH" And forign_id <> "9" Then
            pnl_for_BH.Visible = True
        End If

        If lbl_uname_1.Text = "" Then
            Response.Redirect("User_login.aspx")
        End If

        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()

    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_submit.Click
        btn_submit.Enabled = False

        loginerID = Session.Item("loginerID")
        If loginerID = 0 Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Login Failed ! \nSession is time out! \nPlease Login Ageain ')</script>")
            Response.Redirect("User_login.aspx")

        ElseIf Response.Cookies("admin")("login") = "false" Then
            Response.Redirect("User_login.aspx")
        End If

        Dim l_name As String = ""
        Dim fileext As String
        Dim from_branch As String = ""
        Dim dept_id As Integer
        Dim dept_count As Integer = 0
        Dim i As Integer = 0
        Dim Pro_to_emp_id As Integer = 0
        Dim forign_id As Integer
        Dim hand_in As String = "DE"
        Dim dept_hod_id As Integer
        Dim from_branch_id As Integer
        Dim to_l_name As String = ""
        Dim to_branch As String
        Dim to_branch_id As Integer
        command("sp_get_BE_name_and_branch_name_by_id")
        cmd.Parameters.AddWithValue("@uid", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            l_name = rdr("name_")
            from_branch = rdr("branch_name")
            from_branch_id = rdr("id")
        End If


        
        'command("sp_get_BE_name_and_branch_name_by_id")
        'cmd.Parameters.AddWithValue("@uid", loginerID)
        'rdr = cmd.ExecuteReader
        'If rdr.Read Then
        '    to_l_name = rdr("name_")
        to_branch = cbo_depts.SelectedValue
        'to_branch_id = cbo_depts.SelectedValue
        'End If

        command("sp_get_dept_id_by_dept_name")
        cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            dept_id = rdr("id")
            dept_hod_id = rdr("hod_loginer_id")
        End If

        If (rdb_direct.SelectedValue <> "HOD") Then
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
                    Pro_to_emp_id = arr_emp_id(i)
                    i = dept_count + 1
                End If
                i = i + 1
            End While
            i = 0

            If Pro_to_emp_id = 0 Then
                command("sp_update_stt_yes")
                cmd.Parameters.AddWithValue("@dept_id", dept_id)
                cmd.ExecuteNonQuery()
                Pro_to_emp_id = arr_emp_id(0)
            End If
        Else
            Pro_to_emp_id = dept_hod_id
        End If

        Dim this_attch As String = "No"

        If fUpp.HasFile Then
            fileext = System.IO.Path.GetExtension(fUpp.FileName)
            Dim ext As String = IO.Path.GetExtension(fUpp.FileName).ToLower
            this_attch = "Attatchments/" & Today.Year & Today.Month & Now.Minute & Now.Second & Now.Millisecond & ext
            fUpp.SaveAs(Server.MapPath(this_attch))
        End If

        Dim disp_id As Double
        '========Declaring Disp_id===========
        Dim disp_id_ As String
        Dim hh As Integer = Now.Hour
        Dim min As Integer = Now.Hour
        Dim tod_date As Integer = Now.Day
        Dim yy As Integer = Now.Year
        Dim mm As Integer = Now.Month
        Dim tot_ticket As Integer = 0
        Dim this_tt As String

        Dim this_mm As String
        Dim this_yy As String

        If yy = 2008 Then
            this_yy = "08"
        ElseIf yy = 2009 Then
            this_yy = "09"
        ElseIf yy = 2010 Then
            this_yy = "10"
        ElseIf yy = 2011 Then
            this_yy = "11"
        ElseIf yy = 2012 Then
            this_yy = "12"
        ElseIf yy = 2013 Then
            this_yy = "13"
        ElseIf yy = 2014 Then
            this_yy = "14"
        ElseIf yy = 2015 Then
            this_yy = "15"
        ElseIf yy = 2016 Then
            this_yy = "16"
        End If

        If mm = 1 Then
            this_mm = "01"
        ElseIf mm = 2 Then
            this_mm = "02"
        ElseIf mm = 3 Then
            this_mm = "03"
        ElseIf mm = 4 Then
            this_mm = "04"
        ElseIf mm = 5 Then
            this_mm = "05"
        ElseIf mm = 6 Then
            this_mm = "06"
        ElseIf mm = 7 Then
            this_mm = "07"
        ElseIf mm = 8 Then
            this_mm = "08"
        ElseIf mm = 9 Then
            this_mm = "09"
        ElseIf mm = 10 Then
            this_mm = "10"
        ElseIf mm = 11 Then
            this_mm = "11"
        ElseIf mm = 12 Then
            this_mm = "12"
        End If

        command("sp_get_only_ticket")
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_ticket = tot_ticket + 1
        End While
        tot_ticket = tot_ticket + 1
        Dim str_tot_ticket As String = tot_ticket
        If str_tot_ticket.Length = 1 Then
            this_tt = "00000" & str_tot_ticket
        ElseIf str_tot_ticket.Length = 2 Then
            this_tt = "0000" & str_tot_ticket
        ElseIf str_tot_ticket.Length = 3 Then
            this_tt = "000" & str_tot_ticket
        ElseIf str_tot_ticket.Length = 4 Then
            this_tt = "00" & str_tot_ticket

        ElseIf str_tot_ticket.Length = 5 Then
            this_tt = "0" & str_tot_ticket

            'ElseIf str_tot_ticket.Length = 6 Then
            '    this_tt = "0" & str_tot_ticket
        End If
        disp_id_ = this_yy & this_mm & this_tt

        disp_id = Convert.ToDouble(disp_id_)

        '---------------
        Dim this_email_id As String = ""
        Dim this_name As String = ""
        '---------------
        If rdb_direct.SelectedValue = "" Then
            hand_in = "DE"
            command("sp_get_details_from_dept_master_by_id")
            cmd.Parameters.AddWithValue("@id", Pro_to_emp_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                this_email_id = rdr("email_id")
                this_name = rdr("name_")

            End If
        ElseIf rdb_direct.SelectedValue = "HOD" Then
            hand_in = "HOD"
            command("sp_get_details_from_dept_master_by_id")
            cmd.Parameters.AddWithValue("@id", dept_hod_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                this_email_id = rdr("email_id")
                this_name = rdr("name_")
            End If
        ElseIf rdb_direct.SelectedValue = "MANAGEMENT" Then
            hand_in = "MNG"
        End If
        '===================================
        command("sp_insert_tbl_ticket_master")
        cmd.Parameters.AddWithValue("@t_sub", txt_sub.Text)
        cmd.Parameters.AddWithValue("@t_desc", txt_desc.Text)
        cmd.Parameters.AddWithValue("@attatchment_url", this_attch)
        cmd.Parameters.AddWithValue("@creater_id", loginerID)
        cmd.Parameters.AddWithValue("@disp_id", disp_id)
        cmd.Parameters.AddWithValue("@to_dept_id", dept_id)
        cmd.Parameters.AddWithValue("@from_branch_id", from_branch_id)
        cmd.Parameters.AddWithValue("@hand_in", hand_in)
        cmd.Parameters.AddWithValue("@Pro_to_emp_id", Pro_to_emp_id)
        cmd.Parameters.AddWithValue("@stts_chng_date", DateTime.Now)
        If Pro_to_emp_id = 0 Then
            Dim stream1 As String = ""
            stream1 &= "  <div id=""showimage"" style=""position:absolute;width:250px;left:250px;top:250px"">"
            stream1 &= "<table border=""0"" width=""250"" bgcolor=""#000080"" cellspacing=""0"" cellpadding=""2"">"
            stream1 &= "  <tr>"
            stream1 &= " <td width=""100%""><table border=""0"" width=""100%"" cellspacing=""0"" cellpadding=""0"" height=""36px"">"
            stream1 &= "  <tr>"
            stream1 &= "    <td id=""dragbar"" style=""cursor:hand; cursor:pointer"" width=""100%"" onMousedown=""initializedrag(event)""><ilayer width=""100%"" onSelectStart=""return false""><layer width=""100%"" onMouseover=""dragswitch=1;if (ns4) drag_dropns(showimage)"" onMouseout=""dragswitch=0""><font face=""Verdana""  color=""#FFFFFF""><strong><small>Sri Sri AlertBox</small></strong></font></layer></ilayer></td>"
            stream1 &= "   <td style=""cursor:hand"">"
            stream1 &= "        <a href=""#"" onClick=""hidebox();return false""><img src=""images/close1.gif"" width=""16px"" height=""14px"" border=0></a></td>"
            stream1 &= "  </tr>"
            stream1 &= "  <tr>"
            stream1 &= "    <td width=""100%"" bgcolor=""#FFFFFF"" style=""padding:4px"" colspan=""2"">"
            stream1 &= "<div style=""width:35%;float:left;clear:left"">"
            stream1 &= "<img src=""images/faled.png"">"
            stream1 &= "</div>"
            stream1 &= "<div style=""width:100%;float:right;clear:right"">"
            stream1 &= "<b>ERROR ... !</b><hr><img src=""images/ico_alpha_Error_32x32.png"" align=""left"">Error Found In page .<br>Please Contact To Admin"
            stream1 &= "</div>"
            stream1 &= "<div style=""width:100%;float:left;clear:left"">"
            stream1 &= "<input type=""button"" value=""    Ok    "" style=""float:right;clear:right"" onClick=""hidebox();return false"">"
            stream1 &= "</div>"
            stream1 &= "</td>"
            stream1 &= "   </tr>"
            stream1 &= " </table>"
            stream1 &= " </td>"
            stream1 &= "</tr>"
            stream1 &= "</table>"
            stream1 &= "</div>"
            Disp_this.InnerHtml = stream1
        ElseIf cmd.ExecuteNonQuery Then

            command("sp_update_single_stt_yes")
            cmd.Parameters.AddWithValue("@empid", Pro_to_emp_id)
            Dim disp_name As String = ""
            Dim disp_email As String = ""
            cmd.ExecuteNonQuery()
            'If cmd.ExecuteNonQuery Then
            command("sp_get_details_by_loginerID")
            cmd.Parameters.AddWithValue("@loginerID", loginerID)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                disp_name = rdr("name_")
                disp_email = rdr("email_id")
            End If
            'this_email_id = this_email_id & "," & disp_email
            'End If
            If this_attch = "No" Then
                Call MailSend(this_email_id, "WebTradeNet: You Have Received a New Query :  " & disp_id, "You have received New Query . About : " & txt_sub.Text & "  From " & disp_name & " (" & from_branch & ")<br />")

                Call MailSend(disp_email, "WebTradeNet: You Have Posted a New Query :  " & disp_id, "You have Posted New Query . About : " & txt_sub.Text & "  To  " & this_name & " (" & to_branch & ")<br />" & txt_desc.Text)
            Else
                Call MailSend(this_email_id, "WebTradeNet: You Have Received a New Query :  " & disp_id, "You have Received New Query . About : " & txt_sub.Text & "  From " & disp_name & " (" & from_branch & ")<br />")

                Call MailSend(disp_email, "WebTradeNet: You Have Posted a New Query :  " & disp_id, "You have Posted New Query . About : " & txt_sub.Text & "  To " & this_name & " (" & to_branch & ")<br />" & txt_desc.Text, Server.MapPath(this_attch))

            End If

        End If
        Response.Write("<script type='text/javascript'>alert('Ticket Submitted');</script>")
        Response.Redirect("User_login_next.aspx")

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
    Protected Sub btn_logout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_logout.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()


        Response.Cookies("user")("login") = "false"
        '  Session.Clear()
        Response.Cookies.Clear()
        Response.Write("<script type='text/javascript'>window.close()</script>")
    End Sub


End Class
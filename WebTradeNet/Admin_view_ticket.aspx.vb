Imports System.Data.SqlClient
Imports System.IO
Partial Class view_ticket_
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loginerTYP As String = Session.Item("loginerTYP")
        Dim disp_hom_link As String = ""
        Dim now_hand_in As String
        Dim pro_to As Integer
        Dim simp_link As String
        If loginerTYP = "ADMIN" Then
            disp_hom_link = "<a href=""main_admin_login_Next.aspx"">Home</a>"
            simp_link = "main_admin_login_Next.aspx"
        ElseIf loginerTYP = "HOD" Then
            disp_hom_link = "<a href=""hod_login_Next.aspx"">Home</a>"
            simp_link = "hod_login_Next.aspx"
        ElseIf loginerTYP = "DE" Then
            disp_hom_link = "<a href=""employee_login_next.aspx"">Home</a>"
            simp_link = "employee_login_next.aspx"
        ElseIf loginerTYP = "MNG" Then
            disp_hom_link = "<a href=""mng_login_next.aspx"">Home</a>"
            simp_link = "mng_login_next.aspx"
            LinkButton1.Visible = False
            disp_sent_to_approval.Visible = False
        Else
            disp_hom_link = "<a href=""Default.aspx"">Home</a>"
            simp_link = "Default.aspx"
        End If
        Disp_home_link.InnerHtml = disp_hom_link
        '''''''''''''''''''''''''''''''''''''''''''''
        loginerID = Session.Item("loginerID")
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()
        '==============
        '====================loginer details feed in top informer====================
        '        lbl_user_name.Text = loginer_ID
        command("sp_get_name_username_Department")
        cmd.Parameters.AddWithValue("@loginerID", loginer_ID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            'lbl_name.Text = "Name Of Employee : " & rdr("name_")
            Session.Add("DEPT_ID", rdr("id"))
            UserLabel1.Text = rdr("name_")

            ' deptId = rdr("id")
            ' lbl_dept.Text = "Department of " & rdr("dept_name")
        End If
        'lbl_now.Text = Now()
        ' lbl_last_login.Text = Session.Item("last_login")
        '========
        Dim tid As Integer = Request.QueryString("tid")
        Dim crtr As String = ""
        Dim crtr_date As New Date
        Dim crtrID As Integer
        Dim stts_ As String = ""
        Dim emer_ As String = ""
        Dim attch As String
        Dim to_dept_id As Integer
        Dim rec_date As DateTime
        Dim today_date As DateTime
        Dim ts As New TimeSpan()
        Dim status As String = ""
        command("sp_view_ticket")
        cmd.Parameters.AddWithValue("@t_id", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_t_id.Text = "(" & rdr("disp_id") & ")"
            rec_date = System.Convert.ToDateTime(rdr("stts_chng_date"))
            Last_Status_Change_Label1.Text = rec_date.ToString()
            today_date = System.Convert.ToDateTime(Now())
            lbl_ticket_sub.Text = rdr("t_sub")
            Page.Title = "TradeNet : " & rdr("t_sub")
            lbl_ticket_desc.Text = rdr("t_desc")
            lbl_from.Text = rdr("branch_name")
            crtr_date = rdr("last_update_date")
            attch = rdr("attatchment_url")
            lbl_subid.Text = rdr("disp_id")
            lbl_to.Text = "Department of " & rdr("dept_name")
            crtr &= "<a href=""#?uid=" & crtrID & " "">" & rdr("name_") & "</A> "
            lbl_auther.Text = rdr("name_")
            lbl_crtr_date.Text = rdr("last_update_date")
            lbl_now.Text = Now()
            Disp_stts_link.InnerHtml = rdr("t_stts")
            status = rdr("t_stts")
            If attch = "NO" Or attch = "No" Then
                lbl_attch.Text = "No"
            Else
                lbl_attch.Text = "<a href=""test_3.aspx?fid=" & attch & " "" target=""_blank"">Download Attachment</a>"
            End If
        Else
            Response.Redirect("User_login.aspx")
        End If
        '=========
        If now_hand_in = loginerTYP Then
        Else
        End If
        '==========
        lbl_crtr_date.Text = crtr_date
        lbl_now.Text = Now()
        ts = today_date.Subtract(rec_date)
        Dim rem_h As Integer
        If rec_date.Day.Equals("Saturday") = False Then
            If status <> "FOLLOW UP" Then

                rem_h = 23 - ts.Hours
            Else

                rem_h = 47 - ((ts.Days * 24) + ts.Hours)

            End If
        Else
            If status <> "FOLLOW UP" Then

                rem_h = 47 - ts.Hours
            Else

                rem_h = 71 - ((ts.Days * 24) + ts.Hours)

            End If
        End If





        
        Dim rem_mi As Integer = 60 - ts.Minutes
        Dim rem_se As Integer = 60 - ts.Seconds
        lbl_est_time.Text = rem_h & ":" & rem_mi & ":" & rem_se
        '=============Get comments==============
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

        ' ======== change dept
        tid = Request.QueryString("tid")
        'Dim strim2 As String = ""
        'strim2 &= "<div>"
        'strim2 &= "    <a href=""change_department.aspx?tid=" & tid & " ""  onclick=""return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 490, objectHeight: 200} )"" class=""highslide"">Change Department</a>"
        'strim2 &= "       <div class=""highslide-html-content"" id=""highslide-html"" style=""width: 490px"">"
        'strim2 &= "     <div class=""highslide-move"" style=""border: 0; height: 25px; padding: 0px; cursor: default"">"
        'strim2 &= "         <div class=""data_admin_mid_main_top_3"">"
        'strim2 &= "             <div style=""float:left;clear:left;"">"
        'strim2 &= " Change Department"
        'strim2 &= "               </div>"
        'strim2 &= "              <div>"
        'strim2 &= "               <a href=""#"" onclick=""return hs.close(this)"" class=""control"">"
        'strim2 &= "                       <img src=""images/close1.gif"" width=""25px"" height=""25px;"" aling=""right"" OnClick=""JavaScript:history.go()"" />"
        'strim2 &= "                   </a>"
        'strim2 &= "             </div>"
        'strim2 &= "           </div>"
        'strim2 &= "       </div>"
        'strim2 &= "        <div class=""highslide-body"" id=""hod_runn_main""></div>"
        'strim2 &= "         </div>"
        'strim2 &= "  </div>"
        'If loginerTYP = "DE" Then
        '    disp_change_dept.InnerHtml = ""
        'Else
        '    disp_change_dept.InnerHtml = strim2
        'End If



        ' ======== approval 
        tid = Request.QueryString("tid")
        Dim strim5 As String = ""
        strim5 &= "<div>"
        strim5 &= "    <a href=""send_to_approv.aspx?tid=" & tid & "&lid=" & loginerID & " ""  onclick=""return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 490, objectHeight: 200} )"" class=""highslide"">Send To Approval</a>"
        strim5 &= "       <div class=""highslide-html-content"" id=""highslide-html"" style=""width: 490px"">"
        strim5 &= "     <div class=""highslide-move"" style=""border: 0; height: 25px; padding: 0px; cursor: default"">"
        strim5 &= "         <div class=""data_admin_mid_main_top_3"">"
        strim5 &= "             <div style=""float:left;clear:left;"">"
        strim5 &= "Send Approval Note "
        strim5 &= "               </div>"
        strim5 &= "              <div>"
        strim5 &= "               <a href=""#"" onclick=""return hs.close(this)"" class=""control"">"
        strim5 &= "                       <img src=""images/close1.gif"" width=""25px"" height=""25px;"" aling=""right"" OnClick=""JavaScript:history.go()"" />"
        strim5 &= "                   </a>"
        strim5 &= "             </div>"
        strim5 &= "           </div>"
        strim5 &= "       </div>"
        strim5 &= "        <div class=""highslide-body"" id=""hod_runn_main""></div>"
        strim5 &= "         </div>"
        strim5 &= "  </div>"
        disp_sent_to_approval.InnerHtml = strim5
        tid = Request.QueryString("tid")
        Dim strim2 As String = ""
        strim2 &= "<div>"
        strim2 &= "    <a href=""send_msg.aspx?tid=" & tid & "&lid=" & loginerID & " ""   onclick=""return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 490, objectHeight: 200} )"" class=""highslide"">Send Message</a>"
        strim2 &= "       <div class=""highslide-html-content"" id=""highslide-html"" style=""width: 490px"">"
        strim2 &= "     <div class=""highslide-move"" style=""border: 0; height: 25px; padding: 0px; cursor: default"">"
        strim2 &= "         <div class=""data_admin_mid_main_top_3"">"
        strim2 &= "             <div style=""float:left;clear:left;"">"
        strim2 &= " Send Message"
        strim2 &= "               </div>"
        strim2 &= "              <div>"
        strim2 &= "               <a href=""#"" onclick=""return hs.close(this)"" class=""control"">"
        strim2 &= "                       <img src=""images/close1.gif"" width=""25px"" height=""25px;"" aling=""right"" OnClick=""JavaScript:history.go()"" />"
        strim2 &= "                   </a>"
        strim2 &= "             </div>"
        strim2 &= "           </div>"
        strim2 &= "       </div>"
        strim2 &= "        <div class=""highslide-body"" id=""hod_runn_main""></div>"
        strim2 &= "         </div>"
        strim2 &= "  </div>"
        ' send_message.InnerHtml = strim2

        ' ======== fwd query

        Dim strim3 As String = ""
        strim3 &= "<div>"
        strim3 &= "    <a href=""fwd_query.aspx?tid=" & tid & " ""  onclick=""return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 490, objectHeight: 200} )"" class=""highslide"">Forward Query</a>"
        strim3 &= "       <div class=""highslide-html-content"" id=""highslide-html"" style=""width: 490px"">"
        strim3 &= "     <div class=""highslide-move"" style=""border: 0; height: 25px; padding: 0px; cursor: default"">"
        strim3 &= "         <div class=""data_admin_mid_main_top_3"">"
        strim3 &= "             <div style=""float:left;clear:left;"">"
        strim3 &= ""
        strim3 &= "               </div>"
        strim3 &= "              <div>"
        strim3 &= "               <a href=""#"" onclick=""return hs.close(this)"" class=""control"">"
        strim3 &= "                       <img src=""images/close1.gif"" width=""25px"" height=""25px;"" aling=""right"" OnClick=""JavaScript:history.go()"" />"
        strim3 &= "                   </a>"
        strim3 &= "             </div>"
        strim3 &= "           </div>"
        strim3 &= "       </div>"
        strim3 &= "        <div class=""highslide-body"" id=""hod_runn_main""></div>"
        strim3 &= "         </div>"
        strim3 &= "  </div>"
        disp_fwd_query.InnerHtml = strim3


        ' ======== change stts

        Dim strim4 As String = ""
        strim4 &= "<div>"
        strim4 &= "    <a href=""admin_change_stts.aspx?tid=" & tid & " ""  onclick=""return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 490, objectHeight: 200} )"" class=""highslide"">Status  : " & stts_ & "</a>"
        strim4 &= "       <div class=""highslide-html-content"" id=""highslide-html"" style=""width: 490px"">"
        strim4 &= "     <div class=""highslide-move"" style=""border: 0; height: 25px; padding: 0px; cursor: default"">"
        strim4 &= "         <div class=""data_admin_mid_main_top_3"">"
        strim4 &= "             <div style=""float:left;clear:left;"">"
        strim4 &= "Status : "
        strim4 &= "               </div>"
        strim4 &= "              <div>"
        strim4 &= "               <a href=""#"" onclick=""return hs.close(this)"" class=""control"">"
        strim4 &= "                       <img src=""images/close1.gif"" width=""25px"" height=""25px;"" aling=""right"" OnClick=""JavaScript:history.go()"" />"
        strim4 &= "                   </a>"
        strim4 &= "             </div>"
        strim4 &= "           </div>"
        strim4 &= "       </div>"
        strim4 &= "        <div class=""highslide-body"" id=""hod_runn_main""></div>"
        strim4 &= "         </div>"
        strim4 &= "  </div>"
        Disp_stts_link.InnerHtml = strim4

        '========== approval note 
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
            LinkButton1.Enabled = True
            lbl_result.Text = "<sapn style=""color:red;""><b>DISAPPROVE</b></span>"
        ElseIf result = "FREEZ" Then
            LinkButton1.Enabled = False
            lbl_result.Text = "<sapn style=""color:black;"">Wating</span>"
        ElseIf result = "APPROVE" Then
            LinkButton1.Enabled = True
            lbl_result.Text = "<sapn style=""color:green;""><b>APPROVE</b></span>"
        End If
        'msges for ticket
        'Dim msgtable As String = "<B>MESSAGES:</b><table>"
        'command("get_msges_by_t_id")
        'cmd.Parameters.AddWithValue("@tid", tid)
        'rdr = cmd.ExecuteReader
        'While rdr.Read()
        '    msgtable &= "<tr backcolor='yellow'><td>FROM: " & rdr("sender") & "</td>"
        '    msgtable &= " <td  backcolor='yellow'>TO: " & rdr("receiver") & "</td>"
        '    msgtable &= " <td  backcolor='yellow'>TIME: " & rdr("msg_time") & "</td></tr>"
        '    msgtable &= "<tr><td  backcolor='yellow'>MESSAGE:  </td>"

        '    msgtable &= " <td  backcolor='yellow' colspan='2'>" & rdr("msg") & "  </td></tr>"

        'End While


        ''If rdr.Read Then

        ''End If
        'msgtable &= "</table>"
        'msges.InnerHtml = msgtable




    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If panal_post_comm.Visible = True Then
            panal_post_comm.Visible = False
        Else
            panal_post_comm.Visible = True
            panal_post_comm.Focus()
        End If
    End Sub

    Protected Sub btn_post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_post.Click
        If String.IsNullOrEmpty(txt_post_.Text.Trim()) Then
            Response.Write("<Script>alert('Blank Reply Not Allowed..!')</Script>")
        Else
            Dim tid As Integer = Request.QueryString("tid")
            loginerID = Session.Item("loginerID")
            Dim deptType As String = Session.Item("loginerTYP")
            If deptType = "" Then
                Response.Redirect("User_Login.aspx")
            End If
            'RESOLVE TIME
            Dim createdate As DateTime

            command("sp_get_ticket")
            cmd.Parameters.AddWithValue("@tid", tid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                createdate = rdr("last_update_date")
            End If
            Dim timespn As TimeSpan = DateTime.Now - createdate
            Dim restime As String = timespn.Days & " Days:" & timespn.Hours & " Hours:" & timespn.Minutes & " Minutes"
            command("sp_set_restime")
            cmd.Parameters.AddWithValue("@tkt_id", tid)
            cmd.Parameters.AddWithValue("@resolve_time", restime)
            cmd.ExecuteNonQuery()

            '***************
            Dim loginerTYP As String = Session.Item("loginerTYP")
            Dim attch As String = "NO"
            Dim fileext As String
            Dim this_attch As String = "NO"
            If fUpp.HasFile Then
                fileext = System.IO.Path.GetExtension(fUpp.FileName)
                Dim ext As String = IO.Path.GetExtension(fUpp.FileName).ToLower
                this_attch = "Attatchments/" & Today.Year & Today.Month & Now.Minute & Now.Second & Now.Millisecond & ext
                fUpp.SaveAs(Server.MapPath(this_attch))
            End If

            Dim tickterid As Integer
            Dim sub_ As String = ""
            command("sp_get_ticket")
            cmd.Parameters.AddWithValue("@tid", tid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                sub_ = rdr("t_sub")
                tickterid = rdr("creater_id")
            End If
            Dim this_name As String = ""
            If Not txt_post_.Text = "" Then
                command("sp_insert_comment_")
                cmd.Parameters.AddWithValue("@t_id", tid)
                cmd.Parameters.AddWithValue("@comm_", txt_post_.Text)
                cmd.Parameters.AddWithValue("@crtr_id", loginerID)
                cmd.Parameters.AddWithValue("@attch_url", this_attch)
                If cmd.ExecuteNonQuery Then
                    command("sp_change_stts_as_solved")
                    cmd.Parameters.AddWithValue("@t_id", tid)
                    If cmd.ExecuteNonQuery Then
                        If loginerTYP = "ADMIN" Then
                            Dim disp_name As String = ""
                            Dim disp_email As String = ""
                            Dim this_email_id As String = ""
                            command("sp_get_details_by_loginerID")
                            cmd.Parameters.AddWithValue("@loginerID", tickterid)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                this_name = rdr("name_")
                                this_email_id = rdr("email_id")
                            End If
                            rdr.Close()
                            command("sp_get_details_by_loginerID")
                            cmd.Parameters.AddWithValue("@loginerID", loginerID)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                disp_name = rdr("name_")
                                disp_email = rdr("email_id")
                            End If
                            rdr.Close()
                            ' this_email_id = this_email_id & "," & disp_email
                            If this_attch = "NO" Then
                                'Call MailSend(disp_email, "WebTradeNet: You Have Replied to Query : ", "You have  replied to Query .  To " & this_name & " <br />" & txt_post_.Text)

                                Call MailSend(this_email_id, "WebTradeNet: You have received reply  of Query : " & lbl_t_id.Text, "You have received reply  of Query .  From  " & disp_name & " <br />" & txt_post_.Text)
                            Else
                                'Call MailSend(disp_email, "WebTradeNet: You Have Replied to  Query : ", "You have Replied to Query .  To " & this_name & "<br />" & txt_post_.Text, Server.MapPath(this_attch))

                                Call MailSend(this_email_id, "WebTradeNet: You have received reply of Query : " & lbl_t_id.Text, "You have received reply  of Query.  From  " & disp_name & "<br />" & txt_post_.Text, Server.MapPath(this_attch))

                            End If

                            Response.Redirect("main_admin_login_Next.aspx")
                        ElseIf loginerTYP = "HOD" Then
                            Dim disp_name As String = ""
                            Dim disp_email As String = ""
                            Dim this_email_id As String = ""
                            command("sp_get_details_by_loginerID")
                            cmd.Parameters.AddWithValue("@loginerID", tickterid)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                this_name = rdr("name_")
                                this_email_id = rdr("email_id")
                            End If
                            rdr.Close()
                            command("sp_get_details_by_loginerID")
                            cmd.Parameters.AddWithValue("@loginerID", loginerID)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                disp_name = rdr("name_")
                                disp_email = rdr("email_id")
                            End If
                            rdr.Close()
                            ' this_email_id = this_email_id & "," & disp_email
                            If this_attch = "NO" Then
                                ' Call MailSend(disp_email, "WebTradeNet: You Have Replied to Query : ", "You have  replied to Query .  To " & this_name & " <br />" & txt_post_.Text)

                                Call MailSend(this_email_id, "WebTradeNet: You have received reply  of Query : " & lbl_t_id.Text, "You have received reply  of Query .  From  " & disp_name & " <br />" & txt_post_.Text)
                            Else
                                ' Call MailSend(disp_email, "WebTradeNet: You Have Replied to  Query : ", "You have Replied to Query .  To " & this_name & "<br />" & txt_post_.Text, Server.MapPath(this_attch))

                                Call MailSend(this_email_id, "WebTradeNet: You have received reply of Query : " & lbl_t_id.Text, "You have received reply  of Query.  From  " & disp_name & "<br />" & txt_post_.Text, Server.MapPath(this_attch))

                            End If

                            Response.Redirect("hod_login_Next.aspx")
                        ElseIf loginerTYP = "DE" Then
                            Dim disp_name As String = ""
                            Dim disp_email As String = ""
                            Dim this_email_id As String = ""
                            command("sp_get_details_by_loginerID")
                            cmd.Parameters.AddWithValue("@loginerID", tickterid)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                this_name = rdr("name_")
                                this_email_id = rdr("email_id")
                            End If
                            rdr.Close()
                            command("sp_get_details_by_loginerID")
                            cmd.Parameters.AddWithValue("@loginerID", loginerID)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                disp_name = rdr("name_")
                                disp_email = rdr("email_id")
                            End If
                            rdr.Close()
                            ' this_email_id = this_email_id & "," & disp_email
                            If this_attch = "NO" Then
                                ' Call MailSend(disp_email, "WebTradeNet: You Have Replied to Query : ", "You have  replied to Query .  To " & this_name & " <br />" & txt_post_.Text)

                                Call MailSend(this_email_id, "WebTradeNet: You have received reply  of Query : " & lbl_t_id.Text, "You have received reply  of Query .  From  " & disp_name & " <br />" & txt_post_.Text)
                            Else
                                '  Call MailSend(disp_email, "WebTradeNet: You Have Replied to  Query : ", "You have Replied to Query .  To " & this_name & "<br />" & txt_post_.Text, Server.MapPath(this_attch))

                                Call MailSend(this_email_id, "WebTradeNet: You have received reply of Query : " & lbl_t_id.Text, "You have received reply  of Query.  From  " & disp_name & "<br />" & txt_post_.Text, Server.MapPath(this_attch))

                            End If
                            Response.Redirect("employee_login_next.aspx")
                        ElseIf loginerTYP = "MNG" Then
                            Response.Redirect("mng_login_next.aspx")
                        Else
                            Response.Redirect("Default.aspx")
                        End If
                    End If
                End If
            End If


        End If
        
    End Sub

   
    Public Function MailSend(ByVal MailTo As String, ByVal MailSubject As String, ByVal MailBody As String, Optional ByVal AttachedFileName As String = "") As Boolean
        Dim objEmail As New System.Net.Mail.MailMessage()
        Dim smtpMail As New System.Net.Mail.SmtpClient
        Dim AttachedFile As System.Net.Mail.Attachment
        If (MailTo.Contains("tradenetstockbroking.in")) Then

            smtpMail.Port = 25
            smtpMail.Credentials = New System.Net.NetworkCredential("query@tradenetstockbroking.in", "query12") 'New System.Net.NetworkCredential("info@dattadoor.com", "123456")
            smtpMail.Host = "123.252.207.39" '"mail.dattadoor.com" '"smtp.gmail.com
            objEmail.From = New System.Net.Mail.MailAddress("query@tradenetstockbroking.in", "Query Software")
            objEmail.CC.Add("ccare03@tradenetstockbroking.in")
        Else
            smtpMail.Port = 25
            smtpMail.Credentials = New System.Net.NetworkCredential("query@tradenetstockbroking.com", "que123") 'New System.Net.NetworkCredential("info@dattadoor.com", "123456")
            smtpMail.Host = "tradenetstockbroking.com" '"mail.dattadoor.com" '"smtp.gmail.com
            objEmail.From = New System.Net.Mail.MailAddress("query@tradenetstockbroking.com", "Query Software")
            objEmail.CC.Add("sharmila@tradenetstockbroking.com")
            ' objEmail.CC.Add("techsupport@tradenetstockbroking.com")

        End If
        Try
            objEmail.To.Add(MailTo)
        Catch ex As Exception

        End Try

        ' objEmail.CC.Add("ccare03@tradenetstockbroking.in")
        If AttachedFileName.ToString <> "" Then
            AttachedFile = New System.Net.Mail.Attachment(AttachedFileName)
            objEmail.Attachments.Add(AttachedFile)
        End If
        objEmail.Subject = MailSubject
        objEmail.IsBodyHtml = True
        objEmail.Body = MailBody
        objEmail.Priority = System.Net.Mail.MailPriority.High
        Try
            smtpMail.Send(objEmail)
        Catch ex As Exception
        End Try
        Return True
    End Function
    Protected Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        panal_post_comm.Visible = False
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()


        '   Session.Clear()
        Response.Cookies.Clear()
        Request.Cookies.Clear()
        ' Page.Session.Clear()
        ' Session.RemoveAll()
        Response.Cookies("admin")("login") = "false"
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub
    Protected Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        '================
        Dim loginerTYP As String = Session.Item("loginerTYP")
        Dim disp_hom_link As String = ""
        Dim now_hand_in As String
        Dim pro_to As Integer
        Dim simp_link As String
        If loginerTYP = "ADMIN" Then
            disp_hom_link = "<a href=""main_admin_login_Next.aspx"">Home</a>"
            simp_link = "main_admin_login_Next.aspx"
        ElseIf loginerTYP = "HOD" Then
            disp_hom_link = "<a href=""hod_login_Next.aspx"">Home</a>"
            simp_link = "hod_login_Next.aspx"
        ElseIf loginerTYP = "DE" Then
            disp_hom_link = "<a href=""employee_login_next.aspx"">Home</a>"
            simp_link = "employee_login_next.aspx"
        Else
            disp_hom_link = "<a href=""Default.aspx"">Home</a>"
            simp_link = "Default.aspx"
        End If
        '=============
        Dim tid As Integer = Request.QueryString("tid")
        Dim postid As Integer
        Dim counter As Integer = 0
        Dim i As Integer = 0

        command("sp_get_post_by_ticket")
        cmd.Parameters.AddWithValue("@tid", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            counter = counter + 1
            'postid = rdr("tp_id")
        End If

        Dim posts(counter + 1) As Integer

        If counter <= 0 Then
            command("sp_transfer_single_ticket")
            cmd.Parameters.AddWithValue("@ticket_id", tid)
            If cmd.ExecuteNonQuery Then
                Response.Redirect(simp_link)
            End If
        Else
            command("sp_get_post_by_ticket")
            cmd.Parameters.AddWithValue("@tid", tid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                posts(i) = rdr("tp_id")
                i = i + 1
            End If
            i = 0
            While i <= counter
                command("sp_transfer_single_posts")
                cmd.Parameters.AddWithValue("@tp_id", posts(i))
                cmd.Parameters.AddWithValue("@ticket_id", tid)
                If cmd.ExecuteNonQuery Then
                End If
                i = i + 1
            End While

            command("sp_transfer_single_ticket")
            cmd.Parameters.AddWithValue("@ticket_id", tid)
            If cmd.ExecuteNonQuery Then
                Response.Redirect(simp_link)
            End If
        End If
    End Sub
End Class

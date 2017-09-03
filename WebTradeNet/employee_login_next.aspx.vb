Imports System.Data.SqlClient
Partial Class employee_login_next
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader
    Dim cmd3 As New SqlCommand
    Dim rdr3 As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Sub command2(ByVal strcmd As String)
        cmd2.CommandType = Data.CommandType.Text
        cmd2.CommandText = strcmd
        cmd2.Connection = weldone_con.ConObj
        cmd2.Parameters.Clear()
    End Sub
    Sub command3(ByVal strcmd As String)
        cmd3.CommandType = Data.CommandType.StoredProcedure
        cmd3.CommandText = strcmd
        cmd3.Connection = weldone_con.ConObj
        cmd3.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim emp_id_ As Integer
        Dim deptId As Integer
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()

        '====================loginer details feed in top informer====================
        '        lbl_user_name.Text = loginer_ID
        command("sp_get_name_username_Department")
        cmd.Parameters.AddWithValue("@loginerID", loginer_ID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_name.Text = "Name Of Employee : " & rdr("name_")
            Session.Add("DEPT_ID", rdr("id"))
            lbl_welcome.Text = rdr("name_")

            deptId = rdr("id")
            lbl_dept.Text = "Department of " & rdr("dept_name")
        End If
        lbl_now.Text = Now()
        lbl_last_login.Text = Session.Item("last_login")

        '=============================================================================
        Dim count_ As Integer = 0
        Dim i As Integer = 0
        Dim strim As String = ""
        Dim exp_amt As Integer = 0

        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"

        strim &= "	            <td style=""width:44%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:6%"">"
        strim &= "Ticket ID"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "Auther"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "	                Date"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        i = 0
        command("sp_get_tickets_to_de")
        cmd.Parameters.AddWithValue("@emp_id", loginer_ID)
        '  cmd.Parameters.AddWithValue("@date_", DateTime.Today.AddDays(-30))
        rdr = cmd.ExecuteReader
        While rdr.Read
            Dim rec_date As DateTime = System.Convert.ToDateTime(rdr("last_update_date"))
            Dim today_date As DateTime = System.Convert.ToDateTime(Now())
            Dim ts As New TimeSpan()
            ts = today_date.Subtract(rec_date)
            Dim hnd_stts As String = rdr("now_hand_in")
            Dim minuts As Integer = ts.Minutes
            Dim hours As Integer = 0
            Dim ticket_id As Integer = rdr("id")
            hours = ts.Days * 24
            hours = hours + ts.Hours
            Dim days As Integer = ts.Days()
            Dim ia As Integer = 0
            While ia <= days
                Dim pri_days As Date = DateTime.Now.AddDays(-ia)
                If pri_days.DayOfWeek = DayOfWeek.Sunday Then
                    hours = hours - 24
                End If
                ia = ia + 1
            End While
            Dim disp_block As String = ""
            If hours > 24 And hours <= 48 Then
                If Not rdr("t_stts") = "SOLVED" Then
                    strim &= "	        <tr >"
                    strim &= "	            <td >"
                    strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("id") & "&"">" & rdr("t_sub") & " </a>"
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("disp_id")
                    strim &= "	            </td>"
                    strim &= "	            <td >"
                    strim &= rdr("branch_name")
                    strim &= "	            </td>"
                    strim &= "	            <td >"
                    strim &= rdr("name_")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("t_stts")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("last_update_date")
                    strim &= "	            </td>"
                    strim &= "	        </tr>"
                End If
            ElseIf hours > 48 Then
                If Not rdr("t_stts") = "SOLVED" Then
                    strim &= "	        <tr >"
                    strim &= "	            <td >"
                    strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("disp_id")
                    strim &= "	            </td>"
                    strim &= "	            <td >"
                    strim &= rdr("branch_name")
                    strim &= "	            </td>"
                    strim &= "	            <td >"
                    strim &= rdr("name_")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("t_stts")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("last_update_date")
                    strim &= "	            </td>"
                    strim &= "	        </tr>"
                End If
            Else
                If (hours >= 23) Then
                    disp_block &= ""
                    disp_block &= "   <div id=""showimage"" style=""position:absolute;width:250px;left:050px;top:450px"">"
                    disp_block &= "<table border=""0"" width=""250"" bgcolor=""#2CA0D6"" cellspacing=""0"" cellpadding=""2"">"
                    disp_block &= "<tr>"
                    disp_block &= " <td width=""100%""><table border=""0"" width=""100%"" cellspacing=""0"" cellpadding=""0""  height=""36px"">"
                    disp_block &= " <tr>"
                    disp_block &= "  <td id=""dragbar"" style=""cursor:move; cursor:move"" width=""100%"" onMousedown=""initializedrag(event)"">"
                    disp_block &= "<ilayer width=""100%"" onSelectStart=""return false"">"
                    disp_block &= "<layer width=""100%"" onMouseover=""dragswitch=1;if (ns4) drag_dropns(showimage)"" onMouseout=""dragswitch=0"">"
                    disp_block &= "<font face=""Verdana"" color=""#FFFFFF"">"
                    disp_block &= "<strong>"
                    disp_block &= "<small>"
                    disp_block &= " <img src=""images/ico_alpha_Exclamation_16x16.png""> Tecket Pendig Alert!"
                    disp_block &= "</small>"
                    disp_block &= "</strong>"
                    disp_block &= "</font>"
                    disp_block &= "</layer>"
                    disp_block &= "</ilayer>"
                    disp_block &= "</td>"
                    disp_block &= " <td style=""cursor:move"">"
                    disp_block &= "<a href=""#"" onClick=""hidebox();return false"">"
                    disp_block &= "<img src=""images/Delete_topic.jpg"" width=""16px"" height=""16px"" border=0>"
                    disp_block &= "</a>"
                    disp_block &= "</td>"
                    disp_block &= "</tr>"
                    disp_block &= "<tr>"
                    disp_block &= "  <td width=""100%"" bgcolor=""#FFFFFF"" style=""padding:4px"" colspan=""2"">"
                    disp_block &= "	<div class=""alrt_bx_1"">"
                    disp_block &= "Ticket ID : " & rdr("disp_id")
                    disp_block &= "<br>Subject : " & rdr("t_sub")
                    disp_block &= "<br>Sent On: " & rdr("last_update_date")
                    disp_block &= "<br>From Branch : " & rdr("branch_name")
                    disp_block &= "	<div>"
                    disp_block &= "</td>"
                    disp_block &= "</tr>"
                    disp_block &= "</table>"
                    disp_block &= " </td>"
                    disp_block &= "</tr>"
                    disp_block &= "</table>"
                    disp_block &= "</div>"
                    disp_alert.InnerHtml = disp_block
                End If
                strim &= "	        <tr >"
                strim &= "	            <td >"
                strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("disp_id")
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= rdr("branch_name")
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= rdr("name_")
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("t_stts")
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("last_update_date")
                strim &= "	            </td>"
                strim &= "	        </tr>"
              
                strim &= "	        </tr>"
            End If

            i = i + 1
        End While
        If i = 0 Then
            strim = "<span style=""margin-left:20px;display:block;font-family:Arial, Helvetica, sans-serif;font-size:13px;"">No New Ticket !</span>"
        End If
        strim &= "	    </table>"

        Disp_unread_ticks.InnerHtml = strim

        Try
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
            If Request.Cookies("admin")("login") = "false" Or Request.Cookies("admin")("login") Is Nothing Then
                Response.Redirect("employee/")
            End If
            '         If lbl_user_name.Text = 0 Then
            'Response.Redirect("employee/")
            'End If
        Catch ex As Exception
            Response.Redirect("employee/")
        End Try


        '=========== view all tickets ========
        pnl_view_all.Visible = True

        strim = ""
        Dim counter_ As Integer = 0
        i = 0
        command("sp_get_all_tickets_to_de")
        cmd.Parameters.AddWithValue("@emp_id", loginer_ID)
        cmd.Parameters.AddWithValue("@date_", DateTime.Today.AddDays(-30))
        rdr = cmd.ExecuteReader
        strim &= " <table class=""tbl_vall_clss"">"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:49%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:22%"" >"
        strim &= "Created On"
        strim &= "	            </td>"

        strim &= "	            <td style=""width:3%"">"
        strim &= "DEL"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "RES"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td >"
            strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("name_")
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("t_stts")
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("last_update_date")
            strim &= "	            </td>"

            strim &= "	            <td>"
            strim &= "<a href=""delete_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/Delete_topic.jpg""></a>"
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= "R"
            strim &= "	            </td>"
            strim &= "	        </tr>"
            i = i + 1
        End While
        strim &= "	        </table>"
        disp_all.InnerHtml = strim
        '=====================================
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        panal_post_comm.Visible = True
    End Sub

    Protected Sub btn_post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_post.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        Dim emp_id_ As Integer = loginer_ID
        Dim count_ As Integer = 0
        Dim i As Integer = 0
        Dim strim As String = ""
        command2("select * from tbl_ticket_master where t_sub like '%" & txt_search.Text & "%' and Pro_to_emp_id=" & emp_id_ & "and now_hand_in='DE'")
        rdr2 = cmd2.ExecuteReader
        While rdr2.Read
            count_ = count_ + 1
        End While
        Dim arrname(count_ + 1) As String
        Dim arr_uids(count_ + 1) As String

        command2("select * from tbl_ticket_master where t_sub like '%" & txt_search.Text & "%' and Pro_to_emp_id=" & emp_id_ & "and now_hand_in='DE'")
        rdr = cmd2.ExecuteReader
        i = 0
        While rdr.Read
            arr_uids(i) = rdr("creater_id")
            i = i + 1
        End While

        i = 0
        While i < count_
            command("sp_get_user_by_id")
            cmd.Parameters.AddWithValue("@uid", arr_uids(i))
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                arrname(i) = rdr("name_")
            End If
            i = i + 1
        End While
        strim &= " <h4>Search Result for <i>'" & txt_search.Text & "'</i></h4>"
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:51%"">"
        strim &= "Ticket Title"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "	                Date"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= " -"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= " -"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= " -"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        i = 0
        command2("select * from tbl_ticket_master where t_sub like '%" & txt_search.Text & "%' and Pro_to_emp_id=" & emp_id_ & "and now_hand_in='DE' order by last_update_date desc")
        rdr = cmd2.ExecuteReader
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td style=""width:51%"">"
            strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "&TnCAREeisgrate.html "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "	            <td style=""width:10%"">"
            strim &= arrname(i)
            strim &= "	            </td>"
            strim &= "	            <td style=""width:15%"" class=""date_ticks"">"
            strim &= rdr("t_stts")
            strim &= "	            </td>"
            strim &= "	            <td style=""width:15%"" class=""date_ticks"">"
            strim &= rdr("last_update_date")
            strim &= "	            </td>"
            strim &= "	            <td style=""width:3%"">"
            strim &= "<a href=""JavaScript:return false()"" OnClick=""window.open('admin_change_stts.aspx?tid=" & rdr("id") & "&Suraj.php ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')""> <img src=""images/change_stts.jpg"" /> </a>"
            strim &= "	            </td>"
            strim &= "	            <td style=""width:3%"">"
            strim &= " <img src=""images/Delete_topic.jpg"" />"
            strim &= "	            </td>"
            strim &= "	            <td style=""width:3%"">"
            strim &= " -"
            strim &= "	            </td>"
            strim &= "	        </tr>"
            i = i + 1
        End While
        If i = 0 Then
            strim = "<span style=""margin-left:20px;"">No Ticket found !</span>"
        End If
        strim &= "	    </table>"
        Disp_unread_ticks.InnerHtml = strim
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()


        Response.Cookies("admin")("login") = "false"
        ' Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("employee/")
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        Dim emp_id_ As Integer
        Dim deptId As Integer
        '====================loginer details feed in top informer====================
        '     lbl_user_name.Text = loginer_ID
        command("sp_get_details_by_loginerID")
        cmd.Parameters.AddWithValue("@loginerID", loginer_ID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            emp_id_ = rdr("forign_id")
        End If
        '=========== view all tickets ========
        Dim strim As String = ""
        'Dim i As Integer = 0
        'Label1.Text = "Deleted Tickets"
        'pnl_view_all.Visible = True
        'strim = ""
        'Dim counter_ As Integer = 0
        'i = 0
        'command("sp_get_deleted_ticks_by_emp_id")
        'cmd.Parameters.AddWithValue("@emp_id", emp_id_)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    counter_ = counter_ + 1
        'End While

        'Dim arr_by_(counter_ + 1) As Integer
        'Dim arr_disp_name(counter_ + 1) As String

        'command("sp_get_deleted_ticks_by_emp_id")
        'cmd.Parameters.AddWithValue("@emp_id", emp_id_)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    arr_by_(i) = rdr("creater_id")
        '    i = i + 1
        'End While
        'i = 0


        'While i < counter_
        '    command("sp_get_disp_name_by_loginer_id")
        '    cmd.Parameters.AddWithValue("@lid", arr_by_(i))
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        arr_disp_name(i) = rdr("display_name")
        '    End If
        '    i = i + 1
        'End While
        'i = 0
        ' MsgBox(emp_id_)
        command("sp_get_all_deleted_tickets_to_de")
        cmd.Parameters.AddWithValue("@emp_id", loginer_ID)
        rdr = cmd.ExecuteReader
        strim &= " <table class=""tbl_vall_clss"">"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:39%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:22%"" >"
        strim &= "	                Created On"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "followUP"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "RES"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "D"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td >"
            strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("name_")
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("t_stts")
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("last_update_date")
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("now_hand_in")
            strim &= "	            </td>"
            strim &= "	            <td>"
            strim &= "<a href=""restore_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/restore.png""></a>"
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= "R"
            strim &= "	            </td>"
            strim &= "	        </tr>"

        End While
        strim &= "	        </table>"
        disp_all.InnerHtml = strim
        '=====================================
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()
        '==============

        Response.Cookies("user")("login") = "false"
        '  Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("http://10.53.143.45:81/WebTradeNet/BACKUP")
    End Sub
End Class

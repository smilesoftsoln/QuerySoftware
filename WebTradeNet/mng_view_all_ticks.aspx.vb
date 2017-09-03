Imports System.Data.SqlClient
Partial Class mng_view_all_ticks
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
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim mng_id As Integer
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()
        '=======
        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_welcome.Text = rdr("name_")
            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
            mng_id = rdr("forign_id")
        End If
        Dim chl As Integer = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While

        Dim dept_id_(tot_arr + 1) As Integer
        Dim i As Integer = 0




        If Not Page.IsPostBack Then
            cbo_depts.Items.Add("ALL")
            command("sp_get_depts_by_mng_id")
            cmd.Parameters.AddWithValue("@mng_id", mng_id)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_depts.Items.Add(rdr("dept_name"))
            End While
        End If
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            i = i + 1
        End While


        i = 0

        strim &= " <table width=""100%"">"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:9%"" colspan=""7"">"
        strim &= "Running Ticktes Till - " & Today()
        strim &= "	            </td>"
        strim &= "	        </tr>"
        strim &= "<tr class=""updater_mid_tr_spl"">"
        strim &= "<td width=""10%"">"
        strim &= "Ticket ID"
        strim &= "</td>"
        strim &= "<td width=""35%"">"
        strim &= "Subject"
        strim &= "</td>"
        strim &= "<td width=""5%"">"
        strim &= "TYP"
        strim &= "</td>"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "Follower"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "From"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "To"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "Date"
        strim &= "</td>"
        strim &= "<td width=""10%""> "
        strim &= "Status"
        strim &= "</td>"
        strim &= "</tr>"

        While i < tot_arr
            command("sp_get_all_ticks_hod")
            rdr = cmd.ExecuteReader
            While rdr.Read
                If dept_id_(i) = rdr("to_dept_id") Then
                    'MsgBox("rdr(""to_dept_id"")=" & rdr("to_dept_id") & " & i=" & i)
                    strim &= "	        <tr >"
                    strim &= "	            <td >"
                    strim &= rdr("disp_id")
                    strim &= "	            </td>"
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "&TnCAREeisgrate.html "">" & rdr("t_sub") & " </a>"
                    strim &= "	            </td>"
                    strim &= "<td width=""5%"">"
                    If rdr("q_typ") = "NORMAL" Then
                        strim &= "<img src=""images/typ_normal.JPG"" >"
                    ElseIf rdr("q_typ") = "Transferred" Or rdr("q_typ") = "TRANSFERED" Then
                        strim &= "<img src=""images/typ_transferd.jpg"" >"
                    ElseIf rdr("q_typ") = "ESCALATED" Then
                        strim &= "<img src=""images/typ_escelated.jpg"" >"
                    ElseIf rdr("q_typ") = "DELETE" Or rdr("q_typ") = "DELETED" Then
                        strim &= "<img src=""images/typ_deleted.jpg"" >"
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
                    strim &= "	            <td>"
                    If (rdr("t_stts") = "SOLVED") Then
                        strim &= "<a href=""delete_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/Delete_topic.jpg""></a>"
                    End If
                    strim &= "	            </td>"
                    strim &= "	        </tr>"
                End If
            End While
            i = i + 1
        End While



        strim &= "	    </table>"
        disp_all_updates.InnerHtml = strim
    End Sub



    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_go.Click
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim mng_id As Integer
        Dim this_stts As String
        Dim heading_ As String = ""
        Dim typ As String = rdb_opns.SelectedValue
        If typ = "ALL" Then
            typ = "%%"
        End If
        Dim date_from As Date = "23/11/1990"
        Dim date_to As Date = Now
        Dim dept_id As String

        Dim q_typ As String = "%%"
        If cbo_type.SelectedValue = "Normal" Then
            q_typ = "Normal"
            heading_ &= "Normal Tickets"
        ElseIf cbo_type.SelectedValue = "Escalated" Then
            q_typ = "Escalated"
            heading_ &= "Escalated Tickets"
        ElseIf cbo_type.SelectedValue = "Transferred" Then
            q_typ = "Transferred"
            heading_ &= "Transferred Tickets"
        ElseIf cbo_type.SelectedValue = "DELETED" Then
            q_typ = "DELETE"
            heading_ &= "DELETED Tickets"
        ElseIf cbo_type.SelectedValue = "ALL" Then
            heading_ &= "ALL type of Tickets"
        End If

        If cbo_depts.SelectedValue = "ALL" Then
            dept_id = "%%"
            heading_ &= " of All Departments"
        Else
            command("sp_get_dept_id_by_name")
            cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                dept_id = rdr("id")
            End If
            heading_ &= " " & cbo_depts.SelectedValue & " Department"
        End If

        If fecha01.Text = "" Or fecha02.Text = "" Then
        Else
            date_from = fecha01.Text
            date_to = fecha02.Text & " 23:59:59"
            heading_ &= " Dated " & fecha01.Text & " to " & fecha02.Text
        End If

        If rdb_opns.SelectedValue = "ALL" Then
            this_stts = "%%"
        ElseIf rdb_opns.SelectedValue = "Solved" Then
            this_stts = "SOLVED"
            heading_ &= " (Solved )"
        ElseIf rdb_opns.SelectedValue = "UnSolved" Then
            this_stts = "UNSOLVED"
            heading_ &= " (UnSolved)"
        ElseIf rdb_opns.SelectedValue = "FOLLOW UP" Then
            this_stts = "FOLLOW UP"
            heading_ &= " (FOLLOW UP)"
        End If

        heading_ &= " -Till " & Now()

        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_welcome.Text = rdr("name_")
            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
            mng_id = rdr("forign_id")
        End If
        Dim chl As Integer = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While

        Dim dept_id_(tot_arr + 1) As Integer
        Dim i As Integer = 0




        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            i = i + 1
        End While



        i = 0

        strim &= " <table width=""100%"">"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:9%"" colspan=""7"">"
        strim &= "Running Ticktes Till - " & Today()
        strim &= "	            </td>"
        strim &= "	        </tr>"
        strim &= "<tr class=""updater_mid_tr_spl"">"
        strim &= "<td width=""10%"">"
        strim &= "Ticket ID"
        strim &= "</td>"
        strim &= "<td width=""35%"">"
        strim &= "Subject"
        strim &= "</td>"
        strim &= "<td width=""5%"">"
        strim &= "TYP"
        strim &= "</td>"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "Follower"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "From"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "To"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "Date"
        strim &= "</td>"
        strim &= "<td width=""10%""> "
        strim &= "Status"
        strim &= "</td>"
        strim &= "</tr>"
        While i < tot_arr
            command("sp_view_all_queryes")
            cmd.Parameters.AddWithValue("@t_stts", this_stts)
            cmd.Parameters.AddWithValue("@date_from", date_from)
            cmd.Parameters.AddWithValue("@date_to", date_to)
            cmd.Parameters.AddWithValue("@q_typ", q_typ)
            cmd.Parameters.AddWithValue("@to_dept_id", dept_id)
            rdr = cmd.ExecuteReader
            While rdr.Read
                If dept_id_(i) = rdr("to_dept_id") Then
                    strim &= "	        <tr >"
                    strim &= "	            <td >"
                    strim &= rdr("disp_id")
                    strim &= "	            </td>"
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "&TnCAREeisgrate.html "">" & rdr("t_sub") & " </a>"
                    strim &= "	            </td>"
                    strim &= "<td width=""5%"">"
                    If rdr("q_typ") = "NORMAL" Then
                        strim &= "<img src=""images/typ_normal.JPG"" >"
                    ElseIf rdr("q_typ") = "Transferred" Or rdr("q_typ") = "TRANSFERED" Then
                        strim &= "<img src=""images/typ_transferd.jpg"" >"
                    ElseIf rdr("q_typ") = "ESCALATED" Then
                        strim &= "<img src=""images/typ_escelated.jpg"" >"
                    ElseIf rdr("q_typ") = "DELETE" Or rdr("q_typ") = "DELETED" Then
                        strim &= "<img src=""images/typ_deleted.jpg"" >"
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
                    strim &= "	            <td>"
                    If (rdr("t_stts") = "SOLVED") Then
                        strim &= "<a href=""delete_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/Delete_topic.jpg""></a>"
                    End If
                    strim &= "	            </td>"
                    strim &= "	        </tr>"
                End If
            End While
            i = i + 1
        End While



        strim &= "	    </table>"
        pnl_ticket_typ.Text = heading_
        disp_all_updates.InnerHtml = strim

    End Sub

    Protected Sub btn_exp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exp.Click
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim mng_id As Integer
        Dim this_stts As String
        Dim heading_ As String = ""
        Dim typ As String = rdb_opns.SelectedValue
        If typ = "ALL" Then
            typ = "%%"
        End If
        Dim date_from As Date = "23/11/1990"
        Dim date_to As Date = Now
        Dim dept_id As String

        Dim q_typ As String = "%%"
        If cbo_type.SelectedValue = "Normal" Then
            q_typ = "Normal"
            heading_ &= "Normal Tickets"
        ElseIf cbo_type.SelectedValue = "Escalated" Then
            q_typ = "Escalated"
            heading_ &= "Escalated Tickets"
        ElseIf cbo_type.SelectedValue = "Transferred" Then
            q_typ = "Transferred"
            heading_ &= "Transferred Tickets"
        ElseIf cbo_type.SelectedValue = "DELETED" Then
            q_typ = "DELETE"
            heading_ &= "DELETED Tickets"
        ElseIf cbo_type.SelectedValue = "ALL" Then
            heading_ &= "ALL type of Tickets"
        End If

        If cbo_depts.SelectedValue = "ALL" Then
            dept_id = "%%"
            heading_ &= " of All Departments"
        Else
            command("sp_get_dept_id_by_name")
            cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                dept_id = rdr("id")
            End If
            heading_ &= " " & cbo_depts.SelectedValue & " Department"
        End If

        If fecha01.Text = "" Or fecha02.Text = "" Then
        Else
            date_from = fecha01.Text
            date_to = fecha02.Text & " 23:59:59"
            heading_ &= " Dated " & fecha01.Text & " to " & fecha02.Text
        End If

        If rdb_opns.SelectedValue = "ALL" Then
            this_stts = "%%"
        ElseIf rdb_opns.SelectedValue = "Solved" Then
            this_stts = "SOLVED"
            heading_ &= " (Solved )"
        ElseIf rdb_opns.SelectedValue = "UnSolved" Then
            this_stts = "UNSOLVED"
            heading_ &= " (UnSolved)"
        ElseIf rdb_opns.SelectedValue = "FOLLOW UP" Then
            this_stts = "FOLLOW UP"
            heading_ &= " (FOLLOW UP)"
        End If

        heading_ &= " -Till " & Now()

        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_welcome.Text = rdr("name_")
            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
            mng_id = rdr("forign_id")
        End If
        Dim chl As Integer = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While

        Dim dept_id_(tot_arr + 1) As Integer
        Dim i As Integer = 0

        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            i = i + 1
        End While



        i = 0

        strim &= " <table border=""1"" width=""75%"">"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:9%"" colspan=""7"">"
        strim &= "Running Ticktes Till - " & Today()
        strim &= "	            </td>"
        strim &= "	        </tr>"
        strim &= "<tr class=""updater_mid_tr_spl"">"
        strim &= "<td width=""10%"">"
        strim &= "Ticket ID"
        strim &= "</td>"
        strim &= "<td width=""35%"">"
        strim &= "Subject"
        strim &= "</td>"
        strim &= "<td width=""5%"">"
        strim &= "TYP"
        strim &= "</td>"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "Follower"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "From"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "To"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "Date"
        strim &= "</td>"
        strim &= "<td width=""10%""> "
        strim &= "Status"
        strim &= "</td>"
        strim &= "</tr>"
        While i < tot_arr
            command("sp_view_all_queryes")
            cmd.Parameters.AddWithValue("@t_stts", this_stts)
            cmd.Parameters.AddWithValue("@date_from", date_from)
            cmd.Parameters.AddWithValue("@date_to", date_to)
            cmd.Parameters.AddWithValue("@q_typ", q_typ)
            cmd.Parameters.AddWithValue("@to_dept_id", dept_id)
            rdr = cmd.ExecuteReader
            While rdr.Read
                If dept_id_(i) = rdr("to_dept_id") Then
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
                        strim &= "DELETED"
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
                    strim &= "	            <td>"
                    If (rdr("t_stts") = "SOLVED") Then
                        strim &= "<a href=""delete_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/Delete_topic.jpg""></a>"
                    End If
                    strim &= "	            </td>"
                    strim &= "	        </tr>"
                End If
            End While
            i = i + 1
        End While



        strim &= "	    </table>"

        disp_all_updates.InnerHtml = strim

        Response.ContentType = "application/xls"
        Response.AddHeader("content-disposition", "attachment;filename=" & Now.Year() & Now.Month() & Now.Day() & ".xls")
        Response.Charset = ""
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Me.Controls.Add(frm)
        frm.RenderControl(hw)
        Response.Write("<h5>" & heading_ & "</h5>")
        Response.Write(strim)
        tw.Write("hi2")
        Response.End()

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()
        '==========

        Response.Cookies("admin")("login") = "false"
        'Session.Clear()
        ' Session.Abandon()
        Response.Cookies.Clear()
        Response.Redirect("")

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim mng_id As Integer
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()
        '=======
        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_welcome.Text = rdr("name_")
            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
            mng_id = rdr("forign_id")
        End If
        Dim chl As Integer = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While

        Dim dept_id_(tot_arr + 1) As Integer
        Dim i As Integer = 0




        If Not Page.IsPostBack Then
            cbo_depts.Items.Add("ALL")
            command("sp_get_depts_by_mng_id")
            cmd.Parameters.AddWithValue("@mng_id", mng_id)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_depts.Items.Add(rdr("dept_name"))
            End While
        End If
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            i = i + 1
        End While


        i = 0

        strim &= " <table width=""100%"">"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:9%"" colspan=""7"">"
        strim &= "Running Ticktes Till - " & Today()
        strim &= "	            </td>"
        strim &= "	        </tr>"
        strim &= "<tr class=""updater_mid_tr_spl"">"
        strim &= "<td width=""10%"">"
        strim &= "Ticket ID"
        strim &= "</td>"
        strim &= "<td width=""35%"">"
        strim &= "Subject"
        strim &= "</td>"
        strim &= "<td width=""5%"">"
        strim &= "TYP"
        strim &= "</td>"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "Follower"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "From"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "To"
        strim &= "</td>"
        strim &= "<td width=""10%"">"
        strim &= "Date"
        strim &= "</td>"
        strim &= "<td width=""10%""> "
        strim &= "Status"
        strim &= "</td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "RES"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "D"
        strim &= "	            </td>"
        strim &= "</tr>"

        While i < tot_arr
            command("sp_get_all_deleted_tickets_to_hod")
            rdr = cmd.ExecuteReader
            While rdr.Read
                If dept_id_(i) = rdr("to_dept_id") Then
                    'MsgBox("rdr(""to_dept_id"")=" & rdr("to_dept_id") & " & i=" & i)
                    strim &= "	        <tr >"
                    strim &= "	            <td >"
                    strim &= rdr("disp_id")
                    strim &= "	            </td>"
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "&TnCAREeisgrate.html "">" & rdr("t_sub") & " </a>"
                    strim &= "	            </td>"
                    strim &= "<td width=""5%"">"
                    If rdr("q_typ") = "NORMAL" Then
                        strim &= "<img src=""images/typ_normal.JPG"" >"
                    ElseIf rdr("q_typ") = "Transferred" Or rdr("q_typ") = "TRANSFERED" Then
                        strim &= "<img src=""images/typ_transferd.jpg"" >"
                    ElseIf rdr("q_typ") = "ESCALATED" Then
                        strim &= "<img src=""images/typ_escelated.jpg"" >"
                    ElseIf rdr("q_typ") = "DELETE" Or rdr("q_typ") = "DELETED" Then
                        strim &= "<img src=""images/typ_deleted.jpg"" >"
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
                    strim &= "	            <td>"
                    strim &= "<a href=""restore_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/restore.png""></a>"
                    strim &= "	            </td>"
                    strim &= "	            <td >"
                    strim &= "R"
                    strim &= "	            </td>"
                    strim &= "	        </tr>"
                End If
            End While
            i = i + 1
        End While



        strim &= "	    </table>"
        disp_all_updates.InnerHtml = strim

    End Sub
End Class

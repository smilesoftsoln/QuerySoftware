Imports System.Data.SqlClient
Partial Class hod_view_all_ticks
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Dim nbr_of_deleted_chkbox As Integer

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
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginerID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()
        '============
        command("sp_get_hod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            ' lbl_name.Text = "Name  : " & rdr("name_")
            lbl_welcome.Text = rdr("name_")
            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
        End If

        command("sp_get_hod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While
        Dim dept_id_(tot_arr + 1) As Integer

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim cbname As String

        command("sp_get_hod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            'MsgBox("dept_id_(" & i & ")=" & dept_id_(i))
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
        strim &= "<td width=""30%"">"
        strim &= "Subject"
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
        strim &= "<td style=""width:10%"">"
        strim &= "Resolve Time"
        strim &= "</td>"
        strim &= "<td style=""width:10%"">"
        strim &= "Delete?"
        strim &= "</td>"


        strim &= "</tr>"
        nbr_of_deleted_chkbox = 0
        While i < tot_arr
            command("sp_get_all_ticks_hod")
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
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= rdr("resolve_time")
                    strim &= "	            </td>"
                    strim &= "	            <td>"
                    If (rdr("t_stts") = "SOLVED") Then
                        strim &= "<a href=""delete_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/Delete_topic.jpg""></a>"
                    End If
                    strim &= "	            </td>"
                    '                   strim &= "	            <td>"
                    '                    If (rdr("t_stts") = "SOLVED") Then
                    '                    cbname = "cb" & Trim(j)
                    '                    j = j + 1
                    '                    nbr_of_deleted_chkbox = nbr_of_deleted_chkbox + 1
                    '                    strim &= "<input id=" & cbname & " type=""checkbox"" value=" & rdr("id") & "/>"
                    '                End If
                    '                    strim &= "	            </td>"
                    strim &= "	        </tr>"
                End If
            End While
            i = i + 1
        End While



        strim &= "	    </table>"
        disp_all_updates.InnerHtml = strim
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()
        '==========

        Response.Cookies("admin")("login") = "false"
        'Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub

    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim typ As String = rdb_opns.SelectedValue
        If typ = "ALL" Then
            typ = "%%"
        End If

        command("sp_get_hod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            ' lbl_name.Text = "Name  : " & rdr("name_")
            lbl_welcome.Text = rdr("name_")
            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
        End If

        command("sp_get_hod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While
        Dim dept_id_(tot_arr + 1) As Integer

        Dim i As Integer = 0

        command("sp_get_hod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            'MsgBox("dept_id_(" & i & ")=" & dept_id_(i))
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
        strim &= "<td width=""30%"">"
        strim &= "Subject"
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
        strim &= "<td width=""10%""> "
        strim &= "Resolve Time"
        strim &= "</td>"
        strim &= "<td style=""width:10%"">"
        strim &= "Delete?"
        strim &= "</td>"


        strim &= "</tr>"
        nbr_of_deleted_chkbox = 0
        While i < tot_arr
            command("sp_get_all_ticks_hod_2")
            cmd.Parameters.AddWithValue("@typ", typ)
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
                    strim &= "	            <td class=""date_ticks"">"
                    strim &= rdr("resolve_time")
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

    '    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
    '    Dim ctr As Integer
    '    Dim cb_name As String
    '    Dim chkd As Boolean
    '        For ctr = 0 To nbr_of_deleted_chkbox - 1
    '            cb_name = "cb" & Trim(ctr)
    '    Dim myType1 As Type = GetType(System.Web.UI.WebControls.CheckBox)  '("System.Web.UI.WebControls.CheckBox")
    '            myType1.
    '
    '            chkd = myType1.InvokeMember("Checked", Reflection.BindingFlags.InvokeMethod, System.Type., System.DBNull.Value, New Object() {}
    '
    'chkd = (Type.GetType(cb_name)).InvokeMember("checked", Reflection.BindingFlags.Default, ,System.DBNull.Value,new Object[] {})
    '
    '        Next
    '    End Sub


    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        Dim emp_id_ As Integer
        Dim deptId As Integer
        '====================loginer details feed in top informer====================
        'lbl_user_name.Text = loginer_ID
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
        command("sp_get_all_deleted_tickets_to_hod")
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
            strim &= rdr("auther")
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
        disp_all_updates.InnerHtml = strim
        '=====================================

    End Sub
End Class

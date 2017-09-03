Imports System.Data.SqlClient
Partial Class mng_login_next
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim cmd3 As New SqlCommand
    Dim rdr2 As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Sub command2(ByVal strcmd As String)
        cmd2.CommandType = Data.CommandType.StoredProcedure
        cmd2.CommandText = strcmd
        cmd2.Connection = weldone_con.ConObj
        cmd2.Parameters.Clear()
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
        '===========
        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_name.Text = "Name  : " & rdr("name_")
            lbl_welcome.Text = rdr("name_")
            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
            mng_id = rdr("forign_id")
            Session.Add("MNG_ID", mng_id)
            Session.Add("manage_id", mng_id)

        End If
        Dim chl As Integer = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            lbl_dept.Text &= "<br><b>" & rdr("dept_name") & "'</b> "
            tot_arr = tot_arr + 1
        End While
        lbl_now.Text = Now()

        Dim dept_id_(tot_arr - 1) As Integer
        Dim i As Integer = 0

        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            ' MsgBox(dept_id_(i))
            i = i + 1
        End While

        i = 0
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:6%"">"
        strim &= "Ticket ID"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:41%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "From"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "To"
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
        strim &= "	        </tr>"
        command("sp_get_ticketsby_dept_id_to_mng")
        rdr = cmd.ExecuteReader
        If Array.BinarySearch(dept_id_, 1) > -1 Then
            i = i
        End If
        While rdr.Read
            If Array.IndexOf(dept_id_, rdr("to_dept_id")) > -1 Then
                strim &= "	        <tr >"
                strim &= "	            <td >"
                strim &= rdr("disp_id")
                strim &= "	            </td>"
                strim &= "	            <td class=""date_ticks"">"
                strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("id") & "&TnCAREeisgrate.html "">" & rdr("t_sub") & " </a>"
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= rdr("branch_name") & "<br>(" & rdr("auther") & ")"
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= rdr("dept_name") & "<br>(" & rdr("username_") & ")"
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("t_stts")
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("last_update_date")
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= "<a href=""JavaScript:return false()"" OnClick=""window.open('admin_change_stts.aspx?tid=" & rdr("id") & "&Suraj.php ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')""> <img src=""images/change_stts.jpg"" onMouseover=""showhint('Click Here To Change Status topic " & rdr("t_sub") & " ', this, event, '150px')""/> </a>"
                strim &= "	            </td>"
                strim &= "	        </tr>"
            End If
        End While
        strim &= "	    </table>"
        Disp_unread_ticks.InnerHtml = strim

        i = 0
        Dim tot_apps As Integer = 0
        Dim tid As Integer
        Dim app_id As Integer
        Dim j As Integer = 0
        While i < tot_arr
            command("sp_get_approvals_to_mng")
            rdr = cmd.ExecuteReader
            While rdr.Read
                If dept_id_(i) = rdr("dept_id") Then
                    'MsgBox(dept_id_(i))
                    tot_apps = tot_apps + 1
                    tid = rdr("t_id")
                    app_id = rdr("id")

                End If
            End While



            i = i + 1
        End While

        If tot_apps > 0 Then
            lbl_tot_apps.Visible = True
            lbl_tot_apps.Text = "<a href=""new_approval.aspx?t_id=" & tid & "&app_id=" & app_id & " "" >(" & tot_apps & ") New Approval(s)</a>"

        End If

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
        ' Session.Clear()
        ' Session.Abandon()
        Response.Cookies.Clear()
        Response.Redirect("hod/")
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("mng_search_tickets.aspx")
    End Sub

End Class

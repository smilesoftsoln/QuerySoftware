Imports System.Data.SqlClient
Partial Class mng_search_tickets
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
    Sub command2(ByVal strcmd As String, ByVal uid As Integer)
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = "select * from tbl_ticket_master where creater_id=" & uid & " and  t_sub like '%" & strcmd & "%'"
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Sub command3(ByVal strcmd As String, ByVal uid As Integer)
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = "select * from tbl_ticket_master where creater_id=" & uid & " and  disp_id like '%" & strcmd & "%'"
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Sub command4(ByVal strcmd As String, ByVal strarr As Array)
        Dim ctxt As String
        cmd.CommandType = Data.CommandType.Text
        ctxt = "select * from tbl_ticket_master where t_sub like '%" & strcmd & "%' and to_dept_id in ("
        For j As Integer = 0 To strarr.Length - 1
            ctxt = ctxt & strarr(j)
            If (j < strarr.Length - 1) Then
                ctxt = ctxt & ","
            End If
        Next

        ctxt = ctxt & ") order by last_update_date desc"
        cmd.CommandText = ctxt
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Sub command5(ByVal strcmd As String, ByVal strarr As Array)
        Dim ctxt As String
        cmd.CommandType = Data.CommandType.Text
        ctxt = "select * from tbl_ticket_master where disp_id like '%" & strcmd & "%' and to_dept_id in ("
        For j As Integer = 0 To strarr.Length - 1
            ctxt = ctxt & strarr(j)
            If (j < strarr.Length - 1) Then
                ctxt = ctxt & ","
            End If
        Next

        ctxt = ctxt & ") order by last_update_date desc"
        cmd.CommandText = ctxt
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Request.Cookies("admin")("login") = "false" Then
                Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
            End If

        Catch ex As Exception
            Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
        End Try
        loginerID = Session.Item("loginerID")
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()


    End Sub
    Protected Sub btn_post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_post.Click
        loginerID = Session.Item("loginerID")
        lbl_titl.Text = txt_search.Text
        Dim strim As String = ""
        strim &= " <table>"
        strim &= "<tr class=""updater_mid_tr_spl"">"
        strim &= "<td>"
        strim &= "Ticket ID"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "Subject"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "To Dept"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "Date"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "Status"
        strim &= "</td>"
        strim &= "</tr>"
        Dim strm2 As String = ""

        Dim i As Integer = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", Session.Item("MNG_ID"))
        rdr = cmd.ExecuteReader()
        While rdr.Read
            i = i + 1
        End While
        Dim arr_size = i
        i = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", Session.Item("MNG_ID"))
        rdr = cmd.ExecuteReader()
        If arr_size > 0 Then
            Dim arr_dept(arr_size) As Integer
            Dim arr_dept_name(arr_size) As String
            While rdr.Read
                arr_dept(i) = rdr("dept_id")
                arr_dept_name(i) = rdr("dept_name")
                i = i + 1
            End While


            If rdb_by.SelectedValue = "Subject" Then 'search by subject==========
                command4(txt_search.Text, arr_dept)
            ElseIf rdb_by.SelectedValue = "Ticket ID" Then 'search by Ticket ID==========
                command5(txt_search.Text, arr_dept)
            End If
            Dim counter As Integer = 0
            'cmd.Parameters.AddWithValue("@uid", loginerID)
            rdr = cmd.ExecuteReader
            i = 0
            '==============================

            While rdr.Read
                strim &= "<tr >"
                strim &= "<td width=""15%"">"
                strim &= rdr("disp_id")
                strim &= "</td>"
                strim &= "<td width=""45%"">"
                strim &= "<a href=""view_ticket.aspx?tid=" & rdr("id") & "&TnCAREeisgrate.html "">"
                strim &= rdr("t_sub")
                strim &= "</a>"
                strim &= "</td>"
                strim &= "<td width=""15%"">"
                strim &= arr_dept_name(Array.IndexOf(arr_dept, rdr("to_dept_id")))
                strim &= "</td>"
                strim &= "<td width=""15%"" style=""font-size:10px;"">"
                strim &= rdr("last_update_date")
                strim &= "</td>"
                strim &= "<td width=""10%"" style=""font-size:10px;"">"
                strim &= rdr("t_stts")
                strim &= "</td>"
                strim &= "</tr>"
            End While
        End If
        strim &= "	    </table>"
        disp_search_updates.InnerHtml = strim
        pnl_search_resut.Visible = True
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()
        '==============

        Response.Cookies("admin")("login") = "false"
        'Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("")

    End Sub
End Class

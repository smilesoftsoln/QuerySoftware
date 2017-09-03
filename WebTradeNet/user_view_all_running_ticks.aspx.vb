Imports System.Data.SqlClient
Partial Class user_view_all_running_ticks
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
        Try
            If Request.Cookies("user")("login") = "false" Then
                Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
            End If

        Catch ex As Exception
            Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
        End Try
        loginerID = Session.Item("loginerID")
        Dim strim As String = ""

        '========== get depts==========

        Dim counter As Integer = 0
        command("sp_get_unsolved_ticks")
        cmd.Parameters.AddWithValue("@uid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            counter = counter + 1
        End While

        Dim arr_dept(counter + 1) As Integer
        Dim i As Integer = 0
        Dim arr_dept_name(counter + 1) As String

        command("sp_get_unsolved_ticks")
        cmd.Parameters.AddWithValue("@uid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            arr_dept(i) = rdr("to_dept_id")
            i = i + 1
        End While
        i = 0

        While i < counter
            command("sp_get_dept_by_id")
            cmd.Parameters.AddWithValue("@id", arr_dept(i))
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                arr_dept_name(i) = rdr("dept_name")
            End If
            i = i + 1
        End While
        i = 0


        '==============================
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:9%"" colspan=""5"">"
        strim &= "Running Ticktes Till - " & Today()
        strim &= "	            </td>"
        strim &= "	        </tr>"
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
        Dim up_cout As Integer = 0
        command("sp_get_unsolved_ticks")
        cmd.Parameters.AddWithValue("@uid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read

            strim &= "<tr >"
            strim &= "<td width=""15%"">"
            strim &= rdr("disp_id")
            strim &= "</td>"
            strim &= "<td width=""45%"">"
            strim &= "<a href=""view_ticket.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html "">"
            strim &= rdr("t_sub")
            strim &= "</a>"
            strim &= "</td>"
            strim &= "<td width=""15%"">"
            strim &= arr_dept_name(i)
            strim &= "</td>"
            strim &= "<td width=""15%"" style=""font-size:10px;"">"
            strim &= rdr("date_")
            strim &= "</td>"
            strim &= "<td width=""10%"" style=""font-size:10px;"">"
            strim &= rdr("t_stts")
            strim &= "</td>"
            strim &= "</tr>"
            i = i + 1
            ' strim &= "	        <tr >"
            ' strim &= "	            <td >"
            ' strim &= "<a href=""view_ticket.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html "">" & rdr("t_sub") & " <span class=""disp_id"">(" & rdr("disp_id") & ")</span> </a>"
            ' strim &= "	            </td>"
            'up_cout = up_cout + 1
            'strim &= "	        </tr>"

        End While
        strim &= "	    </table>"
        disp_all_updates.InnerHtml = strim
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Cookies("user")("login") = "false"
        ' Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub
End Class

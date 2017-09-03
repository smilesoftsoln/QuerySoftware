Imports System.Data.SqlClient
Partial Class admin_view_tickets_by_timespan
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Public sepm As Integer = 0
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_go.Click
        If fecha01.Text = "" Or fecha02.Text = "" Then
            Response.Redirect("admin_view_tickets_by_timespan.aspx")
        End If
        Dim date_from As Date = fecha01.Text
        Dim date_to As Date = fecha02.Text
        Label1.Text = fecha01.Text & " To " & fecha02.Text

        Dim count_ As Integer = 0
        Dim i As Integer = 0
        Dim strim As String = ""

        command("sp_get_tick_by_timespan")
        cmd.Parameters.AddWithValue("@val1", date_from)
        cmd.Parameters.AddWithValue("@val2", date_to)
        rdr = cmd.ExecuteReader
        While rdr.Read
            count_ = count_ + 1
        End While

        Dim arrname(count_ + 1) As String
        Dim arr_uids(count_ + 1) As String
        Dim arr_to_dept_id(count_ + 1) As Integer
        Dim dept_name(count_ + 1) As String

        command("sp_get_tick_by_timespan")
        cmd.Parameters.AddWithValue("@val1", date_from)
        cmd.Parameters.AddWithValue("@val2", date_to)
        rdr = cmd.ExecuteReader
        While rdr.Read
            arr_uids(i) = rdr("creater_id")
            arr_to_dept_id(i) = rdr("to_dept_id")
            i = i + 1
        End While

        i = 0
        While i < count_
            command("sp_get_user_by_id")
            cmd.Parameters.AddWithValue("@uid", arr_uids(i))
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                arrname(i) = rdr("display_name")

            End If
            i = i + 1
        End While
        i = 0

        While i < count_
            command("sp_get_dept_by_id")
            cmd.Parameters.AddWithValue("@id", arr_to_dept_id(i))
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                dept_name(i) = rdr("dept_name")

            End If
            i = i + 1
        End While
        i = 0

        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:51%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "To"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "	                Date"
        strim &= "	            </td>"
        'strim &= "	            <td style=""width:3%"">"
        'strim &= " -"
        'strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= " -"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= " -"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        command("sp_get_tick_by_timespan")
        cmd.Parameters.AddWithValue("@val1", date_from)
        cmd.Parameters.AddWithValue("@val2", date_to)
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td style=""width:51%"">"
            strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "& "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "	            <td style=""width:10%"">"
            strim &= dept_name(i)
            strim &= "	            </td>"
            strim &= "	            <td style=""width:10%"">"
            strim &= arrname(i)
            strim &= "	            </td>"
            strim &= "	            <td style=""width:15%"" class=""date_ticks"">"
            strim &= rdr("t_stts")
            strim &= "	            </td>"

            strim &= "	            <td style=""width:15%"" class=""date_ticks"">"
            strim &= rdr("date_")
            strim &= "	            </td>"
            'strim &= "	            <td style=""width:3%"">"
            'strim &= "<a href=""JavaScript:return false()"" OnClick=""window.open('admin_change_stts.aspx?tid=" & rdr("t_id") & "&Suraj.php ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')""> <img src=""images/change_stts.jpg"" onMouseover=""showhint('Click Here To Change Status topic " & rdr("t_sub") & " ', this, event, '150px')""/> </a>"
            'strim &= "	            </td>"
            strim &= "	            <td style=""width:3%"">"
            strim &= "<a href=""JavaScript:return false()"" OnClick=""window.open('admin_delete_topic.aspx?tid=" & rdr("t_id") & "&Suraj.php ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')""> <img src=""images/Delete_topic.jpg"" onMouseover=""showhint('Click Here To Delete topic " & rdr("t_sub") & " ', this, event, '150px')""/> </a>"
            strim &= "	            </td>"
            strim &= "	            <td style=""width:3%"">"
            strim &= " -"
            strim &= "	            </td>"
            strim &= "	        </tr>"
            i = i + 1
        End While
        If i = 0 Then
            strim = "<span style=""margin-left:20px;"">No Ticket(s) Found !</span>"
        End If
        strim &= "	    </table>"

        pnl_search_resut.Visible = True
        Disp_timespan_ticks.InnerHtml = strim

       
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())

    End Sub
End Class

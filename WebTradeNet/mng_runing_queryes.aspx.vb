Imports System.Data.SqlClient
Partial Class mng_runing_queryes
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Sub command2(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim mng_id As Integer


        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
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

        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:6%"">"
        strim &= "Ticket ID"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:31%"">"
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
        strim &= " Date"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "Follow"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " -"
        strim &= "	            </td>"
        strim &= "	        </tr>"

        While i < tot_arr
            command("sp_get_tickets_by_dept_id_running")
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
                    strim &= rdr("branch_name")
                    strim &= "	            </td>"
                    strim &= "	            <td >"
                    strim &= rdr("dept_name")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("t_stts")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("last_update_date")
                    strim &= "	            </td>"
                    strim &= "	            <td  class=""date_ticks"">"
                    strim &= rdr("now_hand_in")
                    strim &= "	            </td>"
                    strim &= "	            <td >"
                    strim &= "<a href=""JavaScript:return false()"" onMouseover=""showhint('" & rdr("name_") & " ', this, event, '150px')"">" & rdr("reciver") & "</a>"
                    strim &= "	            </td>"
                    strim &= "	        </tr>"
                End If
            End While
            i = i + 1
        End While



        strim &= "	    </table>"
        disp_result.InnerHtml = strim
    End Sub
End Class

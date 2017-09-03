Imports System.Data.SqlClient
Partial Class hod_runing_queryes
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
        Dim deptId As Integer = Session.Item("deptId")
        Dim strim As String = ""
        Dim count_ As Integer = 0
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim tot_arr As Integer = 0
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
                    If rdr("now_hand_in") = "DE" Then
                        strim &= "	        <tr >"
                        strim &= "	            <td >"
                        strim &= rdr("disp_id")
                        strim &= "	            </td>"
                        strim &= "	            <td class=""date_ticks"">"
                        strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
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
                    Else
                        strim &= "	        <tr >"
                        strim &= "	            <td >"
                        strim &= rdr("disp_id")
                        strim &= "	            </td>"
                        strim &= "	            <td class=""date_ticks"">"
                        strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
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
                        strim &= "(Current)"
                        strim &= "	            </td>"
                        strim &= "	        </tr>"
                    End If
                End If
            End While
            i = i + 1
        End While
        strim &= "	    </table>"
        disp_result.InnerHtml = strim
    End Sub

    Protected Sub txt_search_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        pnl_main_.Visible = False
        pnl_search.Visible = True
        Dim strim As String = ""
        Dim deptId As Integer = Session.Item("deptId")
        strim &= " <h5>All Tickets</h5>"
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:51%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "Ticket ID"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:6%"">"
        strim &= " By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "	                Date"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:8%"">"
        strim &= "Follow"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        command2("select * from tbl_ticket_master where t_sub like '%" & txt_search.Text & "%' and to_dept_id=" & deptId & " ")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td >"
            strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "& "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "	            <td class=""date_ticks"">"
            strim &= rdr("disp_id")
            strim &= "	            </td>"
            strim &= "	            <td class=""date_ticks"">"
            strim &= rdr("creater_id")
            strim &= "	            </td>"
            strim &= "	            <td class=""date_ticks"">"
            strim &= rdr("t_stts")
            strim &= "	            </td>"
            strim &= "	            <td class=""date_ticks"">"
            strim &= rdr("date_")
            strim &= "	            </td>"
            strim &= "	            <td class=""date_ticks"">"
            strim &= rdr("now_hand_in")
            'strim &= loginerids(i)
            strim &= "	            </td>"
            strim &= "	        </tr>"
        End While
        strim &= "	        </table>"
        disp_search_result.InnerHtml = strim
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

    End Sub
End Class

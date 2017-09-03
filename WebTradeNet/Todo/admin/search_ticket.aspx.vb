Imports System.Data.SqlClient
Partial Class admin_search_ticket
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
        Dim strim As String = ""

        strim &= " <table cellpadding=""0"" cellspacing=""0"" class=""table_1"" style=""font-size:10px;"">"

        strim &= "<tr class=""updater_mid_tr_spl"" style=""background-color:#cccccc;font-weight:bold;"">"
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

        command("sp_search_ticket")
        cmd.Parameters.AddWithValue("@keyword", "%" & txt_search.Text & "%")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td >"
            strim &= rdr("disp_id")
            strim &= "	            </td>"
            strim &= "	            <td class=""date_ticks"">"
            strim &= "<a href=""../hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "&TraerNEtstockbroking.com "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "<td width=""5%"">"
            If rdr("q_typ") = "NORMAL" Then
                strim &= "<img src=""../images/typ_normal.JPG"" >"
            ElseIf rdr("q_typ") = "Transferred" Or rdr("q_typ") = "TRANSFERED" Then
                strim &= "<img src=""../images/typ_transferd.jpg"" >"
            ElseIf rdr("q_typ") = "ESCALATED" Then
                strim &= "<img src=""../images/typ_escelated.jpg"" >"
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
            strim &= "	        </tr>"

        End While
        strim &= "	    </table>"
        Disp_search_result.InnerHtml = strim

    End Sub
End Class

Imports System.Data.SqlClient
Partial Class admin_view_this_login_history_
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ths_user As Integer = Request.QueryString("loginer")
        Dim strim As String = ""

        strim &= "<table class=""tbl_gw"">"
        strim &= "<tr class=""tbl_gw_spl"">"
        strim &= "<td>"
        strim &= "Login History"
        strim &= "</td>"
        strim &= "</tr>"

        command("sp_get_user_info")
        cmd.Parameters.AddWithValue("@uid", ths_user)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_name.Text = rdr("display_name")
        End If

        command("sp_get_login_historu_by_id")
        cmd.Parameters.AddWithValue("@loginerID", ths_user)
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "<tr>"
            strim &= "<td>"
            strim &= rdr("time_value")
            strim &= "</td>"
            strim &= "</tr>"
        End While
        strim &= "</table>"
        Disp_result_login_history.innerhtml = strim
    End Sub
End Class

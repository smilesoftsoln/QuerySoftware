Imports System.Data.SqlClient
Partial Class admin_delly_login_report
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
        Dim strim As String = ""
        Dim i As Integer = 0
        strim &= "<table class=""flexme1"" >"
        strim &= "<thead>"
        strim &= "<tr >"
        strim &= "<th width=""50"">"
        strim &= "No."
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "Username"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "Name"
        strim &= "</th>"
        strim &= "<th width=""200"">"
        strim &= "Login Time"
        strim &= "</th>"
        strim &= "</thead>"

        command("sp_get_all_login_report")
        rdr = cmd.ExecuteReader
        While rdr.Read
            i = i + 1
            strim &= "<tr>"
            strim &= "   <td>"
            strim &= i
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("username_")
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("name_")
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("time_value")
            strim &= "  </td>"
            strim &= "</tr>"
        End While
        strim &= "</table>"

        disp_all_login_report.innerhtml = strim
    End Sub
End Class

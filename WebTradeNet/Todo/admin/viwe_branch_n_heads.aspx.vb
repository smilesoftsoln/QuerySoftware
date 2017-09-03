Imports System.Data.SqlClient
Partial Class admin_viwe_branch_n_heads
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
        Dim i As Integer = 1

        strim &= "<br><br>"
        strim &= "<table class=""flexme1"" >"
        strim &= "<thead>"
        strim &= "<tr >"
        strim &= "<th width=""50"">"
        strim &= "No"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "Branch Name"
        strim &= "</th>"
        strim &= "<th width=""200"">"
        strim &= "Branch Head"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "Manage"
        strim &= "</th>"
        strim &= "</tr>"
        strim &= "</thead>"

        command("sp_get_all_bh")
        cmd.Parameters.AddWithValue("@branch", "%%")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "<tr >"
            strim &= "<td >"
            strim &= i
            strim &= "</td >"
            strim &= "<td>"
            strim &= rdr("branch_name")
            strim &= "</td >"
            strim &= "<td>"
            strim &= rdr("username_") & " (" & rdr("name_") & ")"
            strim &= "</td >"
            strim &= "<td>"
            strim &= "<a href=""edit_branch.aspx"">Manage</a>"
            strim &= "</td >"
            strim &= "</tr >"
            i = i + 1
        End While
        strim &= "</table >"
        disp_all_branchs.innerhtml = strim
    End Sub
End Class

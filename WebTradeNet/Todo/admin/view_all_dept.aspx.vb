Imports System.Data.SqlClient

Partial Class admin_view_all_dept
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
        strim &= "Department Name"
        strim &= "</th>"

        strim &= "<th width=""200"">"
        strim &= "Description"
        strim &= "</th>"
        strim &= "</tr>"
        strim &= "</thead>"

        command("sp_get_depts")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "<tr >"
            strim &= "<td >"
            strim &= i
            strim &= "</td >"
            strim &= "<td>"
            strim &= rdr("dept_name")
            strim &= "</td >"
            strim &= "<td>"
            strim &= rdr("dept_desc")
            strim &= "</td >"
            strim &= "</tr >"
            i = i + 1
        End While
        strim &= "</table >"
        disp_all_branchs.InnerHtml = strim
    End Sub
End Class

Imports System.Data.SqlClient
Partial Class admin_manage_hod
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

        strim &= "<table  class=""flexme1"" >"
        strim &= "<thead>"
        strim &= " <tr>"
        strim &= "<th width=""100"">"
        strim &= "<b>Department Name</b>"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "<b>HOD</b>"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "<b>Manage</b>"
        strim &= "</th >"
        strim &= " </tr>"
        strim &= "</thead>"
        command("sp_get_dept_n_hods")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= ""
            strim &= " <tr>"
            strim &= "<td>"
            strim &= rdr("dept_name")
            strim &= "</td>"
            strim &= "<td>"
            strim &= "<b>" & rdr("username_") & "</b>      (" & rdr("name_") & ")"
            strim &= "</td>"
            strim &= "<td>"
            strim &= "<a href=""transffer_dept.aspx"">Manage</a>"
            strim &= "</td>"
            strim &= " </tr>"
            
        End While
        strim &= "</table>"
        disp_depts_n_hods.InnerHtml = strim
        strim = ""

        '=================

        strim &= "<table width=""40%"" border=""1"" colsapn=""0"" cellpadding=""0"" cellspacing=""0"">"
        strim &= " <tr>"
        strim &= "<td>"
        strim &= "<b>Department Name</b>"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "<b>Manage</b>"
        strim &= "</td>"
        strim &= " </tr>"
        command("sp_get_hod_less_depts")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= ""
            strim &= " <tr>"
            strim &= "<td>"
            strim &= rdr("dept_name")
            strim &= "</td>"
            strim &= "<td>"
            strim &= "<a href=""Assign_Exist_HOD.aspx"">Manage</a>"
            strim &= "</td>"
            strim &= " </tr>"

        End While
        strim &= "</table>"
        disp_hol_less_depts.InnerHtml = strim
        strim = ""

        '=================

        strim &= "<table width=""40%"" border=""1"" colsapn=""0"" cellpadding=""0"" cellspacing=""0"">"
        strim &= " <tr>"
        strim &= "<td>"
        strim &= "<b>Department Name</b>"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "<b>Manage</b>"
        strim &= "</td>"
        strim &= " </tr>"
        command("sp_get_dept_less_hod")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= ""
            strim &= " <tr>"
            strim &= "<td>"
            strim &= rdr("username_") & "(" & rdr("name_") & ")"
            strim &= "</td>"
            strim &= "<td>"
            strim &= "Manage"
            strim &= "</td>"
            strim &= " </tr>"

        End While
        strim &= "</table>"
        disp_dept_less_hods.InnerHtml = strim

    End Sub
End Class

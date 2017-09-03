Imports System.Data.SqlClient
Partial Class admin_Online_users
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

        strim &= "<br><br>"
        strim &= "<table class=""flexme1"" >"
        strim &= "<thead>"
        strim &= "<tr >"
        strim &= "<th width=""100"">"
        strim &= "UserName"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "Online Ststus"
        strim &= "</th>"
        strim &= "</thead>"
        command("sp_view_all_Online_users")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "<tr >"
            strim &= "<td >"
            strim &= rdr("username_")
            strim &= "</td >"
            strim &= "<td>"
            If rdr("login_stts") = "ONLINE" Then
                strim &= "<img src=""images/ico_online.gif"">"
            ElseIf rdr("login_stts") = "OFFLINE" Then
                strim &= "<img src=""images/ico_offline.png"">"
            End If

            strim &= "</td >"
            strim &= "</tr >"
        End While
        strim &= "</table >"
        disp_online_stts.innerhtml = strim
    End Sub
End Class

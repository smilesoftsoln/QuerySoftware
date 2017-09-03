Imports System.Data.SqlClient
Partial Class mng_online_users
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
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim mng_id As Integer
        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            mng_id = rdr("id")  'Because this is management, we take id directly - not through department's manage_id!! -Sanjay
        End If


        Dim tot_arr As Integer = 0
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
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "Dept"
        strim &= "</th>"
        strim &= "</thead>"

        While i < tot_arr
            command("sp_view_all_Online_users_de")
            rdr = cmd.ExecuteReader
            While rdr.Read
                If dept_id_(i) = rdr("forign_id") Then
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
                    strim &= "</th>"
                    strim &= "<td >"
                    strim &= rdr("dept_name")
                    strim &= "</td>"
                    strim &= "</tr >"
                End If
            End While
            i = i + 1
        End While

        strim &= "</table >"
        disp_online_stts.InnerHtml = strim
    End Sub
End Class

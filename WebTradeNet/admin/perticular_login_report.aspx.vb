Imports System.Data.SqlClient
Partial Class admin_perticular_login_report
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
        If Not Page.IsPostBack Then
            cbo_users.Items.Add("ALL")
            command("sp_chk_username_availabality")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_users.Items.Add(rdr("username_"))
            End While
        End If
    End Sub

    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_go.Click

    End Sub
End Class

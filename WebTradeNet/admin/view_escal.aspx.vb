Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.Net.Mail
Partial Class view_escal
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim comm_dns As New somman_functions_NM.commen_funcs
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        Command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()
        Response.Redirect("../SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub
End Class

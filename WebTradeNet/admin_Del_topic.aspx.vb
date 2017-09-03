Imports System.Data.SqlClient
Partial Class admin_Del_topic
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim t_id As Integer = Request.QueryString("t_id")
        command("sp_del_ticket_by_id")
        cmd.Parameters.AddWithValue("@tid", t_id)
        cmd.ExecuteNonQuery()
        Response.Redirect("Admin_view_all_ticks.aspx")
    End Sub
End Class

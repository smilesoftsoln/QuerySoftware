Imports System.Data.SqlClient
Partial Class admin_Default
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

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_submit.Click
        command("sp_get_main_admin")
        cmd.Parameters.AddWithValue("@uname", txt_uName.Text)
        cmd.Parameters.AddWithValue("@pwd", txt_pwd.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Session.RemoveAll()
            Session.Add("loginerID", rdr("id"))
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "ADMIN")
            Response.Cookies("mainadmin")("login") = "true"

            command("sp_read_last_login_by_loginer_id")
            cmd.Parameters.AddWithValue("@loginerID", Session.Item("loginerID"))
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                Session.Item("last_login") = rdr("time_value")
                command("sp_write_last_login_by_loginer_id")
                cmd.Parameters.AddWithValue("@loginerID", Session.Item("loginerID"))
                cmd.Parameters.AddWithValue("@time_value", Now())
                cmd.ExecuteNonQuery()
            End If
            Response.Redirect("../main_admin_login_Next.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("../Default.aspx")
    End Sub
End Class

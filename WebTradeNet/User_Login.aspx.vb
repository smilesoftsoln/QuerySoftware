Imports System.Data.SqlClient
Partial Class User_Login
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
        'command("sp_user_login")
        ' cmd.Parameters.AddWithValue("@uname", txt_uName.Text)
        ' cmd.Parameters.AddWithValue("@pass", txt_pwd.Text)
        ' rdr = cmd.ExecuteReader
        ' If rdr.Read Then
        'Session.Add("loginerID", rdr("id"))
        'Session.Add("loginerTYP", "USER")
        'Response.Cookies("user")("login") = "true"
        'If (rdr("who_is") = "BE") Or (rdr("who_is") = "BH") Then
        '
        '        command("sp_read_last_login_by_loginer_id")
        '        cmd.Parameters.AddWithValue("@loginerID", Session.Item("loginerID"))
        '        rdr = cmd.ExecuteReader
        '        If rdr.Read Then
        ' Session.Item("last_login") = rdr("time_value")
        ' command("sp_write_last_login_by_loginer_id")
        ' cmd.Parameters.AddWithValue("@loginerID", Session.Item("loginerID"))
        '  cmd.Parameters.AddWithValue("@time_value", Now())
        '  cmd.ExecuteNonQuery()
        '   End If
        '   Response.Redirect("User_login_next.aspx")
        '  Else
        '   Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Login Failed ! \nPlease Check Input UserName Or Password! \nOr Contact To Developer ')</script>")
        '   End If
        '   Else
        '   Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Login Failed ! \nPlease Check Input UserName Or Password! \nOr Contact To Developer ')</script>")
        '   End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("Default.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
    End Sub
End Class

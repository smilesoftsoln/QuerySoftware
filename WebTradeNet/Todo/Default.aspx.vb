Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim commasn_fns As New somman_functions_NM.commen_funcs
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_submit.Click
        Dim user As String
        Dim tmp_timeval As String
        Dim lastlogin As String = "NA"
        Dim whi_is As String
        command("sp_get_loginer")
        cmd.Parameters.AddWithValue("@username_", txt_uName.Text)
        cmd.Parameters.AddWithValue("@password_", txt_pwd.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            whi_is = rdr("post_")
            Session.RemoveAll()
            Session.Add("loginerID", rdr("id"))
            command("sp_read_last_login_by_id")
            cmd.Parameters.AddWithValue("@id", Session.Item("loginerID"))
            rdr = cmd.ExecuteReader
            While rdr.Read
                lastlogin = rdr("time_value")
            End While
            Session.Item("last_login") = lastlogin
            command("sp_write_last_login_by_id")
            cmd.Parameters.AddWithValue("@id", Session.Item("loginerID"))
            cmd.Parameters.AddWithValue("@time_value", Now())
            cmd.ExecuteNonQuery()
        Else
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Login Failed ! \nPlease Check Input UserName Or Password! \nOr Contact To Developer ')</script>")
        End If

        If whi_is = "ADMIN" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "ADMIN")
            Response.Cookies("mainadmin")("login") = "true"
            Response.Redirect("admin/Login_Next.aspx")
        ElseIf whi_is = "DE" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "DE")
            Response.Cookies("admin")("login") = "true"
            Response.Redirect("employee_login_next.aspx")
        ElseIf whi_is = "BE" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "BE")
            Response.Cookies("admin")("login") = "true"
            Response.Redirect("User_login_next.aspx")
        ElseIf whi_is = "BH" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "BH")
            Response.Cookies("admin")("login") = "true"
            Response.Redirect("User_login_next.aspx")
        ElseIf whi_is = "HOD" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "HOD")
            Response.Cookies("admin")("login") = "true"
            Response.Redirect("hod_login_Next.aspx")
        ElseIf whi_is = "MNG" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "MNG")
            Response.Cookies("admin")("login") = "true"
            Response.Redirect("mng_login_next.aspx")
        ElseIf whi_is = "ADMIN" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "ADMIN")
            Response.Cookies("admin")("login") = "true"
            Response.Redirect("admin/Login_Next.aspx")
        End If

    End Sub

    Protected Sub btn_clear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_clear.Click

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.RemoveAll()
    End Sub
End Class

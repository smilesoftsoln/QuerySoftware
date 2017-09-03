Imports System.Data.SqlClient
Partial Class admin_add_new_user
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
    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        If txt_conf_pwd.Text = txt_pwd.Text Then
            command("sp_insert_tbl_loginer_master")
            cmd.Parameters.AddWithValue("@username_", txt_username.Text)
            cmd.Parameters.AddWithValue("@password_", txt_pwd.Text)
            cmd.Parameters.AddWithValue("@name_", txt_name.Text)
            cmd.Parameters.AddWithValue("@post_", cbo_user_typ.SelectedValue)
            cmd.Parameters.AddWithValue("@phone_number", txt_phone.Text)
            cmd.Parameters.AddWithValue("@email_id", txt_email.Text)
            If cmd.ExecuteNonQuery Then
                command("sp_get_loginer_by_username")
                cmd.Parameters.AddWithValue("@username_", txt_username.Text)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    Response.Redirect("add_new_user_stape_2.aspx?loginerID=" & rdr("id") & "&post_=" & rdr("post_") & "&")
                End If
            End If
        End If
    End Sub

    Protected Sub txt_username_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_username.TextChanged
        Dim YN As String = "N"
        command("sp_chk_username_availabality")
        cmd.Parameters.AddWithValue("@username_", txt_username.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Username is already Taken !')</script>")
            txt_username.Text = ""
            txt_username.Focus()
        Else
            txt_pwd.Focus()
        End If
    End Sub
End Class

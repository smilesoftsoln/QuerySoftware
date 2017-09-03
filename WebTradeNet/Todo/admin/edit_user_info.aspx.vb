Imports System.Data.SqlClient
Partial Class admin_edit_user_info
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
            Dim lid As Integer = Request.QueryString("lid")
            command("sp_get_loginer_details")
            cmd.Parameters.AddWithValue("@id", lid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_name.Text = rdr("name_")
                txt_username.Text = rdr("username_")
                txt_email.Text = rdr("email_id")
                txt_name.Text = rdr("name_")
                txt_phone.Text = rdr("phone_number")
                txt_pass.Text = rdr("password_")
                lbl_username.Text = rdr("username_")
            End If
        End If
    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        command("sp_update_user_info")
        cmd.Parameters.AddWithValue("@id", Request.QueryString("lid"))
        cmd.Parameters.AddWithValue("@name_", txt_name.Text)
        cmd.Parameters.AddWithValue("@phone_number", txt_phone.Text)
        cmd.Parameters.AddWithValue("@email_id", txt_email.Text)
        cmd.Parameters.AddWithValue("@password_", txt_pass.Text)
        cmd.Parameters.AddWithValue("@username_", txt_username.Text)
        If cmd.ExecuteNonQuery Then
            Response.Redirect("msg.aspx?msg=User Updates Successfully !")
        End If

    End Sub

    Protected Sub btn_show_password_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_show_password.Click
       

        If btn_show_password.Text = "Hide Password" Then
            txt_pass.Visible = False
            lbl_password.Visible = True
            btn_show_password.Text = "Show Password"
        Else
            txt_pass.Visible = True
            lbl_password.Visible = False
            btn_show_password.Text = "Hide Password"
        End If
    End Sub

    Protected Sub txt_username_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_username.TextChanged
        command("sp_chk_username_2")
        cmd.Parameters.AddWithValue("@ori_username", lbl_username.Text)
        cmd.Parameters.AddWithValue("@new_username", txt_username.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Username Name Already Exist!')</script>")
            txt_username.Text = lbl_username.Text
        Else
            txt_name.Focus()
        End If
    End Sub
End Class

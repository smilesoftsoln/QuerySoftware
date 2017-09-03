Imports System.Data.SqlClient
Partial Class admin_add_new_mng
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
    
    Protected Sub txt_mng_name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mng_name.TextChanged
        command("sp_get_managements_by_mng_name")
        cmd.Parameters.AddWithValue("@mng_name", txt_mng_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Branch Name Already Available!')</script>")
            txt_mng_name.Text = ""
            txt_mng_name.Focus()
        Else
            txt_mng_name.Text = txt_mng_name.Text.ToUpper
            txt_mng_desc.Focus()
        End If

    End Sub

    Protected Sub btn_mng_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mng_submit.Click
        command("sp_insert_management")
        cmd.Parameters.AddWithValue("@mng_name", txt_mng_name.Text)
        cmd.Parameters.AddWithValue("@mng_desc", txt_mng_desc.Text)
        If cmd.ExecuteNonQuery Then
            Response.Redirect("msg.aspx?msg=New Management Created Successfully !<br/>Now Add Manager Throw &quot;<a href=""add_new_user.aspx"">Add New User</a>&quot;<br>Or<br>&quot;Defign Existing MNG User&quot;")
        End If

    End Sub
End Class

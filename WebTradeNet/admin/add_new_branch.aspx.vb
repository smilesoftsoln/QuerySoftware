Imports System.Data.SqlClient
Partial Class admin_add_new_branch
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
    Protected Sub txt_branch_name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_branch_name.TextChanged
        command("sp_chk_branch_name_available_or_not")
        cmd.Parameters.AddWithValue("@branch_name", txt_branch_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Branch Name Already Available!')</script>")
            txt_branch_name.Text = ""
            txt_branch_name.Focus()
        Else
            txt_branch_name.Text = txt_branch_name.Text.ToUpper()
            txt_branch_desc.Focus()
        End If
    End Sub

    Protected Sub btn_dept_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_dept_submit.Click
        command("sp_insert_branch")
        cmd.Parameters.AddWithValue("@branch_name", txt_branch_name.Text)
        cmd.Parameters.AddWithValue("@branch_desc", txt_branch_desc.Text)
        If cmd.ExecuteNonQuery Then
            Response.Redirect("msg.aspx?msg=New Branch Created Successfully !")
        End If
    End Sub
End Class

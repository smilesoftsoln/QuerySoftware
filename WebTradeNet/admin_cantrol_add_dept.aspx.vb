Imports System.Data.SqlClient
Partial Class admin_cantrol_add_dept
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

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_submit.Click
        Dim samp As Integer = 0
        If txt_d_name.Text = "" Then
            samp = samp + 1
        ElseIf txt_desc.Text = "" Then
            samp = samp + 1
        End If

        If samp > 0 Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Invalied Data..!')</script>")
        Else
            command("sp_insert_department")
            cmd.Parameters.AddWithValue("@dept_name", txt_d_name.Text)
            cmd.Parameters.AddWithValue("@dept_desc", txt_desc.Text)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("admin_cantrol_add_HOD.aspx?OnDept=")
            End If
        End If
    End Sub

    Protected Sub txt_d_name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_d_name.TextChanged
        command("sp_chk_dept_exist_or_not")
        cmd.Parameters.AddWithValue("@this_dept_name", txt_d_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Department Name -" & txt_d_name.Text & "- is Already in use \nPlease choose Diffrent Department Name')</script>")
            txt_d_name.Text = ""
            txt_desc.Text = ""
            txt_d_name.Focus()
        Else
            txt_d_name.Text = txt_d_name.Text.ToUpper()
        End If
    End Sub
End Class

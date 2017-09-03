Imports System.Data.SqlClient
Partial Class admin_edit_dept
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
            command("sp_get_depts")
            cbo_depts.Items.Add("")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_depts.Items.Add(rdr("dept_name"))
            End While
        End If

    End Sub

    Protected Sub cbo_depts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_depts.SelectedIndexChanged
        command("sp_get_dept_by_name")
        cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_depts_name.Text = rdr("dept_name")
            txt_dept_desc.Text = rdr("dept_desc")
        End If
    End Sub

    Protected Sub btn_update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_update.Click
        command("sp_updte_dept")
        cmd.Parameters.AddWithValue("@ori_dept_name", cbo_depts.SelectedValue)
        cmd.Parameters.AddWithValue("@new_dept_name", txt_depts_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Department Name Already Exist!')</script>")
            txt_depts_name.Text = ""
            txt_depts_name.Focus()
        Else
            command("sp_update_dept_2")
            cmd.Parameters.AddWithValue("@ori_dept_name", cbo_depts.SelectedValue)
            cmd.Parameters.AddWithValue("@new_dept_name", txt_depts_name.Text)
            cmd.Parameters.AddWithValue("@dept_desc", txt_dept_desc.Text)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("msg.aspx?msg=Department Updated Successfully !")
            End If
        End If
    End Sub
End Class

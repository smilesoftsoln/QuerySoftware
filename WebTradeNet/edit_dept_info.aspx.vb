Imports System.Data.SqlClient
Partial Class edit_dept_info
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
            cbo_dept.Items.Add("")
            command("sp_get_departments")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_dept.Items.Add(rdr("dept_name"))
            End While
        End If
    End Sub

    Protected Sub cbo_dept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_dept.SelectedIndexChanged
        Dim forign_id As Integer
        pnl_edit_info.Visible = True
        cbo_dept.Visible = False
        lbl_user.Visible = True
        lbl_user.Text = cbo_dept.SelectedValue

        command("sp_get_dept_id_by_dept_name")
        cmd.Parameters.AddWithValue("@dept_name", lbl_user.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_f_name.Text = rdr("dept_name")
            txt_username.Text = rdr("dept_desc")
        End If
    End Sub

    Protected Sub txt_f_name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_f_name.TextChanged
        command("sp_dept_name_change_exist_or_not")
        cmd.Parameters.AddWithValue("@origin_dept_name", lbl_user.Text)
        cmd.Parameters.AddWithValue("@changed_d_name", txt_f_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Branch Name -" & txt_f_name.Text & "- is Already in use \nPlease choose Diffrent Branch Name')</script>")
            txt_f_name.Text = lbl_user.Text
            txt_f_name.Focus()
        Else
        End If
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_ok.Click
        Dim dept_id As Integer
        '===getting forign kek====
        command("sp_get_dept_id_by_dept_name")
        cmd.Parameters.AddWithValue("@dept_name", lbl_user.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            dept_id = rdr("id")
        End If
        '=============

        command("sp_update_dept_info_by_id")
        cmd.Parameters.AddWithValue("@id", dept_id)
        cmd.Parameters.AddWithValue("@new_name", txt_f_name.Text)
        cmd.Parameters.AddWithValue("@new_dec", txt_username.Text)
        If cmd.ExecuteNonQuery Then
            Response.Redirect("edit_dept_info.aspx")
        End If
    End Sub

    Protected Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cancel.Click
        Response.Redirect("edit_dept_info.aspx")
    End Sub
End Class

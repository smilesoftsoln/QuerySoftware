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
        Dim ctr As Integer
        Dim manage_id As Integer

        cbo_mgmt.Items.Clear()
        command("sp_get_dept_by_name")
        cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_depts_name.Text = rdr("dept_name")
            txt_dept_desc.Text = rdr("dept_desc")
            manage_id = rdr("manage_id")

            command("sp_get_managements")
            rdr = cmd.ExecuteReader
            ctr = 0
            While rdr.Read
                cbo_mgmt.Items.Add(rdr("mng_name"))
                cbo_mgmt.Items.Item(ctr).Text = rdr("mng_name")
                cbo_mgmt.Items.Item(ctr).Value = rdr("id")
                If (manage_id = rdr("id")) Then cbo_mgmt.Items.Item(ctr).Selected = True
                ctr = ctr + 1
            End While


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
            cmd.Parameters.AddWithValue("@manage_id", cbo_mgmt.SelectedValue)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("msg.aspx?msg=Department Updated Successfully !")
            End If
        End If
    End Sub
End Class

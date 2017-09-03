Imports System.Data.SqlClient
Partial Class edit_branch_info
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
            cbo_branch.Items.Add("")
            command("sp_get_branches")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_branch.Items.Add(rdr("branchName"))
            End While
        End If
    End Sub

    Protected Sub cbo_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_branch.SelectedIndexChanged
        Dim forign_id As Integer
        pnl_edit_info.Visible = True
        cbo_branch.Visible = False
        lbl_user.Visible = True
        lbl_user.Text = cbo_branch.SelectedValue

        command("sp_get_branch_by_branch_name")
        cmd.Parameters.AddWithValue("@branch_name", lbl_user.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_f_name.Text = rdr("branchName")
            txt_username.Text = rdr("branch_desc")
        End If
    End Sub

 

    Protected Sub txt_f_name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_f_name.TextChanged
        command("sp_brnach_name_change_exist_or_not")
        cmd.Parameters.AddWithValue("@origin_branch_name", lbl_user.Text)
        cmd.Parameters.AddWithValue("@changed_b_name", txt_f_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Branch Name -" & txt_f_name.Text & "- is Already in use \nPlease choose Diffrent Branch Name')</script>")
            txt_f_name.Text = lbl_user.Text
            txt_f_name.Focus()
        Else

        End If
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_ok.Click
        Dim branch_id As Integer
        Dim new_brnach_name As String = txt_f_name.Text
        Dim old_branch_name As String = ""
        '===getting forign kek====
        command("sp_get_branch_by_name")
        cmd.Parameters.AddWithValue("@branchName", lbl_user.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            branch_id = rdr("id")
            old_branch_name = rdr("branchName")
        End If
        '=============
        
        command("sp_update_branch_info_by_id")
        cmd.Parameters.AddWithValue("@id", branch_id)
        cmd.Parameters.AddWithValue("@new_name", txt_f_name.Text)
        cmd.Parameters.AddWithValue("@new_dec", txt_username.Text)
        If cmd.ExecuteNonQuery Then
            command("sp_edit_user_master_branch_name")
            cmd.Parameters.AddWithValue("@old_benach_name", old_branch_name)
            cmd.Parameters.AddWithValue("@new_branch_name", new_brnach_name)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("edit_branch_info.aspx")
            End If

        End If
    End Sub
End Class

Imports System.Data.SqlClient
Partial Class admin_edit_branch
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
            command("sp_get_branches")
            rdr = cmd.ExecuteReader
            cbo_branchs.Items.Add("")
            While rdr.Read
                cbo_branchs.Items.Add(rdr("branch_name"))
            End While
        End If
       
    End Sub

    Protected Sub cbo_branchs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_branchs.SelectedIndexChanged
        command("sp_get_branch_by_name")
        cmd.Parameters.AddWithValue("@branch_name", cbo_branchs.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_branch_name.Text = rdr("branch_name")
            txt_branch_desc.Text = rdr("branch_address")
        End If
    End Sub

    Protected Sub btn_update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_update.Click
        command("sp_get_update_bracnh_name")
        cmd.Parameters.AddWithValue("@ori_branch_name", cbo_branchs.SelectedValue)
        cmd.Parameters.AddWithValue("@entered_branch_name", txt_branch_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Branch Name Already Exist!')</script>")
            txt_branch_name.Text = ""
            txt_branch_name.Focus()
        Else
            command("sp_update_branch")
            cmd.Parameters.AddWithValue("@ori_branch_name", cbo_branchs.SelectedValue)
            cmd.Parameters.AddWithValue("@new_branch_name", txt_branch_name.Text)
            cmd.Parameters.AddWithValue("@new_details", txt_branch_desc.Text)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("msg.aspx?msg=Branch Updated Successfully !")
            End If
        End If
    End Sub

  
End Class

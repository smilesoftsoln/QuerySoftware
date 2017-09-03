Imports System.Data.SqlClient
Partial Class admin_edit_mng
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
            command("sp_get_management")
            rdr = cmd.ExecuteReader
            cbo_mngs.Items.Add("")
            While rdr.Read
                cbo_mngs.Items.Add(rdr("mng_name"))
            End While
        End If


    End Sub

    Protected Sub cbo_mngs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_mngs.SelectedIndexChanged
        command("sp_get_management_by_name")
        cmd.Parameters.AddWithValue("@mng_name", cbo_mngs.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_mng_name.Text = rdr("mng_name")
            txt_mng_desc.Text = rdr("mng_desc")
        End If
    End Sub

    Protected Sub btn_update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_update.Click
        command("sp_update_mng_1")
        cmd.Parameters.AddWithValue("@ori_mng_name", cbo_mngs.SelectedValue)
        cmd.Parameters.AddWithValue("@new_mng_name", txt_mng_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Management Name Already Exist!')</script>")
            txt_mng_name.Text = ""
            txt_mng_name.Focus()
        Else
            command("sp_update_mng_info")
            cmd.Parameters.AddWithValue("@ori_mng_name", cbo_mngs.SelectedValue)
            cmd.Parameters.AddWithValue("@new_mng_name", txt_mng_name.Text)
            cmd.Parameters.AddWithValue("@mng_desc", txt_mng_desc.Text)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("msg.aspx?msg=Management Updated Successfully !")
            End If
        End If
    End Sub
End Class

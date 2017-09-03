Imports System.Data.SqlClient
Partial Class admin_edit_fev
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
            cbo_fevos.Items.Add("select")
            command("sp_get_tbl_Favorites_master")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_fevos.Items.Add(rdr("title"))
            End While
        End If
    End Sub

    Protected Sub cbo_fevos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_fevos.SelectedIndexChanged
        pnl_details.Visible = True
        txt_title.Text = cbo_fevos.SelectedValue

        command("sp_get_tbl_Favorites_master")
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_url.Text = rdr("url")
        End If
    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_submit.Click
        command("sp_update_Favorites")
        cmd.Parameters.AddWithValue("@title", cbo_fevos.SelectedValue)
        cmd.Parameters.AddWithValue("@new_title", txt_title.Text)
        cmd.Parameters.AddWithValue("@new_url", txt_url.Text)
        If cmd.ExecuteNonQuery Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Done !')</script>")
        Else
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Error !')</script>")
        End If



    End Sub

    Protected Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_delete.Click
        command("sp_delete_Favorites")
        cmd.Parameters.AddWithValue("@title", txt_title.Text)
        If cmd.ExecuteNonQuery Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Done !')</script>")
        Else
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Error !')</script>")
        End If

    End Sub
End Class

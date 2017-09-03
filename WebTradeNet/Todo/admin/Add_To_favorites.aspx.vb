Imports System.Data.SqlClient
Partial Class Add_To_favorites
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
            txt_title.Text = Request.QueryString("title")
            txt_url.Text = Request.QueryString("url")
        End If


    End Sub

    Protected Sub btn_add_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_add.Click
        command("sp_insert_tbl_Favorites_master")
        cmd.Parameters.AddWithValue("@title", txt_title.Text)
        cmd.Parameters.AddWithValue("@url", txt_url.Text)
        If cmd.ExecuteNonQuery() Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">window.close()</script>")
        End If


        
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">window.close()</script>")
    End Sub
End Class

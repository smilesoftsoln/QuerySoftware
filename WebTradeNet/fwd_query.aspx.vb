Imports System.Data.SqlClient
Partial Class fwd_query
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim top_id As Integer = Request.QueryString("tid")
        Dim loginerTYP As String = Session.Item("loginerTYP")
        command("sp_get_ticket_by_t_id")
        cmd.Parameters.AddWithValue("@t_id", top_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_topic.Text = rdr("t_sub")
        End If

        If loginerTYP = "MNG" Then
            cbo_levels.Items(2).Enabled = False
        End If
        Dim count_ As Integer = 0
       
    End Sub

    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        Dim top_id As Integer = Request.QueryString("tid")
        loginerID = Session.Item("loginerID")
        Dim deptType As String = Session.Item("loginerTYP")

        Dim selected_level As String = cbo_levels.SelectedValue

        Dim this_short_key As String
        If txt_why.Text = "" Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Please Mention the Reason about why you forwarding this ticket !')</script>")
        Else
            command("sp_get_short_key_by_level_name")
            cmd.Parameters.AddWithValue("@leelName", selected_level)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                this_short_key = rdr("short_key")
            End If
            If Not this_short_key = "" Then
                command("sp_change_leve")
                cmd.Parameters.AddWithValue("@tid ", top_id)
                cmd.Parameters.AddWithValue("@short_key", this_short_key)
                If cmd.ExecuteNonQuery Then
                    command("sp_insert_comment_")
                    cmd.Parameters.AddWithValue("@t_id", top_id)
                    cmd.Parameters.AddWithValue("@comm_", "<u><i>Forward Note</i> :</u> " & txt_why.Text)
                    cmd.Parameters.AddWithValue("@crtr_id", loginerID)
                    cmd.Parameters.AddWithValue("@attch_url", "NO")
                    If cmd.ExecuteNonQuery Then
                        Response.Write("Forwarded Successfully !!")
                        txt_why.Visible = False
                        Panel1.Visible = False
                        Panel2.Visible = True
                    End If
                End If
            End If
        End If
    End Sub
End Class

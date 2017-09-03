Imports System.Data.SqlClient
Partial Class admin_backup_restore_DB
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

    End Sub
   
    Protected Sub rdb_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_1.SelectedIndexChanged
        If rdb_1.SelectedValue = "Restore Database" Then
            pnl_backup.Visible = False
            pnl_restore.Visible = True
        ElseIf rdb_1.SelectedValue = "BackUp Database" Then
            pnl_backup.Visible = True
            pnl_restore.Visible = False
            PleaseWaitButton1.Text = Now & " << Take Backup  >>"
        End If

        Dim lbd As String = ""
        command("sp_get_max_backuped_date")
        rdr = cmd.ExecuteReader
        While rdr.Read
            lbd = rdr("bk_date")
        End While
        lbl_last_bk_date.Text = lbd
        PleaseWaitButton2.Text = "Restore Database Dated " & lbd
    End Sub

    'Protected Sub btn_backup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_backup.Click
    '    command("sp_backup_feel")
    '    cmd.Parameters.AddWithValue("@this_date", Now)
    '    If cmd.ExecuteNonQuery Then
    '        MsgBox("Done")
    '    End If
    'End Sub

    Protected Sub PleaseWaitButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PleaseWaitButton1.Click



        Dim dt As DateTime = Now.AddSeconds(4)
        While Now < dt

        End While

        command("sp_backup_feel")
        cmd.Parameters.AddWithValue("@this_date", Now)
        If cmd.ExecuteNonQuery Then
            command("sp_take_backup")
            If cmd.ExecuteNonQuery() Then
                Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Backup Database till " & Now() & " ')</script>")
            End If
        End If

    End Sub

    Protected Sub PleaseWaitButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PleaseWaitButton2.Click
        Try

      
            If Not cho_ok.Checked Then
                pnl_sure.BackColor = Drawing.Color.Red
            Else
                Dim dt As DateTime = Now.AddSeconds(8)
                While Now < dt

                End While

                pnl_sure.BackColor = Drawing.Color.White
                command("sp_restore_database")
                If cmd.ExecuteNonQuery Then
                    Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Backup Restored Successfully !!')</script>")
                End If
            End If
        Catch ex As Exception
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('ERROR !!\n" & ex.Message() & "')</script>")
        End Try
    End Sub
End Class


Partial Class admin_Backup_Restore
    Inherits System.Web.UI.Page

    'Protected Sub rdb_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_1.SelectedIndexChanged
    '    If rdb_1.SelectedValue = "Restore Database" Then
    '        pnl_backup.Visible = False
    '        pnl_restore.Visible = True
    '    ElseIf rdb_1.SelectedValue = "BackUp Database" Then
    '        pnl_backup.Visible = True
    '        pnl_restore.Visible = False
    '        PleaseWaitButton1.Text = Now & " << Take Backup  >>"
    '    End If
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub rdb_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb_1.SelectedIndexChanged
        If rdb_1.SelectedValue = "Restore Database" Then
            pnl_backup.Visible = False
            pnl_restore.Visible = True
        ElseIf rdb_1.SelectedValue = "BackUp Database" Then
            pnl_backup.Visible = True
            pnl_restore.Visible = False
            'PleaseWaitButton1.Text = Now & " << Take Backup  >>"
        End If

    End Sub
End Class

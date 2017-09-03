
Partial Class Todo_reports_mng
    Inherits System.Web.UI.Page

   
    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        PlaceHolder2.Controls.Add(GridView2)
        'GridView2.Visible = True

    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged
        PlaceHolder2.Controls.Add(GridView3)

    End Sub
End Class

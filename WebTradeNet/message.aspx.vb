
Partial Class message
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim this_msg As String = Request.QueryString("this_msg")
        disp_this_msg.innerhtml = this_msg
    End Sub
End Class


Partial Class admin_cantrol_success_msg
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim msg As String = Request.QueryString("msg")
        disp_msg.innerhtml = msg
    End Sub
End Class

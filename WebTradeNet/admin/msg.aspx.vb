
Partial Class admin_msg
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim msg As String = Request.QueryString("msg")
        Disp_msg.innerhtml = "<h4>" & msg & "</h4>"
        Page.Title = msg
    End Sub
End Class

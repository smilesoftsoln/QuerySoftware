Imports System.Data.SqlClient
Partial Class Admin_search_updates
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Sub command2(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = "select update_ from admin_updates_master where update_ like '%" & strcmd & "%'"
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Request.Cookies("admin")("login") = "false" Then
                Response.Redirect("User_login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("User_login.aspx")
        End Try
    End Sub
    Protected Sub btn_post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_post.Click
        lbl_titl.Text = txt_search.Text
        Dim strim As String = ""
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:9%"">"
        strim &= "Updates"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        Dim strm2 As String = ""
        command2(txt_search.Text)
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td >"
            strim &= rdr("update_")
            strim &= "	            </td>"
            strim &= "	        </tr>"
        End While
        strim &= "	    </table>"
        disp_search_updates.InnerHtml = strim
        pnl_search_resut.Visible = True
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Cookies("admin")("login") = "false"
        ' Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub
End Class

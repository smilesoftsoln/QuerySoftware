Imports System.Data.SqlClient
Partial Class user_search_updates
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
    Sub command2(ByVal strcmd As String, ByVal uid As Integer)
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = "select update_ from user_updates_master where userID=" & uid & " and  update_ like '%" & strcmd & "%'"
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Request.Cookies("user")("login") = "false" Then
                Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
            End If

        Catch ex As Exception
            Response.Redirect("User_login.aspx&AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
        End Try
        loginerID = Session.Item("loginerID")


    End Sub

    Protected Sub btn_post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_post.Click
        loginerID = Session.Item("loginerID")
        lbl_titl.Text = txt_search.Text
        Dim strim As String = ""
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:9%"">"
        strim &= "Updates"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        Dim strm2 As String = ""
        command2(txt_search.Text, loginerID)
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
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub
End Class

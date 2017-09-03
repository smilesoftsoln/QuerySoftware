Imports System.Data.SqlClient
Partial Class Admin_view_all_updates
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Request.Cookies("admin")("login") = "false" Then
                Response.Redirect("User_login.aspx")
            End If

        Catch ex As Exception
            Response.Redirect("User_login.aspx")
        End Try
        Dim strim As String = ""
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:9%"">"
        strim &= "Update History Till - " & Today()
        strim &= "	            </td>"
        strim &= "	        </tr>"

        command("sp_get_all_admin_updates")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td >"
            strim &= rdr("update_")
            strim &= "	            </td>"

            strim &= "	        </tr>"
        End While
        strim &= "	    </table>"
        disp_all_updates.innerhtml = strim
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Cookies("admin")("login") = "false"
        ' Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub
End Class

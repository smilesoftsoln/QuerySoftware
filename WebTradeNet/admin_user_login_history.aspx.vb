Imports System.Data.SqlClient
Partial Class admin_user_login_history
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
        Dim strim As String = ""

        strim &= "  <table class=""tbl_gw"">"
        strim &= "     <tr class=""tbl_gw_spl"">"
        strim &= "        <td style=""width:10%"">"
        strim &= " LoginerID"
        strim &= "         </td>"
        strim &= "        <td style=""width:40%"">"
        strim &= " UserName"
        strim &= "         </td>"
        strim &= "         <td style=""width:40%"">"
        strim &= " Name"
        strim &= "         </td>"
        strim &= "    </tr>"
        command("sp_get_addressbook")
        rdr = cmd.ExecuteReader
        While rdr.Read
            If rdr("who_is") = "BE" Then

            End If
            strim &= "     <tr >"
            strim &= "        <td style=""width:10%"">"
            strim &= rdr("id")
            strim &= "         </td>"
            strim &= "        <td style=""width:40%"">"
            strim &= "<a href=""admin_view_this_login_history_.aspx?loginer=" & rdr("id") & " "" >" & rdr("username_") & "</a>"
            strim &= "         </td>"
            strim &= "         <td style=""width:40%"">"
            strim &= rdr("display_name")
            strim &= "         </td>"
        End While
        strim &= "</table>"
        Disp_users.innerhtml = strim
    End Sub
End Class

Imports System.Data.SqlClient
Partial Class admin_search_user
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
    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_go.Click
        If txt_search.Text = "" Then
        Else
            command("sp_search_user")
            cmd.Parameters.AddWithValue("@kw", "%" & txt_search.Text & "%")
            rdr = cmd.ExecuteReader
            Dim strim As String = ""

            strim &= "<table cellpadding=""0"" cellspacing=""0"" class=""table_1"">"
            strim &= "<tr class=""spl_td"">"
            strim &= "<td style=""width:15%"">"
            strim &= "UserName"
            strim &= "</td>"
            strim &= "<td style=""width:25%"">"
            strim &= "Name"
            strim &= "</td>"
            strim &= "<td style=""width:10%"">"
            strim &= "Post"
            strim &= "</td>"
            strim &= "<td style=""width:15%"">"
            strim &= "phone number"
            strim &= "</td>"
            strim &= "<td style=""width:15%"">"
            strim &= "Email-ID"
            strim &= "</td>"
            strim &= "<td style=""width:10%"">"
            strim &= "Manage"
            strim &= "</td>"
            strim &= "</tr>"

            While rdr.Read
                strim &= "<tr>"
                strim &= "   <td>"
                strim &= rdr("username_")
                strim &= "  </td>"
                strim &= "  <td>"
                strim &= rdr("name_")
                strim &= " </td>"
                strim &= "  <td>"
                strim &= rdr("post_")
                strim &= "  </td>"
                strim &= " <td>"
                strim &= rdr("phone_number")
                strim &= "</td>"
                strim &= "  <td>"
                strim &= rdr("email_id")
                strim &= "  </td>"
                strim &= "  <td>"
                strim &= "<a href=""edit_user_info.aspx?lid=" & rdr("id") & "&Sed adipiscing dictum sem non elementum. Nullam eget eros eu ligula imperdiet dictum quis ac purus. Donec condimentum erat vitae libero blandit suscipit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut euismod lacinia neque ac mollis.html ""> Manage </a>"
                strim &= "</td>"
                strim &= "</tr>       "
            End While
            strim &= "</table>"

            disp_result.innerhtml = strim
        End If
    End Sub
End Class

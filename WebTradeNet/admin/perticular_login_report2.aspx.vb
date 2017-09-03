Imports System.Data.SqlClient
Partial Class admin_perticular_login_report2
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
        If Not Page.IsPostBack Then
            cbo_users.Items.Add("ALL")
            command("sp_chk_username_availabality")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_users.Items.Add(rdr("username_"))
            End While
        End If
    End Sub

    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Dim username As String = ""
        If cbo_users.SelectedValue = "ALL" Then
            username = "%%"
        Else
            username = cbo_users.SelectedValue
        End If

        Dim date_from As Date = "11/12/1990"
        Dim date_to As Date = Now
        Dim strim As String = ""

        If fecha01.Text = "" Or fecha02.Text = "" Then
        Else
            date_from = fecha01.Text
            date_to = fecha02.Text & " 23:59:59"
        End If

        Dim i As Integer = 0
        strim &= "<table cellpadding=""0"" cellspacing=""0"" class=""table_1"" >"
        strim &= "<tr class=""spl_td"">"
        strim &= "<td width=""50"">"
        strim &= "No."
        strim &= "</td>"
        strim &= "<td width=""100"">"
        strim &= "Username"
        strim &= "</td>"
        strim &= "<td width=""100"">"
        strim &= "Name"
        strim &= "</td>"
        strim &= "<td width=""200"">"
        strim &= "Login Time"
        strim &= "</td>"


        command("sp_get_perticular_login_report")
        cmd.Parameters.AddWithValue("@username_", username)
        cmd.Parameters.AddWithValue("@date_from", date_from)
        cmd.Parameters.AddWithValue("@date_to", date_to)
        rdr = cmd.ExecuteReader
        While rdr.Read
            i = i + 1
            strim &= "<tr>"
            strim &= "   <td>"
            strim &= i
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("username_")
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("name_")
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("time_value")
            strim &= "  </td>"
            strim &= "</tr>"
        End While
        strim &= "</table>"

        disp_result.innerhtml = strim
    End Sub

    Protected Sub btn_export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_export.Click
        Dim username As String = ""
        Dim heading As String = ""
        If cbo_users.SelectedValue = "ALL" Then
            username = "%%"
            heading &= "TradeNet CAREe Login Report :- ALL Users"
        Else
            username = cbo_users.SelectedValue
            heading &= "TradeNet CAREe Login Report :- For User &quot;" & cbo_users.SelectedValue & "&quot;"
        End If

        Dim date_from As Date = "11/12/1990"
        Dim date_to As Date = Now
        Dim strim As String = ""

        If fecha01.Text = "" Or fecha02.Text = "" Then
        Else
            date_from = fecha01.Text
            date_to = fecha02.Text & " 23:59:59"
            heading &= " From : &quot;" & date_from & "&quot; To : &quot;" & date_to & "&quot;"
        End If

        Dim i As Integer = 0
        strim &= "<table cellpadding=""0"" cellspacing=""0"" class=""table_1"" border=""1"">"
        strim &= "<tr class=""spl_td"">"
        strim &= "<td width=""50"">"
        strim &= "No."
        strim &= "</td>"
        strim &= "<td width=""200"">"
        strim &= "Username"
        strim &= "</td>"
        strim &= "<td width=""200"">"
        strim &= "Name"
        strim &= "</td>"
        strim &= "<td width=""400"">"
        strim &= "Login Time"
        strim &= "</td>"


        command("sp_get_perticular_login_report")
        cmd.Parameters.AddWithValue("@username_", username)
        cmd.Parameters.AddWithValue("@date_from", date_from)
        cmd.Parameters.AddWithValue("@date_to", date_to)
        rdr = cmd.ExecuteReader
        While rdr.Read
            i = i + 1
            strim &= "<tr>"
            strim &= "   <td>"
            strim &= i
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("username_")
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("name_")
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("time_value")
            strim &= "  </td>"
            strim &= "</tr>"
        End While
        strim &= "</table>"


        Response.ContentType = "application/xls"
        Response.AddHeader("content-disposition", "attachment;filename=TnCAREe_Login_Report_" & Now.Year() & Now.Month() & Now.Day() & ".xls")
        Response.Charset = ""
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Me.Controls.Add(frm)
        frm.RenderControl(hw)
        Response.Write("<h5>" & heading & "</h5>")
        Response.Write(strim)
        Response.Write("<font face=""Arial, Helvetica, sans-serif"" size=""-6"" > This Is &quot;TnCAREe&quot; Generated Report , Dated :" & Today() & "</font>")
        tw.Write("hi2")
        Response.End()
    End Sub
End Class

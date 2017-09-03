Imports System.Data.SqlClient
Partial Class TD
    Inherits System.Web.UI.MasterPage
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Sub command2(ByVal strcmd As String)
        cmd2.CommandType = Data.CommandType.StoredProcedure
        cmd2.CommandText = strcmd
        cmd2.Connection = weldone_con.ConObj
        cmd2.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim loginerType As String = Session.Item("loginerTYP")
        lbl_today.Text = Today()
        command("sp_get_loginer_details")
        cmd.Parameters.AddWithValue("@id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Label1.Text = "Name  : " & rdr("name_")
        End If
        If loginerType = "ADMIN" Then
            LinkButton1.Enabled = True


        Else
            LinkButton1.Enabled = False

        End If
    End Sub

    Protected Sub lnkbtn_Home_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtn_Home.Click
        Dim loginerType As String = Session.Item("loginerTYP")
        If loginerType = "ADMIN" Then
            Response.Redirect("Assign_task.aspx")
            LinkButton1.Visible = True

        Else
            Response.Redirect("login_Next.aspx")
            LinkButton1.Visible = False

        End If
    End Sub
End Class


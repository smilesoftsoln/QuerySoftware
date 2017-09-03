Imports System.Data.SqlClient
Partial Class change_password
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Public creater As Integer
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loginerID As Integer
        loginerID = Session.Item("loginerID")

        command("sp_get_dept_emp_by_id")
        cmd.Parameters.AddWithValue("@id", loginerID)
        rdr = cmd.ExecuteReader

        If rdr.Read Then
            txt_u_name.Text = rdr("username_")
            txt_u_name.Enabled = False
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim loginerID As Integer
        Panel2.Visible = False
        loginerID = Session.Item("loginerID")

        command("sp_get_dept_employee")
        cmd.Parameters.AddWithValue("@uname", txt_u_name.Text)
        cmd.Parameters.AddWithValue("@pwd", txt_this_pwd.Text)
        rdr = cmd.ExecuteReader

        If rdr.Read Then
            If txt_new_pwd.Text = txt_conf_pwd.Text Then
                command("sp_change_pwd_by_l_id")
                cmd.Parameters.AddWithValue("@l_id", loginerID)
                cmd.Parameters.AddWithValue("@new_pwd", txt_new_pwd.Text)
                If cmd.ExecuteNonQuery Then
                    Panel1.Visible = False
                    Panel2.Visible = True
                    Label1.Text = "Password Change Successfully !"
                End If
            Else
                Panel2.Visible = True
                Label1.Text = "Password Not Match !"
            End If
        Else
            'MsgBox("hi")
        End If
    End Sub
End Class

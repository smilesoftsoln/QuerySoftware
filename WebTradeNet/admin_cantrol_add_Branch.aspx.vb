Imports System.Data.SqlClient
Partial Class admin_cantrol_add_Branch
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

    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_submit.Click
        Dim samp As Integer = 0
        If txt_b_name.Text = "" Then
            samp = samp + 1
        ElseIf txt_desc.Text = "" Then
            samp = samp + 1
        End If

        If samp > 0 Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Invalied Data..!')</script>")
        Else
            command("sp_insert_branch")
            cmd.Parameters.AddWithValue("@branchName", txt_b_name.Text)
            cmd.Parameters.AddWithValue("@branch_desc", txt_desc.Text)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("admin_cantrol_success_msg.aspx?msg=Emtry has been Done Successfully.. ! &वेब डिझायनर सुरज महाजन.htm ")
            End If
        End If
    End Sub

    Protected Sub txt_b_name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_b_name.TextChanged
        command("sp_chk_branch_exist_or_not")
        cmd.Parameters.AddWithValue("@this_branch", txt_b_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Branch Name -" & txt_b_name.Text & "- is Already in use \nPlease choose Diffrent Branch Name')</script>")
            txt_b_name.Text = ""
            txt_desc.Text = ""
            txt_b_name.Focus()
        Else
            txt_b_name.Text = txt_b_name.Text.ToUpper()
        End If
    End Sub
End Class

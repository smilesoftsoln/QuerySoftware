Imports System.Data.SqlClient
Partial Class admin_cantrol_add_Dept_Emp
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
            command("sp_get_departments")
            rdr = cmd.ExecuteReader
            cbo_depts.Items.Add("")
            While rdr.Read
                cbo_depts.Items.Add(rdr("dept_name"))
            End While
        End If
       
    End Sub

    Protected Sub txt_username_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_username.TextChanged
        command("sp_chk_username_av_or_not")
        cmd.Parameters.AddWithValue("@thisuname", txt_username.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Username is already in use \nPlease try Ddiffrent username..!')</script>")
            txt_username.Text = ""
            txt_username.Focus()
            sepm = sepm + 1
        End If
    End Sub

    Protected Sub txt_email_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged
        command("sp_chk_email_av_or_not")
        cmd.Parameters.AddWithValue("@thisemail", txt_email.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('This Email-ID is already in use \nPlease make Ddiffrent Email-ID ..!')</script>")
            txt_email.Text = ""
            txt_email.Focus()
            sepm = sepm + 1
        End If

        Dim emailAddress As String = txt_email.Text
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
        Else
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Invalied Email ID\nPlease check Email ID ypu entered ..!')</script>")
            txt_email.Focus()
            sepm = sepm + 1
        End If
    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_submit.Click
        If txt_c_pass.Text = "" Then
            sepm = sepm + 1
        ElseIf txt_conf_pass.Text = "" Then
            sepm = sepm + 1
        ElseIf txt_email.Text = "" Then
            sepm = sepm + 1
        ElseIf txt_f_name.Text = "" Then
            sepm = sepm + 1
        ElseIf txt_username.Text = "" Then
            sepm = sepm + 1
        End If

        Dim loginer As Integer = 0
        Dim this_loginerID As Integer = 0
        Dim forign_id As Integer = 0
        Dim Dept_id As Integer = 0

        command("sp_get_count_of_loginers")
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            loginer = rdr("count_") + 1
        End If

        command("sp_get_count_of_dept_emps")
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            forign_id = rdr("count_") + 1
        End If

        Dim lvl_code As Integer = 0
        Dim spicl_count As Integer = 0
        '================getting lvl_code============
        command("sp_get_lvl_code")
        cmd.Parameters.AddWithValue("@short_key", "DE")
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lvl_code = rdr("lvl_code")
        End If
        '============================================

        '===========getting spcil_user count========
        command("sp_count_of_spcil_user")
        cmd.Parameters.AddWithValue("@short_key", "DE")
        rdr = cmd.ExecuteReader
        While rdr.Read
            this_loginerID = rdr("id") + 1
            spicl_count = spicl_count + 1
        End While
        '============================================
        this_loginerID = lvl_code & spicl_count + 1

        command("sp_get_dept_id_by_dept_name")
        cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Dept_id = rdr("id")
        End If
        Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Password Not mach\n " & spicl_count & "!')</script>")
        If sepm > 0 Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Error In Input\nPlease check input Feilds  agein..!')</script>")
        ElseIf Not txt_c_pass.Text = txt_conf_pass.Text Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Password Not mach\nPlease check input password feild..!')</script>")
        Else
            command("sp_insert_tbl_dept_emp_master")
            cmd.Parameters.AddWithValue("@dept_id", Dept_id)
            cmd.Parameters.AddWithValue("@name_", txt_f_name.Text)
            cmd.Parameters.AddWithValue("@username_", txt_username.Text)
            cmd.Parameters.AddWithValue("@password_", txt_c_pass.Text)
            cmd.Parameters.AddWithValue("@dept_post", "DE")
            cmd.Parameters.AddWithValue("@e_mel", txt_email.Text)
            If cmd.ExecuteNonQuery Then

                command("sp_insert_loginer")
                cmd.Parameters.AddWithValue("@id", this_loginerID)
                cmd.Parameters.AddWithValue("@username_", txt_username.Text)
                cmd.Parameters.AddWithValue("@password_", txt_c_pass.Text)
                cmd.Parameters.AddWithValue("@display_name", txt_f_name.Text)
                cmd.Parameters.AddWithValue("@who_is", "DE")
                cmd.Parameters.AddWithValue("@forign_id", forign_id)
                If cmd.ExecuteNonQuery() Then
                    command("sp_insert_insert_ranking")
                    cmd.Parameters.AddWithValue("@dept_id", Dept_id)
                    cmd.Parameters.AddWithValue("@emp_id", forign_id)
                    If cmd.ExecuteNonQuery() Then
                        command("sp_insert_tbl_last_login")
                        cmd.Parameters.AddWithValue("@loginerID", this_loginerID)
                        If cmd.ExecuteNonQuery Then
                            Response.Redirect("admin_cantrol_success_msg.aspx?msg=Account of 'DEPARTMENT EMPLOYEE' from user " & txt_f_name.Text & " has been Created Successfully.. ! &वेब डिझायनर सुरज महाजन.htm ")
                        End If
                    End If
                End If
            End If
            End If
    End Sub
End Class

Imports System.Data.SqlClient
Partial Class admin_cantrol_add_Branch_Emp
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
            command("sp_get_branches")
            rdr = cmd.ExecuteReader
            cbo_branchs.Items.Add("")
            While rdr.Read
                cbo_branchs.Items.Add(rdr("branchName"))
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
            else
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
        ElseIf txt_phone.Text = "" Then
            sepm = sepm + 1
        ElseIf txt_username.Text = "" Then
            sepm = sepm + 1
        ElseIf cbo_branchs.SelectedValue = "" Then
            sepm = sepm + 1
        ElseIf cbo_w_post.SelectedValue = "" Then
            sepm = sepm + 1
        End If

        Dim loginer As Integer = 0
        Dim this_loginerID As Integer = 0
        Dim forign_id As Integer = 0

        command("sp_get_count_of_loginers")
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            loginer = rdr("count_") + 1
        End If

        command("sp_count_of_users_ids")
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            forign_id = rdr("count_") + 1
        End If

        Dim lvl_code As Integer = 0
        Dim spicl_count As Integer = 1
        '================getting lvl_code============
        command("sp_get_lvl_code")
        cmd.Parameters.AddWithValue("@short_key", cbo_w_post.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lvl_code = rdr("lvl_code")
        End If
        '============================================

        '===========getting spcil_user count========
        command("sp_count_of_spcil_user")
        cmd.Parameters.AddWithValue("@short_key", cbo_w_post.SelectedValue)
        rdr = cmd.ExecuteReader
        While rdr.Read
            spicl_count = spicl_count + 1
        End While
        '============================================
        this_loginerID = lvl_code & spicl_count + 1

        If sepm > 0 Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Error In Input\nPlease check input Feilds  agein..!')</script>")
        ElseIf Not txt_c_pass.Text = txt_conf_pass.Text Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Password Not mach\nPlease check input password feild..!')</script>")
        Else
            command("sp_insert_user")
            cmd.Parameters.AddWithValue("@phone_number", txt_phone.Text)
            cmd.Parameters.AddWithValue("@e_mail_id", txt_email.Text)
            cmd.Parameters.AddWithValue("@branch_name", cbo_branchs.SelectedValue)
            cmd.Parameters.AddWithValue("@desegnitio_", cbo_w_post.SelectedValue)
            If cmd.ExecuteNonQuery() Then
                command("sp_insert_loginer")
                cmd.Parameters.AddWithValue("@id", this_loginerID)
                cmd.Parameters.AddWithValue("@username_", txt_username.Text)
                cmd.Parameters.AddWithValue("@password_", txt_c_pass.Text)
                cmd.Parameters.AddWithValue("@display_name", txt_f_name.Text)
                cmd.Parameters.AddWithValue("@who_is", cbo_w_post.SelectedValue)
                cmd.Parameters.AddWithValue("@forign_id", forign_id)
                If cmd.ExecuteNonQuery() Then
                    command("sp_insert_tbl_last_login")
                    cmd.Parameters.AddWithValue("@loginerID", this_loginerID)
                    If cmd.ExecuteNonQuery Then
                        Response.Redirect("admin_cantrol_success_msg.aspx?msg=Account of 'BRANCH EMPLOYEE' from user " & txt_f_name.Text & " has been Created Successfully.. ! &वेब डिझायनर सुरज महाजन.htm ")
                    End If
                End If


            End If
            End If
    End Sub
End Class

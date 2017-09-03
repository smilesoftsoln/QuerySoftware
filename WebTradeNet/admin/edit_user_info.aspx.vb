Imports System.Data.SqlClient
Imports System.Configuration

Partial Class admin_edit_user_info
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim todo_con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Public sepm As Integer = 0
    Dim post As String = ""
    Dim loginerID As Integer = 0
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        todo_con = New SqlConnection(ConfigurationManager.ConnectionStrings("myconstring").ToString())

        If Not Page.IsPostBack Then
            Dim lid As Integer = Request.QueryString("lid")
            command("sp_get_loginer_details")
            cmd.Parameters.AddWithValue("@id", lid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_name.Text = rdr("name_")
                UserNameTextBox1.Text = rdr("username_")
                EmailTextBox3.Text = rdr("email_id")
                NameTextBox2.Text = rdr("name_")
                PhoneTextBox4.Text = rdr("phone_number")
                txt_pwd.Text = rdr("password_")
                txt_conf_pwd.Text = rdr("password_")
                cbo_user_typ.Text = rdr("post_")
                lbl_username.Text = rdr("username_")
            End If
            '        If cbo_user_typ.SelectedValue = "BE" Or cbo_user_typ.SelectedValue = "BH" Or cbo_user_typ.SelectedValue = "SRBM" Then
            '            pnl_BE1.Visible = False
            '            pnl_DE1.Visible = False
            '            pnl_HOD1.Visible = False
            '            pnl_mng1.Visible = False
            '            'If Not Page.IsPostBack Then

            '            cbo_branch.Items.Clear()
            '            cbo_branch.Items.Add("")
            '            command("sp_get_branches")
            '            rdr = cmd.ExecuteReader
            '            While rdr.Read
            '                cbo_branch.Items.Add(rdr("branch_name"))
            '            End While
            '            'End If
            '        End If

            '        If cbo_user_typ.SelectedValue = "DE" Then
            '            pnl_DE1.Visible = False
            '            pnl_BE1.Visible = False
            '            'pnl_DE.Visible = False
            '            pnl_HOD1.Visible = False
            '            pnl_mng1.Visible = False
            '            cbo_depts.Items.Clear()
            '            'If Not Page.IsPostBack Then
            '            cbo_depts.Items.Add("")
            '            command("sp_get_depts")
            '            rdr = cmd.ExecuteReader
            '            While rdr.Read
            '                cbo_depts.Items.Add(rdr("dept_name"))
            '            End While
            '            'End If
            '        End If

            '        If cbo_user_typ.SelectedValue = "HOD" Or cbo_user_typ.SelectedValue = "SRMNG" Then
            '            pnl_HOD1.Visible = False
            '            ' pnl_DE.Visible = True
            '            pnl_BE1.Visible = False
            '            pnl_DE1.Visible = False
            '            '  pnl_HOD.Visible = False
            '            pnl_mng1.Visible = False
            '            '   If Not Page.IsPostBack Then
            '            cbo_depts_1_hod.Items.Clear()
            '            cbo_depts_1_hod.Items.Add("")
            '            command("sp_get_depts")
            '            rdr = cmd.ExecuteReader
            '            While rdr.Read
            '                cbo_depts_1_hod.Items.Add(rdr("dept_name"))
            '            End While
            '            'End If
            '        End If

            '        If cbo_user_typ.SelectedValue = "MNG" Then
            '            pnl_mng1.Visible = False
            '            'pnl_HOD.Visible = True
            '            ' pnl_DE.Visible = True
            '            pnl_BE1.Visible = False
            '            pnl_DE1.Visible = False
            '            pnl_HOD1.Visible = False
            '            'pnl_mng.Visible = False
            '            '   If Not Page.IsPostBack Then
            '            cbo_mngs.Items.Clear()
            '            cbo_mngs.Items.Add("")
            '            command("sp_get_managements")
            '            rdr = cmd.ExecuteReader
            '            While rdr.Read
            '                cbo_mngs.Items.Add(rdr("mng_name"))
            '            End While
            '            ' End If
            '        End If
            '        '*********************************

            '    End If

            'End Sub
            'Protected Sub cbo_user_typ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_user_typ.SelectedIndexChanged
            '    If cbo_user_typ.SelectedValue = "BE" Or cbo_user_typ.SelectedValue = "BH" Or cbo_user_typ.SelectedValue = "SRBM" Then
            '        pnl_BE1.Visible = False
            '        pnl_DE1.Visible = False
            '        pnl_HOD1.Visible = False
            '        pnl_mng1.Visible = False
            '        'If Not Page.IsPostBack Then

            '        cbo_branch.Items.Clear()
            '        cbo_branch.Items.Add("")
            '        command("sp_get_branches")
            '        rdr = cmd.ExecuteReader
            '        While rdr.Read
            '            cbo_branch.Items.Add(rdr("branch_name"))
            '        End While
            '        'End If
            '    End If

            '    If cbo_user_typ.SelectedValue = "DE" Then
            '        pnl_DE1.Visible = False
            '        pnl_BE1.Visible = False
            '        'pnl_DE.Visible = False
            '        pnl_HOD1.Visible = False
            '        pnl_mng1.Visible = False
            '        cbo_depts.Items.Clear()
            '        'If Not Page.IsPostBack Then
            '        cbo_depts.Items.Add("")
            '        command("sp_get_depts")
            '        rdr = cmd.ExecuteReader
            '        While rdr.Read
            '            cbo_depts.Items.Add(rdr("dept_name"))
            '        End While
            '        'End If
            '    End If

            '    If cbo_user_typ.SelectedValue = "HOD" Or cbo_user_typ.SelectedValue = "SRMNG" Then
            '        pnl_HOD1.Visible = False
            '        ' pnl_DE.Visible = True
            '        pnl_BE1.Visible = False
            '        pnl_DE1.Visible = False
            '        '  pnl_HOD.Visible = False
            '        pnl_mng1.Visible = False
            '        '   If Not Page.IsPostBack Then
            '        cbo_depts_1_hod.Items.Clear()
            '        cbo_depts_1_hod.Items.Add("")
            '        command("sp_get_depts")
            '        rdr = cmd.ExecuteReader
            '        While rdr.Read
            '            cbo_depts_1_hod.Items.Add(rdr("dept_name"))
            '        End While
            '        'End If
            '    End If

            '    If cbo_user_typ.SelectedValue = "MNG" Then
            '        pnl_mng1.Visible = False
            '        'pnl_HOD.Visible = True
            '        ' pnl_DE.Visible = True
            '        pnl_BE1.Visible = False
            '        pnl_DE1.Visible = False
            '        pnl_HOD1.Visible = False
            '        'pnl_mng.Visible = False
            '        '   If Not Page.IsPostBack Then
            '        cbo_mngs.Items.Clear()
            '        cbo_mngs.Items.Add("")
            '        command("sp_get_managements")
            '        rdr = cmd.ExecuteReader
            '        While rdr.Read
            '            cbo_mngs.Items.Add(rdr("mng_name"))
            '        End While
            ' End If
        End If
        '*********************************
    End Sub

    'Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
    '    command("sp_update_user_info")
    '    cmd.Parameters.AddWithValue("@id", Request.QueryString("lid"))
    '    cmd.Parameters.AddWithValue("@name_", NameTextBox2.Text)
    '    cmd.Parameters.AddWithValue("@phone_number", PhoneTextBox4.Text)
    '    cmd.Parameters.AddWithValue("@email_id", EmailTextBox3.Text)
    '    cmd.Parameters.AddWithValue("@password_", txt_pwd.Text)
    '    cmd.Parameters.AddWithValue("@username_", UserNameTextBox1.Text)
    '    cmd.Parameters.AddWithValue("@post_", cbo_user_typ.Text)

    '    If cmd.ExecuteNonQuery Then
    '        Response.Redirect("msg.aspx?msg=User Updates Successfully !")
    '    End If

    'End Sub

    Protected Sub btn_submit_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        command("sp_update_user_info")
        cmd.Parameters.AddWithValue("@id", Request.QueryString("lid"))
        cmd.Parameters.AddWithValue("@name_", NameTextBox2.Text)
        cmd.Parameters.AddWithValue("@phone_number", PhoneTextBox4.Text)
        cmd.Parameters.AddWithValue("@email_id", EmailTextBox3.Text)
        cmd.Parameters.AddWithValue("@password_", txt_pwd.Text)
        cmd.Parameters.AddWithValue("@username_", UserNameTextBox1.Text)
        cmd.Parameters.AddWithValue("@post_", cbo_user_typ.Text)

        cmd.ExecuteNonQuery()
        'If cmd.ExecuteNonQuery Then
        '    command("sp_get_loginer_by_username")
        '    cmd.Parameters.AddWithValue("@username_", UserNameTextBox1.Text)
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then

        '        '  step2.Attributes.Add("src", "add_new_user_stape_2.aspx?loginerID=" & rdr("id") & "&post_=" & rdr("post_") & "&Documents%20and%20Settings/Sri%20Sri/My%20Documents/Down_18_12_2010/Call%20Center%20India,%20call%20center%20outsourcing,%20call%20center%20service,%20Inbound%20call%20center.htm?AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
        '        ' Response.Redirect("add_new_user_stape_2.aspx?loginerID=" & rdr("id") & "&post_=" & rdr("post_") & "&Documents%20and%20Settings/Sri%20Sri/My%20Documents/Down_18_12_2010/Call%20Center%20India,%20call%20center%20outsourcing,%20call%20center%20service,%20Inbound%20call%20center.htm?AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQaQQEEEEEEEAAAAAAAAAAAAAAaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.com")
        '        post = rdr("post_")
        '        loginerID = rdr("id")
        '        If post = "BE" Or post = "BH" Then
        '            '*************************
        '            Dim branch_id As Integer = 0
        '            Dim loginer_id As Integer = loginerID
        '            command("sp_get_branch_by_name")
        '            cmd.Parameters.AddWithValue("@branch_name", cbo_branch.SelectedValue)
        '            rdr = cmd.ExecuteReader
        '            If rdr.Read Then
        '                branch_id = rdr("id")
        '            End If

        '            'command("sp_insert_login_stts")
        '            'cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '            'cmd.ExecuteNonQuery()

        '            If cbo_user_typ.SelectedValue = "BH" Then
        '                command("chk_branchManageisExistOrNot")
        '                cmd.Parameters.AddWithValue("@branchName", cbo_branch.SelectedValue)
        '                rdr = cmd.ExecuteReader
        '                If rdr.Read Then
        '                    Page.RegisterStartupScript("", "<script language=""JavaScript"">alert('For selected branch " & cbo_branch.SelectedValue & " Branch Head already declared !')</scrit>")
        '                    msg.InnerHtml = "For selected branch " & cbo_branch.SelectedValue & " Branch Head already declared !"
        '                Else
        '                    command("sp_update_tbl_loginer_stape_to")
        '                    cmd.Parameters.AddWithValue("@forign_id", branch_id)
        '                    cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '                    If cmd.ExecuteNonQuery Then
        '                        '  command("sp_insert_login_stts")
        '                        ' cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '                        'cmd.ExecuteNonQuery()
        '                        Response.Redirect("msg.aspx?msg=User Updated Successfully !<br><Br><a href=""add_new_user.aspx"">Add Another User</a> ")

        '                    End If
        '                End If
        '            Else
        '                command("sp_update_tbl_loginer_stape_to")
        '                cmd.Parameters.AddWithValue("@forign_id", branch_id)
        '                cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '                If cmd.ExecuteNonQuery Then
        '                    'command("sp_insert_login_stts")
        '                    'cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '                    'cmd.ExecuteNonQuery()
        '                    Response.Redirect("msg.aspx?msg=User Updated Successfully !<br><Br><a href=""add_new_user.aspx"">Add Another User</a> ")

        '                End If
        '            End If
        '        ElseIf post = "HOD" Or post = "SRMNG" Then
        '            Dim Dept_id As Integer = 0
        '            Dim loginer_id As Integer = loginerID
        '            command("sp_get_dept_by_name")
        '            cmd.Parameters.AddWithValue("@dept_name", cbo_depts_1_hod.SelectedValue)
        '            rdr = cmd.ExecuteReader
        '            If rdr.Read Then
        '                Dept_id = rdr("id")
        '            End If
        '            If post = "HOD" Then
        '                command("sp_set_hod_to_dept")
        '                cmd.Parameters.AddWithValue("@dept_id", Dept_id)
        '                cmd.Parameters.AddWithValue("@hod_loginer_id", loginer_id)
        '                cmd.ExecuteNonQuery()
        '            End If
        '            'command("sp_insert_login_stts")
        '            ' cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '            ' cmd.ExecuteNonQuery()

        '            command("sp_update_tbl_loginer_stape_to")
        '            cmd.Parameters.AddWithValue("@forign_id", Dept_id)
        '            cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '            If cmd.ExecuteNonQuery Then
        '                Response.Redirect("msg.aspx?msg=User Updated Successfully !")
        '            End If
        '        ElseIf post = "DE" Then
        '            Dim Dept_id As Integer = 0
        '            Dim loginer_id As Integer = loginerID
        '            command("sp_get_dept_by_name")
        '            cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
        '            rdr = cmd.ExecuteReader
        '            If rdr.Read Then
        '                Dept_id = rdr("id")
        '            End If

        '            '   command("sp_insert_login_stts")
        '            '  cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '            ' cmd.ExecuteNonQuery()

        '            command("sp_update_tbl_loginer_stape_to")
        '            cmd.Parameters.AddWithValue("@forign_id", Dept_id)
        '            cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '            If cmd.ExecuteNonQuery Then
        '                command("sp_insert_rankings")
        '                cmd.Parameters.AddWithValue("@dept_id", Dept_id)
        '                cmd.Parameters.AddWithValue("@emp_id", loginer_id)
        '                If cmd.ExecuteNonQuery Then
        '                    Response.Redirect("msg.aspx?msg=User Created Successfully !")
        '                End If
        '            End If

        '        ElseIf post = "MNG" Then
        '            Dim mng_id As Integer = 0
        '            Dim loginer_id As Integer = loginerID
        '            command("sp_get_management_by_name")
        '            cmd.Parameters.AddWithValue("@mng_name", cbo_mngs.SelectedValue)
        '            rdr = cmd.ExecuteReader
        '            If rdr.Read Then
        '                mng_id = rdr("id")
        '            End If

        '            ' command("sp_insert_login_stts")
        '            ''cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '            'cmd.ExecuteNonQuery()

        '            command("sp_update_tbl_loginer_stape_to")
        '            cmd.Parameters.AddWithValue("@forign_id", mng_id)
        '            cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '            If cmd.ExecuteNonQuery Then
        '                command("sp_update_manager_loginer_id")
        '                cmd.Parameters.AddWithValue("@id", mng_id)
        '                cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        '                If cmd.ExecuteNonQuery Then
        '                    Response.Redirect("msg.aspx?msg=User Updated Successfully !")
        '                End If

        '            End If
        '            '***************************
        '        End If 'end if for post BH BE

        '    End If
        'End If
        ''********************************
        ''Dim post As String = Request.QueryString("post_")
        ''Dim loginerID As Integer = Request.QueryString("loginerID")
        ''command("sp_get_user_by_id")
        'cmd.Parameters.AddWithValue("@uid", loginerID)
        'rdr = cmd.ExecuteReader
        'If rdr.Read Then
        '    LBL_INFO.Text = "<span style=""color:red;font-size:16px;""><b> * </b></span>Please select a Department For User <b> " & rdr("username_") & " (" & rdr("name_") & ") " & " </b><br><br>"
        'End If

        todo_con.Open()
        cmd = New SqlCommand()
        cmd.Connection = todo_con
        cmd.CommandText = "update t_m_login set name='" + NameTextBox2.Text.Trim() + "',email_id='" + EmailTextBox3.Text + "' where loginid='" + UserNameTextBox1.Text + "'"
        cmd.ExecuteNonQuery()
        todo_con.Close()

        Response.Redirect("msg.aspx?msg=User Updated Successfully !")

    End Sub
    'Protected Sub btn_show_password_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_show_password.Click


    '    If btn_show_password.Text = "Hide Password" Then
    '        txt_pass.Visible = False
    '        lbl_password.Visible = True
    '        btn_show_password.Text = "Show Password"
    '    Else
    '        txt_pass.Visible = True
    '        lbl_password.Visible = False
    '        btn_show_password.Text = "Hide Password"
    '    End If
    'End Sub

    Protected Sub txt_username_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserNameTextBox1.TextChanged
        command("sp_chk_username_2")
        cmd.Parameters.AddWithValue("@ori_username", lbl_username.Text)
        cmd.Parameters.AddWithValue("@new_username", UserNameTextBox1.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Username Name Already Exist!')</script>")
            UserNameTextBox1.Text = lbl_username.Text
        Else
            NameTextBox2.Focus()
        End If
    End Sub
End Class

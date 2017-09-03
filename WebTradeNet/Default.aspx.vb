Imports System.Data.SqlClient
Imports System.Data


Partial Class _Default
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim commasn_fns As New somman_functions_NM.commen_funcs
    Dim cmd As New SqlCommand
    Dim cmd_get_login_information As New SqlCommand
    Dim rdr As SqlDataReader
    Dim dr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim con As New SqlConnection
    Dim dr2 As SqlDataReader

    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_submit.Click
        Dim user As String
        Dim tmp_timeval As String
        Dim lastlogin As String
        Dim whi_is As String = ""
        Session("login") = txt_uName.Text.Trim()
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("myconstring").ConnectionString)
        If con.State = ConnectionState.Open Then

            con.Close()

        End If
        con.Open()
        Dim x As Int32
        Dim cmd_check_loginid As SqlCommand = New SqlCommand("login_check_userid", con)
        cmd_check_loginid.CommandType = CommandType.StoredProcedure
        cmd_check_loginid.Parameters.Add("@u_id", SqlDbType.NVarChar).Value = txt_uName.Text.Trim().ToString()
        x = Convert.ToInt32(cmd_check_loginid.ExecuteScalar())
        con.Close()
        con.Open()

        Dim cmd_get_login_information1 As SqlCommand = New SqlCommand("get_login_information", con)
        cmd_get_login_information1.CommandType = CommandType.StoredProcedure
        cmd_get_login_information1.Parameters.Clear()
        cmd_get_login_information1.Parameters.AddWithValue("@id", x)
        Dim dr1 As SqlDataReader = cmd_get_login_information1.ExecuteReader()
        dr1.Read()

        ' update login status

        If dr1.HasRows Then
            Session.Add("loginid", dr1(1).ToString())
            Session.Add("lgid", x)
            Session.Add("forign_id_todo", dr1(4).ToString())

        End If


        dr1.Close()
        con.Close()
        command("sp_get_loginer")
        cmd.Parameters.AddWithValue("@uname", txt_uName.Text)
        cmd.Parameters.AddWithValue("@pwd", txt_pwd.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            whi_is = rdr("post_")
            'Session.RemoveAll()
            Session.Add("loginerID", rdr("id"))
            command("sp_read_last_login_by_id")
            cmd.Parameters.AddWithValue("@id", Session.Item("loginerID"))
            rdr = cmd.ExecuteReader
            While rdr.Read
                lastlogin = rdr("time_value")
            End While
            Session.Item("last_login") = lastlogin
            command("sp_write_last_login_by_id")
            cmd.Parameters.AddWithValue("@id", Session.Item("loginerID"))
            cmd.Parameters.AddWithValue("@time_value", Now())
            cmd.ExecuteNonQuery()
            cmd_get_login_information.CommandText = "sp_get_user_info_by_loginer_id"
            cmd_get_login_information.Connection = weldone_con.ConObj
            cmd_get_login_information.CommandType = Data.CommandType.StoredProcedure
            '' cmd_get_login_information.Parameters.Clear()
            '' Dim str As String = Session("loginerID") 

            cmd_get_login_information.Parameters.AddWithValue("@lofiner_id", Session("loginerID"))
            dr = cmd_get_login_information.ExecuteReader()
            If (dr.HasRows) Then
                dr.Read()

                '   Session.Add("loginid", Session("loginerID"))
                ''Session.Add("type", dr(2).ToString())
                Dim loginer As String = dr("name_").ToString()

                Session.Add("loginer", loginer)
                Session.Add("login", dr("username_").ToString())
                Session.Add("forign_id", dr("forign_id").ToString())
                '   dim xyz As Integer = Convert.ToInt32(Session["forign_id"]);

            End If
            If whi_is <> "ADMIN" Then
                Try
                    Dim cmd_get_mng_id_by_dept_id As SqlCommand = New SqlCommand()
                    cmd_get_mng_id_by_dept_id.Connection = weldone_con.ConObj
                    cmd_get_mng_id_by_dept_id.CommandText = "select manage_id from tbl_dept_master as d  where id = " & Convert.ToInt32(Session("forign_id"))
                    Session.Add("manage_id", cmd_get_mng_id_by_dept_id.ExecuteScalar().ToString())
                    Dim cmd_get_dept_name_by_dept_id As SqlCommand = New SqlCommand()
                    cmd_get_dept_name_by_dept_id.Connection = weldone_con.ConObj
                    cmd_get_dept_name_by_dept_id.CommandText = "select dept_name from tbl_dept_master as d  where id = " & Convert.ToInt32(Session("forign_id"))
                    Session.Add("dept_name", cmd_get_dept_name_by_dept_id.ExecuteScalar().ToString())

                Catch ex As Exception

                End Try
                      End If

        Else
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Login Failed ! \nPlease Check Input UserName Or Password! \nOr Contact To Developer ')</script>")
        End If
        cmd2.CommandText = "select * from SoftwareMapping where UserName='" + Session("login").ToString() + "'"
        cmd2.Connection = weldone_con.ConObj
        dr2 = cmd2.ExecuteReader()
        Dim map As Boolean = dr2.HasRows




        If whi_is = "ADMIN" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "ADMIN")
            Session.Add("type", "ADMIN")
            Response.Cookies("mainadmin")("login") = "true"
            If map = True Then
                Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
            Else
                Response.Redirect("admin/Login_Next.aspx")
            End If

        ElseIf whi_is = "DE" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "DE")
            Session.Add("type", "DE")
            Response.Cookies("admin")("login") = "true"
            If map = True Then
                Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
            Else
                Response.Redirect("employee_login_next.aspx")
            End If

        ElseIf whi_is = "BE" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "BE")
            Session.Add("type", "BE")
            Response.Cookies("admin")("login") = "true"
            If map = True Then
                Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
            Else
                Response.Redirect("User_login_next.aspx")
                'Response.Redirect("employee_login_next.aspx")
            End If


        ElseIf whi_is = "BH" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "BH")
            Session.Add("type", "BH")
            Response.Cookies("admin")("login") = "true"
            If map = True Then
                Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
            Else
                Response.Redirect("User_login_next.aspx")
                'Response.Redirect("employee_login_next.aspx")
            End If
            '  Response.Redirect("SoftwareSuite.aspx") 'by abhijeet
        ElseIf whi_is = "HOD" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "HOD")
            Session.Add("type", "HOD")
            Response.Cookies("admin")("login") = "true"
            If map = True Then
                Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
            Else
                Response.Redirect("hod_login_Next.aspx")
                'Response.Redirect("employee_login_next.aspx")
            End If
        ElseIf whi_is = "SHOD" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "SHOD")
            Session.Add("type", "SHOD")
            Response.Cookies("admin")("login") = "true"
            If map = True Then
                Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
            Else
                Response.Redirect("shod_login_Next.aspx")
                'Response.Redirect("employee_login_next.aspx")
            End If
        ElseIf whi_is = "MNG" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "MNG")
            Session.Add("type", "MNG")
            Response.Cookies("admin")("login") = "true"
            If map = True Then
                Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
            Else
                Response.Redirect("mng_login_next.aspx")
                'Response.Redirect("employee_login_next.aspx")
            End If

        ElseIf whi_is = "ADMIN" Then
            Session.Item("admin") = "admin"
            Session.Add("loginerTYP", "ADMIN")
            Session.Add("type", "ADMIN")
            Response.Cookies("admin")("login") = "true"
            Response.Redirect("admin/Login_Next.aspx")

        End If
       

    End Sub

    Protected Sub btn_clear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_clear.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'commasn_fns.Escalate_query()
        'Dim onusr As Integer = 0
        'onusr = Application("ActiveUsers")
        'Label1.Text = onusr
        'MsgBox(onusr)
    End Sub
End Class

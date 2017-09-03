Imports System.Data.SqlClient
Partial Class SoftwareSuite
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim commasn_fns As New somman_functions_NM.commen_funcs
    Dim cmd As New SqlCommand
    Dim cmd_get_login_information As New SqlCommand
    Dim rdr As SqlDataReader
    Dim dr As SqlDataReader
    Sub command(ByVal strcmd As String)
        ' cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim mode As String
        Dim username As String
        mode = Request.QueryString("Mode")
        If String.IsNullOrEmpty(mode) Then
            LoginLabel1.Text = Session("login").ToString()

            LoginTypeLabel1.Text = Session("loginerTYP").ToString()
        Else
            username = Request.QueryString("UserName")
            LoginLabel1.Text = username
            Session("login") = username
            command("select * from [tbl_loginer_master] where username_='" + username + "'")

            rdr = cmd.ExecuteReader
            If (rdr.HasRows) Then
                If rdr.Read() Then
                    'Response.Redirect(rdr(0).ToString() + "?UserName=" + LoginLabel1.Text)
                    LoginTypeLabel1.Text = rdr("post_").ToString()
                    Session("loginerTYP") = rdr("post_").ToString()
                    Session("Staff_name") = rdr("name_").ToString()

                End If



            End If
        End If

        'LoginLabel1.Text = Session("login").ToString()

        'LoginTypeLabel1.Text = Session("loginerTYP").ToString()
        If GridView1.Rows.Count = 0 Then
            Response.Redirect("Default.aspx")

        End If


    End Sub



    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim foreignid As String
        foreignid = Convert.ToInt32(Session("forign_id"))

        If (LoginTypeLabel1.Text.Equals("DE") Or LoginTypeLabel1.Text.Equals("HOD")) Then

            command("select dept_name from tbl_dept_master  where id = " & Convert.ToInt32(Session("forign_id")))
            Session.Add("dept_name", cmd.ExecuteScalar().ToString())

        End If
        If (LoginTypeLabel1.Text.Equals("BE") Or LoginTypeLabel1.Text.Equals("BH")) Then

            command("select branch_name from tbl_branch_master  where id = " & Convert.ToInt32(Session("forign_id")))
            Session.Add("dept_name", cmd.ExecuteScalar().ToString())

        End If



        command("select link from [Software Suite] where Software_Name='" + GridView1.SelectedRow.Cells(1).Text + "' and UseRole='" + LoginTypeLabel1.Text + "'")

        rdr = cmd.ExecuteReader
        If (rdr.HasRows) Then
            If rdr.Read() Then
                Response.Write("<script type='text/javascript'>window.open('" & rdr(0).ToString() + "?UserName=" + LoginLabel1.Text + "&staffname=" + Session("Staff_name").ToString() + "&deptbranch=" + Session("dept_name").ToString() & "','_blank', 'toolbar=no, scrollbars=yes, status=1,resizable=yes, top=0, left=0, width=900, height=700')</script>")

            End If



        End If




    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("Default.aspx")

    End Sub
End Class

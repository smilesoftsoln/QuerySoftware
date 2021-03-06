Imports System.Data.SqlClient
Partial Class admin_add_new_user_stape_2
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
        Dim post As String = Request.QueryString("post_")
        Dim loginerID As Integer = Request.QueryString("loginerID")
        command("sp_get_user_by_id")
        cmd.Parameters.AddWithValue("@uid", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            LBL_INFO.Text = "<span style=""color:red;font-size:16px;""><b> * </b></span>Please select a Desegnation For User <b> " & rdr("username_") & " (" & rdr("name_") & ") " & " </b><br><br>"
        End If


       

        If post = "DE" Then
            pnl_DE.Visible = True
            If Not Page.IsPostBack Then
                cbo_depts.Items.Add("")
                command("sp_get_depts")
                rdr = cmd.ExecuteReader
                While rdr.Read
                    cbo_depts.Items.Add(rdr("dept_name"))
                End While
            End If
        End If

        If post = "HOD" Then
            pnl_HOD.Visible = True
            If Not Page.IsPostBack Then
                cbo_depts_1_hod.Items.Add("")
                command("sp_get_depts")
                rdr = cmd.ExecuteReader
                While rdr.Read
                    cbo_depts_1_hod.Items.Add(rdr("dept_name"))
                End While
            End If
        End If

        If post = "MNGT" Then
            pnl_mng.Visible = True
            If Not Page.IsPostBack Then
                cbo_mngs.Items.Add("")
                command("sp_get_managements")
                rdr = cmd.ExecuteReader
                While rdr.Read
                    cbo_mngs.Items.Add(rdr("mngt_name"))
                End While
            End If
        End If
    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        Dim branch_id As Integer = 0
        Dim loginer_id As Integer = Request.QueryString("loginerID")
        command("sp_get_branch_by_name")
        cmd.Parameters.AddWithValue("@branch_name", cbo_branch.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            branch_id = rdr("id")
        End If

        command("sp_insert_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery() Then
            MsgBox("Done ")
        End If

        command("sp_update_tbl_loginer_stape_to")
        cmd.Parameters.AddWithValue("@forign_id", branch_id)
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery Then
            

            Response.Redirect("msg.aspx?msg=User Created Successfully !<br><Br><a href=""add_new_user.aspx"">Add Another User</a> ")

        End If

    End Sub

    Protected Sub btn_dept_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_dept_submit.Click
        Dim Dept_id As Integer = 0
        Dim loginer_id As Integer = Request.QueryString("loginerID")
        command("sp_get_dept_by_name")
        cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Dept_id = rdr("id")
        End If

        command("sp_insert_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery() Then
            MsgBox("Done ")
        End If


        command("sp_update_tbl_loginer_stape_to")
        cmd.Parameters.AddWithValue("@forign_id", Dept_id)
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery Then
           
            Response.Redirect("msg.aspx?msg=User Created Successfully !")

        End If
    End Sub

    Protected Sub btn_sub_hod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_sub_hod.Click
        Dim Dept_id As Integer = 0
        Dim loginer_id As Integer = Request.QueryString("loginerID")
        command("sp_get_dept_by_name")
        cmd.Parameters.AddWithValue("@dept_name", cbo_depts_1_hod.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Dept_id = rdr("id")
        End If

        command("sp_insert_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery() Then
            MsgBox("Done ")
        End If


        command("sp_update_tbl_loginer_stape_to")
        cmd.Parameters.AddWithValue("@forign_id", Dept_id)
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery Then
            command("sp_update_hod_loginer_id_by_dept_is")
            cmd.Parameters.AddWithValue("@dept_id", Dept_id)
            cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("msg.aspx?msg=User Created Successfully !")
            End If

        End If
    End Sub

    Protected Sub cbo_depts_1_hod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_depts_1_hod.SelectedIndexChanged
        Dim hod_loginer_id As Integer
        Dim loginer_id As Integer = Request.QueryString("loginerID")

        command("sp_insert_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery() Then
            MsgBox("Done ")
        End If


        command("sp_chk_dept_hod_by_dept_name")
        cmd.Parameters.AddWithValue("@dept_name", cbo_depts_1_hod.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            If rdr("hod_loginer_id") = 0 Then
                btn_sub_hod.Visible = True
            Else
                Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('HOD for Selected Department Already Exist !')</script>")
                btn_sub_hod.Visible = False
            End If

        End If
    End Sub

    Protected Sub cbo_mngs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_mngs.SelectedIndexChanged
        Dim mng_loginer_id As Integer

        Dim loginer_id As Integer = Request.QueryString("loginerID")

       

        command("sp_get_managements_by_mng_name")
        cmd.Parameters.AddWithValue("@mng_name", cbo_mngs.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            If rdr("manager_loginer_id") = 0 Then
                btn_sub_mng.Visible = True
            Else
                Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Manager for Selected Department Already Exist \nPlease use Add New User Option For Creating New Manager !')</script>")
                btn_sub_mng.Visible = False

            End If
        End If

        command("sp_insert_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery() Then
            MsgBox("Done ")
        End If
    End Sub

    Protected Sub btn_sub_mng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_sub_mng.Click
        Dim mng_id As Integer = 0
        Dim loginer_id As Integer = Request.QueryString("loginerID")
        command("sp_get_management_by_name")
        cmd.Parameters.AddWithValue("@mng_name", cbo_mngs.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            mng_id = rdr("id")
        End If

        command("sp_update_tbl_loginer_stape_to")
        cmd.Parameters.AddWithValue("@forign_id", mng_id)
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery Then
            command("sp_update_manager_loginer_id")
            cmd.Parameters.AddWithValue("@id", mng_id)
            cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("msg.aspx?msg=User Updated Successfully !")
            End If

        End If

        command("sp_insert_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_id)
        If cmd.ExecuteNonQuery() Then
            MsgBox("Done ")
        End If
    End Sub
End Class

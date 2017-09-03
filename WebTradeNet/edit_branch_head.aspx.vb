Imports System.Data.SqlClient
Partial Class edit_branch_head
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
        cbo_user.Items.Add("")
        If Not Page.IsPostBack Then
            command("sp_get_loginers_by_whi_is")
            cmd.Parameters.AddWithValue("@wis", "BH")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_user.Items.Add(rdr("username_"))
            End While
        End If
    End Sub
    Protected Sub cbo_user_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_user.SelectedIndexChanged
        Dim forign_id As Integer
        pnl_edit_info.Visible = True
        cbo_user.Visible = False
        lbl_user.Visible = True
        lbl_user.Text = cbo_user.SelectedValue
        '====getting info from loginer master
        command("sp_get_branches")
        rdr = cmd.ExecuteReader
        cbo_branchs.Items.Add("")
        While rdr.Read
            cbo_branchs.Items.Add(rdr("branchName"))
        End While


        command("sp_get_info_by_username")
        cmd.Parameters.AddWithValue("@username", lbl_user.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_f_name.Text = rdr("display_name")
            txt_username.Text = rdr("username_")
            forign_id = rdr("forign_id")
            txt_pass.Text = rdr("password_")
            lbl_uName.Text = rdr("username_")
        End If
        '============================

        '==== getting info fro user master ====
        command("sp_get_user_id_by_loginer_forign_id")

        cmd.Parameters.AddWithValue("@forign_id", forign_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            txt_phone.Text = rdr("phone_number")
            txt_email.Text = rdr("e_mail_id")
            cbo_branchs.SelectedValue = rdr("branch_name")
        End If
        '================================

    End Sub

    Protected Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cancel.Click
        Response.Redirect("edit_branch_employee.aspx")
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_ok.Click
        Dim forign_id As Integer
        '===getting forign kek====
        command("sp_get_info_by_username")
        cmd.Parameters.AddWithValue("@username", lbl_user.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            forign_id = rdr("forign_id")
        End If
        '==============

        command("sp_update_loginer_by_username")
        cmd.Parameters.AddWithValue("@username", lbl_user.Text)
        cmd.Parameters.AddWithValue("@disp_name", txt_f_name.Text)
        cmd.Parameters.AddWithValue("@password_", txt_pass.Text)
        If cmd.ExecuteNonQuery Then
            command("sp_update_user_by_forign_id")
            cmd.Parameters.AddWithValue("@fid", forign_id)
            cmd.Parameters.AddWithValue("@phone_num", txt_phone.Text)
            cmd.Parameters.AddWithValue("@emel", txt_email.Text)
            If cmd.ExecuteNonQuery Then
                Response.Redirect("edit_branch_employee.aspx")
            End If


        End If
    End Sub
End Class

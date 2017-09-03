Imports System.Data.SqlClient
Partial Class user_info
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l_id As Integer = Request.QueryString("lid")
        Dim this_des As String
        Dim f_id As Integer
        command("sp_get_user_info")
        cmd.Parameters.AddWithValue("@uid", l_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            this_des = rdr("who_is")
            lbl_Designation.Text = rdr("who_is")
            lbl_name.Text = rdr("display_name")
            lbl_username.Text = rdr("username_")
            lbl_l_id.Text = rdr("id")
            f_id = rdr("forign_id")
        End If

        If this_des = "DE" Then
            Dim dept_id As Integer
            command("sp_get_dept_emp_by_id")
            cmd.Parameters.AddWithValue("@id", f_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_j_date.Text = rdr("joining_date")
                lbl_email_ud.Text = "<a href=""mailto:" & rdr("e_mel") & " "" >" & rdr("e_mel") & "</a>"
                dept_id = rdr("dept_id")
            End If

            command("sp_get_dept_by_id")
            cmd.Parameters.AddWithValue("@id", dept_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_desc.Text = "<b>" & rdr("dept_name") & "</b><br>(" & rdr("dept_desc") & ")"
            End If
        ElseIf this_des = "BE" Then
            Dim branch_id As Integer
            command("sp_get_user_id_by_loginer_forign_id")
            cmd.Parameters.AddWithValue("@forign_id", f_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_j_date.Text = "Not Include"
                lbl_email_ud.Text = "<a href=""mailto:" & rdr("e_mail_id") & " "" >" & rdr("e_mail_id") & "</a>"
                lbl_desc.Text = "<b>" & rdr("branch_name") & "</b>"
            End If
        ElseIf this_des = "HOD" Then
            Dim dept_id As Integer
            command("sp_get_hod_by_id")
            cmd.Parameters.AddWithValue("@f_id", f_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_j_date.Text = rdr("joining_date")
                lbl_email_ud.Text = "<a href=""mailto:" & rdr("email_id") & " "" >" & rdr("email_id") & "</a>"
                dept_id = rdr("dept_id")
            End If

            command("sp_get_dept_by_id")
            cmd.Parameters.AddWithValue("@id", dept_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_desc.Text = "<b>" & rdr("dept_name") & "</b><br>(" & rdr("dept_desc") & ")"
            End If
        ElseIf this_des = "BH" Then
            Dim branch_id As Integer
            command("sp_get_user_id_by_loginer_forign_id")
            cmd.Parameters.AddWithValue("@forign_id", f_id)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_j_date.Text = "Not Include"
                lbl_email_ud.Text = "<a href=""mailto:" & rdr("e_mail_id") & " "" >" & rdr("e_mail_id") & "</a>"
                lbl_desc.Text = "<b>" & rdr("branch_name") & "</b>"
            End If
        End If
    End Sub

End Class

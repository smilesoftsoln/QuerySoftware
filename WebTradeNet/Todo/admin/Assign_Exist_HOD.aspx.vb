Imports System.Data.SqlClient
Partial Class admin_Assign_Exist_HOD
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
        Dim strim As String = ""
        command("sp_get_hod_less_depts")
        rdr = cmd.ExecuteReader
        cbo_depts.Items.Add("")
        While rdr.Read
            cbo_depts.Items.Add(rdr("dept_name"))
        End While

        command("sp_get_hods")
        rdr = cmd.ExecuteReader
        cbo_hods.Items.Add("")
        While rdr.Read
            cbo_hods.Items.Add(rdr("username_"))
        End While

    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        Dim slelected_dept_id As Integer
        Dim selected_hod_id As Integer

        command("sp_get_dept_id_by_dept_name")
        cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            slelected_dept_id = rdr("id")
        End If

        command("sp_get_loginer_by_username")
        cmd.Parameters.AddWithValue("@username_", cbo_hods.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            selected_hod_id = rdr("id")
        End If

        command("sp_set_hod_to_dept")
        cmd.Parameters.AddWithValue("@dept_id", slelected_dept_id)
        cmd.Parameters.AddWithValue("@hod_loginer_id", selected_hod_id)
        If cmd.ExecuteNonQuery Then
            Response.Redirect("msg.aspx?msg=Operation Submited Successfully !")
        End If
    End Sub
End Class

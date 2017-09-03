Imports System.Data.SqlClient
Partial Class admin_add_new_dept
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

    Protected Sub txt_dept_name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dept_name.TextChanged
        command("sp_dept_available_or_not")
        cmd.Parameters.AddWithValue("@dept_name", txt_dept_name.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Department Name Already Exits \nPlease Mantion Diffrent Department Name !')</script>")
            txt_dept_name.Text = ""
            txt_dept_name.Focus()
        Else
            txt_dept_name.Text = txt_dept_name.Text.ToUpper()
            txt_dept_desc.Focus()
        End If
    End Sub

    Protected Sub btn_dept_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_dept_submit.Click
        Dim mng_id As Integer
        command("sp_get_managements_by_name")
        cmd.Parameters.AddWithValue("@mngt_name", cbo_manage.SelectedValue)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            mng_id = rdr("id")
        End If

        command("sp_insert_dept")
        cmd.Parameters.AddWithValue("@dept_name", txt_dept_name.Text)
        cmd.Parameters.AddWithValue("@dept_desc", txt_dept_desc.Text)
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        If cmd.ExecuteNonQuery Then
            Response.Redirect("msg.aspx?msg=New Department Created Successfully !")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            command("sp_get_managements")
            rdr = cmd.ExecuteReader
            cbo_manage.Items.Add("")
            While rdr.Read
                cbo_manage.Items.Add(rdr("mngt_name"))
            End While
        End If
        
    End Sub
End Class


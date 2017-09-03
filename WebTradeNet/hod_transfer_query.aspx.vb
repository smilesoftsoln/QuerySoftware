Imports System.Data.SqlClient
Partial Class hod_transfer_query
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
        Dim tid As Integer = Request.QueryString("tid")
        Dim dept_emp_id As Integer 
        Dim count_all_emp As Integer = 0
        Dim i As Integer = 0
        Dim to_dept_id As Integer

        command("sp_get_ticket_by_t_id")
        cmd.Parameters.AddWithValue("@t_id", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_ticket_t_sub.Text = rdr("t_sub")
            lbl_tick_id.Text = rdr("disp_id")
            dept_emp_id = rdr("Pro_to_emp_id")
            to_dept_id = rdr("to_dept_id")
        End If
        command("sp_get_dept_emp_by_id")
        cmd.Parameters.AddWithValue("@id", dept_emp_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_current.Text = rdr("username_")
        End If

        command("sp_get_emp_by_dept")
        cmd.Parameters.AddWithValue("@dept_id", to_dept_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            count_all_emp = count_all_emp + 1
        End While
        Dim username_(count_all_emp + 1) As String
        Dim loginerids(count_all_emp + 1) As Integer
        Dim forugh_id(count_all_emp + 1) As Integer
        Dim disp_name(count_all_emp + 1) As String
        Dim insert_cbo(count_all_emp + 1) As String
        i = 0

        command("sp_get_emp_by_dept")
        cmd.Parameters.AddWithValue("@dept_id", to_dept_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            forugh_id(i) = rdr("id")
            loginerids(i) = rdr("id")
            username_(i) = rdr("username_")
            disp_name(i) = rdr("name_")
            insert_cbo(i) = loginerids(i) & " (" & disp_name(i) & ")"
            i = i + 1
        End While
        i = 0


        'Commented by Sanjay - Wrong Logic used
        'While i < count_all_emp
        'command("sp_get_DE_loginer_ids_by_forign_ids")
        'cmd.Parameters.AddWithValue("@f_id", forugh_id(i))
        'rdr = cmd.ExecuteReader
        'If rdr.Read Then
        'loginerids(i) = rdr("id")
        'username_(i) = rdr("username_")
        'disp_name(i) = rdr("display_name")
        'End If
        'i = i + 1
        'End While
        'i = 0

        'While i < count_all_emp
        'insert_cbo(i) = loginerids(i) & " (" & disp_name(i) & ")"
        'i = i + 1
        'End While
        i = 0

        If Not Page.IsPostBack Then
            '            cbo_em_list.Items.Add("")
            While i < count_all_emp
                cbo_em_list.Items.Add(username_(i))
                cbo_em_list.Items(i).Value = loginerids(i)
                'cbo_em_list.Items.Add(loginerids(i))
                i = i + 1
            End While
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim now_to_luname As String = cbo_em_list.SelectedItem.Text
        Dim now_to_l_id As Integer = cbo_em_list.SelectedValue

        '        command("sp_get_dept_emp_id_by_username")
        '       cmd.Parameters.AddWithValue("@uname", now_to_luname)
        '      rdr = cmd.ExecuteReader
        '     If rdr.Read Then
        '        now_to_l_id = rdr("id")
        '       End If



        '        Dim forign_id As Integer
        Dim disp_id As Double = Double.Parse(lbl_tick_id.Text)
        Dim tid As Integer = Request.QueryString("tid")

        '        command("sp_get_forign_id_by_loginer_id")
        '        cmd.Parameters.AddWithValue("@loginer_id", now_to_l_id)
        '        rdr = cmd.ExecuteReader
        '        If rdr.Read Then
        '        forign_id = rdr("forign_id")
        '       End If

        command("sp_update_reciver_by_tid")
        cmd.Parameters.AddWithValue("@tid", tid)
        cmd.Parameters.AddWithValue("@new_recv_id", now_to_l_id)
        If cmd.ExecuteNonQuery Then
            Response.Redirect("message.aspx?this_msg=Ticket Transferred successfully&TnCAREeisgrate.html")
        End If

    End Sub
End Class

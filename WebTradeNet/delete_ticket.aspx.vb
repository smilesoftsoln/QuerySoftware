Imports System.Data.SqlClient
Imports System.IO
Partial Class delete_ticket
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''================
        Dim loginerTYP As String = Session.Item("loginerTYP")
        Dim disp_hom_link As String = ""
        Dim now_hand_in As String
        Dim pro_to As Integer
        Dim simp_link As String
        If loginerTYP = "ADMIN" Then
            disp_hom_link = "<a href=""main_admin_login_Next.aspx"">Home</a>"
            simp_link = "main_admin_login_Next.aspx"
        ElseIf loginerTYP = "HOD" Then
            disp_hom_link = "<a href=""hod_login_Next.aspx"">Home</a>"
            simp_link = "hod_login_Next.aspx"
        ElseIf loginerTYP = "DE" Then
            disp_hom_link = "<a href=""employee_login_next.aspx"">Home</a>"
            simp_link = "employee_login_next.aspx"
        ElseIf loginerTYP = "BH" Then
            disp_hom_link = "<a href=""User_login_next.aspx.aspx"">Home</a>"
        Else
            disp_hom_link = "<a href=""Default.aspx"">Home</a>"
            simp_link = "Default.aspx"
        End If
        ''=============
        'Dim tid As Integer = Request.QueryString("tid")
        'Dim postid As Integer
        'Dim counter As Integer = 0
        'Dim i As Integer = 0

        'command("sp_get_post_by_ticket")
        'cmd.Parameters.AddWithValue("@tid", tid)
        'rdr = cmd.ExecuteReader
        'If rdr.Read Then
        '    counter = counter + 1
        '    'postid = rdr("tp_id")
        'End If

        'Dim posts(counter + 1) As Integer

        'If counter <= 0 Then
        '    command("sp_transfer_single_ticket")
        '    cmd.Parameters.AddWithValue("@ticket_id", tid)
        '    If cmd.ExecuteNonQuery Then
        '        Response.Redirect(simp_link)
        '    End If
        'Else
        '    command("sp_get_post_by_ticket")
        '    cmd.Parameters.AddWithValue("@tid", tid)
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        posts(i) = rdr("tp_id")
        '        i = i + 1
        '    End If
        '    i = 0
        '    While i <= counter
        '        command("sp_transfer_single_posts")
        '        cmd.Parameters.AddWithValue("@tp_id", posts(i))
        '        cmd.Parameters.AddWithValue("@ticket_id", tid)
        '        If cmd.ExecuteNonQuery Then
        '        End If
        '        i = i + 1
        '    End While
        '    command("sp_transfer_single_ticket")
        '    cmd.Parameters.AddWithValue("@ticket_id", tid)
        '    If cmd.ExecuteNonQuery Then
        '        Response.Redirect(simp_link)
        '    End If
        'End If
        '===================


        'Dim tid As Integer = Request.QueryString("tid")
        'command("sp_change_tick_by_typ")
        'cmd.Parameters.AddWithValue("@tid", tid)
        'If cmd.ExecuteNonQuery Then
        '    Response.Redirect(simp_link)
        'Else
        '    Label1.Visible = True
        '    Label1.Text = "This Ticket Is already Running !<br> This Ticket Cant Deleted !"
        'End If

    End Sub

    Protected Sub Btn_ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_ok.Click
        Panel1.Visible = False
        ''================
        Dim loginerTYP As String = Session.Item("loginerTYP")
        Dim disp_hom_link As String = ""
        Dim now_hand_in As String
        Dim pro_to As Integer
        Dim simp_link As String
        If loginerTYP = "ADMIN" Then
            disp_hom_link = "<a href=""main_admin_login_Next.aspx"">Home</a>"
            simp_link = "main_admin_login_Next.aspx"
        ElseIf loginerTYP = "HOD" Then
            disp_hom_link = "<a href=""hod_login_Next.aspx"">Home</a>"
            simp_link = "hod_view_all_ticks.aspx"
        ElseIf loginerTYP = "DE" Then
            disp_hom_link = "<a href=""employee_login_next.aspx"">Home</a>"
            simp_link = "employee_login_next.aspx"
        ElseIf loginerTYP = "MNG" Then
            disp_hom_link = "<a href=""mng_view_all_ticks.aspx"">Home</a>"
            simp_link = "mng_view_all_ticks.aspx"
        ElseIf loginerTYP = "BH" Then
            disp_hom_link = "<a href=""User_login_next.aspx.aspx"">Home</a>"
            simp_link = "bh_view_all_ticks.aspx"
        Else
            disp_hom_link = "<a href=""Default.aspx"">Home</a>"
            simp_link = "Default.aspx"
        End If
        ''=============
        'Dim tid As Integer = Request.QueryString("tid")
        'Dim postid As Integer
        'Dim counter As Integer = 0
        'Dim i As Integer = 0

        'command("sp_get_post_by_ticket")
        'cmd.Parameters.AddWithValue("@tid", tid)
        'rdr = cmd.ExecuteReader
        'If rdr.Read Then
        '    counter = counter + 1
        '    'postid = rdr("tp_id")
        'End If

        'Dim posts(counter + 1) As Integer

        'If counter <= 0 Then
        '    command("sp_transfer_single_ticket")
        '    cmd.Parameters.AddWithValue("@ticket_id", tid)
        '    If cmd.ExecuteNonQuery Then
        '        Response.Redirect(simp_link)
        '    End If
        'Else
        '    command("sp_get_post_by_ticket")
        '    cmd.Parameters.AddWithValue("@tid", tid)
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        posts(i) = rdr("tp_id")
        '        i = i + 1
        '    End If
        '    i = 0
        '    While i <= counter
        '        command("sp_transfer_single_posts")
        '        cmd.Parameters.AddWithValue("@tp_id", posts(i))
        '        cmd.Parameters.AddWithValue("@ticket_id", tid)
        '        If cmd.ExecuteNonQuery Then
        '        End If
        '        i = i + 1
        '    End While
        '    command("sp_transfer_single_ticket")
        '    cmd.Parameters.AddWithValue("@ticket_id", tid)
        '    If cmd.ExecuteNonQuery Then
        '        Response.Redirect(simp_link)
        '    End If
        'End If
        '===================


        Dim tid As Integer = Request.QueryString("tid")
        command("sp_change_tick_by_typ")
        cmd.Parameters.AddWithValue("@tid", tid)
        If cmd.ExecuteNonQuery Then
            Response.Redirect(simp_link)
        Else
            Label1.Visible = True
            Label1.Text = "This Ticket Is already Running !<br> This Ticket Cant Deleted !"
        End If
    End Sub

    Protected Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        ''================
        Dim loginerTYP As String = Session.Item("loginerTYP")
        Dim disp_hom_link As String = ""
        Dim now_hand_in As String
        Dim pro_to As Integer
        Dim simp_link As String
        If loginerTYP = "ADMIN" Then
            disp_hom_link = "<a href=""main_admin_login_Next.aspx"">Home</a>"
            simp_link = "main_admin_login_Next.aspx"
        ElseIf loginerTYP = "HOD" Then
            disp_hom_link = "<a href=""hod_login_Next.aspx"">Home</a>"
            simp_link = "hod_login_Next.aspx"
        ElseIf loginerTYP = "DE" Then
            disp_hom_link = "<a href=""employee_login_next.aspx"">Home</a>"
            simp_link = "employee_login_next.aspx"
        Else
            disp_hom_link = "<a href=""Default.aspx"">Home</a>"
            simp_link = "Default.aspx"
        End If
        ''=============
        Response.Redirect(simp_link)
    End Sub
End Class

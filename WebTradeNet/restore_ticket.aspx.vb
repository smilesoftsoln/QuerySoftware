Imports System.Data.SqlClient
Imports System.IO
Partial Class restore_ticket
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

        Dim tid As Integer = Request.QueryString("tid")
        command("sp_restore_ticket")
        cmd.Parameters.AddWithValue("@tid", tid)
        If cmd.ExecuteNonQuery Then
            Response.Redirect(simp_link)
        End If

    End Sub
End Class

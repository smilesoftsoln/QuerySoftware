Imports System.Data.SqlClient
Partial Class User_login_next
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader
    Dim loginerTTYP As String

    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Sub command2(ByVal strcmd As String)
        cmd2.CommandType = Data.CommandType.Text
        cmd2.CommandText = strcmd
        cmd2.Connection = weldone_con.ConObj
        cmd2.Parameters.Clear()
    End Sub

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim username As String = Request.QueryString("UserName")
        ' LoginLabel1.Text = username
        If String.IsNullOrEmpty(username) Then
        Else
            Session("login") = username
        End If


        Try
            If Request.Cookies("admin")("login") = "false" Then
                Response.Redirect("branch/")
            End If
        Catch ex As Exception
            Response.Redirect("branch/")
        End Try
        loginerID = Session.Item("loginerID")
        Dim strim As String = ""

        '========get element by loginerID=====
        loginerTTYP = Session.Item("loginerTYP")
        If loginerTTYP = "BH" Then
            pnl_for_BH.Visible = True
        End If
        If loginerTTYP = "BH" Then
            TaskMasterLinkButton1.Attributes("href") = "Todo/branchhead_login_next.aspx"

        Else
            TaskMasterLinkButton1.Attributes("href") = "Todo/be_login_next.aspx"

        End If
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()
        '===========

        command("sp_get_loginer_and_branch_details_join")
        cmd.Parameters.AddWithValue("@id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_Emp_name.Text = rdr("name_")
            lbl_uname_1.Text = rdr("name_")
            lbl_uname.Text = rdr("username_")
            lbl_emp_typ.Text = rdr("post_")
            Session.Add("ThisBranch", rdr("branch_name"))
            lbl_branch_det.Text = rdr("branch_name")
            lbl_uname_1.Text = rdr("name_")
            Page.Title = "TradeNet  :- " & rdr("name_")
        End If

        lbl_last_login.Text = Session.Item("last_login")
        '=====================================
        strim = ""
        command("sp_get_unsolved_tickets_to_be")
        cmd.Parameters.AddWithValue("@id", loginerID)
        rdr = cmd.ExecuteReader
        strim &= "<div class=""updater_mid"">"
        strim &= "<table width=""100%"">"
        strim &= "<tr class=""updater_mid_tr_spl"">"
        strim &= "<td>"
        strim &= "Ticket ID"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "Subject"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "To Dept"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "Date"
        strim &= "</td>"
        strim &= "</tr>"
        While rdr.Read
            strim &= "<tr >"
            strim &= "<td width=""20%"">"
            strim &= rdr("disp_id")
            strim &= "</td>"
            strim &= "<td width=""40%"">"
            strim &= "<a href=""view_ticket.aspx?tid=" & rdr("id") & "&TnCAREeisgrate.html "">"
            strim &= rdr("t_sub")
            strim &= "</a>"
            strim &= "</td>"
            strim &= "<td width=""20%"">"
            strim &= rdr("dept_name")
            strim &= "</td>"
            strim &= "<td width=""20%"">"
            strim &= rdr("last_update_date")
            strim &= "</td>"
            strim &= "</tr>"
        End While
        strim &= "</table>"
        strim &= "<div class=""em_p_lnks"">"
        strim &= "    </div>	"
        disp_ticketd.InnerHtml = strim
        ''===========disp solved tickets
        strim = ""
        command("sp_get_solved_tickets_to_be")
        cmd.Parameters.AddWithValue("@id", loginerID)
        rdr = cmd.ExecuteReader
        strim &= "<div class=""updater_mid"">"
        strim &= "<table width=""100%"">"
        strim &= "<tr class=""updater_mid_tr_spl"">"
        strim &= "<td>"
        strim &= "Ticket ID"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "Subject"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "To Dept"
        strim &= "</td>"
        strim &= "<td>"
        strim &= "Date"
        strim &= "</td>"
        strim &= "</tr>"
        While rdr.Read
            strim &= "<tr >"
            strim &= "<td width=""20%"">"
            strim &= rdr("disp_id")
            strim &= "</td>"
            strim &= "<td width=""40%"">"
            strim &= "<a href=""view_ticket.aspx?tid=" & rdr("id") & "&TnCAREeisgrate.html "">"
            strim &= rdr("t_sub")
            strim &= "</a>"
            strim &= "</td>"
            strim &= "<td width=""20%"">"
            strim &= rdr("dept_name")
            strim &= "</td>"
            strim &= "<td width=""20%"">"
            strim &= rdr("last_update_date")
            strim &= "</td>"
            strim &= "</tr>"
        End While
        strim &= "</table>"
        strim &= "<div class=""em_p_lnks"" style=""float:right;clear:right;display:block;"">"
        strim &= "    </div>	"
        strim &= "			</div>"
        disp_solved_ticketd.InnerHtml = strim
    End Sub

    Protected Sub btn_logout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_logout.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()
        '==============

        Response.Cookies("user")("login") = "false"
        'Session.Clear()
        Response.Cookies.Clear()
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub

    'Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    '    Page.RegisterStartupScript("ScriptDescription", "<script type=""text/javascript"">alert('Selected Branch Name Already Available!')</script>")
    '    MsgBox("hi")
    'End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Dim loginer_ID As Integer = Session.Item("loginerID")
    '    '============== login stts
    '    command("sp_updatye_login_stts")
    '    cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
    '    cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
    '    cmd.ExecuteNonQuery()
    '    '==============

    '    Response.Cookies("user")("login") = "false"
    '    ' Session.Clear()
    '    Response.Cookies.Clear()
    '    Response.Redirect("http://114.143.29.128:81/WebTradeNet/BACKUP")
    'End Sub

    'Protected Sub TaskMasterLinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskMasterLinkButton1.Click

    'End Sub
End Class

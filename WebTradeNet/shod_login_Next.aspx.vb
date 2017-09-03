Imports System.Data.SqlClient
Imports System.Data
Partial Class shod_login_Next
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim Obj_Comman As New somman_functions_NM.commen_funcs
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Sub command2(ByVal strcmd As String)
        cmd2.CommandType = Data.CommandType.StoredProcedure
        cmd2.CommandText = strcmd
        cmd2.Connection = weldone_con.ConObj
        cmd2.Parameters.Clear()
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim DeptID As Integer
        ' =====Escalated 
        '  Dim ds As New DataSet

        'Dim da As New SqlDataAdapter
        ' da.SelectCommand = SqlCmd
        'da.Fill(ds)

        'GridView1.DataSource = ds
        ' GridView1.DataBind()

        '============== login stts



        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginerID)
        cmd.Parameters.AddWithValue("@login_stts", "ONLINE")
        cmd.ExecuteNonQuery()
        '==============loginer details feed in top informer=================
        command("sp_get_Shod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_name.Text = "Name  : " & rdr("name_")
            Session.Add("DEPT_ID", rdr("dept_id"))
            lbl_welcome.Text = rdr("name_")

            Page.Title = "TradeNet SHOD: " & rdr("name_")
            username = rdr("username_")
            If username = "CCHOD" Then
                Panel1.Visible = True
            End If
        End If
        Dim chl As Integer = 0
        command("sp_get_shod_depts")
        cmd.Parameters.AddWithValue("@id", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            lbl_dept.Text &= "<b>'" & rdr("dept_name") & "'</b>, "
            DeptID = rdr("id")
            chl = chl + 1
        End While
        If chl >= 2 Then
            Label1.Text = "<b>Super HOD</b>"
        End If
        lbl_now.Text = Now()
        command("sp_get_shod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While
        Dim dept_id_(tot_arr + 1) As Integer
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim cbname As String
        command("sp_get_shod_details")
        cmd.Parameters.AddWithValue("@loginerid", loginerID)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            i = i + 1
        End While



        i = 0
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:6%"">"
        strim &= "Ticket ID"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:32%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "From"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "To"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "	                Date"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "	                Delete?"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= " -"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        command("sp_get_ticketsby_dept_id_shod")
        rdr = cmd.ExecuteReader
        While rdr.Read
            If Array.IndexOf(dept_id_, rdr("to_dept_id")) > -1 Then
                strim &= "	        <tr >"
                strim &= "	            <td >"
                strim &= rdr("disp_id")
                strim &= "	            </td>"
                strim &= "	            <td class=""date_ticks"">"
                strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= rdr("branch_name") & "<br>(" & rdr("auther") & ")"
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= rdr("dept_name") & " (HOD)"
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("t_stts")
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("last_update_date")
                strim &= "	            </td>"
                strim &= "	            <td >"
                cbname = "cb" & Trim(j)
                j = j + 1
                If (rdr("t_stts") = "SOLVED") Then
                    strim &= "<input id=" & cbname & " type=""checkbox"" value=" & rdr("id") & "/>"
                End If
                strim &= "	            </td >"
                strim &= "	            <td >"
                strim &= "<a href=""JavaScript:return false()"" OnClick=""window.open('admin_change_stts.aspx?tid=" & rdr("id") & "&Suraj.php ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')""> <img src=""images/change_stts.jpg"" onMouseover=""showhint('Click Here To Change Status topic " & rdr("t_sub") & " ', this, event, '150px')""/> </a>"
                strim &= "	            </td>"
                strim &= "	        </tr>"
            End If
        End While
        strim &= "	    </table>"
        Disp_unread_ticks.InnerHtml = strim
        strim = ""
        Dim SqlQry As String = "sp_get_escalated _ticketsby_dept_id"
        Dim con As New SqlConnection()
        Dim SqlCmd As New SqlCommand(SqlQry, weldone_con.ConObj)

        SqlCmd.CommandType = Data.CommandType.StoredProcedure
        i = 0
        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:6%"">"
        strim &= "Ticket ID"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:32%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "From"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "To"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "	                Date"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "	                Delete?"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= " -"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        rdr = SqlCmd.ExecuteReader
        While rdr.Read
            If Array.IndexOf(dept_id_, rdr("to_dept_id")) > -1 Then
                strim &= "	        <tr >"
                strim &= "	            <td >"
                strim &= rdr("disp_id")
                strim &= "	            </td>"
                strim &= "	            <td class=""date_ticks"">"
                strim &= "<a href=""Admin_view_ticket.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= rdr("branch_name") & "<br>(" & rdr("auther") & ")"
                strim &= "	            </td>"
                strim &= "	            <td >"
                strim &= rdr("dept_name") & " (HOD)"
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("t_stts")
                strim &= "	            </td>"
                strim &= "	            <td  class=""date_ticks"">"
                strim &= rdr("last_update_date")
                strim &= "	            </td>"
                strim &= "	            <td >"
                cbname = "cb" & Trim(j)
                j = j + 1
                If (rdr("t_stts") = "SOLVED") Then
                    strim &= "<input id=" & cbname & " type=""checkbox"" value=" & rdr("id") & "/>"
                End If
                strim &= "	            </td >"
                strim &= "	            <td >"
                strim &= "<a href=""JavaScript:return false()"" OnClick=""window.open('admin_change_stts.aspx?tid=" & rdr("id") & "&Suraj.php ', 'Note','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes,copyhistory=no,width=490,height=150')""> <img src=""images/change_stts.jpg"" onMouseover=""showhint('Click Here To Change Status topic " & rdr("t_sub") & " ', this, event, '150px')""/> </a>"
                strim &= "	            </td>"
                strim &= "	        </tr>"
            End If
        End While
        strim &= "	    </table>"
        Div3.InnerHtml = strim
        '****************************************


        'i = 0
        'Dim tot_apps As Integer = 0
        'Dim tid As Integer
        'Dim app_id As Integer
        'Dim sst As String = ""
        'Dim totAlerts As Integer = 0
        'sst &= "<div class=""DispNone"" id=""AppRovles""><b>New Approvals</b> <img src=""images/typ_deleted.jpg"" id=""ifClose"" class=""AppClose""><hr/>"
        'While i < tot_arr
        '    command("sp_get_approvals_to_hod")
        '    rdr = cmd.ExecuteReader

        '    While rdr.Read
        '        If dept_id_(i) = rdr("dept_id") Then
        '            tot_apps = tot_apps + 1
        '            tid = rdr("t_id")
        '            app_id = rdr("id")
        '            sst &= "<a href=""new_approval.aspx?t_id=" & tid & "&app_id=" & app_id & """>" & rdr("note_crtr") & "</a>"

        '            Dim QrtDate As DateTime
        '            QrtDate = Convert.ToDateTime(rdr("date"))
        '            Dim today_date As DateTime = System.Convert.ToDateTime(Now())

        '            Dim ts As New TimeSpan()
        '            ts = today_date.Subtract(QrtDate)
        '            Dim minuts As Integer = ts.Minutes
        '            If minuts > 24 Then
        '                alerts.InnerHtml &= "<p>* Ticket id <b>" & rdr("ticketID") & "</b> : Sub :- <b>" & rdr("t_sub") & "</b> is waiting for your approvement !</p>"
        '                totAlerts = totAlerts + 1
        '            End If

        '        End If
        '    End While

        '    i = i + 1

        'End While
        'If totAlerts > 0 Then
        '    msgsSpan.InnerHtml = "<a href=""#"" class=""vista"">(" & totAlerts & ") Messages</a>"
        'Else
        '    msgsSpan.InnerHtml = "<a href=""#"" >(" & totAlerts & ") Messages</a>"
        'End If
        'sst &= "</div>"
        'T_appList.InnerHtml = sst

        'If tot_apps > 0 Then
        '    lbl_tot_apps.Text = "<a href=""JavaScript:Return false()"" id=""ViewAllApps"">(" & tot_apps & ") New Approval(s)</a>"
        'End If

        ''==========infor to cntr
        'strim = ""
        'Dim strim2 As String = ""
        'Dim infrmCntr As Integer = 0
        'command("get_hods_Informs_Count")
        'cmd.Parameters.AddWithValue("@hod_loginer_id", loginerID)
        'rdr = cmd.ExecuteReader
        'strim2 &= "<div class=""DispNone"" id=""DispNone"">"
        'strim2 &= "New Informs <img src=""images/typ_deleted.jpg"" id=""ifClose"">"
        'strim2 &= "<hr>"
        'While rdr.Read
        '    strim2 &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("Ticket_id") & "&TnCAREeisgrate.html"" style=""display:table;"">" & rdr("t_sub") & " (from " & rdr("from_dept_name") & ")</a>"
        '    infrmCntr = infrmCntr + 1
        'End While
        'strim2 &= "</div>"
        'If infrmCntr >= 1 Then
        '    strim = "<a href=""JavaScript:return false()""  id=""ShowSubList""><b>New (" & infrmCntr & ") Informs</b></a>"
        'Else
        '    strim = ""
        'End If

        't_subList.InnerHtml = strim2
        'informToCnt.InnerHtml = strim

        ''==========All Informs
        'strim = ""
        'strim2 = ""
        'infrmCntr = 0
        'command("get_all_hods_Informs_Count")
        'cmd.Parameters.AddWithValue("@hod_loginer_id", loginerID)
        'rdr = cmd.ExecuteReader
        'strim2 &= "<div class=""DispNone"" id=""DispNoneALL"">"
        'strim2 &= "Total Informs <img src=""images/typ_deleted.jpg"" id=""ifClose"" class=""ifClose"">"
        'strim2 &= "<hr>"
        'While rdr.Read
        '    strim2 &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("Ticket_id") & "&TnCAREeisgrate.html"" style=""display:table;"">" & rdr("t_sub") & " (from " & rdr("from_dept_name") & ")</a>"
        '    infrmCntr = infrmCntr + 1
        'End While
        'strim2 &= "</div>"

        'strim = "<a href=""JavaScript:return false()"" id=""ShowSubListALL"">Total (" & infrmCntr & ") Informs</a>"
        't_subListALL.InnerHtml = strim2
        'informToCntALL.InnerHtml = strim

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        '============== login stts
        command("sp_updatye_login_stts")
        cmd.Parameters.AddWithValue("@loginer_id", loginer_ID)
        cmd.Parameters.AddWithValue("@login_stts", "OFFLINE")
        cmd.ExecuteNonQuery()


        Response.Cookies("admin")("login") = "false"
        '  Session.Clear()
        Response.Cookies.Clear()
        Response.Write("<script type='text/javascript'>window.close()</script>")


        'Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("hod_search_tick_by_dept.aspx")
    End Sub

    Protected Sub btn_post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_post.Click
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        ExportIt_HTML("Export", ".xls", Disp_unread_ticks.InnerHtml())
    End Sub
    Public Sub ExportIt_HTML(ByVal Heading As String, ByVal FileExtention As String, ByVal HTMLContent As String)
        'Response.Clear()

        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" & Heading & "_" & Now.Day() & "_" & Now.Month() & "_" & Now.Year() & "." & FileExtention & "")
        System.Web.HttpContext.Current.Response.Charset = ""
        System.Web.HttpContext.Current.Response.ContentType = "application/vnd." & FileExtention & ""
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Me.Controls.Add(frm)
        frm.RenderControl(hw)
        System.Web.HttpContext.Current.Response.Write("<h5>" & Heading & "</h5>")
        System.Web.HttpContext.Current.Response.Write(HTMLContent)
        System.Web.HttpContext.Current.Response.End()
    End Sub

End Class

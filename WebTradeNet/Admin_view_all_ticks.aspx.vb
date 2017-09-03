Imports System.Data.SqlClient
Imports System.Data
Imports projecterNM.projectercon

Partial Class Admin_view_all_ticks
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
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim mng_id As Integer



        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then

            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
            mng_id = rdr("forign_id")
        End If
        Dim chl As Integer = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While

        Dim dept_id_(tot_arr + 1) As Integer
        Dim i As Integer = 0


        If Not Page.IsPostBack Then
            Obj_Comman.FillList(cboSender, "get_senders")
            Obj_Comman.FillList(cbo_brances, "sp_get_branches")
            cbo_depts.Items.Add("ALL")
            command("sp_get_depts")
            rdr = cmd.ExecuteReader
            While rdr.Read
                cbo_depts.Items.Add(rdr("dept_name"))
            End While
        End If
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            i = i + 1
        End While
 
        Dim ds As New DataSet
        Dim SqlQry As String = "sp_get_all_ticks_hod_new"
        Dim con As New SqlConnection()
        Dim SqlCmd As New SqlCommand(SqlQry, weldone_con.ConObj)
        SqlCmd.CommandType = Data.CommandType.StoredProcedure
        Dim da As New SqlDataAdapter
        da.SelectCommand = SqlCmd
        da.Fill(ds)
        '' GridView1.DataSource = ds
        '' GridView1.DataBind()

        
        If Not Page.IsPostBack Then
            
            ''GridView2.DataSource = ds
            ''GridView2.DataBind()
        End If


    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("admin/search_ticket.aspx")
        'panal_post_comm.Visible = True
        'txt_search.Focus()
    End Sub

    Protected Sub viewlinkClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    
    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_go.Click
        BindData()
       
    End Sub
    Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged

        BindData()

    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
    End Sub

    Sub BindData()
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim username As String
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim mng_id As Integer
        Dim this_stts As String
        Dim heading_ As String = ""
        Dim SenderID As String = "%%"
        Dim BranchID As String = "%%"
        Dim typ As String = rdb_opns.SelectedValue
        If typ = "ALL" Then
            typ = "%%"
        End If
        Dim date_from As Date = "11/11/1990"
        Dim date_to As Date = Now
        Dim dept_id As String

        Dim q_typ As String = "%%"
        If cbo_type.SelectedValue = "Normal" Then
            q_typ = "Normal"
            heading_ &= "Normal Tickets"
        ElseIf cbo_type.SelectedValue = "Escalated" Then
            q_typ = "Escalated"
            heading_ &= "Escalated Tickets"
        ElseIf cbo_type.SelectedValue = "Transferred" Then
            q_typ = "Transferred"
            heading_ &= "Transferred Tickets"
        ElseIf cbo_type.SelectedValue = "DELETED" Then
            q_typ = "DELETE"
            heading_ &= "DELETED Tickets"
        ElseIf cbo_type.SelectedValue = "ALL" Then
            heading_ &= "ALL type of Tickets"
        End If

        If cbo_depts.SelectedValue = "ALL" Then
            dept_id = "%%"
            heading_ &= " of All Departments"
        Else
            command("sp_get_dept_id_by_name")
            cmd.Parameters.AddWithValue("@dept_name", cbo_depts.SelectedValue)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                dept_id = rdr("id")
            End If
            heading_ &= " " & cbo_depts.SelectedValue & " Department"
        End If

        If txtdatefrom.Text = "" Or txtdateto.Text = "" Then
        Else
            date_from = txtdatefrom.Text
            date_to = txtdateto.Text & " 23:59:59"
            heading_ &= " Dated " & txtdatefrom.Text & " to " & txtdateto.Text
        End If

        If rdb_opns.SelectedValue = "ALL" Then
            this_stts = "%%"
        ElseIf rdb_opns.SelectedValue = "Solved" Then
            this_stts = "SOLVED"
            heading_ &= " (Solved )"
        ElseIf rdb_opns.SelectedValue = "UnSolved" Then
            this_stts = "UNSOLVED"
            heading_ &= " (UnSolved)"
        ElseIf rdb_opns.SelectedValue = "FOLLOW UP" Then
            this_stts = "FOLLOW UP"
            heading_ &= " (FOLLOW UP)"
        End If


        If cboSender.SelectedValue = "0" Then
            SenderID = "%%"
        Else
            SenderID = cboSender.SelectedValue
        End If

        If cbo_brances.SelectedValue = "0" Then
            BranchID = "%%"
        Else
            BranchID = cbo_brances.SelectedValue
        End If

        heading_ &= " -Till " & Now()

        command("sp_get_user_info_by_loginer_id")
        cmd.Parameters.AddWithValue("@lofiner_id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then

            Page.Title = "TradeNet HOD: " & rdr("name_")
            username = rdr("username_")
            mng_id = rdr("forign_id")
        End If
        Dim chl As Integer = 0
        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_arr = tot_arr + 1
        End While

        Dim dept_id_(tot_arr + 1) As Integer
        Dim i As Integer = 0




        command("sp_get_depts_by_mng_id")
        cmd.Parameters.AddWithValue("@mng_id", mng_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dept_id_(i) = rdr("dept_id")
            i = i + 1
        End While

        Dim this_stts_ As String = this_stts
        Dim dept_id_2 As String = dept_id



        Dim ds As New DataSet

        ds.Clear()

        Dim SqlQry As String = "sp_view_all_queryes"
        ' Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ProjectConnString").ToString)
        Dim SqlCmd As New SqlCommand(SqlQry, weldone_con.ConObj)
        SqlCmd.Parameters.AddWithValue("@t_stts", this_stts)
        SqlCmd.Parameters.AddWithValue("@date_from", date_from)
        SqlCmd.Parameters.AddWithValue("@date_to", date_to)
        SqlCmd.Parameters.AddWithValue("@q_typ", q_typ)
        SqlCmd.Parameters.AddWithValue("@to_dept_id", dept_id)
        SqlCmd.Parameters.AddWithValue("@SenderID", SenderID)
        SqlCmd.Parameters.AddWithValue("@BranchID", BranchID)
        SqlCmd.CommandType = Data.CommandType.StoredProcedure
        Dim da As New SqlDataAdapter
        da.SelectCommand = SqlCmd
        da.Fill(ds)

        GridView1.DataSource = ds
        GridView1.DataBind()

        For Each gr As GridViewRow In GridView1.Rows
            gr.Cells(0).Text = "<a href='hod_view_tixk_nvsbl.aspx?tid=" & gr.Cells(0).Text & "'>view </a>"
        Next

        GridView2.DataSource = ds
        GridView2.DataBind()
    End Sub

    Protected Sub tbn_exp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exp.Click
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim tot_arr As Integer = 0
        Dim strim As String = ""
        Dim this_stts As String
        Dim heading_ As String = ""
        Dim typ As String = rdb_opns.SelectedValue
        If typ = "ALL" Then
            typ = "%%"
        End If
        Dim date_from As Date = "11/11/1990"
        Dim date_to As Date = Now
        Dim dept_id As String

        Dim q_typ As String = "%%"
        If cbo_type.SelectedValue = "Normal" Then
            heading_ &= "Normal Tickets"
        ElseIf cbo_type.SelectedValue = "Escalated" Then
            heading_ &= "Escalated Tickets"
        ElseIf cbo_type.SelectedValue = "Transferred" Then
            heading_ &= "Transferred Tickets"
        ElseIf cbo_type.SelectedValue = "DELETED" Then
            heading_ &= "DELETED Tickets"
        ElseIf cbo_type.SelectedValue = "ALL" Then
            heading_ &= "ALL type of Tickets"
        End If

        If cbo_depts.SelectedValue = "ALL" Then
            heading_ &= " of All Departments"
        Else
            heading_ &= " " & cbo_depts.SelectedValue & " Department"
        End If

        If txtdatefrom.Text = "" Or txtdateto.Text = "" Then
        Else
            heading_ &= " Dated " & txtdatefrom.Text & " to " & txtdateto.Text
        End If

        If rdb_opns.SelectedValue = "ALL" Then
        ElseIf rdb_opns.SelectedValue = "Solved" Then
            heading_ &= " (Solved )"
        ElseIf rdb_opns.SelectedValue = "UnSolved" Then
            heading_ &= " (UnSolved)"
        ElseIf rdb_opns.SelectedValue = "FOLLOW UP" Then
            heading_ &= " (FOLLOW UP)"
        End If

        heading_ &= " -Till " & Now()



        Response.Clear()
        'Response.AddHeader("content-disposition", "attachment;filename=Auto_" & Now.Day() & "_" & Now.Month() & "_" & Now.Year() & ".xls")
        'Response.Charset = ""
        'Response.ContentType = "application/vnd.xls"
        'Dim stringWrite As New System.IO.StringWriter()
        'Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        'GridView2.RenderControl(htmlWrite)
        'Response.Write("<h5>" & heading_ & "</h5>")
        'Response.Write(stringWrite.ToString)
        'Dim sd As String = stringWrite.ToString
        'Response.End()
        Dim sw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()

        Page.Response.AddHeader("content-disposition", "attachment;filename=Auto_" & Now.Day() & "_" & Now.Month() & "_" & Now.Year() & ".xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        Controls.Add(frm)
        frm.Controls.Add(GridView2)
        frm.RenderControl(hw)
        Response.Write(sw.ToString())
        Response.End()

    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Response.Redirect("Admin_view_all_ticks.aspx")
    End Sub
   
    Protected Sub cbo_brances_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_brances.SelectedIndexChanged
        cboSender.Items.Clear()
        'Obj_Comman.FillList(cboSender, "get_BEH_by_branchID")
        Dim fld As Integer = 0
        Dim i As Integer = 0
        Dim j As Integer
        command("get_BEH_by_branchID")
        If cbo_brances.SelectedValue = "0" Then
            cmd.Parameters.AddWithValue("@branchID", "%%")
        Else
            cmd.Parameters.AddWithValue("@branchID", cbo_brances.SelectedValue)
        End If
        cboSender.Items.Add(New ListItem("Select", "0"))
        rdr = cmd.ExecuteReader
        While rdr.Read
            If fld <> 0 Then
                'inavaDa
                cboSender.Items.Add(New ListItem(rdr(fld), rdr(0)))
            Else
                cboSender.Items.Add(New ListItem(rdr(1), rdr(0)))
            End If

            If i <> 0 Then
                If rdr(0) = i Then
                    cboSender.Items(j + 1).Selected = True
                End If
            End If
            j += 1
        End While
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub cal_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cal.SelectionChanged
        txtdatefrom.Text = cal.SelectedDate
        divcal1.Visible = False
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        divcal1.Visible = True
        cal.Visible = True
        Calendar1.Visible = False

    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        txtdateto.Text = Calendar1.SelectedDate
        divcal1.Visible = False
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        divcal1.Visible = True
        cal.Visible = False
        Calendar1.Visible = True
    End Sub
End Class

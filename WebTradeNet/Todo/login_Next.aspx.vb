Imports System.Data.SqlClient
Imports System.Data

Partial Class login_Next
    Inherits System.Web.UI.Page
    Dim probj As New projecterNM.projectercon
    Dim sqlQuery As String = ""
    Dim emps As SqlDataReader
    Dim nbr_of_items As Integer = 0
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader
    'Dim loginerType As String = Session.Item("loginerTYP")

    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Sub command2(ByVal strcmd As String)
        cmd2.CommandType = Data.CommandType.StoredProcedure
        cmd2.CommandText = strcmd
        cmd2.Connection = weldone_con.ConObj
        cmd2.Parameters.Clear()
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim loginerType As String = Session.Item("loginerTYP")
        Dim loginTypes As ArrayList = New ArrayList()
        loginTypes.Add("DE")
        loginTypes.Add("BE")
        loginTypes.Add("BH")
        loginTypes.Add("HOD")
        loginTypes.Add("SRMNG")
        loginTypes.Add("SRBM")
        loginTypes.Add("MNG")

        If loginTypes.Contains(loginerType) = False Then
            Response.Redirect("unauthorisedaccess.aspx")
        End If
        Dim sql As String = ""
        'Change Open to Overdue if less than today
        If loginerType = "ADMIN" Then
            sql = "update tbl_todo_details set statusid=3 where statusid=1 and DATEDIFF(day, GETDATE(), enddatetime) < 0"
        Else
            sql = "update tbl_tasks set statusid=3 where statusid=1 and DATEDIFF(day, GETDATE(), enddatetime) < 0"
        End If
        Dim success As Int16 = probj.InsertRecord(Sql)

        lbl_date.Text = System.DateTime.Now
        lbl_id.Visible = False
        lbl_id.Text = loginerID
        'SqlDataSource1.DataBind()
        If loginerType = "MNG" Then
            PlaceHolder1.Controls.Add(GridView1)

        Else
            PlaceHolder1.Controls.Add(GridView2)
            GridView1.Visible = False
        End If
        'GridView1.Visible = False

        command("sp_get_loginer_details")
        cmd.Parameters.AddWithValue("@id", loginerID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbl_name.Text = "Name  : " & rdr("name_")
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim taskid As Integer = Convert.ToInt16(GridView1.SelectedDataKey.Value.ToString)
        Session.Add("taskid", taskid)
        Session.Add("querytype", "task")
        Response.Redirect("view_full_todo.aspx")
    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        Dim taskid As Integer = Convert.ToInt16(GridView2.SelectedDataKey.Value.ToString)
        Session.Add("taskid", taskid)
        Session.Add("querytype", "task")
        Response.Redirect("view_full_todo.aspx")
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

    End Sub

    Protected Sub GridView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.SelectedIndexChanged
        Dim todoid As Integer = Convert.ToInt16(GridView3.SelectedDataKey.Value.ToString)
        Session.Add("taskid", todoid)
        Session.Add("querytype", "todo")
        Response.Redirect("view_full_todo.aspx")
    End Sub

    
    Protected Sub lnkbtn_reports_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtn_reports.Click
        Dim loginerType As String = Session.Item("loginerTYP")
        If loginerType = "MNG" Then
            Response.Redirect("Reports_mng.aspx")
        Else
            Response.Redirect("Report.aspx")
        End If
    End Sub

    
End Class
Imports System.Data.SqlClient
Imports System.Data

Partial Class Todo_Assigned_task
    Inherits System.Web.UI.Page
    Dim probj As New projecterNM.projectercon
    Dim sqlQuery As String = ""
    Dim emps As SqlDataReader
    Dim nbr_of_items As Integer = 0
    Dim loginerID As Integer = 0
    Dim loginerType As String = ""
    Dim taskid As Int16 = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loginerID = Session.Item("loginerID")
        loginerType = Session.Item("loginerTYP")
        lbl_id.Text = loginerID

        If loginerType = "ADMIN" Then
            PlaceHolder1.Controls.Add(GridView5)
        Else
            PlaceHolder1.Controls.Add(GridView4)
            Panel1.Visible = False

        End If
    End Sub

    Protected Sub GridView4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView4.SelectedIndexChanged
        taskid = Convert.ToInt16(GridView4.SelectedDataKey.Value.ToString)
        Session.Add("taskid", taskid)
        sqlQuery = "select t.subject, t.""desc"", t.enddatetime from tbl_tasks t where id=" + Convert.ToString(taskid)
        emps = probj.SelectQuery(sqlQuery)
        nbr_of_items = 0
        If emps.Read Then
            txt_desc.Text = emps("desc")
            nbr_of_items = nbr_of_items + 1
        End If
    End Sub

    Protected Sub Btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Submit.Click
        taskid = Session.Item("taskid")
        Dim sql As String = ""
        If Trim(Txt_remark.Text).Length > 0 Then
            'Make statusid=5 if cancelled
            If loginerType = "ADMIN" Then
                sql = "update tbl_todo_details set statusid=5,remark='" + Txt_remark.Text + "' where master_id=" + Convert.ToString(taskid)
            Else
                sql = "update tbl_tasks set statusid=5,remark='" + Txt_remark.Text + "' where id=" + Convert.ToString(taskid)
            End If
            Dim success As Int16 = probj.InsertRecord(Sql)
        Else
            Label1.Text = "Please enter remarks before submitting"
            Txt_remark.Focus()
            Lbl_Remark.Visible = True
            Txt_remark.Visible = True
            Btn_Submit.Visible = True

        End If

    End Sub

    Protected Sub GridView5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView5.SelectedIndexChanged
        taskid = Convert.ToInt16(GridView5.SelectedDataKey.Value.ToString)
        Session.Add("taskid", taskid)
        sqlQuery = "select t.subject, t.""desc"" from tbl_todo_master t where t.id = " + Convert.ToString(taskid)
        emps = probj.SelectQuery(sqlQuery)
        nbr_of_items = 0
        If emps.Read Then
            txt_desc.Text = emps("desc")
            nbr_of_items = nbr_of_items + 1
        End If
    End Sub
End Class

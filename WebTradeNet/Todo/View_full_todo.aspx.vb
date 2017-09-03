Imports System.Data.SqlClient
Imports System.Data

Partial Class Default3
    Inherits System.Web.UI.Page
    Dim probj As New projecterNM.projectercon
    Dim sqlQuery As String = ""
    Dim emps As SqlDataReader
    Dim nbr_of_items As Integer = 0
    Dim loginerID As Integer = 0
    Dim loginerType As String = ""
    Dim taskid As Int16 = 0
    Protected Sub Btn_complete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_complete.Click
        Btn_complete.Enabled = False
        Btn_incomplete.Enabled = False
        Lbl_Remark.Visible = True
        Txt_remark.Visible = True
        Btn_Submit.Visible = True
        Session.Add("newstatus", 4)
    End Sub

    Protected Sub Btn_incomplete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_incomplete.Click
        Btn_complete.Enabled = False
        Btn_incomplete.Enabled = False
        Lbl_Remark.Visible = True
        Txt_remark.Visible = True
        Btn_Submit.Visible = True
        Session.Add("newstatus", 6)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_date.Text = System.DateTime.Now
        Lbl_Remark.Visible = False
        Txt_remark.Visible = False
        Btn_Submit.Visible = False
        loginerID = Session.Item("loginerID")
        loginerType = Session.Item("loginerTYP")
        lbl_id.Text = loginerID

        taskid = Session.Item("taskid")
        If Session.Item("querytype") = "task" Then
            sqlQuery = "select t.subject, t.""desc"", t.enddatetime from tbl_tasks t where id=" + Convert.ToString(taskid)
        ElseIf Session.Item("querytype") = "todo" Then
            sqlQuery = "select t.subject, t.""desc"", td.enddatetime from tbl_todo_master t, tbl_todo_details td where t.id = td.master_id and td.id=" + Convert.ToString(taskid)
        End If
        emps = probj.SelectQuery(sqlQuery)
        nbr_of_items = 0
        If emps.Read Then
            txt_desc.Text = emps("desc")
            nbr_of_items = nbr_of_items + 1
        End If
    End Sub

    Protected Sub Btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Submit.Click
        If Trim(Txt_remark.Text).Length > 0 Then
            'Make statusid=4 if complete, 6 if incomplete
            Dim sql As String = ""
            Dim success As Int16 = 0
            If Session.Item("querytype") = "task" Then
                sql = "update tbl_tasks set statusid=" + Convert.ToString(Session.Item("newstatus")) + ",remark='" + Txt_remark.Text + "' where id=" + Convert.ToString(taskid)
            ElseIf Session.Item("querytype") = "todo" Then
                sql = "update tbl_todo_details set statusid=" + Convert.ToString(Session.Item("newstatus")) + ",remark='" + Txt_remark.Text + "' where id=" + Convert.ToString(taskid)
            End If
            success = probj.InsertRecord(sql)
        Else
            Label1.text = "Please enter remarks before submitting"
            Txt_remark.Focus()
            lbl_remark.Visible = True
            Txt_remark.Visible = True
            Btn_Submit.Visible = True
        End If
    End Sub
End Class

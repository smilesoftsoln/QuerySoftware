Imports System.Data.SqlClient
Imports System.Data
Partial Class Report1
    Inherits System.Web.UI.Page
    Dim a As Integer
    Dim loginerID As Integer = 0
    Dim loginerType As String = ""
    Dim emps As SqlDataReader
    Dim probj As New projecterNM.projectercon
    Dim sqlQuery As String = ""
    Dim nbr_of_items As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loginerID = Session.Item("loginerID")
        loginerType = Session.Item("loginerTYP")
        lbl_id.Text = loginerID
        'If loginerType = "MNG" Then
        '    Panel1.Visible = True
        'Else
        '    PlaceHolder1.Controls.Add(Panel1)
        'End If
        If Session.Item("rep_state") <> 2 Then
            Session.Add("rep_state", 2)
            Dim sqlQuery As String = "select s.id as id, s.""desc"" as 'desc_' from tbl_status s order by 1 asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            DropDownList1.Items.Clear()
            While emps.Read
                DropDownList1.Items.Add(emps("desc_"))
                DropDownList1.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        a = Convert.ToInt32(DropDownList1.SelectedIndex)
        TextBox1.Text = Convert.ToInt32(DropDownList1.SelectedIndex)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        a = Convert.ToInt32(DropDownList1.SelectedIndex)
        TextBox1.Text = DropDownList1.SelectedIndex
    End Sub

   
End Class

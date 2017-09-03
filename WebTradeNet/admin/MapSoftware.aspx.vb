Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.Net.Mail

Partial Class admin_MapSoftware
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim comm_dns As New somman_functions_NM.commen_funcs
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridView1.DataBind()


    End Sub
    Sub command(ByVal strcmd As String)
        'cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.ConObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DropDownList1.SelectedIndex <> 0 Then
            command("select * from SoftwareMapping where Software='" + DropDownList2.Text + "' and UserName='" + DropDownList1.Text + "'")
            rdr = cmd.ExecuteReader()
            If rdr.HasRows Then
                MessageLabel4.Text = "Already Exists..!"
            Else
                cmd2.CommandText = "insert into SoftwareMapping(UserName,Software) values('" + DropDownList1.Text + "','" + DropDownList2.Text + "')"

                cmd2.Connection = weldone_con.ConObj
                cmd2.ExecuteNonQuery()
                MessageLabel4.Text = "Software Mapped Successfully..!"
                GridView1.DataBind()
            End If
        Else
            MessageLabel4.Text = "Select Employee Login ..!"
        End If



    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        MessageLabel4.Text = ""
        cmd2.CommandText = "select name_ from tbl_loginer_master where username_='" + DropDownList1.SelectedValue + "' "

        cmd2.Connection = weldone_con.ConObj
        rdr = cmd2.ExecuteReader()
        If rdr.HasRows Then
            rdr.Read()
            NameLabel4.Text = rdr(0).ToString()
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        'Dim gr As New GridViewRow
        Dim i As Integer
        'gr = GridView1.SelectedRow
        i = GridView1.SelectedIndex
        Dim str As String = GridView1.Rows(i).Cells(1).Text


        DropDownList2.Text = str


        'DropDownList2.Text=
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        cmd2.CommandText = "delete from SoftwareMapping where UserName='" + DropDownList1.Text + "' and Software ='" + DropDownList2.Text + "'"

        cmd2.Connection = weldone_con.ConObj
        cmd2.ExecuteNonQuery()
        MessageLabel4.Text = "Software Mapping Removed Successfully..!"
        GridView1.DataBind()
    End Sub

    Protected Sub DropDownList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.DataBound
        DropDownList1.Items.Insert(0, "<--Select-->")
    End Sub
End Class

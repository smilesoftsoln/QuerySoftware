Imports System.Data.SqlClient
Partial Class admin_change_stts
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Public creater As Integer
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Dim tid As Integer = Request.QueryString("tid")
        Dim t_stts As String = ""
        If Not Page.IsPostBack Then
            'command("sp_get_sttss")
            cbo_stts.Items.Add("--select--")
            'rdr = cmd.ExecuteReader
            '  While rdr.Read
            cbo_stts.Items.Add("FOLLOW UP")
            'End While

            command("sp_get_ticket_stts_by_id")
            cmd.Parameters.AddWithValue("@tid", tid)
            rdr = cmd.ExecuteReader

            If rdr.Read Then
                lbl_topic.Text = rdr("t_sub")
                'cbo_stts.SelectedValue = rdr("t_stts")
                creater = rdr("creater_id")
                t_stts = rdr("t_stts")

            End If
            If t_stts = "FOLLOW UP" Then
                cbo_stts.SelectedValue = t_stts
                cbo_stts.Enabled = False
                btn_change.Enabled = False

            Else
                cbo_stts.Enabled = True
                btn_change.Enabled = True
            End If
        End If


    End Sub

    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        Dim tid As Integer = Request.QueryString("tid")
        Dim nowinhand As String = ""
        command("sp_get_ticket_stts_by_id")
        cmd.Parameters.AddWithValue("@tid", tid)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            creater = rdr("creater_id")
            nowinhand = rdr("now_hand_in")
        End If
        rdr.Close()

        cmd = New SqlCommand
        cmd.CommandType = Data.CommandType.Text
        cmd.Parameters.Clear()
        cmd.Connection = weldone_con.ConObj
        If nowinhand.Equals("HOD") Then
            cmd.CommandText = "update tbl_ticket_master set Followup2=getdate() where id= " & tid
            cmd.ExecuteNonQuery()
        ElseIf nowinhand.Equals("DE") Then
            cmd.CommandText = "update tbl_ticket_master set Followup1=getdate() where id= " & tid
            cmd.ExecuteNonQuery()
        End If



        command("sp_change_stts_by_tid")
        cmd.Parameters.AddWithValue("@tid", tid)
        cmd.Parameters.AddWithValue("@stts", cbo_stts.SelectedValue)

        If cmd.ExecuteNonQuery() Then

            Response.Redirect("success_msg.aspx")
            'End If
        End If







    End Sub
End Class

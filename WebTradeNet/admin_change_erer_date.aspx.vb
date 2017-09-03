Imports System.Data.SqlClient
Partial Class admin_change_erer_date
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
        Try
            If Request.Cookies("admin")("login") = "false" Then
                Response.Redirect("User_login.aspx")
            End If

        Catch ex As Exception
            Response.Redirect("User_login.aspx")
        End Try
        Dim tid As Integer = Request.QueryString("tid")

        If Not Page.IsPostBack Then
            command("sp_get_ticket_stts_by_id")
            cmd.Parameters.AddWithValue("@tid", tid)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lbl_topic.Text = rdr("t_sub")
                txt_emer_date.Text = rdr("emergency_")
            End If
        End If

        
    End Sub

    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        

        Dim tid As Integer = Request.QueryString("tid")
        command("sp_get_ticket_stts_by_id")
        cmd.Parameters.AddWithValue("@tid", tid)
        Dim date_ As Date = txt_emer_date.Text
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            creater = rdr("creater_id")
        End If


        command("sp_change_emer_date_by_tid")
        cmd.Parameters.AddWithValue("@tid", tid)
        cmd.Parameters.AddWithValue("@date_ ", date_)
        If cmd.ExecuteNonQuery() Then
            command("sp_user_update_fill")
            cmd.Parameters.AddWithValue("@userID", creater)
            cmd.Parameters.AddWithValue("@update_", "Your Ticket :" & lbl_topic.Text & "'s: Emergency Date Changed By admin as '" & date_ & "' On- " & Now() & "")
            If cmd.ExecuteNonQuery Then
                Page.RegisterClientScriptBlock("ScriptDescription", "<script language=""JavaScript"">window.close()</script> ")

            End If
        End If

        

    End Sub
End Class

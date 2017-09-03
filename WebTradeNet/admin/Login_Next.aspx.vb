Imports System.Data.OleDb
Partial Class Login_Next
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New OleDbCommand
    Dim rdr As OleDbDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

    End Sub

   
End Class

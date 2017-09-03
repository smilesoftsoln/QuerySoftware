Imports System.Data.SqlClient
Partial Class view_all_users
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strim As String = ""

        strim &= "  <table class=""tbl_gw"">"
        strim &= "     <tr class=""tbl_gw_spl"">"
        strim &= "        <td style=""width:10%"">"
        strim &= " LoginerID"
        strim &= "         </td>"
        strim &= "        <td style=""width:40%"">"
        strim &= " UserName"
        strim &= "         </td>"
        strim &= "         <td style=""width:40%"">"
        strim &= " Name"
        strim &= "         </td>"
        strim &= "         <td style=""width:10%"" >"
        strim &= "            Type Of Emp."
        strim &= "        </td>"
        strim &= "    </tr>"
        command("sp_get_addressbook")
        rdr = cmd.ExecuteReader
        While rdr.Read
            If rdr("who_is") = "BE" Then

            End If
            strim &= "     <tr >"
            strim &= "        <td style=""width:10%"">"
            strim &= rdr("id")
            strim &= "         </td>"
            strim &= "        <td style=""width:40%"">"
            strim &= "<a href=""user_info.aspx?lid=" & rdr("id") & " "" >" & rdr("username_") & "</a>"
            strim &= "         </td>"
            strim &= "         <td style=""width:40%"">"
            strim &= rdr("display_name")
            strim &= "         </td>"
            strim &= "         <td style=""width:10%"" >"
            strim &= rdr("who_is")
            strim &= "        </td>"
        End While
        strim &= "</table>"
        Disp_users.innerhtml = strim
    End Sub

    '    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    '       If e.CommandName = "dg_com_1" Then
    '  Dim asd As String
    ' Dim row As GridViewRow
    'Dim str As String = e.CommandArgument
    ' Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    ' Dim index2 As Integer = Convert.ToInt64(e.CommandArgument)
    ' 'row = GridView1.Rows(index)

    '    End If
    'End Sub

    ' Protected Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
    'Dim selected_id As Integer
    '   selected_id = CType(e.CommandName, Integer)
    '  MsgBox(selected_id)
    'End Sub
End Class

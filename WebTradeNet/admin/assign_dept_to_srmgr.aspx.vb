Imports projecterNM
Imports System.Data.SqlClient

Partial Class admin_assign_dept_to_srmgr
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

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        Dim srmng_id As Integer = Convert.ToInt16(ddl_srmgr.SelectedValue)
        Dim dept_id As Integer = Convert.ToInt16(ddl_dept.SelectedValue)
        'Dim querystring As String
        Dim db As New projectercon

        'querystring = "select * from tbl_srmng_master where dept_id = " + dept_id.ToString
        'db.adp = New SqlDataAdapter(querystring, db.con)
        'db.ds = New DataSet
        'db.adp.Fill(db.ds)

        'Dim dr As DataTableReader = db.ds.CreateDataReader()
        'If dr.Read() = True Then
        'Update existing department to new sr manager
        'Else
        'Insert department - sr manager link
        'End If

        command("sp_get_srmng_dept")
        cmd.Parameters.AddWithValue("@dept_id", dept_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            command("sp_update_srmng")
            cmd.Parameters.AddWithValue("@dept_id", dept_id)
            cmd.Parameters.AddWithValue("@srmng_id", srmng_id)
            If cmd.ExecuteNonQuery Then
                lbl_status.Text = "Update Successful!"
            End If
        Else
            Dim inRec As New Queue
            Dim insDept As New DBField
            Dim insSrmng As New DBField

            insDept.dataType = 2                '1=String, 2=Number
            insDept.value = dept_id.ToString
            insDept.fieldName = "dept_id"
            inRec.Enqueue(insDept)

            insSrmng.dataType = 2               '1=String, 2=Number
            insSrmng.value = srmng_id.ToString
            insSrmng.fieldName = "srmgr_id"
            inRec.Enqueue(insSrmng)

            If db.InsertRecordIntoTable("tbl_srmng_master", inRec, True) Then
                lbl_status.Text = "Insert Successful!"
            End If
        End If
    End Sub

    Protected Sub ddl_dept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_dept.SelectedIndexChanged
        Dim srmng_id As Integer = Convert.ToInt16(ddl_srmgr.SelectedValue)
        Dim dept_id As Integer = Convert.ToInt16(ddl_dept.SelectedValue)
        command("sp_get_srmng_dept")
        cmd.Parameters.AddWithValue("@dept_id", dept_id)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            ddl_srmgr.SelectedValue = rdr("srmgr_id")
        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class

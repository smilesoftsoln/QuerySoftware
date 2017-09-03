Imports System.Data.SqlClient
Partial Class bh_view_running_ticks
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
    Dim cmd2 As New SqlCommand
    Dim rdr2 As SqlDataReader
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim loginerID As Integer = Session.Item("loginerID")
        Dim this_branh As String = Session.Item("ThisBranch")
        Dim branch_id As Integer
        Dim counter As Integer = 0
        Dim strim As String = ""
        Dim i As Integer = 0
        command("sp_get_branch_by_name")
        cmd.Parameters.AddWithValue("@branch_name", this_branh)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            branch_id = rdr("id")
        End If

        strim &= "<table class=""flexme1"">"
        strim &= "<thead>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <th width=""100"">"
        strim &= "Ticket ID"
        strim &= "	            </th>"
        strim &= "	            <th width=""200"">"
        strim &= "Ticket Subject"
        strim &= "	            </th>"
        strim &= "	            <th width=""100"">"
        strim &= "From"
        strim &= "	            </th>"
        strim &= "	            <th width=""100"">"
        strim &= "To"
        strim &= "	            </th>"
        strim &= "	            <th width=""100"">"
        strim &= " Status"
        strim &= "	            </th>"
        strim &= "	            <th width=""150"">"
        strim &= " Date"
        strim &= "	            </th>"
        strim &= "	            <th width=""50"">"
        strim &= "Follow"
        strim &= "	            </th>"
        strim &= "	        </tr>"
        strim &= "</thead>"
        i = 0

        command("sp_get_running_tickets_by_branch")
        cmd.Parameters.AddWithValue("@branch_id", branch_id)
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td >"
            strim &= rdr("disp_id")
            strim &= "	            </td>"
            strim &= "	            <td class=""date_ticks"">"

            strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"

            strim &= "	            <td >"
            strim &= rdr("branch_name") & "<br> (" & rdr("creater_name") & ")"
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("dept_name") & "<br> (" & rdr("reciver") & ")"
            strim &= "	            </td>"
            strim &= "	            <td  class=""date_ticks"">"
            strim &= rdr("t_stts")
            strim &= "	            </td>"
            strim &= "	            <td  class=""date_ticks"">"
            strim &= rdr("last_update_date")
            strim &= "	            </td>"
            strim &= "	            <td  class=""date_ticks"">"
            strim &= rdr("now_hand_in")
            strim &= "	            </td>"
            'strim &= "	            <td >"
            'strim &= "<a href=""JavaScript:return false()"" onMouseover=""showhint('" & rdr("name_") & " ', this, event, '150px')"">" & rdr("reciver") & "</a>"
            'strim &= "	            </td>"
            strim &= "	        </tr>"
            i = i + 1
        End While
        strim &= "	    </table>"

        'Dim this_branh As String = Session.Item("ThisBranch")
        'Dim strim As String = ""
        'Dim count_ As Integer = 0
        'If this_branh = "" Then
        '    Response.Redirect("Default.aspx")
        'End If

        'command("sp_get_unsolved_ticks_by_branch")
        'cmd.Parameters.AddWithValue("@branch_name", this_branh)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    count_ = count_ + 1
        'End While

        'Dim seq_ids(count_ + 1) As Integer
        'Dim loginerids(count_ + 1) As Integer
        'Dim details(count_ + 1) As String
        'Dim usernames(count_ + 1) As String
        'Dim to_depts(count_ + 1) As Integer
        'Dim to_depts_name(count_ + 1) As String
        'Dim arr_crtr_ids(count_ + 1) As Integer
        'Dim arr_disp_name(count_ + 1) As String
        'Dim an As Integer = 1
        'Dim i As Integer = 0

        'command("sp_get_unsolved_ticks_by_branch")
        'cmd.Parameters.AddWithValue("@branch_name", this_branh)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    seq_ids(i) = rdr("pro_to_dept_emoID")
        '    to_depts(i) = rdr("to_dept_id")
        '    arr_crtr_ids(i) = rdr("creater_id")
        '    i = i + 1
        'End While
        'i = 0

        'While i <= count_
        '    command("sp_get_DE_loginer_ids_by_forign_ids")
        '    cmd.Parameters.AddWithValue("@f_id", seq_ids(i))
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        loginerids(i) = rdr("id")
        '        usernames(i) = rdr("username_")
        '        details(i) = "Name :" & rdr("display_name")
        '        details(i) &= "<br>UserName : " & rdr("username_")

        '    End If
        '    i = i + 1
        'End While
        'i = 0

        'While i <= count_
        '    command("sp_get_disp_name_by_loginer_id")
        '    cmd.Parameters.AddWithValue("@lid", arr_crtr_ids(i))
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        arr_disp_name(i) = rdr("display_name")

        '    End If
        '    i = i + 1
        'End While
        'i = 0


        'While i <= count_
        '    command("sp_get_dept_by_id")
        '    cmd.Parameters.AddWithValue("@id", to_depts(i))
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        to_depts_name(i) = rdr("dept_name")
        '    End If
        '    i = i + 1
        'End While
        'i = 0

        'strim &= " <h5>All Tickets By '" & this_branh & "' Branch</h5>"
        'strim &= " <table>"
        'strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        'strim &= "	            <td style=""width:5%"">"
        'strim &= "No."
        'strim &= "	            </td>"
        'strim &= "	            <td style=""width:36%"">"
        'strim &= "Ticket Subject"
        'strim &= "	            </td>"
        'strim &= "	            <td style=""width:10%"">"
        'strim &= "To Dept."
        'strim &= "	            </td>"
        'strim &= "	            <td style=""width:10%"">"
        'strim &= "Ticket ID"
        'strim &= "	            </td>"
        'strim &= "	            <td style=""width:11%"">"
        'strim &= " By"
        'strim &= "	            </td>"
        'strim &= "	            <td style=""width:10%"">"
        'strim &= " Status"
        'strim &= "	            </td>"
        'strim &= "	            <td style=""width:15%"">"
        'strim &= "	                Date"
        'strim &= "	            </td>"
        'strim &= "	            <td style=""width:8%"">"
        'strim &= "Follow"
        'strim &= "	            </td>"
        'strim &= "	        </tr>"

        'command("sp_get_unsolved_ticks_by_branch")
        'cmd.Parameters.AddWithValue("@branch_name", this_branh)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    strim &= "	        <tr >"
        '    strim &= "	            <td class=""date_ticks"">"
        '    strim &= an
        '    strim &= "	            </td>"
        '    strim &= "	            <td >"
        '    strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html "">" & rdr("t_sub") & " </a>"
        '    strim &= "	            </td>"
        '    strim &= "	            <td class=""date_ticks"">"
        '    strim &= to_depts_name(i)
        '    strim &= "	            </td>"
        '    strim &= "	            <td class=""date_ticks"">"
        '    strim &= rdr("disp_id")
        '    strim &= "	            </td>"
        '    strim &= "	            <td class=""date_ticks"">"
        '    strim &= arr_disp_name(i)
        '    strim &= "	            </td>"
        '    strim &= "	            <td class=""date_ticks"">"
        '    strim &= rdr("t_stts")
        '    strim &= "	            </td>"
        '    strim &= "	            <td class=""date_ticks"">"
        '    strim &= rdr("date_")
        '    strim &= "	            </td>"
        '    strim &= "	            <td class=""date_ticks"">"
        '    strim &= "<a href=""JavaScript:return false()"" onMouseover=""showhint('" & details(i) & " ', this, event, '150px')""> " & usernames(i) & " </a>"
        '    'strim &= loginerids(i)
        '    strim &= "	            </td>"
        '    strim &= "	        </tr>"
        '    i = i + 1
        '    an = an + 1
        'End While
        'strim &= "	        </table>"
        disp_result.InnerHtml = strim
    End Sub
End Class

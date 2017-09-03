Imports System.Data.SqlClient
Partial Class bh_view_all_ticks
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim loginerID As Integer
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

        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:6%"">"
        strim &= "Ticket ID"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:31%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "From"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "To"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= " Date"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "Follow"
        strim &= "	            </td>"
        strim &= "<td style=""width:10%"">"
        strim &= "Delete?"
        strim &= "</td>"
        strim &= "	        </tr>"
        i = 0

        command("sp_get_tickets_by_branch")
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
            strim &= rdr("branch_name")
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
            strim &= "	            <td>"
            If (rdr("t_stts") = "SOLVED") Then
                strim &= "<a href=""delete_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/Delete_topic.jpg""></a>"
            End If
            strim &= "	            </td>"
            'strim &= "	            <td >"
            'strim &= "<a href=""JavaScript:return false()"" onMouseover=""showhint('" & rdr("name_") & " ', this, event, '150px')"">" & rdr("reciver") & "</a>"
            'strim &= "	            </td>"
            strim &= "	        </tr>"
            i = i + 1
        End While
        strim &= "	    </table>"

        'command("sp_get_all_ticks_by_branch_name")
        'cmd.Parameters.AddWithValue("@branch_name", this_branh)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    counter = counter + 1
        'End While
        'Dim arr_crtr(counter + 1) As Integer
        'Dim arr_to_emp(counter + 1) As Integer
        'Dim arr_crtr_name(counter + 1) As String
        'Dim arr_emp_name(counter + 1) As String
        'Dim strim As String = ""
        'command("sp_get_all_ticks_by_branch_name")
        'cmd.Parameters.AddWithValue("@branch_name", this_branh)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    arr_crtr(i) = rdr("creater_id")
        '    arr_to_emp(i) = rdr("pro_to_dept_emoID")
        '    i = i + 1
        'End While
        'i = 0
        'While i <= counter
        '    command("sp_get_loginer_by_id")
        '    cmd.Parameters.AddWithValue("@l_id", arr_crtr(i))
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        arr_crtr_name(i) = rdr("display_name")
        '    End If
        '    i = i + 1
        'End While
        'i = 0
        'While i <= counter
        '    command("sp_get_emp_by_id")
        '    cmd.Parameters.AddWithValue("@id", arr_to_emp(i))
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        arr_emp_name(i) = rdr("name_")
        '    End If
        '    i = i + 1
        'End While
        
        'command("sp_get_all_ticks_by_branch_name")
        'cmd.Parameters.AddWithValue("@branch_name", this_branh)
        ''rdr = cmd.ExecuteReader
        ''While rdr.Read
        ''    strim &= "<tr >"
        ''    strim &= "<td width=""10%"">"
        ''    strim &= rdr("disp_id")
        ''    strim &= "</td>"
        ''    strim &= "<td width=""30%"">"
        ''    'strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html "">"
        ''    'strim &= rdr("t_sub")
        ''    'strim &= "</a>"
        ''    '============
        ''    strim &= "<div>"
        ''    strim &= "   <a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html"" onclick=""return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 980, objectHeight: 900} )"" class=""highslide"">" & rdr("t_sub") & "</a>"
        ''    strim &= "       <div class=""highslide-html-content"" id=""highslide-html"" style=""width: 980px"">"
        ''    strim &= "       <div class=""highslide-move"" style=""border: 0; height: 25px; padding: 0px; cursor: default"">"
        ''    strim &= "          <div class=""data_admin_mid_main_top_3"">"
        ''    strim &= "              View Runing Queries"
        ''    strim &= "                   <a href=""#"" onclick=""return hs.close(this)"" class=""control"">"
        ''    strim &= "                      <img src=""images/spacer.gif"" width=""50px"" height=""25px;"" aling=""right""  />"
        ''    strim &= "                  </a>"
        ''    strim &= "           </div>"
        ''    strim &= ""
        ''    strim &= "        </div>"
        ''    strim &= "       <div class=""highslide-body"" id=""hod_runn_main""></div>"
        ''    strim &= "        </div>"
        ''    strim &= "  </div>"
        ''    '============
        ''    strim &= "</td>"
        ''    strim &= "<td width=""10%"" style=""text-transform:uppercase;"">"
        ''    strim &= rdr("now_hand_in")
        ''    strim &= "</td>"
        ''    strim &= "<td width=""15%"">"
        ''    strim &= arr_crtr_name(i) & " (" & rdr("from_branch") & ")"
        ''    strim &= "</td>"
        ''    strim &= "<td width=""15%"" style=""font-size:10px;"">"
        ''    strim &= rdr("date_")
        ''    strim &= "</td>"
        ''    strim &= "<td width=""10%"" style=""font-size:10px;"">"
        ''    strim &= rdr("t_stts")
        ''    strim &= "</td>"
        ''    strim &= "<td width=""10%"" style=""font-size:10px;"">"
        ''    strim &= arr_emp_name(i)
        ''    strim &= "</td>"
        ''    strim &= "</tr>"
        ''    i = i + 1
        ''End While
        ''strim &= "	    </table>"
        disp_all_updates.InnerHtml = strim
    End Sub

    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Dim this_branh As String = Session.Item("ThisBranch")
        Dim strim As String = ""
        Dim t_stts As String
        Dim loginerID As Integer = Session.Item("loginerID")
        Dim branch_id As Integer
        Dim counter As Integer = 0
        Dim i As Integer = 0
        command("sp_get_branch_by_name")
        cmd.Parameters.AddWithValue("@branch_name", this_branh)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            branch_id = rdr("id")
        End If

        If rdb_opns.SelectedValue = "Solved" Then
            t_stts = "SOLVED"
        ElseIf rdb_opns.SelectedValue = "UnSolved" Then
            t_stts = "UNSOLVED"
        ElseIf rdb_opns.SelectedValue = "ALL" Then
            t_stts = "%%"
        ElseIf rdb_opns.SelectedValue = "Follow Up" Then
            t_stts = "FOLLOW UP"
        End If


        strim &= " <table>"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:6%"">"
        strim &= "Ticket ID"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:31%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "From"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "To"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= " Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= " Date"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "Follow"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        i = 0

        command("sp_get_tickets_by_branch_n_stts")
        cmd.Parameters.AddWithValue("@stts", t_stts)
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
            strim &= rdr("branch_name")
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
        'If rdb_opns.SelectedValue = "Solved" Then
        '    Dim loginerID As Integer = Session.Item("loginerID")
        '    Dim counter As Integer = 0
        '    Dim i As Integer = 0
        '    command("sp_get_solved_ticks_by_branch_name")
        '    cmd.Parameters.AddWithValue("@branch_name", this_branh)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        counter = counter + 1
        '    End While
        '    Dim arr_crtr(counter + 1) As Integer
        '    Dim arr_to_emp(counter + 1) As Integer
        '    Dim arr_crtr_name(counter + 1) As String
        '    Dim arr_emp_name(counter + 1) As String
        '    Dim strim As String = ""
        '    command("sp_get_solved_ticks_by_branch_name")
        '    cmd.Parameters.AddWithValue("@branch_name", this_branh)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        arr_crtr(i) = rdr("creater_id")
        '        arr_to_emp(i) = rdr("pro_to_dept_emoID")
        '        i = i + 1
        '    End While
        '    i = 0
        '    While i <= counter
        '        command("sp_get_loginer_by_id")
        '        cmd.Parameters.AddWithValue("@l_id", arr_crtr(i))
        '        rdr = cmd.ExecuteReader
        '        If rdr.Read Then
        '            arr_crtr_name(i) = rdr("display_name")
        '        End If
        '        i = i + 1
        '    End While
        '    i = 0
        '    While i <= counter
        '        command("sp_get_emp_by_id")
        '        cmd.Parameters.AddWithValue("@id", arr_to_emp(i))
        '        rdr = cmd.ExecuteReader
        '        If rdr.Read Then
        '            arr_emp_name(i) = rdr("name_")
        '        End If
        '        i = i + 1
        '    End While
        '    strim &= " <table>"
        '    strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        '    strim &= "	            <td style=""width:9%"" colspan=""6"">"
        '    strim &= "Running Ticktes Till - " & Today()
        '    strim &= "	            </td>"
        '    strim &= "	        </tr>"
        '    strim &= "<tr class=""updater_mid_tr_spl"">"
        '    strim &= "<td>"
        '    strim &= "Ticket ID"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Subject"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Follower"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "By"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Date"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Status"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Tp Emp."
        '    strim &= "</td>"
        '    strim &= "</tr>"
        '    i = 0
        '    command("sp_get_solved_ticks_by_branch_name")
        '    cmd.Parameters.AddWithValue("@branch_name", this_branh)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        strim &= "<tr >"
        '        strim &= "<td width=""10%"">"
        '        strim &= rdr("disp_id")
        '        strim &= "</td>"
        '        strim &= "<td width=""30%"">"
        '        'strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html "">"
        '        'strim &= rdr("t_sub")
        '        'strim &= "</a>"
        '        '============
        '        strim &= "<div>"
        '        strim &= "   <a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html"" onclick=""return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 980, objectHeight: 900} )"" class=""highslide"">" & rdr("t_sub") & "</a>"
        '        strim &= "       <div class=""highslide-html-content"" id=""highslide-html"" style=""width: 980px"">"
        '        strim &= "       <div class=""highslide-move"" style=""border: 0; height: 25px; padding: 0px; cursor: default"">"
        '        strim &= "          <div class=""data_admin_mid_main_top_3"">"
        '        strim &= "              View Runing Queries"
        '        strim &= "                   <a href=""#"" onclick=""return hs.close(this)"" class=""control"">"
        '        strim &= "                      <img src=""images/spacer.gif"" width=""50px"" height=""25px;"" aling=""right""  />"
        '        strim &= "                  </a>"
        '        strim &= "           </div>"
        '        strim &= ""
        '        strim &= "        </div>"
        '        strim &= "       <div class=""highslide-body"" id=""hod_runn_main""></div>"
        '        strim &= "        </div>"
        '        strim &= "  </div>"
        '        '============
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"" style=""text-transform:uppercase;"">"
        '        strim &= rdr("now_hand_in")
        '        strim &= "</td>"
        '        strim &= "<td width=""15%"">"
        '        strim &= arr_crtr_name(i) & " (" & rdr("from_branch") & ")"
        '        strim &= "</td>"
        '        strim &= "<td width=""15%"" style=""font-size:10px;"">"
        '        strim &= rdr("date_")
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"" style=""font-size:10px;"">"
        '        strim &= rdr("t_stts")
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"" style=""font-size:10px;"">"
        '        strim &= arr_emp_name(i)
        '        strim &= "</td>"
        '        strim &= "</tr>"
        '        i = i + 1
        '    End While
        '    strim &= "	    </table>"
        '    disp_all_updates.InnerHtml = strim
        'ElseIf rdb_opns.SelectedValue = "UnSolved" Then
        '    Dim loginerID As Integer = Session.Item("loginerID")
        '    Dim counter As Integer = 0
        '    Dim i As Integer = 0
        '    command("sp_get_Unsolved_ticks_by_branch_name")
        '    cmd.Parameters.AddWithValue("@branch_name", this_branh)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        counter = counter + 1
        '    End While
        '    Dim arr_crtr(counter + 1) As Integer
        '    Dim arr_to_emp(counter + 1) As Integer
        '    Dim arr_crtr_name(counter + 1) As String
        '    Dim arr_emp_name(counter + 1) As String
        '    Dim strim As String = ""
        '    command("sp_get_Unsolved_ticks_by_branch_name")
        '    cmd.Parameters.AddWithValue("@branch_name", this_branh)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        arr_crtr(i) = rdr("creater_id")
        '        arr_to_emp(i) = rdr("pro_to_dept_emoID")
        '        i = i + 1
        '    End While
        '    i = 0
        '    While i <= counter
        '        command("sp_get_loginer_by_id")
        '        cmd.Parameters.AddWithValue("@l_id", arr_crtr(i))
        '        rdr = cmd.ExecuteReader
        '        If rdr.Read Then
        '            arr_crtr_name(i) = rdr("display_name")
        '        End If
        '        i = i + 1
        '    End While
        '    i = 0
        '    While i <= counter
        '        command("sp_get_emp_by_id")
        '        cmd.Parameters.AddWithValue("@id", arr_to_emp(i))
        '        rdr = cmd.ExecuteReader
        '        If rdr.Read Then
        '            arr_emp_name(i) = rdr("name_")
        '        End If
        '        i = i + 1
        '    End While
        '    strim &= " <table>"
        '    strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        '    strim &= "	            <td style=""width:9%"" colspan=""6"">"
        '    strim &= "Running Ticktes Till - " & Today()
        '    strim &= "	            </td>"
        '    strim &= "	        </tr>"
        '    strim &= "<tr class=""updater_mid_tr_spl"">"
        '    strim &= "<td>"
        '    strim &= "Ticket ID"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Subject"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Follower"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "By"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Date"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Status"
        '    strim &= "</td>"
        '    strim &= "<td>"
        '    strim &= "Tp Emp."
        '    strim &= "</td>"
        '    strim &= "</tr>"
        '    i = 0
        '    command("sp_get_Unsolved_ticks_by_branch_name")
        '    cmd.Parameters.AddWithValue("@branch_name", this_branh)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        strim &= "<tr >"
        '        strim &= "<td width=""10%"">"
        '        strim &= rdr("disp_id")
        '        strim &= "</td>"
        '        strim &= "<td width=""30%"">"
        '        'strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html "">"
        '        'strim &= rdr("t_sub")
        '        'strim &= "</a>"
        '        '============
        '        strim &= "<div>"
        '        strim &= "   <a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("t_id") & "&TnCAREeisgrate.html"" onclick=""return hs.htmlExpand(this, { contentId: 'highslide-html', objectType: 'iframe',		objectWidth: 980, objectHeight: 900} )"" class=""highslide"">" & rdr("t_sub") & "</a>"
        '        strim &= "       <div class=""highslide-html-content"" id=""highslide-html"" style=""width: 980px"">"
        '        strim &= "       <div class=""highslide-move"" style=""border: 0; height: 25px; padding: 0px; cursor: default"">"
        '        strim &= "          <div class=""data_admin_mid_main_top_3"">"
        '        strim &= "              View Runing Queries"
        '        strim &= "                   <a href=""#"" onclick=""return hs.close(this)"" class=""control"">"
        '        strim &= "                      <img src=""images/spacer.gif"" width=""50px"" height=""25px;"" aling=""right""  />"
        '        strim &= "                  </a>"
        '        strim &= "           </div>"
        '        strim &= ""
        '        strim &= "        </div>"
        '        strim &= "       <div class=""highslide-body"" id=""hod_runn_main""></div>"
        '        strim &= "        </div>"
        '        strim &= "  </div>"
        '        '============
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"" style=""text-transform:uppercase;"">"
        '        strim &= rdr("now_hand_in")
        '        strim &= "</td>"
        '        strim &= "<td width=""15%"">"
        '        strim &= arr_crtr_name(i) & " (" & rdr("from_branch") & ")"
        '        strim &= "</td>"
        '        strim &= "<td width=""15%"" style=""font-size:10px;"">"
        '        strim &= rdr("date_")
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"" style=""font-size:10px;"">"
        '        strim &= rdr("t_stts")
        '        strim &= "</td>"
        '        strim &= "<td width=""10%"" style=""font-size:10px;"">"
        '        strim &= arr_emp_name(i)
        '        strim &= "</td>"
        '        strim &= "</tr>"
        '        i = i + 1
        '    End While
        '    strim &= "	    </table>"
        disp_all_updates.InnerHtml = strim

    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Dim loginer_ID As Integer = Session.Item("loginerID")
        Dim emp_id_ As Integer
        Dim deptId As Integer
        Dim branch_id As Integer
        Dim this_branch As String = Session.Item("ThisBranch")

        command("sp_get_branch_by_name")
        cmd.Parameters.AddWithValue("@branch_name", this_branch)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            branch_id = rdr("id")
        End If
        '====================loginer details feed in top informer====================
        'lbl_user_name.Text = loginer_ID
        command("sp_get_details_by_loginerID")
        cmd.Parameters.AddWithValue("@loginerID", loginer_ID)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            emp_id_ = rdr("forign_id")
        End If
        '=========== view all tickets ========
        Dim strim As String = ""
        'Dim i As Integer = 0
        'Label1.Text = "Deleted Tickets"
        'pnl_view_all.Visible = True
        'strim = ""
        'Dim counter_ As Integer = 0
        'i = 0
        'command("sp_get_deleted_ticks_by_emp_id")
        'cmd.Parameters.AddWithValue("@emp_id", emp_id_)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    counter_ = counter_ + 1
        'End While

        'Dim arr_by_(counter_ + 1) As Integer
        'Dim arr_disp_name(counter_ + 1) As String

        'command("sp_get_deleted_ticks_by_emp_id")
        'cmd.Parameters.AddWithValue("@emp_id", emp_id_)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    arr_by_(i) = rdr("creater_id")
        '    i = i + 1
        'End While
        'i = 0


        'While i < counter_
        '    command("sp_get_disp_name_by_loginer_id")
        '    cmd.Parameters.AddWithValue("@lid", arr_by_(i))
        '    rdr = cmd.ExecuteReader
        '    If rdr.Read Then
        '        arr_disp_name(i) = rdr("display_name")
        '    End If
        '    i = i + 1
        'End While
        'i = 0
        ' MsgBox(emp_id_)
        'command("sp_get_all_deleted_tickets_to_hod")
        command("sp_get_all_deleted_tickets_to_hod2")
        cmd.Parameters.AddWithValue("@branch_id", branch_id)
        rdr = cmd.ExecuteReader
        strim &= " <table class=""tbl_vall_clss"">"
        strim &= "	        <tr class=""admin_updater_long_mid_sp_td"">"
        strim &= "	            <td style=""width:39%"">"
        strim &= "Ticket Subject"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:15%"">"
        strim &= "By"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "Status"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:22%"" >"
        strim &= "	                Created On"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:10%"">"
        strim &= "followUP"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "RES"
        strim &= "	            </td>"
        strim &= "	            <td style=""width:3%"">"
        strim &= "D"
        strim &= "	            </td>"
        strim &= "	        </tr>"
        While rdr.Read
            strim &= "	        <tr >"
            strim &= "	            <td >"
            strim &= "<a href=""hod_view_tixk_nvsbl.aspx?tid=" & rdr("id") & "& "">" & rdr("t_sub") & " </a>"
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("auther")
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("t_stts")
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("last_update_date")
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= rdr("now_hand_in")
            strim &= "	            </td>"
            strim &= "	            <td>"
            strim &= "<a href=""restore_ticket.aspx?tid=" & rdr("id") & " "" >" & "<img src=""images/restore.png""></a>"
            strim &= "	            </td>"
            strim &= "	            <td >"
            strim &= "R"
            strim &= "	            </td>"
            strim &= "	        </tr>"

        End While
        strim &= "	        </table>"
        disp_all_updates.InnerHtml = strim
        '=====================================

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("SoftwareSuite.aspx?Mode=1&UserName=" + Session("login").ToString())
    End Sub
End Class

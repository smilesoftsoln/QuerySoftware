Imports System.Data.SqlClient
Partial Class admin_view_all_users
    Inherits System.Web.UI.Page
    Dim weldone_con As New projecterNM.projectercon
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Public sepm As Integer = 0
    Sub command(ByVal strcmd As String)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = strcmd
        cmd.Connection = weldone_con.conObj
        cmd.Parameters.Clear()
    End Sub
    
    Protected Sub cbo_typ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_typ.SelectedIndexChanged
        If cbo_typ.SelectedValue = "BE" Then
            pnl_be.Visible = True
            pnl_de.Visible = False
            pnl_mng.Visible = False
        ElseIf cbo_typ.SelectedValue = "BH" Then
            pnl_be.Visible = True
            pnl_de.Visible = False
            pnl_mng.Visible = False
        ElseIf cbo_typ.SelectedValue = "DE" Then
            pnl_be.Visible = False
            pnl_de.Visible = True
            pnl_mng.Visible = False
        ElseIf cbo_typ.SelectedValue = "HOD" Then
            pnl_be.Visible = False
            pnl_de.Visible = True
            pnl_mng.Visible = False
        ElseIf cbo_typ.SelectedValue = "MNG" Then
            pnl_be.Visible = False
            pnl_de.Visible = False
            pnl_mng.Visible = True
        ElseIf cbo_typ.SelectedValue = "ALL" Then
            pnl_be.Visible = False
            pnl_de.Visible = False
            pnl_mng.Visible = False
        End If
        disp_users.InnerHtml = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            command("sp_get_branches")
            rdr = cmd.ExecuteReader
            cbo_be.Items.Add("ALL")
            While rdr.Read
                cbo_be.Items.Add(rdr("branch_name"))
            End While

            command("sp_get_depts")
            rdr = cmd.ExecuteReader
            cbo_dept.Items.Add("ALL")
            While rdr.Read
                cbo_dept.Items.Add(rdr("dept_name"))
            End While

            command("sp_get_managements")
            rdr = cmd.ExecuteReader
            cbo_mng.Items.Add("ALL")
            While rdr.Read
                cbo_mng.Items.Add(rdr("mng_name"))
            End While
        End If


        '==== displaying all users 
        Dim strim As String = ""
        strim &= "<br><br>"
        strim &= "<table class=""flexme1"" >"
        strim &= "<thead>"
        strim &= "<tr >"
        strim &= "<th width=""20"">"
        strim &= "LS"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "UserName"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "Name"
        strim &= "</th>"
        strim &= "<th width=""50"">"
        strim &= "Post"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "phone number"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= "Email-ID"
        strim &= "</th>"
        strim &= "<th width=""100"">"
        strim &= " Manage"
        strim &= "</th>"
        strim &= "</tr>"
        strim &= "</thead>"


        command("sp_get_all_users")
        cmd.Parameters.AddWithValue("@post_", "%%")
        rdr = cmd.ExecuteReader
        While rdr.Read
            strim &= "<tr>"
            strim &= "   <td>"
            If rdr("login_stts") = "ONLINE" Then
                strim &= "<img src=""images/ico_online.gif"">"
            ElseIf rdr("login_stts") = "OFFLINE" Then
                strim &= "<img src=""images/ico_offline.png"">"
            End If
            strim &= "  </td>"
            strim &= "   <td>"
            strim &= rdr("username_")
            strim &= "  </td>"
            strim &= "  <td>"
            strim &= rdr("name_")
            strim &= " </td>"
            strim &= "  <td>"
            strim &= rdr("post_")
            strim &= "  </td>"
            strim &= " <td>"
            strim &= rdr("phone_number")
            strim &= "</td>"
            strim &= "  <td>"
            strim &= rdr("email_id")
            strim &= "  </td>"
            strim &= "  <td>"
            strim &= "<a href=""edit_user_info.aspx?lid=" & rdr("id") & "&Sed adipiscing dictum sem non elementum. Nullam eget eros eu ligula imperdiet dictum quis ac purus. Donec condimentum erat vitae libero blandit suscipit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut euismod lacinia neque ac mollis.html ""> Manage </a>"
            strim &= "</td>"
            strim &= "</tr>       "
        End While
        strim &= "</table>"

        disp_users.innerhtml = strim
    End Sub

    Protected Sub btn_go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_go.Click
        Dim strim As String = ""

        strim &= "<br><br>"
        strim &= "<table class=""flexme1"" >"
        strim &= "<thead>"
        strim &= "<tr >"

        strim &= "<th width=""20"">"
        strim &= "LS"
        strim &= "</th>"
        strim &= "<th width=""90"">"
        strim &= "UserName"
        strim &= "</th>"
        strim &= "<th width=""90"">"
        strim &= "Name"
        strim &= "</th>"
        strim &= "<th width=""50"">"
        strim &= "Post"
        strim &= "</th>"
        strim &= "<th width=""90"">"
        strim &= "Details"
        strim &= "</th>"
        strim &= "<th width=""90"">"
        strim &= "phone number"
        strim &= "</th>"
        strim &= "<th width=""90"">"
        strim &= "Email-ID"
        strim &= "</th>"
       
       
        strim &= "<th width=""60"">"
        strim &= " Manage"
        strim &= "</th>"
        strim &= "</tr>"
        strim &= "</thead>"

        If cbo_typ.SelectedValue = "BE" Then
            Dim branch As String
            If cbo_be.SelectedValue = "ALL" Then
                branch = "%%"
            Else
                branch = cbo_be.SelectedValue
            End If

            command("sp_get_all_be")
            cmd.Parameters.AddWithValue("@branch", branch)
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "<tr>"
                strim &= "   <td>"
                If rdr("login_stts") = "ONLINE" Then
                    strim &= "<img src=""images/ico_online.gif"">"
                ElseIf rdr("login_stts") = "OFFLINE" Then
                    strim &= "<img src=""images/ico_offline.png"">"
                End If
                strim &= "  </td>"
                strim &= "<td>"
                strim &= rdr("username_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("name_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= "BE"
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("branch_name")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("phone_number")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("email_id")
                strim &= "</td>"
               
                strim &= "<td>"
                strim &= "<a href=""edit_user_info.aspx?lid=" & rdr("id") & "&Sed adipiscing dictum sem non elementum. Nullam eget eros eu ligula imperdiet dictum quis ac purus. Donec condimentum erat vitae libero blandit suscipit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut euismod lacinia neque ac mollis.html ""> Manage </a>"
                strim &= "</td>"
                strim &= "</tr>"
            End While
            strim &= "</table>"
            disp_users.InnerHtml = strim
        ElseIf cbo_typ.SelectedValue = "BH" Then
            Dim branch As String
            If cbo_be.SelectedValue = "ALL" Then
                branch = "%%"
            Else
                branch = cbo_be.SelectedValue
            End If

            command("sp_get_all_bh")
            cmd.Parameters.AddWithValue("@branch", branch)
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "<tr>"
                strim &= "   <td>"
                If rdr("login_stts") = "ONLINE" Then
                    strim &= "<img src=""images/ico_online.gif"">"
                ElseIf rdr("login_stts") = "OFFLINE" Then
                    strim &= "<img src=""images/ico_offline.png"">"
                End If
                strim &= "  </td>"
                strim &= "<td>"
                strim &= rdr("username_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("name_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= "BH"
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("branch_name")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("phone_number")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("email_id")
                strim &= "</td>"
               
                strim &= "<td>"
                strim &= "<a href=""edit_user_info.aspx?lid=" & rdr("id") & "&Sed adipiscing dictum sem non elementum. Nullam eget eros eu ligula imperdiet dictum quis ac purus. Donec condimentum erat vitae libero blandit suscipit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut euismod lacinia neque ac mollis.html ""> Manage </a>"
                strim &= "</td>"
                strim &= "</tr>"
            End While
            strim &= "</table>"
            disp_users.InnerHtml = strim
        ElseIf cbo_typ.SelectedValue = "DE" Then
            Dim dept As String
            If cbo_dept.SelectedValue = "ALL" Then
                dept = "%%"
            Else
                dept = cbo_dept.SelectedValue
            End If

            command("sp_get_all_de")
            cmd.Parameters.AddWithValue("@dept", dept)
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "<tr>"
                strim &= "   <td>"
                If rdr("login_stts") = "ONLINE" Then
                    strim &= "<img src=""images/ico_online.gif"">"
                ElseIf rdr("login_stts") = "OFFLINE" Then
                    strim &= "<img src=""images/ico_offline.png"">"
                End If
                strim &= "  </td>"
                strim &= "<td>"
                strim &= rdr("username_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("name_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= "DE"
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("dept_name")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("phone_number")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("email_id")
                strim &= "</td>"
               
                strim &= "<td>"
                strim &= "<a href=""edit_user_info.aspx?lid=" & rdr("id") & "&Sed adipiscing dictum sem non elementum. Nullam eget eros eu ligula imperdiet dictum quis ac purus. Donec condimentum erat vitae libero blandit suscipit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut euismod lacinia neque ac mollis.html ""> Manage </a>"
                strim &= "</td>"
                strim &= "</tr>"
            End While
            strim &= "</table>"
            disp_users.InnerHtml = strim
        ElseIf cbo_typ.SelectedValue = "HOD" Then
            Dim dept As String
            If cbo_dept.SelectedValue = "ALL" Then
                dept = "%%"
            Else
                dept = cbo_dept.SelectedValue
            End If

            command("sp_get_all_hod")
            cmd.Parameters.AddWithValue("@dept", dept)
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "<tr>"
                strim &= "   <td>"
                If rdr("login_stts") = "ONLINE" Then
                    strim &= "<img src=""images/ico_online.gif"">"
                ElseIf rdr("login_stts") = "OFFLINE" Then
                    strim &= "<img src=""images/ico_offline.png"">"
                End If
                strim &= "  </td>"
                strim &= "<td>"
                strim &= rdr("username_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("name_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= "HOD"
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("dept_name")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("phone_number")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("email_id")
                strim &= "</td>"
               
                strim &= "<td>"
                strim &= "<a href=""edit_user_info.aspx?lid=" & rdr("id") & "&Sed adipiscing dictum sem non elementum. Nullam eget eros eu ligula imperdiet dictum quis ac purus. Donec condimentum erat vitae libero blandit suscipit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut euismod lacinia neque ac mollis.html ""> Manage </a>"
                strim &= "</td>"
                strim &= "</tr>"
            End While
            strim &= "</table>"
            disp_users.InnerHtml = strim
        ElseIf cbo_typ.SelectedValue = "MNG" Then
            Dim mng As String
            If cbo_mng.SelectedValue = "ALL" Then
                mng = "%%"
            Else
                mng = cbo_mng.SelectedValue
            End If

            command("sp_get_all_mng")
            cmd.Parameters.AddWithValue("@mng", mng)
            rdr = cmd.ExecuteReader
            While rdr.Read
                strim &= "<tr>"
                strim &= "   <td>"
                If rdr("login_stts") = "ONLINE" Then
                    strim &= "<img src=""images/ico_online.gif"">"
                ElseIf rdr("login_stts") = "OFFLINE" Then
                    strim &= "<img src=""images/ico_offline.png"">"
                End If
                strim &= "  </td>"
                strim &= "<td>"
                strim &= rdr("username_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("name_")
                strim &= "</td>"
                strim &= "<td>"
                strim &= "MNG"
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("mng_name")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("phone_number")
                strim &= "</td>"
                strim &= "<td>"
                strim &= rdr("email_id")
                strim &= "</td>"
              
                strim &= "<td>"
                strim &= "<a href=""edit_user_info.aspx?lid=" & rdr("id") & "&Sed adipiscing dictum sem non elementum. Nullam eget eros eu ligula imperdiet dictum quis ac purus. Donec condimentum erat vitae libero blandit suscipit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut euismod lacinia neque ac mollis.html ""> Manage </a>"
                strim &= "</td>"
                strim &= "</tr>"
            End While
            strim &= "</table>"
            disp_users.InnerHtml = strim
        End If
    End Sub
End Class

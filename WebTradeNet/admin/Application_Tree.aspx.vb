Imports System.Data.SqlClient
Partial Class admin_Application_Tree
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer = 0
        Dim tot_users As Integer = 0
        Dim tot_mngs As Integer = 0
        Dim strim As String = ""

        '--------- Get All Users
        command("sp_get_users_by_dept")
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_users = tot_users + 1
        End While

        Dim arr_user_depts(tot_users + 1) As String
        Dim arr_user_names(tot_users + 1) As String

        command("sp_get_users_by_dept")
        rdr = cmd.ExecuteReader
        While rdr.Read
            arr_user_depts(i) = rdr("dept_name")
            arr_user_names(i) = rdr("username_")
            i = i + 1
        End While
        i = 0

        '------------Get All Managements
        command("sp_get_managements")
        rdr = cmd.ExecuteReader
        While rdr.Read
            tot_mngs = tot_mngs + 1
        End While
        Dim arr_mngs(tot_mngs + 1) As String
        i = 0
        command("sp_get_managements")
        rdr = cmd.ExecuteReader
        While rdr.Read
            arr_mngs(i) = rdr("mng_name")
            i = i + 1
        End While

        i = 0
        '----------------------------------

        strim &= "<ul id=""sitemap"">"
        strim &= "<li><a href=""JavaScript:Return false()""> ADMIN</a>"
        strim &= "<ul>"
        While i < tot_mngs
            Dim i2 As Integer = 0

            strim &= "<li>"
            strim &= "<a href=""JavaScript:Return false()"">" & arr_mngs(i) & "</a>"
            command("sp_get_dept_by_mng_name")
            cmd.Parameters.AddWithValue("@mng_name", arr_mngs(i))
            rdr = cmd.ExecuteReader
            strim &= "<ul>"
            While rdr.Read
                i2 = 0
                strim &= "<li>"
                strim &= "<a href=""JavaScript:Return false()"">" & rdr("dept_name") & "</a>"
                strim &= "<ul>"
                While i2 < tot_users

                    If rdr("dept_name") = arr_user_depts(i2) Then
                        strim &= "<li><a href=""JavaScript:Return false()"">" & arr_user_names(i2) & "</a></li>"
                    End If
                    i2 = i2 + 1

                End While
                strim &= "</ul>"
                strim &= "</li>"
            End While
            strim &= "</ul>"
            strim &= "</li>"
            i = i + 1

        End While
        strim &= "</ul>"
        strim &= "</li>"
        strim &= "<ul>"

        Disp_result.innerhtml = strim
    End Sub
End Class

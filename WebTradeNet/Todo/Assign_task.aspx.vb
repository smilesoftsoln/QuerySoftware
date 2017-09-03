Imports System.Data.SqlClient
Imports System.Data

Partial Class Assign
    Inherits System.Web.UI.Page
    Dim LoggedInUserType As String = "MNG"
    Dim emps As SqlDataReader
    Dim probj As New projecterNM.projectercon
    Dim sqlQuery As String = ""
    Dim nbr_of_items As Integer = 0
    Dim taskortodo As Integer = 1 '1 = Add Task, 2 = Add ToDo
    Dim loadOnce As Boolean = False
    Dim loginerID As Integer = 0
    Dim loginerType As String = ""
    Dim loginTypes As ArrayList = New ArrayList()
    Dim deptLoginTypes As ArrayList = New ArrayList()
    Dim branchLoginTypes As ArrayList = New ArrayList()



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '        Dim probj As New projecterNM.projectercon
        '       SqlDataSource1.ConnectionString = probj.con.ConnectionString
        loginerID = Session.Item("loginerID")
        loginerType = Session.Item("loginerTYP")
        lbl_id.Text = loginerID
        loginTypes.Add("DE")
        loginTypes.Add("BE")
        loginTypes.Add("BH")
        loginTypes.Add("HOD")
        loginTypes.Add("SRMNG")
        loginTypes.Add("SRBM")
        loginTypes.Add("MNG")

        deptLoginTypes.Add("DE")
        deptLoginTypes.Add("HOD")
        deptLoginTypes.Add("SRMNG")

        branchLoginTypes.Add("BE")
        branchLoginTypes.Add("BH")
        branchLoginTypes.Add("SRBM")
        If Session.Item("loginerTYP") = "ADMIN" Then
            taskortodo = 2
            cal_endDate.Visible = False
        Else
            If loginTypes.Contains(loginerType) = False Then
                Response.Redirect("unauthorisedaccess.aspx")
            Else
                taskortodo = 1
            End If
        End If
        Panel4.Visible = False
        Panel1.Visible = False
        Panel3.Visible = False
        Pnl_Type.Visible = True
        pnl_month.Visible = False
        Pnl_week.Visible = False
        If taskortodo = 1 Then          '1=Task
            Pnl_Type.Visible = False
            pnl_month.Visible = False
            Pnl_week.Visible = False
        Else                            '2=Todo
            Pnl_Type.Visible = True
            pnl_month.Visible = True
            Pnl_week.Visible = True
        End If
        If loginerType = "SRMNG" Then
            setSrmng()
        End If
        If loginerType = "SRBM" Then
            setSrbm()
        End If
        If loginerType = "HOD" Then
            sethod()
        End If
        If loginerType = "BH" Then
            setBH()
        End If

        If Convert.ToInt16(Session.Item("ddl_user")) <> 2 Then
            Session.Add("ddl_user", 2)
            setUsers()
        Else
            'ddl_selectUser.Items.Clear()
            setUsers()
        End If
        setDatePanels()
        Session.Add("srmng_state", 2)
        Session.Add("ddl_user", 2)
        Session.Add("srbm_state", 2)
        Session.Add("hod_state", 2)
        Session.Add("bh_state", 2)

        'tmp code



    End Sub


    Protected Sub ddl_selectUser_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_selectUser.SelectedIndexChanged
        If ddl_selectUser.SelectedValue = 1 Then 'MNG
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = False

            'Populate ddl_SelectEmp with Sr Managers only

            sqlQuery = "select id, name_ from tbl_loginer_master where post_ = 'MNG'"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_emp.SelectedIndex = 0
            End If
        ElseIf ddl_selectUser.SelectedValue = 2 Then 'SRMNG
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = False

            'Populate ddl_SelectEmp with Sr Managers only

            sqlQuery = "select id, name_ from tbl_loginer_master where post_ = 'SRMNG'"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_emp.SelectedIndex = 0
            End If
        ElseIf ddl_selectUser.SelectedValue = 3 Then 'SRBM
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = False
            sqlQuery = "select id, name_ from tbl_loginer_master where post_ = 'SRBM'"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_emp.SelectedIndex = 0
            End If
        ElseIf ddl_selectUser.SelectedValue = 4 Then 'HOD
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = True

            sqlQuery = "select id, dept_name from tbl_dept_master order by dept_name asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_dept.Items.Clear()
            While emps.Read
                ddl_select_dept.Items.Add(emps("dept_name"))
                ddl_select_dept.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_dept.SelectedIndex = 0
            End If

            sqlQuery = "select id, name_ from tbl_loginer_master where post_='HOD' and forign_id=" + ddl_select_dept.SelectedValue.ToString
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
        ElseIf ddl_selectUser.SelectedValue = 5 Then 'BH
            Panel4.Visible = True
            Panel1.Visible = True
            Panel3.Visible = False

            sqlQuery = "select id, branch_name from tbl_branch_master order by branch_name asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_branch.Items.Clear()
            While emps.Read
                ddl_select_branch.Items.Add(emps("branch_name"))
                ddl_select_branch.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_branch.SelectedIndex = 0
            End If

            sqlQuery = "select id, name_ from tbl_loginer_master where post_='BH' and forign_id = " + ddl_select_branch.SelectedValue.ToString
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
        ElseIf ddl_selectUser.SelectedValue = 6 Then 'DE
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = True


            sqlQuery = "select id, dept_name from tbl_dept_master order by dept_name asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_dept.Items.Clear()
            While emps.Read
                ddl_select_dept.Items.Add(emps("dept_name"))
                ddl_select_dept.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_dept.SelectedIndex = 0
            End If

            sqlQuery = "select id, name_ from tbl_loginer_master where post_='DE' and forign_id=" + ddl_select_dept.SelectedValue.ToString
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
        ElseIf ddl_selectUser.SelectedValue = 7 Then 'BE
            Panel4.Visible = True
            Panel1.Visible = True
            Panel3.Visible = False

            sqlQuery = "select id, branch_name from tbl_branch_master order by branch_name asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_branch.Items.Clear()
            While emps.Read
                ddl_select_branch.Items.Add(emps("branch_name"))
                ddl_select_branch.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_branch.SelectedIndex = 0
            End If

            sqlQuery = "select id, name_ from tbl_loginer_master where post_='BE' and forign_id = " + ddl_select_branch.SelectedValue.ToString
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
        End If
    End Sub

    Protected Sub Btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_submit.Click

        If taskortodo = 1 Then
            If cal_endDate.SelectedDate < Now.Date Then
                Exit Sub
            End If
        End If

        Dim startDate As projecterNM.DBField = New projecterNM.DBField
        startDate.fieldName = "createdatetime"
        startDate.dataType = 1
        startDate.value = getDateTimeInSQLFormat(System.DateTime.Now)

        Dim endDate As projecterNM.DBField = New projecterNM.DBField
        endDate.dataType = 1
        Dim endTime As String = " " + ddl_Hours.SelectedValue + ":" + DDl_Minutes.SelectedValue + ":00 " + dd_AMPM.SelectedValue
        endDate.value = getDateInSQLFormat(cal_endDate.SelectedDate) + endTime
        endDate.fieldName = "enddatetime"

        Dim creator As projecterNM.DBField = New projecterNM.DBField
        creator.dataType = 2
        creator.value = lbl_id.Text
        creator.fieldName = "creator"

        Dim assignedTo As projecterNM.DBField = New projecterNM.DBField
        assignedTo.dataType = 2
        assignedTo.value = ddl_select_emp.SelectedValue
        assignedTo.fieldName = "assignedto"

        Dim statusId As projecterNM.DBField = New projecterNM.DBField
        statusId.dataType = 2
        statusId.value = "1"
        statusId.fieldName = "statusid"

        Dim priorityId As projecterNM.DBField = New projecterNM.DBField
        priorityId.dataType = 2
        priorityId.value = getPriority()
        priorityId.fieldName = "priorityid"

        Dim DeptId As projecterNM.DBField = New projecterNM.DBField
        DeptId.dataType = 2
        DeptId.value = ""
        DeptId.fieldName = "deptid"
        Dim post As String = ""

        'modification
        Dim Branchid As projecterNM.DBField = New projecterNM.DBField
        Branchid.dataType = 2
        Branchid.value = ""
        Branchid.fieldName = "branchid"
        'Dim post1 As String = ""
        'complete

        Dim LevelId As projecterNM.DBField = New projecterNM.DBField
        LevelId.dataType = 2
        LevelId.value = ""
        LevelId.fieldName = "levelid"

        Dim addRec As Queue = New Queue()

        'Get Dept_id and Post
        If deptLoginTypes.Contains(loginerType) Then
            sqlQuery = "select forign_id, post_ from tbl_loginer_master where id = " + ddl_select_emp.SelectedValue
            emps = probj.SelectQuery(sqlQuery)
            If emps.Read Then
                Branchid.value = 0
                DeptId.value = emps("forign_id").ToString
                post = emps("post_")
            Else
                Branchid.value = 0
                DeptId.value = "0"
                post = emps("post_")
            End If
        Else
            If branchLoginTypes.Contains(loginerType) Then
                sqlQuery = "select forign_id, post_ from tbl_loginer_master where id = " + ddl_select_emp.SelectedValue()
                'modification
                'Get Branchid and Post
                emps = probj.SelectQuery(sqlQuery)
                If emps.Read Then
                    DeptId.value = "0"
                    Branchid.value = emps("forign_id").ToString
                    post = emps("post_")
                Else
                    Branchid.value = "0"
                    DeptId.value = "0"
                    post = emps("post_")
                End If
            End If
            'completed
        End If

        

        'Get Level_id
        sqlQuery = "select id from tbl_levels where short_key  = '" + post.Trim() + "'"

        emps = probj.SelectQuery(sqlQuery)
        If emps.Read Then
            LevelId.value = emps("id").ToString
        End If

        Dim NextTaskId As projecterNM.DBField = New projecterNM.DBField
        If taskortodo = 1 Then
            NextTaskId.dataType = 2
            NextTaskId.value = getNextTaskId().ToString()
        ElseIf taskortodo = 2 Then
            NextTaskId.dataType = 2
            NextTaskId.value = getNextTodoMasterId().ToString()
        End If
        NextTaskId.fieldName = "id"

        Dim descField As projecterNM.DBField = New projecterNM.DBField
        descField.dataType = 1
        descField.value = txt_desc.Text
        descField.fieldName = """desc"""

        Dim subjectField As projecterNM.DBField = New projecterNM.DBField
        subjectField.dataType = 1
        subjectField.value = tb_subject.Text
        subjectField.fieldName = "subject"

        'modification
        Dim remarkField As projecterNM.DBField = New projecterNM.DBField
        remarkField.dataType = 1
        remarkField.value = " "
        remarkField.fieldName = "remark"
        'completed

        If taskortodo = 1 Then
            addRec.Enqueue(NextTaskId)
            addRec.Enqueue(startDate)
            addRec.Enqueue(endDate)
            addRec.Enqueue(subjectField)
            addRec.Enqueue(descField)
            addRec.Enqueue(creator)
            addRec.Enqueue(assignedTo)
            addRec.Enqueue(statusId)
            addRec.Enqueue(priorityId)
            addRec.Enqueue(DeptId)
            addRec.Enqueue(LevelId)
            addRec.Enqueue(Branchid)
            addRec.Enqueue(remarkField)
            probj.InsertRecordIntoTable("tbl_tasks", addRec, False)
        End If

        If taskortodo = 2 Then
            Dim periodtypeField As projecterNM.DBField = New projecterNM.DBField
            periodtypeField.dataType = 1
            periodtypeField.value = ddl_periodtype.SelectedValue
            periodtypeField.fieldName = "periodtype"

            Dim periodentityField As projecterNM.DBField = New projecterNM.DBField
            periodentityField.dataType = 1
            periodentityField.fieldName = "periodentity"

            'Get Dept_Id and Post for MNG when Admin has logged in for adding Todo's
            If ddl_selectUser.SelectedValue = 1 Then  'MNG
                Branchid.value = "0"
                DeptId.value = "0"
                post = "MNG"
            End If

            If Convert.ToInt16(ddl_periodtype.SelectedValue) = 1 Then   'periodtype=1 means Daily Task
                periodentityField.value = 0
            End If

            If Convert.ToInt16(ddl_periodtype.SelectedValue) = 3 Then   'periodtype=3 means Monthly Task
                periodentityField.value = DDl_monthday.SelectedValue
            End If

            If Convert.ToInt16(ddl_periodtype.SelectedValue) = 2 Then   'periodtype=2 means Weekly Task
                periodentityField.value = DDL_weekday.SelectedValue
            End If

            endDate.fieldName = "validupto"

            Dim endtimeField As projecterNM.DBField = New projecterNM.DBField
            endtimeField.dataType = 2
            endtimeField.value = ddl_Hours.SelectedValue + ":" + DDl_Minutes.SelectedValue + ":00 " + dd_AMPM.SelectedValue
            endtimeField.fieldName = "endtime"

            addRec.Enqueue(NextTaskId)
            addRec.Enqueue(periodtypeField)
            addRec.Enqueue(periodentityField)
            addRec.Enqueue(creator)
            addRec.Enqueue(endDate)
            addRec.Enqueue(subjectField)
            addRec.Enqueue(descField)
            'addRec.Enqueue(DeptId)
            'addRec.Enqueue(Branchid)
            'addRec.Enqueue(remarkField)
            probj.InsertRecordIntoTable("tbl_todo_master", addRec, True)

            'Add records to tbl_todo_details
            Dim hr = 0
            If dd_AMPM.SelectedValue = "Pm" Then
                If ddl_Hours.SelectedValue < 12 Then
                    hr = ddl_Hours.SelectedValue + 12
                Else
                    hr = 0
                End If
            Else
                hr = ddl_Hours.SelectedValue
            End If
            Dim period As Date = DateAdd(DateInterval.Day, 1, New Date(Now.Year, Now.Month, Now.Day, hr, DDl_Minutes.SelectedValue, 0))

            If ddl_periodtype.SelectedValue = 2 Then
                While (period.DayOfWeek <> DDL_weekday.SelectedValue)
                    period = DateAdd(DateInterval.Day, 1, period)
                End While
            ElseIf ddl_periodtype.SelectedValue = 3 Then
                While (period.Day <> DDl_monthday.SelectedValue)
                    period = DateAdd(DateInterval.Day, 1, period)
                End While
            End If


            Dim periodend As Date = DateAdd(DateInterval.Month, 15, period)
            Dim holidays As ArrayList = New ArrayList

            sqlQuery = "select holidaydate from tbl_holidays"
            emps = probj.SelectQuery(sqlQuery)
            While emps.Read
                holidays.Add(emps("holidaydate").ToString)
            End While
            addRec.Clear()
            Dim masterId = NextTaskId.value
            While (period <= periodend)
                If (period.Day = periodend.Day And period.Month = periodend.Month And period.Year = periodend.Year) Then
                    period = DateAdd(DateInterval.Day, 1, period)
                Else
                    If holidays.Contains(DateValue(period.ToString).ToString) = False Then
                        'Add task to detail
                        NextTaskId.value = getNextTodoDetailId().ToString()

                        Dim masterIdField As projecterNM.DBField = New projecterNM.DBField
                        masterIdField.dataType = 2
                        masterIdField.value = masterId
                        masterIdField.fieldName = "master_id"

                        endDate.value = getDateTimeInSQLFormat(period)
                        endDate.fieldName = "enddatetime"

                        'Get Dept_id and Post
                        If deptLoginTypes.Contains(ddl_selectUser.SelectedItem.Text) Then
                            sqlQuery = "select forign_id, post_ from tbl_loginer_master where id = " + ddl_select_emp.SelectedValue
                            emps = probj.SelectQuery(sqlQuery)
                            If emps.Read Then
                                Branchid.value = 0
                                DeptId.value = emps("forign_id").ToString
                                post = emps("post_")
                            End If
                        Else
                            If branchLoginTypes.Contains(ddl_selectUser.SelectedItem.Text) Then
                                sqlQuery = "select forign_id, post_ from tbl_loginer_master where id = " + ddl_select_emp.SelectedValue()
                                'modification
                                'Get Branchid and Post
                                emps = probj.SelectQuery(sqlQuery)
                                If emps.Read Then
                                    DeptId.value = 0
                                    Branchid.value = emps("forign_id").ToString
                                    post = emps("post_")
                                End If
                                'completed
                            End If
                        End If

                        'Get Level_id
                        sqlQuery = "select id from tbl_levels where short_key  = '" + post.Trim() + "'"

                        emps = probj.SelectQuery(sqlQuery)
                        If emps.Read Then
                            LevelId.value = emps("id").ToString
                        End If

                        addRec.Enqueue(NextTaskId)
                        addRec.Enqueue(masterIdField)
                        addRec.Enqueue(endDate)
                        addRec.Enqueue(assignedTo)
                        addRec.Enqueue(DeptId)
                        addRec.Enqueue(Branchid)
                        addRec.Enqueue(statusId)
                        addRec.Enqueue(priorityId)
                        addRec.Enqueue(LevelId)
                        addRec.Enqueue(remarkField)

                        probj.InsertRecordIntoTable("tbl_todo_details", addRec, True)
                        period = DateAdd(DateInterval.Day, 1, period)

                        If ddl_periodtype.SelectedValue = 2 Then
                            While (period.DayOfWeek <> DDL_weekday.SelectedValue)
                                period = DateAdd(DateInterval.Day, 1, period)
                            End While
                        ElseIf ddl_periodtype.SelectedValue = 3 Then
                            While (period.Day <> DDl_monthday.SelectedValue)
                                period = DateAdd(DateInterval.Day, 1, period)
                            End While
                        End If
                    Else
                        period = DateAdd(DateInterval.Day, 1, period)
                    End If
                End If
            End While
        End If
        txt_desc.Text = ""
        tb_subject.Text = ""
        lbl_message.Text = IIf(taskortodo = 1, "Task", "Todo") + " Inserted Successfully"
        Session.Add("srmng_state", 0)
        Session.Add("ddl_user", 0)
        Session.Add("srbm_state", 0)
        Session.Add("hod_state", 0)
        Session.Add("bh_state", 0)
    End Sub

    Protected Function getPriority() As Integer
        Return IIf(RadioButton1.Checked, 2, 1)
    End Function

    Protected Function getNextTaskId() As Integer
        sqlQuery = "select max(id)+1 as maxid from tbl_tasks"
        emps = probj.SelectQuery(sqlQuery)
        If emps.Read Then
            Try
                Return (emps("maxid"))
            Catch ex As InvalidCastException
                Return 1
            End Try
        End If
        Return (0)
    End Function

    Protected Function getNextTodoMasterId() As Integer
        sqlQuery = "select max(id)+1 as maxid from tbl_todo_master"
        emps = probj.SelectQuery(sqlQuery)
        If emps.Read Then
            Try
                Return (emps("maxid"))
            Catch ex As InvalidCastException
                Return 1
            End Try
        End If
        Return (0)
    End Function

    Protected Function getNextTodoDetailId() As Integer
        sqlQuery = "select max(id)+1 as maxid from tbl_todo_details"
        emps = probj.SelectQuery(sqlQuery)
        If emps.Read Then
            Try
                Return (emps("maxid"))
            Catch ex As InvalidCastException
                Return 1
            End Try
        End If
        Return (0)
    End Function

    Protected Function getNextTodoId() As Integer
        sqlQuery = "select max(id)+1 as maxid from tbl_todo_details"
        emps = probj.SelectQuery(sqlQuery)
        If emps.Read Then
            Try
                Return (emps("maxid"))
            Catch ex As InvalidCastException
                Return 1
            End Try
        End If
        Return (0)
    End Function

    Protected Function getDateInSQLFormat(ByVal dt As DateTime) As String
        Dim retval As String = getMonthName(dt.Month) + " " + dt.Day.ToString + " " + dt.Year.ToString '+ " " + dt.ToLongTimeString
        Return retval
    End Function

    Protected Function getDateTimeInSQLFormat(ByVal dt As DateTime) As String
        Dim retval As String = getMonthName(dt.Month) + " " + dt.Day.ToString + " " + dt.Year.ToString + " " + dt.ToLongTimeString
        Return retval
    End Function

    Protected Function getMonthName(ByVal mon As Integer) As String
        Return IIf(mon = 1, "January", IIf(mon = 2, "February", IIf(mon = 3, "March", IIf(mon = 4, "April", IIf(mon = 5, "May", IIf(mon = 6, "June", IIf(mon = 7, "July", IIf(mon = 8, "August", IIf(mon = 9, "September", IIf(mon = 10, "October", IIf(mon = 11, "November", "December")))))))))))
    End Function

    Protected Sub ddl_select_dept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_select_dept.SelectedIndexChanged
        sqlQuery = "select id, name_ from tbl_loginer_master where forign_id = " + ddl_select_dept.SelectedValue + " and post_ = " + IIf(ddl_selectUser.SelectedValue = 4, "'HOD'", "'DE'")
        emps = probj.SelectQuery(sqlQuery)
        nbr_of_items = 0
        ddl_select_emp.Items.Clear()
        Panel3.Visible = True
        Panel1.Visible = True
        While emps.Read
            ddl_select_emp.Items.Add(emps("name_"))
            ddl_select_emp.Items(nbr_of_items).Value = emps("id")
            nbr_of_items = nbr_of_items + 1
        End While
    End Sub

   

    Protected Sub ddl_select_branch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_select_branch.SelectedIndexChanged
        sqlQuery = "select id, name_ from tbl_loginer_master where forign_id = " + ddl_select_branch.SelectedValue + " and post_ = " + IIf(ddl_selectUser.SelectedValue = 5, "'BH'", "'BE'")
        emps = probj.SelectQuery(sqlQuery)
        nbr_of_items = 0
        ddl_select_emp.Items.Clear()
        Panel4.Visible = True
        Panel1.Visible = True
        While emps.Read
            ddl_select_emp.Items.Add(emps("name_"))
            ddl_select_emp.Items(nbr_of_items).Value = emps("id")
            nbr_of_items = nbr_of_items + 1
        End While
    End Sub

    Protected Sub ddl_periodtype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_periodtype.SelectedIndexChanged
        setPanels()
        setDatePanels()
    End Sub

    Protected Sub setDatePanels()
        If ddl_periodtype.SelectedValue = 1 Then
            Pnl_week.Visible = False
            pnl_month.Visible = False
        End If
        If ddl_periodtype.SelectedValue = 2 Then
            Pnl_week.Visible = True
            pnl_month.Visible = False
        End If
        If ddl_periodtype.SelectedValue = 3 Then
            pnl_month.Visible = True
            Pnl_week.Visible = False
        End If
    End Sub
    
    Protected Sub cal_endDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cal_endDate.SelectionChanged
        setPanels()
        setDatePanels()
    End Sub

    Protected Sub setPanels()
        If ddl_selectUser.SelectedValue = "1" Then 'MNG
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = False
        ElseIf ddl_selectUser.SelectedValue = "2" Then 'SRMNG
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = False
        ElseIf ddl_selectUser.SelectedValue = "3" Then 'SRBM
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = False
        ElseIf ddl_selectUser.SelectedValue = "4" Then 'HOD
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = True
        ElseIf ddl_selectUser.SelectedValue = "5" Then 'BH
            Panel4.Visible = True
            Panel1.Visible = True
            Panel3.Visible = False
        ElseIf ddl_selectUser.SelectedValue = "6" Then 'DE
            Panel4.Visible = False
            Panel1.Visible = True
            Panel3.Visible = True
        ElseIf ddl_selectUser.SelectedValue = "7" Then 'BE
            Panel4.Visible = True
            Panel1.Visible = True
            Panel3.Visible = False
        End If
    End Sub

    Protected Sub cal_endDate_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles cal_endDate.VisibleMonthChanged
        setPanels()
        setDatePanels()
    End Sub

    Protected Sub setUsers()
        If loginerType = "MNG" Then
            Session.Add("ddl_user", 2)
            sqlQuery = "select id, short_key from tbl_levels where id > 1"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_selectUser.Items.Clear()
            While emps.Read
                ddl_selectUser.Items.Add(emps("short_key"))
                ddl_selectUser.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_selectUser.SelectedIndex = 0
            End If
        ElseIf loginerType = "ADMIN" Then
            Session.Add("ddl_user", 2)
            sqlQuery = "select id, short_key from tbl_levels"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_selectUser.Items.Clear()
            While emps.Read
                ddl_selectUser.Items.Add(emps("short_key"))
                ddl_selectUser.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_selectUser.SelectedIndex = 0
            End If

            'Populate Employees
            sqlQuery = "select id, name_ from tbl_loginer_master where post_ = 'MNG'"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            Panel3.Visible = True
            Panel1.Visible = True
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_emp.SelectedIndex = 0
            End If

            Panel1.Visible = True
            Panel2.Visible = True
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = True
        ElseIf loginerType = "SRMNG" Then
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = True
        ElseIf loginerType = "SRBM" Then
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = True
        ElseIf loginerType = "HOD" Then
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = True
        ElseIf loginerType = "BH" Then
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Panel5.Visible = True
        ElseIf loginerType = "DE" Then
        ElseIf loginerType = "BE" Then

        End If
    End Sub

    Protected Sub setSrmng()
        If Session.Item("srmng_state") <> 2 Then
            Session.Add("srmng_state", 2)
            Dim sqlQuery As String = "select l.id as id, l.name_ as name_ from tbl_loginer_master l, tbl_srmng_master s where l.forign_id = s.dept_id and l.post_ in ('HOD','DE') and srmgr_id = " + Convert.ToString(loginerID) + " order by name_ asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_emp.SelectedIndex = 0
            End If
        End If
    End Sub

    Protected Sub setSrbm()
        If Session.Item("srbm_state") <> 2 Then
            Session.Add("srbm_state", 2)
            Dim sqlQuery As String = "select l.id as id, l.name_ as name_ from tbl_loginer_master l, tbl_srbm_master s where l.forign_id = s.branch_id and l.post_ in ('BH','BE') and s.srbm_id = " + Convert.ToString(loginerID) + " order by name_ asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_emp.SelectedIndex = 0
            End If
        End If
    End Sub
    Protected Sub sethod()
        If Session.Item("hod_state") <> 2 Then
            Session.Add("hod_state", 2)
            Dim sqlQuery As String = "select l.id as id, l.name_ as name_ from tbl_loginer_master l, tbl_dept_master s where s.id = l.forign_id and l.post_ in ('DE') and s.hod_loginer_id = " + Convert.ToString(loginerID) + " order by name_ asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_emp.SelectedIndex = 0
            End If
        End If
    End Sub
    Protected Sub setBH()
        If Session.Item("bh_state") <> 2 Then
            Session.Add("bh_state", 2)
            Dim sqlQuery As String = "select l.id as id, l.name_ as name_ from tbl_loginer_master l, tbl_loginer_master s where s.forign_id = l.forign_id and l.post_ in ('BE') and s.id = " + Convert.ToString(loginerID) + " order by name_ asc"
            emps = probj.SelectQuery(sqlQuery)
            nbr_of_items = 0
            ddl_select_emp.Items.Clear()
            While emps.Read
                ddl_select_emp.Items.Add(emps("name_"))
                ddl_select_emp.Items(nbr_of_items).Value = emps("id")
                nbr_of_items = nbr_of_items + 1
            End While
            If nbr_of_items > 0 Then
                ddl_select_emp.SelectedIndex = 0
            End If
        End If
    End Sub

    Protected Sub ddl_select_emp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_select_emp.SelectedIndexChanged
        Dim sel As Int16 = ddl_select_emp.SelectedIndex
        ddl_select_emp.SelectedIndex = sel
    End Sub

    
End Class

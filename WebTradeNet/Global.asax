<%@ Application Language="VB" %>

<script runat="server">
   
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
          
        Dim escaltimer As New System.Timers.Timer()
        escaltimer.Interval = 60000 * 1
        escaltimer.Enabled = True
        'Add handler for Elapsed event
        AddHandler escaltimer.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf HandlerSub)
        escaltimer.Stop()
         escaltimer.Start()
        '  Dim escaltimer1 As New System.Timers.Timer()
        'escaltimer1.Interval = 60000 * 1
        ' escaltimer1.Enabled = True
        ' 'Add handler for Elapsed event
        '   AddHandler escaltimer1.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf HandlerSub1)
        'escaltimer1.Stop()
        '  escaltimer1.Start()
        Application("ActiveUsers") = 0
    End Sub
    
    
    Sub HandlerSub1(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Dim str1 As String = DateTime.Now.ToString("HH:mm")
        Dim str2 As String = DateTime.Today.AddHours(13).AddMinutes(16).ToString("HH:mm")
        
        If (str1.Equals(str2)) Then
            somman_functions_NM.commen_funcs.auto_mail_branch() 'actual live
           
       
        End If
    End Sub
    
    Sub HandlerSub(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
    
        
        
        
        somman_functions_NM.commen_funcs.Escalate_query() 'actual live
        somman_functions_NM.commen_funcs.escalateTask() 'actual live
        Dim str1 As String = DateTime.Now.ToString("HH:mm")
        Dim str2 As String = DateTime.Today.AddHours(18).AddMinutes(30).ToString("HH:mm")
        
        If (str1.Equals(str2)) Then
            somman_functions_NM.commen_funcs.auto_mail_dept() 'actual live
           
       
        End If
        str2 = DateTime.Today.AddHours(18).AddMinutes(15).ToString("HH:mm")
        
        If (str1.Equals(str2)) Then
            somman_functions_NM.commen_funcs.TaskEOD_Mail_assign_to() 'actual live
            somman_functions_NM.commen_funcs.TaskEOD_Mail_creator() 'actual live
         
        End If
 
        str2 = DateTime.Today.AddHours(18).AddMinutes(24).ToString("HH:mm")
        
        If (str1.Equals(str2)) Then
            somman_functions_NM.commen_funcs.auto_mail_branch() 'actual live
         
        End If
        
        
        'somman_functions_NM.commen_funcs.TaskEOD_Mail_assign_to() '
        'somman_functions_NM.commen_funcs.TaskEOD_Mail_creator() 'comment while making live....
    End Sub
 
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Application.Lock()
        Application("ActiveUsers") = CInt(Application("ActiveUsers")) + 1
        Application.UnLock()
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        Application.Lock()
        Application("ActiveUsers") = CInt(Application("ActiveUsers")) - 1
        Application.UnLock()
    End Sub
        
        
</script>

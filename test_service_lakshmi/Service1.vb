Imports System.Threading

Public Class Service1
    Private workerThread1 As Thread
    Private workerThread2 As Thread
    Dim isRunning As Boolean
    Dim connectionString As String
    Protected Overrides Sub OnStart(ByVal args() As String)
        Utility.Log("Service started at the time " + DateTime.Now)
        isRunning = True
        workerThread1 = New Thread(AddressOf Worker_Update)
        workerThread1.Start()
        workerThread2 = New Thread(AddressOf Worker_Process)
        workerThread2.Start()
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
    End Sub

    Protected Overrides Sub OnStop()
        Utility.Log("Service stopped at the time " + DateTime.Now)
        isRunning = False
        workerThread1.Abort()
        workerThread2.Abort()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub
    Private Sub Worker_Update()
        Try
            While (True)
                Dim currentTime As DateTime = DateTime.Now
                If currentTime.Hour >= 3 AndAlso currentTime.Hour <= 6 Then
                    Continue While
                End If
                While (isRunning)
                    Utility.Log("Worker_Update started at the time " + DateTime.Now)
                    Utility.ProductUpdate(DateTime.Now.Minute)
                    Utility.Log("Worker_Update completed at the time " + DateTime.Now)
                End While
                Thread.Sleep(60000)
            End While

        Catch ex As Exception
            Utility.Log("Exception occuured in Worker_Update" + ex.Message)
        End Try

    End Sub

    Private Sub Worker_Process()
        Try
            While (True)
                Dim currentTime As DateTime = DateTime.Now
                If currentTime.Hour >= 3 AndAlso currentTime.Hour <= 6 Then
                    Continue While
                End If
                While (isRunning)
                    Utility.Log("Worker_Process started at the time " + DateTime.Now)
                    Utility.ProductProcess()
                    Utility.Log("Worker_Process completed at the time " + DateTime.Now)
                End While
                Thread.Sleep(120000)
            End While
        Catch ex As Exception
            Utility.Log("Exception occuured in Worker_Process" + ex.Message)
        End Try

    End Sub
End Class

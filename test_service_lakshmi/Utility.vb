Imports System.Configuration
Imports System.Data.SqlClient

Module Utility
    Public ReadOnly stConnection As String = ConfigurationManager.ConnectionStrings("sqlConnection").ToString()

    Public Sub Log(stLog As String)
        Using connection As New SqlConnection(stConnection)
            connection.Open()

            Using command As New SqlCommand("sp_integrationlog", connection)
                command.CommandType = CommandType.StoredProcedure

                command.Parameters.AddWithValue("@log", stLog)

                command.ExecuteNonQuery()
            End Using

            connection.Close()
        End Using
    End Sub
    Public Sub ProductUpdate(stProcessMins As String)
        Using connection As New SqlConnection(stConnection)
            connection.Open()

            Using command As New SqlCommand("sp_product_update", connection)
                command.CommandType = CommandType.StoredProcedure

                command.Parameters.AddWithValue("@processmin", stProcessMins)

                command.ExecuteNonQuery()
            End Using

            connection.Close()
        End Using
    End Sub
    Public Sub ProductProcess()
        Using connection As New SqlConnection(stConnection)
            connection.Open()

            Using command As New SqlCommand("sp_product_process", connection)
                command.CommandType = CommandType.StoredProcedure
                command.ExecuteNonQuery()
            End Using

            connection.Close()
        End Using
    End Sub

End Module

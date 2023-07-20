Imports MySql.Data.MySqlClient
Module connection
    'create a public function and set your MySQL Connection 
    Public Function mysqlconnection() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;database=payrolldb")
    End Function

    'pass the value of mysqlconnection() as MySQL connection to con.
    Public con As MySqlConnection = mysqlconnection()

    'declaring the variables string
    Public sql As String
    Public result As String

    'declaring the classes
    Public cmd As New MySqlCommand
    Public dt As New DataTable
    Public ds As New DataSet
    Public da As New MySqlDataAdapter
    'create a sub procedure named "login" and the parameter's type is string
    Public Sub loginUser(ByVal sql As String)
        Try
            'declaring the variable as integer
            Dim maxrow As Integer

            'open the connection
            con.Open()
            'every click the button the dt will set a new datatable so that it will retrieve new data in the table
            dt = New DataTable
            'set a command
            With cmd
                'holds the data 
                .Connection = con
                .CommandText = sql
            End With
            'retriving the data
            da.SelectCommand = cmd
            da.Fill(dt)

            'pass the total value of rows in the table to a variable maxrow
            maxrow = dt.Rows.Count

            'conditioning the total value of rows in the table
            'if the total value of rows in the table is greater than 0 then the result is true
            ' and if not, the result is false
            If maxrow > 0 Then
                '```````````````````````````````````````````````````````````````````````````````````````````` the record of the current row and the current column in the current table.
                MsgBox(dt.Rows(0).Item(1))
                With Form1
                    .Show()
                    .Focus()
                End With
                login.Hide()
            Else
                'the result is false
                MsgBox("Account does not exist.")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        da.Dispose()
    End Sub
    'create a sub procedure named "create" and the parameter's type is string
    Public Sub createsub(ByVal sql As String)
        Try
            'open the connection
            con.Open()
            'set your command
            With cmd
                'holds the data to be executed
                .Connection = con
                .CommandText = sql
                'execute the data 
                cmd.ExecuteNonQuery()


            End With
        Catch ex As Exception
            ' MsgBox("Double Entry, Try Again.")
        End Try
        con.Close()
    End Sub
    'create a sub procedure named "create" and the parameter's type is string
    Public Sub create(ByVal sql As String)
        Try
            'open the connection
            con.Open()
            'set your command
            With cmd
                'holds the data to be executed
                .Connection = con
                .CommandText = sql
                'execute the data 
                result = cmd.ExecuteNonQuery

                'coditioning the result whether succesfull or failed when it is executed.
                If result = 0 Then
                    'the execution of data is failed
                    MsgBox("Failed to save!")
                Else
                    'the executed data is succesfull
                    MsgBox("Data has been saved.")
                End If
            End With
        Catch ex As Exception
            MsgBox("Double Entry. Try Again.")
        End Try
        con.Close()
    End Sub
    Public Sub updates(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            result = cmd.ExecuteNonQuery
            If result Then
                MsgBox("Data has been successfully updated.")
            Else
                MsgBox("Update failed. Try again.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub
    Public Sub reload(ByVal sql As String, ByVal dtg As DataGridView)
        con.Open()
        With cmd
            .Connection = con
            .CommandText = sql
        End With
        dt = New DataTable
        da = New MySqlDataAdapter(sql, con)
        da.Fill(dt)
        dtg.DataSource = dt
        da.Dispose()
        con.Close()

    End Sub
    Public Sub filltxt(ByVal sql As String)
        con.Open()
        Try
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            dt = New DataTable
            da = New MySqlDataAdapter(sql, con)
            da.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        da.Dispose()
        con.Close()


    End Sub
    Public Sub deletes(ByVal sql As String)
        Try
            'open the connection
            con.Open()
            'set your command
            With cmd
                'holds the data to be executed
                .Connection = con
                .CommandText = sql
                'execute the data 
                result = cmd.ExecuteNonQuery

                'coditioning the result whether succesfull or failed when it is executed.
                'If result = 0 Then
                '    'the execution of data is failed
                '    MsgBox("Failed to save!")
                'Else
                '    'the executed data is succesfull
                '    MsgBox("Data has been saved.")
                'End If
            End With
        Catch ex As Exception
            MsgBox("Double Entry. Try Again.")
        End Try
        con.Close()
    End Sub
#Region "--------------"
    Public Sub reports(ByVal sql As String, ByVal rptname As String, ByVal crystalRpt As Object)
        Try
            con.Open()
            Dim reportname As String
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            ds = New DataSet
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds)
            reportname = rptname
            Dim reportdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim strReportPath As String
            strReportPath = Application.StartupPath & "\report\" & reportname & ".rpt"
            With reportdoc
                .Load(strReportPath)
                .SetDataSource(ds.Tables(0))
            End With
            With crystalRpt
                .ShowRefreshButton = False
                .ShowCloseButton = False
                .ShowGroupTreeButton = False
                .ReportSource = reportdoc
            End With
        Catch ex As Exception
            MsgBox(ex.Message & "No Crystal Reports have been Installed")
        End Try
        con.Close()
        da.Dispose()
    End Sub
#End Region
End Module

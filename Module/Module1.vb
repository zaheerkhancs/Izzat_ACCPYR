Imports System.Data.SqlClient
Module Module1
    Public cn As New SqlConnection
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public Trans As SqlTransaction

    Public Function Opencn() As SqlConnection
        If cn.State = ConnectionState.Open Then cn.Close()
        cn.ConnectionString = "data Source=.;database=IALimited;Integrated Security=false;User Id=sa;password=sa"
        ' cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\DataBase\Pharma_Data.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True"
        cn.Open()
        Return cn
    End Function

    Public Sub DatasetFill(ByVal str As String, ByVal tableName As String)
        Try
            If ds.Tables.Contains(tableName) = True Then
                ds.Tables(tableName).Clear()
            End If
            cmd.CommandType = CommandType.Text
            cmd.CommandText = str
            cmd.Connection = cn
            da.SelectCommand = cmd
            da.Fill(ds, tableName)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub InsertRecord(ByVal TableName As String, ByVal Fields As String, ByVal values As String)
        Try
            'If cn.State = ConnectionState.Open Then cn.Close()
            'cn.Open()
            cmd.CommandText = "Insert into " & TableName & "(" & Fields & ") values(" & values & ")"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub InsertRecord(ByVal TableName As String, ByVal values As String)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            'cn.Open()
            cmd.CommandText = "Insert into " & TableName & " values(" & values & ")"
            ' MsgBox(cmd.CommandText)
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function InsertRecordTrans(ByVal TableName As String, ByVal values As String, ByVal Trans As SqlTransaction) As Boolean
        Dim bFlage As Boolean = False
        Try

            If cn.State = ConnectionState.Closed Then cn.Open()

            cmd.Transaction = Trans
            cmd.CommandText = "Insert into " & TableName & " values(" & values & ")"

            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            bFlage = True
        Catch ex As Exception
            bFlage = False
        End Try
        Return bFlage
    End Function
    Public Sub InsertRecord(ByVal TableName As String, ByVal values As String, ByVal Trans As SqlTransaction)
        Try

            If cn.State = ConnectionState.Closed Then cn.Open()

            cmd.Transaction = Trans
            cmd.CommandText = "Insert into " & TableName & " values(" & values & ")"

            cmd.Connection = cn
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Trans.Rollback()
        End Try
    End Sub
    Public Sub UpdateRecord(ByVal TableName As String, ByVal Fields As String, ByVal Creteria As String)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()

            cmd.CommandText = "Update " & TableName & " set " & Fields & " where " & Creteria

            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub UpdateRecord(ByVal TableName As String, ByVal Fields As String)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()

            cmd.CommandText = "Update " & TableName & " set " & Fields

            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub UpdateRecord(ByVal TableName As String, ByVal Fields As String, ByVal Creteria As String, ByVal Trans As SqlTransaction)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd.Transaction = Trans
            cmd.CommandText = "Update " & TableName & " set " & Fields & " where " & Creteria

            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'cn.Close()
        Catch ex As Exception
            Trans.Rollback()
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub DeleteRecord(ByVal TableName As String)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()

            cmd.CommandText = "Delete from " & TableName

            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub DeleteRecord(ByVal TableName As String, ByVal Creteria As String)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()

            cmd.CommandText = "Delete from " & TableName & " where " & Creteria

            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function GetMax(ByVal FieldName As String, ByVal TableName As String) As Integer
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            ' cn.Open()
            'Opencn()
            cmd.CommandText = "Select  isnull(Max(" & FieldName & "),0) from " & TableName
            cmd.Connection = cn
            GetMax = cmd.ExecuteScalar + 1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function GetMaxStr(ByVal FieldName As String, ByVal TableName As String, ByVal Creteria As String)
        If cn.State = ConnectionState.Closed Then cn.Open()
        ' cn.Open()
        'Opencn()
        cmd.CommandText = "Select  isnull(Max(" & FieldName & "),0) from " & TableName & " Where " & Creteria
        cmd.Connection = cn

        GetMaxStr = Val(Right(CStr(cmd.ExecuteScalar), 4)) + 1
        ' GetMax = cmd.ExecuteScalar + 1

    End Function


    Public Function GetMaxStr1(ByVal FieldName As String, ByVal TableName As String, ByVal Creteria As String)
        If cn.State = ConnectionState.Closed Then cn.Open()
        ' cn.Open()
        'Opencn()
        cmd.CommandText = "Select  isnull(Max(" & FieldName & "),0) from " & TableName & " Where " & Creteria

        cmd.Connection = cn

        GetMaxStr1 = Val(Right(CStr(cmd.ExecuteScalar), 2)) + 1
        ' GetMax = cmd.ExecuteScalar + 1

    End Function



    Public Function GetValue(ByVal FieldName As String, ByVal TableName As String, ByVal Criateria As String) As String

        Try

        
            If cn.State = ConnectionState.Closed Then cn.Open()
            'cn.Open()
            cmd.CommandText = "Select  " & FieldName & " from " & TableName & " Where " & Criateria
            GetValue = cmd.ExecuteScalar
        Catch ex As Exception
            GetValue = 0
        End Try

    End Function

    Public Function GetValue(ByVal FieldName As String, ByVal TableName As String) As Integer
        If cn.State = ConnectionState.Closed Then cn.Open()
        'cn.Open()
        cmd.CommandText = "Select  " & FieldName & " from " & TableName
        GetValue = cmd.ExecuteScalar
    End Function
    Public Sub TransBegin()
        '  Opencn()
        Trans = cn.BeginTransaction
        ' MsgBox(Trans.GetLifetimeService().ToString)
        cmd.Transaction = Trans
    End Sub

    Public Function GetNewVNO(ByVal table As String, ByVal Field As String, ByVal Dt As Date, ByVal dtf As String)
        '        Dim rs As New ADODB.Recordset


        Dim Y As Int32
        Dim NVNO, NSVNO, RVNO As String
        NSVNO = ""
        Dim mo, ye
        mo = Month(Dt)
        ye = Year(Dt)

        'Select Case mo
        '    Case 1
        '        mo = "Jan"
        '    Case 2
        '        mo = "Feb"
        '    Case 3
        '        mo = "Mar"
        '    Case 4
        '        mo = "Apr"
        '    Case 5
        '        mo = "May"
        '    Case 6
        '        mo = "Jun"
        '    Case 7
        '        mo = "Jul"
        '    Case 8
        '        mo = "Aug"
        '    Case 9
        '        mo = "Sep"
        '    Case 10
        '        mo = "Oct"
        '    Case 11
        '        mo = "Nov"
        '    Case 12
        '        mo = "Dec"
        'End Select
        Y = Year(Dt)

        Dim cmd As New SqlCommand("Select Max(" & Field & ") from " & table & " where " & Field & " like '" & mo & "%' and year(" & dtf & ")=" & Year(Dt), cn)
        '    MsgBox(cmd.CommandText)
        Dim obj As Object = cmd.ExecuteScalar
        If IsDBNull(obj) Then
            NVNO = mo & "" & ye & "00001"
        Else
            RVNO = Val(Right(CStr(cmd.ExecuteScalar), 5)) + 1
            'Dim i As Integer = Len(RVNO)
            Select Case Len(RVNO)
                Case 1
                    NSVNO = "0000" & RVNO
                Case 2
                    NSVNO = "000" & RVNO
                Case 3
                    NSVNO = "00" & RVNO
                Case 4
                    NSVNO = "0" & RVNO
                Case 5
                    NSVNO = RVNO
            End Select
            NVNO = mo & "" & ye & "" & NSVNO
        End If
        GetNewVNO = NVNO
    End Function

    Public Sub CommmitTrans()
        Trans.Commit()
    End Sub

    Public Sub RollbackTrans()
        Trans.Rollback()
    End Sub

    Public Function NoWord(ByVal Numval)
        Dim hun, Ten, One As String
        Dim t As Double

        '*--set up memory variables as an array
        Dim U(90)
        U(0) = " "
        U(1) = "One"
        U(2) = "Two"
        U(3) = "Three"
        U(4) = "Four"
        U(5) = "Five"
        U(6) = "Six"
        U(7) = "Seven"
        U(8) = "Eight"
        U(9) = "Nine"

        U(10) = "Ten"
        U(11) = "Eleven"
        U(12) = "Twelve"
        U(13) = "Thirteen"
        U(14) = "Fourteen"
        U(15) = "Fifteen"
        U(16) = "Sixteen"
        U(17) = "Seventeen"
        U(18) = "Eighteen"
        U(19) = "Nineteen"

        U(20) = "Twenty"
        U(30) = "Thirty"
        U(40) = "Forty"
        U(50) = "Fifty"
        U(60) = "Sixty"
        U(70) = "Seventy"
        U(80) = "Eighty"
        U(90) = "Ninety"

        '    ones = "     One  Two  ThreeFour Five Six  SevenEightNine "
        Dim counter, start, english, streng, chunk
        counter = 1
        start = 1
        english = ""


        '    streng = Format("999999999999.99", "###########0.00")

        streng = Format(CObj(Numval), "000,000,000,000,000.00")
        'streng = Str(Numval)

        '    streng = Format(235, "###,###,###,###,##0.00")

        '*--Loop through trillions, billions, millions, thousands, hundreds, tens, teens, ones & even cents
        Do While counter < 6
            '*--Split out hundreds, tens and ones.
            chunk = Mid(streng, start, 3) '= Left(STRENG, start, 3)
            hun = Mid(chunk, 1, 1)        '= Left(Chunk, 1, 1)
            Ten = Mid(chunk, 2, 2)        '= Left(Chunk, 2, 2)
            One = Mid(chunk, 3, 1)        '= Left(Chunk, 3, 1)

            '*--Handle hundres portion.
            If Val(chunk) > 99 Then
                english = english & U(hun) & " Hundred "
            End If '(Chunk > 99 )

            '*--Handle second 2 degits.
            t = Val(Ten)
            If t > 0 Then
                If (Int(t / 10.0#) = t / 10.0#) Or (t > 9 And t < 20) Then
                    english = english & U(Ten)
                ElseIf t > 9 And (Int(t / 10.0#) <> t / 10.0#) Then
                    Ten = Mid(Ten, 1, 1) & "0"  '= Ten '= SUBSTR(Ten, 1, 1) + "0"
                    english = english & U(Ten) & " " & U(One)
                ElseIf t < 10 Then
                    english = english & U(One)
                End If
            End If '(T > 0)

            '*--Add "Trillions", "Billions", "Millions", and "Thousands" if necessary

            If streng > 999999999999.99 And counter = 1 Then
                If Val(chunk) > 0 Then
                    If Mid(streng, 4, 16) = "000000000000.00" Then
                        english = english & " Trillion "
                    Else
                        english = english & " Trillion, "
                    End If
                End If
            End If '(need to add 'Trillion')

            If streng > 999999999.99 And counter = 2 Then
                If Val(chunk) > 0 Then
                    If Mid(streng, 4, 12) = "000000000.00" Then
                        english = english & " Billion "
                    Else
                        english = english & " Billion, "
                    End If
                End If
            End If '(need to add 'Billion')

            If streng > 999999.99 And counter = 3 Then
                If Val(chunk) > 0 Then
                    english = english + " Million "
                End If
            End If '(need to add 'Million')

            If streng > 999.99 And counter = 4 Then
                If Val(chunk) > 0 Then
                    english = english + " Thousand "
                End If
            End If '(need to add 'Thousand')

            '*--Prepare for pass through hundreds.'
            start = start + 4
            counter = counter + 1
        Loop 'ENDDO (while Counter < 3)

        start = 21
        If Mid(streng, start, 2) > "00" Then
            chunk = Mid(streng, start, 2)
            Ten = Mid(chunk, 1, 2)
            One = Mid(chunk, 2, 1)
            t = Val(Ten)
            If t > 0 Then
                If (Int(t / 10.0#) = t / 10.0#) Or (t > 9 And t < 20) Then
                    english = english + " Point " & U(Ten) & " Only"
                ElseIf t > 9 And (Int(t / 10.0#) <> t / 10.0#) Then
                    Ten = Mid(Ten, 1, 1) & "0"
                    english = english + " and Point " & U(Ten) & " " & U(One) & " Only"
                ElseIf t < 10 Then
                    english = english & " and Point Zero " & U(One) & " Only"
                End If
            End If '(T > 0)
        Else
            english = english + " Only "
        End If
        NoWord = english
    End Function

    Public Sub FormClose()
        FrmVoucher.Close()
        FrmVoucherType.Close()
        FrmUser.Close()
        FrmSubCategory.Close()
        FrmSubSidiary.Close()
        FrmChartOfAccount.Close()

    End Sub
    Sub txtclear(ByVal Frm As Form, ByVal pnlcenter As Panel, ByVal TB As TabControl, ByVal tp As TabPage)

        Dim A As Control


        For Each A In Frm.Controls
            If TypeOf A Is Panel Then
                Dim C As Control
                For Each C In A.Controls
                    If TypeOf C Is TabControl Then
                        Dim D As Control
                        For Each D In C.Controls
                            If TypeOf D Is TabPage Then
                                If D.Name = "TP1" Then
                                    Dim E As Control
                                    For Each E In D.Controls
                                        If TypeOf E Is TextBox Or TypeOf E Is ComboBox Then

                                            E.Text = ""

                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub
    Sub CStatus(ByVal Frm As Form, ByVal pnlcenter As Panel, ByVal TB As TabControl, ByVal tp As TabPage)

        Dim A As Control


        For Each A In Frm.Controls
            If TypeOf A Is Panel Then
                Dim C As Control
                For Each C In A.Controls

                    If TypeOf C Is TabControl Then
                        Dim D As Control
                        For Each D In C.Controls
                            If TypeOf D Is TabPage Then
                                If D.Name = "TP1" Then
                                    Dim E As Control
                                    For Each E In D.Controls
                                        If TypeOf E Is TextBox Or TypeOf E Is ComboBox Or TypeOf E Is DateTimePicker Then

                                            E.Enabled = Not E.Enabled

                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub
    ' I made it, this is not good, it doesn't control multiple entries of (.) dots.
    ' Instead use the following code into ur forms,couldn't work in module unfortunately.
    'Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    '    If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True

    'End Sub
    Public Sub NumericTextBox(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar > Chr(47) And e.KeyChar < Chr(58) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then

        Else

            e.Handled = True
        End If
    End Sub
    ''''A part of that experiment.
    '' ''Public Sub DelegateControl(ByVal cont As Control, ByVal tpe As Type)
    '' ''    'Dim cont As Control = e.Control
    '' ''    'Dim tpe As Type = cont.GetType
    '' ''    If tpe.FullName = "System.Windows.Forms.DataGridViewTextBoxEditingControl" Then
    '' ''        Dim cmb As ComboBox
    '' ''        cmb = CType(e.Control, ComboBox)
    '' ''        AddHandler cmb.SelectionChangeCommitted, AddressOf K2
    '' ''        'MsgBox("Textbox Control")
    '' ''    ElseIf tpe.FullName = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then
    '' ''        Dim ltxt As New TextBox
    '' ''        ltxt = CType(e.Control, TextBox)
    '' ''        AddHandler ltxt.KeyPress, AddressOf DelegateTextBox
    '' ''        'MsgBox("Combo Control")
    '' ''    End If
    '' ''End Sub
    '' ''Private Sub DelegateTextBox(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '' ''    If dg.CurrentCell.ColumnIndex = 5 Then
    '' ''        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
    '' ''        Me.DG.CurrentRow.Cells(5).Value = Me.ActiveControl.Text & e.KeyChar

    '' ''    End If
    '' ''End Sub
    Sub CMStatus(ByVal CM As ContextMenuStrip)
        For Each TSMI As ToolStripMenuItem In CM.Items
            TSMI.Enabled = Not TSMI.Enabled
        Next
    End Sub
    Sub CMStatusDisable(ByVal CM As ContextMenuStrip)
        For Each TSMI As ToolStripMenuItem In CM.Items
            TSMI.Enabled = False
        Next
        CM.Items(CM.Items.Count - 1).Enabled = True
    End Sub
    Sub ExecuteMyQuery(ByVal MyQuery As String)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd.CommandText = MyQuery
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub ExcuteMyQuery(ByVal Query As String)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd.CommandText = Query
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Module
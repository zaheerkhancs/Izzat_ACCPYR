Public Class SetupListForAllHRM

    Dim a As Integer
    Dim SubstringOfTableName As String
    Dim m As String
    Dim n As String
    Dim o As String
    Dim p As String
    Dim NameOfTableFormCriteria As String
    Dim QueryOfThem As String
    Dim _VarPrimeryKey
    Dim _VarNameOfTable

    Public Obj As Object

    Private Sub SetupListForAllHRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DG.AllowUserToAddRows = False
        Me.Left = Frm.Left
        Me.Top = Frm.Top
        ' Me.Parent = NPIW
    End Sub
    Public Sub GridFill(ByVal QueryToUse As String, ByVal NameOfTable As String)
        _VarNameOfTable = NameOfTable
        NameOfTableFormCriteria = NameOfTable
        QueryOfThem = QueryToUse
        DG.Columns.Clear()
        SubstringOfTableName = NameOfTable
        DG.Columns.Add("DGID", "ID")
        DG.Columns.Add("DGName", NameOfTable)
        Dim DGChkbox As New DataGridViewCheckBoxColumn
        DGChkbox.HeaderText = "Delete all"
        DG.Columns.Add(DGChkbox)
        DG.Columns(0).Width = 50
        DG.Columns(1).Width = 150
        DG.Columns(2).Width = 100

        DG.Columns(0).ReadOnly = True
        DG.Columns(1).ReadOnly = True

        Module1.DatasetFill(QueryToUse, NameOfTable)

        For a = 0 To ds.Tables(NameOfTable).Rows.Count - 1
            DG.Rows.Add()
            If NameOfTable = "JobTitle" Then
                DG.Rows(a).Cells(0).Value = ds.Tables(NameOfTable).Rows(a).Item(0)
                DG.Rows(a).Cells(1).Value = ds.Tables(NameOfTable).Rows(a).Item(2)
            Else
                DG.Rows(a).Cells(0).Value = ds.Tables(NameOfTable).Rows(a).Item(0)
                DG.Rows(a).Cells(1).Value = ds.Tables(NameOfTable).Rows(a).Item(1)
            End If

        Next
        If NameOfTable = "JobTitle" Or NameOfTable = "Department" Then

            DG.Rows(0).Cells(2).ReadOnly = True
        End If
    End Sub
    Public Sub GridFill3(ByVal QueryToUse As String, ByVal NameOfTable As String, ByVal Relation As String, ByVal FieldToBeDisplayed As String)
        m = QueryToUse
        n = NameOfTable
        o = Relation
        p = FieldToBeDisplayed
        DG.Columns.Clear()

        DG.Columns.Add("DGID", "ID")

        SubstringOfTableName = NameOfTable.Substring(2)

        'SubstringOfTableName = SubstringOfTableName.Substring(2, NameOfTable.Length - 1)

        'SubstringOfTableName = NameOfTable.Substring(2, NameOfTable.Length - 1)
        'NameOfTable = SubstringOfTableName.Substring(0, SubstringOfTableName.Length - 2)
        DG.Columns.Add("DGName", SubstringOfTableName)
        DG.Columns.Add("DGRelation", Relation)

        Dim DGChkbox As New DataGridViewCheckBoxColumn
        DGChkbox.HeaderText = "Delete all"
        DG.Columns.Add(DGChkbox)
        DG.Columns(0).Width = 30
        DG.Columns(1).Width = 150
        DG.Columns(2).Width = 100
        DG.Columns(3).Width = 100

        DG.Columns(0).ReadOnly = True
        DG.Columns(1).ReadOnly = True
        DG.Columns(2).ReadOnly = True

        Module1.DatasetFill(QueryToUse, NameOfTable)
        'MsgBox(ds.Tables(NameOfTable).Rows.Count)
        For a = 0 To ds.Tables(NameOfTable).Rows.Count - 1
            DG.Rows.Add()

            DG.Rows(a).Cells(0).Value = ds.Tables(NameOfTable).Rows(a).Item(0)
            DG.Rows(a).Cells(1).Value = ds.Tables(NameOfTable).Rows(a).Item(1)
            DG.Rows(a).Cells(2).Value = ds.Tables(NameOfTable).Rows(a).Item(2)
            ' MsgBox(ds.Tables(NameOfTable).Rows(a).Item(2).ToString())
        Next
    End Sub

    Private Sub DG_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DG.ColumnHeaderMouseClick
        '' we don't need it anymore, its work is now handled by chkCheckAll checkbox.
        'Dim s As Integer
        'Dim t As Integer
        't = 0
        's = 0
        'Dim fahim As String

        'If DG.ColumnCount = 4 Then
        '    fahim = DG.Columns(3).HeaderText
        '    If DG.Columns(3).HeaderText = fahim And e.ColumnIndex = 3 Then
        '        'End If

        '        For Each row As DataGridViewRow In DG.Rows
        '            DG.Rows(s).Cells(3).Value = True
        '            s = s + 1
        '        Next


        '        If (MessageBox.Show(" Do you want to delete all records ?", " Delete records", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No) Then
        '            For Each row As DataGridViewRow In DG.Rows
        '                DG.Rows(t).Cells(3).Value = False
        '                t = t + 1
        '            Next

        '        Else
        '            '  MsgBox("hi")
        '        End If
        '    End If
        'Else
        '    fahim = DG.Columns(2).HeaderText
        '    If DG.Columns(2).HeaderText = fahim And e.ColumnIndex = 2 Then
        '        'End If

        '        For Each row As DataGridViewRow In DG.Rows
        '            DG.Rows(s).Cells(2).Value = True
        '            s = s + 1
        '        Next
        '        If _VarNameOfTable = "JobTitle" Or _VarNameOfTable = "Department" Then

        '            DG.Rows(0).Cells(2).Value = False
        '        End If
        '        If (MessageBox.Show(" Do you want to delete all records ?", " Delete records", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No) Then
        '            For Each row As DataGridViewRow In DG.Rows
        '                DG.Rows(t).Cells(2).Value = False
        '                t = t + 1
        '            Next

        '        Else
        '            ' MsgBox("hi")
        '        End If
        '    End If
        'End If
    End Sub


    Private Sub DG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG.KeyDown
        'Dim s As Integer
        'Dim t As Integer
        's = 0
        't = 0
        If e.KeyCode = Keys.Space Then
            Dim ee As KeyPressEventArgs
            DelegateCellData(DG, ee)
        End If
        If e.KeyCode = 46 Then
            Deleter()
            '  MsgBox(e.KeyCode)
        End If
    End Sub
    Sub CheckTableName()
        If NameOfTableFormCriteria = "Nationality" Then
            _VarPrimeryKey = "NID"
        ElseIf NameOfTableFormCriteria = "Religion" Then
            _VarPrimeryKey = "RID"
        ElseIf NameOfTableFormCriteria = "JobTitle" Then
            _VarPrimeryKey = "JobTitleID"
        ElseIf NameOfTableFormCriteria = "Location" Then
            _VarPrimeryKey = "LocID"
        ElseIf NameOfTableFormCriteria = "Department" Then
            _VarPrimeryKey = "DepID"
        ElseIf NameOfTableFormCriteria = "ShopType" Then
            _VarPrimeryKey = "STypeID"
        ElseIf NameOfTableFormCriteria = "SaraafCurrencyTable" Then
            _VarPrimeryKey = "CurrencyID"
        End If

    End Sub
 
    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "" Then
            Me.DG.CurrentCell.Value = True 'Me.ActiveControl.Text & e.KeyChar
        End If
    End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        If DG.Columns(1).HeaderText = "Department" Or DG.Columns(1).HeaderText = "JobTitle" Then
            If DG.CurrentCell.RowIndex = 0 Then
                Exit Sub
            End If
        End If
        If Not DG.CurrentCell.GetEditedFormattedValue(DG.CurrentRow.Index, DataGridViewDataErrorContexts.Commit).Equals("") Then
            Dim ee As KeyPressEventArgs
            DelegateCellData(DG, ee)
        Else
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Deleter()
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub

    Sub Deleter()
        Dim checkSelectAll As Integer = 0
        For Each column As DataGridViewColumn In DG.Columns
            If column.Name = "" Then
                For Each row As DataGridViewRow In DG.Rows
                    'DG.Rows(s).Cells(3).Value = True
                    If DG.Columns.Count = 3 Then
                        If row.Cells(2).Value = True Then
                            checkSelectAll = checkSelectAll + 1
                        End If
                    Else

                        If DG.Columns.Count = 4 Then
                            If row.Cells(3).Value = True Then
                                checkSelectAll = checkSelectAll + 1
                            End If
                        End If
                    End If

                    ' s = s + 1
                Next
            End If
        Next
        If checkSelectAll = 0 Then Exit Sub

        Dim s As Integer
        Dim t As Integer
        s = 0
        t = 0
        If DG.Columns.Count.Equals(4) Then
            If (MessageBox.Show(" All data will be lost " & Chr(13) & " Are you still going to delete them? ", "Last Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then

                For Each row As DataGridViewRow In DG.Rows
                    Try
                        t = DG.Rows(s).Cells(0).Value
                        ' MsgBox(DG.Rows(s).Cells(2).Value)
                        If DG.Rows(s).Cells(3).Value.Equals(True) Then

                            Dim x As String
                            x = SubstringOfTableName & "ID=" & t
                            'Its just because I didn't take it UnionCouncilID
                            If SubstringOfTableName.Equals("Religion") Then
                                x = "RID= " & t
                            End If
                            If SubstringOfTableName.Equals("ProductType") Then
                                x = "ProdTypeID= " & t
                            End If

                            Module1.DeleteRecord(SubstringOfTableName, x)
                        Else

                            ' MsgBox("Record with ID " & t & " is not selected")
                        End If
                        s = s + 1
                    Catch ex As Exception
                        ' MsgBox("Record with ID " & t & " is not selected")
                        s = s + 1
                    End Try
                Next
                Call GridFill3(m, n, o, p)
            Else
            End If ' of confirmation
        Else ' The following code is then for the grid of District,WaterSource and Lining Type.
            '    End If
            'Else

            If (MessageBox.Show(" All data will be lost " & Chr(13) & " Are you still going to delete them? ", "Last Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then


                For Each row As DataGridViewRow In DG.Rows
                    Try
                        t = DG.Rows(s).Cells(0).Value
                        ' MsgBox(DG.Rows(s).Cells(2).Value)
                        If DG.Rows(s).Cells(2).Value.Equals(True) Then

                            Dim x As String
                            Call CheckTableName()
                            x = _VarPrimeryKey & "=" & t
                            'Its just because I didn't take it UnionCouncilID


                            Module1.DeleteRecord(NameOfTableFormCriteria, x)
                            ' here delete all records of related jobtitles if department is being deleted
                            If NameOfTableFormCriteria = "Department" Then
                                Module1.DeleteRecord("JobTitle", x)
                            End If

                        Else

                            ' MsgBox("Record with ID " & t & " is not selected")
                        End If
                        s = s + 1
                    Catch ex As Exception
                        ' MsgBox("Record with ID " & t & " is not selected")
                        s = s + 1
                    End Try
                Next
                Call GridFill(QueryOfThem, NameOfTableFormCriteria)
            Else

            End If

        End If


    End Sub

   
    Private Sub chkCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.CheckedChanged
        If chkCheckAll.Checked.Equals(True) Then


            For Each column As DataGridViewColumn In DG.Columns
                If column.Name = "" Then
                    For Each row As DataGridViewRow In DG.Rows
                        'DG.Rows(s).Cells(3).Value = True
                        If DG.Columns.Count = 3 Then
                            row.Cells(2).Value = True
                        Else
                            row.Cells(3).Value = True
                        End If
                        If DG.Columns(1).HeaderText = "Department" Or DG.Columns(1).HeaderText = "JobTitle" Then


                            If row.Index = 0 Then
                                row.Cells(2).Value = False
                            End If
                        End If

                        ' s = s + 1
                    Next
                End If
            Next


        Else
            For Each column As DataGridViewColumn In DG.Columns
                If column.Name = "" Then
                    For Each row As DataGridViewRow In DG.Rows
                        'DG.Rows(s).Cells(3).Value = True
                        If DG.Columns.Count = 3 Then
                            row.Cells(2).Value = False
                        Else
                            row.Cells(3).Value = False
                        End If

                        ' s = s + 1
                    Next
                End If
            Next

        End If
    End Sub
End Class
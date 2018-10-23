Public Class FrmMarketing
    Dim Checkbox As String
    Dim str As String
    Private Sub FrmMarketing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()

        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        Module1.DatasetFill("select * from Employee", "Employee")
        cmbName.DataSource = ds.Tables("Employee")
        cmbName.DisplayMember = ("Name")
        cmbName.ValueMember = ("ID")
        cmd.Connection = cn
        cmd.CommandText = "Select isnull(Max(ID),0) from MarketMain"
        txtID.Text = cmd.ExecuteScalar + 1
        dtDate.Value = Now
        dtDateSearch.Value = Now
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DgMarketing.CurrentCell.ColumnIndex = 0 Or DgMarketing.CurrentCell.ColumnIndex = 1 Or DgMarketing.CurrentCell.ColumnIndex = 2 Or DgMarketing.CurrentCell.ColumnIndex = 3 Or DgMarketing.CurrentCell.ColumnIndex = 4 Or DgMarketing.CurrentCell.ColumnIndex = 5 Or DgMarketing.CurrentCell.ColumnIndex = 11 Then
            Exit Sub
        Else
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Sub Fill()

        Dim z As Integer
        cmd.Connection = cn
        da.SelectCommand = cmd
        cmd.CommandText = str
        If (ds.Tables.Contains("VuMarket")) Then
            ds.Tables("VuMarket").Clear()
        End If
        da.Fill(ds, "VuMarket")
        Try

            txtID.Text = ds.Tables("VuMarket").Rows(0).Item(0)
            dtDate.Value = ds.Tables("VuMarket").Rows(0).Item(1)
            cmbName.Text = ds.Tables("VuMarket").Rows(0).Item(2)
            txtRemarks.Text = ds.Tables("VuMarket").Rows(0).Item(3)
        Catch ex As Exception
        End Try


        DgMarketing.Rows.Clear()
        For z = 0 To ds.Tables("VuMarket").Rows.Count - 1
            Try
                DgMarketing.Rows.Add()
                DgMarketing.Rows(z).Cells(0).Value = ds.Tables("VuMarket").Rows(z).Item(4)
                DgMarketing.Rows(z).Cells(1).Value = ds.Tables("VuMarket").Rows(z).Item(5)
                DgMarketing.Rows(z).Cells(2).Value = ds.Tables("VuMarket").Rows(z).Item(6)
                DgMarketing.Rows(z).Cells(3).Value = ds.Tables("VuMarket").Rows(z).Item(7)
                If ds.Tables("VuMarket").Rows(z).Item("OOrder") = "NO" Then
                    DgMarketing.Rows(z).Cells(4).Value = ChbOrder.TrueValue = True
                    DgMarketing.Rows(z).Cells(5).ReadOnly = True
                    DgMarketing.Rows(z).Cells(6).ReadOnly = True
                    DgMarketing.Rows(z).Cells(7).ReadOnly = True
                    DgMarketing.Rows(z).Cells(9).ReadOnly = True
                    DgMarketing.Rows(z).Cells(11).ReadOnly = True
                Else
                    DgMarketing.Rows(z).Cells(4).Value = ChbOrder.FalseValue = False
                    DgMarketing.Rows(z).Cells(5).ReadOnly = False
                    DgMarketing.Rows(z).Cells(6).ReadOnly = False
                    DgMarketing.Rows(z).Cells(7).ReadOnly = False
                    DgMarketing.Rows(z).Cells(9).ReadOnly = False
                    DgMarketing.Rows(z).Cells(11).ReadOnly = False
                End If
                DgMarketing.Rows(z).Cells(5).Value = ds.Tables("VuMarket").Rows(z).Item(9)
                DgMarketing.Rows(z).Cells(6).Value = ds.Tables("VuMarket").Rows(z).Item(10)
                DgMarketing.Rows(z).Cells(7).Value = ds.Tables("VuMarket").Rows(z).Item(11)
                DgMarketing.Rows(z).Cells(8).Value = ds.Tables("VuMarket").Rows(z).Item(12)
                DgMarketing.Rows(z).Cells(9).Value = ds.Tables("VuMarket").Rows(z).Item(13)
                DgMarketing.Rows(z).Cells(10).Value = ds.Tables("VuMarket").Rows(z).Item(14)
                DgMarketing.Rows(z).Cells(11).Value = ds.Tables("VuMarket").Rows(z).Item(15)
            Catch ex As Exception
            End Try

        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        MDI.Panel1.Visible = True
    End Sub

    Private Sub chbSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSearch.CheckedChanged
        If chbSearch.Checked.Equals(True) Then
            Module1.DatasetFill("select * from Employee", "Employee")
            cmbNameSearch.DataSource = ds.Tables("Employee")
            cmbNameSearch.DisplayMember = ("Name")
            cmbNameSearch.ValueMember = ("ID")
            cmbNameSearch.Enabled = True
            dtDateSearch.Enabled = True
            btnSearch.Enabled = True
            btnOK.Text = "&Update"
            cmbName.Enabled = False
            cmbName.SelectedIndex = -1
            Module1.GClear(GBEntry)
            DgMarketing.Rows.Clear()
        Else
            cmbNameSearch.Enabled = False
            dtDateSearch.Enabled = False
            btnSearch.Enabled = False
            cmbName.Enabled = True
            btnOK.Text = "&OK"
            cmbNameSearch.SelectedIndex = -1
            dtDateSearch.Value = Now
            Module1.GClear(GBEntry)
            cmd.Connection = cn
            cmd.CommandText = "Select isnull(Max(ID),0) from MarketMain"
            txtID.Text = cmd.ExecuteScalar + 1
            DgMarketing.Rows.Clear()
        End If
    End Sub
    Sub SaveDetail()
        Try
            Dim a As Integer
            For a = 0 To DgMarketing.Rows.Count - 2
                If DgMarketing(4, a).Value <> True Then
                    DgMarketing(4, a).Value = "NO"
                Else
                    DgMarketing(4, a).Value = "YES"
                End If
                Module1.InsertRecord("MarketDetail", "ID,ClientName,Company,Location,OOrder,OrderType,Quantity,Price,Amount,Advance,Balance,DelivaryDate", "" & txtID.Text & ",'" & DgMarketing.Rows(a).Cells(1).Value & "','" & DgMarketing.Rows(a).Cells(2).Value & "','" & DgMarketing.Rows(a).Cells(3).Value & "','" & DgMarketing(4, a).Value & "','" & DgMarketing.Rows(a).Cells(5).Value & "'," & Val(DgMarketing.Rows(a).Cells(6).Value) & "," & Val(DgMarketing.Rows(a).Cells(7).Value) & "," & Val(DgMarketing.Rows(a).Cells(8).Value) & "," & Val(DgMarketing.Rows(a).Cells(9).Value) & "," & Val(DgMarketing.Rows(a).Cells(10).Value) & ",'" & DgMarketing.Rows(a).Cells(11).Value & "'")
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveMain()
        Module1.Opencn()
        Module1.InsertRecord("MarketMain", "ID,dtDate,Name,Remarks", "" & txtID.Text & ",'" & dtDate.Value.Date.ToString & "','" & cmbName.Text & "','" & txtRemarks.Text & "'")
        Call SaveDetail()
    End Sub
    Sub UpdateDetail()
        Module1.Opencn()
        cmd.CommandText = " Delete from MarketDetail where ID = " & txtID.Text & " "
        cmd.Connection = cn
        cmd.ExecuteNonQuery()
        Call SaveDetail()
    End Sub
    Sub UpdateMain()
        If DgMarketing.Rows.Count = 1 Then
            Dim frm5 As New FrmBox("THERE IS NO RECORD TO UPDATE..")
            frm5.ShowDialog()
            Exit Sub
        Else
            Module1.UpdateRecord("MarketMain", "Name='" & cmbName.Text & "',Remarks='" & txtRemarks.Text & "'", "ID = " & txtID.Text & "")
            Call UpdateDetail()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If DgMarketing.Rows.Count = 1 Then
            Dim frm5 As New FrmBox("THERE IS NO RECORD..")
            frm5.ShowDialog()
            Exit Sub
        Else
            If btnOK.Text = "&OK" Then
                Call SaveMain()
                Dim frm1 As New FrmBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY..")
                frm1.ShowDialog()
                DgMarketing.Rows.Clear()
                Module1.GClear(GBEntry)
                cmd.Connection = cn
                cmd.CommandText = "Select isnull(Max(ID),0) from MarketMain"
                txtID.Text = cmd.ExecuteScalar + 1
                Exit Sub
            Else
                Call UpdateMain()
                Dim frm2 As New FrmBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY..")
                frm2.ShowDialog()
                chbSearch.Checked = False
                DgMarketing.Rows.Clear()
                Module1.GClear(GBEntry)
                Module1.GClear(GBSearch)
                cmd.Connection = cn
                cmd.CommandText = "Select isnull(Max(ID),0) from MarketMain"
                txtID.Text = cmd.ExecuteScalar + 1
            End If
        End If
    End Sub

    Private Sub DgMarketing_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DgMarketing.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Sub Read()
        Dim a As Integer
        For a = 0 To DgMarketing.Rows.Count - 1
            If DgMarketing(3, a).Value = "YES" Then
                ChbOrder.TrueValue.Equals(True)
            Else
                ChbOrder.FalseValue.Equals(True)
            End If
        Next
    End Sub

    Private Sub DgMarketing_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMarketing.CellValueChanged
        Dim a As Integer

        If DgMarketing.Rows.Count = 1 Then
            Exit Sub
        Else
            For a = 0 To DgMarketing.Rows.Count - 1
                If DgMarketing.CurrentCell.ColumnIndex = 4 Then
                    If DgMarketing.Rows(a).Cells(4).Value = ChbOrder.TrueValue = False Then
                        DgMarketing.Rows(a).Cells(5).ReadOnly = False
                        DgMarketing.Rows(a).Cells(6).ReadOnly = False
                        DgMarketing.Rows(a).Cells(7).ReadOnly = False
                        DgMarketing.Rows(a).Cells(9).ReadOnly = False
                        DgMarketing.Rows(a).Cells(11).ReadOnly = False
                        DgMarketing.Rows(a).Cells(8).Value = Val(DgMarketing.Rows(a).Cells(6).Value) * Val(DgMarketing.Rows(a).Cells(7).Value)
                        DgMarketing.Rows(a).Cells(10).Value = Val(DgMarketing.Rows(a).Cells(8).Value) - Val(DgMarketing.Rows(a).Cells(9).Value)
                    Else
                        DgMarketing.Rows(a).Cells(5).ReadOnly = True
                        DgMarketing.Rows(a).Cells(6).ReadOnly = True
                        DgMarketing.Rows(a).Cells(7).ReadOnly = True
                        DgMarketing.Rows(a).Cells(9).ReadOnly = True
                        DgMarketing.Rows(a).Cells(11).ReadOnly = True
                    End If
                Else
                    DgMarketing.Rows(a).Cells(8).Value = Val(DgMarketing.Rows(a).Cells(6).Value) * Val(DgMarketing.Rows(a).Cells(7).Value)
                    DgMarketing.Rows(a).Cells(10).Value = Val(DgMarketing.Rows(a).Cells(8).Value) - Val(DgMarketing.Rows(a).Cells(9).Value)
                End If
            Next
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        str = "Select * from VuMarket where Name = '" & cmbNameSearch.Text & "' And dtDate = '" & dtDateSearch.Value.Date.ToString & "'"
        Call Fill()
    End Sub
    Sub k1(ByVal sender As Object, ByVal e As System.EventArgs)
        DgMarketing.CurrentRow.Cells(0).Value = sender.selectedvalue
        DgMarketing.CurrentRow.Cells(1).Value = sender.selectedvalue
    End Sub
    Private Sub DgMarketing_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgMarketing.EditingControlShowing
        If DgMarketing.CurrentCell.ColumnIndex = 6 Then
            Dim ltxt As New TextBox
            ltxt = CType(e.Control, TextBox)
            AddHandler ltxt.KeyPress, AddressOf NumericKeys
        End If
    End Sub
End Class
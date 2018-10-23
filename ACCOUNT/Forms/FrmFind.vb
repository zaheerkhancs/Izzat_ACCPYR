Public Class FrmFind
    '  Dim dbind As New BindingSource
    Public rw As Integer
    Private Sub FrmFind_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Module1.Opencn()
        Module1.DatasetFill("Select HeadID,HeadName from VuChartofAcc", "VuChartofAcc")
        BSource.DataSource = ds.Tables("VuChartofAcc")
        'DG.DataSource = ds
        'DG.DataMember = ds.Tables("VuChartofAcc").TableName
        Me.TextBox1.Focus()
        HeadID.DataPropertyName = "HeadID"
        HeadName.DataPropertyName = "HeadName"

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Down Then
            DG.Focus()

        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            FrmVoucher.DG.EndEdit(True)
            FrmVoucher.DG.BeginEdit(True)
            FrmVoucher.DG.Rows(rw).Cells(0).Value = ""
            FrmVoucher.DG.Rows(rw).Cells(1).Value = DG.CurrentRow.Cells(0).Value
            FrmVoucher.DG.Rows(rw).Cells(0).Value = DG.CurrentRow.Cells(1).Value
            'FrmVoucher.DG.Rows(rw).Cells(0) = DG.CurrentRow.Cells(0)
            Me.Close()
            'FrmVoucher.DG.Rows(rw).Cells(1).EditType.
            FrmVoucher.DG.Focus()
            FrmVoucher.DG.EndEdit(True)
            FrmVoucher.DG.BeginEdit(True)

        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Module1.DatasetFill("Select HeadID,HeadName from VuChartofAcc where HeadName Like '" & Me.TextBox1.Text & "%'", "VuChartofAcc")
        BSource.DataSource = ds.Tables("VuChartofAcc")
        HeadID.DataPropertyName = "HeadID"
        HeadName.DataPropertyName = "HeadName"
        DG.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            FrmVoucher.DG.EndEdit(True)
            FrmVoucher.DG.BeginEdit(True)
            FrmVoucher.DG.Rows(rw).Cells(0).Value = ""
            FrmVoucher.DG.Rows(rw).Cells(1).Value = DG.CurrentRow.Cells(0).Value
            FrmVoucher.DG.Rows(rw).Cells(0).Value = DG.CurrentRow.Cells(1).Value
            'FrmVoucher.DG.Rows(rw).Cells(0) = DG.CurrentRow.Cells(0)
            Me.Close()

            FrmVoucher.DG.Focus()
            FrmVoucher.DG.EndEdit(True)
            FrmVoucher.DG.BeginEdit(True)

        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Module1.DatasetFill("Select HeadID,HeadName from VuChartofAcc where HeadID Like '" & Me.TextBox2.Text & "%'", "VuChartofAcc")
        BSource.DataSource = ds.Tables("VuChartofAcc")

        HeadID.DataPropertyName = "HeadID"
        HeadName.DataPropertyName = "HeadName"
        DG.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub



    Private Sub DG_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellDoubleClick
        ' FrmVoucher.DG.EditMode = DataGridViewEditMode.EditProgrammatically
        FrmVoucher.DG.EndEdit(True)
        FrmVoucher.DG.BeginEdit(True)
        FrmVoucher.DG.Rows(rw).Cells(0).Value = ""


        FrmVoucher.DG.Rows(rw).Cells(1).Value = DG.CurrentRow.Cells(0).Value
        FrmVoucher.DG.Rows(rw).Cells(0).Value = DG.CurrentRow.Cells(1).Value
        'FrmVoucher.DG.Rows(rw).Cells(0) = DG.CurrentRow.Cells(0)

        Me.Close()
        FrmVoucher.DG.Focus()
        FrmVoucher.DG.EndEdit(True)
        FrmVoucher.DG.BeginEdit(True)


        'FrmVoucher.DG.BeginEdit(True)

    End Sub

    Private Sub DG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DG.KeyPress
        'If Asc(e.KeyChar) = 13 Then
        '    MsgBox("You enter " & DG.CurrentCell.RowIndex - 1)

        'End If
    End Sub

    Private Sub DG_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.RowEnter
        'Try


        '    MsgBox("You enter " & DG.CurrentCell.RowIndex)
        'Catch ex As Exception

        'End Try

    End Sub
End Class
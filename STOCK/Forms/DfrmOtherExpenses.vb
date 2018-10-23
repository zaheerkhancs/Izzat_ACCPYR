Imports System.Windows.Forms

Public Class DfrmOtherExpenses
    Public Var_FormIsOpen As Boolean
    Dim ExpenseID As Integer
    Private Sub DfrmOtherExpenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtPayment.Value = Now
        Module1.DatasetFill("Select * from ExpenseTypeForPurchase", "ExpenseTypeForPurchase")
        DGDesc.DataSource = ds.Tables("ExpenseTypeForPurchase")
        DGDesc.DisplayMember = ("ExpenseName")
        DGDesc.ValueMember = ("ExpenseID")
        'CType(DGDiag.Columns(1), DataGridViewComboBoxC).

    End Sub

    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DGDiag.CurrentCell.ColumnIndex = 2 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub

    Sub K2(ByVal sender As Object, ByVal e As System.EventArgs)
        If DGDiag.CurrentCell.ColumnIndex = 1 Then
            DGDiag.CurrentRow.Cells(3).Value = sender.selectedvalue
            'DG.CurrentRow.Cells(4).Value = sender.selectedvalue
        End If
    End Sub

#Region "DATA GRID VIEW"
    Private Sub DGDiag_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDiag.CellClick
        Try
            DGDiag.CurrentRow.Cells(0).Value = DGDiag.CurrentRow.Index + 1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGDiag_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDiag.CellEnter
        Dim z As Integer = 0
        If DGDiag.CurrentRow.Index = 0 And DGDiag.CurrentCell.ColumnIndex = 0 Then
            z = DGDiag.CurrentRow.Index + 1
        End If
        If DGDiag.CurrentCell.ColumnIndex = 0 Then
            DGDiag.CurrentRow.Cells(0).Value = z.ToString
        End If
        If DGDiag.CurrentRow.Index <> 0 And DGDiag.CurrentCell.ColumnIndex = 0 Then
            DGDiag.CurrentRow.Cells(0).Value = DGDiag.CurrentRow.Index + 1
        End If
    End Sub

    Private Sub DGDiag_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDiag.CellValueChanged
        Dim CalculateAmount As Decimal = 0
        Dim Increamenter As Integer = 0
        Try
            For Each Row As DataGridViewRow In DGDiag.Rows
                CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DGDiag.Rows(Increamenter).Cells(2).Value))
                Increamenter = Increamenter + 1
            Next
            txtTotal.Text = CalculateAmount
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGDiag_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGDiag.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DGDiag.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub

    Private Sub DGDiag_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGDiag.EditingControlShowing
        Try

            If DGDiag.CurrentCell.ColumnIndex = 2 Then
                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf NumericKeys
            End If

            If DGDiag.CurrentCell.ColumnIndex = 1 Then
                Dim bcmb As New ComboBox
                bcmb = CType(e.Control, ComboBox)
                AddHandler bcmb.SelectionChangeCommitted, AddressOf K2
            End If

            Dim cont As Control = e.Control
            Dim tpe As Type = cont.GetType
            If tpe.FullName = "System.Windows.Forms.DataGridViewTextBoxEditingControl" Then
                Try
                    Dim ltxt As New TextBox
                    ltxt = CType(e.Control, TextBox)
                    AddHandler ltxt.KeyPress, AddressOf DelegateCellData

                Catch ex As Exception

                End Try
            ElseIf tpe.FullName = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then

            End If

        Catch ex As Exception
        End Try

    End Sub
#End Region
    Private Sub DfrmOtherExpenses_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Var_FormIsOpen = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub

    Private Sub btnPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPay.Click
        frmPurchase.txtOtherExpenses.Text = txtTotal.Text
        Me.Visible = False

    End Sub

    Private Sub txtExpenseType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtExpenseType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtExpenseType.Text = "" Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from ExpenseTypeForPurchase", "ExpenseTypeForPurchase")
                cmd.CommandText = "Select isnull(Max(ExpenseID),0) from ExpenseTypeForPurchase"
                ExpenseID = cmd.ExecuteScalar + 1
                Module1.InsertRecord("ExpenseTypeForPurchase", "ExpenseID,ExpenseName", "" & ExpenseID & ",N'" & txtExpenseType.Text & "'")
                Module1.DatasetFill("Select * from ExpenseTypeForPurchase", "ExpenseTypeForPurchase")
                DGDesc.DataSource = ds.Tables("ExpenseTypeForPurchase")
                DGDesc.DisplayMember = ("ExpenseName")
                DGDesc.ValueMember = ("ExpenseID")
                txtExpenseType.Text = ""
            End If
        End If
    End Sub
    Private Sub DGDiag_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGDiag.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim CalculateAmount As Decimal = 0
            Dim Increamenter As Integer = 0
            Try
                For Each Row As DataGridViewRow In DGDiag.Rows
                    CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DGDiag.Rows(Increamenter).Cells(2).Value))
                    Increamenter = Increamenter + 1
                Next
                txtTotal.Text = CalculateAmount
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class

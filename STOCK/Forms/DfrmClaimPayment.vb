Imports System.Windows.Forms

Public Class DfrmClaimPayment
    Public Var_FormIsOpen As Boolean
    Private Sub DfrmClaimPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtPayment.Value = Now
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DGDiag.CurrentCell.ColumnIndex = 1 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Private Sub DGDiag_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDiag.CellValueChanged
        Dim CalculateAmount As Decimal = 0
        Dim Increamenter As Integer = 0
        Try
            For Each Row As DataGridViewRow In DGDiag.Rows
                CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DGDiag.Rows(Increamenter).Cells(1).Value))
                Increamenter = Increamenter + 1
            Next
            txtTotalPaid.Text = CalculateAmount
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTotalPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid.TextChanged
        txtBalance.Text = Val(txtTotalToPay.Text) - Val(txtTotalPaid.Text)
    End Sub

    Private Sub txtTotalToPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalToPay.TextChanged
        txtBalance.Text = Val(txtTotalToPay.Text) - Val(txtTotalPaid.Text)
    End Sub

    Private Sub btnPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPay.Click
        If txtBalance.Text < 0 Then
            MsgBox("INVALID VALUE", MsgBoxStyle.Critical)
            Exit Sub
        Else

            frmClaim.txtPaid.Text = txtTotalPaid.Text
            frmClaim.txtBalance.Text = txtBalance.Text
            Me.Visible = False
            If DGDiag.CurrentRow.Cells("DGDiagDate").Value = Nothing Then
                DGDiag.CurrentRow.Cells("DGDiagDate").Value = dtPayment.Value.Date
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
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

    Private Sub DGDiag_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDiag.CellClick
        Try
            DGDiag.CurrentRow.Cells(0).Value = DGDiag.CurrentRow.Index + 1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtPayment_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtPayment.KeyPress
        Try
            DGDiag.CurrentRow.Cells(2).Value = dtPayment.Value.Date
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DfrmClaimPayment_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Var_FormIsOpen = False
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
            If DGDiag.CurrentCell.ColumnIndex = 1 Then
                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf NumericKeys
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
End Class

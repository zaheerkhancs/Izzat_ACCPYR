Public Class FrmSalePaymentDialogueBox
    Public P As Boolean = False
    Dim azizkhanqarabaghi2 As Boolean = False
    Public Call_Is_From_FormName As String
    Public Var_PaymentFormIsOpen As Boolean
    'Private iSale As Integer


    'Public Sub New()

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    'End Sub

    'Public Sub Abc(ByVal isale As Integer)
    '    Me.iSale = isale
    'End Sub

    Private Sub DGDiag_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDiag.CellValueChanged
        CalculateOnCellValueChanged()
        'End If

    End Sub
    Sub CalculateOnCellValueChanged()
        Dim CalculateAmount As Decimal = 0
        Dim Increamenter As Integer = 0
        'If DGDiag.CurrentCell.ColumnIndex = 1 Then
        Try
            For Each Row As DataGridViewRow In DGDiag.Rows
                CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DGDiag.Rows(Increamenter).Cells(1).Value))
                Increamenter = Increamenter + 1
            Next
            txtTotalPaid.Text = CalculateAmount
        Catch ex As Exception
            'If azizkhanqarabaghi2 = True Then
            '    DGDiag.CurrentCell.Value = "0"
            '    MessageBox.Show("فقط اعداد قابل قبول میباشد", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'End If
        End Try
    End Sub

    Private Sub txtTotalPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid.TextChanged
        txtBalance.Text = Val(txtTotalToPay.Text) - Val(txtTotalPaid.Text)
    End Sub

    Private Sub txtTotalToPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalToPay.TextChanged
        txtBalance.Text = Val(txtTotalToPay.Text) - Val(txtTotalPaid.Text)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If txtBalance.Text < 0 Then
            MsgBox("INVALID VALUE", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If Call_Is_From_FormName = "FrmSale" Then
                FrmSale.txtTotalToPay.Text = Me.txtTotalToPay.Text
                FrmSale.txtTotalPaid.Text = Me.txtTotalPaid.Text
                FrmSale.txtBalance.Text = Me.txtBalance.Text
            ElseIf Call_Is_From_FormName = "FrmReturn" Then
                FrmReturn.txtTotalToPay.Text = Me.txtTotalToPay.Text
                FrmReturn.txtTotalPaid.Text = Me.txtTotalPaid.Text
                FrmReturn.txtBalance.Text = Me.txtBalance.Text
            ElseIf Call_Is_From_FormName = "FrmSaleOfSaleman" Then
                FrmSaleOfSaleman.txtTotalToPay.Text = Me.txtTotalToPay.Text
                FrmSaleOfSaleman.txtPaid.Text = Me.txtTotalPaid.Text
                FrmSaleOfSaleman.txtBalance.Text = Me.txtBalance.Text
            End If
            Me.Visible = False
            If DGDiag.CurrentRow.Cells("DGDiagDate").Value = Nothing Then
                DGDiag.CurrentRow.Cells("DGDiagDate").Value = DTPaymentDate.Value.Date
            End If
        End If
    End Sub

    Private Sub DGDiag_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDiag.CellClick
        DGDiag.CurrentRow.Cells(0).Value = DGDiag.CurrentRow.Index + 1
    End Sub

    Private Sub FrmSalePaymentDialogueBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        azizkhanqarabaghi2 = False

        ' All the following code has been transferred to their corresponding forms's btnPayment_CLick. Here is didn't work well.
        'If Call_Is_From_FormName = "FrmSale" Then
        '    Try
        '        If FrmSale.EditValue = 0 Then
        '            Call GridFill()
        '        End If
        '    Catch ex As Exception

        '    End Try
        'ElseIf Call_Is_From_FormName = "FrmReturn" Then
        '    Try
        '        If FrmReturn.EditValue = 0 Then
        '            Call GridFillFromReturnTable()
        '        End If

        '    Catch ex As Exception

        '    End Try
        'End If
        azizkhanqarabaghi2 = True

    End Sub
    Sub GridFill()
        Try
            Dim i As Integer = 0

            DGDiag.Rows.Clear()

            Module1.DatasetFill("Select * from SalePayment where SaleID= " & FrmSale.Var_SaleID, "SalePayment")
            'For Each Row As DataRow In ds.Tables("OrderFromCustomerDetail").Rows
            '    DG.Rows.Add()
            '    i = +1
            '    DG.Rows(i).Cells("DGSNo").Value = Row("SNo")
            '    DG.Rows(i).Cells("DGPType").Value = Row("ProdTypeID")
            '    DG.Rows(i).Cells("DGProductName").Value = Row("ProdCode")
            '    DG.Rows(i).Cells("DGQty").Value = Row("Qty")
            '    DG.Rows(i).Cells("DGDesc").Value = Row("ProdDescription")

            'Next
            For i = 0 To ds.Tables("SalePayment").Rows.Count - 1
                DGDiag.Rows.Add()
                'i = DGDiag.Rows.Count

                DGDiag.Rows(i).Cells("DGDiagSNo").Value = ds.Tables("SalePayment").Rows(i).Item("SNo")
                DGDiag.Rows(i).Cells("DGDiagAmount").Value = ds.Tables("SalePayment").Rows(i).Item("Amount")
                DGDiag.Rows(i).Cells("DGDiagDate").Value = ds.Tables("SalePayment").Rows(i).Item("PaymentDate")


            Next
            Var_PaymentFormIsOpen = True
        Catch ex As Exception

        End Try
    End Sub
    Sub GridFillFromReturnTable()
        Try
            Dim i As Integer = 0

            DGDiag.Rows.Clear()

            Module1.DatasetFill("Select * from ReturnPayment where ReturnID= " & FrmReturn.Var_ReturnID, "ReturnPayment")
            'For Each Row As DataRow In ds.Tables("OrderFromCustomerDetail").Rows
            '    DG.Rows.Add()
            '    i = +1
            '    DG.Rows(i).Cells("DGSNo").Value = Row("SNo")
            '    DG.Rows(i).Cells("DGPType").Value = Row("ProdTypeID")
            '    DG.Rows(i).Cells("DGProductName").Value = Row("ProdCode")
            '    DG.Rows(i).Cells("DGQty").Value = Row("Qty")
            '    DG.Rows(i).Cells("DGDesc").Value = Row("ProdDescription")

            'Next
            For i = 0 To ds.Tables("ReturnPayment").Rows.Count - 1
                DGDiag.Rows.Add()
                'i = DGDiag.Rows.Count

                DGDiag.Rows(i).Cells("DGDiagSNo").Value = ds.Tables("ReturnPayment").Rows(i).Item("SNo")
                DGDiag.Rows(i).Cells("DGDiagAmount").Value = ds.Tables("ReturnPayment").Rows(i).Item("Amount")
                DGDiag.Rows(i).Cells("DGDiagDate").Value = ds.Tables("ReturnPayment").Rows(i).Item("PaymentDate")


            Next
            Var_PaymentFormIsOpen = True
        Catch ex As Exception

        End Try
    End Sub
    Sub GridFillFromSaleOfSaleManTable()
        Try
            Dim i As Integer = 0

            DGDiag.Rows.Clear()

            Module1.DatasetFill("Select * from SalePaymentOfSaleMan where SaleID= " & FrmSaleOfSaleman.SaleIDOfSaleMan, "SalePaymentOfSaleMan")
            'For Each Row As DataRow In ds.Tables("OrderFromCustomerDetail").Rows
            '    DG.Rows.Add()
            '    i = +1
            '    DG.Rows(i).Cells("DGSNo").Value = Row("SNo")
            '    DG.Rows(i).Cells("DGPType").Value = Row("ProdTypeID")
            '    DG.Rows(i).Cells("DGProductName").Value = Row("ProdCode")
            '    DG.Rows(i).Cells("DGQty").Value = Row("Qty")
            '    DG.Rows(i).Cells("DGDesc").Value = Row("ProdDescription")

            'Next
            For i = 0 To ds.Tables("SalePaymentOfSaleMan").Rows.Count - 1
                DGDiag.Rows.Add()
                'i = DGDiag.Rows.Count

                DGDiag.Rows(i).Cells("DGDiagSNo").Value = ds.Tables("SalePaymentOfSaleMan").Rows(i).Item("SNo")
                DGDiag.Rows(i).Cells("DGDiagAmount").Value = ds.Tables("SalePaymentOfSaleMan").Rows(i).Item("Amount")
                DGDiag.Rows(i).Cells("DGDiagDate").Value = ds.Tables("SalePaymentOfSaleMan").Rows(i).Item("dtDate")
            Next
            Var_PaymentFormIsOpen = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DTManForGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPaymentDate.KeyPress
        DGDiag.CurrentRow.Cells("DGDiagDate").Value = DTPaymentDate.Value.Date()
    End Sub

    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        Else
            Me.DGDiag.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
        End If
    End Sub

    Private Sub DGDiag_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGDiag.EditingControlShowing
        If DGDiag.CurrentCell.ColumnIndex = 1 Then
            Try
                Dim g As Integer = DGDiag.CurrentCell.Value
            Catch ex As Exception
                'DGDiag.CurrentCell.Value = "0"
                'MessageBox.Show("فقط اعداد قابل قبول میباشد", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
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
    End Sub

    Private Sub FrmSalePaymentDialogueBox_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' I declare a global variable of type boolean P and then in Mnu Close of FrmSale I changed its value to true,
        ' But I saw that it never calls this form's closing when it is disposed or closed from there, so its ok,
        ' i didn't change the code, because it alread works, but if i remove the whole If condition and leave e.Cancel = true, it will work !
        If P = False Then
            e.Cancel = True
        Else
            Var_PaymentFormIsOpen = False
            e.Cancel = False
        End If
        Var_PaymentFormIsOpen = False
    End Sub

    Private Sub DGDiag_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGDiag.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Visible = False
    End Sub

    Private Sub DGDiag_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGDiag.RowsRemoved
        CalculateOnCellValueChanged()
    End Sub
End Class
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms
Public Class DfrmPurchaseQty
    Public P As Boolean = False
    Dim xx As Integer
    Dim yy As Integer
    Dim a As Integer
    Dim MyComputerName As String
    Dim MyComputerIP As String
    Private Sub DfrmPurchaseQty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If frmPurchase.EditValue = 1 Then
                ' Do nothing let is load empty.
            Else
                Call GridFill()
                Me.BringToFront()
                Me.TopMost = True

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DGTransfer.CurrentCell.ColumnIndex = 1 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Private Sub txtTransferredQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferredQty.TextChanged
        txtRemainingQty.Text = Val(txtTotalQty.Text) - Val(txtTransferredQty.Text)
    End Sub

    Private Sub txtRemainingQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemainingQty.TextChanged
        txtRemainingQty.Text = Val(txtTotalQty.Text) - Val(txtTransferredQty.Text)
    End Sub

    Private Sub dtQtyTransferredDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtQtyTransferredDate.KeyPress
        DGTransfer.CurrentRow.Cells(2).Value = dtQtyTransferredDate.Value.Date()
    End Sub

    Private Sub DGTransfer_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGTransfer.CellValueChanged
        Dim CalculateAmount As Decimal = 0
        Dim Increamenter As Integer = 0
        Try
            For Each Row As DataGridViewRow In DGTransfer.Rows
                CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DGTransfer.Rows(Increamenter).Cells(1).Value))
                Increamenter = Increamenter + 1
            Next
            txtTransferredQty.Text = CalculateAmount
        Catch ex As Exception
        End Try

    End Sub
    Private Sub DGTransfer_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGTransfer.DataError
        Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGTransfer_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGTransfer.CellClick
        DGTransfer.CurrentRow.Cells(0).Value = DGTransfer.CurrentRow.Index + 1
    End Sub
    Public Sub GridFill()
        Try
            Dim i As Integer = 0

            DGTransfer.Rows.Clear()
            If frmPurchase.EditValue = 1 Then
                'MsgBox(frmPurchase.EditValue)
                ' If it is a new record, then we don't need to load any data into the DGTransfer DataGrid.
                Exit Sub
            Else
                Module1.DatasetFill("Select * from PurchaseSubDetail where PurchaseID= " & frmPurchase.PurchaseID & " And DGSNo= " & frmPurchase.DG.CurrentRow.Cells(0).Value, "PurchaseSubDetail")

            End If
            If ds.Tables("PurchaseSubDetail").Rows.Count = 0 Then
                DGTransfer.Rows.Clear()
                Exit Sub
            End If
            For i = 0 To ds.Tables("PurchaseSubDetail").Rows.Count - 1
                DGTransfer.Rows.Add()
                DGTransfer.Rows(i).Cells(0).Value = ds.Tables("PurchaseSubDetail").Rows(i).Item(2)
                DGTransfer.Rows(i).Cells(1).Value = ds.Tables("PurchaseSubDetail").Rows(i).Item(3)
                DGTransfer.Rows(i).Cells(2).Value = ds.Tables("PurchaseSubDetail").Rows(i).Item(4)


            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GridFillFrom_CurrentRowKaTable()
        Try
            Dim i As Integer = 0
            'MsgBox(ds.Tables(frmPurchase.CurrentRowKaTable).Rows.Count)

            For Each dtrow As DataRow In ds.Tables(frmPurchase.CurrentRowKaTable).Rows

                DGTransfer.Rows.Add()

                DGTransfer.Rows(i).Cells(0).Value = dtrow("Sno")
                DGTransfer.Rows(i).Cells(1).Value = dtrow("Qty")
                DGTransfer.Rows(i).Cells(2).Value = dtrow("trdate")

                i = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmSaleQtyTranfered_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' I declare a global variable of type boolean P and then in Mnu Close of FrmSale I changed its value to true,
        ' But I saw that it never calls this form's closing when it is disposed or closed from there, so its ok,
        ' i didn't change the code, because it alread works, but if i remove the whole If condition and leave e.Cancel = true, it will work !
        If P = False Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub btnPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPay.Click
        If txtRemainingQty.Text < 0 Then
            MsgBox("INVALID VALUE", MsgBoxStyle.Critical)
            Exit Sub
        Else
            frmPurchase.DG.CurrentRow.Cells("DGRecQty").Value = Me.txtTransferredQty.Text
            frmPurchase.DG.CurrentRow.Cells("DGRemain").Value = Me.txtRemainingQty.Text
            Me.Visible = False
            '' I have created a datatable and added three columns inside them so that for each row in dgtransfer "The Grid" I store the record.
            '' The following code is working completely correct,but since it is for only one row at a time, so I can't use it.

            Dim Mydatatable As New DataTable
            Dim RowNumberForConcatination As String = frmPurchase.DG.CurrentRow.Cells(0).Value
            Mydatatable.TableName = "TableOfRowNo " & RowNumberForConcatination
            Mydatatable.Columns.Add("PurchaseID")
            Mydatatable.Columns.Add("DGSno")
            Mydatatable.Columns.Add("Sno")
            Mydatatable.Columns.Add("Qty")
            Mydatatable.Columns.Add("trdate")
            For a = 0 To DGTransfer.Rows.Count - 2
                Dim drow As DataRow
                drow = Mydatatable.NewRow
                If FrmSale.EditValue = 1 Then
                    drow("PurchaseID") = frmPurchase.PurchaseID '+ 1
                Else
                    drow("PurchaseID") = frmPurchase.PurchaseID
                End If

                drow("DGSno") = (frmPurchase.DG.CurrentRow.Cells(0).Value)
                drow("Sno") = (DGTransfer.Rows(a).Cells(0).Value)
                drow("Qty") = (DGTransfer.Rows(a).Cells(1).Value)
                ' I am going to get only the date portion of the gridvalue
                Dim trdateonly As DateTime
                Dim ci As New CultureInfo("en-GB")
                Dim s As String = DGTransfer.Rows(a).Cells(2).Value
                If s = Nothing Then
                    s = dtQtyTransferredDate.Value.Date
                End If
                Try
                    trdateonly = Convert.ToDateTime(s)
                Catch ex As Exception
                    GoTo x
                End Try
                s = trdateonly.ToString(ci)
x:
                s = s.Substring(0, 10)
                drow("trdate") = s
                Mydatatable.Rows.Add(drow)
            Next
            For Each datatable As DataTable In ds.Tables
                If datatable.TableName.StartsWith("TableOfRowNo") Then
                    If datatable.TableName = Mydatatable.TableName Then
                        If ds.Tables.Contains(Mydatatable.TableName) = True Then
                            ds.Tables.Remove(Mydatatable.TableName)
                            Exit For
                        End If
                    End If
                End If
            Next
            ds.Tables.Add(Mydatatable)
            For Each row As DataRow In Mydatatable.Rows

            Next
        End If
        ' frmPurchase.DG.Rows(frmPurchase.DG.Rows.IndexOf(frmPurchase.DG.CurrentRow)).Cells(0).Selected = True
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DGTransfer.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub DGTransfer_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGTransfer.EditingControlShowing
        Try

            If DGTransfer.CurrentCell.ColumnIndex = 1 Then
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

    Private Sub DGTransfer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGTransfer.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim CalculateAmount As Decimal = 0
            Dim Increamenter As Integer = 0
            Try
                For Each Row As DataGridViewRow In DGTransfer.Rows
                    CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DGTransfer.Rows(Increamenter).Cells(1).Value))
                    Increamenter = Increamenter + 1
                Next
                txtTransferredQty.Text = CalculateAmount
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub DGTransfer_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGTransfer.RowsRemoved
        Dim CalculateAmount As Decimal = 0
        Dim Increamenter As Integer = 0
        Try
            For Each Row As DataGridViewRow In DGTransfer.Rows
                CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DGTransfer.Rows(Increamenter).Cells(1).Value))
                Increamenter = Increamenter + 1
            Next
            txtTransferredQty.Text = CalculateAmount
        Catch ex As Exception
        End Try
    End Sub
End Class

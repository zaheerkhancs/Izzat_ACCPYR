Imports System.Data.SqlClient
Imports System.Globalization

Public Class FrmSaleQtyTranfered

    'Dim flag As Boolean = False ' It is with mouse event for practicing form movement.
    Public P As Boolean = False
    Dim xx As Integer
    Dim yy As Integer
    Dim a As Integer
    Dim MyComputerName As String
    Dim MyComputerIP As String
    Dim NewQty As Decimal
    Dim abc As Decimal

    'Dim Var_TransferDate As DateTime ' now It had been transfered to frmsale. No need for it here since new experiment is commented.
    Private Sub FrmSaleQtyTranfered_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '----------------
        ''For retieving computer name and IP.
        'MsgBox(System.Net.Dns.GetHostEntry("localhost").HostName) ' Just for getting the host computer name.
        'Dim MyIP As System.Net.IPHostEntry

        'MyIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())

        ' Dim IP() As System.Net.IPAddress
        ' IP = MyIP.AddressList
        'Dim MyIPAddress As String = IP(0).ToString()
        ' MsgBox(MyIPAddress)
        '----------------------------
        ' Exit Sub
        'Module1.DatasetFill("Select * from SaleSubDetail where SaleID =" & FrmSale.Var_SaleID & " And DGSNo = " & FrmSale.DG.CurrentRow.Cells(0).Value, "SaleSubDetail")
        Try
            If FrmSale.EditValue = 1 Then
                ' Do nothing let is load empty.
            Else

                Call GridFill()
                Me.BringToFront()
                Me.TopMost = True

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        NewQty = txtTransferredQty.Text


        If FrmSale.DG.CurrentRow.Cells("DGCrtnPcs").Value = 1 Then
            abc = NewQty - FrmSale.OldQty
            If abc > Val(txtRemainingStockPcs.Text) Or Val(txtTransferredQty.Text) > Val(txtTotalQty.Text) Then
                MsgBox("INVALID VALUE", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Else
            abc = NewQty - FrmSale.OldQty
            If abc > Val(txtRemainingStock.Text) Or Val(txtTransferredQty.Text) > Val(txtTotalQty.Text) Then
                MsgBox("INVALID VALUE", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        FrmSale.DG.CurrentRow.Cells("DGDeliveredQty").Value = Me.txtTransferredQty.Text
        FrmSale.DG.CurrentRow.Cells("DGRemainingQty").Value = Me.txtRemainingQty.Text
        Me.Visible = False
        '' I have created a datatable and added three columns inside them so that for each row in dgtransfer "The Grid" I store the record.
        '' The following code is working completely correct,but since it is for only one row at a time, so I can't use it.

        Dim Mydatatable As New DataTable
        Dim RowNumberForConcatination As String = FrmSale.DG.CurrentRow.Cells(0).Value
        Mydatatable.TableName = "TableOfRowNo " & RowNumberForConcatination
        Mydatatable.Columns.Add("SaleID")
        Mydatatable.Columns.Add("DGSno")
        Mydatatable.Columns.Add("Sno")
        Mydatatable.Columns.Add("Qty")
        Mydatatable.Columns.Add("trdate")
        For a = 0 To DGTransfer.Rows.Count - 2
            Dim drow As DataRow
            drow = Mydatatable.NewRow
            If FrmSale.EditValue = 1 Then
                drow("SaleID") = FrmSale.Var_SaleID '+ 1
            Else
                drow("SaleID") = FrmSale.Var_SaleID
            End If

            drow("DGSno") = (FrmSale.DG.CurrentRow.Cells(0).Value)
            drow("Sno") = (DGTransfer.Rows(a).Cells("DGTransferredSNo").Value)
            drow("Qty") = (DGTransfer.Rows(a).Cells("DGTransferredQty").Value)
            ' I am going to get only the date portion of the gridvalue
            Dim trdateonly As DateTime
            Dim ci As New CultureInfo("en-GB")
            Dim s As String = DGTransfer.Rows(a).Cells("DGTransferredDate").Value
            If s = Nothing Then
                s = dtQtyTransferredDate.Value.Date
            End If
            ' trdateonly = Convert.ToDateTime(DGTransfer.Rows(a).Cells("DGTransferredDate").Value)
            ' MsgBox(trdateonly.Date.ToShortDateString())
            Try
                trdateonly = Convert.ToDateTime(s)
            Catch ex As Exception
                GoTo x
            End Try
            ' The following row should run only if the date is in US format otherwise jump to next step.
            s = trdateonly.ToString(ci)
x:
            s = s.Substring(0, 10)
            drow("trdate") = s
            Mydatatable.Rows.Add(drow)
        Next
        For Each datatable As DataTable In ds.Tables
            If datatable.TableName.StartsWith("TableOfRowNo") Then
                If datatable.TableName = Mydatatable.TableName Then
                    'MsgBox(datatable.TableName & " already exits yaar!")
                    If ds.Tables.Contains(Mydatatable.TableName) = True Then
                        ds.Tables.Remove(Mydatatable.TableName)
                        Exit For
                        '                    datatable()
                    End If
                End If
                'MsgBox(datatable.TableName)
                'datatable.remo()
            End If
        Next
        ds.Tables.Add(Mydatatable)
        ''To see how many rows are added insite our datatable
        For Each row As DataRow In Mydatatable.Rows
            'MsgBox(row("SaleID").ToString())
            'MsgBox(row("DGSno").ToString())
            'MsgBox(row("Sno").ToString())
            'MsgBox(row("Qty").ToString())
            'MsgBox(row("trdate").ToString())
        Next

        'MsgBox(datatable.TableName) ' & " contains ".Rows.Count)
        ''To see total how many tables are there in our dataset.
        'For Each datatable As DataTable In ds.Tables
        '  MsgBox(datatable.TableName)
        'Next

        ''''Now this is not in use since i keep all the tables inside temporary datatables in RAM. They will be save
        '''' when the main record is saved, otherwise washed.
        '' ''DeleteGrid()
        '' ''GridSave()

    End Sub

    Private Sub txtTransferredQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferredQty.TextChanged
        txtRemainingQty.Text = Val(txtTotalQty.Text) - Val(txtTransferredQty.Text)
    End Sub

    Private Sub txtRemainingQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemainingQty.TextChanged
        txtRemainingQty.Text = Val(txtTotalQty.Text) - Val(txtTransferredQty.Text)
    End Sub

    Private Sub dtQtyTransferredDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtQtyTransferredDate.KeyPress
        DGTransfer.CurrentRow.Cells("DGTransferredDate").Value = dtQtyTransferredDate.Value.Date()
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

    '#Region "New experiment"
    '    Sub GridSave()

    '        Dim cmdsaveGrid As New SqlCommand
    '        cmdsaveGrid.CommandType = CommandType.StoredProcedure
    '        cmdsaveGrid.CommandText = "OnlyInsertSaleSubDetail"
    '        cmdsaveGrid.Connection = cn
    '        Try

    '            For a = 0 To DGTransfer.Rows.Count - 2 ' This is 1 because I haven't allowed an extra row at the end of the DataGrid.
    '                'Trans = cn.BeginTransaction("Fahim")
    '                cmdsaveGrid.Parameters.Add("@SaleID", SqlDbType.Int).Value = Val("0")
    '                cmdsaveGrid.Parameters.Add("@DGSNo", SqlDbType.Int).Value = FrmSale.DG.CurrentRow.Cells(0).Value
    '                cmdsaveGrid.Parameters.Add("@DGTransferredSNo", SqlDbType.Int).Value = DGTransfer.Rows(a).Cells("DGTransferredSNo").Value
    '                cmdsaveGrid.Parameters.Add("@DGTransferredQty", SqlDbType.Decimal).Value = DGTransfer.Rows(a).Cells("DGTransferredQty").Value
    '                Try

    '                    If DGTransfer.Rows(a).Cells("DGTransferredDate").Value = #12:00:00 AM# Then
    '                        Var_TransferDate = "01/01/1900"
    '                        cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate

    '                    Else
    '                        Var_TransferDate = Convert.ToDateTime(DGTransfer.Rows(a).Cells("DGTransferredDate").Value)
    '                        cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate

    '                    End If
    '                Catch ex As Exception
    '                    Var_TransferDate = "01/01/1900"
    '                    cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate

    '                End Try

    '                'Trans.Commit()
    '                cmdsaveGrid.ExecuteNonQuery()
    '                cmdsaveGrid.Parameters.Clear()
    '            Next




    '        Catch ex As Exception
    '            'Trans.Rollback()
    '        End Try


    '    End Sub
    '    Sub DeleteGrid()

    '        Dim cmdsave As New SqlCommand
    '        cmdsave.CommandType = CommandType.StoredProcedure
    '        cmdsave.CommandText = "DeleteSaleSubDetail"
    '        cmdsave.Connection = cn
    '        cmdsave.Parameters.Add("@DGSNo", SqlDbType.Int).Value = FrmSale.DG.CurrentRow.Cells(0).Value
    '        cmdsave.ExecuteNonQuery()

    '    End Sub
    '#End Region

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
            If FrmSale.EditValue = 1 Then
                ' If it is a new record, then we don't need to load any data into the DGTransfer DataGrid.
                Exit Sub
            Else
                Module1.DatasetFill("Select * from SaleSubDetail where SaleID= " & FrmSale.Var_SaleID & " And DGSNo= " & FrmSale.DG.CurrentRow.Cells(0).Value, "SaleSubDetail")

            End If
            'For Each Row As DataRow In ds.Tables("OrderFromCustomerDetail").Rows
            '    DG.Rows.Add()
            '    i = +1
            '    DG.Rows(i).Cells("DGSNo").Value = Row("SNo")
            '    DG.Rows(i).Cells("DGPType").Value = Row("ProdTypeID")
            '    DG.Rows(i).Cells("DGProductName").Value = Row("ProdCode")
            '    DG.Rows(i).Cells("DGQty").Value = Row("Qty")
            '    DG.Rows(i).Cells("DGDesc").Value = Row("ProdDescription")

            'Next
            If ds.Tables("SaleSubDetail").Rows.Count = 0 Then
                DGTransfer.Rows.Clear()
                Exit Sub
            End If
            For i = 0 To ds.Tables("SaleSubDetail").Rows.Count - 1
                DGTransfer.Rows.Add()
                'i = DGDiag.Rows.Count

                DGTransfer.Rows(i).Cells("DGTransferredSNo").Value = ds.Tables("SaleSubDetail").Rows(i).Item("DGTransferredSNo")
                DGTransfer.Rows(i).Cells("DGTransferredQty").Value = ds.Tables("SaleSubDetail").Rows(i).Item("DGTransferredQty")
                DGTransfer.Rows(i).Cells("DGTransferredDate").Value = ds.Tables("SaleSubDetail").Rows(i).Item("DGTransferredDate")


            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GridFillFrom_CurrentRowKaTable()
        Try


            Dim i As Integer = 0
            ' MsgBox(FrmSale.CurrentRowKaTable)
            ' MsgBox(ds.Tables(FrmSale.CurrentRowKaTable).Rows.Count.ToString())
            For Each dtrow As DataRow In ds.Tables(FrmSale.CurrentRowKaTable).Rows

                DGTransfer.Rows.Add()

                DGTransfer.Rows(i).Cells("DGTransferredSNo").Value = dtrow("Sno")
                DGTransfer.Rows(i).Cells("DGTransferredQty").Value = dtrow("Qty")
                'Dim dt As DateTime
                ''Dim sssssss As String = dtrow("trdate")
                ' dt = dtrow("trdate")
                'Dim ci As New CultureInfo("en-GB")
                'Dim Var_date As String = dt.Date.ToString(ci)
                'MsgBox(Var_date)
                'DGTransfer.Rows(i).Cells("DGTransferredDate").Value = Var_date.Substring(0, 10)
                DGTransfer.Rows(i).Cells("DGTransferredDate").Value = dtrow("trdate")

                i = i + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub FrmSaleQtyTranfered_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        flag = True
    '        xx = Me.Left
    '        yy = Me.Top


    '    End If
    'End Sub

    'Private Sub FrmSaleQtyTranfered_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
    '    If flag = True Then
    '        'Me.Left = xx + e.X
    '        'Me.Top = yy + e.Y
    '    End If

    'End Sub

    'Private Sub FrmSaleQtyTranfered_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
    '    If flag Then
    '        'xx = Me.Left
    '        'yy = Me.Top
    '        'Me.Left = xx + e.X + 50
    '        'Me.Top = yy + e.Y + 50
    '    End If

    'End Sub

    'Private Sub FrmSaleQtyTranfered_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
    '    flag = False
    'End Sub

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub

    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DGTransfer.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub DGTransfer_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGTransfer.EditingControlShowing
        Try
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

    Private Sub DGTransfer_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGTransfer.RowsRemoved
        'Dim CalculateAmount As Decimal = 0
        'Dim Increamenter As Integer = 0
        'Try
        '    For Each Row As DataGridViewRow In DGTransfer.Rows
        '        CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DGTransfer.Rows(Increamenter).Cells(1).Value))
        '        Increamenter = Increamenter + 1
        '    Next
        '    txtTransferredQty.Text = CalculateAmount
        'Catch ex As Exception

        'End Try
    End Sub
End Class
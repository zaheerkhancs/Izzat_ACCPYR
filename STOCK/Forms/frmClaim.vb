Imports System.Data.SqlClient
Imports LanguageSelector
Public Class frmClaim
    Dim azizisagoodboy As Boolean
    Dim azizkhoobbachahasta As Boolean
    Dim a As Integer
    Dim k As Integer = 0
    Dim EditValue As Integer
    Dim ClaimID As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim cnt As Integer
    Dim JustForFill As Boolean
    Dim OldTotal As Integer ' only used for DelegateCellData purpose
    Dim TempTable As New DataTable
    Private Sub frmClaim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        TC.Left = pnlcentre.Width / 2 - (TC.Width / 2)
        TC.Top = pnlcentre.Height / 2 - (TC.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text

        azizisagoodboy = False
        azizkhoobbachahasta = False

        Module1.DatasetFill("Select * from VuVendorForClaim", "VuVendorForClaim")
        cmbCompanyName.DataSource = ds.Tables("VuVendorForClaim")
        cmbCompanyName.DisplayMember = ("Name")
        cmbCompanyName.ValueMember = ("VID")
        cmbCompanyName.SelectedIndex = -1

        'TempTable.Columns.Add("Name")
        'TempTable.Columns.Add("VID")

        'ds.Tables.Add(TempTable)

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        DGPType.DataSource = ds.Tables("ProductType")
        DGPType.DisplayMember = ("ProdTypeName")
        DGPType.ValueMember = ("ProdTypeID")

        Module1.DatasetFill("Select ProdCode,Product from VuProduct", "VuProduct")
        DGProductCode.DataSource = ds.Tables("VuProduct")
        DGProductCode.DisplayMember = ("Product")
        DGProductCode.ValueMember = ("ProdCode")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        DGCrtnPcs.DataSource = ds.Tables("CartonPiece")
        DGCrtnPcs.DisplayMember = "Name"
        DGCrtnPcs.ValueMember = "ID"


        Clear(Me, pnlcentre, TC, TP1)

        azizisagoodboy = True
        EditValue = 1
        FillAll()
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region "FUNCTIONS.................."
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuExit.Enabled = Not MnuExit.Enabled
    End Sub
    Sub CStatus(ByVal frm As Form, ByVal pnl As Panel, ByVal TC As TabControl, ByVal TP As TabPage)
        Dim a As Control
        For Each a In frm.Controls
            If TypeOf a Is Panel Then
                Dim b As Control
                For Each b In a.Controls
                    If TypeOf b Is TabControl Then
                        Dim c As Control
                        For Each c In b.Controls
                            If TypeOf c Is TabPage Then
                                If c.Name = "TP1" Then
                                    Dim d As Control
                                    For Each d In c.Controls
                                        If TypeOf d Is ComboBox Or TypeOf d Is DateTimePicker Or TypeOf d Is ToolStrip Then
                                            d.Enabled = Not d.Enabled
                                        ElseIf TypeOf d Is TextBox Or TypeOf d Is Button Then
                                            If d.Name <> txtTotal.ToString Then
                                                d.Enabled = Not d.Enabled
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next
        DG.ReadOnly = Not DG.ReadOnly
    End Sub
    Sub Clear(ByVal frm As Form, ByVal pnl As Panel, ByVal TC As TabControl, ByVal TP As TabPage)
        Dim a As Control
        For Each a In frm.Controls
            If TypeOf a Is Panel Then
                Dim b As Control
                For Each b In a.Controls
                    If TypeOf b Is TabControl Then
                        Dim c As Control
                        For Each c In b.Controls
                            If TypeOf c Is TabPage Then
                                Dim d As Control
                                For Each d In c.Controls
                                    If TypeOf d Is TextBox Then
                                        d.Text = ""
                                    ElseIf TypeOf d Is DateTimePicker Then
                                        d.Text = Now
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
        cmbCompanyName.SelectedIndex = -1
        cmbInvioceNo.SelectedIndex = -1
        DG.Rows.Clear()
        lblMessage.Text = ""
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.CurrentCell.ColumnIndex = 7 Or DG.CurrentCell.ColumnIndex = 8 Or DG.CurrentCell.ColumnIndex = 9 Or DG.CurrentCell.ColumnIndex = 10 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Sub FillAll()
        Try
            DfrmClaimPayment.Var_FormIsOpen = False
            EditValue = 1
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select ClaimID,Name,InvoiceNo,ClaimDate,TotalQty,TotalAmount,TotalPaid,Balance,Remarks from VuClaimMain", "VuClaimMain")
            ClaimID = ds.Tables("VuClaimMain").Rows(cnt).Item("ClaimID")
            cmbCompanyName.Text = ds.Tables("VuClaimMain").Rows(cnt).Item("Name")
            cmbInvioceNo.Text = ds.Tables("VuClaimMain").Rows(cnt).Item("InvoiceNo")
            dtDate.Value = ds.Tables("VuClaimMain").Rows(cnt).Item("ClaimDate")
            txtQtyTotal.Text = ds.Tables("VuClaimMain").Rows(cnt).Item("TotalQty")
            txtTotal.Text = ds.Tables("VuClaimMain").Rows(cnt).Item("TotalAmount")
            txtPaid.Text = ds.Tables("VuClaimMain").Rows(cnt).Item("TotalPaid")
            txtBalance.Text = ds.Tables("VuClaimMain").Rows(cnt).Item("Balance")
            txtRemarks.Text = ds.Tables("VuClaimMain").Rows(cnt).Item("Remarks")
            GridFill()
        Catch ex As Exception
        End Try
    End Sub
    Sub GridFill()
        Try
            Module1.DatasetFill("Select * from VuClaimDetail where ClaimID = " & ClaimID & "", "VuClaimDetail")
            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuClaimDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuClaimDetail").Rows(a).Item("SNO")
                DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuClaimDetail").Rows(a).Item("ProdTypeID")
                DG.Rows(a).Cells("DGProductCode").Value = ds.Tables("VuClaimDetail").Rows(a).Item("ProdCode")
                DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuClaimDetail").Rows(a).Item("PcsInCrtn")
                DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuClaimDetail").Rows(a).Item("PricePerPcs")
                DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuClaimDetail").Rows(a).Item("PricePerCrtn")
                DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("VuClaimDetail").Rows(a).Item("CrtnPcs")
                If DG.Rows(a).Cells("DGCrtnPcs").FormattedValue = "1" Then
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(0).Item("Name")
                Else
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(1).Item("Name")
                End If

                DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuClaimDetail").Rows(a).Item("Qty")
                DG.Rows(a).Cells("DGBroken").Value = ds.Tables("VuClaimDetail").Rows(a).Item("Broken")
                DG.Rows(a).Cells("DGLeak").Value = ds.Tables("VuClaimDetail").Rows(a).Item("Leak")
                DG.Rows(a).Cells("DGShort").Value = ds.Tables("VuClaimDetail").Rows(a).Item("Short")
                DG.Rows(a).Cells("DGDent").Value = ds.Tables("VuClaimDetail").Rows(a).Item("Dent")
                DG.Rows(a).Cells("DGExpired").Value = ds.Tables("VuClaimDetail").Rows(a).Item("Expired")
                DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value = ds.Tables("VuClaimDetail").Rows(a).Item("DecayedBeforeExpiration")
                DG.Rows(a).Cells("DGClaimQty").Value = ds.Tables("VuClaimDetail").Rows(a).Item("ClaimQty")
                DG.Rows(a).Cells("DGPrice").Value = ds.Tables("VuClaimDetail").Rows(a).Item("ClaimAmount")
                DG.Rows(a).Cells("DGDescription").Value = ds.Tables("VuClaimDetail").Rows(a).Item("ProdDescription")

            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub GridFillForClaim()
        Try

            Module1.DatasetFill("Select * from VuPurchaseDetailForClaim where PurchaseID=" & cmbInvioceNo.SelectedValue & "", "VuPurchaseDetailForClaim")
            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuPurchaseDetailForClaim").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuPurchaseDetailForClaim").Rows(a).Item("SNo")
                DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuPurchaseDetailForClaim").Rows(a).Item("ProdTypeID")
                DG.Rows(a).Cells("DGProductCode").Value = ds.Tables("VuPurchaseDetailForClaim").Rows(a).Item("ProdCode")
                DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuPurchaseDetailForClaim").Rows(a).Item("PcsInCrtn")
                DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuPurchaseDetailForClaim").Rows(a).Item("PricePerPcs")
                DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuPurchaseDetailForClaim").Rows(a).Item("PricePerCrtn")
                'DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("").Rows(a).Item("");
                DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuPurchaseDetailForClaim").Rows(a).Item("Qty")
                DG.Rows(a).Cells("DGDescription").Value = "-----"
                DG.Columns("DGSNo").ReadOnly = True
                DG.Columns("DGPType").ReadOnly = True
                DG.Columns("DGProductCode").ReadOnly = True
                DG.Columns("DGQty").ReadOnly = True
                DG.Columns("DGClaimQty").ReadOnly = True
                DG.Columns("DGPcsInCrtn").ReadOnly = True
                DG.Columns("DGPricePerPcs").ReadOnly = True
                DG.Columns("DGPricePerCrtn").ReadOnly = True
                DG.Columns("DGPrice").ReadOnly = True
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub GridPaymentFill()
        Try

            Module1.DatasetFill("Select * from VuClaimPayment where ClaimID=" & ClaimID & "", "VuClaimPayment")
            DfrmClaimPayment.DGDiag.Rows.Clear()
            For a = 0 To ds.Tables("VuClaimPayment").Rows.Count - 1
                Try
                    DfrmClaimPayment.DGDiag.Rows.Add()
                    DfrmClaimPayment.DGDiag.Rows(a).Cells(0).Value = ds.Tables("VuClaimPayment").Rows(a).Item("SNo")
                    DfrmClaimPayment.DGDiag.Rows(a).Cells(1).Value = ds.Tables("VuClaimPayment").Rows(a).Item("Amount")
                    DfrmClaimPayment.DGDiag.Rows(a).Cells(2).Value = ds.Tables("VuClaimPayment").Rows(a).Item("PaymentDate")
                Catch ex As Exception
                End Try
            Next
            DfrmClaimPayment.Var_FormIsOpen = True
        Catch ex As Exception
        End Try
    End Sub
    Sub calc()
        Dim Total As Double = 0
        Dim TotalQty As Double = 0
        Dim a As Integer
        Try
            For a = 0 To DG.Rows.Count - 1

                Total = Total + Val(DG.Rows(a).Cells("DGPrice").Value)
                TotalQty = TotalQty + Val(DG.Rows(a).Cells("DGClaimQty").Value)
            Next
            Me.txtTotal.Text = Total
            Me.txtQtyTotal.Text = TotalQty
        Catch ex As Exception
        End Try
    End Sub
    Sub calcQtySearch()
        Dim TotalSearch As Double = 0
        Dim TotalQtySearch As Double = 0
        Dim o As Integer
        Try
            For o = 0 To DGSearch.Rows.Count - 1
                If DGSearch.Rows(o).Cells("DGSCrtnPcs").Value = "دانه" Then
                    TotalSearch = TotalSearch + Val(DGSearch.Rows(o).Cells("DGSTotalQty").Value)
                Else
                    TotalQtySearch = TotalQtySearch + Val(DGSearch.Rows(o).Cells("DGSTotalQty").Value)
                End If
            Next
            Me.txtTotalPcs.Text = TotalSearch
            Me.txtTotalCrtn.Text = TotalQtySearch
        Catch ex As Exception
        End Try
    End Sub
    Sub CalcQty()
        Dim Total As Double = 0
        Dim TotalPrice As Double = 0
        'Dim a As Integer
        Try
            'For a = 0 To DG.Rows.Count - 1
            Total = Total + Val(DG.CurrentRow.Cells("DGBroken").Value) + Val(DG.CurrentRow.Cells("DGLeak").Value) + Val(DG.CurrentRow.Cells("DGShort").Value) + Val(DG.CurrentRow.Cells("DGDent").Value) + Val(DG.CurrentRow.Cells("DGExpired").Value) + Val(DG.CurrentRow.Cells("DGDecayedBeforeExpiration").Value)
            'Next
            DG.CurrentRow.Cells("DgClaimQty").Value = Total
            OldTotal = Total ' this in included for Delegate cell data
            Try
                If DG.CurrentRow.Cells("DGCrtnPcs").Value = 2 Then 'to compare with the value of daana
                    TotalPrice = Val(DG.CurrentRow.Cells("DGClaimQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerCrtn").Value)
                Else
                    TotalPrice = Val(DG.CurrentRow.Cells("DGClaimQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerPcs").Value)
                End If

            Catch ex As Exception
                ' MessageBox.Show(ex.Message)
            End Try

        
            DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
        Catch ex As Exception
        End Try
    End Sub
    Sub IDChecker()
        Module1.DatasetFill("Select * from ClaimMain", "ClaimMain")
        cmd.CommandText = "Select isnull(Max(ClaimID),0) from ClaimMain"
        ClaimID = cmd.ExecuteScalar + 1
    End Sub
    Sub SaveUpdateClaimMain()
        Try

            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateClaimMain"
            cmdsave.Connection = cn
            If EditValue = 1 Then
                IDChecker()
            End If
            cmdsave.Parameters.Add("@ClaimID", SqlDbType.Int).Value = ClaimID
            cmdsave.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = Me.cmbInvioceNo.SelectedValue
            cmdsave.Parameters.Add("@CompanyID", SqlDbType.Int).Value = Me.cmbCompanyName.SelectedValue
            cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Me.cmbInvioceNo.Text
            cmdsave.Parameters.Add("@ClaimDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmdsave.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Val(txtQtyTotal.Text)
            cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Val(txtTotal.Text)
            cmdsave.Parameters.Add("@TotalPaid", SqlDbType.Decimal).Value = Val(txtPaid.Text)
            cmdsave.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Val(txtBalance.Text)
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & ClaimID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If EditValue = 1 Then
                SaveUpdateClaimDetail()
                SaveClaimPayment()
                SaveIGL()
                CMStatus()
                CStatus(Me, pnlcentre, TC, TP1)
                'FillAll()
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            Else
                If ds.Tables.Contains("VuClaimPayment") Then
                    DeleteClaimPayment()
                    SaveClaimPayment()
                    ds.Tables.Remove("VuClaimPayment")
                End If
                DeleteClaimDetail()
                SaveUpdateClaimDetail()
                CMStatus()
                CStatus(Me, pnlcentre, TC, TP1)
                FillAll()
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                EditValue = 1
            End If

        Catch ex As Exception
        End Try
        If ds.Tables.Contains("VuClaimPayment") Then
            ds.Tables.Remove("VuClaimPayment")
        End If
    End Sub
    Sub DeleteClaimDetail()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteClaimDetail"
        cmdDelete.Parameters.Add("@ClaimID", SqlDbType.Int).Value = ClaimID
        cmdDelete.ExecuteNonQuery()
    End Sub
    Sub SaveUpdateClaimDetail()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateClaimDetail"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 2
                cmdsaveGrid.Parameters.Add("@ClaimID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@ClaimID").Value = ClaimID

                cmdsaveGrid.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNo").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value
                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPcsInCrtn").Value
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerPcs").Value
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerCrtn").Value
                Dim Var As String = DG.Rows(a).Cells("DGCrtnPcs").Value
                If Var = "2" Or Var = "کارتن" Then
                    cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(1).Item("ID")
                Else
                    cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(0).Item("ID")
                End If
                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGQty").Value
                cmdsaveGrid.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGBroken").Value)
                cmdsaveGrid.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGLeak").Value)
                cmdsaveGrid.Parameters.Add("@Short", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGShort").Value)
                cmdsaveGrid.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGDent").Value)
                cmdsaveGrid.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGExpired").Value)
                cmdsaveGrid.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value)
                cmdsaveGrid.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGClaimQty").Value
                cmdsaveGrid.Parameters.Add("@ClaimAmount", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPrice").Value
                If DG.Rows(a).Cells("DGDescription").Value = Nothing Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = "---"
                Else

                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value

                End If
                cmdsaveGrid.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = cmbInvioceNo.Text ' I am saving this only for making it possible to be picked up in ClaimEnglish Form.
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
                If EditValue <> 1 Then
                    UpdateIGL()
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub DeleteClaimPayment()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteClaimPayment"
        cmdDelete.Parameters.Add("@ClaimID", SqlDbType.Int).Value = ClaimID
        cmdDelete.ExecuteNonQuery()
    End Sub
    Sub SaveClaimPayment()
        Dim cmdsaveGrid1 As New SqlCommand
        cmdsaveGrid1.CommandType = CommandType.StoredProcedure
        cmdsaveGrid1.CommandText = "InsertClaimPayment"
        cmdsaveGrid1.Connection = cn
        Try
            For a = 0 To DfrmClaimPayment.DGDiag.Rows.Count - 2
                cmdsaveGrid1.Parameters.Add("@ClaimID", SqlDbType.Int)
                cmdsaveGrid1.Parameters("@ClaimID").Value = ClaimID

                cmdsaveGrid1.Parameters.Add("@SNO", SqlDbType.Int).Value = DfrmClaimPayment.DGDiag.Rows(a).Cells(0).Value
                cmdsaveGrid1.Parameters.Add("@Amount", SqlDbType.Decimal).Value = DfrmClaimPayment.DGDiag.Rows(a).Cells(1).Value
                'cmdsaveGrid1.Parameters.Add("@dtDate", SqlDbType.NVarChar).Value = DfrmPurchasePayment.DGDiag.Rows(a).Cells(2).Value

                Dim Var_PaymentDate As DateTime
                Try
                    If DfrmClaimPayment.DGDiag.Rows(a).Cells(2).Value = #12:00:00 AM# Then
                        Var_PaymentDate = "01/01/1900"
                        cmdsaveGrid1.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    Else
                        Var_PaymentDate = DfrmClaimPayment.DGDiag.Rows(a).Cells(2).Value
                        cmdsaveGrid1.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    End If
                Catch ex As Exception
                    Var_PaymentDate = "01/01/1900"
                    cmdsaveGrid1.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                End Try

                cmdsaveGrid1.ExecuteNonQuery()
                cmdsaveGrid1.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveIGL()
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn
        Try
            For k = 0 To DG.Rows.Count - 2

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = ClaimID

                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Claim"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(k).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("DGproductCode").Value
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGClaimQty").Value)
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                Dim Var As String = DG.Rows(k).Cells("DGCrtnPcs").Value
                If Var = "2" Or Var = "کارتن" Then
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(1).Item("ID")
                Else
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(0).Item("ID")
                End If
                'cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = DG.Rows(k).Cells("DGCrtnPcs").Value
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGBroken").Value)
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGLeak").Value)
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGShort").Value)
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGDent").Value)
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(k).Cells("DGExpired").Value)
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(k).Cells("DGDecayedBeforeExpiration").Value)


                Try
                    If DG.Rows(k).Cells("DGDescription").Value = "" Then
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                    Else
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(k).Cells("DGDescription").Value
                    End If
                Catch ex As Exception
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                End Try

                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & ClaimID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub UpdateIGL()
        Dim OldQty As Decimal = 0
        Dim NewQty As Decimal = 0
        Dim TotalQty As Decimal = 0
        Dim OldBroken As Decimal = 0
        Dim NewBroken As Decimal = 0
        Dim TotalBroken As Decimal = 0
        Dim OldLeak As Decimal = 0
        Dim NewLeak As Decimal = 0
        Dim TotalLeak As Decimal = 0
        Dim OldShort As Decimal = 0
        Dim NewShort As Decimal = 0
        Dim TotalShort As Decimal = 0
        Dim OldDent As Decimal = 0
        Dim NewDent As Decimal = 0
        Dim TotalDent As Decimal = 0
        Dim TotalExpired As Decimal = 0
        Dim OldExpired As Decimal = 0
        Dim NewExpired As Decimal = 0
        Dim TotalDecayedBeforeExpiration As Decimal = 0
        Dim OldDecayedBeforeExpiration As Decimal = 0
        Dim NewDecayedBeforeExpiration As Decimal = 0

        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn

        Try

            Module1.DatasetFill("Select Sum(ClaimQty)as ClaimQuantity from VuIGL where ID=" & ClaimID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldQty = ds.Tables("VuIGL").Rows(0).Item("ClaimQuantity")
            NewQty = Val(DG.Rows(a).Cells("DGClaimQty").Value)
            TotalQty = NewQty - OldQty
        Catch ex As Exception
        End Try

        If TotalQty = 0 Then
            Exit Sub
        End If


        Try

            Module1.DatasetFill("Select Sum(Broken)as BrokenQuantity from VuIGL where ID=" & ClaimID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldBroken = ds.Tables("VuIGL").Rows(0).Item("BrokenQuantity")
            NewBroken = Val(DG.Rows(a).Cells("DGBroken").Value)
            TotalBroken = NewBroken - OldBroken
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Leak)as LeakQuantity from VuIGL where ID=" & ClaimID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldLeak = ds.Tables("VuIGL").Rows(0).Item("LeakQuantity")
            NewLeak = Val(DG.Rows(a).Cells("DGLeak").Value)
            TotalLeak = NewLeak - OldLeak
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Short)as ShortQuantity from VuIGL where ID=" & ClaimID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldShort = ds.Tables("VuIGL").Rows(0).Item("ShortQuantity")
            NewShort = Val(DG.Rows(a).Cells("DGShort").Value)
            TotalShort = NewShort - OldShort
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Dent)as DentQuantity from VuIGL where ID=" & ClaimID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldDent = ds.Tables("VuIGL").Rows(0).Item("DentQuantity")
            NewDent = Val(DG.Rows(a).Cells("DGDent").Value)
            TotalDent = NewDent - OldDent
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Expired)as ExpiredQuantity from VuIGL where ID=" & ClaimID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldExpired = ds.Tables("VuIGL").Rows(0).Item("ExpiredQuantity")
            NewExpired = Val(DG.Rows(a).Cells("DGExpired").Value)
            TotalExpired = NewExpired - OldExpired
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(DecayedBeforeExpiration)as DecayedBeforeExpirationQuantity from VuIGL where ID=" & ClaimID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldDecayedBeforeExpiration = ds.Tables("VuIGL").Rows(0).Item("DecayedBeforeExpirationQuantity")
            NewDecayedBeforeExpiration = Val(DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value)
            TotalDecayedBeforeExpiration = NewDecayedBeforeExpiration - OldDecayedBeforeExpiration
        Catch ex As Exception
        End Try

        Try
            For k = 0 To 1 - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = ClaimID
                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = dtDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Claim"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = TotalQty
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                Dim Var As String = DG.Rows(k).Cells("DGCrtnPcs").Value
                If Var = "2" Or Var = "کارتن" Then
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(1).Item("ID")
                Else
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(0).Item("ID")
                End If

                'cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = Val(DG.Rows(k).Cells("DGCrtnPcs").Value)
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = TotalBroken
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = TotalLeak
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = TotalShort
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = TotalDent
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = TotalExpired
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = TotalDecayedBeforeExpiration

                Try
                    If DG.Rows(a).Cells("DGDescription").Value = "" Then
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                    Else
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value
                    End If
                Catch ex As Exception
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                End Try


                'cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = "Purchase"
                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & ClaimID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " CONTEXT MENUS ..................."
    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        CMStatus()
        CStatus(Me, pnlcentre, TC, TP1)
        Clear(Me, pnlcentre, TC, TP1)
    End Sub

    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        CMStatus()
        CStatus(Me, pnlcentre, TC, TP1)
        Clear(Me, pnlcentre, TC, TP1)
        FillAll()
    End Sub
    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        SaveUpdateClaimMain()
    End Sub
    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        CMStatus()
        CStatus(Me, pnlcentre, TC, TP1)
        EditValue = 0
    End Sub
    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from ClaimMain where ClaimID = " & ClaimID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from IGL where ID=" & ClaimID & "  And Type='Claim'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuClaimMain").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear(Me, pnlcentre, TC, TP1)
            End If
            Call FillAll()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
        End If
    End Sub
    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region

#Region " Navigations "
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        FillAll()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        FillAll()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuClaimMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        FillAll()
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuClaimMain").Rows.Count - 1
        FillAll()
    End Sub
#End Region

#Region "EVENTS..............."
    Private Sub cmbCompanyName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompanyName.SelectedIndexChanged
        If azizisagoodboy = True Then
            'If cmbCompanyName.Enabled = True Then
            'If JustForFill = False Then
            '    Try
            '        Module1.DatasetFill("Select * from VuInvioceForClaim where VID=" & cmbCompanyName.SelectedValue & " And InvoiceNo Not In(Select InvoiceNo from ClaimMain)", "VuInvioceForClaim")
            '        'Module1.DatasetFill("Select * from VuInvioceForClaim where VID=" & cmbCompanyName.SelectedValue & "", "VuInvioceForClaim")
            '        cmbInvioceNo.DataSource = ds.Tables("VuInvioceForClaim")
            '        cmbInvioceNo.DisplayMember = ("InvoiceNo")
            '        cmbInvioceNo.ValueMember = ("PurchaseID")
            '        cmbInvioceNo.SelectedIndex = -1
            '        azizkhoobbachahasta = True
            '        DG.Rows.Clear()
            '    Catch ex As Exception
            '        cmbInvioceNo.DataSource = Nothing
            '        cmbInvioceNo.Items.Clear()
            '    End Try
            'Else
            Try
                'Module1.DatasetFill("Select * from VuInvioceForClaim where VID=" & cmbCompanyName.SelectedValue & " And InvoiceNo Not In(Select InvoiceNo from ClaimMain)", "VuInvioceForClaim")
                Module1.DatasetFill("Select * from VuInvioceForClaim where VID=" & cmbCompanyName.SelectedValue & "", "VuInvioceForClaim")
                cmbInvioceNo.DataSource = ds.Tables("VuInvioceForClaim")
                cmbInvioceNo.DisplayMember = ("InvoiceNo")
                cmbInvioceNo.ValueMember = ("PurchaseID")
                cmbInvioceNo.SelectedIndex = -1
                azizkhoobbachahasta = True
                DG.Rows.Clear()
            Catch ex As Exception
                cmbInvioceNo.DataSource = Nothing
                cmbInvioceNo.Items.Clear()
            End Try
        End If
        'End If
    End Sub
    Private Sub cmbInvioceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInvioceNo.SelectedIndexChanged
        If azizkhoobbachahasta = True Then
            'If cmbInvioceNo.Enabled = True Then
            Call GridFillForClaim()
            'End If
        End If
    End Sub
    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Dim TotalPrice As Double = 0
        Try
            calc()
        Catch ex As Exception
        End Try

        'Try
        '    If DG.CurrentRow.Cells("DGCrtnPcs").Value = 2 Then
        '        TotalPrice = Val(DG.CurrentRow.Cells("DGClaimQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerCrtn").Value)
        '        DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
        '    Else

        '        TotalPrice = Val(DG.CurrentRow.Cells("DGClaimQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerPcs").Value)
        '        DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
        '    End If

        'Catch ex As Exception

        'End Try

        'Try
        '    TotalPrice = Val(DG.CurrentRow.Cells("DGClaimQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerPcs").Value)
        '    DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        If DG.CurrentCell.ColumnIndex = 7 Then
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
    End Sub
    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtRemarks.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region

    Private Sub DG_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Try
            CalcQty()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If ClaimID = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptVuClaimMain where ClaimID=" & ClaimID, "RptVuClaimMain")
                Dim rpt As New RptClaim
                rpt.SetDataSource(Module1.ds.Tables("RptVuClaimMain"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
        txtBalance.Text = Val(txtTotal.Text) - Val(txtPaid.Text)
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        If cmbInvioceNo.Text = "" Then
            MsgBox("PLEASE GIVE A VALID INVOICE NO", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If EditValue <> 1 Then
                DfrmClaimPayment.txtInvoice.Text = cmbInvioceNo.Text
                DfrmClaimPayment.txtTotalToPay.Text = txtTotal.Text
                'DfrmClaimPayment.txtBalance.Text = txtTotal.Text
                DfrmClaimPayment.Visible = True
                DfrmClaimPayment.TopMost = True
                If DfrmClaimPayment.Var_FormIsOpen = True Then
                Else
                    GridPaymentFill()
                End If
            Else
                If DfrmClaimPayment.Var_FormIsOpen = True Then
                    DfrmClaimPayment.Visible = True
                Else
                    DfrmClaimPayment.txtInvoice.Text = cmbInvioceNo.Text
                    DfrmClaimPayment.txtTotalToPay.Text = txtTotal.Text
                    DfrmClaimPayment.txtBalance.Text = txtTotal.Text
                    DfrmClaimPayment.DGDiag.Rows.Clear()
                    DfrmClaimPayment.Visible = True
                    DfrmClaimPayment.TopMost = True
                    DfrmClaimPayment.Var_FormIsOpen = True
                End If
            End If
        End If
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
        Dim Total As Double = 0

        Try
            Total = Total + Val(DG.CurrentRow.Cells("DGBroken").Value) + Val(DG.CurrentRow.Cells("DGLeak").Value) + Val(DG.CurrentRow.Cells("DGShort").Value) + Val(DG.CurrentRow.Cells("DGDent").Value) + Val(DG.CurrentRow.Cells("DGExpired").Value) + Val(DG.CurrentRow.Cells("DGDecayedBeforeExpiration").Value)

            If Val(Me.DG.CurrentRow.Cells("DGQty").Value) < Val(Total) Then
                DG.CurrentCell.Value = 0
                e.Handled = True
                Total = OldTotal
            Else
                e.Handled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCompanyName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCompanyName.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub
    Private Sub TP2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TP2.Enter
        Try
            Module1.DatasetFill("Select VID,Name from Vendor", "Vendor")
            cmbCompanySearch.DataSource = ds.Tables("Vendor")
            cmbCompanySearch.DisplayMember = ("Name")
            cmbCompanySearch.ValueMember = ("VID")

            cmbInvoiceNoSearch.SelectedIndex = -1
            DGSearch.Rows.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCompanySearch_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompanySearch.SelectionChangeCommitted
        Try
            Module1.DatasetFill("Select Distinct InvoiceNo from ClaimMain where CompanyID=" & cmbCompanySearch.SelectedValue, "ClaimMain")
            cmbInvoiceNoSearch.DataSource = ds.Tables("ClaimMain")
            cmbInvoiceNoSearch.DisplayMember = ("InvoiceNo")
            'cmbInvoiceNoSearch.ValueMember = ("InvoiceNo")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim x As Integer
        Try
            Module1.DatasetFill("Select * from VuClaimSearch where CompanyID=" & cmbCompanySearch.SelectedValue & " and InvoiceNo='" & cmbInvoiceNoSearch.Text & "'", "VuClaimSearch")
            DGSearch.Rows.Clear()
            For x = 0 To ds.Tables("VuClaimSearch").Rows.Count - 1
                DGSearch.Rows.Add()
                DGSearch.Rows(x).Cells("DGSSNO").Value = x + 1
                DGSearch.Rows(x).Cells("DGSPType").Value = ds.Tables("VuClaimSearch").Rows(x).Item("ProdTypeName")
                DGSearch.Rows(x).Cells("DGSPName").Value = ds.Tables("VuClaimSearch").Rows(x).Item("Product")
                DGSearch.Rows(x).Cells("DGSQtyInCrtn").Value = ds.Tables("VuClaimSearch").Rows(x).Item("PcsInCrtn")
                DGSearch.Rows(x).Cells("DGSPricePerPcs").Value = ds.Tables("VuClaimSearch").Rows(x).Item("PricePerPcs")
                DGSearch.Rows(x).Cells("DGSPricePerCrtn").Value = ds.Tables("VuClaimSearch").Rows(x).Item("PricePerCrtn")
                DGSearch.Rows(x).Cells("DGSCrtnPcs").Value = ds.Tables("VuClaimSearch").Rows(x).Item("Name")
                DGSearch.Rows(x).Cells("DGSBroken").Value = ds.Tables("VuClaimSearch").Rows(x).Item("Broken")
                DGSearch.Rows(x).Cells("DGSLeak").Value = ds.Tables("VuClaimSearch").Rows(x).Item("Leak")
                DGSearch.Rows(x).Cells("DGSShort").Value = ds.Tables("VuClaimSearch").Rows(x).Item("Short")
                DGSearch.Rows(x).Cells("DGSDent").Value = ds.Tables("VuClaimSearch").Rows(x).Item("Dent")
                DGSearch.Rows(x).Cells("DGSExpired").Value = ds.Tables("VuClaimSearch").Rows(x).Item("Expired")
                DGSearch.Rows(x).Cells("DGSBeforeExpired").Value = ds.Tables("VuClaimSearch").Rows(x).Item("DecayedBeforeExpiration")
                DGSearch.Rows(x).Cells("DGSTotalQty").Value = ds.Tables("VuClaimSearch").Rows(x).Item("ClaimQty")
                DGSearch.Rows(x).Cells("DGSPrice").Value = ds.Tables("VuClaimSearch").Rows(x).Item("ClaimAmount")
                DGSearch.Rows(x).Cells("DGSDescription").Value = ds.Tables("VuClaimSearch").Rows(x).Item("ProdDescription")

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGSearch_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellValueChanged
        Try
            calcQtySearch()
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class FrmDamagesOfSaleman

    Dim Var_DamageID As Integer
    Dim CurrowIndex As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim EditValue As Integer
    Dim a As Integer
    Dim cnt As Integer
    Dim StrSearch As String

    Dim AddEdit As Boolean = False
    Private Sub FrmDamagesOfSaleman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text

        Module1.DatasetFill("Select * from Customer where CustomerTypeID =1 ", "Customer")
        Call ComboFillerOfFahimshekaib(cmbCustomerName, "Customer", "CustomerName", "CustomerID")
        Call ComboFillerOfFahimshekaib(CmbCustomerNameSearch, "Customer", "CustomerName", "CustomerID")

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Call ComboFillerOfFahimshekaib(DGPType, "ProductType", "ProdTypeName", "ProdTypeID")

        Module1.DatasetFill("Select * from VuProduct", "VuProduct")
        Call ComboFillerOfFahimshekaib(DGProductCode, "VuProduct", "Product", "ProdCode")

        'Module1.DatasetFill("Select * from ProductType", "ProductType")
        'Call ComboFillerOfFahimshekaib(CmbProductTypeSearch, "ProductType", "ProdTypeName", "ProdTypeID")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        Call ComboFillerOfFahimshekaib(DGCrtnPcs, "CartonPiece", "Name", "ID")
        EditValue = 1
        dtDates.Value = Now

        fill()
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub
#Region " FUNCTIONS ................ "
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuExit.Enabled = Not MnuExit.Enabled
    End Sub
    Sub CStatus()
        dtDates.Enabled = Not dtDates.Enabled
        cmbCustomerName.Enabled = Not cmbCustomerName.Enabled
        txtRemarks.Enabled = Not txtRemarks.Enabled
        DG.ReadOnly = Not DG.ReadOnly
        DGTotalQty.ReadOnly = True
        DGPrice.ReadOnly = True
        DGPcsInCrtn.ReadOnly = True
        DGPricePerCrtn.ReadOnly = True
        DGPricePerPcs.ReadOnly = True
        DGProductName.ReadOnly = True
    End Sub
    Public Sub CStatusDefault()
        cmbCustomerName.Enabled = False
        dtDates.Enabled = False
        cmbCustomerName.Enabled = False
        txtRemarks.Enabled = False
    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        txtRemarks.Text = ""
        DG.Rows.Clear()
        dtDates.Value = Now
        txtTotalToPay.Text = ""
        txtTotalDamagedProducts.Text = ""
        txtTotalDamgaproductsCrtn.Text = ""
        DGProductCode.Visible = True
    End Sub
    Sub calc()
        Dim Total As Double = 0
        Dim TotalQtyCrtn As Double = 0
        Dim TotalQtyPcs As Double = 0
        Dim a As Integer
        Try
            For a = 0 To DG.Rows.Count - 1
                Total = Total + Val(DG.Rows(a).Cells("DGPrice").Value)
                If DG.Rows(a).Cells("DGCrtnPcs").Value = 2 Then
                    TotalQtyCrtn = TotalQtyCrtn + Val(DG.Rows(a).Cells("DGTotalQty").Value)
                Else
                    TotalQtyPcs = TotalQtyPcs + Val(DG.Rows(a).Cells("DGTotalQty").Value)
                End If
            Next
            Me.txtTotalToPay.Text = Total
            Me.txtTotalDamagedProducts.Text = TotalQtyPcs
            Me.txtTotalDamgaproductsCrtn.Text = TotalQtyCrtn
        Catch ex As Exception
        End Try
    End Sub
    Sub CalcQty()
        Dim Total As Double = 0
        Dim TotalPrice As Double = 0
        Try
            Total = Total + Val(DG.CurrentRow.Cells("DGBroken").Value) + Val(DG.CurrentRow.Cells("DGLeak").Value) + Val(DG.CurrentRow.Cells("DGShort").Value) + Val(DG.CurrentRow.Cells("DGDent").Value) + Val(DG.CurrentRow.Cells("DGOthers").Value)
            DG.CurrentRow.Cells("DgTotalQty").Value = Total
        Catch ex As Exception
        End Try
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.CurrentCell.ColumnIndex = 8 Or DG.CurrentCell.ColumnIndex = 9 Or DG.CurrentCell.ColumnIndex = 10 Or DG.CurrentCell.ColumnIndex = 11 Or DG.CurrentCell.ColumnIndex = 12 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Sub k1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                DG.CurrentRow.Cells(1).Value = sender.text
                Module1.DatasetFill("Select ProdCode,Product from VuProduct where ProdTypeName = N'" & DG.CurrentRow.Cells(1).Value & "'", "VuProduct")
                DGProductCode.DataSource = ds.Tables("VuProduct")
                DGProductCode.DisplayMember = ("Product")
                DGProductCode.ValueMember = ("ProdCode")
                CurrowIndex = DG.CurrentRow.Index
                DG.CurrentRow.Cells(3).Value = ""
                DG.CurrentRow.Cells(4).Value = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub K2(ByVal sender As Object, ByVal e As System.EventArgs)
        If DG.CurrentCell.ColumnIndex = 2 Then
            DG.CurrentRow.Cells(3).Value = sender.text
            DG.CurrentRow.Cells(4).Value = sender.selectedvalue
            CurrowIndex = DG.CurrentRow.Index

            Try
                GridFillForPrice()
            Catch ex As Exception

            End Try

        End If
    End Sub
    Sub IDPICKER()
        Module1.DatasetFill("Select * from DamageMainSaleman", "DamageMainSaleman")
        cmd.CommandText = "Select isnull(Max(DamID),0) from DamageMainSaleman"
        Var_DamageID = cmd.ExecuteScalar + 1
    End Sub
    Sub SaveUpdateDamageMainSalemanCustomer()
        Try
            If EditValue.Equals(1) Then

                If cmbCustomerName.Visible.Equals(True) Then


                    Module1.DatasetFill("Select * from VuReturnForComboOnlyCheckForDuplicateEntry where InvoiceNo='" & cmbCustomerName.Text & "'", "VuReturnForComboOnlyCheckForDuplicateEntry")
                    If ds.Tables("VuReturnForComboOnlyCheckForDuplicateEntry").Rows.Count.Equals(1) Then
                        MsgBox("Duplicate entry for same Invoice No is not allowed, but u can edit it")
                        Exit Sub
                    End If
                End If

            End If
            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateDamageMainSaleman"
            cmdsave.Connection = cn


            If EditValue = 1 Then
                IDPICKER()
            End If
            ' This is main sectiond data so there is no for loop etc.
            cmdsave.Parameters.Add("@DamID", SqlDbType.Int).Value = Var_DamageID
            cmdsave.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = cmbCustomerName.SelectedValue
            cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDates.Value.Date
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = txtRemarks.Text.Trim()
            cmdsave.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Me.txtTotalDamagedProducts.Text
            cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Me.txtTotalToPay.Text
            cmdsave.Parameters.Add("@TotalAmountCrtn", SqlDbType.Decimal).Value = Me.txtTotalDamgaproductsCrtn.Text
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Var_DamageID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            AddEdit = False ' It means that saving or updation is successful and now we need to assign it false before calling fill().

            If EditValue = 1 Then
                SaveUpdateDamageDetailSaleman()
                CMStatus()
                CStatus()

                fill()
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
            Else
                DeleteDamageDetailSaleman()
                SaveUpdateDamageDetailSaleman()
                CMStatus()
                CStatus()
                fill()
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                EditValue = 1
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub DeleteDamageDetailSaleman()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteDamageDetailSaleman"
        cmdDelete.Parameters.Add("@DamID", SqlDbType.Int).Value = Var_DamageID
        cmdDelete.ExecuteNonQuery()
    End Sub
    Sub SaveUpdateDamageDetailSaleman()

        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateDamageDetailSaleman"
        cmdsaveGrid.Connection = cn
        Try

            For a = 0 To DG.Rows.Count - 2
                cmdsaveGrid.Parameters.Add("@DamID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@DamID").Value = Var_DamageID


                cmdsaveGrid.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSno").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("ID").Value
                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPcsInCrtn").Value
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerPcs").Value
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerCrtn").Value
                cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGCrtnPcs").Value
                cmdsaveGrid.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGBroken").Value)
                cmdsaveGrid.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGLeak").Value)
                cmdsaveGrid.Parameters.Add("@Short", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGShort").Value)
                cmdsaveGrid.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGDent").Value)
                cmdsaveGrid.Parameters.Add("@Others", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGOthers").Value)
                cmdsaveGrid.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGTotalQty").Value)
                cmdsaveGrid.Parameters.Add("@Price", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DgPrice").Value)
                cmdsaveGrid.Parameters.Add("@DamageReason", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DgDescription").Value
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub GridFillForPrice()
        Try
            Module1.DatasetFill("Select PcsInCtrn,SalPerPiece,SalPerCrtn from VuProductPrices where ProdTypeID = " & DG.CurrentRow.Cells("DGPType").Value & " and ProdCode =" & DG.CurrentRow.Cells("ID").Value & "", "VuProductPrices")
            DG.CurrentRow.Cells("DGPcsInCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PcsInCtrn")
            DG.CurrentRow.Cells("DGPricePerPcs").Value = ds.Tables("VuProductPrices").Rows(0).Item("SalPerPiece")
            DG.CurrentRow.Cells("DGPricePerCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("SalPerCrtn")
            DG.CurrentRow.Cells("DGDescription").Value = "------"
        Catch ex As Exception
        End Try
    End Sub
    Sub fill()
        Try

            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from VuDamageMainSaleman", "VuDamageMainSaleman")
            If ds.Tables("VuDamageMainSaleman").Rows.Count = 0 Then
                txtTotalToPay.Text = ""
                txtTotalDamagedProducts.Text = ""
                Exit Sub
            End If

            DGProductCode.Visible = False
            Var_DamageID = ds.Tables("VuDamageMainSaleman").Rows(cnt).Item("DamID")
            cmbCustomerName.SelectedValue = ds.Tables("VuDamageMainSaleman").Rows(cnt).Item("CustomerID")
            dtDates.Value = ds.Tables("VuDamageMainSaleman").Rows(cnt).Item("dtDate")
            txtTotalToPay.Text = ds.Tables("VuDamageMainSaleman").Rows(cnt).Item("TotalQty")
            txtTotalDamagedProducts.Text = ds.Tables("VuDamageMainSaleman").Rows(cnt).Item("TotalAmount")
            txtTotalDamgaproductsCrtn.Text = ds.Tables("VuDamageMainSaleman").Rows(cnt).Item("TotalAmountCrtn")
            txtRemarks.Text = ds.Tables("VuDamageMainSaleman").Rows(cnt).Item("Remarks")
            Call Gridfill()
        Catch ex As Exception
        End Try
    End Sub
    Sub Gridfill()
        Try

            Module1.DatasetFill("Select * from VuDamageDetailSaleman where DamId=" & Var_DamageID & "", "VuDamageDetailSaleman")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuDamageDetailSaleman").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("ProdTypeID")
                    DG.Rows(a).Cells("DGProductName").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("Product")
                    DG.Rows(a).Cells("DGProductCode").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("ID").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("PcsInCrtn")
                    DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("PricePerPcs")
                    DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("PricePerCrtn")
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("CrtnPcs")
                    DG.Rows(a).Cells("DGBroken").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("Broken")
                    DG.Rows(a).Cells("DGLeak").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("Leak")
                    DG.Rows(a).Cells("DGShort").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("Short")
                    DG.Rows(a).Cells("DGDent").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("Dent")
                    DG.Rows(a).Cells("DGOthers").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("Others")
                    DG.Rows(a).Cells("DGTotalQty").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("TotalQty")
                    DG.Rows(a).Cells("DGPrice").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("Price")
                    DG.Rows(a).Cells("DGDescription").Value = ds.Tables("VuDamageDetailSaleman").Rows(a).Item("DamageReason")

                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub GridFillSearch()
        Dim i As Integer
        Try
            DGSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = StrSearch
            If (ds.Tables.Contains("VuDamageOfSaleManSearch")) Then
                ds.Tables("VuDamageOfSaleManSearch").Clear()
                DGSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuDamageOfSaleManSearch")

            For i = 0 To ds.Tables("VuDamageOfSaleManSearch").Rows.Count - 1
                Try
                    DGSearch.Rows.Add()

                    DGSearch.Rows(i).Cells("DGDateSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("dtDate")
                    DGSearch.Rows(i).Cells("DGPTypeSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("ProdTypeName")
                    DGSearch.Rows(i).Cells("DGProdNameSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("Product")
                    DGSearch.Rows(i).Cells("DGCrtnPcsSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("Name")
                    DGSearch.Rows(i).Cells("DGBrokenSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("Broken")
                    DGSearch.Rows(i).Cells("DGLeakSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("Leak")
                    DGSearch.Rows(i).Cells("DGShortSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("Short")
                    DGSearch.Rows(i).Cells("DGDentSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("Dent")
                    DGSearch.Rows(i).Cells("DGOthersSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("Others")
                    DGSearch.Rows(i).Cells("DGTotalQtySearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("TotalQty")
                    DGSearch.Rows(i).Cells("DGPriceSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("Price")
                    DGSearch.Rows(i).Cells("DGDescriptionSearch").Value = ds.Tables("VuDamageOfSaleManSearch").Rows(i).Item("DamageReason")

                Catch ex As Exception
                End Try
                btnPrint.Enabled = True
            Next

        Catch ex As Exception

        End Try
    End Sub
#Region "Fahimshekaib Special ComboFiller"
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As ComboBox, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        ComboName.DataSource = Nothing
        ComboName.Items.Clear()
        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As DataGridViewComboBoxColumn, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)

        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
#End Region
#End Region

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

#Region " Context Menu "
    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        Call CMStatus()
        Call CStatus()
        Call Clear()
        DG.ReadOnly = False
        DGProductCode.Visible = True
        DG.Rows.Clear()
        lblMessage.Text = ""
        EditValue = 1
        AddEdit = True
    End Sub
    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        Call CMStatus()
        Call CStatus()
        EditValue = 1
        AddEdit = False
        Call fill()
    End Sub
    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        SaveUpdateDamageMainSalemanCustomer()
    End Sub
    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        CMStatus()
        CStatus()
        EditValue = 0
        AddEdit = True
        DGProductCode.Visible = True
    End Sub
    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from DamageMainSaleman where DamID = " & Var_DamageID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuDamageMainSaleman").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Call fill()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
        End If
    End Sub
    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region

#Region " Navigations "
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        Call fill()
        CMStatusDefault()
        CStatusDefault()
    End Sub

    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call fill()
        CMStatusDefault()
        CStatusDefault()
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("VuDamageMainSaleMan").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call fill()
        CMStatusDefault()
        CStatusDefault()
    End Sub

    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("VuDamageMainSaleMan").Rows.Count - 1
        Call fill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
#End Region

    Private Sub TC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TC.SelectedIndexChanged
        If Frm.GID.Text <= 2 Then
            If TC.SelectedIndex = 0 Then
                CM.Enabled = True
                ToolStrip1.Enabled = True
                If MnuNew.Enabled <> True Then
                    Call CMStatus()
                    Call CStatus()
                End If
                Call Clear()
                Call fill()
                btnPrint.Enabled = False
            Else
                DGSearch.Rows.Clear()
                CmbCustomerNameSearch.SelectedIndex = -1
                dtFrom.Value = Now
                dtTo.Value = Now
                CM.Enabled = False
                ToolStrip1.Enabled = False
            End If
        End If
    End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        'DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'If DG.CurrentRow.Index = CurrowIndex Then
        '    DG.CurrentRow.Cells(2).ReadOnly = False
        '    DG.CurrentRow.Cells(1).ReadOnly = False
        'Else
        '    DG.CurrentRow.Cells(2).ReadOnly = True
        'End If
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1

        If DG.CurrentRow.Index = CurrowIndex Then
            DG.CurrentRow.Cells(2).ReadOnly = False
            DG.CurrentRow.Cells(1).ReadOnly = False
        Else
            DG.CurrentRow.Cells(2).ReadOnly = True
        End If
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Try
            CalcQty()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Dim z As Integer = 0
        If DG.CurrentRow.Index = 0 And DG.CurrentCell.ColumnIndex = 0 Then
            z = DG.CurrentRow.Index + 1
        End If
        If DG.CurrentCell.ColumnIndex = 0 Then
            DG.CurrentRow.Cells(0).Value = z.ToString
        End If
        If DG.CurrentRow.Index <> 0 And DG.CurrentCell.ColumnIndex = 0 Then
            DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        End If
    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Dim TotalPrice As Double = 0
        Try
            calc()
        Catch ex As Exception
        End Try

        Try
            If DG.CurrentRow.Cells("DGCrtnPcs").Value = 1 Then
                TotalPrice = Val(DG.CurrentRow.Cells("DGTotalQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerPcs").Value)
                DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
            Else
                TotalPrice = Val(DG.CurrentRow.Cells("DGTotalQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerCrtn").Value)
                DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
            End If
        Catch ex As Exception

        End Try



        Dim indexcount As Integer
        Try
            For indexcount = 0 To DGSearch.Rows.Count - 1
                DGSearch.Rows(indexcount).Cells(0).Value = DGSearch.Rows(indexcount).Index + 1
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        'DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'If DG.CurrentCell.ColumnIndex = 1 Then
        '    Try
        '        Dim cmb As ComboBox
        '        cmb = CType(e.Control, ComboBox)
        '        AddHandler cmb.SelectionChangeCommitted, AddressOf k1
        '    Catch ex As Exception
        '    End Try
        'End If
        'If DG.CurrentRow.Index = CurrowIndex Then
        '    Try
        '        Dim cmb As ComboBox
        '        cmb = CType(e.Control, ComboBox)
        '        AddHandler cmb.SelectionChangeCommitted, AddressOf K2

        '    Catch ex As Exception
        '    End Try
        'End If
        'If DG.CurrentCell.ColumnIndex = 5 Then
        '    Dim ltxt As New TextBox
        '    ltxt = CType(e.Control, TextBox)
        '    AddHandler ltxt.KeyPress, AddressOf NumericKeys
        'End If
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'Validation of Datagrid Cell Quantity:
        Try
            If DG.CurrentCell.ColumnIndex = 9 Then
                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf NumericKeys
            End If
            'Ended here
            If DG.CurrentCell.ColumnIndex = 1 Then
                Try
                    Dim cmb As ComboBox
                    cmb = CType(e.Control, ComboBox)
                    AddHandler cmb.SelectionChangeCommitted, AddressOf k1
                Catch ex As Exception
                End Try
            End If
            'End If
            If DG.CurrentRow.Index = CurrowIndex Then
                Try
                    Dim cmb As ComboBox
                    cmb = CType(e.Control, ComboBox)
                    AddHandler cmb.SelectionChangeCommitted, AddressOf K2

                Catch ex As Exception
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
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If CmbCustomerNameSearch.Text = "" Then
            MsgBox("PLEASE SELECT CUSTOMER NAME", MsgBoxStyle.Information)
            Exit Sub
        Else
            StrSearch = "Select * from VuDamageOfSaleManSearch where CustomerID = " & CmbCustomerNameSearch.SelectedValue & "  and dtDate between '" & dtFrom.Value.Date.ToString & "' and '" & dtTo.Value.Date.ToString & "'"
            GridFillSearch()
        End If
    End Sub

    Private Sub DGSearch_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellValueChanged
        Try
            Dim azizkhan As Integer
            For azizkhan = 0 To DGSearch.Rows.Count - 2
                DGSearch.Rows(azizkhan).Cells("DGSNOSearch").Value = DG.Rows(azizkhan).Index + 1
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Module1.DatasetFill("Select * from RptVuDamageOfSaleMan where CustomerID=" & CmbCustomerNameSearch.SelectedValue & " and dtdate between '" & dtFrom.Value.Date & "' and '" & dtTo.Value.Date & "'", "RptVuDamageOfSaleMan")
            Dim rpt As New RptDamageSaleMan
            rpt.SetDataSource(Module1.ds.Tables("RptVuDamageOfSaleMan"))
            frmRptSetup.CV.ReportSource = rpt
            Frm.RptShow()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbCustomerName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCustomerName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub
End Class
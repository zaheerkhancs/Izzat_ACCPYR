Imports System.Data.SqlClient
Imports LanguageSelector
Public Class frmClaimEnglish
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
    Dim CurrowIndex As Integer = 0
    Private Sub frmClaimEnglish_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Module1.DatasetFill("Select * from VuVendorForClaimEnglish", "VuVendorForClaimEnglish")
        cmbCompanyName.DataSource = ds.Tables("VuVendorForClaimEnglish")
        cmbCompanyName.DisplayMember = ("Name")
        cmbCompanyName.ValueMember = ("VID")
        cmbCompanyName.SelectedIndex = -1

        Module1.DatasetFill("Select * from VuProductType", "VuProductType")
        DGPType.DataSource = ds.Tables("VuProductType")
        DGPType.DisplayMember = ("ProdTypeNameEnglish")
        DGPType.ValueMember = ("ProdTypeID")

        Module1.DatasetFill("Select ProdCode,ProductEnglish from VuProduct", "VuProduct")
        DGcmbProductCode.DataSource = ds.Tables("VuProduct")
        DGcmbProductCode.DisplayMember = ("ProductEnglish")
        DGcmbProductCode.ValueMember = ("ProdCode")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        DGCrtnPcs.DataSource = ds.Tables("CartonPiece")
        DGCrtnPcs.DisplayMember = "Name"
        DGCrtnPcs.ValueMember = "ID"

        Clear(Me, pnlcentre, TC, TB1)

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
                                Dim d As Control
                                For Each d In c.Controls
                                    If TypeOf d Is ComboBox Or TypeOf d Is DateTimePicker Then
                                        d.Enabled = Not d.Enabled
                                    ElseIf TypeOf d Is TextBox Then
                                        If d.Name <> txtTotal.ToString Then
                                            d.Enabled = Not d.Enabled
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
        DG.ReadOnly = Not DG.ReadOnly
        DG.Columns("DGPcsInCrtn").ReadOnly = True
        DG.Columns("DGPricePerPcs").ReadOnly = True
        DG.Columns("DGPricePerCrtn").ReadOnly = True
        DG.Columns("DGQty").ReadOnly = True
        DG.Columns("DGPrice").ReadOnly = True
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
        If DG.CurrentCell.ColumnIndex = 8 Or DG.CurrentCell.ColumnIndex = 9 Or DG.CurrentCell.ColumnIndex = 10 Or DG.CurrentCell.ColumnIndex = 11 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Sub FillAll()
        Try
            DG.Columns("DGcmbProductCode").Visible = False
            EditValue = 1
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select ClaimID,Name,InvoiceNo,ClaimDate,TotalQty,TotalAmount,Remarks from VuClaimMainEnglish", "VuClaimMainEnglish")
            If ds.Tables("VuClaimMainEnglish").Rows.Count = 0 Then
                Clear(Me, pnlcentre, TC, TB1)
                DG.Rows.Clear()
                Exit Sub
            End If
            ClaimID = ds.Tables("VuClaimMainEnglish").Rows(cnt).Item("ClaimID")
            cmbCompanyName.Text = ds.Tables("VuClaimMainEnglish").Rows(cnt).Item("Name")
            cmbInvioceNo.Text = ds.Tables("VuClaimMainEnglish").Rows(cnt).Item("InvoiceNo")
            dtDate.Value = ds.Tables("VuClaimMainEnglish").Rows(cnt).Item("ClaimDate")
            txtQtyTotal.Text = ds.Tables("VuClaimMainEnglish").Rows(cnt).Item("TotalQty")
            txtTotal.Text = ds.Tables("VuClaimMainEnglish").Rows(cnt).Item("TotalAmount")
            txtRemarks.Text = ds.Tables("VuClaimMainEnglish").Rows(cnt).Item("Remarks")
            GridFill()
        Catch ex As Exception
        End Try
    End Sub
    Sub GridFill()
        Try
            Module1.DatasetFill("Select * from VuClaimDetailEnglish where ClaimID = " & ClaimID & "", "VuClaimDetailEnglish")
            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuClaimDetailEnglish").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("SNO")
                DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("ProdTypeID")
                DG.Rows(a).Cells("DGcmbProductCode").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("ProdCode")
                DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("PcsInCrtn")
                DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("PricePerPcs")
                DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("PricePerCrtn")
                DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("CrtnPcs")
                If DG.Rows(a).Cells("DGCrtnPcs").FormattedValue = "1" Then
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(0).Item("Name")
                Else
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(1).Item("Name")
                End If

                'DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("ClaimQty")
                DG.Rows(a).Cells("DGBroken").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("Broken")
                DG.Rows(a).Cells("DGLeak").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("Leak")
                DG.Rows(a).Cells("DGShort").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("Short")
                DG.Rows(a).Cells("DGDented").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("Dent")
                DG.Rows(a).Cells("DGExpired").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("Expired")
                DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("DecayedBeforeExpiration")
                DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("ClaimQty")
                DG.Rows(a).Cells("DGPrice").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("ClaimAmount")
                DG.Rows(a).Cells("DGDescription").Value = ds.Tables("VuClaimDetailEnglish").Rows(a).Item("ProdDescription")

            Next
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
                TotalQty = TotalQty + Val(DG.Rows(a).Cells("DGQty").Value)
            Next
            Me.txtTotal.Text = Total
            Me.txtQtyTotal.Text = TotalQty
        Catch ex As Exception
        End Try
    End Sub
    Sub CalcQty()
        Dim Total As Double = 0
        'Dim a As Integer
        Try
            'For a = 0 To DG.Rows.Count - 1
            Total = Total + Val(DG.CurrentRow.Cells("DGBroken").Value) + Val(DG.CurrentRow.Cells("DGLeak").Value) + Val(DG.CurrentRow.Cells("DGShort").Value) + Val(DG.CurrentRow.Cells("DGDented").Value)
            'Next
            DG.CurrentRow.Cells("DGQty").Value = Total
        Catch ex As Exception
        End Try
    End Sub
    Sub IDChecker()
        Module1.DatasetFill("Select * from ClaimMainEnglish", "ClaimMainEnglish")
        cmd.CommandText = "Select isnull(Max(ClaimID),0) from ClaimMainEnglish"
        ClaimID = cmd.ExecuteScalar + 1
    End Sub
    Sub SaveUpdateClaimMainEnglish()
        Try

            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateClaimMainEnglish"
            cmdsave.Connection = cn
            If EditValue = 1 Then
                IDChecker()
            End If
            cmdsave.Parameters.Add("@ClaimID", SqlDbType.Int).Value = ClaimID
            cmdsave.Parameters.Add("@CompanyID", SqlDbType.Int).Value = Me.cmbCompanyName.SelectedValue
            cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Me.cmbInvioceNo.Text
            cmdsave.Parameters.Add("@ClaimDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmdsave.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Val(txtQtyTotal.Text)
            cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Val(txtTotal.Text)
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & ClaimID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If EditValue = 1 Then
                SaveUpdateClaimDetailEnglish()
                CMStatus()
                CStatus(Me, pnlcentre, TC, TB1)
                'FillAll()
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
                lblMessage.Text = "The Record has been Saved Successfully"
            Else

                DeleteClaimDetailEnglish()
                SaveUpdateClaimDetailEnglish()
                CMStatus()
                CStatus(Me, pnlcentre, TC, TB1)
                FillAll()
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                lblMessage.Text = "The Record has been Updated Successfully"
                EditValue = 1
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub DeleteClaimDetailEnglish()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteClaimDetailEnglish"
        cmdDelete.Parameters.Add("@ClaimID", SqlDbType.Int).Value = ClaimID
        cmdDelete.ExecuteNonQuery()
    End Sub
    Sub SaveUpdateClaimDetailEnglish()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateClaimDetailEnglish"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 1
                cmdsaveGrid.Parameters.Add("@ClaimID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@ClaimID").Value = ClaimID

                cmdsaveGrid.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNO").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGcmbProductCode").Value
                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPcsInCrtn").Value)
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPricePerPcs").Value)
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPricePerCrtn").Value)
                Dim Var As String = DG.Rows(a).Cells("DGCrtnPcs").Value
                If Var = "2" Or Var = "کارتن" Then
                    cmdsaveGrid.Parameters.Add("@CartonPiece", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(1).Item("ID")

                Else
                    cmdsaveGrid.Parameters.Add("@CartonPiece", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(0).Item("ID")
                End If
                'cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGCrtnPcs").Value)
                cmdsaveGrid.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGBroken").Value)
                cmdsaveGrid.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGLeak").Value)
                cmdsaveGrid.Parameters.Add("@Short", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGShort").Value)
                cmdsaveGrid.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGDented").Value)
                cmdsaveGrid.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGExpired").Value)
                cmdsaveGrid.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value)

                cmdsaveGrid.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGQty").Value)
                cmdsaveGrid.Parameters.Add("@ClaimAmount", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPrice").Value)
                If DG.Rows(a).Cells("DGDescription").Value = " " Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = " "
                Else
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value
                End If

                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub k1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                DG.CurrentRow.Cells(1).Value = sender.text
                Module1.DatasetFill("Select ProdCode,ProductEnglish from VuProduct where ProdTypeNameEnglish = '" & DG.CurrentRow.Cells(1).Value & "'", "VuProduct")
                DGcmbProductCode.DataSource = ds.Tables("VuProduct")
                DGcmbProductCode.DisplayMember = ("ProductEnglish")
                DGcmbProductCode.ValueMember = ("ProdCode")
                CurrowIndex = DG.CurrentRow.Index
                DG.CurrentRow.Cells(3).Value = ""
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
    Sub GridFillForPrice()
        Try
            Module1.DatasetFill("Select PcsInCtrn,PricePerPcs,PricePerCrtn from VuProductPrices where ProdTypeID = " & DG.CurrentRow.Cells("DGPType").Value & " and ProdCode =" & DG.CurrentRow.Cells("DGID").Value & "", "VuProductPrices")
            DG.CurrentRow.Cells("DGPcsInCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PcsInCtrn")
            DG.CurrentRow.Cells("DGPricePerPcs").Value = ds.Tables("VuProductPrices").Rows(0).Item("PricePerPcs")
            DG.CurrentRow.Cells("DGPricePerCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PricePerCrtn")
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region " CONTEXT MENUS ..................."
    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        CMStatus()
        CStatus(Me, pnlcentre, TC, TB1)
        Clear(Me, pnlcentre, TC, TB1)
        DG.Columns("DGcmbProductCode").Visible = True
        'DG.Columns("DGProductName").ReadOnly = True
        DG.Columns("DGQty").ReadOnly = True
    End Sub

    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        CMStatus()
        CStatus(Me, pnlcentre, TC, TB1)
        Clear(Me, pnlcentre, TC, TB1)
        FillAll()
    End Sub
    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If cmbCompanyName.Text = "" Or cmbInvioceNo.Text = "" Then
            MsgBox(" PLEASE FILL THE REQUIRED FIELDS ", MsgBoxStyle.Critical)
            Exit Sub
        Else
            SaveUpdateClaimMainEnglish()
        End If
    End Sub
    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        CMStatus()
        CStatus(Me, pnlcentre, TC, TB1)
        EditValue = 0
        DG.Columns("DGcmbProductCode").Visible = True
        ' DG.Columns("DGProductName").ReadOnly = True
        DG.Columns("DGQty").ReadOnly = True
        lblMessage.Text = ""
        For Each DataGridViewColumnNNnnn As DataGridViewColumn In DG.Columns
            If Not DataGridViewColumnNNnnn.Name = "DGDescription" Then

                DataGridViewColumnNNnnn.ReadOnly = True
            End If
        Next
    End Sub
    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure you want to delete.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from ClaimMainEnglish where ClaimID = " & ClaimID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)

            If cnt = ds.Tables("VuClaimMainEnglish").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear(Me, pnlcentre, TC, TB1)
            End If
            Call FillAll()
            lblMessage.Text = "The Record has been Deleted Successfully"
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
        If cnt = ds.Tables("VuClaimMainEnglish").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        FillAll()
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuClaimMainEnglish").Rows.Count - 1
        FillAll()
    End Sub
#End Region

#Region "EVENTS..............."
    Private Sub cmbCompanyName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompanyName.SelectedIndexChanged
        If azizisagoodboy = True Then
            Try
                Module1.DatasetFill("Select * from VuInvioceForClaimEnglish where VID=" & cmbCompanyName.SelectedValue & "", "VuInvioceForClaimEnglish")
                cmbInvioceNo.DataSource = ds.Tables("VuInvioceForClaimEnglish")
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
    End Sub
    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        'Dim TotalPrice As Double = 0
        'Try
        '    calc()
        'Catch ex As Exception
        'End Try


        'Try
        '    TotalPrice = Val(DG.CurrentRow.Cells("DGQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerPcs").Value)
        '    DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
        'Catch ex As Exception
        'End Try
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

        'If DG.CurrentCell.ColumnIndex = 8 Then
        '    Dim ltxt As New TextBox
        '    ltxt = CType(e.Control, TextBox)
        '    AddHandler ltxt.KeyPress, AddressOf NumericKeys
        'End If
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
    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
        If txtRemarks.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region

    Private Sub DG_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        'Try
        '    CalcQty()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If ClaimID = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptVuClaimMain where ClaimID=" & ClaimID, "RptVuClaimMain")
                Dim rpt As New RptClaimEnglish
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

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        'DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'If DG.CurrentRow.Index = CurrowIndex Then
        '    DG.CurrentRow.Cells(2).ReadOnly = False
        '    DG.CurrentRow.Cells(1).ReadOnly = False
        'Else
        '    DG.CurrentRow.Cells(2).ReadOnly = True
        'End If
    End Sub

    Sub MainFormFill()
        Try

            Module1.DatasetFill("Select * from ClaimMain where InvoiceNo='" & cmbInvioceNo.Text & "'", "ClaimMain")
            dtDate.Value = ds.Tables("ClaimMain").Rows(0).Item("ClaimDate")
            txtQtyTotal.Text = ds.Tables("ClaimMain").Rows(0).Item("TotalQty")
            txtTotal.Text = ds.Tables("ClaimMain").Rows(0).Item("TotalAmount")
            txtRemarks.Text = ds.Tables("ClaimMain").Rows(0).Item("Remarks")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub GridFillForClaim()
        Try

            Module1.DatasetFill("Select * from ClaimDetail where InvoiceNo='" & cmbInvioceNo.Text & "'", "ClaimDetail")
            DG.Rows.Clear()
            For a = 0 To ds.Tables("ClaimDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(a).Cells("DGSNo").Value = ds.Tables("ClaimDetail").Rows(a).Item("SNO")
                DG.Rows(a).Cells("DGPType").Value = ds.Tables("ClaimDetail").Rows(a).Item("ProdTypeID")
                DG.Rows(a).Cells("DGcmbProductCode").Value = ds.Tables("ClaimDetail").Rows(a).Item("ProdCode")
                DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("ClaimDetail").Rows(a).Item("PcsInCrtn")
                DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("ClaimDetail").Rows(a).Item("PricePerPcs")
                DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("ClaimDetail").Rows(a).Item("PricePerCrtn")
                DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("ClaimDetail").Rows(a).Item("CrtnPcs")
                If DG.Rows(a).Cells("DGCrtnPcs").FormattedValue = "1" Then
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(0).Item("Name")
                Else
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(1).Item("Name")
                End If

                DG.Rows(a).Cells("DGQty").Value = ds.Tables("ClaimDetail").Rows(a).Item("Qty")
                DG.Rows(a).Cells("DGBroken").Value = ds.Tables("ClaimDetail").Rows(a).Item("Broken")
                DG.Rows(a).Cells("DGLeak").Value = ds.Tables("ClaimDetail").Rows(a).Item("Leak")
                DG.Rows(a).Cells("DGShort").Value = ds.Tables("ClaimDetail").Rows(a).Item("Short")
                DG.Rows(a).Cells("DGDented").Value = ds.Tables("ClaimDetail").Rows(a).Item("Dent")
                DG.Rows(a).Cells("DGExpired").Value = ds.Tables("ClaimDetail").Rows(a).Item("Expired")
                DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value = ds.Tables("ClaimDetail").Rows(a).Item("DecayedBeforeExpiration")
                DG.Rows(a).Cells("DGQty").Value = ds.Tables("ClaimDetail").Rows(a).Item("ClaimQty")
                DG.Rows(a).Cells("DGPrice").Value = ds.Tables("ClaimDetail").Rows(a).Item("ClaimAmount")
                DG.Rows(a).Cells("DGDescription").Value = ds.Tables("ClaimDetail").Rows(a).Item("ProdDescription")

            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbCompanyName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCompanyName.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        If cmbInvioceNo.Enabled = True Then
            MainFormFill()
            GridFillForClaim()
        End If
    End Sub
End Class
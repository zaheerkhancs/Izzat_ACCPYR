Imports System.Data.SqlClient
Imports System.Windows.Forms.DataGridViewCellStyle
Public Class GodownStock
    Dim Var_GoDownStockMainID As Integer
    Dim Editvalue As Integer
    Dim cnt As Integer
    Dim Index As Boolean
    Dim DGCheck As Boolean
    Dim CurrowIndex As Integer
    Dim a As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim EngOrderID As Integer ' This is used only for orderEnglishPrompt From.
    Dim AddEdit As Boolean
    Dim i As Integer = 0
    Dim NewRecordIsSaved As Boolean  ' I think it is useless.
    Dim QtyOfEachProductInPiece As Integer
    Dim clr As System.Drawing.Color

    Private Sub GodownStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Index = False
        DGCheck = False

        Module1.DatasetFill("Select GoDownID,GoDownName from GoDown", "GoDown")
        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Module1.DatasetFill("Select * from VuProductForGoDownDataSearch", "VuProductForGoDownDataSearch")

        cmbGodownName.DataSource = ds.Tables("GoDown")
        cmbGodownName.DisplayMember = "GoDownName"
        cmbGodownName.ValueMember = "GoDownID"
        cmbGodownName.SelectedIndex = -1


        ''DGSearch3 combos:
        cmbGoDownSearch3.DataSource = ds.Tables("GoDown")
        cmbGoDownSearch3.DisplayMember = "GoDownName"
        cmbGoDownSearch3.ValueMember = "GoDownID"

        DGSearch3ProdType.DataSource = ds.Tables("ProductType")
        DGSearch3ProdType.DisplayMember = ("ProdTypeName")
        DGSearch3ProdType.ValueMember = ("ProdTypeID")

        DGSearch3ProductName.DataSource = ds.Tables("VuProductForGoDownDataSearch")
        DGSearch3ProductName.DisplayMember = ("Product")
        DGSearch3ProductName.ValueMember = ("ProdCode")
        ''Finished

        DGcmbPType.DataSource = ds.Tables("ProductType")
        DGcmbPType.DisplayMember = ("ProdTypeName")
        DGcmbPType.ValueMember = ("ProdTypeID")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        DGCrtnPcs.DataSource = ds.Tables("CartonPiece")
        DGCrtnPcs.DisplayMember = "Name"
        DGCrtnPcs.ValueMember = "ID"

        ' Search section



        '
        dtDate.Value = Now

        Call Clear()
        Call txtfill()
        Editvalue = 1
        Index = True
        DGCheck = True

        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub
#Region " Functions "
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuExit.Enabled = Not MnuExit.Enabled
    End Sub
    Sub CStatus()
        cmbGodownName.Enabled = Not cmbGodownName.Enabled

        dtDate.Enabled = Not dtDate.Enabled

        txtRemarks.Enabled = Not txtRemarks.Enabled
        DG.ReadOnly = Not DG.ReadOnly
        txtCheqGodownNo.ReadOnly = Not txtCheqGodownNo.ReadOnly
        txtPlateNo.ReadOnly = Not txtPlateNo.ReadOnly
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        ' dtDate.Value = Now
        txtRemarks.Text = ""
        DG.Rows.Clear()
        'Module1.Datasettxtfill("Select * from OrderMain", "OrderMain")
        'cmd.CommandText = "Select isnull(Max(OrderID),0) from OrderMain"
        'OrderID = cmd.ExecuteScalar + 1
        'DGcmbProductCode.Visible = True
        txtCheqGodownNo.Text = ""
        txtPlateNo.Text = ""
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGQty" Then
            ' MsgBox(Asc(e.KeyChar).ToString())
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Or Asc(e.KeyChar) = 46 Then e.Handled = True
        End If
    End Sub
    Sub k1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                DG.CurrentRow.Cells(1).Value = sender.text
                Module1.DatasetFill("Select ProdCode,Product from VuProduct where ProdTypeName = N'" & DG.CurrentRow.Cells(1).Value & "'", "VuProduct")
                DGcmbProductCode.DataSource = ds.Tables("VuProduct")
                DGcmbProductCode.DisplayMember = ("Product")
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
        End If
    End Sub


    Sub Gridtxtfill()
        Try

            Module1.DatasetFill("Select * from VuGoDownStockDetail where RecordID= " & Var_GoDownStockMainID, "VuGoDownStockDetail")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuGoDownStockDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuGoDownStockDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGcmbPType").Value = ds.Tables("VuGoDownStockDetail").Rows(a).Item("ProdTypeID")
                    DG.Rows(a).Cells("ID").Value = ds.Tables("VuGoDownStockDetail").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("aaa").Value = ds.Tables("VuGoDownStockDetail").Rows(a).Item("Product")
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("VuGoDownStockDetail").Rows(a).Item("CrtnPcs")
                    If RBAdd.Checked = True Then
                        DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuGoDownStockDetail").Rows(a).Item("RecQty")
                    ElseIf RBDeduct.Checked = True Then
                        DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuGoDownStockDetail").Rows(a).Item("DeductedQty")
                    End If

                    DG.Rows(a).Cells("DGDescription").Value = ds.Tables("VuGoDownStockDetail").Rows(a).Item("ProdDescription")
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
        DGcmbProductCode.Visible = False
    End Sub
#End Region
#Region " Context Menu "
    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        AddEdit = True
        DGcmbProductCode.Visible = True
        Call CMStatus()
        Call CStatus()
        Call Clear()
        Editvalue = 1
        If cmbGodownName.Items.Count > 0 Then ' In order to get the related combos filled cause sometimes the user forgets.
            cmbGodownName_SelectedIndexChanged(cmbGodownName, e)
        End If
    End Sub
    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        AddEdit = False
        Call CMStatus()
        Call CStatus()
        ' I thought it was left mistakenly so I changed it to GoDownStockMain. If it was correct then uncomment it and comment this one.
        'Module1.DatasetFill("Select * from OrderEnglishMain", "OrderEnglishMain")
        Module1.DatasetFill("Select * from GoDownStockMain", "GoDownStockMain")

        Call txtfill()
        DGcmbProductCode.Visible = False
    End Sub
    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click

        If cmbGodownName.SelectedIndex = -1 Then Exit Sub
        If Editvalue = 1 Then
            Call IDPicker()
        End If
        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertUpdateGoDownStockMain"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@RecordID", SqlDbType.Int).Value = Me.Var_GoDownStockMainID
        cmdsave.Parameters.Add("@GoDownID", SqlDbType.Int).Value = Me.cmbGodownName.SelectedValue
        cmdsave.Parameters.Add("@GoDownKepperName ", SqlDbType.NVarChar).Value = Me.txtGodownKeeper.Text
        cmdsave.Parameters.Add("@GoDownPhone", SqlDbType.NVarChar).Value = Me.txtGodownPhoneNo.Text
        cmdsave.Parameters.Add("@GoDownAddress", SqlDbType.NVarChar).Value = Me.txtGodownAddress.Text
        cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date
        cmdsave.Parameters.Add("@CheqNoGoDown", SqlDbType.NVarChar).Value = Me.txtCheqGodownNo.Text.Trim()
        If RBAdd.Checked = True Then
            cmdsave.Parameters.Add("AddOrDeducted", SqlDbType.Bit).Value = 1
        ElseIf RBDeduct.Checked = True Then
            cmdsave.Parameters.Add("AddOrDeducted", SqlDbType.Bit).Value = 0
        End If
        cmdsave.Parameters.Add("@NoPlate", SqlDbType.NVarChar).Value = Me.txtPlateNo.Text.Trim()
        Dim pd As String = Me.txtRemarks.Text
        If pd.Equals("") Then
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
        Else
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
        End If

        cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
        cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_GoDownStockMainID


        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = Editvalue
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdsave.ExecuteNonQuery()

        cmdsave.Parameters.Clear()

        If Editvalue = 1 Then
            'I just made it comment because it was passing "save" instead of datagrid wala or whatever we need.
            'K2(sender, e) 
            NewRecordIsSaved = True ' I think it is useless.
            Call GridSave()
            Call SaveGodownIGL()
            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            ' MsgBox("Your Record has been saved successfully..")
        Else
            NewRecordIsSaved = False  ' I think it is useless.
            Call DeleteGrid()
            Call GridSave()
            Call DeleteIGL()

            Call SaveGodownIGL()
            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

            'MsgBox("Your Record has been updated successfully..")
        End If
        AddEdit = False
        Call CStatus()
        CMStatus()
        DG.ReadOnly = True
        DGcmbProductCode.Visible = False
        txtfill()

    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        AddEdit = True
        CMStatus()
        CStatus()
        Editvalue = 0
        DGcmbProductCode.Visible = True
    End Sub
    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from GodownStockMain where RecordID = " & Var_GoDownStockMainID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from GodownStockDetail where RecordID=" & Var_GoDownStockMainID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from GoDownIGL where RecordID=" & Var_GoDownStockMainID & "  And Type='Received'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("GoDownStockMain").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Call txtfill()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
        End If
    End Sub
    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        FrmOrderEnglishPrompt.Close()
        Me.Close()
    End Sub
#End Region

#Region " Navigations "
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        NewRecordIsSaved = False
        Call txtfill()
    End Sub

    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        NewRecordIsSaved = False
        Call txtfill()
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("GoDownStockMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        NewRecordIsSaved = False
        Call txtfill()
    End Sub

    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("GoDownStockMain").Rows.Count - 1
        NewRecordIsSaved = False
        Call txtfill()
    End Sub
#End Region

    Private Sub cmbGodownName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGodownName.SelectedIndexChanged
        Try
            If AddEdit.Equals(True) Then
                Module1.DatasetFill("Select GoDownKepperName,GoDownPhone,GoDownAddress from VuGodown where GodownID =" & cmbGodownName.SelectedValue, "VuGodown")
                'If ds.Tables("VuGodown").Rows.Count = 0 Then Exit Sub
                txtGodownKeeper.Text = ds.Tables("VuGodown").Rows(0).Item("GoDownKepperName")
                txtGodownPhoneNo.Text = ds.Tables("VuGodown").Rows(0).Item("GoDownPhone")
                txtGodownAddress.Text = ds.Tables("VuGodown").Rows(0).Item("GoDownAddress")
            Else

            End If

        Catch ex As Exception
            'txtGodownKeeper.Text = ""
            'txtGodownPhoneNo.Text = ""
            'txtGodownAddress.Text = ""
        End Try
    End Sub


    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'Validation of Datagrid Cell Quantity:

        If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGQty" Then
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

    End Sub
    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(RecordID) from GoDownStockMain"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_GoDownStockMainID = 1
                Else
                    Me.Var_GoDownStockMainID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub GridSave()

        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateGodownStockDetail"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 2
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@RecordID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@RecordID").Value = Var_GoDownStockMainID


                cmdsaveGrid.Parameters.Add("@Sno", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNo").Value

                Dim PTypeID As Integer
                Try
                    For Each dtrow As DataRow In ds.Tables("ProductType").Rows
                        If dtrow("ProdTypeName") = DG.Rows(a).Cells("DGcmbPType").Value Then
                            PTypeID = dtrow("ProdTypeID")
                            cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = PTypeID 'DG.Rows(a).Cells("DGcmbPType").Value

                        End If
                    Next
                Catch ex As Exception
                    cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGcmbPType").Value

                End Try

                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("ID").Value
                cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.Int).Value = DG.Rows(a).Cells("DGCrtnPcs").Value
                If RBAdd.Checked = True Then
                    cmdsaveGrid.Parameters.Add("@RecQty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGQty").Value
                    cmdsaveGrid.Parameters.Add("@DeductedQty", SqlDbType.Decimal).Value = 0
                ElseIf RBDeduct.Checked = True Then
                    cmdsaveGrid.Parameters.Add("@RecQty", SqlDbType.Decimal).Value = 0
                    cmdsaveGrid.Parameters.Add("@DeductedQty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGQty").Value
                End If

                Dim pd As String = DG.Rows(a).Cells("DGDescription").Value
                If IsNothing(pd) Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = " "
                Else
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value

                End If
                cmdsaveGrid.Parameters.Add("@GoDownID", SqlDbType.NVarChar).Value = Me.cmbGodownName.SelectedValue

                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next

        Catch ex As Exception
            'Trans.Rollback()
        End Try


    End Sub
    Sub DeleteGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteGoDownStockDetail"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@RecordID", SqlDbType.Int).Value = Var_GoDownStockMainID
        cmdsave.ExecuteNonQuery()

    End Sub
    Sub DeleteIGL()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteGoDownIGL"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@RecordID", SqlDbType.Int).Value = Var_GoDownStockMainID
        cmdsave.ExecuteNonQuery()

    End Sub
    Sub txtfill()
        Try
            'lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from GoDownStockMain Order by RecordID", "GoDownStockMain")

            If ds.Tables("GoDownStockMain").Rows.Count = 0 Then
                Call txtclear(Me, pnlcentre, TB1, TP1)
                Exit Sub
            Else

                If NewRecordIsSaved.Equals(True) Then
                    cnt = ds.Tables("GoDownStockMain").Rows.Count - 1
                End If

                Me.Var_GoDownStockMainID = Val(ds.Tables("GoDownStockMain").Rows(cnt).Item("RecordID"))

                cmbGodownName.SelectedValue = ds.Tables("GoDownStockMain").Rows(cnt).Item("GoDownID")
                txtGodownKeeper.Text = ds.Tables("GoDownStockMain").Rows(cnt).Item("GoDownKepperName")
                txtGodownPhoneNo.Text = ds.Tables("GoDownStockMain").Rows(cnt).Item("GoDownPhone")
                txtGodownAddress.Text = ds.Tables("GoDownStockMain").Rows(cnt).Item("GoDownAddress")
                dtDate.Value = ds.Tables("GoDownStockMain").Rows(cnt).Item("dtDate")
                txtCheqGodownNo.Text = ds.Tables("GoDownStockMain").Rows(cnt).Item("CheqNoGoDown")
                If ds.Tables("GoDownStockMain").Rows(cnt).Item("AddOrDeducted") = True Then
                    RBAdd.Checked = True
                Else
                    RBDeduct.Checked = True
                End If
                txtPlateNo.Text = ds.Tables("GoDownStockMain").Rows(cnt).Item("NoPlate")
                txtRemarks.Text = ds.Tables("GoDownStockMain").Rows(cnt).Item("Remarks")
                Call Gridtxtfill()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnSearch3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch3.Click
        DGSearch3Fill()
    
        For Each dgcol As DataGridViewColumn In DGSearch3.Columns
            If dgcol.Name = "DGSearch3PcsInCrtn" Then
                dgcol.DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next
    End Sub
    Sub Selector()
        Dim TotalNoOfCrtnToMinus As Integer = 0
        Dim TotalNoOfCrtnToPlus As Integer = 0
        Dim TotalNoPcsInCrtn As Integer = 0
        ' showing in carton
        Try
            ''First region started here.
            'Carton of First
            'First I have to load data to grid regarding any deducted item from godown.Either for damage or for transferring from one to another godown.
            Module1.DatasetFill("Select Sum(IssueQty)As QtyInCrtnRemoved from GoDownIGL where Type Like ('Removed from%') And ProductCode=" & DGSearch3.Rows(i).Cells("DGSearch3ProductName").Value & " And CrtnPcs = 2 And GodownID = " & cmbGoDownSearch3.SelectedValue, "GoDownIGL")
            If ds.Tables("GoDownIGL").Rows(0).IsNull("QtyInCrtnRemoved") Then
                DGSearch3.Rows(i).Cells("DGSearchRemovedInCrtn").Value = 0
            Else
                DGSearch3.Rows(i).Cells("DGSearchRemovedInCrtn").Value = ds.Tables("GoDownIGL").Rows(0).Item("QtyInCrtnRemoved")
            End If
            'piece of First
            Module1.DatasetFill("Select Sum(IssueQty)As QtyInPcsRemoved from GoDownIGL where Type <> 'Received' And ProductCode=" & DGSearch3.Rows(i).Cells("DGSearch3ProductName").Value & " And CrtnPcs = 1 And GodownID = " & cmbGoDownSearch3.SelectedValue, "GoDownIGL")
            If ds.Tables("GoDownIGL").Rows(0).IsNull("QtyInPcsRemoved") Then
                DGSearch3.Rows(i).Cells("DGSearchRemovedInPcs").Value = 0
            Else
                DGSearch3.Rows(i).Cells("DGSearchRemovedInPcs").Value = ds.Tables("GoDownIGL").Rows(0).Item("QtyInPcsRemoved")
            End If
            ''First region ended here.
            Module1.DatasetFill("Select Sum(RecQty)-Sum(IssueQty) As IssueQtyInCrtn,Sum(IssueQty)As QtyInCrtnSold,Sum(RecQty) As ReceivedQtyInCrtn from GoDownIGL where Type Not Like ('Removed from%') And ProductCode=" & DGSearch3.Rows(i).Cells("DGSearch3ProductName").Value & " And CrtnPcs = 2 And GodownID = " & cmbGoDownSearch3.SelectedValue, "GoDownIGL")
            If ds.Tables("GoDownIGL").Rows(0).IsNull("IssueQtyInCrtn") Then
                DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value = 0
                If ds.Tables("GoDownIGL").Rows(0).IsNull("QtyInCrtnSold") Then
                    DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtnSold").Value = 0
                    DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtnEnteredGodown").Value = 0
                End If
            Else
                DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtnEnteredGodown").Value = ds.Tables("GoDownIGL").Rows(0).Item("ReceivedQtyInCrtn")
                DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtnSold").Value = ds.Tables("GoDownIGL").Rows(0).Item("QtyInCrtnSold")
                DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value = ds.Tables("GoDownIGL").Rows(0).Item("IssueQtyInCrtn")

            End If
        Catch ex As Exception
        End Try

        'showing in piece
        Try
            'Module1.DatasetFill("Select Sum(RecQty)-Sum(IssueQty) As QtyInPcs from GoDownIGL where ProductCode=" & DGSearch3.Rows(i).Cells("DGSearch3ProductName").Value & " And CrtnPcs = 1", "GoDownIGL")
            Module1.DatasetFill("Select Sum(IssueQty) As IssueQtyInPcs, Sum(RecQty) As ReceivedQtyInPcs from GoDownIGL where Type='Received' And ProductCode=" & DGSearch3.Rows(i).Cells("DGSearch3ProductName").Value & " And CrtnPcs = 1 And GodownID = " & cmbGoDownSearch3.SelectedValue, "GoDownIGL")

            If ds.Tables("GoDownIGL").Rows(0).IsNull("IssueQtyInPcs") Then
                ' DGSearch3.Rows(i).Cells("DGSearch3QtyInPcs").Value = 0 Dont make is zero ,but just calculate the actual amount in piece.
                'It means that only count the numbe rof products in piece.
                DGSearch3.Rows(i).Cells("DGSearch3QtyInPcs").Value = Val(DGSearch3.Rows(i).Cells("DGSearch3PcsInCrtn").Value) * Val(DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value) - Val(DGSearch3.Rows(i).Cells("DGSearchRemovedInPcs").Value)
                DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsSold").Value = 0
                DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsEnteredGodown").Value = 0
                'If ds.Tables("GoDownIGL").Rows(0).IsNull("ReceivedQtyInPcs") Then
                '    DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsEnteredGodown").Value = 0
                'End If

            Else
                Dim QtyToBeMinused = ds.Tables("GoDownIGL").Rows(0).Item("IssueQtyInPcs")
                'GetTotalQtyInPiece()
                DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsEnteredGodown").Value = ds.Tables("GoDownIGL").Rows(0).Item("ReceivedQtyInPcs")
                DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsSold").Value = ds.Tables("GoDownIGL").Rows(0).Item("IssueQtyInPcs") ' Quantity sold in piece. the row(0) is correct,dont thing to change it to i, ok.
                DGSearch3.Rows(i).Cells("DGSearch3QtyInPcs").Value = ((Val(DGSearch3.Rows(i).Cells("DGSearch3PcsInCrtn").Value) * Val(DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value)) + DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsEnteredGodown").Value) - QtyToBeMinused - (DGSearch3.Rows(i).Cells("DGSearchRemovedInPcs").Value)
                'DGSearch3.Rows(i).Cells("DGSearch3QtyInPcs").Value = ds.Tables("GoDownIGL").Rows(0).Item("QtyInPcs")
                If Not DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsSold").Value = 0 And DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsSold").Value < DGSearch3.Rows(i).Cells("DGSearch3PcsInCrtn").Value Then
                    'If the number of products sold in piece is not zero and is less than the total of the product pieces in a carton then do this.
                    DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value = Val(DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value) - 1 ' the row(0) is correct,dont thing to change it to i, ok.
                ElseIf Not DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsSold").Value = 0 And DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsSold").Value > DGSearch3.Rows(i).Cells("DGSearch3PcsInCrtn").Value Then
                    '''''''''''''''''''''
                    'Now Let's calculate the number of carton in piece.
                    Dim TotQtyInPcsSold As Integer = Val(DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsSold").Value)
                    TotalNoPcsInCrtn = Val(DGSearch3.Rows(i).Cells("DGSearch3PcsInCrtn").Value)
                    Dim EstimatedNoOFCrtnToMinus As Decimal = (TotQtyInPcsSold / TotalNoPcsInCrtn) * 100
                    Dim RawAmount() As String = Convert.ToString(EstimatedNoOFCrtnToMinus).Split(("."))
                    If RawAmount(1) > 0 Then
                        TotalNoOfCrtnToMinus = Convert.ToInt32(RawAmount(0)) + 1
                    Else
                        TotalNoOfCrtnToMinus = Convert.ToInt32(RawAmount(0))
                    End If

                    DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value = TotalNoOfCrtnToMinus 'Val(ds.Tables("GoDownIGL").Rows(0).Item("QtyInCrtn")) - 1
                
                End If
               
            End If
            '''''''''''''''''''''
            'Now Let's calculate the number of pieces in carton.
            Dim TotQtyInPcsReceived As Integer = Val(DGSearch3.Rows(i).Cells("DGSearch3QtyInPcsEnteredGodown").Value)
            TotalNoPcsInCrtn = Val(DGSearch3.Rows(i).Cells("DGSearch3PcsInCrtn").Value)
            If TotQtyInPcsReceived > TotalNoPcsInCrtn Then
                Dim EstimatedNoOFCrtnToPlus As Decimal = (TotQtyInPcsReceived / TotalNoPcsInCrtn)
                Dim AddingAmount() As String = Convert.ToString(EstimatedNoOFCrtnToPlus).Split(("."))
                'If AddingAmount(1) > 0 Then
                '    TotalNoOfCrtnToPlus = Convert.ToInt32(AddingAmount(0)) + 1
                'Else
                '    TotalNoOfCrtnToPlus = Convert.ToInt32(AddingAmount(0))
                'End If
                DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value = Val(DGSearch3.Rows(i).Cells("DGSearch3QtyInCrtn").Value) + Convert.ToInt32(AddingAmount(0)) - Val(DGSearch3.Rows(i).Cells("DGSearchRemovedInCrtn").Value)  'Val(ds.Tables("GoDownIGL").Rows(0).Item("QtyInCrtn")) - 1
           
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Property SelectionBackColorFa() As System.Drawing.Color
        Get
            Return Color.Chocolate
        End Get
        Set(ByVal value As System.Drawing.Color)
            clr = value
        End Set
    End Property
    'Sub GetTotalQtyInPiece()
    '    Module1.DatasetFill("Select PcsInCtrn from VuProductForIGL where ProdCode = " & DGSearch3.Rows(i).Cells("DGSearch3ProductName").Value, "VuProductForIGL")
    '    QtyOfEachProductInPiece = ds.Tables("VuProductForIGL").Rows(0).Item(0)
    'End Sub
    Private Sub TB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.SelectedIndexChanged
        If TB1.SelectedIndex = 1 Then
            CM.Enabled = False
        Else
            CM.Enabled = True
        End If
    End Sub
    Sub DGSearch3Fill()
        Dim AvailableProductsInGodown As Boolean = False
        Dim NoOfRowsReturned As Integer = 0
        Try
            DGSearch3.Rows.Clear()
            i = 0
            Try
                'Module1.DatasetFill("Select Distinct(ProductCode),ProductType,PcsInCtrn from VuGoDownIGLSearch3 Group by ProductCode,ProductType,ProductType,PcsInCtrn Having Sum(RecQty) > Sum(IssueQty)", "VuGoDownIGLSearch3_PresentStock")
                'NoOfRowsReturned = ds.Tables("VuGoDownIGLSearch3_PresentStock").Rows.Count
                ''After Mustafa's practice I had to change the code here and conditions,infact
                ''The game was such that when we add products to godown,it goes to GodownIGL as Type Received.
                ''And when we delete that record it is deleted from GodownIGL as well.
                ''And when we give a cheque to someone, Inside GodownIGL is saved as Remarks = ---
                ''And when we delete the cheque,it does another ..wait let me do something else.
                ''Oh before this I was doing another entry in the opposite RecQty column of IGL that had
                ''create alot of problem, Not I am deleting the issued products from GodownIGL when a cheque is deleted.
                ' ''If NoOfRowsReturned > 0 Then
                'Module1.DatasetFill("Select Distinct(ProductCode),ProductType,PcsInCtrn from VuGoDownIGLSearch3 where GoDownID = " & cmbGoDownSearch3.SelectedValue & " Group by ProductCode,ProductType,PcsInCtrn", "VuGoDownIGLSearch3")
                'Dim ii As Integer
                'ii = ds.Tables("VuGoDownIGLSearch3").Rows.Count
                ' ''End If
                ' oh any how leave everything on 19 sep 08 it is updated and is working correctly.
                Module1.DatasetFill("Select Distinct(ProdCode) as 'ProductCode',ProdTypeID as 'ProductType',PcsInCtrn from VuProduct", "VuProducts_Statistics")
            Catch ex As Exception

            End Try
            'If NoOfRowsReturned = 0 Then
            '    DGSearch3.Rows.Clear()
            '    Exit Sub
            'Else
            For Each datarow As DataRow In ds.Tables("VuProducts_Statistics").Rows
                DGSearch3.Rows.Add()
                DGSearch3.Rows(i).Cells("DGSearch3SNo").Value = i + 1
                DGSearch3.Rows(i).Cells("DGSearch3ProdType").Value = datarow("ProductType")
                DGSearch3.Rows(i).Cells("DGSearch3ProductName").Value = datarow("ProductCode")
                DGSearch3.Rows(i).Cells("DGSearch3PcsInCrtn").Value = datarow("PcsInCtrn")
                Selector()
                i = i + 1

            Next

            'End If

        Catch ex As Exception
            AvailableProductsInGodown = False
            NoOfRowsReturned = 0
        End Try

    End Sub

    Private Sub DGSearch_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveGodownIGL()
        Dim k As Integer
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertGoDownIGL"
        cmdsaveGridIGL.Connection = cn
        Try
            For k = 0 To DG.Rows.Count - 1
                'Don't worry when it executes for one time more that the actual number of records in datagrid, It will go to catch and leave it, that is 
                'intentionally so don't do any changes. Fahim
                cmdsaveGridIGL.Parameters.Add("@RecordID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@RecordID").Value = Var_GoDownStockMainID

                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date
                'Delivered the parameter Type from here inside that RBAdd condition...
                cmdsaveGridIGL.Parameters.Add("@GoDownID", SqlDbType.Int).Value = cmbGodownName.SelectedValue
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(k).Cells("DGcmbPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("ID").Value
                cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGCrtnPcs").Value)
                If RBAdd.Checked = True Then
                    cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Received"
                    cmdsaveGridIGL.Parameters.Add("@RecQty", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGQty").Value)
                    cmdsaveGridIGL.Parameters.Add("@IssueQty", SqlDbType.Decimal).Value = 0
                ElseIf RBDeduct.Checked = True Then
                    cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Damaged removed from " & cmbGodownName.Text
                    cmdsaveGridIGL.Parameters.Add("@RecQty", SqlDbType.Decimal).Value = 0
                    cmdsaveGridIGL.Parameters.Add("@IssueQty", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGQty").Value)
                End If


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
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Var_GoDownStockMainID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub
    'Sub UpdateIGL()
    '    Dim OldQty As Decimal = 0
    '    Dim NewQty As Decimal = 0
    '    Dim TotalQty As Decimal = 0
    '    Dim cmdsaveGridIGL As New SqlCommand
    '    cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
    '    cmdsaveGridIGL.CommandText = "InsertIGL"
    '    cmdsaveGridIGL.Connection = cn
    '    Try

    '        Module1.DatasetFill("Select Sum(PurchaseQty)as PurchaseQuantity from VuIGL where ID=" & PurchaseID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Purchase'", "VuIGL")
    '        OldQty = ds.Tables("VuIGL").Rows(0).Item("PurchaseQuantity")
    '        NewQty = Val(DG.Rows(RowWanted).Cells("DGRecQty").Value)
    '        TotalQty = NewQty - OldQty
    '    Catch ex As Exception
    '    End Try
    '    If TotalQty = 0 Then
    '        Exit Sub
    '    End If
    '    Try
    '        For k = 0 To 1 - 1

    '            cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
    '            cmdsaveGridIGL.Parameters("@ID").Value = PurchaseID
    '            'For Each dtTable As DataTable In ds.Tables
    '            '    MsgBox(dtTable.TableName)
    '            'Next
    '            'Try
    '            '    'DateEntry = ds.Tables(TableKaName_ForInsertion).Rows(a).Item("trdate")

    '            'Catch ex As Exception

    '            'End Try
    '            'Try
    '            '    If DateEntry = #12:00:00 AM# Then
    '            '        Var_TransferDate = "01/01/1900"
    '            '        cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
    '            '    Else
    '            '        Var_TransferDate = DateEntry
    '            '        cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
    '            '    End If
    '            'Catch ex As Exception
    '            'End Try
    '            cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
    '            cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Purchase"
    '            cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(RowWanted).Cells("DGPType").Value
    '            cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(RowWanted).Cells("DGProductCode").Value


    '            cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = TotalQty
    '            cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = 0
    '            cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = 0

    '            Try
    '                If DG.Rows(k).Cells("dgdescription").Value = "" Then
    '                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
    '                Else
    '                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(RowWanted).Cells("dgdescription").Value
    '                End If
    '            Catch ex As Exception
    '                cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
    '            End Try


    '            'cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = "Purchase"
    '            cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
    '            cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & PurchaseID

    '            cmdsaveGridIGL.ExecuteNonQuery()
    '            cmdsaveGridIGL.Parameters.Clear()
    '        Next
    '    Catch ex As Exception
    '    End Try
    'End Sub




    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If DGSearch3.Rows.Count = 0 Then
            Exit Sub
        Else

            TransferDataToReportTable()
            Module1.DatasetFill("Select * from RptVuGodownData", "RptVuGodownData")
            Dim rpt As New RptGodownData
            rpt.SetDataSource(Module1.ds.Tables("RptVuGodownData"))
            frmRptSetup.CV.ReportSource = rpt
            Frm.RptShow()
        End If
    End Sub
    Sub TransferDataToReportTable()
        Module1.DeleteRecord("TblGodownReport")
        Dim cmdsaveGridReport As New SqlCommand
        cmdsaveGridReport.CommandType = CommandType.StoredProcedure
        cmdsaveGridReport.CommandText = "InsertGodownDataForReport"
        cmdsaveGridReport.Connection = cn
        Try

            For r As Integer = 0 To DGSearch3.Rows.Count - 1
                cmdsaveGridReport.Parameters.Add("@GoDownID", SqlDbType.Int).Value = cmbGoDownSearch3.SelectedValue
                cmdsaveGridReport.Parameters.Add("@Sno", SqlDbType.Int).Value = DGSearch3.Rows(r).Cells("DGSearch3SNo").Value
                cmdsaveGridReport.Parameters.Add("@ProductType", SqlDbType.NVarChar).Value = DGSearch3.Rows(r).Cells("DGSearch3ProdType").FormattedValue
                cmdsaveGridReport.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = DGSearch3.Rows(r).Cells("DGSearch3ProductName").FormattedValue
                cmdsaveGridReport.Parameters.Add("@SoldInCrtn", SqlDbType.Int).Value = Val(DGSearch3.Rows(r).Cells("DGSearch3QtyInCrtnSold").Value)
                cmdsaveGridReport.Parameters.Add("@SoldInPcs", SqlDbType.Int).Value = Val(DGSearch3.Rows(r).Cells("DGSearch3QtyInPcsSold").Value)
                cmdsaveGridReport.Parameters.Add("@AvailInCrtn", SqlDbType.Int).Value = Val(DGSearch3.Rows(r).Cells("DGSearch3QtyInCrtn").Value)
                cmdsaveGridReport.Parameters.Add("@AvailInPcs", SqlDbType.Int).Value = Val(DGSearch3.Rows(r).Cells("DGSearch3QtyInPcs").Value)
                cmdsaveGridReport.Parameters.Add("@NoOfPcsInCrtn", SqlDbType.Int).Value = Val(DGSearch3.Rows(r).Cells("DGSearch3PcsInCrtn").Value)
                cmdsaveGridReport.Parameters.Add("@EnteredGInCrtn", SqlDbType.Int).Value = Val(DGSearch3.Rows(r).Cells("DGSearch3QtyInCrtnEnteredGodown").Value)
                cmdsaveGridReport.Parameters.Add("@EnteredGInPcs", SqlDbType.Int).Value = Val(DGSearch3.Rows(r).Cells("DGSearch3QtyInPcsEnteredGodown").Value)
                If cn.State = ConnectionState.Closed Then cn.Open()
                cmdsaveGridReport.ExecuteNonQuery()
                cmdsaveGridReport.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class
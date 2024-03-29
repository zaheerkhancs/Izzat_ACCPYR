Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmOderEnglish
    Dim OrderID As Integer
    Dim Editvalue As Integer
    Dim cnt As Integer
    Dim a As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim CurrowIndex As Integer = 0
    Dim index As Boolean
    Dim _OrderNo As String
    Dim byt As Byte()
    Dim ms As MemoryStream
    Private Sub frmOderEnglish_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.Opencn()
        index = False
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text

        Module1.DatasetFill("Select * from VuVendorForOrderMainEnglish", "VuVendorForOrderMainEnglish")
        cmbVendorForOrderMainEnglish.DataSource = ds.Tables("VuVendorForOrderMainEnglish")
        cmbVendorForOrderMainEnglish.DisplayMember = ("Name")
        cmbVendorForOrderMainEnglish.ValueMember = ("VID")

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        DGPType.DataSource = ds.Tables("ProductType")
        DGPType.DisplayMember = ("ProdTypeNameEnglish")
        DGPType.ValueMember = ("ProdTypeID")

        'Module1.DatasetFill("Select ProdCode,Product from VuProduct", "VuProduct")
        'DGcmbProductCode.DataSource = ds.Tables("VuProduct")
        'DGcmbProductCode.DisplayMember = ("Product")
        'DGcmbProductCode.ValueMember = ("ProdCode")

        dtOrderDate.Value = Now
        dtReqDate.Value = Now
        Call Clear()
        Call fill()
        Editvalue = 1
        index = True
        MnuReturn.Visible = False
        Label3.Visible = False
        cmbOrderNoSearch.Visible = False
        Label4.Visible = False
        cmbCompanySearch.Visible = False
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

    Sub OrderNoGenerator()
        Dim _m As String
        Dim _y As String
        Dim _MaxID As String
        Dim _Criteria As String
        _m = Date.Now.Month
        _y = Date.Now.Year
        _y = _y.Substring(2, 2)

        If _m.Length = 1 Then
            _m = "0" & _m
        End If
        _Criteria = "IAL-ORD-" & _m & "-" & _y & "-"

        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(Convert(INT,Substring(OrderNo,15,len(OrderNo)))) from OrderEnglishMain where OrderNo Like('" & _Criteria & "%'" & ")"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    _MaxID = 1
                Else
                    _MaxID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

            If _m.Length = 1 Then
                _m = "0" & _m
            End If
            If _MaxID.Length = 1 Then
                _MaxID = "0" & _MaxID
            End If
            _OrderNo = "IAL-ORD-" & _m & "-" & _y & "-" & _MaxID
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

#Region " Functions "

    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuSearch.Enabled = Not MnuSearch.Enabled
        'MnuExit.Enabled = Not MnuExit.Enabled
    End Sub

    Sub CStatus()
        cmbVendorForOrderMainEnglish.Enabled = Not cmbVendorForOrderMainEnglish.Enabled
        dtOrderDate.Enabled = Not dtOrderDate.Enabled
        dtReqDate.Enabled = Not dtReqDate.Enabled
        txtRemarks.ReadOnly = Not txtRemarks.ReadOnly
        txtNote.ReadOnly = Not txtNote.ReadOnly
        DG.ReadOnly = Not DG.ReadOnly
        ToolStrip1.Enabled = Not ToolStrip1.Enabled
        btnBrowse.Enabled = Not btnBrowse.Enabled
    End Sub

    Sub Clear()
        lblMessage.Text = ""
        'txtVendor.Text = ""
        txtPersonName.Text = ""
        txtJobTitle.Text = ""
        txtOrderNo.Text = ""
        txtNote.Text = ""
        dtOrderDate.Value = Now
        dtReqDate.Value = Now
        txtRemarks.Text = ""
        DG.Rows.Clear()
    End Sub

    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.CurrentCell.ColumnIndex = 5 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
            Me.DG.CurrentRow.Cells(5).Value = Me.ActiveControl.Text & e.KeyChar

        End If
    End Sub

    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub

    Sub SaveUpdateOrderEnglishMain()
        Try

         

            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateOrderEnglishMain"
            cmdsave.Connection = cn
            If Editvalue = 1 Then
                Module1.DatasetFill("Select OrderID from OrderEnglishMain", "OrderEnglishMain")
                cmd.CommandText = "Select isnull(Max(OrderID),0) from OrderEnglishMain"
                OrderID = cmd.ExecuteScalar + 1
            End If
            cmdsave.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID
            cmdsave.Parameters.Add("@OrderNo", SqlDbType.NVarChar).Value = Me.txtOrderNo.Text
            cmdsave.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = Me.cmbVendorForOrderMainEnglish.SelectedValue
            cmdsave.Parameters.Add("@PersonName", SqlDbType.NVarChar).Value = Me.txtPersonName.Text
            cmdsave.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = Me.txtJobTitle.Text
            cmdsave.Parameters.Add("@OrderDate", SqlDbType.SmallDateTime).Value = Me.dtOrderDate.Value.Date.ToString
            cmdsave.Parameters.Add("@ReqDate", SqlDbType.SmallDateTime).Value = Me.dtReqDate.Value.Date.ToString
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            cmdsave.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Me.txtNote.Text
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & OrderID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = Editvalue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If Editvalue = 1 Then
                SaveUpdateOrderEnglishDetail()
                SaveInvoiceProforma()
                CMStatus()
                CStatus()
                'fill()
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
                lblMessage.Text = "THE RECORD HAS BEEN SAVED SUCCESSFULLY"

            Else
                DeleteOrderEnglishDetail()
                SaveUpdateOrderEnglishDetail()
                If chkSaveInvoiceProforma.Checked = True Then
                    SaveInvoiceProforma()
                End If

                CMStatus()
                CStatus()
                fill()
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                lblMessage.Text = "THE RECORD HAS BEEN UPDATED SUCCESSFULLY"
                Editvalue = 1
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub SaveInvoiceProforma()
        Try

            ms = New MemoryStream
            Me.InvProfPB.Image.Save(ms, Me.InvProfPB.Image.RawFormat)
            Dim byt As Byte() = ms.GetBuffer()
            ms.Close()
            If byt.Length > 0 Then
                Cursor = Cursors.WaitCursor
                Dim cmdSave As New SqlCommand
                cmdSave.Connection = cn
                cmdSave.CommandType = CommandType.StoredProcedure
                cmdSave.CommandText = "InsertInvoiceProforma"
                cmdSave.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID
                cmdSave.Parameters.Add("@InvProformaImage", SqlDbType.Image).Value = byt
                cmdSave.ExecuteNonQuery()
                cmdSave.Parameters.Clear()
                Cursor = Cursors.Default
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub DeleteOrderEnglishDetail()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteOrderEnglishDetail"
        cmdDelete.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID
        cmdDelete.ExecuteNonQuery()
    End Sub

    Sub SaveUpdateOrderEnglishDetail()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateOrderEnglishDetail"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 2
                cmdsaveGrid.Parameters.Add("@OrderID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@OrderID").Value = OrderID

                cmdsaveGrid.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNO").Value
                cmdsaveGrid.Parameters.Add("@ProdType", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdName", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGID").Value
                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGQty").Value
                If DG.Rows(a).Cells("DGDecription").Value = "" Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = " "
                Else
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDecription").Value
                End If
                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try

    End Sub

    Sub fill()
        Try
            DG.Columns("DGcmbProductCode").Visible = False
            Editvalue = 1
            If cnt < 0 Then
                cnt = 0
            End If
            lblMessage.Text = ""
            Module1.DatasetFill("Select * from VuOrderEnglishMain Order by OrderNo", "VuOrderEnglishMain")
            If ds.Tables("VuOrderEnglishMain").Rows.Count = 0 Then Exit Sub
            OrderID = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("OrderID")
            Module1.DatasetFill("Select OrderID from OrderEnglishInvoiceProformaTbl where OrderID =" & OrderID, "OrderEnglishInvoiceProformaTbl")
            If ds.Tables("OrderEnglishInvoiceProformaTbl").Rows.Count = 0 Then
                LnkInvoiceProforma.Visible = False
                Me.InvProfPB.Image = Nothing
            Else
                LnkInvoiceProforma.Visible = True
            End If
            Me.InvProfPB.Image = Nothing
            txtOrderNo.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("OrderNo")
            cmbVendorForOrderMainEnglish.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("Name")
            txtPersonName.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("PersonName")
            txtJobTitle.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("JobTitle")
            dtOrderDate.Value = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("OrderDate")
            dtReqDate.Value = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("ReqDate")
            txtRemarks.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("Remarks")
            txtNote.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("Note")
            Call Gridfill()
            chkSaveInvoiceProforma.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Sub Gridfill()
        Try

            Module1.DatasetFill("Select * from VuOrderEnglishDetail where OrderId=" & OrderID & " Order by SNo", "VuOrderEnglishDetail")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuOrderEnglishDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNO").Value = ds.Tables("VuOrderEnglishDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuOrderEnglishDetail").Rows(a).Item("ProdType")
                    DG.Rows(a).Cells("DGProductName").Value = ds.Tables("VuOrderEnglishDetail").Rows(a).Item("ProductEnglish")
                    DG.Rows(a).Cells("DGID").Value = ds.Tables("VuOrderEnglishDetail").Rows(a).Item("ProdName")
                    DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuOrderEnglishDetail").Rows(a).Item("Qty")
                    DG.Rows(a).Cells("DGDecription").Value = ds.Tables("VuOrderEnglishDetail").Rows(a).Item("ProdDescription")
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub

    Sub k1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                DG.CurrentRow.Cells(1).Value = sender.text
                Module1.DatasetFill("Select ProdCode,ProductEnglish from VuProduct where ProdTypeNameEnglish ='" & DG.CurrentRow.Cells(1).Value & "'", "VuProduct")
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
        End If
    End Sub

#End Region

#Region " Context Menu "

    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click

        If MnuSearch.Visible = False Then
            MnuReturn.Visible = False
            Label3.Visible = False
            cmbOrderNoSearch.Visible = False
            Label4.Visible = False
            cmbCompanySearch.Visible = False
            MnuSearch.Visible = True
        End If

        Call CMStatus()
        Call CStatus()
        Call Clear()
        cmbVendorForOrderMainEnglish.SelectedIndex = -1
        DG.Columns("DGcmbProductCode").Visible = True
        DGcmbProductCode.DataSource = Nothing
        DGcmbProductCode.Items.Clear()
        Call OrderNoGenerator()
        txtOrderNo.Text = _OrderNo
        InvProfPB.Visible = True
        LnkInvoiceProforma.Visible = False
        chkSaveInvoiceProforma.Visible = False
        Me.InvProfPB.Image = Nothing
    End Sub

    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        Call CMStatus()
        Call CStatus()
        cmbVendorForOrderMainEnglish.Enabled = False
        Call Clear()
        Call fill()
        InvProfPB.Visible = False
        LnkInvoiceProforma.Visible = True
        chkSaveInvoiceProforma.Visible = False
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click

        If cmbVendorForOrderMainEnglish.Text = "" Or txtOrderNo.Text = "" Or DG.Rows.Count = 1 Then
            MsgBox(" PLEASE FILL THE REQUIRED FIELDS ", MsgBoxStyle.Critical)
            Exit Sub
        Else
            Try
                SaveUpdateOrderEnglishMain()
                cmbVendorForOrderMainEnglish.Enabled = False
                InvProfPB.Visible = False
                Module1.DatasetFill("Select OrderID from OrderEnglishInvoiceProformaTbl where OrderID = " & OrderID, "OrderEnglishInvoiceProformaTbl")
                If ds.Tables("OrderEnglishInvoiceProformaTbl").Rows.Count = 0 Then
                    LnkInvoiceProforma.Visible = False
                    Me.InvProfPB.Image = Nothing
                Else
                    LnkInvoiceProforma.Visible = True
                End If
            Catch ex As Exception

            End Try
        End If
        chkSaveInvoiceProforma.Visible = False
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click

        If MnuSearch.Visible = False Then
            MnuReturn.Visible = False
            Label3.Visible = False
            cmbOrderNoSearch.Visible = False
            Label4.Visible = False
            cmbCompanySearch.Visible = False
            MnuSearch.Visible = True
        End If

        CMStatus()
        CStatus()
        cmbVendorForOrderMainEnglish.Enabled = False
        Editvalue = 0
        DG.Columns("DGcmbProductCode").Visible = True
        DGcmbProductCode.DataSource = Nothing
        DGcmbProductCode.Items.Clear()
        chkSaveInvoiceProforma.Visible = True
    End Sub

    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Try

            Dim a As VariantType
            a = MsgBox("Are you Sure You Want TO Delete.?", MsgBoxStyle.YesNo)
            If a = vbYes Then
                cmd.CommandText = " Delete from OrderEnglishMain where OrderID = " & OrderID
                cmd.Connection = cn
                cmd.ExecuteNonQuery()
                cmd.CommandText = " Delete from OrderEnglishInvoiceProformaTbl where OrderID = " & OrderID
                cmd.Connection = cn
                cmd.ExecuteNonQuery()
                'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
                If cnt = ds.Tables("VuOrderEnglishMain").Rows.Count - 1 Then
                    cnt = cnt - 1
                End If
                If cnt < 0 Then
                    Clear()
                End If
                Call fill()
                lblMessage.Text = "THE RECORD HAS BEEN DELETED SUCCESSFULLY"

                If MnuSearch.Visible = False Then
                    MnuReturn.Visible = False
                    Label3.Visible = False
                    cmbOrderNoSearch.Visible = False
                    Label4.Visible = False
                    cmbCompanySearch.Visible = False
                    MnuSearch.Visible = True
                End If
            End If
            chkSaveInvoiceProforma.Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region

#Region " Navigations "
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        Call fill()
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call fill()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuOrderEnglishMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call fill()
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuOrderEnglishMain").Rows.Count - 1
        Call fill()
    End Sub
#End Region

#Region " Data Grid View "
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
    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        'Try
        '    DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'Catch ex As Exception

        'End Try
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        If DG.CurrentRow.Index = CurrowIndex Then
            DG.CurrentRow.Cells(2).ReadOnly = False
            DG.CurrentRow.Cells(1).ReadOnly = False
        Else
            DG.CurrentRow.Cells(2).ReadOnly = True
        End If
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1


        If DG.CurrentCell.ColumnIndex = 1 Then
            Try
                Dim cmb As ComboBox
                cmb = CType(e.Control, ComboBox)
                AddHandler cmb.SelectionChangeCommitted, AddressOf k1
            Catch ex As Exception
            End Try
        End If
        If DG.CurrentRow.Index = CurrowIndex Then
            Try
                Dim cmb As ComboBox
                cmb = CType(e.Control, ComboBox)
                AddHandler cmb.SelectionChangeCommitted, AddressOf K2

            Catch ex As Exception
            End Try
        End If


        If DG.CurrentCell.ColumnIndex = 4 Or DG.CurrentCell.ColumnIndex = 5 Then
            Dim ltxt As New TextBox
            ltxt = CType(e.Control, TextBox)
            AddHandler ltxt.KeyPress, AddressOf NumericKeys
        End If
        'Delegation of current cell's data to be able to insert in database without leaving the cell.
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
            'Try
            '    Dim cmb As ComboBox
            '    cmb = CType(e.Control, ComboBox)
            '    AddHandler cmb.SelectionChangeCommitted, AddressOf DelegateCellData

            'Catch ex As Exception
            'End Try
        End If


        'MsgBox(DG.CurrentCell.GetType().ToString())
        'If dg.CurrentCell.GetType  == typeof(System.Windows.Forms.DataGridViewComboBoxCell) Then
        '    MsgBox("")
        'End If

        'Dim ltxt1 As New TextBox
        'ltxt1 = CType(e.Control, TextBox)
        'AddHandler ltxt1.KeyPress, AddressOf NumericKeys1
        'End If
        'Experiment: wanted to do an experiment to get them all in Module but remainied.
        ' ''Dim cont As Control = e.Control
        ' ''Dim tpe As Type = cont.GetType
        ' ''Dim ee As DataGridViewEditingControlShowingEventArgs = e
        ' ''Dim DGName As DataGridView
        ' ''Dim Frm As Form
        ' ''Frm.Name = Me.Name
        ' ''DGName.Name = DG.Name
        'End Experiment
   
        ' ''DelegateControl(cont, tpe)

    End Sub
 
#End Region

#Region " KeyPress "
    Private Sub txtOrderNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrderNo.KeyPress
        If txtOrderNo.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
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
    Private Sub txtPersonName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersonName.KeyPress
        If txtPersonName.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If OrderID = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from VuOrderEnglishMain where OrderID=" & OrderID, "VuOrderEnglishMain")
                'Module1.DatasetFill("Select * from VuOrderEnglishDetail where OrderID=" & OrderID, "VuOrderEnglishDetail")
                Dim rpt As New RptOderEnglish
                rpt.SetDataSource(Module1.ds.Tables("VuOrderEnglishMain"))
                'rpt.SetDataSource(Module1.ds)
                'rpt.SetDataSource(Module1.ds.Tables("VuOrderEnglishDetail"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbVendorForOrderMainEnglish_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVendorForOrderMainEnglish.SelectedIndexChanged
        If index = True Then
            If cmbVendorForOrderMainEnglish.Enabled = True Then
                Try
                    Module1.DatasetFill("Select ConcernPName,JobTitle from VuVendorNameForCombo where VID = " & cmbVendorForOrderMainEnglish.SelectedValue & "", "VuVendorNameForCombo")
                    txtPersonName.Text = ds.Tables("VuVendorNameForCombo").Rows(0).Item("ConcernPName")
                    txtJobTitle.Text = ds.Tables("VuVendorNameForCombo").Rows(0).Item("JobTitle")
                    txtRemarks.Text = "-------"
                    txtNote.Text = " "
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub cmbVendorForOrderMainEnglish_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVendorForOrderMainEnglish.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub txtNote_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNote.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub MnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSearch.Click
        Try

            Module1.DatasetFill("Select VID,Name from Vendor", "Vendor")
            cmbCompanySearch.DataSource = ds.Tables("Vendor")
            cmbCompanySearch.DisplayMember = ("Name")
            cmbCompanySearch.ValueMember = ("VID")
            'cmbOrderNoSearch.SelectedIndex = -1

            Label3.Visible = True
            cmbOrderNoSearch.Visible = True
            Label4.Visible = True
            cmbCompanySearch.Visible = True

            Clear()
            cmbVendorForOrderMainEnglish.SelectedIndex = -1

            MnuSearch.Visible = False
            MnuReturn.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReturn.Click
        If DG.Rows.Count = 1 And cmbVendorForOrderMainEnglish.Text = "" Then
            fill()
        End If

        Label3.Visible = False
        cmbOrderNoSearch.Visible = False
        Label4.Visible = False
        cmbCompanySearch.Visible = False

        MnuSearch.Visible = True
        MnuReturn.Visible = False
    End Sub

    Private Sub cmbOrderNoSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbOrderNoSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Module1.DatasetFill("Select * from VuOrderEnglishMain Order by OrderNo", "VuOrderEnglishMain")
                Dim Var_numberOfOccurance As Integer = 0
                Dim Var_PostionFound As Integer = 0
                Dim Var_loopLength As Integer = 0
                Dim Var_LetAssignment As Boolean = True
                For Each dtr As DataRow In ds.Tables("VuOrderEnglishMain").Rows
                    If cmbOrderNoSearch.SelectedValue = dtr("OrderID") Then
                        Var_numberOfOccurance += 1

                    Else

                    End If
                    If Var_numberOfOccurance = 1 And Var_LetAssignment = True Then
                        Var_PostionFound = Var_loopLength
                        Var_LetAssignment = False
                    End If
                    Var_loopLength += 1
                Next
                If Var_numberOfOccurance = 0 Then
                    txtclear(Me, pnlcentre, TB1, TP1)
                    'Module1.GetMax("SocialDataID", "SocialData")
                    'lblRecNo.Text = Module1.MaxID
                    'CStatusDefault()
                    MnuEdit.Enabled = False
                    MnuNew.Enabled = True

                    Exit Sub
                Else
                    cnt = Var_PostionFound
                    lblMessage.Text = ""
                    'Module1.DatasetFill("Select * from VuOrderEnglishMain Where OrderID=" & cmbOrderNoSearch.SelectedValue, "VuOrderEnglishMain")
                    If ds.Tables("VuOrderEnglishMain").Rows.Count = 0 Then Exit Sub
                    OrderID = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("OrderID")
                    txtOrderNo.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("OrderNo")
                    cmbVendorForOrderMainEnglish.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("Name")
                    txtPersonName.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("PersonName")
                    txtJobTitle.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("JobTitle")
                    dtOrderDate.Value = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("OrderDate")
                    dtReqDate.Value = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("ReqDate")
                    txtRemarks.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("Remarks")
                    txtNote.Text = ds.Tables("VuOrderEnglishMain").Rows(cnt).Item("Note")
                    Call Gridfill()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbOrderNoSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbOrderNoSearch.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub cmbCompanySearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompanySearch.SelectedIndexChanged
        Try
            Module1.DatasetFill("Select OrderID,OrderNo from OrderEnglishMain where CompanyName=" & cmbCompanySearch.SelectedValue, "OrderEnglishMain")
            cmbOrderNoSearch.DataSource = ds.Tables("OrderEnglishMain")
            cmbOrderNoSearch.DisplayMember = ("OrderNo")
            cmbOrderNoSearch.ValueMember = ("OrderID")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            OFD.ShowDialog()
            InvProfPB.Image = Image.FromFile(OFD.FileName)
            OFD.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LnkInvoiceProforma_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkInvoiceProforma.LinkClicked
        Try

            Module1.DatasetFill("Select * from OrderEnglishInvoiceProformaTbl where OrderID =" & OrderID, "OrderEnglishInvoiceProformaTbl")
            If ds.Tables("OrderEnglishInvoiceProformaTbl").Rows.Count = 0 Then
                MessageBox.Show("Sorry,the Image could not be loaded.")
            Else

                'File.Create("DefaultImage.jpg")
                Dim ImgBuffer As Byte()

                ImgBuffer = ds.Tables("OrderEnglishInvoiceProformaTbl").Rows(0).Item("InvProformaImage")
                Me.InvProfPB.Image = Image.FromStream(New MemoryStream(ImgBuffer))
                'Convert.ToByte(ImgBuffer)
                File.WriteAllBytes("DefaultImage.jpg", ImgBuffer)
                System.Diagnostics.Process.Start("DefaultImage.jpg")
                'System.Diagnostics.Process.Start(
            End If
            ' System.Diagnostics.Process.Start("DefaultImage.bmp")

        Catch ex As Exception

        End Try
    End Sub


    Private Sub chkSaveInvoiceProforma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSaveInvoiceProforma.CheckedChanged
        If chkSaveInvoiceProforma.Checked = True Then
            InvProfPB.Visible = True
        End If
    End Sub
End Class
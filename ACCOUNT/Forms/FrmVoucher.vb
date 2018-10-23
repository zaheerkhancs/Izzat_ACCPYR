Imports System.Data.SqlClient
Public Class FrmVoucher
    Dim cnt As Integer = 0
    Dim Post As Integer
    Dim Flag As Integer
    Dim EditFlag As Boolean
    Dim Trans As SqlTransaction
    Private Sub FrmVoucher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' DG.Rows.Add()

        If Me.GroupBox1.Text = "رسید بانکی" Then
            Me.LblRece.Visible = True
            Me.TxtCheque.Visible = True
            Me.LblCheque.Visible = True
            Me.TxtRece.Visible = True
        ElseIf Me.GroupBox1.Text = "پرداخت بانکی" Then
            Me.LblPaid.Visible = True
            Me.TxtCheque.Visible = True
            Me.LblCheque.Visible = True
            Me.TxtPaid.Visible = True

        End If

        Dim sts As Boolean
        sts = Module1.GetValue("AccStatus", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")

        Me.Left = 0
        Me.Top = 0
        Module1.Opencn()
        ' Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
        'Me.Height = Screen.PrimaryScreen.Bounds.Height - 4
        Me.Height = Frm.Height - 70
        Me.Width = Frm.Width - 177

        GroupBox1.Left = Me.Width / 2 - (GroupBox1.Width / 2)
        GroupBox1.Top = Me.Height / 2 - (GroupBox1.Height / 2)

        txtclear()
        Module1.DatasetFill("Select * from VuPermission Where GroupID=" & Frm.GID.Text & " and PerName='Vouchers'", "VuPermission")
        If ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
            Me.Close()
            MsgBox("You have no right to view this Form . For further detail contact your administrator", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Alert")
            Exit Sub
        ElseIf ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = True And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
            Me.ToolStripMenuEdit.Visible = False

        ElseIf ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = True And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
            Me.ToolStripMenuEdit.Visible = False
            Me.ToolStripMenuSave.Visible = False
            Me.ContextM.Enabled = False
        End If
        Module1.DatasetFill("Select * from CompannySetUp", "Setting2")
        If ds.Tables("Setting2").Rows(0).Item(2) = True Then
            DG.Columns(5).Visible = True
            DG.Columns(6).Visible = True
        Else
            DG.Columns(5).Visible = False
            DG.Columns(6).Visible = False

        End If

        If ds.Tables("Setting2").Rows(0).Item(1) = True Then
            Post = 1
        Else
            Post = 0
        End If


        If sts = 0 Then
            Me.ToolStripMenuEdit.Visible = False
            Me.ToolStripMenuSave.Visible = False
            Me.NewToolStripMenuItem.Visible = False
            Label5.Visible = True
            Me.ContextM.Enabled = False
        Else
            Label5.Visible = False
        End If

        Module1.DatasetFill("Select * from VoucherMain where Vtype=N'" & GroupBox1.Text & "' and CompanyID=" & Frm.LBCompanyID.Text & " and PID=N'" & Frm.LblPeriod.Text & "'", "VoucherMain")
        Module1.DatasetFill("Select * from Chartofaccount", "Chartofacc")
        ListBox1.DataSource = ds.Tables("Chartofacc")
        ListBox1.ValueMember = "HeadName"
        ListBox1.DisplayMember = "HeadID"
        Call txtfill()
    End Sub

    Sub txtfill()
        Try

        
            Me.txtVno.Text = ds.Tables("VoucherMain").Rows(cnt).Item("Vno")
            Me.DtDate.Value = ds.Tables("VoucherMain").Rows(cnt).Item("Date")
            Me.TxtDesc.Text = ds.Tables("VoucherMain").Rows(cnt).Item("Descr")
            Me.TxtNarration.Text = ds.Tables("VoucherMain").Rows(cnt).Item("Remarks")
            Me.TxtPaid.Text = ds.Tables("VoucherMain").Rows(cnt).Item("paid")
            Me.TxtRece.Text = ds.Tables("VoucherMain").Rows(cnt).Item("Received")
            Me.TxtCheque.Text = ds.Tables("VoucherMain").Rows(cnt).Item("Cheque")

            Dim dtts As Date
            'datts = ds.Tables("VoucherMain").Rows(cnt).Item("VKey")
            'FormatDateTime(Now, DateFormat.ShortDate)
            dtts = Now

            If FormatDateTime(ds.Tables("VoucherMain").Rows(cnt).Item("VKey"), DateFormat.ShortDate) = FormatDateTime(Now, DateFormat.ShortDate) Then
                Module1.UpdateRecord("VoucherMain", "Vkey='01/01/1900'", "Vno=N'" & Me.txtVno.Text & "'")
                Module1.DatasetFill("Select * from VoucherMain where Vtype=N'" & GroupBox1.Text & "' and CompanyID=" & Frm.LBCompanyID.Text & " and PID=N'" & Frm.LblPeriod.Text & "'", "VoucherMain")
                Call txtfill()
            End If

            If Now < ds.Tables("VoucherMain").Rows(cnt).Item("Date") Or ds.Tables("VoucherMain").Rows(cnt).Item("VKey") <= Now.Date Or ds.Tables("VoucherMain").Rows(cnt).Item("VKey") = "1/1/1900" Then
                EditFlag = False

            Else
                EditFlag = True
            End If
            
            If ds.Tables("VoucherMain").Rows(cnt).Item("Vpost") = 1 Then
                ChkStatus.Checked = True
            Else
                ChkStatus.Checked = False
            End If


            Call GridFill()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CalcTotal()
        LblDr.Text = "0"
        LblCr.Text = "0"
        Dim a As Integer

        For a = 0 To Dg.Rows.Count - 1
            LblDr.Text = Val(LblDr.Text) + Val(DG.Rows(a).Cells(7).Value)
            LblCr.Text = Val(LblCr.Text) + Val(DG.Rows(a).Cells(8).Value)

        Next
        LBlWords.Text = Module1.NoWord(Val(LblDr.Text))
    End Sub
    Sub GridFill()
        Dim a As Integer = 0
        DG.Rows.Clear()
        Module1.DatasetFill("Select * from VuVoucherDetail where Vno=N'" & Me.txtVno.Text & "' order by Cr", "VuVoucherDetail")
        For a = 0 To ds.Tables("VuVoucherDetail").Rows.Count - 1
            DG.Rows.Add()
            DG.Rows(a).Cells(0).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(1)
            DG.Rows(a).Cells(1).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(2)
            DG.Rows(a).Cells(2).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(3)
            If IsDBNull(ds.Tables("VuVoucherDetail").Rows(a).Item(4)) = True Then
                DG.Columns(3).Visible = False
            Else
                DG.Columns(3).Visible = True
            End If
            DG.Rows(a).Cells(3).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(4)
            DG.Rows(a).Cells(4).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(5)
            DG.Rows(a).Cells(5).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(6)
            DG.Rows(a).Cells(6).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(7)
            DG.Rows(a).Cells(7).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(8)
            DG.Rows(a).Cells(8).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(9)

        Next
        Call CalcTotal()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkStatus.CheckedChanged
        

        'If ChkStatus.Checked = True Then
        '    ChkStatus.BackColor = Color.OrangeRed
        '    ChkStatus.Text = "Not Post"
        '    Post = 1
        'Else
        '    ChkStatus.BackColor = Color.MediumSeaGreen
        '    ChkStatus.Text = "Post"
        '    Post = 0
        'End If
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Try
            If DG.CurrentCell.ColumnIndex = 0 Then
                DG.Columns(3).Visible = True
                Module1.DatasetFill("Select * from Subsidiary where HeadID='" & DG.CurrentRow.Cells(0).Value & "'", "Subsidary")
                '  MsgBox(ds.Tables("Subsidary").Rows.Count)
                If ds.Tables("Subsidary").Rows.Count = 0 Then DG.Columns(3).Visible = False
                ListBox2.DataSource = Nothing
                ListBox2.Items.Clear()
                DG.Columns(3).HeaderText = DG.CurrentRow.Cells(1).Value
                ListBox2.DataSource = ds.Tables("Subsidary")
                ListBox2.ValueMember = "SubID"
                ListBox2.DisplayMember = "SubName"
            End If
        Catch ex As Exception
        End Try
    End Sub

    

    Private Sub DG_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                DG.Columns(3).Visible = True
                Module1.DatasetFill("Select * from Subsidiary where HeadID='" & DG.CurrentRow.Cells(0).Value & "'", "Subsidary")
                If ds.Tables("Subsidary").Rows.Count = 0 Then DG.Columns(3).Visible = False
                ListBox2.DataSource = Nothing
                ListBox2.Items.Clear()
                DG.Columns(3).HeaderText = DG.CurrentRow.Cells(1).Value

                ListBox2.DataSource = ds.Tables("Subsidary")
                ListBox2.ValueMember = "SubID"
                ListBox2.DisplayMember = "SubName"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellLeave
        Try


            If DG.CurrentCell.ColumnIndex = 0 Then
                DG.Columns(3).Visible = True
                Module1.DatasetFill("Select * from Subsidiary where HeadID='" & DG.CurrentRow.Cells(0).Value & "'", "Subsidary")
                If ds.Tables("Subsidary").Rows.Count = 0 Then DG.Columns(3).Visible = False
                ListBox2.DataSource = Nothing
                ListBox2.Items.Clear()
                DG.Columns(3).HeaderText = DG.CurrentRow.Cells(1).Value


                ListBox2.DataSource = ds.Tables("Subsidary")
                ListBox2.ValueMember = "SubID"
                ListBox2.DisplayMember = "SubName"
            End If

        Catch ex As Exception

        End Try
    End Sub

   
    'Private Sub DG_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DG.CellValueNeeded
    '    If e.ColumnIndex = 6 Then
    '        Dim dt As Date
    '        dt = FormatDateTime(e.Value, DateFormat.ShortDate)
    '        If IsDate(dt) = False Then
    '            MsgBox("Please enter the correct format")
    '            e.Value = Now.Date

    '        End If
    '    End If
    'End Sub
    Private Sub DgBankPayment_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        Try

    
            If DG.CurrentCell.ColumnIndex = 0 Then

                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf Key1
                ' AddHandler ltxt.GotFocus, AddressOf Key3
                AddHandler ltxt.KeyDown, AddressOf Key2
            ElseIf DG.CurrentCell.ColumnIndex = 4 Then
                Dim ltxt As TextBox
                ltxt = CType(e.Control, TextBox)
                'AddHandler ltxt.KeyPress, AddressOf NumericKeys
            ElseIf DG.CurrentCell.ColumnIndex = 3 Then
                Dim ltxt As TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf Key1
            ElseIf DG.CurrentCell.ColumnIndex = 8 Or DG.CurrentCell.ColumnIndex = 7 Then
                Dim ltxt As TextBox
                ltxt = CType(e.Control, TextBox)

                AddHandler ltxt.KeyPress, AddressOf NumericKeys
                'AddHandler ltxt.KeyDown, AddressOf SHelp

            Else
                Dim ltxt As TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf Key
                AddHandler ltxt.KeyDown, AddressOf Key0
            End If
        Catch ex As Exception

        End Try
    End Sub
 

    Private Sub Key1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try

            ' MsgBox(sender.text)
            Dim str As String
            Dim oldval As String
            Dim newval As String

            'If e.KeyChar = "" Then Exit Sub


            If DG.CurrentCell.ColumnIndex = 0 Then
                If Asc(e.KeyChar) <> 8 Then
                    oldval = Strings.Left(sender.Text, Len(sender.Text) - Len(sender.SelectedText))
                    newval = oldval & e.KeyChar
                    Dim a As Integer
                    For a = 0 To ListBox1.Items.Count - 1


                        If LCase(Strings.Left(ListBox1.GetItemText(ListBox1.Items(a)), Len(newval))) = LCase(newval) Then
                            sender.Text = ListBox1.GetItemText(ListBox1.Items(a))
                            str = sender.Text

                            If (Len(newval)) <> Len(sender.text) Then

                                If str.Substring(Len(newval), 1) = "-" Then
                                    newval = newval & "-"
                                End If
                            End If


                            sender.SelectionStart = Len(newval)
                            sender.SelectionLength = Len(sender.Text) - Len(newval)
                            Exit For
                        End If
                    Next
                    e.Handled = True
                Else
                End If
                Dim cmd As New SqlCommand("Select HeadName from Chartofaccount where HeadID='" & sender.Text & "'", cn)
                Dim obj As Object = cmd.ExecuteScalar
                If obj Is Nothing Then
                    DG.CurrentRow.Cells(1).Value = ""
                Else
                    DG.CurrentRow.Cells(1).Value = obj.ToString
                End If
            Else
                Dim oldval1 As String
                Dim newval1 As String

                If DG.CurrentCell.ColumnIndex <> 3 Then Exit Sub
                If Asc(e.KeyChar) <> 8 Then
                    oldval1 = Strings.Left(sender.Text, Len(sender.Text) - Len(sender.SelectedText))
                    newval1 = oldval1 & e.KeyChar
                    Dim a As Integer
                    For a = 0 To ListBox2.Items.Count - 1
                        If LCase(Strings.Left(ListBox2.GetItemText(ListBox2.Items(a)), Len(newval1))) = LCase(newval1) Then
                            sender.Text = ListBox2.GetItemText(ListBox2.Items(a))
                            sender.SelectionStart = Len(newval1)
                            sender.SelectionLength = Len(sender.Text) - Len(newval1)
                            Exit For
                        End If
                    Next
                    e.Handled = True
                Else
                End If
                Dim cmd As New SqlCommand("Select SubID from Subsidiary where Subname=N'" & sender.Text & "'", cn)
                Dim obj As Object = cmd.ExecuteScalar
                If obj Is Nothing Then
                    DG.CurrentRow.Cells(2).Value = ""
                    'DG.CurrentRow.Cells(2).Visible = True

                Else
                    DG.CurrentRow.Cells(2).Value = obj.ToString

                End If

            End If
            ' If Asc(e.KeyChar) <> 8 Then
            'e.KeyChar = ""
            ' End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Key(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = False
    End Sub

    Sub Key2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If DG.CurrentCell.ColumnIndex <> 0 Then Exit Sub
        If e.KeyCode = Keys.F1 Then
            'Dim frm As FrmFind
            'Dim frm As New FrmFind("SELECT HEADCODE as 'Head Code',HEADNAME as 'Head Name' FROM CHARTOFACC")
            FrmFind.rw = DG.CurrentCell.RowIndex
            If FrmFind.Visible = True Then Exit Sub
            FrmFind.Show()
        End If
    End Sub
    Sub SHelp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If dg.CurrentCell.RowIndex = dg.CurrentRow.Index Then
            If dg.CurrentCell.ColumnIndex = 2 Then
                If e.KeyCode = Keys.F1 Then
                 
                End If
            End If
        End If
    End Sub
    Sub Key0(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Call txtclear()
        StatusMnu()
        'ChkStatus.BackColor = Color.MediumSeaGreen
        'ChkStatus.Text = "Post"
        'Post = 0
        Module1.Opencn()
        Me.txtVno.Text = Module1.GetNewVNO("VoucherMain", "Vno", Now, "date")
        Flag = 1
    End Sub
  
    Private Sub StatusMnu()
        Me.ToolStripMenuEdit.Enabled = Not Me.ToolStripMenuEdit.Enabled
        Me.NewToolStripMenuItem.Enabled = Not Me.NewToolStripMenuItem.Enabled
        Me.ToolStripMenuItemUndo.Enabled = Not Me.ToolStripMenuItemUndo.Enabled
        Me.ToolStripMenuSave.Enabled = Not Me.ToolStripMenuSave.Enabled
        Me.DeleteToolStripMenuItem.Enabled = Not Me.DeleteToolStripMenuItem.Enabled
        Me.DG.ReadOnly = Not DG.ReadOnly
        Me.TxtDesc.ReadOnly = Not Me.TxtDesc.ReadOnly
        Me.TxtNarration.ReadOnly = Not Me.TxtNarration.ReadOnly
        Me.txtVno.ReadOnly = Not Me.txtVno.ReadOnly
        Me.DtDate.Enabled = Not Me.DtDate.Enabled
        Me.ChkStatus.Enabled = Not Me.ChkStatus.Enabled
        ' Me.TxtRece.ReadOnly = Me.TxtRece.ReadOnly
        'Me.TxtPaid.ReadOnly = Not Me.TxtPaid.ReadOnly
        'Me.TxtCheque.ReadOnly = Me.TxtCheque.ReadOnly

    End Sub

    Private Sub ToolStripMenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuSave.Click
        If DG.Rows(0).Cells(0).Value = "" Then
            MsgBox("Please enter values in Grid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Alert")
            Exit Sub
        End If
        If Me.LblCr.Text <> Me.LblDr.Text Then
            MsgBox("The Amount on Dr side are not equal to credit amount Please ballance it.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Alert")
            Exit Sub
        End If
        Call Save()
        
    End Sub
    Sub Save()
        Try

            Trans = cn.BeginTransaction


            Dim cmdSave As New SqlCommand
            cmdSave.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave.Connection = cn
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "InsertUpdateVMain"
            cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vno").Value = Me.txtVno.Text
            cmdSave.Parameters.Add("@Vtype", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vtype").Value = Me.GroupBox1.Text
            cmdSave.Parameters.Add("@Date", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@Date").Value = Me.DtDate.Value.Date
            cmdSave.Parameters.Add("@descr", SqlDbType.NVarChar)
            cmdSave.Parameters("@descr").Value = Me.TxtDesc.Text
            cmdSave.Parameters.Add("@UserID", SqlDbType.Int)
            cmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text
            cmdSave.Parameters.Add("@CompanyID", SqlDbType.Int)
            cmdSave.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text
            cmdSave.Parameters.Add("@WName", SqlDbType.VarChar)
            cmdSave.Parameters("@WName").Value = Frm.WName.Text
            cmdSave.Parameters.Add("@PID", SqlDbType.VarChar)
            cmdSave.Parameters("@PID").Value = Frm.LblPeriod.Text
            cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave.Parameters("@Remarks").Value = Me.TxtNarration.Text
            cmdSave.Parameters.Add("@VKey", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@VKey").Value = Me.DtDate.Value.Date.AddDays(3)
            cmdSave.Parameters.Add("@VPost", SqlDbType.Bit)
            cmdSave.Parameters("@VPost").Value = Post

            cmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
            cmdSave.Parameters("@Flag").Value = Flag

            ''''''''''''@Received Varchar(50)
            ''@paid varchar(50)
            ''''@Cheque varchar(50)

            cmdSave.Parameters.Add("@Received", SqlDbType.NVarChar)
            cmdSave.Parameters("@Received").Value = Me.TxtRece.Text

            cmdSave.Parameters.Add("@paid", SqlDbType.NVarChar)
            cmdSave.Parameters("@paid").Value = Me.TxtPaid.Text

            cmdSave.Parameters.Add("@Cheque", SqlDbType.NVarChar)
            cmdSave.Parameters("@Cheque").Value = Me.TxtCheque.Text

            ' MsgBox(Me.DtDate.Value.AddDays(3))


            If Flag = 1 Then
                cmdSave.ExecuteNonQuery()
                GridSave()
                Trans.Commit()
                Dim frmm As New FrmBox("Your Record has been saved successfully..")
                frmm.ShowDialog()
            Else
                If EditFlag = False Then
                    MsgBox("Sorry :  you cannot do entry on wrong date..", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                    Exit Sub

                End If

                cmdSave.ExecuteNonQuery()
                DeleteGrid()
                GridSave()
                Trans.Commit()
                Dim frmm As New FrmBox("Your Record has been Updated successfully..")
                frmm.ShowDialog()
            End If

            Module1.DatasetFill("Select * from VoucherMain where Vtype=N'" & GroupBox1.Text & "' and CompanyID=" & Frm.LBCompanyID.Text & " and PID=N'" & Frm.LblPeriod.Text & "'", "VoucherMain")
            Call txtfill()
            StatusMnu()


        Catch ex As Exception
            Trans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub DeleteGrid()
        Dim cmdDelete As New SqlCommand

        '  If cn.State = ConnectionState.Closed Then cn.Open()
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteDetail"
        cmdDelete.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdDelete.Parameters("@Vno").Value = Me.txtVno.Text
        cmdDelete.ExecuteNonQuery()

    End Sub

    Sub GridSave()
        '   Try


        Dim a As Integer
        For a = 0 To DG.Rows.Count - 2
            Dim cmdSave As New SqlCommand
            cmdSave.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave.Connection = cn
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "SaveDetail"
            cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vno").Value = Me.txtVno.Text
            ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
            cmdSave.Parameters.Add("@HeadID", SqlDbType.Char)
            cmdSave.Parameters("@HeadID").Value = DG.Rows(a).Cells(0).Value
            cmdSave.Parameters.Add("@SubID", SqlDbType.BigInt)
            cmdSave.Parameters("@SubID").Value = (IIf(IsNothing(DG.Rows(a).Cells(2).Value) = True, 0, DG.Rows(a).Cells(2).Value))
            cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave.Parameters("@Remarks").Value = (IIf(IsNothing(DG.Rows(a).Cells(4).Value) = True, "Nill", DG.Rows(a).Cells(4).Value))
            cmdSave.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
            cmdSave.Parameters("@ChequeNo").Value = (IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
            cmdSave.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@ChequeDate").Value = (IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
            cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
            cmdSave.Parameters("@Dr").Value = DG.Rows(a).Cells(7).Value
            cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
            cmdSave.Parameters("@Cr").Value = DG.Rows(a).Cells(8).Value


            cmdSave.ExecuteNonQuery()

        Next


        '  Catch ex As Exception
        'MsgBox(ex.Message)
        'Trans.Rollback()

        'End Try


    End Sub
    Sub txtclear()
        Me.TxtNarration.Text = ""
        Me.txtVno.Text = ""
        Me.TxtDesc.Text = ""
        Me.TxtPaid.Text = ""
        Me.TxtRece.Text = ""
        Me.TxtCheque.Text = ""
        Me.DtDate.Value = Now
        DG.Rows.Clear()
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
    End Sub
    Private Sub DG_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Try
            If e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
                Call CalcTotal()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItemUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemUndo.Click
        Call StatusMnu()
        Call txtfill()
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub ToolStripMenuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuEdit.Click
        Flag = 0
        StatusMnu()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VoucherMain").Rows.Count - 1
        Call TxtFill()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then
            MsgBox("You are on the first record...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        cnt = cnt - 1
        Call TxtFill()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        Call TxtFill()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VoucherMain").Rows.Count - 1 Then
            MsgBox("You are on the Last record...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        cnt = cnt + 1
        Call txtfill()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Module1.DatasetFill("Select * from VuGl where Vno=N'" & Me.txtVno.Text & "' order by Cr", "GLReport")
        FrmReport.Show()
        FrmReport.str2 = Me.LBlWords.Text
        FrmReport.TopMost = True
    End Sub

   
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If (MsgBox("Are you Sure you want to delete?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                Module1.DeleteRecord("VoucherMain", "Vno = '" & txtVno.Text.Trim() & "'")
                Module1.DatasetFill("Select * from VoucherMain", "VoucherMain")
                If cnt > 0 Then
                    cnt = cnt - 1
                End If
                Call txtfill()
                ' StatusMnu()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class
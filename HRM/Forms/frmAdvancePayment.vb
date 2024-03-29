Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmAdvancePayment
    Dim Wait As Boolean
    Dim EditValue As Integer
    Dim Updated As Boolean
    Dim cnt As Integer
    Dim Str As String
    Dim z As Integer
    Dim actualBalance As Decimal
    Dim calcBalance As Decimal
    Dim CityID As Integer
    Dim CItyBasedID As String
    Dim CashCode As String
    Dim EmployeeCode As String
    Dim AdvPayGivenIDVoucher As String
    Private Sub frmAdvancePayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CItyBasedID = Frm.lbLocationName.Text
        Wait = True

        Module1.DatasetFill("Select EmpID,Name from VuEmp1", "VuEmp1")
        cmbPaymentEmpName.DataSource = ds.Tables("VuEmp1")
        cmbPaymentEmpName.DisplayMember = ("Name")
        cmbPaymentEmpName.ValueMember = ("EmpID")
        cmbPaymentEmpName.SelectedIndex = -1

        Module1.DatasetFill("Select EmpID,Name from VuEmp2", "VuEmp2")
        cmbReceiveEmpName.DataSource = ds.Tables("VuEmp2")
        cmbReceiveEmpName.DisplayMember = ("Name")
        cmbReceiveEmpName.ValueMember = ("EmpID")
        cmbReceiveEmpName.SelectedIndex = -1

        Module1.DatasetFill("Select EmpID,Name from VuEmp3", "VuEmp3")
        cmbSearchEmpName.DataSource = ds.Tables("VuEmp3")
        cmbSearchEmpName.DisplayMember = ("Name")
        cmbSearchEmpName.ValueMember = ("EmpID")
        cmbSearchEmpName.SelectedIndex = -1

        Module1.DatasetFill("Select CashCode,EmployeeCode from Impheads where CompanyID = " & Frm.LBCompanyID.Text & "", "Impheads")
        CashCode = ds.Tables("Impheads").Rows(0).Item("CashCode")
        EmployeeCode = ds.Tables("Impheads").Rows(0).Item("EmployeeCode")

        dtPaymentDate.Value = Now
        dtFromRecieve.Value = Now
        dtToRecieve.Value = Now
        dtRecieveDate.Value = Now
        dtFromSearch.Value = Now
        dtToSearch.Value = Now


        Wait = False
        Updated = False
        EditValue = 0
        Call fill()
        lbMassageReceive.Text = ""

        'If Frm.GID.Text <= 2 Then
        '    CM.Enabled = True
        '    CMRecieve.Enabled = True
        '    CMSearch.Enabled = True
        'Else
        '    CM.Enabled = False
        '    CMRecieve.Enabled = False
        '    CMSearch.Enabled = False
        'End If
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
            Module1.CMStatusDisable(CMSearch)
        End If
    End Sub

#Region "ADVANCE PAYMENT GIVEN................."

#Region "FUNCTIONS"

    Sub IDPICKER()
        Module1.DatasetFill("Select * from EmpAdvancePaymentGiven", "EmpAdvancePaymentGiven")
        cmd.CommandText = "Select isnull(Max(APGID),0) from EmpAdvancePaymentGiven"
        lbID.Text = cmd.ExecuteScalar + 1

    End Sub

    Sub Status()
        dtPaymentDate.Enabled = Not dtPaymentDate.Enabled
        cmbPaymentEmpName.Enabled = Not cmbPaymentEmpName.Enabled
        txtPaidAmount.ReadOnly = Not txtPaidAmount.ReadOnly
        txtPaidRemarks.ReadOnly = Not txtPaidRemarks.ReadOnly
    End Sub
    Sub CMStatus()
        TSAdd.Enabled = Not TSAdd.Enabled
        TSSave.Enabled = Not TSSave.Enabled
        TSUndo.Enabled = Not TSUndo.Enabled
        TSUpdate.Enabled = Not TSUpdate.Enabled
        TSDelete.Enabled = Not TSDelete.Enabled
        TSClose.Enabled = Not TSClose.Enabled
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        dtPaymentDate.Value = Now
        cmbPaymentEmpName.SelectedIndex = -1
        txtDepartment.Text = ""
        txtJob.Text = ""
        txtBasicSalary.Text = ""
        txtPaidAmount.Text = ""
        txtPaidRemarks.Text = ""
    End Sub
    Sub fill()
        Try
            EditValue = 0
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from VuEmpAdvancePaymentGiven", "VuEmpAdvancePaymentGiven")
            lbID.Text = ds.Tables("VuEmpAdvancePaymentGiven").Rows(cnt).Item(0)
            cmbPaymentEmpName.Text = ds.Tables("VuEmpAdvancePaymentGiven").Rows(cnt).Item(1)
            dtPaymentDate.Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(cnt).Item(2)
            txtPaidAmount.Text = ds.Tables("VuEmpAdvancePaymentGiven").Rows(cnt).Item(3)
            txtPaidRemarks.Text = ds.Tables("VuEmpAdvancePaymentGiven").Rows(cnt).Item(4)
        Catch ex As Exception
            Clear()
        End Try
    End Sub
    Sub check()
        Dim abc As Integer
        Dim aziz As Integer
        If EditValue = 1 Then
            Module1.DatasetFill("Select * from EmpAdvancePaymentGiven", "EmpAdvancePaymentGiven")
            abc = ds.Tables("EmpAdvancePaymentGiven").Rows(cnt).Item("Remaining")
            If abc = 0 Then
                aziz = 0
            Else
                aziz = abc
            End If
        Else
            aziz = 0
        End If
    End Sub
    Sub SaveUpdateAdvancePaymentGiven()
        If EditValue = 0 Then
            IDPICKER()
        End If
        AdvPayGivenIDVoucher = "Emp" & "-" & "AdvGvn" & "-" & lbID.Text
        Try
            Trans = cn.BeginTransaction()
            Dim cmdsave As New SqlCommand
            cmdsave.Transaction = Trans
            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateAdvancePaymentGiven"
            cmdsave.Connection = cn
            cmdsave.Parameters.Add("@APGID", SqlDbType.Int).Value = Me.lbID.Text
            cmdsave.Parameters.Add("@EmpID", SqlDbType.Int).Value = Me.cmbPaymentEmpName.SelectedValue
            cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtPaymentDate.Value.Date.ToString
            cmdsave.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Me.txtPaidAmount.Text
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtPaidRemarks.Text
            cmdsave.Parameters.Add("@Remaining", SqlDbType.Decimal).Value = Me.txtPaidAmount.Text
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CItyBasedID & "-" & lbID.Text
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If EditValue = 0 Then
                Module1.InsertRecord("VoucherMain", "'" & AdvPayGivenIDVoucher & "','Salary Invoice','" & dtPaymentDate.Value.Date.ToString & "',0,'From AdvancePayment'," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",'" & Frm.WName.Text & "','" & Frm.LblPeriod.Text & "','Nil','" & dtPaymentDate.Value.AddDays(0) & "','Nil','Nil','Nil'", Trans)
                Module1.InsertRecord("VoucherDetail", "'" & AdvPayGivenIDVoucher & "','" & EmployeeCode & "'," & cmbPaymentEmpName.SelectedValue & ",'Salary Invoice',' ','01/01/1900'," & txtPaidAmount.Text & ",0", Trans)
                Module1.InsertRecord("VoucherDetail", "'" & AdvPayGivenIDVoucher & "','" & CashCode & "'," & cmbPaymentEmpName.SelectedValue & ",'Salary Invoice',' ','01/01/1900',0," & txtPaidAmount.Text & "", Trans)
                Trans.Commit()
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            Else
                'Module1.InsertRecord("VoucherMain", "'" & AdvPayGivenIDVoucher & "','Salary Invoice','" & dtPaymentDate.Value.Date.ToString & "',0,'From AdvancePayment'," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",'" & Frm.WName.Text & "','" & Frm.LblPeriod.Text & "','Nil','" & dtPaymentDate.Value.AddDays(0) & "','Nil','Nil','Nil'", Trans)
                Module1.UpdateRecord("VoucherMain", "VType='Salary Invoice',[Date]='" & dtPaymentDate.Value.Date.ToString & "',VPost=0,descr='From AdvancePayment',UserID=" & Frm.LbUserID.Text & ",CompanyID=" & Frm.LBCompanyID.Text & ",WName='" & Frm.WName.Text & "',PID='" & Frm.LblPeriod.Text & "',Remarks='Nil',VKey='" & dtPaymentDate.Value.Date.AddDays(0) & "',Received='Nil',paid='Nil',Cheque='Nil'", "Vno='" & AdvPayGivenIDVoucher & "'", Trans)
                'If cn.State = ConnectionState.Closed Then cn.Open()
                Module1.DeleteRecord("VoucherDetail", "Vno='" & AdvPayGivenIDVoucher & "'")
                'If cn.State = ConnectionState.Closed Then cn.Open()
                Module1.InsertRecord("VoucherDetail", "'" & AdvPayGivenIDVoucher & "','" & EmployeeCode & "'," & cmbPaymentEmpName.SelectedValue & ",'Salary Invoice',' ','01/01/1900'," & txtPaidAmount.Text & ",0", Trans)
                Module1.InsertRecord("VoucherDetail", "'" & AdvPayGivenIDVoucher & "','" & CashCode & "'," & cmbPaymentEmpName.SelectedValue & ",'Salary Invoice',' ','01/01/1900',0," & txtPaidAmount.Text & "", Trans)
                Trans.Commit()
                Call fill()

                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                EditValue = 0
            End If
            Call CMStatus()
            Call Status()
        Catch ex As Exception
            'Trans.Rollback()
            'MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "ACCOUNT SECTION ENTRY"

    Sub SaveVoucher()
        If cn.State = ConnectionState.Closed Then cn.Open()
        Try
            Trans = cn.BeginTransaction
            Dim cmdSave As New SqlCommand
            cmdSave.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave.Connection = cn
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "InsertUpdateVMain"
            cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vno").Value = lbID.Text
            cmdSave.Parameters.Add("@Vtype", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vtype").Value = "Advance Payment Invoice"
            cmdSave.Parameters.Add("@Date", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@Date").Value = Me.dtPaymentDate.Value.Date
            cmdSave.Parameters.Add("@descr", SqlDbType.NVarChar)
            cmdSave.Parameters("@descr").Value = "Nil"
            cmdSave.Parameters.Add("@UserID", SqlDbType.Int)
            cmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text
            cmdSave.Parameters.Add("@CompanyID", SqlDbType.Int)
            cmdSave.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text
            cmdSave.Parameters.Add("@WName", SqlDbType.VarChar)
            cmdSave.Parameters("@WName").Value = Frm.WName.Text
            cmdSave.Parameters.Add("@PID", SqlDbType.VarChar)
            cmdSave.Parameters("@PID").Value = Frm.LblPeriod.Text
            cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave.Parameters("@Remarks").Value = Me.txtPaidRemarks.Text
            cmdSave.Parameters.Add("@VKey", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@VKey").Value = Me.dtPaymentDate.Value.Date.AddDays(0)
            cmdSave.Parameters.Add("@VPost", SqlDbType.Bit)
            cmdSave.Parameters("@VPost").Value = 0

            cmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
            cmdSave.Parameters("@Flag").Value = EditValue

            cmdSave.Parameters.Add("@Received", SqlDbType.NVarChar)
            cmdSave.Parameters("@Received").Value = "Nil"

            cmdSave.Parameters.Add("@paid", SqlDbType.NVarChar)
            cmdSave.Parameters("@paid").Value = "Nil"

            cmdSave.Parameters.Add("@Cheque", SqlDbType.NVarChar)
            cmdSave.Parameters("@Cheque").Value = "Nil"

            ' MsgBox(Me.DtDate.Value.AddDays(3))


            If EditValue = 0 Then
                cmdSave.ExecuteNonQuery()
                GridSave()
                Trans.Commit()
            Else
                cmdSave.ExecuteNonQuery()
                DeleteGrid()
                GridSave()
                Trans.Commit()
            End If

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
        cmdDelete.Parameters("@Vno").Value = AdvPayGivenIDVoucher
        cmdDelete.ExecuteNonQuery()

    End Sub

    Sub GridSave()

        Dim a As Integer
        Dim cmdSave As New SqlCommand
        cmdSave.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave.Connection = cn
        cmdSave.CommandType = CommandType.StoredProcedure
        cmdSave.CommandText = "SaveDetail"
        cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave.Parameters("@Vno").Value = "1"
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave.Parameters("@HeadID").Value = "01-01-0004"
        cmdSave.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave.Parameters("@SubID").Value = Me.cmbPaymentEmpName.SelectedValue
        cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave.Parameters("@Remarks").Value = "From AdvancePayment"
        cmdSave.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave.Parameters("@ChequeNo").Value = "   "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave.Parameters("@Dr").Value = Val(Me.txtPaidAmount.Text)
        cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave.Parameters("@Cr").Value = "0"

        cmdSave.ExecuteNonQuery()
        '''''''''''''''''''''''''


        Dim cmdSave1 As New SqlCommand
        cmdSave1.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave.Connection = cn
        cmdSave.CommandType = CommandType.StoredProcedure
        cmdSave.CommandText = "SaveDetail"
        cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave.Parameters("@Vno").Value = lbID.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave.Parameters("@HeadID").Value = CashCode
        cmdSave.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave.Parameters("@SubID").Value = 0
        cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave.Parameters("@Remarks").Value = "From Advance Payment"
        cmdSave.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave.Parameters("@Dr").Value = 0
        cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave.Parameters("@Cr").Value = Val(Me.txtPaidAmount.Text)

        cmdSave1.ExecuteNonQuery()

    End Sub
#End Region

#Region "CONTEXT MENUS"
    Private Sub TSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSAdd.Click
        Call Status()
        Call CMStatus()
        Call Clear()
    End Sub

    Private Sub TSUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUndo.Click
        Call Status()
        Call CMStatus()
        Call Clear()
        Call fill()
    End Sub

    Private Sub TSSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSave.Click
        If cmbPaymentEmpName.Text = "" Then
            MsgBox("PLEASE SELECT AN EMPLOYEE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول کارمند را انتخاب کنید", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If txtPaidAmount.Text = "" Then
                MsgBox("PLEASE ASSIGN THE VALUE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول مقدار را درج نمائید", MsgBoxStyle.Critical)
                Exit Sub
            Else
                Call SaveUpdateAdvancePaymentGiven()
            End If
        End If
    End Sub

    Private Sub TSUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUpdate.Click
        Call CMStatus()
        Call Status()
        EditValue = 1
    End Sub

    Private Sub TSDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            AdvPayGivenIDVoucher = "Emp" & "-" & "AdvGvn" & "-" & lbID.Text

            cmd.CommandText = " Delete from EmpAdvancePaymentGiven where APGID = " & Me.lbID.Text
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from VoucherMain where Vno = '" & AdvPayGivenIDVoucher & "'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuEmpAdvancePaymentGiven").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Call fill()
            lblMessage.Text = "ریکارد مذکور موفقانه فسخ شد "
        End If
    End Sub
    Private Sub TSClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSClose.Click
        Me.Close()
    End Sub
#End Region

#Region "NAVIGATIONS"
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
        If cnt = ds.Tables("VuEmpAdvancePaymentGiven").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call fill()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuEmpAdvancePaymentGiven").Rows.Count - 1
        Call fill()
    End Sub
#End Region

#Region "EVENTS"
    Private Sub cmbPaymentEmpName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaymentEmpName.SelectedIndexChanged
        Try
            If Wait = False Then
                Module1.DatasetFill("Select DepName,JobTitle,BasicSalary from VuSearchEmp where Name=N'" & cmbPaymentEmpName.Text & "'", "VuSearchEmp")
                txtDepartment.Text = ds.Tables("VuSearchEmp").Rows(0).Item("DepName")
                txtJob.Text = ds.Tables("VuSearchEmp").Rows(0).Item("JobTitle")
                txtBasicSalary.Text = ds.Tables("VuSearchEmp").Rows(0).Item("BasicSalary")
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#End Region


#Region "ADVACNE PAYMENT RECEIVED............"

#Region "FUNCTIONS"
    Sub ClearRecieve()
        dtFromRecieve.Value = Now
        dtToRecieve.Value = Now
        txtEmpName.Text = ""
        txtRemaining.Text = ""
        txtTakenAmount.Text = ""
        txtGivenAmount.Text = ""
        txtRecieveRemarks.Text = ""
        DGRecieveSearch.Rows.Clear()
        lbIDR.Text = "Nothing"
    End Sub
    Sub GridFillRecieve()
        Try
            DGRecieveSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = Str
            If (ds.Tables.Contains("VuEmpAdvancePaymentGiven")) Then
                ds.Tables("VuEmpAdvancePaymentGiven").Clear()
                DGRecieveSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuEmpAdvancePaymentGiven")

            For z = 0 To ds.Tables("VuEmpAdvancePaymentGiven").Rows.Count - 1
                Try

                    DGRecieveSearch.Rows.Add()
                    DGRecieveSearch.Rows(z).Cells(0).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("APGID")
                    DGRecieveSearch.Rows(z).Cells(1).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("dtDate")
                    DGRecieveSearch.Rows(z).Cells(2).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("Amount")
                    DGRecieveSearch.Rows(z).Cells(3).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("Remaining")
                    DGRecieveSearch.Rows(z).Cells(4).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("Remarks")

                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveAdvancePaymentRecieved()
        Dim AdvancePaymentVoucher As String = "Emp" & "-" & "AdvRec" & "-" & lbIDR.Text
        Try
            Trans = cn.BeginTransaction()
            Dim cmdsave As New SqlCommand
            cmdsave.Transaction = Trans
            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertAdvancePaymentRecieved"
            cmdsave.Connection = cn
            cmdsave.Parameters.Add("@APGID", SqlDbType.Int).Value = Me.lbIDR.Text
            cmdsave.Parameters.Add("@EmpID", SqlDbType.Int).Value = Me.cmbReceiveEmpName.SelectedValue
            cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtRecieveDate.Value.Date.ToString
            cmdsave.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Me.txtGivenAmount.Text
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRecieveRemarks.Text

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            Module1.InsertRecord("VoucherMain", "'" & AdvancePaymentVoucher & "','Advance Payment Receive Invoice','" & dtRecieveDate.Value.Date.ToString & "',0,' '," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",'" & Frm.WName.Text & "','" & Frm.LblPeriod.Text & "','Nil','" & dtRecieveDate.Value.AddDays(0) & "','Nil','Nil','Nil'", Trans)
            Module1.InsertRecord("VoucherDetail", "'" & AdvancePaymentVoucher & "','" & CashCode & "'," & cmbReceiveEmpName.SelectedValue & ",'Advance Payment Invoice','Advance Payment Receive Invoice','01/01/1900'," & txtGivenAmount.Text & ",0", Trans)
            Module1.InsertRecord("VoucherDetail", "'" & AdvancePaymentVoucher & "','" & EmployeeCode & "','" & cmbReceiveEmpName.SelectedValue & "','AdvancePayment Invoice','Advance Payment Receive Invoice','01/01/1900',0," & txtGivenAmount.Text & "", Trans)

            Module1.UpdateRecord("EmpAdvancePaymentGiven", "Remaining=" & txtRemaining.Text & "", "APGID = " & lbIDR.Text & "", Trans)
            Trans.Commit()
            Module1.Opencn()
            'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
            Call ClearRecieve()
            cmbReceiveEmpName.SelectedIndex = -1
            lbMassageReceive.Text = "ریکارد شما موفقانه ثبت گردید"

        Catch ex As Exception

        End Try
    End Sub
    Sub calc()
        Dim abc As Decimal
        abc = calcBalance - Val(txtGivenAmount.Text)
        txtRemaining.Text = abc
    End Sub
#End Region

#Region "CONTEXT MENUS"
    Private Sub TSRecieveUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSRecieveUndo.Click
        Call ClearRecieve()
        cmbReceiveEmpName.SelectedIndex = -1
    End Sub

    Private Sub TSRecieveSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSRecieveSave.Click
        If txtEmpName.Text = "" Then
            MsgBox("PLEASE INSERT AN EMPLOYEE NAME FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول اسم کارمند را درج کنید", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If txtGivenAmount.Text = "" Then
                MsgBox("PLEASE ASSIGN THE VALUE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول مقدار را درج نمائید", MsgBoxStyle.Critical)
                Exit Sub
            Else
                Call SaveAdvancePaymentRecieved()
            End If
        End If
    End Sub

    Private Sub TSRecieveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSRecieveClose.Click
        Me.Close()
    End Sub
#End Region

#Region "EVENTS"
    Private Sub btnRecieveSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecieveSearch.Click
        lbMassageReceive.Text = ""
        If cmbReceiveEmpName.Text = "" Then
            MsgBox("PLEASE SELECT AN EMPLOYEE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول کارمند را انتخاب کنید", MsgBoxStyle.Critical)
            Exit Sub
        Else
            Str = "Select APGID,dtDate,Amount,Remarks,Remaining from VuEmpAdvancePaymentGiven where Name = N'" & cmbReceiveEmpName.Text & "' And dtDate between '" & dtFromRecieve.Value.Date.ToString & "' And '" & dtToRecieve.Value.Date.ToString & "'and Remaining > 0"
            Call GridFillRecieve()
        End If
    End Sub
    Private Sub DGRecieveSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGRecieveSearch.CellDoubleClick
        Try

            txtEmpName.Text = cmbReceiveEmpName.Text
            lbIDR.Text = DGRecieveSearch.CurrentRow.Cells(0).Value
            txtTakenAmount.Text = DGRecieveSearch.CurrentRow.Cells(2).Value
            txtRemaining.Text = DGRecieveSearch.CurrentRow.Cells(3).Value
            'txtGivenAmount.Text = DGRecieveSearch.CurrentRow.Cells(3).Value

            actualBalance = txtRemaining.Text
            calcBalance = txtRemaining.Text

            dtFromRecieve.Value = Now
            dtToRecieve.Value = Now
            DGRecieveSearch.Rows.Clear()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtGivenAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGivenAmount.TextChanged
        If txtGivenAmount.Text = "" Then
            txtRemaining.Text = actualBalance
        Else
            Call calc()
        End If

        If txtRemaining.Text < 0 Then
            MsgBox("INVALID AMOUNT" & Chr(13) & " " & Chr(13) & "مقدار درج شده صحیح نیست", MsgBoxStyle.Information)
            txtRemaining.Text = actualBalance
            txtGivenAmount.Text = ""
        End If
    End Sub
    Private Sub cmbReceiveEmpName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReceiveEmpName.SelectedIndexChanged
        Call ClearRecieve()
    End Sub
#End Region

#End Region


#Region "SEARCH...................."

#Region "FUNCTIONS"
    Sub GridFillSearch()
        Try
            DGSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = Str
            If (ds.Tables.Contains("VuEmpAdvancePaymentGiven")) Then
                ds.Tables("VuEmpAdvancePaymentGiven").Clear()
                DGSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuEmpAdvancePaymentGiven")

            For z = 0 To ds.Tables("VuEmpAdvancePaymentGiven").Rows.Count - 1
                Try

                    DGSearch.Rows.Add()
                    DGSearch.Rows(z).Cells(0).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("APGID")
                    DGSearch.Rows(z).Cells(1).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("dtDate")
                    DGSearch.Rows(z).Cells(2).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("Amount")
                    DGSearch.Rows(z).Cells(3).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("Remaining")
                    DGSearch.Rows(z).Cells(4).Value = ds.Tables("VuEmpAdvancePaymentGiven").Rows(z).Item("Remarks")

                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GridFillRecievedAmountSearch()
        Try
            DGAmount.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = Str
            If (ds.Tables.Contains("VuEmpAdvancePaymentRecieved")) Then
                ds.Tables("VuEmpAdvancePaymentRecieved").Clear()
                DGAmount.Rows.Clear()
            End If
            da.Fill(ds, "VuEmpAdvancePaymentRecieved")

            For z = 0 To ds.Tables("VuEmpAdvancePaymentRecieved").Rows.Count - 1
                Try

                    DGAmount.Rows.Add()
                    DGAmount.Rows(z).Cells(0).Value = ds.Tables("VuEmpAdvancePaymentRecieved").Rows(z).Item("APGID")
                    DGAmount.Rows(z).Cells(1).Value = ds.Tables("VuEmpAdvancePaymentRecieved").Rows(z).Item("dtDate")
                    DGAmount.Rows(z).Cells(2).Value = ds.Tables("VuEmpAdvancePaymentRecieved").Rows(z).Item("Amount")
                    DGAmount.Rows(z).Cells(3).Value = ds.Tables("VuEmpAdvancePaymentRecieved").Rows(z).Item("Remarks")

                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "EVENTS"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cmbSearchEmpName.Text = "" Then
            MsgBox("PLEASE SELECT AN EMPLOYEE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول کارمند را انتخاب کنید", MsgBoxStyle.Critical)
            Exit Sub
        Else
            Str = "Select APGID,dtDate,Amount,Remarks,Remaining from VuEmpAdvancePaymentGiven where Name = N'" & cmbSearchEmpName.Text & "' And dtDate between '" & dtFromSearch.Value.Date.ToString & "' And '" & dtToSearch.Value.Date.ToString & "' and Remaining > 0"
            Call GridFillSearch()
        End If
    End Sub

    Private Sub DGSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellDoubleClick
        DGAmount.Visible = True
        Str = "Select APGID,dtDate,Amount,Remarks from VuEmpAdvancePaymentRecieved where APGID = " & DGSearch.CurrentRow.Cells(0).Value & ""
        Call GridFillRecievedAmountSearch()
        If DGSearch.Height = 138 Then
            Exit Sub
        Else
            DGSearch.Height = DGSearch.Height - 250
        End If
    End Sub
    Private Sub cmbSearchEmpName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchEmpName.SelectedIndexChanged
        dtFromSearch.Value = Now
        dtToSearch.Value = Now
        DGAmount.Rows.Clear()
        DGSearch.Rows.Clear()
        DGAmount.Visible = False
        DGSearch.Height = 388
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
#End Region

#End Region


#Region "KEY PRESS FOR ALL TAB CONTROLS"
    Private Sub txtPaidAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaidAmount.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtGivenAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGivenAmount.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtPaidRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaidRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtPaidRemarks.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRecieveRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecieveRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtRecieveRemarks.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region


    Private Sub TC1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TC1.SelectedIndexChanged
        If TC1.SelectedIndex = 0 Then
            TSUndo.PerformClick()
            lblMessage.Text = ""
        ElseIf TC1.SelectedIndex = 1 Then
            TSRecieveUndo.PerformClick()
            lbMassageReceive.Text = ""
        ElseIf TC1.SelectedIndex = 2 Then
            cmbSearchEmpName.SelectedIndex = -1
            dtFromSearch.Value = Now
            dtToSearch.Value = Now
            DGAmount.Rows.Clear()
            DGSearch.Rows.Clear()
            DGAmount.Visible = False
            DGSearch.Height = 388
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Me.Close()
    End Sub

    Private Sub cmbPaymentEmpName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPaymentEmpName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbReceiveEmpName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbReceiveEmpName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbSearchEmpName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSearchEmpName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

 
End Class
Imports System.Data.SqlClient
Imports LanguageSelector
Public Class frmSalaries
    Dim a As Integer
    Dim z As Integer
    Dim Check As Boolean
    Dim EditCombo As Boolean
    Dim editdate As Boolean
    Dim Str1 As String
    Dim Str2 As String
    Dim Str3 As String
    Dim SplitTheDateForAziz() As String
    Dim AdvancePay As Decimal
    Public AdvancePaymentID As Decimal
    Public AdvancePaymentRemark As String
    Public AdvancePaymentRemaining As Decimal
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim SalaryChecker As Boolean
    Dim CheckerYear As String
    Dim CheckerMonth As String
    Dim CashCode As String
    Dim EmployeeCode As String
    Dim NoOfWorkingDays As Integer
    Dim OneDaySalary As Decimal

    Private Sub frmSalaries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Check = False
        cmd.Connection = cn


        Module1.DatasetFill("Select EmpID,Name from EmpPerInfo", "EmpPerInfo")
        cmbEmpName.DataSource = ds.Tables("EmpPerInfo")
        cmbEmpName.DisplayMember = ("Name")
        cmbEmpName.ValueMember = ("EmpID")
        cmbEmpName.SelectedIndex = -1
        Check = True
        Call Clear()
        lbMassageSalaryChecker.Text = ""
        PB.Visible = False
        'If Frm.GID.Text <= 2 Then
        '    CM.Enabled = True
        '    CMSearch.Enabled = True
        'Else
        '    CM.Enabled = False
        '    CMSearch.Enabled = False
        'End If
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region "MAIN...................."

#Region "FUNCTIONS"

    Sub IDPICKER()
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmd.CommandText = "Select isnull(Max(SalID),0) from MonthlySal"
        txtSalID.Text = cmd.ExecuteScalar + 1
    End Sub

    Sub DateSplite()
        Dim a As String = Me.dtDate.Value
        'Me.Label3.Text = Me.dtDate.Text
        Dim i As String = Me.dtDate.Text
        Me.SplitTheDateForAziz = i.Split(New Char() {",", " "})
        For z = 0 To SplitTheDateForAziz.GetUpperBound(0)

        Next
        Me.txtMonth.Text = SplitTheDateForAziz(2)
        Me.txtYear.Text = SplitTheDateForAziz(5)
    End Sub

    Sub CMStatus()
        TSAdd.Enabled = Not TSAdd.Enabled
        TSSave.Enabled = Not TSSave.Enabled
        TSUndo.Enabled = Not TSUndo.Enabled
        TSUpdate.Enabled = Not TSUpdate.Enabled
        TSDelete.Enabled = Not TSDelete.Enabled
    End Sub

    Sub Status()
        cmbEmpName.Enabled = Not cmbEmpName.Enabled
        Panel1.Enabled = Not Panel1.Enabled
        cmbType.Enabled = Not cmbType.Enabled
        txtAmount.ReadOnly = Not txtAmount.ReadOnly
        btnAddNew.Enabled = Not btnAddNew.Enabled
        chbAdvancePayment.Enabled = Not chbAdvancePayment.Enabled
        lblMessage.Text = ""

    End Sub

    Sub Clear()
        Module1.Opencn()
        lblMessage.Text = ""

        'cmd.Connection = cn
        'cmd.CommandText = "Select isnull(Max(SalID),0) from MonthlySal"
        'txtSalID.Text = cmd.ExecuteScalar + 1

        cmbEmpName.SelectedValue = -1
        txtBasicSalary.Text = ""
        txtNetPay.Text = ""
        txtAdvancePayment.Text = ""
        txtAbsent.Text = ""
        txtAbsentMoney.Text = ""

        RBAll.Checked = False
        RBDed.Checked = False
        txtAmount.Text = ""
        DgAllowances.Rows.Clear()
        txtAllTotal.Text = ""
        DgDeduction.Rows.Clear()
        txtDedTotal.Text = ""
        EditCombo = False

        dtDate.Value = Now

        Module1.DeleteRecord("AllTemp")
        Module1.DeleteRecord("DedTemp")

        Label6.Text = "There is no ID"
        txtMonth.Text = ""
        txtYear.Text = ""
        chbAdvancePayment.Checked = False

    End Sub

    Sub Allowances()
        Module1.Opencn()
        cmbType.DataSource = Nothing
        cmbType.Items.Clear()
        Module1.DatasetFill("Select * from AllowancesMain", "AllowancesMain")
        cmbType.DataSource = ds.Tables("AllowancesMain")
        cmbType.DisplayMember = ("AllType")
        cmbType.ValueMember = ("AllID")
        cmbType.SelectedIndex = -1

        cmd.CommandText = "Select isnull(Max(AllID),0) from AllowancesMain"
        Label6.Text = cmd.ExecuteScalar + 1
    End Sub

    Sub Deduction()
        Module1.Opencn()
        cmbType.DataSource = Nothing
        cmbType.Items.Clear()
        Module1.DatasetFill("Select * from DeductionMain", "DeductionMain")
        cmbType.DataSource = ds.Tables("DeductionMain")
        cmbType.DisplayMember = ("DedType")
        cmbType.ValueMember = ("DedID")
        cmbType.SelectedIndex = -1

        cmd.CommandText = "Select isnull(Max(DedID),0) from DeductionMain"
        Label6.Text = cmd.ExecuteScalar + 1
    End Sub

    Sub calcAll()
        Dim Total As Double = 0
        Dim a As Integer
        For a = 0 To DgAllowances.Rows.Count - 1
            Total = Total + Val(DgAllowances.Rows(a).Cells(1).Value)
        Next
        Me.txtAllTotal.Text = Total
    End Sub

    Sub calcDed()
        Dim Total As Double = 0
        Dim a As Integer
        For a = 0 To DgDeduction.Rows.Count - 1
            Total = Total + Val(DgDeduction.Rows(a).Cells(1).Value)
        Next
        Me.txtDedTotal.Text = Total
    End Sub
    Sub calcNet()
        Try

            Dim Total As Double = 0
            Dim aziz As Double = 0
            Total = Total + Val(txtBasicSalary.Text) + Val(txtAllTotal.Text) - Val(txtDedTotal.Text)
            aziz = Total - Val(txtAdvancePayment.Text) - Val(txtAbsentMoney.Text)
            Me.txtNetPay.Text = aziz

        Catch ex As Exception
        End Try
    End Sub

    Sub CheckTextBox()
        If txtAdvancePayment.Text = "" Or txtAdvancePayment.Text = "0" Then
            AdvancePay = 0
        Else
            'If txtAdvancePayment.Text = 0 Then
            '    AdvancePay = 0
            'Else
            AdvancePay = txtAdvancePayment.Text
        End If
        'End If
    End Sub

    'Sub Checktextboxforsave()
    '    If txtAdvancePayment.Text = "" Then
    '        Exit Sub
    '    Else
    '        If txtAdvancePayment.Text = 0 Then
    '            Exit Sub
    '        Else
    '            Module1.InsertRecord("EmpAdvancePaymentRecieved", "APGID,EmpID,dtDate,Amount,Remarks", "" & AdvancePaymentID & "," & cmbEmpName.SelectedValue & ",'" & dtDate.Value.Date.ToString & "'," & txtAdvancePayment.Text & ",N'" & AdvancePaymentRemark & "'")
    '            Module1.UpdateRecord("EmpAdvancePaymentGiven", "Remaining=" & AdvancePaymentRemaining & "", "APGID=" & AdvancePaymentID & "")
    '            Module1.Opencn()
    '        End If
    '    End If
    'End Sub
    'Sub SaveAccount()
    '    Module1.DatasetFill("Select CashCode,EmployeeCode from Impheads where CompanyID = " & Frm.LBCompanyID.Text & "", "Impheads")
    '    CashCode = ds.Tables("Impheads").Rows(0).Item("CashCode")
    '    EmployeeCode = ds.Tables("Impheads").Rows(0).Item("EmployeeCode")
    '    'vCode = ds.Tables("Impheads").Rows(0).Item("vendorSuccode")
    '    Module1.InsertRecord("VoucherMain", "Vno,VType,Date,VPost,descr,UserID,CompanyID,WName,PID,Remarks,VKey,Received,Paid,Cheque", "" & txtSalID.Text & ",'Salary Invoice','" & dtDate.Value.Date.ToString & "',0,'Salary For the Month'," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",'" & Frm.WName.Text & "','" & Frm.LblPeriod.Text & "','Nil','" & dtDate.Value.AddDays(0) & "','Nil','Nil','Nil'")
    '    Module1.InsertRecord("VoucherDetail", "Vno,HeadID,SubID,Remarks,ChequeNo,ChequeDate,Dr,Cr", "" & txtSalID.Text & "," & EmployeeCode & "," & cmbEmpName.SelectedValue & ",'Salary Invoice',' ','01/01/1900'," & txtNetPay.Text & ",0")
    '    Module1.InsertRecord("VoucherDetail", "Vno,HeadID,SubID,Remarks,ChequeNo,ChequeDate,Dr,Cr", "" & txtSalID.Text & "," & CashCode & "," & cmbEmpName.SelectedValue & ",'Salary Invoice',' ','01/01/1900',0," & txtNetPay.Text & "")
    'End Sub

    Sub Save()
        Module1.Opencn()
        Try
            Trans = cn.BeginTransaction()
            Dim x As Integer
            Dim Concatinate As String = CityBasedID & "-" & txtSalID.Text
            Dim AdvancePaymentVoucher As String = "Emp" & "-" & "AdvRecSal" & "-" & AdvancePaymentID
            Dim SalaryIDVoucher As String = "Emp" & "-" & "Salary" & "-" & txtSalID.Text
            Dim MonthVoucher As String = "Salary For The Month Of " & txtMonth.Text
            Dim AdvPaymentMonth As String = "Cut From Salary For The Month Of " & txtMonth.Text
            cmd.Transaction = Trans
            CheckTextBox()
            'Module1.InsertRecord("MonthlySal", "SalID,EmpID,Date,Month,Year,BasicSalary,AdvanceDed,NetPay,CityID,CityBasedID", "'" & txtSalID.Text & "','" & cmbEmpName.SelectedValue & "','" & dtDate.Value.Date.ToString & "',N'" & txtMonth.Text & "','" & txtYear.Text & "','" & txtBasicSalary.Text & "', " & AdvancePay & " ,'" & txtNetPay.Text & "'," & CityID & ",N'" & Concatinate & "'")

            'Module1.InsertRecord("VoucherMain", "Vno,VType,Date,VPost,descr,UserID,CompanyID,WName,PID,Remarks,VKey,Received,Paid,Cheque", "" & txtSalID.Text & ",'Salary Invoice','" & dtDate.Value.Date.ToString & "',0,'Salary For the Month'," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",'" & Frm.WName.Text & "','" & Frm.LblPeriod.Text & "','Nil','" & dtDate.Value.AddDays(0) & "','Nil','Nil','Nil'")

            Module1.InsertRecord("MonthlySal", "'" & txtSalID.Text & "','" & cmbEmpName.SelectedValue & "','" & dtDate.Value.Date.ToString & "',N'" & txtMonth.Text & "','" & txtYear.Text & "','" & txtBasicSalary.Text & "'," & txtAbsent.Text & "," & txtAbsentMoney.Text & "," & AdvancePay & " ,'" & txtNetPay.Text & "'," & CityID & ",N'" & Concatinate & "'", Trans)
            'Trans.Rollback()
            'Exit Sub


            Module1.InsertRecord("VoucherMain", "'" & SalaryIDVoucher & "','Salary Invoice','" & dtDate.Value.Date.ToString & "',0,'" & MonthVoucher & "'," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",'" & Frm.WName.Text & "','" & Frm.LblPeriod.Text & "','Nil','" & dtDate.Value.AddDays(0) & "','Nil','Nil','Nil'", Trans)
            'Trans.Rollback()
            'Exit Sub


            'Module1.InsertRecord("VoucherDetail", "Vno,HeadID,SubID,Remarks,ChequeNo,ChequeDate,Dr,Cr", "" & txtSalID.Text & ",'" & EmployeeCode & "'," & cmbEmpName.SelectedValue & ",'Salary Invoice',' ','01/01/1900'," & txtNetPay.Text & ",0")
            Module1.InsertRecord("VoucherDetail", "'" & SalaryIDVoucher & "','" & EmployeeCode & "'," & cmbEmpName.SelectedValue & ",'Salary Invoice',' ','01/01/1900'," & txtNetPay.Text & ",0", Trans)
            'Trans.Rollback()
            'Exit Sub


            'Module1.InsertRecord("VoucherDetail", "Vno,HeadID,SubID,Remarks,ChequeNo,ChequeDate,Dr,Cr", "" & txtSalID.Text & ",'" & CashCode & "','0','Salary Invoice',' ','01/01/1900',0," & txtNetPay.Text & "")
            Module1.InsertRecord("VoucherDetail", "'" & SalaryIDVoucher & "','" & CashCode & "','" & cmbEmpName.SelectedValue & "','Salary Invoice',' ','01/01/1900',0," & txtNetPay.Text & "", Trans)
            'Trans.Rollback()
            'Exit Sub


            For x = 0 To DgAllowances.Rows.Count - 1
                Module1.InsertRecord("MontlySalAll", " '" & txtSalID.Text & "','" & cmbEmpName.SelectedValue & "','" & dtDate.Value.Date.ToString & "',N'" & txtMonth.Text & "','" & txtYear.Text & "',N'" & DgAllowances.Rows(x).Cells(0).Value & "'," & DgAllowances.Rows(x).Cells(1).Value & "", Trans)
            Next
            For x = 0 To DgDeduction.Rows.Count - 1
                Module1.InsertRecord("MonthlySalDed", " '" & txtSalID.Text & "','" & cmbEmpName.SelectedValue & "','" & dtDate.Value.Date.ToString & "',N'" & txtMonth.Text & "',N'" & txtYear.Text & "',N'" & DgDeduction.Rows(x).Cells(0).Value & "'," & DgDeduction.Rows(x).Cells(1).Value & "", Trans)
            Next

            If txtAdvancePayment.Text = "" Or txtAdvancePayment.Text = "0" Then

            Else
                Module1.InsertRecord("EmpAdvancePaymentRecieved", "" & AdvancePaymentID & "," & cmbEmpName.SelectedValue & ",'" & dtDate.Value.Date.ToString & "'," & txtAdvancePayment.Text & ",N'" & AdvancePaymentRemark & "'", Trans)
                Module1.InsertRecord("VoucherMain", "'" & AdvancePaymentVoucher & "','Advance Payment Recieve Invoice','" & dtDate.Value.Date.ToString & "',0,' '," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",'" & Frm.WName.Text & "','" & Frm.LblPeriod.Text & "','Nil','" & dtDate.Value.AddDays(0) & "','Nil','Nil','Nil'", Trans)
                Module1.InsertRecord("VoucherDetail", "'" & AdvancePaymentVoucher & "','" & CashCode & "'," & cmbEmpName.SelectedValue & ",'Advance Payment Invoice','" & AdvPaymentMonth & "','01/01/1900'," & txtAdvancePayment.Text & ",0", Trans)
                Module1.InsertRecord("VoucherDetail", "'" & AdvancePaymentVoucher & "','" & EmployeeCode & "','" & cmbEmpName.SelectedValue & "','AdvancePayment Invoice','" & AdvPaymentMonth & "','01/01/1900',0," & txtAdvancePayment.Text & "", Trans)
                
            End If

            Module1.UpdateRecord("EmpAdvancePaymentGiven", "Remaining=" & AdvancePaymentRemaining & "", "APGID=" & AdvancePaymentID & "", Trans)
            'Module1.Opencn()

            Module1.DeleteRecord("AllTemp")
            Module1.DeleteRecord("DedTemp")

            Trans.Commit()

            If cn.State = ConnectionState.Closed Then cn.Open()
            Call Clear()
            Call CMStatus()
            Call Status()
            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
        Catch ex As Exception
            'Trans.Rollback()
            'MsgBox(ex.Message)
        End Try
    End Sub

    Sub CheckForExistance()
        Dim m As Integer
        Dim n As Integer
        Dim o As Integer
        Dim abc As String
        Dim mno As String
        Dim xyz As String
        Try
            Module1.DatasetFill("Select * from MonthlySal", "MonthlySal")
            For m = 0 To ds.Tables("MonthlySal").Rows.Count
                abc = ds.Tables("MonthlySal").Rows(m).Item(4)
                Try
                    For n = 0 To ds.Tables("MonthlySal").Rows.Count
                        xyz = ds.Tables("MonthlySal").Rows(n).Item(3)
                        Try
                            For o = 0 To ds.Tables("MonthlySal").Rows.Count
                                mno = ds.Tables("MonthlySal").Rows(o).Item(1)
                                If txtYear.Text = abc And txtMonth.Text = xyz And cmbEmpName.SelectedValue = mno Then
                                    'MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                                    SalaryChecker = True
                                    CheckerMonth = txtMonth.Text
                                    CheckerYear = txtYear.Text
                                    Exit Sub
                                End If
                            Next
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        End Try
        SalaryChecker = False
    End Sub

    Sub AbsentChecker()

        'Module1.DatasetFill("Select Count(StatusID) as Status from AttendenceSheet where StatusID = 2 and EmpID=" & cmbEmpName.SelectedValue & " ", "AttendenceSheet")
        'Module1.DatasetFill("Select Count(StatusID) as Status from AttendenceSheet where StatusID = 2 and EmpID=" & cmbEmpName.SelectedValue & " and month(dtDate) =" & System.DateTime.Now.Month, "AttendanceSheet")
        Module1.DatasetFill("Select Count(StatusID) as Status from AttendenceSheet where StatusID = 2 and EmpID=" & cmbEmpName.SelectedValue & " and month(dtDate) =" & dtDate.Value.Month & " and year(dtDate) =" & dtDate.Value.Year, "AttendanceSheet")
        txtAbsent.Text = ds.Tables("AttendanceSheet").Rows(0).Item(0)
    End Sub

#End Region

#Region " DATA GRID VIEW FUNCTIONS"
    Sub FillAll()
        DgAllowances.Rows.Clear()
        cmd.Connection = cn
        da.SelectCommand = cmd
        cmd.CommandText = "Select * from VuAllTemp where EmpID = '" & cmbEmpName.SelectedValue & "'"
        If (ds.Tables.Contains("VuAllTemp")) Then
            ds.Tables("VuAllTemp").Clear()
            DgAllowances.Rows.Clear()
        End If
        da.Fill(ds, "VuAllTemp")

        For z = 0 To ds.Tables("VuAllTemp").Rows.Count - 1
            Try

                DgAllowances.Rows.Add()
                DgAllowances.Rows(z).Cells(0).Value = ds.Tables("VuAllTemp").Rows(z).Item(1)
                DgAllowances.Rows(z).Cells(1).Value = ds.Tables("VuAllTemp").Rows(z).Item(2)

            Catch ex As Exception
            End Try
        Next
    End Sub
    Sub FillDed()
        DgDeduction.Rows.Clear()
        cmd.Connection = cn
        da.SelectCommand = cmd
        cmd.CommandText = "Select * from VuDedTemp where EmpID = '" & cmbEmpName.SelectedValue & "'"
        If (ds.Tables.Contains("VuDedTemp")) Then
            ds.Tables("VuDedTemp").Clear()
            DgDeduction.Rows.Clear()
        End If
        da.Fill(ds, "VuDedTemp")

        For z = 0 To ds.Tables("VuDedTemp").Rows.Count - 1
            Try

                DgDeduction.Rows.Add(1)
                DgDeduction.Rows(z).Cells(0).Value = ds.Tables("VuDedTemp").Rows(z).Item(1)
                DgDeduction.Rows(z).Cells(1).Value = ds.Tables("VuDedTemp").Rows(z).Item(2)

            Catch ex As Exception
            End Try
        Next
    End Sub
    Sub FillAllowances()
        Try
            DGAll.Rows.Clear()
            Module1.DatasetFill("Select AllowancesName,AllowancesAmount from VuAllowances where SalID = " & DGSearch.CurrentRow.Cells(0).Value & "", "VuAllowances")
            For z = 0 To ds.Tables("VuAllowances").Rows.Count - 1

                DGAll.Rows.Add()
                DGAll.Rows(z).Cells(0).Value = ds.Tables("VuAllowances").Rows(z).Item("AllowancesName")
                DGAll.Rows(z).Cells(1).Value = ds.Tables("VuAllowances").Rows(z).Item("AllowancesAmount")
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub FillDeduction()
        Try
            DGDed.Rows.Clear()
            Module1.DatasetFill("Select DeductionName,DeductionAmount from VuDeduction where SalID = " & DGSearch.CurrentRow.Cells(0).Value & "", "VuDeduction")
            For z = 0 To ds.Tables("VuDeduction").Rows.Count - 1

                DGDed.Rows.Add()
                DGDed.Rows(z).Cells(0).Value = ds.Tables("VuDeduction").Rows(z).Item("DeductionName")
                DGDed.Rows(z).Cells(1).Value = ds.Tables("VuDeduction").Rows(z).Item("DeductionAmount")
            Next

        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "CONTEXT MENUS"
    Private Sub TSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSAdd.Click
        lbMassageSalaryChecker.Text = ""
        PB.Visible = False
        Call CMStatus()
        Call Status()
        Call DateSplite()
    End Sub
    Private Sub TSSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSave.Click
        If cmbEmpName.Text = "" Then
            MsgBox("PLEASE SELECT AN EMPLOYEE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول کارمند را انتخاب کنید", MsgBoxStyle.Critical)
            Exit Sub
        Else
            IDPICKER()
            Module1.DatasetFill("Select CashCode,EmployeeCode from Impheads where CompanyID = " & Frm.LBCompanyID.Text & "", "Impheads")
            CashCode = ds.Tables("Impheads").Rows(0).Item("CashCode")
            EmployeeCode = ds.Tables("Impheads").Rows(0).Item("EmployeeCode")
            Call Save()
        End If
    End Sub
    Private Sub TSUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUndo.Click
        Call Status()
        Call CMStatus()
        Call Clear()
    End Sub
    Private Sub TSClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSClose.Click
        Me.Close()
    End Sub

#End Region

#Region "KEYPRESS AND KEYDOWN BOTH"
    Private Sub txtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If cmbType.DropDownStyle = ComboBoxStyle.DropDown Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            If txtAmount.Text = "" Or cmbType.Text = "" Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If RBAll.Checked.Equals(True) Then
                Module1.InsertRecord("AllTemp", "EmpID,AllName,AllAmount", "'" & cmbEmpName.SelectedValue & "',N'" & cmbType.Text & "',N'" & txtAmount.Text & "'")
                Call FillAll()
                cmbType.SelectedIndex = -1
                txtAmount.Text = ""
            Else
                Module1.InsertRecord("DedTemp", "EmpID,DedName,DedAmount", "'" & cmbEmpName.SelectedValue & "',N'" & cmbType.Text & "',N'" & txtAmount.Text & "'")
                Call FillDed()
                cmbType.SelectedIndex = -1
                txtAmount.Text = ""
            End If
        End If
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
    Private Sub DgDeduction_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgDeduction.KeyDown
        If e.KeyCode = Keys.Delete Then
            Try

                cmd.CommandText = " Delete from DedTemp where DedName = N'" & DgDeduction.CurrentRow.Cells(0).Value & "'"
                cmd.Connection = cn
                cmd.ExecuteNonQuery()
                Module1.DatasetFill("Select * from DedTemp", "DedTemp")
                Call FillDed()
                Call calcDed()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub DgAllowances_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgAllowances.KeyDown
        If e.KeyCode = Keys.Delete Then
            Try
                'Dim row As DataGridViewSelectedRowCollection = DgAllowances.SelectedRows

                'Dim i As Integer = DgAllowances.Rows.IndexOf(row(0))
                'MsgBox(i.ToString)
                cmd.CommandText = " Delete from AllTemp where AllName = N'" & DgAllowances.CurrentRow.Cells(0).Value & "'"
                ''cmd.CommandText = " Delete from AllTemp  "
                cmd.Connection = cn
                cmd.ExecuteNonQuery()
                Module1.DatasetFill("Select * from AllTemp", "AllTemp")
                Call FillAll()
                Call calcAll()
            Catch ex As Exception

            End Try
        End If
    End Sub
#End Region

#Region "EVENTS"
    Private Sub dtDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDate.ValueChanged
        Call DateSplite()
    End Sub
    Private Sub cmbEmpName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpName.SelectedIndexChanged
        If Check = True Then
            If cmbEmpName.Text = "" Then
                Exit Sub
            Else
                CheckForExistance()
                If SalaryChecker = True Then
                    Call Status()
                    Call CMStatus()
                    Call Clear()
                    'lbMassageSalaryChecker.Text = "قبلآ پرداخته شده است " & CheckerYear & " و سال" & CheckerMonth & "معاش شخص مذکور برای ماه"
                    'lbMassageSalaryChecker.Text = "قبلآ پرداخته شده است " & "  " & CheckerYear & "  " & " و سال" & "  " & CheckerMonth & "  " & "معاش شخص مذکور برای ماه"
                    'lbMassageSalaryChecker.Text = "معاش شخص مذکور برای ماه " & "  " & CheckerMonth & "  " & " و سال" & "  " & CheckerYear & "  " & "قبلآ پرداخته شده است"
                    If ds.Tables.Contains("MonthlySal") = True Then
                        ds.Tables("MonthlySal").Clear()
                    End If
                    lbMassageSalaryChecker.Text = "معاش شخص مذکور برای ماه " & "  " & CheckerMonth & "  " & " و سال" & "  " & CheckerYear & "  " & "قبلآ پرداخته شده است"
                    PB.Visible = True
                    Exit Sub
                Else
                    Module1.Opencn()
                    Module1.DatasetFill("Select BasicSalary,NoOfWorkingDays from Contract where EmpID='" & cmbEmpName.SelectedValue & "'", "Contract")
                    Try

                        txtBasicSalary.Text = ds.Tables("Contract").Rows(0).Item("BasicSalary")
                        NoOfWorkingDays = ds.Tables("Contract").Rows(0).Item("NoOfWorkingDays")
                        AbsentChecker()
                        OneDaySalary = txtBasicSalary.Text / NoOfWorkingDays
                        txtAbsentMoney.Text = Val(OneDaySalary) * txtAbsent.Text
                        calcNet()
                        lblMessage.Text = ""
                        frmAdvancePaymentSalary.AdvancePayment = 0

                        RBAll.Checked = False
                        RBDed.Checked = False
                        DgAllowances.Rows.Clear()
                        DgDeduction.Rows.Clear()
                        txtAllTotal.Text = ""
                        txtDedTotal.Text = ""
                        txtAmount.Text = ""


                        cmd.CommandText = " Delete from AllTemp where EmpID <> " & cmbEmpName.SelectedValue
                        cmd.Connection = cn
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = " Delete from DedTemp where EmpID <> " & cmbEmpName.SelectedValue
                        cmd.Connection = cn
                        cmd.ExecuteNonQuery()

                        If ds.Tables.Contains("MonthlySal") = True Then
                            ds.Tables("MonthlySal").Clear()
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub RBAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAll.CheckedChanged
        If RBAll.Checked.Equals(True) Then
            If cmbEmpName.Text = "" Then
                MsgBox("PLEASE SELECT AN EMPLOYEE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول کارمند را انتخاب کنید", MsgBoxStyle.Critical)
                RBAll.Checked = False
                Exit Sub
            End If
            Call Allowances()
        Else
            cmbType.DataSource = Nothing
            cmbType.Items.Clear()
        End If
    End Sub

    Private Sub RBDed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBDed.CheckedChanged
        If RBDed.Checked.Equals(True) Then
            If cmbEmpName.Text = "" Then
                MsgBox("PLEASE SELECT AN EMPLOYEE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول کارمند را انتخاب کنید", MsgBoxStyle.Critical)
                RBDed.Checked = False
                Exit Sub
            End If
            Call Deduction()
        Else
            cmbType.DataSource = Nothing
            cmbType.Items.Clear()
        End If
    End Sub
    Private Sub chbAdvancePayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAdvancePayment.CheckedChanged
        If chbAdvancePayment.Checked.Equals(True) Then
            If cmbEmpName.Text = "" Then
                MsgBox("PLEASE SELECT AN EMPLOYEE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول کارمند را انتخاب کنید", MsgBoxStyle.Critical)
                chbAdvancePayment.Checked = False
                Exit Sub
            Else
                frmAdvancePaymentSalary.ShowDialog()
            End If
        End If
    End Sub

    Private Sub txtAdvancePayment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdvancePayment.TextChanged
        Call calcNet()
    End Sub
    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        If RBAll.Checked = False And RBDed.Checked = False Then
            MsgBox("PLEASE SELETCT ONE OF THEM" & Chr(13) & " " & Chr(13) & " لطفآ یکی را انتخاب کنید ", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If EditCombo = True Then
            If RBAll.Checked.Equals(True) Then
                If cmbType.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Module1.InsertRecord("AllowancesMain", "AllID,AllType", "'" & Label6.Text & "',N'" & cmbType.Text & "'")
                    Call Allowances()
                    cmbType.DropDownStyle = ComboBoxStyle.DropDownList
                    btnAddNew.Text = "جدید"
                    EditCombo = False
                    btnCancel.Visible = False
                    RBAll.Enabled = True
                    RBDed.Enabled = True
                    Exit Sub
                End If
            Else
                If cmbType.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Module1.InsertRecord("DeductionMain", "DedID,DedType", "'" & Label6.Text & "',N'" & cmbType.Text & "'")
                    Call Deduction()
                    cmbType.DropDownStyle = ComboBoxStyle.DropDownList
                    btnAddNew.Text = "جدید"
                    EditCombo = False
                    btnCancel.Visible = False
                    RBAll.Enabled = True
                    RBDed.Enabled = True
                    Exit Sub
                End If
            End If
        Else
            cmbType.DataSource = Nothing
            cmbType.Items.Clear()
            cmbType.DropDownStyle = ComboBoxStyle.DropDown
            btnAddNew.Text = "ثبت"
            EditCombo = True
            btnCancel.Visible = True
            RBAll.Enabled = False
            RBDed.Enabled = False
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If RBAll.Checked.Equals(True) Then
            Call Allowances()
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList
            btnAddNew.Text = "جدید"
            EditCombo = False
            btnCancel.Visible = False
            RBAll.Enabled = True
            RBDed.Enabled = True
        Else
            Call Deduction()
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList
            btnAddNew.Text = "جدید"
            EditCombo = False
            btnCancel.Visible = False
            RBAll.Enabled = True
            RBDed.Enabled = True
        End If
    End Sub
    Private Sub DgDeduction_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDeduction.CellValueChanged
        Call calcDed()
    End Sub

    Private Sub txtBasicSalary_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBasicSalary.TextChanged
        txtNetPay.Text = txtBasicSalary.Text
    End Sub

    Private Sub txtAllTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAllTotal.TextChanged
        Call calcNet()
    End Sub

    Private Sub txtDedTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDedTotal.TextChanged
        Call calcNet()
    End Sub
    Private Sub DgAllowances_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgAllowances.CellValueChanged
        Call calcAll()
    End Sub
#End Region

#End Region


#Region "SEARCH................."

#Region "DATA GRID VIEW FUCTIONS"
    Sub GridSalary()
        DGSearch.Rows.Clear()
        DGAll.Visible = False
        DGDed.Visible = False
        cmd.Connection = cn
        da.SelectCommand = cmd
        cmd.CommandText = Str1
        If (ds.Tables.Contains("VuSalary")) Then
            ds.Tables("VuSalary").Clear()
            DGSearch.Rows.Clear()
        End If
        da.Fill(ds, "VuSalary")

        For z = 0 To ds.Tables("VuSalary").Rows.Count - 1
            Try

                DGSearch.Rows.Add()
                DGSearch.Rows(z).Cells("DGID").Value = ds.Tables("VuSalary").Rows(z).Item("SalID")
                DGSearch.Rows(z).Cells("DGName").Value = ds.Tables("VuSalary").Rows(z).Item("Name")
                DGSearch.Rows(z).Cells("DGDate").Value = ds.Tables("VuSalary").Rows(z).Item("Date")
                DGSearch.Rows(z).Cells("DGMonth").Value = ds.Tables("VuSalary").Rows(z).Item("Month")
                DGSearch.Rows(z).Cells("DGYear").Value = ds.Tables("VuSalary").Rows(z).Item("Year")
                DGSearch.Rows(z).Cells("DGBasicSalary").Value = ds.Tables("VuSalary").Rows(z).Item("BasicSalary")
                DGSearch.Rows(z).Cells("DGAbsent").Value = ds.Tables("VuSalary").Rows(z).Item("AbsentDays")
                DGSearch.Rows(z).Cells("DGAbsentAmount").Value = ds.Tables("VuSalary").Rows(z).Item("AbsentMoney")
                DGSearch.Rows(z).Cells("DGAdvance").Value = ds.Tables("VuSalary").Rows(z).Item("AdvanceDed")
                DGSearch.Rows(z).Cells("DGNetPay").Value = ds.Tables("VuSalary").Rows(z).Item("Netpay")

            Catch ex As Exception
            End Try

        Next
    End Sub
    Sub GridAllowances()
        DGAllowancesMain.Rows.Clear()
        cmd.Connection = cn
        da.SelectCommand = cmd
        cmd.CommandText = Str2
        If (ds.Tables.Contains("VuAllowances")) Then
            ds.Tables("VuAllowances").Clear()
            DGAllowancesMain.Rows.Clear()
        End If
        da.Fill(ds, "VuAllowances")

        For z = 0 To ds.Tables("VuAllowances").Rows.Count - 1
            Try

                DGAllowancesMain.Rows.Add()
                DGAllowancesMain.Rows(z).Cells(0).Value = ds.Tables("VuAllowances").Rows(z).Item("SalID")
                DGAllowancesMain.Rows(z).Cells(1).Value = ds.Tables("VuAllowances").Rows(z).Item("Date")
                DGAllowancesMain.Rows(z).Cells(2).Value = ds.Tables("VuAllowances").Rows(z).Item("Month")
                DGAllowancesMain.Rows(z).Cells(3).Value = ds.Tables("VuAllowances").Rows(z).Item("Year")
                DGAllowancesMain.Rows(z).Cells(4).Value = ds.Tables("VuAllowances").Rows(z).Item("AllowancesName")
                DGAllowancesMain.Rows(z).Cells(5).Value = ds.Tables("VuAllowances").Rows(z).Item("AllowancesAmount")

            Catch ex As Exception
            End Try

        Next
    End Sub
    Sub GridDeduction()
        DGDeductionMain.Rows.Clear()
        cmd.Connection = cn
        da.SelectCommand = cmd
        cmd.CommandText = Str3
        If (ds.Tables.Contains("VuDeduction")) Then
            ds.Tables("VuDeduction").Clear()
            DGDeductionMain.Rows.Clear()
        End If
        da.Fill(ds, "VuDeduction")

        For z = 0 To ds.Tables("VuDeduction").Rows.Count - 1
            Try

                DGDeductionMain.Rows.Add()
                DGDeductionMain.Rows(z).Cells(0).Value = ds.Tables("VuDeduction").Rows(z).Item("SalID")
                DGDeductionMain.Rows(z).Cells(1).Value = ds.Tables("VuDeduction").Rows(z).Item("Date")
                DGDeductionMain.Rows(z).Cells(2).Value = ds.Tables("VuDeduction").Rows(z).Item("Month")
                DGDeductionMain.Rows(z).Cells(3).Value = ds.Tables("VuDeduction").Rows(z).Item("Year")
                DGDeductionMain.Rows(z).Cells(4).Value = ds.Tables("VuDeduction").Rows(z).Item("DeductionName")
                DGDeductionMain.Rows(z).Cells(5).Value = ds.Tables("VuDeduction").Rows(z).Item("DeductionAmount")

            Catch ex As Exception
            End Try

        Next
    End Sub
#End Region

#Region "EVENTS"
    Private Sub rbComplete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbComplete.CheckedChanged
        If rbComplete.Checked.Equals(True) Then
            CheckBox1.Visible = True
            CheckBox1.Checked = False
            cmbSearch.Enabled = False
            DGSearch.Rows.Clear()
            DGAllowancesMain.Rows.Clear()
            DGDeductionMain.Rows.Clear()
            GBCriteria.Visible = True
            DGSearch.Visible = True
            DGAll.Visible = False
            DGDed.Visible = False
            DGAllowancesMain.Visible = False
            DGDeductionMain.Visible = False
            dtFrom.Value = Now
            dtToo.Value = Now
        Else
            cmbSearch.DataSource = Nothing
            cmbSearch.Items.Clear()
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub rbAllowances_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllowances.CheckedChanged
        If rbAllowances.Checked.Equals(True) Then
            CheckBox1.Visible = False
            DGSearch.Rows.Clear()
            DGAllowancesMain.Rows.Clear()
            DGDeductionMain.Rows.Clear()
            GBCriteria.Visible = True
            DGSearch.Visible = False
            DGAllowancesMain.Visible = True
            DGDeductionMain.Visible = False
            DGAll.Visible = False
            DGDed.Visible = False
            cmbSearch.Enabled = True
            cmbSearch.DataSource = Nothing
            cmbSearch.Items.Clear()
            Module1.DatasetFill("Select Name,EmpID from EmpPerInfo", "EmpPerInfo")
            cmbSearch.DataSource = ds.Tables("EmpPerInfo")
            cmbSearch.DisplayMember = ("Name")
            cmbSearch.ValueMember = ("EmpID")
            cmbSearch.SelectedIndex = -1
            dtFrom.Value = Now
            dtToo.Value = Now
        Else
            cmbSearch.DataSource = Nothing
            cmbSearch.Items.Clear()
        End If
    End Sub

    Private Sub rbDeductions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDeductions.CheckedChanged
        If rbDeductions.Checked.Equals(True) Then
            CheckBox1.Visible = False
            DGSearch.Rows.Clear()
            DGAllowancesMain.Rows.Clear()
            DGDeductionMain.Rows.Clear()
            GBCriteria.Visible = True
            DGSearch.Visible = False
            DGAllowancesMain.Visible = False
            DGDeductionMain.Visible = True
            DGAll.Visible = False
            DGDed.Visible = False
            cmbSearch.Enabled = True
            cmbSearch.DataSource = Nothing
            cmbSearch.Items.Clear()
            Module1.DatasetFill("Select Name,EmpID from EmpPerInfo", "EmpPerInfo")
            cmbSearch.DataSource = ds.Tables("EmpPerInfo")
            cmbSearch.DisplayMember = ("Name")
            cmbSearch.ValueMember = ("EmpID")
            cmbSearch.SelectedIndex = -1
            dtFrom.Value = Now
            dtToo.Value = Now
        Else
            cmbSearch.DataSource = Nothing
            cmbSearch.Items.Clear()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If rbComplete.Checked = True Then
            If CheckBox1.Checked.Equals(False) Then
                Module1.DatasetFill("Select * from VuSalary", "VuSalary")
                Str1 = "Select * from VuSalary where Date between '" & dtFrom.Value.Date.ToString & "' And '" & dtToo.Value.Date.ToString & "'"
                Call GridSalary()
            Else
                Module1.DatasetFill("Select * from VuSalary", "VuSalary")
                Str1 = "Select * from VuSalary where Name=N'" & cmbSearch.Text & "' And Date between '" & dtFrom.Value.Date.ToString & "' And '" & dtToo.Value.Date.ToString & "'"
                Call GridSalary()
            End If
        ElseIf rbAllowances.Checked.Equals(True) Then
            Module1.DatasetFill("Select SalID,Date,Month,Year,AllowancesName,AllowancesAmount from VuAllowances", "VuAllowances")
            Str2 = "Select SalID,Date,Month,Year,AllowancesName,AllowancesAmount from VuAllowances where Name =N'" & cmbSearch.Text & "' and Date between '" & dtFrom.Value.Date.ToString & "' and '" & dtToo.Value.Date.ToString & "'"
            Call GridAllowances()
        ElseIf rbDeductions.Checked.Equals(True) Then
            Module1.DatasetFill("Select SalID,Name,Month,Year,DeductionName,DeductionAmount from VuDeduction", "VuDeduction")
            Str3 = "Select * from VuDeduction where Name =N'" & cmbSearch.Text & "' and Date between '" & dtFrom.Value.Date.ToString & "' and '" & dtToo.Value.Date.ToString & "'"
            Call GridDeduction()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked.Equals(True) Then
            DGSearch.Rows.Clear()
            cmbSearch.Enabled = True
            DGAll.Visible = False
            DGDed.Visible = False
            cmbSearch.DataSource = Nothing
            cmbSearch.Items.Clear()
            Module1.DatasetFill("Select Name,EmpID from EmpPerInfo", "EmpPerInfo")
            cmbSearch.DataSource = ds.Tables("EmpPerInfo")
            cmbSearch.DisplayMember = ("Name")
            cmbSearch.ValueMember = ("EmpID")
            cmbSearch.SelectedIndex = -1
        Else
            cmbSearch.Enabled = False
            DGSearch.Rows.Clear()
            DGAll.Visible = False
            DGDed.Visible = False
        End If
    End Sub

    Private Sub DGSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellDoubleClick
        DGAll.Visible = True
        Call FillAllowances()
        DGDed.Visible = True
        Call FillDeduction()
    End Sub
    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Me.Close()
    End Sub
#End Region

#End Region

    Private Sub TB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.SelectedIndexChanged
        If Frm.GID.Text <= 2 Then
            If TB1.SelectedIndex = 1 Then
                rbComplete.Checked = False
                rbAllowances.Checked = False
                rbDeductions.Checked = False
                GBCriteria.Visible = False
                DGSearch.Rows.Clear()
                DGSearch.Visible = False
                DGAllowancesMain.Rows.Clear()
                DGAllowancesMain.Visible = False
                DGDeductionMain.Rows.Clear()
                DGDeductionMain.Visible = False
                DGAll.Rows.Clear()
                DGAll.Visible = False
                DGDed.Rows.Clear()
                DGDed.Visible = False
            Else
                Call Clear()
                lbMassageSalaryChecker.Text = ""
                lblMessage.Text = ""
                PB.Visible = False
            End If
        End If
    End Sub

    Private Sub cmbType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbType.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If Asc(e.KeyChar) = 13 Then
            btnAddNew.PerformClick()
        End If
    End Sub


    Private Sub cmbEmpName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbEmpName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

End Class
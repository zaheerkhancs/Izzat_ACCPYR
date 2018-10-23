Imports System.Data.SqlClient
Public Class FrmClosing
    Dim Trans As SqlTransaction

    Private Sub FrmClosing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MaximizeBox = False
        ''Me.Left = 0
        ''Me.Top = 0
        ' Me.Height = Screen.PrimaryScreen.Bounds.Height - 4
        'Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
        ''Me.Height = Frm.Height - 70
        ''Me.Width = Frm.Width - 4

        GroupBox1.Left = Me.Width / 2 - (GroupBox1.Width / 2)
        GroupBox1.Top = Me.Height / 2 - (GroupBox1.Height / 2)
        Dim sts As Boolean
        sts = Module1.GetValue("AccStatus", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")
        If sts = 0 Then
            MsgBox("your account has been closed,so you cannot take closing")
            Button1.Enabled = False
            Label10.Visible = True
        Else
            Module1.DatasetFill("Select * from FinancialPeriod where Pid=N'" & Frm.LblPeriod.Text & "'", "FinancialPeriod")
            Call txtfill()
        End If
    End Sub
    Sub txtfill()
        Me.TxtCloseID.Text = ds.Tables("FinancialPeriod").Rows(0).Item(0)
        Me.TxtCloseStart.Text = ds.Tables("FinancialPeriod").Rows(0).Item(1)
        Me.TxtCloseEnd.Text = ds.Tables("FinancialPeriod").Rows(0).Item(2)
        'If ds.Tables("FinancialPeriod").Rows(0).Item(3) = 0 Then
        '     Button1.Enabled = False
        '    Label10.Visible = True
        'Else
        '   Label10.Visible = False
        'End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Try
            Dim Revenue As Integer
            Dim expenses As Integer
            Dim IncomeHead As String
            Dim CapitalCode As String
            Module1.UpdateRecord("FinancialPeriod", "AccStatus=0", "CompanyID=" & Frm.LBCompanyID.Text)
            Revenue = Module1.GetValue("Isnull(Sum(Dr)-Sum(Cr),0)", "VuGL", "AccName='Revenue' and PID=N'" & Me.TxtCloseID.Text & "'")
            expenses = Module1.GetValue("Isnull(Sum(Dr)-Sum(Cr),0)", "VuGL", "AccName='Liabilities' and PID=N'" & Me.TxtCloseID.Text & "'")
            IncomeHead = Module1.GetValue("RevenueCode", "Impheads", "CompanyID=" & Frm.LBCompanyID.Text)
            CapitalCode = Module1.GetValue("CapitalCode", "Impheads", "CompanyID=" & Frm.LBCompanyID.Text)
            'cmd.CommandType = CommandType.Text
            '    cmd.CommandText = "select Isnull(Sum(Dr)-Sum(Cr),0) from VuGl where HeadType='Revenue' and date Between '" & Me.LblFDate.Text & "' and '" & Me.LblTDate.Text & "'"
            '    cmd.Connection = cn
            '    Rev = cmd.ExecuteScalar

            '    cmd.CommandType = CommandType.Text
            '    cmd.CommandText = "select isnull(Sum(Dr)-Sum(Cr),0) from VuGl where  HeadType='Expenses' and date Between '" & Me.LblFDate.Text & "' and '" & Me.LblTDate.Text & "'"
            '    cmd.Connection = cn
            '    Exp = cmd.ExecuteScalar
            '    'Capital-0003


            Module1.DatasetFill("select HeadID,HeadName,AccName,sum(Dr) as Dr,Sum(Cr)as Cr,SubId from VuGL where  PID= N'" & Me.TxtCloseID.Text & "' And AccName='Assets' or AccName='Capital' or AccName='Liability' Group by HeadName,HeadID,AccName,subid", "MyTable")
            Trans = cn.BeginTransaction
            If Me.DtStart.Value = Me.DtEnd.Value Then
                Dim frmm1 As New FrmBox("Please Enter the correct Finanical Period.")
                frmm1.ShowDialog()
                frmm1.BackColor = Color.OrangeRed
                Exit Sub

            End If


            Dim CmdSave1 As New SqlCommand
            CmdSave1.CommandType = CommandType.StoredProcedure
            CmdSave1.CommandText = "InsertUpdateFinancial"
            CmdSave1.Connection = cn
            CmdSave1.Transaction = Trans
            CmdSave1.Parameters.Add("@PID", SqlDbType.NVarChar)
            CmdSave1.Parameters("@PID").Value = Me.TxtID.Text
            CmdSave1.Parameters.Add("@FromDate", SqlDbType.DateTime)
            CmdSave1.Parameters("@FromDate").Value = Me.DtStart.Value
            CmdSave1.Parameters.Add("@ToDate", SqlDbType.DateTime)
            CmdSave1.Parameters("@ToDate").Value = Me.DtEnd.Value
            CmdSave1.Parameters.Add("@AccStatus", SqlDbType.Bit)
            If ChkIsCurrent.Checked = True Then
                CmdSave1.Parameters("@AccStatus").Value = 1
            Else
                CmdSave1.Parameters("@AccStatus").Value = 0
            End If
            CmdSave1.Parameters.Add("@CompanyID", SqlDbType.BigInt)
            CmdSave1.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text

            CmdSave1.Parameters.Add("@UserID", SqlDbType.BigInt)
            CmdSave1.Parameters("@UserID").Value = Frm.LbUserID.Text

            CmdSave1.Parameters.Add("@WName", SqlDbType.NVarChar)
            CmdSave1.Parameters("@WName").Value = Frm.WName.Text

            CmdSave1.Parameters.Add("@Flag", SqlDbType.Bit)
            CmdSave1.Parameters("@Flag").Value = 1
            CmdSave1.ExecuteNonQuery()
            '  cmdsave.Parameters.Clear()

            'Dim frmm As New FrmBox("Your Record has been saved successfully..")
            'frmm.ShowDialog()








            ' Trans = cn.BeginTransaction
            Dim a As Integer = 0
            '    Dim Rev As Integer
            '    Dim Exp As Integer
            '    Dim sdate As Date
            '    Dim vno As String
            '    If Me.CmbID.Text = "" Then Exit Sub
            '    cmd.CommandType = CommandType.Text
            '    cmd.CommandText = "Delete From Trial"
            '    cmd.Connection = cn
            '    cmd.ExecuteNonQuery()

            '    cmd.CommandText = "select HeadCode,HeadName,HeadType,sum(Dr) as Dr,Sum(Cr)as Cr,SubId from VuGL where  date Between '" & Me.LblFDate.Text & "' and '" & Me.LblTDate.Text & "' And HeadType='Assets' or HeadType='Capital' or HeadType='Liability' Group by HeadName,HeadCode,HeadType,subid"


            Call SaveVoucher()
            For a = 0 To ds.Tables("MyTable").Rows.Count - 1
                Dim cmdSave As New SqlCommand
                cmdSave.Transaction = Trans
                If cn.State = ConnectionState.Closed Then cn.Open()
                cmdSave.Connection = cn
                cmdSave.CommandType = CommandType.StoredProcedure
                cmdSave.CommandText = "SaveDetail"
                cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
                cmdSave.Parameters("@Vno").Value = "OB" & Me.TxtID.Text & "" & Frm.LBCompanyID.Text
                ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
                cmdSave.Parameters.Add("@HeadID", SqlDbType.Char)
                cmdSave.Parameters("@HeadID").Value = ds.Tables("MyTable").Rows(a).Item("HeadID")
                cmdSave.Parameters.Add("@SubID", SqlDbType.BigInt)
                cmdSave.Parameters("@SubID").Value = (IIf(IsDBNull(ds.Tables("MyTable").Rows(a).Item("SubId")) = True, 0, ds.Tables("MyTable").Rows(a).Item("SubId")))
                cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
                cmdSave.Parameters("@Remarks").Value = "from Closing Form"
                cmdSave.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
                cmdSave.Parameters("@ChequeNo").Value = "Nill"
                cmdSave.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
                cmdSave.Parameters("@ChequeDate").Value = "01/01/1900"
                cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
                cmdSave.Parameters("@Dr").Value = Val(ds.Tables("MyTable").Rows(a).Item("Dr"))
                cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
                cmdSave.Parameters("@Cr").Value = Val(ds.Tables("MyTable").Rows(a).Item("Cr"))
                cmdSave.ExecuteNonQuery()
            Next

            Dim cmdSave2 As New SqlCommand
            cmdSave2.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave2.Connection = cn
            cmdSave2.CommandType = CommandType.StoredProcedure
            cmdSave2.CommandText = "SaveDetail"
            cmdSave2.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave2.Parameters("@Vno").Value = "OB" & Me.TxtID.Text & "" & Frm.LBCompanyID.Text
            ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
            cmdSave2.Parameters.Add("@HeadID", SqlDbType.Char)
            cmdSave2.Parameters("@HeadID").Value = IncomeHead
            cmdSave2.Parameters.Add("@SubID", SqlDbType.BigInt)
            cmdSave2.Parameters("@SubID").Value = 0
            cmdSave2.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave2.Parameters("@Remarks").Value = "from Closing Form"
            cmdSave2.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
            cmdSave2.Parameters("@ChequeNo").Value = "Nill"
            cmdSave2.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
            cmdSave2.Parameters("@ChequeDate").Value = "01/01/1900"
            cmdSave2.Parameters.Add("@Dr", SqlDbType.Decimal)
            cmdSave2.Parameters("@Dr").Value = 0
            cmdSave2.Parameters.Add("@Cr", SqlDbType.Decimal)
            cmdSave2.Parameters("@Cr").Value = Math.Abs(Revenue) - Math.Abs(expenses)
            cmdSave2.ExecuteNonQuery()

            Dim cmdSave3 As New SqlCommand
            cmdSave3.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave3.Connection = cn
            cmdSave3.CommandType = CommandType.StoredProcedure
            cmdSave3.CommandText = "SaveDetail"
            cmdSave3.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave3.Parameters("@Vno").Value = "OB" & Me.TxtID.Text & "" & Frm.LBCompanyID.Text
            ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
            cmdSave3.Parameters.Add("@HeadID", SqlDbType.Char)
            cmdSave3.Parameters("@HeadID").Value = CapitalCode
            cmdSave3.Parameters.Add("@SubID", SqlDbType.BigInt)
            cmdSave3.Parameters("@SubID").Value = 0
            cmdSave3.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave3.Parameters("@Remarks").Value = "from Closing Form"
            cmdSave3.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
            cmdSave3.Parameters("@ChequeNo").Value = "Nill"
            cmdSave3.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
            cmdSave3.Parameters("@ChequeDate").Value = "01/01/1900"
            cmdSave3.Parameters.Add("@Dr", SqlDbType.Decimal)
            cmdSave3.Parameters("@Dr").Value = Math.Abs(Revenue) - Math.Abs(expenses)
            cmdSave3.Parameters.Add("@Cr", SqlDbType.Decimal)
            cmdSave3.Parameters("@Cr").Value = 0
            cmdSave3.ExecuteNonQuery()
            Trans.Commit()

            'cmd.CommandText = "Insert into Gl values('" & vno & "','" & sdate & "','OB','" & ds.Tables("MyTable").Rows(a).Item("HeadCode") & "','Opening Balance of the new Year'," & Val(ds.Tables("MyTable").Rows(a).Item("Dr")) & "," & Val(ds.Tables("MyTable").Rows(a).Item("Cr")) & "," & ds.Tables("MyTable").Rows(a).Item("SubId") & ")"
            'Else
            'cmd.CommandText = "Insert into Gl(Vno,Date,Type,HeadCode,Particular,Dr,Cr) values('" & vno & "','" & sdate & "','OB','" & ds.Tables("MyTable").Rows(a).Item("HeadCode") & "','Opening Balance of the new Year'," & Val(ds.Tables("MyTable").Rows(a).Item("Dr")) & "," & Val(ds.Tables("MyTable").Rows(a).Item("Cr")) & ")"
            ' End If
            '    cmd.ExecuteNonQuery()

            'cmd.CommandType = CommandType.Text
            'cmd.Connection = cn
            'cmd = New SqlCommand("insert into Trial values('" & ds.Tables("MyTable").Rows(a).Item("HeadCode") & "','" & ds.Tables("MyTable").Rows(a).Item("HeadName") & "','" & ds.Tables("MyTable").Rows(a).Item("HeadType") & "'," & ds.Tables("MyTable").Rows(a).Item("Dr") & "," & ds.Tables("MyTable").Rows(a).Item("Cr") & "," & ds.Tables("MyTable").Rows(a).Item("Dr") - ds.Tables("MyTable").Rows(a).Item("Cr") & ",'After-Closing Trial balance')", con)
            'cmd.ExecuteNonQuery()


            'Next
            '    'HeadType
            'cmd.CommandType = CommandType.Text
            '    cmd.CommandText = "select Isnull(Sum(Dr)-Sum(Cr),0) from VuGl where HeadType='Revenue' and date Between '" & Me.LblFDate.Text & "' and '" & Me.LblTDate.Text & "'"
            '    cmd.Connection = cn
            '    Rev = cmd.ExecuteScalar

            '    cmd.CommandType = CommandType.Text
            '    cmd.CommandText = "select isnull(Sum(Dr)-Sum(Cr),0) from VuGl where  HeadType='Expenses' and date Between '" & Me.LblFDate.Text & "' and '" & Me.LblTDate.Text & "'"
            '    cmd.Connection = cn
            '    Exp = cmd.ExecuteScalar
            '    'Capital-0003

            '    cmd.CommandType = CommandType.Text
            '    'Cmd.CommandText = "Insert into Gl values('" & vno & "','Net Income','Capital'," & Rev - Exp & ",'" & Me.CmbID.Text & "','Liabilities & Owners Equity')"
            '    cmd.CommandText = "Insert into Gl(Vno,Date,Type,HeadCode,Particular,Dr,Cr) values('" & vno & "','" & sdate & "','OB','" & NetInc & "','Opening Balance of the new Year'," & Rev - Exp & ",0)"
            '    cmd.Connection = cn
            '    cmd.ExecuteNonQuery()

            '    cmd.CommandType = CommandType.Text
            '    cmd.Connection = cn
            '    cmd = New SqlCommand("insert into Trial values('" & NetInc & "','Net Income','Capital'," & Rev - Exp & ",0," & Rev - Exp & ",'After-Closing Trial balance')", con)
            '    cmd.ExecuteNonQuery()

            '    cmd.CommandType = CommandType.Text
            '    cmd.CommandText = "Insert into ClosingPeriod values('" & CmbID.Text & "','" & sdate & "','nothing')"
            '    cmd.Connection = cn
            '    cmd.ExecuteNonQuery()
            '    MsgBox("Your Financial Period is closed successfully")
            '    Me.CmdPrint.Enabled = True
            '    Me.btnstep2.Enabled = False
            'End If
            Me.BtnClose.Enabled = False
            MsgBox("Your Financial Period is closed successfully")
        Catch ex As Exception
            Trans.Rollback()
            MsgBox(ex.Message)
        End Try

    End Sub

    'Private Sub CmdPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
    '    If RptFrm Is Nothing Then
    '        RptFrm = New FrmReport
    '        RptFrm.Str = "Select * from VuTrial"
    '        RptFrm.RptString = "RptTrial"
    '        RptFrm.Text = "Trial Balance"
    '    Else
    '        RptFrm = Nothing
    '        RptFrm = New FrmReport
    '        RptFrm.Str = "Select * from VuTrial"
    '        RptFrm.RptString = "RptTrial"
    '        RptFrm.Text = "Trial Balance"
    '    End If
    '    Dim PFs As New ParameterFields
    '    Dim pF As New ParameterField
    '    Dim Dv As New ParameterDiscreteValue
    '    pF.ParameterFieldName = "Company"
    '    Dv.Value = "Dwizd Private Limit"
    '    pF.CurrentValues.Add(Dv)
    '    PFs.Add(pF)
    '    RptFrm.CV.ParameterFieldInfo = PFs
    '    RptFrm.Show()



    'End Sub

    Sub SaveVoucher()
        Try

            Dim cmdSave As New SqlCommand
            cmdSave.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave.Connection = cn
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "InsertUpdateVMain"
            cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vno").Value = "OB" & Me.TxtID.Text & "" & Frm.LBCompanyID.Text
            cmdSave.Parameters.Add("@Vtype", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vtype").Value = "OB"
            cmdSave.Parameters.Add("@Date", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@Date").Value = Me.DtEnd.Value.Date
            cmdSave.Parameters.Add("@descr", SqlDbType.NVarChar)
            cmdSave.Parameters("@descr").Value = "from account closing "
            cmdSave.Parameters.Add("@UserID", SqlDbType.Int)
            cmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text
            cmdSave.Parameters.Add("@CompanyID", SqlDbType.Int)
            cmdSave.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text
            cmdSave.Parameters.Add("@WName", SqlDbType.NVarChar)
            cmdSave.Parameters("@WName").Value = Frm.WName.Text
            cmdSave.Parameters.Add("@PID", SqlDbType.NVarChar)
            cmdSave.Parameters("@PID").Value = Frm.LblPeriod.Text
            cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave.Parameters("@Remarks").Value = "Nill"
            cmdSave.Parameters.Add("@VKey", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@VKey").Value = Me.DtStart.Value.Date.AddDays(3)
            cmdSave.Parameters.Add("@VPost", SqlDbType.Bit)
            cmdSave.Parameters("@VPost").Value = 1

            cmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
            cmdSave.Parameters("@Flag").Value = 1
            MsgBox(Me.DtStart.Value.Date.AddDays(3))
            cmdSave.ExecuteNonQuery()
            'GridSave()

            ' Dim frmm As New FrmBox("Your Record has been saved successfully..")
            ' frmm.ShowDialog()
            'Else
            '    If EditFlag = False Then
            '        MsgBox("Sorry :  you cannot do entry on wrong date..", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            '        Exit Sub

            'End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TxtID.Enabled = True
        Me.DtStart.Enabled = True
        Me.DtEnd.Enabled = True
        Me.ChkIsCurrent.Checked = True
        Me.BtnClose.Enabled = True
        Me.Button1.Enabled = False
    End Sub

    Private Sub DtStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtStart.ValueChanged
        Me.TxtID.Text = Frm.LBCompanyName.Text & "-" & DtStart.Value.Year & "-" & DtEnd.Value.Year
    End Sub

    Private Sub DtEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtEnd.ValueChanged
        Me.TxtID.Text = Frm.LBCompanyName.Text & "-" & DtStart.Value.Year & "-" & DtEnd.Value.Year
    End Sub
End Class
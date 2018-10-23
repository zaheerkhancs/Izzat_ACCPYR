Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class FrmIncomeStatment

    Dim CompanyNames As String
    Public Compstr As String
    Dim CashAmount As Decimal
    Dim NewDS As New DataSet
    Dim DASave As New SqlDataAdapter
    Dim cmdnew As New SqlCommand

    Private Sub FrmBallance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = 0
        Me.Top = 0
        Module1.Opencn()
        'Me.TopMost = True
        'Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
        'Me.Height = Screen.PrimaryScreen.Bounds.Height - 4
        Dim sts As Boolean
        Module1.DatasetFill("select * from CompannySetUp", "CompannySetUp")
        CompanyNames = ds.Tables("CompannySetUp").Rows(0).Item(0)
        sts = Module1.GetValue("AccStatus", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")
        ' Module1.DatasetFill("Select * from GlReport", "GLReport")

        ' Module1.DatasetFill("Select * from Company", "Company")
        '''''''''''''''''''''''''''''for Crystal Report '''''''''''''''''''''''''''''''''''''''''''
        'Call ReportShow()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        cmdnew.CommandText = "Select * from IncomeStatment"
        cmdnew.Connection = cn
        DASave.SelectCommand = cmdnew
        DASave.Fill(NewDS, "IncomeStatment")

        Module1.DatasetFill(" select Fullname,Balance from VuTrial where PID=N'" & Frm.LblPeriod.Text & "' and Vtype='OB' and FullName in(N" & Compstr & ")", "VuTrial")
        Module1.DatasetFill("Select * from VuGl where  FullName in(N" & Compstr & ") and PID=N'" & Frm.LblPeriod.Text & "' and AccName in('Revenue','Expenses') order by HeadName ", "VuGL")
        '   MsgBox(ds.Tables("VuGl").Rows.Count.ToString)
        ' MsgBox(ds.Tables("Company").Rows.Count.ToString)
        ' Module1.DatasetFill("Select * from Company where Remarks in (Select FullName from VuGL where  FullName in(N" & Compstr & ") and PID='" & Frm.LblPeriod.Text & "' and Vtype='Cash payment' or Vtype='Cash Receipt')", "Company")

        Module1.DatasetFill("Select * from VuChartofacc", "Chartofacc")
        'MsgBox(Frm.LblPeriod.Text)

    End Sub


    Sub ReportShow()

        Dim TotalRevenue As Integer = 0
        Dim TotalExpenses As Integer = 0


        Dim PField As New ParameterField
        Dim DSv As New ParameterDiscreteValue

        Dim PField1 As New ParameterField
        Dim DSv1 As New ParameterDiscreteValue


        Dim ps As New ParameterFields


        TotalExpenses = Module1.GetValue("Sum(Dr)-Sum(Cr)", "VuGl", "AccName='Expenses' and PID=N'" & Frm.LblPeriod.Text & "' and FullName in(N" & Compstr & ")")
        TotalRevenue = Module1.GetValue("Sum(Cr)-Sum(Dr)", "VuGl", "AccName='Revenue'  and PID=N'" & Frm.LblPeriod.Text & "' and FullName in(N" & Compstr & ")")
        Module1.DatasetFill("Select * from IncomeStatment order by AccName desc", "IncomeStatment")
        Dim rpt As New RptSubType
        rpt.SetDataSource(ds.Tables("IncomeStatment"))

        PField.ParameterFieldName = "CompanyName"
        DSv.Value = CompanyNames
        PField.CurrentValues.Add(DSv)
        ps.Add(PField)
       
        PField1.ParameterFieldName = "TotalIncome"
        DSv1.Value = TotalRevenue - TotalExpenses
        PField1.CurrentValues.Add(DSv1)
        ps.Add(PField1)

        CV.ParameterFieldInfo = ps
        CV.ReportSource = rpt

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim drow As DataRow
        Module1.DeleteRecord("IncomeStatment")
        Dim AmountIn As Decimal = 0
        Dim DrAdd As DataRow
        NewDS.Tables("IncomeStatment").Clear()
        Module1.DatasetFill("Select * from VuChartofacc where AccName in('Revenue')", "Chartofacc")
        Dim DrRevenue As Integer
        Dim CrRevenue As Integer
        For Each drchart As DataRow In ds.Tables("Chartofacc").Rows
            DrRevenue = 0
            CrRevenue = 0
            AmountIn = 0
            For Each drow In ds.Tables("VuGl").Rows
                If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("HeadID") = drchart("HeadID") Then
                    DrRevenue = DrRevenue + drow("Dr")
                End If
            Next

            For Each drow In ds.Tables("VuGl").Rows
                If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("HeadID") = drchart("HeadID") Then
                    CrRevenue = CrRevenue + drow("Cr")
                End If
            Next

            AmountIn = CrRevenue - DrRevenue
            If AmountIn <> 0 Then
                DrAdd = NewDS.Tables("IncomeStatment").NewRow
                DrAdd.Item(0) = drchart("HeadName")
                DrAdd.Item(1) = drchart("AccName")
                DrAdd.Item(2) = AmountIn
                DrAdd.Item(3) = Frm.LblPeriod.Text
                DrAdd.Item(4) = Frm.LBCompanyName.Text
                DrAdd.Item(5) = drchart("CatTitle")
                NewDS.Tables("IncomeStatment").Rows.Add(DrAdd)
            End If

        Next


        ''''''''''''''''''''''''''''''''''''Expenses'''''''''''''''''''''''''''''''''''''''
        Module1.DatasetFill("Select * from VuChartofacc where AccName in('Expenses')", "Chartofacc")
        Dim DrExpenses As Integer
        Dim CrExpenses As Integer
        For Each drchart As DataRow In ds.Tables("Chartofacc").Rows
            DrExpenses = 0
            CrExpenses = 0
            AmountIn = 0
            For Each drow In ds.Tables("VuGl").Rows
                If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("HeadID") = drchart("HeadID") Then
                    DrExpenses = DrExpenses + drow("Dr")
                End If
            Next

            For Each drow In ds.Tables("VuGl").Rows
                If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("HeadID") = drchart("HeadID") Then
                    CrExpenses = CrExpenses + drow("Cr")
                End If
            Next

            AmountIn = DrExpenses - CrExpenses
            If AmountIn <> 0 Then
                DrAdd = NewDS.Tables("IncomeStatment").NewRow
                DrAdd.Item(0) = drchart("HeadName")
                DrAdd.Item(1) = drchart("AccName")
                DrAdd.Item(2) = AmountIn
                DrAdd.Item(3) = Frm.LblPeriod.Text
                DrAdd.Item(4) = Frm.LBCompanyName.Text
                DrAdd.Item(5) = drchart("CatTitle")
                NewDS.Tables("IncomeStatment").Rows.Add(DrAdd)
            End If

        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        'Next
        'Module1.DatasetFill("Select * from VuTrial where  FullName in(N" & Compstr & ") and PID='" & Frm.LblPeriod.Text & "' and AccName in('Liabilities','Capital') order by HeadName ", "VuGL")
        'Module1.DatasetFill("Select * from VuChartofacc where AccName='Liabilities' or AccName='Capital' ", "Chartofacc")
        'For Each DrCompany As DataRow In ds.Tables("Company").Rows
        '    For Each drchart As DataRow In ds.Tables("Chartofacc").Rows
        '        AmountIn = 0
        '        For Each drow In ds.Tables("VuGl").Rows
        '            If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("HeadID") = drchart("HeadID") And DrCompany.Item("Remarks") = drow.Item("FullName") Then
        '                AmountIn = drow("Balance")
        '            End If

        '        Next


        '        DrAdd = NewDS.Tables("BalanceSheet").NewRow
        '        DrAdd.Item(0) = drchart("HeadName")
        '        DrAdd.Item(1) = "Liabilities  " & " and " & "Owner Equity"
        '        DrAdd.Item(2) = AmountIn
        '        DrAdd.Item(3) = Frm.LblPeriod.Text
        '        DrAdd.Item(4) = DrCompany.Item("Remarks")
        '        NewDS.Tables("BalanceSheet").Rows.Add(DrAdd)
        '    Next

        ' Next
        Dim CmdBuild1 As New SqlCommandBuilder(DASave)
        DASave.Update(NewDS, "IncomeStatment")
        Call ReportShow()
        'Module1.InsertRecord("GlReport", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadID") & "','" & drow("HeadName") & "','" & drow("SubName") & "','" & drow("Remarks") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'")
        'Call ReportShow()
    End Sub


End Class
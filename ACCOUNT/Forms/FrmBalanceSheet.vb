Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class FrmBalanceSheet
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
        Module1.DatasetFill("Select * from GlReport", "GLReport")

        Module1.DatasetFill("Select * from Company", "Company")
        '''''''''''''''''''''''''''''for Crystal Report '''''''''''''''''''''''''''''''''''''''''''
        'Call ReportShow()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        cmdnew.CommandText = "Select * from BalanceSheet"
        cmdnew.Connection = cn
        DASave.SelectCommand = cmdnew
        DASave.Fill(NewDS, "BalanceSheet")

        Module1.DatasetFill(" select Fullname,Balance from VuTrial where PID=N'" & Frm.LblPeriod.Text & "' and Vtype='OB' and FullName in(N" & Compstr & ")", "VuTrial")

        '  MsgBox(ds.Tables("VuGl").Rows.Count.ToString)
        ' MsgBox(ds.Tables("Company").Rows.Count.ToString)
        Module1.DatasetFill("Select * from Company where Remarks in (Select FullName from VuGL where  FullName in(N" & Compstr & ") and PID=N'" & Frm.LblPeriod.Text & "' and Vtype='Cash payment' or Vtype='Cash Receipt')", "Company")

        Module1.DatasetFill("Select * from VuChartofacc", "Chartofacc")

    End Sub


    Sub ReportShow()
        Dim PField As New ParameterField
        Dim DSv As New ParameterDiscreteValue
        Dim ps As New ParameterFields
        Dim PField1 As New ParameterField
        Dim DSv1 As New ParameterDiscreteValue


        Module1.DatasetFill("Select * from BalanceSheet", "BalanceSheet")
        Dim rpt As New RptSubTrialBalance

        rpt.SetDataSource(ds.Tables("BalanceSheet"))

        PField.ParameterFieldName = "CompanyName"
        DSv.Value = CompanyNames
        PField.CurrentValues.Add(DSv)

        PField1.ParameterFieldName = "Date"
        DSv1.Value = Me.DtDate2.Value
        PField1.CurrentValues.Add(DSv1)

        ps.Add(PField)
        ps.Add(PField1)

        CV.ParameterFieldInfo = ps
        CV.ReportSource = rpt

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim drow As DataRow
        Module1.DeleteRecord("BalanceSheet")
        Dim cmpstr As String = ""
        Dim AmountIn As Decimal = 0
        Dim DrAdd As DataRow
        NewDS.Tables("BalanceSheet").Clear()
        'MsgBox(ds.Tables("Company").Rows.Count)
        Module1.DatasetFill("Select * from Company where Remarks in(N" & Compstr & ")", "Company")
        'Module1.DatasetFill("Select * from VuTrial where  FullName in(N" & Compstr & ") and PID='" & Frm.LblPeriod.Text & "' and AccName in('Assets') order by HeadName ", "VuGL")
        Module1.DatasetFill("Select * from VuChartofacc where AccName='Assets'", "Chartofacc")

        ' For Each DrCompany As DataRow In ds.Tables("Company").Rows
        Dim DrAssets As Integer
        Dim CrAssets As Integer
        Module1.DatasetFill("Select * from VuGl where  FullName in(N" & Compstr & ") and PID=N'" & Frm.LblPeriod.Text & "' and AccName in('Assets') order by HeadName ", "VuGL")


        For Each drchart As DataRow In ds.Tables("Chartofacc").Rows
            AmountIn = 0
            DrAssets = 0
            CrAssets = 0
            'MsgBox(drchart("HeadName"))
            For Each drow In ds.Tables("VuGl").Rows
                If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("HeadID") = drchart("HeadID") Then
                    DrAssets = DrAssets + drow("Dr")
                    CrAssets = CrAssets + drow("Cr")
                End If
            Next
            AmountIn = DrAssets - CrAssets
            If AmountIn <> 0 Then
                DrAdd = NewDS.Tables("BalanceSheet").NewRow
                DrAdd.Item(0) = drchart("HeadName")
                DrAdd.Item(1) = drchart("AccName")
                DrAdd.Item(2) = AmountIn
                DrAdd.Item(3) = Frm.LblPeriod.Text
                DrAdd.Item(4) = Compstr
                DrAdd.Item(5) = drchart("CatTitle")
                NewDS.Tables("BalanceSheet").Rows.Add(DrAdd)
                ' cmpstr = DrCompany.Item("Remarks")
            End If
        Next

        ' Next
        Module1.DatasetFill("Select * from VuGl where  FullName in(N" & Compstr & ") and PID=N'" & Frm.LblPeriod.Text & "' and AccName in('Liabilities','Capital') order by HeadName ", "VuGL")
        Module1.DatasetFill("Select * from VuChartofacc where AccName='Liabilities' or AccName='Capital' ", "Chartofacc")
        'For Each DrCompany As DataRow In ds.Tables("Company").Rows
        Dim DrLiab As Integer
        Dim CrLiab As Integer
        For Each drchart As DataRow In ds.Tables("Chartofacc").Rows
            AmountIn = 0
            DrLiab = 0
            CrLiab = 0
            For Each drow In ds.Tables("VuGl").Rows
                If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("HeadID") = drchart("HeadID") Then
                    DrLiab = DrLiab + drow("Dr")
                    CrLiab = CrLiab + drow("Cr")
                End If

            Next

            AmountIn = CrLiab - DrLiab
            If AmountIn <> 0 Then
                DrAdd = NewDS.Tables("BalanceSheet").NewRow
                DrAdd.Item(0) = drchart("HeadName")
                DrAdd.Item(1) = "Liabilities  " & " and " & "Owner Equity"
                DrAdd.Item(2) = Math.Abs(AmountIn)
                DrAdd.Item(3) = Frm.LblPeriod.Text
                DrAdd.Item(4) = Compstr
                DrAdd.Item(5) = drchart("CatTitle")
                NewDS.Tables("BalanceSheet").Rows.Add(DrAdd)
                ' cmpstr = DrCompany.Item("Remarks")
            End If
        Next

        ' Next
        Dim TotalExpenses As Integer
        Dim TotalRevenue As Integer
        TotalExpenses = Module1.GetValue("Sum(Dr)-Sum(Cr)", "VuGl", "AccName='Expenses' and PID=N'" & Frm.LblPeriod.Text & "' and FullName in(N" & Compstr & ")")
        TotalRevenue = Module1.GetValue("Sum(Cr)-Sum(Dr)", "VuGl", "AccName='Revenue'  and PID=N'" & Frm.LblPeriod.Text & "' and FullName in(N" & Compstr & ")")

        DrAdd = NewDS.Tables("BalanceSheet").NewRow
        DrAdd.Item(0) = "Net Income of " & Frm.LblPeriod.Text
        DrAdd.Item(1) = "Liabilities  " & " and " & "Owner Equity"
        DrAdd.Item(2) = TotalRevenue - TotalExpenses
        DrAdd.Item(3) = Frm.LblPeriod.Text
        DrAdd.Item(4) = Compstr
        DrAdd.Item(5) = "Net Income"
        NewDS.Tables("BalanceSheet").Rows.Add(DrAdd)




        Dim CmdBuild1 As New SqlCommandBuilder(DASave)
        DASave.Update(NewDS, "BalanceSheet")
        Call ReportShow()
        'Module1.InsertRecord("GlReport", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadID") & "','" & drow("HeadName") & "','" & drow("SubName") & "','" & drow("Remarks") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'")
        'Call ReportShow()
    End Sub



End Class
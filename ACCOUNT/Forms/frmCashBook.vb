Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class FrmCashBook
    Dim CompanyNames As String
    Public Compstr As String
    Dim CashAmount As Decimal
    Dim NewDS As New DataSet
    Dim DASave As New SqlDataAdapter
    Dim cmdnew As New SqlCommand

    Private Sub FrmGL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = 0
        Me.Top = 0
        Module1.Opencn()
        'Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
        'Me.Height = Screen.PrimaryScreen.Bounds.Height - 4
        ' Me.Height = Frm.Height - 70
        'Me.Width = Frm.Width - 4

        Dim sts As Boolean
        Module1.DatasetFill("select * from CompannySetUp", "CompannySetUp")
        CompanyNames = ds.Tables("CompannySetUp").Rows(0).Item(0)
        sts = Module1.GetValue("AccStatus", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")
        Module1.DatasetFill("Select * from GlReport", "GLReport")

        Module1.DatasetFill("Select * from Company", "Company")
        '''''''''''''''''''''''''''''for Crystal Report '''''''''''''''''''''''''''''''''''''''''''
        Call ReportShow()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        cmdnew.CommandText = "Select * from CashBook"
        cmdnew.Connection = cn
        DASave.SelectCommand = cmdnew
        DASave.Fill(NewDS, "CashBook")

        Module1.DatasetFill(" select Fullname,Balance from VuTrial where PID=N'" & Frm.LblPeriod.Text & "' and Vtype='OB' and FullName in(N" & Compstr & ")", "VuTrial")
        Module1.DatasetFill("Select * from VuGL where  FullName in(N" & Compstr & ") and PID=N'" & Frm.LblPeriod.Text & "' and Vtype='Cash payment' or Vtype='Cash Receipt' order by HeadID ", "VuGL")
        ' MsgBox(ds.Tables("VuGl").Rows.Count.ToString)
        Module1.DatasetFill("Select * from Company where Remarks in (Select FullName from VuGL where  FullName in(N" & Compstr & ") and PID=N'" & Frm.LblPeriod.Text & "' and Vtype='Cash payment' or Vtype='Cash Receipt')", "Company")

        Module1.DatasetFill("Select * from Chartofaccount", "Chartofacc")
        CmbHeads.DataSource = ds.Tables("Chartofacc")

        Module1.DatasetFill("Select * from VuChart", "VuChart")
        CmbHeads.DataSource = ds.Tables("VuChart")
        CmbHeads.DisplayMember = "HeadName"
        CmbHeads.ValueMember = "HeadID"
    End Sub
    Private Sub CmbHeads_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbHeads.KeyDown
        If e.KeyCode = Keys.F1 Then
            'Dim frm As FrmFind
            'Dim frm As New FrmFind("SELECT HEADCODE as 'Head Code',HEADNAME as 'Head Name' FROM CHARTOFACC")
            FrmFind2.Obj = Me
            ' If FrmFind.Visible = True Then Exit Sub
            FrmFind2.Show()
        End If
    End Sub

    Private Sub BtnHeads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeads.Click

        Module1.DatasetFill("Select * from Chartofaccount where HeadID='" & Me.CmbHeads.Text & "'", "Chartofacc1")
        Dim drow As DataRow
        Module1.DeleteRecord("CashBook")

        Dim FromDate As Date = Module1.GetValue("FromDate", "FinancialPeriod", "Pid=N'" & Frm.LblPeriod.Text & "'")
        Dim ToDate As Date = Module1.GetValue("ToDate", "FinancialPeriod", "Pid=N'" & Frm.LblPeriod.Text & "'")
        Dim HeadIn As String = ""
        Dim AmountIn As Decimal = 0
        Dim HeadOut As String = ""
        Dim AmountOut As Decimal = 0
        Dim DrAdd As DataRow

        NewDS.Tables("CashBook").Clear()
        ' MsgBox(NewDS.Tables("CashBook").Rows.Count)

        For Each DrCompany As DataRow In ds.Tables("Company").Rows
            CashAmount = Module1.GetValue("Sum(Balance)", "VuTrial", "Pid=N'" & Frm.LblPeriod.Text & "' and VType='OB' and FullName=N'" & DrCompany.Item("Remarks") & "' and HeadName='Cash'")
            For Each drchart As DataRow In ds.Tables("Chartofacc1").Rows

                AmountIn = 0
                AmountOut = 0

                For Each drow In ds.Tables("VuGl").Rows
                    If drow("date") >= Me.DtHead1.Value And drow("date") <= Me.DtHead2.Value And drow("Vtype") = "Cash payment" And drow("HeadID") = drchart("HeadID") And DrCompany.Item("Remarks") = drow.Item("FullName") Then
                        AmountOut = AmountOut + drow("Dr")
                    End If

                    If drow("date") >= Me.DtHead1.Value And drow("date") <= Me.DtDate2.Value And drow("Vtype") = "'Cash Receipt'" And drow("HeadID") = drchart("HeadID") And DrCompany.Item("Remarks") = drow.Item("FullName") Then
                        AmountIn = AmountIn + drow("Cr")
                    End If

                Next


                'MsgBox(ds.Tables("VuGl").Rows.Count.ToString)


                If AmountIn <> 0 Or AmountOut <> 0 Then
                    'DrAdd = NewDS.Tables("CashBook").Rows.Add
                    DrAdd = NewDS.Tables("CashBook").NewRow
                    DrAdd.Item(0) = CashAmount
                    DrAdd.Item(1) = FromDate
                    DrAdd.Item(2) = ToDate
                    DrAdd.Item(3) = drchart(1).ToString & "  " & drchart(2).ToString
                    DrAdd.Item(4) = AmountIn
                    DrAdd.Item(5) = drchart(1).ToString & "  " & drchart(2).ToString
                    DrAdd.Item(6) = AmountOut
                    DrAdd.Item(7) = DrCompany("Remarks")
                    NewDS.Tables("CashBook").Rows.Add(DrAdd)
                    '           MsgBox(NewDS.Tables("CashBook").Rows.Count)


                End If


            Next
            '    MsgBox(NewDS.Tables("CashBook").Rows.Count)
        Next
        Dim CmdBuild1 As New SqlCommandBuilder(DASave)


        DASave.Update(NewDS, "CashBook")

        'Module1.InsertRecord("GlReport", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadID") & "','" & drow("HeadName") & "','" & drow("SubName") & "','" & drow("Remarks") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'")
        Call ReportShow()
    End Sub

    Sub ReportShow()
        Dim PField As New ParameterField
        Dim DSv As New ParameterDiscreteValue
        Dim ps As New ParameterFields
        Module1.DatasetFill("Select * from CashBook", "CashBook")
        Dim rpt As New RptCashBook
        rpt.SetDataSource(ds.Tables("CashBook"))

        PField.ParameterFieldName = "CompanyName"
        DSv.Value = CompanyNames
        PField.CurrentValues.Add(DSv)
        ps.Add(PField)

        CV.ParameterFieldInfo = ps
        CV.ReportSource = rpt

    End Sub

    Private Sub RBHeads_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBHeads.CheckedChanged
        PanDate.Visible = False
        Panel2.Visible = True
    End Sub

    Private Sub RBDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBDate.CheckedChanged
        PanDate.Visible = True
        Panel2.Visible = False
    End Sub

    Private Sub CV_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CV.DoubleClick
        If Panel1.Visible = False Then
            Panel1.Visible = True
            PanDate.Visible = True
            Panel2.Visible = True
            If RBHeads.Checked = True Then
                PanDate.Visible = False
                Panel2.Visible = False

            Else
                PanDate.Visible = False
                Panel2.Visible = False

            End If
        Else
            Panel1.Visible = False
            PanDate.Visible = False
            Panel2.Visible = False
        End If


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim drow As DataRow
        Module1.DeleteRecord("CashBook")

        Dim FromDate As Date = Module1.GetValue("FromDate", "FinancialPeriod", "Pid=N'" & Frm.LblPeriod.Text & "'")
        Dim ToDate As Date = Module1.GetValue("ToDate", "FinancialPeriod", "Pid=N'" & Frm.LblPeriod.Text & "'")
        Dim HeadIn As String = ""
        Dim AmountIn As Decimal = 0
        Dim HeadOut As String = ""
        Dim AmountOut As Decimal = 0
        Dim DrAdd As DataRow

        NewDS.Tables("CashBook").Clear()
        'MsgBox(NewDS.Tables("CashBook").Rows.Count)

        For Each DrCompany As DataRow In ds.Tables("Company").Rows
            CashAmount = Module1.GetValue("Sum(Balance)", "VuTrial", "Pid=N'" & Frm.LblPeriod.Text & "' and VType='OB' and FullName=N'" & DrCompany.Item("Remarks") & "' and HeadName='Cash'")
            For Each drchart As DataRow In ds.Tables("Chartofacc").Rows

                AmountIn = 0
                AmountOut = 0

                For Each drow In ds.Tables("VuGl").Rows
                    If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("Vtype") = "Cash payment" And drow("HeadID") = drchart("HeadID") And DrCompany.Item("Remarks") = drow.Item("FullName") Then
                        AmountOut = AmountOut + drow("Dr")
                    End If

                    If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow("Vtype") = "'Cash Receipt'" And drow("HeadID") = drchart("HeadID") And DrCompany.Item("Remarks") = drow.Item("FullName") Then
                        AmountIn = AmountIn + drow("Cr")
                    End If

                Next


                'MsgBox(ds.Tables("VuGl").Rows.Count.ToString)


                If AmountIn <> 0 Or AmountOut <> 0 Then
                    'DrAdd = NewDS.Tables("CashBook").Rows.Add
                    DrAdd = NewDS.Tables("CashBook").NewRow
                    DrAdd.Item(0) = CashAmount
                    DrAdd.Item(1) = FromDate
                    DrAdd.Item(2) = ToDate
                    DrAdd.Item(3) = drchart(1).ToString & "  " & drchart(2).ToString
                    DrAdd.Item(4) = AmountIn
                    DrAdd.Item(5) = drchart(1).ToString & "  " & drchart(2).ToString
                    DrAdd.Item(6) = AmountOut
                    DrAdd.Item(7) = DrCompany("Remarks")
                    NewDS.Tables("CashBook").Rows.Add(DrAdd)
                    '           MsgBox(NewDS.Tables("CashBook").Rows.Count)


                End If


            Next
            '    MsgBox(NewDS.Tables("CashBook").Rows.Count)
        Next
        Dim CmdBuild1 As New SqlCommandBuilder(DASave)


        DASave.Update(NewDS, "CashBook")

        'Module1.InsertRecord("GlReport", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadID") & "','" & drow("HeadName") & "','" & drow("SubName") & "','" & drow("Remarks") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'")
        Call ReportShow()
    End Sub




End Class
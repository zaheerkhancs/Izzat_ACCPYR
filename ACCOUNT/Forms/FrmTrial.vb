Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmTrial
    Public Compstr As String
    Dim CompanyNames As String
    Dim Fvisable As Boolean
    Dim Fieldvalue As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Module1.DatasetFill("Select * from VuChartofacc", "Chartofacc1")

        Dim drow As DataRow
        Dim HeadID As String
        Dim HeadName As String
        Dim CatTitle As String
        Dim fromDate As Date
        Dim ToDate As Date
        Dim OpenDr As Decimal
        Dim OPenCr As Decimal
        Dim PeriodDr As Decimal
        Dim PeriodCr As Decimal
        Dim CompanyName As String
        Dim OrderTrial As Integer = 0
        fromDate = Module1.GetValue("FromDate", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")
        ToDate = Module1.GetValue("ToDate", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")

        Module1.DeleteRecord("TrialBalance")
        Dim BalanOpen As Decimal
        Dim BalanPeriod As Decimal

       

        '       Dim dr As Decimal
        '        Dim cr As Decimal

        '   For Each DrCompany As DataRow In ds.Tables("Company").Rows

        For Each rw As DataRow In ds.Tables("Chartofacc1").Rows

            BalanOpen = 0
            BalanPeriod = 0
            OpenDr = 0
            OPenCr = 0
            PeriodDr = 0
            PeriodCr = 0

            HeadID = rw.Item("HeadID")
            HeadName = rw.Item("HeadName")
            CatTitle = rw.Item("CatTitle")
            OrderTrial = rw.Item("OrderTrial")
            For Each drow In ds.Tables("VuTrial").Rows
                If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow.Item("HeadID") = HeadID And drow.Item("Vtype") = "OB" Then
                    BalanOpen = BalanOpen + drow("Balance")
                End If

            Next
            For Each drow In ds.Tables("VuTrial").Rows
                If drow("date") >= Me.DtDate1.Value And drow("date") <= Me.DtDate2.Value And drow.Item("HeadID") = HeadID And drow.Item("Vtype") <> "OB" Then
                    BalanPeriod = BalanPeriod + drow("Balance")
                End If
            Next
            If BalanOpen < 0 Then
                OPenCr = Math.Abs(BalanOpen)
            ElseIf BalanOpen > 0 Then
                OpenDr = Math.Abs(BalanOpen)
            End If

            If BalanPeriod < 0 Then
                PeriodCr = Math.Abs(BalanPeriod)
            ElseIf BalanPeriod > 0 Then
                PeriodDr = Math.Abs(BalanPeriod)
            End If
            CompanyName = Frm.LBCompanyName.Text
            If OPenCr <> 0 Or OpenDr <> 0 Or PeriodCr <> 0 Or PeriodDr <> 0 Then
                Module1.InsertRecord("TrialBalance", "'" & fromDate & "','" & ToDate & "','" & HeadID & "','" & HeadName & "'," & OpenDr & "," & OPenCr & "," & PeriodDr & "," & PeriodCr & ",'" & CompanyName & "','" & CatTitle & "'," & OrderTrial)
            End If
        Next

        Fieldvalue = "From Date= " & Me.DtDate1.Text & " To Date =" & Me.DtDate2.Text
        '    Next
        Call ReportShow()
    End Sub

    Private Sub FrmTrial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        
        Module1.Opencn()
       
        'Panel1.Height = Me.Height - 40
        'Panel1.Width = Me.Width - 40

       

       
        Dim sts As Boolean

        Module1.DatasetFill("select * from CompannySetUp", "CompannySetUp")
        Module1.DatasetFill("select * from Company where Remarks in(" & Compstr & ")", "Company")

        CompanyNames = ds.Tables("CompannySetUp").Rows(0).Item(0)

        sts = Module1.GetValue("AccStatus", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")
        Module1.DatasetFill("Select * from GlReport", "GLReport")

        '''''''''''''''''''''''''''''for Crystal Report '''''''''''''''''''''''''''''''''''''''''''


        ' Call ReportShow()


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        'Module1.DatasetFill("Select * from VuPermission Where GroupID=" & Frm.GID.Text & " and PerName='Vouchers'", "VuPermission")
        'If ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
        '    Me.Close()
        '    MsgBox("You have no right to view this Form . For further detail contact your administrator", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Alert")
        '    Exit Sub


        Module1.DatasetFill("Select * from VuTrial where  FullName in(N" & Compstr & ") and PID=N'" & Frm.LblPeriod.Text & "' order by HeadID ", "VuTrial")
        Module1.DatasetFill("Select * from Chartofaccount", "Chartofacc")
        'CmbHeads.DataSource = ds.Tables("Chartofacc")
        'CmbHeads.ValueMember = "HeadName"
        'CmbHeads.DisplayMember = "HeadID"

        Me.Width = Frm.Width - 4
        Me.Height = Frm.Height - 4

        Me.Left = Frm.Left
        Me.Top = Frm.Top
        Module1.DatasetFill("Select * from AccountCategory", "AccountCategory")
        CmbHeads.DataSource = ds.Tables("AccountCategory")
        CmbHeads.DisplayMember = "CatTitle"
        CmbHeads.ValueMember = "CatID"
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

    Sub ReportShow()
        Dim PField As New ParameterField
        Dim DSv As New ParameterDiscreteValue
        Dim PField1 As New ParameterField
        Dim DSv1 As New ParameterDiscreteValue
        Dim ps As New ParameterFields
        Module1.DatasetFill("Select * from TrialBalance order by OrderTrial", "TrialBalance")
        Dim rpt As New RptTrialTitle
        rpt.SetDataSource(ds.Tables("TrialBalance"))

        PField.ParameterFieldName = "CompanyName"
        DSv.Value = CompanyNames
        PField.CurrentValues.Add(DSv)
        ps.Add(PField)
        PField1.ParameterFieldName = "FieldValue"
        DSv1.Value = Fieldvalue
        PField1.CurrentValues.Add(DSv1)
        ps.Add(PField1)

        CV.ParameterFieldInfo = ps
        CV.ReportSource = rpt
        Me.Left = 0
        Me.Top = 0

    End Sub
    Private Sub RBHeads_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBHeads.CheckedChanged
        PanDate.Visible = False
        Panel3.Visible = True
    End Sub

    Private Sub RBDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBDate.CheckedChanged
        PanDate.Visible = True
        Panel3.Visible = False
    End Sub

    Private Sub CV_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CV.DoubleClick
        If Fvisable = False Then
            PanDate.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            Fvisable = True

        Else
            PanDate.Visible = True
            Panel3.Visible = False
            Panel4.Visible = True
            Fvisable = False
        End If

        


    End Sub

    Private Sub BtnHeads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeads.Click

        Module1.DatasetFill("Select * from VuChartofacc where CatTitle=N'" & Me.CmbHeads.Text & "'", "Chartofacc1")

        Dim drow As DataRow
        Dim HeadID As String
        Dim HeadName As String
        Dim fromDate As Date
        Dim ToDate As Date
        Dim OpenDr As Decimal
        Dim OPenCr As Decimal
        Dim PeriodDr As Decimal
        Dim PeriodCr As Decimal
        Dim CompanyName As String
        Dim AccTitle As String
        Dim OrderTrial As Integer = 0
        fromDate = Module1.GetValue("FromDate", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")
        ToDate = Module1.GetValue("ToDate", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")

        Module1.DeleteRecord("TrialBalance")
        Dim BalanOpen As Decimal
        Dim BalanPeriod As Decimal
        '       Dim dr As Decimal
        '        Dim cr As Decimal
        For Each rw As DataRow In ds.Tables("Chartofacc1").Rows
            BalanOpen = 0
            BalanPeriod = 0
            OpenDr = 0
            OPenCr = 0
            PeriodDr = 0
            PeriodCr = 0
            HeadID = rw.Item("HeadID")
            HeadName = rw.Item("HeadName")
            AccTitle = rw.Item("CatTitle")
            OrderTrial = rw.Item("OrderTrial")
            ' For Each DrCompany As DataRow In ds.Tables("Company").Rows
            For Each drow In ds.Tables("VuTrial").Rows
                If drow("date") >= Me.DtHead1.Value And drow("date") <= Me.DtHead2.Value And drow.Item("HeadID") = rw.Item("HeadID") And drow.Item("Vtype") = "OB" Then
                    BalanOpen = BalanOpen + drow("Balance")
                End If

            Next
            For Each drow In ds.Tables("VuTrial").Rows
                If drow("date") >= Me.DtHead1.Value And drow("date") <= Me.DtHead2.Value And drow.Item("HeadID") = rw.Item("HeadID") And drow.Item("Vtype") <> "OB" Then
                    BalanPeriod = BalanPeriod + drow("Balance")
                End If
            Next
            If BalanOpen < 0 Then
                OPenCr = Math.Abs(BalanOpen)
            Else
                OpenDr = Math.Abs(BalanOpen)
            End If

            If BalanPeriod < 0 Then
                PeriodCr = Math.Abs(BalanPeriod)
            Else
                PeriodDr = Math.Abs(BalanPeriod)
            End If
            CompanyName = CompanyNames
            Module1.InsertRecord("TrialBalance", "'" & fromDate & "','" & ToDate & "','" & HeadID & "','" & HeadName & "'," & OpenDr & "," & OPenCr & "," & PeriodDr & "," & PeriodCr & ",'" & CompanyName & "','" & AccTitle & "'," & OrderTrial)
        Next

        Fieldvalue = " Sub Head Name= " & Me.CmbHeads.Text & " From Date= " & Me.DtHead1.Text & " To Date= " & Me.DtHead2.Text
        'Nextmnhh
        Call ReportShow()


    End Sub
End Class
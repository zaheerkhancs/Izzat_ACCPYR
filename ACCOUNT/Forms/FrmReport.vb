
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmReport
    Dim companyNames As String
    Public str As String
    Dim rpt As Object
    Public str2 As String
    Sub ReportShow()
        Dim PField As New ParameterField
        Dim DSv As New ParameterDiscreteValue
        Dim PField1 As New ParameterField
        Dim DSv1 As New ParameterDiscreteValue

        Dim ps As New ParameterFields
        Module1.DatasetFill("select * from CompannySetUp", "CompannySetUp")
        companyNames = ds.Tables("CompannySetUp").Rows(0).Item(0)
        'Module1.DatasetFill("Select * from GlReport", "GLReport")
        If ds.Tables("Setting2").Rows(0).Item(2) = True Then
            If FrmVoucher.GroupBox1.Text = "BANK RECEIPT" Then
                Dim RptBR As New RptVoucherBR
                rpt = RptBR

            ElseIf FrmVoucher.GroupBox1.Text = "BANK PAYMENT" Then
                Dim RptBp As New RptVoucherBP
                rpt = RptBp

            Else
                Dim rpt1 As New RptVoucher
                rpt = rpt1

            End If




        Else
            If FrmVoucher.GroupBox1.Text = "BANK RECEIPT" Then
                Dim RptBR As New RptVoucherBR
                rpt = RptBR

            ElseIf FrmVoucher.GroupBox1.Text = "BANK PAYMENT" Then
                Dim RptBp As New RptVoucherBP
                rpt = RptBp

            Else

                Dim rpt2 As New RptVoucherNoDate
                rpt = rpt2
            End If
        End If
        rpt.SetDataSource(ds.Tables("GlReport"))

        PField.ParameterFieldName = "CompanyName"
        DSv.Value = companyNames
        PField.CurrentValues.Add(DSv)

        PField1.ParameterFieldName = "WordTotal"
        DSv1.Value = FrmVoucher.LBlWords.Text
        PField1.CurrentValues.Add(DSv1)

        ps.Add(PField)
        ps.Add(PField1)

        CV.ParameterFieldInfo = ps
        CV.ReportSource = rpt

    End Sub

    Private Sub FrmReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call ReportShow()
    End Sub
End Class
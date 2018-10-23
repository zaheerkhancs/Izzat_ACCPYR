Public Class FrmFirst
    Sub ReportShow()

        Module1.DatasetFill("Select * from CompannySetUp", "CompannySetUp")
        Dim rpt As New RptIncome
        rpt.SetDataSource(ds.Tables("CompannySetUp"))
        CV.ReportSource = rpt

    End Sub

    Private Sub FrmFirst_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SendToBack()
        ReportShow()
    End Sub
End Class
Imports System.Windows.Forms

Public Class DfrmAdvancePaymentForReport
    Dim RptFrm As frmRptSetup
    Private Sub DfrmAdvancePaymentForReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()

        Module1.DatasetFill("Select * from VuEmp1", "VuEmp1")
        cmbEmpName.DataSource = ds.Tables("VuEmp1")
        cmbEmpName.DisplayMember = ("Name")
        cmbEmpName.ValueMember = ("EmpID")
        cmbEmpName.SelectedIndex = -1
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If cmbEmpName.Text = "" Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from VuAdvancePaymentGivenReport where EmpID=" & cmbEmpName.SelectedValue & " And dtDate Between '" & dtFrom.Value.Date.ToString & "' and '" & dtTo.Value.Date.ToString & "'", "VuAdvancePaymentGivenReport")
                Dim Rpt As New RptAdvancePaymentGiven
                Rpt.SetDataSource(Module1.ds.Tables("VuAdvancePaymentGivenReport"))
                frmRptSetup.CV.ReportSource = Rpt
                Frm.RptShow()
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class

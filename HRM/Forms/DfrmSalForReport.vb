Imports System.Windows.Forms

Public Class DfrmSalForReport
    Dim frmrpt As frmRptSetup
    Private Sub DfrmSalForReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        Module1.DatasetFill("Select * from VuEmp1", "VuEmp1")
        cmbEmpName.DataSource = ds.Tables("VuEmp1")
        cmbEmpName.DisplayMember = ("Name")
        cmbEmpName.ValueMember = ("EmpID")
        cmbEmpName.SelectedIndex = -1

        cmbYear.Text = "2008"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If cmbEmpName.Text = "" Or cmbMonth.Text = "" Or cmbYear.Text = "" Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from VuMonthlySalReport where EmpID = " & cmbEmpName.SelectedValue & " And Month='" & cmbMonth.Text & "' And Year = '" & cmbYear.Text & "'", "VuMonthlySalReport")
                Dim rpt As New RptMonthlySal
                rpt.SetDataSource(Module1.ds.Tables("VuMonthlySalReport"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class

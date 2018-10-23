Imports System.Windows.Forms

Public Class DFrmAttendenceSheet

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try

            Module1.DatasetFill("Select * from RptVuAttendanceSheet where dtDate between '" & dtFrom.Value.Date & "' and '" & dtTo.Value.Date & "'", "RptVuAttendanceSheet")
            Dim rpt As New RptAttendenceSheet
            rpt.SetDataSource(Module1.ds.Tables("RptVuAttendanceSheet"))
            frmRptSetup.CV.ReportSource = rpt
            Frm.RptShow()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub DFrmAttendenceSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtFrom.Value = Now
        dtTo.Value = Now
    End Sub
End Class

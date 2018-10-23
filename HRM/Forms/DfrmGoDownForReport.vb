Public Class DfrmGoDownForReport

    Private Sub DfrmGoDownForReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        Module1.DatasetFill("Select * from VuGoDownCombo", "VuGoDownCombo")
        cmbGoDownReport.DataSource = ds.Tables("VuGoDownCombo")
        cmbGoDownReport.DisplayMember = ("GoDownName")
        cmbGoDownReport.ValueMember = ("GoDownID")
        cmbGoDownReport.SelectedIndex = -1
        Clear(Me)
    End Sub
    Sub Clear(ByVal frm As Form)
        Dim z As Control
        For Each z In frm.Controls
            If TypeOf z Is TextBox Then
                z.Text = ""
            End If
        Next
    End Sub

    Private Sub cmbGoDownReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGoDownReport.SelectedIndexChanged
        Try
            Module1.DatasetFill("Select GoDownKepperName,GoDownPhone from VuGodown where GoDownID =" & cmbGoDownReport.SelectedValue & "", "VuGoDown")
            txtConcernPReport.Text = ds.Tables("VuGoDown").Rows(0).Item("GoDownKepperName")
            txtPhoneReport.Text = ds.Tables("VuGoDown").Rows(0).Item("GoDownPhone")
        Catch ex As Exception
            Clear(Me)
            cmbGoDownReport.SelectedIndex = -1
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If cmbGoDownReport.Text = "" Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from VuGodown where GoDownID =" & cmbGoDownReport.SelectedValue & "", "VuGoDown")
                Dim rpt As New RptGoDown
                rpt.SetDataSource(Module1.ds.Tables("VuGoDown"))
                frmRptSetup.CV.ReportSource = rpt
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
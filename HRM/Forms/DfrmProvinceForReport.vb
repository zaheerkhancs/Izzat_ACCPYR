Imports System.Windows.Forms

Public Class DfrmProvinceForReport
    Private Sub DfrmProvinceForReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()

        Module1.DatasetFill("Select * from VuProvinceCombo", "VuProvinceCombo")
        cmbProvinceReport.DataSource = ds.Tables("VuProvinceCombo")
        cmbProvinceReport.DisplayMember = ("ProvinceName")
        cmbProvinceReport.ValueMember = ("ProvinceID")
        cmbProvinceReport.SelectedIndex = -1
        Clear(Me)
    End Sub
    Sub Clear(ByVal frm As Form)
        Dim b As Control
        For Each b In frm.Controls
            If TypeOf b Is TextBox Then
                b.Text = ""
            End If
        Next
    End Sub

    Private Sub cmbProvinceReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvinceReport.SelectedIndexChanged
        Try

            Module1.DatasetFill("Select * from VuProvinceReport where ProvinceID=" & cmbProvinceReport.SelectedValue & "", "VuProvinceReport")
            txtConcernPName.Text = ds.Tables("VuProvinceReport").Rows(0).Item("ConcernPName")
            txtPhoneReport.Text = ds.Tables("VuProvinceReport").Rows(0).Item("Phone")

        Catch ex As Exception
            Clear(Me)
            cmbProvinceReport.SelectedIndex = -1
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If cmbProvinceReport.Text = "" Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from VuProvince where ProvinceID=" & cmbProvinceReport.SelectedValue & "", "VuProvince")
                Dim rpt As New RptProvinces
                rpt.SetDataSource(Module1.ds.Tables("VuProvince"))
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

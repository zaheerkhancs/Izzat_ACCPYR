Imports System.Windows.Forms

Public Class DfrmVendorForReport
    Dim abdullahazizkhanbachekhoobhasta As Boolean
    Private Sub DfrmVendorForReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        Module1.Opencn()
        abdullahazizkhanbachekhoobhasta = False
        Module1.DatasetFill("Select * from VuVendorCombo", "VuVendorCombo")
        cmbVendorReport.DataSource = ds.Tables("VuVendorCombo")
        cmbVendorReport.DisplayMember = ("Name")
        cmbVendorReport.ValueMember = ("VID")
        cmbVendorReport.SelectedIndex = -1
        abdullahazizkhanbachekhoobhasta = True
        Clear(Me)
    End Sub
    Sub Clear(ByVal frm As Form)
        Dim a As Control
        For Each a In frm.Controls
            If TypeOf a Is TextBox Then
                a.Text = ""
            End If
        Next
    End Sub

    Private Sub cmbVendorReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVendorReport.SelectedIndexChanged
        If abdullahazizkhanbachekhoobhasta = True Then
            Try
                Module1.DatasetFill("Select ConcernPName,Contact from VuVendorReport where VID=" & cmbVendorReport.SelectedValue & "", "VuVendorReport")
                txtConcernPReport.Text = ds.Tables("VuVendorReport").Rows(0).Item("ConcernPName")
                txtPhoneReport.Text = ds.Tables("VuVendorReport").Rows(0).Item("Contact")
            Catch ex As Exception
                Clear(Me)
            End Try
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If cmbVendorReport.Text = "" Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from VuVendor Where VID =" & cmbVendorReport.SelectedValue & "", "VuVendor")
                Dim rpt As New RptCompany
                rpt.SetDataSource(Module1.ds.Tables("VuVendor"))
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

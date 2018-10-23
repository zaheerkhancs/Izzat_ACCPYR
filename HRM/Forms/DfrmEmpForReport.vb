Imports System.Windows.Forms

Public Class DfrmEmpForReport
    Private Sub DfrmEmpForReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()

        Module1.DatasetFill("Select * from VuEmp1", "VuEmp1")
        cmbEmpName.DataSource = ds.Tables("VuEmp1")
        cmbEmpName.DisplayMember = ("Name")
        cmbEmpName.ValueMember = ("EmpID")
        cmbEmpName.SelectedIndex = -1
    End Sub
    Sub Clear(ByVal frm As DfrmEmpForReport)
        Dim A As Control
        For Each A In frm.Controls
            If TypeOf A Is TextBox Then
                A.Text = ""
            ElseIf TypeOf A Is ComboBox Then
                A.Text = ""
            End If
        Next
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub cmbEmpName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpName.SelectedIndexChanged
        Try
            Module1.DatasetFill("Select FName,DepName,JobTitle from VuEmpReport where EmpID=" & cmbEmpName.SelectedValue & "", "VuEmpReport")
            txtFatherName.Text = ds.Tables("VuEmpReport").Rows(0).Item("FName")
            txtDepartment.Text = ds.Tables("VuEmpReport").Rows(0).Item("DepName")
            txtJobTitle.Text = ds.Tables("VuEmpReport").Rows(0).Item("JobTitle")
        Catch ex As Exception
            Clear(Me)
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If cmbEmpName.Text = "" Then
                Exit Sub
            Else

                Module1.DatasetFill("Select * from VuEmpReport where EmpID=" & cmbEmpName.SelectedValue & "", "VuEmpReport")
                Dim rpt As New RptEmp
                rpt.SetDataSource(Module1.ds.Tables("VuEmpReport"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class

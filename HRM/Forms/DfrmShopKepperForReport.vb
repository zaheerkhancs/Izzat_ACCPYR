Imports System.Windows.Forms

Public Class DfrmShopKepperForReport

    Private Sub DfrmShopKepperForReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.DatasetFill("Select * from VuShopCombo", "VuShopCombo")
        cmbShopReport.DataSource = ds.Tables("VuShopCombo")
        cmbShopReport.DisplayMember = ("ShopName")
        cmbShopReport.ValueMember = ("ShopID")
        cmbShopReport.SelectedIndex = -1
        Clear(Me)
    End Sub
    Sub Clear(ByVal frm As Form)
        Dim m As Control
        For Each m In frm.Controls
            If TypeOf m Is TextBox Then
                m.Text = ""
            End If
        Next
    End Sub

    Private Sub cmbShopReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShopReport.SelectedIndexChanged
        Try

            Module1.DatasetFill("Select ConcernPName,Phone,STypeName from VuShop where ShopID=" & cmbShopReport.SelectedValue & "", "VuShop")
            txtConcernPReport.Text = ds.Tables("VuShop").Rows(0).Item("ConcernPName")
            txtPhoneReport.Text = ds.Tables("VuShop").Rows(0).Item("Phone")
            txtSaleType.Text = ds.Tables("VuShop").Rows(0).Item("STypeName")

        Catch ex As Exception
            Clear(Me)
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If cmbShopReport.Text = "" Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from VuShop where ShopID=" & cmbShopReport.SelectedValue & "", "VuShop")
                Dim rpt As New RptShop
                rpt.SetDataSource(Module1.ds.Tables("VuShop"))
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

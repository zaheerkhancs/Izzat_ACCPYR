
Public Class FrmImpHeads


    Private Sub FrmImpHeads_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Module1.DatasetFill("Select * from VuChart", "Chartofacc")
        Module1.DatasetFill("Select * from VuChart", "Chartofacc1")
        Module1.DatasetFill("Select * from VuChart", "Chartofacc2")

        Module1.DatasetFill("Select * from VuChart", "Chartofacc3")
        Module1.DatasetFill("Select * from VuChart", "Chartofacc4")
        Module1.DatasetFill("Select * from VuChart", "Chartofacc5")
        Module1.DatasetFill("Select * from VuChart", "Chartofacc6")
        Module1.DatasetFill("Select * from VuChart", "Chartofacc7")
        Module1.DatasetFill("Select * from VuChart", "Chartofacc8")
        Module1.DatasetFill("Select * from VuChart", "Chartofacc9")

        Me.CmbCash.DataSource = ds.Tables("Chartofacc")
        Me.CmbCash.ValueMember = "HeadID"
        Me.CmbCash.DisplayMember = "HeadName"

        Me.CmbIncome.DataSource = ds.Tables("Chartofacc1")
        Me.CmbIncome.ValueMember = "HeadID"
        Me.CmbIncome.DisplayMember = "HeadName"



        Me.CmbCapital.DataSource = ds.Tables("Chartofacc2")
        Me.CmbCapital.ValueMember = "HeadID"
        Me.CmbCapital.DisplayMember = "HeadName"


        Me.CmbCustomer.DataSource = ds.Tables("Chartofacc3")
        Me.CmbCustomer.ValueMember = "HeadID"
        Me.CmbCustomer.DisplayMember = "HeadName"

        Me.CmbPurchase.DataSource = ds.Tables("Chartofacc4")
        Me.CmbPurchase.ValueMember = "HeadID"
        Me.CmbPurchase.DisplayMember = "HeadName"
        Me.CmbSale.DataSource = ds.Tables("Chartofacc5")
        Me.CmbSale.ValueMember = "HeadID"
        Me.CmbSale.DisplayMember = "HeadName"

        Me.CmbSupplier.DataSource = ds.Tables("Chartofacc6")
        Me.CmbSupplier.ValueMember = "HeadID"
        Me.CmbSupplier.DisplayMember = "HeadName"

        Me.cmbEmployee.DataSource = ds.Tables("Chartofacc7")
        Me.cmbEmployee.ValueMember = "HeadID"
        Me.cmbEmployee.DisplayMember = "HeadName"

        Me.cmbDiscount.DataSource = ds.Tables("Chartofacc8")
        Me.cmbDiscount.ValueMember = "HeadID"
        Me.cmbDiscount.DisplayMember = "HeadName"

        Me.cmbExpense.DataSource = ds.Tables("Chartofacc9")
        Me.cmbExpense.ValueMember = "HeadID"
        Me.cmbExpense.DisplayMember = "HeadName"

        Module1.DatasetFill("Select * from ImpHeads where CompanyID=" & Frm.LBCompanyID.Text, "ImpHeads")
        Call txtfill()
    End Sub
    Sub txtfill()
        Try
            Me.CmbCash.SelectedValue = ds.Tables("Impheads").Rows(0).Item(0)
            Me.CmbIncome.SelectedValue = ds.Tables("Impheads").Rows(0).Item(1)
            Me.CmbCapital.SelectedValue = ds.Tables("Impheads").Rows(0).Item(2)

            Me.CmbSupplier.SelectedValue = ds.Tables("Impheads").Rows(0).Item(3)
            Me.CmbCustomer.SelectedValue = ds.Tables("Impheads").Rows(0).Item(4)
            Me.CmbSale.SelectedValue = ds.Tables("Impheads").Rows(0).Item(5)

            Me.CmbPurchase.SelectedValue = ds.Tables("Impheads").Rows(0).Item(6)
            Me.cmbEmployee.SelectedValue = ds.Tables("Impheads").Rows(0).Item(8)

            Me.cmbDiscount.SelectedValue = ds.Tables("Impheads").Rows(0).Item(9)

            Me.cmbExpense.SelectedValue = ds.Tables("Impheads").Rows(0).Item(10)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If ds.Tables("ImpHeads").Rows.Count = 0 Then
            Module1.InsertRecord("Impheads", "'" & CmbCash.SelectedValue & "','" & CmbIncome.SelectedValue & "','" & CmbCapital.SelectedValue & "','" & CmbSupplier.SelectedValue & "','" & CmbCustomer.SelectedValue & "','" & CmbSale.SelectedValue & "','" & CmbPurchase.SelectedValue & "',0,'" & cmbEmployee.SelectedValue & "','" & cmbDiscount.SelectedValue & "','" & cmbExpense.SelectedValue & "','" & Frm.LBCompanyID.Text & "'")
        Else
            Module1.UpdateRecord("Impheads", "CashCode='" & CmbCash.SelectedValue & "',RevenueCode='" & CmbIncome.SelectedValue & "',CapitalCode='" & CmbCapital.SelectedValue & "', vendorSuccode='" & CmbSupplier.SelectedValue & "', CustoSubCode='" & CmbCustomer.SelectedValue & "', SalesCode='" & CmbSale.SelectedValue & "', RpurchaseCode='" & CmbPurchase.SelectedValue & "',EmployeeCode='" & cmbEmployee.SelectedValue & "',DiscountCode='" & cmbDiscount.SelectedValue & "',ExpenseCode='" & cmbExpense.SelectedValue & "'", "CompanyID=" & Frm.LBCompanyID.Text)
        End If
        '  MsgBox(ds.Tables("ImpHeads").Rows.Count - 1)
        MsgBox("Your Record has been saved successfully.")
    End Sub
End Class
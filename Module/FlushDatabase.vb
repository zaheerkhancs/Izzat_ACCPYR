Public Class FlushDatabase
    Dim counter As Integer = 0
    Private Sub FlushDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        chkbxSelectAll.Visible = False
        txtPinCode.Focus()
    End Sub

    Private Sub FillAllTableNamesOfAccounts()
        DG.Rows.Clear()
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim fahim As String
        fahim = "Account_Section_Is_not_Allowed_Now,"
        fahim += "Sorry"

        Dim arrTable() As String
        arrTable = Split(fahim, ",")

        While a < arrTable.Length
            ' - 1 because index was going out of range.
            DG.Rows.Add()
            DG.Rows(a).Cells(1).Value = "Accounts"
            DG.Rows(a).Cells(2).Value = arrTable(b)
            a += 1
            b += 1
        End While
        chkbxSelectAll.Visible = True
        btnClearTables.Visible = True
        Try
            While a < arrTable.Length - 1
                ' - 1 because index was going out of range.
                DG.Rows.Add()
                DG.Rows(a).Cells(1).Value = "Accounts"
                DG.Rows(a).Cells(2).Value = arrTable(b)
                a += 1
                b += 1
            End While
     
        Catch ex As Exception
         
        End Try
        chkbxSelectAll.Visible = True
        btnClearTables.Visible = True
    End Sub
    Private Sub FillAllTableNamesOfStock()
        DG.Rows.Clear()
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim fahim As String
        fahim = "BiltyInfo,ChequeMain,ChequeDetail,ClaimMain,ClaimDetail,DamageMain,DamageDetail,OrderEnglishMain,OrderEnglishDetail,OrderFromCustomerMain,OrderFromCustomerDetail,OrderMain,OrderDetail,PurchaseMain,PurchaseDetail,PurchasePayment,PurchaseSubDetail,ReturnMain,ReturnDetail,ReturnPayment,SaleMain,SaleDetail,SalePayment,SaleSubDetail,SaleMainOfSaleMan,SaleDetailOfSaleMan"
        ' The following tables are not added.
        'Weight,Product,ProductType,Customer,
        Dim arrTable() As String
        arrTable = Split(fahim, ",")
        Try
            While a < arrTable.Length
                ' - 1 because index was going out of range.
                DG.Rows.Add()
                DG.Rows(a).Cells(1).Value = "Stock"
                DG.Rows(a).Cells(2).Value = arrTable(b)
                a += 1
                b += 1
            End While
           
        Catch ex As Exception
        
        End Try

        chkbxSelectAll.Visible = True
        btnClearTables.Visible = True
    End Sub
    Private Sub FillAllTableNamesOfHRM()
        DG.Rows.Clear()
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim fahim As String
        fahim = "Contract,AllowancesMain," _
        & "DeductionMain,EmpAdvancePaymentGiven,EmpAdvancePaymentRecieved,EmpPerInfo,GoDown,MonthlySal,MontlySalAll," _
        & "MonthlySalDed,Province"
        ' The following tables are not added.
        'Shop,Vendor,JobTitle,Location,Nationality,Religion,ShopType,
        Dim arrTable() As String
        arrTable = Split(fahim, ",")

       
        Try
            While a < arrTable.Length
                ' - 1 because index was going out of range.
                DG.Rows.Add()
                DG.Rows(a).Cells(1).Value = "HRM"
                DG.Rows(a).Cells(2).Value = arrTable(b)
                a += 1
                b += 1
            End While
           
        Catch ex As Exception
         
        End Try
        chkbxSelectAll.Visible = True
        btnClearTables.Visible = True
    End Sub
    Private Sub txtPinCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPinCode.KeyPress
        If e.KeyChar = Chr(13) Then

            If Not txtPinCode.Text.Equals(txtConfirmPinCode.Text) Then

                MessageBox.Show(" --- Pin Code does not match ! --- ", "Pin Code Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
                txtPinCode.Text = ""
                txtConfirmPinCode.Text = ""
                txtPinCode.Focus()

            Else

                If (txtPinCode.Text.Equals("weldoneboss!")) Then

                    DG.Visible = True
                    btnClearTables.Visible = True
                    chkbxSelectAll.Visible = True
                    lblMsg.Visible = True
                    txtPinCode.Visible = False
                    txtConfirmPinCode.Visible = False
                    label1.Visible = False
                    label2.Visible = False


                End If
            End If
        End If
    End Sub

    Private Sub btnClearTables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearTables.Click
        Dim done As Boolean = False
        'Commented statement were because of checking the functionality.
        For Each dgrow As DataGridViewRow In DG.Rows

            Try

                If dgrow.Cells(0).Value.Equals(True) Then

                    done = False
                    Dim NameOfCheckedTable As String = dgrow.Cells(2).Value
                    'MessageBox.Show( NameOfCheckedTable + " is Checked")

                    Module1.DeleteRecord(NameOfCheckedTable)


                    dgrow.Cells(3).Value = " Cleared"

                    done = True  

                Else

                    counter = counter + 1
                    ' string NameOfUncheckedTable = dgrow.Cells[2].Value.ToString();
                    'MessageBox.Show( NameOfUncheckedTable  + " is Unchecked");

                End If
            Catch ex As Exception

                'If done.Equals(False) Then

                '    DG.RowsDefaultCellStyle.ForeColor = Color.Red
                '    dgrow.Cells(3).Value = " Cleaning Failed"

                '    done = True
                '    counter = counter + 1

                '    'MessageBox.Show("Unchecked error");
                'End If

            End Try

        Next
        'If counter.Equals(0) Then

        '    lblMsg.ForeColor = Color.Green
        '    lblMsg.Text = " All tables are cleared successfully! "

        'Else

        '    lblMsg.ForeColor = Color.Red
        '    lblMsg.Text = " Some of your tables were not cleared."
        'End If

    End Sub

    Private Sub chkbxSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxSelectAll.CheckedChanged
        Try

            For Each dgrowToCheck As DataGridViewRow In DG.Rows

                Try

                    If chkbxSelectAll.Checked.Equals(True) Then


                        dgrowToCheck.Cells(0).Value = True

                    Else

                        dgrowToCheck.Cells(0).Value = False

                    End If
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception



        End Try
    End Sub


    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Me.Close()
    End Sub

    Private Sub RDAccounts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDAccounts.CheckedChanged
        If RDAccounts.Checked = True Then
            chkbxSelectAll.Checked = False
            FillAllTableNamesOfAccounts()
        End If
    End Sub

    Private Sub RDStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDStock.CheckedChanged
        If RDStock.Checked = True Then
            chkbxSelectAll.Checked = False
            FillAllTableNamesOfStock()
        End If
    End Sub

    Private Sub RDHRM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDHRM.CheckedChanged
        If RDHRM.Checked = True Then
            chkbxSelectAll.Checked = False
            FillAllTableNamesOfHRM()
        End If
    End Sub

    Private Sub RDEmpty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDEmpty.CheckedChanged
        If RDEmpty.Checked = True Then
            chkbxSelectAll.Checked = False
            DG.Rows.Clear()
            chkbxSelectAll.Visible = False
            btnClearTables.Visible = False
        End If
    End Sub

 
    Private Sub DoAction2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        sender.ForeColor = Color.Red
    End Sub

    Private Sub DoAction1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        sender.ForeColor = Color.Green

    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Try

        
            If e.ColumnIndex = 3 Then
                If DG.CurrentRow.Cells(e.ColumnIndex).Value = " Cleared" Then
                    sender.ForeColor = Color.Blue
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        If DG.CurrentCell.ColumnIndex = 3 Then
            Dim ltxt As New TextBox
            ltxt = CType(e.Control, TextBox)
            AddHandler ltxt.KeyPress, AddressOf DoAction1
        Else
            Dim ltxt As New TextBox
            ltxt = CType(e.Control, TextBox)
            AddHandler ltxt.KeyPress, AddressOf DoAction2
        End If

    End Sub

    Private Sub DG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellContentClick

    End Sub
End Class
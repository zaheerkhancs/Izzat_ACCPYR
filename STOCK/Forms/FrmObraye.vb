Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmObraye
    Dim i As Integer = 0
    Dim Arr_DGRowsClicked As New ArrayList
    Dim j As Integer = 0 ' For Search Section
    Dim Arr_DGSearchRowsClicked As New ArrayList ' For Seach Section
    Dim EditValue As Integer
    Dim Var_ObrayeID As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim a As Integer
    Dim cnt As Integer
    Dim CallFrom As String
    Dim AddEdit As Boolean
    Dim AccountID As String
    Dim CurrentRowSelected As Integer
    Dim CashCode As String
    Dim CustomerCode As String
#Region "Fahimshekaib Special ComboFiller"
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As ComboBox, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)

        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As DataGridViewComboBoxColumn, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        ComboName.DataSource = Nothing
        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
#End Region

    Private Sub FrmObraye_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Me.MaximizeBox = False
        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.DatasetFill("Select * from Location", "Location")
        Module1.DatasetFill("Select * from Customer where CustomerTypeID = 1", "Customer")
        Module1.DatasetFill("Select * from Shop", "Shop")
        Call ComboFillerOfFahimshekaib(cmbLocation, "Location", "LocName", "LocID")
        Call ComboFillerOfFahimshekaib(DGcmbLocation, "Location", "LocName", "LocID")
        Call ComboFillerOfFahimshekaib(cmbLocationSearch, "Customer", "CustomerName", "CustomerID")
        Call ComboFillerOfFahimshekaib(cmbShopName, "Shop", "ShopName", "ShopID")
        Call ComboFillerOfFahimshekaib(cmbShopKeeperName, "Shop", "ConcernPName", "ShopID")

        Call ComboFillerOfFahimshekaib(DGcmbShopName, "Shop", "ShopName", "ShopID")
        Call ComboFillerOfFahimshekaib(DGShopNameSearch, "Shop", "ShopName", "ShopID")
        Call ComboFillerOfFahimshekaib(DGSSShopName, "Shop", "ShopName", "ShopID")
        txtPaid.Text = 0
        txtfill()
        DisableFewControls()
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
     

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        ''''''I commented the old Detail wala Report, but I am not going to remove it from the project, we have to learn how to show the detail of a record.
        '' '' ''Try
        '' '' ''    If DGSearch.RowCount = 0 Then
        '' '' ''        Exit Sub
        '' '' ''    Else
        '' '' ''        'Dim u As Integer = 0
        '' '' ''        'For Each dtrow As DataColumn In ds.Tables("VusearchforObraye").Columns
        '' '' ''        '    MsgBox(dtrow.ColumnName)
        '' '' ''        '    u = u + 1
        '' '' ''        'Next
        '' '' ''        'MsgBox(ds.Tables("VuSearchForObraye").Rows.Count)
        '' '' ''        ' Query will be filled from jostojo button.

        '' '' ''        Dim rpt As New RptObrayeSaleMan
        '' '' ''        rpt.SetDataSource(Module1.ds.Tables("VuSearchForObraye"))
        '' '' ''        frmRptSetup.CV.ReportSource = rpt
        '' '' ''        Frm.RptShow()
        '' '' ''        'Me.Close()

        '' '' ''    End If
        '' '' ''Catch ex As Exception

        '' '' ''End Try
        Try
            Module1.DeleteRecord("ObrayeReportForSaleman")
            SaveIntoObrayeReportForSaleman_Table()
            Call PrintReport()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub
    Sub SaveIntoObrayeReportForSaleman_Table()

        Dim x As Integer = 0
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateObrayeReportForSaleman"
        cmdsaveGrid.Connection = cn
        Try
            For Each dgro As DataGridViewRow In DGSearch.Rows
                cmdsaveGrid.Parameters.Add("@SNo", SqlDbType.Int).Value = DGSearch.Rows(x).Cells("DGSearchSNo").Value
                Try
                    'Checking if data is available for this field for not.
                    Dim ShopNameSearch As String = DGSearch.Rows(x).Cells("DGShopNameSearch").FormattedValue
                    If ShopNameSearch = Nothing Then
                        cmdsaveGrid.Parameters.Add("@ShopName", SqlDbType.NVarChar).Value = ""

                    Else
                        cmdsaveGrid.Parameters.Add("@ShopName", SqlDbType.NVarChar).Value = DGSearch.Rows(x).Cells("DGShopNameSearch").FormattedValue

                    End If

                Catch ex As Exception

                End Try
                Try
                    'Checking if data is available for this field for not.
                    Dim ShopKeeperNameSearch As String = DGSearch.Rows(x).Cells("DGShopKeeperNameSearch").FormattedValue
                    If ShopKeeperNameSearch = Nothing Then
                        cmdsaveGrid.Parameters.Add("@ShopKeeperName", SqlDbType.NVarChar).Value = ""
                    Else
                        cmdsaveGrid.Parameters.Add("@ShopKeeperName", SqlDbType.NVarChar).Value = DGSearch.Rows(x).Cells("DGShopKeeperNameSearch").Value
                    End If

                Catch ex As Exception

                End Try
                Try
                    'Checking if data is available for this field for not.
                    Dim AddressSearch As String = DGSearch.Rows(x).Cells("DGAddressSearch").FormattedValue
                    If AddressSearch = Nothing Then
                        cmdsaveGrid.Parameters.Add("@Address", SqlDbType.NVarChar).Value = ""
                    Else
                        cmdsaveGrid.Parameters.Add("@Address", SqlDbType.NVarChar).Value = DGSearch.Rows(x).Cells("DGAddressSearch").Value
                    End If
                    cmdsaveGrid.Parameters.Add("@Remaining", SqlDbType.Decimal).Value = DGSearch.Rows(x).Cells("DGBaqayaSearch").Value

                    cmdsaveGrid.Parameters.Add("@Paid", SqlDbType.VarChar).Value = ""
                    cmdsaveGrid.Parameters.Add("@Balance", SqlDbType.Decimal).Value = DGSearch.Rows(x).Cells("DGBalanceSearch").Value
                    cmdsaveGrid.Parameters.Add("@CounterForObraye", SqlDbType.Int).Value = DGSearch.Rows(x).Cells("DGCounterForObrayeSearch").Value
                Catch ex As Exception

                End Try

                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
                x += 1
                '
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub PrintReport()
        Module1.DatasetFill("Select * from ObrayeReportForSaleman", "ObrayeReportForSaleman")

        'Module1.DatasetFill("Select * from RptVuProduct where ProdCode=" & txtID.Text, "RptVuProduct")
        Dim rpt As New RptObrayeOfSaleman
        rpt.SetDataSource(Module1.ds.Tables("ObrayeReportForSaleman"))
        frmRptSetup.CV.ReportSource = rpt
        Frm.RptShow()
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDisplayShops_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayShops.Click
        Module1.DatasetFill("Select ShopName,ConcernPName,ShopID,Address from VuShop where LocID=" & cmbLocation.SelectedValue, "VuShop")
        ComboFillerOfFahimshekaib(cmbShopName, "VuShop", "ShopName", "ShopID")
        ComboFillerOfFahimshekaib(cmbShopKeeperName, "VuShop", "ConcernPName", "ShopID")
        cmbShopName_SelectedIndexChanged(cmbShopName, e)
        If cmbShopName.Items.Count = 0 Then
            cmbShopKeeperName.Text = ""
            txtAddress.Text = ""
            txtRemaining.Text = ""

        End If

    End Sub
#Region "Search Section"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim j As Integer
        DGSearch.Rows.Clear()
        DGSearchSub.Rows.Clear()
        DGObPaid.Rows.Clear()
        txtBalanceSearch.Text = 0
        txtBalanceSearchInv.Text = 0
        txtBalanceSearchObPaid.Text = 0
        If RBSearchLocation.Checked.Equals(True) Then
            If chkFixedLocation.Checked.Equals(True) Then
                Module1.DatasetFill("Select Distinct(ShopID), Sum(Balance) as Balance,CounterForObraye from VuSearchForObraye where LocID = " & cmbLocationSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By ShopID,CounterForObraye", "VuSearchForObraye")
                Module1.DatasetFill("Select Distinct(ShopID), Sum(Balance) as Balance,CounterForObraye,ShopName,ConcernPName from RptVuObrayeOfSaleman where LocID = " & cmbLocationSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By ShopID,CounterForObraye", "RptVuObrayeOfSaleman")

            Else
                Module1.DatasetFill("Select Distinct(ShopID), Sum(Balance) as Balance,CounterForObraye from VuSearchForObraye where SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By ShopID,CounterForObraye", "VuSearchForObraye")
                Module1.DatasetFill("Select Distinct(ShopID), Sum(Balance) as Balance,CounterForObraye,ShopName,ConcernPName from RptVuObrayeOfSaleman where LocID = " & cmbLocationSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By ShopID,CounterForObraye", "RptVuObrayeOfSaleman")

            End If
        Else
            If chkFixedLocation.Checked.Equals(True) Then
                Module1.DatasetFill("Select Distinct(ShopID), Sum(Balance) as Balance,CounterForObraye from VuSearchForObraye where CustomerID = " & cmbLocationSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By ShopID,CounterForObraye", "VuSearchForObraye")
                Module1.DatasetFill("Select Distinct(ShopID), Sum(Balance) as Balance,CounterForObraye,ShopName,ConcernPName from RptVuObrayeOfSaleman where CustomerID = " & cmbLocationSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By ShopID,CounterForObraye,ShopName,ConcernPName", "RptVuObrayeOfSaleman")

            Else
                Module1.DatasetFill("Select Distinct(ShopID), Sum(Balance) as Balance,CounterForObraye from VuSearchForObraye where SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By ShopID,CounterForObraye", "VuSearchForObraye")
                Module1.DatasetFill("Select Distinct(ShopID), Sum(Balance) as Balance,CounterForObraye,ShopName,ConcernPName from RptVuObrayeOfSaleman where CustomerID = " & cmbLocationSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By ShopID,CounterForObraye", "RptVuObrayeOfSaleman")

            End If
        End If
        For Each drow As DataRow In ds.Tables("VuSearchForObraye").Rows
            DGSearch.Rows.Add()
            DGSearch.Rows(j).Cells("DGSearchSNo").Value = j + 1
            DGSearch.Rows(j).Cells("DGShopNameSearch").Value = drow("ShopID")
            For Each datarowOfShop As DataRow In ds.Tables("Shop").Rows
                If datarowOfShop.Item("ShopID") = drow("ShopID") Then
                    DGSearch.Rows(j).Cells("DGShopKeeperNameSearch").Value = datarowOfShop("ConcernPName")
                    DGSearch.Rows(j).Cells("DGAddressSearch").Value = datarowOfShop("Address")
                End If
            Next
            DGSearch.Rows(j).Cells("DGRasidSearch").Value = ""
            '>>>>>>>>>>>>>>>>>>>>>>>>>
            Dim remainingFromSaleMain As Decimal = Convert.ToDecimal(drow("Balance"))
            '>>
            'The following code was made just incase it may happen that it get the name of the shop instead of the ID
            'due to its bad habit , so it this case we can place ShopID variable instead in the following datasetfill.
            'but for the time let it be comment because it works as it is.
            'Dim ShopID As Integer = 0
            'For Each dtr As DataRow In ds.Tables("Shop").Rows
            '    If dtr.Item("ShopName") = DGSearch.Rows(j).Cells("DGShopNameSearch").FormattedValue Then
            '        ShopID = dtr.Item("ShopID")
            '    End If
            'Next
            Module1.DatasetFill("Select Sum(Paid) as 'TotalPaid' from VuObrayeDetailForSearchSaleman where ShopID = " & DGSearch.Rows(j).Cells("DGShopNameSearch").Value, "VuObrayeDetailForSearchSaleman")

            Dim PaidAmountInObraye As Decimal = IIf(ds.Tables("VuObrayeDetailForSearchSaleman").Rows(0).Item("TotalPaid").Equals(DBNull.Value) = True, 0, ds.Tables("VuObrayeDetailForSearchSaleman").Rows(0).Item("TotalPaid"))
            DGSearch.Rows(j).Cells("DGBaqayaSearch").Value = remainingFromSaleMain - PaidAmountInObraye
            '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 
            DGSearch.Rows(j).Cells("DGBalanceSearch").Value = DGSearch.Rows(j).Cells("DGBaqayaSearch").Value
            Module1.DatasetFill("Select Max(CounterForObraye) as 'LastCounteryForObraye' from VuObrayeDetailForSearchSaleman where ShopID = " & DGSearch.Rows(j).Cells("DGShopNameSearch").Value & " And ObrayeDate =(Select Max(ObrayeDate) from VuObrayeDetailForSearchSaleman where ShopID = " & DGSearch.Rows(j).Cells("DGShopNameSearch").Value & ")", "VuObrayeDetailForSearchSaleman")

            DGSearch.Rows(j).Cells("DGCounterForObrayeSearch").Value = ds.Tables("VuObrayeDetailForSearchSaleman").Rows(0).Item("LastCounteryForObraye")
            'DGSearch.Rows(j).Cells("DGPaidSearch").Value = drow(5)
            'DGSearch.Rows(j).Cells("DGBalanceSearch").Value = drow(6)
            j = j + 1
        Next
        CalculationOfObrayeSearch()
    End Sub
    Private Sub DGSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellDoubleClick

        ' This piece of code is added after the following commented lines are written.
        For Each dgrow As DataGridViewRow In DGSearch.Rows
            dgrow.DefaultCellStyle.BackColor = Color.White
        Next
        DGSearch.CurrentRow.DefaultCellStyle.BackColor = Color.Orange

        ' Get the data from SaleMain of those records which relates to this customer with balance>0
        'Before this I was using this grid to keep doubleclicking and getting the detail of one after another Person's record in grid.but now I added the following like DGSearchSub.rows.clear() 
        ' so that I get one one persons detail at a time, nothing has been changed in previous code, one you can comment the DGSearchSub.rows.clear() line and it will work like before.Also You should remove the DGOBPaid.rows.clear()
        'And Yes,    j = DGSearchSub.Rows.Count should be uncommented while j = 0 should be commented.
        ' For the time being I also commented the color check portion and would like to make the background of only doubleclicked row orange. 
        DGSearchSub.Rows.Clear()
        DGObPaid.Rows.Clear()
        DGSubInv_Balance()
        'Get data from Obraye of those records which relates to this customer.
        DGSubObrPaid_Detail()

        '>>>>>>>>>>>>>>>>>>>>>1
   
    End Sub
    Private Sub DGSubInv_Balance()
        Dim a As Integer
        'j = DGSearchSub.Rows.Count
        j = 0
        'Try
        '    If Not Arr_DGSearchRowsClicked.Count = 0 Then
        '        For a = 0 To Arr_DGSearchRowsClicked.Count - 1
        '            If a = DGSearch.CurrentRow.Index Then
        '                If Not DGSearch.CurrentRow.DefaultCellStyle.BackColor = Color.Orange Then
        '                Else
        '                    Exit Sub
        '                End If

        '            End If

        '        Next
        '    End If
        'Catch ex As Exception

        'End Try
        Try
            ' Dim s As Integer = DGSub.Rows.Count
            Arr_DGSearchRowsClicked.Add(DGSearch.CurrentRow.Index)
            DGSearch.CurrentRow.DefaultCellStyle.BackColor = Color.Orange

            Module1.DatasetFill("Select InvoiceNo,ShopID,Balance,CounterForObraye from  VuSaleMainOfSaleManForObrayeDetail where ShopID =" & DGSearch.CurrentRow.Cells("DGShopNameSearch").Value & " And Balance>0 And SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "'", "VuSaleMainOfSaleManForObrayeDetail")
            'Dim i As Integer = 0
            'DGSub.Rows.Clear()
            For Each datarow As DataRow In ds.Tables("VuSaleMainOfSaleManForObrayeDetail").Rows
                DGSearchSub.Rows.Add()
                DGSearchSub.Rows(j).Cells("DGSSSNo").Value = DGSearchSub.Rows(j).Index + 1
                DGSearchSub.Rows(j).Cells("DGSSShopName").Value = datarow("ShopID")
                '  MsgBox("sdf")
                ' MsgBox(DGSearchSub.Rows(i).Cells("DGSSShopName").FormattedValue())

                For Each datarowOfShop As DataRow In ds.Tables("Shop").Rows
                    If datarowOfShop.Item("ShopID") = datarow("ShopID") Then
                        DGSearchSub.Rows(j).Cells("DGSSShopkeeperName").Value = datarowOfShop("ConcernPName")
                        DGSearchSub.Rows(j).Cells("DGSSAddress").Value = datarowOfShop("Address")

                    End If
                Next
                DGSearchSub.Rows(j).Cells("DGSSInvoiceNo").Value = datarow("InvoiceNo")
                DGSearchSub.Rows(j).Cells("DGSSTotalAmount").Value = datarow("Balance")
                Try
                    DGSearchSub.Rows(j).Cells("DGSSBalance").Value = datarow("Balance")

                Catch ex As Exception

                End Try
                j = j + 1

            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGSubObrPaid_Detail()

        Module1.DatasetFill("Select * from VuObrPaid_Detail_ForDGSubSaleman where ShopID =" & DGSearch.CurrentRow.Cells("DGShopNameSearch").Value, "VuObrPaid_Detail_ForDGSubSaleman")
        'Dim i As Integer = 0
        'DGSub.Rows.Clear()
        Dim j As Integer = 0
        For Each datarow As DataRow In ds.Tables("VuObrPaid_Detail_ForDGSubSaleman").Rows
            DGObPaid.Rows.Add()

            'DGSearchSub.Rows(j).Cells("DGSSCustomerName").Value = datarow("CustomerID")
            'DGSearchSub.Rows(j).Cells("DGSSShopName").Value = datarow("ShopID")
            ''  MsgBox("sdf")
            '' MsgBox(DGSearchSub.Rows(i).Cells("DGSSShopName").FormattedValue())

            'For Each datarowOfShop As DataRow In ds.Tables("Shop").Rows
            '    If datarowOfShop.Item("ShopID") = datarow("ShopID") Then
            '        DGSearchSub.Rows(j).Cells("DGSSShopkeeperName").Value = datarowOfShop("ConcernPName")
            '        DGSearchSub.Rows(j).Cells("DGSSAddress").Value = datarowOfShop("Address")

            '    End If
            'Next
            DGObPaid.Rows(j).Cells("DGObPSNo").Value = DGObPaid.Rows(j).Index + 1
            DGObPaid.Rows(j).Cells("DGObPDescription").Value = datarow("Remarks")
            DGObPaid.Rows(j).Cells("DGObPDate").Value = datarow("ObrayeDate")
            DGObPaid.Rows(j).Cells("DGObPObResp").Value = datarow("ObrayeResponsible")
            DGObPaid.Rows(j).Cells("DGObPPaid").Value = datarow("Paid")
            'Try
            '    DGSearchSub.Rows(j).Cells("DGSSBalance").Value = datarow("Balance")

            'Catch ex As Exception

            'End Try
            j = j + 1

        Next

    End Sub

    Private Sub DGSearch_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGSearch.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGSearchSub_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGSearchSub.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
#End Region


    Private Sub chkFixedLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFixedLocation.CheckedChanged
        DGSearch.Rows.Clear()
        DGSearchSub.Rows.Clear()
    End Sub

    Private Sub dtFromSearch_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFromSearch.ValueChanged
        DGSearch.Rows.Clear()
        DGSearchSub.Rows.Clear()
    End Sub

    Private Sub dtToSearch_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtToSearch.ValueChanged
        DGSearch.Rows.Clear()
        DGSearchSub.Rows.Clear()
    End Sub

    Private Sub cmbLocationSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocationSearch.SelectedIndexChanged
        DGSearch.Rows.Clear()
        DGSearchSub.Rows.Clear()
    End Sub

    Private Sub RBSearchLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSearchLocation.CheckedChanged
        If RBSearchLocation.Checked.Equals(True) Then
            Module1.DatasetFill("Select * from VuLocation", "VuLocation")
            Call ComboFillerOfFahimshekaib(DGSSShopName, "VuLocation", "LocName", "LocID")
            cmbLocationSearch.DataSource = ds.Tables("VuLocation")
            cmbLocationSearch.DisplayMember = "LocName"
            cmbLocationSearch.ValueMember = "LocID"
            lblForChkbox.Text = "ساحِۀ مشخص"
            'chkFixedLocation.Left = 565
        Else
            cmbLocationSearch.DataSource = Nothing
        End If
    End Sub

    Private Sub RBSearchCustomerName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSearchCustomerName.CheckedChanged
        If RBSearchCustomerName.Checked.Equals(True) Then
            Module1.DatasetFill("Select * from Customer where CustomerTypeID = 1", "Customer")
            Call ComboFillerOfFahimshekaib(DGSSShopName, "Customer", "CustomerName", "CustomerID")
            cmbLocationSearch.DataSource = ds.Tables("Customer")
            cmbLocationSearch.DisplayMember = "CustomerName"
            cmbLocationSearch.ValueMember = "CustomerID"
            lblForChkbox.Text = "فروشندۀ مشخص"
            'chkFixedLocation.Left = 565
        Else
            cmbLocationSearch.DataSource = Nothing
        End If
    End Sub

    'Private Sub cmbShopName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShopName.SelectedIndexChanged

    'End Sub

    Private Sub txtPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaid.TextChanged
        txtBalance.Text = Val(txtRemaining.Text) - Val(txtPaid.Text)
    End Sub

    Private Sub txtBalance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBalance.TextChanged

        Try
            If Val(txtBalance.Text) < 0 Then
                txtPaid.Text = 0
            End If
            If txtBalance.Text = 0 Then
                txtCounterForObraye.Text = 0
            Else
                Module1.DatasetFill("Select Max(CounterForObraye) as 'LastCounteryForObraye' from VuObrayeDetailForSearchSaleman where ShopID = " & cmbShopName.SelectedValue & " And ObrayeDate =(Select Max(ObrayeDate) from VuObrayeDetailForSearchSaleman where ShopID = " & cmbShopName.SelectedValue & ")", "VuObrayeDetailForSearchSaleman")
                If IsDBNull(ds.Tables("VuObrayeDetailForSearchSaleman").Rows(0).Item("LastCounteryForObraye")) Then
                    txtCounterForObraye.Text = 0
                Else
                    Dim LastObrayeTurn As Integer = ds.Tables("VuObrayeDetailForSearchSaleman").Rows(0).Item("LastCounteryForObraye")
                    txtCounterForObraye.Text = LastObrayeTurn + 1
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEnterToDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnterToDG.Click
        If txtCounterForObraye.Text.Trim.Equals("") Then
            txtCounterForObraye.Text = 0
        End If

        If EditValue = 1 Then
            If cmbShopName.Text = "" Then Exit Sub
            DG.Rows.Add()
            DG.Rows(DG.Rows.Count - 1).Cells("DGSNo").Value = DG.Rows(DG.Rows.Count - 1).Index + 1
            DG.Rows(DG.Rows.Count - 1).Cells("DGcmbShopName").Value = cmbShopName.SelectedValue
            DG.Rows(DG.Rows.Count - 1).Cells("DGShopkeeperName").Value = cmbShopKeeperName.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGAddress").Value = txtAddress.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGcmbLocation").Value = cmbLocation.SelectedValue
            DG.Rows(DG.Rows.Count - 1).Cells("DGRemainingBalance").Value = txtRemaining.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGRasid").Value = txtPaid.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGBalance").Value = txtBalance.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGCounterForObraye").Value = txtCounterForObraye.Text
        Else
            DG.Rows(CurrentRowSelected).Cells("DGSNo").Value = DG.Rows(CurrentRowSelected).Index + 1

            DG.Rows(CurrentRowSelected).Cells("DGShopID").Value = cmbShopName.SelectedValue
            DG.Rows(CurrentRowSelected).Cells("DGShopKeeper").Value = cmbShopKeeperName.Text
            DG.Rows(CurrentRowSelected).Cells("DGAddress").Value = txtAddress.Text
            DG.Rows(CurrentRowSelected).Cells("DGcmbLocation").Value = cmbLocation.SelectedValue
            DG.Rows(CurrentRowSelected).Cells("DGReaminingBalance").Value = txtRemaining.Text
            DG.Rows(CurrentRowSelected).Cells("DGRasid").Value = txtPaid.Text
            DG.Rows(CurrentRowSelected).Cells("DGBalance").Value = txtBalance.Text
            DG.Rows(CurrentRowSelected).Cells("DGCounterForObraye").Value = txtCounterForObraye.Text

        End If
    End Sub

    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        AddEdit = True
        cmbLocation.Enabled = False
        EnableFewControls()
        txtclear(Me, pnlcentre, TB1, TP1)
        DG.Rows.Clear()
        CallFrom = "Saving"
        ToolStrip1.Enabled = False
        Module1.txtclear(Me, pnlcentre, TB1, TP1)
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)
        Call Module1.CMStatus(CM)
        EditValue = 1
    End Sub

    Private Sub cmbShopName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShopName.SelectedIndexChanged
        Try


            txtPaid.Text = ""
            cmbShopKeeperName.SelectedValue = cmbShopName.SelectedValue
            Module1.DatasetFill("Select Distinct(ShopID),Sum(Balance) as Balance,CounterForObraye from SaleMainOfSaleMan where saledate between '" & dtFrom.Value.Date & "' And '" & dtTo.Value.Date & "' And ShopID= " & cmbShopName.SelectedValue & " and Balance>0 Group By ShopID,CounterForObraye", "SaleMainOfSaleMan")

            For Each datarowOfShop As DataRow In ds.Tables("VuShop").Rows
                If datarowOfShop("ShopID") = cmbShopName.SelectedValue Then
                    txtAddress.Text = datarowOfShop("Address")
                End If
            Next
            ''''''''''''''''May 16 Commented by fahim for finalizing.
            ' '' '' '' '' ''For Each datarow As DataRow In ds.Tables("SaleMainOfSaleMan").Rows
            ' '' '' '' '' ''    '  If datarow("ShopID") = cmbShopName.SelectedValue Then
            ' '' '' '' '' ''    txtRemaining.Text = datarow("Balance")
            ' '' '' '' '' ''    txtCounterForObraye.Text = datarow("CounterForObraye")
            ' '' '' '' '' ''    ' End If
            ' '' '' '' '' ''Next

        Catch ex As Exception

        End Try

        Try
            Module1.DatasetFill("Select Sum(Balance) as 'Balance' From SaleMainOfSaleMan where ShopID = " & cmbShopName.SelectedValue, "SaleMainOfSaleMan")
            Dim BalanceFromSaleMain As Decimal = ds.Tables("SaleMainOfSaleMan").Rows(0).Item("Balance")
            Dim BalancePaidInObraye As Decimal = 0
            Try
                Module1.DatasetFill("Select Sum(Paid) as 'Paid' From ObrayeDetailSaleman where ShopID = " & cmbShopName.SelectedValue, "ObrayeDetailSaleman")
                BalancePaidInObraye = ds.Tables("ObrayeDetailSaleman").Rows(0).Item("Paid")

            Catch ex As Exception
                BalancePaidInObraye = 0
            End Try

            Try

                txtRemaining.Text = BalanceFromSaleMain - BalancePaidInObraye
                'Try
                '    txtCounterForObraye.Text = ds.Tables("ObrayeDetail").Rows(0).Item("CounterForObraye")

                'Catch ex As Exception
                '    txtCounterForObraye.Text = 0
                'End Try

            Catch ex As Exception
                txtRemaining.Text = 0
                txtCounterForObraye.Text = 0
            End Try
        Catch ex As Exception
            txtRemaining.Text = 0
            txtCounterForObraye.Text = 0
        End Try
        txtPaid.Text = 0
    End Sub


    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        AddEdit = False
        EditValue = 0
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)
        Call Module1.CMStatus(CM)
        cmbLocation.Enabled = False
        DisableFewControls()
        Module1.DatasetFill("Select * from OrderEnglishMain", "OrderEnglishMain")
        Call txtfill()
        ToolStrip1.Enabled = True
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        Try


            If DG.Rows.Count = 0 Then Exit Sub
            If EditValue = 1 Then
                Call IDPicker()
            End If

            Dim cmdsave As New SqlCommand


            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateObrayeMainSaleman"
            cmdsave.Connection = cn
            cmdsave.Parameters.Add("@ObrayeID", SqlDbType.Int).Value = Me.Var_ObrayeID
            cmdsave.Parameters.Add("@ObrayeDate", SqlDbType.SmallDateTime).Value = Me.dtObrayeDate.Value.Date
            cmdsave.Parameters.Add("@ObrayeResponsible ", SqlDbType.NVarChar).Value = Me.txtObrayeResponsible.Text
            cmdsave.Parameters.Add("@OfficeResponsible", SqlDbType.NVarChar).Value = Me.txtOfficeResposible.Text
            cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Me.txtTotalAmount.Text
            Dim Remarks As String = Me.txtRemarks.Text
            If Remarks.Equals("") Then
                cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
            Else
                cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            End If

            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_ObrayeID


            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdsave.ExecuteNonQuery()

            cmdsave.Parameters.Clear()

            If EditValue = 1 Then

                Call GridSave()

                ' Trans.Commit()
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                '' MsgBox("Your Record has been saved successfully..")
                txtfill()
                CallFrom = ""
            Else
                Call DeleteGrid()
                Call GridSave()

                ' Trans.Commit()
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"


                ''MsgBox("Your Record has been updated successfully..")
            End If
            AddEdit = False
            Call CStatus(Me, pnlcentre, TB1, TP1)
            cmbLocation.Enabled = False
            CMStatus(CM)
            DG.ReadOnly = True

            ToolStrip1.Enabled = True
            DisableFewControls()
        Catch ex As Exception

        End Try

    End Sub

    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(ObrayeID) from ObrayeMainSaleman"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_ObrayeID = 1
                Else
                    Me.Var_ObrayeID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub GridSave()

        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateObrayeDetailSaleman"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 1
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@ObrayeID", SqlDbType.Int).Value = Var_ObrayeID
                cmdsaveGrid.Parameters.Add("@Sno", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNo").Value
                cmdsaveGrid.Parameters.Add("@ShopID", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGcmbShopName").Value
                cmdsaveGrid.Parameters.Add("@ConcernPName", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGShopkeeperName").Value
                cmdsaveGrid.Parameters.Add("@Address", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGAddress").Value
                cmdsaveGrid.Parameters.Add("@LocationID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGcmbLocation").Value
                cmdsaveGrid.Parameters.Add("@ToPay", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGRemainingBalance").Value
                cmdsaveGrid.Parameters.Add("@Paid", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGRasid").Value
                cmdsaveGrid.Parameters.Add("@Balance", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGBalance").Value

                Dim CountForObraye As Integer = DG.Rows(a).Cells("DGCounterForObraye").Value
                If IsNothing(CountForObraye) Then
                    cmdsaveGrid.Parameters.Add("@CounterForObraye", SqlDbType.Int).Value = " "
                Else
                    cmdsaveGrid.Parameters.Add("@CounterForObraye", SqlDbType.Int).Value = DG.Rows(a).Cells("DGCounterForObraye").Value

                End If
                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next

        Catch ex As Exception

        End Try


    End Sub
    Sub DeleteGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteObrayeDetailSaleman"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@ObrayeID", SqlDbType.Int).Value = Var_ObrayeID
        cmdsave.ExecuteNonQuery()

    End Sub
    Sub txtfill()
        Try
            'lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If

            Module1.DatasetFill("Select * from ObrayeMainSaleman Order by ObrayeID", "ObrayeMainSaleman")

            If ds.Tables("ObrayeMainSaleman").Rows.Count = 0 Then
                Call txtclear(Me, pnlcentre, TB1, TP1)
                Exit Sub
            Else

                If CallFrom = "Saving" Then
                    cnt = ds.Tables("ObrayeMainSaleman").Rows.Count - 1
                End If
                Me.Var_ObrayeID = Val(ds.Tables("ObrayeMainSaleman").Rows(cnt).Item("ObrayeID"))

                dtObrayeDate.Value = ds.Tables("ObrayeMainSaleman").Rows(cnt).Item("ObrayeDate")
                txtObrayeResponsible.Text = ds.Tables("ObrayeMainSaleman").Rows(cnt).Item("ObrayeResponsible")
                txtOfficeResposible.Text = ds.Tables("ObrayeMainSaleman").Rows(cnt).Item("OfficeResponsible")
                txtTotalAmount.Text = ds.Tables("ObrayeMainSaleman").Rows(cnt).Item("TotalAmount")
                txtRemarks.Text = ds.Tables("ObrayeMainSaleman").Rows(cnt).Item("Remarks")
                Call Gridtxtfill()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Gridtxtfill()
        Try

            Module1.DatasetFill("Select * from ObrayeDetailSaleman where ObrayeID= " & Var_ObrayeID, "ObrayeDetailSaleman")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("ObrayeDetailSaleman").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGcmbShopName").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("ShopID")
                    DG.Rows(a).Cells("DGShopkeeperName").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("ConcernPName")
                    DG.Rows(a).Cells("DGAddress").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("Address")
                    DG.Rows(a).Cells("DGcmbLocation").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("LocationID")
                    DG.Rows(a).Cells("DGRemainingBalance").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("ToPay")
                    DG.Rows(a).Cells("DGRasid").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("Paid")
                    DG.Rows(a).Cells("DGBalance").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("Balance")
                    DG.Rows(a).Cells("DGCounterForObraye").Value = ds.Tables("ObrayeDetailSaleman").Rows(a).Item("CounterForObraye")
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub DisableFewControls()
        btnDisplayShops.Enabled = False
        'chkSpecificLocation.Enabled = False
        btnEnterToDG.Enabled = False
    End Sub
    Sub EnableFewControls()
        btnDisplayShops.Enabled = True
        'chkSpecificLocation.Enabled = True
        btnEnterToDG.Enabled = True
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        AddEdit = True
        CMStatus(CM)
        CStatus(Me, pnlcentre, TB1, TP1)
        cmbLocation.Enabled = False
        EnableFewControls()
        EditValue = 0
        ToolStrip1.Enabled = False
        ComboFillerOfFahimshekaib(cmbShopName, "Customer", "CustomerName", "CustomerID")
    End Sub

    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType

        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from ObrayeMainSaleman where ObrayeID = " & Var_ObrayeID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from ObrayeDetailSaleman where ObrayeID=" & Var_ObrayeID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()



            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("ObrayeMainSaleman").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                txtclear(Me, pnlcentre, TB1, TP1)
                DG.Rows.Clear()
            End If
            Call txtfill()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
        End If
    End Sub
#Region "ACCOUNT SECTION ENTRY"
    ' It does not have account entry.
#End Region

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub

    Private Sub TB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.SelectedIndexChanged
        If TB1.SelectedIndex = 1 Then
            Me.CM.Enabled = False
        Else
            Me.CM.Enabled = True
        End If
    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Calculation()
    End Sub
    Sub Calculation()
        If AddEdit = True Then
            Try
                Dim CalculateAmount As Double = 0
                Dim Increamenter As Integer = 0
                For Each dgcol As DataGridViewColumn In DG.Columns
                    If dgcol.Name = "DGRasid" Then


                        'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGRasid" Then
                        For Each dgrow As DataGridViewRow In DG.Rows
                            CalculateAmount = CalculateAmount + Val(Convert.ToDecimal(DG.Rows(Increamenter).Cells("DGRasid").Value))
                            Increamenter = Increamenter + 1
                        Next
                    End If
                    'End If
                Next
                txtTotalAmount.Text = CalculateAmount
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub CalculationOfObrayeSearch()
        'If EditValue = 1 Then
        Try
           
            Dim CalculateBalance As Double = 0

            Dim Increamenter As Integer = 0
            For Each dgcol As DataGridViewColumn In DGSearch.Columns
                If dgcol.Name = "DGBaqayaSearch" Then


                    'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGRasid" Then
                    For Each dgrow As DataGridViewRow In DGSearch.Rows
                        'CalculateRemaining = CalculateRemaining + Val(Convert.ToDecimal(DGSearch.Rows(Increamenter).Cells("DGBaqayaSearch").Value))
                        'CalculateRasid = CalculateRasid + Val(Convert.ToDecimal(DGSearch.Rows(Increamenter).Cells("DGRasidSearch").Value))
                        CalculateBalance = CalculateBalance + Val(Convert.ToDecimal(DGSearch.Rows(Increamenter).Cells("DGBalanceSearch").Value))

                        Increamenter = Increamenter + 1
                    Next
                    'End If
                End If
            Next
          
            txtBalanceSearch.Text = CalculateBalance

        Catch ex As Exception

        End Try
        'End If
    End Sub
    Sub CalculationOfObrayeSearchIn()
        'If EditValue = 1 Then
        Try
            Dim CalculateRemaining As Double = 0


            Dim Increamenter As Integer = 0
            For Each dgcol As DataGridViewColumn In DGSearchSub.Columns
                If dgcol.Name = "DGSSTotalAmount" Then


                    'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGRasid" Then
                    For Each dgrow As DataGridViewRow In DGSearchSub.Rows
                        CalculateRemaining = CalculateRemaining + Convert.ToDecimal(DGSearchSub.Rows(Increamenter).Cells("DGSSTotalAmount").Value)

                        Increamenter = Increamenter + 1
                    Next
                    'End If
                End If
            Next
            txtBalanceSearchInv.Text = CalculateRemaining


        Catch ex As Exception

        End Try
        'End If
    End Sub
    Sub CalculationOfObrayeSearchObrayePaid()
        'If EditValue = 1 Then
        Try
            Dim CalculateRemaining As Double = 0


            Dim Increamenter As Integer = 0
            For Each dgcol As DataGridViewColumn In DGObPaid.Columns
                If dgcol.Name = "DGObPPaid" Then


                    'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGRasid" Then
                    For Each dgrow As DataGridViewRow In DGObPaid.Rows
                        CalculateRemaining = CalculateRemaining + Convert.ToDecimal(DGObPaid.Rows(Increamenter).Cells("DGObPPaid").Value)

                        Increamenter = Increamenter + 1
                    Next
                    'End If
                End If
            Next
            txtBalanceSearchObPaid.Text = CalculateRemaining


        Catch ex As Exception

        End Try
        'End If
    End Sub
    Private Sub DG_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DG.RowsRemoved
        Calculation()
    End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick

        txtShopName.Text = DG.CurrentRow.Cells("DGcmbShopName").Value
        txtShopkeeperName.Text = DG.CurrentRow.Cells("DGShopKeeperName").Value
        txtAddress.Text = DG.CurrentRow.Cells("DGAddress").Value
        txtRemaining.Text = DG.CurrentRow.Cells("DGRemainingBalance").Value
        txtPaid.Text = DG.CurrentRow.Cells("DGRasid").Value
        txtBalance.Text = DG.CurrentRow.Cells("DGBalance").Value
        txtCounterForObraye.Text = DG.CurrentRow.Cells("DGCounterForObraye").Value
        CurrentRowSelected = DG.CurrentRow.Index
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
#Region "Navigation Section"
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        txtfill()
        DisableFewControls()
        'CStatus(Me, pnlcenter, TB1, TP1)
        'CMStatus(CM)
    End Sub

    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then
            txtfill()

        Else
            cnt = cnt - 1
            txtfill()
        End If
        DisableFewControls()
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("ObrayeMainSaleman").Rows.Count - 1 Then
            MsgBox("شما در ریکارد اخیر قرار دارید")
        Else
            cnt = cnt + 1
            txtfill()
        End If
        DisableFewControls()
    End Sub

    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("ObrayeMainSaleman").Rows.Count - 1
        txtfill()
        DisableFewControls()
    End Sub
#End Region

    Private Sub DGSearchSub_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearchSub.CellValueChanged
        CalculationOfObrayeSearchIn()
    End Sub

    Private Sub DGSearchSub_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGSearchSub.RowsRemoved
        CalculationOfObrayeSearchIn()
    End Sub

    Private Sub txtObrayeResponsible_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObrayeResponsible.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub txtCounterForObraye_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCounterForObraye.KeyPress
        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Or Asc(e.KeyChar) = 46 Then e.Handled = True

    End Sub

    Private Sub txtPaid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaid.KeyPress
        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True

    End Sub

    Private Sub txtOfficeResposible_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOfficeResposible.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub DGObPaid_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGObPaid.CellValueChanged
        CalculationOfObrayeSearchObrayePaid()
    End Sub

End Class
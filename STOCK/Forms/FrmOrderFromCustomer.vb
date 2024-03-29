Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmOrderFromCustomer
    Dim a As Integer
    Dim EditValue As Integer
    Dim cnt As Integer
    Dim Var_SalOrderID As Integer
    Dim CurrowIndex As Integer
    Dim _OrderNo As String

    Dim Count As Integer
    Dim PcsInCrtn As Integer
    Dim ProdCode As Integer

    Dim AddEdit As Boolean
    Dim azizspliter() As String
    Dim Purchase As Integer
    Dim SalePcs As Integer
    Dim SaleCrtn As Integer
    Dim SaleTotal As Decimal
    Dim ReturnPcs As Integer
    Dim ReturnCrtn As Integer
    Dim ReturnTotal As Decimal
    Dim ClaimPcs As Integer
    Dim ClaimCrtn As Integer
    Dim ClaimTotal As Decimal
    Dim DamagePcs As Integer
    Dim DamageCrtn As Integer
    Dim DamageTotal As Decimal

    Dim Search As Boolean
    Private Sub FrmOrderFromCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        Me.MaximizeBox = False
        Module1.DatasetFill("Select * from Location", "Location")
        cmbLocation.DataSource = ds.Tables("Location")
        cmbLocation.DisplayMember = "LocName"
        cmbLocation.ValueMember = "LocID"
        cmbLocation.SelectedIndex = -1

        Module1.DatasetFill("Select * from Shop", "Shop")
        cmbShop.DataSource = ds.Tables("Shop")
        cmbShop.DisplayMember = "ShopName"
        cmbShop.ValueMember = "ShopID"
        cmbShop.SelectedIndex = -1
        Module1.DatasetFill("Select * from OrderFromCustomerMain", "OrderFromCustomerMain")
        Call ComboCustomerTypeFiller()
        If ds.Tables("CustomerType").Rows.Count > 0 Then
            cmbCustomerType.SelectedIndex = -1
        End If
        'Call ComboCustomerNameFiller()
        Call ComboProductTypeFill()
        Module1.DatasetFill("Select * from Customer", "Customer")
        Call FillCustomerNameCombo("Customer", "CustomerName", "CustomerID")
        cmbCustomerName.SelectedIndex = -1
        ComboCrtnPcsFiller()
        Call txtfill()

        Me.MaximizeBox = False
        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        MnuReturn.Visible = False
        Label2.Visible = False
        cmbOrderNoSearch.Visible = False
        Label1.Visible = False
        cmbCustomerNameSearch.Visible = False
        Label3.Visible = False
        cmbCustomerTypeSearch.Visible = False

        'Search = False
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub
    Sub ListViewFill()
        Dim Amad As Double = 0
        Dim Raft As Double = 0
        Dim Total As Double = 0
        Dim GrandTotal As Double = 0
        Module1.DatasetFill("Select * from VuProductForStockViewer where ProductType= " & DG.CurrentRow.Cells("DGProdTypeID").Value & "", "VuProductForStockViewer")
        LVStockViewer.Items.Clear()
        For Count = 0 To ds.Tables("VuProductForStockViewer").Rows.Count - 1

            Dim Item As New ListViewItem
            ProdCode = ds.Tables("VuProductForStockViewer").Rows(Count).Item("ProdCode")
            Item.Text = ds.Tables("VuProductForStockViewer").Rows(Count).Item("Product")
            'Item.SubItems.Add()
            'Item.SubItems.Add(ds.Tables("VuProductForStockViewer").Rows(Count).Item("PcsInCtrn"))
            PcsInCrtn = ds.Tables("VuProductForStockViewer").Rows(Count).Item("PcsInCtrn")
            LVStockViewer.Items.Add(Item)
            Call Selecter()
            Calculator()



            Try

                Amad = 0
                Raft = 0
                Amad = Amad + Val(Purchase) + Val(ReturnTotal)
                Raft = Raft + Val(SaleTotal) + Val(ClaimTotal) + Val(DamageTotal)
                Total = Amad - Raft
                GrandTotal = Total


            Catch ex As Exception

            End Try

            Item.SubItems.Add(GrandTotal)
        Next
    End Sub

#Region "STOCK VIEWER............................."

    Sub Calculator()
        Dim b As String
        Dim CrtnPcsDivision As Decimal
        Dim c As Decimal
        Dim aziz As String
        Dim Fullportion As String
        Dim PointPortion As String
        Dim ReadyToAssignValue As String
        Try
            CrtnPcsDivision = Val(SalePcs) / Val(PcsInCrtn)
            If CrtnPcsDivision = 0 Then
                SaleTotal = SaleCrtn
                Exit Try
            Else
                aziz = CrtnPcsDivision
                azizspliter = aziz.Split(".")
                If azizspliter.Length > 1 Then
                    If azizspliter(1).Length > 2 Then
                        Fullportion = azizspliter(0)
                        PointPortion = azizspliter(1)
                        'b = CType(CrtnPcsDivision, String) ' bekara shud.
                        c = PointPortion.Substring(0, 2)
                        ReadyToAssignValue = Fullportion & "." & c
                        SaleTotal = Val(SaleCrtn) + ReadyToAssignValue
                    Else
                        SaleTotal = Val(SaleCrtn) + CrtnPcsDivision
                    End If
                Else
                    SaleTotal = Val(SaleCrtn) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(ReturnPcs) / Val(PcsInCrtn)
            If CrtnPcsDivision = 0 Then
                ReturnTotal = ReturnCrtn
                Exit Try
            Else
                aziz = CrtnPcsDivision
                azizspliter = aziz.Split(".")
                If azizspliter.Length > 1 Then
                    If azizspliter(1).Length > 2 Then
                        Fullportion = azizspliter(0)
                        PointPortion = azizspliter(1)
                        'b = CType(CrtnPcsDivision, String) ' bekara shud.
                        c = PointPortion.Substring(0, 2)
                        ReadyToAssignValue = Fullportion & "." & c
                        ReturnTotal = Val(ReturnCrtn) + ReadyToAssignValue
                    Else
                        ReturnTotal = Val(ReturnCrtn) + CrtnPcsDivision
                    End If
                Else
                    ReturnTotal = Val(ReturnCrtn) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(ClaimPcs) / Val(PcsInCrtn)
            If CrtnPcsDivision = 0 Then
                ClaimTotal = ClaimCrtn
                Exit Try

            Else
                aziz = CrtnPcsDivision
                azizspliter = aziz.Split(".")
                If azizspliter.Length > 1 Then
                    If azizspliter(1).Length > 2 Then
                        Fullportion = azizspliter(0)
                        PointPortion = azizspliter(1)
                        'b = CType(CrtnPcsDivision, String) ' bekara shud.
                        c = PointPortion.Substring(0, 2)
                        ReadyToAssignValue = Fullportion & "." & c
                        ClaimTotal = Val(ClaimCrtn) + ReadyToAssignValue
                    Else
                        ClaimTotal = Val(ClaimCrtn) + CrtnPcsDivision
                    End If
                Else
                    ClaimTotal = Val(ClaimCrtn) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(DamagePcs) / Val(PcsInCrtn)
            If CrtnPcsDivision = 0 Then
                DamageTotal = DamageCrtn
                Exit Try
            Else
                aziz = CrtnPcsDivision
                azizspliter = aziz.Split(".")
                If azizspliter.Length > 1 Then
                    If azizspliter(1).Length > 2 Then
                        Fullportion = azizspliter(0)
                        PointPortion = azizspliter(1)
                        'b = CType(CrtnPcsDivision, String) ' bekara shud.
                        c = PointPortion.Substring(0, 2)
                        ReadyToAssignValue = Fullportion & "." & c
                        DamageTotal = Val(DamageCrtn) + ReadyToAssignValue
                    Else
                        DamageTotal = Val(DamageCrtn) + CrtnPcsDivision
                    End If
                Else
                    DamageTotal = Val(DamageCrtn) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub Selecter()
        Try
            Module1.DatasetFill("Select Sum(PurchaseQty) As Purchase from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Purchase'", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("Purchase") Then
                Purchase = 0
            Else
                Purchase = ds.Tables("VuIGLForCustomer").Rows(0).Item("Purchase")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(SaleQty) As SalePcs from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Sale' and CrtnPcs = 1", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("SalePcs") Then
                SalePcs = 0
            Else
                SalePcs = ds.Tables("VuIGLForCustomer").Rows(0).Item("SalePcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(SaleQty) As SaleCrtn from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Sale' and CrtnPcs = 2", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("SaleCrtn") Then
                SaleCrtn = 0
            Else
                SaleCrtn = ds.Tables("VuIGLForCustomer").Rows(0).Item("SaleCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ReturnQty) As ReturnPcs from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Sale Return' and CrtnPcs = 1", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("ReturnPcs") Then
                ReturnPcs = 0
            Else
                ReturnPcs = ds.Tables("VuIGLForCustomer").Rows(0).Item("ReturnPcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ReturnQty) As ReturnCrtn from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Sale Return' and CrtnPcs = 2", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("ReturnCrtn") Then
                ReturnCrtn = 0
            Else
                ReturnCrtn = ds.Tables("VuIGLForCustomer").Rows(0).Item("ReturnCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ClaimQty) As ClaimPcs from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Claim' and CrtnPcs = 1", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("ClaimPcs") Then
                ClaimPcs = 0
            Else
                ClaimPcs = ds.Tables("VuIGLForCustomer").Rows(0).Item("ClaimPcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ClaimQty) As ClaimCrtn from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Claim' and CrtnPcs = 2", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("ClaimCrtn") Then
                ClaimCrtn = 0
            Else
                ClaimCrtn = ds.Tables("VuIGLForCustomer").Rows(0).Item("ClaimCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(DamageQty) As DamagePcs from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Damage' and CrtnPcs = 1", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("DamagePcs") Then
                DamagePcs = 0
            Else
                DamagePcs = ds.Tables("VuIGLForCustomer").Rows(0).Item("DamagePcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(DamageQty) As DamageCrtn from VuIGLForCustomer where ProductType=" & DG.CurrentRow.Cells("DGProdTypeID").Value & " and ProductCode=" & ProdCode & " and Type='Damage' and CrtnPcs = 2", "VuIGLForCustomer")
            If ds.Tables("VuIGLForCustomer").Rows(0).IsNull("DamageCrtn") Then
                DamageCrtn = 0
            Else
                DamageCrtn = ds.Tables("VuIGLForCustomer").Rows(0).Item("DamageCrtn")
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region


#Region "Sub Functions txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Public Sub CStatusDefault()
        cmbCustomerType.Enabled = False
        cmbCustomerName.Enabled = False
        txtOrderNo.Enabled = False
        dtOrderDate.Enabled = False
        dtReqDate.Enabled = False
        txtOrderNo.Enabled = False
        txtRemarks.Enabled = False
        btnPromptCustomerForm.Enabled = False
    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False


    End Sub
    Sub CStutus()
        cmbCustomerType.Enabled = Not cmbCustomerType.Enabled
        cmbCustomerName.Enabled = Not cmbCustomerName.Enabled
        txtOrderNo.Enabled = Not txtOrderNo.Enabled
        dtOrderDate.Enabled = Not dtOrderDate.Enabled
        dtReqDate.Enabled = Not dtReqDate.Enabled

        txtRemarks.Enabled = Not txtRemarks.Enabled
        btnPromptCustomerForm.Enabled = Not btnPromptCustomerForm.Enabled

    End Sub
    Sub txtclear()
        Dim C As Control
        Dim D As Control
        Dim E As Control
        Dim F As Control
        For Each C In Me.Controls
            If TypeOf C Is Panel Then
                For Each D In C.Controls
                    If TypeOf D Is TabControl Then
                        For Each E In D.Controls
                            If TypeOf E Is TabPage Then
                                For Each F In E.Controls
                                    If TypeOf F Is TextBox Then
                                        F.Text = ""
                                    ElseIf TypeOf F Is DateTimePicker Then
                                        F.Text = Now
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
        Var_SalOrderID = 0

    End Sub
    Sub ComboCrtnPcsFiller()
        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        DGCrtnPcs.DataSource = ds.Tables("CartonPiece")
        DGCrtnPcs.DisplayMember = "Name"
        DGCrtnPcs.ValueMember = "ID"
        'DGCrtnPcs.SelectedIndex = 0
    End Sub
    Sub ComboCustomerTypeFiller()
        Module1.DatasetFill("Select * from CustomerType", "CustomerType")
        cmbCustomerType.DataSource = ds.Tables("CustomerType")
        cmbCustomerType.DisplayMember = "CustomerTypeName"
        cmbCustomerType.ValueMember = "CustomerTypeID"
        cmbCustomerType.SelectedIndex = -1
    End Sub
    Sub ComboProductTypeFill()
        Module1.DatasetFill("Select * from ProductType", "ProductType")
        DGPType.DataSource = ds.Tables("ProductType")
        DGPType.DisplayMember = "ProdTypeName"
        DGPType.ValueMember = "ProdTypeID"
    End Sub

    Sub txtfill()
        Try
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from OrderFromCustomerMain Order by SalOrderID", "OrderFromCustomerMain")

            If ds.Tables("OrderFromCustomerMain").Rows.Count = 0 Then
                Call txtclear()
                Exit Sub
            Else
                Me.Var_SalOrderID = Val(ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("SalOrderID"))
                cmbCustomerType.SelectedValue = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("CustomerTypeID")
                cmbCustomerName.SelectedValue = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("CustomerID")
                cmbLocation.SelectedValue = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("LocID")
                cmbShop.SelectedValue = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("ShopID")
                If ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("LocID") = 0 Then
                    'Incase this person doesn't have shop
                    cmbLocation.Visible = False
                    lblLocation.Visible = False
                    cmbShop.Visible = False
                    lblShop.Visible = False
                Else
                    'Incase this person has shop
                    cmbLocation.Visible = True
                    lblLocation.Visible = True
                    cmbShop.Visible = True
                    lblShop.Visible = True
                End If
                txtOrderNo.Text = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("SalOrderNo")
                dtOrderDate.Value = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("OrderDate")
                dtReqDate.Value = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("ReqDate")
                txtRemarks.Text = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("Remarks")
                Call GridFill()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub GridFill()
        Try
            Dim i As Integer = 0

            DG.Rows.Clear()

            Module1.DatasetFill("Select * from VuOrderFromCustomerDetail where SalOrderID = " & Var_SalOrderID, "VuOrderFromCustomerDetail")
            'For Each Row As DataRow In ds.Tables("OrderFromCustomerDetail").Rows
            '    DG.Rows.Add()
            '    i = +1
            '    DG.Rows(i).Cells("DGSNo").Value = Row("SNo")
            '    DG.Rows(i).Cells("DGPType").Value = Row("ProdTypeID")
            '    DG.Rows(i).Cells("DGProductName").Value = Row("ProdCode")
            '    DG.Rows(i).Cells("DGQty").Value = Row("Qty")
            '    DG.Rows(i).Cells("DGDesc").Value = Row("ProdDescription")

            'Next
            For i = 0 To ds.Tables("VuOrderFromCustomerDetail").Rows.Count - 1
                DG.Rows.Add()
                'i = DG.Rows.Count

                DG.Rows(i).Cells("DGSNo").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("SNo")
                DG.Rows(i).Cells("DGPType").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("ProdTypeID")
                DG.Rows(i).Cells("DGProductName").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("Product")
                DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("CrtnPcs")
                DG.Rows(i).Cells("DGQty").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("Qty")
                DG.Rows(i).Cells("DGDesc").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("ProdDescription")

                DG.Rows(i).Cells("DGColProductID").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("ProdCode")
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuSearch.Enabled = Not MnuSearch.Enabled
    End Sub

#End Region


#Region "ContextMenuButtons"


    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click

        If MnuSearch.Visible = False Then
            MnuReturn.Visible = False
            Label2.Visible = False
            cmbOrderNoSearch.Visible = False
            Label1.Visible = False
            cmbCustomerNameSearch.Visible = False
            Label3.Visible = False
            cmbCustomerTypeSearch.Visible = False
            MnuSearch.Visible = True
        End If

        'Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        AddEdit = True
        Try
            Call txtclear()
            Call CStutus()
            EditValue = 1

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        CMStatus()
        DG.ReadOnly = False
        DGProductCode.Visible = True
        DG.Rows.Clear()
        lblMessage.Text = ""
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        AddEdit = False
        If EditValue = 1 Then
            Call IDPicker()
        End If
        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertUpdateOrderFromCustomerMain"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@SalOrderID", SqlDbType.Int).Value = Me.Var_SalOrderID

        cmdsave.Parameters.Add("@SalOrderNo", SqlDbType.NVarChar).Value = Me.txtOrderNo.Text
        cmdsave.Parameters.Add("@CustomerTypeID", SqlDbType.Int).Value = Me.cmbCustomerType.SelectedValue
        cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Me.cmbCustomerName.SelectedValue
        If cmbLocation.SelectedValue = Nothing Then
            cmdsave.Parameters.Add("@locID", SqlDbType.Int).Value = 0
            cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = 0
        Else


            cmdsave.Parameters.Add("@locID", SqlDbType.Int).Value = Me.cmbLocation.SelectedValue
            cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = Me.cmbShop.SelectedValue
        End If
        cmdsave.Parameters.Add("@OrderDate", SqlDbType.SmallDateTime).Value = Me.dtOrderDate.Value.Date
        cmdsave.Parameters.Add("@ReqDate", SqlDbType.SmallDateTime).Value = Me.dtReqDate.Value.Date
        cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text

        cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = Val("1")
        cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = "KBL" & "-" & Me.Var_SalOrderID
      

        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdsave.ExecuteNonQuery()

        cmdsave.Parameters.Clear()
        ' fill combo of customer back for navigation or displaying
        AddEdit = False
        Module1.DatasetFill("Select * from Customer", "Customer")
        Call FillCustomerNameCombo("Customer", "CustomerName", "CustomerID")

        If EditValue = 1 Then
            'I just made it comment because it was passing "save" instead of datagrid wala or whatever we need.
            'K2(sender, e) 

            Call GridSave()
            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            ' MsgBox("Your Record has been saved successfully..")
        Else
            Call DeleteGrid()
            Call GridSave()

            txtfill()
            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

            'MsgBox("Your Record has been updated successfully..")
        End If
        Call CStutus()
        CMStatus()
        DG.ReadOnly = True
        DGProductCode.Visible = False

    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click

        If MnuSearch.Visible = False Then
            MnuReturn.Visible = False
            Label2.Visible = False
            cmbOrderNoSearch.Visible = False
            Label1.Visible = False
            cmbCustomerNameSearch.Visible = False
            Label3.Visible = False
            cmbCustomerTypeSearch.Visible = False
            MnuSearch.Visible = True
        End If

        AddEdit = True
        Call CStutus()
        EditValue = 0
        CMStatus()

        DG.ReadOnly = False
        DGProductCode.Visible = True
        lblMessage.Text = ""
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        If Not Me.Var_SalOrderID = 0 Then
            If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                Module1.DeleteRecord("OrderFromCustomerMain", "SalOrderID = " & Me.Var_SalOrderID)
                'cnt = ds.Tables("OrderFromCustomerMain").Rows.Count
                'If cnt = 0 Then
                '    Call txtclear()
                '    Exit Sub
                'End If
                'If cnt = ds.Tables("OrderFromCustomerMain").Rows.Count - 1 Then
                '    cnt = cnt - 1
                '    ' Call TxtFillAfterDeletion()
                '    Call txtfill()
                'End If

                If cnt = ds.Tables("OrderFromCustomerMain").Rows.Count - 1 Then
                    cnt = cnt - 1
                End If
                If cnt < 0 Then
                    Clear()
                End If
                Call txtfill()
                lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "

                If MnuSearch.Visible = False Then
                    MnuReturn.Visible = False
                    Label2.Visible = False
                    cmbOrderNoSearch.Visible = False
                    Label1.Visible = False
                    cmbCustomerNameSearch.Visible = False
                    Label3.Visible = False
                    cmbCustomerTypeSearch.Visible = False
                    MnuSearch.Visible = True
                    'Search = False
                End If

            End If
        End If
    End Sub
    Sub OrderNoGenerator()
        Dim _m As String
        Dim _y As String
        Dim _MaxID As String
        Dim _Criteria As String
        _m = Date.Now.Month
        _y = Date.Now.Year
        _y = _y.Substring(2, 2)
        Dim SaleMan_InvNo As String
        Dim currentsaleman As String
        Module1.DatasetFill("Select InvoiceCode from VuCustomer where CustomerID =" & cmbCustomerName.SelectedValue, "VuCustomer")
        currentsaleman = ds.Tables("VuCustomer").Rows(0).Item("InvoiceCode")

        If _m.Length = 1 Then
            _m = "0" & _m
        End If
        _Criteria = currentsaleman & "-ORD-" & _m & "-" & _y & "-"

        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(Convert(INT,Substring(SalOrderNo,15,len(SalOrderNo)))) from OrderFromCustomerMain where SalOrderNo Like('" & _Criteria & "%'" & ")"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    _MaxID = 1
                Else
                    _MaxID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

            If _m.Length = 1 Then
                _m = "0" & _m
            End If
            If _MaxID.Length = 1 Then
                _MaxID = "0" & _MaxID
            End If

            _OrderNo = currentsaleman & "-ORD-" & _m & "-" & _y & "-" & _MaxID
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        txtOrderNo.Text = ""
        txtRemarks.Text = ""
        DG.Rows.Clear()
    End Sub
    Private Sub TxtFillAfterDeletion()

        If cnt <> Module1.ds.Tables("OrderFromCustomerMain").Rows.Count Then
            ' MsgBox(Module1.ds.Tables("OrderFromCustomerMain").Rows.Count)

            cnt = cnt - 1
            txtfill()
        Else
            If cnt <> 0 Then
                cnt = cnt - 1
                txtfill()
            Else
                MsgBox("There is no more record")
            End If
        End If
    End Sub



    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        AddEdit = False
        Call CStutus()
        txtclear()
        CMStatus()
        Module1.DatasetFill("Select * from Customer", "Customer")
        Call FillCustomerNameCombo("Customer", "CustomerName", "CustomerID")
        Call txtfill()
        DG.ReadOnly = True
        DGProductCode.Visible = False
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region
#Region "Navigation"
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        AddEdit = False
        cnt = 0
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        AddEdit = False
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        AddEdit = False
        If cnt = ds.Tables("OrderFromCustomerMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub





    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        AddEdit = False
        cnt = ds.Tables("OrderFromCustomerMain").Rows.Count - 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
#End Region
    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(SalOrderID) from OrderFromCustomerMain"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_SalOrderID = 1
                Else
                    Me.Var_SalOrderID = Val(sqldreader.Item(0)) + 1

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
        cmdsaveGrid.CommandText = "InsertUpdateOrderFromCustomerDetail"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 2
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@SalOrderID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@SalOrderID").Value = Var_SalOrderID


                cmdsaveGrid.Parameters.Add("@Sno", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNo").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value

                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGColProductID").Value
                cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.Int).Value = DG.Rows(a).Cells("DGCrtnPcs").Value
                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGQty").Value
                If DG.Rows(a).Cells("DGDesc").Value = "" Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = " "
                Else
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDesc").Value
                End If

                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next

        Catch ex As Exception
            'Trans.Rollback()
        End Try


    End Sub
    Sub DeleteGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteOrderFromCustomerDetail"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@SalOrderID", SqlDbType.Int).Value = Var_SalOrderID
        cmdsave.ExecuteNonQuery()

    End Sub
    Sub FillCustomerNameCombo(ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        cmbCustomerName.DataSource = Nothing

        cmbCustomerName.DataSource = ds.Tables(NameOfTable)
        cmbCustomerName.DisplayMember = DisplayMember
        cmbCustomerName.ValueMember = ValueMember
    End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick

        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1

        If DG.CurrentRow.Index = CurrowIndex Then
            DG.CurrentRow.Cells(2).ReadOnly = False
            DG.CurrentRow.Cells(1).ReadOnly = False

        Else
            DG.CurrentRow.Cells(2).ReadOnly = True

        End If
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.CurrentCell.ColumnIndex = 6 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub

    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing

        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'Validation of Datagrid Cell Quantity:

        If DG.CurrentCell.ColumnIndex = 6 Then
            Dim ltxt As New TextBox
            ltxt = CType(e.Control, TextBox)
            AddHandler ltxt.KeyPress, AddressOf NumericKeys
        End If
        'Ended here
        If DG.CurrentCell.ColumnIndex = 1 Then
            Try
                Dim cmb As ComboBox
                cmb = CType(e.Control, ComboBox)
                AddHandler cmb.SelectionChangeCommitted, AddressOf k1
            Catch ex As Exception
            End Try
        End If
        'End If
        If DG.CurrentRow.Index = CurrowIndex Then
            Try
                Dim cmb As ComboBox
                cmb = CType(e.Control, ComboBox)
                AddHandler cmb.SelectionChangeCommitted, AddressOf K2

            Catch ex As Exception
            End Try
        End If
        'Delegation for setting data in a cell without having to leave that cell.
        Dim cont As Control = e.Control
        Dim tpe As Type = cont.GetType
        If tpe.FullName = "System.Windows.Forms.DataGridViewTextBoxEditingControl" Then
            Try
                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf DelegateCellData

            Catch ex As Exception

            End Try
        ElseIf tpe.FullName = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then
            'Try
            '    Dim cmb As ComboBox
            '    cmb = CType(e.Control, ComboBox)
            '    AddHandler cmb.SelectionChangeCommitted, AddressOf DelegateCellData

            'Catch ex As Exception
            'End Try
        End If

    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Sub k1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                DG.CurrentRow.Cells(1).Value = sender.Text
                DG.CurrentRow.Cells("DGProdTypeID").Value = sender.SelectedValue
                Module1.DatasetFill("Select ProdCode,Product from VuProduct where ProdTypeName = N'" & DG.CurrentRow.Cells(1).Value & "'", "VuProduct")
                'Module1.GetValue("ProdCode,Product", "VuProduct", "ProdTypeName = N'" & DG.CurrentRow.Cells(1).Value & "'")
                DGProductCode.DataSource = ds.Tables("VuProduct")
                DGProductCode.DisplayMember = ("Product")
                DGProductCode.ValueMember = ("ProdCode")
                CurrowIndex = DG.CurrentRow.Index
                DG.CurrentRow.Cells(3).Value = ""

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub K2(ByVal sender As Object, ByVal e As System.EventArgs)
        If DG.CurrentCell.ColumnIndex = 2 Then
            DG.CurrentRow.Cells(3).Value = sender.text
            DG.CurrentRow.Cells(4).Value = sender.selectedvalue
            CurrowIndex = DG.CurrentRow.Index
        End If
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If Var_SalOrderID = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptVuOrderFromCustomerMain where SalOrderID=" & Var_SalOrderID, "RptVuOrderFromCustomerMain")
                Dim rpt As New RptOrderFromCustomer
                rpt.SetDataSource(Module1.ds.Tables("RptVuOrderFromCustomerMain"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPromptCustomerForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPromptCustomerForm.Click

        FrmCustomer.Show()
        FrmCustomer.MdiParent = Frm
        Me.Close()
    End Sub


    Private Sub cmbCustomerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerType.SelectedIndexChanged
        'If Search = False Then
        If AddEdit.Equals(True) Then
            Try
                Module1.DatasetFill("Select * from Customer where CustomerTypeID =" & cmbCustomerType.SelectedValue, "Customer")
                Call FillCustomerNameCombo("Customer", "CustomerName", "CustomerID")

            Catch ex As Exception

            End Try

        End If
        'End If
    End Sub

    Private Sub cmbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        Try
            If AddEdit.Equals(True) Then
                ' If a saleman is selected then to this:
                If cmbCustomerType.SelectedValue = 1 Then
                    Call OrderNoGenerator()
                    txtOrderNo.Text = _OrderNo
                Else
                    txtOrderNo.Text = ""
                End If

                Module1.DatasetFill("Select * from VuCustomerLocShop where CustomerID=" & cmbCustomerName.SelectedValue, "VuCustomerLocShop")
                cmbLocation.SelectedValue = ds.Tables("VuCustomerLocShop").Rows(0).Item("LocID")
                cmbShop.SelectedValue = ds.Tables("VuCustomerLocShop").Rows(0).Item("ShopID")

                If cmbCustomerType.SelectedIndex > 1 Then
                    If ds.Tables("VuCustomerLocShop").Rows(0).Item("LocID") = 0 Then
                        'Incase this person doesn't have shop
                        cmbLocation.Visible = False
                        lblLocation.Visible = False
                        cmbShop.Visible = False
                        lblShop.Visible = False
                    Else
                        'Incase this person has shop
                        cmbLocation.Visible = True
                        lblLocation.Visible = True
                        cmbShop.Visible = True
                        lblShop.Visible = True
                    End If
                Else
                    'Incase this person is a saleman or province dealer.
                    cmbLocation.Visible = False
                    lblLocation.Visible = False
                    cmbShop.Visible = False
                    lblShop.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbCustomerType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCustomerType.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbCustomerName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCustomerName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub
    Private Sub DG_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                ListViewFill()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSearch.Click
        Try
            Module1.DatasetFill("Select * from VuCustomerTypeForOrderMainSearch", "VuCustomerTypeForOrderMainSearch")
            cmbCustomerTypeSearch.DataSource = ds.Tables("VuCustomerTypeForOrderMainSearch")
            cmbCustomerTypeSearch.DisplayMember = ("CustomerTypeName")
            cmbCustomerTypeSearch.ValueMember = ("CustomerTypeID")

            Clear()
            cmbCustomerType.SelectedIndex = -1
            cmbCustomerName.SelectedIndex = -1
            cmbShop.SelectedIndex = -1
            cmbLocation.SelectedIndex = -1

            Label2.Visible = True
            cmbOrderNoSearch.Visible = True
            Label1.Visible = True
            cmbCustomerNameSearch.Visible = True
            Label3.Visible = True
            cmbCustomerTypeSearch.Visible = True

            MnuReturn.Visible = True
            MnuSearch.Visible = False

            'Search = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReturn.Click
        If DG.Rows.Count = 1 And cmbCustomerType.Text = "" And cmbCustomerName.Text = "" Then
            txtfill()
        End If

        Label2.Visible = False
        cmbOrderNoSearch.Visible = False
        Label1.Visible = False
        cmbCustomerNameSearch.Visible = False
        Label3.Visible = False
        cmbCustomerTypeSearch.Visible = False

        MnuSearch.Visible = True
        MnuReturn.Visible = False

        'Search = False
    End Sub

    Private Sub cmbOrderNoSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbOrderNoSearch.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then

                Module1.DatasetFill("Select * from OrderFromCustomerMain Order by SalOrderID", "OrderFromCustomerMain")

                Dim Var_numberOfOccurance As Integer = 0
                Dim Var_PostionFound As Integer = 0
                Dim Var_loopLength As Integer = 0
                Dim Var_LetAssignment As Boolean = True
                For Each dtr As DataRow In ds.Tables("OrderFromCustomerMain").Rows
                    If cmbOrderNoSearch.SelectedValue = dtr("SalOrderID") Then
                        Var_numberOfOccurance += 1

                    Else

                    End If
                    If Var_numberOfOccurance = 1 And Var_LetAssignment = True Then
                        Var_PostionFound = Var_loopLength
                        Var_LetAssignment = False
                    End If
                    Var_loopLength += 1
                Next
                If Var_numberOfOccurance = 0 Then
                    txtclear()
                    'Module1.GetMax("SocialDataID", "SocialData")
                    'lblRecNo.Text = Module1.MaxID
                    'CStatusDefault()
                    MnuEdit.Enabled = False
                    MnuNew.Enabled = True

                    Exit Sub
                Else
                    cnt = Var_PostionFound
                    lblMessage.Text = ""

                    'Module1.DatasetFill("Select * from OrderFromCustomerMain where SalOrderID=" & cmbOrderNoSearch.SelectedValue, "OrderFromCustomerMain")

                    If ds.Tables("OrderFromCustomerMain").Rows.Count = 0 Then
                        Call txtclear()
                        Exit Sub
                    Else
                        Me.Var_SalOrderID = Val(ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("SalOrderID"))
                        cmbCustomerType.SelectedValue = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("CustomerTypeID")
                        cmbCustomerName.SelectedValue = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("CustomerID")
                        cmbLocation.SelectedValue = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("LocID")
                        cmbShop.SelectedValue = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("ShopID")
                        If ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("LocID") = 0 Then
                            'Incase this person doesn't have shop
                            cmbLocation.Visible = False
                            lblLocation.Visible = False
                            cmbShop.Visible = False
                            lblShop.Visible = False
                        Else
                            'Incase this person has shop
                            cmbLocation.Visible = True
                            lblLocation.Visible = True
                            cmbShop.Visible = True
                            lblShop.Visible = True
                        End If
                        txtOrderNo.Text = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("SalOrderNo")
                        dtOrderDate.Value = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("OrderDate")
                        dtReqDate.Value = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("ReqDate")
                        txtRemarks.Text = ds.Tables("OrderFromCustomerMain").Rows(cnt).Item("Remarks")
                        Call GridFill()

                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbOrderNoSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbOrderNoSearch.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub cmbCustomerTypeSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerTypeSearch.SelectedIndexChanged
        Try

            Module1.DatasetFill("Select * from VuCustomerNameForOrderFromCustomerSearch where CustomerTypeID=" & cmbCustomerTypeSearch.SelectedValue, "VuCustomerNameForOrderFromCustomerSearch")
            cmbCustomerNameSearch.DataSource = ds.Tables("VuCustomerNameForOrderFromCustomerSearch")
            cmbCustomerNameSearch.DisplayMember = ("CustomerName")
            cmbCustomerNameSearch.ValueMember = ("CustomerID")

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbCustomerNameSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerNameSearch.SelectedIndexChanged
        Try

            Module1.DatasetFill("Select * from VuSalOrderNoForOrderFromCustomerSearch where CustomerTypeID=" & cmbCustomerTypeSearch.SelectedValue & " and CustomerID=" & cmbCustomerNameSearch.SelectedValue & "", "VuSalOrderNoForOrderFromCustomerSearch")
            cmbOrderNoSearch.DataSource = ds.Tables("VuSalOrderNoForOrderFromCustomerSearch")
            cmbOrderNoSearch.DisplayMember = ("SalOrderNo")
            cmbOrderNoSearch.ValueMember = ("SalOrderID")

        Catch ex As Exception
        End Try
    End Sub
End Class
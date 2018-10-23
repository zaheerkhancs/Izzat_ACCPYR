Imports System.Data.SqlClient
Public Class frmStockViewer
    Dim Str As String
    Dim a As Integer
    Dim azizspliter() As String
    Dim z As Integer

    Private Sub frmStockViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        'TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        'TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        'pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        'pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.Opencn()
        GridFillForStock()
    End Sub
    Sub Print()
        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertStockResult"
        cmdsave.Connection = cn
        Try
            Module1.DeleteRecord("StockResult")
            For z = 0 To DG.Rows.Count - 1

                cmdsave.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(z).Cells("DGSNO").Value
                cmdsave.Parameters.Add("@PType", SqlDbType.NVarChar).Value = DG.Rows(z).Cells("DGProdTypeName").Value
                cmdsave.Parameters.Add("@PName", SqlDbType.NVarChar).Value = DG.Rows(z).Cells("DGProductName").Value
                cmdsave.Parameters.Add("@Remaining", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGTotal").Value)
                cmdsave.Parameters.Add("@Purchase", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGPurchase").Value)
                cmdsave.Parameters.Add("@SalePcs", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGSalePcs").Value)
                cmdsave.Parameters.Add("@SaleCrtn", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGSaleCrtn").Value)
                cmdsave.Parameters.Add("@SaleTotal", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGSale").Value)
                cmdsave.Parameters.Add("@ReturnPcs", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGReturnPcs").Value)
                cmdsave.Parameters.Add("@ReturnCrtn", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGReturnCrtn").Value)
                cmdsave.Parameters.Add("@ReturnTotal", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGReturn").Value)
                cmdsave.Parameters.Add("@ClaimPcs", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGClaimPcs").Value)
                cmdsave.Parameters.Add("@ClaimCrtn", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGClaimCrtn").Value)
                cmdsave.Parameters.Add("@ClaimTotal", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGClaim").Value)
                cmdsave.Parameters.Add("@DamagePcs", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGDamagePcs").Value)
                cmdsave.Parameters.Add("@DamageCrtn", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGDamageCrtn").Value)
                cmdsave.Parameters.Add("@DamageTotal", SqlDbType.Decimal).Value = Val(DG.Rows(z).Cells("DGDamage").Value)

                If cn.State = ConnectionState.Closed Then cn.Open()
                cmdsave.ExecuteNonQuery()
                cmdsave.Parameters.Clear()
            Next

        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select * from StockResult", "StockResult")
            Dim rpt As New RptStock
            rpt.SetDataSource(Module1.ds.Tables("StockResult"))
            frmRptSetup.CV.ReportSource = rpt
            Frm.RptShow()
        Catch ex As Exception
        End Try

    End Sub

    Sub Calculator()
        Dim b As String
        Dim CrtnPcsDivision As Decimal
        Dim c As Decimal
        Dim aziz As String
        Dim Fullportion As String
        Dim PointPortion As String
        Dim ReadyToAssignValue As String
        Try
            CrtnPcsDivision = Val(DG.Rows(a).Cells("DGSalePcs").Value) / Val(DG.Rows(a).Cells("DGPcsinCrtn").Value)
            If CrtnPcsDivision = 0 Then
                DG.Rows(a).Cells("DGSale").Value = DG.Rows(a).Cells("DGSaleCrtn").Value
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
                        DG.Rows(a).Cells("DGSale").Value = Val(DG.Rows(a).Cells("DGSaleCrtn").Value) + ReadyToAssignValue
                    Else
                        DG.Rows(a).Cells("DGSale").Value = Val(DG.Rows(a).Cells("DGSaleCrtn").Value) + CrtnPcsDivision
                    End If
                Else
                    DG.Rows(a).Cells("DGSale").Value = Val(DG.Rows(a).Cells("DGSaleCrtn").Value) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(DG.Rows(a).Cells("DGReturnPcs").Value) / Val(DG.Rows(a).Cells("DGPcsinCrtn").Value)
            If CrtnPcsDivision = 0 Then
                DG.Rows(a).Cells("DGReturn").Value = DG.Rows(a).Cells("DGReturnCrtn").Value
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
                        DG.Rows(a).Cells("DGReturn").Value = Val(DG.Rows(a).Cells("DGReturnCrtn").Value) + ReadyToAssignValue
                    Else
                        DG.Rows(a).Cells("DGReturn").Value = Val(DG.Rows(a).Cells("DGReturnCrtn").Value) + CrtnPcsDivision
                    End If
                Else
                    DG.Rows(a).Cells("DGReturn").Value = Val(DG.Rows(a).Cells("DGReturnCrtn").Value) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(DG.Rows(a).Cells("DGClaimPcs").Value) / Val(DG.Rows(a).Cells("DGPcsinCrtn").Value)
            If CrtnPcsDivision = 0 Then
                DG.Rows(a).Cells("DGClaim").Value = DG.Rows(a).Cells("DGClaimCrtn").Value
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
                        DG.Rows(a).Cells("DGClaim").Value = Val(DG.Rows(a).Cells("DGClaimCrtn").Value) + ReadyToAssignValue
                    Else
                        DG.Rows(a).Cells("DGClaim").Value = Val(DG.Rows(a).Cells("DGClaimCrtn").Value) + CrtnPcsDivision
                    End If
                Else
                    DG.Rows(a).Cells("DGClaim").Value = Val(DG.Rows(a).Cells("DGClaimCrtn").Value) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(DG.Rows(a).Cells("DGDamagePcs").Value) / Val(DG.Rows(a).Cells("DGPcsinCrtn").Value)
            If CrtnPcsDivision = 0 Then
                DG.Rows(a).Cells("DGDamage").Value = DG.Rows(a).Cells("DGDamageCrtn").Value
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
                        DG.Rows(a).Cells("DGDamage").Value = Val(DG.Rows(a).Cells("DGDamageCrtn").Value) + ReadyToAssignValue
                    Else
                        DG.Rows(a).Cells("DGDamage").Value = Val(DG.Rows(a).Cells("DGDamageCrtn").Value) + CrtnPcsDivision
                    End If
                Else
                    DG.Rows(a).Cells("DGDamage").Value = Val(DG.Rows(a).Cells("DGDamageCrtn").Value) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub Selecter()
        Try
            Module1.DatasetFill("Select Sum(PurchaseQty) As Purchase from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Purchase'", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("Purchase") Then
                DG.Rows(a).Cells("DGPurchase").Value = 0
            Else
                DG.Rows(a).Cells("DGPurchase").Value = ds.Tables("IGL").Rows(0).Item("Purchase")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(SaleQty) As SalePcs from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Sale' and CrtnPcs = 1", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("SalePcs") Then
                DG.Rows(a).Cells("DgSalePcs").Value = 0
            Else
                DG.Rows(a).Cells("DgSalePcs").Value = ds.Tables("IGL").Rows(0).Item("SalePcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(SaleQty) As SaleCrtn from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Sale' and CrtnPcs = 2", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("SaleCrtn") Then
                DG.Rows(a).Cells("DgSaleCrtn").Value = 0
            Else
                DG.Rows(a).Cells("DgSaleCrtn").Value = ds.Tables("IGL").Rows(0).Item("SaleCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ReturnQty) As ReturnPcs from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Sale Return' and CrtnPcs = 1", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("ReturnPcs") Then
                DG.Rows(a).Cells("DGReturnPcs").Value = 0
            Else
                DG.Rows(a).Cells("DGReturnPcs").Value = ds.Tables("IGL").Rows(0).Item("ReturnPcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ReturnQty) As ReturnCrtn from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Sale Return' and CrtnPcs = 2", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("ReturnCrtn") Then
                DG.Rows(a).Cells("DgReturnCrtn").Value = 0
            Else
                DG.Rows(a).Cells("DgReturnCrtn").Value = ds.Tables("IGL").Rows(0).Item("ReturnCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ClaimQty) As ClaimPcs from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Claim' and CrtnPcs = 1", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("ClaimPcs") Then
                DG.Rows(a).Cells("DGClaimPcs").Value = 0
            Else
                DG.Rows(a).Cells("DGClaimPcs").Value = ds.Tables("IGL").Rows(0).Item("ClaimPcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ClaimQty) As ClaimCrtn from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Claim' and CrtnPcs = 2", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("ClaimCrtn") Then
                DG.Rows(a).Cells("DGClaimCrtn").Value = 0
            Else
                DG.Rows(a).Cells("DGClaimCrtn").Value = ds.Tables("IGL").Rows(0).Item("ClaimCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(DamageQty) As DamagePcs from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Damage' and CrtnPcs = 1", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("DamagePcs") Then
                DG.Rows(a).Cells("DGDamagePcs").Value = 0
            Else
                DG.Rows(a).Cells("DGDamagePcs").Value = ds.Tables("IGL").Rows(0).Item("DamagePcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(DamageQty) As DamageCrtn from IGL where ProductCode=" & DG.Rows(a).Cells("DGID").Value & " and Type='Damage' and CrtnPcs = 2", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("DamageCrtn") Then
                DG.Rows(a).Cells("DGDamageCrtn").Value = 0
            Else
                DG.Rows(a).Cells("DGDamageCrtn").Value = ds.Tables("IGL").Rows(0).Item("DamageCrtn")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub GridFillForStock()
        Module1.DatasetFill("Select * from VuProductForIGL", "VuProductForIGL")
        For a = 0 To ds.Tables("VuProductForIGL").Rows.Count - 1
            DG.Rows.Add()
            DG.Rows(a).Cells("DgProdTypeName").Value = ds.Tables("VuProductForIGL").Rows(a).Item("ProdTypeName")
            DG.Rows(a).Cells("DGProductName").Value = ds.Tables("VuProductForIGL").Rows(a).Item("Product")
            DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuProductForIGL").Rows(a).Item("PcsInCtrn")
            DG.Rows(a).Cells("DGID").Value = ds.Tables("VuProductForIGL").Rows(a).Item("ProdCode")
            Call Selecter()
            Calculator()
        Next
    End Sub

    Private Sub BTNcLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNcLOSE.Click
        Me.Close()
    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Dim indexcount As Integer
        Try
            For indexcount = 0 To DG.Rows.Count - 1
                DG.Rows(indexcount).Cells(0).Value = DG.Rows(indexcount).Index + 1
            Next
        Catch ex As Exception
        End Try
        Dim Amad As Double = 0
        Dim Raft As Double = 0
        Dim Total As Double = 0
        Dim a As Integer
        Try
            For a = 0 To DG.Rows.Count - 1
                Amad = 0
                Raft = 0
                Amad = Amad + Val(DG.Rows(a).Cells("DGPurchase").Value) + Val(DG.Rows(a).Cells("DGReturn").Value)
                Raft = Raft + Val(DG.Rows(a).Cells("DGSale").Value) + Val(DG.Rows(a).Cells("DGClaim").Value) + Val(DG.Rows(a).Cells("DgDamage").Value)
                Total = Amad - Raft
                DG.Rows(a).Cells("DGTotal").Value = Total
            Next

        Catch ex As Exception

        End Try
    End Sub

#Region "NOT USEABLE NOW..............................."

    Sub GridFillForDetail()
        Try
            If DG.CurrentCell.ColumnIndex = 5 Then
                Module1.DatasetFill("Select Sum(ReturnQty) as Total,Sum(Broken)as Broken,Sum(Leak)as Leak,Sum(Short) as Short,Sum(Dent) as Dent from IGL Where ProductCode=" & DG.CurrentRow.Cells("DGID").Value & " and Type='Sale Return'", "IGL")
                If ds.Tables("IGL").Rows(0).IsNull("Total") Then
                    If DG.Height = 278 Then
                        DG.Height = DG.Height + 300
                    End If
                    'DGDetail.Visible = False
                    MsgBox("There is no record for sale return", MsgBoxStyle.Information)
                    Exit Sub
                End If
            ElseIf DG.CurrentCell.ColumnIndex = 6 Then
                Module1.DatasetFill("Select Sum(ClaimQty) as Total,Sum(Broken)as Broken,Sum(Leak)as Leak,Sum(Short) as Short,Sum(Dent) as Dent from IGL Where ProductCode=" & DG.CurrentRow.Cells("DGID").Value & " and Type='Claim'", "IGL")
                If ds.Tables("IGL").Rows(0).IsNull("Total") Then
                    If DG.Height = 278 Then
                        DG.Height = DG.Height + 300
                    End If
                    'DGDetail.Visible = False
                    MsgBox("There is no record for claim", MsgBoxStyle.Information)
                    Exit Sub
                End If
            ElseIf DG.CurrentCell.ColumnIndex = 7 Then
                Module1.DatasetFill("Select Sum(DamageQty) as Total,Sum(Broken)as Broken,Sum(Leak)as Leak,Sum(Short) as Short,Sum(Dent) as Dent from IGL Where ProductCode=" & DG.CurrentRow.Cells("DGID").Value & " and Type='Damage'", "IGL")
                If ds.Tables("IGL").Rows(0).IsNull("Total") Then
                    If DG.Height = 278 Then
                        DG.Height = DG.Height + 300
                    End If
                    'DGDetail.Visible = False
                    MsgBox("There is no record for damage", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If


            Try

                'DGDetail.Rows(0).Cells("DGBroken").Value = ds.Tables("IGL").Rows(0).Item("Broken")
                'DGDetail.Rows(0).Cells("DGLeak").Value = ds.Tables("IGL").Rows(0).Item("Leak")
                'DGDetail.Rows(0).Cells("DGShort").Value = ds.Tables("IGL").Rows(0).Item("Short")
                'DGDetail.Rows(0).Cells("DgDent").Value = ds.Tables("IGL").Rows(0).Item("Dent")
                'DGDetail.Rows(0).Cells("DGTotalDetail").Value = ds.Tables("IGL").Rows(0).Item("Total")

            Catch ex As Exception
            End Try


        Catch ex As Exception
        End Try
    End Sub

    'Private Sub DG_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellDoubleClick
    '    If DG.CurrentCell.ColumnIndex <> 5 And DG.CurrentCell.ColumnIndex <> 6 And DG.CurrentCell.ColumnIndex <> 7 Then
    '        DGDetail.Visible = False
    '        If DG.Height = 278 Then
    '            DG.Height = DG.Height + 300
    '        End If
    '    Else
    '        DGDetail.Rows(0).Cells("DGProdTypeNameDetail").Value = DG.CurrentRow.Cells("DGProdTypeName").Value
    '        DGDetail.Rows(0).Cells("DGProductNameDetail").Value = DG.CurrentRow.Cells("DGProductName").Value
    '        If DG.Height = 278 Then
    '            GridFillForDetail()
    '        Else
    '            DG.Height = DG.Height - 300
    '            DGDetail.Visible = True
    '            GridFillForDetail()
    '        End If
    '    End If
    'End Sub

#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub
End Class
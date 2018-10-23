Imports System.Data.SqlClient
Public Class FrmChartOfAccount
    Dim First As String = "00"
    Dim Second As String = "00"
    Dim Third As String = "0000"
    Dim cnt As Integer = 0
    Dim Flag As Integer
    Dim Trans As SqlTransaction
    Private Sub FrmChartOfAccount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Me.MaximizeBox = False
            Module1.Opencn()
            ''Me.Left = 0
            ''Me.Top = 0
            Dim sts As Boolean
            sts = Module1.GetValue("AccStatus", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")

            Module1.DatasetFill("Select * from VuPermission Where GroupID=" & Frm.GID.Text & " and PerName=N'Chart of Account'", "VuPermission")
            If ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
                MsgBox("You have no right to view this Form . For further detail contact your administrator", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Alert")
                Me.Close()
                Exit Sub
            ElseIf ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = True And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
                Me.ToolStripMenuEdit.Visible = False

            ElseIf ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = True And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
                Me.ToolStripMenuEdit.Visible = False
                Me.ToolStripMenuSave.Visible = False
                Me.ContextM.Enabled = False
            End If
            If sts = 0 Then
                Me.ToolStripMenuEdit.Visible = False
                Me.ToolStripMenuSave.Visible = False
                Me.NewToolStripMenuItem.Visible = False
                LblAlert.Visible = True
                Me.ContextM.Enabled = False
            Else
                LblAlert.Visible = False
            End If





            ''Me.Height = Frm.Height - 0
            ''Me.Width = Frm.Width - 0
            Panel1.Left = Me.Width / 2 - (Panel1.Width / 2)
            Panel1.Top = Me.Height / 2 - (Panel1.Height / 2)
            Module1.DatasetFill("Select * from AccountType", "AccountType")
            CmbAccCategory.DataSource = ds.Tables("AccountType")
            CmbAccCategory.ValueMember = "AccID"
            CmbAccCategory.DisplayMember = "AccName"
            ''
            Module1.DatasetFill("Select * from VuChartOfAcc", "VuChartofAcc")

            'CmbAccCategory.SelectedIndex = -1
            'CmbAccCategory.Text = "Select Option"
            'Frm.Show()
            'MsgBox(System.AppDomain.CurrentDomain.BaseDirectory).ToString()
            Call TxtFill()
        Catch ex As Exception

        End Try

    End Sub

    Sub TxtFill()
        Try

            Me.CmbAccCategory.SelectedValue = ds.Tables("VuChartofAcc").Rows(cnt).Item("AccID")
            Me.CmbSubAccCategory.SelectedValue = ds.Tables("VuChartofAcc").Rows(cnt).Item("CatID")
            'MsgBox(ds.Tables("VuChartofAcc").Rows(cnt).Item(1).ToString)
            Me.TxtHeadCode.Text = ds.Tables("VuChartofAcc").Rows(cnt).Item("HeadID")
            Me.TxtName.Text = ds.Tables("VuChartofAcc").Rows(cnt).Item("HeadName")
            Me.DTDate.Value = ds.Tables("VuChartofAcc").Rows(cnt).Item("Date")
            Me.TxtRemarks.Text = ds.Tables("VuChartofAcc").Rows(cnt).Item("Remarks")
            Me.TxtDr.Text = ds.Tables("VuChartofAcc").Rows(cnt).Item("Dr")
            Me.TxtCr.Text = ds.Tables("VuChartofAcc").Rows(cnt).Item("Cr")



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
    Private Sub CmbAccCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAccCategory.SelectedIndexChanged
        Try
            First = "00"
            If CmbAccCategory.ValueMember = Nothing Then Exit Sub

            CmbSubAccCategory.DataSource = Nothing
            CmbSubAccCategory.Items.Clear()
            Module1.DatasetFill("Select * from AccountCategory where AccID=" & Val(CmbAccCategory.SelectedValue), "AccountCategory")
            CmbSubAccCategory.DataSource = ds.Tables("AccountCategory")
            CmbSubAccCategory.ValueMember = "CatID"
            CmbSubAccCategory.DisplayMember = "CatTitle"

            'If CmbAccCategory.SelectedValue < 9 Then
            '    Me.TxtHeadCode.Text = "0" & CmbAccCategory.SelectedValue
            'Else
            '    Me.TxtHeadCode.Text = CmbAccCategory.SelectedValue
            'End If
            First = "0" & CmbAccCategory.SelectedValue
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub StatusMnu()
        Me.ToolStripMenuEdit.Enabled = Not Me.ToolStripMenuEdit.Enabled
        Me.NewToolStripMenuItem.Enabled = Not Me.NewToolStripMenuItem.Enabled
        Me.ToolStripMenuItemUndo.Enabled = Not Me.ToolStripMenuItemUndo.Enabled
        Me.ToolStripMenuSave.Enabled = Not Me.ToolStripMenuSave.Enabled

        CmbAccCategory.Enabled = Not CmbAccCategory.Enabled
        CmbSubAccCategory.Enabled = Not CmbSubAccCategory.Enabled
        TxtCr.ReadOnly = Not TxtCr.ReadOnly
        TxtDr.ReadOnly = Not TxtDr.ReadOnly
        TxtName.ReadOnly = Not TxtName.ReadOnly
        'TxtHeadCode.ReadOnly = Not TxtHeadCode.ReadOnly
        TxtRemarks.ReadOnly = Not TxtRemarks.ReadOnly

        DTDate.Enabled = Not DTDate.Enabled

    End Sub

    Private Sub CClear()
        Me.CmbAccCategory.SelectedIndex = -1
        Me.CmbSubAccCategory.SelectedIndex = -1
        Me.TxtCr.Text = 0
        Me.TxtDr.Text = 0
        Me.TxtHeadCode.Text = "00000000"
        Me.TxtName.Text = ""
        Me.TxtRemarks.Text = ""
        DTDate.Value = Now
    End Sub




    Private Sub TxtDr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
    End Sub
    Sub Save()
        Trans = cn.BeginTransaction
        Try


            Dim cmdSave As New SqlCommand
            cmdSave.Connection = cn
            cmdSave.Transaction = Trans
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "InsertChartofAcc"
            ''@CatID, @HeadID, @HeadName, @Date, @Remarks, @Dr, @Cr, @UserID, @CompanyID, @WName
            cmdSave.Parameters.Add("@CatID", SqlDbType.Char)
            cmdSave.Parameters("@CatID").Value = Me.CmbSubAccCategory.SelectedValue
            cmdSave.Parameters.Add("@HeadID", SqlDbType.NVarChar)
            cmdSave.Parameters("@HeadID").Value = Me.TxtHeadCode.Text
            cmdSave.Parameters.Add("@HeadName", SqlDbType.NVarChar)
            cmdSave.Parameters("@HeadName").Value = Me.TxtName.Text
            cmdSave.Parameters.Add("@Date", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@Date").Value = Me.DTDate.Value.Date
            Dim DrAmount As Decimal
            Dim CrAmount As Decimal
            If TxtDr.Text.Trim() = "" Then
                DrAmount = 0
            Else
                DrAmount = TxtDr.Text
            End If
            If TxtCr.Text.Trim() = "" Then
                CrAmount = 0
            Else
                CrAmount = TxtCr.Text
            End If
            cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
            cmdSave.Parameters("@Dr").Value = DrAmount
            cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
            cmdSave.Parameters("@Cr").Value = CrAmount
            cmdSave.Parameters.Add("@UserID", SqlDbType.Int)
            cmdSave.Parameters("@UserID").Value = Val(Frm.LbUserID.Text)
            cmdSave.Parameters.Add("@CompanyID", SqlDbType.Int)
            cmdSave.Parameters("@CompanyID").Value = Val(Frm.LBCompanyID.Text)
            cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave.Parameters("@Remarks").Value = Me.TxtRemarks.Text
            cmdSave.Parameters.Add("@WName", SqlDbType.NVarChar)
            cmdSave.Parameters("@WName").Value = Frm.WName.Text
            cmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
            cmdSave.Parameters("@Flag").Value = Flag

            If Flag = 1 Then
                cmdSave.ExecuteNonQuery()
                Call SaveVoucher()
                Trans.Commit()
                GridSave()
                Dim frmm As New FrmBox("Your Record has been saved successfully..")
                frmm.ShowDialog()

            Else
                cmdSave.ExecuteNonQuery()
                Flag = 1
                Call DeleteGrid()
                Call SaveVoucher()
                Trans.Commit()
                GridSave()
                Dim frmm As New FrmBox("Your Record has been Updated successfully..")
                frmm.ShowDialog()


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Trans.Rollback()

        End Try

    End Sub
    Sub SaveVoucher()
        'Try



        Dim cmdSave As New SqlCommand
        cmdSave.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave.Connection = cn
        cmdSave.CommandType = CommandType.StoredProcedure
        cmdSave.CommandText = "InsertUpdateVMain"
        cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave.Parameters("@Vno").Value = "OB" & Frm.LblPeriod.Text & "" & Me.TxtHeadCode.Text
        cmdSave.Parameters.Add("@Vtype", SqlDbType.NVarChar)
        cmdSave.Parameters("@Vtype").Value = "OB"
        cmdSave.Parameters.Add("@Date", SqlDbType.SmallDateTime)
        cmdSave.Parameters("@Date").Value = Me.DTDate.Value.Date
        cmdSave.Parameters.Add("@descr", SqlDbType.NVarChar)
        cmdSave.Parameters("@descr").Value = "from Chart of Account"
        cmdSave.Parameters.Add("@UserID", SqlDbType.Int)
        cmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text
        cmdSave.Parameters.Add("@CompanyID", SqlDbType.Int)
        cmdSave.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text
        cmdSave.Parameters.Add("@WName", SqlDbType.NVarChar)
        cmdSave.Parameters("@WName").Value = Frm.WName.Text
        cmdSave.Parameters.Add("@PID", SqlDbType.NVarChar)
        cmdSave.Parameters("@PID").Value = Frm.LblPeriod.Text
        cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave.Parameters("@Remarks").Value = "Nill"
        cmdSave.Parameters.Add("@VKey", SqlDbType.SmallDateTime)
        cmdSave.Parameters("@VKey").Value = Me.DTDate.Value.Date.AddDays(3)
        cmdSave.Parameters.Add("@VPost", SqlDbType.Bit)
        cmdSave.Parameters("@VPost").Value = 1

        cmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
        cmdSave.Parameters("@Flag").Value = Flag

        cmdSave.Parameters.Add("@Received", SqlDbType.NVarChar)
        cmdSave.Parameters("@Received").Value = ""

        cmdSave.Parameters.Add("@paid", SqlDbType.NVarChar)
        cmdSave.Parameters("@paid").Value = ""

        cmdSave.Parameters.Add("@Cheque", SqlDbType.NVarChar)
        cmdSave.Parameters("@Cheque").Value = ""

        ' MsgBox(Me.DTDate.Value.AddDays(3))



        cmdSave.ExecuteNonQuery()

        'Trans.Commit()
        'Dim frmm As New FrmBox("Your Record has been saved successfully..")
        'frmm.ShowDialog()
        'Else
        '    If EditFlag = False Then
        '        MsgBox("Sorry :  you cannot do entry on wrong date..", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
        '        Exit Sub







    End Sub


    Sub GridSave()

        Dim cmdSave As New SqlCommand
        'cmdSave.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave.Connection = cn
        cmdSave.CommandType = CommandType.StoredProcedure
        cmdSave.CommandText = "SaveDetail"
        cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave.Parameters("@Vno").Value = "OB" & Frm.LblPeriod.Text & "" & Me.TxtHeadCode.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave.Parameters("@HeadID").Value = Me.TxtHeadCode.Text
        cmdSave.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave.Parameters("@SubID").Value = 0
        cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave.Parameters("@Remarks").Value = "Nill"
        cmdSave.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave.Parameters("@ChequeNo").Value = " "
        cmdSave.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave.Parameters("@ChequeDate").Value = "01/01/1900"
        cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave.Parameters("@Dr").Value = Val(Me.TxtDr.Text)
        cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave.Parameters("@Cr").Value = Val(Me.TxtCr.Text)
        cmdSave.ExecuteNonQuery()





    End Sub

    Sub DeleteGrid()
        Dim cmdDelete As New SqlCommand

        '  If cn.State = ConnectionState.Closed Then cn.Open()
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteMain"
        cmdDelete.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdDelete.Parameters("@Vno").Value = "OB" & Frm.LblPeriod.Text & "" & Me.TxtHeadCode.Text
        cmdDelete.ExecuteNonQuery()

    End Sub



    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Call CClear()
        StatusMnu()
        CmbAccCategory.Enabled = True
        CmbSubAccCategory.Enabled = True
        Flag = 1

    End Sub

    Private Sub ToolStripMenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuSave.Click
        If CheckStatus() = False Then Exit Sub
        Call Save()
        StatusMnu()
        CmbAccCategory.Enabled = False
        CmbSubAccCategory.Enabled = False
        Module1.DatasetFill("Select * from VuChartOfAcc", "VuChartofAcc")
        Call TxtFill()

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuChartofAcc").Rows.Count - 1 Then
            MsgBox("You are on the last record...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        cnt = cnt + 1
        Call TxtFill()
    End Sub
    Function CheckStatus() As Boolean
        If Me.TxtName.Text = "" Then
            CheckStatus = False
            MsgBox("Please Enter the Head Name")
            Exit Function
        End If
        If Me.CmbAccCategory.Text = "" Then
            CheckStatus = False
            MsgBox("Please Select the Account Catatogry..")
            Exit Function
        End If
        If Me.CmbSubAccCategory.Text = "" Then
            CheckStatus = False
            MsgBox("Please Select the Sub Account Catatogry..")
            Exit Function
        End If
        CheckStatus = True

    End Function

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuChartofAcc").Rows.Count - 1
        Call TxtFill()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then
            MsgBox("You are on the first record...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        cnt = cnt - 1
        Call TxtFill()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        Call TxtFill()
    End Sub

    Private Sub ToolStripMenuItemUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemUndo.Click
        StatusMnu()
        CmbAccCategory.Enabled = False
        CmbSubAccCategory.Enabled = False
        Call TxtFill()
    End Sub

    Private Sub ToolStripMenuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuEdit.Click
        StatusMnu()
        CmbAccCategory.Enabled = False
        CmbSubAccCategory.Enabled = False
        Flag = 0

    End Sub

    Private Sub CmbSubAccCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSubAccCategory.SelectedIndexChanged
        Try

            If CmbSubAccCategory.ValueMember = Nothing Then
                CmbSubAccCategory.SelectedIndex = -1
                Exit Sub
            End If

            'If IsNothing(CmbSubAccCategory.SelectedValue) Then Exit Sub

            '''''''''''''''''''Comments--------------------------------
            ' Second = ""
            'Second = CmbSubAccCategory.SelectedValue
            'If Second.Length = 1 Then
            ' Second = "0" & Second
            ' Else
            ' Second = Second
            ' End If
            ''''''''''''''
            Third = Module1.GetMaxStr("HeadID", "ChartOfAccount", " Catid='" & CmbSubAccCategory.SelectedValue & "'")
            Select Case Third.Length
                Case "1"
                    Third = "000" & Third
                Case "2"
                    Third = "00" & Third
                Case "3"
                    Third = "0" & Third
                Case "4"
                    Third = Third
            End Select


            TxtHeadCode.Text = CmbSubAccCategory.SelectedValue & "" & Third



        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
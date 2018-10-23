Imports System.Data.SqlClient
Public Class FrmCompany
    Dim EditValue As Integer = 0
    Dim cnt As Integer
    Private Sub FinancialPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.MaximizeBox = False
        ''Me.Left = 0
        ''Me.Top = 0
        '  Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
        ' Me.Height = Screen.PrimaryScreen.Bounds.Height - 4
        ''Me.Height = Frm.Height - 70
        ''Me.Width = Frm.Width - 4
        Me.GroupBox1.Left = Me.Width / 2 - (Me.GroupBox1.Width / 2)
        Me.GroupBox1.Top = Me.Height / 2 - (Me.GroupBox1.Height / 2)
        Module1.DatasetFill("Select * from Company", "Company")
        Call txtfill()

    End Sub

    Public Sub add()

        Call StatusMnu()
        Call CClear()
        'Cmd = New SqlCommand("select isnull(max(Fid),0) from FinancialPeriod", GetCon)

        'Me.Dg.Rows.Clear()
        ' editflag = False
        EditValue = 1
        'EnableAll()
        Me.TxtCompanyID.Text = Module1.GetMax("CompanyID", "Company")


        DtFrom.Value = Now
        DtTo.Value = Now
        DtFrom.Enabled = True
        DtTo.Enabled = True
        ChkIsCurrent.Enabled = False
        ChkIsCurrent.Checked = True
        TxtID.Enabled = True

    End Sub
    Private Sub StatusMnu()
        Me.ToolStripMenuEdit.Enabled = Not Me.ToolStripMenuEdit.Enabled
        Me.NewToolStripMenuItem.Enabled = Not Me.NewToolStripMenuItem.Enabled
        Me.ToolStripMenuItemUndo.Enabled = Not Me.ToolStripMenuItemUndo.Enabled
        Me.ToolStripMenuSave.Enabled = Not Me.ToolStripMenuSave.Enabled

        DtFrom.Enabled = Not DtFrom.Enabled
        DtTo.Enabled = Not DtTo.Enabled
        'TxtHeadCode.ReadOnly = Not TxtHeadCode.ReadOnly
        Me.TxtID.ReadOnly = Not Me.TxtID.ReadOnly
        ChkIsCurrent.Enabled = Not ChkIsCurrent.Enabled
        Me.TxtName.ReadOnly = Not Me.TxtName.ReadOnly
        Me.TxtRemarks.ReadOnly = Not Me.TxtRemarks.ReadOnly
    End Sub

    Private Sub CClear()

        Me.TxtID.Text = ""
        Me.TxtName.Text = ""
        Me.TxtRemarks.Text = ""
        Me.DtFrom.Value = Now
        Me.DtTo.Value = Now


    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        add()
    End Sub

    Private Sub ToolStripMenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuSave.Click

        If Me.DtFrom.Value.Date = Me.DtTo.Value.Date Then
            Dim frmm As New FrmBox("Please Enter the correct Finanical Period.")
            frmm.ShowDialog()
            frmm.BackColor = Color.OrangeRed
            Exit Sub
        ElseIf Me.TxtRemarks.Text = "" Then
            Dim frmm1 As New FrmBox("Please Enter the company full name")
            frmm1.BackColor = Color.OrangeRed
            frmm1.ShowDialog()
            Exit Sub
        End If


        Dim CmdSave As New SqlCommand
        CmdSave.CommandType = CommandType.StoredProcedure
        CmdSave.CommandText = "InsertUpdateFinancial"
        CmdSave.Connection = cn
        CmdSave.Parameters.Add("@PID", SqlDbType.NVarChar)
        CmdSave.Parameters("@PID").Value = Me.TxtID.Text
        CmdSave.Parameters.Add("@FromDate", SqlDbType.SmallDateTime)
        CmdSave.Parameters("@FromDate").Value = Me.DtFrom.Value.Date
        CmdSave.Parameters.Add("@ToDate", SqlDbType.SmallDateTime)
        CmdSave.Parameters("@ToDate").Value = Me.DtTo.Value.Date
        CmdSave.Parameters.Add("@AccStatus", SqlDbType.Bit)
        If ChkIsCurrent.Checked = True Then
            CmdSave.Parameters("@AccStatus").Value = 1
        Else
            CmdSave.Parameters("@AccStatus").Value = 0
        End If
        CmdSave.Parameters.Add("@CompanyID", SqlDbType.BigInt)
        CmdSave.Parameters("@CompanyID").Value = Me.TxtCompanyID.Text

        CmdSave.Parameters.Add("@UserID", SqlDbType.BigInt)
        CmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text

        CmdSave.Parameters.Add("@WName", SqlDbType.NVarChar)
        CmdSave.Parameters("@WName").Value = Frm.WName.Text

        CmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
        CmdSave.Parameters("@Flag").Value = EditValue
        CmdSave.ExecuteNonQuery()
        cmd.Parameters.Clear()

        Call StatusMnu()


        If EditValue = 1 Then
            Module1.InsertRecord("Company", Me.TxtCompanyID.Text & ",N'" & Me.TxtName.Text & "',N'" & Me.TxtRemarks.Text & "'")

            Dim frmm As New FrmBox("Your Record has been saved successfully..")
            frmm.ShowDialog()
        Else

            Module1.InsertRecord("Company", "Remarks=N'" & Me.TxtRemarks.Text & "' CompanyID=" & Me.TxtCompanyID.Text)

            Dim frmm As New FrmBox("Your Record has been Updated successfully..")
            frmm.ShowDialog()
        End If
        Module1.DatasetFill("Select * from Company", "Company")
    End Sub
    Sub txtfill()
        Me.TxtCompanyID.Text = ds.Tables("Company").Rows(cnt).Item(0)
        Me.TxtName.Text = ds.Tables("Company").Rows(cnt).Item(1)
        Me.TxtRemarks.Text = IIf(IsDBNull(ds.Tables("Company").Rows(cnt).Item(2)) = True, " ", (ds.Tables("Company").Rows(cnt).Item(2)))
        Module1.DatasetFill("Select * from FinancialPeriod where CompanyID=" & Me.TxtCompanyID.Text, "FinancialPeriod")
        Try
            Me.TxtID.Text = ds.Tables("FinancialPeriod").Rows(0).Item(0)
            Me.DtFrom.Value = ds.Tables("FinancialPeriod").Rows(0).Item(1)
            Me.DtTo.Value = ds.Tables("FinancialPeriod").Rows(0).Item(2)
            If ds.Tables("FinancialPeriod").Rows(0).Item(3) = 1 Then
                ChkIsCurrent.Checked = True
            Else
                ChkIsCurrent.Checked = False
            End If
        Catch ex As Exception

        End Try

    End Sub




    Private Sub ToolStripMenuItemUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemUndo.Click
        Call Me.StatusMnu()
    End Sub

    Private Sub ToolStripMenuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuEdit.Click
        EditValue = 0
        ChkIsCurrent.Enabled = False
        ChkIsCurrent.Checked = True
        Call Me.StatusMnu()

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("Company").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call txtfill()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("Company").Rows.Count - 1
        Call txtfill()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call txtfill()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        Call txtfill()
    End Sub

    Private Sub DtFrom_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtFrom.GotFocus
        Me.TxtID.Text = TxtName.Text & "-" & DtFrom.Value.Year & "-" & DtTo.Value.Year
    End Sub

    Private Sub DtTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtTo.GotFocus
        Me.TxtID.Text = TxtName.Text & "-" & DtFrom.Value.Year & "-" & DtTo.Value.Year
    End Sub


    Private Sub DtTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtTo.ValueChanged
        Me.TxtID.Text = TxtName.Text & "-" & DtFrom.Value.Year & "-" & DtTo.Value.Year
    End Sub

    Private Sub DtFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFrom.ValueChanged
        Me.TxtID.Text = TxtName.Text & "-" & DtFrom.Value.Year & "-" & DtTo.Value.Year
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
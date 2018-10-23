Imports System.Data.SqlClient
Public Class FinancialPeriod
    Dim EditValue As Integer = 0
    Private Sub FinancialPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MaximizeBox = False

        ''Me.Left = 0
        ''Me.Top = 0
        ' Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        ''Me.Height = Frm.Height - 70
        ''Me.Width = Frm.Width - 4
        Me.GroupBox1.Left = Me.Width / 2 - (Me.GroupBox1.Width / 2)
        Me.GroupBox1.Top = Me.Height / 2 - (Me.GroupBox1.Height / 2)
        Module1.DatasetFill("Select * from FinancialPeriod where CompanyID=" & Frm.LBCompanyID.Text, "FinancialPeriod")
        Call GridFill()
    End Sub
    Sub GridFill()
        DG.Rows.Clear()
        Dim a As Integer
        For a = 0 To ds.Tables("FinancialPeriod").Rows.Count - 1
            DG.Rows.Add()
            DG.Rows(a).Cells(0).Value = ds.Tables("FinancialPeriod").Rows(a).Item(0)
            DG.Rows(a).Cells(1).Value = ds.Tables("FinancialPeriod").Rows(a).Item(1)
            DG.Rows(a).Cells(2).Value = ds.Tables("FinancialPeriod").Rows(a).Item(2)
            DG.Rows(a).Cells(3).Value = ds.Tables("FinancialPeriod").Rows(a).Item(3)

        Next


    End Sub


    Public Sub add()

        Call StatusMnu()
        Call CClear()
        'Cmd = New SqlCommand("select isnull(max(Fid),0) from FinancialPeriod", GetCon)
        Me.TxtID.Text = GetNewVNO("FinancialPeriod", "Pid", Me.DtFrom.Value, "FromDate")
        'Me.Dg.Rows.Clear()
        ' editflag = False
        EditValue = 1
        'EnableAll()
        DtFrom.Value = Now
        DtTo.Value = Now
        DtFrom.Enabled = True
        DtTo.Enabled = True
        ChkIsCurrent.Enabled = True
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

    End Sub

    Private Sub CClear()

        Me.TxtID.Text = ""
        Me.DtFrom.Value = Now
        Me.DtTo.Value = Now


    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        add()
    End Sub

    Private Sub ToolStripMenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuSave.Click

        Dim CmdSave As New SqlCommand
        CmdSave.CommandType = CommandType.StoredProcedure
        CmdSave.CommandText = "InsertUpdateFinancial"
        CmdSave.Connection = cn
        CmdSave.Parameters.Add("@PID", SqlDbType.VarChar)
        CmdSave.Parameters("@PID").Value = Me.TxtID.Text
        CmdSave.Parameters.Add("@FromDate", SqlDbType.DateTime)
        CmdSave.Parameters("@FromDate").Value = Me.DtFrom.Value
        CmdSave.Parameters.Add("@ToDate", SqlDbType.DateTime)
        CmdSave.Parameters("@ToDate").Value = Me.DtTo.Value
        CmdSave.Parameters.Add("@AccStatus", SqlDbType.Bit)
        If ChkIsCurrent.Checked = True Then
            CmdSave.Parameters("@AccStatus").Value = 1
        Else
            CmdSave.Parameters("@AccStatus").Value = 0
        End If
        CmdSave.Parameters.Add("@CompanyID", SqlDbType.BigInt)
        CmdSave.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text

        CmdSave.Parameters.Add("@UserID", SqlDbType.BigInt)
        CmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text

        CmdSave.Parameters.Add("@WName", SqlDbType.VarChar)
        CmdSave.Parameters("@WName").Value = Frm.WName.Text

        CmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
        CmdSave.Parameters("@Flag").Value = EditValue
        CmdSave.ExecuteNonQuery()
        cmd.Parameters.Clear()

        Call StatusMnu()
        Module1.DatasetFill("Select * from FinancialPeriod where CompanyID=" & Frm.LBCompanyID.Text, "FinancialPeriod")
        Call GridFill()
        If EditValue = 1 Then
            Dim frmm As New FrmBox("Your Record has been saved successfully..")
            frmm.ShowDialog()
        Else
            Dim frmm As New FrmBox("Your Record has been Updated successfully..")
            frmm.ShowDialog()
        End If

    End Sub



    Private Sub DG_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellDoubleClick
        Me.TxtID.Text = DG.CurrentRow.Cells(0).Value
        Me.DtFrom.Value = DG.CurrentRow.Cells(1).Value
        Me.DtTo.Value = DG.CurrentRow.Cells(2).Value
        Me.ChkIsCurrent.Checked = DG.CurrentRow.Cells(3).Value
    End Sub

    Private Sub ToolStripMenuItemUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemUndo.Click
        Call Me.StatusMnu()
    End Sub

    Private Sub ToolStripMenuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuEdit.Click
        EditValue = 0
        Call Me.StatusMnu()

    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
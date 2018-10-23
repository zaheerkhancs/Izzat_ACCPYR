Imports System.Data.SqlClient
Public Class FrmSubCategory
    Dim First As String
    Dim Second As String
    Dim editValue As Integer
    Private Sub FrmSubCategory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MaximizeBox = False
        ''Me.Left = 0
        ''Me.Top = 0
        'Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
        'Me.Height = Screen.PrimaryScreen.Bounds.Height - 4
        ''Me.Height = Frm.Height - 70
        ''Me.Width = Frm.Width - 4
        Me.GroupBox1.Left = Me.Width / 2 - (Me.GroupBox1.Width / 2)
        Me.GroupBox1.Top = Me.Height / 2 - (Me.GroupBox1.Height / 2)
        Module1.DatasetFill("Select * from AccountType", "AccountType")
        CmbAccCategory.DataSource = ds.Tables("AccountType")
        CmbAccCategory.ValueMember = "AccID"
        CmbAccCategory.DisplayMember = "AccName"
        Call GridFill()
        'CmbAccCategory.SelectedIndex = -1
        'CmbAccCategory.Text = "Select Option"
        Frm.Show()
    End Sub


    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Sub GridFill()
        Dim a As Integer
        DG.Rows.Clear()
        Module1.DatasetFill("Select * from VuCatagory order by AccName", "VuCatagory1")
        For a = 0 To ds.Tables("VuCatagory1").Rows.Count - 1
            DG.Rows.Add()
            DG.Rows(a).Cells(0).Value = ds.Tables("VuCatagory1").Rows(a).Item(0)
            DG.Rows(a).Cells(1).Value = ds.Tables("VuCatagory1").Rows(a).Item(1)
            DG.Rows(a).Cells(2).Value = ds.Tables("VuCatagory1").Rows(a).Item(2)
            DG.Rows(a).Cells(3).Value = ds.Tables("VuCatagory1").Rows(a).Item(3)
            DG.Rows(a).Cells(4).Value = ds.Tables("VuCatagory1").Rows(a).Item(4)

        Next
    End Sub

    Private Sub CmbAccCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAccCategory.SelectedIndexChanged
        Try


            First = Val(CmbAccCategory.SelectedValue)
            If First.Length = 1 Then
                First = "0" & First
            Else
                First = First
            End If
            Second = Module1.GetMaxStr1("CatID", "AccountCategory", " AccID=" & Val(CmbAccCategory.SelectedValue)).ToString
            Select Case Second.Length
                Case "1"
                    Second = "0" & Second
                Case "2"
                    Second = Second
            End Select


            TxtHeadCode.Text = First & "" & Second
        Catch ex As Exception

        End Try
    End Sub
    Private Sub StatusMnu()
        Me.ToolStripMenuEdit.Enabled = Not Me.ToolStripMenuEdit.Enabled
        Me.NewToolStripMenuItem.Enabled = Not Me.NewToolStripMenuItem.Enabled
        Me.ToolStripMenuItemUndo.Enabled = Not Me.ToolStripMenuItemUndo.Enabled
        Me.ToolStripMenuSave.Enabled = Not Me.ToolStripMenuSave.Enabled

        CmbAccCategory.Enabled = Not CmbAccCategory.Enabled
        'TxtHeadCode.ReadOnly = Not TxtHeadCode.ReadOnly
        Me.TxtName.ReadOnly = Not Me.TxtName.ReadOnly

    End Sub

    Private Sub CClear()
        Me.CmbAccCategory.SelectedIndex = -1
        Me.TxtHeadCode.Text = "00000000"
        Me.TxtName.Text = ""
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Call CClear()
        StatusMnu()
        editValue = 1

    End Sub


    Private Sub ToolStripMenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuSave.Click

        Dim CmdSave As New SqlCommand
        CmdSave.CommandType = CommandType.StoredProcedure
        CmdSave.CommandText = "InsertUpdateCatagory"
        CmdSave.Connection = cn

        '@CatID, @CatTitle, @AccID, @UserID, @CompanyID, @WName

        CmdSave.Parameters.Add("@CatID", SqlDbType.Char)
        CmdSave.Parameters("@CatID").Value = Me.TxtHeadCode.Text
        CmdSave.Parameters.Add("@CatTitle", SqlDbType.NVarChar)
        CmdSave.Parameters("@CatTitle").Value = Me.TxtName.Text
        CmdSave.Parameters.Add("@AccID", SqlDbType.Int)
        CmdSave.Parameters("@AccID").Value = CmbAccCategory.SelectedValue
        
        CmdSave.Parameters.Add("@CompanyID", SqlDbType.BigInt)
        CmdSave.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text

        CmdSave.Parameters.Add("@UserID", SqlDbType.BigInt)
        CmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text

        CmdSave.Parameters.Add("@WName", SqlDbType.NVarChar)
        CmdSave.Parameters("@WName").Value = Frm.WName.Text

        CmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
        CmdSave.Parameters("@Flag").Value = editValue
        CmdSave.Parameters.Add("@OrderTrial", SqlDbType.Int)
        CmdSave.Parameters("@OrderTrial").Value = Val(Me.TextBox1.Text)
        CmdSave.ExecuteNonQuery()
        cmd.Parameters.Clear()

        Call StatusMnu()

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
        Try

        
            Me.TxtHeadCode.Text = DG.CurrentRow.Cells(0).Value
            Me.TxtName.Text = DG.CurrentRow.Cells(1).Value
            Me.CmbAccCategory.SelectedValue = DG.CurrentRow.Cells(3).Value
            Me.TextBox1.Text = Val(DG.CurrentRow.Cells(4).Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellContentClick

    End Sub

    Private Sub ToolStripMenuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuEdit.Click
        Call StatusMnu()
        editValue = 0
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItemUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemUndo.Click
        StatusMnu()
    End Sub
End Class
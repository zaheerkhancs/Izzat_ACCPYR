Public Class FrmSubSidiary
    Dim cnt As Integer
    Dim EditFlag As Boolean
    Private Sub FrmSubSidiary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MaximizeBox = False
        Try
            Dim sts As Boolean
            sts = Module1.GetValue("AccStatus", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")
            ''Me.Left = 0
            ''Me.Top = 0
            ' Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
            'Me.Height = Screen.PrimaryScreen.Bounds.Height - 4

            ''Me.Height = Frm.Height - 70
            ''Me.Width = Frm.Width - 4
            Panel1.Left = Me.Width / 2 - (Panel1.Width / 2)
            Panel1.Top = Me.Height / 2 - (Panel1.Height / 2)
            Call Clear()

            Module1.DatasetFill("Select * from VuPermission Where GroupID=" & Frm.GID.Text & " and PerName=N'Subsidiary Account'", "VuPermission")
            If ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
                Me.Close()
                MsgBox("You have no right to view this Form . For further detail contact your administrator", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Alert")
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





            Module1.DatasetFill("Select * from ChartofAccount", "ChartofAcc")
            CmbSubAccCategory.DataSource = ds.Tables("ChartofAcc")
            CmbSubAccCategory.DisplayMember = "HeadName"
            CmbSubAccCategory.ValueMember = "HeadID"
            Module1.DatasetFill("Select * from VuSubsidiary where CompanyID=" & Frm.LBCompanyID.Text, "Subsidiary")
            Call TxtFill()
        Catch ex As Exception


        End Try

    End Sub

    Sub TxtFill()
        Try
            Me.TxtID.Text = ds.Tables("Subsidiary").Rows(cnt).Item(0)
            Me.TxtName.Text = ds.Tables("Subsidiary").Rows(cnt).Item(1)
            Me.CmbSubAccCategory.SelectedValue = ds.Tables("Subsidiary").Rows(cnt).Item(2)
            DTDate.Value = ds.Tables("Subsidiary").Rows(cnt).Item(3)
            Me.TxtRemarks.Text = ds.Tables("Subsidiary").Rows(cnt).Item(4)
            Me.TxtMobile.Text = (IIf(ds.Tables("Subsidiary").Rows(cnt).Item("Mobile").ToString = "", " ", ds.Tables("Subsidiary").Rows(cnt).Item("Mobile")))
            Me.txtPhone.Text = (IIf(ds.Tables("Subsidiary").Rows(cnt).Item("Phone").ToString = "", "", ds.Tables("Subsidiary").Rows(cnt).Item("Phone")))
            Me.txtAddress.Text = (IIf(ds.Tables("Subsidiary").Rows(cnt).Item("Address").ToString = "", "", ds.Tables("Subsidiary").Rows(cnt).Item("Address")))
            Me.TxtEmail.Text = (IIf(ds.Tables("Subsidiary").Rows(cnt).Item("Email").ToString = "", "", ds.Tables("Subsidiary").Rows(cnt).Item("Email")))
            Me.TxtFaxNo.Text = (IIf(ds.Tables("Subsidiary").Rows(cnt).Item("Fax").ToString = "", "", ds.Tables("Subsidiary").Rows(cnt).Item("Fax")))

            If Me.txtAddress.Text = "" And Me.txtPhone.Text = "" And Me.TxtEmail.Text = "" And Me.TxtMobile.Text = "" Then
                Me.CheckBox1.Checked = False
                Me.GroupBox1.Visible = False
            Else
                Me.CheckBox1.Checked = True
                Me.GroupBox1.Visible = True
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub StatusMnu()
        Me.ToolStripMenuEdit.Enabled = Not Me.ToolStripMenuEdit.Enabled
        Me.NewToolStripMenuItem.Enabled = Not Me.NewToolStripMenuItem.Enabled
        Me.ToolStripMenuItemUndo.Enabled = Not Me.ToolStripMenuItemUndo.Enabled
        Me.ToolStripMenuSave.Enabled = Not Me.ToolStripMenuSave.Enabled


        CmbSubAccCategory.Enabled = Not CmbSubAccCategory.Enabled
        TxtName.ReadOnly = Not TxtName.ReadOnly
        TxtRemarks.ReadOnly = Not TxtRemarks.ReadOnly
        DTDate.Enabled = Not DTDate.Enabled
        GroupBox1.Enabled = Not GroupBox1.Enabled
        CheckBox1.Enabled = Not CheckBox1.Enabled

    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        GroupBox1.Visible = CheckBox1.Checked
    End Sub
    Sub Clear()
        CmbSubAccCategory.SelectedIndex = -1
        TxtName.Text = ""
        TxtRemarks.Text = ""
        DTDate.Value = Now
        CheckBox1.Checked = False
        Me.TxtMobile.Text = ""
        Me.TxtFaxNo.Text = ""
        Me.txtAddress.Text = ""
        Me.TxtEmail.Text = ""
        Me.TxtFaxNo.Text = ""


    End Sub
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        StatusMnu()
        Call Clear()
        Me.TxtID.Text = Module1.GetMax("SubId", "Subsidiary")
        EditFlag = True
    End Sub
    Private Sub Save()
        Try
            If Me.TxtName.Text = "" Then
                MsgBox("Please Enter the Subsidiary Name.")
                Exit Sub
            End If
            '  trans = cn.BeginTransaction
            If EditFlag = True Then

                cmd.Connection = cn
                cmd.CommandText = "INSERT INTO Subsidiary VALUES(" & Me.TxtID.Text & ",N'" & Me.TxtName.Text & "',N'" & Me.CmbSubAccCategory.SelectedValue & "','" & Me.DTDate.Value & "',N'" & Me.TxtRemarks.Text & "'," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",N'" & Frm.WName.Text & "')"
                '    cmd.Transaction = Trans
                cmd.ExecuteNonQuery()
                If Me.CheckBox1.Checked = True Then
                    cmd.Connection = cn
                    cmd.CommandText = "INSERT INTO SubsidiaryPersonal VALUES(" & Me.TxtID.Text & ",N'" & Me.txtAddress.Text & "',N'" & Me.txtPhone.Text & "',N'" & Me.TxtEmail.Text & "',N'" & Me.TxtMobile.Text & "',N'" & Me.TxtFaxNo.Text & "')"
                    '         cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()
                    'Trans.Commit()

                End If
                Dim frmm As New FrmBox("Your Record has been saved successfully..")
                frmm.ShowDialog()

            Else
                cmd.Connection = cn
                cmd.CommandText = "UPDATE Subsidiary SET SubName =N'" & Me.TxtName.Text & "',HEADID='" & Me.CmbSubAccCategory.SelectedValue & "',REMARKS=N'" & Me.TxtRemarks.Text & "',date='" & Me.DTDate.Value & "',UserID=" & Frm.LbUserID.Text & ",WName=N'" & Frm.WName.Text & "' WHERE SUBID=" & Me.TxtID.Text
                ' cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                cmd.Connection = cn
                cmd.CommandText = "Delete from SubsidiaryPersonal where SubID=" & Me.TxtID.Text
                '         cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                cmd.Connection = cn
                cmd.CommandText = "INSERT INTO SubsidiaryPersonal VALUES(" & Me.TxtID.Text & ",N'" & Me.txtAddress.Text & "',N'" & Me.txtPhone.Text & "',N'" & Me.TxtEmail.Text & "',N'" & Me.TxtMobile.Text & "',N'" & Me.TxtFaxNo.Text & "')"
                '         cmd.Transaction = Trans
                cmd.ExecuteNonQuery()
                '   Trans.Commit()
                Dim frmm As New FrmBox("Your Record has been Updated successfully..")
                frmm.ShowDialog()

            End If


            Call StatusMnu()
            Me.GroupBox1.Enabled = Not Me.GroupBox1.Enabled
            ' ds.Tables.Clear()
            Module1.DatasetFill("Select * from VuSubsidiary where CompanyID=" & Frm.LBCompanyID.Text, "Subsidiary")
            Call TxtFill()

        Catch ex As Exception
            'trans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuSave.Click
        Call Save()
    End Sub


    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Try


            cnt = ds.Tables("Subsidiary").Rows.Count - 1
            Call TxtFill()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try


            If cnt = ds.Tables("Subsidiary").Rows.Count - 1 Then
                MsgBox("You are on the last record...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            cnt = cnt + 1
            Call TxtFill()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuEdit.Click
        EditFlag = False
        StatusMnu()
    End Sub

    Private Sub ToolStripMenuItemUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemUndo.Click
        StatusMnu()
        Call TxtFill()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
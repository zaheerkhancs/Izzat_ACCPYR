Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmVendorSetup
    Dim EditValue As Integer
    Dim cnt As Integer
    Dim StrSearch As String
    Dim z As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim id As Integer
    Dim trans As SqlTransaction
    Private Sub frmVendorSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Module1.DatasetFill("Select * from Vendor", "Vendor")
        cmbVendorName.DataSource = ds.Tables("Vendor")
        cmbVendorName.DisplayMember = ("Name")
        cmbVendorName.ValueMember = ("VID")
        dtDate.Value = Now
        EditValue = 0

        Call Fill()

        'If Frm.GID.Text <= 2 Then
        '    CM.Enabled = True
        'Else
        '    CM.Enabled = False
        'End If
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub


#Region "MAIN.............."

#Region "FUNCTIONS"
    Sub Status()
        dtDate.Enabled = Not dtDate.Enabled
        txtName.ReadOnly = Not txtName.ReadOnly
        txtConcernPName.ReadOnly = Not txtConcernPName.ReadOnly
        txtJobTitle.ReadOnly = Not txtJobTitle.ReadOnly
        txtContact.ReadOnly = Not txtContact.ReadOnly
        txtFax.ReadOnly = Not txtFax.ReadOnly
        txtEmail.ReadOnly = Not txtEmail.ReadOnly
        txtAddress1.ReadOnly = Not txtAddress1.ReadOnly
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        dtDate.Value = Now
        txtName.Text = ""
        txtJobTitle.Text = ""
        txtConcernPName.Text = ""
        txtContact.Text = ""
        txtFax.Text = ""
        txtEmail.Text = ""
        txtAddress1.Text = ""
        
    End Sub
    Sub CMStatus()
        TSAdd.Enabled = Not TSAdd.Enabled
        TSSave.Enabled = Not TSSave.Enabled
        TSUndo.Enabled = Not TSUndo.Enabled
        TSUpdate.Enabled = Not TSUpdate.Enabled
        TSDelete.Enabled = Not TSDelete.Enabled
        TSClose.Enabled = Not TSClose.Enabled
    End Sub
    Sub IDPICKER()
        cmd.CommandText = "Select isnull(Max(VID),0) from Vendor"
        id = cmd.ExecuteScalar + 1

        cmd.CommandText = "Select isnull(Max(SubID),0) from Subsidiary"
        If id < (cmd.ExecuteScalar + 1) Then
            Me.txtID.Text = cmd.ExecuteScalar + 1
        Else
            Me.txtID.Text = id
        End If
    End Sub
    Sub Fill()
        Try
            EditValue = 0
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from VuVendor", "VuVendor")
            txtID.Text = ds.Tables("VuVendor").Rows(cnt).Item("VID")
            dtDate.Value = ds.Tables("VuVendor").Rows(cnt).Item("dtDate")
            txtName.Text = ds.Tables("VuVendor").Rows(cnt).Item("Name")
            txtConcernPName.Text = ds.Tables("VuVendor").Rows(cnt).Item("ConcernPName")
            txtJobTitle.Text = ds.Tables("VuVendor").Rows(cnt).Item("JobTitle")
            txtContact.Text = ds.Tables("VuVendor").Rows(cnt).Item("Contact")
            txtFax.Text = ds.Tables("VuVendor").Rows(cnt).Item("Fax")
            txtEmail.Text = ds.Tables("VuVendor").Rows(cnt).Item("Email")
            txtAddress1.Text = ds.Tables("VuVendor").Rows(cnt).Item("Address1")
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveUpdateVendor()
        Dim headid As String
        cmd.CommandText = "Select vendorSuccode from Impheads"
        headid = cmd.ExecuteScalar

        If EditValue = 0 Then
            IDPICKER()
        End If

        trans = cn.BeginTransaction
        Dim cmdsave As New SqlCommand
        cmdsave.Transaction = trans
        Try
            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateVendor"
            cmdsave.Connection = cn

            cmdsave.Parameters.Add("@VID", SqlDbType.Int).Value = Me.txtID.Text
            cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmdsave.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Me.txtName.Text
            cmdsave.Parameters.Add("@ConcernPName", SqlDbType.NVarChar).Value = Me.txtConcernPName.Text
            cmdsave.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = Me.txtJobTitle.Text
            cmdsave.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = Me.txtContact.Text
            cmdsave.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Me.txtFax.Text
            cmdsave.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtEmail.Text
            cmdsave.Parameters.Add("@Address1", SqlDbType.NVarChar).Value = Me.txtAddress1.Text
            cmdsave.Parameters.Add("CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & txtID.Text
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()
            

            If EditValue = 0 Then
                Call CMStatus()
                Call Status()

                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.CommandText = "INSERT INTO Subsidiary VALUES(" & Me.txtID.Text & ",N'" & Me.txtName.Text & "',N'" & headid & "','" & Me.dtDate.Value & "',N' From HRM '," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",N'" & Frm.WName.Text & "')"
                cmd.ExecuteNonQuery()
                trans.Commit()

                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
            Else
                Call CMStatus()
                Call Status()

                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Connection = cn
                cmd.CommandText = "UPDATE Subsidiary SET SubName =N'" & Me.txtName.Text & "',HEADID='" & headid & "',REMARKS=N' From HRM ',date='" & Me.dtDate.Value & "',UserID=" & Frm.LbUserID.Text & ",WName=N'" & Frm.WName.Text & "' WHERE SUBID=" & Me.txtID.Text
                cmd.ExecuteNonQuery()
                trans.Commit()

                Call Fill()
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                EditValue = 0
            End If

        Catch ex As Exception
            trans.Rollback()
        End Try
    End Sub
#End Region

#Region "CONTEXT MENUS"
    Private Sub TSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSAdd.Click
        Call Status()
        Call CMStatus()
        Call Clear()
    End Sub
    Private Sub TSSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSave.Click
        Call SaveUpdateVendor()
    End Sub
    Private Sub TSUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUndo.Click
        Call CMStatus()
        Call Status()
        Clear()
        Call Fill()
    End Sub
    Private Sub TSUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUpdate.Click
        EditValue = 1
        Call Status()
        Call CMStatus()
    End Sub
    Private Sub TSDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSDelete.Click
        Dim a As VariantType
        a = MsgBox("Are You Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from Vendor where VID = " & Me.txtID.Text
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from Subsidiary where SubID = " & Me.txtID.Text
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuVendor").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Call Clear()
            End If
            Call Fill()
            lblMessage.Text = "ریکارد مذکور موفقانه فسخ شد "
        End If
    End Sub
    Private Sub TSClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSClose.Click
        Me.Close()
    End Sub
#End Region

#Region "NAVIGATIONS"
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        Call Fill()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call Fill()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuVendor").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call Fill()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuVendor").Rows.Count - 1
        Call Fill()
    End Sub
#End Region

#Region "EVENTS"
    Private Sub txtContact_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContact.KeyPress
        If e.KeyChar = Chr(32) Then
            e.Handled = True
        End If
        Dim Mes As Integer
        Mes = Asc(e.KeyChar)
        If (Mes > 47 And Mes < 58) Or e.KeyChar = Chr(32) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(45) Or e.KeyChar = Chr(40) Or e.KeyChar = Chr(41) Then

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtFax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
        If e.KeyChar = Chr(32) Then
            e.Handled = True
        End If
        Dim Mes As Integer
        Mes = Asc(e.KeyChar)
        If (Mes > 47 And Mes < 58) Or e.KeyChar = Chr(32) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(45) Or e.KeyChar = Chr(40) Or e.KeyChar = Chr(41) Then

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtConcernPName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcernPName.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
        If txtConcernPName.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar < Chr(47) Or e.KeyChar > Chr(58)) Or e.KeyChar = Chr(32) Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
        If txtName.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
        If txtEmail.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
        If txtAddress1.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region

#End Region


#Region "SEARCH..................."
    Sub GridFill()
        Try
            DGSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = StrSearch
            If (ds.Tables.Contains("VuVendor")) Then
                ds.Tables("VuVendor").Clear()
                DGSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuVendor")

            For z = 0 To ds.Tables("VuVendor").Rows.Count - 1
                Try
                    DGSearch.Rows.Add()
                    DGSearch.Rows(z).Cells("VSNo").Value = (z + 1).ToString()
                    DGSearch.Rows(z).Cells("VName").Value = ds.Tables("VuVendor").Rows(z).Item("Name")
                    DGSearch.Rows(z).Cells("VCName").Value = ds.Tables("VuVendor").Rows(z).Item("ConcernPName")
                    DGSearch.Rows(z).Cells("VJob").Value = ds.Tables("VuVendor").Rows(z).Item("JobTitle")
                    DGSearch.Rows(z).Cells("VTel").Value = ds.Tables("VuVendor").Rows(z).Item("Contact")
                    DGSearch.Rows(z).Cells("VFax").Value = ds.Tables("VuVendor").Rows(z).Item("Fax")
                    DGSearch.Rows(z).Cells("Vmail").Value = ds.Tables("VuVendor").Rows(z).Item("Email")
                    DGSearch.Rows(z).Cells("VAddress").Value = ds.Tables("VuVendor").Rows(z).Item("Address1")
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        DGSearch.Rows.Clear()
        If chbSingle.Checked.Equals(False) Then
            StrSearch = "Select Name,ConcernPName,JobTitle,Contact,Fax,Email,Address1 from VuVendor"
            Call GridFill()
        Else
            If cmbVendorName.Text = "" Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                StrSearch = "Select Name,ConcernPName,JobTitle,Contact,Fax,Email,Address1 from VuVendor where VID=" & cmbVendorName.SelectedValue & ""
                Call GridFill()
            End If
        End If
    End Sub
#End Region

    
    Private Sub TC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TC.SelectedIndexChanged
        If Frm.GID.Text <= 2 Then
            If TC.SelectedIndex = 0 Then
                CM.Enabled = True
                ToolStrip1.Enabled = True
                If TSAdd.Enabled <> True Then
                    Call CMStatus()
                    Call Status()
                End If
                Call Clear()
                Call Fill()
                chbSingle.Checked = False
                cmbVendorName.Enabled = False
            Else
                DGSearch.Rows.Clear()
                Module1.DatasetFill("Select * from Vendor", "Vendor")
                cmbVendorName.DataSource = ds.Tables("Vendor")
                cmbVendorName.DisplayMember = ("Name")
                cmbVendorName.ValueMember = ("VID")
                cmbVendorName.SelectedIndex = -1
                CM.Enabled = False
                ToolStrip1.Enabled = False
                chbSingle.Checked = False
                cmbVendorName.Enabled = False
            End If
        End If
    End Sub
    
    Private Sub txtJobTitle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJobTitle.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub chbSingle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSingle.CheckedChanged
        If chbSingle.Checked.Equals(True) Then
            cmbVendorName.Enabled = True
        Else
            cmbVendorName.Enabled = False
        End If
    End Sub

End Class
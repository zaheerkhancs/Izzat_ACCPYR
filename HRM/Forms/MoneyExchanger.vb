Imports System.Data.SqlClient
Imports LanguageSelector
Public Class MoneyExchanger
    Dim EditValue As Integer
    Dim Var_MoneyExchangerID As Integer
    Dim CityID As Integer
    Dim CItyBasedID As String
    Dim cnt As Integer
    Dim NewRecordIsSaved As Boolean
    Dim StrSearch As String
    Dim z As Integer
    Private Sub MoneyExchanger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CItyBasedID = Frm.lbLocationName.Text
        Module1.DatasetFill("Select * from MoneyExchanger", "MoneyExchanger")
        cmbSarafName.DataSource = ds.Tables("MoneyExchanger")
        cmbSarafName.DisplayMember = ("MoneyExchangerName")
        cmbSarafName.ValueMember = ("MoneyExchangerID")
        cmbSarafName.SelectedIndex = -1

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


    Sub Clear()
        txtMExName.Text = ""
        txtAddress.Text = ""
        txtConcernName.Text = ""
        txtphone.Text = ""
        txtFax.Text = ""
        txtCell.Text = ""

    End Sub
    Sub CStatus()
        dtDate.Enabled = Not dtDate.Enabled
        txtMExName.Enabled = Not txtphone.Enabled
        txtAddress.Enabled = Not txtAddress.Enabled
        txtConcernName.Enabled = Not txtConcernName.Enabled
        txtphone.Enabled = Not txtphone.Enabled
        txtFax.Enabled = Not txtFax.Enabled
        txtCell.Enabled = Not txtCell.Enabled

    End Sub

    Sub CMStatus()
        TSAdd.Enabled = Not TSAdd.Enabled
        TSSave.Enabled = Not TSSave.Enabled
        TSUndo.Enabled = Not TSUndo.Enabled
        TSUpdate.Enabled = Not TSUpdate.Enabled
        TSDelete.Enabled = Not TSDelete.Enabled
        TSClose.Enabled = Not TSClose.Enabled
    End Sub
    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(MoneyExchangerID) from MoneyExchanger"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_MoneyExchangerID = 1
                Else
                    Me.Var_MoneyExchangerID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Fill()
        Try
            EditValue = 0
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from MoneyExchanger", "MoneyExchanger")

            If ds.Tables("MoneyExchanger").Rows.Count = 0 Then Exit Sub
            If NewRecordIsSaved.Equals(True) Then
                cnt = ds.Tables("MoneyExchanger").Rows.Count - 1
            End If

            Var_MoneyExchangerID = ds.Tables("MoneyExchanger").Rows(cnt).Item("MoneyExchangerID")
            txtMExName.Text = ds.Tables("MoneyExchanger").Rows(cnt).Item("MoneyExchangerName")
            txtConcernName.Text = ds.Tables("MoneyExchanger").Rows(cnt).Item("ConcernPName")
            txtphone.Text = ds.Tables("MoneyExchanger").Rows(cnt).Item("Phone")
            txtCell.Text = ds.Tables("MoneyExchanger").Rows(cnt).Item("CellNo")
            txtAddress.Text = ds.Tables("MoneyExchanger").Rows(cnt).Item("Address")
            txtFax.Text = ds.Tables("MoneyExchanger").Rows(cnt).Item("Fax")
            dtDate.Value = ds.Tables("MoneyExchanger").Rows(cnt).Item("SinceDate")

        Catch ex As Exception
        End Try
    End Sub

    Private Sub bbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbtnAdd.Click
        Clear()
        CStatus()
        EditValue = 1
    End Sub

    Private Sub bbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbtnSave.Click
        SaveUpdateMoneyExchanger()
    End Sub
    Sub SaveUpdateMoneyExchanger()
        Try
            ' If edit value is 0 because All HRM is inverse, on editvalue 0 it saves and on editvalue 1 is updates.
            If EditValue = 1 Then
                IDPicker()
            End If

            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateMoneyExchanger"
            cmdsave.Connection = cn

            cmdsave.Parameters.Add("@MoneyExchangerID", SqlDbType.Int).Value = Me.Var_MoneyExchangerID
            cmdsave.Parameters.Add("@MoneyExchangerName", SqlDbType.NVarChar).Value = Me.txtMExName.Text
            cmdsave.Parameters.Add("@ConcernPName", SqlDbType.NVarChar).Value = Me.txtConcernName.Text
            cmdsave.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Me.txtphone.Text
            cmdsave.Parameters.Add("@CellNo", SqlDbType.NVarChar).Value = Me.txtCell.Text
            cmdsave.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Me.txtAddress.Text
            cmdsave.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Me.txtFax.Text
            cmdsave.Parameters.Add("@SinceDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CItyBasedID & "-" & Var_MoneyExchangerID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If EditValue = 1 Then
                Call CMStatus()
                Call CStatus()
                'Call Clear()
                NewRecordIsSaved = True
                Call Fill()
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
            Else
                Call CMStatus()
                Call CStatus()
                'Call Clear()
                NewRecordIsSaved = False
                Call Fill()
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                EditValue = 0
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub bbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbtnEdit.Click
        EditValue = 0
        CStatus()

    End Sub

    Private Sub bbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbtnExit.Click
        Me.Close()
    End Sub

    Private Sub bbtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbtnDelete.Click
        'If Not Me.Var_MoneyExchangerID = " " Then

        If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

            Module1.DeleteRecord("MoneyExchanger", "MoneyExchangerID = " & Var_MoneyExchangerID)

            'SetupListForAll.GridFill3("Select * from VuProduct order by ProdCode", "VuProduct", RelationForeignKey, FieldToBeDisplayed)
            cnt = ds.Tables("MoneyExchanger").Rows.Count
            If cnt = 0 Then
                Clear()
                Exit Sub
            End If

            'cnt = cnt - 1
            'NewRecordIsSaved = False
            '  Call TxtFillAfterDeletion()
            'OpenGrid()

            Fill()
        End If
        'End If
        'Module1.Opencn()
        'Navigating = False
    End Sub

    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        NewRecordIsSaved = False
        Call Fill()
        'CMStatusDefault()
        'CStatusDefault()
        'Navigating = True
    End Sub

    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        NewRecordIsSaved = False
        Call Fill()
        ' CMStatusDefault()
        ' CStatusDefault()
        ' Navigating = True
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("MoneyExchanger").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        NewRecordIsSaved = False
        Call Fill()
        'CMStatusDefault()
        ' CStatusDefault()
        ' Navigating = True
    End Sub

    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("MoneyExchanger").Rows.Count - 1
        NewRecordIsSaved = False
        Call Fill()
        'CMStatusDefault()
        ' CStatusDefault()
        'Navigating = True
    End Sub
    Sub GridFill()
        Try
            DGSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = StrSearch
            If (ds.Tables.Contains("VuMoneyExchangerSearch")) Then
                ds.Tables("VuMoneyExchangerSearch").Clear()
                DGSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuMoneyExchangerSearch")

            For z = 0 To ds.Tables("VuMoneyExchangerSearch").Rows.Count - 1
                Try
                    DGSearch.Rows.Add()
                    DGSearch.Rows(z).Cells("SSNo").Value = (z + 1).ToString()
                    DGSearch.Rows(z).Cells("SName").Value = ds.Tables("VuMoneyExchangerSearch").Rows(z).Item("MoneyExchangerName")
                    DGSearch.Rows(z).Cells("SCName").Value = ds.Tables("VuMoneyExchangerSearch").Rows(z).Item("ConcernPName")
                    DGSearch.Rows(z).Cells("STel").Value = ds.Tables("VuMoneyExchangerSearch").Rows(z).Item("Phone")
                    DGSearch.Rows(z).Cells("SFax").Value = ds.Tables("VuMoneyExchangerSearch").Rows(z).Item("Fax")
                    DGSearch.Rows(z).Cells("SAddress").Value = ds.Tables("VuMoneyExchangerSearch").Rows(z).Item("Address")
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TC.SelectedIndexChanged
        If TC.SelectedIndex = 0 Then
            Call Clear()
            Call Fill()
            ToolStrip1.Enabled = True
            chbSingle.Checked = False
            cmbSarafName.Enabled = False
        Else
            DGSearch.Rows.Clear()
            Module1.DatasetFill("Select * from MoneyExchanger", "MoneyExchanger")
            cmbSarafName.DataSource = ds.Tables("MoneyExchanger")
            cmbSarafName.DisplayMember = ("MoneyExchangerName")
            cmbSarafName.ValueMember = ("MoneyExchangerID")
            cmbSarafName.SelectedIndex = -1
            'CM.Enabled = False
            ToolStrip1.Enabled = False
            chbSingle.Checked = False
            cmbSarafName.Enabled = False
        End If
    End Sub

    Private Sub btnSearc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearc.Click
        DGSearch.Rows.Clear()
        If chbSingle.Checked.Equals(False) Then
            StrSearch = "Select MoneyExchangerName,ConcernPName,Phone,Fax,Address from VuMoneyExchangerSearch"
            Call GridFill()
        Else
            If cmbSarafName.Text = "" Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                StrSearch = "Select MoneyExchangerName,ConcernPName,Phone,Fax,Address from VuMoneyExchangerSearch where MoneyExchangerID=" & cmbSarafName.SelectedValue & ""
                Call GridFill()
            End If
        End If
    End Sub

    Private Sub txtMExName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMExName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub txtConcernName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcernName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub txtAddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub chbSingle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSingle.CheckedChanged
        If chbSingle.Checked.Equals(True) Then
            cmbSarafName.Enabled = True
        Else
            cmbSarafName.Enabled = False
        End If
    End Sub

    Private Sub TSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSAdd.Click
        Clear()
        CStatus()
        EditValue = 1
        CMStatus()
    End Sub

    Private Sub TSSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSave.Click
        SaveUpdateMoneyExchanger()
    End Sub

    Private Sub TSUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUpdate.Click
        EditValue = 0
        CStatus()
        CMStatus()
    End Sub

    Private Sub bbtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbtnCancel.Click

    End Sub

    Private Sub TSDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSDelete.Click
        'If Not Me.Var_MoneyExchangerID = " " Then

        If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

            Module1.DeleteRecord("MoneyExchanger", "MoneyExchangerID = " & Var_MoneyExchangerID)

            'SetupListForAll.GridFill3("Select * from VuProduct order by ProdCode", "VuProduct", RelationForeignKey, FieldToBeDisplayed)
            cnt = ds.Tables("MoneyExchanger").Rows.Count
            If cnt = 0 Then
                Clear()
                Exit Sub
            End If

            'cnt = cnt - 1
            'NewRecordIsSaved = False
            '  Call TxtFillAfterDeletion()
            'OpenGrid()

            Fill()
        End If
        'End If
        'Module1.Opencn()
        'Navigating = Fals
    End Sub

    Private Sub TSClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSClose.Click
        Me.Close()
    End Sub

    Private Sub TSUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUndo.Click
        CMStatus()
        CStatus()
        EditValue = 1
        Fill()
    End Sub

    Private Sub txtphone_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtphone.KeyPress
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

    Private Sub txtCell_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCell.KeyPress
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
End Class
Imports System.Data.SqlClient
Imports LanguageSelector
Public Class frmAttendenceSheet
    Dim AttendenceID As Integer
    Dim EditValue As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim a As Integer
    Dim Slide As Boolean
    Private Sub frmAttendenceSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text

        Module1.DatasetFill("Select * from EmpPerInfo", "EmpPerInfo")
        cmbEmployeeName.DataSource = ds.Tables("EmpPerInfo")
        cmbEmployeeName.DisplayMember = ("Name")
        cmbEmployeeName.ValueMember = ("EmpID")
        cmbEmployeeName.SelectedIndex = -1

        Module1.DatasetFill("Select * from AttendenceStatus", "AttendenceStatus")
        cmbEmployeeStatus.DataSource = ds.Tables("AttendenceStatus")
        cmbEmployeeStatus.DisplayMember = ("StatusName")
        cmbEmployeeStatus.ValueMember = ("StatusID")
        cmbEmployeeStatus.SelectedIndex = -1


        Me.dtDate.MaxDate = DateTime.Today
        Me.dtDate.Value = DateTime.Today
        dtDate.Checked = False
        dtTimeIn.Value = Now
        dtTimeOut.Value = Now
        EditValue = 1
        GBSearch.Width = 0
        lblMessage.Text = "  "

        'If Frm.GID.Text <= 2 Then
        '    CM.Enabled = True
        'Else
        '    CM.Enabled = False
        'End If
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region " FUNCTIONS.......................... "

    Sub Clear()
        dtDate.Value = Now
        dtDate.Checked = False
        dtTimeIn.Value = Now
        dtTimeOut.Value = Now
        cmbEmployeeName.SelectedIndex = -1
        cmbEmployeeStatus.SelectedIndex = -1
        DGSearch.Rows.Clear()
    End Sub

    Sub CStatus()
        'dtDate.Enabled = Not dtDate.Enabled
        cmbEmployeeName.Enabled = Not cmbEmployeeName.Enabled
        cmbEmployeeStatus.Enabled = Not cmbEmployeeStatus.Enabled
        dtTimeIn.Enabled = Not dtTimeIn.Enabled
        dtTimeOut.Enabled = Not dtTimeOut.Enabled
        btnSearch.Enabled = Not btnSearch.Enabled
    End Sub

    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
    End Sub

    Sub IDPICKER()
        Module1.DatasetFill("Select * from AttendenceSheet", "AttendenceSheet")
        cmd.CommandText = "Select isNull(Max(AttendenceID),0) from AttendenceSheet"
        AttendenceID = cmd.ExecuteScalar + 1
    End Sub

    Sub InserUpdateAttendenceSheet()
        If EditValue = 1 Then
            IDPICKER()
        End If

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertUpdateAttendenceSheet"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@AttendenceID", SqlDbType.Int).Value = Me.AttendenceID
        cmdsave.Parameters.Add("@dtDate", SqlDbType.DateTime).Value = Me.dtDate.Value.Date

        cmdsave.Parameters.Add("@EmpID", SqlDbType.Int).Value = Me.cmbEmployeeName.SelectedValue
        cmdsave.Parameters.Add("@StatusID", SqlDbType.Int).Value = Me.cmbEmployeeStatus.SelectedValue
        If cmbEmployeeStatus.SelectedValue = 1 Then
            cmdsave.Parameters.Add("@TimeIn", SqlDbType.NVarChar).Value = Me.dtTimeIn.Text
            cmdsave.Parameters.Add("@TimeOut", SqlDbType.NVarChar).Value = Me.dtTimeOut.Text
        Else
            cmdsave.Parameters.Add("@TimeIn", SqlDbType.NVarChar).Value = "00:00:00"
            cmdsave.Parameters.Add("@TimeOut", SqlDbType.NVarChar).Value = "00:00:00"
        End If
        cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
        cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & AttendenceID

        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdsave.ExecuteNonQuery()

        cmdsave.Parameters.Clear()

        If EditValue = 1 Then
            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
        Else
            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
            EditValue = 1
        End If
        CStatus()
        CMStatus()
        Clear()
    End Sub

    Sub GridFill()
        Try

            Module1.DatasetFill("Select * from VuAttendenceSheet where dtDate='" & dtDate.Value.Date & "'", "VuAttendenceSheet")
            DGSearch.Rows.Clear()
            For a = 0 To ds.Tables("VuAttendenceSheet").Rows.Count - 1
                DGSearch.Rows.Add()
                DGSearch.Rows(a).Cells("DGAttendenceID").Value = ds.Tables("VuAttendenceSheet").Rows(a).Item("AttendenceID")
                DGSearch.Rows(a).Cells("DGEmpName").Value = ds.Tables("VuAttendenceSheet").Rows(a).Item("Name")
                DGSearch.Rows(a).Cells("DGEmpStatus").Value = ds.Tables("VuAttendenceSheet").Rows(a).Item("StatusName")
                DGSearch.Rows(a).Cells("DGEmpTimeIn").Value = ds.Tables("VuAttendenceSheet").Rows(a).Item("TimeIn")
                DGSearch.Rows(a).Cells("DGEmpTimeout").Value = ds.Tables("VuAttendenceSheet").Rows(a).Item("TimeOut")
            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " CONTEXT MENU ..............."

    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        Clear()
        CStatus()
        CMStatus()
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        InserUpdateAttendenceSheet()
        If dtTimeIn.Enabled = True Then
            dtTimeIn.Enabled = False
            dtTimeOut.Enabled = False
        End If
    End Sub

    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        Clear()
        CMStatus()
        CStatus()
        EditValue = 1
        If dtTimeIn.Enabled = True Then
            dtTimeIn.Enabled = False
            dtTimeOut.Enabled = False
        End If
        If GBSearch.Width <> 0 Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        CMStatus()
        CStatus()
        EditValue = 0
        If cmbEmployeeStatus.SelectedValue <> 1 Then
            dtTimeIn.Enabled = False
            dtTimeOut.Enabled = False
        Else
            dtTimeIn.Enabled = True
            dtTimeOut.Enabled = True
        End If
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub

#End Region

#Region "EVENTS..................."

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If btnSearch.Text = "+" Then
            Timer1.Enabled = True
            If GBSearch.Width = 0 Then
                Slide = True
            Else
                Slide = False
            End If
            GridFill()
        Else
            Timer1.Enabled = True
            If GBSearch.Width = 0 Then
                Slide = True
            Else
                Slide = False
            End If
            DGSearch.Rows.Clear()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Slide = True Then
            GBSearch.Width = GBSearch.Width + 100
            If GBSearch.Width = 600 Then
                Timer1.Enabled = False
                btnSearch.Text = "-"
            End If
        Else
            GBSearch.Width = GBSearch.Width - 100
            If GBSearch.Width = 0 Then
                Timer1.Enabled = False
                btnSearch.Text = "+"
            End If
        End If
    End Sub

    Private Sub dtDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDate.ValueChanged
        If GBSearch.Width = 0 Then
        Else
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub DGSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellDoubleClick
        Try
            AttendenceID = DGSearch.CurrentRow.Cells("DGAttendenceID").Value
            cmbEmployeeName.Text = DGSearch.CurrentRow.Cells("DGEmpName").Value
            cmbEmployeeStatus.Text = DGSearch.CurrentRow.Cells("DGEmpStatus").Value
            dtTimeIn.Text = DGSearch.CurrentRow.Cells("DGEmpTimeIn").Value
            dtTimeOut.Text = DGSearch.CurrentRow.Cells("DGEmpTimeOut").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbEmployeeStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmployeeStatus.SelectedIndexChanged
        Try
            If cmbEmployeeName.Enabled = True Then
                If cmbEmployeeStatus.SelectedValue <> 1 Then
                    dtTimeIn.Enabled = False
                    dtTimeOut.Enabled = False
                Else
                    dtTimeIn.Enabled = True
                    dtTimeOut.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub cmbEmployeeName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbEmployeeName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbEmployeeStatus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbEmployeeStatus.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub
End Class
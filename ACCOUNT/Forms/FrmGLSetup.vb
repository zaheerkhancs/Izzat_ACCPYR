
Public Class FrmGLSetup
    'Dim frm As New FrmIncomeStatment
    Private Sub FrmGLSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Module1.DatasetFill("Select * from VuPermission Where GroupID=" & Frm.GID.Text & " and PerName='General Ledger'", "VuPermission")
        If ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then

            BtnNext.Enabled = False
            BtnCashBook.Enabled = False
            BtnTrial.Enabled = False
            BtnBalanceSheet.Enabled = False
            BtnIncome.Enabled = False
            MsgBox("You have no right to view this Form . For further detail contact your administrator", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Alert")

        ElseIf ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = True And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
            BtnNext.Enabled = False
            BtnCashBook.Enabled = False
            BtnTrial.Enabled = False
            BtnBalanceSheet.Enabled = False
            BtnIncome.Enabled = False


        ElseIf ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = True And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
            BtnNext.Enabled = True
            BtnCashBook.Enabled = True
            BtnTrial.Enabled = True
            BtnBalanceSheet.Enabled = True
            BtnIncome.Enabled = True

        End If






        Module1.DatasetFill("Select * from Company", "Company")
        Dim a As Integer
        For a = 0 To ds.Tables("Company").Rows.Count - 1
            Me.CKList.Items.Add(ds.Tables("Company").Rows(a).Item(2))
        Next
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        Dim a As String = ""
        ' FrmGL.Close()
        ' FrmTrial.Close()
        ' FrmCashBook.Close()

        FrmGL.Compstr = ""
        For Each a In CKList.CheckedItems
            If FrmGL.Compstr = "" Then
                FrmGL.Compstr = "'" & a & "'"
            Else
                FrmGL.Compstr = FrmGL.Compstr & ",'" & a & "'"
            End If
        Next
        If FrmGL.Compstr = "" Then
            Dim frmm1 As New FrmBox("Please check companies name from the above list.")
            frmm1.BackColor = Color.OrangeRed
            '  frmm1.Opacity = 60%
            frmm1.ShowDialog()
        Else
            FrmGL.Show()
            FrmGL.BringToFront()
            ' FrmGL.MdiParent = FrmMain
            Me.Close()
            FrmGL.BringToFront()
        End If
    End Sub

    Private Sub BtnTrial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTrial.Click
        Dim a As String = ""
        ' FrmGL.Close()
        'FrmTrial.Close()
        'FrmCashBook.Close()
        FrmTrial.Compstr = ""
        For Each a In CKList.CheckedItems
            If FrmTrial.Compstr = "" Then
                FrmTrial.Compstr = "'" & a & "'"
            Else
                FrmTrial.Compstr = FrmTrial.Compstr & ",'" & a & "'"
            End If
        Next
        If FrmTrial.Compstr = "" Then
            Dim frmm1 As New FrmBox("Please check companies name from the above list.")
            frmm1.BackColor = Color.OrangeRed
            '  frmm1.Opacity = 60%
            frmm1.ShowDialog()
        Else
            Me.Close()

            FrmTrial.Show()
            ' FrmTrial.MdiParent = FrmMain

        End If

    End Sub

    Private Sub BtnCashBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCashBook.Click

        Dim a As String = ""
        FrmCashBook.Compstr = ""
        For Each a In CKList.CheckedItems
            If FrmCashBook.Compstr = "" Then
                FrmCashBook.Compstr = "'" & a & "'"
            Else
                FrmCashBook.Compstr = FrmCashBook.Compstr & ",'" & a & "'"
            End If
        Next
        If FrmCashBook.Compstr = "" Then
            Dim frmm1 As New FrmBox("Please check companies name from the above list.")
            frmm1.BackColor = Color.OrangeRed
            '  frmm1.Opacity = 60%
            frmm1.ShowDialog()
        Else
            Me.Close()

            '   FrmGL.Close()
            '  FrmTrial.Close()
            ' FrmCashBook.Close()
            FrmCashBook.Show()
            ' FrmTrial.MdiParent = FrmMain

        End If


    End Sub

    Private Sub BtnBalanceSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBalanceSheet.Click
        Dim a As String = ""
        FrmBalanceSheet.Compstr = ""
        For Each a In CKList.CheckedItems
            If FrmBalanceSheet.Compstr = "" Then
                FrmBalanceSheet.Compstr = "'" & a & "'"
            Else
                FrmBalanceSheet.Compstr = FrmBalanceSheet.Compstr & ",'" & a & "'"
            End If
        Next
        If FrmBalanceSheet.Compstr = "" Then
            Dim frmm1 As New FrmBox("Please check companies name from the above list.")
            frmm1.BackColor = Color.OrangeRed
            '  frmm1.Opacity = 60%
            frmm1.ShowDialog()
        Else
            Me.Close()

            '   FrmGL.Close()
            '  FrmTrial.Close()
            ' FrmCashBook.Close()
            FrmBalanceSheet.Show()
            ' FrmTrial.MdiParent = FrmMain

        End If





    End Sub

    Private Sub BtnIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIncome.Click
        Dim a As String = ""
        ' FrmIncomeStatment.Compstr = ""
        For Each a In CKList.CheckedItems
            If FrmIncomeStatment.Compstr = "" Then
                FrmIncomeStatment.Compstr = "'" & a & "'"
            Else
                FrmIncomeStatment.Compstr = FrmIncomeStatment.Compstr & ",'" & a & "'"
            End If
        Next
        If FrmIncomeStatment.Compstr = "" Then
            Dim frmm1 As New FrmBox("Please check companies name from the above list.")
            frmm1.BackColor = Color.OrangeRed
            '  frmm1.Opacity = 60%
            frmm1.ShowDialog()
        Else
            Me.Close()

            '   FrmGL.Close()
            '  FrmTrial.Close()
            ' FrmCashBook.Close()
            FrmIncomeStatment.Show()
        End If
    End Sub
End Class
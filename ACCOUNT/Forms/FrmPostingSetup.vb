
Public Class FrmPostingSetup

    Private Sub CalcTotal()
        LblDr.Text = "0"
        LblCr.Text = "0"
        Dim a As Integer

        For a = 0 To Dg.Rows.Count - 1
            LblDr.Text = Val(LblDr.Text) + Val(DG.Rows(a).Cells(7).Value)
            LblCr.Text = Val(LblCr.Text) + Val(DG.Rows(a).Cells(8).Value)

        Next
        LBlWords.Text = Module1.NoWord(Val(LblDr.Text))
    End Sub
    Sub GridFill()
        Dim a As Integer = 0
        DG.Rows.Clear()
        '  Module1.DatasetFill("Select * from VuVoucherDetail where Vno='" & Me.txtVno.Text & "'", "VuVoucherDetail")
        For a = 0 To ds.Tables("VuVoucherDetail").Rows.Count - 1
            DG.Rows.Add()
            DG.Rows(a).Cells(0).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(1)
            DG.Rows(a).Cells(1).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(2)
            DG.Rows(a).Cells(2).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(3)
            If IsDBNull(ds.Tables("VuVoucherDetail").Rows(a).Item(4)) = True Then
                DG.Columns(3).Visible = False
            Else
                DG.Columns(3).Visible = True
            End If
            DG.Rows(a).Cells(3).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(4)
            DG.Rows(a).Cells(4).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(5)
            DG.Rows(a).Cells(5).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(6)
            DG.Rows(a).Cells(6).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(7)
            DG.Rows(a).Cells(7).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(8)
            DG.Rows(a).Cells(8).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(9)

        Next
        Call CalcTotal()
    End Sub
    Sub MainGridFill()
        Dim a As Integer = 0
        DG1.Rows.Clear()
        Module1.DatasetFill("Select * from VoucherMain where Vpost=0 and Pid='" & Frm.LblPeriod.Text & "'", "VoucherMain")
        For a = 0 To ds.Tables("VoucherMain").Rows.Count - 1
            DG1.Rows.Add()
            DG1.Rows(a).Cells(1).Value = ds.Tables("VoucherMain").Rows(a).Item(0)
            DG1.Rows(a).Cells(2).Value = ds.Tables("VoucherMain").Rows(a).Item(2)
            DG1.Rows(a).Cells(3).Value = ds.Tables("VoucherMain").Rows(a).Item(4)
            If IsDBNull(ds.Tables("VoucherMain").Rows(a).Item(3)) = True Then
                DG1.Columns(4).Visible = False
            Else
                DG1.Columns(4).Visible = True
            End If
   
        Next
    End Sub

    Private Sub FrmPostingSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MaximizeBox = False

        ''Me.Left = 0
        ''Me.Top = 0
        Module1.Opencn()
        'Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
        'Me.Height = Screen.PrimaryScreen.Bounds.Height - 4
        ''Me.Height = Frm.Height - 70
        ''Me.Width = Frm.Width - 4
        GroupBox1.Left = Me.Width / 2 - (GroupBox1.Width / 2)
        GroupBox1.Top = Me.Height / 2 - (GroupBox1.Height / 2)
        MainGridFill()
    End Sub

    Private Sub DG1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellDoubleClick
        Try

        
            Dim a As Integer = 0
            DG.Rows.Clear()
            Module1.DatasetFill("Select * from VuVoucherDetail where Vno='" & DG1.CurrentRow.Cells(1).Value & "'", "VuVoucherDetail")
            For a = 0 To ds.Tables("VuVoucherDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(a).Cells(0).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(1)
                DG.Rows(a).Cells(1).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(2)
                DG.Rows(a).Cells(2).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(3)
                If IsDBNull(ds.Tables("VuVoucherDetail").Rows(a).Item(4)) = True Then
                    DG.Columns(3).Visible = False
                Else
                    DG.Columns(3).Visible = True
                End If
                DG.Rows(a).Cells(3).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(4)
                DG.Rows(a).Cells(4).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(5)
                DG.Rows(a).Cells(5).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(6)
                DG.Rows(a).Cells(6).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(7)
                DG.Rows(a).Cells(7).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(8)
                DG.Rows(a).Cells(8).Value = ds.Tables("VuVoucherDetail").Rows(a).Item(9)

            Next
            Call CalcTotal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG1.DataError, DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If MsgBox("Are you want to Post the above checked vouchers", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim a As Integer
            Dim cnt1 As Integer = 0
            For a = 0 To DG1.Rows.Count - 1
                If DG1.Rows(a).Cells(0).Value = True Then
                    cnt1 = cnt1 + 1
                    Module1.UpdateRecord("VoucherMain", "Vpost=1", "Vno='" & DG1.Rows(a).Cells(1).Value & "'")

                End If
                ' 
            Next
            MsgBox("Nos of " & cnt1 & " Voucher has been posted successfully")
            MainGridFill()
        End If
    End Sub
End Class
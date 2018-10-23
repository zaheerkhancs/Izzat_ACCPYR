Public Class FrmVoucherType

    Sub FillLV()
        Dim a As Integer
        LV.Items.Clear()
        Module1.DatasetFill("Select * from VoucherType", "VoucherType")
        'Dim imageListLarge As New ImageList()


        While a <= ds.Tables("VoucherType").Rows.Count - 1
            'Dim row As DataRow

            Dim Name1 As String
            Name1 = ds.Tables("VoucherType").Rows(a).Item(1)
            Dim Item1 As New ListViewItem(Name1, 0)
            LV.Items.AddRange(New ListViewItem() {Item1})

            LV.LargeImageList = ImageList1

            a = a + 1
        End While



        'Me.txtRel.Text = Rel
        'Me.txtBalance.Text = Val(Me.txtTotal.Text) - (Me.txtRel.Text)



    End Sub

    Private Sub FrmVoucherType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call FillLV()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If BtnAdd.Text = "علا وه" Then
            Me.TxtVoucher.Text = ""
            Me.TxtVoucher.Enabled = True
            BtnAdd.Text = "ثبت"
        Else
            If Me.TxtVoucher.Text = "" Then
                Dim frmm1 As New FrmBox("لطفآ خانه مذکور را خالی نگذارید ")
                frmm1.BackColor = Color.OrangeRed
                frmm1.ShowDialog()
                Exit Sub

            End If
            BtnAdd.Text = "علا وه"
            Module1.InsertRecord("VoucherType", "VoucherTypeName", "N'" & Me.TxtVoucher.Text & "'")
            Me.TxtVoucher.Enabled = False
            Me.TxtVoucher.Text = ""
            Call FillLV()
            Dim frmm As New FrmBox("نوع سند به کامیابی علاوه شد")
            frmm.ShowDialog()
        End If
    End Sub

    Private Sub LV_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LV.DoubleClick
        Try


            FrmVoucher.GroupBox1.Text = LV.FocusedItem.Text
            Me.Close()
            FrmVoucher.MdiParent = Frm
            FrmVoucher.Show()
            FrmVoucher.BringToFront()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
Public Class FrmCompanySetup

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim a As Integer
        Dim b As Integer
        Module1.DeleteRecord("CompannySetUp")
        'My.Settings("Setting") = Me.TxtName.Text

        If RbPosted.Checked = True Then
            a = 1
        Else
            a = 0
        End If
        If RbShow.Checked = True Then
            b = 1
        Else
            b = 0
        End If
        My.Settings.Save()

        Module1.InsertRecord("CompannySetUp", "N'" & Me.TxtName.Text & "'," & a & "," & b)
        MsgBox("Setting has been saved successfully")

    End Sub

    Private Sub FrmCompanySetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            Module1.DatasetFill("select * from CompannySetUp", "CompannySetUp")

            Me.TxtName.Text = ds.Tables("CompannySetUp").Rows(0).Item(0)

            If ds.Tables("CompannySetUp").Rows(0).Item(1) = True Then
                RbPosted.Checked = True
                NotPosted.Checked = False


            Else
                RbPosted.Checked = False
                NotPosted.Checked = True
            End If

            If ds.Tables("CompannySetUp").Rows(0).Item(2) = True Then
                RbShow.Checked = True
                RbNotShow.Checked = False

            Else
                RbShow.Checked = False
                RbNotShow.Checked = True
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
Imports System.Data.SqlClient
Public Class FrmUser
    ' Dim cls As New clsConnect
    Dim dr As SqlDataReader
    Dim Log As String
    Dim Pws As String
    Dim LoginID1 As Integer

    Private Sub FrmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Module1.DatasetFill("Select * from Groups", "Groups")


        CmbEmp.DataSource = Ds.Tables("Groups")
        CmbEmp.DisplayMember = "GroupName"
        CmbEmp.ValueMember = "GroupID"
        CmpEmp2.DataSource = Ds.Tables("Groups")
        Me.CmpEmp2.DisplayMember = "GroupName"
        CmpEmp2.ValueMember = "GroupID"

        Module1.DatasetFill("Select * from Company", "Company")
        CmbCompany.DataSource = ds.Tables("Company")
        CmbCompany.ValueMember = "CompanyID"
        CmbCompany.DisplayMember = "CompanyName"

        Me.CmbComp1.DataSource = ds.Tables("Company")
        Me.CmbComp1.ValueMember = "CompanyID"
        Me.CmbComp1.DisplayMember = "CompanyName"

        Module1.DatasetFill("Select * from FinancialPeriod", "FinancialPeriod1")
        CmbPeriod.DataSource = ds.Tables("FinancialPeriod1")
        CmbPeriod.ValueMember = "PID"
        CmbPeriod.DisplayMember = "PID"


        CMBPID1.DataSource = ds.Tables("FinancialPeriod1")
        CMBPID1.ValueMember = "PID"
        CMBPID1.DisplayMember = "PID"

        Call GridFill()
        Call FillLV()
        Call FillLV2()
    End Sub
    Sub GridFill()
        Dim a As Integer
        Cmd.CommandType = CommandType.Text

        Module1.DatasetFill("Select * from Permission", "Permission")

        For a = 0 To Ds.Tables("Permission").Rows.Count - 1
            DG.Rows.Add()
            DG(0, a).Value = Ds.Tables("Permission").Rows(a).Item(1)
            DG(4, a).Value = Ds.Tables("Permission").Rows(a).Item(0)
        Next


    End Sub

    Private Sub BtnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddUser.Click

        Dim count As Integer = 0
        Me.TxtPwd.Enabled = True
        Me.TxtRPwd.Enabled = True
        Me.TxtUName.Enabled = True
        Me.CmbEmp.Enabled = True
        CmbCompany.Enabled = True
        CmbPeriod.Enabled = True
        Me.btnOk.Enabled = True

        'Me.txtId.Enabled = True

        Me.txtId.Text = Module1.GetMax("UserID", "Login")
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.TxtPwd.Enabled = False
        Me.TxtRPwd.Enabled = False
        Me.TxtUName.Enabled = False
        Me.CmbEmp.Enabled = False
        Me.btnOk.Enabled = False
        CmbCompany.Enabled = False
        CmbPeriod.Enabled = False

        Me.TxtPwd.Text = ""
        Me.TxtRPwd.Text = ""
        Me.TxtUName.Text = ""
        Me.txtId.Text = ""
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Me.TxtPwd.Text <> Me.TxtRPwd.Text Then
            Dim frmm1 As New FrmBox("The password is not matching with confirm password")
            frmm1.BackColor = Color.OrangeRed
            frmm1.ShowDialog()
            Exit Sub
        End If
        Module1.InsertRecord("Login", "UserID,UserName,Password,CompanyID,GroupID,PID", Me.txtId.Text & ",N'" & Me.TxtUName.Text & "',N'" & Me.TxtPwd.Text & "'," & Me.CmbCompany.SelectedValue & "," & CmbEmp.SelectedValue & ",N'" & CmbPeriod.SelectedValue & "'")

        Me.TxtPwd.Enabled = False
        Me.TxtRPwd.Enabled = False
        Me.TxtUName.Enabled = False
        Me.CmbEmp.Enabled = False
        Me.btnOk.Enabled = False
        CmbCompany.Enabled = False
        CmbPeriod.Enabled = False
        Me.TxtPwd.Text = ""
        Me.TxtRPwd.Text = ""
        Me.TxtUName.Text = ""
        Me.txtId.Text = ""
        Dim frmm As New FrmBox("the User has been created successfully..")
        frmm.ShowDialog()
        Call FillLV()
        Call FillLV2()
    End Sub

    'Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    'End Sub


    Sub FillLV()
        Dim a As Integer
        LV.Items.Clear()
        Module1.DatasetFill("Select * from Groups", "Groups")
        'Dim imageListLarge As New ImageList()


        While a <= ds.Tables("Groups").Rows.Count - 1
            'Dim row As DataRow

            Dim Name1 As String
            Name1 = ds.Tables("Groups").Rows(a).Item(1)
            Dim Item1 As New ListViewItem(Name1, 2)
            LV.Items.AddRange(New ListViewItem() {Item1})


            LV.LargeImageList = ImageList1

            a = a + 1
        End While



        'Me.txtRel.Text = Rel
        'Me.txtBalance.Text = Val(Me.txtTotal.Text) - (Me.txtRel.Text)



    End Sub
    Sub FillLV2()
        Dim a As Integer
        LV2.Items.Clear()
        da.SelectCommand = Cmd
        Module1.DatasetFill("Select * from Login", "LoginInfo")
        'MsgBox(ds.Tables("LoginInfo").Rows.Count - 1).ToString()

        'Dim imageListLarge As New ImageList()


        While a <= Ds.Tables("LoginInfo").Rows.Count - 1
            'Dim row As DataRow

            Dim Name1 As String
            Name1 = Ds.Tables("LoginInfo").Rows(a).Item(1)
            Dim Item1 As New ListViewItem(Name1, 3)

            LV2.Items.AddRange(New ListViewItem() {Item1})


            LV2.LargeImageList = ImageList1

            a = a + 1
        End While



        '


    End Sub

    Private Sub LV_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles LV.ItemSelectionChanged
        Try
            Dim CmdGroupid As New SqlCommand
            Dim a As Integer
            Lb.Text = "Permissions to " & LV.Items(e.ItemIndex).Text

            Module1.DatasetFill("select * from VuPermission where GroupName=N'" & LV.Items(e.ItemIndex).Text & "'", "VuPermission")
            Log = LV.Items(e.ItemIndex).Text
            DG.Rows.Clear()


            'CmdGroupid.CommandType = CommandType.Text
            ' CmdGroupid.Connection = cn
            '  CmdGroupid.CommandText = "select GroupID from Groups where GroupName='" & LV.Items(e.ItemIndex).Text & "'"
            LoginID1 = Module1.GetValue("GroupID", "Groups", "GroupName=N'" & LV.Items(e.ItemIndex).Text & "'")
            'While dr.Read
            '    LoginID1 = dr.Item(0)
            'End While
            '  dr.Close()


            For a = 0 To ds.Tables("VuPermission").Rows.Count - 1

                DG.Rows.Add()

                DG(0, a).Value = ds.Tables("VuPermission").Rows(a).Item("PerName")

                'If ds.Tables("VuPermission").Rows(a).Item("Readonly") = 1 Then
                DG(1, a).Value = ds.Tables("VuPermission").Rows(a).Item("Readonly")
                'Else
                ' DG(1, a).Value = False

                'End If
                'If ds.Tables("VuPermission").Rows(a).Item("Created") = 1 Then
                DG(2, a).Value = ds.Tables("VuPermission").Rows(a).Item("Created")
                ' Else
                'DG(2, a).Value = False

                'End If
                'If ds.Tables("VuPermission").Rows(a).Item("CModify") = 1 Then
                DG(3, a).Value = ds.Tables("VuPermission").Rows(a).Item("CModify")
                'Else
                'DG(3, a).Value = False

                'End If
                DG(4, a).Value = ds.Tables("VuPermission").Rows(a).Item("PerId")

                DG(5, a).Value = ds.Tables("VuPermission").Rows(a).Item("GroupID")
            Next
            If ds.Tables("VuPermission").Rows.Count = 0 Then Call GridFill()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LV2_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles LV2.ItemSelectionChanged
        Try


            Module1.DatasetFill("select * from Login where UserName=N'" & LV2.Items(e.ItemIndex).Text & "'", "VuLogin")
            Log = LV2.Items(e.ItemIndex).Text
            Me.txtUid2.Text = ds.Tables("VULogin").Rows(0).Item(0)
            Me.txtUName2.Text = ds.Tables("VULogin").Rows(0).Item(1)
            Pws = Ds.Tables("VULogin").Rows(0).Item(2)
            'Me.CmpEmp2.SelectedIndex = 0
            Me.CmpEmp2.Text = ds.Tables("VULogin").Rows(0).Item(4)
            Me.CMBPID1.Text = ds.Tables("VULogin").Rows(0).Item("PID")
            Me.CmbComp1.Text = ds.Tables("VULogin").Rows(0).Item("CompanyID")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ''Sub DetermineSelection(ByVal item As DataGridView, ByRef count As Integer)

    ''    ' Retrieve the SelectCheckBox CheckBox control from the specified  
    ''    ' item (row) in the DataGrid control.
    ''    Dim selection As CheckBox = CType(item.FindControl("SelectCheckBox"), CheckBox)

    ''    ' If the item is selected, display the appropriate message and 
    ''    ' increment the count of selected items.
    ''    If Not selection Is Nothing Then

    ''        If selection.Checked Then

    ''            Message.Text &= "- " & item.Cells(1).Text & "<br>"
    ''            count = count + 1

    ''        End If

    ''    End If

    ''End Sub





    'Private Sub BtnAddPr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddPr.Click
    '    TabControl1.SelectTab(0)
    '    TabPage1.Show()
    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a As VariantType
        a = MsgBox("Are you want to Remove the Group.....?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Delete Alert")
        If a = vbYes Then

            Module1.DeleteRecord("Group", "GroupID=" & Log)
            Dim frmm As New FrmBox("The User has been removed successfully.")
            frmm.ShowDialog()
        End If
        Call FillLV()
        Call FillLV2()

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Pws <> Me.txtOldPws.Text Then
                Dim frmm2 As New FrmBox("Please Enter the Correct Old Password!")
                frmm2.BackColor = Color.OrangeRed
                frmm2.ShowDialog()

                Exit Sub
            End If
            If Me.txtNewPws.Text <> Me.txtCPwd.Text Then

                Dim frmm1 As New FrmBox("The password is not matching with Confirm Password!")
                frmm1.BackColor = Color.OrangeRed
                frmm1.ShowDialog()
            End If

            Module1.UpdateRecord("Login", "UserName='" & Me.txtUName2.Text & "',Password='" & Me.txtNewPws.Text & "',CompanyID='" & Me.CmbComp1.SelectedValue & "',GroupID=" & Val(Me.CmbEmp.SelectedValue) & ",PID='" & Me.CMBPID1.SelectedValue & "'", "UserID=" & Me.txtUid2.Text)

            Dim frmm As New FrmBox("The User Information has been Changed successfully.")
            frmm.ShowDialog()

            Me.txtOldPws.Text = ""
            Me.txtNewPws.Text = ""
            Me.txtCPwd.Text = ""
            Me.txtUName2.Text = ""
            Me.txtUid2.Text = ""
        Catch

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub BtnCancelPer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelPer.Click
        Me.Close()
    End Sub

    ''Private Sub Dg_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
    ''    If DG.CurrentCell.ColumnIndex = 1 Then
    ''        Dim ltxt As CheckBox
    ''        ltxt = CType(e.Control, CheckBox)
    ''        AddHandler ltxt.CheckedChanged, AddressOf OnKey

    ''    ElseIf DG.CurrentCell.ColumnIndex = 2 Then
    ''        Dim ltxt As CheckBox
    ''        ltxt = CType(e.Control, CheckBox)
    ''        AddHandler ltxt.CheckedChanged, AddressOf OnKey2
    ''    ElseIf DG.CurrentCell.ColumnIndex = 3 Then
    ''        Dim ltxt As CheckBox
    ''        ltxt = CType(e.Control, CheckBox)
    ''        AddHandler ltxt.CheckedChanged, AddressOf OnKey3


    ''    End If
    ''End Sub
    ''Private Sub OnKey(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    If sender.checked = True Then
    ''        DG.CurrentRow.Cells(1).Value = "Yes"
    ''    Else
    ''        DG.CurrentRow.Cells(1).Value = "No"
    ''    End If


    ''End Sub
    ''Private Sub OnKey3(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    If sender.checked = True Then
    ''        DG.CurrentRow.Cells(3).Value = "Yes"
    ''    Else
    ''        DG.CurrentRow.Cells(3).Value = "No"
    ''    End If


    ''End Sub
    ''Private Sub OnKey2(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    If sender.checked = True Then
    ''        DG.CurrentRow.Cells(2).Value = "Yes"
    ''    Else
    ''        DG.CurrentRow.Cells(2).Value = "No"
    ''    End If

    ''End Sub

    Private Sub BtnOkPer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOkPer.Click
        Dim d As Integer
        Module1.DeleteRecord("UserPermission", "GroupID=" & LoginID1)


        While d <= DG.Rows.Count - 1
            If DG(1, d).Value <> True Then
                DG(1, d).Value = 0
            Else
                DG(1, d).Value = 1
            End If
            If DG(2, d).Value <> True Then
                DG(2, d).Value = 0
            Else
                DG(2, d).Value = 1
            End If
            If DG(3, d).Value <> True Then
                DG(3, d).Value = 0
            Else
                DG(3, d).Value = 1
            End If
            Module1.InsertRecord("UserPermission", Val(DG(4, d).Value) & "," & LoginID1 & "," & Val(DG.Rows(d).Cells(1).Value) & "," & Val(DG.Rows(d).Cells(2).Value) & "," & Val(DG.Rows(d).Cells(3).Value))
            d = d + 1
        End While

        Dim frmm As New FrmBox("The Permissions assigned  successfully")
        frmm.Text = "Permission Alert"
        frmm.ShowDialog()

    End Sub
    Private Sub DG_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class
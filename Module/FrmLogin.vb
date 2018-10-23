
Imports System.Data.SqlClient
Imports System.ServiceProcess
Public Class FrmLogin
    Public CityID As Integer
    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'SqlServerState()
        Catch ex As Exception
            MessageBox.Show("SQL Server 2000 is not installed")
            Exit Sub
        End Try

        'DatabaseAttachment("IALimited")
        Module1.Opencn()
        'MsgBox(My.Settings("Setting"))
        Me.Left = 0
        Me.Top = 0
        ' FrmFirst.Show()
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        Panel1.Left = Me.Width / 2 - (Panel1.Width / 2)
        Panel1.Top = Me.Height / 2 - (Panel1.Height / 2)

        Module1.DatasetFill("Select * from Company", "Company")
        CmbCompany.DataSource = ds.Tables("Company")
        CmbCompany.ValueMember = "CompanyID"
        CmbCompany.DisplayMember = "CompanyName"

        Module1.DatasetFill("Select * from Groups", "Groups")
        CmbGroup.DataSource = ds.Tables("Groups")
        CmbGroup.ValueMember = "GroupID"
        CmbGroup.DisplayMember = "GroupName"

        Module1.DatasetFill("Select * from FinancialPeriod", "FinancialPeriod1")
        CmbAccount.DataSource = ds.Tables("FinancialPeriod1")
        CmbAccount.ValueMember = "PID"
        CmbAccount.DisplayMember = "PID"
        CmbAccount.SelectedIndex = 0

        Module1.DatasetFill("Select * from City", "City")
        cmbLocation.DataSource = ds.Tables("City")
        cmbLocation.DisplayMember = ("CityName")
        cmbLocation.ValueMember = ("CityID")

        Module1.DatasetFill("Select * from Login", "Login")
        TxtUserName.Text = "Izat"
        txtPassword.Focus()
        ' BtnOK_Click(BtnOK, e)
    End Sub
    Function SqlServerState() As Boolean
        Try
            Dim svc As New ServiceController("MSSQLSERVER", ".")
            Dim s As ServiceControllerStatus = svc.Status
            If s = ServiceControllerStatus.Stopped Then
                svc.Start()
                svc.WaitForStatus(ServiceControllerStatus.Running)
                svc.Refresh()
                Threading.Thread.Sleep(5000)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function DatabaseAttachment(ByVal DatabaseName As String) As Boolean
        Try
            'The following code also works,it fills dataset,but the active code part doesn't need to it cause it has already established connection.
            'Module1.DatasetFill("sp_databases", "Databases")
            'For Each datarow As DataRow In Module1.ds.Tables("Databases").Rows
            '    If datarow("DATABASE_NAME") = DatabaseName Then
            '        DBFound += 1
            '    End If
            'Next
            If cn.State = ConnectionState.Closed Then
                cn.ConnectionString = "data Source=.;Integrated Security=true"
                cn.Open()
            End If

            Dim dtable As DataTable = cn.GetSchema("databases")
            Dim drfound() As DataRow = dtable.Select("database_name='IALimited'")
            If drfound.Length > 0 Then

                '_AppActObjManager.ExcuteMyQuery("sp_detach_db '" & DatabaseName & "'")
                '_AppActObjManager.ExcuteMyQuery("sp_attach_db @dbname = N'" & DatabaseName & "'," & " @filename1 = N'" & Application.StartupPath & "\NPIW_Data.mdf',    @filename2 = N'" & Application.StartupPath & "\NPIW_Log.ldf' ")
            Else
                ExcuteMyQuery("sp_attach_db @dbname = N'" & DatabaseName & "'," & " @filename1 = N'" & Application.StartupPath & "\IALimited_Data.mdf',    @filename2 = N'" & Application.StartupPath & "\IALimited_Log.ldf' ")
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Dim drow As DataRow
        For Each drow In ds.Tables("Login").Rows
            If drow(1) = TxtUserName.Text And drow(2) = txtPassword.Text And drow(3) = CmbCompany.SelectedValue And drow(4) = CmbGroup.SelectedValue And drow(5) = CmbAccount.SelectedValue Then
                Frm.LBCompanyID.Text = CmbCompany.SelectedValue
                Frm.LBCompanyName.Text = CmbCompany.Text
                Frm.LbUserID.Text = drow(0)
                Frm.LbUserName.Text = TxtUserName.Text
                Frm.LblPeriod.Text = CmbAccount.Text
                Frm.GID.Text = CmbGroup.SelectedValue
                'MsgBox(CmbGroup.SelectedValue)
                Frm.lbLocationName.Text = cmbLocation.Text
                Frm.lbLocationID.Text = cmbLocation.SelectedValue
                Frm.Show()

                Exit Sub

            End If

        Next
        Dim frmm1 As New FrmBox("Please enter the correct information..")
        frmm1.BackColor = Color.OrangeRed
        '  frmm1.Opacity = 60%
        frmm1.ShowDialog()

    End Sub

  
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class
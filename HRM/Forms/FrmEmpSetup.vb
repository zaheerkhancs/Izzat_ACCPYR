Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Imports System.Drawing
Public Class FrmEmpSetup
    Dim EditNationality As Boolean
    Dim EditReligion As Boolean
    Dim EditDepartment As Boolean
    Dim EditJobTitle As Boolean
    Dim EditCity As Boolean
    Dim EditSave As Boolean
    Dim Check As Boolean
    Dim cnt As Integer
    Dim z As Integer
    Dim byt() As Byte
    Dim str As String
    Dim a As Integer
    Dim b As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim aziz As Integer = 0
    Dim FahimUpdateCustomerName As String
    Dim id As Integer
    Dim trans As SqlTransaction
    Dim headid As String
    Private Sub FrmEmpSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()
        Check = False
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        'Module1.DatasetFill("Select * from EmpPerInfo", "EmpPerInfo")

        Module1.DatasetFill("Select * from Nationality", "Nationality")
        cmd.CommandText = "Select isnull(Max(NID),0) from Nationality"
        lbNationalityID.Text = cmd.ExecuteScalar + 1
        cmbNationality.DataSource = ds.Tables("Nationality")
        cmbNationality.DisplayMember = ("NName")
        cmbNationality.ValueMember = ("NID")
        cmbNationality.SelectedIndex = -1

        Module1.DatasetFill("Select * from Religion", "Religion")
        cmd.CommandText = "Select isnull(Max(RID),0) from Religion"
        lbReligionID.Text = cmd.ExecuteScalar + 1
        cmbReligion.DataSource = ds.Tables("Religion")
        cmbReligion.DisplayMember = ("RName")
        cmbReligion.ValueMember = ("RID")
        cmbReligion.SelectedIndex = -1

        Module1.DatasetFill("Select * from Department", "Department")
        cmd.CommandText = "Select isnull(Max(DepID),0) from Department"
        lbDepartmentID.Text = cmd.ExecuteScalar + 1
        cmbDepartment.DataSource = ds.Tables("Department")
        cmbDepartment.DisplayMember = ("DepName")
        cmbDepartment.ValueMember = ("DepID")
        cmbDepartment.SelectedIndex = -1

        Module1.DatasetFill("Select * from Location", "Location")
        cmd.CommandText = "Select isnull(Max(LocID),0) from Location"
        lbCityID.Text = cmd.ExecuteScalar + 1
        cmbCity.DataSource = ds.Tables("Location")
        cmbCity.DisplayMember = ("LocName")
        cmbCity.ValueMember = ("LocID")
        cmbCity.SelectedIndex = -1

        Module1.DatasetFill("Select * from JobTitle", "JobTitle")
        cmd.CommandText = "Select isnull(Max(JobTitleID),0) from JobTitle"
        lbJobTitleID.Text = cmd.ExecuteScalar + 1

        EditNationality = False
        EditReligion = False
        EditDepartment = False
        EditJobTitle = False
        EditCity = False

        Check = True
        EditSave = True

        dtDate.Value = Now
        Me.DOB.MaxDate = DateTime.Today
        Me.DOB.Value = DateTime.Today
        Me.DOH.MaxDate = DateTime.Today
        Me.DOH.Value = DateTime.Today

        Call Fill()

        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region "MAIN................."

#Region "FUNCTION"
    Sub Status()
        txtName.ReadOnly = Not txtName.ReadOnly
        txtFName.ReadOnly = Not txtFName.ReadOnly
        txtContactNo.ReadOnly = Not txtContactNo.ReadOnly
        txtRefrence.ReadOnly = Not txtRefrence.ReadOnly
        txtEmail.ReadOnly = Not txtEmail.ReadOnly
        txtAddress.ReadOnly = Not txtAddress.ReadOnly
        txtContractDuration.ReadOnly = Not txtContractDuration.ReadOnly
        txtNoOfWorkingDays.ReadOnly = Not txtNoOfWorkingDays.ReadOnly
        txtBasicSalary.ReadOnly = Not txtBasicSalary.ReadOnly

        cmbNationality.Enabled = Not cmbNationality.Enabled
        cmbReligion.Enabled = Not cmbReligion.Enabled
        cmbDepartment.Enabled = Not cmbDepartment.Enabled
        cmbJobTitle.Enabled = Not cmbJobTitle.Enabled
        cmbCity.Enabled = Not cmbCity.Enabled

        btnAddNationality.Enabled = Not btnAddNationality.Enabled
        btnAddReligion.Enabled = Not btnAddReligion.Enabled
        btnAddDepartment.Enabled = Not btnAddDepartment.Enabled
        btnAddJobTitle.Enabled = Not btnAddJobTitle.Enabled
        btnAddCity.Enabled = Not btnAddCity.Enabled
        btnBrowse.Enabled = Not btnBrowse.Enabled

        DOB.Enabled = Not DOB.Enabled
        DOH.Enabled = Not DOH.Enabled
        dtDate.Enabled = Not dtDate.Enabled
    End Sub
    Sub CMStatus()
        TSAdd.Enabled = Not TSAdd.Enabled
        TSSave.Enabled = Not TSSave.Enabled
        TSUndo.Enabled = Not TSUndo.Enabled
        TSUpdate.Enabled = Not TSUpdate.Enabled
        TSDelete.Enabled = Not TSDelete.Enabled
        TSClose.Enabled = Not TSClose.Enabled
    End Sub
    Sub Clear()
        Try
            lblMessage.Text = ""
            txtName.Text = ""
            txtFName.Text = ""
            txtContactNo.Text = ""
            txtRefrence.Text = ""
            txtEmail.Text = ""
            txtAddress.Text = ""
            txtContractDuration.Text = ""
            txtNoOfWorkingDays.Text = ""
            txtBasicSalary.Text = ""

            If cmbNationality.Items.Count > 0 Then
                cmbNationality.SelectedIndex = 0
            End If

            If cmbReligion.Items.Count > 0 Then
                cmbReligion.SelectedIndex = 0
            End If

            If cmbDepartment.Items.Count > 0 Then
                cmbDepartment.SelectedIndex = 0
            End If

            If cmbJobTitle.Items.Count > 0 Then
                cmbJobTitle.SelectedIndex = 0
            End If

            If cmbCity.Items.Count > 0 Then
                cmbCity.SelectedIndex = 0
            End If

            dtDate.Value = Now
            DOB.Value = Now
            DOH.Value = Now

            EmpPB.Image = Nothing
            EmpPB.Image = EmpPB.InitialImage
        Catch ex As Exception

        End Try
    End Sub
    Sub IDPICKER()
        cmd.CommandText = "Select isnull(Max(EmpID),0) from EmpPerInfo"
        id = cmd.ExecuteScalar + 1

        cmd.CommandText = "Select isnull(Max(SubID),0) from Subsidiary"
        If id < (cmd.ExecuteScalar + 1) Then
            Me.txtEmpID.Text = cmd.ExecuteScalar + 1
        Else
            Me.txtEmpID.Text = id
        End If
    End Sub
    Sub Fill()
        Try
            EditSave = True
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from VuEmp", "VuEmp")
            If Module1.ds.Tables("VuEmp").Rows.Count = 0 Then
                Clear()
                Exit Sub
            End If
            txtEmpID.Text = ds.Tables("VuEmp").Rows(cnt).Item("EmpID")
            dtDate.Value = ds.Tables("VuEmp").Rows(cnt).Item("dtDate")
            txtName.Text = ds.Tables("VuEmp").Rows(cnt).Item("Name")
            txtFName.Text = ds.Tables("VuEmp").Rows(cnt).Item("FName")
            cmbNationality.Text = ds.Tables("VuEmp").Rows(cnt).Item("NName")
            cmbReligion.Text = ds.Tables("VuEmp").Rows(cnt).Item("RName")
            cmbDepartment.Text = ds.Tables("VuEmp").Rows(cnt).Item("DepName")
            cmbJobTitle.Text = ds.Tables("VuEmp").Rows(cnt).Item("JobTitle")
            txtContactNo.Text = ds.Tables("VuEmp").Rows(cnt).Item("ContactNo")
            txtRefrence.Text = ds.Tables("VuEmp").Rows(cnt).Item("Reference")
            txtEmail.Text = ds.Tables("VuEmp").Rows(cnt).Item("Email")
            txtAddress.Text = ds.Tables("VuEmp").Rows(cnt).Item("Address")
            cmbCity.Text = ds.Tables("VuEmp").Rows(cnt).Item("LocName")
            DOB.Value = ds.Tables("VuEmp").Rows(cnt).Item("DOB")
            DOH.Value = ds.Tables("VuEmp").Rows(cnt).Item("DOH")
            Me.EmpPB.Image = Image.FromStream(New MemoryStream(DirectCast(ds.Tables("VuEmp").Rows(cnt).Item("EmpP"), Byte())))
            'Try

            '    Module1.DatasetFill("Select * from Contract", "Contract")

            txtContractDuration.Text = ds.Tables("VuEmp").Rows(cnt).Item("Contract")
            txtNoOfWorkingDays.Text = ds.Tables("VuEmp").Rows(cnt).Item("NoOfWorkingDays")
            txtBasicSalary.Text = ds.Tables("VuEmp").Rows(cnt).Item("BasicSalary")

            'Catch ex As Exception
            'End Try

        Catch ex As Exception
        End Try
    End Sub
    Sub Save()
        Dim squery As String = ""

        trans = cn.BeginTransaction

 	  'this piece of code is done by Fahim, this is because sometimes when u do new,it erases
        ' the initial image, so here it checks that if it is removed and the user has also not
        ' assigned an image to it, then it would get that initial image back.
        'If Me.EmpPB.Image.ToString() = "" Then
        '    Me.EmpPB.Image = Image.FromFile("m.JPG")
        'Else

        'End If
        Dim ms As New MemoryStream
        Me.EmpPB.Image.Save(ms, EmpPB.Image.RawFormat)

        Dim byt() As Byte = (ms.GetBuffer)
        ms.Close()
        squery = "insert into EmpPerInfo(Empid,dtDate,Name,FName,Nationality,Religion,Department,JobTitle,ContactNo,Reference,Email,Address,City,DOB,DOH,EmpP,CItyID,CityBasedID)values(@empid,@dtDate,@Name,@FName,@Nationality,@Religion,@Department,@JobTitle,@ContactNo,@Reference,@Email,@Address,@City,@DOB,@DOH,@emppic,@CityID,@CityBasedID)"
        Dim cmd As New SqlClient.SqlCommand(squery, cn)

        cmd.Transaction = trans
        Try
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Me.txtEmpID.Text
            cmd.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Me.txtName.Text
            cmd.Parameters.Add("@FName", SqlDbType.NVarChar).Value = Me.txtFName.Text
            cmd.Parameters.Add("@Nationality", SqlDbType.Int).Value = Me.cmbNationality.SelectedValue
            cmd.Parameters.Add("@Religion", SqlDbType.Int).Value = Me.cmbReligion.SelectedValue
            cmd.Parameters.Add("@Department", SqlDbType.Int).Value = Me.cmbDepartment.SelectedValue
            cmd.Parameters.Add("@JobTitle", SqlDbType.Int).Value = Me.cmbJobTitle.SelectedValue
            cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = Me.txtContactNo.Text
            cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = Me.txtRefrence.Text
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtEmail.Text
            If txtAddress.Text = "" Then
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = "  "
            Else
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Me.txtAddress.Text
            End If
            cmd.Parameters.Add("@City", SqlDbType.Int).Value = Me.cmbCity.SelectedValue
            cmd.Parameters.Add("@DOB", SqlDbType.SmallDateTime).Value = Me.DOB.Value.Date.ToString
            cmd.Parameters.Add("@DOH", SqlDbType.SmallDateTime).Value = Me.DOH.Value.Date.ToString
            cmd.Parameters.Add("@emppic", SqlDbType.Image).Value = byt
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmd.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & txtEmpID.Text
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd.ExecuteNonQuery()

            cmd.Connection = cn
            cmd.Transaction = trans
            cmd.CommandText = "INSERT INTO Subsidiary VALUES(" & Me.txtEmpID.Text & ",N'" & Me.txtName.Text & "',N'" & headid & "','" & Me.dtDate.Value.Date.ToString & "',N' From HRM '," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",N'" & Frm.WName.Text & "')"
            cmd.ExecuteNonQuery()
            trans.Commit()

            Module1.InsertRecord("Contract", "EmpID,dtDate,Department,JobTitle,Contract,NoOfWorkingDays,BasicSalary", "" & txtEmpID.Text & ",'" & dtDate.Value.Date.ToString & "'," & cmbDepartment.SelectedValue & "," & cmbJobTitle.SelectedValue & ",N'" & txtContractDuration.Text & "',N'" & txtNoOfWorkingDays.Text & "'," & txtBasicSalary.Text & "")
            Call CMStatus()
            Call Status()
            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
        Catch ex As Exception
            trans.Rollback()
        End Try
    End Sub
    Sub UpdateRcd()
        Dim Uquery As String = ""

        trans = cn.BeginTransaction

        Dim ms As New MemoryStream
        Me.EmpPB.Image.Save(ms, EmpPB.Image.RawFormat)
        Dim byt() As Byte = (ms.GetBuffer)
        ms.Close()
        Uquery = "Update EmpPerInfo Set dtDate=@dtDate,Name=@Name,FName=@FName,Nationality=@Nationality,Religion=@Religion,Department=@Department,JobTitle=@JobTitle,ContactNo=@ContactNo,Reference=@Reference,Email=@Email,Address=@Address,City=@City,DOB=@DOB,DOH=@DOH,EmpP=@emppic where EmpID=@EmpID"
        Dim cmd As New SqlClient.SqlCommand(Uquery, cn)

        cmd.Transaction = trans
        Try
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Me.txtEmpID.Text
            cmd.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Me.txtName.Text
            cmd.Parameters.Add("@FName", SqlDbType.NVarChar).Value = Me.txtFName.Text
            cmd.Parameters.Add("@Nationality", SqlDbType.Int).Value = Me.cmbNationality.SelectedValue
            cmd.Parameters.Add("@Religion", SqlDbType.Int).Value = Me.cmbReligion.SelectedValue
            cmd.Parameters.Add("@Department", SqlDbType.Int).Value = Me.cmbDepartment.SelectedValue
            cmd.Parameters.Add("@JobTitle", SqlDbType.Int).Value = Me.cmbJobTitle.SelectedValue
            cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = Me.txtContactNo.Text
            cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = Me.txtRefrence.Text
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Me.txtEmail.Text
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Me.txtAddress.Text
            cmd.Parameters.Add("@City", SqlDbType.Int).Value = Me.cmbCity.SelectedValue
            cmd.Parameters.Add("@DOB", SqlDbType.SmallDateTime).Value = Me.DOB.Value.Date.ToString
            cmd.Parameters.Add("@DOH", SqlDbType.SmallDateTime).Value = Me.DOH.Value.Date.ToString
            cmd.Parameters.Add("@emppic", SqlDbType.Image).Value = byt
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd.ExecuteNonQuery()

            cmd.Connection = cn
            cmd.Transaction = trans
            cmd.Connection = cn
            cmd.CommandText = "UPDATE Subsidiary SET SubName =N'" & Me.txtName.Text & "',HEADID='" & headid & "',REMARKS=N' From HRM ',date='" & Me.dtDate.Value.Date.ToString & "',UserID=" & Frm.LbUserID.Text & ",WName=N'" & Frm.WName.Text & "' WHERE SUBID=" & Me.txtEmpID.Text
            cmd.ExecuteNonQuery()
            trans.Commit()

            If cmbDepartment.SelectedValue = 1 Then
                Module1.UpdateRecord("Customer", "CustomerName ='" & txtName.Text & "'", " CustomerTypeID =1 and CustomerName ='" & FahimUpdateCustomerName & "'")
            End If
            Module1.UpdateRecord("Contract", "dtDate='" & dtDate.Value.Date.ToString & "',Department=" & cmbDepartment.SelectedValue & ",JobTitle=" & cmbJobTitle.SelectedValue & ",Contract=N'" & txtContractDuration.Text & "',NoOfWorkingDays=N'" & txtNoOfWorkingDays.Text & "',BasicSalary=" & txtBasicSalary.Text & "", "EmpID=" & txtEmpID.Text & "")
            Module1.Opencn()
            Call CMStatus()
            Call Status()
            Call Fill()
            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
        Catch ex As Exception
            trans.Rollback()
        End Try
    End Sub

#End Region

#Region "BUTTONS"
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            OFD.ShowDialog()
            EmpPB.Image = Image.FromFile(OFD.FileName)
            OFD.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnAddNationality_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNationality.Click
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim abc As String
        Try
            If EditNationality = True Then
                If cmbNationality.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Try

                        For a = 0 To ds.Tables("Nationality").Rows.Count
                            abc = ds.Tables("Nationality").Rows(a).Item(1)
                            If cmbNationality.Text = abc Then
                                MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                                cmbNationality.Text = ""
                                Exit Sub
                            End If
                        Next

                    Catch ex As Exception
                    End Try
                    Dim CanN As String = " Pesh - " & lbNationalityID.Text
                    Dim IDN As Integer = 1
                    Module1.InsertRecord("Nationality", "NID,NName", "" & lbNationalityID.Text & ",N'" & cmbNationality.Text & "'")
                    Module1.DatasetFill("Select * from Nationality", "Nationality")
                    cmd.CommandText = "Select isnull(Max(NID),0) from Nationality"
                    lbNationalityID.Text = cmd.ExecuteScalar + 1
                    cmbNationality.DataSource = ds.Tables("Nationality")
                    cmbNationality.DisplayMember = ("NName")
                    cmbNationality.ValueMember = ("NID")
                    aziz = cmbNationality.Items.Count
                    cmbNationality.SelectedIndex = aziz - 1
                    cmbNationality.DropDownStyle = ComboBoxStyle.DropDownList
                    EditNationality = False
                    btnAddNationality.Text = "جدید"
                    btnCancelNationality.Visible = False
                    CM.Enabled = True
                    ToolStrip1.Enabled = True
                    btnAddReligion.Enabled = True
                    btnAddDepartment.Enabled = True
                    btnAddJobTitle.Enabled = True
                    btnAddCity.Enabled = True
                    cmbNationality.Focus()
                End If
            Else
                cmbNationality.DataSource = Nothing
                cmbNationality.Items.Clear()
                cmbNationality.DropDownStyle = ComboBoxStyle.DropDown
                EditNationality = True
                btnAddNationality.Text = "ثبت"
                btnCancelNationality.Visible = True
                CM.Enabled = False
                ToolStrip1.Enabled = False
                btnAddReligion.Enabled = False
                btnAddDepartment.Enabled = False
                btnAddJobTitle.Enabled = False
                btnAddCity.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddReligion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddReligion.Click
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim abc As String
        Try
            If EditReligion = True Then
                If cmbReligion.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & " " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Try

                        For a = 0 To ds.Tables("Religion").Rows.Count
                            abc = ds.Tables("Religion").Rows(a).Item(1)
                            If cmbReligion.Text = abc Then
                                MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                                cmbReligion.Text = ""
                                Exit Sub
                            End If
                        Next

                    Catch ex As Exception
                    End Try
                    Module1.InsertRecord("Religion", "RID,RName", "'" & lbReligionID.Text & "',N'" & cmbReligion.Text & "'")
                    Module1.DatasetFill("Select * from Religion", "Religion")
                    cmd.CommandText = "Select isnull(Max(RID),0) from Religion"
                    lbReligionID.Text = cmd.ExecuteScalar + 1
                    cmbReligion.DataSource = ds.Tables("Religion")
                    cmbReligion.DisplayMember = ("RName")
                    cmbReligion.ValueMember = ("RID")
                    aziz = cmbReligion.Items.Count
                    cmbReligion.SelectedIndex = aziz - 1
                    cmbReligion.DropDownStyle = ComboBoxStyle.DropDownList
                    EditReligion = False
                    btnAddReligion.Text = "جدید"
                    btnCancelReligion.Visible = False
                    CM.Enabled = True
                    ToolStrip1.Enabled = True
                    btnAddNationality.Enabled = True
                    btnAddDepartment.Enabled = True
                    btnAddJobTitle.Enabled = True
                    btnAddCity.Enabled = True
                    cmbReligion.Focus()
                End If
            Else
                cmbReligion.DataSource = Nothing
                cmbReligion.Items.Clear()
                cmbReligion.DropDownStyle = ComboBoxStyle.DropDown
                EditReligion = True
                btnAddReligion.Text = "ثبت"
                btnCancelReligion.Visible = True
                CM.Enabled = False
                ToolStrip1.Enabled = False
                btnAddNationality.Enabled = False
                btnAddDepartment.Enabled = False
                btnAddJobTitle.Enabled = False
                btnAddCity.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDepartment.Click
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim abc As String
        Try

            If EditDepartment = True Then
                If cmbDepartment.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Try

                        For a = 0 To ds.Tables("Department").Rows.Count
                            abc = ds.Tables("Department").Rows(a).Item(1)
                            If cmbDepartment.Text = abc Then
                                MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                                cmbDepartment.Text = ""
                                Exit Sub
                            End If
                        Next

                    Catch ex As Exception
                    End Try
                    Module1.InsertRecord("Department", "DepID,DepName", "'" & lbDepartmentID.Text & "',N'" & cmbDepartment.Text & "'")
                    Module1.DatasetFill("Select * from Department", "Department")
                    cmd.CommandText = "Select isnull(Max(DepID),0) from Department"
                    lbDepartmentID.Text = cmd.ExecuteScalar + 1
                    cmbDepartment.DataSource = ds.Tables("Department")
                    cmbDepartment.DisplayMember = ("DepName")
                    cmbDepartment.ValueMember = ("DepID")
                    aziz = cmbDepartment.Items.Count
                    cmbDepartment.SelectedIndex = aziz - 1
                    cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList
                    EditDepartment = False
                    btnAddDepartment.Text = "جدید"
                    btnCancelDepartment.Visible = False
                    CM.Enabled = True
                    ToolStrip1.Enabled = True
                    btnAddNationality.Enabled = True
                    btnAddReligion.Enabled = True
                    btnAddJobTitle.Enabled = True
                    btnAddCity.Enabled = True
                    cmbDepartment.Focus()
                End If
            Else
                cmbDepartment.DataSource = Nothing
                cmbDepartment.Items.Clear()
                cmbDepartment.DropDownStyle = ComboBoxStyle.DropDown
                EditDepartment = True
                btnAddDepartment.Text = "ثبت"
                btnCancelDepartment.Visible = True
                CM.Enabled = False
                ToolStrip1.Enabled = False
                btnAddNationality.Enabled = False
                btnAddReligion.Enabled = False
                btnAddJobTitle.Enabled = False
                btnAddCity.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnAddJobTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJobTitle.Click
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim abc As String
        Dim xyz As Integer
        Try

            If cmbDepartment.Text = "" Then
                MsgBox("PLEASE SELECT A DEPARTMENT FIRST" & Chr(13) & "  " & Chr(13) & " لطفآ اول یک شعبه را انتخاب کنید ", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If EditJobTitle = True Then
                If cmbJobTitle.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else

                    Try
                        For a = 0 To ds.Tables("JobTitle").Rows.Count
                            abc = ds.Tables("JobTitle").Rows(a).Item(2)
                            Try
                                For b = 0 To ds.Tables("JobTitle").Rows.Count
                                    xyz = ds.Tables("JobTitle").Rows(b).Item(1)
                                    If cmbJobTitle.Text = abc And cmbDepartment.SelectedValue = xyz Then
                                        MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                                        cmbJobTitle.Text = ""
                                        Exit Sub
                                    End If
                                Next

                            Catch ex As Exception
                            End Try
                        Next
                    Catch ex As Exception
                    End Try

                    Module1.InsertRecord("JobTitle", "JobTitleID,DepID,JobTitle", "'" & lbJobTitleID.Text & "','" & cmbDepartment.SelectedValue & "',N'" & cmbJobTitle.Text & "'")
                    Module1.DatasetFill("Select * from JobTitle where DepID='" & cmbDepartment.SelectedValue & "'", "JobTitle")
                    cmd.CommandText = "Select isnull(Max(JobTitleID),0) from JobTitle"
                    lbJobTitleID.Text = cmd.ExecuteScalar + 1
                    cmbJobTitle.DataSource = ds.Tables("JobTitle")
                    cmbJobTitle.DisplayMember = ("JobTitle")
                    cmbJobTitle.ValueMember = ("JobTitleID")
                    aziz = cmbJobTitle.Items.Count
                    cmbJobTitle.SelectedIndex = aziz - 1
                    cmbJobTitle.DropDownStyle = ComboBoxStyle.DropDownList
                    EditJobTitle = False
                    btnAddJobTitle.Text = "جدید"
                    btnCancelJobTitle.Visible = False
                    cmbDepartment.Enabled = True
                    btnAddDepartment.Enabled = True
                    CM.Enabled = True
                    ToolStrip1.Enabled = True
                    btnAddNationality.Enabled = True
                    btnAddReligion.Enabled = True
                    btnAddDepartment.Enabled = True
                    btnAddCity.Enabled = True
                    cmbJobTitle.Focus()
                End If
            Else
                cmbJobTitle.DataSource = Nothing
                cmbJobTitle.Items.Clear()
                cmbJobTitle.DropDownStyle = ComboBoxStyle.DropDown
                EditJobTitle = True
                btnAddJobTitle.Text = "ثبت"
                btnCancelJobTitle.Visible = True
                cmbDepartment.Enabled = False
                btnAddDepartment.Enabled = False
                CM.Enabled = False
                ToolStrip1.Enabled = False
                btnAddNationality.Enabled = False
                btnAddReligion.Enabled = False
                btnAddDepartment.Enabled = False
                btnAddCity.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCity.Click
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim abc As String
        Try
            If EditCity = True Then
                If cmbCity.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Try

                        For a = 0 To ds.Tables("Location").Rows.Count
                            abc = ds.Tables("Location").Rows(a).Item(1)
                            If cmbCity.Text = abc Then
                                MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                                cmbCity.Text = ""
                                Exit Sub
                            End If
                        Next

                    Catch ex As Exception
                    End Try
                    Module1.InsertRecord("Location", "LocID,LocName", "'" & lbCityID.Text & "',N'" & cmbCity.Text & "'")
                    Module1.DatasetFill("Select * from Location", "Location")
                    cmd.CommandText = "Select isnull(Max(LocID),0) from Location"
                    lbCityID.Text = cmd.ExecuteScalar + 1
                    cmbCity.DataSource = ds.Tables("Location")
                    cmbCity.DisplayMember = ("LocName")
                    cmbCity.ValueMember = ("LocID")
                    aziz = cmbCity.Items.Count
                    cmbCity.SelectedIndex = aziz - 1
                    cmbCity.DropDownStyle = ComboBoxStyle.DropDownList
                    EditCity = False
                    btnAddCity.Text = "جدید"
                    btnCancelCity.Visible = False
                    CM.Enabled = True
                    ToolStrip1.Enabled = True
                    btnAddNationality.Enabled = True
                    btnAddReligion.Enabled = True
                    btnAddDepartment.Enabled = True
                    btnAddJobTitle.Enabled = True
                    cmbCity.Focus()
                End If
            Else
                cmbCity.DataSource = Nothing
                cmbCity.Items.Clear()
                cmbCity.DropDownStyle = ComboBoxStyle.DropDown
                EditCity = True
                btnAddCity.Text = "ثبت"
                btnCancelCity.Visible = True
                CM.Enabled = False
                ToolStrip1.Enabled = False
                btnAddNationality.Enabled = False
                btnAddReligion.Enabled = False
                btnAddDepartment.Enabled = False
                btnAddJobTitle.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnCancelNationality_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelNationality.Click
        Try

            Module1.DatasetFill("Select * from Nationality", "Nationality")
            cmd.CommandText = "Select isnull(Max(NID),0) from Nationality"
            lbNationalityID.Text = cmd.ExecuteScalar + 1
            cmbNationality.DataSource = ds.Tables("Nationality")
            cmbNationality.DisplayMember = ("NName")
            cmbNationality.ValueMember = ("NID")
            cmbNationality.SelectedIndex = 0
            cmbNationality.DropDownStyle = ComboBoxStyle.DropDownList
            EditNationality = False
            btnAddNationality.Text = "جدید"
            btnCancelNationality.Visible = False
            CM.Enabled = True
            ToolStrip1.Enabled = True
            ToolStrip1.Enabled = True
            btnAddReligion.Enabled = True
            btnAddDepartment.Enabled = True
            btnAddJobTitle.Enabled = True
            btnAddCity.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelReligion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelReligion.Click
        Try

            Module1.DatasetFill("Select * from Religion", "Religion")
            cmd.CommandText = "Select isnull(Max(RID),0) from Religion"
            lbReligionID.Text = cmd.ExecuteScalar + 1
            cmbReligion.DataSource = ds.Tables("Religion")
            cmbReligion.DisplayMember = ("RName")
            cmbReligion.ValueMember = ("RID")
            cmbReligion.SelectedIndex = 0
            cmbReligion.DropDownStyle = ComboBoxStyle.DropDownList
            EditReligion = False
            btnAddReligion.Text = "جدید"
            btnCancelReligion.Visible = False
            CM.Enabled = True
            ToolStrip1.Enabled = True
            btnAddNationality.Enabled = True
            btnAddDepartment.Enabled = True
            btnAddJobTitle.Enabled = True
            btnAddCity.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelDepartment.Click
        Try

            Module1.DatasetFill("Select * from Department", "Department")
            cmd.CommandText = "Select isnull(Max(DepID),0) from Department"
            lbDepartmentID.Text = cmd.ExecuteScalar + 1
            cmbDepartment.DataSource = ds.Tables("Department")
            cmbDepartment.DisplayMember = ("DepName")
            cmbDepartment.ValueMember = ("DepID")
            cmbDepartment.SelectedIndex = 0
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList
            EditDepartment = False
            btnAddDepartment.Text = "جدید"
            btnCancelDepartment.Visible = False
            CM.Enabled = True
            ToolStrip1.Enabled = True
            btnAddNationality.Enabled = True
            btnAddReligion.Enabled = True
            btnAddJobTitle.Enabled = True
            btnAddCity.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelJobTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelJobTitle.Click
        Try

            Module1.DatasetFill("Select * from JobTitle where DepID='" & cmbDepartment.SelectedValue & "'", "JobTitle")
            cmd.CommandText = "Select isnull(Max(JobTitleID),0) from JobTitle"
            lbJobTitleID.Text = cmd.ExecuteScalar + 1
            cmbJobTitle.DataSource = ds.Tables("JobTitle")
            cmbJobTitle.DisplayMember = ("JobTitle")
            cmbJobTitle.ValueMember = ("JobTitleID")
            cmbJobTitle.SelectedIndex = 0
            cmbJobTitle.DropDownStyle = ComboBoxStyle.DropDownList
            EditJobTitle = False
            btnAddJobTitle.Text = "جدید"
            btnCancelJobTitle.Visible = False
            cmbDepartment.Enabled = True
            btnAddDepartment.Enabled = True
            CM.Enabled = True
            ToolStrip1.Enabled = True
            btnAddNationality.Enabled = True
            btnAddReligion.Enabled = True
            btnAddDepartment.Enabled = True
            btnAddCity.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelCity.Click
        Try

            Module1.DatasetFill("Select * from Location", "Location")
            cmd.CommandText = "Select isnull(Max(LocID),0) from Location"
            lbCityID.Text = cmd.ExecuteScalar + 1
            cmbCity.DataSource = ds.Tables("Location")
            cmbCity.DisplayMember = ("LocName")
            cmbCity.ValueMember = ("LocID")
            cmbCity.SelectedIndex = 0
            cmbCity.DropDownStyle = ComboBoxStyle.DropDownList
            EditCity = False
            btnAddCity.Text = "جدید"
            btnCancelCity.Visible = False
            CM.Enabled = True
            ToolStrip1.Enabled = True
            btnAddNationality.Enabled = True
            btnAddReligion.Enabled = True
            btnAddDepartment.Enabled = True
            btnAddJobTitle.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "CONTEXT MENUS"
    Private Sub TSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSAdd.Click
        If cn.State = ConnectionState.Closed Then cn.Open()
        Call Status()
        Call CMStatus()
        Call Clear()
    End Sub

    Private Sub TSUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUndo.Click
        Call Status()
        Call CMStatus()
        btnCancelNationality.PerformClick()
        btnCancelReligion.PerformClick()
        btnCancelDepartment.PerformClick()
        btnCancelJobTitle.PerformClick()
        btnCancelCity.PerformClick()
        If cmbDepartment.Enabled = True Then
            cmbDepartment.Enabled = False
            btnAddDepartment.Enabled = False
        End If
        Call Clear()
        Call Fill()
    End Sub

    Private Sub TSClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSClose.Click
        Me.Close()
    End Sub
    Private Sub TSSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSave.Click
        cmd.CommandText = "Select EmployeeCode from Impheads"
        headid = cmd.ExecuteScalar
        If EditSave = True Then
            IDPICKER()
            Call Save()
        Else
            Call UpdateRcd()
            EditSave = True
        End If
    End Sub
    Private Sub TSUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUpdate.Click
        Call CMStatus()
        Call Status()
        EditSave = False
        FahimUpdateCustomerName = txtName.Text
    End Sub
    Private Sub TSDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from EmpPerInfo where EmpID = " & Me.txtEmpID.Text
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from Contract where EmpID = " & Me.txtEmpID.Text
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'cmd.CommandText = " Delete from Subsidiary where SubID = " & Me.txtEmpID.Text
            'cmd.Connection = cn
            'cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuEmp").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Call Fill()
            lblMessage.Text = "ریکارد مذکور موفقانه فسخ شد "
        End If
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
        If cnt = ds.Tables("VuEmp").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call Fill()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuEmp").Rows.Count - 1
        Call Fill()
    End Sub

#End Region

#Region "EVENTS"
    Private Sub cmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartment.SelectedIndexChanged
        Try
            If cmbDepartment.Text = "" Then
                cmbJobTitle.DataSource = Nothing
                cmbJobTitle.Items.Clear()
                Exit Sub
            Else
                If Check = True Then
                    Module1.DatasetFill("Select * from JobTitle where DepID='" & cmbDepartment.SelectedValue & "'", "JobTitle")
                    cmbJobTitle.DataSource = ds.Tables("JobTitle")
                    cmbJobTitle.DisplayMember = ("JobTitle")
                    cmbJobTitle.ValueMember = ("JobTitleID")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB.SelectedIndexChanged
        If TB.SelectedIndex = 1 Then
            Call RadioClear()
            Call InVisible()
            lblMessage.Text = ""
        End If
    End Sub
#End Region

#End Region


#Region "SEARCH..................."

#Region "FUNCTIONS"
    Sub InVisible()
        GBCriteriaLoc.Visible = False
        GBCriteriaName.Visible = False
        GBCriteriaSalary.Visible = False

        DGSearchLoc.Visible = False
        DGSearchName.Visible = False
        DGSearchSalary.Visible = False
    End Sub
    Sub SearchName()
        Try

            DGSearchName.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = str
            If (ds.Tables.Contains("VuSearchEmp")) Then
                ds.Tables("VuSearchEmp").Clear()
                DGSearchName.Rows.Clear()
            End If
            da.Fill(ds, "VuSearchEmp")

            For z = 0 To ds.Tables("VuSearchEmp").Rows.Count - 1
                Try

                    DGSearchName.Rows.Add()
                    DGSearchName.Rows(z).Cells(0).Value = (z + 1).ToString()
                    DGSearchName.Rows(z).Cells(1).Value = ds.Tables("VuSearchEmp").Rows(z).Item("Name")
                    DGSearchName.Rows(z).Cells(2).Value = ds.Tables("VuSearchEmp").Rows(z).Item("FName")
                    DGSearchName.Rows(z).Cells(3).Value = ds.Tables("VuSearchEmp").Rows(z).Item("DepName")
                    DGSearchName.Rows(z).Cells(4).Value = ds.Tables("VuSearchEmp").Rows(z).Item("JobTitle")
                    DGSearchName.Rows(z).Cells(5).Value = ds.Tables("VuSearchEmp").Rows(z).Item("DOH".ToString())
                    DGSearchName.Rows(z).Cells(6).Value = ds.Tables("VuSearchEmp").Rows(z).Item("Contract")
                    DGSearchName.Rows(z).Cells(7).Value = ds.Tables("VuSearchEmp").Rows(z).Item("NoOfWorkingDays")
                    DGSearchName.Rows(z).Cells(8).Value = ds.Tables("VuSearchEmp").Rows(z).Item("BasicSalary")

                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SearchLoc()
        Try
            DGSearchLoc.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = str
            If (ds.Tables.Contains("VuSearchEmp")) Then
                ds.Tables("VuSearchEmp").Clear()
                DGSearchLoc.Rows.Clear()
            End If
            da.Fill(ds, "VuSearchEmp")

            For z = 0 To ds.Tables("VuSearchEmp").Rows.Count - 1
                Try

                    DGSearchLoc.Rows.Add()
                    DGSearchLoc.Rows(z).Cells(0).Value = (z + 1).ToString()
                    DGSearchLoc.Rows(z).Cells(1).Value = ds.Tables("VuSearchEmp").Rows(z).Item("Name")
                    DGSearchLoc.Rows(z).Cells(2).Value = ds.Tables("VuSearchEmp").Rows(z).Item("FName")
                    DGSearchLoc.Rows(z).Cells(3).Value = ds.Tables("VuSearchEmp").Rows(z).Item("JobTitle")
                    DGSearchLoc.Rows(z).Cells(4).Value = ds.Tables("VuSearchEmp").Rows(z).Item("DOH")
                    DGSearchLoc.Rows(z).Cells(5).Value = ds.Tables("VuSearchEmp").Rows(z).Item("Contract")
                    DGSearchLoc.Rows(z).Cells(6).Value = ds.Tables("VuSearchEmp").Rows(z).Item("NoOfWorkingDays")
                    DGSearchLoc.Rows(z).Cells(7).Value = ds.Tables("VuSearchEmp").Rows(z).Item("BasicSalary")

                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SearchSalary()
        Try
            DGSearchSalary.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = str
            If (ds.Tables.Contains("VuSearchEmp")) Then
                ds.Tables("VuSearchEmp").Clear()
                DGSearchSalary.Rows.Clear()
            End If
            da.Fill(ds, "VuSearchEmp")

            For z = 0 To ds.Tables("VuSearchEmp").Rows.Count - 1
                Try
                    DGSearchSalary.Rows.Add()
                    DGSearchSalary.Rows(z).Cells(0).Value = (z + 1).ToString()
                    DGSearchSalary.Rows(z).Cells(1).Value = ds.Tables("VuSearchEmp").Rows(z).Item("Name")
                    DGSearchSalary.Rows(z).Cells(2).Value = ds.Tables("VuSearchEmp").Rows(z).Item("FName")
                    DGSearchSalary.Rows(z).Cells(3).Value = ds.Tables("VuSearchEmp").Rows(z).Item("DepName")
                    DGSearchSalary.Rows(z).Cells(4).Value = ds.Tables("VuSearchEmp").Rows(z).Item("JobTitle")
                    DGSearchSalary.Rows(z).Cells(5).Value = ds.Tables("VuSearchEmp").Rows(z).Item("DOH")
                    DGSearchSalary.Rows(z).Cells(6).Value = ds.Tables("VuSearchEmp").Rows(z).Item("Contract")
                    DGSearchSalary.Rows(z).Cells(7).Value = ds.Tables("VuSearchEmp").Rows(z).Item("NoOfWorkingDays")
                    DGSearchSalary.Rows(z).Cells(8).Value = ds.Tables("VuSearchEmp").Rows(z).Item("BasicSalary")
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "EVENTS"
    Private Sub rbSearchName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSearchName.CheckedChanged
        If rbSearchName.Checked.Equals(True) Then
            Call InVisible()
            GBCriteriaName.Visible = True
            DGSearchName.Visible = True

            Module1.DatasetFill("Select EmpID,Name from EmpPerInfo", "EmpPerInfo")
            cmbSearchEmp.DataSource = ds.Tables("EmpPerInfo")
            cmbSearchEmp.DisplayMember = ("Name")
            cmbSearchEmp.ValueMember = ("EmpID")
            cmbSearchEmp.SelectedIndex = -1

            DGSearchName.Rows.Clear()
            txtNameSearch.Text = ""
        End If
    End Sub

    Private Sub rbSearchLoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSearchLoc.CheckedChanged
        If rbSearchLoc.Checked.Equals(True) Then
            Call InVisible()
            GBCriteriaLoc.Visible = True
            DGSearchLoc.Visible = True

            Module1.DatasetFill("Select * from Department", "Department")
            cmbSearchDep.DataSource = ds.Tables("Department")
            cmbSearchDep.DisplayMember = ("DepName")
            cmbSearchDep.ValueMember = ("DepID")
            cmbSearchDep.SelectedValue = -1

            Module1.DatasetFill("Select * from Location", "Location")
            cmbSearchLoc.DataSource = ds.Tables("Location")
            cmbSearchLoc.DisplayMember = ("LocName")
            cmbSearchLoc.ValueMember = ("LocID")
            cmbSearchLoc.SelectedValue = -1

            DGSearchLoc.Rows.Clear()
            txtNameSearch.Text = ""
        End If
    End Sub

    Private Sub rbSearchSalary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSearchSalary.CheckedChanged
        If rbSearchSalary.Checked.Equals(True) Then
            Call InVisible()
            GBCriteriaSalary.Visible = True
            DGSearchSalary.Visible = True

            txtFromSal.Text = ""
            txtToSal.Text = ""
            DGSearchSalary.Rows.Clear()
            txtNameSearch.Text = ""
        End If
    End Sub
    Sub RadioClear()
        rbSearchLoc.Checked = False
        rbSearchName.Checked = False
        rbSearchSalary.Checked = False
    End Sub
    Private Sub btnSearchEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchEmp.Click
        'str = "Select FName,Department,JobTitle,DOH,Contract,NoOfWorkingDays,BasicSalary from VuSearchEmp where Name = N'" & cmbSearchEmp.Text & "'"
        str = "Select Name,FName,DepName,JobTitle,DOH,Contract,NoOfWorkingDays,BasicSalary from VuSearchEmp where ( Name LIKE N'%" & txtNameSearch.Text & "%')"
        Call SearchName()
    End Sub

    Private Sub btnSearchLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLoc.Click
        str = "Select Name,FName,JobTitle,DOH,Contract,NoOfWorkingDays,BasicSalary from VuSearchEmp where DepName = N'" & cmbSearchDep.Text & "' And LocName = N'" & cmbSearchLoc.Text & "'"
        Call SearchLoc()
    End Sub

    Private Sub btnSearchSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSalary.Click
        str = "Select Name,FName,DepName,JobTitle,DOH,Contract,NoOfWorkingDays,BasicSalary from VuSearchEmp where BasicSalary between " & txtFromSal.Text & " And " & txtToSal.Text & ""
        Call SearchSalary()
    End Sub
    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Me.Close()
    End Sub
#End Region

#End Region


#Region "KEY PRESS FOR BOTH................."
    Private Sub txtContactNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactNo.KeyPress
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

    Private Sub txtBasicSalary_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBasicSalary.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtFromSal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromSal.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtToSal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToSal.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtName.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar < Chr(47) Or e.KeyChar > Chr(58)) Or e.KeyChar = Chr(32) Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtFName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtFName.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar < Chr(47) Or e.KeyChar > Chr(58)) Or e.KeyChar = Chr(32) Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtRefrence_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefrence.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtRefrence.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar < Chr(47) Or e.KeyChar > Chr(58)) Or e.KeyChar = Chr(32) Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNameSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNameSearch.KeyPress
        If txtNameSearch.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar < Chr(47) Or e.KeyChar > Chr(58)) Or e.KeyChar = Chr(32) Then
        Else
            e.Handled = True
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

    Private Sub txtAddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtAddress.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtContractDuration_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContractDuration.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtContractDuration.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNoOfWorkingDays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfWorkingDays.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub
#End Region

#Region "LINKS..........."

    Private Sub LLNationalityList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLNationalityList.LinkClicked
        Me.OpenGrid("Nationality", "NID")
    End Sub

    Sub OpenGrid(ByVal OpenGridTableName As String, ByVal OpenGridCriteria As String)

        SetupListForAllHRM.GridFill("Select * from " & OpenGridTableName & " Order by " & OpenGridCriteria, OpenGridTableName)
        SetupListForAllHRM.Obj = Me
        SetupListForAllHRM.Show()

        SetupListForAll.MdiParent = Frm
        SetupListForAllHRM.TopMost = True



    End Sub

    Private Sub LLReligionList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLReligionList.LinkClicked
        Me.OpenGrid("Religion", "RID")
    End Sub

    Private Sub LLJobTitleList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLJobTitleList.LinkClicked
        Me.OpenGrid("JobTitle", "JobTitleID")
    End Sub

    Private Sub LLCityList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLCityList.LinkClicked
        Me.OpenGrid("Location", "LocID")
    End Sub

    Private Sub LLDepartmentList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLDepartmentList.LinkClicked
        Me.OpenGrid("Department", "DepID")
    End Sub
#End Region

    Private Sub cmbNationality_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNationality.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        'If Asc(e.KeyChar) = 13 Then
        '    btnAddNationality.PerformClick()
        'End If
    End Sub

    Private Sub cmbReligion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbReligion.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        'If Asc(e.KeyChar) = 13 Then
        '    btnAddReligion.PerformClick()
        'End If
    End Sub

    Private Sub cmbDepartment_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDepartment.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        'If Asc(e.KeyChar) = 13 Then
        '    btnAddDepartment.PerformClick()
        'End If
    End Sub

    Private Sub cmbJobTitle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbJobTitle.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        'If Asc(e.KeyChar) = 13 Then
        '    btnAddJobTitle.PerformClick()
        'End If
    End Sub

    Private Sub cmbCity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCity.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        'If Asc(e.KeyChar) = 13 Then
        '    btnAddCity.PerformClick()
        'End If
    End Sub

    Private Sub txtName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        'If Not KeyboardLayout.getName() = "00000429" Then
        '    KeyboardLayout.Farsi()
        'End If
    End Sub

End Class
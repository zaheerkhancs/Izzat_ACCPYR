<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUser))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label20 = New System.Windows.Forms.Label
        Me.CmbPeriod = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.CmbCompany = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnAddUser = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbEmp = New System.Windows.Forms.ComboBox
        Me.TxtRPwd = New System.Windows.Forms.TextBox
        Me.TxtPwd = New System.Windows.Forms.TextBox
        Me.TxtUName = New System.Windows.Forms.TextBox
        Me.txtId = New System.Windows.Forms.TextBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.DG = New System.Windows.Forms.DataGridView
        Me.Permission = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Readonl = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Creat = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CreateM = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PerID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnOkPer = New System.Windows.Forms.Button
        Me.BtnCancelPer = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Lb = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnAddPr = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.LV = New System.Windows.Forms.ListView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label22 = New System.Windows.Forms.Label
        Me.CMBPID1 = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.CmbComp1 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtOldPws = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.CmpEmp2 = New System.Windows.Forms.ComboBox
        Me.txtCPwd = New System.Windows.Forms.TextBox
        Me.txtNewPws = New System.Windows.Forms.TextBox
        Me.txtUName2 = New System.Windows.Forms.TextBox
        Me.txtUid2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.LV2 = New System.Windows.Forms.ListView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(462, 473)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.BackgroundImage = CType(resources.GetObject("TabPage1.BackgroundImage"), System.Drawing.Image)
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.CmbPeriod)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.CmbCompany)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.BtnAddUser)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CmbEmp)
        Me.TabPage1.Controls.Add(Me.TxtRPwd)
        Me.TabPage1.Controls.Add(Me.TxtPwd)
        Me.TabPage1.Controls.Add(Me.TxtUName)
        Me.TabPage1.Controls.Add(Me.txtId)
        Me.TabPage1.Controls.Add(Me.btnOk)
        Me.TabPage1.Controls.Add(Me.BtnCancel)
        Me.TabPage1.ForeColor = System.Drawing.Color.White
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(454, 447)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Create Users"
        Me.TabPage1.ToolTipText = "Create User"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(48, 187)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 13)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Finanical  Period"
        '
        'CmbPeriod
        '
        Me.CmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPeriod.Enabled = False
        Me.CmbPeriod.FormattingEnabled = True
        Me.CmbPeriod.Location = New System.Drawing.Point(159, 184)
        Me.CmbPeriod.Name = "CmbPeriod"
        Me.CmbPeriod.Size = New System.Drawing.Size(224, 21)
        Me.CmbPeriod.TabIndex = 17
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(49, 161)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Company Name"
        Me.ToolTip1.SetToolTip(Me.Label19, "Company Name")
        '
        'CmbCompany
        '
        Me.CmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCompany.Enabled = False
        Me.CmbCompany.FormattingEnabled = True
        Me.CmbCompany.Location = New System.Drawing.Point(159, 158)
        Me.CmbCompany.Name = "CmbCompany"
        Me.CmbCompany.Size = New System.Drawing.Size(224, 21)
        Me.CmbCompany.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(87, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(279, 13)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "From here you can create new login user."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 52)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'BtnAddUser
        '
        Me.BtnAddUser.BackColor = System.Drawing.Color.Transparent
        Me.BtnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddUser.Location = New System.Drawing.Point(288, 32)
        Me.BtnAddUser.Name = "BtnAddUser"
        Me.BtnAddUser.Size = New System.Drawing.Size(125, 23)
        Me.BtnAddUser.TabIndex = 12
        Me.BtnAddUser.Text = "New User"
        Me.ToolTip1.SetToolTip(Me.BtnAddUser, "Add User")
        Me.BtnAddUser.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(37, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Confirm Password"
        Me.ToolTip1.SetToolTip(Me.Label5, "Confirm Password")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(87, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Password"
        Me.ToolTip1.SetToolTip(Me.Label4, "Password")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(69, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Group Name"
        Me.ToolTip1.SetToolTip(Me.Label3, "Group Name")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(78, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "User Name"
        Me.ToolTip1.SetToolTip(Me.Label2, "User Name")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(97, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "User ID"
        Me.ToolTip1.SetToolTip(Me.Label1, "User ID")
        '
        'CmbEmp
        '
        Me.CmbEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEmp.Enabled = False
        Me.CmbEmp.FormattingEnabled = True
        Me.CmbEmp.Location = New System.Drawing.Point(159, 132)
        Me.CmbEmp.Name = "CmbEmp"
        Me.CmbEmp.Size = New System.Drawing.Size(224, 21)
        Me.CmbEmp.TabIndex = 6
        '
        'TxtRPwd
        '
        Me.TxtRPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRPwd.Enabled = False
        Me.TxtRPwd.Location = New System.Drawing.Point(159, 236)
        Me.TxtRPwd.Name = "TxtRPwd"
        Me.TxtRPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtRPwd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRPwd.Size = New System.Drawing.Size(224, 21)
        Me.TxtRPwd.TabIndex = 5
        '
        'TxtPwd
        '
        Me.TxtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPwd.Enabled = False
        Me.TxtPwd.Location = New System.Drawing.Point(159, 210)
        Me.TxtPwd.Name = "TxtPwd"
        Me.TxtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPwd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPwd.Size = New System.Drawing.Size(224, 21)
        Me.TxtPwd.TabIndex = 4
        '
        'TxtUName
        '
        Me.TxtUName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUName.Enabled = False
        Me.TxtUName.Location = New System.Drawing.Point(159, 106)
        Me.TxtUName.Name = "TxtUName"
        Me.TxtUName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtUName.Size = New System.Drawing.Size(224, 21)
        Me.TxtUName.TabIndex = 3
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(159, 80)
        Me.txtId.Name = "txtId"
        Me.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtId.Size = New System.Drawing.Size(105, 14)
        Me.txtId.TabIndex = 2
        Me.txtId.Text = "0000"
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.Enabled = False
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Location = New System.Drawing.Point(261, 416)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(87, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        Me.ToolTip1.SetToolTip(Me.btnOk, "Ok")
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Location = New System.Drawing.Point(356, 416)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(87, 23)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "Cancel"
        Me.ToolTip1.SetToolTip(Me.BtnCancel, "Cancel")
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.BackgroundImage = CType(resources.GetObject("TabPage2.BackgroundImage"), System.Drawing.Image)
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.DG)
        Me.TabPage2.Controls.Add(Me.BtnOkPer)
        Me.TabPage2.Controls.Add(Me.BtnCancelPer)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Lb)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.BtnAddPr)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.LV)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(454, 447)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Permission"
        Me.TabPage2.ToolTipText = "Permissions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AllowUserToResizeColumns = False
        Me.DG.AllowUserToResizeRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DG.ColumnHeadersVisible = False
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Permission, Me.Readonl, Me.Creat, Me.CreateM, Me.PerID, Me.Group})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle4
        Me.DG.GridColor = System.Drawing.Color.White
        Me.DG.Location = New System.Drawing.Point(9, 245)
        Me.DG.Name = "DG"
        Me.DG.RowHeadersVisible = False
        Me.DG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DG.Size = New System.Drawing.Size(434, 147)
        Me.DG.TabIndex = 17
        '
        'Permission
        '
        Me.Permission.HeaderText = "Permission"
        Me.Permission.Name = "Permission"
        Me.Permission.ReadOnly = True
        Me.Permission.Width = 190
        '
        'Readonl
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.NullValue = "False"
        Me.Readonl.DefaultCellStyle = DataGridViewCellStyle1
        Me.Readonl.FalseValue = "False"
        Me.Readonl.HeaderText = "Read Only"
        Me.Readonl.IndeterminateValue = "False"
        Me.Readonl.Name = "Readonl"
        Me.Readonl.TrueValue = "True"
        Me.Readonl.Width = 70
        '
        'Creat
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.NullValue = "False"
        Me.Creat.DefaultCellStyle = DataGridViewCellStyle2
        Me.Creat.FalseValue = "False"
        Me.Creat.HeaderText = "Create "
        Me.Creat.IndeterminateValue = "False"
        Me.Creat.Name = "Creat"
        Me.Creat.TrueValue = "True"
        Me.Creat.Width = 70
        '
        'CreateM
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.NullValue = "False"
        Me.CreateM.DefaultCellStyle = DataGridViewCellStyle3
        Me.CreateM.FalseValue = "False"
        Me.CreateM.HeaderText = "Create and Modify"
        Me.CreateM.IndeterminateValue = "False"
        Me.CreateM.Name = "CreateM"
        Me.CreateM.TrueValue = "True"
        Me.CreateM.Width = 80
        '
        'PerID
        '
        Me.PerID.HeaderText = "PerID"
        Me.PerID.Name = "PerID"
        Me.PerID.Visible = False
        '
        'Group
        '
        Me.Group.HeaderText = "GroupID"
        Me.Group.Name = "Group"
        Me.Group.ReadOnly = True
        Me.Group.Visible = False
        '
        'BtnOkPer
        '
        Me.BtnOkPer.BackColor = System.Drawing.Color.Transparent
        Me.BtnOkPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOkPer.ForeColor = System.Drawing.Color.White
        Me.BtnOkPer.Location = New System.Drawing.Point(261, 416)
        Me.BtnOkPer.Name = "BtnOkPer"
        Me.BtnOkPer.Size = New System.Drawing.Size(87, 23)
        Me.BtnOkPer.TabIndex = 16
        Me.BtnOkPer.Text = "OK"
        Me.ToolTip1.SetToolTip(Me.BtnOkPer, "Ok")
        Me.BtnOkPer.UseVisualStyleBackColor = False
        '
        'BtnCancelPer
        '
        Me.BtnCancelPer.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancelPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelPer.ForeColor = System.Drawing.Color.White
        Me.BtnCancelPer.Location = New System.Drawing.Point(356, 416)
        Me.BtnCancelPer.Name = "BtnCancelPer"
        Me.BtnCancelPer.Size = New System.Drawing.Size(87, 23)
        Me.BtnCancelPer.TabIndex = 15
        Me.BtnCancelPer.Text = "Cancel"
        Me.ToolTip1.SetToolTip(Me.BtnCancelPer, "Cancel")
        Me.BtnCancelPer.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(340, 228)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Create && Modify"
        Me.ToolTip1.SetToolTip(Me.Label10, "Create && Modify")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(289, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Create"
        Me.ToolTip1.SetToolTip(Me.Label9, "Create")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(215, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Read Only"
        Me.ToolTip1.SetToolTip(Me.Label8, "Read Only")
        '
        'Lb
        '
        Me.Lb.AutoSize = True
        Me.Lb.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb.ForeColor = System.Drawing.Color.White
        Me.Lb.Location = New System.Drawing.Point(13, 228)
        Me.Lb.Name = "Lb"
        Me.Lb.Size = New System.Drawing.Size(79, 13)
        Me.Lb.TabIndex = 11
        Me.Lb.Text = "Permission"
        Me.ToolTip1.SetToolTip(Me.Lb, "Permissions")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Select the Group Name :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 8
        '
        'BtnAddPr
        '
        Me.BtnAddPr.BackColor = System.Drawing.Color.Transparent
        Me.BtnAddPr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddPr.ForeColor = System.Drawing.Color.White
        Me.BtnAddPr.Location = New System.Drawing.Point(262, 201)
        Me.BtnAddPr.Name = "BtnAddPr"
        Me.BtnAddPr.Size = New System.Drawing.Size(87, 23)
        Me.BtnAddPr.TabIndex = 3
        Me.BtnAddPr.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.BtnAddPr, "Add")
        Me.BtnAddPr.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(356, 201)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Remove"
        Me.ToolTip1.SetToolTip(Me.Button2, "Remove")
        Me.Button2.UseVisualStyleBackColor = False
        '
        'LV
        '
        Me.LV.BackColor = System.Drawing.Color.White
        Me.LV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV.LargeImageList = Me.ImageList1
        Me.LV.Location = New System.Drawing.Point(7, 36)
        Me.LV.Name = "LV"
        Me.LV.Size = New System.Drawing.Size(434, 159)
        Me.LV.TabIndex = 0
        Me.LV.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Users.bmp")
        Me.ImageList1.Images.SetKeyName(1, "user.ico")
        Me.ImageList1.Images.SetKeyName(2, "aa.jpg")
        Me.ImageList1.Images.SetKeyName(3, "2.jpg")
        Me.ImageList1.Images.SetKeyName(4, "3.jpg")
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Transparent
        Me.TabPage3.BackgroundImage = CType(resources.GetObject("TabPage3.BackgroundImage"), System.Drawing.Image)
        Me.TabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.CMBPID1)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.CmbComp1)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.txtOldPws)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.CmpEmp2)
        Me.TabPage3.Controls.Add(Me.txtCPwd)
        Me.TabPage3.Controls.Add(Me.txtNewPws)
        Me.TabPage3.Controls.Add(Me.txtUName2)
        Me.TabPage3.Controls.Add(Me.txtUid2)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.LV2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(454, 447)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Change Password"
        Me.TabPage3.ToolTipText = "Change Password"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(51, 387)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 13)
        Me.Label22.TabIndex = 27
        Me.Label22.Text = "Finanical  Period"
        '
        'CMBPID1
        '
        Me.CMBPID1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPID1.FormattingEnabled = True
        Me.CMBPID1.Location = New System.Drawing.Point(156, 385)
        Me.CMBPID1.Name = "CMBPID1"
        Me.CMBPID1.Size = New System.Drawing.Size(224, 21)
        Me.CMBPID1.TabIndex = 26
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(52, 362)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 13)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Company Name"
        Me.ToolTip1.SetToolTip(Me.Label21, "Company Name")
        '
        'CmbComp1
        '
        Me.CmbComp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbComp1.FormattingEnabled = True
        Me.CmbComp1.Location = New System.Drawing.Point(157, 360)
        Me.CmbComp1.Name = "CmbComp1"
        Me.CmbComp1.Size = New System.Drawing.Size(223, 21)
        Me.CmbComp1.TabIndex = 24
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(262, 419)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "OK"
        Me.ToolTip1.SetToolTip(Me.Button1, "Ok")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(357, 419)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 23)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "Cancel"
        Me.ToolTip1.SetToolTip(Me.Button3, "Cancel")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(67, 287)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Old Password"
        Me.ToolTip1.SetToolTip(Me.Label17, "Old Password")
        '
        'txtOldPws
        '
        Me.txtOldPws.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldPws.Location = New System.Drawing.Point(157, 285)
        Me.txtOldPws.Name = "txtOldPws"
        Me.txtOldPws.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPws.Size = New System.Drawing.Size(224, 21)
        Me.txtOldPws.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(40, 337)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Confirm Password"
        Me.ToolTip1.SetToolTip(Me.Label12, "Confirm Password")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(62, 312)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "New Password"
        Me.ToolTip1.SetToolTip(Me.Label13, "New Password")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(56, 262)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Employee Type"
        Me.ToolTip1.SetToolTip(Me.Label14, "Employee Type")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(81, 237)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "User Name"
        Me.ToolTip1.SetToolTip(Me.Label15, "User Name")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(100, 218)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "User ID"
        Me.ToolTip1.SetToolTip(Me.Label16, "User ID")
        '
        'CmpEmp2
        '
        Me.CmpEmp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmpEmp2.FormattingEnabled = True
        Me.CmpEmp2.Location = New System.Drawing.Point(157, 260)
        Me.CmpEmp2.Name = "CmpEmp2"
        Me.CmpEmp2.Size = New System.Drawing.Size(223, 21)
        Me.CmpEmp2.TabIndex = 12
        '
        'txtCPwd
        '
        Me.txtCPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCPwd.Location = New System.Drawing.Point(157, 335)
        Me.txtCPwd.Name = "txtCPwd"
        Me.txtCPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCPwd.Size = New System.Drawing.Size(224, 21)
        Me.txtCPwd.TabIndex = 15
        '
        'txtNewPws
        '
        Me.txtNewPws.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewPws.Location = New System.Drawing.Point(157, 310)
        Me.txtNewPws.Name = "txtNewPws"
        Me.txtNewPws.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPws.Size = New System.Drawing.Size(224, 21)
        Me.txtNewPws.TabIndex = 14
        '
        'txtUName2
        '
        Me.txtUName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUName2.Location = New System.Drawing.Point(157, 235)
        Me.txtUName2.Name = "txtUName2"
        Me.txtUName2.Size = New System.Drawing.Size(224, 21)
        Me.txtUName2.TabIndex = 11
        '
        'txtUid2
        '
        Me.txtUid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUid2.Enabled = False
        Me.txtUid2.Location = New System.Drawing.Point(157, 210)
        Me.txtUid2.Name = "txtUid2"
        Me.txtUid2.Size = New System.Drawing.Size(108, 21)
        Me.txtUid2.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(15, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Select the User Name :"
        '
        'LV2
        '
        Me.LV2.BackColor = System.Drawing.Color.White
        Me.LV2.LargeImageList = Me.ImageList1
        Me.LV2.Location = New System.Drawing.Point(8, 36)
        Me.LV2.Name = "LV2"
        Me.LV2.Size = New System.Drawing.Size(433, 159)
        Me.LV2.TabIndex = 10
        Me.LV2.UseCompatibleStateImageBehavior = False
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolTip1.IsBalloon = True
        '
        'FrmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(462, 473)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmUser"
        Me.Opacity = 0.85
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrator's Form"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbEmp As System.Windows.Forms.ComboBox
    Friend WithEvents TxtRPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxtPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxtUName As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnAddUser As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnAddPr As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LV As System.Windows.Forms.ListView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Lb As System.Windows.Forms.Label
    Friend WithEvents BtnOkPer As System.Windows.Forms.Button
    Friend WithEvents BtnCancelPer As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LV2 As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtOldPws As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CmpEmp2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtCPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPws As System.Windows.Forms.TextBox
    Friend WithEvents txtUName2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUid2 As System.Windows.Forms.TextBox
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Permission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Readonl As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Creat As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CreateM As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CmbComp1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CMBPID1 As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProduct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProduct))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbWeight = New System.Windows.Forms.ComboBox
        Me.cmbProdType = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.TSNavigator = New System.Windows.Forms.ToolStrip
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.LLProductsList = New System.Windows.Forms.LinkLabel
        Me.btnAddProdType = New System.Windows.Forms.Button
        Me.btnCancelProdType = New System.Windows.Forms.Button
        Me.btnAddWeight = New System.Windows.Forms.Button
        Me.btnCancelWeight = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPcsInCrtn = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSalPerCrtn = New System.Windows.Forms.TextBox
        Me.txtSalPerPiece = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtPricePerPcs = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPricePerCrtn = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbProdTypeEnglish = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtNameEnglish = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtSalPriceMobilePcs = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSalPriceMobileCrtn = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSNavigator.SuspendLayout()
        Me.CM.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(-149, 145)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 23)
        Me.Button1.TabIndex = 269
        Me.Button1.Text = "----"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(653, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 16)
        Me.Label9.TabIndex = 268
        Me.Label9.Text = "وزن"
        '
        'cmbWeight
        '
        Me.cmbWeight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbWeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWeight.Enabled = False
        Me.cmbWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbWeight.FormattingEnabled = True
        Me.cmbWeight.Location = New System.Drawing.Point(412, 179)
        Me.cmbWeight.Name = "cmbWeight"
        Me.cmbWeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbWeight.Size = New System.Drawing.Size(129, 21)
        Me.cmbWeight.TabIndex = 2
        '
        'cmbProdType
        '
        Me.cmbProdType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProdType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProdType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProdType.Enabled = False
        Me.cmbProdType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProdType.FormattingEnabled = True
        Me.cmbProdType.Location = New System.Drawing.Point(412, 124)
        Me.cmbProdType.Name = "cmbProdType"
        Me.cmbProdType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbProdType.Size = New System.Drawing.Size(175, 21)
        Me.cmbProdType.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(610, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 264
        Me.Label6.Text = "کود محصول"
        Me.Label6.Visible = False
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(411, 153)
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtName.Size = New System.Drawing.Size(176, 20)
        Me.txtName.TabIndex = 1
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.White
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtID.Location = New System.Drawing.Point(411, 97)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(131, 20)
        Me.txtID.TabIndex = 0
        Me.txtID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(604, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 261
        Me.Label1.Text = "اسم محصول "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(651, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "نوع"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(85, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 271
        Me.PictureBox1.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(103, 46)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(19, 14)
        Me.lblMessage.TabIndex = 272
        Me.lblMessage.Text = "..."
        '
        'TSNavigator
        '
        Me.TSNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSFirst, Me.TSPrevious, Me.TSLast, Me.TSNext})
        Me.TSNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TSNavigator.Name = "TSNavigator"
        Me.TSNavigator.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSNavigator.Size = New System.Drawing.Size(700, 25)
        Me.TSNavigator.TabIndex = 7
        Me.TSNavigator.Text = "ToolStrip1"
        '
        'TSFirst
        '
        Me.TSFirst.Image = CType(resources.GetObject("TSFirst.Image"), System.Drawing.Image)
        Me.TSFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSFirst.Name = "TSFirst"
        Me.TSFirst.Size = New System.Drawing.Size(65, 22)
        Me.TSFirst.Text = "نخستین"
        '
        'TSPrevious
        '
        Me.TSPrevious.Image = CType(resources.GetObject("TSPrevious.Image"), System.Drawing.Image)
        Me.TSPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSPrevious.Name = "TSPrevious"
        Me.TSPrevious.Size = New System.Drawing.Size(51, 22)
        Me.TSPrevious.Text = "قبلی"
        '
        'TSLast
        '
        Me.TSLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSLast.Image = CType(resources.GetObject("TSLast.Image"), System.Drawing.Image)
        Me.TSLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSLast.Name = "TSLast"
        Me.TSLast.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSLast.Size = New System.Drawing.Size(53, 22)
        Me.TSLast.Text = "نهایی"
        '
        'TSNext
        '
        Me.TSNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSNext.Image = CType(resources.GetObject("TSNext.Image"), System.Drawing.Image)
        Me.TSNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSNext.Name = "TSNext"
        Me.TSNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSNext.Size = New System.Drawing.Size(52, 22)
        Me.TSNext.Text = "بعدی"
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuEdit, Me.MnuDelete, Me.MnuUndo, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
        Me.CM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CM.Size = New System.Drawing.Size(139, 136)
        '
        'MnuNew
        '
        Me.MnuNew.BackColor = System.Drawing.Color.White
        Me.MnuNew.Image = CType(resources.GetObject("MnuNew.Image"), System.Drawing.Image)
        Me.MnuNew.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuNew.Name = "MnuNew"
        Me.MnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.MnuNew.Size = New System.Drawing.Size(138, 22)
        Me.MnuNew.Text = "&علاوه"
        '
        'MnuSave
        '
        Me.MnuSave.BackColor = System.Drawing.Color.White
        Me.MnuSave.Enabled = False
        Me.MnuSave.Image = CType(resources.GetObject("MnuSave.Image"), System.Drawing.Image)
        Me.MnuSave.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuSave.Name = "MnuSave"
        Me.MnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.MnuSave.Size = New System.Drawing.Size(138, 22)
        Me.MnuSave.Text = "&ثبت"
        '
        'MnuEdit
        '
        Me.MnuEdit.BackColor = System.Drawing.Color.White
        Me.MnuEdit.Image = CType(resources.GetObject("MnuEdit.Image"), System.Drawing.Image)
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.MnuEdit.Size = New System.Drawing.Size(138, 22)
        Me.MnuEdit.Text = "&تغیر"
        '
        'MnuDelete
        '
        Me.MnuDelete.BackColor = System.Drawing.Color.White
        Me.MnuDelete.Image = CType(resources.GetObject("MnuDelete.Image"), System.Drawing.Image)
        Me.MnuDelete.Name = "MnuDelete"
        Me.MnuDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuDelete.Size = New System.Drawing.Size(138, 22)
        Me.MnuDelete.Text = "&حذف"
        '
        'MnuUndo
        '
        Me.MnuUndo.BackColor = System.Drawing.Color.White
        Me.MnuUndo.Enabled = False
        Me.MnuUndo.Image = CType(resources.GetObject("MnuUndo.Image"), System.Drawing.Image)
        Me.MnuUndo.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuUndo.Name = "MnuUndo"
        Me.MnuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.MnuUndo.Size = New System.Drawing.Size(138, 22)
        Me.MnuUndo.Text = "خنثی"
        '
        'MnuExit
        '
        Me.MnuExit.BackColor = System.Drawing.Color.White
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MnuExit.Size = New System.Drawing.Size(138, 22)
        Me.MnuExit.Text = "&خروج"
        '
        'LLProductsList
        '
        Me.LLProductsList.AutoSize = True
        Me.LLProductsList.BackColor = System.Drawing.Color.Transparent
        Me.LLProductsList.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LLProductsList.LinkColor = System.Drawing.Color.Orange
        Me.LLProductsList.Location = New System.Drawing.Point(587, 46)
        Me.LLProductsList.Name = "LLProductsList"
        Me.LLProductsList.Size = New System.Drawing.Size(93, 16)
        Me.LLProductsList.TabIndex = 6
        Me.LLProductsList.TabStop = True
        Me.LLProductsList.Text = "لست محصولات"
        '
        'btnAddProdType
        '
        Me.btnAddProdType.BackColor = System.Drawing.Color.Transparent
        Me.btnAddProdType.Enabled = False
        Me.btnAddProdType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddProdType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnAddProdType.ForeColor = System.Drawing.Color.White
        Me.btnAddProdType.Location = New System.Drawing.Point(354, 124)
        Me.btnAddProdType.Name = "btnAddProdType"
        Me.btnAddProdType.Size = New System.Drawing.Size(44, 22)
        Me.btnAddProdType.TabIndex = 275
        Me.btnAddProdType.Text = "جدید"
        Me.btnAddProdType.UseVisualStyleBackColor = False
        '
        'btnCancelProdType
        '
        Me.btnCancelProdType.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelProdType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelProdType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancelProdType.ForeColor = System.Drawing.Color.White
        Me.btnCancelProdType.Location = New System.Drawing.Point(295, 123)
        Me.btnCancelProdType.Name = "btnCancelProdType"
        Me.btnCancelProdType.Size = New System.Drawing.Size(53, 22)
        Me.btnCancelProdType.TabIndex = 276
        Me.btnCancelProdType.Text = "فسخ"
        Me.btnCancelProdType.UseVisualStyleBackColor = False
        Me.btnCancelProdType.Visible = False
        '
        'btnAddWeight
        '
        Me.btnAddWeight.BackColor = System.Drawing.Color.Transparent
        Me.btnAddWeight.Enabled = False
        Me.btnAddWeight.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddWeight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnAddWeight.ForeColor = System.Drawing.Color.White
        Me.btnAddWeight.Location = New System.Drawing.Point(355, 178)
        Me.btnAddWeight.Name = "btnAddWeight"
        Me.btnAddWeight.Size = New System.Drawing.Size(44, 22)
        Me.btnAddWeight.TabIndex = 277
        Me.btnAddWeight.Text = "جدید"
        Me.btnAddWeight.UseVisualStyleBackColor = False
        '
        'btnCancelWeight
        '
        Me.btnCancelWeight.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelWeight.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelWeight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancelWeight.ForeColor = System.Drawing.Color.White
        Me.btnCancelWeight.Location = New System.Drawing.Point(296, 178)
        Me.btnCancelWeight.Name = "btnCancelWeight"
        Me.btnCancelWeight.Size = New System.Drawing.Size(53, 22)
        Me.btnCancelWeight.TabIndex = 278
        Me.btnCancelWeight.Text = "فسخ"
        Me.btnCancelWeight.UseVisualStyleBackColor = False
        Me.btnCancelWeight.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(12, 325)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 63)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = " پرنت"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(576, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "تعداد  در یک کارتن"
        '
        'txtPcsInCrtn
        '
        Me.txtPcsInCrtn.BackColor = System.Drawing.Color.White
        Me.txtPcsInCrtn.Location = New System.Drawing.Point(411, 206)
        Me.txtPcsInCrtn.Name = "txtPcsInCrtn"
        Me.txtPcsInCrtn.ReadOnly = True
        Me.txtPcsInCrtn.Size = New System.Drawing.Size(131, 20)
        Me.txtPcsInCrtn.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(214, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 16)
        Me.Label7.TabIndex = 289
        Me.Label7.Text = "قیمت فی کارتن"
        '
        'txtSalPerCrtn
        '
        Me.txtSalPerCrtn.BackColor = System.Drawing.Color.White
        Me.txtSalPerCrtn.Location = New System.Drawing.Point(29, 14)
        Me.txtSalPerCrtn.Name = "txtSalPerCrtn"
        Me.txtSalPerCrtn.ReadOnly = True
        Me.txtSalPerCrtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSalPerCrtn.Size = New System.Drawing.Size(131, 21)
        Me.txtSalPerCrtn.TabIndex = 0
        '
        'txtSalPerPiece
        '
        Me.txtSalPerPiece.BackColor = System.Drawing.Color.White
        Me.txtSalPerPiece.Location = New System.Drawing.Point(29, 40)
        Me.txtSalPerPiece.Name = "txtSalPerPiece"
        Me.txtSalPerPiece.ReadOnly = True
        Me.txtSalPerPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSalPerPiece.Size = New System.Drawing.Size(131, 21)
        Me.txtSalPerPiece.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(222, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 16)
        Me.Label8.TabIndex = 290
        Me.Label8.Text = "قیمت فی دانه"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtSalPerCrtn)
        Me.GroupBox1.Controls.Add(Me.txtSalPerPiece)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(376, 319)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(312, 69)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "فروش"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtPricePerPcs)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPricePerCrtn)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(376, 240)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(312, 69)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "خرید"
        '
        'txtPricePerPcs
        '
        Me.txtPricePerPcs.BackColor = System.Drawing.Color.White
        Me.txtPricePerPcs.Location = New System.Drawing.Point(29, 42)
        Me.txtPricePerPcs.Name = "txtPricePerPcs"
        Me.txtPricePerPcs.ReadOnly = True
        Me.txtPricePerPcs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPricePerPcs.Size = New System.Drawing.Size(131, 21)
        Me.txtPricePerPcs.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(209, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 289
        Me.Label5.Text = "قیمت فی کارتن "
        '
        'txtPricePerCrtn
        '
        Me.txtPricePerCrtn.BackColor = System.Drawing.Color.White
        Me.txtPricePerCrtn.Location = New System.Drawing.Point(30, 14)
        Me.txtPricePerCrtn.Name = "txtPricePerCrtn"
        Me.txtPricePerCrtn.ReadOnly = True
        Me.txtPricePerCrtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPricePerCrtn.Size = New System.Drawing.Size(131, 21)
        Me.txtPricePerCrtn.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(220, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 287
        Me.Label4.Text = "قیمت فی دانه"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(286, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 16)
        Me.Label10.TabIndex = 281
        Me.Label10.Text = "Product Code"
        Me.Label10.Visible = False
        '
        'cmbProdTypeEnglish
        '
        Me.cmbProdTypeEnglish.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProdTypeEnglish.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProdTypeEnglish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProdTypeEnglish.Enabled = False
        Me.cmbProdTypeEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProdTypeEnglish.FormattingEnabled = True
        Me.cmbProdTypeEnglish.Location = New System.Drawing.Point(114, 124)
        Me.cmbProdTypeEnglish.Name = "cmbProdTypeEnglish"
        Me.cmbProdTypeEnglish.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbProdTypeEnglish.Size = New System.Drawing.Size(169, 21)
        Me.cmbProdTypeEnglish.TabIndex = 283
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(21, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 285
        Me.Label11.Text = "Product Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(18, 126)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 16)
        Me.Label12.TabIndex = 284
        Me.Label12.Text = "Product Type"
        '
        'txtNameEnglish
        '
        Me.txtNameEnglish.BackColor = System.Drawing.Color.White
        Me.txtNameEnglish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNameEnglish.Enabled = False
        Me.txtNameEnglish.Location = New System.Drawing.Point(114, 151)
        Me.txtNameEnglish.Name = "txtNameEnglish"
        Me.txtNameEnglish.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNameEnglish.Size = New System.Drawing.Size(169, 20)
        Me.txtNameEnglish.TabIndex = 282
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txtSalPriceMobilePcs)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtSalPriceMobileCrtn)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(103, 240)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(267, 147)
        Me.GroupBox3.TabIndex = 286
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "قیمت فروش فروشنده های سیار"
        '
        'txtSalPriceMobilePcs
        '
        Me.txtSalPriceMobilePcs.BackColor = System.Drawing.Color.White
        Me.txtSalPriceMobilePcs.Location = New System.Drawing.Point(14, 97)
        Me.txtSalPriceMobilePcs.Name = "txtSalPriceMobilePcs"
        Me.txtSalPriceMobilePcs.ReadOnly = True
        Me.txtSalPriceMobilePcs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSalPriceMobilePcs.Size = New System.Drawing.Size(131, 20)
        Me.txtSalPriceMobilePcs.TabIndex = 291
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(151, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 16)
        Me.Label13.TabIndex = 291
        Me.Label13.Text = "قیمت فی کارتن "
        '
        'txtSalPriceMobileCrtn
        '
        Me.txtSalPriceMobileCrtn.BackColor = System.Drawing.Color.White
        Me.txtSalPriceMobileCrtn.Location = New System.Drawing.Point(14, 46)
        Me.txtSalPriceMobileCrtn.Name = "txtSalPriceMobileCrtn"
        Me.txtSalPriceMobileCrtn.ReadOnly = True
        Me.txtSalPriceMobileCrtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSalPriceMobileCrtn.Size = New System.Drawing.Size(131, 20)
        Me.txtSalPriceMobileCrtn.TabIndex = 290
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(164, 95)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 16)
        Me.Label14.TabIndex = 290
        Me.Label14.Text = "قیمت فی دانه"
        '
        'FrmProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(700, 411)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmbProdTypeEnglish)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtNameEnglish)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPcsInCrtn)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnAddWeight)
        Me.Controls.Add(Me.LLProductsList)
        Me.Controls.Add(Me.btnCancelWeight)
        Me.Controls.Add(Me.TSNavigator)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnAddProdType)
        Me.Controls.Add(Me.btnCancelProdType)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbWeight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbProdType)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSNavigator.ResumeLayout(False)
        Me.TSNavigator.PerformLayout()
        Me.CM.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents TSNavigator As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LLProductsList As System.Windows.Forms.LinkLabel
    Friend WithEvents btnAddProdType As System.Windows.Forms.Button
    Friend WithEvents btnCancelProdType As System.Windows.Forms.Button
    Friend WithEvents btnAddWeight As System.Windows.Forms.Button
    Friend WithEvents btnCancelWeight As System.Windows.Forms.Button
    Public WithEvents cmbWeight As System.Windows.Forms.ComboBox
    Public WithEvents cmbProdType As System.Windows.Forms.ComboBox
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txtPcsInCrtn As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txtSalPerCrtn As System.Windows.Forms.TextBox
    Public WithEvents txtSalPerPiece As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents txtPricePerCrtn As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents txtPricePerPcs As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents cmbProdTypeEnglish As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txtNameEnglish As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents txtSalPriceMobilePcs As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents txtSalPriceMobileCrtn As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class

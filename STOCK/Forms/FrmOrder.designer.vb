<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrder))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlcentre = New System.Windows.Forms.Panel
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TB1 = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCompanySearch = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbOrderNoSearch = New System.Windows.Forms.ComboBox
        Me.txtJobTilte = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbOrderNo = New System.Windows.Forms.ComboBox
        Me.txtPersonName = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.cmbVendorForOrderMain = New System.Windows.Forms.ComboBox
        Me.dtReqDate = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGcmbPType = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGcmbProdName = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGProductID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtOrderDate = New System.Windows.Forms.DateTimePicker
        Me.pnlcentre.SuspendLayout()
        Me.CM.SuspendLayout()
        Me.TB1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlcentre
        '
        Me.pnlcentre.ContextMenuStrip = Me.CM
        Me.pnlcentre.Controls.Add(Me.btnPrint)
        Me.pnlcentre.Controls.Add(Me.Label14)
        Me.pnlcentre.Controls.Add(Me.TB1)
        Me.pnlcentre.Location = New System.Drawing.Point(13, 38)
        Me.pnlcentre.Name = "pnlcentre"
        Me.pnlcentre.Size = New System.Drawing.Size(720, 553)
        Me.pnlcentre.TabIndex = 0
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSearch, Me.MnuReturn, Me.MnuNew, Me.MnuSave, Me.MnuUndo, Me.MnuEdit, Me.MnuDelete, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
        Me.CM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CM.Size = New System.Drawing.Size(148, 180)
        '
        'MnuSearch
        '
        Me.MnuSearch.BackColor = System.Drawing.Color.White
        Me.MnuSearch.Image = CType(resources.GetObject("MnuSearch.Image"), System.Drawing.Image)
        Me.MnuSearch.Name = "MnuSearch"
        Me.MnuSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuSearch.Size = New System.Drawing.Size(147, 22)
        Me.MnuSearch.Text = "&جستجو"
        '
        'MnuReturn
        '
        Me.MnuReturn.BackColor = System.Drawing.Color.White
        Me.MnuReturn.Image = CType(resources.GetObject("MnuReturn.Image"), System.Drawing.Image)
        Me.MnuReturn.Name = "MnuReturn"
        Me.MnuReturn.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.MnuReturn.Size = New System.Drawing.Size(147, 22)
        Me.MnuReturn.Text = "&برگشت"
        '
        'MnuNew
        '
        Me.MnuNew.BackColor = System.Drawing.Color.White
        Me.MnuNew.Image = CType(resources.GetObject("MnuNew.Image"), System.Drawing.Image)
        Me.MnuNew.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuNew.Name = "MnuNew"
        Me.MnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.MnuNew.Size = New System.Drawing.Size(147, 22)
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
        Me.MnuSave.Size = New System.Drawing.Size(147, 22)
        Me.MnuSave.Text = "&ثبت"
        '
        'MnuUndo
        '
        Me.MnuUndo.BackColor = System.Drawing.Color.White
        Me.MnuUndo.Enabled = False
        Me.MnuUndo.Image = CType(resources.GetObject("MnuUndo.Image"), System.Drawing.Image)
        Me.MnuUndo.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuUndo.Name = "MnuUndo"
        Me.MnuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.MnuUndo.Size = New System.Drawing.Size(147, 22)
        Me.MnuUndo.Text = "خنثی"
        '
        'MnuEdit
        '
        Me.MnuEdit.BackColor = System.Drawing.Color.White
        Me.MnuEdit.Image = CType(resources.GetObject("MnuEdit.Image"), System.Drawing.Image)
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.MnuEdit.Size = New System.Drawing.Size(147, 22)
        Me.MnuEdit.Text = "&تغیر"
        '
        'MnuDelete
        '
        Me.MnuDelete.BackColor = System.Drawing.Color.White
        Me.MnuDelete.Image = CType(resources.GetObject("MnuDelete.Image"), System.Drawing.Image)
        Me.MnuDelete.Name = "MnuDelete"
        Me.MnuDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuDelete.Size = New System.Drawing.Size(147, 22)
        Me.MnuDelete.Text = "&حذف"
        '
        'MnuExit
        '
        Me.MnuExit.BackColor = System.Drawing.Color.White
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MnuExit.Size = New System.Drawing.Size(147, 22)
        Me.MnuExit.Text = "&خروج"
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(23, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 45)
        Me.btnPrint.TabIndex = 254
        Me.btnPrint.Text = " پرنت"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(279, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(208, 34)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "صفحهٌ حواله یا آردر"
        '
        'TB1
        '
        Me.TB1.Controls.Add(Me.TP1)
        Me.TB1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB1.Location = New System.Drawing.Point(30, 67)
        Me.TB1.Name = "TB1"
        Me.TB1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TB1.RightToLeftLayout = True
        Me.TB1.SelectedIndex = 0
        Me.TB1.Size = New System.Drawing.Size(660, 483)
        Me.TB1.TabIndex = 27
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.cmbCompanySearch)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.cmbOrderNoSearch)
        Me.TP1.Controls.Add(Me.txtJobTilte)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.cmbOrderNo)
        Me.TP1.Controls.Add(Me.txtPersonName)
        Me.TP1.Controls.Add(Me.Panel2)
        Me.TP1.Controls.Add(Me.cmbVendorForOrderMain)
        Me.TP1.Controls.Add(Me.dtReqDate)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.Label24)
        Me.TP1.Controls.Add(Me.Label23)
        Me.TP1.Controls.Add(Me.Label22)
        Me.TP1.Controls.Add(Me.DG)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.txtRemarks)
        Me.TP1.Controls.Add(Me.Label11)
        Me.TP1.Controls.Add(Me.dtOrderDate)
        Me.TP1.ForeColor = System.Drawing.Color.White
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(652, 457)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "بخش معلومات اساسی"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(211, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 18)
        Me.Label3.TabIndex = 279
        Me.Label3.Text = "کمپنی"
        '
        'cmbCompanySearch
        '
        Me.cmbCompanySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCompanySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCompanySearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCompanySearch.FormattingEnabled = True
        Me.cmbCompanySearch.Location = New System.Drawing.Point(27, 20)
        Me.cmbCompanySearch.Name = "cmbCompanySearch"
        Me.cmbCompanySearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCompanySearch.Size = New System.Drawing.Size(148, 21)
        Me.cmbCompanySearch.TabIndex = 280
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(177, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 18)
        Me.Label2.TabIndex = 277
        Me.Label2.Text = " حواله (آردر) "
        '
        'cmbOrderNoSearch
        '
        Me.cmbOrderNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOrderNoSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrderNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbOrderNoSearch.FormattingEnabled = True
        Me.cmbOrderNoSearch.Location = New System.Drawing.Point(27, 45)
        Me.cmbOrderNoSearch.Name = "cmbOrderNoSearch"
        Me.cmbOrderNoSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbOrderNoSearch.Size = New System.Drawing.Size(148, 21)
        Me.cmbOrderNoSearch.TabIndex = 278
        '
        'txtJobTilte
        '
        Me.txtJobTilte.Location = New System.Drawing.Point(27, 112)
        Me.txtJobTilte.Multiline = True
        Me.txtJobTilte.Name = "txtJobTilte"
        Me.txtJobTilte.ReadOnly = True
        Me.txtJobTilte.Size = New System.Drawing.Size(478, 25)
        Me.txtJobTilte.TabIndex = 276
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(590, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 275
        Me.Label1.Text = "شغل"
        '
        'cmbOrderNo
        '
        Me.cmbOrderNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOrderNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrderNo.Enabled = False
        Me.cmbOrderNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbOrderNo.FormattingEnabled = True
        Me.cmbOrderNo.Location = New System.Drawing.Point(281, 10)
        Me.cmbOrderNo.Name = "cmbOrderNo"
        Me.cmbOrderNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbOrderNo.Size = New System.Drawing.Size(224, 21)
        Me.cmbOrderNo.TabIndex = 274
        '
        'txtPersonName
        '
        Me.txtPersonName.Location = New System.Drawing.Point(281, 59)
        Me.txtPersonName.Multiline = True
        Me.txtPersonName.Name = "txtPersonName"
        Me.txtPersonName.ReadOnly = True
        Me.txtPersonName.Size = New System.Drawing.Size(224, 52)
        Me.txtPersonName.TabIndex = 273
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblMessage)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 178)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(646, 34)
        Me.Panel2.TabIndex = 271
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(255, 9)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(25, 22)
        Me.lblMessage.TabIndex = 288
        Me.lblMessage.Text = "..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton5, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 12)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(643, 23)
        Me.ToolStrip1.TabIndex = 245
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(59, 20)
        Me.ToolStripButton2.Text = "نخست"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(53, 20)
        Me.ToolStripButton5.Text = "نهایی"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(52, 20)
        Me.ToolStripButton3.Text = "بعدی"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(51, 20)
        Me.ToolStripButton4.Text = "قبلی"
        '
        'cmbVendorForOrderMain
        '
        Me.cmbVendorForOrderMain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendorForOrderMain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendorForOrderMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendorForOrderMain.Enabled = False
        Me.cmbVendorForOrderMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbVendorForOrderMain.FormattingEnabled = True
        Me.cmbVendorForOrderMain.Location = New System.Drawing.Point(281, 35)
        Me.cmbVendorForOrderMain.Name = "cmbVendorForOrderMain"
        Me.cmbVendorForOrderMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbVendorForOrderMain.Size = New System.Drawing.Size(224, 21)
        Me.cmbVendorForOrderMain.TabIndex = 266
        '
        'dtReqDate
        '
        Me.dtReqDate.CustomFormat = "dd/MM/yy"
        Me.dtReqDate.Enabled = False
        Me.dtReqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtReqDate.Location = New System.Drawing.Point(27, 92)
        Me.dtReqDate.Name = "dtReqDate"
        Me.dtReqDate.Size = New System.Drawing.Size(148, 21)
        Me.dtReqDate.TabIndex = 264
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(521, 11)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(114, 16)
        Me.Label25.TabIndex = 263
        Me.Label25.Text = "شمارهُ حواله (آردر) "
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(184, 93)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(95, 16)
        Me.Label24.TabIndex = 262
        Me.Label24.Text = "تاریخ نیاز (لازم) "
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(211, 71)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 16)
        Me.Label23.TabIndex = 261
        Me.Label23.Text = "تاریخ حواله"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(513, 60)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 16)
        Me.Label22.TabIndex = 260
        Me.Label22.Text = "مدیر مسئعول کمپنی"
        '
        'DG
        '
        Me.DG.AllowUserToResizeColumns = False
        Me.DG.AllowUserToResizeRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSNo, Me.DGcmbPType, Me.DGcmbProdName, Me.DGQty, Me.DGDescription, Me.DGProductID})
        Me.DG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DG.Location = New System.Drawing.Point(3, 212)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DG.RowHeadersVisible = False
        Me.DG.Size = New System.Drawing.Size(646, 242)
        Me.DG.TabIndex = 258
        '
        'DGSNo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGSNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGSNo.HeaderText = "شماره"
        Me.DGSNo.Name = "DGSNo"
        Me.DGSNo.ReadOnly = True
        Me.DGSNo.Width = 60
        '
        'DGcmbPType
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGcmbPType.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGcmbPType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGcmbPType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DGcmbPType.HeaderText = "نوع محصول"
        Me.DGcmbPType.Name = "DGcmbPType"
        Me.DGcmbPType.ReadOnly = True
        Me.DGcmbPType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGcmbPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGcmbPType.Width = 150
        '
        'DGcmbProdName
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DGcmbProdName.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGcmbProdName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGcmbProdName.HeaderText = "اسم محصول"
        Me.DGcmbProdName.Name = "DGcmbProdName"
        Me.DGcmbProdName.ReadOnly = True
        Me.DGcmbProdName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGcmbProdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGcmbProdName.Width = 150
        '
        'DGQty
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DGQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGQty.HeaderText = "مقدار"
        Me.DGQty.Name = "DGQty"
        Me.DGQty.ReadOnly = True
        Me.DGQty.Width = 60
        '
        'DGDescription
        '
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.DGDescription.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGDescription.HeaderText = "تفصیل"
        Me.DGDescription.Name = "DGDescription"
        Me.DGDescription.ReadOnly = True
        Me.DGDescription.Width = 250
        '
        'DGProductID
        '
        Me.DGProductID.HeaderText = "ProductID"
        Me.DGProductID.Name = "DGProductID"
        Me.DGProductID.ReadOnly = True
        Me.DGProductID.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(590, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 16)
        Me.Label6.TabIndex = 252
        Me.Label6.Text = "کمپنی"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Location = New System.Drawing.Point(27, 137)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ReadOnly = True
        Me.txtRemarks.Size = New System.Drawing.Size(478, 39)
        Me.txtRemarks.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(586, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "ملاحظات"
        '
        'dtOrderDate
        '
        Me.dtOrderDate.CustomFormat = "dd/MM/yy"
        Me.dtOrderDate.Enabled = False
        Me.dtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtOrderDate.Location = New System.Drawing.Point(27, 69)
        Me.dtOrderDate.Name = "dtOrderDate"
        Me.dtOrderDate.Size = New System.Drawing.Size(148, 21)
        Me.dtOrderDate.TabIndex = 3
        '
        'FrmOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(760, 604)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.pnlcentre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmOrder"
        Me.pnlcentre.ResumeLayout(False)
        Me.pnlcentre.PerformLayout()
        Me.CM.ResumeLayout(False)
        Me.TB1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlcentre As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TB1 As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbVendorForOrderMain As System.Windows.Forms.ComboBox
    Friend WithEvents dtReqDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPersonName As System.Windows.Forms.TextBox
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cmbOrderNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtJobTilte As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGcmbPType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGcmbProdName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOrderNoSearch As System.Windows.Forms.ComboBox
    Friend WithEvents MnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCompanySearch As System.Windows.Forms.ComboBox
End Class

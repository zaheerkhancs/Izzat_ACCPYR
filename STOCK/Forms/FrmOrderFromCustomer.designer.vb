<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrderFromCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrderFromCustomer))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlcentre = New System.Windows.Forms.Panel
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TB1 = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.cmbCustomerTypeSearch = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCustomerNameSearch = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbOrderNoSearch = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LVStockViewer = New System.Windows.Forms.ListView
        Me.CProductName = New System.Windows.Forms.ColumnHeader
        Me.CRemainQty = New System.Windows.Forms.ColumnHeader
        Me.lblLocation = New System.Windows.Forms.Label
        Me.cmbLocation = New System.Windows.Forms.ComboBox
        Me.lblShop = New System.Windows.Forms.Label
        Me.cmbShop = New System.Windows.Forms.ComboBox
        Me.btnPromptCustomerForm = New System.Windows.Forms.Button
        Me.txtOrderNo = New System.Windows.Forms.TextBox
        Me.cmbCustomerName = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
        Me.cmbCustomerType = New System.Windows.Forms.ComboBox
        Me.dtReqDate = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPType = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGProductCode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGColProductID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGCrtnPcs = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGProdTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtOrderDate = New System.Windows.Forms.DateTimePicker
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlcentre.SuspendLayout()
        Me.TB1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlcentre
        '
        Me.pnlcentre.Controls.Add(Me.btnPrint)
        Me.pnlcentre.Controls.Add(Me.Label14)
        Me.pnlcentre.Controls.Add(Me.TB1)
        Me.pnlcentre.Location = New System.Drawing.Point(27, 16)
        Me.pnlcentre.Name = "pnlcentre"
        Me.pnlcentre.Size = New System.Drawing.Size(747, 561)
        Me.pnlcentre.TabIndex = 0
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
        Me.Label14.Location = New System.Drawing.Point(202, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(286, 34)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "صفحهٌ حواله یا آردر مشتری"
        '
        'TB1
        '
        Me.TB1.Controls.Add(Me.TP1)
        Me.TB1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB1.Location = New System.Drawing.Point(23, 54)
        Me.TB1.Name = "TB1"
        Me.TB1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TB1.RightToLeftLayout = True
        Me.TB1.SelectedIndex = 0
        Me.TB1.Size = New System.Drawing.Size(700, 502)
        Me.TB1.TabIndex = 29
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.cmbCustomerTypeSearch)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.cmbCustomerNameSearch)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.cmbOrderNoSearch)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.LVStockViewer)
        Me.TP1.Controls.Add(Me.lblLocation)
        Me.TP1.Controls.Add(Me.cmbLocation)
        Me.TP1.Controls.Add(Me.lblShop)
        Me.TP1.Controls.Add(Me.cmbShop)
        Me.TP1.Controls.Add(Me.btnPromptCustomerForm)
        Me.TP1.Controls.Add(Me.txtOrderNo)
        Me.TP1.Controls.Add(Me.cmbCustomerName)
        Me.TP1.Controls.Add(Me.Panel2)
        Me.TP1.Controls.Add(Me.cmbCustomerType)
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
        Me.TP1.Size = New System.Drawing.Size(692, 476)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "بخش معلومات اساسی"
        '
        'cmbCustomerTypeSearch
        '
        Me.cmbCustomerTypeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomerTypeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomerTypeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCustomerTypeSearch.FormattingEnabled = True
        Me.cmbCustomerTypeSearch.Location = New System.Drawing.Point(47, 7)
        Me.cmbCustomerTypeSearch.Name = "cmbCustomerTypeSearch"
        Me.cmbCustomerTypeSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCustomerTypeSearch.Size = New System.Drawing.Size(198, 21)
        Me.cmbCustomerTypeSearch.TabIndex = 311
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(277, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 310
        Me.Label3.Text = "نوع مشتری"
        '
        'cmbCustomerNameSearch
        '
        Me.cmbCustomerNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomerNameSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomerNameSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCustomerNameSearch.FormattingEnabled = True
        Me.cmbCustomerNameSearch.Location = New System.Drawing.Point(47, 33)
        Me.cmbCustomerNameSearch.Name = "cmbCustomerNameSearch"
        Me.cmbCustomerNameSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCustomerNameSearch.Size = New System.Drawing.Size(198, 21)
        Me.cmbCustomerNameSearch.TabIndex = 309
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(270, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 308
        Me.Label1.Text = "اسم مشتری"
        '
        'cmbOrderNoSearch
        '
        Me.cmbOrderNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOrderNoSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrderNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbOrderNoSearch.FormattingEnabled = True
        Me.cmbOrderNoSearch.Location = New System.Drawing.Point(47, 59)
        Me.cmbOrderNoSearch.Name = "cmbOrderNoSearch"
        Me.cmbOrderNoSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbOrderNoSearch.Size = New System.Drawing.Size(198, 21)
        Me.cmbOrderNoSearch.TabIndex = 307
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(270, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 18)
        Me.Label2.TabIndex = 306
        Me.Label2.Text = " حواله (آردر) "
        '
        'LVStockViewer
        '
        Me.LVStockViewer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CProductName, Me.CRemainQty})
        Me.LVStockViewer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVStockViewer.GridLines = True
        Me.LVStockViewer.Location = New System.Drawing.Point(120, 387)
        Me.LVStockViewer.Name = "LVStockViewer"
        Me.LVStockViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LVStockViewer.RightToLeftLayout = True
        Me.LVStockViewer.Size = New System.Drawing.Size(458, 82)
        Me.LVStockViewer.TabIndex = 304
        Me.LVStockViewer.UseCompatibleStateImageBehavior = False
        Me.LVStockViewer.View = System.Windows.Forms.View.Details
        '
        'CProductName
        '
        Me.CProductName.Text = "اسم محصول"
        Me.CProductName.Width = 189
        '
        'CRemainQty
        '
        Me.CRemainQty.Text = "باقی مانده در انبار"
        Me.CRemainQty.Width = 241
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblLocation.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.White
        Me.lblLocation.Location = New System.Drawing.Point(634, 93)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(43, 16)
        Me.lblLocation.TabIndex = 303
        Me.lblLocation.Text = "موقیت"
        '
        'cmbLocation
        '
        Me.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbLocation.Enabled = False
        Me.cmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(380, 93)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(198, 20)
        Me.cmbLocation.TabIndex = 302
        '
        'lblShop
        '
        Me.lblShop.AutoSize = True
        Me.lblShop.BackColor = System.Drawing.Color.Transparent
        Me.lblShop.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblShop.ForeColor = System.Drawing.Color.White
        Me.lblShop.Location = New System.Drawing.Point(639, 123)
        Me.lblShop.Name = "lblShop"
        Me.lblShop.Size = New System.Drawing.Size(38, 16)
        Me.lblShop.TabIndex = 301
        Me.lblShop.Text = "دوکان"
        '
        'cmbShop
        '
        Me.cmbShop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbShop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbShop.Enabled = False
        Me.cmbShop.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbShop.FormattingEnabled = True
        Me.cmbShop.Location = New System.Drawing.Point(380, 123)
        Me.cmbShop.Name = "cmbShop"
        Me.cmbShop.Size = New System.Drawing.Size(198, 21)
        Me.cmbShop.TabIndex = 300
        '
        'btnPromptCustomerForm
        '
        Me.btnPromptCustomerForm.BackColor = System.Drawing.Color.Transparent
        Me.btnPromptCustomerForm.Enabled = False
        Me.btnPromptCustomerForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPromptCustomerForm.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPromptCustomerForm.ForeColor = System.Drawing.Color.White
        Me.btnPromptCustomerForm.Location = New System.Drawing.Point(2, 74)
        Me.btnPromptCustomerForm.Name = "btnPromptCustomerForm"
        Me.btnPromptCustomerForm.Size = New System.Drawing.Size(44, 22)
        Me.btnPromptCustomerForm.TabIndex = 274
        Me.btnPromptCustomerForm.Text = "جدید"
        Me.btnPromptCustomerForm.UseVisualStyleBackColor = False
        Me.btnPromptCustomerForm.Visible = False
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Enabled = False
        Me.txtOrderNo.Location = New System.Drawing.Point(47, 84)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(198, 21)
        Me.txtOrderNo.TabIndex = 273
        '
        'cmbCustomerName
        '
        Me.cmbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomerName.Enabled = False
        Me.cmbCustomerName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCustomerName.FormattingEnabled = True
        Me.cmbCustomerName.Location = New System.Drawing.Point(380, 62)
        Me.cmbCustomerName.Name = "cmbCustomerName"
        Me.cmbCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCustomerName.Size = New System.Drawing.Size(198, 21)
        Me.cmbCustomerName.TabIndex = 272
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblMessage)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Location = New System.Drawing.Point(3, 205)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(686, 39)
        Me.Panel2.TabIndex = 271
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(248, 13)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(19, 14)
        Me.lblMessage.TabIndex = 285
        Me.lblMessage.Text = "..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSFirst, Me.TSPrevious, Me.TSLast, Me.TSNext})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 8)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(686, 23)
        Me.ToolStrip1.TabIndex = 283
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSFirst
        '
        Me.TSFirst.ForeColor = System.Drawing.Color.White
        Me.TSFirst.Image = CType(resources.GetObject("TSFirst.Image"), System.Drawing.Image)
        Me.TSFirst.Name = "TSFirst"
        Me.TSFirst.RightToLeftAutoMirrorImage = True
        Me.TSFirst.Size = New System.Drawing.Size(59, 20)
        Me.TSFirst.Text = "نخست"
        '
        'TSPrevious
        '
        Me.TSPrevious.ForeColor = System.Drawing.Color.White
        Me.TSPrevious.Image = CType(resources.GetObject("TSPrevious.Image"), System.Drawing.Image)
        Me.TSPrevious.Name = "TSPrevious"
        Me.TSPrevious.RightToLeftAutoMirrorImage = True
        Me.TSPrevious.Size = New System.Drawing.Size(51, 20)
        Me.TSPrevious.Text = "قبلی"
        '
        'TSLast
        '
        Me.TSLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSLast.ForeColor = System.Drawing.Color.White
        Me.TSLast.Image = CType(resources.GetObject("TSLast.Image"), System.Drawing.Image)
        Me.TSLast.Name = "TSLast"
        Me.TSLast.RightToLeftAutoMirrorImage = True
        Me.TSLast.Size = New System.Drawing.Size(53, 20)
        Me.TSLast.Text = "نهایی"
        '
        'TSNext
        '
        Me.TSNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSNext.ForeColor = System.Drawing.Color.White
        Me.TSNext.Image = CType(resources.GetObject("TSNext.Image"), System.Drawing.Image)
        Me.TSNext.Name = "TSNext"
        Me.TSNext.RightToLeftAutoMirrorImage = True
        Me.TSNext.Size = New System.Drawing.Size(52, 20)
        Me.TSNext.Text = "بعدی"
        '
        'cmbCustomerType
        '
        Me.cmbCustomerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomerType.Enabled = False
        Me.cmbCustomerType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCustomerType.FormattingEnabled = True
        Me.cmbCustomerType.Items.AddRange(New Object() {"نمایندگی ولایات", "فروشنده سیار ", "عمومی", ""})
        Me.cmbCustomerType.Location = New System.Drawing.Point(380, 29)
        Me.cmbCustomerType.Name = "cmbCustomerType"
        Me.cmbCustomerType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCustomerType.Size = New System.Drawing.Size(198, 21)
        Me.cmbCustomerType.TabIndex = 266
        '
        'dtReqDate
        '
        Me.dtReqDate.CustomFormat = "dd/MM/yy"
        Me.dtReqDate.Enabled = False
        Me.dtReqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtReqDate.Location = New System.Drawing.Point(47, 129)
        Me.dtReqDate.Name = "dtReqDate"
        Me.dtReqDate.Size = New System.Drawing.Size(198, 21)
        Me.dtReqDate.TabIndex = 264
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(251, 86)
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
        Me.Label24.Location = New System.Drawing.Point(288, 132)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 16)
        Me.Label24.TabIndex = 262
        Me.Label24.Text = "تاریخ ضرورت"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(295, 109)
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
        Me.Label22.Location = New System.Drawing.Point(598, 66)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 16)
        Me.Label22.TabIndex = 260
        Me.Label22.Text = "اسم مشتری"
        '
        'DG
        '
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSNo, Me.DGPType, Me.DGProductCode, Me.DGProductName, Me.DGColProductID, Me.DGCrtnPcs, Me.DGQty, Me.DGDesc, Me.DGProdTypeID})
        Me.DG.Location = New System.Drawing.Point(3, 245)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersVisible = False
        Me.DG.Size = New System.Drawing.Size(686, 140)
        Me.DG.TabIndex = 258
        '
        'DGSNo
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DGSNo.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGSNo.HeaderText = "شماره"
        Me.DGSNo.Name = "DGSNo"
        Me.DGSNo.ReadOnly = True
        Me.DGSNo.Width = 40
        '
        'DGPType
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGPType.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGPType.HeaderText = "نوع محصول"
        Me.DGPType.Name = "DGPType"
        Me.DGPType.ReadOnly = True
        Me.DGPType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGPType.Width = 150
        '
        'DGProductCode
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGProductCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGProductCode.HeaderText = "لست انتخاب"
        Me.DGProductCode.Name = "DGProductCode"
        Me.DGProductCode.ReadOnly = True
        Me.DGProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGProductCode.Visible = False
        Me.DGProductCode.Width = 200
        '
        'DGProductName
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DGProductName.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGProductName.HeaderText = "اسم محصول"
        Me.DGProductName.Name = "DGProductName"
        Me.DGProductName.ReadOnly = True
        Me.DGProductName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGProductName.Width = 200
        '
        'DGColProductID
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DGColProductID.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGColProductID.HeaderText = "کود محصول"
        Me.DGColProductID.Name = "DGColProductID"
        Me.DGColProductID.ReadOnly = True
        Me.DGColProductID.Visible = False
        '
        'DGCrtnPcs
        '
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.DGCrtnPcs.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGCrtnPcs.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DGCrtnPcs.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DGCrtnPcs.HeaderText = "کارتن / دانه"
        Me.DGCrtnPcs.Name = "DGCrtnPcs"
        Me.DGCrtnPcs.ReadOnly = True
        Me.DGCrtnPcs.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCrtnPcs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DGQty
        '
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.DGQty.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGQty.HeaderText = "مقدار"
        Me.DGQty.Name = "DGQty"
        Me.DGQty.ReadOnly = True
        Me.DGQty.Width = 60
        '
        'DGDesc
        '
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.DGDesc.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGDesc.HeaderText = "تفصیل"
        Me.DGDesc.Name = "DGDesc"
        Me.DGDesc.ReadOnly = True
        Me.DGDesc.Width = 210
        '
        'DGProdTypeID
        '
        Me.DGProdTypeID.HeaderText = "Column1"
        Me.DGProdTypeID.Name = "DGProdTypeID"
        Me.DGProdTypeID.ReadOnly = True
        Me.DGProdTypeID.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(605, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 252
        Me.Label6.Text = "نوع مشتری"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Enabled = False
        Me.txtRemarks.Location = New System.Drawing.Point(47, 149)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(531, 53)
        Me.txtRemarks.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(628, 156)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "ملاحظه"
        '
        'dtOrderDate
        '
        Me.dtOrderDate.CustomFormat = "dd/MM/yy"
        Me.dtOrderDate.Enabled = False
        Me.dtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtOrderDate.Location = New System.Drawing.Point(47, 107)
        Me.dtOrderDate.Name = "dtOrderDate"
        Me.dtOrderDate.Size = New System.Drawing.Size(198, 21)
        Me.dtOrderDate.TabIndex = 3
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
        'FrmOrderFromCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(803, 675)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.pnlcentre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmOrderFromCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmOrderFromCustomer"
        Me.pnlcentre.ResumeLayout(False)
        Me.pnlcentre.PerformLayout()
        Me.TB1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlcentre As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TB1 As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbCustomerType As System.Windows.Forms.ComboBox
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
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents cmbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPromptCustomerForm As System.Windows.Forms.Button
    Friend WithEvents lblShop As System.Windows.Forms.Label
    Friend WithEvents cmbShop As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents LVStockViewer As System.Windows.Forms.ListView
    Friend WithEvents CProductName As System.Windows.Forms.ColumnHeader
    Friend WithEvents CRemainQty As System.Windows.Forms.ColumnHeader
    Friend WithEvents DGSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGProductCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGColProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGCrtnPcs As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGProdTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbOrderNoSearch As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCustomerNameSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomerTypeSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class

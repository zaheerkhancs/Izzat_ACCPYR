<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSale
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSale))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.TB1 = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbCustomerTypeSearch = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbCustomerNameSearch = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbInvoiceNoSearch = New System.Windows.Forms.ComboBox
        Me.lblLocation = New System.Windows.Forms.Label
        Me.cmbLocation = New System.Windows.Forms.ComboBox
        Me.lblShop = New System.Windows.Forms.Label
        Me.cmbShop = New System.Windows.Forms.ComboBox
        Me.txtTotalToPayWithoutDiscount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDiscount = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTExpForGrid = New System.Windows.Forms.DateTimePicker
        Me.DTManForGrid = New System.Windows.Forms.DateTimePicker
        Me.txtTotalPaid = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnPayment = New System.Windows.Forms.Button
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPType = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGProductCode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGPcsInCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPricePerPcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPricePerCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGCrtnPcs = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGBtnTransfer = New System.Windows.Forms.DataGridViewButtonColumn
        Me.DGDeliveredQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGRemainingQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDesciption = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGManDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGExpDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbCustomerName = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
        Me.cmbOrderNo = New System.Windows.Forms.ComboBox
        Me.cmbCustomerType = New System.Windows.Forms.ComboBox
        Me.txtTotalToPay = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtInvoice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBalance = New System.Windows.Forms.TextBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtSaleDate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.pnlcentre = New System.Windows.Forms.Panel
        Me.CM.SuspendLayout()
        Me.TB1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlcentre.SuspendLayout()
        Me.SuspendLayout()
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSearch, Me.MnuReturn, Me.MnuNew, Me.MnuSave, Me.MnuEdit, Me.MnuUndo, Me.MnuDelete, Me.MnuExit})
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
        'MnuEdit
        '
        Me.MnuEdit.BackColor = System.Drawing.Color.White
        Me.MnuEdit.Image = CType(resources.GetObject("MnuEdit.Image"), System.Drawing.Image)
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.MnuEdit.Size = New System.Drawing.Size(147, 22)
        Me.MnuEdit.Text = "&تغیر"
        Me.MnuEdit.Visible = False
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
        'TB1
        '
        Me.TB1.Controls.Add(Me.TP1)
        Me.TB1.Location = New System.Drawing.Point(19, 44)
        Me.TB1.Name = "TB1"
        Me.TB1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TB1.RightToLeftLayout = True
        Me.TB1.SelectedIndex = 0
        Me.TB1.Size = New System.Drawing.Size(679, 496)
        Me.TB1.TabIndex = 27
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.Label13)
        Me.TP1.Controls.Add(Me.cmbCustomerTypeSearch)
        Me.TP1.Controls.Add(Me.Label12)
        Me.TP1.Controls.Add(Me.cmbCustomerNameSearch)
        Me.TP1.Controls.Add(Me.Label10)
        Me.TP1.Controls.Add(Me.cmbInvoiceNoSearch)
        Me.TP1.Controls.Add(Me.lblLocation)
        Me.TP1.Controls.Add(Me.cmbLocation)
        Me.TP1.Controls.Add(Me.lblShop)
        Me.TP1.Controls.Add(Me.cmbShop)
        Me.TP1.Controls.Add(Me.txtTotalToPayWithoutDiscount)
        Me.TP1.Controls.Add(Me.Label9)
        Me.TP1.Controls.Add(Me.txtDiscount)
        Me.TP1.Controls.Add(Me.Label8)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.DTExpForGrid)
        Me.TP1.Controls.Add(Me.DTManForGrid)
        Me.TP1.Controls.Add(Me.txtTotalPaid)
        Me.TP1.Controls.Add(Me.Label7)
        Me.TP1.Controls.Add(Me.btnPayment)
        Me.TP1.Controls.Add(Me.DG)
        Me.TP1.Controls.Add(Me.cmbCustomerName)
        Me.TP1.Controls.Add(Me.Panel2)
        Me.TP1.Controls.Add(Me.cmbOrderNo)
        Me.TP1.Controls.Add(Me.cmbCustomerType)
        Me.TP1.Controls.Add(Me.txtTotalToPay)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.Label23)
        Me.TP1.Controls.Add(Me.Label22)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.txtInvoice)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.txtBalance)
        Me.TP1.Controls.Add(Me.txtRemarks)
        Me.TP1.Controls.Add(Me.Label11)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.dtSaleDate)
        Me.TP1.ForeColor = System.Drawing.Color.White
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(671, 470)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "بخش معلومات اساسی"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Yellow
        Me.Label13.Location = New System.Drawing.Point(582, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 18)
        Me.Label13.TabIndex = 313
        Me.Label13.Text = "نوع مشتری"
        '
        'cmbCustomerTypeSearch
        '
        Me.cmbCustomerTypeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomerTypeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomerTypeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCustomerTypeSearch.FormattingEnabled = True
        Me.cmbCustomerTypeSearch.Location = New System.Drawing.Point(364, 13)
        Me.cmbCustomerTypeSearch.Name = "cmbCustomerTypeSearch"
        Me.cmbCustomerTypeSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCustomerTypeSearch.Size = New System.Drawing.Size(195, 21)
        Me.cmbCustomerTypeSearch.TabIndex = 312
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(574, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 18)
        Me.Label12.TabIndex = 311
        Me.Label12.Text = "اسم مشتری"
        '
        'cmbCustomerNameSearch
        '
        Me.cmbCustomerNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomerNameSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomerNameSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCustomerNameSearch.FormattingEnabled = True
        Me.cmbCustomerNameSearch.Location = New System.Drawing.Point(364, 38)
        Me.cmbCustomerNameSearch.Name = "cmbCustomerNameSearch"
        Me.cmbCustomerNameSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCustomerNameSearch.Size = New System.Drawing.Size(195, 21)
        Me.cmbCustomerNameSearch.TabIndex = 310
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(566, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 18)
        Me.Label10.TabIndex = 309
        Me.Label10.Text = "شمارهُ انوایس"
        '
        'cmbInvoiceNoSearch
        '
        Me.cmbInvoiceNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInvoiceNoSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInvoiceNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbInvoiceNoSearch.FormattingEnabled = True
        Me.cmbInvoiceNoSearch.Location = New System.Drawing.Point(364, 62)
        Me.cmbInvoiceNoSearch.Name = "cmbInvoiceNoSearch"
        Me.cmbInvoiceNoSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbInvoiceNoSearch.Size = New System.Drawing.Size(195, 21)
        Me.cmbInvoiceNoSearch.TabIndex = 308
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblLocation.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.White
        Me.lblLocation.Location = New System.Drawing.Point(629, 153)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(43, 16)
        Me.lblLocation.TabIndex = 307
        Me.lblLocation.Text = "موقیت"
        '
        'cmbLocation
        '
        Me.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbLocation.Enabled = False
        Me.cmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(364, 150)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(195, 21)
        Me.cmbLocation.TabIndex = 306
        '
        'lblShop
        '
        Me.lblShop.AutoSize = True
        Me.lblShop.BackColor = System.Drawing.Color.Transparent
        Me.lblShop.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblShop.ForeColor = System.Drawing.Color.White
        Me.lblShop.Location = New System.Drawing.Point(634, 175)
        Me.lblShop.Name = "lblShop"
        Me.lblShop.Size = New System.Drawing.Size(38, 16)
        Me.lblShop.TabIndex = 305
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
        Me.cmbShop.Location = New System.Drawing.Point(364, 172)
        Me.cmbShop.Name = "cmbShop"
        Me.cmbShop.Size = New System.Drawing.Size(195, 21)
        Me.cmbShop.TabIndex = 304
        '
        'txtTotalToPayWithoutDiscount
        '
        Me.txtTotalToPayWithoutDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalToPayWithoutDiscount.Location = New System.Drawing.Point(16, 60)
        Me.txtTotalToPayWithoutDiscount.Name = "txtTotalToPayWithoutDiscount"
        Me.txtTotalToPayWithoutDiscount.ReadOnly = True
        Me.txtTotalToPayWithoutDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalToPayWithoutDiscount.Size = New System.Drawing.Size(198, 20)
        Me.txtTotalToPayWithoutDiscount.TabIndex = 284
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(224, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 16)
        Me.Label9.TabIndex = 283
        Me.Label9.Text = "مقدار پول بیدون تخفیف"
        '
        'txtDiscount
        '
        Me.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscount.Location = New System.Drawing.Point(16, 88)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.ReadOnly = True
        Me.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDiscount.Size = New System.Drawing.Size(198, 20)
        Me.txtDiscount.TabIndex = 282
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(313, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 16)
        Me.Label8.TabIndex = 281
        Me.Label8.Text = "تخفیف"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(288, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "تاریخ انقضاء"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(295, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "تاریخ تولید"
        '
        'DTExpForGrid
        '
        Me.DTExpForGrid.CustomFormat = "dd/MM/yyyy"
        Me.DTExpForGrid.Enabled = False
        Me.DTExpForGrid.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTExpForGrid.Location = New System.Drawing.Point(16, 256)
        Me.DTExpForGrid.Name = "DTExpForGrid"
        Me.DTExpForGrid.Size = New System.Drawing.Size(159, 20)
        Me.DTExpForGrid.TabIndex = 278
        '
        'DTManForGrid
        '
        Me.DTManForGrid.CustomFormat = "dd/MM/yyyy"
        Me.DTManForGrid.Enabled = False
        Me.DTManForGrid.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTManForGrid.Location = New System.Drawing.Point(16, 233)
        Me.DTManForGrid.Name = "DTManForGrid"
        Me.DTManForGrid.Size = New System.Drawing.Size(159, 20)
        Me.DTManForGrid.TabIndex = 29
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPaid.Location = New System.Drawing.Point(76, 145)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.ReadOnly = True
        Me.txtTotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalPaid.Size = New System.Drawing.Size(138, 20)
        Me.txtTotalPaid.TabIndex = 277
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(219, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 16)
        Me.Label7.TabIndex = 276
        Me.Label7.Text = "مقدار پول پذرداخته شده"
        '
        'btnPayment
        '
        Me.btnPayment.Enabled = False
        Me.btnPayment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPayment.ForeColor = System.Drawing.Color.Black
        Me.btnPayment.Location = New System.Drawing.Point(16, 138)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(60, 33)
        Me.btnPayment.TabIndex = 275
        Me.btnPayment.Text = "پرداخت"
        Me.btnPayment.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSno, Me.DGPType, Me.DGProductCode, Me.DGPcsInCrtn, Me.DGPricePerPcs, Me.DGPricePerCrtn, Me.DGCrtnPcs, Me.DGQty, Me.DGBtnTransfer, Me.DGDeliveredQty, Me.DGRemainingQty, Me.DGPrice, Me.DGDesciption, Me.DGManDate, Me.DGExpDate})
        Me.DG.Location = New System.Drawing.Point(16, 281)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.Size = New System.Drawing.Size(637, 149)
        Me.DG.TabIndex = 274
        '
        'DGSno
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGSno.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGSno.HeaderText = "شماره"
        Me.DGSno.Name = "DGSno"
        Me.DGSno.ReadOnly = True
        Me.DGSno.Width = 60
        '
        'DGPType
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGPType.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGPType.HeaderText = "نوع محصول"
        Me.DGPType.Name = "DGPType"
        Me.DGPType.ReadOnly = True
        Me.DGPType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGPType.Width = 150
        '
        'DGProductCode
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DGProductCode.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGProductCode.HeaderText = "اسم محصول"
        Me.DGProductCode.Name = "DGProductCode"
        Me.DGProductCode.ReadOnly = True
        Me.DGProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGProductCode.Width = 150
        '
        'DGPcsInCrtn
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DGPcsInCrtn.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGPcsInCrtn.HeaderText = "تعداد در فی کارتن"
        Me.DGPcsInCrtn.Name = "DGPcsInCrtn"
        Me.DGPcsInCrtn.ReadOnly = True
        '
        'DGPricePerPcs
        '
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DGPricePerPcs.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGPricePerPcs.HeaderText = "قیمت فی دانه"
        Me.DGPricePerPcs.Name = "DGPricePerPcs"
        Me.DGPricePerPcs.ReadOnly = True
        '
        'DGPricePerCrtn
        '
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DGPricePerCrtn.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGPricePerCrtn.HeaderText = "قیمت فی کارتن"
        Me.DGPricePerCrtn.Name = "DGPricePerCrtn"
        Me.DGPricePerCrtn.ReadOnly = True
        '
        'DGCrtnPcs
        '
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.DGCrtnPcs.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGCrtnPcs.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGCrtnPcs.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DGCrtnPcs.HeaderText = "دانه / کارتن"
        Me.DGCrtnPcs.Name = "DGCrtnPcs"
        Me.DGCrtnPcs.ReadOnly = True
        Me.DGCrtnPcs.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCrtnPcs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DGQty
        '
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.DGQty.DefaultCellStyle = DataGridViewCellStyle9
        Me.DGQty.HeaderText = "مقدار"
        Me.DGQty.Name = "DGQty"
        Me.DGQty.ReadOnly = True
        '
        'DGBtnTransfer
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Red
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.DGBtnTransfer.DefaultCellStyle = DataGridViewCellStyle10
        Me.DGBtnTransfer.HeaderText = "انتقال"
        Me.DGBtnTransfer.Name = "DGBtnTransfer"
        Me.DGBtnTransfer.ReadOnly = True
        Me.DGBtnTransfer.Text = "a"
        Me.DGBtnTransfer.Width = 60
        '
        'DGDeliveredQty
        '
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        Me.DGDeliveredQty.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGDeliveredQty.HeaderText = "انتقال یافته"
        Me.DGDeliveredQty.Name = "DGDeliveredQty"
        Me.DGDeliveredQty.ReadOnly = True
        '
        'DGRemainingQty
        '
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.DGRemainingQty.DefaultCellStyle = DataGridViewCellStyle12
        Me.DGRemainingQty.HeaderText = "باقی مانده"
        Me.DGRemainingQty.Name = "DGRemainingQty"
        Me.DGRemainingQty.ReadOnly = True
        '
        'DGPrice
        '
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.DGPrice.DefaultCellStyle = DataGridViewCellStyle13
        Me.DGPrice.HeaderText = "قیمت"
        Me.DGPrice.Name = "DGPrice"
        Me.DGPrice.ReadOnly = True
        '
        'DGDesciption
        '
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.DGDesciption.DefaultCellStyle = DataGridViewCellStyle14
        Me.DGDesciption.HeaderText = "تفصیل"
        Me.DGDesciption.Name = "DGDesciption"
        Me.DGDesciption.ReadOnly = True
        Me.DGDesciption.Width = 250
        '
        'DGManDate
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.Format = "dd/MM/yyyy"
        DataGridViewCellStyle15.NullValue = "01/01/1900"
        Me.DGManDate.DefaultCellStyle = DataGridViewCellStyle15
        Me.DGManDate.HeaderText = "تاریخ تولید"
        Me.DGManDate.Name = "DGManDate"
        Me.DGManDate.ReadOnly = True
        '
        'DGExpDate
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.Format = "dd/MM/yyyy"
        DataGridViewCellStyle16.NullValue = "01/01/1900"
        Me.DGExpDate.DefaultCellStyle = DataGridViewCellStyle16
        Me.DGExpDate.HeaderText = "تاریخ انقضاء"
        Me.DGExpDate.Name = "DGExpDate"
        Me.DGExpDate.ReadOnly = True
        '
        'cmbCustomerName
        '
        Me.cmbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbCustomerName.Enabled = False
        Me.cmbCustomerName.FormattingEnabled = True
        Me.cmbCustomerName.Location = New System.Drawing.Point(364, 128)
        Me.cmbCustomerName.Name = "cmbCustomerName"
        Me.cmbCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCustomerName.Size = New System.Drawing.Size(195, 21)
        Me.cmbCustomerName.TabIndex = 273
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblMessage)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 435)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(665, 32)
        Me.Panel2.TabIndex = 268
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(235, 5)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(19, 14)
        Me.lblMessage.TabIndex = 287
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
        Me.ToolStrip1.Location = New System.Drawing.Point(31, 5)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(603, 23)
        Me.ToolStrip1.TabIndex = 286
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
        'cmbOrderNo
        '
        Me.cmbOrderNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOrderNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrderNo.Enabled = False
        Me.cmbOrderNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbOrderNo.FormattingEnabled = True
        Me.cmbOrderNo.Location = New System.Drawing.Point(16, 30)
        Me.cmbOrderNo.Name = "cmbOrderNo"
        Me.cmbOrderNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbOrderNo.Size = New System.Drawing.Size(197, 21)
        Me.cmbOrderNo.TabIndex = 267
        '
        'cmbCustomerType
        '
        Me.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbCustomerType.Enabled = False
        Me.cmbCustomerType.FormattingEnabled = True
        Me.cmbCustomerType.Items.AddRange(New Object() {"نمایندگی ولایات", "فروشنده سیار ", "عمومی"})
        Me.cmbCustomerType.Location = New System.Drawing.Point(364, 106)
        Me.cmbCustomerType.Name = "cmbCustomerType"
        Me.cmbCustomerType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCustomerType.Size = New System.Drawing.Size(195, 21)
        Me.cmbCustomerType.TabIndex = 266
        '
        'txtTotalToPay
        '
        Me.txtTotalToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalToPay.Location = New System.Drawing.Point(16, 115)
        Me.txtTotalToPay.Name = "txtTotalToPay"
        Me.txtTotalToPay.ReadOnly = True
        Me.txtTotalToPay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalToPay.Size = New System.Drawing.Size(198, 20)
        Me.txtTotalToPay.TabIndex = 265
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(244, 35)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(114, 16)
        Me.Label25.TabIndex = 263
        Me.Label25.Text = "شمارهُ حواله (آردر) "
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(603, 237)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 16)
        Me.Label23.TabIndex = 261
        Me.Label23.Text = "تاریخ فروش"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(593, 130)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 16)
        Me.Label22.TabIndex = 260
        Me.Label22.Text = "اسم مشتری"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(600, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 252
        Me.Label6.Text = "نوع مشتری"
        '
        'txtInvoice
        '
        Me.txtInvoice.BackColor = System.Drawing.Color.White
        Me.txtInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoice.Enabled = False
        Me.txtInvoice.Location = New System.Drawing.Point(364, 85)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(195, 20)
        Me.txtInvoice.TabIndex = 251
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(577, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "شمارهُ (انوایس)"
        '
        'txtBalance
        '
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance.Enabled = False
        Me.txtBalance.Location = New System.Drawing.Point(16, 173)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBalance.Size = New System.Drawing.Size(198, 20)
        Me.txtBalance.TabIndex = 246
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Enabled = False
        Me.txtRemarks.Location = New System.Drawing.Point(16, 195)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(543, 36)
        Me.txtRemarks.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(615, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "ملاحظات"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(244, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "مقدار پول قابل تادیه"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(321, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "میزان"
        '
        'dtSaleDate
        '
        Me.dtSaleDate.CustomFormat = "dd/MM/yyyy"
        Me.dtSaleDate.Enabled = False
        Me.dtSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtSaleDate.Location = New System.Drawing.Point(367, 238)
        Me.dtSaleDate.Name = "dtSaleDate"
        Me.dtSaleDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtSaleDate.Size = New System.Drawing.Size(192, 20)
        Me.dtSaleDate.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(279, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(160, 34)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "صفحه فروشات"
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
        'pnlcentre
        '
        Me.pnlcentre.Controls.Add(Me.btnPrint)
        Me.pnlcentre.Controls.Add(Me.Label14)
        Me.pnlcentre.Controls.Add(Me.TB1)
        Me.pnlcentre.Location = New System.Drawing.Point(27, 30)
        Me.pnlcentre.Name = "pnlcentre"
        Me.pnlcentre.Size = New System.Drawing.Size(717, 559)
        Me.pnlcentre.TabIndex = 0
        '
        'FrmSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(804, 700)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.pnlcentre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSale"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSale"
        Me.CM.ResumeLayout(False)
        Me.TB1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlcentre.ResumeLayout(False)
        Me.pnlcentre.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TB1 As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTExpForGrid As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTManForGrid As System.Windows.Forms.DateTimePicker
    Public WithEvents txtTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents cmbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbOrderNo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCustomerType As System.Windows.Forms.ComboBox
    Public WithEvents txtTotalToPay As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtSaleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents pnlcentre As System.Windows.Forms.Panel
    Friend WithEvents DGSno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGProductCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGPcsInCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPricePerPcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPricePerCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGCrtnPcs As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGBtnTransfer As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DGDeliveredQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGRemainingQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDesciption As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGManDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGExpDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents txtTotalToPayWithoutDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents lblShop As System.Windows.Forms.Label
    Friend WithEvents cmbShop As System.Windows.Forms.ComboBox
    Friend WithEvents cmbInvoiceNoSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomerTypeSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomerNameSearch As System.Windows.Forms.ComboBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Saraaf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Saraaf))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TC = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.lblMessage = New System.Windows.Forms.Label
        Me.GBFEx = New System.Windows.Forms.GroupBox
        Me.LLCurrencyTypeList = New System.Windows.Forms.LinkLabel
        Me.btnAddNewFX = New System.Windows.Forms.Button
        Me.btnCancelFX = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAmountInFX = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtFXchangeRate = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbCurrencyType = New System.Windows.Forms.ComboBox
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtBalance = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.RBReceive = New System.Windows.Forms.RadioButton
        Me.RBPayment = New System.Windows.Forms.RadioButton
        Me.txtConcernName = New System.Windows.Forms.TextBox
        Me.cmbMoneyExchanger = New System.Windows.Forms.ComboBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.TP2 = New System.Windows.Forms.TabPage
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSearchTotalBalance = New System.Windows.Forms.TextBox
        Me.txtSearchTotalWithdraw = New System.Windows.Forms.TextBox
        Me.txtSearchTotalPaid = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DGSearch = New System.Windows.Forms.DataGridView
        Me.DGSearchWithdrawFromSaraaf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSearchGivenToSaraaf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSearchTabadula = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSearchAmountInFEx = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSearchCurrType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSearchDesciption = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSearchDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSearchCPName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSearchName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBSearch = New System.Windows.Forms.GroupBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkbxSaraafname = New System.Windows.Forms.CheckBox
        Me.cmbMoneyExchangerSearch = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.TC.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBFEx.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TP2.SuspendLayout()
        CType(Me.DGSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBSearch.SuspendLayout()
        Me.CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TP1)
        Me.TC.Controls.Add(Me.TP2)
        Me.TC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TC.Location = New System.Drawing.Point(23, 94)
        Me.TC.Name = "TC"
        Me.TC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TC.RightToLeftLayout = True
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(661, 433)
        Me.TC.TabIndex = 4
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.lblMessage)
        Me.TP1.Controls.Add(Me.GBFEx)
        Me.TP1.Controls.Add(Me.txtAmount)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.txtBalance)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.RBReceive)
        Me.TP1.Controls.Add(Me.RBPayment)
        Me.TP1.Controls.Add(Me.txtConcernName)
        Me.TP1.Controls.Add(Me.cmbMoneyExchanger)
        Me.TP1.Controls.Add(Me.ToolStrip1)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.Label9)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.dtDate)
        Me.TP1.Controls.Add(Me.txtRemarks)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(653, 407)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "معلومات صراف "
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(230, 350)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(25, 22)
        Me.lblMessage.TabIndex = 316
        Me.lblMessage.Text = "..."
        '
        'GBFEx
        '
        Me.GBFEx.Controls.Add(Me.LLCurrencyTypeList)
        Me.GBFEx.Controls.Add(Me.btnAddNewFX)
        Me.GBFEx.Controls.Add(Me.btnCancelFX)
        Me.GBFEx.Controls.Add(Me.Label16)
        Me.GBFEx.Controls.Add(Me.txtAmountInFX)
        Me.GBFEx.Controls.Add(Me.Label15)
        Me.GBFEx.Controls.Add(Me.txtFXchangeRate)
        Me.GBFEx.Controls.Add(Me.Label14)
        Me.GBFEx.Controls.Add(Me.cmbCurrencyType)
        Me.GBFEx.Enabled = False
        Me.GBFEx.ForeColor = System.Drawing.Color.White
        Me.GBFEx.Location = New System.Drawing.Point(161, 16)
        Me.GBFEx.Name = "GBFEx"
        Me.GBFEx.Size = New System.Drawing.Size(398, 125)
        Me.GBFEx.TabIndex = 315
        Me.GBFEx.TabStop = False
        Me.GBFEx.Text = "اسعار"
        '
        'LLCurrencyTypeList
        '
        Me.LLCurrencyTypeList.ActiveLinkColor = System.Drawing.Color.Lime
        Me.LLCurrencyTypeList.AutoSize = True
        Me.LLCurrencyTypeList.LinkColor = System.Drawing.Color.White
        Me.LLCurrencyTypeList.Location = New System.Drawing.Point(11, 28)
        Me.LLCurrencyTypeList.Name = "LLCurrencyTypeList"
        Me.LLCurrencyTypeList.Size = New System.Drawing.Size(32, 13)
        Me.LLCurrencyTypeList.TabIndex = 8
        Me.LLCurrencyTypeList.TabStop = True
        Me.LLCurrencyTypeList.Text = "لست"
        '
        'btnAddNewFX
        '
        Me.btnAddNewFX.BackColor = System.Drawing.Color.Transparent
        Me.btnAddNewFX.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddNewFX.ForeColor = System.Drawing.Color.White
        Me.btnAddNewFX.Location = New System.Drawing.Point(118, 25)
        Me.btnAddNewFX.Name = "btnAddNewFX"
        Me.btnAddNewFX.Size = New System.Drawing.Size(44, 22)
        Me.btnAddNewFX.TabIndex = 6
        Me.btnAddNewFX.Text = "جدید"
        Me.btnAddNewFX.UseVisualStyleBackColor = False
        '
        'btnCancelFX
        '
        Me.btnCancelFX.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelFX.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelFX.ForeColor = System.Drawing.Color.White
        Me.btnCancelFX.Location = New System.Drawing.Point(59, 25)
        Me.btnCancelFX.Name = "btnCancelFX"
        Me.btnCancelFX.Size = New System.Drawing.Size(53, 22)
        Me.btnCancelFX.TabIndex = 7
        Me.btnCancelFX.Text = "فسخ"
        Me.btnCancelFX.UseVisualStyleBackColor = False
        Me.btnCancelFX.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(340, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 13)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "مقدار پول"
        '
        'txtAmountInFX
        '
        Me.txtAmountInFX.Location = New System.Drawing.Point(176, 78)
        Me.txtAmountInFX.Name = "txtAmountInFX"
        Me.txtAmountInFX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAmountInFX.Size = New System.Drawing.Size(145, 21)
        Me.txtAmountInFX.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(324, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "معال به کلدار"
        '
        'txtFXchangeRate
        '
        Me.txtFXchangeRate.Location = New System.Drawing.Point(176, 51)
        Me.txtFXchangeRate.Name = "txtFXchangeRate"
        Me.txtFXchangeRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFXchangeRate.Size = New System.Drawing.Size(145, 21)
        Me.txtFXchangeRate.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(350, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "نوع پول"
        '
        'cmbCurrencyType
        '
        Me.cmbCurrencyType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCurrencyType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCurrencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurrencyType.FormattingEnabled = True
        Me.cmbCurrencyType.Location = New System.Drawing.Point(177, 24)
        Me.cmbCurrencyType.Name = "cmbCurrencyType"
        Me.cmbCurrencyType.Size = New System.Drawing.Size(144, 21)
        Me.cmbCurrencyType.TabIndex = 0
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Enabled = False
        Me.txtAmount.Location = New System.Drawing.Point(241, 265)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAmount.Size = New System.Drawing.Size(214, 21)
        Me.txtAmount.TabIndex = 314
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(526, 268)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 313
        Me.Label6.Text = "مقدار "
        '
        'txtBalance
        '
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance.Enabled = False
        Me.txtBalance.Location = New System.Drawing.Point(241, 218)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBalance.Size = New System.Drawing.Size(214, 21)
        Me.txtBalance.TabIndex = 312
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(457, 219)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 311
        Me.Label5.Text = "مقدار موجورد با صراف"
        '
        'RBReceive
        '
        Me.RBReceive.AutoSize = True
        Me.RBReceive.Enabled = False
        Me.RBReceive.ForeColor = System.Drawing.Color.White
        Me.RBReceive.Location = New System.Drawing.Point(305, 242)
        Me.RBReceive.Name = "RBReceive"
        Me.RBReceive.Size = New System.Drawing.Size(51, 17)
        Me.RBReceive.TabIndex = 310
        Me.RBReceive.TabStop = True
        Me.RBReceive.Text = "وصول"
        Me.RBReceive.UseVisualStyleBackColor = True
        '
        'RBPayment
        '
        Me.RBPayment.AutoSize = True
        Me.RBPayment.Enabled = False
        Me.RBPayment.ForeColor = System.Drawing.Color.White
        Me.RBPayment.Location = New System.Drawing.Point(378, 242)
        Me.RBPayment.Name = "RBPayment"
        Me.RBPayment.Size = New System.Drawing.Size(58, 17)
        Me.RBPayment.TabIndex = 309
        Me.RBPayment.TabStop = True
        Me.RBPayment.Text = "پرداخت"
        Me.RBPayment.UseVisualStyleBackColor = True
        '
        'txtConcernName
        '
        Me.txtConcernName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConcernName.Enabled = False
        Me.txtConcernName.Location = New System.Drawing.Point(241, 191)
        Me.txtConcernName.Name = "txtConcernName"
        Me.txtConcernName.ReadOnly = True
        Me.txtConcernName.Size = New System.Drawing.Size(214, 21)
        Me.txtConcernName.TabIndex = 308
        '
        'cmbMoneyExchanger
        '
        Me.cmbMoneyExchanger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMoneyExchanger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMoneyExchanger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneyExchanger.Enabled = False
        Me.cmbMoneyExchanger.FormattingEnabled = True
        Me.cmbMoneyExchanger.Location = New System.Drawing.Point(241, 164)
        Me.cmbMoneyExchanger.Name = "cmbMoneyExchanger"
        Me.cmbMoneyExchanger.Size = New System.Drawing.Size(214, 21)
        Me.cmbMoneyExchanger.TabIndex = 307
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSFirst, Me.TSPrevious, Me.TSLast, Me.TSNext})
        Me.ToolStrip1.Location = New System.Drawing.Point(8, 353)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(572, 23)
        Me.ToolStrip1.TabIndex = 306
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(461, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "اسم شخص مسئول"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(525, 294)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "تفصیل"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(497, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "اسم صرافی"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(128, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "تاریخ"
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "dd/MM/yyyy"
        Me.dtDate.Enabled = False
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(31, 17)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(92, 21)
        Me.dtDate.TabIndex = 0
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Enabled = False
        Me.txtRemarks.Location = New System.Drawing.Point(161, 292)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(294, 55)
        Me.txtRemarks.TabIndex = 6
        '
        'TP2
        '
        Me.TP2.BackColor = System.Drawing.Color.Teal
        Me.TP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP2.Controls.Add(Me.Label13)
        Me.TP2.Controls.Add(Me.txtSearchTotalBalance)
        Me.TP2.Controls.Add(Me.txtSearchTotalWithdraw)
        Me.TP2.Controls.Add(Me.txtSearchTotalPaid)
        Me.TP2.Controls.Add(Me.Label10)
        Me.TP2.Controls.Add(Me.Label8)
        Me.TP2.Controls.Add(Me.DGSearch)
        Me.TP2.Controls.Add(Me.GBSearch)
        Me.TP2.Location = New System.Drawing.Point(4, 22)
        Me.TP2.Name = "TP2"
        Me.TP2.Size = New System.Drawing.Size(653, 407)
        Me.TP2.TabIndex = 1
        Me.TP2.Text = "جستجو"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(183, 377)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 318
        Me.Label13.Text = "میزان"
        '
        'txtSearchTotalBalance
        '
        Me.txtSearchTotalBalance.Location = New System.Drawing.Point(5, 373)
        Me.txtSearchTotalBalance.Name = "txtSearchTotalBalance"
        Me.txtSearchTotalBalance.ReadOnly = True
        Me.txtSearchTotalBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearchTotalBalance.Size = New System.Drawing.Size(172, 21)
        Me.txtSearchTotalBalance.TabIndex = 317
        '
        'txtSearchTotalWithdraw
        '
        Me.txtSearchTotalWithdraw.Location = New System.Drawing.Point(286, 375)
        Me.txtSearchTotalWithdraw.Name = "txtSearchTotalWithdraw"
        Me.txtSearchTotalWithdraw.ReadOnly = True
        Me.txtSearchTotalWithdraw.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearchTotalWithdraw.Size = New System.Drawing.Size(172, 21)
        Me.txtSearchTotalWithdraw.TabIndex = 316
        '
        'txtSearchTotalPaid
        '
        Me.txtSearchTotalPaid.Location = New System.Drawing.Point(286, 346)
        Me.txtSearchTotalPaid.Name = "txtSearchTotalPaid"
        Me.txtSearchTotalPaid.ReadOnly = True
        Me.txtSearchTotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearchTotalPaid.Size = New System.Drawing.Size(172, 21)
        Me.txtSearchTotalPaid.TabIndex = 315
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(481, 375)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 314
        Me.Label10.Text = "سرجم وصول شده"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(476, 351)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 313
        Me.Label8.Text = "سرجم پرداخته شده"
        '
        'DGSearch
        '
        Me.DGSearch.AllowUserToAddRows = False
        Me.DGSearch.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSearchWithdrawFromSaraaf, Me.DGSearchGivenToSaraaf, Me.DGSearchTabadula, Me.DGSearchAmountInFEx, Me.DGSearchCurrType, Me.DGSearchDesciption, Me.DGSearchDate, Me.DGSearchCPName, Me.DGSearchName})
        Me.DGSearch.Location = New System.Drawing.Point(0, 77)
        Me.DGSearch.Name = "DGSearch"
        Me.DGSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DGSearch.RowHeadersVisible = False
        Me.DGSearch.Size = New System.Drawing.Size(651, 256)
        Me.DGSearch.TabIndex = 6
        '
        'DGSearchWithdrawFromSaraaf
        '
        Me.DGSearchWithdrawFromSaraaf.HeaderText = "وصول شده از صراف"
        Me.DGSearchWithdrawFromSaraaf.Name = "DGSearchWithdrawFromSaraaf"
        Me.DGSearchWithdrawFromSaraaf.ReadOnly = True
        Me.DGSearchWithdrawFromSaraaf.Width = 150
        '
        'DGSearchGivenToSaraaf
        '
        Me.DGSearchGivenToSaraaf.HeaderText = "پرداخته شده به صراف"
        Me.DGSearchGivenToSaraaf.Name = "DGSearchGivenToSaraaf"
        Me.DGSearchGivenToSaraaf.ReadOnly = True
        Me.DGSearchGivenToSaraaf.Width = 150
        '
        'DGSearchTabadula
        '
        Me.DGSearchTabadula.HeaderText = "تبادله"
        Me.DGSearchTabadula.Name = "DGSearchTabadula"
        Me.DGSearchTabadula.ReadOnly = True
        '
        'DGSearchAmountInFEx
        '
        Me.DGSearchAmountInFEx.HeaderText = "مقدار در پول خارجی"
        Me.DGSearchAmountInFEx.Name = "DGSearchAmountInFEx"
        Me.DGSearchAmountInFEx.ReadOnly = True
        '
        'DGSearchCurrType
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGSearchCurrType.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGSearchCurrType.HeaderText = "نوع پول"
        Me.DGSearchCurrType.Name = "DGSearchCurrType"
        Me.DGSearchCurrType.ReadOnly = True
        '
        'DGSearchDesciption
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DGSearchDesciption.DefaultCellStyle = DataGridViewCellStyle9
        Me.DGSearchDesciption.HeaderText = "تفصیل"
        Me.DGSearchDesciption.Name = "DGSearchDesciption"
        Me.DGSearchDesciption.ReadOnly = True
        '
        'DGSearchDate
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGSearchDate.DefaultCellStyle = DataGridViewCellStyle10
        Me.DGSearchDate.HeaderText = "تاریخ"
        Me.DGSearchDate.Name = "DGSearchDate"
        Me.DGSearchDate.ReadOnly = True
        '
        'DGSearchCPName
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DGSearchCPName.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGSearchCPName.HeaderText = "اسم مسئول"
        Me.DGSearchCPName.Name = "DGSearchCPName"
        Me.DGSearchCPName.ReadOnly = True
        Me.DGSearchCPName.Width = 150
        '
        'DGSearchName
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DGSearchName.DefaultCellStyle = DataGridViewCellStyle12
        Me.DGSearchName.HeaderText = "اسم صرافی"
        Me.DGSearchName.Name = "DGSearchName"
        Me.DGSearchName.ReadOnly = True
        Me.DGSearchName.Width = 150
        '
        'GBSearch
        '
        Me.GBSearch.Controls.Add(Me.btnPrint)
        Me.GBSearch.Controls.Add(Me.dtTo)
        Me.GBSearch.Controls.Add(Me.dtFrom)
        Me.GBSearch.Controls.Add(Me.Label7)
        Me.GBSearch.Controls.Add(Me.chkbxSaraafname)
        Me.GBSearch.Controls.Add(Me.cmbMoneyExchangerSearch)
        Me.GBSearch.Controls.Add(Me.btnSearch)
        Me.GBSearch.Controls.Add(Me.Label11)
        Me.GBSearch.Controls.Add(Me.Label12)
        Me.GBSearch.Location = New System.Drawing.Point(5, 3)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(646, 68)
        Me.GBSearch.TabIndex = 1
        Me.GBSearch.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(10, 13)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 45)
        Me.btnPrint.TabIndex = 313
        Me.btnPrint.Text = " پرنت"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'dtTo
        '
        Me.dtTo.CustomFormat = "dd/MM/yyyy"
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(200, 41)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(130, 21)
        Me.dtTo.TabIndex = 312
        '
        'dtFrom
        '
        Me.dtFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(405, 42)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(130, 21)
        Me.dtFrom.TabIndex = 311
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(349, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 310
        Me.Label7.Text = "تا تاریخ"
        '
        'chkbxSaraafname
        '
        Me.chkbxSaraafname.AutoSize = True
        Me.chkbxSaraafname.Location = New System.Drawing.Point(604, 18)
        Me.chkbxSaraafname.Name = "chkbxSaraafname"
        Me.chkbxSaraafname.Size = New System.Drawing.Size(15, 14)
        Me.chkbxSaraafname.TabIndex = 309
        Me.chkbxSaraafname.UseVisualStyleBackColor = True
        '
        'cmbMoneyExchangerSearch
        '
        Me.cmbMoneyExchangerSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMoneyExchangerSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMoneyExchangerSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneyExchangerSearch.Enabled = False
        Me.cmbMoneyExchangerSearch.FormattingEnabled = True
        Me.cmbMoneyExchangerSearch.Location = New System.Drawing.Point(333, 14)
        Me.cmbMoneyExchangerSearch.Name = "cmbMoneyExchangerSearch"
        Me.cmbMoneyExchangerSearch.Size = New System.Drawing.Size(201, 21)
        Me.cmbMoneyExchangerSearch.TabIndex = 308
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(199, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(579, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = " از تاریخ "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(539, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "اسم صرافی"
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuEdit, Me.MnuDelete, Me.MnuUndo, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(183, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(378, 56)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "  داد و گرفت با صراف"
        '
        'Saraaf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(729, 550)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Saraaf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saraaf"
        Me.TC.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.GBFEx.ResumeLayout(False)
        Me.GBFEx.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TP2.ResumeLayout(False)
        Me.TP2.PerformLayout()
        CType(Me.DGSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBSearch.ResumeLayout(False)
        Me.GBSearch.PerformLayout()
        Me.CM.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TC As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents TP2 As System.Windows.Forms.TabPage
    Friend WithEvents DGSearch As System.Windows.Forms.DataGridView
    Friend WithEvents GBSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneyExchanger As System.Windows.Forms.ComboBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RBReceive As System.Windows.Forms.RadioButton
    Friend WithEvents RBPayment As System.Windows.Forms.RadioButton
    Friend WithEvents txtConcernName As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkbxSaraafname As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMoneyExchangerSearch As System.Windows.Forms.ComboBox
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSearchTotalBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchTotalWithdraw As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GBFEx As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCurrencyType As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFXchangeRate As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAmountInFX As System.Windows.Forms.TextBox
    Friend WithEvents btnAddNewFX As System.Windows.Forms.Button
    Friend WithEvents btnCancelFX As System.Windows.Forms.Button
    Friend WithEvents LLCurrencyTypeList As System.Windows.Forms.LinkLabel
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents DGSearchWithdrawFromSaraaf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSearchGivenToSaraaf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSearchTabadula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSearchAmountInFEx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSearchCurrType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSearchDesciption As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSearchDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSearchCPName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSearchName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As System.Windows.Forms.Label
End Class

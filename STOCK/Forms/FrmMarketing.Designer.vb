<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMarketing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMarketing))
        Me.Label13 = New System.Windows.Forms.Label
        Me.GBEntry = New System.Windows.Forms.GroupBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbName = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DgMarketing = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ClientName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LOC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChbOrder = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.OrderType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Advance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ddate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GBSearch = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.chbSearch = New System.Windows.Forms.CheckBox
        Me.dtDateSearch = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbNameSearch = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GBEntry.SuspendLayout()
        CType(Me.DgMarketing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBSearch.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(252, 119)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(516, 44)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "MARKETING INFORMATION"
        '
        'GBEntry
        '
        Me.GBEntry.BackColor = System.Drawing.Color.Transparent
        Me.GBEntry.Controls.Add(Me.txtRemarks)
        Me.GBEntry.Controls.Add(Me.Label4)
        Me.GBEntry.Controls.Add(Me.cmbName)
        Me.GBEntry.Controls.Add(Me.Label3)
        Me.GBEntry.Controls.Add(Me.dtDate)
        Me.GBEntry.Controls.Add(Me.Label2)
        Me.GBEntry.Controls.Add(Me.txtID)
        Me.GBEntry.Controls.Add(Me.Label1)
        Me.GBEntry.ForeColor = System.Drawing.Color.Black
        Me.GBEntry.Location = New System.Drawing.Point(153, 187)
        Me.GBEntry.Name = "GBEntry"
        Me.GBEntry.Size = New System.Drawing.Size(377, 173)
        Me.GBEntry.TabIndex = 0
        Me.GBEntry.TabStop = False
        Me.GBEntry.Text = "Client Information"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(69, 99)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(293, 61)
        Me.txtRemarks.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Remarks :"
        '
        'cmbName
        '
        Me.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(69, 68)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(150, 21)
        Me.cmbName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Name :"
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "dd/MM/yyyy"
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(258, 25)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(104, 20)
        Me.dtDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Date :"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(69, 25)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(78, 20)
        Me.txtID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "ID :"
        '
        'DgMarketing
        '
        Me.DgMarketing.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.DgMarketing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DgMarketing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgMarketing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.ClientName, Me.Company, Me.LOC, Me.ChbOrder, Me.OrderType, Me.Quantity, Me.Price, Me.Amount, Me.Advance, Me.Balance, Me.ddate})
        Me.DgMarketing.Location = New System.Drawing.Point(153, 377)
        Me.DgMarketing.Name = "DgMarketing"
        Me.DgMarketing.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DgMarketing.Size = New System.Drawing.Size(709, 182)
        Me.DgMarketing.TabIndex = 1
        '
        'ID
        '
        Me.ID.Frozen = True
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'ClientName
        '
        Me.ClientName.Frozen = True
        Me.ClientName.HeaderText = "Client Name"
        Me.ClientName.Name = "ClientName"
        '
        'Company
        '
        Me.Company.Frozen = True
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        '
        'LOC
        '
        Me.LOC.HeaderText = "Location"
        Me.LOC.Name = "LOC"
        '
        'ChbOrder
        '
        Me.ChbOrder.HeaderText = "Order"
        Me.ChbOrder.Name = "ChbOrder"
        Me.ChbOrder.Width = 50
        '
        'OrderType
        '
        Me.OrderType.HeaderText = "Order Type"
        Me.OrderType.Name = "OrderType"
        Me.OrderType.ReadOnly = True
        Me.OrderType.Width = 195
        '
        'Quantity
        '
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 60
        '
        'Price
        '
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        Me.Price.Width = 80
        '
        'Amount
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle1
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        Me.Amount.Width = 80
        '
        'Advance
        '
        Me.Advance.HeaderText = "Advance"
        Me.Advance.Name = "Advance"
        Me.Advance.ReadOnly = True
        '
        'Balance
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Cyan
        Me.Balance.DefaultCellStyle = DataGridViewCellStyle2
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        '
        'ddate
        '
        Me.ddate.HeaderText = "Delivary Date"
        Me.ddate.Name = "ddate"
        Me.ddate.ReadOnly = True
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Location = New System.Drawing.Point(693, 590)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Location = New System.Drawing.Point(787, 590)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'GBSearch
        '
        Me.GBSearch.BackColor = System.Drawing.Color.Transparent
        Me.GBSearch.Controls.Add(Me.btnSearch)
        Me.GBSearch.Controls.Add(Me.chbSearch)
        Me.GBSearch.Controls.Add(Me.dtDateSearch)
        Me.GBSearch.Controls.Add(Me.Label6)
        Me.GBSearch.Controls.Add(Me.cmbNameSearch)
        Me.GBSearch.Controls.Add(Me.Label5)
        Me.GBSearch.ForeColor = System.Drawing.Color.Black
        Me.GBSearch.Location = New System.Drawing.Point(594, 187)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(267, 172)
        Me.GBSearch.TabIndex = 4
        Me.GBSearch.TabStop = False
        Me.GBSearch.Text = "Search"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.Enabled = False
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Location = New System.Drawing.Point(101, 127)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(66, 25)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'chbSearch
        '
        Me.chbSearch.AutoSize = True
        Me.chbSearch.Location = New System.Drawing.Point(23, 24)
        Me.chbSearch.Name = "chbSearch"
        Me.chbSearch.Size = New System.Drawing.Size(121, 17)
        Me.chbSearch.TabIndex = 0
        Me.chbSearch.Text = "Search For Records"
        Me.chbSearch.UseVisualStyleBackColor = True
        '
        'dtDateSearch
        '
        Me.dtDateSearch.CustomFormat = "dd/MM/yyyy"
        Me.dtDateSearch.Enabled = False
        Me.dtDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDateSearch.Location = New System.Drawing.Point(78, 94)
        Me.dtDateSearch.Name = "dtDateSearch"
        Me.dtDateSearch.Size = New System.Drawing.Size(150, 20)
        Me.dtDateSearch.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Date :"
        '
        'cmbNameSearch
        '
        Me.cmbNameSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNameSearch.Enabled = False
        Me.cmbNameSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbNameSearch.FormattingEnabled = True
        Me.cmbNameSearch.Location = New System.Drawing.Point(78, 60)
        Me.cmbNameSearch.Name = "cmbNameSearch"
        Me.cmbNameSearch.Size = New System.Drawing.Size(150, 21)
        Me.cmbNameSearch.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Name :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1025, 771)
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'FrmMarketing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.GBSearch)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.DgMarketing)
        Me.Controls.Add(Me.GBEntry)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMarketing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmMarketing"
        Me.GBEntry.ResumeLayout(False)
        Me.GBEntry.PerformLayout()
        CType(Me.DgMarketing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBSearch.ResumeLayout(False)
        Me.GBSearch.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GBEntry As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents DgMarketing As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GBSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents chbSearch As System.Windows.Forms.CheckBox
    Friend WithEvents dtDateSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbNameSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClientName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChbOrder As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OrderType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Advance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class

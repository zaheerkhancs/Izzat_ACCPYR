<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FlushDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FlushDatabase))
        Me.chkbxSelectAll = New System.Windows.Forms.CheckBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.btnClearTables = New System.Windows.Forms.Button
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGColChkBx = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DGSection = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGColTableName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGColOperation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.txtConfirmPinCode = New System.Windows.Forms.TextBox
        Me.txtPinCode = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblClose = New System.Windows.Forms.Label
        Me.RDAccounts = New System.Windows.Forms.RadioButton
        Me.RDStock = New System.Windows.Forms.RadioButton
        Me.RDHRM = New System.Windows.Forms.RadioButton
        Me.RDEmpty = New System.Windows.Forms.RadioButton
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkbxSelectAll
        '
        Me.chkbxSelectAll.AutoSize = True
        Me.chkbxSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.chkbxSelectAll.Location = New System.Drawing.Point(375, 137)
        Me.chkbxSelectAll.Name = "chkbxSelectAll"
        Me.chkbxSelectAll.Size = New System.Drawing.Size(80, 17)
        Me.chkbxSelectAll.TabIndex = 18
        Me.chkbxSelectAll.Text = "Select All"
        Me.chkbxSelectAll.UseVisualStyleBackColor = True
        Me.chkbxSelectAll.Visible = False
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Green
        Me.lblMsg.Location = New System.Drawing.Point(215, 9)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(361, 22)
        Me.lblMsg.TabIndex = 17
        Me.lblMsg.Text = "لطفآ جدول های را که میخواهید خالی گردند انتخاب نمایید"
        Me.lblMsg.Visible = False
        '
        'btnClearTables
        '
        Me.btnClearTables.Location = New System.Drawing.Point(474, 126)
        Me.btnClearTables.Name = "btnClearTables"
        Me.btnClearTables.Size = New System.Drawing.Size(80, 28)
        Me.btnClearTables.TabIndex = 16
        Me.btnClearTables.Text = "Clear Tables"
        Me.btnClearTables.UseVisualStyleBackColor = True
        Me.btnClearTables.Visible = False
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGColChkBx, Me.DGSection, Me.DGColTableName, Me.DGColOperation})
        Me.DG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DG.Location = New System.Drawing.Point(0, 216)
        Me.DG.Name = "DG"
        Me.DG.Size = New System.Drawing.Size(755, 387)
        Me.DG.TabIndex = 15
        Me.DG.Visible = False
        '
        'DGColChkBx
        '
        Me.DGColChkBx.Frozen = True
        Me.DGColChkBx.HeaderText = ""
        Me.DGColChkBx.Name = "DGColChkBx"
        Me.DGColChkBx.Width = 30
        '
        'DGSection
        '
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        Me.DGSection.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGSection.HeaderText = "Section"
        Me.DGSection.Name = "DGSection"
        Me.DGSection.ReadOnly = True
        '
        'DGColTableName
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGColTableName.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGColTableName.HeaderText = "Table Name"
        Me.DGColTableName.Name = "DGColTableName"
        Me.DGColTableName.ReadOnly = True
        Me.DGColTableName.Width = 300
        '
        'DGColOperation
        '
        Me.DGColOperation.HeaderText = "Operation"
        Me.DGColOperation.Name = "DGColOperation"
        Me.DGColOperation.ReadOnly = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(372, 97)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(90, 13)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Comfirm Pin Code"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(372, 67)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(50, 13)
        Me.label1.TabIndex = 13
        Me.label1.Text = "Pin Code"
        '
        'txtConfirmPinCode
        '
        Me.txtConfirmPinCode.Location = New System.Drawing.Point(474, 94)
        Me.txtConfirmPinCode.Name = "txtConfirmPinCode"
        Me.txtConfirmPinCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtConfirmPinCode.Size = New System.Drawing.Size(137, 20)
        Me.txtConfirmPinCode.TabIndex = 12
        '
        'txtPinCode
        '
        Me.txtPinCode.Location = New System.Drawing.Point(474, 64)
        Me.txtPinCode.Name = "txtPinCode"
        Me.txtPinCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtPinCode.Size = New System.Drawing.Size(137, 20)
        Me.txtPinCode.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(12, 60)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 84)
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.BackColor = System.Drawing.Color.Red
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(14, 44)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(33, 13)
        Me.lblClose.TabIndex = 20
        Me.lblClose.Text = "Close"
        '
        'RDAccounts
        '
        Me.RDAccounts.AutoSize = True
        Me.RDAccounts.Location = New System.Drawing.Point(120, 83)
        Me.RDAccounts.Name = "RDAccounts"
        Me.RDAccounts.Size = New System.Drawing.Size(70, 17)
        Me.RDAccounts.TabIndex = 21
        Me.RDAccounts.Text = "Accounts"
        Me.RDAccounts.UseVisualStyleBackColor = True
        '
        'RDStock
        '
        Me.RDStock.AutoSize = True
        Me.RDStock.Location = New System.Drawing.Point(120, 106)
        Me.RDStock.Name = "RDStock"
        Me.RDStock.Size = New System.Drawing.Size(53, 17)
        Me.RDStock.TabIndex = 22
        Me.RDStock.Text = "Stock"
        Me.RDStock.UseVisualStyleBackColor = True
        '
        'RDHRM
        '
        Me.RDHRM.AutoSize = True
        Me.RDHRM.Location = New System.Drawing.Point(120, 129)
        Me.RDHRM.Name = "RDHRM"
        Me.RDHRM.Size = New System.Drawing.Size(50, 17)
        Me.RDHRM.TabIndex = 23
        Me.RDHRM.Text = "HRM"
        Me.RDHRM.UseVisualStyleBackColor = True
        '
        'RDEmpty
        '
        Me.RDEmpty.AutoSize = True
        Me.RDEmpty.Checked = True
        Me.RDEmpty.Location = New System.Drawing.Point(120, 60)
        Me.RDEmpty.Name = "RDEmpty"
        Me.RDEmpty.Size = New System.Drawing.Size(232, 17)
        Me.RDEmpty.TabIndex = 24
        Me.RDEmpty.TabStop = True
        Me.RDEmpty.Text = "Please Select any section from the following"
        Me.RDEmpty.UseVisualStyleBackColor = True
        '
        'FlushDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(755, 603)
        Me.Controls.Add(Me.RDEmpty)
        Me.Controls.Add(Me.RDHRM)
        Me.Controls.Add(Me.RDStock)
        Me.Controls.Add(Me.RDAccounts)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.chkbxSelectAll)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnClearTables)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtConfirmPinCode)
        Me.Controls.Add(Me.txtPinCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FlushDatabase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FlushDatabase"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkbxSelectAll As System.Windows.Forms.CheckBox
    Private WithEvents lblMsg As System.Windows.Forms.Label
    Private WithEvents btnClearTables As System.Windows.Forms.Button
    Private WithEvents DG As System.Windows.Forms.DataGridView
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtConfirmPinCode As System.Windows.Forms.TextBox
    Private WithEvents txtPinCode As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents RDAccounts As System.Windows.Forms.RadioButton
    Friend WithEvents RDStock As System.Windows.Forms.RadioButton
    Friend WithEvents RDHRM As System.Windows.Forms.RadioButton
    Friend WithEvents RDEmpty As System.Windows.Forms.RadioButton
    Friend WithEvents DGColChkBx As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DGSection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGColTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGColOperation As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

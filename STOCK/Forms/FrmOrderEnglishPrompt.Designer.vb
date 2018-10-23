<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrderEnglishPrompt
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDecription = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG
        '
        Me.DG.AllowUserToResizeColumns = False
        Me.DG.AllowUserToResizeRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSNo, Me.DGPType, Me.DGProductName, Me.DGQty, Me.DGDecription})
        Me.DG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DG.Location = New System.Drawing.Point(0, -1)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DG.Size = New System.Drawing.Size(638, 242)
        Me.DG.TabIndex = 259
        '
        'DGSNo
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DGSNo.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGSNo.HeaderText = "SNO"
        Me.DGSNo.Name = "DGSNo"
        Me.DGSNo.ReadOnly = True
        Me.DGSNo.Width = 40
        '
        'DGPType
        '
        Me.DGPType.HeaderText = "Product Type"
        Me.DGPType.Name = "DGPType"
        Me.DGPType.ReadOnly = True
        '
        'DGProductName
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGProductName.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGProductName.HeaderText = "Product Name"
        Me.DGProductName.Name = "DGProductName"
        Me.DGProductName.ReadOnly = True
        Me.DGProductName.Width = 150
        '
        'DGQty
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGQty.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGQty.HeaderText = "Quantity"
        Me.DGQty.Name = "DGQty"
        Me.DGQty.ReadOnly = True
        '
        'DGDecription
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DGDecription.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGDecription.HeaderText = "Description"
        Me.DGDecription.Name = "DGDecription"
        Me.DGDecription.ReadOnly = True
        Me.DGDecription.Width = 250
        '
        'FrmOrderEnglishPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 241)
        Me.Controls.Add(Me.DG)
        Me.Name = "FrmOrderEnglishPrompt"
        Me.Text = "FrmOrderEnglishPrompt"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents DGSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDecription As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

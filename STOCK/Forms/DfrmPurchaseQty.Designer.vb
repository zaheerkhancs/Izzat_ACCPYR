<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DfrmPurchaseQty
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
        Me.btnPay = New System.Windows.Forms.Button
        Me.DGTransfer = New System.Windows.Forms.DataGridView
        Me.DGDiagSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDiagAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDiagDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtTransferredQty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtRemainingQty = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtQtyTransferredDate = New System.Windows.Forms.DateTimePicker
        Me.txtProdName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtProdType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotalQty = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.DGTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPay
        '
        Me.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPay.ForeColor = System.Drawing.Color.White
        Me.btnPay.Location = New System.Drawing.Point(17, 310)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(370, 23)
        Me.btnPay.TabIndex = 289
        Me.btnPay.Text = "انتقال"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'DGTransfer
        '
        Me.DGTransfer.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTransfer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTransfer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGDiagSNo, Me.DGDiagAmount, Me.DGDiagDate})
        Me.DGTransfer.Location = New System.Drawing.Point(0, 107)
        Me.DGTransfer.Name = "DGTransfer"
        Me.DGTransfer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGTransfer.Size = New System.Drawing.Size(405, 194)
        Me.DGTransfer.TabIndex = 280
        '
        'DGDiagSNo
        '
        Me.DGDiagSNo.HeaderText = "شماره"
        Me.DGDiagSNo.Name = "DGDiagSNo"
        Me.DGDiagSNo.ReadOnly = True
        Me.DGDiagSNo.Width = 60
        '
        'DGDiagAmount
        '
        Me.DGDiagAmount.HeaderText = "مقدار"
        Me.DGDiagAmount.Name = "DGDiagAmount"
        Me.DGDiagAmount.Width = 150
        '
        'DGDiagDate
        '
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        Me.DGDiagDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGDiagDate.HeaderText = "تاریخ"
        Me.DGDiagDate.Name = "DGDiagDate"
        Me.DGDiagDate.ReadOnly = True
        Me.DGDiagDate.Width = 150
        '
        'txtTransferredQty
        '
        Me.txtTransferredQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransferredQty.Location = New System.Drawing.Point(14, 54)
        Me.txtTransferredQty.Name = "txtTransferredQty"
        Me.txtTransferredQty.ReadOnly = True
        Me.txtTransferredQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTransferredQty.Size = New System.Drawing.Size(95, 21)
        Me.txtTransferredQty.TabIndex = 306
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(112, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 16)
        Me.Label3.TabIndex = 305
        Me.Label3.Text = "مقدار انتقال یافته"
        '
        'txtRemainingQty
        '
        Me.txtRemainingQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemainingQty.Enabled = False
        Me.txtRemainingQty.Location = New System.Drawing.Point(14, 75)
        Me.txtRemainingQty.Name = "txtRemainingQty"
        Me.txtRemainingQty.ReadOnly = True
        Me.txtRemainingQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRemainingQty.Size = New System.Drawing.Size(95, 21)
        Me.txtRemainingQty.TabIndex = 304
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(123, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 303
        Me.Label4.Text = "مقدار باقیمانده"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(317, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 302
        Me.Label2.Text = "تاریخ پرانتقال"
        '
        'dtQtyTransferredDate
        '
        Me.dtQtyTransferredDate.CustomFormat = "dd/MM/yy"
        Me.dtQtyTransferredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtQtyTransferredDate.Location = New System.Drawing.Point(217, 76)
        Me.dtQtyTransferredDate.Name = "dtQtyTransferredDate"
        Me.dtQtyTransferredDate.Size = New System.Drawing.Size(89, 21)
        Me.dtQtyTransferredDate.TabIndex = 301
        '
        'txtProdName
        '
        Me.txtProdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProdName.Location = New System.Drawing.Point(14, 33)
        Me.txtProdName.Name = "txtProdName"
        Me.txtProdName.ReadOnly = True
        Me.txtProdName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtProdName.Size = New System.Drawing.Size(292, 21)
        Me.txtProdName.TabIndex = 300
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(317, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 299
        Me.Label5.Text = "اسم محصول"
        '
        'txtProdType
        '
        Me.txtProdType.BackColor = System.Drawing.Color.White
        Me.txtProdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProdType.Enabled = False
        Me.txtProdType.Location = New System.Drawing.Point(14, 12)
        Me.txtProdType.Name = "txtProdType"
        Me.txtProdType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtProdType.Size = New System.Drawing.Size(292, 21)
        Me.txtProdType.TabIndex = 298
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(324, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 297
        Me.Label1.Text = "نوع محصول"
        '
        'txtTotalQty
        '
        Me.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQty.Enabled = False
        Me.txtTotalQty.Location = New System.Drawing.Point(217, 54)
        Me.txtTotalQty.Name = "txtTotalQty"
        Me.txtTotalQty.ReadOnly = True
        Me.txtTotalQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalQty.Size = New System.Drawing.Size(89, 21)
        Me.txtTotalQty.TabIndex = 296
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(317, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 295
        Me.Label7.Text = "مقدار سرجم"
        '
        'DfrmPurchaseQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(405, 343)
        Me.Controls.Add(Me.txtTransferredQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRemainingQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtQtyTransferredDate)
        Me.Controls.Add(Me.txtProdName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProdType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalQty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.DGTransfer)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DfrmPurchaseQty"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DfrmPurchaseQty"
        CType(Me.DGTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPay As System.Windows.Forms.Button
    Friend WithEvents DGTransfer As System.Windows.Forms.DataGridView
    Friend WithEvents DGDiagSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDiagAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDiagDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents txtTransferredQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txtRemainingQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtQtyTransferredDate As System.Windows.Forms.DateTimePicker
    Public WithEvents txtProdName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents txtProdType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtTotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DfrmPurchasePayment
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
        Me.txtTotalToPay = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtInvoice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotalPaid = New System.Windows.Forms.TextBox
        Me.txtBalance = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DGDiag = New System.Windows.Forms.DataGridView
        Me.DGDiagSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDiagAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDiagDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnPay = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.dtPayment = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DGDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTotalToPay
        '
        Me.txtTotalToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalToPay.Location = New System.Drawing.Point(12, 30)
        Me.txtTotalToPay.Name = "txtTotalToPay"
        Me.txtTotalToPay.ReadOnly = True
        Me.txtTotalToPay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalToPay.Size = New System.Drawing.Size(192, 21)
        Me.txtTotalToPay.TabIndex = 275
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(275, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 16)
        Me.Label5.TabIndex = 274
        Me.Label5.Text = "مقدار پول قابل تادیه"
        '
        'txtInvoice
        '
        Me.txtInvoice.BackColor = System.Drawing.Color.White
        Me.txtInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoice.Enabled = False
        Me.txtInvoice.Location = New System.Drawing.Point(12, 5)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(192, 21)
        Me.txtInvoice.TabIndex = 273
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(271, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 16)
        Me.Label1.TabIndex = 272
        Me.Label1.Text = "شمارهُ درج (انوایس)"
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPaid.Enabled = False
        Me.txtTotalPaid.Location = New System.Drawing.Point(12, 56)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.ReadOnly = True
        Me.txtTotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalPaid.Size = New System.Drawing.Size(192, 21)
        Me.txtTotalPaid.TabIndex = 271
        '
        'txtBalance
        '
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance.Enabled = False
        Me.txtBalance.Location = New System.Drawing.Point(12, 82)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBalance.Size = New System.Drawing.Size(192, 21)
        Me.txtBalance.TabIndex = 270
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(250, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 16)
        Me.Label7.TabIndex = 269
        Me.Label7.Text = "مقدار پول پذرداخته شده"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(352, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 268
        Me.Label4.Text = "میزان"
        '
        'DGDiag
        '
        Me.DGDiag.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGDiag.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGDiag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDiag.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGDiagSNo, Me.DGDiagAmount, Me.DGDiagDate})
        Me.DGDiag.Location = New System.Drawing.Point(0, 147)
        Me.DGDiag.Name = "DGDiag"
        Me.DGDiag.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGDiag.Size = New System.Drawing.Size(405, 198)
        Me.DGDiag.TabIndex = 267
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
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        Me.DGDiagDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGDiagDate.HeaderText = "تاریخ"
        Me.DGDiagDate.Name = "DGDiagDate"
        Me.DGDiagDate.ReadOnly = True
        Me.DGDiagDate.Width = 150
        '
        'btnPay
        '
        Me.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPay.ForeColor = System.Drawing.Color.White
        Me.btnPay.Location = New System.Drawing.Point(232, 351)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(161, 23)
        Me.btnPay.TabIndex = 276
        Me.btnPay.Text = "پرداخت"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(12, 351)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(161, 23)
        Me.btnCancel.TabIndex = 277
        Me.btnCancel.Text = "خروج"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dtPayment
        '
        Me.dtPayment.CustomFormat = "dd/MM/yyyy"
        Me.dtPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPayment.Location = New System.Drawing.Point(12, 108)
        Me.dtPayment.Name = "dtPayment"
        Me.dtPayment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtPayment.Size = New System.Drawing.Size(192, 21)
        Me.dtPayment.TabIndex = 278
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(312, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "تاریخ پرداخت"
        '
        'DfrmPurchasePayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(405, 386)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtPayment)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.txtTotalToPay)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtInvoice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalPaid)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DGDiag)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DfrmPurchasePayment"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "   محل پرداخت   "
        CType(Me.DGDiag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents txtTotalToPay As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGDiag As System.Windows.Forms.DataGridView
    Friend WithEvents btnPay As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dtPayment As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGDiagSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDiagAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDiagDate As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DfrmShopKepperForReport
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.txtPhoneReport = New System.Windows.Forms.TextBox
        Me.txtConcernPReport = New System.Windows.Forms.TextBox
        Me.cmbShopReport = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSaleType = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(69, 200)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 341
        Me.btnCancel.Text = "لغو"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(160, 200)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 340
        Me.btnOK.Text = "درج"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'txtPhoneReport
        '
        Me.txtPhoneReport.Location = New System.Drawing.Point(21, 135)
        Me.txtPhoneReport.Name = "txtPhoneReport"
        Me.txtPhoneReport.ReadOnly = True
        Me.txtPhoneReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPhoneReport.Size = New System.Drawing.Size(171, 21)
        Me.txtPhoneReport.TabIndex = 339
        '
        'txtConcernPReport
        '
        Me.txtConcernPReport.Location = New System.Drawing.Point(21, 107)
        Me.txtConcernPReport.Name = "txtConcernPReport"
        Me.txtConcernPReport.ReadOnly = True
        Me.txtConcernPReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtConcernPReport.Size = New System.Drawing.Size(171, 21)
        Me.txtConcernPReport.TabIndex = 338
        '
        'cmbShopReport
        '
        Me.cmbShopReport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbShopReport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbShopReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShopReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbShopReport.FormattingEnabled = True
        Me.cmbShopReport.Location = New System.Drawing.Point(21, 77)
        Me.cmbShopReport.Name = "cmbShopReport"
        Me.cmbShopReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbShopReport.Size = New System.Drawing.Size(171, 21)
        Me.cmbShopReport.TabIndex = 337
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(224, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 336
        Me.Label5.Text = "شماره تماس"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(201, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 335
        Me.Label4.Text = "اسم شخص مسول"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(229, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 334
        Me.Label3.Text = "اسم دوکان"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(55, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 24)
        Me.Label1.TabIndex = 333
        Me.Label1.Text = "مقدمات گزارش های دوکاندار ها"
        '
        'txtSaleType
        '
        Me.txtSaleType.Location = New System.Drawing.Point(21, 163)
        Me.txtSaleType.Name = "txtSaleType"
        Me.txtSaleType.ReadOnly = True
        Me.txtSaleType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSaleType.Size = New System.Drawing.Size(171, 21)
        Me.txtSaleType.TabIndex = 343
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(232, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 342
        Me.Label2.Text = "نوع فروش"
        '
        'DfrmShopKepperForReport
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(307, 255)
        Me.Controls.Add(Me.txtSaleType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPhoneReport)
        Me.Controls.Add(Me.txtConcernPReport)
        Me.Controls.Add(Me.cmbShopReport)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DfrmShopKepperForReport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DfrmShopKepperForReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtPhoneReport As System.Windows.Forms.TextBox
    Friend WithEvents txtConcernPReport As System.Windows.Forms.TextBox
    Friend WithEvents cmbShopReport As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSaleType As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class

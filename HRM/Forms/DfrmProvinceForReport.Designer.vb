<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DfrmProvinceForReport
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
        Me.txtPhoneReport = New System.Windows.Forms.TextBox
        Me.cmbProvinceReport = New System.Windows.Forms.ComboBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtConcernPName = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtPhoneReport
        '
        Me.txtPhoneReport.Location = New System.Drawing.Point(21, 148)
        Me.txtPhoneReport.Name = "txtPhoneReport"
        Me.txtPhoneReport.ReadOnly = True
        Me.txtPhoneReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPhoneReport.Size = New System.Drawing.Size(171, 21)
        Me.txtPhoneReport.TabIndex = 333
        '
        'cmbProvinceReport
        '
        Me.cmbProvinceReport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProvinceReport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProvinceReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvinceReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbProvinceReport.FormattingEnabled = True
        Me.cmbProvinceReport.Location = New System.Drawing.Point(21, 88)
        Me.cmbProvinceReport.Name = "cmbProvinceReport"
        Me.cmbProvinceReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbProvinceReport.Size = New System.Drawing.Size(171, 21)
        Me.cmbProvinceReport.TabIndex = 331
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(65, 204)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 330
        Me.btnCancel.Text = "لغو"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(156, 204)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 329
        Me.btnOK.Text = "درج"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(221, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 328
        Me.Label5.Text = "شماره تماس"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(200, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 327
        Me.Label4.Text = "اسم شخص مسول"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(17, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(277, 24)
        Me.Label1.TabIndex = 326
        Me.Label1.Text = "مقدمات گزارش های نمائند گی ها در ولایات"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(229, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 325
        Me.Label3.Text = "اسم ولایت"
        '
        'txtConcernPName
        '
        Me.txtConcernPName.Location = New System.Drawing.Point(21, 119)
        Me.txtConcernPName.Name = "txtConcernPName"
        Me.txtConcernPName.ReadOnly = True
        Me.txtConcernPName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtConcernPName.Size = New System.Drawing.Size(171, 21)
        Me.txtConcernPName.TabIndex = 334
        '
        'DfrmProvinceForReport
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(307, 255)
        Me.Controls.Add(Me.txtConcernPName)
        Me.Controls.Add(Me.txtPhoneReport)
        Me.Controls.Add(Me.cmbProvinceReport)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DfrmProvinceForReport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DfrmProvinceForReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPhoneReport As System.Windows.Forms.TextBox
    Friend WithEvents cmbProvinceReport As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtConcernPName As System.Windows.Forms.TextBox

End Class

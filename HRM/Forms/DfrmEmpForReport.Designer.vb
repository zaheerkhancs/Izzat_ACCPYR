<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DfrmEmpForReport
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbEmpName = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFatherName = New System.Windows.Forms.TextBox
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.txtJobTitle = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(286, 24)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "مقدمات گزارش های معلومات مکمل کارمند ها"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(223, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "اسم کارمند"
        '
        'cmbEmpName
        '
        Me.cmbEmpName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmpName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbEmpName.FormattingEnabled = True
        Me.cmbEmpName.Location = New System.Drawing.Point(25, 78)
        Me.cmbEmpName.Name = "cmbEmpName"
        Me.cmbEmpName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbEmpName.Size = New System.Drawing.Size(183, 21)
        Me.cmbEmpName.TabIndex = 57
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(249, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 279
        Me.Label6.Text = "شغل"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(249, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 278
        Me.Label5.Text = "شعبه"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(238, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 277
        Me.Label4.Text = "ولد/بنت"
        '
        'txtFatherName
        '
        Me.txtFatherName.Location = New System.Drawing.Point(25, 108)
        Me.txtFatherName.Name = "txtFatherName"
        Me.txtFatherName.ReadOnly = True
        Me.txtFatherName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFatherName.Size = New System.Drawing.Size(183, 21)
        Me.txtFatherName.TabIndex = 281
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(25, 137)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDepartment.Size = New System.Drawing.Size(183, 21)
        Me.txtDepartment.TabIndex = 282
        '
        'txtJobTitle
        '
        Me.txtJobTitle.Location = New System.Drawing.Point(25, 166)
        Me.txtJobTitle.Name = "txtJobTitle"
        Me.txtJobTitle.ReadOnly = True
        Me.txtJobTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtJobTitle.Size = New System.Drawing.Size(183, 21)
        Me.txtJobTitle.TabIndex = 283
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(69, 204)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 314
        Me.btnCancel.Text = "لغو"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.ForeColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(160, 204)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 313
        Me.btnOK.Text = "درج"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'DfrmEmpForReport
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(307, 255)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtJobTitle)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.txtFatherName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbEmpName)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DfrmEmpForReport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DfrmEmpForReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFatherName As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents txtJobTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button

End Class

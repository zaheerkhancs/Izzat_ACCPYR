<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGL))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnHeads = New System.Windows.Forms.Button
        Me.CmbHeads = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtHead2 = New System.Windows.Forms.DateTimePicker
        Me.DtHead1 = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbSubHeadName = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbHeadCode = New System.Windows.Forms.ComboBox
        Me.RBDate = New System.Windows.Forms.RadioButton
        Me.RBHeads = New System.Windows.Forms.RadioButton
        Me.chkSpecificSubHead = New System.Windows.Forms.CheckBox
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.CV = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.DtDate1 = New System.Windows.Forms.DateTimePicker
        Me.DtDate2 = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbRecord = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.PanDate = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbCustomer = New System.Windows.Forms.ComboBox
        Me.btnCustomer = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtToCustomer = New System.Windows.Forms.DateTimePicker
        Me.dtFromCustomer = New System.Windows.Forms.DateTimePicker
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.PanDate.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnHeads)
        Me.Panel2.Controls.Add(Me.CmbHeads)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DtHead2)
        Me.Panel2.Controls.Add(Me.DtHead1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(925, 41)
        Me.Panel2.TabIndex = 7
        '
        'BtnHeads
        '
        Me.BtnHeads.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnHeads.Image = CType(resources.GetObject("BtnHeads.Image"), System.Drawing.Image)
        Me.BtnHeads.Location = New System.Drawing.Point(850, 0)
        Me.BtnHeads.Name = "BtnHeads"
        Me.BtnHeads.Size = New System.Drawing.Size(73, 39)
        Me.BtnHeads.TabIndex = 6
        Me.BtnHeads.Text = "Preview"
        Me.BtnHeads.UseVisualStyleBackColor = True
        '
        'CmbHeads
        '
        Me.CmbHeads.FormattingEnabled = True
        Me.CmbHeads.Location = New System.Drawing.Point(77, 12)
        Me.CmbHeads.Name = "CmbHeads"
        Me.CmbHeads.Size = New System.Drawing.Size(218, 21)
        Me.CmbHeads.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Head Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(493, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(322, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From Date"
        '
        'DtHead2
        '
        Me.DtHead2.CustomFormat = "dd/MM/yyyy"
        Me.DtHead2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtHead2.Location = New System.Drawing.Point(546, 12)
        Me.DtHead2.Name = "DtHead2"
        Me.DtHead2.Size = New System.Drawing.Size(99, 20)
        Me.DtHead2.TabIndex = 1
        '
        'DtHead1
        '
        Me.DtHead1.CustomFormat = "dd/MM/yyyy"
        Me.DtHead1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtHead1.Location = New System.Drawing.Point(388, 12)
        Me.DtHead1.Name = "DtHead1"
        Me.DtHead1.Size = New System.Drawing.Size(99, 20)
        Me.DtHead1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cmbSubHeadName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbHeadCode)
        Me.Panel1.Controls.Add(Me.RBDate)
        Me.Panel1.Controls.Add(Me.RBHeads)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(925, 41)
        Me.Panel1.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(332, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Sub Head Names"
        Me.Label7.Visible = False
        '
        'cmbSubHeadName
        '
        Me.cmbSubHeadName.FormattingEnabled = True
        Me.cmbSubHeadName.Location = New System.Drawing.Point(427, 13)
        Me.cmbSubHeadName.Name = "cmbSubHeadName"
        Me.cmbSubHeadName.Size = New System.Drawing.Size(218, 21)
        Me.cmbSubHeadName.TabIndex = 10
        Me.cmbSubHeadName.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Head Code"
        Me.Label4.Visible = False
        '
        'cmbHeadCode
        '
        Me.cmbHeadCode.FormattingEnabled = True
        Me.cmbHeadCode.Location = New System.Drawing.Point(77, 13)
        Me.cmbHeadCode.Name = "cmbHeadCode"
        Me.cmbHeadCode.Size = New System.Drawing.Size(218, 21)
        Me.cmbHeadCode.TabIndex = 8
        Me.cmbHeadCode.Visible = False
        '
        'RBDate
        '
        Me.RBDate.AutoSize = True
        Me.RBDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RBDate.Location = New System.Drawing.Point(730, 19)
        Me.RBDate.Name = "RBDate"
        Me.RBDate.Size = New System.Drawing.Size(139, 17)
        Me.RBDate.TabIndex = 2
        Me.RBDate.TabStop = True
        Me.RBDate.Text = "General Ledger By Date"
        Me.RBDate.UseVisualStyleBackColor = True
        Me.RBDate.Visible = False
        '
        'RBHeads
        '
        Me.RBHeads.AutoSize = True
        Me.RBHeads.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RBHeads.Location = New System.Drawing.Point(730, 1)
        Me.RBHeads.Name = "RBHeads"
        Me.RBHeads.Size = New System.Drawing.Size(147, 17)
        Me.RBHeads.TabIndex = 1
        Me.RBHeads.TabStop = True
        Me.RBHeads.Text = "General Ledger By Heads"
        Me.RBHeads.UseVisualStyleBackColor = True
        Me.RBHeads.Visible = False
        '
        'chkSpecificSubHead
        '
        Me.chkSpecificSubHead.AutoSize = True
        Me.chkSpecificSubHead.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkSpecificSubHead.Location = New System.Drawing.Point(23, 8)
        Me.chkSpecificSubHead.Name = "chkSpecificSubHead"
        Me.chkSpecificSubHead.Size = New System.Drawing.Size(184, 17)
        Me.chkSpecificSubHead.TabIndex = 12
        Me.chkSpecificSubHead.Text = "Search a specific sub head name"
        Me.chkSpecificSubHead.UseVisualStyleBackColor = True
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me.chkSpecificSubHead)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(925, 28)
        Me.PanelTop.TabIndex = 5
        '
        'CV
        '
        Me.CV.ActiveViewIndex = -1
        Me.CV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CV.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CV.Location = New System.Drawing.Point(0, 198)
        Me.CV.Name = "CV"
        Me.CV.SelectionFormula = ""
        Me.CV.Size = New System.Drawing.Size(925, 290)
        Me.CV.TabIndex = 9
        Me.CV.ViewTimeSelectionFormula = ""
        '
        'DtDate1
        '
        Me.DtDate1.CustomFormat = "dd/MM/yyyy"
        Me.DtDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtDate1.Location = New System.Drawing.Point(388, 9)
        Me.DtDate1.Name = "DtDate1"
        Me.DtDate1.Size = New System.Drawing.Size(99, 20)
        Me.DtDate1.TabIndex = 0
        '
        'DtDate2
        '
        Me.DtDate2.CustomFormat = "dd/MM/yyyy"
        Me.DtDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtDate2.Location = New System.Drawing.Point(546, 9)
        Me.DtDate2.Name = "DtDate2"
        Me.DtDate2.Size = New System.Drawing.Size(99, 20)
        Me.DtDate2.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(321, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "From Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(487, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To Date"
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Location = New System.Drawing.Point(850, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 39)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Preview"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbRecord
        '
        Me.cmbRecord.FormattingEnabled = True
        Me.cmbRecord.Location = New System.Drawing.Point(101, 8)
        Me.cmbRecord.Name = "cmbRecord"
        Me.cmbRecord.Size = New System.Drawing.Size(194, 21)
        Me.cmbRecord.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(8, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Company Names"
        '
        'PanDate
        '
        Me.PanDate.BackColor = System.Drawing.Color.Transparent
        Me.PanDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanDate.Controls.Add(Me.Label8)
        Me.PanDate.Controls.Add(Me.cmbRecord)
        Me.PanDate.Controls.Add(Me.Button1)
        Me.PanDate.Controls.Add(Me.Label5)
        Me.PanDate.Controls.Add(Me.Label6)
        Me.PanDate.Controls.Add(Me.DtDate2)
        Me.PanDate.Controls.Add(Me.DtDate1)
        Me.PanDate.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanDate.Location = New System.Drawing.Point(0, 110)
        Me.PanDate.Name = "PanDate"
        Me.PanDate.Size = New System.Drawing.Size(925, 41)
        Me.PanDate.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.cmbCustomer)
        Me.Panel3.Controls.Add(Me.btnCustomer)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.dtToCustomer)
        Me.Panel3.Controls.Add(Me.dtFromCustomer)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 151)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(925, 41)
        Me.Panel3.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(8, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Customer Names"
        '
        'cmbCustomer
        '
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(101, 8)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(194, 21)
        Me.cmbCustomer.TabIndex = 8
        '
        'btnCustomer
        '
        Me.btnCustomer.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCustomer.Location = New System.Drawing.Point(850, 0)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(73, 39)
        Me.btnCustomer.TabIndex = 6
        Me.btnCustomer.Text = "Preview"
        Me.btnCustomer.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(487, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "To Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(321, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "From Date"
        '
        'dtToCustomer
        '
        Me.dtToCustomer.CustomFormat = "dd/MM/yyyy"
        Me.dtToCustomer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToCustomer.Location = New System.Drawing.Point(546, 9)
        Me.dtToCustomer.Name = "dtToCustomer"
        Me.dtToCustomer.Size = New System.Drawing.Size(99, 20)
        Me.dtToCustomer.TabIndex = 1
        '
        'dtFromCustomer
        '
        Me.dtFromCustomer.CustomFormat = "dd/MM/yyyy"
        Me.dtFromCustomer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromCustomer.Location = New System.Drawing.Point(388, 9)
        Me.dtFromCustomer.Name = "dtFromCustomer"
        Me.dtFromCustomer.Size = New System.Drawing.Size(99, 20)
        Me.dtFromCustomer.TabIndex = 0
        '
        'FrmGL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(925, 488)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.CV)
        Me.Controls.Add(Me.PanDate)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "FrmGL"
        Me.Text = "FrmGL"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.PanDate.ResumeLayout(False)
        Me.PanDate.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnHeads As System.Windows.Forms.Button
    Public WithEvents CmbHeads As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtHead2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtHead1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RBDate As System.Windows.Forms.RadioButton
    Friend WithEvents RBHeads As System.Windows.Forms.RadioButton
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents CV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Public WithEvents cmbHeadCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents cmbSubHeadName As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkSpecificSubHead As System.Windows.Forms.CheckBox
    Friend WithEvents DtDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents cmbRecord As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PanDate As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents btnCustomer As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtToCustomer As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFromCustomer As System.Windows.Forms.DateTimePicker
End Class

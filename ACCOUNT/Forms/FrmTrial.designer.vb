<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrial))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CV = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.PanDate = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtDate2 = New System.Windows.Forms.DateTimePicker
        Me.DtDate1 = New System.Windows.Forms.DateTimePicker
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.BtnHeads = New System.Windows.Forms.Button
        Me.CmbHeads = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtHead2 = New System.Windows.Forms.DateTimePicker
        Me.DtHead1 = New System.Windows.Forms.DateTimePicker
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.RBDate = New System.Windows.Forms.RadioButton
        Me.RBHeads = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.PanDate.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.CV)
        Me.Panel1.Controls.Add(Me.PanDate)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(713, 432)
        Me.Panel1.TabIndex = 0
        '
        'CV
        '
        Me.CV.ActiveViewIndex = -1
        Me.CV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CV.DisplayGroupTree = False
        Me.CV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CV.Location = New System.Drawing.Point(0, 147)
        Me.CV.Name = "CV"
        Me.CV.SelectionFormula = ""
        Me.CV.Size = New System.Drawing.Size(713, 285)
        Me.CV.TabIndex = 13
        Me.CV.ViewTimeSelectionFormula = ""
        '
        'PanDate
        '
        Me.PanDate.BackColor = System.Drawing.Color.Transparent
        Me.PanDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanDate.Controls.Add(Me.Button1)
        Me.PanDate.Controls.Add(Me.Label5)
        Me.PanDate.Controls.Add(Me.Label6)
        Me.PanDate.Controls.Add(Me.DtDate2)
        Me.PanDate.Controls.Add(Me.DtDate1)
        Me.PanDate.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanDate.Location = New System.Drawing.Point(0, 106)
        Me.PanDate.Name = "PanDate"
        Me.PanDate.Size = New System.Drawing.Size(713, 41)
        Me.PanDate.TabIndex = 11
        Me.PanDate.Visible = False
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Location = New System.Drawing.Point(638, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 39)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Preview"
        Me.ToolTip1.SetToolTip(Me.Button1, "Preview")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(332, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To Date"
        Me.ToolTip1.SetToolTip(Me.Label5, "To Date")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(129, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "From Date"
        Me.ToolTip1.SetToolTip(Me.Label6, "From Date")
        '
        'DtDate2
        '
        Me.DtDate2.CustomFormat = "dd/MM/yyyy"
        Me.DtDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtDate2.Location = New System.Drawing.Point(391, 9)
        Me.DtDate2.Name = "DtDate2"
        Me.DtDate2.Size = New System.Drawing.Size(99, 20)
        Me.DtDate2.TabIndex = 1
        '
        'DtDate1
        '
        Me.DtDate1.CustomFormat = "dd/MM/yyyy"
        Me.DtDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtDate1.Location = New System.Drawing.Point(194, 9)
        Me.DtDate1.Name = "DtDate1"
        Me.DtDate1.Size = New System.Drawing.Size(99, 20)
        Me.DtDate1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnHeads)
        Me.Panel3.Controls.Add(Me.CmbHeads)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.DtHead2)
        Me.Panel3.Controls.Add(Me.DtHead1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 65)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(713, 41)
        Me.Panel3.TabIndex = 10
        Me.Panel3.Visible = False
        '
        'BtnHeads
        '
        Me.BtnHeads.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnHeads.Image = CType(resources.GetObject("BtnHeads.Image"), System.Drawing.Image)
        Me.BtnHeads.Location = New System.Drawing.Point(638, 0)
        Me.BtnHeads.Name = "BtnHeads"
        Me.BtnHeads.Size = New System.Drawing.Size(73, 39)
        Me.BtnHeads.TabIndex = 6
        Me.BtnHeads.Text = "Preview"
        Me.ToolTip1.SetToolTip(Me.BtnHeads, "Preview")
        Me.BtnHeads.UseVisualStyleBackColor = True
        '
        'CmbHeads
        '
        Me.CmbHeads.FormattingEnabled = True
        Me.CmbHeads.Location = New System.Drawing.Point(122, 12)
        Me.CmbHeads.Name = "CmbHeads"
        Me.CmbHeads.Size = New System.Drawing.Size(171, 21)
        Me.CmbHeads.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sub Head Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(487, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To Date"
        Me.ToolTip1.SetToolTip(Me.Label2, "To Date")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(321, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From Date"
        Me.ToolTip1.SetToolTip(Me.Label1, "From Date")
        '
        'DtHead2
        '
        Me.DtHead2.CustomFormat = "dd/MM/yyyy"
        Me.DtHead2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtHead2.Location = New System.Drawing.Point(535, 12)
        Me.DtHead2.Name = "DtHead2"
        Me.DtHead2.Size = New System.Drawing.Size(99, 20)
        Me.DtHead2.TabIndex = 1
        '
        'DtHead1
        '
        Me.DtHead1.CustomFormat = "dd/MM/yyyy"
        Me.DtHead1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtHead1.Location = New System.Drawing.Point(383, 12)
        Me.DtHead1.Name = "DtHead1"
        Me.DtHead1.Size = New System.Drawing.Size(99, 20)
        Me.DtHead1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.RBDate)
        Me.Panel4.Controls.Add(Me.RBHeads)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 24)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(713, 41)
        Me.Panel4.TabIndex = 12
        '
        'RBDate
        '
        Me.RBDate.AutoSize = True
        Me.RBDate.ForeColor = System.Drawing.Color.White
        Me.RBDate.Location = New System.Drawing.Point(391, 5)
        Me.RBDate.Name = "RBDate"
        Me.RBDate.Size = New System.Drawing.Size(86, 17)
        Me.RBDate.TabIndex = 2
        Me.RBDate.TabStop = True
        Me.RBDate.Text = "Trial By Date"
        Me.RBDate.UseVisualStyleBackColor = True
        '
        'RBHeads
        '
        Me.RBHeads.AutoSize = True
        Me.RBHeads.ForeColor = System.Drawing.Color.White
        Me.RBHeads.Location = New System.Drawing.Point(119, 5)
        Me.RBHeads.Name = "RBHeads"
        Me.RBHeads.Size = New System.Drawing.Size(116, 17)
        Me.RBHeads.TabIndex = 1
        Me.RBHeads.TabStop = True
        Me.RBHeads.Text = "Trial By Sub Heads"
        Me.RBHeads.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(713, 24)
        Me.Panel2.TabIndex = 0
        '
        'FrmTrial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(713, 432)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmTrial"
        Me.Text = "Trial Balance"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.PanDate.ResumeLayout(False)
        Me.PanDate.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PanDate As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DtDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnHeads As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtHead2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtHead1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RBDate As System.Windows.Forms.RadioButton
    Friend WithEvents RBHeads As System.Windows.Forms.RadioButton
    Friend WithEvents CV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Public WithEvents CmbHeads As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

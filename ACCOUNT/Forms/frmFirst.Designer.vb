<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFirst
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
        Me.CV = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CV
        '
        Me.CV.ActiveViewIndex = -1
        Me.CV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CV.DisplayBackgroundEdge = False
        Me.CV.DisplayGroupTree = False
        Me.CV.DisplayStatusBar = False
        Me.CV.DisplayToolbar = False
        Me.CV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CV.Location = New System.Drawing.Point(0, 0)
        Me.CV.Name = "CV"
        Me.CV.SelectionFormula = ""
        Me.CV.Size = New System.Drawing.Size(479, 271)
        Me.CV.TabIndex = 15
        Me.CV.ViewTimeSelectionFormula = ""
        '
        'frmFirst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 271)
        Me.Controls.Add(Me.CV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFirst"
        Me.Text = "frmFirst"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CV As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

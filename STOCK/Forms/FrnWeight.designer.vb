<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWeight
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
        Dim Label5 As System.Windows.Forms.Label
        Dim TypeIDLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWeight))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TxtID = New System.Windows.Forms.TextBox
        Me.LLWeightsList = New System.Windows.Forms.LinkLabel
        Me.lblMessage = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.TSNavigator = New System.Windows.Forms.ToolStrip
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
        Label5 = New System.Windows.Forms.Label
        TypeIDLabel = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CM.SuspendLayout()
        Me.TSNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.BackColor = System.Drawing.Color.Transparent
        Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Label5.ForeColor = System.Drawing.Color.White
        Label5.Location = New System.Drawing.Point(284, 141)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(49, 16)
        Label5.TabIndex = 66
        Label5.Text = "کود وزن"
        '
        'TypeIDLabel
        '
        TypeIDLabel.AutoSize = True
        TypeIDLabel.BackColor = System.Drawing.Color.Transparent
        TypeIDLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        TypeIDLabel.ForeColor = System.Drawing.Color.White
        TypeIDLabel.Location = New System.Drawing.Point(306, 168)
        TypeIDLabel.Name = "TypeIDLabel"
        TypeIDLabel.Size = New System.Drawing.Size(27, 16)
        TypeIDLabel.TabIndex = 65
        TypeIDLabel.Text = "وزن"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(123, 107)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'TxtID
        '
        Me.TxtID.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TxtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtID.Location = New System.Drawing.Point(12, 141)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.ReadOnly = True
        Me.TxtID.Size = New System.Drawing.Size(83, 20)
        Me.TxtID.TabIndex = 63
        '
        'LLWeightsList
        '
        Me.LLWeightsList.AutoSize = True
        Me.LLWeightsList.BackColor = System.Drawing.Color.Transparent
        Me.LLWeightsList.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LLWeightsList.LinkColor = System.Drawing.Color.Orange
        Me.LLWeightsList.Location = New System.Drawing.Point(266, 35)
        Me.LLWeightsList.Name = "LLWeightsList"
        Me.LLWeightsList.Size = New System.Drawing.Size(67, 16)
        Me.LLWeightsList.TabIndex = 273
        Me.LLWeightsList.TabStop = True
        Me.LLWeightsList.Text = "لست اوزان"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(141, 63)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(19, 14)
        Me.lblMessage.TabIndex = 274
        Me.lblMessage.Text = "..."
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(12, 168)
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(216, 20)
        Me.txtName.TabIndex = 275
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuEdit, Me.MnuDelete, Me.MnuUndo, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
        Me.CM.Size = New System.Drawing.Size(139, 136)
        '
        'MnuNew
        '
        Me.MnuNew.BackColor = System.Drawing.Color.White
        Me.MnuNew.Image = CType(resources.GetObject("MnuNew.Image"), System.Drawing.Image)
        Me.MnuNew.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuNew.Name = "MnuNew"
        Me.MnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.MnuNew.Size = New System.Drawing.Size(138, 22)
        Me.MnuNew.Text = "&علاوه"
        '
        'MnuSave
        '
        Me.MnuSave.BackColor = System.Drawing.Color.White
        Me.MnuSave.Enabled = False
        Me.MnuSave.Image = CType(resources.GetObject("MnuSave.Image"), System.Drawing.Image)
        Me.MnuSave.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuSave.Name = "MnuSave"
        Me.MnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.MnuSave.Size = New System.Drawing.Size(138, 22)
        Me.MnuSave.Text = "&ثبت"
        '
        'MnuEdit
        '
        Me.MnuEdit.BackColor = System.Drawing.Color.White
        Me.MnuEdit.Image = CType(resources.GetObject("MnuEdit.Image"), System.Drawing.Image)
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.MnuEdit.Size = New System.Drawing.Size(138, 22)
        Me.MnuEdit.Text = "&تغیر"
        '
        'MnuDelete
        '
        Me.MnuDelete.BackColor = System.Drawing.Color.White
        Me.MnuDelete.Image = CType(resources.GetObject("MnuDelete.Image"), System.Drawing.Image)
        Me.MnuDelete.Name = "MnuDelete"
        Me.MnuDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuDelete.Size = New System.Drawing.Size(138, 22)
        Me.MnuDelete.Text = "&حذف"
        '
        'MnuUndo
        '
        Me.MnuUndo.BackColor = System.Drawing.Color.White
        Me.MnuUndo.Enabled = False
        Me.MnuUndo.Image = CType(resources.GetObject("MnuUndo.Image"), System.Drawing.Image)
        Me.MnuUndo.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuUndo.Name = "MnuUndo"
        Me.MnuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.MnuUndo.Size = New System.Drawing.Size(138, 22)
        Me.MnuUndo.Text = "خنثی"
        '
        'MnuExit
        '
        Me.MnuExit.BackColor = System.Drawing.Color.White
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MnuExit.Size = New System.Drawing.Size(138, 22)
        Me.MnuExit.Text = "&خروج"
        '
        'TSNavigator
        '
        Me.TSNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSFirst, Me.TSPrevious, Me.TSLast, Me.TSNext})
        Me.TSNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TSNavigator.Name = "TSNavigator"
        Me.TSNavigator.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSNavigator.Size = New System.Drawing.Size(375, 25)
        Me.TSNavigator.TabIndex = 276
        Me.TSNavigator.Text = "ToolStrip1"
        '
        'TSFirst
        '
        Me.TSFirst.Image = CType(resources.GetObject("TSFirst.Image"), System.Drawing.Image)
        Me.TSFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSFirst.Name = "TSFirst"
        Me.TSFirst.Size = New System.Drawing.Size(65, 22)
        Me.TSFirst.Text = "نخستین"
        '
        'TSPrevious
        '
        Me.TSPrevious.Image = CType(resources.GetObject("TSPrevious.Image"), System.Drawing.Image)
        Me.TSPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSPrevious.Name = "TSPrevious"
        Me.TSPrevious.Size = New System.Drawing.Size(51, 22)
        Me.TSPrevious.Text = "قبلی"
        '
        'TSLast
        '
        Me.TSLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSLast.Image = CType(resources.GetObject("TSLast.Image"), System.Drawing.Image)
        Me.TSLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSLast.Name = "TSLast"
        Me.TSLast.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSLast.Size = New System.Drawing.Size(53, 22)
        Me.TSLast.Text = "نهایی"
        '
        'TSNext
        '
        Me.TSNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSNext.Image = CType(resources.GetObject("TSNext.Image"), System.Drawing.Image)
        Me.TSNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSNext.Name = "TSNext"
        Me.TSNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSNext.Size = New System.Drawing.Size(52, 22)
        Me.TSNext.Text = "بعدی"
        '
        'FrmWeight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(375, 200)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.TSNavigator)
        Me.Controls.Add(Me.LLWeightsList)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.TxtID)
        Me.Controls.Add(TypeIDLabel)
        Me.MaximizeBox = False
        Me.Name = "FrmWeight"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "..."
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CM.ResumeLayout(False)
        Me.TSNavigator.ResumeLayout(False)
        Me.TSNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LLWeightsList As System.Windows.Forms.LinkLabel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSNavigator As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Public WithEvents TxtID As System.Windows.Forms.TextBox
End Class

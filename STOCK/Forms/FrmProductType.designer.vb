<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductType
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
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductType))
        Me.TxtID = New System.Windows.Forms.TextBox
        Me.TSNavigator = New System.Windows.Forms.ToolStrip
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.LLProductTypesList = New System.Windows.Forms.LinkLabel
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtNameEnglish = New System.Windows.Forms.TextBox
        Label5 = New System.Windows.Forms.Label
        TypeIDLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Me.TSNavigator.SuspendLayout()
        Me.CM.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.BackColor = System.Drawing.Color.Transparent
        Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Label5.ForeColor = System.Drawing.Color.White
        Label5.Location = New System.Drawing.Point(268, 142)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(92, 16)
        Label5.TabIndex = 57
        Label5.Text = "کود نوع محصول"
        Label5.Visible = False
        '
        'TypeIDLabel
        '
        TypeIDLabel.AutoSize = True
        TypeIDLabel.BackColor = System.Drawing.Color.Transparent
        TypeIDLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        TypeIDLabel.ForeColor = System.Drawing.Color.White
        TypeIDLabel.Location = New System.Drawing.Point(279, 169)
        TypeIDLabel.Name = "TypeIDLabel"
        TypeIDLabel.Size = New System.Drawing.Size(103, 16)
        TypeIDLabel.TabIndex = 56
        TypeIDLabel.Text = " اسم نوع محصول"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Label1.ForeColor = System.Drawing.Color.White
        Label1.Location = New System.Drawing.Point(12, 211)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(120, 16)
        Label1.TabIndex = 80
        Label1.Text = "Product Type Name"
        '
        'TxtID
        '
        Me.TxtID.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TxtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtID.Location = New System.Drawing.Point(13, 142)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.ReadOnly = True
        Me.TxtID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtID.Size = New System.Drawing.Size(83, 20)
        Me.TxtID.TabIndex = 54
        Me.TxtID.Visible = False
        '
        'TSNavigator
        '
        Me.TSNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSLast, Me.TSNext, Me.TSFirst, Me.TSPrevious})
        Me.TSNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TSNavigator.Name = "TSNavigator"
        Me.TSNavigator.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSNavigator.Size = New System.Drawing.Size(391, 25)
        Me.TSNavigator.TabIndex = 73
        Me.TSNavigator.Text = "ToolStrip1"
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
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuEdit, Me.MnuDelete, Me.MnuUndo, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
        Me.CM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
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
        'LLProductTypesList
        '
        Me.LLProductTypesList.AutoSize = True
        Me.LLProductTypesList.BackColor = System.Drawing.Color.Transparent
        Me.LLProductTypesList.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LLProductTypesList.LinkColor = System.Drawing.Color.Orange
        Me.LLProductTypesList.Location = New System.Drawing.Point(229, 36)
        Me.LLProductTypesList.Name = "LLProductTypesList"
        Me.LLProductTypesList.Size = New System.Drawing.Size(121, 16)
        Me.LLProductTypesList.TabIndex = 76
        Me.LLProductTypesList.TabStop = True
        Me.LLProductTypesList.Text = "لست انواع محصولات"
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(13, 169)
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtName.Size = New System.Drawing.Size(238, 20)
        Me.txtName.TabIndex = 77
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
        Me.lblMessage.TabIndex = 78
        Me.lblMessage.Text = "..."
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
        Me.PictureBox1.TabIndex = 79
        Me.PictureBox1.TabStop = False
        '
        'txtNameEnglish
        '
        Me.txtNameEnglish.Enabled = False
        Me.txtNameEnglish.Location = New System.Drawing.Point(141, 210)
        Me.txtNameEnglish.Name = "txtNameEnglish"
        Me.txtNameEnglish.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNameEnglish.Size = New System.Drawing.Size(238, 20)
        Me.txtNameEnglish.TabIndex = 81
        '
        'FrmProductType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(391, 264)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.txtNameEnglish)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LLProductTypesList)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.TSNavigator)
        Me.Controls.Add(Me.TxtID)
        Me.Controls.Add(Label5)
        Me.Controls.Add(TypeIDLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmProductType"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TSNavigator.ResumeLayout(False)
        Me.TSNavigator.PerformLayout()
        Me.CM.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSNavigator As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LLProductTypesList As System.Windows.Forms.LinkLabel
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Public WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents txtNameEnglish As System.Windows.Forms.TextBox
End Class

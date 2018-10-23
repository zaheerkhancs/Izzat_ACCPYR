<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGLSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGLSetup))
        Me.CKList = New System.Windows.Forms.CheckedListBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnIncome = New System.Windows.Forms.Button
        Me.BtnBalanceSheet = New System.Windows.Forms.Button
        Me.BtnTrial = New System.Windows.Forms.Button
        Me.BtnCashBook = New System.Windows.Forms.Button
        Me.BtnNext = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CKList
        '
        Me.CKList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CKList.FormattingEnabled = True
        Me.CKList.Location = New System.Drawing.Point(0, 65)
        Me.CKList.Name = "CKList"
        Me.CKList.Size = New System.Drawing.Size(488, 244)
        Me.CKList.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 65)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(74, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(398, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select the companies from the below list, which you want on reports"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnIncome)
        Me.Panel2.Controls.Add(Me.BtnBalanceSheet)
        Me.Panel2.Controls.Add(Me.BtnTrial)
        Me.Panel2.Controls.Add(Me.BtnCashBook)
        Me.Panel2.Controls.Add(Me.BtnNext)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 275)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(488, 37)
        Me.Panel2.TabIndex = 2
        '
        'BtnIncome
        '
        Me.BtnIncome.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnIncome.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIncome.Image = CType(resources.GetObject("BtnIncome.Image"), System.Drawing.Image)
        Me.BtnIncome.Location = New System.Drawing.Point(88, 0)
        Me.BtnIncome.Name = "BtnIncome"
        Me.BtnIncome.Size = New System.Drawing.Size(86, 35)
        Me.BtnIncome.TabIndex = 4
        Me.BtnIncome.Text = "Income Statement"
        Me.BtnIncome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnIncome.UseVisualStyleBackColor = True
        '
        'BtnBalanceSheet
        '
        Me.BtnBalanceSheet.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnBalanceSheet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBalanceSheet.Image = CType(resources.GetObject("BtnBalanceSheet.Image"), System.Drawing.Image)
        Me.BtnBalanceSheet.Location = New System.Drawing.Point(174, 0)
        Me.BtnBalanceSheet.Name = "BtnBalanceSheet"
        Me.BtnBalanceSheet.Size = New System.Drawing.Size(78, 35)
        Me.BtnBalanceSheet.TabIndex = 3
        Me.BtnBalanceSheet.Text = "Balance Sheet"
        Me.BtnBalanceSheet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnBalanceSheet.UseVisualStyleBackColor = True
        '
        'BtnTrial
        '
        Me.BtnTrial.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnTrial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTrial.Image = CType(resources.GetObject("BtnTrial.Image"), System.Drawing.Image)
        Me.BtnTrial.Location = New System.Drawing.Point(252, 0)
        Me.BtnTrial.Name = "BtnTrial"
        Me.BtnTrial.Size = New System.Drawing.Size(78, 35)
        Me.BtnTrial.TabIndex = 2
        Me.BtnTrial.Text = "Trial Balance"
        Me.BtnTrial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnTrial.UseVisualStyleBackColor = True
        '
        'BtnCashBook
        '
        Me.BtnCashBook.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCashBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCashBook.Image = CType(resources.GetObject("BtnCashBook.Image"), System.Drawing.Image)
        Me.BtnCashBook.Location = New System.Drawing.Point(330, 0)
        Me.BtnCashBook.Name = "BtnCashBook"
        Me.BtnCashBook.Size = New System.Drawing.Size(78, 35)
        Me.BtnCashBook.TabIndex = 1
        Me.BtnCashBook.Text = "Cash Book"
        Me.BtnCashBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCashBook.UseVisualStyleBackColor = True
        Me.BtnCashBook.Visible = False
        '
        'BtnNext
        '
        Me.BtnNext.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnNext.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.Location = New System.Drawing.Point(408, 0)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(78, 35)
        Me.BtnNext.TabIndex = 0
        Me.BtnNext.Text = "General Ledger"
        Me.BtnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'FrmGLSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(488, 312)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CKList)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGLSetup"
        Me.Opacity = 0.9
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Setup"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CKList As System.Windows.Forms.CheckedListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCashBook As System.Windows.Forms.Button
    Friend WithEvents BtnTrial As System.Windows.Forms.Button
    Friend WithEvents BtnBalanceSheet As System.Windows.Forms.Button
    Friend WithEvents BtnIncome As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockViewer
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockViewer))
        Me.BTNcLOSE = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TB1 = New System.Windows.Forms.TabControl
        Me.TP3 = New System.Windows.Forms.TabPage
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DgProdTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPcsInCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPurchase = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DgSalePcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DgSaleCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSale = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGReturnPcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGReturnCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGReturn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGClaimPcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGClaimCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGClaim = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDamagePcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDamageCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDamage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnPrint = New System.Windows.Forms.Button
        Me.TB1.SuspendLayout()
        Me.TP3.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNcLOSE
        '
        Me.BTNcLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTNcLOSE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTNcLOSE.Location = New System.Drawing.Point(5, 519)
        Me.BTNcLOSE.Name = "BTNcLOSE"
        Me.BTNcLOSE.Size = New System.Drawing.Size(82, 41)
        Me.BTNcLOSE.TabIndex = 255
        Me.BTNcLOSE.Text = "خاموش"
        Me.BTNcLOSE.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Location = New System.Drawing.Point(224, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(279, 34)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "معلومات محصولات در انبار"
        '
        'TB1
        '
        Me.TB1.Controls.Add(Me.TP3)
        Me.TB1.Location = New System.Drawing.Point(5, 68)
        Me.TB1.Name = "TB1"
        Me.TB1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TB1.RightToLeftLayout = True
        Me.TB1.SelectedIndex = 0
        Me.TB1.Size = New System.Drawing.Size(692, 445)
        Me.TB1.TabIndex = 27
        '
        'TP3
        '
        Me.TP3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP3.Controls.Add(Me.DG)
        Me.TP3.Location = New System.Drawing.Point(4, 22)
        Me.TP3.Name = "TP3"
        Me.TP3.Size = New System.Drawing.Size(684, 419)
        Me.TP3.TabIndex = 2
        Me.TP3.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AllowUserToResizeRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.Ivory
        Me.DG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.DG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSNO, Me.DgProdTypeName, Me.DGProductName, Me.DGPcsInCrtn, Me.DGTotal, Me.DGPurchase, Me.DgSalePcs, Me.DgSaleCrtn, Me.DGSale, Me.DGReturnPcs, Me.DGReturnCrtn, Me.DGReturn, Me.DGClaimPcs, Me.DGClaimCrtn, Me.DGClaim, Me.DGDamagePcs, Me.DGDamageCrtn, Me.DGDamage, Me.DGID})
        Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG.Location = New System.Drawing.Point(0, 0)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.DG.RowHeadersVisible = False
        Me.DG.Size = New System.Drawing.Size(684, 419)
        Me.DG.TabIndex = 295
        '
        'DGSNO
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGSNO.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGSNO.Frozen = True
        Me.DGSNO.HeaderText = "شماره"
        Me.DGSNO.Name = "DGSNO"
        Me.DGSNO.ReadOnly = True
        Me.DGSNO.Width = 50
        '
        'DgProdTypeName
        '
        Me.DgProdTypeName.Frozen = True
        Me.DgProdTypeName.HeaderText = "نوع محصول"
        Me.DgProdTypeName.Name = "DgProdTypeName"
        Me.DgProdTypeName.ReadOnly = True
        Me.DgProdTypeName.Width = 90
        '
        'DGProductName
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGProductName.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGProductName.Frozen = True
        Me.DGProductName.HeaderText = "اسم محصول"
        Me.DGProductName.Name = "DGProductName"
        Me.DGProductName.ReadOnly = True
        Me.DGProductName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGProductName.Width = 90
        '
        'DGPcsInCrtn
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red
        Me.DGPcsInCrtn.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGPcsInCrtn.HeaderText = "PcsInCrtn"
        Me.DGPcsInCrtn.Name = "DGPcsInCrtn"
        Me.DGPcsInCrtn.ReadOnly = True
        Me.DGPcsInCrtn.Visible = False
        Me.DGPcsInCrtn.Width = 60
        '
        'DGTotal
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red
        Me.DGTotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGTotal.Frozen = True
        Me.DGTotal.HeaderText = "باقی مانده "
        Me.DGTotal.Name = "DGTotal"
        Me.DGTotal.ReadOnly = True
        Me.DGTotal.Width = 60
        '
        'DGPurchase
        '
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        Me.DGPurchase.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGPurchase.HeaderText = "خرید"
        Me.DGPurchase.Name = "DGPurchase"
        Me.DGPurchase.ReadOnly = True
        '
        'DgSalePcs
        '
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy
        Me.DgSalePcs.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgSalePcs.HeaderText = "فروش دانه"
        Me.DgSalePcs.Name = "DgSalePcs"
        Me.DgSalePcs.ReadOnly = True
        Me.DgSalePcs.Width = 60
        '
        'DgSaleCrtn
        '
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Navy
        Me.DgSaleCrtn.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgSaleCrtn.HeaderText = "فروش کارتن"
        Me.DgSaleCrtn.Name = "DgSaleCrtn"
        Me.DgSaleCrtn.ReadOnly = True
        Me.DgSaleCrtn.Width = 60
        '
        'DGSale
        '
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Navy
        Me.DGSale.DefaultCellStyle = DataGridViewCellStyle9
        Me.DGSale.HeaderText = "فروش سر جمع"
        Me.DGSale.Name = "DGSale"
        Me.DGSale.ReadOnly = True
        '
        'DGReturnPcs
        '
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy
        Me.DGReturnPcs.DefaultCellStyle = DataGridViewCellStyle10
        Me.DGReturnPcs.HeaderText = "برگشت دانه"
        Me.DGReturnPcs.Name = "DGReturnPcs"
        Me.DGReturnPcs.ReadOnly = True
        Me.DGReturnPcs.Width = 60
        '
        'DGReturnCrtn
        '
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Navy
        Me.DGReturnCrtn.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGReturnCrtn.HeaderText = "برگشت کارتن"
        Me.DGReturnCrtn.Name = "DGReturnCrtn"
        Me.DGReturnCrtn.ReadOnly = True
        Me.DGReturnCrtn.Width = 60
        '
        'DGReturn
        '
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Navy
        Me.DGReturn.DefaultCellStyle = DataGridViewCellStyle12
        Me.DGReturn.HeaderText = "برگشت سر جمع"
        Me.DGReturn.Name = "DGReturn"
        Me.DGReturn.ReadOnly = True
        '
        'DGClaimPcs
        '
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Navy
        Me.DGClaimPcs.DefaultCellStyle = DataGridViewCellStyle13
        Me.DGClaimPcs.HeaderText = "Claim Pcs"
        Me.DGClaimPcs.Name = "DGClaimPcs"
        Me.DGClaimPcs.ReadOnly = True
        Me.DGClaimPcs.Width = 60
        '
        'DGClaimCrtn
        '
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Navy
        Me.DGClaimCrtn.DefaultCellStyle = DataGridViewCellStyle14
        Me.DGClaimCrtn.HeaderText = "Clam Crtn"
        Me.DGClaimCrtn.Name = "DGClaimCrtn"
        Me.DGClaimCrtn.ReadOnly = True
        Me.DGClaimCrtn.Width = 60
        '
        'DGClaim
        '
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Navy
        Me.DGClaim.DefaultCellStyle = DataGridViewCellStyle15
        Me.DGClaim.HeaderText = "claim total"
        Me.DGClaim.Name = "DGClaim"
        Me.DGClaim.ReadOnly = True
        '
        'DGDamagePcs
        '
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Navy
        Me.DGDamagePcs.DefaultCellStyle = DataGridViewCellStyle16
        Me.DGDamagePcs.HeaderText = "فاسد شده دانه"
        Me.DGDamagePcs.Name = "DGDamagePcs"
        Me.DGDamagePcs.ReadOnly = True
        Me.DGDamagePcs.Width = 60
        '
        'DGDamageCrtn
        '
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Navy
        Me.DGDamageCrtn.DefaultCellStyle = DataGridViewCellStyle17
        Me.DGDamageCrtn.HeaderText = "فاسد شده کارتن"
        Me.DGDamageCrtn.Name = "DGDamageCrtn"
        Me.DGDamageCrtn.ReadOnly = True
        Me.DGDamageCrtn.Width = 60
        '
        'DGDamage
        '
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Navy
        Me.DGDamage.DefaultCellStyle = DataGridViewCellStyle18
        Me.DGDamage.HeaderText = "فاسد شده سر جمع"
        Me.DGDamage.Name = "DGDamage"
        Me.DGDamage.ReadOnly = True
        '
        'DGID
        '
        Me.DGID.HeaderText = "ID"
        Me.DGID.Name = "DGID"
        Me.DGID.ReadOnly = True
        Me.DGID.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(5, 38)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 45)
        Me.btnPrint.TabIndex = 256
        Me.btnPrint.Text = " پرنت"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'frmStockViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(760, 604)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.TB1)
        Me.Controls.Add(Me.BTNcLOSE)
        Me.Controls.Add(Me.Label14)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmStockViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStockViewer"
        Me.TB1.ResumeLayout(False)
        Me.TP3.ResumeLayout(False)
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TB1 As System.Windows.Forms.TabControl
    Friend WithEvents BTNcLOSE As System.Windows.Forms.Button
    Friend WithEvents TP3 As System.Windows.Forms.TabPage
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents DGSNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgProdTypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPcsInCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPurchase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgSalePcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgSaleCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGReturnPcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGReturnCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGReturn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGClaimPcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGClaimCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGClaim As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDamagePcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDamageCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDamage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class

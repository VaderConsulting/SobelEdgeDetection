<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EdgeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EdgeForm))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.pbBefore = New System.Windows.Forms.PictureBox
        Me.pbAfter = New System.Windows.Forms.PictureBox
        Me.btnDetectGdi = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.ofdLoadImage = New System.Windows.Forms.OpenFileDialog
        Me.btnDetectDirect = New System.Windows.Forms.Button
        Me.btnPar = New System.Windows.Forms.Button
        Me.btnSerial = New System.Windows.Forms.Button
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.pbBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer
        '
        Me.SplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.AutoScroll = True
        Me.SplitContainer.Panel1.Controls.Add(Me.pbBefore)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.AutoScroll = True
        Me.SplitContainer.Panel2.Controls.Add(Me.pbAfter)
        Me.SplitContainer.Size = New System.Drawing.Size(630, 243)
        Me.SplitContainer.SplitterDistance = 315
        Me.SplitContainer.TabIndex = 2
        '
        'pbBefore
        '
        Me.pbBefore.Location = New System.Drawing.Point(0, 0)
        Me.pbBefore.Name = "pbBefore"
        Me.pbBefore.Size = New System.Drawing.Size(240, 214)
        Me.pbBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbBefore.TabIndex = 0
        Me.pbBefore.TabStop = False
        '
        'pbAfter
        '
        Me.pbAfter.Location = New System.Drawing.Point(0, 0)
        Me.pbAfter.Name = "pbAfter"
        Me.pbAfter.Size = New System.Drawing.Size(210, 186)
        Me.pbAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbAfter.TabIndex = 1
        Me.pbAfter.TabStop = False
        '
        'btnDetectGdi
        '
        Me.btnDetectGdi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDetectGdi.Location = New System.Drawing.Point(12, 261)
        Me.btnDetectGdi.Name = "btnDetectGdi"
        Me.btnDetectGdi.Size = New System.Drawing.Size(118, 23)
        Me.btnDetectGdi.TabIndex = 3
        Me.btnDetectGdi.Text = "Detect Edges (GDI)"
        Me.btnDetectGdi.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(547, 261)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(95, 23)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Text = "Load Image"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'ofdLoadImage
        '
        Me.ofdLoadImage.Filter = "Images (*.bmp, *.jpg)|*.jpg;*.bmp"
        '
        'btnDetectDirect
        '
        Me.btnDetectDirect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDetectDirect.Location = New System.Drawing.Point(136, 261)
        Me.btnDetectDirect.Name = "btnDetectDirect"
        Me.btnDetectDirect.Size = New System.Drawing.Size(132, 23)
        Me.btnDetectDirect.TabIndex = 3
        Me.btnDetectDirect.Text = "Detect Edges (Direct)"
        Me.btnDetectDirect.UseVisualStyleBackColor = True
        '
        'btnPar
        '
        Me.btnPar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPar.Location = New System.Drawing.Point(412, 261)
        Me.btnPar.Name = "btnPar"
        Me.btnPar.Size = New System.Drawing.Size(132, 23)
        Me.btnPar.TabIndex = 3
        Me.btnPar.Text = "Multi-Parallel (Direct)"
        Me.btnPar.UseVisualStyleBackColor = True
        '
        'btnSerial
        '
        Me.btnSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSerial.Location = New System.Drawing.Point(274, 261)
        Me.btnSerial.Name = "btnSerial"
        Me.btnSerial.Size = New System.Drawing.Size(132, 23)
        Me.btnSerial.TabIndex = 3
        Me.btnSerial.Text = "Multi-Serial (Direct)"
        Me.btnSerial.UseVisualStyleBackColor = True
        '
        'EdgeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 296)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSerial)
        Me.Controls.Add(Me.btnPar)
        Me.Controls.Add(Me.btnDetectDirect)
        Me.Controls.Add(Me.btnDetectGdi)
        Me.Controls.Add(Me.SplitContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(670, 330)
        Me.Name = "EdgeForm"
        Me.Text = "Visual Core: Sobel Edge Detection"
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.Panel2.PerformLayout()
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.pbBefore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAfter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbBefore As System.Windows.Forms.PictureBox
    Friend WithEvents pbAfter As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents btnDetectGdi As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents ofdLoadImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnDetectDirect As System.Windows.Forms.Button
    Friend WithEvents btnPar As System.Windows.Forms.Button
    Friend WithEvents btnSerial As System.Windows.Forms.Button

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWindowTips
#Region "Windows フォーム デザイナによって生成されたコード "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'この呼び出しは、Windows フォーム デザイナで必要です。
		InitializeComponent()
	End Sub
	'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows フォーム デザイナで必要です。
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents picIcon As System.Windows.Forms.PictureBox
	Public WithEvents tmrMain As System.Windows.Forms.Timer
	Public WithEvents chkNextDisp As System.Windows.Forms.CheckBox
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWindowTips))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.chkNextDisp = New System.Windows.Forms.CheckBox()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picIcon
        '
        Me.picIcon.BackColor = System.Drawing.SystemColors.Control
        Me.picIcon.Cursor = System.Windows.Forms.Cursors.Default
        Me.picIcon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
        Me.picIcon.Location = New System.Drawing.Point(0, 0)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picIcon.Size = New System.Drawing.Size(32, 64)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picIcon.TabIndex = 0
        Me.picIcon.Visible = False
        '
        'tmrMain
        '
        '
        'chkNextDisp
        '
        Me.chkNextDisp.BackColor = System.Drawing.SystemColors.Control
        Me.chkNextDisp.Checked = True
        Me.chkNextDisp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNextDisp.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNextDisp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNextDisp.Location = New System.Drawing.Point(8, 236)
        Me.chkNextDisp.Name = "chkNextDisp"
        Me.chkNextDisp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNextDisp.Size = New System.Drawing.Size(185, 17)
        Me.chkNextDisp.TabIndex = 1
        Me.chkNextDisp.Text = "Launch at next startup"
        Me.chkNextDisp.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNext.Location = New System.Drawing.Point(204, 232)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNext.Size = New System.Drawing.Size(101, 25)
        Me.cmdNext.TabIndex = 2
        Me.cmdNext.Text = "次へ"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(312, 232)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(97, 25)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "閉じる"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'frmWindowTips
        '
        Me.AcceptButton = Me.cmdNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(418, 264)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.chkNextDisp)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdClose)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(3, 19)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWindowTips"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "BMSE Tips (Sorry Japanese Language Only!!!!!!!111)"
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class
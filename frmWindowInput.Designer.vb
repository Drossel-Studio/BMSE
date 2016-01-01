<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWindowInput
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdDecide As System.Windows.Forms.Button
	Public WithEvents txtMain As System.Windows.Forms.TextBox
	Public WithEvents lblMainDisp As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWindowInput))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdDecide = New System.Windows.Forms.Button
		Me.txtMain = New System.Windows.Forms.TextBox
		Me.lblMainDisp = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "入力フォーム"
		Me.ClientSize = New System.Drawing.Size(266, 89)
		Me.Location = New System.Drawing.Point(3, 19)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmWindowInput"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(62, 19)
		Me.cmdCancel.Location = New System.Drawing.Point(198, 66)
		Me.cmdCancel.TabIndex = 3
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdDecide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDecide.Text = "OK"
		Me.AcceptButton = Me.cmdDecide
		Me.cmdDecide.Size = New System.Drawing.Size(89, 19)
		Me.cmdDecide.Location = New System.Drawing.Point(104, 66)
		Me.cmdDecide.TabIndex = 2
		Me.cmdDecide.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDecide.CausesValidation = True
		Me.cmdDecide.Enabled = True
		Me.cmdDecide.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDecide.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDecide.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDecide.TabStop = True
		Me.cmdDecide.Name = "cmdDecide"
		Me.txtMain.AutoSize = False
		Me.txtMain.Size = New System.Drawing.Size(257, 18)
		Me.txtMain.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtMain.Location = New System.Drawing.Point(4, 44)
		Me.txtMain.TabIndex = 1
		Me.txtMain.AcceptsReturn = True
		Me.txtMain.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMain.BackColor = System.Drawing.SystemColors.Window
		Me.txtMain.CausesValidation = True
		Me.txtMain.Enabled = True
		Me.txtMain.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMain.HideSelection = True
		Me.txtMain.ReadOnly = False
		Me.txtMain.Maxlength = 0
		Me.txtMain.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMain.MultiLine = False
		Me.txtMain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMain.TabStop = True
		Me.txtMain.Visible = True
		Me.txtMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMain.Name = "txtMain"
		Me.lblMainDisp.Text = "lblMainDisp"
		Me.lblMainDisp.Size = New System.Drawing.Size(251, 36)
		Me.lblMainDisp.Location = New System.Drawing.Point(8, 4)
		Me.lblMainDisp.TabIndex = 0
		Me.lblMainDisp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMainDisp.BackColor = System.Drawing.SystemColors.Control
		Me.lblMainDisp.Enabled = True
		Me.lblMainDisp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMainDisp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMainDisp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMainDisp.UseMnemonic = True
		Me.lblMainDisp.Visible = True
		Me.lblMainDisp.AutoSize = False
		Me.lblMainDisp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMainDisp.Name = "lblMainDisp"
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdDecide)
		Me.Controls.Add(txtMain)
		Me.Controls.Add(lblMainDisp)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
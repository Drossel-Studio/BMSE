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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdDecide = New System.Windows.Forms.Button()
        Me.txtMain = New System.Windows.Forms.TextBox()
        Me.lblMainDisp = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(198, 66)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(62, 19)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdDecide
        '
        Me.cmdDecide.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDecide.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDecide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDecide.Location = New System.Drawing.Point(104, 66)
        Me.cmdDecide.Name = "cmdDecide"
        Me.cmdDecide.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDecide.Size = New System.Drawing.Size(89, 19)
        Me.cmdDecide.TabIndex = 2
        Me.cmdDecide.Text = "OK"
        Me.cmdDecide.UseVisualStyleBackColor = False
        '
        'txtMain
        '
        Me.txtMain.AcceptsReturn = True
        Me.txtMain.BackColor = System.Drawing.SystemColors.Window
        Me.txtMain.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMain.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMain.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMain.Location = New System.Drawing.Point(4, 44)
        Me.txtMain.MaxLength = 0
        Me.txtMain.Name = "txtMain"
        Me.txtMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMain.Size = New System.Drawing.Size(257, 19)
        Me.txtMain.TabIndex = 1
        '
        'lblMainDisp
        '
        Me.lblMainDisp.BackColor = System.Drawing.SystemColors.Control
        Me.lblMainDisp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMainDisp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMainDisp.Location = New System.Drawing.Point(8, 4)
        Me.lblMainDisp.Name = "lblMainDisp"
        Me.lblMainDisp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMainDisp.Size = New System.Drawing.Size(251, 36)
        Me.lblMainDisp.TabIndex = 0
        Me.lblMainDisp.Text = "lblMainDisp"
        '
        'frmWindowInput
        '
        Me.AcceptButton = Me.cmdDecide
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(266, 89)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDecide)
        Me.Controls.Add(Me.txtMain)
        Me.Controls.Add(Me.lblMainDisp)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(3, 19)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWindowInput"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "入力フォーム"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class
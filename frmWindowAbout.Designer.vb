<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWindowAbout
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
	Public WithEvents tmrMain As System.Windows.Forms.Timer
	Public WithEvents picMain As System.Windows.Forms.Panel
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWindowAbout))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picMain = New System.Windows.Forms.Panel
		Me.tmrMain = New System.Windows.Forms.Timer(components)
		Me.picMain.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "About BMSE"
		Me.ClientSize = New System.Drawing.Size(526, 196)
		Me.Location = New System.Drawing.Point(3, 19)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Icon = CType(resources.GetObject("frmWindowAbout.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmWindowAbout"
		Me.picMain.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.picMain.Size = New System.Drawing.Size(526, 196)
		Me.picMain.Location = New System.Drawing.Point(0, 0)
		Me.picMain.BackgroundImage = CType(resources.GetObject("picMain.BackgroundImage"), System.Drawing.Image)
		Me.picMain.TabIndex = 0
		Me.picMain.Visible = False
		Me.picMain.Dock = System.Windows.Forms.DockStyle.None
		Me.picMain.BackColor = System.Drawing.SystemColors.Control
		Me.picMain.CausesValidation = True
		Me.picMain.Enabled = True
		Me.picMain.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picMain.Cursor = System.Windows.Forms.Cursors.Default
		Me.picMain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picMain.TabStop = True
		Me.picMain.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picMain.Name = "picMain"
		Me.tmrMain.Enabled = False
		Me.tmrMain.Interval = 100
		Me.Controls.Add(picMain)
		Me.picMain.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
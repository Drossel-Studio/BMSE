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
    Public WithEvents tmrMain As System.Windows.Forms.Timer
    Public WithEvents picMain As System.Windows.Forms.Panel
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWindowAbout))
        Me.picMain = New System.Windows.Forms.Panel()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'picMain
        '
        Me.picMain.BackColor = System.Drawing.SystemColors.Control
        Me.picMain.BackgroundImage = CType(resources.GetObject("picMain.BackgroundImage"), System.Drawing.Image)
        Me.picMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.picMain.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.picMain.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picMain.Location = New System.Drawing.Point(0, 0)
        Me.picMain.Name = "picMain"
        Me.picMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picMain.Size = New System.Drawing.Size(526, 196)
        Me.picMain.TabIndex = 0
        Me.picMain.TabStop = True
        Me.picMain.Visible = False
        '
        'tmrMain
        '
        '
        'frmWindowAbout
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(526, 196)
        Me.Controls.Add(Me.picMain)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 19)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWindowAbout"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "About BMSE"
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class
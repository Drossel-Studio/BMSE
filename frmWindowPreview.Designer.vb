<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWindowPreview
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
	Public WithEvents cmdPreviewBack As System.Windows.Forms.Button
	Public WithEvents cmdPreviewNext As System.Windows.Forms.Button
	Public WithEvents cmdPreviewEnd As System.Windows.Forms.Button
	Public WithEvents cmdPreviewHome As System.Windows.Forms.Button
	Public WithEvents fraBGACmd As System.Windows.Forms.GroupBox
	Public WithEvents cmdCopy As System.Windows.Forms.Button
	Public WithEvents chkLock As System.Windows.Forms.CheckBox
	Public WithEvents chkBGLine As System.Windows.Forms.CheckBox
	Public WithEvents _txtBGAPara_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtBGAPara_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtBGAPara_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtBGAPara_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtBGAPara_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtBGAPara_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtBGAPara_6 As System.Windows.Forms.TextBox
	Public WithEvents _lblBGAPara_0 As System.Windows.Forms.Label
	Public WithEvents _lblBGAPara_1 As System.Windows.Forms.Label
	Public WithEvents _lblBGAPara_2 As System.Windows.Forms.Label
	Public WithEvents _lblBGAPara_3 As System.Windows.Forms.Label
	Public WithEvents _lblBGAPara_4 As System.Windows.Forms.Label
	Public WithEvents _lblBGAPara_5 As System.Windows.Forms.Label
	Public WithEvents _lblBGAPara_6 As System.Windows.Forms.Label
	Public WithEvents fraBGAPara As System.Windows.Forms.GroupBox
	Public WithEvents picBackBuffer As System.Windows.Forms.PictureBox
	Public WithEvents picPreview As System.Windows.Forms.PictureBox
	Public WithEvents lblBGAPara As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtBGAPara As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWindowPreview))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.fraBGACmd = New System.Windows.Forms.GroupBox
		Me.cmdPreviewBack = New System.Windows.Forms.Button
		Me.cmdPreviewNext = New System.Windows.Forms.Button
		Me.cmdPreviewEnd = New System.Windows.Forms.Button
		Me.cmdPreviewHome = New System.Windows.Forms.Button
		Me.fraBGAPara = New System.Windows.Forms.GroupBox
		Me.cmdCopy = New System.Windows.Forms.Button
		Me.chkLock = New System.Windows.Forms.CheckBox
		Me.chkBGLine = New System.Windows.Forms.CheckBox
		Me._txtBGAPara_0 = New System.Windows.Forms.TextBox
		Me._txtBGAPara_1 = New System.Windows.Forms.TextBox
		Me._txtBGAPara_2 = New System.Windows.Forms.TextBox
		Me._txtBGAPara_3 = New System.Windows.Forms.TextBox
		Me._txtBGAPara_4 = New System.Windows.Forms.TextBox
		Me._txtBGAPara_5 = New System.Windows.Forms.TextBox
		Me._txtBGAPara_6 = New System.Windows.Forms.TextBox
		Me._lblBGAPara_0 = New System.Windows.Forms.Label
		Me._lblBGAPara_1 = New System.Windows.Forms.Label
		Me._lblBGAPara_2 = New System.Windows.Forms.Label
		Me._lblBGAPara_3 = New System.Windows.Forms.Label
		Me._lblBGAPara_4 = New System.Windows.Forms.Label
		Me._lblBGAPara_5 = New System.Windows.Forms.Label
		Me._lblBGAPara_6 = New System.Windows.Forms.Label
		Me.picBackBuffer = New System.Windows.Forms.PictureBox
		Me.picPreview = New System.Windows.Forms.PictureBox
		Me.lblBGAPara = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txtBGAPara = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.fraBGACmd.SuspendLayout()
		Me.fraBGAPara.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblBGAPara, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtBGAPara, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
		Me.Text = "Preview Window"
		Me.ClientSize = New System.Drawing.Size(414, 256)
		Me.Location = New System.Drawing.Point(4, 20)
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
		Me.Name = "frmWindowPreview"
		Me.fraBGACmd.Size = New System.Drawing.Size(152, 21)
		Me.fraBGACmd.Location = New System.Drawing.Point(260, 234)
		Me.fraBGACmd.TabIndex = 20
		Me.fraBGACmd.BackColor = System.Drawing.SystemColors.Control
		Me.fraBGACmd.Enabled = True
		Me.fraBGACmd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraBGACmd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraBGACmd.Visible = True
		Me.fraBGACmd.Padding = New System.Windows.Forms.Padding(0)
		Me.fraBGACmd.Name = "fraBGACmd"
		Me.cmdPreviewBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPreviewBack.Text = "<"
		Me.cmdPreviewBack.Size = New System.Drawing.Size(25, 21)
		Me.cmdPreviewBack.Location = New System.Drawing.Point(32, 0)
		Me.cmdPreviewBack.TabIndex = 22
		Me.cmdPreviewBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPreviewBack.CausesValidation = True
		Me.cmdPreviewBack.Enabled = True
		Me.cmdPreviewBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPreviewBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPreviewBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPreviewBack.TabStop = True
		Me.cmdPreviewBack.Name = "cmdPreviewBack"
		Me.cmdPreviewNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPreviewNext.Text = ">"
		Me.cmdPreviewNext.Size = New System.Drawing.Size(25, 21)
		Me.cmdPreviewNext.Location = New System.Drawing.Point(64, 0)
		Me.cmdPreviewNext.TabIndex = 23
		Me.cmdPreviewNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPreviewNext.CausesValidation = True
		Me.cmdPreviewNext.Enabled = True
		Me.cmdPreviewNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPreviewNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPreviewNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPreviewNext.TabStop = True
		Me.cmdPreviewNext.Name = "cmdPreviewNext"
		Me.cmdPreviewEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPreviewEnd.Text = "ZZ"
		Me.cmdPreviewEnd.Size = New System.Drawing.Size(25, 21)
		Me.cmdPreviewEnd.Location = New System.Drawing.Point(96, 0)
		Me.cmdPreviewEnd.TabIndex = 24
		Me.cmdPreviewEnd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPreviewEnd.CausesValidation = True
		Me.cmdPreviewEnd.Enabled = True
		Me.cmdPreviewEnd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPreviewEnd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPreviewEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPreviewEnd.TabStop = True
		Me.cmdPreviewEnd.Name = "cmdPreviewEnd"
		Me.cmdPreviewHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPreviewHome.Text = "01"
		Me.cmdPreviewHome.Size = New System.Drawing.Size(25, 21)
		Me.cmdPreviewHome.Location = New System.Drawing.Point(0, 0)
		Me.cmdPreviewHome.TabIndex = 21
		Me.cmdPreviewHome.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPreviewHome.CausesValidation = True
		Me.cmdPreviewHome.Enabled = True
		Me.cmdPreviewHome.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPreviewHome.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPreviewHome.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPreviewHome.TabStop = True
		Me.cmdPreviewHome.Name = "cmdPreviewHome"
		Me.fraBGAPara.Size = New System.Drawing.Size(153, 157)
		Me.fraBGAPara.Location = New System.Drawing.Point(260, 0)
		Me.fraBGAPara.TabIndex = 2
		Me.fraBGAPara.BackColor = System.Drawing.SystemColors.Control
		Me.fraBGAPara.Enabled = True
		Me.fraBGAPara.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraBGAPara.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraBGAPara.Visible = True
		Me.fraBGAPara.Padding = New System.Windows.Forms.Padding(0)
		Me.fraBGAPara.Name = "fraBGAPara"
		Me.cmdCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCopy.Text = "Copy"
		Me.cmdCopy.Size = New System.Drawing.Size(67, 21)
		Me.cmdCopy.Location = New System.Drawing.Point(5, 90)
		Me.cmdCopy.TabIndex = 17
		Me.cmdCopy.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCopy.CausesValidation = True
		Me.cmdCopy.Enabled = True
		Me.cmdCopy.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCopy.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCopy.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCopy.TabStop = True
		Me.cmdCopy.Name = "cmdCopy"
		Me.chkLock.Text = "Lock"
		Me.chkLock.Size = New System.Drawing.Size(141, 17)
		Me.chkLock.Location = New System.Drawing.Point(4, 135)
		Me.chkLock.TabIndex = 19
		Me.chkLock.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkLock.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkLock.BackColor = System.Drawing.SystemColors.Control
		Me.chkLock.CausesValidation = True
		Me.chkLock.Enabled = True
		Me.chkLock.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkLock.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkLock.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkLock.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkLock.TabStop = True
		Me.chkLock.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkLock.Visible = True
		Me.chkLock.Name = "chkLock"
		Me.chkBGLine.Text = "BG-Line"
		Me.chkBGLine.Size = New System.Drawing.Size(141, 17)
		Me.chkBGLine.Location = New System.Drawing.Point(4, 117)
		Me.chkBGLine.TabIndex = 18
		Me.chkBGLine.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkBGLine.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkBGLine.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkBGLine.BackColor = System.Drawing.SystemColors.Control
		Me.chkBGLine.CausesValidation = True
		Me.chkBGLine.Enabled = True
		Me.chkBGLine.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkBGLine.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkBGLine.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkBGLine.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkBGLine.TabStop = True
		Me.chkBGLine.Visible = True
		Me.chkBGLine.Name = "chkBGLine"
		Me._txtBGAPara_0.AutoSize = False
		Me._txtBGAPara_0.Enabled = False
		Me._txtBGAPara_0.Size = New System.Drawing.Size(46, 18)
        Me._txtBGAPara_0.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me._txtBGAPara_0.Location = New System.Drawing.Point(26, 0)
        Me._txtBGAPara_0.MaxLength = 8
        Me._txtBGAPara_0.TabIndex = 4
		Me._txtBGAPara_0.Text = "01"
		Me._txtBGAPara_0.AcceptsReturn = True
		Me._txtBGAPara_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtBGAPara_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtBGAPara_0.CausesValidation = True
		Me._txtBGAPara_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtBGAPara_0.HideSelection = True
		Me._txtBGAPara_0.ReadOnly = False
		Me._txtBGAPara_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtBGAPara_0.Multiline = False
        Me._txtBGAPara_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtBGAPara_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtBGAPara_0.TabStop = True
		Me._txtBGAPara_0.Visible = True
		Me._txtBGAPara_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtBGAPara_0.Name = "_txtBGAPara_0"
		Me._txtBGAPara_1.AutoSize = False
		Me._txtBGAPara_1.Size = New System.Drawing.Size(46, 18)
        Me._txtBGAPara_1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me._txtBGAPara_1.Location = New System.Drawing.Point(26, 24)
        Me._txtBGAPara_1.MaxLength = 8
        Me._txtBGAPara_1.TabIndex = 6
		Me._txtBGAPara_1.Text = "0"
		Me._txtBGAPara_1.AcceptsReturn = True
		Me._txtBGAPara_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtBGAPara_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtBGAPara_1.CausesValidation = True
		Me._txtBGAPara_1.Enabled = True
		Me._txtBGAPara_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtBGAPara_1.HideSelection = True
		Me._txtBGAPara_1.ReadOnly = False
		Me._txtBGAPara_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtBGAPara_1.Multiline = False
        Me._txtBGAPara_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtBGAPara_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtBGAPara_1.TabStop = True
		Me._txtBGAPara_1.Visible = True
		Me._txtBGAPara_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtBGAPara_1.Name = "_txtBGAPara_1"
		Me._txtBGAPara_2.AutoSize = False
		Me._txtBGAPara_2.Size = New System.Drawing.Size(46, 18)
        Me._txtBGAPara_2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me._txtBGAPara_2.Location = New System.Drawing.Point(104, 22)
        Me._txtBGAPara_2.MaxLength = 8
        Me._txtBGAPara_2.TabIndex = 8
		Me._txtBGAPara_2.Text = "0"
		Me._txtBGAPara_2.AcceptsReturn = True
		Me._txtBGAPara_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtBGAPara_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtBGAPara_2.CausesValidation = True
		Me._txtBGAPara_2.Enabled = True
		Me._txtBGAPara_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtBGAPara_2.HideSelection = True
		Me._txtBGAPara_2.ReadOnly = False
		Me._txtBGAPara_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtBGAPara_2.Multiline = False
        Me._txtBGAPara_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtBGAPara_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtBGAPara_2.TabStop = True
		Me._txtBGAPara_2.Visible = True
		Me._txtBGAPara_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtBGAPara_2.Name = "_txtBGAPara_2"
		Me._txtBGAPara_3.AutoSize = False
		Me._txtBGAPara_3.Size = New System.Drawing.Size(46, 18)
        Me._txtBGAPara_3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me._txtBGAPara_3.Location = New System.Drawing.Point(26, 44)
        Me._txtBGAPara_3.MaxLength = 8
        Me._txtBGAPara_3.TabIndex = 10
		Me._txtBGAPara_3.Text = "0"
		Me._txtBGAPara_3.AcceptsReturn = True
		Me._txtBGAPara_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtBGAPara_3.BackColor = System.Drawing.SystemColors.Window
		Me._txtBGAPara_3.CausesValidation = True
		Me._txtBGAPara_3.Enabled = True
		Me._txtBGAPara_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtBGAPara_3.HideSelection = True
		Me._txtBGAPara_3.ReadOnly = False
		Me._txtBGAPara_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtBGAPara_3.Multiline = False
        Me._txtBGAPara_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtBGAPara_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtBGAPara_3.TabStop = True
		Me._txtBGAPara_3.Visible = True
		Me._txtBGAPara_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtBGAPara_3.Name = "_txtBGAPara_3"
		Me._txtBGAPara_4.AutoSize = False
		Me._txtBGAPara_4.Size = New System.Drawing.Size(46, 18)
        Me._txtBGAPara_4.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me._txtBGAPara_4.Location = New System.Drawing.Point(104, 44)
        Me._txtBGAPara_4.MaxLength = 8
        Me._txtBGAPara_4.TabIndex = 12
		Me._txtBGAPara_4.Text = "0"
		Me._txtBGAPara_4.AcceptsReturn = True
		Me._txtBGAPara_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtBGAPara_4.BackColor = System.Drawing.SystemColors.Window
		Me._txtBGAPara_4.CausesValidation = True
		Me._txtBGAPara_4.Enabled = True
		Me._txtBGAPara_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtBGAPara_4.HideSelection = True
		Me._txtBGAPara_4.ReadOnly = False
		Me._txtBGAPara_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtBGAPara_4.Multiline = False
        Me._txtBGAPara_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtBGAPara_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtBGAPara_4.TabStop = True
		Me._txtBGAPara_4.Visible = True
		Me._txtBGAPara_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtBGAPara_4.Name = "_txtBGAPara_4"
		Me._txtBGAPara_5.AutoSize = False
		Me._txtBGAPara_5.Size = New System.Drawing.Size(46, 18)
        Me._txtBGAPara_5.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me._txtBGAPara_5.Location = New System.Drawing.Point(26, 65)
        Me._txtBGAPara_5.MaxLength = 8
        Me._txtBGAPara_5.TabIndex = 14
		Me._txtBGAPara_5.Text = "0"
		Me._txtBGAPara_5.AcceptsReturn = True
		Me._txtBGAPara_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtBGAPara_5.BackColor = System.Drawing.SystemColors.Window
		Me._txtBGAPara_5.CausesValidation = True
		Me._txtBGAPara_5.Enabled = True
		Me._txtBGAPara_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtBGAPara_5.HideSelection = True
		Me._txtBGAPara_5.ReadOnly = False
		Me._txtBGAPara_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtBGAPara_5.Multiline = False
        Me._txtBGAPara_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtBGAPara_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtBGAPara_5.TabStop = True
		Me._txtBGAPara_5.Visible = True
		Me._txtBGAPara_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtBGAPara_5.Name = "_txtBGAPara_5"
		Me._txtBGAPara_6.AutoSize = False
		Me._txtBGAPara_6.Size = New System.Drawing.Size(46, 18)
        Me._txtBGAPara_6.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me._txtBGAPara_6.Location = New System.Drawing.Point(104, 65)
        Me._txtBGAPara_6.MaxLength = 8
        Me._txtBGAPara_6.TabIndex = 16
		Me._txtBGAPara_6.Text = "0"
		Me._txtBGAPara_6.AcceptsReturn = True
		Me._txtBGAPara_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtBGAPara_6.BackColor = System.Drawing.SystemColors.Window
		Me._txtBGAPara_6.CausesValidation = True
		Me._txtBGAPara_6.Enabled = True
		Me._txtBGAPara_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtBGAPara_6.HideSelection = True
		Me._txtBGAPara_6.ReadOnly = False
		Me._txtBGAPara_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtBGAPara_6.Multiline = False
        Me._txtBGAPara_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtBGAPara_6.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtBGAPara_6.TabStop = True
		Me._txtBGAPara_6.Visible = True
		Me._txtBGAPara_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtBGAPara_6.Name = "_txtBGAPara_6"
		Me._lblBGAPara_0.Text = "Num"
		Me._lblBGAPara_0.Size = New System.Drawing.Size(18, 12)
		Me._lblBGAPara_0.Location = New System.Drawing.Point(4, 4)
		Me._lblBGAPara_0.TabIndex = 3
		Me._lblBGAPara_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblBGAPara_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblBGAPara_0.Enabled = True
		Me._lblBGAPara_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblBGAPara_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblBGAPara_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblBGAPara_0.UseMnemonic = True
		Me._lblBGAPara_0.Visible = True
		Me._lblBGAPara_0.AutoSize = True
		Me._lblBGAPara_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblBGAPara_0.Name = "_lblBGAPara_0"
		Me._lblBGAPara_1.Text = "X1"
		Me._lblBGAPara_1.Size = New System.Drawing.Size(12, 12)
		Me._lblBGAPara_1.Location = New System.Drawing.Point(4, 26)
		Me._lblBGAPara_1.TabIndex = 5
		Me._lblBGAPara_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblBGAPara_1.BackColor = System.Drawing.SystemColors.Control
		Me._lblBGAPara_1.Enabled = True
		Me._lblBGAPara_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblBGAPara_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblBGAPara_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblBGAPara_1.UseMnemonic = True
		Me._lblBGAPara_1.Visible = True
		Me._lblBGAPara_1.AutoSize = True
		Me._lblBGAPara_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblBGAPara_1.Name = "_lblBGAPara_1"
		Me._lblBGAPara_2.Text = "Y1"
		Me._lblBGAPara_2.Size = New System.Drawing.Size(12, 12)
		Me._lblBGAPara_2.Location = New System.Drawing.Point(82, 26)
		Me._lblBGAPara_2.TabIndex = 7
		Me._lblBGAPara_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblBGAPara_2.BackColor = System.Drawing.SystemColors.Control
		Me._lblBGAPara_2.Enabled = True
		Me._lblBGAPara_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblBGAPara_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblBGAPara_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblBGAPara_2.UseMnemonic = True
		Me._lblBGAPara_2.Visible = True
		Me._lblBGAPara_2.AutoSize = True
		Me._lblBGAPara_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblBGAPara_2.Name = "_lblBGAPara_2"
		Me._lblBGAPara_3.Text = "X2"
		Me._lblBGAPara_3.Size = New System.Drawing.Size(12, 12)
		Me._lblBGAPara_3.Location = New System.Drawing.Point(4, 48)
		Me._lblBGAPara_3.TabIndex = 9
		Me._lblBGAPara_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblBGAPara_3.BackColor = System.Drawing.SystemColors.Control
		Me._lblBGAPara_3.Enabled = True
		Me._lblBGAPara_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblBGAPara_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblBGAPara_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblBGAPara_3.UseMnemonic = True
		Me._lblBGAPara_3.Visible = True
		Me._lblBGAPara_3.AutoSize = True
		Me._lblBGAPara_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblBGAPara_3.Name = "_lblBGAPara_3"
		Me._lblBGAPara_4.Text = "Y2"
		Me._lblBGAPara_4.Size = New System.Drawing.Size(12, 12)
		Me._lblBGAPara_4.Location = New System.Drawing.Point(82, 48)
		Me._lblBGAPara_4.TabIndex = 11
		Me._lblBGAPara_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblBGAPara_4.BackColor = System.Drawing.SystemColors.Control
		Me._lblBGAPara_4.Enabled = True
		Me._lblBGAPara_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblBGAPara_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblBGAPara_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblBGAPara_4.UseMnemonic = True
		Me._lblBGAPara_4.Visible = True
		Me._lblBGAPara_4.AutoSize = True
		Me._lblBGAPara_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblBGAPara_4.Name = "_lblBGAPara_4"
		Me._lblBGAPara_5.Text = "dX"
		Me._lblBGAPara_5.Size = New System.Drawing.Size(12, 12)
		Me._lblBGAPara_5.Location = New System.Drawing.Point(4, 69)
		Me._lblBGAPara_5.TabIndex = 13
		Me._lblBGAPara_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblBGAPara_5.BackColor = System.Drawing.SystemColors.Control
		Me._lblBGAPara_5.Enabled = True
		Me._lblBGAPara_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblBGAPara_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblBGAPara_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblBGAPara_5.UseMnemonic = True
		Me._lblBGAPara_5.Visible = True
		Me._lblBGAPara_5.AutoSize = True
		Me._lblBGAPara_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblBGAPara_5.Name = "_lblBGAPara_5"
		Me._lblBGAPara_6.Text = "dY"
		Me._lblBGAPara_6.Size = New System.Drawing.Size(12, 12)
		Me._lblBGAPara_6.Location = New System.Drawing.Point(82, 69)
		Me._lblBGAPara_6.TabIndex = 15
		Me._lblBGAPara_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblBGAPara_6.BackColor = System.Drawing.SystemColors.Control
		Me._lblBGAPara_6.Enabled = True
		Me._lblBGAPara_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblBGAPara_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblBGAPara_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblBGAPara_6.UseMnemonic = True
		Me._lblBGAPara_6.Visible = True
		Me._lblBGAPara_6.AutoSize = True
		Me._lblBGAPara_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblBGAPara_6.Name = "_lblBGAPara_6"
		Me.picBackBuffer.BackColor = System.Drawing.Color.Black
		Me.picBackBuffer.Size = New System.Drawing.Size(61, 36)
		Me.picBackBuffer.Location = New System.Drawing.Point(0, 0)
		Me.picBackBuffer.TabIndex = 0
		Me.picBackBuffer.Visible = False
		Me.picBackBuffer.Dock = System.Windows.Forms.DockStyle.None
		Me.picBackBuffer.CausesValidation = True
		Me.picBackBuffer.Enabled = True
		Me.picBackBuffer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picBackBuffer.Cursor = System.Windows.Forms.Cursors.Default
		Me.picBackBuffer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picBackBuffer.TabStop = True
		Me.picBackBuffer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.picBackBuffer.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picBackBuffer.Name = "picBackBuffer"
		Me.picPreview.BackColor = System.Drawing.Color.Black
		Me.picPreview.ForeColor = System.Drawing.Color.Green
		Me.picPreview.Size = New System.Drawing.Size(61, 37)
		Me.picPreview.Location = New System.Drawing.Point(0, 40)
		Me.picPreview.TabIndex = 1
		Me.picPreview.Dock = System.Windows.Forms.DockStyle.None
		Me.picPreview.CausesValidation = True
		Me.picPreview.Enabled = True
		Me.picPreview.Cursor = System.Windows.Forms.Cursors.Default
		Me.picPreview.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picPreview.TabStop = True
		Me.picPreview.Visible = True
		Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picPreview.Name = "picPreview"
		Me.Controls.Add(fraBGACmd)
		Me.Controls.Add(fraBGAPara)
		Me.Controls.Add(picBackBuffer)
		Me.Controls.Add(picPreview)
		Me.fraBGACmd.Controls.Add(cmdPreviewBack)
		Me.fraBGACmd.Controls.Add(cmdPreviewNext)
		Me.fraBGACmd.Controls.Add(cmdPreviewEnd)
		Me.fraBGACmd.Controls.Add(cmdPreviewHome)
		Me.fraBGAPara.Controls.Add(cmdCopy)
		Me.fraBGAPara.Controls.Add(chkLock)
		Me.fraBGAPara.Controls.Add(chkBGLine)
		Me.fraBGAPara.Controls.Add(_txtBGAPara_0)
		Me.fraBGAPara.Controls.Add(_txtBGAPara_1)
		Me.fraBGAPara.Controls.Add(_txtBGAPara_2)
		Me.fraBGAPara.Controls.Add(_txtBGAPara_3)
		Me.fraBGAPara.Controls.Add(_txtBGAPara_4)
		Me.fraBGAPara.Controls.Add(_txtBGAPara_5)
		Me.fraBGAPara.Controls.Add(_txtBGAPara_6)
		Me.fraBGAPara.Controls.Add(_lblBGAPara_0)
		Me.fraBGAPara.Controls.Add(_lblBGAPara_1)
		Me.fraBGAPara.Controls.Add(_lblBGAPara_2)
		Me.fraBGAPara.Controls.Add(_lblBGAPara_3)
		Me.fraBGAPara.Controls.Add(_lblBGAPara_4)
		Me.fraBGAPara.Controls.Add(_lblBGAPara_5)
		Me.fraBGAPara.Controls.Add(_lblBGAPara_6)
		Me.lblBGAPara.SetIndex(_lblBGAPara_0, CType(0, Short))
		Me.lblBGAPara.SetIndex(_lblBGAPara_1, CType(1, Short))
		Me.lblBGAPara.SetIndex(_lblBGAPara_2, CType(2, Short))
		Me.lblBGAPara.SetIndex(_lblBGAPara_3, CType(3, Short))
		Me.lblBGAPara.SetIndex(_lblBGAPara_4, CType(4, Short))
		Me.lblBGAPara.SetIndex(_lblBGAPara_5, CType(5, Short))
		Me.lblBGAPara.SetIndex(_lblBGAPara_6, CType(6, Short))
		Me.txtBGAPara.SetIndex(_txtBGAPara_0, CType(0, Short))
		Me.txtBGAPara.SetIndex(_txtBGAPara_1, CType(1, Short))
		Me.txtBGAPara.SetIndex(_txtBGAPara_2, CType(2, Short))
		Me.txtBGAPara.SetIndex(_txtBGAPara_3, CType(3, Short))
		Me.txtBGAPara.SetIndex(_txtBGAPara_4, CType(4, Short))
		Me.txtBGAPara.SetIndex(_txtBGAPara_5, CType(5, Short))
		Me.txtBGAPara.SetIndex(_txtBGAPara_6, CType(6, Short))
		CType(Me.txtBGAPara, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblBGAPara, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraBGACmd.ResumeLayout(False)
		Me.fraBGAPara.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
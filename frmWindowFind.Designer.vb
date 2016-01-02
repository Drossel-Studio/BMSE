<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWindowFind
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
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdDecide As System.Windows.Forms.Button
	Public WithEvents txtReplace As System.Windows.Forms.TextBox
	Public WithEvents optProcessReplace As System.Windows.Forms.RadioButton
	Public WithEvents optProcessDelete As System.Windows.Forms.RadioButton
	Public WithEvents optProcessSelect As System.Windows.Forms.RadioButton
	Public WithEvents fraProcess As System.Windows.Forms.GroupBox
	Public WithEvents cmdInvert As System.Windows.Forms.Button
	Public WithEvents cmdReset As System.Windows.Forms.Button
	Public WithEvents cmdSelect As System.Windows.Forms.Button
	Public WithEvents _lstGrid_2 As System.Windows.Forms.CheckedListBox
	Public WithEvents _lstGrid_1 As System.Windows.Forms.CheckedListBox
	Public WithEvents _lstGrid_0 As System.Windows.Forms.CheckedListBox
	Public WithEvents _lstGrid_3 As System.Windows.Forms.CheckedListBox
	Public WithEvents lblBGM As System.Windows.Forms.Label
	Public WithEvents lblPlayer2 As System.Windows.Forms.Label
	Public WithEvents lblPlayer1 As System.Windows.Forms.Label
	Public WithEvents lblEtc As System.Windows.Forms.Label
	Public WithEvents fraSearchGrid As System.Windows.Forms.GroupBox
	Public WithEvents txtNumMax As System.Windows.Forms.TextBox
	Public WithEvents txtNumMin As System.Windows.Forms.TextBox
	Public WithEvents lblNotice As System.Windows.Forms.Label
	Public WithEvents lblNum As System.Windows.Forms.Label
	Public WithEvents fraSearchNum As System.Windows.Forms.GroupBox
	Public WithEvents txtMeasureMax As System.Windows.Forms.TextBox
	Public WithEvents txtMeasureMin As System.Windows.Forms.TextBox
	Public WithEvents lblMeasure As System.Windows.Forms.Label
	Public WithEvents fraSearchMeasure As System.Windows.Forms.GroupBox
	Public WithEvents optSearchSelect As System.Windows.Forms.RadioButton
	Public WithEvents optSearchAll As System.Windows.Forms.RadioButton
	Public WithEvents fraSearchObject As System.Windows.Forms.GroupBox
	Public WithEvents lstGrid As Microsoft.VisualBasic.Compatibility.VB6.CheckedListBoxArray
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWindowFind))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdDecide = New System.Windows.Forms.Button
		Me.fraProcess = New System.Windows.Forms.GroupBox
		Me.txtReplace = New System.Windows.Forms.TextBox
		Me.optProcessReplace = New System.Windows.Forms.RadioButton
		Me.optProcessDelete = New System.Windows.Forms.RadioButton
		Me.optProcessSelect = New System.Windows.Forms.RadioButton
		Me.fraSearchGrid = New System.Windows.Forms.GroupBox
		Me.cmdInvert = New System.Windows.Forms.Button
		Me.cmdReset = New System.Windows.Forms.Button
		Me.cmdSelect = New System.Windows.Forms.Button
		Me._lstGrid_2 = New System.Windows.Forms.CheckedListBox
		Me._lstGrid_1 = New System.Windows.Forms.CheckedListBox
		Me._lstGrid_0 = New System.Windows.Forms.CheckedListBox
		Me._lstGrid_3 = New System.Windows.Forms.CheckedListBox
		Me.lblBGM = New System.Windows.Forms.Label
		Me.lblPlayer2 = New System.Windows.Forms.Label
		Me.lblPlayer1 = New System.Windows.Forms.Label
		Me.lblEtc = New System.Windows.Forms.Label
		Me.fraSearchNum = New System.Windows.Forms.GroupBox
		Me.txtNumMax = New System.Windows.Forms.TextBox
		Me.txtNumMin = New System.Windows.Forms.TextBox
		Me.lblNotice = New System.Windows.Forms.Label
		Me.lblNum = New System.Windows.Forms.Label
		Me.fraSearchMeasure = New System.Windows.Forms.GroupBox
		Me.txtMeasureMax = New System.Windows.Forms.TextBox
		Me.txtMeasureMin = New System.Windows.Forms.TextBox
		Me.lblMeasure = New System.Windows.Forms.Label
		Me.fraSearchObject = New System.Windows.Forms.GroupBox
		Me.optSearchSelect = New System.Windows.Forms.RadioButton
		Me.optSearchAll = New System.Windows.Forms.RadioButton
		Me.lstGrid = New Microsoft.VisualBasic.Compatibility.VB6.CheckedListBoxArray(components)
		Me.fraProcess.SuspendLayout()
		Me.fraSearchGrid.SuspendLayout()
		Me.fraSearchNum.SuspendLayout()
		Me.fraSearchMeasure.SuspendLayout()
		Me.fraSearchObject.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lstGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "検索・削除・置換"
		Me.ClientSize = New System.Drawing.Size(566, 193)
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
		Me.Name = "frmWindowFind"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "閉じる"
		Me.cmdClose.Size = New System.Drawing.Size(125, 25)
		Me.cmdClose.Location = New System.Drawing.Point(436, 136)
		Me.cmdClose.TabIndex = 29
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdDecide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDecide.Text = "実行"
		Me.AcceptButton = Me.cmdDecide
		Me.cmdDecide.Size = New System.Drawing.Size(125, 25)
		Me.cmdDecide.Location = New System.Drawing.Point(436, 164)
		Me.cmdDecide.TabIndex = 30
		Me.cmdDecide.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDecide.CausesValidation = True
		Me.cmdDecide.Enabled = True
		Me.cmdDecide.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDecide.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDecide.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDecide.TabStop = True
		Me.cmdDecide.Name = "cmdDecide"
		Me.fraProcess.Text = "処理"
		Me.fraProcess.Size = New System.Drawing.Size(125, 81)
		Me.fraProcess.Location = New System.Drawing.Point(436, 4)
		Me.fraProcess.TabIndex = 24
		Me.fraProcess.BackColor = System.Drawing.SystemColors.Control
		Me.fraProcess.Enabled = True
		Me.fraProcess.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraProcess.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraProcess.Visible = True
		Me.fraProcess.Padding = New System.Windows.Forms.Padding(0)
		Me.fraProcess.Name = "fraProcess"
		Me.txtReplace.AutoSize = False
		Me.txtReplace.Size = New System.Drawing.Size(25, 18)
		Me.txtReplace.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtReplace.Location = New System.Drawing.Point(92, 56)
		Me.txtReplace.MaxLength = 2
		Me.txtReplace.TabIndex = 28
		Me.txtReplace.Text = "01"
		Me.txtReplace.AcceptsReturn = True
		Me.txtReplace.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtReplace.BackColor = System.Drawing.SystemColors.Window
		Me.txtReplace.CausesValidation = True
		Me.txtReplace.Enabled = True
		Me.txtReplace.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtReplace.HideSelection = True
		Me.txtReplace.ReadOnly = False
		Me.txtReplace.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtReplace.Multiline = False
		Me.txtReplace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtReplace.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtReplace.TabStop = True
		Me.txtReplace.Visible = True
		Me.txtReplace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtReplace.Name = "txtReplace"
		Me.optProcessReplace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optProcessReplace.Text = "置換"
		Me.optProcessReplace.Size = New System.Drawing.Size(109, 21)
		Me.optProcessReplace.Location = New System.Drawing.Point(8, 56)
		Me.optProcessReplace.TabIndex = 27
		Me.optProcessReplace.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optProcessReplace.BackColor = System.Drawing.SystemColors.Control
		Me.optProcessReplace.CausesValidation = True
		Me.optProcessReplace.Enabled = True
		Me.optProcessReplace.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optProcessReplace.Cursor = System.Windows.Forms.Cursors.Default
		Me.optProcessReplace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optProcessReplace.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optProcessReplace.TabStop = True
		Me.optProcessReplace.Checked = False
		Me.optProcessReplace.Visible = True
		Me.optProcessReplace.Name = "optProcessReplace"
		Me.optProcessDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optProcessDelete.Text = "削除"
		Me.optProcessDelete.Size = New System.Drawing.Size(109, 21)
		Me.optProcessDelete.Location = New System.Drawing.Point(8, 36)
		Me.optProcessDelete.TabIndex = 26
		Me.optProcessDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optProcessDelete.BackColor = System.Drawing.SystemColors.Control
		Me.optProcessDelete.CausesValidation = True
		Me.optProcessDelete.Enabled = True
		Me.optProcessDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optProcessDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.optProcessDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optProcessDelete.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optProcessDelete.TabStop = True
		Me.optProcessDelete.Checked = False
		Me.optProcessDelete.Visible = True
		Me.optProcessDelete.Name = "optProcessDelete"
		Me.optProcessSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optProcessSelect.Text = "選択"
		Me.optProcessSelect.Size = New System.Drawing.Size(109, 21)
		Me.optProcessSelect.Location = New System.Drawing.Point(8, 16)
		Me.optProcessSelect.TabIndex = 25
		Me.optProcessSelect.Checked = True
		Me.optProcessSelect.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optProcessSelect.BackColor = System.Drawing.SystemColors.Control
		Me.optProcessSelect.CausesValidation = True
		Me.optProcessSelect.Enabled = True
		Me.optProcessSelect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optProcessSelect.Cursor = System.Windows.Forms.Cursors.Default
		Me.optProcessSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optProcessSelect.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optProcessSelect.TabStop = True
		Me.optProcessSelect.Visible = True
		Me.optProcessSelect.Name = "optProcessSelect"
		Me.fraSearchGrid.Text = "列の指定"
		Me.fraSearchGrid.Size = New System.Drawing.Size(237, 185)
		Me.fraSearchGrid.Location = New System.Drawing.Point(192, 4)
		Me.fraSearchGrid.TabIndex = 12
		Me.fraSearchGrid.BackColor = System.Drawing.SystemColors.Control
		Me.fraSearchGrid.Enabled = True
		Me.fraSearchGrid.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraSearchGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraSearchGrid.Visible = True
		Me.fraSearchGrid.Padding = New System.Windows.Forms.Padding(0)
		Me.fraSearchGrid.Name = "fraSearchGrid"
		Me.cmdInvert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdInvert.Text = "反転"
		Me.cmdInvert.Size = New System.Drawing.Size(61, 21)
		Me.cmdInvert.Location = New System.Drawing.Point(20, 156)
		Me.cmdInvert.TabIndex = 21
		Me.cmdInvert.BackColor = System.Drawing.SystemColors.Control
		Me.cmdInvert.CausesValidation = True
		Me.cmdInvert.Enabled = True
		Me.cmdInvert.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdInvert.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdInvert.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdInvert.TabStop = True
		Me.cmdInvert.Name = "cmdInvert"
		Me.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReset.Text = "全解除"
		Me.cmdReset.Size = New System.Drawing.Size(61, 21)
		Me.cmdReset.Location = New System.Drawing.Point(84, 156)
		Me.cmdReset.TabIndex = 22
		Me.cmdReset.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReset.CausesValidation = True
		Me.cmdReset.Enabled = True
		Me.cmdReset.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReset.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReset.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReset.TabStop = True
		Me.cmdReset.Name = "cmdReset"
		Me.cmdSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelect.Text = "全選択"
		Me.cmdSelect.Size = New System.Drawing.Size(81, 21)
		Me.cmdSelect.Location = New System.Drawing.Point(148, 156)
		Me.cmdSelect.TabIndex = 23
		Me.cmdSelect.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelect.CausesValidation = True
		Me.cmdSelect.Enabled = True
		Me.cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelect.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelect.TabStop = True
		Me.cmdSelect.Name = "cmdSelect"
		Me._lstGrid_2.Size = New System.Drawing.Size(53, 116)
		Me._lstGrid_2.Location = New System.Drawing.Point(120, 36)
		Me._lstGrid_2.Items.AddRange(New Object(){"01"})
		Me._lstGrid_2.TabIndex = 18
		Me._lstGrid_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstGrid_2.BackColor = System.Drawing.SystemColors.Window
		Me._lstGrid_2.CausesValidation = True
		Me._lstGrid_2.Enabled = True
		Me._lstGrid_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstGrid_2.IntegralHeight = True
		Me._lstGrid_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lstGrid_2.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me._lstGrid_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lstGrid_2.Sorted = False
		Me._lstGrid_2.TabStop = True
		Me._lstGrid_2.Visible = True
		Me._lstGrid_2.MultiColumn = False
		Me._lstGrid_2.Name = "_lstGrid_2"
		Me._lstGrid_1.Size = New System.Drawing.Size(53, 116)
		Me._lstGrid_1.Location = New System.Drawing.Point(64, 36)
		Me._lstGrid_1.Items.AddRange(New Object(){"1", "2", "3", "4", "5", "6", "7", "SC"})
		Me._lstGrid_1.TabIndex = 16
		Me._lstGrid_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstGrid_1.BackColor = System.Drawing.SystemColors.Window
		Me._lstGrid_1.CausesValidation = True
		Me._lstGrid_1.Enabled = True
		Me._lstGrid_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstGrid_1.IntegralHeight = True
		Me._lstGrid_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lstGrid_1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me._lstGrid_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lstGrid_1.Sorted = False
		Me._lstGrid_1.TabStop = True
		Me._lstGrid_1.Visible = True
		Me._lstGrid_1.MultiColumn = False
		Me._lstGrid_1.Name = "_lstGrid_1"
		Me._lstGrid_0.Size = New System.Drawing.Size(53, 116)
		Me._lstGrid_0.Location = New System.Drawing.Point(8, 36)
		Me._lstGrid_0.Items.AddRange(New Object(){"1", "2", "3", "4", "5", "6", "7", "SC"})
		Me._lstGrid_0.TabIndex = 14
		Me._lstGrid_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstGrid_0.BackColor = System.Drawing.SystemColors.Window
		Me._lstGrid_0.CausesValidation = True
		Me._lstGrid_0.Enabled = True
		Me._lstGrid_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstGrid_0.IntegralHeight = True
		Me._lstGrid_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lstGrid_0.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me._lstGrid_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lstGrid_0.Sorted = False
		Me._lstGrid_0.TabStop = True
		Me._lstGrid_0.Visible = True
		Me._lstGrid_0.MultiColumn = False
		Me._lstGrid_0.Name = "_lstGrid_0"
		Me._lstGrid_3.Size = New System.Drawing.Size(53, 116)
		Me._lstGrid_3.Location = New System.Drawing.Point(176, 36)
		Me._lstGrid_3.Items.AddRange(New Object(){"BPM", "STOP", "BGA", "Layer", "Poor"})
		Me._lstGrid_3.TabIndex = 20
		Me._lstGrid_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstGrid_3.BackColor = System.Drawing.SystemColors.Window
		Me._lstGrid_3.CausesValidation = True
		Me._lstGrid_3.Enabled = True
		Me._lstGrid_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstGrid_3.IntegralHeight = True
		Me._lstGrid_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lstGrid_3.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me._lstGrid_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lstGrid_3.Sorted = False
		Me._lstGrid_3.TabStop = True
		Me._lstGrid_3.Visible = True
		Me._lstGrid_3.MultiColumn = False
		Me._lstGrid_3.Name = "_lstGrid_3"
		Me.lblBGM.Text = "BGM"
		Me.lblBGM.Size = New System.Drawing.Size(18, 12)
		Me.lblBGM.Location = New System.Drawing.Point(120, 20)
		Me.lblBGM.TabIndex = 17
		Me.lblBGM.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblBGM.BackColor = System.Drawing.SystemColors.Control
		Me.lblBGM.Enabled = True
		Me.lblBGM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblBGM.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblBGM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblBGM.UseMnemonic = True
		Me.lblBGM.Visible = True
		Me.lblBGM.AutoSize = True
		Me.lblBGM.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblBGM.Name = "lblBGM"
		Me.lblPlayer2.Text = "Player 2"
		Me.lblPlayer2.Size = New System.Drawing.Size(48, 12)
		Me.lblPlayer2.Location = New System.Drawing.Point(64, 20)
		Me.lblPlayer2.TabIndex = 15
		Me.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlayer2.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlayer2.Enabled = True
		Me.lblPlayer2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlayer2.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlayer2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlayer2.UseMnemonic = True
		Me.lblPlayer2.Visible = True
		Me.lblPlayer2.AutoSize = True
		Me.lblPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlayer2.Name = "lblPlayer2"
		Me.lblPlayer1.Text = "Player 1"
		Me.lblPlayer1.Size = New System.Drawing.Size(48, 12)
		Me.lblPlayer1.Location = New System.Drawing.Point(8, 20)
		Me.lblPlayer1.TabIndex = 13
		Me.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlayer1.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlayer1.Enabled = True
		Me.lblPlayer1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlayer1.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlayer1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlayer1.UseMnemonic = True
		Me.lblPlayer1.Visible = True
		Me.lblPlayer1.AutoSize = True
		Me.lblPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlayer1.Name = "lblPlayer1"
		Me.lblEtc.Text = "Etc"
		Me.lblEtc.Size = New System.Drawing.Size(18, 12)
		Me.lblEtc.Location = New System.Drawing.Point(176, 20)
		Me.lblEtc.TabIndex = 19
		Me.lblEtc.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblEtc.BackColor = System.Drawing.SystemColors.Control
		Me.lblEtc.Enabled = True
		Me.lblEtc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEtc.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEtc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEtc.UseMnemonic = True
		Me.lblEtc.Visible = True
		Me.lblEtc.AutoSize = True
		Me.lblEtc.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEtc.Name = "lblEtc"
		Me.fraSearchNum.Text = "オブジェ番号の指定"
		Me.fraSearchNum.Size = New System.Drawing.Size(177, 78)
		Me.fraSearchNum.Location = New System.Drawing.Point(8, 112)
		Me.fraSearchNum.TabIndex = 7
		Me.fraSearchNum.BackColor = System.Drawing.SystemColors.Control
		Me.fraSearchNum.Enabled = True
		Me.fraSearchNum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraSearchNum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraSearchNum.Visible = True
		Me.fraSearchNum.Padding = New System.Windows.Forms.Padding(0)
		Me.fraSearchNum.Name = "fraSearchNum"
		Me.txtNumMax.AutoSize = False
		Me.txtNumMax.Size = New System.Drawing.Size(37, 18)
        Me.txtNumMax.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNumMax.Location = New System.Drawing.Point(92, 16)
        Me.txtNumMax.MaxLength = 2
        Me.txtNumMax.TabIndex = 10
		Me.txtNumMax.Text = "ZZ"
		Me.txtNumMax.AcceptsReturn = True
		Me.txtNumMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNumMax.BackColor = System.Drawing.SystemColors.Window
		Me.txtNumMax.CausesValidation = True
		Me.txtNumMax.Enabled = True
		Me.txtNumMax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNumMax.HideSelection = True
		Me.txtNumMax.ReadOnly = False
		Me.txtNumMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumMax.Multiline = False
        Me.txtNumMax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNumMax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNumMax.TabStop = True
		Me.txtNumMax.Visible = True
		Me.txtNumMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNumMax.Name = "txtNumMax"
		Me.txtNumMin.AutoSize = False
		Me.txtNumMin.Size = New System.Drawing.Size(37, 18)
        Me.txtNumMin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNumMin.Location = New System.Drawing.Point(28, 16)
        Me.txtNumMin.MaxLength = 2
        Me.txtNumMin.TabIndex = 8
		Me.txtNumMin.Text = "01"
		Me.txtNumMin.AcceptsReturn = True
		Me.txtNumMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNumMin.BackColor = System.Drawing.SystemColors.Window
		Me.txtNumMin.CausesValidation = True
		Me.txtNumMin.Enabled = True
		Me.txtNumMin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNumMin.HideSelection = True
		Me.txtNumMin.ReadOnly = False
		Me.txtNumMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumMin.Multiline = False
        Me.txtNumMin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNumMin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNumMin.TabStop = True
		Me.txtNumMin.Visible = True
		Me.txtNumMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNumMin.Name = "txtNumMin"
		Me.lblNotice.Text = "This item doesn't influence BPM/STOP object"
		Me.lblNotice.Size = New System.Drawing.Size(161, 28)
		Me.lblNotice.Location = New System.Drawing.Point(8, 39)
		Me.lblNotice.TabIndex = 11
		Me.lblNotice.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNotice.BackColor = System.Drawing.SystemColors.Control
		Me.lblNotice.Enabled = True
		Me.lblNotice.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNotice.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNotice.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNotice.UseMnemonic = True
		Me.lblNotice.Visible = True
		Me.lblNotice.AutoSize = False
		Me.lblNotice.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNotice.Name = "lblNotice"
		Me.lblNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblNum.Text = "～"
		Me.lblNum.Size = New System.Drawing.Size(12, 12)
		Me.lblNum.Location = New System.Drawing.Point(72, 20)
		Me.lblNum.TabIndex = 9
		Me.lblNum.BackColor = System.Drawing.SystemColors.Control
		Me.lblNum.Enabled = True
		Me.lblNum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNum.UseMnemonic = True
		Me.lblNum.Visible = True
		Me.lblNum.AutoSize = True
		Me.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNum.Name = "lblNum"
		Me.fraSearchMeasure.Text = "小節範囲の指定"
		Me.fraSearchMeasure.Size = New System.Drawing.Size(177, 41)
		Me.fraSearchMeasure.Location = New System.Drawing.Point(8, 68)
		Me.fraSearchMeasure.TabIndex = 3
		Me.fraSearchMeasure.BackColor = System.Drawing.SystemColors.Control
		Me.fraSearchMeasure.Enabled = True
		Me.fraSearchMeasure.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraSearchMeasure.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraSearchMeasure.Visible = True
		Me.fraSearchMeasure.Padding = New System.Windows.Forms.Padding(0)
		Me.fraSearchMeasure.Name = "fraSearchMeasure"
		Me.txtMeasureMax.AutoSize = False
		Me.txtMeasureMax.Size = New System.Drawing.Size(37, 18)
        Me.txtMeasureMax.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtMeasureMax.Location = New System.Drawing.Point(92, 16)
        Me.txtMeasureMax.MaxLength = 3
        Me.txtMeasureMax.TabIndex = 6
		Me.txtMeasureMax.Text = "999"
		Me.txtMeasureMax.AcceptsReturn = True
		Me.txtMeasureMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMeasureMax.BackColor = System.Drawing.SystemColors.Window
		Me.txtMeasureMax.CausesValidation = True
		Me.txtMeasureMax.Enabled = True
		Me.txtMeasureMax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMeasureMax.HideSelection = True
		Me.txtMeasureMax.ReadOnly = False
		Me.txtMeasureMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMeasureMax.Multiline = False
        Me.txtMeasureMax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMeasureMax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMeasureMax.TabStop = True
		Me.txtMeasureMax.Visible = True
		Me.txtMeasureMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMeasureMax.Name = "txtMeasureMax"
		Me.txtMeasureMin.AutoSize = False
		Me.txtMeasureMin.Size = New System.Drawing.Size(37, 18)
		Me.txtMeasureMin.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtMeasureMin.Location = New System.Drawing.Point(28, 16)
        Me.txtMeasureMin.MaxLength = 3
        Me.txtMeasureMin.TabIndex = 4
		Me.txtMeasureMin.Text = "0"
		Me.txtMeasureMin.AcceptsReturn = True
		Me.txtMeasureMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMeasureMin.BackColor = System.Drawing.SystemColors.Window
		Me.txtMeasureMin.CausesValidation = True
		Me.txtMeasureMin.Enabled = True
		Me.txtMeasureMin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMeasureMin.HideSelection = True
		Me.txtMeasureMin.ReadOnly = False
		Me.txtMeasureMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMeasureMin.Multiline = False
        Me.txtMeasureMin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMeasureMin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMeasureMin.TabStop = True
		Me.txtMeasureMin.Visible = True
		Me.txtMeasureMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMeasureMin.Name = "txtMeasureMin"
		Me.lblMeasure.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblMeasure.Text = "～"
		Me.lblMeasure.Size = New System.Drawing.Size(12, 12)
		Me.lblMeasure.Location = New System.Drawing.Point(72, 20)
		Me.lblMeasure.TabIndex = 5
		Me.lblMeasure.BackColor = System.Drawing.SystemColors.Control
		Me.lblMeasure.Enabled = True
		Me.lblMeasure.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMeasure.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMeasure.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMeasure.UseMnemonic = True
		Me.lblMeasure.Visible = True
		Me.lblMeasure.AutoSize = True
		Me.lblMeasure.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMeasure.Name = "lblMeasure"
		Me.fraSearchObject.Text = "選択対象"
		Me.fraSearchObject.Size = New System.Drawing.Size(177, 61)
		Me.fraSearchObject.Location = New System.Drawing.Point(8, 4)
		Me.fraSearchObject.TabIndex = 0
		Me.fraSearchObject.BackColor = System.Drawing.SystemColors.Control
		Me.fraSearchObject.Enabled = True
		Me.fraSearchObject.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraSearchObject.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraSearchObject.Visible = True
		Me.fraSearchObject.Padding = New System.Windows.Forms.Padding(0)
		Me.fraSearchObject.Name = "fraSearchObject"
		Me.optSearchSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSearchSelect.Text = "選択されているオブジェ"
		Me.optSearchSelect.Size = New System.Drawing.Size(161, 17)
		Me.optSearchSelect.Location = New System.Drawing.Point(8, 36)
		Me.optSearchSelect.TabIndex = 2
		Me.optSearchSelect.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSearchSelect.BackColor = System.Drawing.SystemColors.Control
		Me.optSearchSelect.CausesValidation = True
		Me.optSearchSelect.Enabled = True
		Me.optSearchSelect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optSearchSelect.Cursor = System.Windows.Forms.Cursors.Default
		Me.optSearchSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optSearchSelect.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optSearchSelect.TabStop = True
		Me.optSearchSelect.Checked = False
		Me.optSearchSelect.Visible = True
		Me.optSearchSelect.Name = "optSearchSelect"
		Me.optSearchAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSearchAll.Text = "全てのオブジェ"
		Me.optSearchAll.Size = New System.Drawing.Size(161, 17)
		Me.optSearchAll.Location = New System.Drawing.Point(8, 16)
		Me.optSearchAll.TabIndex = 1
		Me.optSearchAll.Checked = True
		Me.optSearchAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSearchAll.BackColor = System.Drawing.SystemColors.Control
		Me.optSearchAll.CausesValidation = True
		Me.optSearchAll.Enabled = True
		Me.optSearchAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optSearchAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.optSearchAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optSearchAll.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optSearchAll.TabStop = True
		Me.optSearchAll.Visible = True
		Me.optSearchAll.Name = "optSearchAll"
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(cmdDecide)
		Me.Controls.Add(fraProcess)
		Me.Controls.Add(fraSearchGrid)
		Me.Controls.Add(fraSearchNum)
		Me.Controls.Add(fraSearchMeasure)
		Me.Controls.Add(fraSearchObject)
		Me.fraProcess.Controls.Add(txtReplace)
		Me.fraProcess.Controls.Add(optProcessReplace)
		Me.fraProcess.Controls.Add(optProcessDelete)
		Me.fraProcess.Controls.Add(optProcessSelect)
		Me.fraSearchGrid.Controls.Add(cmdInvert)
		Me.fraSearchGrid.Controls.Add(cmdReset)
		Me.fraSearchGrid.Controls.Add(cmdSelect)
		Me.fraSearchGrid.Controls.Add(_lstGrid_2)
		Me.fraSearchGrid.Controls.Add(_lstGrid_1)
		Me.fraSearchGrid.Controls.Add(_lstGrid_0)
		Me.fraSearchGrid.Controls.Add(_lstGrid_3)
		Me.fraSearchGrid.Controls.Add(lblBGM)
		Me.fraSearchGrid.Controls.Add(lblPlayer2)
		Me.fraSearchGrid.Controls.Add(lblPlayer1)
		Me.fraSearchGrid.Controls.Add(lblEtc)
		Me.fraSearchNum.Controls.Add(txtNumMax)
		Me.fraSearchNum.Controls.Add(txtNumMin)
		Me.fraSearchNum.Controls.Add(lblNotice)
		Me.fraSearchNum.Controls.Add(lblNum)
		Me.fraSearchMeasure.Controls.Add(txtMeasureMax)
		Me.fraSearchMeasure.Controls.Add(txtMeasureMin)
		Me.fraSearchMeasure.Controls.Add(lblMeasure)
		Me.fraSearchObject.Controls.Add(optSearchSelect)
		Me.fraSearchObject.Controls.Add(optSearchAll)
		Me.lstGrid.SetIndex(_lstGrid_2, CType(2, Short))
		Me.lstGrid.SetIndex(_lstGrid_1, CType(1, Short))
		Me.lstGrid.SetIndex(_lstGrid_0, CType(0, Short))
		Me.lstGrid.SetIndex(_lstGrid_3, CType(3, Short))
		CType(Me.lstGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraProcess.ResumeLayout(False)
		Me.fraSearchGrid.ResumeLayout(False)
		Me.fraSearchNum.ResumeLayout(False)
		Me.fraSearchMeasure.ResumeLayout(False)
		Me.fraSearchObject.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
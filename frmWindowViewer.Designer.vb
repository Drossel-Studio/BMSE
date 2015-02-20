<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWindowViewer
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
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents txtStop As System.Windows.Forms.TextBox
	Public WithEvents txtPlay As System.Windows.Forms.TextBox
	Public WithEvents txtPlayAll As System.Windows.Forms.TextBox
	Public WithEvents cmdViewerPath As System.Windows.Forms.Button
	Public WithEvents txtViewerPath As System.Windows.Forms.TextBox
	Public WithEvents txtViewerName As System.Windows.Forms.TextBox
	Public WithEvents lblNotice As System.Windows.Forms.Label
	Public WithEvents lblStop As System.Windows.Forms.Label
	Public WithEvents lblPlay As System.Windows.Forms.Label
	Public WithEvents lblPlayAll As System.Windows.Forms.Label
	Public WithEvents lblViewerPath As System.Windows.Forms.Label
	Public WithEvents lblViewerName As System.Windows.Forms.Label
	Public WithEvents fraViewer As System.Windows.Forms.GroupBox
	Public WithEvents lstViewer As System.Windows.Forms.ListBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWindowViewer))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.fraViewer = New System.Windows.Forms.GroupBox
		Me.txtStop = New System.Windows.Forms.TextBox
		Me.txtPlay = New System.Windows.Forms.TextBox
		Me.txtPlayAll = New System.Windows.Forms.TextBox
		Me.cmdViewerPath = New System.Windows.Forms.Button
		Me.txtViewerPath = New System.Windows.Forms.TextBox
		Me.txtViewerName = New System.Windows.Forms.TextBox
		Me.lblNotice = New System.Windows.Forms.Label
		Me.lblStop = New System.Windows.Forms.Label
		Me.lblPlay = New System.Windows.Forms.Label
		Me.lblPlayAll = New System.Windows.Forms.Label
		Me.lblViewerPath = New System.Windows.Forms.Label
		Me.lblViewerName = New System.Windows.Forms.Label
		Me.lstViewer = New System.Windows.Forms.ListBox
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.fraViewer.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "Viewer Config"
		Me.ClientSize = New System.Drawing.Size(400, 323)
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
		Me.Name = "frmWindowViewer"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "削除"
		Me.cmdDelete.Size = New System.Drawing.Size(53, 21)
		Me.cmdDelete.Location = New System.Drawing.Point(36, 264)
		Me.cmdDelete.TabIndex = 1
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.TabStop = True
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAdd.Text = "追加"
		Me.cmdAdd.Size = New System.Drawing.Size(53, 21)
		Me.cmdAdd.Location = New System.Drawing.Point(96, 264)
		Me.cmdAdd.TabIndex = 2
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.Enabled = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.TabStop = True
		Me.cmdAdd.Name = "cmdAdd"
		Me.fraViewer.Size = New System.Drawing.Size(237, 281)
		Me.fraViewer.Location = New System.Drawing.Point(156, 4)
		Me.fraViewer.TabIndex = 3
		Me.fraViewer.BackColor = System.Drawing.SystemColors.Control
		Me.fraViewer.Enabled = True
		Me.fraViewer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraViewer.Visible = True
		Me.fraViewer.Padding = New System.Windows.Forms.Padding(0)
		Me.fraViewer.Name = "fraViewer"
		Me.txtStop.AutoSize = False
		Me.txtStop.Size = New System.Drawing.Size(221, 18)
		Me.txtStop.Location = New System.Drawing.Point(8, 204)
		Me.txtStop.TabIndex = 14
		Me.txtStop.AcceptsReturn = True
		Me.txtStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtStop.BackColor = System.Drawing.SystemColors.Window
		Me.txtStop.CausesValidation = True
		Me.txtStop.Enabled = True
		Me.txtStop.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtStop.HideSelection = True
		Me.txtStop.ReadOnly = False
		Me.txtStop.Maxlength = 0
		Me.txtStop.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtStop.MultiLine = False
		Me.txtStop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtStop.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtStop.TabStop = True
		Me.txtStop.Visible = True
		Me.txtStop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtStop.Name = "txtStop"
		Me.txtPlay.AutoSize = False
		Me.txtPlay.Size = New System.Drawing.Size(221, 18)
		Me.txtPlay.Location = New System.Drawing.Point(8, 160)
		Me.txtPlay.TabIndex = 12
		Me.txtPlay.AcceptsReturn = True
		Me.txtPlay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPlay.BackColor = System.Drawing.SystemColors.Window
		Me.txtPlay.CausesValidation = True
		Me.txtPlay.Enabled = True
		Me.txtPlay.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPlay.HideSelection = True
		Me.txtPlay.ReadOnly = False
		Me.txtPlay.Maxlength = 0
		Me.txtPlay.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPlay.MultiLine = False
		Me.txtPlay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPlay.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPlay.TabStop = True
		Me.txtPlay.Visible = True
		Me.txtPlay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPlay.Name = "txtPlay"
		Me.txtPlayAll.AutoSize = False
		Me.txtPlayAll.Size = New System.Drawing.Size(221, 18)
		Me.txtPlayAll.Location = New System.Drawing.Point(8, 116)
		Me.txtPlayAll.TabIndex = 10
		Me.txtPlayAll.AcceptsReturn = True
		Me.txtPlayAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPlayAll.BackColor = System.Drawing.SystemColors.Window
		Me.txtPlayAll.CausesValidation = True
		Me.txtPlayAll.Enabled = True
		Me.txtPlayAll.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPlayAll.HideSelection = True
		Me.txtPlayAll.ReadOnly = False
		Me.txtPlayAll.Maxlength = 0
		Me.txtPlayAll.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPlayAll.MultiLine = False
		Me.txtPlayAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPlayAll.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPlayAll.TabStop = True
		Me.txtPlayAll.Visible = True
		Me.txtPlayAll.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPlayAll.Name = "txtPlayAll"
		Me.cmdViewerPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdViewerPath.Text = "参照"
		Me.cmdViewerPath.Size = New System.Drawing.Size(37, 17)
		Me.cmdViewerPath.Location = New System.Drawing.Point(192, 72)
		Me.cmdViewerPath.TabIndex = 8
		Me.cmdViewerPath.BackColor = System.Drawing.SystemColors.Control
		Me.cmdViewerPath.CausesValidation = True
		Me.cmdViewerPath.Enabled = True
		Me.cmdViewerPath.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdViewerPath.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdViewerPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdViewerPath.TabStop = True
		Me.cmdViewerPath.Name = "cmdViewerPath"
		Me.txtViewerPath.AutoSize = False
		Me.txtViewerPath.Size = New System.Drawing.Size(181, 18)
		Me.txtViewerPath.Location = New System.Drawing.Point(8, 72)
		Me.txtViewerPath.TabIndex = 7
		Me.txtViewerPath.AcceptsReturn = True
		Me.txtViewerPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtViewerPath.BackColor = System.Drawing.SystemColors.Window
		Me.txtViewerPath.CausesValidation = True
		Me.txtViewerPath.Enabled = True
		Me.txtViewerPath.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtViewerPath.HideSelection = True
		Me.txtViewerPath.ReadOnly = False
		Me.txtViewerPath.Maxlength = 0
		Me.txtViewerPath.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtViewerPath.MultiLine = False
		Me.txtViewerPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtViewerPath.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtViewerPath.TabStop = True
		Me.txtViewerPath.Visible = True
		Me.txtViewerPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtViewerPath.Name = "txtViewerPath"
		Me.txtViewerName.AutoSize = False
		Me.txtViewerName.Size = New System.Drawing.Size(221, 18)
		Me.txtViewerName.Location = New System.Drawing.Point(8, 28)
		Me.txtViewerName.TabIndex = 5
		Me.txtViewerName.AcceptsReturn = True
		Me.txtViewerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtViewerName.BackColor = System.Drawing.SystemColors.Window
		Me.txtViewerName.CausesValidation = True
		Me.txtViewerName.Enabled = True
		Me.txtViewerName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtViewerName.HideSelection = True
		Me.txtViewerName.ReadOnly = False
		Me.txtViewerName.Maxlength = 0
		Me.txtViewerName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtViewerName.MultiLine = False
		Me.txtViewerName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtViewerName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtViewerName.TabStop = True
		Me.txtViewerName.Visible = True
		Me.txtViewerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtViewerName.Name = "txtViewerName"
		Me.lblNotice.Text = "lblNotice"
		Me.lblNotice.Size = New System.Drawing.Size(221, 41)
		Me.lblNotice.Location = New System.Drawing.Point(8, 232)
		Me.lblNotice.TabIndex = 15
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
		Me.lblStop.Text = "「停止」の引数"
		Me.lblStop.Size = New System.Drawing.Size(213, 13)
		Me.lblStop.Location = New System.Drawing.Point(12, 188)
		Me.lblStop.TabIndex = 13
		Me.lblStop.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblStop.BackColor = System.Drawing.SystemColors.Control
		Me.lblStop.Enabled = True
		Me.lblStop.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblStop.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStop.UseMnemonic = True
		Me.lblStop.Visible = True
		Me.lblStop.AutoSize = False
		Me.lblStop.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblStop.Name = "lblStop"
		Me.lblPlay.Text = "「現在位置から再生」の引数"
		Me.lblPlay.Size = New System.Drawing.Size(213, 13)
		Me.lblPlay.Location = New System.Drawing.Point(12, 144)
		Me.lblPlay.TabIndex = 11
		Me.lblPlay.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlay.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlay.Enabled = True
		Me.lblPlay.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlay.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlay.UseMnemonic = True
		Me.lblPlay.Visible = True
		Me.lblPlay.AutoSize = False
		Me.lblPlay.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlay.Name = "lblPlay"
		Me.lblPlayAll.Text = "「最初から再生」の引数"
		Me.lblPlayAll.Size = New System.Drawing.Size(213, 13)
		Me.lblPlayAll.Location = New System.Drawing.Point(12, 100)
		Me.lblPlayAll.TabIndex = 9
		Me.lblPlayAll.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlayAll.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlayAll.Enabled = True
		Me.lblPlayAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlayAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlayAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlayAll.UseMnemonic = True
		Me.lblPlayAll.Visible = True
		Me.lblPlayAll.AutoSize = False
		Me.lblPlayAll.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlayAll.Name = "lblPlayAll"
		Me.lblViewerPath.Text = "実行ファイルのパス"
		Me.lblViewerPath.Size = New System.Drawing.Size(213, 13)
		Me.lblViewerPath.Location = New System.Drawing.Point(12, 56)
		Me.lblViewerPath.TabIndex = 6
		Me.lblViewerPath.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblViewerPath.BackColor = System.Drawing.SystemColors.Control
		Me.lblViewerPath.Enabled = True
		Me.lblViewerPath.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblViewerPath.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblViewerPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblViewerPath.UseMnemonic = True
		Me.lblViewerPath.Visible = True
		Me.lblViewerPath.AutoSize = False
		Me.lblViewerPath.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblViewerPath.Name = "lblViewerPath"
		Me.lblViewerName.Text = "表示する名前"
		Me.lblViewerName.Size = New System.Drawing.Size(213, 13)
		Me.lblViewerName.Location = New System.Drawing.Point(12, 12)
		Me.lblViewerName.TabIndex = 4
		Me.lblViewerName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblViewerName.BackColor = System.Drawing.SystemColors.Control
		Me.lblViewerName.Enabled = True
		Me.lblViewerName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblViewerName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblViewerName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblViewerName.UseMnemonic = True
		Me.lblViewerName.Visible = True
		Me.lblViewerName.AutoSize = False
		Me.lblViewerName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblViewerName.Name = "lblViewerName"
		Me.lstViewer.Size = New System.Drawing.Size(141, 247)
		Me.lstViewer.Location = New System.Drawing.Point(8, 12)
		Me.lstViewer.TabIndex = 0
		Me.lstViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstViewer.BackColor = System.Drawing.SystemColors.Window
		Me.lstViewer.CausesValidation = True
		Me.lstViewer.Enabled = True
		Me.lstViewer.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstViewer.IntegralHeight = True
		Me.lstViewer.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstViewer.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstViewer.Sorted = False
		Me.lstViewer.TabStop = True
		Me.lstViewer.Visible = True
		Me.lstViewer.MultiColumn = False
		Me.lstViewer.Name = "lstViewer"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
		Me.cmdCancel.Location = New System.Drawing.Point(320, 292)
		Me.cmdCancel.TabIndex = 17
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.AcceptButton = Me.cmdOK
		Me.cmdOK.Size = New System.Drawing.Size(97, 25)
		Me.cmdOK.Location = New System.Drawing.Point(216, 292)
		Me.cmdOK.TabIndex = 16
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.Controls.Add(cmdDelete)
		Me.Controls.Add(cmdAdd)
		Me.Controls.Add(fraViewer)
		Me.Controls.Add(lstViewer)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdOK)
		Me.fraViewer.Controls.Add(txtStop)
		Me.fraViewer.Controls.Add(txtPlay)
		Me.fraViewer.Controls.Add(txtPlayAll)
		Me.fraViewer.Controls.Add(cmdViewerPath)
		Me.fraViewer.Controls.Add(txtViewerPath)
		Me.fraViewer.Controls.Add(txtViewerName)
		Me.fraViewer.Controls.Add(lblNotice)
		Me.fraViewer.Controls.Add(lblStop)
		Me.fraViewer.Controls.Add(lblPlay)
		Me.fraViewer.Controls.Add(lblPlayAll)
		Me.fraViewer.Controls.Add(lblViewerPath)
		Me.fraViewer.Controls.Add(lblViewerName)
		Me.fraViewer.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
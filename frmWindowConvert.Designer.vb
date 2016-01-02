<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWindowConvert
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
	Public WithEvents chkSortByName As System.Windows.Forms.CheckBox
	Public WithEvents chkFileRecycle As System.Windows.Forms.CheckBox
	Public WithEvents chkDeleteFile As System.Windows.Forms.CheckBox
	Public WithEvents txtExtension As System.Windows.Forms.TextBox
	Public WithEvents chkFileNameConvert As System.Windows.Forms.CheckBox
	Public WithEvents chkUseOldFormat As System.Windows.Forms.CheckBox
	Public WithEvents chkListAlign As System.Windows.Forms.CheckBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdDecide As System.Windows.Forms.Button
	Public WithEvents chkDeleteUnusedFile As System.Windows.Forms.CheckBox
	Public WithEvents lblNotice As System.Windows.Forms.Label
	Public WithEvents lblExtension As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWindowConvert))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.chkSortByName = New System.Windows.Forms.CheckBox
		Me.chkFileRecycle = New System.Windows.Forms.CheckBox
		Me.chkDeleteFile = New System.Windows.Forms.CheckBox
		Me.txtExtension = New System.Windows.Forms.TextBox
		Me.chkFileNameConvert = New System.Windows.Forms.CheckBox
		Me.chkUseOldFormat = New System.Windows.Forms.CheckBox
		Me.chkListAlign = New System.Windows.Forms.CheckBox
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdDecide = New System.Windows.Forms.Button
		Me.chkDeleteUnusedFile = New System.Windows.Forms.CheckBox
		Me.lblNotice = New System.Windows.Forms.Label
		Me.lblExtension = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "変換ウィザード"
		Me.ClientSize = New System.Drawing.Size(312, 330)
		Me.Location = New System.Drawing.Point(3, 19)
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
		Me.Name = "frmWindowConvert"
		Me.chkSortByName.Text = "ファイル名順でソートする"
		Me.chkSortByName.Enabled = False
		Me.chkSortByName.Size = New System.Drawing.Size(289, 25)
		Me.chkSortByName.Location = New System.Drawing.Point(24, 184)
		Me.chkSortByName.TabIndex = 11
		Me.chkSortByName.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkSortByName.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkSortByName.BackColor = System.Drawing.SystemColors.Control
		Me.chkSortByName.CausesValidation = True
		Me.chkSortByName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkSortByName.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSortByName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSortByName.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSortByName.TabStop = True
		Me.chkSortByName.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSortByName.Visible = True
		Me.chkSortByName.Name = "chkSortByName"
		Me.chkFileRecycle.Text = "ごみ箱に移動しないですぐに削除する"
		Me.chkFileRecycle.Enabled = False
		Me.chkFileRecycle.Size = New System.Drawing.Size(289, 25)
		Me.chkFileRecycle.Location = New System.Drawing.Point(24, 96)
		Me.chkFileRecycle.TabIndex = 6
		Me.chkFileRecycle.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkFileRecycle.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkFileRecycle.BackColor = System.Drawing.SystemColors.Control
		Me.chkFileRecycle.CausesValidation = True
		Me.chkFileRecycle.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFileRecycle.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFileRecycle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFileRecycle.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFileRecycle.TabStop = True
		Me.chkFileRecycle.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkFileRecycle.Visible = True
		Me.chkFileRecycle.Name = "chkFileRecycle"
		Me.chkDeleteFile.Text = "フォルダ内の使用していないファイルを削除 (*)"
		Me.chkDeleteFile.Size = New System.Drawing.Size(297, 25)
		Me.chkDeleteFile.Location = New System.Drawing.Point(8, 48)
		Me.chkDeleteFile.TabIndex = 3
		Me.chkDeleteFile.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDeleteFile.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkDeleteFile.BackColor = System.Drawing.SystemColors.Control
		Me.chkDeleteFile.CausesValidation = True
		Me.chkDeleteFile.Enabled = True
		Me.chkDeleteFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkDeleteFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDeleteFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDeleteFile.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDeleteFile.TabStop = True
		Me.chkDeleteFile.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDeleteFile.Visible = True
		Me.chkDeleteFile.Name = "chkDeleteFile"
		Me.txtExtension.AutoSize = False
		Me.txtExtension.Enabled = False
		Me.txtExtension.Size = New System.Drawing.Size(193, 18)
		Me.txtExtension.Location = New System.Drawing.Point(112, 76)
		Me.txtExtension.TabIndex = 5
		Me.txtExtension.Text = "wav,mp3,bmp,jpg,gif"
		Me.txtExtension.AcceptsReturn = True
		Me.txtExtension.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtExtension.BackColor = System.Drawing.SystemColors.Window
		Me.txtExtension.CausesValidation = True
		Me.txtExtension.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtExtension.HideSelection = True
		Me.txtExtension.ReadOnly = False
		Me.txtExtension.MaxLength = 0
		Me.txtExtension.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtExtension.Multiline = False
		Me.txtExtension.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtExtension.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtExtension.TabStop = True
		Me.txtExtension.Visible = True
		Me.txtExtension.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtExtension.Name = "txtExtension"
		Me.chkFileNameConvert.Text = "ファイル名を連番 (01 - ZZ) に変換 (*)"
		Me.chkFileNameConvert.Size = New System.Drawing.Size(297, 25)
		Me.chkFileNameConvert.Location = New System.Drawing.Point(8, 224)
		Me.chkFileNameConvert.TabIndex = 9
		Me.chkFileNameConvert.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkFileNameConvert.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkFileNameConvert.BackColor = System.Drawing.SystemColors.Control
		Me.chkFileNameConvert.CausesValidation = True
		Me.chkFileNameConvert.Enabled = True
		Me.chkFileNameConvert.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFileNameConvert.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFileNameConvert.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFileNameConvert.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFileNameConvert.TabStop = True
		Me.chkFileNameConvert.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkFileNameConvert.Visible = True
		Me.chkFileNameConvert.Name = "chkFileNameConvert"
		Me.chkUseOldFormat.Text = "可能なら古いフォーマット (01 - FF) を使う"
		Me.chkUseOldFormat.Enabled = False
		Me.chkUseOldFormat.Size = New System.Drawing.Size(289, 25)
		Me.chkUseOldFormat.Location = New System.Drawing.Point(24, 160)
		Me.chkUseOldFormat.TabIndex = 8
		Me.chkUseOldFormat.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkUseOldFormat.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkUseOldFormat.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkUseOldFormat.BackColor = System.Drawing.SystemColors.Control
		Me.chkUseOldFormat.CausesValidation = True
		Me.chkUseOldFormat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkUseOldFormat.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkUseOldFormat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkUseOldFormat.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkUseOldFormat.TabStop = True
		Me.chkUseOldFormat.Visible = True
		Me.chkUseOldFormat.Name = "chkUseOldFormat"
		Me.chkListAlign.Text = "定義リストの整列"
		Me.chkListAlign.Size = New System.Drawing.Size(297, 25)
		Me.chkListAlign.Location = New System.Drawing.Point(8, 136)
		Me.chkListAlign.TabIndex = 7
		Me.chkListAlign.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkListAlign.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkListAlign.BackColor = System.Drawing.SystemColors.Control
		Me.chkListAlign.CausesValidation = True
		Me.chkListAlign.Enabled = True
		Me.chkListAlign.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkListAlign.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkListAlign.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkListAlign.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkListAlign.TabStop = True
		Me.chkListAlign.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkListAlign.Visible = True
		Me.chkListAlign.Name = "chkListAlign"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "キャンセル"
		Me.cmdCancel.Size = New System.Drawing.Size(89, 25)
		Me.cmdCancel.Location = New System.Drawing.Point(216, 296)
		Me.cmdCancel.TabIndex = 1
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdDecide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDecide.Text = "実行"
		Me.AcceptButton = Me.cmdDecide
		Me.cmdDecide.Size = New System.Drawing.Size(121, 25)
		Me.cmdDecide.Location = New System.Drawing.Point(88, 296)
		Me.cmdDecide.TabIndex = 0
		Me.cmdDecide.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDecide.CausesValidation = True
		Me.cmdDecide.Enabled = True
		Me.cmdDecide.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDecide.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDecide.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDecide.TabStop = True
		Me.cmdDecide.Name = "cmdDecide"
		Me.chkDeleteUnusedFile.Text = "使用していない #WAV・#BMP・#BGA の定義を消去"
		Me.chkDeleteUnusedFile.Size = New System.Drawing.Size(297, 17)
		Me.chkDeleteUnusedFile.Location = New System.Drawing.Point(8, 16)
		Me.chkDeleteUnusedFile.TabIndex = 2
		Me.chkDeleteUnusedFile.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDeleteUnusedFile.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkDeleteUnusedFile.BackColor = System.Drawing.SystemColors.Control
		Me.chkDeleteUnusedFile.CausesValidation = True
		Me.chkDeleteUnusedFile.Enabled = True
		Me.chkDeleteUnusedFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkDeleteUnusedFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDeleteUnusedFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDeleteUnusedFile.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDeleteUnusedFile.TabStop = True
		Me.chkDeleteUnusedFile.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDeleteUnusedFile.Visible = True
		Me.chkDeleteUnusedFile.Name = "chkDeleteUnusedFile"
		Me.lblNotice.Text = "(*)・・・この操作はやり直しができません"
		Me.lblNotice.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.lblNotice.Size = New System.Drawing.Size(297, 17)
		Me.lblNotice.Location = New System.Drawing.Point(8, 264)
		Me.lblNotice.TabIndex = 10
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
		Me.lblExtension.Text = "検索する拡張子:"
		Me.lblExtension.Enabled = False
		Me.lblExtension.Size = New System.Drawing.Size(84, 12)
		Me.lblExtension.Location = New System.Drawing.Point(26, 80)
		Me.lblExtension.TabIndex = 4
		Me.lblExtension.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblExtension.BackColor = System.Drawing.SystemColors.Control
		Me.lblExtension.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblExtension.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblExtension.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblExtension.UseMnemonic = True
		Me.lblExtension.Visible = True
		Me.lblExtension.AutoSize = True
		Me.lblExtension.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblExtension.Name = "lblExtension"
		Me.Controls.Add(chkSortByName)
		Me.Controls.Add(chkFileRecycle)
		Me.Controls.Add(chkDeleteFile)
		Me.Controls.Add(txtExtension)
		Me.Controls.Add(chkFileNameConvert)
		Me.Controls.Add(chkUseOldFormat)
		Me.Controls.Add(chkListAlign)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdDecide)
		Me.Controls.Add(chkDeleteUnusedFile)
		Me.Controls.Add(lblNotice)
		Me.Controls.Add(lblExtension)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
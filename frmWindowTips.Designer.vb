<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWindowTips
#Region "Windows �t�H�[�� �f�U�C�i�ɂ���Đ������ꂽ�R�[�h "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
		InitializeComponent()
	End Sub
	'Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents picIcon As System.Windows.Forms.PictureBox
	Public WithEvents tmrMain As System.Windows.Forms.Timer
	Public WithEvents chkNextDisp As System.Windows.Forms.CheckBox
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	'����: �ȉ��̃v���V�[�W���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
	'Windows �t�H�[�� �f�U�C�i���g���ĕύX�ł��܂��B
	'�R�[�h �G�f�B�^���g�p���āA�ύX���Ȃ��ł��������B
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWindowTips))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.picIcon = New System.Windows.Forms.PictureBox
		Me.tmrMain = New System.Windows.Forms.Timer(components)
		Me.chkNextDisp = New System.Windows.Forms.CheckBox
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "BMSE Tips (Sorry Japanese Language Only!!!!!!!111)"
		Me.ClientSize = New System.Drawing.Size(418, 264)
		Me.Location = New System.Drawing.Point(3, 19)
		Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
		Me.Name = "frmWindowTips"
		Me.picIcon.Size = New System.Drawing.Size(32, 64)
		Me.picIcon.Location = New System.Drawing.Point(0, 0)
		Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
		Me.picIcon.TabIndex = 0
		Me.picIcon.Visible = False
		Me.picIcon.Dock = System.Windows.Forms.DockStyle.None
		Me.picIcon.BackColor = System.Drawing.SystemColors.Control
		Me.picIcon.CausesValidation = True
		Me.picIcon.Enabled = True
		Me.picIcon.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picIcon.Cursor = System.Windows.Forms.Cursors.Default
		Me.picIcon.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picIcon.TabStop = True
		Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picIcon.Name = "picIcon"
		Me.tmrMain.Enabled = False
		Me.tmrMain.Interval = 100
		Me.chkNextDisp.Text = "Launch at next startup"
		Me.chkNextDisp.Size = New System.Drawing.Size(185, 17)
		Me.chkNextDisp.Location = New System.Drawing.Point(8, 236)
		Me.chkNextDisp.TabIndex = 1
		Me.chkNextDisp.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkNextDisp.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkNextDisp.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkNextDisp.BackColor = System.Drawing.SystemColors.Control
		Me.chkNextDisp.CausesValidation = True
		Me.chkNextDisp.Enabled = True
		Me.chkNextDisp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkNextDisp.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkNextDisp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkNextDisp.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkNextDisp.TabStop = True
		Me.chkNextDisp.Visible = True
		Me.chkNextDisp.Name = "chkNextDisp"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "����"
		Me.AcceptButton = Me.cmdNext
		Me.cmdNext.Size = New System.Drawing.Size(101, 25)
		Me.cmdNext.Location = New System.Drawing.Point(204, 232)
		Me.cmdNext.TabIndex = 2
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.TabStop = True
		Me.cmdNext.Name = "cmdNext"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "����"
		Me.cmdClose.Size = New System.Drawing.Size(97, 25)
		Me.cmdClose.Location = New System.Drawing.Point(312, 232)
		Me.cmdClose.TabIndex = 3
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.Controls.Add(picIcon)
		Me.Controls.Add(chkNextDisp)
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(cmdClose)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
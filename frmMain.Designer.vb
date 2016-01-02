<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
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
	Public WithEvents mnuFileNew As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileSave As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileSaveAs As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileOpenDirectory As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineFile As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _mnuRecentFiles_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_3 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_4 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_5 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_6 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_7 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_8 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuRecentFiles_9 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineRecent As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuFileConvertWizard As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineExit As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEditUndo As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEditRedo As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineEdit1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuEditCut As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEditCopy As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEditPaste As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEditDelete As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineEdit2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuEditSelectAll As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineEdit3 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuEditFind As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineEdit4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _mnuEditMode_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuEditMode_1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuEditMode_2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuViewItem_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuOptionsItem_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineOptions As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _mnuLanguage_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLanguageParent As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuTheme_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuThemeParent As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuToolsPlayAll As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuToolsPlay As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuToolsPlayStop As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineTools As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuToolsSetting As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelpOpen As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLineHelp As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuHelpWeb As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextPlayAll As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextPlay As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextBar1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuContextInsertMeasure As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextDeleteMeasure As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextBar2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuContextEditCut As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextEditCopy As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextEditPaste As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextEditDelete As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContext As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextListLoad As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextListDelete As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextListRename As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuContextList As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents _staMain_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _staMain_Panel2 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _staMain_Panel3 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _staMain_Panel4 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _staMain_Panel5 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _staMain_Panel6 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents staMain As System.Windows.Forms.StatusStrip
	Public WithEvents picSiromaru As System.Windows.Forms.PictureBox
	Public WithEvents tmrEffect As System.Windows.Forms.Timer
	Public WithEvents cboVScroll As System.Windows.Forms.ComboBox
	Public WithEvents lblVScroll As System.Windows.Forms.Label
	Public WithEvents fraResolution As System.Windows.Forms.GroupBox
	Public WithEvents cboDispHeight As System.Windows.Forms.ComboBox
	Public WithEvents cboDispWidth As System.Windows.Forms.ComboBox
	Public WithEvents lblDispWidth As System.Windows.Forms.Label
	Public WithEvents lblDispHeight As System.Windows.Forms.Label
	Public WithEvents fraDispSize As System.Windows.Forms.GroupBox
	Public WithEvents cboViewer As System.Windows.Forms.ComboBox
	Public WithEvents fraViewer As System.Windows.Forms.GroupBox
	Public WithEvents tmrMain As System.Windows.Forms.Timer
	Public WithEvents ilsMenu As System.Windows.Forms.ImageList
	Public WithEvents cboDirectInput As System.Windows.Forms.ComboBox
	Public WithEvents cmdDirectInput As System.Windows.Forms.Button
	Public WithEvents cboDispGridMain As System.Windows.Forms.ComboBox
	Public WithEvents cboDispGridSub As System.Windows.Forms.ComboBox
	Public WithEvents lblGridSub As System.Windows.Forms.Label
	Public WithEvents lblGridMain As System.Windows.Forms.Label
	Public WithEvents fraGrid As System.Windows.Forms.GroupBox
	Public WithEvents cboPlayer As System.Windows.Forms.ComboBox
	Public WithEvents txtGenre As System.Windows.Forms.TextBox
	Public WithEvents txtTitle As System.Windows.Forms.TextBox
	Public WithEvents txtArtist As System.Windows.Forms.TextBox
	Public WithEvents cboPlayLevel As System.Windows.Forms.ComboBox
	Public WithEvents txtBPM As System.Windows.Forms.TextBox
	Public WithEvents lblPlayMode As System.Windows.Forms.Label
	Public WithEvents lblGenre As System.Windows.Forms.Label
	Public WithEvents lblTitle As System.Windows.Forms.Label
	Public WithEvents lblArtist As System.Windows.Forms.Label
	Public WithEvents lblPlayLevel As System.Windows.Forms.Label
	Public WithEvents lblBPM As System.Windows.Forms.Label
	Public WithEvents _fraTop_0 As System.Windows.Forms.GroupBox
	Public WithEvents cboPlayRank As System.Windows.Forms.ComboBox
	Public WithEvents txtTotal As System.Windows.Forms.TextBox
	Public WithEvents txtVolume As System.Windows.Forms.TextBox
	Public WithEvents txtStageFile As System.Windows.Forms.TextBox
	Public WithEvents cmdLoadStageFile As System.Windows.Forms.Button
	Public WithEvents cmdLoadMissBMP As System.Windows.Forms.Button
	Public WithEvents txtMissBMP As System.Windows.Forms.TextBox
	Public WithEvents lblPlayRank As System.Windows.Forms.Label
	Public WithEvents lblTotal As System.Windows.Forms.Label
	Public WithEvents lblVolume As System.Windows.Forms.Label
	Public WithEvents lblStageFile As System.Windows.Forms.Label
	Public WithEvents lblMissBMP As System.Windows.Forms.Label
	Public WithEvents _fraTop_1 As System.Windows.Forms.GroupBox
	Public WithEvents cboDispFrame As System.Windows.Forms.ComboBox
	Public WithEvents cboDispSC2P As System.Windows.Forms.ComboBox
	Public WithEvents cboDispSC1P As System.Windows.Forms.ComboBox
	Public WithEvents cboDispKey As System.Windows.Forms.ComboBox
	Public WithEvents lblDispFrame As System.Windows.Forms.Label
	Public WithEvents lblDispSC2P As System.Windows.Forms.Label
	Public WithEvents lblDispSC1P As System.Windows.Forms.Label
	Public WithEvents lblDispKey As System.Windows.Forms.Label
	Public WithEvents _fraTop_2 As System.Windows.Forms.GroupBox
	Public WithEvents _optChangeTop_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optChangeTop_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optChangeTop_1 As System.Windows.Forms.RadioButton
	Public WithEvents fraHeader As System.Windows.Forms.GroupBox
	Public WithEvents _optChangeBottom_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optChangeBottom_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optChangeBottom_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optChangeBottom_3 As System.Windows.Forms.RadioButton
	Public WithEvents _optChangeBottom_4 As System.Windows.Forms.RadioButton
	Public WithEvents txtExInfo As System.Windows.Forms.TextBox
	Public WithEvents _fraBottom_4 As System.Windows.Forms.GroupBox
	Public WithEvents cmdSoundExcUp As System.Windows.Forms.Button
	Public WithEvents cmdSoundExcDown As System.Windows.Forms.Button
	Public WithEvents cmdSoundDelete As System.Windows.Forms.Button
	Public WithEvents cmdSoundLoad As System.Windows.Forms.Button
	Public WithEvents cmdSoundStop As System.Windows.Forms.Button
	Public WithEvents lstWAV As System.Windows.Forms.ListBox
	Public WithEvents _fraBottom_0 As System.Windows.Forms.GroupBox
	Public WithEvents cmdBMPExcDown As System.Windows.Forms.Button
	Public WithEvents cmdBMPExcUp As System.Windows.Forms.Button
	Public WithEvents lstBMP As System.Windows.Forms.ListBox
	Public WithEvents cmdBMPDelete As System.Windows.Forms.Button
	Public WithEvents cmdBMPLoad As System.Windows.Forms.Button
	Public WithEvents cmdBMPPreview As System.Windows.Forms.Button
	Public WithEvents _fraBottom_1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdBGAExcDown As System.Windows.Forms.Button
	Public WithEvents cmdBGAExcUp As System.Windows.Forms.Button
	Public WithEvents txtBGAInput As System.Windows.Forms.TextBox
	Public WithEvents cmdBGAPreview As System.Windows.Forms.Button
	Public WithEvents cmdBGASet As System.Windows.Forms.Button
	Public WithEvents cmdBGADelete As System.Windows.Forms.Button
	Public WithEvents lstBGA As System.Windows.Forms.ListBox
	Public WithEvents _fraBottom_2 As System.Windows.Forms.GroupBox
	Public WithEvents cboNumerator As System.Windows.Forms.ComboBox
	Public WithEvents cboDenominator As System.Windows.Forms.ComboBox
	Public WithEvents cmdMeasureSelectAll As System.Windows.Forms.Button
	Public WithEvents cmdInputMeasureLen As System.Windows.Forms.Button
	Public WithEvents lstMeasureLen As System.Windows.Forms.ListBox
	Public WithEvents lblFraction As System.Windows.Forms.Label
	Public WithEvents _fraBottom_3 As System.Windows.Forms.GroupBox
	Public WithEvents fraMaterial As System.Windows.Forms.GroupBox
	Public WithEvents picMain As System.Windows.Forms.PictureBox
	Public WithEvents hsbMain As System.Windows.Forms.HScrollBar
	Public WithEvents vsbMain As System.Windows.Forms.VScrollBar
	Public dlgMainOpen As System.Windows.Forms.OpenFileDialog
	Public dlgMainSave As System.Windows.Forms.SaveFileDialog
	Public WithEvents _tlbMenu_Button1 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button2 As System.Windows.Forms.ToolStripDropDownButton
	Public WithEvents _tlbMenu_Button3 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button4 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button5 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button6 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbMenu_Button7 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button8 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button9 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button10 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbMenu_Button11 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbMenu_Button12 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button13 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button14 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbMenu_Button15 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbMenu_Button16 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbMenu_Button17 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbMenu_Button18 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbMenu_Button19 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbMenu_Button20 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents tlbMenu As System.Windows.Forms.ToolStrip
	Public WithEvents _linStatusBar_0 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linStatusBar_1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linToolbarBottom_0 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linHeader_0 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linVertical_0 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linDirectInput_0 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linDirectInput_1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linHeader_1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linVertical_1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _linToolbarBottom_1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents lblDirectInput As System.Windows.Forms.Label
	Public WithEvents fraBottom As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
	Public WithEvents fraTop As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
	Public WithEvents linDirectInput As LineShapeArray
	Public WithEvents linHeader As LineShapeArray
	Public WithEvents linStatusBar As LineShapeArray
	Public WithEvents linToolbarBottom As LineShapeArray
	Public WithEvents linVertical As LineShapeArray
	Public WithEvents mnuEditMode As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuLanguage As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuOptionsItem As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuRecentFiles As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuTheme As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents mnuViewItem As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents optChangeBottom As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents optChangeTop As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileSave = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileOpenDirectory = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineFile = New System.Windows.Forms.ToolStripSeparator
		Me._mnuRecentFiles_0 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_1 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_2 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_3 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_4 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_5 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_6 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_7 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_8 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuRecentFiles_9 = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineRecent = New System.Windows.Forms.ToolStripSeparator
		Me.mnuFileConvertWizard = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineExit = New System.Windows.Forms.ToolStripSeparator
		Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditUndo = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditRedo = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineEdit1 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuEditCut = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditCopy = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditPaste = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditDelete = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineEdit2 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuEditSelectAll = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineEdit3 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuEditFind = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineEdit4 = New System.Windows.Forms.ToolStripSeparator
		Me._mnuEditMode_0 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuEditMode_1 = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuEditMode_2 = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuView = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuViewItem_0 = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuOptionsItem_0 = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineOptions = New System.Windows.Forms.ToolStripSeparator
		Me.mnuLanguageParent = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuLanguage_0 = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuThemeParent = New System.Windows.Forms.ToolStripMenuItem
		Me._mnuTheme_0 = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuToolsPlayAll = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuToolsPlay = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuToolsPlayStop = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineTools = New System.Windows.Forms.ToolStripSeparator
		Me.mnuToolsSetting = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpOpen = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLineHelp = New System.Windows.Forms.ToolStripSeparator
		Me.mnuHelpWeb = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContext = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextPlayAll = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextPlay = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextBar1 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuContextInsertMeasure = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextDeleteMeasure = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextBar2 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuContextEditCut = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextEditCopy = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextEditPaste = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextEditDelete = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextList = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextListLoad = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextListDelete = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuContextListRename = New System.Windows.Forms.ToolStripMenuItem
		Me.staMain = New System.Windows.Forms.StatusStrip
		Me._staMain_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me._staMain_Panel2 = New System.Windows.Forms.ToolStripStatusLabel
		Me._staMain_Panel3 = New System.Windows.Forms.ToolStripStatusLabel
		Me._staMain_Panel4 = New System.Windows.Forms.ToolStripStatusLabel
		Me._staMain_Panel5 = New System.Windows.Forms.ToolStripStatusLabel
		Me._staMain_Panel6 = New System.Windows.Forms.ToolStripStatusLabel
		Me.picSiromaru = New System.Windows.Forms.PictureBox
		Me.tmrEffect = New System.Windows.Forms.Timer(components)
		Me.fraResolution = New System.Windows.Forms.GroupBox
		Me.cboVScroll = New System.Windows.Forms.ComboBox
		Me.lblVScroll = New System.Windows.Forms.Label
		Me.fraDispSize = New System.Windows.Forms.GroupBox
		Me.cboDispHeight = New System.Windows.Forms.ComboBox
		Me.cboDispWidth = New System.Windows.Forms.ComboBox
		Me.lblDispWidth = New System.Windows.Forms.Label
		Me.lblDispHeight = New System.Windows.Forms.Label
		Me.fraViewer = New System.Windows.Forms.GroupBox
		Me.cboViewer = New System.Windows.Forms.ComboBox
		Me.tmrMain = New System.Windows.Forms.Timer(components)
		Me.ilsMenu = New System.Windows.Forms.ImageList
		Me.cboDirectInput = New System.Windows.Forms.ComboBox
		Me.cmdDirectInput = New System.Windows.Forms.Button
		Me.fraGrid = New System.Windows.Forms.GroupBox
		Me.cboDispGridMain = New System.Windows.Forms.ComboBox
		Me.cboDispGridSub = New System.Windows.Forms.ComboBox
		Me.lblGridSub = New System.Windows.Forms.Label
		Me.lblGridMain = New System.Windows.Forms.Label
		Me.fraHeader = New System.Windows.Forms.GroupBox
		Me._fraTop_0 = New System.Windows.Forms.GroupBox
		Me.cboPlayer = New System.Windows.Forms.ComboBox
		Me.txtGenre = New System.Windows.Forms.TextBox
		Me.txtTitle = New System.Windows.Forms.TextBox
		Me.txtArtist = New System.Windows.Forms.TextBox
		Me.cboPlayLevel = New System.Windows.Forms.ComboBox
		Me.txtBPM = New System.Windows.Forms.TextBox
		Me.lblPlayMode = New System.Windows.Forms.Label
		Me.lblGenre = New System.Windows.Forms.Label
		Me.lblTitle = New System.Windows.Forms.Label
		Me.lblArtist = New System.Windows.Forms.Label
		Me.lblPlayLevel = New System.Windows.Forms.Label
		Me.lblBPM = New System.Windows.Forms.Label
		Me._fraTop_1 = New System.Windows.Forms.GroupBox
		Me.cboPlayRank = New System.Windows.Forms.ComboBox
		Me.txtTotal = New System.Windows.Forms.TextBox
		Me.txtVolume = New System.Windows.Forms.TextBox
		Me.txtStageFile = New System.Windows.Forms.TextBox
		Me.cmdLoadStageFile = New System.Windows.Forms.Button
		Me.cmdLoadMissBMP = New System.Windows.Forms.Button
		Me.txtMissBMP = New System.Windows.Forms.TextBox
		Me.lblPlayRank = New System.Windows.Forms.Label
		Me.lblTotal = New System.Windows.Forms.Label
		Me.lblVolume = New System.Windows.Forms.Label
		Me.lblStageFile = New System.Windows.Forms.Label
		Me.lblMissBMP = New System.Windows.Forms.Label
		Me._fraTop_2 = New System.Windows.Forms.GroupBox
		Me.cboDispFrame = New System.Windows.Forms.ComboBox
		Me.cboDispSC2P = New System.Windows.Forms.ComboBox
		Me.cboDispSC1P = New System.Windows.Forms.ComboBox
		Me.cboDispKey = New System.Windows.Forms.ComboBox
		Me.lblDispFrame = New System.Windows.Forms.Label
		Me.lblDispSC2P = New System.Windows.Forms.Label
		Me.lblDispSC1P = New System.Windows.Forms.Label
		Me.lblDispKey = New System.Windows.Forms.Label
		Me._optChangeTop_0 = New System.Windows.Forms.RadioButton
		Me._optChangeTop_2 = New System.Windows.Forms.RadioButton
		Me._optChangeTop_1 = New System.Windows.Forms.RadioButton
		Me.fraMaterial = New System.Windows.Forms.GroupBox
		Me._optChangeBottom_0 = New System.Windows.Forms.RadioButton
		Me._optChangeBottom_1 = New System.Windows.Forms.RadioButton
		Me._optChangeBottom_2 = New System.Windows.Forms.RadioButton
		Me._optChangeBottom_3 = New System.Windows.Forms.RadioButton
		Me._optChangeBottom_4 = New System.Windows.Forms.RadioButton
		Me._fraBottom_4 = New System.Windows.Forms.GroupBox
		Me.txtExInfo = New System.Windows.Forms.TextBox
		Me._fraBottom_0 = New System.Windows.Forms.GroupBox
		Me.cmdSoundExcUp = New System.Windows.Forms.Button
		Me.cmdSoundExcDown = New System.Windows.Forms.Button
		Me.cmdSoundDelete = New System.Windows.Forms.Button
		Me.cmdSoundLoad = New System.Windows.Forms.Button
		Me.cmdSoundStop = New System.Windows.Forms.Button
		Me.lstWAV = New System.Windows.Forms.ListBox
		Me._fraBottom_1 = New System.Windows.Forms.GroupBox
		Me.cmdBMPExcDown = New System.Windows.Forms.Button
		Me.cmdBMPExcUp = New System.Windows.Forms.Button
		Me.lstBMP = New System.Windows.Forms.ListBox
		Me.cmdBMPDelete = New System.Windows.Forms.Button
		Me.cmdBMPLoad = New System.Windows.Forms.Button
		Me.cmdBMPPreview = New System.Windows.Forms.Button
		Me._fraBottom_2 = New System.Windows.Forms.GroupBox
		Me.cmdBGAExcDown = New System.Windows.Forms.Button
		Me.cmdBGAExcUp = New System.Windows.Forms.Button
		Me.txtBGAInput = New System.Windows.Forms.TextBox
		Me.cmdBGAPreview = New System.Windows.Forms.Button
		Me.cmdBGASet = New System.Windows.Forms.Button
		Me.cmdBGADelete = New System.Windows.Forms.Button
		Me.lstBGA = New System.Windows.Forms.ListBox
		Me._fraBottom_3 = New System.Windows.Forms.GroupBox
		Me.cboNumerator = New System.Windows.Forms.ComboBox
		Me.cboDenominator = New System.Windows.Forms.ComboBox
		Me.cmdMeasureSelectAll = New System.Windows.Forms.Button
		Me.cmdInputMeasureLen = New System.Windows.Forms.Button
		Me.lstMeasureLen = New System.Windows.Forms.ListBox
		Me.lblFraction = New System.Windows.Forms.Label
		Me.picMain = New System.Windows.Forms.PictureBox
		Me.hsbMain = New System.Windows.Forms.HScrollBar
		Me.vsbMain = New System.Windows.Forms.VScrollBar
		Me.dlgMainOpen = New System.Windows.Forms.OpenFileDialog
		Me.dlgMainSave = New System.Windows.Forms.SaveFileDialog
		Me.tlbMenu = New System.Windows.Forms.ToolStrip
		Me._tlbMenu_Button1 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button2 = New System.Windows.Forms.ToolStripDropDownButton
		Me._tlbMenu_Button3 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button4 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button5 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button6 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbMenu_Button7 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button8 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button9 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button10 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbMenu_Button11 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbMenu_Button12 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button13 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button14 = New System.Windows.Forms.ToolStripButton
		Me._tlbMenu_Button15 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbMenu_Button16 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbMenu_Button17 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbMenu_Button18 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbMenu_Button19 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbMenu_Button20 = New System.Windows.Forms.ToolStripSeparator
		Me._linStatusBar_0 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linStatusBar_1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linToolbarBottom_0 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linHeader_0 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linVertical_0 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linDirectInput_0 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linDirectInput_1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linHeader_1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linVertical_1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._linToolbarBottom_1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.lblDirectInput = New System.Windows.Forms.Label
		Me.fraBottom = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
		Me.fraTop = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
		Me.linDirectInput = New LineShapeArray(components)
		Me.linHeader = New LineShapeArray(components)
		Me.linStatusBar = New LineShapeArray(components)
		Me.linToolbarBottom = New LineShapeArray(components)
		Me.linVertical = New LineShapeArray(components)
		Me.mnuEditMode = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(components)
		Me.mnuLanguage = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(components)
		Me.mnuOptionsItem = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(components)
		Me.mnuRecentFiles = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(components)
		Me.mnuTheme = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(components)
		Me.mnuViewItem = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(components)
		Me.optChangeBottom = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.optChangeTop = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.MainMenu1.SuspendLayout()
		Me.staMain.SuspendLayout()
		Me.fraResolution.SuspendLayout()
		Me.fraDispSize.SuspendLayout()
		Me.fraViewer.SuspendLayout()
		Me.fraGrid.SuspendLayout()
		Me.fraHeader.SuspendLayout()
		Me._fraTop_0.SuspendLayout()
		Me._fraTop_1.SuspendLayout()
		Me._fraTop_2.SuspendLayout()
		Me.fraMaterial.SuspendLayout()
		Me._fraBottom_4.SuspendLayout()
		Me._fraBottom_0.SuspendLayout()
		Me._fraBottom_1.SuspendLayout()
		Me._fraBottom_2.SuspendLayout()
		Me._fraBottom_3.SuspendLayout()
		Me.tlbMenu.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.fraBottom, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.fraTop, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.linDirectInput, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.linHeader, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.linStatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.linToolbarBottom, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.linVertical, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mnuEditMode, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mnuLanguage, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mnuOptionsItem, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mnuRecentFiles, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mnuTheme, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mnuViewItem, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optChangeBottom, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optChangeTop, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "BMx Sequence Editor"
		Me.ClientSize = New System.Drawing.Size(1192, 530)
		Me.Location = New System.Drawing.Point(11, 49)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Icon = CType(resources.GetObject("frmMain.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Visible = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMain"
		Me.mnuFile.Name = "mnuFile"
		Me.mnuFile.Text = "mnuFile"
		Me.mnuFile.Checked = False
		Me.mnuFile.Enabled = True
		Me.mnuFile.Visible = True
		Me.mnuFileNew.Name = "mnuFileNew"
		Me.mnuFileNew.Text = "mnuFileNew"
		Me.mnuFileNew.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.N, System.Windows.Forms.Keys)
		Me.mnuFileNew.Checked = False
		Me.mnuFileNew.Enabled = True
		Me.mnuFileNew.Visible = True
		Me.mnuFileOpen.Name = "mnuFileOpen"
		Me.mnuFileOpen.Text = "mnuFileOpen"
		Me.mnuFileOpen.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.O, System.Windows.Forms.Keys)
		Me.mnuFileOpen.Checked = False
		Me.mnuFileOpen.Enabled = True
		Me.mnuFileOpen.Visible = True
		Me.mnuFileSave.Name = "mnuFileSave"
		Me.mnuFileSave.Text = "mnuFileSave"
		Me.mnuFileSave.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.S, System.Windows.Forms.Keys)
		Me.mnuFileSave.Checked = False
		Me.mnuFileSave.Enabled = True
		Me.mnuFileSave.Visible = True
		Me.mnuFileSaveAs.Name = "mnuFileSaveAs"
		Me.mnuFileSaveAs.Text = "mnuFileSaveAs"
		Me.mnuFileSaveAs.Checked = False
		Me.mnuFileSaveAs.Enabled = True
		Me.mnuFileSaveAs.Visible = True
		Me.mnuFileOpenDirectory.Name = "mnuFileOpenDirectory"
		Me.mnuFileOpenDirectory.Text = "mnuFileOpenDirectory"
		Me.mnuFileOpenDirectory.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.D, System.Windows.Forms.Keys)
		Me.mnuFileOpenDirectory.Checked = False
		Me.mnuFileOpenDirectory.Enabled = True
		Me.mnuFileOpenDirectory.Visible = True
		Me.mnuLineFile.Enabled = True
		Me.mnuLineFile.Visible = True
		Me.mnuLineFile.Name = "mnuLineFile"
		Me._mnuRecentFiles_0.Name = "_mnuRecentFiles_0"
		Me._mnuRecentFiles_0.Text = "&1:"
		Me._mnuRecentFiles_0.Checked = False
		Me._mnuRecentFiles_0.Enabled = True
		Me._mnuRecentFiles_0.Visible = True
		Me._mnuRecentFiles_1.Name = "_mnuRecentFiles_1"
		Me._mnuRecentFiles_1.Text = "&2:"
		Me._mnuRecentFiles_1.Checked = False
		Me._mnuRecentFiles_1.Enabled = True
		Me._mnuRecentFiles_1.Visible = True
		Me._mnuRecentFiles_2.Name = "_mnuRecentFiles_2"
		Me._mnuRecentFiles_2.Text = "&3:"
		Me._mnuRecentFiles_2.Checked = False
		Me._mnuRecentFiles_2.Enabled = True
		Me._mnuRecentFiles_2.Visible = True
		Me._mnuRecentFiles_3.Name = "_mnuRecentFiles_3"
		Me._mnuRecentFiles_3.Text = "&4:"
		Me._mnuRecentFiles_3.Checked = False
		Me._mnuRecentFiles_3.Enabled = True
		Me._mnuRecentFiles_3.Visible = True
		Me._mnuRecentFiles_4.Name = "_mnuRecentFiles_4"
		Me._mnuRecentFiles_4.Text = "&5:"
		Me._mnuRecentFiles_4.Checked = False
		Me._mnuRecentFiles_4.Enabled = True
		Me._mnuRecentFiles_4.Visible = True
		Me._mnuRecentFiles_5.Name = "_mnuRecentFiles_5"
		Me._mnuRecentFiles_5.Text = "&6:"
		Me._mnuRecentFiles_5.Visible = False
		Me._mnuRecentFiles_5.Checked = False
		Me._mnuRecentFiles_5.Enabled = True
		Me._mnuRecentFiles_6.Name = "_mnuRecentFiles_6"
		Me._mnuRecentFiles_6.Text = "&7:"
		Me._mnuRecentFiles_6.Visible = False
		Me._mnuRecentFiles_6.Checked = False
		Me._mnuRecentFiles_6.Enabled = True
		Me._mnuRecentFiles_7.Name = "_mnuRecentFiles_7"
		Me._mnuRecentFiles_7.Text = "&8:"
		Me._mnuRecentFiles_7.Visible = False
		Me._mnuRecentFiles_7.Checked = False
		Me._mnuRecentFiles_7.Enabled = True
		Me._mnuRecentFiles_8.Name = "_mnuRecentFiles_8"
		Me._mnuRecentFiles_8.Text = "&9:"
		Me._mnuRecentFiles_8.Visible = False
		Me._mnuRecentFiles_8.Checked = False
		Me._mnuRecentFiles_8.Enabled = True
		Me._mnuRecentFiles_9.Name = "_mnuRecentFiles_9"
		Me._mnuRecentFiles_9.Text = "&0:"
		Me._mnuRecentFiles_9.Visible = False
		Me._mnuRecentFiles_9.Checked = False
		Me._mnuRecentFiles_9.Enabled = True
		Me.mnuLineRecent.Enabled = True
		Me.mnuLineRecent.Visible = True
		Me.mnuLineRecent.Name = "mnuLineRecent"
		Me.mnuFileConvertWizard.Name = "mnuFileConvertWizard"
		Me.mnuFileConvertWizard.Text = "mnuFileConvertWizard"
		Me.mnuFileConvertWizard.Checked = False
		Me.mnuFileConvertWizard.Enabled = True
		Me.mnuFileConvertWizard.Visible = True
		Me.mnuLineExit.Enabled = True
		Me.mnuLineExit.Visible = True
		Me.mnuLineExit.Name = "mnuLineExit"
		Me.mnuFileExit.Name = "mnuFileExit"
		Me.mnuFileExit.Text = "mnuFileExit"
		Me.mnuFileExit.Checked = False
		Me.mnuFileExit.Enabled = True
		Me.mnuFileExit.Visible = True
		Me.mnuEdit.Name = "mnuEdit"
		Me.mnuEdit.Text = "mnuEdit"
		Me.mnuEdit.Checked = False
		Me.mnuEdit.Enabled = True
		Me.mnuEdit.Visible = True
		Me.mnuEditUndo.Name = "mnuEditUndo"
		Me.mnuEditUndo.Text = "mnuEditUndo"
		Me.mnuEditUndo.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.Z, System.Windows.Forms.Keys)
		Me.mnuEditUndo.Checked = False
		Me.mnuEditUndo.Enabled = True
		Me.mnuEditUndo.Visible = True
		Me.mnuEditRedo.Name = "mnuEditRedo"
		Me.mnuEditRedo.Text = "mnuEditRedo"
		Me.mnuEditRedo.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.Y, System.Windows.Forms.Keys)
		Me.mnuEditRedo.Checked = False
		Me.mnuEditRedo.Enabled = True
		Me.mnuEditRedo.Visible = True
		Me.mnuLineEdit1.Enabled = True
		Me.mnuLineEdit1.Visible = True
		Me.mnuLineEdit1.Name = "mnuLineEdit1"
		Me.mnuEditCut.Name = "mnuEditCut"
		Me.mnuEditCut.Text = "mnuEditCut"
		Me.mnuEditCut.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.X, System.Windows.Forms.Keys)
		Me.mnuEditCut.Checked = False
		Me.mnuEditCut.Enabled = True
		Me.mnuEditCut.Visible = True
		Me.mnuEditCopy.Name = "mnuEditCopy"
		Me.mnuEditCopy.Text = "mnuEditCopy"
		Me.mnuEditCopy.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.C, System.Windows.Forms.Keys)
		Me.mnuEditCopy.Checked = False
		Me.mnuEditCopy.Enabled = True
		Me.mnuEditCopy.Visible = True
		Me.mnuEditPaste.Name = "mnuEditPaste"
		Me.mnuEditPaste.Text = "mnuEditPaste"
		Me.mnuEditPaste.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.V, System.Windows.Forms.Keys)
		Me.mnuEditPaste.Checked = False
		Me.mnuEditPaste.Enabled = True
		Me.mnuEditPaste.Visible = True
		Me.mnuEditDelete.Name = "mnuEditDelete"
		Me.mnuEditDelete.Text = "mnuEditDelete"
		Me.mnuEditDelete.ShortcutKeys = CType(System.Windows.Forms.Keys.Delete, System.Windows.Forms.Keys)
		Me.mnuEditDelete.Checked = False
		Me.mnuEditDelete.Enabled = True
		Me.mnuEditDelete.Visible = True
		Me.mnuLineEdit2.Enabled = True
		Me.mnuLineEdit2.Visible = True
		Me.mnuLineEdit2.Name = "mnuLineEdit2"
		Me.mnuEditSelectAll.Name = "mnuEditSelectAll"
		Me.mnuEditSelectAll.Text = "mnuEditSelectAll"
		Me.mnuEditSelectAll.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.A, System.Windows.Forms.Keys)
		Me.mnuEditSelectAll.Checked = False
		Me.mnuEditSelectAll.Enabled = True
		Me.mnuEditSelectAll.Visible = True
		Me.mnuLineEdit3.Enabled = True
		Me.mnuLineEdit3.Visible = True
		Me.mnuLineEdit3.Name = "mnuLineEdit3"
		Me.mnuEditFind.Name = "mnuEditFind"
		Me.mnuEditFind.Text = "mnuEditFind"
		Me.mnuEditFind.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F, System.Windows.Forms.Keys)
		Me.mnuEditFind.Checked = False
		Me.mnuEditFind.Enabled = True
		Me.mnuEditFind.Visible = True
		Me.mnuLineEdit4.Enabled = True
		Me.mnuLineEdit4.Visible = True
		Me.mnuLineEdit4.Name = "mnuLineEdit4"
		Me._mnuEditMode_0.Name = "_mnuEditMode_0"
		Me._mnuEditMode_0.Text = "mnuEditMode(0)"
		Me._mnuEditMode_0.ShortcutKeys = CType(System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys)
		Me._mnuEditMode_0.Checked = False
		Me._mnuEditMode_0.Enabled = True
		Me._mnuEditMode_0.Visible = True
		Me._mnuEditMode_1.Name = "_mnuEditMode_1"
		Me._mnuEditMode_1.Text = "mnuEditMode(1)"
		Me._mnuEditMode_1.ShortcutKeys = CType(System.Windows.Forms.Keys.F3, System.Windows.Forms.Keys)
		Me._mnuEditMode_1.Checked = False
		Me._mnuEditMode_1.Enabled = True
		Me._mnuEditMode_1.Visible = True
		Me._mnuEditMode_2.Name = "_mnuEditMode_2"
		Me._mnuEditMode_2.Text = "mnuEditMode(2)"
		Me._mnuEditMode_2.ShortcutKeys = CType(System.Windows.Forms.Keys.F4, System.Windows.Forms.Keys)
		Me._mnuEditMode_2.Checked = False
		Me._mnuEditMode_2.Enabled = True
		Me._mnuEditMode_2.Visible = True
		Me.mnuView.Name = "mnuView"
		Me.mnuView.Text = "mnuView"
		Me.mnuView.Checked = False
		Me.mnuView.Enabled = True
		Me.mnuView.Visible = True
		Me._mnuViewItem_0.Name = "_mnuViewItem_0"
		Me._mnuViewItem_0.Text = "mnuViewItem(0)"
		Me._mnuViewItem_0.Checked = False
		Me._mnuViewItem_0.Enabled = True
		Me._mnuViewItem_0.Visible = True
		Me.mnuOptions.Name = "mnuOptions"
		Me.mnuOptions.Text = "mnuOptions"
		Me.mnuOptions.Checked = False
		Me.mnuOptions.Enabled = True
		Me.mnuOptions.Visible = True
		Me._mnuOptionsItem_0.Name = "_mnuOptionsItem_0"
		Me._mnuOptionsItem_0.Text = "mnuOptionsItem(0)"
		Me._mnuOptionsItem_0.Checked = True
		Me._mnuOptionsItem_0.Enabled = True
		Me._mnuOptionsItem_0.Visible = True
		Me.mnuLineOptions.Enabled = True
		Me.mnuLineOptions.Visible = True
		Me.mnuLineOptions.Name = "mnuLineOptions"
		Me.mnuLanguageParent.Name = "mnuLanguageParent"
		Me.mnuLanguageParent.Text = "Select &Language"
		Me.mnuLanguageParent.Checked = False
		Me.mnuLanguageParent.Enabled = True
		Me.mnuLanguageParent.Visible = True
		Me._mnuLanguage_0.Name = "_mnuLanguage_0"
		Me._mnuLanguage_0.Text = "mnuLanguage(0)"
		Me._mnuLanguage_0.Checked = False
		Me._mnuLanguage_0.Enabled = True
		Me._mnuLanguage_0.Visible = True
		Me.mnuThemeParent.Name = "mnuThemeParent"
		Me.mnuThemeParent.Text = "Select &Theme"
		Me.mnuThemeParent.Checked = False
		Me.mnuThemeParent.Enabled = True
		Me.mnuThemeParent.Visible = True
		Me._mnuTheme_0.Name = "_mnuTheme_0"
		Me._mnuTheme_0.Text = "mnuTheme(0)"
		Me._mnuTheme_0.Checked = False
		Me._mnuTheme_0.Enabled = True
		Me._mnuTheme_0.Visible = True
		Me.mnuTools.Name = "mnuTools"
		Me.mnuTools.Text = "mnuTools"
		Me.mnuTools.Checked = False
		Me.mnuTools.Enabled = True
		Me.mnuTools.Visible = True
		Me.mnuToolsPlayAll.Name = "mnuToolsPlayAll"
		Me.mnuToolsPlayAll.Text = "mnuToolsPlayAll"
		Me.mnuToolsPlayAll.ShortcutKeys = CType(System.Windows.Forms.Keys.F6, System.Windows.Forms.Keys)
		Me.mnuToolsPlayAll.Checked = False
		Me.mnuToolsPlayAll.Enabled = True
		Me.mnuToolsPlayAll.Visible = True
		Me.mnuToolsPlay.Name = "mnuToolsPlay"
		Me.mnuToolsPlay.Text = "mnuToolsPlay"
		Me.mnuToolsPlay.ShortcutKeys = CType(System.Windows.Forms.Keys.F7, System.Windows.Forms.Keys)
		Me.mnuToolsPlay.Checked = False
		Me.mnuToolsPlay.Enabled = True
		Me.mnuToolsPlay.Visible = True
		Me.mnuToolsPlayStop.Name = "mnuToolsPlayStop"
		Me.mnuToolsPlayStop.Text = "mnuToolsPlayStop"
		Me.mnuToolsPlayStop.ShortcutKeys = CType(System.Windows.Forms.Keys.F8, System.Windows.Forms.Keys)
		Me.mnuToolsPlayStop.Checked = False
		Me.mnuToolsPlayStop.Enabled = True
		Me.mnuToolsPlayStop.Visible = True
		Me.mnuLineTools.Enabled = True
		Me.mnuLineTools.Visible = True
		Me.mnuLineTools.Name = "mnuLineTools"
		Me.mnuToolsSetting.Name = "mnuToolsSetting"
		Me.mnuToolsSetting.Text = "mnuToolsSetting"
		Me.mnuToolsSetting.Checked = False
		Me.mnuToolsSetting.Enabled = True
		Me.mnuToolsSetting.Visible = True
		Me.mnuHelp.Name = "mnuHelp"
		Me.mnuHelp.Text = "mnuHelp"
		Me.mnuHelp.Checked = False
		Me.mnuHelp.Enabled = True
		Me.mnuHelp.Visible = True
		Me.mnuHelpOpen.Name = "mnuHelpOpen"
		Me.mnuHelpOpen.Text = "mnuHelpOpen"
		Me.mnuHelpOpen.ShortcutKeys = CType(System.Windows.Forms.Keys.F1, System.Windows.Forms.Keys)
		Me.mnuHelpOpen.Checked = False
		Me.mnuHelpOpen.Enabled = True
		Me.mnuHelpOpen.Visible = True
		Me.mnuLineHelp.Enabled = True
		Me.mnuLineHelp.Visible = True
		Me.mnuLineHelp.Name = "mnuLineHelp"
		Me.mnuHelpWeb.Name = "mnuHelpWeb"
		Me.mnuHelpWeb.Text = "mnuHelpWeb"
		Me.mnuHelpWeb.Checked = False
		Me.mnuHelpWeb.Enabled = True
		Me.mnuHelpWeb.Visible = True
		Me.mnuHelpAbout.Name = "mnuHelpAbout"
		Me.mnuHelpAbout.Text = "mnuHelpAbout"
		Me.mnuHelpAbout.Checked = False
		Me.mnuHelpAbout.Enabled = True
		Me.mnuHelpAbout.Visible = True
		Me.mnuContext.Name = "mnuContext"
		Me.mnuContext.Text = "mnuContext"
		Me.mnuContext.Checked = False
		Me.mnuContext.Enabled = True
		Me.mnuContext.Visible = True
		Me.mnuContextPlayAll.Name = "mnuContextPlayAll"
		Me.mnuContextPlayAll.Text = "mnuContextPlayAll"
		Me.mnuContextPlayAll.Checked = False
		Me.mnuContextPlayAll.Enabled = True
		Me.mnuContextPlayAll.Visible = True
		Me.mnuContextPlay.Name = "mnuContextPlay"
		Me.mnuContextPlay.Text = "mnuContextPlay"
		Me.mnuContextPlay.Checked = False
		Me.mnuContextPlay.Enabled = True
		Me.mnuContextPlay.Visible = True
		Me.mnuContextBar1.Enabled = True
		Me.mnuContextBar1.Visible = True
		Me.mnuContextBar1.Name = "mnuContextBar1"
		Me.mnuContextInsertMeasure.Name = "mnuContextInsertMeasure"
		Me.mnuContextInsertMeasure.Text = "mnuContextInsertMeasure"
		Me.mnuContextInsertMeasure.Checked = False
		Me.mnuContextInsertMeasure.Enabled = True
		Me.mnuContextInsertMeasure.Visible = True
		Me.mnuContextDeleteMeasure.Name = "mnuContextDeleteMeasure"
		Me.mnuContextDeleteMeasure.Text = "mnuContextDeleteMeasure"
		Me.mnuContextDeleteMeasure.Checked = False
		Me.mnuContextDeleteMeasure.Enabled = True
		Me.mnuContextDeleteMeasure.Visible = True
		Me.mnuContextBar2.Enabled = True
		Me.mnuContextBar2.Visible = True
		Me.mnuContextBar2.Name = "mnuContextBar2"
		Me.mnuContextEditCut.Name = "mnuContextEditCut"
		Me.mnuContextEditCut.Text = "mnuContextEditCut"
		Me.mnuContextEditCut.Checked = False
		Me.mnuContextEditCut.Enabled = True
		Me.mnuContextEditCut.Visible = True
		Me.mnuContextEditCopy.Name = "mnuContextEditCopy"
		Me.mnuContextEditCopy.Text = "mnuContextEditCopy"
		Me.mnuContextEditCopy.Checked = False
		Me.mnuContextEditCopy.Enabled = True
		Me.mnuContextEditCopy.Visible = True
		Me.mnuContextEditPaste.Name = "mnuContextEditPaste"
		Me.mnuContextEditPaste.Text = "mnuContextEditPaste"
		Me.mnuContextEditPaste.Checked = False
		Me.mnuContextEditPaste.Enabled = True
		Me.mnuContextEditPaste.Visible = True
		Me.mnuContextEditDelete.Name = "mnuContextEditDelete"
		Me.mnuContextEditDelete.Text = "mnuContextEditDelete"
		Me.mnuContextEditDelete.Checked = False
		Me.mnuContextEditDelete.Enabled = True
		Me.mnuContextEditDelete.Visible = True
		Me.mnuContextList.Name = "mnuContextList"
		Me.mnuContextList.Text = "mnuContextList"
		Me.mnuContextList.Checked = False
		Me.mnuContextList.Enabled = True
		Me.mnuContextList.Visible = True
		Me.mnuContextListLoad.Name = "mnuContextListLoad"
		Me.mnuContextListLoad.Text = "mnuContextListLoad"
		Me.mnuContextListLoad.Checked = False
		Me.mnuContextListLoad.Enabled = True
		Me.mnuContextListLoad.Visible = True
		Me.mnuContextListDelete.Name = "mnuContextListDelete"
		Me.mnuContextListDelete.Text = "mnuContextListDelete"
		Me.mnuContextListDelete.Checked = False
		Me.mnuContextListDelete.Enabled = True
		Me.mnuContextListDelete.Visible = True
		Me.mnuContextListRename.Name = "mnuContextListRename"
		Me.mnuContextListRename.Text = "mnuContextListRename"
		Me.mnuContextListRename.Checked = False
		Me.mnuContextListRename.Enabled = True
		Me.mnuContextListRename.Visible = True
		Me.staMain.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.staMain.Size = New System.Drawing.Size(1192, 21)
		Me.staMain.Location = New System.Drawing.Point(0, 509)
		Me.staMain.TabIndex = 98
		Me.staMain.Name = "staMain"
		Me._staMain_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._staMain_Panel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._staMain_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._staMain_Panel1.Size = New System.Drawing.Size(81, 21)
		Me._staMain_Panel1.Text = "Edit Mode"
		Me._staMain_Panel1.AutoSize = True
		Me._staMain_Panel1.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._staMain_Panel1.Margin = New System.Windows.Forms.Padding(0)
		Me._staMain_Panel1.AutoSize = False
		Me._staMain_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._staMain_Panel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._staMain_Panel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._staMain_Panel2.Size = New System.Drawing.Size(904, 21)
		Me._staMain_Panel2.Text = "Position:"
		Me._staMain_Panel2.Spring = True
		Me._staMain_Panel2.AutoSize = True
		Me._staMain_Panel2.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._staMain_Panel2.Margin = New System.Windows.Forms.Padding(0)
		Me._staMain_Panel2.AutoSize = False
		Me._staMain_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._staMain_Panel3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._staMain_Panel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._staMain_Panel3.Size = New System.Drawing.Size(68, 21)
		Me._staMain_Panel3.Text = "#WAV 01"
		Me._staMain_Panel3.AutoSize = True
		Me._staMain_Panel3.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._staMain_Panel3.Margin = New System.Windows.Forms.Padding(0)
		Me._staMain_Panel3.AutoSize = False
		Me._staMain_Panel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._staMain_Panel4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._staMain_Panel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._staMain_Panel4.Size = New System.Drawing.Size(68, 21)
		Me._staMain_Panel4.Text = "#BMP 01"
		Me._staMain_Panel4.AutoSize = True
		Me._staMain_Panel4.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._staMain_Panel4.Margin = New System.Windows.Forms.Padding(0)
		Me._staMain_Panel4.AutoSize = False
		Me._staMain_Panel5.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._staMain_Panel5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._staMain_Panel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._staMain_Panel5.Size = New System.Drawing.Size(54, 21)
		Me._staMain_Panel5.Text = "4/4"
		Me._staMain_Panel5.AutoSize = True
		Me._staMain_Panel5.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._staMain_Panel5.Margin = New System.Windows.Forms.Padding(0)
		Me._staMain_Panel5.AutoSize = False
		Me._staMain_Panel6.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._staMain_Panel6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._staMain_Panel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._staMain_Panel6.Visible = 0
		Me._staMain_Panel6.Size = New System.Drawing.Size(54, 21)
		Me._staMain_Panel6.Text = "0ms"
		Me._staMain_Panel6.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._staMain_Panel6.Margin = New System.Windows.Forms.Padding(0)
		Me._staMain_Panel6.AutoSize = False
		Me.picSiromaru.BackColor = System.Drawing.Color.Black
		Me.picSiromaru.Size = New System.Drawing.Size(64, 256)
		Me.picSiromaru.Location = New System.Drawing.Point(1184, 56)
		Me.picSiromaru.Image = CType(resources.GetObject("picSiromaru.Image"), System.Drawing.Image)
		Me.picSiromaru.TabIndex = 99
		Me.picSiromaru.Visible = False
		Me.picSiromaru.Dock = System.Windows.Forms.DockStyle.None
		Me.picSiromaru.CausesValidation = True
		Me.picSiromaru.Enabled = True
		Me.picSiromaru.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picSiromaru.Cursor = System.Windows.Forms.Cursors.Default
		Me.picSiromaru.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picSiromaru.TabStop = True
		Me.picSiromaru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.picSiromaru.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picSiromaru.Name = "picSiromaru"
		Me.tmrEffect.Enabled = False
		Me.tmrEffect.Interval = 10
		Me.fraResolution.Size = New System.Drawing.Size(117, 21)
		Me.fraResolution.Location = New System.Drawing.Point(1008, 200)
		Me.fraResolution.TabIndex = 16
		Me.fraResolution.BackColor = System.Drawing.SystemColors.Control
		Me.fraResolution.Enabled = True
		Me.fraResolution.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraResolution.Visible = True
		Me.fraResolution.Padding = New System.Windows.Forms.Padding(0)
		Me.fraResolution.Name = "fraResolution"
		Me.cboVScroll.Size = New System.Drawing.Size(57, 20)
		Me.cboVScroll.Location = New System.Drawing.Point(48, 0)
		Me.cboVScroll.Items.AddRange(New Object(){"1"})
		Me.cboVScroll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboVScroll.TabIndex = 18
		Me.cboVScroll.BackColor = System.Drawing.SystemColors.Window
		Me.cboVScroll.CausesValidation = True
		Me.cboVScroll.Enabled = True
		Me.cboVScroll.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboVScroll.IntegralHeight = True
		Me.cboVScroll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboVScroll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboVScroll.Sorted = False
		Me.cboVScroll.TabStop = True
		Me.cboVScroll.Visible = True
		Me.cboVScroll.Name = "cboVScroll"
		Me.lblVScroll.Text = "VScroll"
		Me.lblVScroll.Size = New System.Drawing.Size(42, 12)
		Me.lblVScroll.Location = New System.Drawing.Point(0, 4)
		Me.lblVScroll.TabIndex = 17
		Me.lblVScroll.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblVScroll.BackColor = System.Drawing.SystemColors.Control
		Me.lblVScroll.Enabled = True
		Me.lblVScroll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVScroll.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVScroll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVScroll.UseMnemonic = True
		Me.lblVScroll.Visible = True
		Me.lblVScroll.AutoSize = True
		Me.lblVScroll.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblVScroll.Name = "lblVScroll"
		Me.fraDispSize.Size = New System.Drawing.Size(197, 21)
		Me.fraDispSize.Location = New System.Drawing.Point(808, 200)
		Me.fraDispSize.TabIndex = 11
		Me.fraDispSize.BackColor = System.Drawing.SystemColors.Control
		Me.fraDispSize.Enabled = True
		Me.fraDispSize.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraDispSize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraDispSize.Visible = True
		Me.fraDispSize.Padding = New System.Windows.Forms.Padding(0)
		Me.fraDispSize.Name = "fraDispSize"
		Me.cboDispHeight.Size = New System.Drawing.Size(57, 20)
		Me.cboDispHeight.Location = New System.Drawing.Point(32, 0)
		Me.cboDispHeight.Items.AddRange(New Object(){"x0.5", "x1.0", "x1.5", "x2.0", "x2.5", "x3.0", "x3.5", "x4.0", "..."})
		Me.cboDispHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDispHeight.TabIndex = 13
		Me.cboDispHeight.BackColor = System.Drawing.SystemColors.Window
		Me.cboDispHeight.CausesValidation = True
		Me.cboDispHeight.Enabled = True
		Me.cboDispHeight.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDispHeight.IntegralHeight = True
		Me.cboDispHeight.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDispHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDispHeight.Sorted = False
		Me.cboDispHeight.TabStop = True
		Me.cboDispHeight.Visible = True
		Me.cboDispHeight.Name = "cboDispHeight"
		Me.cboDispWidth.Size = New System.Drawing.Size(57, 20)
		Me.cboDispWidth.Location = New System.Drawing.Point(116, 0)
		Me.cboDispWidth.Items.AddRange(New Object(){"x0.5", "x1.0", "x1.5", "x2.0", "x2.5", "x3.0", "x3.5", "x4.0", "..."})
		Me.cboDispWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDispWidth.TabIndex = 15
		Me.cboDispWidth.BackColor = System.Drawing.SystemColors.Window
		Me.cboDispWidth.CausesValidation = True
		Me.cboDispWidth.Enabled = True
		Me.cboDispWidth.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDispWidth.IntegralHeight = True
		Me.cboDispWidth.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDispWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDispWidth.Sorted = False
		Me.cboDispWidth.TabStop = True
		Me.cboDispWidth.Visible = True
		Me.cboDispWidth.Name = "cboDispWidth"
		Me.lblDispWidth.Text = "幅"
		Me.lblDispWidth.Size = New System.Drawing.Size(12, 12)
		Me.lblDispWidth.Location = New System.Drawing.Point(96, 4)
		Me.lblDispWidth.TabIndex = 14
		Me.lblDispWidth.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDispWidth.BackColor = System.Drawing.SystemColors.Control
		Me.lblDispWidth.Enabled = True
		Me.lblDispWidth.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDispWidth.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDispWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDispWidth.UseMnemonic = True
		Me.lblDispWidth.Visible = True
		Me.lblDispWidth.AutoSize = True
		Me.lblDispWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDispWidth.Name = "lblDispWidth"
		Me.lblDispHeight.Text = "高さ"
		Me.lblDispHeight.Size = New System.Drawing.Size(24, 12)
		Me.lblDispHeight.Location = New System.Drawing.Point(0, 4)
		Me.lblDispHeight.TabIndex = 12
		Me.lblDispHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDispHeight.BackColor = System.Drawing.SystemColors.Control
		Me.lblDispHeight.Enabled = True
		Me.lblDispHeight.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDispHeight.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDispHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDispHeight.UseMnemonic = True
		Me.lblDispHeight.Visible = True
		Me.lblDispHeight.AutoSize = True
		Me.lblDispHeight.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDispHeight.Name = "lblDispHeight"
		Me.fraViewer.Size = New System.Drawing.Size(97, 21)
		Me.fraViewer.Location = New System.Drawing.Point(808, 136)
		Me.fraViewer.TabIndex = 4
		Me.fraViewer.BackColor = System.Drawing.SystemColors.Control
		Me.fraViewer.Enabled = True
		Me.fraViewer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraViewer.Visible = True
		Me.fraViewer.Padding = New System.Windows.Forms.Padding(0)
		Me.fraViewer.Name = "fraViewer"
		Me.cboViewer.Size = New System.Drawing.Size(89, 20)
		Me.cboViewer.Location = New System.Drawing.Point(0, 0)
		Me.cboViewer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboViewer.TabIndex = 5
		Me.cboViewer.BackColor = System.Drawing.SystemColors.Window
		Me.cboViewer.CausesValidation = True
		Me.cboViewer.Enabled = True
		Me.cboViewer.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboViewer.IntegralHeight = True
		Me.cboViewer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboViewer.Sorted = False
		Me.cboViewer.TabStop = True
		Me.cboViewer.Visible = True
		Me.cboViewer.Name = "cboViewer"
		Me.tmrMain.Enabled = False
		Me.tmrMain.Interval = 100
		Me.ilsMenu.ImageSize = New System.Drawing.Size(16, 16)
		Me.ilsMenu.TransparentColor = System.Drawing.Color.White
		Me.ilsMenu.ImageStream = CType(resources.GetObject("ilsMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ilsMenu.Images.SetKeyName(0, "")
		Me.ilsMenu.Images.SetKeyName(1, "")
		Me.ilsMenu.Images.SetKeyName(2, "")
		Me.ilsMenu.Images.SetKeyName(3, "")
		Me.ilsMenu.Images.SetKeyName(4, "")
		Me.ilsMenu.Images.SetKeyName(5, "")
		Me.ilsMenu.Images.SetKeyName(6, "")
		Me.ilsMenu.Images.SetKeyName(7, "")
		Me.ilsMenu.Images.SetKeyName(8, "")
		Me.ilsMenu.Images.SetKeyName(9, "")
		Me.ilsMenu.Images.SetKeyName(10, "")
		Me.cboDirectInput.Size = New System.Drawing.Size(29, 20)
		Me.cboDirectInput.Location = New System.Drawing.Point(40, 480)
		Me.cboDirectInput.TabIndex = 96
		Me.cboDirectInput.BackColor = System.Drawing.SystemColors.Window
		Me.cboDirectInput.CausesValidation = True
		Me.cboDirectInput.Enabled = True
		Me.cboDirectInput.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDirectInput.IntegralHeight = True
		Me.cboDirectInput.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDirectInput.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDirectInput.Sorted = False
		Me.cboDirectInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboDirectInput.TabStop = True
		Me.cboDirectInput.Visible = True
		Me.cboDirectInput.Name = "cboDirectInput"
		Me.cmdDirectInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDirectInput.Text = "Input"
		Me.cmdDirectInput.Size = New System.Drawing.Size(61, 21)
		Me.cmdDirectInput.Location = New System.Drawing.Point(72, 480)
		Me.cmdDirectInput.TabIndex = 97
		Me.cmdDirectInput.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDirectInput.CausesValidation = True
		Me.cmdDirectInput.Enabled = True
		Me.cmdDirectInput.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDirectInput.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDirectInput.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDirectInput.TabStop = True
		Me.cmdDirectInput.Name = "cmdDirectInput"
		Me.fraGrid.Size = New System.Drawing.Size(197, 21)
		Me.fraGrid.Location = New System.Drawing.Point(808, 168)
		Me.fraGrid.TabIndex = 6
		Me.fraGrid.BackColor = System.Drawing.SystemColors.Control
		Me.fraGrid.Enabled = True
		Me.fraGrid.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraGrid.Visible = True
		Me.fraGrid.Padding = New System.Windows.Forms.Padding(0)
		Me.fraGrid.Name = "fraGrid"
		Me.cboDispGridMain.Size = New System.Drawing.Size(57, 20)
		Me.cboDispGridMain.Location = New System.Drawing.Point(128, 0)
		Me.cboDispGridMain.Items.AddRange(New Object(){"2", "4", "8", "16", "32", "64", "3", "6", "12", "24", "48", "NONE"})
		Me.cboDispGridMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDispGridMain.TabIndex = 10
		Me.cboDispGridMain.BackColor = System.Drawing.SystemColors.Window
		Me.cboDispGridMain.CausesValidation = True
		Me.cboDispGridMain.Enabled = True
		Me.cboDispGridMain.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDispGridMain.IntegralHeight = True
		Me.cboDispGridMain.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDispGridMain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDispGridMain.Sorted = False
		Me.cboDispGridMain.TabStop = True
		Me.cboDispGridMain.Visible = True
		Me.cboDispGridMain.Name = "cboDispGridMain"
		Me.cboDispGridSub.Size = New System.Drawing.Size(57, 20)
		Me.cboDispGridSub.Location = New System.Drawing.Point(32, 0)
		Me.cboDispGridSub.Items.AddRange(New Object(){"4", "8", "16", "32", "64", "3", "6", "12", "24", "48", "FREE"})
		Me.cboDispGridSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDispGridSub.TabIndex = 8
		Me.cboDispGridSub.BackColor = System.Drawing.SystemColors.Window
		Me.cboDispGridSub.CausesValidation = True
		Me.cboDispGridSub.Enabled = True
		Me.cboDispGridSub.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDispGridSub.IntegralHeight = True
		Me.cboDispGridSub.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDispGridSub.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDispGridSub.Sorted = False
		Me.cboDispGridSub.TabStop = True
		Me.cboDispGridSub.Visible = True
		Me.cboDispGridSub.Name = "cboDispGridSub"
		Me.lblGridSub.Text = "補助"
		Me.lblGridSub.Size = New System.Drawing.Size(24, 12)
		Me.lblGridSub.Location = New System.Drawing.Point(96, 4)
		Me.lblGridSub.TabIndex = 9
		Me.lblGridSub.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGridSub.BackColor = System.Drawing.SystemColors.Control
		Me.lblGridSub.Enabled = True
		Me.lblGridSub.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGridSub.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGridSub.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGridSub.UseMnemonic = True
		Me.lblGridSub.Visible = True
		Me.lblGridSub.AutoSize = True
		Me.lblGridSub.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblGridSub.Name = "lblGridSub"
		Me.lblGridMain.Text = "Grid"
		Me.lblGridMain.Size = New System.Drawing.Size(24, 12)
		Me.lblGridMain.Location = New System.Drawing.Point(0, 4)
		Me.lblGridMain.TabIndex = 7
		Me.lblGridMain.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGridMain.BackColor = System.Drawing.SystemColors.Control
		Me.lblGridMain.Enabled = True
		Me.lblGridMain.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGridMain.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGridMain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGridMain.UseMnemonic = True
		Me.lblGridMain.Visible = True
		Me.lblGridMain.AutoSize = True
		Me.lblGridMain.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblGridMain.Name = "lblGridMain"
		Me.fraHeader.Size = New System.Drawing.Size(666, 165)
		Me.fraHeader.Location = New System.Drawing.Point(140, 56)
		Me.fraHeader.TabIndex = 19
		Me.fraHeader.BackColor = System.Drawing.SystemColors.Control
		Me.fraHeader.Enabled = True
		Me.fraHeader.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraHeader.Visible = True
		Me.fraHeader.Padding = New System.Windows.Forms.Padding(0)
		Me.fraHeader.Name = "fraHeader"
		Me._fraTop_0.Size = New System.Drawing.Size(217, 125)
		Me._fraTop_0.Location = New System.Drawing.Point(0, 32)
		Me._fraTop_0.TabIndex = 23
		Me._fraTop_0.Visible = False
		Me._fraTop_0.BackColor = System.Drawing.SystemColors.Control
		Me._fraTop_0.Enabled = True
		Me._fraTop_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._fraTop_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._fraTop_0.Padding = New System.Windows.Forms.Padding(0)
		Me._fraTop_0.Name = "_fraTop_0"
		Me.cboPlayer.Size = New System.Drawing.Size(133, 20)
		Me.cboPlayer.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.cboPlayer.Location = New System.Drawing.Point(80, 8)
		Me.cboPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboPlayer.TabIndex = 25
		Me.cboPlayer.BackColor = System.Drawing.SystemColors.Window
		Me.cboPlayer.CausesValidation = True
		Me.cboPlayer.Enabled = True
		Me.cboPlayer.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboPlayer.IntegralHeight = True
		Me.cboPlayer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboPlayer.Sorted = False
		Me.cboPlayer.TabStop = True
		Me.cboPlayer.Visible = True
		Me.cboPlayer.Name = "cboPlayer"
		Me.txtGenre.AutoSize = False
		Me.txtGenre.Size = New System.Drawing.Size(133, 18)
		Me.txtGenre.Location = New System.Drawing.Point(80, 32)
		Me.txtGenre.TabIndex = 27
		Me.txtGenre.AcceptsReturn = True
		Me.txtGenre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtGenre.BackColor = System.Drawing.SystemColors.Window
		Me.txtGenre.CausesValidation = True
		Me.txtGenre.Enabled = True
		Me.txtGenre.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtGenre.HideSelection = True
		Me.txtGenre.ReadOnly = False
		Me.txtGenre.MaxLength = 0
		Me.txtGenre.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtGenre.Multiline = False
		Me.txtGenre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtGenre.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtGenre.TabStop = True
		Me.txtGenre.Visible = True
		Me.txtGenre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtGenre.Name = "txtGenre"
		Me.txtTitle.AutoSize = False
		Me.txtTitle.Size = New System.Drawing.Size(133, 18)
		Me.txtTitle.Location = New System.Drawing.Point(80, 56)
		Me.txtTitle.TabIndex = 29
		Me.txtTitle.AcceptsReturn = True
		Me.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTitle.BackColor = System.Drawing.SystemColors.Window
		Me.txtTitle.CausesValidation = True
		Me.txtTitle.Enabled = True
		Me.txtTitle.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTitle.HideSelection = True
		Me.txtTitle.ReadOnly = False
		Me.txtTitle.MaxLength = 0
		Me.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTitle.Multiline = False
		Me.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTitle.TabStop = True
		Me.txtTitle.Visible = True
		Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTitle.Name = "txtTitle"
		Me.txtArtist.AutoSize = False
		Me.txtArtist.Size = New System.Drawing.Size(133, 18)
		Me.txtArtist.Location = New System.Drawing.Point(80, 80)
		Me.txtArtist.TabIndex = 31
		Me.txtArtist.AcceptsReturn = True
		Me.txtArtist.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtArtist.BackColor = System.Drawing.SystemColors.Window
		Me.txtArtist.CausesValidation = True
		Me.txtArtist.Enabled = True
		Me.txtArtist.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtArtist.HideSelection = True
		Me.txtArtist.ReadOnly = False
		Me.txtArtist.MaxLength = 0
		Me.txtArtist.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtArtist.Multiline = False
		Me.txtArtist.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtArtist.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtArtist.TabStop = True
		Me.txtArtist.Visible = True
		Me.txtArtist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtArtist.Name = "txtArtist"
		Me.cboPlayLevel.Size = New System.Drawing.Size(49, 20)
		Me.cboPlayLevel.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.cboPlayLevel.Location = New System.Drawing.Point(80, 104)
		Me.cboPlayLevel.Items.AddRange(New Object(){"1", "2", "3", "4", "5", "6", "7", "8", "0"})
		Me.cboPlayLevel.TabIndex = 33
		Me.cboPlayLevel.BackColor = System.Drawing.SystemColors.Window
		Me.cboPlayLevel.CausesValidation = True
		Me.cboPlayLevel.Enabled = True
		Me.cboPlayLevel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboPlayLevel.IntegralHeight = True
		Me.cboPlayLevel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboPlayLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboPlayLevel.Sorted = False
		Me.cboPlayLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboPlayLevel.TabStop = True
		Me.cboPlayLevel.Visible = True
		Me.cboPlayLevel.Name = "cboPlayLevel"
		Me.txtBPM.AutoSize = False
		Me.txtBPM.Size = New System.Drawing.Size(41, 18)
		Me.txtBPM.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtBPM.Location = New System.Drawing.Point(172, 104)
		Me.txtBPM.TabIndex = 35
		Me.txtBPM.Text = "130"
		Me.txtBPM.AcceptsReturn = True
		Me.txtBPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtBPM.BackColor = System.Drawing.SystemColors.Window
		Me.txtBPM.CausesValidation = True
		Me.txtBPM.Enabled = True
		Me.txtBPM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBPM.HideSelection = True
		Me.txtBPM.ReadOnly = False
		Me.txtBPM.MaxLength = 0
		Me.txtBPM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBPM.Multiline = False
		Me.txtBPM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBPM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBPM.TabStop = True
		Me.txtBPM.Visible = True
		Me.txtBPM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBPM.Name = "txtBPM"
		Me.lblPlayMode.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblPlayMode.Text = "プレイモード"
		Me.lblPlayMode.Size = New System.Drawing.Size(72, 12)
		Me.lblPlayMode.Location = New System.Drawing.Point(4, 12)
		Me.lblPlayMode.TabIndex = 24
		Me.lblPlayMode.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlayMode.Enabled = True
		Me.lblPlayMode.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlayMode.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlayMode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlayMode.UseMnemonic = True
		Me.lblPlayMode.Visible = True
		Me.lblPlayMode.AutoSize = True
		Me.lblPlayMode.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlayMode.Name = "lblPlayMode"
		Me.lblGenre.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblGenre.Text = "ジャンル"
		Me.lblGenre.Size = New System.Drawing.Size(48, 12)
		Me.lblGenre.Location = New System.Drawing.Point(28, 36)
		Me.lblGenre.TabIndex = 26
		Me.lblGenre.BackColor = System.Drawing.SystemColors.Control
		Me.lblGenre.Enabled = True
		Me.lblGenre.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGenre.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGenre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGenre.UseMnemonic = True
		Me.lblGenre.Visible = True
		Me.lblGenre.AutoSize = True
		Me.lblGenre.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblGenre.Name = "lblGenre"
		Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTitle.Text = "タイトル"
		Me.lblTitle.Size = New System.Drawing.Size(48, 12)
		Me.lblTitle.Location = New System.Drawing.Point(28, 60)
		Me.lblTitle.TabIndex = 28
		Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
		Me.lblTitle.Enabled = True
		Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitle.UseMnemonic = True
		Me.lblTitle.Visible = True
		Me.lblTitle.AutoSize = True
		Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitle.Name = "lblTitle"
		Me.lblArtist.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblArtist.Text = "アーティスト"
		Me.lblArtist.Size = New System.Drawing.Size(72, 12)
		Me.lblArtist.Location = New System.Drawing.Point(4, 84)
		Me.lblArtist.TabIndex = 30
		Me.lblArtist.BackColor = System.Drawing.SystemColors.Control
		Me.lblArtist.Enabled = True
		Me.lblArtist.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblArtist.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblArtist.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblArtist.UseMnemonic = True
		Me.lblArtist.Visible = True
		Me.lblArtist.AutoSize = True
		Me.lblArtist.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblArtist.Name = "lblArtist"
		Me.lblPlayLevel.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblPlayLevel.Text = "難易度表示"
		Me.lblPlayLevel.Size = New System.Drawing.Size(60, 12)
		Me.lblPlayLevel.Location = New System.Drawing.Point(16, 108)
		Me.lblPlayLevel.TabIndex = 32
		Me.lblPlayLevel.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlayLevel.Enabled = True
		Me.lblPlayLevel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlayLevel.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlayLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlayLevel.UseMnemonic = True
		Me.lblPlayLevel.Visible = True
		Me.lblPlayLevel.AutoSize = True
		Me.lblPlayLevel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlayLevel.Name = "lblPlayLevel"
		Me.lblBPM.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblBPM.Text = "BPM"
		Me.lblBPM.Size = New System.Drawing.Size(18, 12)
		Me.lblBPM.Location = New System.Drawing.Point(148, 108)
		Me.lblBPM.TabIndex = 34
		Me.lblBPM.BackColor = System.Drawing.SystemColors.Control
		Me.lblBPM.Enabled = True
		Me.lblBPM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblBPM.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblBPM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblBPM.UseMnemonic = True
		Me.lblBPM.Visible = True
		Me.lblBPM.AutoSize = True
		Me.lblBPM.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblBPM.Name = "lblBPM"
		Me._fraTop_1.Size = New System.Drawing.Size(217, 125)
		Me._fraTop_1.Location = New System.Drawing.Point(220, 32)
		Me._fraTop_1.TabIndex = 36
		Me._fraTop_1.Visible = False
		Me._fraTop_1.BackColor = System.Drawing.SystemColors.Control
		Me._fraTop_1.Enabled = True
		Me._fraTop_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._fraTop_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._fraTop_1.Padding = New System.Windows.Forms.Padding(0)
		Me._fraTop_1.Name = "_fraTop_1"
		Me.cboPlayRank.Size = New System.Drawing.Size(133, 20)
		Me.cboPlayRank.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.cboPlayRank.Location = New System.Drawing.Point(80, 8)
		Me.cboPlayRank.Items.AddRange(New Object(){"Very Hard", "Hard", "Normal", "Easy"})
		Me.cboPlayRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboPlayRank.TabIndex = 38
		Me.cboPlayRank.BackColor = System.Drawing.SystemColors.Window
		Me.cboPlayRank.CausesValidation = True
		Me.cboPlayRank.Enabled = True
		Me.cboPlayRank.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboPlayRank.IntegralHeight = True
		Me.cboPlayRank.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboPlayRank.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboPlayRank.Sorted = False
		Me.cboPlayRank.TabStop = True
		Me.cboPlayRank.Visible = True
		Me.cboPlayRank.Name = "cboPlayRank"
		Me.txtTotal.AutoSize = False
		Me.txtTotal.Size = New System.Drawing.Size(133, 18)
		Me.txtTotal.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtTotal.Location = New System.Drawing.Point(80, 32)
		Me.txtTotal.TabIndex = 40
		Me.txtTotal.AcceptsReturn = True
		Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTotal.BackColor = System.Drawing.SystemColors.Window
		Me.txtTotal.CausesValidation = True
		Me.txtTotal.Enabled = True
		Me.txtTotal.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTotal.HideSelection = True
		Me.txtTotal.ReadOnly = False
		Me.txtTotal.MaxLength = 0
		Me.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTotal.Multiline = False
		Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTotal.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTotal.TabStop = True
		Me.txtTotal.Visible = True
		Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTotal.Name = "txtTotal"
		Me.txtVolume.AutoSize = False
		Me.txtVolume.Size = New System.Drawing.Size(133, 18)
		Me.txtVolume.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtVolume.Location = New System.Drawing.Point(80, 56)
		Me.txtVolume.TabIndex = 42
		Me.txtVolume.AcceptsReturn = True
		Me.txtVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtVolume.BackColor = System.Drawing.SystemColors.Window
		Me.txtVolume.CausesValidation = True
		Me.txtVolume.Enabled = True
		Me.txtVolume.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtVolume.HideSelection = True
		Me.txtVolume.ReadOnly = False
		Me.txtVolume.MaxLength = 0
		Me.txtVolume.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVolume.Multiline = False
		Me.txtVolume.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVolume.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtVolume.TabStop = True
		Me.txtVolume.Visible = True
		Me.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtVolume.Name = "txtVolume"
		Me.txtStageFile.AutoSize = False
		Me.txtStageFile.Size = New System.Drawing.Size(93, 18)
		Me.txtStageFile.Location = New System.Drawing.Point(80, 80)
		Me.txtStageFile.TabIndex = 44
		Me.txtStageFile.AcceptsReturn = True
		Me.txtStageFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtStageFile.BackColor = System.Drawing.SystemColors.Window
		Me.txtStageFile.CausesValidation = True
		Me.txtStageFile.Enabled = True
		Me.txtStageFile.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtStageFile.HideSelection = True
		Me.txtStageFile.ReadOnly = False
		Me.txtStageFile.MaxLength = 0
		Me.txtStageFile.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtStageFile.Multiline = False
		Me.txtStageFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtStageFile.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtStageFile.TabStop = True
		Me.txtStageFile.Visible = True
		Me.txtStageFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtStageFile.Name = "txtStageFile"
		Me.cmdLoadStageFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoadStageFile.Text = "参照"
		Me.cmdLoadStageFile.Size = New System.Drawing.Size(37, 17)
		Me.cmdLoadStageFile.Location = New System.Drawing.Point(176, 80)
		Me.cmdLoadStageFile.TabIndex = 45
		Me.cmdLoadStageFile.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoadStageFile.CausesValidation = True
		Me.cmdLoadStageFile.Enabled = True
		Me.cmdLoadStageFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoadStageFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoadStageFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoadStageFile.TabStop = True
		Me.cmdLoadStageFile.Name = "cmdLoadStageFile"
		Me.cmdLoadMissBMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLoadMissBMP.Text = "参照"
		Me.cmdLoadMissBMP.Size = New System.Drawing.Size(37, 17)
		Me.cmdLoadMissBMP.Location = New System.Drawing.Point(176, 104)
		Me.cmdLoadMissBMP.TabIndex = 48
		Me.cmdLoadMissBMP.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLoadMissBMP.CausesValidation = True
		Me.cmdLoadMissBMP.Enabled = True
		Me.cmdLoadMissBMP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLoadMissBMP.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLoadMissBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLoadMissBMP.TabStop = True
		Me.cmdLoadMissBMP.Name = "cmdLoadMissBMP"
		Me.txtMissBMP.AutoSize = False
		Me.txtMissBMP.Size = New System.Drawing.Size(93, 18)
		Me.txtMissBMP.Location = New System.Drawing.Point(80, 104)
		Me.txtMissBMP.TabIndex = 47
		Me.txtMissBMP.AcceptsReturn = True
		Me.txtMissBMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMissBMP.BackColor = System.Drawing.SystemColors.Window
		Me.txtMissBMP.CausesValidation = True
		Me.txtMissBMP.Enabled = True
		Me.txtMissBMP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMissBMP.HideSelection = True
		Me.txtMissBMP.ReadOnly = False
		Me.txtMissBMP.MaxLength = 0
		Me.txtMissBMP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMissBMP.Multiline = False
		Me.txtMissBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMissBMP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMissBMP.TabStop = True
		Me.txtMissBMP.Visible = True
		Me.txtMissBMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMissBMP.Name = "txtMissBMP"
		Me.lblPlayRank.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblPlayRank.Text = "#RANK"
		Me.lblPlayRank.Size = New System.Drawing.Size(30, 12)
		Me.lblPlayRank.Location = New System.Drawing.Point(45, 12)
		Me.lblPlayRank.TabIndex = 37
		Me.lblPlayRank.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlayRank.Enabled = True
		Me.lblPlayRank.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlayRank.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlayRank.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlayRank.UseMnemonic = True
		Me.lblPlayRank.Visible = True
		Me.lblPlayRank.AutoSize = True
		Me.lblPlayRank.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlayRank.Name = "lblPlayRank"
		Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotal.Text = "#TOTAL"
		Me.lblTotal.Size = New System.Drawing.Size(36, 12)
		Me.lblTotal.Location = New System.Drawing.Point(40, 36)
		Me.lblTotal.TabIndex = 39
		Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
		Me.lblTotal.Enabled = True
		Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotal.UseMnemonic = True
		Me.lblTotal.Visible = True
		Me.lblTotal.AutoSize = True
		Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTotal.Name = "lblTotal"
		Me.lblVolume.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblVolume.Text = "#VOLWAV"
		Me.lblVolume.Size = New System.Drawing.Size(42, 12)
		Me.lblVolume.Location = New System.Drawing.Point(34, 60)
		Me.lblVolume.TabIndex = 41
		Me.lblVolume.BackColor = System.Drawing.SystemColors.Control
		Me.lblVolume.Enabled = True
		Me.lblVolume.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVolume.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVolume.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVolume.UseMnemonic = True
		Me.lblVolume.Visible = True
		Me.lblVolume.AutoSize = True
		Me.lblVolume.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblVolume.Name = "lblVolume"
		Me.lblStageFile.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblStageFile.Text = "#STAGEFILE"
		Me.lblStageFile.Size = New System.Drawing.Size(60, 12)
		Me.lblStageFile.Location = New System.Drawing.Point(15, 84)
		Me.lblStageFile.TabIndex = 43
		Me.lblStageFile.BackColor = System.Drawing.SystemColors.Control
		Me.lblStageFile.Enabled = True
		Me.lblStageFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblStageFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStageFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStageFile.UseMnemonic = True
		Me.lblStageFile.Visible = True
		Me.lblStageFile.AutoSize = True
		Me.lblStageFile.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblStageFile.Name = "lblStageFile"
		Me.lblMissBMP.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblMissBMP.Text = "#BMP00"
		Me.lblMissBMP.Size = New System.Drawing.Size(36, 12)
		Me.lblMissBMP.Location = New System.Drawing.Point(39, 108)
		Me.lblMissBMP.TabIndex = 46
		Me.lblMissBMP.BackColor = System.Drawing.SystemColors.Control
		Me.lblMissBMP.Enabled = True
		Me.lblMissBMP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMissBMP.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMissBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMissBMP.UseMnemonic = True
		Me.lblMissBMP.Visible = True
		Me.lblMissBMP.AutoSize = True
		Me.lblMissBMP.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMissBMP.Name = "lblMissBMP"
		Me._fraTop_2.Size = New System.Drawing.Size(217, 125)
		Me._fraTop_2.Location = New System.Drawing.Point(440, 32)
		Me._fraTop_2.TabIndex = 49
		Me._fraTop_2.Visible = False
		Me._fraTop_2.BackColor = System.Drawing.SystemColors.Control
		Me._fraTop_2.Enabled = True
		Me._fraTop_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._fraTop_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._fraTop_2.Padding = New System.Windows.Forms.Padding(0)
		Me._fraTop_2.Name = "_fraTop_2"
		Me.cboDispFrame.Size = New System.Drawing.Size(133, 20)
		Me.cboDispFrame.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.cboDispFrame.Location = New System.Drawing.Point(80, 8)
		Me.cboDispFrame.Items.AddRange(New Object(){"ハーフ", "セパレート"})
		Me.cboDispFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDispFrame.TabIndex = 51
		Me.cboDispFrame.BackColor = System.Drawing.SystemColors.Window
		Me.cboDispFrame.CausesValidation = True
		Me.cboDispFrame.Enabled = True
		Me.cboDispFrame.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDispFrame.IntegralHeight = True
		Me.cboDispFrame.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDispFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDispFrame.Sorted = False
		Me.cboDispFrame.TabStop = True
		Me.cboDispFrame.Visible = True
		Me.cboDispFrame.Name = "cboDispFrame"
		Me.cboDispSC2P.Size = New System.Drawing.Size(49, 20)
		Me.cboDispSC2P.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.cboDispSC2P.Location = New System.Drawing.Point(164, 56)
		Me.cboDispSC2P.Items.AddRange(New Object(){"左", "右"})
		Me.cboDispSC2P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDispSC2P.TabIndex = 57
		Me.cboDispSC2P.BackColor = System.Drawing.SystemColors.Window
		Me.cboDispSC2P.CausesValidation = True
		Me.cboDispSC2P.Enabled = True
		Me.cboDispSC2P.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDispSC2P.IntegralHeight = True
		Me.cboDispSC2P.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDispSC2P.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDispSC2P.Sorted = False
		Me.cboDispSC2P.TabStop = True
		Me.cboDispSC2P.Visible = True
		Me.cboDispSC2P.Name = "cboDispSC2P"
		Me.cboDispSC1P.Size = New System.Drawing.Size(49, 20)
		Me.cboDispSC1P.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.cboDispSC1P.Location = New System.Drawing.Point(80, 56)
		Me.cboDispSC1P.Items.AddRange(New Object(){"左", "右"})
		Me.cboDispSC1P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDispSC1P.TabIndex = 55
		Me.cboDispSC1P.BackColor = System.Drawing.SystemColors.Window
		Me.cboDispSC1P.CausesValidation = True
		Me.cboDispSC1P.Enabled = True
		Me.cboDispSC1P.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDispSC1P.IntegralHeight = True
		Me.cboDispSC1P.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDispSC1P.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDispSC1P.Sorted = False
		Me.cboDispSC1P.TabStop = True
		Me.cboDispSC1P.Visible = True
		Me.cboDispSC1P.Name = "cboDispSC1P"
		Me.cboDispKey.Size = New System.Drawing.Size(133, 20)
		Me.cboDispKey.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.cboDispKey.Location = New System.Drawing.Point(80, 32)
		Me.cboDispKey.Items.AddRange(New Object(){"5Keys/10Keys", "7Keys/14Keys"})
		Me.cboDispKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDispKey.TabIndex = 53
		Me.cboDispKey.BackColor = System.Drawing.SystemColors.Window
		Me.cboDispKey.CausesValidation = True
		Me.cboDispKey.Enabled = True
		Me.cboDispKey.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDispKey.IntegralHeight = True
		Me.cboDispKey.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDispKey.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDispKey.Sorted = False
		Me.cboDispKey.TabStop = True
		Me.cboDispKey.Visible = True
		Me.cboDispKey.Name = "cboDispKey"
		Me.lblDispFrame.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDispFrame.Text = "キー表示"
		Me.lblDispFrame.Size = New System.Drawing.Size(48, 12)
		Me.lblDispFrame.Location = New System.Drawing.Point(28, 12)
		Me.lblDispFrame.TabIndex = 50
		Me.lblDispFrame.BackColor = System.Drawing.SystemColors.Control
		Me.lblDispFrame.Enabled = True
		Me.lblDispFrame.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDispFrame.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDispFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDispFrame.UseMnemonic = True
		Me.lblDispFrame.Visible = True
		Me.lblDispFrame.AutoSize = True
		Me.lblDispFrame.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDispFrame.Name = "lblDispFrame"
		Me.lblDispSC2P.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDispSC2P.Text = "2P"
		Me.lblDispSC2P.Size = New System.Drawing.Size(12, 12)
		Me.lblDispSC2P.Location = New System.Drawing.Point(148, 60)
		Me.lblDispSC2P.TabIndex = 56
		Me.lblDispSC2P.BackColor = System.Drawing.SystemColors.Control
		Me.lblDispSC2P.Enabled = True
		Me.lblDispSC2P.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDispSC2P.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDispSC2P.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDispSC2P.UseMnemonic = True
		Me.lblDispSC2P.Visible = True
		Me.lblDispSC2P.AutoSize = True
		Me.lblDispSC2P.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDispSC2P.Name = "lblDispSC2P"
		Me.lblDispSC1P.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDispSC1P.Text = "スクラッチ1P"
		Me.lblDispSC1P.Size = New System.Drawing.Size(72, 12)
		Me.lblDispSC1P.Location = New System.Drawing.Point(4, 60)
		Me.lblDispSC1P.TabIndex = 54
		Me.lblDispSC1P.BackColor = System.Drawing.SystemColors.Control
		Me.lblDispSC1P.Enabled = True
		Me.lblDispSC1P.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDispSC1P.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDispSC1P.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDispSC1P.UseMnemonic = True
		Me.lblDispSC1P.Visible = True
		Me.lblDispSC1P.AutoSize = True
		Me.lblDispSC1P.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDispSC1P.Name = "lblDispSC1P"
		Me.lblDispKey.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDispKey.Text = "キー配置"
		Me.lblDispKey.Size = New System.Drawing.Size(48, 12)
		Me.lblDispKey.Location = New System.Drawing.Point(28, 36)
		Me.lblDispKey.TabIndex = 52
		Me.lblDispKey.BackColor = System.Drawing.SystemColors.Control
		Me.lblDispKey.Enabled = True
		Me.lblDispKey.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDispKey.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDispKey.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDispKey.UseMnemonic = True
		Me.lblDispKey.Visible = True
		Me.lblDispKey.AutoSize = True
		Me.lblDispKey.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDispKey.Name = "lblDispKey"
		Me._optChangeTop_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optChangeTop_0.Text = "基本"
		Me._optChangeTop_0.Size = New System.Drawing.Size(61, 21)
		Me._optChangeTop_0.Location = New System.Drawing.Point(0, 0)
		Me._optChangeTop_0.Appearance = System.Windows.Forms.Appearance.Button
		Me._optChangeTop_0.TabIndex = 20
		Me._optChangeTop_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChangeTop_0.BackColor = System.Drawing.SystemColors.Control
		Me._optChangeTop_0.CausesValidation = True
		Me._optChangeTop_0.Enabled = True
		Me._optChangeTop_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optChangeTop_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChangeTop_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChangeTop_0.TabStop = True
		Me._optChangeTop_0.Checked = False
		Me._optChangeTop_0.Visible = True
		Me._optChangeTop_0.Name = "_optChangeTop_0"
		Me._optChangeTop_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optChangeTop_2.Text = "環境"
		Me._optChangeTop_2.Size = New System.Drawing.Size(61, 21)
		Me._optChangeTop_2.Location = New System.Drawing.Point(130, 0)
		Me._optChangeTop_2.Appearance = System.Windows.Forms.Appearance.Button
		Me._optChangeTop_2.TabIndex = 22
		Me._optChangeTop_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChangeTop_2.BackColor = System.Drawing.SystemColors.Control
		Me._optChangeTop_2.CausesValidation = True
		Me._optChangeTop_2.Enabled = True
		Me._optChangeTop_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optChangeTop_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChangeTop_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChangeTop_2.TabStop = True
		Me._optChangeTop_2.Checked = False
		Me._optChangeTop_2.Visible = True
		Me._optChangeTop_2.Name = "_optChangeTop_2"
		Me._optChangeTop_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optChangeTop_1.Text = "拡張"
		Me._optChangeTop_1.Size = New System.Drawing.Size(61, 21)
		Me._optChangeTop_1.Location = New System.Drawing.Point(65, 0)
		Me._optChangeTop_1.Appearance = System.Windows.Forms.Appearance.Button
		Me._optChangeTop_1.TabIndex = 21
		Me._optChangeTop_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChangeTop_1.BackColor = System.Drawing.SystemColors.Control
		Me._optChangeTop_1.CausesValidation = True
		Me._optChangeTop_1.Enabled = True
		Me._optChangeTop_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optChangeTop_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChangeTop_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChangeTop_1.TabStop = True
		Me._optChangeTop_1.Checked = False
		Me._optChangeTop_1.Visible = True
		Me._optChangeTop_1.Name = "_optChangeTop_1"
		Me.fraMaterial.Size = New System.Drawing.Size(1105, 269)
		Me.fraMaterial.Location = New System.Drawing.Point(140, 228)
		Me.fraMaterial.TabIndex = 58
		Me.fraMaterial.BackColor = System.Drawing.SystemColors.Control
		Me.fraMaterial.Enabled = True
		Me.fraMaterial.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraMaterial.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraMaterial.Visible = True
		Me.fraMaterial.Padding = New System.Windows.Forms.Padding(0)
		Me.fraMaterial.Name = "fraMaterial"
		Me._optChangeBottom_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optChangeBottom_0.Text = "#WAV"
		Me._optChangeBottom_0.Size = New System.Drawing.Size(61, 21)
		Me._optChangeBottom_0.Location = New System.Drawing.Point(0, 0)
		Me._optChangeBottom_0.Appearance = System.Windows.Forms.Appearance.Button
		Me._optChangeBottom_0.TabIndex = 59
		Me._optChangeBottom_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChangeBottom_0.BackColor = System.Drawing.SystemColors.Control
		Me._optChangeBottom_0.CausesValidation = True
		Me._optChangeBottom_0.Enabled = True
		Me._optChangeBottom_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optChangeBottom_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChangeBottom_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChangeBottom_0.TabStop = True
		Me._optChangeBottom_0.Checked = False
		Me._optChangeBottom_0.Visible = True
		Me._optChangeBottom_0.Name = "_optChangeBottom_0"
		Me._optChangeBottom_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optChangeBottom_1.Text = "#BMP"
		Me._optChangeBottom_1.Size = New System.Drawing.Size(61, 21)
		Me._optChangeBottom_1.Location = New System.Drawing.Point(65, 0)
		Me._optChangeBottom_1.Appearance = System.Windows.Forms.Appearance.Button
		Me._optChangeBottom_1.TabIndex = 60
		Me._optChangeBottom_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChangeBottom_1.BackColor = System.Drawing.SystemColors.Control
		Me._optChangeBottom_1.CausesValidation = True
		Me._optChangeBottom_1.Enabled = True
		Me._optChangeBottom_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optChangeBottom_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChangeBottom_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChangeBottom_1.TabStop = True
		Me._optChangeBottom_1.Checked = False
		Me._optChangeBottom_1.Visible = True
		Me._optChangeBottom_1.Name = "_optChangeBottom_1"
		Me._optChangeBottom_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optChangeBottom_2.Text = "#BGA"
		Me._optChangeBottom_2.Size = New System.Drawing.Size(61, 21)
		Me._optChangeBottom_2.Location = New System.Drawing.Point(130, 0)
		Me._optChangeBottom_2.Appearance = System.Windows.Forms.Appearance.Button
		Me._optChangeBottom_2.TabIndex = 61
		Me._optChangeBottom_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChangeBottom_2.BackColor = System.Drawing.SystemColors.Control
		Me._optChangeBottom_2.CausesValidation = True
		Me._optChangeBottom_2.Enabled = True
		Me._optChangeBottom_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optChangeBottom_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChangeBottom_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChangeBottom_2.TabStop = True
		Me._optChangeBottom_2.Checked = False
		Me._optChangeBottom_2.Visible = True
		Me._optChangeBottom_2.Name = "_optChangeBottom_2"
		Me._optChangeBottom_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optChangeBottom_3.Text = "拍子"
		Me._optChangeBottom_3.Size = New System.Drawing.Size(61, 21)
		Me._optChangeBottom_3.Location = New System.Drawing.Point(0, 25)
		Me._optChangeBottom_3.Appearance = System.Windows.Forms.Appearance.Button
		Me._optChangeBottom_3.TabIndex = 62
		Me._optChangeBottom_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChangeBottom_3.BackColor = System.Drawing.SystemColors.Control
		Me._optChangeBottom_3.CausesValidation = True
		Me._optChangeBottom_3.Enabled = True
		Me._optChangeBottom_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optChangeBottom_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChangeBottom_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChangeBottom_3.TabStop = True
		Me._optChangeBottom_3.Checked = False
		Me._optChangeBottom_3.Visible = True
		Me._optChangeBottom_3.Name = "_optChangeBottom_3"
		Me._optChangeBottom_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._optChangeBottom_4.Text = "拡張命令"
		Me._optChangeBottom_4.Size = New System.Drawing.Size(61, 21)
		Me._optChangeBottom_4.Location = New System.Drawing.Point(65, 25)
		Me._optChangeBottom_4.Appearance = System.Windows.Forms.Appearance.Button
		Me._optChangeBottom_4.TabIndex = 63
		Me._optChangeBottom_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChangeBottom_4.BackColor = System.Drawing.SystemColors.Control
		Me._optChangeBottom_4.CausesValidation = True
		Me._optChangeBottom_4.Enabled = True
		Me._optChangeBottom_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optChangeBottom_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChangeBottom_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChangeBottom_4.TabStop = True
		Me._optChangeBottom_4.Checked = False
		Me._optChangeBottom_4.Visible = True
		Me._optChangeBottom_4.Name = "_optChangeBottom_4"
		Me._fraBottom_4.Size = New System.Drawing.Size(217, 233)
		Me._fraBottom_4.Location = New System.Drawing.Point(884, 32)
		Me._fraBottom_4.TabIndex = 93
		Me._fraBottom_4.Visible = False
		Me._fraBottom_4.BackColor = System.Drawing.SystemColors.Control
		Me._fraBottom_4.Enabled = True
		Me._fraBottom_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._fraBottom_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._fraBottom_4.Padding = New System.Windows.Forms.Padding(0)
		Me._fraBottom_4.Name = "_fraBottom_4"
		Me.txtExInfo.AutoSize = False
		Me.txtExInfo.Size = New System.Drawing.Size(213, 217)
		Me.txtExInfo.Location = New System.Drawing.Point(0, 8)
		Me.txtExInfo.Multiline = True
		Me.txtExInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtExInfo.WordWrap = False
		Me.txtExInfo.TabIndex = 94
		Me.txtExInfo.AcceptsReturn = True
		Me.txtExInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtExInfo.BackColor = System.Drawing.SystemColors.Window
		Me.txtExInfo.CausesValidation = True
		Me.txtExInfo.Enabled = True
		Me.txtExInfo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtExInfo.HideSelection = True
		Me.txtExInfo.ReadOnly = False
		Me.txtExInfo.MaxLength = 0
		Me.txtExInfo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtExInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtExInfo.TabStop = True
		Me.txtExInfo.Visible = True
		Me.txtExInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtExInfo.Name = "txtExInfo"
		Me._fraBottom_0.Size = New System.Drawing.Size(217, 209)
		Me._fraBottom_0.Location = New System.Drawing.Point(4, 56)
		Me._fraBottom_0.TabIndex = 64
		Me._fraBottom_0.Visible = False
		Me._fraBottom_0.BackColor = System.Drawing.SystemColors.Control
		Me._fraBottom_0.Enabled = True
		Me._fraBottom_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._fraBottom_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._fraBottom_0.Padding = New System.Windows.Forms.Padding(0)
		Me._fraBottom_0.Name = "_fraBottom_0"
		Me.cmdSoundExcUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSoundExcUp.Text = "▲"
		Me.cmdSoundExcUp.Size = New System.Drawing.Size(21, 21)
		Me.cmdSoundExcUp.Location = New System.Drawing.Point(61, 180)
		Me.cmdSoundExcUp.TabIndex = 67
		Me.cmdSoundExcUp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSoundExcUp.CausesValidation = True
		Me.cmdSoundExcUp.Enabled = True
		Me.cmdSoundExcUp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSoundExcUp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSoundExcUp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSoundExcUp.TabStop = True
		Me.cmdSoundExcUp.Name = "cmdSoundExcUp"
		Me.cmdSoundExcDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSoundExcDown.Text = "▼"
		Me.cmdSoundExcDown.Size = New System.Drawing.Size(21, 21)
		Me.cmdSoundExcDown.Location = New System.Drawing.Point(86, 180)
		Me.cmdSoundExcDown.TabIndex = 68
		Me.cmdSoundExcDown.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSoundExcDown.CausesValidation = True
		Me.cmdSoundExcDown.Enabled = True
		Me.cmdSoundExcDown.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSoundExcDown.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSoundExcDown.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSoundExcDown.TabStop = True
		Me.cmdSoundExcDown.Name = "cmdSoundExcDown"
		Me.cmdSoundDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSoundDelete.Text = "消去"
		Me.cmdSoundDelete.Size = New System.Drawing.Size(41, 21)
		Me.cmdSoundDelete.Location = New System.Drawing.Point(126, 180)
		Me.cmdSoundDelete.TabIndex = 69
		Me.cmdSoundDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSoundDelete.CausesValidation = True
		Me.cmdSoundDelete.Enabled = True
		Me.cmdSoundDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSoundDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSoundDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSoundDelete.TabStop = True
		Me.cmdSoundDelete.Name = "cmdSoundDelete"
		Me.cmdSoundLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSoundLoad.Text = "指定"
		Me.cmdSoundLoad.Size = New System.Drawing.Size(41, 21)
		Me.cmdSoundLoad.Location = New System.Drawing.Point(172, 180)
		Me.cmdSoundLoad.TabIndex = 70
		Me.cmdSoundLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSoundLoad.CausesValidation = True
		Me.cmdSoundLoad.Enabled = True
		Me.cmdSoundLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSoundLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSoundLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSoundLoad.TabStop = True
		Me.cmdSoundLoad.Name = "cmdSoundLoad"
		Me.cmdSoundStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSoundStop.Text = "停止"
		Me.cmdSoundStop.Size = New System.Drawing.Size(53, 21)
		Me.cmdSoundStop.Location = New System.Drawing.Point(0, 180)
		Me.cmdSoundStop.TabIndex = 66
		Me.cmdSoundStop.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSoundStop.CausesValidation = True
		Me.cmdSoundStop.Enabled = True
		Me.cmdSoundStop.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSoundStop.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSoundStop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSoundStop.TabStop = True
		Me.cmdSoundStop.Name = "cmdSoundStop"
		Me.lstWAV.Size = New System.Drawing.Size(213, 151)
		Me.lstWAV.Location = New System.Drawing.Point(0, 8)
		Me.lstWAV.TabIndex = 65
		Me.lstWAV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstWAV.BackColor = System.Drawing.SystemColors.Window
		Me.lstWAV.CausesValidation = True
		Me.lstWAV.Enabled = True
		Me.lstWAV.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstWAV.IntegralHeight = True
		Me.lstWAV.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstWAV.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstWAV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstWAV.Sorted = False
		Me.lstWAV.TabStop = True
		Me.lstWAV.Visible = True
		Me.lstWAV.MultiColumn = False
		Me.lstWAV.Name = "lstWAV"
		Me._fraBottom_1.Size = New System.Drawing.Size(217, 233)
		Me._fraBottom_1.Location = New System.Drawing.Point(224, 32)
		Me._fraBottom_1.TabIndex = 71
		Me._fraBottom_1.Visible = False
		Me._fraBottom_1.BackColor = System.Drawing.SystemColors.Control
		Me._fraBottom_1.Enabled = True
		Me._fraBottom_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._fraBottom_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._fraBottom_1.Padding = New System.Windows.Forms.Padding(0)
		Me._fraBottom_1.Name = "_fraBottom_1"
		Me.cmdBMPExcDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBMPExcDown.Text = "▼"
		Me.cmdBMPExcDown.Size = New System.Drawing.Size(21, 21)
		Me.cmdBMPExcDown.Location = New System.Drawing.Point(86, 204)
		Me.cmdBMPExcDown.TabIndex = 75
		Me.cmdBMPExcDown.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBMPExcDown.CausesValidation = True
		Me.cmdBMPExcDown.Enabled = True
		Me.cmdBMPExcDown.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBMPExcDown.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBMPExcDown.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBMPExcDown.TabStop = True
		Me.cmdBMPExcDown.Name = "cmdBMPExcDown"
		Me.cmdBMPExcUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBMPExcUp.Text = "▲"
		Me.cmdBMPExcUp.Size = New System.Drawing.Size(21, 21)
		Me.cmdBMPExcUp.Location = New System.Drawing.Point(61, 204)
		Me.cmdBMPExcUp.TabIndex = 74
		Me.cmdBMPExcUp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBMPExcUp.CausesValidation = True
		Me.cmdBMPExcUp.Enabled = True
		Me.cmdBMPExcUp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBMPExcUp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBMPExcUp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBMPExcUp.TabStop = True
		Me.cmdBMPExcUp.Name = "cmdBMPExcUp"
		Me.lstBMP.Size = New System.Drawing.Size(213, 175)
		Me.lstBMP.Location = New System.Drawing.Point(0, 8)
		Me.lstBMP.TabIndex = 72
		Me.lstBMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstBMP.BackColor = System.Drawing.SystemColors.Window
		Me.lstBMP.CausesValidation = True
		Me.lstBMP.Enabled = True
		Me.lstBMP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstBMP.IntegralHeight = True
		Me.lstBMP.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstBMP.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstBMP.Sorted = False
		Me.lstBMP.TabStop = True
		Me.lstBMP.Visible = True
		Me.lstBMP.MultiColumn = False
		Me.lstBMP.Name = "lstBMP"
		Me.cmdBMPDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBMPDelete.Text = "消去"
		Me.cmdBMPDelete.Size = New System.Drawing.Size(41, 21)
		Me.cmdBMPDelete.Location = New System.Drawing.Point(126, 204)
		Me.cmdBMPDelete.TabIndex = 76
		Me.cmdBMPDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBMPDelete.CausesValidation = True
		Me.cmdBMPDelete.Enabled = True
		Me.cmdBMPDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBMPDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBMPDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBMPDelete.TabStop = True
		Me.cmdBMPDelete.Name = "cmdBMPDelete"
		Me.cmdBMPLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBMPLoad.Text = "指定"
		Me.cmdBMPLoad.Size = New System.Drawing.Size(41, 21)
		Me.cmdBMPLoad.Location = New System.Drawing.Point(172, 204)
		Me.cmdBMPLoad.TabIndex = 77
		Me.cmdBMPLoad.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBMPLoad.CausesValidation = True
		Me.cmdBMPLoad.Enabled = True
		Me.cmdBMPLoad.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBMPLoad.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBMPLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBMPLoad.TabStop = True
		Me.cmdBMPLoad.Name = "cmdBMPLoad"
		Me.cmdBMPPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBMPPreview.Text = "表示"
		Me.cmdBMPPreview.Size = New System.Drawing.Size(53, 21)
		Me.cmdBMPPreview.Location = New System.Drawing.Point(0, 204)
		Me.cmdBMPPreview.TabIndex = 73
		Me.cmdBMPPreview.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBMPPreview.CausesValidation = True
		Me.cmdBMPPreview.Enabled = True
		Me.cmdBMPPreview.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBMPPreview.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBMPPreview.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBMPPreview.TabStop = True
		Me.cmdBMPPreview.Name = "cmdBMPPreview"
		Me._fraBottom_2.Size = New System.Drawing.Size(217, 233)
		Me._fraBottom_2.Location = New System.Drawing.Point(444, 32)
		Me._fraBottom_2.TabIndex = 78
		Me._fraBottom_2.Visible = False
		Me._fraBottom_2.BackColor = System.Drawing.SystemColors.Control
		Me._fraBottom_2.Enabled = True
		Me._fraBottom_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._fraBottom_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._fraBottom_2.Padding = New System.Windows.Forms.Padding(0)
		Me._fraBottom_2.Name = "_fraBottom_2"
		Me.cmdBGAExcDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBGAExcDown.Text = "▼"
		Me.cmdBGAExcDown.Size = New System.Drawing.Size(21, 21)
		Me.cmdBGAExcDown.Location = New System.Drawing.Point(86, 204)
		Me.cmdBGAExcDown.TabIndex = 83
		Me.cmdBGAExcDown.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBGAExcDown.CausesValidation = True
		Me.cmdBGAExcDown.Enabled = True
		Me.cmdBGAExcDown.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBGAExcDown.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBGAExcDown.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBGAExcDown.TabStop = True
		Me.cmdBGAExcDown.Name = "cmdBGAExcDown"
		Me.cmdBGAExcUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBGAExcUp.Text = "▲"
		Me.cmdBGAExcUp.Size = New System.Drawing.Size(21, 21)
		Me.cmdBGAExcUp.Location = New System.Drawing.Point(61, 204)
		Me.cmdBGAExcUp.TabIndex = 82
		Me.cmdBGAExcUp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBGAExcUp.CausesValidation = True
		Me.cmdBGAExcUp.Enabled = True
		Me.cmdBGAExcUp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBGAExcUp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBGAExcUp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBGAExcUp.TabStop = True
		Me.cmdBGAExcUp.Name = "cmdBGAExcUp"
		Me.txtBGAInput.AutoSize = False
		Me.txtBGAInput.Size = New System.Drawing.Size(213, 21)
		Me.txtBGAInput.Location = New System.Drawing.Point(0, 176)
		Me.txtBGAInput.TabIndex = 80
		Me.txtBGAInput.AcceptsReturn = True
		Me.txtBGAInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtBGAInput.BackColor = System.Drawing.SystemColors.Window
		Me.txtBGAInput.CausesValidation = True
		Me.txtBGAInput.Enabled = True
		Me.txtBGAInput.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBGAInput.HideSelection = True
		Me.txtBGAInput.ReadOnly = False
		Me.txtBGAInput.MaxLength = 0
		Me.txtBGAInput.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBGAInput.Multiline = False
		Me.txtBGAInput.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBGAInput.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBGAInput.TabStop = True
		Me.txtBGAInput.Visible = True
		Me.txtBGAInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBGAInput.Name = "txtBGAInput"
		Me.cmdBGAPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBGAPreview.Text = "表示"
		Me.cmdBGAPreview.Size = New System.Drawing.Size(53, 21)
		Me.cmdBGAPreview.Location = New System.Drawing.Point(0, 205)
		Me.cmdBGAPreview.TabIndex = 81
		Me.cmdBGAPreview.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBGAPreview.CausesValidation = True
		Me.cmdBGAPreview.Enabled = True
		Me.cmdBGAPreview.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBGAPreview.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBGAPreview.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBGAPreview.TabStop = True
		Me.cmdBGAPreview.Name = "cmdBGAPreview"
		Me.cmdBGASet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBGASet.Text = "入力"
		Me.cmdBGASet.Size = New System.Drawing.Size(41, 21)
		Me.cmdBGASet.Location = New System.Drawing.Point(172, 204)
		Me.cmdBGASet.TabIndex = 85
		Me.cmdBGASet.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBGASet.CausesValidation = True
		Me.cmdBGASet.Enabled = True
		Me.cmdBGASet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBGASet.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBGASet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBGASet.TabStop = True
		Me.cmdBGASet.Name = "cmdBGASet"
		Me.cmdBGADelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBGADelete.Text = "消去"
		Me.cmdBGADelete.Size = New System.Drawing.Size(41, 21)
		Me.cmdBGADelete.Location = New System.Drawing.Point(126, 204)
		Me.cmdBGADelete.TabIndex = 84
		Me.cmdBGADelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBGADelete.CausesValidation = True
		Me.cmdBGADelete.Enabled = True
		Me.cmdBGADelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBGADelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBGADelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBGADelete.TabStop = True
		Me.cmdBGADelete.Name = "cmdBGADelete"
		Me.lstBGA.Size = New System.Drawing.Size(213, 151)
		Me.lstBGA.Location = New System.Drawing.Point(0, 8)
		Me.lstBGA.TabIndex = 79
		Me.lstBGA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstBGA.BackColor = System.Drawing.SystemColors.Window
		Me.lstBGA.CausesValidation = True
		Me.lstBGA.Enabled = True
		Me.lstBGA.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstBGA.IntegralHeight = True
		Me.lstBGA.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstBGA.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstBGA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstBGA.Sorted = False
		Me.lstBGA.TabStop = True
		Me.lstBGA.Visible = True
		Me.lstBGA.MultiColumn = False
		Me.lstBGA.Name = "lstBGA"
		Me._fraBottom_3.Size = New System.Drawing.Size(217, 233)
		Me._fraBottom_3.Location = New System.Drawing.Point(664, 32)
		Me._fraBottom_3.TabIndex = 86
		Me._fraBottom_3.Visible = False
		Me._fraBottom_3.BackColor = System.Drawing.SystemColors.Control
		Me._fraBottom_3.Enabled = True
		Me._fraBottom_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._fraBottom_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._fraBottom_3.Padding = New System.Windows.Forms.Padding(0)
		Me._fraBottom_3.Name = "_fraBottom_3"
		Me.cboNumerator.Size = New System.Drawing.Size(41, 20)
		Me.cboNumerator.Location = New System.Drawing.Point(75, 204)
		Me.cboNumerator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboNumerator.TabIndex = 89
		Me.cboNumerator.BackColor = System.Drawing.SystemColors.Window
		Me.cboNumerator.CausesValidation = True
		Me.cboNumerator.Enabled = True
		Me.cboNumerator.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboNumerator.IntegralHeight = True
		Me.cboNumerator.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboNumerator.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboNumerator.Sorted = False
		Me.cboNumerator.TabStop = True
		Me.cboNumerator.Visible = True
		Me.cboNumerator.Name = "cboNumerator"
		Me.cboDenominator.Size = New System.Drawing.Size(41, 20)
		Me.cboDenominator.Location = New System.Drawing.Point(127, 204)
		Me.cboDenominator.Items.AddRange(New Object(){"4", "8", "16", "32", "64"})
		Me.cboDenominator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDenominator.TabIndex = 91
		Me.cboDenominator.BackColor = System.Drawing.SystemColors.Window
		Me.cboDenominator.CausesValidation = True
		Me.cboDenominator.Enabled = True
		Me.cboDenominator.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDenominator.IntegralHeight = True
		Me.cboDenominator.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDenominator.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDenominator.Sorted = False
		Me.cboDenominator.TabStop = True
		Me.cboDenominator.Visible = True
		Me.cboDenominator.Name = "cboDenominator"
		Me.cmdMeasureSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMeasureSelectAll.Text = "全選択"
		Me.cmdMeasureSelectAll.Size = New System.Drawing.Size(53, 21)
		Me.cmdMeasureSelectAll.Location = New System.Drawing.Point(0, 204)
		Me.cmdMeasureSelectAll.TabIndex = 88
		Me.cmdMeasureSelectAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMeasureSelectAll.CausesValidation = True
		Me.cmdMeasureSelectAll.Enabled = True
		Me.cmdMeasureSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMeasureSelectAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMeasureSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMeasureSelectAll.TabStop = True
		Me.cmdMeasureSelectAll.Name = "cmdMeasureSelectAll"
		Me.cmdInputMeasureLen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdInputMeasureLen.Text = "入力"
		Me.cmdInputMeasureLen.Size = New System.Drawing.Size(41, 21)
		Me.cmdInputMeasureLen.Location = New System.Drawing.Point(172, 204)
		Me.cmdInputMeasureLen.TabIndex = 92
		Me.cmdInputMeasureLen.BackColor = System.Drawing.SystemColors.Control
		Me.cmdInputMeasureLen.CausesValidation = True
		Me.cmdInputMeasureLen.Enabled = True
		Me.cmdInputMeasureLen.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdInputMeasureLen.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdInputMeasureLen.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdInputMeasureLen.TabStop = True
		Me.cmdInputMeasureLen.Name = "cmdInputMeasureLen"
		Me.lstMeasureLen.Size = New System.Drawing.Size(213, 175)
		Me.lstMeasureLen.Location = New System.Drawing.Point(0, 8)
		Me.lstMeasureLen.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
		Me.lstMeasureLen.TabIndex = 87
		Me.lstMeasureLen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstMeasureLen.BackColor = System.Drawing.SystemColors.Window
		Me.lstMeasureLen.CausesValidation = True
		Me.lstMeasureLen.Enabled = True
		Me.lstMeasureLen.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstMeasureLen.IntegralHeight = True
		Me.lstMeasureLen.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstMeasureLen.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstMeasureLen.Sorted = False
		Me.lstMeasureLen.TabStop = True
		Me.lstMeasureLen.Visible = True
		Me.lstMeasureLen.MultiColumn = False
		Me.lstMeasureLen.Name = "lstMeasureLen"
		Me.lblFraction.Text = "/"
		Me.lblFraction.Size = New System.Drawing.Size(6, 12)
		Me.lblFraction.Location = New System.Drawing.Point(119, 208)
		Me.lblFraction.TabIndex = 90
		Me.lblFraction.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFraction.BackColor = System.Drawing.SystemColors.Control
		Me.lblFraction.Enabled = True
		Me.lblFraction.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblFraction.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFraction.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFraction.UseMnemonic = True
		Me.lblFraction.Visible = True
		Me.lblFraction.AutoSize = False
		Me.lblFraction.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblFraction.Name = "lblFraction"
		Me.picMain.BackColor = System.Drawing.Color.Black
		Me.picMain.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.picMain.ForeColor = System.Drawing.Color.FromArgb(192, 192, 192)
		Me.picMain.Size = New System.Drawing.Size(57, 33)
		Me.picMain.Location = New System.Drawing.Point(0, 56)
		Me.picMain.TabIndex = 0
		Me.picMain.TabStop = False
		Me.picMain.Dock = System.Windows.Forms.DockStyle.None
		Me.picMain.CausesValidation = True
		Me.picMain.Enabled = True
		Me.picMain.Cursor = System.Windows.Forms.Cursors.Default
		Me.picMain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picMain.Visible = True
		Me.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picMain.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picMain.Name = "picMain"
		Me.hsbMain.Size = New System.Drawing.Size(113, 17)
		Me.hsbMain.LargeChange = 128
		Me.hsbMain.Location = New System.Drawing.Point(0, 456)
		Me.hsbMain.Maximum = 0
		Me.hsbMain.SmallChange = 32
		Me.hsbMain.TabIndex = 2
		Me.hsbMain.TabStop = False
		Me.hsbMain.CausesValidation = True
		Me.hsbMain.Enabled = True
		Me.hsbMain.Minimum = 0
		Me.hsbMain.Cursor = System.Windows.Forms.Cursors.Default
		Me.hsbMain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.hsbMain.Value = 0
		Me.hsbMain.Visible = True
		Me.hsbMain.Name = "hsbMain"
		Me.vsbMain.Size = New System.Drawing.Size(17, 397)
		Me.vsbMain.LargeChange = 8
		Me.vsbMain.Location = New System.Drawing.Point(112, 60)
		Me.vsbMain.Maximum = 64
		Me.vsbMain.Minimum = 0
		Me.vsbMain.TabIndex = 1
		Me.vsbMain.TabStop = False
		Me.vsbMain.CausesValidation = True
		Me.vsbMain.Enabled = True
		Me.vsbMain.Cursor = System.Windows.Forms.Cursors.Default
		Me.vsbMain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.vsbMain.SmallChange = 1
		Me.vsbMain.Value = 0
		Me.vsbMain.Visible = True
		Me.vsbMain.Name = "vsbMain"
		Me.dlgMainOpen.Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"
		Me.dlgMainSave.Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"
		Me.tlbMenu.ShowItemToolTips = True
		Me.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top
		Me.tlbMenu.Size = New System.Drawing.Size(1192, 44)
		Me.tlbMenu.Location = New System.Drawing.Point(0, 24)
		Me.tlbMenu.TabIndex = 3
		Me.tlbMenu.CanOverflow = False
		Me.tlbMenu.ImageList = ilsMenu
		Me.tlbMenu.Name = "tlbMenu"
		Me._tlbMenu_Button1.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button1.AutoSize = False
		Me._tlbMenu_Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button1.Name = "New"
		Me._tlbMenu_Button1.ToolTipText = "新規作成"
		Me._tlbMenu_Button1.ImageIndex = 0
		Me._tlbMenu_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button2.Size = New System.Drawing.Size(37, 22)
		Me._tlbMenu_Button2.AutoSize = False
		Me._tlbMenu_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button2.Name = "Open"
		Me._tlbMenu_Button2.ToolTipText = "開く"
		Me._tlbMenu_Button2.ImageIndex = 1
		Me._tlbMenu_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button3.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button3.AutoSize = False
		Me._tlbMenu_Button3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button3.Name = "Reload"
		Me._tlbMenu_Button3.ToolTipText = "再読み込み"
		Me._tlbMenu_Button3.ImageIndex = 2
		Me._tlbMenu_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button4.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button4.AutoSize = False
		Me._tlbMenu_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button4.Name = "Save"
		Me._tlbMenu_Button4.ToolTipText = "上書き保存"
		Me._tlbMenu_Button4.ImageIndex = 3
		Me._tlbMenu_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button5.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button5.AutoSize = False
		Me._tlbMenu_Button5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button5.Name = "SaveAs"
		Me._tlbMenu_Button5.ToolTipText = "名前を付けて保存"
		Me._tlbMenu_Button5.ImageIndex = 4
		Me._tlbMenu_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button6.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button6.AutoSize = False
		Me._tlbMenu_Button6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button6.Name = "SepMode"
		Me._tlbMenu_Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button7.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button7.AutoSize = False
		Me._tlbMenu_Button7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button7.Name = "Edit"
		Me._tlbMenu_Button7.ToolTipText = "編集"
		Me._tlbMenu_Button7.ImageIndex = 5
		Me._tlbMenu_Button7.Checked = True
		Me._tlbMenu_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button8.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button8.AutoSize = False
		Me._tlbMenu_Button8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button8.Name = "Write"
		Me._tlbMenu_Button8.ToolTipText = "書込"
		Me._tlbMenu_Button8.ImageIndex = 6
		Me._tlbMenu_Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button9.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button9.AutoSize = False
		Me._tlbMenu_Button9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button9.Name = "Delete"
		Me._tlbMenu_Button9.ToolTipText = "消去"
		Me._tlbMenu_Button9.ImageIndex = 7
		Me._tlbMenu_Button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button10.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button10.AutoSize = False
		Me._tlbMenu_Button10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button10.Name = "SepViewer"
		Me._tlbMenu_Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button11.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button11.AutoSize = False
		Me._tlbMenu_Button11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button11.Name = "Viewer"
		Me._tlbMenu_Button11.Width = 1395
		Me._tlbMenu_Button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button12.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button12.AutoSize = False
		Me._tlbMenu_Button12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button12.Name = "PlayAll"
		Me._tlbMenu_Button12.ToolTipText = "最初から再生"
		Me._tlbMenu_Button12.ImageIndex = 8
		Me._tlbMenu_Button12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button13.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button13.AutoSize = False
		Me._tlbMenu_Button13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button13.Name = "Play"
		Me._tlbMenu_Button13.ToolTipText = "現在位置から再生"
		Me._tlbMenu_Button13.ImageIndex = 9
		Me._tlbMenu_Button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button14.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button14.AutoSize = False
		Me._tlbMenu_Button14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button14.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button14.Name = "Stop"
		Me._tlbMenu_Button14.ToolTipText = "停止"
		Me._tlbMenu_Button14.ImageIndex = 10
		Me._tlbMenu_Button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button15.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button15.AutoSize = False
		Me._tlbMenu_Button15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button15.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button15.Name = "SepGrid"
		Me._tlbMenu_Button15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button16.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button16.AutoSize = False
		Me._tlbMenu_Button16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button16.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button16.Name = "ChangeGrid"
		Me._tlbMenu_Button16.Width = 2955
		Me._tlbMenu_Button16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button17.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button17.AutoSize = False
		Me._tlbMenu_Button17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button17.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button17.Name = "SepSize"
		Me._tlbMenu_Button17.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button18.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button18.AutoSize = False
		Me._tlbMenu_Button18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button18.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button18.Name = "DispSize"
		Me._tlbMenu_Button18.Width = 2955
		Me._tlbMenu_Button18.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button19.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button19.AutoSize = False
		Me._tlbMenu_Button19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button19.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button19.Name = "SepResolution"
		Me._tlbMenu_Button19.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tlbMenu_Button20.Size = New System.Drawing.Size(24, 22)
		Me._tlbMenu_Button20.AutoSize = False
		Me._tlbMenu_Button20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbMenu_Button20.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbMenu_Button20.Name = "Resolution"
		Me._tlbMenu_Button20.Width = 2055
		Me._tlbMenu_Button20.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._linStatusBar_0.BorderColor = System.Drawing.SystemColors.ControlDark
		Me._linStatusBar_0.X1 = 0
		Me._linStatusBar_0.X2 = 1244
		Me._linStatusBar_0.Y1 = 480
		Me._linStatusBar_0.Y2 = 480
		Me._linStatusBar_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linStatusBar_0.BorderWidth = 1
		Me._linStatusBar_0.Visible = True
		Me._linStatusBar_0.Name = "_linStatusBar_0"
		Me._linStatusBar_1.BorderColor = System.Drawing.SystemColors.ControlLight
		Me._linStatusBar_1.X1 = 0
		Me._linStatusBar_1.X2 = 1244
		Me._linStatusBar_1.Y1 = 481
		Me._linStatusBar_1.Y2 = 481
		Me._linStatusBar_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linStatusBar_1.BorderWidth = 1
		Me._linStatusBar_1.Visible = True
		Me._linStatusBar_1.Name = "_linStatusBar_1"
		Me._linToolbarBottom_0.BorderColor = System.Drawing.SystemColors.ControlDark
		Me._linToolbarBottom_0.X1 = 0
		Me._linToolbarBottom_0.X2 = 1244
		Me._linToolbarBottom_0.Y1 = 30
		Me._linToolbarBottom_0.Y2 = 30
		Me._linToolbarBottom_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linToolbarBottom_0.BorderWidth = 1
		Me._linToolbarBottom_0.Visible = True
		Me._linToolbarBottom_0.Name = "_linToolbarBottom_0"
		Me._linHeader_0.BorderColor = System.Drawing.SystemColors.ControlDark
		Me._linHeader_0.X1 = 136
		Me._linHeader_0.X2 = 1248
		Me._linHeader_0.Y1 = 200
		Me._linHeader_0.Y2 = 200
		Me._linHeader_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linHeader_0.BorderWidth = 1
		Me._linHeader_0.Visible = True
		Me._linHeader_0.Name = "_linHeader_0"
		Me._linVertical_0.BorderColor = System.Drawing.SystemColors.ControlDark
		Me._linVertical_0.X1 = 136
		Me._linVertical_0.X2 = 136
		Me._linVertical_0.Y1 = 28
		Me._linVertical_0.Y2 = 490
		Me._linVertical_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linVertical_0.BorderWidth = 1
		Me._linVertical_0.Visible = True
		Me._linVertical_0.Name = "_linVertical_0"
		Me._linDirectInput_0.BorderColor = System.Drawing.SystemColors.ControlDark
		Me._linDirectInput_0.X1 = 136
		Me._linDirectInput_0.X2 = 0
		Me._linDirectInput_0.Y1 = 456
		Me._linDirectInput_0.Y2 = 456
		Me._linDirectInput_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linDirectInput_0.BorderWidth = 1
		Me._linDirectInput_0.Visible = True
		Me._linDirectInput_0.Name = "_linDirectInput_0"
		Me._linDirectInput_1.BorderColor = System.Drawing.SystemColors.ControlLight
		Me._linDirectInput_1.X1 = 136
		Me._linDirectInput_1.X2 = 0
		Me._linDirectInput_1.Y1 = 457
		Me._linDirectInput_1.Y2 = 457
		Me._linDirectInput_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linDirectInput_1.BorderWidth = 1
		Me._linDirectInput_1.Visible = True
		Me._linDirectInput_1.Name = "_linDirectInput_1"
		Me._linHeader_1.BorderColor = System.Drawing.SystemColors.ControlLight
		Me._linHeader_1.X1 = 136
		Me._linHeader_1.X2 = 1248
		Me._linHeader_1.Y1 = 201
		Me._linHeader_1.Y2 = 201
		Me._linHeader_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linHeader_1.BorderWidth = 1
		Me._linHeader_1.Visible = True
		Me._linHeader_1.Name = "_linHeader_1"
		Me._linVertical_1.BorderColor = System.Drawing.SystemColors.ControlLight
		Me._linVertical_1.X1 = 137
		Me._linVertical_1.X2 = 137
		Me._linVertical_1.Y1 = 28
		Me._linVertical_1.Y2 = 490
		Me._linVertical_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linVertical_1.BorderWidth = 1
		Me._linVertical_1.Visible = True
		Me._linVertical_1.Name = "_linVertical_1"
		Me._linToolbarBottom_1.BorderColor = System.Drawing.SystemColors.ControlLight
		Me._linToolbarBottom_1.X1 = 0
		Me._linToolbarBottom_1.X2 = 1244
		Me._linToolbarBottom_1.Y1 = 31
		Me._linToolbarBottom_1.Y2 = 31
		Me._linToolbarBottom_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me._linToolbarBottom_1.BorderWidth = 1
		Me._linToolbarBottom_1.Visible = True
		Me._linToolbarBottom_1.Name = "_linToolbarBottom_1"
		Me.lblDirectInput.Text = "Direct"
		Me.lblDirectInput.Size = New System.Drawing.Size(36, 12)
		Me.lblDirectInput.Location = New System.Drawing.Point(4, 482)
		Me.lblDirectInput.TabIndex = 95
		Me.lblDirectInput.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDirectInput.BackColor = System.Drawing.SystemColors.Control
		Me.lblDirectInput.Enabled = True
		Me.lblDirectInput.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDirectInput.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDirectInput.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDirectInput.UseMnemonic = True
		Me.lblDirectInput.Visible = True
		Me.lblDirectInput.AutoSize = True
		Me.lblDirectInput.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDirectInput.Name = "lblDirectInput"
		Me.Controls.Add(staMain)
		Me.Controls.Add(picSiromaru)
		Me.Controls.Add(fraResolution)
		Me.Controls.Add(fraDispSize)
		Me.Controls.Add(fraViewer)
		Me.Controls.Add(cboDirectInput)
		Me.Controls.Add(cmdDirectInput)
		Me.Controls.Add(fraGrid)
		Me.Controls.Add(fraHeader)
		Me.Controls.Add(fraMaterial)
		Me.Controls.Add(picMain)
		Me.Controls.Add(hsbMain)
		Me.Controls.Add(vsbMain)
		Me.Controls.Add(tlbMenu)
		Me.ShapeContainer1.Shapes.Add(_linStatusBar_0)
		Me.ShapeContainer1.Shapes.Add(_linStatusBar_1)
		Me.ShapeContainer1.Shapes.Add(_linToolbarBottom_0)
		Me.ShapeContainer1.Shapes.Add(_linHeader_0)
		Me.ShapeContainer1.Shapes.Add(_linVertical_0)
		Me.ShapeContainer1.Shapes.Add(_linDirectInput_0)
		Me.ShapeContainer1.Shapes.Add(_linDirectInput_1)
		Me.ShapeContainer1.Shapes.Add(_linHeader_1)
		Me.ShapeContainer1.Shapes.Add(_linVertical_1)
		Me.ShapeContainer1.Shapes.Add(_linToolbarBottom_1)
		Me.Controls.Add(lblDirectInput)
		Me.Controls.Add(ShapeContainer1)
		Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._staMain_Panel1})
		Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._staMain_Panel2})
		Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._staMain_Panel3})
		Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._staMain_Panel4})
		Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._staMain_Panel5})
		Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._staMain_Panel6})
		Me.fraResolution.Controls.Add(cboVScroll)
		Me.fraResolution.Controls.Add(lblVScroll)
		Me.fraDispSize.Controls.Add(cboDispHeight)
		Me.fraDispSize.Controls.Add(cboDispWidth)
		Me.fraDispSize.Controls.Add(lblDispWidth)
		Me.fraDispSize.Controls.Add(lblDispHeight)
		Me.fraViewer.Controls.Add(cboViewer)
		Me.fraGrid.Controls.Add(cboDispGridMain)
		Me.fraGrid.Controls.Add(cboDispGridSub)
		Me.fraGrid.Controls.Add(lblGridSub)
		Me.fraGrid.Controls.Add(lblGridMain)
		Me.fraHeader.Controls.Add(_fraTop_0)
		Me.fraHeader.Controls.Add(_fraTop_1)
		Me.fraHeader.Controls.Add(_fraTop_2)
		Me.fraHeader.Controls.Add(_optChangeTop_0)
		Me.fraHeader.Controls.Add(_optChangeTop_2)
		Me.fraHeader.Controls.Add(_optChangeTop_1)
		Me._fraTop_0.Controls.Add(cboPlayer)
		Me._fraTop_0.Controls.Add(txtGenre)
		Me._fraTop_0.Controls.Add(txtTitle)
		Me._fraTop_0.Controls.Add(txtArtist)
		Me._fraTop_0.Controls.Add(cboPlayLevel)
		Me._fraTop_0.Controls.Add(txtBPM)
		Me._fraTop_0.Controls.Add(lblPlayMode)
		Me._fraTop_0.Controls.Add(lblGenre)
		Me._fraTop_0.Controls.Add(lblTitle)
		Me._fraTop_0.Controls.Add(lblArtist)
		Me._fraTop_0.Controls.Add(lblPlayLevel)
		Me._fraTop_0.Controls.Add(lblBPM)
		Me._fraTop_1.Controls.Add(cboPlayRank)
		Me._fraTop_1.Controls.Add(txtTotal)
		Me._fraTop_1.Controls.Add(txtVolume)
		Me._fraTop_1.Controls.Add(txtStageFile)
		Me._fraTop_1.Controls.Add(cmdLoadStageFile)
		Me._fraTop_1.Controls.Add(cmdLoadMissBMP)
		Me._fraTop_1.Controls.Add(txtMissBMP)
		Me._fraTop_1.Controls.Add(lblPlayRank)
		Me._fraTop_1.Controls.Add(lblTotal)
		Me._fraTop_1.Controls.Add(lblVolume)
		Me._fraTop_1.Controls.Add(lblStageFile)
		Me._fraTop_1.Controls.Add(lblMissBMP)
		Me._fraTop_2.Controls.Add(cboDispFrame)
		Me._fraTop_2.Controls.Add(cboDispSC2P)
		Me._fraTop_2.Controls.Add(cboDispSC1P)
		Me._fraTop_2.Controls.Add(cboDispKey)
		Me._fraTop_2.Controls.Add(lblDispFrame)
		Me._fraTop_2.Controls.Add(lblDispSC2P)
		Me._fraTop_2.Controls.Add(lblDispSC1P)
		Me._fraTop_2.Controls.Add(lblDispKey)
		Me.fraMaterial.Controls.Add(_optChangeBottom_0)
		Me.fraMaterial.Controls.Add(_optChangeBottom_1)
		Me.fraMaterial.Controls.Add(_optChangeBottom_2)
		Me.fraMaterial.Controls.Add(_optChangeBottom_3)
		Me.fraMaterial.Controls.Add(_optChangeBottom_4)
		Me.fraMaterial.Controls.Add(_fraBottom_4)
		Me.fraMaterial.Controls.Add(_fraBottom_0)
		Me.fraMaterial.Controls.Add(_fraBottom_1)
		Me.fraMaterial.Controls.Add(_fraBottom_2)
		Me.fraMaterial.Controls.Add(_fraBottom_3)
		Me._fraBottom_4.Controls.Add(txtExInfo)
		Me._fraBottom_0.Controls.Add(cmdSoundExcUp)
		Me._fraBottom_0.Controls.Add(cmdSoundExcDown)
		Me._fraBottom_0.Controls.Add(cmdSoundDelete)
		Me._fraBottom_0.Controls.Add(cmdSoundLoad)
		Me._fraBottom_0.Controls.Add(cmdSoundStop)
		Me._fraBottom_0.Controls.Add(lstWAV)
		Me._fraBottom_1.Controls.Add(cmdBMPExcDown)
		Me._fraBottom_1.Controls.Add(cmdBMPExcUp)
		Me._fraBottom_1.Controls.Add(lstBMP)
		Me._fraBottom_1.Controls.Add(cmdBMPDelete)
		Me._fraBottom_1.Controls.Add(cmdBMPLoad)
		Me._fraBottom_1.Controls.Add(cmdBMPPreview)
		Me._fraBottom_2.Controls.Add(cmdBGAExcDown)
		Me._fraBottom_2.Controls.Add(cmdBGAExcUp)
		Me._fraBottom_2.Controls.Add(txtBGAInput)
		Me._fraBottom_2.Controls.Add(cmdBGAPreview)
		Me._fraBottom_2.Controls.Add(cmdBGASet)
		Me._fraBottom_2.Controls.Add(cmdBGADelete)
		Me._fraBottom_2.Controls.Add(lstBGA)
		Me._fraBottom_3.Controls.Add(cboNumerator)
		Me._fraBottom_3.Controls.Add(cboDenominator)
		Me._fraBottom_3.Controls.Add(cmdMeasureSelectAll)
		Me._fraBottom_3.Controls.Add(cmdInputMeasureLen)
		Me._fraBottom_3.Controls.Add(lstMeasureLen)
		Me._fraBottom_3.Controls.Add(lblFraction)
		Me.tlbMenu.Items.Add(_tlbMenu_Button1)
		Me.tlbMenu.Items.Add(_tlbMenu_Button2)
		Me.tlbMenu.Items.Add(_tlbMenu_Button3)
		Me.tlbMenu.Items.Add(_tlbMenu_Button4)
		Me.tlbMenu.Items.Add(_tlbMenu_Button5)
		Me.tlbMenu.Items.Add(_tlbMenu_Button6)
		Me.tlbMenu.Items.Add(_tlbMenu_Button7)
		Me.tlbMenu.Items.Add(_tlbMenu_Button8)
		Me.tlbMenu.Items.Add(_tlbMenu_Button9)
		Me.tlbMenu.Items.Add(_tlbMenu_Button10)
		Me.tlbMenu.Items.Add(_tlbMenu_Button11)
		Me.tlbMenu.Items.Add(_tlbMenu_Button12)
		Me.tlbMenu.Items.Add(_tlbMenu_Button13)
		Me.tlbMenu.Items.Add(_tlbMenu_Button14)
		Me.tlbMenu.Items.Add(_tlbMenu_Button15)
		Me.tlbMenu.Items.Add(_tlbMenu_Button16)
		Me.tlbMenu.Items.Add(_tlbMenu_Button17)
		Me.tlbMenu.Items.Add(_tlbMenu_Button18)
		Me.tlbMenu.Items.Add(_tlbMenu_Button19)
		Me.tlbMenu.Items.Add(_tlbMenu_Button20)
		Me.fraBottom.SetIndex(_fraBottom_4, CType(4, Short))
		Me.fraBottom.SetIndex(_fraBottom_0, CType(0, Short))
		Me.fraBottom.SetIndex(_fraBottom_1, CType(1, Short))
		Me.fraBottom.SetIndex(_fraBottom_2, CType(2, Short))
		Me.fraBottom.SetIndex(_fraBottom_3, CType(3, Short))
		Me.fraTop.SetIndex(_fraTop_0, CType(0, Short))
		Me.fraTop.SetIndex(_fraTop_1, CType(1, Short))
		Me.fraTop.SetIndex(_fraTop_2, CType(2, Short))
		Me.linDirectInput.SetIndex(_linDirectInput_0, CType(0, Short))
		Me.linDirectInput.SetIndex(_linDirectInput_1, CType(1, Short))
		Me.linHeader.SetIndex(_linHeader_0, CType(0, Short))
		Me.linHeader.SetIndex(_linHeader_1, CType(1, Short))
		Me.linStatusBar.SetIndex(_linStatusBar_0, CType(0, Short))
		Me.linStatusBar.SetIndex(_linStatusBar_1, CType(1, Short))
		Me.linToolbarBottom.SetIndex(_linToolbarBottom_0, CType(0, Short))
		Me.linToolbarBottom.SetIndex(_linToolbarBottom_1, CType(1, Short))
		Me.linVertical.SetIndex(_linVertical_0, CType(0, Short))
		Me.linVertical.SetIndex(_linVertical_1, CType(1, Short))
		Me.mnuEditMode.SetIndex(_mnuEditMode_0, CType(0, Short))
		Me.mnuEditMode.SetIndex(_mnuEditMode_1, CType(1, Short))
		Me.mnuEditMode.SetIndex(_mnuEditMode_2, CType(2, Short))
		Me.mnuLanguage.SetIndex(_mnuLanguage_0, CType(0, Short))
		Me.mnuOptionsItem.SetIndex(_mnuOptionsItem_0, CType(0, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_0, CType(0, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_1, CType(1, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_2, CType(2, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_3, CType(3, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_4, CType(4, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_5, CType(5, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_6, CType(6, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_7, CType(7, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_8, CType(8, Short))
		Me.mnuRecentFiles.SetIndex(_mnuRecentFiles_9, CType(9, Short))
		Me.mnuTheme.SetIndex(_mnuTheme_0, CType(0, Short))
		Me.mnuViewItem.SetIndex(_mnuViewItem_0, CType(0, Short))
		Me.optChangeBottom.SetIndex(_optChangeBottom_0, CType(0, Short))
		Me.optChangeBottom.SetIndex(_optChangeBottom_1, CType(1, Short))
		Me.optChangeBottom.SetIndex(_optChangeBottom_2, CType(2, Short))
		Me.optChangeBottom.SetIndex(_optChangeBottom_3, CType(3, Short))
		Me.optChangeBottom.SetIndex(_optChangeBottom_4, CType(4, Short))
		Me.optChangeTop.SetIndex(_optChangeTop_0, CType(0, Short))
		Me.optChangeTop.SetIndex(_optChangeTop_2, CType(2, Short))
		Me.optChangeTop.SetIndex(_optChangeTop_1, CType(1, Short))
		CType(Me.optChangeTop, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.optChangeBottom, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mnuViewItem, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mnuTheme, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mnuRecentFiles, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mnuOptionsItem, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mnuLanguage, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mnuEditMode, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.linVertical, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.linToolbarBottom, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.linStatusBar, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.linHeader, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.linDirectInput, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.fraTop, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.fraBottom, System.ComponentModel.ISupportInitialize).EndInit()
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.mnuOptions, Me.mnuTools, Me.mnuHelp, Me.mnuContext, Me.mnuContextList})
		mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuFileNew, Me.mnuFileOpen, Me.mnuFileSave, Me.mnuFileSaveAs, Me.mnuFileOpenDirectory, Me.mnuLineFile, Me._mnuRecentFiles_0, Me._mnuRecentFiles_1, Me._mnuRecentFiles_2, Me._mnuRecentFiles_3, Me._mnuRecentFiles_4, Me._mnuRecentFiles_5, Me._mnuRecentFiles_6, Me._mnuRecentFiles_7, Me._mnuRecentFiles_8, Me._mnuRecentFiles_9, Me.mnuLineRecent, Me.mnuFileConvertWizard, Me.mnuLineExit, Me.mnuFileExit})
		mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuEditUndo, Me.mnuEditRedo, Me.mnuLineEdit1, Me.mnuEditCut, Me.mnuEditCopy, Me.mnuEditPaste, Me.mnuEditDelete, Me.mnuLineEdit2, Me.mnuEditSelectAll, Me.mnuLineEdit3, Me.mnuEditFind, Me.mnuLineEdit4, Me._mnuEditMode_0, Me._mnuEditMode_1, Me._mnuEditMode_2})
		mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me._mnuViewItem_0})
		mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me._mnuOptionsItem_0, Me.mnuLineOptions, Me.mnuLanguageParent, Me.mnuThemeParent})
		mnuLanguageParent.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me._mnuLanguage_0})
		mnuThemeParent.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me._mnuTheme_0})
		mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuToolsPlayAll, Me.mnuToolsPlay, Me.mnuToolsPlayStop, Me.mnuLineTools, Me.mnuToolsSetting})
		mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuHelpOpen, Me.mnuLineHelp, Me.mnuHelpWeb, Me.mnuHelpAbout})
		mnuContext.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuContextPlayAll, Me.mnuContextPlay, Me.mnuContextBar1, Me.mnuContextInsertMeasure, Me.mnuContextDeleteMeasure, Me.mnuContextBar2, Me.mnuContextEditCut, Me.mnuContextEditCopy, Me.mnuContextEditPaste, Me.mnuContextEditDelete})
		mnuContextList.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuContextListLoad, Me.mnuContextListDelete, Me.mnuContextListRename})
		Me.Controls.Add(MainMenu1)
		Me.MainMenu1.ResumeLayout(False)
		Me.staMain.ResumeLayout(False)
		Me.fraResolution.ResumeLayout(False)
		Me.fraDispSize.ResumeLayout(False)
		Me.fraViewer.ResumeLayout(False)
		Me.fraGrid.ResumeLayout(False)
		Me.fraHeader.ResumeLayout(False)
		Me._fraTop_0.ResumeLayout(False)
		Me._fraTop_1.ResumeLayout(False)
		Me._fraTop_2.ResumeLayout(False)
		Me.fraMaterial.ResumeLayout(False)
		Me._fraBottom_4.ResumeLayout(False)
		Me._fraBottom_0.ResumeLayout(False)
		Me._fraBottom_1.ResumeLayout(False)
		Me._fraBottom_2.ResumeLayout(False)
		Me._fraBottom_3.ResumeLayout(False)
		Me.tlbMenu.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
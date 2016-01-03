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
    Public WithEvents _mnuViewItem_1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuViewItem_2 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuOptionsItem_0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuOptionsItem_1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuOptionsItem_2 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuOptionsItem_3 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuOptionsItem_4 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuOptionsItem_5 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuOptionsItem_6 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuOptionsItem_7 As System.Windows.Forms.ToolStripMenuItem
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
    Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me._linStatusBar_0 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linStatusBar_1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linToolbarBottom_0 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linHeader_0 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linVertical_0 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linDirectInput_0 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linDirectInput_1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linHeader_1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linVertical_1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me._linToolbarBottom_1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpenDirectory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineFile = New System.Windows.Forms.ToolStripSeparator()
        Me._mnuRecentFiles_0 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_3 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_4 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_5 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_6 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_7 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_8 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuRecentFiles_9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineRecent = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileConvertWizard = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineExit = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineEdit1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineEdit2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineEdit3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineEdit4 = New System.Windows.Forms.ToolStripSeparator()
        Me._mnuEditMode_0 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuEditMode_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuEditMode_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuViewItem_0 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuViewItem_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuViewItem_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuOptionsItem_0 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuOptionsItem_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuOptionsItem_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuOptionsItem_3 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuOptionsItem_4 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuOptionsItem_5 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuOptionsItem_6 = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuOptionsItem_7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineOptions = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLanguageParent = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuLanguage_0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuThemeParent = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuTheme_0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsPlayAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsPlayStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineTools = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuToolsSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLineHelp = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHelpWeb = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContext = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextPlayAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextInsertMeasure = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextDeleteMeasure = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextBar2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextEditCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextEditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextEditPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextEditDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextListLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextListDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextListRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.staMain = New System.Windows.Forms.StatusStrip()
        Me._staMain_Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._staMain_Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._staMain_Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._staMain_Panel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._staMain_Panel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._staMain_Panel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.picSiromaru = New System.Windows.Forms.PictureBox()
        Me.tmrEffect = New System.Windows.Forms.Timer(Me.components)
        Me.fraResolution = New System.Windows.Forms.GroupBox()
        Me.cboVScroll = New System.Windows.Forms.ComboBox()
        Me.lblVScroll = New System.Windows.Forms.Label()
        Me.fraDispSize = New System.Windows.Forms.GroupBox()
        Me.cboDispHeight = New System.Windows.Forms.ComboBox()
        Me.cboDispWidth = New System.Windows.Forms.ComboBox()
        Me.lblDispWidth = New System.Windows.Forms.Label()
        Me.lblDispHeight = New System.Windows.Forms.Label()
        Me.fraViewer = New System.Windows.Forms.GroupBox()
        Me.cboViewer = New System.Windows.Forms.ComboBox()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.ilsMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.cboDirectInput = New System.Windows.Forms.ComboBox()
        Me.cmdDirectInput = New System.Windows.Forms.Button()
        Me.fraGrid = New System.Windows.Forms.GroupBox()
        Me.cboDispGridMain = New System.Windows.Forms.ComboBox()
        Me.cboDispGridSub = New System.Windows.Forms.ComboBox()
        Me.lblGridSub = New System.Windows.Forms.Label()
        Me.lblGridMain = New System.Windows.Forms.Label()
        Me.fraHeader = New System.Windows.Forms.GroupBox()
        Me._fraTop_0 = New System.Windows.Forms.GroupBox()
        Me.cboPlayer = New System.Windows.Forms.ComboBox()
        Me.txtGenre = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtArtist = New System.Windows.Forms.TextBox()
        Me.cboPlayLevel = New System.Windows.Forms.ComboBox()
        Me.txtBPM = New System.Windows.Forms.TextBox()
        Me.lblPlayMode = New System.Windows.Forms.Label()
        Me.lblGenre = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblArtist = New System.Windows.Forms.Label()
        Me.lblPlayLevel = New System.Windows.Forms.Label()
        Me.lblBPM = New System.Windows.Forms.Label()
        Me._fraTop_1 = New System.Windows.Forms.GroupBox()
        Me.cboPlayRank = New System.Windows.Forms.ComboBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.txtStageFile = New System.Windows.Forms.TextBox()
        Me.cmdLoadStageFile = New System.Windows.Forms.Button()
        Me.cmdLoadMissBMP = New System.Windows.Forms.Button()
        Me.txtMissBMP = New System.Windows.Forms.TextBox()
        Me.lblPlayRank = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblVolume = New System.Windows.Forms.Label()
        Me.lblStageFile = New System.Windows.Forms.Label()
        Me.lblMissBMP = New System.Windows.Forms.Label()
        Me._fraTop_2 = New System.Windows.Forms.GroupBox()
        Me.cboDispFrame = New System.Windows.Forms.ComboBox()
        Me.cboDispSC2P = New System.Windows.Forms.ComboBox()
        Me.cboDispSC1P = New System.Windows.Forms.ComboBox()
        Me.cboDispKey = New System.Windows.Forms.ComboBox()
        Me.lblDispFrame = New System.Windows.Forms.Label()
        Me.lblDispSC2P = New System.Windows.Forms.Label()
        Me.lblDispSC1P = New System.Windows.Forms.Label()
        Me.lblDispKey = New System.Windows.Forms.Label()
        Me._optChangeTop_0 = New System.Windows.Forms.RadioButton()
        Me._optChangeTop_2 = New System.Windows.Forms.RadioButton()
        Me._optChangeTop_1 = New System.Windows.Forms.RadioButton()
        Me.fraMaterial = New System.Windows.Forms.GroupBox()
        Me._optChangeBottom_0 = New System.Windows.Forms.RadioButton()
        Me._optChangeBottom_1 = New System.Windows.Forms.RadioButton()
        Me._optChangeBottom_2 = New System.Windows.Forms.RadioButton()
        Me._optChangeBottom_3 = New System.Windows.Forms.RadioButton()
        Me._optChangeBottom_4 = New System.Windows.Forms.RadioButton()
        Me._fraBottom_4 = New System.Windows.Forms.GroupBox()
        Me.txtExInfo = New System.Windows.Forms.TextBox()
        Me._fraBottom_0 = New System.Windows.Forms.GroupBox()
        Me.cmdSoundExcUp = New System.Windows.Forms.Button()
        Me.cmdSoundExcDown = New System.Windows.Forms.Button()
        Me.cmdSoundDelete = New System.Windows.Forms.Button()
        Me.cmdSoundLoad = New System.Windows.Forms.Button()
        Me.cmdSoundStop = New System.Windows.Forms.Button()
        Me.lstWAV = New System.Windows.Forms.ListBox()
        Me._fraBottom_1 = New System.Windows.Forms.GroupBox()
        Me.cmdBMPExcDown = New System.Windows.Forms.Button()
        Me.cmdBMPExcUp = New System.Windows.Forms.Button()
        Me.lstBMP = New System.Windows.Forms.ListBox()
        Me.cmdBMPDelete = New System.Windows.Forms.Button()
        Me.cmdBMPLoad = New System.Windows.Forms.Button()
        Me.cmdBMPPreview = New System.Windows.Forms.Button()
        Me._fraBottom_2 = New System.Windows.Forms.GroupBox()
        Me.cmdBGAExcDown = New System.Windows.Forms.Button()
        Me.cmdBGAExcUp = New System.Windows.Forms.Button()
        Me.txtBGAInput = New System.Windows.Forms.TextBox()
        Me.cmdBGAPreview = New System.Windows.Forms.Button()
        Me.cmdBGASet = New System.Windows.Forms.Button()
        Me.cmdBGADelete = New System.Windows.Forms.Button()
        Me.lstBGA = New System.Windows.Forms.ListBox()
        Me._fraBottom_3 = New System.Windows.Forms.GroupBox()
        Me.cboNumerator = New System.Windows.Forms.ComboBox()
        Me.cboDenominator = New System.Windows.Forms.ComboBox()
        Me.cmdMeasureSelectAll = New System.Windows.Forms.Button()
        Me.cmdInputMeasureLen = New System.Windows.Forms.Button()
        Me.lstMeasureLen = New System.Windows.Forms.ListBox()
        Me.lblFraction = New System.Windows.Forms.Label()
        Me.picMain = New System.Windows.Forms.PictureBox()
        Me.hsbMain = New System.Windows.Forms.HScrollBar()
        Me.vsbMain = New System.Windows.Forms.VScrollBar()
        Me.dlgMainOpen = New System.Windows.Forms.OpenFileDialog()
        Me.dlgMainSave = New System.Windows.Forms.SaveFileDialog()
        Me.tlbMenu = New System.Windows.Forms.ToolStrip()
        Me._tlbMenu_Button1 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me._tlbMenu_Button3 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button4 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button5 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button6 = New System.Windows.Forms.ToolStripSeparator()
        Me._tlbMenu_Button7 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button8 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button9 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button10 = New System.Windows.Forms.ToolStripSeparator()
        Me._tlbMenu_Button11 = New System.Windows.Forms.ToolStripSeparator()
        Me._tlbMenu_Button12 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button13 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button14 = New System.Windows.Forms.ToolStripButton()
        Me._tlbMenu_Button15 = New System.Windows.Forms.ToolStripSeparator()
        Me._tlbMenu_Button16 = New System.Windows.Forms.ToolStripSeparator()
        Me._tlbMenu_Button17 = New System.Windows.Forms.ToolStripSeparator()
        Me._tlbMenu_Button18 = New System.Windows.Forms.ToolStripSeparator()
        Me._tlbMenu_Button19 = New System.Windows.Forms.ToolStripSeparator()
        Me._tlbMenu_Button20 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblDirectInput = New System.Windows.Forms.Label()
        Me.dlgMain = New System.Windows.Forms.OpenFileDialog()
        Me.MainMenu1.SuspendLayout()
        Me.staMain.SuspendLayout()
        CType(Me.picSiromaru, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me._linStatusBar_0, Me._linStatusBar_1, Me._linToolbarBottom_0, Me._linHeader_0, Me._linVertical_0, Me._linDirectInput_0, Me._linDirectInput_1, Me._linHeader_1, Me._linVertical_1, Me._linToolbarBottom_1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1192, 530)
        Me.ShapeContainer1.TabIndex = 100
        Me.ShapeContainer1.TabStop = False
        '
        '_linStatusBar_0
        '
        Me._linStatusBar_0.BorderColor = System.Drawing.SystemColors.ControlDark
        Me._linStatusBar_0.Name = "_linStatusBar_0"
        Me._linStatusBar_0.X1 = 0
        Me._linStatusBar_0.X2 = 1244
        Me._linStatusBar_0.Y1 = 480
        Me._linStatusBar_0.Y2 = 480
        '
        '_linStatusBar_1
        '
        Me._linStatusBar_1.BorderColor = System.Drawing.SystemColors.ControlLight
        Me._linStatusBar_1.Name = "_linStatusBar_1"
        Me._linStatusBar_1.X1 = 0
        Me._linStatusBar_1.X2 = 1244
        Me._linStatusBar_1.Y1 = 481
        Me._linStatusBar_1.Y2 = 481
        '
        '_linToolbarBottom_0
        '
        Me._linToolbarBottom_0.BorderColor = System.Drawing.SystemColors.ControlDark
        Me._linToolbarBottom_0.Name = "_linToolbarBottom_0"
        Me._linToolbarBottom_0.X1 = 0
        Me._linToolbarBottom_0.X2 = 1244
        Me._linToolbarBottom_0.Y1 = 30
        Me._linToolbarBottom_0.Y2 = 30
        '
        '_linHeader_0
        '
        Me._linHeader_0.BorderColor = System.Drawing.SystemColors.ControlDark
        Me._linHeader_0.Name = "_linHeader_0"
        Me._linHeader_0.X1 = 136
        Me._linHeader_0.X2 = 1248
        Me._linHeader_0.Y1 = 200
        Me._linHeader_0.Y2 = 200
        '
        '_linVertical_0
        '
        Me._linVertical_0.BorderColor = System.Drawing.SystemColors.ControlDark
        Me._linVertical_0.Name = "_linVertical_0"
        Me._linVertical_0.X1 = 136
        Me._linVertical_0.X2 = 136
        Me._linVertical_0.Y1 = 28
        Me._linVertical_0.Y2 = 490
        '
        '_linDirectInput_0
        '
        Me._linDirectInput_0.BorderColor = System.Drawing.SystemColors.ControlDark
        Me._linDirectInput_0.Name = "_linDirectInput_0"
        Me._linDirectInput_0.X1 = 136
        Me._linDirectInput_0.X2 = 0
        Me._linDirectInput_0.Y1 = 456
        Me._linDirectInput_0.Y2 = 456
        '
        '_linDirectInput_1
        '
        Me._linDirectInput_1.BorderColor = System.Drawing.SystemColors.ControlLight
        Me._linDirectInput_1.Name = "_linDirectInput_1"
        Me._linDirectInput_1.X1 = 136
        Me._linDirectInput_1.X2 = 0
        Me._linDirectInput_1.Y1 = 457
        Me._linDirectInput_1.Y2 = 457
        '
        '_linHeader_1
        '
        Me._linHeader_1.BorderColor = System.Drawing.SystemColors.ControlLight
        Me._linHeader_1.Name = "_linHeader_1"
        Me._linHeader_1.X1 = 136
        Me._linHeader_1.X2 = 1248
        Me._linHeader_1.Y1 = 201
        Me._linHeader_1.Y2 = 201
        '
        '_linVertical_1
        '
        Me._linVertical_1.BorderColor = System.Drawing.SystemColors.ControlLight
        Me._linVertical_1.Name = "_linVertical_1"
        Me._linVertical_1.X1 = 137
        Me._linVertical_1.X2 = 137
        Me._linVertical_1.Y1 = 28
        Me._linVertical_1.Y2 = 490
        '
        '_linToolbarBottom_1
        '
        Me._linToolbarBottom_1.BorderColor = System.Drawing.SystemColors.ControlLight
        Me._linToolbarBottom_1.Name = "_linToolbarBottom_1"
        Me._linToolbarBottom_1.X1 = 0
        Me._linToolbarBottom_1.X2 = 1244
        Me._linToolbarBottom_1.Y1 = 31
        Me._linToolbarBottom_1.Y2 = 31
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.mnuOptions, Me.mnuTools, Me.mnuHelp, Me.mnuContext, Me.mnuContextList})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(1192, 24)
        Me.MainMenu1.TabIndex = 101
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNew, Me.mnuFileOpen, Me.mnuFileSave, Me.mnuFileSaveAs, Me.mnuFileOpenDirectory, Me.mnuLineFile, Me._mnuRecentFiles_0, Me._mnuRecentFiles_1, Me._mnuRecentFiles_2, Me._mnuRecentFiles_3, Me._mnuRecentFiles_4, Me._mnuRecentFiles_5, Me._mnuRecentFiles_6, Me._mnuRecentFiles_7, Me._mnuRecentFiles_8, Me._mnuRecentFiles_9, Me.mnuLineRecent, Me.mnuFileConvertWizard, Me.mnuLineExit, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(61, 20)
        Me.mnuFile.Text = "mnuFile"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Name = "mnuFileNew"
        Me.mnuFileNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuFileNew.Size = New System.Drawing.Size(234, 22)
        Me.mnuFileNew.Text = "mnuFileNew"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Name = "mnuFileOpen"
        Me.mnuFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mnuFileOpen.Size = New System.Drawing.Size(234, 22)
        Me.mnuFileOpen.Text = "mnuFileOpen"
        '
        'mnuFileSave
        '
        Me.mnuFileSave.Name = "mnuFileSave"
        Me.mnuFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuFileSave.Size = New System.Drawing.Size(234, 22)
        Me.mnuFileSave.Text = "mnuFileSave"
        '
        'mnuFileSaveAs
        '
        Me.mnuFileSaveAs.Name = "mnuFileSaveAs"
        Me.mnuFileSaveAs.Size = New System.Drawing.Size(234, 22)
        Me.mnuFileSaveAs.Text = "mnuFileSaveAs"
        '
        'mnuFileOpenDirectory
        '
        Me.mnuFileOpenDirectory.Name = "mnuFileOpenDirectory"
        Me.mnuFileOpenDirectory.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.mnuFileOpenDirectory.Size = New System.Drawing.Size(234, 22)
        Me.mnuFileOpenDirectory.Text = "mnuFileOpenDirectory"
        '
        'mnuLineFile
        '
        Me.mnuLineFile.Name = "mnuLineFile"
        Me.mnuLineFile.Size = New System.Drawing.Size(231, 6)
        '
        '_mnuRecentFiles_0
        '
        Me._mnuRecentFiles_0.Name = "_mnuRecentFiles_0"
        Me._mnuRecentFiles_0.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_0.Text = "&1:"
        '
        '_mnuRecentFiles_1
        '
        Me._mnuRecentFiles_1.Name = "_mnuRecentFiles_1"
        Me._mnuRecentFiles_1.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_1.Text = "&2:"
        '
        '_mnuRecentFiles_2
        '
        Me._mnuRecentFiles_2.Name = "_mnuRecentFiles_2"
        Me._mnuRecentFiles_2.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_2.Text = "&3:"
        '
        '_mnuRecentFiles_3
        '
        Me._mnuRecentFiles_3.Name = "_mnuRecentFiles_3"
        Me._mnuRecentFiles_3.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_3.Text = "&4:"
        '
        '_mnuRecentFiles_4
        '
        Me._mnuRecentFiles_4.Name = "_mnuRecentFiles_4"
        Me._mnuRecentFiles_4.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_4.Text = "&5:"
        '
        '_mnuRecentFiles_5
        '
        Me._mnuRecentFiles_5.Name = "_mnuRecentFiles_5"
        Me._mnuRecentFiles_5.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_5.Text = "&6:"
        Me._mnuRecentFiles_5.Visible = False
        '
        '_mnuRecentFiles_6
        '
        Me._mnuRecentFiles_6.Name = "_mnuRecentFiles_6"
        Me._mnuRecentFiles_6.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_6.Text = "&7:"
        Me._mnuRecentFiles_6.Visible = False
        '
        '_mnuRecentFiles_7
        '
        Me._mnuRecentFiles_7.Name = "_mnuRecentFiles_7"
        Me._mnuRecentFiles_7.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_7.Text = "&8:"
        Me._mnuRecentFiles_7.Visible = False
        '
        '_mnuRecentFiles_8
        '
        Me._mnuRecentFiles_8.Name = "_mnuRecentFiles_8"
        Me._mnuRecentFiles_8.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_8.Text = "&9:"
        Me._mnuRecentFiles_8.Visible = False
        '
        '_mnuRecentFiles_9
        '
        Me._mnuRecentFiles_9.Name = "_mnuRecentFiles_9"
        Me._mnuRecentFiles_9.Size = New System.Drawing.Size(234, 22)
        Me._mnuRecentFiles_9.Text = "&0:"
        Me._mnuRecentFiles_9.Visible = False
        '
        'mnuLineRecent
        '
        Me.mnuLineRecent.Name = "mnuLineRecent"
        Me.mnuLineRecent.Size = New System.Drawing.Size(231, 6)
        '
        'mnuFileConvertWizard
        '
        Me.mnuFileConvertWizard.Name = "mnuFileConvertWizard"
        Me.mnuFileConvertWizard.Size = New System.Drawing.Size(234, 22)
        Me.mnuFileConvertWizard.Text = "mnuFileConvertWizard"
        '
        'mnuLineExit
        '
        Me.mnuLineExit.Name = "mnuLineExit"
        Me.mnuLineExit.Size = New System.Drawing.Size(231, 6)
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(234, 22)
        Me.mnuFileExit.Text = "mnuFileExit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditUndo, Me.mnuEditRedo, Me.mnuLineEdit1, Me.mnuEditCut, Me.mnuEditCopy, Me.mnuEditPaste, Me.mnuEditDelete, Me.mnuLineEdit2, Me.mnuEditSelectAll, Me.mnuLineEdit3, Me.mnuEditFind, Me.mnuLineEdit4, Me._mnuEditMode_0, Me._mnuEditMode_1, Me._mnuEditMode_2})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(63, 20)
        Me.mnuEdit.Text = "mnuEdit"
        '
        'mnuEditUndo
        '
        Me.mnuEditUndo.Name = "mnuEditUndo"
        Me.mnuEditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.mnuEditUndo.Size = New System.Drawing.Size(204, 22)
        Me.mnuEditUndo.Text = "mnuEditUndo"
        '
        'mnuEditRedo
        '
        Me.mnuEditRedo.Name = "mnuEditRedo"
        Me.mnuEditRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.mnuEditRedo.Size = New System.Drawing.Size(204, 22)
        Me.mnuEditRedo.Text = "mnuEditRedo"
        '
        'mnuLineEdit1
        '
        Me.mnuLineEdit1.Name = "mnuLineEdit1"
        Me.mnuLineEdit1.Size = New System.Drawing.Size(201, 6)
        '
        'mnuEditCut
        '
        Me.mnuEditCut.Name = "mnuEditCut"
        Me.mnuEditCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnuEditCut.Size = New System.Drawing.Size(204, 22)
        Me.mnuEditCut.Text = "mnuEditCut"
        '
        'mnuEditCopy
        '
        Me.mnuEditCopy.Name = "mnuEditCopy"
        Me.mnuEditCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuEditCopy.Size = New System.Drawing.Size(204, 22)
        Me.mnuEditCopy.Text = "mnuEditCopy"
        '
        'mnuEditPaste
        '
        Me.mnuEditPaste.Name = "mnuEditPaste"
        Me.mnuEditPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mnuEditPaste.Size = New System.Drawing.Size(204, 22)
        Me.mnuEditPaste.Text = "mnuEditPaste"
        '
        'mnuEditDelete
        '
        Me.mnuEditDelete.Name = "mnuEditDelete"
        Me.mnuEditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.mnuEditDelete.Size = New System.Drawing.Size(204, 22)
        Me.mnuEditDelete.Text = "mnuEditDelete"
        '
        'mnuLineEdit2
        '
        Me.mnuLineEdit2.Name = "mnuLineEdit2"
        Me.mnuLineEdit2.Size = New System.Drawing.Size(201, 6)
        '
        'mnuEditSelectAll
        '
        Me.mnuEditSelectAll.Name = "mnuEditSelectAll"
        Me.mnuEditSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.mnuEditSelectAll.Size = New System.Drawing.Size(204, 22)
        Me.mnuEditSelectAll.Text = "mnuEditSelectAll"
        '
        'mnuLineEdit3
        '
        Me.mnuLineEdit3.Name = "mnuLineEdit3"
        Me.mnuLineEdit3.Size = New System.Drawing.Size(201, 6)
        '
        'mnuEditFind
        '
        Me.mnuEditFind.Name = "mnuEditFind"
        Me.mnuEditFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuEditFind.Size = New System.Drawing.Size(204, 22)
        Me.mnuEditFind.Text = "mnuEditFind"
        '
        'mnuLineEdit4
        '
        Me.mnuLineEdit4.Name = "mnuLineEdit4"
        Me.mnuLineEdit4.Size = New System.Drawing.Size(201, 6)
        '
        '_mnuEditMode_0
        '
        Me._mnuEditMode_0.Name = "_mnuEditMode_0"
        Me._mnuEditMode_0.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me._mnuEditMode_0.Size = New System.Drawing.Size(204, 22)
        Me._mnuEditMode_0.Text = "mnuEditMode(0)"
        '
        '_mnuEditMode_1
        '
        Me._mnuEditMode_1.Name = "_mnuEditMode_1"
        Me._mnuEditMode_1.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me._mnuEditMode_1.Size = New System.Drawing.Size(204, 22)
        Me._mnuEditMode_1.Text = "mnuEditMode(1)"
        '
        '_mnuEditMode_2
        '
        Me._mnuEditMode_2.Name = "_mnuEditMode_2"
        Me._mnuEditMode_2.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me._mnuEditMode_2.Size = New System.Drawing.Size(204, 22)
        Me._mnuEditMode_2.Text = "mnuEditMode(2)"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuViewItem_0, Me._mnuViewItem_1, Me._mnuViewItem_2})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(68, 20)
        Me.mnuView.Text = "mnuView"
        '
        '_mnuViewItem_0
        '
        Me._mnuViewItem_0.Name = "_mnuViewItem_0"
        Me._mnuViewItem_0.Size = New System.Drawing.Size(160, 22)
        Me._mnuViewItem_0.Text = "mnuViewItem(0)"
        '
        '_mnuViewItem_1
        '
        Me._mnuViewItem_1.Name = "_mnuViewItem_1"
        Me._mnuViewItem_1.Size = New System.Drawing.Size(160, 22)
        Me._mnuViewItem_1.Text = "mnuViewItem(1)"
        '
        '_mnuViewItem_2
        '
        Me._mnuViewItem_2.Name = "_mnuViewItem_2"
        Me._mnuViewItem_2.Size = New System.Drawing.Size(160, 22)
        Me._mnuViewItem_2.Text = "mnuViewItem(2)"
        '
        'mnuOptions
        '
        Me.mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuOptionsItem_0, Me._mnuOptionsItem_1, Me._mnuOptionsItem_2, Me._mnuOptionsItem_3, Me._mnuOptionsItem_4, Me._mnuOptionsItem_5, Me._mnuOptionsItem_6, Me._mnuOptionsItem_7, Me.mnuLineOptions, Me.mnuLanguageParent, Me.mnuThemeParent})
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(85, 20)
        Me.mnuOptions.Text = "mnuOptions"
        '
        '_mnuOptionsItem_0
        '
        Me._mnuOptionsItem_0.Checked = True
        Me._mnuOptionsItem_0.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuOptionsItem_0.Name = "_mnuOptionsItem_0"
        Me._mnuOptionsItem_0.Size = New System.Drawing.Size(177, 22)
        Me._mnuOptionsItem_0.Text = "mnuOptionsItem(0)"
        '
        '_mnuOptionsItem_1
        '
        Me._mnuOptionsItem_1.Checked = True
        Me._mnuOptionsItem_1.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuOptionsItem_1.Name = "_mnuOptionsItem_1"
        Me._mnuOptionsItem_1.Size = New System.Drawing.Size(177, 22)
        Me._mnuOptionsItem_1.Text = "mnuOptionsItem(1)"
        '
        '_mnuOptionsItem_2
        '
        Me._mnuOptionsItem_2.Checked = True
        Me._mnuOptionsItem_2.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuOptionsItem_2.Name = "_mnuOptionsItem_2"
        Me._mnuOptionsItem_2.Size = New System.Drawing.Size(177, 22)
        Me._mnuOptionsItem_2.Text = "mnuOptionsItem(2)"
        '
        '_mnuOptionsItem_3
        '
        Me._mnuOptionsItem_3.Checked = True
        Me._mnuOptionsItem_3.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuOptionsItem_3.Name = "_mnuOptionsItem_3"
        Me._mnuOptionsItem_3.Size = New System.Drawing.Size(177, 22)
        Me._mnuOptionsItem_3.Text = "mnuOptionsItem(3)"
        '
        '_mnuOptionsItem_4
        '
        Me._mnuOptionsItem_4.Checked = True
        Me._mnuOptionsItem_4.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuOptionsItem_4.Name = "_mnuOptionsItem_4"
        Me._mnuOptionsItem_4.Size = New System.Drawing.Size(177, 22)
        Me._mnuOptionsItem_4.Text = "mnuOptionsItem(4)"
        '
        '_mnuOptionsItem_5
        '
        Me._mnuOptionsItem_5.Checked = True
        Me._mnuOptionsItem_5.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuOptionsItem_5.Name = "_mnuOptionsItem_5"
        Me._mnuOptionsItem_5.Size = New System.Drawing.Size(177, 22)
        Me._mnuOptionsItem_5.Text = "mnuOptionsItem(5)"
        '
        '_mnuOptionsItem_6
        '
        Me._mnuOptionsItem_6.Checked = True
        Me._mnuOptionsItem_6.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuOptionsItem_6.Name = "_mnuOptionsItem_6"
        Me._mnuOptionsItem_6.Size = New System.Drawing.Size(177, 22)
        Me._mnuOptionsItem_6.Text = "mnuOptionsItem(6)"
        '
        '_mnuOptionsItem_7
        '
        Me._mnuOptionsItem_7.Checked = True
        Me._mnuOptionsItem_7.CheckState = System.Windows.Forms.CheckState.Checked
        Me._mnuOptionsItem_7.Name = "_mnuOptionsItem_7"
        Me._mnuOptionsItem_7.Size = New System.Drawing.Size(177, 22)
        Me._mnuOptionsItem_7.Text = "mnuOptionsItem(7)"
        '
        'mnuLineOptions
        '
        Me.mnuLineOptions.Name = "mnuLineOptions"
        Me.mnuLineOptions.Size = New System.Drawing.Size(174, 6)
        '
        'mnuLanguageParent
        '
        Me.mnuLanguageParent.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuLanguage_0})
        Me.mnuLanguageParent.Name = "mnuLanguageParent"
        Me.mnuLanguageParent.Size = New System.Drawing.Size(177, 22)
        Me.mnuLanguageParent.Text = "Select &Language"
        '
        '_mnuLanguage_0
        '
        Me._mnuLanguage_0.Name = "_mnuLanguage_0"
        Me._mnuLanguage_0.Size = New System.Drawing.Size(164, 22)
        Me._mnuLanguage_0.Text = "mnuLanguage(0)"
        '
        'mnuThemeParent
        '
        Me.mnuThemeParent.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuTheme_0})
        Me.mnuThemeParent.Name = "mnuThemeParent"
        Me.mnuThemeParent.Size = New System.Drawing.Size(177, 22)
        Me.mnuThemeParent.Text = "Select &Theme"
        '
        '_mnuTheme_0
        '
        Me._mnuTheme_0.Name = "_mnuTheme_0"
        Me._mnuTheme_0.Size = New System.Drawing.Size(147, 22)
        Me._mnuTheme_0.Text = "mnuTheme(0)"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsPlayAll, Me.mnuToolsPlay, Me.mnuToolsPlayStop, Me.mnuLineTools, Me.mnuToolsSetting})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(70, 20)
        Me.mnuTools.Text = "mnuTools"
        '
        'mnuToolsPlayAll
        '
        Me.mnuToolsPlayAll.Name = "mnuToolsPlayAll"
        Me.mnuToolsPlayAll.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.mnuToolsPlayAll.Size = New System.Drawing.Size(190, 22)
        Me.mnuToolsPlayAll.Text = "mnuToolsPlayAll"
        '
        'mnuToolsPlay
        '
        Me.mnuToolsPlay.Name = "mnuToolsPlay"
        Me.mnuToolsPlay.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.mnuToolsPlay.Size = New System.Drawing.Size(190, 22)
        Me.mnuToolsPlay.Text = "mnuToolsPlay"
        '
        'mnuToolsPlayStop
        '
        Me.mnuToolsPlayStop.Name = "mnuToolsPlayStop"
        Me.mnuToolsPlayStop.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.mnuToolsPlayStop.Size = New System.Drawing.Size(190, 22)
        Me.mnuToolsPlayStop.Text = "mnuToolsPlayStop"
        '
        'mnuLineTools
        '
        Me.mnuLineTools.Name = "mnuLineTools"
        Me.mnuLineTools.Size = New System.Drawing.Size(187, 6)
        '
        'mnuToolsSetting
        '
        Me.mnuToolsSetting.Name = "mnuToolsSetting"
        Me.mnuToolsSetting.Size = New System.Drawing.Size(190, 22)
        Me.mnuToolsSetting.Text = "mnuToolsSetting"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpOpen, Me.mnuLineHelp, Me.mnuHelpWeb, Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(68, 20)
        Me.mnuHelp.Text = "mnuHelp"
        '
        'mnuHelpOpen
        '
        Me.mnuHelpOpen.Name = "mnuHelpOpen"
        Me.mnuHelpOpen.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnuHelpOpen.Size = New System.Drawing.Size(171, 22)
        Me.mnuHelpOpen.Text = "mnuHelpOpen"
        '
        'mnuLineHelp
        '
        Me.mnuLineHelp.Name = "mnuLineHelp"
        Me.mnuLineHelp.Size = New System.Drawing.Size(168, 6)
        '
        'mnuHelpWeb
        '
        Me.mnuHelpWeb.Name = "mnuHelpWeb"
        Me.mnuHelpWeb.Size = New System.Drawing.Size(171, 22)
        Me.mnuHelpWeb.Text = "mnuHelpWeb"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(171, 22)
        Me.mnuHelpAbout.Text = "mnuHelpAbout"
        '
        'mnuContext
        '
        Me.mnuContext.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextPlayAll, Me.mnuContextPlay, Me.mnuContextBar1, Me.mnuContextInsertMeasure, Me.mnuContextDeleteMeasure, Me.mnuContextBar2, Me.mnuContextEditCut, Me.mnuContextEditCopy, Me.mnuContextEditPaste, Me.mnuContextEditDelete})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(84, 20)
        Me.mnuContext.Text = "mnuContext"
        '
        'mnuContextPlayAll
        '
        Me.mnuContextPlayAll.Name = "mnuContextPlayAll"
        Me.mnuContextPlayAll.Size = New System.Drawing.Size(217, 22)
        Me.mnuContextPlayAll.Text = "mnuContextPlayAll"
        '
        'mnuContextPlay
        '
        Me.mnuContextPlay.Name = "mnuContextPlay"
        Me.mnuContextPlay.Size = New System.Drawing.Size(217, 22)
        Me.mnuContextPlay.Text = "mnuContextPlay"
        '
        'mnuContextBar1
        '
        Me.mnuContextBar1.Name = "mnuContextBar1"
        Me.mnuContextBar1.Size = New System.Drawing.Size(214, 6)
        '
        'mnuContextInsertMeasure
        '
        Me.mnuContextInsertMeasure.Name = "mnuContextInsertMeasure"
        Me.mnuContextInsertMeasure.Size = New System.Drawing.Size(217, 22)
        Me.mnuContextInsertMeasure.Text = "mnuContextInsertMeasure"
        '
        'mnuContextDeleteMeasure
        '
        Me.mnuContextDeleteMeasure.Name = "mnuContextDeleteMeasure"
        Me.mnuContextDeleteMeasure.Size = New System.Drawing.Size(217, 22)
        Me.mnuContextDeleteMeasure.Text = "mnuContextDeleteMeasure"
        '
        'mnuContextBar2
        '
        Me.mnuContextBar2.Name = "mnuContextBar2"
        Me.mnuContextBar2.Size = New System.Drawing.Size(214, 6)
        '
        'mnuContextEditCut
        '
        Me.mnuContextEditCut.Name = "mnuContextEditCut"
        Me.mnuContextEditCut.Size = New System.Drawing.Size(217, 22)
        Me.mnuContextEditCut.Text = "mnuContextEditCut"
        '
        'mnuContextEditCopy
        '
        Me.mnuContextEditCopy.Name = "mnuContextEditCopy"
        Me.mnuContextEditCopy.Size = New System.Drawing.Size(217, 22)
        Me.mnuContextEditCopy.Text = "mnuContextEditCopy"
        '
        'mnuContextEditPaste
        '
        Me.mnuContextEditPaste.Name = "mnuContextEditPaste"
        Me.mnuContextEditPaste.Size = New System.Drawing.Size(217, 22)
        Me.mnuContextEditPaste.Text = "mnuContextEditPaste"
        '
        'mnuContextEditDelete
        '
        Me.mnuContextEditDelete.Name = "mnuContextEditDelete"
        Me.mnuContextEditDelete.Size = New System.Drawing.Size(217, 22)
        Me.mnuContextEditDelete.Text = "mnuContextEditDelete"
        '
        'mnuContextList
        '
        Me.mnuContextList.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextListLoad, Me.mnuContextListDelete, Me.mnuContextListRename})
        Me.mnuContextList.Name = "mnuContextList"
        Me.mnuContextList.Size = New System.Drawing.Size(102, 20)
        Me.mnuContextList.Text = "mnuContextList"
        '
        'mnuContextListLoad
        '
        Me.mnuContextListLoad.Name = "mnuContextListLoad"
        Me.mnuContextListLoad.Size = New System.Drawing.Size(199, 22)
        Me.mnuContextListLoad.Text = "mnuContextListLoad"
        '
        'mnuContextListDelete
        '
        Me.mnuContextListDelete.Name = "mnuContextListDelete"
        Me.mnuContextListDelete.Size = New System.Drawing.Size(199, 22)
        Me.mnuContextListDelete.Text = "mnuContextListDelete"
        '
        'mnuContextListRename
        '
        Me.mnuContextListRename.Name = "mnuContextListRename"
        Me.mnuContextListRename.Size = New System.Drawing.Size(199, 22)
        Me.mnuContextListRename.Text = "mnuContextListRename"
        '
        'staMain
        '
        Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._staMain_Panel1, Me._staMain_Panel2, Me._staMain_Panel3, Me._staMain_Panel4, Me._staMain_Panel5, Me._staMain_Panel6})
        Me.staMain.Location = New System.Drawing.Point(0, 508)
        Me.staMain.Name = "staMain"
        Me.staMain.Size = New System.Drawing.Size(1192, 22)
        Me.staMain.TabIndex = 98
        '
        '_staMain_Panel1
        '
        Me._staMain_Panel1.AutoSize = False
        Me._staMain_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel1.Name = "_staMain_Panel1"
        Me._staMain_Panel1.Size = New System.Drawing.Size(81, 22)
        Me._staMain_Panel1.Text = "Edit Mode"
        '
        '_staMain_Panel2
        '
        Me._staMain_Panel2.AutoSize = False
        Me._staMain_Panel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel2.Name = "_staMain_Panel2"
        Me._staMain_Panel2.Size = New System.Drawing.Size(906, 22)
        Me._staMain_Panel2.Spring = True
        Me._staMain_Panel2.Text = "Position:"
        Me._staMain_Panel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_staMain_Panel3
        '
        Me._staMain_Panel3.AutoSize = False
        Me._staMain_Panel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel3.Name = "_staMain_Panel3"
        Me._staMain_Panel3.Size = New System.Drawing.Size(68, 22)
        Me._staMain_Panel3.Text = "#WAV 01"
        '
        '_staMain_Panel4
        '
        Me._staMain_Panel4.AutoSize = False
        Me._staMain_Panel4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel4.Name = "_staMain_Panel4"
        Me._staMain_Panel4.Size = New System.Drawing.Size(68, 22)
        Me._staMain_Panel4.Text = "#BMP 01"
        '
        '_staMain_Panel5
        '
        Me._staMain_Panel5.AutoSize = False
        Me._staMain_Panel5.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel5.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel5.Name = "_staMain_Panel5"
        Me._staMain_Panel5.Size = New System.Drawing.Size(54, 22)
        Me._staMain_Panel5.Text = "4/4"
        '
        '_staMain_Panel6
        '
        Me._staMain_Panel6.AutoSize = False
        Me._staMain_Panel6.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._staMain_Panel6.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._staMain_Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me._staMain_Panel6.Name = "_staMain_Panel6"
        Me._staMain_Panel6.Size = New System.Drawing.Size(54, 21)
        Me._staMain_Panel6.Text = "0ms"
        Me._staMain_Panel6.Visible = False
        '
        'picSiromaru
        '
        Me.picSiromaru.BackColor = System.Drawing.Color.Black
        Me.picSiromaru.Cursor = System.Windows.Forms.Cursors.Default
        Me.picSiromaru.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picSiromaru.Image = CType(resources.GetObject("picSiromaru.Image"), System.Drawing.Image)
        Me.picSiromaru.Location = New System.Drawing.Point(1184, 56)
        Me.picSiromaru.Name = "picSiromaru"
        Me.picSiromaru.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picSiromaru.Size = New System.Drawing.Size(64, 256)
        Me.picSiromaru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picSiromaru.TabIndex = 99
        Me.picSiromaru.TabStop = False
        Me.picSiromaru.Visible = False
        '
        'tmrEffect
        '
        Me.tmrEffect.Interval = 10
        '
        'fraResolution
        '
        Me.fraResolution.BackColor = System.Drawing.SystemColors.Control
        Me.fraResolution.Controls.Add(Me.cboVScroll)
        Me.fraResolution.Controls.Add(Me.lblVScroll)
        Me.fraResolution.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraResolution.Location = New System.Drawing.Point(1008, 200)
        Me.fraResolution.Name = "fraResolution"
        Me.fraResolution.Padding = New System.Windows.Forms.Padding(0)
        Me.fraResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraResolution.Size = New System.Drawing.Size(117, 21)
        Me.fraResolution.TabIndex = 16
        Me.fraResolution.TabStop = False
        '
        'cboVScroll
        '
        Me.cboVScroll.BackColor = System.Drawing.SystemColors.Window
        Me.cboVScroll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboVScroll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVScroll.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboVScroll.Items.AddRange(New Object() {"1"})
        Me.cboVScroll.Location = New System.Drawing.Point(48, 0)
        Me.cboVScroll.Name = "cboVScroll"
        Me.cboVScroll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboVScroll.Size = New System.Drawing.Size(57, 20)
        Me.cboVScroll.TabIndex = 18
        '
        'lblVScroll
        '
        Me.lblVScroll.AutoSize = True
        Me.lblVScroll.BackColor = System.Drawing.SystemColors.Control
        Me.lblVScroll.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVScroll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVScroll.Location = New System.Drawing.Point(0, 4)
        Me.lblVScroll.Name = "lblVScroll"
        Me.lblVScroll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVScroll.Size = New System.Drawing.Size(47, 12)
        Me.lblVScroll.TabIndex = 17
        Me.lblVScroll.Text = "VScroll"
        '
        'fraDispSize
        '
        Me.fraDispSize.BackColor = System.Drawing.SystemColors.Control
        Me.fraDispSize.Controls.Add(Me.cboDispHeight)
        Me.fraDispSize.Controls.Add(Me.cboDispWidth)
        Me.fraDispSize.Controls.Add(Me.lblDispWidth)
        Me.fraDispSize.Controls.Add(Me.lblDispHeight)
        Me.fraDispSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDispSize.Location = New System.Drawing.Point(808, 200)
        Me.fraDispSize.Name = "fraDispSize"
        Me.fraDispSize.Padding = New System.Windows.Forms.Padding(0)
        Me.fraDispSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraDispSize.Size = New System.Drawing.Size(197, 21)
        Me.fraDispSize.TabIndex = 11
        Me.fraDispSize.TabStop = False
        '
        'cboDispHeight
        '
        Me.cboDispHeight.BackColor = System.Drawing.SystemColors.Window
        Me.cboDispHeight.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDispHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispHeight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDispHeight.Items.AddRange(New Object() {"x0.5", "x1.0", "x1.5", "x2.0", "x2.5", "x3.0", "x3.5", "x4.0", "..."})
        Me.cboDispHeight.Location = New System.Drawing.Point(32, 0)
        Me.cboDispHeight.Name = "cboDispHeight"
        Me.cboDispHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDispHeight.Size = New System.Drawing.Size(57, 20)
        Me.cboDispHeight.TabIndex = 13
        '
        'cboDispWidth
        '
        Me.cboDispWidth.BackColor = System.Drawing.SystemColors.Window
        Me.cboDispWidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDispWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDispWidth.Items.AddRange(New Object() {"x0.5", "x1.0", "x1.5", "x2.0", "x2.5", "x3.0", "x3.5", "x4.0", "..."})
        Me.cboDispWidth.Location = New System.Drawing.Point(116, 0)
        Me.cboDispWidth.Name = "cboDispWidth"
        Me.cboDispWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDispWidth.Size = New System.Drawing.Size(57, 20)
        Me.cboDispWidth.TabIndex = 15
        '
        'lblDispWidth
        '
        Me.lblDispWidth.AutoSize = True
        Me.lblDispWidth.BackColor = System.Drawing.SystemColors.Control
        Me.lblDispWidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDispWidth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDispWidth.Location = New System.Drawing.Point(96, 4)
        Me.lblDispWidth.Name = "lblDispWidth"
        Me.lblDispWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDispWidth.Size = New System.Drawing.Size(17, 12)
        Me.lblDispWidth.TabIndex = 14
        Me.lblDispWidth.Text = "幅"
        '
        'lblDispHeight
        '
        Me.lblDispHeight.AutoSize = True
        Me.lblDispHeight.BackColor = System.Drawing.SystemColors.Control
        Me.lblDispHeight.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDispHeight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDispHeight.Location = New System.Drawing.Point(0, 4)
        Me.lblDispHeight.Name = "lblDispHeight"
        Me.lblDispHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDispHeight.Size = New System.Drawing.Size(29, 12)
        Me.lblDispHeight.TabIndex = 12
        Me.lblDispHeight.Text = "高さ"
        '
        'fraViewer
        '
        Me.fraViewer.BackColor = System.Drawing.SystemColors.Control
        Me.fraViewer.Controls.Add(Me.cboViewer)
        Me.fraViewer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraViewer.Location = New System.Drawing.Point(808, 136)
        Me.fraViewer.Name = "fraViewer"
        Me.fraViewer.Padding = New System.Windows.Forms.Padding(0)
        Me.fraViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraViewer.Size = New System.Drawing.Size(97, 21)
        Me.fraViewer.TabIndex = 4
        Me.fraViewer.TabStop = False
        '
        'cboViewer
        '
        Me.cboViewer.BackColor = System.Drawing.SystemColors.Window
        Me.cboViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboViewer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboViewer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboViewer.Location = New System.Drawing.Point(0, 0)
        Me.cboViewer.Name = "cboViewer"
        Me.cboViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboViewer.Size = New System.Drawing.Size(89, 20)
        Me.cboViewer.TabIndex = 5
        '
        'tmrMain
        '
        '
        'ilsMenu
        '
        Me.ilsMenu.ImageStream = CType(resources.GetObject("ilsMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsMenu.TransparentColor = System.Drawing.Color.White
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
        '
        'cboDirectInput
        '
        Me.cboDirectInput.BackColor = System.Drawing.SystemColors.Window
        Me.cboDirectInput.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDirectInput.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDirectInput.Location = New System.Drawing.Point(40, 480)
        Me.cboDirectInput.Name = "cboDirectInput"
        Me.cboDirectInput.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDirectInput.Size = New System.Drawing.Size(29, 20)
        Me.cboDirectInput.TabIndex = 96
        '
        'cmdDirectInput
        '
        Me.cmdDirectInput.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDirectInput.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDirectInput.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDirectInput.Location = New System.Drawing.Point(72, 480)
        Me.cmdDirectInput.Name = "cmdDirectInput"
        Me.cmdDirectInput.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDirectInput.Size = New System.Drawing.Size(61, 21)
        Me.cmdDirectInput.TabIndex = 97
        Me.cmdDirectInput.Text = "Input"
        Me.cmdDirectInput.UseVisualStyleBackColor = False
        '
        'fraGrid
        '
        Me.fraGrid.BackColor = System.Drawing.SystemColors.Control
        Me.fraGrid.Controls.Add(Me.cboDispGridMain)
        Me.fraGrid.Controls.Add(Me.cboDispGridSub)
        Me.fraGrid.Controls.Add(Me.lblGridSub)
        Me.fraGrid.Controls.Add(Me.lblGridMain)
        Me.fraGrid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraGrid.Location = New System.Drawing.Point(808, 168)
        Me.fraGrid.Name = "fraGrid"
        Me.fraGrid.Padding = New System.Windows.Forms.Padding(0)
        Me.fraGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraGrid.Size = New System.Drawing.Size(197, 21)
        Me.fraGrid.TabIndex = 6
        Me.fraGrid.TabStop = False
        '
        'cboDispGridMain
        '
        Me.cboDispGridMain.BackColor = System.Drawing.SystemColors.Window
        Me.cboDispGridMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDispGridMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispGridMain.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDispGridMain.Items.AddRange(New Object() {"2", "4", "8", "16", "32", "64", "3", "6", "12", "24", "48", "NONE"})
        Me.cboDispGridMain.Location = New System.Drawing.Point(128, 0)
        Me.cboDispGridMain.Name = "cboDispGridMain"
        Me.cboDispGridMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDispGridMain.Size = New System.Drawing.Size(57, 20)
        Me.cboDispGridMain.TabIndex = 10
        '
        'cboDispGridSub
        '
        Me.cboDispGridSub.BackColor = System.Drawing.SystemColors.Window
        Me.cboDispGridSub.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDispGridSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispGridSub.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDispGridSub.Items.AddRange(New Object() {"4", "8", "16", "32", "64", "3", "6", "12", "24", "48", "FREE"})
        Me.cboDispGridSub.Location = New System.Drawing.Point(32, 0)
        Me.cboDispGridSub.Name = "cboDispGridSub"
        Me.cboDispGridSub.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDispGridSub.Size = New System.Drawing.Size(57, 20)
        Me.cboDispGridSub.TabIndex = 8
        '
        'lblGridSub
        '
        Me.lblGridSub.AutoSize = True
        Me.lblGridSub.BackColor = System.Drawing.SystemColors.Control
        Me.lblGridSub.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGridSub.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGridSub.Location = New System.Drawing.Point(96, 4)
        Me.lblGridSub.Name = "lblGridSub"
        Me.lblGridSub.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGridSub.Size = New System.Drawing.Size(29, 12)
        Me.lblGridSub.TabIndex = 9
        Me.lblGridSub.Text = "補助"
        '
        'lblGridMain
        '
        Me.lblGridMain.AutoSize = True
        Me.lblGridMain.BackColor = System.Drawing.SystemColors.Control
        Me.lblGridMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGridMain.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGridMain.Location = New System.Drawing.Point(0, 4)
        Me.lblGridMain.Name = "lblGridMain"
        Me.lblGridMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGridMain.Size = New System.Drawing.Size(29, 12)
        Me.lblGridMain.TabIndex = 7
        Me.lblGridMain.Text = "Grid"
        '
        'fraHeader
        '
        Me.fraHeader.BackColor = System.Drawing.SystemColors.Control
        Me.fraHeader.Controls.Add(Me._fraTop_0)
        Me.fraHeader.Controls.Add(Me._fraTop_1)
        Me.fraHeader.Controls.Add(Me._fraTop_2)
        Me.fraHeader.Controls.Add(Me._optChangeTop_0)
        Me.fraHeader.Controls.Add(Me._optChangeTop_2)
        Me.fraHeader.Controls.Add(Me._optChangeTop_1)
        Me.fraHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraHeader.Location = New System.Drawing.Point(140, 56)
        Me.fraHeader.Name = "fraHeader"
        Me.fraHeader.Padding = New System.Windows.Forms.Padding(0)
        Me.fraHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraHeader.Size = New System.Drawing.Size(666, 165)
        Me.fraHeader.TabIndex = 19
        Me.fraHeader.TabStop = False
        '
        '_fraTop_0
        '
        Me._fraTop_0.BackColor = System.Drawing.SystemColors.Control
        Me._fraTop_0.Controls.Add(Me.cboPlayer)
        Me._fraTop_0.Controls.Add(Me.txtGenre)
        Me._fraTop_0.Controls.Add(Me.txtTitle)
        Me._fraTop_0.Controls.Add(Me.txtArtist)
        Me._fraTop_0.Controls.Add(Me.cboPlayLevel)
        Me._fraTop_0.Controls.Add(Me.txtBPM)
        Me._fraTop_0.Controls.Add(Me.lblPlayMode)
        Me._fraTop_0.Controls.Add(Me.lblGenre)
        Me._fraTop_0.Controls.Add(Me.lblTitle)
        Me._fraTop_0.Controls.Add(Me.lblArtist)
        Me._fraTop_0.Controls.Add(Me.lblPlayLevel)
        Me._fraTop_0.Controls.Add(Me.lblBPM)
        Me._fraTop_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraTop_0.Location = New System.Drawing.Point(0, 32)
        Me._fraTop_0.Name = "_fraTop_0"
        Me._fraTop_0.Padding = New System.Windows.Forms.Padding(0)
        Me._fraTop_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraTop_0.Size = New System.Drawing.Size(217, 125)
        Me._fraTop_0.TabIndex = 23
        Me._fraTop_0.TabStop = False
        Me._fraTop_0.Visible = False
        '
        'cboPlayer
        '
        Me.cboPlayer.BackColor = System.Drawing.SystemColors.Window
        Me.cboPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlayer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPlayer.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboPlayer.Location = New System.Drawing.Point(80, 8)
        Me.cboPlayer.Name = "cboPlayer"
        Me.cboPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPlayer.Size = New System.Drawing.Size(133, 20)
        Me.cboPlayer.TabIndex = 25
        '
        'txtGenre
        '
        Me.txtGenre.AcceptsReturn = True
        Me.txtGenre.BackColor = System.Drawing.SystemColors.Window
        Me.txtGenre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGenre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGenre.Location = New System.Drawing.Point(80, 32)
        Me.txtGenre.MaxLength = 0
        Me.txtGenre.Name = "txtGenre"
        Me.txtGenre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGenre.Size = New System.Drawing.Size(133, 19)
        Me.txtGenre.TabIndex = 27
        '
        'txtTitle
        '
        Me.txtTitle.AcceptsReturn = True
        Me.txtTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTitle.Location = New System.Drawing.Point(80, 56)
        Me.txtTitle.MaxLength = 0
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTitle.Size = New System.Drawing.Size(133, 19)
        Me.txtTitle.TabIndex = 29
        '
        'txtArtist
        '
        Me.txtArtist.AcceptsReturn = True
        Me.txtArtist.BackColor = System.Drawing.SystemColors.Window
        Me.txtArtist.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtArtist.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArtist.Location = New System.Drawing.Point(80, 80)
        Me.txtArtist.MaxLength = 0
        Me.txtArtist.Name = "txtArtist"
        Me.txtArtist.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtArtist.Size = New System.Drawing.Size(133, 19)
        Me.txtArtist.TabIndex = 31
        '
        'cboPlayLevel
        '
        Me.cboPlayLevel.BackColor = System.Drawing.SystemColors.Window
        Me.cboPlayLevel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboPlayLevel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPlayLevel.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboPlayLevel.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "0"})
        Me.cboPlayLevel.Location = New System.Drawing.Point(80, 104)
        Me.cboPlayLevel.Name = "cboPlayLevel"
        Me.cboPlayLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPlayLevel.Size = New System.Drawing.Size(49, 20)
        Me.cboPlayLevel.TabIndex = 33
        '
        'txtBPM
        '
        Me.txtBPM.AcceptsReturn = True
        Me.txtBPM.BackColor = System.Drawing.SystemColors.Window
        Me.txtBPM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBPM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBPM.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBPM.Location = New System.Drawing.Point(172, 104)
        Me.txtBPM.MaxLength = 0
        Me.txtBPM.Name = "txtBPM"
        Me.txtBPM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBPM.Size = New System.Drawing.Size(41, 19)
        Me.txtBPM.TabIndex = 35
        Me.txtBPM.Text = "130"
        '
        'lblPlayMode
        '
        Me.lblPlayMode.AutoSize = True
        Me.lblPlayMode.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayMode.Location = New System.Drawing.Point(4, 12)
        Me.lblPlayMode.Name = "lblPlayMode"
        Me.lblPlayMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayMode.Size = New System.Drawing.Size(77, 12)
        Me.lblPlayMode.TabIndex = 24
        Me.lblPlayMode.Text = "プレイモード"
        Me.lblPlayMode.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblGenre
        '
        Me.lblGenre.AutoSize = True
        Me.lblGenre.BackColor = System.Drawing.SystemColors.Control
        Me.lblGenre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGenre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGenre.Location = New System.Drawing.Point(28, 36)
        Me.lblGenre.Name = "lblGenre"
        Me.lblGenre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGenre.Size = New System.Drawing.Size(53, 12)
        Me.lblGenre.TabIndex = 26
        Me.lblGenre.Text = "ジャンル"
        Me.lblGenre.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTitle.Location = New System.Drawing.Point(28, 60)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitle.Size = New System.Drawing.Size(53, 12)
        Me.lblTitle.TabIndex = 28
        Me.lblTitle.Text = "タイトル"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblArtist
        '
        Me.lblArtist.AutoSize = True
        Me.lblArtist.BackColor = System.Drawing.SystemColors.Control
        Me.lblArtist.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblArtist.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblArtist.Location = New System.Drawing.Point(4, 84)
        Me.lblArtist.Name = "lblArtist"
        Me.lblArtist.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblArtist.Size = New System.Drawing.Size(77, 12)
        Me.lblArtist.TabIndex = 30
        Me.lblArtist.Text = "アーティスト"
        Me.lblArtist.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPlayLevel
        '
        Me.lblPlayLevel.AutoSize = True
        Me.lblPlayLevel.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayLevel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayLevel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayLevel.Location = New System.Drawing.Point(16, 108)
        Me.lblPlayLevel.Name = "lblPlayLevel"
        Me.lblPlayLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayLevel.Size = New System.Drawing.Size(65, 12)
        Me.lblPlayLevel.TabIndex = 32
        Me.lblPlayLevel.Text = "難易度表示"
        Me.lblPlayLevel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBPM
        '
        Me.lblBPM.AutoSize = True
        Me.lblBPM.BackColor = System.Drawing.SystemColors.Control
        Me.lblBPM.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBPM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBPM.Location = New System.Drawing.Point(148, 108)
        Me.lblBPM.Name = "lblBPM"
        Me.lblBPM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBPM.Size = New System.Drawing.Size(23, 12)
        Me.lblBPM.TabIndex = 34
        Me.lblBPM.Text = "BPM"
        Me.lblBPM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_fraTop_1
        '
        Me._fraTop_1.BackColor = System.Drawing.SystemColors.Control
        Me._fraTop_1.Controls.Add(Me.cboPlayRank)
        Me._fraTop_1.Controls.Add(Me.txtTotal)
        Me._fraTop_1.Controls.Add(Me.txtVolume)
        Me._fraTop_1.Controls.Add(Me.txtStageFile)
        Me._fraTop_1.Controls.Add(Me.cmdLoadStageFile)
        Me._fraTop_1.Controls.Add(Me.cmdLoadMissBMP)
        Me._fraTop_1.Controls.Add(Me.txtMissBMP)
        Me._fraTop_1.Controls.Add(Me.lblPlayRank)
        Me._fraTop_1.Controls.Add(Me.lblTotal)
        Me._fraTop_1.Controls.Add(Me.lblVolume)
        Me._fraTop_1.Controls.Add(Me.lblStageFile)
        Me._fraTop_1.Controls.Add(Me.lblMissBMP)
        Me._fraTop_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraTop_1.Location = New System.Drawing.Point(220, 32)
        Me._fraTop_1.Name = "_fraTop_1"
        Me._fraTop_1.Padding = New System.Windows.Forms.Padding(0)
        Me._fraTop_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraTop_1.Size = New System.Drawing.Size(217, 125)
        Me._fraTop_1.TabIndex = 36
        Me._fraTop_1.TabStop = False
        Me._fraTop_1.Visible = False
        '
        'cboPlayRank
        '
        Me.cboPlayRank.BackColor = System.Drawing.SystemColors.Window
        Me.cboPlayRank.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboPlayRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlayRank.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPlayRank.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboPlayRank.Items.AddRange(New Object() {"Very Hard", "Hard", "Normal", "Easy"})
        Me.cboPlayRank.Location = New System.Drawing.Point(80, 8)
        Me.cboPlayRank.Name = "cboPlayRank"
        Me.cboPlayRank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPlayRank.Size = New System.Drawing.Size(133, 20)
        Me.cboPlayRank.TabIndex = 38
        '
        'txtTotal
        '
        Me.txtTotal.AcceptsReturn = True
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTotal.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTotal.Location = New System.Drawing.Point(80, 32)
        Me.txtTotal.MaxLength = 0
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotal.Size = New System.Drawing.Size(133, 19)
        Me.txtTotal.TabIndex = 40
        '
        'txtVolume
        '
        Me.txtVolume.AcceptsReturn = True
        Me.txtVolume.BackColor = System.Drawing.SystemColors.Window
        Me.txtVolume.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVolume.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVolume.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtVolume.Location = New System.Drawing.Point(80, 56)
        Me.txtVolume.MaxLength = 0
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVolume.Size = New System.Drawing.Size(133, 19)
        Me.txtVolume.TabIndex = 42
        '
        'txtStageFile
        '
        Me.txtStageFile.AcceptsReturn = True
        Me.txtStageFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtStageFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStageFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStageFile.Location = New System.Drawing.Point(80, 80)
        Me.txtStageFile.MaxLength = 0
        Me.txtStageFile.Name = "txtStageFile"
        Me.txtStageFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStageFile.Size = New System.Drawing.Size(93, 19)
        Me.txtStageFile.TabIndex = 44
        '
        'cmdLoadStageFile
        '
        Me.cmdLoadStageFile.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLoadStageFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLoadStageFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoadStageFile.Location = New System.Drawing.Point(176, 80)
        Me.cmdLoadStageFile.Name = "cmdLoadStageFile"
        Me.cmdLoadStageFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLoadStageFile.Size = New System.Drawing.Size(37, 17)
        Me.cmdLoadStageFile.TabIndex = 45
        Me.cmdLoadStageFile.Text = "参照"
        Me.cmdLoadStageFile.UseVisualStyleBackColor = False
        '
        'cmdLoadMissBMP
        '
        Me.cmdLoadMissBMP.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLoadMissBMP.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLoadMissBMP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoadMissBMP.Location = New System.Drawing.Point(176, 104)
        Me.cmdLoadMissBMP.Name = "cmdLoadMissBMP"
        Me.cmdLoadMissBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLoadMissBMP.Size = New System.Drawing.Size(37, 17)
        Me.cmdLoadMissBMP.TabIndex = 48
        Me.cmdLoadMissBMP.Text = "参照"
        Me.cmdLoadMissBMP.UseVisualStyleBackColor = False
        '
        'txtMissBMP
        '
        Me.txtMissBMP.AcceptsReturn = True
        Me.txtMissBMP.BackColor = System.Drawing.SystemColors.Window
        Me.txtMissBMP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMissBMP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMissBMP.Location = New System.Drawing.Point(80, 104)
        Me.txtMissBMP.MaxLength = 0
        Me.txtMissBMP.Name = "txtMissBMP"
        Me.txtMissBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMissBMP.Size = New System.Drawing.Size(93, 19)
        Me.txtMissBMP.TabIndex = 47
        '
        'lblPlayRank
        '
        Me.lblPlayRank.AutoSize = True
        Me.lblPlayRank.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayRank.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayRank.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayRank.Location = New System.Drawing.Point(45, 12)
        Me.lblPlayRank.Name = "lblPlayRank"
        Me.lblPlayRank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayRank.Size = New System.Drawing.Size(35, 12)
        Me.lblPlayRank.TabIndex = 37
        Me.lblPlayRank.Text = "#RANK"
        Me.lblPlayRank.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.Location = New System.Drawing.Point(40, 36)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotal.Size = New System.Drawing.Size(41, 12)
        Me.lblTotal.TabIndex = 39
        Me.lblTotal.Text = "#TOTAL"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.BackColor = System.Drawing.SystemColors.Control
        Me.lblVolume.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVolume.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVolume.Location = New System.Drawing.Point(34, 60)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVolume.Size = New System.Drawing.Size(47, 12)
        Me.lblVolume.TabIndex = 41
        Me.lblVolume.Text = "#VOLWAV"
        Me.lblVolume.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblStageFile
        '
        Me.lblStageFile.AutoSize = True
        Me.lblStageFile.BackColor = System.Drawing.SystemColors.Control
        Me.lblStageFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStageFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStageFile.Location = New System.Drawing.Point(15, 84)
        Me.lblStageFile.Name = "lblStageFile"
        Me.lblStageFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStageFile.Size = New System.Drawing.Size(65, 12)
        Me.lblStageFile.TabIndex = 43
        Me.lblStageFile.Text = "#STAGEFILE"
        Me.lblStageFile.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMissBMP
        '
        Me.lblMissBMP.AutoSize = True
        Me.lblMissBMP.BackColor = System.Drawing.SystemColors.Control
        Me.lblMissBMP.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMissBMP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMissBMP.Location = New System.Drawing.Point(39, 108)
        Me.lblMissBMP.Name = "lblMissBMP"
        Me.lblMissBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMissBMP.Size = New System.Drawing.Size(41, 12)
        Me.lblMissBMP.TabIndex = 46
        Me.lblMissBMP.Text = "#BMP00"
        Me.lblMissBMP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_fraTop_2
        '
        Me._fraTop_2.BackColor = System.Drawing.SystemColors.Control
        Me._fraTop_2.Controls.Add(Me.cboDispFrame)
        Me._fraTop_2.Controls.Add(Me.cboDispSC2P)
        Me._fraTop_2.Controls.Add(Me.cboDispSC1P)
        Me._fraTop_2.Controls.Add(Me.cboDispKey)
        Me._fraTop_2.Controls.Add(Me.lblDispFrame)
        Me._fraTop_2.Controls.Add(Me.lblDispSC2P)
        Me._fraTop_2.Controls.Add(Me.lblDispSC1P)
        Me._fraTop_2.Controls.Add(Me.lblDispKey)
        Me._fraTop_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraTop_2.Location = New System.Drawing.Point(440, 32)
        Me._fraTop_2.Name = "_fraTop_2"
        Me._fraTop_2.Padding = New System.Windows.Forms.Padding(0)
        Me._fraTop_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraTop_2.Size = New System.Drawing.Size(217, 125)
        Me._fraTop_2.TabIndex = 49
        Me._fraTop_2.TabStop = False
        Me._fraTop_2.Visible = False
        '
        'cboDispFrame
        '
        Me.cboDispFrame.BackColor = System.Drawing.SystemColors.Window
        Me.cboDispFrame.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDispFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispFrame.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDispFrame.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboDispFrame.Items.AddRange(New Object() {"ハーフ", "セパレート"})
        Me.cboDispFrame.Location = New System.Drawing.Point(80, 8)
        Me.cboDispFrame.Name = "cboDispFrame"
        Me.cboDispFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDispFrame.Size = New System.Drawing.Size(133, 20)
        Me.cboDispFrame.TabIndex = 51
        '
        'cboDispSC2P
        '
        Me.cboDispSC2P.BackColor = System.Drawing.SystemColors.Window
        Me.cboDispSC2P.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDispSC2P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispSC2P.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDispSC2P.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboDispSC2P.Items.AddRange(New Object() {"左", "右"})
        Me.cboDispSC2P.Location = New System.Drawing.Point(164, 56)
        Me.cboDispSC2P.Name = "cboDispSC2P"
        Me.cboDispSC2P.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDispSC2P.Size = New System.Drawing.Size(49, 20)
        Me.cboDispSC2P.TabIndex = 57
        '
        'cboDispSC1P
        '
        Me.cboDispSC1P.BackColor = System.Drawing.SystemColors.Window
        Me.cboDispSC1P.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDispSC1P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispSC1P.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDispSC1P.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboDispSC1P.Items.AddRange(New Object() {"左", "右"})
        Me.cboDispSC1P.Location = New System.Drawing.Point(80, 56)
        Me.cboDispSC1P.Name = "cboDispSC1P"
        Me.cboDispSC1P.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDispSC1P.Size = New System.Drawing.Size(49, 20)
        Me.cboDispSC1P.TabIndex = 55
        '
        'cboDispKey
        '
        Me.cboDispKey.BackColor = System.Drawing.SystemColors.Window
        Me.cboDispKey.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDispKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDispKey.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDispKey.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cboDispKey.Items.AddRange(New Object() {"5Keys/10Keys", "7Keys/14Keys"})
        Me.cboDispKey.Location = New System.Drawing.Point(80, 32)
        Me.cboDispKey.Name = "cboDispKey"
        Me.cboDispKey.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDispKey.Size = New System.Drawing.Size(133, 20)
        Me.cboDispKey.TabIndex = 53
        '
        'lblDispFrame
        '
        Me.lblDispFrame.AutoSize = True
        Me.lblDispFrame.BackColor = System.Drawing.SystemColors.Control
        Me.lblDispFrame.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDispFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDispFrame.Location = New System.Drawing.Point(28, 12)
        Me.lblDispFrame.Name = "lblDispFrame"
        Me.lblDispFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDispFrame.Size = New System.Drawing.Size(53, 12)
        Me.lblDispFrame.TabIndex = 50
        Me.lblDispFrame.Text = "キー表示"
        Me.lblDispFrame.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDispSC2P
        '
        Me.lblDispSC2P.AutoSize = True
        Me.lblDispSC2P.BackColor = System.Drawing.SystemColors.Control
        Me.lblDispSC2P.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDispSC2P.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDispSC2P.Location = New System.Drawing.Point(148, 60)
        Me.lblDispSC2P.Name = "lblDispSC2P"
        Me.lblDispSC2P.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDispSC2P.Size = New System.Drawing.Size(17, 12)
        Me.lblDispSC2P.TabIndex = 56
        Me.lblDispSC2P.Text = "2P"
        Me.lblDispSC2P.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDispSC1P
        '
        Me.lblDispSC1P.AutoSize = True
        Me.lblDispSC1P.BackColor = System.Drawing.SystemColors.Control
        Me.lblDispSC1P.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDispSC1P.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDispSC1P.Location = New System.Drawing.Point(4, 60)
        Me.lblDispSC1P.Name = "lblDispSC1P"
        Me.lblDispSC1P.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDispSC1P.Size = New System.Drawing.Size(77, 12)
        Me.lblDispSC1P.TabIndex = 54
        Me.lblDispSC1P.Text = "スクラッチ1P"
        Me.lblDispSC1P.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDispKey
        '
        Me.lblDispKey.AutoSize = True
        Me.lblDispKey.BackColor = System.Drawing.SystemColors.Control
        Me.lblDispKey.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDispKey.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDispKey.Location = New System.Drawing.Point(28, 36)
        Me.lblDispKey.Name = "lblDispKey"
        Me.lblDispKey.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDispKey.Size = New System.Drawing.Size(53, 12)
        Me.lblDispKey.TabIndex = 52
        Me.lblDispKey.Text = "キー配置"
        Me.lblDispKey.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_optChangeTop_0
        '
        Me._optChangeTop_0.Appearance = System.Windows.Forms.Appearance.Button
        Me._optChangeTop_0.BackColor = System.Drawing.SystemColors.Control
        Me._optChangeTop_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optChangeTop_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optChangeTop_0.Location = New System.Drawing.Point(0, 0)
        Me._optChangeTop_0.Name = "_optChangeTop_0"
        Me._optChangeTop_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optChangeTop_0.Size = New System.Drawing.Size(61, 21)
        Me._optChangeTop_0.TabIndex = 20
        Me._optChangeTop_0.TabStop = True
        Me._optChangeTop_0.Text = "基本"
        Me._optChangeTop_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._optChangeTop_0.UseVisualStyleBackColor = False
        '
        '_optChangeTop_2
        '
        Me._optChangeTop_2.Appearance = System.Windows.Forms.Appearance.Button
        Me._optChangeTop_2.BackColor = System.Drawing.SystemColors.Control
        Me._optChangeTop_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optChangeTop_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optChangeTop_2.Location = New System.Drawing.Point(130, 0)
        Me._optChangeTop_2.Name = "_optChangeTop_2"
        Me._optChangeTop_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optChangeTop_2.Size = New System.Drawing.Size(61, 21)
        Me._optChangeTop_2.TabIndex = 22
        Me._optChangeTop_2.TabStop = True
        Me._optChangeTop_2.Text = "環境"
        Me._optChangeTop_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._optChangeTop_2.UseVisualStyleBackColor = False
        '
        '_optChangeTop_1
        '
        Me._optChangeTop_1.Appearance = System.Windows.Forms.Appearance.Button
        Me._optChangeTop_1.BackColor = System.Drawing.SystemColors.Control
        Me._optChangeTop_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optChangeTop_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optChangeTop_1.Location = New System.Drawing.Point(65, 0)
        Me._optChangeTop_1.Name = "_optChangeTop_1"
        Me._optChangeTop_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optChangeTop_1.Size = New System.Drawing.Size(61, 21)
        Me._optChangeTop_1.TabIndex = 21
        Me._optChangeTop_1.TabStop = True
        Me._optChangeTop_1.Text = "拡張"
        Me._optChangeTop_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._optChangeTop_1.UseVisualStyleBackColor = False
        '
        'fraMaterial
        '
        Me.fraMaterial.BackColor = System.Drawing.SystemColors.Control
        Me.fraMaterial.Controls.Add(Me._optChangeBottom_0)
        Me.fraMaterial.Controls.Add(Me._optChangeBottom_1)
        Me.fraMaterial.Controls.Add(Me._optChangeBottom_2)
        Me.fraMaterial.Controls.Add(Me._optChangeBottom_3)
        Me.fraMaterial.Controls.Add(Me._optChangeBottom_4)
        Me.fraMaterial.Controls.Add(Me._fraBottom_4)
        Me.fraMaterial.Controls.Add(Me._fraBottom_0)
        Me.fraMaterial.Controls.Add(Me._fraBottom_1)
        Me.fraMaterial.Controls.Add(Me._fraBottom_2)
        Me.fraMaterial.Controls.Add(Me._fraBottom_3)
        Me.fraMaterial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraMaterial.Location = New System.Drawing.Point(140, 228)
        Me.fraMaterial.Name = "fraMaterial"
        Me.fraMaterial.Padding = New System.Windows.Forms.Padding(0)
        Me.fraMaterial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraMaterial.Size = New System.Drawing.Size(1105, 269)
        Me.fraMaterial.TabIndex = 58
        Me.fraMaterial.TabStop = False
        '
        '_optChangeBottom_0
        '
        Me._optChangeBottom_0.Appearance = System.Windows.Forms.Appearance.Button
        Me._optChangeBottom_0.BackColor = System.Drawing.SystemColors.Control
        Me._optChangeBottom_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optChangeBottom_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optChangeBottom_0.Location = New System.Drawing.Point(0, 0)
        Me._optChangeBottom_0.Name = "_optChangeBottom_0"
        Me._optChangeBottom_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optChangeBottom_0.Size = New System.Drawing.Size(61, 21)
        Me._optChangeBottom_0.TabIndex = 59
        Me._optChangeBottom_0.TabStop = True
        Me._optChangeBottom_0.Text = "#WAV"
        Me._optChangeBottom_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._optChangeBottom_0.UseVisualStyleBackColor = False
        '
        '_optChangeBottom_1
        '
        Me._optChangeBottom_1.Appearance = System.Windows.Forms.Appearance.Button
        Me._optChangeBottom_1.BackColor = System.Drawing.SystemColors.Control
        Me._optChangeBottom_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optChangeBottom_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optChangeBottom_1.Location = New System.Drawing.Point(65, 0)
        Me._optChangeBottom_1.Name = "_optChangeBottom_1"
        Me._optChangeBottom_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optChangeBottom_1.Size = New System.Drawing.Size(61, 21)
        Me._optChangeBottom_1.TabIndex = 60
        Me._optChangeBottom_1.TabStop = True
        Me._optChangeBottom_1.Text = "#BMP"
        Me._optChangeBottom_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._optChangeBottom_1.UseVisualStyleBackColor = False
        '
        '_optChangeBottom_2
        '
        Me._optChangeBottom_2.Appearance = System.Windows.Forms.Appearance.Button
        Me._optChangeBottom_2.BackColor = System.Drawing.SystemColors.Control
        Me._optChangeBottom_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optChangeBottom_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optChangeBottom_2.Location = New System.Drawing.Point(130, 0)
        Me._optChangeBottom_2.Name = "_optChangeBottom_2"
        Me._optChangeBottom_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optChangeBottom_2.Size = New System.Drawing.Size(61, 21)
        Me._optChangeBottom_2.TabIndex = 61
        Me._optChangeBottom_2.TabStop = True
        Me._optChangeBottom_2.Text = "#BGA"
        Me._optChangeBottom_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._optChangeBottom_2.UseVisualStyleBackColor = False
        '
        '_optChangeBottom_3
        '
        Me._optChangeBottom_3.Appearance = System.Windows.Forms.Appearance.Button
        Me._optChangeBottom_3.BackColor = System.Drawing.SystemColors.Control
        Me._optChangeBottom_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._optChangeBottom_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optChangeBottom_3.Location = New System.Drawing.Point(0, 25)
        Me._optChangeBottom_3.Name = "_optChangeBottom_3"
        Me._optChangeBottom_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optChangeBottom_3.Size = New System.Drawing.Size(61, 21)
        Me._optChangeBottom_3.TabIndex = 62
        Me._optChangeBottom_3.TabStop = True
        Me._optChangeBottom_3.Text = "拍子"
        Me._optChangeBottom_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._optChangeBottom_3.UseVisualStyleBackColor = False
        '
        '_optChangeBottom_4
        '
        Me._optChangeBottom_4.Appearance = System.Windows.Forms.Appearance.Button
        Me._optChangeBottom_4.BackColor = System.Drawing.SystemColors.Control
        Me._optChangeBottom_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._optChangeBottom_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._optChangeBottom_4.Location = New System.Drawing.Point(65, 25)
        Me._optChangeBottom_4.Name = "_optChangeBottom_4"
        Me._optChangeBottom_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optChangeBottom_4.Size = New System.Drawing.Size(61, 21)
        Me._optChangeBottom_4.TabIndex = 63
        Me._optChangeBottom_4.TabStop = True
        Me._optChangeBottom_4.Text = "拡張命令"
        Me._optChangeBottom_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._optChangeBottom_4.UseVisualStyleBackColor = False
        '
        '_fraBottom_4
        '
        Me._fraBottom_4.BackColor = System.Drawing.SystemColors.Control
        Me._fraBottom_4.Controls.Add(Me.txtExInfo)
        Me._fraBottom_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraBottom_4.Location = New System.Drawing.Point(884, 32)
        Me._fraBottom_4.Name = "_fraBottom_4"
        Me._fraBottom_4.Padding = New System.Windows.Forms.Padding(0)
        Me._fraBottom_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraBottom_4.Size = New System.Drawing.Size(217, 233)
        Me._fraBottom_4.TabIndex = 93
        Me._fraBottom_4.TabStop = False
        Me._fraBottom_4.Visible = False
        '
        'txtExInfo
        '
        Me.txtExInfo.AcceptsReturn = True
        Me.txtExInfo.BackColor = System.Drawing.SystemColors.Window
        Me.txtExInfo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExInfo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExInfo.Location = New System.Drawing.Point(0, 8)
        Me.txtExInfo.MaxLength = 0
        Me.txtExInfo.Multiline = True
        Me.txtExInfo.Name = "txtExInfo"
        Me.txtExInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtExInfo.Size = New System.Drawing.Size(213, 217)
        Me.txtExInfo.TabIndex = 94
        Me.txtExInfo.WordWrap = False
        '
        '_fraBottom_0
        '
        Me._fraBottom_0.BackColor = System.Drawing.SystemColors.Control
        Me._fraBottom_0.Controls.Add(Me.cmdSoundExcUp)
        Me._fraBottom_0.Controls.Add(Me.cmdSoundExcDown)
        Me._fraBottom_0.Controls.Add(Me.cmdSoundDelete)
        Me._fraBottom_0.Controls.Add(Me.cmdSoundLoad)
        Me._fraBottom_0.Controls.Add(Me.cmdSoundStop)
        Me._fraBottom_0.Controls.Add(Me.lstWAV)
        Me._fraBottom_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraBottom_0.Location = New System.Drawing.Point(4, 56)
        Me._fraBottom_0.Name = "_fraBottom_0"
        Me._fraBottom_0.Padding = New System.Windows.Forms.Padding(0)
        Me._fraBottom_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraBottom_0.Size = New System.Drawing.Size(217, 209)
        Me._fraBottom_0.TabIndex = 64
        Me._fraBottom_0.TabStop = False
        Me._fraBottom_0.Visible = False
        '
        'cmdSoundExcUp
        '
        Me.cmdSoundExcUp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSoundExcUp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSoundExcUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSoundExcUp.Location = New System.Drawing.Point(61, 180)
        Me.cmdSoundExcUp.Name = "cmdSoundExcUp"
        Me.cmdSoundExcUp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSoundExcUp.Size = New System.Drawing.Size(21, 21)
        Me.cmdSoundExcUp.TabIndex = 67
        Me.cmdSoundExcUp.Text = "▲"
        Me.cmdSoundExcUp.UseVisualStyleBackColor = False
        '
        'cmdSoundExcDown
        '
        Me.cmdSoundExcDown.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSoundExcDown.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSoundExcDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSoundExcDown.Location = New System.Drawing.Point(86, 180)
        Me.cmdSoundExcDown.Name = "cmdSoundExcDown"
        Me.cmdSoundExcDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSoundExcDown.Size = New System.Drawing.Size(21, 21)
        Me.cmdSoundExcDown.TabIndex = 68
        Me.cmdSoundExcDown.Text = "▼"
        Me.cmdSoundExcDown.UseVisualStyleBackColor = False
        '
        'cmdSoundDelete
        '
        Me.cmdSoundDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSoundDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSoundDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSoundDelete.Location = New System.Drawing.Point(126, 180)
        Me.cmdSoundDelete.Name = "cmdSoundDelete"
        Me.cmdSoundDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSoundDelete.Size = New System.Drawing.Size(41, 21)
        Me.cmdSoundDelete.TabIndex = 69
        Me.cmdSoundDelete.Text = "消去"
        Me.cmdSoundDelete.UseVisualStyleBackColor = False
        '
        'cmdSoundLoad
        '
        Me.cmdSoundLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSoundLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSoundLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSoundLoad.Location = New System.Drawing.Point(172, 180)
        Me.cmdSoundLoad.Name = "cmdSoundLoad"
        Me.cmdSoundLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSoundLoad.Size = New System.Drawing.Size(41, 21)
        Me.cmdSoundLoad.TabIndex = 70
        Me.cmdSoundLoad.Text = "指定"
        Me.cmdSoundLoad.UseVisualStyleBackColor = False
        '
        'cmdSoundStop
        '
        Me.cmdSoundStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSoundStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSoundStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSoundStop.Location = New System.Drawing.Point(0, 180)
        Me.cmdSoundStop.Name = "cmdSoundStop"
        Me.cmdSoundStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSoundStop.Size = New System.Drawing.Size(53, 21)
        Me.cmdSoundStop.TabIndex = 66
        Me.cmdSoundStop.Text = "停止"
        Me.cmdSoundStop.UseVisualStyleBackColor = False
        '
        'lstWAV
        '
        Me.lstWAV.BackColor = System.Drawing.SystemColors.Window
        Me.lstWAV.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstWAV.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstWAV.ItemHeight = 12
        Me.lstWAV.Location = New System.Drawing.Point(0, 8)
        Me.lstWAV.Name = "lstWAV"
        Me.lstWAV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstWAV.Size = New System.Drawing.Size(213, 148)
        Me.lstWAV.TabIndex = 65
        '
        '_fraBottom_1
        '
        Me._fraBottom_1.BackColor = System.Drawing.SystemColors.Control
        Me._fraBottom_1.Controls.Add(Me.cmdBMPExcDown)
        Me._fraBottom_1.Controls.Add(Me.cmdBMPExcUp)
        Me._fraBottom_1.Controls.Add(Me.lstBMP)
        Me._fraBottom_1.Controls.Add(Me.cmdBMPDelete)
        Me._fraBottom_1.Controls.Add(Me.cmdBMPLoad)
        Me._fraBottom_1.Controls.Add(Me.cmdBMPPreview)
        Me._fraBottom_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraBottom_1.Location = New System.Drawing.Point(224, 32)
        Me._fraBottom_1.Name = "_fraBottom_1"
        Me._fraBottom_1.Padding = New System.Windows.Forms.Padding(0)
        Me._fraBottom_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraBottom_1.Size = New System.Drawing.Size(217, 233)
        Me._fraBottom_1.TabIndex = 71
        Me._fraBottom_1.TabStop = False
        Me._fraBottom_1.Visible = False
        '
        'cmdBMPExcDown
        '
        Me.cmdBMPExcDown.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBMPExcDown.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBMPExcDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBMPExcDown.Location = New System.Drawing.Point(86, 204)
        Me.cmdBMPExcDown.Name = "cmdBMPExcDown"
        Me.cmdBMPExcDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBMPExcDown.Size = New System.Drawing.Size(21, 21)
        Me.cmdBMPExcDown.TabIndex = 75
        Me.cmdBMPExcDown.Text = "▼"
        Me.cmdBMPExcDown.UseVisualStyleBackColor = False
        '
        'cmdBMPExcUp
        '
        Me.cmdBMPExcUp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBMPExcUp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBMPExcUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBMPExcUp.Location = New System.Drawing.Point(61, 204)
        Me.cmdBMPExcUp.Name = "cmdBMPExcUp"
        Me.cmdBMPExcUp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBMPExcUp.Size = New System.Drawing.Size(21, 21)
        Me.cmdBMPExcUp.TabIndex = 74
        Me.cmdBMPExcUp.Text = "▲"
        Me.cmdBMPExcUp.UseVisualStyleBackColor = False
        '
        'lstBMP
        '
        Me.lstBMP.BackColor = System.Drawing.SystemColors.Window
        Me.lstBMP.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstBMP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstBMP.ItemHeight = 12
        Me.lstBMP.Location = New System.Drawing.Point(0, 8)
        Me.lstBMP.Name = "lstBMP"
        Me.lstBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstBMP.Size = New System.Drawing.Size(213, 172)
        Me.lstBMP.TabIndex = 72
        '
        'cmdBMPDelete
        '
        Me.cmdBMPDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBMPDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBMPDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBMPDelete.Location = New System.Drawing.Point(126, 204)
        Me.cmdBMPDelete.Name = "cmdBMPDelete"
        Me.cmdBMPDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBMPDelete.Size = New System.Drawing.Size(41, 21)
        Me.cmdBMPDelete.TabIndex = 76
        Me.cmdBMPDelete.Text = "消去"
        Me.cmdBMPDelete.UseVisualStyleBackColor = False
        '
        'cmdBMPLoad
        '
        Me.cmdBMPLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBMPLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBMPLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBMPLoad.Location = New System.Drawing.Point(172, 204)
        Me.cmdBMPLoad.Name = "cmdBMPLoad"
        Me.cmdBMPLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBMPLoad.Size = New System.Drawing.Size(41, 21)
        Me.cmdBMPLoad.TabIndex = 77
        Me.cmdBMPLoad.Text = "指定"
        Me.cmdBMPLoad.UseVisualStyleBackColor = False
        '
        'cmdBMPPreview
        '
        Me.cmdBMPPreview.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBMPPreview.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBMPPreview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBMPPreview.Location = New System.Drawing.Point(0, 204)
        Me.cmdBMPPreview.Name = "cmdBMPPreview"
        Me.cmdBMPPreview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBMPPreview.Size = New System.Drawing.Size(53, 21)
        Me.cmdBMPPreview.TabIndex = 73
        Me.cmdBMPPreview.Text = "表示"
        Me.cmdBMPPreview.UseVisualStyleBackColor = False
        '
        '_fraBottom_2
        '
        Me._fraBottom_2.BackColor = System.Drawing.SystemColors.Control
        Me._fraBottom_2.Controls.Add(Me.cmdBGAExcDown)
        Me._fraBottom_2.Controls.Add(Me.cmdBGAExcUp)
        Me._fraBottom_2.Controls.Add(Me.txtBGAInput)
        Me._fraBottom_2.Controls.Add(Me.cmdBGAPreview)
        Me._fraBottom_2.Controls.Add(Me.cmdBGASet)
        Me._fraBottom_2.Controls.Add(Me.cmdBGADelete)
        Me._fraBottom_2.Controls.Add(Me.lstBGA)
        Me._fraBottom_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraBottom_2.Location = New System.Drawing.Point(444, 32)
        Me._fraBottom_2.Name = "_fraBottom_2"
        Me._fraBottom_2.Padding = New System.Windows.Forms.Padding(0)
        Me._fraBottom_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraBottom_2.Size = New System.Drawing.Size(217, 233)
        Me._fraBottom_2.TabIndex = 78
        Me._fraBottom_2.TabStop = False
        Me._fraBottom_2.Visible = False
        '
        'cmdBGAExcDown
        '
        Me.cmdBGAExcDown.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBGAExcDown.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBGAExcDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBGAExcDown.Location = New System.Drawing.Point(86, 204)
        Me.cmdBGAExcDown.Name = "cmdBGAExcDown"
        Me.cmdBGAExcDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBGAExcDown.Size = New System.Drawing.Size(21, 21)
        Me.cmdBGAExcDown.TabIndex = 83
        Me.cmdBGAExcDown.Text = "▼"
        Me.cmdBGAExcDown.UseVisualStyleBackColor = False
        '
        'cmdBGAExcUp
        '
        Me.cmdBGAExcUp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBGAExcUp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBGAExcUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBGAExcUp.Location = New System.Drawing.Point(61, 204)
        Me.cmdBGAExcUp.Name = "cmdBGAExcUp"
        Me.cmdBGAExcUp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBGAExcUp.Size = New System.Drawing.Size(21, 21)
        Me.cmdBGAExcUp.TabIndex = 82
        Me.cmdBGAExcUp.Text = "▲"
        Me.cmdBGAExcUp.UseVisualStyleBackColor = False
        '
        'txtBGAInput
        '
        Me.txtBGAInput.AcceptsReturn = True
        Me.txtBGAInput.BackColor = System.Drawing.SystemColors.Window
        Me.txtBGAInput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBGAInput.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBGAInput.Location = New System.Drawing.Point(0, 176)
        Me.txtBGAInput.MaxLength = 0
        Me.txtBGAInput.Name = "txtBGAInput"
        Me.txtBGAInput.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBGAInput.Size = New System.Drawing.Size(213, 19)
        Me.txtBGAInput.TabIndex = 80
        '
        'cmdBGAPreview
        '
        Me.cmdBGAPreview.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBGAPreview.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBGAPreview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBGAPreview.Location = New System.Drawing.Point(0, 205)
        Me.cmdBGAPreview.Name = "cmdBGAPreview"
        Me.cmdBGAPreview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBGAPreview.Size = New System.Drawing.Size(53, 21)
        Me.cmdBGAPreview.TabIndex = 81
        Me.cmdBGAPreview.Text = "表示"
        Me.cmdBGAPreview.UseVisualStyleBackColor = False
        '
        'cmdBGASet
        '
        Me.cmdBGASet.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBGASet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBGASet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBGASet.Location = New System.Drawing.Point(172, 204)
        Me.cmdBGASet.Name = "cmdBGASet"
        Me.cmdBGASet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBGASet.Size = New System.Drawing.Size(41, 21)
        Me.cmdBGASet.TabIndex = 85
        Me.cmdBGASet.Text = "入力"
        Me.cmdBGASet.UseVisualStyleBackColor = False
        '
        'cmdBGADelete
        '
        Me.cmdBGADelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBGADelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBGADelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBGADelete.Location = New System.Drawing.Point(126, 204)
        Me.cmdBGADelete.Name = "cmdBGADelete"
        Me.cmdBGADelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBGADelete.Size = New System.Drawing.Size(41, 21)
        Me.cmdBGADelete.TabIndex = 84
        Me.cmdBGADelete.Text = "消去"
        Me.cmdBGADelete.UseVisualStyleBackColor = False
        '
        'lstBGA
        '
        Me.lstBGA.BackColor = System.Drawing.SystemColors.Window
        Me.lstBGA.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstBGA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstBGA.ItemHeight = 12
        Me.lstBGA.Location = New System.Drawing.Point(0, 8)
        Me.lstBGA.Name = "lstBGA"
        Me.lstBGA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstBGA.Size = New System.Drawing.Size(213, 148)
        Me.lstBGA.TabIndex = 79
        '
        '_fraBottom_3
        '
        Me._fraBottom_3.BackColor = System.Drawing.SystemColors.Control
        Me._fraBottom_3.Controls.Add(Me.cboNumerator)
        Me._fraBottom_3.Controls.Add(Me.cboDenominator)
        Me._fraBottom_3.Controls.Add(Me.cmdMeasureSelectAll)
        Me._fraBottom_3.Controls.Add(Me.cmdInputMeasureLen)
        Me._fraBottom_3.Controls.Add(Me.lstMeasureLen)
        Me._fraBottom_3.Controls.Add(Me.lblFraction)
        Me._fraBottom_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraBottom_3.Location = New System.Drawing.Point(664, 32)
        Me._fraBottom_3.Name = "_fraBottom_3"
        Me._fraBottom_3.Padding = New System.Windows.Forms.Padding(0)
        Me._fraBottom_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraBottom_3.Size = New System.Drawing.Size(217, 233)
        Me._fraBottom_3.TabIndex = 86
        Me._fraBottom_3.TabStop = False
        Me._fraBottom_3.Visible = False
        '
        'cboNumerator
        '
        Me.cboNumerator.BackColor = System.Drawing.SystemColors.Window
        Me.cboNumerator.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboNumerator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNumerator.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboNumerator.Location = New System.Drawing.Point(75, 204)
        Me.cboNumerator.Name = "cboNumerator"
        Me.cboNumerator.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboNumerator.Size = New System.Drawing.Size(41, 20)
        Me.cboNumerator.TabIndex = 89
        '
        'cboDenominator
        '
        Me.cboDenominator.BackColor = System.Drawing.SystemColors.Window
        Me.cboDenominator.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDenominator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDenominator.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDenominator.Items.AddRange(New Object() {"4", "8", "16", "32", "64"})
        Me.cboDenominator.Location = New System.Drawing.Point(127, 204)
        Me.cboDenominator.Name = "cboDenominator"
        Me.cboDenominator.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDenominator.Size = New System.Drawing.Size(41, 20)
        Me.cboDenominator.TabIndex = 91
        '
        'cmdMeasureSelectAll
        '
        Me.cmdMeasureSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMeasureSelectAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMeasureSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMeasureSelectAll.Location = New System.Drawing.Point(0, 204)
        Me.cmdMeasureSelectAll.Name = "cmdMeasureSelectAll"
        Me.cmdMeasureSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMeasureSelectAll.Size = New System.Drawing.Size(53, 21)
        Me.cmdMeasureSelectAll.TabIndex = 88
        Me.cmdMeasureSelectAll.Text = "全選択"
        Me.cmdMeasureSelectAll.UseVisualStyleBackColor = False
        '
        'cmdInputMeasureLen
        '
        Me.cmdInputMeasureLen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdInputMeasureLen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdInputMeasureLen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdInputMeasureLen.Location = New System.Drawing.Point(172, 204)
        Me.cmdInputMeasureLen.Name = "cmdInputMeasureLen"
        Me.cmdInputMeasureLen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdInputMeasureLen.Size = New System.Drawing.Size(41, 21)
        Me.cmdInputMeasureLen.TabIndex = 92
        Me.cmdInputMeasureLen.Text = "入力"
        Me.cmdInputMeasureLen.UseVisualStyleBackColor = False
        '
        'lstMeasureLen
        '
        Me.lstMeasureLen.BackColor = System.Drawing.SystemColors.Window
        Me.lstMeasureLen.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstMeasureLen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstMeasureLen.ItemHeight = 12
        Me.lstMeasureLen.Location = New System.Drawing.Point(0, 8)
        Me.lstMeasureLen.Name = "lstMeasureLen"
        Me.lstMeasureLen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstMeasureLen.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstMeasureLen.Size = New System.Drawing.Size(213, 172)
        Me.lstMeasureLen.TabIndex = 87
        '
        'lblFraction
        '
        Me.lblFraction.BackColor = System.Drawing.SystemColors.Control
        Me.lblFraction.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFraction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFraction.Location = New System.Drawing.Point(119, 208)
        Me.lblFraction.Name = "lblFraction"
        Me.lblFraction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFraction.Size = New System.Drawing.Size(6, 12)
        Me.lblFraction.TabIndex = 90
        Me.lblFraction.Text = "/"
        '
        'picMain
        '
        Me.picMain.BackColor = System.Drawing.Color.Black
        Me.picMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.picMain.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.picMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.picMain.Location = New System.Drawing.Point(0, 56)
        Me.picMain.Name = "picMain"
        Me.picMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picMain.Size = New System.Drawing.Size(57, 33)
        Me.picMain.TabIndex = 0
        Me.picMain.TabStop = False
        '
        'hsbMain
        '
        Me.hsbMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsbMain.LargeChange = 1
        Me.hsbMain.Location = New System.Drawing.Point(0, 456)
        Me.hsbMain.Maximum = 0
        Me.hsbMain.Name = "hsbMain"
        Me.hsbMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbMain.Size = New System.Drawing.Size(113, 17)
        Me.hsbMain.TabIndex = 2
        '
        'vsbMain
        '
        Me.vsbMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.vsbMain.LargeChange = 8
        Me.vsbMain.Location = New System.Drawing.Point(112, 60)
        Me.vsbMain.Maximum = 64
        Me.vsbMain.Name = "vsbMain"
        Me.vsbMain.Size = New System.Drawing.Size(17, 397)
        Me.vsbMain.TabIndex = 1
        '
        'dlgMainOpen
        '
        Me.dlgMainOpen.Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"
        '
        'dlgMainSave
        '
        Me.dlgMainSave.Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"
        '
        'tlbMenu
        '
        Me.tlbMenu.CanOverflow = False
        Me.tlbMenu.ImageList = Me.ilsMenu
        Me.tlbMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tlbMenu_Button1, Me._tlbMenu_Button2, Me._tlbMenu_Button3, Me._tlbMenu_Button4, Me._tlbMenu_Button5, Me._tlbMenu_Button6, Me._tlbMenu_Button7, Me._tlbMenu_Button8, Me._tlbMenu_Button9, Me._tlbMenu_Button10, Me._tlbMenu_Button11, Me._tlbMenu_Button12, Me._tlbMenu_Button13, Me._tlbMenu_Button14, Me._tlbMenu_Button15, Me._tlbMenu_Button16, Me._tlbMenu_Button17, Me._tlbMenu_Button18, Me._tlbMenu_Button19, Me._tlbMenu_Button20})
        Me.tlbMenu.Location = New System.Drawing.Point(0, 24)
        Me.tlbMenu.Name = "tlbMenu"
        Me.tlbMenu.Size = New System.Drawing.Size(1192, 25)
        Me.tlbMenu.TabIndex = 3
        '
        '_tlbMenu_Button1
        '
        Me._tlbMenu_Button1.AutoSize = False
        Me._tlbMenu_Button1.ImageIndex = 0
        Me._tlbMenu_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button1.Name = "_tlbMenu_Button1"
        Me._tlbMenu_Button1.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button1.ToolTipText = "新規作成"
        '
        '_tlbMenu_Button2
        '
        Me._tlbMenu_Button2.AutoSize = False
        Me._tlbMenu_Button2.ImageIndex = 1
        Me._tlbMenu_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button2.Name = "_tlbMenu_Button2"
        Me._tlbMenu_Button2.Size = New System.Drawing.Size(37, 22)
        Me._tlbMenu_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button2.ToolTipText = "開く"
        '
        '_tlbMenu_Button3
        '
        Me._tlbMenu_Button3.AutoSize = False
        Me._tlbMenu_Button3.ImageIndex = 2
        Me._tlbMenu_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button3.Name = "_tlbMenu_Button3"
        Me._tlbMenu_Button3.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button3.ToolTipText = "再読み込み"
        '
        '_tlbMenu_Button4
        '
        Me._tlbMenu_Button4.AutoSize = False
        Me._tlbMenu_Button4.ImageIndex = 3
        Me._tlbMenu_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button4.Name = "_tlbMenu_Button4"
        Me._tlbMenu_Button4.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button4.ToolTipText = "上書き保存"
        '
        '_tlbMenu_Button5
        '
        Me._tlbMenu_Button5.AutoSize = False
        Me._tlbMenu_Button5.ImageIndex = 4
        Me._tlbMenu_Button5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button5.Name = "_tlbMenu_Button5"
        Me._tlbMenu_Button5.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button5.ToolTipText = "名前を付けて保存"
        '
        '_tlbMenu_Button6
        '
        Me._tlbMenu_Button6.AutoSize = False
        Me._tlbMenu_Button6.Name = "_tlbMenu_Button6"
        Me._tlbMenu_Button6.Size = New System.Drawing.Size(24, 22)
        '
        '_tlbMenu_Button7
        '
        Me._tlbMenu_Button7.AutoSize = False
        Me._tlbMenu_Button7.Checked = True
        Me._tlbMenu_Button7.CheckState = System.Windows.Forms.CheckState.Checked
        Me._tlbMenu_Button7.ImageIndex = 5
        Me._tlbMenu_Button7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button7.Name = "_tlbMenu_Button7"
        Me._tlbMenu_Button7.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button7.ToolTipText = "編集"
        '
        '_tlbMenu_Button8
        '
        Me._tlbMenu_Button8.AutoSize = False
        Me._tlbMenu_Button8.ImageIndex = 6
        Me._tlbMenu_Button8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button8.Name = "_tlbMenu_Button8"
        Me._tlbMenu_Button8.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button8.ToolTipText = "書込"
        '
        '_tlbMenu_Button9
        '
        Me._tlbMenu_Button9.AutoSize = False
        Me._tlbMenu_Button9.ImageIndex = 7
        Me._tlbMenu_Button9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button9.Name = "_tlbMenu_Button9"
        Me._tlbMenu_Button9.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button9.ToolTipText = "消去"
        '
        '_tlbMenu_Button10
        '
        Me._tlbMenu_Button10.AutoSize = False
        Me._tlbMenu_Button10.Name = "_tlbMenu_Button10"
        Me._tlbMenu_Button10.Size = New System.Drawing.Size(24, 22)
        '
        '_tlbMenu_Button11
        '
        Me._tlbMenu_Button11.AutoSize = False
        Me._tlbMenu_Button11.Name = "_tlbMenu_Button11"
        Me._tlbMenu_Button11.Size = New System.Drawing.Size(1395, 22)
        '
        '_tlbMenu_Button12
        '
        Me._tlbMenu_Button12.AutoSize = False
        Me._tlbMenu_Button12.ImageIndex = 8
        Me._tlbMenu_Button12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button12.Name = "_tlbMenu_Button12"
        Me._tlbMenu_Button12.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button12.ToolTipText = "最初から再生"
        '
        '_tlbMenu_Button13
        '
        Me._tlbMenu_Button13.AutoSize = False
        Me._tlbMenu_Button13.ImageIndex = 9
        Me._tlbMenu_Button13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button13.Name = "_tlbMenu_Button13"
        Me._tlbMenu_Button13.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button13.ToolTipText = "現在位置から再生"
        '
        '_tlbMenu_Button14
        '
        Me._tlbMenu_Button14.AutoSize = False
        Me._tlbMenu_Button14.ImageIndex = 10
        Me._tlbMenu_Button14.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._tlbMenu_Button14.Name = "_tlbMenu_Button14"
        Me._tlbMenu_Button14.Size = New System.Drawing.Size(24, 22)
        Me._tlbMenu_Button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me._tlbMenu_Button14.ToolTipText = "停止"
        '
        '_tlbMenu_Button15
        '
        Me._tlbMenu_Button15.AutoSize = False
        Me._tlbMenu_Button15.Name = "_tlbMenu_Button15"
        Me._tlbMenu_Button15.Size = New System.Drawing.Size(24, 22)
        '
        '_tlbMenu_Button16
        '
        Me._tlbMenu_Button16.AutoSize = False
        Me._tlbMenu_Button16.Name = "_tlbMenu_Button16"
        Me._tlbMenu_Button16.Size = New System.Drawing.Size(2955, 22)
        '
        '_tlbMenu_Button17
        '
        Me._tlbMenu_Button17.AutoSize = False
        Me._tlbMenu_Button17.Name = "_tlbMenu_Button17"
        Me._tlbMenu_Button17.Size = New System.Drawing.Size(24, 22)
        '
        '_tlbMenu_Button18
        '
        Me._tlbMenu_Button18.AutoSize = False
        Me._tlbMenu_Button18.Name = "_tlbMenu_Button18"
        Me._tlbMenu_Button18.Size = New System.Drawing.Size(2955, 22)
        '
        '_tlbMenu_Button19
        '
        Me._tlbMenu_Button19.AutoSize = False
        Me._tlbMenu_Button19.Name = "_tlbMenu_Button19"
        Me._tlbMenu_Button19.Size = New System.Drawing.Size(24, 22)
        '
        '_tlbMenu_Button20
        '
        Me._tlbMenu_Button20.AutoSize = False
        Me._tlbMenu_Button20.Name = "_tlbMenu_Button20"
        Me._tlbMenu_Button20.Size = New System.Drawing.Size(2055, 22)
        '
        'lblDirectInput
        '
        Me.lblDirectInput.AutoSize = True
        Me.lblDirectInput.BackColor = System.Drawing.SystemColors.Control
        Me.lblDirectInput.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDirectInput.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDirectInput.Location = New System.Drawing.Point(4, 482)
        Me.lblDirectInput.Name = "lblDirectInput"
        Me.lblDirectInput.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDirectInput.Size = New System.Drawing.Size(41, 12)
        Me.lblDirectInput.TabIndex = 95
        Me.lblDirectInput.Text = "Direct"
        '
        'dlgMain
        '
        Me.dlgMain.FileName = "dlgMain"
        Me.dlgMain.Filter = "BMS ﾌｧｲﾙ (*.bms,*.bme,*.bml)|*.bms;*.bme;*.bml"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1192, 530)
        Me.Controls.Add(Me.staMain)
        Me.Controls.Add(Me.picSiromaru)
        Me.Controls.Add(Me.fraResolution)
        Me.Controls.Add(Me.fraDispSize)
        Me.Controls.Add(Me.fraViewer)
        Me.Controls.Add(Me.cboDirectInput)
        Me.Controls.Add(Me.cmdDirectInput)
        Me.Controls.Add(Me.fraGrid)
        Me.Controls.Add(Me.fraHeader)
        Me.Controls.Add(Me.fraMaterial)
        Me.Controls.Add(Me.picMain)
        Me.Controls.Add(Me.hsbMain)
        Me.Controls.Add(Me.vsbMain)
        Me.Controls.Add(Me.tlbMenu)
        Me.Controls.Add(Me.lblDirectInput)
        Me.Controls.Add(Me.MainMenu1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(11, 49)
        Me.Name = "frmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "BMx Sequence Editor"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.staMain.ResumeLayout(False)
        Me.staMain.PerformLayout()
        CType(Me.picSiromaru, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraResolution.ResumeLayout(False)
        Me.fraResolution.PerformLayout()
        Me.fraDispSize.ResumeLayout(False)
        Me.fraDispSize.PerformLayout()
        Me.fraViewer.ResumeLayout(False)
        Me.fraGrid.ResumeLayout(False)
        Me.fraGrid.PerformLayout()
        Me.fraHeader.ResumeLayout(False)
        Me._fraTop_0.ResumeLayout(False)
        Me._fraTop_0.PerformLayout()
        Me._fraTop_1.ResumeLayout(False)
        Me._fraTop_1.PerformLayout()
        Me._fraTop_2.ResumeLayout(False)
        Me._fraTop_2.PerformLayout()
        Me.fraMaterial.ResumeLayout(False)
        Me._fraBottom_4.ResumeLayout(False)
        Me._fraBottom_4.PerformLayout()
        Me._fraBottom_0.ResumeLayout(False)
        Me._fraBottom_1.ResumeLayout(False)
        Me._fraBottom_2.ResumeLayout(False)
        Me._fraBottom_2.PerformLayout()
        Me._fraBottom_3.ResumeLayout(False)
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbMenu.ResumeLayout(False)
        Me.tlbMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dlgMain As OpenFileDialog
#End Region
End Class
Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module modMain
	
#Const MODE_DEBUG = True
	
	Private Const INI_VERSION As Short = 3
	
	Public Const RELEASEDATE As String = "2007-08-08T09:51"
	
	
	
#If MODE_DEBUG = True Then
	
	Public Declare Function timeBeginPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
	Public Declare Function timeEndPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
	
#End If
	
	Public Declare Function mciSendString Lib "winmm.dll"  Alias "mciSendStringA"(ByVal lpstrCommand As String, ByVal lpstrTempurnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
	Public Declare Function mciGetErrorString Lib "winmm.dll"  Alias "mciGetErrorStringA"(ByVal dwError As Integer, ByVal lpstrBuffer As String, ByVal uLength As Integer) As Integer
	
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	Private Declare Function GetPrivateProfileString Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer 'ini�t�@�C���ɓǂ݂��ނ��߂�API
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	Private Declare Function WritePrivateProfileString Lib "kernel32"  Alias "WritePrivateProfileStringA"(ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Integer 'ini�t�@�C�����������ނ��߂�API
	
	'UPGRADE_WARNING: �\���� WINDOWPLACEMENT �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Public Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As Integer, ByRef lpwndpl As WINDOWPLACEMENT) As Integer
	'UPGRADE_WARNING: �\���� WINDOWPLACEMENT �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Public Declare Function SetWindowPlacement Lib "user32" (ByVal hwnd As Integer, ByRef lpwndpl As WINDOWPLACEMENT) As Integer
	
	Public Declare Function ShellExecute Lib "shell32.dll"  Alias "ShellExecuteA"(ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
	
	Public Declare Function GetWindowLong Lib "user32"  Alias "GetWindowLongA"(ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
	'UPGRADE_WARNING: �\���� RECT �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Public Declare Function AdjustWindowRectEx Lib "user32" (ByRef lpRect As RECT, ByVal dsStyle As Integer, ByVal bMenu As Integer, ByVal dwEsStyle As Integer) As Integer
	
	Private Declare Function GetStockObject Lib "gdi32" (ByVal nIndex As Integer) As Integer
	'UPGRADE_NOTE: GetObject �� GetObject_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	Private Declare Function GetObject_Renamed Lib "gdi32"  Alias "GetObjectA"(ByVal hObject As Integer, ByVal nCount As Integer, ByRef lpObject As Any) As Integer
	'Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Long, ByVal uParam As Long, ByRef lpvParam As Any, ByVal fuWinIni As Long) As Long
	
	'Get/SetWindowPlacement�EShellExecute �֘A�̒萔
	Public Const SW_HIDE As Short = 0
	Public Const SW_MAXIMIZE As Short = 3
	Public Const SW_MINIMIZE As Short = 6
	Public Const SW_RESTORE As Short = 9
	Public Const SW_SHOW As Short = 5
	Public Const SW_SHOWDEFAULT As Short = 10
	Public Const SW_SHOWMAXIMIZED As Short = 3
	Public Const SW_SHOWMINIMIZED As Short = 2
	Public Const SW_SHOWMINNOACTIVE As Short = 7
	Public Const SW_SHOWNA As Short = 8
	Public Const SW_SHOWNOACTIVATE As Short = 4
	Public Const SW_SHOWNORMAL As Short = 1
	
	'GetWindowLong �֘A�̒萔
	Public Const GWL_STYLE As Short = -16
	Public Const GWL_EXSTYLE As Short = -20
	
	'GetStockObject �֘A�̒萔
	Private Const OEM_FIXED_FONT As Short = 10
	Private Const ANSI_FIXED_FONT As Short = 11
	Private Const ANSI_VAR_FONT As Short = 12
	Private Const SYSTEM_FONT As Short = 13
	Private Const SYSTEM_FIXED_FONT As Short = 16
	Private Const DEFAULT_GUI_FONT As Short = 17
	
	'LOGFONT �֘A�̒萔
	Private Const DEFAULT_CHARSET As Short = 1
	Private Const LF_FACESIZE As Short = 32
	
	'SystemParametersInfo �֘A�̒萔
	Private Const SPI_GETICONTITLELOGFONT As Short = 31
	Private Const SPI_GETNONCLIENTMETRICS As Short = 41
	
	Private Structure LOGFONT
		Dim lfHeight As Integer
		Dim lfWidth As Integer
		Dim lfEscapement As Integer
		Dim lfOrientation As Integer
		Dim lfWeight As Integer
		Dim lfItalic As Byte
		Dim lfUnderline As Byte
		Dim lfStrikeOut As Byte
		Dim lfCharSet As Byte
		Dim lfOutPrecision As Byte
		Dim lfClipPrecision As Byte
		Dim lfQuality As Byte
		Dim lfPitchAndFamily As Byte
		'UPGRADE_WARNING: �I�u�W�F�N�g LF_FACESIZE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		<VBFixedArray(LF_FACESIZE)> Dim lfFaceName() As Byte
		
		'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
		Public Sub Initialize()
			Dim LF_FACESIZE As Object
			'UPGRADE_WARNING: �z�� lfFaceName �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g LF_FACESIZE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ReDim lfFaceName(LF_FACESIZE)
		End Sub
	End Structure
	
	Private Structure NONCLIENTMETRICS
		Dim cbSize As Integer
		Dim iBorderWidth As Integer
		Dim iScrollWidth As Integer
		Dim iScrollHeight As Integer
		Dim iCaptionWidth As Integer
		Dim iCaptionHeight As Integer
		'UPGRADE_ISSUE: LOGFONT �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim lfCaptionFont As LOGFONT
		Dim iSMCaptionWidth As Integer
		Dim iSMCaptionHeight As Integer
		'UPGRADE_ISSUE: LOGFONT �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim lfSMCaptionFont As LOGFONT
		Dim iMenuWidth As Integer
		Dim iMenuHeight As Integer
		'UPGRADE_ISSUE: LOGFONT �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim lfMenuFont As LOGFONT
		'UPGRADE_ISSUE: LOGFONT �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim lfStatusFont As LOGFONT
		'UPGRADE_ISSUE: LOGFONT �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim lfMessageFont As LOGFONT
	End Structure
	
	Public Structure POINTAPI
		Dim X As Integer
		Dim Y As Integer
	End Structure
	
	Public Structure RECT
		'UPGRADE_NOTE: left �� left_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim left_Renamed As Integer
		Dim Top As Integer
		'UPGRADE_NOTE: right �� right_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim right_Renamed As Integer
		Dim Bottom As Integer
	End Structure
	
	Public Structure WINDOWPLACEMENT
		Dim Length As Integer
		Dim flags As Integer
		Dim showCmd As Integer
		Dim ptMinPosition As POINTAPI
		Dim ptMaxPosition As POINTAPI
		Dim rcNormalPosition As RECT
	End Structure
	
	
	
	Public Const PI As Single = 3.14159265358979
	Public Const RAD As Single = PI / 180
	
	Public Enum OBJ_SELECT
		NON_SELECT '���I��
		Selected '�I��
		EDIT_RECT '���g (�ҏW���[�h)
		DELETE_RECT '�Ԙg (�������[�h)
		SELECTAREA_IN '�I��͈͓��ɂ���I�u�W�F�A�I��
		SELECTAREA_OUT '�I��͈͂�W�J�������Ɋ��ɑI����Ԃɂ������I�u�W�F�A�I��
		SELECTAREA_SELECTED '�����I��͈͓��A�܂�I����ԂłȂ��Ȃ����I�u�W�F
	End Enum
	
	Public Enum OBJ_ATT
		OBJ_NORMAL
		OBJ_INVISIBLE
		OBJ_LONGNOTE
	End Enum
	
	Public Enum BGA_PARA
		BGA_NUM
		BGA_X1
		BGA_Y1
		BGA_X2
		BGA_Y2
		BGA_dX
		BGA_dY
	End Enum
	
	Public Enum CMD_LOG
		NONE
		OBJ_ADD
		OBJ_DEL
		OBJ_MOVE
		OBJ_CHANGE
		MSR_ADD
		MSR_DEL
		MSR_CHANGE
		WAV_CHANGE
		BMP_CHANGE
		LIST_ALIGN
		LIST_DEL
	End Enum
	
	Public g_strAppTitle As String
	
	Private Structure m_udtMouse
		Dim X As Single
		Dim Y As Single
		Dim Shift As Short
		Dim Button As Short
		Dim measure As Short
	End Structure
	
	'UPGRADE_ISSUE: m_udtMouse �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public g_Mouse As m_udtMouse
	
	Private Structure m_udtDisplay
		Dim X As Integer
		Dim Y As Integer
		Dim Width As Single
		Dim Height As Single
		Dim lngMaxX As Integer
		Dim lngMaxY As Integer
		Dim intStartMeasure As Short
		Dim intEndMeasure As Short
		Dim lngStartPos As Integer
		Dim lngEndPos As Integer
		Dim intMaxMeasure As Short '�ő�\������
		Dim intResolution As Short '����\
		Dim intEffect As Short '��ʌ���
	End Structure
	
	'UPGRADE_ISSUE: m_udtDisplay �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public g_disp As m_udtDisplay
	
	Private Structure m_udtBMS
		Dim strDir As String '�f�B���N�g��
		Dim strFileName As String 'BMS�t�@�C����
		Dim intPlayerType As Short '#PLAYER
		Dim strGenre As String '#GENRE
		Dim strTitle As String '#TITLE
		Dim strArtist As String '#ARTIST
		Dim sngBPM As Single '#BPM
		Dim lngPlayLevel As Integer '#PLAYLEVEL
		Dim intPlayRank As Short '#RANK
		Dim sngTotal As Single '#TOTAL
		Dim intVolume As Short '#VOLWAV
		Dim strStageFile As String '#STAGEFILE
		Dim blnSaveFlag As Boolean
	End Structure
	
	'UPGRADE_ISSUE: m_udtBMS �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public g_BMS As m_udtBMS
	
	Private Structure m_udtVerticalLine
		Dim blnVisible As Boolean
		Dim intCh As Short
		Dim strText As String
		Dim intWidth As Short
		Dim lngLeft As Integer
		Dim lngObjLeft As Integer
		Dim lngBackColor As Integer
		Dim intLightNum As Short
		Dim intShadowNum As Short
		Dim intBrushNum As Short
		Dim blnDraw As Boolean
	End Structure
	
	'UPGRADE_ISSUE: m_udtVerticalLine �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public g_VGrid(61) As m_udtVerticalLine
	
	Public g_intVGridNum(132 + 40) As Short
	
	Public Structure g_udtObj
		Dim lngID As Integer
		Dim intCh As Short
		Dim intAtt As OBJ_ATT
		Dim intMeasure As Short
		Dim lngHeight As Integer
		Dim lngPosition As Integer
		Dim sngValue As Single
		Dim intSelect As OBJ_SELECT
		'0�E�E�E���I��
		'1�E�E�E�I��
		'2�E�E�E���g (�ҏW���[�h)
		'3�E�E�E�Ԙg (�������[�h)
		'4�E�E�E�I��͈͓��ɂ���I�u�W�F�A�I��
		'5�E�E�E�I��͈͂�W�J�������Ɋ��ɑI����Ԃɂ������I�u�W�F�A�I��
		'6�E�E�E5�Ԃ��I��͈͓��A�܂�I����ԂłȂ��Ȃ����I�u�W�F
	End Structure
	
	Public g_Obj() As g_udtObj
	
	Public g_lngObjID() As Integer
	Public g_lngIDNum As Integer
	
	Private Structure m_udtSelectArea
		Dim blnFlag As Boolean
		Dim X1 As Single
		Dim Y1 As Single
		Dim X2 As Single
		Dim Y2 As Single
	End Structure
	
	'UPGRADE_ISSUE: m_udtSelectArea �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public g_SelectArea As m_udtSelectArea
	
	Public g_strLangFileName() As String
	Public g_strThemeFileName() As String
	Public g_strStatusBar(23) As String
	
	Public g_blnIgnoreInput As Boolean
	Public g_strAppDir As String
	Public g_strHelpFilename As String
	Public g_strFiler As String
	Public g_strRecentFiles(4) As String
	
	Public g_InputLog As New clsLog
	
	Public Structure g_udtViewer
		Dim strAppName As String
		Dim strAppPath As String
		Dim strArgAll As String
		Dim strArgPlay As String
		Dim strArgStop As String
	End Structure
	
	Public g_Viewer() As g_udtViewer
	
	Public Enum Message
		ERR_01
		ERR_02
		ERR_FILE_NOT_FOUND
		ERR_LOAD_CANCEL
		ERR_SAVE_ERROR
		ERR_SAVE_CANCEL
		ERR_OVERFLOW_LARGE
		ERR_OVERFLOW_SMALL
		ERR_OVERFLOW_BPM
		ERR_OVERFLOW_STOP
		ERR_APP_NOT_FOUND
		ERR_FILE_ALREADY_EXIST
		MSG_CONFIRM
		MSG_FILE_CHANGED
		MSG_INI_CHANGED
		MSG_ALIGN_LIST
		MSG_DELETE_FILE
		INPUT_BPM
		INPUT_STOP
		INPUT_RENAME
		INPUT_SIZE
		Max
	End Enum
	
	'UPGRADE_WARNING:  �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
	
	Public Sub StartUp()
		Dim strGet_ini As Object
		
		Dim i As Integer
		Dim strTemp As String
		Dim intTemp As Short
		Dim lngFFile As Integer
		
		If Right(My.Application.Info.DirectoryPath, 1) = "\" Then
			
			g_strAppDir = My.Application.Info.DirectoryPath
			
		Else
			
			g_strAppDir = My.Application.Info.DirectoryPath & "\"
			
		End If
		
		g_strAppTitle = "BMx Sequence Editor " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		g_strAppTitle = g_strAppTitle & " beta 14"
		
#If MODE_DEBUG = False Then
		'UPGRADE_NOTE: �� MODE_DEBUG = False �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		
		Call modMessage.SubClass(frmMain.hwnd)
		
#Else
		
		Call timeBeginPeriod(1)
		frmMain.staMain.Items.Item("Time").Visible = True
		
#End If
		
		ReDim g_strLangFileName(0)
		
		Call g_InputLog.clear()
		
		ReDim g_Viewer(1)
		
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If Dir(g_strAppDir & "bmse_viewer.ini", FileAttribute.Normal) = vbNullString Then
			
			lngFFile = FreeFile
			
			FileOpen(lngFFile, g_strAppDir & "bmse_viewer.ini", OpenMode.Output)
			
			PrintLine(lngFFile, "uBMplay")
			PrintLine(lngFFile, "uBMplay.exe")
			PrintLine(lngFFile, "-P -N0 <filename>")
			PrintLine(lngFFile, "-P -N<measure> <filename>")
			PrintLine(lngFFile, "-S")
			PrintLine(lngFFile)
			PrintLine(lngFFile, "WAview")
			PrintLine(lngFFile, "C:\Program Files\Winamp\Plugins\WAview.exe")
			PrintLine(lngFFile, "-Lbml <filename>")
			PrintLine(lngFFile, "-N<measure>")
			PrintLine(lngFFile, "-S")
			PrintLine(lngFFile)
			PrintLine(lngFFile, "nBMplay")
			PrintLine(lngFFile, "nbmplay.exe")
			PrintLine(lngFFile, "-P -N0 <filename>")
			PrintLine(lngFFile, "-P -N<measure> <filename>")
			PrintLine(lngFFile, "-S")
			PrintLine(lngFFile)
			PrintLine(lngFFile, "BMEV")
			PrintLine(lngFFile, "BMEV.exe")
			PrintLine(lngFFile, "-P -N0 <filename>")
			PrintLine(lngFFile, "-P -N<measure> <filename>")
			PrintLine(lngFFile, "-S")
			PrintLine(lngFFile)
			PrintLine(lngFFile, "BMS Viewer")
			PrintLine(lngFFile, "bmview.exe")
			PrintLine(lngFFile, "-S -P -N0 <filename>")
			PrintLine(lngFFile, "-S -P -N<measure> <filename>")
			PrintLine(lngFFile, "-S")
			
			FileClose(lngFFile)
			
		End If
		
		i = 0
		lngFFile = FreeFile
		
		FileOpen(lngFFile, g_strAppDir & "bmse_viewer.ini", OpenMode.Input)
		
		Do While Not EOF(lngFFile)
			
			strTemp = LineInput(lngFFile)
			
			Select Case i Mod 6
				
				Case 0
					
					If Len(strTemp) = 0 Then Exit Do
					g_Viewer(UBound(g_Viewer)).strAppName = strTemp
					
				Case 1
					
					If Len(strTemp) = 0 Then Exit Do
					g_Viewer(UBound(g_Viewer)).strAppPath = strTemp
					
				Case 2
					
					g_Viewer(UBound(g_Viewer)).strArgAll = strTemp
					
				Case 3
					
					g_Viewer(UBound(g_Viewer)).strArgPlay = strTemp
					
				Case 4
					
					g_Viewer(UBound(g_Viewer)).strArgStop = strTemp
					
					Call frmMain.cboViewer.Items.Add(g_Viewer(UBound(g_Viewer)).strAppName)
					ReDim Preserve g_Viewer(UBound(g_Viewer) + 1)
					
			End Select
			
			i = i + 1
			
		Loop 
		
		FileClose(lngFFile)
		
		ReDim Preserve g_Viewer(frmMain.cboViewer.Items.Count)
		
		'�����Q�[�W�t�@�C���ǂݍ���
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		strTemp = Dir(g_strAppDir & "lang\*.ini")
		intTemp = 0
		
		Do While strTemp <> ""
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Main, Key, , lang\ & strTemp) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If strGet_ini("Main", "Key", "", "lang\" & strTemp) = "BMSE" Then
				
				intTemp = intTemp + 1
				
				ReDim Preserve g_strLangFileName(intTemp)
				
				g_strLangFileName(intTemp) = strTemp
				
				Call frmMain.mnuLanguage.Load(intTemp)
				
				With frmMain.mnuLanguage(intTemp)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Main, Language, strTemp, lang\ & strTemp) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = "&" & strGet_ini("Main", "Language", strTemp, "lang\" & strTemp)
					
					If .Text = "&" Then .Text = "&" & strTemp
					
					.Visible = True
					
				End With
				
			End If
			
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			strTemp = Dir()
			
		Loop 
		
		If intTemp Then
			
			frmMain.mnuLanguage(0).Visible = False
			
		Else
			
			frmMain.mnuLanguageParent.Enabled = False
			
		End If
		
		'�e�[�}�t�@�C���ǂݍ���
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		strTemp = Dir(g_strAppDir & "theme\*.ini")
		intTemp = 0
		
		Do While strTemp <> ""
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Main, Key, , theme\ & strTemp) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If strGet_ini("Main", "Key", "", "theme\" & strTemp) = "BMSE" Then
				
				intTemp = intTemp + 1
				
				ReDim Preserve g_strThemeFileName(intTemp)
				
				g_strThemeFileName(intTemp) = strTemp
				
				frmMain.mnuTheme.Load(intTemp)
				
				With frmMain.mnuTheme(intTemp)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Main, Name, strTemp, theme\ & strTemp) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Text = "&" & strGet_ini("Main", "Name", strTemp, "theme\" & strTemp)
					
					If .Text = "&" Then .Text = "&" & strTemp
					
					.Visible = True
					
				End With
				
			End If
			
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			strTemp = Dir()
			
		Loop 
		
		If intTemp Then
			
			frmMain.mnuTheme(0).Visible = False
			
		Else
			
			frmMain.mnuThemeParent.Enabled = False
			
		End If
		
		For i = 1 To frmMain.MENU_OPTIONS.Max - 1
			
			Call frmMain.mnuOptionsItem.Load(i)
			
		Next i
		
		For i = 1 To frmMain.MENU_VIEW.Max - 1
			
			Call frmMain.mnuViewItem.Load(i)
			
		Next i
		
		'������
		With g_BMS
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.intPlayerType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.intPlayerType = modInput.PLAYER_TYPE.PLAYER_1P
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strGenre �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.strGenre = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strTitle �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.strTitle = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strArtist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.strArtist = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.sngBPM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.sngBPM = Val(frmMain.txtBPM.Text)
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.lngPlayLevel �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lngPlayLevel = 1
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.intPlayRank �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.intPlayRank = modInput.PLAY_RANK.RANK_EASY
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.sngTotal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.sngTotal = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.intVolume �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.intVolume = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.blnSaveFlag = True
			
		End With
		
		ReDim g_Obj(0)
		ReDim g_lngObjID(0)
		g_lngIDNum = 0
		
		For i = 0 To 256 + 64
			
			g_sngSin(i) = System.Math.Sin(i * PI / 128)
			
		Next i
		
		For i = 0 To UBound(g_VGrid)
			
			With g_VGrid(i)
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(i).intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Choose() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.intCh = Choose(i + 1, 0, 8, 9, 0, 21, 16, 11, 12, 13, 14, 15, 18, 19, 16, 0, 26, 21, 22, 23, 24, 25, 28, 29, 26, 0, 4, 7, 6, 0, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 0)
				'If .intCh Then g_intVGridNum(.intCh) = i
				'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().blnVisible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.blnVisible = True
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(i).intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Select Case .intCh
					
					Case modInput.OBJ_CH.CH_BPM, modInput.OBJ_CH.CH_EXBPM, modInput.OBJ_CH.CH_STOP 'BPM/STOP
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.BPM_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.BPM_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.BPM
						
					Case modInput.OBJ_CH.CH_BGA, modInput.OBJ_CH.CH_LAYER, modInput.OBJ_CH.CH_POOR 'BGA/Layer/Poor
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.BGA_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.BGA_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.BGA
						
					Case 11
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY01_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY01_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY01
						
					Case 12
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY02_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY02_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY02
						
					Case 13
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY03_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY03_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY03
						
					Case 14
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY04_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY04_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY04
						
					Case 15
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY05_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY05_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY05
						
					Case 18
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY06_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY06_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY06
						
					Case 19
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY07_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY07_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY07
						
					Case 16
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY08_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY08_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY08
						
					Case 21
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY11_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY11_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY11
						
					Case 22
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY12_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY12_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY12
						
					Case 23
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY13_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY13_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY13
						
					Case 24
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY14_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY14_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY14
						
					Case 25
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY15_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY15_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY15
						
					Case 28
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY16_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY16_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY16
						
					Case 29
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY17_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY17_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY17
						
					Case 26
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.KEY18_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.KEY18_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.KEY18
						
					Case Is > 100 'BGM
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intLightNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intLightNum = modDraw.PEN_NUM.BGM_LIGHT
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intShadowNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intShadowNum = modDraw.PEN_NUM.BGM_SHADOW
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intBrushNum �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intBrushNum = modDraw.BRUSH_NUM.BGM
						
				End Select
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(i).intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If .intCh Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intWidth �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.intWidth = GRID_WIDTH
					
				Else
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intWidth �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.intWidth = SPACE_WIDTH
					
				End If
				
			End With
			
		Next i
		
		'g_Disp.intMaxMeasure = 31
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intMaxMeasure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_disp.intMaxMeasure = 0
		Call modDraw.lngChangeMaxMeasure(15)
		Call modDraw.ChangeResolution()
		
	End Sub
	
	Public Sub CleanUp(Optional ByVal lngErrNum As Integer = 0, Optional ByRef strErrDescription As String = "", Optional ByRef strErrProcedure As String = "")
		Dim DebugOutput As Object
		Dim lngDeleteFile As Object
		Dim SaveConfig As Object
		On Error Resume Next
		
		Dim i As Integer
		
#If MODE_DEBUG = False Then
		'UPGRADE_NOTE: �� MODE_DEBUG = False �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		
		Call modMessage.UnSubClass(frmMain.hwnd)
		
#Else
		
		Call timeEndPeriod(1)
		
#End If
		
		'UPGRADE_NOTE: �I�u�W�F�N�g g_InputLog ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		g_InputLog = Nothing
		
		Call modEasterEgg.EndEffect()
		
		Call SaveConfig()
		
		Call mciSendString("close PREVIEW", vbNullString, 0, 0)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")
		Call lngDeleteFile(g_strAppDir & "___bmse_temp.bms")
		
		If lngErrNum <> 0 And strErrDescription <> "" And strErrProcedure <> "" Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Len(g_BMS.strDir) = 0 Then g_BMS.strDir = g_strAppDir
			
			For i = 0 To 9999
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				g_BMS.strFileName = "temp" & VB6.Format(i, "0000") & ".bms"
				
				If i = 9999 Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call CreateBMS(g_BMS.strDir & g_BMS.strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				ElseIf Dir(g_BMS.strDir & g_BMS.strFileName) = vbNullString Then 
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call CreateBMS(g_BMS.strDir & g_BMS.strFileName)
					Exit For
					
				End If
				
			Next i
			
			Call DebugOutput(lngErrNum, strErrDescription, strErrProcedure, True)
			
		End If
		
		End
		
	End Sub
	
	Public Sub DebugOutput(ByVal lngErrNum As Integer, ByRef strErrDescription As String, ByRef strErrProcedure As String, Optional ByVal blnCleanUp As Boolean = False)
		Dim g_Message As Object
		
		Dim lngFFile As Integer
		Dim strError As String
		
		lngFFile = FreeFile
		
		FileOpen(lngFFile, g_strAppDir & "error.txt", OpenMode.Append)
		
		PrintLine(lngFFile, Today & TimeOfDay & "ErrorNo." & lngErrNum & " " & strErrDescription & "@" & strErrProcedure & "/BMSE_" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision)
		
		FileClose(lngFFile)
		
		strError = strError & "ErrorNo." & lngErrNum & " " & strErrDescription & "@" & strErrProcedure
		
		If blnCleanUp Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strError = g_Message(modMain.Message.ERR_01) & vbCrLf & strError & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strError = strError & g_Message(modMain.Message.ERR_02) & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strError = strError & g_BMS.strDir & g_BMS.strFileName
			
		End If
		
		Call frmMain.Show()
		Call MsgBox(strError, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, g_strAppTitle)
		
	End Sub
	
	Public Function lngDeleteFile(ByRef FileName As String) As Integer
		On Error GoTo Err_Renamed
		
		Kill(FileName)
		
		Exit Function
		
Err_Renamed: 
		lngDeleteFile = 1
	End Function
	
	Public Function intSaveCheck() As Short
		Dim RecentFilesRotation As Object
		Dim g_Message As Object
		On Error GoTo Err_Renamed
		
		Dim lngTemp As Integer
		Dim strArray() As String
		
		With frmMain
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.intPlayerType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .cboPlayer.SelectedIndex + 1 <> g_BMS.intPlayerType Then g_BMS.blnSaveFlag = False
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strGenre �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .txtGenre.Text <> g_BMS.strGenre Then g_BMS.blnSaveFlag = False
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strTitle �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .txtTitle.Text <> g_BMS.strTitle Then g_BMS.blnSaveFlag = False
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strArtist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .txtArtist.Text <> g_BMS.strArtist Then g_BMS.blnSaveFlag = False
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.lngPlayLevel �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Val(.cboPlayLevel.Text) <> g_BMS.lngPlayLevel Then g_BMS.blnSaveFlag = False
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.sngBPM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Val(.txtBPM.Text) <> g_BMS.sngBPM Then g_BMS.blnSaveFlag = False
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.intPlayRank �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .cboPlayRank.SelectedIndex <> g_BMS.intPlayRank Then g_BMS.blnSaveFlag = False
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.sngTotal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Val(.txtTotal.Text) <> g_BMS.sngTotal Then g_BMS.blnSaveFlag = False
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.intVolume �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Val(.txtVolume.Text) <> g_BMS.intVolume Then g_BMS.blnSaveFlag = False
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strStageFile �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .txtStageFile.Text <> g_BMS.strStageFile Then g_BMS.blnSaveFlag = False
			'If .txtMissBMP.Text <> g_strBMP(0) Then g_BMS.blnSaveFlag = False
			
		End With
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If g_BMS.blnSaveFlag Then
			
			intSaveCheck = 0
			
			Exit Function
			
		End If
		
		Call frmMain.Show()
		
		lngTemp = MsgBox(g_Message(modMain.Message.MSG_FILE_CHANGED), MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel, g_strAppTitle)
		
		Select Case lngTemp
			
			Case MsgBoxResult.Yes
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If g_BMS.strDir <> "" And g_BMS.strFileName <> "" Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call CreateBMS(g_BMS.strDir & g_BMS.strFileName)
					
				Else
					
					'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
					With frmMain.dlgMain
						
						'UPGRADE_WARNING: Filter �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
						.Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.FileName = g_BMS.strFileName
						
						Call .ShowDialog()
						
						strArray = Split(.FileName, "\")
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_BMS.strDir = Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_BMS.strFileName = strArray(UBound(strArray))
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call CreateBMS(g_BMS.strDir & g_BMS.strFileName)
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.InitialDirectory = g_BMS.strDir
						
					End With
					
				End If
				
			Case MsgBoxResult.No
				
				intSaveCheck = 0
				
			Case MsgBoxResult.Cancel
				
				intSaveCheck = 1
				
		End Select
		
		Exit Function
		
Err_Renamed: 
		
		intSaveCheck = 1
		
	End Function
	
	Public Sub RecentFilesRotation(ByRef strFilePath As String)
		Dim SubRotate As Object
		
		Dim i As Integer
		Dim intTemp As Short
		
		For i = 0 To UBound(g_strRecentFiles)
			
			If g_strRecentFiles(i) = strFilePath Then
				
				Call SubRotate(0, i, strFilePath)
				
				intTemp = 1
				
				Exit For
				
			End If
			
		Next i
		
		If intTemp = 0 Then Call SubRotate(0, UBound(g_strRecentFiles), strFilePath)
		
		frmMain.mnuLineRecent.Visible = True
		
	End Sub
	
	Private Sub SubRotate(ByVal intIndex As Short, ByVal intEnd As Short, ByRef strFilePath As String)
		Dim SubRotate As Object
		
		If intIndex <> intEnd And g_strRecentFiles(intIndex) <> "" And intIndex <= UBound(g_strRecentFiles) Then
			
			Call SubRotate(intIndex + 1, intEnd, g_strRecentFiles(intIndex))
			
		End If
		
		g_strRecentFiles(intIndex) = strFilePath
		
		With frmMain.mnuRecentFiles(intIndex)
			
			.Text = "&" & intIndex + 1 & ":" & strFilePath
			.Enabled = True
			.Visible = True
			
		End With
		
		'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �R���N�V���� frmMain.tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
		With frmMain.tlbMenu.Items.Item("Open").ButtonMenus.Item(intIndex + 1)
			
			'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �R���N�V���� frmMain.tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
			.Text = "&" & intIndex + 1 & ":" & strFilePath
			'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �R���N�V���� frmMain.tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
			.Enabled = True
			'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �R���N�V���� frmMain.tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
			.Visible = True
			
		End With
		
	End Sub
	
	Public Sub GetCmdLine()
		Dim modMain As Object
		Dim RecentFilesRotation As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim strTemp As String
		Dim strCmdArray() As String
		Dim strArray() As String
		Dim ReadLock As Boolean
		Dim blnReadFlag As Boolean
		
		strTemp = Trim(VB.Command())
		
		If strTemp = "" Then Exit Sub
		
		ReDim strCmdArray(0)
		
		For i = 1 To Len(strTemp)
			
			Select Case Asc(Mid(strTemp, i, 1))
				
				Case 32 '�X�y�[�X
					
					If ReadLock = False Then
						
						ReDim Preserve strCmdArray(UBound(strCmdArray) + 1)
						
					Else
						
						strCmdArray(UBound(strCmdArray)) = strCmdArray(UBound(strCmdArray)) & " "
						
					End If
					
				Case 34 '�_�u���N�I�[�e�[�V����
					
					ReadLock = Not ReadLock
					
				Case Else
					
					strCmdArray(UBound(strCmdArray)) = strCmdArray(UBound(strCmdArray)) & Mid(strTemp, i, 1)
					
			End Select
			
		Next i
		
		For i = 0 To UBound(strCmdArray)
			
			If strCmdArray(i) <> "" Then
				
				If InStr(1, strCmdArray(i), ":\") <> 0 And (UCase(Right(strCmdArray(i), 4)) = ".BMS" Or UCase(Right(strCmdArray(i), 4)) = ".BME" Or UCase(Right(strCmdArray(i), 4)) = ".BML" Or UCase(Right(strCmdArray(i), 4)) = ".PMS") Then
					
					If blnReadFlag Then
						
						'UPGRADE_WARNING: App �v���p�e�B App.EXEName �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
						Call ShellExecute(0, "open", Chr(34) & g_strAppDir & My.Application.Info.AssemblyName & Chr(34), Chr(34) & strCmdArray(i) & Chr(34), "", SW_SHOWNORMAL)
						
					Else
						
						strArray = Split(strCmdArray(i), "\")
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_BMS.strFileName = Right(strCmdArray(i), Len(strArray(UBound(strArray))))
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_BMS.strDir = Left(strCmdArray(i), Len(strCmdArray(i)) - Len(strArray(UBound(strArray))))
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						frmMain.dlgMainSave.InitialDirectory = g_BMS.strDir
						blnReadFlag = True
						
						Call modInput.LoadBMS()
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)
						
					End If
					
				End If
				
			End If
			
		Next i
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "GetCmdLine")
	End Sub
	
	Public Sub LoadThemeFile(ByRef strFileName As String)
		Dim HalfColor As Object
		Dim strGet_ini As Object
		Dim GetColor As Object
		
		Dim strArray() As String
		Dim i As Integer
		Dim j As Integer
		Dim Color As Integer
		Dim lngTemp As Integer
		
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		frmMain.picMain.BackColor = System.Drawing.ColorTranslator.FromOle(GetColor("Main", "Background", "0,0,0", strFileName))
		
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_lngSystemColor(modDraw.COLOR_NUM.MEASURE_NUM) = GetColor("Main", "MeasureNum", "64,64,64", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_lngSystemColor(modDraw.COLOR_NUM.MEASURE_LINE) = GetColor("Main", "MeasureLine", "255,255,255", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_lngSystemColor(modDraw.COLOR_NUM.GRID_MAIN) = GetColor("Main", "GridMain", "96,96,96", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_lngSystemColor(modDraw.COLOR_NUM.GRID_SUB) = GetColor("Main", "GridSub", "192,192,192", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_lngSystemColor(modDraw.COLOR_NUM.VERTICAL_MAIN) = GetColor("Main", "VerticalMain", "255,255,255", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_lngSystemColor(modDraw.COLOR_NUM.VERTICAL_SUB) = GetColor("Main", "VerticalSub", "128,128,128", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_lngSystemColor(modDraw.COLOR_NUM.INFO) = GetColor("Main", "Info", "0,255,0", strFileName)
		
		
		For i = 0 To modDraw.BRUSH_NUM.Max - 1
			
			Select Case i
				
				Case modDraw.BRUSH_NUM.BGM
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("BGM", "Background", "48,0,0", strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strArray = Split(strGet_ini("BGM", "Text", "B01,B02,B03,B04,B05,B06,B07,B08,B09,B10,B11,B12,B13,B14,B15,B16,B17,B18,B19,B20,B21,B22,B23,B24,B25,B26,B27,B28,B29,B30,B31,B32", strFileName), ",")
					
					For j = 0 To 31
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_VGrid(modDraw.GRID.NUM_BGM + j).strText = strArray(j)
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_VGrid(modDraw.GRID.NUM_BGM + j).lngBackColor = Color
						
					Next j
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.BGM_LIGHT) = GetColor("BGM", "ObjectLight", "255,0,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.BGM_SHADOW) = GetColor("BGM", "ObjectShadow", "96,0,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.BGM) = GetColor("BGM", "ObjectColor", "128,0,0", strFileName)
					
				Case modDraw.BRUSH_NUM.BPM
					
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strArray = Split(strGet_ini("BPM", "Text", "BPM,STOP", strFileName), ",")
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_BPM).strText = strArray(0)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_STOP).strText = strArray(1)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("BPM", "Background", "48,48,48", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_BPM).lngBackColor = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_STOP).lngBackColor = Color
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.BPM_LIGHT) = GetColor("BPM", "ObjectLight", "192,192,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.BPM_SHADOW) = GetColor("BPM", "ObjectShadow", "128,128,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.BPM) = GetColor("BPM", "ObjectColor", "160,160,0", strFileName)
					
				Case modDraw.BRUSH_NUM.BGA
					
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strArray = Split(strGet_ini("BGA", "Text", "BGA,LAYER,POOR", strFileName), ",")
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_BGA).strText = strArray(0)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_LAYER).strText = strArray(1)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_POOR).strText = strArray(2)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("BGA", "Background", "0,24,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_BGA).lngBackColor = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_LAYER).lngBackColor = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_POOR).lngBackColor = Color
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.BGA_LIGHT) = GetColor("BGA", "ObjectLight", "0,255,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.BGA_SHADOW) = GetColor("BGA", "ObjectShadow", "0,96,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.BGA) = GetColor("BGA", "ObjectColor", "0,128,0", strFileName)
					
				Case modDraw.BRUSH_NUM.KEY01, modDraw.BRUSH_NUM.KEY03, modDraw.BRUSH_NUM.KEY05, modDraw.BRUSH_NUM.KEY07
					
					lngTemp = (i - modDraw.BRUSH_NUM.KEY01) + 1
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_1P_1KEY + lngTemp - 1).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_1P_1KEY + lngTemp - 1).strText = strGet_ini("KEY_1P_0" & lngTemp, "Text", lngTemp, strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_1P_1KEY + lngTemp - 1).lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_1P_1KEY + lngTemp - 1).lngBackColor = GetColor("KEY_1P_0" & lngTemp, "Background", "32,32,32", strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_0" & lngTemp, "ObjectLight", "192,192,192", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY01_LIGHT + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY01_LIGHT + lngTemp - 1) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_0" & lngTemp, "ObjectShadow", "96,96,96", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY01_SHADOW + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY01_SHADOW + lngTemp - 1) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_0" & lngTemp, "ObjectColor", "128,128,128", strFileName)
					g_lngBrushColor(modDraw.BRUSH_NUM.KEY01 + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.INV_KEY01 + lngTemp - 1) = HalfColor(Color)
					
				Case modDraw.BRUSH_NUM.KEY02, modDraw.BRUSH_NUM.KEY04, modDraw.BRUSH_NUM.KEY06
					
					lngTemp = (i - modDraw.BRUSH_NUM.KEY01) + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_1P_1KEY + lngTemp - 1).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_1P_1KEY + lngTemp - 1).strText = strGet_ini("KEY_1P_0" & lngTemp, "Text", lngTemp, strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_1P_1KEY + lngTemp - 1).lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_1P_1KEY + lngTemp - 1).lngBackColor = GetColor("KEY_1P_0" & lngTemp, "Background", "0,0,40", strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_0" & lngTemp, "ObjectLight", "96,96,255", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY01_LIGHT + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY01_LIGHT + lngTemp - 1) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_0" & lngTemp, "ObjectShadow", "0,0,128", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY01_SHADOW + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY01_SHADOW + lngTemp - 1) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_0" & lngTemp, "ObjectColor", "0,0,255", strFileName)
					g_lngBrushColor(modDraw.BRUSH_NUM.KEY01 + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.INV_KEY01 + lngTemp - 1) = HalfColor(Color)
					
				Case modDraw.BRUSH_NUM.KEY08
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_1P_SC_L).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_1P_SC_L).strText = strGet_ini("KEY_1P_SC", "Text", "SC", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_1P_SC_R).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_1P_SC_R).strText = strGet_ini("KEY_1P_SC", "Text", "SC", strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_SC", "Background", "48,0,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_1P_SC_L).lngBackColor = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_1P_SC_R).lngBackColor = Color
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_SC", "ObjectLight", "255,96,96", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY08_LIGHT) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY08_LIGHT) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_SC", "ObjectShadow", "128,0,0", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY08_SHADOW) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY08_SHADOW) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_1P_SC", "ObjectColor", "255,0,0", strFileName)
					g_lngBrushColor(modDraw.BRUSH_NUM.KEY08) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.INV_KEY08) = HalfColor(Color)
					
				Case modDraw.BRUSH_NUM.KEY11, modDraw.BRUSH_NUM.KEY13, modDraw.BRUSH_NUM.KEY15, modDraw.BRUSH_NUM.KEY17
					
					lngTemp = (i - modDraw.BRUSH_NUM.KEY11) + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_2P_1KEY + lngTemp - 1).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_2P_1KEY + lngTemp - 1).strText = strGet_ini("KEY_2P_0" & lngTemp, "Text", lngTemp, strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_2P_1KEY + lngTemp - 1).lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_2P_1KEY + lngTemp - 1).lngBackColor = GetColor("KEY_2P_0" & lngTemp, "Background", "32,32,32", strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_0" & lngTemp, "ObjectLight", "192,192,192", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY11_LIGHT + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY11_LIGHT + lngTemp - 1) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_0" & lngTemp, "ObjectShadow", "96,96,96", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY11_SHADOW + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY11_SHADOW + lngTemp - 1) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_0" & lngTemp, "ObjectColor", "128,128,128", strFileName)
					g_lngBrushColor(modDraw.BRUSH_NUM.KEY11 + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.INV_KEY11 + lngTemp - 1) = HalfColor(Color)
					
					If i = modDraw.BRUSH_NUM.KEY11 Then
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_FOOTPEDAL).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_VGrid(modDraw.GRID.NUM_FOOTPEDAL).strText = strGet_ini("KEY_2P_01", "Text", lngTemp, strFileName)
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_FOOTPEDAL).lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_VGrid(modDraw.GRID.NUM_FOOTPEDAL).lngBackColor = GetColor("KEY_2P_01", "Background", "32,32,32", strFileName)
						'color = GetColor("KEY_2P_0" & lngTemp, "ObjectLight", "192,192,192", strFileName)
						
					End If
					
				Case modDraw.BRUSH_NUM.KEY12, modDraw.BRUSH_NUM.KEY14, modDraw.BRUSH_NUM.KEY16
					
					lngTemp = (i - modDraw.BRUSH_NUM.KEY11) + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_2P_1KEY + lngTemp - 1).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_2P_1KEY + lngTemp - 1).strText = strGet_ini("KEY_2P_0" & lngTemp, "Text", lngTemp, strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_2P_1KEY + lngTemp - 1).lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_2P_1KEY + lngTemp - 1).lngBackColor = GetColor("KEY_2P_0" & lngTemp, "Background", "0,0,40", strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_0" & lngTemp, "ObjectLight", "96,96,255", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY11_LIGHT + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY11_LIGHT + lngTemp - 1) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_0" & lngTemp, "ObjectShadow", "0,0,128", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY11_SHADOW + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY11_SHADOW + lngTemp - 1) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_0" & lngTemp, "ObjectColor", "0,0,255", strFileName)
					g_lngBrushColor(modDraw.BRUSH_NUM.KEY11 + lngTemp - 1) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.INV_KEY11 + lngTemp - 1) = HalfColor(Color)
					
				Case modDraw.BRUSH_NUM.KEY18
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_2P_SC_L).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_2P_SC_L).strText = strGet_ini("KEY_2P_SC", "Text", "SC", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(GRID.NUM_2P_SC_R).strText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_2P_SC_R).strText = strGet_ini("KEY_2P_SC", "Text", "SC", strFileName)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_SC", "Background", "48,0,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_2P_SC_L).lngBackColor = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().lngBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_VGrid(modDraw.GRID.NUM_2P_SC_R).lngBackColor = Color
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_SC", "ObjectLight", "255,96,96", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY18_LIGHT) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY18_LIGHT) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_SC", "ObjectShadow", "128,0,0", strFileName)
					g_lngPenColor(modDraw.PEN_NUM.KEY18_SHADOW) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.INV_KEY18_SHADOW) = HalfColor(Color)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Color = GetColor("KEY_2P_SC", "ObjectColor", "255,0,0", strFileName)
					g_lngBrushColor(modDraw.BRUSH_NUM.KEY18) = Color
					'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.INV_KEY18) = HalfColor(Color)
					
				Case modDraw.BRUSH_NUM.LONGNOTE
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.LONGNOTE_LIGHT) = GetColor("KEY_LONGNOTE", "ObjectLight", "0,128,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.LONGNOTE_SHADOW) = GetColor("KEY_LONGNOTE", "ObjectShadow", "0,32,0", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.LONGNOTE) = GetColor("KEY_LONGNOTE", "ObjectColor", "0,64,0", strFileName)
					
				Case modDraw.BRUSH_NUM.SELECT_OBJ
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.SELECT_OBJ_LIGHT) = GetColor("SELECT", "ObjectLight", "255,255,255", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.SELECT_OBJ_SHADOW) = GetColor("SELECT", "ObjectShadow", "128,128,128", strFileName)
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngBrushColor(modDraw.BRUSH_NUM.SELECT_OBJ) = GetColor("SELECT", "ObjectColor", "0,255,255", strFileName)
					
				Case modDraw.BRUSH_NUM.EDIT_FRAME
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.EDIT_FRAME) = GetColor("SELECT", "EditFrame", "255,255,255", strFileName)
					
				Case modDraw.BRUSH_NUM.DELETE_FRAME
					
					'UPGRADE_WARNING: �I�u�W�F�N�g GetColor() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_lngPenColor(modDraw.PEN_NUM.DELETE_FRAME) = GetColor("SELECT", "DeleteFrame", "255,255,255", strFileName)
					
			End Select
			
		Next i
		
	End Sub
	
	Public Sub LoadLanguageFile(ByRef strFileName As String)
		Dim DEFAULT_CHARSET As Object
		Dim LoadFont As Object
		Dim DEFAULT_GUI_FONT As Object
		Dim GetStockObject As Object
		Dim g_Message As Object
		Dim strGet_ini As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(1) = strGet_ini("StatusBar", "CH_01", "BGM", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(4) = strGet_ini("StatusBar", "CH_04", "BGA", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(6) = strGet_ini("StatusBar", "CH_06", "BGA Poor", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(7) = strGet_ini("StatusBar", "CH_07", "BGA Layer", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(8) = strGet_ini("StatusBar", "CH_08", "BPM Change", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(9) = strGet_ini("StatusBar", "CH_09", "Stop Sequence", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(11) = strGet_ini("StatusBar", "CH_KEY_1P", "1P Key", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(12) = strGet_ini("StatusBar", "CH_KEY_2P", "2P Key", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(13) = strGet_ini("StatusBar", "CH_SCRATCH_1P", "1P Scratch", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(14) = strGet_ini("StatusBar", "CH_SCRATCH_2P", "2P Scratch", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(15) = strGet_ini("StatusBar", "CH_INVISIBLE", "(Invisible)", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(16) = strGet_ini("StatusBar", "CH_LONGNOTE", "(LongNote)", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(20) = strGet_ini("StatusBar", "MODE_EDIT", "Edit Mode", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(21) = strGet_ini("StatusBar", "MODE_WRITE", "Write Mode", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(22) = strGet_ini("StatusBar", "MODE_DELETE", "Delete Mode", strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_strStatusBar(23) = strGet_ini("StatusBar", "MEASURE", "Measure", strFileName)
		
		With frmMain
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuFile.Text = strGet_ini("Menu", "FILE", "&File", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuFileNew.Text = strGet_ini("Menu", "FILE_NEW", "&New", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuFileOpen.Text = strGet_ini("Menu", "FILE_OPEN", "&Open", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuFileSave.Text = strGet_ini("Menu", "FILE_SAVE", "&Save", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuFileSaveAs.Text = strGet_ini("Menu", "FILE_SAVE_AS", "Save &As", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuFileOpenDirectory.Text = strGet_ini("Menu", "FILE_OPEN_DIRECTORY", "Open &Directory", strFileName)
			'.mnuFileDeleteUnusedFile.Caption = strGet_ini("Menu", "FILE_DELETE_UNUSED_FILE", "&Delete Unused File(s)", strFileName)
			'.mnuFileNameConvert.Caption = strGet_ini("Menu", "FILE_CONVERT_FILENAME", "&Convert Filenames to [01-ZZ]", strFileName)
			'.mnuFileListAlign.Caption = strGet_ini("Menu", "FILE_ALIGN_LIST", "Rewrite &List into old format [01-FF]", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuFileConvertWizard.Text = strGet_ini("Menu", "FILE_CONVERT_WIZARD", "Show &Conversion Wizard", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuFileExit.Text = strGet_ini("Menu", "FILE_EXIT", "&Exit", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEdit.Text = strGet_ini("Menu", "EDIT", "&Edit", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditUndo.Text = strGet_ini("Menu", "EDIT_UNDO", "&Undo", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditRedo.Text = strGet_ini("Menu", "EDIT_REDO", "&Redo", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditCut.Text = strGet_ini("Menu", "EDIT_CUT", "Cu&t", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditCopy.Text = strGet_ini("Menu", "EDIT_COPY", "&Copy", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditPaste.Text = strGet_ini("Menu", "EDIT_PASTE", "&Paste", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditDelete.Text = strGet_ini("Menu", "EDIT_DELETE", "&Delete", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditSelectAll.Text = strGet_ini("Menu", "EDIT_SELECT_ALL", "&Find/Replace/Delete", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditFind.Text = strGet_ini("Menu", "EDIT_FIND", "&Select All", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, EDIT_MODE_EDIT, Edit &Mode, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditMode(0).Text = strGet_ini("Menu", "EDIT_MODE_EDIT", "Edit &Mode", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, EDIT_MODE_WRITE, Write &Mode, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditMode(1).Text = strGet_ini("Menu", "EDIT_MODE_WRITE", "Write &Mode", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, EDIT_MODE_DELETE, Delete &Mode, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuEditMode(2).Text = strGet_ini("Menu", "EDIT_MODE_DELETE", "Delete &Mode", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuView.Text = strGet_ini("Menu", "VIEW", "&View", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, VIEW_TOOL_BAR, &Tool Bar, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuViewItem(frmMain.MENU_VIEW.TOOL_BAR).Text = strGet_ini("Menu", "VIEW_TOOL_BAR", "&Tool Bar", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, VIEW_DIRECT_INPUT, &Direct Input, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuViewItem(frmMain.MENU_VIEW.DIRECT_INPUT).Text = strGet_ini("Menu", "VIEW_DIRECT_INPUT", "&Direct Input", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, VIEW_STATUS_BAR, &Status Bar, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuViewItem(frmMain.MENU_VIEW.STATUS_BAR).Text = strGet_ini("Menu", "VIEW_STATUS_BAR", "&Status Bar", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptions.Text = strGet_ini("Menu", "OPTIONS", "&Options", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, OPTIONS_IGNORE_ACTIVE, &Control Unavailable When Active, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.IGNORE_INPUT).Text = strGet_ini("Menu", "OPTIONS_IGNORE_ACTIVE", "&Control Unavailable When Active", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, OPTIONS_FILE_NAME_ONLY, Display &File Name Only, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.TITLE_FILENAME).Text = strGet_ini("Menu", "OPTIONS_FILE_NAME_ONLY", "Display &File Name Only", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, OPTIONS_VERTICAL, &Vertical Grid Info, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.VERTICAL_INFO).Text = strGet_ini("Menu", "OPTIONS_VERTICAL", "&Vertical Grid Info", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, OPTIONS_LANE_BG, &Background Color, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.LANE_BGCOLOR).Text = strGet_ini("Menu", "OPTIONS_LANE_BG", "&Background Color", strFileName)
			'.mnuOptionsItem(SELECT_PREVIEW).Caption = strGet_ini("Menu", "OPTIONS_SINGLE_SELECT_SOUND", "&Sound Upon Object Selection", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, OPTIONS_SINGLE_SELECT_PREVIEW, &Preview Upon Object Selection, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.SELECT_PREVIEW).Text = strGet_ini("Menu", "OPTIONS_SINGLE_SELECT_PREVIEW", "&Preview Upon Object Selection", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, OPTIONS_OBJECT_FILE_NAME, Show &Objects' File Names, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.OBJ_FILENAME).Text = strGet_ini("Menu", "OPTIONS_OBJECT_FILE_NAME", "Show &Objects' File Names", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, OPTIONS_MOVE_ON_GRID, Restrict Objects' &Movement Onto Grid, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.MOVE_ON_GRID).Text = strGet_ini("Menu", "OPTIONS_MOVE_ON_GRID", "Restrict Objects' &Movement Onto Grid", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Menu, OPTIONS_USE_OLD_FORMAT, &Use Old Format (01-FF), strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.USE_OLD_FORMAT).Text = strGet_ini("Menu", "OPTIONS_USE_OLD_FORMAT", "&Use Old Format (01-FF)", strFileName)
			'.mnuOptionsItem(RCLICK_DELETE).Caption = strGet_ini("Menu", "OPTIONS_RIGHT_CLICK_DELETE", "&Right Click To Delete Objects", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuTools.Text = strGet_ini("Menu", "TOOLS", "&Tools", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuToolsPlayAll.Text = strGet_ini("Menu", "TOOLS_PLAY_FIRST", "Play &All", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuToolsPlay.Text = strGet_ini("Menu", "TOOLS_PLAY", "&Play From Current Position", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuToolsPlayStop.Text = strGet_ini("Menu", "TOOLS_STOP", "&Stop", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuToolsSetting.Text = strGet_ini("Menu", "TOOLS_SETTING", "&Viewer Setting", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuHelp.Text = strGet_ini("Menu", "HELP", "&Help", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuHelpOpen.Text = strGet_ini("Menu", "HELP_OPEN", "&Help", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuHelpWeb.Text = strGet_ini("Menu", "HELP_WEB", "Open &Website", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuHelpAbout.Text = strGet_ini("Menu", "HELP_ABOUT", "&About BMSE", strFileName)
			
			.mnuContext.Visible = False
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextPlayAll.Text = strGet_ini("Menu", "TOOLS_PLAY_FIRST", "Play &All", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextPlay.Text = strGet_ini("Menu", "TOOLS_PLAY", "&Play From Current Position", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextInsertMeasure.Text = strGet_ini("Menu", "CONTEXT_MEASURE_INSERT", "&Insert Measure", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextDeleteMeasure.Text = strGet_ini("Menu", "CONTEXT_MEASURE_DELETE", "Delete &Measure", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextEditCut.Text = strGet_ini("Menu", "EDIT_CUT", "Cu&t", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextEditCopy.Text = strGet_ini("Menu", "EDIT_COPY", "&Copy", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextEditPaste.Text = strGet_ini("Menu", "EDIT_PASTE", "&Paste", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextEditDelete.Text = strGet_ini("Menu", "EDIT_DELETE", "&Delete", strFileName)
			
			.mnuContextList.Visible = False
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextListLoad.Text = strGet_ini("Menu", "CONTEXT_LIST_LOAD", "&Load", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextListDelete.Text = strGet_ini("Menu", "CONTEXT_LIST_DELETE", "&Delete", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuContextListRename.Text = strGet_ini("Menu", "CONTEXT_LIST_RENAME", "&Rename", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Header, TAB_BASIC, Basic, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optChangeTop(0).Text = strGet_ini("Header", "TAB_BASIC", "Basic", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Header, TAB_EXPAND, Expand, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optChangeTop(1).Text = strGet_ini("Header", "TAB_EXPAND", "Expand", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Header, TAB_CONFIG, Config, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optChangeTop(2).Text = strGet_ini("Header", "TAB_CONFIG", "Config", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblPlayMode.Text = strGet_ini("Header", "BASIC_PLAYER", "#PLAYER", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayer, 0, strGet_ini("Header", "BASIC_PLAYER_1P", "1 Player", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayer, 1, strGet_ini("Header", "BASIC_PLAYER_2P", "2 Player", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayer, 2, strGet_ini("Header", "BASIC_PLAYER_DP", "Double Play", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayer, 3, strGet_ini("Header", "BASIC_PLAYER_PMS", "9 Keys (PMS)", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayer, 4, strGet_ini("Header", "BASIC_PLAYER_OCT", "13 Keys (Oct)", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblGenre.Text = strGet_ini("Header", "BASIC_GENRE", "#GENRE", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblTitle.Text = strGet_ini("Header", "BASIC_TITLE", "#TITLE", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblArtist.Text = strGet_ini("Header", "BASIC_ARTIST", "#ARTIST", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblPlayLevel.Text = strGet_ini("Header", "BASIC_PLAYLEVEL", "#PLAYLEVEL", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblBPM.Text = strGet_ini("Header", "BASIC_BPM", "#BPM", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblPlayRank.Text = strGet_ini("Header", "EXPAND_RANK", "#RANK", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayRank, 0, strGet_ini("Header", "EXPAND_RANK_VERY_HARD", "Very Hard", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayRank, 1, strGet_ini("Header", "EXPAND_RANK_HARD", "Hard", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayRank, 2, strGet_ini("Header", "EXPAND_RANK_NORMAL", "Normal", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboPlayRank, 3, strGet_ini("Header", "EXPAND_RANK_EASY", "Easy", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblTotal.Text = strGet_ini("Header", "EXPAND_TOTAL", "#TOTAL", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblVolume.Text = strGet_ini("Header", "EXPAND_VOLWAV", "#VOLWAV", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblStageFile.Text = strGet_ini("Header", "EXPAND_STAGEFILE", "#STAGEFILE", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblMissBMP.Text = strGet_ini("Header", "EXPAND_BPM_MISS", "#BMP00", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdLoadMissBMP.Text = strGet_ini("Header", "EXPAND_SET_FILE", "...", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdLoadStageFile.Text = strGet_ini("Header", "EXPAND_SET_FILE", "...", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblDispFrame.Text = strGet_ini("Header", "CONFIG_KEY_FRAME", "Key Frame", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispFrame, 0, strGet_ini("Header", "CONFIG_KEY_HALF", "Half", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispFrame, 1, strGet_ini("Header", "CONFIG_KEY_SEPARATE", "Separate", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblDispKey.Text = strGet_ini("Header", "CONFIG_KEY_POSITION", "Key Position", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispKey, 0, strGet_ini("Header", "CONFIG_KEY_5KEYS", "5Keys/10Keys", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispKey, 1, strGet_ini("Header", "CONFIG_KEY_7KEYS", "7Keys/14Keys", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblDispSC1P.Text = strGet_ini("Header", "CONFIG_SCRATCH_1P", "Scratch 1P", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispSC1P, 0, strGet_ini("Header", "CONFIG_SCRATCH_LEFT", "L", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispSC1P, 1, strGet_ini("Header", "CONFIG_SCRATCH_RIGHT", "R", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblDispSC2P.Text = strGet_ini("Header", "CONFIG_SCRATCH_2P", "2P", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispSC2P, 0, strGet_ini("Header", "CONFIG_SCRATCH_LEFT", "L", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispSC2P, 1, strGet_ini("Header", "CONFIG_SCRATCH_RIGHT", "R", strFileName))
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Material, TAB_WAV, #WAV, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optChangeBottom(0).Text = strGet_ini("Material", "TAB_WAV", "#WAV", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Material, TAB_BMP, #BMP, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optChangeBottom(1).Text = strGet_ini("Material", "TAB_BMP", "#BMP", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Material, TAB_BGA, #BGA, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optChangeBottom(2).Text = strGet_ini("Material", "TAB_BGA", "#BGA", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Material, TAB_BEAT, Beat, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optChangeBottom(3).Text = strGet_ini("Material", "TAB_BEAT", "Beat", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Material, TAB_EXPAND, Expand, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optChangeBottom(4).Text = strGet_ini("Material", "TAB_EXPAND", "Expand", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdSoundStop.Text = strGet_ini("Material", "MATERIAL_STOP", "Stop", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdSoundExcUp.Text = strGet_ini("Material", "MATERIAL_EXCHANGE_UP", "<", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdSoundExcDown.Text = strGet_ini("Material", "MATERIAL_EXCHANGE_DOWN", ">", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdSoundDelete.Text = strGet_ini("Material", "MATERIAL_DELETE", "Del", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdSoundLoad.Text = strGet_ini("Material", "MATERIAL_SET_FILE", "...", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBMPPreview.Text = strGet_ini("Material", "MATERIAL_PREVIEW", "Preview", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBMPExcUp.Text = strGet_ini("Material", "MATERIAL_EXCHANGE_UP", "<", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBMPExcDown.Text = strGet_ini("Material", "MATERIAL_EXCHANGE_DOWN", ">", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBMPDelete.Text = strGet_ini("Material", "MATERIAL_DELETE", "Del", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBMPLoad.Text = strGet_ini("Material", "MATERIAL_SET_FILE", "...", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBGAPreview.Text = strGet_ini("Material", "MATERIAL_PREVIEW", "Preview", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBGAExcUp.Text = strGet_ini("Material", "MATERIAL_EXCHANGE_UP", "<", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBGAExcDown.Text = strGet_ini("Material", "MATERIAL_EXCHANGE_DOWN", ">", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBGADelete.Text = strGet_ini("Material", "MATERIAL_DELETE", "Del", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdBGASet.Text = strGet_ini("Material", "MATERIAL_INPUT", "Input", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdMeasureSelectAll.Text = strGet_ini("Material", "MATERIAL_SELECT_ALL", "All", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdInputMeasureLen.Text = strGet_ini("Material", "MATERIAL_INPUT", "Input", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblGridMain.Text = strGet_ini("ToolBar", "GRID_MAIN", "Grid", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblGridSub.Text = strGet_ini("ToolBar", "GRID_SUB", "Sub", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblDispHeight.Text = strGet_ini("ToolBar", "DISP_HEIGHT", "Height", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblDispWidth.Text = strGet_ini("ToolBar", "DISP_WIDTH", "Width", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispHeight, .cboDispHeight.Items.Count - 1, strGet_ini("ToolBar", "DISP_VALUE_OTHER", "Other", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			VB6.SetItemString(.cboDispWidth, .cboDispHeight.Items.Count - 1, strGet_ini("ToolBar", "DISP_VALUE_OTHER", "Other", strFileName))
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblVScroll.Text = strGet_ini("ToolBar", "VSCROLL", "VScroll", strFileName)
			
			If .tlbMenu.Items.Item("Edit").Checked = True Then
				
				.staMain.Items.Item("Mode").Text = g_strStatusBar(20)
				
			ElseIf .tlbMenu.Items.Item("Write").Checked = True Then 
				
				.staMain.Items.Item("Mode").Text = g_strStatusBar(21)
				
			Else
				
				.staMain.Items.Item("Mode").Text = g_strStatusBar(22)
				
			End If
			
		End With
		
		With frmMain.tlbMenu
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_NEW, New, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("New").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_NEW", "New", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("New").Description = strGet_ini("ToolBar", "TOOLTIP_NEW", "New", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_OPEN, Open, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Open").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_OPEN", "Open", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Open").Description = strGet_ini("ToolBar", "TOOLTIP_OPEN", "Open", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_RELOAD, Reload, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Reload").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_RELOAD", "Reload", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Reload").Description = strGet_ini("ToolBar", "TOOLTIP_RELOAD", "Reload", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_SAVE, Save, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Save").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_SAVE", "Save", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Save").Description = strGet_ini("ToolBar", "TOOLTIP_SAVE", "Save", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_SAVE_AS, Save As, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("SaveAs").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_SAVE_AS", "Save As", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("SaveAs").Description = strGet_ini("ToolBar", "TOOLTIP_SAVE_AS", "Save As", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_MODE_EDIT, Edit Mode, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Edit").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_MODE_EDIT", "Edit Mode", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Edit").Description = strGet_ini("ToolBar", "TOOLTIP_MODE_EDIT", "Edit Mode", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_MODE_WRITE, Write Mode, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Write").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_MODE_WRITE", "Write Mode", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Write").Description = strGet_ini("ToolBar", "TOOLTIP_MODE_WRITE", "Write Mode", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_MODE_DELETE, Delete Mode, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Delete").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_MODE_DELETE", "Delete Mode", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Delete").Description = strGet_ini("ToolBar", "TOOLTIP_MODE_DELETE", "Delete Mode", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_PLAY_FIRST, Play All, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("PlayAll").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_PLAY_FIRST", "Play All", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("PlayAll").Description = strGet_ini("ToolBar", "TOOLTIP_PLAY_FIRST", "Play All", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_PLAY, Play From Current Position, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Play").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_PLAY", "Play From Current Position", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Play").Description = strGet_ini("ToolBar", "TOOLTIP_PLAY", "Play From Current Position", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, TOOLTIP_STOP, Stop, strFileName) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Stop").ToolTipText = strGet_ini("ToolBar", "TOOLTIP_STOP", "Stop", strFileName)
			'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Description �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Items.Item("Stop").Description = strGet_ini("ToolBar", "TOOLTIP_STOP", "Stop", strFileName)
			
		End With
		
		With frmWindowFind
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Text = strGet_ini("Find", "TITLE", "Find/Delete/Replace", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.fraSearchObject.Text = strGet_ini("Find", "FRAME_SEARCH", "Range", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.fraSearchMeasure.Text = strGet_ini("Find", "FRAME_MEASURE", "Range of measure", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.fraSearchNum.Text = strGet_ini("Find", "FRAME_OBJ_NUM", "Range of object number", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.fraSearchGrid.Text = strGet_ini("Find", "FRAME_GRID", "Lane", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.fraProcess.Text = strGet_ini("Find", "FRAME_PROCESS", "Method", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optSearchAll.Text = strGet_ini("Find", "OPT_OBJ_ALL", "All object", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optSearchSelect.Text = strGet_ini("Find", "OPT_OBJ_SELECT", "Selected object", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optProcessSelect.Text = strGet_ini("Find", "OPT_PROCESS_SELECT", "Select", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optProcessDelete.Text = strGet_ini("Find", "OPT_PROCESS_DELETE", "Delete", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.optProcessReplace.Text = strGet_ini("Find", "OPT_PROCESS_REPLACE", "Replace to", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdInvert.Text = strGet_ini("Find", "CMD_INVERT", "Invert", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdReset.Text = strGet_ini("Find", "CMD_RESET", "Reset", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdSelect.Text = strGet_ini("Find", "CMD_SELECT", "Select All", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdClose.Text = strGet_ini("Find", "CMD_CLOSE", "Close", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdDecide.Text = strGet_ini("Find", "CMD_DECIDE", "Run", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblNotice.Text = strGet_ini("Find", "LBL_NOTICE", "This item doesn't influence BPM/STOP object", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblMeasure.Text = strGet_ini("Find", "LBL_DASH", "to", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblNum.Text = strGet_ini("Find", "LBL_DASH", "to", strFileName)
			
		End With
		
		With frmWindowInput
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Text = strGet_ini("Input", "TITLE", "Input Form", strFileName)
			
		End With
		
		With frmWindowViewer
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Text = strGet_ini("Viewer", "TITLE", "Viewer Setting", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdViewerPath.Text = strGet_ini("Viewer", "CMD_SET", "...", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdAdd.Text = strGet_ini("Viewer", "CMD_ADD", "Add", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdDelete.Text = strGet_ini("Viewer", "CMD_DELETE", "Delete", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdOK.Text = strGet_ini("Viewer", "CMD_OK", "OK", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdCancel.Text = strGet_ini("Viewer", "CMD_CANCEL", "Cancel", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblViewerName.Text = strGet_ini("Viewer", "LBL_APP_NAME", "Player name", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblViewerPath.Text = strGet_ini("Viewer", "LBL_APP_PATH", "Path", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblPlayAll.Text = strGet_ini("Viewer", "LBL_ARG_PLAY_ALL", "Argument of ""Play All""", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblPlay.Text = strGet_ini("Viewer", "LBL_ARG_PLAY", "Argument of ""Play""", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblStop.Text = strGet_ini("Viewer", "LBL_ARG_STOP", "Argument of ""Stop""", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblNotice.Text = Replace(strGet_ini("Viewer", "LBL_ARG_INFO", "Syntax reference:\n<filename> File name\n<measure> Current measure", strFileName), "\n", vbCrLf)
			
		End With
		
		With frmWindowConvert
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Text = strGet_ini("Convert", "TITLE", "Conversion Wizard", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.chkDeleteUnusedFile.Text = strGet_ini("Convert", "CHK_DELETE_LIST", "Clear unused definition from a list", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.chkDeleteFile.Text = strGet_ini("Convert", "CHK_DELETE_FILE", "Delete unused files in this BMS folder (*)", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblExtension.Text = strGet_ini("Convert", "LBL_EXTENSION", "Search extensions:", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.chkFileRecycle.Text = strGet_ini("Convert", "CHK_RECYCLE", "Delete soon with no through recycled", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.chkListAlign.Text = strGet_ini("Convert", "CHK_ALIGN_LIST", "Sort definition list", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.chkUseOldFormat.Text = strGet_ini("Convert", "CHK_USE_OLD_FORMAT", "Use old Format [01 - FF] if possible", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.chkSortByName.Text = strGet_ini("Convert", "CHK_SORT_BY_NAME", "Sorting by filename", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.chkFileNameConvert.Text = strGet_ini("Convert", "CHK_CONVERT_FILENAME", "Change filename to list number [01 - ZZ] (*)", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lblNotice.Text = strGet_ini("Convert", "LBL_NOTICE", "(*) Cannot undo this command", strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdDecide.Text = strGet_ini("Convert", "CMD_DECIDE", "Run", strFileName)
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cmdCancel.Text = strGet_ini("Convert", "CMD_CANCEL", "Cancel", strFileName)
			
		End With
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_01) = Replace(strGet_ini("Message", "ERROR_MESSAGE_01", "The unexpected error occurred. Program will shut down.\nRefer to the ""error.txt"" for the details of an error.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_02) = Replace(strGet_ini("Message", "ERROR_MESSAGE_02", "Temporary file is saved to...", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_FILE_NOT_FOUND) = Replace(strGet_ini("Message", "ERROR_FILE_NOT_FOUND", "File not found.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_LOAD_CANCEL) = Replace(strGet_ini("Message", "ERROR_LOAD_CANCEL", "Loading will be aborted.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_SAVE_ERROR) = Replace(strGet_ini("Message", "ERROR_SAVE_ERROR", "Error occured while saving.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_SAVE_CANCEL) = Replace(strGet_ini("Message", "ERROR_SAVE_CANCEL", "Saving will be aborted.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_OVERFLOW_LARGE) = Replace(strGet_ini("Message", "ERROR_OVERFLOW_LARGE", "Error:\nValue is too large.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_OVERFLOW_SMALL) = Replace(strGet_ini("Message", "ERROR_OVERFLOW_SMALL", "Error:\nValue is too small.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_OVERFLOW_BPM) = Replace(strGet_ini("Message", "ERROR_OVERFLOW_BPM", "You have used more than 1295 BPM change command.\nNumber of commands should be less than 1295.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_OVERFLOW_STOP) = Replace(strGet_ini("Message", "ERROR_OVERFLOW_STOP", "You have used more than 1295 STOP command.\nNumber of commands should be less than 1295.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_APP_NOT_FOUND) = Replace(strGet_ini("Message", "ERROR_APP_NOT_FOUND", " is not found.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.ERR_FILE_ALREADY_EXIST) = Replace(strGet_ini("Message", "ERROR_FILE_ALREADY_EXIST", "File already exist.", strFileName), "\n", vbCrLf)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.MSG_CONFIRM) = Replace(strGet_ini("Message", "INFO_CONFIRM", "This command cannot be undone, OK?", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.MSG_FILE_CHANGED) = Replace(strGet_ini("Message", "INFO_FILE_CHANGED", "Do you want to save changes?", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.MSG_INI_CHANGED) = Replace(strGet_ini("Message", "INFO_INI_CHANGED", "ini format has changed.\n(All setting will reset)", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.MSG_ALIGN_LIST) = Replace(strGet_ini("Message", "INFO_ALIGN_LIST", "Do you want the filelist to be rewrited into the old format [01 - FF]?\n(Attention: Some programs are compatible only with old format files.)", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.MSG_DELETE_FILE) = Replace(strGet_ini("Message", "INFO_DELETE_FILE", "They have been deleted:", strFileName), "\n", vbCrLf)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.INPUT_BPM) = Replace(strGet_ini("Input", "INPUT_BPM", "Enter the BPM you wish to change to.\n(Decimal number can be used. Enter 0 to cancel)", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.INPUT_STOP) = Replace(strGet_ini("Input", "INPUT_STOP", "Enter the length of stoppage 1 corresponds to 1/192 of the measure.\n(Enter under 0 to cancel)", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.INPUT_RENAME) = Replace(strGet_ini("Input", "INPUT_RENAME", "Please enter new filename.", strFileName), "\n", vbCrLf)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Message(modMain.Message.INPUT_SIZE) = Replace(strGet_ini("Input", "INPUT_SIZE", "Type your display magnification.\n(Maximum 16.00. Enter under 0 to cancel)", strFileName), "\n", vbCrLf)
		
		Dim DefaultFont As String
		Dim SystemFont As String
		Dim FixedFont As String
		
		'Dim ncm As NONCLIENTMETRICS
		'ncm.cbSize = LenB(ncm)
		'Call SystemParametersInfo(SPI_GETNONCLIENTMETRICS, LenB(ncm), ncm, 0)
		'DefaultFont = StrConv(ncm.lfSMCaptionFont.lfFaceName, vbUnicode)
		
		'UPGRADE_ISSUE: LOGFONT �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim lf As LOGFONT
		'UPGRADE_WARNING: �I�u�W�F�N�g lf �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g GetStockObject() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call GetObject(GetStockObject(DEFAULT_GUI_FONT), CStr(LenB(lf)), CStr(lf))
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g lf.lfFaceName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DefaultFont = Trim(StrConv(lf.lfFaceName, vbUnicode))
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SystemFont = strGet_ini("Main", "Font", DefaultFont, strFileName)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FixedFont = strGet_ini("Main", "FixedFont", DefaultFont, strFileName)
		
		'�t�H���g�����ύX
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SystemFont = strGet_ini("Main", "Font", SystemFont, "bmse.ini")
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FixedFont = strGet_ini("Main", "FixedFont", FixedFont, "bmse.ini")
		
		Call LoadFont(SystemFont, FixedFont, strGet_ini("Main", "Charset", DEFAULT_CHARSET, strFileName))
		
		Call frmMain.frmMain_Resize(Nothing, New System.EventArgs())
		
	End Sub
	
	Private Sub LoadFont(ByRef MainFont As String, ByRef FixedFont As String, ByVal Charset As Integer)
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim objCtl As Object
		
		For i = 0 To My.Application.OpenForms.Count - 1
			
			My.Application.OpenForms.Item(i).Font = VB6.FontChangeName(My.Application.OpenForms.Item(i).Font, MainFont)
			My.Application.OpenForms.Item(i).Font = VB6.FontChangeGdiCharSet(My.Application.OpenForms.Item(i).Font, Charset)
			
			For	Each objCtl In My.Application.OpenForms.Item(i).Controls
				
				If TypeOf objCtl Is System.Windows.Forms.Label Or TypeOf objCtl Is System.Windows.Forms.TextBox Or TypeOf objCtl Is System.Windows.Forms.ComboBox Or TypeOf objCtl Is System.Windows.Forms.Button Or TypeOf objCtl Is System.Windows.Forms.RadioButton Or TypeOf objCtl Is System.Windows.Forms.CheckBox Or TypeOf objCtl Is System.Windows.Forms.GroupBox Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g objCtl.Font �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					objCtl.Font.Name = MainFont
					'UPGRADE_WARNING: �I�u�W�F�N�g objCtl.Font �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					objCtl.Font.Charset = Charset
					
				ElseIf TypeOf objCtl Is System.Windows.Forms.PictureBox Or TypeOf objCtl Is System.Windows.Forms.ListBox Then 
					
					'UPGRADE_WARNING: �I�u�W�F�N�g objCtl.Font �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					objCtl.Font.Name = FixedFont
					'UPGRADE_WARNING: �I�u�W�F�N�g objCtl.Font �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					objCtl.Font.Charset = Charset
					
				End If
				
			Next objCtl
			
		Next i
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "LoadFont")
	End Sub
	
	Public Sub LoadConfig()
		Dim CreateConfig As Object
		Dim modMain As Object
		Dim LoadThemeFile As Object
		Dim INI_VERSION As Object
		Dim g_Message As Object
		Dim LoadLanguageFile As Object
		Dim strGet_ini As Object
		On Error GoTo InitConfig
		
		Dim i As Integer
		Dim wp As WINDOWPLACEMENT
		Dim strTemp As String
		Dim lngTemp As Integer
		Static lngCount As Integer
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Main, Key, , bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If strGet_ini("Main", "Key", "", "bmse.ini") <> "BMSE" Then GoTo InitConfig
		
		With frmMain
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strTemp = strGet_ini("Main", "Language", "english.ini", "bmse.ini")
			
			For i = 1 To .mnuLanguage.UBound
				
				If strTemp = g_strLangFileName(i) Then
					
					.mnuLanguage(i).Checked = True
					
					Exit For
					
				End If
				
			Next i
			
			'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
			Load(frmWindowAbout)
			'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
			Load(frmWindowFind)
			'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
			Load(frmWindowInput)
			'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
			Load(frmWindowPreview)
			'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
			Load(frmWindowTips)
			'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
			Load(frmWindowViewer)
			'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
			Load(frmWindowConvert)
			
			Call LoadLanguageFile("lang\" & strTemp)
			
			Call frmWindowPreview.SetWindowSize()
			
			'UPGRADE_WARNING: �I�u�W�F�N�g INI_VERSION �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If strGet_ini("Main", "ini", "", "bmse.ini") <> INI_VERSION Then
				
				'UPGRADE_WARNING: LoadConfig �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
				
				GoTo InitConfig
				
			End If
			
			wp.Length = 44
			Call GetWindowPlacement(.Handle.ToInt32, wp)
			
			With wp
				
				.showCmd = SW_HIDE
				
				With .rcNormalPosition
					
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.right_Renamed = strGet_ini("Main", "Width", 800, "bmse.ini")
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bottom = strGet_ini("Main", "Height", 600, "bmse.ini")
					'.Left = strGet_ini("Main", "X", (Screen.Width \ Screen.TwipsPerPixelX - .Right) \ 2, "bmse.ini")
					'.Top = strGet_ini("Main", "Y", (Screen.Height \ Screen.TwipsPerPixelY - .Bottom) \ 2, "bmse.ini")
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.left_Renamed = strGet_ini("Main", "X", 0, "bmse.ini")
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Top = strGet_ini("Main", "Y", 0, "bmse.ini")
					.right_Renamed = .left_Renamed + .right_Renamed
					.Bottom = .Top + .Bottom
					
					If .right_Renamed > VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ VB6.TwipsPerPixelX Then
						
						.left_Renamed = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ VB6.TwipsPerPixelX - (.right_Renamed - .left_Renamed)
						.right_Renamed = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ VB6.TwipsPerPixelX
						
					End If
					
					If .left_Renamed < 0 Then .left_Renamed = 0
					
					If .Bottom > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ VB6.TwipsPerPixelY Then
						
						.Top = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ VB6.TwipsPerPixelY - (.Bottom - .Top)
						.Bottom = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ VB6.TwipsPerPixelY
						
					End If
					
					If .Top < 0 Then .Top = 0
					
				End With
				
			End With
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strTemp = strGet_ini("Main", "Theme", "default.ini", "bmse.ini")
			
			For i = 1 To .mnuTheme.UBound
				
				If strTemp = g_strThemeFileName(i) Then
					
					.mnuTheme(i).Checked = True
					
					Exit For
					
				End If
				
			Next i
			
			Call LoadThemeFile("theme\" & strTemp)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			g_strHelpFilename = strGet_ini("Main", "Help", "", "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			g_strFiler = strGet_ini("Main", "Filer", "", "bmse.ini")
			
			If g_strHelpFilename <> "" Then
				
				.mnuHelpOpen.Enabled = True
				
			End If
			
			'.hsbDispWidth.Value = strGet_ini("View", "Width", 100, "bmse.ini")
			'.hsbDispHeight.Value = strGet_ini("View", "Height", 100, "bmse.ini")
			
			With .cboDispWidth
				
				'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				lngTemp = strGet_ini("View", "Width", 100, "bmse.ini")
				
				For i = 0 To .Items.Count - 1
					
					If VB6.GetItemData(frmMain.cboDispWidth, i) = lngTemp Then
						
						.SelectedIndex = i
						
						Exit For
						
					ElseIf VB6.GetItemData(frmMain.cboDispWidth, i) > lngTemp Then 
						
						Call .Items.Insert(i, "x" & VB6.Format(lngTemp / 100, "#0.00"))
						VB6.SetItemData(frmMain.cboDispWidth, i, lngTemp)
						.SelectedIndex = i
						
						Exit For
						
					End If
					
				Next i
				
			End With
			
			With .cboDispHeight
				
				'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				lngTemp = strGet_ini("View", "Height", 100, "bmse.ini")
				
				For i = 0 To .Items.Count - 1
					
					If VB6.GetItemData(frmMain.cboDispHeight, i) = lngTemp Then
						
						.SelectedIndex = i
						
						Exit For
						
					ElseIf VB6.GetItemData(frmMain.cboDispHeight, i) > lngTemp Then 
						
						Call .Items.Insert(i, "x" & VB6.Format(lngTemp / 100, "#0.00"))
						VB6.SetItemData(frmMain.cboDispHeight, i, lngTemp)
						.SelectedIndex = i
						
						Exit For
						
					End If
					
				Next i
				
			End With
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cboDispGridMain.SelectedIndex = strGet_ini("View", "VGridMain", 1, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cboDispGridSub.SelectedIndex = strGet_ini("View", "VGridSub", 1, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cboDispFrame.SelectedIndex = strGet_ini("View", "Frame", 1, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cboDispKey.SelectedIndex = strGet_ini("View", "Key", 1, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cboDispSC1P.SelectedIndex = strGet_ini("View", "SC_1P", 1, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.cboDispSC2P.SelectedIndex = strGet_ini("View", "SC_2P", 1, "bmse.ini")
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(View, ToolBar, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuViewItem(frmMain.MENU_VIEW.TOOL_BAR).Checked = strGet_ini("View", "ToolBar", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(View, DirectInput, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuViewItem(frmMain.MENU_VIEW.DIRECT_INPUT).Checked = strGet_ini("View", "DirectInput", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(View, StatusBar, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuViewItem(frmMain.MENU_VIEW.STATUS_BAR).Checked = strGet_ini("View", "StatusBar", True, "bmse.ini")
			
			If .cboViewer.Items.Count Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(View, ViewerNum, 0, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If .cboViewer.Items.Count > strGet_ini("View", "ViewerNum", 0, "bmse.ini") Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.cboViewer.SelectedIndex = strGet_ini("View", "ViewerNum", 0, "bmse.ini")
					
				Else
					
					.cboViewer.SelectedIndex = 0
					
				End If
				
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Options, Active, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.IGNORE_INPUT).Checked = strGet_ini("Options", "Active", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Options, FileNameOnly, False, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.TITLE_FILENAME).Checked = strGet_ini("Options", "FileNameOnly", False, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Options, VerticalWriting, False, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.VERTICAL_INFO).Checked = strGet_ini("Options", "VerticalWriting", False, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Options, LaneBG, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.LANE_BGCOLOR).Checked = strGet_ini("Options", "LaneBG", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Options, SelectSound, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.SELECT_PREVIEW).Checked = strGet_ini("Options", "SelectSound", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Options, MoveOnGrid, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.MOVE_ON_GRID).Checked = strGet_ini("Options", "MoveOnGrid", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Options, ObjectFileName, False, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.OBJ_FILENAME).Checked = strGet_ini("Options", "ObjectFileName", False, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(Options, UseOldFormat, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.mnuOptionsItem(frmMain.MENU_OPTIONS.USE_OLD_FORMAT).Checked = strGet_ini("Options", "UseOldFormat", True, "bmse.ini")
			'.mnuOptionsItem(RCLICK_DELETE).Checked = strGet_ini("Options", "RightClickDelete", False, "bmse.ini")
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, New, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("New").Visible = strGet_ini("ToolBar", "New", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Open, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Open").Visible = strGet_ini("ToolBar", "Open", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Reload, False, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Reload").Visible = strGet_ini("ToolBar", "Reload", False, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Save, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Save").Visible = strGet_ini("ToolBar", "Save", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, SaveAs, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("SaveAs").Visible = strGet_ini("ToolBar", "SaveAs", True, "bmse.ini")
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Mode, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("SepMode").Visible = strGet_ini("ToolBar", "Mode", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Mode, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Edit").Visible = strGet_ini("ToolBar", "Mode", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Mode, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Write").Visible = strGet_ini("ToolBar", "Mode", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Mode, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Delete").Visible = strGet_ini("ToolBar", "Mode", True, "bmse.ini")
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Preview, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("SepViewer").Visible = strGet_ini("ToolBar", "Preview", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Preview, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("PlayAll").Visible = strGet_ini("ToolBar", "Preview", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Preview, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Play").Visible = strGet_ini("ToolBar", "Preview", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Preview, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Stop").Visible = strGet_ini("ToolBar", "Preview", True, "bmse.ini")
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Grid, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("SepGrid").Visible = strGet_ini("ToolBar", "Grid", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Grid, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("ChangeGrid").Visible = strGet_ini("ToolBar", "Grid", True, "bmse.ini")
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Size, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("SepSize").Visible = strGet_ini("ToolBar", "Size", True, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Size, True, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("DispSize").Visible = strGet_ini("ToolBar", "Size", True, "bmse.ini")
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Resolution, False, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("SepResolution").Visible = strGet_ini("ToolBar", "Resolution", False, "bmse.ini")
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(ToolBar, Resolution, False, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.tlbMenu.Items.Item("Resolution").Visible = strGet_ini("ToolBar", "Resolution", False, "bmse.ini")
			
			For i = 0 To UBound(g_strRecentFiles)
				
				'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				g_strRecentFiles(i) = strGet_ini("RecentFiles", i, "", "bmse.ini")
				
				If Len(g_strRecentFiles(i)) Then
					
					With .mnuRecentFiles(i)
						
						.Text = "&" & Right(CStr(i + 1), 1) & ":" & g_strRecentFiles(i)
						.Enabled = True
						.Visible = True
						
					End With
					
					'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �R���N�V���� frmMain.tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
					With .tlbMenu.Items.Item("Open").ButtonMenus.Item(i + 1)
						
						'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �R���N�V���� frmMain.tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
						.Text = "&" & Right(CStr(i + 1), 1) & ":" & g_strRecentFiles(i)
						'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �R���N�V���� frmMain.tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
						.Enabled = True
						'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �R���N�V���� frmMain.tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
						.Visible = True
						
					End With
					
					.mnuLineRecent.Visible = True
					
				End If
				
			Next i
			
			Call SetWindowPlacement(.Handle.ToInt32, wp)
			
		End With
		
		Call modEasterEgg.InitEffect()
		
		With frmWindowPreview
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Left = VB6.TwipsToPixelsX(strGet_ini("Preview", "X", (VB6.PixelsToTwipsX(frmMain.Left) + VB6.PixelsToTwipsX(frmMain.Width) \ 2) - VB6.PixelsToTwipsX(.Width) \ 2, "bmse.ini"))
			If VB6.PixelsToTwipsX(.Left) < 0 Then .Left = 0
			If VB6.PixelsToTwipsX(.Left) > VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) Then .Left = 0
			
			'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Top = VB6.TwipsToPixelsY(strGet_ini("Preview", "Y", (VB6.PixelsToTwipsY(frmMain.Top) + VB6.PixelsToTwipsY(frmMain.Height) \ 2) - VB6.PixelsToTwipsY(.Height) \ 2, "bmse.ini"))
			If VB6.PixelsToTwipsY(.Top) < 0 Then .Top = 0
			If VB6.PixelsToTwipsY(.Top) > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) Then .Top = 0
			
		End With
		
		Exit Sub
		
InitConfig: 
		
		lngCount = lngCount + 1
		
		If lngCount > 5 Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call modMain.CleanUp(Err.Number, Err.Description, "LoadConfig")
			
		Else
			
			Call CreateConfig()
			
		End If
		
	End Sub
	
	Private Sub CreateConfig()
		Dim LoadConfig As Object
		Dim INI_VERSION As Object
		Dim lngSet_ini As Object
		
		Call lngSet_ini("Main", "Key", Chr(34) & "BMSE" & Chr(34))
		Call lngSet_ini("Main", "ini", INI_VERSION)
		'Call lngSet_ini("Main", "X", (Screen.Width \ Screen.TwipsPerPixelX - 800) \ 2)
		'Call lngSet_ini("Main", "Y", (Screen.Height \ Screen.TwipsPerPixelY - 600) \ 2)
		Call lngSet_ini("Main", "X", 0)
		Call lngSet_ini("Main", "Y", 0)
		Call lngSet_ini("Main", "Width", "800")
		Call lngSet_ini("Main", "Height", "600")
		Call lngSet_ini("Main", "State", SW_SHOWNORMAL)
		Call lngSet_ini("Main", "Language", Chr(34) & "english.ini" & Chr(34))
		Call lngSet_ini("Main", "Theme", Chr(34) & "default.ini" & Chr(34))
		Call lngSet_ini("Main", "Help", Chr(34) & Chr(34))
		
		Call lngSet_ini("View", "Width", 100)
		Call lngSet_ini("View", "Height", 100)
		Call lngSet_ini("View", "VGridMain", 1)
		Call lngSet_ini("View", "VGridSub", 1)
		Call lngSet_ini("View", "Frame", 1)
		Call lngSet_ini("View", "Key", 1)
		Call lngSet_ini("View", "SC_1P", 0)
		Call lngSet_ini("View", "SC_2P", 1)
		
		Call lngSet_ini("View", "ToolBar", True)
		Call lngSet_ini("View", "DirectInput", True)
		Call lngSet_ini("View", "StatusBar", True)
		
		Call lngSet_ini("View", "ViewerNum", 0)
		
		Call lngSet_ini("ToolBar", "New", True)
		Call lngSet_ini("ToolBar", "Open", True)
		Call lngSet_ini("ToolBar", "Reload", False)
		Call lngSet_ini("ToolBar", "Save", True)
		Call lngSet_ini("ToolBar", "SaveAs", True)
		Call lngSet_ini("ToolBar", "Mode", True)
		Call lngSet_ini("ToolBar", "Preview", True)
		Call lngSet_ini("ToolBar", "Gird", True)
		Call lngSet_ini("ToolBar", "Size", True)
		Call lngSet_ini("ToolBar", "Resolution", False)
		
		Call lngSet_ini("Options", "Active", True)
		Call lngSet_ini("Options", "FileNameOnly", False)
		Call lngSet_ini("Options", "VerticalWriting", False)
		Call lngSet_ini("Options", "LaneBG", True)
		Call lngSet_ini("Options", "SelectSound", True)
		Call lngSet_ini("Options", "MoveOnGrid", True)
		Call lngSet_ini("Options", "ObjectFileName", False)
		Call lngSet_ini("Options", "UseOldFormat", True)
		Call lngSet_ini("Options", "RightClickDelete", False)
		
		Call lngSet_ini("Preview", "X", 0)
		Call lngSet_ini("Preview", "Y", 0)
		
		Call LoadConfig()
		
	End Sub
	
	Public Sub SaveConfig()
		Dim lngSet_ini As Object
		
		Dim i As Integer
		Dim wp As WINDOWPLACEMENT
		
		Call lngSet_ini("Main", "Key", Chr(34) & "BMSE" & Chr(34))
		
		wp.Length = 44
		Call GetWindowPlacement(frmMain.Handle.ToInt32, wp)
		
		With wp
			
			If wp.showCmd <> SW_SHOWMINIMIZED Then
				
				Call lngSet_ini("Main", "State", wp.showCmd)
				
			Else
				
				Call lngSet_ini("Main", "State", SW_SHOWNORMAL)
				
			End If
			
			With .rcNormalPosition
				
				Call lngSet_ini("Main", "X", .left_Renamed)
				Call lngSet_ini("Main", "Y", .Top)
				Call lngSet_ini("Main", "Width", .right_Renamed - .left_Renamed)
				Call lngSet_ini("Main", "Height", .Bottom - .Top)
				
			End With
			
		End With
		
		With frmMain
			
			For i = 1 To .mnuLanguage.UBound
				
				If .mnuLanguage(i).Checked = True Then
					
					Call lngSet_ini("Main", "Language", Chr(34) & g_strLangFileName(i) & Chr(34))
					
					Exit For
					
				End If
				
			Next i
			
			For i = 1 To .mnuTheme.UBound
				
				If .mnuTheme(i).Checked = True Then
					
					Call lngSet_ini("Main", "Theme", Chr(34) & g_strThemeFileName(i) & Chr(34))
					
					Exit For
					
				End If
				
			Next i
			
			Call lngSet_ini("View", "Width", VB6.GetItemData(.cboDispWidth, .cboDispWidth.SelectedIndex))
			Call lngSet_ini("View", "Height", VB6.GetItemData(.cboDispHeight, .cboDispHeight.SelectedIndex))
			Call lngSet_ini("View", "VGridMain", .cboDispGridMain.SelectedIndex)
			Call lngSet_ini("View", "VGridSub", .cboDispGridSub.SelectedIndex)
			Call lngSet_ini("View", "Frame", .cboDispFrame.SelectedIndex)
			Call lngSet_ini("View", "Key", .cboDispKey.SelectedIndex)
			Call lngSet_ini("View", "SC_1P", .cboDispSC1P.SelectedIndex)
			Call lngSet_ini("View", "SC_2P", .cboDispSC2P.SelectedIndex)
			
			Call lngSet_ini("View", "ToolBar", .mnuViewItem(frmMain.MENU_VIEW.TOOL_BAR).Checked)
			Call lngSet_ini("View", "DirectInput", .mnuViewItem(frmMain.MENU_VIEW.DIRECT_INPUT).Checked)
			Call lngSet_ini("View", "StatusBar", .mnuViewItem(frmMain.MENU_VIEW.STATUS_BAR).Checked)
			
			If .cboViewer.Items.Count Then
				
				Call lngSet_ini("View", "ViewerNum", .cboViewer.SelectedIndex)
				
			End If
			
			Call lngSet_ini("Options", "Active", .mnuOptionsItem(frmMain.MENU_OPTIONS.IGNORE_INPUT).Checked)
			Call lngSet_ini("Options", "FileNameOnly", .mnuOptionsItem(frmMain.MENU_OPTIONS.TITLE_FILENAME).Checked)
			Call lngSet_ini("Options", "VerticalWriting", .mnuOptionsItem(frmMain.MENU_OPTIONS.VERTICAL_INFO).Checked)
			Call lngSet_ini("Options", "LaneBG", .mnuOptionsItem(frmMain.MENU_OPTIONS.LANE_BGCOLOR).Checked)
			Call lngSet_ini("Options", "SelectSound", .mnuOptionsItem(frmMain.MENU_OPTIONS.SELECT_PREVIEW).Checked)
			Call lngSet_ini("Options", "MoveOnGrid", .mnuOptionsItem(frmMain.MENU_OPTIONS.MOVE_ON_GRID).Checked)
			Call lngSet_ini("Options", "ObjectFileName", .mnuOptionsItem(frmMain.MENU_OPTIONS.OBJ_FILENAME).Checked)
			Call lngSet_ini("Options", "UseOldFormat", .mnuOptionsItem(frmMain.MENU_OPTIONS.USE_OLD_FORMAT).Checked)
			'Call lngSet_ini("Options", "RightClickDelete", .mnuOptionsItem(RCLICK_DELETE).Checked)
			
			Call lngSet_ini("ToolBar", "New", .tlbMenu.Items.Item("New").Visible)
			Call lngSet_ini("ToolBar", "Open", .tlbMenu.Items.Item("Open").Visible)
			Call lngSet_ini("ToolBar", "Reload", .tlbMenu.Items.Item("Reload").Visible)
			Call lngSet_ini("ToolBar", "Save", .tlbMenu.Items.Item("Save").Visible)
			Call lngSet_ini("ToolBar", "SaveAs", .tlbMenu.Items.Item("SaveAs").Visible)
			Call lngSet_ini("ToolBar", "Mode", .tlbMenu.Items.Item("Write").Visible)
			Call lngSet_ini("ToolBar", "Preview", .tlbMenu.Items.Item("PlayAll").Visible)
			Call lngSet_ini("ToolBar", "Size", .tlbMenu.Items.Item("DispSize").Visible)
			Call lngSet_ini("ToolBar", "Resolution", .tlbMenu.Items.Item("Resolution").Visible)
			
			For i = 0 To UBound(g_strRecentFiles)
				
				Call lngSet_ini("RecentFiles", i, Chr(34) & g_strRecentFiles(i) & Chr(34))
				
			Next i
			
		End With
		
		With frmWindowPreview
			
			Call lngSet_ini("Preview", "X", VB6.PixelsToTwipsX(.Left))
			Call lngSet_ini("Preview", "Y", VB6.PixelsToTwipsY(.Top))
			
		End With
		
	End Sub
	
	Public Function lngSet_ini(ByRef strSection As String, ByVal strKey As String, ByVal strSet As String) As Integer
		Dim WritePrivateProfileString As Object
		
		Dim lngTemp As Integer
		
		'API�Ăяo�����ϐ���Ԃ�
		'UPGRADE_WARNING: �I�u�W�F�N�g WritePrivateProfileString() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngTemp = WritePrivateProfileString(strSection & Chr(0), strKey, strSet, g_strAppDir & "bmse.ini" & Chr(0))
		
		lngSet_ini = lngTemp
		
	End Function
	
	Public Function strGet_ini(ByRef strSection As String, ByVal strKey As String, ByVal strDefault As String, ByRef strFileName As String) As String
		Dim GetPrivateProfileString As Object
		
		Dim strGetBuf As New VB6.FixedLengthString(256) '���e����string�̃o�b�t�@
		Dim intGetLen As Short '���e����string�̕������̃o�b�t�@
		
		'�o�b�t�@�̏������i256������Ηǂ���ˁB�j
		strGetBuf.Value = Space(256)
		
		'API�Ăяo��
		'UPGRADE_WARNING: �I�u�W�F�N�g GetPrivateProfileString() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intGetLen = GetPrivateProfileString(strSection & Chr(0), strKey, strDefault & Chr(0), strGetBuf.Value, 128, g_strAppDir & strFileName & Chr(0))
		
		'�������Ԃ�
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strGet_ini = Trim(Left(strGetBuf.Value, InStr(strGetBuf.Value, Chr(0)) - 1))
		
		If Val(strGet_ini) < 0 Then strGet_ini = CStr(0)
		
	End Function
	
	Private Function GetColor(ByRef strSection As String, ByRef strKey As String, ByRef strDefault As String, ByRef strFileName As String) As Integer
		Dim strGet_ini As Object
		
		Dim strArray() As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strArray = Split(strGet_ini(strSection, strKey, strDefault, strFileName), ",")
		
		If UBound(strArray) < 2 Then Exit Function
		
		'UPGRADE_WARNING: �I�u�W�F�N�g GetColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		GetColor = RGB(CInt(strArray(0)), CInt(strArray(1)), CInt(strArray(2)))
		
	End Function
	
	Private Function HalfColor(ByVal Color As Integer) As Integer
		
		Dim r As Byte
		Dim g As Byte
		Dim b As Byte
		
		r = Color And &HFF
		g = (Color \ &HFF) And &HFF
		b = (Color \ &HFFFF) And &HFF
		
		'UPGRADE_WARNING: �I�u�W�F�N�g HalfColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HalfColor = RGB(r \ 2, g \ 2, b \ 2)
		
	End Function
End Module
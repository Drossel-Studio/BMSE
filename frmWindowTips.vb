Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmWindowTips
	Inherits System.Windows.Forms.Form
	'UPGRADE_WARNING: �\���� RECT �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Private Declare Function DrawText Lib "user32"  Alias "DrawTextA"(ByVal hdc As Integer, ByVal lpStr As String, ByVal nCount As Integer, ByRef lpRect As RECT, ByVal wFormat As Integer) As Integer
	Private Const DT_WORDBREAK As Integer = &H10
	
	Dim m_sngTwipsX As Single
	Dim m_sngTwipsY As Single
	
	Dim m_strTips() As String
	Dim m_intTipsPos As Short
	Dim m_lngTipsNum As Integer
	
	'UPGRADE_WARNING: �C�x���g chkNextDisp.CheckStateChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub chkNextDisp_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkNextDisp.CheckStateChanged
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim lngArg As Integer
		
		For i = 0 To frmMain.mnuLanguage.UBound
			
			If frmMain.mnuLanguage(i).Checked Then
				
				If g_strLangFileName(i) <> "japanese.ini" Then
					
					Exit Sub
					
				End If
				
				Exit For
				
			End If
			
		Next i
		
		If chkNextDisp.CheckState = 0 Then
			
			lngTemp = MsgBoxResult.Retry
			Call Randomize()
			
			Do While lngTemp = MsgBoxResult.Retry
				
				If Int(Rnd() * 256) = 0 Then
					
					Call MsgBox("�悭�킩��Ȃ����Ǒ����G���[���������܂����B" & vbCrLf & "����� Tips ��\�����܂��B", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, g_strAppTitle)
					
					chkNextDisp.CheckState = System.Windows.Forms.CheckState.Checked
					chkNextDisp.Enabled = False
					
					Exit Do
					
				End If
				
				lngTemp = Int(Rnd() * 32) + 1
				
				If lngTemp Mod 32 = 0 Then
					
					lngArg = MsgBoxStyle.Exclamation
					
				ElseIf lngTemp Mod 16 = 0 Then 
					
					lngArg = MsgBoxStyle.Information
					
				ElseIf lngTemp Mod 8 = 0 Then 
					
					lngArg = MsgBoxStyle.Critical
					
				Else
					
					lngArg = MsgBoxStyle.Question
					
				End If
				
				If Int(Rnd() * 64) = 0 Then
					
					lngArg = lngArg Or MsgBoxStyle.MsgBoxRight
					
				End If
				
				If Int(Rnd() * 128) = 0 Then
					
					lngArg = lngArg Or MsgBoxStyle.MsgBoxRtlReading
					
				End If
				
				lngTemp = MsgBox("�{���ɁH", MsgBoxStyle.AbortRetryIgnore Or lngArg, g_strAppTitle)
				
			Loop 
			
			Select Case lngTemp
				
				Case MsgBoxResult.Abort
					
					chkNextDisp.CheckState = System.Windows.Forms.CheckState.Checked
					
			End Select
			
		End If
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		
		Call Me.Close()
		
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		
		m_intTipsPos = m_intTipsPos + 1
		
		If m_intTipsPos > UBound(m_strTips) Then m_intTipsPos = 1
		
		'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Line �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		frmWindowTips.Line (5400, 360) - Step(180, 150), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White), BF
		
		With Me
			
			.Font = VB6.FontChangeSize(.Font, 9)
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.CurrentX �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			.CurrentX = 5400
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.CurrentY �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			.CurrentY = 345
			
			'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Print �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			frmWindowTips.Print(VB.Right(" " & m_intTipsPos, 2))
			
			.Font = VB6.FontChangeSize(.Font, 12)
			
		End With
		
		'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Line �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		frmWindowTips.Line (945, 720) - (6030, 3240), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White), BF
		
		'UPGRADE_ISSUE: PictureBox �v���p�e�B picIcon.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		Call BitBlt(Me.hdc, 240 * m_sngTwipsX / VB6.TwipsPerPixelX, 240 * m_sngTwipsY / VB6.TwipsPerPixelY, 32, 32, picIcon.hdc, 0, 32, SRCCOPY)
		
		m_lngTipsNum = 0
		
	End Sub
	
	'UPGRADE_WARNING: Form �C�x���g frmWindowTips.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub frmWindowTips_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		With Me
			
			.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(frmMain.Left) + (VB6.PixelsToTwipsX(frmMain.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
			.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frmMain.Top) + (VB6.PixelsToTwipsY(frmMain.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)
			
		End With
		
		m_sngTwipsX = 15 / VB6.TwipsPerPixelX
		m_sngTwipsY = 15 / VB6.TwipsPerPixelY
		
		m_intTipsPos = 0
		
		ReDim m_strTips(0)
		
		m_strTips(0) = " ���ꂩ�� Tips ��\�����܂��B" & vbCrLf & vbCrLf & " �����̏��͂��Ȃ��� BMSE ���g�� BMS ���쐬����̂��菕�����Ă���邱�Ƃ����邩������܂���B" & vbCrLf & vbCrLf & " �u���ցv�̃{�^���������� Tips ���J�n���Ă��������B" & vbCrLf & vbCrLf & " (���̕��͈͂�x�����\������܂���)"
		
		Call AddTutorial(" BMSE �� UCN-Soft ���J�����Ă��܂��B" & vbCrLf & vbCrLf & " UCN �̗R���͒����փl�^�Ȃ̂œ����ł��I")
		Call AddTutorial(" BMSE �� BMx Sequence Editor �̗��ł��B�m��Ȃ��F�B��������L�߂悤�I")
		Call AddTutorial(" BMSE �� bms �t�@�C���Abme �t�@�C���Abml �t�@�C������� pms �t�@�C���������o�����Ƃ��ł��܂��B")
		Call AddTutorial(" bms �̐������̂� Be-Music Script �ȂǏ�������܂����A�^���͓�̂܂܂ł��B")
		Call AddTutorial(" BMSE ���g�p����ɂ́A�܂� Windows OS �̑���ɏK�n����K�v������܂��B" & vbCrLf & vbCrLf & " �}�E�X�͕Ў�Ŏ����A��ʏ�̃|�C���^�𑀍삵�܂��B�f�B�X�v���C���w�łȂ���킯�ł͂���܂���B")
		Call AddTutorial(" �I�u�W�F��z�u����ɂ̓X�N���[�������N���b�N���܂��B" & vbCrLf & vbCrLf & " ���N���b�N�̎d���ɂ��ẮA���g���� OS �̃}�j���A�������ǂ݂��������B" & vbCrLf & vbCrLf & " (BMSE �̓}�E�X���K�{�ł�)")
		Call AddTutorial(" �I�u�W�F���z�u�ł��Ȃ��H�����S���c�[���ɂȂ��Ă��܂��񂩁H")
		Call AddTutorial(" �E���ɕ\������Ă���e�L�X�g�E�{�b�N�X�ɂ͔C�ӂ̕��������͂��܂��B" & vbCrLf & vbCrLf & " ���������͂���ɂ̓L�[�{�[�h���K�v�ł��̂ŁA���g���� OS �y�ь���c�[���̃}�j���A�������ǂ݂��������B")
		Call AddTutorial(" GENRE �́u�W�������v�Ɠǂ݁A�I�Ȓ��ɕ\������邨���܂��ȋȂ̌X������͂��܂��B" & vbCrLf & vbCrLf & " �悭�킩��Ȃ����� Techno �ɂ��Ă��������B")
		Call AddTutorial(" bpm �� Beat Per Minute �̗��ŁA1��������̃r�[�g������͂��܂��B" & vbCrLf & vbCrLf & " �悭�킩��Ȃ�����400�ɂ��Ă��������B")
		Call AddTutorial(" TITLE �́u�^�C�g���v�Ɠǂ݂܂��B�p��Łu�薼�v���Ӗ����A�I�Ȓ��ɕ\�������Ȃ̑薼����͂��܂��B" & vbCrLf & vbCrLf & " �悭�킩��Ȃ����͉p�a�����������Ă������� (�p�a�����͂��߂��̏��X�ōw���\�ł�)�B")
		Call AddTutorial(" ARTIST �͒��󂷂�Ɓu�|�p�Ɓv�ƂȂ�܂����A�����ł́u��ҁv����͂��Ă��������B" & vbCrLf & vbCrLf & " �悭�킩��Ȃ����́uDJ �c���v�Ƃ��Ă��������B��: DJ �R�c")
		Call AddTutorial(" PLAYLEVEL �́u���ʂ̓�Փx�v�ł��B�������� 1 �` 7 �� bms �� �f�t�@�N�g�X�^���_�[�h�ł��B" & vbCrLf & vbCrLf & " �悭�킩��Ȃ����̓m�[�g����100�ɂ��Ă��������B")
		Call AddTutorial(" �u��{�v�^�u�ׂ̗Ɂu�g���v�^�u����сu���v�^�u�����邱�Ƃɂ��C�Â��ł����H" & vbCrLf & vbCrLf & " �N���b�N����ΐV���Ȑݒ���s�����Ƃ��\�ɂȂ�܂��B")
		Call AddTutorial(" RANK �͒��󂵂Ă��Ӗ����ʂ��܂���B�u����̌������v�������܂��B" & vbCrLf & vbCrLf & " �悭�킩��Ȃ����� VERY HARD �ɂ��Ă��������B")
		Call AddTutorial(" ���� BMSE �� MOD �ɑΉ����Ă��܂� (���݉B���R�}���h)�B" & vbCrLf & vbCrLf & " ���̐��ǂނɂ̓V�F�A�E�G�A�t�B�[�𕥂��K�v������܂��B" & vbCrLf & vbCrLf & " ���̃\�t�g�E�F�A�͑���E�F�A�ł��B�C�ɓ��������҂ɑ������t���Ă��������B")
		Call AddTutorial(" �e���L�[�������ƁA�r���E�Q�C�c�ƃ��b�Z���W���[�Ń`���b�g���ł��܂��B")
		Call AddTutorial(" �X�N���[���̈�ԍ��ɂ���uBPM�v����сuSTOP�v���[���ɒ��ڂ��Ă��������I" & vbCrLf & vbCrLf & " ���̃��[�����N���b�N���A�P���ɔ��p�p�� (�L�[�{�[�h�̉E�[�ɂ��鋷�������݂̗̂̈���������Ă�������) ����͂��邾���ŁA�v���C���[��|�M���邱�Ƃ��ł��܂��B")
		Call AddTutorial(" BMSE �̓}�E�}�j�ɑΉ����Ă��܂���B�{������I")
		Call AddTutorial(" �Ă��Ƃ葁�� bms �����ɂ́Awav ���g�p�����ɍ��̂���Ԃł��B" & vbCrLf & vbCrLf & " �G��`�����o�ŃX�N���[���ɃI�u�W�F��z�u (���N���b�N) ����� bms �������I�ȒP�ł���H")
		Call AddTutorial(" �u��{�v�^�u�̈�ԏ�ɂ���u�v���C���[�h�v�� Double Play �ɂ��Ă݂܂��傤�B���Ղ̐����{�����A���u�����v���ʂ���邱�Ƃ��ł��܂��B" & vbCrLf & vbCrLf & " �܂��A2 Player ��I�т܂��ƁA���ۂ̃Q�[���Ō��Ղ��������ƂɃX�N���[���̒[�ɕ��􂵂ĕ\������܂��B����ɂ��A���o�I�Ȍ��ʂœ�Փx���}�㏸�����邱�Ƃ��ł��܂�� ")
		Call AddTutorial(" �u���q�v�^�u�� 3 / 6 �ɂ��Ă݂܂��傤�B�V���ȃ��Y���𓾂邱�Ƃ��ł��܂��B")
		Call AddTutorial(" ���[��5�̌��ՂƃX�N���b�`���g�p�������ʂ́ubms�v�ŁA" & vbCrLf & vbCrLf & " 7�̌��ՂƃX�N���b�`���g�p�������ʂ́ubme�v�ŁA" & vbCrLf & vbCrLf & " 4�̃}�E�X���g�p�������ʂ́ummx�v�ŕۑ����܂��傤 (���ݎ�������Ă��܂���)�B")
		Call AddTutorial(" �R�[�������݂Ȃ��� bms �����Ȃ��ł��������B�V�~���ł���\��������܂��B")
		Call AddTutorial(" TOTAL �l��ύX���邱�Ƃɂ��A�Q�[�W�̏㏸����ύX���邱�Ƃ��ł��܂��B" & vbCrLf & vbCrLf & " �ʏ� TOTAL �l�̃f�t�H���g�� bms �̎d�l�ɂ���� 200 + Total Notes �ƌ��߂��Ă��܂����A�ꕔ�d�l�ɑ����Ă��Ȃ��v���C���[������܂��̂ł����ӂ�������� ")
		Call AddTutorial(" VOLWAV �͖�������Ă��܂��񂪁AVOLume of WAVe �̗����Ǝv���܂��B" & vbCrLf & vbCrLf & " �悭�킩��Ȃ�����0�ɂ��A�^�C�g�����u4:33�v�ɂ���Ƃ悢�悤�ł��B")
		Call AddTutorial(" ����� BMSE ����V���ȋ@�\���ǉ�����܂����B" & vbCrLf & vbCrLf & " ��葽���� Tips ��ǂނ��Ƃ��ł��܂��B")
		Call AddTutorial(" ���̃\�t�g�E�F�A�͂����ɂ��o�O�̂悤�ȐU�镑�������邱�Ƃ�����܂����A" & vbCrLf & vbCrLf & " ����������͎d�l�ł�� ")
		Call AddTutorial(" ���̃E�B���h�E�̂ǂ��ł������̂ŁA15��N���b�N���Ă��������B" & vbCrLf & " ....." & vbCrLf & " ...." & vbCrLf & " ..." & vbCrLf & " .." & vbCrLf & " ." & vbCrLf & vbCrLf & " �ق�A�����N���Ȃ��ł��傤�B")
		Call AddTutorial(" �u���q�v�^�u�� 10 / 572 �ɂ��Ă݂܂��傤�B�V���ȃ��Y���𓾂邱�Ƃ��ł��܂��B")
		Call AddTutorial(" BMSE �ō쐬���ꂽ BMS �̓r�[�g���ɂ��ōĐ��ł���ۏ؂͂���܂���B")
		Call AddTutorial(" ����I�Ɍ����T�C�g���������������B" & vbCrLf & vbCrLf & " http://www.killertomatoes.com/")
		Call AddTutorial(" �����Y��ĂȂ����H")
		Call AddTutorial(" BMSE �ɃC�[�X�^�[�G�b�O�͂������܂��� (�{������I)")
		Call AddTutorial(" BMSE �ɃC�[�X�^�[�G�b�O�͂���܂��񂪁ATips ��\������E���e�N������܂��B���Ȃ��͂����������܂������H")
		Call AddTutorial(" �ŐV�ł� BMSE �������[�X����Ă��邩�m�F���Ă��������I" & vbCrLf & vbCrLf & " ���F�B�S���� BMS ������N�[���� BMSE �̂��΂炵���������Ă����悤�I")
		Call AddTutorial(" ���� Tips �̓C�[�X�^�[�G�b�O�ł��B" & vbCrLf & vbCrLf & " ��Q�Ȃ��瓭�����ɍ�������̃\�t�g�E�F�A���݂Ȃ���ɋC�ɓ����Ă���������悤�Atokonats�����]��ł��邱�Ƃł��傤�B")
		
		With Me
			
			'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Line �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			frmWindowTips.Line (120, 120) - Step(720, 3210), RGB(128, 128, 128), BF
			
			'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Line �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			frmWindowTips.Line (855, 120) - Step(5265, 3210), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White), BF
			
			'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Line �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			frmWindowTips.Line (855, 615) - Step(5265, 0), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), BF
			
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.CurrentX �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			.CurrentX = 960
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.CurrentY �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			.CurrentY = 210
			.Font = VB6.FontChangeSize(.Font, 16)
			.Font = VB6.FontChangeBold(.Font, True)
			
			'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Print �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			frmWindowTips.Print("�����m�ł���...")
			
			.Font = VB6.FontChangeSize(.Font, 9)
			.Font = VB6.FontChangeBold(.Font, False)
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.CurrentX �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			.CurrentX = 5400
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.CurrentY �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			.CurrentY = 345
			
			'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Print �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			frmWindowTips.Print(" 0 / " & UBound(m_strTips))
			
			.Font = VB6.FontChangeSize(.Font, 12)
			
			'UPGRADE_ISSUE: PictureBox �v���p�e�B picIcon.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			Call BitBlt(Me.hdc, 240 * m_sngTwipsX / VB6.TwipsPerPixelX, 240 * m_sngTwipsY / VB6.TwipsPerPixelY, 32, 32, picIcon.hdc, 0, 32, SRCCOPY)
			
		End With
		
		'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Line �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		frmWindowTips.Line (960, 720) - (6075, 3270), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White), BF
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		Call DrawText(Me.hdc, m_strTips(0), LenB(StrConv(m_strTips(0), vbFromUnicode)), ddRect(63, 48, 402, 216), DT_WORDBREAK)
		m_lngTipsNum = Len(m_strTips(0))
		
		chkNextDisp.CheckState = System.Windows.Forms.CheckState.Checked
		
		tmrMain.Enabled = True
		
		Call cmdNext.Focus()
		
	End Sub
	
	Private Sub frmWindowTips_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Dim lngSet_ini As Object
		
		If Me.Visible Then Call lngSet_ini("EasterEgg", "Tips", chkNextDisp.CheckState)
		
		'UPGRADE_ISSUE: Event �p�����[�^ Cancel �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' ���N���b�N���Ă��������B
		Cancel = True
		
		tmrMain.Enabled = False
		
		Erase m_strTips
		
		Call Me.Hide()
		
		Call frmMain.picMain.Focus()
		
	End Sub
	
	Private Sub tmrMain_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMain.Tick
		
		Dim strTemp As String
		
		m_lngTipsNum = m_lngTipsNum + 1
		tmrMain.Interval = 100
		
		'UPGRADE_ISSUE: Form ���\�b�h frmWindowTips.Line �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		frmWindowTips.Line (945, 720) - (6030, 3240), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White), BF
		
		If m_lngTipsNum >= Len(m_strTips(m_intTipsPos)) + 1 Then
			
			tmrMain.Interval = 250
			
			'If (m_lngTipsNum \ 2) Mod 2 Then
			If (m_lngTipsNum \ 2) And 1 Then
				
				strTemp = m_strTips(m_intTipsPos)
				
			Else
				
				strTemp = m_strTips(m_intTipsPos) & "_"
				
			End If
			
			'If m_lngTipsNum Mod 2 Then
			If m_lngTipsNum And 1 Then
				
				'Call BitBlt(frmWindowTips.hdc, 16 * m_sngTwipsX, 16 * m_sngTwipsY, 32, 32, picIcon.hdc, 0, 32, SRCCOPY)
				'UPGRADE_ISSUE: PictureBox �v���p�e�B picIcon.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				Call BitBlt(Me.hdc, 240 * m_sngTwipsX / VB6.TwipsPerPixelX, 240 * m_sngTwipsY / VB6.TwipsPerPixelY, 32, 32, picIcon.hdc, 0, 32, SRCCOPY)
				
			Else
				
				'Call BitBlt(frmWindowTips.hdc, 16 * m_sngTwipsX, 16 * m_sngTwipsY, 32, 32, picIcon.hdc, 0, 0, SRCCOPY)
				'UPGRADE_ISSUE: PictureBox �v���p�e�B picIcon.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				Call BitBlt(Me.hdc, 240 * m_sngTwipsX / VB6.TwipsPerPixelX, 240 * m_sngTwipsY / VB6.TwipsPerPixelY, 32, 32, picIcon.hdc, 0, 0, SRCCOPY)
				
			End If
			
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			Call DrawText(Me.hdc, strTemp, LenB(StrConv(strTemp, vbFromUnicode)), ddRect(63, 48, 402, 216), DT_WORDBREAK)
			
		Else
			
			strTemp = VB.Left(m_strTips(m_intTipsPos), m_lngTipsNum) & "_"
			
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: Form �v���p�e�B frmWindowTips.hdc �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			Call DrawText(Me.hdc, strTemp, LenB(StrConv(strTemp, vbFromUnicode)), ddRect(63, 48, 402, 216), DT_WORDBREAK)
			
			Select Case VB.Right(strTemp, 2)
				
				Case vbCrLf & "_"
					
					tmrMain.Interval = 1
					
				Case " _"
					
					tmrMain.Interval = 50
					
				Case "�A_", "(_", ")_", "�u_", "�v_", "�`_"
					
					tmrMain.Interval = 200
					
				Case "�B_", "�I_", "�H_", ":_", "/_", "._"
					
					tmrMain.Interval = 400
					
			End Select
			
		End If
		
	End Sub
	
	Private Function ddRect(ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As RECT
		
		With ddRect
			.Top = Y1 * m_sngTwipsY
			.left_Renamed = X1 * m_sngTwipsX
			.right_Renamed = X2 * m_sngTwipsX
			.Bottom = Y2 * m_sngTwipsY
		End With
		
	End Function
	
	'UPGRADE_NOTE: str �� str_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub AddTutorial(ByRef str_Renamed As String)
		
		ReDim Preserve m_strTips(UBound(m_strTips) + 1)
		
		m_strTips(UBound(m_strTips)) = str_Renamed
		
	End Sub
End Class
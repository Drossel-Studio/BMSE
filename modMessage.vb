Option Strict Off
Option Explicit On
Module modMessage
	
	' ---------- �W�����W���[�� ----------
	Private Structure COPYDATASTRUCT
		Dim dwData As Integer
		Dim cbData As Integer
		Dim lpData As Integer
	End Structure
	
	'�T�u�N���X���֐�
	Private Declare Function SetWindowLong Lib "user32"  Alias "SetWindowLongA"(ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
	Private Declare Function CallWindowProc Lib "user32"  Alias "CallWindowProcA"(ByVal lpPrevWndFunc As Integer, ByVal hwnd As Integer, ByVal MSG As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
	Private Declare Function GetActiveWindow Lib "user32" () As Integer
	
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	Public Declare Function SendMessage Lib "user32"  Alias "SendMessageA"(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Any) As Integer
	
	Private Const GWL_WNDPROC As Short = (-4) '�E�C���h�E�v���V�[�W��
	
	Private Const WM_ACTIVATE As Integer = &H6
	Private Const WM_ACTIVATEAPP As Integer = &H1C
	Private Const WM_SETCURSOR As Integer = &H20
	Private Const WM_KEYDOWN As Integer = &H100
	Private Const WM_SYSCOMMAND As Integer = &H112
	Private Const WM_HSCROLL As Integer = &H114
	Private Const WM_VSCROLL As Integer = &H115
	Private Const WM_CTLCOLORSCROLLBAR As Integer = &H137
	Private Const WM_MOUSEWHEEL As Integer = &H20A
	
	Public Const WM_CUT As Integer = &H300
	Public Const WM_COPY As Integer = &H301
	Public Const WM_PASTE As Integer = &H302
	Public Const WM_CLEAR As Integer = &H303
	Public Const WM_UNDO As Integer = &H304
	
	Private Const MM_MCINOTIFY As Integer = &H3B9
	
	Private Const MCI_NOTIFY_SUCCESSFUL As Short = 1
	Private Const MCI_NOTIFY_SUPERSEDED As Short = 2
	Private Const MCI_NOTIFY_ABORTED As Short = 4
	Private Const MCI_NOTIFY_FAILURE As Short = 8
	
	Private Const WA_ACTIVE As Short = 1
	Private Const WA_CLICKACTIVE As Short = 2
	Private Const WA_INACTIVE As Short = 0
	
	Private Const SB_LINEUP As Short = 0
	Private Const SB_LINEDOWN As Short = 1
	Private Const SB_PAGEUP As Short = 2
	Private Const SB_PAGEDOWN As Short = 3
	Private Const SB_THUMBPOSITION As Short = 4
	Private Const SB_THUMBTRACK As Short = 5
	Private Const SB_TOP As Short = 6
	Private Const SB_BOTTOM As Short = 7
	Private Const SB_ENDSCROLL As Short = 8
	
	'�f�t�H���g�̃E�C���h�E�v���V�[�W��
	Public OldWindowhWnd As Integer
	
	
	'---------------------------------------------------------------------------
	' �֐����F SubClass
	' �@�\ �F �T�u�N���X�����J�n����
	' ���� �F (in) hWnd �c �Ώۃt�H�[���̃E�C���h�E�n���h��
	' �Ԃ�l �F �Ȃ�
	'---------------------------------------------------------------------------
	Public Sub SubClass(ByVal hwnd As Integer)
		
		
		'UPGRADE_WARNING: AddressOf WindowProc �� delegate ��ǉ����� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' ���N���b�N���Ă��������B
		OldWindowhWnd = SetWindowLong(hwnd, GWL_WNDPROC, AddressOf WindowProc)
		
		
	End Sub
	
	
	'---------------------------------------------------------------------------
	' �֐����F UnSubClass
	' �@�\ �F �T�u�N���X�����I������
	' ���� �F (in) hWnd �c �Ώۃt�H�[���̃E�C���h�E�n���h��
	' �Ԃ�l �F �Ȃ�
	'---------------------------------------------------------------------------
	Public Sub UnSubClass(ByVal hwnd As Integer)
		
		
		Dim ret As Integer
		
		
		If OldWindowhWnd <> 0 Then
			
			'���̃v���V�[�W���A�h���X�ɐݒ肷��
			ret = SetWindowLong(hwnd, GWL_WNDPROC, OldWindowhWnd)
			
			
			OldWindowhWnd = 0
			
		End If
		
		
	End Sub
	
	'---------------------------------------------------------------
	' �֐����F strNullCut
	' �@�\ �F ������� vbNullChar �܂ł��擾����
	' ���� �F (in) srcStr �c �Ώە�����
	' �Ԃ�l �F�ҏW���ꂽ������
	'---------------------------------------------------------------
	Public Function strNullCut(ByVal srcStr As String) As String
		
		
		Dim NullCharPos As Short
		
		
		NullCharPos = InStr(srcStr, Chr(0))
		
		
		If NullCharPos = 0 Then
			
			strNullCut = srcStr
			
			Exit Function
			
		End If
		
		
		strNullCut = Left(srcStr, NullCharPos - 1)
		
		
	End Function
	
	
	'���́A��M���鑤�̃R�[�h�B������擾���@�͎擾����������ւ̃|�C���^��� NULL �܂ł̒������擾���A���̒������o�C�g�P�ʂŃR�s�[���Ă��΂悢�B
	
	
	
	'-------------------------------------------------------------------------
	' �֐����F WindowProc
	' �@�\ �F �E�C���h�E���b�Z�[�W���t�b�N����
	' ���� �F (in) hWnd �c �Ώۃt�H�[���̃E�C���h�E�n���h��
	'�@�@�@�@�@(in) uMsg �c �E�C���h�E���b�Z�[�W
	'�@�@�@�@�@(in) wParam �c �ǉ����P
	'�@�@�@�@�@(in) lParam �c �ǉ����Q
	' �Ԃ�l �F �Ȃ�
	' ���l �F ���ɂȂ�
	'---------------------------------------------------------------------------
	Public Function WindowProc(ByVal hwnd As Integer, ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
		
		
		'Dim udtCDP As COPYDATASTRUCT
		'Dim SentText As String '�����Ă���������
		'Dim SentTextLen As Long '�����Ă���������̐�
		
		Dim lngTemp As Integer
		
		
		If frmMain.Handle.ToInt32 = GetActiveWindow() Then
			
			Select Case uMsg
				
				Case WM_ACTIVATEAPP
					
					If wParam Then
						
						If frmMain.mnuOptionsItem(frmMain.MENU_OPTIONS.IGNORE_INPUT).Checked Then g_blnIgnoreInput = True
						
					End If
					
				Case WM_SETCURSOR
					
					If wParam <> frmMain.picMain.Handle.ToInt32 Then
						
						g_Obj(UBound(g_Obj)).intCh = 0
						
						frmMain.staMain.Items.Item("Position").Text = "Position:"
						
						'Call frmMain.picMain.Cls
						Call modEasterEgg.DrawEffect()
						
						Select Case wParam
							
							Case frmMain.lstWAV.Handle.ToInt32
								
								Call frmMain.lstWAV.Focus()
								
							Case frmMain.lstBMP.Handle.ToInt32
								
								Call frmMain.lstBMP.Focus()
								
							Case frmMain.lstBGA.Handle.ToInt32
								
								Call frmMain.lstBGA.Focus()
								
							Case frmMain.lstMeasureLen.Handle.ToInt32
								
								Call frmMain.lstMeasureLen.Focus()
								
						End Select
						
					Else
						
						'Call frmMain.vsbMain.SetFocus
						Call frmMain.picMain.Focus()
						
					End If
					
				Case WM_MOUSEWHEEL
					
					If HWORD(wParam) > 0 Then
						
						lngTemp = SB_LINEUP
						
					Else
						
						lngTemp = SB_LINEDOWN
						
					End If
					
					Call WindowProc(frmMain.Handle.ToInt32, WM_VSCROLL, lngTemp, frmMain.vsbMain.Handle.ToInt32)
					Call WindowProc(frmMain.Handle.ToInt32, WM_VSCROLL, SB_ENDSCROLL, frmMain.vsbMain.Handle.ToInt32)
					
				Case MM_MCINOTIFY
					
					If wParam = MCI_NOTIFY_SUCCESSFUL Then
						
						Call mciSendString("close PREVIEW", vbNullString, 0, 0)
						
					End If
					
				Case WM_CTLCOLORSCROLLBAR '�X�N���[���o�[�ςȐF�΍�
					
					Exit Function
					
			End Select
			
			'Debug.Print uMsg, wParam, lParam, frmMain.hsbMain.hwnd
			
		End If
		
		WindowProc = CallWindowProc(OldWindowhWnd, hwnd, uMsg, wParam, lParam)
		
	End Function
	
	Public Function HWORD(ByVal LongValue As Integer) As Short
		
		'�������l�����ʃ��[�h���擾����
		HWORD = (LongValue And &HFFFF0000) \ &H10000
		
	End Function
	
	Public Function LWORD(ByVal LongValue As Integer) As Short
		
		'�������l���牺�ʃ��[�h���擾����
		If (LongValue And &HFFFF) > &H7FFF Then
			
			LWORD = CShort(LongValue And &HFFFF) - &H10000
			
		Else
			
			LWORD = LongValue And &HFFFF
			
		End If
		
	End Function
End Module
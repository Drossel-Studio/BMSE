Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6

Friend Class frmMain
	Inherits System.Windows.Forms.Form
	
	Public Enum MENU_VIEW
		TOOL_BAR
		DIRECT_INPUT
		STATUS_BAR
		Max
	End Enum
	
	Public Enum MENU_OPTIONS
		IGNORE_INPUT
		TITLE_FILENAME
		VERTICAL_INFO
		LANE_BGCOLOR
		SELECT_PREVIEW
		MOVE_ON_GRID
		OBJ_FILENAME
		USE_OLD_FORMAT
		'RCLICK_DELETE
		Max
	End Enum
	
	Private m_intScrollDir As Short
	
	Private m_tempObj() As g_udtObj
	
	Private m_blnMouseDown As Boolean
	
	Private m_blnPreview As Boolean
	
	Private m_blnIgnoreMenu As Boolean
	
	'UPGRADE_NOTE: str �� str_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Public Function lngFromString(ByRef str_Renamed As String) As Integer
		
		'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
		
		'lngFromString = Val("&H" & str)
		
		'Else
		
		lngFromString = modInput.strToNum(str_Renamed)
		
		'End If
		
	End Function
	
	Public Function lngFromLong(ByVal value As Integer) As Integer
		
		'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
		
		'lngFromLong = modInput.strToNum(strFromLong(value))
		
		'Else
		
		lngFromLong = value
		
		'End If
		
	End Function
	
	Public Function strFromLong(ByVal value As Integer) As String
		
		'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
		
		'strFromLong = right$("0" & Hex$(value), 2)
		
		'Else
		
		strFromLong = modInput.strFromNum(value)
		
		'End If
		
	End Function
	
	Private Sub MoveObj(ByVal X As Single, ByVal Y As Single, ByVal Shift As Short)
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim j As Integer
		Dim k As Integer
		Dim lngTemp As Integer
		Dim oldObj As g_udtObj
		Dim newObj As g_udtObj
		
		With newObj
			
			Call modDraw.SetObjData(newObj, X, Y) ', g_disp.X, g_disp.Y)
			
			.intCh = g_intVGridNum(.intCh)
			
			'If Not Shift And vbAltMask Then
			
			'�O���b�h�ɂ��킹��
            If VB6.GetItemData(Me.cboDispGridSub, Me.cboDispGridSub.SelectedIndex) Then
                lngTemp = 192 \ (VB6.GetItemData(Me.cboDispGridSub, Me.cboDispGridSub.SelectedIndex))
                .lngPosition = (.lngPosition \ lngTemp) * lngTemp

                'If Not Shift And vbShiftMask Then

                If Me.mnuOptionsItem(MENU_OPTIONS.MOVE_ON_GRID).Checked Then

                    With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                        lngTemp = .lngPosition - (.lngPosition \ lngTemp) * lngTemp

                    End With

                    .lngPosition = .lngPosition - lngTemp

                End If

                'End If

            End If
			
			'End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lngPosition = .lngPosition + g_Measure(.intMeasure).lngY
			
		End With
		
		'UPGRADE_WARNING: �I�u�W�F�N�g oldObj �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		oldObj = g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
		
		With oldObj
			
			.intCh = g_intVGridNum(.intCh)
			
			'If Not Shift And vbAltMask Then
			
			If VB6.GetItemData(Me.cboDispGridSub, Me.cboDispGridSub.SelectedIndex) Then
				
				lngTemp = 192 \ VB6.GetItemData(Me.cboDispGridSub, Me.cboDispGridSub.SelectedIndex)
				.lngPosition = (.lngPosition \ lngTemp) * lngTemp
				
			End If
			
			'End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.lngPosition = .lngPosition + g_Measure(.intMeasure).lngY
			
		End With
		
		'Y ���Œ�ړ�
		If Shift And VB6.ShiftConstants.ShiftMask Then
			
			newObj.lngPosition = oldObj.lngPosition
			
		End If
		
		'�ړ����Ă���H
		If newObj.intCh <> oldObj.intCh Or newObj.lngPosition <> oldObj.lngPosition Then
			
			'�E�Ɉړ�
			If newObj.intCh > oldObj.intCh Then
				
				For j = oldObj.intCh To newObj.intCh - 1
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(j).intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(j).blnDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If g_VGrid(j).blnDraw = True And g_VGrid(j).intCh <> 0 Then
						
						newObj.intAtt = newObj.intAtt + 1
						
					End If
					
				Next j
				
			ElseIf newObj.intCh < oldObj.intCh Then  '���Ɉړ�
				
				For j = oldObj.intCh To newObj.intCh + 1 Step -1
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(j).intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(j).blnVisible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If g_VGrid(j).blnVisible = True And g_VGrid(j).intCh <> 0 Then
						
						newObj.intAtt = newObj.intAtt + 1
						
					End If
					
				Next j
				
			End If
			
			lngTemp = newObj.intCh <> oldObj.intCh And newObj.intCh <> 0 And oldObj.intCh <> 0 And newObj.intCh <> UBound(g_VGrid) And oldObj.intCh <> UBound(g_VGrid)
			
			For i = 0 To UBound(g_Obj) - 1
				
				With g_Obj(i)
					
					'�I��
					'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .intSelect = modMain.OBJ_SELECT.Selected Then
						
						'Y ���ړ�
						.lngPosition = .lngPosition + newObj.lngPosition - oldObj.lngPosition
						
						'���߂͂܂����ł��Ȃ����H
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(g_Obj(i).intMeasure).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Do While .lngPosition >= g_Measure(.intMeasure).intLen
							
							If .intMeasure < 999 Then
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(g_Obj(i).intMeasure).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.lngPosition = .lngPosition - g_Measure(.intMeasure).intLen
								.intMeasure = .intMeasure + 1
								
							Else
								
								.intMeasure = 999
								
								Exit Do
								
							End If
							
						Loop 
						
						'�t�ɏ��߂�؂��Ă��Ȃ����H
						Do While .lngPosition < 0
							
							If .intMeasure > 0 Then
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.lngPosition = g_Measure(.intMeasure - 1).intLen + .lngPosition
								.intMeasure = .intMeasure - 1
								
							Else
								
								.intMeasure = 0
								
								Exit Do
								
							End If
							
						Loop 
						
						'�ړ����Ă��邪�A�ʒu�͉E�[�ł����[�ł��Ȃ�
						If lngTemp Then
							
							If .intCh < 0 Then
								
								j = .intCh
								
							ElseIf .intCh > 1000 Then 
								
								j = .intCh - 1000
								
							Else
								
								j = g_intVGridNum(.intCh)
								
							End If
							
							If newObj.intCh > oldObj.intCh Then '�E�Ɉړ�
								
								'�ړ��ʕ����[�v
								For k = 1 To newObj.intAtt
									
									'�\������Ă��郌�[�����`�F�b�N
									Do 
										
										j = j + 1
										
										If j < 0 Or j > UBound(g_VGrid) Then Exit Do
										
										'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(j).intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(j).blnVisible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If g_VGrid(j).blnVisible = True And g_VGrid(j).intCh <> 0 Then
											
											Exit Do
											
										End If
										
									Loop 
									
								Next k
								
							Else '���Ɉړ�
								
								For k = 1 To newObj.intAtt
									
									Do 
										
										j = j - 1
										
										If j < 0 Or j > UBound(g_VGrid) Then Exit Do
										
										'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(j).intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(j).blnVisible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If g_VGrid(j).blnVisible = True And g_VGrid(j).intCh <> 0 Then
											
											Exit Do
											
										End If
										
									Loop 
									
								Next k
								
							End If
							
							'0�����̎��͉��ʒu�Ƃ��ă}�C�i�X�����Ă�
							If j < 0 Then
								
								.intCh = j
								
							ElseIf j > UBound(g_VGrid) Then  '�ő�l�ȏ�Ȃ牼�ʒu�Ƃ���1000�ȏ�����Ă�
								
								.intCh = 1000 + j
								
							Else '����ȊO�Ȃ畁�ʂɐݒ�
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid().intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intCh = g_VGrid(j).intCh
								
							End If
							
							'�`�����l���ɂ���ē���ȑ��삪�K�v�H
							Select Case .intCh
								
								Case 8
									
									'�������Ȃ�
									
								Case 9
									
									.sngValue = CInt(.sngValue)
									
									If .sngValue < 0 Then
										
										.sngValue = 1
										
									End If
									
								Case Else
									
									.sngValue = CInt(.sngValue)
									
									If .sngValue < 0 Then
										
										.sngValue = 1
										
									ElseIf .sngValue > 1295 Then 
										
										.sngValue = 1295
										
									End If
									
							End Select
							
						End If
						
					End If
					
				End With
				
			Next i
			
			'Call modDraw.DrawStatusBar(g_Obj(UBound(g_Obj)).lngHeight, Shift)
			Call modDraw.DrawStatusBar(g_Obj(g_Obj(UBound(g_Obj)).lngHeight), Shift)
			
			'Call SaveChanges
			
			Call modDraw.Redraw()
			
		End If
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "MoveObj")
	End Sub
	
	Public Sub PreviewBMP(ByRef strFileName As String)
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		If m_blnPreview = False Then Exit Sub
		
		With frmWindowPreview
			
			If .chkLock.CheckState Then Exit Sub
			
			'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
			
			'.txtBGAPara(BGA_NUM).Text = Right$("0" & Hex$(lstBMP.ListIndex + 1), 2)
			'.Caption = Right$("0" & Hex$(lstBMP.ListIndex + 1), 2) & ":" & strFileName
			
			'Else
			
			'.txtBGAPara(BGA_NUM).Text = modInput.strFromNum(lstBMP.ListIndex + 1)
			'.Caption = modInput.strFromNum(lstBMP.ListIndex + 1) & ":" & strFileName
			
			'End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.txtBGAPara(modMain.BGA_PARA.BGA_NUM).Text = strFromLong(lstBMP.SelectedIndex + 1)
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Text = .txtBGAPara(modMain.BGA_PARA.BGA_NUM).Text & ":" & strFileName
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Mid(strFileName, 2, 2) <> ":\" Then strFileName = g_BMS.strDir & strFileName
			
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Len(strFileName) <> 0 And strFileName <> g_BMS.strDir And Dir(strFileName, FileAttribute.Normal) <> vbNullString Then
				
				.picBackBuffer.Image = System.Drawing.Image.FromFile(strFileName)
				
			Else
				
				.picBackBuffer.Image = Nothing
				
			End If
			
			If .picBackBuffer.ClientRectangle.Width <= 256 Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_X1).Text = CStr(0)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_X2).Text = CStr(.picBackBuffer.ClientRectangle.Width)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_dX).Text = CStr((256 - .picBackBuffer.ClientRectangle.Width) \ 2)
				
			Else
				
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_X1).Text = CStr((.picBackBuffer.ClientRectangle.Width - 256) \ 2)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_X2).Text = CStr(CDbl(.txtBGAPara(modMain.BGA_PARA.BGA_X1).Text) + 256)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_dX).Text = CStr(0)
				
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.txtBGAPara(modMain.BGA_PARA.BGA_Y1).Text = CStr(0)
			
			If .picBackBuffer.ClientRectangle.Height >= 256 Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_Y2).Text = CStr(256)
				
			Else
				
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_Y2).Text = CStr(.picBackBuffer.ClientRectangle.Height)
				
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.txtBGAPara(modMain.BGA_PARA.BGA_dY).Text = CStr(0)
			
			Call .picPreview_Paint()
			
		End With
		
Err_Renamed: 
	End Sub
	
	Private Sub PreviewBGA(ByVal lngFileNum As Integer)
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim strTemp As String
		Dim strArray() As String
		
		If m_blnPreview = False Then Exit Sub
		
		With frmWindowPreview
			
			If .chkLock.CheckState Then Exit Sub
			
			'strTemp = Trim$(Mid$(lstBGA.List(lstBGA.ListIndex), 8))
			strTemp = g_strBGA(lngFileNum)
			strArray = Split(strTemp, " ")
			
			If Len(strTemp) Then
				
				strTemp = g_strBMP(modInput.strToNum(strArray(0)))
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Mid(strTemp, 2, 2) <> ":\" Then strTemp = g_BMS.strDir & strTemp
				
				'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				If Dir(strTemp, FileAttribute.Normal) <> vbNullString Then
					
					.picBackBuffer.Image = System.Drawing.Image.FromFile(strTemp)
					
				Else
					
					.picBackBuffer.Image = Nothing
					
				End If
				
			Else
				
				.picBackBuffer.Image = Nothing
				
			End If
			
			If UBound(strArray) > 5 Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_NUM).Text = strArray(0)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_X1).Text = strArray(1)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CDbl(.txtBGAPara(modMain.BGA_PARA.BGA_X1).Text) < 0 Then .txtBGAPara(modMain.BGA_PARA.BGA_X1).Text = CStr(0)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_Y1).Text = strArray(2)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CDbl(.txtBGAPara(modMain.BGA_PARA.BGA_Y1).Text) < 0 Then .txtBGAPara(modMain.BGA_PARA.BGA_Y1).Text = CStr(0)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_X2).Text = strArray(3)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CDbl(.txtBGAPara(modMain.BGA_PARA.BGA_X2).Text) < 0 Then .txtBGAPara(modMain.BGA_PARA.BGA_X2).Text = CStr(0)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_Y2).Text = strArray(4)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CDbl(.txtBGAPara(modMain.BGA_PARA.BGA_Y2).Text) < 0 Then .txtBGAPara(modMain.BGA_PARA.BGA_Y2).Text = CStr(0)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_dX).Text = strArray(5)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CDbl(.txtBGAPara(modMain.BGA_PARA.BGA_dX).Text) < 0 Then .txtBGAPara(modMain.BGA_PARA.BGA_dX).Text = CStr(0)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtBGAPara(modMain.BGA_PARA.BGA_dY).Text = strArray(6)
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.BGA_PARA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CDbl(.txtBGAPara(modMain.BGA_PARA.BGA_dY).Text) < 0 Then .txtBGAPara(modMain.BGA_PARA.BGA_dY).Text = CStr(0)
				
				'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
				
				'.Caption = Right$("0" & Hex$(lstBGA.ListIndex + 1), 2) & ":" & strTemp
				
				'Else
				
				'.Caption = modInput.strFromNum(lstBGA.ListIndex + 1) & ":" & strTemp
				
				'End If
				
				.Text = strFromLong(lstBGA.SelectedIndex + 1) & ":" & strTemp
				
			End If
			
			Call .picPreview_Paint()
			
		End With
		
Err_Renamed: 
	End Sub
	
	Private Sub PreviewWAV(ByRef strFileName As String)
		On Error GoTo Err_Renamed
		
		Dim lngError As Integer
		Dim strError As New VB6.FixedLengthString(256)
		Dim strTemp As String
		
		If m_blnPreview = False Then Exit Sub
		
		If Mid(strFileName, 2, 2) <> ":\" Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strFileName = g_BMS.strDir & strFileName
			
		End If
		
		Call mciSendString("close PREVIEW", vbNullString, 0, 0)
		
		Dim strArray() As String
		strArray = Split(strFileName, ".")
		
		Select Case UCase(strArray(UBound(strArray)))
			Case "WAV" : strTemp = " type WaveAudio"
			Case "MP3", "OGG" : strTemp = " type MPEGVideo"
		End Select
		
		lngError = mciSendString("open " & Chr(34) & strFileName & Chr(34) & strTemp & " alias PREVIEW", vbNullString, 0, 0)
		
		If lngError Then
			
			If mciGetErrorString(lngError, strError.Value, 256) Then
				
				strTemp = VB.Left(strError.Value, InStr(strError.Value, Chr(0)) - 1)
				
			Else
				
				strTemp = "�s���ȃG���[�ł��B"
				
			End If
			
			'Call modMain.DebugOutput(lngError, strTemp & Chr$(34) & strFileName & Chr$(34), "PreviewWAV", False)
			
		End If
		
		Call mciSendString("play PREVIEW notify", vbNullString, 0, Me.Handle.ToInt32)
		
Err_Renamed: 
	End Sub
	
	'UPGRADE_ISSUE: VBRUN.DataObject �^ �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Private Sub FormDragDrop(ByVal Data As Object)
		Dim modMain As Object
		Dim lngDeleteFile As Object
		
		Dim i As Integer
		Dim strArray() As String
		Dim strTemp As String
		Dim blnReadFlag As Boolean
		
		'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Count �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		For i = 1 To Data.Files.Count
			
			'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Item �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			If Dir(Data.Files.Item(i), FileAttribute.Normal) <> vbNullString Then
				
				'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Item �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
				strTemp = Data.Files.Item(i)
				
				If VB.Right(UCase(strTemp), 4) = ".BMS" Or VB.Right(UCase(strTemp), 4) = ".BME" Or VB.Right(UCase(strTemp), 4) = ".BML" Or VB.Right(UCase(strTemp), 4) = ".PMS" Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g modMain.intSaveCheck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If modMain.intSaveCheck() Or blnReadFlag Then
						
						'UPGRADE_WARNING: App �v���p�e�B App.EXEName �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
						Call ShellExecute(0, "open", Chr(34) & g_strAppDir & My.Application.Info.AssemblyName & Chr(34), Chr(34) & strTemp & Chr(34), "", SW_SHOWNORMAL)
						
					Else
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")
						
						strArray = Split(strTemp, "\")
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_BMS.strFileName = VB.Right(strTemp, Len(strArray(UBound(strArray))))
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_BMS.strDir = VB.Left(strTemp, Len(strTemp) - Len(strArray(UBound(strArray))))
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						dlgMainOpen.InitialDirectory = g_BMS.strDir
						dlgMainSave.InitialDirectory = g_BMS.strDir
						blnReadFlag = True
						
						Call modInput.LoadBMS()
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.RecentFilesRotation �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)
						
					End If
					
				End If
				
			End If
			
		Next i
		
	End Sub
	
	Private Sub CopyToClipboard()
		Dim modMain As Object
		
		Dim i As Integer
		Dim intTemp As Short
		Dim lngTemp As Integer
		Dim strArray() As String
		
		Call My.Computer.Clipboard.Clear()
		
		intTemp = 999
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If .intSelect = modMain.OBJ_SELECT.Selected Then
					
					If .intMeasure < intTemp Then intTemp = .intMeasure
					
					lngTemp = lngTemp + 1
					
				End If
				
			End With
			
		Next i
		
		ReDim strArray(lngTemp - 1)
		lngTemp = 0
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If .intSelect = modMain.OBJ_SELECT.Selected Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(intTemp).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strArray(lngTemp) = VB6.Format(.intCh, "000") & .intAtt & VB6.Format(g_Measure(.intMeasure).lngY + .lngPosition - g_Measure(intTemp).lngY, "0000000") & .sngValue
					lngTemp = lngTemp + 1
					
				End If
				
			End With
			
		Next i
		
		Call My.Computer.Clipboard.SetText("BMSE ClipBoard Object Data Format" & vbCrLf & Join(strArray, vbCrLf) & vbCrLf)
		
	End Sub
	
	Public Sub SaveChanges()
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_BMS.blnSaveFlag = False
		
		Me.Text = g_strAppTitle
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Len(g_BMS.strDir) Then
			
			If mnuOptionsItem(MENU_OPTIONS.TITLE_FILENAME).Checked Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Me.Text = Me.Text & " - " & g_BMS.strFileName
				
			Else
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Me.Text = Me.Text & " - " & g_BMS.strDir & g_BMS.strFileName
				
			End If
			
		End If
		
		Me.Text = Me.Text & " *"
		
	End Sub
	
	Private Function strCmdDecode(ByRef strCmd As String, ByRef strFileName As String) As String
		
		Dim ret As String
		
		ret = strCmd
		
		ret = Replace(ret, "<filename>", Chr(34) & strFileName & Chr(34))
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intStartMeasure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ret = Replace(ret, "<measure>", g_disp.intStartMeasure)
		ret = Replace(ret, "<appdir>", g_strAppDir)
		
		strCmdDecode = ret
		
	End Function
	
	Public Sub RefreshList()
		
		Dim i As Integer
		Dim strTemp As New VB6.FixedLengthString(2)
		Dim lngTemp As Integer
		Dim lngIndex(2) As Integer
		
		lngIndex(0) = lstWAV.SelectedIndex
		lngIndex(1) = lstBMP.SelectedIndex
		lngIndex(2) = lstBGA.SelectedIndex
		
		lstWAV.Visible = False
		lstBMP.Visible = False
		lstBGA.Visible = False
		
		lstWAV.Items.Clear()
		lstBMP.Items.Clear()
		lstBGA.Items.Clear()
		
		For i = 1 To 1295
			
			'strTemp = Right$("0" & Hex$(i), 2)
			'lngTemp = modInput.strToNum(strTemp)
			
			strTemp.Value = modInput.strFromNum(i)
			lngTemp = modInput.strToNum(modInput.strFromNumZZ(i))
			
			VB6.SetItemString(lstWAV, i - 1, "#WAV" & strTemp.Value & ":" & g_strWAV(i))
			VB6.SetItemString(lstBMP, i - 1, "#BMP" & strTemp.Value & ":" & g_strBMP(i))
			VB6.SetItemString(lstBGA, i - 1, "#BGA" & strTemp.Value & ":" & g_strBGA(i))
			
		Next i
		
		'    If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
		'
		'        For i = 1 To 255
		'
		'            'strTemp = Right$("0" & Hex$(i), 2)
		'            'lngTemp = modInput.strToNum(strTemp)
		'
		'            strTemp = strFromLong(i)
		'            lngTemp = lngFromLong(i)
		'
		'            lstWAV.List(i - 1) = "#WAV" & strTemp & ":" & g_strWAV(lngTemp)
		'            lstBMP.List(i - 1) = "#BMP" & strTemp & ":" & g_strBMP(lngTemp)
		'            lstBGA.List(i - 1) = "#BGA" & strTemp & ":" & g_strBGA(lngTemp)
		'
		'        Next i
		'
		'        frmWindowPreview.cmdPreviewEnd.Caption = "FF"
		'
		'    Else
		'
		'        For i = 1 To 1295
		'
		'            strTemp = modInput.strFromNum(i)
		'
		'            lstWAV.List(i - 1) = "#WAV" & strTemp & ":" & g_strWAV(i)
		'            lstBMP.List(i - 1) = "#BMP" & strTemp & ":" & g_strBMP(i)
		'            lstBGA.List(i - 1) = "#BGA" & strTemp & ":" & g_strBGA(i)
		'
		'        Next i
		'
		'        frmWindowPreview.cmdPreviewEnd.Caption = "ZZ"
		'
		'    End If
		
		m_blnPreview = False
		lstWAV.SelectedIndex = lngIndex(0)
		lstBMP.SelectedIndex = lngIndex(1)
		lstBGA.SelectedIndex = lngIndex(2)
		m_blnPreview = True
		
		lstWAV.Visible = True
		lstBMP.Visible = True
		lstBGA.Visible = True
		
	End Sub
	
	Private Sub cboDirectInput_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDirectInput.Enter
		
		VB6.SetDefault(cmdDirectInput, True)
		
	End Sub
	
	Private Sub cboDirectInput_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDirectInput.Leave
		
		VB6.SetDefault(cmdDirectInput, False)
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboDispFrame.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboDispFrame_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispFrame.SelectedIndexChanged
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboDispGridMain.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboDispGridMain_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispGridMain.SelectedIndexChanged
		
		Call modDraw.Redraw()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboDispGridSub.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboDispGridSub_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispGridSub.SelectedIndexChanged
		
		Call modDraw.Redraw()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboDispHeight.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboDispHeight_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispHeight.SelectedIndexChanged
		Dim modMain As Object
		Dim g_Message As Object
		
		Dim i As Integer
		Dim sngTemp As Single
		
		If Me.Visible = False Then Exit Sub
		
		If cboDispHeight.SelectedIndex = cboDispHeight.Items.Count - 1 Then
			
			With frmWindowInput
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.lblMainDisp.Text = g_Message(modMain.Message.INPUT_SIZE)
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Height �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtMain.Text = VB6.Format(g_disp.Height, "#0.00")
				If .txtMain.Text = "100.00" Then .txtMain.Text = "1.00"
				
				Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)
				
				sngTemp = System.Math.Round(Val(.txtMain.Text), 2)
				
				If sngTemp <= 0 Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Height �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					sngTemp = g_disp.Height
					
				ElseIf sngTemp > 16 Then 
					
					sngTemp = 16
					
				End If
				
				For i = 0 To cboDispHeight.Items.Count - 1
					
					If VB6.GetItemData(cboDispHeight, i) = sngTemp * 100 Then
						
						cboDispHeight.SelectedIndex = i
						
						Exit For
						
					ElseIf VB6.GetItemData(cboDispHeight, i) > sngTemp * 100 Then 
						
						Call cboDispHeight.Items.Insert(i, "x" & VB6.Format(sngTemp, "#0.00"))
						VB6.SetItemData(cboDispHeight, i, sngTemp * 100)
						cboDispHeight.SelectedIndex = i
						
						Exit For
						
					End If
					
				Next i
				
			End With
			
		End If
		
		Call modDraw.Redraw()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboDispKey.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboDispKey_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispKey.SelectedIndexChanged
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboDispSC1P.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboDispSC1P_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispSC1P.SelectedIndexChanged
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboDispSC2P.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboDispSC2P_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispSC2P.SelectedIndexChanged
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboDispWidth.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboDispWidth_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispWidth.SelectedIndexChanged
		Dim modMain As Object
		Dim g_Message As Object
		
		Dim i As Integer
		Dim sngTemp As Single
		
		If Me.Visible = False Then Exit Sub
		
		If cboDispWidth.SelectedIndex = cboDispWidth.Items.Count - 1 Then
			
			With frmWindowInput
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.lblMainDisp.Text = g_Message(modMain.Message.INPUT_SIZE)
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Width �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.txtMain.Text = VB6.Format(g_disp.Width, "#0.00")
				If .txtMain.Text = "100.00" Then .txtMain.Text = "1.00"
				
				Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)
				
				sngTemp = System.Math.Round(Val(.txtMain.Text), 2)
				
				If sngTemp <= 0 Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Width �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					sngTemp = g_disp.Width
					
				ElseIf sngTemp > 16 Then 
					
					sngTemp = 16
					
				End If
				
				For i = 0 To cboDispWidth.Items.Count - 1
					
					If VB6.GetItemData(cboDispWidth, i) = sngTemp * 100 Then
						
						cboDispWidth.SelectedIndex = i
						
						Exit For
						
					ElseIf VB6.GetItemData(cboDispWidth, i) > sngTemp * 100 Then 
						
						Call cboDispWidth.Items.Insert(i, "x" & VB6.Format(sngTemp, "#0.00"))
						VB6.SetItemData(cboDispWidth, i, sngTemp * 100)
						cboDispWidth.SelectedIndex = i
						
						Exit For
						
					End If
					
				Next i
				
			End With
			
		End If
		
		Call modDraw.Redraw()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboPlayer.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboPlayer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPlayer.SelectedIndexChanged
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g cboVScroll.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub cboVScroll_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboVScroll.SelectedIndexChanged
		Dim NewLargeChange As Short
		
		vsbMain.SmallChange = VB6.GetItemData(cboVScroll, cboVScroll.SelectedIndex)
		NewLargeChange = Me.vsbMain.SmallChange * 8
		vsbMain.Maximum = vsbMain.Maximum + NewLargeChange - vsbMain.LargeChange
		vsbMain.LargeChange = NewLargeChange
		
	End Sub
	
	Private Sub cmdBGAExcDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBGAExcDown.Click
		
		Call cmdBMPExcDown_Click(cmdBMPExcDown, New System.EventArgs())
		
	End Sub
	
	Private Sub cmdBGAExcUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBGAExcUp.Click
		
		Call cmdBMPExcUp_Click(cmdBMPExcUp, New System.EventArgs())
		
	End Sub
	
	Private Sub cmdBGAPreview_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBGAPreview.Click
		
		Call PreviewBGA(lstBGA.SelectedIndex + 1)
		
		With frmWindowPreview
			
			If Not .Visible Then
				
				'Call .SetWindowSize
				'.Left = frmMain.Left + (frmMain.Width - .Width) \ 2
				'.Top = frmMain.Top + (frmMain.Height - .Height) \ 2
				
				Call VB6.ShowForm(frmWindowPreview, 0, Me)
				
			Else
				
				Call frmWindowPreview.Close()
				
			End If
			
			Call picMain.Focus()
			
		End With
		
	End Sub
	
	Private Sub cmdBMPExcDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBMPExcDown.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim lngChangeA As Integer
		Dim lngChangeB As Integer
		Dim strTemp As String
		Dim lngIndex As Integer
		Dim strArray() As String
		
		With lstBMP
			
			If .SelectedIndex = .Items.Count - 1 Then Exit Sub
			
			'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
			
			'lngChangeB = modInput.strToNum(Hex$(.ListIndex + 2))
			'lngChangeA = modInput.strToNum(Hex$(.ListIndex + 1))
			
			'Else
			
			'lngChangeB = .ListIndex + 2
			'lngChangeA = .ListIndex + 1
			
			'End If
			
			lngChangeB = lngFromLong(.SelectedIndex + 2)
			lngChangeA = lngFromLong(.SelectedIndex + 1)
			
			strTemp = g_strBMP(lngChangeB)
			g_strBMP(lngChangeB) = g_strBMP(lngChangeA)
			g_strBMP(lngChangeA) = strTemp
			
			lngIndex = .SelectedIndex + 1
			
		End With
		
		With lstBGA
			
			strTemp = g_strBGA(lngChangeB)
			g_strBGA(lngChangeB) = g_strBGA(lngChangeA)
			g_strBGA(lngChangeA) = strTemp
			
		End With
		
		For i = 0 To UBound(g_strBGA)
			
			If Len(g_strBGA(i)) Then
				
				strArray = Split(g_strBGA(i), " ")
				
				If UBound(strArray) Then
					
					If modInput.strToNum(strArray(0)) = lngChangeB Then
						
						strArray(0) = modInput.strFromNum(lngChangeA, 2)
						
					ElseIf modInput.strToNum(strArray(0)) = lngChangeA Then 
						
						strArray(0) = modInput.strFromNum(lngChangeB, 2)
						
					End If
					
					g_strBGA(i) = Join(strArray, " ")
					
				End If
				
			End If
			
		Next i
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				If .intCh = 4 Or .intCh = 6 Or .intCh = 7 Then
					
					If .sngValue = lngChangeA Then
						
						.sngValue = lngChangeB
						
					ElseIf .sngValue = lngChangeB Then 
						
						.sngValue = lngChangeA
						
					End If
					
				End If
				
			End With
			
		Next i
		
		Call g_InputLog.AddData(modInput.strFromNum(modMain.CMD_LOG.BMP_CHANGE) & modInput.strFromNum(lngChangeB) & modInput.strFromNum(lngChangeA) & modLog.getSeparator)
		
		Call RefreshList()
		
		Call Redraw()
		
		lstBMP.SelectedIndex = lngIndex
		lstBGA.SelectedIndex = lngIndex
		
	End Sub
	
	Private Sub cmdBMPExcUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBMPExcUp.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim lngChangeA As Integer
		Dim lngChangeB As Integer
		Dim strTemp As String
		Dim lngIndex As Integer
		Dim strArray() As String
		
		With lstBMP
			
			If .SelectedIndex = 0 Then Exit Sub
			
			'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
			
			'lngChangeB = modInput.strToNum(Hex$(.ListIndex))
			'lngChangeA = modInput.strToNum(Hex$(.ListIndex + 1))
			
			'Else
			
			'lngChangeB = .ListIndex
			'lngChangeA = .ListIndex + 1
			
			'End If
			
			lngChangeB = lngFromLong(.SelectedIndex)
			lngChangeA = lngFromLong(.SelectedIndex + 1)
			
			strTemp = g_strBMP(lngChangeB)
			g_strBMP(lngChangeB) = g_strBMP(lngChangeA)
			g_strBMP(lngChangeA) = strTemp
			
			lngIndex = .SelectedIndex - 1
			
		End With
		
		With lstBGA
			
			strTemp = g_strBGA(lngChangeB)
			g_strBGA(lngChangeB) = g_strBGA(lngChangeA)
			g_strBGA(lngChangeA) = strTemp
			
		End With
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				If .intCh = 4 Or .intCh = 6 Or .intCh = 7 Then
					
					If .sngValue = lngChangeA Then
						
						.sngValue = lngChangeB
						
					ElseIf .sngValue = lngChangeB Then 
						
						.sngValue = lngChangeA
						
					End If
					
				End If
				
			End With
			
		Next i
		
		For i = 0 To UBound(g_strBGA)
			
			If Len(g_strBGA(i)) Then
				
				strArray = Split(g_strBGA(i), " ")
				
				If UBound(strArray) Then
					
					If modInput.strToNum(strArray(0)) = lngChangeB Then
						
						strArray(0) = modInput.strFromNum(lngChangeA, 2)
						
					ElseIf modInput.strToNum(strArray(0)) = lngChangeA Then 
						
						strArray(0) = modInput.strFromNum(lngChangeB, 2)
						
					End If
					
					g_strBGA(i) = Join(strArray, " ")
					
				End If
				
			End If
			
		Next i
		
		Call g_InputLog.AddData(modInput.strFromNum(modMain.CMD_LOG.BMP_CHANGE) & modInput.strFromNum(lngChangeB) & modInput.strFromNum(lngChangeA) & modLog.getSeparator)
		
		Call RefreshList()
		
		Call Redraw()
		
		lstBMP.SelectedIndex = lngIndex
		lstBGA.SelectedIndex = lngIndex
		
	End Sub
	
	Private Sub cmdDirectInput_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDirectInput.Click
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim intTemp As Short
		Dim i As Integer
		
		With cboDirectInput
			
			If Len(.Text) Then
				
				intTemp = UBound(g_Obj)
				
				Call modInput.LoadBMSLine(.Text, True)
				
				For i = intTemp To UBound(g_Obj) - 1
					
					With g_Obj(i)
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.lngPosition = (g_Measure(.intMeasure).intLen / .lngHeight) * .lngPosition
						
						Select Case .intCh
							
							Case modInput.OBJ_CH.CH_BPM
								
								.intCh = 8
								
							Case modInput.OBJ_CH.CH_KEY_INV_MIN To modInput.OBJ_CH.CH_KEY_INV_MAX '�s��
								
								.intCh = .intCh - modInput.OBJ_CH.CH_INV
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_ATT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intAtt = modMain.OBJ_ATT.OBJ_INVISIBLE
								
							Case modInput.OBJ_CH.CH_KEY_LN_MIN To modInput.OBJ_CH.CH_KEY_LN_MAX 'LN
								
								.intCh = .intCh - modInput.OBJ_CH.CH_LN
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_ATT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE
								
						End Select
						
					End With
					
				Next i
				
				Call .Items.Insert(0, .Text)
				
				For i = 1 To .Items.Count
					
					If .Text = VB6.GetItemString(cboDirectInput, i) Then
						
						Call .Items.RemoveAt(i)
						
						Exit For
						
					End If
					
				Next i
				
				If .Items.Count > 10 Then Call .Items.RemoveAt(.Items.Count - 1)
				
				.Text = ""
				
				Call .Focus()
				
				Call SaveChanges()
				
				Call modDraw.InitVerticalLine()
				
			End If
			
		End With
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "cmdDirectImput_Click")
	End Sub
	
	Private Sub cmdMeasureSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMeasureSelectAll.Click
		
		Dim i As Integer
		Dim intTemp As Short
		
		With lstMeasureLen
			
			intTemp = .SelectedIndex
			.Visible = False
			
			For i = 0 To 999
				
				.SetSelected(i, True)
				
			Next i
			
			.SelectedIndex = intTemp
			.Visible = True
			
		End With
		
	End Sub
	
	Private Sub cmdBGADelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBGADelete.Click
		
		Dim strTemp As New VB6.FixedLengthString(7)
		
		With lstBGA
			
			If Len(VB6.GetItemString(lstBGA, .SelectedIndex)) > 7 Then
				
				strTemp.Value = "#BGA00:"
				
				'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
				
				'Mid$(strTemp, 5, 2) = Right$("0" & Hex$(.ListIndex + 1), 2)
				'g_strBGA(strToNum(Mid$(strTemp, 5, 2))) = ""
				
				'Else
				
				'Mid$(strTemp, 5, 2) = modInput.strFromNum(.ListIndex + 1)
				'g_strBGA(.ListIndex + 1) = ""
				
				'End If
				
				Mid(strTemp.Value, 5, 2) = strFromLong(.SelectedIndex + 1)
				g_strBGA(lngFromLong(.SelectedIndex + 1)) = ""
				
				VB6.SetItemString(lstBGA, .SelectedIndex, strTemp.Value)
				
				Call SaveChanges()
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdBGASet_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBGASet.Click
		
		'Dim strTemp As String
		
		With lstBGA
			
			If Len(txtBGAInput.Text) = 0 Then Exit Sub
			
			'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
			
			'strTemp = Right$("0" & Hex$(.ListIndex + 1), 2)
			'.List(.ListIndex) = "#BGA" & strTemp & ":" & txtBGAInput.Text
			'g_strBGA(modInput.strToNum(strTemp)) = txtBGAInput.Text
			
			'Else
			
			'.List(.ListIndex) = "#BGA" & modInput.strFromNum(.ListIndex + 1) & ":" & txtBGAInput.Text
			'g_strBGA(.ListIndex + 1) = txtBGAInput.Text
			
			'End If
			
			VB6.SetItemString(lstBGA, .SelectedIndex, "#BGA" & strFromLong(.SelectedIndex + 1) & ":" & txtBGAInput.Text)
			g_strBGA(lngFromLong(.SelectedIndex + 1)) = txtBGAInput.Text
			
			txtBGAInput.Text = ""
			
			Call SaveChanges()
			
		End With
		
		With frmWindowPreview
			
			If .Visible Then
				
				Call PreviewBGA(lstBGA.SelectedIndex + 1)
				Call VB6.ShowForm(frmWindowPreview, 0, Me)
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdBmpDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBmpDelete.Click
		
		Dim strTemp As New VB6.FixedLengthString(7)
		
		With lstBMP
			
			If Len(VB6.GetItemString(lstBMP, .SelectedIndex)) > 7 Then
				
				strTemp.Value = "#BMP00:"
				
				Mid(strTemp.Value, 5, 2) = strFromLong(.SelectedIndex + 1)
				g_strBMP(lngFromLong(.SelectedIndex + 1)) = ""
				
				VB6.SetItemString(lstBMP, .SelectedIndex, strTemp.Value)
				
				Call SaveChanges()
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdBmpLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBmpLoad.Click
		On Error GoTo Err_Renamed
		
		Dim strArray() As String
		'Dim strTemp     As String * 2
		
		'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
		With dlgMain
			
			'UPGRADE_WARNING: Filter �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			.Filter = "Image files (*.bmp,*.jpg,*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*"
			.FileName = Mid(VB6.GetItemString(lstBMP, lstBMP.SelectedIndex), 8)
			
			Call .ShowDialog()
			
			strArray = Split(.FileName, "\")
			
			VB6.SetItemString(lstBMP, lstBMP.SelectedIndex, "#BMP" & strFromLong(lstBMP.SelectedIndex + 1) & ":" & strArray(UBound(strArray)))
			g_strBMP(lngFromLong(lstBMP.SelectedIndex + 1)) = strArray(UBound(strArray))
			
			.InitialDirectory = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
			
			Call SaveChanges()
			
		End With
		
		With frmWindowPreview
			
			If .Visible Then
				
				Call PreviewBMP(Mid(VB6.GetItemString(lstBMP, lstBMP.SelectedIndex), 8))
				Call VB6.ShowForm(frmWindowPreview, 0, Me)
				
			End If
			
		End With
		
		Exit Sub
		
Err_Renamed: 
	End Sub
	
	Private Sub cmdInputMeasureLen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdInputMeasureLen.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim strArray() As String
		Dim tempObj As g_udtObj
		
		With lstMeasureLen
			
			For i = 0 To 999
				
				If .GetSelected(i) Then
					
					lngTemp = 1
					
					Exit For
					
				End If
				
			Next i
			
			If lngTemp = 0 Then Exit Sub
			
			ReDim strArray(0)
			
			.Visible = False
			lngTemp = 0
			
			For i = 0 To 999
				
				If .GetSelected(i) Then
					
					VB6.SetItemString(lstMeasureLen, i, "#" & VB6.Format(i, "000") & ":" & cboNumerator.Text & "/" & cboDenominator.Text)
					lngTemp = (192 / CDbl(cboDenominator.Text)) * CDbl(cboNumerator.Text)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.MSR_CHANGE) & modInput.strFromNum(i) & VB.Right("00" & Hex(g_Measure(i).intLen), 3) & VB.Right("00" & Hex(lngTemp), 3)
					ReDim Preserve strArray(UBound(strArray) + 1)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Measure(i).intLen = lngTemp
					
				End If
				
			Next i
			
			.Visible = True
			
		End With
		
		For i = 0 To UBound(g_Obj) - 1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g tempObj �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			tempObj = g_Obj(i)
			
			With tempObj
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(tempObj.intMeasure).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Do While .lngPosition >= g_Measure(.intMeasure).intLen
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.lngPosition = .lngPosition - g_Measure(.intMeasure).intLen
					.intMeasure = .intMeasure + 1
					
				Loop 
				
			End With
			
			With g_Obj(i)
				
				If tempObj.intMeasure > 999 Then
					
					strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
					ReDim Preserve strArray(UBound(strArray) + 1)
					
					Call modDraw.RemoveObj(i)
					
				Else
					
					strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_MOVE) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & VB.Right("0" & Hex(tempObj.intCh), 2) & modInput.strFromNum(tempObj.intMeasure) & modInput.strFromNum(tempObj.lngPosition, 3)
					ReDim Preserve strArray(UBound(strArray) + 1)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Obj(i) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Obj(i) = tempObj
					
				End If
				
			End With
			
		Next i
		
		Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))
		
		Call modDraw.ArrangeObj()
		
		Call modDraw.ChangeResolution()
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	Private Sub cmdBMPPreview_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBMPPreview.Click
		
		Call PreviewBMP(Mid(VB6.GetItemString(lstBMP, lstBMP.SelectedIndex), 8))
		
		With frmWindowPreview
			
			If Not .Visible Then
				
				'Call .SetWindowSize
				'.Left = frmMain.Left + (frmMain.Width - .Width) \ 2
				'.Top = frmMain.Top + (frmMain.Height - .Height) \ 2
				
				Call VB6.ShowForm(frmWindowPreview, 0, Me)
				
			Else
				
				Call frmWindowPreview.Close()
				
			End If
			
			Call picMain.Focus()
			
		End With
		
	End Sub
	
	Private Sub cmdLoadMissBMP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoadMissBMP.Click
		On Error GoTo Err_Renamed
		
		Dim strArray() As String
		
		'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
		With dlgMain
			
			'UPGRADE_WARNING: Filter �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			.Filter = "Image files (*.bmp,*.jpg,*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*"
			.FileName = txtStageFile.Text
			
			Call .ShowDialog()
			
			strArray = Split(.FileName, "\")
			txtMissBMP.Text = strArray(UBound(strArray))
			dlgMainOpen.InitialDirectory = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
			dlgMainSave.InitialDirectory = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
			
		End With
		
		Exit Sub
		
Err_Renamed: 
	End Sub
	
	Private Sub cmdLoadStageFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoadStageFile.Click
		On Error GoTo Err_Renamed
		
		Dim strArray() As String
		
		'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
		With dlgMain
			
			'UPGRADE_WARNING: Filter �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			.Filter = "Image files (*.bmp,*.jpg,*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*"
			.FileName = txtStageFile.Text
			
			Call .ShowDialog()
			
			strArray = Split(.FileName, "\")
			txtStageFile.Text = strArray(UBound(strArray))
			dlgMainOpen.InitialDirectory = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
			dlgMainSave.InitialDirectory = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
			
		End With
		
		Exit Sub
		
Err_Renamed: 
	End Sub
	
	Private Sub cmdSoundDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSoundDelete.Click
		
		Dim strTemp As New VB6.FixedLengthString(7)
		
		Call mciSendString("close PREVIEW", vbNullString, 0, 0)
		
		With lstWAV
			
			If Len(VB6.GetItemString(lstWAV, .SelectedIndex)) > 7 Then
				
				strTemp.Value = "#WAV00:"
				
				'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
				
				'Mid$(strTemp, 5, 2) = Right$("0" & Hex$(.ListIndex + 1), 2)
				'g_strWAV(strToNum(Mid$(strTemp, 5, 2))) = ""
				
				'Else
				
				'Mid$(strTemp, 5, 2) = modInput.strFromNum(.ListIndex + 1)
				'g_strWAV(.ListIndex + 1) = ""
				
				'End If
				
				Mid(strTemp.Value, 5, 2) = strFromLong(.SelectedIndex + 1)
				g_strWAV(lngFromLong(.SelectedIndex + 1)) = ""
				
				VB6.SetItemString(lstWAV, .SelectedIndex, strTemp.Value)
				
				Call SaveChanges()
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdSoundExcDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSoundExcDown.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim intTemp As Short
		Dim strTemp As String
		
		With lstWAV
			
			If .SelectedIndex = .Items.Count - 1 Then Exit Sub
			
			'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
			
			'intTemp = strToNum(Hex$(.ListIndex + 2))
			'lngTemp = strToNum(Hex$(.ListIndex + 1))
			
			'Else
			
			'intTemp = .ListIndex + 2
			'lngTemp = .ListIndex + 1
			
			'End If
			
			intTemp = lngFromLong(.SelectedIndex + 2)
			lngTemp = lngFromLong(.SelectedIndex + 1)
			
			strTemp = g_strWAV(intTemp)
			g_strWAV(intTemp) = g_strWAV(lngTemp)
			g_strWAV(lngTemp) = strTemp
			
			VB6.SetItemString(lstWAV, .SelectedIndex + 1, "")
			.SelectedIndex = .SelectedIndex + 1
			
			VB6.SetItemString(lstWAV, .SelectedIndex, "#WAV" & strFromNum(intTemp) & ":" & g_strWAV(intTemp))
			VB6.SetItemString(lstWAV, .SelectedIndex - 1, "#WAV" & strFromNum(lngTemp) & ":" & g_strWAV(lngTemp))
			
		End With
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				If .intCh >= 11 Then
					
					If .sngValue = lngTemp Then
						
						.sngValue = intTemp
						
					ElseIf .sngValue = intTemp Then 
						
						.sngValue = lngTemp
						
					End If
					
				End If
				
			End With
			
		Next i
		
		Call g_InputLog.AddData(modInput.strFromNum(modMain.CMD_LOG.WAV_CHANGE) & modInput.strFromNum(intTemp) & modInput.strFromNum(lngTemp) & modLog.getSeparator)
		
		Call Redraw()
		
	End Sub
	
	Private Sub cmdSoundExcUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSoundExcUp.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim intTemp As Short
		Dim strTemp As String
		
		With lstWAV
			
			If .SelectedIndex = 0 Then Exit Sub
			
			intTemp = lngFromLong(.SelectedIndex)
			lngTemp = lngFromLong(.SelectedIndex + 1)
			
			strTemp = g_strWAV(intTemp)
			g_strWAV(intTemp) = g_strWAV(lngTemp)
			g_strWAV(lngTemp) = strTemp
			
			VB6.SetItemString(lstWAV, .SelectedIndex - 1, "")
			.SelectedIndex = .SelectedIndex - 1
			
			VB6.SetItemString(lstWAV, .SelectedIndex, "#WAV" & strFromNum(intTemp) & ":" & g_strWAV(intTemp))
			VB6.SetItemString(lstWAV, .SelectedIndex + 1, "#WAV" & strFromNum(lngTemp) & ":" & g_strWAV(lngTemp))
			
		End With
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				If .intCh >= 11 Then
					
					If .sngValue = lngTemp Then
						
						.sngValue = intTemp
						
					ElseIf .sngValue = intTemp Then 
						
						.sngValue = lngTemp
						
					End If
					
				End If
				
			End With
			
		Next i
		
		Call g_InputLog.AddData(modInput.strFromNum(modMain.CMD_LOG.WAV_CHANGE) & modInput.strFromNum(intTemp) & modInput.strFromNum(lngTemp) & modLog.getSeparator)
		
		Call Redraw()
		
	End Sub
	
	Private Sub cmdSoundLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSoundLoad.Click
		On Error GoTo Err_Renamed
		
		Dim strArray() As String
		
		Call mciSendString("close PREVIEW", vbNullString, 0, 0)
		
		'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
		With dlgMain
			
			'UPGRADE_WARNING: Filter �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			.Filter = "Sound files (*.wav,*.mp3)|*.wav;*.mp3|All files (*.*)|*.*"
			.FileName = Mid(VB6.GetItemString(lstWAV, lstWAV.SelectedIndex), 8)
			
			Call dlgMainOpen.ShowDialog()
			dlgMainSave.FileName = dlgMainOpen.FileName
			
			strArray = Split(.FileName, "\")
			
			VB6.SetItemString(lstWAV, lstWAV.SelectedIndex, "#WAV" & strFromLong(lstWAV.SelectedIndex + 1) & ":" & strArray(UBound(strArray)))
			g_strWAV(lngFromLong(lstWAV.SelectedIndex + 1)) = strArray(UBound(strArray))
			
			.InitialDirectory = VB.Left(dlgMainOpen.FileName, Len(dlgMainOpen.FileName) - Len(strArray(UBound(strArray))))
			
			Call SaveChanges()
			
		End With
		
Err_Renamed: 
	End Sub
	
	Private Sub cmdSoundStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSoundStop.Click
		
		Call mciSendString("close PREVIEW", vbNullString, 0, 0)
		
	End Sub
	
	Private Sub frmMain_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Dim i As Integer
		Dim j As Integer
		
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			
			Exit Sub
			
		ElseIf TypeOf VB6.GetActiveControl() Is System.Windows.Forms.ComboBox Then 
			
			'UPGRADE_ISSUE: Control Style �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If VB6.GetActiveControl().Style = 0 Then
				
				Exit Sub
				
			End If
			
		End If
		
		'Shift ��������Ă�����3��J��Ԃ���
		If Shift And VB6.ShiftConstants.ShiftMask Then j = 2
		
		For i = 0 To j
			
			Select Case KeyCode
				
				Case System.Windows.Forms.Keys.Add '+
					
					If optChangeBottom(0).Checked = True Then
						
						If lstWAV.SelectedIndex <> lstWAV.Items.Count - 1 Then
							
							If Shift And VB6.ShiftConstants.CtrlMask Then
								
								Call cmdSoundExcDown_Click(cmdSoundExcDown, New System.EventArgs())
								
							Else
								
								lstWAV.SelectedIndex = lstWAV.SelectedIndex + 1
								
							End If
							
						End If
						
					ElseIf optChangeBottom(1).Checked = True Or optChangeBottom(2).Checked = True Then 
						
						If lstBMP.SelectedIndex <> lstBMP.Items.Count - 1 Then
							
							If Shift And VB6.ShiftConstants.CtrlMask Then
								
								Call cmdBMPExcDown_Click(cmdBMPExcDown, New System.EventArgs())
								
							Else
								
								lstBMP.SelectedIndex = lstBMP.SelectedIndex + 1
								lstBGA.SelectedIndex = lstBMP.SelectedIndex
								
							End If
							
						End If
						
					End If
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)
					
				Case System.Windows.Forms.Keys.Subtract '-
					
					If optChangeBottom(0).Checked = True Then
						
						If lstWAV.SelectedIndex <> 0 Then
							
							If Shift And VB6.ShiftConstants.CtrlMask Then
								
								Call cmdSoundExcUp_Click(cmdSoundExcUp, New System.EventArgs())
								
							Else
								
								lstWAV.SelectedIndex = lstWAV.SelectedIndex - 1
								
							End If
							
						End If
						
					ElseIf optChangeBottom(1).Checked = True Or optChangeBottom(2).Checked = True Then 
						
						If lstBMP.SelectedIndex <> 0 Then
							
							If Shift And VB6.ShiftConstants.CtrlMask Then
								
								Call cmdBMPExcUp_Click(cmdBMPExcUp, New System.EventArgs())
								
							Else
								
								lstBMP.SelectedIndex = lstBMP.SelectedIndex - 1
								lstBGA.SelectedIndex = lstBGA.SelectedIndex - 1
								
							End If
							
						End If
						
					End If
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)
					
			End Select
			
		Next i
		
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.F5 'F5 ���X�g�ύX
				
				If optChangeBottom(0).Checked = True Then
					
					optChangeBottom(1).Checked = True
					
				ElseIf optChangeBottom(1).Checked = True Then 
					
					optChangeBottom(2).Checked = True
					
				ElseIf optChangeBottom(2).Checked = True Then 
					
					optChangeBottom(0).Checked = True
					
				End If
				
			Case System.Windows.Forms.Keys.Multiply '* �v���r���[
				
				If optChangeBottom(0).Checked = True Then
					
					Call lstWAV_SelectedIndexChanged(lstWAV, New System.EventArgs())
					
				ElseIf optChangeBottom(1).Checked = True Then 
					
					If Not frmWindowPreview.Visible Then Call cmdBMPPreview_Click(cmdBMPPreview, New System.EventArgs())
					
				ElseIf optChangeBottom(2).Checked = True Then 
					
					If Not frmWindowPreview.Visible Then Call cmdBGAPreview_Click(cmdBGAPreview, New System.EventArgs())
					
				End If
				
			Case System.Windows.Forms.Keys.Divide '/ �v���r���[��~
				
				If optChangeBottom(0).Checked = True Then
					
					Call cmdSoundStop_Click(cmdSoundStop, New System.EventArgs())
					
				ElseIf optChangeBottom(1).Checked = True Or optChangeBottom(2).Checked = True Then 
					
					If frmWindowPreview.Visible = True Then
						
						Call frmWindowPreview.Close()
						
					End If
					
				End If
				
		End Select
		
		Call modEasterEgg.KeyCheck(KeyCode, Shift)
		
	End Sub
	
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim GetCmdLine As Object
		Dim strGet_ini As Object
		Dim NewLargeChange As Short
		Dim LoadConfig As Object
		Dim modMain As Object
		
		Dim i As Integer
		Dim wp As WINDOWPLACEMENT
		
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.StartUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.StartUp()
		
		If cboViewer.Items.Count = 0 Then
			
			tlbMenu.Items.Item("PlayAll").Enabled = False
			tlbMenu.Items.Item("Play").Enabled = False
			tlbMenu.Items.Item("Stop").Enabled = False
			mnuToolsPlayAll.Enabled = False
			mnuToolsPlay.Enabled = False
			mnuToolsPlayStop.Enabled = False
			cboViewer.Enabled = False
			
		End If
		
		For i = 1 To 5
			
			'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: MSComctlLib.ButtonMenus ���\�b�h tlbMenu.Buttons.ButtonMenus.Add �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			Call tlbMenu.Items.Item("Open").ButtonMenus.Add(New System.Windows.Forms.ToolStripMenuItem(i,  , "&" & i & ":"))
			'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �R���N�V���� tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
			tlbMenu.Items.Item("Open").ButtonMenus.Item(i).Enabled = False
			'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B tlbMenu.Buttons.ButtonMenus �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �R���N�V���� tlbMenu.Buttons().ButtonMenus �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
			tlbMenu.Items.Item("Open").ButtonMenus.Item(i).Visible = False
			
		Next i
		
		For i = 0 To mnuRecentFiles.UBound
			
			'mnuRecentFiles(i).Enabled = False
			mnuRecentFiles(i).Visible = False
			
		Next i
		
		mnuLineRecent.Visible = False
		mnuHelpOpen.Enabled = False
		
		Me.Text = g_strAppTitle
		
		Call LoadConfig()
		
		dlgMainOpen.InitialDirectory = g_strAppDir
		dlgMainSave.InitialDirectory = g_strAppDir
		'UPGRADE_WARNING: FileOpenConstants �萔 FileOpenConstants.cdlOFNHideReadOnly �́A�V������������� OpenFileDialog.ShowReadOnly �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: MSComDlg.CommonDialog �v���p�e�B dlgMain.Flags �́A�V������������� dlgMainOpen.CheckFileExists �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' ���N���b�N���Ă��������B
		dlgMainOpen.CheckFileExists = True
		dlgMainOpen.CheckPathExists = True
		dlgMainSave.CheckPathExists = True
		'UPGRADE_WARNING: MSComDlg.CommonDialog �v���p�e�B dlgMain.Flags �́A�V������������� dlgMainOpen.ShowReadOnly �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: FileOpenConstants �萔 FileOpenConstants.cdlOFNHideReadOnly �́A�V������������� OpenFileDialog.ShowReadOnly �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' ���N���b�N���Ă��������B
		dlgMainOpen.ShowReadOnly = False
		'UPGRADE_WARNING: MSComDlg.CommonDialog �v���p�e�B dlgMain.Flags �́A�V������������� dlgMainSave.OverwritePrompt �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' ���N���b�N���Ă��������B
		dlgMainSave.OverwritePrompt = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.lngMaxY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_disp.lngMaxY = (vsbMain.Maximum - vsbMain.LargeChange + 1)
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.lngMaxX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_disp.lngMaxX = hsbMain.Minimum
		
		hsbMain.SmallChange = OBJ_WIDTH
		NewLargeChange = OBJ_WIDTH * 4
		hsbMain.Maximum = hsbMain.Maximum + NewLargeChange - hsbMain.LargeChange
		hsbMain.LargeChange = NewLargeChange
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.intPlayerType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		cboPlayer.SelectedIndex = g_BMS.intPlayerType - 1
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.lngPlayLevel �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		cboPlayLevel.Text = g_BMS.lngPlayLevel
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.intPlayRank �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		cboPlayRank.SelectedIndex = g_BMS.intPlayRank
		
		'        If strGet_ini("Options", "UseOldFormat", False, "bmse.ini") Then
		'
		'            For i = 1 To 255
		'
		'                strTemp = right$("0" & Hex$(i), 2)
		'                Call .lstWAV.AddItem("#WAV" & strTemp & ":", i - 1)
		'                Call .lstBMP.AddItem("#BMP" & strTemp & ":", i - 1)
		'                Call .lstBGA.AddItem("#BGA" & strTemp & ":", i - 1)
		'
		'            Next i
		'
		'            frmWindowPreview.cmdPreviewEnd.Caption = "FF"
		'
		'        Else
		
		'        For i = 1 To 1295
		'
		'            strTemp = modInput.strFromNum(i)
		'            Call lstWAV.AddItem("#WAV" & strTemp & ":", i - 1)
		'            Call lstBMP.AddItem("#BMP" & strTemp & ":", i - 1)
		'            Call lstBGA.AddItem("#BGA" & strTemp & ":", i - 1)
		'
		'        Next i
		Call RefreshList()
		
		'        End If
		
		For i = 0 To 999
			
			Call lstMeasureLen.Items.Insert(i, "#" & VB6.Format(i, "000") & ":4/4")
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			g_Measure(i).intLen = 192
			
		Next i
		
		lstWAV.SelectedIndex = 0
		lstBMP.SelectedIndex = 0
		lstBGA.SelectedIndex = 0
		lstMeasureLen.SelectedIndex = 0
		
		'UPGRADE_ISSUE: Frame �v���p�e�B fraViewer.BorderStyle �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		fraViewer.BorderStyle = 0
		'UPGRADE_ISSUE: Frame �v���p�e�B fraGrid.BorderStyle �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		fraGrid.BorderStyle = 0
		'UPGRADE_ISSUE: Frame �v���p�e�B fraDispSize.BorderStyle �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		fraDispSize.BorderStyle = 0
		'UPGRADE_ISSUE: Frame �v���p�e�B fraResolution.BorderStyle �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		fraResolution.BorderStyle = 0
		
		'UPGRADE_ISSUE: Frame �v���p�e�B fraHeader.BorderStyle �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		fraHeader.BorderStyle = 0
		'UPGRADE_ISSUE: Frame �v���p�e�B fraMaterial.BorderStyle �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		fraMaterial.BorderStyle = 0
		
		For i = 0 To 2
			
			fraTop(i).Top = 0
			fraTop(i).Left = 0
			'UPGRADE_ISSUE: Frame �v���p�e�B fraTop.BorderStyle �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			fraTop(i).BorderStyle = 0
			
		Next i
		
		fraTop(0).Visible = True
		optChangeTop(0).Checked = True
		
		For i = 0 To 4
			
			fraBottom(i).Top = 0
			fraBottom(i).Left = 0
			'UPGRADE_ISSUE: Frame �v���p�e�B fraBottom.BorderStyle �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			fraBottom(i).BorderStyle = 0
			
		Next i
		
		fraBottom(0).Visible = True
		optChangeBottom(0).Checked = True
		
		For i = 1 To 64
			
			Call cboNumerator.Items.Insert(i - 1, CStr(i))
			
		Next i
		
		cboNumerator.SelectedIndex = 3
		cboDenominator.SelectedIndex = 0
		
		m_blnPreview = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini(EasterEgg, Tips, 0, bmse.ini) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If strGet_ini("EasterEgg", "Tips", 0, "bmse.ini") Then
			
			With frmWindowTips
				
				.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Left) + (VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
				.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) + (VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)
				
				Call VB6.ShowForm(frmWindowTips, VB6.FormShowConstants.Modal, Me)
				
			End With
			
		End If
		
		wp.Length = 44
		Call GetWindowPlacement(Me.Handle.ToInt32, wp)
		'UPGRADE_WARNING: �I�u�W�F�N�g strGet_ini() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wp.showCmd = strGet_ini("Main", "State", SW_SHOW, "bmse.ini")
		Call SetWindowPlacement(Me.Handle.ToInt32, wp)
		
		Call GetCmdLine()
		
	End Sub
	
	'UPGRADE_ISSUE: VBRUN.DataObject �^ �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	'UPGRADE_ISSUE: Form �C�x���g Form.OLEDragDrop �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' ���N���b�N���Ă��������B
	Private Sub Form_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		
		Call FormDragDrop(Data)
		
	End Sub
	
	Private Sub frmMain_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		Dim modMain As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.intSaveCheck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If modMain.intSaveCheck() Then
			
			Cancel = True
			
		Else
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call modMain.CleanUp()
			
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	
	'UPGRADE_WARNING: �C�x���g frmMain.Resize �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Public Sub frmMain_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		
		Dim i As Integer
		Dim lngTemp As Integer
		
		Dim lngLineWidth As Integer
		Dim lngLineHeight As Integer
		Dim lngToolBarHeight As Integer
		Dim lngDirectInputHeight As Integer
		Dim lngStatusBarHeight As Integer
		
		'UPGRADE_NOTE: PADDING �� PADDING_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Const PADDING_Renamed As Short = 60 '�e�p�f�B���O�̑傫��
		Const SCROLLBAR_SIZE As Short = 255 '�X�N���[���o�[�̑傫��
		Const COLUMN_HEIGHT As Short = 315 '�e�J�����̍���
		Const FRAME_WIDTH As Short = 3255 '�t���[���̕�
		Const FRAME_TOP_HEIGHT As Short = 2190 '�w�b�_�t���[���̍���
		Const FRAME_BOTTOM_TOP As Short = 630 '�{�g���t���[����Y�ʒu�B�^�u�{�^���̑傫��
		Const FRAME_BOTTOM_BUTTONS_HEIGHT As Short = COLUMN_HEIGHT '�����Ƃ����͂Ƃ��̃{�^��
		
		With Me
			
			If .WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
			
			lngLineWidth = 2 * VB6.TwipsPerPixelX
			lngLineHeight = 2 * VB6.TwipsPerPixelY
			If mnuViewItem(MENU_VIEW.TOOL_BAR).Checked Then lngToolBarHeight = VB6.PixelsToTwipsY(tlbMenu.Height)
			If mnuViewItem(MENU_VIEW.DIRECT_INPUT).Checked Then lngDirectInputHeight = COLUMN_HEIGHT + PADDING_Renamed * 2
			If mnuViewItem(MENU_VIEW.STATUS_BAR).Checked Then lngStatusBarHeight = VB6.PixelsToTwipsY(staMain.Height) + VB6.TwipsPerPixelY * 2
			
			staMain.Visible = mnuViewItem(MENU_VIEW.STATUS_BAR).Checked
			
			linToolbarBottom(0).X1 = 0
			linToolbarBottom(0).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width))
			linToolbarBottom(0).Y1 = VB6.TwipsToPixelsY(lngToolBarHeight)
			linToolbarBottom(0).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linToolbarBottom(0).Y1))
			linToolbarBottom(1).X1 = 0
			linToolbarBottom(1).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width))
			linToolbarBottom(1).Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linToolbarBottom(0).Y1) + VB6.TwipsPerPixelY)
			linToolbarBottom(1).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linToolbarBottom(0).Y2) + VB6.TwipsPerPixelY)
			
			linVertical(0).X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width) - FRAME_WIDTH - PADDING_Renamed - lngLineWidth)
			linVertical(0).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linVertical(0).X1))
			linVertical(1).X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linVertical(0).X1) + VB6.TwipsPerPixelX)
			linVertical(1).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linVertical(1).X1))
			
			linVertical(0).Y1 = VB6.TwipsToPixelsY(lngToolBarHeight)
			linVertical(0).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngStatusBarHeight)
			linVertical(1).Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linVertical(0).Y1))
			linVertical(1).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linVertical(0).Y2))
			
			linHeader(0).X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linVertical(0).X1))
			linHeader(0).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width))
			linHeader(0).Y1 = VB6.TwipsToPixelsY(lngToolBarHeight + PADDING_Renamed + FRAME_TOP_HEIGHT + PADDING_Renamed)
			linHeader(0).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linHeader(0).Y1))
			linHeader(1).X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linHeader(0).X1))
			linHeader(1).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linHeader(0).X2))
			linHeader(1).Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linHeader(0).Y1) + VB6.TwipsPerPixelY)
			linHeader(1).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linHeader(0).Y2) + VB6.TwipsPerPixelY)
			
			linDirectInput(0).X1 = 0
			linDirectInput(0).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linVertical(0).X1))
			linDirectInput(0).Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngStatusBarHeight - PADDING_Renamed - COLUMN_HEIGHT - PADDING_Renamed)
			linDirectInput(0).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linDirectInput(0).Y1))
			linDirectInput(1).X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linDirectInput(0).X1))
			linDirectInput(1).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linDirectInput(0).X2))
			linDirectInput(1).Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linDirectInput(0).Y1) + VB6.TwipsPerPixelY)
			linDirectInput(1).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linDirectInput(0).Y2) + VB6.TwipsPerPixelY)
			
			linStatusBar(0).X1 = 0
			linStatusBar(0).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width))
			linStatusBar(0).Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngStatusBarHeight)
			linStatusBar(0).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngStatusBarHeight)
			linStatusBar(1).X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linStatusBar(0).X1))
			linStatusBar(1).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linStatusBar(0).X2))
			linStatusBar(1).Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linStatusBar(0).Y1) + VB6.TwipsPerPixelY)
			linStatusBar(1).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linStatusBar(0).Y2) + VB6.TwipsPerPixelY)
			
			linStatusBar(0).Visible = mnuViewItem(MENU_VIEW.STATUS_BAR).Checked
			linStatusBar(1).Visible = mnuViewItem(MENU_VIEW.STATUS_BAR).Checked
			
			tlbMenu.Visible = mnuViewItem(MENU_VIEW.TOOL_BAR).Checked
			fraViewer.Visible = mnuViewItem(MENU_VIEW.TOOL_BAR).Checked
			fraGrid.Visible = mnuViewItem(MENU_VIEW.TOOL_BAR).Checked
			fraDispSize.Visible = mnuViewItem(MENU_VIEW.TOOL_BAR).Checked
			
			lngTemp = VB6.PixelsToTwipsX(.ClientRectangle.Width) - FRAME_WIDTH - PADDING_Renamed - lngLineWidth - PADDING_Renamed - SCROLLBAR_SIZE
			
			Call vsbMain.SetBounds(VB6.TwipsToPixelsX(lngTemp), VB6.TwipsToPixelsY(lngToolBarHeight + PADDING_Renamed), VB6.TwipsToPixelsX(SCROLLBAR_SIZE), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngToolBarHeight - PADDING_Renamed - lngStatusBarHeight - lngDirectInputHeight - SCROLLBAR_SIZE - PADDING_Renamed))
			
			Call hsbMain.SetBounds(0, VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngStatusBarHeight - lngDirectInputHeight - SCROLLBAR_SIZE - PADDING_Renamed), VB6.TwipsToPixelsX(lngTemp), VB6.TwipsToPixelsY(SCROLLBAR_SIZE))
			
			Call picMain.SetBounds(0, VB6.TwipsToPixelsY(lngToolBarHeight + PADDING_Renamed), VB6.TwipsToPixelsX(lngTemp), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngToolBarHeight - PADDING_Renamed - lngStatusBarHeight - lngDirectInputHeight - SCROLLBAR_SIZE - PADDING_Renamed))
			
			linDirectInput(0).Visible = mnuViewItem(MENU_VIEW.DIRECT_INPUT).Checked
			linDirectInput(1).Visible = mnuViewItem(MENU_VIEW.DIRECT_INPUT).Checked
			lblDirectInput.Visible = mnuViewItem(MENU_VIEW.DIRECT_INPUT).Checked
			cboDirectInput.Visible = mnuViewItem(MENU_VIEW.DIRECT_INPUT).Checked
			cmdDirectInput.Visible = mnuViewItem(MENU_VIEW.DIRECT_INPUT).Checked
			
			Call lblDirectInput.SetBounds(VB6.TwipsToPixelsX(PADDING_Renamed), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngStatusBarHeight - PADDING_Renamed - (COLUMN_HEIGHT + VB6.PixelsToTwipsY(lblDirectInput.Height)) \ 2), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
			
			Call cmdDirectInput.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width) - FRAME_WIDTH - VB6.PixelsToTwipsX(cmdDirectInput.Width) - PADDING_Renamed * 2 - lngLineWidth), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngStatusBarHeight - PADDING_Renamed - VB6.PixelsToTwipsY(cmdDirectInput.Height)), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
			
			Call cboDirectInput.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(lblDirectInput.Left) + VB6.PixelsToTwipsX(lblDirectInput.Width) + PADDING_Renamed), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - lngStatusBarHeight - PADDING_Renamed - (COLUMN_HEIGHT + VB6.PixelsToTwipsY(cboDirectInput.Height)) \ 2), VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(cmdDirectInput.Left) - VB6.PixelsToTwipsX(lblDirectInput.Width) - PADDING_Renamed * 3), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
			
			With tlbMenu.Items.Item("Viewer")
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Width �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				.Width = VB6.PixelsToTwipsX(fraViewer.Width)
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Top �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.left �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				Call fraViewer.SetBounds(VB6.TwipsToPixelsX(.Left + PADDING_Renamed), VB6.TwipsToPixelsY(.Top + PADDING_Renamed), VB6.TwipsToPixelsX(.Width), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
				Call fraViewer.BringToFront()
			End With
			
			With tlbMenu.Items.Item("ChangeGrid")
				lblGridMain.Left = VB6.TwipsToPixelsX(PADDING_Renamed)
				cboDispGridSub.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(lblGridMain.Left) + VB6.PixelsToTwipsX(lblGridMain.Width) + PADDING_Renamed)
				lblGridSub.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(cboDispGridSub.Left) + VB6.PixelsToTwipsX(cboDispGridSub.Width) + PADDING_Renamed * 3)
				cboDispGridMain.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(lblGridSub.Left) + VB6.PixelsToTwipsX(lblGridSub.Width) + PADDING_Renamed)
				fraGrid.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(cboDispGridMain.Left) + VB6.PixelsToTwipsX(cboDispGridMain.Width) + PADDING_Renamed)
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Width �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				.Width = VB6.PixelsToTwipsX(fraGrid.Width)
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Top �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.left �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				Call fraGrid.SetBounds(VB6.TwipsToPixelsX(.Left), VB6.TwipsToPixelsY(.Top + PADDING_Renamed), VB6.TwipsToPixelsX(.Width), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
				Call fraGrid.BringToFront()
			End With
			
			With tlbMenu.Items.Item("DispSize")
				lblDispHeight.Left = VB6.TwipsToPixelsX(PADDING_Renamed)
				cboDispHeight.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(lblDispHeight.Left) + VB6.PixelsToTwipsX(lblDispHeight.Width) + PADDING_Renamed)
				lblDispWidth.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(cboDispHeight.Left) + VB6.PixelsToTwipsX(cboDispHeight.Width) + PADDING_Renamed * 3)
				cboDispWidth.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(lblDispWidth.Left) + VB6.PixelsToTwipsX(lblDispWidth.Width) + PADDING_Renamed)
				fraDispSize.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(cboDispWidth.Left) + VB6.PixelsToTwipsX(cboDispWidth.Width) + PADDING_Renamed)
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Width �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				.Width = VB6.PixelsToTwipsX(fraDispSize.Width)
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Top �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.left �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				Call fraDispSize.SetBounds(VB6.TwipsToPixelsX(.Left), VB6.TwipsToPixelsY(.Top + PADDING_Renamed), VB6.TwipsToPixelsX(.Width), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
				Call fraDispSize.BringToFront()
			End With
			
			With tlbMenu.Items.Item("Resolution")
				lblVScroll.Left = VB6.TwipsToPixelsX(PADDING_Renamed)
				cboVScroll.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(lblVScroll.Left) + VB6.PixelsToTwipsX(lblVScroll.Width) + PADDING_Renamed)
				fraResolution.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(cboVScroll.Left) + VB6.PixelsToTwipsX(cboVScroll.Width) + PADDING_Renamed)
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.Top �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: MSComctlLib.Button �v���p�e�B tlbMenu.Buttons.left �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				Call fraResolution.SetBounds(VB6.TwipsToPixelsX(.Left), VB6.TwipsToPixelsY(.Top + PADDING_Renamed), VB6.TwipsToPixelsX(.Width), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
				Call fraResolution.BringToFront()
			End With
			
			Call .picMain.Focus()
			
		End With
		
		With fraHeader
			
			Call fraHeader.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - FRAME_WIDTH), VB6.TwipsToPixelsY(lngToolBarHeight + PADDING_Renamed), VB6.TwipsToPixelsX(FRAME_WIDTH), VB6.TwipsToPixelsY(FRAME_TOP_HEIGHT))
			
			For i = 0 To 2
				
				fraTop(i).Top = VB6.TwipsToPixelsY(COLUMN_HEIGHT)
				
			Next i
			
		End With
		
		With fraMaterial
			
			Call fraMaterial.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - FRAME_WIDTH), VB6.TwipsToPixelsY(FRAME_TOP_HEIGHT + PADDING_Renamed + lngLineHeight + PADDING_Renamed + lngToolBarHeight + PADDING_Renamed), VB6.TwipsToPixelsX(FRAME_WIDTH), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - lngToolBarHeight - PADDING_Renamed - VB6.PixelsToTwipsY(fraHeader.Height) - lngLineHeight - PADDING_Renamed - lngStatusBarHeight - PADDING_Renamed))
			
			lngTemp = VB6.PixelsToTwipsY(.Height) - FRAME_BOTTOM_TOP
			
			For i = 0 To 4
				
				Call fraBottom(i).SetBounds(0, VB6.TwipsToPixelsY(FRAME_BOTTOM_TOP), VB6.TwipsToPixelsX(FRAME_WIDTH), VB6.TwipsToPixelsY(lngTemp))
				
			Next i
			
			lngTemp = VB6.PixelsToTwipsY(.Height) - FRAME_BOTTOM_BUTTONS_HEIGHT - FRAME_BOTTOM_TOP - PADDING_Renamed * 4
			lstWAV.Height = VB6.TwipsToPixelsY(lngTemp)
			lstBMP.Height = VB6.TwipsToPixelsY(lngTemp)
			lstMeasureLen.Height = VB6.TwipsToPixelsY(lngTemp)
			txtBGAInput.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Height) - VB6.PixelsToTwipsY(txtBGAInput.Height) - FRAME_BOTTOM_BUTTONS_HEIGHT - FRAME_BOTTOM_TOP - PADDING_Renamed * 2)
			lstBGA.Height = VB6.TwipsToPixelsY(lngTemp - VB6.PixelsToTwipsY(txtBGAInput.Height) - PADDING_Renamed)
			txtExInfo.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Height) - FRAME_BOTTOM_TOP - PADDING_Renamed * 3)
			
			lngTemp = VB6.PixelsToTwipsY(fraBottom(0).Height) - COLUMN_HEIGHT - PADDING_Renamed
			cmdSoundStop.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdSoundExcUp.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdSoundExcDown.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdSoundDelete.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdSoundLoad.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBMPPreview.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBMPExcUp.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBMPExcDown.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBMPDelete.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBMPLoad.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBGAPreview.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBGAExcUp.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBGAExcDown.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBGADelete.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdBGASet.Top = VB6.TwipsToPixelsY(lngTemp)
			cmdMeasureSelectAll.Top = VB6.TwipsToPixelsY(lngTemp)
			cboNumerator.Top = VB6.TwipsToPixelsY(lngTemp)
			cboDenominator.Top = VB6.TwipsToPixelsY(lngTemp)
			lblFraction.Top = VB6.TwipsToPixelsY(lngTemp + PADDING_Renamed)
			cmdInputMeasureLen.Top = VB6.TwipsToPixelsY(lngTemp)
			
		End With
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	'UPGRADE_NOTE: hsbMain.Change �̓C�x���g����v���V�[�W���ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' ���N���b�N���Ă��������B
	'UPGRADE_WARNING: HScrollBar �C�x���g hsbMain.Change �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub hsbMain_Change(ByVal newScrollValue As Integer)
		
		With g_disp
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.X = newScrollValue
			
		End With
		
		Call modDraw.Redraw()
		
		'Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)
		'�X�N���[�����I�u�W�F�ړ������̂���
		
	End Sub
	
	'UPGRADE_NOTE: hsbMain.Scroll �̓C�x���g����v���V�[�W���ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' ���N���b�N���Ă��������B
	Private Sub hsbMain_Scroll_Renamed(ByVal newScrollValue As Integer)
		
		Call hsbMain_Change(0)
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g lstBGA.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub lstBGA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBGA.SelectedIndexChanged
		
		'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
		
		'staMain.Panels("BMP").Text = "#BMP " & Right$("0" & Hex$(lstBGA.ListIndex + 1), 2)
		
		'Else
		
		'staMain.Panels("BMP").Text = "#BMP " & modInput.strFromNum(lstBGA.ListIndex + 1)
		
		'End If
		
		If optChangeBottom(2).Checked Then lstBMP.SelectedIndex = lstBGA.SelectedIndex
		
		staMain.Items.Item("BMP").Text = "#BMP " & strFromLong(lstBGA.SelectedIndex + 1)
		
		txtBGAInput.Text = Mid(VB6.GetItemString(lstBGA, lstBGA.SelectedIndex), 8)
		
		If frmWindowPreview.Visible Then
			
			Call PreviewBGA(lstBGA.SelectedIndex + 1)
			
		End If
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g lstBMP.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub lstBMP_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBMP.SelectedIndexChanged
		
		'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
		
		'staMain.Panels("BMP").Text = "#BMP " & Right$("0" & Hex$(lstBMP.ListIndex + 1), 2)
		
		'Else
		
		'staMain.Panels("BMP").Text = "#BMP " & modInput.strFromNum(lstBMP.ListIndex + 1)
		
		'End If
		
		If optChangeBottom(1).Checked Then lstBGA.SelectedIndex = lstBMP.SelectedIndex
		
		staMain.Items.Item("BMP").Text = "#BMP " & strFromLong(lstBMP.SelectedIndex + 1)
		
		If frmWindowPreview.Visible Then
			
			Call PreviewBMP(Mid(VB6.GetItemString(lstBMP, lstBMP.SelectedIndex), 8))
			
		End If
		
	End Sub
	
	Private Sub lstBMP_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBMP.DoubleClick
		
		Call cmdBmpLoad_Click(cmdBmpLoad, New System.EventArgs())
		
	End Sub
	
	Private Sub lstBMP_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lstBMP.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If Button = VB6.MouseButtonConstants.RightButton Then
			
			'UPGRADE_ISSUE: Form ���\�b�h frmMain.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			Call PopupMenu(mnuContextList)
			
		End If
		
	End Sub
	
	'UPGRADE_ISSUE: VBRUN.DataObject �^ �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	'UPGRADE_ISSUE: ListBox �C�x���g lstBMP.OLEDragDrop �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' ���N���b�N���Ă��������B
	Private Sub lstBMP_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		
		Dim i As Integer
		Dim j As Integer
		Dim strTemp As String
		Dim strArray() As String
		
		With lstBMP
			
			j = .SelectedIndex
			.Visible = False
			
			'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Count �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			For i = 1 To Data.Files.Count
				
				'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Item �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				If Dir(Data.Files.Item(i), FileAttribute.Normal) <> vbNullString Then
					
					'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
					'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Item �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
					strTemp = Data.Files.Item(i)
					
					'If Right$(UCase$(strTemp), 4) = ".BMP" Or Right$(UCase$(strTemp), 4) = ".JPG" Or Right$(UCase$(strTemp), 4) = ".GIF" Then
					
					Do Until Len(VB6.GetItemString(lstBMP, j)) < 8
						
						j = j + 1
						If j >= lstBMP.Items.Count Then Exit For
						
					Loop 
					
					strArray = Split(strTemp, "\")
					
					'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
					
					'strTemp = Right$("0" & Hex$(j + 1), 2)
					'.List(j) = "#BMP" & strTemp & ":" & strArray(UBound(strArray))
					'g_strBMP(strToNum(strTemp)) = strArray(UBound(strArray))
					
					'Else
					
					'.List(j) = "#BMP" & modInput.strFromNum(j + 1) & ":" & strArray(UBound(strArray))
					'g_strBMP(j + 1) = strArray(UBound(strArray))
					
					'End If
					
					VB6.SetItemString(lstBMP, j, "#BMP" & strFromLong(j + 1) & ":" & strArray(UBound(strArray)))
					g_strBMP(lngFromLong(j + 1)) = strArray(UBound(strArray))
					
					j = j + 1
					
					If j >= lstBMP.Items.Count Then Exit For
					
					'End If
					
				End If
				
			Next i
			
			.Visible = True
			
		End With
		
		Call Me.Show()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g lstMeasureLen.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub lstMeasureLen_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstMeasureLen.SelectedIndexChanged
		On Error Resume Next
		
		Dim strArray() As String
		
		strArray = Split(Mid(VB6.GetItemString(lstMeasureLen, lstMeasureLen.SelectedIndex), 6), "/")
		
		cboNumerator.SelectedIndex = CDbl(strArray(0)) - 1
		
		cboDenominator.SelectedIndex = System.Math.Log(CDbl(strArray(1))) / System.Math.Log(2) - 2
		
	End Sub
	
	Private Sub lstMeasureLen_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstMeasureLen.DoubleClick
		
		Dim i As Integer
		
		With lstMeasureLen
			
			.Visible = False
			
			For i = 0 To 999
				
				.SetSelected(i, True)
				
			Next i
			
			.SelectedIndex = 0
			.Visible = True
			
		End With
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g lstWAV.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub lstWAV_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstWAV.SelectedIndexChanged
		
		Dim strTemp As String
		
		'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
		
		'strTemp = Right$("0" & Hex$(lstWAV.ListIndex + 1), 2)
		
		'Else
		
		'strTemp = modInput.strFromNum(lstWAV.ListIndex + 1)
		
		'End If
		
		strTemp = strFromLong(lstWAV.SelectedIndex + 1)
		
		staMain.Items.Item("WAV").Text = "#WAV " & strTemp
		
		strTemp = Mid(VB6.GetItemString(lstWAV, lstWAV.SelectedIndex), 8)
		
		If strTemp = "" Then Exit Sub
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If Dir(g_BMS.strDir & strTemp) = vbNullString Then Exit Sub
		
		Call PreviewWAV(strTemp)
		
	End Sub
	
	Private Sub lstWAV_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstWAV.DoubleClick
		
		Call cmdSoundLoad_Click(cmdSoundLoad, New System.EventArgs())
		
	End Sub
	
	Private Sub lstWAV_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lstWAV.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If Button = VB6.MouseButtonConstants.RightButton Then
			
			'UPGRADE_ISSUE: Form ���\�b�h frmMain.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			Call PopupMenu(mnuContextList)
			
		End If
		
	End Sub
	
	'UPGRADE_ISSUE: VBRUN.DataObject �^ �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	'UPGRADE_ISSUE: ListBox �C�x���g lstWAV.OLEDragDrop �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' ���N���b�N���Ă��������B
	Private Sub lstWAV_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim j As Integer
		Dim strTemp As String
		Dim strArray() As String
		
		With lstWAV
			
			j = .SelectedIndex
			.Visible = False
			
			'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Count �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			For i = 1 To Data.Files.Count
				
				'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Item �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				If Dir(Data.Files.Item(i), FileAttribute.Normal) <> vbNullString Then
					
					'UPGRADE_ISSUE: DataObject �v���p�e�B Data.Files �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
					'UPGRADE_ISSUE: DataObjectFiles �v���p�e�B Files.Item �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
					strTemp = Data.Files.Item(i)
					
					'If Right$(UCase$(strTemp), 4) = ".WAV" Or Right$(UCase$(strTemp), 4) = ".MP3" Then
					
					Do Until Len(VB6.GetItemString(lstWAV, j)) < 8
						
						j = j + 1
						If j >= lstWAV.Items.Count Then Exit For
						
					Loop 
					
					strArray = Split(strTemp, "\")
					
					'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then
					
					'strTemp = Right$("0" & Hex$(j + 1), 2)
					'.List(j) = "#WAV" & strTemp & ":" & strArray(UBound(strArray))
					'g_strWAV(strToNum(strTemp)) = strArray(UBound(strArray))
					
					'Else
					
					'.List(j) = "#WAV" & modInput.strFromNum(j + 1) & ":" & strArray(UBound(strArray))
					'g_strWAV(j + 1) = strArray(UBound(strArray))
					
					'End If
					
					VB6.SetItemString(lstWAV, j, "#WAV" & strFromLong(j + 1) & ":" & strArray(UBound(strArray)))
					g_strWAV(lngFromLong(j + 1)) = strArray(UBound(strArray))
					
					Call SaveChanges()
					
					j = j + 1
					
					If j >= lstWAV.Items.Count Then Exit For
					
					'End If
					
				End If
				
			Next i
			
			.Visible = True
			
		End With
		
		Call Me.Show()
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "lstWAV_OLEDragDrop")
	End Sub
	
	Public Sub mnuContextDeleteMeasure_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextDeleteMeasure.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim intTemp As Short
		Dim strArray() As String
		
		For i = 0 To 999
			
			'If g_Measure(i).lngY >= g_disp.Y + picMain.ScaleHeight - g_Mouse.Y - 6 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Height �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(i).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If g_Measure(i).lngY >= g_disp.Y + (picMain.ClientRectangle.Height - g_Mouse.Y) / g_disp.Height - 1 Then
				
				intTemp = i - 1
				
				Exit For
				
			End If
			
		Next i
		
		ReDim strArray(0)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strArray(0) = modInput.strFromNum(modMain.CMD_LOG.MSR_DEL) & modInput.strFromNum(intTemp) & VB.Right("00" & Hex(g_Measure(intTemp).intLen), 3)
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				If .intMeasure = intTemp Then
					
					ReDim Preserve strArray(UBound(strArray) + 1)
					strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
					
					Call modDraw.RemoveObj(i)
					
				ElseIf .intMeasure > intTemp Then 
					
					.intMeasure = .intMeasure - 1
					
				End If
				
			End With
			
		Next i
		
		lstMeasureLen.Visible = False
		
		For i = intTemp To 998
			
			With g_Measure(i)
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(i).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.intLen = g_Measure(i + 1).intLen
				VB6.SetItemString(lstMeasureLen, i, VB.Left(VB6.GetItemString(lstMeasureLen, i), 5) & Mid(VB6.GetItemString(lstMeasureLen, i + 1), 6))
				
			End With
			
		Next i
		
		VB6.SetItemString(lstMeasureLen, 999, "#999:4/4")
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Measure(999).intLen = 192
		
		Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))
		
		lstMeasureLen.Visible = True
		
		Call modDraw.ArrangeObj()
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	Public Sub mnuContextEditCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextEditCopy.Click
		
		Call mnuEditCopy_Click(mnuEditCopy, New System.EventArgs())
		
	End Sub
	
	Public Sub mnuContextEditCut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextEditCut.Click
		
		Call mnuEditCut_Click(mnuEditCut, New System.EventArgs())
		
	End Sub
	
	Public Sub mnuContextEditDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextEditDelete.Click
		
		Call mnuEditDelete_Click(mnuEditDelete, New System.EventArgs())
		
	End Sub
	
	Public Sub mnuContextEditPaste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextEditPaste.Click
		
		Call mnuEditPaste_Click(mnuEditPaste, New System.EventArgs())
		
	End Sub
	
	Public Sub mnuContextInsertMeasure_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextInsertMeasure.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim intTemp As Short
		Dim strArray() As String
		
		lstMeasureLen.Visible = False
		
		For i = 998 To 0 Step -1
			
			With g_Measure(i)
				
				'If .lngY < g_disp.Y + picMain.ScaleHeight - g_Mouse.Y - 6 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Height �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(i).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If .lngY < g_disp.Y + (picMain.ClientRectangle.Height - g_Mouse.Y) / g_disp.Height - 1 Then
					
					VB6.SetItemString(lstMeasureLen, i, "#" & VB6.Format(i, "000") & ":4/4")
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.intLen = 192
					intTemp = i
					
					Exit For
					
				End If
				
				VB6.SetItemString(lstMeasureLen, i, VB.Left(VB6.GetItemString(lstMeasureLen, i), 5) & Mid(VB6.GetItemString(lstMeasureLen, i - 1), 6))
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(i).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.intLen = g_Measure(i - 1).intLen
				
			End With
			
		Next i
		
		ReDim strArray(0)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strArray(0) = modInput.strFromNum(modMain.CMD_LOG.MSR_ADD) & modInput.strFromNum(intTemp) & VB.Right("00" & Hex(g_Measure(999).intLen), 3)
		
		lstMeasureLen.Visible = True
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				If .intMeasure = 999 Then
					
					ReDim Preserve strArray(UBound(strArray) + 1)
					strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
					
					Call modDraw.RemoveObj(i)
					
				ElseIf .intMeasure >= intTemp Then 
					
					.intMeasure = .intMeasure + 1
					
				End If
				
			End With
			
		Next i
		
		Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))
		
		Call modDraw.ArrangeObj()
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	Public Sub mnuContextListDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextListDelete.Click
		
		If optChangeBottom(0).Checked Then
			
			Call cmdSoundDelete_Click(cmdSoundDelete, New System.EventArgs())
			
		ElseIf optChangeBottom(1).Checked Then 
			
			Call cmdBmpDelete_Click(cmdBmpDelete, New System.EventArgs())
			
		End If
		
	End Sub
	
	Public Sub mnuContextListLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextListLoad.Click
		
		If optChangeBottom(0).Checked Then
			
			Call cmdSoundLoad_Click(cmdSoundLoad, New System.EventArgs())
			
		ElseIf optChangeBottom(1).Checked Then 
			
			Call cmdBmpLoad_Click(cmdBmpLoad, New System.EventArgs())
			
		End If
		
	End Sub
	
	Public Sub mnuContextListRename_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextListRename.Click
		Dim modMain As Object
		Dim g_Message As Object
		
		Dim strTemp As String
		
		If optChangeBottom(0).Checked Then
			
			With lstWAV
				
				Call mciSendString("close PREVIEW", vbNullString, 0, 0)
				strTemp = Mid(VB6.GetItemString(lstWAV, .SelectedIndex), 8)
				
				If Len(VB6.GetItemString(lstWAV, .SelectedIndex)) > 8 Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
					If Dir(g_BMS.strDir & strTemp, FileAttribute.Normal) <> vbNullString Then
						
						With frmWindowInput
							
							'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.lblMainDisp.Text = g_Message(modMain.Message.INPUT_RENAME)
							.txtMain.Text = strTemp
							
							Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)
							
						End With
						
						If strTemp <> frmWindowInput.txtMain.Text And Len(frmWindowInput.txtMain.Text) <> 0 Then
							
							'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
							If Dir(g_BMS.strDir & frmWindowInput.txtMain.Text, FileAttribute.Normal) = vbNullString Then
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Rename(g_BMS.strDir & strTemp, g_BMS.strDir & frmWindowInput.txtMain.Text)
								
								VB6.SetItemString(lstWAV, .SelectedIndex, VB.Left(VB6.GetItemString(lstWAV, .SelectedIndex), 7) & frmWindowInput.txtMain.Text)
								g_strWAV(lngFromLong(.SelectedIndex + 1)) = frmWindowInput.txtMain.Text
								
							Else
								
								Call MsgBox(g_Message(modMain.Message.ERR_FILE_ALREADY_EXIST), MsgBoxStyle.Critical, g_strAppTitle)
								
							End If
							
						End If
						
					Else
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & g_BMS.strDir & strTemp, MsgBoxStyle.Critical, g_strAppTitle)
						
					End If
					
				End If
				
			End With
			
		ElseIf optChangeBottom(1).Checked Then 
			
			With lstBMP
				
				strTemp = Mid(VB6.GetItemString(lstBMP, .SelectedIndex), 8)
				
				If Len(VB6.GetItemString(lstBMP, .SelectedIndex)) > 8 Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
					If Dir(g_BMS.strDir & strTemp, FileAttribute.Normal) <> vbNullString Then
						
						With frmWindowInput
							
							'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.lblMainDisp.Text = g_Message(modMain.Message.INPUT_RENAME)
							.txtMain.Text = strTemp
							
							Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)
							
						End With
						
						If strTemp <> frmWindowInput.txtMain.Text And Len(frmWindowInput.txtMain.Text) <> 0 Then
							
							'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
							If Dir(g_BMS.strDir & frmWindowInput.txtMain.Text, FileAttribute.Normal) = vbNullString Then
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Rename(g_BMS.strDir & strTemp, g_BMS.strDir & frmWindowInput.txtMain.Text)
								
								VB6.SetItemString(lstBMP, .SelectedIndex, VB.Left(VB6.GetItemString(lstBMP, .SelectedIndex), 7) & frmWindowInput.txtMain.Text)
								g_strBMP(lngFromLong(.SelectedIndex + 1)) = frmWindowInput.txtMain.Text
								
							Else
								
								Call MsgBox(g_Message(modMain.Message.ERR_FILE_ALREADY_EXIST), MsgBoxStyle.Critical, g_strAppTitle)
								
							End If
							
						End If
						
					Else
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & g_BMS.strDir & strTemp, MsgBoxStyle.Critical, g_strAppTitle)
						
					End If
					
				End If
				
			End With
			
		End If
		
	End Sub
	
	Public Sub mnuContextPlay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextPlay.Click
		
		Dim lngTemp As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intStartMeasure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngTemp = g_disp.intStartMeasure
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intStartMeasure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.measure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_disp.intStartMeasure = g_Mouse.measure
		
		Call mnuToolsPlay_Click(mnuToolsPlay, New System.EventArgs())
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intStartMeasure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_disp.intStartMeasure = lngTemp
		
	End Sub
	
	Public Sub mnuContextPlayAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextPlayAll.Click
		
		Call mnuToolsPlayAll_Click(mnuToolsPlayAll, New System.EventArgs())
		
	End Sub
	
	Public Sub mnuEditFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditFind.Click
		
		With frmWindowFind
			
			If Not .Visible Then
				
				.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Left) + (VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
				.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) + (VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)
				
			End If
			
			Call VB6.ShowForm(frmWindowFind, 0, Me)
			
		End With
		
	End Sub
	
	Public Sub mnuEditRedo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditRedo.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim j As Integer
		Dim intTemp As Short
		Dim lngTemp As Integer
		Dim strTemp As String
		Dim strArray() As String
		Dim lngArrayWAV(1295) As Integer
		Dim lngArrayBMP(1295) As Integer
		Dim strArrayWAV(1295) As String
		Dim strArrayBMP(1295) As String
		Dim strArrayBGA(1295) As String
		Dim strArrayParamBGA() As String
		Dim blnRefreshList As Boolean
		
		'�e�L�X�g�{�b�N�X��R���{�{�b�N�X���A�N�e�B�u�̏ꍇ��
		'�������� Redo �̃��b�Z�[�W�𑗐M���ĒE�o����
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			
			'UPGRADE_ISSUE: Control hwnd �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call SendMessage(VB6.GetActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)
			
			Exit Sub
			
		ElseIf TypeOf VB6.GetActiveControl() Is System.Windows.Forms.ComboBox Then 
			
			'UPGRADE_ISSUE: Control Style �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If VB6.GetActiveControl().Style = 0 Then
				
				'UPGRADE_ISSUE: Control hwnd �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Call SendMessage(VB6.GetActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)
				
				Exit Sub
				
			End If
			
		End If
		
		If g_InputLog.GetPos = g_InputLog.Max Then Exit Sub
		
		Call modDraw.ObjSelectCancel()
		
		Call g_InputLog.Forward()
		
		strArray = Split(g_InputLog.GetData(), modLog.getSeparator)
		
		For i = 0 To UBound(strArray)
			
			Select Case modInput.strToNum(VB.Left(strArray(i), 2))
				
				Case modMain.CMD_LOG.OBJ_ADD
					
					ReDim Preserve g_Obj(UBound(g_Obj) + 1)
					
					Call modInput.SwapObj(UBound(g_Obj), UBound(g_Obj) - 1)
					
					'                With g_Obj(UBound(g_Obj) - 1)
					'
					'                    .lngID = modInput.strToNum(Mid$(strArray(i), 3, 4)) '
					'                    g_lngObjID(.lngID) = UBound(g_Obj) - 1
					'                    .intCh = Val("&H" & Mid$(strArray(i), 7, 2)) '
					'                    .intAtt = Mid$(strArray(i), 9, 1) '
					'                    .intMeasure = modInput.strToNum(Mid$(strArray(i), 10, 2)) '
					'                    .lngPosition = modInput.strToNum(Mid$(strArray(i), 12, 3)) '
					'                    .sngValue = Mid$(strArray(i), 15) '
					'                    .intSelect = Selected
					'
					'                End With
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Obj(UBound() - 1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Obj(UBound(g_Obj) - 1) = modLog.decAdd(strArray(i), UBound(g_Obj) - 1)
					'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Obj(UBound(g_Obj) - 1).intSelect = modMain.OBJ_SELECT.Selected
					
				Case modMain.CMD_LOG.OBJ_DEL
					
					'Call modDraw.RemoveObj(g_lngObjID(modInput.strToNum(Mid$(strArray(i), 3, 4)))) '
					Call modLog.decDel(strArray(i))
					
				Case modMain.CMD_LOG.OBJ_MOVE
					
					'                With g_Obj(g_lngObjID(modInput.strToNum(Mid$(strArray(i), 3, 4)))) '
					'
					'                    .intCh = Val("&H" & Mid$(strArray(i), 14, 2)) '
					'                    .intMeasure = modInput.strToNum(Mid$(strArray(i), 16, 2)) '
					'                    .lngPosition = modInput.strToNum(Mid$(strArray(i), 18, 3)) '
					'                    .intSelect = Selected
					'
					'                End With
					Call modLog.decMove(strArray(i), g_Obj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))))
					
				Case modMain.CMD_LOG.OBJ_CHANGE
					
					With g_Obj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))) '
						
						.sngValue = modInput.strToNum(Mid(strArray(i), 9, 2)) '
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intSelect = modMain.OBJ_SELECT.Selected
						
					End With
					
				Case modMain.CMD_LOG.MSR_ADD
					
					lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					
					For j = 999 To lngTemp + 1 Step -1
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(j).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_Measure(j).intLen = g_Measure(j - 1).intLen
						VB6.SetItemString(lstMeasureLen, j, VB.Left(VB6.GetItemString(lstMeasureLen, j), 5) & Mid(VB6.GetItemString(lstMeasureLen, j - 1), 6))
						
					Next j
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Measure(lngTemp).intLen = 192
					VB6.SetItemString(lstMeasureLen, lngTemp, VB.Left(VB6.GetItemString(lstMeasureLen, lngTemp), 5) & "4/4")
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							If .intMeasure >= lngTemp Then
								
								.intMeasure = .intMeasure + 1
								
							End If
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.MSR_DEL
					
					lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					
					For j = lngTemp + 1 To 998
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(j).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_Measure(j).intLen = g_Measure(j + 1).intLen
						VB6.SetItemString(lstMeasureLen, j, VB.Left(VB6.GetItemString(lstMeasureLen, j), 5) & Mid(VB6.GetItemString(lstMeasureLen, j + 1), 6))
						
					Next j
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Measure(999).intLen = 192
					VB6.SetItemString(lstMeasureLen, 999, "#999:4/4")
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							If .intMeasure >= lngTemp Then
								
								.intMeasure = .intMeasure - 1
								
							End If
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.MSR_CHANGE
					
					lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(lngTemp).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 8, 3)) '
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
					If intTemp <= 2 Then intTemp = 3
					If intTemp >= 48 Then intTemp = 48
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(lngTemp).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					VB6.SetItemString(lstMeasureLen, lngTemp, VB.Left(VB6.GetItemString(lstMeasureLen, lngTemp), 5) & (g_Measure(lngTemp).intLen / intTemp) & "/" & (192 \ intTemp))
					
				Case modMain.CMD_LOG.WAV_CHANGE
					
					intTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					lngTemp = modInput.strToNum(Mid(strArray(i), 5, 2)) '
					
					strTemp = g_strWAV(intTemp)
					g_strWAV(intTemp) = g_strWAV(lngTemp)
					g_strWAV(lngTemp) = strTemp
					
					blnRefreshList = True
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							If .intCh >= 11 Then
								
								If .sngValue = lngTemp Then
									
									.sngValue = intTemp
									
								ElseIf .sngValue = intTemp Then 
									
									.sngValue = lngTemp
									
								End If
								
							End If
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.BMP_CHANGE
					
					intTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					lngTemp = modInput.strToNum(Mid(strArray(i), 5, 2)) '
					
					strTemp = g_strBMP(intTemp)
					g_strBMP(intTemp) = g_strBMP(lngTemp)
					g_strBMP(lngTemp) = strTemp
					
					strTemp = g_strBGA(intTemp)
					g_strBGA(intTemp) = g_strBGA(lngTemp)
					g_strBGA(lngTemp) = strTemp
					
					For j = 0 To UBound(g_strBGA)
						
						If Len(g_strBGA(j)) Then
							
							strArrayParamBGA = Split(g_strBGA(j), " ")
							
							If UBound(strArrayParamBGA) Then
								
								If modInput.strToNum(strArrayParamBGA(0)) = lngTemp Then
									
									strArrayParamBGA(0) = modInput.strFromNum(intTemp, 2)
									
								ElseIf modInput.strToNum(strArrayParamBGA(0)) = intTemp Then 
									
									strArrayParamBGA(0) = modInput.strFromNum(lngTemp, 2)
									
								End If
								
								g_strBGA(j) = Join(strArrayParamBGA, " ")
								
							End If
							
						End If
						
					Next j
					
					blnRefreshList = True
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							If .intCh = 4 Or .intCh = 6 Or .intCh = 7 Then
								
								If .sngValue = lngTemp Then
									
									.sngValue = intTemp
									
								ElseIf .sngValue = intTemp Then 
									
									.sngValue = lngTemp
									
								End If
								
							End If
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.LIST_ALIGN
					
					For j = 0 To UBound(lngArrayWAV)
						
						lngArrayWAV(j) = j
						lngArrayBMP(j) = j
						
						strArrayWAV(j) = g_strWAV(j)
						strArrayBMP(j) = g_strBMP(j)
						strArrayBGA(j) = g_strBGA(j)
						
						g_strWAV(j) = ""
						g_strBMP(j) = ""
						g_strBGA(j) = ""
						
					Next j
					
					For j = 3 To Len(strArray(i)) Step 5
						
						lngTemp = modInput.strToNum(Mid(strArray(i), j + 1, 2)) '
						intTemp = modInput.strToNum(Mid(strArray(i), j + 3, 2)) '
						
						Select Case Mid(strArray(i), j, 1)
							
							Case CStr(1) 'WAV
								
								g_strWAV(intTemp) = strArrayWAV(lngTemp)
								lngArrayWAV(lngTemp) = intTemp
								
							Case CStr(2) 'BMP
								
								g_strBMP(intTemp) = strArrayBMP(lngTemp)
								g_strBGA(intTemp) = strArrayBGA(lngTemp)
								lngArrayBMP(lngTemp) = intTemp
								
						End Select
						
					Next j
					
					For j = 0 To UBound(g_strBGA)
						
						If Len(g_strBGA(j)) Then
							
							strArrayParamBGA = Split(g_strBGA(j), " ")
							
							If UBound(strArrayParamBGA) Then
								
								strArrayParamBGA(0) = modInput.strFromNum(lngArrayBMP(modInput.strToNum(strArrayParamBGA(0))), 2)
								g_strBGA(j) = Join(strArrayParamBGA, " ")
								
							End If
							
						End If
						
					Next j
					
					blnRefreshList = True
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							Select Case .intCh
								
								Case Is >= 11
									
									.sngValue = lngArrayWAV(.sngValue)
									
								Case 4, 6, 7
									
									.sngValue = lngArrayBMP(.sngValue)
									
							End Select
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.LIST_DEL
					
					Select Case Mid(strArray(i), 3, 1)
						
						Case CStr(1) '#WAV
							
							g_strWAV(modInput.strToNum(Mid(strArray(i), 4, 2))) = ""
							
						Case CStr(2) '#BMP
							
							g_strBMP(modInput.strToNum(Mid(strArray(i), 4, 2))) = ""
							
						Case CStr(3) '#BGA
							
							g_strBGA(modInput.strToNum(Mid(strArray(i), 4, 2))) = ""
							
					End Select
					
					blnRefreshList = True
					
			End Select
			
		Next i
		
		If blnRefreshList Then Call RefreshList()
		
		Call modDraw.ArrangeObj()
		
		Call SaveChanges()
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	Public Sub mnuEditUndo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditUndo.Click
		Dim modMain As Object
		
		Dim i As Integer
		Dim j As Integer
		Dim intTemp As Short
		Dim lngTemp As Integer
		Dim strTemp As String
		Dim strArray() As String
		Dim lngArrayWAV(1295) As Integer
		Dim lngArrayBMP(1295) As Integer
		Dim strArrayWAV(1295) As String
		Dim strArrayBMP(1295) As String
		Dim strArrayBGA(1295) As String
		Dim strArrayParamBGA() As String
		Dim blnRefreshList As Boolean
		
		'�e�L�X�g�{�b�N�X��R���{�{�b�N�X���A�N�e�B�u�̏ꍇ��
		'�������� Undo �̃��b�Z�[�W�𑗐M���ĒE�o����
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			
			'UPGRADE_ISSUE: Control hwnd �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call SendMessage(VB6.GetActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)
			
			Exit Sub
			
		ElseIf TypeOf VB6.GetActiveControl() Is System.Windows.Forms.ComboBox Then 
			
			'UPGRADE_ISSUE: Control Style �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If VB6.GetActiveControl().Style = 0 Then
				
				'UPGRADE_ISSUE: Control hwnd �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Call SendMessage(VB6.GetActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)
				
				Exit Sub
				
			End If
			
		End If
		
		If g_InputLog.GetPos = 0 Then Exit Sub
		
		Call modDraw.ObjSelectCancel()
		
		strArray = Split(g_InputLog.GetData(), modLog.getSeparator)
		
		Call g_InputLog.Back()
		
		For i = 0 To UBound(strArray)
			
			Select Case modInput.strToNum(VB.Left(strArray(i), 2))
				
				Case modMain.CMD_LOG.OBJ_ADD
					
					Call modDraw.RemoveObj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))) '
					
				Case modMain.CMD_LOG.OBJ_DEL
					
					ReDim Preserve g_Obj(UBound(g_Obj) + 1)
					
					Call modInput.SwapObj(UBound(g_Obj), UBound(g_Obj) - 1)
					
					With g_Obj(UBound(g_Obj) - 1)
						
						.lngID = modInput.strToNum(Mid(strArray(i), 3, 4)) '
						g_lngObjID(.lngID) = UBound(g_Obj) - 1
						.intCh = Val("&H" & Mid(strArray(i), 7, 2)) '
						.intAtt = CShort(Mid(strArray(i), 9, 1)) '
						.intMeasure = modInput.strToNum(Mid(strArray(i), 10, 2)) '
						.lngPosition = modInput.strToNum(Mid(strArray(i), 12, 3)) '
						.sngValue = CSng(Mid(strArray(i), 15)) '
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intSelect = modMain.OBJ_SELECT.Selected
						
					End With
					
				Case modMain.CMD_LOG.OBJ_MOVE
					
					With g_Obj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))) '
						
						.intCh = Val("&H" & Mid(strArray(i), 7, 2)) '
						.intMeasure = modInput.strToNum(Mid(strArray(i), 9, 2)) '
						.lngPosition = modInput.strToNum(Mid(strArray(i), 11, 3)) '
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intSelect = modMain.OBJ_SELECT.Selected
						
					End With
					
				Case modMain.CMD_LOG.OBJ_CHANGE
					
					With g_Obj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))) '
						
						.sngValue = modInput.strToNum(Mid(strArray(i), 7, 2)) '
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.intSelect = modMain.OBJ_SELECT.Selected
						
					End With
					
				Case modMain.CMD_LOG.MSR_ADD
					
					lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					
					For j = lngTemp To 998
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(j).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_Measure(j).intLen = g_Measure(j + 1).intLen
						VB6.SetItemString(lstMeasureLen, j, VB.Left(VB6.GetItemString(lstMeasureLen, j), 5) & Mid(VB6.GetItemString(lstMeasureLen, j + 1), 6))
						
					Next j
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(999).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Measure(999).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intTemp = intGCD(g_Measure(999).intLen, 192)
					If intTemp <= 2 Then intTemp = 3
					If intTemp >= 48 Then intTemp = 48
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					VB6.SetItemString(lstMeasureLen, 999, "#999:" & (g_Measure(999).intLen / intTemp) & "/" & (192 \ intTemp))
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							If .intMeasure > lngTemp Then
								
								.intMeasure = .intMeasure - 1
								
							End If
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.MSR_DEL
					
					lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					
					For j = 999 To lngTemp + 1 Step -1
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(j).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_Measure(j).intLen = g_Measure(j - 1).intLen
						VB6.SetItemString(lstMeasureLen, j, VB.Left(VB6.GetItemString(lstMeasureLen, j), 5) & Mid(VB6.GetItemString(lstMeasureLen, j - 1), 6))
						
					Next j
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(lngTemp).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
					If intTemp <= 2 Then intTemp = 3
					If intTemp >= 48 Then intTemp = 48
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(lngTemp).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					VB6.SetItemString(lstMeasureLen, lngTemp, VB.Left(VB6.GetItemString(lstMeasureLen, lngTemp), 5) & (g_Measure(lngTemp).intLen / intTemp) & "/" & (192 \ intTemp))
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							If .intMeasure >= lngTemp Then
								
								.intMeasure = .intMeasure + 1
								
							End If
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.MSR_CHANGE
					
					lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(lngTemp).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
					If intTemp <= 2 Then intTemp = 3
					If intTemp >= 48 Then intTemp = 48
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(lngTemp).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					VB6.SetItemString(lstMeasureLen, lngTemp, VB.Left(VB6.GetItemString(lstMeasureLen, lngTemp), 5) & (g_Measure(lngTemp).intLen / intTemp) & "/" & (192 \ intTemp))
					
				Case modMain.CMD_LOG.WAV_CHANGE
					
					intTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					lngTemp = modInput.strToNum(Mid(strArray(i), 5, 2)) '
					
					strTemp = g_strWAV(intTemp)
					g_strWAV(intTemp) = g_strWAV(lngTemp)
					g_strWAV(lngTemp) = strTemp
					
					blnRefreshList = True
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							If .intCh >= 11 Then
								
								If .sngValue = lngTemp Then
									
									.sngValue = intTemp
									
								ElseIf .sngValue = intTemp Then 
									
									.sngValue = lngTemp
									
								End If
								
							End If
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.BMP_CHANGE
					
					intTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '
					lngTemp = modInput.strToNum(Mid(strArray(i), 5, 2)) '
					
					strTemp = g_strBMP(intTemp)
					g_strBMP(intTemp) = g_strBMP(lngTemp)
					g_strBMP(lngTemp) = strTemp
					
					strTemp = g_strBGA(intTemp)
					g_strBGA(intTemp) = g_strBGA(lngTemp)
					g_strBGA(lngTemp) = strTemp
					
					
					For j = 0 To UBound(g_strBGA)
						
						If Len(g_strBGA(j)) Then
							
							strArrayParamBGA = Split(g_strBGA(j), " ")
							
							If UBound(strArrayParamBGA) Then
								
								If modInput.strToNum(strArrayParamBGA(0)) = lngTemp Then
									
									strArrayParamBGA(0) = modInput.strFromNum(intTemp, 2)
									
								ElseIf modInput.strToNum(strArrayParamBGA(0)) = intTemp Then 
									
									strArrayParamBGA(0) = modInput.strFromNum(lngTemp, 2)
									
								End If
								
								g_strBGA(j) = Join(strArrayParamBGA, " ")
								
							End If
							
						End If
						
					Next j
					
					blnRefreshList = True
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							If .intCh = 4 Or .intCh = 6 Or .intCh = 7 Then
								
								If .sngValue = lngTemp Then
									
									.sngValue = intTemp
									
								ElseIf .sngValue = intTemp Then 
									
									.sngValue = lngTemp
									
								End If
								
							End If
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.LIST_ALIGN
					
					For j = 0 To UBound(lngArrayWAV)
						
						lngArrayWAV(j) = j
						lngArrayBMP(j) = j
						
						strArrayWAV(j) = g_strWAV(j)
						strArrayBMP(j) = g_strBMP(j)
						strArrayBGA(j) = g_strBGA(j)
						
						g_strWAV(j) = ""
						g_strBMP(j) = ""
						g_strBGA(j) = ""
						
					Next j
					
					For j = 3 To Len(strArray(i)) Step 5
						
						intTemp = modInput.strToNum(Mid(strArray(i), j + 1, 2)) '�Â��l
						lngTemp = modInput.strToNum(Mid(strArray(i), j + 3, 2)) '�V�����l
						
						Select Case Mid(strArray(i), j, 1)
							
							Case CStr(1) 'WAV
								
								g_strWAV(intTemp) = strArrayWAV(lngTemp)
								lngArrayWAV(lngTemp) = intTemp
								
							Case CStr(2) 'BMP
								
								g_strBMP(intTemp) = strArrayBMP(lngTemp)
								g_strBGA(intTemp) = strArrayBGA(lngTemp)
								lngArrayBMP(lngTemp) = intTemp
								
						End Select
						
					Next j
					
					For j = 0 To UBound(g_strBGA)
						
						If Len(g_strBGA(j)) Then
							
							strArrayParamBGA = Split(g_strBGA(j), " ")
							
							If UBound(strArrayParamBGA) Then
								
								strArrayParamBGA(0) = modInput.strFromNum(lngArrayBMP(modInput.strToNum(strArrayParamBGA(0))), 2)
								g_strBGA(j) = Join(strArrayParamBGA, " ")
								
							End If
							
						End If
						
					Next j
					
					blnRefreshList = True
					
					For j = 0 To UBound(g_Obj) - 1
						
						With g_Obj(j)
							
							Select Case .intCh
								
								Case Is >= 11
									
									.sngValue = lngArrayWAV(.sngValue)
									
								Case 4, 6, 7
									
									.sngValue = lngArrayBMP(.sngValue)
									
							End Select
							
						End With
						
					Next j
					
				Case modMain.CMD_LOG.LIST_DEL
					
					Select Case Mid(strArray(i), 3, 1)
						
						Case CStr(1) '#WAV
							
							g_strWAV(modInput.strToNum(Mid(strArray(i), 4, 2))) = Mid(strArray(i), 6)
							
						Case CStr(2) '#BMP
							
							g_strBMP(modInput.strToNum(Mid(strArray(i), 4, 2))) = Mid(strArray(i), 6)
							
						Case CStr(3) '#BGA
							
							g_strBGA(modInput.strToNum(Mid(strArray(i), 4, 2))) = Mid(strArray(i), 6)
							
					End Select
					
					blnRefreshList = True
					
			End Select
			
		Next i
		
		If blnRefreshList Then Call RefreshList()
		
		Call modDraw.ArrangeObj()
		
		Call SaveChanges()
		
		Call modDraw.InitVerticalLine()
		
	End Sub
	
	Public Sub mnuFileConvertWizard_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileConvertWizard.Click
		
		With frmWindowConvert
			
			.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Left) + (VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
			.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) + (VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)
			
		End With
		
		Call VB6.ShowForm(frmWindowConvert, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mnuFileOpenDirectory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpenDirectory.Click
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Len(g_BMS.strDir) Then
			
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			If Len(g_strFiler) <> 0 And Dir(g_strFiler) <> vbNullString Then '�w�肵���t�@�C�����g�p
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call ShellExecute(Me.Handle.ToInt32, "open", Chr(34) & g_strFiler & Chr(34), Chr(34) & g_BMS.strDir & Chr(34), "", SW_SHOWNORMAL)
				
			Else 'Explorer �ŊJ��
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call ShellExecute(Me.Handle.ToInt32, "Explore", Chr(34) & g_BMS.strDir & Chr(34), "", "", SW_SHOWNORMAL)
				
			End If
			
		End If
		
	End Sub
	
	Public Sub mnuHelpAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpAbout.Click
		
		With frmWindowAbout
			
			.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Me.Left) + VB6.PixelsToTwipsX(Me.Width) \ 2) - VB6.PixelsToTwipsX(.Width) \ 2)
			.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(Me.Top) + VB6.PixelsToTwipsY(Me.Height) \ 2) - VB6.PixelsToTwipsY(.Height) \ 2)
			
			Call .Show()
			
		End With
		
	End Sub
	
	Public Sub mnuHelpOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpOpen.Click
		
		Call ShellExecute(0, vbNullString, g_strAppDir & g_strHelpFilename, vbNullString, vbNullString, SW_SHOWNORMAL)
		
	End Sub
	
	Public Sub mnuOptionsItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOptionsItem.Click
		Dim Index As Short = mnuOptionsItem.GetIndex(eventSender)
		
		mnuOptionsItem(Index).Checked = Not mnuOptionsItem(Index).Checked
		
		Select Case Index
			
			Case MENU_OPTIONS.USE_OLD_FORMAT
				
				m_blnPreview = False
				lstWAV.SelectedIndex = 0
				lstBMP.SelectedIndex = 0
				lstBGA.SelectedIndex = 0
				m_blnPreview = True
				
				Call RefreshList()
				Call modDraw.Redraw()
				
			Case MENU_OPTIONS.OBJ_FILENAME, MENU_OPTIONS.VERTICAL_INFO, MENU_OPTIONS.LANE_BGCOLOR
				
				Call modDraw.Redraw()
				
			Case MENU_OPTIONS.TITLE_FILENAME
				
				Me.Text = g_strAppTitle
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Len(g_BMS.strDir) Then
					
					If mnuOptionsItem(MENU_OPTIONS.TITLE_FILENAME).Checked Then
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Me.Text = Me.Text & " - " & g_BMS.strFileName
						
					Else
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Me.Text = Me.Text & " - " & g_BMS.strDir & g_BMS.strFileName
						
					End If
					
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.blnSaveFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Not g_BMS.blnSaveFlag Then Me.Text = Me.Text & " *"
				
		End Select
		
	End Sub
	
	Public Sub mnuTheme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTheme.Click
		Dim Index As Short = mnuTheme.GetIndex(eventSender)
		Dim modMain As Object
		
		Dim i As Integer
		
		For i = 1 To mnuTheme.UBound
			
			mnuTheme(i).Checked = False
			
		Next i
		
		With mnuTheme(Index)
			
			.Checked = True
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.LoadThemeFile �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call modMain.LoadThemeFile("theme\" & g_strThemeFileName(Index))
			
		End With
		
		Call Redraw()
		
	End Sub
	
	Public Sub mnuToolsSetting_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolsSetting.Click
		
		With frmWindowViewer
			
			.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Left) + (VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
			.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) + (VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)
			
			Call VB6.ShowForm(frmWindowViewer, VB6.FormShowConstants.Modal, Me)
			
		End With
		
	End Sub
	
	Public Sub mnuViewItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuViewItem.Click
		Dim Index As Short = mnuViewItem.GetIndex(eventSender)
		
		mnuViewItem(Index).Checked = Not mnuViewItem(Index).Checked
		Call frmMain_Resize(Me, New System.EventArgs())
		
	End Sub
	
	Public Sub mnuEditCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditCopy.Click
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim intTemp As Short
		
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			
			Call My.Computer.Clipboard.Clear()
			'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
			
			Exit Sub
			
		ElseIf TypeOf VB6.GetActiveControl() Is System.Windows.Forms.ComboBox Then 
			
			'UPGRADE_ISSUE: Control Style �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If VB6.GetActiveControl().Style = 0 Then
				
				Call My.Computer.Clipboard.Clear()
				'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Call My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
				
				Exit Sub
				
			End If
			
		End If
		
		For i = 0 To UBound(g_Obj) - 1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If g_Obj(i).intSelect = modMain.OBJ_SELECT.Selected Then
				
				intTemp = 1
				
				Exit For
				
			End If
			
		Next i
		
		If intTemp = 0 Then Exit Sub
		
		Call CopyToClipboard()
		
		For i = 0 To UBound(g_Obj) - 1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then g_Obj(i).intSelect = modMain.OBJ_SELECT.NON_SELECT
			
		Next i
		
		Call modDraw.Redraw()
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditCopy_Click")
	End Sub
	
	Public Sub mnuEditCut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditCut.Click
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim intTemp As Short
		
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			
			Call My.Computer.Clipboard.Clear()
			'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
			'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			VB6.GetActiveControl().SelText = ""
			
			Exit Sub
			
		ElseIf TypeOf VB6.GetActiveControl() Is System.Windows.Forms.ComboBox Then 
			
			'UPGRADE_ISSUE: Control Style �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If VB6.GetActiveControl().Style = 0 Then
				
				Call My.Computer.Clipboard.Clear()
				'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Call My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
				'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				VB6.GetActiveControl().SelText = ""
				
				Exit Sub
				
			End If
			
		End If
		
		For i = 0 To UBound(g_Obj) - 1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If g_Obj(i).intSelect = modMain.OBJ_SELECT.Selected Then
				
				intTemp = 1
				
				Exit For
				
			End If
			
		Next i
		
		If intTemp = 0 Then Exit Sub
		
		Call CopyToClipboard()
		
		Call mnuEditDelete_Click(mnuEditDelete, New System.EventArgs())
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditCut_Click")
	End Sub
	
	Public Sub mnuEditDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditDelete.Click
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim strArray() As String
		
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			
			'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If Len(VB6.GetActiveControl().SelText) = 0 Then
				
				'UPGRADE_ISSUE: Control SelLength �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				VB6.GetActiveControl().SelLength = 1
				
			End If
			
			'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			VB6.GetActiveControl().SelText = ""
			
			Exit Sub
			
		ElseIf TypeOf VB6.GetActiveControl() Is System.Windows.Forms.ComboBox Then 
			
			'UPGRADE_ISSUE: Control Style �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If VB6.GetActiveControl().Style = 0 Then
				
				'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				If Len(VB6.GetActiveControl().SelText) = 0 Then
					
					'UPGRADE_ISSUE: Control SelLength �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
					VB6.GetActiveControl().SelLength = 1
					
				End If
				
				'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				VB6.GetActiveControl().SelText = ""
				
				Exit Sub
				
			End If
			
		End If
		
		For i = 0 To UBound(g_Obj) - 1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then
				
				lngTemp = lngTemp + 1
				
			End If
			
		Next i
		
		If lngTemp = 0 Then Exit Sub
		
		'g_strInputLog(g_lngInputLogPos) = ""
		ReDim strArray(lngTemp - 1)
		lngTemp = 0
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then
					
					strArray(lngTemp) = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
					lngTemp = lngTemp + 1
					
					Call modDraw.RemoveObj(i)
					
				End If
				
			End With
			
		Next i
		
		Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))
		
		Call modDraw.ArrangeObj()
		
		Call modDraw.Redraw()
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditDelete_Click")
	End Sub
	
	Public Sub mnuEditMode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditMode.Click
		Dim Index As Short = mnuEditMode.GetIndex(eventSender)
		
		CType(tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = False
		CType(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = False
		CType(tlbMenu.Items.Item("Delete"), ToolStripButton).Checked = False
		'UPGRADE_WARNING: �R���N�V���� tlbMenu.Buttons �̉����� 1 ���� 0 �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"' ���N���b�N���Ă��������B
		CType(tlbMenu.Items.Item(Index + 7), ToolStripButton).Checked = True
		
		Select Case Index
			
			Case 0 : staMain.Items.Item("Mode").Text = g_strStatusBar(20)
				
			Case 1 : staMain.Items.Item("Mode").Text = g_strStatusBar(21)
				
			Case 2 : staMain.Items.Item("Mode").Text = g_strStatusBar(22)
				
		End Select
		
	End Sub
	
	Public Sub mnuEditPaste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditPaste.Click
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim j As Integer
		Dim lngArg As Integer
		Dim strArray() As String
		
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			
			'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: Clipboard ���\�b�h Clipboard.GetText �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			VB6.GetActiveControl().SelText = My.Computer.Clipboard.GetText()
			
			Exit Sub
			
		ElseIf TypeOf VB6.GetActiveControl() Is System.Windows.Forms.ComboBox Then 
			
			'UPGRADE_ISSUE: Control Style �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If VB6.GetActiveControl().Style = 0 Then
				
				'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: Clipboard ���\�b�h Clipboard.GetText �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
				VB6.GetActiveControl().SelText = My.Computer.Clipboard.GetText()
				
				Exit Sub
				
			End If
			
		End If
		
		Call modDraw.ObjSelectCancel()
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intStartMeasure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		For i = g_disp.intStartMeasure To 999
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(i).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If g_disp.Y <= g_Measure(i).lngY Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intStartMeasure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				g_disp.intStartMeasure = i
				
				Exit For
				
			End If
			
		Next i
		
		strArray = Split(My.Computer.Clipboard.GetText, vbCrLf)
		
		If UBound(strArray) < 2 Then Exit Sub
		
		If strArray(0) <> "BMSE ClipBoard Object Data Format" Then Exit Sub
		
		For i = 1 To UBound(strArray) - 1
			
			With g_Obj(UBound(g_Obj))
				
				.lngID = g_lngIDNum
				g_lngObjID(g_lngIDNum) = UBound(g_Obj)
				g_lngIDNum = g_lngIDNum + 1
				ReDim Preserve g_lngObjID(g_lngIDNum)
				.intCh = CShort(VB.Left(strArray(i), 3))
				.intAtt = CShort(Mid(strArray(i), 4, 1))
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intStartMeasure �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(g_disp.intStartMeasure).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.lngPosition = Val(Mid(strArray(i), 5, 7)) + g_Measure(g_disp.intStartMeasure).lngY
				.sngValue = Val(Mid(strArray(i), 12))
				.lngHeight = 0
				'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.intSelect = modMain.OBJ_SELECT.Selected
				
				For j = 0 To 999
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(j).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .lngPosition < g_Measure(j).lngY Then
						
						Exit For
						
					Else
						
						.intMeasure = j
						
					End If
					
				Next j
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(g_Obj(UBound(g_Obj)).intMeasure).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.lngPosition = .lngPosition - g_Measure(.intMeasure).lngY
				
				strArray(i - 1) = modInput.strFromNum(modMain.CMD_LOG.OBJ_ADD) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
				
				If modDraw.lngChangeMaxMeasure(.intMeasure) Then lngArg = 1
				
			End With
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(g_Obj(UBound(g_Obj)).intMeasure).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If g_Obj(UBound(g_Obj)).lngPosition < g_Measure(g_Obj(UBound(g_Obj)).intMeasure).intLen Then ReDim Preserve g_Obj(UBound(g_Obj) + 1)
			
		Next i
		
		If lngArg Then Call modDraw.ChangeResolution()
		
		Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))
		
		Call modDraw.Redraw()
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditPaste_Click")
	End Sub
	
	Public Sub mnuFileExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileExit.Click
		Dim modMain As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.intSaveCheck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If modMain.intSaveCheck() Then Exit Sub
		
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp()
		
	End Sub
	
	Public Sub mnuHelpWeb_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpWeb.Click
		
		Call ShellExecute(0, vbNullString, "http://ucn.tokonats.net/", vbNullString, vbNullString, SW_SHOWNORMAL)
		
	End Sub
	
	Public Sub mnuLanguage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLanguage.Click
		Dim Index As Short = mnuLanguage.GetIndex(eventSender)
		Dim modMain As Object
		
		Dim i As Integer
		
		For i = 1 To mnuLanguage.UBound
			
			mnuLanguage(i).Checked = False
			
		Next i
		
		With mnuLanguage(Index)
			
			.Checked = True
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.LoadLanguageFile �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call modMain.LoadLanguageFile("lang\" & g_strLangFileName(Index))
			
		End With
		
		Call modDraw.Redraw()
		
	End Sub
	
	Public Sub mnuFileNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileNew.Click
		Dim lngDeleteFile As Object
		Dim modMain As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.intSaveCheck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If modMain.intSaveCheck() Then Exit Sub
		
		Me.Text = g_strAppTitle & " - Now Initializing"
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")
		
		With g_BMS
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.strDir = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.strFileName = ""
			
		End With
		
		Call modInput.LoadBMSStart()
		
		Call modInput.LoadBMSEnd()
		
	End Sub
	
	Public Sub mnuFileOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpen.Click
		Dim lngDeleteFile As Object
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim strArray() As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.intSaveCheck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If modMain.intSaveCheck() Then Exit Sub
		
		'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
		With dlgMain
			
			'UPGRADE_WARNING: Filter �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			.Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.FileName = g_BMS.strFileName
			
			Call .ShowDialog()
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")
			
			strArray = Split(.FileName, "\")
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			g_BMS.strDir = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			g_BMS.strFileName = strArray(UBound(strArray))
			
			Call modInput.LoadBMS()
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.RecentFilesRotation �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.InitialDirectory = g_BMS.strDir
			
		End With
		
Err_Renamed: 
	End Sub
	
	Public Sub mnuToolsPlay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolsPlay.Click
		Dim g_Message As Object
		
		Dim strFileName As String
		Dim strPath As String
		
		If Mid(g_Viewer(cboViewer.SelectedIndex + 1).strAppPath, 2, 2) <> ":\" Then
			
			strPath = g_strAppDir & g_Viewer(cboViewer.SelectedIndex + 1).strAppPath
			
		Else
			
			strPath = g_Viewer(cboViewer.SelectedIndex + 1).strAppPath
			
		End If
		
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If Dir(strPath, FileAttribute.Normal) = vbNullString Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
			Exit Sub
			
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Len(g_BMS.strDir) Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strFileName = g_BMS.strDir & "___bmse_temp.bms" & vbNullString
			
		Else
			
			strFileName = g_strAppDir & "___bmse_temp.bms" & vbNullString
			
		End If
		
		Call modOutput.CreateBMS(strFileName, 1)
		Call mciSendString("close PREVIEW", vbNullString, 0, 0)
		
		With g_Viewer(cboViewer.SelectedIndex + 1)
			
			Call ShellExecute(0, "open", Chr(34) & strPath & Chr(34), strCmdDecode(.strArgPlay, strFileName), "", SW_SHOWNORMAL)
			
		End With
		
	End Sub
	
	Public Sub mnuToolsPlayAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolsPlayAll.Click
		Dim g_Message As Object
		
		Dim strFileName As String
		Dim strPath As String
		
		If Mid(g_Viewer(cboViewer.SelectedIndex + 1).strAppPath, 2, 2) <> ":\" Then
			
			strPath = g_strAppDir & g_Viewer(cboViewer.SelectedIndex + 1).strAppPath
			
		Else
			
			strPath = g_Viewer(cboViewer.SelectedIndex + 1).strAppPath
			
		End If
		
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If Dir(strPath, FileAttribute.Normal) = vbNullString Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
			Exit Sub
			
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Len(g_BMS.strDir) Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strFileName = g_BMS.strDir & "___bmse_temp.bms" & vbNullString
			
		Else
			
			strFileName = g_strAppDir & "___bmse_temp.bms" & vbNullString
			
		End If
		
		Call modOutput.CreateBMS(strFileName, 1)
		Call mciSendString("close PREVIEW", vbNullString, 0, 0)
		
		With g_Viewer(cboViewer.SelectedIndex + 1)
			
			Call ShellExecute(0, "open", Chr(34) & strPath & Chr(34), strCmdDecode(.strArgAll, strFileName), "", SW_SHOWNORMAL)
			
		End With
		
	End Sub
	
	Public Sub mnuToolsPlayStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolsPlayStop.Click
		Dim g_Message As Object
		
		Dim strFileName As String
		Dim strPath As String
		
		If Mid(g_Viewer(cboViewer.SelectedIndex + 1).strAppPath, 2, 2) <> ":\" Then
			
			strPath = g_strAppDir & g_Viewer(cboViewer.SelectedIndex + 1).strAppPath
			
		Else
			
			strPath = g_Viewer(cboViewer.SelectedIndex + 1).strAppPath
			
		End If
		
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If Dir(strPath, FileAttribute.Normal) = vbNullString Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
			Exit Sub
			
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Len(g_BMS.strDir) Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strFileName = g_BMS.strDir & "___bmse_temp.bms" & vbNullString
			
		Else
			
			strFileName = g_strAppDir & "___bmse_temp.bms" & vbNullString
			
		End If
		
		Call mciSendString("close PREVIEW", vbNullString, 0, 0)
		
		With g_Viewer(cboViewer.SelectedIndex + 1)
			
			Call ShellExecute(0, "open", Chr(34) & strPath & Chr(34), strCmdDecode(.strArgStop, strFileName), "", SW_SHOWNORMAL)
			
		End With
		
	End Sub
	
	Public Sub mnuRecentFiles_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRecentFiles.Click
		Dim Index As Short = mnuRecentFiles.GetIndex(eventSender)
		Dim lngDeleteFile As Object
		Dim g_Message As Object
		Dim modMain As Object
		
		Dim strArray() As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.intSaveCheck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If modMain.intSaveCheck() Then Exit Sub
		
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If Dir(Mid(mnuRecentFiles(Index).Text, 4)) = vbNullString Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Message(ERR_LOAD_CANCEL) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(mnuRecentFiles(Index).Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
			Exit Sub
			
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")
		
		strArray = Split(mnuRecentFiles(Index).Text, "\")
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_BMS.strDir = Mid(mnuRecentFiles(Index).Text, 4, Len(mnuRecentFiles(Index).Text) - Len(strArray(UBound(strArray))) - 3)
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_BMS.strFileName = strArray(UBound(strArray))
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		dlgMainOpen.InitialDirectory = g_BMS.strDir
		dlgMainSave.InitialDirectory = g_BMS.strDir
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.RecentFilesRotation �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)
		
		Call modInput.LoadBMS()
		
	End Sub
	
	Public Sub mnuFileSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSave.Click
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If g_BMS.strDir <> "" And g_BMS.strFileName <> "" Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call modOutput.CreateBMS(g_BMS.strDir & g_BMS.strFileName)
			
		Else
			
			Call mnuFileSaveAs_Click(mnuFileSaveAs, New System.EventArgs())
			
		End If
		
	End Sub
	
	Public Sub mnuFileSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSaveAs.Click
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim strArray() As String
		
		'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
		With dlgMain
			
			'UPGRADE_WARNING: Filter �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			.Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.FileName = g_BMS.strFileName
			
			Call .ShowDialog()
			
			strArray = Split(.FileName, "\")
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			g_BMS.strDir = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			g_BMS.strFileName = strArray(UBound(strArray))
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call modOutput.CreateBMS(g_BMS.strDir & g_BMS.strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strFileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.RecentFilesRotation �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.InitialDirectory = g_BMS.strDir
			
		End With
		
Err_Renamed: 
	End Sub
	
	Public Sub mnuEditSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditSelectAll.Click
		Dim modMain As Object
		
		Dim i As Integer
		
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			
			'UPGRADE_ISSUE: Control SelStart �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			VB6.GetActiveControl().SelStart = 0
			'UPGRADE_ISSUE: Control SelLength �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: Control Text �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			VB6.GetActiveControl().SelLength = Len(VB6.GetActiveControl().Text)
			
			Exit Sub
			
		ElseIf TypeOf VB6.GetActiveControl() Is System.Windows.Forms.ComboBox Then 
			
			'UPGRADE_ISSUE: Control Style �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			If VB6.GetActiveControl().Style = 0 Then
				
				'UPGRADE_ISSUE: Control SelStart �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				VB6.GetActiveControl().SelStart = 0
				'UPGRADE_ISSUE: Control SelLength �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: Control Text �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				VB6.GetActiveControl().SelLength = Len(VB6.GetActiveControl().Text)
				
				Exit Sub
				
			End If
			
		End If
		
		For i = 0 To UBound(g_Obj) - 1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			g_Obj(i).intSelect = modMain.OBJ_SELECT.Selected
			
		Next i
		
		Call modDraw.Redraw()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g optChangeBottom.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub optChangeBottom_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optChangeBottom.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optChangeBottom.GetIndex(eventSender)
			
			Dim i As Integer
			
			For i = fraBottom.LBound To fraBottom.UBound
				
				fraBottom(i).Visible = False
				
			Next i
			
			fraBottom(Index).Visible = True
			
		End If
	End Sub
	
	'UPGRADE_WARNING: �C�x���g optChangeTop.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub optChangeTop_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optChangeTop.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optChangeTop.GetIndex(eventSender)
			
			Dim i As Integer
			
			For i = fraTop.LBound To fraTop.UBound
				
				fraTop(i).Visible = False
				
			Next i
			
			fraTop(Index).Visible = True
			
		End If
	End Sub
	
	'UPGRADE_ISSUE: PictureBox �C�x���g picMain.KeyDown �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' ���N���b�N���Ă��������B
	Private Sub picMain_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
		
		Dim lngTemp As Integer
		Dim intTemp As Short
		Dim blnTemp As Boolean
		
		blnTemp = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Shift �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Mouse.Shift = Shift
		
		lngTemp = vsbMain.Value
		intTemp = hsbMain.Value
		
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.ControlKey, System.Windows.Forms.Keys.ShiftKey ', vbKeyMenu
				
				If tlbMenu.Items.Item("Write").Checked = False Then blnTemp = False
				
			Case System.Windows.Forms.Keys.NumPad0
				
				cboDispGridSub.SelectedIndex = cboDispGridSub.Items.Count - 1
				
			Case System.Windows.Forms.Keys.NumPad1
				
				cboDispGridSub.SelectedIndex = 1
				
			Case System.Windows.Forms.Keys.NumPad2
				
				cboDispGridSub.SelectedIndex = 2
				
			Case System.Windows.Forms.Keys.NumPad3
				
				cboDispGridSub.SelectedIndex = 3
				
			Case System.Windows.Forms.Keys.NumPad4
				
				cboDispGridSub.SelectedIndex = 6
				
			Case System.Windows.Forms.Keys.NumPad5
				
				cboDispGridSub.SelectedIndex = 7
				
			Case System.Windows.Forms.Keys.NumPad6
				
				cboDispGridSub.SelectedIndex = 8
				
			Case System.Windows.Forms.Keys.Home
				
				lngTemp = (vsbMain.Maximum - vsbMain.LargeChange + 1)
				
			Case System.Windows.Forms.Keys.End
				
				lngTemp = vsbMain.Minimum
				
			Case System.Windows.Forms.Keys.PageUp
				
				lngTemp = lngTemp + vsbMain.LargeChange
				
			Case System.Windows.Forms.Keys.PageDown
				
				lngTemp = lngTemp - vsbMain.LargeChange
				
			Case System.Windows.Forms.Keys.Up
				
				lngTemp = lngTemp + vsbMain.SmallChange
				
			Case System.Windows.Forms.Keys.Down
				
				lngTemp = lngTemp - vsbMain.SmallChange
				
			Case System.Windows.Forms.Keys.Left
				
				intTemp = intTemp - hsbMain.SmallChange
				
			Case System.Windows.Forms.Keys.Right
				
				intTemp = intTemp + hsbMain.SmallChange
				
			Case Else
				
				blnTemp = False
				
		End Select
		
		With vsbMain
			
			If lngTemp > .Minimum Then
				
				.Value = .Minimum
				
			ElseIf lngTemp < 0 Then 
				
				.Value = 0
				
			Else
				
				.Value = lngTemp
				
			End If
			
		End With
		
		With hsbMain
			
			If intTemp < 0 Then
				
				.Value = 0
				
			ElseIf intTemp > (.Maximum - .LargeChange + 1) Then 
				
				.Value = (.Maximum - .LargeChange + 1)
				
			Else
				
				.Value = intTemp
				
			End If
			
		End With
		
		If blnTemp Then
			
			If Me.tlbMenu.Items.Item("Write").Checked = False Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Button �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.blnFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If g_SelectArea.blnFlag = True Or (g_Obj(UBound(g_Obj)).intCh <> 0 And g_Mouse.Button <> 0) Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call picMain_MouseMove(picMain, New System.Windows.Forms.MouseEventArgs(VB6.MouseButtonConstants.LeftButton * &H100000, 0, g_Mouse.X, g_Mouse.Y, 0))
					
				End If
				
			Else
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)
				
			End If
			
		End If
		
	End Sub
	
	'UPGRADE_ISSUE: PictureBox �C�x���g picMain.KeyUp �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' ���N���b�N���Ă��������B
	Private Sub picMain_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Shift �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_Mouse.Shift = Shift
		
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.ControlKey, System.Windows.Forms.Keys.ShiftKey
				
				If tlbMenu.Items.Item("Write").Checked = True Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)
					
				End If
				
		End Select
		
	End Sub
	
	Private Sub picMain_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim strTemp As String
		'Dim intNum      As Long
		Dim lngTemp As Integer
		Dim i As Integer
		Dim tempObj As g_udtObj
		Dim strArray() As String
		
		If g_blnIgnoreInput Then Exit Sub
		
		m_blnMouseDown = True
		
		If Button = VB6.MouseButtonConstants.LeftButton Then '���N���b�N
			
			If tlbMenu.Items.Item("Delete").Checked = True Then
				
				If g_Obj(UBound(g_Obj)).intCh Then
					
					'/// Undo
					With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
						
						Call g_InputLog.AddData(modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue & modLog.getSeparator)
						
					End With
					
					Call modDraw.RemoveObj(g_Obj(UBound(g_Obj)).lngHeight)
					
					Call modDraw.ArrangeObj()
					
					Call RemoveObj(UBound(g_Obj))
					
				End If
				
				Call modDraw.ObjSelectCancel()
				Call modDraw.Redraw()
				
			ElseIf tlbMenu.Items.Item("Edit").Checked = True Then 
				
				If g_Obj(UBound(g_Obj)).intCh <> 0 Then '�I�u�W�F�̂���Ƃ���ŉ��������ۂ���
					
					With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
						
						If VB6.GetItemData(cboDispGridSub, cboDispGridSub.SelectedIndex) Then
							
							lngTemp = 192 \ (VB6.GetItemData(cboDispGridSub, cboDispGridSub.SelectedIndex))
							lngTemp = .lngPosition - (.lngPosition \ lngTemp) * lngTemp
							
						End If
						
					End With
					
					'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then '�����I�����ۂ���
						
						If Shift And VB6.ShiftConstants.CtrlMask Then
							
							'UPGRADE_WARNING: �I�u�W�F�N�g tempObj �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							tempObj = g_Obj(UBound(g_Obj))
							
							'ReDim strArray(intNum - 1)
							ReDim strArray(0)
							'intNum = 0
							
							For i = 0 To UBound(g_Obj) - 1
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then
									
									With g_Obj(i)
										
										'UPGRADE_WARNING: �I�u�W�F�N�g g_Obj(UBound()) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										g_Obj(UBound(g_Obj)) = g_Obj(i)
										g_Obj(UBound(g_Obj)).lngID = g_lngIDNum
										
										strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_ADD) & modInput.strFromNum(g_lngIDNum, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
										'intNum = intNum + 1
										ReDim Preserve strArray(UBound(strArray) + 1)
										
										g_lngObjID(g_lngIDNum) = UBound(g_Obj)
										g_lngIDNum = g_lngIDNum + 1
										ReDim Preserve g_lngObjID(g_lngIDNum)
										
										'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										.intSelect = modMain.OBJ_SELECT.NON_SELECT
										
									End With
									
									If i = tempObj.lngHeight Then tempObj.lngHeight = UBound(g_Obj)
									
									ReDim Preserve g_Obj(UBound(g_Obj) + 1)
									
								End If
								
							Next i
							
							If UBound(strArray) Then
								
								ReDim Preserve strArray(UBound(strArray) - 1)
								
								Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_Obj(UBound()) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								g_Obj(UBound(g_Obj)) = tempObj
								
							End If
							
						End If
						
						ReDim m_tempObj(0)
						
						For i = 0 To UBound(g_Obj) - 1
							
							With g_Obj(i)
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then
									
									'UPGRADE_WARNING: �I�u�W�F�N�g m_tempObj(UBound()) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									m_tempObj(UBound(m_tempObj)) = g_Obj(i)
									
									.lngHeight = UBound(m_tempObj)
									
									ReDim Preserve m_tempObj(UBound(m_tempObj) + 1)
									
								End If
								
							End With
							
						Next i
						
						'UPGRADE_WARNING: �I�u�W�F�N�g m_tempObj(UBound()) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						m_tempObj(UBound(m_tempObj)) = g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
						
						With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
							
							'�v���r���[
							If mnuOptionsItem(MENU_OPTIONS.SELECT_PREVIEW).Checked = True And ((.intCh >= 11 And .intCh <= 29) Or .intCh > 100) Then
								
								strTemp = g_strWAV(.sngValue)
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
								If strTemp <> "" And Dir(g_BMS.strDir & strTemp) <> vbNullString Then
									
									Call PreviewWAV(strTemp)
									
								End If
								
							End If
							
							'�I�u�W�F���O���b�h�ɂ��킹��
							'If Not Shift And vbShiftMask Then
							
							'If lngTemp <> 0 And mnuOptionsItem(MOVE_ON_GRID).Checked = True Then
							
							'For i = 0 To UBound(g_Obj) - 1
							
							'With g_Obj(i)
							
							'If .intSelect <> NON_SELECT Then
							
							'.lngPosition = .lngPosition - lngTemp
							
							'Do While .lngPosition < 0 And .intMeasure <> 0
							
							'.intMeasure = .intMeasure - 1
							'.lngPosition = .lngPosition + g_Measure(.intMeasure).intLen
							
							'Loop
							
							'Call SaveChanges
							
							'End If
							
							'End With
							
							'Next i
							
							'End If
							
							'End If
							
						End With
						
					Else '�P���I�����ۂ���
						
						If Not Shift And VB6.ShiftConstants.CtrlMask Then
							
							Call modDraw.ObjSelectCancel()
							
						End If
						
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intSelect = modMain.OBJ_SELECT.Selected
						
						Call modDraw.MoveSelectedObj()
						
						With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
							
							ReDim m_tempObj(0)
							
							For i = 0 To UBound(g_Obj) - 1
								
								With g_Obj(i)
									
									'UPGRADE_WARNING: �I�u�W�F�N�g m_tempObj(UBound()) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									m_tempObj(UBound(m_tempObj)) = g_Obj(i)
									.lngHeight = UBound(m_tempObj)
									ReDim Preserve m_tempObj(UBound(m_tempObj) + 1)
									
								End With
								
							Next i
							
							'UPGRADE_WARNING: �I�u�W�F�N�g m_tempObj(UBound()) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							m_tempObj(UBound(m_tempObj)) = g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
							
							'�I�u�W�F���O���b�h�ɂ��킹��
							'If Not Shift And vbShiftMask Then
							
							'If lngTemp <> 0 And mnuOptionsItem(MOVE_ON_GRID).Checked = True Then
							
							'.lngPosition = .lngPosition - lngTemp
							
							'Do While .lngPosition < 0 And .intMeasure <> 0
							
							'.intMeasure = .intMeasure - 1
							'.lngPosition = .lngPosition + g_Measure(.intMeasure).intLen
							
							'Loop
							
							'Call SaveChanges
							
							'End If
							
							'End If
							
							'�v���r���[
							If mnuOptionsItem(MENU_OPTIONS.SELECT_PREVIEW).Checked Then
								
								Select Case .intCh
									
									Case 11 To 29, Is > 100
										
										strTemp = g_strWAV(.sngValue)
										
										'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
										If strTemp <> "" And Dir(g_BMS.strDir & strTemp) <> vbNullString Then
											
											Call PreviewWAV(strTemp)
											
										End If
										
									Case 4, 6, 7
										
										If Len(g_strBGA(.sngValue)) Then
											
											Call PreviewBGA(.sngValue)
											
										Else
											
											strTemp = g_strBMP(.sngValue)
											
											'UPGRADE_WARNING: �I�u�W�F�N�g g_BMS.strDir �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
											'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
											If strTemp <> "" And Dir(g_BMS.strDir & strTemp) <> vbNullString Then
												
												Call PreviewBMP(strTemp)
												
											End If
											
										End If
										
								End Select
								
							End If
							
						End With
						
					End If
					
					Call modDraw.Redraw()
					
				Else '�I�u�W�F�̂Ȃ��Ƃ���ŉ��������ۂ���
					
					If Not Shift And VB6.ShiftConstants.CtrlMask Then
						
						Call modDraw.ObjSelectCancel()
						
						Call modDraw.Redraw()
						
					Else
						
						For i = 0 To UBound(g_Obj) - 1
							
							With g_Obj(i)
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then
									
									'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									.intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT
									
								End If
								
							End With
							
						Next i
						
						Call modDraw.Redraw()
						
					End If
					
					With g_SelectArea
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.blnFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.blnFlag = True
						'.X1 = (X + g_disp.X) / g_disp.Width
						'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Width �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.X1 = X / g_disp.Width + g_disp.X
						'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Height �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Y1 = (picMain.ClientRectangle.Height - Y) / g_disp.Height + g_disp.Y
						'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.X2 = .X1
						'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Y2 = .Y1
						
					End With
					
					Call modDraw.DrawSelectArea()
					
				End If
				
				'Call modDraw.Redraw
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intEffect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If g_disp.intEffect Then Call modEasterEgg.DrawEffect()
				
			Else 'If tlbMenu.Buttons("Write").Value = tbrPressed Then
				
				Call modDraw.ObjSelectCancel()
				Call modDraw.Redraw()
				
				picMain.Font = VB6.FontChangeSize(picMain.Font, 8)
				
				Call modDraw.InitPen()
				Call modDraw.DrawObj(g_Obj(UBound(g_Obj)))
				Call modDraw.DeletePen()
				
			End If
			
		ElseIf Button = VB6.MouseButtonConstants.RightButton Then  '�E�N���b�N
			
			With g_Mouse
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Button �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Button = Button
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Shift �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Shift = Shift
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.X = X
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Y = Y
				
			End With
			
			Call DrawObjMax(X, Y, Shift)
			
		ElseIf Button = VB6.MouseButtonConstants.MiddleButton Then  '���N���b�N
			
			'�I�u�W�F�폜
			If g_Obj(UBound(g_Obj)).lngHeight < UBound(g_Obj) Then '�I�u�W�F�I��
				
				'���͗����ɒǉ�
				With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
					
					Call g_InputLog.AddData(modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue & modLog.getSeparator)
					
				End With
				
				'�I�u�W�F�폜
				Call modDraw.RemoveObj(g_Obj(UBound(g_Obj)).lngHeight)
				
				g_Obj(UBound(g_Obj)).intCh = 0
				g_Obj(UBound(g_Obj)).lngHeight = UBound(g_Obj)
				
				'����
				Call modDraw.ArrangeObj()
				
				'�ĕ`��
				Call modDraw.Redraw()
				
			End If
			
		End If
		
		g_blnIgnoreInput = False
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseDown")
	End Sub
	
	Private Sub picMain_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim modMain As Object
		Dim g_Message As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim strTemp As String
		Dim lngArg As Integer
		Dim strArray() As String
		
		m_intScrollDir = 0
		
		If g_blnIgnoreInput Then
			
			g_blnIgnoreInput = False
			
			Exit Sub
			
		End If
		
		If Not m_blnMouseDown Then Exit Sub
		
		m_blnMouseDown = False
		
		If Button = VB6.MouseButtonConstants.LeftButton Then
			
			If tlbMenu.Items.Item("Write").Checked = True Then
				
				With g_Obj(UBound(g_Obj))
					
					Select Case .intCh
						
						Case 8 'BPM
							
							With frmWindowInput
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.lblMainDisp.Text = g_Message(modMain.Message.INPUT_BPM)
								.txtMain.Text = "" 'strTemp
								
								Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)
								
							End With
							
							Select Case Val(frmWindowInput.txtMain.Text)
								
								Case 0
									
									Exit Sub
									
								Case Is > 65535
									
									Call MsgBox(g_Message(modMain.Message.ERR_OVERFLOW_LARGE), MsgBoxStyle.Critical, g_strAppTitle)
									
									Exit Sub
									
								Case Is < -65535
									
									Call MsgBox(g_Message(modMain.Message.ERR_OVERFLOW_SMALL), MsgBoxStyle.Critical, g_strAppTitle)
									
									Exit Sub
									
								Case Else
									
									.sngValue = Val(frmWindowInput.txtMain.Text)
									Call picMain.Focus()
									
							End Select
							
						Case 9 'STOP
							
							With frmWindowInput
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_Message() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.lblMainDisp.Text = g_Message(modMain.Message.INPUT_STOP)
								.txtMain.Text = "" 'strTemp
								
								Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)
								
							End With
							
							Select Case CInt(Val(frmWindowInput.txtMain.Text))
								
								Case Is <= 0
									
									Exit Sub
									
								Case Is > 65535
									
									Call MsgBox(g_Message(modMain.Message.ERR_OVERFLOW_LARGE), MsgBoxStyle.Critical, g_strAppTitle)
									
									Exit Sub
									
								Case Else
									
									.sngValue = CInt(Val(frmWindowInput.txtMain.Text))
									Call picMain.Focus()
									
							End Select
							
						Case 51 To 69
							
							.intCh = .intCh - 40
							'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_ATT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE
							
					End Select
					
					If .sngValue = 0 Then Exit Sub
					
					Call SaveChanges()
					
					If modDraw.lngChangeMaxMeasure(.intMeasure) Then Call modDraw.ChangeResolution()
					
				End With
				
				'g_strInputLog(g_lngInputLogPos) = ""
				strTemp = ""
				
				For i = UBound(g_Obj) - 1 To 0 Step -1
					
					If g_Obj(i).intMeasure = g_Obj(UBound(g_Obj)).intMeasure And g_Obj(i).lngPosition = g_Obj(UBound(g_Obj)).lngPosition And g_Obj(i).intCh = g_Obj(UBound(g_Obj)).intCh Then
						
						'If g_Obj(i).intAtt \ 2 = g_Obj(UBound(g_Obj)).intAtt \ 2 Then
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_ATT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If g_Obj(i).intAtt = g_Obj(UBound(g_Obj)).intAtt Or ((g_Obj(i).intAtt = modMain.OBJ_ATT.OBJ_NORMAL And g_Obj(UBound(g_Obj)).intAtt = modMain.OBJ_ATT.OBJ_INVISIBLE) Or (g_Obj(i).intAtt = modMain.OBJ_ATT.OBJ_INVISIBLE And g_Obj(UBound(g_Obj)).intAtt = modMain.OBJ_ATT.OBJ_NORMAL)) Then
							
							'Undo
							With g_Obj(i)
								
								'g_strInputLog(g_lngInputLogPos) = g_strInputLog(g_lngInputLogPos) & modInput.strFromNum(CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & Right$("0" & Hex$(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue & modLog.getSeparator
								strTemp = strTemp & modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue & modLog.getSeparator
								
							End With
							
							Call modDraw.RemoveObj(i)
							
						End If
						
					End If
					
				Next i
				
				'Undo
				With g_Obj(UBound(g_Obj))
					
					.lngID = g_lngIDNum
					strTemp = strTemp & modInput.strFromNum(modMain.CMD_LOG.OBJ_ADD) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue & modLog.getSeparator
					Call g_InputLog.AddData(strTemp)
					
					g_lngObjID(g_lngIDNum) = UBound(g_Obj)
					g_lngIDNum = g_lngIDNum + 1
					ReDim Preserve g_lngObjID(g_lngIDNum)
					
				End With
				
				ReDim Preserve g_Obj(UBound(g_Obj) + 1)
				
				Call modDraw.ArrangeObj()
				
				Call modDraw.Redraw()
				
			ElseIf tlbMenu.Items.Item("Edit").Checked = True Then 
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.blnFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If g_SelectArea.blnFlag Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.blnFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					g_SelectArea.blnFlag = False
					
					For i = 0 To UBound(g_Obj) - 1
						
						With g_Obj(i)
							
							'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If .intSelect = modMain.OBJ_SELECT.Selected Or .intSelect = modMain.OBJ_SELECT.SELECTAREA_IN Or .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT Then
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intSelect = modMain.OBJ_SELECT.Selected
								
							Else
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intSelect = modMain.OBJ_SELECT.NON_SELECT
								
							End If
							
						End With
						
					Next i
					
					Call modDraw.MoveSelectedObj()
					
				Else '�����I�����ۂ���
					
					For i = 0 To UBound(g_Obj) - 1
						
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then
							
							'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(m_tempObj(UBound(m_tempObj)).intMeasure).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intMeasure).lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If g_Obj(g_Obj(UBound(g_Obj)).lngHeight).lngPosition + g_Measure(g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intMeasure).lngY <> m_tempObj(UBound(m_tempObj)).lngPosition + g_Measure(m_tempObj(UBound(m_tempObj)).intMeasure).lngY Or g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intCh <> m_tempObj(UBound(m_tempObj)).intCh Then
								
								lngTemp = 1
								
							End If
							
							Exit For
							
						End If
						
					Next i
					
					If lngTemp Then
						
						ReDim strArray(0)
						
						For i = 0 To UBound(g_Obj) - 1
							
							With g_Obj(i)
								
								'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure(999).intLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If .intCh <= 0 Or .intCh > 1000 Or (.intMeasure = 0 And .lngPosition < 0) Or (.intMeasure = 999 And .lngPosition > g_Measure(999).intLen) Then
									
									With m_tempObj(g_Obj(i).lngHeight)
										
										strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
										ReDim Preserve strArray(UBound(strArray) + 1)
										
									End With
									
									Call modDraw.RemoveObj(i)
									
									'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								ElseIf .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then 
									
									strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_MOVE) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(m_tempObj(.lngHeight).intCh), 2) & modInput.strFromNum(m_tempObj(.lngHeight).intMeasure) & modInput.strFromNum(m_tempObj(.lngHeight).lngPosition, 3) & VB.Right("0" & Hex(.intCh), 2) & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3)
									ReDim Preserve strArray(UBound(strArray) + 1)
									
								End If
								
								If modDraw.lngChangeMaxMeasure(.intMeasure) Then lngArg = 1
								
							End With
							
						Next i
						
						If lngArg Then Call modDraw.ChangeResolution()
						
						Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))
						
					End If
					
					Call modDraw.ArrangeObj()
					
				End If
				
				Call modDraw.Redraw()
				
			End If
			
		ElseIf Button = VB6.MouseButtonConstants.RightButton Then 
			
			'UPGRADE_ISSUE: Form ���\�b�h frmMain.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			If Not m_blnIgnoreMenu Then Call PopupMenu(mnuContext)
			
			m_blnIgnoreMenu = False
			
		End If
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseUp")
	End Sub
	
	Public Sub picMain_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim modMain As Object
		On Error GoTo Err_Renamed
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim strTemp As String
		Dim rectTemp As RECT
		Dim blnSelect() As Boolean
		Dim blnYAxisFixed As Boolean
		
		'VB6 �o�O�΍�
		If Button And VB6.MouseButtonConstants.LeftButton Then
			
			If Not m_blnMouseDown Then
				
				Exit Sub
				
			End If
			
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.blnFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Dim value As Integer
		'UPGRADE_NOTE: str �� str_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim str_Renamed As String
		If Not g_SelectArea.blnFlag Then '�I��͈͂Ȃ�
			
			If Button = VB6.MouseButtonConstants.LeftButton And tlbMenu.Items.Item("Edit").Checked = True And g_Obj(UBound(g_Obj)).intCh <> 0 Then '�I�u�W�F�ړ���
				
				Call MoveObj(X, Y, Shift)
				
				'Y ���Œ�ړ�
				If Shift And VB6.ShiftConstants.ShiftMask Then blnYAxisFixed = True
				
			Else '����ȊO
				
				Call modDraw.DrawObjMax(X, Y, Shift)
				
				'�X�|�C�g�@�\
				If Button = VB6.MouseButtonConstants.RightButton And g_Obj(UBound(g_Obj)).lngHeight < UBound(g_Obj) Then
					
					With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
						
						Select Case .intCh
							
							Case modInput.OBJ_CH.CH_BGA, modInput.OBJ_CH.CH_POOR, modInput.OBJ_CH.CH_LAYER, Is > modInput.OBJ_CH.CH_KEY_MIN
								
								
								If mnuOptionsItem(MENU_OPTIONS.USE_OLD_FORMAT).Checked Then
									
									str_Renamed = modInput.strFromNum(.sngValue)
									
									'���� 01-FF ����Ȃ������� 01-ZZ �\���Ɉڍs����
									'ASCII �����Z�b�g�ł� 0-9 < A-Z < a-z
									If Asc(VB.Left(str_Renamed, 1)) > Asc("F") Or Asc(VB.Right(str_Renamed, 1)) > Asc("F") Then
										
										Call mnuOptionsItem_Click(mnuOptionsItem.Item(MENU_OPTIONS.USE_OLD_FORMAT), New System.EventArgs())
										value = .sngValue
										
									Else
										
										value = Val("&H" & str_Renamed)
										
									End If
									
								Else
									
									value = .sngValue
									
								End If
								
								m_blnPreview = False
								
								If .intCh > modInput.OBJ_CH.CH_KEY_MIN Then
									
									lstWAV.SelectedIndex = value - 1
									
								Else
									
									If optChangeBottom(2).Checked Then
										
										lstBGA.SelectedIndex = value - 1
										
									Else
										
										lstBMP.SelectedIndex = value - 1
										
									End If
									
								End If
								
								m_blnPreview = True
								
						End Select
						
						'�|�b�v�A�b�v��\�����Ȃ�
						m_blnIgnoreMenu = True
						
					End With
					
				End If
				
			End If
			
		Else '�I��͈͂���
			
			With g_Mouse
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Button �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Button = Button
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Shift �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Shift = Shift
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.X = X
				'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Y = Y
				
			End With
			
			With g_SelectArea
				
				'.X2 = (X + g_disp.X) / g_disp.Width
				'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Width �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.X2 = X / g_disp.Width + g_disp.X
				'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Height �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Y2 = (picMain.ClientRectangle.Height - Y) / g_disp.Height + g_disp.Y
				
			End With
			
			With rectTemp
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If g_SelectArea.X1 > g_SelectArea.X2 Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.left_Renamed = g_SelectArea.X2
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.right_Renamed = g_SelectArea.X1
					
				Else
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.left_Renamed = g_SelectArea.X1
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.X2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.right_Renamed = g_SelectArea.X2
					
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If g_SelectArea.Y1 > g_SelectArea.Y2 Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Top = g_SelectArea.Y2
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bottom = g_SelectArea.Y1
					
				Else
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Top = g_SelectArea.Y1
					'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.Y2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bottom = g_SelectArea.Y2
					
				End If
				
			End With
			
			ReDim blnSelect(UBound(g_VGrid))
			
			For i = 0 To UBound(g_VGrid)
				
				With g_VGrid(i)
					
					blnSelect(i) = False
					
					'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(i).blnVisible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .blnVisible Then
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(i).intCh �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If .intCh Then
							
							'If (.lngLeft + .intWidth >= g_SelectArea.X1 And .lngLeft <= g_SelectArea.X2) Or (.lngLeft <= g_SelectArea.X1 And .lngLeft + .intWidth >= g_SelectArea.X2) Then
							'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(i).lngLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g g_VGrid(i).intWidth �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If .lngLeft + .intWidth > rectTemp.left_Renamed And .lngLeft < rectTemp.right_Renamed Then
								
								blnSelect(i) = True
								
							End If
							
						End If
						
					End If
					
				End With
				
			Next i
			
			For i = 0 To UBound(g_Obj) - 1
				
				With g_Obj(i)
					
					'If g_VGrid(g_intVGridNum(.intCh)).blnSelect Then
					If blnSelect(g_intVGridNum(.intCh)) Then
						
						'UPGRADE_WARNING: �I�u�W�F�N�g g_Measure().lngY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						lngTemp = g_Measure(.intMeasure).lngY + .lngPosition
						
						'If (lngTemp >= g_SelectArea.Y1 And lngTemp <= g_SelectArea.Y2 + OBJ_HEIGHT / g_disp.Height) Or (lngTemp <= g_SelectArea.Y1 And lngTemp >= g_SelectArea.Y2 - OBJ_HEIGHT / g_disp.Height) Then
						'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Height �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If lngTemp + OBJ_HEIGHT / g_disp.Height >= rectTemp.Top And lngTemp <= rectTemp.Bottom Then
							
							'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intSelect = modMain.OBJ_SELECT.SELECTAREA_IN
								
							Else
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intSelect = modMain.OBJ_SELECT.SELECTAREA_SELECTED
								
							End If
							
						Else
							
							'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intSelect = modMain.OBJ_SELECT.NON_SELECT
								
							Else
								
								'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT
								
							End If
							
						End If
						
					Else
						
						'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then
							
							'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.intSelect = modMain.OBJ_SELECT.NON_SELECT
							
						Else
							
							'UPGRADE_WARNING: �I�u�W�F�N�g modMain.OBJ_SELECT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT
							
						End If
						
					End If
					
				End With
				
			Next i
			
			Call modDraw.DrawSelectArea()
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intEffect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If g_disp.intEffect Then Call modEasterEgg.DrawEffect()
			
		End If
		
		'�c�[���`�b�v�\��
		If g_Obj(UBound(g_Obj)).lngHeight <> UBound(g_Obj) Then
			
			With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
				
				Select Case .intCh
					
					Case Is > 100, 11 To 29 'BGM�E�L�[��
						
						strTemp = "#WAV" & strFromNum(.sngValue) & ":"
						
						If Len(g_strWAV(.sngValue)) Then
							strTemp = strTemp & g_strWAV(.sngValue)
						Else
							strTemp = strTemp & "<empty>"
						End If
						
					Case 4, 6, 7 'BGA LAYER POOR
						
						If Len(g_strBGA(.sngValue)) Then 'BGA �����
							
							strTemp = g_strBMP(strToNum(VB.Left(g_strBGA(.sngValue), 2)))
							
							If Len(strTemp) Then
								strTemp = VB.Left(g_strBGA(.sngValue), 2) & "(" & strTemp & ")" & Mid(g_strBGA(.sngValue), 3)
							Else
								strTemp = g_strBGA(.sngValue)
							End If
							
							strTemp = "#BGA" & strFromNum(.sngValue) & ":" & strTemp
							
						Else
							
							strTemp = "#BMP" & strFromNum(.sngValue) & ":"
							
							If Len(g_strBMP(.sngValue)) Then
								strTemp = strTemp & g_strBMP(.sngValue)
							Else
								strTemp = strTemp & "<empty>"
							End If
							
						End If
						
					Case 3, 8 'BPM
						
						strTemp = "BPM:" & .sngValue
						
					Case 9 'STOP
						
						strTemp = "STOP:" & .sngValue
						
					Case Else
						
						strTemp = CStr(.sngValue)
						
				End Select
				
			End With
			
			'�󂩂ǂ���
			ToolTip1.SetToolTip(picMain, strTemp)
			
		Else
			
			ToolTip1.SetToolTip(picMain, "")
			
		End If
		
		With g_Mouse
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Button �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Button = Button
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Shift �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Shift = Shift
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.X = X
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Not blnYAxisFixed Then .Y = Y
			
		End With
		
		m_intScrollDir = 0
		
		If X < 0 Then
			
			m_intScrollDir = 20
			
		ElseIf X > picMain.ClientRectangle.Width Then 
			
			m_intScrollDir = 10
			
		End If
		
		If Not blnYAxisFixed Then
			
			If Y < 0 Then
				
				m_intScrollDir = m_intScrollDir + 1
				
			ElseIf Y > picMain.ClientRectangle.Height Then 
				
				m_intScrollDir = m_intScrollDir + 2
				
			End If
			
		End If
		
		If m_intScrollDir Then
			
			tmrMain.Enabled = True
			
		Else
			
			tmrMain.Enabled = False
			
		End If
		
		Exit Sub
		
Err_Renamed: 
		'UPGRADE_WARNING: �I�u�W�F�N�g modMain.CleanUp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseMove")
	End Sub
	
	'UPGRADE_ISSUE: VBRUN.DataObject �^ �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	'UPGRADE_ISSUE: PictureBox �C�x���g picMain.OLEDragDrop �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' ���N���b�N���Ă��������B
	Private Sub picMain_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		
		Call FormDragDrop(Data)
		
	End Sub
	
	Private Sub staMain_PanelDblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _staMain_Panel1.DoubleClick, _staMain_Panel2.DoubleClick, _staMain_Panel3.DoubleClick, _staMain_Panel4.DoubleClick, _staMain_Panel5.DoubleClick, _staMain_Panel6.DoubleClick
		Dim Panel As System.Windows.Forms.ToolStripStatusLabel = CType(eventSender, System.Windows.Forms.ToolStripStatusLabel)
		
		'UPGRADE_ISSUE: MSComctlLib.Panel �v���p�e�B Panel.Key �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		If Panel.Key = "Mode" Then
			
			If tlbMenu.Items.Item("Edit").Checked = True Then
				
				Call mnuEditMode_Click(mnuEditMode.Item(1), New System.EventArgs())
				
			ElseIf tlbMenu.Items.Item("Write").Checked = True Then 
				
				Call mnuEditMode_Click(mnuEditMode.Item(2), New System.EventArgs())
				
			ElseIf tlbMenu.Items.Item("Delete").Checked = True Then 
				
				Call mnuEditMode_Click(mnuEditMode.Item(0), New System.EventArgs())
				
			End If
			
		End If
		
	End Sub
	
	Private Sub tlbMenu_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tlbMenu_Button1.Click, _tlbMenu_Button2.Click, _tlbMenu_Button3.Click, _tlbMenu_Button4.Click, _tlbMenu_Button5.Click, _tlbMenu_Button6.Click, _tlbMenu_Button7.Click, _tlbMenu_Button8.Click, _tlbMenu_Button9.Click, _tlbMenu_Button10.Click, _tlbMenu_Button11.Click, _tlbMenu_Button12.Click, _tlbMenu_Button13.Click, _tlbMenu_Button14.Click, _tlbMenu_Button15.Click, _tlbMenu_Button16.Click, _tlbMenu_Button17.Click, _tlbMenu_Button18.Click, _tlbMenu_Button19.Click, _tlbMenu_Button20.Click
		Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
		On Error GoTo Err_Renamed
		
		Select Case Button.Name
			
			Case "New" '�V�K�쐬
				
				Call mnuFileNew_Click(mnuFileNew, New System.EventArgs())
				
			Case "Open" '�J��
				
				Call mnuFileOpen_Click(mnuFileOpen, New System.EventArgs())
				
			Case "Reload" '�ēǂݍ���
				
				Call mnuRecentFiles_Click(mnuRecentFiles.Item(0), New System.EventArgs())
				
			Case "Save" '�㏑���ۑ�
				
				Call mnuFileSave_Click(mnuFileSave, New System.EventArgs())
				
			Case "SaveAs" '���O��t���ĕۑ�
				
				Call mnuFileSaveAs_Click(mnuFileSaveAs, New System.EventArgs())
				
			Case "Edit"
				
				Call mnuEditMode_Click(mnuEditMode.Item(0), New System.EventArgs())
				
			Case "Write"
				
				Call mnuEditMode_Click(mnuEditMode.Item(1), New System.EventArgs())
				
			Case "Delete"
				
				Call mnuEditMode_Click(mnuEditMode.Item(2), New System.EventArgs())
				
			Case "PlayAll"
				
				Call mnuToolsPlayAll_Click(mnuToolsPlayAll, New System.EventArgs())
				
			Case "Play"
				
				Call mnuToolsPlay_Click(mnuToolsPlay, New System.EventArgs())
				
			Case "Stop"
				
				Call mnuToolsPlayStop_Click(mnuToolsPlayStop, New System.EventArgs())
				
		End Select
		
Err_Renamed: 
	End Sub
	
	Private Sub tlbMenu_ButtonMenuClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tlbMenu.ButtonMenuClick
		Dim ButtonMenu As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripMenuItem)
		
		'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B ButtonMenu.Parent �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		If ButtonMenu.Parent.Text = tlbMenu.Items.Item("Open").Text Then
			
			'UPGRADE_ISSUE: MSComctlLib.ButtonMenu �v���p�e�B ButtonMenu.Index �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
			Call mnuRecentFiles_Click(mnuRecentFiles.Item(ButtonMenu.Index - 1), New System.EventArgs())
			
		End If
		
	End Sub
	
	'UPGRADE_ISSUE: MSComctlLib.Toolbar �C�x���g tlbMenu.Change �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' ���N���b�N���Ă��������B
	Private Sub tlbMenu_Change()
		
		Call frmMain_Resize(Me, New System.EventArgs())
		
	End Sub
	
	Private Sub tmrMain_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMain.Tick
		
		With hsbMain
			
			Select Case m_intScrollDir \ 10
				
				Case 1
					
					If .Value + .SmallChange < (.Maximum - .LargeChange + 1) Then
						
						.Value = .Value + .SmallChange
						
					Else
						
						.Value = (.Maximum - .LargeChange + 1)
						
						m_intScrollDir = m_intScrollDir - 10
						
					End If
					
				Case 2
					
					If .Value - .SmallChange > .Minimum Then
						
						.Value = .Value - .SmallChange
						
					Else
						
						.Value = .Minimum
						
						m_intScrollDir = m_intScrollDir - 20
						
					End If
					
			End Select
			
		End With
		
		With vsbMain
			
			Select Case m_intScrollDir Mod 10
				
				Case 1
					
					If .Value + .SmallChange < .Minimum Then
						
						.Value = .Value + .SmallChange
						
					Else
						
						.Value = .Minimum
						
						m_intScrollDir = m_intScrollDir - 1
						
					End If
					
				Case 2
					
					If .Value - .SmallChange > (.Maximum - .LargeChange + 1) Then
						
						.Value = .Value - .SmallChange
						
					Else
						
						.Value = (.Maximum - .LargeChange + 1)
						
						m_intScrollDir = m_intScrollDir - 2
						
					End If
					
			End Select
			
		End With
		
		If m_intScrollDir Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.X �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_Mouse.Shift �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call picMain_MouseMove(picMain, New System.Windows.Forms.MouseEventArgs(VB6.MouseButtonConstants.LeftButton * &H100000, 0, g_Mouse.X, g_Mouse.Y, 0))
			'Call MoveObj(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)
			
		End If
		
	End Sub
	
	Public Sub tmrEffect_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrEffect.Tick
		
		'UPGRADE_ISSUE: PictureBox ���\�b�h picMain.Cls �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		Call picMain.Cls()
		
		If g_Obj(UBound(g_Obj)).intCh Then
			
			Call modDraw.InitPen()
			Call modDraw.DrawObj(g_Obj(UBound(g_Obj)))
			Call modDraw.DeletePen()
			
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intEffect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Select Case g_disp.intEffect
			
			Case modEasterEgg.EASTEREGG.RASTER, modEasterEgg.EASTEREGG.NOISE, modEasterEgg.EASTEREGG.STORM
				
				'Call modEasterEgg.RasterScroll
				'Call modEasterEgg.DrawRaster
				
			Case modEasterEgg.EASTEREGG.SNOW, modEasterEgg.EASTEREGG.SIROMARU
				
				Call modEasterEgg.FallingSnow()
				
			Case modEasterEgg.EASTEREGG.SIROMARU2
				
				Call modEasterEgg.ZoomSiromaru2()
				
			Case modEasterEgg.EASTEREGG.STAFFROLL, modEasterEgg.EASTEREGG.STAFFROLL2
				
				Call modEasterEgg.StaffRollScroll()
				'Call modEasterEgg.DrawStaffRoll
				
		End Select
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_SelectArea.blnFlag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If g_SelectArea.blnFlag Then Call modDraw.DrawSelectArea()
		
		'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intEffect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If g_disp.intEffect Then Call modEasterEgg.DrawEffect()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtArtist.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtArtist_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtArtist.TextChanged
		
		Call SaveChanges()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtBPM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtBPM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBPM.TextChanged
		
		Call SaveChanges()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtExInfo.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtExInfo_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtExInfo.TextChanged
		
		Call SaveChanges()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtGenre.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtGenre_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGenre.TextChanged
		
		Call SaveChanges()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtMissBMP.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtMissBMP_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMissBMP.TextChanged
		
		Call SaveChanges()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtStageFile.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtStageFile_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtStageFile.TextChanged
		
		Call SaveChanges()
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtTitle.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtTitle_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTitle.TextChanged
		
		Call SaveChanges()
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtTotal.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtTotal_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTotal.TextChanged
		
		Call SaveChanges()
		
	End Sub
	
	Private Sub txtTotal_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtTotal.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim lngSet_ini As Object
		
		If KeyCode = System.Windows.Forms.Keys.Return Then
			
			If txtTotal.Text = "10572" Then Call lngSet_ini("EasterEgg", "Tips", 1)
			
		End If
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g txtVolume.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txtVolume_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtVolume.TextChanged
		
		Call SaveChanges()
		
	End Sub
	
	'UPGRADE_NOTE: vsbMain.Change �̓C�x���g����v���V�[�W���ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' ���N���b�N���Ă��������B
	'UPGRADE_WARNING: VScrollBar �C�x���g vsbMain.Change �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub vsbMain_Change(ByVal newScrollValue As Integer)
		On Error Resume Next
		
		With g_disp
			
			'.Y = CLng(vsbMain.Value) * 96
			'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.Y �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g g_disp.intResolution �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Y = CInt(newScrollValue) * .intResolution
			
		End With
		
		Call modDraw.Redraw()
		
		'Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)
		'�X�N���[�����I�u�W�F�ړ������̂���
		
	End Sub
	
	'UPGRADE_NOTE: vsbMain.Scroll �̓C�x���g����v���V�[�W���ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' ���N���b�N���Ă��������B
	Private Sub vsbMain_Scroll_Renamed(ByVal newScrollValue As Integer)
		
		Call vsbMain_Change(0)
		
	End Sub
	Private Sub hsbMain_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles hsbMain.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.ThumbTrack
				hsbMain_Scroll_Renamed(eventArgs.newValue)
			Case System.Windows.Forms.ScrollEventType.EndScroll
				hsbMain_Change(eventArgs.newValue)
		End Select
	End Sub
	Private Sub vsbMain_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles vsbMain.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.ThumbTrack
				vsbMain_Scroll_Renamed(eventArgs.newValue)
			Case System.Windows.Forms.ScrollEventType.EndScroll
				vsbMain_Change(eventArgs.newValue)
		End Select
	End Sub
End Class
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
			
			'グリッドにあわせる
            If VB6.GetItemData(Me.cboDispGridSub, Me.cboDispGridSub.SelectedIndex) Then
                lngTemp = 192 \ (VB6.GetItemData(Me.cboDispGridSub, Me.cboDispGridSub.SelectedIndex))
                .lngPosition = (.lngPosition \ lngTemp) * lngTemp

                'If Not Shift And vbShiftMask Then

                If Me._mnuOptionsItem_5.Checked Then

                    With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                        lngTemp = .lngPosition - (.lngPosition \ lngTemp) * lngTemp

                    End With

                    .lngPosition = .lngPosition - lngTemp

                End If

                'End If

            End If
			
			'End If
			
			'UPGRADE_WARNING: オブジェクト g_Measure().lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.lngPosition = .lngPosition + g_Measure(.intMeasure).lngY
			
		End With
		
		'UPGRADE_WARNING: オブジェクト oldObj の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		oldObj = g_Obj(g_Obj(UBound(g_Obj)).lngHeight)
		
		With oldObj
			
			.intCh = g_intVGridNum(.intCh)
			
			'If Not Shift And vbAltMask Then
			
			If VB6.GetItemData(Me.cboDispGridSub, Me.cboDispGridSub.SelectedIndex) Then
				
				lngTemp = 192 \ VB6.GetItemData(Me.cboDispGridSub, Me.cboDispGridSub.SelectedIndex)
				.lngPosition = (.lngPosition \ lngTemp) * lngTemp
				
			End If
			
			'End If
			
			'UPGRADE_WARNING: オブジェクト g_Measure().lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.lngPosition = .lngPosition + g_Measure(.intMeasure).lngY
			
		End With
		
		'Y 軸固定移動
		If Shift And VB6.ShiftConstants.ShiftMask Then
			
			newObj.lngPosition = oldObj.lngPosition
			
		End If
		
		'移動している？
		If newObj.intCh <> oldObj.intCh Or newObj.lngPosition <> oldObj.lngPosition Then
			
			'右に移動
			If newObj.intCh > oldObj.intCh Then
				
				For j = oldObj.intCh To newObj.intCh - 1
					
					'UPGRADE_WARNING: オブジェクト g_VGrid(j).intCh の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト g_VGrid(j).blnDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_VGrid(j).blnDraw = True And g_VGrid(j).intCh <> 0 Then
						
						newObj.intAtt = newObj.intAtt + 1
						
					End If
					
				Next j
				
			ElseIf newObj.intCh < oldObj.intCh Then  '左に移動
				
				For j = oldObj.intCh To newObj.intCh + 1 Step -1
					
					'UPGRADE_WARNING: オブジェクト g_VGrid(j).intCh の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト g_VGrid(j).blnVisible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_VGrid(j).blnVisible = True And g_VGrid(j).intCh <> 0 Then
						
						newObj.intAtt = newObj.intAtt + 1
						
					End If
					
				Next j
				
			End If
			
			lngTemp = newObj.intCh <> oldObj.intCh And newObj.intCh <> 0 And oldObj.intCh <> 0 And newObj.intCh <> UBound(g_VGrid) And oldObj.intCh <> UBound(g_VGrid)
			
			For i = 0 To UBound(g_Obj) - 1
				
				With g_Obj(i)
					
					'選択中
					'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .intSelect = modMain.OBJ_SELECT.Selected Then
						
						'Y 軸移動
						.lngPosition = .lngPosition + newObj.lngPosition - oldObj.lngPosition
						
						'小節はまたいでいないか？
						'UPGRADE_WARNING: オブジェクト g_Measure(g_Obj(i).intMeasure).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Do While .lngPosition >= g_Measure(.intMeasure).intLen
							
							If .intMeasure < 999 Then
								
								'UPGRADE_WARNING: オブジェクト g_Measure(g_Obj(i).intMeasure).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.lngPosition = .lngPosition - g_Measure(.intMeasure).intLen
								.intMeasure = .intMeasure + 1
								
							Else
								
								.intMeasure = 999
								
								Exit Do
								
							End If
							
						Loop 
						
						'逆に小節を切っていないか？
						Do While .lngPosition < 0
							
							If .intMeasure > 0 Then
								
								'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.lngPosition = g_Measure(.intMeasure - 1).intLen + .lngPosition
								.intMeasure = .intMeasure - 1
								
							Else
								
								.intMeasure = 0
								
								Exit Do
								
							End If
							
						Loop 
						
						'移動しているが、位置は右端でも左端でもない
						If lngTemp Then
							
							If .intCh < 0 Then
								
								j = .intCh
								
							ElseIf .intCh > 1000 Then 
								
								j = .intCh - 1000
								
							Else
								
								j = g_intVGridNum(.intCh)
								
							End If
							
							If newObj.intCh > oldObj.intCh Then '右に移動
								
								'移動量分ループ
								For k = 1 To newObj.intAtt
									
									'表示されているレーンをチェック
									Do 
										
										j = j + 1
										
										If j < 0 Or j > UBound(g_VGrid) Then Exit Do
										
										'UPGRADE_WARNING: オブジェクト g_VGrid(j).intCh の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										'UPGRADE_WARNING: オブジェクト g_VGrid(j).blnVisible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										If g_VGrid(j).blnVisible = True And g_VGrid(j).intCh <> 0 Then
											
											Exit Do
											
										End If
										
									Loop 
									
								Next k
								
							Else '左に移動
								
								For k = 1 To newObj.intAtt
									
									Do 
										
										j = j - 1
										
										If j < 0 Or j > UBound(g_VGrid) Then Exit Do
										
										'UPGRADE_WARNING: オブジェクト g_VGrid(j).intCh の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										'UPGRADE_WARNING: オブジェクト g_VGrid(j).blnVisible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										If g_VGrid(j).blnVisible = True And g_VGrid(j).intCh <> 0 Then
											
											Exit Do
											
										End If
										
									Loop 
									
								Next k
								
							End If
							
							'0未満の時は仮位置としてマイナスをあてる
							If j < 0 Then
								
								.intCh = j
								
							ElseIf j > UBound(g_VGrid) Then  '最大値以上なら仮位置として1000以上をあてる
								
								.intCh = 1000 + j
								
							Else 'それ以外なら普通に設定
								
								'UPGRADE_WARNING: オブジェクト g_VGrid().intCh の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.intCh = g_VGrid(j).intCh
								
							End If
							
							'チャンネルによって特殊な操作が必要？
							Select Case .intCh
								
								Case 8
									
									'何もしない
									
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
		'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call modMain.CleanUp(Err.Number, Err.Description, "MoveObj")
	End Sub
	
	Public Sub PreviewBMP(ByRef strFileName As String)
        On Error GoTo Err_Renamed

        If m_blnPreview = False Then Exit Sub
		
		With frmWindowPreview
			
			If .chkLock.CheckState Then Exit Sub

            ._txtBGAPara_0.Text = strFromLong(lstBMP.SelectedIndex + 1)
            .Text = ._txtBGAPara_0.Text & ":" & strFileName

            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Mid(strFileName, 2, 2) <> ":\" Then strFileName = g_BMS.strDir & strFileName
			
			'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Len(strFileName) <> 0 And strFileName <> g_BMS.strDir And Dir(strFileName, FileAttribute.Normal) <> vbNullString Then
				
				.picBackBuffer.Image = System.Drawing.Image.FromFile(strFileName)
				
			Else
				
				.picBackBuffer.Image = Nothing
				
			End If

            If .picBackBuffer.ClientRectangle.Width <= 256 Then
                ._txtBGAPara_1.Text = CStr(0)
                ._txtBGAPara_3.Text = CStr(.picBackBuffer.ClientRectangle.Width)
                ._txtBGAPara_5.Text = CStr((256 - .picBackBuffer.ClientRectangle.Width) \ 2)
            Else
                ._txtBGAPara_1.Text = CStr((.picBackBuffer.ClientRectangle.Width - 256) \ 2)
                ._txtBGAPara_3.Text = CStr(CDbl(._txtBGAPara_1.Text) + 256)
                ._txtBGAPara_5.Text = CStr(0)
            End If

            ._txtBGAPara_2.Text = CStr(0)

            If .picBackBuffer.ClientRectangle.Height >= 256 Then
                ._txtBGAPara_4.Text = CStr(256)
            Else
                ._txtBGAPara_4.Text = CStr(.picBackBuffer.ClientRectangle.Height)
            End If

            ._txtBGAPara_6.Text = CStr(0)

            Call .Invalidate()

        End With
		
Err_Renamed: 
	End Sub
	
	Private Sub PreviewBGA(ByVal lngFileNum As Integer)
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
				
				'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Mid(strTemp, 2, 2) <> ":\" Then strTemp = g_BMS.strDir & strTemp
				
				'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
				If Dir(strTemp, FileAttribute.Normal) <> vbNullString Then
					
					.picBackBuffer.Image = System.Drawing.Image.FromFile(strTemp)
					
				Else
					
					.picBackBuffer.Image = Nothing
					
				End If
				
			Else
				
				.picBackBuffer.Image = Nothing
				
			End If
			
			If UBound(strArray) > 5 Then
                ._txtBGAPara_0.Text = strArray(0)
                ._txtBGAPara_1.Text = strArray(1)
                If CDbl(._txtBGAPara_1.Text) < 0 Then ._txtBGAPara_1.Text = CStr(0)
                ._txtBGAPara_2.Text = strArray(2)
                If CDbl(._txtBGAPara_2.Text) < 0 Then ._txtBGAPara_2.Text = CStr(0)
                ._txtBGAPara_3.Text = strArray(3)
                If CDbl(._txtBGAPara_3.Text) < 0 Then ._txtBGAPara_3.Text = CStr(0)
                ._txtBGAPara_4.Text = strArray(4)
                If CDbl(._txtBGAPara_4.Text) < 0 Then ._txtBGAPara_4.Text = CStr(0)
                ._txtBGAPara_5.Text = strArray(5)
                If CDbl(._txtBGAPara_5.Text) < 0 Then ._txtBGAPara_5.Text = CStr(0)
                ._txtBGAPara_6.Text = strArray(6)
                If CDbl(._txtBGAPara_6.Text) < 0 Then ._txtBGAPara_6.Text = CStr(0)

                .Text = strFromLong(lstBGA.SelectedIndex + 1) & ":" & strTemp
				
			End If

            Call .Invalidate()

        End With
		
Err_Renamed: 
	End Sub
	
	Private Sub PreviewWAV(ByRef strFileName As String)
		On Error GoTo Err_Renamed
		
		Dim lngError As Integer
		Dim strError As New VB6.FixedLengthString(256)
        Dim strTemp As String = ""

        If m_blnPreview = False Then Exit Sub
		
		If Mid(strFileName, 2, 2) <> ":\" Then
			
			'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
				
				strTemp = "不明なエラーです。"
				
			End If
			
			'Call modMain.DebugOutput(lngError, strTemp & Chr$(34) & strFileName & Chr$(34), "PreviewWAV", False)
			
		End If
		
		Call mciSendString("play PREVIEW notify", vbNullString, 0, Me.Handle.ToInt32)
		
Err_Renamed: 
	End Sub

    'UPGRADE_ISSUE: VBRUN.DataObject 型 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    Private Sub FormDragDrop(ByVal Data As Object)
        Dim i As Integer
        Dim strArray() As String
        Dim strTemp As String
        Dim blnReadFlag As Boolean

        'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        For i = 1 To Data.Files.Count

            'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
            'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Item はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If Dir(Data.Files.Item(i), FileAttribute.Normal) <> vbNullString Then

                'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Item はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                strTemp = Data.Files.Item(i)

                If VB.Right(UCase(strTemp), 4) = ".BMS" Or VB.Right(UCase(strTemp), 4) = ".BME" Or VB.Right(UCase(strTemp), 4) = ".BML" Or VB.Right(UCase(strTemp), 4) = ".PMS" Then

                    If modMain.intSaveCheck() Or blnReadFlag Then

                        'UPGRADE_WARNING: App プロパティ App.EXEName には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                        Call ShellExecute(0, "open", Chr(34) & g_strAppDir & My.Application.Info.AssemblyName & Chr(34), Chr(34) & strTemp & Chr(34), "", SW_SHOWNORMAL)

                    Else

                        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                        strArray = Split(strTemp, "\")
                        'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        g_BMS.strFileName = VB.Right(strTemp, Len(strArray(UBound(strArray))))
                        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        g_BMS.strDir = VB.Left(strTemp, Len(strTemp) - Len(strArray(UBound(strArray))))
                        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        dlgMainOpen.InitialDirectory = g_BMS.strDir
                        dlgMainSave.InitialDirectory = g_BMS.strDir
                        blnReadFlag = True

                        Call modInput.LoadBMS()
                        'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト modMain.RecentFilesRotation の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)

                    End If

                End If

            End If

        Next i

    End Sub

    Private Sub CopyToClipboard()

        Dim i As Integer
		Dim intTemp As Short
		Dim lngTemp As Integer
		Dim strArray() As String
		
		Call My.Computer.Clipboard.Clear()
		
		intTemp = 999
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
				
				'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If .intSelect = modMain.OBJ_SELECT.Selected Then
					
					'UPGRADE_WARNING: オブジェクト g_Measure(intTemp).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト g_Measure().lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strArray(lngTemp) = VB6.Format(.intCh, "000") & .intAtt & VB6.Format(g_Measure(.intMeasure).lngY + .lngPosition - g_Measure(intTemp).lngY, "0000000") & .sngValue
					lngTemp = lngTemp + 1
					
				End If
				
			End With
			
		Next i
		
		Call My.Computer.Clipboard.SetText("BMSE ClipBoard Object Data Format" & vbCrLf & Join(strArray, vbCrLf) & vbCrLf)
		
	End Sub
	
	Public Sub SaveChanges()
		
		'UPGRADE_WARNING: オブジェクト g_BMS.blnSaveFlag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		g_BMS.blnSaveFlag = False
		
		Me.Text = g_strAppTitle
		
		'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Len(g_BMS.strDir) Then

            If _mnuOptionsItem_1.Checked Then

                'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Me.Text = Me.Text & " - " & g_BMS.strFileName

            Else

                'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Me.Text = Me.Text & " - " & g_BMS.strDir & g_BMS.strFileName
				
			End If
			
		End If
		
		Me.Text = Me.Text & " *"
		
	End Sub
	
	Private Function strCmdDecode(ByRef strCmd As String, ByRef strFileName As String) As String
		
		Dim ret As String
		
		ret = strCmd
		
		ret = Replace(ret, "<filename>", Chr(34) & strFileName & Chr(34))
		'UPGRADE_WARNING: オブジェクト g_disp.intStartMeasure の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

    'UPGRADE_WARNING: イベント cboDispFrame.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispFrame_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispFrame.SelectedIndexChanged

        Call modDraw.InitVerticalLine()

    End Sub

    'UPGRADE_WARNING: イベント cboDispGridMain.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispGridMain_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        Call modDraw.Redraw()

    End Sub

    'UPGRADE_WARNING: イベント cboDispGridSub.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispGridSub_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        Call modDraw.Redraw()

    End Sub

    'UPGRADE_WARNING: イベント cboDispHeight.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispHeight_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim i As Integer
        Dim sngTemp As Single

        If Me.Visible = False Then Exit Sub

        If cboDispHeight.SelectedIndex = cboDispHeight.Items.Count - 1 Then

            With frmWindowInput

                'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .lblMainDisp.Text = g_Message(modMain.Message.INPUT_SIZE)
                'UPGRADE_WARNING: オブジェクト g_disp.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .txtMain.Text = VB6.Format(g_disp.Height, "#0.00")
                If .txtMain.Text = "100.00" Then .txtMain.Text = "1.00"

                Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)

                sngTemp = System.Math.Round(Val(.txtMain.Text), 2)

                If sngTemp <= 0 Then

                    'UPGRADE_WARNING: オブジェクト g_disp.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

    'UPGRADE_WARNING: イベント cboDispKey.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispKey_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispKey.SelectedIndexChanged

        Call modDraw.InitVerticalLine()

    End Sub

    'UPGRADE_WARNING: イベント cboDispSC1P.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispSC1P_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispSC1P.SelectedIndexChanged

        Call modDraw.InitVerticalLine()

    End Sub

    'UPGRADE_WARNING: イベント cboDispSC2P.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispSC2P_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispSC2P.SelectedIndexChanged

        Call modDraw.InitVerticalLine()

    End Sub

    'UPGRADE_WARNING: イベント cboDispWidth.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispWidth_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim i As Integer
        Dim sngTemp As Single

        If Me.Visible = False Then Exit Sub

        If cboDispWidth.SelectedIndex = cboDispWidth.Items.Count - 1 Then

            With frmWindowInput

                'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .lblMainDisp.Text = g_Message(modMain.Message.INPUT_SIZE)
                'UPGRADE_WARNING: オブジェクト g_disp.Width の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .txtMain.Text = VB6.Format(g_disp.Width, "#0.00")
                If .txtMain.Text = "100.00" Then .txtMain.Text = "1.00"

                Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)

                sngTemp = System.Math.Round(Val(.txtMain.Text), 2)

                If sngTemp <= 0 Then

                    'UPGRADE_WARNING: オブジェクト g_disp.Width の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

    'UPGRADE_WARNING: イベント cboPlayer.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboPlayer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPlayer.SelectedIndexChanged

        Call modDraw.InitVerticalLine()

    End Sub

    'UPGRADE_WARNING: イベント cboVScroll.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboVScroll_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
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
        On Error GoTo Err_Renamed

        Dim intTemp As Short
        Dim i As Integer

        With cboDirectInput

            If Len(.Text) Then

                intTemp = UBound(g_Obj)

                Call modInput.LoadBMSLine(.Text, True)

                For i = intTemp To UBound(g_Obj) - 1

                    With g_Obj(i)

                        'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .lngPosition = (g_Measure(.intMeasure).intLen / .lngHeight) * .lngPosition

                        Select Case .intCh

                            Case modInput.OBJ_CH.CH_BPM

                                .intCh = 8

                            Case modInput.OBJ_CH.CH_KEY_INV_MIN To modInput.OBJ_CH.CH_KEY_INV_MAX '不可視

                                .intCh = .intCh - modInput.OBJ_CH.CH_INV
                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_ATT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                .intAtt = modMain.OBJ_ATT.OBJ_INVISIBLE

                            Case modInput.OBJ_CH.CH_KEY_LN_MIN To modInput.OBJ_CH.CH_KEY_LN_MAX 'LN

                                .intCh = .intCh - modInput.OBJ_CH.CH_LN
                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_ATT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
        'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

    Private Sub cmdBmpDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBMPDelete.Click

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

    Private Sub cmdBmpLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBMPLoad.Click
        On Error GoTo Err_Renamed

        Dim strArray() As String
        'Dim strTemp     As String * 2

        'UPGRADE_WARNING: CommonDialog 変数はアップグレードされませんでした 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' をクリックしてください。
        With dlgMain

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
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

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.MSR_CHANGE) & modInput.strFromNum(i) & VB.Right("00" & Hex(g_Measure(i).intLen), 3) & VB.Right("00" & Hex(lngTemp), 3)
                    ReDim Preserve strArray(UBound(strArray) + 1)

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    g_Measure(i).intLen = lngTemp

                End If

            Next i

            .Visible = True

        End With

        For i = 0 To UBound(g_Obj) - 1

            'UPGRADE_WARNING: オブジェクト tempObj の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            tempObj = g_Obj(i)

            With tempObj

                'UPGRADE_WARNING: オブジェクト g_Measure(tempObj.intMeasure).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Do While .lngPosition >= g_Measure(.intMeasure).intLen

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                    'UPGRADE_WARNING: オブジェクト g_Obj(i) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

        'UPGRADE_WARNING: CommonDialog 変数はアップグレードされませんでした 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' をクリックしてください。
        With dlgMain

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
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

        'UPGRADE_WARNING: CommonDialog 変数はアップグレードされませんでした 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' をクリックしてください。
        With dlgMain

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
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

        'UPGRADE_WARNING: CommonDialog 変数はアップグレードされませんでした 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' をクリックしてください。
        With dlgMain

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
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

        If TypeOf ActiveControl Is System.Windows.Forms.TextBox Then

            Exit Sub

        ElseIf TypeOf ActiveControl Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), System.Windows.Forms.ComboBox).DropDownStyle = 0 Then
                Exit Sub
            End If


        End If

        'Shift が押されていたら3回繰り返すよ
        If Shift And VB6.ShiftConstants.ShiftMask Then j = 2

        For i = 0 To j

            Select Case KeyCode

                Case System.Windows.Forms.Keys.Add '+

                    If _optChangeBottom_0.Checked = True Then

                        If lstWAV.SelectedIndex <> lstWAV.Items.Count - 1 Then

                            If Shift And VB6.ShiftConstants.CtrlMask Then

                                Call cmdSoundExcDown_Click(cmdSoundExcDown, New System.EventArgs())

                            Else

                                lstWAV.SelectedIndex = lstWAV.SelectedIndex + 1

                            End If

                        End If

                    ElseIf _optChangeBottom_1.Checked = True Or _optChangeBottom_2.Checked = True Then

                        If lstBMP.SelectedIndex <> lstBMP.Items.Count - 1 Then

                            If Shift And VB6.ShiftConstants.CtrlMask Then

                                Call cmdBMPExcDown_Click(cmdBMPExcDown, New System.EventArgs())

                            Else

                                lstBMP.SelectedIndex = lstBMP.SelectedIndex + 1
                                lstBGA.SelectedIndex = lstBMP.SelectedIndex

                            End If

                        End If

                    End If

                    'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)

                Case System.Windows.Forms.Keys.Subtract '-

                    If _optChangeBottom_0.Checked = True Then

                        If lstWAV.SelectedIndex <> 0 Then

                            If Shift And VB6.ShiftConstants.CtrlMask Then

                                Call cmdSoundExcUp_Click(cmdSoundExcUp, New System.EventArgs())

                            Else

                                lstWAV.SelectedIndex = lstWAV.SelectedIndex - 1

                            End If

                        End If

                    ElseIf _optChangeBottom_1.Checked = True Or _optChangeBottom_2.Checked = True Then

                        If lstBMP.SelectedIndex <> 0 Then

                            If Shift And VB6.ShiftConstants.CtrlMask Then

                                Call cmdBMPExcUp_Click(cmdBMPExcUp, New System.EventArgs())

                            Else

                                lstBMP.SelectedIndex = lstBMP.SelectedIndex - 1
                                lstBGA.SelectedIndex = lstBGA.SelectedIndex - 1

                            End If

                        End If

                    End If

                    'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)

            End Select

        Next i

        Select Case KeyCode

            Case System.Windows.Forms.Keys.F5 'F5 リスト変更

                If _optChangeBottom_0.Checked = True Then

                    _optChangeBottom_1.Checked = True

                ElseIf _optChangeBottom_1.Checked = True Then

                    _optChangeBottom_2.Checked = True

                ElseIf _optChangeBottom_2.Checked = True Then

                    _optChangeBottom_0.Checked = True

                End If

            Case System.Windows.Forms.Keys.Multiply '* プレビュー

                If _optChangeBottom_0.Checked = True Then

                    Call lstWAV_SelectedIndexChanged(lstWAV, New System.EventArgs())

                ElseIf _optChangeBottom_1.Checked = True Then

                    If Not frmWindowPreview.Visible Then Call cmdBMPPreview_Click(cmdBMPPreview, New System.EventArgs())

                ElseIf _optChangeBottom_2.Checked = True Then

                    If Not frmWindowPreview.Visible Then Call cmdBGAPreview_Click(cmdBGAPreview, New System.EventArgs())

                End If

            Case System.Windows.Forms.Keys.Divide '/ プレビュー停止

                If _optChangeBottom_0.Checked = True Then

                    Call cmdSoundStop_Click(cmdSoundStop, New System.EventArgs())

                ElseIf _optChangeBottom_1.Checked = True Or _optChangeBottom_2.Checked = True Then

                    If frmWindowPreview.Visible = True Then

                        Call frmWindowPreview.Close()

                    End If

                End If

        End Select

        Call modEasterEgg.KeyCheck(KeyCode, Shift)

    End Sub

    Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub

    'UPGRADE_ISSUE: VBRUN.DataObject 型 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'UPGRADE_ISSUE: Form イベント Form.OLEDragDrop はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' をクリックしてください。
    Private Sub Form_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)

        Call FormDragDrop(Data)

    End Sub

    Private Sub frmMain_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        'UPGRADE_WARNING: オブジェクト modMain.intSaveCheck の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If modMain.intSaveCheck() Then

            Cancel = True

        Else

            'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call modMain.CleanUp()

        End If

        eventArgs.Cancel = Cancel
    End Sub

    'UPGRADE_WARNING: イベント frmMain.Resize は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Public Sub frmMain_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

    End Sub

    'UPGRADE_NOTE: hsbMain.Change はイベントからプロシージャに変更されました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' をクリックしてください。
    'UPGRADE_WARNING: HScrollBar イベント hsbMain.Change には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    Private Sub hsbMain_Change(ByVal newScrollValue As Integer)

        With g_disp

            'UPGRADE_WARNING: オブジェクト g_disp.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .X = newScrollValue

        End With

        Call modDraw.Redraw()

        'Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)
        'スクロール＆オブジェ移動実現のため

    End Sub

    'UPGRADE_NOTE: hsbMain.Scroll はイベントからプロシージャに変更されました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' をクリックしてください。
    Private Sub hsbMain_Scroll_Renamed(ByVal newScrollValue As Integer)

        Call hsbMain_Change(0)

    End Sub

    'UPGRADE_WARNING: イベント lstBGA.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub lstBGA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBGA.SelectedIndexChanged

        'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then

        'staMain.Panels("BMP").Text = "#BMP " & Right$("0" & Hex$(lstBGA.ListIndex + 1), 2)

        'Else

        'staMain.Panels("BMP").Text = "#BMP " & modInput.strFromNum(lstBGA.ListIndex + 1)

        'End If

        If _optChangeBottom_2.Checked Then lstBMP.SelectedIndex = lstBGA.SelectedIndex

        staMain.Items.Item("BMP").Text = "#BMP " & strFromLong(lstBGA.SelectedIndex + 1)

        txtBGAInput.Text = Mid(VB6.GetItemString(lstBGA, lstBGA.SelectedIndex), 8)

        If frmWindowPreview.Visible Then

            Call PreviewBGA(lstBGA.SelectedIndex + 1)

        End If

    End Sub

    'UPGRADE_WARNING: イベント lstBMP.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub lstBMP_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBMP.SelectedIndexChanged

        'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then

        'staMain.Panels("BMP").Text = "#BMP " & Right$("0" & Hex$(lstBMP.ListIndex + 1), 2)

        'Else

        'staMain.Panels("BMP").Text = "#BMP " & modInput.strFromNum(lstBMP.ListIndex + 1)

        'End If

        If _optChangeBottom_1.Checked Then lstBGA.SelectedIndex = lstBMP.SelectedIndex

        staMain.Items.Item("BMP").Text = "#BMP " & strFromLong(lstBMP.SelectedIndex + 1)

        If frmWindowPreview.Visible Then

            Call PreviewBMP(Mid(VB6.GetItemString(lstBMP, lstBMP.SelectedIndex), 8))

        End If

    End Sub

    Private Sub lstBMP_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBMP.DoubleClick

        Call cmdBmpLoad_Click(cmdBMPLoad, New System.EventArgs())

    End Sub

    Private Sub lstBMP_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lstBMP.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        If Button = VB6.MouseButtonConstants.RightButton Then

            Me.ContextMenuStrip = mnuContextList

        End If

    End Sub

    'UPGRADE_ISSUE: VBRUN.DataObject 型 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'UPGRADE_ISSUE: ListBox イベント lstBMP.OLEDragDrop はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' をクリックしてください。
    Private Sub lstBMP_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)

        Dim i As Integer
        Dim j As Integer
        Dim strTemp As String
        Dim strArray() As String

        With lstBMP

            j = .SelectedIndex
            .Visible = False

            'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
            'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
            For i = 1 To Data.Files.Count

                'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Item はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Data.Files.Item(i), FileAttribute.Normal) <> vbNullString Then

                    'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                    'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Item はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
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

    'UPGRADE_WARNING: イベント lstMeasureLen.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
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

    'UPGRADE_WARNING: イベント lstWAV.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
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
        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
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

            Me.ContextMenuStrip = mnuContextList

        End If

    End Sub

    'UPGRADE_ISSUE: VBRUN.DataObject 型 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'UPGRADE_ISSUE: ListBox イベント lstWAV.OLEDragDrop はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' をクリックしてください。
    Private Sub lstWAV_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim j As Integer
        Dim strTemp As String
        Dim strArray() As String

        With lstWAV

            j = .SelectedIndex
            .Visible = False

            'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
            'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
            For i = 1 To Data.Files.Count

                'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Item はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Data.Files.Item(i), FileAttribute.Normal) <> vbNullString Then

                    'UPGRADE_ISSUE: DataObject プロパティ Data.Files はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                    'UPGRADE_ISSUE: DataObjectFiles プロパティ Files.Item はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
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
        'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call modMain.CleanUp(Err.Number, Err.Description, "lstWAV_OLEDragDrop")
    End Sub

    Public Sub mnuContextDeleteMeasure_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextDeleteMeasure.Click
        Dim i As Integer
        Dim intTemp As Short
        Dim strArray() As String

        For i = 0 To 999

            'If g_Measure(i).lngY >= g_disp.Y + picMain.ScaleHeight - g_Mouse.Y - 6 Then
            'UPGRADE_WARNING: オブジェクト g_disp.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_disp.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_Measure(i).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If g_Measure(i).lngY >= g_disp.Y + (picMain.ClientRectangle.Height - g_Mouse.Y) / g_disp.Height - 1 Then

                intTemp = i - 1

                Exit For

            End If

        Next i

        ReDim strArray(0)

        'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                'UPGRADE_WARNING: オブジェクト g_Measure(i).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .intLen = g_Measure(i + 1).intLen
                VB6.SetItemString(lstMeasureLen, i, VB.Left(VB6.GetItemString(lstMeasureLen, i), 5) & Mid(VB6.GetItemString(lstMeasureLen, i + 1), 6))

            End With

        Next i

        VB6.SetItemString(lstMeasureLen, 999, "#999:4/4")
        'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
        Dim i As Integer
        Dim intTemp As Short
        Dim strArray() As String

        lstMeasureLen.Visible = False

        For i = 998 To 0 Step -1

            With g_Measure(i)

                'If .lngY < g_disp.Y + picMain.ScaleHeight - g_Mouse.Y - 6 Then
                'UPGRADE_WARNING: オブジェクト g_disp.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_disp.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_Measure(i).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If .lngY < g_disp.Y + (picMain.ClientRectangle.Height - g_Mouse.Y) / g_disp.Height - 1 Then

                    VB6.SetItemString(lstMeasureLen, i, "#" & VB6.Format(i, "000") & ":4/4")
                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .intLen = 192
                    intTemp = i

                    Exit For

                End If

                VB6.SetItemString(lstMeasureLen, i, VB.Left(VB6.GetItemString(lstMeasureLen, i), 5) & Mid(VB6.GetItemString(lstMeasureLen, i - 1), 6))
                'UPGRADE_WARNING: オブジェクト g_Measure(i).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .intLen = g_Measure(i - 1).intLen

            End With

        Next i

        ReDim strArray(0)

        'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

        If _optChangeBottom_0.Checked Then

            Call cmdSoundDelete_Click(cmdSoundDelete, New System.EventArgs())

        ElseIf _optChangeBottom_1.Checked Then

            Call cmdBmpDelete_Click(cmdBMPDelete, New System.EventArgs())

        End If

    End Sub

    Public Sub mnuContextListLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextListLoad.Click

        If _optChangeBottom_0.Checked Then

            Call cmdSoundLoad_Click(cmdSoundLoad, New System.EventArgs())

        ElseIf _optChangeBottom_1.Checked Then

            Call cmdBmpLoad_Click(cmdBMPLoad, New System.EventArgs())

        End If

    End Sub

    Public Sub mnuContextListRename_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextListRename.Click
        Dim strTemp As String

        If _optChangeBottom_0.Checked Then

            With lstWAV

                Call mciSendString("close PREVIEW", vbNullString, 0, 0)
                strTemp = Mid(VB6.GetItemString(lstWAV, .SelectedIndex), 8)

                If Len(VB6.GetItemString(lstWAV, .SelectedIndex)) > 8 Then

                    'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                    If Dir(g_BMS.strDir & strTemp, FileAttribute.Normal) <> vbNullString Then

                        With frmWindowInput

                            'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            .lblMainDisp.Text = g_Message(modMain.Message.INPUT_RENAME)
                            .txtMain.Text = strTemp

                            Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)

                        End With

                        If strTemp <> frmWindowInput.txtMain.Text And Len(frmWindowInput.txtMain.Text) <> 0 Then

                            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                            If Dir(g_BMS.strDir & frmWindowInput.txtMain.Text, FileAttribute.Normal) = vbNullString Then

                                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                Rename(g_BMS.strDir & strTemp, g_BMS.strDir & frmWindowInput.txtMain.Text)

                                VB6.SetItemString(lstWAV, .SelectedIndex, VB.Left(VB6.GetItemString(lstWAV, .SelectedIndex), 7) & frmWindowInput.txtMain.Text)
                                g_strWAV(lngFromLong(.SelectedIndex + 1)) = frmWindowInput.txtMain.Text

                            Else

                                Call MsgBox(g_Message(modMain.Message.ERR_FILE_ALREADY_EXIST), MsgBoxStyle.Critical, g_strAppTitle)

                            End If

                        End If

                    Else

                        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & g_BMS.strDir & strTemp, MsgBoxStyle.Critical, g_strAppTitle)

                    End If

                End If

            End With

        ElseIf _optChangeBottom_1.Checked Then

            With lstBMP

                strTemp = Mid(VB6.GetItemString(lstBMP, .SelectedIndex), 8)

                If Len(VB6.GetItemString(lstBMP, .SelectedIndex)) > 8 Then

                    'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                    If Dir(g_BMS.strDir & strTemp, FileAttribute.Normal) <> vbNullString Then

                        With frmWindowInput

                            'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            .lblMainDisp.Text = g_Message(modMain.Message.INPUT_RENAME)
                            .txtMain.Text = strTemp

                            Call VB6.ShowForm(frmWindowInput, VB6.FormShowConstants.Modal, Me)

                        End With

                        If strTemp <> frmWindowInput.txtMain.Text And Len(frmWindowInput.txtMain.Text) <> 0 Then

                            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                            If Dir(g_BMS.strDir & frmWindowInput.txtMain.Text, FileAttribute.Normal) = vbNullString Then

                                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                Rename(g_BMS.strDir & strTemp, g_BMS.strDir & frmWindowInput.txtMain.Text)

                                VB6.SetItemString(lstBMP, .SelectedIndex, VB.Left(VB6.GetItemString(lstBMP, .SelectedIndex), 7) & frmWindowInput.txtMain.Text)
                                g_strBMP(lngFromLong(.SelectedIndex + 1)) = frmWindowInput.txtMain.Text

                            Else

                                Call MsgBox(g_Message(modMain.Message.ERR_FILE_ALREADY_EXIST), MsgBoxStyle.Critical, g_strAppTitle)

                            End If

                        End If

                    Else

                        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & g_BMS.strDir & strTemp, MsgBoxStyle.Critical, g_strAppTitle)

                    End If

                End If

            End With

        End If

    End Sub

    Public Sub mnuContextPlay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextPlay.Click

        Dim lngTemp As Short

        'UPGRADE_WARNING: オブジェクト g_disp.intStartMeasure の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        lngTemp = g_disp.intStartMeasure
        'UPGRADE_WARNING: オブジェクト g_disp.intStartMeasure の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト g_Mouse.measure の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        g_disp.intStartMeasure = g_Mouse.measure

        Call mnuToolsPlay_Click(mnuToolsPlay, New System.EventArgs())

        'UPGRADE_WARNING: オブジェクト g_disp.intStartMeasure の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

        'テキストボックスやコンボボックスがアクティブの場合は
        'そっちに Redo のメッセージを送信して脱出する
        If TypeOf ActiveControl() Is System.Windows.Forms.TextBox Then

            'UPGRADE_ISSUE: Control hwnd は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call SendMessage(ActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), System.Windows.Forms.ComboBox).DropDownStyle = 0 Then

                'UPGRADE_ISSUE: Control hwnd は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Call SendMessage(ActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)

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
                    'UPGRADE_WARNING: オブジェクト g_Obj(UBound() - 1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    g_Obj(UBound(g_Obj) - 1) = modLog.decAdd(strArray(i), UBound(g_Obj) - 1)
                    'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .intSelect = modMain.OBJ_SELECT.Selected

                    End With

                Case modMain.CMD_LOG.MSR_ADD

                    lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '

                    For j = 999 To lngTemp + 1 Step -1

                        'UPGRADE_WARNING: オブジェクト g_Measure(j).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        g_Measure(j).intLen = g_Measure(j - 1).intLen
                        VB6.SetItemString(lstMeasureLen, j, VB.Left(VB6.GetItemString(lstMeasureLen, j), 5) & Mid(VB6.GetItemString(lstMeasureLen, j - 1), 6))

                    Next j

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                        'UPGRADE_WARNING: オブジェクト g_Measure(j).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        g_Measure(j).intLen = g_Measure(j + 1).intLen
                        VB6.SetItemString(lstMeasureLen, j, VB.Left(VB6.GetItemString(lstMeasureLen, j), 5) & Mid(VB6.GetItemString(lstMeasureLen, j + 1), 6))

                    Next j

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                    'UPGRADE_WARNING: オブジェクト g_Measure(lngTemp).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 8, 3)) '

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
                    If intTemp <= 2 Then intTemp = 3
                    If intTemp >= 48 Then intTemp = 48
                    'UPGRADE_WARNING: オブジェクト g_Measure(lngTemp).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

        'テキストボックスやコンボボックスがアクティブの場合は
        'そっちに Undo のメッセージを送信して脱出する
        If TypeOf ActiveControl() Is System.Windows.Forms.TextBox Then

            'UPGRADE_ISSUE: Control hwnd は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call SendMessage(ActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), ComboBox).DropDownStyle = 0 Then

                'UPGRADE_ISSUE: Control hwnd は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Call SendMessage(ActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)

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
                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .intSelect = modMain.OBJ_SELECT.Selected

                    End With

                Case modMain.CMD_LOG.OBJ_MOVE

                    With g_Obj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))) '

                        .intCh = Val("&H" & Mid(strArray(i), 7, 2)) '
                        .intMeasure = modInput.strToNum(Mid(strArray(i), 9, 2)) '
                        .lngPosition = modInput.strToNum(Mid(strArray(i), 11, 3)) '
                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .intSelect = modMain.OBJ_SELECT.Selected

                    End With

                Case modMain.CMD_LOG.OBJ_CHANGE

                    With g_Obj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))) '

                        .sngValue = modInput.strToNum(Mid(strArray(i), 7, 2)) '
                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .intSelect = modMain.OBJ_SELECT.Selected

                    End With

                Case modMain.CMD_LOG.MSR_ADD

                    lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '

                    For j = lngTemp To 998

                        'UPGRADE_WARNING: オブジェクト g_Measure(j).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        g_Measure(j).intLen = g_Measure(j + 1).intLen
                        VB6.SetItemString(lstMeasureLen, j, VB.Left(VB6.GetItemString(lstMeasureLen, j), 5) & Mid(VB6.GetItemString(lstMeasureLen, j + 1), 6))

                    Next j

                    'UPGRADE_WARNING: オブジェクト g_Measure(999).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    g_Measure(999).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intTemp = intGCD(g_Measure(999).intLen, 192)
                    If intTemp <= 2 Then intTemp = 3
                    If intTemp >= 48 Then intTemp = 48
                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                        'UPGRADE_WARNING: オブジェクト g_Measure(j).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        g_Measure(j).intLen = g_Measure(j - 1).intLen
                        VB6.SetItemString(lstMeasureLen, j, VB.Left(VB6.GetItemString(lstMeasureLen, j), 5) & Mid(VB6.GetItemString(lstMeasureLen, j - 1), 6))

                    Next j

                    'UPGRADE_WARNING: オブジェクト g_Measure(lngTemp).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
                    If intTemp <= 2 Then intTemp = 3
                    If intTemp >= 48 Then intTemp = 48
                    'UPGRADE_WARNING: オブジェクト g_Measure(lngTemp).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                    'UPGRADE_WARNING: オブジェクト g_Measure(lngTemp).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '

                    'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
                    If intTemp <= 2 Then intTemp = 3
                    If intTemp >= 48 Then intTemp = 48
                    'UPGRADE_WARNING: オブジェクト g_Measure(lngTemp).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                        intTemp = modInput.strToNum(Mid(strArray(i), j + 1, 2)) '古い値
                        lngTemp = modInput.strToNum(Mid(strArray(i), j + 3, 2)) '新しい値

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

        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Len(g_BMS.strDir) Then

            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If Len(g_strFiler) <> 0 And Dir(g_strFiler) <> vbNullString Then '指定したファイラを使用

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call ShellExecute(Me.Handle.ToInt32, "open", Chr(34) & g_strFiler & Chr(34), Chr(34) & g_BMS.strDir & Chr(34), "", SW_SHOWNORMAL)

            Else 'Explorer で開く

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

    Public Sub mnuOptionsItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _mnuOptionsItem_7.Click, _mnuOptionsItem_6.Click, _mnuOptionsItem_5.Click, _mnuOptionsItem_4.Click, _mnuOptionsItem_3.Click, _mnuOptionsItem_2.Click, _mnuOptionsItem_1.Click, _mnuOptionsItem_0.Click
        Select Case DirectCast(eventSender, ToolStripMenuItem).Name
            Case _mnuOptionsItem_0.Name
                _mnuOptionsItem_0.Checked = Not _mnuOptionsItem_0.Checked

            Case _mnuOptionsItem_1.Name
                _mnuOptionsItem_1.Checked = Not _mnuOptionsItem_1.Checked
                Me.Text = g_strAppTitle

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Len(g_BMS.strDir) Then

                    If _mnuOptionsItem_1.Checked Then

                        'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Me.Text = Me.Text & " - " & g_BMS.strFileName

                    Else

                        'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Me.Text = Me.Text & " - " & g_BMS.strDir & g_BMS.strFileName

                    End If

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.blnSaveFlag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not g_BMS.blnSaveFlag Then Me.Text = Me.Text & " *"

            Case _mnuOptionsItem_2.Name
                _mnuOptionsItem_2.Checked = Not _mnuOptionsItem_2.Checked
                Call modDraw.Redraw()

            Case _mnuOptionsItem_3.Name
                _mnuOptionsItem_3.Checked = Not _mnuOptionsItem_3.Checked
                Call modDraw.Redraw()

            Case _mnuOptionsItem_4.Name
                _mnuOptionsItem_4.Checked = Not _mnuOptionsItem_4.Checked

            Case _mnuOptionsItem_5.Name
                _mnuOptionsItem_5.Checked = Not _mnuOptionsItem_5.Checked

            Case _mnuOptionsItem_6.Name
                _mnuOptionsItem_6.Checked = Not _mnuOptionsItem_6.Checked
                Call modDraw.Redraw()

            Case _mnuOptionsItem_7.Name
                _mnuOptionsItem_7.Checked = Not _mnuOptionsItem_7.Checked
                m_blnPreview = False
                lstWAV.SelectedIndex = 0
                lstBMP.SelectedIndex = 0
                lstBGA.SelectedIndex = 0
                m_blnPreview = True

                Call RefreshList()
                Call modDraw.Redraw()
        End Select
    End Sub

    Public Sub mnuTheme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _mnuTheme_2.Click, _mnuTheme_1.Click, _mnuTheme_0.Click
        _mnuTheme_0.Checked = False
        _mnuTheme_1.Checked = False
        _mnuTheme_2.Checked = False

        Select Case DirectCast(eventSender, ToolStripMenuItem).Name
            Case _mnuTheme_0.Name
                With _mnuTheme_0
                    .Checked = True
                    Call modMain.LoadThemeFile("theme\" & g_strThemeFileName(0))
                End With

            Case _mnuTheme_1.Name
                With _mnuTheme_1
                    .Checked = True
                    Call modMain.LoadThemeFile("theme\" & g_strThemeFileName(1))
                End With

            Case _mnuTheme_2.Name
                With _mnuTheme_2
                    .Checked = True
                    Call modMain.LoadThemeFile("theme\" & g_strThemeFileName(2))
                End With
        End Select

        Call Redraw()

    End Sub

    Public Sub mnuToolsSetting_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolsSetting.Click

        With frmWindowViewer

            .Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Left) + (VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
            .Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) + (VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)

            Call VB6.ShowForm(frmWindowViewer, VB6.FormShowConstants.Modal, Me)

        End With

    End Sub

    Public Sub mnuViewItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _mnuViewItem_2.Click, _mnuViewItem_1.Click, _mnuViewItem_0.Click
        Select Case DirectCast(eventSender, ToolStripMenuItem).Name
            Case _mnuViewItem_0.Name
                _mnuViewItem_0.Checked = Not _mnuViewItem_0.Checked
            Case _mnuViewItem_1.Name
                _mnuViewItem_1.Checked = Not _mnuViewItem_1.Checked
            Case _mnuViewItem_2.Name
                _mnuViewItem_2.Checked = Not _mnuViewItem_2.Checked
        End Select

        Call frmMain_Resize(Me, New System.EventArgs())

    End Sub

    Public Sub mnuEditCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditCopy.Click
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim intTemp As Short

        If TypeOf ActiveControl() Is System.Windows.Forms.TextBox Then

            Call My.Computer.Clipboard.Clear()
            Call My.Computer.Clipboard.SetText(DirectCast(ActiveControl(), TextBox).SelectedText)

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), ComboBox).DropDownStyle = 0 Then

                Call My.Computer.Clipboard.Clear()
                Call My.Computer.Clipboard.SetText(DirectCast(ActiveControl(), ComboBox).SelectedText)

                Exit Sub

            End If

        End If

        For i = 0 To UBound(g_Obj) - 1

            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If g_Obj(i).intSelect = modMain.OBJ_SELECT.Selected Then

                intTemp = 1

                Exit For

            End If

        Next i

        If intTemp = 0 Then Exit Sub

        Call CopyToClipboard()

        For i = 0 To UBound(g_Obj) - 1

            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then g_Obj(i).intSelect = modMain.OBJ_SELECT.NON_SELECT

        Next i

        Call modDraw.Redraw()

        Exit Sub

Err_Renamed:
        'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditCopy_Click")
    End Sub

    Public Sub mnuEditCut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditCut.Click
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim intTemp As Short

        If TypeOf ActiveControl() Is System.Windows.Forms.TextBox Then

            Call My.Computer.Clipboard.Clear()
            Call My.Computer.Clipboard.SetText(DirectCast(ActiveControl(), TextBox).SelectedText)
            DirectCast(ActiveControl(), TextBox).SelectedText = ""

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), ComboBox).DropDownStyle = 0 Then

                Call My.Computer.Clipboard.Clear()
                Call My.Computer.Clipboard.SetText(DirectCast(ActiveControl(), ComboBox).SelectedText)
                DirectCast(ActiveControl(), ComboBox).SelectedText = ""

                Exit Sub

            End If

        End If

        For i = 0 To UBound(g_Obj) - 1

            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
        'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditCut_Click")
    End Sub

    Public Sub mnuEditDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditDelete.Click
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim lngTemp As Integer
        Dim strArray() As String

        If TypeOf ActiveControl() Is System.Windows.Forms.TextBox Then

            If Len(DirectCast(ActiveControl(), TextBox).SelectedText) = 0 Then

                DirectCast(ActiveControl(), TextBox).SelectionLength = 1

            End If

            DirectCast(ActiveControl(), TextBox).SelectedText = ""

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), ComboBox).DropDownStyle = 0 Then

                If Len(DirectCast(ActiveControl(), ComboBox).SelectedText) = 0 Then

                    DirectCast(ActiveControl(), ComboBox).SelectionLength = 1

                End If

                DirectCast(ActiveControl(), ComboBox).SelectedText = ""

                Exit Sub

            End If

        End If

        For i = 0 To UBound(g_Obj) - 1

            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
        'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditDelete_Click")
    End Sub

    Public Sub mnuEditMode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _mnuEditMode_2.Click, _mnuEditMode_1.Click, _mnuEditMode_0.Click
        CType(tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = False
        CType(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = False
        CType(tlbMenu.Items.Item("Delete"), ToolStripButton).Checked = False


        Select Case DirectCast(eventSender, ToolStripMenuItem).Name
            Case _mnuEditMode_0.Name
                CType(tlbMenu.Items.Item(0 + 7), ToolStripButton).Checked = True
                staMain.Items.Item("Mode").Text = g_strStatusBar(20)
            Case _mnuEditMode_1.Name
                CType(tlbMenu.Items.Item(1 + 7), ToolStripButton).Checked = True
                staMain.Items.Item("Mode").Text = g_strStatusBar(21)
            Case _mnuEditMode_2.Name
                CType(tlbMenu.Items.Item(2 + 7), ToolStripButton).Checked = True
                staMain.Items.Item("Mode").Text = g_strStatusBar(22)
        End Select

    End Sub

    Public Sub mnuEditPaste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditPaste.Click
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim j As Integer
        Dim lngArg As Integer
        Dim strArray() As String

        If TypeOf ActiveControl() Is System.Windows.Forms.TextBox Then

            'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
            DirectCast(ActiveControl(), TextBox).SelectedText = My.Computer.Clipboard.GetText()

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), ComboBox).DropDownStyle = 0 Then

                'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                DirectCast(ActiveControl(), ComboBox).SelectedText = My.Computer.Clipboard.GetText()

                Exit Sub

            End If

        End If

        Call modDraw.ObjSelectCancel()

        'UPGRADE_WARNING: オブジェクト g_disp.intStartMeasure の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        For i = g_disp.intStartMeasure To 999

            'UPGRADE_WARNING: オブジェクト g_Measure(i).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_disp.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If g_disp.Y <= g_Measure(i).lngY Then

                'UPGRADE_WARNING: オブジェクト g_disp.intStartMeasure の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                'UPGRADE_WARNING: オブジェクト g_disp.intStartMeasure の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_Measure(g_disp.intStartMeasure).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .lngPosition = Val(Mid(strArray(i), 5, 7)) + g_Measure(g_disp.intStartMeasure).lngY
                .sngValue = Val(Mid(strArray(i), 12))
                .lngHeight = 0
                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .intSelect = modMain.OBJ_SELECT.Selected

                For j = 0 To 999

                    'UPGRADE_WARNING: オブジェクト g_Measure(j).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If .lngPosition < g_Measure(j).lngY Then

                        Exit For

                    Else

                        .intMeasure = j

                    End If

                Next j

                'UPGRADE_WARNING: オブジェクト g_Measure(g_Obj(UBound(g_Obj)).intMeasure).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .lngPosition = .lngPosition - g_Measure(.intMeasure).lngY

                strArray(i - 1) = modInput.strFromNum(modMain.CMD_LOG.OBJ_ADD) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue

                If modDraw.lngChangeMaxMeasure(.intMeasure) Then lngArg = 1

            End With

            'UPGRADE_WARNING: オブジェクト g_Measure(g_Obj(UBound(g_Obj)).intMeasure).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If g_Obj(UBound(g_Obj)).lngPosition < g_Measure(g_Obj(UBound(g_Obj)).intMeasure).intLen Then ReDim Preserve g_Obj(UBound(g_Obj) + 1)

        Next i

        If lngArg Then Call modDraw.ChangeResolution()

        Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))

        Call modDraw.Redraw()

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditPaste_Click")
    End Sub

    Public Sub mnuFileExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileExit.Click
        If modMain.intSaveCheck() Then Exit Sub

        Call modMain.CleanUp()

    End Sub

    Public Sub mnuHelpWeb_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpWeb.Click

        Call ShellExecute(0, vbNullString, "http://ucn.tokonats.net/", vbNullString, vbNullString, SW_SHOWNORMAL)

    End Sub

    Public Sub mnuLanguage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _mnuLanguage_2.Click, _mnuLanguage_1.Click, _mnuLanguage_0.Click

        _mnuLanguage_0.Checked = False
        _mnuLanguage_1.Checked = False
        _mnuLanguage_2.Checked = False

        Select Case DirectCast(eventSender, ToolStripMenuItem).Name
            Case _mnuLanguage_0.Name
                With _mnuLanguage_0
                    .Checked = True
                    Call modMain.LoadLanguageFile("lang\" & g_strLangFileName(0))
                End With

            Case _mnuLanguage_1.Name
                With _mnuLanguage_1
                    .Checked = True
                    Call modMain.LoadLanguageFile("lang\" & g_strLangFileName(1))
                End With

            Case _mnuLanguage_2.Name
                With _mnuLanguage_2
                    .Checked = True
                    Call modMain.LoadLanguageFile("lang\" & g_strLangFileName(2))
                End With
        End Select

        Call modDraw.Redraw()
    End Sub

    Public Sub mnuFileNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileNew.Click
        'UPGRADE_WARNING: オブジェクト modMain.intSaveCheck の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If modMain.intSaveCheck() Then Exit Sub

        Me.Text = g_strAppTitle & " - Now Initializing"

        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

        With g_BMS

            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .strDir = ""
            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .strFileName = ""

        End With

        Call modInput.LoadBMSStart()

        Call modInput.LoadBMSEnd()

    End Sub

    Public Sub mnuFileOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpen.Click
        On Error GoTo Err_Renamed

        Dim strArray() As String

        'UPGRADE_WARNING: オブジェクト modMain.intSaveCheck の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If modMain.intSaveCheck() Then Exit Sub

        'UPGRADE_WARNING: CommonDialog 変数はアップグレードされませんでした 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' をクリックしてください。
        With dlgMain

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            .Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"

            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FileName = g_BMS.strFileName

            Call .ShowDialog()

            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

            strArray = Split(.FileName, "\")
            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_BMS.strDir = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_BMS.strFileName = strArray(UBound(strArray))

            Call modInput.LoadBMS()

            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト modMain.RecentFilesRotation の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)

            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .InitialDirectory = g_BMS.strDir

        End With

Err_Renamed:
    End Sub

    Public Sub mnuToolsPlay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolsPlay.Click
        Dim strFileName As String
        Dim strPath As String

        If Mid(g_Viewer(cboViewer.SelectedIndex + 1).strAppPath, 2, 2) <> ":\" Then

            strPath = g_strAppDir & g_Viewer(cboViewer.SelectedIndex + 1).strAppPath

        Else

            strPath = g_Viewer(cboViewer.SelectedIndex + 1).strAppPath

        End If

        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If Dir(strPath, FileAttribute.Normal) = vbNullString Then

            'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
            Exit Sub

        End If

        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Len(g_BMS.strDir) Then

            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
        Dim strFileName As String
        Dim strPath As String

        If Mid(g_Viewer(cboViewer.SelectedIndex + 1).strAppPath, 2, 2) <> ":\" Then

            strPath = g_strAppDir & g_Viewer(cboViewer.SelectedIndex + 1).strAppPath

        Else

            strPath = g_Viewer(cboViewer.SelectedIndex + 1).strAppPath

        End If

        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If Dir(strPath, FileAttribute.Normal) = vbNullString Then

            'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
            Exit Sub

        End If

        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Len(g_BMS.strDir) Then

            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
        Dim strFileName As String
        Dim strPath As String

        If Mid(g_Viewer(cboViewer.SelectedIndex + 1).strAppPath, 2, 2) <> ":\" Then

            strPath = g_strAppDir & g_Viewer(cboViewer.SelectedIndex + 1).strAppPath

        Else

            strPath = g_Viewer(cboViewer.SelectedIndex + 1).strAppPath

        End If

        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If Dir(strPath, FileAttribute.Normal) = vbNullString Then

            'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
            Exit Sub

        End If

        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Len(g_BMS.strDir) Then

            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strFileName = g_BMS.strDir & "___bmse_temp.bms" & vbNullString

        Else

            strFileName = g_strAppDir & "___bmse_temp.bms" & vbNullString

        End If

        Call mciSendString("close PREVIEW", vbNullString, 0, 0)

        With g_Viewer(cboViewer.SelectedIndex + 1)

            Call ShellExecute(0, "open", Chr(34) & strPath & Chr(34), strCmdDecode(.strArgStop, strFileName), "", SW_SHOWNORMAL)

        End With

    End Sub

    Public Sub mnuRecentFiles_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _mnuRecentFiles_9.Click, _mnuRecentFiles_8.Click, _mnuRecentFiles_7.Click, _mnuRecentFiles_6.Click, _mnuRecentFiles_5.Click, _mnuRecentFiles_4.Click, _mnuRecentFiles_3.Click, _mnuRecentFiles_2.Click, _mnuRecentFiles_1.Click, _mnuRecentFiles_0.Click
        Dim strArray() As String

        If modMain.intSaveCheck() Then Exit Sub
        Select Case DirectCast(eventSender, ToolStripMenuItem).Name
            Case _mnuRecentFiles_0.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_0.Text, 4)) = vbNullString Then
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_0.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_0.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_0.Text, 4, Len(_mnuRecentFiles_0.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_1.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_1.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_1.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_1.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_1.Text, 4, Len(_mnuRecentFiles_1.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_2.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_2.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_2.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_2.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_2.Text, 4, Len(_mnuRecentFiles_2.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_3.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_3.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_3.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_3.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_3.Text, 4, Len(_mnuRecentFiles_3.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_4.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_4.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_4.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_4.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_4.Text, 4, Len(_mnuRecentFiles_4.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_5.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_5.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_5.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_5.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_5.Text, 4, Len(_mnuRecentFiles_5.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_6.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_6.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_6.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_6.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_6.Text, 4, Len(_mnuRecentFiles_6.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_7.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_7.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_7.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_7.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_7.Text, 4, Len(_mnuRecentFiles_7.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_8.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_8.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_8.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_8.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_8.Text, 4, Len(_mnuRecentFiles_8.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_9.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_9.Text, 4)) = vbNullString Then

                    'UPGRADE_WARNING: オブジェクト g_Message(ERR_LOAD_CANCEL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_9.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_9.Text, "\")
                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                g_BMS.strDir = Mid(_mnuRecentFiles_9.Text, 4, Len(_mnuRecentFiles_9.Text) - Len(strArray(UBound(strArray))) - 3)
        End Select
        'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        g_BMS.strFileName = strArray(UBound(strArray))

        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        dlgMainOpen.InitialDirectory = g_BMS.strDir
        dlgMainSave.InitialDirectory = g_BMS.strDir

        'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト modMain.RecentFilesRotation の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)

        Call modInput.LoadBMS()

    End Sub

    Public Sub mnuFileSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSave.Click

        'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If g_BMS.strDir <> "" And g_BMS.strFileName <> "" Then

            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call modOutput.CreateBMS(g_BMS.strDir & g_BMS.strFileName)

        Else

            Call mnuFileSaveAs_Click(mnuFileSaveAs, New System.EventArgs())

        End If

    End Sub

    Public Sub mnuFileSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSaveAs.Click
        On Error GoTo Err_Renamed

        Dim strArray() As String

        'UPGRADE_WARNING: CommonDialog 変数はアップグレードされませんでした 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' をクリックしてください。
        With dlgMain

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            .Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"

            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FileName = g_BMS.strFileName

            Call .ShowDialog()

            strArray = Split(.FileName, "\")
            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_BMS.strDir = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_BMS.strFileName = strArray(UBound(strArray))

            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call modOutput.CreateBMS(g_BMS.strDir & g_BMS.strFileName)

            'UPGRADE_WARNING: オブジェクト g_BMS.strFileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト modMain.RecentFilesRotation の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)

            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .InitialDirectory = g_BMS.strDir

        End With

Err_Renamed:
    End Sub

    Public Sub mnuEditSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditSelectAll.Click
        Dim i As Integer

        If TypeOf ActiveControl() Is System.Windows.Forms.TextBox Then

            DirectCast(ActiveControl(), TextBox).SelectionStart = 0
            DirectCast(ActiveControl(), TextBox).SelectionLength = Len(DirectCast(ActiveControl(), TextBox).Text)

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), ComboBox).DropDownStyle = 0 Then

                DirectCast(ActiveControl(), ComboBox).SelectionStart = 0
                DirectCast(ActiveControl(), ComboBox).SelectionLength = Len(DirectCast(ActiveControl(), ComboBox).Text)

                Exit Sub

            End If

        End If

        For i = 0 To UBound(g_Obj) - 1

            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_Obj(i).intSelect = modMain.OBJ_SELECT.Selected

        Next i

        Call modDraw.Redraw()

    End Sub

    'UPGRADE_WARNING: イベント optChangeBottom.CheckedChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub optChangeBottom_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _optChangeBottom_4.CheckedChanged, _optChangeBottom_3.CheckedChanged, _optChangeBottom_2.CheckedChanged, _optChangeBottom_1.CheckedChanged, _optChangeBottom_0.CheckedChanged
        If eventSender.Checked Then
            _fraBottom_0.Visible = False
            _fraBottom_1.Visible = False
            _fraBottom_2.Visible = False
            _fraBottom_3.Visible = False
            _fraBottom_4.Visible = False

            Select Case DirectCast(eventSender, RadioButton).Name
                Case _optChangeBottom_0.Name
                    _fraBottom_0.Visible = True
                Case _optChangeBottom_1.Name
                    _fraBottom_1.Visible = True
                Case _optChangeBottom_2.Name
                    _fraBottom_0.Visible = True
                Case _optChangeBottom_3.Name
                    _fraBottom_0.Visible = True
                Case _optChangeBottom_4.Name
                    _fraBottom_0.Visible = True
            End Select

        End If
    End Sub

    'UPGRADE_WARNING: イベント optChangeTop.CheckedChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub optChangeTop_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _optChangeTop_2.CheckedChanged, _optChangeTop_1.CheckedChanged, _optChangeTop_0.CheckedChanged
        If eventSender.Checked Then
            _fraTop_0.Visible = False
            _fraTop_1.Visible = False
            _fraTop_1.Visible = False

            Select Case DirectCast(eventSender, RadioButton).Name
                Case _optChangeTop_0.Name
                    _fraTop_0.Visible = True
                Case _optChangeTop_1.Name
                    _fraTop_1.Visible = True
                Case _optChangeTop_2.Name
                    _fraTop_2.Visible = True
            End Select

        End If
    End Sub

    'UPGRADE_ISSUE: PictureBox イベント picMain.KeyDown はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' をクリックしてください。
    Private Sub picMain_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)

        Dim lngTemp As Integer
        Dim intTemp As Short
        Dim blnTemp As Boolean

        blnTemp = True

        'UPGRADE_WARNING: オブジェクト g_Mouse.Shift の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        g_Mouse.Shift = Shift

        lngTemp = vsbMain.Value
        intTemp = hsbMain.Value

        Select Case KeyCode

            Case System.Windows.Forms.Keys.ControlKey, System.Windows.Forms.Keys.ShiftKey ', vbKeyMenu

                If tlbMenu.Items.Item("Write").Pressed = False Then blnTemp = False

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

            If Me.tlbMenu.Items.Item("Write").Pressed = False Then

                'UPGRADE_WARNING: オブジェクト g_Mouse.Button の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_SelectArea.blnFlag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If g_SelectArea.blnFlag = True Or (g_Obj(UBound(g_Obj)).intCh <> 0 And g_Mouse.Button <> 0) Then

                    'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call picMain_MouseMove(picMain, New System.Windows.Forms.MouseEventArgs(VB6.MouseButtonConstants.LeftButton * &H100000, 0, g_Mouse.X, g_Mouse.Y, 0))

                End If

            Else

                'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)

            End If

        End If

    End Sub

    'UPGRADE_ISSUE: PictureBox イベント picMain.KeyUp はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' をクリックしてください。
    Private Sub picMain_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)

        'UPGRADE_WARNING: オブジェクト g_Mouse.Shift の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        g_Mouse.Shift = Shift

        Select Case KeyCode

            Case System.Windows.Forms.Keys.ControlKey, System.Windows.Forms.Keys.ShiftKey

                If tlbMenu.Items.Item("Write").Pressed = True Then

                    'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)

                End If

        End Select

    End Sub

    Private Sub picMain_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
        On Error GoTo Err_Renamed

        Dim strTemp As String
        'Dim intNum      As Long
        Dim lngTemp As Integer
        Dim i As Integer
        Dim tempObj As g_udtObj
        Dim strArray() As String

        If g_blnIgnoreInput Then Exit Sub

        m_blnMouseDown = True

        If Button = VB6.MouseButtonConstants.LeftButton Then '左クリック

            If tlbMenu.Items.Item("Delete").Pressed = True Then

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

            ElseIf tlbMenu.Items.Item("Edit").Pressed = True Then

                If g_Obj(UBound(g_Obj)).intCh <> 0 Then 'オブジェのあるところで押したっぽいよ

                    With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                        If VB6.GetItemData(cboDispGridSub, cboDispGridSub.SelectedIndex) Then

                            lngTemp = 192 \ (VB6.GetItemData(cboDispGridSub, cboDispGridSub.SelectedIndex))
                            lngTemp = .lngPosition - (.lngPosition \ lngTemp) * lngTemp

                        End If

                    End With

                    'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then '複数選択っぽいよ

                        If Shift And VB6.ShiftConstants.CtrlMask Then

                            'UPGRADE_WARNING: オブジェクト tempObj の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            tempObj = g_Obj(UBound(g_Obj))

                            'ReDim strArray(intNum - 1)
                            ReDim strArray(0)
                            'intNum = 0

                            For i = 0 To UBound(g_Obj) - 1

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                                    With g_Obj(i)

                                        'UPGRADE_WARNING: オブジェクト g_Obj(UBound()) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        g_Obj(UBound(g_Obj)) = g_Obj(i)
                                        g_Obj(UBound(g_Obj)).lngID = g_lngIDNum

                                        strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_ADD) & modInput.strFromNum(g_lngIDNum, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
                                        'intNum = intNum + 1
                                        ReDim Preserve strArray(UBound(strArray) + 1)

                                        g_lngObjID(g_lngIDNum) = UBound(g_Obj)
                                        g_lngIDNum = g_lngIDNum + 1
                                        ReDim Preserve g_lngObjID(g_lngIDNum)

                                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        .intSelect = modMain.OBJ_SELECT.NON_SELECT

                                    End With

                                    If i = tempObj.lngHeight Then tempObj.lngHeight = UBound(g_Obj)

                                    ReDim Preserve g_Obj(UBound(g_Obj) + 1)

                                End If

                            Next i

                            If UBound(strArray) Then

                                ReDim Preserve strArray(UBound(strArray) - 1)

                                Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))

                                'UPGRADE_WARNING: オブジェクト g_Obj(UBound()) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                g_Obj(UBound(g_Obj)) = tempObj

                            End If

                        End If

                        ReDim m_tempObj(0)

                        For i = 0 To UBound(g_Obj) - 1

                            With g_Obj(i)

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                If .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                                    'UPGRADE_WARNING: オブジェクト m_tempObj(UBound()) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    m_tempObj(UBound(m_tempObj)) = g_Obj(i)

                                    .lngHeight = UBound(m_tempObj)

                                    ReDim Preserve m_tempObj(UBound(m_tempObj) + 1)

                                End If

                            End With

                        Next i

                        'UPGRADE_WARNING: オブジェクト m_tempObj(UBound()) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        m_tempObj(UBound(m_tempObj)) = g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                        With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                            'プレビュー
                            If _mnuOptionsItem_4.Checked = True And ((.intCh >= 11 And .intCh <= 29) Or .intCh > 100) Then

                                strTemp = g_strWAV(.sngValue)

                                'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                                If strTemp <> "" And Dir(g_BMS.strDir & strTemp) <> vbNullString Then

                                    Call PreviewWAV(strTemp)

                                End If

                            End If

                            'オブジェをグリッドにあわせる
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

                    Else '単数選択っぽいよ

                        If Not Shift And VB6.ShiftConstants.CtrlMask Then

                            Call modDraw.ObjSelectCancel()

                        End If

                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intSelect = modMain.OBJ_SELECT.Selected

                        Call modDraw.MoveSelectedObj()

                        With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                            ReDim m_tempObj(0)

                            For i = 0 To UBound(g_Obj) - 1

                                With g_Obj(i)

                                    'UPGRADE_WARNING: オブジェクト m_tempObj(UBound()) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    m_tempObj(UBound(m_tempObj)) = g_Obj(i)
                                    .lngHeight = UBound(m_tempObj)
                                    ReDim Preserve m_tempObj(UBound(m_tempObj) + 1)

                                End With

                            Next i

                            'UPGRADE_WARNING: オブジェクト m_tempObj(UBound()) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            m_tempObj(UBound(m_tempObj)) = g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                            'オブジェをグリッドにあわせる
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

                            'プレビュー
                            If _mnuOptionsItem_4.Checked Then

                                Select Case .intCh

                                    Case 11 To 29, Is > 100

                                        strTemp = g_strWAV(.sngValue)

                                        'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                                        If strTemp <> "" And Dir(g_BMS.strDir & strTemp) <> vbNullString Then

                                            Call PreviewWAV(strTemp)

                                        End If

                                    Case 4, 6, 7

                                        If Len(g_strBGA(.sngValue)) Then

                                            Call PreviewBGA(.sngValue)

                                        Else

                                            strTemp = g_strBMP(.sngValue)

                                            'UPGRADE_WARNING: オブジェクト g_BMS.strDir の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                                            If strTemp <> "" And Dir(g_BMS.strDir & strTemp) <> vbNullString Then

                                                Call PreviewBMP(strTemp)

                                            End If

                                        End If

                                End Select

                            End If

                        End With

                    End If

                    Call modDraw.Redraw()

                Else 'オブジェのないところで押したっぽいよ

                    If Not Shift And VB6.ShiftConstants.CtrlMask Then

                        Call modDraw.ObjSelectCancel()

                        Call modDraw.Redraw()

                    Else

                        For i = 0 To UBound(g_Obj) - 1

                            With g_Obj(i)

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                If .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                                    'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT

                                End If

                            End With

                        Next i

                        Call modDraw.Redraw()

                    End If

                    With g_SelectArea

                        'UPGRADE_WARNING: オブジェクト g_SelectArea.blnFlag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .blnFlag = True
                        '.X1 = (X + g_disp.X) / g_disp.Width
                        'UPGRADE_WARNING: オブジェクト g_SelectArea.X1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_disp.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_disp.Width の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .X1 = X / g_disp.Width + g_disp.X
                        'UPGRADE_WARNING: オブジェクト g_SelectArea.Y1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_disp.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_disp.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .Y1 = (picMain.ClientRectangle.Height - Y) / g_disp.Height + g_disp.Y
                        'UPGRADE_WARNING: オブジェクト g_SelectArea.X2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_SelectArea.X1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .X2 = .X1
                        'UPGRADE_WARNING: オブジェクト g_SelectArea.Y2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト g_SelectArea.Y1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .Y2 = .Y1

                    End With

                    Call modDraw.DrawSelectArea()

                End If

                'Call modDraw.Redraw
                'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If g_disp.intEffect Then Call modEasterEgg.DrawEffect()

            Else 'If tlbMenu.Buttons("Write").Value = tbrPressed Then

                Call modDraw.ObjSelectCancel()
                Call modDraw.Redraw()

                picMain.Font = VB6.FontChangeSize(picMain.Font, 8)

                Call modDraw.InitPen()
                Call modDraw.DrawObj(g_Obj(UBound(g_Obj)))
                Call modDraw.DeletePen()

            End If

        ElseIf Button = VB6.MouseButtonConstants.RightButton Then  '右クリック

            With g_Mouse

                'UPGRADE_WARNING: オブジェクト g_Mouse.Button の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Button = Button
                'UPGRADE_WARNING: オブジェクト g_Mouse.Shift の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Shift = Shift
                'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .X = X
                'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Y = Y

            End With

            Call DrawObjMax(X, Y, Shift)

        ElseIf Button = VB6.MouseButtonConstants.MiddleButton Then  '中クリック

            'オブジェ削除
            If g_Obj(UBound(g_Obj)).lngHeight < UBound(g_Obj) Then 'オブジェ選択中

                '入力履歴に追加
                With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                    Call g_InputLog.AddData(modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue & modLog.getSeparator)

                End With

                'オブジェ削除
                Call modDraw.RemoveObj(g_Obj(UBound(g_Obj)).lngHeight)

                g_Obj(UBound(g_Obj)).intCh = 0
                g_Obj(UBound(g_Obj)).lngHeight = UBound(g_Obj)

                '整列
                Call modDraw.ArrangeObj()

                '再描画
                Call modDraw.Redraw()

            End If

        End If

        g_blnIgnoreInput = False

        Exit Sub

Err_Renamed:
        'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseDown")
    End Sub

    Private Sub picMain_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
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

            If tlbMenu.Items.Item("Write").Pressed = True Then

                With g_Obj(UBound(g_Obj))

                    Select Case .intCh

                        Case 8 'BPM

                            With frmWindowInput

                                'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                                'UPGRADE_WARNING: オブジェクト g_Message() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                            'UPGRADE_WARNING: オブジェクト modMain.OBJ_ATT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_ATT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

            ElseIf tlbMenu.Items.Item("Edit").Pressed = True Then

                'UPGRADE_WARNING: オブジェクト g_SelectArea.blnFlag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If g_SelectArea.blnFlag Then

                    'UPGRADE_WARNING: オブジェクト g_SelectArea.blnFlag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    g_SelectArea.blnFlag = False

                    For i = 0 To UBound(g_Obj) - 1

                        With g_Obj(i)

                            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If .intSelect = modMain.OBJ_SELECT.Selected Or .intSelect = modMain.OBJ_SELECT.SELECTAREA_IN Or .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT Then

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                .intSelect = modMain.OBJ_SELECT.Selected

                            Else

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                .intSelect = modMain.OBJ_SELECT.NON_SELECT

                            End If

                        End With

                    Next i

                    Call modDraw.MoveSelectedObj()

                Else '複数選択っぽいよ

                    For i = 0 To UBound(g_Obj) - 1

                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                            'UPGRADE_WARNING: オブジェクト g_Measure(m_tempObj(UBound(m_tempObj)).intMeasure).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト g_Measure(g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intMeasure).lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                                'UPGRADE_WARNING: オブジェクト g_Measure(999).intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                If .intCh <= 0 Or .intCh > 1000 Or (.intMeasure = 0 And .lngPosition < 0) Or (.intMeasure = 999 And .lngPosition > g_Measure(999).intLen) Then

                                    With m_tempObj(g_Obj(i).lngHeight)

                                        strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
                                        ReDim Preserve strArray(UBound(strArray) + 1)

                                    End With

                                    Call modDraw.RemoveObj(i)

                                    'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

            If Not m_blnIgnoreMenu Then Me.ContextMenuStrip = mnuContext

            m_blnIgnoreMenu = False

        End If

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseUp")
    End Sub

    Public Sub picMain_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim lngTemp As Integer
        Dim strTemp As String
        Dim rectTemp As RECT
        Dim blnSelect() As Boolean
        Dim blnYAxisFixed As Boolean

        'VB6 バグ対策
        If Button And VB6.MouseButtonConstants.LeftButton Then

            If Not m_blnMouseDown Then

                Exit Sub

            End If

        End If

        'UPGRADE_WARNING: オブジェクト g_SelectArea.blnFlag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Dim value As Integer
        Dim str_Renamed As String
        If Not g_SelectArea.blnFlag Then '選択範囲なし

            If Button = VB6.MouseButtonConstants.LeftButton And tlbMenu.Items.Item("Edit").Pressed = True And g_Obj(UBound(g_Obj)).intCh <> 0 Then 'オブジェ移動中

                Call MoveObj(X, Y, Shift)

                'Y 軸固定移動
                If Shift And VB6.ShiftConstants.ShiftMask Then blnYAxisFixed = True

            Else 'それ以外

                Call modDraw.DrawObjMax(X, Y, Shift)

                'スポイト機能
                If Button = VB6.MouseButtonConstants.RightButton And g_Obj(UBound(g_Obj)).lngHeight < UBound(g_Obj) Then

                    With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                        Select Case .intCh

                            Case modInput.OBJ_CH.CH_BGA, modInput.OBJ_CH.CH_POOR, modInput.OBJ_CH.CH_LAYER, Is > modInput.OBJ_CH.CH_KEY_MIN


                                If _mnuOptionsItem_7.Checked Then

                                    str_Renamed = modInput.strFromNum(.sngValue)

                                    'もし 01-FF じゃなかったら 01-ZZ 表示に移行する
                                    'ASCII 文字セットでは 0-9 < A-Z < a-z
                                    If Asc(VB.Left(str_Renamed, 1)) > Asc("F") Or Asc(VB.Right(str_Renamed, 1)) > Asc("F") Then

                                        Call mnuOptionsItem_Click(_mnuOptionsItem_7, New System.EventArgs())
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

                                    If _optChangeBottom_2.Checked Then

                                        lstBGA.SelectedIndex = value - 1

                                    Else

                                        lstBMP.SelectedIndex = value - 1

                                    End If

                                End If

                                m_blnPreview = True

                        End Select

                        'ポップアップを表示しない
                        m_blnIgnoreMenu = True

                    End With

                End If

            End If

        Else '選択範囲あり

            With g_Mouse

                'UPGRADE_WARNING: オブジェクト g_Mouse.Button の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Button = Button
                'UPGRADE_WARNING: オブジェクト g_Mouse.Shift の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Shift = Shift
                'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .X = X
                'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Y = Y

            End With

            With g_SelectArea

                '.X2 = (X + g_disp.X) / g_disp.Width
                'UPGRADE_WARNING: オブジェクト g_SelectArea.X2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_disp.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_disp.Width の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .X2 = X / g_disp.Width + g_disp.X
                'UPGRADE_WARNING: オブジェクト g_SelectArea.Y2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_disp.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_disp.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Y2 = (picMain.ClientRectangle.Height - Y) / g_disp.Height + g_disp.Y

            End With

            With rectTemp

                'UPGRADE_WARNING: オブジェクト g_SelectArea.X2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_SelectArea.X1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If g_SelectArea.X1 > g_SelectArea.X2 Then

                    'UPGRADE_WARNING: オブジェクト g_SelectArea.X2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .left_Renamed = g_SelectArea.X2
                    'UPGRADE_WARNING: オブジェクト g_SelectArea.X1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .right_Renamed = g_SelectArea.X1

                Else

                    'UPGRADE_WARNING: オブジェクト g_SelectArea.X1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .left_Renamed = g_SelectArea.X1
                    'UPGRADE_WARNING: オブジェクト g_SelectArea.X2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .right_Renamed = g_SelectArea.X2

                End If

                'UPGRADE_WARNING: オブジェクト g_SelectArea.Y2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト g_SelectArea.Y1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If g_SelectArea.Y1 > g_SelectArea.Y2 Then

                    'UPGRADE_WARNING: オブジェクト g_SelectArea.Y2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Top = g_SelectArea.Y2
                    'UPGRADE_WARNING: オブジェクト g_SelectArea.Y1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bottom = g_SelectArea.Y1

                Else

                    'UPGRADE_WARNING: オブジェクト g_SelectArea.Y1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Top = g_SelectArea.Y1
                    'UPGRADE_WARNING: オブジェクト g_SelectArea.Y2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bottom = g_SelectArea.Y2

                End If

            End With

            ReDim blnSelect(UBound(g_VGrid))

            For i = 0 To UBound(g_VGrid)

                With g_VGrid(i)

                    blnSelect(i) = False

                    'UPGRADE_WARNING: オブジェクト g_VGrid(i).blnVisible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If .blnVisible Then

                        'UPGRADE_WARNING: オブジェクト g_VGrid(i).intCh の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If .intCh Then

                            'If (.lngLeft + .intWidth >= g_SelectArea.X1 And .lngLeft <= g_SelectArea.X2) Or (.lngLeft <= g_SelectArea.X1 And .lngLeft + .intWidth >= g_SelectArea.X2) Then
                            'UPGRADE_WARNING: オブジェクト g_VGrid(i).lngLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト g_VGrid(i).intWidth の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

                        'UPGRADE_WARNING: オブジェクト g_Measure().lngY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        lngTemp = g_Measure(.intMeasure).lngY + .lngPosition

                        'If (lngTemp >= g_SelectArea.Y1 And lngTemp <= g_SelectArea.Y2 + OBJ_HEIGHT / g_disp.Height) Or (lngTemp <= g_SelectArea.Y1 And lngTemp >= g_SelectArea.Y2 - OBJ_HEIGHT / g_disp.Height) Then
                        'UPGRADE_WARNING: オブジェクト g_disp.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If lngTemp + OBJ_HEIGHT / g_disp.Height >= rectTemp.Top And lngTemp <= rectTemp.Bottom Then

                            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                .intSelect = modMain.OBJ_SELECT.SELECTAREA_IN

                            Else

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                .intSelect = modMain.OBJ_SELECT.SELECTAREA_SELECTED

                            End If

                        Else

                            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                .intSelect = modMain.OBJ_SELECT.NON_SELECT

                            Else

                                'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT

                            End If

                        End If

                    Else

                        'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then

                            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            .intSelect = modMain.OBJ_SELECT.NON_SELECT

                        Else

                            'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT

                        End If

                    End If

                End With

            Next i

            Call modDraw.DrawSelectArea()

            'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If g_disp.intEffect Then Call modEasterEgg.DrawEffect()

        End If

        'ツールチップ表示
        If g_Obj(UBound(g_Obj)).lngHeight <> UBound(g_Obj) Then

            With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                Select Case .intCh

                    Case Is > 100, 11 To 29 'BGM・キー音

                        strTemp = "#WAV" & strFromNum(.sngValue) & ":"

                        If Len(g_strWAV(.sngValue)) Then
                            strTemp = strTemp & g_strWAV(.sngValue)
                        Else
                            strTemp = strTemp & "<empty>"
                        End If

                    Case 4, 6, 7 'BGA LAYER POOR

                        If Len(g_strBGA(.sngValue)) Then 'BGA あるよ

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

            '空かどうか
            ToolTip1.SetToolTip(picMain, strTemp)

        Else

            ToolTip1.SetToolTip(picMain, "")

        End If

        With g_Mouse

            'UPGRADE_WARNING: オブジェクト g_Mouse.Button の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Button = Button
            'UPGRADE_WARNING: オブジェクト g_Mouse.Shift の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Shift = Shift
            'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .X = X
            'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
        'UPGRADE_WARNING: オブジェクト modMain.CleanUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseMove")
    End Sub

    'UPGRADE_ISSUE: VBRUN.DataObject 型 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'UPGRADE_ISSUE: PictureBox イベント picMain.OLEDragDrop はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' をクリックしてください。
    Private Sub picMain_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)

        Call FormDragDrop(Data)

    End Sub

    Private Sub staMain_PanelDblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _staMain_Panel6.DoubleClick, Measure.DoubleClick, BMP.DoubleClick, WAV.DoubleClick, Position.DoubleClick, Mode.DoubleClick
        Dim Panel As System.Windows.Forms.ToolStripStatusLabel = CType(eventSender, System.Windows.Forms.ToolStripStatusLabel)

        If Panel.Name = staMain.Items.Item("Mode").Name Then
            If tlbMenu.Items.Item("Edit").Pressed = True Then
                Call mnuEditMode_Click(_mnuEditMode_1, New System.EventArgs())
            ElseIf tlbMenu.Items.Item("Write").Pressed = True Then
                Call mnuEditMode_Click(_mnuEditMode_2, New System.EventArgs())
            ElseIf tlbMenu.Items.Item("Delete").Pressed = True Then
                Call mnuEditMode_Click(_mnuEditMode_0, New System.EventArgs())
            End If
        End If

    End Sub

    Private Sub tlbMenu_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Delete.Click, Write.Click, Edit.Click, SepMode.Click, SaveAs.Click, Save.Click, Reload.Click, Resolution.Click, Open.Click, SepResolution.Click, DispSize.Click, SepSize.Click, ChangeGrid.Click, SepGrid.Click, _Stop.Click, Play.Click, PlayAll.Click, Viewer.Click, SepViewer.Click, _New.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        On Error GoTo Err_Renamed

        Select Case Button.Name

            Case "_New" '新規作成

                Call mnuFileNew_Click(mnuFileNew, New System.EventArgs())

            Case "Open" '開く

                Call mnuFileOpen_Click(mnuFileOpen, New System.EventArgs())

            Case "Reload" '再読み込み

                Call mnuRecentFiles_Click(_mnuRecentFiles_0, New System.EventArgs())

            Case "Save" '上書き保存

                Call mnuFileSave_Click(mnuFileSave, New System.EventArgs())

            Case "SaveAs" '名前を付けて保存

                Call mnuFileSaveAs_Click(mnuFileSaveAs, New System.EventArgs())

            Case "Edit"

                Call mnuEditMode_Click(_mnuEditMode_0, New System.EventArgs())

            Case "Write"

                Call mnuEditMode_Click(_mnuEditMode_1, New System.EventArgs())

            Case "Delete"

                Call mnuEditMode_Click(_mnuEditMode_2, New System.EventArgs())

            Case "PlayAll"

                Call mnuToolsPlayAll_Click(mnuToolsPlayAll, New System.EventArgs())

            Case "Play"

                Call mnuToolsPlay_Click(mnuToolsPlay, New System.EventArgs())

            Case "_Stop"

                Call mnuToolsPlayStop_Click(mnuToolsPlayStop, New System.EventArgs())

        End Select

Err_Renamed:
    End Sub

    Private Sub tlbMenu_ButtonMenuClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ToolStripMenuItem9.Click, ToolStripMenuItem8.Click, ToolStripMenuItem7.Click, ToolStripMenuItem6.Click, ToolStripMenuItem5.Click, ToolStripMenuItem4.Click, ToolStripMenuItem3.Click, ToolStripMenuItem2.Click, ToolStripMenuItem1.Click, ToolStripMenuItem0.Click

        Select Case DirectCast(eventSender, ToolStripItem).Name
            Case ToolStripMenuItem0.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_0, New System.EventArgs())
            Case ToolStripMenuItem1.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_1, New System.EventArgs())
            Case ToolStripMenuItem2.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_2, New System.EventArgs())
            Case ToolStripMenuItem3.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_3, New System.EventArgs())
            Case ToolStripMenuItem4.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_4, New System.EventArgs())
            Case ToolStripMenuItem5.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_5, New System.EventArgs())
            Case ToolStripMenuItem6.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_6, New System.EventArgs())
            Case ToolStripMenuItem7.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_7, New System.EventArgs())
            Case ToolStripMenuItem8.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_8, New System.EventArgs())
            Case ToolStripMenuItem9.Name
                Call mnuRecentFiles_Click(_mnuRecentFiles_9, New System.EventArgs())
        End Select
    End Sub

    'UPGRADE_ISSUE: MSComctlLib.Toolbar イベント tlbMenu.Change はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' をクリックしてください。
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

            'UPGRADE_WARNING: オブジェクト g_Mouse.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_Mouse.X の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_Mouse.Shift の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call picMain_MouseMove(picMain, New System.Windows.Forms.MouseEventArgs(VB6.MouseButtonConstants.LeftButton * &H100000, 0, g_Mouse.X, g_Mouse.Y, 0))
            'Call MoveObj(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)

        End If

    End Sub

    Public Sub tmrEffect_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrEffect.Tick

        Dim gp As Graphics = picMain.CreateGraphics()
        Call gp.Clear(picMain.BackColor)

        If g_Obj(UBound(g_Obj)).intCh Then

            Call modDraw.InitPen()
            Call modDraw.DrawObj(g_Obj(UBound(g_Obj)))
            Call modDraw.DeletePen()

        End If

        'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

        'UPGRADE_WARNING: オブジェクト g_SelectArea.blnFlag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If g_SelectArea.blnFlag Then Call modDraw.DrawSelectArea()

        'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If g_disp.intEffect Then Call modEasterEgg.DrawEffect()

    End Sub

    'UPGRADE_WARNING: イベント txtArtist.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtArtist_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtArtist.TextChanged

        Call SaveChanges()

    End Sub

    'UPGRADE_WARNING: イベント txtBPM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtBPM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBPM.TextChanged

        Call SaveChanges()

    End Sub

    'UPGRADE_WARNING: イベント txtExInfo.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtExInfo_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtExInfo.TextChanged

        Call SaveChanges()

    End Sub

    'UPGRADE_WARNING: イベント txtGenre.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtGenre_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGenre.TextChanged

        Call SaveChanges()

    End Sub

    'UPGRADE_WARNING: イベント txtMissBMP.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtMissBMP_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMissBMP.TextChanged

        Call SaveChanges()

    End Sub

    'UPGRADE_WARNING: イベント txtStageFile.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtStageFile_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtStageFile.TextChanged

        Call SaveChanges()
    End Sub

    'UPGRADE_WARNING: イベント txtTitle.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtTitle_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTitle.TextChanged

        Call SaveChanges()

    End Sub

    'UPGRADE_WARNING: イベント txtTotal.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtTotal_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTotal.TextChanged

        Call SaveChanges()

    End Sub

    Private Sub txtTotal_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtTotal.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        If KeyCode = System.Windows.Forms.Keys.Return Then

            If txtTotal.Text = "10572" Then Call lngSet_ini("EasterEgg", "Tips", 1)

        End If

    End Sub

    'UPGRADE_WARNING: イベント txtVolume.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtVolume_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtVolume.TextChanged

        Call SaveChanges()

    End Sub

    'UPGRADE_NOTE: vsbMain.Change はイベントからプロシージャに変更されました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' をクリックしてください。
    'UPGRADE_WARNING: VScrollBar イベント vsbMain.Change には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    Private Sub vsbMain_Change(ByVal newScrollValue As Integer)
        On Error Resume Next

        With g_disp

            '.Y = CLng(vsbMain.Value) * 96
            'UPGRADE_WARNING: オブジェクト g_disp.Y の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト g_disp.intResolution の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Y = CInt(newScrollValue) * .intResolution

        End With

        Call modDraw.Redraw()

        'Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)
        'スクロール＆オブジェ移動実現のため

    End Sub

    'UPGRADE_NOTE: vsbMain.Scroll はイベントからプロシージャに変更されました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' をクリックしてください。
    Private Sub vsbMain_Scroll_Renamed(ByVal newScrollValue As Integer)

        Call vsbMain_Change(0)

    End Sub
    Private Sub hsbMain_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles hsbMain.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.ThumbTrack
                hsbMain_Scroll_Renamed(eventArgs.NewValue)
            Case System.Windows.Forms.ScrollEventType.EndScroll
                hsbMain_Change(eventArgs.NewValue)
        End Select
    End Sub
    Private Sub vsbMain_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles vsbMain.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.ThumbTrack
                vsbMain_Scroll_Renamed(eventArgs.NewValue)
            Case System.Windows.Forms.ScrollEventType.EndScroll
                vsbMain_Change(eventArgs.NewValue)
        End Select
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim NewLargeChange As Short

        Dim i As Integer
        Dim wp As WINDOWPLACEMENT

        'UPGRADE_WARNING: オブジェクト modMain.StartUp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call modMain.StartUp()

        If cboViewer.Items.Count = 0 Then

            tlbMenu.Items.Item("PlayAll").Enabled = False
            tlbMenu.Items.Item("Play").Enabled = False
            tlbMenu.Items.Item("_Stop").Enabled = False
            mnuToolsPlayAll.Enabled = False
            mnuToolsPlay.Enabled = False
            mnuToolsPlayStop.Enabled = False
            cboViewer.Enabled = False

        End If

        _mnuRecentFiles_0.Visible = False
        _mnuRecentFiles_1.Visible = False
        _mnuRecentFiles_2.Visible = False
        _mnuRecentFiles_3.Visible = False
        _mnuRecentFiles_4.Visible = False
        _mnuRecentFiles_5.Visible = False
        _mnuRecentFiles_6.Visible = False
        _mnuRecentFiles_7.Visible = False
        _mnuRecentFiles_8.Visible = False
        _mnuRecentFiles_9.Visible = False

        mnuLineRecent.Visible = False
        mnuHelpOpen.Enabled = False

        Me.Text = g_strAppTitle

        Call LoadConfig()

        dlgMainOpen.InitialDirectory = g_strAppDir
        dlgMainSave.InitialDirectory = g_strAppDir
        'UPGRADE_WARNING: FileOpenConstants 定数 FileOpenConstants.cdlOFNHideReadOnly は、新しい動作をもつ OpenFileDialog.ShowReadOnly にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' をクリックしてください。
        'UPGRADE_WARNING: MSComDlg.CommonDialog プロパティ dlgMain.Flags は、新しい動作をもつ dlgMainOpen.CheckFileExists にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' をクリックしてください。
        dlgMainOpen.CheckFileExists = True
        dlgMainOpen.CheckPathExists = True
        dlgMainSave.CheckPathExists = True
        'UPGRADE_WARNING: MSComDlg.CommonDialog プロパティ dlgMain.Flags は、新しい動作をもつ dlgMainOpen.ShowReadOnly にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' をクリックしてください。
        'UPGRADE_WARNING: FileOpenConstants 定数 FileOpenConstants.cdlOFNHideReadOnly は、新しい動作をもつ OpenFileDialog.ShowReadOnly にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' をクリックしてください。
        dlgMainOpen.ShowReadOnly = False
        'UPGRADE_WARNING: MSComDlg.CommonDialog プロパティ dlgMain.Flags は、新しい動作をもつ dlgMainSave.OverwritePrompt にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"' をクリックしてください。
        dlgMainSave.OverwritePrompt = True

        'UPGRADE_WARNING: オブジェクト g_disp.lngMaxY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        g_disp.lngMaxY = (vsbMain.Maximum - vsbMain.LargeChange + 1)
        'UPGRADE_WARNING: オブジェクト g_disp.lngMaxX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        g_disp.lngMaxX = hsbMain.Minimum

        hsbMain.SmallChange = OBJ_WIDTH
        NewLargeChange = OBJ_WIDTH * 4
        hsbMain.Maximum = hsbMain.Maximum + NewLargeChange - hsbMain.LargeChange
        hsbMain.LargeChange = NewLargeChange

        'UPGRADE_WARNING: オブジェクト g_BMS.intPlayerType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        cboPlayer.SelectedIndex = g_BMS.intPlayerType - 1
        'UPGRADE_WARNING: オブジェクト g_BMS.lngPlayLevel の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        cboPlayLevel.Text = g_BMS.lngPlayLevel
        'UPGRADE_WARNING: オブジェクト g_BMS.intPlayRank の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
            'UPGRADE_WARNING: オブジェクト g_Measure().intLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_Measure(i).intLen = 192

        Next i

        lstWAV.SelectedIndex = 0
        lstBMP.SelectedIndex = 0
        lstBGA.SelectedIndex = 0

        'UPGRADE_ISSUE: Frame プロパティ fraViewer.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'fraViewer.BorderStyle = 0
        'UPGRADE_ISSUE: Frame プロパティ fraGrid.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'fraGrid.BorderStyle = 0
        'UPGRADE_ISSUE: Frame プロパティ fraDispSize.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'fraDispSize.BorderStyle = 0
        'UPGRADE_ISSUE: Frame プロパティ fraResolution.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'fraResolution.BorderStyle = 0

        'UPGRADE_ISSUE: Frame プロパティ fraHeader.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'fraHeader.BorderStyle = 0
        'UPGRADE_ISSUE: Frame プロパティ fraMaterial.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'fraMaterial.BorderStyle = 0


        _fraTop_0.Top = 0
        _fraTop_0.Left = 0
        '_fraTop_0.BorderStyle = 0
        _fraTop_1.Top = 0
        _fraTop_1.Left = 0
        '_fraTop_1.BorderStyle = 0
        _fraTop_2.Top = 0
        _fraTop_2.Left = 0
        '_fraTop_2.BorderStyle = 0


        _fraTop_0.Visible = True
        _optChangeTop_0.Checked = True

        _fraBottom_0.Top = 0
        _fraBottom_0.Left = 0
        '_fraBottom_0.BorderStyle = 0
        _fraBottom_1.Top = 0
        _fraBottom_1.Left = 0
        '_fraBottom_1.BorderStyle = 0
        _fraBottom_2.Top = 0
        _fraBottom_2.Left = 0
        '_fraBottom_2.BorderStyle = 0
        _fraBottom_3.Top = 0
        _fraBottom_3.Left = 0
        '_fraBottom_3.BorderStyle = 0

        _fraBottom_0.Visible = True
        _optChangeBottom_0.Checked = True

        For i = 1 To 64

            Call cboNumerator.Items.Insert(i - 1, CStr(i))

        Next i

        cboNumerator.SelectedIndex = 3
        cboDenominator.SelectedIndex = 0

        lstMeasureLen.SelectedIndex = 0

        m_blnPreview = True

        'UPGRADE_WARNING: オブジェクト strGet_ini(EasterEgg, Tips, 0, bmse.ini) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If strGet_ini("EasterEgg", "Tips", 0, "bmse.ini") Then

            With frmWindowTips

                .Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Left) + (VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
                .Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) + (VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)

                Call VB6.ShowForm(frmWindowTips, VB6.FormShowConstants.Modal, Me)

            End With

        End If

        wp.Length = 44
        Call GetWindowPlacement(Me.Handle.ToInt32, wp)
        'UPGRADE_WARNING: オブジェクト strGet_ini() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wp.showCmd = strGet_ini("Main", "State", SW_SHOW, "bmse.ini")
        Call SetWindowPlacement(Me.Handle.ToInt32, wp)

        Call GetCmdLine()

        AddHandler Me.Resize, AddressOf frmMain_Resize
        AddHandler cboDispGridMain.SelectedIndexChanged, AddressOf cboDispGridMain_SelectedIndexChanged
        AddHandler cboDispGridSub.SelectedIndexChanged, AddressOf cboDispGridSub_SelectedIndexChanged
        AddHandler cboDispWidth.SelectedIndexChanged, AddressOf cboDispWidth_SelectedIndexChanged
        AddHandler cboDispHeight.SelectedIndexChanged, AddressOf cboDispHeight_SelectedIndexChanged
        AddHandler cboVScroll.SelectedIndexChanged, AddressOf cboVScroll_SelectedIndexChanged

    End Sub
End Class
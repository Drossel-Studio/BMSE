Option Strict Off
Option Explicit On
Module modInput
	
	Public Enum OBJ_CH
		CH_NONE = 0
		CH_BGM = 1
		CH_MEASURE_LENGTH = 2
		CH_BPM = 3
		CH_BGA = 4
		CH_EXTCHR = 5
		CH_POOR = 6
		CH_LAYER = 7
		CH_EXBPM = 8
		CH_STOP = 9
		CH_INV = 20
		CH_LN = 40
		CH_KEY_MIN = 10
		CH_1P_KEY1 = OBJ_CH.CH_KEY_MIN + 1
		CH_1P_KEY2 = OBJ_CH.CH_KEY_MIN + 2
		CH_1P_KEY3 = OBJ_CH.CH_KEY_MIN + 3
		CH_1P_KEY4 = OBJ_CH.CH_KEY_MIN + 4
		CH_1P_KEY5 = OBJ_CH.CH_KEY_MIN + 5
		CH_1P_KEY6 = OBJ_CH.CH_KEY_MIN + 6
		CH_1P_KEY7 = OBJ_CH.CH_KEY_MIN + 7
		CH_1P_SC = OBJ_CH.CH_KEY_MIN + 8
		CH_2P_KEY1 = OBJ_CH.CH_1P_KEY1 + 10
		CH_2P_KEY2 = OBJ_CH.CH_1P_KEY2 + 10
		CH_2P_KEY3 = OBJ_CH.CH_1P_KEY3 + 10
		CH_2P_KEY4 = OBJ_CH.CH_1P_KEY4 + 10
		CH_2P_KEY5 = OBJ_CH.CH_1P_KEY5 + 10
		CH_2P_KEY6 = OBJ_CH.CH_1P_KEY6 + 10
		CH_2P_KEY7 = OBJ_CH.CH_1P_KEY7 + 10
		CH_2P_SC = OBJ_CH.CH_1P_SC + 10
		CH_KEY_MAX = OBJ_CH.CH_KEY_MIN + 20
		CH_KEY_INV_MIN = OBJ_CH.CH_KEY_MIN + OBJ_CH.CH_INV
		CH_KEY_INV_MAX = OBJ_CH.CH_KEY_MAX + OBJ_CH.CH_INV
		CH_KEY_LN_MIN = OBJ_CH.CH_KEY_MIN + OBJ_CH.CH_LN
		CH_KEY_LN_MAX = OBJ_CH.CH_KEY_MAX + OBJ_CH.CH_LN
	End Enum
	
	Public Enum PLAYER_TYPE
		PLAYER_1P = 1
		PLAYER_2P = 2
		PLAYER_DP = 3
		PLAYER_PMS = 4
		PLAYER_OCT = 5
	End Enum
	
	'判定ランク
	Public Enum PLAY_RANK
		RANK_VERYHARD = 0
		RANK_HARD = 1
		RANK_NORMAL = 2
		RANK_EASY = 3
		RANK_MIN = PLAY_RANK.RANK_VERYHARD
		RANK_MAX = PLAY_RANK.RANK_EASY
	End Enum

    Public Const MATERIAL_MAX As Integer = 1295
    Public Const MEASURE_MAX As Integer = 999
    Public Const MEASURE_LENGTH As Integer = 192

    Public Const BPM_LANE As Integer = 32

    Private Const DEFAULT_BPM As Integer = 130
    Private Const DEFAULT_VOLUME As Integer = 1

    Private m_blnUnreadFlag As Boolean
	Private m_strEXInfo As String
	
	Private m_blnBGM() As Boolean

    Public Structure m_udtMeasure
        Dim intLen As Integer
        Dim lngY As Integer
    End Structure

    Public g_Measure(MEASURE_MAX) As m_udtMeasure
	
	Public g_strWAV(MATERIAL_MAX) As String
	Public g_strBMP(MATERIAL_MAX) As String
	Public g_strBGA(MATERIAL_MAX) As String
	
	Private m_lngStop(MATERIAL_MAX) As Integer
	Private m_sngBPM(MATERIAL_MAX) As Single
	
	Public Sub LoadBMS()
        On Error GoTo Err_Renamed

        'ファイルの存在チェック
        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If Dir(g_BMS.strDir & g_BMS.strFileName, FileAttribute.Normal) = vbNullString Then

            Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)

            Exit Sub
			
		End If
		
		frmMain.Text = g_strAppTitle & " - Now Loading"
		
		Call LoadBMSStart()
		
		Call LoadBMSData()
		
		Call CreatePairList()

		Call LoadBMSEnd()
		
		Exit Sub
		
Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "LoadBMS")
    End Sub
	
	Public Sub LoadBMSStart()
        On Error GoTo Err_Renamed

        Dim i As Integer
		
		With frmMain
			
			For i = 0 To MATERIAL_MAX
				
				g_strWAV(i) = ""
				g_strBMP(i) = ""
				g_strBGA(i) = ""
				m_sngBPM(i) = 0
				m_lngStop(i) = 0
				
			Next i
			
			.cboPlayer.SelectedIndex = 0
			.txtGenre.Text = ""
			.txtTitle.Text = ""
			.txtArtist.Text = ""
			.cboPlayLevel.Text = CStr(1)
			.txtBPM.Text = CStr(DEFAULT_BPM)
			.cboPlayRank.SelectedIndex = PLAY_RANK.RANK_EASY
			.txtTotal.Text = ""
			.txtVolume.Text = ""
			.txtStageFile.Text = ""
			.txtMissBMP.Text = ""
			.lstWAV.SelectedIndex = 0
			.lstBMP.SelectedIndex = 0
			.lstBGA.SelectedIndex = 0
			.lstMeasureLen.SelectedIndex = 0
			.lstMeasureLen.Visible = False
			.txtExInfo.Text = ""
			.Enabled = False

            .vsbMain.Value = .vsbMain.Maximum - frmMain.vsbMain.LargeChange + 1
            .hsbMain.Value = 0
			.cboVScroll.SelectedIndex = .cboVScroll.Items.Count - 2
			
			For i = 0 To MEASURE_MAX
				
				g_Measure(i).intLen = MEASURE_LENGTH
                modMain.SetItemString(.lstMeasureLen, i, "#" & Format(i, "000") & ":4/4")

            Next i
			
		End With
		
		With g_BMS

            .intPlayerType = PLAYER_TYPE.PLAYER_1P
            .strGenre = ""
            .strTitle = ""
            .strArtist = ""
            .sngBPM = DEFAULT_BPM
            .lngPlayLevel = 1
            .intPlayRank = PLAY_RANK.RANK_EASY
            .sngTotal = 0
            .intVolume = 0
            .strStageFile = ""

        End With

        g_disp.intMaxMeasure = 0
        Call modDraw.lngChangeMaxMeasure(15)
		Call modDraw.ChangeResolution()
		
		Call g_InputLog.clear()
		
		ReDim g_Obj(0)
		ReDim g_lngObjID(0)
		g_lngIDNum = 0
		
		m_blnUnreadFlag = False
		m_strEXInfo = ""
		
		ReDim m_blnBGM(BPM_LANE * (MEASURE_MAX + 1) - 1)
		
		For i = 0 To UBound(m_blnBGM)
			
			m_blnBGM(i) = False
			
		Next i
		
		Exit Sub
		
Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "LoadBMSStart")
    End Sub
	
	Public Sub LoadBMSEnd()
        On Error GoTo Err_Renamed

        With frmMain
			
			Call modEasterEgg.LoadEffect()
			
			Call frmMain.RefreshList()
			
			.lstMeasureLen.Visible = True
			
			Call modDraw.ChangeResolution()
			
			.Enabled = True

            If UCase(Right(g_BMS.strFileName, 3)) = "PMS" Then

                .cboPlayer.SelectedIndex = 3
                g_BMS.intPlayerType = 4

            End If

            m_blnUnreadFlag = False
			.txtExInfo.Text = m_strEXInfo
			m_strEXInfo = ""
			
		End With

        g_BMS.blnSaveFlag = True

        Call modDraw.InitVerticalLine()
		
		With frmMain

            If Len(g_BMS.strDir) Then

                If ._mnuOptionsItem_1.Checked Then

                    .Text = g_strAppTitle & " - " & g_BMS.strFileName

                Else

                    .Text = g_strAppTitle & " - " & g_BMS.strDir & g_BMS.strFileName

                End If

            End If

            Call .Show()
			
			Call .picMain.Focus()
			
		End With
		
		Exit Sub
		
Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "LoadBMSEnd")
    End Sub
	
	Private Sub LoadBMSData()
        On Error GoTo Err_Renamed

        Dim i As Integer
		Dim strArray() As String
		Dim strTemp As String
		Dim lngFFile As Integer
		
		lngFFile = FreeFile()

        FileOpen(lngFFile, g_BMS.strDir & g_BMS.strFileName, OpenMode.Input)

        Do While Not EOF(lngFFile)
			
			System.Windows.Forms.Application.DoEvents()
			
			strTemp = LineInput(lngFFile)
			
			strArray = Split(Replace(Replace(strTemp, vbCr, vbCrLf), vbLf, vbCrLf), vbCrLf)
			
			For i = 0 To UBound(strArray)
				
				If Left(strArray(i), 1) = "#" Then Call LoadBMSLine(strArray(i))
				
			Next i
			
		Loop 
		
		FileClose(lngFFile)
		
		ReDim Preserve g_Obj(UBound(g_Obj))
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				.lngPosition = (g_Measure(.intMeasure).intLen / .lngHeight) * .lngPosition
				
				If .intCh = OBJ_CH.CH_BPM Then 'BPM
					
					.intCh = OBJ_CH.CH_EXBPM
					
				ElseIf .intCh = OBJ_CH.CH_EXBPM Then  '拡張BPM
					
					If m_sngBPM(.sngValue) = 0 Then
						
						.intCh = OBJ_CH.CH_NONE
						
					Else
						
						.sngValue = m_sngBPM(.sngValue)
						
					End If
					
				ElseIf .intCh = OBJ_CH.CH_STOP Then  'ストップシーケンス
					
					.sngValue = m_lngStop(.sngValue)
					
				End If
				
			End With
			
		Next i
		
		'Call QuickSort(0, UBound(g_Obj))
		
		Exit Sub
		
Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "LoadBMSData")
    End Sub
	
	Public Sub LoadBMSLine(ByRef strLineData As String, Optional ByVal blnDirectInput As Boolean = False)
        On Error GoTo Err_Renamed

        Dim strArray() As String
		Dim strFunc As String
		Dim strParam As String
		
		strArray = Split(Replace(strLineData, " ", ":", 1, 1), ":")

        If UBound(strArray) > 0 Then

            strFunc = UCase(strArray(0))
            strParam = Mid(strLineData, Len(strFunc) + 2)

            Select Case strFunc

                Case "#IF", "#RANDOM", "#RONDAM", "#ENDIF"

                    If blnDirectInput = False Then

                        m_blnUnreadFlag = True

                        m_strEXInfo = m_strEXInfo & strLineData & vbCrLf

                    End If

                Case "#ENDIF"

                    m_blnUnreadFlag = False

                    m_strEXInfo = m_strEXInfo & strLineData & vbCrLf

                Case Else

                    If m_blnUnreadFlag = False Then

                        If LoadBMSHeader(strFunc, strParam, blnDirectInput) = False Then

                            If LoadBMSObject(strFunc, strParam) = False Then

                                m_strEXInfo = m_strEXInfo & strLineData & vbCrLf

                            End If

                        End If

                    Else

                        m_strEXInfo = m_strEXInfo & strLineData & vbCrLf

                    End If

            End Select

        Else

            m_strEXInfo = m_strEXInfo & strLineData & vbCrLf

        End If

        Exit Sub
		
Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "LoadBMSLine")
    End Sub
	
	Private Function LoadBMSHeader(ByRef strFunc As String, ByRef strParam As String, Optional ByVal blnDirectInput As Boolean = False) As Boolean
        On Error GoTo Err_Renamed

        Dim lngNum As Integer
		
		With frmMain
			
			Select Case strFunc
				
				'Case "#PATH_WAV"
				
				'g_BMS.strDir = strParam
				
				Case "#PLAYER"

                    g_BMS.intPlayerType = Val(strParam)
                    .cboPlayer.SelectedIndex = Val(strParam) - 1
					
				Case "#GENRE", "#GENLE"

                    g_BMS.strGenre = strParam
                    .txtGenre.Text = strParam
					
				Case "#TITLE"
                    g_BMS.strTitle = strParam
                    .txtTitle.Text = strParam
					
				Case "#ARTIST"

                    g_BMS.strArtist = strParam
                    .txtArtist.Text = strParam
					
				Case "#BPM"

                    g_BMS.sngBPM = Val(strParam)
                    .txtBPM.Text = CStr(Val(strParam))
					
				Case "#PLAYLEVEL"

                    g_BMS.lngPlayLevel = Val(strParam)
                    .cboPlayLevel.Text = CStr(Val(strParam))
					
				Case "#RANK"

                    g_BMS.intPlayRank = Val(strParam)

                    If g_BMS.intPlayRank < PLAY_RANK.RANK_MIN Then g_BMS.intPlayRank = PLAY_RANK.RANK_MIN

                    If g_BMS.intPlayRank > PLAY_RANK.RANK_MAX Then g_BMS.intPlayRank = PLAY_RANK.RANK_MAX

                    .cboPlayRank.SelectedIndex = g_BMS.intPlayRank

                Case "#TOTAL"

                    g_BMS.sngTotal = Val(strParam)
                    .txtTotal.Text = CStr(Val(strParam))
					
				Case "#VOLWAV"

                    g_BMS.intVolume = Val(strParam)
                    .txtVolume.Text = CStr(Val(strParam))
					
				Case "#STAGEFILE"

                    g_BMS.strStageFile = strParam
                    .txtStageFile.Text = strParam
					
				Case Else
					
					lngNum = strToNum(Right(strFunc, 2))
					
					Select Case Left(strFunc, Len(strFunc) - 2)
						
						Case "#WAV"
							
							If lngNum <> 0 And blnDirectInput = False Then
								
								g_strWAV(lngNum) = strParam
								
								'                            If Asc(left$(strTemp, 1)) > Asc("F") Or Asc(right$(strTemp, 1)) > Asc("F") Then
								'
								'                                .mnuOptionsItem(USE_OLD_FORMAT).Checked = False
								'
								'                            End If
								
							End If
							
						Case "#BMP"
							
							If blnDirectInput = False Then
								
								If lngNum <> 0 Then
									
									g_strBMP(lngNum) = strParam
									
									'                                If Asc(left$(strTemp, 1)) > Asc("F") Or Asc(right$(strTemp, 1)) > Asc("F") Then
									'
									'                                    .mnuOptionsItem(USE_OLD_FORMAT).Checked = False
									'
									'                                End If
									
								Else
									
									.txtMissBMP.Text = strParam
									
								End If
								
							End If
							
						Case "#BGA"
							
							If lngNum <> 0 And blnDirectInput = False Then
								
								g_strBGA(lngNum) = strParam
								
								'                            If Asc(left$(strTemp, 1)) > Asc("F") Or Asc(right$(strTemp, 1)) > Asc("F") Then
								'
								'                                .mnuOptionsItem(USE_OLD_FORMAT).Checked = False
								'
								'                            End If
								
							End If
							
						Case "#BPM"
							
							If lngNum <> 0 And blnDirectInput = False Then
								
								m_sngBPM(lngNum) = CSng(strParam)
								
							End If
							
						Case "#STOP"
							
							If lngNum <> 0 And blnDirectInput = False Then
								
								m_lngStop(lngNum) = CInt(strParam)
								
							End If
							
						Case Else
							
							LoadBMSHeader = True
							
					End Select
					
			End Select
			
		End With
		
		LoadBMSHeader = Not LoadBMSHeader
		
		Exit Function
		
Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "LoadBMSHeader")
    End Function
	
	Private Function LoadBMSObject(ByRef strFunc As String, ByRef strParam As String) As Boolean
        On Error GoTo Err_Renamed

        Dim i As Integer
		Dim j As Integer
        Dim intTemp As Integer
        Dim intMeasure As Integer
        Dim intCh As Integer
        Dim lngSepaNum As Integer
        Dim Value As String = Space(2)

        intMeasure = Val(Mid(strFunc, 2, 3))
		intCh = Val(Mid(strFunc, 5, 2))
		
		lngSepaNum = Len(strParam) \ 2
		
		If intCh = OBJ_CH.CH_MEASURE_LENGTH Then
			
			If Val(strParam) = 0 Then Exit Function
			
			intTemp = intGCD(Int(MEASURE_LENGTH * Val(strParam)), MEASURE_LENGTH)
			
			If intTemp <= 2 Then intTemp = 3
			
			If intTemp >= 48 Then intTemp = 48
			
			With g_Measure(intMeasure)
				
				.intLen = Int(MEASURE_LENGTH * Val(strParam))
				
				If .intLen < 3 Then .intLen = 3
				
				Do While .intLen \ intTemp > 64
					
					If intTemp >= 48 Then
						
						.intLen = 3072
						
						Exit Do
						
					End If
					
					intTemp = intTemp * 2
					
				Loop

                modMain.SetItemString(frmMain.lstMeasureLen, intMeasure, "#" & Format(intMeasure, "000") & ":" & (.intLen \ intTemp) & "/" & (MEASURE_LENGTH \ intTemp))

            End With
			
		Else
			
			If intCh = OBJ_CH.CH_BGM Then
				
				For j = 0 To 31
					
					If m_blnBGM(intMeasure * 32 + j) = False Then
						
						m_blnBGM(intMeasure * 32 + j) = True
						intTemp = 101 + j
						
						Exit For
						
					End If
					
				Next j
				
			End If
			
			For i = 1 To lngSepaNum

                Value = Mid(strParam, i * 2 - 1, 2)

                If Value <> "00" Then

                    With g_Obj(UBound(g_Obj))

                        .lngID = g_lngIDNum
                        g_lngObjID(g_lngIDNum) = g_lngIDNum
                        .lngPosition = i - 1
                        .lngHeight = lngSepaNum
                        .intMeasure = intMeasure
                        .intCh = intCh

                        Call modDraw.lngChangeMaxMeasure(.intMeasure)

                        Select Case intCh

                            Case OBJ_CH.CH_BGM 'BGM

                                .sngValue = strToNum(Value)
                                .intCh = intTemp

                            Case OBJ_CH.CH_BGA, OBJ_CH.CH_POOR, OBJ_CH.CH_LAYER, OBJ_CH.CH_EXBPM, OBJ_CH.CH_STOP 'BGA,Poor,Layer,拡張BPM,ストップシーケンス

                                .sngValue = strToNum(Value)

                            Case OBJ_CH.CH_BPM 'BPM

                                .sngValue = Val("&H" & Value)

                            Case 11 To 16, 18, 19, 21 To 26, 28, 29 'キー音

                                .sngValue = strToNum(Value)

                            Case 31 To 36, 38, 39, 41 To 46, 48, 49 'キー音 (INV)

                                .sngValue = strToNum(Value)
                                .intCh = .intCh - 20
                                .intAtt = modMain.OBJ_ATT.OBJ_INVISIBLE

                            Case 51 To 56, 58, 59, 61 To 66, 68, 69 'キー音 (LN)

                                .sngValue = strToNum(Value)
                                .intCh = .intCh - 40
                                .intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE

                            Case Else

                                Exit Function

                        End Select

                    End With

                    ReDim Preserve g_Obj(UBound(g_Obj) + 1)

                    g_lngIDNum = g_lngIDNum + 1
                    ReDim Preserve g_lngObjID(g_lngIDNum)

                End If

            Next i
			
		End If
		
		LoadBMSObject = True
		
		Exit Function
		
Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "LoadBMSObject")
    End Function
	
	Public Sub QuickSort(ByVal l As Integer, ByVal r As Integer)
		
		Dim i As Integer
		Dim j As Integer
		Dim p As Single
		
		p = g_Obj((l + r) \ 2).lngPosition
		i = l
		j = r
		
		Do 
			
			Do While g_Obj(i).lngPosition < p
				
				i = i + 1
				
			Loop 
			
			Do While g_Obj(j).lngPosition > p
				
				j = j - 1
				
			Loop 
			
			If i >= j Then Exit Do
			
			Call SwapObj(i, j)
			
			i = i + 1
			j = j - 1
			
		Loop 
		
		If (l < i - 1) Then Call QuickSort(l, i - 1)
		If (r > j + 1) Then Call QuickSort(j + 1, r)
		
	End Sub
	
	Public Sub SwapObj(ByVal Obj1Num As Integer, ByVal Obj2Num As Integer)
		
		Dim dummy As g_udtObj
		
		g_lngObjID(g_Obj(Obj1Num).lngID) = Obj2Num
		g_lngObjID(g_Obj(Obj2Num).lngID) = Obj1Num

        dummy = g_Obj(Obj1Num)
        g_Obj(Obj1Num) = g_Obj(Obj2Num)
        g_Obj(Obj2Num) = dummy

    End Sub
	
    'ペアノーツリストの作成
    Public Sub CreatePairList()
        Dim SortedObj(UBound(g_Obj)) As ObjForSort      '時間で並べ替えられたノーツリスト
        Dim pairNum As Integer                          '登録したペアリストの数
        Dim firstPair As Integer                        'スライド親ノーツのペアリストインデックス（スライドノーツ登録中に使用）
        Dim reg As Boolean                              'すでにペアリストに登録したか否か
        Dim delFlag As Boolean                          '削除対象のノーツがあるか否か
        Dim delMeasure As Integer                       '削除対象の小節番号
        Dim delPosition As Integer                      '削除対象の位置番号
        Dim i As Integer                                'ループカウンタ
        Dim j As Integer                                'ループカウンタ
        Dim k As Integer                                'ループカウンタ

        'ペアなしフラグの初期化
        ReDim g_ObjPairErrorFlag(UBound(g_Obj))
        For i = 0 To UBound(g_Obj)
            g_ObjPairErrorFlag(i) = 0
        Next

        '内部では入力された順番でノーツデータが並んでいるので時間で並び替える
        For i = 0 To UBound(g_Obj)
            SortedObj(i).index = i
            SortedObj(i).intCh = g_Obj(i).intCh
            SortedObj(i).intMeasure = g_Obj(i).intMeasure
            SortedObj(i).lngPosition = g_Obj(i).lngPosition
            SortedObj(i).sngValue = g_Obj(i).sngValue
            SortedObj(i).intSelect = g_Obj(i).intSelect
        Next
        Array.Sort(SortedObj, New CompareByTime)

        '削除フラグの処理（削除後のペアを表示するために削除対象を検索から除外する）
        '削除の枠線を検索
        delFlag = False
        For i = 0 To UBound(g_Obj)
            If SortedObj(i).intSelect = OBJ_SELECT.DELETE_RECT Then
                delFlag = True
                delMeasure = SortedObj(i).intMeasure
                delPosition = SortedObj(i).lngPosition
            End If
        Next
        '削除対象を検索
        If delFlag Then
            For i = 0 To UBound(g_Obj)
                If (SortedObj(i).intSelect <> OBJ_SELECT.DELETE_RECT) And (SortedObj(i).intMeasure = delMeasure) And (SortedObj(i).lngPosition = delPosition) Then
                    '削除対象の属性を枠線にし、検索から除外する
                    SortedObj(i).intSelect = OBJ_SELECT.DELETE_RECT
                End If
            Next
        End If

        'ペアリストの初期化
        ReDim g_PairList(UBound(g_Obj) + 1)
        pairNum = 0

        'ペアリストの作成
        For i = 0 To UBound(SortedObj)
            'ノーツでなければ除外
            'レーンが異なる
            If (SortedObj(i).intCh < OBJ_CH.CH_KEY_MIN) Or (SortedObj(i).intCh > OBJ_CH.CH_KEY_MAX) Then
                Continue For
            End If
            '枠線
            If (SortedObj(i).intSelect = OBJ_SELECT.EDIT_RECT) Or (SortedObj(i).intSelect = OBJ_SELECT.DELETE_RECT) Then
                Continue For
            End If

            Select Case (SortedObj(i).sngValue)
                'ロングノーツ
                Case NOTE_TYPE.LONG_NOTE
                    '登録済みかを検索
                    reg = False
                    For j = 0 To pairNum - 1
                        If (g_PairList(j).endID = SortedObj(i).index) Then
                            reg = True
                            Exit For
                        End If
                    Next j
                    If reg Then
                        Continue For
                    End If

                    'ペアリストを作成
                    g_PairList(pairNum).Type = SortedObj(i).sngValue
                    g_PairList(pairNum).ID = SortedObj(i).index
                    g_PairList(pairNum).startID = SortedObj(i).index
                    g_PairList(pairNum).endID = -1
                    g_PairList(pairNum).nextID = -1

                    For j = i + 1 To UBound(SortedObj)
                        'ペアとなるロングノーツを検索

                        '対象でなければ除外
                        'レーンが異なる
                        If (SortedObj(i).intCh <> SortedObj(j).intCh) Then
                            Continue For
                        End If
                        '枠線
                        If (SortedObj(j).intSelect = OBJ_SELECT.EDIT_RECT) Or (SortedObj(j).intSelect = OBJ_SELECT.DELETE_RECT) Then
                            Continue For
                        End If
                        '種類が異なる
                        If (SortedObj(j).sngValue <> NOTE_TYPE.LONG_NOTE) Then
                            Continue For
                        End If

                        'ペアとして登録
                        g_PairList(pairNum).endID = SortedObj(j).index
                        g_PairList(pairNum).nextID = SortedObj(j).index
                        Exit For
                    Next j

                    'ペアなしフラグを立てる
                    If (g_PairList(pairNum).endID = -1) Then
                        g_ObjPairErrorFlag(g_PairList(pairNum).ID) = 1
                    End If

                    '登録完了
                    pairNum += 1

                'スライドノーツ
                Case NOTE_TYPE.SLIDE_PARENT_NOTE
                    '登録済みかを検索
                    reg = False
                    For j = 0 To pairNum - 1
                        If (g_PairList(j).endID = SortedObj(i).index) Then
                            reg = True
                            Exit For
                        End If
                    Next j
                    If reg Then
                        Continue For
                    End If

                    'ペアリストを作成
                    firstPair = pairNum
                    g_PairList(pairNum).Type = SortedObj(i).sngValue
                    g_PairList(firstPair).ID = SortedObj(i).index
                    g_PairList(firstPair).startID = SortedObj(i).index
                    g_PairList(firstPair).endID = -1
                    g_PairList(firstPair).nextID = -1

                    For j = i + 1 To UBound(SortedObj)
                        'ペアとなるノーツを検索

                        '対象でなければ除外
                        'レーンが異なる
                        If (SortedObj(j).intCh < OBJ_CH.CH_KEY_MIN) Or (SortedObj(j).intCh > OBJ_CH.CH_KEY_MAX) Then
                            Continue For
                        End If
                        '枠線
                        If (SortedObj(j).intSelect = OBJ_SELECT.EDIT_RECT) Or (SortedObj(j).intSelect = OBJ_SELECT.DELETE_RECT) Then
                            Continue For
                        End If
                        '種類が異なる
                        If ((SortedObj(j).sngValue <> NOTE_TYPE.SLIDE_PARENT_NOTE) And (SortedObj(j).sngValue <> NOTE_TYPE.SLIDE_CHILD_NOTE)) Then
                            Continue For
                        End If

                        'スライド子ノーツの場合
                        If (SortedObj(j).sngValue = NOTE_TYPE.SLIDE_CHILD_NOTE) Then
                            'ペアとして登録
                            g_PairList(pairNum).nextID = SortedObj(j).index
                            pairNum += 1

                            '子ノーツ用のペアリストを作成
                            g_PairList(pairNum).Type = SortedObj(j).sngValue
                            g_PairList(pairNum).ID = SortedObj(j).index
                            g_PairList(pairNum).startID = g_PairList(firstPair).startID
                            g_PairList(pairNum).endID = -1
                            g_PairList(pairNum).nextID = -1
                        End If

                        'スライド親ノーツの場合
                        If (SortedObj(j).sngValue = NOTE_TYPE.SLIDE_PARENT_NOTE) Then
                            'ペアとして登録
                            g_PairList(pairNum).nextID = SortedObj(j).index
                            For k = firstPair To pairNum
                                g_PairList(k).endID = SortedObj(j).index
                            Next k
                            Exit For
                        End If
                    Next j

                    'ペアなしフラグを立てる
                    For k = firstPair To pairNum
                        If (g_PairList(k).endID = -1) Then
                            g_ObjPairErrorFlag(g_PairList(k).ID) = 1
                        End If
                    Next k

                    '登録完了
                    pairNum += 1

                'スライド子ノーツ（スライド親ノーツに挟まれていないノーツを検出する）
                Case NOTE_TYPE.SLIDE_CHILD_NOTE
                    '登録済みかを検索
                    reg = False
                    For j = 0 To pairNum - 1
                        If (g_PairList(j).nextID = SortedObj(i).index) Then
                            reg = True
                            Exit For
                        End If
                    Next j
                    If reg Then
                        Continue For
                    End If

                    'ペアなしフラグを立てる
                    g_ObjPairErrorFlag(SortedObj(i).index) = 1
            End Select
        Next i

        '番兵の設置
        g_PairList(pairNum).ID = -1
    End Sub

	Public Function strToNum(ByRef strNum As String) As Integer

        If frmMain._mnuOptionsItem_7.Checked Then

            strToNum = strToNumFF(strNum)

        Else

            strToNum = strToNumZZ(strNum)
			
		End If
		
	End Function
	
	Public Function strToNumZZ(ByRef strNum As String) As Integer
		
		Dim i As Integer
		Dim ret As Integer
		
		For i = 1 To Len(strNum)
			
			ret = ret + subStrToNumZZ(Mid(strNum, i, 1)) * (36 ^ (Len(strNum) - i))
			
		Next i
		
		strToNumZZ = ret
		
	End Function
	
	Public Function subStrToNumZZ(ByRef b As String) As Integer
		
		Dim r As Integer
		
		r = System.Math.Abs(Asc(UCase(b)))
		
		If r >= 65 And r <= 90 Then 'A-Z
			
			subStrToNumZZ = r - 55
			
		Else
			
			subStrToNumZZ = (r - 48) Mod 36
			
		End If
		
	End Function
	
	Public Function strToNumFF(ByRef strNum As String) As Integer
		
		Dim ret As Integer
        Dim l As String = Space(1)
        Dim r As String = Space(1)

        r = UCase(Right(strNum, 1))

        If Len(strNum) > 1 Then

            l = UCase(Mid(strNum, Len(strNum) - 1, 1))

        Else

            l = "0"

        End If

        If Asc(l) <= 70 Then 'F 以下

            If Asc(r) <= 70 Then 'FF 以下

                ret = Val("&H" & l & r)

            Else 'FZ 以下

                ret = Val("&H" & l) * 20 + subStrToNumFF(r)

            End If

        Else 'ZZ

            ret = strToNumZZ(l & r)

        End If
		
		strToNumFF = ret
		
	End Function
	
	Private Function subStrToNumFF(ByRef b As String) As Integer
		
		Dim r As Integer
		
		r = Asc(b)
		
		If r >= 65 And r <= 70 Then 'A-F
			
			subStrToNumFF = r - 55
			
		ElseIf r >= 71 And r <= 90 Then 
			
			subStrToNumFF = r + 185
			
		Else
			
			subStrToNumFF = (r - 48) Mod 36
			
		End If
		
	End Function
	
	Public Function strFromNum(ByVal lngNum As Integer, Optional ByVal Length As Integer = 2) As String

        If frmMain._mnuOptionsItem_7.Checked Then

            strFromNum = strFromNumFF(lngNum, Length)

        Else

            strFromNum = strFromNumZZ(lngNum, Length)
			
		End If
		
	End Function
	
	Public Function strFromNumZZ(ByVal lngNum As Integer, Optional ByVal Length As Integer = 2) As String

        Dim strTemp As String = ""

        Do While lngNum
			
			strTemp = subStrFromNumZZ(lngNum Mod 36) & strTemp
			lngNum = lngNum \ 36
			
		Loop 
		
		Do While Len(strTemp) < Length
			
			strTemp = "0" & strTemp
			
		Loop 
		
		strFromNumZZ = Right(strTemp, Length)
		
	End Function
	
	Public Function subStrFromNumZZ(ByVal b As Integer) As String
		
		Select Case b
			
			Case 0 To 9
				
				subStrFromNumZZ = CStr(b)
				
			Case Else
				
				subStrFromNumZZ = Chr(b + 55)
				
		End Select
		
	End Function
	
	Public Function strFromNumFF(ByVal lngNum As Integer, Optional ByVal Length As Integer = 2) As String
		
		Select Case lngNum
			
			Case Is < 256
				
				strFromNumFF = Right(New String("0", Length) & Hex(lngNum), Length)
				
			Case Is < 576
				
				lngNum = lngNum - 256
				strFromNumFF = Hex(lngNum \ 20) & subStrFromNumZZ((lngNum Mod 20) + 16)
				
			Case Else
				
				strFromNumFF = strFromNumZZ(lngNum, Length)
				
		End Select
		
	End Function

    Public Function intGCD(ByVal m As Integer, ByVal n As Integer) As Integer

        If m <= 0 Or n <= 0 Then Exit Function

        If m Mod n = 0 Then

            intGCD = n

        Else

            intGCD = intGCD(n, m Mod n)

        End If

    End Function
End Module
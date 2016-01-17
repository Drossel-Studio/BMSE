Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks

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

    Public stringFont As Font

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
            If DirectCast(Me.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData Then
                lngTemp = 192 \ (DirectCast(Me.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData)
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

            .lngPosition = .lngPosition + g_Measure(.intMeasure).lngY

        End With

        oldObj = g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

        With oldObj

            .intCh = g_intVGridNum(.intCh)

            'If Not Shift And vbAltMask Then

            If DirectCast(Me.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData Then

                lngTemp = 192 \ DirectCast(Me.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData
                .lngPosition = (.lngPosition \ lngTemp) * lngTemp

            End If

            'End If

            .lngPosition = .lngPosition + g_Measure(.intMeasure).lngY

        End With

        'Y 軸固定移動
        If Shift And Keys.Shift Then

            newObj.lngPosition = oldObj.lngPosition

        End If

        '移動している？
        If newObj.intCh <> oldObj.intCh Or newObj.lngPosition <> oldObj.lngPosition Then

            '右に移動
            If newObj.intCh > oldObj.intCh Then

                For j = oldObj.intCh To newObj.intCh - 1

                    If g_VGrid(j).blnDraw = True And g_VGrid(j).intCh <> 0 Then

                        newObj.intAtt = newObj.intAtt + 1

                    End If

                Next j

            ElseIf newObj.intCh < oldObj.intCh Then  '左に移動

                For j = oldObj.intCh To newObj.intCh + 1 Step -1

                    If g_VGrid(j).blnVisible = True And g_VGrid(j).intCh <> 0 Then

                        newObj.intAtt = newObj.intAtt + 1

                    End If

                Next j

            End If

            lngTemp = newObj.intCh <> oldObj.intCh And newObj.intCh <> 0 And oldObj.intCh <> 0 And newObj.intCh <> UBound(g_VGrid) And oldObj.intCh <> UBound(g_VGrid)

            For i = 0 To UBound(g_Obj) - 1

                With g_Obj(i)

                    '選択中
                    If .intSelect = modMain.OBJ_SELECT.Selected Then

                        'Y 軸移動
                        .lngPosition = .lngPosition + newObj.lngPosition - oldObj.lngPosition

                        '小節はまたいでいないか？
                        Do While .lngPosition >= g_Measure(.intMeasure).intLen

                            If .intMeasure < 999 Then

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

            picMain.Refresh()

        End If

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "MoveObj")
    End Sub

    Public Sub PreviewBMP(ByRef strFileName As String)
        On Error GoTo Err_Renamed

        If m_blnPreview = False Then Exit Sub

        With frmWindowPreview

            If .chkLock.CheckState Then Exit Sub

            ._txtBGAPara_0.Text = strFromLong(lstBMP.SelectedIndex + 1)
            .Text = ._txtBGAPara_0.Text & ":" & strFileName

            If Mid(strFileName, 2, 2) <> ":\" Then strFileName = g_BMS.strDir & strFileName

            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
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

            Call .picPreview.Refresh()

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

            Call .picPreview.Refresh()

        End With

Err_Renamed:
    End Sub

    Private Sub PreviewWAV(ByRef strFileName As String)
        On Error GoTo Err_Renamed

        Dim lngError As Integer
        Dim strError As String = Space(256)
        Dim strTemp As String = ""

        If m_blnPreview = False Then Exit Sub

        If Mid(strFileName, 2, 2) <> ":\" Then

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

            If mciGetErrorString(lngError, strError, 256) Then

                strTemp = VB.Left(strError, InStr(strError, Chr(0)) - 1)

            Else

                strTemp = "不明なエラーです。"

            End If

            'Call modMain.DebugOutput(lngError, strTemp & Chr$(34) & strFileName & Chr$(34), "PreviewWAV", False)

        End If

        Call mciSendString("play PREVIEW notify", vbNullString, 0, Me.Handle.ToInt32)

Err_Renamed:
    End Sub

    Private Sub FormDragDrop(ByVal Data As String())
        Dim i As Integer
        Dim strArray() As String
        Dim strTemp As String
        Dim blnReadFlag As Boolean

        For i = 0 To Data.Length - 1

            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If Dir(Data(i), FileAttribute.Normal) <> vbNullString Then

                strTemp = Data(i)

                If VB.Right(UCase(strTemp), 4) = ".BMS" Or VB.Right(UCase(strTemp), 4) = ".BME" Or VB.Right(UCase(strTemp), 4) = ".BML" Or VB.Right(UCase(strTemp), 4) = ".PMS" Then

                    If modMain.intSaveCheck() Or blnReadFlag Then

                        'UPGRADE_WARNING: App プロパティ App.EXEName には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                        Call ShellExecute(0, "open", Chr(34) & g_strAppDir & My.Application.Info.AssemblyName & Chr(34), Chr(34) & strTemp & Chr(34), "", SW_SHOWNORMAL)

                    Else

                        Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                        strArray = Split(strTemp, "\")
                        g_BMS.strFileName = VB.Right(strTemp, Len(strArray(UBound(strArray))))
                        g_BMS.strDir = VB.Left(strTemp, Len(strTemp) - Len(strArray(UBound(strArray))))
                        dlgMainOpen.InitialDirectory = g_BMS.strDir
                        dlgMainSave.InitialDirectory = g_BMS.strDir
                        blnReadFlag = True

                        Call modInput.LoadBMS()
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

                If .intSelect = modMain.OBJ_SELECT.Selected Then

                    strArray(lngTemp) = Format(.intCh, "000") & .intAtt & Format(g_Measure(.intMeasure).lngY + .lngPosition - g_Measure(intTemp).lngY, "0000000") & .sngValue
                    lngTemp = lngTemp + 1

                End If

            End With

        Next i

        Call My.Computer.Clipboard.SetText("BMSE ClipBoard Object Data Format" & vbCrLf & Join(strArray, vbCrLf) & vbCrLf)

    End Sub

    Public Sub SaveChanges()

        g_BMS.blnSaveFlag = False

        Me.Text = g_strAppTitle

        If Len(g_BMS.strDir) Then

            If _mnuOptionsItem_1.Checked Then

                Me.Text = Me.Text & " - " & g_BMS.strFileName

            Else

                Me.Text = Me.Text & " - " & g_BMS.strDir & g_BMS.strFileName

            End If

        End If

        Me.Text = Me.Text & " *"

    End Sub

    Private Function strCmdDecode(ByRef strCmd As String, ByRef strFileName As String) As String

        Dim ret As String

        ret = strCmd

        ret = Replace(ret, "<filename>", Chr(34) & strFileName & Chr(34))
        ret = Replace(ret, "<measure>", g_disp.intStartMeasure)
        ret = Replace(ret, "<appdir>", g_strAppDir)

        strCmdDecode = ret

    End Function

    Public Sub RefreshList()

        Dim i As Integer
        Dim strTemp As String = Space(2)
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

            strTemp = modInput.strFromNum(i)
            lngTemp = modInput.strToNum(modInput.strFromNumZZ(i))

            modMain.SetItemString(lstWAV, i - 1, "#WAV" & strTemp & ":" & g_strWAV(i))
            modMain.SetItemString(lstBMP, i - 1, "#BMP" & strTemp & ":" & g_strBMP(i))
            modMain.SetItemString(lstBGA, i - 1, "#BGA" & strTemp & ":" & g_strBGA(i))

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

        Me.AcceptButton = cmdDirectInput

    End Sub

    Private Sub cboDirectInput_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDirectInput.Leave

        Me.AcceptButton = Nothing

    End Sub

    'UPGRADE_WARNING: イベント cboDispFrame.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboDispFrame_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispFrame.SelectedIndexChanged

        Call modDraw.InitVerticalLine()

    End Sub

    Private Sub cboDispGridMain_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispGridMain.SelectedIndexChanged

        picMain.Refresh()

    End Sub

    Private Sub cboDispGridSub_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispGridSub.SelectedIndexChanged

        picMain.Refresh()

    End Sub

    Private Sub cboDispHeight_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispHeight.SelectedIndexChanged
        Dim i As Integer
        Dim sngTemp As Single

        If Me.Visible = False Then Exit Sub

        If cboDispHeight.SelectedIndex = cboDispHeight.Items.Count - 1 Then

            With frmWindowInput

                .lblMainDisp.Text = g_Message(modMain.Message.INPUT_SIZE)
                .txtMain.Text = Format(g_disp.Height, "#0.00")
                If .txtMain.Text = "100.00" Then .txtMain.Text = "1.00"

                Call frmWindowInput.ShowDialog(Me)

                sngTemp = System.Math.Round(Val(.txtMain.Text), 2)

                If sngTemp <= 0 Then

                    sngTemp = g_disp.Height

                ElseIf sngTemp > 16 Then

                    sngTemp = 16

                End If

                For i = 0 To cboDispHeight.Items.Count - 1

                    If DirectCast(Me.cboDispHeight.Items.Item(i), modMain.ItemWithData).ItemData = sngTemp * 100 Then

                        cboDispHeight.SelectedIndex = i

                        Exit For

                    ElseIf DirectCast(Me.cboDispHeight.Items.Item(i), modMain.ItemWithData).ItemData > sngTemp * 100 Then

                        Call cboDispHeight.Items.Insert(i, New modMain.ItemWithData("x" & Format(sngTemp, "#0.00"), sngTemp * 100))
                        cboDispHeight.SelectedIndex = i

                        Exit For

                    End If

                Next i

            End With

        End If

        picMain.Refresh()

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

    Private Sub cboDispWidth_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDispWidth.SelectedIndexChanged
        Dim i As Integer
        Dim sngTemp As Single

        If Me.Visible = False Then Exit Sub

        If cboDispWidth.SelectedIndex = cboDispWidth.Items.Count - 1 Then

            With frmWindowInput

                .lblMainDisp.Text = g_Message(modMain.Message.INPUT_SIZE)
                .txtMain.Text = Format(g_disp.Width, "#0.00")
                If .txtMain.Text = "100.00" Then .txtMain.Text = "1.00"

                Call frmWindowInput.ShowDialog(Me)

                sngTemp = System.Math.Round(Val(.txtMain.Text), 2)

                If sngTemp <= 0 Then

                    sngTemp = g_disp.Width

                ElseIf sngTemp > 16 Then

                    sngTemp = 16

                End If

                For i = 0 To cboDispWidth.Items.Count - 1

                    If DirectCast(Me.cboDispWidth.Items.Item(i), modMain.ItemWithData).ItemData = sngTemp * 100 Then

                        cboDispWidth.SelectedIndex = i

                        Exit For

                    ElseIf DirectCast(Me.cboDispWidth.Items.Item(i), modMain.ItemWithData).ItemData > sngTemp * 100 Then

                        Call cboDispWidth.Items.Insert(i, New modMain.ItemWithData("x" & Format(sngTemp, "#0.00"), sngTemp * 100))
                        cboDispWidth.SelectedIndex = i

                        Exit For

                    End If

                Next i

            End With

        End If

        picMain.Refresh()

    End Sub

    'UPGRADE_WARNING: イベント cboPlayer.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub cboPlayer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPlayer.SelectedIndexChanged

        Call modDraw.InitVerticalLine()

    End Sub

    Private Sub cboVScroll_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboVScroll.SelectedIndexChanged
        Dim NewLargeChange As Short

        vsbMain.SmallChange = DirectCast(Me.cboVScroll.SelectedItem, modMain.ItemWithData).ItemData
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

                Call frmWindowPreview.Show(Me)

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

        picMain.Refresh()

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

        picMain.Refresh()

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

                        .lngPosition = (g_Measure(.intMeasure).intLen / .lngHeight) * .lngPosition

                        Select Case .intCh

                            Case modInput.OBJ_CH.CH_BPM

                                .intCh = 8

                            Case modInput.OBJ_CH.CH_KEY_INV_MIN To modInput.OBJ_CH.CH_KEY_INV_MAX '不可視

                                .intCh = .intCh - modInput.OBJ_CH.CH_INV
                                .intAtt = modMain.OBJ_ATT.OBJ_INVISIBLE

                            Case modInput.OBJ_CH.CH_KEY_LN_MIN To modInput.OBJ_CH.CH_KEY_LN_MAX 'LN

                                .intCh = .intCh - modInput.OBJ_CH.CH_LN
                                .intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE

                        End Select

                    End With

                Next i

                Call .Items.Insert(0, .Text)

                For i = 1 To .Items.Count

                    If .Text = modMain.GetItemString(cboDirectInput, i) Then

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

        Dim strTemp As String = Space(7)

        With lstBGA

            If Len(modMain.GetItemString(lstBGA, .SelectedIndex)) > 7 Then

                strTemp = "#BGA00:"

                'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then

                'Mid$(strTemp, 5, 2) = Right$("0" & Hex$(.ListIndex + 1), 2)
                'g_strBGA(strToNum(Mid$(strTemp, 5, 2))) = ""

                'Else

                'Mid$(strTemp, 5, 2) = modInput.strFromNum(.ListIndex + 1)
                'g_strBGA(.ListIndex + 1) = ""

                'End If

                Mid(strTemp, 5, 2) = strFromLong(.SelectedIndex + 1)
                g_strBGA(lngFromLong(.SelectedIndex + 1)) = ""

                modMain.SetItemString(lstBGA, .SelectedIndex, strTemp)

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

            modMain.SetItemString(lstBGA, .SelectedIndex, "#BGA" & strFromLong(.SelectedIndex + 1) & ":" & txtBGAInput.Text)
            g_strBGA(lngFromLong(.SelectedIndex + 1)) = txtBGAInput.Text

            txtBGAInput.Text = ""

            Call SaveChanges()

        End With

        With frmWindowPreview

            If .Visible Then

                Call PreviewBGA(lstBGA.SelectedIndex + 1)
                Call frmWindowPreview.Show(Me)

            End If

        End With

    End Sub

    Private Sub cmdBmpDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBMPDelete.Click

        Dim strTemp As String = Space(7)

        With lstBMP

            If Len(modMain.GetItemString(lstBMP, .SelectedIndex)) > 7 Then

                strTemp = "#BMP00:"

                Mid(strTemp, 5, 2) = strFromLong(.SelectedIndex + 1)
                g_strBMP(lngFromLong(.SelectedIndex + 1)) = ""

                modMain.SetItemString(lstBMP, .SelectedIndex, strTemp)

                Call SaveChanges()

            End If

        End With

    End Sub

    Private Sub cmdBmpLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBMPLoad.Click
        On Error GoTo Err_Renamed

        Dim strArray() As String
        'Dim strTemp     As String * 2

        With dlgMainOpen

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            .Filter = "Image files (*.bmp,*.jpg,*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*"
            .FileName = Mid(modMain.GetItemString(lstBMP, lstBMP.SelectedIndex), 8)

            If .ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            strArray = Split(.FileName, "\")

            modMain.SetItemString(lstBMP, lstBMP.SelectedIndex, "#BMP" & strFromLong(lstBMP.SelectedIndex + 1) & ":" & strArray(UBound(strArray)))
            g_strBMP(lngFromLong(lstBMP.SelectedIndex + 1)) = strArray(UBound(strArray))

            .InitialDirectory = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))

            Call SaveChanges()

        End With

        With frmWindowPreview

            If .Visible Then

                Call PreviewBMP(Mid(modMain.GetItemString(lstBMP, lstBMP.SelectedIndex), 8))
                Call frmWindowPreview.Show(Me)

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

                    modMain.SetItemString(lstMeasureLen, i, "#" & Format(i, "000") & ":" & cboNumerator.Text & "/" & cboDenominator.Text)
                    lngTemp = (192 / CDbl(cboDenominator.Text)) * CDbl(cboNumerator.Text)

                    strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.MSR_CHANGE) & modInput.strFromNum(i) & VB.Right("00" & Hex(g_Measure(i).intLen), 3) & VB.Right("00" & Hex(lngTemp), 3)
                    ReDim Preserve strArray(UBound(strArray) + 1)

                    g_Measure(i).intLen = lngTemp

                End If

            Next i

            .Visible = True

        End With

        For i = 0 To UBound(g_Obj) - 1

            tempObj = g_Obj(i)

            With tempObj

                Do While .lngPosition >= g_Measure(.intMeasure).intLen

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

        Call PreviewBMP(Mid(modMain.GetItemString(lstBMP, lstBMP.SelectedIndex), 8))

        With frmWindowPreview

            If Not .Visible Then

                'Call .SetWindowSize
                '.Left = frmMain.Left + (frmMain.Width - .Width) \ 2
                '.Top = frmMain.Top + (frmMain.Height - .Height) \ 2

                Call frmWindowPreview.Show(Me)

            Else

                Call frmWindowPreview.Close()

            End If

            Call picMain.Focus()

        End With

    End Sub

    Private Sub cmdLoadMissBMP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoadMissBMP.Click
        On Error GoTo Err_Renamed

        Dim strArray() As String

        With dlgMainOpen

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            .Filter = "Image files (*.bmp,*.jpg,*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*"
            .FileName = txtStageFile.Text

            If .ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

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

        With dlgMainOpen

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            .Filter = "Image files (*.bmp,*.jpg,*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*"
            .FileName = txtStageFile.Text

            If .ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            strArray = Split(.FileName, "\")
            txtStageFile.Text = strArray(UBound(strArray))
            dlgMainOpen.InitialDirectory = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
            dlgMainSave.InitialDirectory = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))

        End With

        Exit Sub

Err_Renamed:
    End Sub

    Private Sub cmdSoundDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSoundDelete.Click

        Dim strTemp As String = Space(7)

        Call mciSendString("close PREVIEW", vbNullString, 0, 0)

        With lstWAV

            If Len(modMain.GetItemString(lstWAV, .SelectedIndex)) > 7 Then

                strTemp = "#WAV00:"

                'If mnuOptionsItem(USE_OLD_FORMAT).Checked Then

                'Mid$(strTemp, 5, 2) = Right$("0" & Hex$(.ListIndex + 1), 2)
                'g_strWAV(strToNum(Mid$(strTemp, 5, 2))) = ""

                'Else

                'Mid$(strTemp, 5, 2) = modInput.strFromNum(.ListIndex + 1)
                'g_strWAV(.ListIndex + 1) = ""

                'End If

                Mid(strTemp, 5, 2) = strFromLong(.SelectedIndex + 1)
                g_strWAV(lngFromLong(.SelectedIndex + 1)) = ""

                modMain.SetItemString(lstWAV, .SelectedIndex, strTemp)

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

            modMain.SetItemString(lstWAV, .SelectedIndex + 1, "")
            .SelectedIndex = .SelectedIndex + 1

            modMain.SetItemString(lstWAV, .SelectedIndex, "#WAV" & strFromNum(intTemp) & ":" & g_strWAV(intTemp))
            modMain.SetItemString(lstWAV, .SelectedIndex - 1, "#WAV" & strFromNum(lngTemp) & ":" & g_strWAV(lngTemp))

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

        picMain.Refresh()

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

            modMain.SetItemString(lstWAV, .SelectedIndex - 1, "")
            .SelectedIndex = .SelectedIndex - 1

            modMain.SetItemString(lstWAV, .SelectedIndex, "#WAV" & strFromNum(intTemp) & ":" & g_strWAV(intTemp))
            modMain.SetItemString(lstWAV, .SelectedIndex + 1, "#WAV" & strFromNum(lngTemp) & ":" & g_strWAV(lngTemp))

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

        picMain.Refresh()

    End Sub

    Private Sub cmdSoundLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSoundLoad.Click
        On Error GoTo Err_Renamed

        Dim strArray() As String

        Call mciSendString("close PREVIEW", vbNullString, 0, 0)

        With dlgMainOpen

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            .Filter = "Sound files (*.wav,*.mp3)|*.wav;*.mp3|All files (*.*)|*.*"
            .FileName = Mid(modMain.GetItemString(lstWAV, lstWAV.SelectedIndex), 8)

            If .ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            dlgMainSave.FileName = dlgMainOpen.FileName

            strArray = Split(.FileName, "\")

            modMain.SetItemString(lstWAV, lstWAV.SelectedIndex, "#WAV" & strFromLong(lstWAV.SelectedIndex + 1) & ":" & strArray(UBound(strArray)))
            g_strWAV(lngFromLong(lstWAV.SelectedIndex + 1)) = strArray(UBound(strArray))

            dlgMainOpen.InitialDirectory = VB.Left(dlgMainOpen.FileName, Len(dlgMainOpen.FileName) - Len(strArray(UBound(strArray))))
            dlgMainSave.InitialDirectory = VB.Left(dlgMainOpen.FileName, Len(dlgMainOpen.FileName) - Len(strArray(UBound(strArray))))

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
        If Shift And Keys.Shift Then j = 2

        For i = 0 To j

            Select Case KeyCode

                Case System.Windows.Forms.Keys.Add '+

                    If _optChangeBottom_0.Checked = True Then

                        If lstWAV.SelectedIndex <> lstWAV.Items.Count - 1 Then

                            If Shift And Keys.Control Then

                                Call cmdSoundExcDown_Click(cmdSoundExcDown, New System.EventArgs())

                            Else

                                lstWAV.SelectedIndex = lstWAV.SelectedIndex + 1

                            End If

                        End If

                    ElseIf _optChangeBottom_1.Checked = True Or _optChangeBottom_2.Checked = True Then

                        If lstBMP.SelectedIndex <> lstBMP.Items.Count - 1 Then

                            If Shift And Keys.Control Then

                                Call cmdBMPExcDown_Click(cmdBMPExcDown, New System.EventArgs())

                            Else

                                lstBMP.SelectedIndex = lstBMP.SelectedIndex + 1
                                lstBGA.SelectedIndex = lstBMP.SelectedIndex

                            End If

                        End If

                    End If

                    Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)
                    picMain.Refresh()

                Case System.Windows.Forms.Keys.Subtract '-

                    If _optChangeBottom_0.Checked = True Then

                        If lstWAV.SelectedIndex <> 0 Then

                            If Shift And Keys.Control Then

                                Call cmdSoundExcUp_Click(cmdSoundExcUp, New System.EventArgs())

                            Else

                                lstWAV.SelectedIndex = lstWAV.SelectedIndex - 1

                            End If

                        End If

                    ElseIf _optChangeBottom_1.Checked = True Or _optChangeBottom_2.Checked = True Then

                        If lstBMP.SelectedIndex <> 0 Then

                            If Shift And Keys.Control Then

                                Call cmdBMPExcUp_Click(cmdBMPExcUp, New System.EventArgs())

                            Else

                                lstBMP.SelectedIndex = lstBMP.SelectedIndex - 1
                                lstBGA.SelectedIndex = lstBGA.SelectedIndex - 1

                            End If

                        End If

                    End If

                    Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, Shift)
                    picMain.Refresh()

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
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("x0.5", 50))
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("x1.0", 100))
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("x1.5", 150))
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("x2.0", 200))
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("x2.5", 250))
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("x3.0", 300))
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("x3.5", 350))
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("x4.0", 400))
        Me.cboDispHeight.Items.Add(New modMain.ItemWithData("...", 10000))
        Me.cboDispHeight.SelectedIndex = 0

        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("x0.5", 50))
        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("x1.0", 100))
        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("x1.5", 150))
        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("x2.0", 200))
        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("x2.5", 250))
        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("x3.0", 300))
        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("x3.5", 350))
        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("x4.0", 400))
        Me.cboDispWidth.Items.Add(New modMain.ItemWithData("...", 10000))
        Me.cboDispWidth.SelectedIndex = 0

        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("2", 2))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("4", 4))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("8", 8))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("16", 16))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("32", 32))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("64", 64))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("3", 3))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("6", 6))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("12", 12))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("24", 24))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("48", 48))
        Me.cboDispGridMain.Items.Add(New modMain.ItemWithData("NONE", 0))
        Me.cboDispGridMain.SelectedIndex = 0

        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("4", 4))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("8", 8))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("16", 16))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("32", 32))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("64", 64))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("3", 3))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("6", 6))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("12", 12))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("24", 24))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("48", 48))
        Me.cboDispGridSub.Items.Add(New modMain.ItemWithData("FREE", 0))
        Me.cboDispGridSub.SelectedIndex = 0

        Me.cboVScroll.Items.Add(New modMain.ItemWithData("1", 1))

        stringFont = Font

        Dim NewLargeChange As Short

        Dim i As Integer
        Dim wp As WINDOWPLACEMENT

        Call modMain.StartUp()

        AddHandler picMain.Paint, AddressOf picMain_Paint
        AddHandler Me.Resize, AddressOf frmMain_Resize

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

        g_disp.lngMaxY = vsbMain.Minimum
        g_disp.lngMaxX = hsbMain.Minimum

        hsbMain.SmallChange = OBJ_WIDTH
        NewLargeChange = OBJ_WIDTH * 4
        hsbMain.Maximum = hsbMain.Maximum + NewLargeChange - hsbMain.LargeChange
        hsbMain.LargeChange = NewLargeChange

        cboPlayer.SelectedIndex = g_BMS.intPlayerType - 1
        cboPlayLevel.Text = g_BMS.lngPlayLevel
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

            Call lstMeasureLen.Items.Insert(i, "#" & Format(i, "000") & ":4/4")
            g_Measure(i).intLen = 192

        Next i

        lstWAV.SelectedIndex = 0
        lstBMP.SelectedIndex = 0
        lstBGA.SelectedIndex = 0

        _fraTop_0.Top = 0
        _fraTop_0.Left = 0
        _fraTop_1.Top = 0
        _fraTop_1.Left = 0
        _fraTop_2.Top = 0
        _fraTop_2.Left = 0


        _fraTop_0.Visible = True
        _optChangeTop_0.Checked = True

        _fraBottom_0.Top = 0
        _fraBottom_0.Left = 0
        _fraBottom_1.Top = 0
        _fraBottom_1.Left = 0
        _fraBottom_2.Top = 0
        _fraBottom_2.Left = 0
        _fraBottom_3.Top = 0
        _fraBottom_3.Left = 0

        _fraBottom_0.Visible = True
        _optChangeBottom_0.Checked = True

        For i = 1 To 64

            Call cboNumerator.Items.Insert(i - 1, CStr(i))

        Next i

        cboNumerator.SelectedIndex = 3
        cboDenominator.SelectedIndex = 0

        lstMeasureLen.SelectedIndex = 0

        m_blnPreview = True

        If strGet_ini("EasterEgg", "Tips", 0, "bmse.ini") Then

            With frmWindowTips

                .Left = Me.Left + (Me.Width - .Width) \ 2
                .Top = Me.Top + (Me.Height - .Height) \ 2

                Call frmWindowTips.ShowDialog(Me)

            End With

        End If

        wp.Length = 44
        Call GetWindowPlacement(Me.Handle.ToInt32, wp)
        wp.showCmd = strGet_ini("Main", "State", SW_SHOW, "bmse.ini")
        Call SetWindowPlacement(Me.Handle.ToInt32, wp)

        Call GetCmdLine()

        Call frmMain_Resize(Me, New EventArgs)
        vsbMain.Value = vsbMain.Maximum - vsbMain.LargeChange + 1

    End Sub

    Private Sub frmMain_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub frmMain_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Call FormDragDrop(CType(e.Data.GetData(DataFormats.FileDrop), String()))
    End Sub

    Private Sub frmMain_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        If modMain.intSaveCheck() Then

            Cancel = True

        Else

            RemoveHandler picMain.Paint, AddressOf picMain_Paint
            Call modMain.CleanUp()

        End If

        eventArgs.Cancel = Cancel
    End Sub

    Public Sub frmMain_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error Resume Next

        Dim i As Integer
        Dim lngTemp As Integer

        Dim lngLineWidth As Integer
        Dim lngLineHeight As Integer
        Dim lngToolBarHeight As Integer
        Dim lngDirectInputHeight As Integer
        Dim lngStatusBarHeight As Integer

        Const PADDING_Renamed As Short = 4 '各パディングの大きさ
        Const SCROLLBAR_SIZE As Short = 17 'スクロールバーの大きさ
        Const COLUMN_HEIGHT As Short = 21 '各カラムの高さ
        Const FRAME_WIDTH As Short = 217 'フレームの幅
        Const FRAME_TOP_HEIGHT As Short = 146 'ヘッダフレームの高さ
        Const FRAME_BOTTOM_TOP As Short = 42 'ボトムフレームのY位置。タブボタンの大きさ
        Const FRAME_BOTTOM_BUTTONS_HEIGHT As Short = COLUMN_HEIGHT '消去とか入力とかのボタン

        With Me

            If .WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub

            lngLineWidth = 2
            lngLineHeight = 2
            If _mnuViewItem_0.Checked Then lngToolBarHeight = tlbMenu.Height
            If _mnuViewItem_1.Checked Then lngDirectInputHeight = COLUMN_HEIGHT + PADDING_Renamed * 2
            If _mnuViewItem_2.Checked Then lngStatusBarHeight = staMain.Height + 2

            staMain.Visible = _mnuViewItem_2.Checked

            _linToolbarBottom_0.X1 = 0
            _linToolbarBottom_0.X2 = .ClientRectangle.Width
            _linToolbarBottom_0.Y1 = lngToolBarHeight
            _linToolbarBottom_0.Y2 = _linToolbarBottom_0.Y1
            _linToolbarBottom_1.X1 = 0
            _linToolbarBottom_1.X2 = .ClientRectangle.Width
            _linToolbarBottom_1.Y1 = _linToolbarBottom_0.Y1 + 1
            _linToolbarBottom_1.Y2 = _linToolbarBottom_0.Y2 + 1

            _linVertical_0.X1 = .ClientRectangle.Width - FRAME_WIDTH - PADDING_Renamed - lngLineWidth
            _linVertical_0.X2 = _linVertical_0.X1
            _linVertical_1.X1 = _linVertical_0.X1 + 1
            _linVertical_1.X2 = _linVertical_1.X1

            _linVertical_0.Y1 = lngToolBarHeight
            _linVertical_0.Y2 = .ClientRectangle.Height - lngStatusBarHeight
            _linVertical_1.Y1 = _linVertical_0.Y1
            _linVertical_1.Y2 = _linVertical_0.Y2

            _linHeader_0.X1 = _linHeader_0.X1
            _linHeader_0.X2 = .ClientRectangle.Width
            _linHeader_0.Y1 = lngToolBarHeight + PADDING_Renamed + FRAME_TOP_HEIGHT + PADDING_Renamed
            _linHeader_0.Y2 = _linHeader_0.Y1
            _linHeader_1.X1 = _linHeader_0.X1
            _linHeader_1.X2 = _linHeader_0.X2
            _linHeader_1.Y1 = _linHeader_0.Y1 + 1
            _linHeader_1.Y2 = _linHeader_0.Y2 + 1

            _linDirectInput_0.X1 = 0
            _linDirectInput_0.X2 = _linVertical_0.X1
            _linDirectInput_0.Y1 = .ClientRectangle.Height - lngStatusBarHeight - PADDING_Renamed - COLUMN_HEIGHT - PADDING_Renamed
            _linDirectInput_0.Y2 = _linDirectInput_0.Y1
            _linDirectInput_1.X1 = _linDirectInput_0.X1
            _linDirectInput_1.X2 = _linDirectInput_0.X2
            _linDirectInput_1.Y1 = _linDirectInput_0.Y1 + 1
            _linDirectInput_1.Y2 = _linDirectInput_0.Y2 + 1

            _linStatusBar_0.X1 = 0
            _linStatusBar_0.X2 = .ClientRectangle.Width
            _linStatusBar_0.Y1 = .ClientRectangle.Height - lngStatusBarHeight
            _linStatusBar_0.Y2 = .ClientRectangle.Height - lngStatusBarHeight
            _linStatusBar_1.X1 = _linStatusBar_0.X1
            _linStatusBar_1.X2 = _linStatusBar_0.X2
            _linStatusBar_1.Y1 = _linStatusBar_0.Y1 + 1
            _linStatusBar_1.Y2 = _linStatusBar_0.Y2 + 1

            _linStatusBar_0.Visible = _mnuViewItem_2.Checked
            _linStatusBar_1.Visible = _mnuViewItem_2.Checked

            tlbMenu.Visible = _mnuViewItem_0.Checked
            fraViewer.Visible = _mnuViewItem_0.Checked
            fraGrid.Visible = _mnuViewItem_0.Checked
            fraDispSize.Visible = _mnuViewItem_0.Checked

            lngTemp = .ClientRectangle.Width - FRAME_WIDTH - PADDING_Renamed - lngLineWidth - PADDING_Renamed - SCROLLBAR_SIZE

            Call vsbMain.SetBounds(lngTemp, MainMenu1.Height + lngToolBarHeight + PADDING_Renamed, SCROLLBAR_SIZE, .ClientRectangle.Height - MainMenu1.Height - lngToolBarHeight - PADDING_Renamed - lngStatusBarHeight - lngDirectInputHeight - SCROLLBAR_SIZE - PADDING_Renamed)

            Call hsbMain.SetBounds(0, .ClientRectangle.Height - lngStatusBarHeight - lngDirectInputHeight - SCROLLBAR_SIZE - PADDING_Renamed, lngTemp, SCROLLBAR_SIZE)

            Call picMain.SetBounds(0, MainMenu1.Height + lngToolBarHeight + PADDING_Renamed, lngTemp, .ClientRectangle.Height - MainMenu1.Height - lngToolBarHeight - PADDING_Renamed - lngStatusBarHeight - lngDirectInputHeight - SCROLLBAR_SIZE - PADDING_Renamed)

            _linDirectInput_0.Visible = _mnuViewItem_1.Checked
            _linDirectInput_1.Visible = _mnuViewItem_1.Checked
            lblDirectInput.Visible = _mnuViewItem_1.Checked
            cboDirectInput.Visible = _mnuViewItem_1.Checked
            cmdDirectInput.Visible = _mnuViewItem_1.Checked

            Call lblDirectInput.SetBounds(PADDING_Renamed, .ClientRectangle.Height - lngStatusBarHeight - PADDING_Renamed - (COLUMN_HEIGHT + lblDirectInput.Height) \ 2, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)

            Call cmdDirectInput.SetBounds(.ClientRectangle.Width - FRAME_WIDTH - cmdDirectInput.Width - PADDING_Renamed * 2 - lngLineWidth, .ClientRectangle.Height - lngStatusBarHeight - PADDING_Renamed - cmdDirectInput.Height, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)

            Call cboDirectInput.SetBounds(lblDirectInput.Left + lblDirectInput.Width + PADDING_Renamed, .ClientRectangle.Height - lngStatusBarHeight - PADDING_Renamed - (COLUMN_HEIGHT + cboDirectInput.Height) \ 2, cmdDirectInput.Left - lblDirectInput.Width - PADDING_Renamed * 3, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)

            With tlbMenu.Items.Item("Viewer")
                .Width = fraViewer.Width
                Call fraViewer.SetBounds(.Bounds.Left + PADDING_Renamed, .Bounds.Top + MainMenu1.Height + PADDING_Renamed, .Width, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
                Call fraViewer.BringToFront()
            End With

            With tlbMenu.Items.Item("ChangeGrid")
                lblGridMain.Left = PADDING_Renamed
                cboDispGridSub.Left = lblGridMain.Left + lblGridMain.Width + PADDING_Renamed
                lblGridSub.Left = cboDispGridSub.Left + cboDispGridSub.Width + PADDING_Renamed * 3
                cboDispGridMain.Left = lblGridSub.Left + lblGridSub.Width + PADDING_Renamed
                fraGrid.Width = cboDispGridMain.Left + cboDispGridMain.Width + PADDING_Renamed
                .Width = fraGrid.Width
                Call fraGrid.SetBounds(.Bounds.Left, .Bounds.Top + MainMenu1.Height + PADDING_Renamed, .Width, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
                Call fraGrid.BringToFront()
            End With

            With tlbMenu.Items.Item("DispSize")
                lblDispHeight.Left = PADDING_Renamed
                cboDispHeight.Left = lblDispHeight.Left + lblDispHeight.Width + PADDING_Renamed
                lblDispWidth.Left = cboDispHeight.Left + cboDispHeight.Width + PADDING_Renamed * 3
                cboDispWidth.Left = lblDispWidth.Left + lblDispWidth.Width + PADDING_Renamed
                fraDispSize.Width = cboDispWidth.Left + cboDispWidth.Width + PADDING_Renamed
                .Width = fraDispSize.Width
                Call fraDispSize.SetBounds(.Bounds.Left, .Bounds.Top + MainMenu1.Height + PADDING_Renamed, .Width, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
                Call fraDispSize.BringToFront()
            End With

            With tlbMenu.Items.Item("Resolution")
                lblVScroll.Left = PADDING_Renamed
                cboVScroll.Left = lblVScroll.Left + lblVScroll.Width + PADDING_Renamed
                fraResolution.Width = cboVScroll.Left + cboVScroll.Width + PADDING_Renamed
                Call fraResolution.SetBounds(.Bounds.Left, .Bounds.Top + MainMenu1.Height + PADDING_Renamed, .Width, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
                Call fraResolution.BringToFront()
            End With

            Call .picMain.Focus()

        End With

        With fraHeader

            Call fraHeader.SetBounds(Me.ClientRectangle.Width - FRAME_WIDTH, lngToolBarHeight + PADDING_Renamed, FRAME_WIDTH, FRAME_TOP_HEIGHT)

            _fraTop_0.Top = COLUMN_HEIGHT
            _fraTop_1.Top = COLUMN_HEIGHT
            _fraTop_2.Top = COLUMN_HEIGHT

        End With

        With fraMaterial

            Call fraMaterial.SetBounds(Me.ClientRectangle.Width - FRAME_WIDTH, FRAME_TOP_HEIGHT + PADDING_Renamed + lngLineHeight + PADDING_Renamed + lngToolBarHeight + PADDING_Renamed, FRAME_WIDTH, Me.ClientRectangle.Height - lngToolBarHeight - PADDING_Renamed - fraHeader.Height - lngLineHeight - PADDING_Renamed - lngStatusBarHeight - PADDING_Renamed)

            lngTemp = .Height - FRAME_BOTTOM_TOP

            Call _fraBottom_0.SetBounds(0, FRAME_BOTTOM_TOP, FRAME_WIDTH, lngTemp)
            Call _fraBottom_1.SetBounds(0, FRAME_BOTTOM_TOP, FRAME_WIDTH, lngTemp)
            Call _fraBottom_2.SetBounds(0, FRAME_BOTTOM_TOP, FRAME_WIDTH, lngTemp)
            Call _fraBottom_3.SetBounds(0, FRAME_BOTTOM_TOP, FRAME_WIDTH, lngTemp)
            Call _fraBottom_4.SetBounds(0, FRAME_BOTTOM_TOP, FRAME_WIDTH, lngTemp)

            lngTemp = .Height - FRAME_BOTTOM_BUTTONS_HEIGHT - FRAME_BOTTOM_TOP - PADDING_Renamed * 4
            lstWAV.Height = lngTemp
            lstBMP.Height = lngTemp
            lstMeasureLen.Height = lngTemp
            txtBGAInput.Top = .Height - txtBGAInput.Height - FRAME_BOTTOM_BUTTONS_HEIGHT - FRAME_BOTTOM_TOP - PADDING_Renamed * 2
            lstBGA.Height = lngTemp - txtBGAInput.Height - PADDING_Renamed
            txtExInfo.Height = .Height - FRAME_BOTTOM_TOP - PADDING_Renamed * 3

            lngTemp = _fraBottom_0.Height - COLUMN_HEIGHT - PADDING_Renamed
            cmdSoundStop.Top = lngTemp
            cmdSoundExcUp.Top = lngTemp
            cmdSoundExcDown.Top = lngTemp
            cmdSoundDelete.Top = lngTemp
            cmdSoundLoad.Top = lngTemp
            cmdBMPPreview.Top = lngTemp
            cmdBMPExcUp.Top = lngTemp
            cmdBMPExcDown.Top = lngTemp
            cmdBMPDelete.Top = lngTemp
            cmdBMPLoad.Top = lngTemp
            cmdBGAPreview.Top = lngTemp
            cmdBGAExcUp.Top = lngTemp
            cmdBGAExcDown.Top = lngTemp
            cmdBGADelete.Top = lngTemp
            cmdBGASet.Top = lngTemp
            cmdMeasureSelectAll.Top = lngTemp
            cboNumerator.Top = lngTemp
            cboDenominator.Top = lngTemp
            lblFraction.Top = lngTemp
            cmdInputMeasureLen.Top = lngTemp

        End With

        Call modDraw.InitVerticalLine()
    End Sub

    'UPGRADE_WARNING: HScrollBar イベント hsbMain.Change には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    Private Sub hsbMain_Change(ByVal newScrollValue As Integer)

        With g_disp

            .X = newScrollValue

        End With

        picMain.Refresh()

        'Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)
        'スクロール＆オブジェ移動実現のため

    End Sub

    Private Sub hsbMain_Scroll_Renamed(ByVal newScrollValue As Integer)

        Call hsbMain_Change(newScrollValue)

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

        txtBGAInput.Text = Mid(modMain.GetItemString(lstBGA, lstBGA.SelectedIndex), 8)

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

            Call PreviewBMP(Mid(modMain.GetItemString(lstBMP, lstBMP.SelectedIndex), 8))

        End If

    End Sub

    Private Sub lstBMP_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBMP.DoubleClick

        Call cmdBmpLoad_Click(cmdBMPLoad, New System.EventArgs())

    End Sub

    Private Sub lstBMP_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lstBMP.MouseDown
        If eventArgs.Button = Windows.Forms.MouseButtons.Right Then

            mnuContextList.Show(Me, eventArgs.X, eventArgs.Y)

        End If

    End Sub

    Private Sub lstBMP_DragEnter(sender As Object, e As DragEventArgs) Handles lstBMP.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstBMP_DragDrop(sender As Object, e As DragEventArgs) Handles lstBMP.DragDrop
        Dim i As Integer
        Dim j As Integer
        Dim strTemp As String
        Dim strArray() As String

        With lstBMP

            j = .SelectedIndex
            .Visible = False

            For i = 0 To CType(e.Data.GetData(DataFormats.FileDrop), String()).Length - 1

                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(CType(e.Data.GetData(DataFormats.FileDrop), String())(i), FileAttribute.Normal) <> vbNullString Then

                    strTemp = CType(e.Data.GetData(DataFormats.FileDrop), String())(i)

                    'If Right$(UCase$(strTemp), 4) = ".BMP" Or Right$(UCase$(strTemp), 4) = ".JPG" Or Right$(UCase$(strTemp), 4) = ".GIF" Then

                    Do Until Len(modMain.GetItemString(lstBMP, j)) < 8

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

                    modMain.SetItemString(lstBMP, j, "#BMP" & strFromLong(j + 1) & ":" & strArray(UBound(strArray)))
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

        strArray = Split(Mid(modMain.GetItemString(lstMeasureLen, lstMeasureLen.SelectedIndex), 6), "/")

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

        strTemp = Mid(modMain.GetItemString(lstWAV, lstWAV.SelectedIndex), 8)

        If strTemp = "" Then Exit Sub
        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If Dir(g_BMS.strDir & strTemp) = vbNullString Then Exit Sub

        Call PreviewWAV(strTemp)

    End Sub

    Private Sub lstWAV_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstWAV.DoubleClick

        Call cmdSoundLoad_Click(cmdSoundLoad, New System.EventArgs())

    End Sub

    Private Sub lstWAV_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lstWAV.MouseDown
        If eventArgs.Button = Windows.Forms.MouseButtons.Right Then

            mnuContextList.Show(Me, eventArgs.X, eventArgs.Y)

        End If

    End Sub

    Private Sub lstWAV_DragEnter(sender As Object, e As DragEventArgs) Handles lstWAV.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstWAV_DragDrop(sender As Object, e As DragEventArgs) Handles lstWAV.DragDrop
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim j As Integer
        Dim strTemp As String
        Dim strArray() As String

        With lstWAV

            j = .SelectedIndex
            .Visible = False

            For i = 0 To CType(e.Data.GetData(DataFormats.FileDrop), String()).Length - 1

                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(CType(e.Data.GetData(DataFormats.FileDrop), String())(i), FileAttribute.Normal) <> vbNullString Then

                    strTemp = CType(e.Data.GetData(DataFormats.FileDrop), String())(i)

                    'If Right$(UCase$(strTemp), 4) = ".WAV" Or Right$(UCase$(strTemp), 4) = ".MP3" Then

                    Do Until Len(modMain.GetItemString(lstWAV, j)) < 8

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

                    modMain.SetItemString(lstWAV, j, "#WAV" & strFromLong(j + 1) & ":" & strArray(UBound(strArray)))
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
        Call modMain.CleanUp(Err.Number, Err.Description, "lstWAV_OLEDragDrop")
    End Sub

    Public Sub mnuContextDeleteMeasure_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextDeleteMeasure.Click
        Dim i As Integer
        Dim intTemp As Short
        Dim strArray() As String

        For i = 0 To 999

            'If g_Measure(i).lngY >= g_disp.Y + picMain.ScaleHeight - g_Mouse.Y - 6 Then
            If g_Measure(i).lngY >= g_disp.Y + (picMain.ClientRectangle.Height - g_Mouse.Y) / g_disp.Height - 1 Then

                intTemp = i - 1

                Exit For

            End If

        Next i

        ReDim strArray(0)

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

                .intLen = g_Measure(i + 1).intLen
                modMain.SetItemString(lstMeasureLen, i, VB.Left(modMain.GetItemString(lstMeasureLen, i), 5) & Mid(modMain.GetItemString(lstMeasureLen, i + 1), 6))

            End With

        Next i

        modMain.SetItemString(lstMeasureLen, 999, "#999:4/4")
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
                If .lngY < g_disp.Y + (picMain.ClientRectangle.Height - g_Mouse.Y) / g_disp.Height - 1 Then

                    modMain.SetItemString(lstMeasureLen, i, "#" & Format(i, "000") & ":4/4")
                    .intLen = 192
                    intTemp = i

                    Exit For

                End If

                modMain.SetItemString(lstMeasureLen, i, VB.Left(modMain.GetItemString(lstMeasureLen, i), 5) & Mid(modMain.GetItemString(lstMeasureLen, i - 1), 6))
                .intLen = g_Measure(i - 1).intLen

            End With

        Next i

        ReDim strArray(0)

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
                strTemp = Mid(modMain.GetItemString(lstWAV, .SelectedIndex), 8)

                If Len(modMain.GetItemString(lstWAV, .SelectedIndex)) > 8 Then

                    'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                    If Dir(g_BMS.strDir & strTemp, FileAttribute.Normal) <> vbNullString Then

                        With frmWindowInput

                            .lblMainDisp.Text = g_Message(modMain.Message.INPUT_RENAME)
                            .txtMain.Text = strTemp

                            Call frmWindowInput.ShowDialog(Me)

                        End With

                        If strTemp <> frmWindowInput.txtMain.Text And Len(frmWindowInput.txtMain.Text) <> 0 Then

                            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                            If Dir(g_BMS.strDir & frmWindowInput.txtMain.Text, FileAttribute.Normal) = vbNullString Then

                                Rename(g_BMS.strDir & strTemp, g_BMS.strDir & frmWindowInput.txtMain.Text)

                                modMain.SetItemString(lstWAV, .SelectedIndex, VB.Left(modMain.GetItemString(lstWAV, .SelectedIndex), 7) & frmWindowInput.txtMain.Text)
                                g_strWAV(lngFromLong(.SelectedIndex + 1)) = frmWindowInput.txtMain.Text

                            Else

                                Call MsgBox(g_Message(modMain.Message.ERR_FILE_ALREADY_EXIST), MsgBoxStyle.Critical, g_strAppTitle)

                            End If

                        End If

                    Else

                        Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & g_BMS.strDir & strTemp, MsgBoxStyle.Critical, g_strAppTitle)

                    End If

                End If

            End With

        ElseIf _optChangeBottom_1.Checked Then

            With lstBMP

                strTemp = Mid(modMain.GetItemString(lstBMP, .SelectedIndex), 8)

                If Len(modMain.GetItemString(lstBMP, .SelectedIndex)) > 8 Then

                    'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                    If Dir(g_BMS.strDir & strTemp, FileAttribute.Normal) <> vbNullString Then

                        With frmWindowInput

                            .lblMainDisp.Text = g_Message(modMain.Message.INPUT_RENAME)
                            .txtMain.Text = strTemp

                            Call frmWindowInput.ShowDialog(Me)

                        End With

                        If strTemp <> frmWindowInput.txtMain.Text And Len(frmWindowInput.txtMain.Text) <> 0 Then

                            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                            If Dir(g_BMS.strDir & frmWindowInput.txtMain.Text, FileAttribute.Normal) = vbNullString Then

                                Rename(g_BMS.strDir & strTemp, g_BMS.strDir & frmWindowInput.txtMain.Text)

                                modMain.SetItemString(lstBMP, .SelectedIndex, VB.Left(modMain.GetItemString(lstBMP, .SelectedIndex), 7) & frmWindowInput.txtMain.Text)
                                g_strBMP(lngFromLong(.SelectedIndex + 1)) = frmWindowInput.txtMain.Text

                            Else

                                Call MsgBox(g_Message(modMain.Message.ERR_FILE_ALREADY_EXIST), MsgBoxStyle.Critical, g_strAppTitle)

                            End If

                        End If

                    Else

                        Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & g_BMS.strDir & strTemp, MsgBoxStyle.Critical, g_strAppTitle)

                    End If

                End If

            End With

        End If

    End Sub

    Public Sub mnuContextPlay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextPlay.Click

        Dim lngTemp As Short

        lngTemp = g_disp.intStartMeasure
        g_disp.intStartMeasure = g_Mouse.measure

        Call mnuToolsPlay_Click(mnuToolsPlay, New System.EventArgs())

        g_disp.intStartMeasure = lngTemp

    End Sub

    Public Sub mnuContextPlayAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuContextPlayAll.Click

        Call mnuToolsPlayAll_Click(mnuToolsPlayAll, New System.EventArgs())

    End Sub

    Public Sub mnuEditFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditFind.Click

        With frmWindowFind

            If Not .Visible Then

                .Left = Me.Left + (Me.Width - .Width) \ 2
                .Top = Me.Top + (Me.Height - .Height) \ 2

            End If

            Call frmWindowFind.Show(Me)

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

            Call SendMessage(ActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), System.Windows.Forms.ComboBox).DropDownStyle = 0 Then

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
                    g_Obj(UBound(g_Obj) - 1) = modLog.decAdd(strArray(i), UBound(g_Obj) - 1)
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
                        .intSelect = modMain.OBJ_SELECT.Selected

                    End With

                Case modMain.CMD_LOG.MSR_ADD

                    lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '

                    For j = 999 To lngTemp + 1 Step -1

                        g_Measure(j).intLen = g_Measure(j - 1).intLen
                        modMain.SetItemString(lstMeasureLen, j, VB.Left(modMain.GetItemString(lstMeasureLen, j), 5) & Mid(modMain.GetItemString(lstMeasureLen, j - 1), 6))

                    Next j

                    g_Measure(lngTemp).intLen = 192
                    modMain.SetItemString(lstMeasureLen, lngTemp, VB.Left(modMain.GetItemString(lstMeasureLen, lngTemp), 5) & "4/4")

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

                        g_Measure(j).intLen = g_Measure(j + 1).intLen
                        modMain.SetItemString(lstMeasureLen, j, VB.Left(modMain.GetItemString(lstMeasureLen, j), 5) & Mid(modMain.GetItemString(lstMeasureLen, j + 1), 6))

                    Next j

                    g_Measure(999).intLen = 192
                    modMain.SetItemString(lstMeasureLen, 999, "#999:4/4")

                    For j = 0 To UBound(g_Obj) - 1

                        With g_Obj(j)

                            If .intMeasure >= lngTemp Then

                                .intMeasure = .intMeasure - 1

                            End If

                        End With

                    Next j

                Case modMain.CMD_LOG.MSR_CHANGE

                    lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '

                    g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 8, 3)) '

                    intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
                    If intTemp <= 2 Then intTemp = 3
                    If intTemp >= 48 Then intTemp = 48
                    modMain.SetItemString(lstMeasureLen, lngTemp, VB.Left(modMain.GetItemString(lstMeasureLen, lngTemp), 5) & (g_Measure(lngTemp).intLen / intTemp) & "/" & (192 \ intTemp))

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

            Call SendMessage(ActiveControl().Handle.ToInt32, WM_UNDO, 0, 0)

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), ComboBox).DropDownStyle = 0 Then

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
                        .intSelect = modMain.OBJ_SELECT.Selected

                    End With

                Case modMain.CMD_LOG.OBJ_MOVE

                    With g_Obj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))) '

                        .intCh = Val("&H" & Mid(strArray(i), 7, 2)) '
                        .intMeasure = modInput.strToNum(Mid(strArray(i), 9, 2)) '
                        .lngPosition = modInput.strToNum(Mid(strArray(i), 11, 3)) '
                        .intSelect = modMain.OBJ_SELECT.Selected

                    End With

                Case modMain.CMD_LOG.OBJ_CHANGE

                    With g_Obj(g_lngObjID(modInput.strToNum(Mid(strArray(i), 3, 4)))) '

                        .sngValue = modInput.strToNum(Mid(strArray(i), 7, 2)) '
                        .intSelect = modMain.OBJ_SELECT.Selected

                    End With

                Case modMain.CMD_LOG.MSR_ADD

                    lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '

                    For j = lngTemp To 998

                        g_Measure(j).intLen = g_Measure(j + 1).intLen
                        modMain.SetItemString(lstMeasureLen, j, VB.Left(modMain.GetItemString(lstMeasureLen, j), 5) & Mid(modMain.GetItemString(lstMeasureLen, j + 1), 6))

                    Next j

                    g_Measure(999).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '

                    intTemp = intGCD(g_Measure(999).intLen, 192)
                    If intTemp <= 2 Then intTemp = 3
                    If intTemp >= 48 Then intTemp = 48
                    modMain.SetItemString(lstMeasureLen, 999, "#999:" & (g_Measure(999).intLen / intTemp) & "/" & (192 \ intTemp))

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

                        g_Measure(j).intLen = g_Measure(j - 1).intLen
                        modMain.SetItemString(lstMeasureLen, j, VB.Left(modMain.GetItemString(lstMeasureLen, j), 5) & Mid(modMain.GetItemString(lstMeasureLen, j - 1), 6))

                    Next j

                    g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '

                    intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
                    If intTemp <= 2 Then intTemp = 3
                    If intTemp >= 48 Then intTemp = 48
                    modMain.SetItemString(lstMeasureLen, lngTemp, VB.Left(modMain.GetItemString(lstMeasureLen, lngTemp), 5) & (g_Measure(lngTemp).intLen / intTemp) & "/" & (192 \ intTemp))

                    For j = 0 To UBound(g_Obj) - 1

                        With g_Obj(j)

                            If .intMeasure >= lngTemp Then

                                .intMeasure = .intMeasure + 1

                            End If

                        End With

                    Next j

                Case modMain.CMD_LOG.MSR_CHANGE

                    lngTemp = modInput.strToNum(Mid(strArray(i), 3, 2)) '

                    g_Measure(lngTemp).intLen = Val("&H" & Mid(strArray(i), 5, 3)) '

                    intTemp = intGCD(g_Measure(lngTemp).intLen, 192)
                    If intTemp <= 2 Then intTemp = 3
                    If intTemp >= 48 Then intTemp = 48
                    modMain.SetItemString(lstMeasureLen, lngTemp, VB.Left(modMain.GetItemString(lstMeasureLen, lngTemp), 5) & (g_Measure(lngTemp).intLen / intTemp) & "/" & (192 \ intTemp))

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

            .Left = Me.Left + (Me.Width - .Width) \ 2
            .Top = Me.Top + (Me.Height - .Height) \ 2

        End With

        Call frmWindowConvert.ShowDialog(Me)

    End Sub

    Public Sub mnuFileOpenDirectory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpenDirectory.Click

        If Len(g_BMS.strDir) Then

            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If Len(g_strFiler) <> 0 And Dir(g_strFiler) <> vbNullString Then '指定したファイラを使用

                Call ShellExecute(Me.Handle.ToInt32, "open", Chr(34) & g_strFiler & Chr(34), Chr(34) & g_BMS.strDir & Chr(34), "", SW_SHOWNORMAL)

            Else 'Explorer で開く

                Call ShellExecute(Me.Handle.ToInt32, "Explore", Chr(34) & g_BMS.strDir & Chr(34), "", "", SW_SHOWNORMAL)

            End If

        End If

    End Sub

    Public Sub mnuHelpAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpAbout.Click

        With frmWindowAbout

            .Left = (Me.Left + Me.Width \ 2) - .Width \ 2
            .Top = (Me.Top + Me.Height \ 2) - .Height \ 2

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

                If Len(g_BMS.strDir) Then

                    If _mnuOptionsItem_1.Checked Then

                        Me.Text = Me.Text & " - " & g_BMS.strFileName

                    Else

                        Me.Text = Me.Text & " - " & g_BMS.strDir & g_BMS.strFileName

                    End If

                End If

                If Not g_BMS.blnSaveFlag Then Me.Text = Me.Text & " *"

            Case _mnuOptionsItem_2.Name
                _mnuOptionsItem_2.Checked = Not _mnuOptionsItem_2.Checked
                picMain.Refresh()

            Case _mnuOptionsItem_3.Name
                _mnuOptionsItem_3.Checked = Not _mnuOptionsItem_3.Checked
                picMain.Refresh()

            Case _mnuOptionsItem_4.Name
                _mnuOptionsItem_4.Checked = Not _mnuOptionsItem_4.Checked

            Case _mnuOptionsItem_5.Name
                _mnuOptionsItem_5.Checked = Not _mnuOptionsItem_5.Checked

            Case _mnuOptionsItem_6.Name
                _mnuOptionsItem_6.Checked = Not _mnuOptionsItem_6.Checked
                picMain.Refresh()

            Case _mnuOptionsItem_7.Name
                _mnuOptionsItem_7.Checked = Not _mnuOptionsItem_7.Checked
                m_blnPreview = False
                lstWAV.SelectedIndex = 0
                lstBMP.SelectedIndex = 0
                lstBGA.SelectedIndex = 0
                m_blnPreview = True

                Call RefreshList()
                picMain.Refresh()
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

        picMain.Refresh()

    End Sub

    Public Sub mnuToolsSetting_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolsSetting.Click

        With frmWindowViewer

            .Left = Me.Left + (Me.Width - .Width) \ 2
            .Top = Me.Top + (Me.Height - .Height) \ 2

            Call frmWindowViewer.ShowDialog(Me)

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

            If g_Obj(i).intSelect = modMain.OBJ_SELECT.Selected Then

                intTemp = 1

                Exit For

            End If

        Next i

        If intTemp = 0 Then Exit Sub

        Call CopyToClipboard()

        For i = 0 To UBound(g_Obj) - 1

            If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then g_Obj(i).intSelect = modMain.OBJ_SELECT.NON_SELECT

        Next i

        picMain.Refresh()

        Exit Sub

Err_Renamed:
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

                If .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                    strArray(lngTemp) = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
                    lngTemp = lngTemp + 1

                    Call modDraw.RemoveObj(i)

                End If

            End With

        Next i

        Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))

        Call modDraw.ArrangeObj()

        picMain.Refresh()

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "mnuEditDelete_Click")
    End Sub

    Public Sub mnuEditMode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _mnuEditMode_2.Click, _mnuEditMode_1.Click, _mnuEditMode_0.Click
        DirectCast(tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = False
        DirectCast(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = False
        DirectCast(tlbMenu.Items.Item("Delete"), ToolStripButton).Checked = False


        Select Case DirectCast(eventSender, ToolStripMenuItem).Name
            Case _mnuEditMode_0.Name
                DirectCast(tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = True
                staMain.Items.Item("Mode").Text = g_strStatusBar(20)
            Case _mnuEditMode_1.Name
                DirectCast(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = True
                staMain.Items.Item("Mode").Text = g_strStatusBar(21)
            Case _mnuEditMode_2.Name
                DirectCast(tlbMenu.Items.Item("Delete"), ToolStripButton).Checked = True
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

            DirectCast(ActiveControl(), TextBox).SelectedText = My.Computer.Clipboard.GetText()

            Exit Sub

        ElseIf TypeOf ActiveControl() Is System.Windows.Forms.ComboBox Then

            If DirectCast(ActiveControl(), ComboBox).DropDownStyle = 0 Then

                DirectCast(ActiveControl(), ComboBox).SelectedText = My.Computer.Clipboard.GetText()

                Exit Sub

            End If

        End If

        Call modDraw.ObjSelectCancel()

        For i = g_disp.intStartMeasure To 999

            If g_disp.Y <= g_Measure(i).lngY Then

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
                .lngPosition = Val(Mid(strArray(i), 5, 7)) + g_Measure(g_disp.intStartMeasure).lngY
                .sngValue = Val(Mid(strArray(i), 12))
                .lngHeight = 0
                .intSelect = modMain.OBJ_SELECT.Selected

                For j = 0 To 999

                    If .lngPosition < g_Measure(j).lngY Then

                        Exit For

                    Else

                        .intMeasure = j

                    End If

                Next j

                .lngPosition = .lngPosition - g_Measure(.intMeasure).lngY

                strArray(i - 1) = modInput.strFromNum(modMain.CMD_LOG.OBJ_ADD) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue

                If modDraw.lngChangeMaxMeasure(.intMeasure) Then lngArg = 1

            End With

            If g_Obj(UBound(g_Obj)).lngPosition < g_Measure(g_Obj(UBound(g_Obj)).intMeasure).intLen Then ReDim Preserve g_Obj(UBound(g_Obj) + 1)

        Next i

        If lngArg Then Call modDraw.ChangeResolution()

        Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))

        picMain.Refresh()

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

        picMain.Refresh()
    End Sub

    Public Sub mnuFileNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileNew.Click
        If modMain.intSaveCheck() Then Exit Sub

        Me.Text = g_strAppTitle & " - Now Initializing"

        Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

        With g_BMS

            .strDir = ""
            .strFileName = ""

        End With

        Call modInput.LoadBMSStart()

        Call modInput.LoadBMSEnd()

    End Sub

    Public Sub mnuFileOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpen.Click
        On Error GoTo Err_Renamed

        Dim strArray() As String

        If modMain.intSaveCheck() Then Exit Sub

        With dlgMainOpen

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            .Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"

            .FileName = g_BMS.strFileName

            If .ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

            strArray = Split(.FileName, "\")
            g_BMS.strDir = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
            g_BMS.strFileName = strArray(UBound(strArray))

            Call modInput.LoadBMS()

            Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)

            dlgMainOpen.InitialDirectory = g_BMS.strDir
            dlgMainSave.InitialDirectory = g_BMS.strDir

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

            Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
            Exit Sub

        End If

        If Len(g_BMS.strDir) Then

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

            Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
            Exit Sub

        End If

        If Len(g_BMS.strDir) Then

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

            Call MsgBox(strPath & " " & g_Message(modMain.Message.ERR_APP_NOT_FOUND), MsgBoxStyle.Critical, g_strAppTitle)
            Exit Sub

        End If

        If Len(g_BMS.strDir) Then

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
        Dim strArray() As String = Nothing

        If modMain.intSaveCheck() Then Exit Sub
        Select Case DirectCast(eventSender, ToolStripMenuItem).Name
            Case _mnuRecentFiles_0.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_0.Text, 4)) = vbNullString Then
                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_0.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_0.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_0.Text, 4, Len(_mnuRecentFiles_0.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_1.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_1.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_1.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_1.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_1.Text, 4, Len(_mnuRecentFiles_1.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_2.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_2.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_2.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_2.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_2.Text, 4, Len(_mnuRecentFiles_2.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_3.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_3.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_3.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_3.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_3.Text, 4, Len(_mnuRecentFiles_3.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_4.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_4.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_4.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_4.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_4.Text, 4, Len(_mnuRecentFiles_4.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_5.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_5.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_5.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_5.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_5.Text, 4, Len(_mnuRecentFiles_5.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_6.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_6.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_6.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_6.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_6.Text, 4, Len(_mnuRecentFiles_6.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_7.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_7.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_7.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_7.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_7.Text, 4, Len(_mnuRecentFiles_7.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_8.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_8.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_8.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_8.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_8.Text, 4, Len(_mnuRecentFiles_8.Text) - Len(strArray(UBound(strArray))) - 3)

            Case _mnuRecentFiles_9.Name
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(Mid(_mnuRecentFiles_9.Text, 4)) = vbNullString Then

                    Call MsgBox(g_Message(modMain.Message.ERR_FILE_NOT_FOUND) & vbCrLf & Mid(_mnuRecentFiles_9.Text, 4) & vbCrLf & g_Message(modMain.Message.ERR_LOAD_CANCEL), MsgBoxStyle.Critical, g_strAppTitle)
                    Exit Sub

                End If

                Call lngDeleteFile(g_BMS.strDir & "___bmse_temp.bms")

                strArray = Split(_mnuRecentFiles_9.Text, "\")
                g_BMS.strDir = Mid(_mnuRecentFiles_9.Text, 4, Len(_mnuRecentFiles_9.Text) - Len(strArray(UBound(strArray))) - 3)
        End Select
        g_BMS.strFileName = strArray(UBound(strArray))

        dlgMainOpen.InitialDirectory = g_BMS.strDir
        dlgMainSave.InitialDirectory = g_BMS.strDir

        Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)

        Call modInput.LoadBMS()

    End Sub

    Public Sub mnuFileSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSave.Click

        If g_BMS.strDir <> "" And g_BMS.strFileName <> "" Then

            Call modOutput.CreateBMS(g_BMS.strDir & g_BMS.strFileName)

        Else

            Call mnuFileSaveAs_Click(mnuFileSaveAs, New System.EventArgs())

        End If

    End Sub

    Public Sub mnuFileSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSaveAs.Click
        On Error GoTo Err_Renamed

        Dim strArray() As String

        With dlgMainSave

            'UPGRADE_WARNING: Filter に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            .Filter = "BMS files (*.bms,*.bme,*.bml,*.pms)|*.bms;*.bme;*.bml;*.pms|All files (*.*)|*.*"

            .FileName = g_BMS.strFileName

            If .ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            strArray = Split(.FileName, "\")
            g_BMS.strDir = VB.Left(.FileName, Len(.FileName) - Len(strArray(UBound(strArray))))
            g_BMS.strFileName = strArray(UBound(strArray))

            Call modOutput.CreateBMS(g_BMS.strDir & g_BMS.strFileName)

            Call modMain.RecentFilesRotation(g_BMS.strDir & g_BMS.strFileName)

            dlgMainOpen.InitialDirectory = g_BMS.strDir
            dlgMainSave.InitialDirectory = g_BMS.strDir

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

            g_Obj(i).intSelect = modMain.OBJ_SELECT.Selected

        Next i

        picMain.Refresh()

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
                    _fraBottom_2.Visible = True
                Case _optChangeBottom_3.Name
                    _fraBottom_3.Visible = True
                Case _optChangeBottom_4.Name
                    _fraBottom_4.Visible = True
            End Select

        End If
    End Sub

    'UPGRADE_WARNING: イベント optChangeTop.CheckedChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub optChangeTop_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _optChangeTop_2.CheckedChanged, _optChangeTop_1.CheckedChanged, _optChangeTop_0.CheckedChanged
        If eventSender.Checked Then
            _fraTop_0.Visible = False
            _fraTop_1.Visible = False
            _fraTop_2.Visible = False

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

    Private Sub picMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles picMain.KeyDown

        Dim lngTemp As Integer
        Dim intTemp As Short
        Dim blnTemp As Boolean

        blnTemp = True

        g_Mouse.Shift = e.Modifiers

        lngTemp = vsbMain.Value
        intTemp = hsbMain.Value

        Select Case e.KeyCode

            Case System.Windows.Forms.Keys.ControlKey, System.Windows.Forms.Keys.ShiftKey ', vbKeyMenu

                If DirectCast(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = False Then blnTemp = False

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

            Case System.Windows.Forms.Keys.End

                lngTemp = vsbMain.Minimum

            Case System.Windows.Forms.Keys.Home

                lngTemp = vsbMain.Maximum - vsbMain.LargeChange + 1

            Case System.Windows.Forms.Keys.PageDown

                lngTemp = lngTemp + vsbMain.LargeChange

            Case System.Windows.Forms.Keys.PageUp

                lngTemp = lngTemp - vsbMain.LargeChange

            Case System.Windows.Forms.Keys.Down

                lngTemp = lngTemp + vsbMain.SmallChange

            Case System.Windows.Forms.Keys.Up

                lngTemp = lngTemp - vsbMain.SmallChange

            Case System.Windows.Forms.Keys.Left

                intTemp = intTemp - hsbMain.SmallChange

            Case System.Windows.Forms.Keys.Right

                intTemp = intTemp + hsbMain.SmallChange

            Case Else

                blnTemp = False

        End Select

        With vsbMain

            If lngTemp > (.Maximum - .LargeChange + 1) Then

                .Value = (.Maximum - .LargeChange + 1)

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

            If DirectCast(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = False Then

                If g_SelectArea.blnFlag = True Or (g_Obj(UBound(g_Obj)).intCh <> 0 And g_Mouse.Button <> 0) Then

                    Call picMain_MouseMove(picMain, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, g_Mouse.X, g_Mouse.Y, 0))

                End If

            Else

                Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, e.Modifiers)
                picMain.Refresh()

            End If

        End If

    End Sub

    Private Sub picMain_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles picMain.KeyUp
        g_Mouse.Shift = e.Modifiers

        Select Case e.KeyCode

            Case System.Windows.Forms.Keys.ControlKey, System.Windows.Forms.Keys.ShiftKey

                If DirectCast(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = True Then

                    Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, e.Modifiers)
                    picMain.Refresh()

                End If

        End Select

    End Sub

    Private Sub picMain_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseDown
        On Error GoTo Err_Renamed

        Dim Shift As Keys = System.Windows.Forms.Control.ModifierKeys

        Dim strTemp As String
        'Dim intNum      As Long
        Dim lngTemp As Integer
        Dim i As Integer
        Dim tempObj As g_udtObj
        Dim strArray() As String

        If g_blnIgnoreInput Then Exit Sub

        m_blnMouseDown = True

        If eventArgs.Button = Windows.Forms.MouseButtons.Left Then '左クリック

            If DirectCast(tlbMenu.Items.Item("Delete"), ToolStripButton).Checked = True Then

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
                picMain.Refresh()

            ElseIf DirectCast(tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = True Then

                If g_Obj(UBound(g_Obj)).intCh <> 0 Then 'オブジェのあるところで押したっぽいよ

                    With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                        If DirectCast(Me.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData Then

                            lngTemp = 192 \ (DirectCast(Me.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData)
                            lngTemp = .lngPosition - (.lngPosition \ lngTemp) * lngTemp

                        End If

                    End With

                    If g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then '複数選択っぽいよ

                        If Shift And System.Windows.Forms.Keys.Control Then

                            tempObj = g_Obj(UBound(g_Obj))

                            'ReDim strArray(intNum - 1)
                            ReDim strArray(0)
                            'intNum = 0

                            For i = 0 To UBound(g_Obj) - 1

                                If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                                    With g_Obj(i)

                                        g_Obj(UBound(g_Obj)) = g_Obj(i)
                                        g_Obj(UBound(g_Obj)).lngID = g_lngIDNum

                                        strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_ADD) & modInput.strFromNum(g_lngIDNum, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
                                        'intNum = intNum + 1
                                        ReDim Preserve strArray(UBound(strArray) + 1)

                                        g_lngObjID(g_lngIDNum) = UBound(g_Obj)
                                        g_lngIDNum = g_lngIDNum + 1
                                        ReDim Preserve g_lngObjID(g_lngIDNum)

                                        .intSelect = modMain.OBJ_SELECT.NON_SELECT

                                    End With

                                    If i = tempObj.lngHeight Then tempObj.lngHeight = UBound(g_Obj)

                                    ReDim Preserve g_Obj(UBound(g_Obj) + 1)

                                End If

                            Next i

                            If UBound(strArray) Then

                                ReDim Preserve strArray(UBound(strArray) - 1)

                                Call g_InputLog.AddData(Join(strArray, modLog.getSeparator))

                                g_Obj(UBound(g_Obj)) = tempObj

                            End If

                        End If

                        ReDim m_tempObj(0)

                        For i = 0 To UBound(g_Obj) - 1

                            With g_Obj(i)

                                If .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                                    m_tempObj(UBound(m_tempObj)) = g_Obj(i)

                                    .lngHeight = UBound(m_tempObj)

                                    ReDim Preserve m_tempObj(UBound(m_tempObj) + 1)

                                End If

                            End With

                        Next i

                        m_tempObj(UBound(m_tempObj)) = g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                        With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                            'プレビュー
                            If _mnuOptionsItem_4.Checked = True And ((.intCh >= 11 And .intCh <= 29) Or .intCh > 100) Then

                                strTemp = g_strWAV(.sngValue)

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

                        If Not Shift And System.Windows.Forms.Keys.Control Then

                            Call modDraw.ObjSelectCancel()

                        End If

                        g_Obj(g_Obj(UBound(g_Obj)).lngHeight).intSelect = modMain.OBJ_SELECT.Selected

                        Call modDraw.MoveSelectedObj()

                        With g_Obj(g_Obj(UBound(g_Obj)).lngHeight)

                            ReDim m_tempObj(0)

                            For i = 0 To UBound(g_Obj) - 1

                                With g_Obj(i)

                                    m_tempObj(UBound(m_tempObj)) = g_Obj(i)
                                    .lngHeight = UBound(m_tempObj)
                                    ReDim Preserve m_tempObj(UBound(m_tempObj) + 1)

                                End With

                            Next i

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

                                        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                                        If strTemp <> "" And Dir(g_BMS.strDir & strTemp) <> vbNullString Then

                                            Call PreviewWAV(strTemp)

                                        End If

                                    Case 4, 6, 7

                                        If Len(g_strBGA(.sngValue)) Then

                                            Call PreviewBGA(.sngValue)

                                        Else

                                            strTemp = g_strBMP(.sngValue)

                                            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                                            If strTemp <> "" And Dir(g_BMS.strDir & strTemp) <> vbNullString Then

                                                Call PreviewBMP(strTemp)

                                            End If

                                        End If

                                End Select

                            End If

                        End With

                    End If

                    picMain.Refresh()

                Else 'オブジェのないところで押したっぽいよ

                    If Not Shift And System.Windows.Forms.Keys.Control Then

                        Call modDraw.ObjSelectCancel()

                        picMain.Refresh()

                    Else

                        For i = 0 To UBound(g_Obj) - 1

                            With g_Obj(i)

                                If .intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                                    .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT

                                End If

                            End With

                        Next i

                        picMain.Refresh()

                    End If

                    With g_SelectArea

                        .blnFlag = True
                        '.X1 = (X + g_disp.X) / g_disp.Width
                        .X1 = eventArgs.X / g_disp.Width + g_disp.X
                        .Y1 = (picMain.ClientRectangle.Height - eventArgs.Y) / g_disp.Height + g_disp.Y
                        .X2 = .X1
                        .Y2 = .Y1

                    End With

                End If

                'Call modDraw.Redraw
                picMain.Refresh()

            Else 'If tlbMenu.Buttons("Write").Value = tbrPressed Then

                Call modDraw.ObjSelectCancel()
                picMain.Refresh()

            End If

        ElseIf eventArgs.Button = Windows.Forms.MouseButtons.Right Then  '右クリック

            With g_Mouse

                .Button = eventArgs.Button
                .Shift = Shift
                .X = eventArgs.X
                .Y = eventArgs.Y

            End With

            Call DrawObjMax(eventArgs.X, eventArgs.Y, Shift)
            picMain.Refresh()

        ElseIf eventArgs.Button = Windows.Forms.MouseButtons.Middle Then  '中クリック

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
                picMain.Refresh()

            End If

        End If

        g_blnIgnoreInput = False

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseDown")
    End Sub

    Private Sub picMain_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseUp
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

        If eventArgs.Button = Windows.Forms.MouseButtons.Left Then

            If DirectCast(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = True Then

                With g_Obj(UBound(g_Obj))

                    Select Case .intCh

                        Case 8 'BPM

                            With frmWindowInput

                                .lblMainDisp.Text = g_Message(modMain.Message.INPUT_BPM)
                                .txtMain.Text = "" 'strTemp

                                Call frmWindowInput.ShowDialog(Me)

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

                                .lblMainDisp.Text = g_Message(modMain.Message.INPUT_STOP)
                                .txtMain.Text = "" 'strTemp

                                Call frmWindowInput.ShowDialog(Me)

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

                picMain.Refresh()

            ElseIf DirectCast(tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = True Then

                If g_SelectArea.blnFlag Then

                    g_SelectArea.blnFlag = False

                    For i = 0 To UBound(g_Obj) - 1

                        With g_Obj(i)

                            If .intSelect = modMain.OBJ_SELECT.Selected Or .intSelect = modMain.OBJ_SELECT.SELECTAREA_IN Or .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT Then

                                .intSelect = modMain.OBJ_SELECT.Selected

                            Else

                                .intSelect = modMain.OBJ_SELECT.NON_SELECT

                            End If

                        End With

                    Next i

                    Call modDraw.MoveSelectedObj()

                Else '複数選択っぽいよ

                    For i = 0 To UBound(g_Obj) - 1

                        If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

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

                                If .intCh <= 0 Or .intCh > 1000 Or (.intMeasure = 0 And .lngPosition < 0) Or (.intMeasure = 999 And .lngPosition > g_Measure(999).intLen) Then

                                    With m_tempObj(g_Obj(i).lngHeight)

                                        strArray(UBound(strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & modInput.strFromNum(.lngID, 4) & VB.Right("0" & Hex(.intCh), 2) & .intAtt & modInput.strFromNum(.intMeasure) & modInput.strFromNum(.lngPosition, 3) & .sngValue
                                        ReDim Preserve strArray(UBound(strArray) + 1)

                                    End With

                                    Call modDraw.RemoveObj(i)

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

                picMain.Refresh()

            End If

        ElseIf eventArgs.Button = Windows.Forms.MouseButtons.Right Then

            If Not m_blnIgnoreMenu Then mnuContext.Show(Me, eventArgs.X, eventArgs.Y)

            m_blnIgnoreMenu = False

        End If

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseUp")
    End Sub

    Public Sub picMain_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles picMain.MouseMove
        Dim Shift As Keys = System.Windows.Forms.Control.ModifierKeys
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim lngTemp As Integer
        Dim strTemp As String
        Dim rectTemp As RECT
        Dim blnSelect() As Boolean
        Dim blnYAxisFixed As Boolean

        'VB6 バグ対策
        If eventArgs.Button And Windows.Forms.MouseButtons.Left Then

            If Not m_blnMouseDown Then

                Exit Sub

            End If

        End If

        Dim value As Integer
        Dim str_Renamed As String

        If Not g_SelectArea.blnFlag Then '選択範囲なし

            If eventArgs.Button = Windows.Forms.MouseButtons.Left And DirectCast(tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = True And g_Obj(UBound(g_Obj)).intCh <> 0 Then 'オブジェ移動中

                Call MoveObj(eventArgs.X, eventArgs.Y, Shift)

                'Y 軸固定移動
                If Shift And Keys.Shift Then blnYAxisFixed = True

            Else 'それ以外

                Call modDraw.DrawObjMax(eventArgs.X, eventArgs.Y, Shift)
                picMain.Refresh()

                'スポイト機能
                If eventArgs.Button = Windows.Forms.MouseButtons.Right And g_Obj(UBound(g_Obj)).lngHeight < UBound(g_Obj) Then

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

                .Button = eventArgs.Button
                .Shift = Shift
                .X = eventArgs.X
                .Y = eventArgs.Y

            End With

            With g_SelectArea

                '.X2 = (X + g_disp.X) / g_disp.Width
                .X2 = eventArgs.X / g_disp.Width + g_disp.X
                .Y2 = (picMain.ClientRectangle.Height - eventArgs.Y) / g_disp.Height + g_disp.Y

            End With

            With rectTemp

                If g_SelectArea.X1 > g_SelectArea.X2 Then

                    .left_Renamed = g_SelectArea.X2
                    .right_Renamed = g_SelectArea.X1

                Else

                    .left_Renamed = g_SelectArea.X1
                    .right_Renamed = g_SelectArea.X2

                End If

                If g_SelectArea.Y1 > g_SelectArea.Y2 Then

                    .Top = g_SelectArea.Y2
                    .Bottom = g_SelectArea.Y1

                Else

                    .Top = g_SelectArea.Y1
                    .Bottom = g_SelectArea.Y2

                End If

            End With

            ReDim blnSelect(UBound(g_VGrid))

            For i = 0 To UBound(g_VGrid)

                With g_VGrid(i)

                    blnSelect(i) = False

                    If .blnVisible Then

                        If .intCh Then

                            'If (.lngLeft + .intWidth >= g_SelectArea.X1 And .lngLeft <= g_SelectArea.X2) Or (.lngLeft <= g_SelectArea.X1 And .lngLeft + .intWidth >= g_SelectArea.X2) Then
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

                        lngTemp = g_Measure(.intMeasure).lngY + .lngPosition

                        'If (lngTemp >= g_SelectArea.Y1 And lngTemp <= g_SelectArea.Y2 + OBJ_HEIGHT / g_disp.Height) Or (lngTemp <= g_SelectArea.Y1 And lngTemp >= g_SelectArea.Y2 - OBJ_HEIGHT / g_disp.Height) Then
                        If lngTemp + OBJ_HEIGHT / g_disp.Height >= rectTemp.Top And lngTemp <= rectTemp.Bottom Then

                            If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then

                                .intSelect = modMain.OBJ_SELECT.SELECTAREA_IN

                            Else

                                .intSelect = modMain.OBJ_SELECT.SELECTAREA_SELECTED

                            End If

                        Else

                            If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then

                                .intSelect = modMain.OBJ_SELECT.NON_SELECT

                            Else

                                .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT

                            End If

                        End If

                    Else

                        If .intSelect < modMain.OBJ_SELECT.SELECTAREA_OUT Then

                            .intSelect = modMain.OBJ_SELECT.NON_SELECT

                        Else

                            .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT

                        End If

                    End If

                End With

            Next i

            picMain.Refresh()

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

            .Button = eventArgs.Button
            .Shift = Shift
            .X = eventArgs.X
            If Not blnYAxisFixed Then .Y = eventArgs.Y

        End With

        m_intScrollDir = 0

        If eventArgs.X < 0 Then

            m_intScrollDir = 20

        ElseIf eventArgs.X > picMain.ClientRectangle.Width Then

            m_intScrollDir = 10

        End If

        If Not blnYAxisFixed Then

            If eventArgs.Y < 0 Then

                m_intScrollDir = m_intScrollDir + 1

            ElseIf eventArgs.Y > picMain.ClientRectangle.Height Then

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
        Call modMain.CleanUp(Err.Number, Err.Description, "picMain_MouseMove")
    End Sub

    Private Sub picMain_DragEnter(sender As Object, e As DragEventArgs) Handles picMain.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub picMain_DragDrop(sender As Object, e As DragEventArgs) Handles picMain.DragDrop
        Call FormDragDrop(CType(e.Data.GetData(DataFormats.FileDrop), String()))
    End Sub

    Private Sub staMain_PanelDblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _staMain_Panel6.DoubleClick, Measure.DoubleClick, BMP.DoubleClick, WAV.DoubleClick, Position.DoubleClick, Mode.DoubleClick
        Dim Panel As System.Windows.Forms.ToolStripStatusLabel = DirectCast(eventSender, System.Windows.Forms.ToolStripStatusLabel)

        If Panel.Name = staMain.Items.Item("Mode").Name Then
            If DirectCast(tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = True Then
                Call mnuEditMode_Click(_mnuEditMode_1, New System.EventArgs())
            ElseIf DirectCast(tlbMenu.Items.Item("Write"), ToolStripButton).Checked = True Then
                Call mnuEditMode_Click(_mnuEditMode_2, New System.EventArgs())
            ElseIf DirectCast(tlbMenu.Items.Item("Delete"), ToolStripButton).Checked = True Then
                Call mnuEditMode_Click(_mnuEditMode_0, New System.EventArgs())
            End If
        End If

    End Sub

    Private Sub tlbMenu_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Delete.Click, Write.Click, Edit.Click, SepMode.Click, SaveAs.Click, Save.Click, Reload.Click, Resolution.Click, Open.Click, SepResolution.Click, DispSize.Click, SepSize.Click, ChangeGrid.Click, SepGrid.Click, _Stop.Click, Play.Click, PlayAll.Click, Viewer.Click, SepViewer.Click, _New.Click
        Dim Button As System.Windows.Forms.ToolStripItem = DirectCast(eventSender, System.Windows.Forms.ToolStripItem)
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
    'Private Sub tlbMenu_Change()

    '    Call frmMain_Resize(Me, New System.EventArgs())

    'End Sub

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

                    If .Value + .SmallChange < (.Maximum - .LargeChange + 1) Then

                        .Value = .Value + .SmallChange

                    Else

                        .Value = (.Maximum - .LargeChange + 1)

                        m_intScrollDir = m_intScrollDir - 1

                    End If

                Case 2

                    If .Value - .SmallChange > .Minimum Then

                        .Value = .Value - .SmallChange

                    Else

                        .Value = .Minimum

                        m_intScrollDir = m_intScrollDir - 2

                    End If

            End Select

        End With

        If m_intScrollDir Then

            Call picMain_MouseMove(picMain, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, g_Mouse.X, g_Mouse.Y, 0))
            'Call MoveObj(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)

        End If

    End Sub

    Public Sub tmrEffect_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrEffect.Tick

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

        picMain.Refresh()

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

    'UPGRADE_WARNING: VScrollBar イベント vsbMain.Change には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    Private Sub vsbMain_Change(ByVal newScrollValue As Integer)
        On Error Resume Next

        With g_disp

            '.Y = CLng(vsbMain.Value) * 96
            .Y = CInt((vsbMain.Maximum - vsbMain.LargeChange + 1) - newScrollValue) * .intResolution

        End With

        picMain.Refresh()

        'Call modDraw.DrawObjMax(g_Mouse.X, g_Mouse.Y, g_Mouse.Shift)
        'スクロール＆オブジェ移動実現のため

    End Sub

    Private Sub vsbMain_Scroll_Renamed(ByVal newScrollValue As Integer)

        Call vsbMain_Change(newScrollValue)

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

    Private Sub picMain_Paint(ByVal sender As System.Object, ByVal e As PaintEventArgs)
        Redraw(e.Graphics)

        If g_Obj(UBound(g_Obj)).intCh Then

            Call modDraw.InitPen()
            Call modDraw.DrawObj(e.Graphics, g_Obj(UBound(g_Obj)))
            Call modDraw.DeletePen()

        End If

        If g_SelectArea.blnFlag Then Call modDraw.DrawSelectArea(e.Graphics)

        If g_disp.intEffect Then Call modEasterEgg.DrawEffect(e.Graphics)

    End Sub

    Private Sub vsbMain_ValueChanged(sender As Object, e As EventArgs) Handles vsbMain.ValueChanged
        vsbMain_Change(vsbMain.Value)
    End Sub

    Private Sub hsbMain_ValueChanged(sender As Object, e As EventArgs) Handles hsbMain.ValueChanged
        hsbMain_Change(hsbMain.Value)
    End Sub
End Class
Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices

Module modDraw

    Private Declare Function timeGetTime Lib "winmm.dll" () As Integer

    Public Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As Integer, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal dwRop As Integer) As Integer

    Public Declare Function GetTextExtentPoint32 Lib "gdi32" Alias "GetTextExtentPoint32W" (ByVal hdc As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpsz As String, ByVal cbString As Integer, <[In]()> ByRef lpSize As Size) As Integer

    Public Declare Function CreatePen Lib "gdi32" (ByVal nPenStyle As Integer, ByVal nWidth As Integer, ByVal crColor As Integer) As Integer
    Public Declare Function CreateBrushIndirect Lib "gdi32" (<[In]()> ByRef lpLogBrush As LOGBRUSH) As Integer
    Public Declare Function CreateSolidBrush Lib "gdi32" (ByVal crColor As Integer) As Integer

    Public Declare Function SelectObject Lib "gdi32" (ByVal hdc As Integer, ByVal hObject As Integer) As Integer
    Public Declare Function DeleteObject Lib "gdi32" (ByVal hObject As Integer) As Integer

    Public Declare Function CreateCompatibleDC Lib "gdi32" (ByVal hDC As IntPtr) As IntPtr
    Public Declare Function DeleteDC Lib "gdi32" (ByVal hDC As IntPtr) As Integer

    Public Declare Function TextOut Lib "gdi32" Alias "TextOutW" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpString As String, ByVal nCount As Integer) As Integer
    Public Declare Function SetTextColor Lib "gdi32" (ByVal hdc As Integer, ByVal crColor As Integer) As Integer
    Public Declare Function SetBkMode Lib "gdi32" (ByVal hdc As Integer, ByVal iBkMode As Integer) As Integer

    Public Declare Function Rectangle Lib "gdi32" (ByVal hdc As Integer, ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As Integer
    Public Declare Function LineTo Lib "gdi32" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer) As Integer
    Public Declare Function MoveToEx Lib "gdi32" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer, ByRef lpPoint As Integer) As Integer

    Public Declare Function Ellipse Lib "gdi32" (ByVal hdc As Integer, ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As Integer

    'CreatePen 関連
    Public Const PS_SOLID As Short = 0
    Public Const PS_DASH As Short = 1 '  -------
    Public Const PS_DOT As Short = 2 '  .......
    Public Const PS_DASHDOT As Short = 3 '  _._._._
    Public Const PS_DASHDOTDOT As Short = 4 '  _.._.._
    Public Const PS_NULL As Short = 5
    Public Const PS_INSIDEFRAME As Short = 6

    'CreateHatchBrush 関連
    Public Const HS_BDIAGONAL As Short = 3 '  /////
    Public Const HS_CROSS As Short = 4 '  +++++
    Public Const HS_DIAGCROSS As Short = 5 '  xxxxx
    Public Const HS_FDIAGONAL As Short = 2 '  \\\\\
    Public Const HS_HORIZONTAL As Short = 0 '  -----
    Public Const HS_VERTICAL As Short = 1 '  |||||

    'CreateBrushIndirect 関連
    Public Const BS_SOLID As Short = 0
    Public Const BS_NULL As Short = 1
    Public Const BS_HOLLOW As Short = BS_NULL
    Public Const BS_HATCHED As Short = 2
    Public Const BS_PATTERN As Short = 3
    Public Const BS_DIBPATTERN As Short = 5
    Public Const BS_DIBPATTERNPT As Short = 6
    Public Const BS_PATTERN8X8 As Short = 7
    Public Const BS_DIBPATTERN8X8 As Short = 8

    'SetBkMode 関連
    Public Const TRANSPARENT As Integer = 1
    Public Const OPAQUE As Integer = 2
    Public Const BKMODE_LAST As Integer = 2

    <StructLayout(LayoutKind.Sequential)> Public Structure LOGBRUSH
        Dim lbStyle As Integer
        Dim lbColor As Integer
        Dim lbHatch As Integer
    End Structure

    'BitBlt 関連の定数
    Public Const SRCAND As Integer = &H8800C6
    Public Const SRCCOPY As Integer = &HCC0020
    Public Const SRCPAINT As Integer = &HEE0086
    Public Const SRCINVERT As Integer = &H660046

    'GetTextExtentPoint32 関連
    <StructLayout(LayoutKind.Sequential)> Public Structure Size
        Dim Width As Integer
        Dim Height As Integer
    End Structure

    Public Const OBJ_DIFF As Short = -1 'オブジェのずれ

    '# Ch早見表 #
    ' 1 BGM
    ' 2 小節長
    ' 3 BPM Hex
    ' 4 BGA
    ' 6 Poor
    ' 7 Layer
    ' 8 BPM Dec
    ' 9 STOP
    '11 1P 1Key
    '12 1P 2Key
    '13 1P 3Key
    '14 1P 4Key
    '15 1P 5Key
    '18 1P 6Key
    '19 1P 7Key
    '16 1P SC
    '21 2P 1Key
    '22 2P 2Key
    '23 2P 3Key
    '24 2P 4Key
    '25 2P 5Key
    '28 2P 6Key
    '29 2P 7Key
    '26 2P SC
    '31-49 不可視オブジェ
    '51-69 ロングノート

    Public g_lngPenColor(75) As Integer
    Public g_lngBrushColor(36) As Integer
    Public g_lngSystemColor(6) As Integer

    Private m_hPen(75) As Integer
    Private m_hBrush(37) As Integer

    Private m_tempObj() As g_udtObj

    Public Enum COLOR_NUM
        MEASURE_NUM
        MEASURE_LINE
        GRID_MAIN
        GRID_SUB
        VERTICAL_MAIN
        VERTICAL_SUB
        INFO
        Max
    End Enum

    Public Enum PEN_NUM
        BGM_LIGHT
        BGM_SHADOW
        BPM_LIGHT
        BPM_SHADOW
        BGA_LIGHT
        BGA_SHADOW
        KEY01_LIGHT
        KEY02_LIGHT
        KEY03_LIGHT
        KEY04_LIGHT
        KEY05_LIGHT
        KEY06_LIGHT
        KEY07_LIGHT
        KEY08_LIGHT
        KEY11_LIGHT
        KEY12_LIGHT
        KEY13_LIGHT
        KEY14_LIGHT
        KEY15_LIGHT
        KEY16_LIGHT
        KEY17_LIGHT
        KEY18_LIGHT
        KEY01_SHADOW
        KEY02_SHADOW
        KEY03_SHADOW
        KEY04_SHADOW
        KEY05_SHADOW
        KEY06_SHADOW
        KEY07_SHADOW
        KEY08_SHADOW
        KEY11_SHADOW
        KEY12_SHADOW
        KEY13_SHADOW
        KEY14_SHADOW
        KEY15_SHADOW
        KEY16_SHADOW
        KEY17_SHADOW
        KEY18_SHADOW
        INV_KEY01_LIGHT
        INV_KEY02_LIGHT
        INV_KEY03_LIGHT
        INV_KEY04_LIGHT
        INV_KEY05_LIGHT
        INV_KEY06_LIGHT
        INV_KEY07_LIGHT
        INV_KEY08_LIGHT
        INV_KEY11_LIGHT
        INV_KEY12_LIGHT
        INV_KEY13_LIGHT
        INV_KEY14_LIGHT
        INV_KEY15_LIGHT
        INV_KEY16_LIGHT
        INV_KEY17_LIGHT
        INV_KEY18_LIGHT
        INV_KEY01_SHADOW
        INV_KEY02_SHADOW
        INV_KEY03_SHADOW
        INV_KEY04_SHADOW
        INV_KEY05_SHADOW
        INV_KEY06_SHADOW
        INV_KEY07_SHADOW
        INV_KEY08_SHADOW
        INV_KEY11_SHADOW
        INV_KEY12_SHADOW
        INV_KEY13_SHADOW
        INV_KEY14_SHADOW
        INV_KEY15_SHADOW
        INV_KEY16_SHADOW
        INV_KEY17_SHADOW
        INV_KEY18_SHADOW
        LONGNOTE_LIGHT
        LONGNOTE_SHADOW
        SELECT_OBJ_LIGHT
        SELECT_OBJ_SHADOW
        EDIT_FRAME
        DELETE_FRAME
        Max
    End Enum

    Public Enum BRUSH_NUM
        BGM
        BPM
        BGA
        KEY01
        KEY02
        KEY03
        KEY04
        KEY05
        KEY06
        KEY07
        KEY08
        KEY11
        KEY12
        KEY13
        KEY14
        KEY15
        KEY16
        KEY17
        KEY18
        INV_KEY01
        INV_KEY02
        INV_KEY03
        INV_KEY04
        INV_KEY05
        INV_KEY06
        INV_KEY07
        INV_KEY08
        INV_KEY11
        INV_KEY12
        INV_KEY13
        INV_KEY14
        INV_KEY15
        INV_KEY16
        INV_KEY17
        INV_KEY18
        LONGNOTE
        SELECT_OBJ
        DELETE_FRAME
        EDIT_FRAME
        Max
    End Enum

    Public Enum GRID
        NUM_BLANK_1
        NUM_BPM
        NUM_STOP
        NUM_BLANK_2
        NUM_FOOTPEDAL
        NUM_1P_SC_L
        NUM_1P_1KEY
        NUM_1P_2KEY
        NUM_1P_3KEY
        NUM_1P_4KEY
        NUM_1P_5KEY
        NUM_1P_6KEY
        NUM_1P_7KEY
        NUM_1P_SC_R
        NUM_BLANK_3
        NUM_2P_SC_L
        NUM_2P_1KEY
        NUM_2P_2KEY
        NUM_2P_3KEY
        NUM_2P_4KEY
        NUM_2P_5KEY
        NUM_2P_6KEY
        NUM_2P_7KEY
        NUM_2P_SC_R
        NUM_BLANK_4
        NUM_BGA
        NUM_LAYER
        NUM_POOR
        NUM_BLANK_5
        NUM_BGM
    End Enum

    Public Const OBJ_WIDTH As Short = 28
    Public Const OBJ_HEIGHT As Short = 9

    Public Const GRID_WIDTH As Short = OBJ_WIDTH
    Public Const GRID_HALF_WIDTH As Short = GRID_WIDTH \ 2
    Public Const GRID_HALF_EDGE_WIDTH As Short = (GRID_WIDTH * 3) \ 4
    Public Const SPACE_WIDTH As Short = 4
    Public Const FRAME_WIDTH As Short = GRID_WIDTH \ 2
    Public Const LEFT_SPACE As Integer = FRAME_WIDTH + SPACE_WIDTH
    Public Const RIGHT_SPACE As Integer = FRAME_WIDTH + SPACE_WIDTH * 2

    Public g_sngSin(256 + 64) As Single

    Public Sub InitVerticalLine()
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim lngTemp As Integer

        With frmMain

            If .cboDispFrame.SelectedIndex Then

                For i = GRID.NUM_1P_1KEY To GRID.NUM_1P_7KEY

                    g_VGrid(i).intWidth = GRID_WIDTH

                Next i

                For i = GRID.NUM_2P_1KEY To GRID.NUM_2P_7KEY

                    g_VGrid(i).intWidth = GRID_WIDTH

                Next i

            Else

                g_VGrid(GRID.NUM_1P_1KEY).intWidth = GRID_HALF_EDGE_WIDTH

                For i = GRID.NUM_1P_2KEY To GRID.NUM_1P_6KEY

                    g_VGrid(i).intWidth = GRID_HALF_WIDTH

                Next i

                If frmMain.cboDispKey.SelectedIndex Then

                    g_VGrid(GRID.NUM_1P_7KEY).intWidth = GRID_HALF_EDGE_WIDTH

                Else

                    g_VGrid(GRID.NUM_1P_5KEY).intWidth = GRID_HALF_EDGE_WIDTH

                End If

                g_VGrid(GRID.NUM_2P_1KEY).intWidth = GRID_HALF_EDGE_WIDTH

                For i = GRID.NUM_2P_2KEY To GRID.NUM_2P_6KEY

                    g_VGrid(i).intWidth = GRID_HALF_WIDTH

                Next i

                If frmMain.cboDispKey.SelectedIndex Then

                    g_VGrid(GRID.NUM_2P_7KEY).intWidth = GRID_HALF_EDGE_WIDTH

                Else

                    g_VGrid(GRID.NUM_2P_5KEY).intWidth = GRID_HALF_EDGE_WIDTH

                End If

            End If

            Select Case .cboPlayer.SelectedIndex

                Case 0, 1, 2 '1P/2P/DP

                    g_VGrid(GRID.NUM_FOOTPEDAL).blnVisible = False
                    g_VGrid(GRID.NUM_2P_SC_L - 1).blnVisible = True

                    If .cboDispKey.SelectedIndex = 0 Then

                        g_VGrid(GRID.NUM_1P_6KEY).blnVisible = False
                        g_VGrid(GRID.NUM_1P_7KEY).blnVisible = False

                    Else

                        g_VGrid(GRID.NUM_1P_6KEY).blnVisible = True
                        g_VGrid(GRID.NUM_1P_7KEY).blnVisible = True

                    End If

                    If .cboDispSC1P.SelectedIndex = 0 Then

                        g_VGrid(GRID.NUM_1P_SC_L).blnVisible = True
                        g_VGrid(GRID.NUM_1P_SC_R).blnVisible = False

                    Else

                        g_VGrid(GRID.NUM_1P_SC_L).blnVisible = False
                        g_VGrid(GRID.NUM_1P_SC_R).blnVisible = True

                    End If

                    If .cboPlayer.SelectedIndex <> 0 Then

                        For i = GRID.NUM_2P_SC_L To GRID.NUM_2P_SC_R + 1

                            g_VGrid(i).blnVisible = True

                        Next i

                        If .cboDispKey.SelectedIndex = 0 Then

                            g_VGrid(GRID.NUM_2P_6KEY).blnVisible = False
                            g_VGrid(GRID.NUM_2P_7KEY).blnVisible = False

                        Else

                            g_VGrid(GRID.NUM_2P_6KEY).blnVisible = True
                            g_VGrid(GRID.NUM_2P_7KEY).blnVisible = True

                        End If

                        If .cboDispSC2P.SelectedIndex = 0 Then

                            g_VGrid(GRID.NUM_2P_SC_L).blnVisible = True
                            g_VGrid(GRID.NUM_2P_SC_R).blnVisible = False

                        Else

                            g_VGrid(GRID.NUM_2P_SC_L).blnVisible = False
                            g_VGrid(GRID.NUM_2P_SC_R).blnVisible = True

                        End If

                    Else

                        For i = GRID.NUM_2P_SC_L To GRID.NUM_2P_SC_R + 1

                            g_VGrid(i).blnVisible = False

                        Next i

                    End If

                Case 3 'PMS

                    g_VGrid(GRID.NUM_FOOTPEDAL).blnVisible = False
                    g_VGrid(GRID.NUM_1P_SC_L).blnVisible = False
                    g_VGrid(GRID.NUM_1P_6KEY).blnVisible = False
                    g_VGrid(GRID.NUM_1P_7KEY).blnVisible = False
                    g_VGrid(GRID.NUM_1P_SC_R).blnVisible = False
                    g_VGrid(GRID.NUM_2P_SC_L - 1).blnVisible = False
                    g_VGrid(GRID.NUM_2P_SC_L).blnVisible = False
                    g_VGrid(GRID.NUM_2P_1KEY).blnVisible = False
                    g_VGrid(GRID.NUM_2P_SC_R + 1).blnVisible = True

                    For i = GRID.NUM_2P_2KEY To GRID.NUM_2P_5KEY

                        g_VGrid(i).blnVisible = True

                    Next i

                    For i = GRID.NUM_2P_6KEY To GRID.NUM_2P_SC_R

                        g_VGrid(i).blnVisible = False

                    Next i

                    If .cboDispFrame.SelectedIndex = 0 Then

                        g_VGrid(GRID.NUM_1P_5KEY).intWidth = GRID_HALF_WIDTH
                        g_VGrid(GRID.NUM_2P_5KEY).intWidth = GRID_HALF_EDGE_WIDTH

                    End If

                Case 4 'Oct

                    g_VGrid(GRID.NUM_FOOTPEDAL).blnVisible = True
                    g_VGrid(GRID.NUM_1P_SC_L).blnVisible = True
                    g_VGrid(GRID.NUM_1P_6KEY).blnVisible = True
                    g_VGrid(GRID.NUM_1P_7KEY).blnVisible = True
                    g_VGrid(GRID.NUM_2P_SC_L - 1).blnVisible = False
                    g_VGrid(GRID.NUM_2P_1KEY).blnVisible = False
                    g_VGrid(GRID.NUM_2P_SC_R).blnVisible = True
                    g_VGrid(GRID.NUM_2P_SC_R + 1).blnVisible = True

                    For i = GRID.NUM_2P_2KEY To GRID.NUM_2P_7KEY

                        g_VGrid(i).blnVisible = True

                    Next i

                    If .cboDispFrame.SelectedIndex = 0 Then

                        g_VGrid(GRID.NUM_1P_5KEY).intWidth = GRID_HALF_WIDTH
                        g_VGrid(GRID.NUM_1P_7KEY).intWidth = GRID_HALF_WIDTH
                        g_VGrid(GRID.NUM_2P_5KEY).intWidth = GRID_HALF_WIDTH
                        g_VGrid(GRID.NUM_2P_7KEY).intWidth = GRID_HALF_EDGE_WIDTH

                    End If

            End Select

        End With

        lngTemp = 0

        For i = 0 To 999

            g_Measure(i).lngY = lngTemp
            lngTemp = lngTemp + g_Measure(i).intLen

        Next i

        g_disp.lngMaxY = g_Measure(999).lngY + g_Measure(999).intLen

        frmMain.picMain.Refresh()

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "InitVerticalLine")
    End Sub

    Public Sub Redraw(ByVal gp As Graphics)
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim lngTemp As Integer
        Dim lngTimer As Integer

        lngTimer = timeGetTime()

        'If frmMain.Visible = False Or frmMain.Enabled = False Then Exit Sub
        If frmMain.Visible = False Then Exit Sub

        For i = 0 To g_disp.intMaxMeasure

            lngTemp = lngTemp + g_Measure(i).intLen

        Next i

        'frmMain.vsbMain.Min = lngTemp \ 96
        frmMain.vsbMain.Minimum = lngTemp \ g_disp.intResolution

        'UPGRADE_ISSUE: PictureBox プロパティ picMain.AutoRedraw はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'frmMain.picMain.AutoRedraw = True

        With g_disp

            '.Width = frmMain.hsbDispWidth.Value / 100
            '.Height = frmMain.hsbDispHeight.Value / 100
            .Width = DirectCast(frmMain.cboDispWidth.SelectedItem, modMain.ItemWithData).ItemData / 100
            Dim inasdka As Integer = frmMain.cboDispHeight.SelectedIndex
            .Height = DirectCast(frmMain.cboDispHeight.SelectedItem, modMain.ItemWithData).ItemData / 100
            .intStartMeasure = 999
            .intEndMeasure = 999
            .lngStartPos = .Y - OBJ_HEIGHT
            .lngEndPos = .Y + frmMain.picMain.ClientRectangle.Height / .Height

        End With

        'lngTemp = 16
        lngTemp = FRAME_WIDTH

        For i = 0 To UBound(g_intVGridNum)

            g_intVGridNum(i) = 0

        Next i

        For i = 0 To UBound(g_VGrid)

            With g_VGrid(i)

                If .blnVisible Then

                    Select Case .intCh

                        Case 11 To 29

                            g_intVGridNum(.intCh) = i
                            g_intVGridNum(.intCh + 20) = i
                            g_intVGridNum(.intCh + 40) = i

                        Case Is > 100

                            g_intVGridNum(.intCh) = i
                            g_intVGridNum(.intCh + 40) = i

                        Case Is > 0

                            g_intVGridNum(.intCh) = i

                    End Select

                    .lngLeft = lngTemp

                    Select Case .intCh

                        Case 15

                            If frmMain.cboDispKey.SelectedIndex = 1 Or frmMain.cboPlayer.SelectedIndex > 2 Then

                                .lngObjLeft = .lngLeft + (.intWidth - GRID_WIDTH) \ 2

                            Else

                                .lngObjLeft = .lngLeft + .intWidth - GRID_WIDTH

                            End If

                        Case 25

                            If frmMain.cboPlayer.SelectedIndex = 4 Then

                                .lngObjLeft = .lngLeft + (.intWidth - GRID_WIDTH) \ 2

                            ElseIf frmMain.cboDispKey.SelectedIndex = 0 Or frmMain.cboPlayer.SelectedIndex = 3 Then

                                .lngObjLeft = .lngLeft + .intWidth - GRID_WIDTH

                            Else

                                .lngObjLeft = .lngLeft + (.intWidth - GRID_WIDTH) \ 2

                            End If

                        Case 19

                            If frmMain.cboPlayer.SelectedIndex > 2 Then

                                .lngObjLeft = .lngLeft + (.intWidth - GRID_WIDTH) \ 2

                            Else

                                .lngObjLeft = .lngLeft + .intWidth - GRID_WIDTH

                            End If

                        Case 29

                            .lngObjLeft = .lngLeft + .intWidth - GRID_WIDTH

                        Case 12 To 18, 22 To 28

                            .lngObjLeft = .lngLeft + (.intWidth - GRID_WIDTH) \ 2

                        Case Else

                            .lngObjLeft = lngTemp

                    End Select

                    'If (lngTemp + .intWidth) * g_disp.Width >= g_disp.X And (g_disp.X + frmMain.picMain.ScaleWidth) / g_disp.Width >= lngTemp Then
                    If .lngLeft + .intWidth >= g_disp.X And frmMain.picMain.ClientRectangle.Width + (g_disp.X - .lngLeft) * g_disp.Width >= 0 Then

                        .blnDraw = True

                    Else

                        .blnDraw = False

                    End If

                    lngTemp = lngTemp + .intWidth

                Else

                    .blnDraw = False

                End If

            End With

        Next i

        g_disp.lngMaxX = lngTemp

        lngTemp = 0

        For i = 0 To 999

            lngTemp = lngTemp + g_Measure(i).intLen

            If lngTemp > g_disp.Y Then

                g_disp.intStartMeasure = i

                Exit For

            End If

        Next i

        For i = g_disp.intStartMeasure + 1 To 999

            lngTemp = lngTemp + g_Measure(i).intLen

            If (lngTemp - g_disp.Y) * g_disp.Height >= frmMain.picMain.ClientRectangle.Height Then

                g_disp.intEndMeasure = i

                Exit For

            End If

        Next i

        Call gp.Clear(frmMain.picMain.BackColor)

        Dim hDC As IntPtr = gp.GetHdc()

        Call DrawGridBG(hDC) '背景色

        Call DrawMeasureNum(hDC) '小節番号

        Call DrawVerticalGrayLine(hDC) '縦線(灰色)

        Call DrawHorizonalLine(hDC) '横線(灰色)

        Call DrawVerticalWhiteLine(hDC) '縦線(白)

        Call DrawMeasureLine(hDC) '横線(白)

        gp.ReleaseHdc()

        Call InitPen()

        Dim newstyle As FontStyle = frmMain.stringFont.Style
        If newstyle And FontStyle.Italic Then
            newstyle = newstyle Xor FontStyle.Italic
        End If
        frmMain.stringFont = New Font(frmMain.stringFont.FontFamily, 8, newstyle, frmMain.stringFont.Unit, frmMain.stringFont.GdiCharSet, frmMain.stringFont.GdiVerticalFont)

        ReDim m_tempObj(0)

        For i = 0 To UBound(g_Obj) - 1 'オブジェ

            With g_Obj(i)

                If 0 < .intCh And .intCh < 133 Then

                    If g_VGrid(g_intVGridNum(.intCh)).blnDraw Then

                        If g_disp.lngStartPos <= g_Measure(.intMeasure).lngY + .lngPosition And g_disp.lngEndPos >= g_Measure(.intMeasure).lngY + .lngPosition Then

                            Call DrawObj(gp, g_Obj(i))

                        End If

                    End If

                End If

            End With

        Next i

        For i = 0 To UBound(m_tempObj) - 1

            With m_tempObj(i)

                If g_disp.lngStartPos <= g_Measure(.intMeasure).lngY + .lngPosition And g_disp.lngEndPos >= g_Measure(.intMeasure).lngY + .lngPosition And g_VGrid(g_intVGridNum(.intCh)).blnDraw = True And .intCh <> 0 Then

                    Call DrawObj(gp, m_tempObj(i))

                End If

            End With

        Next i

        Call DeletePen()

        hDC = gp.GetHdc()

        Call DrawGridInfo(hDC) 'グリッド情報

        gp.ReleaseHdc()

        With frmMain.picMain

            If (g_disp.lngMaxX + 16) * g_disp.Width - .ClientRectangle.Width < 0 Then

                frmMain.hsbMain.Maximum = (0 + frmMain.hsbMain.LargeChange - 1)

            Else

                'frmMain.hsbMain.Max = (g_disp.lngMaxX + 16) * g_disp.Width - .ScaleWidth
                'frmMain.hsbMain.Max = (g_disp.lngMaxX + 16) - .ScaleWidth / g_disp.Width
                frmMain.hsbMain.Maximum = ((g_disp.lngMaxX + FRAME_WIDTH) - .ClientRectangle.Width / g_disp.Width + frmMain.hsbMain.LargeChange - 1)

            End If

            'UPGRADE_ISSUE: PictureBox プロパティ picMain.AutoRedraw はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '.AutoRedraw = False

        End With

        If g_disp.intEffect Then Call modEasterEgg.DrawEffect(gp)

        'Debug.Print timeGetTime() - lngTimer
        'frmMain.staMain.Items.Item("Time").Text = timeGetTime() - lngTimer & "ms"

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "Redraw")
    End Sub

    Private Sub DrawGridBG(ByVal hDC As IntPtr)

        Dim i As Integer
        Dim hPenNew As Integer
        Dim hPenOld As Integer
        Dim hBrushNew As Integer
        Dim hBrushOld As Integer

        If frmMain._mnuOptionsItem_3.Checked Then

            For i = 0 To UBound(g_VGrid) '背景色

                With g_VGrid(i)

                    If .blnDraw Then

                        If .intCh Then

                            hPenNew = CreatePen(PS_SOLID, 1, .lngBackColor)
                            hPenOld = SelectObject(hDC, hPenNew)
                            hBrushNew = CreateSolidBrush(.lngBackColor)
                            hBrushOld = SelectObject(hDC, hBrushNew)

                            'Call Rectangle(frmMain.picMain.hdc, .lngLeft * g_disp.Width - g_disp.X, 0, (.lngLeft + .intWidth + 1) * g_disp.Width - g_disp.X, frmMain.picMain.ScaleHeight)
                            Call Rectangle(hDC, (.lngLeft - g_disp.X) * g_disp.Width, 0, (.lngLeft + .intWidth + 1 - g_disp.X) * g_disp.Width, frmMain.picMain.ClientRectangle.Height)

                            hPenNew = SelectObject(hDC, hPenOld)
                            Call DeleteObject(hPenNew)
                            hBrushNew = SelectObject(hDC, hBrushOld)
                            Call DeleteObject(hBrushNew)

                        End If

                    End If

                End With

            Next i

        End If

    End Sub

    Private Sub DrawMeasureNum(ByVal hDC As IntPtr)

        Dim i As Integer
        Dim strTemp As String = Space(4)
        Dim sizeTemp As Size

        With frmMain.picMain

            frmMain.stringFont = New Font(frmMain.stringFont.FontFamily, 72, frmMain.stringFont.Style Or FontStyle.Italic, frmMain.stringFont.Unit, frmMain.stringFont.GdiCharSet, frmMain.stringFont.GdiVerticalFont)

            Dim hFont As IntPtr = frmMain.stringFont.ToHfont()
            Dim hOldFont As IntPtr = SelectObject(hDC, hFont)

            SetBkMode(hDC, TRANSPARENT)

            For i = g_disp.intStartMeasure To g_disp.intEndMeasure '#小節番号

                'strTemp = "#" & Format$(i, "000")
                strTemp = "#" & Right("00" & i, 3)

                Call GetTextExtentPoint32(hDC, strTemp, 4, sizeTemp)

                Call SetTextColor(hDC, g_lngSystemColor(COLOR_NUM.MEASURE_NUM)) 'RGB(64, 64, 64)
                Call TextOut(hDC, (.ClientRectangle.Width - sizeTemp.Width) \ 2, .ClientRectangle.Height - sizeTemp.Height - (g_Measure(i).lngY - g_disp.Y) * g_disp.Height, strTemp, 4)

            Next i

            SelectObject(hDC, hOldFont)
            DeleteObject(hFont)

        End With

    End Sub

    Private Sub DrawVerticalGrayLine(ByVal hDC As IntPtr)

        Dim i As Integer
        Dim Y As Integer
        Dim H As Integer
        Dim hNew As Integer
        Dim hOld As Integer

        hNew = CreatePen(PS_SOLID, 1, g_lngSystemColor(COLOR_NUM.VERTICAL_SUB)) 'RGB(128, 128, 128)
        hOld = SelectObject(hDC, hNew)

        Y = g_disp.Y
        H = frmMain.picMain.ClientRectangle.Height

        '縦線(灰色)
        For i = 0 To UBound(g_VGrid)

            With g_VGrid(i)

                If .blnDraw Then

                    If .intCh Then

                        'Call PrintLine(.lngLeft + .intWidth, g_disp.Y, 0, frmMain.picMain.ScaleHeight)
                        Call PrintLine_Renamed(hDC, .lngLeft + .intWidth, Y, 0, H)

                    End If

                End If

            End With

        Next i

        hNew = SelectObject(hDC, hOld)
        Call DeleteObject(hNew)

    End Sub

    Private Sub DrawHorizonalLine(ByVal hDC As IntPtr)

        Dim i As Integer
        Dim j As Integer
        Dim W As Integer
        Dim intTemp As Short
        Dim hNew As Integer
        Dim hOld As Integer

        hNew = CreatePen(PS_SOLID, 1, g_lngSystemColor(COLOR_NUM.GRID_MAIN)) 'RGB(96, 96, 96)
        hOld = SelectObject(hDC, hNew)

        W = g_disp.lngMaxX - RIGHT_SPACE

        '横線(灰色)
        With frmMain.cboDispGridSub

            If DirectCast(frmMain.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData Then

                For i = g_disp.intStartMeasure To g_disp.intEndMeasure

                    intTemp = 192 \ DirectCast(frmMain.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData

                    For j = 0 To g_Measure(i).intLen Step intTemp

                        Call PrintLine_Renamed(hDC, LEFT_SPACE, g_Measure(i).lngY + j, W, 0)

                    Next j

                Next i

            End If

        End With


        hNew = SelectObject(hDC, hOld)
        Call DeleteObject(hNew)

        hNew = CreatePen(PS_SOLID, 1, g_lngSystemColor(COLOR_NUM.GRID_SUB)) 'RGB(192, 192, 192))
        hOld = SelectObject(hDC, hNew)

        W = g_disp.lngMaxX - FRAME_WIDTH

        '横線(灰色・補助)
        With frmMain.cboDispGridMain

            If DirectCast(frmMain.cboDispGridMain.SelectedItem, modMain.ItemWithData).ItemData Then

                For i = g_disp.intStartMeasure To g_disp.intEndMeasure

                    intTemp = 192 \ DirectCast(frmMain.cboDispGridMain.SelectedItem, modMain.ItemWithData).ItemData

                    For j = intTemp To g_Measure(i).intLen Step intTemp

                        'Call PrintLine(16, g_Measure(i).lngY + j, g_disp.lngMaxX - 16, 0)
                        Call PrintLine_Renamed(hDC, FRAME_WIDTH, g_Measure(i).lngY + j, W, 0)

                    Next j

                Next i

            End If

        End With

        hNew = SelectObject(hDC, hOld)
        Call DeleteObject(hNew)

    End Sub

    Private Sub DrawVerticalWhiteLine(ByVal hDC As IntPtr)

        Dim i As Integer
        Dim Y As Integer
        Dim H As Integer
        Dim hNew As Integer
        Dim hOld As Integer

        hNew = CreatePen(PS_SOLID, 1, g_lngSystemColor(COLOR_NUM.VERTICAL_MAIN))
        hOld = SelectObject(hDC, hNew)

        Y = g_disp.Y
        H = frmMain.picMain.ClientRectangle.Height

        '縦線(白)
        For i = 0 To UBound(g_VGrid)

            With g_VGrid(i)

                If .blnDraw = True Then

                    If .intCh = 0 Then

                        Call PrintLine_Renamed(hDC, .lngLeft, Y, 0, H)
                        Call PrintLine_Renamed(hDC, .lngLeft + .intWidth, Y, 0, H)

                    End If

                End If

            End With

        Next i

        hNew = SelectObject(hDC, hOld)
        Call DeleteObject(hNew)

    End Sub

    Private Sub DrawMeasureLine(ByVal hDC As IntPtr)

        Dim i As Integer
        Dim W As Integer
        Dim hNew As Integer
        Dim hOld As Integer

        hNew = CreatePen(hNew, 1, g_lngSystemColor(COLOR_NUM.MEASURE_LINE))
        hOld = SelectObject(hDC, hNew)

        W = g_disp.lngMaxX - FRAME_WIDTH

        '横線(白)
        For i = g_disp.intStartMeasure To g_disp.intEndMeasure

            'Call PrintLine(16, g_Measure(i).lngY, g_disp.lngMaxX - 16, 0)
            Call PrintLine_Renamed(hDC, FRAME_WIDTH, g_Measure(i).lngY, W, 0)

        Next i

        'If g_disp.intEndMeasure = 999 Then Call PrintLine(16, g_Measure(999).lngY + g_Measure(999).intLen, g_disp.lngMaxX - 16, 0)
        If g_disp.intEndMeasure = 999 Then

            Call PrintLine_Renamed(hDC, FRAME_WIDTH, g_Measure(999).lngY + g_Measure(999).intLen, g_disp.lngMaxX - FRAME_WIDTH, 0)

        End If

        hNew = SelectObject(hDC, hOld)
        Call DeleteObject(hNew)

    End Sub

    Private Sub DrawGridInfo(ByVal hDC As IntPtr)

        Dim i As Integer
        Dim j As Integer
        Dim X As Integer
        Dim lngLength As Integer
        Dim lngTemp As Integer
        Dim strTemp As String
        Dim sizeTemp As Size

        frmMain.stringFont = New Font(frmMain.stringFont.FontFamily, 9, frmMain.stringFont.Style, frmMain.stringFont.Unit, frmMain.stringFont.GdiCharSet, frmMain.stringFont.GdiVerticalFont)

        Dim hFont As IntPtr = frmMain.stringFont.ToHfont()
        Dim hOldFont As IntPtr = SelectObject(hDC, hFont)

        SetBkMode(hDC, TRANSPARENT)

        For i = 0 To UBound(g_VGrid) '文字

            With g_VGrid(i)

                If .blnDraw Then

                    If .intCh Then

                        If frmMain._mnuOptionsItem_2.Checked Then

                            'lngTemp = (.lngLeft + (.intWidth \ 2)) * g_disp.Width - g_disp.X
                            lngTemp = (.lngLeft + (.intWidth \ 2) - g_disp.X) * g_disp.Width

                            For j = 0 To Len(.strText) - 1

                                strTemp = Mid(.strText, j + 1, 1)
                                lngLength = LenB(strTemp)
                                Call GetTextExtentPoint32(hDC, strTemp, lngLength, sizeTemp)

                                X = lngTemp - sizeTemp.Width \ 2

                                '無理やり縁取り
                                Call SetTextColor(hDC, 0)
                                'Call TextOut(frmMain.picMain.hdc, X - 1, 0 + 11 * j, strTemp, lngLength)
                                Call TextOut(hDC, X, 0 + 11 * j, strTemp, lngLength)
                                'Call TextOut(frmMain.picMain.hdc, X + 1, 0 + 11 * j, strTemp, lngLength)
                                Call TextOut(hDC, X - 1, 1 + 11 * j, strTemp, lngLength)
                                Call TextOut(hDC, X + 1, 1 + 11 * j, strTemp, lngLength)
                                'Call TextOut(frmMain.picMain.hdc, X - 1, 2 + 11 * j, strTemp, lngLength)
                                Call TextOut(hDC, X, 2 + 11 * j, strTemp, lngLength)
                                'Call TextOut(frmMain.picMain.hdc, X + 1, 2 + 11 * j, strTemp, lngLength)
                                Call SetTextColor(hDC, g_lngSystemColor(COLOR_NUM.INFO))
                                Call TextOut(hDC, X, 1 + 11 * j, strTemp, lngLength)

                            Next j

                        Else

                            lngLength = LenB(.strText)
                            Call GetTextExtentPoint32(hDC, .strText, lngLength, sizeTemp)

                            'X = (.lngLeft + .intWidth \ 2) * g_disp.Width - (sizeTemp.Width) \ 2 - g_disp.X + 1
                            X = (.lngLeft + .intWidth \ 2 - g_disp.X) * g_disp.Width - (sizeTemp.Width) \ 2 + 1

                            '無理やり縁取り
                            Call SetTextColor(hDC, 0)
                            'Call TextOut(frmMain.picMain.hdc, X - 1, 0, .strText, lngLength)
                            Call TextOut(hDC, X, 0, .strText, lngLength)
                            'Call TextOut(frmMain.picMain.hdc, X + 1, 0, .strText, lngLength)
                            Call TextOut(hDC, X - 1, 1, .strText, lngLength)
                            Call TextOut(hDC, X + 1, 1, .strText, lngLength)
                            'Call TextOut(frmMain.picMain.hdc, X - 1, 2, .strText, lngLength)
                            Call TextOut(hDC, X, 2, .strText, lngLength)
                            'Call TextOut(frmMain.picMain.hdc, X + 1, 2, .strText, lngLength)
                            Call SetTextColor(hDC, g_lngSystemColor(COLOR_NUM.INFO))
                            Call TextOut(hDC, X, 1, .strText, lngLength)

                        End If

                    End If

                End If

            End With

        Next i

        SelectObject(hDC, hOldFont)
        DeleteObject(hFont)

    End Sub

    Private Sub PrintLine_Renamed(ByVal hDC As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer)

        Width = Width * g_disp.Width
        'X = X * g_disp.Width

        If X - g_disp.X < 0 Then

            'If Width Then Width = Width + (X - g_disp.X)
            If Width Then Width = Width + (X - g_disp.X) * g_disp.Width

            X = 0

        Else

            'X = X - g_disp.X
            X = (X - g_disp.X) * g_disp.Width

        End If

        If Y + g_disp.Y < 0 Then

            If Height Then Height = Height + (Y - g_disp.Y)

            Y = 0

        Else

            Y = (Y - g_disp.Y) * g_disp.Height

        End If

        Call MoveToEx(hDC, X, frmMain.picMain.ClientRectangle.Height - 1 - Y, 0)
        Call LineTo(hDC, X + Width, frmMain.picMain.ClientRectangle.Height - 1 - Y - Height)

    End Sub

    Public Sub DrawObj(ByVal gp As Graphics, ByRef tempObj As g_udtObj)
        On Error GoTo Err_Renamed

        Dim intTemp As Short
        Dim Text As String
        Dim strArray() As String
        Dim X As Integer
        Dim Y As Integer
        Dim Width As Short
        Dim sizeTemp As Size
        Dim intLightNum As Short
        Dim intShadowNum As Short
        Dim intBrushNum As Short
        Dim hOldBrush As Integer
        Dim hOldPen As Integer

        Dim hDC As IntPtr = gp.GetHdc()

        With tempObj

            If g_intVGridNum(.intCh) = 0 Then
                gp.ReleaseHdc()
                Exit Sub
            End If

            X = (g_VGrid(g_intVGridNum(.intCh)).lngObjLeft - g_disp.X) * g_disp.Width + 1
            Y = frmMain.picMain.ClientRectangle.Height + OBJ_DIFF - (g_Measure(.intMeasure).lngY + .lngPosition - g_disp.Y) * g_disp.Height
            Width = GRID_WIDTH * g_disp.Width - 1

            '文字列の決定
            Select Case .intCh

                Case modInput.OBJ_CH.CH_BPM, modInput.OBJ_CH.CH_EXBPM, modInput.OBJ_CH.CH_STOP

                    Text = CStr(.sngValue)

                Case modInput.OBJ_CH.CH_BGA, modInput.OBJ_CH.CH_POOR, modInput.OBJ_CH.CH_LAYER

                    Text = g_strBMP(.sngValue)

                    If frmMain._mnuOptionsItem_6.Checked = True And Len(Text) <> 0 Then

                        strArray = Split(Text, ".")
                        Text = Left(Text, Len(Text) - (Len(strArray(UBound(strArray))) + 1))

                    Else

                        Text = modInput.strFromNum(.sngValue)

                    End If

                Case Else

                    Text = g_strWAV(.sngValue)

                    If frmMain._mnuOptionsItem_6.Checked = True And Len(Text) <> 0 Then

                        strArray = Split(Text, ".")
                        Text = Left(Text, Len(Text) - (Len(strArray(UBound(strArray))) + 1))

                    Else

                        Text = modInput.strFromNum(.sngValue)

                    End If

                    'ロングノート
                    If (.intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE Or (50 < .intCh And .intCh < 69)) And .intCh < 100 Then

                        X = X + 3
                        Width = Width - 6

                    End If

                    'ロングノートの場合、仮オブジェを生成
                    If .intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE And 10 < .intCh And .intCh < 30 Then

                        m_tempObj(UBound(m_tempObj)) = tempObj
                        m_tempObj(UBound(m_tempObj)).intCh = .intCh + 40

                        ReDim Preserve m_tempObj(UBound(m_tempObj) + 1)

                        'Exit Sub

                    End If

            End Select

            '色の決定
            Select Case .intSelect

                Case modMain.OBJ_SELECT.NON_SELECT, modMain.OBJ_SELECT.SELECTAREA_IN, modMain.OBJ_SELECT.SELECTAREA_OUT, modMain.OBJ_SELECT.SELECTAREA_SELECTED

                    If .intCh < 10 Or 100 < .intCh Then

                        intLightNum = g_VGrid(g_intVGridNum(.intCh)).intLightNum
                        intShadowNum = g_VGrid(g_intVGridNum(.intCh)).intShadowNum
                        intBrushNum = g_VGrid(g_intVGridNum(.intCh)).intBrushNum

                    ElseIf 50 < .intCh Then  'ロングノート

                        intLightNum = PEN_NUM.LONGNOTE_LIGHT
                        intShadowNum = PEN_NUM.LONGNOTE_SHADOW
                        intBrushNum = BRUSH_NUM.LONGNOTE

                    Else

                        If .intAtt = modMain.OBJ_ATT.OBJ_NORMAL Then

                            intLightNum = g_VGrid(g_intVGridNum(.intCh)).intLightNum
                            intShadowNum = g_VGrid(g_intVGridNum(.intCh)).intShadowNum
                            intBrushNum = g_VGrid(g_intVGridNum(.intCh)).intBrushNum

                        Else 'If .intAtt =OBJ_INVISIBLE  Then

                            intTemp = .intCh Mod 10

                            Select Case .intCh

                                Case 11 To 15

                                    intLightNum = PEN_NUM.INV_KEY01_LIGHT + intTemp - 1
                                    intShadowNum = PEN_NUM.INV_KEY01_SHADOW + intTemp - 1
                                    intBrushNum = BRUSH_NUM.INV_KEY01 + intTemp - 1

                                Case 18

                                    intLightNum = PEN_NUM.KEY06_LIGHT
                                    intShadowNum = PEN_NUM.INV_KEY06_SHADOW
                                    intBrushNum = BRUSH_NUM.INV_KEY06

                                Case 19

                                    intLightNum = PEN_NUM.KEY07_LIGHT
                                    intShadowNum = PEN_NUM.INV_KEY07_SHADOW
                                    intBrushNum = BRUSH_NUM.INV_KEY07

                                Case 16

                                    intLightNum = PEN_NUM.KEY08_LIGHT
                                    intShadowNum = PEN_NUM.INV_KEY08_SHADOW
                                    intBrushNum = BRUSH_NUM.INV_KEY08

                                Case 21 To 25

                                    intLightNum = PEN_NUM.INV_KEY11_LIGHT + intTemp - 1
                                    intShadowNum = PEN_NUM.INV_KEY11_SHADOW + intTemp - 1
                                    intBrushNum = BRUSH_NUM.INV_KEY11 + intTemp - 1

                                Case 28

                                    intLightNum = PEN_NUM.KEY16_LIGHT
                                    intShadowNum = PEN_NUM.INV_KEY16_SHADOW
                                    intBrushNum = BRUSH_NUM.INV_KEY16

                                Case 29

                                    intLightNum = PEN_NUM.KEY17_LIGHT
                                    intShadowNum = PEN_NUM.INV_KEY17_SHADOW
                                    intBrushNum = BRUSH_NUM.INV_KEY17

                                Case 26

                                    intLightNum = PEN_NUM.KEY18_LIGHT
                                    intShadowNum = PEN_NUM.INV_KEY18_SHADOW
                                    intBrushNum = BRUSH_NUM.INV_KEY18

                            End Select

                        End If

                    End If

                Case modMain.OBJ_SELECT.Selected '通常選択

                    intLightNum = PEN_NUM.SELECT_OBJ_LIGHT
                    intShadowNum = PEN_NUM.SELECT_OBJ_SHADOW
                    intBrushNum = BRUSH_NUM.SELECT_OBJ

                Case Else

                    If .intSelect = modMain.OBJ_SELECT.EDIT_RECT Then '白枠(編集モード)

                        intLightNum = PEN_NUM.EDIT_FRAME

                    Else 'if .intSelect = DELETE_RECT Then '赤枠(消去モード)

                        intLightNum = PEN_NUM.DELETE_FRAME

                    End If

                    intBrushNum = UBound(m_hBrush)

                    hOldBrush = SelectObject(hDC, m_hBrush(intBrushNum))
                    hOldPen = SelectObject(hDC, m_hPen(intLightNum))

                    Call Rectangle(hDC, X - 1, Y - OBJ_HEIGHT - 1, X + Width + 1, Y + 2)

                    m_hPen(intLightNum) = SelectObject(hDC, hOldPen)
                    m_hBrush(intBrushNum) = SelectObject(hDC, hOldBrush)

                    gp.ReleaseHdc()
                    Exit Sub

            End Select

        End With

        With frmMain.picMain

            hOldBrush = SelectObject(hDC, m_hBrush(intBrushNum))
            hOldPen = SelectObject(hDC, m_hPen(intLightNum))

            Call Rectangle(hDC, X, Y - OBJ_HEIGHT, X + Width, Y + 1)

            m_hPen(intLightNum) = SelectObject(hDC, m_hPen(intShadowNum))

            Call MoveToEx(hDC, X, Y, 0)
            Call LineTo(hDC, X + Width - 1, Y)
            Call LineTo(hDC, X + Width - 1, Y - OBJ_HEIGHT)

            m_hPen(intShadowNum) = SelectObject(hDC, hOldPen)
            m_hBrush(intBrushNum) = SelectObject(hDC, hOldBrush)

            'Text = g_Obj(lngNum).lngID
            intTemp = LenB(Text)

            Call GetTextExtentPoint32(hDC, Text, intTemp, sizeTemp)

            Y = Y - (OBJ_HEIGHT + sizeTemp.Height) \ 2 + 1

            Dim hFont As IntPtr = frmMain.stringFont.ToHfont()
            Dim hOldFont As IntPtr = SelectObject(hDC, hFont)

            SetBkMode(hDC, TRANSPARENT)

            'If g_Obj(lngNum).intSelect = Selected Then
            If tempObj.intSelect = modMain.OBJ_SELECT.Selected Then

                Call SetTextColor(hDC, &HFFFFFF)
                Call TextOut(hDC, X + 3, Y, Text, intTemp)
                Call SetTextColor(hDC, &H0)
                Call TextOut(hDC, X + 2, Y, Text, intTemp)

            Else

                Call SetTextColor(hDC, &H0)
                Call TextOut(hDC, X + 3, Y, Text, intTemp)
                Call SetTextColor(hDC, &HFFFFFF)
                Call TextOut(hDC, X + 2, Y, Text, intTemp)

            End If

            SelectObject(hDC, hOldFont)
            DeleteObject(hFont)

        End With

        gp.ReleaseHdc()
        Exit Sub

Err_Renamed:
        gp.ReleaseHdc()
        Call modMain.CleanUp(Err.Number, Err.Description, "DrawObj")
    End Sub

    Public Sub DrawObjRect(ByVal hDC As IntPtr, ByVal Num As Integer)
        On Error GoTo Err_Renamed

        Dim X As Integer
        Dim Y As Integer
        Dim Width As Short

        With g_Obj(Num)

            If g_intVGridNum(.intCh) = 0 Then Exit Sub

            'X = g_VGrid(g_intVGridNum(.intCh)).lngObjLeft * g_disp.Width - g_disp.X + 1
            X = (g_VGrid(g_intVGridNum(.intCh)).lngObjLeft - g_disp.X) * g_disp.Width + 1
            Y = frmMain.picMain.ClientRectangle.Height + OBJ_DIFF - (g_Measure(.intMeasure).lngY + .lngPosition - g_disp.Y) * g_disp.Height
            Width = GRID_WIDTH * g_disp.Width - 1

            If .intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE Or (.intCh >= 51 And .intCh <= 69) Then

                X = X + 3
                Width = Width - 6

            End If

        End With

        With frmMain.picMain

            Call Rectangle(hDC, X - 1, Y - OBJ_HEIGHT - 1, X + Width + 1, Y + 2)

        End With

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "DrawObjRect")
    End Sub

    Public Sub DrawObjMax(ByVal X As Single, ByVal Y As Single, ByVal Shift As Short)
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim lngTemp As Integer '一時変数
        Dim tempObj As g_udtObj '一時オブジェ

        'マウスの状態を変数に保存
        With g_Mouse

            .Shift = Shift
            .X = X
            .Y = Y

        End With

        '入力無視が有効ならさよなら
        If g_blnIgnoreInput Then Exit Sub

        '一時オブジェにデータを格納する
        Call SetObjData(tempObj, X, Y) ', g_disp.X, g_disp.Y)

        With tempObj

            If DirectCast(frmMain.tlbMenu.Items.Item("Write"), ToolStripButton).Checked = True Then '書き込みモード

                If 10 < .intCh And .intCh < 30 Then 'オブジェはキーオブジェである

                    If Shift And Keys.Control Then '不可視オブジェ

                        .intAtt = modMain.OBJ_ATT.OBJ_INVISIBLE

                    ElseIf Shift And Keys.Shift Then  'ロングノート

                        .intCh = .intCh + 40
                        .intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE

                    End If

                End If

                'オブジェ位置をグリッドにあわせる
                'If Shift And vbAltMask Then

                If DirectCast(frmMain.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData Then

                    lngTemp = 192 \ (DirectCast(frmMain.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData)
                    .lngPosition = (.lngPosition \ lngTemp) * lngTemp

                End If

                'End If

            End If

        End With

        'If frmMain.tlbMenu.Buttons("Write").value = tbrUnpressed Then '書き込みモード

        With tempObj

            lngTemp = g_Measure(.intMeasure).lngY + .lngPosition

            For i = UBound(g_Obj) - 1 To 0 Step -1

                If (g_Obj(i).intCh = .intCh) Or (.intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE And g_Obj(i).intCh + 40 = .intCh) Then

                    If g_Measure(g_Obj(i).intMeasure).lngY + g_Obj(i).lngPosition + OBJ_HEIGHT / g_disp.Height >= lngTemp And g_Measure(g_Obj(i).intMeasure).lngY + g_Obj(i).lngPosition <= lngTemp Then

                        If DirectCast(frmMain.tlbMenu.Items.Item("Write"), ToolStripButton).Checked = False Then

                            If DirectCast(frmMain.tlbMenu.Items.Item("Edit"), ToolStripButton).Checked = True Then

                                .intSelect = modMain.OBJ_SELECT.EDIT_RECT

                            ElseIf DirectCast(frmMain.tlbMenu.Items.Item("Delete"), ToolStripButton).Checked = True Then

                                .intSelect = modMain.OBJ_SELECT.DELETE_RECT

                            End If

                            .intAtt = g_Obj(i).intAtt

                            If .intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE Then .intCh = .intCh + 40

                            .sngValue = g_Obj(i).sngValue
                            .lngPosition = g_Obj(i).lngPosition
                            .intMeasure = g_Obj(i).intMeasure
                            .lngHeight = i

                        End If

                        '.lngHeight = i

                        '.lngPosition = g_Obj(i).lngPosition
                        'とりあえず切っておいたよ、その代わり上に追加しておいた v1.1.7
                        '↑何のために消したのかわからねー上にバグるので復活させました v1.2.3
                        '↑これ消さないと書き込みモード時にオブジェに吸い込まれる。で、何がバグったんだっけ？ v1.3.0
                        '↑小節をまたがるオブジェに関してえらいことになる。どーしよう。 v1.3.5
                        '↓これを上に移動して解決？した？かも？ v1.3.6
                        'これがないと書き込みモード時の右クリック削除がうまく動かないのかも？ v1.3.9
                        '.intMeasure = g_Obj(i).intMeasure

                        .lngHeight = i

                        Exit For

                    End If

                End If

            Next i

        End With

        'End If

        'ステータスバー更新
        Call DrawStatusBar(tempObj, Shift)

        If DirectCast(frmMain.tlbMenu.Items.Item("Write"), ToolStripButton).Checked = True Then '書き込みモード

            If tempObj.intCh <> g_Obj(UBound(g_Obj)).intCh Or tempObj.intAtt <> g_Obj(UBound(g_Obj)).intAtt Or tempObj.intMeasure <> g_Obj(UBound(g_Obj)).intMeasure Or tempObj.lngPosition <> g_Obj(UBound(g_Obj)).lngPosition Or tempObj.sngValue <> g_Obj(UBound(g_Obj)).sngValue Then

                g_Obj(UBound(g_Obj)) = tempObj
                g_lngObjID(g_Obj(UBound(g_Obj)).lngID) = UBound(g_Obj)

            Else

                g_Obj(UBound(g_Obj)).lngHeight = tempObj.lngHeight

                Exit Sub

            End If

        Else '書き込みモード以外

            '描画すべきオブジェはない
            If tempObj.intSelect <> modMain.OBJ_SELECT.EDIT_RECT And tempObj.intSelect <> modMain.OBJ_SELECT.DELETE_RECT Then

                tempObj.intCh = 0
                g_Obj(UBound(g_Obj)).intCh = 0

            End If

            'If tempObj.intCh <> g_Obj(UBound(g_Obj)).intCh Or tempObj.intAtt <> g_Obj(UBound(g_Obj)).intAtt Or g_Measure(tempObj.intMeasure).lngY + tempObj.lngPosition > g_Measure(g_Obj(UBound(g_Obj)).intMeasure).lngY + g_Obj(UBound(g_Obj)).lngPosition + OBJ_HEIGHT / g_disp.Height Or g_Measure(tempObj.intMeasure).lngY + tempObj.lngPosition < g_Measure(g_Obj(UBound(g_Obj)).intMeasure).lngY + g_Obj(UBound(g_Obj)).lngPosition Then
            If tempObj.lngHeight <> g_Obj(UBound(g_Obj)).lngHeight Then

                If g_Obj(tempObj.lngHeight).intCh Then tempObj.lngPosition = g_Obj(tempObj.lngHeight).lngPosition

                g_Obj(UBound(g_Obj)) = tempObj
                g_lngObjID(g_Obj(UBound(g_Obj)).lngID) = UBound(g_Obj)

            Else

                Exit Sub

            End If

        End If

        'Call DrawStatusBar(UBound(g_Obj), Shift)

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "DrawObjMax")
    End Sub

    Public Sub SetObjData(ByRef tempObj As g_udtObj, ByVal X As Single, ByVal Y As Single) ', ByVal g_disp.x As Long, ByVal g_disp.y As Long)

        Dim i As Integer
        Dim lngTemp As Integer

        If X < 0 Then

            X = 0

        ElseIf frmMain.picMain.ClientRectangle.Width < X Then

            X = frmMain.picMain.ClientRectangle.Width

        End If

        'lngTemp = (X + g_disp.X) / g_disp.Width
        lngTemp = X / g_disp.Width + g_disp.X

        tempObj.intCh = 8

        For i = 0 To UBound(g_VGrid)

            With g_VGrid(i)

                If .blnDraw = True And .intCh <> 0 Then

                    If .lngLeft <= lngTemp Then

                        tempObj.intCh = .intCh

                    Else

                        Exit For

                    End If

                End If

            End With

        Next i

        With tempObj

            .lngID = g_lngIDNum
            .lngHeight = UBound(g_Obj)

            If Y < 1 Then

                Y = 1

            ElseIf frmMain.picMain.ClientRectangle.Height + OBJ_DIFF < Y Then

                Y = frmMain.picMain.ClientRectangle.Height + OBJ_DIFF

            End If

            lngTemp = (frmMain.picMain.ClientRectangle.Height - Y + OBJ_DIFF) / g_disp.Height + g_disp.Y

            'For i = g_Disp.intStartMeasure To g_Disp.intEndMeasure
            For i = 0 To 999

                If g_Measure(i).lngY <= lngTemp Then

                    .intMeasure = i
                    .lngPosition = lngTemp - g_Measure(i).lngY

                    If g_Measure(i).intLen < .lngPosition Then .lngPosition = g_Measure(i).intLen - 1

                Else

                    Exit For

                End If

            Next i

            Select Case .intCh

                Case 3, 8, 9

                    .sngValue = 0

                Case 4, 6, 7

                    'If frmMain.mnuOptionsItem(USE_OLD_FORMAT).Checked Then

                    '.sngValue = strToNum(Hex$(frmMain.lstBMP.ListIndex + 1))

                    'Else

                    '.sngValue = frmMain.lstBMP.ListIndex + 1

                    'End If

                    .sngValue = frmMain.lngFromLong(frmMain.lstBMP.SelectedIndex + 1)

                Case Else

                    'If frmMain.mnuOptionsItem(USE_OLD_FORMAT).Checked Then

                    '.sngValue = strToNum(Hex$(frmMain.lstWAV.ListIndex + 1))

                    'Else

                    '.sngValue = frmMain.lstWAV.ListIndex + 1

                    'End If

                    .sngValue = frmMain.lngFromLong(frmMain.lstWAV.SelectedIndex + 1)

            End Select

        End With

    End Sub

    'Public Sub DrawStatusBar(ByVal ObjNum As Long, ByVal Shift As Integer)
    Public Sub DrawStatusBar(ByRef tempObj As g_udtObj, ByVal Shift As Short)
        Dim strTemp As String
        Dim lngTemp As Integer
        Dim strArray() As String

        'With g_Obj(ObjNum)
        With tempObj

            '小節
            strTemp = "Position:  " & .intMeasure & g_strStatusBar(23) & "  "
            g_Mouse.measure = .intMeasure

            'If Not Shift And vbAltMask Then

            lngTemp = DirectCast(frmMain.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData

            'End If

            'グリッド
            If lngTemp Then

                If .intSelect > modMain.OBJ_SELECT.Selected And .lngPosition <> 0 Then

                    lngTemp = modInput.intGCD(.lngPosition, g_Measure(.intMeasure).intLen)

                    If 192 \ DirectCast(frmMain.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData < lngTemp Then

                        lngTemp = DirectCast(frmMain.cboDispGridSub.SelectedItem, modMain.ItemWithData).ItemData

                    Else

                        lngTemp = 192 \ lngTemp

                    End If

                End If

                strTemp = strTemp & .lngPosition * lngTemp \ 192 & "/" & g_Measure(.intMeasure).intLen * lngTemp \ 192

            Else

                strTemp = strTemp & .lngPosition & "/" & g_Measure(.intMeasure).intLen

            End If

            strTemp = strTemp & "  "

            'キー名
            Select Case .intCh

                Case Is > 100

                    strTemp = strTemp & g_strStatusBar(1) & " " & Format(.intCh - 100, "00")

                Case Is < 10

                    strTemp = strTemp & g_strStatusBar(.intCh)

                Case 11 To 15

                    strTemp = strTemp & g_strStatusBar(11) & .intCh - 10

                Case 16

                    strTemp = strTemp & g_strStatusBar(13)

                Case 18, 19

                    strTemp = strTemp & g_strStatusBar(11) & .intCh - 12

                Case 21 To 25

                    strTemp = strTemp & g_strStatusBar(12) & .intCh - 20

                Case 26

                    strTemp = strTemp & g_strStatusBar(14)

                Case 28, 29

                    strTemp = strTemp & g_strStatusBar(12) & .intCh - 22

                Case 51 To 55

                    strTemp = strTemp & g_strStatusBar(11) & .intCh - 50

                Case 56

                    strTemp = strTemp & g_strStatusBar(13)

                Case 58, 59

                    strTemp = strTemp & g_strStatusBar(11) & .intCh - 52

                Case 61 To 65

                    strTemp = strTemp & g_strStatusBar(12) & .intCh - 60

                Case 66

                    strTemp = strTemp & g_strStatusBar(14)

                Case 68, 69

                    strTemp = strTemp & g_strStatusBar(12) & .intCh - 62


            End Select

            '不可視 or ロングノート
            If 10 < .intCh And .intCh < 30 Then

                If .intAtt = modMain.OBJ_ATT.OBJ_INVISIBLE Then

                    strTemp = strTemp & " " & g_strStatusBar(15)

                ElseIf .intAtt = modMain.OBJ_ATT.OBJ_LONGNOTE Then

                    strTemp = strTemp & " " & g_strStatusBar(16)

                End If

            ElseIf 50 < .intCh And .intCh < 70 Then

                'If lngChangeMaxMeasure(.intMeasure) Then Call ChangeResolution

                strTemp = strTemp & " " & g_strStatusBar(16)

            End If

            frmMain.staMain.Items.Item("Position").Text = strTemp

            strArray = Split(Mid(modMain.GetItemString(frmMain.lstMeasureLen, .intMeasure), 6), "/")

            frmMain.staMain.Items.Item("Measure").Text = Right(" " & strArray(0), 2) & "/" & Left(strArray(1) & " ", 2)

        End With

    End Sub

    Public Sub DrawSelectArea(ByVal gp As Graphics)
        Dim i As Integer
        Dim lngTemp As Integer
        Dim hOldPen As Integer
        Dim hNewPen As Integer
        Dim objBrush As LOGBRUSH
        Dim hOldBrush As Integer
        Dim hNewBrush As Integer
        Dim rectTemp As RECT

        Dim hDC As IntPtr = gp.GetHdc()

        hNewPen = CreatePen(PS_SOLID, 1, g_lngPenColor(PEN_NUM.EDIT_FRAME))
        hOldPen = SelectObject(hDC, hNewPen)

        With objBrush
            .lbStyle = BS_NULL
            .lbColor = 0
            .lbHatch = BS_NULL
        End With

        'hNewBrush = CreateHatchBrush(HS_BDIAGONAL, g_lngPenColor(PEN_NUM.EDIT_FRAME))
        hNewBrush = CreateBrushIndirect(objBrush)
        hOldBrush = SelectObject(hDC, hNewBrush)

        With rectTemp

            .Top = (g_SelectArea.Y1 - g_disp.Y) * -g_disp.Height + frmMain.picMain.ClientRectangle.Height
            '.Left = g_SelectArea.X1 * g_disp.Width - g_disp.X
            .left_Renamed = (g_SelectArea.X1 - g_disp.X) * g_disp.Width
            .right_Renamed = g_Mouse.X
            .Bottom = g_Mouse.Y

            Call Rectangle(hDC, .left_Renamed, .Top, .right_Renamed, .Bottom)

        End With

        For i = 0 To UBound(g_Obj) - 1

            With g_Obj(i)

                If .intSelect = modMain.OBJ_SELECT.SELECTAREA_IN Or .intSelect = modMain.OBJ_SELECT.SELECTAREA_OUT Then

                    lngTemp = g_Measure(.intMeasure).lngY + .lngPosition

                    If g_disp.lngStartPos <= lngTemp And lngTemp <= g_disp.lngEndPos Then

                        Call modDraw.DrawObjRect(hDC, i)

                    End If

                End If

            End With

        Next i

        hNewPen = SelectObject(hDC, hOldPen)
        Call DeleteObject(hNewPen)

        hNewBrush = SelectObject(hDC, hOldBrush)
        Call DeleteObject(hNewBrush)

        gp.ReleaseHdc()
    End Sub

    Public Function lngChangeMaxMeasure(ByVal intMeasure As Short) As Integer

        With g_disp

            If .intMaxMeasure < intMeasure + 16 Then

                .intMaxMeasure = intMeasure + 16

                If 999 < g_disp.intMaxMeasure Then .intMaxMeasure = 999

                lngChangeMaxMeasure = 1

            End If

        End With

    End Function

    Public Sub ChangeResolution()

        Dim i As Integer
        Dim intTemp As Short
        Dim lngTemp As Integer
        Dim sngTemp As Single

        With g_disp

            intTemp = .intResolution

            For i = 0 To .intMaxMeasure

                lngTemp = lngTemp + g_Measure(i).intLen

            Next i

            'sngTemp = 96 / (((64 / 4) * 1000 * 2) / (lngTemp / 96))
            sngTemp = lngTemp / 32000

            Select Case sngTemp
                Case Is > 48
                    .intResolution = 96
                Case Is > 24
                    .intResolution = 48
                Case Is > 12
                    .intResolution = 24
                Case Is > 6
                    .intResolution = 12
                Case Is > 3
                    .intResolution = 6
                Case Is > 1
                    .intResolution = 3
                Case Else
                    .intResolution = 1
            End Select

            If intTemp = .intResolution Then Exit Sub

            frmMain.vsbMain.Value = (frmMain.vsbMain.Value / .intResolution) * intTemp

        End With

        With frmMain.cboVScroll

            Call .Items.Clear()
            intTemp = 0

            'For i = 0 To 6
            For i = 1 To 6

                'lngTemp = 2 ^ (i - 1) * 3
                'If i = 0 Then lngTemp = 1
                lngTemp = 2 ^ i * 3

                If g_disp.intResolution <= lngTemp Then

                    Call .Items.Insert(intTemp, New modMain.ItemWithData(CStr(lngTemp), lngTemp \ g_disp.intResolution))

                    intTemp = intTemp + 1

                End If

            Next i

            .SelectedIndex = .Items.Count - 2

        End With

    End Sub

    Public Sub RemoveObj(ByVal lngNum As Integer)
        On Error GoTo Err_Renamed

        With g_Obj(lngNum)
            g_lngObjID(.lngID) = -1
            .lngID = 0
            .intCh = 0
            .lngHeight = 0
            .intMeasure = 0
            .lngPosition = 0
            .intSelect = modMain.OBJ_SELECT.NON_SELECT
            .sngValue = 0
            .intAtt = modMain.OBJ_ATT.OBJ_NORMAL
        End With

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "RemoveObj")
    End Sub

    Public Sub ArrangeObj()

        Dim i As Integer
        Dim lngTemp As Integer

        For i = 0 To UBound(g_Obj) - 1

            If g_Obj(i).intCh Then

                Call modInput.SwapObj(lngTemp, i)

                If i = g_Obj(UBound(g_Obj)).lngHeight Then g_Obj(UBound(g_Obj)).lngHeight = lngTemp

                lngTemp = lngTemp + 1

            End If

        Next i

        g_Obj(lngTemp) = g_Obj(UBound(g_Obj))

        ReDim Preserve g_Obj(lngTemp)

    End Sub

    '選択されたオブジェを配列の後ろに移動する
    Public Sub MoveSelectedObj()
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim j As Integer
        Dim lngTemp As Integer

        For i = 0 To UBound(g_Obj) - 1

            If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                lngTemp = lngTemp + 1

            End If

        Next i

        If lngTemp = 0 Then Exit Sub

        j = UBound(g_Obj)

        ReDim Preserve g_Obj(j + lngTemp)

        Call modInput.SwapObj(UBound(g_Obj), j)

        lngTemp = 0

        For i = 0 To j - 1

            If g_Obj(i).intSelect <> modMain.OBJ_SELECT.NON_SELECT Then

                Call modInput.SwapObj(i, j + lngTemp)

                If i = g_Obj(UBound(g_Obj)).lngHeight Then g_Obj(UBound(g_Obj)).lngHeight = j + lngTemp

                lngTemp = lngTemp + 1

            End If

        Next i

        Call ArrangeObj()

        Exit Sub

Err_Renamed:
        Call modMain.CleanUp(Err.Number, Err.Description, "MoveSelectedObj")
    End Sub

    Public Sub ObjSelectCancel()
        Dim i As Integer

        For i = 0 To UBound(g_Obj) - 1

            g_Obj(i).intSelect = modMain.OBJ_SELECT.NON_SELECT

        Next i

    End Sub

    Public Sub InitPen()

        Dim i As Integer
        Dim objBrush As LOGBRUSH

        'ペン生成

        For i = 0 To UBound(m_hPen)

            m_hPen(i) = CreatePen(PS_SOLID, 1, g_lngPenColor(i))

        Next i

        'ブラシ生成

        For i = 0 To UBound(m_hBrush) - 1

            m_hBrush(i) = CreateSolidBrush(g_lngBrushColor(i))

        Next i

        With objBrush

            .lbStyle = BS_NULL
            .lbColor = 0
            .lbHatch = BS_NULL

        End With

        m_hBrush(UBound(m_hBrush)) = CreateBrushIndirect(objBrush)

    End Sub

    Public Sub DeletePen()

        Dim i As Integer

        'ペン削除
        For i = 0 To UBound(m_hPen)

            Call DeleteObject(m_hPen(i))

        Next i

        'ブラシ削除
        For i = 0 To UBound(m_hBrush)

            Call DeleteObject(m_hBrush(i))

        Next i

    End Sub
End Module
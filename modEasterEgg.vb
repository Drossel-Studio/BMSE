Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module modEasterEgg
	
	Private Declare Function StretchBlt Lib "gdi32" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As Integer, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal nSrcWidth As Integer, ByVal nSrcHeight As Integer, ByVal dwRop As Integer) As Integer
    Private Declare Function DrawText Lib "user32" Alias "DrawTextA" (ByVal hdc As Integer, ByRef lpStr As String, ByVal nCount As Integer, ByRef lpRect As RECT, ByVal wFormat As Integer) As Integer

    Private Const DT_WORDBREAK As Integer = &H10
	
	Public Enum EASTEREGG
		OFF
		TIPS
		RASTER
		SNOW
		SIROMARU
		NOISE
		STORM
		SIROMARU2
		SIROMARU3
		DISP_LOG
		STAFFROLL
		STAFFROLL2
		G20
		BLUESCREEN
		Max
	End Enum
	
	Private Structure m_udtSnow
		Dim X As Single
		Dim Y As Single
		Dim dX As Single
		Dim dY As Single
		Dim counter As Integer
		Dim Angle As Short
	End Structure
	
	Private m_objSnow() As m_udtSnow
	
	'Private m_sngRaster(511)    As Single
	'Private m_lngRasterHeight   As Long
	Private m_lngCounter As Integer
	
	Private m_strStaffRoll() As String

    Public Sub InitEffect()
        'modInput.LoadBMSEnd にエイプリルフール用コードあり
        'If strGet_ini("EasterEgg", "Snow", False, "bmse.ini") = True Or (Month(Now) = 12 And Day(Now) = 25) Then
        'UPGRADE_WARNING: オブジェクト strGet_ini(EasterEgg, Snow, False, bmse.ini) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If strGet_ini("EasterEgg", "Snow", False, "bmse.ini") Then

            'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_disp.intEffect = EASTEREGG.SNOW

            Call modEasterEgg.InitSnow()

            'UPGRADE_WARNING: オブジェクト strGet_ini(EasterEgg, siromaru, False, bmse.ini) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ElseIf strGet_ini("EasterEgg", "siromaru", False, "bmse.ini") Then

            'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_disp.intEffect = EASTEREGG.SIROMARU

            Call modEasterEgg.InitSnow()

            'ElseIf Month(Now) = 12 And (Day(Now) = 24 Or Day(Now) = 25) And strGet_ini("EasterEgg", "Snow", True, "bmse.ini") = True Then
            'UPGRADE_WARNING: オブジェクト strGet_ini(EasterEgg, Snow, True, bmse.ini) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ElseIf Month(Now) = 12 And VB.Day(Now) = 25 And strGet_ini("EasterEgg", "Snow", True, "bmse.ini") = True Then

            'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            g_disp.intEffect = EASTEREGG.SNOW

            Call modEasterEgg.InitSnow()

            g_strAppTitle = g_strAppTitle & " (Xmas mode: Only once!)"
            frmMain.Text = g_strAppTitle

            'UPGRADE_WARNING: オブジェクト modMain.lngSet_ini の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call modMain.lngSet_ini("EasterEgg", "Snow", False)

        End If

    End Sub

    Public Sub LoadEffect()
        If Month(Now) = 2 And VB.Day(Now) = 15 Then 'シロマルの誕生日

            'UPGRADE_WARNING: オブジェクト g_BMS.strArtist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If g_BMS.strArtist = "siromaru" Then

                'UPGRADE_WARNING: オブジェクト modMain.strGet_ini の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If modMain.strGet_ini("EasterEgg", "siromaru", False, "bmse.ini") = False And modMain.strGet_ini("EasterEgg", "siromaru", True, "bmse.ini") = True Then

                    'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    g_disp.intEffect = EASTEREGG.SIROMARU

                    Call modEasterEgg.InitSnow()

                    'Call modMain.lngSet_ini("EasterEgg", "siromaru", False)

                End If

            End If

        End If

    End Sub
	
	Public Sub EndEffect()
        Dim strTemp As String

        If frmMain.tmrEffect.Enabled Then
			
			'If Month(Now) = 4 And Day(Now) = 1 And g_disp.intEffect = RASTER Then 'April Fool
			'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Month(Now) = 2 And VB.Day(Now) = 15 And g_disp.intEffect = EASTEREGG.SIROMARU Then 'シロマルの誕生日
				
				'If modMain.strGet_ini("EasterEgg", "RasterScroll", False, "bmse.ini") = False And modMain.strGet_ini("EasterEgg", "RasterScroll", True, "bmse.ini") = True Then
				'UPGRADE_WARNING: オブジェクト modMain.strGet_ini の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If modMain.strGet_ini("EasterEgg", "siromaru", False, "bmse.ini") = False And modMain.strGet_ini("EasterEgg", "siromaru", True, "bmse.ini") = True Then
					
					'strTemp = "エイプリル・フールだというのにわざわざ BMSE を使ってくれてありがとう!"
					'strTemp = strTemp & vbCrLf & "Thank you for using BMSE on April Fool's Day!"
					'strTemp = strTemp & vbCrLf & "びっくりしたかな?"
					'strTemp = strTemp & vbCrLf & "Were you surprised?"
					'strTemp = strTemp & vbCrLf
					'strTemp = strTemp & vbCrLf & "さて、この演出は今回限りだから安心してほしい。"
					'strTemp = strTemp & vbCrLf & "So, be relieved that this effect is only once."
					'strTemp = strTemp & vbCrLf & "それじゃ、、、"
					'strTemp = strTemp & vbCrLf & "Well..."
					'strTemp = strTemp & vbCrLf & """また後でな (ニヤリ)"""
					'strTemp = strTemp & vbCrLf & """BE SEEING YOU! (GRIN)"""
					
					strTemp = "A Happy New Year!"
					strTemp = strTemp & vbCrLf & "本年もよろしくお願いします。"
					strTemp = strTemp & vbCrLf
					strTemp = strTemp & vbCrLf & "*Please note that this effect will appear only once."
					strTemp = strTemp & vbCrLf & "*大変恐縮ですが、このサービスは1回限りとさせて頂きます。"
					
					Call MsgBox(strTemp, MsgBoxStyle.Information, g_strAppTitle)
					
					'Call modMain.lngSet_ini("EasterEgg", "RasterScroll", False)
					'UPGRADE_WARNING: オブジェクト modMain.lngSet_ini の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call modMain.lngSet_ini("EasterEgg", "siromaru", False)
					
				End If
				
			End If
			
		End If
		
	End Sub
	
	Public Sub DrawEffect()
		
		'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case g_disp.intEffect
			
			Case EASTEREGG.SNOW, EASTEREGG.SIROMARU
				
				Call DrawSnow()
				
			Case EASTEREGG.SIROMARU2
				
				Call DrawSiromaru2()
				
			Case EASTEREGG.STAFFROLL, EASTEREGG.STAFFROLL2
				
				Call DrawStaffRoll()
				
			Case EASTEREGG.DISP_LOG
				
				Call DrawLog()
				
			Case EASTEREGG.BLUESCREEN
				
				Call DrawBlueScreen()
				
			Case Else
				
				'UPGRADE_ISSUE: PictureBox メソッド picMain.Cls はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				Call frmMain.picMain.Cls()
				
		End Select
		
	End Sub
	
	Public Sub KeyCheck(ByVal KeyCode As Short, ByVal Shift As Short)
		
		Static buf As New VB6.FixedLengthString(16)
		
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.F9 'ほわいる
				
				If Len(frmMain.txtGenre.Text) = 0 And Len(frmMain.txtArtist.Text) = 0 Then
					
					frmMain.txtGenre.Text = "Unstable Pitch Song"
					frmMain.txtArtist.Text = "while"
					
				End If
				
			Case System.Windows.Forms.Keys.F10 'シロディウス
				
				Call ShellExecute(0, vbNullString, "sirodius.exe", vbNullString, vbNullString, SW_SHOWNORMAL)
				
			Case System.Windows.Forms.Keys.A To System.Windows.Forms.Keys.Z, System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9 'バッファに保存
				
				buf.Value = Right(buf.Value, 15) & Chr(KeyCode)
				
			Case System.Windows.Forms.Keys.NumPad0 To System.Windows.Forms.Keys.NumPad9 'バッファに保存
				
				buf.Value = Right(buf.Value, 15) & KeyCode - System.Windows.Forms.Keys.NumPad0
				
			Case System.Windows.Forms.Keys.Space 'バッファに保存
				
				buf.Value = Right(buf.Value, 15) & " "
				
			Case System.Windows.Forms.Keys.Return 'イースターエッグ発動
				
				If Right(buf.Value, 3) = "OFF" Then 'OFF
					
					frmMain.tmrEffect.Enabled = False
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					g_disp.intEffect = EASTEREGG.OFF
					
					Call DrawEffect()
					
				ElseIf Right(buf.Value, 4) = "TIPS" Then  'TIPS
					
					With frmWindowTips
						
						.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(frmMain.Left) + (VB6.PixelsToTwipsX(frmMain.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
						.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frmMain.Top) + (VB6.PixelsToTwipsY(frmMain.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)
						
						Call VB6.ShowForm(frmWindowTips, VB6.FormShowConstants.Modal, frmMain)
						
					End With
					
				ElseIf Right(buf.Value, 4) = "SNOW" Then  'SNOW
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_disp.intEffect = EASTEREGG.SNOW Then
						
						frmMain.tmrEffect.Enabled = False
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.OFF
						
					Else
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.SNOW
						
						Call InitSnow()
						
					End If
					
					Call DrawEffect()
					
				ElseIf Right(buf.Value, 8) = "SIROMARU" Or Right(buf.Value, 9) = "SIROMARU1" Then  'SIROMARU
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_disp.intEffect = EASTEREGG.SIROMARU Then
						
						frmMain.tmrEffect.Enabled = False
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.OFF
						
					Else
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.SIROMARU
						
						Call InitSnow()
						
					End If
					
					Call DrawEffect()
					
				ElseIf Right(buf.Value, 9) = "SIROMARU2" Then  'SIROMARU2
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_disp.intEffect = EASTEREGG.SIROMARU2 Then
						
						frmMain.tmrEffect.Enabled = False
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.OFF
						
					Else
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.SIROMARU2
						
						Call InitSiromaru2()
						
					End If
					
					Call DrawEffect()
					
				ElseIf Right(buf.Value, 3) = "LOG" Then  'LOG
					
					frmMain.tmrEffect.Enabled = False
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_disp.intEffect = EASTEREGG.DISP_LOG Then
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.OFF
						
					Else
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.DISP_LOG
						
					End If
					
					Call DrawEffect()
					Call modDraw.Redraw()
					
				ElseIf Right(buf.Value, 9) = "STAFFROLL" Then  'STAFFROLL, STAFFROLL2
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_disp.intEffect = EASTEREGG.STAFFROLL Or g_disp.intEffect = EASTEREGG.STAFFROLL2 Then
						
						frmMain.tmrEffect.Enabled = False
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.OFF
						
					Else
						
						frmMain.tmrEffect.Interval = 100
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.STAFFROLL
						
						Call InitStaffRoll()
						
					End If
					
					Call DrawEffect()
					
				ElseIf Right(buf.Value, 10) = "STAFFROLL2" Then  'STAFFROLL, STAFFROLL2
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_disp.intEffect = EASTEREGG.STAFFROLL Or g_disp.intEffect = EASTEREGG.STAFFROLL2 Then
						
						frmMain.tmrEffect.Enabled = False
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.OFF
						
					Else
						
						frmMain.tmrEffect.Interval = 10
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.STAFFROLL
						
						Call InitStaffRoll()
						
					End If
					
					Call DrawEffect()
					
				ElseIf Right(buf.Value, 10) = "BLUESCREEN" Or Right(buf.Value, 4) = "BSOD" Then  'BLUESCREEN OF DEATH
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If g_disp.intEffect = EASTEREGG.BLUESCREEN Then
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.OFF
						
					Else
						
						'frmMain.tmrEffect.Interval = 1
						'frmMain.tmrEffect.Enabled = True
						frmMain.tmrEffect.Enabled = False
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						g_disp.intEffect = EASTEREGG.BLUESCREEN
						
					End If
					
					Call DrawEffect()
					
				End If
				
				buf.Value = ""
				
		End Select
		
	End Sub
	
	Public Sub InitSnow()
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim sngTemp As Single
		
		'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If g_disp.intEffect = EASTEREGG.OFF Then Exit Sub
		
		ReDim m_objSnow((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ VB6.TwipsPerPixelX) * 0.5 - 1)
		
		'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If g_disp.intEffect <> EASTEREGG.SNOW Then ReDim m_objSnow((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ VB6.TwipsPerPixelX) \ 8 - 1)
		
		lngTemp = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ VB6.TwipsPerPixelY
		sngTemp = ((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ VB6.TwipsPerPixelX) / UBound(m_objSnow))
		
		Call Randomize()
		
		For i = 0 To UBound(m_objSnow)
			
			With m_objSnow(i)
				
				.counter = (Rnd() * 1024) \ 4
				
				.X = sngTemp * i
				.Y = Rnd() * lngTemp + 1 - lngTemp
				
				'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If g_disp.intEffect = EASTEREGG.SNOW Then
					
					.dY = Rnd() * 2 + 1
					
				Else
					
					.dY = Rnd() * 4 + 4
					
				End If
				
				.dX = .X + g_sngSin(.counter And 255) * 5 * .dY
				
			End With
			
		Next i
		
		'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If g_disp.intEffect = EASTEREGG.SNOW Then Call QuickSortA(0, UBound(m_objSnow))
		
		frmMain.tmrEffect.Enabled = True
		frmMain.tmrEffect.Interval = 100
		
	End Sub
	
	Public Sub FallingSnow()
		
		Dim i As Integer
		Dim lngTemp As Integer
		
		For i = 0 To UBound(m_objSnow)
			
			With m_objSnow(i)
				
				.counter = .counter + 4
				
				'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If g_disp.intEffect = EASTEREGG.SNOW Then
					
					.Y = .Y + .dY
					.X = .X + g_sngSin(.counter * 2 And 255) * .dY / 2
					
				Else
					
					lngTemp = (.counter \ 4) And 7
					
					If lngTemp = 0 Then
						
						.Angle = Rnd() * 128
						
					ElseIf lngTemp > 1 Then 
						
						.X = .X + g_sngSin(.Angle + 64) * .dY
						.Y = .Y + g_sngSin(.Angle) * .dY
						
						'.x = .x + g_sngSin((.Counter \ 32 And 7) * 32 + 16) * .dY
						'.y = .y + g_sngSin(((.Counter \ 32 And 7) * 32 + 16 + 64) And 127) * .dY
						'.X = .X + g_sngSin((.Counter) And 255) * .dY
						'.Y = .Y + g_sngSin((.Counter + 64) And 127) * .dY
						
					End If
					
				End If
				
			End With
			
		Next i
		
		'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If g_disp.intEffect <> EASTEREGG.SNOW Then Call QuickSortY(0, UBound(m_objSnow))
		
	End Sub
	
	Public Sub DrawSnow()
		
		Dim i As Integer
		Dim X As Integer
		Dim Y As Integer
		Dim Width As Integer
		Dim Height As Integer
		'UPGRADE_NOTE: Size は Size_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		Dim Size_Renamed As Integer
		'Dim srcX    As Long
		Dim srcY As Integer
		Dim intTemp As Short
		'Dim lngTemp As Long
		
		'lngTemp = timeGetTime()
		
		Width = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ VB6.TwipsPerPixelX)
		Height = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ VB6.TwipsPerPixelY)
		
		For i = 0 To UBound(m_objSnow)
			
			With m_objSnow(i)
				
				'UPGRADE_WARNING: オブジェクト g_disp.Width の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: Mod に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
				X = (.X - frmMain.hsbMain.Value * g_disp.Width) Mod Width
				'UPGRADE_WARNING: オブジェクト g_disp.Height の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: Mod に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
				Y = (.Y + frmMain.vsbMain.Value * g_disp.Height) Mod Height
				
				'If Y < frmMain.picMain.ScaleHeight And X < frmMain.picMain.ScaleWidth Then
				
				Select Case .dY
					
					Case Is < 3
						
						Size_Renamed = Int(3 + (.dY - 1) * 3) '3-8
						
						'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						Call Ellipse(frmMain.picMain.hdc, X, Y, X + Size_Renamed, Y + Size_Renamed)
						
						If Y + Size_Renamed > Height Then
							
							intTemp = Y - Height
							
							'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							Call Ellipse(frmMain.picMain.hdc, X, intTemp, X + Size_Renamed, intTemp + Size_Renamed)
							
						End If
						
						If X + Size_Renamed > Width Then
							
							intTemp = X - Width
							
							'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							Call Ellipse(frmMain.picMain.hdc, intTemp, Y, intTemp + Size_Renamed, Y + Size_Renamed)
							
						End If
						
					Case Else
						
						srcY = ((.counter \ 4) And 7)
						
						If srcY > 1 Then
							
							Y = Y - g_sngSin((srcY - 1) * 128 \ 6 And 127) * 4 * .dY
							
						End If
						
						srcY = srcY * 32
						
						'Call Ellipse(frmMain.picmain.hdc, X - 16, .y - 16, X + 16, .y + 16)
						'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						Call BitBlt(frmMain.picMain.hdc, X, Y, 32, 32, frmMain.picSiromaru.hdc, 32, srcY, SRCAND)
						'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						Call BitBlt(frmMain.picMain.hdc, X, Y, 32, 32, frmMain.picSiromaru.hdc, 0, srcY, SRCPAINT)
						
						If Y + 32 > Height Then
							
							intTemp = Y + 32 - Height
							
							'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							Call BitBlt(frmMain.picMain.hdc, X, 0, 32, intTemp, frmMain.picSiromaru.hdc, 32, srcY + 32 - intTemp, SRCAND)
							'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							Call BitBlt(frmMain.picMain.hdc, X, 0, 32, intTemp, frmMain.picSiromaru.hdc, 0, srcY + 32 - intTemp, SRCPAINT)
							
						End If
						
						If X + 32 > Width Then
							
							intTemp = X + 32 - Width
							
							'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							Call BitBlt(frmMain.picMain.hdc, 0, Y, intTemp, 32, frmMain.picSiromaru.hdc, 64 - intTemp, srcY, SRCAND)
							'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
							Call BitBlt(frmMain.picMain.hdc, 0, Y, intTemp, 32, frmMain.picSiromaru.hdc, 32 - intTemp, srcY, SRCPAINT)
							
						End If
						
				End Select
				
				'End If
				
			End With
			
		Next i
		
		'frmMain.cboDirectInput.Text = timeGetTime() - lngTemp
		
		Exit Sub
		
	End Sub
	
	Private Sub InitSiromaru2()
		
		frmMain.tmrEffect.Enabled = True
		frmMain.tmrEffect.Interval = 100
		
		m_lngCounter = 0
		
		ReDim m_objSnow(0)
		m_objSnow(0).X = 1
		m_objSnow(0).dX = 0
		
	End Sub
	
	Public Sub ZoomSiromaru2()
		
		m_lngCounter = m_lngCounter + 1
		
		If (m_lngCounter And 7) > 1 And (m_lngCounter And 7) < 7 Then
			
			If m_objSnow(0).X < frmMain.picMain.ClientRectangle.Width * 2 Then
				
				m_objSnow(0).dX = m_objSnow(0).dX + 0.1
				m_objSnow(0).X = m_objSnow(0).X + m_objSnow(0).dX
				
			End If
			
		End If
		
	End Sub
	
	Public Sub DrawSiromaru2()
		
		Dim X As Integer
		Dim Y As Integer
		Dim srcY As Short
		
		srcY = m_lngCounter And 7
		
		If srcY > 1 Then
			
			Y = Y - g_sngSin((srcY - 1) * 128 \ 6 And 127) * m_objSnow(0).X
			
		End If
		
		srcY = srcY * 32
		
		With frmMain.picMain
			
			X = (.ClientRectangle.Width - m_objSnow(0).X) \ 2
			Y = Y + (.ClientRectangle.Height - m_objSnow(0).X) \ 2
			
			'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call StretchBlt(.hdc, X, Y, m_objSnow(0).X, m_objSnow(0).X, frmMain.picSiromaru.hdc, 32, srcY, 32, 32, SRCAND)
			'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call StretchBlt(.hdc, X, Y, m_objSnow(0).X, m_objSnow(0).X, frmMain.picSiromaru.hdc, 0, srcY, 32, 32, SRCPAINT)
			
		End With
		
	End Sub
	
	Public Sub DrawLog()
		
		'1.3.6 にて削除
		
	End Sub
	
	Private Sub DrawLogText(ByVal X As Integer, ByVal Y As Integer, ByRef Text As String, Optional ByVal Color As Integer = 16777215)
		
		Dim intTemp As Short
		
		With frmMain.picMain

            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            intTemp = LenB(Text)

            'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call SetTextColor(.hdc, 0) 'RGB(0, 0, 0)
			
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call TextOut(.hdc, X, Y - 1, Text, intTemp)
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call TextOut(.hdc, X + 1, Y, Text, intTemp)
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call TextOut(.hdc, X, Y + 1, Text, intTemp)
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call TextOut(.hdc, X - 1, Y, Text, intTemp)
			
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call SetTextColor(.hdc, Color)
			
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call TextOut(.hdc, X, Y, Text, intTemp)
			
		End With
		
	End Sub
	
	Public Sub InitStaffRoll()
		
		'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If g_disp.intEffect = EASTEREGG.OFF Then Exit Sub
		
		frmMain.tmrEffect.Enabled = True
		
		m_lngCounter = 0
		
		ReDim m_strStaffRoll(0)
		
		Call AddStaffRoll("BMx Sequence Editor", 1)
		Call AddStaffRoll(My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision, 1)
		Call AddStaffRoll("Staff Credit", 5)
		
		Call AddStaffRoll("-Program-", 1)
		'Call AddStaffRoll("tokonats", 3)
		Call AddStaffRoll("Hayana", 0)
		Call AddStaffRoll("(aka tokonats)", 3)
		
		Call AddStaffRoll("-Program Icon, Toolbar Icon, BMSE Image-", 1)
		Call AddStaffRoll("AOiRO_Manbow", 3)
		
		Call AddStaffRoll("-Technical Adviser-", 1)
		Call AddStaffRoll("aska sakurano", 3)
		
		Call AddStaffRoll("-Language File Support-", 1)
		Call AddStaffRoll("Aruhito", 0)
		Call AddStaffRoll("sfmddrex", 0)
		Call AddStaffRoll("MW", 3)
		
		Call AddStaffRoll("-Tips Writing-", 1)
		Call AddStaffRoll("sfmddrex", 0)
		Call AddStaffRoll("Aruhito", 3)
		
		Call AddStaffRoll("-siromaru Animation-", 1)
		Call AddStaffRoll("tutidama", 0)
		Call AddStaffRoll("●▼●", 3)
		
		Call AddStaffRoll("-Easter Egg Adviser-", 1)
		Call AddStaffRoll("shammy", 0)
		'Call AddStaffRoll("Clock", 0)
		Call AddStaffRoll("sfmddrex", 0)
		Call AddStaffRoll("Lai", 0)
		Call AddStaffRoll("Yamajet", 0)
		Call AddStaffRoll("AOiRO_Manbow", 3)
		
		Call AddStaffRoll("-Programming Assistant-", 1)
		Call AddStaffRoll("Coca-Cola Classic", 3)
		
		Call AddStaffRoll("-Special Thanks-", 1)
		Call AddStaffRoll("tix", 0)
		Call AddStaffRoll("J.T.", 1)
		'Call AddStaffRoll("Shunsuke Kudo a.k.a. OBONO", 3)
		Call AddStaffRoll("Shunsuke Kudo", 0)
		Call AddStaffRoll("(aka OBONO)", 3)
		
		Call AddStaffRoll("-Special ""NO"" Thanks-", 1)
		Call AddStaffRoll("FontSize Property", 0)
		Call AddStaffRoll("FontBold Property", 0)
		Call AddStaffRoll("FontItalic Property", 0)
		Call AddStaffRoll("FontName Property", 0)
		Call AddStaffRoll("FontStrikethru Property", 0)
		Call AddStaffRoll("FontUnderline Property", 1)
		Call AddStaffRoll("TabStrip Control", 0)
		Call AddStaffRoll("SSTab Control", 1)
		Call AddStaffRoll("PitcureBox.MouseDown", 0)
		Call AddStaffRoll("PitcureBox.MouseMove", 0)
		Call AddStaffRoll("PictureBox.MouseUp", 1)
		'Call AddStaffRoll("Microsoft Visual Basic 6.0", 3)
		Call AddStaffRoll("Microsoft Visual Basic 6.0", 0)
		Call AddStaffRoll("(Oh No, I Love Her!)", 1)
		Call AddStaffRoll("tokonats", 3)
		
		Call AddStaffRoll("-Debugger-", 1)
		Call AddStaffRoll("All BMSE Users:)", 5)
		
		'Call AddStaffRoll("Copyright(C) tokonats/UCN-Soft 2004.", 0)
		Call AddStaffRoll("Copyright(C) Hayana/UCN-Soft 2004-2007.", 0)
		Call AddStaffRoll("http://ucn.tokonats.net/", 0)
		Call AddStaffRoll("ucn@tokonats.net", 0)
		
		'ReDim Preserve m_strStaffRoll(1)
		
	End Sub
	
	Private Sub AddStaffRoll(ByRef Text As String, Optional ByVal Break As Short = 0)
		
		Dim lngTemp As Integer
		
		If Break < 0 Then Break = 0
		
		lngTemp = UBound(m_strStaffRoll) + 1
		
		ReDim Preserve m_strStaffRoll(lngTemp + Break)
		
		m_strStaffRoll(lngTemp) = Text
		
	End Sub
	
	Public Sub StaffRollScroll()
		
		m_lngCounter = m_lngCounter + 100 \ frmMain.tmrEffect.Interval
		
	End Sub
	
	Public Sub DrawStaffRoll()
		
		Dim i As Integer
		Dim X As Integer
		Dim Y As Integer
		Dim Color As Integer
		Dim intTemp As Integer
		Dim lngTemp As Integer
		Dim sizeTemp As Size
		
		Dim srcY As Short
		With frmMain.picMain
			
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call SetTextColor(.hdc, RGB(255, 255, 255))
			.Font = VB6.FontChangeSize(.Font, 12)
			
			lngTemp = .ClientRectangle.Height - m_lngCounter
			
			For i = 0 To UBound(m_strStaffRoll)
				
				If Len(m_strStaffRoll(i)) Then

                    'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                    'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
                    intTemp = LenB(m_strStaffRoll(i))

                    'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                    Call GetTextExtentPoint32(.hdc, m_strStaffRoll(i), intTemp, sizeTemp)
					
					X = (frmMain.picMain.ClientRectangle.Width - sizeTemp.Width) \ 2
					Y = lngTemp - sizeTemp.Height \ 2
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If (Y < .ClientRectangle.Height And Y + sizeTemp.Height > 0) Or g_disp.intEffect = EASTEREGG.STAFFROLL2 Then
						
						'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If g_disp.intEffect = EASTEREGG.STAFFROLL Then
							
							If .ClientRectangle.Height < 128 Then
								
								Color = 255
								
							ElseIf lngTemp < 64 Then 
								
								Color = lngTemp * 4
								
								If Color < 0 Then Color = 0
								
							ElseIf lngTemp > .ClientRectangle.Height - 64 Then 
								
								Color = 255 - (lngTemp - (.ClientRectangle.Height - 64)) * 4
								
								If Color < 0 Then Color = 0
								
							Else
								
								Color = 255
								
							End If
							
						Else
							
							Select Case m_lngCounter
								
								Case Is > 95
									
									frmMain.tmrEffect.Enabled = False
									'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									g_disp.intEffect = EASTEREGG.OFF
									
									Exit Sub
									
								Case Is < 32 : Color = m_lngCounter * 8 '0-31
								Case Is > 63 : Color = (95 - m_lngCounter) * 8 '64-95
								Case Else : Color = 255 '32-63
									
							End Select
							
							Y = (.ClientRectangle.Height - sizeTemp.Height * UBound(m_strStaffRoll)) \ 2 + sizeTemp.Height * i
							
						End If
						
						If m_strStaffRoll(i) <> "●▼●" Then
							
							Call DrawLogText(X, Y, m_strStaffRoll(i), RGB(Color, Color, Color))
							
						End If
						
					End If
					
					If m_strStaffRoll(i) = "●▼●" Then
						
						
						X = (frmMain.picMain.ClientRectangle.Width - 32) \ 2
						Y = lngTemp '.ScaleHeight - lngTemp
						
						srcY = (m_lngCounter And 7)
						
						If srcY > 1 Then
							
							Y = Y - g_sngSin((srcY - 1) * 128 \ 6 And 127) * 4 * 8
							
						End If
						
						srcY = srcY * 32
						
						'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						Call BitBlt(frmMain.picMain.hdc, X, Y, 32, 32, frmMain.picSiromaru.hdc, 32, srcY, SRCAND)
						'UPGRADE_ISSUE: PictureBox プロパティ picSiromaru.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
						Call BitBlt(frmMain.picMain.hdc, X, Y, 32, 32, frmMain.picSiromaru.hdc, 0, srcY, SRCPAINT)
						
					End If
					
					lngTemp = lngTemp + sizeTemp.Height + 2
					
				Else
					
					lngTemp = lngTemp + 12
					
				End If
				
			Next i
			
			If lngTemp < 0 Then
				
				'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If g_disp.intEffect = EASTEREGG.STAFFROLL Then
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					g_disp.intEffect = EASTEREGG.STAFFROLL2
					
					ReDim m_strStaffRoll(0)
					
					'm_lngCounter = Rnd * 4
					
					'Select Case m_lngCounter
					'Case 0: m_strStaffRoll(0) = """HAVE YOU FORGOTTEN SOMETHING?"""
					'Case 1: m_strStaffRoll(0) = "I'M PERFECT! ARE YOU?"
					'Case 2: m_strStaffRoll(0) = "The Matrix has you..."
					'Case 3
					'm_strStaffRoll(0) = "WAS ITS PHANTASM"
					'Call AddStaffRoll("THE LAST ATTACKING")
					'Call AddStaffRoll("OR ITS LAST MOMENTS", 1)
					'Call AddStaffRoll("AND WAS THIS FOR REAL")
					'Call AddStaffRoll("OR WAS I DREAMING", 1)
					'Call AddStaffRoll("NOBODY KNOWS YET....")
					'End Select
					
					m_lngCounter = 0
					m_strStaffRoll(0) = """HAVE YOU FORGOTTEN SOMETHING?"""
					
				Else
					
					frmMain.tmrEffect.Enabled = False
					
					Erase m_strStaffRoll
					
					'UPGRADE_WARNING: オブジェクト g_disp.intEffect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					g_disp.intEffect = EASTEREGG.OFF
					
				End If
				
			End If
			
		End With
		
	End Sub
	
	Public Sub DrawBlueScreen()
		
		Dim hBrushNew As Integer
		Dim hBrushOld As Integer
		Dim rectTemp As RECT
		
		With frmMain.picMain
			
			hBrushNew = CreateSolidBrush(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue))
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			hBrushOld = SelectObject(.hdc, hBrushNew)
			
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call Rectangle(.hdc, 0, 0, .ClientRectangle.Width, .ClientRectangle.Height)
			
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			hBrushNew = SelectObject(.hdc, hBrushOld)
			Call DeleteObject(hBrushNew)
			
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call SetTextColor(.hdc, 16777215)
			
			rectTemp.left_Renamed = 8
			rectTemp.right_Renamed = .ClientRectangle.Width - 8
			rectTemp.Top = 8
			rectTemp.Bottom = .ClientRectangle.Height
			
			.Font = VB6.FontChangeSize(.Font, 9)
			
			'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call DrawText(.hdc, "A problem has been detected and BMSE has been shut down to prevent damage to your mind." & vbCrLf & vbCrLf & "The problem seems to be caused by the following file: BMSE.EXE" & vbCrLf & vbCrLf & "EASTER_EGG_BLUE_SCREEN_OF_DEATH" & vbCrLf & vbCrLf & "If this is the first time you've seen this stop error screen, restart your BMSE. If this screen appears again, follow these steps:" & vbCrLf & vbCrLf & "1) Bury me from your computer." & vbCrLf & "2) Access UCN-Soft BBS, and write your shout of spirit." & vbCrLf & "       ex) ""BMSE is the worst software in the world!!!!!!!!!!!!!!111111""" & vbCrLf & "3) Sing ""asdf song"":" & vbCrLf & "       This is the sound of the asdf song." & vbCrLf & "       asdf fdsa" & vbCrLf & "       asdffdsa ye-ye" & vbCrLf & "       (clap clap clap)" & vbCrLf & "4) Throw your computer from window." & vbCrLf & vbCrLf & "If you are satiated with joke:" & vbCrLf & vbCrLf & "Launch BMSE and type your key ""OFF"", then press return key." & vbCrLf & vbCrLf & "Meaningless information:" & vbCrLf & vbCrLf & "*** STOP: 0x88710572 (0xASDFFDSA,0x00004126,0xD0SUK01,0x○0▽0○)" & vbCrLf & vbCrLf & vbCrLf & "***  BMSE.EXE - Public Sub DrawBlueScreen() at modEasterEgg.bas, DateStamp 2006-12-26", -1, rectTemp, DT_WORDBREAK)
			
		End With
		
	End Sub
	
	Private Sub QuickSortY(ByVal l As Integer, ByVal r As Integer)
		
		Dim i As Integer
		Dim j As Integer
		Dim p As Single
		
		p = m_objSnow((l + r) \ 2).Y
		i = l
		j = r
		
		Do 
			
			Do While m_objSnow(i).Y < p
				i = i + 1
			Loop 
			
			Do While m_objSnow(j).Y > p
				j = j - 1
			Loop 
			
			If i >= j Then Exit Do
			
			Call SwapObj(m_objSnow(i), m_objSnow(j))
			
			i = i + 1
			j = j - 1
			
		Loop 
		
		If (l < i - 1) Then Call QuickSortY(l, i - 1)
		If (r > j + 1) Then Call QuickSortY(j + 1, r)
		
	End Sub
	
	Private Sub QuickSortA(ByVal l As Integer, ByVal r As Integer)
		
		Dim i As Integer
		Dim j As Integer
		Dim p As Single
		
		p = m_objSnow((l + r) \ 2).dY
		i = l
		j = r
		
		Do 
			
			Do While m_objSnow(i).dY < p
				i = i + 1
			Loop 
			
			Do While m_objSnow(j).dY > p
				j = j - 1
			Loop 
			
			If i >= j Then Exit Do
			
			Call SwapObj(m_objSnow(i), m_objSnow(j))
			
			i = i + 1
			j = j - 1
			
		Loop 
		
		If (l < i - 1) Then Call QuickSortA(l, i - 1)
		If (r > j + 1) Then Call QuickSortA(j + 1, r)
		
	End Sub
	
	Private Sub SwapObj(ByRef Obj1 As m_udtSnow, ByRef Obj2 As m_udtSnow)
		
		Dim dummy As m_udtSnow
		
		'UPGRADE_WARNING: オブジェクト dummy の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		dummy = Obj1
		'UPGRADE_WARNING: オブジェクト Obj1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Obj1 = Obj2
		'UPGRADE_WARNING: オブジェクト Obj2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Obj2 = dummy
		
	End Sub
End Module
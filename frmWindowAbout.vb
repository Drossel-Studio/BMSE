Option Strict Off
Option Explicit On
Friend Class frmWindowAbout
	Inherits System.Windows.Forms.Form
	
	Private m_sngRaster() As Single
	Private m_lngCounter As Integer
	
	'UPGRADE_NOTE: Text は Text_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Sub PrintText(ByRef Text_Renamed As String, ByVal X As Integer, ByVal Y As Integer)
		
		Dim intTemp As Short

        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        intTemp = LenB(Text_Renamed)

        With Me
            Dim gp As Graphics = .CreateGraphics()
            Dim hDC As IntPtr = gp.GetHdc()

            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call SetTextColor(hDC, 0)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X - 1, Y - 1, Text_Renamed, intTemp)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X, Y - 1, Text_Renamed, intTemp)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X + 1, Y - 1, Text_Renamed, intTemp)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X - 1, Y, Text_Renamed, intTemp)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X + 1, Y, Text_Renamed, intTemp)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X - 1, Y + 1, Text_Renamed, intTemp)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X, Y + 1, Text_Renamed, intTemp)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X + 1, Y + 1, Text_Renamed, intTemp)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call SetTextColor(hDC, 16777215)
            'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call TextOut(hDC, X, Y, Text_Renamed, intTemp)

        End With
		
	End Sub
	
	'UPGRADE_WARNING: Form イベント frmWindowAbout.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub frmWindowAbout_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		Dim i As Integer
		
		ReDim m_sngRaster(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - 1)
		
		For i = 0 To UBound(m_sngRaster)
			
			m_sngRaster(i) = 0
			
		Next i
		
		m_lngCounter = 0
		
		Call frmWindowAbout_Paint(Me, New System.Windows.Forms.PaintEventArgs(Nothing, Nothing))
		
	End Sub
	
	Private Sub frmWindowAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		
		Call Me.Close()
		
	End Sub
	
	'UPGRADE_WARNING: Form イベント frmWindowAbout.Deactivate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub frmWindowAbout_Deactivate(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Deactivate
		
		Call Me.Close()
		
	End Sub

    Private Sub frmWindowAbout_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode

            Case System.Windows.Forms.Keys.M

                tmrMain.Enabled = True

        End Select

    End Sub

    Private Sub frmWindowAbout_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        With Me

            .Width = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(.Width) * VB6.TwipsPerPixelX) / 15)
            .Height = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(.Height) * VB6.TwipsPerPixelY) / 15)
            .Text = "About: " & g_strAppTitle & " (" & RELEASEDATE & " ver.)"

        End With

        Dim rectTemp As RECT

        With rectTemp

            .left_Renamed = 0
            .Top = 0
            .right_Renamed = 526
            .Bottom = 196

        End With

        With Me

            Call AdjustWindowRectEx(rectTemp, GetWindowLong(.Handle.ToInt32, GWL_STYLE), False, GetWindowLong(.Handle.ToInt32, GWL_EXSTYLE))

            Call .SetBounds(.Left, .Top, VB6.TwipsToPixelsX((rectTemp.right_Renamed - rectTemp.left_Renamed) * VB6.TwipsPerPixelX), VB6.TwipsToPixelsY((rectTemp.Bottom - rectTemp.Top) * VB6.TwipsPerPixelY))

        End With

    End Sub

    Private Sub frmWindowAbout_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        Dim i As Integer
        Dim strTemp As String
        Dim lngTemp As Integer
        Dim sngTemp As Single

        With Me
            Dim gp As Graphics = .CreateGraphics()
            Dim hDC As IntPtr = gp.GetHdc()

            Dim picMain_gp As Graphics = picMain.CreateGraphics()
            Dim picMain_hDC As IntPtr = picMain_gp.GetHdc()


            'UPGRADE_ISSUE: Form メソッド frmWindowAbout.Cls はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call gp.Clear(.BackColor)

            sngTemp = m_lngCounter / 10
            If sngTemp > 8 Then sngTemp = 8

            For i = 0 To VB6.PixelsToTwipsY(.ClientRectangle.Height) - 1

                'm_sngRaster(i) = m_sngRaster(i) + Sin((i + m_lngCounter) * RAD * 8)
                'm_sngRaster(i) = m_sngRaster(i) + g_sngSin(((i + m_lngCounter) * 8) And 255)
                m_sngRaster(i) = g_sngSin(((i + m_lngCounter) * 8) And 255) * sngTemp
                'm_sngRaster(i) = (m_sngRaster(i) + i) And .ScaleWidth

                If tmrMain.Enabled Then lngTemp = m_sngRaster(i)

                'Call StretchBlt(.hdc, lngTemp - .ScaleWidth, i, .ScaleWidth, 1, picMain.hdc, 0, i, .ScaleWidth, 1, SRCCOPY)
                'Call StretchBlt(.hdc, lngTemp, i, .ScaleWidth, 1, picMain.hdc, 0, i, .ScaleWidth, 1, SRCCOPY)
                'UPGRADE_ISSUE: PictureBox プロパティ picMain.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'UPGRADE_ISSUE: Form プロパティ frmWindowAbout.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                Call BitBlt(hDC, lngTemp, i, VB6.PixelsToTwipsX(.ClientRectangle.Width), 1, picMain_hDC, 0, i, SRCCOPY)

            Next i

            'Call BitBlt(.hWnd, 0, 0, .ScaleWidth, .ScaleHeight, picMain.hWnd, 0, 0, SRCCOPY)

            lngTemp = 0

            .Font = VB6.FontChangeSize(.Font, 9)
            .Font = VB6.FontChangeUnderline(.Font, False)
            .Font = VB6.FontChangeBold(.Font, True)

            lngTemp = g_InputLog.GetBufferSize

            Select Case lngTemp

                Case Is < 1024

                    strTemp = lngTemp & " Byte"

                Case Is < 1048576

                    strTemp = System.Math.Round(lngTemp / 1024, 2) & " KB"

                Case Else

                    strTemp = System.Math.Round(lngTemp / 1048576, 2) & " MB"

            End Select

            strTemp = "Undo Buffer Size: " & strTemp

            Call PrintText(strTemp, 1, 1)

            Call PrintText("Undo Counter: " & g_InputLog.GetPos & " / " & g_InputLog.Max, 1, 13 * (15 / VB6.TwipsPerPixelY))

            '.Font.SIZE = 12 * (Screen.TwipsPerPixelX / 15)
            '.Font.Underline = True

            'strTemp = App.Major & "." & App.Minor & "." & App.Revision
            'lngTemp = LenB(StrConv(strTemp, vbFromUnicode))

            'Call PrintText(strTemp, 251, 174)

        End With

    End Sub

    Private Sub frmWindowAbout_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub picMain_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picMain.Click

        Call Me.Close()

    End Sub

    Private Sub tmrMain_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMain.Tick

        m_lngCounter = m_lngCounter + 1
        Call frmWindowAbout_Paint(Me, New System.Windows.Forms.PaintEventArgs(Nothing, Nothing))

    End Sub

    Private Sub frmWindowAbout_FormClosed(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class
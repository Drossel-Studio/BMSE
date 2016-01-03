Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmWindowPreview
	Inherits System.Windows.Forms.Form
	
	Private Const GWL_STYLE As Short = (-16)
	Private Const GWL_EXSTYLE As Short = -20
	
	Public Sub SetWindowSize()
		
		Dim rectTemp As RECT
		
		Call frmWindowPreview_Resize(Me, New System.EventArgs())
		
		With rectTemp
			
			.left_Renamed = 0
			.Top = 0
			.right_Renamed = 256 + VB6.PixelsToTwipsX(fraBGAPara.Width) \ VB6.TwipsPerPixelX
			.Bottom = 256
			
		End With
		
		With Me
			
			Call AdjustWindowRectEx(rectTemp, GetWindowLong(.Handle.ToInt32, GWL_STYLE), False, GetWindowLong(.Handle.ToInt32, GWL_EXSTYLE))
			
			Call .SetBounds(.Left, .Top, VB6.TwipsToPixelsX((rectTemp.right_Renamed - rectTemp.left_Renamed) * VB6.TwipsPerPixelX), VB6.TwipsToPixelsY((rectTemp.Bottom - rectTemp.Top) * VB6.TwipsPerPixelY))
			
		End With
		
	End Sub
	
	'UPGRADE_WARNING: イベント chkBGLine.CheckStateChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub chkBGLine_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkBGLine.CheckStateChanged
		
		Call picPreview_Paint(picPreview, New System.Windows.Forms.PaintEventArgs(Nothing, Nothing))
		
	End Sub

    Private Sub cmdCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCopy.Click
        Dim strArray(6) As String

        strArray(0) = _txtBGAPara_0.Text
        If Len(strArray(0)) = 0 Then strArray(0) = "0"
        strArray(1) = _txtBGAPara_1.Text
        If Len(strArray(1)) = 0 Then strArray(1) = "0"
        strArray(2) = _txtBGAPara_2.Text
        If Len(strArray(2)) = 0 Then strArray(2) = "0"
        strArray(3) = _txtBGAPara_3.Text
        If Len(strArray(3)) = 0 Then strArray(3) = "0"
        strArray(4) = _txtBGAPara_4.Text
        If Len(strArray(4)) = 0 Then strArray(4) = "0"
        strArray(5) = _txtBGAPara_5.Text
        If Len(strArray(5)) = 0 Then strArray(5) = "0"
        strArray(6) = _txtBGAPara_6.Text
        If Len(strArray(6)) = 0 Then strArray(6) = "0"

        Call My.Computer.Clipboard.Clear()
		Call My.Computer.Clipboard.SetText(Join(strArray, " "))
		
	End Sub
	
	Private Sub cmdPreviewBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviewBack.Click
		
		Dim i As Integer
		
		With frmMain

            If ._optChangeBottom_2.Checked Then

                i = .lstBGA.SelectedIndex - 1

                Do While i = 0

                    If Len(VB6.GetItemString(.lstBGA, i)) > 8 Then

                        .lstBGA.SelectedIndex = i

                        Exit Sub

                    End If

                    i = i - 1

                Loop

            Else

                i = .lstBMP.SelectedIndex - 1
				
				Do While i >= 0
					
					If Len(VB6.GetItemString(.lstBMP, i)) > 8 Then
						
						.lstBMP.SelectedIndex = i
						
						Exit Sub
						
					End If
					
					i = i - 1
					
					
				Loop 
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdPreviewEnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviewEnd.Click
		
		With frmMain

            If ._optChangeBottom_2.Checked Then

                .lstBGA.SelectedIndex = .lstBGA.Items.Count - 1

            Else

                .lstBMP.SelectedIndex = .lstBMP.Items.Count - 1
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdPreviewHome_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviewHome.Click
		
		With frmMain

            If ._optChangeBottom_2.Checked Then

                .lstBGA.SelectedIndex = 0

            Else

                .lstBMP.SelectedIndex = 0
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdPreviewNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviewNext.Click
		
		Dim i As Integer
		
		With frmMain

            If ._optChangeBottom_2.Checked Then

                i = .lstBGA.SelectedIndex + 1

                Do While i < .lstBGA.Items.Count

                    If Len(VB6.GetItemString(.lstBGA, i)) > 8 Then

                        .lstBGA.SelectedIndex = i

                        Exit Sub

                    End If

                    i = i + 1

                Loop

            Else

                i = .lstBMP.SelectedIndex + 1
				
				Do While i < .lstBMP.Items.Count
					
					If Len(VB6.GetItemString(.lstBMP, i)) > 8 Then
						
						.lstBMP.SelectedIndex = i
						
						Exit Sub
						
					End If
					
					i = i + 1
					
				Loop 
				
			End If
			
		End With
		
	End Sub

    Private Sub frmWindowPreview_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        With Me

            Call .picPreview.SetBounds(0, 0, VB6.TwipsToPixelsX(256 * VB6.TwipsPerPixelX), VB6.TwipsToPixelsY(256 * VB6.TwipsPerPixelY))
            Call .picBackBuffer.SetBounds(0, 0, VB6.TwipsToPixelsX(256 * VB6.TwipsPerPixelX), VB6.TwipsToPixelsY(256 * VB6.TwipsPerPixelY))
            'UPGRADE_ISSUE: Frame プロパティ fraBGAPara.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '.fraBGAPara.BorderStyle = 0
            'UPGRADE_ISSUE: Frame プロパティ fraBGACmd.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '.fraBGACmd.BorderStyle = 0

        End With

    End Sub

    'UPGRADE_WARNING: イベント frmWindowPreview.Resize は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub frmWindowPreview_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error Resume Next

        Dim lngTemp As Integer

        With Me

            lngTemp = 120

            ._lblBGAPara_0.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_1.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_3.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_5.Left = VB6.TwipsToPixelsX(lngTemp)
            .cmdCopy.Left = VB6.TwipsToPixelsX(lngTemp)
            .chkBGLine.Left = VB6.TwipsToPixelsX(lngTemp)
            .chkLock.Left = VB6.TwipsToPixelsX(lngTemp)

            .cmdPreviewHome.Left = VB6.TwipsToPixelsX(lngTemp)
            .cmdPreviewBack.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.cmdPreviewHome.Left) + VB6.PixelsToTwipsX(.cmdPreviewHome.Width) + 60)
            .cmdPreviewNext.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.cmdPreviewBack.Left) + VB6.PixelsToTwipsX(.cmdPreviewBack.Width) + 60)
            .cmdPreviewEnd.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.cmdPreviewNext.Left) + VB6.PixelsToTwipsX(.cmdPreviewNext.Width) + 60)
            .fraBGACmd.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.cmdPreviewEnd.Left) + VB6.PixelsToTwipsX(.cmdPreviewEnd.Width) + 60)
            .fraBGACmd.Height = .cmdPreviewEnd.Height

            lngTemp = lngTemp + VB6.PixelsToTwipsX(._lblBGAPara_0.Width) + 60

            ._lblBGAPara_0.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_1.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_3.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_5.Left = VB6.TwipsToPixelsX(lngTemp)

            lngTemp = lngTemp + VB6.PixelsToTwipsX(._lblBGAPara_0.Width) + 180

            ._lblBGAPara_2.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_4.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_6.Left = VB6.TwipsToPixelsX(lngTemp)

            lngTemp = lngTemp + VB6.PixelsToTwipsX(._lblBGAPara_0.Width) + 60

            ._lblBGAPara_2.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_4.Left = VB6.TwipsToPixelsX(lngTemp)
            ._lblBGAPara_6.Left = VB6.TwipsToPixelsX(lngTemp)

            lngTemp = lngTemp + VB6.PixelsToTwipsX(._lblBGAPara_0.Width)

            .chkBGLine.Width = VB6.TwipsToPixelsX(lngTemp - 120)
            .chkLock.Width = VB6.TwipsToPixelsX(lngTemp - 120)

            .fraBGAPara.Width = VB6.TwipsToPixelsX(lngTemp + 60)

            Call .picPreview.SetBounds(0, 0, VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width) - VB6.PixelsToTwipsX(fraBGAPara.Width)), .ClientRectangle.Height)
            Call .fraBGAPara.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width) - VB6.PixelsToTwipsX(fraBGAPara.Width)), VB6.TwipsToPixelsY(60), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
            Call .fraBGACmd.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width) - VB6.PixelsToTwipsX(fraBGAPara.Width)), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - VB6.PixelsToTwipsY(fraBGACmd.Height) - 60), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)

            Call .PushPaintEvent()

        End With

    End Sub

    Private Sub frmWindowPreview_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    'UPGRADE_ISSUE: VBRUN.DataObject 型 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'UPGRADE_ISSUE: PictureBox イベント picPreview.OLEDragDrop はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"' をクリックしてください。
    Private Sub picPreview_OLEDragDrop(ByRef Data As Object, ByRef Effect As Integer, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        On Error GoTo Err_Renamed

        Dim i As Integer
        Dim strTemp As String

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

                Call frmMain.PreviewBMP(strTemp)

                Me.Text = VB.Right(Me.Text, Len(Me.Text) - 3)

            End If

        Next i

Err_Renamed:
    End Sub

    Public Sub PushPaintEvent()
        RaisePaintEvent(Me, New EventArgs)
    End Sub

    Public Sub picPreview_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles picPreview.Paint
        Dim i As Integer

        With picPreview
            Dim gp As Graphics = .CreateGraphics()
            Dim hDC As IntPtr = gp.GetHdc()

            Dim picBackBuffer_gp As Graphics = picBackBuffer.CreateGraphics()
            Dim picBackBuffer_hDC As IntPtr = gp.GetHdc()

            'UPGRADE_ISSUE: PictureBox メソッド picPreview.Cls はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call gp.Clear(.BackColor)

            'UPGRADE_ISSUE: PictureBox プロパティ picBackBuffer.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト modMain.BGA_PARA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call BitBlt(hDC, (.ClientRectangle.Width \ 2 - 128) + Val(_txtBGAPara_5.Text) - Val(_txtBGAPara_1.Text), (.ClientRectangle.Height \ 2 - 128) + Val(_txtBGAPara_6.Text) - Val(_txtBGAPara_2.Text), picBackBuffer.ClientRectangle.Width, picBackBuffer.ClientRectangle.Height, picBackBuffer_hDC, 0, 0, SRCCOPY)

            If chkBGLine.CheckState Then

                'UPGRADE_ISSUE: PictureBox プロパティ picPreview.DrawWidth はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '.DrawWidth = 1

                For i = 4 To .ClientRectangle.Height Step 8

                    'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                    Call MoveToEx(hDC, 0, i, 0)
                    'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                    Call LineTo(hDC, .ClientRectangle.Width, i)

                Next i

            End If

            'UPGRADE_ISSUE: PictureBox プロパティ picPreview.DrawWidth はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '.DrawWidth = 2

            'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call Rectangle(hDC, .ClientRectangle.Width \ 2 - 129, .ClientRectangle.Height \ 2 - 129, .ClientRectangle.Width \ 2 + 130, .ClientRectangle.Height \ 2 + 130)

            'UPGRADE_WARNING: オブジェクト modMain.BGA_PARA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_ISSUE: PictureBox プロパティ picBackBuffer.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call BitBlt(hDC, (.ClientRectangle.Width \ 2 - 128) + Val(_txtBGAPara_5.Text), (.ClientRectangle.Height \ 2 - 128) + Val(_txtBGAPara_6.Text), lngNumField(Val(_txtBGAPara_3.Text) - Val(_txtBGAPara_1.Text), 0, 256), lngNumField(Val(_txtBGAPara_4.Text) - Val(_txtBGAPara_2.Text), 0, 256), picBackBuffer_hDC, Val(_txtBGAPara_1.Text), Val(_txtBGAPara_2.Text), SRCCOPY)

        End With

    End Sub

    'UPGRADE_WARNING: イベント txtBGAPara.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txtBGAPara_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtBGAPara_6.TextChanged, _txtBGAPara_5.TextChanged, _txtBGAPara_4.TextChanged, _txtBGAPara_3.TextChanged, _txtBGAPara_2.TextChanged, _txtBGAPara_1.TextChanged, _txtBGAPara_0.TextChanged
        Select Case DirectCast(eventSender, TextBox).Name
            Case _txtBGAPara_0.Name
                If Val(_txtBGAPara_0.Text) < 0 Then _txtBGAPara_0.Text = CStr(0)
            Case _txtBGAPara_1.Name
                If Val(_txtBGAPara_1.Text) < 0 Then _txtBGAPara_1.Text = CStr(0)
            Case _txtBGAPara_2.Name
                If Val(_txtBGAPara_2.Text) < 0 Then _txtBGAPara_2.Text = CStr(0)
            Case _txtBGAPara_3.Name
                If Val(_txtBGAPara_3.Text) < 0 Then _txtBGAPara_3.Text = CStr(0)
            Case _txtBGAPara_4.Name
                If Val(_txtBGAPara_4.Text) < 0 Then _txtBGAPara_4.Text = CStr(0)
            Case _txtBGAPara_5.Name
                If Val(_txtBGAPara_5.Text) < 0 Then _txtBGAPara_5.Text = CStr(0)
            Case _txtBGAPara_6.Name
                If Val(_txtBGAPara_6.Text) < 0 Then _txtBGAPara_6.Text = CStr(0)
        End Select

        Call picPreview_Paint(picPreview, New System.Windows.Forms.PaintEventArgs(Nothing, Nothing))

    End Sub

    Private Sub txtBGAPara_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtBGAPara_6.Enter, _txtBGAPara_5.Enter, _txtBGAPara_4.Enter, _txtBGAPara_3.Enter, _txtBGAPara_2.Enter, _txtBGAPara_1.Enter, _txtBGAPara_0.Enter

        Select Case DirectCast(eventSender, TextBox).Name
            Case _txtBGAPara_0.Name
                _txtBGAPara_0.SelectionStart = 0
                _txtBGAPara_0.SelectionLength = Len(_txtBGAPara_0.Text)
            Case _txtBGAPara_1.Name
                _txtBGAPara_1.SelectionStart = 0
                _txtBGAPara_1.SelectionLength = Len(_txtBGAPara_1.Text)
            Case _txtBGAPara_2.Name
                _txtBGAPara_2.SelectionStart = 0
                _txtBGAPara_2.SelectionLength = Len(_txtBGAPara_2.Text)
            Case _txtBGAPara_3.Name
                _txtBGAPara_3.SelectionStart = 0
                _txtBGAPara_3.SelectionLength = Len(_txtBGAPara_3.Text)
            Case _txtBGAPara_4.Name
                _txtBGAPara_4.SelectionStart = 0
                _txtBGAPara_4.SelectionLength = Len(_txtBGAPara_4.Text)
            Case _txtBGAPara_5.Name
                _txtBGAPara_5.SelectionStart = 0
                _txtBGAPara_5.SelectionLength = Len(_txtBGAPara_5.Text)
            Case _txtBGAPara_6.Name
                _txtBGAPara_6.SelectionStart = 0
                _txtBGAPara_6.SelectionLength = Len(_txtBGAPara_6.Text)
        End Select

    End Sub

    Private Function lngNumField(ByVal lngNum As Integer, ByVal lngMin As Integer, ByVal lngMax As Integer) As Integer

        If lngNum < lngMin Then lngNum = lngMin

        If lngNum > lngMax Then lngNum = lngMax

        lngNumField = lngNum

    End Function
End Class
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
		
		Dim i As Integer
		Dim strArray(6) As String
		
		For i = 0 To UBound(strArray)
			
			strArray(i) = txtBGAPara(i).Text
			
			If Len(strArray(i)) = 0 Then strArray(i) = "0"
			
		Next i
		
		Call My.Computer.Clipboard.Clear()
		Call My.Computer.Clipboard.SetText(Join(strArray, " "))
		
	End Sub
	
	Private Sub cmdPreviewBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviewBack.Click
		
		Dim i As Integer
		
		With frmMain
			
			If .optChangeBottom(2).Checked Then
				
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
			
			If .optChangeBottom(2).Checked Then
				
				.lstBGA.SelectedIndex = .lstBGA.Items.Count - 1
				
			Else
				
				.lstBMP.SelectedIndex = .lstBMP.Items.Count - 1
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdPreviewHome_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviewHome.Click
		
		With frmMain
			
			If .optChangeBottom(2).Checked Then
				
				.lstBGA.SelectedIndex = 0
				
			Else
				
				.lstBMP.SelectedIndex = 0
				
			End If
			
		End With
		
	End Sub
	
	Private Sub cmdPreviewNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviewNext.Click
		
		Dim i As Integer
		
		With frmMain
			
			If .optChangeBottom(2).Checked Then
				
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
			.fraBGAPara.BorderStyle = 0
			'UPGRADE_ISSUE: Frame プロパティ fraBGACmd.BorderStyle はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			.fraBGACmd.BorderStyle = 0
			
		End With
		
	End Sub
	
	'UPGRADE_WARNING: イベント frmWindowPreview.Resize は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub frmWindowPreview_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		
		Dim lngTemp As Integer
		
		With Me
			
			lngTemp = 120
			
			.lblBGAPara(0).Left = VB6.TwipsToPixelsX(lngTemp)
			.lblBGAPara(1).Left = VB6.TwipsToPixelsX(lngTemp)
			.lblBGAPara(3).Left = VB6.TwipsToPixelsX(lngTemp)
			.lblBGAPara(5).Left = VB6.TwipsToPixelsX(lngTemp)
			.cmdCopy.Left = VB6.TwipsToPixelsX(lngTemp)
			.chkBGLine.Left = VB6.TwipsToPixelsX(lngTemp)
			.chkLock.Left = VB6.TwipsToPixelsX(lngTemp)
			
			.cmdPreviewHome.Left = VB6.TwipsToPixelsX(lngTemp)
			.cmdPreviewBack.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.cmdPreviewHome.Left) + VB6.PixelsToTwipsX(.cmdPreviewHome.Width) + 60)
			.cmdPreviewNext.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.cmdPreviewBack.Left) + VB6.PixelsToTwipsX(.cmdPreviewBack.Width) + 60)
			.cmdPreviewEnd.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.cmdPreviewNext.Left) + VB6.PixelsToTwipsX(.cmdPreviewNext.Width) + 60)
			.fraBGACmd.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.cmdPreviewEnd.Left) + VB6.PixelsToTwipsX(.cmdPreviewEnd.Width) + 60)
			.fraBGACmd.Height = .cmdPreviewEnd.Height
			
			lngTemp = lngTemp + VB6.PixelsToTwipsX(.lblBGAPara(0).Width) + 60
			
			.txtBGAPara(0).Left = VB6.TwipsToPixelsX(lngTemp)
			.txtBGAPara(1).Left = VB6.TwipsToPixelsX(lngTemp)
			.txtBGAPara(3).Left = VB6.TwipsToPixelsX(lngTemp)
			.txtBGAPara(5).Left = VB6.TwipsToPixelsX(lngTemp)
			
			lngTemp = lngTemp + VB6.PixelsToTwipsX(.txtBGAPara(0).Width) + 180
			
			.lblBGAPara(2).Left = VB6.TwipsToPixelsX(lngTemp)
			.lblBGAPara(4).Left = VB6.TwipsToPixelsX(lngTemp)
			.lblBGAPara(6).Left = VB6.TwipsToPixelsX(lngTemp)
			
			lngTemp = lngTemp + VB6.PixelsToTwipsX(.lblBGAPara(0).Width) + 60
			
			.txtBGAPara(2).Left = VB6.TwipsToPixelsX(lngTemp)
			.txtBGAPara(4).Left = VB6.TwipsToPixelsX(lngTemp)
			.txtBGAPara(6).Left = VB6.TwipsToPixelsX(lngTemp)
			
			lngTemp = lngTemp + VB6.PixelsToTwipsX(.txtBGAPara(0).Width)
			
			.chkBGLine.Width = VB6.TwipsToPixelsX(lngTemp - 120)
			.chkLock.Width = VB6.TwipsToPixelsX(lngTemp - 120)
			
			.fraBGAPara.Width = VB6.TwipsToPixelsX(lngTemp + 60)
			
			Call .picPreview.SetBounds(0, 0, VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width) - VB6.PixelsToTwipsX(fraBGAPara.Width)), .ClientRectangle.Height)
			Call .fraBGAPara.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width) - VB6.PixelsToTwipsX(fraBGAPara.Width)), VB6.TwipsToPixelsY(60), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
			Call .fraBGACmd.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.ClientRectangle.Width) - VB6.PixelsToTwipsX(fraBGAPara.Width)), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.ClientRectangle.Height) - VB6.PixelsToTwipsY(fraBGACmd.Height) - 60), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
			
			Call .picPreview_Paint()
			
		End With
		
	End Sub
	
	Private Sub frmWindowPreview_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
		'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
		Cancel = True
		
		Call Me.Hide()
		
		Call frmMain.picMain.Focus()
		
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
	
	Public Sub picPreview_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles picPreview.Paint
		Dim modMain As Object
		
		Dim i As Integer
		
		With picPreview
			
			'UPGRADE_ISSUE: PictureBox メソッド picPreview.Cls はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call .Cls()
			
			'UPGRADE_ISSUE: PictureBox プロパティ picBackBuffer.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト modMain.BGA_PARA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call BitBlt(.hdc, (.ClientRectangle.Width \ 2 - 128) + Val(txtBGAPara(modMain.BGA_PARA.BGA_dX).Text) - Val(txtBGAPara(modMain.BGA_PARA.BGA_X1).Text), (.ClientRectangle.Height \ 2 - 128) + Val(txtBGAPara(modMain.BGA_PARA.BGA_dY).Text) - Val(txtBGAPara(modMain.BGA_PARA.BGA_Y1).Text), picBackBuffer.ClientRectangle.Width, picBackBuffer.ClientRectangle.Height, picBackBuffer.hdc, 0, 0, SRCCOPY)
			
			If chkBGLine.CheckState Then
				
				'UPGRADE_ISSUE: PictureBox プロパティ picPreview.DrawWidth はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				.DrawWidth = 1
				
				For i = 4 To .ClientRectangle.Height Step 8
					
					'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
					Call MoveToEx(.hdc, 0, i, 0)
					'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
					Call LineTo(.hdc, .ClientRectangle.Width, i)
					
				Next i
				
			End If
			
			'UPGRADE_ISSUE: PictureBox プロパティ picPreview.DrawWidth はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			.DrawWidth = 2
			
			'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call Rectangle(.hdc, .ClientRectangle.Width \ 2 - 129, .ClientRectangle.Height \ 2 - 129, .ClientRectangle.Width \ 2 + 130, .ClientRectangle.Height \ 2 + 130)
			
			'UPGRADE_WARNING: オブジェクト modMain.BGA_PARA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_ISSUE: PictureBox プロパティ picBackBuffer.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			'UPGRADE_ISSUE: PictureBox プロパティ picPreview.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			Call BitBlt(.hdc, (.ClientRectangle.Width \ 2 - 128) + Val(txtBGAPara(modMain.BGA_PARA.BGA_dX).Text), (.ClientRectangle.Height \ 2 - 128) + Val(txtBGAPara(modMain.BGA_PARA.BGA_dY).Text), lngNumField(Val(txtBGAPara(modMain.BGA_PARA.BGA_X2).Text) - Val(txtBGAPara(modMain.BGA_PARA.BGA_X1).Text), 0, 256), lngNumField(Val(txtBGAPara(modMain.BGA_PARA.BGA_Y2).Text) - Val(txtBGAPara(modMain.BGA_PARA.BGA_Y1).Text), 0, 256), picBackBuffer.hdc, Val(txtBGAPara(modMain.BGA_PARA.BGA_X1).Text), Val(txtBGAPara(modMain.BGA_PARA.BGA_Y1).Text), SRCCOPY)
			
		End With
		
	End Sub
	
	'UPGRADE_WARNING: イベント txtBGAPara.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txtBGAPara_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBGAPara.TextChanged
		Dim Index As Short = txtBGAPara.GetIndex(eventSender)
		
		If Val(txtBGAPara(Index).Text) < 0 Then txtBGAPara(Index).Text = CStr(0)
		
		Call picPreview_Paint(picPreview, New System.Windows.Forms.PaintEventArgs(Nothing, Nothing))
		
	End Sub
	
	Private Sub txtBGAPara_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBGAPara.Enter
		Dim Index As Short = txtBGAPara.GetIndex(eventSender)
		
		txtBGAPara(Index).SelectionStart = 0
		txtBGAPara(Index).SelectionLength = Len(txtBGAPara(Index).Text)
		
	End Sub
	
	Private Function lngNumField(ByVal lngNum As Integer, ByVal lngMin As Integer, ByVal lngMax As Integer) As Integer
		
		If lngNum < lngMin Then lngNum = lngMin
		
		If lngNum > lngMax Then lngNum = lngMax
		
		lngNumField = lngNum
		
	End Function
End Class
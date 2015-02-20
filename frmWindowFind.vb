Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmWindowFind
	Inherits System.Windows.Forms.Form
	
	Private m_strArray() As String
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		
		Call Me.Close()
		
	End Sub
	
	Private Sub cmdDecide_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDecide.Click
		Dim modMain As Object
		
		Dim i As Integer
		
		ReDim m_strArray(0)
		m_strArray(0) = ""
		
		For i = 0 To UBound(g_Obj) - 1
			
			With g_Obj(i)
				
				'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If (optSearchAll.Checked = True Or .intSelect = modMain.OBJ_SELECT.Selected) And (Val(txtMeasureMin.Text) <= .intMeasure And Val(txtMeasureMax.Text) >= .intMeasure) And ((modInput.strToNum((txtNumMin.Text)) <= .sngValue And modInput.strToNum((txtNumMax.Text)) >= .sngValue) Or .intCh = 8 Or .intCh = 9) Then
					
					'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.intSelect = modMain.OBJ_SELECT.NON_SELECT
					
					Select Case .intCh
						
						Case 8 'BPM
							
							If lstGrid(3).GetItemChecked(0) Then Call SearchProcess(i)
							
						Case 9 'STOP
							
							If lstGrid(3).GetItemChecked(1) Then Call SearchProcess(i)
							
						Case 11 To 15, 31 To 35, 51 To 55 '1P 1-5
							
							If lstGrid(0).GetItemChecked(.intCh Mod 10 - 1) Then Call SearchProcess(i)
							
						Case 18, 19, 38, 39, 58, 59 '1P 6-7
							
							If lstGrid(0).GetItemChecked(.intCh Mod 10 - 3) Then Call SearchProcess(i)
							
						Case 16, 36, 56 '1P SC
							
							If lstGrid(0).GetItemChecked(7) Then Call SearchProcess(i)
							
						Case 21 To 25, 41 To 45, 61 To 65 '2P 1-5
							
							If lstGrid(1).GetItemChecked(.intCh Mod 10 - 1) Then Call SearchProcess(i)
							
						Case 28, 29, 48, 49, 68, 69 '2P 6-7
							
							If lstGrid(1).GetItemChecked(.intCh Mod 10 - 3) Then Call SearchProcess(i)
							
						Case 26, 46, 66 '2P SC
							
							If lstGrid(1).GetItemChecked(7) Then Call SearchProcess(i)
							
						Case 4 'BGA
							
							If lstGrid(3).GetItemChecked(2) Then Call SearchProcess(i)
							
						Case 7 'Layer
							
							If lstGrid(3).GetItemChecked(3) Then Call SearchProcess(i)
							
						Case 6 'Poor
							
							If lstGrid(3).GetItemChecked(4) Then Call SearchProcess(i)
							
						Case Is > 100 'BGM
							
							If lstGrid(2).GetItemChecked(.intCh - 101) Then Call SearchProcess(i)
							
					End Select
					
				Else
					
					'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.intSelect = modMain.OBJ_SELECT.NON_SELECT
					
				End If
				
			End With
			
		Next i
		
		If optProcessDelete.Checked Then
			
			Call frmMain.mnuEditDelete_Click(Nothing, New System.EventArgs())
			
		ElseIf optProcessSelect.Checked Then 
			
			Call modDraw.MoveSelectedObj()
			
		ElseIf optProcessReplace.Checked Then 
			
			If UBound(m_strArray) Then
				
				Call g_InputLog.AddData(Join(m_strArray, modLog.getSeparator))
				
			End If
			
		End If
		
		Call modDraw.Redraw()
		
	End Sub
	
	Private Sub cmdReset_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReset.Click
		
		Dim i As Integer
		Dim j As Integer
		
		For i = 0 To 3
			
			With lstGrid(i)
				
				.Visible = False
				
				For j = 0 To .Items.Count - 1
					
					.SetItemChecked(j, False)
					
				Next j
				
				.SelectedIndex = 0
				.Visible = True
				
			End With
			
		Next i
		
	End Sub
	
	Private Sub cmdInvert_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdInvert.Click
		
		Dim i As Integer
		Dim j As Integer
		
		For i = 0 To 3
			
			With lstGrid(i)
				
				.Visible = False
				
				For j = 0 To .Items.Count - 1
					
					.SetItemChecked(j, Not .GetItemChecked(j))
					
				Next j
				
				.SelectedIndex = 0
				.Visible = True
				
			End With
			
		Next i
		
	End Sub
	
	Private Sub cmdSelect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelect.Click
		
		Dim i As Integer
		Dim j As Integer
		
		For i = 0 To 3
			
			With lstGrid(i)
				
				.Visible = False
				
				For j = 0 To .Items.Count - 1
					
					.SetItemChecked(j, True)
					
				Next j
				
				.SelectedIndex = 0
				.Visible = True
				
			End With
			
		Next i
		
	End Sub
	
	'UPGRADE_WARNING: Form イベント frmWindowFind.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub frmWindowFind_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		Call cmdDecide.Focus()
		
	End Sub
	
	Private Sub frmWindowFind_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		Dim i As Integer
		
		For i = 2 To 32
			
			Call lstGrid(2).Items.Add(VB6.Format(i, "00"))
			
		Next i
		
		Call cmdSelect_Click(cmdSelect, New System.EventArgs())
		
		For i = 0 To 3
			
			lstGrid(i).SelectedIndex = 0
			
		Next i
		
	End Sub
	
	Private Sub frmWindowFind_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
		'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
		Cancel = True
		
		Call Me.Hide()
		
		Call frmMain.picMain.Focus()
		
	End Sub
	
	Private Sub txtMeasureMax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMeasureMax.Enter
		
		txtMeasureMax.SelectionStart = 0
		txtMeasureMax.SelectionLength = Len(txtMeasureMax.Text)
		
	End Sub
	
	Private Sub txtMeasureMin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMeasureMin.Enter
		
		txtMeasureMin.SelectionStart = 0
		txtMeasureMin.SelectionLength = Len(txtMeasureMin.Text)
		
	End Sub
	
	Private Sub txtNumMax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNumMax.Enter
		
		txtNumMax.SelectionStart = 0
		txtNumMax.SelectionLength = Len(txtNumMax.Text)
		
	End Sub
	
	Private Sub txtNumMin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNumMin.Enter
		
		txtNumMin.SelectionStart = 0
		txtNumMin.SelectionLength = Len(txtNumMin.Text)
		
	End Sub
	
	Private Sub txtReplace_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtReplace.Enter
		
		optProcessReplace.Checked = True
		txtReplace.SelectionStart = 0
		txtReplace.SelectionLength = Len(txtReplace.Text)
		
	End Sub
	
	Private Sub SearchProcess(ByVal num As Integer)
		Dim modMain As Object
		
		With g_Obj(num)
			
			If optProcessReplace.Checked Then
				
				If .intCh <> 8 And .intCh <> 9 Then
					
					m_strArray(UBound(m_strArray)) = modInput.strFromNum(modMain.CMD_LOG.OBJ_CHANGE) & modInput.strFromNum(.lngID, 4) & modInput.strFromNum(.sngValue) & VB.Right("0" & txtReplace.Text, 2)
					ReDim Preserve m_strArray(UBound(m_strArray) + 1)
					.sngValue = modInput.strToNum((txtReplace.Text))
					
				End If
				
			End If
			
			'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.intSelect = modMain.OBJ_SELECT.Selected
			
		End With
		
	End Sub
End Class
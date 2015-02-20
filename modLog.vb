Option Strict Off
Option Explicit On
Module modLog
	
	Public Function encAdd(ByVal id As Integer, ByVal ch As Integer, ByVal att As modMain.OBJ_ATT, ByVal measure As Integer, ByVal pos As Integer, ByRef value As String) As String
		Dim modMain As Object
		
		encAdd = modInput.strFromNum(modMain.CMD_LOG.OBJ_ADD) & encAddDel(id, ch, att, measure, pos, value)
		
	End Function
	
	Public Function encDel(ByVal id As Integer, ByVal ch As Integer, ByVal att As modMain.OBJ_ATT, ByVal measure As Integer, ByVal pos As Integer, ByRef value As String) As String
		Dim modMain As Object
		
		encDel = modInput.strFromNum(modMain.CMD_LOG.OBJ_DEL) & encAddDel(id, ch, att, measure, pos, value)
		
	End Function
	
	Public Function encAddDel(ByVal id As Integer, ByVal ch As Integer, ByVal att As modMain.OBJ_ATT, ByVal measure As Integer, ByVal pos As Integer, ByRef value As String) As String
		
		encAddDel = modInput.strFromNum(id, 4) & modInput.strFromNum(ch, 2) & att & modInput.strFromNum(measure) & modInput.strFromNum(pos, 3) & value
		
	End Function
	
	Public Function decAdd(ByRef code As String, ByVal num As Integer) As g_udtObj
		
		With decAdd
			
			.lngID = modInput.strToNum(Mid(code, 3, 4))
			g_lngObjID(.lngID) = num
			.intCh = modInput.strToNum(Mid(code, 7, 2))
			.intAtt = CShort(Mid(code, 9, 1))
			.intMeasure = modInput.strToNum(Mid(code, 10, 2))
			.lngPosition = modInput.strToNum(Mid(code, 12, 3))
			.sngValue = CSng(Mid(code, 15))
			'.intSelect = Selected
			
		End With
		
	End Function
	
	Public Sub decDel(ByRef code As String)
		
		Call modDraw.RemoveObj(g_lngObjID(modInput.strToNum(Mid(code, 3, 4))))
		
	End Sub
	
	Public Sub decMove(ByRef code As String, ByRef obj As g_udtObj)
		Dim modMain As Object
		
		With obj
			
			.intCh = Val("&H" & Mid(code, 14, 2))
			.intMeasure = modInput.strToNum(Mid(code, 16, 2))
			.lngPosition = modInput.strToNum(Mid(code, 18, 3))
			'UPGRADE_WARNING: オブジェクト modMain.OBJ_SELECT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.intSelect = modMain.OBJ_SELECT.Selected
			
		End With
		
	End Sub
	
	'セパレータ文字列を返却する
	Public Function getSeparator() As String
		
		getSeparator = vbNullChar
		
	End Function
End Module
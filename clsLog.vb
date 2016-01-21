Option Strict Off
Option Explicit On
Friend Class clsLog
	
	Dim m_strArray() As String 'ログ
	Dim m_lngPos As Integer '現在位置
	Dim m_lngMax As Integer '最大値

    'コンストラクタ
    Private Sub Class_Initialize_Renamed()

        Call Me.Clear()

    End Sub
    Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'初期化
	Public Sub Clear()

        ReDim m_strArray(0)
        m_strArray(0) = ""
        m_lngPos = 0
		m_lngMax = 0
		
	End Sub

    'データの追加
    Public Sub AddData(ByRef str_Renamed As String)

        m_strArray(GetPos) = str_Renamed

        m_lngPos = m_lngPos + 1
        m_lngMax = m_lngPos

        If UBound(m_strArray) < Max() Then

            ReDim Preserve m_strArray((UBound(m_strArray) + 1) * 2 - 1)

        End If

        Call frmMain.SaveChanges()

    End Sub

    'データの取得
    Public Function GetData() As String
		
		GetData = m_strArray(m_lngPos - 1)
		
	End Function
	
	'現在位置の取得
	Public Function GetPos() As Integer
		
		GetPos = m_lngPos
		
	End Function
	
	'進む
	Public Sub Forward()
		
		m_lngPos = m_lngPos + 1
		
		If m_lngPos > Max Then m_lngPos = Max
		
	End Sub
	
	'戻る
	Public Sub Back()
		
		m_lngPos = m_lngPos - 1
		
		If m_lngPos < 0 Then m_lngPos = 0
		
	End Sub
	
	'最大サイズの取得
	Public Function Max() As Integer
		
		Max = m_lngMax
		
	End Function
	
	'使用しているメモリ量の取得
	Public Function GetBufferSize() As Integer
		
		Dim i As Integer
        Dim ret As Integer = 0

        For i = 0 To UBound(m_strArray)

            ret = ret + LenB(m_strArray(i))

        Next i
		
		GetBufferSize = ret
		
	End Function
End Class
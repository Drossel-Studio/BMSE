Option Strict Off
Option Explicit On
Friend Class clsLog
	
	Dim m_strArray() As String '���O
	Dim m_lngPos As Integer '���݈ʒu
	Dim m_lngMax As Integer '�ő�l
	
	'�R���X�g���N�^
	'UPGRADE_NOTE: Class_Initialize �� Class_Initialize_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Initialize_Renamed()
		
		Call Me.Clear()
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'������
	Public Sub Clear()
		
		ReDim m_strArray(0)
		m_lngPos = 0
		m_lngMax = 0
		
	End Sub
	
	'�f�[�^�̒ǉ�
	'UPGRADE_NOTE: str �� str_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Public Sub AddData(ByRef str_Renamed As String)
		
		m_strArray(GetPos) = str_Renamed
		
		m_lngPos = m_lngPos + 1
		m_lngMax = m_lngPos
		
		If UBound(m_strArray) < Max Then
			
			ReDim Preserve m_strArray((UBound(m_strArray) + 1) * 2 - 1)
			
		End If
		
		Call frmMain.SaveChanges()
		
	End Sub
	
	'�f�[�^�̎擾
	Public Function GetData() As String
		
		GetData = m_strArray(m_lngPos - 1)
		
	End Function
	
	'���݈ʒu�̎擾
	Public Function GetPos() As Integer
		
		GetPos = m_lngPos
		
	End Function
	
	'�i��
	Public Sub Forward()
		
		m_lngPos = m_lngPos + 1
		
		If m_lngPos > Max Then m_lngPos = Max
		
	End Sub
	
	'�߂�
	Public Sub Back()
		
		m_lngPos = m_lngPos - 1
		
		If m_lngPos < 0 Then m_lngPos = 0
		
	End Sub
	
	'�ő�T�C�Y�̎擾
	Public Function Max() As Integer
		
		Max = m_lngMax
		
	End Function
	
	'�g�p���Ă��郁�����ʂ̎擾
	Public Function GetBufferSize() As Integer
		
		Dim i As Integer
		Dim ret As Integer
		
		For i = 0 To UBound(m_strArray)
			
			'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			ret = ret + LenB(m_strArray(i))
			
		Next i
		
		GetBufferSize = ret
		
	End Function
End Class
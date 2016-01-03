Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmWindowTips
	Inherits System.Windows.Forms.Form
    Private Declare Function DrawText Lib "user32" Alias "DrawTextA" (ByVal hdc As Integer, ByRef lpStr As String, ByVal nCount As Integer, ByRef lpRect As RECT, ByVal wFormat As Integer) As Integer
    Private Const DT_WORDBREAK As Integer = &H10
	
	Dim m_sngTwipsX As Single
	Dim m_sngTwipsY As Single
	
	Dim m_strTips() As String
	Dim m_intTipsPos As Short
	Dim m_lngTipsNum As Integer
	
	'UPGRADE_WARNING: イベント chkNextDisp.CheckStateChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub chkNextDisp_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkNextDisp.CheckStateChanged
		
		Dim i As Integer
		Dim lngTemp As Integer
		Dim lngArg As Integer

        If frmMain._mnuLanguage_0.Checked Then
            If g_strLangFileName(0) <> "japanese.ini" Then
                Exit Sub
            End If
        End If
        If frmMain._mnuLanguage_1.Checked Then
            If g_strLangFileName(1) <> "japanese.ini" Then
                Exit Sub
            End If
        End If
        If frmMain._mnuLanguage_2.Checked Then
            If g_strLangFileName(2) <> "japanese.ini" Then
                Exit Sub
            End If
        End If

        If chkNextDisp.CheckState = 0 Then
			
			lngTemp = MsgBoxResult.Retry
			Call Randomize()
			
			Do While lngTemp = MsgBoxResult.Retry
				
				If Int(Rnd() * 256) = 0 Then
					
					Call MsgBox("よくわからないけど多分エラーが発生しました。" & vbCrLf & "次回も Tips を表示します。", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, g_strAppTitle)
					
					chkNextDisp.CheckState = System.Windows.Forms.CheckState.Checked
					chkNextDisp.Enabled = False
					
					Exit Do
					
				End If
				
				lngTemp = Int(Rnd() * 32) + 1
				
				If lngTemp Mod 32 = 0 Then
					
					lngArg = MsgBoxStyle.Exclamation
					
				ElseIf lngTemp Mod 16 = 0 Then 
					
					lngArg = MsgBoxStyle.Information
					
				ElseIf lngTemp Mod 8 = 0 Then 
					
					lngArg = MsgBoxStyle.Critical
					
				Else
					
					lngArg = MsgBoxStyle.Question
					
				End If
				
				If Int(Rnd() * 64) = 0 Then
					
					lngArg = lngArg Or MsgBoxStyle.MsgBoxRight
					
				End If
				
				If Int(Rnd() * 128) = 0 Then
					
					lngArg = lngArg Or MsgBoxStyle.MsgBoxRtlReading
					
				End If
				
				lngTemp = MsgBox("本当に？", MsgBoxStyle.AbortRetryIgnore Or lngArg, g_strAppTitle)
				
			Loop 
			
			Select Case lngTemp
				
				Case MsgBoxResult.Abort
					
					chkNextDisp.CheckState = System.Windows.Forms.CheckState.Checked
					
			End Select
			
		End If
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		
		Call Me.Close()
		
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
        Dim gp As Graphics = Me.CreateGraphics()

        m_intTipsPos = m_intTipsPos + 1
		
		If m_intTipsPos > UBound(m_strTips) Then m_intTipsPos = 1

        'UPGRADE_ISSUE: Form メソッド frmWindowTips.Line はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        gp.DrawRectangle(Pens.White, New Rectangle(VB6.TwipsToPixelsX(5400), VB6.TwipsToPixelsY(360), VB6.TwipsToPixelsX(180), VB6.TwipsToPixelsY(150)))

        With Me
            Dim frmWindowTips_gp As Graphics = .CreateGraphics()

            .Font = VB6.FontChangeSize(.Font, 9)

            'UPGRADE_ISSUE: Form メソッド frmWindowTips.Print はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Dim stringBrush As SolidBrush = New SolidBrush(.ForeColor)
            Dim Current As PointF = New PointF(VB6.TwipsToPixelsX(5400), VB6.TwipsToPixelsX(345))
            frmWindowTips_gp.DrawString(VB.Right(" " & m_intTipsPos, 2), .Font, stringBrush, Current)

            .Font = VB6.FontChangeSize(.Font, 12)
			
		End With

        'UPGRADE_ISSUE: Form メソッド frmWindowTips.Line はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        gp.DrawRectangle(Pens.White, New Rectangle(VB6.TwipsToPixelsX(945), VB6.TwipsToPixelsY(720), VB6.TwipsToPixelsY(5085), VB6.TwipsToPixelsY(2530)))

        Dim hDC As IntPtr = gp.GetHdc()
        Dim picIcon_gp As Graphics = picIcon.CreateGraphics()
        Dim picIcon_hDC As IntPtr = gp.GetHdc()

        'UPGRADE_ISSUE: PictureBox プロパティ picIcon.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'UPGRADE_ISSUE: Form プロパティ frmWindowTips.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        Call BitBlt(hDC, 240 * m_sngTwipsX / VB6.TwipsPerPixelX, 240 * m_sngTwipsY / VB6.TwipsPerPixelY, 32, 32, picIcon_hDC, 0, 32, SRCCOPY)

        m_lngTipsNum = 0
		
	End Sub
	
	'UPGRADE_WARNING: Form イベント frmWindowTips.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub frmWindowTips_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		With Me
			
			.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(frmMain.Left) + (VB6.PixelsToTwipsX(frmMain.Width) - VB6.PixelsToTwipsX(.Width)) \ 2)
			.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frmMain.Top) + (VB6.PixelsToTwipsY(frmMain.Height) - VB6.PixelsToTwipsY(.Height)) \ 2)
			
		End With
		
		m_sngTwipsX = 15 / VB6.TwipsPerPixelX
		m_sngTwipsY = 15 / VB6.TwipsPerPixelY
		
		m_intTipsPos = 0
		
		ReDim m_strTips(0)
		
		m_strTips(0) = " これから Tips を表示します。" & vbCrLf & vbCrLf & " これらの情報はあなたが BMSE を使い BMS を作成するのを手助けしてくれることもあるかもしれません。" & vbCrLf & vbCrLf & " 「次へ」のボタンを押して Tips を開始してください。" & vbCrLf & vbCrLf & " (この文章は一度しか表示されません)"
		
		Call AddTutorial(" BMSE は UCN-Soft が開発しています。" & vbCrLf & vbCrLf & " UCN の由来は超内輪ネタなので内緒です！")
		Call AddTutorial(" BMSE は BMx Sequence Editor の略です。知らない友達がいたら広めよう！")
		Call AddTutorial(" BMSE は bms ファイル、bme ファイル、bml ファイルおよび pms ファイルを書き出すことができます。")
		Call AddTutorial(" bms の正式名称は Be-Music Script など諸説ありますが、真相は謎のままです。")
		Call AddTutorial(" BMSE を使用するには、まず Windows OS の操作に習熟する必要があります。" & vbCrLf & vbCrLf & " マウスは片手で持ち、画面上のポインタを操作します。ディスプレイを指でなぞるわけではありません。")
		Call AddTutorial(" オブジェを配置するにはスクリーンを左クリックします。" & vbCrLf & vbCrLf & " 左クリックの仕方については、お使いの OS のマニュアルをお読みください。" & vbCrLf & vbCrLf & " (BMSE はマウスが必須です)")
		Call AddTutorial(" オブジェが配置できない？消しゴムツールになっていませんか？")
		Call AddTutorial(" 右側に表示されているテキスト・ボックスには任意の文字列を入力します。" & vbCrLf & vbCrLf & " 文字列を入力するにはキーボードが必要ですので、お使いの OS 及び言語ツールのマニュアルをお読みください。")
		Call AddTutorial(" GENRE は「ジャンル」と読み、選曲中に表示されるおおまかな曲の傾向を入力します。" & vbCrLf & vbCrLf & " よくわからない時は Techno にしてください。")
		Call AddTutorial(" bpm は Beat Per Minute の略で、1分あたりのビート数を入力します。" & vbCrLf & vbCrLf & " よくわからない時は400にしてください。")
		Call AddTutorial(" TITLE は「タイトル」と読みます。英語で「題名」を意味し、選曲中に表示される曲の題名を入力します。" & vbCrLf & vbCrLf & " よくわからない時は英和辞書を引いてください (英和辞書はお近くの書店で購入可能です)。")
		Call AddTutorial(" ARTIST は直訳すると「芸術家」となりますが、ここでは「作者」を入力してください。" & vbCrLf & vbCrLf & " よくわからない時は「DJ 苗字」としてください。例: DJ 山田")
		Call AddTutorial(" PLAYLEVEL は「譜面の難易度」です。だいたい 1 ～ 7 が bms の デファクトスタンダードです。" & vbCrLf & vbCrLf & " よくわからない時はノート数÷100にしてください。")
		Call AddTutorial(" 「基本」タブの隣に「拡張」タブおよび「環境」タブがあることにお気づきですか？" & vbCrLf & vbCrLf & " クリックすれば新たな設定を行うことが可能になります。")
		Call AddTutorial(" RANK は直訳しても意味が通じません。「判定の厳しさ」を現します。" & vbCrLf & vbCrLf & " よくわからない時は VERY HARD にしてください。")
		Call AddTutorial(" 実は BMSE は MOD に対応しています (現在隠しコマンド)。" & vbCrLf & vbCrLf & " この先を読むにはシェアウエアフィーを払う必要があります。" & vbCrLf & vbCrLf & " このソフトウェアは臓器ウェアです。気に入ったら作者に臓器を寄付してください。")
		Call AddTutorial(" テンキーを押すと、ビル・ゲイツとメッセンジャーでチャットができます。")
		Call AddTutorial(" スクリーンの一番左にある「BPM」および「STOP」レーンに注目してください！" & vbCrLf & vbCrLf & " このレーンをクリックし、単純に半角英数 (キーボードの右端にある狭い数字のみの領域を押下してください) を入力するだけで、プレイヤーを翻弄することができます。")
		Call AddTutorial(" BMSE はマウマニに対応していません。本当だよ！")
		Call AddTutorial(" てっとり早く bms を作るには、wav を使用せずに作るのが一番です。" & vbCrLf & vbCrLf & " 絵を描く感覚でスクリーンにオブジェを配置 (左クリック) すれば bms が完成！簡単でしょ？")
		Call AddTutorial(" 「基本」タブの一番上にある「プレイモード」を Double Play にしてみましょう。鍵盤の数が倍増し、より「太い」譜面を作ることができます。" & vbCrLf & vbCrLf & " また、2 Player を選びますと、実際のゲームで鍵盤が半分ごとにスクリーンの端に分裂して表示されます。これにより、視覚的な効果で難易度を急上昇させることができます｡ ")
		Call AddTutorial(" 「拍子」タブで 3 / 6 にしてみましょう。新たなリズムを得ることができます。")
		Call AddTutorial(" 左端の5つの鍵盤とスクラッチを使用した譜面は「bms」で、" & vbCrLf & vbCrLf & " 7つの鍵盤とスクラッチを使用した譜面は「bme」で、" & vbCrLf & vbCrLf & " 4つのマウスを使用した譜面は「mmx」で保存しましょう (現在実装されていません)。")
		Call AddTutorial(" コーラを飲みながら bms を作らないでください。シミができる可能性があります。")
		Call AddTutorial(" TOTAL 値を変更することにより、ゲージの上昇率を変更することができます。" & vbCrLf & vbCrLf & " 通常 TOTAL 値のデフォルトは bms の仕様によって 200 + Total Notes と決められていますが、一部仕様に則っていないプレイヤーもありますのでご注意ください｡ ")
		Call AddTutorial(" VOLWAV は明言されていませんが、VOLume of WAVe の略だと思われます。" & vbCrLf & vbCrLf & " よくわからない時は0にし、タイトルを「4:33」にするとよいようです。")
		Call AddTutorial(" 今回の BMSE から新たな機能が追加されました。" & vbCrLf & vbCrLf & " より多くの Tips を読むことができます。")
		Call AddTutorial(" このソフトウェアはいかにもバグのような振る舞いをすることがありますが、" & vbCrLf & vbCrLf & " しかしそれは仕様です｡ ")
		Call AddTutorial(" このウィンドウのどこでもいいので、15回クリックしてください。" & vbCrLf & " ....." & vbCrLf & " ...." & vbCrLf & " ..." & vbCrLf & " .." & vbCrLf & " ." & vbCrLf & vbCrLf & " ほら、何も起きないでしょう。")
		Call AddTutorial(" 「拍子」タブで 10 / 572 にしてみましょう。新たなリズムを得ることができます。")
		Call AddTutorial(" BMSE で作成された BMS はビート魔にやりで再生できる保証はありません。")
		Call AddTutorial(" 定期的に公式サイトをご覧ください。" & vbCrLf & vbCrLf & " http://www.killertomatoes.com/")
		Call AddTutorial(" 何か忘れてないか？")
		Call AddTutorial(" BMSE にイースターエッグはございません (本当だよ！)")
		Call AddTutorial(" BMSE にイースターエッグはありませんが、Tips を表示するウルテクがあります。あなたはもう発見しましたか？")
		Call AddTutorial(" 最新版の BMSE がリリースされているか確認してください！" & vbCrLf & vbCrLf & " お友達全員に BMS が作れるクールな BMSE のすばらしさを教えてあげよう！")
		Call AddTutorial(" この Tips はイースターエッグです。" & vbCrLf & vbCrLf & " 夜寝ながら働かずに作ったこのソフトウェアがみなさんに気に入っていただけるよう、tokonats氏が望んでいることでしょう。")

        Dim gp As Graphics = Me.CreateGraphics()
        Dim hDC As IntPtr

        Dim picIcon_gp As Graphics = picIcon.CreateGraphics()
        Dim picIcon_hDC As IntPtr = gp.GetHdc()

        With Me

            gp.ReleaseHdc()

            'UPGRADE_ISSUE: Form メソッド frmWindowTips.Line はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            gp.DrawRectangle(Pens.Gray, New Rectangle(VB6.TwipsToPixelsX(120), VB6.TwipsToPixelsY(120), VB6.TwipsToPixelsX(720), VB6.TwipsToPixelsY(3210)))

            'UPGRADE_ISSUE: Form メソッド frmWindowTips.Line はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            gp.DrawRectangle(Pens.White, New Rectangle(VB6.TwipsToPixelsX(855), VB6.TwipsToPixelsY(120), VB6.TwipsToPixelsX(5265), VB6.TwipsToPixelsY(3210)))

            'UPGRADE_ISSUE: Form メソッド frmWindowTips.Line はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            gp.DrawRectangle(Pens.Black, New Rectangle(VB6.TwipsToPixelsX(855), VB6.TwipsToPixelsY(615), VB6.TwipsToPixelsX(5265), VB6.TwipsToPixelsY(0)))

            .Font = VB6.FontChangeSize(.Font, 16)
            .Font = VB6.FontChangeBold(.Font, True)

            Dim stringBrush As SolidBrush = New SolidBrush(.ForeColor)
            Dim Current As PointF = New PointF(VB6.TwipsToPixelsX(960), VB6.TwipsToPixelsX(210))
            gp.DrawString("ご存知ですか...", .Font, stringBrush, Current)

            .Font = VB6.FontChangeSize(.Font, 9)
            .Font = VB6.FontChangeBold(.Font, False)

            Current = New PointF(VB6.TwipsToPixelsX(5400), VB6.TwipsToPixelsX(345))
            gp.DrawString(" 0 / " & UBound(m_strTips), .Font, stringBrush, Current)
            'UPGRADE_ISSUE: Form メソッド frmWindowTips.Print はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。

            .Font = VB6.FontChangeSize(.Font, 12)

            hDC = gp.GetHdc()

            'UPGRADE_ISSUE: PictureBox プロパティ picIcon.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            'UPGRADE_ISSUE: Form プロパティ frmWindowTips.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call BitBlt(hDC, 240 * m_sngTwipsX / VB6.TwipsPerPixelX, 240 * m_sngTwipsY / VB6.TwipsPerPixelY, 32, 32, picIcon_hDC, 0, 32, SRCCOPY)

            gp.ReleaseHdc()
        End With

        'UPGRADE_ISSUE: Form メソッド frmWindowTips.Line はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        gp.DrawRectangle(Pens.White, New Rectangle(VB6.TwipsToPixelsX(960), VB6.TwipsToPixelsY(720), VB6.TwipsToPixelsX(6075), VB6.TwipsToPixelsY(3270)))
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        'UPGRADE_ISSUE: Form プロパティ frmWindowTips.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。

        hDC = gp.GetHdc()

        Call DrawText(hDC, m_strTips(0), LenB(m_strTips(0)), ddRect(63, 48, 402, 216), DT_WORDBREAK)

        m_lngTipsNum = Len(m_strTips(0))

        chkNextDisp.CheckState = System.Windows.Forms.CheckState.Checked
		
		tmrMain.Enabled = True
		
		Call cmdNext.Focus()
		
	End Sub
	
	Private Sub frmWindowTips_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub tmrMain_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMain.Tick

        Dim strTemp As String

        Dim gp As Graphics = Me.CreateGraphics()

        Dim picIcon_gp As Graphics = picIcon.CreateGraphics()
        Dim picIcon_hDC As IntPtr = gp.GetHdc()

        m_lngTipsNum = m_lngTipsNum + 1
        tmrMain.Interval = 100

        'UPGRADE_ISSUE: Form メソッド frmWindowTips.Line はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        gp.DrawRectangle(Pens.White, New Rectangle(VB6.TwipsToPixelsX(945), VB6.TwipsToPixelsY(720), VB6.TwipsToPixelsX(6030), VB6.TwipsToPixelsY(3240)))

        Dim hDC As IntPtr = gp.GetHdc()

        If m_lngTipsNum >= Len(m_strTips(m_intTipsPos)) + 1 Then

            tmrMain.Interval = 250

            'If (m_lngTipsNum \ 2) Mod 2 Then
            If (m_lngTipsNum \ 2) And 1 Then

                strTemp = m_strTips(m_intTipsPos)

            Else

                strTemp = m_strTips(m_intTipsPos) & "_"

            End If

            'If m_lngTipsNum Mod 2 Then
            If m_lngTipsNum And 1 Then

                'Call BitBlt(frmWindowTips.hdc, 16 * m_sngTwipsX, 16 * m_sngTwipsY, 32, 32, picIcon.hdc, 0, 32, SRCCOPY)
                'UPGRADE_ISSUE: PictureBox プロパティ picIcon.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'UPGRADE_ISSUE: Form プロパティ frmWindowTips.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                Call BitBlt(hDC, 240 * m_sngTwipsX / VB6.TwipsPerPixelX, 240 * m_sngTwipsY / VB6.TwipsPerPixelY, 32, 32, picIcon_hDC, 0, 32, SRCCOPY)

            Else

                'Call BitBlt(frmWindowTips.hdc, 16 * m_sngTwipsX, 16 * m_sngTwipsY, 32, 32, picIcon.hdc, 0, 0, SRCCOPY)
                'UPGRADE_ISSUE: PictureBox プロパティ picIcon.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'UPGRADE_ISSUE: Form プロパティ frmWindowTips.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                Call BitBlt(hDC, 240 * m_sngTwipsX / VB6.TwipsPerPixelX, 240 * m_sngTwipsY / VB6.TwipsPerPixelY, 32, 32, picIcon_hDC, 0, 0, SRCCOPY)

            End If

            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            'UPGRADE_ISSUE: Form プロパティ frmWindowTips.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call DrawText(hDC, strTemp, LenB(strTemp), ddRect(63, 48, 402, 216), DT_WORDBREAK)

        Else

            strTemp = VB.Left(m_strTips(m_intTipsPos), m_lngTipsNum) & "_"

            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            'UPGRADE_ISSUE: Form プロパティ frmWindowTips.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            Call DrawText(hDC, strTemp, LenB(strTemp), ddRect(63, 48, 402, 216), DT_WORDBREAK)

            Select Case VB.Right(strTemp, 2)

                Case vbCrLf & "_"

                    tmrMain.Interval = 1

                Case " _"

                    tmrMain.Interval = 50

                Case "、_", "(_", ")_", "「_", "」_", "～_"

                    tmrMain.Interval = 200

                Case "。_", "！_", "？_", ":_", "/_", "._"

                    tmrMain.Interval = 400

            End Select

        End If

    End Sub

    Private Function ddRect(ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As RECT

        With ddRect
            .Top = Y1 * m_sngTwipsY
            .left_Renamed = X1 * m_sngTwipsX
            .right_Renamed = X2 * m_sngTwipsX
            .Bottom = Y2 * m_sngTwipsY
        End With

    End Function

    'UPGRADE_NOTE: str は str_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
    Private Sub AddTutorial(ByRef str_Renamed As String)

        ReDim Preserve m_strTips(UBound(m_strTips) + 1)

        m_strTips(UBound(m_strTips)) = str_Renamed

    End Sub

    Private Sub frmWindowTips_FormClosed(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class
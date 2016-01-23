Option Strict Off
Option Explicit On

Module modMessage

    ' ---------- 標準モジュール ----------
    Private Structure COPYDATASTRUCT
        Dim dwData As Integer
        Dim cbData As Integer
        Dim lpData As Integer
    End Structure

    'サブクラス化関数
    Public Delegate Function WindowProcDelegate(ByVal hwnd As IntPtr, ByVal uMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongW" (ByVal hwnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As WindowProcDelegate) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongW" (ByVal hwnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    Private Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcW" (ByVal lpPrevWndFunc As IntPtr, ByVal hwnd As IntPtr, ByVal MSG As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Private Declare Function GetActiveWindow Lib "user32" () As IntPtr

    Public Declare Function SendMessage Lib "user32" Alias "SendMessageW" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Private Const GWL_WNDPROC As Integer = (-4) 'ウインドウプロシージャ

    Private Const WM_ACTIVATE As Integer = &H6
    Private Const WM_ACTIVATEAPP As Integer = &H1C
    Private Const WM_SETCURSOR As Integer = &H20
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const WM_HSCROLL As Integer = &H114
    Private Const WM_VSCROLL As Integer = &H115
    Private Const WM_CTLCOLORSCROLLBAR As Integer = &H137
    Private Const WM_MOUSEWHEEL As Integer = &H20A

    Public Const WM_CUT As Integer = &H300
    Public Const WM_COPY As Integer = &H301
    Public Const WM_PASTE As Integer = &H302
    Public Const WM_CLEAR As Integer = &H303
    Public Const WM_UNDO As Integer = &H304

    Private Const MM_MCINOTIFY As Integer = &H3B9

    Private Const MCI_NOTIFY_SUCCESSFUL As Integer = 1
    Private Const MCI_NOTIFY_SUPERSEDED As Integer = 2
    Private Const MCI_NOTIFY_ABORTED As Integer = 4
    Private Const MCI_NOTIFY_FAILURE As Integer = 8

    Private Const WA_ACTIVE As Integer = 1
    Private Const WA_CLICKACTIVE As Integer = 2
    Private Const WA_INACTIVE As Integer = 0

    Private Const SB_LINEUP As Integer = 0
    Private Const SB_LINEDOWN As Integer = 1
    Private Const SB_PAGEUP As Integer = 2
    Private Const SB_PAGEDOWN As Integer = 3
    Private Const SB_THUMBPOSITION As Integer = 4
    Private Const SB_THUMBTRACK As Integer = 5
    Private Const SB_TOP As Integer = 6
    Private Const SB_BOTTOM As Integer = 7
    Private Const SB_ENDSCROLL As Integer = 8

    'デフォルトのウインドウプロシージャ
    Public OldWindowhWnd As Integer


    '---------------------------------------------------------------------------
    ' 関数名： SubClass
    ' 機能 ： サブクラス化を開始する
    ' 引数 ： (in) hWnd … 対象フォームのウインドウハンドル
    ' 返り値 ： なし
    '---------------------------------------------------------------------------
    Public Sub SubClass(ByVal hwnd As Integer)


        OldWindowhWnd = SetWindowLong(hwnd, GWL_WNDPROC, AddressOf WindowProc)


    End Sub


    '---------------------------------------------------------------------------
    ' 関数名： UnSubClass
    ' 機能 ： サブクラス化を終了する
    ' 引数 ： (in) hWnd … 対象フォームのウインドウハンドル
    ' 返り値 ： なし
    '---------------------------------------------------------------------------
    Public Sub UnSubClass(ByVal hwnd As Integer)

        If OldWindowhWnd <> 0 Then

            '元のプロシージャアドレスに設定する
            SetWindowLong(hwnd, GWL_WNDPROC, OldWindowhWnd)

            OldWindowhWnd = 0

        End If

    End Sub

    '---------------------------------------------------------------
    ' 関数名： strNullCut
    ' 機能 ： 文字列を vbNullChar までを取得する
    ' 引数 ： (in) srcStr … 対象文字列
    ' 返り値 ：編集された文字列
    '---------------------------------------------------------------
    Public Function strNullCut(ByVal srcStr As String) As String


        Dim NullCharPos As Integer


        NullCharPos = InStr(srcStr, Chr(0))


        If NullCharPos = 0 Then

            strNullCut = srcStr

            Exit Function

        End If


        strNullCut = Left(srcStr, NullCharPos - 1)


    End Function


    '次は、受信する側のコード。文字列取得方法は取得した文字列へのポインタより NULL までの長さを取得し、その長さ分バイト単位でコピーしてやればよい。



    '-------------------------------------------------------------------------
    ' 関数名： WindowProc
    ' 機能 ： ウインドウメッセージをフックする
    ' 引数 ： (in) hWnd … 対象フォームのウインドウハンドル
    '　　　　　(in) uMsg … ウインドウメッセージ
    '　　　　　(in) wParam … 追加情報１
    '　　　　　(in) lParam … 追加情報２
    ' 返り値 ： なし
    ' 備考 ： 特になし
    '---------------------------------------------------------------------------
    Public Function WindowProc(ByVal hwnd As Integer, ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer


        'Dim udtCDP As COPYDATASTRUCT
        'Dim SentText As String '送られてきた文字列
        'Dim SentTextLen As Long '送られてきた文字列の数

        Dim lngTemp As Integer


        If frmMain.Handle.ToInt32 = GetActiveWindow() Then

            Select Case uMsg

                Case WM_ACTIVATEAPP

                    If wParam Then

                        If frmMain._mnuOptionsItem_0.Checked Then g_blnIgnoreInput = True

                    End If

                Case WM_SETCURSOR

                    If wParam <> frmMain.picMain.Handle.ToInt32 Then

                        g_Obj(UBound(g_Obj)).intCh = 0

                        frmMain.staMain.Items.Item("Position").Text = "Position:"

                        'Call frmMain.picMain.Cls
                        'Call modEasterEgg.DrawEffect()

                        Select Case wParam

                            Case frmMain.lstWAV.Handle.ToInt32

                                Call frmMain.lstWAV.Focus()

                            Case frmMain.lstBMP.Handle.ToInt32

                                Call frmMain.lstBMP.Focus()

                            Case frmMain.lstBGA.Handle.ToInt32

                                Call frmMain.lstBGA.Focus()

                            Case frmMain.lstMeasureLen.Handle.ToInt32

                                Call frmMain.lstMeasureLen.Focus()

                        End Select

                    Else

                        'Call frmMain.vsbMain.SetFocus
                        Call frmMain.picMain.Focus()

                    End If

                Case WM_MOUSEWHEEL

                    If HWORD(wParam) > 0 Then

                        lngTemp = SB_LINEUP

                    Else

                        lngTemp = SB_LINEDOWN

                    End If

                    Call WindowProc(frmMain.Handle.ToInt32, WM_VSCROLL, lngTemp, frmMain.vsbMain.Handle.ToInt32)
                    Call WindowProc(frmMain.Handle.ToInt32, WM_VSCROLL, SB_ENDSCROLL, frmMain.vsbMain.Handle.ToInt32)

                Case MM_MCINOTIFY

                    If wParam = MCI_NOTIFY_SUCCESSFUL Then

                        Call mciSendString("close PREVIEW", vbNullString, 0, 0)

                    End If

                Case WM_CTLCOLORSCROLLBAR 'スクロールバー変な色対策

                    Exit Function

            End Select

            'Debug.Print uMsg, wParam, lParam, frmMain.hsbMain.hwnd

        End If

        WindowProc = CallWindowProc(OldWindowhWnd, hwnd, uMsg, wParam, lParam)

    End Function

    Public Function HWORD(ByVal LongValue As Integer) As Short

        '長整数値から上位ワードを取得する
        HWORD = (LongValue And &HFFFF0000) \ &H10000

    End Function

    Public Function LWORD(ByVal LongValue As Integer) As Short

        '長整数値から下位ワードを取得する
        If (LongValue And &HFFFF) > &H7FFF Then

            LWORD = CShort(LongValue And &HFFFF) - &H10000

        Else

            LWORD = LongValue And &HFFFF

        End If

    End Function
End Module
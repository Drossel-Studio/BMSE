Option Strict Off
Option Explicit On
Friend Class frmWindowInput
	Inherits System.Windows.Forms.Form

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        Call Me.Close()

    End Sub

    Private Sub cmdDecide_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDecide.Click

        Call Me.Hide()

        Call frmMain.picMain.Focus()

    End Sub

    'UPGRADE_WARNING: Form イベント frmWindowInput.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    Private Sub frmWindowInput_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        txtMain.SelectionStart = 0
        txtMain.SelectionLength = Len(txtMain.Text)

        lblMainDisp.AutoSize = True

        Call lblMainDisp.SetBounds(VB6.TwipsToPixelsX(60), VB6.TwipsToPixelsY(60), VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 60 - 60), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
        Call txtMain.SetBounds(VB6.TwipsToPixelsX(60), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lblMainDisp.Top) + VB6.PixelsToTwipsY(lblMainDisp.Height) + 60), VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 120), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
        Call cmdCancel.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 60 - VB6.PixelsToTwipsX(cmdCancel.Width)), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtMain.Top) + VB6.PixelsToTwipsY(txtMain.Height) + 60), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
        Call cmdDecide.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(cmdCancel.Left) - 60 - VB6.PixelsToTwipsX(cmdDecide.Width)), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtMain.Top) + VB6.PixelsToTwipsY(txtMain.Height) + 60), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)

        With frmMain

            Call Me.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.Left) + (VB6.PixelsToTwipsX(.Width) - VB6.PixelsToTwipsX(Me.Width)) \ 2), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Top) + (VB6.PixelsToTwipsY(.Height) - VB6.PixelsToTwipsY(Me.Height)) \ 2), Me.Width, VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(cmdDecide.Top) + VB6.PixelsToTwipsY(cmdDecide.Height) + 60 + (VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(Me.ClientRectangle.Height))))

        End With

        Call txtMain.Focus()

    End Sub

    Private Sub frmWindowInput_FormClosed(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True

        txtMain.Text = ""

        Call Me.Hide()

        Call frmMain.picMain.Focus()
    End Sub
End Class
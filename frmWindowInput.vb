Option Strict Off
Option Explicit On
Friend Class frmWindowInput
	Inherits System.Windows.Forms.Form

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        DialogResult = DialogResult.Cancel

        Call Me.Close()

    End Sub

    Private Sub cmdDecide_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDecide.Click

        Call Me.Hide()

        Call frmMain.picMain.Focus()

        DialogResult = DialogResult.OK

    End Sub

    'UPGRADE_WARNING: Form イベント frmWindowInput.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    Private Sub frmWindowInput_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        txtMain.SelectionStart = 0
        txtMain.SelectionLength = Len(txtMain.Text)

        lblMainDisp.AutoSize = True

        Call lblMainDisp.SetBounds(4, 4, Me.Width - 4 - 4, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
        Call txtMain.SetBounds(4, lblMainDisp.Top + lblMainDisp.Height + 4, Me.ClientRectangle.Width - 8, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
        Call cmdCancel.SetBounds(Me.ClientRectangle.Width - 4 - cmdCancel.Width, txtMain.Top + txtMain.Height + 4, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
        Call cmdDecide.SetBounds(cmdCancel.Left - 4 - cmdDecide.Width, txtMain.Top + txtMain.Height + 4, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)

        With frmMain

            Call Me.SetBounds(.Left + (.Width - Me.Width) \ 2, .Top + (.Height - Me.Height) \ 2, Me.Width, cmdDecide.Top + cmdDecide.Height + 60 + (Me.Height - Me.ClientRectangle.Height))

        End With

        Call txtMain.Focus()

    End Sub

    Private Sub frmWindowInput_FormClosed(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True

        If DialogResult <> DialogResult.OK Then
            txtMain.Text = ""
            DialogResult = DialogResult.Cancel
        End If

        Call Me.Hide()

        Call frmMain.picMain.Focus()
    End Sub
End Class
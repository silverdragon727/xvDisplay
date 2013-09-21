Public Class StageForm

    Dim ctrl As Controller

    Private Sub OnLoaded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SBSLibrary.StandardIO.Output = AddressOf DebugForm.Print
        ctrl = New Controller()
        ctrl.Start()
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        Select Case e.KeyChar
            Case "c"c
                ctrl.Dispose()
                ctrl = New Controller()
                ctrl.Start()
            Case "d"c
                DebugForm.Visible = Not DebugForm.Visible
            Case "l"c
                For i As Integer = 0 To 100
                    ctrl.Dispose()
                    ctrl = New Controller()
                    ctrl.Start()
                Next
            Case "q"c
                DebugForm.closeFlag = True
                Application.Exit()
        End Select

        MyBase.OnKeyPress(e)
    End Sub
End Class

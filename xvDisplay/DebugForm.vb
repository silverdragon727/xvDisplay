Public NotInheritable Class DebugForm

    Private Sub OnLoaded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OutputTextBox.Top = -2
        OutputTextBox.Left = -2
        OutputTextBox.Height = Me.ClientSize.Height + 4
        OutputTextBox.Width = Me.ClientSize.Width + 4
    End Sub

    Public Sub Print(ByVal str As String)
        OutputTextBox.AppendText(Date.Now.ToString("[HH:mm:ss.fff] "))
        ' OutputTextBox.AppendText(String.Format("[{0}] ", Date.Now.ToString("HH:mm:ss.fff")))
        ' If Not str.EndsWith(vbCrLf) Then
        ' str += vbCrLf
        ' End If
        ' 不要通过 += 运算符连接字符串 (性能问题)。此处可直接 AppendText。
        OutputTextBox.AppendText(str)
        If Not str.EndsWith(vbCrLf, StringComparison.OrdinalIgnoreCase) Then
            OutputTextBox.AppendText(vbCrLf)
        End If
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        OutputTextBox.Height = Me.ClientSize.Height + 4
        OutputTextBox.Width = Me.ClientSize.Width + 4
        MyBase.OnResize(e)
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        Me.Hide()
        e.Cancel = (e.CloseReason = CloseReason.UserClosing)
        MyBase.OnFormClosing(e)
    End Sub
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebugForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout
        '
        'OutputTextBox
        '
        Me.OutputTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.OutputTextBox.Font = New System.Drawing.Font("Consolas", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OutputTextBox.ForeColor = System.Drawing.Color.LawnGreen
        Me.OutputTextBox.Location = New System.Drawing.Point(-2, -2)
        Me.OutputTextBox.Multiline = true
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.ReadOnly = true
        Me.OutputTextBox.Size = New System.Drawing.Size(502, 293)
        Me.OutputTextBox.TabIndex = 0
        '
        'DebugForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 287)
        Me.Controls.Add(Me.OutputTextBox)
        Me.Name = "DebugForm"
        Me.Text = "Debug - Standard I/O"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox
End Class

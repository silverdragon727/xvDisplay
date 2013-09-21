Public Class Controller
    Implements IDisposable

    Public Const Version As String = "v0.1a1"

    Friend Drawer As Draw
    Friend ItemTable As Items.ItemTable
    Friend ResTable As Resources.ResourceTable
    Friend Configuration As Configuration
    Friend ScriptEngine As SBSLibrary.SBSEngine
    Friend ScriptFunctions As ScriptFuncLib

    Sub New()
        ' 常量不使用 String.Format，以便编译器优化
        SBSLibrary.StandardIO.PrintLine("xvDisplay Controller " & Version & " Initializing... ")
        ItemTable = New Items.ItemTable()
        ResTable = New Resources.ResourceTable()

        SBSLibrary.StandardIO.PrintLine("Script Engine Initializing...")
        ScriptEngine = New SBSLibrary.SBSEngine()
        ScriptFunctions = New ScriptFuncLib(Me)

        Drawer = New Draw(ItemTable, ResTable, ScriptEngine)
        Configuration = New Configuration(Drawer, ItemTable, ResTable, ScriptEngine)

        SBSLibrary.StandardIO.PrintLine("Initialized.")
    End Sub

    Sub Start()

#If DEBUG Then
        DebugForm.Show()
#End If

        Try
            Configuration.LoadConfFile("startup.xdc", False)
        Catch ex As Exception
            SBSLibrary.StandardIO.PrintLine(String.Concat("Error: ", ex.Message))
        End Try

    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 检测冗余的调用

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Drawer.Dispose()
                ItemTable.Clear()
                ResTable.Dispose()
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' 不要更改此代码。请将清理代码放入上面的 Dispose(ByVal disposing As Boolean)中。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

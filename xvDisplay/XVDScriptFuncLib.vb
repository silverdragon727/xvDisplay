Imports SBSLibrary

Public NotInheritable Class ScriptFuncLib
    Dim Controller As Controller

    Sub New(ByRef _controller As Controller)
        Controller = _controller

        Controller.ScriptEngine.AddFunction(New LibFunction("xvdreadconf", AddressOf XVDReadConf, 1))
        Controller.ScriptEngine.AddFunction(New LibFunction("xvdreadglobalconf", AddressOf XVDReadGlobalConf, 1))
        Controller.ScriptEngine.AddFunction(New LibFunction("xvdremovetempconf", AddressOf XVDRemoveTempConf, 1))
        Controller.ScriptEngine.AddFunction(New LibFunction("xvddrawitemset", AddressOf XVDDrawItemSet, 1))
        Controller.ScriptEngine.AddFunction(New LibFunction("xvddraw", AddressOf XVDDraw))
        Controller.ScriptEngine.AddFunction(New LibFunction("xvdchangeitemres", AddressOf XVDChangeItemRes, 4))
        Controller.ScriptEngine.AddFunction(New LibFunction("xvdsetdrawingupdateflag", AddressOf XVDSetDrawingUpdateFlag))
        Controller.ScriptEngine.AddFunction(New LibFunction("xvdexit", AddressOf XVDExit))

    End Sub

    Public Function XVDReadConf(ByRef argsList As ArrayList) As SBSValue
        Dim confPath As SBSValue = CType(argsList(0), SBSValue)

        Controller.Configuration.LoadConfFile(CType(confPath.Value, String), True)
        Return Nothing
    End Function

    Public Function XVDReadGlobalConf(ByRef argsList As ArrayList) As SBSValue
        Dim confPath As SBSValue = CType(argsList(0), SBSValue)

        Controller.Configuration.LoadConfFile(CType(confPath.Value, String), False)
        Return Nothing
    End Function

    ' TODO: 建议改为 XVDUnloadLocalConf
    Public Function XVDRemoveTempConf(ByRef argsList As ArrayList) As SBSValue
        Controller.ResTable.DisposeTempResources()
        Controller.ItemTable.DisposeTempItems()
        Return Nothing
    End Function

    Public Function XVDDrawItemSet(ByRef argslist As ArrayList) As SBSValue
        Dim setName As SBSValue = CType(argslist(0), SBSValue)
        Controller.Drawer.DrawItemSet(CType(setName.Value, String))
        Return Nothing
    End Function

    Public Function XVDDraw(ByRef argslist As ArrayList) As SBSValue
        Controller.Drawer.Draw()
        Return Nothing
    End Function

    Public Function XVDChangeItemRes(ByRef argslist As ArrayList) As SBSValue
        Dim itemName As String = CType(argslist(0).Value, String)
        Dim resType As String = CType(argslist(1).Value, String)
        Dim resPtr As Integer = Controller.ResTable.PointerOf(CType(argslist(2).Value, String))
        Dim status As Integer = GetStatusByName(CType(argslist(3).Value, String))

        Dim resptrs?() As Integer = Controller.ItemTable(itemName).GetResourceByType(resType)

        If resptrs IsNot Nothing Then
            resptrs(status) = resPtr
            Controller.Drawer.Update = Draw.UpdateFlag.Reflow
        Else
            Throw New ApplicationException(String.Format("Undefined item ""{0}"".", itemName))
        End If
        Return Nothing
    End Function

    Public Function XVDSetDrawingUpdateFlag(ByRef argslist As ArrayList) As SBSValue
        Dim before As Draw.UpdateFlag = Controller.Drawer.Update

        If Not [Enum].TryParse(argslist(0).Value, True, Controller.Drawer.Update) Then _
            Controller.Drawer.Update = before
        Return Nothing
    End Function

    Public Function XVDExit(ByRef argslist As ArrayList) As SBSValue
        DebugForm.closeFlag = True
        Application.Exit()
        Return Nothing
    End Function

    Private Shared Function GetStatusByName(ByVal name As String) As Items.EventType
        Dim type As Items.EventType
        If Not [Enum].TryParse(name, True, type) Then type = Items.EventType.Normal
        Return type
    End Function
End Class

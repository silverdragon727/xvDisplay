Imports System.Runtime.CompilerServices

Friend Module Extensions

    <Extension>
    Function HasValue(ByVal s As String) As Boolean
        Return Not String.IsNullOrEmpty(s)
    End Function

End Module

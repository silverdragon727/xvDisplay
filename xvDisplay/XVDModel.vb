Imports System.Collections.ObjectModel
Imports System.Windows.Markup

Namespace Model

    Public Interface IObjectTag
        Property Name As String
    End Interface

    <Ambient, UsableDuringInitialization(True)>
    Public MustInherit Class ObjectTable(Of T As IObjectTag)
        Inherits ObjectModel.KeyedCollection(Of String, T)

        Protected Const InvalidFlag As Integer = Integer.MinValue

        Public Shadows Function Add(tag As T) As Integer
            If tag Is Nothing Then Throw New ArgumentNullException("tag")
            ' tags 添加 tag 前的 Count 即为加入的 tag 索引
            Dim index = Count
            MyBase.Add(tag)
            Return index
        End Function

        <Obsolete("Please use Item(Integer) instead of GetItemByPtr(Integer)")>
        Public Function GetItemByPtr(ByVal ptr As Integer) As T
            Return Item(ptr)
        End Function

        <Obsolete("Please use Item(String) instead of GetItemByName(String)")>
        Public Function GetItemByName(ByVal name As String) As T
            Return Item(name)
        End Function

        Protected Overrides Function GetKeyForItem(item As T) As String
            If item.Name.HasValue Then
                Return item.Name
            Else : Return Nothing
            End If
        End Function
    End Class
End Namespace
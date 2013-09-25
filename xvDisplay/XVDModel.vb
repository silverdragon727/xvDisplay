Imports System.Collections.ObjectModel
Imports System.Windows.Markup

Namespace Model

    Public Interface IObjectTag
        Property Name As String
    End Interface

    <Ambient, UsableDuringInitialization(True)>
    Public MustInherit Class ObjectTable(Of T As IObjectTag)
        Inherits ObjectModel.Collection(Of T)

        ' Tag 名称与索引的键值对
        Protected nameMap As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)

        Protected Const InvalidFlag As Integer = Integer.MinValue

        Public Shadows Function Add(tag As T) As Integer
            If tag Is Nothing Then Throw New ArgumentNullException("tag")
            ' tags 添加 tag 前的 Count 即为加入的 tag 索引
            Dim index = Count
            MyBase.Add(tag)
            Return index
        End Function

        Protected NotOverridable Overrides Sub InsertItem(index As Integer, item As T)
            Dim name = Item.Name
            If name.HasValue Then nameMap.Add(name, index)
            MyBase.InsertItem(index, item)
        End Sub

        Protected NotOverridable Overrides Sub RemoveItem(index As Integer)
            Dim name = Items(index).Name
            If name.HasValue Then nameMap.Remove(name)
            MyBase.RemoveItem(index)
        End Sub

        Protected NotOverridable Overrides Sub SetItem(index As Integer, item As T)
            Dim name = Items(index).Name
            If name.HasValue Then nameMap(name) = index
            MyBase.SetItem(index, item)
        End Sub

        Default Overloads ReadOnly Property Item(ByVal name As String) As T
            Get
                Return Item(nameMap(name))
            End Get
        End Property

        Public Function PointerOf(ByVal name As String) As Integer
            Return nameMap(name)
        End Function

        <Obsolete("Please use Item(Integer) instead of GetItemByPtr(Integer)")>
        Public Function GetItemByPtr(ByVal ptr As Integer) As T
            Return Item(ptr)
        End Function

        <Obsolete("Please use Item(String) instead of GetItemByName(String)")>
        Public Function GetItemByName(ByVal name As String) As T
            Return Item(name)
        End Function

    End Class
End Namespace
Imports System.Collections.ObjectModel
Imports System.Windows.Markup

Namespace Model

    Public Interface IObjectTag
        Property Name As String
    End Interface

    <Ambient, UsableDuringInitialization(True)>
    Public MustInherit Class ObjectTable(Of T As IObjectTag)
        Implements ICollection(Of T)

        Protected nameMap As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        Protected tags As List(Of T) = New List(Of T)

        Protected Sub AddTag(item As T) Implements ICollection(Of T).Add
            tags.Add(item)
        End Sub

        Public Function Add(tag As T) As Integer
            If tag Is Nothing Then Throw New ArgumentNullException("tag")
            ' tags 添加 tag 前的 Count 即为加入的 tag 索引
            Dim index = tags.Count
            AddTag(tag)

            If tag.Name.HasValue Then _
                nameMap.Add(tag.Name, index)

            Return index
        End Function

        Public Sub Clear() Implements ICollection(Of T).Clear
            tags.Clear()
            nameMap.Clear()
        End Sub

        Default Public ReadOnly Property Item(index As Integer) As T
            Get
                Return tags(index)
            End Get
        End Property

        Default Public ReadOnly Property Item(name As String) As T
            Get
                Return tags(nameMap(name))
            End Get
        End Property

        Public Function Contains(item As T) As Boolean Implements ICollection(Of T).Contains
            Return tags.Contains(item)
        End Function

        Public Sub CopyTo(array() As T, arrayIndex As Integer) Implements ICollection(Of T).CopyTo
            tags.CopyTo(array, arrayIndex)
        End Sub

        Public ReadOnly Property Count As Integer Implements ICollection(Of T).Count
            Get
                Return tags.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of T).IsReadOnly
            Get
                Return False
            End Get
        End Property

        Public Function Remove(item As T) As Boolean Implements ICollection(Of T).Remove
            Return tags.Remove(item)
        End Function

        Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            Return tags.GetEnumerator()
        End Function

        Public Function GetObjectEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return tags.GetEnumerator()
        End Function

        <Obsolete("Please use Item(Integer) instead of GetItemByPtr(Integer)")>
        Public Function GetItemByPtr(ByVal ptr As Integer) As T
            Return tags(ptr)
        End Function

        <Obsolete("Please use Item(String) instead of GetItemByName(String)")>
        Public Function GetItemByName(ByVal name As String) As T
            Return tags(nameMap(name))
        End Function
    End Class
End Namespace
<Serializable()> Public Class Curso
    Private _Codigo As Integer
    Private _Tipo As String
    Private _Nome As String
    Private _CC_Dir As String
    Private _ID_Dep As String

    Property Codigo() As Integer
        Get
            Codigo = _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property
    Property Nome() As String
        Get
            Nome = _Nome
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Nome field can’t be empty")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property
    Property Tipo() As String
        Get
            Tipo = _Tipo
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Tipo field can’t be empty")
                Exit Property
            End If
            _Tipo = value
        End Set
    End Property

    Property CC_Dir() As String
        Get
            CC_Dir = _CC_Dir
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("CC_Dir field can’t be empty")
                Exit Property
            End If
            _CC_Dir = value
        End Set
    End Property

    Property ID_Dep() As String
        Get
            ID_Dep = _ID_Dep
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("ID_Dep field can’t be empty")
                Exit Property
            End If
            _ID_Dep = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _Nome & "   " & _Codigo
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Nome As String, ByVal Codigo As String,
                   ByVal Tipo As String, ByVal CC_Dir As String,
                   ByVal ID_Dep As String)
        MyBase.New()
        Me.Codigo = Codigo
        Me.Nome = Nome
        Me.Tipo = Tipo
        Me.CC_Dir = CC_Dir
        Me.ID_Dep = ID_Dep
    End Sub
End Class

<Serializable()> Public Class Departamento
    Private _ID As String
    Private _Nome As String
    Private _Endereco As String
    Private _Telefone As String
    Private _Horario As String
    Private _Bar As Boolean

    Property ID() As String
        Get
            ID = _ID
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("ID field can’t be empty")
                Exit Property
            End If
            _ID = value
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
    Property Endereco() As String
        Get
            Endereco = _Endereco
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Endereco field can’t be empty")
                Exit Property
            End If
            _Endereco = value
        End Set
    End Property
    Property Telefone() As String
        Get
            Telefone = _Telefone
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Telefone field can’t be empty")
                Exit Property
            End If
            _Telefone = value
        End Set
    End Property

    Property Horario() As String
        Get
            Horario = _Horario
        End Get
        Set(ByVal value As String)
            _Horario = value
        End Set
    End Property

    Property Bar() As Boolean
        Get
            Bar = _Bar
        End Get
        Set(ByVal value As Boolean)
            _Bar = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return "Dep.:        " & _Nome & "   " & _ID
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Nome As String, ByVal ID As String,
                   ByVal Telefone As String)
        MyBase.New()
        Me.ID = ID
        Me.Telefone = Telefone
        Me.Nome = Nome
    End Sub
End Class

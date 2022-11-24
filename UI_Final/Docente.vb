<Serializable()> Public Class Docente
    Private _CC As String
    Private _Nome As String
    Private _NIF As String
    Private _Telefone As String
    Private _ID_Dep As String
    Private _Ref_Proj As String
    Private _Curso As String
    Private _Tipo As String
    Private _Cod_Curso As Integer

    Property CC() As String
        Get
            CC = _CC
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("CC field can’t be empty")
                Exit Property
            End If
            _CC = value
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
    Property NIF() As String
        Get
            NIF = _NIF
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("NIF field can’t be empty")
                Exit Property
            End If
            _NIF = value
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

    Property Ref_Proj() As String
        Get
            Ref_Proj = _Ref_Proj
        End Get
        Set(ByVal value As String)
            _Ref_Proj = value
        End Set
    End Property

    Property Curso() As String
        Get
            Curso = _Curso
        End Get
        Set(ByVal value As String)
            _Curso = value
        End Set
    End Property

    Property Tipo() As String
        Get
            Tipo = _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Property Cod_Curso() As Integer
        Get
            Cod_Curso = _Cod_Curso
        End Get
        Set(ByVal value As Integer)
            _Cod_Curso = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return "Doc.:    " & _Nome & "   " & _CC
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Nome As String, ByVal CC As String,
                   ByVal NIF As String, ByVal Telefone As String,
                   ByVal ID_Dep As String)
        MyBase.New()
        Me.CC = CC
        Me.Telefone = Telefone
        Me.NIF = NIF
        Me.Nome = Nome
        Me.ID_Dep = ID_Dep
    End Sub
End Class

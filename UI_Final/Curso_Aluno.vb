Public Class Curso_Aluno
    Private _Numero As Integer
    Private _Curso As String
    Private _Tipo As String
    Private _DataI As String
    Private _DataE As String
    Private _Cod_Curso As Integer

    Property Numero() As Integer
        Get
            Numero = _Numero
        End Get
        Set(ByVal value As Integer)
            _Numero = value
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

    Property DataI() As String
        Get
            DataI = _DataI
        End Get
        Set(ByVal value As String)
            _DataI = value
        End Set
    End Property

    Property DataE() As String
        Get
            DataE = _DataE
        End Get
        Set(ByVal value As String)
            _DataE = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return "Curso: " & _Cod_Curso
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Numero As Integer)
        MyBase.New()
        Me.Numero = Numero
    End Sub
End Class

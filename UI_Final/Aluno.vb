<Serializable()> Public Class Aluno
    Private _CC As String
    Private _Nome As String
    Private _NIF As String
    Private _Numero As Integer
    Private _Ano As Integer
    Private _N_Matri As Integer
    Private _Ref_Proj As String

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

    Property Numero() As Integer
        Get
            Numero = _Numero
        End Get
        Set(ByVal value As Integer)
            _Numero = value
        End Set
    End Property

    Property N_Matri() As Integer
        Get
            N_Matri = _N_Matri
        End Get
        Set(ByVal value As Integer)
            _N_Matri = value
        End Set
    End Property

    Property Ano() As Integer
        Get
            Ano = _Ano
        End Get
        Set(ByVal value As Integer)
            _Ano = value
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

    Overrides Function ToString() As String
        Return "Aluno:  " & _Nome & "   " & _CC
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Nome As String, ByVal CC As String,
                   ByVal NIF As String, ByVal Numero As String,
                   ByVal N_Matri As String, ByVal Ano As String)
        MyBase.New()
        Me.CC = CC
        Me.Numero = Numero
        Me.N_Matri = N_Matri
        Me.Ano = Ano
        Me.NIF = NIF
        Me.Nome = Nome
    End Sub
End Class

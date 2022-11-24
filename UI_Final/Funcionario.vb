<Serializable()> Public Class Funcionario
    Private _CC As String
    Private _Nome As String
    Private _NIF As String
    Private _Numero As Integer
    Private _Funcao As String
    Private _ID_Trab As String
    Private _Endereco As String
    Private _NomeTrab As String

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

    Property Funcao() As String
        Get
            Funcao = _Funcao
        End Get
        Set(ByVal value As String)
            _Funcao = value
        End Set
    End Property

    Property ID_Trab() As String
        Get
            ID_Trab = _ID_Trab
        End Get
        Set(ByVal value As String)
            _ID_Trab = value
        End Set
    End Property

    Property Endereco() As String
        Get
            Endereco = _Endereco
        End Get
        Set(ByVal value As String)
            _Endereco = value
        End Set
    End Property

    Property NomeTrab() As String
        Get
            NomeTrab = _NomeTrab
        End Get
        Set(ByVal value As String)
            _NomeTrab = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return "Func.:   " & _Nome & "   " & _CC
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Nome As String, ByVal CC As String,
                   ByVal NIF As String, ByVal Numero As String)
        MyBase.New()
        Me.CC = CC
        Me.Numero = Numero
        Me.NIF = NIF
        Me.Nome = Nome
    End Sub
End Class

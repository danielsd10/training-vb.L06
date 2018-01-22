Public MustInherit Class Contacto
    'Campos
    Protected _Id As Integer
    Protected _Nombre As String
    Protected _Direccion As String
    Protected _Telefonos As List(Of String)
    Protected _Correos As List(Of String)

    'Propiedades
    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property
    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property
    Public Property Telefonos As List(Of String)
        Get
            Return _Telefonos
        End Get
        Set(value As List(Of String))
            _Telefonos = value
        End Set
    End Property
    Public Property Correos As List(Of String)
        Get
            Return _Correos
        End Get
        Set(value As List(Of String))
            _Correos = value
        End Set
    End Property

    'Constructor
    Sub New()
    	'Inicializar listas
        Me.Telefonos = New List(Of String)
        Me.Correos = New List(Of String)
    End Sub

    'Métodos

End Class

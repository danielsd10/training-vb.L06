Imports System.Data
Imports System.Data.SqlClient
Imports Entidades

Public Class Contactos

    Private CadenaConexion As String

    Sub New()
        'cadena de conexión a base de datos
        CadenaConexion = "Data Source=localhost;Initial Catalog=TrainingNET;Integrated Security=True"
    End Sub

    Public Function RegistrarPersona(objPersona As Persona) As Boolean
        Dim cnx As New SqlConnection
        Dim cmd As New SqlCommand
        Dim ts As SqlTransaction
        Dim params(5) As SqlParameter

        Try
            'conectar a base de datos
            cnx = New SqlConnection(CadenaConexion)
            cnx.Open()

            'iniciar transacción
            ts = cnx.BeginTransaction()

            'crear comando para ejecutar procedimiento
            cmd = New SqlCommand()
            cmd.Connection = cnx
            cmd.Transaction = ts
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "RegistrarPersona"

            'establecer parámetros
            params(0) = New SqlParameter("Nombre", SqlDbType.VarChar)
            params(0).Value = objPersona.Nombre
            params(1) = New SqlParameter("Apellido", SqlDbType.VarChar)
            params(1).Value = objPersona.Apellido
            params(2) = New SqlParameter("DNI", SqlDbType.VarChar)
            params(2).Value = objPersona.DNI
            params(3) = New SqlParameter("Direccion", SqlDbType.VarChar)
            params(3).Value = objPersona.Direccion
            params(4) = New SqlParameter("FechaNacimiento", SqlDbType.Date)
            params(4).Value = objPersona.FechaNacimiento.ToString("yyyy-MM-dd")
            params(5) = New SqlParameter("Id", SqlDbType.Int)
            params(5).Direction = ParameterDirection.Output
            cmd.Parameters.AddRange(params)

            'ejecutar
            cmd.ExecuteNonQuery()

            If params(5).Value > 0 Then
                objPersona.Id = params(5).Value
                cmd.CommandText = "RegistrarTelefono"
                'redefinir número de parámetros
                ReDim params(2)
                Dim strTelefono As String
                For Each strTelefono In objPersona.Telefonos
                    'establecer parámetros
                    cmd.Parameters.Clear()
                    params(0) = New SqlParameter("IdContacto", SqlDbType.Int)
                    params(0).Value = objPersona.Id
                    params(1) = New SqlParameter("Telefono", SqlDbType.VarChar)
                    params(1).Value = strTelefono
                    params(2) = New SqlParameter("Id", SqlDbType.Int)
                    params(2).Direction = ParameterDirection.Output
                    cmd.Parameters.AddRange(params)

                    'ejecutar
                    cmd.ExecuteNonQuery()

                    If params(2).Value <= 0 Then
                        'si no se obtuvo Id, cancelar transacción
                        ts.Rollback()
                        Return False
                    End If
                Next

                'confirmar transacción
                ts.Commit()
                Return True
            Else
                'si no se obtuvo Id, cancelar transacción
                ts.Rollback()
                Return False
            End If
        Catch ex As SqlException
            Return False
        Catch ex As Exception
            Return False
        Finally
            'liberar recursos
            cmd.Dispose()
            cnx.Dispose()
            cnx.Close()
        End Try
    End Function

    Private Function RegistrarTelefono(ts As SqlTransaction, intIdContacto As Integer, strTelefono As String) As Boolean
        Dim cnx As New SqlConnection
        Dim cmd As New SqlCommand
        Dim params(5) As SqlParameter

        Try
            'conectar a base de datos
            cnx = New SqlConnection(CadenaConexion)
            cnx.Open()

            'crear comando para ejecutar procedimiento
            cmd = New SqlCommand()
            cmd.Connection = cnx
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "RegistrarTelefono"

            'establecer parámetros
            params(0) = New SqlParameter("IdContacto", SqlDbType.Int)
            params(0).Value = intIdContacto
            params(1) = New SqlParameter("DNI", SqlDbType.VarChar)
            params(1).Value = strTelefono
            params(2) = New SqlParameter("Id", SqlDbType.Int)
            params(2).Direction = ParameterDirection.Output
            cmd.Parameters.AddRange(params)

            'ejecutar
            cmd.ExecuteNonQuery()

            'retornar resultado
            Return params(2).Value > 0

        Catch ex As SqlException
            Return False
        Catch ex As Exception
            Return False
        Finally
            'liberar recursos
            cmd.Dispose()
            cnx.Dispose()
            cnx.Close()
        End Try
    End Function

    Public Function ListarPersonas(Optional strBuscar As String = "") As List(Of Persona)
        Dim cnx As New SqlConnection
        Dim cmd As New SqlCommand
        Dim param As SqlParameter

        Dim lstPersonas As New List(Of Persona)
        Dim objPersona As Persona

        Try
            'conectar a base de datos
            cnx = New SqlConnection(CadenaConexion)
            cnx.Open()

            'crear comando para ejecutar procedimiento
            cmd = New SqlCommand()
            cmd.Connection = cnx
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "ListarPersonas"

            'establecer parámetros
            If strBuscar <> "" Then
                param = New SqlParameter("Buscar", SqlDbType.VarChar)
                param.Value = strBuscar
                cmd.Parameters.Add(param)
            End If

            'pasar resultados a lista de objetos
            Using reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read
                    objPersona = New Persona
                    objPersona.Id = reader("id_contacto")
                    objPersona.Nombre = reader("nombre")
                    objPersona.Apellido = reader("apellido")
                    objPersona.DNI = reader("dni")
                    objPersona.Direccion = reader("direccion")
                    objPersona.FechaNacimiento = reader("fecha_nacimiento")
                    ListarTelefonos(objPersona)
                    lstPersonas.Add(objPersona)
                End While
            End Using

        Catch ex As SqlException

        Catch ex As Exception

        Finally
            'liberar recursos
            cmd.Dispose()
            cnx.Dispose()
            cnx.Close()
        End Try
        'retornar resultados
        Return lstPersonas
    End Function

    Private Sub ListarTelefonos(ByRef objPersona As Persona)
        Dim cnx As New SqlConnection
        Dim cmd As New SqlCommand
        Dim param As SqlParameter

        Try
            'conectar a base de datos
            cnx = New SqlConnection(CadenaConexion)
            cnx.Open()

            'crear comando para ejecutar procedimiento
            cmd = New SqlCommand()
            cmd.Connection = cnx
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "ListarTelefonos"

            'establecer parámetros
            param = New SqlParameter("Id", SqlDbType.Int)
            param.Value = objPersona.Id
            cmd.Parameters.Add(param)

            'pasar resultados a lista de objetos
            Using reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read
                    objPersona.Telefonos.Add(reader("telefono"))
                End While
            End Using

        Catch ex As SqlException

        Catch ex As Exception

        Finally
            'liberar recursos
            cmd.Dispose()
        End Try
    End Sub

    Public Function EliminarContacto(Id As Integer) As Boolean
        Dim cnx As New SqlConnection
        Dim cmd As New SqlCommand
        Dim params(0) As SqlParameter

        Try
            'conectar a base de datos
            cnx = New SqlConnection(CadenaConexion)
            cnx.Open()

            'crear comando para ejecutar procedimiento
            cmd = New SqlCommand()
            cmd.Connection = cnx
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "EliminarContacto"

            'establecer parámetros
            params(0) = New SqlParameter("Id", SqlDbType.VarChar)
            params(0).Value = Id
            cmd.Parameters.AddRange(params)

            cmd.ExecuteNonQuery()

            'retornar resultados
            Return True

        Catch ex As SqlException
            Return False
        Catch ex As Exception
            Return False
        Finally
            'liberar recursos
            cmd.Dispose()
            cnx.Dispose()
            cnx.Close()
        End Try
    End Function

End Class

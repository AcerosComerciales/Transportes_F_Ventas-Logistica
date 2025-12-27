Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte
Imports System.Data.SqlClient

Partial Public Class DTRAN_Neumaticos

#Region " Variables "
    Private m_formatofecha As String
    Public ReadOnly Property Tabla() As String
        Get
            Return "TRAN_Neumaticos"
        End Get
    End Property
    Public ReadOnly Property Esquema() As String
        Get
            Return "Transportes"
        End Get
    End Property

#End Region

#Region " Constructores "

    Public Sub New()
        m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
    End Sub

#End Region

#Region " Procedimientos Almacenados "

    Public Function TRAN_NEUMASS_Todos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos)) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRAN_Neumaticos())
                    While reader.Read()
                        Dim e_tran_neumaticos As New ETRAN_Neumaticos()
                        _utilitarios.ACCargarEsquemas(reader, e_tran_neumaticos)
                        e_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                        listETRAN_Neumaticos.Add(e_tran_neumaticos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASS_Todos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRAN_Neumaticos())
                    While reader.Read()
                        Dim e_tran_neumaticos As New ETRAN_Neumaticos()
                        _utilitarios.ACCargarEsquemas(reader, e_tran_neumaticos)
                        e_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                        listETRAN_Neumaticos.Add(e_tran_neumaticos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASS_Todos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRAN_Neumaticos())
                    While reader.Read()
                        Dim e_tran_neumaticos As New ETRAN_Neumaticos()
                        _utilitarios.ACCargarEsquemas(reader, e_tran_neumaticos)
                        e_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                        listETRAN_Neumaticos.Add(e_tran_neumaticos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function TRAN_NEUMASS_Activos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
    '    Try
    '        DAEnterprise.AsignarProcedure(getSelectNeumaActivos(x_join, x_where), CommandType.Text)
    '        Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
    '            If reader.HasRows Then
    '                Dim _utilitarios As New ACEsquemas(New ETRAN_Neumaticos())
    '                While reader.Read()
    '                    Dim e_tran_neumaticos As New ETRAN_Neumaticos()
    '                    _utilitarios.ACCargarEsquemas(reader, e_tran_neumaticos)
    '                    e_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
    '                    listETRAN_Neumaticos.Add(e_tran_neumaticos)
    '                End While
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function



    Public Function TRAM_NEUMASS_Activos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos)) As DataTable
        Dim dataTable As New DataTable()

        DAEnterprise.AsignarProcedure("TRAN_NEUMA_Listado")
        Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            ' Definir las columnas del DataTable basándote en los resultados del DbDataReader
            For i As Integer = 0 To reader.FieldCount - 1
                dataTable.Columns.Add(reader.GetName(i), reader.GetFieldType(i))
            Next
            Dim _utilitarios As New ACEsquemas(New ETRAN_Neumaticos())
            If reader.HasRows Then
                While reader.Read()
                    Dim row As DataRow = dataTable.NewRow()
                    For i As Integer = 0 To reader.FieldCount - 1
                        row(i) = reader(i)
                    Next
                    dataTable.Rows.Add(row)

                    Dim e_tran_neumaticos As New ETRAN_Neumaticos()
                    _utilitarios.ACCargarEsquemas(reader, e_tran_neumaticos)
                    e_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                    listETRAN_Neumaticos.Add(e_tran_neumaticos)
                End While
            End If
        End Using

        Return dataTable
    End Function


    'EL QUE MAS SE ACERCA
    'Public Function TRAM_NEUMASS_Activos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos)) As DataTable
    '    Dim dataTable As New DataTable()

    '    DAEnterprise.AsignarProcedure("TRAN_NEUMA_Listado")
    '    Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
    '        'Using connection As New SqlConnection("Data Source=192.168.30.235\SQL8;Initial Catalog=BDAcerosComer;Integrated Security=True")
    '        '   Dim query As String = "TRAN_NEUMA_Listado" ' Nombre del procedimiento almacenado
    '        Dim _utilitarios As New ACEsquemas(New ETRAN_Neumaticos())
    '        If reader.HasRows Then
    '            While reader.Read()
    '                Dim e_tran_neumaticos As New ETRAN_Neumaticos()
    '                _utilitarios.ACCargarEsquemas(reader, e_tran_neumaticos)
    '                e_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
    '                listETRAN_Neumaticos.Add(e_tran_neumaticos)
    '            End While
    '        End If
    '        'Command.CommandType = CommandType.StoredProcedure
    '        '    Dim adapter As New SqlDataAdapter(command)
    '        '    adapter.Fill(dataTable)

    '    End Using
    '    Return dataTable
    'End Function

    'Public Function TRAM_NEUMASS_Activos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos)) As DataTable
    '    Dim dataTable As New DataTable()

    '    DAEnterprise.AsignarProcedure("TRAN_NEUMA_Listado")
    '    Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
    '        ' Definir las columnas del DataTable basándote en los resultados del DbDataReader
    '        For i As Integer = 0 To reader.FieldCount - 1
    '            dataTable.Columns.Add(reader.GetName(i), reader.GetFieldType(i))
    '        Next

    '        If reader.HasRows Then
    '            While reader.Read()
    '                Dim row As DataRow = dataTable.NewRow()
    '                For i As Integer = 0 To reader.FieldCount - 1
    '                    row(i) = reader(i)
    '                Next
    '                dataTable.Rows.Add(row)
    '            End While
    '        End If
    '    End Using

    '    Return dataTable
    'End Function




    Public Function TRAN_NEUMASS_Todos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRAN_Neumaticos())
                    While reader.Read()
                        Dim e_tran_neumaticos As New ETRAN_Neumaticos()
                        _utilitarios.ACCargarEsquemas(reader, e_tran_neumaticos)
                        e_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                        listETRAN_Neumaticos.Add(e_tran_neumaticos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASS_UnReg(ByRef x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_neuma_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_neuma_id), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tran_neumaticos)
                    x_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASS_UnReg(ByRef x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tran_neumaticos)
                    x_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASS_UnReg(ByRef x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tran_neumaticos)
                    x_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASI_UnReg(ByRef x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_tran_neumaticos, x_usuario), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASI_UnReg(ByRef x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_tran_neumaticos, x_usuario, x_setfecha), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASI_UnReg(ByRef x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_tran_neumaticos, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASU_UnReg(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tran_neumaticos, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASU_UnReg(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tran_neumaticos, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASU_UnReg(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tran_neumaticos, x_where, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASU_UnReg(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tran_neumaticos, x_where, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASU_UnReg(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tran_neumaticos, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASU_UnReg(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tran_neumaticos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASD_UnReg(ByVal x_tran_neumaticos As ETRAN_Neumaticos) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_tran_neumaticos), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_NEUMASD_UnReg(ByVal x_where As Hashtable) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_where), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByVal x_campo As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getSelectId(x_campo), CommandType.Text)
            Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
            Return CType(m_data.Tables(0).Rows(0)("Id"), Integer)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            DAEnterprise.AsignarProcedure(getSelectId(x_campo, x_where), CommandType.Text)
            Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
            Return CType(m_data.Tables(0).Rows(0)("Id"), Integer)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Procedimientos Adicionales "
    Private Function getSelectAll() As String
        Dim sql As String = ""
        Try
            sql = " SELECT * "
            sql &= " FROM Transportes.TRAN_Neumaticos" & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM Transportes.TRAN_Neumaticos" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRAN_Neumaticos)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  " & vbNewLine
            Dim i As Boolean = True
            For Each Item As ACCampos In m_campos
                If i Then
                    sql &= String.Format(" {0} As {1}{2}", Item.CampoOrigen, Item.CampoDestino, vbNewLine)
                    i = False
                Else
                    sql &= String.Format(",{0} As {1}{2}", Item.CampoOrigen, Item.CampoDestino, vbNewLine)
                End If
            Next
            sql &= " FROM Transportes.TRAN_Neumaticos" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRAN_Neumaticos)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRAN_Neumaticos)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRAN_Neumaticos)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function getSelectNeumaActivos(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = "  SELECT * FROM Transportes.TRAN_Neumaticos  AS Neumaticos 
   WHERE Neumaticos.NEUMA_Estado <> 'X'
   order by Neumaticos.NEUMA_FecCrea DESC "
        Try

            Dim _join As New ACGenerador(Of ETRAN_Neumaticos)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectBy(ByVal x_neuma_id As Long) As String
        Dim sql As String = ""
        Try
            sql = " SELECT * " & vbNewLine
            sql &= " FROM Transportes.TRAN_Neumaticos" & vbNewLine
            sql &= " WHERE " & vbNewLine
            sql &= "NEUMA_Id = " + x_neuma_id.ToString() & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrCrea = x_usuario
            x_tran_neumaticos.NEUMA_FecCrea = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            sql = _insert.getInsert(Esquema, Tabla, x_tran_neumaticos, x_tran_neumaticos.Hash, New String() {})


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getInsert(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrCrea = x_usuario
            x_tran_neumaticos.NEUMA_FecCrea = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_neumaticos, x_tran_neumaticos.Hash, New String() {}, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getInsert(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrCrea = x_usuario
            x_tran_neumaticos.NEUMA_FecCrea = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_tran_neumaticos, x_tran_neumaticos.Hash, x_excluir, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrMod = x_usuario
            x_tran_neumaticos.NEUMA_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("NEUMA_Id", New ACWhere(x_tran_neumaticos.NEUMA_Id, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdate(Esquema, Tabla, x_tran_neumaticos, _where, x_tran_neumaticos.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrMod = x_usuario
            x_tran_neumaticos.NEUMA_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("NEUMA_Id", New ACWhere(x_tran_neumaticos.NEUMA_Id, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_neumaticos, _where, x_tran_neumaticos.Hash, New String() {}, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrMod = x_usuario
            x_tran_neumaticos.NEUMA_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            sql = _update.getUpdate(Esquema, Tabla, x_tran_neumaticos, x_where, x_tran_neumaticos.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrMod = x_usuario
            x_tran_neumaticos.NEUMA_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("NEUMA_Id", New ACWhere(x_tran_neumaticos.NEUMA_Id, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_neumaticos, _where, x_tran_neumaticos.Hash, New String() {}, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrMod = x_usuario
            x_tran_neumaticos.NEUMA_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            sql = _update.getUpdateFecha(Esquema, Tabla, x_tran_neumaticos, x_where, x_tran_neumaticos.Hash, x_excluir, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tran_neumaticos As ETRAN_Neumaticos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tran_neumaticos.NEUMA_UsrMod = x_usuario
            x_tran_neumaticos.NEUMA_FecMod = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRAN_Neumaticos)(_fecha, m_formatofecha)
            sql = _update.getUpdate(Esquema, Tabla, x_tran_neumaticos, x_where, x_tran_neumaticos.Hash, x_excluir, x_setfecha, x_setcampos)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDelete(ByVal x_tran_neumaticos As ETRAN_Neumaticos) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM Transportes.TRAN_Neumaticos" & vbNewLine
            sql &= " WHERE "
            sql &= "    NEUMA_Id = " & IIf(x_tran_neumaticos.NEUMA_Id = 0, "Null", x_tran_neumaticos.NEUMA_Id.ToString()) & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getDelete(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM Transportes.TRAN_Neumaticos" & vbNewLine
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of ETRAN_Neumaticos)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getSelectId(ByVal x_campo As String) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_Neumaticos ", x_campo)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getSelectId(ByVal x_campo As String, ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Transportes.TRAN_Neumaticos ", x_campo)
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of ETRAN_Neumaticos)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#End Region

#Region " Metodos "

    Private Function getDate() As String
        Dim x_datos As New DataTable()
        Try
            DAEnterprise.AsignarProcedure("select GetDate()", CommandType.Text)
            x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
            Dim _fecha As DateTime = x_datos.Rows(0)(0)
            Return "'" & _fecha.ToString(m_formatofecha) & "'"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDateTime() As DateTime
        Dim x_datos As New DataTable()
        Try
            DAEnterprise.AsignarProcedure("select GetDate()", CommandType.Text)
            x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
            Dim _fecha As DateTime = x_datos.Rows(0)(0)
            Return _fecha
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class


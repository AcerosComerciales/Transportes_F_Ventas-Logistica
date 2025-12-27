Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEAppMovil


Public Class DTRANGUIAS_Tipos

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "
    Public Function TIPOSSS_TodosTrim(ByRef listETRANGUIAS_Tipos As List(Of ETRANGUIAS_Tipos)) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Tipos())
                    While reader.Read()
                        Dim e_tipos As New ETRANGUIAS_Tipos()
                        _utilitarios.ACCargarEsquemas(reader, e_tipos)
                        e_tipos.Instanciar(ACEInstancia.Consulta)
                        e_tipos.TipoDescripcion = e_tipos.TipoDescripcion.Trim()
                        listETRANGUIAS_Tipos.Add(e_tipos)
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

    Public Function TIPOSS_Todos(ByRef listETRANGUIAS_Tipos As List(Of ETRANGUIAS_Tipos), ByVal x_cadena As String, ByVal x_tipo_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_cadena, x_tipo_codigo), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Tipos())
                    While reader.Read()
                        Dim e_tipos As New ETRANGUIAS_Tipos()
                        _utilitarios.ACCargarEsquemas(reader, e_tipos)
                        e_tipos.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Tipos.Add(e_tipos)
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

    'Procedimiento para sacar tipos por Usuarios para llenar el combobox 

    Public Function Busq_GUIAS_TIPOS_X_Usuario(ByRef x_tipos As List(Of ETRANGUIAS_Tipos), ByVal x_usuario As String) As Integer
        Dim m_filas As Integer
        Try
            Try
                DAEnterprise.AsignarProcedure("Busq_GUIAS_TIPOS_X_Usuario")
                DAEnterprise.AgregarParametro("@EntidCodigo", x_usuario, DbType.String, 11)

                Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                    If reader.HasRows Then
                        While reader.Read()
                            Dim _tipo_datos As New ETRANGUIAS_Tipos()
                            ACEsquemas.ACCargarEsquema(reader, _tipo_datos)
                            _tipo_datos.Instanciar(ACEInstancia.Consulta)
                            x_tipos.Add(_tipo_datos)
                        End While
                        Return True
                    Else
                        Return False
                    End If
                End Using
                Return True
            Catch ex As Exception
                Throw ex
            End Try
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'BusquedaTipoEntidadPorUsuarios 'Procedimiento para sacar el rol si es  DNI O EXTRANJERO O RUC ETC 
    Public Function Busq_GUIAS_TIPOS_Entidad_X_Usuario(ByRef x_tipos As List(Of ETRANGUIAS_Tipos), ByVal x_usuario As String) As Integer
        Dim m_filas As Integer
        Try
            Try
                DAEnterprise.AsignarProcedure("Busq_GUIAS_TIPOS_Entidad_X_Usuario")
                DAEnterprise.AgregarParametro("@EntidCodigo", x_usuario, DbType.String, 11)

                Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                    If reader.HasRows Then
                        While reader.Read()
                            Dim _tipo_datos As New ETRANGUIAS_Tipos()
                            ACEsquemas.ACCargarEsquema(reader, _tipo_datos)
                            _tipo_datos.Instanciar(ACEInstancia.Consulta)
                            x_tipos.Add(_tipo_datos)
                        End While
                        Return True
                    Else
                        Return False
                    End If
                End Using
                Return True
            Catch ex As Exception
                Throw ex
            End Try
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TIPOSI_UnRegSP(ByRef x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String) As Integer
        Dim m_filas As Integer
        Try
            Try
                DAEnterprise.AsignarProcedure("Busq_GUIAS_TIPOS_X_Usuario")
                DAEnterprise.AgregarParametro("@EntidCodigo", x_usuario, DbType.String, 11)

                Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                    If reader.HasRows Then
                        While reader.Read()
                            Dim _tipo_datos As New ETRANGUIAS_Tipos()
                            ACEsquemas.ACCargarEsquema(reader, _tipo_datos)
                            _tipo_datos.Instanciar(ACEInstancia.Consulta)
                            '  x_tipos.Add(_tipo_datos)
                        End While
                        Return True
                    Else
                        Return False
                    End If
                End Using
                Return True
            Catch ex As Exception
                Throw ex
            End Try
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function




#Region "Procedimientos Adicionales "
    Public Function getSelectAll(ByVal x_cadena As String, ByVal x_tipo_codigo As String) As String
        Dim sql As String
        Try
            sql = " SELECT "
            sql &= " TRANGUIAS_Tipos"
            sql &= ",TIPOS_Descripcion"
            sql &= ",TIPOS_DescLarga"
            sql &= ",TIPOS_DescCorta"
            sql &= ",TIPOS_Numero"
            sql &= ",TIPOS_ESTADO"
            sql &= ",TIPOS_PROTEGIDO"
            sql &= " FROM TransportesGuias.TRANGUIAS_Tipos"
            sql &= " WHERE "
            sql &= " TRANGUIAS_Tipos Like '" & x_tipo_codigo & "%'"
            sql &= " AND TIPOS_Descripcion Like '%" & x_cadena & "%'"
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#End Region

#Region " Variables "
    Private m_formatofecha As String
    Public ReadOnly Property Tabla() As String
        Get
            Return "TRANGUIAS_Tipos"
        End Get
    End Property
    Public ReadOnly Property Esquema() As String
        Get
            Return "TransportesGuias"
        End Get
    End Property

#End Region

#Region " Constructores "

    Public Sub New()
        m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
    End Sub

#End Region

#Region " Procedimientos Almacenados "

    Public Function TIPOSSS_Todos(ByRef listETRANGUIAS_Tipos As List(Of ETRANGUIAS_Tipos)) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Tipos())
                    While reader.Read()
                        Dim e_tipos As New ETRANGUIAS_Tipos()
                        _utilitarios.ACCargarEsquemas(reader, e_tipos)
                        e_tipos.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Tipos.Add(e_tipos)
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
    Public Function TIPOSSS_Todos(ByRef listETRANGUIAS_Tipos As List(Of ETRANGUIAS_Tipos), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Tipos())
                    While reader.Read()
                        Dim e_tipos As New ETRANGUIAS_Tipos()
                        _utilitarios.ACCargarEsquemas(reader, e_tipos)
                        e_tipos.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Tipos.Add(e_tipos)
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
    Public Function TIPOSSS_Todos(ByRef listETRANGUIAS_Tipos As List(Of ETRANGUIAS_Tipos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Tipos())
                    While reader.Read()
                        Dim e_tipos As New ETRANGUIAS_Tipos()
                        _utilitarios.ACCargarEsquemas(reader, e_tipos)
                        e_tipos.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Tipos.Add(e_tipos)
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
    Public Function TIPOSSS_Todos(ByRef listETRANGUIAS_Tipos As List(Of ETRANGUIAS_Tipos), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Tipos())
                    While reader.Read()
                        Dim e_tipos As New ETRANGUIAS_Tipos()
                        _utilitarios.ACCargarEsquemas(reader, e_tipos)
                        e_tipos.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Tipos.Add(e_tipos)
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
    Public Function TIPOSSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSS_UnReg(ByRef x_tipos As ETRANGUIAS_Tipos, ByVal x_TRANGUIAS_Tipos As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_TRANGUIAS_Tipos), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tipos)
                    x_tipos.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSS_UnReg(ByRef x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tipos)
                    x_tipos.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSS_UnReg(ByRef x_tipos As ETRANGUIAS_Tipos, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_tipos)
                    x_tipos.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSI_UnReg(ByRef x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_tipos, x_usuario), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSI_UnReg(ByRef x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_tipos, x_usuario, x_setfecha), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSI_UnReg(ByRef x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_tipos, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSU_UnReg(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tipos, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSU_UnReg(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tipos, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSU_UnReg(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tipos, x_where, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSU_UnReg(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tipos, x_where, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSU_UnReg(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tipos, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSU_UnReg(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_tipos, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSD_UnReg(ByVal x_tipos As ETRANGUIAS_Tipos) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_tipos), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TIPOSSD_UnReg(ByVal x_where As Hashtable) As Integer
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
            sql &= " FROM TransportesGuias.TRANGUIAS_Tipos" & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM TransportesGuias.TRANGUIAS_Tipos" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRANGUIAS_Tipos)(m_formatofecha)
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
            sql &= " FROM TransportesGuias.TRANGUIAS_Tipos" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRANGUIAS_Tipos)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRANGUIAS_Tipos)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRANGUIAS_Tipos)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectBy(ByVal x_TRANGUIAS_Tipos As String) As String
        Dim sql As String = ""
        Try
            sql = " SELECT * " & vbNewLine
            sql &= " FROM TransportesGuias.TRANGUIAS_Tipos" & vbNewLine
            sql &= " WHERE " & vbNewLine
            sql &= "TRANGUIAS_Tipos = " + IIf(IsNothing(x_TRANGUIAS_Tipos), "Null", "'" & x_TRANGUIAS_Tipos & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha
            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            sql = _insert.getInsert(Esquema, Tabla, x_tipos, x_tipos.Hash, New String() {})


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getInsert(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha
            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_tipos, x_tipos.Hash, New String() {}, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getInsert(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha
            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_tipos, x_tipos.Hash, x_excluir, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("TipoId", New ACWhere(x_tipos.TipoId, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdate(Esquema, Tabla, x_tipos, _where, x_tipos.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("TipoId", New ACWhere(x_tipos.TipoId, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdateFecha(Esquema, Tabla, x_tipos, _where, x_tipos.Hash, New String() {}, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            sql = _update.getUpdate(Esquema, Tabla, x_tipos, x_where, x_tipos.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("TipoId", New ACWhere(x_tipos.TipoId, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdateFecha(Esquema, Tabla, x_tipos, _where, x_tipos.Hash, New String() {}, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            sql = _update.getUpdateFecha(Esquema, Tabla, x_tipos, x_where, x_tipos.Hash, x_excluir, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_tipos As ETRANGUIAS_Tipos, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_tipos.TipoUsrModificacion = x_usuario
            x_tipos.TipoFecModificacion = _fecha
            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Tipos)(_fecha, m_formatofecha)
            sql = _update.getUpdate(Esquema, Tabla, x_tipos, x_where, x_tipos.Hash, x_excluir, x_setfecha, x_setcampos)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDelete(ByVal x_tipos As ETRANGUIAS_Tipos) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Tipos" & vbNewLine
            sql &= " WHERE "
            sql &= "    TipoId = " & IIf(IsNothing(x_tipos.TipoId), "Null", "'" & x_tipos.TipoDescripcion & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getDelete(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Tipos" & vbNewLine
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of ETRANGUIAS_Tipos)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getSelectId(ByVal x_campo As String) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As Id From TransportesGuias.TRANGUIAS_Tipos ", x_campo)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getSelectId(ByVal x_campo As String, ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As Id From TransportesGuias.TRANGUIAS_Tipos ", x_campo)
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of ETRANGUIAS_Tipos)(m_formatofecha)
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
            DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
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
            DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
            x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
            Dim _fecha As DateTime = x_datos.Rows(0)(0)
            Return _fecha
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEAppMovil
Public Class DTRANGUIAS_Usuarios


    Enum TipoBusqueda

        NumDocumento = 1
        RazonSocial = 2


    End Enum

#Region " Variables "
    Private m_formatofecha As String
    Public ReadOnly Property Tabla() As String
        Get
            Return "TRANGUIAS_Usuarios"
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

    Public Function USUARSS_Todos(ByRef x_listTRANGUIAS_Usuarios As List(Of ETRANGUIAS_Usuarios)) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Usuarios())
                    While reader.Read()
                        Dim x_ETRANGUIAS_Usuarios As New ETRANGUIAS_Usuarios()
                        _utilitarios.ACCargarEsquemas(reader, x_ETRANGUIAS_Usuarios)
                        x_ETRANGUIAS_Usuarios.Instanciar(ACEInstancia.Consulta)
                        x_listTRANGUIAS_Usuarios.Add(x_ETRANGUIAS_Usuarios)
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

    '=======================================TRAN_GUIAS_BusqUsuarioXNumDocumento==================================================
    Public Function TRAN_GUIAS_TRANSPORTISTA_BusqUsuarioXNumDocumento(ByRef X_ENTID_CodigoFk As String, ByRef x_razon_social As String, ByRef x_listTRANGUIAS_Usuarios As List(Of ETRANGUIAS_Usuarios), ByRef TipoUsuario As TipoBusqueda) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_GUIAS_TRANSPORTISTA_BusqUsuarioXNumDocumento")
            DAEnterprise.AgregarParametro("@ENTID_CodigoFk", X_ENTID_CodigoFk, DbType.String, 11)
            DAEnterprise.AgregarParametro("@Razon_Social", x_razon_social, DbType.String)
            DAEnterprise.AgregarParametro("@TipoBusqueda", TipoUsuario, DbType.Int16, 1)

            'DAEnterprise.AgregarParametro("@ViewAll", ViewAll, DbType.Boolean, 1)
            'ViewAll

            'DAEnterprise.AgregarParametro("@VEHIC_Id", x_cadena, DbType.Int16, 10)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _TRAN_GUIAS_Usuarios As New ETRANGUIAS_Usuarios()
                        ACEsquemas.ACCargarEsquema(reader, _TRAN_GUIAS_Usuarios)
                        _TRAN_GUIAS_Usuarios.Instanciar(ACEInstancia.Consulta)
                        x_listTRANGUIAS_Usuarios.Add(_TRAN_GUIAS_Usuarios)
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



    End Function

    'Busqueda por botonen solo devuelve todo los documentos activos o inactivos 
    Public Function TRAN_GUIAS_TRANSPORTISTA_BusqUsuariosActivosInactivos(ByRef x_listTRANGUIAS_Usuarios As List(Of ETRANGUIAS_Usuarios), ByRef ViewAll As Boolean) As Boolean

        Try
            DAEnterprise.AsignarProcedure("TRAN_GUIAS_TRANSPORTISTA_BusqUsuariosActivosInactivos")
            DAEnterprise.AgregarParametro("@ViewAll", ViewAll, DbType.Boolean, 1)
            'ViewAll
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _TRAN_GUIAS_Usuarios As New ETRANGUIAS_Usuarios()
                        ACEsquemas.ACCargarEsquema(reader, _TRAN_GUIAS_Usuarios)
                        _TRAN_GUIAS_Usuarios.Instanciar(ACEInstancia.Consulta)
                        x_listTRANGUIAS_Usuarios.Add(_TRAN_GUIAS_Usuarios)
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

    End Function



    Public Function USUARSS_Todos(ByRef x_listTRANGUIAS_Usuarios As List(Of ETRANGUIAS_Usuarios), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Usuarios())
                    While reader.Read()
                        Dim x_ETRANGUIAS_Usuarios As New ETRANGUIAS_Usuarios()
                        _utilitarios.ACCargarEsquemas(reader, x_ETRANGUIAS_Usuarios)
                        x_ETRANGUIAS_Usuarios.Instanciar(ACEInstancia.Consulta)
                        x_listTRANGUIAS_Usuarios.Add(x_ETRANGUIAS_Usuarios)
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



    'Usuario CON Join 


    Public Function USUARSS_JoinUnReg(ByRef x_listTRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectUnReg(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_listTRANGUIAS_Usuarios)
                    x_listTRANGUIAS_Usuarios.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function USUARSS_Todos(ByRef x_listTRANGUIAS_Usuarios As List(Of ETRANGUIAS_Usuarios), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Usuarios())
                    While reader.Read()
                        Dim x_ETRANGUIAS_Usuarios As New ETRANGUIAS_Usuarios()
                        _utilitarios.ACCargarEsquemas(reader, x_ETRANGUIAS_Usuarios)
                        x_ETRANGUIAS_Usuarios.Instanciar(ACEInstancia.Consulta)
                        x_listTRANGUIAS_Usuarios.Add(x_ETRANGUIAS_Usuarios)
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

    Public Function USUARSS_Todos(ByRef x_listTRANGUIAS_Usuarios As List(Of ETRANGUIAS_Usuarios), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Usuarios())
                    While reader.Read()
                        Dim x_ETRANGUIAS_Usuarios As New ETRANGUIAS_Usuarios()
                        _utilitarios.ACCargarEsquemas(reader, x_ETRANGUIAS_Usuarios)
                        x_ETRANGUIAS_Usuarios.Instanciar(ACEInstancia.Consulta)
                        x_listTRANGUIAS_Usuarios.Add(x_ETRANGUIAS_Usuarios)
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

    Public Function USUARSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function USUARSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function USUARSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function USUARSI_UnReg(ByRef x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_TRANGUIAS_Usuarios, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'proceso de actualizacion 
    Public Function USUARUP_UnReg(ByRef x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_TRANGUIAS_Usuarios, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function USUARSI_UnReg(ByRef x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_TRANGUIAS_Usuarios, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function USUARSI_UnReg(ByRef x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_TRANGUIAS_Usuarios, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function USUARSD_UnReg(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_TRANGUIAS_Usuarios), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function USUARSD_UnReg(ByVal x_where As Hashtable) As Integer
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
            Return CType(m_data.Tables(0).Rows(0)("GtusId"), Integer)
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
            sql &= " FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)
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
            sql &= " FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'GETSELECT UN REGISTRO BY FRANK 

    Private Function getSelectUnReg(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectBy(ByVal x_almac_id As Short, ByVal x_entid_codigo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short) As String
        Dim sql As String = ""
        Try

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TRAN_GUIAS_UnReg(ByRef x_TRAN_GUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal _where_ As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(_where_), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_TRAN_GUIAS_Usuarios)
                    x_TRAN_GUIAS_Usuarios.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getSelectBy(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function getUpdate(ByVal x_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_Usuarios.GtusUsrCreacion = x_usuario
            x_Usuarios.GtusFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Usuarios)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("ENTID_CodigoFk", New ACWhere(x_Usuarios.ENTID_CodigoFk, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdate(Esquema, Tabla, x_Usuarios, _where, x_Usuarios.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_TRANGUIAS_Usuarios.GtusUsrCreacion = x_usuario
            x_TRANGUIAS_Usuarios.GtusFecCreacion = _fecha

            Dim _insert As New ACGenerador(Of ETRANGUIAS_Usuarios)(_fecha, m_formatofecha)
            sql = _insert.getInsert(Esquema, Tabla, x_TRANGUIAS_Usuarios, x_TRANGUIAS_Usuarios.Hash, New String() {})


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_TRANGUIAS_Usuarios.GtusUsrCreacion = x_usuario
            x_TRANGUIAS_Usuarios.GtusFecCreacion = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Usuarios)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_TRANGUIAS_Usuarios, x_TRANGUIAS_Usuarios.Hash, New String() {}, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getInsert(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_TRANGUIAS_Usuarios.GtusUsrCreacion = x_usuario
            x_TRANGUIAS_Usuarios.GtusFecCreacion = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Usuarios)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_TRANGUIAS_Usuarios, x_TRANGUIAS_Usuarios.Hash, x_excluir, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Private Function getUpdate(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String) As String
    '    Dim sql As String = ""
    '    Try

    '        Return sql
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Private Function getUpdate(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
    '    Dim sql As String = ""
    '    Try

    '        Return sql
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Private Function getUpdate(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_where As Hashtable, ByVal x_usuario As String) As String
    '    Dim sql As String = ""
    '    Try

    '        Return sql
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Private Function getUpdate(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
    '    Dim sql As String = ""
    '    Try

    '        Return sql
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Private Function getUpdate(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
    '    Dim sql As String = ""
    '    Try

    '        Return sql
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Private Function getUpdate(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
    '    Dim sql As String = ""
    '    Try

    '        Return sql
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Function getDelete(ByVal x_TRANGUIAS_Usuarios As ETRANGUIAS_Usuarios) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine
            sql &= " WHERE "
            sql &= "    GtusId = " & IIf(x_TRANGUIAS_Usuarios.GtusId = 0, "Null", x_TRANGUIAS_Usuarios.GtusId.ToString()) & vbNewLine
            sql &= "And ENTID_CodigoFk = " & IIf(IsNothing(x_TRANGUIAS_Usuarios.ENTID_CodigoFk), "Null", "'" & x_TRANGUIAS_Usuarios.ENTID_CodigoFk & "'") & vbNewLine
            sql &= "And GtusUsuario = " & IIf(IsNothing(x_TRANGUIAS_Usuarios.GtusUsuario), "Null", "'" & x_TRANGUIAS_Usuarios.GtusUsuario & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDelete(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectId(ByVal x_campo As String) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As GtusId From TransportesGuias.TRANGUIAS_Usuarios ", x_campo)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectId(ByVal x_campo As String, ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As GtusId From TransportesGuias.TRANGUIAS_Usuarios ", x_campo)
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)
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

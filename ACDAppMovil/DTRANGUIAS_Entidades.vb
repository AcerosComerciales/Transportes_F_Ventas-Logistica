Imports System
Imports System.Data.Common
Imports ACDTransporte
Imports ACEAppMovil
Imports ACFramework
Imports DAConexion

Public Class DTRANGUIAS_Entidades


#Region " Variables "
    Private m_formatofecha As String
    Public ReadOnly Property Tabla() As String
        Get
            Return "TRANGUIAS_Entidades"
        End Get
    End Property
    Public ReadOnly Property Esquema() As String
        Get
            Return "TransportesGuias"
        End Get
    End Property
    Enum TipoProceso
        SQL
        SQL_ID
    End Enum


#End Region
#Region " Constructores "

    Public Sub New()
        m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
    End Sub


    Public Function ENTISS_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_entid_dni As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectByUsuario(x_entid_dni), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTISI_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String, ByVal x_tipo As ETRANGUIAS_Entidades.TipoInicializacion) As Integer
        Dim m_filas As Integer
        Try
            Select Case x_tipo
                Case ETRANGUIAS_Entidades.TipoInicializacion.EntTipos_Dir_Tel
                    DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario, x_tipo), CommandType.Text)
                    Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
                    x_entidades.EntiId = CType(m_datos.Rows(0)(0), Long)
                Case Else
                    DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario), CommandType.Text)
                    m_filas = DAEnterprise.ExecuteNonQuery()
            End Select
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTISS_TodosAyuda(ByRef dtETRANGUIAS_Entidades As DataTable, ByVal x_where As Hashtable, ByVal x_tipoentidad As ETRANGUIAS_Entidades.TipoEntidad) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAyuda(x_where, x_tipoentidad), CommandType.Text)
            dtETRANGUIAS_Entidades = DAEnterprise.ExecuteDataSet().Tables(0)
            Return dtETRANGUIAS_Entidades.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTISS_TodosAyudaConductor(ByRef dtETRANGUIAS_Entidades As DataTable, ByVal x_entid_codigo As String, ByVal x_cadena As String, ByVal x_campo As String, ByVal x_tipoentidad As ETRANGUIAS_Entidades.TipoEntidad) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAyuda(x_entid_codigo, x_cadena, x_campo, x_tipoentidad), CommandType.Text)
            dtETRANGUIAS_Entidades = DAEnterprise.ExecuteDataSet().Tables(0)
            Return dtETRANGUIAS_Entidades.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTISS_TodosAyudaConductor(ByRef dtETRANGUIAS_Entidades As DataTable, ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_tipoentidad As ETRANGUIAS_Entidades.TipoEntidad) As Boolean
        Try
            DAEnterprise.AsignarProcedure("ENTISS_TodosAyudaConductor")
            DAEnterprise.AgregarParametro("@ROLES_Id", x_tipoentidad, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            dtETRANGUIAS_Entidades = DAEnterprise.ExecuteDataSet().Tables(0)
            Return dtETRANGUIAS_Entidades.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTISS_TodosAyudaUsuario(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAyudaUsuario(x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTISS_CargarDocIden(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_entid_nrodocumento As String) As Boolean
        Dim sql As String = ""
        Try
            App.Inicializar()
            sql = String.Format(App.Hash("DEntidades.CargarDocDevo"), x_entid_nrodocumento)
            DAEnterprise.AsignarProcedure(sql, CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function ENTISS_CargarDirecciones(ByRef listEDirecciones As List(Of EDirecciones), ByVal x_entid_codigo As String) As Boolean
    '    Dim sql As String = ""
    '    Try
    '        App.Inicializar()
    '        sql = String.Format(App.Hash("DEntidades.ENTISS_CargarDirecciones"), x_entid_codigo)
    '        DAEnterprise.AsignarProcedure(sql, CommandType.Text)
    '        Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
    '            If reader.HasRows Then
    '                Dim _utilitarios As New ACEsquemas(New EDirecciones())
    '                While reader.Read()
    '                    Dim e_direcciones As New EDirecciones()
    '                    _utilitarios.ACCargarEsquemas(reader, e_direcciones)
    '                    e_direcciones.Instanciar(ACEInstancia.Consulta)
    '                    listEDirecciones.Add(e_direcciones)
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

    ''' <summary> 
    ''' Capa de Datos: ENTISS_ObtenerDireccion
    ''' </summary>
    ''' <param name="x_entid_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ENTISS_ObtenerDireccion(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_entid_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("ENTISS_ObtenerDireccion")
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
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
    Public Function ENTISS_CargarCotizadores(ByRef dtETRANGUIAS_Entidades As DataTable, ByVal x_periodo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectCotizadores(x_periodo), CommandType.Text)
            dtETRANGUIAS_Entidades = DAEnterprise.ExecuteDataSet().Tables(0)
            Return dtETRANGUIAS_Entidades.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary> 
    ''' Capa de Datos: ENTISS_BuscarClientes
    ''' </summary>
    ''' <param name="x_cadena">Parametro 1: </param> 
    ''' <param name="x_opcion">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ENTISS_BuscarClientes(ByVal m_listentidades As List(Of ETRANGUIAS_Entidades), ByVal x_cadena As String, ByVal x_opcion As Short) As Boolean
        Try
            DAEnterprise.AsignarProcedure("ENTISS_BuscarClientes")
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 200)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _entidades As New ETRANGUIAS_Entidades()
                        ACEsquemas.ACCargarEsquema(reader, _entidades)
                        _entidades.Instanciar(ACEInstancia.Consulta)
                        m_listentidades.Add(_entidades)
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

#Region "Procedimientos Adicionales "
    Public Function getSelectByUsuario(ByVal x_entid_dni As String) As String
        Dim sql As String
        Try
            sql = " SELECT "
            sql &= " * "
            sql &= " FROM Entidades"
            sql &= " WHERE "
            sql &= String.Format("USUAR_CODIGO = '{0}'", x_entid_dni)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getSelectCotizadores(ByVal x_periodo As String) As String
        Dim sql As String
        Try
            sql = " SELECT Distinct  V.ENTID_CodigoCotizador"
            sql &= " ,E.ENTID_Nombres"
            sql &= " FROM Ventas.VENT_DocsVenta as V"
            sql &= String.Format(" Inner Join TransportesGuias.TRANGUIAS_Entidades As E On E.ENTID_Codigo = V.ENTID_CodigoCotizador")
            sql &= " WHERE "
            sql &= String.Format("YEAR(DOCVE_FechaDocumento)='{0}'", x_periodo)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getInsert(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String, ByVal x_tipo As TipoProceso) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            sql = _insert.getInsert(Esquema, Tabla, x_entidades, x_entidades.Hash, New String() {"ENTID_Id"})
            sql &= " SELECT @@IDENTITY AS 'Identity'; "
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getSelectAyuda(ByVal x_where As Hashtable, ByVal x_tipoentidad As ETRANGUIAS_Entidades.TipoEntidad) As String
        Dim sql As String = ""
        Try
            'sql = String.Format(" SELECT Distinct m_Ent.ENTID_Codigo As Codigo, m_Ent.ENTID_RazonSocial As [Razon Social], m_Ent.ENTID_Nombres As Nombre, m_Ent.ENTID_NroDocumento As [Doc./R.U.C.] {0}", vbNewLine)
            'sql &= String.Format(" ,ENTID_Direccion As Dirección, m_Ent.ENTID_Id As Interno{0}, UBIGO_Codigo As Ubigeo", vbNewLine)
            'sql &= String.Format(" FROM Entidades as m_Ent{0}", vbNewLine)
            App.Inicializar()
            sql = App.Hash("DEntidades.getSelectAyuda")
            If Not x_tipoentidad = ETRANGUIAS_Entidades.TipoEntidad.Todos Then
                sql &= String.Format(" Inner Join EntidadesRoles As ERol On ERol.ENTID_Codigo = m_Ent.ENTID_Codigo And ERol.ROLES_Id = {0}{1}", x_tipoentidad.GetHashCode, vbNewLine)
                sql &= String.Format(" Inner Join Roles As Rol On Rol.ROLES_Id = ERol.ROLES_Id{0}", vbNewLine)
            End If
            sql &= String.Format(" WHERE {0}", vbNewLine)
            Dim _where As New ACGenerador(Of ETRANGUIAS_Entidades)(m_formatofecha)
            sql &= _where.getWhere(x_where, "Ent", True)
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getSelectAyuda(ByVal x_entid_codigo As String, ByVal x_cadena As String, ByVal x_campo As String, ByVal x_tipoentidad As ETRANGUIAS_Entidades.TipoEntidad) As String
        Dim sql As String = ""
        Try
            App.Inicializar()
            sql &= String.Format(App.Hash("DEntidades.ENTISS_TodosAyudaConductor").ToString(), CType(x_tipoentidad, Integer).ToString(), x_entid_codigo, x_campo, x_cadena)
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAyudaUsuario(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql &= " SELECT  ENTID_Codigo As Código " & vbNewLine
            sql &= " ,ENTID_Nombres As Nombres" & vbNewLine
            sql &= " ,ENTID_NroDocumento As Documento" & vbNewLine
            sql &= " ,ENTID_EMail As EMail" & vbNewLine
            sql &= " ,ENTID_Direccion As Dirección" & vbNewLine
            sql &= " ,ENTID_Id As Interno" & vbNewLine
            sql &= " FROM Entidades" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRANGUIAS_Usuarios)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#End Region

    Public Function ENTIDSS_Todos(ByRef listETRANGUIAS_Entidades As List(Of ETRANGUIAS_Entidades)) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Entidades())
                    While reader.Read()
                        Dim e_entidades As New ETRANGUIAS_Entidades()
                        _utilitarios.ACCargarEsquemas(reader, e_entidades)
                        e_entidades.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Entidades.Add(e_entidades)
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
    Public Function ENTIDSS_Todos(ByRef listETRANGUIAS_Entidades As List(Of ETRANGUIAS_Entidades), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Entidades())
                    While reader.Read()
                        Dim e_entidades As New ETRANGUIAS_Entidades()
                        _utilitarios.ACCargarEsquemas(reader, e_entidades)
                        e_entidades.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Entidades.Add(e_entidades)
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
    Public Function ENTIDSS_Todos(ByRef listETRANGUIAS_Entidades As List(Of ETRANGUIAS_Entidades), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Entidades())
                    While reader.Read()
                        Dim e_entidades As New ETRANGUIAS_Entidades()
                        _utilitarios.ACCargarEsquemas(reader, e_entidades)
                        e_entidades.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Entidades.Add(e_entidades)
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
    Public Function ENTIDSS_Todos(ByRef listETRANGUIAS_Entidades As List(Of ETRANGUIAS_Entidades), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRANGUIAS_Entidades())
                    While reader.Read()
                        Dim e_entidades As New ETRANGUIAS_Entidades()
                        _utilitarios.ACCargarEsquemas(reader, e_entidades)
                        e_entidades.Instanciar(ACEInstancia.Consulta)
                        listETRANGUIAS_Entidades.Add(e_entidades)
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
    Public Function ENTIDSS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            m_datos = DAEnterprise.ExecuteDataSet()
            Return m_datos.Tables.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function ENTIDSS_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_entid_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_entid_codigo), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Tipo usuario apara buscar  Entidades Usuarios 

    Public Function ENTIDSS_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_entid_codigo As String, ByVal usuario As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_entid_codigo), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'ENTIDSS_UrReg  busqueda 

    Public Function Usuarios_UnReg(ByRef x_entidades As ETRANGUIAS_Usuarios, ByVal x_entid_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectBy(x_entid_codigo, True), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function ENTIDSS_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSS_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Comprobacion de usuarios para registros con enetidades 

    Public Function ENTIDSS_UnReg(ByRef x_entidades As ETRANGUIAS_Usuarios, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_entidades)
                    x_entidades.Instanciar(ACEInstancia.Consulta)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function ENTIDSI_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSI_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario, x_setfecha), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSI_UnReg(ByRef x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Dim m_filas As Integer
        Try
            DAEnterprise.AsignarProcedure(getInsert(x_entidades, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            m_filas = DAEnterprise.ExecuteNonQuery()
            Return m_filas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSU_UnReg(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSU_UnReg(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSU_UnReg(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_where, x_usuario), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSU_UnReg(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_where, x_usuario, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSU_UnReg(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSU_UnReg(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getUpdate(x_entidades, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ENTIDSD_UnReg(ByVal x_entidades As ETRANGUIAS_Entidades) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_entidades), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTIDSD_UnReg(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_entidades), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTIDSD_UnReg(ByVal x_entidades As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDelete(x_entidades), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTID_EXISTS_UnReg(Byval x_dni As String ) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getExistsConductor(x_dni), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex 
        End Try
    End Function



    'Eliminacion de Usuario aqui 

    'Public Function UsuarioDSD_UnReg(ByVal x_entidades As ETRANGUIAS_Usuarios) As Integer
    '    Try
    '        DAEnterprise.AsignarProcedure(getDelete(x_entidades), CommandType.Text)
    '        Return DAEnterprise.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


    Public Function UsuarioDSD_UnReg(ByVal x_entidades As String) As Integer
        Try
            DAEnterprise.AsignarProcedure(getDeleteUser(x_entidades), CommandType.Text)
            Return DAEnterprise.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ENTIDSD_UnReg(ByVal x_where As Hashtable) As Integer
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

    Private Function getSelectAll() As String
        Dim sql As String = ""
        Try
            sql = " SELECT * "
            sql &= " FROM TransportesGuias.TRANGUIAS_Entidades" & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM TransportesGuias.TRANGUIAS_Entidades" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRANGUIAS_Entidades)(m_formatofecha)
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
            sql &= " FROM TransportesGuias.TRANGUIAS_Entidades" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of ETRANGUIAS_Entidades)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            Dim _join As New ACGenerador(Of ETRANGUIAS_Entidades)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'getselect solo para usuariso 


    Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_tipousuario As String) As String
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

            Dim _join As New ACGenerador(Of ETRANGUIAS_Entidades)(m_formatofecha)

            sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectBy(ByVal x_entid_codigo As String) As String
        Dim sql As String = ""
        Try
            sql = " SELECT * " & vbNewLine
            sql &= " FROM TransportesGuias.TRANGUIAS_Entidades" & vbNewLine
            sql &= " WHERE " & vbNewLine
            sql &= "EntiDocumento = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Funciones ==> 
    Private Function getSelectBy(ByVal x_entid_codigo As String, ByVal x_valor As Boolean) As String
        Dim sql As String = ""
        Try
            sql = " SELECT * " & vbNewLine
            sql &= " FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine
            sql &= " WHERE " & vbNewLine
            sql &= "ENTID_CodigoFk = " + IIf(IsNothing(x_entid_codigo), "Null", "'" & x_entid_codigo & "'") & vbNewLine
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Private Function getInsert(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecCreacion = _fecha


            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            sql = _insert.getInsert(Esquema, Tabla, x_entidades, x_entidades.Hash, New String() {})


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getInsert(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_entidades, x_entidades.Hash, New String() {}, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getInsert(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha

            Dim _insert As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            sql = _insert.getInsertFecha(Esquema, Tabla, x_entidades, x_entidades.Hash, x_excluir, x_setfecha)


            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getUpdate(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha
            x_entidades.EntiId = Nothing

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("EntiDocumento", New ACWhere(x_entidades.EntiDocumento, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdate(Esquema, Tabla, x_entidades, _where, x_entidades.Hash, New String() {})
            Debug.WriteLine(sql)
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha
            x_entidades.EntiId = Nothing
            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("EntiDocumento", New ACWhere(x_entidades.EntiDocumento, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdateFecha(Esquema, Tabla, x_entidades, _where, x_entidades.Hash, New String() {}, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable, ByVal x_usuario As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha
            x_entidades.EntiId = Nothing
            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            sql = _update.getUpdate(Esquema, Tabla, x_entidades, x_where, x_entidades.Hash, New String() {})

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            Dim _where As New Hashtable()
            _where.Add("EntiDocumento", New ACWhere(x_entidades.EntiDocumento, ACWhere.TipoWhere.Igual))
            sql = _update.getUpdateFecha(Esquema, Tabla, x_entidades, _where, x_entidades.Hash, New String() {}, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            sql = _update.getUpdateFecha(Esquema, Tabla, x_entidades, x_where, x_entidades.Hash, x_excluir, x_setfecha)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getUpdate(ByVal x_entidades As ETRANGUIAS_Entidades, ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
        Dim sql As String = ""
        Try
            Dim _fecha As DateTime = getDateTime()
            x_entidades.EntiUsrCreacion = x_usuario
            x_entidades.EntiFecModificacion = _fecha

            Dim _update As New ACFramework.ACGenerador(Of ETRANGUIAS_Entidades)(_fecha, m_formatofecha)
            sql = _update.getUpdate(Esquema, Tabla, x_entidades, x_where, x_entidades.Hash, x_excluir, x_setfecha, x_setcampos)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDelete(ByVal x_Documento As ETRANGUIAS_Entidades) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Entidades" & vbNewLine
            sql &= " WHERE "
            sql &= "    EntiDocumento = " & IIf(IsNothing(x_Documento.EntiDocumento), "Null", "'" & x_Documento.EntiDocumento & "'") & vbNewLine
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Eliminar Entidada
    Private Function getDelete(ByVal x_Documento As String) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Entidades" & vbNewLine
            sql &= " WHERE "
            sql &= "    EntiDocumento = " & IIf(IsNothing(x_Documento), "Null", "'" & x_Documento & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function getDelete(ByVal x_Documento As ETRANGUIAS_Usuarios, ByVal PERMISO As Boolean) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine
            sql &= " WHERE "
            sql &= "    ENTID_CodigoFk = " & IIf(IsNothing(x_Documento.ENTID_CodigoFk), "Null", "'" & x_Documento.ENTID_CodigoFk & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'dELTE USUARIOS 

    Private Function getDeleteUser(ByVal x_Documento As String) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Usuarios" & vbNewLine
            sql &= " WHERE "
            sql &= "    ENTID_CodigoFk = " & IIf(IsNothing(x_Documento), "Null", "'" & x_Documento & "'") & vbNewLine

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDelete(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = " DELETE FROM TransportesGuias.TRANGUIAS_Entidades" & vbNewLine
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of ETRANGUIAS_Entidades)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getSelectId(ByVal x_campo As String) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As Id From TransportesGuias.TRANGUIAS_Entidades ", x_campo)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function getSelectId(ByVal x_campo As String, ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try

            sql = String.Format(" SELECT IsNull(Max({0}), 0) As Id From TransportesGuias.TRANGUIAS_Entidades ", x_campo)
            sql &= " WHERE "
            Dim _where As New ACGenerador(Of ETRANGUIAS_Entidades)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private function getExistsConductor(Byval x_dni As String) As String 

        Dim sql As String = "" 
        Try
            sql = String.Format(" SELECT  ENTID_Codigo  From dbo.Conductores", x_dni)
            sql &= " WHERE Entid_Codigo   = " + x_dni  
         
            Return sql
        Catch ex As Exception
            Throw ex 
        End Try
    End function


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



End Class
Imports System
Imports System.Data
Imports System.Collections.Generic


Imports System.Configuration
Imports ACFramework
Imports DAConexion
Imports ACEVentas
Imports ACEAppMovil
Imports ACDAppMovil

Public Class BTRANGUIAS_Entidades


#Region " Variables "

    Private m_ETRANGUIAS_Entidades As ETRANGUIAS_Entidades
    Private m_listVENT_Pedidos As List(Of ETRANGUIAS_Entidades)
    Private m_dtVENT_Pedidos As DataTable

    Private m_dsVENT_Pedidos As DataSet
    Private d_vent_pedidos As DTRANGUIAS_Entidades



    'Otras variables = 

    Private m_entidades As ETRANGUIAS_Entidades
    Private m_usuarios As ETRANGUIAS_Usuarios
    Private m_listEntidades As List(Of ETRANGUIAS_Entidades)
    Private m_dtEntidades As DataTable

    Private l_Conductores As EConductores 'FUNCON CREADO PARA REGISTRAR LO Y AMARRARLO A CONDUCTORES 

    Private m_dsEntidades As DataSet
    Private d_entidades As DTRANGUIAS_Entidades

    Private d_usuarios As DTRANGUIAS_Usuarios


    Private d_vent_docsventa As DTRANGUIAS_Entidades



#End Region

#Region " Constructores "
    Sub New()
        d_entidades = New DTRANGUIAS_Entidades
        d_usuarios = New DTRANGUIAS_Usuarios
    End Sub



#End Region

#Region " Propiedades "
    Public Property ETRAN_GUIAS_Entidades() As ETRANGUIAS_Entidades
        Get
            Return m_entidades
        End Get
        Set(ByVal value As ETRANGUIAS_Entidades)
            m_entidades = value
        End Set
    End Property
    Public Property ETRAN_GUIAS_Usuarios() As ETRANGUIAS_Usuarios
        Get
            Return m_usuarios
        End Get
        Set(ByVal value As ETRANGUIAS_Usuarios)
            m_usuarios = value
        End Set
    End Property

    Public Property ListUsuariosApp() As List(Of ETRANGUIAS_Entidades)
        Get
            Return m_listEntidades
        End Get
        Set(ByVal value As List(Of ETRANGUIAS_Entidades))
            m_listEntidades = value
        End Set
    End Property

    Public Property DTUsuariosPorAlmacen() As DataTable
        Get
            Return m_dtEntidades
        End Get
        Set(ByVal value As DataTable)
            m_dtEntidades = value
        End Set
    End Property

    Public Property DSUsuariosPorAlmacen() As DataSet
        Get
            Return m_dsEntidades
        End Get
        Set(ByVal value As DataSet)
            m_dsEntidades = value
        End Set
    End Property
#End Region

#Region " Funciones para obtencion de datos "

#End Region



    'Public Function Busqueda(ByVal x_opcion As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_zonas_codigo As String _
    '                      , ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
    '    m_listVENT_Pedidos = New List(Of ETRANGUIAS_Entidades)
    '    Try
    '        Return d_vent_pedidos.VENT_PEDIDSS_Busqueda(m_listVENT_Pedidos, x_fecini, x_fecfin, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function



    ' <summary>
    ' Cargar pedido / cotización
    ' </summary>
    ' <param name="x_pedid_codigo">codigo del pedido</param>
    ' <param name="x_detalle">opcion para la carga del detalle</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function Cargar(ByVal x_EntidCodigo As String, ByVal x_detalle As Boolean) As Boolean
        Try
            Dim _join As New List(Of ACJoin)


            _join.Add(New ACJoin(ETRANGUIAS_Entidades.Esquema, ETRANGUIAS_Entidades.Tabla, "GUIAEntidad", ACJoin.TipoJoin.Inner _
                                         , New ACCampos() {New ACCampos("EntiDocumento", "ENTID_CodigoFk")}))
            '_join.Add(New ACJoin(ETRANGUIAS_Usuarios.Esquema, ETRANGUIAS_Usuarios.Tabla, "GUIAUsuario", ACJoin.TipoJoin.Inner _
            '                             , New ACCampos() {New ACCampos("ENTID_CodigoFk", "ENTID_CodigoFk")}))
            Dim _where As New Hashtable()
            _where.Add("EntiDocumento", New ACWhere(x_EntidCodigo, ACWhere.TipoWhere.Igual))
            If Cargar(_join, _where) Then

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function CargarUsuario(ByVal x_EntidCodigo As String, ByVal x_detalle As Boolean) As Boolean
        Try
            Dim _join As New List(Of ACJoin)


            _join.Add(New ACJoin(ETRANGUIAS_Entidades.Esquema, ETRANGUIAS_Entidades.Tabla, "GUIAEntidad", ACJoin.TipoJoin.Inner _
                                         , New ACCampos() {New ACCampos("ENTID_CodigoFk", "EntiDocumento")}))
            '_join.Add(New ACJoin(EConductores.Esquema, EConductores.Tabla, "EntConduct", ACJoin.TipoJoin.Inner _
            '                             , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoFk")}))
            '_join.Add(New ACJoin(EConductores.Esquema, EConductores.Tabla, "EntConduct", ACJoin.TipoJoin.Inner) _
            '          , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoFk")}))

            Dim _where As New Hashtable()
            _where.Add("EntiDocumento", New ACWhere(x_EntidCodigo, ACWhere.TipoWhere.Igual))
            If Cargar(_join, _where, x_EntidCodigo) Then

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CargarEntidad(ByVal x_EntidCodigo As String, ByVal x_detalle As Boolean) As Boolean
        Try
            Dim _join As New List(Of ACJoin)


            _join.Add(New ACJoin(ETRANGUIAS_Usuarios.Esquema, ETRANGUIAS_Usuarios.Tabla, "GUIAEntidad", ACJoin.TipoJoin.Inner _
                                         , New ACCampos() {New ACCampos("ENTID_CodigoFk", "EntiDocumento")})) 'ENTID_CodigoFk
            '_join.Add(New ACJoin(ETRANGUIAS_Usuarios.Esquema, ETRANGUIAS_Usuarios.Tabla, "GUIAUsuario", ACJoin.TipoJoin.Inner _
            '                             , New ACCampos() {New ACCampos("ENTID_CodigoFk", "ENTID_CodigoFk")}))
            Dim _where As New Hashtable()
            _where.Add("EntiDocumento", New ACWhere(x_EntidCodigo, ACWhere.TipoWhere.Igual))
            If Cargar(_join, _where) Then

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Funcion Buscar entidade spar eliminacion  Entidad + etran_guiasusuarios 

    Public Function CargarEntidadXEliminacion(ByVal x_EntidCodigo As String, ByVal x_detalle As Boolean) As Boolean
        Try
            Dim _join As New List(Of ACJoin)


            _join.Add(New ACJoin(ETRANGUIAS_Usuarios.Esquema, ETRANGUIAS_Usuarios.Tabla, "GUIAEntidad", ACJoin.TipoJoin.Inner _
                                         , New ACCampos() {New ACCampos("ENTID_CodigoFk", "EntiDocumento")})) 'ENTID_CodigoFk
            _join.Add(New ACJoin(EConductores.Esquema, EConductores.Tabla, "Conduct", ACJoin.TipoJoin.Inner _
                                         , New ACCampos() {New ACCampos("ENTID_Codigo", "EntiDocumento")}))
            Dim _where As New Hashtable()
            _where.Add("EntiDocumento", New ACWhere(x_EntidCodigo, ACWhere.TipoWhere.Igual))
            If Cargar(_join, _where) Then

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    ' <summary> 
    ' Capa de Negocio: VENT_PEDIDSS_ObtenerPedidoReposicion
    ' </summary>
    ' <param name="x_fecfin">Parametro 1: </param> 
    ' <param name="x_zonas_codigo">Parametro 2: </param> 
    ' <param name="x_pvent_id">Parametro 3: </param> 
    ' <param name="x_sucur_id">Parametro 4: </param> 
    ' <param name="x_pedid_tipo">Parametro 5: </param> 
    ' <param name="x_opcion">Parametro 6: </param> 
    ' <param name="x_cadena">Parametro 7: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    'Public Function VENT_PEDIDSS_ObtenerPedidoReposicion(ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String) As Boolean
    '    m_listVENT_Pedidos = New List(Of ETRANGUIAS_Entidades)
    '    Try
    '        Return d_vent_pedidos.VENT_PEDIDSS_ObtenerPedidoReposicion(m_listVENT_Pedidos, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_pedid_tipo, x_opcion, x_cadena)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function



#Region "Funciones Simples "

    Public Function CargarTodos() As Boolean
        Try
            m_listEntidades = New List(Of ETRANGUIAS_Entidades)()
            Return d_entidades.ENTIDSS_Todos(m_listEntidades)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_where As Hashtable) As Boolean
        Try
            m_listEntidades = New List(Of ETRANGUIAS_Entidades)()
            Return d_entidades.ENTIDSS_Todos(m_listEntidades, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_listEntidades = New List(Of ETRANGUIAS_Entidades)()
            Return d_entidades.ENTIDSS_Todos(m_listEntidades, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
        Try
            m_listEntidades = New List(Of ETRANGUIAS_Entidades)()
            Return d_entidades.ENTIDSS_Todos(m_listEntidades, x_join, x_where, x_distinct)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDS(ByVal x_where As Hashtable) As Boolean
        Try
            m_dsEntidades = New DataSet()
            Return d_entidades.ENTIDSS_Todos(m_dsEntidades, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDS(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_dsEntidades = New DataSet()
            Return d_entidades.ENTIDSS_Todos(m_dsEntidades, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDT(ByVal x_where As Hashtable) As Boolean
        Try
            m_dsEntidades = New DataSet()
            Dim _opcion As Boolean = d_entidades.ENTIDSS_Todos(m_dsEntidades, x_where)
            If _opcion Then
                m_dtEntidades = m_dsEntidades.Tables(0)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarTodosDT(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_dsEntidades = New DataSet()
            Dim _opcion As Boolean = d_entidades.ENTIDSS_Todos(m_dsEntidades, x_join, x_where)
            If _opcion Then
                m_dtEntidades = m_dsEntidades.Tables(0)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cargar(ByVal x_entid_codigo As String) As Boolean
        Try
            m_entidades = New ETRANGUIAS_Entidades()
            Return d_entidades.ENTIDSS_UnReg(m_entidades, x_entid_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cargar(ByVal x_where As Hashtable) As Boolean
        Try
            m_entidades = New ETRANGUIAS_Entidades()
            Return d_entidades.ENTIDSS_UnReg(m_entidades, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Cargar para Entidades 
    Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
        Try
            m_entidades = New ETRANGUIAS_Entidades()
            Return d_entidades.ENTIDSS_UnReg(m_entidades, x_join, x_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Cargar para Usuarios 


    Public Function Cargar(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable, ByVal x_entid_Codigo As String) As Boolean
        Try
            m_usuarios = New ETRANGUIAS_Usuarios()
            Return d_entidades.Usuarios_UnReg(m_usuarios, x_entid_Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Guardar(ByVal x_usuario As String, ByVal x_RECIBE_Usuarios As ETRANGUIAS_Usuarios) As Boolean
        Try
            If m_entidades.Nuevo Then
                d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario)
            ElseIf m_entidades.Modificado Then
                d_entidades.ENTIDSU_UnReg(m_entidades, x_usuario)
            ElseIf m_entidades.Eliminado Then
                d_entidades.ENTIDSD_UnReg(m_entidades)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String) As Boolean
        Try
            If m_entidades.Nuevo Then
                d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario)
            ElseIf m_entidades.Modificado Then
                d_entidades.ENTIDSU_UnReg(m_entidades, x_where, x_usuario)
            ElseIf m_entidades.Eliminado Then
                d_entidades.ENTIDSD_UnReg(x_where)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Parametros para guardar entidades y usuarios en una sola transacction  by frank 
    Public Function Guardar(ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            'Dim d_entidades As New DEntidades()
            If m_entidades.Nuevo Then
                'm_entidades.Estado = 0
                'm_entidades.ENTID_Id = getCorrelativo("ENTID_Id")

                d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario)
                'DAEnterprise.CommitTransaction()
            ElseIf m_entidades.Modificado Then
                d_entidades.ENTIDSU_UnReg(m_entidades, x_usuario)
            ElseIf m_entidades.Eliminado Then
                Dim _entidad As New ETRANGUIAS_Entidades()
                d_entidades.ENTIDSU_UnReg(_entidad, x_usuario)
                'DAEnterprise.CommitTransaction()
                Return True
            End If

            If (m_usuarios.Nuevo) Then

                d_usuarios.USUARSI_UnReg(m_usuarios, x_usuario)
            ElseIf m_usuarios.Modificado Then
                d_usuarios.USUARUP_UnReg(m_usuarios, x_usuario)
            ElseIf m_usuarios.Eliminado Then
                Dim _entidad As New ETRANGUIAS_Entidades()
                d_usuarios.USUARSD_UnReg(m_usuarios)
                'DAEnterprise.CommitTransaction()
                Return True
            End If
            '' Guardar Tablas adicionales a la entidad


            '' Completar la operacion cerrando la transacción
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function




    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_entidades.Nuevo Then
                d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario, x_excluir, x_setfecha)
            ElseIf m_entidades.Modificado Then
                d_entidades.ENTIDSU_UnReg(m_entidades, x_where, x_usuario, x_excluir, x_setfecha)
            ElseIf m_entidades.Eliminado Then
                d_entidades.ENTIDSD_UnReg(m_entidades)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_where As Hashtable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Boolean
        Try
            If m_entidades.Nuevo Then
                d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario, x_excluir, x_setfecha)
            ElseIf m_entidades.Modificado Then
                d_entidades.ENTIDSU_UnReg(m_entidades, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos)
            ElseIf m_entidades.Eliminado Then
                d_entidades.ENTIDSD_UnReg(m_entidades)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_entidades.Nuevo Then
                d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario, x_setfecha)
            ElseIf m_entidades.Modificado Then
                d_entidades.ENTIDSU_UnReg(m_entidades, x_usuario, x_setfecha)
            ElseIf m_entidades.Eliminado Then
                d_entidades.ENTIDSD_UnReg(m_entidades)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Guardar(ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Boolean
        Try
            If m_entidades.Nuevo Then
                d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario, x_excluir, x_setfecha)
            ElseIf m_entidades.Eliminado Then
                d_entidades.ENTIDSD_UnReg(m_entidades)
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Eliminar(ByVal x_where As Hashtable) As Boolean
        Try
            m_listEntidades = New List(Of ETRANGUIAS_Entidades)()
            Return d_entidades.ENTIDSD_UnReg(x_where) > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Comprobar .. si existe en conductores .. no se deberia eliminar --> si ya existe 

    Public function ComprobarExistsConductor(Byval x_NumeroDocumento As String ) As Boolean 
        Try
            d_entidades.ENTID_EXISTS_UnReg(x_NumeroDocumento) 
        Catch ex As Exception
            Throw ex 
        End Try
    End function


    Public Function Eliminar(ByVal X_NumeroDocumento As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            'Dim d_entidades As New DEntidades()
            If m_entidades.Eliminado Then
                Dim _entidad As New ETRANGUIAS_Entidades()
                d_entidades.ENTIDSD_UnReg(X_NumeroDocumento)
                'DAEnterprise.CommitTransaction()

            End If


            If m_usuarios.Eliminado Then
                Dim _entidad As New ETRANGUIAS_Entidades()
                d_entidades.UsuarioDSD_UnReg(X_NumeroDocumento)
                'DAEnterprise.CommitTransaction()

            End If
            '' Guardar Tablas adicionales a la entidad


            '' Completar la operacion cerrando la transacción
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function getCorrelativo(ByVal x_campo As String) As Integer
        Try
            Return d_entidades.getCorrelativo(x_campo) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String) As Integer
        Try
            x_id = d_entidades.getCorrelativo(x_campo)
            Return (x_id + 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            Return d_entidades.getCorrelativo(x_campo, x_where) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getCorrelativo(ByRef x_id As Integer, ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            x_id = d_entidades.getCorrelativo(x_campo, x_where)
            Return (x_id + 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



#End Region


End Class

Imports System
Imports System.Data
Imports System.Collections.Generic
Imports ACBLogistica
Imports ACBVentas
Imports ACDVentas
Imports ACEVentas
Imports System.Configuration
Imports System.Net.Configuration
Imports ACETransporte
Imports ACBTransporte

Imports DAConexion


Imports ACFramework

Public Class BGenerarGuias

#Region " Variables "
	
	Private m_dtGenerarGuias As DataTable
    Private ds_generarguias As DataSet
    
    Private managerTRAN_Vehiculos As BTRAN_Vehiculos'_A
    Private m_etran_vehiculos As ETRAN_Vehiculos '_A

   Private m_edist_guiasremision As EDIST_GuiasRemision
   Private m_vent_docsventa As EVENT_DocsVenta
    Private m_vent_pedidos As EVENT_Pedidos
   Private m_listDIST_GuiasRemision As List(Of EDIST_GuiasRemision)
   Private m_listVENT_DocsVenta As List(Of EVENT_DocsVenta)
    Private m_listVENT_Pedidos As List(Of EVENT_Pedidos)
   Private d_generarguias As DGenerarGuias

   Private m_pvent_id As Long
   Private m_periodo As String
   Private m_almac_id As Short
   Private m_zonas_codigo As String
   Private m_sucur_id As Integer

   Private m_tipoguia As ETipos.MotivoTraslado

   Enum m_tguia
      Ingreso
      Egreso
   End Enum


#End Region

#Region " Constructores "

    ' <summary>
    ' Contructor
    ' </summary>
    ' <param name="x_pvent_id">Codigo de Punto de venta</param>
    ' <param name="x_almac_id">Codigo del almacen</param>
    ' <param name="x_periodo">Codigo del periodo activo</param>
    ' <param name="x_zonas_codigo">codigo de zona</param>
    ' <param name="x_sucur_id">Codigo de sucursal</param>
    ' <remarks></remarks>
    Public Sub New(ByVal x_pvent_id As Long, ByVal x_almac_id As Short, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
        m_pvent_id = x_pvent_id
        m_periodo = x_periodo
        m_almac_id = x_almac_id
        m_zonas_codigo = x_zonas_codigo
        m_sucur_id = x_sucur_id
        d_generarguias = New DGenerarGuias
        managerTRAN_Vehiculos = New BTRAN_Vehiculos
        m_etran_vehiculos = New ETRAN_Vehiculos
    End Sub
    Public Sub New(ByVal x_almac_id As Short, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
        m_periodo = x_periodo
        m_almac_id = x_almac_id
        m_zonas_codigo = x_zonas_codigo
        m_sucur_id = x_sucur_id
        d_generarguias = New DGenerarGuias
        managerTRAN_Vehiculos = New BTRAN_Vehiculos
        m_etran_vehiculos = New ETRAN_Vehiculos
    End Sub



#End Region

#Region " Propiedades "

    Public Property DIST_GuiasRemision() As EDIST_GuiasRemision
        Get
            Return m_edist_guiasremision
        End Get
        Set(ByVal value As EDIST_GuiasRemision)
            m_edist_guiasremision = value
        End Set
    End Property

    Public Property ListDIST_GuiasRemision() As List(Of EDIST_GuiasRemision)
        Get
            Return m_listDIST_GuiasRemision
        End Get
        Set(ByVal value As List(Of EDIST_GuiasRemision))
            m_listDIST_GuiasRemision = value
        End Set
    End Property

    Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
        Get
            Return m_listVENT_DocsVenta
        End Get
        Set(ByVal value As List(Of EVENT_DocsVenta))
            m_listVENT_DocsVenta = value
        End Set
    End Property

    Public Property VENT_DocsVenta() As EVENT_DocsVenta
        Get
            Return m_vent_docsventa
        End Get
        Set(ByVal value As EVENT_DocsVenta)
            m_vent_docsventa = value
        End Set
    End Property
    Public Property ListVENT_Pedidos() As List(Of EVENT_Pedidos)
        Get
            Return m_listVENT_Pedidos
        End Get
        Set(ByVal value As List(Of EVENT_Pedidos))
            m_listVENT_Pedidos = value
        End Set
    End Property

    Public Property VENT_Pedidos() As EVENT_Pedidos
        Get
            Return m_vent_pedidos
        End Get
        Set(ByVal value As EVENT_Pedidos)
            m_vent_pedidos = value
        End Set
    End Property
#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "

    ' <summary>
    ' Busqueda de guias de remision
    ' </summary>
    ' <param name="x_cadena">Cadena de busqueda</param>
    ' <param name="x_campo">Campo sobre el cual se busca la cadena</param>
    ' <param name="x_pvent_id">codigo de punto de venta</param>
    ' <param name="x_cfecha"></param>
    ' <param name="x_tipos_codmotivo">Motivo de traslado de la Guia</param>
    ' <param name="x_fecini">Fecha de inicio de busqueda</param>
    ' <param name="x_fecfin">Fecha de Fin de busqueda</param>
    ' <param name="x_todos">Buscar todos incluido los anulados</param>
    ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
    ' <remarks></remarks>
    Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_pvent_id As Integer, ByVal x_cfecha As String _
                          , ByVal x_tipos_codmotivo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.BuscarGuiasRemision(x_fecini, x_fecfin, x_pvent_id, x_tipos_codmotivo, x_campo, x_cadena, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' <summary>
    ' Busqueda de guias de salida de mercaderia
    ' </summary>
    ' <param name="x_almac_iddestino">codigo de almcen destino</param>
    ' <param name="x_fecini">fecha de inicio de busqueda</param>
    ' <param name="x_fecfin">fecha de fin de busqueda</param>
    ' <param name="x_tipos_codmotivotraslado">motivo de traslado de la guia</param>
    ' <param name="x_opcionfecha">tipo de fecha de emision o traslado</param>
    ' <param name="x_opcion">campo sobre el cual se busca la cadena</param>
    ' <param name="x_cadena">cadena de busqueda</param>
    ' <param name="x_todos">buscar a todos incluidos los anulados</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaSalida(ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.ObtenerGuiasSalida(x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Busqueda de guias de salida de mercaderia
    ' </summary>
    ' <param name="x_almac_iddestino">codigo de almcen destino</param>
    ' <param name="x_fecini">fecha de inicio de busqueda</param>
    ' <param name="x_fecfin">fecha de fin de busqueda</param>
    ' <param name="x_tipos_codmotivotraslado">motivo de traslado de la guia</param>
    ' <param name="x_opcionfecha">tipo de fecha de emision o traslado</param>
    ' <param name="x_opcion">campo sobre el cual se busca la cadena</param>
    ' <param name="x_cadena">cadena de busqueda</param>
    ' <param name="x_todos">buscar a todos incluidos los anulados</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaCompra(ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.ObtenerGuiasCompra(x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Busqueda de guias de ingreso de mercaderia
    ' </summary>
    ' <param name="x_almac_iddestino">codigo del almacen destino</param>
    ' <param name="x_fecini">fecha de inicio de busqueda</param>
    ' <param name="x_fecfin">fecha de fin de busqueda</param>
    ' <param name="x_tipos_codmotivotraslado">motivo de traslado de la guia</param>
    ' <param name="x_opcionfecha">opcion de busqqueda por fecha de emision o traslado</param>
    ' <param name="x_opcion">opcion para busqueda del campo usando la cadena de busqueda</param>
    ' <param name="x_cadena">cadena de busqueda</param>
    ' <param name="x_todos">buscar todos los registros incluidos los anulados</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaIngreso(ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.ObtenerGuiasIngresos(x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Busqueda de guias por numero
    ' </summary>
    ' <param name="x_numero">numero de la guia a buscar</param>
    ' <param name="x_serie">serie de la guia a buscar</param>
    ' <param name="x_pvent_id">codigo del punto de venta</param>
    ' <param name="x_tipos_codmotivo">motivo de traslado de la guia</param>
    ' <param name="x_tipos_codtipodocumento">tipo de documento guia</param>
    ' <param name="x_todos">mostrar todos los registros incluidos los anulados</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_pvent_id As Integer _
                                 , ByVal x_tipos_codmotivo As String, ByVal x_tipos_codtipodocumento As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.BuscarGuiasRemisionXNumero(x_numero, x_serie, x_pvent_id, x_tipos_codmotivo, x_tipos_codtipodocumento, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Busqueda de guias de salida de mercaderia por numero
    ' </summary>
    ' <param name="x_numero">numero de la guia a buscar</param>
    ' <param name="x_serie">serie de la guia a buscar</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_tipos_codmotivo">motivo de traslado de la guia</param>
    ' <param name="x_todos">mostrar a todos los registros incluidos los anulado</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaSalidaXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_almac_id As Integer _
                              , ByVal x_tipos_codmotivo As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.ObtenerGuiasSalidaXNumero(x_almac_id, x_numero, x_serie, x_tipos_codmotivo, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' Busqueda de guias de salida de mercaderia por numero
    ' </summary>
    ' <param name="x_numero">numero de la guia a buscar</param>
    ' <param name="x_serie">serie de la guia a buscar</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_tipos_codmotivo">motivo de traslado de la guia</param>
    ' <param name="x_todos">mostrar a todos los registros incluidos los anulado</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaCompraXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_almac_id As Integer _
                               , ByVal x_tipos_codmotivo As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.ObtenerGuiasCompraXNumero(x_almac_id, x_numero, x_serie, x_tipos_codmotivo, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' busqueda de guias de ingreso de mercaderia por numero
    ' </summary>
    ' <param name="x_numero">numero de la guia a buscar</param>
    ' <param name="x_serie">serie de la guia a buscar</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_tipos_codmotivo">codigo del motivo de traslado</param>
    ' <param name="x_todos">mostrar todos incluidos los anulados</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaIngresoXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_almac_id As Integer _
                              , ByVal x_tipos_codmotivo As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.ObtenerGuiasIngresosXNumero(x_almac_id, x_numero, x_serie, x_tipos_codmotivo, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Busqueda de guias de reposicion
    ' </summary>
    ' <param name="x_almac_iddestino">codigo del almacen destino</param>
    ' <param name="x_fecini">fecha de inicio de busqueda</param>
    ' <param name="x_fecfin">fecha de fin de busqueda</param>
    ' <param name="x_tipos_codmotivotraslado">codigo de motivo de traslado de la guia</param>
    ' <param name="x_opcionfecha">opcion de busqueda de fecha de emsion o traslado</param>
    ' <param name="x_opcion">opcion para el campo de busqueda con la cadena</param>
    ' <param name="x_cadena">cadena de busqueda</param>
    ' <param name="x_todos">mostrar todos los registros incluidos los anulados</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaReposicion(ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.ObtenerGuiasReposicion(x_almac_iddestino, x_fecini, x_fecfin, x_tipos_codmotivotraslado, x_opcionfecha, x_opcion, x_cadena, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function






    ' <summary>
    ' Busqueda de guias de reposicion por numero
    ' </summary>
    ' <param name="x_numero">numero de la guia</param>
    ' <param name="x_serie">serie de la guia</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_tipos_codmotivo">codigo del motivo de traslados de la guia</param>
    ' <param name="x_todos">mostrar todos los registros incluidos los anulados</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaReposicionXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_almac_id As Integer _
                           , ByVal x_tipos_codmotivo As String, ByVal x_todos As Boolean) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            If m_bdist_docstraslados.ObtenerGuiasReposicionXNumero(x_almac_id, x_numero, x_serie, x_tipos_codmotivo, x_todos) Then
                m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function VerificarVehiculos(ByVal Ip_Remoto As String, ByVal BD_Remoto As String, ByVal Ip_Local As String, ByVal BD_Local As String, ByVal usuario As String, ByVal password As String, ByVal usuario_ As String) As String

        ''''''''''''''''
        Dim _entgrabar As Boolean = False
        Dim m_bdist_docstraslados As New BDIST_GuiasRemision() With {.DIST_GuiasRemision = m_edist_guiasremision}

        If ACUtilitarios.ACCrearCadena("StrConn", Ip_Remoto, BD_Remoto, usuario, password) Then
            DAEnterprise.Instanciar("StrConn", True)
            If Not managerTRAN_Vehiculos.Cargar(m_bdist_docstraslados.DIST_GuiasRemision.VEHIC_Placa, True) Then
                Throw New Exception("No se puede Cargar el vehiculo en el servidor Local")
            End If
        Else
            Throw New Exception("No se puede establecer conexion con el servidor local")
        End If



        If ACUtilitarios.ACCrearCadena("StrConn", Ip_Local, BD_Local, usuario, password) Then
            DAEnterprise.Instanciar("StrConn", True)
            '' Verificar si el cliente existe en el servidor local

            If Not managerTRAN_Vehiculos.Cargar(m_bdist_docstraslados.DIST_GuiasRemision.VEHIC_Placa, True) Then
                _entgrabar = True
                '' Establecer conexion con el servidor remoto para traer los datos del cliente, pra grabarlos en el servidor local
                'If ACUtilitarios.ACCrearCadena("StrConn", Ip_Remoto, BD_Remoto, usuario, password) Then
                '   DAEnterprise.Instanciar("StrConn", True)
                '    If Not managerTRAN_Vehiculos.Cargar(m_bdist_docstraslados.DIST_GuiasRemision.VEHIC_Placa,True) Then 
                '        Throw New Exception("No se puede Cargar la entidad Cliente en el servidor Local")
                '    End If
                'Else
                '   Throw New Exception("No se puede establecer conexion con el servidor local")
                'End If
            Else
                _entgrabar = False
                'If ACUtilitarios.ACCrearCadena("StrConn", Ip_Local, BD_Local, usuario, password) Then
                '   DAEnterprise.Instanciar("StrConn", True)
                '   'If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor remoto")
                'End If
            End If

            '' Establecer conexion al servidor local para grabar los datos
            If ACUtilitarios.ACCrearCadena("StrConn", Ip_Local, BD_Local, usuario, password) Then
                DAEnterprise.Instanciar("StrConn", True)
                DAEnterprise.BeginTransaction()
                '' Grabar los datos del vehiculo
                If _entgrabar Then
                    m_etran_vehiculos.Instanciar(ACEInstancia.Nuevo) '' : If Not managerTRAN_Vehiculos.Guardar(usuario_,false) Then 
                    '                                                       Throw New Exception("No se puede Cargar la entidad Cliente en el servidor Local")
                    '                                                   End If
                    managerTRAN_Vehiculos.TRAN_Vehiculos.Instanciar(ACEInstancia.Nuevo)
                    If m_etran_vehiculos.Nuevo Then m_etran_vehiculos.VEHIC_Id = managerTRAN_Vehiculos.getCorrelativo()
                    managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Id = m_etran_vehiculos.VEHIC_Id
                    'managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Codigo = m_etran_vehiculos.VEHIC_Codigo
                    If managerTRAN_Vehiculos.Guardar(usuario, True) Then
                        DAEnterprise.CommitTransaction()
                    Else
                        Throw New Exception("No se puede Cargar el vehiculo en el servidor Local")
                    End If
                    DAEnterprise.CommitTransaction()
                    Return managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Id
                Else
                    m_etran_vehiculos.Instanciar(ACEInstancia.Modificado)
                    'Dim id As String = managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Id 
                    If m_etran_vehiculos.Modificado Then 'm_etran_vehiculos.VEHIC_Id = managerTRAN_Vehiculos.getCorrelativo()
                        ''managerTRAN_Vehiculos.TRAN_Vehiculos = m_etran_vehiculos
                        managerTRAN_Vehiculos.TRAN_Vehiculos.Instanciar(ACEInstancia.Modificado)
                        If managerTRAN_Vehiculos.Guardar(usuario, True) Then
                            DAEnterprise.CommitTransaction()
                        Else
                            Throw New Exception("No se puede Cargar el vehiculo en el servidor Local")
                        End If
                    End If
                    DAEnterprise.CommitTransaction()
                    Return managerTRAN_Vehiculos.TRAN_Vehiculos.VEHIC_Id
                    'Return Id
                End If
            End If
        End If




        '''''''''''''''''''''

    End Function


    ' <summary>
    ' Grabar guia
    ' </summary>
    ' <param name="x_usuario">Codigo de usuario</param>
    ' <param name="x_tipoguia">tipo de guia de remision</param>
    ' <param name="x_orden">campo para definir si la guia se genera por un documento de venta o una orden de compra</param>
    ' <param name="x_tguia">tipo de guia, de ingreso o salida</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function GrabarGuia(ByVal x_usuario As String, ByVal x_tipoguia As ETipos.MotivoTraslado, ByVal x_orden As Boolean, ByVal x_tguia As m_tguia) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision() With {.DIST_GuiasRemision = m_edist_guiasremision}
            '' Verificar si hay punto de venta origen
            If m_edist_guiasremision.PVENT_IdOrigen = 0 Then
                Dim _PtoVenta As New BPuntoVenta
                Dim _where As New Hashtable
                _where.Add("ALMAC_Id", New ACFramework.ACWhere(m_edist_guiasremision.ALMAC_IdOrigen))
                If _PtoVenta.Cargar(_where) Then
                    m_bdist_docstraslados.DIST_GuiasRemision.PVENT_IdOrigen = _PtoVenta.PuntoVenta.PVENT_Id
                Else
                    m_bdist_docstraslados.DIST_GuiasRemision.PVENT_IdOrigen = m_bdist_docstraslados.DIST_GuiasRemision.PVENT_IdDestino
                End If
            End If

            Select Case x_tipoguia
                Case ETipos.MotivoTraslado.Venta
                    '' Validar que la guia no haya sido anulada en otra ventan
                    If x_orden Then
                        Dim _borden As New BDIST_Ordenes
                        If _borden.Cargar(m_bdist_docstraslados.DIST_GuiasRemision.ORDEN_Codigo) Then
                            If _borden.DIST_Ordenes.ORDEN_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Anulado) Then
                                Throw New Exception(String.Format("El Documento Orden: {0} que Ud. esta intentando crear una guia, acaba de ser anulado, no puede continuar con el proceso de creación de La Guia", m_bdist_docstraslados.DIST_GuiasRemision.ORDEN_Codigo))
                            End If
                        End If
                    Else
                        Dim _bfactura As New BVENT_DocsVenta
                        If _bfactura.Cargar(m_bdist_docstraslados.DIST_GuiasRemision.DOCVE_Codigo) Then
                            If _bfactura.VENT_DocsVenta.DOCVE_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Anulado) Then
                                Throw New Exception(String.Format("El Documento Venta: {0} que Ud. esta intentando crear una guia, acaba de ser anulado, no puede continuar con el proceso de creación de La Guia", m_bdist_docstraslados.DIST_GuiasRemision.DOCVE_Codigo))
                            End If
                        End If
                    End If


                    DAEnterprise.BeginTransaction()
                    '' Grabar Documento de Traslado Guia de Remision
                    If m_bdist_docstraslados.Guardar(x_usuario) Then
                        '' Verificar que las cantidades no excedan los saldos.
                        Dim _msg As String = ""
                        For Each item As EDIST_GuiasRemisionDetalle In m_bdist_docstraslados.DIST_GuiasRemision.ListDIST_GuiasRemisionDetalle
                            Dim _saldo As Decimal = 0
                            If x_orden Then
                                m_bdist_docstraslados.GetSaldoArticulo(m_bdist_docstraslados.DIST_GuiasRemision.ORDEN_Codigo, item.ARTIC_Codigo, _saldo, x_orden)
                            Else
                                m_bdist_docstraslados.GetSaldoArticulo(m_bdist_docstraslados.DIST_GuiasRemision.DOCVE_Codigo, item.ARTIC_Codigo, _saldo, x_orden)
                            End If
                            If item.GUIRD_Cantidad > _saldo Then
                                _msg &= String.Format("- Articulo [{1}] Su saldo es [{3}], y la cantidad que desea retirar es [{4}]{0}", vbNewLine, item.ARTIC_Codigo, item.ARTIC_Descripcion, _saldo.ToString("#,###,##0.00"), item.GUIRD_Cantidad.ToString("#,###,##0.00"))
                            End If
                        Next
                        'If _msg.Length > 0 Then
                        '   Throw New Exception(String.Format("No puede grabar el documento, por que hay articulos que exceden el saldo disponible, debe actualizar sus saldos{0}{1}", vbNewLine, _msg))
                        'End If
                        '' Grabar el Detalle de la Guia de Remisión
                        Dim i As Integer = 1
                        For Each Item As EDIST_GuiasRemisionDetalle In m_bdist_docstraslados.DIST_GuiasRemision.ListDIST_GuiasRemisionDetalle
                            If Item.GUIRD_Cantidad > 0 Then
                                Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                                Item.GUIRD_Item = i
                                Item.GUIAR_Codigo = m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_Codigo
                                Dim m_bdist_docstrasladosdetalle As New BDIST_GuiasRemisionDetalle() With {.DIST_GuiasRemisionDetalle = Item}
                                If m_bdist_docstrasladosdetalle.Guardar(x_usuario) Then
                                    '' Mover Stock si El documento de venta esta marcado para hacer el movimiento
                                    If m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_StockDevuelto Then
                                        Dim _stocks As New ACBLogistica.BManejarStock
                                        _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                        _stocks.LOG_Stocks.GUIAR_Codigo = Item.GUIAR_Codigo
                                        _stocks.LOG_Stocks.GUIRD_Item = Item.GUIRD_Item
                                        _stocks.LOG_Stocks.STOCK_Lote = Item.GUIRD_Lote
                                        _stocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad,
                                             m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaEmision, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPendDevuelta), x_usuario)
                                    End If
                                End If
                                i += 1
                            End If
                        Next

                        '' Actualizar
                        '' Terminar Transaccion
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        DAEnterprise.RollBackTransaction()
                        Return False
                    End If
                Case ETipos.MotivoTraslado.Traslado_Empresa
                    DAEnterprise.BeginTransaction()

                    '' Grabar Documento de Traslado Guia de Remision

                    If m_bdist_docstraslados.Guardar(x_usuario) Then
                        '' Grabar el Detalle de la Guia de Remisión
                        Dim i As Integer = 1
                        For Each Item As EDIST_GuiasRemisionDetalle In m_bdist_docstraslados.DIST_GuiasRemision.ListDIST_GuiasRemisionDetalle
                            If Item.GUIRD_Cantidad > 0 Then
                                Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                                Item.GUIRD_Item = i
                                Item.GUIAR_Codigo = m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_Codigo
                                Dim m_bdist_docstrasladosdetalle As New BDIST_GuiasRemisionDetalle() With {.DIST_GuiasRemisionDetalle = Item}
                                If m_bdist_docstrasladosdetalle.Guardar(x_usuario) Then
                                    Dim _stocks As New ACBLogistica.BManejarStock
                                    _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                    _stocks.LOG_Stocks.GUIAR_Codigo = Item.GUIAR_Codigo
                                    _stocks.LOG_Stocks.GUIRD_Item = Item.GUIRD_Item
                                    _stocks.LOG_Stocks.STOCK_Lote = Item.GUIRD_Lote
                                    _stocks.LOG_Stocks.STOCK_LoteGeneral = Item.GUIRD_LoteGeneral
                                    Select Case x_tguia
                                        Case m_tguia.Ingreso
                                            _stocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad,
                                                            m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaIngreso, ETipos.getTipo(ETipos.TMovimientoStock.IngresoTraslado), x_usuario)
                                        Case m_tguia.Egreso
                                            _stocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad,
                                                           m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaEmision, ETipos.getTipo(ETipos.TMovimientoStock.SalidaGuiaTraslado), x_usuario)
                                    End Select
                                End If
                                i += 1
                            End If
                        Next
                        '' Terminar Transaccion
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        DAEnterprise.RollBackTransaction()
                        Return False
                    End If

                Case ETipos.MotivoTraslado.Traslado_Transformacion
                    DAEnterprise.BeginTransaction()
                    '' Grabar Documento de Traslado Guia de Remision
                    If m_bdist_docstraslados.Guardar(x_usuario) Then
                        '' Grabar el Detalle de la Guia de Remisión
                        Dim i As Integer = 1
                        For Each Item As EDIST_GuiasRemisionDetalle In m_bdist_docstraslados.DIST_GuiasRemision.ListDIST_GuiasRemisionDetalle
                            If Item.GUIRD_Cantidad > 0 Then
                                Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                                Item.GUIRD_Item = i
                                Item.GUIAR_Codigo = m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_Codigo
                                Dim m_bdist_docstrasladosdetalle As New BDIST_GuiasRemisionDetalle() With {.DIST_GuiasRemisionDetalle = Item}
                                If m_bdist_docstrasladosdetalle.Guardar(x_usuario) Then
                                    Dim _stocks As New ACBLogistica.BManejarStock
                                    _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                    _stocks.LOG_Stocks.GUIAR_Codigo = Item.GUIAR_Codigo
                                    _stocks.LOG_Stocks.GUIRD_Item = Item.GUIRD_Item
                                    _stocks.LOG_Stocks.STOCK_Lote = Item.GUIRD_Lote
                                    _stocks.LOG_Stocks.STOCK_LoteGeneral = Item.GUIRD_LoteGeneral
                                    Select Case x_tguia
                                        Case m_tguia.Ingreso
                                            _stocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad,
                                                            m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaIngreso, ETipos.getTipo(ETipos.TMovimientoStock.SalidaTransformacion), x_usuario)
                                        Case m_tguia.Egreso
                                            _stocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad,
                                                           m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaEmision, ETipos.getTipo(ETipos.TMovimientoStock.SalidaTransformacion), x_usuario)
                                    End Select
                                End If
                                i += 1
                            End If
                        Next
                        '' Terminar Transaccion
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        DAEnterprise.RollBackTransaction()
                        Return False
                    End If


                Case ETipos.MotivoTraslado.Devolucion
                    DAEnterprise.BeginTransaction()
                    '' Grabar Documento de Traslado Guia de Remision
                    If m_bdist_docstraslados.Guardar(x_usuario) Then
                        '' Grabar el Detalle de la Guia de Remisión
                        Dim i As Integer = 1
                        For Each Item As EDIST_GuiasRemisionDetalle In m_bdist_docstraslados.DIST_GuiasRemision.ListDIST_GuiasRemisionDetalle
                            If Item.GUIRD_Cantidad > 0 Then
                                Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                                Item.GUIRD_Item = i
                                Item.GUIAR_Codigo = m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_Codigo
                                Dim m_bdist_docstrasladosdetalle As New BDIST_GuiasRemisionDetalle() With {.DIST_GuiasRemisionDetalle = Item}
                                If m_bdist_docstrasladosdetalle.Guardar(x_usuario) Then
                                    Dim _stocks As New ACBLogistica.BManejarStock
                                    _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                    _stocks.LOG_Stocks.GUIAR_Codigo = Item.GUIAR_Codigo
                                    _stocks.LOG_Stocks.GUIRD_Item = Item.GUIRD_Item
                                    Select Case x_tguia
                                        Case m_tguia.Ingreso
                                            _stocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad,
                                                            m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaIngreso, ETipos.getTipo(ETipos.TMovimientoStock.SalidaDevolucion), x_usuario)
                                        Case m_tguia.Egreso
                                            _stocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad,
                                                           m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaEmision, ETipos.getTipo(ETipos.TMovimientoStock.SalidaDevolucion), x_usuario)
                                            'movimiento de stock aqui 
                                            'Dim m_bmanejarstocks As New BManejarStock()
                                            'm_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                            'm_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.GUIAR_Codigo
                                            'm_bmanejarstocks.LOG_Stocks.ENTID_CodigoCliente = Nothing
                                            'm_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.GUIRD_Item
                                            'If Not m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad, m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaIngreso, ETipos.getTipo(ETipos.TMovimientoStock.SalidaDevolucion), x_usuario) Then
                                            '    ' If x_trans Then DAEnterprise.RollBackTransaction()
                                            '    Return False
                                            'End If
                                    End Select
                                End If
                                i += 1
                            End If


                        Next

                        '' Terminar Transaccion
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        DAEnterprise.RollBackTransaction()
                        Return False
                    End If
                Case ETipos.MotivoTraslado.Compra
                    DAEnterprise.BeginTransaction()
                    '' Grabar Documento de Traslado Guia de Remision
                    If m_bdist_docstraslados.Guardar(x_usuario) Then
                        '' Grabar el Detalle de la Guia de Remisión
                        Dim i As Integer = 1
                        For Each Item As EDIST_GuiasRemisionDetalle In m_bdist_docstraslados.DIST_GuiasRemision.ListDIST_GuiasRemisionDetalle
                            If Item.GUIRD_Cantidad > 0 Then
                                Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                                Item.GUIRD_Item = i
                                Item.GUIAR_Codigo = m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_Codigo
                                Dim m_bdist_docstrasladosdetalle As New BDIST_GuiasRemisionDetalle() With {.DIST_GuiasRemisionDetalle = Item}
                                If m_bdist_docstrasladosdetalle.Guardar(x_usuario) Then
                                    Dim _stocks As New ACBLogistica.BManejarStock
                                    _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                    _stocks.LOG_Stocks.GUIAR_Codigo = Item.GUIAR_Codigo
                                    _stocks.LOG_Stocks.GUIRD_Item = Item.GUIRD_Item
                                    Select Case x_tguia
                                        'Case m_tguia.Ingreso
                                        '    _stocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad, _
                                        '                    m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaIngreso, ETipos.getTipo(ETipos.TMovimientoStock.SalidaDevolucion), x_usuario)
                                        'Case m_tguia.Egreso
                                        '    _stocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad, _
                                        '                   m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaEmision, ETipos.getTipo(ETipos.TMovimientoStock.SalidaDevolucion), x_usuario)
                                        '    'movimiento de stock aqui 
                                        'Dim m_bmanejarstocks As New BManejarStock()
                                        'm_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                        'm_bmanejarstocks.LOG_Stocks.DOCVE_Codigo = Item.GUIAR_Codigo
                                        'm_bmanejarstocks.LOG_Stocks.ENTID_CodigoCliente = Nothing
                                        'm_bmanejarstocks.LOG_Stocks.DOCVD_Item = Item.GUIRD_Item
                                        'If Not m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_almac_id, Item.GUIRD_Cantidad, m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_FechaIngreso, ETipos.getTipo(ETipos.TMovimientoStock.SalidaDevolucion), x_usuario) Then
                                        '    ' If x_trans Then DAEnterprise.RollBackTransaction()
                                        '    Return False
                                        'End If
                                    End Select
                                End If
                                i += 1
                            End If


                        Next

                        '' Terminar Transaccion
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        DAEnterprise.RollBackTransaction()
                        Return False
                    End If
                Case Else
                    Throw New Exception("Error Interno: Especifique correctamente el tipo de guia, o consulte a su administrador")
            End Select


        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Grabar guia generadas por pedidos de reposicion
    ' </summary>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <param name="x_pedid_codigo">codigo del pedido de reposicion</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function GrabarGuiaReposicion(ByVal x_usuario As String, ByVal x_pedid_codigo As String) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision() With {.DIST_GuiasRemision = m_edist_guiasremision}

            m_bdist_docstraslados.DIST_GuiasRemision.PEDID_Codigo = x_pedid_codigo
            DAEnterprise.BeginTransaction()
            '' Grabar Documento de Traslado Guia de Remision
            If m_bdist_docstraslados.Guardar(x_usuario) Then
                '' Grabar el Detalle de la Guia de Remisión
                Dim i As Integer = 1
                For Each Item As EDIST_GuiasRemisionDetalle In m_bdist_docstraslados.DIST_GuiasRemision.ListDIST_GuiasRemisionDetalle
                    If Item.GUIRD_Cantidad > 0 Then
                        Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                        Item.GUIRD_Item = i
                        Item.GUIAR_Codigo = m_bdist_docstraslados.DIST_GuiasRemision.GUIAR_Codigo
                        Dim m_bdist_docstrasladosdetalle As New BDIST_GuiasRemisionDetalle() With {.DIST_GuiasRemisionDetalle = Item}
                        m_bdist_docstrasladosdetalle.Guardar(x_usuario)
                        i += 1
                    End If
                Next
                '' Cambiar de estado al pedido
                Dim m_preposicion As New BVENT_Pedidos
                If m_preposicion.Cargar(x_pedid_codigo) Then
                    If m_preposicion.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Confirmado) Then
                        Throw New Exception("No se puede volver a generar una guia de un pedido de reposición que ya fue generado")
                    End If
                End If
                m_preposicion.VENT_Pedidos = New EVENT_Pedidos
                m_preposicion.VENT_Pedidos.PEDID_Codigo = x_pedid_codigo
                m_preposicion.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Confirmado)
                m_preposicion.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
                m_preposicion.Guardar(x_usuario)
                '' Terminar Transaccion
                DAEnterprise.CommitTransaction()
                Return True
            Else
                DAEnterprise.RollBackTransaction()
                Return False
            End If

        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Anular guia de remision
    ' </summary>
    ' <param name="x_codigo">codigo de la guia de remision</param>
    ' <param name="x_motivo">motivo de anulacion</param>
    ' <param name="x_pgremisionp">permiso para anular guia de remision posteriores a la fecha de creacion</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function AnularGuia(ByVal x_codigo As String, ByVal x_motivo As String, ByVal x_pgremisionp As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Dim m_bdist_docstraslado As New BDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision = New EDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision.Instanciar(ACFramework.ACEInstancia.Modificado)
            '' Verificar el permiso de anulacion despues del mismo dia
            Dim _constantes As New BConstantes
            Dim _fecha As DateTime = _constantes.getFecha()
            If Not _fecha.Date = m_edist_guiasremision.GUIAR_FechaEmision.Date Then
                If Not x_pgremisionp Then
                    Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                End If
                m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_AnuladoCaja = x_pgremisionp
            End If
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Estado = EDIST_GuiasRemision.getEstado(EDIST_GuiasRemision.Estado.Anulado)
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_FechaAnulacion = _fecha
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_MotivoAnulacion = x_motivo
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Codigo = x_codigo
            Return m_bdist_docstraslado.Guardar(x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' Anular guia de remision generada por un documento de venta u orden de recojo
    ' </summary>
    ' <param name="x_codigo">codigo de la guia</param>
    ' <param name="x_motivo">motivo de anulacion</param>
    ' <param name="x_pgremisionp">permiso para anular guia de remision posteriores a la fecha de emision</param>
    ' <param name="x_stockdevuelto">campo para saber si la guia mueve stock, y dicho stock sea anulado en el momento de su anulacion</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function AnularGuiaVenta(ByVal x_codigo As String, ByVal x_motivo As String, ByVal x_pgremisionp As Boolean, ByVal x_stockdevuelto As Boolean, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim m_bdist_docstraslado As New BDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision = New EDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision.Instanciar(ACFramework.ACEInstancia.Modificado)
            '' Verificar el permiso de anulacion despues del mismo dia
            Dim _constantes As New BConstantes
            Dim _fecha As DateTime = _constantes.getFecha()
            If Not _fecha.Date = m_edist_guiasremision.GUIAR_FechaEmision.Date Then
                If Not x_pgremisionp Then
                    Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                End If
                m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_AnuladoCaja = x_pgremisionp
            End If
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Estado = EDIST_GuiasRemision.getEstado(EDIST_GuiasRemision.Estado.Anulado)
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_FechaAnulacion = _fecha
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_MotivoAnulacion = x_motivo
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Codigo = x_codigo
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_StockDevuelto = x_stockdevuelto
            If m_bdist_docstraslado.Guardar(x_usuario) Then
                If x_stockdevuelto Then
                    Dim _dguia As New BDIST_GuiasRemisionDetalle
                    Dim _where As New Hashtable
                    _where.Add("GUIAR_Codigo", New ACWhere(x_codigo))
                    If _dguia.CargarTodos(_where) Then
                        Dim _manejarStock As New ACBLogistica.BManejarStock()
                        For Each item As EDIST_GuiasRemisionDetalle In _dguia.ListDIST_GuiasRemisionDetalle
                            _manejarStock.AnulacionEgresoGuia(m_periodo, item.ARTIC_Codigo, m_almac_id, x_codigo, item.GUIRD_Item, item.GUIRD_Cantidad, x_usuario)
                        Next
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        Throw New Exception("No se completo el proceso de Anular Guia Ingreso")
                    End If
                Else
                    DAEnterprise.CommitTransaction()
                    Return True
                End If
            End If

            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
    ' <summary>
    ' Anular guia de remision generada por un documento de venta u orden de recojo
    ' </summary>
    ' <param name="x_codigo">codigo de la guia</param>
    ' <param name="x_motivo">motivo de anulacion</param>
    ' <param name="x_pgremisionp">permiso para anular guia de remision posteriores a la fecha de emision</param>
    ' <param name="x_stockdevuelto">campo para saber si la guia es de una orden o boleta /factura</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function AnularGuiaVenta(ByVal x_codigo As String, ByVal x_motivo As String, ByVal x_pgremisionp As Boolean,
                                    ByVal x_paseanulacion As Boolean, ByVal x_stockdevuelto As Boolean, ByVal x_usuario As String,
                                    ByVal _orden As Boolean, ByVal _documento As String, ByRef x_msg As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim m_bdist_docstraslado As New BDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision = New EDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision.Instanciar(ACFramework.ACEInstancia.Modificado)
            '' Verificar el permiso de anulacion despues del mismo dia
            Dim _constantes As New BConstantes
            Dim _fecha As DateTime = _constantes.getFecha()


            If Not _fecha.Date = m_edist_guiasremision.GUIAR_FechaEmision.Date Then
                If Not x_pgremisionp Then
                    If Not x_paseanulacion Then
                        Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                    End If
                End If
                m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_AnuladoCaja = x_pgremisionp
            End If





            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Estado = EDIST_GuiasRemision.getEstado(EDIST_GuiasRemision.Estado.Anulado)
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_FechaAnulacion = _fecha
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_MotivoAnulacion = x_motivo
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Codigo = x_codigo
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_StockDevuelto = x_stockdevuelto
            If m_bdist_docstraslado.Guardar(x_usuario) Then
                Dim _docguia As New BDIST_GuiasRemisionDetalle
                Dim _docwhere As New Hashtable
                _docwhere.Add("GUIAR_Codigo", New ACWhere(x_codigo))
                If _docguia.CargarTodos(_docwhere) Then

                    If Not _orden = True Then
                        '  Dim _detguia As New BDIST_GuiasRemisionDetalle
                        Dim _manejardetalle As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                        For Each item As EDIST_GuiasRemisionDetalle In _docguia.ListDIST_GuiasRemisionDetalle
                            _manejardetalle.AnularEntregaAlmacen(m_periodo, item.ARTIC_Codigo, m_almac_id, _documento, item.GUIRD_ItemDocumento, item.GUIRD_Cantidad, x_motivo, x_usuario, x_msg)
                        Next
                        DAEnterprise.CommitTransaction()
                        ' Return True
                        Return x_msg.Length > 0
                    Else
                        '  Dim _detguia As New BDIST_GuiasRemisionDetalle
                        Dim _manejardetalle As New BGenerarOrdenes(m_periodo)

                        For Each item As EDIST_GuiasRemisionDetalle In _docguia.ListDIST_GuiasRemisionDetalle
                            _manejardetalle.AnularEntregaAlmacen(m_periodo, item.ARTIC_Codigo, m_almac_id, _documento, item.GUIRD_ItemDocumento, item.GUIRD_Cantidad, x_motivo, x_usuario, x_msg)
                        Next
                        DAEnterprise.CommitTransaction()
                        ' Return True
                        Return x_msg.Length > 0

                        'Throw New Exception("No se completo el proceso de Anular Guia Ingreso")
                    End If

                End If
            End If
            DAEnterprise.RollBackTransaction()
            Return False


        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Anulacion de guia de remision de ingreso de mercaderia
    ' </summary>
    ' <param name="x_codigo">codigo de guia de remision</param>
    ' <param name="x_motivo">motivo de anulacion de la guia de remision</param>
    ' <param name="x_pgremisionp">permiso para anular guia posteriores de la fecha de creación</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function AnularGuiaIngreso(ByVal x_codigo As String, ByVal x_motivo As String, ByVal x_pgremisionp As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Dim m_bdist_docstraslado As New BDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision = New EDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision.Instanciar(ACFramework.ACEInstancia.Modificado)
            '' Verificar el permiso de anulacion despues del mismo dia
            Dim _constantes As New BConstantes
            Dim _fecha As DateTime = _constantes.getFecha()
            If Not _fecha.Date = m_edist_guiasremision.GUIAR_FechaEmision.Date Then
                If Not x_pgremisionp Then
                    Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                End If
                m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_AnuladoCaja = x_pgremisionp
            End If
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Estado = EDIST_GuiasRemision.getEstado(EDIST_GuiasRemision.Estado.Anulado)
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_FechaAnulacion = _fecha
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_MotivoAnulacion = x_motivo
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Codigo = x_codigo
            DAEnterprise.BeginTransaction()
            If m_bdist_docstraslado.Guardar(x_usuario) Then
                Dim _dguia As New BDIST_GuiasRemisionDetalle
                Dim _where As New Hashtable
                _where.Add("GUIAR_Codigo", New ACWhere(x_codigo))
                If _dguia.CargarTodos(_where) Then
                    Dim _manejarStock As New ACBLogistica.BManejarStock()
                    For Each item As EDIST_GuiasRemisionDetalle In _dguia.ListDIST_GuiasRemisionDetalle
                        _manejarStock.AnulacionIngresoGuia(m_periodo, item.ARTIC_Codigo, m_almac_id, x_codigo, item.GUIRD_Item, item.GUIRD_Cantidad, x_usuario)
                    Next
                    DAEnterprise.CommitTransaction()
                    Return True
                Else
                    Throw New Exception("No se completo el proceso de Anular Guia Ingreso")
                End If
            Else
                Throw New Exception("No se completo el proceso de Anular Guia Ingreso")
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Anulacion de guias de salida de mercaderia
    ' </summary>
    ' <param name="x_codigo">codigo de guia de remision</param>
    ' <param name="x_motivo">motivo de anulacion</param>
    ' <param name="x_pgremisionp">permiso para anular guias pòsteriores a la fecha de creacion</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function AnularGuiaSalida(ByVal x_codigo As String, ByVal x_motivo As String, ByVal x_pgremisionp As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Dim m_bdist_docstraslado As New BDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision = New EDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision.Instanciar(ACFramework.ACEInstancia.Modificado)
            '' Verificar el permiso de anulacion despues del mismo dia
            Dim _constantes As New BConstantes
            Dim _fecha As DateTime = _constantes.getFecha()
            If Not _fecha.Date = m_edist_guiasremision.GUIAR_FechaEmision.Date Then
                If Not x_pgremisionp Then
                    Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                End If
                m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_AnuladoCaja = x_pgremisionp
            End If
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Estado = EDIST_GuiasRemision.getEstado(EDIST_GuiasRemision.Estado.Anulado)
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_FechaAnulacion = _fecha
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_MotivoAnulacion = x_motivo
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Codigo = x_codigo
            DAEnterprise.BeginTransaction()
            If m_bdist_docstraslado.Guardar(x_usuario) Then
                Dim _dguia As New BDIST_GuiasRemisionDetalle
                Dim _where As New Hashtable
                _where.Add("GUIAR_Codigo", New ACWhere(x_codigo))
                If _dguia.CargarTodos(_where) Then
                    Dim _manejarStock As New ACBLogistica.BManejarStock()
                    For Each item As EDIST_GuiasRemisionDetalle In _dguia.ListDIST_GuiasRemisionDetalle
                        _manejarStock.AnulacionEgresoGuia(m_periodo, item.ARTIC_Codigo, m_almac_id, x_codigo, item.GUIRD_Item, item.GUIRD_Cantidad, x_usuario)
                    Next
                    DAEnterprise.CommitTransaction()
                    Return True
                Else
                    Throw New Exception("No se completo el proceso de Anular Guia Ingreso")
                End If
            Else
                Throw New Exception("No se completo el proceso de Anular Guia Ingreso")
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Anulacion de guias de remison de los pedidos de reposicion
    ' </summary>
    ' <param name="x_codigo">codigo de guia de remison</param>
    ' <param name="x_pedid_codigo">codigo de pedido de reposicion</param>
    ' <param name="x_motivo">motivo de anulacion</param>
    ' <param name="x_pgremisionp">permiso para anular guias posteriores a la fecha de creacion</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function AnularGuiaSalidaReposicion(ByVal x_codigo As String, ByVal x_pedid_codigo As String, ByVal x_motivo As String, ByVal x_pgremisionp As Boolean, ByVal x_paseanulacion As Boolean, ByVal x_usuario As String) As Boolean
        Try
            Dim m_bdist_docstraslado As New BDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision = New EDIST_GuiasRemision()
            m_bdist_docstraslado.DIST_GuiasRemision.Instanciar(ACFramework.ACEInstancia.Modificado)
            '' Verificar el permiso de anulacion despues del mismo dia
            Dim _constantes As New BConstantes
            Dim _fecha As DateTime = _constantes.getFecha()
            If Not _fecha.Date = m_edist_guiasremision.GUIAR_FechaEmision.Date Then
                If Not x_pgremisionp Then
                    If Not x_paseanulacion Then
                        Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                    End If
                End If
                m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_AnuladoCaja = x_pgremisionp
            End If
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Estado = EDIST_GuiasRemision.getEstado(EDIST_GuiasRemision.Estado.Anulado)
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_FechaAnulacion = _fecha
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_MotivoAnulacion = x_motivo
            m_bdist_docstraslado.DIST_GuiasRemision.GUIAR_Codigo = x_codigo
            DAEnterprise.BeginTransaction()
            If m_bdist_docstraslado.Guardar(x_usuario) Then
                Dim _pedido As New BVENT_Pedidos
                _pedido.VENT_Pedidos = New EVENT_Pedidos
                _pedido.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
                _pedido.VENT_Pedidos.PEDID_Codigo = x_pedid_codigo
                _pedido.VENT_Pedidos.PEDID_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Ingresado)
                If _pedido.Guardar(x_usuario) Then
                    DAEnterprise.CommitTransaction()
                    Return True
                Else
                    Throw New Exception("No se puede completar el proceso de liberar pedido ")
                End If

            Else
                Throw New Exception("No se completo el proceso de Anular Guia Ingreso")
            End If

        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Cargar guia de remision
    ' </summary>
    ' <param name="x_codigo">codigo de la guia de remision</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function CargarGuia(ByVal x_codigo As String) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
            If m_bdist_docstraslados.Cargar(x_codigo) Then
                m_edist_guiasremision = m_bdist_docstraslados.DIST_GuiasRemision
                Dim _where As New Hashtable()
                _where.Add("GUIAR_Codigo", New ACWhere(x_codigo))
                Dim m_bdist_docstrasladosdetalle As New BDIST_GuiasRemisionDetalle()
                Dim _joinDet As New List(Of ACJoin)
                _joinDet.Add(New ACJoin(EArticulos.Esquema, EArticulos.Tabla, "Art", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                               , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion") _
                                                 , New ACCampos("ARTIC_Id", "ARTIC_Id")}))
                _joinDet.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TUni", "Art", ACJoin.TipoJoin.Inner _
                               , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                               , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida")}))
                If m_bdist_docstrasladosdetalle.CargarTodos(_joinDet, _where) Then
                    m_edist_guiasremision.ListDIST_GuiasRemisionDetalle = New List(Of EDIST_GuiasRemisionDetalle)(m_bdist_docstrasladosdetalle.ListDIST_GuiasRemisionDetalle)
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Busqueda de documentos de venta
    ' </summary>
    ' <param name="x_cadena">cadena de busqueda</param>
    ' <param name="x_campo">campo de busqueda usando la cadena</param>
    ' <param name="x_pvent_id">codigo del punto de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_todos">mostrar todos los registros</param>
    ' <param name="x_fecini">fecha de inicio de busqueda</param>
    ' <param name="x_fecfin">fecha de fin de busqueda</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_pvent_id As Integer, ByVal x_almac_id As Short, ByVal x_todos As Boolean _
                            , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
        Try
            Dim _where As New Hashtable()

            If Not x_todos Then _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado), ACWhere.TipoWhere.Igual))
            _where.Add(x_campo, New ACWhere(x_cadena, "Cli", "System.String", ACWhere.TipoWhere._Like))
            _where.Add("DOCVE_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
            _where.Add("PVENT_Id", New ACWhere(x_pvent_id, ACWhere.TipoWhere.Igual))
            m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            Return d_generarguias.getCliente(m_listVENT_DocsVenta, _where, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDocVenta
    ' </summary>
    ' <param name="x_tconsulta">Parametro 1: </param> 
    ' <param name="x_cadena">Parametro 2: </param> 
    ' <param name="x_almac_id">Parametro 3: </param> 
    ' <param name="x_pvent_id">Parametro 4: </param> 
    ' <param name="x_fecini">Parametro 5: </param> 
    ' <param name="x_fecfin">Parametro 6: </param> 
    ' <param name="x_desbloqueo">Parametro 7: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtDocVenta(ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_desbloqueo As Boolean) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDocVenta(m_listVENT_DocsVenta, x_tconsulta, x_cadena, x_almac_id, x_pvent_id, x_fecini, x_fecfin, x_desbloqueo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDocVenta
    ' </summary>
    ' <param name="x_tconsulta">Parametro 1: </param> 
    ' <param name="x_cadena">Parametro 2: </param> 
    ' <param name="x_almac_id">Parametro 3: </param> 
    ' <param name="x_pvent_id">Parametro 4: </param> 
    ' <param name="x_fecini">Parametro 5: </param> 
    ' <param name="x_fecfin">Parametro 6: </param> 
    ' <param name="x_desbloqueo">Parametro 7: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtCotizaciones(ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_desbloqueo As Boolean) As Boolean
        m_listVENT_Pedidos = New List(Of EVENT_Pedidos)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtCotizaciones(m_listVENT_Pedidos, x_tconsulta, x_cadena, x_almac_id, x_pvent_id, x_fecini, x_fecfin, x_desbloqueo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtOrdenes
    ' </summary>
    ' <param name="x_tconsulta">Parametro 1: </param> 
    ' <param name="x_cadena">Parametro 2: </param> 
    ' <param name="x_almac_id">Parametro 3: </param> 
    ' <param name="x_pvent_id">Parametro 4: </param> 
    ' <param name="x_fecini">Parametro 5: </param> 
    ' <param name="x_fecfin">Parametro 6: </param> 
    ' <param name="x_desbloqueo">Parametro 7: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtOrdenes(ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_desbloqueo As Boolean) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtOrdenes(m_listVENT_DocsVenta, x_tconsulta, x_cadena, x_almac_id, x_pvent_id, x_fecini, x_fecfin, x_desbloqueo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Enum TDocumento
        DOcVenta
        Ordenes
    End Enum

    ' <summary>
    ' busqueda de documentos de venta usando el numero
    ' </summary>
    ' <param name="x_numero">numero del documento de venta</param>
    ' <param name="x_serie">serie del documento</param>
    ' <param name="x_tipos_codtipodocumento">tipo de documento</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_pvent_id">codigo del punto de venta</param>
    ' <param name="x_desbloqueo">codigo de desbloqueo de pendientes superiores al la cantidad de meses que tiene configurado</param>
    ' <param name="x_pergenguia">permiso para poder cargar una pendiente que fue bloqueada por exceder el tiempo disponible configurado</param>
    ' <param name="x_tipodoc">tipo de documento Doc Venta u orden</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function BusquedaXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean, ByVal x_pergenguia As Boolean, ByVal x_tipodoc As TDocumento) As Boolean
        Try
            Select Case x_tipodoc
                Case TDocumento.DOcVenta
                    Return BusquedaDocVentaXNumero(x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
                Case TDocumento.Ordenes
                    Return ObtOrdenesXNumero(x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
                Case Else
                    Return BusquedaDocVentaXNumero(x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDocVentaXNumero
    ' </summary>
    ' <param name="x_numero">Parametro 1: </param> 
    ' <param name="x_serie">Parametro 2: </param> 
    ' <param name="x_tipos_codtipodocumento">Parametro 3: </param> 
    ' <param name="x_almac_id">Parametro 4: </param> 
    ' <param name="x_pvent_id">Parametro 5: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function BusquedaDocVentaXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean, ByVal x_pergenguia As Boolean) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDocVentaXNumero(m_listVENT_DocsVenta, x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtOrdenesXNumero
    ' </summary>
    ' <param name="x_numero">Parametro 1: </param> 
    ' <param name="x_serie">Parametro 2: </param> 
    ' <param name="x_tipos_codtipodocumento">Parametro 3: </param> 
    ' <param name="x_almac_id">Parametro 4: </param> 
    ' <param name="x_pvent_id">Parametro 5: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtOrdenesXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean, ByVal x_pergenguia As Boolean) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtOrdenesXNumero(m_listVENT_DocsVenta, x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Busqueda de documentos de venta
    ' </summary>
    ' <param name="x_doc">tipo de docuento de venta</param>
    ' <param name="x_serie">serie del documento de venta</param>
    ' <param name="x_numero">numero del documento de venta</param>
    ' <param name="x_pvent_id">codigo del punto de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_todos">mostrar todos los registros</param>
    ' <param name="x_fecini">fecha de inicio de busqueda</param>
    ' <param name="x_fecfin">fecha de fin de busqueda</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function Busqueda(ByVal x_doc As String, ByVal x_serie As String, ByVal x_numero As String, ByVal x_pvent_id As Integer, ByVal x_almac_id As Short _
                           , ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
        Try
            Dim _where As New Hashtable()
            _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_doc, "m_vent_docsventa", "System.String", ACWhere.TipoWhere._Like))
            _where.Add("DOCVE_Serie", New ACWhere(x_serie, ACWhere.TipoWhere._Like))
            _where.Add("DOCVE_Numero", New ACWhere(x_numero, ACWhere.TipoWhere._Like))
            _where.Add("PVENT_Id", New ACWhere(x_pvent_id))
            _where.Add("DOCVE_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
            '_where.Add(ACWhere.OrderBy, New ACWhere(New ACOrderBy() {New ACOrderBy("DOCVE_Codigo", ACOrderBy.Ordenamiento.Ascendente)}))
            If Not x_todos Then _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado), ACWhere.TipoWhere.Igual))
            m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            Return d_generarguias.getCliente(m_listVENT_DocsVenta, _where, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' Atender pedido
    ' </summary>
    ' <param name="x_usuario">codigo del usuario</param>
    ' <param name="x_codigo">codigo del pedido</param>
    ' <param name="x_codrelacionado">codigo relacionado o de origen</param>
    ' <param name="x_pvent_idrelacionado">codigo del punto de venta origen o relacionado</param>
    ' <param name="x_almac_idrelacionado">codigo de almacen origen o relacionado</param>
    ' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
    ' <remarks></remarks>
    Public Function AtenderGuia(ByVal x_usuario As String, ByVal x_codigo As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim m_bdist_guias As New BDIST_GuiasRemision
            m_bdist_guias.DIST_GuiasRemision = New EDIST_GuiasRemision
            m_bdist_guias.DIST_GuiasRemision.Instanciar(ACEInstancia.Modificado)
            m_bdist_guias.DIST_GuiasRemision.GUIAR_Codigo = x_codigo
            m_bdist_guias.DIST_GuiasRemision.GUIAR_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Confirmado)
            'm_bdist_guias.DIST_GuiasRemision.PEDID_CodRelacionado = x_codrelacionado
            ' m_bdist_guias.DIST_GuiasRemision.PVENT_IdRelacionado = x_pvent_idrelacionado
            'm_bdist_guias.DIST_GuiasRemision.ALMAC_IdRelacionado = x_almac_idrelacionado
            If m_bdist_guias.Guardar(x_usuario) Then
                DAEnterprise.CommitTransaction()
                Return True
            Else
                Throw New Exception("No se puede completar el proceso de atender guia ")
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function


    ' <summary>
    ' Obtener el documento pendiente para generar su respectiva guai de remision
    ' </summary>
    ' <param name="x_cadena">cadena de busqueda</param>
    ' <param name="x_campo">campo de busqueda de la cadena</param>
    ' <param name="x_pvent_id">codigo del punto de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_todos">mostrar todos</param>
    ' <param name="x_fecini">fecha de inicio de busqeuda</param>
    ' <param name="x_fecfin">fecha de fin de busqueda</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getPendientes(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_pvent_id As Integer, ByVal x_almac_id As Short, ByVal x_todos As Boolean _
                         , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
        Try
            Dim _where As New Hashtable()

            If Not x_todos Then _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado), ACWhere.TipoWhere.Igual))
            _where.Add(x_campo, New ACWhere(x_cadena, "Cli", "System.String", ACWhere.TipoWhere._Like))
            _where.Add("DOCVE_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
            _where.Add("PVENT_Id", New ACWhere(x_pvent_id, ACWhere.TipoWhere.Diferente))
            m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            Return d_generarguias.getCliente(m_listVENT_DocsVenta, _where, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' busqueda de pendientes de entrega usando el numero del documento
    ' </summary>
    ' <param name="x_doc">tipo de docuemnto de vent</param>
    ' <param name="x_serie">serie del documento de busqueda</param>
    ' <param name="x_numero">numero del documento de busqueda</param>
    ' <param name="x_pvent_id">codigo del punto de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_todos">mostrar todos</param>
    ' <param name="x_fecini">fecha de inicio de busqeuda</param>
    ' <param name="x_fecfin">fecha de fin de busqueda</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getPendientes(ByVal x_doc As String, ByVal x_serie As String, ByVal x_numero As String, ByVal x_pvent_id As Integer, ByVal x_almac_id As Short _
                           , ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
        Try
            Dim _where As New Hashtable()
            _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_doc, "m_vent_docsventa", "System.String", ACWhere.TipoWhere._Like))
            _where.Add("DOCVE_Serie", New ACWhere(x_serie, ACWhere.TipoWhere._Like))
            _where.Add("DOCVE_Numero", New ACWhere(x_numero, ACWhere.TipoWhere._Like))
            _where.Add("PVENT_Id", New ACWhere(x_pvent_id))
            _where.Add("DOCVE_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
            '_where.Add(ACWhere.OrderBy, New ACWhere(New ACOrderBy() {New ACOrderBy("DOCVE_Codigo", ACOrderBy.Ordenamiento.Ascendente)}))
            If Not x_todos Then _where.Add("DOCVE_Estado", New ACWhere(EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado), ACWhere.TipoWhere.Igual))
            m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
            Return d_generarguias.getCliente(m_listVENT_DocsVenta, _where, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Obtener el numero correspondiente a la guia de remision
    ' </summary>
    ' <param name="x_serie">serie del documento para la busqueda del correlativo</param>
    ' <param name="x_tipos_codtipodocumento">tipo de documento de guia</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getNumero(ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String) As Integer
        Dim m_dgenerardocventa As New DGenerarGuias
        Try
            Return m_dgenerardocventa.getNumero(x_serie, x_tipos_codtipodocumento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' <summary>
    ' 'getSunat'
    ' </summary>
    ' <param name="x_guiarCodigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getSunat(ByVal x_guiarCodigo As String) As Boolean
        Dim m_dgenerardocventa As New DGenerarGuias
        Try
            'Dim _join As New List(Of ACJoin)
            Dim _where As New Hashtable()
            _where.Add("GUIAR_Codigo", New ACWhere(x_guiarCodigo, ACWhere.TipoWhere.Igual))
            _where.Add("generado", New ACWhere(2, ACWhere.TipoWhere.Igual))
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            Return m_dgenerardocventa.DIST_Sunat(m_listDIST_GuiasRemision, _where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' 
    ' </summary>
    ' <param name="x_serie"></param>
    ' <param name="x_tipos_codtipodocumento"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getPesoFleje(ByVal x_lote As String) As Decimal
        Dim m_dgenerardocventa As New DGenerarGuias
        Try
            Return m_dgenerardocventa.getPesoFleje(x_lote)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' Obtener el numero de lote General
    ' </summary>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getNumeroLote() As Integer
        Dim m_dgenerardocventa As New DGenerarGuias
        Try
            Return m_dgenerardocventa.getNumeroLote()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' Obtener el numero de lote transformacion externa
    ' </summary>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getNumeroLotetransExterna() As Integer
        Dim m_dgenerardocventa As New DGenerarGuias
        Try
            Return m_dgenerardocventa.getNumerolotetransExterna()
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' <summary>
    ' Obtener el peso
    ' </summary>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getNumeropeso(ByVal x_artic As String) As Double
        Dim m_dgenerardocventa As New DGenerarGuias
        Try
            Return m_dgenerardocventa.getNumeropeso(x_artic)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function getNumerolinea(ByVal x_artic As String) As String
        Dim m_dgenerardocventa As New DGenerarGuias
        Try
            Return m_dgenerardocventa.getNumerolinea(x_artic)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' <summary>
    ' cargar el documento de venta
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargar(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean,
                           ByVal x_estentrega As String) As Boolean
        Try
            Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If x_ordenes Then
                Dim m_dist_ordenes As New BDIST_Ordenes
                If m_dist_ordenes.ObtenerOrden(x_codigo, False) Then
                    m_vent_docsventa = New EVENT_DocsVenta()
                    m_vent_docsventa.DOCVE_Codigo = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo
                    m_vent_docsventa.ORDEN_Codigo = m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo
                    m_vent_docsventa.Codigo = m_dist_ordenes.DIST_Ordenes.Codigo
                    m_vent_docsventa.ENTID_CodigoCliente = m_dist_ordenes.DIST_Ordenes.ENTID_CodigoCliente
                    m_vent_docsventa.DOCVE_Serie = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(2, 4)
                    m_vent_docsventa.DOCVE_Numero = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(3, 7) '010130000015
                    m_vent_docsventa.DOCVE_DireccionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DireccionDestino
                    m_vent_docsventa.DOCVE_DescripcionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DescripcionCliente
                    m_vent_docsventa.DOCVE_FechaDocumento = m_dist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento
                    m_vent_docsventa.DOCVE_Observaciones = m_dist_ordenes.DIST_Ordenes.ORDEN_Observaciones
                    m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                    If ObtDetOrdenes(m_vent_docsventa.ListVENT_DocsVentaDetalle, m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo, 1) Then
                        Return True
                    Else
                        Return True
                    End If
                    Return False
                End If
            Else
                If m_bvent_docsventa.Cargar(x_codigo, False) Then
                    m_vent_docsventa = New EVENT_DocsVenta()
                    m_vent_docsventa = m_bvent_docsventa.VENT_DocsVenta
                    Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                    If x_opcion Then
                        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        If LOG_DIST_GUIASS_ObtDetDocVenta_obs(x_codigo, x_almac_id, x_estentrega) Then
                            Return True
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
                End If
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ' <summary>
    ' cargar el documento de venta
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargar(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean) As Boolean
        Try
            Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If x_ordenes Then
                Dim m_dist_ordenes As New BDIST_Ordenes
                If m_dist_ordenes.ObtenerOrden(x_codigo, False) Then
                    m_vent_docsventa = New EVENT_DocsVenta()
                    m_vent_docsventa.DOCVE_Codigo = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo
                    m_vent_docsventa.ORDEN_Codigo = m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo
                    m_vent_docsventa.Codigo = m_dist_ordenes.DIST_Ordenes.Codigo
                    m_vent_docsventa.ENTID_CodigoCliente = m_dist_ordenes.DIST_Ordenes.ENTID_CodigoCliente
                    m_vent_docsventa.DOCVE_Serie = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(2, 4)
                    m_vent_docsventa.DOCVE_Numero = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(3, 7) '010130000015
                    m_vent_docsventa.DOCVE_DireccionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DireccionDestino
                    m_vent_docsventa.DOCVE_DescripcionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DescripcionCliente
                    m_vent_docsventa.DOCVE_FechaDocumento = m_dist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento
                    m_vent_docsventa.DOCVE_Observaciones = m_dist_ordenes.DIST_Ordenes.ORDEN_Observaciones
                    m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                    If ObtDetOrdenes(m_vent_docsventa.ListVENT_DocsVentaDetalle, m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo, 1) Then
                        Return True
                    Else
                        Return True
                    End If
                    Return False
                End If
            Else
                If m_bvent_docsventa.Cargar(x_codigo, False) Then
                    m_vent_docsventa = New EVENT_DocsVenta()
                    m_vent_docsventa = m_bvent_docsventa.VENT_DocsVenta
                    Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                    If x_opcion Then
                        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        If LOG_DIST_GUIASS_ObtDetDocVenta(x_codigo, x_almac_id) Then
                            Return True
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
                End If
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' cargar el documento de venta
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargarPedido(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean) As Boolean
        Try
            Dim m_bvent_pedidos As New BVENT_Pedidos()
            'If x_ordenes Then
            '    Dim m_dist_ordenes As New BDIST_Ordenes
            '    If m_dist_ordenes.ObtenerOrden(x_codigo, False) Then
            '        m_vent_docsventa = New EVENT_DocsVenta()
            '        m_vent_docsventa.DOCVE_Codigo = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo
            '        m_vent_docsventa.ORDEN_Codigo = m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo
            '        m_vent_docsventa.Codigo = m_dist_ordenes.DIST_Ordenes.Codigo
            '        m_vent_docsventa.ENTID_CodigoCliente = m_dist_ordenes.DIST_Ordenes.ENTID_CodigoCliente
            '        m_vent_docsventa.DOCVE_Serie = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(2, 4)
            '        m_vent_docsventa.DOCVE_Numero = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(3, 7) '010130000015
            '        m_vent_docsventa.DOCVE_DireccionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DireccionDestino
            '        m_vent_docsventa.DOCVE_DescripcionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DescripcionCliente
            '        m_vent_docsventa.DOCVE_FechaDocumento = m_dist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento
            '        m_vent_docsventa.DOCVE_Observaciones = m_dist_ordenes.DIST_Ordenes.ORDEN_Observaciones
            '        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
            '        If ObtDetOrdenes(m_vent_docsventa.ListVENT_DocsVentaDetalle, m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo, 1) Then
            '            Return True
            '        Else
            '            Return True
            '        End If
            '        Return False
            '    End If
            'Else
            If m_bvent_pedidos.Cargar(x_codigo, False) Then
                m_vent_pedidos = New EVENT_Pedidos()
                m_vent_pedidos = m_bvent_pedidos.VENT_Pedidos
                Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                If x_opcion Then
                    m_vent_pedidos.ListDetPedidos = New List(Of EVENT_PedidosDetalle)
                    If LOG_DIST_GUIASS_ObtDetPedidos(x_codigo, x_almac_id) Then
                        Return True
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
                ' End If
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' <summary>
    ' cargar el documento de venta
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargaralmacen(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean) As Boolean
        Try
            Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If x_ordenes Then
                Dim m_dist_ordenes As New BDIST_Ordenes
                If m_dist_ordenes.ObtenerOrden(x_codigo, False) Then
                    m_vent_docsventa = New EVENT_DocsVenta()
                    m_vent_docsventa.DOCVE_Codigo = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo
                    m_vent_docsventa.ORDEN_Codigo = m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo
                    m_vent_docsventa.Codigo = m_dist_ordenes.DIST_Ordenes.Codigo
                    m_vent_docsventa.ENTID_CodigoCliente = m_dist_ordenes.DIST_Ordenes.ENTID_CodigoCliente
                    m_vent_docsventa.DOCVE_Serie = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(2, 4)
                    m_vent_docsventa.DOCVE_Numero = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(3, 7) '010130000015
                    m_vent_docsventa.DOCVE_DireccionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DireccionDestino
                    m_vent_docsventa.ORDEN_UbigeoDestino = m_dist_ordenes.DIST_Ordenes.ORDEN_UbigeoDestino
                    m_vent_docsventa.DOCVE_DescripcionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DescripcionCliente
                    m_vent_docsventa.DOCVE_FechaDocumento = m_dist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento
                    m_vent_docsventa.DOCVE_Observaciones = m_dist_ordenes.DIST_Ordenes.ORDEN_Observaciones
                    m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                    If ObtDetOrdenesalmacen(m_vent_docsventa.ListVENT_DocsVentaDetalle, m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo, 1) Then
                        Return True
                    Else
                        Return True
                    End If
                    Return False
                End If
            Else
                If m_bvent_docsventa.Cargar(x_codigo, False) Then
                    m_vent_docsventa = New EVENT_DocsVenta()
                    m_vent_docsventa = m_bvent_docsventa.VENT_DocsVenta
                    Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                    If x_opcion Then
                        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        If LOG_DIST_GUIASS_ObtDetDocVentaalmacen(x_codigo, x_almac_id) Then
                            Return True
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
                End If
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' <summary>
    ' cargar el documento de venta
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargaralmacenCot(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean) As Boolean
        Try
            Dim m_bvent_pedidos As New BVENT_Pedidos()

            If m_bvent_pedidos.Cargar(x_codigo, False) Then
                m_vent_pedidos = New EVENT_Pedidos()
                m_vent_pedidos = m_bvent_pedidos.VENT_Pedidos
                Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                If x_opcion Then
                    m_vent_pedidos.ListDetPedidos = New List(Of EVENT_PedidosDetalle)
                    If LOG_DIST_GUIASS_ObtDetDocVentaalmacen(x_codigo, x_almac_id) Then
                        Return True
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            End If
            Return False

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' cargar el documento de ordnes
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargarSoloorden(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean) As Boolean
        Try
            Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            m_bvent_docsventa.Cargar(x_codigo, False)
            m_vent_docsventa = New EVENT_DocsVenta()
            m_vent_docsventa = m_bvent_docsventa.VENT_DocsVenta

            If x_opcion Then
                m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                Return LOG_DIST_Ordenes_ObtDetguias(x_codigo, x_almac_id)
            Else
                Return True
            End If

            Return False

        Catch ex As Exception
            Throw ex
        End Try
    End Function





    ' <summary>
    ' cargar el documento de venta
    ' </summary>
    ' <param name="x_codigo">codigo del documento de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargarL(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean, ByVal x_estentrega As String) As Boolean
        Try
            Dim m_bvent_docsventa As New BVENT_DocsVenta(m_periodo, m_zonas_codigo, m_sucur_id)
            If x_ordenes Then
                Dim m_dist_ordenes As New BDIST_Ordenes
                If m_dist_ordenes.ObtenerOrden(x_codigo, False) Then
                    m_vent_docsventa = New EVENT_DocsVenta()
                    m_vent_docsventa.DOCVE_Codigo = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo
                    m_vent_docsventa.ORDEN_Codigo = m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo
                    m_vent_docsventa.Codigo = m_dist_ordenes.DIST_Ordenes.Codigo
                    m_vent_docsventa.ENTID_CodigoCliente = m_dist_ordenes.DIST_Ordenes.ENTID_CodigoCliente
                    m_vent_docsventa.DOCVE_Serie = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(2, 4)
                    m_vent_docsventa.DOCVE_Numero = m_dist_ordenes.DIST_Ordenes.DOCVE_Codigo.Substring(3, 7) '010130000015
                    m_vent_docsventa.DOCVE_DireccionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DireccionDestino
                    m_vent_docsventa.DOCVE_DescripcionCliente = m_dist_ordenes.DIST_Ordenes.ORDEN_DescripcionCliente
                    m_vent_docsventa.DOCVE_FechaDocumento = m_dist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento
                    m_vent_docsventa.DOCVE_Observaciones = m_dist_ordenes.DIST_Ordenes.ORDEN_Observaciones
                    m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                    If ObtDetOrdenes(m_vent_docsventa.ListVENT_DocsVentaDetalle, m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo, 1) Then
                        Return True
                    End If
                    Return False
                End If
            Else
                If m_bvent_docsventa.Cargar(x_codigo, False) Then
                    m_vent_docsventa = New EVENT_DocsVenta()
                    m_vent_docsventa = m_bvent_docsventa.VENT_DocsVenta
                    Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                    If x_opcion Then
                        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        ' Return LOG_DIST_GUIASS_ObtDetDocVenta(x_codigo, x_almac_id)
                        Return LOG_DIST_GUIASS_ObtDetDocVenta_obs(x_codigo, x_almac_id, x_estentrega)
                    Else
                        Return True
                    End If
                End If
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function






    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetDocVenta(ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDetDocVenta(m_vent_docsventa.ListVENT_DocsVentaDetalle, x_docve_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetPedidos(ByVal x_pedid_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_vent_pedidos.ListDetPedidos = New List(Of EVENT_PedidosDetalle)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDetPedidos(m_vent_pedidos.ListDetPedidos, x_pedid_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetDocVenta_obs(ByVal x_docve_codigo As String, ByVal x_almac_id As Short,
                                                       ByVal x_estentrega As String) As Boolean
        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDetDocVenta_obs(m_vent_docsventa.ListVENT_DocsVentaDetalle, x_docve_codigo, x_almac_id, x_estentrega)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetDocVentaalmacen(ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDetDocVentaalmacen(m_vent_docsventa.ListVENT_DocsVentaDetalle, x_docve_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_Ordenes_ObtDetguias
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DIST_Ordenes_ObtDetguias(ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generarguias.LOG_DIST_ORDENES_ObtDetGuias(m_vent_docsventa.ListVENT_DocsVentaDetalle, x_docve_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' cargar el detalle del documento, solo lo pendiente
    ' </summary>
    ' <param name="x_docve_codigo">codigo de venta</param>
    ' <param name="x_almac_id">codigo del almacen</param>
    ' <param name="x_opcion">opcion para cargar el detalle</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function cargarPendiente(ByVal x_docve_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean) As Boolean
        Try
            Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If m_bvent_docsventa.Cargar(x_docve_codigo, False) Then
                m_vent_docsventa = New EVENT_DocsVenta()
                m_vent_docsventa = m_bvent_docsventa.VENT_DocsVenta
                Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                If x_opcion Then
                    m_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                    Return LOG_DIST_GUIASS_ObtDetDocVenta(x_docve_codigo, x_almac_id)
                Else
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Guardar el campo de confirmacion de impresion de la guia de remision
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <remarks></remarks>
    Public Sub ImpresionGuia(ByVal x_usuario As String)
        Try
            Dim _bdist_guiasremision As New BDIST_GuiasRemision
            _bdist_guiasremision.DIST_GuiasRemision = New EDIST_GuiasRemision
            _bdist_guiasremision.DIST_GuiasRemision.GUIAR_Impresa = True
            '_bdist_guiasremision.DIST_GuiasRemision.GUIAR_Impresiones = _bdist_guiasremision.DIST_GuiasRemision.GUIAR_Impresiones + 1
            _bdist_guiasremision.DIST_GuiasRemision.GUIAR_Codigo = m_edist_guiasremision.GUIAR_Codigo
            _bdist_guiasremision.DIST_GuiasRemision.GUIAR_Salida = m_edist_guiasremision.GUIAR_Salida
            _bdist_guiasremision.DIST_GuiasRemision.GUIAR_StockDevuelto = m_edist_guiasremision.GUIAR_StockDevuelto
            _bdist_guiasremision.DIST_GuiasRemision.Instanciar(ACEInstancia.Modificado)
            _bdist_guiasremision.Guardar(x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ' <summary>
    ' 'getImpresiones'
    ' </summary>
    ' <param name="x_docveCodigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getImpresiones(ByVal x_guiarCodigo As String) As Boolean
        Try
            'Dim _join As New List(Of ACJoin)
            Dim _where As New Hashtable()
            _where.Add("GUIAR_Codigo", New ACWhere(x_guiarCodigo, ACWhere.TipoWhere.Igual))
            _where.Add("GUIAR_Impresiones", New ACWhere(1, ACWhere.TipoWhere.MayorIgual))
            m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
            Return d_generarguias.GUIAR_Impresiones(m_listDIST_GuiasRemision, _where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    '
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function ActualizarImpresion(ByVal x_usuario As String) As Boolean
        Try
            Dim _where As New Hashtable
            _where.Add("GUIAR_Codigo", New ACWhere(m_edist_guiasremision.GUIAR_Codigo))
            Dim _guia As New BDIST_GuiasRemision
            _guia.DIST_GuiasRemision = New EDIST_GuiasRemision()
            _guia.DIST_GuiasRemision.GUIAR_Codigo = m_edist_guiasremision.GUIAR_Codigo
            _guia.DIST_GuiasRemision.Instanciar(ACEInstancia.Modificado)
            _guia.DIST_GuiasRemision.GUIAR_Impresa = True
            _guia.DIST_GuiasRemision.GUIAR_Impresiones = _guia.getCorrelativo("GUIAR_Impresiones", _where)
            Return _guia.Guardar(x_usuario)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ' <summary>
    ' cargar las guia de venta
    ' </summary>
    ' <param name="x_guiar_codigo">codigo de la guia de remision</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getGuiaVenta(ByVal x_guiar_codigo As String) As Boolean
        Try
            Dim _bdist_guiasremision As New BDIST_GuiasRemision
            If _bdist_guiasremision.ObtenerGuiaVenta(x_guiar_codigo) Then
                m_edist_guiasremision = _bdist_guiasremision.DIST_GuiasRemision
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' obtener guias de traslado
    ' </summary>
    ' <param name="x_guiar_codigo">codigo de la guia de remision</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getGuiaTransf(ByVal x_guiar_codigo As String) As Boolean
        Try
            Dim _bdist_guiasremision As New BDIST_GuiasRemision
            If _bdist_guiasremision.ObtenerGuiaTransf(x_guiar_codigo) Then
                m_edist_guiasremision = _bdist_guiasremision.DIST_GuiasRemision
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' obtener guias de traslado
    ' </summary>
    ' <param name="x_guiar_codigo">codigo de la guia de remision</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function getGuiaCompra(ByVal x_guiar_codigo As String) As Boolean
        Try
            Dim _bdist_guiasremision As New BDIST_GuiasRemision
            If _bdist_guiasremision.ObtenerGuiaCompra(x_guiar_codigo) Then
                m_edist_guiasremision = _bdist_guiasremision.DIST_GuiasRemision
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetOrdenes
    ' </summary>
    ' <param name="x_orden_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtDetOrdenes(ByRef m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_orden_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_listvent_docsventadetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDetOrdenes(m_listvent_docsventadetalle, x_orden_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetOrdenes_obs
    ' </summary>
    ' <param name="x_orden_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtDetOrdenes_obs(ByRef m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_orden_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_listvent_docsventadetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDetOrdenes_obs(m_listvent_docsventadetalle, x_orden_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Capa de Negocio: LOG_DIST_GUIASS_ObtDetOrdenes
    ' </summary>
    ' <param name="x_orden_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtDetOrdenesalmacen(ByRef m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_orden_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_listvent_docsventadetalle = New List(Of EVENT_DocsVentaDetalle)
        Try
            Return d_generarguias.LOG_DIST_GUIASS_ObtDetOrdenesalmacen(m_listvent_docsventadetalle, x_orden_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' elimianr guia de remision
    ' </summary>
    ' <param name="x_guiar_codigo">codigo de guia de remision</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <param name="x_tipos_codtipodocumento">tipo de documento guia de remision</param>
    ' <param name="x_stockdevuelto">booleano para saber si esta guia mueve stock del kardex</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function EliminarGuia(ByVal x_guiar_codigo As String, ByVal x_usuario As String, ByVal x_tipos_codtipodocumento As String, ByVal x_stockdevuelto As Boolean) As Boolean
        Dim _where As New Hashtable
        Try
            _where.Add("GUIAR_Codigo", New ACWhere(x_guiar_codigo))

            DAEnterprise.BeginTransaction()

            Select Case x_tipos_codtipodocumento
                Case ETipos.getMotivoTraslado(ETipos.MotivoTraslado.Venta)
                    If x_stockdevuelto Then
                        Dim manejarstock As New ACBLogistica.BManejarStock
                        Dim _detguias As New BDIST_GuiasRemisionDetalle
                        If _detguias.CargarTodos(_where) Then
                            For Each item As EDIST_GuiasRemisionDetalle In _detguias.ListDIST_GuiasRemisionDetalle
                                manejarstock.EliminarMovimientoGuia(m_periodo, item.ARTIC_Codigo, m_almac_id,
                                                            x_guiar_codigo, item.GUIRD_Item, item.GUIRD_Cantidad, x_usuario)
                            Next
                        End If
                    End If
                Case ETipos.getMotivoTraslado(ETipos.MotivoTraslado.Traslado_Empresa)
                    Dim manejarstock As New ACBLogistica.BManejarStock
                    Dim _detguias As New BDIST_GuiasRemisionDetalle
                    If _detguias.CargarTodos(_where) Then
                        For Each item As EDIST_GuiasRemisionDetalle In _detguias.ListDIST_GuiasRemisionDetalle
                            manejarstock.EliminarMovimientoGuia(m_periodo, item.ARTIC_Codigo, m_almac_id,
                                                         x_guiar_codigo, item.GUIRD_Item, item.GUIRD_Cantidad, x_usuario)
                        Next
                    End If
            End Select

            Dim _guiasdet As New BDIST_GuiasRemisionDetalle
            _guiasdet.Eliminar(_where)

            Dim _guias As New BDIST_GuiasRemision
            _guias.Eliminar(_where)

            DAEnterprise.CommitTransaction()
            Return True

        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DISTSS_GuiasXDocumento
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_pvent_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function GuiasXFacturaOrden(ByVal x_docve_codigo As String, ByVal x_orden_codigo As String, ByVal x_pvent_id As Long, ByVal x_orden As Boolean) As Boolean
        m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
        Try
            If x_orden Then
                Return d_generarguias.LOG_DISTSS_GuiasXDocumentoOrden(m_listDIST_GuiasRemision, x_orden_codigo, x_pvent_id)
            Else
                Return d_generarguias.LOG_DISTSS_GuiasXDocumento(m_listDIST_GuiasRemision, x_docve_codigo, x_pvent_id)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DISTSS_GuiasXDocumento
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_pvent_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function GuiasXDocumento(ByVal x_docve_codigo As String, ByVal x_pvent_id As Long) As Boolean
        m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
        Try
            Return d_generarguias.LOG_DISTSS_GuiasXDocumento(m_listDIST_GuiasRemision, x_docve_codigo, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DISTSS_GuiasXDocumento
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_pvent_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function GuiasXDocumentoL(ByVal x_docve_codigo As String, ByVal x_almacen_id As Long) As Boolean
        m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
        Try
            Return d_generarguias.LOG_DISTSS_GuiasXDocumentoG(m_listDIST_GuiasRemision, x_docve_codigo, x_almacen_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DISTSS_GuiasXDocumentoOrden
    ' </summary>
    ' <param name="x_orden_codigo">Parametro 1: </param> 
    ' <param name="x_pvent_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DISTSS_GuiasXDocumentoOrden(ByVal x_orden_codigo As String, ByVal x_pvent_id As Long) As Boolean
        m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
        Try
            Return d_generarguias.LOG_DISTSS_GuiasXDocumentoOrden(m_listDIST_GuiasRemision, x_orden_codigo, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DISTSS_GuiasXOrdenControl
    ' </summary>
    ' <param name="x_orden_codigo">Parametro 1: </param> 
    ' <param name="x_pvent_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DISTSS_GuiasXOrden(ByVal x_orden_codigo As String, ByVal x_almac_id As Long) As Boolean
        m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
        Try
            Return d_generarguias.LOG_DISTSS_GuiasXOrden(m_listDIST_GuiasRemision, x_orden_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function





    ' <summary>
    ' Dar permiso al documento de venta para poder geenerar guia de remision
    ' </summary>
    ' <param name="x_codigo">codifo del documento de venta</param>
    ' <param name="x_value">valor verdadero o falso para el permiso</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <param name="x_docventa">clase documento de venta</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function SetPermisoGenGuia(ByVal x_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String, ByVal x_docventa As Boolean) As Boolean
        Try
            If x_docventa Then
                Dim _ventas As New BVENT_DocsVenta
                Return _ventas.SetPermisoGenGuia(x_codigo, x_value, x_usuario)
            Else
                Dim _ordenes As New BDIST_Ordenes
                Return _ordenes.SetPermisoGenGuia(x_codigo, x_value, x_usuario)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Dar permiso al documento para volver a imprimir
    ' </summary>
    ' <param name="x_codigo">codifo del documento de venta</param>
    ' <param name="x_value">valor verdadero o falso para el permiso</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function SetPermisoImpGuia(ByVal x_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try

            Dim _guia As New BDIST_GuiasRemision
            Return _guia.SetPermisoImpGuia(x_codigo, x_value, x_usuario)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Dar permiso al documento para volver a imprimir
    ' </summary>
    ' <param name="x_codigo">codifo del documento de venta</param>
    ' <param name="x_value">valor verdadero o falso para el permiso</param>
    ' <param name="x_usuario">codigo de usuario</param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function SetPermisoAnularGuia(ByVal x_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try

            Dim _guia As New BDIST_GuiasRemision
            Return _guia.SetPermisoAnularGuia(x_codigo, x_value, x_usuario)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class


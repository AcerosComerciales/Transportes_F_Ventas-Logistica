Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports DAConexion
Imports ACFramework
Imports ACBVentas
Imports ACEVentas

Public Class BAdministracionViajes

#Region " Variables "
   Private m_dtAdministracionViajes As DataTable

   Private m_dsAdministracionViajes As DataSet
   Private Shared d_administracionviajes As DAdministracionViajes = Nothing

   Private m_tran_cotizaciones As ETRAN_Cotizaciones
   Private m_tran_fletes As ETRAN_Fletes
   Private m_tran_viajes As ETRAN_Viajes

   Private m_vent_docsventa As EVENT_DocsVenta
   Private m_eteso_caja As ETESO_Caja

   Private m_listtran_fletes As List(Of ETRAN_Fletes)
   Private m_listtran_viajesneumaticos As List(Of ETRAN_ViajesNeumaticos)
   Private m_listtran_incidenciasviajes As List(Of ETRAN_IncidenciasViajes)
   Private m_listtran_combustibleconsumo As List(Of ETRAN_CombustibleConsumo)
   Private m_listtran_viajesgastos As List(Of ETRAN_ViajesGastos)
   Private m_listtran_viajesgastosRecibos As List(Of ETRAN_ViajesGastos)
   Private m_listTRAN_Recibos As List(Of ETRAN_Recibos)
   Private m_listtran_viajesguiasremision As List(Of ETRAN_ViajesGuiasRemision)
   Private m_listTRAN_ViajesVentas As List(Of ETRAN_ViajesVentas)

   Private m_tran_viajesgastos As ETRAN_ViajesGastos
   Private m_tran_viajesingresos As ETRAN_ViajesIngresos
   Private m_tran_neumaticosincidencias As ETRAN_NeumaticosIncidencias
   Private m_tran_ordenestransportes As ETRAN_OrdenesTransportes

   Private m_etran_combustibleconsumo As ETRAN_CombustibleConsumo

   Private m_zonas_codigo As String
   Private m_sucur_id As Integer
   Private m_pvent_id As Integer
    Private m_periodo As String
    Private m_comco_id As Long

    Private m_listTESO_Caja As List(Of ETESO_Caja)

#End Region

#Region " Constructores "
    Public Sub New(ByVal x_zona As String, ByVal x_sucursal As Integer, ByVal x_pvent_id As Integer, ByVal x_periodo As String)
        m_zonas_codigo = x_zona
        m_sucur_id = x_sucursal
        m_pvent_id = x_pvent_id
        m_periodo = x_periodo
        d_administracionviajes = New DAdministracionViajes
    End Sub
    Public Sub New()
        d_administracionviajes = New DAdministracionViajes
    End Sub
#End Region

#Region " Propiedades "
    Public Property TRAN_Viajes() As ETRAN_Viajes
      Get
         Return m_tran_viajes
      End Get
      Set(ByVal value As ETRAN_Viajes)
         m_tran_viajes = value
      End Set
   End Property

   Public Property TRAN_Cotizaciones() As ETRAN_Cotizaciones
      Get
         Return m_tran_cotizaciones
      End Get
      Set(ByVal value As ETRAN_Cotizaciones)
         m_tran_cotizaciones = value
      End Set
   End Property

   Public Property TRAN_ViajesGastos() As ETRAN_ViajesGastos
      Get
         Return m_tran_viajesgastos
      End Get
      Set(ByVal value As ETRAN_ViajesGastos)
         m_tran_viajesgastos = value
      End Set
   End Property

   Public Property ListTRAN_ViajesGastosRecibos() As List(Of ETRAN_ViajesGastos)
      Get
         Return m_listTRAN_ViajesGastosRecibos
      End Get
      Set(ByVal value As List(Of ETRAN_ViajesGastos))
         m_listTRAN_ViajesGastosRecibos = value
      End Set
   End Property

   Public Property TRAN_ViajesIngresos() As ETRAN_ViajesIngresos
      Get
         Return m_tran_viajesingresos
      End Get
      Set(ByVal value As ETRAN_ViajesIngresos)
         m_tran_viajesingresos = value
      End Set
   End Property

   Public Property TRAN_NeumaticosIncidencias() As ETRAN_NeumaticosIncidencias
      Get
         Return m_tran_neumaticosincidencias
      End Get
      Set(ByVal value As ETRAN_NeumaticosIncidencias)
         m_tran_neumaticosincidencias = value
      End Set
   End Property

   Public Property TRAN_OrdenesTransportes() As ETRAN_OrdenesTransportes
      Get
         Return m_tran_ordenestransportes
      End Get
      Set(ByVal value As ETRAN_OrdenesTransportes)
         m_tran_ordenestransportes = value
      End Set
   End Property

   Public Property TRAN_Fletes() As ETRAN_Fletes
      Get
         Return m_tran_fletes
      End Get
      Set(ByVal value As ETRAN_Fletes)
         m_tran_fletes = value
      End Set
   End Property

   Public Property TRAN_CombustibleConsumo() As ETRAN_CombustibleConsumo
      Get
         Return m_etran_combustibleconsumo
      End Get
      Set(ByVal value As ETRAN_CombustibleConsumo)
         m_etran_combustibleconsumo = value
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

   Public Property ListTRAN_Fletes() As List(Of ETRAN_Fletes)
      Get
         Return m_listtran_fletes
      End Get
      Set(ByVal value As List(Of ETRAN_Fletes))
         m_listtran_fletes = value
      End Set
   End Property

   Public Property ListTRAN_ViajesNeumaticos() As List(Of ETRAN_ViajesNeumaticos)
      Get
         Return m_listtran_viajesneumaticos
      End Get
      Set(ByVal value As List(Of ETRAN_ViajesNeumaticos))
         m_listtran_viajesneumaticos = value
      End Set
   End Property

   Public Property ListTRAN_IncidenciasViajes() As List(Of ETRAN_IncidenciasViajes)
      Get
         Return m_listtran_incidenciasviajes
      End Get
      Set(ByVal value As List(Of ETRAN_IncidenciasViajes))
         m_listtran_incidenciasviajes = value
      End Set
   End Property

   Public Property ListTRAN_CombustibleConsumo() As List(Of ETRAN_CombustibleConsumo)
      Get
         Return m_listtran_combustibleconsumo
      End Get
      Set(ByVal value As List(Of ETRAN_CombustibleConsumo))
         m_listtran_combustibleconsumo = value
      End Set
   End Property

   Public Property ListTRAN_ViajesGastos() As List(Of ETRAN_ViajesGastos)
      Get
         Return m_listtran_viajesgastos
      End Get
      Set(ByVal value As List(Of ETRAN_ViajesGastos))
         m_listtran_viajesgastos = value
      End Set
   End Property

   Public Property ListTRAN_Recibos() As List(Of ETRAN_Recibos)
      Get
         Return m_listTRAN_Recibos
      End Get
      Set(ByVal value As List(Of ETRAN_Recibos))
         m_listTRAN_Recibos = value
      End Set
   End Property

   Public Property ListTRAN_ViajesGuiasRemision() As List(Of ETRAN_ViajesGuiasRemision)
      Get
         Return m_listtran_viajesguiasremision
      End Get
      Set(ByVal value As List(Of ETRAN_ViajesGuiasRemision))
         m_listtran_viajesguiasremision = value
      End Set
   End Property

   Public Property ListTRAN_ViajesVentas As List(Of ETRAN_ViajesVentas)
      Get
         Return m_listTRAN_ViajesVentas
      End Get
      Set(ByVal value As List(Of ETRAN_ViajesVentas))
         m_listTRAN_ViajesVentas = value
      End Set
   End Property

   Public Property TESO_Caja() As ETESO_Caja
      Get
         Return m_eteso_caja
      End Get
      Set(ByVal value As ETESO_Caja)
         m_eteso_caja = value
      End Set
   End Property

   Public Property ListTESO_Caja() As List(Of ETESO_Caja)
      Get
         Return m_listTESO_Caja
      End Get
      Set(ByVal value As List(Of ETESO_Caja))
         m_listTESO_Caja = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
   Public Sub setTRAN_Cotizaciones(ByVal x_tran_cotizaciones As ETRAN_Cotizaciones)
      Me.m_tran_cotizaciones = x_tran_cotizaciones
   End Sub

   Public Sub setTRAN_Fletes(ByVal x_tran_fletes As ETRAN_Fletes)
      Me.m_tran_fletes = x_tran_fletes
   End Sub

    Public Sub setTRAN_Viajes(ByVal x_tran_viajes As ETRAN_Viajes)
        Me.m_tran_viajes = x_tran_viajes
    End Sub
    Public Sub setTRAN_CombustibleADblue(ByVal m_comco_id_ As Long)
        Me.m_comco_id = m_comco_id_
    End Sub
#End Region

#Region " Metodos "
#Region " Cotizaciones y Ordenes "
    Public Function GenerarRecepcionar(ByVal x_usuario As String, ByVal x_ano As String) As Boolean
      Try
         GenerarOrden(x_usuario, x_ano)

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GenerarOrden(ByVal x_usuario As String, ByVal x_ano As String) As Boolean
      Dim d_tran_cotizaciones As New DTRAN_Cotizaciones()
      Try
         DAEnterprise.BeginTransaction()
         '' Generar Orden
         Dim b_tran_ordentransporte As New BTRAN_OrdenesTransportes()
         b_tran_ordentransporte.TRAN_OrdenesTransportes = New ETRAN_OrdenesTransportes()
         b_tran_ordentransporte.TRAN_OrdenesTransportes.SUCUR_Id = m_tran_cotizaciones.SUCUR_Id
         b_tran_ordentransporte.TRAN_OrdenesTransportes.ZONAS_Codigo = m_tran_cotizaciones.ZONAS_Codigo
         b_tran_ordentransporte.TRAN_OrdenesTransportes.ENTID_Codigo = m_tran_cotizaciones.ENTID_Codigo
         b_tran_ordentransporte.TRAN_OrdenesTransportes.COTIZ_Codigo = m_tran_cotizaciones.COTIZ_Codigo
         b_tran_ordentransporte.TRAN_OrdenesTransportes.RUTAS_Id = m_tran_cotizaciones.RUTAS_Id
         b_tran_ordentransporte.TRAN_OrdenesTransportes.ORDTR_Monto = m_tran_cotizaciones.COTIZ_Monto
         b_tran_ordentransporte.TRAN_OrdenesTransportes.ORDTR_Carga = m_tran_cotizaciones.COTIZ_Carga
         b_tran_ordentransporte.TRAN_OrdenesTransportes.ORDTR_Estado = BConstantes.getEstado(BConstantes.Estados.Activo)
         b_tran_ordentransporte.TRAN_OrdenesTransportes.Instanciar(ACEInstancia.Nuevo)
         b_tran_ordentransporte.TRAN_OrdenesTransportes.ORDTR_Id = b_tran_ordentransporte.getCorrelativo("ORDTR_Id")
         '' Generar el codigo de la orden de transporte

         b_tran_ordentransporte.TRAN_OrdenesTransportes.ORDTR_Codigo = getCorrelativo(b_tran_ordentransporte.TRAN_OrdenesTransportes.ORDTR_Numero, m_tran_cotizaciones.ZONAS_Codigo, m_tran_cotizaciones.SUCUR_Id)
         '' Grabar la orden de transporte
         b_tran_ordentransporte.Guardar(x_usuario, New String() {"ORDTR_Fecha"})
         '' Actualizar el correlativo

         '' Cambia estado de Cotizacion
         m_tran_cotizaciones.COTIZ_Estado = ETRAN_Cotizaciones.getEstado(ETRAN_Cotizaciones.Estado.Recibido)
         d_tran_cotizaciones.TRAN_COTIZSU_UnReg(m_tran_cotizaciones, x_usuario)

         m_tran_ordenestransportes = b_tran_ordentransporte.TRAN_OrdenesTransportes
         '' Terminar la transacción
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function


   Private Function getCorrelativo(ByRef x_ordtr_numero As Integer, ByVal x_zonas_codigo As String _
                                   , ByVal x_sucur_codigo As Short) As String
      Try
         x_ordtr_numero = d_administracionviajes.getCorrelativo(x_zonas_codigo, x_sucur_codigo) + 1
         Return String.Format("{0}{1}{2}", "OR", x_sucur_codigo.ToString("000"), x_ordtr_numero.ToString("0000000"))
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GuardarCotizacion(ByVal x_usuario As String, ByVal x_ano As String) As Boolean
      Try
         Dim b_tran_cotizaciones As New BTRAN_Cotizaciones()
         m_tran_cotizaciones.TIPOS_CodTipoOrigen = ETipos.getTipo(ETipos.OrigenCotizacion.CViaje)
         b_tran_cotizaciones.TRAN_Cotizaciones = m_tran_cotizaciones
         Return b_tran_cotizaciones.Guardar(x_usuario, x_ano, True)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Fletes "

    ' <summary>
    ' Guardar fletes
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <param name="x_ano"></param>
    ' <param name="x_viaje_id"></param>
    ' <param name="x_detalle"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function GuardarFlete(ByVal x_usuario As String, ByVal x_ano As String _
                         , ByVal x_viaje_id As Long, ByVal x_detalle As Boolean) As Boolean
        Try
            Dim b_tran_fletes As New BTRAN_Fletes
            b_tran_fletes.setTRAN_Fletes(m_tran_fletes)
            If x_detalle Then
                If m_tran_fletes.Nuevo Then
                    Try
                        DAEnterprise.BeginTransaction()
                        Dim b_correlativos As New BCorrelativos()
                        ' Crear el Flete
                        '' Obtener correlativo
                        b_correlativos.GetCorrelativo(m_tran_fletes.SUCUR_Id, ECorrelativos.NTabla.TRAN_Fletes, x_ano)
                        m_tran_fletes.VIAJE_Id = x_viaje_id
                        m_tran_fletes.FLETE_Codigo = b_correlativos.Correlativos.Codigo
                        m_tran_fletes.FLETE_Estado = ETRAN_Fletes.getEstado(ETRAN_Fletes.Estados.Activo)
                        b_tran_fletes.setTRAN_Fletes(m_tran_fletes)
                        Dim b_tran_cotizaciones As New BTRAN_Cotizaciones
                        If b_tran_cotizaciones.Cargar(m_tran_fletes.COTIZ_Codigo, True) Then
                            m_tran_fletes.FLETE_MontoPorTM = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_MontoPorTM
                            m_tran_fletes.FLETE_PesoEnTM = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_PesoEnTM
                            m_tran_fletes.FLETE_NombreRuta = b_tran_cotizaciones.TRAN_Cotizaciones.RUTAS_Nombre
                            m_tran_fletes.TIPOS_CodTipoMoneda = b_tran_cotizaciones.TRAN_Cotizaciones.TIPOS_CodTipoMoneda
                            m_tran_fletes.FLETE_Glosa = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_Carga
                        End If
                        If b_tran_fletes.Guardar(x_usuario) Then
                            Dim _cotizacion As New BTRAN_Cotizaciones
                            _cotizacion.CambiarEstado(ETRAN_Cotizaciones.Estado.Confirmado, m_tran_fletes.COTIZ_Codigo)
                            '' Actualizar Correlativo
                            b_correlativos.Correlativos.ZONAS_Codigo = m_tran_fletes.ZONAS_Codigo
                            b_correlativos.SetCorrelativo(x_usuario)
                            '' Completar Transaccion
                            DAEnterprise.CommitTransaction()
                            Return True
                        Else
                            Throw New Exception("No se puede Generar el Flete")
                        End If
                    Catch ex As Exception
                        DAEnterprise.RollBackTransaction()
                        Throw ex
                    End Try
                End If
            Else
                Return b_tran_fletes.Guardar(x_usuario)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'actualizar el Flete con el Numero de Cotizacion amarrado x frank PIPIPIP 

    Public Function GuardarFleteXCotizacion(ByVal x_usuario As String, ByVal RUTAS_Nombre As String, ByVal x_cotiz_codigo As String _
                       , ByVal x_detalle As Boolean) As Boolean
        Try
            Dim b_tran_fletes As New BTRAN_Fletes
            Dim m_tran_flete = New ETRAN_Fletes
            Dim m_Btran_viaje As New BTRAN_Viajes
            Dim m_Etran_viaje As New ETRAN_Viajes
            'b_tran_fletes.setTRAN_Fletes(m_tran_flete)
            If x_detalle Then
                'If m_tran_fletes.Nuevo Then
                Try
                    DAEnterprise.BeginTransaction()

                    ' Crear el Flete
                    '' Obtener correlativo        

                    'b_tran_fletes.setTRAN_Fletes(m_tran_flete)
                    Dim b_tran_cotizaciones As New BTRAN_Cotizaciones
                    If b_tran_cotizaciones.Cargar(x_cotiz_codigo, True) Then
                        If b_tran_fletes.CargarXCotiz(x_cotiz_codigo) Then
                            b_tran_fletes.TRAN_Fletes.FLETE_DireccionPuntoDestino = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoDestino
                            b_tran_fletes.TRAN_Fletes.FLETE_DireccionPuntoOrigen = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_DireccionPuntoOrigen
                            b_tran_fletes.TRAN_Fletes.Ubigo_CodOrigen = b_tran_cotizaciones.TRAN_Cotizaciones.UBIGO_CodigoOrigen
                            b_tran_fletes.TRAN_Fletes.Ubigo_CodDestino = b_tran_cotizaciones.TRAN_Cotizaciones.UBIGO_CodigoDestino
                            b_tran_fletes.TRAN_Fletes.RUTAS_Nombre = RUTAS_Nombre
                            b_tran_fletes.TRAN_Fletes.RUTAS_Id = b_tran_cotizaciones.TRAN_Cotizaciones.RUTAS_Id
                            'm_Etran_viaje.VIAJE_Descripcion = m_tran_flete.FLETE_NombreRuta
                        End If
                    End If

                    If b_tran_fletes.GuardarFleteXCotizacion(x_usuario) Then
                        Dim _cotizacion As New BTRAN_Cotizaciones
                        _cotizacion.CambiarEstado(ETRAN_Cotizaciones.Estado.Confirmado, m_tran_flete.COTIZ_Codigo)
                        If m_Btran_viaje.Cargar(b_tran_fletes.TRAN_Fletes.VIAJE_Id) Then
                            '' ACTUALIZAR EL VIAJE SOLO LA DESCRIPCION  DE LA RUTA 
                            m_Etran_viaje.VIAJE_Descripcion = m_Btran_viaje.TRAN_Viajes.VIAJE_Descripcion.Substring(0, 30) + RUTAS_Nombre
                            If m_Btran_viaje.GuardarUno(x_usuario, True) Then

                            Else
                                Throw New Exception("NO SE PUDO ACTUALIZAR LA DERCIPCION DEL VIAJE")
                            End If
                        End If

                        '' Completar Transaccion
                        DAEnterprise.CommitTransaction()
                            Return True
                        Else
                            Throw New Exception("No se Actualizar el Flete papucho  :(pipip")
                    End If
                Catch ex As Exception
                    DAEnterprise.RollBackTransaction()
                    Throw ex
                End Try
                'End If
            Else
                Return b_tran_fletes.Guardar(x_usuario)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' <summary>
    ' Grabar Flete y Crear Viaje
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <param name="x_ano"></param>
    ' <param name="x_fleteInd"></param>
    ' <param name="x_detalle"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function GuardarFlete(ByVal x_usuario As String, ByVal x_ano As String _
                              , ByVal x_fleteInd As Boolean, ByVal x_detalle As Boolean _
                              , ByVal x_cviaje As Integer, ByRef x_viaje_id As Long, ByRef x_flete_id As Long, ByVal x_min As Boolean) As Boolean
        Try
            Dim b_tran_fletes As New BTRAN_Fletes
            b_tran_fletes.TRAN_Fletes = m_tran_fletes
            If x_detalle Then
                If m_tran_fletes.Nuevo Then
                    Try
                        DAEnterprise.BeginTransaction()
                        Dim b_correlativos As New BCorrelativos()
                        ' Crear el Viaje
                        Dim b_tran_viajes As New BTRAN_Viajes() With {.TRAN_Viajes = New ETRAN_Viajes()}
                        If Not x_fleteInd Then
                            '' Obtener correlativo
                            b_correlativos.GetCorrelativo(m_tran_fletes.SUCUR_Id, ECorrelativos.NTabla.TRAN_Viajes, x_ano)
                            b_correlativos.Correlativos.ZONAS_Codigo = BConstantes.ZONAS_Codigo
                            b_tran_viajes.TRAN_Viajes.VIAJE_Codigo = b_correlativos.Correlativos.Codigo
                            '' Asignar la ranfla que tiene asignado el vehiculo
                            Dim b_tran_vehiculosranflas As New BTRAN_VehiculosRanflas()
                            Dim _join As New List(Of ACJoin)()
                            _join.Add(New ACJoin(ETRAN_VehiculosConductores.Esquema, ETRAN_VehiculosConductores.Tabla, "VCon", ACJoin.TipoJoin.Inner _
                                          , New ACCampos() {New ACCampos("VEHIC_Id", "VEHIC_Id")}))
                            _join.Add(New ACJoin(ETRAN_Vehiculos.Esquema, ETRAN_Vehiculos.Tabla, "Veh", ACJoin.TipoJoin.Inner _
                                          , New ACCampos() {New ACCampos("VEHIC_Id", "VEHIC_Id")} _
                                          , New ACCampos() {New ACCampos("VEHIC_Placa", "VEHIC_Placa")}))
                            Dim _where As New Hashtable()
                            _where.Add("VHCON_Id", New ACWhere(m_tran_fletes.VHCON_Id, "VCon", "System.Int64", ACWhere.TipoWhere.Igual))
                            _where.Add("VEHRN_Estado", New ACWhere(BConstantes.getEstado(BConstantes.Estados.Activo), ACWhere.TipoWhere.Igual))
                            _where.Add("VHCON_Estado", New ACWhere(BConstantes.getEstado(BConstantes.Estados.Activo), "VCon", "System.String", ACWhere.TipoWhere.Igual))
                            b_tran_vehiculosranflas.TRAN_VehiculosRanflas = New ETRAN_VehiculosRanflas
                            Dim _vehic_id As Long : Dim _placa As String
                            If b_tran_vehiculosranflas.Cargar(_join, _where) Then
                                _placa = b_tran_vehiculosranflas.TRAN_VehiculosRanflas.VEHIC_Placa
                                _vehic_id = b_tran_vehiculosranflas.TRAN_VehiculosRanflas.VEHIC_Id
                                b_tran_viajes.TRAN_Viajes.VEHRN_Id = b_tran_vehiculosranflas.TRAN_VehiculosRanflas.VEHRN_Id
                            Else
                                Dim _btran_vehiculosconductores As New BTRAN_VehiculosConductores
                                Dim _joinVH As New List(Of ACJoin)()
                                _joinVH.Add(New ACJoin(ETRAN_Vehiculos.Esquema, ETRAN_Vehiculos.Tabla, "Veh", ACJoin.TipoJoin.Inner _
                                          , New ACCampos() {New ACCampos("VEHIC_Id", "VEHIC_Id")} _
                                          , New ACCampos() {New ACCampos("VEHIC_Placa", "VEHIC_Placa")}))
                                Dim _whereVH As New Hashtable()
                                _whereVH.Add("VHCON_Id", New ACWhere(m_tran_fletes.VHCON_Id))
                                _btran_vehiculosconductores.Cargar(_joinVH, _whereVH)
                                _vehic_id = _btran_vehiculosconductores.TRAN_VehiculosConductores.VEHIC_Id
                                _placa = _btran_vehiculosconductores.TRAN_VehiculosConductores.VEHIC_Placa
                            End If


                            '' Cargar los demas datos 
                            b_tran_viajes.TRAN_Viajes.SUCUR_Id = m_tran_fletes.SUCUR_Id
                            b_tran_viajes.TRAN_Viajes.ZONAS_Codigo = m_tran_fletes.ZONAS_Codigo
                            b_tran_viajes.TRAN_Viajes.VHCON_Id = m_tran_fletes.VHCON_Id
                            b_tran_viajes.TRAN_Viajes.VIAJE_Estado = BConstantes.getEstado(BConstantes.Estados.Activo)
                            b_tran_viajes.TRAN_Viajes.VIAJE_FecSalida = m_tran_fletes.FLETE_FecSalida
                            b_tran_viajes.TRAN_Viajes.VIAJE_FecLlegada = m_tran_fletes.FLETE_FecLlegada
                            b_tran_viajes.TRAN_Viajes.VIAJE_Presupuesto = New Xml.XmlDocument()
                            b_tran_viajes.TRAN_Viajes.VIAJE_IdxVehiculo = b_tran_viajes.CorrelativoXvehiculo(_vehic_id, False)
                            b_tran_viajes.TRAN_Viajes.PVENT_Id = m_pvent_id

                            Dim _b As New BTRAN_VehiculosConductores : _b.Cargar(m_tran_fletes.VHCON_Id)

                            b_tran_viajes.TRAN_Viajes.VIAJE_IdxConductor = x_cviaje ' b_tran_viajes.CorrelativoXconductor(_b.TRAN_VehiculosConductores.ENTID_Codigo)
                            b_tran_viajes.TRAN_Viajes.VIAJE_Descripcion = String.Format("Viaje {0} / {3} / {2} : {1} ", b_tran_viajes.TRAN_Viajes.VIAJE_IdxConductor.ToString("00000"), m_tran_fletes.FLETE_NombreRuta, _placa, m_tran_fletes.CONDU_Sigla)
                            b_tran_viajes.TRAN_Viajes.VIAJE_Id = b_tran_viajes.getCorrelativo()
                            x_viaje_id = b_tran_viajes.TRAN_Viajes.VIAJE_Id

                            b_tran_viajes.TRAN_Viajes.Instanciar(ACFramework.ACEInstancia.Nuevo)
                            '' Crear el Viaje
                            '---------------------------------------------------------CREAR EL VIAJES -------------------------------------------------------------
                            b_tran_viajes.Guardar(x_usuario)
                            m_tran_fletes.VIAJE_Id = b_tran_viajes.TRAN_Viajes.VIAJE_Id
                            '' Actualizar Correlativo
                            b_correlativos.SetCorrelativo(x_usuario)
                            '' Grabar Viajes y Vehiculos
                            Dim b_viajesvehiculos As New BTRAN_ViajesVehiculos
                            b_viajesvehiculos.TRAN_ViajesVehiculos = New ETRAN_ViajesVehiculos
                            b_viajesvehiculos.TRAN_ViajesVehiculos.VEHIC_Id = _vehic_id
                            b_viajesvehiculos.TRAN_ViajesVehiculos.VIAJE_Id = b_tran_viajes.TRAN_Viajes.VIAJE_Id
                            b_viajesvehiculos.TRAN_ViajesVehiculos.Instanciar(ACEInstancia.Nuevo)
                            '------------------------------------------------CREAR VEHICULO -----------------------------------------------------
                            b_viajesvehiculos.Guardar(x_usuario)

                            '' cambia el estado de viaje del vehiculo
                            Dim b_tran_vehiculo As New BTRAN_Vehiculos() With {.TRAN_Vehiculos = New ETRAN_Vehiculos()}
                            b_tran_vehiculo.TRAN_Vehiculos.VEHIC_EstadoViaje = BConstantes.getEstado(BConstantes.EstadosVehiculoViaje.Ocupado)
                            b_tran_vehiculo.TRAN_Vehiculos.VEHIC_Id = _vehic_id
                            b_tran_vehiculo.TRAN_Vehiculos.Instanciar(ACEInstancia.Modificado)
                            b_tran_vehiculo.Guardar(x_usuario)
                            '' Asignar los neumaticos al viaje


                            ' Cargar todos los Neumaticos del Vehiculo
                            Dim b_vehiculosneumaticos As New BTRAN_VehiculosNeumaticos
                            _where = New Hashtable()
                            _where.Add("VEHIC_Id", New ACWhere(_vehic_id, ACWhere.TipoWhere.Igual))
                            _where.Add("VNEUM_Estado", New ACWhere(BConstantes.getEstado(BConstantes.Estados.Activo), ACWhere.TipoWhere.Igual))
                            b_vehiculosneumaticos.CargarTodos(_where)

                            Dim b_tran_viajesneumaticos As New BTRAN_ViajesNeumaticos() With {.TRAN_ViajesNeumaticos = New ETRAN_ViajesNeumaticos()}
                            b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.SUCUR_Id = m_tran_fletes.SUCUR_Id
                            b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.ZONAS_Codigo = m_tran_fletes.ZONAS_Codigo
                            b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.VIAJE_Id = b_tran_viajes.TRAN_Viajes.VIAJE_Id
                            b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.Instanciar(ACEInstancia.Nuevo)
                            '' Crear cada registro en los neumaticos del vehiculo para el viaje
                            Dim i As Integer = 1
                            For Each Item As ETRAN_VehiculosNeumaticos In b_vehiculosneumaticos.ListTRAN_VehiculosNeumaticos
                                b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.NEUMA_Id = Item.NEUMA_Id
                                b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.NEUMF_Km = 0
                                b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.NEUMF_Id = i
                                b_tran_viajesneumaticos.Guardar(x_usuario)
                                i += 1
                            Next
                            '' Cargar todos los neumaticos de las ranflas
                            _where = New Hashtable()
                            _where.Add("RANFL_Id", New ACWhere(b_tran_vehiculosranflas.TRAN_VehiculosRanflas.RANFL_Id, ACWhere.TipoWhere.Igual))
                            _where.Add("VNEUM_Estado", New ACWhere(BConstantes.getEstado(BConstantes.Estados.Activo), ACWhere.TipoWhere.Igual))
                            b_vehiculosneumaticos.CargarTodos(_where)
                            '' Crear cada registro en los neumaticos de la ranflas para el viaje
                            For Each Item As ETRAN_VehiculosNeumaticos In b_vehiculosneumaticos.ListTRAN_VehiculosNeumaticos
                                b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.NEUMA_Id = Item.NEUMA_Id
                                b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.NEUMF_Km = 0
                                b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.NEUMF_Id = i
                                b_tran_viajesneumaticos.Guardar(x_usuario)
                                i += 1
                            Next

                        End If
                        ' Crear el Flete
                        '' Obtener correlativo
                        b_correlativos.GetCorrelativo(m_tran_fletes.SUCUR_Id, ECorrelativos.NTabla.TRAN_Fletes, x_ano)
                        m_tran_fletes.FLETE_Codigo = b_correlativos.Correlativos.Codigo
                        m_tran_fletes.FLETE_Estado = ETRAN_Fletes.getEstado(ETRAN_Fletes.Estados.Activo)
                        m_tran_fletes.FLETE_Id = b_tran_fletes.getCorrelativo()
                        x_flete_id = m_tran_fletes.FLETE_Id
                        '' 
                        Dim b_tran_cotizaciones As New BTRAN_Cotizaciones
                        If b_tran_cotizaciones.Cargar(m_tran_fletes.COTIZ_Codigo, True) Then
                            m_tran_fletes.FLETE_MontoPorTM = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_MontoPorTM
                            m_tran_fletes.FLETE_PesoEnTM = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_PesoEnTM
                            m_tran_fletes.FLETE_NombreRuta = b_tran_cotizaciones.TRAN_Cotizaciones.RUTAS_Nombre
                            m_tran_fletes.TIPOS_CodTipoMoneda = b_tran_cotizaciones.TRAN_Cotizaciones.TIPOS_CodTipoMoneda
                            m_tran_fletes.FLETE_Glosa = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_Carga
                            m_tran_fletes.FLETE_ImporteIgv = b_tran_cotizaciones.TRAN_Cotizaciones.COTIZ_ImporteIgv
                        End If
                        b_tran_cotizaciones.CambiarEstado(ETRAN_Cotizaciones.Estado.Confirmado, m_tran_fletes.COTIZ_Codigo)
                        b_tran_fletes.TRAN_Fletes = m_tran_fletes
                        If b_tran_fletes.Guardar(x_usuario) Then
                            '' Actualizar Correlativo
                            b_correlativos.Correlativos.ZONAS_Codigo = m_tran_fletes.ZONAS_Codigo
                            b_correlativos.SetCorrelativo(x_usuario)
                            '' Completar Transaccion
                            DAEnterprise.CommitTransaction()
                            Return True
                        Else
                            Throw New Exception("No se puede completar la operación de creación/grabado")
                        End If
                    Catch ex As Exception
                        DAEnterprise.RollBackTransaction()
                        Throw ex
                    End Try
                ElseIf m_tran_fletes.Modificado Then
                    'Return b_tran_fletes.Guardar(x_usuario)
                ElseIf m_tran_fletes.Eliminado Then
                    'Return b_tran_fletes.Guardar(x_usuario)
                End If
            Else
                Return b_tran_fletes.Guardar(x_usuario)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function CargarFletes(ByVal x_viaje_id As Long) As Boolean
    '   Try
    '      Dim b_tran_fletes As New BTRAN_Fletes
    '      Dim _join As New List(Of ACJoin)
    '      _join.Add(New ACJoin(ETRAN_Rutas.Esquema, ETRAN_Rutas.Tabla, ACJoin.TipoJoin.Inner _
    '                           , New ACCampos() {New ACCampos("RUTAS_Id", "RUTAS_Id")} _
    '                           , New ACCampos() {New ACCampos("RUTAS_Nombre", "RUTAS_Nombre")}))
    '      _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, ACJoin.TipoJoin.Inner _
    '                           , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
    '                           , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Nombres") _
    '                                            , New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
    '      _join.Add(New ACJoin(ETRAN_Cotizaciones.Esquema, ETRAN_Cotizaciones.Tabla, ACJoin.TipoJoin.Inner _
    '                           , New ACCampos() {New ACCampos("COTIZ_Codigo", "COTIZ_Codigo")} _
    '                           , New ACCampos() {New ACCampos("COTIZ_Carga", "COTIZ_Carga")}))
    '      Dim _where As New Hashtable()
    '      _where.Add("VIAJE_Id", New ACWhere(x_viaje_id, ACWhere.TipoWhere.Igual))
    '      b_tran_fletes.CargarTodos(_join, _where)
    '      m_listtran_fletes = New List(Of ETRAN_Fletes)(b_tran_fletes.ListTRAN_Fletes)
    '      Return m_listtran_fletes.Count > 0
    '   Catch ex As Exception
    '      Throw ex
    '   End Try
    'End Function


    ' <summary> 
    ' Capa de Negocio: TRAN_CAJASS_Fletes
    ' </summary>
    ' <param name="x_viaje_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function CargarFletes(ByVal x_viaje_id As Long) As Boolean
        m_listtran_fletes = New List(Of ETRAN_Fletes)
        Try
            Return d_administracionviajes.TRAN_CAJASS_Fletes(m_listtran_fletes, x_viaje_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function liquidarViaje(ByVal x_vehic_id As Long, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            '' Cambiar de estado al viaje
            Dim b_tran_viajes As New BTRAN_Viajes()
            b_tran_viajes.TRAN_Viajes = New ETRAN_Viajes()
            b_tran_viajes.TRAN_Viajes.VIAJE_Id = m_tran_viajes.VIAJE_Id
            b_tran_viajes.TRAN_Viajes.VIAJE_Estado = ETRAN_Viajes.getEstado(ETRAN_Viajes.EstadosViajes.Liquidado)
            b_tran_viajes.TRAN_Viajes.Instanciar(ACEInstancia.Modificado)
            b_tran_viajes.Guardar(x_usuario)
            '' Cambiar de estado al vehiculo
            Dim b_tran_vehiculos As New BTRAN_Vehiculos()
            b_tran_vehiculos.TRAN_Vehiculos = New ETRAN_Vehiculos()
            b_tran_vehiculos.TRAN_Vehiculos.VEHIC_Id = x_vehic_id
            b_tran_vehiculos.TRAN_Vehiculos.VEHIC_EstadoViaje = BConstantes.getEstado(BConstantes.EstadosVehiculoViaje.Disponible)
            b_tran_vehiculos.TRAN_Vehiculos.Instanciar(ACEInstancia.Modificado)
            b_tran_vehiculos.Guardar(x_usuario)
            '' Actualizar el kilometraje a los neumaticos
            Dim b_tran_viajesneumaticos As New BTRAN_ViajesNeumaticos()
            b_tran_viajesneumaticos.TRAN_ViajesNeumaticos = New ETRAN_ViajesNeumaticos()
            b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.Instanciar(ACEInstancia.Modificado)
            b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.NEUMF_Km = m_tran_viajes.VIAJE_KmTotal
            If IsNothing(m_listtran_viajesneumaticos) Then
                CargarNeumaticos(m_tran_viajes.VIAJE_Id)
            End If
            For Each Item As ETRAN_ViajesNeumaticos In m_listtran_viajesneumaticos
                b_tran_viajesneumaticos.TRAN_ViajesNeumaticos.NEUMF_Id = Item.NEUMF_Id
                b_tran_viajesneumaticos.Guardar(x_usuario)
            Next
            '' Grabar Guias de Remision
            cargarGuiaRemision(m_tran_viajes.VIAJE_Id)
            '' Terminar transacción
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function GrabarObsFlete(ByVal x_flete_id As Long, ByVal x_obs As String, ByVal x_usuario As String)
        Try
            Dim _flete As New BTRAN_Fletes
            _flete.TRAN_Fletes = New ETRAN_Fletes
            _flete.TRAN_Fletes.Instanciar(ACEInstancia.Modificado)
            _flete.TRAN_Fletes.FLETE_Id = x_flete_id
            _flete.TRAN_Fletes.FLETE_Observaciones = x_obs
            Return _flete.Guardar(x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Incidencias de Viajes "

    Public Function cargarIncidencias(ByVal x_viaje_id As Long) As Boolean
        Try
            Dim b_tran_incviajes As New BTRAN_IncidenciasViajes
            Dim _where As New Hashtable()
            _where.Add("VIAJE_Id", New ACWhere(x_viaje_id, ACWhere.TipoWhere.Igual))
            b_tran_incviajes.CargarTodos(_where)
            m_listtran_incidenciasviajes = New List(Of ETRAN_IncidenciasViajes)(b_tran_incviajes.ListTRAN_IncidenciasViajes)
            Return m_listtran_incidenciasviajes.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function eliminarIncidencia(ByVal x_inciv_id As Long) As Boolean
        Try
            Dim b_tran_incviajes As New BTRAN_IncidenciasViajes
            b_tran_incviajes.TRAN_IncidenciasViajes = New ETRAN_IncidenciasViajes()
            b_tran_incviajes.TRAN_IncidenciasViajes.INCIV_Id = x_inciv_id
            b_tran_incviajes.TRAN_IncidenciasViajes.Instanciar(ACEInstancia.Eliminado)
            Return b_tran_incviajes.Guardar("")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Consumo de Combustible "

    Public Function cargarConsCombustible(ByVal x_viaje_id As Long) As Boolean
        Try

            Dim b_tran_combustiblecomsumo As New BTRAN_CombustibleConsumo(m_pvent_id, m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
            '' Crear Inner Join Con otras Tablas
            If b_tran_combustiblecomsumo.ConsumoCombustible(x_viaje_id) Then
                m_listtran_combustibleconsumo = New List(Of ETRAN_CombustibleConsumo)(b_tran_combustiblecomsumo.ListTRAN_CombustibleConsumo)
                Return m_listtran_combustibleconsumo.Count > 0
            End If
            'Dim _join As New List(Of ACFramework.ACJoin)
            '_join.Add(New ACJoin("dbo", "Tipos", "TCom", ACJoin.TipoJoin.Inner _
            '                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoCombustible")} _
            '                   , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoCombustible")}))
            '_join.Add(New ACJoin("dbo", "Tipos", "TMPag", ACJoin.TipoJoin.Inner _
            '                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodModoPago")} _
            '                   , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_ModoPago")}))
            '_join.Add(New ACJoin("dbo", "Entidades", "Entid", ACJoin.TipoJoin.Inner _
            '                   , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")} _
            '                   , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
            '_join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Left _
            '                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
            '                   , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento") _
            '                                     , New ACCampos("TIPOS_DescCorta", "TIPOS_TipoDocCorta")}))
            '_join.Add(New ACJoin(ETRAN_Documentos.Esquema, ETRAN_Documentos.Tabla, "Doc", ACJoin.TipoJoin.Left _
            '                   , New ACCampos() {New ACCampos("DOCUS_Codigo", "DOCUS_Codigo"), New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")} _
            '                   , New ACCampos() {New ACCampos("DOCUS_Serie", "DOCUS_Serie") _
            '                                     , New ACCampos("DOCUS_Numero", "DOCUS_Numero") _
            '                                     , New ACCampos("TIPOS_CodTipoDocumento", "DOCUS_CodTipoDocumento")}))
            '_join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TipoDoc", "Doc", ACJoin.TipoJoin.Inner _
            '                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
            '                   , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento") _
            '                                     , New ACCampos("TIPOS_DescCorta", "CompTipoDocumento")}))
            'Dim b_tran_combustiblecomsumo As New BTRAN_CombustibleConsumo(m_zona, m_sucursal, m_pvent_id)
            'Dim _where As New Hashtable()
            '_where.Add("VIAJE_Id", New ACWhere(x_viaje_id, ACWhere.TipoWhere.Igual))
            'b_tran_combustiblecomsumo.CargarTodos(_join, _where)
            'm_listtran_combustibleconsumo = New List(Of ETRAN_CombustibleConsumo)(b_tran_combustiblecomsumo.ListTRAN_CombustibleConsumo)
            'Return m_listtran_combustibleconsumo.Count > 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' 'eliminar solo consumo combustible y de caja tambien
    ' </summary>
    ' <returns></returns>
    ' <remarks></remarks>
    ' 
    Public Function eliminarSoloConsCombustible() As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim b_tran_combustibleconsumo As New BTRAN_CombustibleConsumo(m_pvent_id, m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
            b_tran_combustibleconsumo.TRAN_CombustibleConsumo = New ETRAN_CombustibleConsumo()
            b_tran_combustibleconsumo.TRAN_CombustibleConsumo.COMCO_Id = m_etran_combustibleconsumo.COMCO_Id
            b_tran_combustibleconsumo.TRAN_CombustibleConsumo.Instanciar(ACEInstancia.Eliminado)
            If b_tran_combustibleconsumo.Guardar("") Then
                'Dim _where As New Hashtable
                '_where.Add("DOCUS_Codigo", New ACWhere(m_etran_combustibleconsumo.DOCUS_Codigo))
                '_where.Add("ENTID_Codigo", New ACWhere(m_etran_combustibleconsumo.ENTID_CodigoProveedor))
                'Dim _bdetalle As New BTRAN_DocumentosDetalle : _bdetalle.Eliminar(_where)
                'Dim _bcabecera As New BTRAN_Documentos : _bcabecera.Eliminar(_where)

                Dim _caja As New BTESO_Caja
                Dim _wherecaja As New Hashtable
                _wherecaja.Add("CAJA_Id", New ACWhere(m_etran_combustibleconsumo.CAJA_Id))
                _wherecaja.Add("PVENT_Id", New ACWhere(m_pvent_id))
                If _caja.Eliminar(_wherecaja) Then
                    Dim _recibo As New BTRAN_Recibos
                    Dim _whererecibos As New Hashtable
                    _whererecibos.Add("RECIB_Codigo", New ACWhere(m_etran_combustibleconsumo.RECIB_Codigo))
                    If _recibo.Eliminar(_whererecibos) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        Throw New Exception("No se puede Quitar los Pagos/Recibo")
                    End If
                Else
                    Throw New Exception("No se puede Quitar los Pagos/Recibo")
                End If
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function




    Public Function eliminarConsCombustible() As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim b_tran_combustibleconsumo As New BTRAN_CombustibleConsumo(m_pvent_id, m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
            b_tran_combustibleconsumo.TRAN_CombustibleConsumo = New ETRAN_CombustibleConsumo()
            b_tran_combustibleconsumo.TRAN_CombustibleConsumo.COMCO_Id = m_etran_combustibleconsumo.COMCO_Id
            b_tran_combustibleconsumo.TRAN_CombustibleConsumo.Instanciar(ACEInstancia.Eliminado)
            If b_tran_combustibleconsumo.Guardar("") Then
                Dim _where As New Hashtable
                _where.Add("DOCUS_Codigo", New ACWhere(m_etran_combustibleconsumo.DOCUS_Codigo))
                _where.Add("ENTID_Codigo", New ACWhere(m_etran_combustibleconsumo.ENTID_CodigoProveedor))
                Dim _bdetalle As New BTRAN_DocumentosDetalle : _bdetalle.Eliminar(_where)
                Dim _bcabecera As New BTRAN_Documentos : _bcabecera.Eliminar(_where)

                Dim _caja As New BTESO_Caja
                Dim _wherecaja As New Hashtable
                _wherecaja.Add("CAJA_Id", New ACWhere(m_etran_combustibleconsumo.CAJA_Id))
                _wherecaja.Add("PVENT_Id", New ACWhere(m_pvent_id))
                If _caja.Eliminar(_wherecaja) Then
                    Dim _recibo As New BTRAN_Recibos
                    Dim _whererecibos As New Hashtable
                    _whererecibos.Add("RECIB_Codigo", New ACWhere(m_etran_combustibleconsumo.RECIB_Codigo))
                    If _recibo.Eliminar(_whererecibos) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                    Else
                        Throw New Exception("No se puede Quitar los Pagos/Recibo")
                    End If
                Else
                    Throw New Exception("No se puede Quitar los Pagos/Recibo")
                End If
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function eliminarFlete(ByVal x_etran_viajesventas As ETRAN_ViajesVentas) As Boolean
        Try
            Dim _btran_viajesventas As New BTRAN_ViajesVentas
            Dim _where As New Hashtable
            _where.Add("VIAJE_Id", New ACWhere(x_etran_viajesventas.VIAJE_Id))
            _where.Add("DOCVE_Codigo", New ACWhere(x_etran_viajesventas.DOCVE_Codigo))
            _where.Add("FLETE_Id", New ACWhere(x_etran_viajesventas.FLETE_Id))
            Return _btran_viajesventas.Eliminar(_where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Consumo AdBlue"

    Public Function cargarConsumoAdBlue(ByVal x_viaje_id As Long) As Boolean
        Try

            Dim b_tran_combustiblecomsumo As New BTRAN_CombustibleConsumo(m_pvent_id, m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
            '' Crear Inner Join Con otras Tablas
            If b_tran_combustiblecomsumo.ConsumoAdBlue(x_viaje_id) Then
                m_listtran_combustibleconsumo = New List(Of ETRAN_CombustibleConsumo)(b_tran_combustiblecomsumo.ListTRAN_CombustibleConsumo)
                Return m_listtran_combustibleconsumo.Count > 0
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EliminarConsumoADBlue() As Boolean
        Try
            Dim b_tran_combustiblecomsumo As New BTRAN_CombustibleConsumo(m_pvent_id, m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
            Return b_tran_combustiblecomsumo.ELiminarConsumoADBLue(m_tran_viajes.VIAJE_Id, Me.m_comco_id)
        Catch ex As Exception

        End Try
    End Function
#End Region

#Region " Guias de Remision "
    'Public Function cargarGuiaRemision(ByVal x_viaje_id As Long) As Boolean
    '   Try
    '      '' Crear Inner Join Con otras Tablas
    '      Dim b_tran_viajesguiasremision As New BTRAN_ViajesGuiasRemision()
    '      Dim _where As New Hashtable()
    '      _where.Add("VIAJE_Id", New ACWhere(x_viaje_id, ACWhere.TipoWhere.Igual))
    '      If b_tran_viajesguiasremision.CargarTodos(_where) Then
    '         For Each item As ETRAN_ViajesGuiasRemision In b_tran_viajesguiasremision.ListTRAN_ViajesGuiasRemision
    '            item.Serie = item.GTRAN_Codigo.Substring(2, 3)
    '            item.Numero = item.GTRAN_Codigo.Substring(5, 7)
    '         Next
    '      End If
    '      m_listtran_viajesguiasremision = New List(Of ETRAN_ViajesGuiasRemision)(b_tran_viajesguiasremision.ListTRAN_ViajesGuiasRemision)
    '      Return m_listtran_viajesguiasremision.Count > 0
    '   Catch ex As Exception
    '      Throw ex
    '   End Try
    'End Function

    ' <summary> 
    ' Capa de Negocio: TRAN_CAJASS_GuiasViajes
    ' </summary>
    ' <param name="x_viaje_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function cargarGuiaRemision(ByVal x_viaje_id As Long) As Boolean
        m_listtran_viajesguiasremision = New List(Of ETRAN_ViajesGuiasRemision)
        Try
            If d_administracionviajes.TRAN_CAJASS_GuiasViajes(m_listtran_viajesguiasremision, x_viaje_id) Then
                For Each item As ETRAN_ViajesGuiasRemision In m_listtran_viajesguiasremision
                    If Len(item.GTRAN_Codigo) = 12 Then
                        item.Serie = item.GTRAN_Codigo.Substring(2, 3)
                        item.Numero = item.GTRAN_Codigo.Substring(5, 7)
                    Else
                        item.Serie = item.GTRAN_Codigo.Substring(2, 4)
                        item.Numero = item.GTRAN_Codigo.Substring(6, 7)
                    End If
                Next
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardarGuiaRemision(ByVal x_viaje_id As Long, ByVal x_usuario As String)
        Dim _where As New Hashtable()
        Try
            _where.Add("VIAJE_Id", New ACWhere(x_viaje_id))
            DAEnterprise.BeginTransaction()
            Dim _btran_viajesguiasremision As New BTRAN_ViajesGuiasRemision
            _btran_viajesguiasremision.Eliminar(_where)
            For Each item As ETRAN_ViajesGuiasRemision In m_listtran_viajesguiasremision
                item.VIAJE_Id = x_viaje_id
                If Len(item.Serie) = 3 Then
                    item.GTRAN_Codigo = String.Format("{0}{1}{2}", ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente).Substring(3), item.Serie.PadLeft(3, "0"), item.Numero.ToString("0000000"))
                Else
                    item.GTRAN_Codigo = String.Format("{0}{1}{2}", ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente).Substring(3), item.Serie.PadLeft(4, "0"), item.Numero.ToString("0000000"))
                End If
                ' item.GTRAN_Codigo = String.Format("{0}{1}{2}", ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente).Substring(3), item.Serie.PadLeft(3, "0"), item.Numero.ToString("0000000"))
                item.Instanciar(ACEInstancia.Nuevo)
                _btran_viajesguiasremision.TRAN_ViajesGuiasRemision = item
                _btran_viajesguiasremision.Guardar(x_usuario)
            Next
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function CambiarEstadoViaje(ByVal x_usuario As String, ByVal x_viaje_id As Long, ByVal x_tipo As ETRAN_Viajes.EstadosViajes)
        Try
            Dim _btran_viajes As New BTRAN_Viajes
            _btran_viajes.TRAN_Viajes = New ETRAN_Viajes
            _btran_viajes.TRAN_Viajes.Instanciar(ACEInstancia.Modificado)
            _btran_viajes.TRAN_Viajes.VIAJE_Estado = ETRAN_Viajes.getEstado(x_tipo)
            _btran_viajes.TRAN_Viajes.VIAJE_Id = x_viaje_id
            Return _btran_viajes.Guardar(x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Gastos de Viaje "
    Public Function cargarGastosViaje(ByVal x_viaje_id As Long) As Boolean
        Try
            Dim b_tran_viajesgastos As New BTRAN_ViajesGastos(m_pvent_id, m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
            b_tran_viajesgastos.GastosViajeVerificados(x_viaje_id)
            m_listtran_viajesgastos = New List(Of ETRAN_ViajesGastos)(b_tran_viajesgastos.ListTRAN_ViajesGastos)
            Return m_listtran_viajesgastos.Count > 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function eliminarGastoViaje() As Boolean
        Try
            DAEnterprise.BeginTransaction()
            '' Eliminar los Gastos de Viaje
            Dim b_tran_viajesgastos As New BTRAN_ViajesGastos(m_pvent_id, m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
            b_tran_viajesgastos.TRAN_ViajesGastos = New ETRAN_ViajesGastos()
            b_tran_viajesgastos.TRAN_ViajesGastos.VGAST_Id = m_tran_viajesgastos.VGAST_Id
            b_tran_viajesgastos.TRAN_ViajesGastos.VIAJE_Id = m_tran_viajesgastos.VIAJE_Id
            b_tran_viajesgastos.TRAN_ViajesGastos.Instanciar(ACEInstancia.Eliminado)

            Dim _recibo As New BTRAN_Recibos
            Dim _whererecibos As New Hashtable
            _whererecibos.Add("RECIB_Codigo", New ACWhere(m_tran_viajesgastos.RECIB_Codigo))
            _recibo.Eliminar(_whererecibos)

            If b_tran_viajesgastos.Guardar("") Then
                '' Eliminar Documento
                Dim b_tran_documentos As New BTRAN_Documentos
                If b_tran_documentos.EliminarDocumento(m_tran_viajesgastos.DOCUS_Codigo, m_tran_viajesgastos.ENTID_CodigoProveedor, False) Then

                End If
                Dim _caja As New BTESO_Caja
                Dim _where As New Hashtable
                _where.Add("CAJA_Id", New ACWhere(m_tran_viajesgastos.CAJA_Id))
                _where.Add("PVENT_Id", New ACWhere(m_pvent_id))
                If _caja.Eliminar(_where) Then
                    DAEnterprise.CommitTransaction()
                    Return True
                Else
                    Throw New Exception("No se puede Quitar los Pagos/Recibo")
                End If
                DAEnterprise.CommitTransaction()
                Return True
            Else
                Throw New Exception("No se puede Quitar los Pagos/Recibo")
            End If
            Return True

            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
#End Region

#Region " Incidencias de Neumaticos "
    Public Function eliminarIncidenciaNeumaticos() As Boolean
        Try
            DAEnterprise.BeginTransaction()
            '' Eliminar los Gastos de Viaje
            Dim b_tran_viajesgastos As New BTRAN_ViajesGastos(m_pvent_id, m_zonas_codigo, m_sucur_id, m_pvent_id, m_periodo)
            b_tran_viajesgastos.TRAN_ViajesGastos = New ETRAN_ViajesGastos
            b_tran_viajesgastos.TRAN_ViajesGastos.Instanciar(ACEInstancia.Eliminado)
            Dim _where As New Hashtable()
            _where.Add("DOCUS_Codigo", New ACWhere(m_tran_neumaticosincidencias.DOCUS_Codigo))
            _where.Add("ENTID_CodigoProveedor", New ACWhere(m_tran_neumaticosincidencias.ENTID_CodigoProveedor))
            b_tran_viajesgastos.Eliminar(_where)
            '' Eliminar Incidencias de neumatico
            Dim b_tran_neumaticosincidencias As New BTRAN_NeumaticosIncidencias
            b_tran_neumaticosincidencias.TRAN_NeumaticosIncidencias = New ETRAN_NeumaticosIncidencias()
            b_tran_neumaticosincidencias.TRAN_NeumaticosIncidencias.INCNU_Id = m_tran_neumaticosincidencias.INCNU_Id
            b_tran_neumaticosincidencias.TRAN_NeumaticosIncidencias.NEUMA_Id = m_tran_neumaticosincidencias.NEUMA_Id
            b_tran_neumaticosincidencias.TRAN_NeumaticosIncidencias.Instanciar(ACEInstancia.Eliminado)
            If b_tran_neumaticosincidencias.Guardar("") Then
                '' Eliminar Documento
                Dim b_tran_documentos As New BTRAN_Documentos
                If b_tran_documentos.EliminarDocumento(m_tran_neumaticosincidencias.DOCUS_Codigo, m_tran_neumaticosincidencias.ENTID_CodigoProveedor, False) Then
                    DAEnterprise.CommitTransaction()
                    Return True
                End If
                Return True
            End If
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
#End Region

#Region " Recibos "
    Public Function cargarRecibos(ByVal x_viaje_id As Long) As Boolean
        m_listTRAN_Recibos = New List(Of ETRAN_Recibos)
        Dim b_tran_recibos As New BTRAN_Recibos()
        Dim _where As New Hashtable()
        Try
            '_where.Add("VIAJE_Id", New ACWhere(x_viaje_id))
            Dim _btran_viajesgastos As New BTRAN_ViajesGastos
            If b_tran_recibos.CargarRecibos(x_viaje_id) Then
                m_listTRAN_Recibos = New List(Of ETRAN_Recibos)(b_tran_recibos.ListTRAN_Recibos)
                If _btran_viajesgastos.GenerarRecibos(x_viaje_id) Then
                    m_listtran_viajesgastosRecibos = New List(Of ETRAN_ViajesGastos)(_btran_viajesgastos.ListTRAN_ViajesGastos)
                End If
                Return m_listTRAN_Recibos.Count > 0
            Else
                m_listTRAN_Recibos = New List(Of ETRAN_Recibos)
                If _btran_viajesgastos.GenerarRecibos(x_viaje_id) Then
                    m_listtran_viajesgastosRecibos = New List(Of ETRAN_ViajesGastos)(_btran_viajesgastos.ListTRAN_ViajesGastos)
                Else
                    m_listtran_viajesgastosRecibos = New List(Of ETRAN_ViajesGastos)
                End If

            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function QuitarRecibos(ByVal x_caja_id As Integer, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _caja As New BTESO_Caja
            Dim _where As New Hashtable
            _where.Add("CAJA_Id", New ACWhere(x_caja_id))
            _where.Add("PVENT_Id", New ACWhere(m_pvent_id))
            If _caja.Eliminar(_where) Then
                Dim _recibo As New BTRAN_Recibos
                If _recibo.Eliminar(x_where) Then
                    DAEnterprise.CommitTransaction()
                    Return True
                Else
                    Throw New Exception("No se puede Quitar los Pagos/Recibo")
                End If
            Else
                Throw New Exception("No se puede Quitar los Pagos/Recibo")
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
#End Region

#Region " Facturación "
    Public Function cargarVentasFletes() As Boolean
        Dim _join As New List(Of ACJoin)
        Dim _where As New Hashtable
        Dim _btran_viajesventas As New BTRAN_ViajesVentas
        Try
            _join.Add(New ACJoin(ETRAN_Fletes.Esquema, ETRAN_Fletes.Tabla, "Fle", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("FLETE_Id", "FLETE_Id")} _
                              , New ACCampos() {New ACCampos("FLETE_TotIngreso", "FLETE_TotIngreso"),
                                                New ACCampos("FLETE_PesoEnTM", "FLETE_PesoEnTM"),
                                                New ACCampos("FLETE_ImporteIgv", "FLETE_ImporteIgv"),
                                                New ACCampos("FLETE_MontoPorTM", "FLETE_MontoPorTM"),
                                                New ACCampos("FLETE_FechaTransaccion", "FLETE_FechaTransaccion"),
                                                New ACCampos("FLETE_FecSalida", "FLETE_FecSalida"),
                                                New ACCampos("FLETE_FecSalida", "FLETE_FecLlegada"),
                                                New ACCampos("FLETE_Glosa", "FLETE_Glosa")}))

            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", "Fle", ACJoin.TipoJoin.Inner _
                     , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                     , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
            _join.Add(New ACJoin(ETRAN_Viajes.Esquema, ETRAN_Viajes.Tabla, "Via", "Fle", ACJoin.TipoJoin.Inner _
                     , New ACCampos() {New ACCampos("VIAJE_Id", "VIAJE_Id")} _
                     , New ACCampos() {New ACCampos("VIAJE_Descripcion", "VIAJE_Descripcion")}))

            _where.Add("DOCVE_Codigo", New ACWhere(m_vent_docsventa.DOCVE_Codigo))
            If _btran_viajesventas.CargarTodos(_join, _where) Then
                m_listTRAN_ViajesVentas = New List(Of ETRAN_ViajesVentas)(_btran_viajesventas.ListTRAN_ViajesVentas)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardarVentasFletes(ByVal x_usuario As String) As Boolean
        Dim _where As New Hashtable
        Dim _btran_viajesventas As New BTRAN_ViajesVentas
        Try
            DAEnterprise.BeginTransaction()

            _where.Add("DOCVE_Codigo", New ACWhere(m_vent_docsventa.DOCVE_Codigo))
            _btran_viajesventas.Eliminar(_where)

            For Each item As ETRAN_ViajesVentas In m_listTRAN_ViajesVentas
                item.Instanciar(ACEInstancia.Nuevo)
                _btran_viajesventas.TRAN_ViajesVentas = item
                _btran_viajesventas.Guardar(x_usuario)
            Next

            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
#End Region

#Region " Tesoreria: Gastos Iniciales de Viaje"
    ' <summary> 
    ' Procedimiento "TRAN_CAJASS_GastosViajeInicial" por el Generador 01/04/2012
    ' </summary> 
    ' <returns>Si no hay registros devuelve Falso</returns> 
    ' <remarks></remarks> 
    Public Function GastosViajeInicial() As Boolean
        m_listTESO_Caja = New List(Of ETESO_Caja)
        Try
            Return d_administracionviajes.TRAN_CAJASS_GastosViajeInicial(m_listTESO_Caja, m_tran_viajes.VIAJE_Id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function QuitarGasto(ByVal x_caja_id As Integer, ByVal x_recib_codigo As String, ByVal x_usuario As String)
        Try
            DAEnterprise.BeginTransaction()
            Dim _caja As New BTESO_Caja
            Dim _where As New Hashtable
            _where.Add("CAJA_Id", New ACWhere(x_caja_id))
            _where.Add("PVENT_Id", New ACWhere(m_pvent_id))
            If _caja.Eliminar(_where) Then
                Dim _recibo As New BTRAN_Recibos
                Dim _whererecibos As New Hashtable
                _whererecibos.Add("RECIB_Codigo", New ACWhere(x_recib_codigo))
                If _recibo.Eliminar(_whererecibos) Then
                    DAEnterprise.CommitTransaction()
                    Return True
                Else
                    Throw New Exception("No se puede Quitar los Pagos/Recibo")
                End If
            Else
                Throw New Exception("No se puede Quitar los Pagos/Recibo")
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    Public Function GenerarGasto(ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _caja As New BTESO_Caja
            Dim managerTRAN_Recibos As New BTRAN_Recibos
            managerTRAN_Recibos.TRAN_Recibos = New ETRAN_Recibos
            '' Cargar la serie del recibo

            _caja.TESO_Caja = m_eteso_caja
            _caja.TESO_Caja.CAJA_Estado = ETESO_Caja.getEstado(ETESO_Caja.Estado.Ingresado)
            _caja.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CGViajes)
            Dim _serie As String = "001" : Dim _numero As Integer
            If managerTRAN_Recibos.GetSeries(m_zonas_codigo, m_sucur_id, 0, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboTransporte)) Then
                _serie = managerTRAN_Recibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                _numero = managerTRAN_Recibos.getNumero(_serie, ETipos.getTipo(ETipos.TipoRecibo.Pendiente)) + 1
            Else
                _numero = 1
            End If
            managerTRAN_Recibos.TRAN_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", ETipos.getTipo(ETipos.TipoRecibo.Pendiente).Substring(3, 1).PadLeft(2, "0") _
                                                                                          , _serie, _numero)
            _caja.TESO_Caja.CAJA_NroDocumento = managerTRAN_Recibos.TRAN_Recibos.RECIB_Codigo
            _caja.TESO_Caja.CAJA_Serie = ACETransporte.Constantes.CAJA_SerieEgreso
            Dim _bgcancelacion As New BGCancelacion(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            _caja.TESO_Caja.CAJA_Numero = _bgcancelacion.getNroTransaccion(_caja.TESO_Caja.PVENT_Id, ACETransporte.Constantes.CAJA_SerieEgreso)
            _caja.TESO_Caja.CAJA_Codigo = String.Format("{0:00}{1}{2:0000000}", m_pvent_id, _caja.TESO_Caja.CAJA_Serie, _caja.TESO_Caja.CAJA_Numero)
            Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
            _caja.TESO_Caja.CAJA_Id = _caja.getCorrelativo("CAJA_Id", _whereCaja)

            If _caja.Guardar(x_usuario, New String() {"CAJA_Hora", "CAJA_FechaPago"}) Then
                managerTRAN_Recibos.TRAN_Recibos.Instanciar(ACEInstancia.Nuevo)
                managerTRAN_Recibos.TRAN_Recibos.RECIB_Concepto = _caja.TESO_Caja.CAJA_Glosa
                managerTRAN_Recibos.TRAN_Recibos.RECIB_Serie = _serie
                managerTRAN_Recibos.TRAN_Recibos.VIAJE_Id = m_tran_viajes.VIAJE_Id
                managerTRAN_Recibos.TRAN_Recibos.RECIB_Numero = _numero
                managerTRAN_Recibos.TRAN_Recibos.ZONAS_Codigo = m_zonas_codigo
                managerTRAN_Recibos.TRAN_Recibos.SUCUR_Id = m_sucur_id
                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoMoneda = _caja.TESO_Caja.TIPOS_CodTipoMoneda
                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.Pendiente)
                managerTRAN_Recibos.TRAN_Recibos.RECIB_Fecha = _caja.TESO_Caja.CAJA_Fecha
                managerTRAN_Recibos.TRAN_Recibos.RECIB_Monto = _caja.TESO_Caja.CAJA_Importe
                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTransaccion = _caja.TESO_Caja.TIPOS_CodTransaccion

                If managerTRAN_Recibos.Guardar(x_usuario) Then
                    DAEnterprise.CommitTransaction()
                    Return True
                Else
                    Throw New Exception("No se puede Guardar los recibos")
                End If
            Else
                Throw New Exception("No se puede Guardar la Caja")
            End If
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
#End Region

    Public Function getKmAnterior() As Decimal
        Try
            Return d_administracionviajes.getKmAnterior(m_tran_viajes.VIAJE_Id, m_tran_viajes.TRAN_ViajesVehiculos.VEHIC_Id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    ' <summary> 
    ' Capa de Negocio: TRAN_VIAJESS_ObtenerKMAnterior
    ' </summary>
    ' <param name="x_vehic_id">Parametro 1: </param> 
    ' <param name="x_viaje_idxvehiculo">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtenerKMAnterior(ByVal x_vehic_id As Long) As Decimal
        Dim m_tran_viajesvehiculos = New ETRAN_ViajesVehiculos
        Try
            If d_administracionviajes.TRAN_VIAJESS_ObtenerKMAnterior(m_tran_viajesvehiculos, x_vehic_id, m_tran_viajes.VIAJE_IdxVehiculo) Then
                Return m_tran_viajesvehiculos.VIAVE_KmAnterior
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarNeumaticos(ByVal x_viaje_id As Long) As Boolean
        Try
            Dim b_tran_viajesneumaticos As New BTRAN_ViajesNeumaticos
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(ETRAN_Neumaticos.Esquema, ETRAN_Neumaticos.Tabla, "Neu", ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("NEUMA_Id", "NEUMA_Id")} _
                                 , New ACCampos() {New ACCampos("NEUMA_Codigo", "NEUMA_Codigo") _
                                                   , New ACCampos("NEUMA_Modelo", "NEUMA_Modelo") _
                                                   , New ACCampos("NEUMA_KmVidaUtil", "KMVidaUtil") _
                                                   , New ACCampos("NEUMA_Tamano", "NEUMA_Tamano")}))
            _join.Add(New ACJoin(ETRAN_VehiculosNeumaticos.Esquema, ETRAN_VehiculosNeumaticos.Tabla, "VNeu", ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("NEUMA_Id", "NEUMA_Id")} _
                                 , New ACCampos() {New ACCampos("VNEUM_Lado", "VNEUM_Lado") _
                                                   , New ACCampos("VNEUM_Seccion", "VNEUM_Seccion") _
                                                   , New ACCampos("VNEUM_InternoExterno", "VNEUM_InternoExterno") _
                                                   , New ACCampos("VEHIC_Id", "VEHIC_Id") _
                                                   , New ACCampos("RANFL_Id", "RANFL_Id") _
                                                   , New ACCampos("VNEUM_OrdenPosicion", "VNEUM_OrdenPosicion")} _
                                 , New ACCampos() {New ACCampos("VNEUM_Estado", "A", "System.String")}))
            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TNeu", "Neu", ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoLlanta")} _
                                 , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoLlanta")}))
            _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TMar", "Neu", ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodMarca")} _
                                 , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_Marca")}))
            Dim _where As New Hashtable()
            _where.Add("VIAJE_Id", New ACWhere(x_viaje_id, ACWhere.TipoWhere.Igual))
            b_tran_viajesneumaticos.CargarTodos(_join, _where)

            m_listtran_viajesneumaticos = New List(Of ETRAN_ViajesNeumaticos)(b_tran_viajesneumaticos.ListTRAN_ViajesNeumaticos)

            Dim b_tran_incidenciasneumaticos As New BTRAN_NeumaticosIncidencias()
            b_tran_incidenciasneumaticos.CargarTodos(_where)
            'el problema aqui es que no hay ningun neumatico para regitrar en Transportes.TRAN_ViajesNeumaticos 
            For Each Item As ETRAN_ViajesNeumaticos In m_listtran_viajesneumaticos
                Dim _filter As New ACFiltrador(Of ETRAN_NeumaticosIncidencias)()
                _filter.ACFiltro = "NEUMA_Id=" & Item.NEUMA_Id.ToString()
                Item.ListTRAN_IncidenciasNeumaticos = New List(Of ETRAN_NeumaticosIncidencias)(_filter.ACFiltrar(b_tran_incidenciasneumaticos.ListTRAN_NeumaticosIncidencias))
            Next

            Return m_listtran_viajesneumaticos.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Public Function CargarNeumaticos(ByVal x_vehic_placa As String) As Boolean
    '    Try
    '        Dim b_tran_viajesneumaticos As New BTRAN_ViajesNeumaticos
    '        Dim _join As New List(Of ACJoin)
    '        _join.Add(New ACJoin(ETRAN_Neumaticos.Esquema, ETRAN_Neumaticos.Tabla, "Neu", ACJoin.TipoJoin.Inner _
    '                             , New ACCampos() {New ACCampos("NEUMA_Id", "NEUMA_Id")} _
    '                             , New ACCampos() {New ACCampos("NEUMA_Estado", "NEUMA_Estado")} _
    '                             , New ACCampos() {New ACCampos("NEUMA_Codigo", "NEUMA_Codigo") _
    '                                               , New ACCampos("NEUMA_Modelo", "NEUMA_Modelo") _
    '                                               , New ACCampos("NEUMA_Tamano", "NEUMA_Tamano")}))

    '        _join.Add(New ACJoin(ETRAN_VehiculosNeumaticos.Esquema, ETRAN_VehiculosNeumaticos.Tabla, "VNeu", ACJoin.TipoJoin.Inner _
    '                             , New ACCampos() {New ACCampos("NEUMA_Id", "NEUMA_Id")} _
    '                             , New ACCampos() {New ACCampos("VNEUM_Lado", "VNEUM_Lado") _
    '                                               , New ACCampos("VNEUM_Seccion", "VNEUM_Seccion") _
    '                                               , New ACCampos("VNEUM_InternoExterno", "VNEUM_InternoExterno") _
    '                                               , New ACCampos("VEHIC_Id", "VEHIC_Id") _
    '                                               , New ACCampos("RANFL_Id", "RANFL_Id") _
    '                                               , New ACCampos("VNEUM_OrdenPosicion", "VNEUM_OrdenPosicion")} _
    '                             , New ACCampos() {New ACCampos("VNEUM_Estado", "A", "System.String")}))
    '        _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TNeu", "Neu", ACJoin.TipoJoin.Inner _
    '                             , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoLlanta")} _
    '                             , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoLlanta")}))
    '        _join.Add(New ACJoin(ETRAN_VehiculosNeumaticos.Esquema, ETRAN_VehiculosNeumaticos.Tabla, "Veh", ACJoin.TipoJoin.Inner _
    '                             , New ACCampos() {New ACCampos("VEHIC_Id", "Correlativo")} _
    '                             , New ACCampos() {New ACCampos("VEHIC_Placa", "VEHIC_Placa")}))
    '        _join.Add(New ACJoin(ETRAN_Ranflas.Esquema, ETRAN_Ranflas.Tabla, "Ranfla", ACJoin.TipoJoin.Inner _
    '                             , New ACCampos() {New ACCampos("RANFL_Id", "RANFL_Id")} _
    '                             , New ACCampos() {New ACCampos("RANFL_Id", "RANFL_Id")}))
    '        Dim _where As New Hashtable()
    '        _where.Add("VEHIC_Placa", New ACWhere(x_vehic_placa, ACWhere.TipoWhere.Igual))
    '        b_tran_viajesneumaticos.CargarTodos(_join, _where)

    '        m_listtran_viajesneumaticos = New List(Of ETRAN_ViajesNeumaticos)(b_tran_viajesneumaticos.ListTRAN_ViajesNeumaticos)

    '        Dim b_tran_incidenciasneumaticos As New BTRAN_NeumaticosIncidencias()
    '        b_tran_incidenciasneumaticos.CargarTodos(_where)
    '        'el problema aqui es que no hay ningun neumatico para regitrar en Transportes.TRAN_ViajesNeumaticos 
    '        For Each Item As ETRAN_ViajesNeumaticos In m_listtran_viajesneumaticos
    '            Dim _filter As New ACFiltrador(Of ETRAN_NeumaticosIncidencias)()
    '            _filter.ACFiltro = "NEUMA_Id=" & Item.NEUMA_Id.ToString()
    '            Item.ListTRAN_IncidenciasNeumaticos = New List(Of ETRAN_NeumaticosIncidencias)(_filter.ACFiltrar(b_tran_incidenciasneumaticos.ListTRAN_NeumaticosIncidencias))
    '        Next

    '        Return m_listtran_viajesneumaticos.Count > 0
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


#End Region

End Class



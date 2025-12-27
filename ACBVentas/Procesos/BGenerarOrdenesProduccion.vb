Imports ACDVentas
Imports ACEVentas
Imports ACFramework
Imports DAConexion

Public Class BGenerarOrdenesProduccion


#Region " Variables "
   Private d_generarordenes As DGenerarOrdenesProduccion
    PRIVATE m_listVENT_DocsVentadET As EVENT_DocsVentaDetalle

   Private m_dist_ordenes As EABAS_OrdenesProduccion
   Private m_bvent_docsventa As New BVENT_DocsVenta
   Private m_puntoventaremoto As EPuntoVenta
    Private m_docs_venta As EVENT_DocsVenta
    
    Private m_listDIST_VENTADET As List(Of EVENT_DocsVentaDetalle)
   Private m_listVENT_DocsVenta As List(Of EVENT_DocsVenta)
   Private m_listDIST_Ordenes As List(Of EABAS_OrdenesProduccion)

    Public Property ListDIST_VentDetalle() As List(Of EVENT_DocsVentaDetalle)
        Get
            Return m_listDIST_VENTADET
        End Get
        Set(ByVal value As List(Of EVENT_DocsVentaDetalle))
            m_listDIST_VENTADET = value
        End Set
    End Property

   Private m_periodo As String
#End Region

#Region " Propiedades "

   Public Property DIST_Ordenes() As EABAS_OrdenesProduccion
      Get
         Return m_dist_ordenes
      End Get
      Set(ByVal value As EABAS_OrdenesProduccion)
         m_dist_ordenes = value
      End Set
   End Property

   Public ReadOnly Property VENT_DocsVenta() As EVENT_DocsVenta
      Get
         Return m_bvent_docsventa.VENT_DocsVenta
      End Get
   End Property

   Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
      Get
         Return m_listVENT_DocsVenta
      End Get
      Set(ByVal value As List(Of EVENT_DocsVenta))
         m_listVENT_DocsVenta = value
      End Set
   End Property

   Public Property ListDIST_Ordenes() As List(Of EABAS_OrdenesProduccion)
      Get
         Return m_listdist_ordenes
      End Get
      Set(ByVal value As List(Of EABAS_OrdenesProduccion))
         m_listdist_ordenes = value
      End Set
   End Property

   Public Property PuntoVentaRemoto() As EPuntoVenta
      Get
         Return m_puntoventaremoto
      End Get
      Set(ByVal value As EPuntoVenta)
         m_puntoventaremoto = value
      End Set
   End Property

#End Region

#Region " Constructores "

   ''' <summary>
   ''' constructor
   ''' </summary>
   ''' <param name="x_periodo"></param>
   ''' <remarks></remarks>
   Public Sub New(ByVal x_periodo As String)
      m_periodo = x_periodo
      d_generarordenes = New DGenerarOrdenesProduccion
        m_listVENT_DocsVentadET = New EVENT_DocsVentaDetalle()
        m_docs_venta= New EVENT_DocsVenta()
   End Sub
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Generar Orden de Ingreso, Generando Orden de Ingreso Local y Remota, asi como la actualización de los stocks
   ''' tanto local como remoto
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarOrdenIngresoActStock(ByVal x_usuario As String, ByVal x_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta, ByVal x_usuario_db As String, ByVal x_password_db As String) As Boolean
        Dim m_bdist_ordenes As New BABAS_OrdenesProduccion
        Dim _where As New Hashtable
        Dim _entidad As New BEntidades : Dim _cliente As New BClientes : Dim _roles As New BEntidadesRoles
        Dim _entgrabar As Boolean = False
        Try
            '' Verificar que la Factura no ha sido anulada
            Dim _factura As New BVENT_DocsVenta
            If _factura.Cargar(m_dist_ordenes.DOCVE_Codigo) Then
                If _factura.VENT_DocsVenta.DOCVE_Estado.Equals(Constantes.getEstado(Constantes.Estado.Anulado)) Then
                    Throw New Exception(String.Format("El documento {0} se encuentra anulado, Ud. no podra completar el proceso de Crear la Orden", _factura.VENT_DocsVenta.DOCVE_Codigo))
                End If
            End If
            '' Grabar en Remoto
            _where.Add("PVENT_Id", New ACWhere(m_dist_ordenes.PVENT_Id))
            _where.Add("TIPOS_CodTipoOrden", New ACWhere(m_dist_ordenes.TIPOS_CodTipoOrden))
            '' Completar Datos de la Orden
            m_dist_ordenes.ORDEN_Id = m_bdist_ordenes.getCorrelativo("ORDEN_Id", _where)
            m_dist_ordenes.ORDEN_Codigo = String.Format("{0}{1}{2:0000000}", m_dist_ordenes.TIPOS_CodTipoOrden.Substring(3, 1).PadLeft(2, "0"), m_dist_ordenes.ORDEN_Serie, m_dist_ordenes.ORDEN_Numero)
            m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            m_bdist_ordenes.DIST_Ordenes = m_dist_ordenes

            ''VERIFICAR CLIENTE SI EXISTE_A
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
                '' Verificar si el cliente existe en el servidor remoto

                If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then
                    _entgrabar = True
                    '' Establecer conexion con el servidor local para traer los datos del cliente, pra grabarlos en el servidor remoto
                    If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                        DAEnterprise.Instanciar("StrConn", True)
                        If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor Local")
                        If Not _cliente.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor Local")
                        If Not _roles.CargarTodos(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los roles que tiene el cliente Local")
                    Else
                        Throw New Exception("No se puede establecer conexion con el servidor local")
                    End If
                Else
                    If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                        DAEnterprise.Instanciar("StrConn", True)
                        If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor remoto")
                    End If
                End If

                '' Establecer conexion al servidor remoto para grabar los datos
                If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                    DAEnterprise.Instanciar("StrConn", True)
                    DAEnterprise.BeginTransaction()
                    '' Grabar los datos del cliente
                    If _entgrabar Then
                        _entidad.Entidades.Instanciar(ACEInstancia.Nuevo) : If Not _entidad.Guardar(x_usuario) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor Local")
                        _cliente.Clientes.Instanciar(ACEInstancia.Nuevo) : If Not _cliente.Guardar(x_usuario) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor Local")
                        For Each item As EEntidadesRoles In _roles.ListEntidadesRoles
                            _roles.EntidadesRoles = item
                            _roles.EntidadesRoles.Instanciar(ACEInstancia.Nuevo) : If Not _roles.Guardar(x_usuario) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor Local")
                        Next
                        DAEnterprise.CommitTransaction()
                    Else
                        _entidad.Entidades.Instanciar(ACEInstancia.Modificado) : If Not _entidad.Guardar(x_usuario) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor Local")
                        DAEnterprise.CommitTransaction()
                    End If
                End If
            End If


            '' Grabar en el servidor Local
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
                DAEnterprise.BeginTransaction()
                '----> Prueba de ordenes
                Dim cant As DOUBLE = 0
                m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
                If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
                    Dim i As Integer = 1

                    For Each item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                        If item.ORDET_Cantidad > 0 Then
                            Dim _detalle As New BABAS_OrdenesProduccionDetalle
                            _detalle.DIST_OrdenesDetalle = item
                            _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                            _detalle.DIST_OrdenesDetalle.ORDET_Item = i
                            _detalle.DIST_OrdenesDetalle.ORDET_Cantidad = item.ORDET_Cantidad
                            cant = item.ORDET_Cantidad
                            _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)

                            If LOG_DIST_GUIASS_ObtDetDocVenta_Artic(m_bvent_docsventa.VENT_DocsVenta, m_dist_ordenes.DOCVE_Codigo, m_dist_ordenes.ALMAC_Id, _detalle.DIST_OrdenesDetalle.ARTIC_Codigo) Then

                                For Each item_1 As EVENT_DocsVentaDetalle In ListDIST_VentDetalle.ToList()
                                    If cant > item_1.Diferencia Then
                                        Throw New Exception("Cantidad Desbordante de Producto " + _detalle.DIST_OrdenesDetalle.ARTIC_Descripcion)
                                    Else
                                        _detalle.Guardar(x_usuario)
                                    End If
                                Next
                            Else
                                Throw New Exception("Documento de venta sin saldo pendiente: " + m_dist_ordenes.Documento)
                            End If

                            '' Realizar el Ingreso a Stock
                            Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                            m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                            m_bmanejarstocks.LOG_Stocks.ORDEN_Codigo = item.ORDEN_Codigo
                            m_bmanejarstocks.LOG_Stocks.ORDET_Item = item.ORDET_Item
                            m_bmanejarstocks.Ingreso(m_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, m_bdist_ordenes.DIST_Ordenes.ALMAC_Id, item.ORDET_Cantidad, _
                                                     m_bdist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.IngresoOrden), x_usuario)
                        End If
                        i += 1
                    Next
                    DAEnterprise.CommitTransaction()

                End If
            End If

            '' Establecer conexion con el servidor remoto
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)

                '' Grabar la Orden remoto
                m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
                If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
                    Dim i As Integer = 1
                    For Each item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                        If item.ORDET_Cantidad > 0 Then
                            Dim _detalle As New BABAS_OrdenesProduccionDetalle
                            _detalle.DIST_OrdenesDetalle = item
                            _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                            _detalle.DIST_OrdenesDetalle.ORDET_Cantidad = item.ORDET_Cantidad
                            _detalle.DIST_OrdenesDetalle.ORDET_Item = i
                            _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)

                            _detalle.Guardar(x_usuario)

                            '' Realizar el egreso de Stock
                            Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                            m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                            m_bmanejarstocks.LOG_Stocks.ORDEN_Codigo = item.ORDEN_Codigo
                            m_bmanejarstocks.LOG_Stocks.ORDET_Item = item.ORDET_Item
                            m_bmanejarstocks.Egreso(m_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, x_pvremoto.ALMAC_Id, item.ORDET_Cantidad, _
                                             m_bdist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaOrden), x_usuario)
                        End If
                        i += 1
                    Next
                    DAEnterprise.CommitTransaction()
                Else
                    Throw New Exception("No se puede completar el proceso de grabar orden")
                End If

            Else
                Throw New Exception("No se puede eestablecer conexion con el servidor remoto")
            End If

            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
            End If
            Return True

        Catch ex As Exception
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
            End If
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
   End Function


     Public Function GrabarOrdenIngresoM(ByVal x_usuario As String, ByVal x_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta,
                                      ByVal x_usuario_db As String  ,ByVal x_password_db As String) As Boolean
      Try
          Dim _traerCliente As Boolean = False
         Dim _entidad As New BEntidades
         Dim _cliente As New BClientes
         Dim _roles As New BEntidadesRoles


         Dim m_bdist_ordenes As New BABAS_OrdenesProduccion
         m_bdist_ordenes.DIST_Ordenes = new EABAS_OrdenesProduccion()
         m_bdist_ordenes.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
            m_bdist_ordenes.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            m_bdist_ordenes.DIST_Ordenes.ORDEN_Observaciones=m_dist_ordenes.ORDEN_Observaciones
            m_bdist_ordenes.DIST_Ordenes.ORDEN_PesoTotal  = m_dist_ordenes.ORDEN_PesoTotal
        DAEnterprise.BeginTransaction()
         If m_bdist_ordenes.Guardar(x_usuario) Then
            
            Dim i As Integer = 1
                Dim _detalle As New BABAS_OrdenesProduccionDetalle
                Dim _whereEli As New Hashtable
               _whereEli.Add("ORDEN_Codigo", New ACWhere(m_bdist_ordenes.DIST_Ordenes.ORDEN_Codigo))
               _detalle.Eliminar(_whereEli)
               
                   
            For Each item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
               _detalle.DIST_OrdenesDetalle = item
               _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
               _detalle.DIST_OrdenesDetalle.ORDET_orden=i
               _detalle.DIST_OrdenesDetalle.ORDET_Item = i
               _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)
               _detalle.Guardar(x_usuario)
               i += 1
            Next
            DAEnterprise.CommitTransaction()
            
         Else
            Throw New Exception("No se puede completar el proceso de grabar orden de produccion")
         End If

       '''grabar en el servidor remoto
         
         If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then
            _traerCliente = True
         End If
         If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
            '' Traer Cliente
            If _traerCliente Then
               _entidad = New BEntidades
               If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor remoto")
               If Not _cliente.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor remoto")
               If Not _roles.CargarTodos(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los roles que tiene el cliente")
            End If
            '' Cambiar estado a Orden generada
            
            m_bdist_ordenes.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            If m_bdist_ordenes.Guardar(x_usuario) Then
                    Dim i As Integer = 1
                         Dim _detalle As New BABAS_OrdenesProduccionDetalle
                        Dim _whereEli As New Hashtable
                       _whereEli.Add("ORDEN_Codigo", New ACWhere(m_bdist_ordenes.DIST_Ordenes.ORDEN_Codigo))
                        _detalle.Eliminar(_whereEli)
                          
                         For Each item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                              _detalle.DIST_OrdenesDetalle = item
                               _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                               _detalle.DIST_OrdenesDetalle.ORDET_Item = i
                               _detalle.DIST_OrdenesDetalle.ORDET_orden = i
                               _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)
                              _detalle.Guardar(x_usuario)
                               i += 1
                         Next
                    DAEnterprise.CommitTransaction()
                   
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
               Return True
            Else
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
               Throw New Exception("No se puede Atender la Orden en el Punto de venta Remoto")
            End If
         Else
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
            Throw New Exception("No se puede establecer conexión")
         End If

            

      Catch ex As Exception
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

     Public Function GrabarOrdenIngresoSinStock(ByVal x_usuario As String, ByVal x_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta,
                                      ByVal x_usuario_db As String  ,ByVal x_password_db As String) As Boolean
      Try
          Dim _traerCliente As Boolean = False
         Dim _entidad As New BEntidades
         Dim _cliente As New BClientes
         Dim _roles As New BEntidadesRoles


         Dim m_bdist_ordenes As New BABAS_OrdenesProduccion
         m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
         m_bdist_ordenes.DIST_Ordenes = m_dist_ordenes
         DAEnterprise.BeginTransaction()
         If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
         
                Dim i As Integer = 1
            For Each item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                
                Dim _detalle As New BABAS_OrdenesProduccionDetalle
               _detalle.DIST_OrdenesDetalle = item
               _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
               _detalle.DIST_OrdenesDetalle.ORDET_orden=i
               _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)
               _detalle.Guardar(x_usuario)
               

                'Dim _stocks As New ACBLogistica.BManejarStock
                '_stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                '_stocks.LOG_Stocks.ORDEN_CodigoProduccion = Item.ORDEN_Codigo
                '_stocks.LOG_Stocks.ORDET_ItemProduccion = i
                '_stocks.LOG_Stocks.STOCK_Lote = Item.ORDET_Lote
                '_stocks.Ingresopro(m_periodo, Item.ARTIC_Codigo, m_bdist_ordenes.getTipoUnidadMedida(Item.ARTIC_Codigo), m_bdist_ordenes.DIST_Ordenes.ALMAC_Id, Item.ORDET_Cantidad, _
                'm_bdist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.IngresoOrdenProduccion), x_usuario, _
                '_stocks.LOG_Stocks.ORDEN_CodigoProduccion,_stocks.LOG_Stocks.ORDET_ItemProduccion)
                'i += 1
            Next
                 
                'sale del stock de produccion el fleje
                i=1
                    'For Each Item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle.Where(Function(p) p.ORDET_Item >=1)
                    '          Dim _stocks As New ACBLogistica.BManejarStock
                    '          _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                    '          _stocks.LOG_Stocks.ORDEN_CodigoProduccion = Item.ORDEN_Codigo
                    '          _stocks.LOG_Stocks.ORDET_ItemProduccion = Item.ORDET_orden
                    '          _stocks.LOG_Stocks.TIPOS_CodTipoUnidad=Item.TIPOS_CodUnidadMedida
                    '          _stocks.LOG_Stocks.STOCK_Lote = Item.ORDET_Lote
                    '          _STOCKS.LOG_Stocks.STOCK_LoteGeneral=Item.ORDET_LoteGeneral
                    '          _stocks.Egresopro(m_periodo, Item.ARTIC_Codigo,  m_bdist_ordenes.getTipoUnidadMedida(Item.ARTIC_Codigo), x_pvlocal.ALMAC_Id, Item.ORDET_Cantidad, _
                    '          m_bdist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaOrdenProduccion), x_usuario, _
                    '          _stocks.LOG_Stocks.ORDEN_CodigoProduccion,_stocks.LOG_Stocks.ORDET_ItemProduccion )                                                  
                    '          i += 1
                    'Next               
              
                  'dim  m_actualizarped = New BABAS_OrdenesProduccion
                  '      m_actualizarped.DIST_Ordenes= New EABAS_OrdenesProduccion()
                  '      m_actualizarped.DIST_Ordenes.ORDEN_Codigo=m_dist_ordenes.ORDEN_CodReferencia
                  '      m_actualizarped.DIST_Ordenes.ORDEN_Estado="T"
                  '      m_actualizarped.DIST_Ordenes.ORDEN_Impresa=True
                  '      m_actualizarped.DIST_Ordenes.ORDEN_Atendido=True
                  '      m_actualizarped.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
                  '      m_actualizarped.Guardar(x_usuario)
                        DAEnterprise.CommitTransaction()
            
         Else
            Throw New Exception("No se puede completar el proceso de grabar orden de produccion")
         End If

       '''grabar en el servidor remoto
         
         If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then
            _traerCliente = True
         End If
         If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
            '' Traer Cliente
            If _traerCliente Then
               _entidad = New BEntidades
               If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor remoto")
               If Not _cliente.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor remoto")
               If Not _roles.CargarTodos(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los roles que tiene el cliente")
            End If
            '' Cambiar estado a Orden generada
            DAEnterprise.BeginTransaction()

            m_bdist_ordenes.DIST_Ordenes.ORDEN_Atendido = True
            m_bdist_ordenes.DIST_Ordenes.ORDEN_Impresa = False
            m_bdist_ordenes.DIST_Ordenes.PVENT_Id=x_pvremoto.PVENT_Id
            m_bdist_ordenes.DIST_Ordenes.ALMAC_Id=x_pvremoto.ALMAC_Id
            m_bdist_ordenes.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            m_bdist_ordenes.DIST_Ordenes.Instanciar(ACEInstancia.Nuevo)
            If m_bdist_ordenes.Guardar(x_usuario) Then
                    
                 
                    Dim i As Integer = 1
                         For Each item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                              
                                Dim _detalle As New BABAS_OrdenesProduccionDetalle
                               _detalle.DIST_OrdenesDetalle = item
                               _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                               _detalle.DIST_OrdenesDetalle.ORDET_orden = i
                                _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)
                              _detalle.Guardar(x_usuario)
                               i += 1
                         Next
                    DAEnterprise.CommitTransaction()
                   
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
               Return True
            Else
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
               Throw New Exception("No se puede Atender la Orden en el Punto de venta Remoto")
            End If
         Else
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
            Throw New Exception("No se puede establecer conexión")
         End If

            

      Catch ex As Exception
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function




   ''' <summary>
   ''' Grabar Orden de Ingreso
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarOrdenIngreso(ByVal x_usuario As String, ByVal x_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta,
                                      ByVal x_usuario_db As String  ,ByVal x_password_db As String) As Boolean
      Try
          Dim _traerCliente As Boolean = False
         Dim _entidad As New BEntidades
         Dim _cliente As New BClientes
         Dim _roles As New BEntidadesRoles


         Dim m_bdist_ordenes As New BABAS_OrdenesProduccion
         m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
         m_bdist_ordenes.DIST_Ordenes = m_dist_ordenes
         DAEnterprise.BeginTransaction()
         If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
         
                Dim i As Integer = 1
            For Each item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                
                Dim _detalle As New BABAS_OrdenesProduccionDetalle
               _detalle.DIST_OrdenesDetalle = item
               _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
               _detalle.DIST_OrdenesDetalle.ORDET_orden=i
               _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)
               _detalle.Guardar(x_usuario)
               

                'Dim _stocks As New ACBLogistica.BManejarStock
                '_stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                '_stocks.LOG_Stocks.ORDEN_CodigoProduccion = Item.ORDEN_Codigo
                '_stocks.LOG_Stocks.ORDET_ItemProduccion = i
                '_stocks.LOG_Stocks.STOCK_Lote = Item.ORDET_Lote
                '_stocks.Ingresopro(m_periodo, Item.ARTIC_Codigo, m_bdist_ordenes.getTipoUnidadMedida(Item.ARTIC_Codigo), m_bdist_ordenes.DIST_Ordenes.ALMAC_Id, Item.ORDET_Cantidad, _
                'm_bdist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.IngresoOrdenProduccion), x_usuario, _
                '_stocks.LOG_Stocks.ORDEN_CodigoProduccion,_stocks.LOG_Stocks.ORDET_ItemProduccion)
                i += 1
            Next
                 
                'sale del stock de produccion el fleje
                i=1
                    For Each Item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle.Where(Function(p) p.ORDET_Item >=1)
                              Dim _stocks As New ACBLogistica.BManejarStock
                              _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                              _stocks.LOG_Stocks.ORDEN_CodigoProduccion = Item.ORDEN_Codigo
                              _stocks.LOG_Stocks.ORDET_ItemProduccion = Item.ORDET_orden
                              _stocks.LOG_Stocks.TIPOS_CodTipoUnidad=Item.TIPOS_CodUnidadMedida
                              _stocks.LOG_Stocks.STOCK_Lote = Item.ORDET_Lote
                              _STOCKS.LOG_Stocks.STOCK_LoteGeneral=Item.ORDET_LoteGeneral
                              _stocks.Egresopro(m_periodo, Item.ARTIC_Codigo,  m_bdist_ordenes.getTipoUnidadMedida(Item.ARTIC_Codigo), x_pvlocal.ALMAC_Id, Item.ORDET_Cantidad, _
                              m_bdist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaOrdenProduccion), x_usuario, _
                              _stocks.LOG_Stocks.ORDEN_CodigoProduccion,_stocks.LOG_Stocks.ORDET_ItemProduccion )                                                  
                              i += 1
                    Next               
              
                  dim  m_actualizarped = New BABAS_OrdenesProduccion
                        m_actualizarped.DIST_Ordenes= New EABAS_OrdenesProduccion()
                        m_actualizarped.DIST_Ordenes.ORDEN_Codigo=m_dist_ordenes.ORDEN_CodReferencia
                        m_actualizarped.DIST_Ordenes.ORDEN_Estado="T"
                        m_actualizarped.DIST_Ordenes.ORDEN_Impresa=True
                        m_actualizarped.DIST_Ordenes.ORDEN_Atendido=True
                        m_actualizarped.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
                        m_actualizarped.Guardar(x_usuario)
                        DAEnterprise.CommitTransaction()
            
         Else
            Throw New Exception("No se puede completar el proceso de grabar orden de produccion")
         End If

       '''grabar en el servidor remoto
         
         If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then
            _traerCliente = True
         End If
         If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
            '' Traer Cliente
            If _traerCliente Then
               _entidad = New BEntidades
               If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor remoto")
               If Not _cliente.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor remoto")
               If Not _roles.CargarTodos(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los roles que tiene el cliente")
            End If
            '' Cambiar estado a Orden generada
            
            m_bdist_ordenes.DIST_Ordenes.ORDEN_Atendido = True
            m_bdist_ordenes.DIST_Ordenes.ORDEN_Impresa = False
            m_bdist_ordenes.DIST_Ordenes.PVENT_Id=x_pvremoto.PVENT_Id
            m_bdist_ordenes.DIST_Ordenes.ALMAC_Id=x_pvremoto.ALMAC_Id
            m_bdist_ordenes.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            m_bdist_ordenes.DIST_Ordenes.Instanciar(ACEInstancia.Nuevo)
            If m_bdist_ordenes.Guardar(x_usuario) Then
                    
                 
                    Dim i As Integer = 1
                         For Each item As EABAS_OrdenesProduccionDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                              
                                Dim _detalle As New BABAS_OrdenesProduccionDetalle
                               _detalle.DIST_OrdenesDetalle = item
                               _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                               _detalle.DIST_OrdenesDetalle.ORDET_orden = i
                                _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)
                              _detalle.Guardar(x_usuario)
                               i += 1
                         Next
                    DAEnterprise.CommitTransaction()
                   
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
               Return True
            Else
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
               Throw New Exception("No se puede Atender la Orden en el Punto de venta Remoto")
            End If
         Else
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
            Throw New Exception("No se puede establecer conexión")
         End If

            

      Catch ex As Exception
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar orden de recojo de salida de mercaderia, tanto el el servidor local como el remoto
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="m_pvremoto">clase punto de venta del servidor remoto, contiene los valores de conexion</param>
   ''' <param name="x_pvlocal">clase punto de venta del servidor local, contiene los valores de conexion</param>
   ''' <param name="x_usuario_db">usuario de la base de datos a la cual se conectara, tanto el local como el remoto</param>
   ''' <param name="x_password_db">contraseña de la base de datos a la cual se conectara, tanto el local como el remoto</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarOrdenSalida(ByVal x_usuario As String, ByVal m_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta, ByVal x_usuario_db As String, ByVal x_password_db As String) As Boolean
      Dim _traerCliente As Boolean = False
      Try
         '' Realizar conexion a servidor remoto
         '' Verificar si el cliente existe en la base local
         Dim _entidad As New BEntidades
         Dim _cliente As New BClientes
         Dim _roles As New BEntidadesRoles
        
         If ACUtilitarios.ACCrearCadena("StrConn", m_pvremoto.PVENT_DireccionIP, m_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
           
            '' Cambiar estado a Orden generada
            Dim _orden1 As New BABAS_OrdenesProduccion
            _orden1.DIST_Ordenes = New EABAS_OrdenesProduccion
            _orden1.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                _orden1.DIST_Ordenes.ORDEN_Atendido = True
            _orden1.DIST_Ordenes.ORDEN_Impresa = True
            _orden1.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
            _orden1.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            If _orden1.Guardar(x_usuario) Then
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
            Else
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
               Throw New Exception("No se puede Atender la Orden en el Punto de venta Remoto")
            End If
         Else
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
            Throw New Exception("No se puede establecer conexión")
         End If

         '' Grabar Datos en Servidor Local
         DAEnterprise.BeginTransaction()
        
         '' Grabar la Orden en la Base Local
         Dim _orden As New BABAS_OrdenesProduccion
            _orden.DIST_Ordenes = New EABAS_OrdenesProduccion
            _orden.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                _orden.DIST_Ordenes.ORDEN_Atendido = True
            _orden.DIST_Ordenes.ORDEN_Impresa = True
            _orden.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
            _orden.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            
    
         If _orden.Guardar(x_usuario) Then
            Dim i As Integer = 1
        
            DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se puede completar el proceso de grabar orden")
         End If
      Catch ex As Exception
         If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
         End If
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

      Public Function GrabarOrdenSalidaStock(ByVal x_usuario As String, ByVal m_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta, ByVal x_usuario_db As String, ByVal x_password_db As String) As Boolean
      Dim _traerCliente As Boolean = False
      Try
         '' Realizar conexion a servidor remoto
         '' Verificar si el cliente existe en la base local
         Dim _entidad As New BEntidades
         Dim _cliente As New BClientes
         Dim _roles As New BEntidadesRoles
         
        
         If ACUtilitarios.ACCrearCadena("StrConn", m_pvremoto.PVENT_DireccionIP, m_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
           
            '' Cambiar estado a Orden generada
            DAEnterprise.BeginTransaction()
            Dim _orden1 As New BABAS_OrdenesProduccion
            Dim m_babas_ordenproduccion As New BABAS_OrdenesProduccion() With {.DIST_Ordenes = m_dist_ordenes}
            _orden1.DIST_Ordenes = New EABAS_OrdenesProduccion
            _orden1.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                _orden1.DIST_Ordenes.ORDEN_Atendido = True
            _orden1.DIST_Ordenes.ORDEN_Impresa = True
            _orden1.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
            _orden1.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            If _orden1.Guardar(x_usuario) Then
                    'Dim detallemateria As IEnumerable(Of EABAS_OrdenesProduccionDetalle) = m_bgenerarordenes.DIST_Ordenes.ListDIST_OrdenesDetalle.Where(Function(p) p.ORDET_ItemDocumento <= 0)
                    Dim count As Integer=1
                    For Each Item As EABAS_OrdenesProduccionDetalle In m_babas_ordenproduccion.DIST_Ordenes.ListDIST_OrdenesDetalle.Where(Function(p) p.ORDET_ItemDocumento >=1)
                              Dim _stocks As New ACBLogistica.BManejarStock
                              _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                              _stocks.LOG_Stocks.ORDEN_CodigoProduccion = Item.ORDEN_Codigo
                              _stocks.LOG_Stocks.ORDET_ItemProduccion = Item.ORDET_orden
                              _stocks.LOG_Stocks.STOCK_Lote = Item.ORDET_Lote
                              _stocks.LOG_Stocks.STOCK_LoteGeneral=Item.ORDET_LoteGeneral
                              _stocks.Ingresopro(m_periodo, Item.ARTIC_Codigo, m_babas_ordenproduccion.getTipoUnidadMedida(Item.ARTIC_Codigo), m_pvremoto.ALMAC_Id, Item.ORDET_Cantidad, _
                              m_babas_ordenproduccion.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.IngresoOrdenProduccion), x_usuario, _
                              _stocks.LOG_Stocks.ORDEN_CodigoProduccion,_stocks.LOG_Stocks.ORDET_ItemProduccion)
                              count += 1

                    Next
            DAEnterprise.CommitTransaction()

               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
            Else
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                  DAEnterprise.Instanciar("StrConn", True)
               End If
               Throw New Exception("No se puede Atender la Orden en el Punto de venta Remoto")
            End If
         Else
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
            Throw New Exception("No se puede establecer conexión")
         End If

         '' Grabar Datos en Servidor Local
         DAEnterprise.BeginTransaction()
        
         '' Grabar la Orden en la Base Local
         Dim _orden As New BABAS_OrdenesProduccion
              Dim m_babas_ordenproduccion1 As New BABAS_OrdenesProduccion() With {.DIST_Ordenes = m_dist_ordenes}
            _orden.DIST_Ordenes = New EABAS_OrdenesProduccion
            _orden.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                _orden.DIST_Ordenes.ORDEN_Atendido = True
            _orden.DIST_Ordenes.ORDEN_Impresa = True
            _orden.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
            _orden.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            
    
         If _orden.Guardar(x_usuario) Then
            DAEnterprise.CommitTransaction()
            ' Dim count As Integer=1
            '        For Each Item As EABAS_OrdenesProduccionDetalle In m_babas_ordenproduccion1.DIST_Ordenes.ListDIST_OrdenesDetalle.Where(Function(p) p.ORDET_Item >=1)
            '                  Dim _stocks As New ACBLogistica.BManejarStock
            '                  _stocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
            '                  _stocks.LOG_Stocks.ORDEN_CodigoProduccion = Item.ORDEN_Codigo
            '                  _stocks.LOG_Stocks.ORDET_ItemProduccion = count
            '                  _stocks.LOG_Stocks.TIPOS_CodTipoUnidad=Item.TIPOS_CodUnidadMedida
            '                  _stocks.LOG_Stocks.STOCK_Lote = Item.ORDET_Lote
            '                  _stocks.Egresopro(m_periodo, Item.ARTIC_Codigo,  m_babas_ordenproduccion1.getTipoUnidadMedida(Item.ARTIC_Codigo), x_pvlocal.ALMAC_Id, Item.ORDET_Cantidad, _
            '                  m_babas_ordenproduccion1.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaOrdenProduccion), x_usuario,_stocks.LOG_Stocks.ORDEN_CodigoProduccion,_stocks.LOG_Stocks.ORDET_ItemProduccion )
            '                  count += 1
            '        Next
            'DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se puede completar el proceso de grabar orden")
         End If
      Catch ex As Exception
         If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
         End If
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function


   ''' <summary>
   ''' Cargar el documento de venta
   ''' </summary>
   ''' <param name="x_docve_codigo">codigo del documento de venta</param>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <param name="x_almac_id">codigo del almacen</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarDocVenta(ByVal x_docve_codigo As String, ByVal x_pvent_id As Long, ByVal x_almac_id As Short) As Boolean
      Try
         If m_bvent_docsventa.Cargar(x_docve_codigo, False) Then
            m_dist_ordenes = New EABAS_OrdenesProduccion
            m_dist_ordenes.Instanciar(ACFramework.ACEInstancia.Nuevo)
            m_dist_ordenes.TIPOS_CodTipoOrden = ETipos.getTipoOrdenRecojo(ETipos.TipoOrdenRecojo.RecojoIngreso)
            Dim _where As New Hashtable
            _where.Add("PVENT_Id", New ACWhere(x_pvent_id))
            _where.Add("TIPOS_CodTipoOrden", New ACWhere(m_dist_ordenes.TIPOS_CodTipoOrden))
            Dim m_bdist_ordenes As New BABAS_OrdenesProduccion
            m_dist_ordenes.ORDEN_Id = m_bdist_ordenes.getCorrelativo("ORDEN_Id", _where)
            m_dist_ordenes.ORDEN_Codigo = String.Format("{0}{1:000}{2:0000000}", m_dist_ordenes.TIPOS_CodTipoOrden.Substring(3, 1).PadLeft(2, "0"), x_pvent_id, m_dist_ordenes.ORDEN_Id)

            m_dist_ordenes.ENTID_CodigoCliente = m_bvent_docsventa.VENT_DocsVenta.ENTID_CodigoCliente
            m_dist_ordenes.TIPOS_CodTipoMoneda = m_bvent_docsventa.VENT_DocsVenta.TIPOS_CodTipoMoneda
            m_dist_ordenes.DOCVE_Codigo = m_bvent_docsventa.VENT_DocsVenta.DOCVE_Codigo
            m_dist_ordenes.PVENT_IdOrigen = m_bvent_docsventa.VENT_DocsVenta.PVENT_Id
            m_dist_ordenes.ORDEN_DireccionDestino = m_bvent_docsventa.VENT_DocsVenta.DOCVE_DireccionCliente
            m_dist_ordenes.ORDEN_DescripcionCliente = m_bvent_docsventa.VENT_DocsVenta.ENTID_Cliente
            m_dist_ordenes.ORDEN_Observaciones = m_bvent_docsventa.VENT_DocsVenta.DOCVE_Observaciones
            m_dist_ordenes.ListDIST_OrdenesDetalle = New List(Of EABAS_OrdenesProduccionDetalle)

            If LOG_DIST_GUIASS_ObtDetDocVenta(m_bvent_docsventa.VENT_DocsVenta, x_docve_codigo, x_almac_id) Then
               Dim _i As Integer = 1
               For Each item As EVENT_DocsVentaDetalle In m_bvent_docsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                  Dim _detalle As New EABAS_OrdenesProduccionDetalle
                  _detalle.Entregado = item.Entregado
                  _detalle.Diferencia = item.Diferencia
                  _detalle.DOCVD_Cantidad = item.DOCVD_Cantidad
                  _detalle.ORDET_Cantidad = item.Diferencia
                  _detalle.ARTIC_Codigo = item.ARTIC_Codigo
                  _detalle.ARTIC_Descripcion = item.ARTIC_Descripcion
                  _detalle.TIPOS_UnidadMedida = item.TIPOS_UnidadMedida
                  _detalle.PesoUnitario = item.DOCVD_PesoUnitario
                  _detalle.ORDET_Item = _i
                  _detalle.ORDET_ItemDocumento = item.DOCVD_Item
                  _detalle.TIPOS_CodUnidadMedida = item.TIPOS_CodUnidadMedida
                  m_dist_ordenes.ListDIST_OrdenesDetalle.Add(_detalle)
                  _i += 1
               Next
            End If
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busqueda de Ordenes
   ''' </summary>
   ''' <param name="x_fecini">fecha de inicio de busqueda</param>
   ''' <param name="x_fecfin">fecha de fin de busqueda</param>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <param name="x_tipos_codtipoorden">tipo de orden de recojo</param>
   ''' <param name="x_opcion">opcion de campo en la busqueda</param>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_todos">cargar todos los registros</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Dim m_ordenes As New BABAS_OrdenesProduccion
      Try
         If m_ordenes.BuscarOrdenesIngreso(x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos) Then
            m_listDIST_Ordenes = m_ordenes.ListDIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Public Function BusquedaParaConfirmarIngPro(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Dim m_ordenes As New BABAS_OrdenesProduccion
      Try
         If m_ordenes.BuscarOrdenesParaConfirmarIngPro(x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos) Then
            m_listDIST_Ordenes = m_ordenes.ListDIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function



    Public Function BusquedaSalidaProducConf(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Dim m_ordenes As New BABAS_OrdenesProduccion
      Try
         If m_ordenes.BuscarOrdenesSalidaProConf(x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos) Then
            m_listDIST_Ordenes = m_ordenes.ListDIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function




     Public Function BusquedaConf(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Dim m_ordenes As New BABAS_OrdenesProduccion
      Try
         If m_ordenes.BuscarOrdenesIngresoConf(x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos) Then
            m_listDIST_Ordenes = m_ordenes.ListDIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

      Public Function ObtenerDoc(ByVal orden_codigo As String) As Boolean
        Dim m_ordenes As New BABAS_OrdenesProduccion
        m_ordenes.DIST_Ordenes = New EABAS_OrdenesProduccion()
      Try
            IF m_ordenes.ObtenerOrdend(orden_codigo,True,m_ordenes.DIST_Ordenes) THEN   
                     m_dist_ordenes = m_ordenes.DIST_Ordenes
                     m_dist_ordenes.ListDIST_OrdenesDetalle=m_ordenes.DIST_Ordenes.ListDIST_OrdenesDetalle
                     Return True
            End IF    

      Catch ex As Exception
         Throw ex
      End Try


   End Function

         ''' <summary> 
   ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta_articulos_a
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDetDocVenta_Artic(ByRef x_vent_docsventa As EVENT_DocsVenta, ByVal x_docve_codigo As String, ByVal x_almac_id As Short, ByVal x_artic_codigo as String) As Boolean
      'x_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)

       m_listDIST_VENTADET = New List (Of EVENT_DocsVentaDetalle)

      Try
         Return d_generarordenes.LOG_DIST_GUIASS_ObtDetDocVenta_Artic(m_listDIST_VENTADET, x_docve_codigo, x_almac_id,x_artic_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busqueda de ordenes por punto de venta
   ''' </summary>
   ''' <param name="x_fecini">fecha de inicio de busqueda</param>
   ''' <param name="x_fecfin">fecha de fin de busqueda</param>
   ''' <param name="x_pvent_iddestino">codigo de punto de venta destino</param>
   ''' <param name="x_pvent_idorigen">codigo de punto de venta origen</param>
   ''' <param name="x_tipos_codtipoorden">tipo de orden de recojo</param>
   ''' <param name="x_opcion">opcion de busqueda de documento</param>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_todos">mostrar todos los registros</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function BusquedaPtoVenta(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_pvent_idorigen As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Dim m_ordenes As New BABAS_OrdenesProduccion
      Try
         If m_ordenes.BuscarOrdenesIngresoPtoVenta(x_fecini, x_fecfin, x_pvent_iddestino, x_pvent_idorigen, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos) Then
            m_listDIST_Ordenes = m_ordenes.ListDIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de ordenes en el servidor local
   ''' </summary>
   ''' <param name="x_fecini">fecha de inicio de busqueda</param>
   ''' <param name="x_fecfin">fecha de fin de busqueda</param>
   ''' <param name="x_pvent_iddestino">codigo de punto de venta destino</param>
   ''' <param name="x_tipos_codtipoorden">tipo de orden de recojo</param>
   ''' <param name="x_opcion">opcion de busqueda</param>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_todos">mostrar todos los registros</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function BusquedaLocal(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Dim m_ordenes As New BABAS_OrdenesProduccion
      Try
         If m_ordenes.BuscarOrdenesIngresoLocal(x_fecini, x_fecfin, x_pvent_iddestino, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos) Then
            m_listDIST_Ordenes = m_ordenes.ListDIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

      ''' <summary> 
   ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDetDocVenta(ByRef x_vent_docsventa As EVENT_DocsVenta, ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
      x_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
      Try
         Return d_generarordenes.LOG_DIST_GUIASS_ObtDetDocVenta(x_vent_docsventa.ListVENT_DocsVentaDetalle, x_docve_codigo, x_almac_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar orden de compra
   ''' </summary>
   ''' <param name="x_codigo">codigo de orden de compra</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarOrden(ByVal x_codigo As String) As Boolean
      Try
         Dim _ordenes As New BABAS_OrdenesProduccion
         If _ordenes.ObtenerOrden(x_codigo, True) Then
            m_dist_ordenes = _ordenes.DIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar orden de recojo
   ''' </summary>
   ''' <param name="x_codigo">codigo de orden de recojo</param>
   ''' <param name="x_detalle">opcion para cargar el detalle de la orden de recojo</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarOrden(ByVal x_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim _ordenes As New BABAS_OrdenesProduccion
         If _ordenes.ObtenerOrden(x_codigo, x_detalle) Then
            m_dist_ordenes = _ordenes.DIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener y cargar el punto de venta
   ''' </summary>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function GetPuntoVenta(ByVal x_pvent_id As Long) As Boolean
      Try
         Dim _puntoventa As New BPuntoVenta
         If _puntoventa.Cargar(x_pvent_id) Then
            m_puntoventaremoto = _puntoventa.PuntoVenta
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' anular orden de recojo
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_pvlocal">clase punto de venta que contiene los datos de conexion remota</param>
   ''' <param name="x_usuario_db">usuario de la base de datos</param>
   ''' <param name="x_password_db">contraseña de la base de datos</param>
   ''' <param name="x_xordenposterior">permiso para nular orden posterior a la fecha de creación</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AnularOrdenSalida(ByVal x_usuario As String, ByVal x_pvlocal As EPuntoVenta, ByVal x_usuario_db As String, ByVal x_password_db As String, ByVal x_xordenposterior As Boolean) As Boolean
      Try
         '' Verificar que la orden no tegna guias
         Dim _where As New Hashtable
         _where.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenes.ORDEN_Codigo))
         _where.Add("GUIAR_Estado", New ACWhere("X", ACWhere.TipoWhere.Diferente))
         Dim _guias As New BDIST_GuiasRemision
         If _guias.CargarTodos(_where) Then
            Dim _lguia As String = ""
            For Each item As EDIST_GuiasRemision In _guias.ListDIST_GuiasRemision
               _lguia &= String.Format("{0}, ", item.GUIAR_Codigo)
            Next
            Throw New Exception(String.Format("No se puede Anular la Orden {0}, por que tiene Guias de Remision: {1}{2}", m_dist_ordenes.ORDEN_Codigo, _lguia, vbNewLine))
         End If
         '' Verificar permiso para anular ordenes posteriores
         Dim _constantes As New BConstantes
         Dim _fecha As DateTime = _constantes.getFecha()
         If Not _fecha.Date = m_dist_ordenes.ORDEN_FechaDocumento.Date Then
            If Not x_xordenposterior Then
               Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
            End If
         End If

         '' Anular Documento Remoto
         GetPuntoVenta(m_dist_ordenes.PVENT_IdOrigen)
         If ACUtilitarios.ACCrearCadena("StrConn", m_puntoventaremoto.PVENT_DireccionIP, m_puntoventaremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
            DAEnterprise.BeginTransaction()
            Dim _ordenremoto As New BABAS_OrdenesProduccion
            _ordenremoto.DIST_Ordenes = New EABAS_OrdenesProduccion
            _ordenremoto.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
            _ordenremoto.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
            _ordenremoto.DIST_Ordenes.ORDEN_Atendido = True
            _ordenremoto.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            If _ordenremoto.Guardar(x_usuario) Then
               '' Actualizar el Ingreso de Articulos
               Dim _whereorden As New Hashtable : _whereorden.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenes.ORDEN_Codigo))
               Dim _ordendetalle As New BABAS_OrdenesProduccionDetalle
               If _ordendetalle.CargarTodos(_whereorden) Then
                  For Each item As EABAS_OrdenesProduccionDetalle In _ordendetalle.ListDIST_OrdenesDetalle
                     Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                     m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                     m_bmanejarstocks.LOG_Stocks.ORDEN_Codigo = item.ORDEN_Codigo
                     m_bmanejarstocks.LOG_Stocks.ORDET_Item = item.ORDET_Item
                     m_bmanejarstocks.AnulacionIngresoOrden(m_periodo, item.ARTIC_Codigo, m_puntoventaremoto.ALMAC_Id, item.ORDEN_Codigo, item.ORDET_Item, _
                                                            item.ORDET_Cantidad, x_usuario)
                  Next
                  DAEnterprise.CommitTransaction()
               Else
                  Throw New Exception("No se puede cargar el detalle de la Orden")
               End If
            Else
               Throw New Exception(String.Format("No se puede Anular la orden {0} en {0}, ocurrio un error al intentar anular la orden remota", m_dist_ordenes.ORDEN_Codigo, m_puntoventaremoto.PVENT_Descripcion))
            End If
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
         Else
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
               DAEnterprise.Instanciar("StrConn", True)
            End If
            Throw New Exception("No se puede establecer conexión")
         End If
         '' Anular Documento Local
         DAEnterprise.BeginTransaction()
         Dim _ordenlocal As New BABAS_OrdenesProduccion
         _ordenlocal.DIST_Ordenes = New EABAS_OrdenesProduccion
         _ordenlocal.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
         _ordenlocal.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
         _ordenlocal.DIST_Ordenes.ORDEN_Atendido = True
         _ordenlocal.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
         If _ordenlocal.Guardar(x_usuario) Then
            '' Actualizar el Egreso de Articulos
            Dim _whereorden As New Hashtable : _whereorden.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenes.ORDEN_Codigo))
            Dim _ordendetalle As New BABAS_OrdenesProduccionDetalle
            If _ordendetalle.CargarTodos(_whereorden) Then
               For Each item As EABAS_OrdenesProduccionDetalle In _ordendetalle.ListDIST_OrdenesDetalle
                  Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                  m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                  m_bmanejarstocks.LOG_Stocks.ORDEN_Codigo = item.ORDEN_Codigo
                  m_bmanejarstocks.LOG_Stocks.ORDET_Item = item.ORDET_Item
                  m_bmanejarstocks.AnulacionEgresoOrden(m_periodo, item.ARTIC_Codigo, x_pvlocal.ALMAC_Id, item.ORDEN_Codigo, item.ORDET_Item, _
                                                        item.ORDET_Cantidad, x_usuario)
               Next
               DAEnterprise.CommitTransaction()
               Return True
            Else
               Throw New Exception("No se puede cargar el detalle de la Orden")
            End If
         Else
            Throw New Exception(String.Format("No se puede Anular la orden {0} en {0}, ocurrio un error al intentar anular la orden local atendida", m_dist_ordenes.ORDEN_Codigo, m_puntoventaremoto.PVENT_Descripcion))
         End If
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
         End If
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' actualizar el estado de impresion de la orden de compra, solo el usuario normal solo puede imprimir 1 sola vez
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ActualizarImpresion(ByVal x_usuario As String) As Boolean
      Try
         Dim _where As New Hashtable
         _where.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenes.ORDEN_Codigo))
         Dim _orden As New BABAS_OrdenesProduccion
         _orden.DIST_Ordenes = New EABAS_OrdenesProduccion
         _orden.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
         _orden.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
         _orden.DIST_Ordenes.ORDEN_Impresa = True
         _orden.DIST_Ordenes.ORDEN_Impresiones = _orden.getCorrelativo("ORDEN_Impresiones", _where)
         Return _orden.Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' ''' <summary> 
   ' ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDocVentaXNumero
   ' ''' </summary>
   ' ''' <param name="x_numero">Parametro 1: </param> 
   ' ''' <param name="x_serie">Parametro 2: </param> 
   ' ''' <param name="x_tipos_codtipodocumento">Parametro 3: </param> 
   ' ''' <param name="x_almac_id">Parametro 4: </param> 
   ' ''' <param name="x_pvent_id">Parametro 5: </param> 
   ' ''' <returns></returns> 
   ' ''' <remarks></remarks> 
   'Public Function BusquedaDocVentaXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long) As Boolean
   '   m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
   '   Try
   '      Return d_generarordenes.LOG_DIST_GUIASS_ObtDocVentaXNumero(m_listVENT_DocsVenta, x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   ' ''' <summary> 
   ' ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDocVenta
   ' ''' </summary>
   ' ''' <param name="x_tconsulta">Parametro 1: </param> 
   ' ''' <param name="x_cadena">Parametro 2: </param> 
   ' ''' <param name="x_almac_id">Parametro 3: </param> 
   ' ''' <param name="x_pvent_id">Parametro 4: </param> 
   ' ''' <param name="x_fecini">Parametro 5: </param> 
   ' ''' <param name="x_fecfin">Parametro 6: </param> 
   ' ''' <returns></returns> 
   ' ''' <remarks></remarks> 
   'Public Function BusquedaDocVenta(ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
   '   m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
   '   Try
   '      Return d_generarordenes.LOG_DIST_GUIASS_ObtDocVenta(m_listVENT_DocsVenta, x_tconsulta, x_cadena, x_almac_id, x_pvent_id, x_fecini, x_fecfin)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   ' ''' <summary> 
   ' ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta
   ' ''' </summary>
   ' ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ' ''' <param name="x_almac_id">Parametro 2: </param> 
   ' ''' <returns></returns> 
   ' ''' <remarks></remarks> 
   'Public Function LOG_DIST_GUIASS_ObtDetDocVenta(ByRef x_vent_docsventa As EVENT_DocsVenta, ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
   '   x_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
   '   Try
   '      Return d_generarordenes.LOG_DIST_GUIASS_ObtDetDocVenta(x_vent_docsventa.ListVENT_DocsVentaDetalle, x_docve_codigo, x_almac_id)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function


   '    ''' <summary> 
   ' ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta_articulos_a
   ' ''' </summary>
   ' ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ' ''' <param name="x_almac_id">Parametro 2: </param> 
   ' ''' <returns></returns> 
   ' ''' <remarks></remarks> 
   'Public Function LOG_DIST_GUIASS_ObtDetDocVenta_Artic(ByRef x_vent_docsventa As EVENT_DocsVenta, ByVal x_docve_codigo As String, ByVal x_almac_id As Short, ByVal x_artic_codigo as String) As Boolean
   '   'x_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)

   '    m_listDIST_VENTADET = New List (Of EVENT_DocsVentaDetalle)

   '   Try
   '      Return d_generarordenes.LOG_DIST_GUIASS_ObtDetDocVenta_Artic(m_listDIST_VENTADET, x_docve_codigo, x_almac_id,x_artic_codigo)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   ''' <summary>
   ''' obtener el correlativo de la orden de recojo
   ''' </summary>
   ''' <param name="x_orden_serie">serie de la orden de recojo</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetCorrelativo(ByVal x_orden_serie As String) As Integer
      Try
         Dim _where As New Hashtable
         _where.Add("ORDEN_Serie", New ACWhere(x_orden_serie))
         Dim m_dist_ordenes As New BABAS_OrdenesProduccion
         Return m_dist_ordenes.getCorrelativo("ORDEN_Numero", _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_OrdenesXDocumento
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function OrdenesXDocumento(ByVal x_docve_codigo As String, ByVal x_pvent_id As Long) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Try
         Return d_generarordenes.LOG_DISTSS_OrdenesXDocumento(m_listDIST_Ordenes, x_docve_codigo, x_pvent_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
         ''' <summary> 
   ''' Capa de Negocio: LOG_DISTSS_OrdenesXDocumento
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function OrdenesXDocumentoL(ByVal x_docve_codigo As String, ByVal x_ALMAC_id As Long) As Boolean
      m_listDIST_Ordenes = New List(Of EABAS_OrdenesProduccion)
      Try
         Return d_generarordenes.LOG_DISTSS_OrdenesXDocumentoL(m_listDIST_Ordenes, x_docve_codigo, x_ALMAC_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


#End Region

#Region " Metodos de Controles"

#End Region


End Class

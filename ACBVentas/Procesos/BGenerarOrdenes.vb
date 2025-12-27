Imports ACDVentas
Imports ACEVentas
Imports ACFramework
Imports DAConexion

Public Class BGenerarOrdenes
#Region " Variables "
   Private d_generarordenes As DGenerarOrdenes
   PRIVATE m_listVENT_DocsVentadET As EVENT_DocsVentaDetalle

   Private m_dist_ordenes As EDIST_Ordenes
    Private m_dist_ordenesp As EABAS_OrdenesProduccion
   Private m_bvent_docsventa As New BVENT_DocsVenta
   Private m_puntoventaremoto As EPuntoVenta
    Private m_docs_venta As EVENT_DocsVenta
    
    Private m_listDIST_VENTADET As List(Of EVENT_DocsVentaDetalle)
   Private m_listVENT_DocsVenta As List(Of EVENT_DocsVenta)
   Private m_listDIST_Ordenes As List(Of EDIST_Ordenes)


    Private m_listDIST_ordendetorigen As List(Of EDIST_OrdenesDetalle)
    Private m_listDIST_ordendetdestino As List(Of EDIST_OrdenesDetalle)
    
     Public Property ListDIST_OrdenesDetalleOrigen() As List(Of EDIST_OrdenesDetalle)
        Get
            Return m_listDIST_ordendetorigen
        End Get
        Set(ByVal value As List(Of EDIST_OrdenesDetalle))
            m_listDIST_ordendetorigen = value
        End Set
    End Property
     Public Property ListDIST_OrdenesDetalleDestino() As List(Of EDIST_OrdenesDetalle)
        Get
            Return m_listDIST_ordendetdestino
        End Get
        Set(ByVal value As List(Of EDIST_OrdenesDetalle))
            m_listDIST_ordendetdestino = value
        End Set
    End Property
    
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

   Public Property DIST_Ordenes() As EDIST_Ordenes
      Get
         Return m_dist_ordenes
      End Get
      Set(ByVal value As EDIST_Ordenes)
         m_dist_ordenes = value
      End Set
   End Property

    
     Public Property DIST_OrdenesProduccion() As EABAS_OrdenesProduccion
      Get
         Return m_dist_ordenesp
      End Get
      Set(ByVal value As EABAS_OrdenesProduccion)
         m_dist_ordenesp = value
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

   Public Property ListDIST_Ordenes() As List(Of EDIST_Ordenes)
      Get
         Return m_listdist_ordenes
      End Get
      Set(ByVal value As List(Of EDIST_Ordenes))
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
      d_generarordenes = New DGenerarOrdenes
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
        Dim m_bdist_ordenes As New BDIST_Ordenes
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
                m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
                If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
                    Dim i As Integer = 1

                    For Each item As EDIST_OrdenesDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                        If item.ORDET_Cantidad > 0 Then
                            Dim _detalle As New BDIST_OrdenesDetalle
                            _detalle.DIST_OrdenesDetalle = item
                            _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                            _detalle.DIST_OrdenesDetalle.ORDET_Item = i
                            _detalle.DIST_OrdenesDetalle.ORDET_Cantidad = item.ORDET_Cantidad
                            cant = item.ORDET_Cantidad
                            '_detalle.DIST_OrdenesDetalle.ORDET_EstAlmacen = "E"
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

                            ' ''Actualizar estado a entregado VENT_DocsVenta
                            'Dim x_documento As New BVENT_DocsVentaDetalle
                            ' '' Cambiar de estado al pedido
                            'If x_documento.Cargar(m_dist_ordenes.DOCVE_Codigo, _detalle.DIST_OrdenesDetalle.ORDET_ItemDocumento) Then
                            '    If x_documento.VENT_DocsVentaDetalle.DOCVD_EstAlmacen = "E" Then
                            '        Throw New Exception("No se puede generar orden,ya que la venta fue entregada")
                            '    End If
                            'End If
                            'x_documento.VENT_DocsVentaDetalle = New EVENT_DocsVentaDetalle
                            'x_documento.VENT_DocsVentaDetalle.DOCVE_Codigo = m_dist_ordenes.DOCVE_Codigo
                            'x_documento.VENT_DocsVentaDetalle.DOCVD_EstAlmacen = "E"
                            'x_documento.VENT_DocsVentaDetalle.Instanciar(ACEInstancia.Modificado)
                            'x_documento.Guardar(x_usuario)
    



                                    '' Realizar el Ingreso a Stock
                                    Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                                    m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                    m_bmanejarstocks.LOG_Stocks.ORDEN_Codigo = Item.ORDEN_Codigo
                                    m_bmanejarstocks.LOG_Stocks.ORDET_Item = Item.ORDET_Item
                                    m_bmanejarstocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_bdist_ordenes.DIST_Ordenes.ALMAC_Id, Item.ORDET_Cantidad, _
                                                             m_bdist_ordenes.DIST_Ordenes.ORDEN_FechaIngreso, ETipos.getTipo(ETipos.TMovimientoStock.IngresoOrden), x_usuario)
                                End If
                                i += 1
                            Next
                            DAEnterprise.CommitTransaction()

                        End If
            End If

            '' Establecer conexion con el servidor remoto
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
                DAEnterprise.BeginTransaction()
               m_dist_ordenes.ORDEN_Serie=getSerie(ETipos.getTipoOrdenRecojo(ETipos.TipoOrdenRecojo.RecojoSalida),x_pvremoto.PVENT_Id)  
               m_dist_ordenes.ORDEN_Numero=GetCorrelativo(m_dist_ordenes.ORDEN_Serie)
               m_dist_ordenes.ORDEN_Codorigen=m_dist_ordenes.ORDEN_Codigo
               m_dist_ordenes.ORDEN_Codigo = String.Format("{0}{1}{2:0000000}", m_dist_ordenes.TIPOS_CodTipoOrden.Substring(3, 1).PadLeft(2, "0"), m_dist_ordenes.ORDEN_Serie, m_dist_ordenes.ORDEN_Numero)
               m_dist_ordenes.TIPOS_CodTipoOrden=ETipos.getTipoOrdenRecojo(ETipos.TipoOrdenRecojo.RecojoSalida)

                '' Grabar la Orden remoto
                m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
                If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then 

                    Dim i As Integer = 1
                    For Each item As EDIST_OrdenesDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                        If item.ORDET_Cantidad > 0 Then
                            Dim _detalle As New BDIST_OrdenesDetalle
                            _detalle.DIST_OrdenesDetalle = item
                            _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                            _detalle.DIST_OrdenesDetalle.ORDET_Cantidad = item.ORDET_Cantidad
                            _detalle.DIST_OrdenesDetalle.ORDET_Item = i
                            ' _detalle.DIST_OrdenesDetalle.ORDET_EstAlmacen = "P"
                            _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)

                            _detalle.Guardar(x_usuario)

                            '' Realizar el egreso de Stock
                            Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                            m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                            m_bmanejarstocks.LOG_Stocks.ORDEN_Codigo = item.ORDEN_Codigo
                            m_bmanejarstocks.LOG_Stocks.ORDET_Item = item.ORDET_Item
                            m_bmanejarstocks.Egreso(m_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, x_pvremoto.ALMAC_Id, item.ORDET_Cantidad, _
                                             m_bdist_ordenes.DIST_Ordenes.ORDEN_FechaIngreso, ETipos.getTipo(ETipos.TMovimientoStock.SalidaOrden), x_usuario)
                        End If
                        i += 1
                    Next
                    DAEnterprise.CommitTransaction()


                    'ListDIST_OrdenesDetalleDestino
                    'ListDIST_OrdenesDetalleOrigen
                         m_listDIST_ordendetdestino = New List (Of EDIST_OrdenesDetalle)
                        d_generarordenes.LOG_DISTSS_OrdenesDetalle(m_listDIST_ordendetdestino,m_dist_ordenes.ORDEN_Codigo,m_dist_ordenes.ALMAC_IdDestino)


                    '''''''''''''confirmar en origen
                       If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                             DAEnterprise.Instanciar("StrConn", True)
                        m_listDIST_ordendetorigen = New List (Of EDIST_OrdenesDetalle)
                        d_generarordenes.LOG_DISTSS_OrdenesDetalle(m_listDIST_ordendetorigen,m_dist_ordenes.ORDEN_Codorigen,m_dist_ordenes.ALMAC_Id)

                            For each item As EDIST_OrdenesDetalle In m_listDIST_ordendetorigen  
                               
                             if not  ((From p In  ListDIST_OrdenesDetalleDestino Where p.ARTIC_Codigo =item.ARTIC_Codigo).Any()) Then

                                    if ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                                    DAEnterprise.Instanciar("StrConn", True)
                                        
                                         Dim _ord As New BDIST_Ordenes
                                         Dim _where1 As New Hashtable
                                        _where1.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenes.ORDEN_Codigo))
                                        _ord.EliminarTodo(_where1)

                                    ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) 
                                    DAEnterprise.Instanciar("StrConn", True)

                                    Else
                                    ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) 
                                    DAEnterprise.Instanciar("StrConn", True)

                                    End If
                                Throw New Exception("No se grabo la orden con su totalidad en el destino por problemas de conexion, consultar con el area de Control")
                                
                             end If

                            Next
                        
                             DAEnterprise.BeginTransaction()
                            Dim _orden As New BDIST_Ordenes
                            _orden.DIST_Ordenes = New EDIST_Ordenes
                            _orden.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codorigen
                            _orden.DIST_Ordenes.ORDEN_Codorigen=m_dist_ordenes.ORDEN_Codigo
                            _orden.DIST_Ordenes.ORDEN_Atendido = True
                            _orden.DIST_Ordenes.ORDEN_Impresa = False
                            _orden.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
                            _orden.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
                            If  _orden.Guardar(x_usuario) then
                                DAEnterprise.CommitTransaction()
                            else
                                Throw New Exception("No se puede Confirmar la orden Localmente")
                            End If
                         
                    END IF

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

   ''' <summary>
   ''' Grabar Orden de Ingreso
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarOrdenIngreso(ByVal x_usuario As String) As Boolean
      Try
         Dim m_bdist_ordenes As New BDIST_Ordenes
         Dim _where As New Hashtable
         _where.Add("PVENT_Id", New ACWhere(m_dist_ordenes.PVENT_Id))
         _where.Add("TIPOS_CodTipoOrden", New ACWhere(m_dist_ordenes.TIPOS_CodTipoOrden))

         m_dist_ordenes.ORDEN_Id = m_bdist_ordenes.getCorrelativo("ORDEN_Id", _where)
         m_dist_ordenes.ORDEN_Codigo = String.Format("{0}{1:000}{2:0000000}", m_dist_ordenes.TIPOS_CodTipoOrden.Substring(3, 1).PadLeft(2, "0"), m_dist_ordenes.PVENT_Id, m_dist_ordenes.ORDEN_Id)
         m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
         m_bdist_ordenes.DIST_Ordenes = m_dist_ordenes
         DAEnterprise.BeginTransaction()
         If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
            Dim i As Integer = 1
            For Each item As EDIST_OrdenesDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
               Dim _detalle As New BDIST_OrdenesDetalle
               _detalle.DIST_OrdenesDetalle = item
               _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
               _detalle.DIST_OrdenesDetalle.ORDET_Item = i
               _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)
               _detalle.Guardar(x_usuario)
               i += 1
            Next
            DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se puede completar el proceso de grabar orden")
         End If
      Catch ex As Exception
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
         If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then
            _traerCliente = True
         End If
         If ACUtilitarios.ACCrearCadena("StrConn", m_pvremoto.PVENT_DireccionIP, m_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            DAEnterprise.Instanciar("StrConn", True)
            '' Traer Cliente
            If _traerCliente Then
               _entidad = New BEntidades
               If Not _entidad.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor remoto")
               If Not _cliente.Cargar(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor remoto")
               If Not _roles.CargarTodos(m_dist_ordenes.ENTID_CodigoCliente) Then Throw New Exception("No se puede cargar los roles que tiene el cliente")
            End If
            '' Cambiar estado a Orden generada
            Dim _orden As New BDIST_Ordenes
            _orden.DIST_Ordenes = New EDIST_Ordenes
            _orden.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codorigen
                _orden.DIST_Ordenes.ORDEN_Atendido = True
            _orden.DIST_Ordenes.ORDEN_Impresa = False
            _orden.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
            _orden.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            If _orden.Guardar(x_usuario) Then
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
         '' Grabar la Entidad en el Cliente Local
         If _traerCliente Then
            _entidad.Entidades.Instanciar(ACEInstancia.Nuevo)
            If Not _entidad.Guardar(x_usuario) Then Throw New Exception("No se puede Cargar la entidad Cliente en el servidor Local")
            _cliente.Clientes.Instanciar(ACEInstancia.Nuevo)
            If Not _cliente.Guardar(x_usuario) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor Local")
            _roles.EntidadesRoles.Instanciar(ACEInstancia.Nuevo)
            If Not _roles.Guardar(x_usuario) Then Throw New Exception("No se puede cargar los datos adicionales del cliente en el servidor Local")
         End If
         '' Grabar la Orden en la Base Local
         Dim m_bdist_ordenes As New BDIST_Ordenes
         m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
         m_bdist_ordenes.DIST_Ordenes = m_dist_ordenes
         m_bdist_ordenes.DIST_Ordenes.ORDEN_UsrCreaRemoto = m_dist_ordenes.ORDEN_UsrCrea
         m_bdist_ordenes.DIST_Ordenes.ORDEN_FecCreaRemoto = m_dist_ordenes.ORDEN_FecCrea
         
         If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
            Dim i As Integer = 1
                'For Each item As EDIST_OrdenesDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                '   Dim _detalle As New BDIST_OrdenesDetalle
                '   _detalle.DIST_OrdenesDetalle = item
                '   _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                '   _detalle.DIST_OrdenesDetalle.ORDET_Item = i
                '   _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)
                '   _detalle.Guardar(x_usuario)
                '   i += 1
                'Next
                For Each item As EDIST_OrdenesDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
                    If item.ORDET_Cantidad > 0 Then
                        Dim _detalle As New BDIST_OrdenesDetalle
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
                        m_bmanejarstocks.Egreso(m_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, m_bdist_ordenes.DIST_Ordenes.ALMAC_IdDestino, item.ORDET_Cantidad, _
                                                m_bdist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaOrden), x_usuario)
                    End If
                    i += 1
                Next
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
            m_dist_ordenes = New EDIST_Ordenes
            m_dist_ordenes.Instanciar(ACFramework.ACEInstancia.Nuevo)
            m_dist_ordenes.TIPOS_CodTipoOrden = ETipos.getTipoOrdenRecojo(ETipos.TipoOrdenRecojo.RecojoIngreso)
            Dim _where As New Hashtable
            _where.Add("PVENT_Id", New ACWhere(x_pvent_id))
            _where.Add("TIPOS_CodTipoOrden", New ACWhere(m_dist_ordenes.TIPOS_CodTipoOrden))
            Dim m_bdist_ordenes As New BDIST_Ordenes
            m_dist_ordenes.ORDEN_Id = m_bdist_ordenes.getCorrelativo("ORDEN_Id", _where)
            m_dist_ordenes.ORDEN_Codigo = String.Format("{0}{1:000}{2:0000000}", m_dist_ordenes.TIPOS_CodTipoOrden.Substring(3, 1).PadLeft(2, "0"), x_pvent_id, m_dist_ordenes.ORDEN_Id)

            m_dist_ordenes.ENTID_CodigoCliente = m_bvent_docsventa.VENT_DocsVenta.ENTID_CodigoCliente
            m_dist_ordenes.TIPOS_CodTipoMoneda = m_bvent_docsventa.VENT_DocsVenta.TIPOS_CodTipoMoneda
            m_dist_ordenes.DOCVE_Codigo = m_bvent_docsventa.VENT_DocsVenta.DOCVE_Codigo
            m_dist_ordenes.ORDEN_FechaDocumento=m_bvent_docsventa.VENT_DocsVenta.DOCVE_FechaDocumento
            m_dist_ordenes.PVENT_IdOrigen = m_bvent_docsventa.VENT_DocsVenta.PVENT_Id
                m_dist_ordenes.ORDEN_DireccionDestino = m_bvent_docsventa.VENT_DocsVenta.DOCVE_DireccionCliente

                'R14/06/2017
                m_dist_ordenes.ORDEN_DescripcionCliente = m_bvent_docsventa.VENT_DocsVenta.DOCVE_DescripcionCliente 'ENTID_Cliente

            m_dist_ordenes.ORDEN_Observaciones = m_bvent_docsventa.VENT_DocsVenta.DOCVE_Observaciones
            m_dist_ordenes.ListDIST_OrdenesDetalle = New List(Of EDIST_OrdenesDetalle)

            If LOG_DIST_GUIASS_ObtDetDocVenta(m_bvent_docsventa.VENT_DocsVenta, x_docve_codigo, x_almac_id) Then
               Dim _i As Integer = 1
               For Each item As EVENT_DocsVentaDetalle In m_bvent_docsventa.VENT_DocsVenta.ListVENT_DocsVentaDetalle
                  Dim _detalle As New EDIST_OrdenesDetalle
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
      m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
      Dim m_ordenes As New BDIST_Ordenes
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
      m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
      Dim m_ordenes As New BDIST_Ordenes
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
      m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
      Dim m_ordenes As New BDIST_Ordenes
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
   ''' cargar orden de compra
   ''' </summary>
   ''' <param name="x_codigo">codigo de orden de compra</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarOrden(ByVal x_codigo As String) As Boolean
      Try
         Dim _ordenes As New BDIST_Ordenes
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
    ''' verifica si tiene guias
    ''' </summary>
    ''' <param name="x_codigo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     Public Function verificacionOrdenesGuias(ByVal x_codigo As String) As Boolean
      Try
         Dim _ordenes As New BDIST_Ordenes
         If _ordenes.verificarordenesguias(x_codigo) Then
            m_dist_ordenes = _ordenes.DIST_Ordenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function


    ''' <summary>
    ''' actuliza solo el estado
    ''' </summary>
    ''' <param name="x_codigo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     Public Function actualizarestadoOrden(ByVal x_usuario As String, ByVal x_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta, ByVal x_usuario_db As String, ByVal x_password_db As String,ByVal x_codigo As String,ByVal x_codigo_Origen As String, ByVal x_estadoentrega As String) As Boolean
      Try
        Dim _ordenes As New BDIST_Ordenes
       

        ''grabar en el local

           
        If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
                DAEnterprise.BeginTransaction()
                _ordenes.actualizarEstadoOrden(x_codigo,x_estadoentrega)
                DAEnterprise.CommitTransaction()
        Else
            Throw New Exception("No se puede eestablecer conexion con el servidor remoto")
        End If

        If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
                DAEnterprise.BeginTransaction()
            If _ordenes.actualizarEstadoOrden(x_codigo_Origen,x_estadoentrega) Then
               If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
                End If
                DAEnterprise.CommitTransaction()
                Return True
            Else 
                If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
                End If
                Return False
            End If
            
             
        Else
            If ACUtilitarios.ACCrearCadena("StrConn", x_pvlocal.PVENT_DireccionIP, x_pvlocal.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
             End If
            Throw New Exception("No se puede eestablecer conexion con el servidor remoto")
        End If


         
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
         Dim _ordenes As New BDIST_Ordenes
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
    Public Function AnularOrdenSalida(ByVal x_usuario As String, ByVal x_pvlocal As EPuntoVenta, ByVal x_usuario_db As String, ByVal x_password_db As String, ByVal x_xordenposterior As Boolean,
                                      ByVal x_paseanularordenes As Boolean, ByVal x_motivo As String) As Boolean
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
                    If Not x_paseanularordenes Then
                        Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                    End If
                End If
            End If

            '' Anular Documento Remoto
            GetPuntoVenta(m_dist_ordenes.PVENT_IdOrigen)
            If ACUtilitarios.ACCrearCadena("StrConn", m_puntoventaremoto.PVENT_DireccionIP, m_puntoventaremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
                DAEnterprise.Instanciar("StrConn", True)
                DAEnterprise.BeginTransaction()
                Dim _ordenremoto As New BDIST_Ordenes
                _ordenremoto.DIST_Ordenes = New EDIST_Ordenes
                '''REVISAR CODIGO ORIGEN DE ORDEN
                If m_dist_ordenes.ORDEN_Codorigen Is Nothing Then
                    _ordenremoto.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
                Else
                    _ordenremoto.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codorigen
                End If

                _ordenremoto.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
                _ordenremoto.DIST_Ordenes.ORDEN_Atendido = True
                _ordenremoto.DIST_Ordenes.ORDEN_MotivoAnulacion = x_motivo
                _ordenremoto.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
                If _ordenremoto.Guardar(x_usuario) Then
                    '' Actualizar el Ingreso de Articulos
                    Dim _whereorden As New Hashtable
                    If m_dist_ordenes.ORDEN_Codorigen Is Nothing Then
                        _whereorden.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenes.ORDEN_Codigo))
                    Else
                        _whereorden.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenes.ORDEN_Codorigen))
                    End If
                    Dim _ordendetalle As New BDIST_OrdenesDetalle
                    If _ordendetalle.CargarTodos(_whereorden) Then
                        For Each item As EDIST_OrdenesDetalle In _ordendetalle.ListDIST_OrdenesDetalle
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
            Dim _ordenlocal As New BDIST_Ordenes
            _ordenlocal.DIST_Ordenes = New EDIST_Ordenes
            _ordenlocal.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
            _ordenlocal.DIST_Ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
            _ordenlocal.DIST_Ordenes.ORDEN_Impresa = m_dist_ordenes.ORDEN_Impresa
            _ordenlocal.DIST_Ordenes.ORDEN_PerGenGuia = m_dist_ordenes.ORDEN_PerGenGuia
            _ordenlocal.DIST_Ordenes.ORDEN_RevisadoControl = m_dist_ordenes.ORDEN_RevisadoControl
            _ordenlocal.DIST_Ordenes.ORDEN_Atendido = True
            _ordenlocal.DIST_Ordenes.ORDEN_MotivoAnulacion = x_motivo
            _ordenlocal.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            If _ordenlocal.Guardar(x_usuario) Then
                '' Actualizar el Egreso de Articulos
                Dim _whereorden As New Hashtable : _whereorden.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenes.ORDEN_Codigo))
                Dim _ordendetalle As New BDIST_OrdenesDetalle
                If _ordendetalle.CargarTodos(_whereorden) Then
                    For Each item As EDIST_OrdenesDetalle In _ordendetalle.ListDIST_OrdenesDetalle
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
    ''' anular Entrega de almacen
    ''' </summary>
    ''' <param name="x_periodo"></param>
    ''' <param name="x_artic_codigo"></param>
    ''' <param name="x_almac_id"></param>
    ''' <param name="x_guiar_codigo"></param>
    ''' <param name="x_guird_item"></param>
    ''' <param name="x_cantidad"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AnularEntregaAlmacen(ByVal x_periodo As String, ByVal x_artic_codigo As String, _
                                       ByVal x_almac_id As Short, ByVal x_guiar_codigo As String, ByVal x_guird_item As Short, _
                                       ByVal x_cantidad As Double, ByVal x_motivo As String, ByVal x_usuario As String, ByRef x_msg As String) As Boolean
        Try
            Dim m_documento As New BDIST_OrdenesDetalle
            m_documento.DIST_OrdenesDetalle = New EDIST_OrdenesDetalle
            Dim _where As New Hashtable
            _where.Add("ARTIC_Codigo", New ACFramework.ACWhere(x_artic_codigo))
            _where.Add("ORDEN_Codigo", New ACFramework.ACWhere(x_guiar_codigo))
            _where.Add("ORDET_Item", New ACFramework.ACWhere(x_guird_item))
            If m_documento.Cargar(_where) Then
                If m_documento.DIST_OrdenesDetalle.ORDET_CantidadEntregada > 0 Then
                    Dim _cant As Decimal = m_documento.DIST_OrdenesDetalle.ORDET_CantidadEntregada
                    m_documento.DIST_OrdenesDetalle = New EDIST_OrdenesDetalle()
                    m_documento.DIST_OrdenesDetalle.Instanciar(ACFramework.ACEInstancia.Modificado)
                    m_documento.DIST_OrdenesDetalle.ORDEN_Codigo = x_guiar_codigo
                    m_documento.DIST_OrdenesDetalle.ARTIC_Codigo = x_artic_codigo
                    m_documento.DIST_OrdenesDetalle.ORDET_Item = x_guird_item
                    m_documento.DIST_OrdenesDetalle.ORDET_Motivo = x_motivo
                    m_documento.DIST_OrdenesDetalle.ORDET_CantidadEntregada = _cant - x_cantidad
                    _cant = _cant - x_cantidad
                    'Return m_documento.Guardar(x_usuario, _cant, True)
                    If m_documento.Guardar(x_usuario, _cant, True) Then
                        x_msg &= String.Format("-{1}-{2}, Cantidad Entregada: {3}. {0}", vbNewLine, _
                                                                x_artic_codigo, m_documento.DIST_OrdenesDetalle.ARTIC_Descripcion, x_cantidad)
                    End If
                    Return x_msg.Length > 0
                Else
                    'Return True
                    x_msg &= String.Format("No se registra entregas en Almacen")
                    Return x_msg.Length > 0
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' anular Entrega de almacen x item ---ordenes
    ''' </summary>
    ''' <param name="x_periodo"></param>
    ''' <param name="x_artic_codigo"></param>
    ''' <param name="x_almac_id"></param>
    ''' <param name="x_guiar_codigo"></param>
    ''' <param name="x_guird_item"></param>
    ''' <param name="x_cantidad"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AnularEntregaAlmacenXItem(ByVal x_orden_codigo As String, ByVal x_artic_codigo As String, ByVal x_ordet_item As Short, _
                                       ByVal x_cantidad As Double, ByVal x_orden_fecha As Date, ByVal m_proceso As Boolean, ByVal x_motivo As String, ByVal x_usuario As String) As Boolean
        Try
            Dim m_documento As New BDIST_OrdenesDetalle
            m_documento.DIST_OrdenesDetalle = New EDIST_OrdenesDetalle()
            Dim _where As New Hashtable
            _where.Add("ARTIC_Codigo", New ACFramework.ACWhere(x_artic_codigo))
            _where.Add("ORDEN_Codigo", New ACFramework.ACWhere(x_orden_codigo))
            _where.Add("ORDET_Item", New ACFramework.ACWhere(x_ordet_item))
            If m_documento.Cargar(_where) Then
                If m_documento.DIST_OrdenesDetalle.ORDET_CantidadEntregada > 0 Then
                    Dim _cant As Decimal = m_documento.DIST_OrdenesDetalle.ORDET_CantidadEntregada
                    m_documento.DIST_OrdenesDetalle = New EDIST_OrdenesDetalle()
                    m_documento.DIST_OrdenesDetalle.Instanciar(ACFramework.ACEInstancia.Modificado)
                    m_documento.DIST_OrdenesDetalle.ORDEN_Codigo = x_orden_codigo
                    m_documento.DIST_OrdenesDetalle.ARTIC_Codigo = x_artic_codigo
                    m_documento.DIST_OrdenesDetalle.ORDET_Item = x_ordet_item
                    m_documento.DIST_OrdenesDetalle.ORDET_Motivo = x_motivo
                    m_documento.DIST_OrdenesDetalle.ORDET_CantidadEntregada = _cant - x_cantidad
                    _cant = _cant - x_cantidad
                    '' Verificar opciones de Anulacion
                    Dim _constantes As New BConstantes
                    Dim _eliFec As Boolean = False
                    If Not _constantes.getFecha().Date = x_orden_fecha.Date Then
                        '' Verificar si el usuario tiene autorizacion
                        If Not m_proceso Then

                            Throw New Exception("No se puede anular una entrega despues de la fecha de emision, consulte con su administrador")

                        End If

                        _eliFec = True
                    End If
                    'Return m_documento.Guardar(x_usuario, _cant, True)
                    If m_documento.Guardar(x_usuario, _cant, True) Then
                        Return True
                    End If
                    Return False
                Else
                    'Return True
                    Return False
                End If
            End If
        Catch ex As Exception
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
            Dim _orden As New BDIST_Ordenes
            _orden.DIST_Ordenes = New EDIST_Ordenes
            _orden.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
            _orden.DIST_Ordenes.ORDEN_UsrImpresion = x_usuario
            _orden.DIST_Ordenes.ORDEN_FecImpresion = DateTime.Now
            _orden.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            _orden.DIST_Ordenes.ORDEN_Impresa = True
            _orden.DIST_Ordenes.ORDEN_Impresiones = _orden.getCorrelativo("ORDEN_Impresiones", _where)
            Return _orden.Guardar(x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ActualizarImpresionP(ByVal x_usuario As String) As Boolean
        Try
            Dim _where As New Hashtable
            _where.Add("ORDEN_Codigo", New ACWhere(m_dist_ordenesp.ORDEN_Codigo))
            Dim _orden As New BABAS_OrdenesProduccion
            _orden.DIST_Ordenes = New EABAS_OrdenesProduccion()
            _orden.DIST_Ordenes.ORDEN_Codigo = m_dist_ordenesp.ORDEN_Codigo
            _orden.DIST_Ordenes.Instanciar(ACEInstancia.Modificado)
            _orden.DIST_Ordenes.ORDEN_Impresa = True
            _orden.DIST_Ordenes.ORDEN_Atendido = True
            _orden.DIST_Ordenes.ORDEN_Impresiones = _orden.getCorrelativo("ORDEN_Impresiones", _where)
            Return _orden.Guardar(x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDocVentaXNumero
    ''' </summary>
    ''' <param name="x_numero">Parametro 1: </param> 
    ''' <param name="x_serie">Parametro 2: </param> 
    ''' <param name="x_tipos_codtipodocumento">Parametro 3: </param> 
    ''' <param name="x_almac_id">Parametro 4: </param> 
    ''' <param name="x_pvent_id">Parametro 5: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function BusquedaDocVentaXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_generarordenes.LOG_DIST_GUIASS_ObtDocVentaXNumero(m_listVENT_DocsVenta, x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDocVenta
    ''' </summary>
    ''' <param name="x_tconsulta">Parametro 1: </param> 
    ''' <param name="x_cadena">Parametro 2: </param> 
    ''' <param name="x_almac_id">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_fecini">Parametro 5: </param> 
    ''' <param name="x_fecfin">Parametro 6: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function BusquedaDocVenta(ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
        Try
            Return d_generarordenes.LOG_DIST_GUIASS_ObtDocVenta(m_listVENT_DocsVenta, x_tconsulta, x_cadena, x_almac_id, x_pvent_id, x_fecini, x_fecfin)
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
    ''' Capa de Negocio: LOG_DIST_GUIASS_ObtDetDocVenta_articulos_a
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetDocVenta_Artic(ByRef x_vent_docsventa As EVENT_DocsVenta, ByVal x_docve_codigo As String, ByVal x_almac_id As Short, ByVal x_artic_codigo As String) As Boolean
        'x_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)

        m_listDIST_VENTADET = New List(Of EVENT_DocsVentaDetalle)

        Try
            Return d_generarordenes.LOG_DIST_GUIASS_ObtDetDocVenta_Artic(m_listDIST_VENTADET, x_docve_codigo, x_almac_id, x_artic_codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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
            Dim m_dist_ordenes As New BDIST_Ordenes
            Return m_dist_ordenes.getCorrelativo("ORDEN_Numero", _where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    ''' <summary>
    ''' obtener el correlativo de la orden de recojo
    ''' </summary>
    ''' <param name="x_tipodoc">serie de la orden de recojo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSerie(ByVal x_tipodoc As String, ByVal x_serie As String) As String
        Try
            Dim _where As New Hashtable
            _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipodoc))
            _where.Add("PVENT_Id", New ACWhere(x_serie))
            Dim m_dist_ordenes As New BDIST_Ordenes
            'Dim m_dist_ordenes As New BVENT_PVentDocumento
            Return m_dist_ordenes.getSerie("PVDOCU_Serie", _where)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function GetImpresion(ByVal x_orden_codigo As String) As Boolean
        Try
            Dim _where As New Hashtable
            _where.Add("ORDEN_Codigo", New ACWhere(x_orden_codigo))
            _where.Add("ORDEN_Impresiones", New ACWhere(1, ACWhere.TipoWhere.MayorIgual))
            Dim m_dist_ordenes As New BDIST_Ordenes
            Return m_dist_ordenes.getImpresion(_where)
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
        m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
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
        m_listDIST_Ordenes = New List(Of EDIST_Ordenes)
        Try
            Return d_generarordenes.LOG_DISTSS_OrdenesXDocumentoL(m_listDIST_Ordenes, x_docve_codigo, x_ALMAC_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

    ''' <summary>
    ''' Dar permiso al documento para volver a imprimir
    ''' </summary>
    ''' <param name="x_codigo">codifo del documento de venta</param>
    ''' <param name="x_value">valor verdadero o falso para el permiso</param>
    ''' <param name="x_usuario">codigo de usuario</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoImpOrden(ByVal x_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try

            Dim _ordenes As New BDIST_Ordenes
            Return _ordenes.SetPermisoImpOrden(x_codigo, x_value, x_usuario)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Dar permiso al documento para anular
    ''' </summary>
    ''' <param name="x_codigo">codifo del documento de venta</param>
    ''' <param name="x_value">valor verdadero o falso para el permiso</param>
    ''' <param name="x_usuario">codigo de usuario</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoAnularOrden(ByVal x_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try

            Dim _ordenes As New BDIST_Ordenes
            Return _ordenes.SetPermisoAnularOrden(x_codigo, x_value, x_usuario)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Dar permiso al documento de venta para poder geenerar guia de remision
    ''' </summary>
    ''' <param name="x_codigo">codifo del documento de venta</param>
    ''' <param name="x_value">valor verdadero o falso para el permiso</param>
    ''' <param name="x_usuario">codigo de usuario</param>
    ''' <param name="x_docventa">clase documento de venta</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoGenGuia(ByVal x_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try

            Dim _ordenes As New BDIST_Ordenes
            Return _ordenes.SetPermisoGenGuia(x_codigo, x_value, x_usuario)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' cargar el documento de venta
    ''' </summary>
    ''' <param name="x_codigo">codigo del documento de venta</param>
    ''' <param name="x_almac_id">codigo del almacen</param>
    ''' <param name="x_opcion">cargar el detalle del documento de venta</param>
    ''' <param name="x_ordenes">opcion para saber si son ordenes de documentos de venta</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function cargar(ByVal x_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Boolean, ByVal x_ordenes As Boolean) As Boolean
        Try
            'Dim m_bvent_docsventa As New BVENT_DocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
            If x_ordenes Then
                Dim m_bdist_ordenes As New BDIST_Ordenes
                If m_bdist_ordenes.ObtenerOrden(x_codigo, False) Then
                    m_dist_ordenes = New EDIST_Ordenes()
                    m_dist_ordenes = m_bdist_ordenes.DIST_Ordenes
                    If x_opcion Then
                        m_dist_ordenes.ListDIST_OrdenesDetalle = New List(Of EDIST_OrdenesDetalle)
                        If DIST_Alm_ObtDetDocVenta(x_codigo, x_almac_id) Then
                            Return True
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
                    '    m_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                    'If ObtDetOrdenes(m_event_docsventa.ListVENT_DocsVentaDetalle, m_dist_ordenes.DIST_Ordenes.ORDEN_Codigo, 1) Then
                    '    '        Return True
                    '    '    Else
                    '    '        Return True
                    'End If
                    '    Return False
                End If
                Return False
            Else
                'If m_bvent_docsventa.Cargar(x_codigo, False) Then
                '    m_event_docsventa = New EVENT_DocsVenta()
                '    m_event_docsventa = m_bvent_docsventa.VENT_DocsVenta
                '    Dim x_orden As String = ETipos.getTipoDocTraslado(ETipos.TipoDocsTraslado.GuiaRemisionRemitente)
                '    If x_opcion Then
                '        m_event_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                '        If VENT_Alm_ObtDetDocVenta(x_codigo, x_almac_id) Then
                '            Return True
                '        Else
                '            Return True
                '        End If
                '    Else
                '        Return True
                '    End If
                'End If
                'Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary> 
    ''' Capa de Negocio: DIST_Alm_ObtDetDocVenta
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function DIST_Alm_ObtDetDocVenta(ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
        m_dist_ordenes.ListDIST_OrdenesDetalle = New List(Of EDIST_OrdenesDetalle)
        Try
            Return d_generarordenes.DIST_Alm_ObtDetOrden(m_dist_ordenes.ListDIST_OrdenesDetalle, x_docve_codigo, x_almac_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#Region " Metodos de Controles"

#End Region
End Class

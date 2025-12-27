Imports System

Imports ACEVentas
Imports ACDVentas
Imports ACBLogistica
Imports System.Configuration
Imports ACFramework
Imports DAConexion

Public Class BGenerarCotizacion

#Region " Variables "
   Private m_dtGenerarCotizacion As DataTable

   Private ds_generarcotizacion As DataSet

   Private d_generarcotizacion As DGenerarCotizacion

   Private m_tipocambio As ETipoCambio
   Private m_event_pedidos As EVENT_Pedidos
   Private m_evendedor As EEntidades

   Private m_listPrecios As List(Of EPPrecios)
   Private m_listVENT_Pedidos As List(Of EVENT_Pedidos)

   Private d_vent_pventdocumento As DVENT_PVentDocumento
   Private m_listVENT_PVentDocumento As List(Of EVENT_PVentDocumento)


   Private m_periodo As String
#End Region

#Region " Constructores "
   Public Sub New(ByVal x_periodo As String)
      d_generarcotizacion = New DGenerarCotizacion()
      m_periodo = x_periodo
   End Sub
#End Region

#Region " Propiedades "

   Public Property TipoCambio() As ETipoCambio
      Get
         Return m_tipocambio
      End Get
      Set(ByVal value As ETipoCambio)
         m_tipocambio = value
      End Set
   End Property

   Public Property VENT_Pedidos() As EVENT_Pedidos
      Get
         Return m_event_pedidos
      End Get
      Set(ByVal value As EVENT_Pedidos)
         m_event_pedidos = value
      End Set
   End Property

   Public Property Vendedor() As EEntidades
      Get
         Return m_evendedor
      End Get
      Set(ByVal value As EEntidades)
         m_evendedor = value
      End Set
   End Property

   Public Property ListPrecios() As List(Of EPPrecios)
      Get
         Return m_listPrecios
      End Get
      Set(ByVal value As List(Of EPPrecios))
         m_listPrecios = value
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

   Public Property ListVENT_PVentDocumento() As List(Of EVENT_PVentDocumento)
      Get
         Return m_listVENT_PVentDocumento
      End Get
      Set(ByVal value As List(Of EVENT_PVentDocumento))
         m_listVENT_PVentDocumento = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Obtener la fecha de servidor de base de datos
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetFecha() As DateTime
      Try
         Return d_generarcotizacion.getDateTime()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
   Public Function orden_compra(ByVal orden As String,ByVal documento As String) As Boolean
      Try
         Return d_generarcotizacion.obtener_orden_compra(orden,documento)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener los datos del vendedor
   ''' </summary>
   ''' <param name="x_entid_codigo">Codigo del vendedor</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getVendedor(ByVal x_entid_codigo As String) As Boolean
      Try
         Dim m_bentidad As New BEntidades
         If m_bentidad.Cargar(x_entid_codigo) Then
            m_evendedor = m_bentidad.Entidades
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el ultimo tipo de cambio, de oficina y el de sunat por separado
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getTipoCambio() As Boolean
      Try
         Dim b_tipocambio As New BTipoCambio()
         m_tipocambio = New ETipoCambio
         If b_tipocambio.getUltTipoCambioOficina() Then
            m_tipocambio.TIPOC_VentaOficina = b_tipocambio.TipoCambio.TIPOC_VentaOficina
            m_tipocambio.TIPOC_CompraOficina = b_tipocambio.TipoCambio.TIPOC_CompraOficina
         End If
         If b_tipocambio.getUltTipoCambioSunat() Then
            m_tipocambio.TIPOC_CompraSunat = b_tipocambio.TipoCambio.TIPOC_CompraSunat
            m_tipocambio.TIPOC_VentaSunat = b_tipocambio.TipoCambio.TIPOC_VentaSunat
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Buscar en los padrones si un cliente tiene una calificación especial
   ''' </summary>
   ''' <param name="x_entid_codigo">Codigo del cliente</param>
   ''' <param name="x_parametro">Parametro con el porcentaje de la percepcion que le corresponde</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getPercepcion(ByVal x_entid_codigo As String, ByVal x_parametro As Decimal) As Decimal
      Dim _bentidadespadrones As New BEntidadesPadrones
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoPadron")}, _
                              New ACCampos() {New ACCampos("TIPOS_Numero", "TIPOS_TipoPadron")}))

         Dim _where As New Hashtable()
         _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
         If _bentidadespadrones.CargarTodos(_join, _where) Then
            Dim _base As Decimal = 2
            For Each item As EEntidadesPadrones In _bentidadespadrones.ListEntidadesPadrones
               If _base >= item.TIPOS_TipoPadron Then
                  _base = item.TIPOS_TipoPadron
               End If
            Next
            Return _base
         Else
            Return x_parametro
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar Un pedido y su respectivo detalle
   ''' </summary>
   ''' <param name="x_usuario">Usuario que crea el pedido</param>
   ''' <param name="x_zonas_codigo">Codigo de la Zona de creacion</param>
   ''' <param name="x_sucur_id">Sucursal donde se crea</param>
   ''' <param name="x_pvent_id">Punto de venta que crea el pedido</param>
   ''' <param name="x_msg">Mensaje devuelto en caso de haber algun error o observacion con respecto al proceso de grabado</param>
   ''' <returns>True: Cuando culmina el grabado correctamente</returns>
   ''' <remarks></remarks>
   Public Function GrabarPedidoCotizacion(ByVal x_usuario As String, ByVal x_zonas_codigo As String _
                                          , ByVal x_sucur_id As Long, ByVal x_pvent_id As Long, ByVal x_almac_id As Short, ByRef x_msg As String _
                                          , ByVal x_tipo As EVENT_Pedidos.TipoPedido) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         m_bvent_pedidos.VENT_Pedidos.SUCUR_Id = x_sucur_id
         m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo = x_zonas_codigo
         m_bvent_pedidos.VENT_Pedidos.PVENT_Id = x_pvent_id
         If m_bvent_pedidos.VENT_Pedidos.Nuevo Then m_bvent_pedidos.VENT_Pedidos.PEDID_Id = m_bvent_pedidos.getCorrelativo("PEDID_Id")  
         '' Iniciar transaccion
         DAEnterprise.BeginTransaction()
         If m_bvent_pedidos.Guardar(x_usuario) Then
            Dim i As Integer = 1
            '' Grabar los detalles
            For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
               Item.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
               Item.PDDET_Item = i
               'Item.ALMAC_Id = x_almac_id
               Item.ZONAS_Codigo = m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo
               Item.Instanciar(ACEInstancia.Nuevo)
               i += 1
               Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle() With {.VENT_PedidosDetalle = Item}
               If m_bvent_pedidosdetalle.Guardar(x_usuario) Then
                  Select Case x_tipo
                     Case EVENT_Pedidos.TipoPedido.PD
                        '' Descontar Stock del Articulo si es un pedido, de forma directa
                        Dim m_bmanejarstocks As New BManejarStock()
                        m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                        m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = Item.PEDID_Codigo
                        m_bmanejarstocks.LOG_Stocks.PDDET_Item = Item.PDDET_Item
                        m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.Articulo.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.PDDET_Cantidad, m_bvent_pedidos.VENT_Pedidos.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPedido), x_usuario)
                     Case EVENT_Pedidos.TipoPedido.PI
                        '' Descontar Stock del Articulo si es un pedido, de forma directa
                        Dim m_bmanejarstocks As New BManejarStock()
                        m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                        m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = Item.PEDID_Codigo
                        m_bmanejarstocks.LOG_Stocks.PDDET_Item = Item.PDDET_Item
                        m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.Articulo.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.PDDET_Cantidad, m_bvent_pedidos.VENT_Pedidos.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPedido), x_usuario)
                  End Select
               Else
                  Throw New Exception(String.Format("No se pudo grabar el item {0} de articulo {1}, consulte con el administrador", Item.PDDET_Item, Item.ARTIC_Descripcion))
               End If
                Next
                '' Cambiar Estado de Facturar Pedido Anterior
                If Not IsNothing(m_bvent_pedidos.VENT_Pedidos.PEDID_CodRelacionado) Then
                    Dim _pedido As New BVENT_Pedidos
                    _pedido.VENT_Pedidos = New EVENT_Pedidos
                    _pedido.VENT_Pedidos.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_CodRelacionado
                    _pedido.VENT_Pedidos.PEDID_DocumentoPercepcion = m_bvent_pedidos.VENT_Pedidos.PEDID_DocumentoPercepcion
                    _pedido.VENT_Pedidos.PEDID_ParaFacturar = False
                    _pedido.VENT_Pedidos.PEDID_GenerarGuia = m_bvent_pedidos.VENT_Pedidos.PEDID_GenerarGuia
                    _pedido.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Rehusado)
                    _pedido.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
                    _pedido.Guardar(x_usuario)
                End If
            Else
                DAEnterprise.RollBackTransaction()
                x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
                Return False
            End If
         '' Completar Operaciones adicionales con el Pedido/Cotizacion

         '' Culminar la transaccion
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar un pedido de reposicioncon su respectivo detalle
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_zonas_codigo">Codigo de la zona</param>
   ''' <param name="x_sucur_id">Codigo de la sucursal</param>
   ''' <param name="x_pvent_id">Codigo del punto de venta</param>
   ''' <param name="x_almac_id">Codigo del almacen</param>
   ''' <param name="x_msg">Mensaje devuelto en caso de existir algun error o limitacion de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarPedidoReposicion(ByVal x_usuario As String, ByVal x_zonas_codigo As String _
                                       , ByVal x_sucur_id As Long, ByVal x_pvent_id As Long, ByVal x_almac_id As Short, ByRef x_msg As String) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         m_bvent_pedidos.VENT_Pedidos.SUCUR_Id = x_sucur_id
         m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo = x_zonas_codigo
         m_bvent_pedidos.VENT_Pedidos.PVENT_Id = x_pvent_id
         If m_bvent_pedidos.VENT_Pedidos.Nuevo Then m_bvent_pedidos.VENT_Pedidos.PEDID_Id = m_bvent_pedidos.getCorrelativo("PEDID_Id")
         '' Verificar si el Pedido ya fue confirmado
         Dim _bpedido As New BVENT_Pedidos
         If _bpedido.Cargar(m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo) Then
            If _bpedido.VENT_Pedidos.PEDID_Estado.Equals(Constantes.getEstado(Constantes.Estado.Confirmado)) Then
               Throw New Exception(String.Format("El pedido: {0} ya fue confirmado, Ud ya no puede modificar este pedido", _bpedido.VENT_Pedidos.PEDID_Numero))
            End If
         End If

         '' Iniciar transaccion
         DAEnterprise.BeginTransaction()
         If m_bvent_pedidos.Guardar(x_usuario) Then
            Dim i As Integer = 1

            Dim _pedidosdetalle As New BVENT_PedidosDetalle
            Dim _where As New Hashtable
            _where.Add("PEDID_Codigo", New ACWhere(m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo))
            _pedidosdetalle.Eliminar(_where)

            '' Grabar los detalles
            For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
               Item.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
               Item.PDDET_Item = i
               'Item.ALMAC_Id = x_almac_id
               Item.ZONAS_Codigo = m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo
               Item.Instanciar(ACEInstancia.Nuevo)
               i += 1
               Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle() With {.VENT_PedidosDetalle = Item}
               m_bvent_pedidosdetalle.Guardar(x_usuario)

            Next
            '' Cambiar Estado de Facturar Pedido Anterior
            If Not IsNothing(m_bvent_pedidos.VENT_Pedidos.PEDID_CodRelacionado) Then
               Dim _pedido As New BVENT_Pedidos
               _pedido.VENT_Pedidos = New EVENT_Pedidos
               _pedido.VENT_Pedidos.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_CodRelacionado
               _pedido.VENT_Pedidos.PEDID_ParaFacturar = False
               _pedido.VENT_Pedidos.PEDID_GenerarGuia = m_bvent_pedidos.VENT_Pedidos.PEDID_GenerarGuia
               _pedido.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
               _pedido.Guardar(x_usuario)
            End If
         Else
            DAEnterprise.RollBackTransaction()
            x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
            Return False
         End If
         '' Completar Operaciones adicionales con el Pedido/Cotizacion

         '' Culminar la transaccion
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar la atencion de un pedido de reposicion, el cual genera una separacion de stock en el lugar donde es atendido
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_zonas_codigo">Codigo de la Zona</param>
   ''' <param name="x_sucur_id">Codigo de la sucursal</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <param name="x_almac_id">codigo del almacen</param>
   ''' <param name="x_msg">mensaje devuelto en caso de existir algun inconveniente</param>
   ''' <param name="x_generarvariosdocumentos">Opcion que permite generar varios pedidos al aceptar un solo pedido</param>
   ''' <param name="x_items">Numero de items que tiene el pendid</param>
   ''' <param name="x_documentos">Numero de documentos que se esta generando</param>
   ''' <param name="x_modreposicion"></param>
   ''' <returns>Devuelve verdadero si se completa la genereacion de documentos</returns>
   ''' <remarks></remarks>
   Public Function GrabarPedidoReposicionAtendida(ByVal x_usuario As String, ByVal x_zonas_codigo As String, _
                                                  ByVal x_sucur_id As Long, ByVal x_pvent_id As Long, ByVal x_almac_id As Short, ByRef x_msg As String, _
                                                  ByVal x_generarvariosdocumentos As Boolean, ByVal x_items As Integer, ByVal x_documentos As Integer, ByVal x_modreposicion As Boolean) As Boolean
      Try
         '' Iniciar transaccion

    

         DAEnterprise.BeginTransaction()
         If x_generarvariosdocumentos Then
            Dim _listPedidos As New List(Of EVENT_Pedidos)
            Dim _cont As Integer = 0
            For index = 1 To x_documentos
               Dim _pedido As EVENT_Pedidos = m_event_pedidos.Clone()
               _pedido.ListDetPedidos = New List(Of EVENT_PedidosDetalle)
               _pedido.Instanciar(ACEInstancia.Nuevo)
               Dim _where As New Hashtable
               _where.Add("PVENT_Id", New ACWhere(x_pvent_id))
               _where.Add("PEDID_Tipo", New ACWhere(EVENT_Pedidos.TipoPedido.PR.ToString().Substring(1, 1)))
               Dim m_cotizacion As New BVENT_Pedidos
               _pedido.PEDID_Numero = m_cotizacion.getCorrelativo("PEDID_Numero", _where)
               _pedido.PEDID_Codigo = String.Format("{0}{1:000}{2:0000000}", EVENT_Pedidos.TipoPedido.PR.ToString(), _pedido.PVENT_Id, _pedido.PEDID_Numero)
               For item = _cont To (x_items + _cont - 1)
                  _pedido.ListDetPedidos.Add(m_event_pedidos.ListDetPedidos(item))
                  If item = m_event_pedidos.ListDetPedidos.Count - 1 Then
                     Exit For
                  End If
               Next
               _cont += x_items
               '' Grabar El Pedido
               Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = _pedido}
               m_bvent_pedidos.VENT_Pedidos.SUCUR_Id = x_sucur_id
               m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo = x_zonas_codigo
               m_bvent_pedidos.VENT_Pedidos.PVENT_Id = x_pvent_id
               If m_bvent_pedidos.VENT_Pedidos.Nuevo Then m_bvent_pedidos.VENT_Pedidos.PEDID_Id = m_bvent_pedidos.getCorrelativo("PEDID_Id")

          If m_bvent_pedidos.Guardar(x_usuario) Then
                  Dim i As Integer = 1
                  '' Eliminar el Detalle para volverlo a ingresar
                  Dim _whereEli As New Hashtable
                  _whereEli.Add("PEDID_Codigo", New ACWhere(m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo))
                  Dim _blog_stock As New ACBLogistica.BLOG_Stocks : _blog_stock.Eliminar(_whereEli)
                  Dim _bvent_pedidosdetalle As New BVENT_PedidosDetalle : _bvent_pedidosdetalle.Eliminar(_whereEli)
                  '' Grabar los detalles
                  For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
                     Item.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
                     Item.PDDET_Item = i
                     'Item.ALMAC_Id = x_almac_id
                     Item.ZONAS_Codigo = m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo
                     Item.Instanciar(ACEInstancia.Nuevo)
                     i += 1
                     Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle() With {.VENT_PedidosDetalle = Item}
                     m_bvent_pedidosdetalle.Guardar(x_usuario)
                     If IsNothing(Item.Articulo) Then
                        Dim _artic As New BArticulos
                        If _artic.Cargar(Item.ARTIC_Codigo) Then
                           Item.Articulo = _artic.Articulos
                        Else
                           Throw New Exception("No se puede cargar el articulo")
                        End If
                     End If
                     '' Descontar Stock del Articulo si es un pedido, de forma directa
                     Dim m_bmanejarstocks As New BManejarStock()
                     m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                     m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = Item.PEDID_Codigo
                     m_bmanejarstocks.LOG_Stocks.PDDET_Item = Item.PDDET_Item
                     m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.Articulo.TIPOS_CodUnidadMedida, x_almac_id, Item.PDDET_Cantidad, _
                                             m_bvent_pedidos.VENT_Pedidos.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPedidoReposicion), x_usuario)
                  Next
                  '' Cambiar Estado de Facturar Pedido Anterior

               Else
                  DAEnterprise.RollBackTransaction()
                  x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
                  Return False
               End If
            Next


         Else
            Dim m_bvent_PEDEA As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}

            If m_bvent_PEDEA.Cargar(m_bvent_PEDEA.VENT_Pedidos.PEDID_Codigo) Then
                If m_bvent_PEDEA.VENT_Pedidos.PEDID_Estado.Equals(Constantes.getEstado(Constantes.Estado.Confirmado)) Then
                   Throw New Exception(String.Format("El pedido: {0} ya fue confirmado, Ud ya no puede modificar este pedido", m_bvent_PEDEA.VENT_Pedidos.PEDID_Numero))
                End If
            End If


            Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
            m_bvent_pedidos.VENT_Pedidos.SUCUR_Id = x_sucur_id
            m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo = x_zonas_codigo
            m_bvent_pedidos.VENT_Pedidos.PVENT_Id = x_pvent_id
            If m_bvent_pedidos.VENT_Pedidos.Nuevo Then m_bvent_pedidos.VENT_Pedidos.PEDID_Id = m_bvent_pedidos.getCorrelativo("PEDID_Id")
            If m_bvent_pedidos.Guardar(x_usuario) Then
               Dim i As Integer = 1
               '' Eliminar el Detalle para volverlo a ingresar
               Dim _whereEli As New Hashtable
               _whereEli.Add("PEDID_Codigo", New ACWhere(m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo))
               Dim _blog_stock As New ACBLogistica.BLOG_Stocks : _blog_stock.Eliminar(_whereEli)
               Dim _bvent_pedidosdetalle As New BVENT_PedidosDetalle : _bvent_pedidosdetalle.Eliminar(_whereEli)
               '' Grabar los detalles
               For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
                  Item.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
                  Item.PDDET_Item = i
                  'Item.ALMAC_Id = x_almac_id
                  Item.ZONAS_Codigo = m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo
                  Item.Instanciar(ACEInstancia.Nuevo)
                  i += 1
                  Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle() With {.VENT_PedidosDetalle = Item}
                  m_bvent_pedidosdetalle.Guardar(x_usuario)
                  If IsNothing(Item.Articulo) Then
                     Dim _artic As New BArticulos
                     If _artic.Cargar(Item.ARTIC_Codigo) Then
                        Item.Articulo = _artic.Articulos
                     Else
                        Throw New Exception("No se puede cargar el articulo")
                     End If
                  End If
                  ' Descontar Stock del Articulo si es un pedido, de forma directa
                  Dim m_bmanejarstocks As New BManejarStock()
                  m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                  m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = Item.PEDID_Codigo
                  m_bmanejarstocks.LOG_Stocks.PDDET_Item = Item.PDDET_Item
                  m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.Articulo.TIPOS_CodUnidadMedida, x_almac_id, Item.PDDET_Cantidad, _
                                          m_bvent_pedidos.VENT_Pedidos.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPedidoReposicion), x_usuario)
               Next
            Else
               DAEnterprise.RollBackTransaction()
               x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
               Return False
            End If
            '' Completar Operaciones adicionales con el Pedido/Cotizacion
         End If
         '' Culminar la transaccion
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

#Region " Pedido de Separacion "

   ''' <summary>
   ''' Grabar el pedido de separación con su respectivo detalle
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_zonas_codigo">Codigo de zonas</param>
   ''' <param name="x_sucur_id">Codigo de la sucursal</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <param name="x_almac_id">codigo del almacen</param>
   ''' <param name="x_pconfirmar">Permiso para completar la confirmacion del grabado de stock</param>
   ''' <param name="x_pmodconfirmado"></param>
   ''' <returns>Obtener la fe</returns>
   ''' <remarks></remarks>
   Public Function GrabarPedidoSeparacionConfirmado(ByVal x_usuario As String, ByVal x_zonas_codigo As String, _
                                          ByVal x_sucur_id As Long, ByVal x_pvent_id As Long, ByVal x_almac_id As Short, _
                                          ByVal x_pconfirmar As Boolean, ByVal x_pmodconfirmado As Boolean) As Boolean
      Try
         '' Iniciar transaccion
         DAEnterprise.BeginTransaction()
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         m_bvent_pedidos.VENT_Pedidos.SUCUR_Id = x_sucur_id
         m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo = x_zonas_codigo
         m_bvent_pedidos.VENT_Pedidos.PVENT_Id = x_pvent_id
         If m_bvent_pedidos.VENT_Pedidos.Nuevo Then m_bvent_pedidos.VENT_Pedidos.PEDID_Id = m_bvent_pedidos.getCorrelativo("PEDID_Id")
         If m_bvent_pedidos.Guardar(x_usuario) Then
            Dim i As Integer = 1
            '' Eliminar el Detalle para volverlo a ingresar
            Dim _whereEli As New Hashtable
            _whereEli.Add("PEDID_Codigo", New ACWhere(m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo))
            Dim _blog_stock As New ACBLogistica.BLOG_Stocks : _blog_stock.Eliminar(_whereEli)
            Dim _bvent_pedidosdetalle As New BVENT_PedidosDetalle : _bvent_pedidosdetalle.Eliminar(_whereEli)
            '' Grabar los detalles
            For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
               Item.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
               Item.PDDET_Item = i
               'Item.ALMAC_Id = x_almac_id
               Item.ZONAS_Codigo = m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo
               Item.Instanciar(ACEInstancia.Nuevo)
               i += 1
               Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle() With {.VENT_PedidosDetalle = Item}
               m_bvent_pedidosdetalle.Guardar(x_usuario)
               If IsNothing(Item.Articulo) Then
                  Dim _artic As New BArticulos
                  If _artic.Cargar(Item.ARTIC_Codigo) Then
                     Item.Articulo = _artic.Articulos
                  Else
                     Throw New Exception("No se puede cargar el articulo")
                  End If
               End If
               ' Descontar Stock del Articulo si es un pedido, de forma directa
               Dim m_bmanejarstocks As New BManejarStock()
               m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
               m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = Item.PEDID_Codigo
               m_bmanejarstocks.LOG_Stocks.PDDET_Item = Item.PDDET_Item
               m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.Articulo.TIPOS_CodUnidadMedida, x_almac_id, Item.PDDET_Cantidad, _
                                       m_bvent_pedidos.VENT_Pedidos.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPedidoReposicion), x_usuario)
            Next
         Else
            Throw New Exception(String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine))
         End If
         '' Culminar la transaccion
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Greabar pedido de separacion de mercaderia
   ''' </summary>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <param name="x_zonas_codigo">Codigo de la zon</param>
   ''' <param name="x_sucur_id">Codigo de la sucursal</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <param name="x_almac_id">codigo del almacen</param>
   ''' <param name="x_confirmar">permiso para confirmar el pedido</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarPedidoSeparacion(ByVal x_usuario As String, ByVal x_zonas_codigo As String, _
                                          ByVal x_sucur_id As Long, ByVal x_pvent_id As Long, ByVal x_almac_id As Short, _
                                          ByVal x_confirmar As Boolean) As Boolean
      Try
         '' Iniciar transaccion
         DAEnterprise.BeginTransaction()
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         m_bvent_pedidos.VENT_Pedidos.SUCUR_Id = x_sucur_id
         m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo = x_zonas_codigo
         m_bvent_pedidos.VENT_Pedidos.PVENT_Id = x_pvent_id
         If m_bvent_pedidos.VENT_Pedidos.Nuevo Then m_bvent_pedidos.VENT_Pedidos.PEDID_Id = m_bvent_pedidos.getCorrelativo("PEDID_Id")
         If m_bvent_pedidos.VENT_Pedidos.PEDID_Estado.Equals(EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Ingresado)) Then
            If x_confirmar Then
               Dim _where As New Hashtable : _where.Add("PEDID_Codigo", New ACWhere(m_bvent_pedidos.VENT_Pedidos.DOCVE_Codigo))
               Dim _stocks As New BLOG_Stocks : _stocks.Eliminar(_where)
            Else
               Throw New Exception("Ud. No puede modificar un pedido que ya fue cponfirmado")
            End If
         Else
            If x_confirmar Then
               m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
            End If
         End If

         If m_bvent_pedidos.Guardar(x_usuario) Then
            Dim i As Integer = 1
            '' Eliminar el Detalle para volverlo a ingresar
            Dim _whereEli As New Hashtable : _whereEli.Add("PEDID_Codigo", New ACWhere(m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo))
            Dim _bvent_pedidosdetalle As New BVENT_PedidosDetalle : _bvent_pedidosdetalle.Eliminar(_whereEli)
            '' Grabar los detalles
            For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
               Item.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
               Item.PDDET_Item = i
               'Item.ALMAC_Id = x_almac_id
               Item.ZONAS_Codigo = m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo
               Item.Instanciar(ACEInstancia.Nuevo)
               i += 1
               Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle() With {.VENT_PedidosDetalle = Item}
               m_bvent_pedidosdetalle.Guardar(x_usuario)
               If x_confirmar Then
                  Dim m_bmanejarstocks As New BManejarStock()
                  m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                  m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = Item.PEDID_Codigo
                  m_bmanejarstocks.LOG_Stocks.PDDET_Item = Item.PDDET_Item
                  m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.Articulo.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.PDDET_Cantidad, m_event_pedidos.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPedido), x_usuario)
               End If

               If IsNothing(Item.Articulo) Then
                  Dim _artic As New BArticulos
                  If _artic.Cargar(Item.ARTIC_Codigo) Then
                     Item.Articulo = _artic.Articulos
                  Else
                     Throw New Exception("No se puede cargar el articulo")
                  End If
               End If
            Next
         Else
            Throw New Exception(String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine))
         End If
         '' Culminar la transaccion
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Confirmar el pedido de separacion
   ''' </summary>
   ''' <param name="x_pedid_codigo">Codigo del pedido</param>
   ''' <param name="x_usuario">codigo del usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ConfirmarPedidoSeparacion(ByVal x_pedid_codigo As String, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
         If m_bvent_pedidos.Guardar(x_usuario) Then
            For Each Item As EVENT_PedidosDetalle In m_event_pedidos.ListDetPedidos
               Dim m_bmanejarstocks As New BManejarStock()
               m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
               m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = Item.PEDID_Codigo
               m_bmanejarstocks.LOG_Stocks.PDDET_Item = Item.PDDET_Item
               If IsNothing(Item.Articulo) Then
                  Dim _artic As New BArticulos
                  If _artic.Cargar(Item.ARTIC_Codigo) Then
                     Item.Articulo = _artic.Articulos
                  Else
                     Throw New Exception("No se puede cargar el articulo")
                  End If
               End If
               m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.Articulo.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.PDDET_Cantidad, m_event_pedidos.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPedido), x_usuario)
            Next
            DAEnterprise.CommitTransaction()
            Return True
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Desconfirmar pedido de separacion
   ''' </summary>
   ''' <param name="x_pedid_codigo">Codigo del pedido a desconfirmar</param>
   ''' <param name="x_usuario">Codigo del usuario</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function DesConfirmarPedidoSeparacion(ByVal x_pedid_codigo As String, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Nuevo)
         If m_bvent_pedidos.Guardar(x_usuario) Then
            Dim _where As New Hashtable : _where.Add("PEDID_Codigo", New ACWhere(x_pedid_codigo))
            Dim _stocks As New BLOG_Stocks : _stocks.Eliminar(_where)
            DAEnterprise.CommitTransaction()
            Return True
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Anular pedido de separacion de mercaderia
   ''' </summary>
   ''' <param name="x_pedid_codigo">Codigo del pedido</param>
   ''' <param name="x_confirmado">Valor del permiso de confirmacion</param>
   ''' <param name="x_usuario">Codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AnularPedidoSeparacion(ByVal x_pedid_codigo As String, ByVal x_confirmado As Boolean, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado)
         If m_bvent_pedidos.Guardar(x_usuario) Then
            If x_confirmado Then
               If m_bvent_pedidos.Cargar(x_pedid_codigo, True) Then
                  For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
                     Dim m_bmanejarstocks As New BManejarStock()
                     If Not m_bmanejarstocks.AnulacionPedidoSeparacion(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, Item.PEDID_Codigo, Item.PDDET_Item, Item.PDDET_Cantidad, x_usuario) Then
                        DAEnterprise.RollBackTransaction()
                        Return False
                     End If
                  Next
               End If
            End If
            DAEnterprise.CommitTransaction()
            Return True
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Graba rpedido de separación para pasar a facturacion
   ''' </summary>
   ''' <param name="x_usuario">Codigo del usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarPedidoSeparacionParaFacturar(ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
         If m_bvent_pedidos.Guardar(x_usuario) Then
            For Each item As EVENT_PedidosDetalle In m_event_pedidos.ListDetPedidos
               Dim m_detalle As New BVENT_PedidosDetalle
               m_detalle.VENT_PedidosDetalle = item
               m_detalle.VENT_PedidosDetalle.Instanciar(ACEInstancia.Modificado)
               m_detalle.Guardar(x_usuario)
            Next
            DAEnterprise.CommitTransaction()
            Return True
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function
#End Region

   ''' <summary>
   ''' Grabar el pedido de la cotizacion de forma rapida.
   ''' </summary>
   ''' <param name="x_usuario">Usuario que guarda la cotizacion</param>
   ''' <param name="x_msg">Mensaje devuelto en caso de falla</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabaPedidoCotizacion(ByVal x_usuario As String, ByRef x_msg As String, ByVal x_tipo As EVENT_Pedidos.TipoPedido) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         '' Iniciar transaccion
         DAEnterprise.BeginTransaction()

         '' Verificar el tipo de pedido
         Select Case x_tipo
            Case EVENT_Pedidos.TipoPedido.PI
               Dim _whereEli As New Hashtable
               _whereEli.Add("PEDID_Codigo", New ACWhere(m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo))
               Dim _blog_stock As New ACBLogistica.BLOG_Stocks : _blog_stock.Eliminar(_whereEli)
               Dim _bvent_pedidosdetalle As New BVENT_PedidosDetalle : _bvent_pedidosdetalle.Eliminar(_whereEli)
         End Select

         If m_bvent_pedidos.Guardar(x_usuario) Then
            '' Grabar los detalles
            Dim _i As Integer = 1
            For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
               Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle() With {.VENT_PedidosDetalle = Item}
               m_bvent_pedidosdetalle.VENT_PedidosDetalle.Instanciar(ACEInstancia.Nuevo)
               m_bvent_pedidosdetalle.VENT_PedidosDetalle.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
               m_bvent_pedidosdetalle.VENT_PedidosDetalle.PDDET_Item = _i
               m_bvent_pedidosdetalle.VENT_PedidosDetalle.ZONAS_Codigo = m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo
               m_bvent_pedidosdetalle.Guardar(x_usuario)
               Select Case x_tipo
                  Case EVENT_Pedidos.TipoPedido.PI
                     '' Descontar Stock del Articulo si es un pedido, de forma directa
                     Dim m_bmanejarstocks As New BManejarStock()
                     m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                     m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = Item.PEDID_Codigo
                     m_bmanejarstocks.LOG_Stocks.PDDET_Item = Item.PDDET_Item
                     m_bmanejarstocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.Articulo.TIPOS_CodUnidadMedida, Item.ALMAC_Id, Item.PDDET_Cantidad, m_bvent_pedidos.VENT_Pedidos.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaPedido), x_usuario)
               End Select
               _i += 1
            Next
         Else
            DAEnterprise.RollBackTransaction()
            x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
            Return False
         End If
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

     Public Function GrabaOrdenCorte(ByVal x_usuario As String, ByRef x_msg As String) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_bvent_pedidos As New BVENT_Pedidos() With {.VENT_Pedidos = m_event_pedidos}
         '' Iniciar transaccion
         DAEnterprise.BeginTransaction()

        
         If m_bvent_pedidos.Guardar(x_usuario) Then
            '' Grabar los detalles
            Dim _i As Integer = 1
            For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
               Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle() With {.VENT_PedidosDetalle = Item}
               m_bvent_pedidosdetalle.VENT_PedidosDetalle.Instanciar(ACEInstancia.Nuevo)
               m_bvent_pedidosdetalle.VENT_PedidosDetalle.PEDID_Codigo = m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo
               m_bvent_pedidosdetalle.VENT_PedidosDetalle.PDDET_Item = _i
               m_bvent_pedidosdetalle.VENT_PedidosDetalle.ZONAS_Codigo = m_bvent_pedidos.VENT_Pedidos.ZONAS_Codigo
               m_bvent_pedidosdetalle.Guardar(x_usuario)
              
               _i += 1
            Next
         Else
            DAEnterprise.RollBackTransaction()
            x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
            Return False
         End If
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function



   ''' <summary>
   ''' Anular cotizacion de ventas
   ''' </summary>
   ''' <param name="x_codigo">codigo de pedido a ser anulado</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function AnularCotizacion(ByVal x_codigo As String, ByVal x_usuario As String) As Boolean
      Dim m_bvent_pedidos As New BVENT_Pedidos
      m_bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
      Try
         m_bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
         m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_codigo
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado)
         Return m_bvent_pedidos.Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
    End Function

    ''' <summary>
    ''' Eliminar Orden de corte
    ''' </summary>
    ''' <param name="x_codigo">codigo de pedido a ser anulado</param>
    ''' <param name="x_usuario">codigo de usuario</param>
    ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
    ''' <remarks></remarks>
    Public Function EliminarOrdenCorte(ByVal x_codigo As String, ByVal x_usuario As String) As Boolean
        Dim _where As New Hashtable
        Try
            _where.Add("PEDID_Codigo", New ACWhere(x_codigo))

            DAEnterprise.BeginTransaction()


           
            Dim _ordendet As New BVENT_PedidosDetalle
            _ordendet.Eliminar(_where)

            Dim _orden As New BVENT_Pedidos
            _orden.Eliminar(_where)

            DAEnterprise.CommitTransaction()
            Return True

        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Anular pedido
   ''' </summary>
   ''' <param name="x_codigo">Codigo de pedido a ser anulado</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AnularPedido(ByVal x_codigo As String, ByVal x_usuario As String) As Boolean
      Dim m_bvent_pedidos As New BVENT_Pedidos
      m_bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
      Try
         DAEnterprise.BeginTransaction()
         m_bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
         m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_codigo
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado)
         If m_bvent_pedidos.Guardar(x_usuario) Then
            If m_bvent_pedidos.Cargar(x_codigo, True) Then
               For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
                  Dim m_bmanejarstocks As New BManejarStock()
                        If Not m_bmanejarstocks.AnulacionPedidoVenta(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, Item.PEDID_Codigo, Item.PDDET_Item, Item.PDDET_Cantidad, x_usuario) Then
                            'If Not m_bmanejarstocks.AnulacionPedidoVenta(año_anular, Item.ARTIC_Codigo, Item.ALMAC_Id, Item.PEDID_Codigo, Item.PDDET_Item, Item.PDDET_Cantidad, x_usuario) Then
                            DAEnterprise.RollBackTransaction()
                            Return False
                        End If
               Next
            End If
         End If
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Anular pedido de reposicion, con su respectiva separacion de stocks
   ''' </summary>
   ''' <param name="x_codigo">codigo del pedido</param>
   ''' <param name="x_usuario">codigo del usuario</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function AnularPedidoReposicion(ByVal x_codigo As String, ByVal x_usuario As String) As Boolean
      Dim m_bvent_pedidos As New BVENT_Pedidos
      m_bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
      Try
         DAEnterprise.BeginTransaction()
         m_bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
         m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_codigo
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado)
         If m_bvent_pedidos.Guardar(x_usuario) Then
            DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se pudo anular el pedido de Reposicion")
         End If
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Anular pedido de stocks
   ''' </summary>
   ''' <param name="x_codigo">codigo del pedido</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_tran">Opcion para ver si se ejecuta las transacción</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AnularPedidoStock(ByVal x_codigo As String, ByVal x_usuario As String, Optional ByVal x_tran As Boolean = True) As Boolean
      Dim m_bvent_pedidos As New BVENT_Pedidos
      m_bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         m_bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
         m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_codigo

         If m_bvent_pedidos.Cargar(x_codigo, True) Then
            For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
               Dim m_bmanejarstocks As New BManejarStock()
               If Not m_bmanejarstocks.AnulacionPedidoVenta(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, Item.PEDID_Codigo, Item.PDDET_Item, Item.PDDET_Cantidad, x_usuario) Then
                  If x_tran Then DAEnterprise.RollBackTransaction()
                  Return False
               End If
            Next
         End If
         If x_tran Then DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         If x_tran Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Anular pedido de reposicion de los puntos de venta
   ''' </summary>
   ''' <param name="x_codigo">Codigo del pedido</param>
   ''' <param name="x_pxpedido">permiso de anulacion</param>
   ''' <param name="x_motivo">motivo de anulación</param>
   ''' <param name="x_almac_id">codigo de almacen</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
    Public Function AnularPedidoReposicion(ByVal x_codigo As String, ByVal x_pxpedido As Boolean, ByVal x_motivo As String,
                                           ByVal x_paseanulacion As Boolean, ByVal x_almac_id As Short, ByVal x_usuario As String) As Boolean
        Dim m_bvent_pedidos As New BVENT_Pedidos
        m_bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
        Try
            Dim _constantes As New BConstantes
            Dim _fecha As DateTime = _constantes.getFecha()
            If Not _fecha.Date = m_event_pedidos.PEDID_FechaDocumento.Date Then
                If Not x_pxpedido Then
                    If Not x_paseanulacion Then
                        Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
                    End If
                End If
                m_bvent_pedidos.VENT_Pedidos.PEDID_AnuladoCaja = x_pxpedido
            End If

            DAEnterprise.BeginTransaction()
            m_bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
            m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_codigo
            m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Anulado)
            m_bvent_pedidos.VENT_Pedidos.PEDID_MotivoAnulacion = x_motivo
            If m_bvent_pedidos.Guardar(x_usuario) Then
                If m_bvent_pedidos.Cargar(x_codigo, True) Then
                    For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
                        Dim m_bmanejarstocks As New BManejarStock()
                        If Not m_bmanejarstocks.AnulacionPedidoVenta(m_periodo, Item.ARTIC_Codigo, x_almac_id, Item.PEDID_Codigo, Item.PDDET_Item, Item.PDDET_Cantidad, x_usuario) Then
                            DAEnterprise.RollBackTransaction()
                            Return False
                        End If
                    Next
                End If
            End If
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' activacion de pedido de separación
   ''' </summary>
   ''' <param name="x_codigo">codigo del pedido</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_tran">opcion para el manejo de transacciones entre funciones</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function ActivarPedido(ByVal x_codigo As String, ByVal x_usuario As String, Optional ByVal x_tran As Boolean = True) As Boolean
      Dim m_bvent_pedidos As New BVENT_Pedidos
      m_bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         m_bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
         m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_codigo
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Ingresado)
         If m_bvent_pedidos.Guardar(x_usuario) Then
            If m_bvent_pedidos.Cargar(x_codigo, True) Then
               For Each Item As EVENT_PedidosDetalle In m_bvent_pedidos.VENT_Pedidos.ListDetPedidos
                  Dim m_bmanejarstocks As New BManejarStock()
                  If Not m_bmanejarstocks.ActivacionPedidoVenta(m_periodo, Item.ARTIC_Codigo, Item.ALMAC_Id, Item.PEDID_Codigo, Item.PDDET_Item, Item.PDDET_Cantidad, x_usuario) Then
                     If x_tran Then DAEnterprise.RollBackTransaction()
                     Return False
                  End If
               Next
            End If
         End If
         If x_tran Then DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         If x_tran Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar los precios de un producto
   ''' </summary>
   ''' <param name="x_zonas_codigo">Codigo de la Zona</param>
   ''' <param name="x_artic_codigo">Codigo del articulo</param>
   ''' <returns>True: Si existen precios, False: Si no existe precios</returns>
   ''' <remarks></remarks>
   Public Function cargarPrecios(ByVal x_zonas_codigo As String, ByVal x_artic_codigo As String) As Boolean
      Try
         m_listPrecios = New List(Of EPPrecios)
         Dim _conarticulos As New BConsultaArticulos(m_periodo)
         If _conarticulos.ObtenerPrecios(x_artic_codigo, x_zonas_codigo) Then
            m_listPrecios = _conarticulos.ListPrecios
            Dim _btipocambio As New BTipoCambio
            If _btipocambio.getUltTipoCambioOficina() Then
               m_tipocambio = _btipocambio.TipoCambio
               For Each Item As EPPrecios In m_listPrecios
                  If Item.TIPOS_CodTipoMoneda.Equals(ETipos.getTipo(ETipos.TipoMoneda.Dolares)) Then
                     Item.PrecioCalculadoDolares = Item.PrecioCalculado
                     Item.PrecioCalculado = Item.PrecioCalculado * m_tipocambio.TIPOC_VentaOficina
                     Item.PrecioCalculadoSoles = Item.PrecioCalculado
                  Else
                     Item.PrecioCalculadoDolares = Item.PrecioCalculado / m_tipocambio.TIPOC_VentaOficina
                     Item.PrecioCalculadoSoles = Item.PrecioCalculado
                  End If
               Next
               Return True
            Else
               Return False
            End If
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busqueda de pedidos
   ''' </summary>
   ''' <param name="x_cadena">Cadena de busqueda</param>
   ''' <param name="x_campo">Campo sobre el cual se hace la busqueda de cadena</param>
   ''' <param name="x_todos">Mostrar todos</param>
   ''' <param name="x_rehusados">Mostrar los rehuzados</param>
   ''' <param name="x_tipo">Tipo de pedido</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <param name="x_zonas_codigo">codigo de zona</param>
   ''' <param name="x_sucur_id">codigo de sucursal</param>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_todos As Boolean, ByVal x_rehusados As Boolean, ByVal x_tipo As EVENT_Pedidos.TipoPedido _
                            , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                            , ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
      Try
         Dim m_bvent_pedidos As New BVENT_Pedidos()
         Dim _tipo As String = ""
         Select Case x_tipo
            Case EVENT_Pedidos.TipoPedido.CT
               _tipo = x_tipo.ToString().Substring(0, 1)
            Case EVENT_Pedidos.TipoPedido.PD
               _tipo = x_tipo.ToString().Substring(0, 1)
            Case EVENT_Pedidos.TipoPedido.PI
               _tipo = x_tipo.ToString().Substring(1, 1)
            Case EVENT_Pedidos.TipoPedido.PS
               _tipo = x_tipo.ToString().Substring(1, 1)
            Case Else
               _tipo = x_tipo.ToString().Substring(0, 1)
         End Select

         If m_bvent_pedidos.BusCotizacion(x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, _tipo, x_campo, x_cadena, x_todos, x_rehusados) Then
            m_listVENT_Pedidos = New List(Of EVENT_Pedidos)(m_bvent_pedidos.ListVENT_Pedidos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busqueda de pedidos de reposicion
   ''' </summary>
   ''' <param name="x_cadena">Cadena de busqueda</param>
   ''' <param name="x_campo">Campo sobre el cual se busca la cadena</param>
   ''' <param name="x_todos">Mostrar todos los pedidos</param>
   ''' <param name="x_tipo">buscar el tipo de pedideo</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <param name="x_zonas_codigo">codigo de zonas</param>
   ''' <param name="x_sucur_id">codigo de sucursal</param>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <param name="x_pvent_iddestino">codigo del punto de venta destino</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function BusquedaReposicion(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_todos As Boolean, ByVal x_tipo As EVENT_Pedidos.TipoPedido _
                         , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                         , ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long, ByVal x_pvent_iddestino As Long) As Boolean
      Try
         Dim m_bvent_pedidos As New BVENT_Pedidos()
         If m_bvent_pedidos.BusPedidoReposicion(x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_pvent_iddestino, x_sucur_id, x_tipo.ToString().Substring(1, 1), x_campo, x_cadena, x_todos) Then
            m_listVENT_Pedidos = New List(Of EVENT_Pedidos)(m_bvent_pedidos.ListVENT_Pedidos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busquedade de pedidos de separacion
   ''' </summary>
   ''' <param name="x_cadena">Cadena de busqueda</param>
   ''' <param name="x_campo">Campo sobre el cual se busca la cadena</param>
   ''' <param name="x_todos">Mostrar todos los pedidos</param>
   ''' <param name="x_tipo">buscar el tipo de pedideo</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <param name="x_zonas_codigo">codigo de zonas</param>
   ''' <param name="x_sucur_id">codigo de sucursal</param>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <param name="x_pvent_iddestino">codigo del punto de venta destino</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function BusquedaSeparacion(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_todos As Boolean, ByVal x_tipo As EVENT_Pedidos.TipoPedido _
                      , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                      , ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long, ByVal x_pvent_iddestino As Long) As Boolean
      Try
         Dim m_bvent_pedidos As New BVENT_Pedidos()
         If m_bvent_pedidos.BusPedidoSeparacion(x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_pvent_iddestino, x_sucur_id, x_tipo.ToString().Substring(1, 1), x_campo, x_cadena, x_todos) Then
            m_listVENT_Pedidos = New List(Of EVENT_Pedidos)(m_bvent_pedidos.ListVENT_Pedidos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    
     Public Function BusquedaOrdenCorte(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_todos As Boolean, ByVal x_tipo As String _
                      , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                      , ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long , ByVal x_artic_codigo As String) As Boolean
      Try
         Dim m_bvent_pedidos As New BVENT_Pedidos()
         If m_bvent_pedidos.BusOrdenCorte(x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_tipo, x_campo, x_cadena, x_todos , x_artic_codigo) Then
            m_listVENT_Pedidos = New List(Of EVENT_Pedidos)(m_bvent_pedidos.ListVENT_Pedidos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function



   ''' <summary>
   ''' Busquedas de guias de remoposcion
   ''' </summary>
   ''' <param name="x_cadena">Cadena de busqueda</param>
   ''' <param name="x_campo">Campo sobre el cual se busca la cadena</param>
   ''' <param name="x_todos">Mostrar todos los pedidos</param>
   ''' <param name="x_tipo">buscar el tipo de pedideo</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <param name="x_zonas_codigo">Codigo de zona</param>
   ''' <param name="x_sucur_id">codigo de sucursal</param>
   ''' <param name="x_pvent_id">codigo de pùnto de venta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function BusquedaGuiaReposicion(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_todos As Boolean, ByVal x_tipo As EVENT_Pedidos.TipoPedido _
                      , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                      , ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
      Try
         Dim m_bvent_pedidos As New BVENT_Pedidos()
         If m_bvent_pedidos.VENT_PEDIDSS_ConsPedidoReposicion(x_fecini, x_fecfin, x_zonas_codigo, x_pvent_id, x_sucur_id, x_tipo.ToString().Substring(1, 1), x_campo, x_cadena, x_todos, Nothing, False) Then
            m_listVENT_Pedidos = New List(Of EVENT_Pedidos)(m_bvent_pedidos.ListVENT_Pedidos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de pedidos
   ''' </summary>
   ''' <param name="x_opcion">Opcion de busqueda</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <param name="x_zonas_codigo">codigo de la zona</param>
   ''' <param name="x_sucur_id">codigo de la sucursal</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_opcion As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime _
                            , ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
      Try
         Dim m_bvent_pedidos As New BVENT_Pedidos()
         If m_bvent_pedidos.Busqueda(x_opcion, x_fecini, x_fecfin, x_zonas_codigo, x_sucur_id, x_pvent_id) Then
            m_listVENT_Pedidos = New List(Of EVENT_Pedidos)(m_bvent_pedidos.ListVENT_Pedidos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busqueda de pedidos
   ''' </summary>
   ''' <param name="x_xcliente"></param>
   ''' <param name="x_fecha"></param>
   ''' <param name="x_fecini"></param>
   ''' <param name="x_fecfin"></param>
   ''' <param name="x_tconsulta"></param>
   ''' <param name="x_cadena"></param>
   ''' <param name="x_opcion"></param>
   ''' <param name="x_zonas_codigo"></param>
   ''' <param name="x_sucur_id"></param>
   ''' <param name="x_pvent_id"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_xcliente As Boolean, ByVal x_fecha As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tconsulta As Short, _
                            ByVal x_cadena As String, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, _
                            ByVal x_pvent_id As Long) As Boolean
      Try
         Dim m_bvent_pedidos As New BVENT_Pedidos()
         If m_bvent_pedidos.Busqueda(x_xcliente, x_fecha, x_fecini, x_fecfin, x_tconsulta, x_cadena, x_opcion, x_zonas_codigo, x_sucur_id, x_pvent_id) Then
            m_listVENT_Pedidos = New List(Of EVENT_Pedidos)(m_bvent_pedidos.ListVENT_Pedidos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el correlativo para el pedido
   ''' </summary>
   ''' <param name="x_pedid_numero">numero del pedido</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <param name="x_tipo">tipo de pedido</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCorrelativo(ByRef x_pedid_numero As Integer, ByVal x_pvent_id As Long, ByVal x_tipo As String) As String
      Try
         x_pedid_numero = d_generarcotizacion.getCorrelativo(x_pvent_id, x_tipo) + 1
         Dim x_codigo As String = x_pvent_id.ToString().PadLeft(3, "0") & x_pedid_numero.ToString().PadLeft(7, "0")
         Return x_codigo

      Catch ex As Exception
         Throw ex
      End Try

   End Function

    Public Function getImpresiones(ByRef x_pedid_codigo As String) As Integer
      Try
        Dim impresiones As Integer
         impresiones = d_generarcotizacion.getImpresiones(x_pedid_codigo) + 1

         Return impresiones

      Catch ex As Exception
         Throw ex
      End Try

   End Function
     Public sub actualizarCodigo(ByRef x_pedid_codigo As String,ByVal x_impresiones As Integer) 
      Try
   
      d_generarcotizacion.getActualizar(x_pedid_codigo,x_impresiones) 

      Catch ex As Exception
         Throw ex
      End Try

   End Sub


    Public Function getcantidadlimite(ByVal X_codigorelacionado As String, ByVal x_artic_codigo As String, ByVal x_tipodoc As String) As Decimal
       Try
         
         Dim x_codigo As Decimal = d_generarcotizacion.getcantidadlimite(X_codigorelacionado,x_artic_codigo,x_tipodoc)
         Return x_codigo

      Catch ex As Exception
         Throw ex
      End Try
   End Function


      Public Function getCorrelativoNum(ByRef x_pedid_numero As Integer, ByVal x_pvent_id As Long, ByVal x_tipo As String) As String
      Try
         x_pedid_numero = d_generarcotizacion.getCorrelativoCorte(x_pvent_id, x_tipo) + 1
         Dim x_codigo As String = x_pedid_numero.ToString().PadLeft(7, "0")
         Return x_codigo

      Catch ex As Exception
         Throw ex
      End Try

   End Function

   ''' <summary>
   ''' cargar pedido con su detalle
   ''' </summary>
   ''' <param name="x_pedid_codigo"></param>
   ''' <param name="x_detalle"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Cargar(ByVal x_pedid_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "PEDID_UsrCrea")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "Usuario") _
                                            , New ACCampos("ENTID_PtrNombre1", "PrtNombre")}))
         Dim _where As New Hashtable()
         _where.Add("PEDID_Codigo", New ACWhere(x_pedid_codigo, ACWhere.TipoWhere.Igual))

         Dim m_bvent_pedidos As New BVENT_Pedidos()
         If m_bvent_pedidos.Cargar(_join, _where) Then
            m_event_pedidos = m_bvent_pedidos.VENT_Pedidos
            m_event_pedidos.Cotizador = m_event_pedidos.Usuario.Substring(m_event_pedidos.PrtNombre)
            If x_detalle Then
               Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle
               Dim _joinDet As New List(Of ACJoin)
               _joinDet.Add(New ACJoin("dbo", "Articulos", "Art", ACJoin.TipoJoin.Inner _
                                  , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                                  , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion"), _
                                                    New ACCampos("ARTIC_Codigo", "ARTIC_Codigo"), _
                                                    New ACCampos("ARTIC_Peso", "ARTIC_Peso"), _
                                                    New ACCampos("ARTIC_Percepcion", "ARTIC_Percepcion"), _
                                                    New ACCampos("TIPOS_CodUnidadMedida", "TIPOS_CodUnidadMedida")}))
                ''New ACCampos("ARTIC_Peso", "PDDET_PesoUnitario"), _
               _joinDet.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "Uni", "Art", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_Descripcion"), _
                                              New ACCampos("TIPOS_DescCorta", "TIPOS_UnidadMedida")}))
               _joinDet.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, "Alm", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                            , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
               Dim _whereDet As New Hashtable()
               _whereDet.Add("PEDID_Codigo", New ACWhere(x_pedid_codigo, ACWhere.TipoWhere.Igual))

               m_bvent_pedidosdetalle.CargarTodos(_joinDet, _whereDet)
               m_event_pedidos.ListDetPedidos = New List(Of EVENT_PedidosDetalle)(m_bvent_pedidosdetalle.ListVENT_PedidosDetalle)
               For Each item As EVENT_PedidosDetalle In m_event_pedidos.ListDetPedidos
                  item.ARTIC_Peso = item.PDDET_Cantidad * item.ARTIC_Peso
               Next

            End If
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try

   End Function

   ''' <summary>
   ''' Cargar el pedido con su detalle
   ''' </summary>
   ''' <param name="x_pedid_codigo">codigo del pedido</param>
   ''' <param name="x_almac_id">codigo del almacen</param>
   ''' <param name="x_detalle">opcion para cargar el detalle del pedido</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function Cargar(ByVal x_pedid_codigo As String, ByVal x_almac_id As Short, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "PEDID_UsrCrea")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "Usuario") _
                                            , New ACCampos("ENTID_PtrNombre1", "PrtNombre")}))
         Dim _where As New Hashtable()
         _where.Add("PEDID_Codigo", New ACWhere(x_pedid_codigo, ACWhere.TipoWhere.Igual))

         Dim m_bvent_pedidos As New BVENT_Pedidos()
         If m_bvent_pedidos.Cargar(_join, _where) Then
            m_event_pedidos = m_bvent_pedidos.VENT_Pedidos
            m_event_pedidos.Cotizador = m_event_pedidos.Usuario.Substring(m_event_pedidos.PrtNombre)
            If x_detalle Then
               Dim m_bvent_pedidosdetalle As New BVENT_PedidosDetalle

               If m_bvent_pedidosdetalle.VENT_PEDIDSS_ObtDetPedidoReposicion(x_pedid_codigo, x_almac_id) Then
                  m_event_pedidos.ListDetPedidos = New List(Of EVENT_PedidosDetalle)(m_bvent_pedidosdetalle.ListVENT_PedidosDetalle)
                  For Each item As EVENT_PedidosDetalle In m_event_pedidos.ListDetPedidos
                     item.ARTIC_Peso = item.PDDET_Cantidad * item.ARTIC_Peso

                  Next
               End If
            End If
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try

   End Function

   ''' <summary>
   ''' Obtener la seried de los documentos
   ''' </summary>
   ''' <param name="x_zonas_codigo">codigo de la zona</param>
   ''' <param name="x_sucur_id">codigo de la sucursal</param>
   ''' <param name="x_pvent_id">codigo del punto de venta</param>
   ''' <param name="x_tipo_documento">tipo de documento</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetSeries(ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_pvent_id As Integer, ByVal x_tipo_documento As String) As Boolean
      Try
         m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()

         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, "Sucur", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, "PVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")} _
                              , New ACCampos() {New ACCampos("PVENT_Descripcion", "PVENT_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))

         Dim x_where As New Hashtable
         x_where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         x_where.Add("SUCUR_Id", New ACWhere(x_sucur_id))

         If x_pvent_id > 0 Then x_where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         If x_tipo_documento.Length > 3 Then x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         ''Jalar los datos de la capa de Negocio de BVENT_PVentDocumento
         Dim m_bvent_pventdoc As New BVENT_PVentDocumento
         '' CargarTodos: Metodo para Cargar todas las listas de los registros
         If m_bvent_pventdoc.CargarTodos(_join, x_where) Then
            m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)(m_bvent_pventdoc.ListVENT_PVentDocumento)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Atender pedido
   ''' </summary>
   ''' <param name="x_usuario">codigo del usuario</param>
   ''' <param name="x_codigo">codigo del pedido</param>
   ''' <param name="x_codrelacionado">codigo relacionado o de origen</param>
   ''' <param name="x_pvent_idrelacionado">codigo del punto de venta origen o relacionado</param>
   ''' <param name="x_almac_idrelacionado">codigo de almacen origen o relacionado</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function AtenderPedido(ByVal x_usuario As String, ByVal x_codigo As String, _
                                 ByVal x_codrelacionado As String, ByVal x_pvent_idrelacionado As Long, ByVal x_almac_idrelacionado As Short) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim m_bvent_pedidos As New BVENT_Pedidos
         m_bvent_pedidos.VENT_Pedidos = New EVENT_Pedidos
         m_bvent_pedidos.VENT_Pedidos.Instanciar(ACEInstancia.Modificado)
         m_bvent_pedidos.VENT_Pedidos.PEDID_Codigo = x_codigo
         m_bvent_pedidos.VENT_Pedidos.PEDID_Estado = EVENT_Pedidos.getEstado(EVENT_Pedidos.Estado.Confirmado)
         m_bvent_pedidos.VENT_Pedidos.PEDID_CodRelacionado = x_codrelacionado
         m_bvent_pedidos.VENT_Pedidos.PVENT_IdRelacionado = x_pvent_idrelacionado
         m_bvent_pedidos.VENT_Pedidos.ALMAC_IdRelacionado = x_almac_idrelacionado
         If m_bvent_pedidos.Guardar(x_usuario) Then
            DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se puede completar el proceso de atender pedido ")
         End If
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Modificar si el pedido fue impreso
   ''' </summary>
   ''' <param name="x_pedid_codigo">codigo del pedido</param>
   ''' <param name="x_pedid_condiciones"></param>
   ''' <param name="x_pedid_condicionentrega"></param>
   ''' <param name="x_pedid_nota"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ModificarPedidosReporte(ByVal x_pedid_codigo As String, ByVal x_pedid_condiciones As String, ByVal x_pedid_condicionentrega As String, ByVal x_pedid_nota As String) As Boolean
      Try
         Dim _pedidos As New BVENT_Pedidos
         _pedidos.VENTSS_ModificarPedidosReporte(x_pedid_codigo, x_pedid_condiciones, x_pedid_condicionentrega, x_pedid_nota)
         Return True
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
    Public Function SetPermisoAnularPedido(ByVal x_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try

            Dim _pedido As New BVENT_Pedidos
            Return _pedido.SetPermisoAnularPedido(x_codigo, x_value, x_usuario)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class


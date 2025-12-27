Imports ACDVentas
Imports ACEVentas
Imports ACFramework
Imports DAConexion

Public Class BGenerarTransformacionPedido

#Region " Variables "
   Private d_generarpedidoTrans As DGenerarPedidoTransformacion
    PRIVATE m_listVENT_DocsVentadET As EVENT_DocsVentaDetalle

   Private m_dist_pedidoTrans As EABAS_PedidoTransformacion
   Private m_dist_pedidoTransDetalle As EABAS_PedidoTransformaciondetalle
   Private m_bvent_docsventa As New BVENT_DocsVenta
   Private m_puntoventaremoto As EPuntoVenta
    Private m_docs_venta As EVENT_DocsVenta
    
    Private m_listDIST_VENTADET As List(Of EVENT_DocsVentaDetalle)
   Private m_listVENT_DocsVenta As List(Of EVENT_DocsVenta)
   Private m_listDIST_pedidoTrans As List(Of EABAS_PedidoTransformacion)
   Private m_listDIST_pedidoTranscantidades As List(Of EABAS_PedidoTransformacion)
   Private m_listDist_pedidoTransDetalle As List(Of EABAS_PedidoTransformacionDetalle)


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

   Public Property ABAS_PedidoTransformacion() As EABAS_PedidoTransformacion
      Get
         Return m_dist_pedidoTrans
      End Get
      Set(ByVal value As EABAS_PedidoTransformacion)
         m_dist_pedidoTrans = value
      End Set
   End Property

    Public Property ABAS_PedidoTransformacionDetalle() As EABAS_PedidoTransformaciondetalle
      Get
         Return m_dist_pedidoTransDetalle
      End Get
      Set(ByVal value As EABAS_PedidoTransformaciondetalle)
         m_dist_pedidoTransDetalle = value
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

   Public Property ListABAS_PedidoTransformacion() As List(Of EABAS_PedidoTransformacion)
      Get
         Return m_listDIST_pedidoTrans
      End Get
      Set(ByVal value As List(Of EABAS_PedidoTransformacion))
         m_listDIST_pedidoTrans = value
      End Set
   End Property
    
   Public  Property ListABAS_PedidoTransformacionCantidades() As List(Of EABAS_PedidoTransformacion)
       Get
           Return m_listDIST_pedidoTranscantidades
       End Get
        set(ByVal value As List(Of EABAS_PedidoTransformacion))
            m_listDIST_pedidoTranscantidades=value
        End Set
   End Property
   


    Public Property ListABAS_PedidoTransformacionDetalle() As List(Of EABAS_PedidoTransformacionDetalle)
      Get
         Return m_listDist_pedidoTransDetalle
      End Get
      Set(ByVal value As List(Of EABAS_PedidoTransformacionDetalle))
         m_listDist_pedidoTransDetalle = value
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
      d_generarpedidoTrans = New DGenerarPedidoTransformacion()
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
   Public Function GrabarPedidoTransIngresoActStock(ByVal x_usuario As String, ByVal x_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta, ByVal x_usuario_db As String, ByVal x_password_db As String) As Boolean
        Dim m_bdist_pedidotrans As New BABAS_PedidoTransformacion
        Try
            '' Verificar que la Factura no ha sido anulada
            Dim _factura As New BVENT_DocsVenta
            If _factura.Cargar(m_dist_pedidoTrans.DOCVE_Codigo) Then
                If _factura.VENT_DocsVenta.DOCVE_Estado.Equals(Constantes.getEstado(Constantes.Estado.Anulado)) Then
                    Throw New Exception(String.Format("El documento {0} se encuentra anulado, Ud. no podra completar el proceso de Crear la Orden", _factura.VENT_DocsVenta.DOCVE_Codigo))
                End If
            End If

             
        
     '' Cambiar estado del pedido de transformacion generada
            Dim _pedidotrans As New BABAS_PedidoTransformacion
            _pedidotrans.DIST_PEDIDTrans = New EABAS_PedidoTransformacion()
            _pedidotrans.DIST_PEDIDTrans.PEDID_Atendido = True
            _pedidotrans.DIST_PEDIDTrans.PEDID_Impresa = False
            _pedidotrans.DIST_PEDIDTrans.PEDID_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
            _pedidotrans.DIST_PEDIDTrans.Instanciar(ACEInstancia.Modificado)
            If Not _pedidotrans.Guardar(x_usuario) Then
                Throw New Exception("No se puede Atender la Orden en el Punto de venta Remoto")
            End If
      ''''


            
            '' Grabar en el servidor Local
                DAEnterprise.BeginTransaction()
                m_dist_pedidoTrans.PEDID_CodigoTrans = m_dist_pedidoTrans.PEDID_CodReferencia
                '----> Prueba de ordenes
                Dim cant As DOUBLE = 0
                m_dist_pedidoTrans.PEDID_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
                If m_bdist_pedidotrans.Guardar(x_usuario, New String() {"PEDID_FechaIngreso"}) Then
                    Dim i As Integer = 1

                    For Each item As EABAS_PedidoTransformacionDetalle In m_dist_pedidoTrans.ListABAS_PedidoTransDetalle
                        If item.PEDID_Cantidad > 0 Then
                            Dim _detalle As New BABAS_PedidoTransformacionDetalle
                            _detalle.DIST_PedidoTransDetalle = item
                            _detalle.DIST_PedidoTransDetalle.PEDID_CodigoTrans = m_dist_pedidoTrans.PEDID_CodigoTrans
                            _detalle.DIST_PedidoTransDetalle.PEDID_Item = i
                            _detalle.DIST_PedidoTransDetalle.PEDID_Cantidad = item.PEDID_Cantidad
                           _detalle.DIST_PedidoTransDetalle.Instanciar(ACEInstancia.Nuevo)
                           _detalle.Guardar(x_usuario)

                            '' Realizar el Ingreso a Stock
                            Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                            m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                            m_bmanejarstocks.LOG_Stocks.PEDID_Codigo = item.PEDID_CodigoTrans
                            m_bmanejarstocks.LOG_Stocks.PDDET_Item = item.PEDID_Item
                            m_bmanejarstocks.Ingreso(m_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, m_bdist_pedidotrans.DIST_PEDIDTrans.ALMAC_Id, item.PEDID_Cantidad, _
                                                     m_bdist_pedidotrans.DIST_PEDIDTrans.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.IngresoOrden), x_usuario)
                        End If
                        i += 1
                    Next
                    DAEnterprise.CommitTransaction()
                End If
            
            
            '' EGRESO
            'If ACUtilitarios.ACCrearCadena("StrConn", x_pvremoto.PVENT_DireccionIP, x_pvremoto.PVENT_BaseDatos, x_usuario_db, x_password_db) Then
            '    DAEnterprise.Instanciar("StrConn", True)

            '    '' Grabar la Orden remoto
            '    m_dist_ordenes.ORDEN_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            '    If m_bdist_ordenes.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
            '        Dim i As Integer = 1
            '        For Each item As EDIST_OrdenesDetalle In m_dist_ordenes.ListDIST_OrdenesDetalle
            '            If item.ORDET_Cantidad > 0 Then
            '                Dim _detalle As New BDIST_OrdenesDetalle
            '                _detalle.DIST_OrdenesDetalle = item
            '                _detalle.DIST_OrdenesDetalle.ORDEN_Codigo = m_dist_ordenes.ORDEN_Codigo
            '                _detalle.DIST_OrdenesDetalle.ORDET_Cantidad = item.ORDET_Cantidad
            '                _detalle.DIST_OrdenesDetalle.ORDET_Item = i
            '                _detalle.DIST_OrdenesDetalle.Instanciar(ACEInstancia.Nuevo)

            '                _detalle.Guardar(x_usuario)

            '                '' Realizar el egreso de Stock
            '                Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
            '                m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
            '                m_bmanejarstocks.LOG_Stocks.ORDEN_Codigo = item.ORDEN_Codigo
            '                m_bmanejarstocks.LOG_Stocks.ORDET_Item = item.ORDET_Item
            '                m_bmanejarstocks.Egreso(m_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, x_pvremoto.ALMAC_Id, item.ORDET_Cantidad, _
            '                                 m_bdist_ordenes.DIST_Ordenes.ORDEN_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaOrden), x_usuario)
            '            End If
            '            i += 1
            '        Next
            '        DAEnterprise.CommitTransaction()
            '    Else
            '        Throw New Exception("No se puede completar el proceso de grabar orden")
            '    End If

            'Else
            '    Throw New Exception("No se puede eestablecer conexion con el servidor remoto")
            'End If

            Return True




        Catch ex As Exception
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
   Public Function GrabarPedidoTransIngreso(ByVal x_usuario As String) As Boolean
      Try
         Dim m_bdist_ordenes As New BABAS_PedidoTransformacion
        
         m_dist_pedidoTrans.PEDID_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
         m_bdist_ordenes.DIST_PEDIDTrans = m_dist_pedidoTrans
         DAEnterprise.BeginTransaction()
         If m_bdist_ordenes.Guardar(x_usuario, New String() {"PEDID_FechaIngreso"}) Then
            Dim i As Integer = 1

            For Each item As EABAS_PedidoTransformacionDetalle In m_dist_pedidoTrans.ListABAS_PedidoTransDetalle
               Dim _detalle As New BABAS_PedidoTransformacionDetalle
               _detalle.DIST_PedidoTransDetalle = item
               _detalle.DIST_PedidoTransDetalle.PEDID_CodigoTrans = m_dist_pedidoTrans.PEDID_CodigoTrans
               _detalle.DIST_PedidoTransDetalle.PEDID_Item = i
               _detalle.DIST_PedidoTransDetalle.PEDID_Referencia=item.Titulo
               _detalle.DIST_PedidoTransDetalle.PEDID_Lote=item.PEDID_Lote
               _detalle.DIST_PedidoTransDetalle.PEDID_LoteGeneral=item.PEDID_LoteGeneral
               _detalle.DIST_PedidoTransDetalle.PEDID_Cantidad = item.PEDID_Cantidad
               _detalle.DIST_PedidoTransDetalle.Instanciar(ACEInstancia.Nuevo)
               _detalle.Guardar(x_usuario)
               
                 '' Realizar el Ingreso a Stock
                Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                m_bmanejarstocks.LOG_Stocks.PEDID_CodigoTrans = item.PEDID_CodigoTrans
                m_bmanejarstocks.LOG_Stocks.PEDID_Item = item.PEDID_Item
                m_bmanejarstocks.LOG_Stocks.STOCK_Lote=item.PEDID_Lote
                m_bmanejarstocks.LOG_Stocks.STOCK_LoteGeneral=item.PEDID_LoteGeneral
                m_bmanejarstocks.Ingreso(m_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida, m_bdist_ordenes.DIST_PEDIDTrans.ALMAC_Id, item.PEDID_Cantidad, _
                m_bdist_ordenes.DIST_PEDIDTrans.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.IngresoTransformacionInterna), x_usuario)
                i += 1

            Next
           

            DAEnterprise.CommitTransaction()

                
            'DAEnterprise.BeginTransaction()    
            'Dim _pedidotrans As New BABAS_PedidoTransformacion
            '_pedidotrans.DIST_PEDIDTrans = New EABAS_PedidoTransformacion()
            '_pedidotrans.DIST_PEDIDTrans.PEDID_Atendido = True
            '_pedidotrans.DIST_PEDIDTrans.PEDID_Impresa = False
            '_pedidotrans.DIST_PEDIDTrans.PEDID_CodigoTrans=_pedidotrans.DIST_PEDIDTrans.PEDID_CodReferencia
            '_pedidotrans.DIST_PEDIDTrans.PEDID_Estado = Constantes.getEstado(Constantes.Estado.Confirmado)
            '_pedidotrans.DIST_PEDIDTrans.Instanciar(ACEInstancia.Modificado)
            'If Not _pedidotrans.Guardar(x_usuario) Then
            '    Throw New Exception("No se puede Atender la Orden en el Punto de venta Remoto")
            'End If
            'DAEnterprise.CommitTransaction()



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
   ''' <remarks></remarks>GrabarPedidTransSalida
   Public Function GrabarPedidTransSalida(ByVal x_usuario As String, ByVal m_pvremoto As EPuntoVenta, ByVal x_pvlocal As EPuntoVenta, ByVal x_usuario_db As String, ByVal x_password_db As String) As Boolean
      Try
  
            
         DAEnterprise.BeginTransaction()
         Dim m_bdist_pedidtrans As New BABAS_PedidoTransformacion
         m_dist_pedidoTrans.PEDID_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
         m_bdist_pedidtrans.DIST_PEDIDTrans = m_dist_pedidoTrans
         m_bdist_pedidtrans.DIST_PEDIDTrans.PEDID_UsrCrea = m_dist_pedidoTrans.PEDID_UsrCrea
         m_bdist_pedidtrans.DIST_PEDIDTrans.PEDID_FecCrea = m_dist_pedidoTrans.PEDID_FecCrea

         If m_bdist_pedidtrans.Guardar(x_usuario, New String() {"ORDEN_FechaIngreso"}) Then
            Dim i As Integer = 1
         
                For Each item As EABAS_PedidoTransformacionDetalle In m_dist_pedidoTrans.ListABAS_PedidoTransDetalle
                    If item.PEDID_Cantidad > 0 
                                IF m_bdist_pedidtrans.ValidarLote(item.PEDID_Lote, item.ARTIC_Codigo)=False
                        
                                Dim _detalle As New BABAS_PedidoTransformacionDetalle
                                _detalle.DIST_PedidoTransDetalle = item
                                _detalle.DIST_PedidoTransDetalle.PEDID_CodigoTrans = m_dist_pedidoTrans.PEDID_CodigoTrans
                                _detalle.DIST_PedidoTransDetalle.PEDID_Cantidad = item.PEDID_Cantidad
                                _detalle.DIST_PedidoTransDetalle.PEDID_Item = i
                                _detalle.DIST_PedidoTransDetalle.Instanciar(ACEInstancia.Nuevo)
                                _detalle.Guardar(x_usuario)

                                '' Realizar el egreso de Stock
                                Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                                m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                                m_bmanejarstocks.LOG_Stocks.PEDID_CodigoTrans = item.PEDID_CodigoTrans
                                m_bmanejarstocks.LOG_Stocks.PEDID_Item = item.PEDID_Item
                                m_bmanejarstocks.LOG_Stocks.STOCK_Lote= item.PEDID_Lote
                                m_bmanejarstocks.LOG_Stocks.STOCK_LoteGeneral=item.PEDID_LoteGeneral
                                m_bmanejarstocks.Egreso(m_periodo, item.ARTIC_Codigo, item.TIPOS_CodUnidadMedida,m_bdist_pedidtrans.DIST_PEDIDTrans.ALMAC_Id, item.PEDID_Cantidad, _
                                                        m_bdist_pedidtrans.DIST_PEDIDTrans.PEDID_FechaDocumento, ETipos.getTipo(ETipos.TMovimientoStock.SalidaTransformacionInterna), x_usuario)
                               Else 
                                Throw New Exception("El Lote ya se encuentra registrado, consulte con su Administrador")
                               End If 
                    Else 
                        Throw New Exception("La cantidad de unos de los items es menor a 0")
                    End If
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
   ''' Busqueda de Pedidos Transformacion
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
      m_listDIST_pedidoTrans = New List(Of EABAS_PedidoTransformacion)
      Dim m_pedidostrans As New BABAS_PedidoTransformacion
      Try
         If m_pedidostrans.BuscarPedidoTransformacionIngreso(x_fecini, x_fecfin, x_pvent_id, x_tipos_codtipoorden, x_opcion, x_cadena, x_todos) Then
            m_listDIST_pedidoTrans = m_pedidostrans.ListDIST_PEDIDTrans
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function


    ''' <summary>
    ''' BusquedaxArticulo
    ''' </summary>
    ''' <param name="x_articulo"></param>
    ''' <param name="x_almacene"></param>
    ''' <param name="x_todos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BusquedaxArticulo(ByVal x_articulo As String, ByVal x_almacene As Short, ByVal x_todos As Boolean) As Boolean
      m_listDist_pedidoTransDetalle = New List(Of EABAS_PedidoTransformaciondetalle)
      Dim m_pedidostrans As New BABAS_PedidoTransformacion
      m_pedidostrans.ListDIST_PEDIDTransDetalle = New List(Of EABAS_PedidoTransformacionDetalle)
      Try
         If m_pedidostrans.BuscarPedidoTransformacionIngresoxArticulos(x_articulo, x_almacene, x_todos) Then
            m_listDist_pedidoTransDetalle = m_pedidostrans.ListDIST_PEDIDTransDetalle
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Public Function Agregarcalibres (ByVal x_codigogestor As String, ByVal x_calibre As Decimal, ByVal x_pm As Decimal, ByVal x_aprox As Decimal,
                                      ByVal x_numCalibre As String) As Boolean
      
      Dim m_pedidostrans As New BABAS_PedidoTransformacion
      Try
         If m_pedidostrans.AgregarCalibres(x_codigogestor, x_calibre, x_pm,x_aprox,x_numCalibre) Then
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    
     Public Function ActualizarEstadoT(ByVal x_codigogestor As String) As Boolean
      
      Dim m_pedidostrans As New BABAS_PedidoTransformacion
      Try
         If m_pedidostrans.ActualizarEstadoT(x_codigogestor) Then
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function


     Public Function BusquedaxLote(ByVal x_lote As String, ByVal x_almacene As Short, ByVal x_todos As Boolean) As Boolean
      m_listDist_pedidoTransDetalle = New List(Of EABAS_PedidoTransformaciondetalle)
      Dim m_pedidostrans As New BABAS_PedidoTransformacion
      m_pedidostrans.ListDIST_PEDIDTransDetalle = New List(Of EABAS_PedidoTransformacionDetalle)
      Try
         If m_pedidostrans.BuscarPedidoTransformacionIngresoxLote(x_lote, x_almacene, x_todos) Then
            m_listDist_pedidoTransDetalle = m_pedidostrans.ListDIST_PEDIDTransDetalle
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Public Function BusquedaxFecha(ByVal x_fecini As date,ByVal x_fecfin As date, ByVal x_almacene As Short, ByVal x_todos As Boolean) As Boolean
      m_listDist_pedidoTransDetalle = New List(Of EABAS_PedidoTransformaciondetalle)
      Dim m_pedidostrans As New BABAS_PedidoTransformacion
      m_pedidostrans.ListDIST_PEDIDTransDetalle = New List(Of EABAS_PedidoTransformacionDetalle)
      Try
         If m_pedidostrans.BuscarPedidoTransformacionIngresoxfecha(x_fecini,x_fecfin, x_almacene, x_todos) Then
            m_listDist_pedidoTransDetalle = m_pedidostrans.ListDIST_PEDIDTransDetalle
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Busquedacantidadestotales(ByVal x_fecini As date,ByVal x_fecfin As date, ByVal x_almacene As Short, ByVal x_todos As Boolean) As Boolean
      m_listDIST_pedidoTranscantidades = New List(Of EABAS_PedidoTransformacion)
      Dim m_pedidostrans As New BABAS_PedidoTransformacion
      m_pedidostrans.ListDIST_PEDIDTransCantidad = New List(Of EABAS_PedidoTransformacion)
      Try
         If m_pedidostrans.BuscarPedidoTransformacionCantidad(x_fecini,x_fecfin, x_almacene, x_todos) Then
            m_listDIST_pedidoTranscantidades = m_pedidostrans.ListDIST_PEDIDTransCantidad
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function



   ''' <summary>
   ''' cargar pedido transformacion
   ''' </summary>
   ''' <param name="x_codigo">codigo de orden de compra</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarPedidoTrans(ByVal x_codigo As String) As Boolean
      Try
         Dim _pedidos As New BABAS_PedidoTransformacion
         If _pedidos.ObtenerPedidoTrnas(x_codigo, True) Then
            m_dist_pedidoTrans = _pedidos.DIST_PEDIDTrans
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function


    
   ''' <summary>
   ''' cargar pedido transformacion
   ''' </summary>
   ''' <param name="x_codigo">codigo de orden de compra</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarPedidoTrans_paraconsulta(ByVal x_codigo As String) As Boolean
      Try
         Dim _pedidos As New BABAS_PedidoTransformacion
         If _pedidos.ObtenerPedidoTrnas_consulta(x_codigo, True) Then
            m_dist_pedidoTrans = _pedidos.DIST_PEDIDTrans
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
   Public Function CargarPedidoTrans(ByVal x_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim _pedidos As New BABAS_PedidoTransformacion
         If _pedidos.ObtenerPedidoTrnas(x_codigo, x_detalle) Then
            m_dist_pedidoTrans = _pedidos.DIST_PEDIDTrans
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''''
   ''' <summary>
   ''' cargar orden de corte detalles
   ''' </summary>
   ''' <param name="x_codigo">codigo de orden de recojo</param>
   ''' <param name="x_detalle">opcion para cargar el detalle de la orden de recojo</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarPedidoTransDetalle(ByVal x_codigo As String, ByVal x_artic_codigo As String, ByVal x_loteTrans as String) As Boolean
      Try
         Dim _pedidos As New BABAS_PedidoTransformaciondetalle
         If _pedidos.CargarPedidoTransDetalle(x_codigo, x_artic_codigo,x_loteTrans) Then
            m_dist_pedidoTransDetalle = _pedidos.DIST_PedidoTransDetalle
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
   ''' Obtener el numero de lote x bobina
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getNumeroLotexbobina(byval x_articcodigo As String) As Integer
      Dim m_dgenerarpedidotrans As New DGenerarPedidoTransformacion
      Try
         Return m_dgenerarpedidotrans.getNumeroLotexBobina(x_articcodigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

       ''' <summary>
   ''' ver si existe en la cabecera para bloquear
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getcabecera(byval x_codigo As String) As Integer
      Dim m_dgenerarpedidotrans As New DGenerarPedidoTransformacion
      Try
         Return m_dgenerarpedidotrans.getcabecera(x_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function





   ''' <summary>
   ''' anular Pedido Transformacion
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
         
         '' Verificar permiso para anular ordenes posteriores
         'Dim _constantes As New BConstantes
         'Dim _fecha As DateTime = _constantes.getFecha()
         'If Not _fecha.Date = m_dist_ordenes.ORDEN_FechaDocumento.Date Then
         '   If Not x_xordenposterior Then
         '      Throw New Exception("No se puede anular un documento despues de la fecha de emision, consulte con su administrador")
         '   End If
         'End If

         '' Anular Documento Local
         DAEnterprise.BeginTransaction()
         Dim _pedidotrans As New BABAS_PedidoTransformacion
         _pedidotrans.DIST_PEDIDTrans = New EABAS_PedidoTransformacion
         _pedidotrans.DIST_PEDIDTrans.PEDID_CodigoTrans = m_dist_pedidoTrans.PEDID_CodigoTrans
         _pedidotrans.DIST_PEDIDTrans.PEDID_Estado = Constantes.getEstado(Constantes.Estado.Anulado)
         _pedidotrans.DIST_PEDIDTrans.PEDID_Atendido = True
         _pedidotrans.DIST_PEDIDTrans.Instanciar(ACEInstancia.Modificado)
         If _pedidotrans.Guardar(x_usuario) Then
            '' Actualizar el Egreso de Articulos
            Dim _wherepedid As New Hashtable : _wherepedid.Add("PEDID_CodigoTrans", New ACWhere(m_dist_pedidoTrans.PEDID_CodigoTrans))
            Dim _pedidotransdeta As New BABAS_PedidoTransformacionDetalle
            If _pedidotransdeta.CargarTodos(_wherepedid) Then
               For Each item As EABAS_PedidoTransformacionDetalle In _pedidotransdeta.ListDIST_PedidoTransDetalle
                  Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                  m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                  m_bmanejarstocks.LOG_Stocks.ORDEN_Codigo = item.PEDID_CodigoTrans
                  m_bmanejarstocks.LOG_Stocks.ORDET_Item = item.PEDID_Item
                  m_bmanejarstocks.AnulacionEgresoOrden(m_periodo, item.ARTIC_Codigo, x_pvlocal.ALMAC_Id, item.PEDID_CodigoTrans, item.PEDID_Item, _
                                                        item.PEDID_Cantidad, x_usuario)
               Next
               DAEnterprise.CommitTransaction()
               Return True
            Else
               Throw New Exception("No se puede cargar el detalle del Pedido por Transformación")
            End If
         Else
            Throw New Exception(String.Format("No se puede Anular la orden {0} en {0}, ocurrio un error al intentar anular la orden local atendida", m_dist_pedidoTrans.PEDID_CodigoTrans, m_puntoventaremoto.PVENT_Descripcion))
         End If
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
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
         _where.Add("PEDID_CodigoTrans", New ACWhere(m_dist_pedidoTrans.PEDID_CodigoTrans))
         Dim _pedido As New BABAS_PedidoTransformacion
         _pedido.DIST_PEDIDTrans = New EABAS_PedidoTransformacion
         _pedido.DIST_PEDIDTrans.PEDID_CodigoTrans = m_dist_pedidoTrans.PEDID_CodigoTrans
         _pedido.DIST_PEDIDTrans.Instanciar(ACEInstancia.Modificado)
         _pedido.DIST_PEDIDTrans.PEDID_Impresa = True
         _pedido.DIST_PEDIDTrans.PEDID_Impresiones = _pedido.getCorrelativo("PEDID_Impresiones", _where)
         Return _pedido.Guardar(x_usuario)
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
   'Public Function LOG_DIST_GUIASS_ObtDetDocVenta_Artic(ByRef x_vent_docsventa As EVENT_DocsVenta, ByVal x_docve_codigo As String, ByVal x_almac_id As Short, ByVal x_artic_codigo as String, ByVal x_item_doc As Short) As Boolean
   '   'x_vent_docsventa.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)

   '    m_listDIST_VENTADET = New List (Of EVENT_DocsVentaDetalle)

   '   Try
   '      Return d_generarordenes.LOG_DIST_GUIASS_ObtDetDocVenta_Artic(m_listDIST_VENTADET, x_docve_codigo, x_almac_id,x_artic_codigo,x_item_doc)
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
   Public Function GetCorrelativo(ByVal x_pedid_serie As String) As Integer
      Try
         Dim _where As New Hashtable
         _where.Add("PEDID_Serie", New ACWhere(x_pedid_serie))
         Dim m_distpedidtrans As New BABAS_PedidoTransformacion
         Return m_distpedidtrans.getCorrelativo("PEDID_Numero", _where)
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
   Public Function GetCorrelativoXtipo(ByVal x_pedid_serie As String, ByVal x_tipo_doc As String) As Integer
      Try
         Dim _where As New Hashtable
         _where.Add("PEDID_Serie", New ACWhere(x_pedid_serie))
         _where.add("TIPOS_CodTipoPedido", new ACWhere(x_tipo_doc))
         Dim m_distpedidtrans As New BABAS_PedidoTransformacion
         Return m_distpedidtrans.getCorrelativoXtipo("PEDID_Numero", _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function




    '    Public Function GetImpresion(ByVal x_pedid_codigo As String) As Boolean
    '   Try
    '      Dim _where As New Hashtable
    '      _where.Add("PEDID_CodigoTrans", New ACWhere(x_pedid_codigo))
    '      _where.Add("PEDID_Impresiones", New ACWhere(1,ACWhere.TipoWhere.MayorIgual))
    '      Dim m_dist_pedido As New BABAS_PedidoTransformacion
    '      Return m_dist_pedido.getImpresion(_where)
    '   Catch ex As Exception
    '      Throw ex
    '   End Try
    'End Function

    ' <summary> 
    ' Capa de Negocio: LOG_DISTSS_OrdenesXDocumento
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_pvent_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function PedidTransXDocumento(ByVal x_pedido_codigo As String, ByVal x_pvent_id As Long) As Boolean
        m_listDIST_pedidoTrans = New List(Of EABAS_PedidoTransformacion)
        Try
            Return d_generarpedidoTrans.LOG_DISTSS_PedidosXDocumento(m_listDIST_pedidoTrans, x_pedido_codigo, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Capa de Negocio: LOG_DISTSS_OrdenesXDocumento
    ' </summary>
    ' <param name="x_docve_codigo">Parametro 1: </param> 
    ' <param name="x_pvent_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function PedidTransXDocumentoL(ByVal x_pedido_codigo As String, ByVal x_ALMAC_id As Long) As Boolean
        m_listDIST_pedidoTrans = New List(Of EABAS_PedidoTransformacion)
        Try
            Return d_generarpedidoTrans.LOG_DISTSS_PedidosXDocumentoL(m_listDIST_pedidoTrans, x_pedido_codigo, x_ALMAC_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region " Metodos de Controles"

#End Region


End Class

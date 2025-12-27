Imports ACDVentas
Imports ACEVentas
Imports ACFramework
Imports DAConexion

Public Class BGenerarGestionOrdenes


    #Region " Variables "
   Private m_eabas_gestionordenes As EABAS_GestionOrdenes
   Private m_listABAS_GestionOrdenes As List(Of EABAS_GestionOrdenes)
   Private m_listABAS_GestionOrdenescantidades As List(Of EABAS_GestionOrdenes)


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

   ''' <summary>
   ''' Contructor
   ''' </summary>
   ''' <param name="x_pvent_id">Codigo de Punto de venta</param>
   ''' <param name="x_almac_id">Codigo del almacen</param>
   ''' <param name="x_periodo">Codigo del periodo activo</param>
   ''' <param name="x_zonas_codigo">codigo de zona</param>
   ''' <param name="x_sucur_id">Codigo de sucursal</param>
   ''' <remarks></remarks>
   Public Sub New(ByVal x_pvent_id As Long, ByVal x_almac_id As Short, ByVal x_periodo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer)
      m_pvent_id = x_pvent_id
      m_periodo = x_periodo
      m_almac_id = x_almac_id
      m_zonas_codigo = x_zonas_codigo
      m_sucur_id = x_sucur_id

   End Sub


#End Region

#Region " Propiedades "

   Public Property ABAS_GestionOrdenes() As EABAS_GestionOrdenes
      Get
         Return m_eabas_gestionordenes
      End Get
      Set(ByVal value As EABAS_GestionOrdenes)
         m_eabas_gestionordenes = value
      End Set
   End Property

   Public Property ListABAS_GestionOrdenes() As List(Of EABAS_GestionOrdenes)
      Get
         Return m_listABAS_GestionOrdenes
      End Get
      Set(ByVal value As List(Of EABAS_GestionOrdenes))
         m_listABAS_GestionOrdenes = value
      End Set
   End Property
      Public  Property ListABAS_PedidoTransformacionCantidades() As List(Of EABAS_GestionOrdenes)
       Get
           Return m_listABAS_GestionOrdenescantidades
       End Get
        set(ByVal value As List(Of EABAS_GestionOrdenes))
            m_listABAS_GestionOrdenescantidades=value
        End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "

#End Region




   'Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_pvent_id As Integer, ByVal x_cfecha As String _
   '                       , ByVal x_tipos_codmotivo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_todos As Boolean) As Boolean
   '   Try
   '      Dim m_bdist_docstraslados As New BDIST_GuiasRemision()
   '      m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)
   '      If m_bdist_docstraslados.BuscarGuiasRemision(x_fecini, x_fecfin, x_pvent_id, x_tipos_codmotivo, x_campo, x_cadena, x_todos) Then
   '         m_listDIST_GuiasRemision = New List(Of EDIST_GuiasRemision)(m_bdist_docstraslados.ListDIST_GuiasRemision)
   '         Return True
   '      End If
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   ' End Function


   
   Public Function GrabarGestionOrdnes(ByVal x_usuario As String, ByVal x_cantidad_total As Decimal, ByVal x_codigo as String,
                                       ByVal x_cantidad_ingresada As Decimal) As Boolean
      Try
            
         Dim m_babas_gestionordenes As New BABAS_GestionOrdenes() With {.ABAS_GestionOrdenes = m_eabas_gestionordenes}
      
               '' Validar que no este anulado
                Dim _borden As New BABAS_GestionOrdenes
                  If _borden.Cargar(m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo) Then
                     If _borden.ABAS_GestionOrdenes.GESTOR_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Anulado) Then
                        Throw New Exception(String.Format("El Documento de Gestion : {0} que Ud. esta intentando crear , acaba de ser anulado, no puede continuar con el proceso de creación de La Guia", m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo))
                     End If
                  End If
                    IF x_cantidad_ingresada>x_cantidad_total
                        Throw New Exception(String.Format("La cantidad ingresada para la orden de corte Nº: {0} Es superior a la cantidad que queda como saldo actualmente.", x_codigo.Substring(0,2)+" "+x_codigo.Substring(2,3)+"-"+x_codigo.Substring(5,7)))
                    End If

               DAEnterprise.BeginTransaction()
               '' Grabar Documento de Traslado Guia de Remision
               If m_babas_gestionordenes.Guardar(x_usuario) Then
                
                  Dim i As Integer = 1
                  For Each Item As EABAS_GestionOrdenesDetalle In m_babas_gestionordenes.ABAS_GestionOrdenes.ListDIST_GestionOrdenesDetalle
                     If Item.GESTOD_CantidadXmetrosOC > 0 Then
                        Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                        Item.GESTOD_Item = i
                        Item.GESTOR_Codigo = m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo
                        Dim m_bdist_docstrasladosdetalle As New BABAS_GestionOrdenesDetalle() With {.ABAS_GestionOrdenesDetalle = Item}
                        m_bdist_docstrasladosdetalle.Guardar(x_usuario)
                        i += 1
                     End If
                        
                  Next
                    
                   If x_cantidad_total=x_cantidad_ingresada
                       Dim m_dbist_ventpedido As New BVENT_Pedidos()
                       m_dbist_ventpedido.ActualizarOrdenCorte(x_codigo,Constantes.getEstado(Constantes.Estado.Confirmado) )
                   End If

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


    ''' <summary>
    ''' GrabarGestionOrdnesDetalle
    ''' </summary>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
       Public Function GrabarGestionOrdnesDetalle(ByVal x_usuario As String, ByVal x_cantidad_total As Decimal, ByVal x_codigo as String,
                                       ByVal x_cantidad_ingresada As Decimal) As Boolean
      Try
         Dim m_babas_gestionordenes As New BABAS_GestionOrdenes() With {.ABAS_GestionOrdenes = m_eabas_gestionordenes}
      
               '' Validar que no este anulado
                Dim _borden As New BABAS_GestionOrdenes
                  If _borden.Cargar(m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo) Then
                     If _borden.ABAS_GestionOrdenes.GESTOR_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Anulado) Then
                        Throw New Exception(String.Format("El Documento de Gestion : {0} que Ud. esta intentando crear , acaba de ser anulado, no puede continuar con el proceso de creación de La Guia", m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo))
                     End If
                  End If
                    IF x_cantidad_ingresada>x_cantidad_total
                        Throw New Exception(String.Format("La cantidad ingresada para la orden de corte Nº: {0} Es superior a la cantidad que queda como saldo actualmente.", x_codigo.Substring(0,2)+" "+x_codigo.Substring(2,3)+"-"+x_codigo.Substring(5,7)))
                    End If
            
                 Dim _pedidosdetalle As New BABAS_GestionOrdenesDetalle
                 Dim _where As New Hashtable
                _where.Add("GESTOR_Codigo", New ACWhere(m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo))
                _pedidosdetalle.Eliminar(_where)
            
               DAEnterprise.BeginTransaction()
               '' Grabar Documento de Traslado Guia de Remision
                  Dim i As Integer = 1
                  For Each Item As EABAS_GestionOrdenesDetalle In m_babas_gestionordenes.ABAS_GestionOrdenes.ListDIST_GestionOrdenesDetalle
                     If Item.GESTOD_CantidadXmetrosOC > 0 Then
                        Item.Instanciar(ACFramework.ACEInstancia.Nuevo)
                        Item.GESTOD_Item = i
                        Item.GESTOR_Codigo = m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo
                        Dim m_bdist_docstrasladosdetalle As New BABAS_GestionOrdenesDetalle() With {.ABAS_GestionOrdenesDetalle = Item}
                        m_bdist_docstrasladosdetalle.Guardar(x_usuario)
                        i += 1
                     End If
                  Next

                 If x_cantidad_total=x_cantidad_ingresada
                       Dim m_dbist_ventpedido As New BVENT_Pedidos()
                       m_dbist_ventpedido.ActualizarOrdenCorte(x_codigo,Constantes.getEstado(Constantes.Estado.Confirmado) )
                   End If

                    
               DAEnterprise.CommitTransaction()
                  Return True
             
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

  

   ''' <summary>
   ''' Anular guia de remision
   ''' </summary>
   ''' <param name="x_codigo">codigo de la guia de remision</param>
   ''' <param name="x_motivo">motivo de anulacion</param>
   ''' <param name="x_pgremisionp">permiso para anular guia de remision posteriores a la fecha de creacion</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AnularGestionOrden(ByVal x_codigo As String, ByVal x_motivo As String, ByVal x_usuario As String) As Boolean
      Try
         Dim m_babas_gestionordenes As New BABAS_GestionOrdenes()
         m_babas_gestionordenes.ABAS_GestionOrdenes = New EABAS_GestionOrdenes()
         m_babas_gestionordenes.ABAS_GestionOrdenes.Instanciar(ACFramework.ACEInstancia.Modificado)
         Dim _constantes As New BConstantes
         Dim _fecha As DateTime = _constantes.getFecha()
         m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_EstadoCorte = EABAS_GestionOrdenes.getEstado(EDIST_GuiasRemision.Estado.Anulado)
         m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo = x_codigo
         Return m_babas_gestionordenes.Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

  


   ''' <summary>
   ''' Cargar gestion ordenes
   ''' </summary>
   ''' <param name="x_codigo">codigo de gestion ordenes</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarGestionOrden(ByVal x_codigo As String) As Boolean
      Try
         Dim m_babas_gestionordenes As New BABAS_GestionOrdenes()
         If m_babas_gestionordenes.Cargar(x_codigo) Then
            m_eabas_gestionordenes = m_babas_gestionordenes.ABAS_GestionOrdenes
            Dim _where As New Hashtable()
            _where.Add("GESTOR_Codigo", New ACWhere(x_codigo))
            Dim m_babas_gestionordenesdetalle As New BABAS_GestionOrdenesDetalle()
           
            If m_babas_gestionordenesdetalle.CargarTodos(_where) Then
               m_eabas_gestionordenes.ListDIST_GestionOrdenesDetalle = New List(Of EABAS_GestionOrdenesDetalle)(m_babas_gestionordenesdetalle.ListABAS_GestionOrdenesDetalle)
               Return True
            End If
      
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function


       Public Function Busquedacantidadestotales(ByVal x_fecini As date,ByVal x_fecfin As date, ByVal x_almacene As Short, ByVal x_todos As Boolean) As Boolean
      m_listABAS_GestionOrdenescantidades = New List(Of EABAS_GestionOrdenes)
      Dim m_pedidostrans As New BABAS_GestionOrdenes
      m_pedidostrans.ListABAS_GestionOrdenesCant = New List(Of EABAS_GestionOrdenes)
      Try
         If m_pedidostrans.BuscarGestionOrdenCantidad(x_fecini,x_fecfin, x_almacene, x_todos) Then
            m_listABAS_GestionOrdenescantidades = m_pedidostrans.ListABAS_GestionOrdenesCant
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function




     ''' <summary>
   ''' Cargar gestion ordenes
   ''' </summary>
   ''' <param name="x_codigo">codigo de gestion ordenes</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarGestionOrdendetallexOrden(ByVal x_codigo As String) As Boolean
      Try
            
            m_eabas_gestionordenes = New EABAS_GestionOrdenes()
            m_eabas_gestionordenes.ListDIST_GestionOrdenesDetalle= New List(Of EABAS_GestionOrdenesDetalle)

          Dim _where As New Hashtable()
            _where.Add("GESTOD_CodigoOC", New ACWhere(x_codigo))
            Dim m_babas_gestionordenesdetalle As New BABAS_GestionOrdenesDetalle()
           
            If m_babas_gestionordenesdetalle.CargarTodos(_where) Then
               m_eabas_gestionordenes.ListDIST_GestionOrdenesDetalle = New List(Of EABAS_GestionOrdenesDetalle)(m_babas_gestionordenesdetalle.ListABAS_GestionOrdenesDetalle)
               Return True
            End If
      
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function





    ''' <summary>
    ''' cargar gestion ordenes por lote y documento 
    ''' </summary>
    ''' <param name="x_lote"></param>
    ''' <param name="x_codArticulo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
   Public Function CargarGestionOrdenCabe(ByVal x_lote As String, ByVal x_codArticulo As String) As Boolean
      Try
         
         Dim _where As New Hashtable()
         _where.Add("GESTOR_Lote", New ACWhere(x_lote))
         _where.Add("ARTIC_Codigo", New ACWhere(x_codArticulo))
         Dim m_babas_gestionordenes As New BABAS_GestionOrdenes()
         If m_babas_gestionordenes.Cargar(_where) Then
            
            CargarGestionOrdenCorte(m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo)

            'm_eabas_gestionordenes = m_babas_gestionordenes.ABAS_GestionOrdenes
            
            'Dim _where1 As New Hashtable()
            '_where1.Add("GESTOR_Codigo", New ACWhere(m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo))
            'Dim m_babas_gestionordenesdetalle As New BABAS_GestionOrdenesDetalle()
           
            'If m_babas_gestionordenesdetalle.CargarTodos(_where1) Then
            '   m_eabas_gestionordenes.ListDIST_GestionOrdenesDetalle = New List(Of EABAS_GestionOrdenesDetalle)(m_babas_gestionordenesdetalle.ListABAS_GestionOrdenesDetalle)
            '   Return True
            'End If
                Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

      ''' <summary>
   ''' cargar gestion orden corte
   ''' </summary>
   ''' <param name="x_codigo">codigo de orden de orte</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarGestionOrdenCorte(ByVal x_codigo As String) As Boolean
      Try
        Dim _ordenes As New BABAS_GestionOrdenes
         If _ordenes.ObtenerGestionOrden(x_codigo) Then
            m_eabas_gestionordenes = _ordenes.ABAS_GestionOrdenes
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function






   Enum TDocumento
      DOcVenta
      Ordenes
   End Enum


   'Public Function BusquedaXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean, ByVal x_pergenguia As Boolean, ByVal x_tipodoc As TDocumento) As Boolean
   '   Try
   '      Select Case x_tipodoc
   '         Case TDocumento.DOcVenta
   '            Return BusquedaDocVentaXNumero(x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
   '         Case TDocumento.Ordenes
   '            Return ObtOrdenesXNumero(x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
   '         Case Else
   '            Return BusquedaDocVentaXNumero(x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
   '      End Select

   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

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
   'Public Function BusquedaDocVentaXNumero(ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean, ByVal x_pergenguia As Boolean) As Boolean
   '   m_listVENT_DocsVenta = New List(Of EVENT_DocsVenta)
   '   Try
   '      Return d_generarguias.LOG_DIST_GUIASS_ObtDocVentaXNumero(m_listVENT_DocsVenta, x_numero, x_serie, x_tipos_codtipodocumento, x_almac_id, x_pvent_id, x_desbloqueo, x_pergenguia)
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   
    Public Function AtenderGestionOrdenes(ByVal x_usuario As String, ByVal x_codigo As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim m_babas_gestionordenes As New BABAS_GestionOrdenes
            m_babas_gestionordenes.ABAS_GestionOrdenes = New EABAS_GestionOrdenes
            m_babas_gestionordenes.ABAS_GestionOrdenes.Instanciar(ACEInstancia.Modificado)
            m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Codigo = x_codigo
            m_babas_gestionordenes.ABAS_GestionOrdenes.GESTOR_Estado = EABAS_GestionOrdenes.getEstado(EABAS_GestionOrdenes.Estado.Confirmado)
    
            If m_babas_gestionordenes.Guardar(x_usuario) Then
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

    
   ''' <summary>
   ''' getNumeroCorrelativo
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getNumeroCorrelativo(ByVal x_almacen As Long) As Integer
      Dim m_dgenerargestionOrdenes As New DGenerarGestionOrdenes
      Try
         Return m_dgenerargestionOrdenes.getNumero(x_almacen)
      Catch ex As Exception
         Throw ex
      End Try
   End Function



End Class

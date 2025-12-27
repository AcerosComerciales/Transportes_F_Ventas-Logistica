Imports DAConexion
Imports ACDLogistica
Imports ACELogistica
Imports ACFramework
Imports ACEVentas
Public Class BReporte
#Region " Variables "
   Private d_reporte As DReporte
    Private m_reporte As DataTable
    Private m_dttable As DataTable
    Private m_dttabledet As DataTable
    Private m_dttabledetdest As DataTable
    Private m_ectrl_arreglos As ECTRL_Arreglos
    Private m_listDIST_GuiasRemision As List(Of ACELogistica.EDIST_GuiasRemision)
    Private m_listDIST_Ordenes As List(Of ACEVentas.EDIST_Ordenes)
    Private m_ListVENTAS_DOCVE_Ventas As List(Of ACEVentas.EVENT_DocsVenta)

    Private m_listDIST_GuiasRemisiones As List(Of EDIST_GuiasTodas)
    Private m_edist_guiasremision As EDIST_GuiasTodas
    Private m_edist_ordenes As ACEVentas.EDIST_Ordenes
    Private m_vent_DocsVenta As ACEVentas.EVENT_DocsVenta
   Private m_almac_id As Integer
   Private m_periodo As String
   Private m_sucur_id As Short
#End Region

#Region " Propiedades "
     Public Property DTReportes() As DataTable
        Get
            Return m_reporte
        End Get
        Set(ByVal value As DataTable)
            m_reporte = value
        End Set
    End Property

    Public Property DIST_GuiasRemision() As EDIST_GuiasTodas
        Get
            Return m_edist_guiasremision
        End Get
        Set(ByVal value As EDIST_GuiasTodas)
            m_edist_guiasremision = value
        End Set
    End Property
    
       Public Property DIST_Ordenes() As ACEVentas.EDIST_Ordenes
        Get
            Return m_edist_ordenes
        End Get
        Set(ByVal value As ACEVentas.EDIST_Ordenes)
            m_edist_ordenes = value
        End Set
    End Property

    Public Property VENT_DocsVenta() As ACEVentas.EVENT_DocsVenta
        Get
            Return m_vent_DocsVenta
        End Get
        Set(ByVal value As ACEVentas.EVENT_DocsVenta)
            m_vent_DocsVenta = value
        End Set
    End Property

   Public Property DTTabla() As DataTable
      Get
         Return m_dttable
      End Get
      Set(ByVal value As DataTable)
         m_dttable = value
      End Set
    End Property
 
    Public Property DTTablavs() As DataTable
        Get
            Return m_dttabledet
        End Get
        Set(ByVal value As DataTable)
            m_dttabledet = value
            End Set
    End Property
    
    
    Public Property DTTablavsdest() As DataTable
        Get
            Return m_dttabledetdest
        End Get
        Set(ByVal value As DataTable)
            m_dttabledetdest = value
            End Set
    End Property



   Public Property CTRL_Arreglos() As ECTRL_Arreglos
      Get
         Return m_ectrl_arreglos
      End Get
      Set(ByVal value As ECTRL_Arreglos)
         m_ectrl_arreglos = value
      End Set
   End Property

    Public Property ListDIST_GuiasRemision() As List(Of ACELogistica.EDIST_GuiasRemision)
        Get
            Return m_listDIST_GuiasRemision
        End Get
        Set(ByVal value As List(Of ACELogistica.EDIST_GuiasRemision))
            m_listDIST_GuiasRemision = value
        End Set
    End Property

    Public Property ListDIST_Ordenes() As List(Of ACEVentas.EDIST_Ordenes)
        Get
            Return m_listDIST_Ordenes
        End Get
        Set(ByVal value As List(Of ACEVentas.EDIST_Ordenes))
            m_listDIST_Ordenes = value
        End Set
    End Property
      Public Property ListVENT_DocsVenta() As List(Of ACEVentas.EVENT_DocsVenta)
        Get
            Return m_ListVENTAS_DOCVE_Ventas
        End Get
        Set(ByVal value As List(Of  ACEVentas.EVENT_DocsVenta))
            m_ListVENTAS_DOCVE_Ventas = value
        End Set
    End Property

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_almac_id As Integer, ByVal x_periodo As String, ByVal x_sucur_id As Short)
      m_almac_id = x_almac_id
      m_periodo = x_periodo
      m_sucur_id = x_sucur_id

      d_reporte = New DReporte
   End Sub
#End Region

#Region " Metodos "

   ''' <summary> 
   ''' Capa de Negocio: CTRL_STOCKSS_KardexXArticulo
   ''' </summary> 
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_perio_codigo">Parametro 3: </param> 
   ''' <param name="x_zonas_codigo">Parametro 4: </param> 
   ''' <param name="x_fecini">Parametro 5: </param> 
   ''' <param name="x_fecfin">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function KardexXArticulo(ByVal x_artic_codigo As String, ByVal x_almac_id As Integer, ByVal x_perio_codigo As String, ByVal x_zonas_codigo As String, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         m_dttable = New DataTable
         Return d_reporte.CTRL_STOCKSS_KardexXArticulo(m_dttable, x_artic_codigo, x_almac_id, x_perio_codigo, x_zonas_codigo, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: REPOSS_ObtenerArreglo
   ''' </summary>
   ''' <param name="x_arreg_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function REPOSS_ObtenerArreglo(ByVal x_arreg_codigo As String, ByVal x_almac_id As Integer) As Boolean
      m_ectrl_arreglos = New ECTRL_Arreglos
      Try
         Return d_reporte.REPOSS_ObtenerArreglo(m_ectrl_arreglos, x_arreg_codigo, x_almac_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: CTRL_MostrarDocumentosCliente
   ''' </summary> 
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_entid_codigo">Parametro 4: </param> 
   ''' <param name="x_fecha">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
    Public Function CTRL_MostrarDocumentosCliente(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Long, ByVal x_entid_codigo As String, ByVal x_fecha As Boolean) As Boolean
        Try
            m_dttable = New DataTable
            Return d_reporte.CTRL_MostrarDocumentosCliente(m_dttable, x_fecini, x_fecfin, x_almac_id, x_entid_codigo, x_fecha)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Repor_ProductXGuiasv(ByVal x_periodo As String, ByVal x_almac_id As Short, ByVal x_articulo As String, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean) As Boolean
        Try
            m_dttable = New DataTable
            Return d_reporte.Control_Repor_ProductXGuiasV(m_dttable, m_periodo, x_almac_id, x_articulo, x_fecini, x_fecfin, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Repor_ing_vs_compras(ByVal x_cadena As String, ByVal _opcion As Integer, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As String) As Boolean
        Try
   
            m_dttabledet = New DataTable
            Return d_reporte.CONTROL_ComprasVSingresos(m_dttabledet, x_cadena, _opcion, x_todos, x_fecini, x_fecfin)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    
    Public Function Repor_ing_vs_comprasDest(ByVal x_tipodoc As String) As Boolean
        Try
            m_dttabledetdest = New DataTable
            Return d_reporte.CONTROL_ComprasVSingresosdest(m_dttabledetdest,x_tipodoc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Repor_ProductXGuias(ByVal x_periodo As String, ByVal x_almac_id As Short, ByVal x_articulo As String, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean) As Boolean
        Try
            m_dttable = New DataTable
            Return d_reporte.Control_Repor_ProductXGuias(m_dttable, m_periodo, x_almac_id, x_articulo, x_fecini, x_fecfin, x_todos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''actualizar la base de datos para verificacion de control _A
    Public Function Guias_VerificacionControl( ByVal x_almac_id As Short, ByVal x_documento As String, ByVal x_user As String, ByVal x_opcion As String) As Boolean
        Try
            Return d_reporte.Guias_VerificacionControl(x_almac_id, x_documento,x_user,x_opcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

     ''actualizar la base de datos para verificacion de control ORDENES _A
     Public Function Guias_VerificacionControlOrdenes( ByVal x_almac_id As Short, ByVal x_documento As String, ByVal x_user As String,
                                                       ByVal tipo_orden As string,ByVal x_opcion As string ) As Boolean
        Try
            Return d_reporte.Guias_VerificacionControlOrdenes(x_almac_id, x_documento,x_user,tipo_orden,x_opcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''actualizar la base de datos para verificacion de control _A
    Public Function Ventas_VerificacionControl( ByVal x_almac_id As Short, ByVal x_documento As String, ByVal x_usuario As String,ByVal x_opcion As String) As Boolean
        Try
            Return d_reporte.Ventas_VerificacionControl(x_almac_id, x_documento,x_usuario,x_opcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    ''PARA GUIAS _A

    Public Function Repor_Guias_Todo(ByVal x_periodo As String, ByVal x_almac_id As Short, ByVal C_Cliente As String, ByVal x_CLI As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean, ByVal x_pvent_id As Integer) As Boolean
        Try
            'm_dttable = New DataTable
            ' Dim m_bdist_docstraslados As New BDIST_GuiasTodas()
            m_listDIST_GuiasRemision = New List(Of ACELogistica.EDIST_GuiasRemision)
            If ObtenerGuias(m_periodo, x_almac_id, C_Cliente, x_CLI, x_fecini, x_fecfin, x_todos,x_pvent_id) Then
                ' m_listDIST_GuiasRemisiones = New List(Of EDIST_GuiasTodas)(m_bdist_docstraslados.ListDIST_GuiasRemision)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''PARA VENTAS  _A

     Public Function Repor_Ventas_Todo( ByVal X_PVENTID As Short, ByVal C_Cliente As String, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean, ByVal x_doc As String ) As Boolean
        Try
            m_ListVENTAS_DOCVE_Ventas = New List(Of ACEVentas.EVENT_DocsVenta)
            'm_ListVENTAS_DOCVE_Ventas = New List(Of ACELogistica.EVENT_DocsVenta)
            If ObtenerVentas( X_PVENTID, C_Cliente, x_fecini, x_fecfin, x_todos,x_doc) Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'PARA obtener ventas _A
    Public Function ObtenerVentas( ByVal X_PVENT_ID As String, ByVal c_cliente As String, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean, ByVal x_doc As String) As Boolean
        m_ListVENTAS_DOCVE_Ventas = New List(Of ACEVentas.EVENT_DocsVenta)
        Try
            Return d_reporte.Control_Repor_VentasTodas(m_ListVENTAS_DOCVE_Ventas, X_PVENT_ID, c_cliente,  x_fecini, x_fecfin, x_todos,x_doc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



  
''PARA obtener GUIAS _A
    Public Function ObtenerGuias(ByVal m_periodo As String, ByVal x_almac_id As String, ByVal c_cliente As String, ByVal C_CLI As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean, ByVal x_pvent_id As Integer) As Boolean
        m_listDIST_GuiasRemision = New List(Of ACELogistica.EDIST_GuiasRemision)
        Try
            Return d_reporte.Control_Repor_GuiasTodas(m_listDIST_GuiasRemision, m_periodo, x_almac_id, c_cliente, C_CLI, x_fecini, x_fecfin, x_todos, x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
    ''PARA obtenertodo tipo de ordenes _A
    Public Function ObtenerOrdenes(ByVal x_periodo As String,ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                   ByVal x_pvent_id As Integer) As Boolean
         m_listDIST_Ordenes = New List(Of ACEVentas.EDIST_Ordenes)
        Try
            Return d_reporte.Control_Repor_OrdenesTodas(m_listDIST_Ordenes,x_periodo,x_fecini, x_fecfin,x_almac_id, x_tipos_codtipoorden, x_cadena, x_todos,x_pvent_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    

    Public Function ControlPendietnesTotdo(ByVal x_almacen As String, ByVal x_fecini As Date, ByVal x_fecfin As Date,
                                           ByVal x_tipo As String) As Boolean
        Try
            m_reporte = New DataTable
            Return d_reporte.Control_PendientesCondi(m_reporte, x_almacen,x_fecini, x_fecfin,x_tipo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

     Public Function ControlyVerificacionKardex(ByVal x_almacen As String, ByVal x_documento As string,
                                                ByVal x_tipoorden As String) As Boolean
        Try
            m_reporte = New DataTable
            Return d_reporte.control_verificacionKardex(m_reporte, x_almacen,x_documento, x_tipoorden)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


       Public Function CargarOrdenes(ByVal x_codigo As String) As Boolean
        Try
            Dim m_bdist_docstraslados As New ACBVentas.BDIST_Ordenes()
            If m_bdist_docstraslados.Cargar(x_codigo) Then
                m_edist_ordenes = m_bdist_docstraslados.DIST_Ordenes
                Dim _where As New Hashtable()
                _where.Add("ORDEN_Codigo", New ACWhere(x_codigo))
                Dim m_bdist_docsordenessdetalle As New ACBVentas.BDIST_OrdenesDetalle()
                Dim _joinDet As New List(Of ACJoin)
                _joinDet.Add(New ACJoin(ACEVentas.EArticulos.Esquema, ACEVentas.EArticulos.Tabla, "Art", ACJoin.TipoJoin.Inner _
                                   , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                                   , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion") _
                                                     , New ACCampos("ARTIC_Id", "ARTIC_Id") _
                                                     , New ACCampos("ARTIC_Peso","PesoUnitario")}))
                _joinDet.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TUni", "Art", ACJoin.TipoJoin.Inner _
                                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                                   , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida")}
                                   ))
                If m_bdist_docsordenessdetalle.CargarTodos(_joinDet, _where) Then
                    m_edist_ordenes.ListDIST_OrdenesDetalle = New List(Of ACEVentas.EDIST_OrdenesDetalle)(m_bdist_docsordenessdetalle.ListDIST_OrdenesDetalle)
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function








    Public Function CargarGuia(ByVal x_codigo As String) As Boolean
        Try
            Dim m_bdist_docstraslados As New BDIST_GuiasTodas()
            If m_bdist_docstraslados.Cargar(x_codigo) Then
                m_edist_guiasremision = m_bdist_docstraslados.DIST_GuiasRemision
                Dim _where As New Hashtable()
                _where.Add("GUIAR_Codigo", New ACWhere(x_codigo))
                Dim m_bdist_docstrasladosdetalle As New BDIST_GuiasRemisionDetalle()
                Dim _joinDet As New List(Of ACJoin)
                _joinDet.Add(New ACJoin(ACEVentas.EArticulos.Esquema, ACEVentas.EArticulos.Tabla, "Art", ACJoin.TipoJoin.Inner _
                                   , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                                   , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion") _
                                                     , New ACCampos("ARTIC_Id", "ARTIC_Id")}))
                _joinDet.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TUni", "Art", ACJoin.TipoJoin.Inner _
                                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                                   , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida")}
                                   ))
                If m_bdist_docstrasladosdetalle.CargarTodos(_joinDet, _where) Then
                    m_edist_guiasremision.ListDIST_GuiasRemisionDetalle = New List(Of ACELogistica.EDIST_GuiasRemisionDetalle)(m_bdist_docstrasladosdetalle.ListDIST_GuiasRemisionDetalle)
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

     Public Function CargarVentas(ByVal x_codigo As String) As Boolean
        Try
            Dim m_bdist_docs As New ACBVentas.BVENT_DocsVenta()
            If m_bdist_docs.Cargar(x_codigo) Then
                m_vent_DocsVenta = m_bdist_docs.VENT_DocsVenta
                Dim _where As New Hashtable()
                _where.Add("DOCVE_Codigo", New ACWhere(x_codigo))
                Dim m_bdist_docsdetalle As New ACBVentas.BVENT_DocsVentaDetalle()
                Dim _joinDet As New List(Of ACJoin)
                _joinDet.Add(New ACJoin(ACEVentas.EArticulos.Esquema, ACEVentas.EArticulos.Tabla, "Art", ACJoin.TipoJoin.Inner _
                                   , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                                   , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion") _
                                                     , New ACCampos("ARTIC_Id", "ARTIC_Id")}))
                _joinDet.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TUni", "Art", ACJoin.TipoJoin.Inner _
                                   , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                                   , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida")}
                                   ))
                If m_bdist_docsdetalle.CargarTodos(_joinDet, _where) Then
                    m_vent_DocsVenta.ListVENT_DocsVentaDetalle = New List(Of ACEVentas.EVENT_DocsVentaDetalle)(m_bdist_docsdetalle.ListVENT_DocsVentaDetalle)
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function






#End Region

#Region " Metodos de Controles"

#End Region
End Class

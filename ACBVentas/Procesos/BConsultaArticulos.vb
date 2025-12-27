Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports ACELogistica
Imports ACBLogistica

Imports System.Configuration
Imports ACFramework

Public Class BConsultaArticulos

#Region " Variables "
   Private m_dtConsultaArticulos As DataTable
    Private m_stockremoto As DataTable
   Private ds_consultaarticulos As DataSet

   Private d_consultaarticulos As DConsultaArticulos

   Private m_listLineas As List(Of ELineas)
   Private m_listSubLineas As List(Of ELineas)
   Private m_listPrecios As List(Of EPPrecios)
   Private m_listStock As List(Of ELOG_Stocks)
   Private m_pprecios As EPPrecios
   Private m_stock As ELOG_Stocks
   Private m_earticulos As EArticulos
   Private m_tipocambio As ETipoCambio
   Private m_periodo As String
    Private m_dttable As DataTable
   Private m_hash As Hashtable

   Private m_listarticulos As List(Of EArticulos)
   Private m_listpuntoventa As List(Of EPuntoVenta)
#End Region

#Region " Constructores "

   Public Sub New(ByVal x_periodo As String)
      m_periodo = x_periodo
      d_consultaarticulos = New DConsultaArticulos()
   End Sub

#End Region

#Region " Propiedades "

   Public Property ListLineas() As List(Of ELineas)
      Get
         Return m_listLineas
      End Get
      Set(ByVal value As List(Of ELineas))
         m_listLineas = value
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

   Public Property ListSubLineas() As List(Of ELineas)
      Get
         Return m_listSubLineas
      End Get
      Set(ByVal value As List(Of ELineas))
         m_listSubLineas = value
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

   Public Property ListStock() As List(Of ELOG_Stocks)
      Get
         Return m_listStock
      End Get
      Set(ByVal value As List(Of ELOG_Stocks))
         m_listStock = value
      End Set
   End Property
   Public Property Articulos() As EArticulos
      Get
         Return m_earticulos
      End Get
      Set(ByVal value As EArticulos)
         m_earticulos = value
      End Set
   End Property

   Public Property DTConsultaArticulos() As DataTable
      Get
         Return m_dtConsultaArticulos
      End Get
      Set(ByVal value As DataTable)
         m_dtConsultaArticulos = value
      End Set
   End Property

  Public Property DTstockremoto() As DataTable
      Get
         Return m_stockremoto
      End Get
      Set(ByVal value As DataTable)
         m_stockremoto = value
      End Set
   End Property

   Public Property Stock() As ELOG_Stocks
      Get
         Return m_stock
      End Get
      Set(ByVal value As ELOG_Stocks)
         m_stock = value
      End Set
   End Property

   Public Property ListArticulos() As List(Of EArticulos)
      Get
         Return m_listarticulos
      End Get
      Set(ByVal value As List(Of EArticulos))
         m_listarticulos = value
      End Set
   End Property

   Public Property ListPuntoVenta() As List(Of EPuntoVenta)
      Get
         Return m_listpuntoventa
      End Get
      Set(ByVal value As List(Of EPuntoVenta))
         m_listpuntoventa = value
      End Set
   End Property

   Public Property HashPrecios() As Hashtable
      Get
         Return m_hash
      End Get
      Set(ByVal value As Hashtable)
         m_hash = value
      End Set
   End Property

   Public Property PPrecio() As EPPrecios
      Get
         Return m_pprecios
      End Get
      Set(ByVal value As EPPrecios)
         m_pprecios = value
      End Set
   End Property

   Public Property TipoCambio() As ETipoCambio
      Get
         Return m_tipocambio
      End Get
      Set(ByVal value As ETipoCambio)
         m_tipocambio = value
      End Set
   End Property


#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   ''' <summary>
   ''' Cargar Linea y Sub-Linea para ser procesadas en la busqueda de productos
   ''' </summary>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function cargarProductos() As Boolean
      Try
         Dim b_lineas As New BLineas()
         Dim _where As New Hashtable()
         _where.Add("LINEA_CodPadre", New ACWhere("", ACWhere.TipoWhere.Igual))
         _where.Add(ACWhere.OrderBy, New ACWhere(New ACOrderBy() {New ACOrderBy("LINEA_Nombre", ACOrderBy.Ordenamiento.Ascendente)}))
         b_lineas.CargarTodos(_where)
         m_listLineas = New List(Of ELineas)(b_lineas.ListLineas)

         _where = New Hashtable()
         _where.Add("LINEA_CodPadre", New ACWhere("", ACWhere.TipoWhere.Diferente))
         _where.Add(ACWhere.OrderBy, New ACWhere(New ACOrderBy() {New ACOrderBy("LINEA_Nombre", ACOrderBy.Ordenamiento.Ascendente)}))
         b_lineas.CargarTodos(_where)
         m_listSubLineas = New List(Of ELineas)(b_lineas.ListLineas)

         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el ultimo tipo de cambio ingresaod
   ''' </summary>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Private Function getTipoCambio() As Boolean
      Try
         Dim b_tipocambio As New BTipoCambio()
         Dim _where As New Hashtable
         _where.Add("TIPOC_Fecha", New ACWhere("select max(TIPOC_Fecha) from TipoCambio", ACWhere.TipoWhere._In))
         If b_tipocambio.Cargar(_where) Then
            m_tipocambio = b_tipocambio.TipoCambio
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
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
         If ObtenerPrecios(x_artic_codigo, x_zonas_codigo) Then
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
   ''' Cargar los precios de un producto
   ''' </summary>
   ''' <param name="x_zonas_codigo">Codigo de la Zona</param>
   ''' <param name="x_artic_codigo">Codigo del articulo</param>
   ''' <returns>True: Si existen precios, False: Si no existe precios</returns>
   ''' <remarks></remarks>
   Public Function cargarPrecio(ByVal x_zonas_codigo As String, ByVal x_artic_codigo As String, ByVal x_lprec_id As Integer) As Boolean
      Try
         m_listPrecios = New List(Of EPPrecios)
         If ObtenerPrecioLista(x_artic_codigo, x_zonas_codigo, x_lprec_id) Then
            Dim _btipocambio As New BTipoCambio
            If _btipocambio.getUltTipoCambioSunat() Then
               m_tipocambio = _btipocambio.TipoCambio
               If m_pprecios.TIPOS_CodTipoMoneda.Equals(ETipos.getTipo(ETipos.TipoMoneda.Dolares)) Then
                  m_pprecios.PrecioCalculadoDolares = m_pprecios.PrecioCalculado
                  m_pprecios.PrecioCalculado = m_pprecios.PrecioCalculado * m_tipocambio.TIPOC_VentaSunat
                        m_pprecios.PrecioCalculadoSoles = m_pprecios.PrecioCalculado
                        'm_pprecios.PrecioCalculadoLogistica = m_pprecios.PrecioCalculadoLogistica * m_tipocambio.TIPOC_VentaSunat
               Else
                  m_pprecios.PrecioCalculadoDolares = m_pprecios.PrecioCalculado / m_tipocambio.TIPOC_VentaSunat
                  m_pprecios.PrecioCalculadoSoles = m_pprecios.PrecioCalculado
               End If
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
    '_M

    ''' <summary>
    ''' Cargar los precios de un producto
    ''' </summary>
    ''' <param name="x_zonas_codigo">Codigo de la Zona</param>
    ''' <param name="x_artic_codigo">Codigo del articulo</param>
    ''' <returns>True: Si existen precios, False: Si no existe precios</returns>
    ''' <remarks></remarks>
    Public Function cargarPrecioListaEspecial(ByVal x_zonas_codigo As String, ByVal x_artic_codigo As String, ByVal x_lprec_id As Integer) As Boolean
        Try
            m_listPrecios = New List(Of EPPrecios)
            If ObtenerPrecioListaEspecial(x_artic_codigo, x_zonas_codigo, x_lprec_id) Then
                Dim _btipocambio As New BTipoCambio
                If _btipocambio.getUltTipoCambioSunat() Then
                    m_tipocambio = _btipocambio.TipoCambio
                    If m_pprecios.TIPOS_CodTipoMoneda.Equals(ETipos.getTipo(ETipos.TipoMoneda.Dolares)) Then
                        If m_pprecios.PrecioLogistica > 0 Then
                            m_pprecios.PrecioCalculadoDolares = m_pprecios.PrecioLogistica
                            m_pprecios.PrecioLogistica = m_pprecios.PrecioLogistica * m_tipocambio.TIPOC_VentaSunat
                            m_pprecios.PrecioCalculadoSoles = m_pprecios.PrecioLogistica '* m_tipocambio.TIPOC_VentaSunat 'm_pprecios.PrecioCalculado

                            'm_pprecios.PrecioCalculadoLogistica = m_pprecios.PrecioCalculadoLogistica * m_tipocambio.TIPOC_VentaSunat
                        Else
                            m_pprecios.PrecioCalculadoDolares =m_pprecios.PrecioCalculado
                            m_pprecios.PrecioCalculado = m_pprecios.PrecioCalculado * m_tipocambio.TIPOC_VentaSunat
                            m_pprecios.PrecioCalculadoSoles = m_pprecios.PrecioCalculado '* m_tipocambio.TIPOC_VentaSunat 'm_pprecios.PrecioCalculado
                            'm_pprecios.PrecioCalculadoLogistica = m_pprecios.PrecioCalculadoLogistica * m_tipocambio.TIPOC_VentaSunat
                        End If

                    Else
                        If m_pprecios.PrecioLogistica > 0 Then
                            m_pprecios.PrecioCalculadoDolares = m_pprecios.PrecioLogistica / m_tipocambio.TIPOC_VentaSunat
                            m_pprecios.PrecioCalculadoSoles = m_pprecios.PrecioLogistica
                        Else
                            m_pprecios.PrecioCalculadoDolares = m_pprecios.PrecioCalculado / m_tipocambio.TIPOC_VentaSunat
                            m_pprecios.PrecioCalculadoSoles = m_pprecios.PrecioCalculado
                        End If
                        
                    End If
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
   ''' Cargar los precios de un producto
   ''' </summary>
   ''' <param name="x_zonas_codigo">Codigo de la Zona</param>
   ''' <param name="x_artic_codigo">Codigo del articulo</param>
   ''' <returns>True: Si existen precios, False: Si no existe precios</returns>
   ''' <remarks></remarks>
   Public Function cargarPrecioCosto(ByVal x_zonas_codigo As String, ByVal x_artic_codigo As String, ByVal x_lprec_id As Integer) As Boolean
      Try
         m_listPrecios = New List(Of EPPrecios)
         If ObtenerPrecioLista(x_artic_codigo, x_zonas_codigo, x_lprec_id) Then
            Dim _btipocambio As New BTipoCambio
            If _btipocambio.getUltTipoCambioOficina() Then
               m_tipocambio = _btipocambio.TipoCambio
               If m_pprecios.TIPOS_CodTipoMoneda.Equals(ETipos.getTipo(ETipos.TipoMoneda.Dolares)) Then
                  m_pprecios.PrecioCalculadoDolares = m_pprecios.PrecioCalculado
                  m_pprecios.PrecioCalculado = m_pprecios.PrecioCalculado * m_tipocambio.TIPOC_VentaOficina
                  m_pprecios.PrecioCalculadoSoles = m_pprecios.PrecioCalculado
               Else
                  m_pprecios.PrecioCalculadoDolares = m_pprecios.PrecioCalculado / m_tipocambio.TIPOC_VentaOficina
                  m_pprecios.PrecioCalculadoSoles = m_pprecios.PrecioCalculado
               End If
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
   ''' Capa de Negocio: VEN_ARTICSS_ObtenerPrecios
   ''' </summary>
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerPrecios(ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String) As Boolean
      m_listPrecios = New List(Of EPPrecios)
      Try
         Return d_consultaarticulos.ARTICSS_ObtenerPrecios(m_listPrecios, x_artic_codigo, x_zonas_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: ARTICSS_ObtenerPrecioLista
   ''' </summary>
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <param name="x_lprec_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerPrecioLista(ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String, ByVal x_lprec_id As Integer) As Boolean
      m_pprecios = New EPPrecios
      Try
         Return d_consultaarticulos.ARTICSS_ObtenerPrecioLista(m_pprecios, x_artic_codigo, x_zonas_codigo, x_lprec_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
      ''' <summary> 
   ''' Capa de Negocio: ARTICSS_ObtenerPrecioLista
   ''' </summary>
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <param name="x_lprec_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerPrecioListaEspecial(ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String, ByVal x_lprec_id As Integer) As Boolean
      m_pprecios = New EPPrecios
      Try
         Return d_consultaarticulos.ARTICSS_ObtenerPrecioListaEspecial(m_pprecios, x_artic_codigo, x_zonas_codigo, x_lprec_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar los stocks de un articulo, y le asigan un orden para que aparezcan al final del listado de Stocks
   ''' </summary>
   ''' <param name="x_artic_codigo">Codigo del articulo</param>
   ''' <param name="x_zonas_codigo">Codigo de la zona</param>
   ''' <param name="x_almac_id">Codigo del almacen</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Public Function cargarStocks(ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String, ByVal x_almac_id As Short) As Boolean
      Try
         Dim m_bstocks As New BLOG_Stocks()
         If m_bstocks.ObtenerStockAlmacen(m_periodo, x_artic_codigo, x_almac_id, x_zonas_codigo) Then
            For Each Item As ELOG_Stocks In m_bstocks.ListLOG_Stocks
               Item.Orden = 5
            Next
            m_listStock = New List(Of ELOG_Stocks)(m_bstocks.ListLOG_Stocks)
            Return True
         Else
            m_listStock = New List(Of ELOG_Stocks)()
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

      Public Function cargarStocksremoto( ByVal x_periodo As String, ByVal x_almac_id As Short,ByVal x_linea As String ) As Boolean
      Try
         m_stockremoto = New DataTable()
         RETURN  d_consultaarticulos.LOG_STOCKSS_StockALaFecha(m_stockremoto,x_periodo,x_almac_id,x_linea)

      Catch ex As Exception
         Throw ex
      End Try
    

   End Function


   ''' <summary>
   ''' Cargar el stock de un articulo
   ''' </summary>
   ''' <param name="x_artic_codigo">codigo del articulo</param>
   ''' <param name="x_almac_id">Codigo del almacen</param>
   ''' <param name="x_zonas_codigo">Codigo de la zona</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Public Function cargarStocks(ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String) As Boolean
      Try
         Dim m_bstocks As New BLOG_Stocks()
         If m_bstocks.ObtenerStockAlmacen(m_periodo, x_artic_codigo, x_almac_id, x_zonas_codigo) Then
            m_stock = m_bstocks.ListLOG_Stocks(0)
            Return True
         Else
            m_stock = New ELOG_Stocks()
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar el detalle de un articulo
   ''' </summary>
   ''' <param name="x_artic_codigo">Codigo del articulo</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Public Function cargarProducto(ByVal x_artic_codigo As String) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TProd", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoProducto")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_Producto")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TCat", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodCategoria")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_Categoria")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TUnd", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodUnidadMedida")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_UnidadMedida") _
                                              , New ACCampos("TIPOS_DescCorta", "TIPOS_UndMedCorta")}))
         _join.Add(New ACJoin(ELineas.Esquema, ELineas.Tabla, "Linea", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("LINEA_Codigo", "LINEA_Codigo")} _
                              , New ACCampos() {New ACCampos("LINEA_Nombre", "LINEA_Nombre")}))
         Dim _where As New Hashtable
         _where.Add("ARTIC_Codigo", New ACWhere(x_artic_codigo))

         Dim m_barticulos As New BArticulos
         If m_barticulos.Cargar(_join, _where) Then
            m_earticulos = m_barticulos.Articulos
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar las ultimas compras realizadas de este articulo
   ''' </summary>
   ''' <param name="x_top">Cantidad de resultados que se mostraran</param>
   ''' <param name="x_artic_codigo">Codigo del articulo a consultar</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Public Function CargarUltimos(ByVal x_top As Integer, ByVal x_artic_codigo As String) As Boolean
      m_dtConsultaArticulos = New DataTable()
      Try
         Return d_consultaarticulos.CargarUltimos(m_dtConsultaArticulos, x_top, x_artic_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el listado de articulos con su respectivo stock, de cada almacen indicado en la estructura Hash, se obtendra los stock de cada punto de venta.
   ''' </summary>
   ''' <param name="x_periodo">Periodo que consultara el stock</param>
   ''' <param name="x_linea_codigo">Codigo de la linea/sublinea que se desea obtener</param>
   ''' <param name="x_user">Usuario de la Base de datos</param>
   ''' <param name="x_password">Contraseña de la base de datos</param>
   ''' <param name="x_pvent_id">Punto de venta local</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetStocksAlmacenes(ByVal x_periodo As String, ByVal x_linea_codigo As String, _
                                       ByVal x_user As String, ByVal x_password As String, ByVal x_pvent_id As Long) As Boolean
      Try
         Return d_consultaarticulos.GetStockAlmacenes(m_hash, m_listpuntoventa, x_periodo, x_linea_codigo, x_user, x_password, x_pvent_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el stock del almacen seleccionado
   ''' </summary>
   ''' <param name="x_artic_codigo">Codigo del articulo</param>
   ''' <param name="x_puntoventa">Clase punto de venta</param>
   ''' <param name="x_user">Usuario de la base de datos</param>
   ''' <param name="x_password">Contraseña de la base de datos</param>
   ''' <param name="x_liststock">Listado de stocks que se debe obtener</param>
   ''' <returns>devuelve un valor verdadero si se ejecuta la consulta correctamente</returns>
   ''' <remarks></remarks>
   Public Function GetStockAlmacen(ByVal x_artic_codigo As String, ByVal x_puntoventa As EPuntoVenta, _
                                       ByVal x_user As String, ByVal x_password As String, ByRef x_liststock As List(Of ACELogistica.ELOG_Stocks)) As Boolean
      Try
         Return d_consultaarticulos.GetStockAlmacen(m_periodo, x_artic_codigo, x_puntoventa, x_user, x_password, x_liststock)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar el listado de articulos
   ''' </summary>
   ''' <param name="x_join">Listado del objeto Join donde encuentra los join que se realizara para la consulta</param>
   ''' <param name="x_where">Objeto que contiene las condiciones para la consulta generado con el Join anterior</param>
   ''' <returns>devuelve el valor verdadero si se carga datos de la consulta ejecutada</returns>
   ''' <remarks></remarks>
   Public Function CargarTodos(ByVal x_join As List(Of ACFramework.ACJoin), ByVal x_where As Hashtable) As Boolean
      Try
         m_listarticulos = New List(Of EArticulos)()
         Dim _articulos As New BArticulos
         If _articulos.CargarTodos(x_join, x_where) Then
            m_listarticulos = _articulos.ListArticulos
            Return True
         Else
            m_listarticulos = New List(Of EArticulos)
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ' <summary> 
    ' Capa de Negocio: VENTSS_ObtenerArticulos
    ' </summary>
    ' <param name="x_perio_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    ' <param name="x_linea_codigo">Parametro 4: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    ' 
    Public Function ObtenerArticulosT(ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
      m_listarticulos = New List(Of EArticulos)
      Try
         Return d_consultaarticulos.VENTSS_ObtenerArticulosT(m_listarticulos, x_perio_codigo, x_almac_id,x_linea)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

      Public Function ObtenerArticulosPedido(ByVal x_orden_codigo As String) As Boolean
      m_listarticulos = New List(Of EArticulos)
      Try
         Return d_consultaarticulos.VENTSS_ObtenerArticulosPedido(m_listarticulos, x_orden_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    Public Function ObtenerArticulosXmetros(ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_linea As String) As Boolean
      m_listarticulos = New List(Of EArticulos)
      Try
         Return d_consultaarticulos.VENTSS_ObtenerArticulosXmetros(m_listarticulos, x_perio_codigo, x_almac_id,x_linea)
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   Public Function ObtenerArticulos(ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_linea_codigo As String) As Boolean
      m_listarticulos = New List(Of EArticulos)
      Try
         Return d_consultaarticulos.VENTSS_ObtenerArticulos(m_listarticulos, x_perio_codigo, x_almac_id, x_zonas_codigo, x_linea_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class


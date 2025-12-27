Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Imports ACEVentas.EUtilitarios
Imports DAConexion
Imports ACFramework


Public Class BArticulos


#Region " Variables "
   Private m_listPrecios As List(Of EPPrecios)
   Private m_listLPrecios As List(Of EVENT_ListaPrecios)
   ' Articulo Destino
   Private m_ListArtDestino As List(Of EArticDestinos)
   Private m_artdestin As EArticulos
   'Private m_inicio As EArticulos.TipoInicializacion

   ' Stock
   'Private m_stock_art As EArticulos

#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
   Public Property ListPrecios() As List(Of EPPrecios)
      Get
         Return m_listPrecios
      End Get
      Set(ByVal value As List(Of EPPrecios))
         m_listPrecios = value
      End Set
   End Property


   Public Property ListLPrecios() As List(Of EVENT_ListaPrecios)
      Get
         Return m_listLPrecios
      End Get
      Set(ByVal value As List(Of EVENT_ListaPrecios))
         m_listLPrecios = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
   Public Sub setArtDestinos(ByVal x_artDestinos As EArticulos)
      m_artdestin = x_artDestinos
   End Sub

   Public Function getListArtDestinos() As List(Of EArticDestinos)
      Return m_ListArtDestino
   End Function

   'Public Function getArticulosDestinos() As EArticDestinos 
   '   Return Me.m_artdest
   'End Function


#End Region

#Region " Metodos "

   ''' <summary> 
   ''' Capa de Negocio: ARTICSS_ProductosPrecios
   ''' </summary>
   ''' <param name="x_linea_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ProductosPrecios(ByVal x_zonas_codigo As String, ByVal x_linea_codigo As String) As Boolean
      m_listArticulos = New List(Of EArticulos)
      m_listPrecios = New List(Of EPPrecios)
      m_listLPrecios = New List(Of EVENT_ListaPrecios)
      Try
         Return d_articulos.ARTICSS_ProductosPrecios(m_listArticulos, m_listPrecios, m_listLPrecios, x_zonas_codigo, x_linea_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de articulos
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin("dbo", ETipos.Tabla, "CodTip", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoProducto")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIP_Descripcion")}))


         Dim _where As New Hashtable()
         _where.Add("ARTIC_Detalle", New ACWhere(x_cadena, ACWhere.TipoWhere._Like))

         m_listArticulos = New List(Of EArticulos)()
         Return d_articulos.ARTICSS_Todos(m_listArticulos, _join, _where)

      Catch ex As Exception
         Throw ex
      End Try

   End Function

   ''' <summary>
   ''' Obtener el correlativo del articulo segun la linea que se selecciones
   ''' </summary>
   ''' <param name="x_artcod">correlativo</param>
   ''' <param name="x_codlin">codigo de la linea</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getCodCorrelativo(ByRef x_artcod As Integer, ByVal x_codlin As String) As String
      Try
         x_artcod = d_articulos.getCorrelativo(x_codlin) + 1
         Dim x_codigo As String = x_codlin & x_artcod.ToString().PadLeft(3, "0")
         Return x_codigo
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   '''  Grabar el registro
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_zonas_codigo">codgio de la zona</param>
   ''' <param name="x_inicio">tipo de inicializacion</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Guardar(ByVal x_usuario As String, ByVal x_zonas_codigo As String, ByVal x_inicio As EArticulos.TipoInicializacion) As Boolean
      Try
         Select Case x_inicio
            Case EArticulos.TipoInicializacion.Articulos_Destino
               DAEnterprise.BeginTransaction()
               '' Articulos Destinos
               If Not IsNothing(m_articulos.ListArtDestinos) Then
                  For Each Item As EArticDestinos In m_articulos.ListArtDestinos
                     Item.ARTIC_Codigo = m_articulos.ARTIC_Codigo
                     Dim _bartdest As New BArticDestinos() With {.ArticDestinos = Item}
                     _bartdest.ArticDestinos.Instanciar(ACEInstancia.Nuevo)
                     _bartdest.Guardar(x_usuario)
                  Next
               End If
               '' Eliminar
               If Not IsNothing(m_ListArtDestino) Then
                  For Each Item As EArticDestinos In m_ListArtDestino
                     Item.ARTIC_Codigo = m_articulos.ARTIC_Codigo
                     Dim _bartdest As New BArticDestinos() With {.ArticDestinos = Item}
                     _bartdest.ArticDestinos.Instanciar(ACEInstancia.Eliminado)
                     _bartdest.Guardar(x_usuario)
                  Next
               End If
               '' Completar la operacion cerrando la transacción
               DAEnterprise.CommitTransaction()
               Return True
            Case EArticulos.TipoInicializacion.Stock

            Case EArticulos.TipoInicializacion.Todos
               DAEnterprise.BeginTransaction()
               If m_articulos.Nuevo Then m_articulos.ARTIC_Id = getCorrelativo("ARTIC_Id")
               If Guardar(x_usuario) Then
                  GuardarListaPrecios(x_usuario, x_zonas_codigo, False)

                  'GuardarStocks(x_usuario, False)
                  '' Completar la operacion cerrando la transacción
                  DAEnterprise.CommitTransaction()
                  Return True
               Else
                  DAEnterprise.RollBackTransaction()
                  Return False
               End If
            Case Else

         End Select
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try

   End Function

   ''' <summary>
   ''' Guardar lista de precios
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuarios</param>
   ''' <param name="x_zonas_codigo">Codigo de Zonas</param>
   ''' <param name="x_tran">Para utilizar la transaccion en la funcion</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GuardarListaPrecios(ByVal x_usuario As String, ByVal x_zonas_codigo As String, ByVal x_tran As Boolean) As Boolean
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         Dim _precios As New BPrecios
         If _precios.Cargar(x_zonas_codigo, m_articulos.ARTIC_Codigo) Then
            _precios.Precios = New EPrecios
            _precios.Precios.Instanciar(ACEInstancia.Modificado)
         Else
            _precios.Precios = New EPrecios
            _precios.Precios.Instanciar(ACEInstancia.Nuevo)
         End If
         _precios.Precios.ZONAS_Codigo = x_zonas_codigo
         _precios.Precios.ARTIC_Codigo = m_articulos.ARTIC_Codigo
         _precios.Precios.PRECI_Precio = m_articulos.PRECI_Precio
         _precios.Precios.PRECI_TipoCambio = m_articulos.PRECI_TipoCambio
         _precios.Precios.TIPOS_CodTipoMoneda = m_articulos.TIPOS_CodTipoMoneda
         If _precios.Guardar(x_usuario) Then
            Dim b_blistaprecios As New BVENT_ListaPreciosArticulos()
            For Each Item As EVENT_ListaPreciosArticulos In m_articulos.ListVentPrecios
               b_blistaprecios.VENT_ListaPreciosArticulos = Item
               b_blistaprecios.VENT_ListaPreciosArticulos.ARTIC_Codigo = m_articulos.ARTIC_Codigo
               b_blistaprecios.Guardar(x_usuario)
            Next
            If x_tran Then DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No se puede completar la")
         End If
      Catch ex As Exception
         If x_tran Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Guardar precios
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_tran">para el uso de transacciones en esta funcion</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GuardarPrecios(ByVal x_usuario As String, ByVal x_tran As Boolean) As Boolean
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         Dim b_bprecios As New BPrecios
         For Each Item As EPrecios In m_articulos.ListPrecios
            b_bprecios.Precios = Item
            b_bprecios.Precios.ARTIC_Codigo = m_articulos.ARTIC_Codigo
            b_bprecios.Guardar(x_usuario)
         Next
         If x_tran Then DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         If x_tran Then DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar articulos destino, es decir el destino de un articulo es aquel en el que se puede transformar el articulo
   ''' </summary>
   ''' <param name="x_artic_codigo">codigo del articulo</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarArtDest(ByVal x_artic_codigo As String) As Boolean
      Try
         Dim x_artdest As New BArticDestinos
         If x_artdest.CargarArtDestin(x_artic_codigo) Then
            m_articulos.ListArtDestinos = New List(Of EArticDestinos)(x_artdest.ListArticDestinos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' 
   ''' </summary>
   ''' <param name="x_artic_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarStock(ByVal x_artic_codigo As String) As Boolean
      Try
         Dim x_artstock As New ACBLogistica.Blog_Stocks
         'If x_artstock.CargarSStock(x_artic_codigo) Then
         '   m_articulos.ListLOG_Stocks = New List(Of ACELogistica.ELOG_Stocks)(x_artstock.ListStocks)
         '   Return True
         'End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar la listas de precios de un articulo
   ''' </summary>
   ''' <param name="x_artic_codigo">codigo de articulos</param>
   ''' <param name="x_zonas_codigo">codigo de la zona</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarListaPrecios(ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String) As Boolean
      Try
         Dim x_bvent_listaprecios As New BVENT_ListaPreciosArticulos
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EVENT_ListaPrecios.Esquema, EVENT_ListaPrecios.Tabla, ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("LPREC_Id", "LPREC_Id"), New ACCampos("ZONAS_Codigo", "ZONAS_Codigo")} _
                              , New ACCampos() {New ACCampos("LPREC_Descripcion", "LPREC_Descripcion")}))
         _join.Add(New ACJoin(EZonas.Esquema, EZonas.Tabla, ACJoin.TipoJoin.Inner _
                                       , New ACCampos() {New ACCampos("ZONAS_Codigo", "ZONAS_Codigo")} _
                                       , New ACCampos() {New ACCampos("ZONAS_Descripcion", "ZONAS_Descripcion")}))
         Dim _where As New Hashtable : _where.Add("ARTIC_Codigo", New ACWhere(x_artic_codigo))
         _where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         _where.Add(ACWhere.OrderBy, New ACWhere(New ACOrderBy() {New ACOrderBy("ZONAS_Codigo", ACOrderBy.Ordenamiento.Ascendente), New ACOrderBy("LPREC_Id", ACOrderBy.Ordenamiento.Ascendente)}))
         If x_bvent_listaprecios.CargarTodos(_join, _where) Then
            m_articulos.ListVentPrecios = New List(Of EVENT_ListaPreciosArticulos)(x_bvent_listaprecios.ListVENT_ListaPreciosArticulos)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar precios de un articulo
   ''' </summary>
   ''' <param name="x_artic_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarPrecios(ByVal x_artic_codigo As String) As Boolean
      Try
         Dim x_bvent_precios As New BPrecios
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EZonas.Esquema, EZonas.Tabla, ACJoin.TipoJoin.Inner _
                                       , New ACCampos() {New ACCampos("ZONAS_Codigo", "ZONAS_Codigo")} _
                                       , New ACCampos() {New ACCampos("ZONAS_Descripcion", "ZONAS_Descripcion")}))
         Dim _where As New Hashtable : _where.Add("ARTIC_Codigo", New ACWhere(x_artic_codigo))
         _where.Add(ACWhere.OrderBy, New ACWhere(New ACOrderBy() {New ACOrderBy("ZONAS_Codigo", ACOrderBy.Ordenamiento.Ascendente)}))
         If x_bvent_precios.CargarTodos(_join, _where) Then
            m_articulos.ListPrecios = New List(Of EPrecios)(x_bvent_precios.ListPrecios)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: ARTICSS_UnRegistro
   ''' </summary>
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function UnRegistro(ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String) As Boolean
      m_articulos = New EArticulos
      Try
         Return d_articulos.ARTICSS_UnRegistro(m_articulos, x_artic_codigo, x_zonas_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' generar el codigo SQL para guardar un articulo
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GuardarSQL(ByVal x_usuario As String) As String
      Try
         If m_articulos.Nuevo Then
            Return d_articulos.ARTICSI_UnRegSQL(m_articulos, x_usuario)
         ElseIf m_articulos.Modificado Then
            Return d_articulos.ARTICSU_UnRegSQL(m_articulos, x_usuario)
         ElseIf m_articulos.Eliminado Then
            Return d_articulos.ARTICSD_UnReg(m_articulos)
         End If
         Return ""
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class


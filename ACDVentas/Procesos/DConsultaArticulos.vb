Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DConsultaArticulos

#Region " Variables "
   Private m_formatofecha As String
   Private m_listPuntoVenta As List(Of EPuntoVenta)
#End Region

#Region " Constructores "
   Public Sub New()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
   End Sub
#End Region

#Region " Procedimientos Almacenados "

   ''' <summary>
   ''' Obtener listado de almacenes
   ''' </summary>
   ''' <param name="x_hash"></param>
   ''' <param name="x_listpuntoventa"></param>
   ''' <param name="x_periodo"></param>
   ''' <param name="x_linea_codigo"></param>
   ''' <param name="x_user"></param>
   ''' <param name="x_password"></param>
   ''' <param name="x_pvent_id"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetStockAlmacenes(ByRef x_hash As Hashtable, ByRef x_listpuntoventa As List(Of EPuntoVenta), _
                                       ByVal x_periodo As String, ByVal x_linea_codigo As String, _
                                       ByVal x_user As String, ByVal x_password As String, ByVal x_pvent_id As Long) As Boolean
      x_listpuntoventa = New List(Of EPuntoVenta)
      x_hash = New Hashtable
      Dim _sql As String = ""
      Try
         If IsNothing(m_listPuntoVenta) Then
            If ARTICSS_ConexionStocksAlmacenes(x_listpuntoventa, x_pvent_id) Then
               m_listPuntoVenta = x_listpuntoventa
            Else
               Return False
            End If
         Else
            x_listpuntoventa = m_listPuntoVenta
         End If
         For Each item As EPuntoVenta In m_listPuntoVenta
            If item.AlmacenActivo Then
               Dim _cadConexion As String = String.Format("data source = {0}; initial catalog = {1}; user id = {2}; password = {3}", _
                                                  item.PVENT_DireccionIP, item.PVENT_BaseDatos, x_user, x_password)
               App.Inicializar()
               _sql = String.Format(App.Hash("DConsultaArticulos.GetPreciosAlmacenes").ToString(), x_periodo, x_linea_codigo, item.ALMAC_Id)

               Dim _dataAdapter As SqlDataAdapter
               Dim _dataTable As New DataTable
               Try
                  _dataAdapter = New SqlDataAdapter(_sql, _cadConexion)
                  _dataAdapter.Fill(_dataTable)
                  Dim _listStocks As New List(Of ACELogistica.ELOG_Stocks)
                  For Each Precio As DataRow In _dataTable.Rows
                     Dim _stocks As New ACELogistica.ELOG_Stocks()
                     ACEsquemas.ACCargarEsquema(Precio, _stocks)
                     _stocks.Instanciar(ACEInstancia.Consulta)
                     _stocks.VSPVA_ParaPedidos = item.VSPVA_ParaPedidos
                     _listStocks.Add(_stocks)
                  Next
                  x_hash.Add(item.ALMAC_Id.ToString(), _listStocks)
               Catch ex As Exception
                  item.AlmacenActivo = False
               End Try
            End If
         Next
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener stock por almacen
   ''' </summary>
   ''' <param name="x_periodo"></param>
   ''' <param name="x_artic_codigo"></param>
   ''' <param name="x_puntoventa"></param>
   ''' <param name="x_user"></param>
   ''' <param name="x_password"></param>
   ''' <param name="x_liststock"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetStockAlmacen(ByVal x_periodo As String, ByVal x_artic_codigo As String, ByVal x_puntoventa As EPuntoVenta, _
                                   ByVal x_user As String, ByVal x_password As String, ByRef x_liststock As List(Of ACELogistica.ELOG_Stocks)) As Boolean
      Dim _sql As String = ""
      Try
         App.Inicializar()
         _sql = String.Format(App.Hash("DConsultaArticulos.GetStockAlmacen").ToString(), x_periodo, x_artic_codigo, x_puntoventa.ALMAC_Id)
         Dim _cadConexion As String = String.Format("data source = {0}; initial catalog = {1}; user id = {2}; password = {3}", _
                                                  x_puntoventa.PVENT_DireccionIP, x_puntoventa.PVENT_BaseDatos, x_user, x_password)
         Try
            Dim _dataAdapter As SqlDataAdapter
            Dim _dataTable As New DataTable
            _dataAdapter = New SqlDataAdapter(_sql, _cadConexion)
            _dataAdapter.Fill(_dataTable)
            x_liststock = New List(Of ACELogistica.ELOG_Stocks)
            For Each Stock As DataRow In _dataTable.Rows
               Dim x_stock As New ACELogistica.ELOG_Stocks()
               ACEsquemas.ACCargarEsquema(Stock, x_stock)
               x_stock.Instanciar(ACEInstancia.Consulta)
               x_liststock.Add(x_stock)
            Next
         Catch ex As Exception
         End Try

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: ARTICSS_ConexionStocksAlmacenes
   ''' </summary>
   ''' <param name="x_pvent_id">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ARTICSS_ConexionStocksAlmacenes(ByVal m_listpuntoventa As List(Of EPuntoVenta), ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ARTICSS_ConexionStocksAlmacenes")
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _puntoventa As New EPuntoVenta()
                  ACEsquemas.ACCargarEsquema(reader, _puntoventa)
                  _puntoventa.Instanciar(ACEInstancia.Consulta)
                  _puntoventa.AlmacenActivo = True
                  m_listpuntoventa.Add(_puntoventa)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ''' <summary> 
   ''' Capa de Datos: VEN_ARTICSS_ObtenerPrecios
   ''' </summary>
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ARTICSS_ObtenerPrecios(ByVal m_listpprecios As List(Of EPPrecios), ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ARTICSS_ObtenerPrecios")
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 7)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _pprecios As New EPPrecios()
                  ACEsquemas.ACCargarEsquema(reader, _pprecios)
                  _pprecios.Instanciar(ACEInstancia.Consulta)
                  m_listpprecios.Add(_pprecios)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: ARTICSS_ObtenerPrecioLista
   ''' </summary>
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <param name="x_lprec_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ARTICSS_ObtenerPrecioLista(ByVal x_pprecios As EPPrecios, ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String, ByVal x_lprec_id As Integer) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ARTICSS_ObtenerPrecioLista")
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 7)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@LPREC_Id", x_lprec_id, DbType.Int32, 4)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_pprecios)
               x_pprecios.Instanciar(ACEInstancia.Consulta)
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
     ''' <summary> 
   ''' Capa de Datos: ARTICSS_ObtenerPrecioLista
   ''' </summary>
   ''' <param name="x_artic_codigo">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <param name="x_lprec_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ARTICSS_ObtenerPrecioListaEspecial(ByVal x_pprecios As EPPrecios, ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String, ByVal x_lprec_id As Integer) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ARTICSS_ObtenerPrecioListaEspecial")
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 7)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@LPREC_Id", x_lprec_id, DbType.Int32, 4)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_pprecios)
               x_pprecios.Instanciar(ACEInstancia.Consulta)
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     
    
      Public Function LOG_STOCKSS_StockALaFecha(ByRef x_datatable As DataTable, ByVal x_perio_codigo As String, ByVal x_almac_id As Integer, ByVal x_linea As Integer) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_StockXLote")
        DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 4)
         
         x_datatable = DAEnterprise.ExecuteDataSet().Tables(0)
         Return (x_datatable.Rows.Count > 0)
            
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary>
   ''' cargar lista de preccios de un articulo
   ''' </summary>
   ''' <param name="listPrecios"></param>
   ''' <param name="x_zonas_codigo"></param>
   ''' <param name="x_artic_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function cargarPrecios(ByRef listPrecios As List(Of EPPrecios), ByVal x_zonas_codigo As String, ByVal x_artic_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_zonas_codigo, x_artic_codigo), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EPPrecios())
               While reader.Read()
                  Dim e_precios As New EPPrecios()
                  _utilitarios.ACCargarEsquemas(reader, e_precios)
                  e_precios.Instanciar(ACEInstancia.Consulta)
                  listPrecios.Add(e_precios)
               End While
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar ultimos precios
   ''' </summary>
   ''' <param name="m_datos"></param>
   ''' <param name="x_top"></param>
   ''' <param name="x_artic_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarUltimos(ByRef m_datos As DataTable, ByVal x_top As Integer _
                              , ByVal x_artic_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_top, x_artic_codigo), CommandType.Text)
         m_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return m_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ' <summary> 
    ' Capa de Datos: VENTSS_ObtenerArticulos
    ' </summary>
    ' <param name="x_perio_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    ' <param name="x_linea_codigo">Parametro 4: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    ''' 
    Public Function VENTSS_ObtenerArticulosT(ByVal m_listarticulos As List(Of EArticulos), ByVal x_perio_codigo As String, ByVal x_almac_id As Short,
                                            ByVal x_linea As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_StockXLote")
         DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 4)
         
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _articulos As New EArticulos()
                  ACEsquemas.ACCargarEsquema(reader, _articulos)
                  _articulos.Instanciar(ACEInstancia.Consulta)
                  m_listarticulos.Add(_articulos)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
     Public Function VENTSS_ObtenerArticulosXmetros(ByVal m_listarticulos As List(Of EArticulos), ByVal x_perio_codigo As String, ByVal x_almac_id As Short,
                                            ByVal x_linea As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_StockXLoteMetros")
         DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 4)
         
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _articulos As New EArticulos()
                  ACEsquemas.ACCargarEsquema(reader, _articulos)
                  _articulos.Instanciar(ACEInstancia.Consulta)
                  m_listarticulos.Add(_articulos)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function


     Public Function VENTSS_ObtenerArticulosPedido(ByVal m_listarticulos As List(Of EArticulos), ByVal x_orden_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_StockXPedidoPro")
         DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
       
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _articulos As New EArticulos()
                  ACEsquemas.ACCargarEsquema(reader, _articulos)
                  _articulos.Instanciar(ACEInstancia.Consulta)
                  m_listarticulos.Add(_articulos)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function



   Public Function VENTSS_ObtenerArticulos(ByVal m_listarticulos As List(Of EArticulos), ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_linea_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENTSS_ObtenerArticulos")
         DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@LINEA_Codigo", x_linea_codigo, DbType.String, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _articulos As New EArticulos()
                  ACEsquemas.ACCargarEsquema(reader, _articulos)
                  _articulos.Instanciar(ACEInstancia.Consulta)
                  m_listarticulos.Add(_articulos)
               End While
               Return True
            Else
               Return False
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region " Adicionales "
   Private Function getSelectAll(ByVal x_zonas_codigo As String, ByVal x_artic_codigo As String)
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim _where As New ACGenerador(Of EEntidades)(m_formatofecha)
         sql &= String.Format(App.Hash("DConsultaArticulos.cargarPrecios").ToString(), x_artic_codigo, x_zonas_codigo)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectAll(ByVal x_top As Integer, ByVal x_artic_codigo As String) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= String.Format(App.Hash("DConsultaArticulos.CargarUltimos"), x_top.ToString(), x_artic_codigo)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

#Region " Metodos "

#End Region

End Class


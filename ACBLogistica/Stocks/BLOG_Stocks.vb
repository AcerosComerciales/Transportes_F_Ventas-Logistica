Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica

Partial Public Class BLOG_Stocks

#Region " Variables "
	
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Negocio: LOG_STOCKSS_ObtenerStock
   ''' </summary>
   ''' <param name="x_perio_codigo">Parametro 1: </param> 
   ''' <param name="x_artic_codigo">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerStock(ByVal x_perio_codigo As String, ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String) As Boolean
      m_listLOG_Stocks = New List(Of ELOG_Stocks)
      Try
         Return d_log_stocks.LOG_STOCKSS_ObtenerStock(m_listLOG_Stocks, x_perio_codigo, x_artic_codigo, x_zonas_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_STOCKSS_ObtenerStockAlmacen
   ''' </summary>
   ''' <param name="x_perio_codigo">Parametro 1: </param> 
   ''' <param name="x_artic_codigo">Parametro 2: </param> 
   ''' <param name="x_almac_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerStockAlmacen(ByVal x_perio_codigo As String, ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String) As Boolean
      m_listLOG_Stocks = New List(Of ELOG_Stocks)
      Try
         Return d_log_stocks.LOG_STOCKSS_ObtenerStockAlmacen(m_listLOG_Stocks, x_perio_codigo, x_artic_codigo, x_almac_id, x_zonas_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class


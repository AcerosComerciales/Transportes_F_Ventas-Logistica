Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Partial Public Class DLOG_Stocks

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "


   ''' <summary> 
   ''' Capa de Datos: LOG_STOCKSS_ObtenerStock
   ''' </summary>
   ''' <param name="x_perio_codigo">Parametro 1: </param> 
   ''' <param name="x_artic_codigo">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_STOCKSS_ObtenerStock(ByVal m_listlog_stocks As List(Of ELOG_Stocks), ByVal x_perio_codigo As String, ByVal x_artic_codigo As String, ByVal x_zonas_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_STOCKSS_ObtenerStock")
         DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 7)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _log_stocks As New ELOG_Stocks()
                  ACEsquemas.ACCargarEsquema(reader, _log_stocks)
                  _log_stocks.Instanciar(ACEInstancia.Consulta)
                  m_listlog_stocks.Add(_log_stocks)
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
   ''' Capa de Datos: LOG_STOCKSS_ObtenerStockAlmacen
   ''' </summary>
   ''' <param name="x_perio_codigo">Parametro 1: </param> 
   ''' <param name="x_artic_codigo">Parametro 2: </param> 
   ''' <param name="x_almac_id">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_STOCKSS_ObtenerStockAlmacen(ByVal m_listlog_stocks As List(Of ELOG_Stocks), ByVal x_perio_codigo As String, ByVal x_artic_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_STOCKSS_ObtenerStockAlmacen")
         DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 7)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _log_stocks As New ELOG_Stocks()
                  ACEsquemas.ACCargarEsquema(reader, _log_stocks)
                  _log_stocks.Instanciar(ACEInstancia.Consulta)
                  m_listlog_stocks.Add(_log_stocks)
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

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "

#End Region

End Class


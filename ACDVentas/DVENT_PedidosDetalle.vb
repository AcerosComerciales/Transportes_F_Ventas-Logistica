Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DVENT_PedidosDetalle


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   ''' <summary> 
   ''' Capa de Datos: VENT_PEDIDSS_ObtDetPedidoReposicion
   ''' </summary>
   ''' <param name="x_pedid_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_ObtDetPedidoReposicion(ByVal m_listvent_pedidosdetalle As List(Of EVENT_PedidosDetalle), ByVal x_pedid_codigo As String, ByVal x_almac_id As Short) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_ObtDetPedidoReposicion")
         DAEnterprise.AgregarParametro("@PEDID_Codigo", x_pedid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidosdetalle As New EVENT_PedidosDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidosdetalle)
                  _vent_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidosdetalle.Add(_vent_pedidosdetalle)
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


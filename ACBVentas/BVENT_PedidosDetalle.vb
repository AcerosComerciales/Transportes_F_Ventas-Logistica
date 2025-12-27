Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Public Class BVENT_PedidosDetalle


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
   ''' Capa de Negocio: VENT_PEDIDSS_ObtDetPedidoReposicion
   ''' </summary>
   ''' <param name="x_pedid_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_ObtDetPedidoReposicion(ByVal x_pedid_codigo As String, ByVal x_almac_id As Short) As Boolean
      m_listvent_pedidosdetalle = New List(Of EVENT_PedidosDetalle)
      Try
         Return d_vent_pedidosdetalle.VENT_PEDIDSS_ObtDetPedidoReposicion(m_listvent_pedidosdetalle, x_pedid_codigo, x_almac_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class


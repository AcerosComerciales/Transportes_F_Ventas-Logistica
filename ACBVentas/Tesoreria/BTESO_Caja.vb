Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_Caja

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
   ''' Capa de Negocio: TESO_CAJASS_ObtenerDocPagosDetalle
   ''' </summary>
   ''' <param name="x_dpago_id">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerDocPagosDetalle(ByVal x_dpago_id As Long) As Boolean
      m_listTESO_Caja = New List(Of ETESO_Caja)
      Try
         Return d_teso_caja.TESO_CAJASS_ObtenerDocPagosDetalle(m_listTESO_Caja, x_dpago_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' modificar fecha de impresion
   ''' </summary>
   ''' <param name="x_fecha">fehca nueva</param>
   ''' <param name="x_importe">importe</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ModificarImpFec(ByVal x_fecha As DateTime, ByVal x_importe As Decimal, ByVal x_usuario As String) As Boolean
      Try
         Return d_teso_caja.ModificarImpFec(m_eteso_caja, x_fecha, x_importe, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' modificar fecha
   ''' </summary>
   ''' <param name="x_fecha">fecha nueva</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ModificarFecha(ByVal x_fecha As DateTime, ByVal x_usuario As String) As Boolean
      Try
         Return d_teso_caja.ModificarFecha(m_eteso_caja, x_fecha, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cambiar estado de un registro de caja
   ''' </summary>
   ''' <param name="x_caja_id">Id de caja, el id es unico por punto de venta</param>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <param name="x_caja_fecha">fecha de caja</param>
   ''' <param name="x_estado">estado que se desea colocar</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CambiarEstado(ByVal x_caja_id As Long, ByVal x_pvent_id As Integer, ByVal x_caja_fecha As DateTime, ByVal x_estado As ETESO_Caja.Estado, ByVal x_usuario As String) As Boolean
      Try
         Return d_teso_caja.CambiarEstado(x_caja_id, x_pvent_id, x_caja_fecha, x_estado, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class


Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACFramework
Imports ACEVentas
Imports ACBVentas

Public Class BTRAN_VehiculosConductores

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   ' <summary>
   ' Cargar todas las ranflas disponibles y no disponibles, segun el parametro x_opcion
   ' </summary>
   ' <param name="x_opcion"></param>
   ' <returns></returns>
   ' <remarks></remarks>
   Public Function CargarTodos(ByVal x_opcion As Boolean, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Dim d_tran_vehiculosconductores As New DTRAN_VehiculosConductores()
      Try
         m_listTRAN_VehiculosConductores = New List(Of ETRAN_VehiculosConductores)()
         Return d_tran_vehiculosconductores.VHCOSS_Todos(m_listTRAN_VehiculosConductores, x_opcion, x_tipoentidad)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   
    Public Function CargarConductoresXNombre(ByVal x_vehic_id As Long, ByVal x_opcion As Boolean, ByVal x_estado As Boolean, ByVal x_tipoentidad As EEntidades.TipoEntidad,Byval x_nombre As String ) As Boolean
        '=====================================FUNCION CREADO FRANK 08-11-2025================================================================================
            Dim d_tran_vehiculosconductores As New DTRAN_VehiculosConductores()
      Try
         m_listTRAN_VehiculosConductores = New List(Of ETRAN_VehiculosConductores)()
         Return d_tran_vehiculosconductores.BuscarConductorXNombre(m_listTRAN_VehiculosConductores, x_vehic_id, x_opcion, x_estado, x_tipoentidad,x_nombre)
      Catch ex As Exception
         Throw ex
      End Try


    End Function


   Public Function CargarTodos(ByVal x_vehic_id As Long, ByVal x_opcion As Boolean, ByVal x_estado As Boolean, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Dim d_tran_vehiculosconductores As New DTRAN_VehiculosConductores()
      Try
         m_listTRAN_VehiculosConductores = New List(Of ETRAN_VehiculosConductores)()
         Return d_tran_vehiculosconductores.VHCOSS_Todos(m_listTRAN_VehiculosConductores, x_vehic_id, x_opcion, x_estado, x_tipoentidad)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CargarAyuda(ByVal x_cadena As String, ByVal x_campo As String) As Boolean
      Dim d_tran_vehiculosconductores As New DTRAN_VehiculosConductores()
      Try
         Dim _where As New Hashtable()
         _where.Add(x_campo, New ACWhere(x_cadena, "Vehi", "A".GetType.ToString(), ACWhere.TipoWhere._Like))
         _where.Add("VEHIC_Estado", New ACWhere(ETRAN_Vehiculos.getEstado(ETRAN_Vehiculos.Estado.Anulado), "Vehi", "A".GetType.ToString(), ACWhere.TipoWhere.Diferente))
         _where.Add("VHCON_Estado", New ACWhere(BConstantes.getEstado(BConstantes.Estados.Activo), "VCond", "A".GetType.ToString(), ACWhere.TipoWhere._Like))
         '_where.Add("VEHIC_ESTADOVIAJE", New ACWhere(BConstantes.getEstado(BConstantes.EstadosVehiculoViaje.Disponible), "Vehi", "A".GetType().ToString(), ACWhere.TipoWhere.Igual))
         m_dtTRAN_VehiculosConductores = New DataTable()
         Return d_tran_vehiculosconductores.VHCOSS_TodosAyuda(m_dtTRAN_VehiculosConductores, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class


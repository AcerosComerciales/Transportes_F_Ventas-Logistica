Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACEVentas
'Imports ACDVentas

Imports ACFramework

Public Class BTRAN_VehiculosInventarioDetalle

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         m_listTRAN_VehiculosInventarioDetalle = New List(Of ETRAN_VehiculosInventarioDetalle)()
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(ETRAN_Vehiculos.Esquema, ETRAN_Vehiculos.Tabla, "Tvehiculos", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("VEHIC_Id", "VEHIC_Id")} _
                              , New ACCampos() {New ACCampos("VEHIC_Placa", "VEHIC_Placa")}))

         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "Tcategoria", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodCategoria")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_CodCategoria")}))

         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TAccesorio", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodAccesorios")} _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_Codigo") _
                                              , New ACCampos("TIPOS_Descripcion", "TIPOS_CodAccesorios")}))

         _join.Add(New ACJoin(ETRAN_VehiculosInventario.Esquema, ETRAN_VehiculosInventario.Tabla, "TVehiculosInventario", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("VEHIN_Id", "VEHIN_Id")} _
                              , New ACCampos() {New ACCampos("VEHIN_Responsable", "VEHIN_Responsable")}))

         Dim _where As New Hashtable()

         If Not x_todos Then
            _where.Add("VEHIN_Estado", New ACWhere(ETRAN_VehiculosInventario.getEstado(ETRAN_VehiculosInventario.Estado.Activo), "TVehiculosInventario", "System.String", ACWhere.TipoWhere.Igual))

         End If
         Return CargarTodos(_join, _where)

      Catch ex As Exception
         Throw ex
      End Try

   End Function


   ' <summary> 
   ' Capa de Negocio: TRAN_INVSS_TodosObjetosInventario
   ' </summary>
   ' <param name="x_vehic_id">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TodosObjetosInventario(ByVal x_vehic_id As Long) As Boolean
      m_listTRAN_VehiculosInventarioDetalle = New List(Of ETRAN_VehiculosInventarioDetalle)
      Try
         Return d_tran_vehiculosinventariodetalle.TRAN_INVSS_TodosObjetosInventario(m_listTRAN_VehiculosInventarioDetalle, x_vehic_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class


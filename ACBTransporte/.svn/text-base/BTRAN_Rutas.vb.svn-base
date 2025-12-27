Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports DAConexion
Imports ACBVentas
Imports ACEVentas

Imports ACFramework

Public Class BTRAN_Rutas

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function Busqueda(ByVal x_cadena As String) As Boolean
      Try
         m_listTRAN_Rutas = New List(Of ETRAN_Rutas)()
         Return d_tran_rutas.RUTASS_Todos(m_listTRAN_Rutas, x_cadena)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Ayuda(ByVal x_where As Hashtable) As Boolean
      Try
         m_dtTRAN_Rutas = New DataTable()
         Return d_tran_rutas.RUTASS_TodosAyuda(m_dtTRAN_Rutas, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Guardar(ByVal x_usuario As String, ByVal x_generar_codigo As Boolean) As Boolean
      Try
         Dim d_tran_rutas As New DTRAN_Rutas()
         If x_generar_codigo Then
            If m_tran_rutas.Nuevo Then
               DAEnterprise.BeginTransaction()
               Dim b_correlativo As New BCorrelativos()
               Try
                  b_correlativo.getCorrelativo(BConstantes.SUCUR_Id, ACEVentas.ECorrelativos.NTabla.TRAN_Rutas)
                  m_tran_rutas.RUTAS_Codigo = b_correlativo.Correlativos.Codigo
                  d_tran_rutas.TRAN_RUTASSI_UnReg(m_tran_rutas, x_usuario)
                  b_correlativo.Correlativos.ZONAS_Codigo = BConstantes.ZONAS_Codigo
                  b_correlativo.SetCorrelativo(x_usuario)
                  DAEnterprise.CommitTransaction()
                  Return True
               Catch ex As Exception
                  DAEnterprise.RollBackTransaction()
                  Throw ex
               End Try
            ElseIf m_tran_rutas.Modificado Then
               d_tran_rutas.TRAN_RUTASSU_UnReg(m_tran_rutas, x_usuario)
            ElseIf m_tran_rutas.Eliminado Then
               d_tran_rutas.TRAN_RUTASSD_UnReg(m_tran_rutas)
            End If
            Return True
         Else
            Return Guardar(x_usuario)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Cargar(ByVal x_rutas_id As Long, ByVal x_detalles As Boolean) As Boolean
      Dim _join As New List(Of ACJoin)
      Dim _where As New Hashtable
      Try
         _join.Add(New ACJoin(EUbigeos.Esquema, EUbigeos.Tabla, "Ori", ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("UBIGO_Codigo", "UBIGO_CodOrigen")}, _
                              New ACCampos() {New ACCampos("UBIGO_Descripcion", "UBIGO_Origen")}))
         _join.Add(New ACJoin(EUbigeos.Esquema, EUbigeos.Tabla, "Dest", ACJoin.TipoJoin.Inner, _
                              New ACCampos() {New ACCampos("UBIGO_Codigo", "UBIGO_CodDestino")}, _
                              New ACCampos() {New ACCampos("UBIGO_Descripcion", "UBIGO_Destino")}))
         _where.Add("RUTAS_Id", New ACWhere(x_rutas_id))
         Return Cargar(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class


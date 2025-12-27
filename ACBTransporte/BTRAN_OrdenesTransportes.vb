Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACFramework

Public Class BTRAN_OrdenesTransportes


#Region " Variables "

#End Region

#Region " Constructores "
   'Public Sub New(ByVal x_opcion As Boolean)
   '   If x_opcion Then
   '      m_tran_ordenestransportes = New ETRAN_OrdenesTransportes()
   '      m_listTRAN_OrdenesTransportes = New List(Of ETRAN_OrdenesTransportes)
   '   End If
   'End Sub
#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function CargarAyuda(ByVal x_where As Hashtable) As Boolean
      Dim d_tran_ordenestransportes As New DTRAN_OrdenesTransportes()
      Try
         If IsNothing(x_where) Then
            x_where = New Hashtable()
         End If
         x_where.Add("ORDTR_Estado", New ACWhere(ETRAN_OrdenesTransportes.getEstado(ETRAN_OrdenesTransportes.Estado.Activo), ACWhere.TipoWhere.Igual))
         m_dtTRAN_OrdenesTransportes = New DataTable()
         Return d_tran_ordenestransportes.ORDTSS_TodosAyuda(m_dtTRAN_OrdenesTransportes, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String _
                          , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Dim d_tran_ordenestransportes As New DTRAN_OrdenesTransportes()
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin("Transportes", "TRAN_Cotizaciones", "Coti", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("COTIZ_Codigo", "COTIZ_Codigo")} _
                            , New ACCampos() {New ACCampos("COTIZ_Codigo", "COTIZ_Codigo")}))
         _join.Add(New ACJoin("dbo", "Entidades", "Ent", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
         _join.Add(New ACJoin("Transportes", "TRAN_Rutas", "Ruta", ACJoin.TipoJoin.Left _
                            , New ACCampos() {New ACCampos("RUTAS_Id", "RUTAS_Id")} _
                            , New ACCampos() {New ACCampos("RUTAS_Nombre", "RUTAS_Nombre") _
                                            , New ACCampos("RUTAS_Codigo", "RUTAS_Codigo")}))
         Dim _where As New Hashtable()
         If x_campo.Contains("ENTID") Then
            _where.Add(x_campo, New ACWhere(x_cadena, "Ent", ACWhere.TipoWhere._Like))
         Else
            _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         End If
         _where.Add("ORDTR_Fecha", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
         _where.Add("ORDTR_Estado", New ACWhere(ETRAN_OrdenesTransportes.getEstado(ETRAN_OrdenesTransportes.Estado.Activo), ACWhere.TipoWhere.Igual))
         m_listTRAN_OrdenesTransportes = New List(Of ETRAN_OrdenesTransportes)()
         Return d_tran_ordenestransportes.TRAN_ORDTRSS_Todos(m_listTRAN_OrdenesTransportes, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function CambiarEstado(ByVal x_usuario As String) As Boolean
      Try
         Dim d_tran_ordenestransportes As New DTRAN_OrdenesTransportes()
         d_tran_ordenestransportes.ORDTSU_UnRegCambiarEstado(m_tran_ordenestransportes, x_usuario)

         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   'Public Function Guardar(ByVal x_usuario As String, ByVal x_setfecha() As String) As Boolean
   '   Try
   '      Dim d_tran_ordenestransportes As New DTRAN_OrdenesTransportes()
   '      If m_tran_ordenestransportes.Nuevo Then
   '         d_tran_ordenestransportes.ORDTRSI_UnReg(m_tran_ordenestransportes, x_usuario, x_setfecha)
   '      ElseIf m_tran_ordenestransportes.Modificado Then
   '         d_tran_ordenestransportes.ORDTRSU_UnReg(m_tran_ordenestransportes, x_usuario)
   '      ElseIf m_tran_ordenestransportes.Eliminado Then
   '         d_tran_ordenestransportes.ORDTRSD_UnReg(m_tran_ordenestransportes)
   '      End If
   '      Return True
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   Public Function Cargar(ByVal x_ordtr_codigo As String, ByVal x_ruta As Boolean) As Boolean
      m_listTRAN_OrdenesTransportes = New List(Of ETRAN_OrdenesTransportes)()
      Dim d_tran_ordenestransportes As New DTRAN_OrdenesTransportes()
      m_tran_ordenestransportes = New ETRAN_OrdenesTransportes()
      Dim _where As New Hashtable()
      Try
         _where.Add("ORDTR_Codigo", New ACWhere(x_ordtr_codigo, ACWhere.TipoWhere.Igual))
         If x_ruta Then
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin("Transportes", "TRAN_Cotizaciones", "Coti", ACJoin.TipoJoin.Left _
                               , New ACCampos() {New ACCampos("COTIZ_Codigo", "COTIZ_Codigo")} _
                               , New ACCampos() {New ACCampos("COTIZ_Codigo", "COTIZ_Codigo")}))
            _join.Add(New ACJoin("dbo", "Entidades", "Ent", ACJoin.TipoJoin.Left _
                               , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                               , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Nombres")}))
            _join.Add(New ACJoin("Transportes", "TRAN_Rutas", "Ruta", ACJoin.TipoJoin.Left _
                               , New ACCampos() {New ACCampos("RUTAS_Id", "RUTAS_Id")} _
                               , New ACCampos() {New ACCampos("RUTAS_Nombre", "RUTAS_Nombre") _
                                               , New ACCampos("RUTAS_Codigo", "RUTAS_Codigo")}))
            Return d_tran_ordenestransportes.TRAN_ORDTRSS_UnReg(m_tran_ordenestransportes, _join, _where)
         Else
            Return Cargar(x_ordtr_codigo)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class


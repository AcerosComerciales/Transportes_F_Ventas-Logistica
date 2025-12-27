Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports DAConexion
Imports ACFramework

Partial Public Class BTRAN_Vehiculos

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
      Dim d_tran_vehiculos As New DTRAN_Vehiculos()
      Try
         m_listTRAN_Vehiculos = New List(Of ETRAN_Vehiculos)()
         Return d_tran_vehiculos.VEHISS_Todos(m_listTRAN_Vehiculos, x_cadena)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_entid_codtransportista As String) As Boolean
      Dim d_tran_vehiculos As New DTRAN_Vehiculos()
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin("dbo", "Tipos", "TMar", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodMarca")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_Marca")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TVehi", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoVehiculo")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_Vehiculo")}))
         _join.Add(New ACJoin("dbo", "Tipos", "TCmb", ACJoin.TipoJoin.Inner _
                                     , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoCombustible")} _
                                     , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoCombustible")}))
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoTransportista")} _
                              , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
         '_join.Add(New ACJoin(ETRAN_Ranflas.Esquema, ETRAN_Ranflas.Tabla, "Ranf", "Relac", ACJoin.TipoJoin.Left _
         '                     , New ACCampos() {New ACCampos("RANFL_Id", "RANFL_Id")} _
         '                     , New ACCampos() {New ACCampos("RANFL_Placa", "RANFL_Placa")}))

         '_join.Add(New ACJoin("dbo", "Sucursales", "Suc", ACJoin.TipoJoin.Inner _
         '                   , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
         '                   , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         Dim _where As New Hashtable()
         _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         _where.Add("VEHIC_Estado", New ACWhere(ETRAN_Vehiculos.getEstado(ETRAN_Vehiculos.Estado.Anulado), ACWhere.TipoWhere.Diferente))
         '_where.Add("VHCON_Estado", New ACWhere("A","", ACWhere.TipoWhere.Igual))
         m_listTRAN_Vehiculos = New List(Of ETRAN_Vehiculos)()
         Return d_tran_vehiculos.TRAN_VEHICSS_Todos(m_listTRAN_Vehiculos, _join, _where, True)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Cargar(ByVal x_vehic_id As Long, ByVal x_opcion As ETRAN_Vehiculos.Inicializacion) As Boolean
      Try
         Dim d_tran_vehiculos As New DTRAN_Vehiculos()
         m_etran_vehiculos = New ETRAN_Vehiculos()
         If (d_tran_vehiculos.TRAN_VEHICSS_UnReg(m_etran_vehiculos, x_vehic_id)) Then
            Select Case x_opcion
               Case ETRAN_Vehiculos.Inicializacion.Ranflas
                  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
               Case ETRAN_Vehiculos.Inicializacion.Mantenimiento

               Case Else

            End Select

            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Cargar(ByVal x_vehic_id As Long, ByVal x_detalle As Boolean) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoTransportista")} _
                              , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
         Dim _where As New Hashtable()
         _where.Add("VEHIC_Id", New ACWhere(x_vehic_id))
         Return Cargar(_join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Cargar(ByVal x_opcion As ETRAN_Vehiculos.Inicializacion) As Boolean
      Dim x_vehic_id As Long
      Try
         x_vehic_id = m_etran_vehiculos.VEHIC_Id
         Select Case x_opcion
            Case ETRAN_Vehiculos.Inicializacion.Ranflas
               ''***************************************************************************************************
               '' Cargar los detalles de la ranfla
              
               ''***************************************************************************************************
            Case ETRAN_Vehiculos.Inicializacion.Mantenimiento
               ''***************************************************************************************************

               ''***************************************************************************************************
            Case ETRAN_Vehiculos.Inicializacion.Combustible
               ''***************************************************************************************************
              
               ''***************************************************************************************************
            Case ETRAN_Vehiculos.Inicializacion.Incidencias
               ''***************************************************************************************************
              
               ''***************************************************************************************************
            Case ETRAN_Vehiculos.Inicializacion.Seguros
               ''***************************************************************************************************
              
               ''***************************************************************************************************
            Case ETRAN_Vehiculos.Inicializacion.Conductores
               ''***************************************************************************************************
              
               ''***************************************************************************************************
            Case Else
               Cargar(ETRAN_Vehiculos.Inicializacion.Ranflas)
         End Select
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Ayuda(ByVal x_cadena As String, ByVal x_opcion As Short) As Boolean
      Dim d_tran_vehiculos As New DTRAN_Vehiculos()
      Try
         m_dtTRAN_Vehiculos = New DataTable()
         Return d_tran_vehiculos.TRAN_VEHICSS_Ayuda(m_dtTRAN_Vehiculos, x_cadena, x_opcion)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Ayuda(ByVal x_where As Hashtable) As Boolean
      Dim d_tran_vehiculos As New DTRAN_Vehiculos()
      Try
         m_dtTRAN_Vehiculos = New DataTable()
         Return d_tran_vehiculos.VEHISS_TodosAyuda(m_dtTRAN_Vehiculos, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Guardar(ByVal x_usuario As String, ByVal x_detalle As Boolean) As Boolean
      Try
         If x_detalle Then
            Dim d_tran_vehiculos As New DTRAN_Vehiculos()
            If m_etran_vehiculos.Nuevo Then
               DAEnterprise.BeginTransaction()
               Dim b_correlativo As New BCorrelativos()
               Try
                  m_etran_vehiculos.VEHIC_EstadoViaje = BConstantes.getEstado(BConstantes.EstadosVehiculoViaje.Disponible)
                  b_correlativo.getCorrelativo(BConstantes.SUCUR_Id, ECorrelativos.NTabla.TRAN_Vehiculos)
                  m_etran_vehiculos.VEHIC_Codigo = b_correlativo.Correlativos.Codigo
                  d_tran_vehiculos.TRAN_VEHICSI_UnReg(m_etran_vehiculos, x_usuario)
                  b_correlativo.Correlativos.ZONAS_Codigo = BConstantes.ZONAS_Codigo
                  b_correlativo.SetCorrelativo(x_usuario)
                  DAEnterprise.CommitTransaction()
               Catch ex As Exception
                  DAEnterprise.RollBackTransaction()
                  Throw ex
               End Try
            ElseIf m_etran_vehiculos.Modificado Then
               d_tran_vehiculos.TRAN_VEHICSU_UnReg(m_etran_vehiculos, x_usuario)
            ElseIf m_etran_vehiculos.Eliminado Then
               d_tran_vehiculos.TRAN_VEHICSD_UnReg(m_etran_vehiculos)
            End If
            Return True
         Else
            Return Guardar(x_usuario)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Ayuda(ByVal x_cadena As String, ByVal x_campo As String) As Boolean
      Dim d_tran_vehiculos As New DTRAN_Vehiculos()
      Dim x_where As New Hashtable
      Try
         x_where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         m_dtTRAN_Vehiculos = New DataTable()
         Return d_tran_vehiculos.VEHISS_TodosAyuda(m_dtTRAN_Vehiculos, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Ayuda(ByVal x_entid_codigo As String, ByVal x_cadena As String, ByVal x_campo As String) As Boolean
      Dim d_tran_vehiculos As New DTRAN_Vehiculos()
      Dim x_where As New Hashtable
      Try
         x_where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         x_where.Add("ENTID_CodigoTransportista", New ACWhere(x_entid_codigo, ACWhere.TipoWhere.Igual))
         m_dtTRAN_Vehiculos = New DataTable()
         Return d_tran_vehiculos.VEHISS_TodosAyuda(m_dtTRAN_Vehiculos, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class


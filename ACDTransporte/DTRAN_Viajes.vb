Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_Viajes

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function VIAJSS_UnRegXML(ByRef x_tran_viajes As ETRAN_Viajes, ByVal x_viaje_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectBy(x_viaje_id), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_tran_viajes)
               'Dim mixml As Object = reader.GetValue(reader.GetOrdinal("VIAJE_PRESUPUESTO"))

               'If Not mixml Is System.DBNull.Value Then
               '   x_tran_viajes.VIAJE_Presupuesto = New XmlDocument
               '   x_tran_viajes.VIAJE_Presupuesto.LoadXml(mixml)
               'End If
               x_tran_viajes.Instanciar(ACEInstancia.Consulta)
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function VIAJSU_ActualizarPendientes(ByVal x_tran_viajes As ETRAN_Viajes) As Boolean
      Try
         Dim _sql As String = ""
         _sql = String.Format("Update Transportes.TRAN_Viajes Set VIAJE_SaldoConductor = {0}, VIAJE_PagoConductor = {1}, VIAJE_Saldo = {2}", x_tran_viajes.VIAJE_SaldoConductor, _
                              x_tran_viajes.VIAJE_PagoConductor, x_tran_viajes.VIAJE_Saldo)
         _sql &= String.Format("Where VIAJE_Id = {0}", x_tran_viajes.VIAJE_Id)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Dim _filas As Integer = DAEnterprise.ExecuteNonQuery
         Return _filas > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getCorrelativoXvehiculo(ByVal x_viaje_id As Long, ByVal x_min As Boolean) As Integer
      Try
         Dim m_datos As New DataSet
         DAEnterprise.AsignarProcedure(getSelectIdxVehiculo(x_viaje_id, x_min), CommandType.Text)
         m_datos = DAEnterprise.ExecuteDataSet()
         Return Convert.ToInt64(m_datos.Tables(0).Rows(0)(0))
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getCorrelativoXConductor(ByVal x_entid_codigo As String, ByVal x_min As Boolean) As Integer
      Try
         Dim m_datos As New DataSet
         DAEnterprise.AsignarProcedure(getSelectIdXConductor(x_entid_codigo, x_min), CommandType.Text)
         m_datos = DAEnterprise.ExecuteDataSet()
         Return Convert.ToInt64(m_datos.Tables(0).Rows(0)(0))
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getLiquidados(ByRef x_listTRAN_Viajes As List(Of ETRAN_Viajes), ByVal x_where As Hashtable) As Boolean
      Try
         Dim m_datos As New DataSet
         DAEnterprise.AsignarProcedure(getSelectLiquidados(x_where), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_tran_salidas As New ETRAN_Viajes()
                  ACEsquemas.ACCargarEsquema(reader, e_tran_salidas)
                  e_tran_salidas.Instanciar(ACEInstancia.Consulta)
                  x_listTRAN_Viajes.Add(e_tran_salidas)
               End While
               Dim _listFletes As New List(Of ETRAN_Fletes)
               Dim _utilitariosdet As New ACEsquemas(New ETRAN_Fletes)
               If reader.NextResult() Then
                  While reader.Read()
                     Dim _tran_fletes As New ETRAN_Fletes
                     _utilitariosdet.ACCargarEsquemas(reader, _tran_fletes)
                     _tran_fletes.Instanciar(ACEInstancia.Consulta)
                     _listFletes.Add(_tran_fletes)
                  End While
               End If
               Dim _filtrador As New ACFiltrador(Of ETRAN_Fletes)
               For Each _viaje As ETRAN_Viajes In x_listTRAN_Viajes
                  _filtrador.ACFiltro = String.Format("VIAJE_Id={0}", _viaje.VIAJE_Id)
                  _viaje.ListTRAN_Fletes = _filtrador.ACFiltrar(_listFletes)
               Next
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

   ' <summary> 
   ' Capa de Datos: TRAN_CAJASS_PendientePorViaje
   ' </summary>
   ' <param name="x_fecfin">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_CAJASS_PendientePorViaje(ByVal m_listtran_viajes As List(Of ETRAN_Viajes), ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_CAJASS_PendientePorViaje")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _tran_viajes As New ETRAN_Viajes()
                  ACEsquemas.ACCargarEsquema(reader, _tran_viajes)
                  _tran_viajes.Instanciar(ACEInstancia.Consulta)
                  m_listtran_viajes.Add(_tran_viajes)
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

   ' <summary> 
   ' Capa de Datos: TRAN_VIAJESS_ObtenerViajes
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <param name="x_cadenas">Parametro 3: </param> 
   ' <param name="x_campo">Parametro 4: </param> 
   ' <param name="x_campofecha">Parametro 5: </param> 
   ' <param name="x_liquidados">Parametro 6: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_VIAJESS_ObtenerViajes(ByVal m_listtran_viajes As List(Of ETRAN_Viajes), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_cadenas As String, ByVal x_campo As Short, ByVal x_campofecha As Boolean, ByVal x_liquidados As Boolean, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_VIAJESS_ObtenerViajes")
         If x_campo = 0 Then
            DAEnterprise.AgregarParametro("@FecIni", "01-01-1790", DbType.DateTime, 8)
         Else
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         End If
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Cadenas", x_cadenas, DbType.String, 100)
         DAEnterprise.AgregarParametro("@Campo", x_campo, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@CampoFecha", x_campofecha, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@Liquidados", x_liquidados, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _tran_viajes As New ETRAN_Viajes()
                        ACEsquemas.ACCargarEsquema(reader, _tran_viajes)
                        _tran_viajes.Instanciar(ACEInstancia.Consulta)
                        m_listtran_viajes.Add(_tran_viajes)
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

   ' <summary> 
   ' Capa de Datos: TRAN_VIAJESS_CuadroComparativoCombustible
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <param name="x_cadenas">Parametro 3: </param> 
   ' <param name="x_campo">Parametro 4: </param> 
   ' <param name="x_campofecha">Parametro 5: </param> 
   ' <param name="x_liquidados">Parametro 6: </param> 
   ' <param name="x_pvent_id">Parametro 7: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_VIAJESS_CuadroComparativoCombustible(ByVal m_listtran_viajes As List(Of ETRAN_CombustibleConsumo), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_cadenas As String, ByVal x_campo As Short, ByVal x_campofecha As Boolean, ByVal x_liquidados As Boolean, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_VIAJESS_CuadroComparativoCombustible")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Cadenas", x_cadenas, DbType.String, 100)
         DAEnterprise.AgregarParametro("@Campo", x_campo, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@CampoFecha", x_campofecha, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@Liquidados", x_liquidados, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _tran_viajes As New ETRAN_CombustibleConsumo()
                  ACEsquemas.ACCargarEsquema(reader, _tran_viajes)
                  _tran_viajes.Instanciar(ACEInstancia.Consulta)
                  m_listtran_viajes.Add(_tran_viajes)
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

   Public Function AnularViaje(ByVal x_viaje_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_VIAJESU_AnularViaje")
         DAEnterprise.AgregarParametro("@VIAJE_Id", x_viaje_id)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GuardarFecSalida(ByVal m_tran_viaje As ETRAN_Viajes)
      Dim _sql As String = ""
      Try
         _sql = String.Format("Update Transportes.TRAN_Viajes Set VIAJE_FecLlegada = Null Where VIAJE_Id = {0}{1}", m_tran_viaje.VIAJE_Id, vbNewLine)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GuardarFecScan(ByVal m_tran_viaje As ETRAN_Viajes)
      Dim _sql As String = ""
      Try
         _sql = String.Format("Update Transportes.TRAN_Viajes Set VIAJE_ScanFecha = Null Where VIAJE_Id = {0}{1}", m_tran_viaje.VIAJE_Id, vbNewLine)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ActivarAnulado(ByVal x_viaje_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_VIAJESU_ActivarAnulado")
         DAEnterprise.AgregarParametro("@VIAJE_Id", x_viaje_id)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Function EliminarViaje(ByVal x_viaje_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_VIAJESD_EliminarViaje")
            DAEnterprise.AgregarParametro("@VIAJE_Id", x_viaje_id)
            Return DAEnterprise.ExecuteNonQuery() > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ELiminarConsumoADBLue(ByVal x_viaje_id As Long, ByVal x_comco_id As Long)
        Try
            DAEnterprise.AsignarProcedure("TRAN_VIAJESS_EliminarConsumo")
            DAEnterprise.AgregarParametro("@VIaje_id", x_viaje_id)
            DAEnterprise.AgregarParametro("@COMCO_ID", x_comco_id)
            Return DAEnterprise.ExecuteNonQuery() > 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Procedimientos Adicionales "
    Private Function getSelectIdxVehiculo(ByVal x_viaje_id As Long, ByVal x_min As Boolean) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         If x_min Then
            sql = String.Format(App.Hash("DTRAN_Viajes.getCorrelativoXvehiculoMin").ToString(), x_viaje_id)
         Else
            sql = String.Format(App.Hash("DTRAN_Viajes.getCorrelativoXvehiculo").ToString(), x_viaje_id)
         End If

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectIdXConductor(ByVal x_entid_codigo As String, ByVal x_min As Boolean) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         If x_min Then
            sql = String.Format(App.Hash("DTRAN_Viajes.getCorrelativoXConductorMin").ToString(), x_entid_codigo)
         Else
            sql = String.Format(App.Hash("DTRAN_Viajes.getCorrelativoXConductor").ToString(), x_entid_codigo)
         End If
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectLiquidados(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim _where As New ACGenerador(Of ETRAN_Viajes)(m_formatofecha)
         sql = String.Format(App.Hash("DTRAN_Viajes.getLiquidados").ToString(), _where.getWhere(x_where, True))
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class


Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACELogistica

Public Class DGenerarReportes

#Region " Variables "
   Private m_formatofecha As String

   Enum Reporte
      Linea = 1
      SubLinea = 2
      Todo = 3
   End Enum
#End Region

#Region " Constructores "
   Public Sub New()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
   End Sub
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function GetArticulos(ByVal x_campo As String, ByVal x_cadena As String, ByRef x_datos As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelect(x_campo, x_cadena), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetStocks(ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_opcion As Reporte, ByRef x_datos As DataTable, ByVal x_periodo As String, ByVal x_zonas_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelect(x_cadena, x_almac_id, x_opcion, x_periodo, x_zonas_codigo), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   ''' <summary> 
   ''' Capa de Datos: LOG_STOCKSS_StockALaFecha
   ''' </summary>
   ''' <param name="x_perio_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_STOCKSS_StockALaFecha(ByRef x_datatable As DataTable, ByVal x_perio_codigo As String, ByVal x_almac_id As Short, ByVal x_zonas_codigo As String, ByVal x_linea As String, ByVal x_sublinea As String, ByVal x_fecha As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_STOCKSS_StockALaFecha")
         DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@Linea", x_linea, DbType.String, 10)
         DAEnterprise.AgregarParametro("@SubLinea", x_sublinea, DbType.String, 10)
         If x_fecha.Year > 2000 Then
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.DateTime, 8)
         End If
         x_datatable = DAEnterprise.ExecuteDataSet().Tables(0)
         Return (x_datatable.Rows.Count > 0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetComprasXLinea(ByVal x_linea_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByRef x_datos As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelect(x_linea_codigo, x_fecini, x_fecfin), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetPendientesXProveedor(ByVal x_entid_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByRef x_datos As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectPendientes(x_entid_codigo, x_fecini, x_fecfin), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetComprasProveedorDetalle(ByVal x_entid_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByRef x_datos As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectDetalle(x_entid_codigo, x_fecini, x_fecfin), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetComprasXArticulo(ByVal x_artic_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByRef x_datos As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectPorArticulo(x_artic_codigo, x_fecini, x_fecfin), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetStocksArticulos(ByVal x_cadena As String, ByVal x_opcion As Reporte, ByRef x_datos As DataTable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectStocks(x_cadena, x_opcion), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
         Return x_datos.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetPendientesXProveedorFecha(ByVal x_entid_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByRef x_datos As DataSet) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ABAS_GENREPSS_ComprasProveedoresFecha")
         DAEnterprise.AgregarParametro("@ENTID_CodigoProveedor", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@AnhoIni", x_fecini.Year, DbType.Int32, 14)
         DAEnterprise.AgregarParametro("@MesIni", x_fecini.Month, DbType.Int32, 14)
         DAEnterprise.AgregarParametro("@AnhoFin", x_fecfin.Year, DbType.Int32, 14)
         DAEnterprise.AgregarParametro("@MesFin", x_fecfin.Month, DbType.Int32, 14)
         'DAEnterprise.AsignarProcedure(getSelectProvFecha(x_entid_codigo, x_fecini, x_fecfin), CommandType.Text)
         x_datos = DAEnterprise.ExecuteDataSet()
         Return x_datos.Tables(0).Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetGuiasXFecha(ByVal m_listelog_guias As List(Of EABAS_Guias), ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasTodas")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)

         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_guias As New EABAS_Guias
                  ACEsquemas.ACCargarEsquema(reader, _vent_guias)
                  _vent_guias.Instanciar(ACEInstancia.Consulta)
                  m_listelog_guias.Add(_vent_guias)
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

#Region " Adicionales "
   Private Function getSelect(ByVal x_campo As String, ByVal x_cadena As String) As String
      Dim sql As String = ""
      Dim _repla As String = ""
      Try
         If Not x_cadena.Equals("") Then
            _repla = String.Format("Where Art.{0} = '{1}'", x_campo, x_cadena)
         End If
         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarReportes.GetArticulos").ToString(), _repla)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelect(ByVal x_linea_codigo As String, ByVal x_almac_id As Short, ByVal x_opcion As Reporte, ByVal x_periodo As String, ByVal x_zonas_codigo As String) As String
      Dim sql As String = ""
      Dim x_where As String = ""
      Try
         Select Case x_opcion
            Case Reporte.Linea
               x_where = String.Format("Where Li.LINEA_Codigo = '{0}'", x_linea_codigo)
               'If (x_almac_id > 0) Then x_where &= String.Format(" And Alm.ALMAC_Id = {0}", x_almac_id)
            Case Reporte.SubLinea
               x_where = String.Format("Where SLi.LINEA_Codigo = '{0}'", x_linea_codigo)
               'If (x_almac_id > 0) Then x_where &= String.Format(" And Alm.ALMAC_Id = {0}", x_almac_id)
            Case Reporte.Todo
               x_where = ""
               'If (x_almac_id > 0) Then x_where &= String.Format("Where Alm.ALMAC_Id = {0}", x_almac_id)
            Case Else
               x_where = ""
         End Select
         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarReportes.GetStocks").ToString(), x_where, x_almac_id, x_periodo, x_zonas_codigo)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelect(ByVal x_linea_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarReportes.GetArticulosXLinea").ToString(), x_linea_codigo, x_fecini.ToString(m_formatofecha), x_fecfin.ToString(m_formatofecha))
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectPorArticulo(ByVal x_artic_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarReportes.GetComprasXArticulo").ToString(), x_artic_codigo, x_fecini.ToString(m_formatofecha), x_fecfin.ToString(m_formatofecha))
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectDetalle(ByVal x_entid_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarReportes.GetComprasProveedorDetalle").ToString(), x_entid_codigo, x_fecini.ToString(m_formatofecha), x_fecfin.ToString(m_formatofecha))
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   'Guias'
   'Private Function getSelectGuias(ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As String
   '   Dim sql As String = ""
   '   Try
   '      App.Inicializar()
   '      sql &= String.Format(App.Hash("DGenerarReportes.GetGuiasXFecha").ToString(), x_fecini.ToString(m_formatofecha), x_fecfin.ToString(m_formatofecha))
   '      Return sql
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function
   ''
   Private Function getSelectPendientes(ByVal x_entid_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarReportes.GetPendientesXProveedor").ToString(), x_entid_codigo, x_fecini.ToString(m_formatofecha), x_fecfin.ToString(m_formatofecha))
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectStocks(ByVal x_cadena As String, ByVal x_opcion As Reporte) As String
      Dim sql As String = ""
      Dim x_where As String = ""
      Try
         Select Case x_opcion
            Case Reporte.Linea
               x_where = String.Format("Where Li.LINEA_Codigo = '{0}'", x_cadena)
            Case Reporte.SubLinea
               x_where = String.Format("Where SLi.LINEA_Codigo = '{0}'", x_cadena)
            Case Reporte.Todo
               x_where = ""
            Case Else
               x_where = ""
         End Select
         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarReportes.GetStocksArticulos").ToString(), x_where)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectProvFecha(ByVal x_entid_codigo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql &= String.Format(App.Hash("DGenerarReportes.GetComprasXProveedorXFecha").ToString(), x_entid_codigo, x_fecini.Year, x_fecini.Month, x_fecfin.Year, x_fecfin.Month)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

#End Region

#Region " Metodos "

#End Region

End Class


Imports ACETransporte
Imports DAConexion
Imports System.Data.Common
Imports ACFramework
Imports ACEVentas

Public Class DReporte
#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   ' <summary> 
   ' Capa de Datos: TRAN_REPORSS_CuadreCaja
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_REPORSS_CuadreCaja(ByRef m_listcuadrecaja As List(Of ECuadreCaja), ByRef m_saldocaja As ESaldoCaja, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_REPORSS_CuadreCaja")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _cuadrecaja As New ECuadreCaja()
                  ACEsquemas.ACCargarEsquema(reader, _cuadrecaja)
                  _cuadrecaja.Instanciar(ACEInstancia.Consulta)
                  m_listcuadrecaja.Add(_cuadrecaja)
               End While
               If reader.NextResult() Then
                  While reader.Read()
                     m_saldocaja = New ESaldoCaja()
                     ACEsquemas.ACCargarEsquema(reader, m_saldocaja)
                     m_saldocaja.Instanciar(ACEInstancia.Consulta)
                  End While
               End If
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
    ' facturaelectronica NC_a
    ' </summary>
    ' <param name="m_vent_docs"></param>
    ' <param name="x_docve_codigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function REPOSS_NotasCre(ByRef m_vent_docs As EVENT_DocsVenta, ByVal x_docve_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOS_NCElectronica")
            DAEnterprise.AgregarParametro("@docve_codigo", x_docve_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        m_vent_docs = New EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, m_vent_docs)
                        m_vent_docs.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_vent_docs.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                        While reader.Read()
                            Dim _vent_pedidosdetalle As New EVENT_DocsVentaDetalle()
                            ACEsquemas.ACCargarEsquema(reader, _vent_pedidosdetalle)
                            _vent_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                            m_vent_docs.ListVENT_DocsVentaDetalle.Add(_vent_pedidosdetalle)
                        End While
                    End If
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
   ' Capa de Datos: REPOSS_CuentasCorrientes
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <param name="x_entid_codigo">Parametro 3: </param> 
   ' <param name="x_pvent_id">Parametro 4: </param> 
   ' <param name="x_fecha">Parametro 5: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function REPOSS_CuentasCorrientes(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigo As String, ByVal x_pvent_id As Long, ByVal x_fecha As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("REPOSS_CuentasCorrientes")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventa As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                  _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventa.Add(_vent_docsventa)
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
    ' facturaelectronica ventas_a
    ' </summary>
    ' <param name="m_vent_docs"></param>
    ' <param name="x_docve_codigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function REPOSS_DocsVenta(ByRef m_vent_docs As EVENT_DocsVenta, ByVal x_docve_codigo As String) As Boolean
      Try
            DAEnterprise.AsignarProcedure("REPOS_NCElectronica")
         DAEnterprise.AgregarParametro("@docve_codigo", x_docve_codigo, DbType.String, 15)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               If reader.Read() Then
                  m_vent_docs = New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, m_vent_docs)
                  m_vent_docs.Instanciar(ACEInstancia.Consulta)
               End If
               If reader.NextResult() Then
                        m_vent_docs.ListVENT_DocsVentaDetalle = New List(Of EVENT_DocsVentaDetalle)
                  While reader.Read()
                     Dim _vent_pedidosdetalle As New EVENT_DocsVentaDetalle()
                     ACEsquemas.ACCargarEsquema(reader, _vent_pedidosdetalle)
                     _vent_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                     m_vent_docs.ListVENT_DocsVentaDetalle.Add(_vent_pedidosdetalle)
                  End While
               End If
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
    Public Function REPOSS_Guias(ByRef m_gtran_guia As ETRAN_GuiasTransportista, ByVal x_guiar_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOS_GuiaElectronica")
            DAEnterprise.AgregarParametro("@gtran_codigo", x_guiar_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        m_gtran_guia = New ETRAN_GuiasTransportista()
                        ACEsquemas.ACCargarEsquema(reader, m_gtran_guia)
                        m_gtran_guia.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_gtran_guia.ListETRAN_GuiasTransportistaDetalles = New List(Of ETRAN_GuiasTransportistaDetalles)
                        While reader.Read()
                            Dim _gtran_guiasdetalle As New ETRAN_GuiasTransportistaDetalles()
                            ACEsquemas.ACCargarEsquema(reader, _gtran_guiasdetalle)
                            _gtran_guiasdetalle.Instanciar(ACEInstancia.Consulta)
                            m_gtran_guia.ListETRAN_GuiasTransportistaDetalles.Add(_gtran_guiasdetalle)
                        End While
                    End If
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
    Public Function REPOSS_GuiasTransportista(ByRef m_gtran_guia As ETRAN_GuiasTransportista, ByVal x_guiar_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOS_GuiaElectronicaTransportista")
            DAEnterprise.AgregarParametro("@gtran_codigo", x_guiar_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        m_gtran_guia = New ETRAN_GuiasTransportista()
                        ACEsquemas.ACCargarEsquema(reader, m_gtran_guia)
                        m_gtran_guia.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_gtran_guia.ListETRAN_GuiasTransportistaDetalles = New List(Of ETRAN_GuiasTransportistaDetalles)
                        While reader.Read()
                            Dim _gtran_guiasdetalle As New ETRAN_GuiasTransportistaDetalles()
                            ACEsquemas.ACCargarEsquema(reader, _gtran_guiasdetalle)
                            _gtran_guiasdetalle.Instanciar(ACEInstancia.Consulta)
                            m_gtran_guia.ListETRAN_GuiasTransportistaDetalles.Add(_gtran_guiasdetalle)
                        End While
                    End If
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
   ' Capa de Datos: VENT_CAJASS_CobranzaPendiente
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <param name="x_pvent_id">Parametro 3: </param> 
   ' <param name="x_fecha">Parametro 5: </param> 
   ' <param name="x_entid_codigovendedor">Parametro 6: </param> 
   ' <param name="x_entid_codigocliente">Parametro 7: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function VENT_CAJASS_CobranzaPendiente(ByVal m_listccuadrependientes As List(Of ECCuadrePendientes), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_fecha As Boolean, ByVal x_entid_codigovendedor As String, ByVal x_entid_codigocliente As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_CAJASS_CobranzaPendiente")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@ENTID_CodigoVendedor", x_entid_codigovendedor, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entid_codigocliente, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _ccuadrependientes As New ECCuadrePendientes()
                  ACEsquemas.ACCargarEsquema(reader, _ccuadrependientes)
                  _ccuadrependientes.Instanciar(ACEInstancia.Consulta)
                  m_listccuadrependientes.Add(_ccuadrependientes)
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

#Region "Para el Cuadre de Caja"
   


   ' <summary> 
   ' Capa de Datos: TRAN_REPORSS_CuadreCaja_Facturas
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_REPORSS_CuadreCaja_Facturas(ByVal m_listcuadrecaja As List(Of ECuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_REPORSS_CuadreCaja_Facturas")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 0
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _cuadrecaja As New ECuadreCaja()
                  ACEsquemas.ACCargarEsquema(reader, _cuadrecaja)
                  _cuadrecaja.Instanciar(ACEInstancia.Consulta)
                  m_listcuadrecaja.Add(_cuadrecaja)
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
   ' Capa de Datos: TRAN_REPORSS_CuadreCaja_IngEgre
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_REPORSS_CuadreCaja_IngEgre(ByVal m_listcuadrecaja As List(Of ECuadreCaja), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_REPORSS_CuadreCaja_IngEgre")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 0
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _cuadrecaja As New ECuadreCaja()
                  ACEsquemas.ACCargarEsquema(reader, _cuadrecaja)
                  _cuadrecaja.Instanciar(ACEInstancia.Consulta)
                  m_listcuadrecaja.Add(_cuadrecaja)
               End While
               If reader.NextResult() Then
                  While reader.Read()
                     Dim _cuadrecaja As New ECuadreCaja()
                     ACEsquemas.ACCargarEsquema(reader, _cuadrecaja)
                     _cuadrecaja.Instanciar(ACEInstancia.Consulta)
                     m_listcuadrecaja.Add(_cuadrecaja)
                  End While
               End If
               Return True
            Else
               If reader.NextResult() Then
                  While reader.Read()
                     Dim _cuadrecaja As New ECuadreCaja()
                     ACEsquemas.ACCargarEsquema(reader, _cuadrecaja)
                     _cuadrecaja.Instanciar(ACEInstancia.Consulta)
                     m_listcuadrecaja.Add(_cuadrecaja)
                  End While
               Else
                  Return False
               End If
               Return True
            End If
         End Using
         Return True
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Datos: TRAN_REPORSS_CuadreCaja_Pendientes
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_REPORSS_CuadreCaja_Pendientes(ByRef m_saldocaja As ESaldoCaja, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_REPORSS_SaldoInicial")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         'DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.CommandTimeOut = 0
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               'While reader.Read()
               '   Dim _cuadrecaja As New ECuadreCaja()
               '   ACEsquemas.ACCargarEsquema(reader, _cuadrecaja)
               '   _cuadrecaja.Instanciar(ACEInstancia.Consulta)
               '   m_listcuadrecaja.Add(_cuadrecaja)
               'End While
               'If reader.NextResult() Then
               While reader.Read()
                  m_saldocaja = New ESaldoCaja()
                  ACEsquemas.ACCargarEsquema(reader, m_saldocaja)
                  m_saldocaja.Instanciar(ACEInstancia.Consulta)
               End While
               'End If
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

#End Region

   ' <summary> 
   ' Capa de Datos: TRAN_CAJASS_CuadrePendientes
   ' </summary>
   ' <param name="x_fecfin">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_CAJASS_CuadrePendientes(ByVal m_listtran_fletes As List(Of ETRAN_Fletes), ByVal x_fecfin As Date, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_CAJASS_CuadrePendientes")
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _tran_fletes As New ETRAN_Fletes()
                  ACEsquemas.ACCargarEsquema(reader, _tran_fletes)
                  _tran_fletes.Instanciar(ACEInstancia.Consulta)
                  m_listtran_fletes.Add(_tran_fletes)
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
   ' Capa de Datos: TRAN_REPOSS_ViajesFletes
   ' </summary>
   ' <param name="x_fecini">Parametro 1: </param> 
   ' <param name="x_fecfin">Parametro 2: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_REPOSS_ViajesFletes(ByVal m_listtran_fletes As List(Of ETRAN_Fletes), ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("TRAN_REPOSS_ViajesFletes")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _tran_fletes As New ETRAN_Fletes()
                  ACEsquemas.ACCargarEsquema(reader, _tran_fletes)
                  _tran_fletes.Instanciar(ACEInstancia.Consulta)
                  m_listtran_fletes.Add(_tran_fletes)
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
#End Region

#Region " Metodos de Controles"

#End Region
End Class

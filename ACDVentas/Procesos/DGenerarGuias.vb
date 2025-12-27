Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DGenerarGuias

#Region " Variables "
   Private m_formatofecha As String
#End Region

#Region " Constructores "
   Public Sub New()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
   End Sub
#End Region

#Region " Procedimientos Almacenados "
	
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime, ByVal x_todos As Boolean) As Boolean
      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GrabarGuia(ByVal x_usuario As String) As Boolean
      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function AnularGuia(ByVal x_codigo As String, ByVal x_usuario As String) As Boolean
      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetDocVenta
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDetDocVenta(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
      Try
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetDocVenta_orden")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                  _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetDocVenta
   ''' </summary>
   ''' <param name="x_pedid_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDetPedidos(ByVal m_listvent_pedidosdetalle As List(Of EVENT_PedidosDetalle), ByVal x_pedid_codigo As String, ByVal x_almac_id As Short) As Boolean
      Try
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetPedidoVenta")
         DAEnterprise.AgregarParametro("@PEDID_Codigo", x_pedid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidosdetalle As New EVENT_PedidosDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidosdetalle)
                  _vent_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidosdetalle.Add(_vent_pedidosdetalle)
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
    ''' <summary> 
    ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetDocVenta
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetDocVentaalmacen(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetDocVenta")
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    ''' <summary> 
    ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetDocVenta
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetDocVenta_obs(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String, ByVal x_almac_id As Short,
                                                       ByVal x_estentrega As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetDocVenta_obs")
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@EstadoEntrega", x_estentrega, DbType.String, 1)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    
    ''' <summary> 
   ''' Capa de Datos: LOG_DIST_ORDENES_ObtDetGuias
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_ORDENES_ObtDetGuias(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetDocOrden")
         DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                  _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
        Public Function getNumeroLote() As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectlote(), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("Lote"), Integer)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Public Function getNumerolotetransExterna() As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectloteTransExterna(), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("Lote"), Integer)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function



    Public Function getPesoFleje(ByVal x_lote As String) As Decimal
        Try
            DAEnterprise.AsignarProcedure(getSelectpesoFleje(x_lote), CommandType.Text)
            Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
            If m_datos.Rows.Count > 0 Then
                Return CType(m_datos.Rows(0)("peso_bobina"), Decimal)
            Else
                'DAEnterprise.AsignarProcedure(getSelectpesoFleje(x_lote), CommandType.Text)
                'Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)

                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   Public Function getNumero(ByVal x_serie As String, ByVal x_tipos_tipodocumento As String) As Integer
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_serie, x_tipos_tipodocumento), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("Numero"), Integer)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    Public Function DIST_Sunat(ByRef listEDIST_GuiasRemision As List(Of EDIST_GuiasRemision), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

      Public Function getNumeropeso(ByVal x_artic As String) As Double
      Try
         DAEnterprise.AsignarProcedure(getSelectpeso(x_artic), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("ARTIC_Peso"),Double)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

         Public Function getNumerolinea(ByVal x_artic As String) As String
      Try
         DAEnterprise.AsignarProcedure(getSelectlinea(x_artic), CommandType.Text)
         Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         If m_datos.Rows.Count > 0 Then
            Return CType(m_datos.Rows(0)("LINEA_Codigo"),String)
         Else
            Return 0
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getCliente(ByRef listEVENT_DocsVenta As List(Of EVENT_DocsVenta), ByVal x_where As Hashtable, ByVal x_almac_id As Short) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_where, x_almac_id), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EVENT_DocsVenta())
               While reader.Read()
                  Dim e_event_docsventa As New EVENT_DocsVenta()
                  _utilitarios.ACCargarEsquemas(reader, e_event_docsventa)
                  e_event_docsventa.Instanciar(ACEInstancia.Consulta)
                  listEVENT_DocsVenta.Add(e_event_docsventa)
               End While
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDocVenta
   ''' </summary>
   ''' <param name="x_tconsulta">Parametro 1: </param> 
   ''' <param name="x_cadena">Parametro 2: </param> 
   ''' <param name="x_almac_id">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_fecini">Parametro 5: </param> 
   ''' <param name="x_fecfin">Parametro 6: </param> 
   ''' <param name="x_desbloqueo">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDocVenta(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_desbloqueo As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDocVenta")
         DAEnterprise.AgregarParametro("@TConsulta", x_tconsulta, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
            DAEnterprise.CommandTimeOut = 5000
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
    
   ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDocVenta
   ''' </summary>
   ''' <param name="x_tconsulta">Parametro 1: </param> 
   ''' <param name="x_cadena">Parametro 2: </param> 
   ''' <param name="x_almac_id">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_fecini">Parametro 5: </param> 
   ''' <param name="x_fecfin">Parametro 6: </param> 
   ''' <param name="x_desbloqueo">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtCotizaciones(ByVal m_listvent_costventa As List(Of EVENT_Pedidos), ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_desbloqueo As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasSinDocumento")
         DAEnterprise.AgregarParametro("@TConsulta", x_tconsulta, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
            ' DAEnterprise.CommandTimeOut = 0
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_cotsventa As New EVENT_Pedidos()
                        ACEsquemas.ACCargarEsquema(reader, _vent_cotsventa)
                        _vent_cotsventa.Instanciar(ACEInstancia.Consulta)
                        m_listvent_costventa.Add(_vent_cotsventa)
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

   ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtOrdenes
   ''' </summary>
   ''' <param name="x_tconsulta">Parametro 1: </param> 
   ''' <param name="x_cadena">Parametro 2: </param> 
   ''' <param name="x_almac_id">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_fecini">Parametro 5: </param> 
   ''' <param name="x_fecfin">Parametro 6: </param> 
   ''' <param name="x_desbloqueo">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtOrdenes(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_desbloqueo As Boolean) As Boolean
      Try
         ''DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtOrdenes")
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtOrdenes_pruebas")
         DAEnterprise.AgregarParametro("@TConsulta", x_tconsulta, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
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

   ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDocVentaXNumero
   ''' </summary>
   ''' <param name="x_numero">Parametro 1: </param> 
   ''' <param name="x_serie">Parametro 2: </param> 
   ''' <param name="x_tipos_codtipodocumento">Parametro 3: </param> 
   ''' <param name="x_almac_id">Parametro 4: </param> 
   ''' <param name="x_pvent_id">Parametro 5: </param> 
   ''' <param name="x_desbloqueo">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDocVentaXNumero(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_numero As String, ByVal x_serie As String, _
                                                      ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean, _
                                                      ByVal x_pergenguia As Boolean) As Boolean
      Try
         If x_pergenguia Then
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDocVentaXNumeroPerGenGuia")
         Else
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDocVentaXNumero")
         End If
         DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoDocumento", x_tipos_codtipodocumento, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
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

   ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtOrdenesXNumero
   ''' </summary>
   ''' <param name="x_numero">Parametro 1: </param> 
   ''' <param name="x_serie">Parametro 2: </param> 
   ''' <param name="x_tipos_codtipodocumento">Parametro 3: </param> 
   ''' <param name="x_almac_id">Parametro 4: </param> 
   ''' <param name="x_pvent_id">Parametro 5: </param> 
   ''' <param name="x_desbloqueo">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtOrdenesXNumero(ByVal m_listdist_ordenes As List(Of EVENT_DocsVenta), ByVal x_numero As String, ByVal x_serie As String, _
                                                     ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean, _
                                                     ByVal x_pergenguia As Boolean) As Boolean
      Try
         If x_pergenguia Then
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtOrdenesXNumeroPerGenGuia")
         Else
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtOrdenesXNumero")
         End If

         DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoDocumento", x_tipos_codtipodocumento, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
                  _dist_ordenes.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_ordenes)
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
    Public Function GUIAR_Impresiones(ByRef listEDIST_GuiasRemision As List(Of EDIST_GuiasRemision), ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetOrdenes
   ''' </summary>
   ''' <param name="x_orden_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDetOrdenes(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_orden_codigo As String, ByVal x_almac_id As Short) As Boolean
      Try
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetOrdenes_orden")
         DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                  _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                  m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    ''' <summary> 
    ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetOrdenes_obs
    ''' </summary>
    ''' <param name="x_orden_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetOrdenes_obs(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_orden_codigo As String, ByVal x_almac_id As Short) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetOrdenes_obs")
            DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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
    ''' <summary> 
    ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetOrdenes
    ''' </summary>
    ''' <param name="x_orden_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DIST_GUIASS_ObtDetOrdenesalmacen(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_orden_codigo As String, ByVal x_almac_id As Short) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetOrdenes")
            DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _vent_docsventadetalle)
                        _vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventadetalle.Add(_vent_docsventadetalle)
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

   ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_GuiasXDocumento
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_GuiasXDocumento(ByRef m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_docve_codigo As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_GuiasXDocumento")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_guiasremision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, _dist_guiasremision)
                  _dist_guiasremision.Instanciar(ACEInstancia.Consulta)
                  m_listdist_guiasremision.Add(_dist_guiasremision)
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

      ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_GuiasXDocumento
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_GuiasXDocumentoG(ByRef m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_docve_codigo As String, ByVal x_almac_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_GuiasXDocumentoLogistica")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_ID", x_almac_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_guiasremision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, _dist_guiasremision)
                  _dist_guiasremision.Instanciar(ACEInstancia.Consulta)
                  m_listdist_guiasremision.Add(_dist_guiasremision)
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

   ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_GuiasXDocumentoOrden
   ''' </summary>
   ''' <param name="x_orden_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_GuiasXDocumentoOrden(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_orden_codigo As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_GuiasXDocumentoOrden")
         DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_guiasremision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, _dist_guiasremision)
                  _dist_guiasremision.Instanciar(ACEInstancia.Consulta)
                  m_listdist_guiasremision.Add(_dist_guiasremision)
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
    ' Capa de Datos: LOG_DISTSS_GuiasXDocumentoOrden
    ' </summary>
    ' <param name="x_orden_codigo">Parametro 1: </param> 
    ' <param name="x_pvent_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DISTSS_GuiasXOrden(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_orden_codigo As String, ByVal x_almac As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTSS_GuiasXOrden")
            DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_IDOrigen", x_almac, DbType.Int64, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _dist_guiasremision As New EDIST_GuiasRemision()
                        ACEsquemas.ACCargarEsquema(reader, _dist_guiasremision)
                        _dist_guiasremision.Instanciar(ACEInstancia.Consulta)
                        m_listdist_guiasremision.Add(_dist_guiasremision)
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



#Region "Procedimientos Adicionales "
    Private Function getSelectAll(ByVal x_serie As String, ByVal x_tipos_tipodocumento As String) As String
      Dim sql As String = ""
      Try
         sql &= String.Format(" Select IsNull(Max(GUIAR_Numero), 0) As Numero from [Logistica].[DIST_GuiasRemision] ", vbNewLine)
         sql &= String.Format(" Where GUIAR_Serie = '{0}' And TIPOS_CodTipoDocumento = '{1}'{2}", x_serie, x_tipos_tipodocumento, vbNewLine)

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    Private Function getSelectAll(ByVal x_where As Hashtable) As String
        Dim sql As String = ""
        Try
            sql = " SELECT  * " & vbNewLine
            sql &= " FROM Logistica.DIST_GuiasRemision" & vbNewLine
            sql &= " WHERE " & vbNewLine
            Dim _where As New ACGenerador(Of EDIST_GuiasRemision)(m_formatofecha)
            sql &= _where.getWhere(x_where, True)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getSelectpesoFleje(ByVal x_lote As String) As String
        Dim sql As String = ""
        Try
            sql &= String.Format(" select ingcd_cantidad as peso_bobina from Logistica.ABAS_IngresosCompraDetalle d ", vbNewLine)
            sql &= String.Format(" inner join Logistica.ABAS_IngresosCompra i on i.INGCO_Id=d.INGCO_id ", vbNewLine)
            sql &= String.Format(" inner join Articulos a on a.ARTIC_Codigo=d.ARTIC_Codigo ", vbNewLine)
            sql &= String.Format(" where d.INGCD_LoteGeneral='{0}' and a.LINEA_Codigo='0408' ", x_lote, vbNewLine)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Private Function getSelectlote() As String
      Dim sql As String = ""
      Try
         sql &= String.Format("select isnull(max(INGCD_LoteGeneral)+1,1) AS Lote from Logistica.ABAS_IngresosCompraDetalle ", vbNewLine)
         
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Private Function getSelectloteTransExterna() As String
      Dim sql As String = ""
      Try
         sql &= String.Format("select isnull(max(GUIRD_Lote)+1,1) AS Lote from Logistica.DIST_GuiasRemisionDetalle ", vbNewLine)
         
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

      Private Function getSelectpeso(x_artic) As String
      Dim sql As String = ""
      Try
         sql &= String.Format("select ARTIC_Peso from Articulos where ARTIC_Codigo='{0}' ",x_artic, vbNewLine)
         
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

           Private Function getSelectlinea(x_artic) As String
      Dim sql As String = ""
      Try
         sql &= String.Format("select LINEA_Codigo from Articulos where ARTIC_Codigo='{0}' ",x_artic, vbNewLine)
         
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   Private Function getSelectOrdenGuiaPendiente(ByVal x_docve_codigo As String, ByVal x_almac_id As Short, ByVal x_orden As String) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql = String.Format(App.Hash("DGenerarGuias.CargarOrdenGuiaPendiente").ToString(), x_docve_codigo, x_almac_id)
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Function getSelectAll(ByVal x_where As Hashtable, ByVal x_almac_id As Short) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql = String.Format("{0} Where ", App.Hash("DGenerarGuias.getCliente"))
         Dim _where As New ACGenerador(Of EVENT_DocsVenta)(m_formatofecha)
         sql &= _where.getWhere(x_where, True)
         sql &= String.Format(App.Hash("DGenerarGuias.getCliente.Where").ToString(), x_almac_id)
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


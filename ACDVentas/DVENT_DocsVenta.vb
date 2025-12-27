Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DVENT_DocsVenta


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "

   ''' <summary> 
   ''' Capa de Datos: VENT_DOCVESS_UnDocumento
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCVESS_UnDocumento(ByRef x_vent_docsventa As EVENT_DocsVenta, ByVal x_docve_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_DOCVESS_UnDocumento")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  ACEsquemas.ACCargarEsquema(reader, x_vent_docsventa)
                  x_vent_docsventa.Instanciar(ACEInstancia.Consulta)
               End While
               If reader.NextResult() Then
                  While reader.Read()
                     Dim e_vent_docsventadetalle As New EVENT_DocsVentaDetalle()
                     ACEsquemas.ACCargarEsquema(reader, e_vent_docsventadetalle)
                     e_vent_docsventadetalle.Instanciar(ACEInstancia.Consulta)
                     x_vent_docsventa.ListVENT_DocsVentaDetalle.Add(e_vent_docsventadetalle)
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
   

   ''' <summary> 
   ''' Capa de Datos: VEN_DOCVSS_ObtenerUltimaFecha
   ''' </summary>
   ''' <param name="x_tipos_codtipodocumento">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VEN_DOCVSS_ObtenerUltimaFecha(ByVal x_vent_docsventa As EVENT_DocsVenta, ByVal x_tipos_codtipodocumento As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VEN_DOCVSS_ObtenerUltimaFecha")
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoDocumento", x_tipos_codtipodocumento, DbType.String, 6)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_vent_docsventa)
               x_vent_docsventa.Instanciar(ACEInstancia.Consulta)
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
   ''' Capa de Datos: VENT_DOCVESS_DocumentosXNotaDebito
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_DOCVESS_DocumentosRelacionados(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_docve_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_DOCVESS_DocumentosRelacionados")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)
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
    ''' Capa de Datos: VENT_DOCSVESS_RELACIONADOSPAGOS 
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCSVESS_RELACIONADOSPAGOS(ByVal m_listTesoDocsPago As List(Of ETESO_DocsPagos), ByVal x_docve_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_DOCSVESS_RELACIONADOSPAGOS")
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _teso_docspago As New ETESO_DocsPagos()
                        ACEsquemas.ACCargarEsquema(reader, _teso_docspago)
                        _teso_docspago.Instanciar(ACEInstancia.Consulta)
                        m_listTesoDocsPago.Add(_teso_docspago)
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
    ''' Capa de Datos: VENT_DOCVESS_DocumentosXNotaDebito
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_DOCVESS_DocumentosRelacionadoss(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_docve_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_DOCVESS_DocumentosRelacionadoss")
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)
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
    ''' Capa de Datos: CAJASS_PendientesPago
    ''' </summary>
    ''' <param name="x_pvent_id">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function CAJASS_ObtenerPendientesPago(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_pvent_id As Long, ByVal x_entidad As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("CAJASS_ObtenerPendientesPago")
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entidad, DbType.String, 15)

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vpendientespagos As New EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, _vpendientespagos)
                        _vpendientespagos.Instanciar(ACEInstancia.Consulta)
                        m_listvent_docsventa.Add(_vpendientespagos)
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
   ''' Capa de Datos: VENT_VENTSS_RomperRelacionDocsVentas
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_VENTSS_RomperRelacionDocsVentas(ByVal x_docve_codigo As String, ByVal x_pvent_id As Long, ByVal x_xpago As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_VENTSS_RomperRelacionDocsVentas")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@XPago", x_xpago, DbType.Boolean, 1)
         Return DAEnterprise.ExecuteNonQuery() > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: VENT_VENTSS_BusDocsVenta
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_VENTSS_BusDocsVenta(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_VENTSS_BusDocsVenta")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: VENT_VENTSS_BusDocsVentaXlinea
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_VENTSS_BusDocsVentaXlinea(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos As String, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                                  ByVal X_linea As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_VENTSS_BusDocsVentaXlinea")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_Codtipo", x_tipos, DbType.String, 8)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@linea", X_linea, DbType.String, 5)
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
    ' Capa de Datos:     VENT_VENTSS_BusDocsVentaXnumYlinea
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    ' <param name="x_pvent_id">Parametro 4: </param> 
    ' <param name="x_sucur_id">Parametro 5: </param> 
    ' <param name="x_opcion">Parametro 6: </param> 
    ' <param name="x_cadena">Parametro 7: </param> 
    ' <param name="x_todos">Parametro 8: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function VENT_VENTSS_BusDocsVentaXnumYlinea(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_pventid As Short, ByVal x_numero As Long, ByVal x_serie As String, ByVal x_tipos As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                                          ByVal x_linea As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_VENTSS_BusDocsVentaXnumeroYlinea")
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pventid, DbType.Int32, 8)
            DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.Int32, 8)
            DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 5)
            DAEnterprise.AgregarParametro("@TIPOS_Codtipo", x_tipos, DbType.String, 8)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 50)
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





#Region " Consultas "
   ''' <summary> 
   ''' Capa de Datos: VENTSS_VentasxVendedor
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_entid_codigovendedor">Parametro 3: </param> 
   ''' <param name="x_entid_codigocliente">Parametro 4: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENTSS_VentasxVendedor(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigovendedor As String, ByVal x_entid_codigocliente As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENTSS_VentasxVendedor")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ENTID_CodigoVendedor", x_entid_codigovendedor, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entid_codigocliente, DbType.String, 14)
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
    ''' Capa de Datos: VENTSS_VentasxVendedor
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigovendedor">Parametro 3: </param> 
    ''' <param name="x_entid_codigocliente">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENTSS_VentasConsultaDetallado(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENTSS_VentasConsultaDetallado")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
    ''' Capa de Datos: VENTSS_VentasPorVendedor
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_entid_codigovendedor">Parametro 3: </param> 
    ''' <param name="x_entid_codigocliente">Parametro 4: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENTSS_VentasPorVendedor(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigovendedor As String, ByVal x_entid_codigocliente As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENTSS_VentasPorVendedor")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ENTID_CodigoVendedor", x_entid_codigovendedor, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entid_codigocliente, DbType.String, 14)
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
    ' Capa de Datos: VENTSS_VentasxVendedor
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_entid_codigovendedor">Parametro 3: </param> 
    ' <param name="x_entid_codigocliente">Parametro 4: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function VENTSS_VentasxCotizador(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_entid_codigocotizador As String, ByVal x_entid_codigocliente As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENTSS_VentasxCotizador")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ENTID_CodigoCotizador", x_entid_codigocotizador, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ENTID_CodigoCliente", x_entid_codigocliente, DbType.String, 14)
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
#End Region


       ''' <summary>
    ''' alex
    ''' </summary>
    ''' <param name="m_data"></param>
    ''' <param name="x_zonas_codigo"></param>
    ''' <param name="x_articulo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Obtener_Deta_Anulada(ByRef m_data As DataTable, ByVal x_docve_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("[Doc_Vent_ObtenerMotAnulacion]")
            'DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 6)
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 50)
           m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "

   ''' <summary> 
   ''' Capa de Datos: VENT_REPOSS_Ventas
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_REPOSS_Ventas(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Integer) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_REPOSS_Ventas")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int32, 4)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_docsventa As New EVENT_DocsVenta()
                  ACEsquemas.ACCargarEsquema(reader, _vent_docsventa)
                  _vent_docsventa.Instanciar(ACEInstancia.Consulta)
                  If _vent_docsventa.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
                     _vent_docsventa.ENTID_Cliente = "ANULADA"
                     _vent_docsventa.ENTID_NroDocumento = "-"
                     _vent_docsventa.IGVSoles = 0
                     _vent_docsventa.ImporteSoles = 0
                     _vent_docsventa.TotalSoles = 0
                     _vent_docsventa.DOCVE_TotalPagar = 0
                     _vent_docsventa.DOCVE_TotalVenta = 0
                     _vent_docsventa.TIPOC_VentaSunat = 0
                     _vent_docsventa.DOCVE_ImportePercepcionSoles = 0
                     _vent_docsventa.DOCVE_AfectoPercepcionSoles = 0
                     _vent_docsventa.DOCVE_AfectoPercepcion = 0
                     _vent_docsventa.TotalVenta = 0
                  End If
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


   Public Function VENT_ReporteVentas(ByRef listEVENT_DocsVenta As List(Of EVENT_DocsVenta), ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime)
      Try
         DAEnterprise.AsignarProcedure(selectReporte(x_fecini, x_fecfin), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EVENT_DocsVenta())
               While reader.Read()
                  Dim e_vent_docsventa As New EVENT_DocsVenta()
                  _utilitarios.ACCargarEsquemas(reader, e_vent_docsventa)
                  e_vent_docsventa.Instanciar(ACEInstancia.Consulta)
                  If e_vent_docsventa.DOCVE_Estado = EVENT_DocsVenta.getEstado(EVENT_DocsVenta.Estado.Anulado) Then
                     e_vent_docsventa.ENTID_Cliente = "ANULADA"
                     e_vent_docsventa.ENTID_NroDocumento = "-"
                     e_vent_docsventa.IGVSoles = 0
                     e_vent_docsventa.ImporteSoles = 0
                     e_vent_docsventa.TotalSoles = 0
                     e_vent_docsventa.DOCVE_TotalPagar = 0
                     e_vent_docsventa.TIPOC_VentaSunat = 0
                  End If
                  listEVENT_DocsVenta.Add(e_vent_docsventa)
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

   Public Function getFecha() As DateTime
      Try
         Return getDateTime()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function SetPermisoGenGuia(ByVal x_docve_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Ventas.VENT_DocsVenta Set DOCVE_PerGenGuia = {0}, DOCVE_UsrMod = '{2}', DOCVE_FecMod = GETDATE() Where DOCVE_Codigo = '{1}'"
         _sql = String.Format(_sql, IIf(x_value, 1, 0), x_docve_codigo, x_usuario)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Dim i As Integer = DAEnterprise.ExecuteNonQuery()
         DAEnterprise.CommitTransaction()
         Return (i > 0)
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
    End Function
    Public Function SetPermisoAnularDocumentos(ByVal x_docve_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Ventas.VENT_DocsVenta Set DOCVE_PaseAnulacion = {0}, DOCVE_UsrPaseAnulacion = '{2}', DOCVE_FechaPaseAnulacion = GETDATE() Where DOCVE_Codigo = '{1}'"
            _sql = String.Format(_sql, IIf(x_value, 1, 0), x_docve_codigo, x_usuario)
            DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
            Dim i As Integer = DAEnterprise.ExecuteNonQuery()
            DAEnterprise.CommitTransaction()
            Return (i > 0)
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Asignar permiso para poder imprimir documento
    ''' </summary>
    ''' <param name="x_docve_codigo"></param>
    ''' <param name="x_value"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoImpDocu(ByVal x_docve_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Ventas.VENT_DocsVenta Set DOCVE_Impresa = {0}, DOCVE_UsrMod = '{2}', DOCVE_FecMod = GETDATE() Where DOCVE_Codigo = '{1}'"
            _sql = String.Format(_sql, IIf(x_value, 1, 0), x_docve_codigo, x_usuario)
            DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
            Dim i As Integer = DAEnterprise.ExecuteNonQuery()
            DAEnterprise.CommitTransaction()
            Return (i > 0)
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function


#Region "Procedimientos Adicionales "
   Private Function selectReporte(ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As String
        Dim sql As String
        Try
         App.Inicializar()
         sql = App.Hash("DVENT_DocsVenta.VENT_ReporteVentas")
         Dim _where As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha)
         sql = String.Format(sql, x_fecini.ToString(m_formatofecha), x_fecfin.ToString(m_formatofecha))

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region


End Class


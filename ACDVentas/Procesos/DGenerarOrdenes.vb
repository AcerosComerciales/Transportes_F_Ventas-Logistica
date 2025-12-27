Imports ACEVentas
Imports DAConexion
Imports ACFramework
Imports System.Data.Common

Public Class DGenerarOrdenes
#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "
   ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDocVentaXNumero
   ''' </summary>
   ''' <param name="x_numero">Parametro 1: </param> 
   ''' <param name="x_serie">Parametro 2: </param> 
   ''' <param name="x_tipos_codtipodocumento">Parametro 3: </param> 
   ''' <param name="x_almac_id">Parametro 4: </param> 
   ''' <param name="x_pvent_id">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDocVentaXNumero(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codtipodocumento As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDocVentaXNumero")
         DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoDocumento", x_tipos_codtipodocumento, DbType.String, 6)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
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
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDocVenta(ByVal m_listvent_docsventa As List(Of EVENT_DocsVenta), ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDocVenta")
         DAEnterprise.AgregarParametro("@TConsulta", x_tconsulta, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
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
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetDocVenta_articulos
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDetDocVenta_Artic(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String, ByVal x_almac_id As Short,
                                                        ByVal x_articulo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DIST_GUIASS_ObtDetDocVenta_articulos")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@ARTIC_Codigo",x_articulo, DbType.String, 11)
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
   ''' Capa de Datos: LOG_DISTSS_OrdenesXDocumento
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_OrdenesXDocumento(ByVal m_listdist_ordenes As List(Of EDIST_Ordenes), ByVal x_docve_codigo As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_OrdenesXDocumento")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EDIST_Ordenes()
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

    
     ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_OrdenesXDocumento
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_pvent_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_OrdenesXDocumentoL(ByVal m_listdist_ordenes As List(Of EDIST_Ordenes), ByVal x_docve_codigo As String, ByVal x_Almac_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_OrdenesXDocumentoL")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_Almac_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EDIST_Ordenes()
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

    Public Function LOG_DISTSS_OrdenesDetalle(ByVal m_listdist_ordenesDetalle As List(Of EDIST_OrdenesDetalle), ByVal x_ordencodigo As String, ByVal x_Almac_id As Long) As Boolean
      Try
       DAEnterprise.AsignarProcedure("LOG_DISTSS_OrdenesDetalle")
         DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_ordencodigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_Almac_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EDIST_OrdenesDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
                  _dist_ordenes.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenesDetalle.Add(_dist_ordenes)
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
    ''' Capa de Datos: DIST_Alm_ObtDetDocVenta
    ''' </summary>
    ''' <param name="x_docve_codigo">Parametro 1: </param> 
    ''' <param name="x_almac_id">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function DIST_Alm_ObtDetOrden(ByVal m_listdist_ordenesDetalle As List(Of EDIST_OrdenesDetalle), ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
        Try
            DAEnterprise.AsignarProcedure("DIST_Alm_ObtDetOrden")
            DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_docve_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _dist_ordenesdetalle As New EDIST_OrdenesDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _dist_ordenesdetalle)
                        _dist_ordenesdetalle.Instanciar(ACEInstancia.Consulta)
                        m_listdist_ordenesDetalle.Add(_dist_ordenesdetalle)
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

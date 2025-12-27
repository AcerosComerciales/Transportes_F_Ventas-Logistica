Imports ACEVentas
Imports DAConexion
Imports ACFramework
Imports System.Data.Common

Public Class DGenerarOrdenesProduccion

    #Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "


       ''' <summary> 
   ''' Capa de Datos: LOG_DIST_GUIASS_ObtDetDocVenta
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_GUIASS_ObtDetDocVenta(ByVal m_listvent_docsventadetalle As List(Of EVENT_DocsVentaDetalle), ByVal x_docve_codigo As String, ByVal x_almac_id As Short) As Boolean
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
   Public Function LOG_DISTSS_OrdenesXDocumento(ByVal m_listdist_ordenes As List(Of EABAS_OrdenesProduccion), ByVal x_docve_codigo As String, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_OrdenesProduccionXDocumento")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EABAS_OrdenesProduccion()
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
   Public Function LOG_DISTSS_OrdenesXDocumentoL(ByVal m_listdist_ordenes As List(Of EABAS_OrdenesProduccion), ByVal x_docve_codigo As String, ByVal x_Almac_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_OrdenesproduccionXDocumentoL")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_Almac_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EABAS_OrdenesProduccion()
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



#End Region

#Region " Metodos de Controles"

#End Region

End Class

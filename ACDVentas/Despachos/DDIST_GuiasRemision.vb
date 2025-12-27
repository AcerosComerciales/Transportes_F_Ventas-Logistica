Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DDIST_GuiasRemision

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
	
   ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_ObtenerGuiaVenta
   ''' </summary>
   ''' <param name="x_guiar_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_ObtenerGuiaVenta(ByVal x_dist_guiasremision As EDIST_GuiasRemision, ByVal x_guiar_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerGuiaVenta")
         DAEnterprise.AgregarParametro("@GUIAR_Codigo", x_guiar_codigo, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_dist_guiasremision)
               x_dist_guiasremision.Instanciar(ACEInstancia.Consulta)
               x_dist_guiasremision.ListDIST_GuiasRemisionDetalle = New List(Of EDIST_GuiasRemisionDetalle)

               If reader.NextResult() Then
                  While reader.Read()
                     Dim e_guiadetalle As New EDIST_GuiasRemisionDetalle()
                     ACEsquemas.ACCargarEsquema(reader, e_guiadetalle)
                     e_guiadetalle.Instanciar(ACEInstancia.Consulta)
                     x_dist_guiasremision.ListDIST_GuiasRemisionDetalle.Add(e_guiadetalle)
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
   ''' Capa de Datos: LOG_DISTSS_ObtenerGuiaVenta
   ''' </summary>
   ''' <param name="x_guiar_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   ''' 
     Public Function LOG_DISTSS_ObtenerGuiaTransformacion(ByVal x_dist_guiasremision As EDIST_GuiasRemision, ByVal x_guiar_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerGuiaTransformacion")
         DAEnterprise.AgregarParametro("@GUIAR_Codigo", x_guiar_codigo, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_dist_guiasremision)
               x_dist_guiasremision.Instanciar(ACEInstancia.Consulta)
               x_dist_guiasremision.ListDIST_GuiasRemisionDetalle = New List(Of EDIST_GuiasRemisionDetalle)

               If reader.NextResult() Then
                  While reader.Read()
                     Dim e_guiadetalle As New EDIST_GuiasRemisionDetalle()
                     ACEsquemas.ACCargarEsquema(reader, e_guiadetalle)
                     e_guiadetalle.Instanciar(ACEInstancia.Consulta)
                     x_dist_guiasremision.ListDIST_GuiasRemisionDetalle.Add(e_guiadetalle)
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
   ''' Capa de Datos: LOG_DISTSS_ObtenerGuiaVenta
   ''' </summary>
   ''' <param name="x_guiar_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_ObtenerGuiaTransf(ByVal x_dist_guiasremision As EDIST_GuiasRemision, ByVal x_guiar_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerGuiaTransf")
         DAEnterprise.AgregarParametro("@GUIAR_Codigo", x_guiar_codigo, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_dist_guiasremision)
               x_dist_guiasremision.Instanciar(ACEInstancia.Consulta)
               x_dist_guiasremision.ListDIST_GuiasRemisionDetalle = New List(Of EDIST_GuiasRemisionDetalle)

               If reader.NextResult() Then
                  While reader.Read()
                     Dim e_guiadetalle As New EDIST_GuiasRemisionDetalle()
                     ACEsquemas.ACCargarEsquema(reader, e_guiadetalle)
                     e_guiadetalle.Instanciar(ACEInstancia.Consulta)
                     x_dist_guiasremision.ListDIST_GuiasRemisionDetalle.Add(e_guiadetalle)
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
    ''' Capa de Datos: LOG_DISTSS_ObtenerGuiaVenta
    ''' </summary>
    ''' <param name="x_guiar_codigo">Parametro 1: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_DISTSS_ObtenerGuiaCompra(ByVal x_dist_guiasremision As EDIST_GuiasRemision, ByVal x_guiar_codigo As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerGuiaCompra")
            DAEnterprise.AgregarParametro("@GUIAR_Codigo", x_guiar_codigo, DbType.String, 14)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    reader.Read()
                    ACEsquemas.ACCargarEsquema(reader, x_dist_guiasremision)
                    x_dist_guiasremision.Instanciar(ACEInstancia.Consulta)
                    x_dist_guiasremision.ListDIST_GuiasRemisionDetalle = New List(Of EDIST_GuiasRemisionDetalle)

                    If reader.NextResult() Then
                        While reader.Read()
                            Dim e_guiadetalle As New EDIST_GuiasRemisionDetalle()
                            ACEsquemas.ACCargarEsquema(reader, e_guiadetalle)
                            e_guiadetalle.Instanciar(ACEInstancia.Consulta)
                            x_dist_guiasremision.ListDIST_GuiasRemisionDetalle.Add(e_guiadetalle)
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
    ''' alex
    ''' </summary>
    ''' <param name="m_data"></param>
    ''' <param name="x_zonas_codigo"></param>
    ''' <param name="x_articulo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Obtener_Deta_Anulada(ByRef m_data As DataTable, ByVal x_docve_codigo As String,ByVal documento As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("Log_Dist_ObtenerMotAnulacion")
            'DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 6)
            DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Documento", x_docve_codigo, DbType.String, 50)
            DAEnterprise.AgregarParametro("@GUIA",1,DbType.Boolean)
            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_BuscarGuiasRemision
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_BuscarGuiasRemision(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarGuiasRemision")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_DISTSS_BuscarGuiasRemision
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_BuscarGuiasRemisionCompra(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarGuiasRemisionCompra")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_DISTSS_BuscarFacturasVentaXNumero
   ''' </summary>
   ''' <param name="x_numero">Parametro 1: </param> 
   ''' <param name="x_serie">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_BuscarGuiasRemisionXNumero(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_numero As String, ByVal x_serie As String, ByVal x_pvent_id As Long, ByVal x_tipos_codmotivotraslado As String, ByVal x_tipos_codtipodocumento As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarGuiasRemisionXNumero")
         DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoDocumento", x_tipos_codtipodocumento, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_DISTSS_GetSaldoArticulo
   ''' </summary>
   ''' <param name="x_docve_codigo">Parametro 1: </param> 
   ''' <param name="x_artic_codigo">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_GetSaldoArticulo(ByVal x_docve_codigo As String, ByVal x_artic_codigo As String, ByRef x_saldo As Decimal, ByVal x_orden As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_GetSaldoArticulo")
         DAEnterprise.AgregarParametro("@DOCVE_Codigo", x_docve_codigo, DbType.String, 15)
         DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Orden", x_orden, DbType.Boolean, 1)
         Dim _table As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
         x_saldo = _table.Rows(0)("Saldo")
         Return _table.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuias
   ''' </summary>
   ''' <param name="x_almac_iddestino">Parametro 1: </param> 
   ''' <param name="x_fecini">Parametro 2: </param> 
   ''' <param name="x_fecfin">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcionfecha">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuias(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuias")
         DAEnterprise.AgregarParametro("@ALMAC_IdDestino", x_almac_iddestino, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@OpcionFecha", x_opcionfecha, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasSalida
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_fecini">Parametro 2: </param> 
   ''' <param name="x_fecfin">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcionfecha">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuiasSalida(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_idorigen As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasSalida")
         DAEnterprise.AgregarParametro("@ALMAC_IdOrigen", x_almac_idorigen, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@OpcionFecha", x_opcionfecha, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)

            'DAEnterprise.CommandTimeOut = 19000
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
    ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasSalida
    ''' </summary>
    ''' <param name="x_almac_idorigen">Parametro 1: </param> 
    ''' <param name="x_fecini">Parametro 2: </param> 
    ''' <param name="x_fecfin">Parametro 3: </param> 
    ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
    ''' <param name="x_opcionfecha">Parametro 5: </param> 
    ''' <param name="x_opcion">Parametro 6: </param> 
    ''' <param name="x_cadena">Parametro 7: </param> 
    ''' <param name="x_todos">Parametro 8: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function LOG_GUIASS_ObtenerGuiasCompra(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasCompra")
            DAEnterprise.AgregarParametro("@ALMAC_IdDestino", x_almac_iddestino, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
            DAEnterprise.AgregarParametro("@OpcionFecha", x_opcionfecha, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)

            'DAEnterprise.CommandTimeOut = 19000
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
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasSalidaRemoto
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_almac_iddestino">Parametro 2: </param> 
   ''' <param name="x_fecini">Parametro 3: </param> 
   ''' <param name="x_fecfin">Parametro 4: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 5: </param> 
   ''' <param name="x_opcionfecha">Parametro 6: </param> 
   ''' <param name="x_opcion">Parametro 7: </param> 
   ''' <param name="x_cadena">Parametro 8: </param> 
   ''' <param name="x_todos">Parametro 9: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuiasSalidaRemoto(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_idorigen As Short, ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasSalidaRemoto")
         DAEnterprise.AgregarParametro("@ALMAC_IdOrigen", x_almac_idorigen, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@ALMAC_IdDestino", x_almac_iddestino, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@OpcionFecha", x_opcionfecha, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasIngresos
   ''' </summary>
   ''' <param name="x_almac_iddestino">Parametro 1: </param> 
   ''' <param name="x_fecini">Parametro 2: </param> 
   ''' <param name="x_fecfin">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcionfecha">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuiasIngresos(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_iddestino As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            ''data grid para consulta general
            DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasIngresos")
            DAEnterprise.AgregarParametro("@ALMAC_IdDestino", x_almac_iddestino, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
            DAEnterprise.AgregarParametro("@OpcionFecha", x_opcionfecha, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasIngresosXNumero
   ''' </summary>
   ''' <param name="x_almac_iddestino">Parametro 1: </param> 
   ''' <param name="x_numero">Parametro 2: </param> 
   ''' <param name="x_serie">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuiasIngresosXNumero(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_iddestino As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasIngresosXNumero")
         DAEnterprise.AgregarParametro("@ALMAC_IdDestino", x_almac_iddestino, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasSalidaXNumero
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_numero">Parametro 2: </param> 
   ''' <param name="x_serie">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuiasSalidaXNumero(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_idorigen As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasSalidaXNumero")
         DAEnterprise.AgregarParametro("@ALMAC_IdOrigen", x_almac_idorigen, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
    ' Capa de Datos: LOG_GUIASS_ObtenerGuiasSalidaXNumero
    ' </summary>
    ' <param name="x_almac_idorigen">Parametro 1: </param> 
    ' <param name="x_numero">Parametro 2: </param> 
    ' <param name="x_serie">Parametro 3: </param> 
    ' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
    ' <param name="x_todos">Parametro 5: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_GUIASS_ObtenerGuiasCompraXNumero(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_iddestino As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasCompraXNumero")
            DAEnterprise.AgregarParametro("@ALMAC_IdDestino", x_almac_iddestino, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
            DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
            DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasSalidaXNumeroRemoto
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_almac_iddestino">Parametro 2: </param> 
   ''' <param name="x_numero">Parametro 3: </param> 
   ''' <param name="x_serie">Parametro 4: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 5: </param> 
   ''' <param name="x_todos">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuiasSalidaXNumeroRemoto(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_idorigen As Short, ByVal x_almac_iddestino As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasSalidaXNumeroRemoto")
         DAEnterprise.AgregarParametro("@ALMAC_IdOrigen", x_almac_idorigen, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@ALMAC_IdDestino", x_almac_iddestino, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasReposicion
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_fecini">Parametro 2: </param> 
   ''' <param name="x_fecfin">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_opcionfecha">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuiasReposicion(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_idorigen As Short, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tipos_codmotivotraslado As String, ByVal x_opcionfecha As Short, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasReposicion")
         DAEnterprise.AgregarParametro("@ALMAC_IdOrigen", x_almac_idorigen, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@OpcionFecha", x_opcionfecha, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_GUIASS_ObtenerGuiasReposicionXNumero
   ''' </summary>
   ''' <param name="x_almac_idorigen">Parametro 1: </param> 
   ''' <param name="x_numero">Parametro 2: </param> 
   ''' <param name="x_serie">Parametro 3: </param> 
   ''' <param name="x_tipos_codmotivotraslado">Parametro 4: </param> 
   ''' <param name="x_todos">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_GUIASS_ObtenerGuiasReposicionXNumero(ByVal m_listdist_guiasremision As List(Of EDIST_GuiasRemision), ByVal x_almac_idorigen As Short, ByVal x_numero As String, ByVal x_serie As String, ByVal x_tipos_codmotivotraslado As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_GUIASS_ObtenerGuiasReposicionXNumero")
         DAEnterprise.AgregarParametro("@ALMAC_IdOrigen", x_almac_idorigen, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.String, 7)
         DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.String, 4)
         DAEnterprise.AgregarParametro("@TIPOS_CodMotivoTraslado", x_tipos_codmotivotraslado, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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

#Region " Control de Despachos "
   ''' <summary> 
   ''' Procedimiento "GUIA_SalidasPendientes" por el Generador 17/11/2011
   ''' </summary> 
   ''' <param name="m_listGuia_Remision">Lista donde se cargaran los valores</param> 
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_trans_id">Parametro 3: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_SalidasPendientes(ByRef m_listGuia_Remision As List(Of EDIST_GuiasRemision), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_trans_id As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("GUIA_SalidasPendientes")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TRANS_Id", x_trans_id, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_guia_remision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, e_guia_remision)
                  e_guia_remision.Instanciar(ACEInstancia.Consulta)
                  m_listGuia_Remision.Add(e_guia_remision)
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
   ''' Procedimiento "GUIA_GuiasPorConductor" por el Generador 17/11/2011
   ''' </summary> 
   ''' <param name="m_listGuia_Remision">Lista donde se cargaran los valores</param> 
   ''' <param name="x_condu_id">Parametro 1: </param> 
   ''' <param name="x_trans_id">Parametro 3: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_GuiasPorConductor(ByRef m_listGuia_Remision As List(Of EDIST_GuiasRemision), ByVal x_condu_id As String, ByVal x_vehic_id As Long, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_trans_id As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("GUIA_GuiasPorConductorFecha")
         DAEnterprise.AgregarParametro("@CONDU_Id", x_condu_id, DbType.String, 14)
         DAEnterprise.AgregarParametro("@VEHIC_Id", x_vehic_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TRANS_Id", x_trans_id, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_guia_remision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, e_guia_remision)
                  e_guia_remision.Instanciar(ACEInstancia.Consulta)
                  m_listGuia_Remision.Add(e_guia_remision)
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

   Public Function GUIA_GuiasPorConductor(ByRef m_listGuia_Remision As List(Of EDIST_GuiasRemision), ByVal x_condu_id As String, ByVal x_vehic_id As Long, ByVal x_fecini As Date, ByVal x_trans_id As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("GUIA_GuiasPorConductor")
         DAEnterprise.AgregarParametro("@CONDU_Id", x_condu_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@VEHIC_Id", x_vehic_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Fecha", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TRANS_Id", x_trans_id, DbType.String, 2)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_guia_remision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, e_guia_remision)
                  e_guia_remision.Instanciar(ACEInstancia.Consulta)
                  m_listGuia_Remision.Add(e_guia_remision)
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
   ''' Procedimiento "GUIA_GuiasDeSalidas" por el Generador 18/11/2011
   ''' </summary> 
   ''' <param name="m_listGuia_Remision">Lista donde se cargaran los valores</param> 
   ''' <param name="x_vehic_id">Parametro 1: </param> 
   ''' <param name="x_fecha">Parametro 2: </param> 
   ''' <param name="x_trans_id">Parametro 3: </param> 
   ''' <returns>Si no hay registros devuelve Falso</returns> 
   ''' <remarks></remarks> 
   Public Function GUIA_GuiasDeSalidas(ByRef m_listGuia_Remision As List(Of EDIST_GuiasRemision), ByVal x_vehic_id As Long, ByVal x_fecha As Date, ByVal x_trans_id As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("GUIA_GuiasDeSalidas")
         DAEnterprise.AgregarParametro("@VEHIC_Id", x_vehic_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TRANS_Id", x_trans_id, DbType.String, 14)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim e_guia_remision As New EDIST_GuiasRemision()
                  ACEsquemas.ACCargarEsquema(reader, e_guia_remision)
                  e_guia_remision.Instanciar(ACEInstancia.Consulta)
                  m_listGuia_Remision.Add(e_guia_remision)
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
   ''' Actualizar un registro 
   ''' </summary>
   ''' <param name="x_guia_remision">codigo de la guia de remision</param>
   ''' <param name="x_opcion">valor del booleano</param>
   ''' <param name="x_usuario">codigo del usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GUIAR_UnRegActGuiaRemision(ByRef x_guia_remision As EDIST_GuiasRemision, ByVal x_opcion As Boolean, ByVal x_usuario As String) As Integer
      Try
         Dim _fecha As DateTime = getDateTime()

         DAEnterprise.AsignarProcedure("GUIAR_UnRegActGuiaRemision")
         DAEnterprise.AgregarParametro("@ID_Guia_Remision", x_guia_remision.GUIAR_Codigo, DbType.String, 12)
         If x_opcion Then
            x_guia_remision.GUIAR_HoraLlegada = New DateTime(_fecha.Year, _fecha.Month, _fecha.Day, x_guia_remision.GUIAR_HoraLlegada.Hour, x_guia_remision.GUIAR_HoraLlegada.Minute, x_guia_remision.GUIAR_HoraLlegada.Second)
            DAEnterprise.AgregarParametro("@Hora", x_guia_remision.GUIAR_HoraLlegada, DbType.DateTime, 8)
         Else
            x_guia_remision.GUIAR_HoraSalida = New DateTime(_fecha.Year, _fecha.Month, _fecha.Day, x_guia_remision.GUIAR_HoraSalida.Hour, x_guia_remision.GUIAR_HoraSalida.Minute, x_guia_remision.GUIAR_HoraSalida.Second)
            DAEnterprise.AgregarParametro("@Hora", x_guia_remision.GUIAR_HoraSalida, DbType.DateTime, 8)
         End If
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@Usuario", x_usuario, DbType.String, 20)
         Return DAEnterprise.ExecuteNonQuery()
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region "Procedimientos Adicionales "
    ''' <summary>
    ''' Asignar permiso para poder imprimir orden
    ''' </summary>
    ''' <param name="x_guia_codigo"></param>
    ''' <param name="x_value"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoImpGuia(ByVal x_guia_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Logistica.DIST_GuiasRemision Set GUIAR_Impresa = {0}, GUIAR_UsrMod = '{2}', GUIAR_FecMod = GETDATE() Where GUIAR_Codigo = '{1}'"
            _sql = String.Format(_sql, IIf(x_value, 1, 0), x_guia_codigo, x_usuario)
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
    ''' Asignar permiso para poder imprimir orden
    ''' </summary>
    ''' <param name="x_guia_codigo"></param>
    ''' <param name="x_value"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoAnularGuia(ByVal x_guia_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Logistica.DIST_GuiasRemision Set GUIAR_PaseAnulacion= {0}, GUIAR_UsrPaseAnulacion = '{2}', GUIAR_FechaPaseAnulacion = GETDATE() Where GUIAR_Codigo = '{1}'"
            _sql = String.Format(_sql, IIf(x_value, 1, 0), x_guia_codigo, x_usuario)
            DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
            Dim i As Integer = DAEnterprise.ExecuteNonQuery()
            DAEnterprise.CommitTransaction()
            Return (i > 0)
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
#End Region
#End Region

#Region " Metodos "
	
#End Region

End Class


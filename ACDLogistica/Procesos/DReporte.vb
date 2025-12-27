Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient

Imports DAConexion
Imports ACELogistica
'Imports 
Imports ACEVentas
Imports ACFramework

Public Class DReporte
#Region " Variables "

#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

    ' <summary> 
    ' Capa de Datos: CTRL_STOCKSS_KardexXArticulo
    ' </summary>
    ' <param name="x_artic_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <param name="x_perio_codigo">Parametro 3: </param> 
    ' <param name="x_zonas_codigo">Parametro 4: </param> 
    ' <param name="x_fecini">Parametro 5: </param> 
    ' <param name="x_fecfin">Parametro 6: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function CTRL_STOCKSS_KardexXArticulo(ByRef x_data As DataTable, ByVal x_artic_codigo As String, ByVal x_almac_id As Integer, ByVal x_perio_codigo As String, ByVal x_zonas_codigo As String, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            DAEnterprise.AsignarProcedure("CTRL_STOCKSS_KardexXArticulo")
            DAEnterprise.AgregarParametro("@ARTIC_Codigo", x_artic_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int32, 4)
            DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio_codigo, DbType.String, 4)
            DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            x_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return (x_data.Rows.Count > 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''procedimiento para obtener guias _A
    Public Function Control_Repor_GuiasTodas(ByRef x_data As List(Of ACELogistica.EDIST_GuiasRemision), ByVal x_perio As String, ByVal x_almac_id As Integer,
                                                ByVal x_CLIENTE_ID As String, ByVal X_CLI As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean, ByVal x_pvent_id As Integer) As Boolean
        Try

            DAEnterprise.AsignarProcedure("LOG_DIST_Guias_Todas_a")
            DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int32, 4)
            DAEnterprise.AgregarParametro("@CLI", X_CLI, DbType.Boolean)
            DAEnterprise.AgregarParametro("@Cliente", x_CLIENTE_ID, DbType.String, 11)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@todos", x_todos, DbType.Boolean)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int32, 4)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _dist_guiasremision As New ACELogistica.EDIST_GuiasRemision()
                        ACEsquemas.ACCargarEsquema(reader, _dist_guiasremision)
                        _dist_guiasremision.Instanciar(ACEInstancia.Consulta)
                        x_data.Add(_dist_guiasremision)
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


    ''procedimiento para obtener ordenes _A
    Public Function Control_Repor_OrdenesTodas(ByRef x_data As List(Of ACEVentas.EDIST_Ordenes), ByVal x_perio As String, ByVal x_fecini As Date, ByVal x_fecfin As Date,
                                               ByVal x_almac As Integer, ByVal x_tipos_codtipoorden As String, ByVal cadena As String, ByVal x_todos As Boolean,
                                               ByVal x_pvent_id As Integer) As Boolean
        Try

            DAEnterprise.AsignarProcedure("LOG_DISTSS_OrdenesIngreso")
            DAEnterprise.AgregarParametro("@Periodo", x_perio, DbType.String, 14)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@Almac_id", x_almac, DbType.Int32, 4)
            DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 11)
            DAEnterprise.AgregarParametro("@Cadena", cadena, DbType.String, 11)
            DAEnterprise.AgregarParametro("@todos", x_todos, DbType.Boolean)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int32, 4)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _dist_ordenes As New ACEVentas.EDIST_Ordenes()
                        ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
                        _dist_ordenes.Instanciar(ACEInstancia.Consulta)
                        x_data.Add(_dist_ordenes)
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

    ' <summary> _A
    ' 
    ' </summary>
    ' <param name="x_zonas_codigo">Parametro 1: </param> 
    ' <param name="x_linea">Parametro 2: </param> 
    ' <param name="x_cadena">Parametro 3: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function Control_PendientesCondi(ByRef m_data As DataTable, ByVal x_almacen As String, ByVal x_fechaIni As Date, ByVal x_fechaFin As Date, ByVal x_tipo As String) As Boolean
        Try
            If (x_tipo = "guias") Then

                DAEnterprise.AsignarProcedure("LOG_DIST_PendientesGenerales")
                DAEnterprise.AgregarParametro("@ALMAC_Id", x_almacen, DbType.Int32)
                DAEnterprise.AgregarParametro("@FecIni", x_fechaIni, DbType.DateTime, 8)
                DAEnterprise.AgregarParametro("@FecFin", x_fechaFin, DbType.DateTime, 10)
                DAEnterprise.CommandTimeOut = 2000
                m_data = DAEnterprise.ExecuteDataSet().Tables(0)
                Return m_data.Rows.Count > 0

            ElseIf (x_tipo = "ordenes") Then

                DAEnterprise.AsignarProcedure("LOG_DIST_PendientesGeneralesOrdenes")
                DAEnterprise.AgregarParametro("@ALMAC_Id", x_almacen, DbType.Int32)
                DAEnterprise.AgregarParametro("@FecIni", x_fechaIni, DbType.DateTime, 8)
                DAEnterprise.AgregarParametro("@FecFin", x_fechaFin, DbType.DateTime, 10)
                DAEnterprise.CommandTimeOut = 2000
                m_data = DAEnterprise.ExecuteDataSet().Tables(0)
                Return m_data.Rows.Count > 0

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function




    ' <summary> _A
    ' Capa de Datos: ARTICSS_CargarPrecios
    ' </summary>
    ' <param name="x_zonas_codigo">Parametro 1: </param> 
    ' <param name="x_linea">Parametro 2: </param> 
    ' <param name="x_cadena">Parametro 3: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function control_verificacionKardex(ByRef m_data As DataTable, ByVal x_almacen As String, ByVal x_documento As String, ByVal x_tipoorden As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_OrdenesKardex")
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almacen, DbType.Int32)
            DAEnterprise.AgregarParametro("@Documento", x_documento, DbType.String, 15)
            DAEnterprise.AgregarParametro("@TipoOrden", x_tipoorden, DbType.String, 6)
            DAEnterprise.CommandTimeOut = 2000
            m_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return m_data.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''procedimiento para obtener VENTAS _A
    Public Function Control_Repor_VentasTodas(ByRef x_data As List(Of ACEVentas.EVENT_DocsVenta), ByVal X_PVENT_ID As Integer,
                                                ByVal x_CLIENTE_ID As String, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean,
                                                ByVal x_doc As String) As Boolean
        Try

            DAEnterprise.AsignarProcedure("VENT_VENTSS_BusDocsVentaTodosB")
            'DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio, DbType.String, 14)
            DAEnterprise.AgregarParametro("@PVENT_Id", X_PVENT_ID, DbType.Int32, 4)
            'DAEnterprise.AgregarParametro("@CLI", X_CLI, DbType.Boolean)
            DAEnterprise.AgregarParametro("@Cliente", x_CLIENTE_ID, DbType.String, 11)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@DOC", x_doc, DbType.String, 10)
            DAEnterprise.AgregarParametro("@todos", x_todos, DbType.Boolean)

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                'Using reader As DbDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_DOCVEVentas As New ACEVentas.EVENT_DocsVenta()
                        ACEsquemas.ACCargarEsquema(reader, _vent_DOCVEVentas)
                        _vent_DOCVEVentas.Instanciar(ACEInstancia.Consulta)
                        x_data.Add(_vent_DOCVEVentas)
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

    Public Function Control_Repor_ProductXGuias(ByRef x_data As DataTable, ByVal x_perio As String, ByVal x_almac_id As Integer, ByVal x_artic_codigo As String, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTS_PRODUCXGUIAS_LOCAL")
            DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int32, 4)
            DAEnterprise.AgregarParametro("@Articulo", x_artic_codigo, DbType.String, 7)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@todos", x_todos, DbType.Boolean)
            x_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return (x_data.Rows.Count > 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Actualizacion de verificacion de guias para control_A
    ' </summary>
    ' <param name="x_data"></param>
    ' <param name="x_perio"></param>
    ' <param name="x_almac_id"></param>
    ' <param name="x_artic_codigo"></param>
    ' <param name="x_fecini"></param>
    ' <param name="x_fecfin"></param>
    ' <param name="x_todos"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    ' m_periodo, x_almac_id, x_documento
    Public Function Guias_VerificacionControl(ByVal x_almac_id As Integer, ByVal x_documento As String, ByVal x_user As String, ByVal x_opcion As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_VerificacionGuias")
            DAEnterprise.AgregarParametro("@Almacen", x_almac_id, DbType.String, 5)
            DAEnterprise.AgregarParametro("@Usuario", x_user, DbType.String, 15)
            DAEnterprise.AgregarParametro("@Documento", x_documento, DbType.String, 15)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.String, 1)


            If DAEnterprise.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Actualizacion de verificacion de ordenes para control_A
    ' </summary>
    ' <param name="x_data"></param>
    ' <param name="x_perio"></param>
    ' <param name="x_almac_id"></param>
    ' <param name="x_artic_codigo"></param>
    ' <param name="x_fecini"></param>
    ' <param name="x_fecfin"></param>
    ' <param name="x_todos"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    ' m_periodo, x_almac_id, x_documento
    Public Function Guias_VerificacionControlOrdenes(ByVal x_almac_id As Integer, ByVal x_documento As String, ByVal x_user As String, ByVal x_tipoorden As String,
                                                        ByVal x_opcion As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_VerificacionOrdenes")
            DAEnterprise.AgregarParametro("@Almacen", x_almac_id, DbType.String, 5)
            DAEnterprise.AgregarParametro("@Usuario", x_user, DbType.String, 15)
            DAEnterprise.AgregarParametro("@Documento", x_documento, DbType.String, 15)
            DAEnterprise.AgregarParametro("@tipoorden", x_tipoorden, DbType.String, 15)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.String, 1)

            If DAEnterprise.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary>
    ' Actualizacion de verificacion de Ventas para control_A
    ' </summary>
    ' <param name="x_data"></param>
    ' <param name="x_perio"></param>
    ' <param name="x_almac_id"></param>
    ' <param name="x_artic_codigo"></param>
    ' <param name="x_fecini"></param>
    ' <param name="x_fecfin"></param>
    ' <param name="x_todos"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    ' m_periodo, x_almac_id, x_documento
    Public Function Ventas_VerificacionControl(ByVal x_almac_id As Integer, ByVal x_documento As String, ByVal x_usuario As String,
                                                  ByVal x_opcion As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DIST_VerificacionVentas")
            DAEnterprise.AgregarParametro("@SUCURSAL", x_almac_id, DbType.String, 5)
            DAEnterprise.AgregarParametro("@Documento", x_documento, DbType.String, 15)
            DAEnterprise.AgregarParametro("@Usuario", x_usuario, DbType.String, 15)
            DAEnterprise.AgregarParametro("Opcion", x_opcion, DbType.String, 1)


            If DAEnterprise.ExecuteNonQuery() Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function









    Public Function Control_Repor_ProductXGuiasV(ByRef x_data As DataTable, ByVal x_perio As String, ByVal x_almac_id As Integer, ByVal x_artic_codigo As String, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_todos As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTS_PRODUCXGUIAS_VISITA")
            DAEnterprise.AgregarParametro("@PERIO_Codigo", x_perio, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int32, 4)
            DAEnterprise.AgregarParametro("@Articulo", x_artic_codigo, DbType.String, 7)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@todos", x_todos, DbType.Boolean)
            x_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return (x_data.Rows.Count > 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CONTROL_ComprasVSingresos(ByRef x_data As DataTable, ByVal x_cadena As String, ByVal _opcion As Integer, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_INGSSVSCOMPRAS")
            DAEnterprise.AgregarParametro("@cadena", x_cadena, DbType.String, 90)
            DAEnterprise.AgregarParametro("@opcion", _opcion, DbType.Int32, 4)
            DAEnterprise.AgregarParametro("@todos", x_todos, DbType.Boolean)
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            x_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return (x_data.Rows.Count > 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CONTROL_ComprasVSingresosdest(ByRef x_data As DataTable, ByVal x_tipodoc As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTSSIngresosCompraVS")
            DAEnterprise.AgregarParametro("@tipodoc", x_tipodoc, DbType.String, 90)

            x_data = DAEnterprise.ExecuteDataSet().Tables(0)
            Return (x_data.Rows.Count > 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    ' <summary> 
    ' Capa de Datos: REPOSS_ObtenerArreglo
    ' </summary>
    ' <param name="x_arreg_codigo">Parametro 1: </param> 
    ' <param name="x_almac_id">Parametro 2: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function REPOSS_ObtenerArreglo(ByVal m_ctrl_arreglos As ECTRL_Arreglos, ByVal x_arreg_codigo As String, ByVal x_almac_id As Integer) As Boolean
        Try
            DAEnterprise.AsignarProcedure("REPOSS_ObtenerArreglo")
            DAEnterprise.AgregarParametro("@ARREG_Codigo", x_arreg_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int32, 4)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        ACEsquemas.ACCargarEsquema(reader, m_ctrl_arreglos)
                        m_ctrl_arreglos.Instanciar(ACEInstancia.Consulta)
                    End If
                    If reader.NextResult() Then
                        m_ctrl_arreglos.ListCTRL_ArreglosDetalle = New List(Of ECTRL_ArreglosDetalle)
                        While reader.Read()
                            Dim _ctrl_arreglosdetalle As New ECTRL_ArreglosDetalle()
                            ACEsquemas.ACCargarEsquema(reader, _ctrl_arreglosdetalle)
                            _ctrl_arreglosdetalle.Instanciar(ACEInstancia.Consulta)
                            m_ctrl_arreglos.ListCTRL_ArreglosDetalle.Add(_ctrl_arreglosdetalle)
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
    ' Capa de Datos: CTRL_MostrarDocumentosCliente
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_pvent_id">Parametro 3: </param> 
    ' <param name="x_entid_codigo">Parametro 4: </param> 
    ' <param name="x_fecha">Parametro 5: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function CTRL_MostrarDocumentosCliente(ByRef x_dtdata As DataTable, ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_almac_id As Long, ByVal x_entid_codigo As String, ByVal x_fecha As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("CTRL_MostrarDocumentosCliente")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@ENTID_Codigo", x_entid_codigo, DbType.String, 14)
            DAEnterprise.AgregarParametro("@Fecha", x_fecha, DbType.Boolean, 1)

            x_dtdata = DAEnterprise.ExecuteDataSet().Tables(0)
            Return (x_dtdata.Rows.Count > 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Metodos de Controles"

#End Region
End Class

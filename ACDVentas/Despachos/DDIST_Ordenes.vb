Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DDIST_Ordenes

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_BuscarOrdenesIngreso
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_BuscarOrdenesIngreso(ByVal m_listdist_ordenes As List(Of EDIST_Ordenes), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesIngreso")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

      ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_BuscarOrdenessalidaXlinea
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_BuscarOrdenessalidaXlinea(ByVal m_listdist_ordenes As List(Of EDIST_Ordenes), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                                        ByVal x_linea As String ) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesSalisaXlinea")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 8)
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
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ' <summary> 
    ' Capa de Datos: LOG_DISTSS_BuscarOrdenessalidaXnumeroYlinea
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_pvent_id">Parametro 3: </param> 
    ' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
    ' <param name="x_opcion">Parametro 5: </param> 
    ' <param name="x_cadena">Parametro 6: </param> 
    ' <param name="x_todos">Parametro 7: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function LOG_DISTSS_BuscarOrdenessalidaXnumeroYlinea(ByVal m_listdist_ordenes As List(Of EDIST_Ordenes), ByVal x_serie As String, ByVal x_numero As Long, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                                        ByVal x_linea As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesSalisaXnumeroYlinea")
            DAEnterprise.AgregarParametro("@serie", x_serie, DbType.String, 8)
            DAEnterprise.AgregarParametro("@numero", x_numero, DbType.String, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 8)
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
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function



   ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_BuscarOrdenesIngresoPtoVenta
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_iddestino">Parametro 3: </param> 
   ''' <param name="x_pvent_idorigen">Parametro 4: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <param name="x_todos">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_BuscarOrdenesIngresoPtoVenta(ByVal m_listdist_ordenes As List(Of EDIST_Ordenes), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_pvent_idorigen As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesIngresoPtoVenta")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_IdDestino", x_pvent_iddestino, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@PVENT_IdOrigen", x_pvent_idorigen, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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
   ''' Capa de Datos: LOG_DISTSS_BuscarOrdenesIngresoLocal
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_iddestino">Parametro 3: </param> 
   ''' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_BuscarOrdenesIngresoLocal(ByVal m_listdist_ordenes As List(Of EDIST_Ordenes), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesIngresoLocal")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_IdDestino", x_pvent_iddestino, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
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

   Public Function LOG_DISTSS_ObtenerOrden(ByRef x_dist_ordenes As EDIST_Ordenes, ByVal x_orden_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerOrden")
         DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@Detalle", x_detalle, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_dist_ordenes)
               x_dist_ordenes.Instanciar(ACEInstancia.Consulta)
            Else
               Return False
            End If
            Dim _peso As Decimal = 0
            x_dist_ordenes.ListDIST_OrdenesDetalle = New List(Of EDIST_OrdenesDetalle)
            If reader.NextResult() Then
               Dim _utilitariosdet As New ACEsquemas(New EDIST_OrdenesDetalle)
               While reader.Read()
                  Dim _ordendetalle As New EDIST_OrdenesDetalle
                  _utilitariosdet.ACCargarEsquemas(reader, _ordendetalle)
                  _ordendetalle.Instanciar(ACEInstancia.Consulta)
                  x_dist_ordenes.ListDIST_OrdenesDetalle.Add(_ordendetalle)
                  _peso += _ordendetalle.PesoUnitario * _ordendetalle.ORDET_Cantidad
               End While
            End If
            x_dist_ordenes.Peso = _peso
            Return True
         End Using
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     Public Function LOG_DISTSS_VerificarOrdenGuias(ByRef x_dist_ordenes As EDIST_Ordenes, ByVal x_orden_codigo As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DIST_OrdenesVerificaciondeGuias")
         DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
         
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

     Public Function LOG_DISTSS_actualizarEstadoEntrega( ByVal x_orden_codigo As String,ByVal x_estEntrega As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DIST_ModificarEstadoEntregaOrden")
         DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@Estado_Entrega", x_estEntrega, DbType.String, 1)

          IF DAEnterprise.ExecuteNonQuery() Then
              Return True
                Else 
              Return False
          End If
            
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    



    
#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Asignar permiso para poder generar guia de remision, despues que el documento fue bloqueado por el tiempo mayor al confirurado de no haber sido recogido
   ''' </summary>
   ''' <param name="x_orden_codigo"></param>
   ''' <param name="x_value"></param>
   ''' <param name="x_usuario"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function SetPermisoGenGuia(ByVal x_orden_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Logistica.DIST_Ordenes Set ORDEN_PerGenGuia = {0}, ORDEN_UsrMod = '{2}', ORDEN_FecMod = GETDATE() Where ORDEN_Codigo = '{1}'"
         _sql = String.Format(_sql, IIf(x_value, 1, 0), x_orden_codigo, x_usuario)
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
    ''' <param name="x_orden_codigo"></param>
    ''' <param name="x_value"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoImpOrden(ByVal x_orden_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Logistica.DIST_Ordenes Set ORDEN_Impresa = {0}, ORDEN_UsrMod = '{2}', ORDEN_FecMod = GETDATE() Where ORDEN_Codigo = '{1}'"
            _sql = String.Format(_sql, IIf(x_value, 1, 0), x_orden_codigo, x_usuario)
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
    ''' <param name="x_orden_codigo"></param>
    ''' <param name="x_value"></param>
    ''' <param name="x_usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPermisoAnularOrden(ByVal x_orden_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Logistica.DIST_Ordenes Set ORDEN_PaseAnulacion = {0}, ORDEN_UsrPaseAnulacion = '{2}', ORDEN_FechaPaseAnulacion = GETDATE() Where ORDEN_Codigo = '{1}'"
            _sql = String.Format(_sql, IIf(x_value, 1, 0), x_orden_codigo, x_usuario)
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
   ''' Capa de Datos: LOG_DIST_ObtenerPendientesOrdenes
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_almac_id">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_desbloqueo">Parametro 4: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DIST_ObtenerPendientesOrdenes(ByRef m_listdist_ordenes As List(Of EDIST_Ordenes), ByVal x_fecfin As Date, ByVal x_almac_id As Short, ByVal x_pvent_id As Long, ByVal x_desbloqueo As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DIST_ObtenerPendientesOrdenes")
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ALMAC_Id", x_almac_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@DesBloqueo", x_desbloqueo, DbType.Boolean, 1)
            DAEnterprise.CommandTimeOut = 0
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
   ''' Actualizar fecha de entrega
   ''' </summary>
   ''' <param name="x_orden_codigo">codigo de la orden</param>
   ''' <param name="x_fecha">fecha a actualizar</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ActualizarFechaEntrega(ByVal x_orden_codigo As String, ByVal x_fecha As DateTime, ByVal x_usuario As String)
      Try
         Dim _sql As String = String.Format("Update Logistica.DIST_Ordenes Set ORDEN_FechaEntrega = '{0}', ORDEN_UsrMod = '{2}', ORDEN_FecMod = GETDATE() Where ORDEN_Codigo = '{1}' ", x_fecha.ToString("MM-dd-yyyy"), x_orden_codigo, x_usuario)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Dim i As Integer = DAEnterprise.ExecuteNonQuery()
         Return i > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class


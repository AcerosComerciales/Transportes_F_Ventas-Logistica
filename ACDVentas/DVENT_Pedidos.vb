Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Partial Public Class DVENT_Pedidos


#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "

   ''' <summary> 
   ''' Capa de Datos: VENT_PEDIDSS_Busqueda
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_opcion">Parametro 3: </param> 
   ''' <param name="x_zonas_codigo">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_pvent_id">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_Busqueda(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_Busqueda")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EVENT_Pedidos())
               While reader.Read()
                  Dim e_event_pedidos As New EVENT_Pedidos()
                  _utilitarios.ACCargarEsquemas(reader, e_event_pedidos)
                  e_event_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(e_event_pedidos)
               End While
               Dim m_listEVENT_PedidosDetalle As New List(Of EVENT_PedidosDetalle)
               Dim _utilitariosdet As New ACEsquemas(New EVENT_PedidosDetalle())
               If reader.NextResult() Then
                  While reader.Read()
                     Dim e_event_pedidosdetalle As New EVENT_PedidosDetalle()
                     _utilitariosdet.ACCargarEsquemas(reader, e_event_pedidosdetalle)
                     e_event_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                     m_listEVENT_PedidosDetalle.Add(e_event_pedidosdetalle)
                  End While
               End If
               Dim _filtrador As New ACFiltrador(Of EVENT_PedidosDetalle)
               For Each _pedid As EVENT_Pedidos In m_listvent_pedidos
                  _filtrador.ACFiltro = String.Format("PEDID_Codigo={0}", _pedid.PEDID_Codigo)
                  _pedid.ListDetPedidos = _filtrador.ACFiltrar(m_listEVENT_PedidosDetalle)
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

   ''' <summary> 
   ''' Capa de Datos: VENT_PEDIDSS_BusCliente
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_tconsulta">Parametro 3: </param> 
   ''' <param name="x_cadena">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_zonas_codigo">Parametro 6: </param> 
   ''' <param name="x_sucur_id">Parametro 7: </param> 
   ''' <param name="x_pvent_id">Parametro 8: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_BusCliente(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_BusCliente")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@TConsulta", x_tconsulta, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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
   ''' Capa de Datos: VENT_PEDIDSS_BusClienteSF
   ''' </summary>
   ''' <param name="x_tconsulta">Parametro 1: </param> 
   ''' <param name="x_cadena">Parametro 2: </param> 
   ''' <param name="x_opcion">Parametro 3: </param> 
   ''' <param name="x_zonas_codigo">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_pvent_id">Parametro 6: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_BusClienteSF(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_tconsulta As Short, ByVal x_cadena As String, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_BusClienteSF")
         DAEnterprise.AgregarParametro("@TConsulta", x_tconsulta, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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
   ''' Capa de Datos: VENT_PEDIDSS_BusCodigo
   ''' </summary>
   ''' <param name="x_codigo">Parametro 1: </param> 
   ''' <param name="x_opcion">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_sucur_id">Parametro 4: </param> 
   ''' <param name="x_pvent_id">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_BusCodigo(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_codigo As String, ByVal x_opcion As Boolean, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_pvent_id As Long) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_BusCodigo")
         DAEnterprise.AgregarParametro("@Codigo", x_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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
   ''' Capa de Datos: VENT_PEDIDSS_BusCotizacion
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_pedid_tipo">Parametro 6: </param> 
   ''' <param name="x_opcion">Parametro 7: </param> 
   ''' <param name="x_cadena">Parametro 8: </param> 
   ''' <param name="x_todos">Parametro 9: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_BusCotizacion(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean, Optional ByVal x_rehusados As Boolean = False) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_BusCotizacion")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PEDID_Tipo", x_pedid_tipo, DbType.String, 1)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@Rehusados", x_rehusados, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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

 Public Function VENT_PEDIDSS_ActualizarOrden(ByVal x_codigo_OC As String, ByVal x_estado As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_ActualizarEstadoOC")
            DAEnterprise.AgregarParametro("@PEDID_Codigo", x_codigo_OC, DbType.String, 12)
         DAEnterprise.AgregarParametro("@PEDID_Estado", x_estado, DbType.String, 8)
        
          Return DAEnterprise.ExecuteNonQuery() > 0
         
        
      Catch ex As Exception
         Throw ex
      End Try
   End Function


    
    Public Function VENT_PEDIDSS_BusOrdenCorte(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal artic_codigo As string, ByVal x_todos As Boolean, Optional ByVal x_rehusados As Boolean = False ) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_OrdenCorte")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PEDID_Tipo", x_pedid_tipo, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@ARTIC_Codigo",artic_codigo,DbType.String,50)
         
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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
   ''' Capa de Datos: VENT_PEDIDSS_ConsPedidoReposicion
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_pedid_tipo">Parametro 6: </param> 
   ''' <param name="x_opcion">Parametro 7: </param> 
   ''' <param name="x_cadena">Parametro 8: </param> 
   ''' <param name="x_todos">Parametro 9: </param> 
   ''' <param name="x_pvent_idorigen">Parametro 10: </param> 
   ''' <param name="x_rehusados">Parametro 11: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_ConsPedidoReposicion(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean, ByVal x_pvent_idorigen As Long, ByVal x_rehusados As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_ConsPedidoReposicion")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PEDID_Tipo", x_pedid_tipo, DbType.String, 1)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         If x_pvent_idorigen = 0 Then
            DAEnterprise.AgregarParametro("@PVENT_IdOrigen", Nothing, DbType.Int64, 8)
         Else
            DAEnterprise.AgregarParametro("@PVENT_IdOrigen", x_pvent_idorigen, DbType.Int64, 8)
         End If

         DAEnterprise.AgregarParametro("@Rehusados", x_rehusados, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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
    ' Capa de Datos: VENT_PEDIDSS_ConsPedidoReposicion
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_zonas_codigo">Parametro 3: </param> 
    ' <param name="x_pvent_id">Parametro 4: </param> 
    ' <param name="x_sucur_id">Parametro 5: </param> 
    ' <param name="x_pedid_tipo">Parametro 6: </param> 
    ' <param name="x_opcion">Parametro 7: </param> 
    ' <param name="x_cadena">Parametro 8: </param> 
    ' <param name="x_todos">Parametro 9: </param> 
    ' <param name="x_pvent_idorigen">Parametro 10: </param> 
    ' <param name="x_rehusados">Parametro 11: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    ' m_listVENT_Pedidos, x_numero, x_serie, x_tipo, x_opcion, x_cadena, x_todos, x_linea
    Public Function VENT_PEDIDSS_ConsPedidoReposicionXnumeroYlinea(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_numero As Long, ByVal x_serie As Long, ByVal pvent_id As Short, ByVal x_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean, ByVal x_linea As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("VENT_PEDIDSS_ConsPedidoReposicionXnumeroYlinea")
            DAEnterprise.AgregarParametro("@Numero", x_numero, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Serie", x_serie, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", pvent_id, DbType.String, 5)
            DAEnterprise.AgregarParametro("@PEDID_Tipo", x_tipo, DbType.String, 8)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 1)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 2)
            DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 50)

            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _vent_pedidos As New EVENT_Pedidos()
                        ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                        _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                        m_listvent_pedidos.Add(_vent_pedidos)
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
    ''' Capa de Datos: VENT_PEDIDSS_ConsPedidoReposicion
    ''' </summary>
    ''' <param name="x_fecini">Parametro 1: </param> 
    ''' <param name="x_fecfin">Parametro 2: </param> 
    ''' <param name="x_zonas_codigo">Parametro 3: </param> 
    ''' <param name="x_pvent_id">Parametro 4: </param> 
    ''' <param name="x_sucur_id">Parametro 5: </param> 
    ''' <param name="x_pedid_tipo">Parametro 6: </param> 
    ''' <param name="x_opcion">Parametro 7: </param> 
    ''' <param name="x_cadena">Parametro 8: </param> 
    ''' <param name="x_todos">Parametro 9: </param> 
    ''' <param name="x_pvent_idorigen">Parametro 10: </param> 
    ''' <param name="x_rehusados">Parametro 11: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function VENT_PEDIDSS_ConsPedidoReposicionXlinea(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pedid_tipo As String, ByVal x_pvent_id As Long, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean, ByVal x_linea As string) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_ConsPedidoReposicionXlinea")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PEDID_Tipo", x_pedid_tipo, DbType.String, 8)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String,50)
         DAEnterprise.AgregarParametro("@Todos",x_todos,DbType.Boolean,2)
         DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 50)

         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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
   ''' Capa de Datos: VENT_PEDIDSS_BusPedidoReposicion
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_pvent_iddestino">Parametro 5: </param> 
   ''' <param name="x_sucur_id">Parametro 6: </param> 
   ''' <param name="x_pedid_tipo">Parametro 7: </param> 
   ''' <param name="x_opcion">Parametro 8: </param> 
   ''' <param name="x_cadena">Parametro 9: </param> 
   ''' <param name="x_todos">Parametro 10: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_BusPedidoReposicion(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_pvent_iddestino As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_BusPedidoReposicion")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@PVENT_IdDestino", x_pvent_iddestino, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PEDID_Tipo", x_pedid_tipo, DbType.String, 1)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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
   ''' Capa de Datos: VENT_PEDIDSS_GuiasParaReposicion
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_zonas_codigo">Parametro 3: </param> 
   ''' <param name="x_pvent_id">Parametro 4: </param> 
   ''' <param name="x_sucur_id">Parametro 5: </param> 
   ''' <param name="x_pedid_tipo">Parametro 6: </param> 
   ''' <param name="x_opcion">Parametro 7: </param> 
   ''' <param name="x_cadena">Parametro 8: </param> 
   ''' <param name="x_todos">Parametro 9: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_BusPedidoReposicionParaGuia(ByVal m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_BusPedidoReposicionParaGuia")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PEDID_Tipo", x_pedid_tipo, DbType.String, 1)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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
   ''' Capa de Datos: VENTSS_ModificarPedidosReporte
   ''' </summary>
   ''' <param name="x_pedid_codigo">Parametro 1: </param> 
   ''' <param name="x_pedid_condiciones">Parametro 2: </param> 
   ''' <param name="x_pedid_condicionentrega">Parametro 3: </param> 
   ''' <param name="x_pedid_nota">Parametro 4: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENTSS_ModificarPedidosReporte(ByVal x_pedid_codigo As String, ByVal x_pedid_condiciones As String, ByVal x_pedid_condicionentrega As String, ByVal x_pedid_nota As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENTSS_ModificarPedidosReporte")
         DAEnterprise.AgregarParametro("@PEDID_Codigo", x_pedid_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@PEDID_Condiciones", x_pedid_condiciones, DbType.String, 120)
         DAEnterprise.AgregarParametro("@PEDID_CondicionEntrega", x_pedid_condicionentrega, DbType.String, 120)
         DAEnterprise.AgregarParametro("@PEDID_Nota", x_pedid_nota, DbType.String, 120)
         Dim i As Integer = DAEnterprise.ExecuteNonQuery()
         Return (i > 0)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "

   Public Function getBusqueda(ByRef listEVENT_Pedidos As List(Of EVENT_Pedidos), ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(selectBusqueda(x_where), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New EVENT_Pedidos())
               While reader.Read()
                  Dim e_event_pedidos As New EVENT_Pedidos()
                  _utilitarios.ACCargarEsquemas(reader, e_event_pedidos)
                  e_event_pedidos.Instanciar(ACEInstancia.Consulta)
                  listEVENT_Pedidos.Add(e_event_pedidos)
               End While
               Dim m_listEVENT_PedidosDetalle As New List(Of EVENT_PedidosDetalle)
               Dim _utilitariosdet As New ACEsquemas(New EVENT_PedidosDetalle())
               If reader.NextResult() Then
                  While reader.Read()
                     Dim e_event_pedidosdetalle As New EVENT_PedidosDetalle()
                     _utilitariosdet.ACCargarEsquemas(reader, e_event_pedidosdetalle)
                     e_event_pedidosdetalle.Instanciar(ACEInstancia.Consulta)
                     m_listEVENT_PedidosDetalle.Add(e_event_pedidosdetalle)
                  End While
               End If
               Dim _filtrador As New ACFiltrador(Of EVENT_PedidosDetalle)
               For Each _pedid As EVENT_Pedidos In listEVENT_Pedidos
                  _filtrador.ACFiltro = String.Format("PEDID_Codigo={0}", _pedid.PEDID_Codigo)
                  _pedid.ListDetPedidos = _filtrador.ACFiltrar(m_listEVENT_PedidosDetalle)
               Next
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
   ''' Capa de Datos: VENT_PEDIDSS_ObtenerPedidoReposicion
   ''' </summary>
   ''' <param name="x_fecfin">Parametro 1: </param> 
   ''' <param name="x_zonas_codigo">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_sucur_id">Parametro 4: </param> 
   ''' <param name="x_pedid_tipo">Parametro 5: </param> 
   ''' <param name="x_opcion">Parametro 6: </param> 
   ''' <param name="x_cadena">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_PEDIDSS_ObtenerPedidoReposicion(ByRef m_listvent_pedidos As List(Of EVENT_Pedidos), ByVal x_fecfin As Date, ByVal x_zonas_codigo As String, ByVal x_pvent_id As Long, ByVal x_sucur_id As Short, ByVal x_pedid_tipo As String, ByVal x_opcion As Short, ByVal x_cadena As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("VENT_PEDIDSS_ObtenerPedidoReposicion")
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 5)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@SUCUR_Id", x_sucur_id, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@PEDID_Tipo", x_pedid_tipo, DbType.String, 1)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _vent_pedidos As New EVENT_Pedidos()
                  ACEsquemas.ACCargarEsquema(reader, _vent_pedidos)
                  _vent_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listvent_pedidos.Add(_vent_pedidos)
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

   Public Function ActualizarFechaEntrega(ByVal x_orden_codigo As String, ByVal x_fecha As DateTime, ByVal x_usuario As String)
      Try
         Dim _sql As String = String.Format("Update Ventas.VENT_Pedidos Set PEDID_FechaEntrega = '{0}', PEDID_UsrMod = '{2}', PEDID_FecMod = GETDATE() Where PEDID_Codigo = '{1}' ", x_fecha.ToString("MM-dd-yyyy"), x_orden_codigo, x_usuario)
         DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
         Dim i As Integer = DAEnterprise.ExecuteNonQuery()
         Return i > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function
   '  Public Function ActualizarImpresion(ByVal x_pedid_codigo As String)
   '   Try
   '      Dim _sql As String = String.Format("Update Ventas.VENT_Pedidos Set PEDID_Impresiones = '{0}', PEDID_UsrMod = '{2}', PEDID_FecMod = GETDATE() Where PEDID_Codigo = '{1}' ", x_fecha.ToString("MM-dd-yyyy"), x_orden_codigo, x_usuario)
   '      DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
   '      Dim i As Integer = DAEnterprise.ExecuteNonQuery()
   '      Return i > 0
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

#Region "Procedimientos Adicionales "
   Private Function selectBusqueda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         sql = App.Hash("DVENT_Pedidos.getBusqueda")
         Dim _where As New ACGenerador(Of EVENT_Pedidos)(m_formatofecha)
         sql = String.Format(sql, _where.getWhere(x_where, True))

         Return sql
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ' <summary>
    ' Asignar permiso para poder anular pedido
    ' </summary>
    ' <param name="x_guia_codigo"></param>
    ' <param name="x_value"></param>
    ' <param name="x_usuario"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function SetPermisoAnularPedido(ByVal x_pedid_codigo As String, ByVal x_value As Boolean, ByVal x_usuario As String) As Boolean
        Try
            DAEnterprise.BeginTransaction()
            Dim _sql As String = "Update Ventas.VENT_Pedidos Set PEDID_PaseAnulacion= {0}, PEDID_UsrPaseAnulacion = '{2}', PEDID_FechaPaseAnulacion = GETDATE() Where PEDID_Codigo = '{1}'"
            _sql = String.Format(_sql, IIf(x_value, 1, 0), x_pedid_codigo, x_usuario)
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


End Class


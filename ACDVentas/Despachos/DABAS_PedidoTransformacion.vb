Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACEVentas

Public Class DABAS_PedidoTransformacion


#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   ''' <summary> 
   ''' Capa de Datos: LOG_DISTSS_BuscarPedidoTransIngreso
   ''' </summary>
   ''' <param name="x_fecini">Parametro 1: </param> 
   ''' <param name="x_fecfin">Parametro 2: </param> 
   ''' <param name="x_pvent_id">Parametro 3: </param> 
   ''' <param name="x_tipos_codtipopedido">Parametro 4: </param> 
   ''' <param name="x_opcion">Parametro 5: </param> 
   ''' <param name="x_cadena">Parametro 6: </param> 
   ''' <param name="x_todos">Parametro 7: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_DISTSS_BuscarPedidoTransIngreso(ByVal m_listdist_ordenes As List(Of EABAS_PedidoTransformacion), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipopedido As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarPedidodTransformaiconIngreso")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_CodTipoPedido", x_tipos_codtipopedido, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_pedidos As New EABAS_PedidoTransformacion()
                  ACEsquemas.ACCargarEsquema(reader, _dist_pedidos)
                  _dist_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_pedidos)
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
    
    Public Function LOG_DISTSS_BuscarPedidoTransIngresoxlote(ByVal m_listdist_ordenes As List(Of EABAS_PedidoTransformacionDetalle), ByVal x_lote As String, ByVal x_alamacen As Short, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ABAS_PEDIDTransformacionXlote")
         DAEnterprise.AgregarParametro("@lote", x_lote, DbType.String, 8)
         DAEnterprise.AgregarParametro("@almacen", x_alamacen, DbType.String, 8)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_pedidos As New EABAS_PedidoTransformacionDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _dist_pedidos)
                  _dist_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_pedidos)
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
    
       Public Function LOG_DISTSS_BuscarPedidoTransIngresoxfecha(ByVal m_listdist_ordenes As List(Of EABAS_PedidoTransformacionDetalle),ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_alamacen As Short, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ABAS_PEDIDTransformacionXfecha")
         DAEnterprise.AgregarParametro("@fecini", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@fecfin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@almacen", x_alamacen, DbType.String, 8)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_pedidos As New EABAS_PedidoTransformacionDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _dist_pedidos)
                  _dist_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_pedidos)
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
    
     Public Function LOG_DISTSS_BuscarPedidoTransCANTIDAD(ByVal m_listdist_ordenes As List(Of EABAS_PedidoTransformacion),ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_alamacen As Short, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ABAS_PEDIDTransformacionCantidad")
         DAEnterprise.AgregarParametro("@fecini", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@fecfin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@almacen", x_alamacen, DbType.String, 8)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_pedidos As New EABAS_PedidoTransformacion()
                  ACEsquemas.ACCargarEsquema(reader, _dist_pedidos)
                  _dist_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_pedidos)
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



    Public Function LOG_DISTSS_BuscarPedidoTransIngresoxArticulo(ByVal m_listdist_ordenes As List(Of EABAS_PedidoTransformacionDetalle), ByVal x_articulo As String, ByVal x_alamacen As Short, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_ABAS_PEDIDTransformacionXArticulo")
         DAEnterprise.AgregarParametro("@artic_codigo", x_articulo, DbType.String, 8)
         DAEnterprise.AgregarParametro("@almacen", x_alamacen, DbType.String, 8)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_pedidos As New EABAS_PedidoTransformacionDetalle()
                  ACEsquemas.ACCargarEsquema(reader, _dist_pedidos)
                  _dist_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_pedidos)
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

    Public Function AgreagarCalibre( ByVal x_codigogestor As String, ByVal x_calibre As Decimal, ByVal x_pm As Decimal, ByVal x_aprox As Decimal, ByVal x_numCalibre As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("AgregarCalibre")
         DAEnterprise.AgregarParametro("@adicional", x_numCalibre, DbType.String, 10)
         DAEnterprise.AgregarParametro("@GESTOR_Codigo", x_codigogestor, DbType.String, 20)
         DAEnterprise.AgregarParametro("@calibre", x_calibre, DbType.Decimal)
         DAEnterprise.AgregarParametro("@pm", x_pm, DbType.Decimal)
         DAEnterprise.AgregarParametro("@aprox", x_aprox, DbType.Decimal)
          if DAEnterprise.ExecuteNonQuery() Then
              Return True
          End If
            Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
    Public Function ActualizarEstadoT( ByVal x_codigogestor As String) As Boolean
      Try
         DAEnterprise.AsignarProcedure("ActualizarEstadoGestionamiento")
         DAEnterprise.AgregarParametro("@GESTOR_Codigo", x_codigogestor, DbType.String, 20)
         if DAEnterprise.ExecuteNonQuery() Then
              Return True
          End If
            Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function
    
      Public Function LOG_DISTSS_BuscarPedidoTransIngresoConfir(ByVal m_listdist_ordenes As List(Of EABAS_PedidoTransformacion), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarPedidodTransformaiconConfirmado")
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
                  Dim _dist_pedidos As New EABAS_PedidoTransformacion()
                  ACEsquemas.ACCargarEsquema(reader, _dist_pedidos)
                  _dist_pedidos.Instanciar(ACEInstancia.Consulta)
                  m_listdist_ordenes.Add(_dist_pedidos)
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



   ' Public Function LOG_DISTSS_BuscarOrdenesSalidaProConf(ByVal m_listdist_ordenes As List(Of EABAS_OrdenesProduccion), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   Try
   '      DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesPedidoProduccion")
   '      DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
   '      DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
   '      DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
   '      DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
   '      DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
   '      Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
   '         If reader.HasRows Then
   '            While reader.Read()
   '               Dim _dist_ordenes As New EABAS_OrdenesProduccion()
   '               ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
   '               _dist_ordenes.Instanciar(ACEInstancia.Consulta)
   '               m_listdist_ordenes.Add(_dist_ordenes)
   '            End While
   '            Return True
   '         Else
   '            Return False
   '         End If
   '      End Using
   '      Return False
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function


    
   ' Public Function LOG_DISTSS_BuscarOrdenesIngresoConf(ByVal m_listdist_ordenes As List(Of EABAS_OrdenesProduccion), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   Try
   '      DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesIngresoProduccionConfirmado")
   '      DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
   '      DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
   '      DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
   '      DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
   '      DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
   '      Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
   '         If reader.HasRows Then
   '            While reader.Read()
   '               Dim _dist_ordenes As New EABAS_OrdenesProduccion()
   '               ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
   '               _dist_ordenes.Instanciar(ACEInstancia.Consulta)
   '               m_listdist_ordenes.Add(_dist_ordenes)
   '            End While
   '            Return True
   '         Else
   '            Return False
   '         End If
   '      End Using
   '      Return False
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   ' ''' <summary> 
   ' ''' Capa de Datos: LOG_DISTSS_BuscarOrdenesIngresoPtoVenta
   ' ''' </summary>
   ' ''' <param name="x_fecini">Parametro 1: </param> 
   ' ''' <param name="x_fecfin">Parametro 2: </param> 
   ' ''' <param name="x_pvent_iddestino">Parametro 3: </param> 
   ' ''' <param name="x_pvent_idorigen">Parametro 4: </param> 
   ' ''' <param name="x_tipos_codtipoorden">Parametro 5: </param> 
   ' ''' <param name="x_opcion">Parametro 6: </param> 
   ' ''' <param name="x_cadena">Parametro 7: </param> 
   ' ''' <param name="x_todos">Parametro 8: </param> 
   ' ''' <returns></returns> 
   ' ''' <remarks></remarks> 
   'Public Function LOG_DISTSS_BuscarOrdenesIngresoPtoVenta(ByVal m_listdist_ordenes As List(Of EABAS_OrdenesProduccion), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_pvent_idorigen As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   Try
   '      DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesIngresoProduccionPtoVenta")
   '      DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@PVENT_IdDestino", x_pvent_iddestino, DbType.Int64, 8)
   '      DAEnterprise.AgregarParametro("@PVENT_IdOrigen", x_pvent_idorigen, DbType.Int64, 8)
   '      DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
   '      DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
   '      DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
   '      DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
   '      Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
   '         If reader.HasRows Then
   '            While reader.Read()
   '               Dim _dist_ordenes As New EABAS_OrdenesProduccion()
   '               ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
   '               _dist_ordenes.Instanciar(ACEInstancia.Consulta)
   '               m_listdist_ordenes.Add(_dist_ordenes)
   '            End While
   '            Return True
   '         Else
   '            Return False
   '         End If
   '      End Using
   '      Return True
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   ' ''' <summary> 
   ' ''' Capa de Datos: LOG_DISTSS_BuscarOrdenesIngresoLocal
   ' ''' </summary>
   ' ''' <param name="x_fecini">Parametro 1: </param> 
   ' ''' <param name="x_fecfin">Parametro 2: </param> 
   ' ''' <param name="x_pvent_iddestino">Parametro 3: </param> 
   ' ''' <param name="x_tipos_codtipoorden">Parametro 4: </param> 
   ' ''' <param name="x_opcion">Parametro 5: </param> 
   ' ''' <param name="x_cadena">Parametro 6: </param> 
   ' ''' <param name="x_todos">Parametro 7: </param> 
   ' ''' <returns></returns> 
   ' ''' <remarks></remarks> 
   'Public Function LOG_DISTSS_BuscarOrdenesIngresoLocal(ByVal m_listdist_ordenes As List(Of EABAS_OrdenesProduccion), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_iddestino As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
   '   Try
   '      DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarOrdenesIngresoProduccionLocal")
   '      DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
   '      DAEnterprise.AgregarParametro("@PVENT_IdDestino", x_pvent_iddestino, DbType.Int64, 8)
   '      DAEnterprise.AgregarParametro("@TIPOS_CodTipoOrden", x_tipos_codtipoorden, DbType.String, 6)
   '      DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
   '      DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
   '      DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
   '      Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
   '         If reader.HasRows Then
   '            While reader.Read()
   '               Dim _dist_ordenes As New EABAS_OrdenesProduccion()
   '               ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
   '               _dist_ordenes.Instanciar(ACEInstancia.Consulta)
   '               m_listdist_ordenes.Add(_dist_ordenes)
   '            End While
   '            Return True
   '         Else
   '            Return False
   '         End If
   '      End Using
   '      Return True
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   Public Function LOG_DISTSS_Obtenerpedidotrans(ByRef x_dist_pedidtrans As EABAS_PedidoTransformacion, ByVal x_pedidotrans_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerPedidoTrans")
         DAEnterprise.AgregarParametro("@PEDID_Codigotrans", x_pedidotrans_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@Detalle", x_detalle, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_dist_pedidtrans)
               x_dist_pedidtrans.Instanciar(ACEInstancia.Consulta)
            Else
               Return False
            End If
            Dim _peso As Decimal = 0
            x_dist_pedidtrans.ListABAS_PedidoTransDetalle = New List(Of EABAS_PedidoTransformacionDetalle)
            If reader.NextResult() Then
               Dim _utilitariosdet As New ACEsquemas(New EABAS_PedidoTransformacionDetalle)
               While reader.Read()
                  Dim _pedidodetalle As New EABAS_PedidoTransformacionDetalle
                  _utilitariosdet.ACCargarEsquemas(reader, _pedidodetalle)
                  _pedidodetalle.Instanciar(ACEInstancia.Consulta)
                  x_dist_pedidtrans.ListABAS_PedidoTransDetalle.Add(_pedidodetalle)
                  _peso += _pedidodetalle.PesoUnitario * _pedidodetalle.PEDID_Cantidad
               End While
            End If
            x_dist_pedidtrans.Peso = _peso
            Return True
         End Using
            
         Return False
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    
    Public Function LOG_DISTSS_Obtenerpedidotrans_consulta(ByRef x_dist_pedidtrans As EABAS_PedidoTransformacion, ByVal x_pedidotrans_codigo As String, ByVal x_detalle As Boolean) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerPedidoTransConsuta")
         DAEnterprise.AgregarParametro("@PEDID_Codigotrans", x_pedidotrans_codigo, DbType.String, 14)
         DAEnterprise.AgregarParametro("@Detalle", x_detalle, DbType.Boolean, 1)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

            If reader.HasRows Then
               reader.Read()
               ACEsquemas.ACCargarEsquema(reader, x_dist_pedidtrans)
               x_dist_pedidtrans.Instanciar(ACEInstancia.Consulta)
            Else
               Return False
            End If
            Dim _peso As Decimal = 0
            x_dist_pedidtrans.ListABAS_PedidoTransDetalle = New List(Of EABAS_PedidoTransformacionDetalle)
            If reader.NextResult() Then
               Dim _utilitariosdet As New ACEsquemas(New EABAS_PedidoTransformacionDetalle)
               While reader.Read()
                  Dim _pedidodetalle As New EABAS_PedidoTransformacionDetalle
                  _utilitariosdet.ACCargarEsquemas(reader, _pedidodetalle)
                  _pedidodetalle.Instanciar(ACEInstancia.Consulta)
                  x_dist_pedidtrans.ListABAS_PedidoTransDetalle.Add(_pedidodetalle)
                  _peso += _pedidodetalle.PesoUnitario * _pedidodetalle.PEDID_Cantidad
               End While
            End If
            x_dist_pedidtrans.Peso = _peso
            Return True
         End Using
            
         Return False
      Catch ex As Exception
         Throw ex
      End Try
    End Function




   '    Try
   '      DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerOrdenProduccion")
   '      DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 13)
   '      DAEnterprise.AgregarParametro("@Detalle", x_detalle, DbType.Boolean, 1)
   '      Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

   '         If reader.HasRows Then
   '            reader.Read()
   '            ACEsquemas.ACCargarEsquema(reader, x_dist_ordenes)
   '            x_dist_ordenes.Instanciar(ACEInstancia.Consulta)
   '         Else
   '            Return False
   '         End If
   '         Dim _peso As Decimal = 0
   '         x_dist_ordenes.ListDIST_OrdenesDetalle = New List(Of EABAS_OrdenesProduccionDetalle)
   '         If reader.NextResult() Then
   '            Dim _utilitariosdet As New ACEsquemas(New EABAS_OrdenesProduccionDetalle)
   '            While reader.Read()
   '               Dim _ordendetalle As New EABAS_OrdenesProduccionDetalle
   '               _utilitariosdet.ACCargarEsquemas(reader, _ordendetalle)
   '               _ordendetalle.Instanciar(ACEInstancia.Consulta)
   '               x_dist_ordenes.ListDIST_OrdenesDetalle.Add(_ordendetalle)
   '               _peso += _ordendetalle.PesoUnitario * _ordendetalle.ORDET_Cantidad
   '            End While
   '         End If
   '         x_dist_ordenes.Peso = _peso
   '         Return True
   '      End Using
   '      Return False
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function



    'Public Function LOG_DISTSS_ObtenerOrdend(ByRef x_dist_ordenes As EABAS_OrdenesProduccion, ByVal x_orden_codigo As String, ByVal x_detalle As Boolean) As Boolean
    '  Try
    '     DAEnterprise.AsignarProcedure("LOG_DISTSS_ObtenerOrdenProduccion")
    '     DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_orden_codigo, DbType.String, 13)
    '     DAEnterprise.AgregarParametro("@Detalle", x_detalle, DbType.Boolean, 1)
    '     Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()

    '        If reader.HasRows Then
    '           reader.Read()
    '           ACEsquemas.ACCargarEsquema(reader, x_dist_ordenes)
    '           x_dist_ordenes.Instanciar(ACEInstancia.Consulta)
    '        Else
    '           Return False
    '        End If
    '        Dim _peso As Decimal = 0
    '        x_dist_ordenes.ListDIST_OrdenesDetalle = New List(Of EABAS_OrdenesProduccionDetalle)
    '        If reader.NextResult() Then
    '           Dim _utilitariosdet As New ACEsquemas(New EABAS_OrdenesProduccionDetalle)
    '           While reader.Read()
    '              Dim _ordendetalle As New EABAS_OrdenesProduccionDetalle
    '              _utilitariosdet.ACCargarEsquemas(reader, _ordendetalle)
    '              _ordendetalle.Instanciar(ACEInstancia.Consulta)
    '              _ordendetalle.ORDET_ItemDocumento = _ordendetalle.ORDET_Item+100 
    '              _ordendetalle.ORDET_Item=Nothing
    '              x_dist_ordenes.ListDIST_OrdenesDetalle.Add(_ordendetalle)
    '              _peso += _ordendetalle.PesoUnitario * _ordendetalle.ORDET_Cantidad
    '           End While
    '        End If
    '        x_dist_ordenes.Peso = _peso
    '        Return True
    '     End Using
    '     Return False
    '  Catch ex As Exception
    '     Throw ex
    '  End Try
  ' End Function

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "


#End Region
End Class

Partial Public Class DABAS_PedidoTransformacion

#Region " Variables "
	Private m_formatofecha As String
	Public ReadOnly Property Tabla() As String
		Get
			Return "ABAS_PedidoTransformacion"
		End Get
	End Property
	Public ReadOnly Property Esquema() As String
		Get
			Return "Logistica"
		End Get
	End Property

#End Region

#Region " Constructores "
	
	Public Sub New()
		m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
	End Sub

#End Region

#Region " Procedimientos Almacenados "
	
	Public Function DIST_PEDIDTransS_Todos(ByRef x_listDIST_Ordenes As List(Of EABAS_PedidoTransformacion)) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_PedidoTransformacion())
					While reader.Read()
						Dim x_edist_ordenes As New EABAS_PedidoTransformacion()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_Ordenes.Add(x_edist_ordenes)
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

	Public Function DIST_PEDIDTransS_Todos(ByRef x_listDIST_Ordenes As List(Of EABAS_PedidoTransformacion), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_PedidoTransformacion())
					While reader.Read()
						Dim x_edist_ordenes As New EABAS_PedidoTransformacion()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_Ordenes.Add(x_edist_ordenes)
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

	Public Function DIST_PEDIDTransS_Todos(ByRef x_listDIST_Ordenes As List(Of EABAS_PedidoTransformacion), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_PedidoTransformacion())
					While reader.Read()
						Dim x_edist_ordenes As New EABAS_PedidoTransformacion()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_Ordenes.Add(x_edist_ordenes)
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

	Public Function DIST_PEDIDTransS_Todos(ByRef x_listDIST_Ordenes As List(Of EABAS_PedidoTransformacion), ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable, ByVal x_distinct As Boolean) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where, x_distinct), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows
					Dim _utilitarios As New ACEsquemas(New EABAS_PedidoTransformacion())
					While reader.Read()
						Dim x_edist_ordenes As New EABAS_PedidoTransformacion()
						_utilitarios.ACCargarEsquemas(reader, x_edist_ordenes)
						x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
						x_listDIST_Ordenes.Add(x_edist_ordenes)
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

	Public Function DIST_PEDIDTransS_Todos(ByRef m_datos As DataSet, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransS_Todos(ByRef m_datos As DataSet, ByVal m_campos() As ACCampos, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(m_campos, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransS_Todos(ByRef m_datos As DataSet, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectAll(x_join, x_where), CommandType.Text)
			m_datos = DAEnterprise.ExecuteDataSet()
			Return m_datos.Tables.Count > 0
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransS_UnReg(ByRef x_edist_ordenes As EABAS_PedidoTransformacion, ByVal x_orden_codigo As String) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_orden_codigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_ordenes)
					x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    ' ''' <summary>
    ' ''' alex
    ' ''' </summary>
    ' ''' <param name="m_data"></param>
    ' ''' <param name="x_zonas_codigo"></param>
    ' ''' <param name="x_articulo"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    '    Public Function Obtener_Deta_Anulada(ByRef m_data As DataTable, ByVal x_docve_codigo As String,ByVal documento As String) As Boolean
    '    Try
    '        DAEnterprise.AsignarProcedure("Log_Dist_ObtenerMotAnulacionOrdProduccion")
    '        'DAEnterprise.AgregarParametro("@ZONAS_Codigo", x_zonas_codigo, DbType.String, 6)
    '        DAEnterprise.AgregarParametro("@ORDEN_Codigo", x_docve_codigo, DbType.String, 50)

    '        m_data = DAEnterprise.ExecuteDataSet().Tables(0)
    '        Return m_data.Rows.Count > 0
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

	Public Function DIST_PEDIDTransSS_UnReg(ByRef x_edist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_ordenes)
					x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSS_UnReg(ByRef x_edist_ordenes As EABAS_PedidoTransformacion, ByVal x_join As List(Of ACJoin), ByVal x_where As Hashtable) As Boolean
		Try
			DAEnterprise.AsignarProcedure(getSelectBy(x_join, x_where), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					ACEsquemas.ACCargarEsquema(reader, x_edist_ordenes)
					x_edist_ordenes.Instanciar(ACEInstancia.Consulta)
					return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Throw ex
		End Try
	End Function

     Public Function LOG_DISTSS_BuscarPedidoTransXnumeroYlinea(ByVal m_listdist_PT As List(Of EABAS_PedidoTransformacion), ByVal x_serie As String, ByVal x_numero As Long, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                                        ByVal x_linea As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarPedidoTransformacionXnumeroYlinea")
            DAEnterprise.AgregarParametro("@serie", x_serie, DbType.String, 8)
            DAEnterprise.AgregarParametro("@numero", x_numero, DbType.String, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@TIPOS_CodTipoPedidoTrans", x_tipos_codtipoorden, DbType.String, 6)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 8)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _dist_ordenes As New EABAS_PedidoTransformacion()
                        ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
                        _dist_ordenes.Instanciar(ACEInstancia.Consulta)
                        m_listdist_PT.Add(_dist_ordenes)
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

    Public Function LOG_DISTSS_BuscarOrdenessalidaXlinea(ByVal m_listdist_pt As List(Of EABAS_PedidoTransformacion), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_tipos_codtipoorden As String, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean,
                                                        ByVal x_linea As String ) As Boolean
      Try
         DAEnterprise.AsignarProcedure("LOG_DISTSS_BuscarPedidoTransformacionXlinea")
         DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
         DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
         DAEnterprise.AgregarParametro("@TIPOS_Codtipo", x_tipos_codtipoorden, DbType.String, 6)
         DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
         DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
         DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
         DAEnterprise.AgregarParametro("@linea", x_linea, DbType.String, 8)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               While reader.Read()
                  Dim _dist_ordenes As New EABAS_PedidoTransformacion()
                  ACEsquemas.ACCargarEsquema(reader, _dist_ordenes)
                  _dist_ordenes.Instanciar(ACEInstancia.Consulta)
                  m_listdist_pt.Add(_dist_ordenes)
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





	Public Function DIST_PEDIDTransSI_UnReg(ByRef x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_ordenes, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSI_UnReg(ByRef x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_ordenes, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSI_UnReg(ByRef x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getInsert(x_dist_ordenes, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSU_UnReg(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSU_UnReg(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSU_UnReg(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As HashTable, ByVal x_usuario As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_where, x_usuario), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSU_UnReg(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_where, x_usuario, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSU_UnReg(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_where, x_usuario, x_excluir, x_setfecha), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTransSU_UnReg(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getUpdate(x_dist_ordenes, x_where, x_usuario, x_excluir, x_setfecha, x_setcampos), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTrans_UnReg(ByVal x_dist_ordenes As EABAS_PedidoTransformacion) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_dist_ordenes), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function DIST_PEDIDTrans_UnReg(ByVal x_where As Hashtable) As Integer
		Try
			DAEnterprise.AsignarProcedure(getDelete(x_where), CommandType.Text)
			Return DAEnterprise.ExecuteNonQuery()
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function getCorrelativo(ByVal x_campo As String) As Integer
		Try
			DAEnterprise.AsignarProcedure(getSelectId(x_campo), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
			Return CType(m_data.Tables(0).Rows(0)("Id"), Integer)
		Catch ex As Exception
			Throw ex
		End Try
	End Function


    Public Function getlote_existente(ByVal x_lote As String, ByVal x_articcodigo As String) As Boolean
		
        DAEnterprise.AsignarProcedure(getSelectlote_existente(x_lote,x_articcodigo), CommandType.Text)
			Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
				If reader.HasRows Then
					reader.Read()
					return True
				Else
					Return False
				End If
			End Using
	End Function



    Public Function getUnidadMedida(ByVal x_campo As String) As String
		Try
			DAEnterprise.AsignarProcedure(getSelectunidad(x_campo), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
			Return CType(m_data.Tables(0).Rows(0)("TIPOS_CodUnidadMedida"), String)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    

	Public Function getCorrelativo(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			DAEnterprise.AsignarProcedure(getSelectId(x_campo, x_where), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
			Return CType(m_data.Tables(0).Rows(0)("Id"), Integer)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

    Public Function getCorrelativoXtip(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
		Try
			DAEnterprise.AsignarProcedure(getSelectIdXtipo(x_campo, x_where), CommandType.Text)
			Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
			Return CType(m_data.Tables(0).Rows(0)("Id"), Integer)
		Catch ex As Exception
			Throw ex
		End Try
	End Function
    
	#region "Procedimientos Adicionales "
		Private Function getSelectAll() As String
			Dim sql As String = ""
			Try
				sql = " SELECT * "
				sql &= " FROM Logistica.ABAS_PedidoTransformacion" & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_PedidoTransformacion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal m_campos() As ACCampos, ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  " & vbNewLine
				Dim i As Boolean = True
				For Each Item As ACCampos In m_campos
					If i Then
						sql &= String.Format(" {0} As {1}{2}", Item.CampoOrigen, Item.CampoDestino, vbNewLine)
						i = False
					Else
						sql &= String.Format(",{0} As {1}{2}", Item.CampoOrigen, Item.CampoDestino, vbNewLine)
					End If
				Next
				sql &= " FROM Logistica.ABAS_PedidoTransformacion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha)
 				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectAll(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable, ByVal x_distinct As Boolean) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where, x_distinct)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_orden_codigo As String) As String
			Dim sql As String = ""
			Try
				sql  = " SELECT * " & vbNewLine
				sql &= " FROM Logistica.ABAS_PedidoTransformacion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				sql &= "ORDEN_Codigo = " + IIf(IsNothing(x_orden_codigo), "Null", "'" & x_orden_codigo & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try
				sql = " SELECT  * " & vbNewLine
				sql &= " FROM Logistica.ABAS_PedidoTransformacion" & vbNewLine
				sql &= " WHERE " & vbNewLine
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha)
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectBy(ByVal x_join As List(Of ACJoin), ByVal x_where As HashTable) As String
			Dim sql As String = ""
			Try

				Dim _join As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha)
 
				sql &= _join.getJoin(Esquema, Tabla, x_join, x_where)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrCrea = x_usuario
				x_dist_ordenes.PEDID_FecCREA = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				sql = _insert.getInsert(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, New String() {})


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrCrea = x_usuario
				x_dist_ordenes.PEDID_FecCREA = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, New String() {}, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getInsert(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrCrea = x_usuario
				x_dist_ordenes.PEDID_FecCREA = _fecha

				Dim _insert As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				sql = _insert.getInsertFecha(Esquema, Tabla, x_dist_ordenes, x_dist_ordenes.Hash, x_excluir, x_setfecha)


				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrMod = x_usuario
				x_dist_ordenes.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_CodigoTrans", New ACWhere(x_DIST_Ordenes.PEDID_CodigoTrans, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrMod = x_usuario
				x_dist_ordenes.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_CodigoTrans", New ACWhere(x_DIST_Ordenes.PEDID_CodigoTrans, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As HashTable, ByVal x_usuario As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrMod = x_usuario
				x_dist_ordenes.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, New String() {})

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrMod = x_usuario
				x_dist_ordenes.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				Dim _where As New Hashtable()
				_where.Add("PEDID_CodigoTrans", New ACWhere(x_DIST_Ordenes.PEDID_CodigoTrans, ACWhere.TipoWhere.Igual))
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, _where, x_dist_ordenes.Hash, New String() {}, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrMod = x_usuario
				x_dist_ordenes.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				sql = _update.getUpdateFecha(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, x_excluir, x_setfecha)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getUpdate(ByVal x_dist_ordenes As EABAS_PedidoTransformacion, ByVal x_where As HashTable, ByVal x_usuario As String, ByVal x_excluir() As String, ByVal x_setfecha() As String, ByVal x_setcampos() As String) As String
			Dim sql As String = ""
			Try
				Dim _fecha As DateTime = getDateTime()
				x_dist_ordenes.PEDID_UsrMod = x_usuario
				x_dist_ordenes.PEDID_FecMod = _fecha

				Dim _update As New ACFramework.ACGenerador(Of EABAS_PedidoTransformacion)(_fecha, m_formatofecha)
				sql = _update.getUpdate(Esquema, Tabla, x_dist_ordenes, x_where, x_dist_ordenes.Hash, x_excluir, x_setfecha, x_setcampos)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_dist_ordenes As EABAS_PedidoTransformacion) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_PedidoTransformacion" & vbNewLine
				sql &= " WHERE "
				sql &= "    ORDEN_Codigo = " & IIf(IsNothing(x_dist_ordenes.PEDID_CodigoTrans), "Null", "'" & x_dist_ordenes.PEDID_CodigoTrans & "'") & vbNewLine

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getDelete(ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = " DELETE FROM Logistica.ABAS_PedidoTransformacion" & vbNewLine
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function getSelectId(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_PedidoTransformacion ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

    Private Function getSelectunidad(ByVal x_campo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" select TIPOS_CodUnidadMedida from Articulos where ARTIC_Codigo='{0}' ", x_campo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function

    Private Function getSelectlote_existente(ByVal x_lote As String,ByVal x_artic_codigo As String) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" select PEDID_Lote from Logistica.ABAS_PedidoTransformacionDetalle where PEDID_Lote={0} and ARTIC_Codigo='{1}'", x_lote,x_artic_codigo)

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
    
		Private Function getSelectId(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_PedidoTransformacion ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function
   
    Private Function  getSelectIdXtipo(ByVal x_campo As String, ByVal x_where As HashTable) As String 
			Dim sql As String = ""
			Try

				sql  = String.Format(" SELECT IsNull(Max({0}), 0) As Id From Logistica.ABAS_PedidoTransformacion ", x_campo)
				sql &= " WHERE "
				Dim _where As New ACGenerador(Of EABAS_PedidoTransformacion)(m_formatofecha) 
				sql &= _where.getWhere(x_where, True) 

				Return sql
			Catch ex As Exception
				Throw ex
			End Try
		End Function



	#End Region
#End Region

#Region " Metodos "
	
	Private Function getDate() As String
		Dim x_datos As New DataTable()
		Try
			DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
			x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
			Dim _fecha As DateTime = x_datos.Rows(0)(0)
			Return "'" & _fecha.ToString(m_formatofecha) & "'"
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Private Function getDateTime() As DateTime
		Dim x_datos As New DataTable()
		Try
			DAEnterprise.AsignarProcedure("Select GetDate()", CommandType.Text)
			x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
			Dim _fecha As DateTime = x_datos.Rows(0)(0)
			Return _fecha
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region


End Class

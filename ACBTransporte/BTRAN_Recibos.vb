Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration

Imports ACEVentas
Imports ACFramework
Imports ACBVentas

Imports DAConexion

Public Class BTRAN_Recibos

#Region " Variables "
   Private m_listVENT_PVentDocumento As List(Of EVENT_PVentDocumento)

   Private m_zonas_codigo As String
   Private m_sucur_id As Integer
   Private m_pvent_id As Integer
   Private m_aplicacion As String
   Private m_periodo As String
#End Region

#Region " Constructores "
   Public Sub New(ByVal x_aplicacion As String, ByVal x_zona As String, ByVal x_sucursal As Integer, ByVal x_pvent_id As Integer, ByVal x_periodo As String)
      m_zonas_codigo = x_zona
      m_periodo = x_periodo
      m_sucur_id = x_sucursal
      m_pvent_id = x_pvent_id
      m_aplicacion = x_aplicacion

      d_tran_recibos = New DTRAN_Recibos()
   End Sub
#End Region

#Region " Propiedades "
   Public Property ListVENT_PVentDocumento() As List(Of EVENT_PVentDocumento)
      Get
         Return m_listVENT_PVentDocumento
      End Get
      Set(ByVal value As List(Of EVENT_PVentDocumento))
         m_listVENT_PVentDocumento = value
      End Set
   End Property
#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   ' <summary>
   ' Genera el correlativo segun el documento de venta y la serie
   ' </summary>
   ' <param name="x_docve_serie">Serie del documento</param>
   ' <param name="x_tipos_codtipodocumento">Tipo de documento/comprobante de venta</param>
   ' <returns>Retorna el numero correspondiente al ultimo generado</returns>
   ' <remarks></remarks>
   Public Function getNumero(ByVal x_docve_serie As String, ByVal x_tipos_codtipodocumento As String) As Integer
      Try
         Return d_tran_recibos.getNumero(x_docve_serie, x_tipos_codtipodocumento)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetSeries(ByVal x_zonas_codigo As String, ByVal x_sucur_id As Integer, ByVal x_pvent_id As Integer, ByVal x_tipo_documento As String) As Boolean
      Try
         m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)()

         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ESucursales.Esquema, ESucursales.Tabla, "Sucur", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("SUCUR_Id", "SUCUR_Id")} _
                              , New ACCampos() {New ACCampos("SUCUR_Nombre", "SUCUR_Nombre")}))
         _join.Add(New ACJoin(EPuntoVenta.Esquema, EPuntoVenta.Tabla, "PVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("PVENT_Id", "PVENT_Id")} _
                              , New ACCampos() {New ACCampos("PVENT_Descripcion", "PVENT_Descripcion")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoDocumento")}))

         Dim x_where As New Hashtable
         x_where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         x_where.Add("SUCUR_Id", New ACWhere(x_sucur_id))

         If x_pvent_id > 0 Then x_where.Add("PVENT_Id", New ACWhere(x_pvent_id))
         If x_tipo_documento.Length > 3 Then x_where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_tipo_documento))

         ''Jalar los datos de la capa de Negocio de BVENT_PVentDocumento
         Dim m_bvent_pventdoc As New BVENT_PVentDocumento
         '' CargarTodos: Metodo para Cargar todas las listas de los registros
         If m_bvent_pventdoc.CargarTodos(_join, x_where) Then
            m_listVENT_PVentDocumento = New List(Of EVENT_PVentDocumento)(m_bvent_pventdoc.ListVENT_PVentDocumento)
            Return True
         End If
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function cargarRecibos(ByVal x_where As Hashtable) As Boolean
      m_listTRAN_Recibos = New List(Of ETRAN_Recibos)
      Try
         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoRecibo")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoRecibo")}))
         _join.Add(New ACJoin(ETipos.Esquema, ETipos.Tabla, "TMon", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                              , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_TipoMoneda")}))
         Return CargarTodos(_join, x_where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Procedimiento "TRAN_CAJASS_RecibosTransporte" por el Generador 03/04/2012
   ' </summary> 
   ' <param name="x_viaje_id">Parametro 1: </param> 
   ' <returns>Si no hay registros devuelve Falso</returns> 
   ' <remarks></remarks> 
   Public Function CargarRecibos(ByVal x_viaje_id As Long) As Boolean
      Dim m_dtran_recibos As New DTRAN_Recibos()
      m_listTRAN_Recibos = New List(Of ETRAN_Recibos)
      Try
         Return m_dtran_recibos.TRAN_CAJASS_RecibosTransporte(m_listTRAN_Recibos, x_viaje_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Guardar(ByVal x_usuario As String, ByVal x_entid_codigo As String)
      Try
         DAEnterprise.BeginTransaction()
         If m_tran_recibos.Nuevo Then
            If Guardar(x_usuario) Then
               '' Pagos
               Dim _caja As New BTESO_Caja
               _caja.TESO_Caja = New ETESO_Caja
               _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)

               _caja.TESO_Caja.PVENT_Id = m_pvent_id
               _caja.TESO_Caja.TIPOS_CodTipoMoneda = m_tran_recibos.TIPOS_CodTipoMoneda
               _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboTransporte)
               Dim managerGenerarDocsVenta As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)

               If managerGenerarDocsVenta.GetSeries(m_aplicacion, m_zonas_codigo, m_sucur_id, m_pvent_id, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Caja)) Then
                  _caja.TESO_Caja.CAJA_Serie = managerGenerarDocsVenta.ListVENT_PVentDocumento(0).PVDOCU_Serie
               End If
               Dim managerGenerarCancelacion As New BGenerarCancelacion(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
               _caja.TESO_Caja.TIPOS_CodTransaccion = ETipos.getTipoDePago(ETipos.TipoDePago.Efectivo)
               _caja.TESO_Caja.CAJA_Numero = managerGenerarCancelacion.getNroTransaccion(_caja.TESO_Caja.CAJA_Serie)
               _caja.TESO_Caja.CAJA_OrdenDocumento = 1
               _caja.TESO_Caja.CAJA_Fecha = m_tran_recibos.RECIB_Fecha
               _caja.TESO_Caja.CAJA_Codigo = String.Format("{0:00}{1}{2:0000000}", m_pvent_id, _caja.TESO_Caja.CAJA_Serie, _caja.TESO_Caja.CAJA_Numero)
               _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Recibo de Viaje Nro: {0} / ", m_tran_recibos.VIAJE_Id)
               If m_tran_recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.ACtaSueldo) Then
                  _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboEgreso)
                  _caja.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Salida)
                  _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Recibo A/Cta. de Sueldo. Viaje Nro: {0} / ", m_tran_recibos.VIAJE_Id)
               ElseIf m_tran_recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.Ingreso) Then
                  _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboIngreso)
                  _caja.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Entrada)
                  _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Recibo de Ingreso. Viaje Nro: {0} / ", m_tran_recibos.VIAJE_Id)
               ElseIf m_tran_recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.Egreso) Then
                  _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboEgreso)
                  _caja.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Salida)
                  _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Recibo de Egreso. Viaje Nro: {0} / ", m_tran_recibos.VIAJE_Id)
               End If
               _caja.TESO_Caja.CAJA_Importe = m_tran_recibos.RECIB_Monto

               _caja.TESO_Caja.CAJA_Estado = ETESO_Caja.getEstado(ETESO_Caja.Estado.Ingresado)
               _caja.TESO_Caja.ENTID_Codigo = x_entid_codigo
               _caja.TESO_Caja.CAJA_NroDocumento = m_tran_recibos.RECIB_Codigo
               _caja.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CGViajes)
               Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
               _caja.TESO_Caja.CAJA_Id = _caja.getCorrelativo("CAJA_Id", _whereCaja)
               If _caja.Guardar(x_usuario, New String() {"CAJA_Hora", "CAJA_FechaPago"}) Then
                  DAEnterprise.CommitTransaction()
                  Return True
               End If
            End If
         ElseIf m_tran_recibos.Modificado Then
            If Guardar(x_usuario) Then
               Dim _bteso_caja As New BTESO_Caja
               _bteso_caja.TESO_Caja = New ETESO_Caja
               _bteso_caja.TESO_Caja.Instanciar(ACEInstancia.Modificado)
               _bteso_caja.TESO_Caja.CAJA_Id = m_tran_recibos.CAJA_Id
               _bteso_caja.TESO_Caja.CAJA_Importe = m_tran_recibos.RECIB_Monto
               _bteso_caja.TESO_Caja.CAJA_Fecha = m_tran_recibos.RECIB_Fecha
               _bteso_caja.TESO_Caja.PVENT_Id = m_pvent_id
               If _bteso_caja.Guardar(x_usuario) Then
                  DAEnterprise.CommitTransaction()
                  Return True
               End If
            End If
         End If
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   Public Function ModificarImpFec(ByVal x_fecha As DateTime, ByVal x_importe As Decimal, ByVal x_usuario As String)
      Try
         Return d_tran_recibos.ModificarImpFec(m_tran_recibos, x_fecha, x_importe, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ModificarFecha(ByVal x_fecha As DateTime, ByVal x_usuario As String)
      Try
         Return d_tran_recibos.ModificarFecha(m_tran_recibos, x_fecha, x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: TRAN_ObtenerRecibo
   ' </summary>
   ' <param name="x_recib_codigo">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function TRAN_ObtenerRecibo(ByRef m_tran_recibos As ETRAN_Recibos, ByVal x_recib_codigo As String) As Boolean
      m_tran_recibos = New ETRAN_Recibos
      Try
         Return d_tran_recibos.TRAN_ObtenerRecibo(m_tran_recibos, x_recib_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class


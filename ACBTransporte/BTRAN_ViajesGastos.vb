Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration

Imports DAConexion
Imports ACFramework
Imports ACEVentas
Imports ACBVentas

Public Class BTRAN_ViajesGastos

#Region " Variables "
   Private m_zonas_codigo As String
   Private m_sucur_id As Integer
   Private m_pvent_id As Integer
   Private m_aplicacion As String
   Private m_periodo As String
#End Region

#Region " Constructores "
   Public Sub New(ByVal x_aplicacion As String, ByVal x_zona As String, ByVal x_sucursal As Integer, ByVal x_pvent_id As Integer, ByVal x_periodo As String)
      m_zonas_codigo = x_zona
      m_sucur_id = x_sucursal
      m_pvent_id = x_pvent_id
      m_aplicacion = x_aplicacion
      m_periodo = x_periodo
      d_tran_viajesgastos = New DTRAN_ViajesGastos()
   End Sub
#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function Guardar(ByVal x_usuario As String, ByVal x_documento As Boolean, ByVal x_entid_codigo As String, ByVal x_recib_codigopendiente As String, _
                           ByVal x_recib_codigo As String, ByVal x_caja_id As Long) As Boolean
      Dim m_btran_documentos As New BTRAN_Documentos()
      Try
         DAEnterprise.BeginTransaction()
         If m_tran_viajesgastos.Nuevo Then
            If x_documento Then
               m_btran_documentos.TRAN_Documentos = m_tran_viajesgastos.TRAN_Documentos
               m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2) _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Serie.Trim().PadLeft(3, "0") _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0"))
               m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_viajesgastos.ENTID_CodigoProveedor
               Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
               m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_viajesgastos.VGAST_Monto / (_igv + 1), 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_viajesgastos.VGAST_Monto / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_viajesgastos.VGAST_Monto
               m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_viajesgastos.TIPOS_CodTipoMoneda
               m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_viajesgastos.VGAST_Fecha
               m_btran_documentos.crearDocumento(m_tran_viajesgastos.VGAST_Descripcion)
               m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)

               Dim _where As New Hashtable()
               _where.Add("DOCUS_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.DOCUS_Codigo))
               _where.Add("ENTID_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.ENTID_Codigo))
               If m_btran_documentos.CargarTodos(_where) Then
                  Throw New Exception(String.Format("El Numero del documento {0}-{1}, ya existe para el proveedor: {2}{3}" _
                                                    , m_btran_documentos.TRAN_Documentos.DOCUS_Serie, m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0") _
                                                    , m_btran_documentos.TRAN_Documentos.ENTID_Codigo.Substring(1), vbNewLine))
               End If

               If m_btran_documentos.Guardar(x_usuario, True, False) Then
                  m_tran_viajesgastos.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
                  m_tran_viajesgastos.ENTID_CodigoProveedor = m_btran_documentos.TRAN_Documentos.ENTID_Codigo
                  m_tran_viajesgastos.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                  m_tran_viajesgastos.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                  m_tran_viajesgastos.VGAST_Estado = ETRAN_ViajesGastos.getEstado(ETRAN_ViajesGastos.Estado.Ingresado)
                  If Guardar(x_usuario) Then
                     '' Pagos
                     Dim _caja As New BTESO_Caja
                     _caja.TESO_Caja = New ETESO_Caja
                     _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
                     Dim managerTRAN_Recibos As New BTRAN_Recibos
                     managerTRAN_Recibos.TRAN_Recibos = New ETRAN_Recibos

                     _caja.TESO_Caja.PVENT_Id = m_pvent_id
                     _caja.TESO_Caja.TIPOS_CodTipoMoneda = m_tran_viajesgastos.TIPOS_CodTipoMoneda
                     _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.GastosViaje)
                     Dim managerGenerarDocsVenta As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)

                     If managerGenerarDocsVenta.GetSeries(m_aplicacion, m_zonas_codigo, m_sucur_id, m_pvent_id, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Caja)) Then
                        _caja.TESO_Caja.CAJA_Serie = managerGenerarDocsVenta.ListVENT_PVentDocumento(0).PVDOCU_Serie
                     End If
                     Dim managerGenerarCancelacion As New BGenerarCancelacion(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                     _caja.TESO_Caja.CAJA_Numero = managerGenerarCancelacion.getNroTransaccion(_caja.TESO_Caja.CAJA_Serie)
                     _caja.TESO_Caja.CAJA_OrdenDocumento = 1
                     _caja.TESO_Caja.CAJA_Fecha = m_tran_viajesgastos.VGAST_FechaViaje
                     _caja.TESO_Caja.CAJA_Importe = m_tran_viajesgastos.VGAST_Monto
                     _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Gasto del Viaje Nro: {0}", m_tran_viajesgastos.VIAJE_Id)
                     _caja.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Gasto)
                     _caja.TESO_Caja.CAJA_Estado = ETESO_Caja.getEstado(ETESO_Caja.Estado.Ingresado)
                     _caja.TESO_Caja.ENTID_Codigo = m_btran_documentos.TRAN_Documentos.ENTID_Codigo
                     _caja.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CGViajes)

                     Dim _serie As String = "001" : Dim _numero As Integer
                     If managerTRAN_Recibos.GetSeries(m_zonas_codigo, m_sucur_id, 0, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboTransporte)) Then
                        _serie = managerTRAN_Recibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                        _numero = managerTRAN_Recibos.getNumero(_serie, ETipos.getTipo(ETipos.TipoRecibo.ConDocumento)) + 1
                     End If
                     managerTRAN_Recibos.TRAN_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", ETipos.getTipo(ETipos.TipoRecibo.ConDocumento).Substring(3, 1).PadLeft(2, "0") _
                                                                                 , _serie, _numero)
                     _caja.TESO_Caja.CAJA_NroDocumento = managerTRAN_Recibos.TRAN_Recibos.RECIB_Codigo
                     _caja.TESO_Caja.CAJA_Codigo = String.Format("{0:00}{1}{2:0000000}", m_pvent_id, _caja.TESO_Caja.CAJA_Serie, _caja.TESO_Caja.CAJA_Numero)
                     Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
                     _caja.TESO_Caja.CAJA_Id = _caja.getCorrelativo("CAJA_Id", _whereCaja)
                     If _caja.Guardar(x_usuario, New String() {"CAJA_Hora", "CAJA_FechaPago"}) Then
                        managerTRAN_Recibos.TRAN_Recibos.Instanciar(ACEInstancia.Nuevo)
                        managerTRAN_Recibos.TRAN_Recibos.RECIB_Concepto = _caja.TESO_Caja.CAJA_Glosa
                        managerTRAN_Recibos.TRAN_Recibos.RECIB_Serie = _serie
                        managerTRAN_Recibos.TRAN_Recibos.VIAJE_Id = m_tran_viajesgastos.VIAJE_Id
                        managerTRAN_Recibos.TRAN_Recibos.RECIB_Numero = _numero
                        managerTRAN_Recibos.TRAN_Recibos.ZONAS_Codigo = m_zonas_codigo
                        managerTRAN_Recibos.TRAN_Recibos.SUCUR_Id = m_sucur_id
                        managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoMoneda = _caja.TESO_Caja.TIPOS_CodTipoMoneda
                        managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.ConDocumento)
                        managerTRAN_Recibos.TRAN_Recibos.RECIB_Fecha = _caja.TESO_Caja.CAJA_Fecha
                        managerTRAN_Recibos.TRAN_Recibos.RECIB_Monto = _caja.TESO_Caja.CAJA_Importe
                        managerTRAN_Recibos.TRAN_Recibos.RECIB_CodReferencia = m_tran_viajesgastos.VGAST_Id
                        managerTRAN_Recibos.TRAN_Recibos.RECIB_CodRecRef = x_recib_codigopendiente
                        managerTRAN_Recibos.TRAN_Recibos.VGAST_Id = m_tran_viajesgastos.VGAST_Id
                        If managerTRAN_Recibos.Guardar(x_usuario) Then
                           DAEnterprise.CommitTransaction()
                           Return True
                        Else
                           Throw New Exception("No se puede Guardar los recibos")
                        End If
                     End If
                  End If
               End If


            Else
               m_tran_viajesgastos.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
               m_tran_viajesgastos.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
               m_tran_viajesgastos.VGAST_Estado = ETRAN_ViajesGastos.getEstado(ETRAN_ViajesGastos.Estado.Ingresado)
               If Guardar(x_usuario) Then

                  '' Pagos
                  Dim _caja As New BTESO_Caja
                  _caja.TESO_Caja = New ETESO_Caja
                  _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
                  Dim managerTRAN_Recibos As New BTRAN_Recibos
                  managerTRAN_Recibos.TRAN_Recibos = New ETRAN_Recibos

                  _caja.TESO_Caja.PVENT_Id = m_pvent_id
                  _caja.TESO_Caja.TIPOS_CodTipoMoneda = m_tran_viajesgastos.TIPOS_CodTipoMoneda
                  _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.GastosViaje)

                  Dim managerGenerarDocsVenta As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)

                  If managerGenerarDocsVenta.GetSeries(m_aplicacion, m_zonas_codigo, m_sucur_id, m_pvent_id, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Caja)) Then
                     _caja.TESO_Caja.CAJA_Serie = managerGenerarDocsVenta.ListVENT_PVentDocumento(0).PVDOCU_Serie
                  End If
                  Dim managerGenerarCancelacion As New BGenerarCancelacion(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                  _caja.TESO_Caja.CAJA_Numero = managerGenerarCancelacion.getNroTransaccion(_caja.TESO_Caja.CAJA_Serie)
                  _caja.TESO_Caja.CAJA_OrdenDocumento = 1
                  _caja.TESO_Caja.CAJA_Fecha = m_tran_viajesgastos.VGAST_FechaViaje
                  _caja.TESO_Caja.CAJA_Importe = m_tran_viajesgastos.VGAST_Monto
                  _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Gasto del Viaje Nro: {0}", m_tran_viajesgastos.VIAJE_Id)
                  _caja.TESO_Caja.CAJA_Pase = ACEVentas.Constantes.GetPase(ACEVentas.Constantes.Pase.Gasto)
                  _caja.TESO_Caja.CAJA_Estado = ETESO_Caja.getEstado(ETESO_Caja.Estado.Ingresado)
                  _caja.TESO_Caja.ENTID_Codigo = x_entid_codigo
                  _caja.TESO_Caja.TIPOS_CodTipoOrigen = ETipos.getTipoOrigen(ETipos.OrigenCancelacion.CGViajes)

                  Dim _serie As String = "001" : Dim _numero As Integer
                  If managerTRAN_Recibos.GetSeries(m_zonas_codigo, m_sucur_id, 0, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.ReciboTransporte)) Then
                     _serie = managerTRAN_Recibos.ListVENT_PVentDocumento(0).PVDOCU_Serie
                     _numero = managerTRAN_Recibos.getNumero(_serie, ETipos.getTipo(ETipos.TipoRecibo.Gasto)) + 1
                  End If
                  managerTRAN_Recibos.TRAN_Recibos.RECIB_Codigo = String.Format("{0}{1}{2:0000000}", ETipos.getTipo(ETipos.TipoRecibo.Gasto).Substring(3, 1).PadLeft(2, "0") _
                                                                              , _serie, _numero)
                  _caja.TESO_Caja.CAJA_NroDocumento = managerTRAN_Recibos.TRAN_Recibos.RECIB_Codigo
                  _caja.TESO_Caja.CAJA_Codigo = String.Format("{0:00}{1}{2:0000000}", m_pvent_id, _caja.TESO_Caja.CAJA_Serie, _caja.TESO_Caja.CAJA_Numero)
                  Dim _whereCaja As New Hashtable : _whereCaja.Add("PVENT_Id", New ACWhere(_caja.TESO_Caja.PVENT_Id))
                  _caja.TESO_Caja.CAJA_Id = _caja.getCorrelativo("CAJA_Id", _whereCaja)
                  If _caja.Guardar(x_usuario, New String() {"CAJA_Hora", "CAJA_FechaPago"}) Then
                     managerTRAN_Recibos.TRAN_Recibos.Instanciar(ACEInstancia.Nuevo)
                     managerTRAN_Recibos.TRAN_Recibos.RECIB_Concepto = _caja.TESO_Caja.CAJA_Glosa
                     managerTRAN_Recibos.TRAN_Recibos.RECIB_Serie = _serie
                     managerTRAN_Recibos.TRAN_Recibos.VIAJE_Id = m_tran_viajesgastos.VIAJE_Id
                     managerTRAN_Recibos.TRAN_Recibos.RECIB_Numero = _numero
                     managerTRAN_Recibos.TRAN_Recibos.ZONAS_Codigo = m_zonas_codigo
                     managerTRAN_Recibos.TRAN_Recibos.SUCUR_Id = m_sucur_id
                     managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoMoneda = _caja.TESO_Caja.TIPOS_CodTipoMoneda
                     managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.Gasto)
                     managerTRAN_Recibos.TRAN_Recibos.RECIB_Fecha = _caja.TESO_Caja.CAJA_Fecha
                     managerTRAN_Recibos.TRAN_Recibos.RECIB_Monto = _caja.TESO_Caja.CAJA_Importe
                     managerTRAN_Recibos.TRAN_Recibos.RECIB_CodReferencia = m_tran_viajesgastos.VGAST_Id
                     managerTRAN_Recibos.TRAN_Recibos.RECIB_CodRecRef = x_recib_codigopendiente
                     managerTRAN_Recibos.TRAN_Recibos.VGAST_Id = m_tran_viajesgastos.VGAST_Id
                     If managerTRAN_Recibos.Guardar(x_usuario) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                     Else
                        Throw New Exception("No se puede Guardar los recibos")
                     End If
                  End If
               End If
            End If
         ElseIf m_tran_viajesgastos.Modificado Then
            If Guardar(x_usuario) Then
               If Not IsNothing(m_tran_viajesgastos.TRAN_Documentos) Then
                  m_btran_documentos.TRAN_Documentos = m_tran_viajesgastos.TRAN_Documentos
                  Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
                  m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_viajesgastos.VGAST_Monto / (_igv + 1), 2, MidpointRounding.AwayFromZero)
                  m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_viajesgastos.VGAST_Monto / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
                  m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_viajesgastos.VGAST_Monto
                  m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_viajesgastos.TIPOS_CodTipoMoneda
                  m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_viajesgastos.VGAST_Fecha
                  If m_btran_documentos.Guardar(x_usuario) Then
                     Dim _btran_recibos As New BTRAN_Recibos
                     _btran_recibos.TRAN_Recibos = New ETRAN_Recibos
                     _btran_recibos.TRAN_Recibos.Instanciar(ACEInstancia.Modificado)
                     _btran_recibos.TRAN_Recibos.RECIB_Codigo = x_recib_codigo
                     _btran_recibos.TRAN_Recibos.RECIB_Fecha = m_tran_viajesgastos.VGAST_FechaViaje
                     _btran_recibos.TRAN_Recibos.RECIB_Monto = m_tran_viajesgastos.VGAST_Monto
                     _btran_recibos.Guardar(x_usuario)

                     Dim _bteso_caja As New BTESO_Caja
                     _bteso_caja.TESO_Caja = New ETESO_Caja
                     _bteso_caja.TESO_Caja.Instanciar(ACEInstancia.Modificado)
                     _bteso_caja.TESO_Caja.CAJA_Id = x_caja_id
                     _bteso_caja.TESO_Caja.PVENT_Id = m_pvent_id
                     _bteso_caja.TESO_Caja.CAJA_Importe = m_tran_viajesgastos.VGAST_Monto
                     _bteso_caja.TESO_Caja.CAJA_Fecha = m_tran_viajesgastos.VGAST_FechaViaje
                     _bteso_caja.Guardar(x_usuario)

                     DAEnterprise.CommitTransaction()
                     Return True
                  End If
               Else
                  Dim _btran_recibos As New BTRAN_Recibos
                  _btran_recibos.TRAN_Recibos = New ETRAN_Recibos
                  _btran_recibos.TRAN_Recibos.Instanciar(ACEInstancia.Modificado)
                  _btran_recibos.TRAN_Recibos.RECIB_Codigo = x_recib_codigo
                  _btran_recibos.TRAN_Recibos.RECIB_Fecha = m_tran_viajesgastos.VGAST_FechaViaje
                  _btran_recibos.TRAN_Recibos.RECIB_Monto = m_tran_viajesgastos.VGAST_Monto
                  _btran_recibos.Guardar(x_usuario)

                  Dim _bteso_caja As New BTESO_Caja
                  _bteso_caja.TESO_Caja = New ETESO_Caja
                  _bteso_caja.TESO_Caja.Instanciar(ACEInstancia.Modificado)
                  _bteso_caja.TESO_Caja.CAJA_Id = x_caja_id
                  _bteso_caja.TESO_Caja.PVENT_Id = m_pvent_id
                  _bteso_caja.TESO_Caja.CAJA_Fecha = m_tran_viajesgastos.VGAST_FechaViaje
                  _bteso_caja.TESO_Caja.CAJA_Importe = m_tran_viajesgastos.VGAST_Monto
                  _bteso_caja.Guardar(x_usuario)

                  DAEnterprise.CommitTransaction()
                  DAEnterprise.CommitTransaction()
                  Return True
               End If
            End If
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   Public Function GastosViaje(ByVal x_viaje_id As Integer) As Boolean
      Dim _where As New Hashtable()
      Try
         _where.Add("VIAJE_Id", New ACWhere(x_viaje_id))
         m_listTRAN_ViajesGastos = New List(Of ETRAN_ViajesGastos)
         Return d_tran_viajesgastos.GetGastosViaje(m_listTRAN_ViajesGastos, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Procedimiento "TRAN_CAJASS_GastosViajeVerificados" por el Generador 02/04/2012
   ' </summary> 
   ' <param name="x_viaje_id">Parametro 1: </param> 
   ' <returns>Si no hay registros devuelve Falso</returns> 
   ' <remarks></remarks> 
   Public Function GastosViajeVerificados(ByVal x_viaje_id As Long) As Boolean
      Dim m_dtran_viajesgastos As New DTRAN_ViajesGastos()
      m_listTRAN_ViajesGastos = New List(Of ETRAN_ViajesGastos)
      Try
         Return m_dtran_viajesgastos.TRAN_CAJASS_GastosViajeVerificados(m_listTRAN_ViajesGastos, x_viaje_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Cargar(ByVal x_viaje_id As Long, ByVal x_vgast_id As Long, ByVal x_detalle As Boolean) As Boolean
      Dim _join As New List(Of ACJoin)
      Dim _where As New Hashtable
      Try
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Left, _
                              New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")}, _
                              New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocumento")}))
         _where.Add("VIAJE_Id", New ACWhere(x_viaje_id))
         _where.Add("VGAST_Id", New ACWhere(x_vgast_id))
         If Cargar(_join, _where) Then
            Dim _documento As New BTRAN_Documentos
            If _documento.Cargar(m_tran_viajesgastos.DOCUS_Codigo, m_tran_viajesgastos.ENTID_CodigoProveedor) Then
               m_tran_viajesgastos.TRAN_Documentos = _documento.TRAN_Documentos
               Return True
            End If
            Return True
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ' <summary> 
   ' Capa de Negocio: TRAN_VIAJSS_GenerarRecibos
   ' </summary>
   ' <param name="x_viaje_id">Parametro 1: </param> 
   ' <returns></returns> 
   ' <remarks></remarks> 
   Public Function GenerarRecibos(ByVal x_viaje_id As Long) As Boolean
      m_listTRAN_ViajesGastos = New List(Of ETRAN_ViajesGastos)
      Try
         Return d_tran_viajesgastos.TRAN_VIAJSS_GenerarRecibos(m_listTRAN_ViajesGastos, x_viaje_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class



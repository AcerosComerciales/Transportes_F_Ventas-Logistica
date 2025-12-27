Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte
Imports System.Configuration
Imports ACBVentas
Imports ACEVentas

Imports DAConexion
Imports ACFramework

Public Class BTRAN_CombustibleConsumo

#Region " Variables "
    Private m_dtReportes As DataTable
    Private m_dtReportes_com As DataTable
    Private m_dtReportes_com_pro As DataTable
    Private m_dtReportes_com_val As DataTable
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
      d_tran_combustibleconsumo = New DTRAN_CombustibleConsumo()
   End Sub
#End Region

#Region " Propiedades "

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
    Public Property DTTabla() As DataTable
      Get
         Return m_dtReportes
      End Get
      Set(ByVal value As DataTable)
         m_dtReportes = value
      End Set
    End Property
       Public Property DTTabla_com() As DataTable
      Get
         Return m_dtReportes_com
      End Get
      Set(ByVal value As DataTable)
         m_dtReportes_com = value
      End Set
    End Property
Public Property DTTabla_com_pro() As DataTable
      Get
         Return m_dtReportes_com_pro
      End Get
      Set(ByVal value As DataTable)
         m_dtReportes_com_pro = value
      End Set
    End Property    

     Public Property DTTabla_com_val() As DataTable
      Get
         Return m_dtReportes_com_val
      End Get
      Set(ByVal value As DataTable)
         m_dtReportes_com_val = value
      End Set
    End Property
    Public Function AnularRegistro(ByVal x_estado As String, ByVal x_usuario As String) As Boolean
        Try
            Return d_tran_combustibleconsumo.AnularRegistro(m_tran_combustibleconsumo.COMCO_Id, x_estado, x_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function





    Public Function ELiminarConsumoADBLue(ByVal x_viaje_id As Long, ByVal x_comco_id As Long) As Boolean
        Try
            'no es necesario eliminar por id del consumo ya que si se elimina se elimina todos los consumos asiciados al viaje
            DAEnterprise.AsignarProcedure("TRAN_VIAJESS_EliminarConsumo")
            DAEnterprise.AgregarParametro("@VIaje_id", x_viaje_id)
            DAEnterprise.AgregarParametro("@COMCO_ID", x_comco_id)
            Return DAEnterprise.ExecuteNonQuery() > 0


        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' 
    ' </summary>
    ' <>
    '  name="x_usuario"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function GuardarConsumo_mod(ByVal x_usuario As String) As Boolean
      Dim m_btran_documentos As New BTRAN_Documentos()
      Try
         m_tran_combustibleconsumo.COMCO_CCaja = False
         m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)
         DAEnterprise.BeginTransaction()
         If m_tran_combustibleconsumo.Nuevo Then
            m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
            If m_btran_documentos.TRAN_Documentos.DOCUS_Numero > 0 Then
               m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
               m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_combustibleconsumo.ENTID_CodigoProveedor
               Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
               m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
               m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
               m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha
               'm_btran_documentos.crearDocumento(m_tran_combustibleconsumo.COMCO_Descripcion)
               m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)

               Dim _where As New Hashtable()
               _where.Add("DOCUS_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.DOCUS_Codigo))
               _where.Add("ENTID_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.ENTID_Codigo))
               If m_btran_documentos.CargarTodos(_where) Then
                  'Throw New Exception(String.Format("El Numero del documento {0}-{1}, ya existe para el proveedor: {2}{3}" _
                  '                                  , m_btran_documentos.TRAN_Documentos.DOCUS_Serie, m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0") _
                  '                                  , m_btran_documentos.TRAN_Documentos.ENTID_Codigo.Substring(1), vbNewLine))
               End If
               'm_btran_documentos.Guardar(x_usuario, True, False)
            End If
                DAEnterprise.CommitTransaction()
            m_tran_combustibleconsumo.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
            m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
            m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
            If Guardar(x_usuario) Then
               DAEnterprise.CommitTransaction()
               Return True
            Else
               Throw New Exception("No se puede Guardar los recibos")
            End If

         ElseIf m_tran_combustibleconsumo.Modificado Then

            If Guardar(x_usuario) Then
               DAEnterprise.CommitTransaction()
               Return True
            Else
               Throw New Exception("No se puede Guardar los recibos")
            End If
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function
   Public Function GuardarConsumo(ByVal x_usuario As String) As Boolean
      Dim m_btran_documentos As New BTRAN_Documentos()
      Try
         m_tran_combustibleconsumo.COMCO_CCaja = False
         m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)
         DAEnterprise.BeginTransaction()
         If m_tran_combustibleconsumo.Nuevo Then
            m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
            If m_btran_documentos.TRAN_Documentos.DOCUS_Numero > 0 Then
               m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2) _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Serie.Trim().PadLeft(5, "0") _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(8, "0"))
               m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_combustibleconsumo.ENTID_CodigoProveedor
               Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
               m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
               m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
               m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
               m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha
               m_btran_documentos.crearDocumento(m_tran_combustibleconsumo.COMCO_Descripcion)
               m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)

               Dim _where As New Hashtable()
               _where.Add("DOCUS_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.DOCUS_Codigo))
               _where.Add("ENTID_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.ENTID_Codigo))
               If m_btran_documentos.CargarTodos(_where) Then
                  Throw New Exception(String.Format("El Numero del documento {0}-{1}, ya existe para el proveedor: {2}{3}" _
                                                    , m_btran_documentos.TRAN_Documentos.DOCUS_Serie, m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0") _
                                                    , m_btran_documentos.TRAN_Documentos.ENTID_Codigo.Substring(1), vbNewLine))
               End If
               m_btran_documentos.Guardar(x_usuario, True, False)
            End If
                DAEnterprise.CommitTransaction()
            m_tran_combustibleconsumo.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
            m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
            m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
            If Guardar(x_usuario) Then
               DAEnterprise.CommitTransaction()
               Return True
            Else
               Throw New Exception("No se puede Guardar los recibos")
            End If

         ElseIf m_tran_combustibleconsumo.Modificado Then

            If Guardar(x_usuario) Then
               DAEnterprise.CommitTransaction()
               Return True
            Else
               Throw New Exception("No se puede Guardar los recibos")
            End If
         End If
         DAEnterprise.RollBackTransaction()
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

    ' <summary>
    ' guardar solo documento _a
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <param name="x_documento"></param>
    ' <param name="x_recib_codigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function Guardar_doc(ByVal x_usuario As String, ByVal x_documento As Boolean, ByVal x_recib_codigo As String,
                                 ByVal LIST As List(Of ETRAN_DocumentosDetalle)) As Boolean
        Dim m_btran_documentos As New BTRAN_Documentos()
        'm_tran_combustibleconsumo = New ETRAN_CombustibleConsumo()
        'm_tran_combustibleconsumo.Instanciar(ACEInstancia.Nuevo)

        Try
            DAEnterprise.BeginTransaction()
            If m_tran_combustibleconsumo.Nuevo Then
                If x_documento Then
                    m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
                    m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2) _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Serie.Trim().PadLeft(5, "0") _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(8, "0"))
                    m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_combustibleconsumo.ENTID_CodigoProveedor
                    Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
                    m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
                    m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                    m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha
                    'm_btran_documentos.crearDocumento(m_tran_combustibleconsumo.COMCO_Descripcion)
                    m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)

                    Dim _where As New Hashtable()
                    _where.Add("DOCUS_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.DOCUS_Codigo))
                    _where.Add("ENTID_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.ENTID_Codigo))
                    If m_btran_documentos.CargarTodos(_where) Then

                        Throw New Exception(String.Format("El Numero del documento {0}-{1}, ya existe para el proveedor: {2}{3}" _
                                                    , m_btran_documentos.TRAN_Documentos.DOCUS_Serie, m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0") _
                                                    , m_btran_documentos.TRAN_Documentos.ENTID_Codigo.Substring(1), vbNewLine))

                    End If

                    If m_btran_documentos.Guardar_det(LIST, x_usuario, True, False) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                    End If
                Else
                    m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                    m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                    m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)

                End If
            ElseIf m_tran_combustibleconsumo.Modificado Then

                If m_btran_documentos.Guardar(x_usuario) Then

                    DAEnterprise.CommitTransaction()
                    Return True
                End If
            Else
                Return True
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function
    ' <summary>
    ' ''
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <param name="x_documento"></param>
    ' <param name="x_recib_codigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function Guardar_todo(ByVal x_usuario As String, ByVal x_documento As Boolean, ByVal x_recib_codigo As String) As Boolean
        Dim m_btran_documentos As New BTRAN_Documentos()
        Try
            DAEnterprise.BeginTransaction()
            If m_tran_combustibleconsumo.Nuevo Then
                If x_documento Then
                    m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
                    m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo

                    m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_combustibleconsumo.ENTID_CodigoProveedor
                    Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
                    m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
                    m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                    m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha
                    'm_btran_documentos.crearDocumento(m_tran_combustibleconsumo.COMCO_Descripcion)
                    m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)

                    Dim _where As New Hashtable()
                    _where.Add("DOCUS_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.DOCUS_Codigo))
                    _where.Add("ENTID_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.ENTID_Codigo))
                    If m_btran_documentos.CargarTodos(_where) Then



                        'Throw New Exception(String.Format("El Numero del documento {0}-{1}, ya existe para el proveedor: {2}{3}" _
                        '                                  , m_btran_documentos.TRAN_Documentos.DOCUS_Serie, m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0") _
                        '                                  , m_btran_documentos.TRAN_Documentos.ENTID_Codigo.Substring(1), vbNewLine))



                        ' If m_btran_documentos.Guardar(x_usuario, True, False) Then'' SE QUITA EL DOCUMENTO SOLO GUARDA CONSUMO COMBUSTIBLE
                        m_tran_combustibleconsumo.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
                        m_tran_combustibleconsumo.ENTID_CodigoProveedor = m_btran_documentos.TRAN_Documentos.ENTID_Codigo
                        m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                        m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                        m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)
                        If Guardar(x_usuario) Then
                            '' Pagos
                            Dim _caja As New BTESO_Caja
                            _caja.TESO_Caja = New ETESO_Caja
                            _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
                            Dim managerTRAN_Recibos As New BTRAN_Recibos
                            managerTRAN_Recibos.TRAN_Recibos = New ETRAN_Recibos

                            _caja.TESO_Caja.PVENT_Id = m_pvent_id
                            _caja.TESO_Caja.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                            _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.GastosViaje)
                            Dim managerGenerarDocsVenta As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)

                            If managerGenerarDocsVenta.GetSeries(m_aplicacion, m_zonas_codigo, m_sucur_id, m_pvent_id, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Caja)) Then
                                _caja.TESO_Caja.CAJA_Serie = managerGenerarDocsVenta.ListVENT_PVentDocumento(0).PVDOCU_Serie
                            End If
                            Dim managerGenerarCancelacion As New BGenerarCancelacion(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                            _caja.TESO_Caja.CAJA_Numero = managerGenerarCancelacion.getNroTransaccion(_caja.TESO_Caja.CAJA_Serie)
                            _caja.TESO_Caja.CAJA_OrdenDocumento = 1
                            _caja.TESO_Caja.CAJA_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                            _caja.TESO_Caja.CAJA_Importe = m_tran_combustibleconsumo.COMCO_Total
                            _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Consumo de Combustible del Viaje Nro: {0}", m_tran_combustibleconsumo.VIAJE_Id)
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
                                managerTRAN_Recibos.TRAN_Recibos.VIAJE_Id = m_tran_combustibleconsumo.VIAJE_Id
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Numero = _numero
                                managerTRAN_Recibos.TRAN_Recibos.ZONAS_Codigo = m_zonas_codigo
                                managerTRAN_Recibos.TRAN_Recibos.SUCUR_Id = m_sucur_id
                                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoMoneda = _caja.TESO_Caja.TIPOS_CodTipoMoneda
                                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.ConDocumento)
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Fecha = _caja.TESO_Caja.CAJA_Fecha
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Monto = _caja.TESO_Caja.CAJA_Importe
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_CodReferencia = m_tran_combustibleconsumo.COMCO_Id
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_CodRecRef = x_recib_codigo
                                If managerTRAN_Recibos.Guardar(x_usuario) Then
                                    DAEnterprise.CommitTransaction()
                                    Return True
                                Else
                                    Throw New Exception("No se puede Guardar los recibos")
                                End If
                            End If
                        End If
                        ''End If '' SE QUITA EL DOCUMENTO SOLO GUARDA CONSUMO COMBUSTIBLE
                    End If

                Else
                    m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                    m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                    m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)
                    If Guardar(x_usuario) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                    End If
                End If
            ElseIf m_tran_combustibleconsumo.Modificado Then
                If Guardar(x_usuario) Then
                    m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
                    m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
                    Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
                    m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                    m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha

                    If m_btran_documentos.Guardar(x_usuario) Then
                        Dim _btran_recibos As New BTRAN_Recibos
                        _btran_recibos.TRAN_Recibos = New ETRAN_Recibos
                        _btran_recibos.TRAN_Recibos.Instanciar(ACEInstancia.Modificado)
                        _btran_recibos.TRAN_Recibos.RECIB_Codigo = m_tran_combustibleconsumo.RECIB_Codigo
                        _btran_recibos.TRAN_Recibos.RECIB_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                        If _btran_recibos.Guardar(x_usuario) Then
                            Dim _bteso_caja As New BTESO_Caja
                            _bteso_caja.TESO_Caja = New ETESO_Caja
                            _bteso_caja.TESO_Caja.Instanciar(ACEInstancia.Modificado)
                            _bteso_caja.TESO_Caja.CAJA_Id = m_tran_combustibleconsumo.CAJA_Id
                            _bteso_caja.TESO_Caja.PVENT_Id = m_pvent_id
                            _bteso_caja.TESO_Caja.CAJA_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                            _bteso_caja.TESO_Caja.CAJA_Importe = m_tran_combustibleconsumo.COMCO_Total

                            If _bteso_caja.Guardar(x_usuario) Then
                                DAEnterprise.CommitTransaction()
                                Return True
                            End If
                        End If
                    End If
                End If
            Else
                Return True
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary>
    ' ''
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <param name="x_documento"></param>
    ' <param name="x_recib_codigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>

    Public Function GuardarCCAdBlue(ByVal x_usuario As String, ByVal x_documento As Boolean, ByVal x_recib_codigo As String,
                                    ByVal x_ccaja As Boolean) As Boolean
        Dim m_btran_documentos As New BTRAN_Documentos()
        Try
            DAEnterprise.BeginTransaction()
            If m_tran_combustibleconsumo.Nuevo Then
                If x_documento Then
                    m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
                    m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2) _
                                                                                    , m_btran_documentos.TRAN_Documentos.DOCUS_Serie.Trim().PadLeft(5, "0") _
                                                                                    , m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(8, "0"))
                    m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_combustibleconsumo.ENTID_CodigoProveedor
                    Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
                    m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
                    m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = ETipos.getTipoComprobante(ETipos.TipoMoneda.Soles) 'm_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                    m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha
                    m_btran_documentos.crearDocumento(m_tran_combustibleconsumo.COMCO_Descripcion)
                    m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)

                    ' m_btran_documentos.TRAN_Documentos.TIPOS_CodTiposCombustible = 


                    Dim _where As New Hashtable()
                    _where.Add("DOCUS_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.DOCUS_Codigo))
                    _where.Add("ENTID_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.ENTID_Codigo))
                    If m_btran_documentos.CargarTodos(_where) Then



                        Throw New Exception(String.Format("El Numero del documento {0}-{1}, ya existe para el proveedor: {2}{3}" _
                                                          , m_btran_documentos.TRAN_Documentos.DOCUS_Serie, m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0") _
                                                          , m_btran_documentos.TRAN_Documentos.ENTID_Codigo.Substring(1), vbNewLine))
                        'Return False

                    End If

                    If m_btran_documentos.Guardar(x_usuario, True, False) Then '' SE QUITA EL DOCUMENTO SOLO GUARDA CONSUMO COMBUSTIBLE
                        m_tran_combustibleconsumo.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
                        m_tran_combustibleconsumo.ENTID_CodigoProveedor = m_btran_documentos.TRAN_Documentos.ENTID_Codigo
                        m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                        m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                        m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)
                        If Guardar(x_usuario) Then
                            '' Pagos
                            Dim _caja As New BTESO_Caja
                            _caja.TESO_Caja = New ETESO_Caja
                            _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
                            Dim managerTRAN_Recibos As New BTRAN_Recibos
                            managerTRAN_Recibos.TRAN_Recibos = New ETRAN_Recibos

                            _caja.TESO_Caja.PVENT_Id = m_pvent_id
                            _caja.TESO_Caja.TIPOS_CodTipoMoneda = ETipos.getTipoComprobante(ETipos.TipoMoneda.Soles) 'm_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                            _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.GastosViaje)
                            Dim managerGenerarDocsVenta As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)

                            If managerGenerarDocsVenta.GetSeries(m_aplicacion, m_zonas_codigo, m_sucur_id, m_pvent_id, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Caja)) Then
                                _caja.TESO_Caja.CAJA_Serie = managerGenerarDocsVenta.ListVENT_PVentDocumento(0).PVDOCU_Serie
                            End If
                            Dim managerGenerarCancelacion As New BGenerarCancelacion(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                            _caja.TESO_Caja.CAJA_Numero = managerGenerarCancelacion.getNroTransaccion(_caja.TESO_Caja.CAJA_Serie)
                            _caja.TESO_Caja.CAJA_OrdenDocumento = 1
                            _caja.TESO_Caja.CAJA_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                            _caja.TESO_Caja.CAJA_Importe = m_tran_combustibleconsumo.COMCO_Total
                            _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Consumo de Combustible del Viaje Nro: {0}", m_tran_combustibleconsumo.VIAJE_Id)
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
                                managerTRAN_Recibos.TRAN_Recibos.VIAJE_Id = m_tran_combustibleconsumo.VIAJE_Id
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Numero = _numero
                                managerTRAN_Recibos.TRAN_Recibos.ZONAS_Codigo = m_zonas_codigo
                                managerTRAN_Recibos.TRAN_Recibos.SUCUR_Id = m_sucur_id
                                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoMoneda = _caja.TESO_Caja.TIPOS_CodTipoMoneda
                                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.ConDocumento)
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Fecha = _caja.TESO_Caja.CAJA_Fecha
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Monto = _caja.TESO_Caja.CAJA_Importe
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_CodReferencia = m_tran_combustibleconsumo.COMCO_Id
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_CodRecRef = x_recib_codigo
                                If managerTRAN_Recibos.Guardar(x_usuario) Then
                                    DAEnterprise.CommitTransaction()
                                    Return True
                                Else
                                    Throw New Exception("No se puede Guardar los recibos")
                                End If
                            End If
                        End If
                    End If '' SE QUITA EL DOCUMENTO SOLO GUARDA CONSUMO COMBUSTIBLE
                Else
                    m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                    m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                    m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)
                    If Guardar(x_usuario) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                    End If
                End If
            ElseIf m_tran_combustibleconsumo.Modificado Then
                If Guardar(x_usuario) Then
                    m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
                    m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
                    Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
                    m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                    m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha

                    If m_btran_documentos.Guardar(x_usuario) Then
                        Dim _btran_recibos As New BTRAN_Recibos
                        _btran_recibos.TRAN_Recibos = New ETRAN_Recibos
                        _btran_recibos.TRAN_Recibos.Instanciar(ACEInstancia.Modificado)
                        _btran_recibos.TRAN_Recibos.RECIB_Codigo = m_tran_combustibleconsumo.RECIB_Codigo
                        _btran_recibos.TRAN_Recibos.RECIB_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                        If _btran_recibos.Guardar(x_usuario) Then
                            Dim _bteso_caja As New BTESO_Caja
                            _bteso_caja.TESO_Caja = New ETESO_Caja
                            _bteso_caja.TESO_Caja.Instanciar(ACEInstancia.Modificado)
                            _bteso_caja.TESO_Caja.CAJA_Id = m_tran_combustibleconsumo.CAJA_Id
                            _bteso_caja.TESO_Caja.PVENT_Id = m_pvent_id
                            _bteso_caja.TESO_Caja.CAJA_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                            _bteso_caja.TESO_Caja.CAJA_Importe = m_tran_combustibleconsumo.COMCO_Total

                            If _bteso_caja.Guardar(x_usuario) Then
                                DAEnterprise.CommitTransaction()
                                Return True
                            End If
                        End If
                    End If
                End If
            Else
                Return True
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function


    ' <summary>
    ' '
    ' </summary>
    ' <param name="x_usuario"></param>
    ' <param name="x_documento"></param>
    ' <param name="x_recib_codigo"></param>
    ' <returns></returns>
    ' <remarks></remarks>

    Public Function Guardar(ByVal x_usuario As String, ByVal x_documento As Boolean, ByVal x_recib_codigo As String) As Boolean
        Dim m_btran_documentos As New BTRAN_Documentos()
        Try
            DAEnterprise.BeginTransaction()
            If m_tran_combustibleconsumo.Nuevo Then
                If x_documento Then
                    m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
                    m_btran_documentos.TRAN_Documentos.DOCUS_Codigo = String.Format("{0}{1}{2}", m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoDocumento.Substring(3, 2) _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Serie.Trim().PadLeft(5, "0") _
                                                                               , m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(8, "0"))
                    m_btran_documentos.TRAN_Documentos.ENTID_Codigo = m_tran_combustibleconsumo.ENTID_CodigoProveedor
                    Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
                    m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
                    m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                    m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha
                    m_btran_documentos.crearDocumento(m_tran_combustibleconsumo.COMCO_Descripcion)
                    m_btran_documentos.TRAN_Documentos.Instanciar(ACEInstancia.Nuevo)

                    Dim _where As New Hashtable()
                    _where.Add("DOCUS_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.DOCUS_Codigo))
                    _where.Add("ENTID_Codigo", New ACWhere(m_btran_documentos.TRAN_Documentos.ENTID_Codigo))
                    If m_btran_documentos.CargarTodos(_where) Then



                        Throw New Exception(String.Format("El Numero del documento {0}-{1}, ya existe para el proveedor: {2}{3}" _
                                                    , m_btran_documentos.TRAN_Documentos.DOCUS_Serie, m_btran_documentos.TRAN_Documentos.DOCUS_Numero.ToString().PadLeft(7, "0") _
                                                    , m_btran_documentos.TRAN_Documentos.ENTID_Codigo.Substring(1), vbNewLine))
                        'Return False

                    End If

                    If m_btran_documentos.Guardar(x_usuario, True, False) Then '' SE QUITA EL DOCUMENTO SOLO GUARDA CONSUMO COMBUSTIBLE
                        m_tran_combustibleconsumo.DOCUS_Codigo = m_btran_documentos.TRAN_Documentos.DOCUS_Codigo
                        m_tran_combustibleconsumo.ENTID_CodigoProveedor = m_btran_documentos.TRAN_Documentos.ENTID_Codigo
                        m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                        m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                        m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)
                        If Guardar(x_usuario) Then
                            '' Pagos
                            Dim _caja As New BTESO_Caja
                            _caja.TESO_Caja = New ETESO_Caja
                            _caja.TESO_Caja.Instanciar(ACEInstancia.Nuevo)
                            Dim managerTRAN_Recibos As New BTRAN_Recibos
                            managerTRAN_Recibos.TRAN_Recibos = New ETRAN_Recibos

                            _caja.TESO_Caja.PVENT_Id = m_pvent_id
                            _caja.TESO_Caja.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                            _caja.TESO_Caja.TIPOS_CodTipoDocumento = ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.GastosViaje)
                            Dim managerGenerarDocsVenta As New BGenerarDocsVenta(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)

                            If managerGenerarDocsVenta.GetSeries(m_aplicacion, m_zonas_codigo, m_sucur_id, m_pvent_id, ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Caja)) Then
                                _caja.TESO_Caja.CAJA_Serie = managerGenerarDocsVenta.ListVENT_PVentDocumento(0).PVDOCU_Serie
                            End If
                            Dim managerGenerarCancelacion As New BGenerarCancelacion(m_pvent_id, m_periodo, m_zonas_codigo, m_sucur_id)
                            _caja.TESO_Caja.CAJA_Numero = managerGenerarCancelacion.getNroTransaccion(_caja.TESO_Caja.CAJA_Serie)
                            _caja.TESO_Caja.CAJA_OrdenDocumento = 1
                            _caja.TESO_Caja.CAJA_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                            _caja.TESO_Caja.CAJA_Importe = m_tran_combustibleconsumo.COMCO_Total
                            _caja.TESO_Caja.CAJA_Glosa = String.Format("Registro de Consumo de Combustible del Viaje Nro: {0}", m_tran_combustibleconsumo.VIAJE_Id)
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
                                managerTRAN_Recibos.TRAN_Recibos.VIAJE_Id = m_tran_combustibleconsumo.VIAJE_Id
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Numero = _numero
                                managerTRAN_Recibos.TRAN_Recibos.ZONAS_Codigo = m_zonas_codigo
                                managerTRAN_Recibos.TRAN_Recibos.SUCUR_Id = m_sucur_id
                                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoMoneda = _caja.TESO_Caja.TIPOS_CodTipoMoneda
                                managerTRAN_Recibos.TRAN_Recibos.TIPOS_CodTipoRecibo = ETipos.getTipo(ETipos.TipoRecibo.ConDocumento)
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Fecha = _caja.TESO_Caja.CAJA_Fecha
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_Monto = _caja.TESO_Caja.CAJA_Importe
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_CodReferencia = m_tran_combustibleconsumo.COMCO_Id
                                managerTRAN_Recibos.TRAN_Recibos.RECIB_CodRecRef = x_recib_codigo
                                If managerTRAN_Recibos.Guardar(x_usuario) Then
                                    DAEnterprise.CommitTransaction()
                                    Return True
                                Else
                                    Throw New Exception("No se puede Guardar los recibos")
                                End If
                            End If
                        End If
                    End If '' SE QUITA EL DOCUMENTO SOLO GUARDA CONSUMO COMBUSTIBLE
                Else
                    m_tran_combustibleconsumo.ZONAS_Codigo = ACBVentas.BConstantes.ZONAS_Codigo
                    m_tran_combustibleconsumo.SUCUR_Id = ACBVentas.BConstantes.SUCUR_Id
                    m_tran_combustibleconsumo.COMCO_Estado = ETRAN_CombustibleConsumo.getEstado(ETRAN_CombustibleConsumo.Estado.Ingresado)
                    If Guardar(x_usuario) Then
                        DAEnterprise.CommitTransaction()
                        Return True
                    End If
                End If
            ElseIf m_tran_combustibleconsumo.Modificado Then
                If Guardar(x_usuario) Then
                    m_btran_documentos.TRAN_Documentos = m_tran_combustibleconsumo.TRAN_Documentos
                    m_btran_documentos.TRAN_Documentos.DOCUS_TotalPago = m_tran_combustibleconsumo.COMCO_Total
                    Dim _igv As Decimal = (ACETransporte.Constantes.Porcentaje_IGV) / 100
                    m_btran_documentos.TRAN_Documentos.DOCUS_Importe = Math.Round(m_tran_combustibleconsumo.COMCO_Total / (_igv + 1), 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.DOCUS_ImporteIGV = Math.Round((m_tran_combustibleconsumo.COMCO_Total / (_igv + 1)) * _igv, 2, MidpointRounding.AwayFromZero)
                    m_btran_documentos.TRAN_Documentos.TIPOS_CodTipoMoneda = m_tran_combustibleconsumo.TIPOS_CodTipoMoneda
                    m_btran_documentos.TRAN_Documentos.DOCUS_Fecha = m_tran_combustibleconsumo.COMCO_Fecha

                    If m_btran_documentos.Guardar(x_usuario) Then
                        Dim _btran_recibos As New BTRAN_Recibos
                        _btran_recibos.TRAN_Recibos = New ETRAN_Recibos
                        _btran_recibos.TRAN_Recibos.Instanciar(ACEInstancia.Modificado)
                        _btran_recibos.TRAN_Recibos.RECIB_Codigo = m_tran_combustibleconsumo.RECIB_Codigo
                        _btran_recibos.TRAN_Recibos.RECIB_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                        If _btran_recibos.Guardar(x_usuario) Then
                            Dim _bteso_caja As New BTESO_Caja
                            _bteso_caja.TESO_Caja = New ETESO_Caja
                            _bteso_caja.TESO_Caja.Instanciar(ACEInstancia.Modificado)
                            _bteso_caja.TESO_Caja.CAJA_Id = m_tran_combustibleconsumo.CAJA_Id
                            _bteso_caja.TESO_Caja.PVENT_Id = m_pvent_id
                            _bteso_caja.TESO_Caja.CAJA_Fecha = m_tran_combustibleconsumo.COMCO_FechaViaje
                            _bteso_caja.TESO_Caja.CAJA_Importe = m_tran_combustibleconsumo.COMCO_Total

                            If _bteso_caja.Guardar(x_usuario) Then
                                DAEnterprise.CommitTransaction()
                                Return True
                            End If
                        End If
                    End If
                End If
            Else
                Return True
            End If
            DAEnterprise.RollBackTransaction()
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: TRAN_COMCOSS_ObtConCombustible
    ' </summary>
    ' <param name="x_comco_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ObtConCombustible(ByVal x_comco_id As Long) As Boolean
        m_tran_combustibleconsumo = New ETRAN_CombustibleConsumo
        Try
            If d_tran_combustibleconsumo.TRAN_COMCOSS_ObtConCombustible(m_tran_combustibleconsumo, x_comco_id) Then
                Dim _documento As New BTRAN_Documentos
                If Not IsNothing(m_tran_combustibleconsumo.DOCUS_Codigo) Then
                    If _documento.Cargar(m_tran_combustibleconsumo.DOCUS_Codigo, m_tran_combustibleconsumo.ENTID_CodigoProveedor) Then
                        m_tran_combustibleconsumo.TRAN_Documentos = _documento.TRAN_Documentos
                        Return True
                    End If
                End If
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: TRAN_ConsumoCombustible
    ' </summary>
    '<param name="x_recib_codigo">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function TRAN_ObtenerConsumoAdBlue(ByRef m_tran_combustibleconsumo As ETRAN_CombustibleConsumo, ByVal x_comco_id As Long) As Boolean
        m_tran_combustibleconsumo = New ETRAN_CombustibleConsumo
        Try
            Return d_tran_combustibleconsumo.TRAN_ObtenerConsumoAdBlue(m_tran_combustibleconsumo, x_comco_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cargar(ByVal x_comco_id As Long, ByVal x_detalle As Boolean) As Boolean
        Dim _join As New List(Of ACJoin)
        Dim _where As New Hashtable
        Try
            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner,
                              New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")},
                              New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocProveedor")}))
            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Cond", ACJoin.TipoJoin.Left,
                          New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoConductor")},
                          New ACCampos() {New ACCampos("ENTID_RazonSocial", "Conductor"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocConductor")}))
            _join.Add(New ACJoin(ETRAN_Vehiculos.Esquema, ETRAN_Vehiculos.Tabla, "Vehic", ACJoin.TipoJoin.Inner,
                       New ACCampos() {New ACCampos("VEHIC_Id", "VEHIC_Id")},
                       New ACCampos() {New ACCampos("VEHIC_Placa", "VEHIC_Placa")}))
            _where.Add("COMCO_Id", New ACWhere(x_comco_id))
            If Cargar(_join, _where) Then
                Dim _documento As New BTRAN_Documentos
                If Not IsNothing(m_tran_combustibleconsumo.DOCUS_Codigo) Then
                    If _documento.Cargar(m_tran_combustibleconsumo.DOCUS_Codigo, m_tran_combustibleconsumo.ENTID_CodigoProveedor) Then
                        m_tran_combustibleconsumo.TRAN_Documentos = _documento.TRAN_Documentos
                        Return True
                    End If
                End If
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Procedimiento "TRAN_CAJASS_ConsumoCombustible" por el Generador 02/04/2012
    ' </summary> 
    ' <param name="x_viaje_id">Parametro 1: </param> 
    ' <returns>Si no hay registros devuelve Falso</returns> 
    ' <remarks></remarks> 
    ' 
    Public Function ConsumoCombustible(ByVal x_viaje_id As Long) As Boolean
        Dim m_dtran_combustibleconsumo As New DTRAN_CombustibleConsumo()
        m_listTRAN_CombustibleConsumo = New List(Of ETRAN_CombustibleConsumo)
        Try
            Return m_dtran_combustibleconsumo.TRAN_CAJASS_ConsumoCombustible(m_listTRAN_CombustibleConsumo, x_viaje_id)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ' <summary> 
    ' Procedimiento "TRAN_CAJASS_ConsumoCombustible" por el Generador 02/04/2012
    ' </summary> 
    ' <param name="x_viaje_id">Parametro 1: </param> 
    ' <returns>Si no hay registros devuelve Falso</returns> 
    ' <remarks></remarks> 
    ' 
    Public Function ConsumoAdBlue(ByVal x_viaje_id As Long) As Boolean
        Dim m_dtran_combustibleconsumo As New DTRAN_CombustibleConsumo()
        m_listTRAN_CombustibleConsumo = New List(Of ETRAN_CombustibleConsumo)
        Try
            Return m_dtran_combustibleconsumo.TRAN_CAJASS_ConsumoAdBlue(m_listTRAN_CombustibleConsumo, x_viaje_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary> 
    ' Procedimiento "EliminarViaje" por el Generador 20-04-2024 por frank
    ' </summary> 
    ' <param name="x_viaje_id">Parametro 1: </param> 
    ' <returns>Si no hay registros devuelve Falso</returns> 
    ' <remarks></remarks> 
    ' 
    Public Function EliminarViaje(ByVal x_viaje_id As Long) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_VIAJESD_EliminarViaje")
            DAEnterprise.AgregarParametro("@VIAJE_Id", x_viaje_id)
            Return DAEnterprise.ExecuteNonQuery() > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' <summary> 
    ' Capa de Negocio: TRAN_COMCOSS_ConsumosXVehiculo
    ' </summary>
    ' <param name="x_vehic_id">Parametro 1: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function ConsumosXVehiculo(ByVal x_vehic_id As Long) As Boolean
        m_listTRAN_CombustibleConsumo = New List(Of ETRAN_CombustibleConsumo)
        Try
            Return d_tran_combustibleconsumo.TRAN_COMCOSS_ConsumosXVehiculo(m_listTRAN_CombustibleConsumo, x_vehic_id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ' <summary>
    ' alex consumos
    ' </summary>
    ' <param name="x_documento"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function consumo_combustibless(ByVal x_documento As String) As Boolean
      Try
         m_dtReportes = New DataTable
         Return d_tran_combustibleconsumo.consumo_combustibles(m_dtReportes,x_documento)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ' <summary>
    ' alex compras
    ' </summary>
    '<param name="x_documento"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function doc_compra(ByVal fecini As DateTime, ByVal fecfin As DateTime, ByVal provee As String) As Boolean
      Try
         m_dtReportes_com = New DataTable
         Return d_tran_combustibleconsumo.doc_compra(m_dtReportes_com,fecini,fecfin,provee)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ' <summary>
    ' alex compras pro
    ' </summary>
    ' <param name="x_documento"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function doc_compra_pro(ByVal provee As String) As Boolean
      Try
         m_dtReportes_com_pro = New DataTable
         Return d_tran_combustibleconsumo.doc_compra_pro(m_dtReportes_com_pro,provee)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    ' <summary>
    ' alex validar compras
    ' </summary>
    ' <param name="x_documento"></param>
    ' <returns></returns>
    ' <remarks></remarks>
    Public Function doc_compra_validar(ByVal x_doc As String, ByVal x_pro As String) As Boolean
      Try
         DTTabla_com_val = New DataTable
         Return d_tran_combustibleconsumo.doc_compra_val(DTTabla_com_val,x_doc,x_pro)
      Catch ex As Exception
         Throw ex
      End Try
   End Function



    ' <summary> 
    ' Capa de Negocio: TRAN_COMCOSS_Consumos
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    '<param name = "x_cadena" > Parametro 3: </param> 
    ' <param name="x_opcion">Parametro 4: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function Consumos(ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_cadena As String, ByVal x_opcion As Short) As Boolean
      m_listTRAN_CombustibleConsumo = New List(Of ETRAN_CombustibleConsumo)
      Try
         Return d_tran_combustibleconsumo.TRAN_COMCOSS_Consumos(m_listTRAN_CombustibleConsumo, x_fecini, x_fecfin, x_cadena, x_opcion)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetFecha() As DateTime
      Try
         Return d_tran_combustibleconsumo.GetFecha()
      Catch ex As Exception
         Throw ex
      End Try
    End Function


    Public Function getCorrelativoAdBlue(ByVal x_campo As String, ByVal x_where As Hashtable) As Integer
        Try
            Return d_tran_combustibleconsumo.getCorrelativo(x_campo, x_where) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   'Public Function Cargar(ByVal x_comco_id As Long, ByVal x_detalle As Boolean) As Boolean
   '   Try
   '      If x_detalle Then
   '         Dim _acjoin As New List(Of ACJoin)
   '         _acjoin.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Prov", ACJoin.TipoJoin.Inner, _
   '                                New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")}, _
   '                                New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocProveedor")}))
   '         _acjoin.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Cond", ACJoin.TipoJoin.Inner, _
   '                       New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoConductor")}, _
   '                       New ACCampos() {New ACCampos("ENTID_RazonSocial", "Conductores"), New ACCampos("ENTID_NroDocumento", "ENTID_NroDocConductor")}))
   '         _acjoin.Add(New ACJoin(ETRAN_Vehiculos.Esquema, ETRAN_Vehiculos.Tabla, "Vehic", ACJoin.TipoJoin.Inner, _
   '                       New ACCampos() {New ACCampos("VEHIC_Id", "VEHIC_Id")}, _
   '                       New ACCampos() {New ACCampos("VEHIC_Placa", "VEHIC_Placa")}))

   '         Dim _where As New Hashtable
   '         _where.Add("COMCO_Id", New ACWhere(x_comco_id))
   '         Return Cargar(_acjoin, _where)
   '      Else
   '         m_tran_combustibleconsumo = New ETRAN_CombustibleConsumo()
   '         Return d_tran_combustibleconsumo.TRAN_COMCOSS_UnReg(m_tran_combustibleconsumo, x_comco_id)
   '      End If
   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

#End Region

End Class


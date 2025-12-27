Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETipos
      Implements ICloneable

#Region " Variables "

#End Region

#Region " Propiedades "
   Public ReadOnly Property TIPOS_CODTIPO() As String
      Get
         Return m_tipos_codigo.Substring(3)
      End Get
   End Property

#End Region

#Region " Constructores "
   Public Sub New(ByVal x_tipos_codigo As String, ByVal x_tipos_descripcion As String)
      Me.m_tipos_codigo = x_tipos_codigo
      Me.m_tipos_descripcion = x_tipos_descripcion
   End Sub
#End Region

#Region " Metodos "
   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New ETipos()
         cloneInstance = CType(Me, ETipos)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region " Constantes de Tipos "

#Region " Enumeraciones "

   Public Enum MyTipos
      Tipos
      TipoAlmacen
      CodigoAduana
      TipoColor
      TipoComision
      TipoDocComprobante
      CategoriaArticulo
      TipoDestinoArticulo
      DocumentoIndentidad
      EntidadFinanciera
      TipoIntangible
      TipoMoneda
      TipoMedioPago
      TipoPercepcion
      CondicionPago
      TipoArticulo
      TipoExistencia
      TipoUnidad
      TipoCosteo
      MarcasVehiculos
      TipoVehiculos
      TipoCombustible
      TipoNeumatico
      TipoDocTraslado
      MotivoTraslado
      RelacionEntidades
      Auditoria
      MarcasNeumaticos
      MarcasRanflas
      TipoMantenimiento
      TipoPieza
      TipoIncidencia
      TipoDocumentoInterno
      TipoOrigenDestino
      ModoPago
      TipoGasto
      TipoCuentaBancaria
      TipoDocumentoPago
      TipoPago
      TipoIncidenciaNeumatico
      TipoRecibo
      TipoCategoria
      TipoInventarioAccesorio
      TipoInventarioHerramienta
      TipoInventarioAbolladura
      TipoInventarioOtro
      TipoRemuneracion
      TipoTrabajo
      TipoTrabajador
      Nacionalidad
      GrupoSanguineo
      TipoSueldo
      Genero
      AreaEmpresa
      EstadoCivil
      EstadoTrabajador
      Turno
      Sansionado
      SituacionEPS
      SCRTPension
      SCTRSalud
      TipoPagoTrabajador
      SubtipoPlantillaHaberes
      OrigenCancelacion
      OrigenCotizacion
      TipoRepuesto
      AccesorioInventario
      TipoOrdenRecojo
      MotivoNotaCredito
        MotivoNotaDebito
      TipoEntidadRelacion
      TipoDevCajaChica
      TransaccionTRecibos
      OrigenDeGuias
      TipoMovimientoStock
      TipoDeArreglo
      TRAN_TipoOrigenCompra
   End Enum

   Enum TransaccionTRecibos
      Normal = 1
      AFavorCliente = 2
      DevolucionCliente = 3
      SinRecibo = 4
   End Enum

   Enum TipoDocumentoIdentidad
      Otros
      DNI
      CarnetExtranjeria
      RUC
      Pasaporte
   End Enum

   Enum TPercepcion
      Todos = 1
      AgentesPercepcion = 2
      Exonerados = 3
      AgentesRetencion = 4
   End Enum

   Enum TipoPago
      Contado = 1
        Credito = 2
        Bancarizacion = 17 '_M
    End Enum
    

   Enum TipoDePago
      Efectivo = 1
      DepositoBancario = 2
      Cheque = 3
      Letra = 4
      NotaCredito = 5
      Detraccion = 6
      RecEgreInterno = 7
      TransferenciaFondos = 8
      ReciboEgresoRedondeo = 9
      ReciboIngresoRedondeo = 10
   End Enum

   Enum TipoDocumento
      Factura = 1
      Boleta = 3
      NotaCredito = 7
      GuiaRemisionRem = 9
   End Enum

   Enum TipoComprobanteVenta
      Boleta = 3
      Factura = 1
      Ticket = 12
      NotaCredito = 7
      NotaDebito = 8
      Percepcion = -1
      ReciboTransporte = -2
      Caja = -3
      Flete = -4
      GastosViaje = -5
      Transferencia = -6
      IngresoEfectivo = -7
      EgresoEfectivo = -8
      ReciboEgreso = -9
      ReciboIngreso = -10
      CotizacionTransporte = -11
      CotizacionVenta = -12
      BoletaInterna = -13
      RegistroMercaderia = -14
      PedidoReposicion = -15
      GuiaReposicion = -16
      ReciboAFavorCliente = -17
      OrdenRecojo = -18
      Letra = -19
      ReciboDevolucion = -20
   End Enum

   Enum OrigenCancelacion
      CFletes = 1
      CGViajes = 2
      CFacturas = 3
      CVarios = 4
      CIngEgre = 5
      COtrosIngresos = 6
      CancelacionDocumentosTransp = 7
      FactCancelacionVentas = 8
      PagoPercepciones = 9
      CancelacionDocumentosVentas = 10
   End Enum

   Enum TipoDocsTraslado
      GuiaRemisionRemitente = 9
      GuiaRemisionTransportista = 31
   End Enum

   Enum TipoMoneda
      Soles = 1
      Dolares = 2
      Otros = 9
   End Enum

   Enum CondicionPago
      Contado = 1
      Credito = 2
   End Enum

   Enum TipoCosteo
      Fletes = 1
      Gastos = 2
      Servicio = 3
      Descuentos = 4
   End Enum

   Enum TipoDestino
      Mercaderia = 1
      Produccion = 2
   End Enum

   Enum TipoAuditoria
      StocksNegativo = 1
      CotizacionesPasadas = 2
      FacturarCreditoExcedido = 3
      FacturaDiferido = 4
      CambiarVendedorCot = 5
      CambiarVendedorFac = 6
   End Enum

   Enum TipoDocPago
      Efectivo = 1
      Deposito = 2
      Cheque = 3
      Letra = 4
      NotaCredito = 5
      Detraccion = 6
      RecEgreInterno = 7
   End Enum

   Enum MotivoTraslado
      Venta = 1
      Compra = 3
      Consignacion = 4
      Devolucion = 5
      Traslado_Empresa = 6
      Traslado_Transformacion = 7
      Recojo_Transformados = 8
      Otros = 13
   End Enum

   Enum TipoGasto
      Inicial = 1
      Terminal = 2
      IncNeumaticos = 3
      IncVehiculos = 4
   End Enum

   Enum TipoRecibo
      Ingreso = 1
      Egreso = 2
      Pendiente = 3
      Gasto = 4
      ACtaSueldo = 5
      ConDocumento = 6
   End Enum

   Enum TipoCategoria
      Accesorios
      Herramientas
      Abolladuras
      Otros
   End Enum

   Enum TBanco
      BCP = 2
      Interbank = 54
   End Enum

   Enum TCuentaBancaria
      CtaCte = 1
      CtaAhorro = 2
      CtaSueldo = 3
      CtaMaestra = 4
   End Enum

   Enum OrigenCotizacion
      CViaje = 1
      CFacturacion = 2
   End Enum

   Enum TipoOrdenRecojo
      Recojo = 1
      RecojoIngreso = 2
      RecojoSalida = 3
   End Enum

   Enum MotivoNotaCredito
      AnulacionOperacion = 1
      AnulacionRuc = 2
      CorreccionDescripcion = 3
      DescuentoGlobal = 4
      DescuentoItem = 5
        DevolucionTotal=6
        DevolucionItem=7
        Bonificacion=8
        DisminucionValor=9
        OtrosConceptos=10
   End Enum
    Enum MotivoNotaDebito
      InteresMora = 1
      AumentoValor = 2
      Penalidades = 3
      
   End Enum

   Enum TipoEntidadRelacion
      Conductor = 1
   End Enum

   Enum TOrigenDeGuias
      TrasladoVentas = 1
      TrasladoSalida = 2
      TrasladoIngreso = 3
   End Enum

   Enum TMovimientoStock
      SalidaVenta = 1
      SalidaPedido = 2
      IngresoCompra = 3
      IngresoOrden = 4
      SalidaOrden = 5
      SalidaGuiaTraslado = 6
      IngresoPendienteDevuelta = 7
      IngresoTraslado = 8
      SalidaPendDevuelta = 9
      IngresoArreglo = 10
      SalidaArreglo = 11
        SalidaPedidoReposicion = 12
        SalidaDevolucion = 16
        SalidaTransformacion = 17
   End Enum

   Enum TArreglo
      Ingreso = 1
      Egreso = 2
   End Enum

   Enum TTRAN_TipoOrigenCompra
      Combustible = 1
      Mantenimiento = 2
   End Enum


#End Region

   Public Shared ReadOnly Property getCodTipo(ByVal x_opcion As MyTipos)
      Get
         Select Case x_opcion
            Case MyTipos.Tipos
               Return "TIP"
            Case MyTipos.TipoAlmacen
               Return "ALM"
            Case MyTipos.CodigoAduana
               Return "CAD"
            Case MyTipos.TipoColor
               Return "CLR"
            Case MyTipos.TipoComision
               Return "COM"
            Case MyTipos.TipoDocComprobante
               Return "CPD"
            Case MyTipos.CategoriaArticulo
               Return "CTP"
            Case MyTipos.TipoDestinoArticulo
               Return "DES"
            Case MyTipos.DocumentoIndentidad
               Return "DID"
            Case MyTipos.EntidadFinanciera
               Return "ENF"
            Case MyTipos.TipoIntangible
               Return "ITA"
            Case MyTipos.TipoMoneda
               Return "MND"
            Case MyTipos.TipoCuentaBancaria
               Return "CTA"
            Case MyTipos.TipoMedioPago
               Return "MPG"
            Case MyTipos.TipoPercepcion
               Return "PER"
            Case MyTipos.CondicionPago
               Return "PGO"
            Case MyTipos.TipoArticulo
               Return "PRO"
            Case MyTipos.TipoExistencia
               Return "TEX"
            Case MyTipos.TipoUnidad
               Return "UND"
            Case MyTipos.TipoCosteo
               Return "CTO"
            Case MyTipos.MarcasVehiculos
               Return "MAV"
            Case MyTipos.TipoCombustible
               Return "CMB"
            Case MyTipos.TipoVehiculos
               Return "VEH"
            Case MyTipos.TipoNeumatico
               Return "NEU"
            Case MyTipos.TipoDocTraslado
               Return "DTR"
            Case MyTipos.MotivoTraslado
               Return "MTG"
            Case MyTipos.RelacionEntidades
               Return "ERL"
            Case MyTipos.Auditoria
               Return "AUT"
            Case MyTipos.MarcasRanflas
               Return "MAR"
            Case MyTipos.MarcasNeumaticos
               Return "MAN"
            Case MyTipos.TipoMantenimiento
               Return "MNT"
            Case MyTipos.TipoPieza
               Return "TPZ"
            Case MyTipos.TipoIncidencia
               Return "INC"
            Case MyTipos.TipoDocumentoInterno
               Return "TDI"
            Case MyTipos.TipoOrigenDestino
               Return "TOD"
            Case MyTipos.ModoPago
               Return "MPG"
            Case MyTipos.TipoGasto
               Return "GTO"
            Case MyTipos.TipoDocumentoPago
               Return "DPG"
            Case MyTipos.TipoPago
               Return "TPG"
            Case MyTipos.TipoIncidenciaNeumatico
               Return "INN"
            Case MyTipos.TipoRecibo
               Return "RCT"
            Case MyTipos.TipoCategoria
               Return "TCA"
            Case MyTipos.TipoInventarioAccesorio
               Return "IAC"
            Case MyTipos.TipoInventarioAbolladura
               Return "IAB"
            Case MyTipos.TipoInventarioHerramienta
               Return "IHR"
            Case MyTipos.TipoInventarioOtro
               Return "IOT"
            Case MyTipos.TipoRemuneracion
               Return "TRM"
            Case MyTipos.TipoTrabajo
               Return "TRA"
            Case MyTipos.TipoTrabajador
               Return "TBJ"
            Case MyTipos.Nacionalidad
               Return "NAC"
            Case MyTipos.GrupoSanguineo
               Return "GSN"
            Case MyTipos.TipoSueldo
               Return "SUE"
            Case MyTipos.Genero
               Return "SEX"
            Case MyTipos.AreaEmpresa
               Return "ARE"
            Case MyTipos.EstadoCivil
               Return "ETC"
            Case MyTipos.EstadoTrabajador
               Return "EST"
            Case MyTipos.Turno
               Return "TUR"
            Case MyTipos.Sansionado
               Return "SAN"
            Case MyTipos.SituacionEPS
               Return "SEP"
            Case MyTipos.SCRTPension
               Return "SCP"
            Case MyTipos.SCTRSalud
               Return "SCS"
            Case MyTipos.TipoPagoTrabajador
               Return "TPT"
            Case MyTipos.SubtipoPlantillaHaberes
               Return "SPH"
            Case MyTipos.OrigenCancelacion
               Return "ORI"
            Case MyTipos.OrigenCotizacion
               Return "ORC"
            Case MyTipos.TipoRepuesto
               Return "REP"
            Case MyTipos.AccesorioInventario
               Return "AVI"
            Case MyTipos.TipoOrdenRecojo
               Return "ORD"
            Case MyTipos.MotivoNotaCredito
               Return "MNC"
                    Case MyTipos.MotivoNotaDebito
               Return "NDM"
            Case MyTipos.TipoEntidadRelacion
               Return "ERL"
            Case MyTipos.TipoDevCajaChica
               Return "TPC"
            Case MyTipos.TransaccionTRecibos
               Return "TRE"
            Case MyTipos.OrigenDeGuias
               Return "OGR"
            Case MyTipos.TipoMovimientoStock
               Return "MST"
            Case MyTipos.TipoDeArreglo
               Return "ARR"
            Case MyTipos.TRAN_TipoOrigenCompra
               Return "DOR"
            Case Else
               Return ""
         End Select
      End Get
   End Property

#Region " Tipos como Funciones Explicitas "
   ''' <summary>
   ''' Tipo de Comprobante de Venta
   ''' </summary>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getTipoComprobante(ByVal x_opcion As TipoComprobanteVenta) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoDocComprobante)
         Select Case x_opcion
            Case TipoComprobanteVenta.ReciboTransporte
               Return String.Format("{0}RT", x_tipo)
            Case TipoComprobanteVenta.Percepcion
               Return String.Format("{0}PE", x_tipo)
            Case TipoComprobanteVenta.Flete
               Return String.Format("{0}FL", x_tipo)
            Case TipoComprobanteVenta.Caja
               Return String.Format("{0}CJ", x_tipo)
            Case TipoComprobanteVenta.GastosViaje
               Return String.Format("{0}GV", x_tipo)
            Case TipoComprobanteVenta.Transferencia
               Return String.Format("{0}TR", x_tipo)
            Case TipoComprobanteVenta.IngresoEfectivo
               Return String.Format("{0}IN", x_tipo)
            Case TipoComprobanteVenta.EgresoEfectivo
               Return String.Format("{0}EG", x_tipo)
            Case TipoComprobanteVenta.ReciboEgreso
               Return String.Format("{0}RE", x_tipo)
            Case TipoComprobanteVenta.ReciboIngreso
               Return String.Format("{0}RI", x_tipo)
            Case TipoComprobanteVenta.CotizacionTransporte
               Return String.Format("{0}CT", x_tipo)
            Case TipoComprobanteVenta.CotizacionVenta
               Return String.Format("{0}CV", x_tipo)
            Case TipoComprobanteVenta.BoletaInterna
               Return String.Format("{0}BI", x_tipo)
            Case TipoComprobanteVenta.RegistroMercaderia
               Return String.Format("{0}RM", x_tipo)
            Case TipoComprobanteVenta.PedidoReposicion
               Return String.Format("{0}PR", x_tipo)
            Case TipoComprobanteVenta.GuiaReposicion
               Return String.Format("{0}GR", x_tipo)
            Case TipoComprobanteVenta.ReciboAFavorCliente
               Return String.Format("{0}RA", x_tipo)
            Case TipoComprobanteVenta.OrdenRecojo
               Return String.Format("{0}OR", x_tipo)
            Case TipoComprobanteVenta.Letra
               Return String.Format("{0}LE", x_tipo)
            Case TipoComprobanteVenta.ReciboDevolucion
               Return String.Format("{0}DE", x_tipo)
            Case Else
               Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
         End Select
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipoDocumento(ByVal x_opcion As TipoDocumento) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoDocComprobante)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipoDocPago(ByVal x_opcion As TipoDocPago) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoDocumentoPago)
         Return String.Format("{0}{1:00}", x_tipo, CType(x_opcion, Integer))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipoDePago(ByVal x_opcion As TipoDePago) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoPago)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipoDocTraslado(ByVal x_opcion As TipoDocsTraslado) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoDocComprobante)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipoOrigen(ByVal x_opcion As OrigenCancelacion) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.OrigenCancelacion)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   ''' <summary>
   ''' Tipo de Pago
   ''' </summary>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getCondicionPago(ByVal x_opcion As TipoPago) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.CondicionPago)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   ''' <summary>
   ''' Motivo de Traslado
   ''' </summary>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getMotivoTraslado(ByVal x_opcion As MotivoTraslado) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.MotivoTraslado)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function getTipoOrdenRecojo(ByVal x_opcion As TipoOrdenRecojo) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoOrdenRecojo)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getMotivoNotaCredito(ByVal x_opcion As MotivoNotaCredito) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.MotivoNotaCredito)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("000"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

    Public Shared Function getMotivoNotaDebito(ByVal x_opcion As MotivoNotaDebito) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.MotivoNotaDebito)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("000"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipoArreglo(ByVal x_opcion As TArreglo) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoDeArreglo)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo_TRAN_OrigenDocCompra(ByVal x_opcion As TTRAN_TipoOrigenCompra) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TRAN_TipoOrigenCompra)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

#End Region

#Region " Tipos como Funciones GetTipo"

   ''' <summary>
   ''' Documentos de Identidad
   ''' </summary>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getTipo(ByVal x_opcion As TipoDocumentoIdentidad) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.DocumentoIndentidad)
         Select Case x_opcion
            Case TipoDocumentoIdentidad.Otros
               Return String.Format("{0}0", x_tipo)
            Case TipoDocumentoIdentidad.DNI
               Return String.Format("{0}1", x_tipo)
            Case TipoDocumentoIdentidad.CarnetExtranjeria
               Return String.Format("{0}4", x_tipo)
            Case TipoDocumentoIdentidad.RUC
               Return String.Format("{0}6", x_tipo)
            Case TipoDocumentoIdentidad.Pasaporte
               Return String.Format("{0}7", x_tipo)
         End Select
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   ''' <summary>
   ''' Tipo de Moneda
   ''' </summary>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getTipo(ByVal x_opcion As TipoMoneda) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoMoneda)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   ''' <summary>
   ''' Tipo de Moneda
   ''' </summary>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getTipo(ByVal x_opcion As TipoEntidadRelacion) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoEntidadRelacion)
         Return String.Format("{0}{1:00}", x_tipo, CType(x_opcion, Integer))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   ''' <summary>
   ''' Tipo de Costeo
   ''' </summary>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getTipo(ByVal x_opcion As TipoCosteo) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoCosteo)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   ''' <summary>
   ''' Tipo destino
   ''' </summary>
   ''' <param name="x_opcion"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getTipo(ByVal x_opcion As TipoDestino) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoDestinoArticulo)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As TipoAuditoria) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.Auditoria)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("000"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As TipoGasto) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoGasto)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As TipoRecibo) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoRecibo)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As TBanco) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.EntidadFinanciera)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As TCuentaBancaria) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoCuentaBancaria)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As TipoDePago) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoPago)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As OrigenCotizacion) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.OrigenCotizacion)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function


   Public Shared Function getTipo(ByVal x_opcion As TPercepcion) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoPercepcion)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("0"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As TransaccionTRecibos) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TransaccionTRecibos)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function

   Public Shared Function getTipo(ByVal x_opcion As TOrigenDeGuias) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.OrigenDeGuias)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function


   Public Shared Function getTipo(ByVal x_opcion As TMovimientoStock) As String
      Dim x_tipo As String
      Try
         x_tipo = getCodTipo(MyTipos.TipoMovimientoStock)
         Return String.Format("{0}{1}", x_tipo, CType(x_opcion, Integer).ToString("00"))
      Catch ex As Exception
         Throw ex
      End Try
      Return x_tipo
   End Function
#End Region

#End Region

#End Region
End Class




Partial Public Class ETipos

#Region " Campos "
	
	Private m_tipos_codigo As String
	Private m_tipos_descripcion As String
	Private m_tipos_desclarga As String
	Private m_tipos_desccorta As String
	Private m_tipos_desc2 As String
	Private m_tipos_numero As Decimal
	Private m_tipos_estado As String
	Private m_tipos_protegido As Boolean
	Private m_tipos_nventas As Short
	Private m_tipos_nlogistica As Short
	Private m_tipos_lserie As Short
	Private m_tipos_lnumero As Short
	Private m_tipos_items As Short
	Private m_tipos_usrcrea As String
	Private m_tipos_feccrea As Date
	Private m_tipos_usrmod As String
	Private m_tipos_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlTipos
			Dim _xml As New XmlDocument
			_xml.LoadXml(_obj)
			If IsNothing(m_hash) Then
				m_hash = New Hashtable()
				Dim cPlantilla As XmlNodeList = _xml.GetElementsByTagName("Tabla")
				Dim cCampos As XmlNodeList = CType(cPlantilla(0), XmlElement).GetElementsByTagName("Campos")
				Dim Campo As XmlNodeList = CType(cCampos(0), XmlElement).GetElementsByTagName("CCampo")
				For Each Item As XmlElement In Campo
					m_hash.Add(Item.InnerText.ToString(), New CCampo(Item.GetAttribute("xmlns"), IIf(Item.GetAttribute("Identity") = "1", True, False), IIf(Item.GetAttribute("ForeignKey") = "1", True, False), IIf(Item.GetAttribute("PrimaryKey") = "1", True, False)))
				Next
			End If
		Catch ex As Exception
			Throw ex
		End Try
	End Sub

#End Region

#Region" Propiedades "
	
	Public Property TIPOS_Codigo() As String
		Get
			return m_tipos_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codigo) Then
				If Not m_tipos_codigo.Equals(value) Then
					m_tipos_codigo = value
					OnTIPOS_CodigoChanged(m_tipos_codigo, EventArgs.Empty)
				End If
			Else
				m_tipos_codigo = value
				OnTIPOS_CodigoChanged(m_tipos_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Descripcion() As String
		Get
			return m_tipos_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_descripcion) Then
				If Not m_tipos_descripcion.Equals(value) Then
					m_tipos_descripcion = value
					OnTIPOS_DescripcionChanged(m_tipos_descripcion, EventArgs.Empty)
				End If
			Else
				m_tipos_descripcion = value
				OnTIPOS_DescripcionChanged(m_tipos_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_DescLarga() As String
		Get
			return m_tipos_desclarga
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_desclarga) Then
				If Not m_tipos_desclarga.Equals(value) Then
					m_tipos_desclarga = value
					OnTIPOS_DescLargaChanged(m_tipos_desclarga, EventArgs.Empty)
				End If
			Else
				m_tipos_desclarga = value
				OnTIPOS_DescLargaChanged(m_tipos_desclarga, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_DescCorta() As String
		Get
			return m_tipos_desccorta
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_desccorta) Then
				If Not m_tipos_desccorta.Equals(value) Then
					m_tipos_desccorta = value
					OnTIPOS_DescCortaChanged(m_tipos_desccorta, EventArgs.Empty)
				End If
			Else
				m_tipos_desccorta = value
				OnTIPOS_DescCortaChanged(m_tipos_desccorta, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Desc2() As String
		Get
			return m_tipos_desc2
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_desc2) Then
				If Not m_tipos_desc2.Equals(value) Then
					m_tipos_desc2 = value
					OnTIPOS_Desc2Changed(m_tipos_desc2, EventArgs.Empty)
				End If
			Else
				m_tipos_desc2 = value
				OnTIPOS_Desc2Changed(m_tipos_desc2, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Numero() As Decimal
		Get
			return m_tipos_numero
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tipos_numero) Then
				If Not m_tipos_numero.Equals(value) Then
					m_tipos_numero = value
					OnTIPOS_NumeroChanged(m_tipos_numero, EventArgs.Empty)
				End If
			Else
				m_tipos_numero = value
				OnTIPOS_NumeroChanged(m_tipos_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Estado() As String
		Get
			return m_tipos_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_estado) Then
				If Not m_tipos_estado.Equals(value) Then
					m_tipos_estado = value
					OnTIPOS_EstadoChanged(m_tipos_estado, EventArgs.Empty)
				End If
			Else
				m_tipos_estado = value
				OnTIPOS_EstadoChanged(m_tipos_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Protegido() As Boolean
		Get
			return m_tipos_protegido
		End Get
		Set(ByVal value As Boolean)
			If Not m_tipos_protegido.Equals(value) Then
				m_tipos_protegido = value
				OnTIPOS_ProtegidoChanged(m_tipos_protegido, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_NVentas() As Short
		Get
			return m_tipos_nventas
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_nventas) Then
				If Not m_tipos_nventas.Equals(value) Then
					m_tipos_nventas = value
					OnTIPOS_NVentasChanged(m_tipos_nventas, EventArgs.Empty)
				End If
			Else
				m_tipos_nventas = value
				OnTIPOS_NVentasChanged(m_tipos_nventas, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_NLogistica() As Short
		Get
			return m_tipos_nlogistica
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_nlogistica) Then
				If Not m_tipos_nlogistica.Equals(value) Then
					m_tipos_nlogistica = value
					OnTIPOS_NLogisticaChanged(m_tipos_nlogistica, EventArgs.Empty)
				End If
			Else
				m_tipos_nlogistica = value
				OnTIPOS_NLogisticaChanged(m_tipos_nlogistica, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_LSerie() As Short
		Get
            Return m_tipos_lserie
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_lserie) Then
				If Not m_tipos_lserie.Equals(value) Then
					m_tipos_lserie = value
					OnTIPOS_LSerieChanged(m_tipos_lserie, EventArgs.Empty)
				End If
			Else
				m_tipos_lserie = value
				OnTIPOS_LSerieChanged(m_tipos_lserie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_LNumero() As Short
		Get
			return m_tipos_lnumero
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_lnumero) Then
				If Not m_tipos_lnumero.Equals(value) Then
					m_tipos_lnumero = value
					OnTIPOS_LNumeroChanged(m_tipos_lnumero, EventArgs.Empty)
				End If
			Else
				m_tipos_lnumero = value
				OnTIPOS_LNumeroChanged(m_tipos_lnumero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_Items() As Short
		Get
			return m_tipos_items
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_tipos_items) Then
				If Not m_tipos_items.Equals(value) Then
					m_tipos_items = value
					OnTIPOS_ItemsChanged(m_tipos_items, EventArgs.Empty)
				End If
			Else
				m_tipos_items = value
				OnTIPOS_ItemsChanged(m_tipos_items, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_UsrCrea() As String
		Get
			return m_tipos_usrcrea
		End Get
		Set(ByVal value As String)
			m_tipos_usrcrea = value
		End Set
	End Property

	Public Property TIPOS_FecCrea() As Date
		Get
			return m_tipos_feccrea
		End Get
		Set(ByVal value As Date)
			m_tipos_feccrea = value
		End Set
	End Property

	Public Property TIPOS_UsrMod() As String
		Get
			return m_tipos_usrmod
		End Get
		Set(ByVal value As String)
			m_tipos_usrmod = value
		End Set
	End Property

	Public Property TIPOS_FecMod() As Date
		Get
			return m_tipos_fecmod
		End Get
		Set(ByVal value As Date)
			m_tipos_fecmod = value
		End Set
	End Property

	#Region " Propiedades de Solo Lectura "

	Public ReadOnly Property Nuevo() As Boolean
		Get
			return m_nuevo
		End Get
	End Property

	Public ReadOnly Property Modificado() As Boolean
		Get
			return m_modificado
		End Get
	End Property

	Public ReadOnly Property Eliminado() As Boolean
		Get
			return m_eliminado
		End Get
	End Property

	Public ReadOnly Property Hash() As Hashtable
		Get
			return m_hash
		End Get
	End Property

	Public Shared ReadOnly Property Tabla() As String
		Get
			Return "Tipos"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event TIPOS_CodigoChanged As EventHandler
	Public Event TIPOS_DescripcionChanged As EventHandler
	Public Event TIPOS_DescLargaChanged As EventHandler
	Public Event TIPOS_DescCortaChanged As EventHandler
	Public Event TIPOS_Desc2Changed As EventHandler
	Public Event TIPOS_NumeroChanged As EventHandler
	Public Event TIPOS_EstadoChanged As EventHandler
	Public Event TIPOS_ProtegidoChanged As EventHandler
	Public Event TIPOS_NVentasChanged As EventHandler
	Public Event TIPOS_NLogisticaChanged As EventHandler
	Public Event TIPOS_LSerieChanged As EventHandler
	Public Event TIPOS_LNumeroChanged As EventHandler
	Public Event TIPOS_ItemsChanged As EventHandler

	Public Sub OnTIPOS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_DescripcionChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_DescLargaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_DescLargaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_DescCortaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_DescCortaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_Desc2Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_Desc2Changed(sender, e)
	End Sub

	Public Sub OnTIPOS_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_NumeroChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_EstadoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_ProtegidoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_ProtegidoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_NVentasChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_NVentasChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_NLogisticaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_NLogisticaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_LSerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_LSerieChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_LNumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_LNumeroChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_ItemsChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_ItemsChanged(sender, e)
	End Sub


#End Region

#Region " Metodos "
	
	Public Sub Instanciar(ByVal x_instancia As ACEInstancia)
		Select Case x_instancia
			Case ACEInstancia.Consulta
				m_nuevo = False
				m_modificado = False
				m_eliminado = False
			Case ACEInstancia.Nuevo
				m_nuevo = True
				m_modificado = False
				m_eliminado = False
			Case ACEInstancia.Modificado
				m_nuevo = False
				m_modificado = True
				m_eliminado = False
			Case ACEInstancia.Eliminado
				m_nuevo = False
				m_modificado = False
				m_eliminado = True
		End Select
	End Sub

	Public Sub ActualizarInstancia()
		If Not Nuevo Then
			If Not Eliminado Then
				Instanciar(ACEInstancia.Modificado)
			End If
		End If
	End Sub

#End Region

End Class

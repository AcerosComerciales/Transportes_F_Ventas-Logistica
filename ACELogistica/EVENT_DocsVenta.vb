Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework
Imports ACEVentas

Public Class EVENT_DocsVenta

       Implements ICloneable

#Region " Variables "
   Private m_posicion As Integer

   Private m_listVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle)
   Private m_listvent_docsrelacion As List(Of EVENT_DocsRelacion)
  ' Private m_listteso_docspagos As List(Of ETESO_DocsPagos)
   Private m_listvent_docsventa As List(Of EVENT_DocsVenta)
   'Private m_listcuadrependientes As List(Of ECCuadrePendientes)

   Private m_entid_codtipodocumento As String
   Private m_entid_tipoentidadpdt As String
   Private m_entid_cliente As String
   Private m_entid_razonsocial As String
   Private m_entid_apaterno As String
   Private m_entid_amaterno As String
   Private m_entid_nombres As String

   Private m_entid_vendedor As String
   Private m_usuario As String
   Private m_tipos_tipopagocorto As String
   Private m_tipos_codtipomonedapago As String
    Private m_tipos_tipomonedapago As String

    Private m_tipos_tipomotivo As String
   Private m_tipos_documento As String
   Private m_tipos_doccorta As String
   Private m_tipos_moneda As String

   Private m_entid_codigo As String
   Private m_entid_nrodocumento As String
   Private m_tipos_condicionpago As String
   Private m_tipos_condicionpagocorto As String

   Private m_guias As Boolean
   Private m_nota As Boolean
   Private m_orden As Boolean
   Private m_pendiente As Boolean
   Private m_anulada As Boolean

   Private m_importesoles As Decimal
   Private m_importesdolares As Decimal

   Private m_igvsoles As Decimal
   Private m_totalsoles As Decimal
   Private m_totaldolares As Decimal

   Private m_importepagar As Decimal

   Private m_tipoc_ventasunat As Decimal

   Private m_seleccionado As Boolean

   Private m_tpago As ETipos.TipoDePago

   'Private m_teso_caja As ETESO_Caja
   'Private m_teso_docspagos As ETESO_DocsPagos

   Private m_totalpagado As Decimal
   Private m_totalpagadodolares As Decimal
   Private m_saldopendiente As Decimal

   Private m_seleccionar As Boolean

   Private m_artic_codigo As String
   Private m_artic_descripcion As String
   Private m_docvd_cantidad As Decimal
   Private m_docvd_preciounitario As Decimal
   Private m_docvd_subimporteventa As Decimal
   Private m_comisionsoles As Decimal
   Private m_comisiondolares As Decimal
   Private m_lprec_codigo As String
   Private m_lprec_comision As Decimal
   Private m_orden_codigo As String
   Private m_codigo As String

   Private m_cotiz_codigo As String
   Private m_entid_codusuario As String

   Private m_cotizador As String
   Private m_titulo As String
   Private m_cargo As Decimal
   Private m_abono As Decimal
   Private m_saldocta As Decimal

   Private m_entid_usradmin As String
   Private m_totalventa As Decimal

   Private m_dpago_id As Long
   Private m_dpago_numero As String
   Private m_caja_fecha As DateTime
   Private m_tipos_tipopago As String
   Private m_caja_importe As Decimal
   Private m_glosa As String
   Private m_dpago_fecha As DateTime
   Private m_dpago_importe As Decimal
   Private m_caja_glosa As String

   Private m_entid_facturador As String
   Private m_entid_cotizador As String

   Private m_docve_importepercepciondolares As Decimal
   Private m_pendientesoles As Decimal
   Private m_pendientedolares As Decimal
   Private m_totalpendiente As Decimal
   Private m_percepcionpendiente As Decimal
   Private m_importependiente As Decimal

   Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum

#End Region

#Region " Propiedades "

   Public Property Posicion() As Integer
      Get
         Return m_posicion
      End Get
      Set(ByVal value As Integer)
         m_posicion = value
      End Set
   End Property

   Public ReadOnly Property DOCVE_Estado_Text() As String
      Get
         Select Case m_docve_estado
            Case getEstado(Estado.Ingresado)
               Return Estado.Ingresado.ToString()
            Case getEstado(Estado.Anulado)
               Return Estado.Anulado.ToString()
            Case getEstado(Estado.Confirmado)
               Return Estado.Confirmado.ToString()
            Case getEstado(Estado.Eliminado)
               Return Estado.Eliminado.ToString()
            Case Else
               Return Estado.Ingresado.ToString()
         End Select
      End Get
   End Property

   Public ReadOnly Property Documento() As String
      Get
         If Not IsNothing(m_docve_serie) Then
            Select Case m_tipos_codtipodocumento
               Case ETipos.getTipoComprobante(ETipos.TipoComprobanteVenta.Letra)
                  Return String.Format("{0} {1}", m_tipos_doccorta, m_docve_numero.ToString.PadLeft(10, "0"))
               Case Else
                  If IsNothing(m_tipos_doccorta) Then m_tipos_doccorta = "" 'm_tipos_codtipodocumento.Substring(3, 2)"
                  Return String.Format("{0} {1}-{2}", m_tipos_doccorta, m_docve_serie.PadLeft(4, "0"), m_docve_numero.ToString().PadLeft(7, "0"))
            End Select
         Else
            Return ""
         End If
      End Get
   End Property

   Public ReadOnly Property Agrupador() As String
      Get
         Return String.Format("{0} - {1} / {2}", m_docve_fechadocumento.ToString(Constantes.Formatofecha), Documento, m_entid_razonsocial)
      End Get
   End Property

   Public Property ListVENT_DocsVentaDetalle() As List(Of EVENT_DocsVentaDetalle)
      Get
         Return m_listVENT_DocsVentaDetalle
      End Get
      Set(ByVal value As List(Of EVENT_DocsVentaDetalle))
         m_listVENT_DocsVentaDetalle = value
      End Set
   End Property

   Public Property ListVENT_DocsRelacion() As List(Of EVENT_DocsRelacion)
      Get
         Return m_listvent_docsrelacion
      End Get
      Set(ByVal value As List(Of EVENT_DocsRelacion))
         m_listvent_docsrelacion = value
      End Set
   End Property

   'Public Property ListTESO_DocsPagos() As List(Of ETESO_DocsPagos)
   '   Get
   '      Return m_listteso_docspagos
   '   End Get
   '   Set(ByVal value As List(Of ETESO_DocsPagos))
   '      m_listteso_docspagos = value
   '   End Set
   'End Property

   Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
      Get
         Return m_listvent_docsventa
      End Get
      Set(ByVal value As List(Of EVENT_DocsVenta))
         m_listvent_docsventa = value
      End Set
   End Property

   'Public Property ListCuadrePendientes() As List(Of ECCuadrePendientes)
   '   Get
   '      Return m_listcuadrependientes
   '   End Get
   '   Set(ByVal value As List(Of ECCuadrePendientes))
   '      m_listcuadrependientes = value
   '   End Set
   'End Property

   Public Property ENTID_CodTipoDocumento() As String
      Get
         Return m_entid_codtipodocumento
      End Get
      Set(ByVal value As String)
         m_entid_codtipodocumento = value
      End Set
   End Property

   Public Property ENTID_TipoEntidadPDT() As String
      Get
         Return m_entid_tipoentidadpdt
      End Get
      Set(ByVal value As String)
         m_entid_tipoentidadpdt = value
      End Set
   End Property

   Public Property ENTID_Cliente() As String
      Get
         Return m_entid_cliente
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_cliente) Then
            If Not m_entid_cliente.Equals(value) Then
               m_entid_cliente = value
            End If
         Else
            m_entid_cliente = value
         End If
      End Set
   End Property

   Public Property ENTID_RazonSocial() As String
      Get
         Return m_entid_razonsocial
      End Get
      Set(ByVal value As String)
         m_entid_razonsocial = value
      End Set
   End Property

   Public Property ENTID_APaterno() As String
      Get
         Return m_entid_apaterno
      End Get
      Set(ByVal value As String)
         m_entid_apaterno = value
      End Set
   End Property

   Public Property ENTID_AMAterno() As String
      Get
         Return m_entid_amaterno
      End Get
      Set(ByVal value As String)
         m_entid_amaterno = value
      End Set
   End Property

   Public Property ENTID_Nombres() As String
      Get
         Return m_entid_nombres
      End Get
      Set(ByVal value As String)
         m_entid_nombres = value
      End Set
   End Property

   Public Property ENTID_Vendedor() As String
      Get
         Return m_entid_vendedor
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_vendedor) Then
            If Not m_entid_vendedor.Equals(value) Then
               m_entid_vendedor = value
            End If
         Else
            m_entid_vendedor = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoDocumento() As String
      Get
         Return m_tipos_documento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_documento) Then
            If Not m_tipos_documento.Equals(value) Then
               m_tipos_documento = value
            End If
         Else
            m_tipos_documento = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoDocCorta() As String
      Get
         Return m_tipos_doccorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_doccorta) Then
            If Not m_tipos_doccorta.Equals(value) Then
               m_tipos_doccorta = value
            End If
         Else
            m_tipos_doccorta = value
         End If
      End Set
   End Property

   Public Property TIPOS_TipoPagoCorto() As String
      Get
         Return m_tipos_tipopagocorto
      End Get
      Set(ByVal value As String)
         m_tipos_tipopagocorto = value
      End Set
   End Property

   Public Property TIPOS_TipoMoneda() As String
      Get
         Return m_tipos_moneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_moneda) Then
            If Not m_tipos_moneda.Equals(value) Then
               m_tipos_moneda = value
            End If
         Else
            m_tipos_moneda = value
         End If
      End Set
   End Property

   Public Property TIPOS_CodTipoMonedaPago() As String
      Get
         Return m_tipos_codtipomonedapago
      End Get
      Set(ByVal value As String)
         m_tipos_codtipomonedapago = value
      End Set
   End Property


    Public Property TIPOS_TipoMonedaPago() As String
        Get
            Return m_tipos_tipomonedapago
        End Get
        Set(ByVal value As String)
            m_tipos_tipomonedapago = value
        End Set
    End Property
    Public Property TIPOS_TipoMotivo() As String
        Get
            Return m_tipos_tipomotivo
        End Get
        Set(ByVal value As String)
            m_tipos_tipomotivo = value
        End Set
    End Property

   Public Property Usuario() As String
      Get
         Return m_usuario
      End Get
      Set(ByVal value As String)
         m_usuario = value
      End Set
   End Property

   Public Property ENTID_Codigo() As String
      Get
         Return m_entid_codigo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_codigo) Then
            If Not m_entid_codigo.Equals(value) Then
               m_entid_codigo = value
            End If
         Else
            m_entid_codigo = value
         End If
      End Set
   End Property

   Public Property ENTID_NroDocumento() As String
      Get
         Return m_entid_nrodocumento
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_entid_nrodocumento) Then
            If Not m_entid_nrodocumento.Equals(value) Then
               m_entid_nrodocumento = value
            End If
         Else
            m_entid_nrodocumento = value
         End If
      End Set
   End Property

   Public Property Guias() As Boolean
      Get
         Return m_guias
      End Get
      Set(ByVal value As Boolean)
         m_guias = value
      End Set
   End Property

   Public Property Nota() As Boolean
      Get
         Return m_nota
      End Get
      Set(ByVal value As Boolean)
         m_nota = value
      End Set
   End Property

   Public Property Orden() As Boolean
      Get
         Return m_orden
      End Get
      Set(ByVal value As Boolean)
         m_orden = value
      End Set
   End Property

   Public Property Pendiente() As Boolean
      Get
         Return m_pendiente
      End Get
      Set(ByVal value As Boolean)
         m_pendiente = value
      End Set
   End Property

   Public Property Anulada() As Boolean
      Get
         Return m_anulada
      End Get
      Set(ByVal value As Boolean)
         m_anulada = value
      End Set
   End Property

   Public Property TIPOS_CondicionPagoCorto() As String
      Get
         Return m_tipos_condicionpagocorto
      End Get
      Set(ByVal value As String)
         m_tipos_condicionpagocorto = value
      End Set
   End Property

   Public Property TIPOS_CondicionPago() As String
      Get
         Return m_tipos_condicionpago
      End Get
      Set(ByVal value As String)
         m_tipos_condicionpago = value
      End Set
   End Property

   Public ReadOnly Property Condicion() As String
      Get
         Select Case m_docve_estentrega
            Case "E"
               Return "Entregado"
            Case "P"
               Return "Pendiente"
            Case Else
               Return "Entregado"
         End Select
      End Get
   End Property

   Public Property Seleccionado() As Boolean
      Get
         Return m_seleccionado
      End Get
      Set(ByVal value As Boolean)
         m_seleccionado = value
      End Set
   End Property

   Public ReadOnly Property DocPercepcion() As String
      Get
         Return IIf(m_docve_porcentajepercepcion > 0, "Si", "No")
      End Get
   End Property

   Public Property TotalDolares() As Decimal
      Get
         Return m_totaldolares
      End Get
      Set(ByVal value As Decimal)
         m_totaldolares = value
      End Set
   End Property

   Public Property ImporteSoles() As Decimal
      Get
         Return m_importesoles
      End Get
      Set(ByVal value As Decimal)
         m_importesoles = value
      End Set
   End Property

   Public Property ImporteDolares() As Decimal
      Get
         Return m_importesdolares
      End Get
      Set(ByVal value As Decimal)
         m_importesdolares = value
      End Set
   End Property

   Public Property TotalSoles() As Decimal
      Get
         Return m_totalsoles
      End Get
      Set(ByVal value As Decimal)
         m_totalsoles = value
      End Set
   End Property

   Public Property IGVSoles() As Decimal
      Get
         Return m_igvsoles
      End Get
      Set(ByVal value As Decimal)
         m_igvsoles = value
      End Set
   End Property

   Public Property TIPOC_VentaSunat() As Decimal
      Get
         Return m_tipoc_ventasunat
      End Get
      Set(ByVal value As Decimal)
         m_tipoc_ventasunat = value
      End Set
   End Property

   Public ReadOnly Property TIPOC_VentaSunat_Text() As String
      Get
         If m_tipoc_ventasunat > 0 Then
            Return m_tipoc_ventasunat.ToString("#,##0.0000")
         Else
            Return ""
         End If
      End Get
   End Property

   Public ReadOnly Property Saldo() As Decimal
      Get
         Return m_docve_totalpagar - m_docve_totalpagado
      End Get
   End Property

   Public Property ImportePagar() As Decimal
      Get
         Return m_importepagar
      End Get
      Set(ByVal value As Decimal)
         m_importepagar = value
      End Set
   End Property

   Public Property TipoDePago() As ETipos.TipoDePago
      Get
         Return m_tpago
      End Get
      Set(ByVal value As ETipos.TipoDePago)
         m_tpago = value
      End Set
   End Property

   'Public Property TESO_Caja() As ETESO_Caja
   '   Get
   '      Return m_teso_caja
   '   End Get
   '   Set(ByVal value As ETESO_Caja)
   '      m_teso_caja = value
   '   End Set
   'End Property

   'Public Property TESO_DocsPagos() As ETESO_DocsPagos
   '   Get
   '      Return m_teso_docspagos
   '   End Get
   '   Set(ByVal value As ETESO_DocsPagos)
   '      m_teso_docspagos = value
   '   End Set
   'End Property

   Public Property TotalPagado() As Decimal
      Get
         Return m_totalpagado
      End Get
      Set(ByVal value As Decimal)
         m_totalpagado = value
      End Set
   End Property

   Public Property TotalPagadoDolares() As Decimal
      Get
         Return m_totalpagadodolares
      End Get
      Set(ByVal value As Decimal)
         m_totalpagadodolares = value
      End Set
   End Property

   Public Property Seleccionar() As Boolean
      Get
         Return m_seleccionar
      End Get
      Set(ByVal value As Boolean)
         m_seleccionar = value
      End Set
   End Property

   Public Property SaldoPendiente() As Decimal
      Get
         Return m_saldopendiente
      End Get
      Set(ByVal value As Decimal)
         m_saldopendiente = value
      End Set
   End Property

   Public Property ARTIC_Codigo() As String
      Get
         Return m_artic_codigo
      End Get
      Set(ByVal value As String)
         m_artic_codigo = value
      End Set
   End Property

   Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         m_artic_descripcion = value
      End Set
   End Property

   Public Property DOCVD_Cantidad() As Decimal
      Get
         Return m_docvd_cantidad
      End Get
      Set(ByVal value As Decimal)
         m_docvd_cantidad = value
      End Set
   End Property

   Public Property DOCVD_PrecioUnitario() As Decimal
      Get
         Return m_docvd_preciounitario
      End Get
      Set(ByVal value As Decimal)
         m_docvd_preciounitario = value
      End Set
   End Property

   Public Property DOCVD_SubImporteVenta() As Decimal
      Get
         Return m_docvd_subimporteventa
      End Get
      Set(ByVal value As Decimal)
         m_docvd_subimporteventa = value
      End Set
   End Property

   Public Property ComisionSoles() As Decimal
      Get
         Return m_comisionsoles
      End Get
      Set(ByVal value As Decimal)
         m_comisionsoles = value
      End Set
   End Property

   Public Property ComisionDolares() As Decimal
      Get
         Return m_comisiondolares
      End Get
      Set(ByVal value As Decimal)
         m_comisiondolares = value
      End Set
   End Property

   Public Property LPREC_Codigo() As String
      Get
         Return m_lprec_codigo
      End Get
      Set(ByVal value As String)
         m_lprec_codigo = value
      End Set
   End Property

   Public Property LPREC_Comision() As Decimal
      Get
         Return m_lprec_comision
      End Get
      Set(ByVal value As Decimal)
         m_lprec_comision = value
      End Set
   End Property

   Public Property COTIZ_Codigo() As String
      Get
         Return m_cotiz_codigo
      End Get
      Set(ByVal value As String)
         m_cotiz_codigo = value
      End Set
   End Property

   Public Property ENTID_CodUsuario() As String
      Get
         Return m_entid_codusuario
      End Get
      Set(ByVal value As String)
         m_entid_codusuario = value
      End Set
   End Property

   Public Property ORDEN_Codigo() As String
      Get
         Return m_orden_codigo
      End Get
      Set(ByVal value As String)
         m_orden_codigo = value
      End Set
   End Property

   Public Property Codigo() As String
      Get
         Return m_codigo
      End Get
      Set(ByVal value As String)
         m_codigo = value
      End Set
   End Property

   Public Property Cotizador() As String
      Get
         Return m_cotizador
      End Get
      Set(ByVal value As String)
         m_cotizador = value
      End Set
   End Property

   Public Property Titulo() As String
      Get
         Return m_titulo
      End Get
      Set(ByVal value As String)
         m_titulo = value
      End Set
   End Property

   Public Property Cargo() As Decimal
      Get
         Return m_cargo
      End Get
      Set(ByVal value As Decimal)
         m_cargo = value
      End Set
   End Property

   Public Property Abono() As Decimal
      Get
         Return m_abono
      End Get
      Set(ByVal value As Decimal)
         m_abono = value
      End Set
   End Property

   Public Property SaldoCta() As Decimal
      Get
         Return m_saldocta
      End Get
      Set(ByVal value As Decimal)
         m_saldocta = value
      End Set
   End Property

   Public Property ENTID_UsrAdmin() As String
      Get
         Return m_entid_usradmin
      End Get
      Set(ByVal value As String)
         m_entid_usradmin = value
      End Set
   End Property

   Public Property TotalVenta() As Decimal
      Get
         Return m_totalventa
      End Get
      Set(ByVal value As Decimal)
         m_totalventa = value
      End Set
   End Property

   Public Property DPAGO_Id() As Long
      Get
         Return m_dpago_id
      End Get
      Set(ByVal value As Long)
         m_dpago_id = value
      End Set
   End Property

   Public Property DPAGO_Numero() As String
      Get
         Return m_dpago_numero
      End Get
      Set(ByVal value As String)
         m_dpago_numero = value
      End Set
   End Property

   Public Property CAJA_Fecha() As DateTime
      Get
         Return m_caja_fecha
      End Get
      Set(ByVal value As DateTime)
         m_caja_fecha = value
      End Set
   End Property

   Public Property TIPOS_TipoPago() As String
      Get
         Return m_tipos_tipopago
      End Get
      Set(ByVal value As String)
         m_tipos_tipopago = value
      End Set
   End Property

   Public Property CAJA_Importe() As Decimal
      Get
         Return m_caja_importe
      End Get
      Set(ByVal value As Decimal)
         m_caja_importe = value
      End Set
   End Property

   Public Property Glosa() As String
      Get
         Return m_glosa
      End Get
      Set(ByVal value As String)
         m_glosa = value
      End Set
   End Property

   Public Property DPAGO_Fecha() As DateTime
      Get
         Return m_dpago_fecha
      End Get
      Set(ByVal value As DateTime)
         m_dpago_fecha = value
      End Set
   End Property

   Public Property DPAGO_Importe() As Decimal
      Get
         Return m_dpago_importe
      End Get
      Set(ByVal value As Decimal)
         m_dpago_importe = value
      End Set
   End Property

   Public Property CAJA_Glosa() As String
      Get
         Return m_caja_glosa
      End Get
      Set(ByVal value As String)
         m_caja_glosa = value
      End Set
   End Property

   Public Property DOCVE_ImportePercepcionDolares() As Decimal
      Get
         Return m_docve_importepercepciondolares
      End Get
      Set(ByVal value As Decimal)
         m_docve_importepercepciondolares = value
      End Set
   End Property

   
   Public Property ENTID_Facturador() As String
      Get
         Return m_entid_facturador
      End Get
      Set(ByVal value As String)
         m_entid_facturador = value
      End Set
   End Property

   Public Property ENTID_Cotizador() As String
      Get
         Return m_entid_cotizador
      End Get
      Set(ByVal value As String)
         m_entid_cotizador = value
      End Set
   End Property

   
   Public Property PendienteSoles() As Decimal
      Get
         Return m_pendientesoles
      End Get
      Set(ByVal value As Decimal)
         m_pendientesoles = value
      End Set
   End Property

   Public Property PendienteDolares() As Decimal
      Get
         Return m_pendientedolares
      End Get
      Set(ByVal value As Decimal)
         m_pendientedolares = value
      End Set
   End Property

   Public Property PercepcionPendiente() As Decimal
      Get
         Return m_percepcionpendiente
      End Get
      Set(ByVal value As Decimal)
         m_percepcionpendiente = value
      End Set
   End Property

   Public Property TotalPendiente() As Decimal
      Get
         Return m_totalpendiente
      End Get
      Set(ByVal value As Decimal)
         m_totalpendiente = value
      End Set
   End Property

   Public Property ImportePendiente() As Decimal
      Get
         Return m_importependiente
      End Get
      Set(ByVal value As Decimal)
         m_importependiente = value
      End Set
   End Property

#End Region

#Region " Constructores "

#End Region

#Region " Metodos "

   Public Shared Function getEstado(ByVal x_opcion As Estado) As String
      Select Case x_opcion
         Case Estado.Anulado
            Return "X"
         Case Estado.Confirmado
            Return "C"
         Case Estado.Eliminado
            Return "E"
         Case Estado.Ingresado
            Return "I"
         Case Else
            Return "I"
      End Select

   End Function

   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New EVENT_DocsVenta()
         cloneInstance = CType(Me, EVENT_DocsVenta)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region


End Class

''' <summary>
''' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''' </summary>
''' <remarks></remarks>


Partial Public Class EVENT_DocsVenta

#Region " Campos "
	
	Private m_docve_codigo As String
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_pedid_codigo As String
	Private m_pvent_id As Long
	Private m_entid_codigocliente As String
	Private m_entid_codigovendedor As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipodocumento As String
	Private m_tipos_codcondicionpago As String
	Private m_tipos_codtipomotivo As String
	Private m_docve_id As Long
	Private m_docve_serie As String
	Private m_docve_numero As Decimal
	Private m_docve_direccioncliente As String
	Private m_docve_descripcioncliente As String
	Private m_docve_fechadocumento As Date
	Private m_docve_fechatransaccion As Date
	Private m_docve_ordencompra As String
	Private m_docve_importeventa As Decimal
	Private m_docve_porcentajeigv As Decimal
	Private m_docve_importeigv As Decimal
	Private m_docve_totalventa As Decimal
	Private m_docve_referencia As String
	Private m_docve_afectopercepcion As Decimal
	Private m_docve_afectopercepcionsoles As Decimal
	Private m_docve_porcentajepercepcion As Decimal
	Private m_docve_importepercepcion As Decimal
	Private m_docve_importepercepcionsoles As Decimal
	Private m_docve_totalpagar As Decimal
	Private m_docve_totalpagado As Decimal
	Private m_docve_totalpeso As Decimal
	Private m_docve_documentopercepcion As Boolean
	Private m_docve_tipocambio As Decimal
	Private m_docve_tipocambiosunat As Decimal
	Private m_docve_estentrega As String
	Private m_docve_observaciones As String
	Private m_docve_notapie As String
	Private m_docve_estado As String
	Private m_docve_guias As String
	Private m_docve_incigv As Boolean
	Private m_docve_plazo As Integer
	Private m_docve_plazofecha As Date
	Private m_docve_dirigida As String
	Private m_docve_nrotelefono As String
	Private m_docve_anuladocaja As Boolean
	Private m_docve_precincivg As Boolean
	Private m_docve_fecanulacion As Date
	Private m_docve_motivo As String
	Private m_docve_stockdevuelto As Boolean
	Private m_docve_motivoanulacion As String
	Private m_entid_codigocotizador As String
	Private m_docve_ncaceptada As Boolean
	Private m_docve_ncpendientecaja As Boolean
	Private m_docve_ncpendientedespachos As Boolean
	Private m_docve_rcrevisado As Boolean
	Private m_docve_rcfecha As Date
	Private m_docve_fechapago As Date
	Private m_rctct_id As Integer
	Private m_docve_pergenguia As Boolean
    Private m_docve_impresiones as Integer
	Private m_docve_usrcrea As String
	Private m_docve_feccrea As Date
	Private m_docve_usrmod As String
	Private m_docve_fecmod As Date
	Private m_docve_rcusrmod As String
	Private m_docve_fpusrmod As String
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
    Private m_eliminado As Boolean
    Private m_referenciado As String
    Private m_cant_adicional As Int32
    Private m_ventasrevision as Boolean


	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlVENT_DocsVenta
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
	
	Public Property DOCVE_Codigo() As String
		Get
			return m_docve_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_codigo) Then
				If Not m_docve_codigo.Equals(value) Then
					m_docve_codigo = value
					OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
				End If
			Else
				m_docve_codigo = value
				OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ZONAS_Codigo() As String
		Get
			return m_zonas_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_zonas_codigo) Then
				If Not m_zonas_codigo.Equals(value) Then
					m_zonas_codigo = value
					OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
				End If
			Else
				m_zonas_codigo = value
				OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property Cant_Pendientes() As Int32
		Get
			return m_cant_adicional
		End Get
		Set(ByVal value As Int32)
			If Not IsNothing(m_cant_adicional) Then
				If Not m_cant_adicional.Equals(value) Then
					m_cant_adicional = value
					OnCant_PendientesChanged(m_cant_adicional, EventArgs.Empty)
				End If
			Else
				m_cant_adicional = value
				OnCant_PendientesChanged(m_cant_adicional, EventArgs.Empty)
			End If
		End Set
	End Property
    Public Property VENTAS_RevisadoControl() As Boolean
		Get
			return m_ventasrevision
		End Get
		Set(ByVal value As Boolean)
			If Not IsNothing(m_ventasrevision) Then
				If Not m_ventasrevision.Equals(value) Then
					m_ventasrevision = value
					OnVENTAS_RevisadoControlChanged(m_ventasrevision, EventArgs.Empty)
				End If
			Else
				m_ventasrevision = value
				OnVENTAS_RevisadoControlChanged(m_ventasrevision, EventArgs.Empty)
			End If
		End Set
	End Property


	Public Property SUCUR_Id() As Short
		Get
			return m_sucur_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_sucur_id) Then
				If Not m_sucur_id.Equals(value) Then
					m_sucur_id = value
					OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
				End If
			Else
				m_sucur_id = value
				OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Codigo() As String
		Get
			return m_pedid_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_codigo) Then
				If Not m_pedid_codigo.Equals(value) Then
					m_pedid_codigo = value
					OnPEDID_CodigoChanged(m_pedid_codigo, EventArgs.Empty)
				End If
			Else
				m_pedid_codigo = value
				OnPEDID_CodigoChanged(m_pedid_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVENT_Id() As Long
		Get
			return m_pvent_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pvent_id) Then
				If Not m_pvent_id.Equals(value) Then
					m_pvent_id = value
					OnPVENT_IdChanged(m_pvent_id, EventArgs.Empty)
				End If
			Else
				m_pvent_id = value
				OnPVENT_IdChanged(m_pvent_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodigoCliente() As String
		Get
			return m_entid_codigocliente
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigocliente) Then
				If Not m_entid_codigocliente.Equals(value) Then
					m_entid_codigocliente = value
					OnENTID_CodigoClienteChanged(m_entid_codigocliente, EventArgs.Empty)
				End If
			Else
				m_entid_codigocliente = value
				OnENTID_CodigoClienteChanged(m_entid_codigocliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodigoVendedor() As String
		Get
			return m_entid_codigovendedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigovendedor) Then
				If Not m_entid_codigovendedor.Equals(value) Then
					m_entid_codigovendedor = value
					OnENTID_CodigoVendedorChanged(m_entid_codigovendedor, EventArgs.Empty)
				End If
			Else
				m_entid_codigovendedor = value
				OnENTID_CodigoVendedorChanged(m_entid_codigovendedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoMoneda() As String
		Get
			return m_tipos_codtipomoneda
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipomoneda) Then
				If Not m_tipos_codtipomoneda.Equals(value) Then
					m_tipos_codtipomoneda = value
					OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipomoneda = value
				OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoDocumento() As String
		Get
			return m_tipos_codtipodocumento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipodocumento) Then
				If Not m_tipos_codtipodocumento.Equals(value) Then
					m_tipos_codtipodocumento = value
					OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipodocumento = value
				OnTIPOS_CodTipoDocumentoChanged(m_tipos_codtipodocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodCondicionPago() As String
		Get
			return m_tipos_codcondicionpago
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codcondicionpago) Then
				If Not m_tipos_codcondicionpago.Equals(value) Then
					m_tipos_codcondicionpago = value
					OnTIPOS_CodCondicionPagoChanged(m_tipos_codcondicionpago, EventArgs.Empty)
				End If
			Else
				m_tipos_codcondicionpago = value
				OnTIPOS_CodCondicionPagoChanged(m_tipos_codcondicionpago, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoMotivo() As String
		Get
			return m_tipos_codtipomotivo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipomotivo) Then
				If Not m_tipos_codtipomotivo.Equals(value) Then
					m_tipos_codtipomotivo = value
					OnTIPOS_CodTipoMotivoChanged(m_tipos_codtipomotivo, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipomotivo = value
				OnTIPOS_CodTipoMotivoChanged(m_tipos_codtipomotivo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Id() As Long
		Get
			return m_docve_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_docve_id) Then
				If Not m_docve_id.Equals(value) Then
					m_docve_id = value
					OnDOCVE_IdChanged(m_docve_id, EventArgs.Empty)
				End If
			Else
				m_docve_id = value
				OnDOCVE_IdChanged(m_docve_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Serie() As String
		Get
			return m_docve_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_serie) Then
				If Not m_docve_serie.Equals(value) Then
					m_docve_serie = value
					OnDOCVE_SerieChanged(m_docve_serie, EventArgs.Empty)
				End If
			Else
				m_docve_serie = value
				OnDOCVE_SerieChanged(m_docve_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Numero() As Decimal
		Get
			return m_docve_numero
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_numero) Then
				If Not m_docve_numero.Equals(value) Then
					m_docve_numero = value
					OnDOCVE_NumeroChanged(m_docve_numero, EventArgs.Empty)
				End If
			Else
				m_docve_numero = value
				OnDOCVE_NumeroChanged(m_docve_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_DireccionCliente() As String
		Get
			return m_docve_direccioncliente
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_direccioncliente) Then
				If Not m_docve_direccioncliente.Equals(value) Then
					m_docve_direccioncliente = value
					OnDOCVE_DireccionClienteChanged(m_docve_direccioncliente, EventArgs.Empty)
				End If
			Else
				m_docve_direccioncliente = value
				OnDOCVE_DireccionClienteChanged(m_docve_direccioncliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_DescripcionCliente() As String
		Get
			return m_docve_descripcioncliente
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_descripcioncliente) Then
				If Not m_docve_descripcioncliente.Equals(value) Then
					m_docve_descripcioncliente = value
					OnDOCVE_DescripcionClienteChanged(m_docve_descripcioncliente, EventArgs.Empty)
				End If
			Else
				m_docve_descripcioncliente = value
				OnDOCVE_DescripcionClienteChanged(m_docve_descripcioncliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_FechaDocumento() As Date
		Get
			return m_docve_fechadocumento
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docve_fechadocumento) Then
				If Not m_docve_fechadocumento.Equals(value) Then
					m_docve_fechadocumento = value
					OnDOCVE_FechaDocumentoChanged(m_docve_fechadocumento, EventArgs.Empty)
				End If
			Else
				m_docve_fechadocumento = value
				OnDOCVE_FechaDocumentoChanged(m_docve_fechadocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_FechaTransaccion() As Date
		Get
			return m_docve_fechatransaccion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docve_fechatransaccion) Then
				If Not m_docve_fechatransaccion.Equals(value) Then
					m_docve_fechatransaccion = value
					OnDOCVE_FechaTransaccionChanged(m_docve_fechatransaccion, EventArgs.Empty)
				End If
			Else
				m_docve_fechatransaccion = value
				OnDOCVE_FechaTransaccionChanged(m_docve_fechatransaccion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_OrdenCompra() As String
		Get
			return m_docve_ordencompra
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_ordencompra) Then
				If Not m_docve_ordencompra.Equals(value) Then
					m_docve_ordencompra = value
					OnDOCVE_OrdenCompraChanged(m_docve_ordencompra, EventArgs.Empty)
				End If
			Else
				m_docve_ordencompra = value
				OnDOCVE_OrdenCompraChanged(m_docve_ordencompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_ImporteVenta() As Decimal
		Get
			return m_docve_importeventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_importeventa) Then
				If Not m_docve_importeventa.Equals(value) Then
					m_docve_importeventa = value
					OnDOCVE_ImporteVentaChanged(m_docve_importeventa, EventArgs.Empty)
				End If
			Else
				m_docve_importeventa = value
				OnDOCVE_ImporteVentaChanged(m_docve_importeventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_PorcentajeIGV() As Decimal
		Get
			return m_docve_porcentajeigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_porcentajeigv) Then
				If Not m_docve_porcentajeigv.Equals(value) Then
					m_docve_porcentajeigv = value
					OnDOCVE_PorcentajeIGVChanged(m_docve_porcentajeigv, EventArgs.Empty)
				End If
			Else
				m_docve_porcentajeigv = value
				OnDOCVE_PorcentajeIGVChanged(m_docve_porcentajeigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_ImporteIgv() As Decimal
		Get
			return m_docve_importeigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_importeigv) Then
				If Not m_docve_importeigv.Equals(value) Then
					m_docve_importeigv = value
					OnDOCVE_ImporteIgvChanged(m_docve_importeigv, EventArgs.Empty)
				End If
			Else
				m_docve_importeigv = value
				OnDOCVE_ImporteIgvChanged(m_docve_importeigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_TotalVenta() As Decimal
		Get
			return m_docve_totalventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_totalventa) Then
				If Not m_docve_totalventa.Equals(value) Then
					m_docve_totalventa = value
					OnDOCVE_TotalVentaChanged(m_docve_totalventa, EventArgs.Empty)
				End If
			Else
				m_docve_totalventa = value
				OnDOCVE_TotalVentaChanged(m_docve_totalventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Referencia() As String
		Get
			return m_docve_referencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_referencia) Then
				If Not m_docve_referencia.Equals(value) Then
					m_docve_referencia = value
					OnDOCVE_ReferenciaChanged(m_docve_referencia, EventArgs.Empty)
				End If
			Else
				m_docve_referencia = value
				OnDOCVE_ReferenciaChanged(m_docve_referencia, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property DOCVE_Referenciado() As String
        Get
            Return m_referenciado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_referenciado) Then
                If Not m_referenciado.Equals(value) Then
                    m_referenciado = value
                    OnDOCVE_ReferenciadoChanged(m_referenciado, EventArgs.Empty)
                End If
            Else
                m_docve_referencia = value
                OnDOCVE_ReferenciadoChanged(m_referenciado, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property DOCVE_AfectoPercepcion() As Decimal
		Get
			return m_docve_afectopercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_afectopercepcion) Then
				If Not m_docve_afectopercepcion.Equals(value) Then
					m_docve_afectopercepcion = value
					OnDOCVE_AfectoPercepcionChanged(m_docve_afectopercepcion, EventArgs.Empty)
				End If
			Else
				m_docve_afectopercepcion = value
				OnDOCVE_AfectoPercepcionChanged(m_docve_afectopercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_AfectoPercepcionSoles() As Decimal
		Get
			return m_docve_afectopercepcionsoles
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_afectopercepcionsoles) Then
				If Not m_docve_afectopercepcionsoles.Equals(value) Then
					m_docve_afectopercepcionsoles = value
					OnDOCVE_AfectoPercepcionSolesChanged(m_docve_afectopercepcionsoles, EventArgs.Empty)
				End If
			Else
				m_docve_afectopercepcionsoles = value
				OnDOCVE_AfectoPercepcionSolesChanged(m_docve_afectopercepcionsoles, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_PorcentajePercepcion() As Decimal
		Get
			return m_docve_porcentajepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_porcentajepercepcion) Then
				If Not m_docve_porcentajepercepcion.Equals(value) Then
					m_docve_porcentajepercepcion = value
					OnDOCVE_PorcentajePercepcionChanged(m_docve_porcentajepercepcion, EventArgs.Empty)
				End If
			Else
				m_docve_porcentajepercepcion = value
				OnDOCVE_PorcentajePercepcionChanged(m_docve_porcentajepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_ImportePercepcion() As Decimal
		Get
			return m_docve_importepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_importepercepcion) Then
				If Not m_docve_importepercepcion.Equals(value) Then
					m_docve_importepercepcion = value
					OnDOCVE_ImportePercepcionChanged(m_docve_importepercepcion, EventArgs.Empty)
				End If
			Else
				m_docve_importepercepcion = value
				OnDOCVE_ImportePercepcionChanged(m_docve_importepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_ImportePercepcionSoles() As Decimal
		Get
			return m_docve_importepercepcionsoles
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_importepercepcionsoles) Then
				If Not m_docve_importepercepcionsoles.Equals(value) Then
					m_docve_importepercepcionsoles = value
					OnDOCVE_ImportePercepcionSolesChanged(m_docve_importepercepcionsoles, EventArgs.Empty)
				End If
			Else
				m_docve_importepercepcionsoles = value
				OnDOCVE_ImportePercepcionSolesChanged(m_docve_importepercepcionsoles, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_TotalPagar() As Decimal
		Get
			return m_docve_totalpagar
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_totalpagar) Then
				If Not m_docve_totalpagar.Equals(value) Then
					m_docve_totalpagar = value
					OnDOCVE_TotalPagarChanged(m_docve_totalpagar, EventArgs.Empty)
				End If
			Else
				m_docve_totalpagar = value
				OnDOCVE_TotalPagarChanged(m_docve_totalpagar, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_TotalPagado() As Decimal
		Get
			return m_docve_totalpagado
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_totalpagado) Then
				If Not m_docve_totalpagado.Equals(value) Then
					m_docve_totalpagado = value
					OnDOCVE_TotalPagadoChanged(m_docve_totalpagado, EventArgs.Empty)
				End If
			Else
				m_docve_totalpagado = value
				OnDOCVE_TotalPagadoChanged(m_docve_totalpagado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_TotalPeso() As Decimal
		Get
			return m_docve_totalpeso
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_totalpeso) Then
				If Not m_docve_totalpeso.Equals(value) Then
					m_docve_totalpeso = value
					OnDOCVE_TotalPesoChanged(m_docve_totalpeso, EventArgs.Empty)
				End If
			Else
				m_docve_totalpeso = value
				OnDOCVE_TotalPesoChanged(m_docve_totalpeso, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_DocumentoPercepcion() As Boolean
		Get
			return m_docve_documentopercepcion
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_documentopercepcion.Equals(value) Then
				m_docve_documentopercepcion = value
				OnDOCVE_DocumentoPercepcionChanged(m_docve_documentopercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_TipoCambio() As Decimal
		Get
			return m_docve_tipocambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_tipocambio) Then
				If Not m_docve_tipocambio.Equals(value) Then
					m_docve_tipocambio = value
					OnDOCVE_TipoCambioChanged(m_docve_tipocambio, EventArgs.Empty)
				End If
			Else
				m_docve_tipocambio = value
				OnDOCVE_TipoCambioChanged(m_docve_tipocambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_TipoCambioSunat() As Decimal
		Get
			return m_docve_tipocambiosunat
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_tipocambiosunat) Then
				If Not m_docve_tipocambiosunat.Equals(value) Then
					m_docve_tipocambiosunat = value
					OnDOCVE_TipoCambioSunatChanged(m_docve_tipocambiosunat, EventArgs.Empty)
				End If
			Else
				m_docve_tipocambiosunat = value
				OnDOCVE_TipoCambioSunatChanged(m_docve_tipocambiosunat, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_EstEntrega() As String
		Get
			return m_docve_estentrega
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_estentrega) Then
				If Not m_docve_estentrega.Equals(value) Then
					m_docve_estentrega = value
					OnDOCVE_EstEntregaChanged(m_docve_estentrega, EventArgs.Empty)
				End If
			Else
				m_docve_estentrega = value
				OnDOCVE_EstEntregaChanged(m_docve_estentrega, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Observaciones() As String
		Get
			return m_docve_observaciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_observaciones) Then
				If Not m_docve_observaciones.Equals(value) Then
					m_docve_observaciones = value
					OnDOCVE_ObservacionesChanged(m_docve_observaciones, EventArgs.Empty)
				End If
			Else
				m_docve_observaciones = value
				OnDOCVE_ObservacionesChanged(m_docve_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_NotaPie() As String
		Get
			return m_docve_notapie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_notapie) Then
				If Not m_docve_notapie.Equals(value) Then
					m_docve_notapie = value
					OnDOCVE_NotaPieChanged(m_docve_notapie, EventArgs.Empty)
				End If
			Else
				m_docve_notapie = value
				OnDOCVE_NotaPieChanged(m_docve_notapie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Estado() As String
		Get
			return m_docve_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_estado) Then
				If Not m_docve_estado.Equals(value) Then
					m_docve_estado = value
					OnDOCVE_EstadoChanged(m_docve_estado, EventArgs.Empty)
				End If
			Else
				m_docve_estado = value
				OnDOCVE_EstadoChanged(m_docve_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Guias() As String
		Get
			return m_docve_guias
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_guias) Then
				If Not m_docve_guias.Equals(value) Then
					m_docve_guias = value
					OnDOCVE_GuiasChanged(m_docve_guias, EventArgs.Empty)
				End If
			Else
				m_docve_guias = value
				OnDOCVE_GuiasChanged(m_docve_guias, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_IncIGV() As Boolean
		Get
			return m_docve_incigv
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_incigv.Equals(value) Then
				m_docve_incigv = value
				OnDOCVE_IncIGVChanged(m_docve_incigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Plazo() As Integer
		Get
			return m_docve_plazo
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_docve_plazo) Then
				If Not m_docve_plazo.Equals(value) Then
					m_docve_plazo = value
					OnDOCVE_PlazoChanged(m_docve_plazo, EventArgs.Empty)
				End If
			Else
				m_docve_plazo = value
				OnDOCVE_PlazoChanged(m_docve_plazo, EventArgs.Empty)
			End If
		End Set
	End Property

    ''impresiones
    Public Property DOCVE_Impresiones() As Integer
		Get
			return m_docve_impresiones
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_docve_impresiones) Then
				If Not m_docve_impresiones.Equals(value) Then
					m_docve_impresiones = value
					OnDOCVE_ImprsionesChanged(m_docve_impresiones, EventArgs.Empty)
				End If
			Else
				m_docve_impresiones = value
				OnDOCVE_ImprsionesChanged(m_docve_impresiones, EventArgs.Empty)
			End If
		End Set
	End Property


	Public Property DOCVE_PlazoFecha() As Date
		Get
			return m_docve_plazofecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docve_plazofecha) Then
				If Not m_docve_plazofecha.Equals(value) Then
					m_docve_plazofecha = value
					OnDOCVE_PlazoFechaChanged(m_docve_plazofecha, EventArgs.Empty)
				End If
			Else
				m_docve_plazofecha = value
				OnDOCVE_PlazoFechaChanged(m_docve_plazofecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Dirigida() As String
		Get
			return m_docve_dirigida
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_dirigida) Then
				If Not m_docve_dirigida.Equals(value) Then
					m_docve_dirigida = value
					OnDOCVE_DirigidaChanged(m_docve_dirigida, EventArgs.Empty)
				End If
			Else
				m_docve_dirigida = value
				OnDOCVE_DirigidaChanged(m_docve_dirigida, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_NroTelefono() As String
		Get
			return m_docve_nrotelefono
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_nrotelefono) Then
				If Not m_docve_nrotelefono.Equals(value) Then
					m_docve_nrotelefono = value
					OnDOCVE_NroTelefonoChanged(m_docve_nrotelefono, EventArgs.Empty)
				End If
			Else
				m_docve_nrotelefono = value
				OnDOCVE_NroTelefonoChanged(m_docve_nrotelefono, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_AnuladoCaja() As Boolean
		Get
			return m_docve_anuladocaja
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_anuladocaja.Equals(value) Then
				m_docve_anuladocaja = value
				OnDOCVE_AnuladoCajaChanged(m_docve_anuladocaja, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_PrecIncIVG() As Boolean
		Get
			return m_docve_precincivg
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_precincivg.Equals(value) Then
				m_docve_precincivg = value
				OnDOCVE_PrecIncIVGChanged(m_docve_precincivg, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_FecAnulacion() As Date
		Get
			return m_docve_fecanulacion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docve_fecanulacion) Then
				If Not m_docve_fecanulacion.Equals(value) Then
					m_docve_fecanulacion = value
					OnDOCVE_FecAnulacionChanged(m_docve_fecanulacion, EventArgs.Empty)
				End If
			Else
				m_docve_fecanulacion = value
				OnDOCVE_FecAnulacionChanged(m_docve_fecanulacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Motivo() As String
		Get
			return m_docve_motivo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_motivo) Then
				If Not m_docve_motivo.Equals(value) Then
					m_docve_motivo = value
					OnDOCVE_MotivoChanged(m_docve_motivo, EventArgs.Empty)
				End If
			Else
				m_docve_motivo = value
				OnDOCVE_MotivoChanged(m_docve_motivo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_StockDevuelto() As Boolean
		Get
			return m_docve_stockdevuelto
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_stockdevuelto.Equals(value) Then
				m_docve_stockdevuelto = value
				OnDOCVE_StockDevueltoChanged(m_docve_stockdevuelto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_MotivoAnulacion() As String
		Get
			return m_docve_motivoanulacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_motivoanulacion) Then
				If Not m_docve_motivoanulacion.Equals(value) Then
					m_docve_motivoanulacion = value
					OnDOCVE_MotivoAnulacionChanged(m_docve_motivoanulacion, EventArgs.Empty)
				End If
			Else
				m_docve_motivoanulacion = value
				OnDOCVE_MotivoAnulacionChanged(m_docve_motivoanulacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodigoCotizador() As String
		Get
			return m_entid_codigocotizador
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigocotizador) Then
				If Not m_entid_codigocotizador.Equals(value) Then
					m_entid_codigocotizador = value
					OnENTID_CodigoCotizadorChanged(m_entid_codigocotizador, EventArgs.Empty)
				End If
			Else
				m_entid_codigocotizador = value
				OnENTID_CodigoCotizadorChanged(m_entid_codigocotizador, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_NCAceptada() As Boolean
		Get
			return m_docve_ncaceptada
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_ncaceptada.Equals(value) Then
				m_docve_ncaceptada = value
				OnDOCVE_NCAceptadaChanged(m_docve_ncaceptada, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_NCPendienteCaja() As Boolean
		Get
			return m_docve_ncpendientecaja
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_ncpendientecaja.Equals(value) Then
				m_docve_ncpendientecaja = value
				OnDOCVE_NCPendienteCajaChanged(m_docve_ncpendientecaja, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_NCPendienteDespachos() As Boolean
		Get
			return m_docve_ncpendientedespachos
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_ncpendientedespachos.Equals(value) Then
				m_docve_ncpendientedespachos = value
				OnDOCVE_NCPendienteDespachosChanged(m_docve_ncpendientedespachos, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_RCRevisado() As Boolean
		Get
			return m_docve_rcrevisado
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_rcrevisado.Equals(value) Then
				m_docve_rcrevisado = value
				OnDOCVE_RCRevisadoChanged(m_docve_rcrevisado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_RCFecha() As Date
		Get
			return m_docve_rcfecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docve_rcfecha) Then
				If Not m_docve_rcfecha.Equals(value) Then
					m_docve_rcfecha = value
					OnDOCVE_RCFechaChanged(m_docve_rcfecha, EventArgs.Empty)
				End If
			Else
				m_docve_rcfecha = value
				OnDOCVE_RCFechaChanged(m_docve_rcfecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_FechaPago() As Date
		Get
			return m_docve_fechapago
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docve_fechapago) Then
				If Not m_docve_fechapago.Equals(value) Then
					m_docve_fechapago = value
					OnDOCVE_FechaPagoChanged(m_docve_fechapago, EventArgs.Empty)
				End If
			Else
				m_docve_fechapago = value
				OnDOCVE_FechaPagoChanged(m_docve_fechapago, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RCTCT_Id() As Integer
		Get
			return m_rctct_id
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_rctct_id) Then
				If Not m_rctct_id.Equals(value) Then
					m_rctct_id = value
					OnRCTCT_IdChanged(m_rctct_id, EventArgs.Empty)
				End If
			Else
				m_rctct_id = value
				OnRCTCT_IdChanged(m_rctct_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_PerGenGuia() As Boolean
		Get
			return m_docve_pergenguia
		End Get
		Set(ByVal value As Boolean)
			If Not m_docve_pergenguia.Equals(value) Then
				m_docve_pergenguia = value
				OnDOCVE_PerGenGuiaChanged(m_docve_pergenguia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_UsrCrea() As String
		Get
			return m_docve_usrcrea
		End Get
		Set(ByVal value As String)
			m_docve_usrcrea = value
		End Set
	End Property

	Public Property DOCVE_FecCrea() As Date
		Get
			return m_docve_feccrea
		End Get
		Set(ByVal value As Date)
			m_docve_feccrea = value
		End Set
	End Property

	Public Property DOCVE_UsrMod() As String
		Get
			return m_docve_usrmod
		End Get
		Set(ByVal value As String)
			m_docve_usrmod = value
		End Set
	End Property

	Public Property DOCVE_FecMod() As Date
		Get
			return m_docve_fecmod
		End Get
		Set(ByVal value As Date)
			m_docve_fecmod = value
		End Set
	End Property

	Public Property DOCVE_RCUsrMod() As String
		Get
			return m_docve_rcusrmod
		End Get
		Set(ByVal value As String)
			m_docve_rcusrmod = value
		End Set
	End Property

	Public Property DOCVE_FPUsrMod() As String
		Get
			return m_docve_fpusrmod
		End Get
		Set(ByVal value As String)
			m_docve_fpusrmod = value
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
			Return "VENT_DocsVenta"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Ventas"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
    Public Event Cant_PendientesChanged As EventHandler
    Public Event VENTAS_RevisadoControlChanged as EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event PEDID_CodigoChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event ENTID_CodigoClienteChanged As EventHandler
	Public Event ENTID_CodigoVendedorChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event TIPOS_CodCondicionPagoChanged As EventHandler
	Public Event TIPOS_CodTipoMotivoChanged As EventHandler
	Public Event DOCVE_IdChanged As EventHandler
	Public Event DOCVE_SerieChanged As EventHandler
	Public Event DOCVE_NumeroChanged As EventHandler
	Public Event DOCVE_DireccionClienteChanged As EventHandler
	Public Event DOCVE_DescripcionClienteChanged As EventHandler
	Public Event DOCVE_FechaDocumentoChanged As EventHandler
	Public Event DOCVE_FechaTransaccionChanged As EventHandler
	Public Event DOCVE_OrdenCompraChanged As EventHandler
	Public Event DOCVE_ImporteVentaChanged As EventHandler
	Public Event DOCVE_PorcentajeIGVChanged As EventHandler
	Public Event DOCVE_ImporteIgvChanged As EventHandler
	Public Event DOCVE_TotalVentaChanged As EventHandler
    Public Event DOCVE_ReferenciaChanged As EventHandler
    Public Event DOCVE_ReferenciadoChanged As EventHandler
	Public Event DOCVE_AfectoPercepcionChanged As EventHandler
	Public Event DOCVE_AfectoPercepcionSolesChanged As EventHandler
	Public Event DOCVE_PorcentajePercepcionChanged As EventHandler
	Public Event DOCVE_ImportePercepcionChanged As EventHandler
	Public Event DOCVE_ImportePercepcionSolesChanged As EventHandler
	Public Event DOCVE_TotalPagarChanged As EventHandler
	Public Event DOCVE_TotalPagadoChanged As EventHandler
	Public Event DOCVE_TotalPesoChanged As EventHandler
	Public Event DOCVE_DocumentoPercepcionChanged As EventHandler
	Public Event DOCVE_TipoCambioChanged As EventHandler
	Public Event DOCVE_TipoCambioSunatChanged As EventHandler
	Public Event DOCVE_EstEntregaChanged As EventHandler
	Public Event DOCVE_ObservacionesChanged As EventHandler
	Public Event DOCVE_NotaPieChanged As EventHandler
	Public Event DOCVE_EstadoChanged As EventHandler
	Public Event DOCVE_GuiasChanged As EventHandler
	Public Event DOCVE_IncIGVChanged As EventHandler
	Public Event DOCVE_PlazoChanged As EventHandler
	Public Event DOCVE_PlazoFechaChanged As EventHandler
	Public Event DOCVE_DirigidaChanged As EventHandler
	Public Event DOCVE_NroTelefonoChanged As EventHandler
	Public Event DOCVE_AnuladoCajaChanged As EventHandler
	Public Event DOCVE_PrecIncIVGChanged As EventHandler
	Public Event DOCVE_FecAnulacionChanged As EventHandler
	Public Event DOCVE_MotivoChanged As EventHandler
	Public Event DOCVE_StockDevueltoChanged As EventHandler
	Public Event DOCVE_MotivoAnulacionChanged As EventHandler
	Public Event ENTID_CodigoCotizadorChanged As EventHandler
	Public Event DOCVE_NCAceptadaChanged As EventHandler
	Public Event DOCVE_NCPendienteCajaChanged As EventHandler
	Public Event DOCVE_NCPendienteDespachosChanged As EventHandler
	Public Event DOCVE_RCRevisadoChanged As EventHandler
	Public Event DOCVE_RCFechaChanged As EventHandler
	Public Event DOCVE_FechaPagoChanged As EventHandler
	Public Event RCTCT_IdChanged As EventHandler
    Public Event DOCVE_ImprsionesChanged as EventHandler
	Public Event DOCVE_PerGenGuiaChanged As EventHandler

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
    
    Public Sub OnCant_PendientesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent Cant_PendientesChanged(sender, e)
	End Sub
    
     Public Sub OnVENTAS_RevisadoControlChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VENTAS_RevisadoControlChanged(sender, e)
	End Sub


	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
    	Public Sub OnDOCVE_ImprsionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_ImprsionesChanged(sender, e)
	End Sub

	Public Sub OnPEDID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoClienteChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoVendedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoVendedorChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodCondicionPagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodCondicionPagoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMotivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMotivoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_IdChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_SerieChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_NumeroChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_DireccionClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_DireccionClienteChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_DescripcionClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_DescripcionClienteChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_FechaDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_FechaDocumentoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_FechaTransaccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_FechaTransaccionChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_OrdenCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_OrdenCompraChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_ImporteVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_ImporteVentaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_PorcentajeIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_PorcentajeIGVChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_ImporteIgvChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_ImporteIgvChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_TotalVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_TotalVentaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_ReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_ReferenciaChanged(sender, e)
	End Sub

    Public Sub OnDOCVE_ReferenciadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_ReferenciadoChanged(sender, e)
    End Sub
	Public Sub OnDOCVE_AfectoPercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_AfectoPercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_AfectoPercepcionSolesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_AfectoPercepcionSolesChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_PorcentajePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_PorcentajePercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_ImportePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_ImportePercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_ImportePercepcionSolesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_ImportePercepcionSolesChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_TotalPagarChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_TotalPagarChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_TotalPagadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_TotalPagadoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_TotalPesoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_TotalPesoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_DocumentoPercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_DocumentoPercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_TipoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_TipoCambioChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_TipoCambioSunatChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_TipoCambioSunatChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_EstEntregaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_EstEntregaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_ObservacionesChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_NotaPieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_NotaPieChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_EstadoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_GuiasChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_GuiasChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_IncIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_IncIGVChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_PlazoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_PlazoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_PlazoFechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_PlazoFechaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_DirigidaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_DirigidaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_NroTelefonoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_NroTelefonoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_AnuladoCajaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_AnuladoCajaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_PrecIncIVGChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_PrecIncIVGChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_FecAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_FecAnulacionChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_MotivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_MotivoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_StockDevueltoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_StockDevueltoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_MotivoAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_MotivoAnulacionChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoCotizadorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoCotizadorChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_NCAceptadaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_NCAceptadaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_NCPendienteCajaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_NCPendienteCajaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_NCPendienteDespachosChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_NCPendienteDespachosChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_RCRevisadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_RCRevisadoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_RCFechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_RCFechaChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_FechaPagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_FechaPagoChanged(sender, e)
	End Sub

	Public Sub OnRCTCT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RCTCT_IdChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_PerGenGuiaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_PerGenGuiaChanged(sender, e)
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

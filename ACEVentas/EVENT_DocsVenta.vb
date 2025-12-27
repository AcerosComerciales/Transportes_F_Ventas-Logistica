Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic


Partial Public Class EVENT_DocsVenta
   Implements ICloneable

#Region " Variables "
   Private m_posicion As Integer

   Private m_listVENT_DocsVentaDetalle As List(Of EVENT_DocsVentaDetalle)
   Private m_listvent_docsrelacion As List(Of EVENT_DocsRelacion)
   Private m_listteso_docspagos As List(Of ETESO_DocsPagos)
   Private m_listvent_docsventa As List(Of EVENT_DocsVenta)
   Private m_listcuadrependientes As List(Of ECCuadrePendientes)

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

   Private m_teso_caja As ETESO_Caja
   Private m_teso_docspagos As ETESO_DocsPagos

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
    Private m_orden_ubigeodestino As String
    Private m_codigo As String
    Private m_observaciones As String '_M

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

    Private m_cantidadcero As Decimal




    

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

   Public Property ListTESO_DocsPagos() As List(Of ETESO_DocsPagos)
      Get
         Return m_listteso_docspagos
      End Get
      Set(ByVal value As List(Of ETESO_DocsPagos))
         m_listteso_docspagos = value
      End Set
   End Property

   Public Property ListVENT_DocsVenta() As List(Of EVENT_DocsVenta)
      Get
         Return m_listvent_docsventa
      End Get
      Set(ByVal value As List(Of EVENT_DocsVenta))
         m_listvent_docsventa = value
      End Set
   End Property

   Public Property ListCuadrePendientes() As List(Of ECCuadrePendientes)
      Get
         Return m_listcuadrependientes
      End Get
      Set(ByVal value As List(Of ECCuadrePendientes))
         m_listcuadrependientes = value
      End Set
   End Property

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
    Public Property Observaciones() As String
        Get
            Return m_observaciones

        End Get
        Set(ByVal value As String)
            m_observaciones = value

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
    Public ReadOnly Property Cantidad_Cero() As Integer
        Get
            Return 0
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

   Public Property TESO_Caja() As ETESO_Caja
      Get
         Return m_teso_caja
      End Get
      Set(ByVal value As ETESO_Caja)
         m_teso_caja = value
      End Set
   End Property

   Public Property TESO_DocsPagos() As ETESO_DocsPagos
      Get
         Return m_teso_docspagos
      End Get
      Set(ByVal value As ETESO_DocsPagos)
         m_teso_docspagos = value
      End Set
   End Property

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

    'Public Property COTIZ_Codigo() As String
    '   Get
    '      Return m_cotiz_codigo
    '   End Get
    '   Set(ByVal value As String)
    '      m_cotiz_codigo = value
    '   End Set
    'End Property

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
    Public Property ORDEN_UbigeoDestino() As String
        Get
            Return m_orden_ubigeodestino
        End Get
        Set(ByVal value As String)
            m_orden_ubigeodestino = value
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

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

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

    '==========================================================
    Private m_docve_rutaid As Long 'Nueva 31-03-2025
    Private m_docve_rutasdescripcion As String 'Hasta aqui 
    Private m_docve_ubigocodigo_origen As String
    Private m_docve_ubigocodigodestino As String
    Private m_vehic_certificado As String
    Private m_docve_direccion_origen As String 'Punto de Venta 

    Private m_docve_direccionpunto_origen As String
    Private m_docve_direccionpunto_destino As String


    '==========================================================
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
    Private m_Condicion As String

    Private m_cotiz_codigo_ As String

    Private m_ventasrevisionUsr as String
    Private m_docvefechaimpresion As DateTime
    Private m_docve_impresa As Boolean

    Private m_ventasrevision2 As Boolean
    '--Private m_Condicion As String
    Private m_ventasrevisionUsr2 As String
    Private m_docvefecrevisado2 As DateTime

    Private m_nrocomprobante As String

    '' para otrdenes
    Private m_estadoentregaorden as string
    Private m_ordenimpresa As Boolean

    ''Detracciones
    Private m_docve_afectodetraccion As Boolean
    Private m_docve_porcentajedetraccion As Decimal
    Private m_docve_importedetraccion As Decimal

    '''Retenciones
    Private m_docve_afectoretencion As Boolean
    Private m_docve_porcentajeretencion As Decimal
    Private m_docve_importeretencion As Decimal

    'R 20-12-2017
    Private m_tipodocumento As String
    Private m_COD_Documento As String
    Private m_COD_Usuario As String
    Private m_Dia As String
    Private m_Mes As String
    Private m_Año As String
    Private m_DireccionPVent As String
    ' Private DOCVE_EstEntrega As String
    Private m_docve_totalrecibido As Decimal

    'F 20240418
    Private m_docve_valorreferencial As Decimal

    Private m_docve_paseanulacion As Boolean
    Private m_docve_usrpaseanulacion As String
    Private m_docve_fechapaseanulacion As Date

    Private m_generado As Decimal

    Private m_hash As Hashtable
#End Region

#Region " Constructores "

    Public Sub New()

        Try
            Dim _obj As Object = ACEVentas.My.Resources.xmlVENT_DocsVenta
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

#Region " Propiedades "

    Public Property DOCVE_Codigo() As String
        Get
            Return m_docve_codigo
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
    Public Property NroComprobante() As String
        Get
            Return m_nrocomprobante
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_nrocomprobante) Then
                If Not m_nrocomprobante.Equals(value) Then
                    m_nrocomprobante = value
                    OnNroComprobanteChanged(m_nrocomprobante, EventArgs.Empty)
                End If
            Else
                m_nrocomprobante = value
                OnNroComprobanteChanged(m_nrocomprobante, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ZONAS_Codigo() As String
        Get
            Return m_zonas_codigo
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
            Return m_cant_adicional
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
    Public Property COTIZ_Codigo() As String
        Get
            Return m_cotiz_codigo_
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_cotiz_codigo_) Then
                If Not m_cotiz_codigo_.Equals(value) Then
                    m_cotiz_codigo_ = value
                    OnCOTIZ_CodigoChanged(m_cotiz_codigo_, EventArgs.Empty)
                End If
            Else
                m_cotiz_codigo_ = value
                OnCOTIZ_CodigoChanged(m_cotiz_codigo_, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCVE_DireccionPuntoOrigen() As String
        Get
            Return m_docve_direccionpunto_origen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docve_direccionpunto_origen) Then
                If Not m_docve_direccionpunto_origen.Equals(value) Then
                    m_docve_direccionpunto_origen = value
                    OnDOCVE_DireccionPuntoOrigenChanged(m_docve_direccionpunto_origen, EventArgs.Empty)
                End If
            Else
                m_docve_direccionpunto_origen = value
                OnDOCVE_DireccionPuntoOrigenChanged(m_docve_direccionpunto_origen, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVE_DireccionPuntoDestino() As String
        Get
            Return m_docve_direccionpunto_destino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docve_direccionpunto_destino) Then
                If Not m_docve_direccionpunto_destino.Equals(value) Then
                    m_docve_direccionpunto_destino = value
                    OnDOCVE_DireccionPuntoDestinoChanged(m_docve_direccionpunto_destino, EventArgs.Empty)
                End If
            Else
                m_docve_direccionpunto_destino = value
                OnDOCVE_DireccionPuntoDestinoChanged(m_docve_direccionpunto_destino, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property VENTAS_RevisadoControl() As Boolean
        Get
            Return m_ventasrevision
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
    Public Property DOCVE_RevisadoControl2() As Boolean
        Get
            Return m_ventasrevision2
        End Get
        Set(ByVal value As Boolean)
            If Not IsNothing(m_ventasrevision2) Then
                If Not m_ventasrevision2.Equals(value) Then
                    m_ventasrevision2 = value
                    OnDOCVE_RevisadoControl2Changed(m_ventasrevision2, EventArgs.Empty)
                End If
            Else
                m_ventasrevision2 = value
                OnDOCVE_RevisadoControl2Changed(m_ventasrevision2, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property VENTAS_Condicion() As String
        Get
            Return m_Condicion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_Condicion) Then
                If Not m_Condicion.Equals(value) Then
                    m_Condicion = value
                    OnVENTAS_CondicionChanged(m_Condicion, EventArgs.Empty)
                End If
            Else
                m_Condicion = value
                OnVENTAS_CondicionChanged(m_Condicion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property VENTAS_RevisadoUsr() As String
        Get
            Return m_ventasrevisionUsr
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ventasrevisionUsr) Then
                If Not m_ventasrevisionUsr.Equals(value) Then
                    m_ventasrevisionUsr = value
                    OnVENTAS_RevisadoUsrChanged(m_ventasrevisionUsr, EventArgs.Empty)
                End If
            Else
                m_ventasrevisionUsr = value
                OnVENTAS_RevisadoUsrChanged(m_ventasrevisionUsr, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVE_RevisadoUsr2() As String
        Get
            Return m_ventasrevisionUsr2
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ventasrevisionUsr2) Then
                If Not m_ventasrevisionUsr2.Equals(value) Then
                    m_ventasrevisionUsr2 = value
                    OnDOCVE_RevisadoUsr2Changed(m_ventasrevisionUsr2, EventArgs.Empty)
                End If
            Else
                m_ventasrevisionUsr2 = value
                OnDOCVE_RevisadoUsr2Changed(m_ventasrevisionUsr2, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property SUCUR_Id() As Short
        Get
            Return m_sucur_id
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
            Return m_pedid_codigo
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
            Return m_pvent_id
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
            Return m_entid_codigocliente
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
            Return m_entid_codigovendedor
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
            Return m_tipos_codtipomoneda
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
            Return m_tipos_codtipodocumento
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
            Return m_tipos_codcondicionpago
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
            Return m_tipos_codtipomotivo
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
            Return m_docve_id
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
            Return m_docve_serie
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
            Return m_docve_numero
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
            Return m_docve_direccioncliente
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
            Return m_docve_descripcioncliente
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


    Public Property DOCVE_FecImpresion() As Date
        Get
            Return m_docvefechaimpresion
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_docvefechaimpresion) Then
                If Not m_docvefechaimpresion.Equals(value) Then
                    m_docvefechaimpresion = value
                    OnDOCVE_FecImpresionChanged(m_docvefechaimpresion, EventArgs.Empty)
                End If
            Else
                m_docve_fechadocumento = value
                OnDOCVE_FecImpresionChanged(m_docvefechaimpresion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVE_FecRevisado2() As Date
        Get
            Return m_docvefecrevisado2
        End Get
        Set(ByVal value As Date)
            If Not IsNothing(m_docvefecrevisado2) Then
                If Not m_docvefecrevisado2.Equals(value) Then
                    m_docvefecrevisado2 = value
                    OnDOCVE_FecRevisado2Changed(m_docvefecrevisado2, EventArgs.Empty)
                End If
            Else
                m_docvefecrevisado2 = value
                OnDOCVE_FecRevisado2Changed(m_docvefecrevisado2, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCVE_FechaDocumento() As Date
        Get
            Return m_docve_fechadocumento
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
            Return m_docve_fechatransaccion
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
            Return m_docve_ordencompra
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
    ''R
    'Public Property RUC() As String
    '    Get
    '        Return m_docve_ordencompra
    '    End Get
    '    Set(ByVal value As String)
    '        If Not IsNothing(m_docve_ordencompra) Then
    '            If Not m_docve_ordencompra.Equals(value) Then
    '                m_docve_ordencompra = value
    '                OnDOCVE_OrdenCompraChanged(m_docve_ordencompra, EventArgs.Empty)
    '            End If
    '        Else
    '            m_docve_ordencompra = value
    '            OnDOCVE_OrdenCompraChanged(m_docve_ordencompra, EventArgs.Empty)
    '        End If
    '    End Set
    'End Property

    Public Property DOCVE_ImporteVenta() As Decimal
        Get
            Return m_docve_importeventa
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
            Return m_docve_porcentajeigv
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
            Return m_docve_importeigv
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
            Return m_docve_totalventa
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
            Return m_docve_referencia
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
            Return m_docve_afectopercepcion
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
            Return m_docve_afectopercepcionsoles
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
            Return m_docve_porcentajepercepcion
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
            Return m_docve_importepercepcion
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
            Return m_docve_importepercepcionsoles
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
            Return m_docve_totalpagar
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
            Return m_docve_totalpagado
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
    Public Property DOCVE_TotalRecibido() As Decimal
        Get
            Return m_docve_totalrecibido
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docve_totalrecibido) Then
                If Not m_docve_totalrecibido.Equals(value) Then
                    m_docve_totalrecibido = value
                    OnDOCVE_TotalRecibidoChanged(m_docve_totalrecibido, EventArgs.Empty)
                End If
            Else
                m_docve_totalrecibido = value
                OnDOCVE_TotalRecibidoChanged(m_docve_totalrecibido, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVE_ValorReferencial() As Decimal
        Get
            Return m_docve_valorreferencial
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docve_valorreferencial) Then
                If Not m_docve_valorreferencial.Equals(value) Then
                    m_docve_valorreferencial = value
                    OnDOCVE_ValorReferencialChanged(m_docve_valorreferencial, EventArgs.Empty)
                End If
            Else
                m_docve_valorreferencial = value
                OnDOCVE_ValorReferencialChanged(m_docve_valorreferencial, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCVE_TotalPeso() As Decimal
        Get
            Return m_docve_totalpeso
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
            Return m_docve_documentopercepcion
        End Get
        Set(ByVal value As Boolean)
            If Not m_docve_documentopercepcion.Equals(value) Then
                m_docve_documentopercepcion = value
                OnDOCVE_DocumentoPercepcionChanged(m_docve_documentopercepcion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVE_AfectoRetencion() As Boolean
        Get
            Return m_docve_afectoretencion
        End Get
        Set(ByVal value As Boolean)
            If Not IsNothing(m_docve_afectoretencion) Then
                If Not m_docve_afectoretencion.Equals(value) Then
                    m_docve_afectoretencion = value
                    OnDOCVE_AfectoRetencionChanged(m_docve_afectoretencion, EventArgs.Empty)
                End If
            Else
                m_docve_afectoretencion = value
                OnDOCVE_AfectoRetencionChanged(m_docve_afectoretencion, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property DOCVE_PorcentajeRetencion() As Decimal
        Get
            Return m_docve_porcentajeretencion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docve_porcentajeretencion) Then
                If Not m_docve_porcentajeretencion.Equals(value) Then
                    m_docve_porcentajeretencion = value
                    OnDOCVE_PorcentajeRetencionChanged(m_docve_porcentajeretencion, EventArgs.Empty)
                End If
            Else
                m_docve_porcentajeretencion = value
                OnDOCVE_PorcentajeRetencionChanged(m_docve_porcentajeretencion, EventArgs.Empty)
            End If
        End Set

    End Property
    Public Property DOCVE_ImporteRetencion() As Decimal
        Get
            Return m_docve_importeretencion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docve_importeretencion) Then
                If Not m_docve_importeretencion.Equals(value) Then
                    m_docve_importeretencion = value
                    OnDOCVE_ImporteRetencionChanged(m_docve_importeretencion, EventArgs.Empty)
                End If
            Else
                m_docve_importeretencion = value
                OnDOCVE_ImporteRetencionChanged(m_docve_importeretencion, EventArgs.Empty)
            End If
        End Set

    End Property

    Public Property DOCVE_TipoCambio() As Decimal
        Get
            Return m_docve_tipocambio
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
            Return m_docve_tipocambiosunat
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
            Return m_docve_estentrega
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
            Return m_docve_observaciones
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
            Return m_docve_notapie
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
            Return m_docve_estado
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
            Return m_docve_guias
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
            Return m_docve_incigv
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
            Return m_docve_plazo
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
            Return m_docve_impresiones
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
    Public Property DOCVE_Impresa() As Boolean
        Get
            Return m_docve_impresa
        End Get
        Set(ByVal value As Boolean)
            If Not m_docve_impresa.Equals(value) Then
                m_docve_impresa = value
                OnDOCVE_ImpresaChanged(m_docve_impresa, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property DOCVE_PlazoFecha() As Date
        Get
            Return m_docve_plazofecha
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
            Return m_docve_dirigida
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
            Return m_docve_nrotelefono
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
            Return m_docve_anuladocaja
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
            Return m_docve_precincivg
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
            Return m_docve_fecanulacion
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
            Return m_docve_motivo
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
            Return m_docve_stockdevuelto
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
            Return m_docve_motivoanulacion
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
            Return m_entid_codigocotizador
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
            Return m_docve_ncaceptada
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
            Return m_docve_ncpendientecaja
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
            Return m_docve_ncpendientedespachos
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
            Return m_docve_rcrevisado
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
            Return m_docve_rcfecha
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
            Return m_docve_fechapago
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
            Return m_rctct_id
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
            Return m_docve_pergenguia
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
            Return m_docve_usrcrea
        End Get
        Set(ByVal value As String)
            m_docve_usrcrea = value
        End Set
    End Property

    Public Property DOCVE_FecCrea() As Date
        Get
            Return m_docve_feccrea
        End Get
        Set(ByVal value As Date)
            m_docve_feccrea = value
        End Set
    End Property

    '
    Public Property DOCVE_DireccionOrigen() As Long
        Get
            Return m_docve_direccion_origen
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_docve_direccion_origen) Then
                If Not m_docve_direccion_origen.Equals(value) Then
                    m_docve_direccion_origen = value
                    OnRUTAS_IdChanged(m_docve_direccion_origen, EventArgs.Empty)
                End If
            Else
                m_docve_direccion_origen = value
                OnRUTAS_IdChanged(m_docve_direccion_origen, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCVE_RUTASId() As Long
        Get
            Return m_docve_rutaid
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_docve_rutaid) Then
                If Not m_docve_rutaid.Equals(value) Then
                    m_docve_rutaid = value
                    OnRUTAS_IdChanged(m_docve_rutaid, EventArgs.Empty)
                End If
            Else
                m_docve_rutasdescripcion = value
                OnRUTAS_IdChanged(m_docve_rutaid, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCVE_RutasDescripcion() As String
        Get
            Return m_docve_rutasdescripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docve_rutasdescripcion) Then
                If Not m_docve_rutasdescripcion.Equals(value) Then
                    m_docve_rutasdescripcion = value
                    OnRutasDescripcionChanged(m_docve_rutasdescripcion, EventArgs.Empty)
                End If
            Else
                m_docve_rutasdescripcion = value
                OnRutasDescripcionChanged(m_docve_rutasdescripcion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property UBIGO_CodigoOrigen() As String
        Get
            Return m_docve_ubigocodigo_origen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docve_ubigocodigo_origen) Then
                If Not m_docve_ubigocodigo_origen.Equals(value) Then
                    m_docve_ubigocodigo_origen = value
                    OnUbigoCodigoOrigenChanged(m_docve_ubigocodigo_origen, EventArgs.Empty)
                End If
            Else
                m_docve_ubigocodigo_origen = value
                OnUbigoCodigoOrigenChanged(m_docve_ubigocodigo_origen, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property UBIGO_CodigoDestino() As String
        Get
            Return m_docve_ubigocodigodestino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docve_ubigocodigodestino) Then
                If Not m_docve_ubigocodigodestino.Equals(value) Then
                    m_docve_ubigocodigodestino = value
                    OnUbigoCodigoDestinoChanged(m_docve_ubigocodigodestino, EventArgs.Empty)
                End If
            Else
                m_docve_ubigocodigodestino = value
                OnUbigoCodigoDestinoChanged(m_docve_ubigocodigodestino, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property VEHIC_Certificado() As String
        Get
            Return m_vehic_certificado
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_vehic_certificado) Then
                If Not m_vehic_certificado.Equals(value) Then
                    m_vehic_certificado = value
                    OnVEHIC_CertificadoChanged(m_vehic_certificado, EventArgs.Empty)
                End If
            Else
                m_vehic_certificado = value
                OnVEHIC_CertificadoChanged(m_vehic_certificado, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DOCVE_UsrMod() As String
        Get
            Return m_docve_usrmod
        End Get
        Set(ByVal value As String)
            m_docve_usrmod = value
        End Set
    End Property

    Public Property DOCVE_FecMod() As Date
        Get
            Return m_docve_fecmod
        End Get
        Set(ByVal value As Date)
            m_docve_fecmod = value
        End Set
    End Property

    Public Property DOCVE_RCUsrMod() As String
        Get
            Return m_docve_rcusrmod
        End Get
        Set(ByVal value As String)
            m_docve_rcusrmod = value
        End Set
    End Property

    Public Property DOCVE_FPUsrMod() As String
        Get
            Return m_docve_fpusrmod
        End Get
        Set(ByVal value As String)
            m_docve_fpusrmod = value
        End Set
    End Property

    'R 20-12-2017
    Public Property tipodocumento() As String
        Get
            Return m_tipodocumento
        End Get
        Set(ByVal value As String)
            m_tipodocumento = value
        End Set
    End Property
    Public Property COD_Documento() As String
        Get
            Return m_COD_Documento
        End Get
        Set(ByVal value As String)
            m_COD_Documento = value
        End Set
    End Property
    Public Property COD_Usuario() As String
        Get
            Return m_COD_Usuario
        End Get
        Set(ByVal value As String)
            m_COD_Usuario = value
        End Set
    End Property
    Public Property Dia() As String
        Get
            Return m_Dia
        End Get
        Set(ByVal value As String)
            m_Dia = value
        End Set
    End Property
    Public Property Mes() As String
        Get
            Return m_Mes
        End Get
        Set(ByVal value As String)
            m_Mes = value
        End Set
    End Property
    Public Property Año() As String
        Get
            Return m_Año
        End Get
        Set(ByVal value As String)
            m_Año = value
        End Set
    End Property
    Public Property DireccionPVenta() As String
        Get
            Return m_DireccionPVent
        End Get
        Set(ByVal value As String)
            m_DireccionPVent = value
        End Set
    End Property

    Public Property ORDEN_EstEntrega() As String
        Get
            Return m_estadoentregaorden
        End Get
        Set(ByVal value As String)
            m_estadoentregaorden = value
        End Set
    End Property

    Public Property ORDEN_Impresa() As Boolean
        Get
            Return m_ordenimpresa
        End Get
        Set(ByVal value As Boolean)
            m_ordenimpresa = value
        End Set
    End Property


    'Public Property DOCVE_EstEntrega() As String
    '    Get
    '        Return m_docve_estentrega
    '    End Get
    '    Set(ByVal value As String)
    '        m_docve_estentrega = value
    '    End Set
    'End Property


    Public Property DOCVE_AfectoDetraccion() As Boolean
        Get
            Return m_docve_afectodetraccion
        End Get
        Set(ByVal value As Boolean)
            If Not m_docve_afectodetraccion.Equals(value) Then
                m_docve_afectodetraccion = value
                OnDOCVE_AfectoDetraccionChanged(m_docve_pergenguia, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVE_PorcentajeDetraccion() As Decimal
        Get
            Return m_docve_porcentajedetraccion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docve_porcentajedetraccion) Then
                If Not m_docve_porcentajedetraccion.Equals(value) Then
                    m_docve_porcentajedetraccion = value
                    OnDOCVE_PorcentajeDetraccionChanged(m_docve_porcentajedetraccion, EventArgs.Empty)
                End If
            Else
                m_docve_porcentajedetraccion = value
                OnDOCVE_PorcentajeDetraccionChanged(m_docve_porcentajedetraccion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVE_ImporteDetraccion() As Decimal
        Get
            Return m_docve_importedetraccion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docve_importedetraccion) Then
                If Not m_docve_importedetraccion.Equals(value) Then
                    m_docve_importedetraccion = value
                    OnDOCVE_ImporteDetraccionChanged(m_docve_importedetraccion, EventArgs.Empty)
                End If
            Else
                m_docve_porcentajedetraccion = value
                OnDOCVE_ImporteDetraccionChanged(m_docve_importedetraccion, EventArgs.Empty)
            End If
        End Set
    End Property
   
    Public Property DOCVE_PaseAnulacion() As Boolean
        Get
            Return m_docve_paseanulacion
        End Get
        Set(ByVal value As Boolean)
            If Not m_docve_paseanulacion.Equals(value) Then
                m_docve_paseanulacion = value
                OnDOCVE_PaseAnulacionChanged(m_docve_paseanulacion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVE_UsrPaseAnulacion() As String
        Get
            Return m_docve_usrpaseanulacion
        End Get
        Set(ByVal value As String)
            m_docve_usrpaseanulacion = value
        End Set
    End Property

    Public Property DOCVE_FechaPaseAnulacion() As Date
        Get
            Return m_docve_fechapaseanulacion
        End Get
        Set(ByVal value As Date)
            m_docve_fechapaseanulacion = value
        End Set
    End Property

    ''impresiones
    Public Property generado() As Integer
        Get
            Return m_generado
        End Get
        Set(ByVal value As Integer)
            m_generado = value
        End Set
    End Property



#Region " Propiedades de Solo Lectura "

    Public ReadOnly Property Nuevo() As Boolean
        Get
            Return m_nuevo
        End Get
    End Property

    Public ReadOnly Property Modificado() As Boolean
        Get
            Return m_modificado
        End Get
    End Property

    Public ReadOnly Property Eliminado() As Boolean
        Get
            Return m_eliminado
        End Get
    End Property

    Public ReadOnly Property Hash() As Hashtable
        Get
            Return m_hash
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
    Public Event COTIZ_CodigoChanged As EventHandler
    Public Event DOCVE_DireccionPuntoOrigenChanged As EventHandler
    Public Event DOCVE_DireccionPuntoDestinoChanged As EventHandler
    Public Event VENTAS_RevisadoControlChanged As EventHandler
    Public Event DOCVE_RevisadoControl2Changed As EventHandler
    Public Event VENTAS_CondicionChanged as EventHandler
    Public Event VENTAS_RevisadoUsrChanged As EventHandler
    Public Event DOCVE_RevisadoUsr2Changed As EventHandler
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
    Public Event DOCVE_FecImpresionChanged As EventHandler
    Public Event DOCVE_FecRevisado2Changed As EventHandler
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
    Public Event DOCVE_ImpresaChanged As EventHandler
    Public Event NroComprobanteChanged As EventHandler

    Public Event DOCVE_TotalRecibidoChanged As EventHandler
    Public Event DOCVE_ValorReferencialChanged As EventHandler

    Public Event DOCVE_AfectoDetraccionChanged As EventHandler
    Public Event DOCVE_PorcentajeDetraccionChanged As EventHandler
    Public Event DOCVE_ImporteDetraccionChanged As EventHandler

    Public Event DOCVE_AfectoRetencionChanged As EventHandler
    Public Event DOCVE_PorcentajeRetencionChanged As EventHandler
    Public Event DOCVE_ImporteRetencionChanged As EventHandler


    Public Event RUTAS_IdChanged As EventHandler
    Public Event DOCVE_DireccionOrigenChanged As EventHandler
    Public Event RutasDescripcionChanged As EventHandler
    Public Event UbigoCodigoOrigenChanged As EventHandler
    Public Event UbigoCodigoDestinoChanged As EventHandler
    Public Event VEHIC_CertificadoChanged As EventHandler

    Public Event DOCVE_PaseAnulacionChanged As EventHandler

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
    End Sub
    Public Sub OnNroComprobanteChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent NroComprobanteChanged(sender, e)
    End Sub


	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

    Public Sub OnCant_PendientesChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent Cant_PendientesChanged(sender, e)
    End Sub
    Public Sub OnCOTIZ_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent COTIZ_CodigoChanged(sender, e)
    End Sub

    Public Sub OnDOCVE_DireccionPuntoOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_DireccionPuntoOrigenChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_DireccionPuntoDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_DireccionPuntoDestinoChanged(sender, e)
    End Sub


    Public Sub OnVENTAS_RevisadoControlChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VENTAS_RevisadoControlChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_RevisadoControl2Changed(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_RevisadoControl2Changed(sender, e)
    End Sub

     Public Sub OnVENTAS_CondicionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VENTAS_CondicionChanged(sender, e)
	End Sub
    
    Public Sub OnVENTAS_RevisadoUsrChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VENTAS_RevisadoUsrChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_RevisadoUsr2Changed(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_RevisadoUsr2Changed(sender, e)
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
    
    Public Sub OnDOCVE_FecImpresionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_FecImpresionChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_FecRevisado2Changed(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_FecRevisado2Changed(sender, e)
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

    Public Sub OnDOCVE_TotalRecibidoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_TotalRecibidoChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_ValorReferencialChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_ValorReferencialChanged(sender, e)
    End Sub

    Public Sub OnDOCVE_TotalPesoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_TotalPesoChanged(sender, e)
	End Sub

    Public Sub OnDOCVE_DocumentoPercepcionChanged(ByVal sender As Object, ByVal e As EventArgs)
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

    Public Sub OnDOCVE_AfectoDetraccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_AfectoDetraccionChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_PorcentajeDetraccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_PorcentajeDetraccionChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_ImporteDetraccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_ImporteDetraccionChanged(sender, e)
    End Sub

    Public Sub OnDOCVE_AfectoRetencionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_AfectoRetencionChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_PorcentajeRetencionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_PorcentajeRetencionChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_ImporteRetencionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_ImporteRetencionChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_PaseAnulacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_PaseAnulacionChanged(sender, e)
    End Sub
    Public Sub OnDOCVE_ImpresaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_ImpresaChanged(sender, e)
    End Sub
    'Nuevas columnas +++


    Public Sub OnRUTAS_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent RUTAS_IdChanged(sender, e)
    End Sub

    Public Sub OnDOCVE_DireccionOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_DireccionOrigenChanged(sender, e)
    End Sub

    Public Sub OnRutasDescripcionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent RutasDescripcionChanged(sender, e)
    End Sub
    Public Sub OnUbigoCodigoOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent UbigoCodigoOrigenChanged(sender, e)
    End Sub
    Public Sub OnUbigoCodigoDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent UbigoCodigoDestinoChanged(sender, e)
    End Sub
    Public Sub OnVEHIC_CertificadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent VEHIC_CertificadoChanged(sender, e)
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


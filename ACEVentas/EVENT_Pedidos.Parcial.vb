Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVENT_Pedidos

#Region " Campos "
	
	Private m_pedid_codigo As String
	Private m_pvent_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_docve_codigo As String
	Private m_entid_codigocliente As String
	Private m_entid_codigovendedor As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipodocumento As String
	Private m_tipos_codcondicionpago As String
	Private m_pedid_id As Long
	Private m_docve_percepcioncliente As Decimal
	Private m_pedid_descripcioncliente As String
	Private m_pedid_direccioncliente As String
	Private m_pedid_numero As Integer
	Private m_pedid_fechadocumento As Date
	Private m_pedid_fechatransaccion As Date
	Private m_pedid_ordencompra As String
	Private m_pedid_importeventa As Decimal
	Private m_pedid_porcentajeigv As Decimal
	Private m_pedid_importeigv As Decimal
	Private m_pedid_totalventa As Decimal
	Private m_pedid_afectopercepcion As Decimal
	Private m_pedid_porcentajepercepcion As Decimal
	Private m_pedid_importepercepcion As Decimal
	Private m_pedid_impdocpercepcion As Decimal
	Private m_pedid_totalpagar As Decimal
	Private m_pedid_totalpeso As Decimal
	Private m_pedid_documentopercepcion As Boolean
	Private m_pedid_tipocambio As Decimal
	Private m_pedid_tipocambiosunat As Decimal
	Private m_pedid_listaespecial As String
	Private m_pedid_listapredeterminada As String
	Private m_pedid_tipo As String
	Private m_pedid_parafacturar As Boolean
	Private m_pedid_estentrega As String
	Private m_pedid_observaciones As String
	Private m_pedid_estado As String
	Private m_pedid_plazo As Integer
	Private m_pedid_dirigida As String
	Private m_pedid_numerooc As String
	Private m_pedid_nrotelefono As String
	Private m_pedid_plazofecha As Date
	Private m_pedid_stocklocal As Decimal
	Private m_pedid_stockprincipal As Decimal
	Private m_pedid_promedioventas As Decimal
	Private m_pedid_generarguia As Boolean
	Private m_pedid_codrelacionado As String
	Private m_pvent_idrelacionado As Long
	Private m_almac_idrelacionado As Short
	Private m_pedid_email As String
	Private m_pedid_condiciones As String
	Private m_pedid_condicionentrega As String
	Private m_pedid_nota As String
	Private m_pedid_modreporte As Boolean
	Private m_pedid_afectopercepcionsoles As Decimal
	Private m_pedid_importepercepcionsoles As Decimal
	Private m_pedid_tcofcompra As Decimal
	Private m_pvent_idorigen As Long
	Private m_pvent_iddestinopreposicion As Long
	Private m_pvent_idorigenpreposicion As Long
	Private m_pedid_fechaanulacion As Date
	Private m_pedid_motivoanulacion As String
	Private m_pedid_anuladocaja As Boolean
	Private m_pedid_fechaentrega As Date
	Private m_entid_codigosolicitante As String
	Private m_pedid_usrcrea As String
	Private m_pedid_feccrea As Date
    Private m_pedid_usrmod As String
    Private m_pedid_usrmodificador As String
	Private m_pedid_fecmod As Date
    Private m_impresiones As Integer

    Private m_pedid_afectoretencion As Boolean
    Private m_pedid_porcentajeretencion As Decimal
    Private m_pedid_importeretencion As Decimal

    Private m_pedid_afectodetraccion As Boolean
    Private m_pedid_porcentajedetraccion As Decimal
    Private m_pedid_importedetraccion As Decimal

    Private m_pedid_paseanulacion As Boolean
    Private m_pedid_usrpaseanulacion As String
    Private m_pedid_fechapaseanulacion As Date

	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlVENT_Pedidos
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
    	Public Property PEDID_Impresiones() As Integer
		Get
			return m_impresiones
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_impresiones) Then
				If Not m_impresiones.Equals(value) Then
					m_impresiones = value
					OnPEDID_CodigoChanged(m_impresiones, EventArgs.Empty)
				End If
			Else
				m_impresiones = value
				OnPEDID_CodigoChanged(m_impresiones, EventArgs.Empty)
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

	Public Property PEDID_Id() As Long
		Get
			return m_pedid_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pedid_id) Then
				If Not m_pedid_id.Equals(value) Then
					m_pedid_id = value
					OnPEDID_IdChanged(m_pedid_id, EventArgs.Empty)
				End If
			Else
				m_pedid_id = value
				OnPEDID_IdChanged(m_pedid_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_PercepcionCliente() As Decimal
		Get
			return m_docve_percepcioncliente
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docve_percepcioncliente) Then
				If Not m_docve_percepcioncliente.Equals(value) Then
					m_docve_percepcioncliente = value
					OnDOCVE_PercepcionClienteChanged(m_docve_percepcioncliente, EventArgs.Empty)
				End If
			Else
				m_docve_percepcioncliente = value
				OnDOCVE_PercepcionClienteChanged(m_docve_percepcioncliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_DescripcionCliente() As String
		Get
			return m_pedid_descripcioncliente
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_descripcioncliente) Then
				If Not m_pedid_descripcioncliente.Equals(value) Then
					m_pedid_descripcioncliente = value
					OnPEDID_DescripcionClienteChanged(m_pedid_descripcioncliente, EventArgs.Empty)
				End If
			Else
				m_pedid_descripcioncliente = value
				OnPEDID_DescripcionClienteChanged(m_pedid_descripcioncliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_DireccionCliente() As String
		Get
			return m_pedid_direccioncliente
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_direccioncliente) Then
				If Not m_pedid_direccioncliente.Equals(value) Then
					m_pedid_direccioncliente = value
					OnPEDID_DireccionClienteChanged(m_pedid_direccioncliente, EventArgs.Empty)
				End If
			Else
				m_pedid_direccioncliente = value
				OnPEDID_DireccionClienteChanged(m_pedid_direccioncliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Numero() As Integer
		Get
			return m_pedid_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_pedid_numero) Then
				If Not m_pedid_numero.Equals(value) Then
					m_pedid_numero = value
					OnPEDID_NumeroChanged(m_pedid_numero, EventArgs.Empty)
				End If
			Else
				m_pedid_numero = value
				OnPEDID_NumeroChanged(m_pedid_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_FechaDocumento() As Date
		Get
			return m_pedid_fechadocumento
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_pedid_fechadocumento) Then
				If Not m_pedid_fechadocumento.Equals(value) Then
					m_pedid_fechadocumento = value
					OnPEDID_FechaDocumentoChanged(m_pedid_fechadocumento, EventArgs.Empty)
				End If
			Else
				m_pedid_fechadocumento = value
				OnPEDID_FechaDocumentoChanged(m_pedid_fechadocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_FechaTransaccion() As Date
		Get
			return m_pedid_fechatransaccion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_pedid_fechatransaccion) Then
				If Not m_pedid_fechatransaccion.Equals(value) Then
					m_pedid_fechatransaccion = value
					OnPEDID_FechaTransaccionChanged(m_pedid_fechatransaccion, EventArgs.Empty)
				End If
			Else
				m_pedid_fechatransaccion = value
				OnPEDID_FechaTransaccionChanged(m_pedid_fechatransaccion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_OrdenCompra() As String
		Get
			return m_pedid_ordencompra
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_ordencompra) Then
				If Not m_pedid_ordencompra.Equals(value) Then
					m_pedid_ordencompra = value
					OnPEDID_OrdenCompraChanged(m_pedid_ordencompra, EventArgs.Empty)
				End If
			Else
				m_pedid_ordencompra = value
				OnPEDID_OrdenCompraChanged(m_pedid_ordencompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ImporteVenta() As Decimal
		Get
			return m_pedid_importeventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_importeventa) Then
				If Not m_pedid_importeventa.Equals(value) Then
					m_pedid_importeventa = value
					OnPEDID_ImporteVentaChanged(m_pedid_importeventa, EventArgs.Empty)
				End If
			Else
				m_pedid_importeventa = value
				OnPEDID_ImporteVentaChanged(m_pedid_importeventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_PorcentajeIGV() As Decimal
		Get
			return m_pedid_porcentajeigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_porcentajeigv) Then
				If Not m_pedid_porcentajeigv.Equals(value) Then
					m_pedid_porcentajeigv = value
					OnPEDID_PorcentajeIGVChanged(m_pedid_porcentajeigv, EventArgs.Empty)
				End If
			Else
				m_pedid_porcentajeigv = value
				OnPEDID_PorcentajeIGVChanged(m_pedid_porcentajeigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ImporteIGV() As Decimal
		Get
			return m_pedid_importeigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_importeigv) Then
				If Not m_pedid_importeigv.Equals(value) Then
					m_pedid_importeigv = value
					OnPEDID_ImporteIGVChanged(m_pedid_importeigv, EventArgs.Empty)
				End If
			Else
				m_pedid_importeigv = value
				OnPEDID_ImporteIGVChanged(m_pedid_importeigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_TotalVenta() As Decimal
		Get
			return m_pedid_totalventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_totalventa) Then
				If Not m_pedid_totalventa.Equals(value) Then
					m_pedid_totalventa = value
					OnPEDID_TotalVentaChanged(m_pedid_totalventa, EventArgs.Empty)
				End If
			Else
				m_pedid_totalventa = value
				OnPEDID_TotalVentaChanged(m_pedid_totalventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_AfectoPercepcion() As Decimal
		Get
			return m_pedid_afectopercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_afectopercepcion) Then
				If Not m_pedid_afectopercepcion.Equals(value) Then
					m_pedid_afectopercepcion = value
					OnPEDID_AfectoPercepcionChanged(m_pedid_afectopercepcion, EventArgs.Empty)
				End If
			Else
				m_pedid_afectopercepcion = value
				OnPEDID_AfectoPercepcionChanged(m_pedid_afectopercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_PorcentajePercepcion() As Decimal
		Get
			return m_pedid_porcentajepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_porcentajepercepcion) Then
				If Not m_pedid_porcentajepercepcion.Equals(value) Then
					m_pedid_porcentajepercepcion = value
					OnPEDID_PorcentajePercepcionChanged(m_pedid_porcentajepercepcion, EventArgs.Empty)
				End If
			Else
				m_pedid_porcentajepercepcion = value
				OnPEDID_PorcentajePercepcionChanged(m_pedid_porcentajepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ImportePercepcion() As Decimal
		Get
			return m_pedid_importepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_importepercepcion) Then
				If Not m_pedid_importepercepcion.Equals(value) Then
					m_pedid_importepercepcion = value
					OnPEDID_ImportePercepcionChanged(m_pedid_importepercepcion, EventArgs.Empty)
				End If
			Else
				m_pedid_importepercepcion = value
				OnPEDID_ImportePercepcionChanged(m_pedid_importepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ImpDocPercepcion() As Decimal
		Get
			return m_pedid_impdocpercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_impdocpercepcion) Then
				If Not m_pedid_impdocpercepcion.Equals(value) Then
					m_pedid_impdocpercepcion = value
					OnPEDID_ImpDocPercepcionChanged(m_pedid_impdocpercepcion, EventArgs.Empty)
				End If
			Else
				m_pedid_impdocpercepcion = value
				OnPEDID_ImpDocPercepcionChanged(m_pedid_impdocpercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_TotalPagar() As Decimal
		Get
			return m_pedid_totalpagar
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_totalpagar) Then
				If Not m_pedid_totalpagar.Equals(value) Then
					m_pedid_totalpagar = value
					OnPEDID_TotalPagarChanged(m_pedid_totalpagar, EventArgs.Empty)
				End If
			Else
				m_pedid_totalpagar = value
				OnPEDID_TotalPagarChanged(m_pedid_totalpagar, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_TotalPeso() As Decimal
		Get
			return m_pedid_totalpeso
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_totalpeso) Then
				If Not m_pedid_totalpeso.Equals(value) Then
					m_pedid_totalpeso = value
					OnPEDID_TotalPesoChanged(m_pedid_totalpeso, EventArgs.Empty)
				End If
			Else
				m_pedid_totalpeso = value
				OnPEDID_TotalPesoChanged(m_pedid_totalpeso, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_DocumentoPercepcion() As Boolean
		Get
			return m_pedid_documentopercepcion
		End Get
		Set(ByVal value As Boolean)
			If Not m_pedid_documentopercepcion.Equals(value) Then
				m_pedid_documentopercepcion = value
				OnPEDID_DocumentoPercepcionChanged(m_pedid_documentopercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_TipoCambio() As Decimal
		Get
			return m_pedid_tipocambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_tipocambio) Then
				If Not m_pedid_tipocambio.Equals(value) Then
					m_pedid_tipocambio = value
					OnPEDID_TipoCambioChanged(m_pedid_tipocambio, EventArgs.Empty)
				End If
			Else
				m_pedid_tipocambio = value
				OnPEDID_TipoCambioChanged(m_pedid_tipocambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_TipoCambioSunat() As Decimal
		Get
			return m_pedid_tipocambiosunat
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_tipocambiosunat) Then
				If Not m_pedid_tipocambiosunat.Equals(value) Then
					m_pedid_tipocambiosunat = value
					OnPEDID_TipoCambioSunatChanged(m_pedid_tipocambiosunat, EventArgs.Empty)
				End If
			Else
				m_pedid_tipocambiosunat = value
				OnPEDID_TipoCambioSunatChanged(m_pedid_tipocambiosunat, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ListaEspecial() As String
		Get
			return m_pedid_listaespecial
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_listaespecial) Then
				If Not m_pedid_listaespecial.Equals(value) Then
					m_pedid_listaespecial = value
					OnPEDID_ListaEspecialChanged(m_pedid_listaespecial, EventArgs.Empty)
				End If
			Else
				m_pedid_listaespecial = value
				OnPEDID_ListaEspecialChanged(m_pedid_listaespecial, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ListaPredeterminada() As String
		Get
			return m_pedid_listapredeterminada
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_listapredeterminada) Then
				If Not m_pedid_listapredeterminada.Equals(value) Then
					m_pedid_listapredeterminada = value
					OnPEDID_ListaPredeterminadaChanged(m_pedid_listapredeterminada, EventArgs.Empty)
				End If
			Else
				m_pedid_listapredeterminada = value
				OnPEDID_ListaPredeterminadaChanged(m_pedid_listapredeterminada, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Tipo() As String
		Get
			return m_pedid_tipo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_tipo) Then
				If Not m_pedid_tipo.Equals(value) Then
					m_pedid_tipo = value
					OnPEDID_TipoChanged(m_pedid_tipo, EventArgs.Empty)
				End If
			Else
				m_pedid_tipo = value
				OnPEDID_TipoChanged(m_pedid_tipo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ParaFacturar() As Boolean
		Get
			return m_pedid_parafacturar
		End Get
		Set(ByVal value As Boolean)
			If Not m_pedid_parafacturar.Equals(value) Then
				m_pedid_parafacturar = value
				OnPEDID_ParaFacturarChanged(m_pedid_parafacturar, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_EstEntrega() As String
		Get
			return m_pedid_estentrega
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_estentrega) Then
				If Not m_pedid_estentrega.Equals(value) Then
					m_pedid_estentrega = value
					OnPEDID_EstEntregaChanged(m_pedid_estentrega, EventArgs.Empty)
				End If
			Else
				m_pedid_estentrega = value
				OnPEDID_EstEntregaChanged(m_pedid_estentrega, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Observaciones() As String
		Get
			return m_pedid_observaciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_observaciones) Then
				If Not m_pedid_observaciones.Equals(value) Then
					m_pedid_observaciones = value
					OnPEDID_ObservacionesChanged(m_pedid_observaciones, EventArgs.Empty)
				End If
			Else
				m_pedid_observaciones = value
				OnPEDID_ObservacionesChanged(m_pedid_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Estado() As String
		Get
			return m_pedid_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_estado) Then
				If Not m_pedid_estado.Equals(value) Then
					m_pedid_estado = value
					OnPEDID_EstadoChanged(m_pedid_estado, EventArgs.Empty)
				End If
			Else
				m_pedid_estado = value
				OnPEDID_EstadoChanged(m_pedid_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Plazo() As Integer
		Get
			return m_pedid_plazo
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_pedid_plazo) Then
				If Not m_pedid_plazo.Equals(value) Then
					m_pedid_plazo = value
					OnPEDID_PlazoChanged(m_pedid_plazo, EventArgs.Empty)
				End If
			Else
				m_pedid_plazo = value
				OnPEDID_PlazoChanged(m_pedid_plazo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Dirigida() As String
		Get
			return m_pedid_dirigida
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_dirigida) Then
				If Not m_pedid_dirigida.Equals(value) Then
					m_pedid_dirigida = value
					OnPEDID_DirigidaChanged(m_pedid_dirigida, EventArgs.Empty)
				End If
			Else
				m_pedid_dirigida = value
				OnPEDID_DirigidaChanged(m_pedid_dirigida, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_NumeroOC() As String
		Get
			return m_pedid_numerooc
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_numerooc) Then
				If Not m_pedid_numerooc.Equals(value) Then
					m_pedid_numerooc = value
					OnPEDID_NumeroOCChanged(m_pedid_numerooc, EventArgs.Empty)
				End If
			Else
				m_pedid_numerooc = value
				OnPEDID_NumeroOCChanged(m_pedid_numerooc, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_NroTelefono() As String
		Get
			return m_pedid_nrotelefono
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_nrotelefono) Then
				If Not m_pedid_nrotelefono.Equals(value) Then
					m_pedid_nrotelefono = value
					OnPEDID_NroTelefonoChanged(m_pedid_nrotelefono, EventArgs.Empty)
				End If
			Else
				m_pedid_nrotelefono = value
				OnPEDID_NroTelefonoChanged(m_pedid_nrotelefono, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_PlazoFecha() As Date
		Get
			return m_pedid_plazofecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_pedid_plazofecha) Then
				If Not m_pedid_plazofecha.Equals(value) Then
					m_pedid_plazofecha = value
					OnPEDID_PlazoFechaChanged(m_pedid_plazofecha, EventArgs.Empty)
				End If
			Else
				m_pedid_plazofecha = value
				OnPEDID_PlazoFechaChanged(m_pedid_plazofecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_StockLocal() As Decimal
		Get
			return m_pedid_stocklocal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_stocklocal) Then
				If Not m_pedid_stocklocal.Equals(value) Then
					m_pedid_stocklocal = value
					OnPEDID_StockLocalChanged(m_pedid_stocklocal, EventArgs.Empty)
				End If
			Else
				m_pedid_stocklocal = value
				OnPEDID_StockLocalChanged(m_pedid_stocklocal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_StockPrincipal() As Decimal
		Get
			return m_pedid_stockprincipal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_stockprincipal) Then
				If Not m_pedid_stockprincipal.Equals(value) Then
					m_pedid_stockprincipal = value
					OnPEDID_StockPrincipalChanged(m_pedid_stockprincipal, EventArgs.Empty)
				End If
			Else
				m_pedid_stockprincipal = value
				OnPEDID_StockPrincipalChanged(m_pedid_stockprincipal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_PromedioVentas() As Decimal
		Get
			return m_pedid_promedioventas
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_promedioventas) Then
				If Not m_pedid_promedioventas.Equals(value) Then
					m_pedid_promedioventas = value
					OnPEDID_PromedioVentasChanged(m_pedid_promedioventas, EventArgs.Empty)
				End If
			Else
				m_pedid_promedioventas = value
				OnPEDID_PromedioVentasChanged(m_pedid_promedioventas, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_GenerarGuia() As Boolean
		Get
			return m_pedid_generarguia
		End Get
		Set(ByVal value As Boolean)
			If Not m_pedid_generarguia.Equals(value) Then
				m_pedid_generarguia = value
				OnPEDID_GenerarGuiaChanged(m_pedid_generarguia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_CodRelacionado() As String
		Get
			return m_pedid_codrelacionado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_codrelacionado) Then
				If Not m_pedid_codrelacionado.Equals(value) Then
					m_pedid_codrelacionado = value
					OnPEDID_CodRelacionadoChanged(m_pedid_codrelacionado, EventArgs.Empty)
				End If
			Else
				m_pedid_codrelacionado = value
				OnPEDID_CodRelacionadoChanged(m_pedid_codrelacionado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVENT_IdRelacionado() As Long
		Get
			return m_pvent_idrelacionado
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pvent_idrelacionado) Then
				If Not m_pvent_idrelacionado.Equals(value) Then
					m_pvent_idrelacionado = value
					OnPVENT_IdRelacionadoChanged(m_pvent_idrelacionado, EventArgs.Empty)
				End If
			Else
				m_pvent_idrelacionado = value
				OnPVENT_IdRelacionadoChanged(m_pvent_idrelacionado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALMAC_IdRelacionado() As Short
		Get
			return m_almac_idrelacionado
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_almac_idrelacionado) Then
				If Not m_almac_idrelacionado.Equals(value) Then
					m_almac_idrelacionado = value
					OnALMAC_IdRelacionadoChanged(m_almac_idrelacionado, EventArgs.Empty)
				End If
			Else
				m_almac_idrelacionado = value
				OnALMAC_IdRelacionadoChanged(m_almac_idrelacionado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_EMail() As String
		Get
			return m_pedid_email
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_email) Then
				If Not m_pedid_email.Equals(value) Then
					m_pedid_email = value
					OnPEDID_EMailChanged(m_pedid_email, EventArgs.Empty)
				End If
			Else
				m_pedid_email = value
				OnPEDID_EMailChanged(m_pedid_email, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Condiciones() As String
		Get
			return m_pedid_condiciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_condiciones) Then
				If Not m_pedid_condiciones.Equals(value) Then
					m_pedid_condiciones = value
					OnPEDID_CondicionesChanged(m_pedid_condiciones, EventArgs.Empty)
				End If
			Else
				m_pedid_condiciones = value
				OnPEDID_CondicionesChanged(m_pedid_condiciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_CondicionEntrega() As String
		Get
			return m_pedid_condicionentrega
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_condicionentrega) Then
				If Not m_pedid_condicionentrega.Equals(value) Then
					m_pedid_condicionentrega = value
					OnPEDID_CondicionEntregaChanged(m_pedid_condicionentrega, EventArgs.Empty)
				End If
			Else
				m_pedid_condicionentrega = value
				OnPEDID_CondicionEntregaChanged(m_pedid_condicionentrega, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Nota() As String
		Get
			return m_pedid_nota
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_nota) Then
				If Not m_pedid_nota.Equals(value) Then
					m_pedid_nota = value
					OnPEDID_NotaChanged(m_pedid_nota, EventArgs.Empty)
				End If
			Else
				m_pedid_nota = value
				OnPEDID_NotaChanged(m_pedid_nota, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ModReporte() As Boolean
		Get
			return m_pedid_modreporte
		End Get
		Set(ByVal value As Boolean)
			If Not m_pedid_modreporte.Equals(value) Then
				m_pedid_modreporte = value
				OnPEDID_ModReporteChanged(m_pedid_modreporte, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_AfectoPercepcionSoles() As Decimal
		Get
			return m_pedid_afectopercepcionsoles
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_afectopercepcionsoles) Then
				If Not m_pedid_afectopercepcionsoles.Equals(value) Then
					m_pedid_afectopercepcionsoles = value
					OnPEDID_AfectoPercepcionSolesChanged(m_pedid_afectopercepcionsoles, EventArgs.Empty)
				End If
			Else
				m_pedid_afectopercepcionsoles = value
				OnPEDID_AfectoPercepcionSolesChanged(m_pedid_afectopercepcionsoles, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_ImportePercepcionSoles() As Decimal
		Get
			return m_pedid_importepercepcionsoles
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_importepercepcionsoles) Then
				If Not m_pedid_importepercepcionsoles.Equals(value) Then
					m_pedid_importepercepcionsoles = value
					OnPEDID_ImportePercepcionSolesChanged(m_pedid_importepercepcionsoles, EventArgs.Empty)
				End If
			Else
				m_pedid_importepercepcionsoles = value
				OnPEDID_ImportePercepcionSolesChanged(m_pedid_importepercepcionsoles, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_TCOfCompra() As Decimal
		Get
			return m_pedid_tcofcompra
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_tcofcompra) Then
				If Not m_pedid_tcofcompra.Equals(value) Then
					m_pedid_tcofcompra = value
					OnPEDID_TCOfCompraChanged(m_pedid_tcofcompra, EventArgs.Empty)
				End If
			Else
				m_pedid_tcofcompra = value
				OnPEDID_TCOfCompraChanged(m_pedid_tcofcompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVENT_IdOrigen() As Long
		Get
			return m_pvent_idorigen
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pvent_idorigen) Then
				If Not m_pvent_idorigen.Equals(value) Then
					m_pvent_idorigen = value
					OnPVENT_IdOrigenChanged(m_pvent_idorigen, EventArgs.Empty)
				End If
			Else
				m_pvent_idorigen = value
				OnPVENT_IdOrigenChanged(m_pvent_idorigen, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVENT_IdDestinoPReposicion() As Long
		Get
			return m_pvent_iddestinopreposicion
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pvent_iddestinopreposicion) Then
				If Not m_pvent_iddestinopreposicion.Equals(value) Then
					m_pvent_iddestinopreposicion = value
					OnPVENT_IdDestinoPReposicionChanged(m_pvent_iddestinopreposicion, EventArgs.Empty)
				End If
			Else
				m_pvent_iddestinopreposicion = value
				OnPVENT_IdDestinoPReposicionChanged(m_pvent_iddestinopreposicion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVENT_IdOrigenPReposicion() As Long
		Get
			return m_pvent_idorigenpreposicion
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pvent_idorigenpreposicion) Then
				If Not m_pvent_idorigenpreposicion.Equals(value) Then
					m_pvent_idorigenpreposicion = value
					OnPVENT_IdOrigenPReposicionChanged(m_pvent_idorigenpreposicion, EventArgs.Empty)
				End If
			Else
				m_pvent_idorigenpreposicion = value
				OnPVENT_IdOrigenPReposicionChanged(m_pvent_idorigenpreposicion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_FechaAnulacion() As Date
		Get
			return m_pedid_fechaanulacion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_pedid_fechaanulacion) Then
				If Not m_pedid_fechaanulacion.Equals(value) Then
					m_pedid_fechaanulacion = value
					OnPEDID_FechaAnulacionChanged(m_pedid_fechaanulacion, EventArgs.Empty)
				End If
			Else
				m_pedid_fechaanulacion = value
				OnPEDID_FechaAnulacionChanged(m_pedid_fechaanulacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_MotivoAnulacion() As String
		Get
			return m_pedid_motivoanulacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_motivoanulacion) Then
				If Not m_pedid_motivoanulacion.Equals(value) Then
					m_pedid_motivoanulacion = value
					OnPEDID_MotivoAnulacionChanged(m_pedid_motivoanulacion, EventArgs.Empty)
				End If
			Else
				m_pedid_motivoanulacion = value
				OnPEDID_MotivoAnulacionChanged(m_pedid_motivoanulacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_AnuladoCaja() As Boolean
		Get
			return m_pedid_anuladocaja
		End Get
		Set(ByVal value As Boolean)
			If Not m_pedid_anuladocaja.Equals(value) Then
				m_pedid_anuladocaja = value
				OnPEDID_AnuladoCajaChanged(m_pedid_anuladocaja, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_FechaEntrega() As Date
		Get
			return m_pedid_fechaentrega
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_pedid_fechaentrega) Then
				If Not m_pedid_fechaentrega.Equals(value) Then
					m_pedid_fechaentrega = value
					OnPEDID_FechaEntregaChanged(m_pedid_fechaentrega, EventArgs.Empty)
				End If
			Else
				m_pedid_fechaentrega = value
				OnPEDID_FechaEntregaChanged(m_pedid_fechaentrega, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_CodigoSolicitante() As String
		Get
			return m_entid_codigosolicitante
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigosolicitante) Then
				If Not m_entid_codigosolicitante.Equals(value) Then
					m_entid_codigosolicitante = value
					OnENTID_CodigoSolicitanteChanged(m_entid_codigosolicitante, EventArgs.Empty)
				End If
			Else
				m_entid_codigosolicitante = value
				OnENTID_CodigoSolicitanteChanged(m_entid_codigosolicitante, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_UsrCrea() As String
		Get
			return m_pedid_usrcrea
		End Get
		Set(ByVal value As String)
			m_pedid_usrcrea = value
		End Set
    End Property


    Public Property UsuarioModi() As String
        Get
            Return m_pedid_usrmodificador
        End Get
        Set(ByVal value As String)
            m_pedid_usrmodificador = value
        End Set
    End Property



	Public Property PEDID_FecCrea() As Date
		Get
			return m_pedid_feccrea
		End Get
		Set(ByVal value As Date)
			m_pedid_feccrea = value
		End Set
	End Property

	Public Property PEDID_UsrMod() As String
		Get
			return m_pedid_usrmod
		End Get
		Set(ByVal value As String)
			m_pedid_usrmod = value
		End Set
	End Property

	Public Property PEDID_FecMod() As Date
		Get
			return m_pedid_fecmod
		End Get
		Set(ByVal value As Date)
			m_pedid_fecmod = value
		End Set
    End Property
    Public Property PEDID_AfectoRetencion() As Boolean
        Get
            Return m_pedid_afectoretencion
        End Get
        Set(ByVal value As Boolean)
            If Not m_pedid_afectoretencion.Equals(value) Then
                m_pedid_afectoretencion = value
                OnPEDID_AfectoRetencionChanged(m_pedid_afectoretencion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property PEDID_PorcentajeRetencion() As Decimal
        Get
            Return m_pedid_porcentajeretencion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_pedid_porcentajeretencion) Then
                If Not m_pedid_porcentajeretencion.Equals(value) Then
                    m_pedid_porcentajeretencion = value
                    OnPEDID_PorcentajeRetencionChanged(m_pedid_porcentajeretencion, EventArgs.Empty)
                End If
            Else
                m_pedid_porcentajeretencion = value
                OnPEDID_PorcentajeRetencionChanged(m_pedid_porcentajeretencion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property PEDID_ImporteRetencion() As Decimal
        Get
            Return m_pedid_importeretencion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_pedid_importeretencion) Then
                If Not m_pedid_importeretencion.Equals(value) Then
                    m_pedid_importeretencion = value
                    OnPEDID_ImporteRetencionChanged(m_pedid_importeretencion, EventArgs.Empty)
                End If
            Else
                m_pedid_importeretencion = value
                OnPEDID_ImporteRetencionChanged(m_pedid_importeretencion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property PEDID_AfectoDetraccion() As Boolean
        Get
            Return m_pedid_afectodetraccion
        End Get
        Set(ByVal value As Boolean)
            If Not m_pedid_afectodetraccion.Equals(value) Then
                m_pedid_afectodetraccion = value
                OnPEDID_AfectoDetraccionChanged(m_pedid_afectodetraccion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property PEDID_PorcentajeDetraccion() As Decimal
        Get
            Return m_pedid_porcentajedetraccion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_pedid_porcentajedetraccion) Then
                If Not m_pedid_porcentajedetraccion.Equals(value) Then
                    m_pedid_porcentajedetraccion = value
                    OnPEDID_PorcentajeDetraccionChanged(m_pedid_porcentajedetraccion, EventArgs.Empty)
                End If
            Else
                m_pedid_porcentajedetraccion = value
                OnPEDID_PorcentajeDetraccionChanged(m_pedid_porcentajedetraccion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property PEDID_ImporteDetraccion() As Decimal
        Get
            Return m_pedid_importedetraccion
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_pedid_importedetraccion) Then
                If Not m_pedid_importedetraccion.Equals(value) Then
                    m_pedid_importedetraccion = value
                    OnPEDID_ImporteDetraccionChanged(m_pedid_importedetraccion, EventArgs.Empty)
                End If
            Else
                m_pedid_importedetraccion = value
                OnPEDID_ImporteDetraccionChanged(m_pedid_importedetraccion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property PEDID_PaseAnulacion() As Boolean
        Get
            Return m_pedid_paseanulacion
        End Get
        Set(ByVal value As Boolean)
            If Not m_pedid_paseanulacion.Equals(value) Then
                m_pedid_paseanulacion = value
                OnPEDID_PaseAnulacionChanged(m_pedid_paseanulacion, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property PEDID_UsrPaseAnulacion() As String
        Get
            Return m_pedid_usrpaseanulacion
        End Get
        Set(ByVal value As String)
            m_pedid_usrpaseanulacion = value
        End Set
    End Property

    Public Property PEDID_FechaPaseAnulacion() As Date
        Get
            Return m_pedid_fechapaseanulacion
        End Get
        Set(ByVal value As Date)
            m_pedid_fechapaseanulacion = value
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
			Return "VENT_Pedidos"
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
	
	Public Event PEDID_CodigoChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event ENTID_CodigoClienteChanged As EventHandler
	Public Event ENTID_CodigoVendedorChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event TIPOS_CodCondicionPagoChanged As EventHandler
	Public Event PEDID_IdChanged As EventHandler
	Public Event DOCVE_PercepcionClienteChanged As EventHandler
	Public Event PEDID_DescripcionClienteChanged As EventHandler
	Public Event PEDID_DireccionClienteChanged As EventHandler
	Public Event PEDID_NumeroChanged As EventHandler
	Public Event PEDID_FechaDocumentoChanged As EventHandler
	Public Event PEDID_FechaTransaccionChanged As EventHandler
	Public Event PEDID_OrdenCompraChanged As EventHandler
	Public Event PEDID_ImporteVentaChanged As EventHandler
	Public Event PEDID_PorcentajeIGVChanged As EventHandler
	Public Event PEDID_ImporteIGVChanged As EventHandler
	Public Event PEDID_TotalVentaChanged As EventHandler
	Public Event PEDID_AfectoPercepcionChanged As EventHandler
	Public Event PEDID_PorcentajePercepcionChanged As EventHandler
	Public Event PEDID_ImportePercepcionChanged As EventHandler
	Public Event PEDID_ImpDocPercepcionChanged As EventHandler
	Public Event PEDID_TotalPagarChanged As EventHandler
	Public Event PEDID_TotalPesoChanged As EventHandler
	Public Event PEDID_DocumentoPercepcionChanged As EventHandler
	Public Event PEDID_TipoCambioChanged As EventHandler
	Public Event PEDID_TipoCambioSunatChanged As EventHandler
	Public Event PEDID_ListaEspecialChanged As EventHandler
	Public Event PEDID_ListaPredeterminadaChanged As EventHandler
	Public Event PEDID_TipoChanged As EventHandler
	Public Event PEDID_ParaFacturarChanged As EventHandler
	Public Event PEDID_EstEntregaChanged As EventHandler
	Public Event PEDID_ObservacionesChanged As EventHandler
	Public Event PEDID_EstadoChanged As EventHandler
	Public Event PEDID_PlazoChanged As EventHandler
	Public Event PEDID_DirigidaChanged As EventHandler
	Public Event PEDID_NumeroOCChanged As EventHandler
	Public Event PEDID_NroTelefonoChanged As EventHandler
	Public Event PEDID_PlazoFechaChanged As EventHandler
	Public Event PEDID_StockLocalChanged As EventHandler
	Public Event PEDID_StockPrincipalChanged As EventHandler
	Public Event PEDID_PromedioVentasChanged As EventHandler
	Public Event PEDID_GenerarGuiaChanged As EventHandler
	Public Event PEDID_CodRelacionadoChanged As EventHandler
	Public Event PVENT_IdRelacionadoChanged As EventHandler
	Public Event ALMAC_IdRelacionadoChanged As EventHandler
	Public Event PEDID_EMailChanged As EventHandler
	Public Event PEDID_CondicionesChanged As EventHandler
	Public Event PEDID_CondicionEntregaChanged As EventHandler
	Public Event PEDID_NotaChanged As EventHandler
	Public Event PEDID_ModReporteChanged As EventHandler
	Public Event PEDID_AfectoPercepcionSolesChanged As EventHandler
	Public Event PEDID_ImportePercepcionSolesChanged As EventHandler
	Public Event PEDID_TCOfCompraChanged As EventHandler
	Public Event PVENT_IdOrigenChanged As EventHandler
	Public Event PVENT_IdDestinoPReposicionChanged As EventHandler
	Public Event PVENT_IdOrigenPReposicionChanged As EventHandler
	Public Event PEDID_FechaAnulacionChanged As EventHandler
	Public Event PEDID_MotivoAnulacionChanged As EventHandler
	Public Event PEDID_AnuladoCajaChanged As EventHandler
	Public Event PEDID_FechaEntregaChanged As EventHandler
	Public Event ENTID_CodigoSolicitanteChanged As EventHandler
    Public Event PEDID_ImpresionesChanged As EventHandler

    Public Event PEDID_AfectoRetencionChanged As EventHandler
    Public Event PEDID_PorcentajeRetencionChanged As EventHandler
    Public Event PEDID_ImporteRetencionChanged As EventHandler

    Public Event PEDID_AfectoDetraccionChanged As EventHandler
    Public Event PEDID_PorcentajeDetraccionChanged As EventHandler
    Public Event PEDID_ImporteDetraccionChanged As EventHandler

    Public Event PEDID_PaseAnulacionChanged As EventHandler


	Public Sub OnPEDID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

    Public Sub OnPEDID_ImpresionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ImpresionesChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
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

	Public Sub OnPEDID_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_IdChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_PercepcionClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_PercepcionClienteChanged(sender, e)
	End Sub

	Public Sub OnPEDID_DescripcionClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_DescripcionClienteChanged(sender, e)
	End Sub

	Public Sub OnPEDID_DireccionClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_DireccionClienteChanged(sender, e)
	End Sub

	Public Sub OnPEDID_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_NumeroChanged(sender, e)
	End Sub

	Public Sub OnPEDID_FechaDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FechaDocumentoChanged(sender, e)
	End Sub

	Public Sub OnPEDID_FechaTransaccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FechaTransaccionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_OrdenCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_OrdenCompraChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ImporteVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ImporteVentaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_PorcentajeIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_PorcentajeIGVChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ImporteIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ImporteIGVChanged(sender, e)
	End Sub

	Public Sub OnPEDID_TotalVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_TotalVentaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_AfectoPercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_AfectoPercepcionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_PorcentajePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_PorcentajePercepcionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ImportePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ImportePercepcionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ImpDocPercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ImpDocPercepcionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_TotalPagarChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_TotalPagarChanged(sender, e)
	End Sub

	Public Sub OnPEDID_TotalPesoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_TotalPesoChanged(sender, e)
	End Sub

	Public Sub OnPEDID_DocumentoPercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_DocumentoPercepcionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_TipoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_TipoCambioChanged(sender, e)
	End Sub

	Public Sub OnPEDID_TipoCambioSunatChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_TipoCambioSunatChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ListaEspecialChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ListaEspecialChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ListaPredeterminadaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ListaPredeterminadaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_TipoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_TipoChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ParaFacturarChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ParaFacturarChanged(sender, e)
	End Sub

	Public Sub OnPEDID_EstEntregaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_EstEntregaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ObservacionesChanged(sender, e)
	End Sub

	Public Sub OnPEDID_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_EstadoChanged(sender, e)
	End Sub

	Public Sub OnPEDID_PlazoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_PlazoChanged(sender, e)
	End Sub

	Public Sub OnPEDID_DirigidaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_DirigidaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_NumeroOCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_NumeroOCChanged(sender, e)
	End Sub

	Public Sub OnPEDID_NroTelefonoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_NroTelefonoChanged(sender, e)
	End Sub

	Public Sub OnPEDID_PlazoFechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_PlazoFechaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_StockLocalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_StockLocalChanged(sender, e)
	End Sub

	Public Sub OnPEDID_StockPrincipalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_StockPrincipalChanged(sender, e)
	End Sub

	Public Sub OnPEDID_PromedioVentasChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_PromedioVentasChanged(sender, e)
	End Sub

	Public Sub OnPEDID_GenerarGuiaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_GenerarGuiaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_CodRelacionadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CodRelacionadoChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdRelacionadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdRelacionadoChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdRelacionadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdRelacionadoChanged(sender, e)
	End Sub

	Public Sub OnPEDID_EMailChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_EMailChanged(sender, e)
	End Sub

	Public Sub OnPEDID_CondicionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CondicionesChanged(sender, e)
	End Sub

	Public Sub OnPEDID_CondicionEntregaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CondicionEntregaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_NotaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_NotaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ModReporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ModReporteChanged(sender, e)
	End Sub

	Public Sub OnPEDID_AfectoPercepcionSolesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_AfectoPercepcionSolesChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ImportePercepcionSolesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ImportePercepcionSolesChanged(sender, e)
	End Sub

	Public Sub OnPEDID_TCOfCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_TCOfCompraChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdOrigenChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdDestinoPReposicionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdDestinoPReposicionChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdOrigenPReposicionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdOrigenPReposicionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_FechaAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FechaAnulacionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_MotivoAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_MotivoAnulacionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_AnuladoCajaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_AnuladoCajaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_FechaEntregaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FechaEntregaChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoSolicitanteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoSolicitanteChanged(sender, e)
	End Sub

    Public Sub OnPEDID_AfectoRetencionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PEDID_AfectoRetencionChanged(sender, e)
    End Sub

    Public Sub OnPEDID_PorcentajeRetencionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PEDID_PorcentajeRetencionChanged(sender, e)
    End Sub

    Public Sub OnPEDID_ImporteRetencionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PEDID_ImporteRetencionChanged(sender, e)
    End Sub

    Public Sub OnPEDID_AfectoDetraccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PEDID_AfectoDetraccionChanged(sender, e)
    End Sub

    Public Sub OnPEDID_PorcentajeDetraccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PEDID_PorcentajeDetraccionChanged(sender, e)
    End Sub

    Public Sub OnPEDID_ImporteDetraccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PEDID_ImporteDetraccionChanged(sender, e)
    End Sub

    Public Sub OnPEDID_PaseAnulacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PEDID_PaseAnulacionChanged(sender, e)
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


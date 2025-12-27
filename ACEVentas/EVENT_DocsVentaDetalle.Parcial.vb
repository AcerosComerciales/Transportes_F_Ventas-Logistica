Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EVENT_DocsVentaDetalle

#Region " Campos "
	
	Private m_docve_codigo As String
	Private m_docvd_item As Short
	Private m_zonas_codigo As String
	Private m_lprec_id As Long
	Private m_almac_id As Short
	Private m_artic_codigo As String
	Private m_docvd_percepcion As Boolean
	Private m_docvd_costounitario As Decimal
	Private m_docvd_pesounitario As Decimal
	Private m_docvd_preciounitario As Decimal
	Private m_docvd_cantidad As Decimal
	Private m_docvd_unidad As String
	Private m_docvd_detalle As String
	Private m_docvd_saldo As Decimal
	Private m_docvd_subimporteventa As Decimal
	Private m_docvd_subimportepercepcion As Decimal
	Private m_docvd_subtotal As Decimal
	Private m_docve_codigoreferencia As String
	Private m_docvd_precventaoriginal As Decimal
	Private m_docvd_precioventa As Decimal
	Private m_docvd_porcentaje As Decimal
	Private m_docvd_fecemision As Date
	Private m_docvd_importe As Decimal
	Private m_docvd_montototal As Decimal
	Private m_docvd_estado As String
	Private m_docvd_precincigv As Decimal
	Private m_docvd_preciounitarioprecincigv As Decimal
	Private m_tmp As Decimal
	Private m_docvd_cantidaddevolver As Decimal
	Private m_artic_codigocambio As String
	Private m_docvd_cantidadcambio As Decimal
	Private m_docvd_codigocambio As Integer
	Private m_docvd_costounitariodolares As Decimal
	Private m_docvd_costounitariosoles As Decimal
	Private m_docvd_tipocambiocosto As Decimal
	Private m_docvd_usrcrea As String
	Private m_docvd_feccrea As Date
	Private m_docvd_usrmod As String
	Private m_docvd_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
    Private m_estadoentregaOR As String
    Private m_docvd_fecalmacen As Date
    Private m_docvd_cantidadentregada As Decimal
    Private m_docvd_usuarioalmacen As String
    Private m_docvd_motivo As String

    Private m_docvd_valorreferencial As Decimal

    'Private m_docvd_estalmacen As String
    
    Private m_hash As Hashtable

    Private m_nrocomprobante As String

    'R
    Private m_tipos_desccorta As String

    Private m_tipos_documento As String
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlVENT_DocsVentaDetalle
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

	Public Property DOCVD_Item() As Short
		Get
			return m_docvd_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_docvd_item) Then
				If Not m_docvd_item.Equals(value) Then
					m_docvd_item = value
					OnDOCVD_ItemChanged(m_docvd_item, EventArgs.Empty)
				End If
			Else
				m_docvd_item = value
				OnDOCVD_ItemChanged(m_docvd_item, EventArgs.Empty)
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

	Public Property LPREC_Id() As Long
		Get
			return m_lprec_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_lprec_id) Then
				If Not m_lprec_id.Equals(value) Then
					m_lprec_id = value
					OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
				End If
			Else
				m_lprec_id = value
				OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ALMAC_Id() As Short
		Get
			return m_almac_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_almac_id) Then
				If Not m_almac_id.Equals(value) Then
					m_almac_id = value
					OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
				End If
			Else
				m_almac_id = value
				OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Codigo() As String
		Get
			return m_artic_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_codigo) Then
				If Not m_artic_codigo.Equals(value) Then
					m_artic_codigo = value
					OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
				End If
			Else
				m_artic_codigo = value
				OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Percepcion() As Boolean
		Get
			return m_docvd_percepcion
		End Get
		Set(ByVal value As Boolean)
			If Not m_docvd_percepcion.Equals(value) Then
				m_docvd_percepcion = value
				OnDOCVD_PercepcionChanged(m_docvd_percepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CostoUnitario() As Decimal
		Get
			return m_docvd_costounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_costounitario) Then
				If Not m_docvd_costounitario.Equals(value) Then
					m_docvd_costounitario = value
					OnDOCVD_CostoUnitarioChanged(m_docvd_costounitario, EventArgs.Empty)
				End If
			Else
				m_docvd_costounitario = value
				OnDOCVD_CostoUnitarioChanged(m_docvd_costounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PesoUnitario() As Decimal
		Get
			return m_docvd_pesounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_pesounitario) Then
				If Not m_docvd_pesounitario.Equals(value) Then
					m_docvd_pesounitario = value
					OnDOCVD_PesoUnitarioChanged(m_docvd_pesounitario, EventArgs.Empty)
				End If
			Else
				m_docvd_pesounitario = value
				OnDOCVD_PesoUnitarioChanged(m_docvd_pesounitario, EventArgs.Empty)
			End If
		End Set
	End Property

     Public ReadOnly Property SubPeso_() As Decimal
        Get
            Return m_docvd_cantidad * m_docvd_pesounitario
        End Get
    End Property


	Public Property DOCVD_PrecioUnitario() As Decimal
		Get
			return m_docvd_preciounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_preciounitario) Then
				If Not m_docvd_preciounitario.Equals(value) Then
					m_docvd_preciounitario = value
					OnDOCVD_PrecioUnitarioChanged(m_docvd_preciounitario, EventArgs.Empty)
				End If
			Else
				m_docvd_preciounitario = value
				OnDOCVD_PrecioUnitarioChanged(m_docvd_preciounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Cantidad() As Decimal
		Get
			return m_docvd_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_cantidad) Then
				If Not m_docvd_cantidad.Equals(value) Then
					m_docvd_cantidad = value
					OnDOCVD_CantidadChanged(m_docvd_cantidad, EventArgs.Empty)
				End If
			Else
				m_docvd_cantidad = value
				OnDOCVD_CantidadChanged(m_docvd_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Unidad() As String
		Get
			return m_docvd_unidad
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docvd_unidad) Then
				If Not m_docvd_unidad.Equals(value) Then
					m_docvd_unidad = value
					OnDOCVD_UnidadChanged(m_docvd_unidad, EventArgs.Empty)
				End If
			Else
				m_docvd_unidad = value
				OnDOCVD_UnidadChanged(m_docvd_unidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Detalle() As String
		Get
			return m_docvd_detalle
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docvd_detalle) Then
				If Not m_docvd_detalle.Equals(value) Then
					m_docvd_detalle = value
					OnDOCVD_DetalleChanged(m_docvd_detalle, EventArgs.Empty)
				End If
			Else
				m_docvd_detalle = value
				OnDOCVD_DetalleChanged(m_docvd_detalle, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Saldo() As Decimal
		Get
			return m_docvd_saldo
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_saldo) Then
				If Not m_docvd_saldo.Equals(value) Then
					m_docvd_saldo = value
					OnDOCVD_SaldoChanged(m_docvd_saldo, EventArgs.Empty)
				End If
			Else
				m_docvd_saldo = value
				OnDOCVD_SaldoChanged(m_docvd_saldo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_SubImporteVenta() As Decimal
		Get
			return m_docvd_subimporteventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_subimporteventa) Then
				If Not m_docvd_subimporteventa.Equals(value) Then
					m_docvd_subimporteventa = value
					OnDOCVD_SubImporteVentaChanged(m_docvd_subimporteventa, EventArgs.Empty)
				End If
			Else
				m_docvd_subimporteventa = value
				OnDOCVD_SubImporteVentaChanged(m_docvd_subimporteventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_SubImportePercepcion() As Decimal
		Get
			return m_docvd_subimportepercepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_subimportepercepcion) Then
				If Not m_docvd_subimportepercepcion.Equals(value) Then
					m_docvd_subimportepercepcion = value
					OnDOCVD_SubImportePercepcionChanged(m_docvd_subimportepercepcion, EventArgs.Empty)
				End If
			Else
				m_docvd_subimportepercepcion = value
				OnDOCVD_SubImportePercepcionChanged(m_docvd_subimportepercepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_SubTotal() As Decimal
		Get
			return m_docvd_subtotal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_subtotal) Then
				If Not m_docvd_subtotal.Equals(value) Then
					m_docvd_subtotal = value
					OnDOCVD_SubTotalChanged(m_docvd_subtotal, EventArgs.Empty)
				End If
			Else
				m_docvd_subtotal = value
				OnDOCVD_SubTotalChanged(m_docvd_subtotal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_CodigoReferencia() As String
		Get
			return m_docve_codigoreferencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_codigoreferencia) Then
				If Not m_docve_codigoreferencia.Equals(value) Then
					m_docve_codigoreferencia = value
					OnDOCVE_CodigoReferenciaChanged(m_docve_codigoreferencia, EventArgs.Empty)
				End If
			Else
				m_docve_codigoreferencia = value
				OnDOCVE_CodigoReferenciaChanged(m_docve_codigoreferencia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PrecVentaOriginal() As Decimal
		Get
			return m_docvd_precventaoriginal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_precventaoriginal) Then
				If Not m_docvd_precventaoriginal.Equals(value) Then
					m_docvd_precventaoriginal = value
					OnDOCVD_PrecVentaOriginalChanged(m_docvd_precventaoriginal, EventArgs.Empty)
				End If
			Else
				m_docvd_precventaoriginal = value
				OnDOCVD_PrecVentaOriginalChanged(m_docvd_precventaoriginal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PrecioVenta() As Decimal
		Get
			return m_docvd_precioventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_precioventa) Then
				If Not m_docvd_precioventa.Equals(value) Then
					m_docvd_precioventa = value
					OnDOCVD_PrecioVentaChanged(m_docvd_precioventa, EventArgs.Empty)
				End If
			Else
				m_docvd_precioventa = value
				OnDOCVD_PrecioVentaChanged(m_docvd_precioventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Porcentaje() As Decimal
		Get
			return m_docvd_porcentaje
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_porcentaje) Then
				If Not m_docvd_porcentaje.Equals(value) Then
					m_docvd_porcentaje = value
					OnDOCVD_PorcentajeChanged(m_docvd_porcentaje, EventArgs.Empty)
				End If
			Else
				m_docvd_porcentaje = value
				OnDOCVD_PorcentajeChanged(m_docvd_porcentaje, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_FecEmision() As Date
		Get
			return m_docvd_fecemision
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_docvd_fecemision) Then
				If Not m_docvd_fecemision.Equals(value) Then
					m_docvd_fecemision = value
					OnDOCVD_FecEmisionChanged(m_docvd_fecemision, EventArgs.Empty)
				End If
			Else
				m_docvd_fecemision = value
				OnDOCVD_FecEmisionChanged(m_docvd_fecemision, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Importe() As Decimal
		Get
			return m_docvd_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_importe) Then
				If Not m_docvd_importe.Equals(value) Then
					m_docvd_importe = value
					OnDOCVD_ImporteChanged(m_docvd_importe, EventArgs.Empty)
				End If
			Else
				m_docvd_importe = value
				OnDOCVD_ImporteChanged(m_docvd_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_MontoTotal() As Decimal
		Get
			return m_docvd_montototal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_montototal) Then
				If Not m_docvd_montototal.Equals(value) Then
					m_docvd_montototal = value
					OnDOCVD_MontoTotalChanged(m_docvd_montototal, EventArgs.Empty)
				End If
			Else
				m_docvd_montototal = value
				OnDOCVD_MontoTotalChanged(m_docvd_montototal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_Estado() As String
		Get
			return m_docvd_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docvd_estado) Then
				If Not m_docvd_estado.Equals(value) Then
					m_docvd_estado = value
					OnDOCVD_EstadoChanged(m_docvd_estado, EventArgs.Empty)
				End If
			Else
				m_docvd_estado = value
				OnDOCVD_EstadoChanged(m_docvd_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PrecIncIGV() As Decimal
		Get
			return m_docvd_precincigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_precincigv) Then
				If Not m_docvd_precincigv.Equals(value) Then
					m_docvd_precincigv = value
					OnDOCVD_PrecIncIGVChanged(m_docvd_precincigv, EventArgs.Empty)
				End If
			Else
				m_docvd_precincigv = value
				OnDOCVD_PrecIncIGVChanged(m_docvd_precincigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_PrecioUnitarioPrecIncIGV() As Decimal
		Get
			return m_docvd_preciounitarioprecincigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_preciounitarioprecincigv) Then
				If Not m_docvd_preciounitarioprecincigv.Equals(value) Then
					m_docvd_preciounitarioprecincigv = value
					OnDOCVD_PrecioUnitarioPrecIncIGVChanged(m_docvd_preciounitarioprecincigv, EventArgs.Empty)
				End If
			Else
				m_docvd_preciounitarioprecincigv = value
				OnDOCVD_PrecioUnitarioPrecIncIGVChanged(m_docvd_preciounitarioprecincigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TMP() As Decimal
		Get
			return m_tmp
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tmp) Then
				If Not m_tmp.Equals(value) Then
					m_tmp = value
					OnTMPChanged(m_tmp, EventArgs.Empty)
				End If
			Else
				m_tmp = value
				OnTMPChanged(m_tmp, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CantidadDevolver() As Decimal
		Get
			return m_docvd_cantidaddevolver
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_cantidaddevolver) Then
				If Not m_docvd_cantidaddevolver.Equals(value) Then
					m_docvd_cantidaddevolver = value
					OnDOCVD_CantidadDevolverChanged(m_docvd_cantidaddevolver, EventArgs.Empty)
				End If
			Else
				m_docvd_cantidaddevolver = value
				OnDOCVD_CantidadDevolverChanged(m_docvd_cantidaddevolver, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_CodigoCambio() As String
		Get
			return m_artic_codigocambio
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_codigocambio) Then
				If Not m_artic_codigocambio.Equals(value) Then
					m_artic_codigocambio = value
					OnARTIC_CodigoCambioChanged(m_artic_codigocambio, EventArgs.Empty)
				End If
			Else
				m_artic_codigocambio = value
				OnARTIC_CodigoCambioChanged(m_artic_codigocambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CantidadCambio() As Decimal
		Get
			return m_docvd_cantidadcambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_cantidadcambio) Then
				If Not m_docvd_cantidadcambio.Equals(value) Then
					m_docvd_cantidadcambio = value
					OnDOCVD_CantidadCambioChanged(m_docvd_cantidadcambio, EventArgs.Empty)
				End If
			Else
				m_docvd_cantidadcambio = value
				OnDOCVD_CantidadCambioChanged(m_docvd_cantidadcambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CodigoCambio() As Integer
		Get
			return m_docvd_codigocambio
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_docvd_codigocambio) Then
				If Not m_docvd_codigocambio.Equals(value) Then
					m_docvd_codigocambio = value
					OnDOCVD_CodigoCambioChanged(m_docvd_codigocambio, EventArgs.Empty)
				End If
			Else
				m_docvd_codigocambio = value
				OnDOCVD_CodigoCambioChanged(m_docvd_codigocambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CostoUnitarioDolares() As Decimal
		Get
			return m_docvd_costounitariodolares
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_costounitariodolares) Then
				If Not m_docvd_costounitariodolares.Equals(value) Then
					m_docvd_costounitariodolares = value
					OnDOCVD_CostoUnitarioDolaresChanged(m_docvd_costounitariodolares, EventArgs.Empty)
				End If
			Else
				m_docvd_costounitariodolares = value
				OnDOCVD_CostoUnitarioDolaresChanged(m_docvd_costounitariodolares, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_CostoUnitarioSoles() As Decimal
		Get
			return m_docvd_costounitariosoles
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_costounitariosoles) Then
				If Not m_docvd_costounitariosoles.Equals(value) Then
					m_docvd_costounitariosoles = value
					OnDOCVD_CostoUnitarioSolesChanged(m_docvd_costounitariosoles, EventArgs.Empty)
				End If
			Else
				m_docvd_costounitariosoles = value
				OnDOCVD_CostoUnitarioSolesChanged(m_docvd_costounitariosoles, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVD_TipoCambioCosto() As Decimal
		Get
			return m_docvd_tipocambiocosto
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_docvd_tipocambiocosto) Then
				If Not m_docvd_tipocambiocosto.Equals(value) Then
					m_docvd_tipocambiocosto = value
					OnDOCVD_TipoCambioCostoChanged(m_docvd_tipocambiocosto, EventArgs.Empty)
				End If
			Else
				m_docvd_tipocambiocosto = value
				OnDOCVD_TipoCambioCostoChanged(m_docvd_tipocambiocosto, EventArgs.Empty)
			End If
		End Set
    End Property

    'R 
    Public Property TIPOS_DescCorta() As String
        Get
            Return m_tipos_desccorta
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_desccorta) Then
                If Not m_tipos_desccorta.Equals(value) Then
                    m_tipos_desccorta = value
                    OnDOCVE_CodigoChanged(m_tipos_desccorta, EventArgs.Empty)
                End If
            Else
                m_tipos_desccorta = value
                OnDOCVE_CodigoChanged(m_tipos_desccorta, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property TIPOS_Documento() As String
        Get
            Return m_tipos_documento
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_documento) Then
                If Not m_tipos_documento.Equals(value) Then
                    m_tipos_documento = value
                    OnTIPOS_DocumentoChanged(m_tipos_documento, EventArgs.Empty)
                End If
            Else
                m_tipos_documento = value
                OnTIPOS_DocumentoChanged(m_tipos_documento, EventArgs.Empty)
            End If
        End Set
    End Property

    'Public Property DOCVD_EstAlmacen() As String
    '    Get
    '        Return m_docvd_estalmacen
    '    End Get
    '    Set(ByVal value As String)
    '        If Not IsNothing(m_docvd_estalmacen) Then
    '            If Not m_docvd_estalmacen.Equals(value) Then
    '                m_docvd_estalmacen = value
    '                OnDOCVD_EstAlmacenChanged(m_docvd_estalmacen, EventArgs.Empty)
    '            End If
    '        Else
    '            m_docvd_estalmacen = value
    '            OnDOCVD_EstAlmacenChanged(m_docvd_estalmacen, EventArgs.Empty)
    '        End If
    '    End Set
    'End Property

    Public Property DOCVD_CantidadEntregada() As Decimal
        Get
            Return m_docvd_cantidadentregada
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docvd_cantidadentregada) Then
                If Not m_docvd_cantidadentregada.Equals(value) Then
                    m_docvd_cantidadentregada = value
                    OnDOCVD_CantidadEntregadaChanged(m_docvd_cantidadentregada, EventArgs.Empty)
                End If
            Else
                m_docvd_cantidadentregada = value
                OnDOCVD_CantidadEntregadaChanged(m_docvd_cantidadentregada, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVD_Motivo() As String
        Get
            Return m_docvd_motivo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docvd_motivo) Then
                If Not m_docvd_motivo.Equals(value) Then
                    m_docvd_motivo = value
                    OnDOCVD_MotivoChanged(m_docvd_motivo, EventArgs.Empty)
                End If
            Else
                m_docvd_motivo = value
                OnDOCVD_MotivoChanged(m_docvd_motivo, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DOCVD_ValorReferencial() As Decimal
        Get
            Return m_docvd_valorreferencial
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_docvd_valorreferencial) Then
                If Not m_docvd_valorreferencial.Equals(value) Then
                    m_docvd_valorreferencial = value
                    OnDOCVD_ValorReferencialChanged(m_docvd_valorreferencial, EventArgs.Empty)
                End If
            Else
                m_docvd_valorreferencial = value
                OnDOCVD_ValorReferencialChanged(m_docvd_valorreferencial, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property DOCVD_UsrCrea() As String
		Get
			return m_docvd_usrcrea
		End Get
		Set(ByVal value As String)
			m_docvd_usrcrea = value
		End Set
    End Property
    Public Property DOCVD_UsuarioAlmacen() As String
        Get
            Return m_docvd_usuarioalmacen
        End Get
        Set(ByVal value As String)
            m_docvd_usuarioalmacen = value
        End Set
    End Property

	Public Property DOCVD_FecCrea() As Date
		Get
			return m_docvd_feccrea
		End Get
		Set(ByVal value As Date)
			m_docvd_feccrea = value
		End Set
	End Property

	Public Property DOCVD_UsrMod() As String
		Get
			return m_docvd_usrmod
		End Get
		Set(ByVal value As String)
			m_docvd_usrmod = value
		End Set
	End Property

	Public Property DOCVD_FecMod() As Date
		Get
			return m_docvd_fecmod
		End Get
		Set(ByVal value As Date)
			m_docvd_fecmod = value
		End Set
    End Property
    Public Property DOCVD_FecAlmacen() As Date
        Get
            Return m_docvd_fecalmacen
        End Get
        Set(ByVal value As Date)
            m_docvd_fecalmacen = value
        End Set
    End Property
    
    Public Property ORDEN_EstEntrega() As String
		Get
			return m_estadoentregaOR
		End Get
		Set(ByVal value As String)
			m_estadoentregaOR = value
		End Set
	End Property
	#Region " Propiedades de Solo Lectura "
    Public ReadOnly Property Cantidad_Cero() As Integer
        Get
            Return 0
        End Get
    End Property
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
			Return "VENT_DocsVentaDetalle"
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
	Public Event DOCVD_ItemChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event LPREC_IdChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event DOCVD_PercepcionChanged As EventHandler
	Public Event DOCVD_CostoUnitarioChanged As EventHandler
	Public Event DOCVD_PesoUnitarioChanged As EventHandler
	Public Event DOCVD_PrecioUnitarioChanged As EventHandler
	Public Event DOCVD_CantidadChanged As EventHandler
	Public Event DOCVD_UnidadChanged As EventHandler
	Public Event DOCVD_DetalleChanged As EventHandler
	Public Event DOCVD_SaldoChanged As EventHandler
	Public Event DOCVD_SubImporteVentaChanged As EventHandler
	Public Event DOCVD_SubImportePercepcionChanged As EventHandler
	Public Event DOCVD_SubTotalChanged As EventHandler
	Public Event DOCVE_CodigoReferenciaChanged As EventHandler
	Public Event DOCVD_PrecVentaOriginalChanged As EventHandler
	Public Event DOCVD_PrecioVentaChanged As EventHandler
	Public Event DOCVD_PorcentajeChanged As EventHandler
	Public Event DOCVD_FecEmisionChanged As EventHandler
	Public Event DOCVD_ImporteChanged As EventHandler
	Public Event DOCVD_MontoTotalChanged As EventHandler
	Public Event DOCVD_EstadoChanged As EventHandler
	Public Event DOCVD_PrecIncIGVChanged As EventHandler
	Public Event DOCVD_PrecioUnitarioPrecIncIGVChanged As EventHandler
	Public Event TMPChanged As EventHandler
	Public Event DOCVD_CantidadDevolverChanged As EventHandler
	Public Event ARTIC_CodigoCambioChanged As EventHandler
	Public Event DOCVD_CantidadCambioChanged As EventHandler
	Public Event DOCVD_CodigoCambioChanged As EventHandler
	Public Event DOCVD_CostoUnitarioDolaresChanged As EventHandler
	Public Event DOCVD_CostoUnitarioSolesChanged As EventHandler
	Public Event DOCVD_TipoCambioCostoChanged As EventHandler

    Public Event TIPOS_DocumentoChanged As EventHandler

    Public Event DOCVD_CantidadEntregadaChanged As EventHandler

    Public Event DOCVD_MotivoChanged As EventHandler

    'Public Event DOCVD_EstAlmacenChanged As EventHandler

    Public Event NroComprobanteChanged As EventHandler

    Public Event DOCVD_ValorReferencialChanged As EventHandler


	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
    End Sub

    Public Sub OnNroComprobanteChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent NroComprobanteChanged(sender, e)
    End Sub

	Public Sub OnDOCVD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_ItemChanged(sender, e)
	End Sub

	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnLPREC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent LPREC_IdChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CostoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CostoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PesoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PesoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecioUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecioUnitarioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CantidadChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_UnidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_UnidadChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_DetalleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_DetalleChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_SaldoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_SaldoChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_SubImporteVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_SubImporteVentaChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_SubImportePercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_SubImportePercepcionChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_SubTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_SubTotalChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoReferenciaChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecVentaOriginalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecVentaOriginalChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecioVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecioVentaChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PorcentajeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PorcentajeChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_FecEmisionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_FecEmisionChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_ImporteChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_MontoTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_MontoTotalChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_EstadoChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecIncIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecIncIGVChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_PrecioUnitarioPrecIncIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_PrecioUnitarioPrecIncIGVChanged(sender, e)
	End Sub

	Public Sub OnTMPChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TMPChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CantidadDevolverChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CantidadDevolverChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoCambioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CantidadCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CantidadCambioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CodigoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CodigoCambioChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CostoUnitarioDolaresChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CostoUnitarioDolaresChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_CostoUnitarioSolesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_CostoUnitarioSolesChanged(sender, e)
	End Sub

	Public Sub OnDOCVD_TipoCambioCostoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVD_TipoCambioCostoChanged(sender, e)
	End Sub

    Public Sub OnTIPOS_DocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_DocumentoChanged(sender, e)
    End Sub
    'Public Sub OnDOCVD_EstAlmacenChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    ActualizarInstancia()
    '    RaiseEvent DOCVD_EstAlmacenChanged(sender, e)
    'End Sub
    Public Sub OnDOCVD_CantidadEntregadaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVD_CantidadEntregadaChanged(sender, e)
    End Sub

    Public Sub OnDOCVD_MotivoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVD_MotivoChanged(sender, e)
    End Sub
    Public Sub OnDOCVD_ValorReferencialChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVD_ValorReferencialChanged(sender, e)
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


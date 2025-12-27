Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_Caja

#Region " Campos "
	
	Private m_caja_id As Long
	Private m_pvent_id As Long
	Private m_banco_id As Short
	Private m_entid_codigo As String
    Private m_entidad_descripcion as string
	Private m_docve_codigo As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codmonedapago As String
	Private m_tipos_codtransaccion As String
	Private m_tipos_codtipodocumento As String
	Private m_tipos_codtipoorigen As String
	Private m_caja_codigo As String
	Private m_caja_serie As String
	Private m_caja_numero As Long
	Private m_caja_ordendocumento As Short
	Private m_caja_fecha As Date
	Private m_caja_hora As Date
	Private m_caja_fechapago As Date
	Private m_caja_feccontabilidad As Date
	Private m_caja_importe As Decimal
	Private m_caja_glosa As String
	Private m_caja_pase As String
	Private m_caja_recibo As String
	Private m_caja_nrodocumento As String
	Private m_caja_numdeposito As String
    Private m_caja_fechadocventa As Decimal
    Private m_caja_tcsunatdocventa As Decimal
	Private m_caja_tcsunatventa As Decimal
	Private m_caja_tcsunatcompra As Decimal
	Private m_caja_tcoficinaventa As Decimal
	Private m_caja_tcoficinacompra As Decimal
	Private m_caja_tcambio As Decimal
	Private m_caja_tcdocumento As Decimal
	Private m_caja_tcporusuario As Boolean
	Private m_caja_importeventa As Decimal
	Private m_caja_percepcion As Decimal
	Private m_caja_estado As String
	Private m_caja_revisado As Boolean
	Private m_caja_fechaanulado As Date
	Private m_caja_anuladocaja As Boolean
	Private m_caja_tnumfac As Long
	Private m_caja_app As String
	Private m_caja_motivoanulacion As String
	Private m_caja_usrcrea As String
	Private m_caja_feccrea As Date
	Private m_caja_usrmod As String
	Private m_caja_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
    Private m_eliminado As Boolean
    Private m_Cod_Confirmacion As String

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_Caja
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
	
	Public Property CAJA_Id() As Long
		Get
			return m_caja_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_caja_id) Then
				If Not m_caja_id.Equals(value) Then
					m_caja_id = value
					OnCAJA_IdChanged(m_caja_id, EventArgs.Empty)
				End If
			Else
				m_caja_id = value
				OnCAJA_IdChanged(m_caja_id, EventArgs.Empty)
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

	Public Property BANCO_Id() As Short
		Get
			return m_banco_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_banco_id) Then
				If Not m_banco_id.Equals(value) Then
					m_banco_id = value
					OnBANCO_IdChanged(m_banco_id, EventArgs.Empty)
				End If
			Else
				m_banco_id = value
				OnBANCO_IdChanged(m_banco_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Codigo() As String
		Get
			return m_entid_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigo) Then
				If Not m_entid_codigo.Equals(value) Then
					m_entid_codigo = value
					OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
				End If
			Else
				m_entid_codigo = value
				OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
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

	Public Property TIPOS_CodMonedaPago() As String
		Get
			return m_tipos_codmonedapago
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codmonedapago) Then
				If Not m_tipos_codmonedapago.Equals(value) Then
					m_tipos_codmonedapago = value
					OnTIPOS_CodMonedaPagoChanged(m_tipos_codmonedapago, EventArgs.Empty)
				End If
			Else
				m_tipos_codmonedapago = value
				OnTIPOS_CodMonedaPagoChanged(m_tipos_codmonedapago, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTransaccion() As String
		Get
			return m_tipos_codtransaccion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtransaccion) Then
				If Not m_tipos_codtransaccion.Equals(value) Then
					m_tipos_codtransaccion = value
					OnTIPOS_CodTransaccionChanged(m_tipos_codtransaccion, EventArgs.Empty)
				End If
			Else
				m_tipos_codtransaccion = value
				OnTIPOS_CodTransaccionChanged(m_tipos_codtransaccion, EventArgs.Empty)
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

	Public Property TIPOS_CodTipoOrigen() As String
		Get
			return m_tipos_codtipoorigen
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipoorigen) Then
				If Not m_tipos_codtipoorigen.Equals(value) Then
					m_tipos_codtipoorigen = value
					OnTIPOS_CodTipoOrigenChanged(m_tipos_codtipoorigen, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipoorigen = value
				OnTIPOS_CodTipoOrigenChanged(m_tipos_codtipoorigen, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Codigo() As String
		Get
			return m_caja_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_codigo) Then
				If Not m_caja_codigo.Equals(value) Then
					m_caja_codigo = value
					OnCAJA_CodigoChanged(m_caja_codigo, EventArgs.Empty)
				End If
			Else
				m_caja_codigo = value
				OnCAJA_CodigoChanged(m_caja_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Serie() As String
		Get
			return m_caja_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_serie) Then
				If Not m_caja_serie.Equals(value) Then
					m_caja_serie = value
					OnCAJA_SerieChanged(m_caja_serie, EventArgs.Empty)
				End If
			Else
				m_caja_serie = value
				OnCAJA_SerieChanged(m_caja_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Numero() As Long
		Get
			return m_caja_numero
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_caja_numero) Then
				If Not m_caja_numero.Equals(value) Then
					m_caja_numero = value
					OnCAJA_NumeroChanged(m_caja_numero, EventArgs.Empty)
				End If
			Else
				m_caja_numero = value
				OnCAJA_NumeroChanged(m_caja_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_OrdenDocumento() As Short
		Get
			return m_caja_ordendocumento
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_caja_ordendocumento) Then
				If Not m_caja_ordendocumento.Equals(value) Then
					m_caja_ordendocumento = value
					OnCAJA_OrdenDocumentoChanged(m_caja_ordendocumento, EventArgs.Empty)
				End If
			Else
				m_caja_ordendocumento = value
				OnCAJA_OrdenDocumentoChanged(m_caja_ordendocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Fecha() As Date
		Get
			return m_caja_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_caja_fecha) Then
				If Not m_caja_fecha.Equals(value) Then
					m_caja_fecha = value
					OnCAJA_FechaChanged(m_caja_fecha, EventArgs.Empty)
				End If
			Else
				m_caja_fecha = value
				OnCAJA_FechaChanged(m_caja_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Hora() As Date
		Get
			return m_caja_hora
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_caja_hora) Then
				If Not m_caja_hora.Equals(value) Then
					m_caja_hora = value
					OnCAJA_HoraChanged(m_caja_hora, EventArgs.Empty)
				End If
			Else
				m_caja_hora = value
				OnCAJA_HoraChanged(m_caja_hora, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_FechaPago() As Date
		Get
			return m_caja_fechapago
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_caja_fechapago) Then
				If Not m_caja_fechapago.Equals(value) Then
					m_caja_fechapago = value
					OnCAJA_FechaPagoChanged(m_caja_fechapago, EventArgs.Empty)
				End If
			Else
				m_caja_fechapago = value
				OnCAJA_FechaPagoChanged(m_caja_fechapago, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_FecContabilidad() As Date
		Get
			return m_caja_feccontabilidad
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_caja_feccontabilidad) Then
				If Not m_caja_feccontabilidad.Equals(value) Then
					m_caja_feccontabilidad = value
					OnCAJA_FecContabilidadChanged(m_caja_feccontabilidad, EventArgs.Empty)
				End If
			Else
				m_caja_feccontabilidad = value
				OnCAJA_FecContabilidadChanged(m_caja_feccontabilidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Importe() As Decimal
		Get
			return m_caja_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_importe) Then
				If Not m_caja_importe.Equals(value) Then
					m_caja_importe = value
					OnCAJA_ImporteChanged(m_caja_importe, EventArgs.Empty)
				End If
			Else
				m_caja_importe = value
				OnCAJA_ImporteChanged(m_caja_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Glosa() As String
		Get
			return m_caja_glosa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_glosa) Then
				If Not m_caja_glosa.Equals(value) Then
					m_caja_glosa = value
					OnCAJA_GlosaChanged(m_caja_glosa, EventArgs.Empty)
				End If
			Else
				m_caja_glosa = value
				OnCAJA_GlosaChanged(m_caja_glosa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Pase() As String
		Get
			return m_caja_pase
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_pase) Then
				If Not m_caja_pase.Equals(value) Then
					m_caja_pase = value
					OnCAJA_PaseChanged(m_caja_pase, EventArgs.Empty)
				End If
			Else
				m_caja_pase = value
				OnCAJA_PaseChanged(m_caja_pase, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Recibo() As String
		Get
			return m_caja_recibo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_recibo) Then
				If Not m_caja_recibo.Equals(value) Then
					m_caja_recibo = value
					OnCAJA_ReciboChanged(m_caja_recibo, EventArgs.Empty)
				End If
			Else
				m_caja_recibo = value
				OnCAJA_ReciboChanged(m_caja_recibo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_NroDocumento() As String
		Get
			return m_caja_nrodocumento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_nrodocumento) Then
				If Not m_caja_nrodocumento.Equals(value) Then
					m_caja_nrodocumento = value
					OnCAJA_NroDocumentoChanged(m_caja_nrodocumento, EventArgs.Empty)
				End If
			Else
				m_caja_nrodocumento = value
				OnCAJA_NroDocumentoChanged(m_caja_nrodocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_NumDeposito() As String
		Get
			return m_caja_numdeposito
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_numdeposito) Then
				If Not m_caja_numdeposito.Equals(value) Then
					m_caja_numdeposito = value
					OnCAJA_NumDepositoChanged(m_caja_numdeposito, EventArgs.Empty)
				End If
			Else
				m_caja_numdeposito = value
				OnCAJA_NumDepositoChanged(m_caja_numdeposito, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property CAJA_FechaDocVenta() As Decimal
        Get
            Return m_caja_fechadocventa
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_caja_fechadocventa) Then
                If Not m_caja_fechadocventa.Equals(value) Then
                    m_caja_fechadocventa = value
                    OnCAJA_FechaDocVentaChanged(m_caja_fechadocventa, EventArgs.Empty)
                End If
            Else
                m_caja_fechadocventa = value
                OnCAJA_FechaDocVentaChanged(m_caja_fechadocventa, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property CAJA_TCSunatDocVenta() As Decimal
		Get
			return m_caja_tcsunatdocventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_tcsunatdocventa) Then
				If Not m_caja_tcsunatdocventa.Equals(value) Then
					m_caja_tcsunatdocventa = value
					OnCAJA_TCSunatDocVentaChanged(m_caja_tcsunatdocventa, EventArgs.Empty)
				End If
			Else
				m_caja_tcsunatdocventa = value
				OnCAJA_TCSunatDocVentaChanged(m_caja_tcsunatdocventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_TCSunatVenta() As Decimal
		Get
			return m_caja_tcsunatventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_tcsunatventa) Then
				If Not m_caja_tcsunatventa.Equals(value) Then
					m_caja_tcsunatventa = value
					OnCAJA_TCSunatVentaChanged(m_caja_tcsunatventa, EventArgs.Empty)
				End If
			Else
				m_caja_tcsunatventa = value
				OnCAJA_TCSunatVentaChanged(m_caja_tcsunatventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_TCSunatCompra() As Decimal
		Get
			return m_caja_tcsunatcompra
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_tcsunatcompra) Then
				If Not m_caja_tcsunatcompra.Equals(value) Then
					m_caja_tcsunatcompra = value
					OnCAJA_TCSunatCompraChanged(m_caja_tcsunatcompra, EventArgs.Empty)
				End If
			Else
				m_caja_tcsunatcompra = value
				OnCAJA_TCSunatCompraChanged(m_caja_tcsunatcompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_TCOficinaVenta() As Decimal
		Get
			return m_caja_tcoficinaventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_tcoficinaventa) Then
				If Not m_caja_tcoficinaventa.Equals(value) Then
					m_caja_tcoficinaventa = value
					OnCAJA_TCOficinaVentaChanged(m_caja_tcoficinaventa, EventArgs.Empty)
				End If
			Else
				m_caja_tcoficinaventa = value
				OnCAJA_TCOficinaVentaChanged(m_caja_tcoficinaventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_TCOficinaCompra() As Decimal
		Get
			return m_caja_tcoficinacompra
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_tcoficinacompra) Then
				If Not m_caja_tcoficinacompra.Equals(value) Then
					m_caja_tcoficinacompra = value
					OnCAJA_TCOficinaCompraChanged(m_caja_tcoficinacompra, EventArgs.Empty)
				End If
			Else
				m_caja_tcoficinacompra = value
				OnCAJA_TCOficinaCompraChanged(m_caja_tcoficinacompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_TCambio() As Decimal
		Get
			return m_caja_tcambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_tcambio) Then
				If Not m_caja_tcambio.Equals(value) Then
					m_caja_tcambio = value
					OnCAJA_TCambioChanged(m_caja_tcambio, EventArgs.Empty)
				End If
			Else
				m_caja_tcambio = value
				OnCAJA_TCambioChanged(m_caja_tcambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_TCDocumento() As Decimal
		Get
			return m_caja_tcdocumento
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_tcdocumento) Then
				If Not m_caja_tcdocumento.Equals(value) Then
					m_caja_tcdocumento = value
					OnCAJA_TCDocumentoChanged(m_caja_tcdocumento, EventArgs.Empty)
				End If
			Else
				m_caja_tcdocumento = value
				OnCAJA_TCDocumentoChanged(m_caja_tcdocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_TCPorUsuario() As Boolean
		Get
			return m_caja_tcporusuario
		End Get
		Set(ByVal value As Boolean)
			If Not m_caja_tcporusuario.Equals(value) Then
				m_caja_tcporusuario = value
				OnCAJA_TCPorUsuarioChanged(m_caja_tcporusuario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_ImporteVenta() As Decimal
		Get
			return m_caja_importeventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_importeventa) Then
				If Not m_caja_importeventa.Equals(value) Then
					m_caja_importeventa = value
					OnCAJA_ImporteVentaChanged(m_caja_importeventa, EventArgs.Empty)
				End If
			Else
				m_caja_importeventa = value
				OnCAJA_ImporteVentaChanged(m_caja_importeventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Percepcion() As Decimal
		Get
			return m_caja_percepcion
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_caja_percepcion) Then
				If Not m_caja_percepcion.Equals(value) Then
					m_caja_percepcion = value
					OnCAJA_PercepcionChanged(m_caja_percepcion, EventArgs.Empty)
				End If
			Else
				m_caja_percepcion = value
				OnCAJA_PercepcionChanged(m_caja_percepcion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Estado() As String
		Get
			return m_caja_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_estado) Then
				If Not m_caja_estado.Equals(value) Then
					m_caja_estado = value
					OnCAJA_EstadoChanged(m_caja_estado, EventArgs.Empty)
				End If
			Else
				m_caja_estado = value
				OnCAJA_EstadoChanged(m_caja_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Revisado() As Boolean
		Get
			return m_caja_revisado
		End Get
		Set(ByVal value As Boolean)
			If Not m_caja_revisado.Equals(value) Then
				m_caja_revisado = value
				OnCAJA_RevisadoChanged(m_caja_revisado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_FechaAnulado() As Date
		Get
			return m_caja_fechaanulado
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_caja_fechaanulado) Then
				If Not m_caja_fechaanulado.Equals(value) Then
					m_caja_fechaanulado = value
					OnCAJA_FechaAnuladoChanged(m_caja_fechaanulado, EventArgs.Empty)
				End If
			Else
				m_caja_fechaanulado = value
				OnCAJA_FechaAnuladoChanged(m_caja_fechaanulado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_AnuladoCaja() As Boolean
		Get
			return m_caja_anuladocaja
		End Get
		Set(ByVal value As Boolean)
			If Not m_caja_anuladocaja.Equals(value) Then
				m_caja_anuladocaja = value
				OnCAJA_AnuladoCajaChanged(m_caja_anuladocaja, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_TNumFac() As Long
		Get
			return m_caja_tnumfac
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_caja_tnumfac) Then
				If Not m_caja_tnumfac.Equals(value) Then
					m_caja_tnumfac = value
					OnCAJA_TNumFacChanged(m_caja_tnumfac, EventArgs.Empty)
				End If
			Else
				m_caja_tnumfac = value
				OnCAJA_TNumFacChanged(m_caja_tnumfac, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_App() As String
		Get
			return m_caja_app
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_app) Then
				If Not m_caja_app.Equals(value) Then
					m_caja_app = value
					OnCAJA_AppChanged(m_caja_app, EventArgs.Empty)
				End If
			Else
				m_caja_app = value
				OnCAJA_AppChanged(m_caja_app, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_MotivoAnulacion() As String
		Get
			return m_caja_motivoanulacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_motivoanulacion) Then
				If Not m_caja_motivoanulacion.Equals(value) Then
					m_caja_motivoanulacion = value
					OnCAJA_MotivoAnulacionChanged(m_caja_motivoanulacion, EventArgs.Empty)
				End If
			Else
				m_caja_motivoanulacion = value
				OnCAJA_MotivoAnulacionChanged(m_caja_motivoanulacion, EventArgs.Empty)
			End If
		End Set
	End Property
    
    Public Property ENTID_Descripcion() As String
		Get
			return m_entidad_descripcion
		End Get
		Set(ByVal value As String)
			m_entidad_descripcion = value
		End Set
    End Property

	Public Property CAJA_UsrCrea() As String
		Get
			return m_caja_usrcrea
		End Get
		Set(ByVal value As String)
			m_caja_usrcrea = value
		End Set
    End Property
    Public Property Cod_Confirmacion() As String
        Get
            Return m_Cod_Confirmacion
        End Get
        Set(ByVal value As String)
            m_Cod_Confirmacion = value
        End Set
    End Property


	Public Property CAJA_FecCrea() As Date
		Get
			return m_caja_feccrea
		End Get
		Set(ByVal value As Date)
			m_caja_feccrea = value
		End Set
	End Property

	Public Property CAJA_UsrMod() As String
		Get
			return m_caja_usrmod
		End Get
		Set(ByVal value As String)
			m_caja_usrmod = value
		End Set
	End Property

	Public Property CAJA_FecMod() As Date
		Get
			return m_caja_fecmod
		End Get
		Set(ByVal value As Date)
			m_caja_fecmod = value
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
			Return "TESO_Caja"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Tesoreria"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event CAJA_IdChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event BANCO_IdChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodMonedaPagoChanged As EventHandler
	Public Event TIPOS_CodTransaccionChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event TIPOS_CodTipoOrigenChanged As EventHandler
	Public Event CAJA_CodigoChanged As EventHandler
	Public Event CAJA_SerieChanged As EventHandler
	Public Event CAJA_NumeroChanged As EventHandler
	Public Event CAJA_OrdenDocumentoChanged As EventHandler
	Public Event CAJA_FechaChanged As EventHandler
	Public Event CAJA_HoraChanged As EventHandler
	Public Event CAJA_FechaPagoChanged As EventHandler
	Public Event CAJA_FecContabilidadChanged As EventHandler
	Public Event CAJA_ImporteChanged As EventHandler
	Public Event CAJA_GlosaChanged As EventHandler
	Public Event CAJA_PaseChanged As EventHandler
	Public Event CAJA_ReciboChanged As EventHandler
	Public Event CAJA_NroDocumentoChanged As EventHandler
	Public Event CAJA_NumDepositoChanged As EventHandler
	Public Event CAJA_FechaDocVentaChanged As EventHandler
	Public Event CAJA_TCSunatDocVentaChanged As EventHandler
	Public Event CAJA_TCSunatVentaChanged As EventHandler
	Public Event CAJA_TCSunatCompraChanged As EventHandler
	Public Event CAJA_TCOficinaVentaChanged As EventHandler
	Public Event CAJA_TCOficinaCompraChanged As EventHandler
	Public Event CAJA_TCambioChanged As EventHandler
	Public Event CAJA_TCDocumentoChanged As EventHandler
	Public Event CAJA_TCPorUsuarioChanged As EventHandler
	Public Event CAJA_ImporteVentaChanged As EventHandler
	Public Event CAJA_PercepcionChanged As EventHandler
	Public Event CAJA_EstadoChanged As EventHandler
	Public Event CAJA_RevisadoChanged As EventHandler
	Public Event CAJA_FechaAnuladoChanged As EventHandler
	Public Event CAJA_AnuladoCajaChanged As EventHandler
	Public Event CAJA_TNumFacChanged As EventHandler
	Public Event CAJA_AppChanged As EventHandler
	Public Event CAJA_MotivoAnulacionChanged As EventHandler

	Public Sub OnCAJA_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_IdChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnBANCO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent BANCO_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodMonedaPagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodMonedaPagoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTransaccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTransaccionChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoOrigenChanged(sender, e)
	End Sub

	Public Sub OnCAJA_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_CodigoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_SerieChanged(sender, e)
	End Sub

	Public Sub OnCAJA_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_NumeroChanged(sender, e)
	End Sub

	Public Sub OnCAJA_OrdenDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_OrdenDocumentoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_FechaChanged(sender, e)
	End Sub

	Public Sub OnCAJA_HoraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_HoraChanged(sender, e)
	End Sub

	Public Sub OnCAJA_FechaPagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_FechaPagoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_FecContabilidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_FecContabilidadChanged(sender, e)
	End Sub

	Public Sub OnCAJA_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_ImporteChanged(sender, e)
	End Sub

	Public Sub OnCAJA_GlosaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_GlosaChanged(sender, e)
	End Sub

	Public Sub OnCAJA_PaseChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_PaseChanged(sender, e)
	End Sub

	Public Sub OnCAJA_ReciboChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_ReciboChanged(sender, e)
	End Sub

	Public Sub OnCAJA_NroDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_NroDocumentoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_NumDepositoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_NumDepositoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_FechaDocVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_FechaDocVentaChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TCSunatDocVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TCSunatDocVentaChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TCSunatVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TCSunatVentaChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TCSunatCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TCSunatCompraChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TCOficinaVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TCOficinaVentaChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TCOficinaCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TCOficinaCompraChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TCambioChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TCDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TCDocumentoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TCPorUsuarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TCPorUsuarioChanged(sender, e)
	End Sub

	Public Sub OnCAJA_ImporteVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_ImporteVentaChanged(sender, e)
	End Sub

	Public Sub OnCAJA_PercepcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_PercepcionChanged(sender, e)
	End Sub

	Public Sub OnCAJA_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_EstadoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_RevisadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_RevisadoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_FechaAnuladoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_FechaAnuladoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_AnuladoCajaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_AnuladoCajaChanged(sender, e)
	End Sub

	Public Sub OnCAJA_TNumFacChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_TNumFacChanged(sender, e)
	End Sub

	Public Sub OnCAJA_AppChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_AppChanged(sender, e)
	End Sub

	Public Sub OnCAJA_MotivoAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_MotivoAnulacionChanged(sender, e)
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


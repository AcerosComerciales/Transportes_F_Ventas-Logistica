Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_DocsPagos

#Region " Campos "
	
	Private m_pvent_id As Long
	Private m_dpago_id As Long
	Private m_banco_id As Short
	Private m_cuent_id As Short
	Private m_entid_codigo As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipodocumento As String
	Private m_docve_codigo As String
	Private m_dpago_fecha As Date
	Private m_dpago_fechavenc As Date
	Private m_dpago_numero As String
	Private m_dpago_importe As Decimal
	Private m_dpago_tipocambio As Decimal
	Private m_dpago_lugargiro As String
	Private m_dpago_glosa As String
	Private m_dpago_aceptante As String
	Private m_dpago_domicilio As String
	Private m_dpago_localidad As String
	Private m_dpago_ruc As String
	Private m_dpago_telefono As String
	Private m_dpago_refgirador As String
	Private m_dpago_codigogirador As String
	Private m_dpago_numerocheque As String
	Private m_dpago_depositante As String
	Private m_dpago_estado As String
	Private m_tipos_codmodopago As String
	Private m_dpago_fechagiro As Date
	Private m_dpago_usrcrea As String
	Private m_dpago_feccrea As Date
	Private m_dpago_usrmod As String
	Private m_dpago_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
    Private m_CodConfirmacion As String

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_DocsPagos
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

	Public Property DPAGO_Id() As Long
		Get
			return m_dpago_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_dpago_id) Then
				If Not m_dpago_id.Equals(value) Then
					m_dpago_id = value
					OnDPAGO_IdChanged(m_dpago_id, EventArgs.Empty)
				End If
			Else
				m_dpago_id = value
				OnDPAGO_IdChanged(m_dpago_id, EventArgs.Empty)
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

	Public Property CUENT_Id() As Short
		Get
			return m_cuent_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_cuent_id) Then
				If Not m_cuent_id.Equals(value) Then
					m_cuent_id = value
					OnCUENT_IdChanged(m_cuent_id, EventArgs.Empty)
				End If
			Else
				m_cuent_id = value
				OnCUENT_IdChanged(m_cuent_id, EventArgs.Empty)
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

	Public Property DPAGO_Fecha() As Date
		Get
			return m_dpago_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_dpago_fecha) Then
				If Not m_dpago_fecha.Equals(value) Then
					m_dpago_fecha = value
					OnDPAGO_FechaChanged(m_dpago_fecha, EventArgs.Empty)
				End If
			Else
				m_dpago_fecha = value
				OnDPAGO_FechaChanged(m_dpago_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_FechaVenc() As Date
		Get
			return m_dpago_fechavenc
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_dpago_fechavenc) Then
				If Not m_dpago_fechavenc.Equals(value) Then
					m_dpago_fechavenc = value
					OnDPAGO_FechaVencChanged(m_dpago_fechavenc, EventArgs.Empty)
				End If
			Else
				m_dpago_fechavenc = value
				OnDPAGO_FechaVencChanged(m_dpago_fechavenc, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Numero() As String
		Get
			return m_dpago_numero
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_numero) Then
				If Not m_dpago_numero.Equals(value) Then
					m_dpago_numero = value
					OnDPAGO_NumeroChanged(m_dpago_numero, EventArgs.Empty)
				End If
			Else
				m_dpago_numero = value
				OnDPAGO_NumeroChanged(m_dpago_numero, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property Cod_Confirmacion() As String
        Get
            Return m_CodConfirmacion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_CodConfirmacion) Then
                If Not m_CodConfirmacion.Equals(value) Then
                    m_CodConfirmacion = value
                    OnCod_ConfirmacionChanged(m_CodConfirmacion, EventArgs.Empty)
                End If
            Else
                m_CodConfirmacion = value
                OnCod_ConfirmacionChanged(m_CodConfirmacion, EventArgs.Empty)
            End If
        End Set
    End Property

 

	Public Property DPAGO_Importe() As Decimal
		Get
			return m_dpago_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_dpago_importe) Then
				If Not m_dpago_importe.Equals(value) Then
					m_dpago_importe = value
					OnDPAGO_ImporteChanged(m_dpago_importe, EventArgs.Empty)
				End If
			Else
				m_dpago_importe = value
				OnDPAGO_ImporteChanged(m_dpago_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_TipoCambio() As Decimal
		Get
			return m_dpago_tipocambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_dpago_tipocambio) Then
				If Not m_dpago_tipocambio.Equals(value) Then
					m_dpago_tipocambio = value
					OnDPAGO_TipoCambioChanged(m_dpago_tipocambio, EventArgs.Empty)
				End If
			Else
				m_dpago_tipocambio = value
				OnDPAGO_TipoCambioChanged(m_dpago_tipocambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_LugarGiro() As String
		Get
			return m_dpago_lugargiro
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_lugargiro) Then
				If Not m_dpago_lugargiro.Equals(value) Then
					m_dpago_lugargiro = value
					OnDPAGO_LugarGiroChanged(m_dpago_lugargiro, EventArgs.Empty)
				End If
			Else
				m_dpago_lugargiro = value
				OnDPAGO_LugarGiroChanged(m_dpago_lugargiro, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Glosa() As String
		Get
			return m_dpago_glosa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_glosa) Then
				If Not m_dpago_glosa.Equals(value) Then
					m_dpago_glosa = value
					OnDPAGO_GlosaChanged(m_dpago_glosa, EventArgs.Empty)
				End If
			Else
				m_dpago_glosa = value
				OnDPAGO_GlosaChanged(m_dpago_glosa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Aceptante() As String
		Get
			return m_dpago_aceptante
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_aceptante) Then
				If Not m_dpago_aceptante.Equals(value) Then
					m_dpago_aceptante = value
					OnDPAGO_AceptanteChanged(m_dpago_aceptante, EventArgs.Empty)
				End If
			Else
				m_dpago_aceptante = value
				OnDPAGO_AceptanteChanged(m_dpago_aceptante, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Domicilio() As String
		Get
			return m_dpago_domicilio
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_domicilio) Then
				If Not m_dpago_domicilio.Equals(value) Then
					m_dpago_domicilio = value
					OnDPAGO_DomicilioChanged(m_dpago_domicilio, EventArgs.Empty)
				End If
			Else
				m_dpago_domicilio = value
				OnDPAGO_DomicilioChanged(m_dpago_domicilio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Localidad() As String
		Get
			return m_dpago_localidad
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_localidad) Then
				If Not m_dpago_localidad.Equals(value) Then
					m_dpago_localidad = value
					OnDPAGO_LocalidadChanged(m_dpago_localidad, EventArgs.Empty)
				End If
			Else
				m_dpago_localidad = value
				OnDPAGO_LocalidadChanged(m_dpago_localidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_RUC() As String
		Get
			return m_dpago_ruc
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_ruc) Then
				If Not m_dpago_ruc.Equals(value) Then
					m_dpago_ruc = value
					OnDPAGO_RUCChanged(m_dpago_ruc, EventArgs.Empty)
				End If
			Else
				m_dpago_ruc = value
				OnDPAGO_RUCChanged(m_dpago_ruc, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Telefono() As String
		Get
			return m_dpago_telefono
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_telefono) Then
				If Not m_dpago_telefono.Equals(value) Then
					m_dpago_telefono = value
					OnDPAGO_TelefonoChanged(m_dpago_telefono, EventArgs.Empty)
				End If
			Else
				m_dpago_telefono = value
				OnDPAGO_TelefonoChanged(m_dpago_telefono, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_RefGirador() As String
		Get
			return m_dpago_refgirador
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_refgirador) Then
				If Not m_dpago_refgirador.Equals(value) Then
					m_dpago_refgirador = value
					OnDPAGO_RefGiradorChanged(m_dpago_refgirador, EventArgs.Empty)
				End If
			Else
				m_dpago_refgirador = value
				OnDPAGO_RefGiradorChanged(m_dpago_refgirador, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_CodigoGirador() As String
		Get
			return m_dpago_codigogirador
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_codigogirador) Then
				If Not m_dpago_codigogirador.Equals(value) Then
					m_dpago_codigogirador = value
					OnDPAGO_CodigoGiradorChanged(m_dpago_codigogirador, EventArgs.Empty)
				End If
			Else
				m_dpago_codigogirador = value
				OnDPAGO_CodigoGiradorChanged(m_dpago_codigogirador, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_NumeroCheque() As String
		Get
			return m_dpago_numerocheque
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_numerocheque) Then
				If Not m_dpago_numerocheque.Equals(value) Then
					m_dpago_numerocheque = value
					OnDPAGO_NumeroChequeChanged(m_dpago_numerocheque, EventArgs.Empty)
				End If
			Else
				m_dpago_numerocheque = value
				OnDPAGO_NumeroChequeChanged(m_dpago_numerocheque, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Depositante() As String
		Get
			return m_dpago_depositante
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_depositante) Then
				If Not m_dpago_depositante.Equals(value) Then
					m_dpago_depositante = value
					OnDPAGO_DepositanteChanged(m_dpago_depositante, EventArgs.Empty)
				End If
			Else
				m_dpago_depositante = value
				OnDPAGO_DepositanteChanged(m_dpago_depositante, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Estado() As String
		Get
			return m_dpago_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_dpago_estado) Then
				If Not m_dpago_estado.Equals(value) Then
					m_dpago_estado = value
					OnDPAGO_EstadoChanged(m_dpago_estado, EventArgs.Empty)
				End If
			Else
				m_dpago_estado = value
				OnDPAGO_EstadoChanged(m_dpago_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodModoPago() As String
		Get
			return m_tipos_codmodopago
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codmodopago) Then
				If Not m_tipos_codmodopago.Equals(value) Then
					m_tipos_codmodopago = value
					OnTIPOS_CodModoPagoChanged(m_tipos_codmodopago, EventArgs.Empty)
				End If
			Else
				m_tipos_codmodopago = value
				OnTIPOS_CodModoPagoChanged(m_tipos_codmodopago, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_FechaGiro() As Date
		Get
			return m_dpago_fechagiro
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_dpago_fechagiro) Then
				If Not m_dpago_fechagiro.Equals(value) Then
					m_dpago_fechagiro = value
					OnDPAGO_FechaGiroChanged(m_dpago_fechagiro, EventArgs.Empty)
				End If
			Else
				m_dpago_fechagiro = value
				OnDPAGO_FechaGiroChanged(m_dpago_fechagiro, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_UsrCrea() As String
		Get
			return m_dpago_usrcrea
		End Get
		Set(ByVal value As String)
			m_dpago_usrcrea = value
		End Set
	End Property

	Public Property DPAGO_FecCrea() As Date
		Get
			return m_dpago_feccrea
		End Get
		Set(ByVal value As Date)
			m_dpago_feccrea = value
		End Set
	End Property

	Public Property DPAGO_UsrMod() As String
		Get
			return m_dpago_usrmod
		End Get
		Set(ByVal value As String)
			m_dpago_usrmod = value
		End Set
	End Property

	Public Property DPAGO_FecMod() As Date
		Get
			return m_dpago_fecmod
		End Get
		Set(ByVal value As Date)
			m_dpago_fecmod = value
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
			Return "TESO_DocsPagos"
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
	
	Public Event PVENT_IdChanged As EventHandler
	Public Event DPAGO_IdChanged As EventHandler
	Public Event BANCO_IdChanged As EventHandler
	Public Event CUENT_IdChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoDocumentoChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event DPAGO_FechaChanged As EventHandler
	Public Event DPAGO_FechaVencChanged As EventHandler
    Public Event DPAGO_NumeroChanged As EventHandler
    Public Event Cod_ConfirmacionChanged As EventHandler
	Public Event DPAGO_ImporteChanged As EventHandler
	Public Event DPAGO_TipoCambioChanged As EventHandler
	Public Event DPAGO_LugarGiroChanged As EventHandler
	Public Event DPAGO_GlosaChanged As EventHandler
	Public Event DPAGO_AceptanteChanged As EventHandler
	Public Event DPAGO_DomicilioChanged As EventHandler
	Public Event DPAGO_LocalidadChanged As EventHandler
	Public Event DPAGO_RUCChanged As EventHandler
	Public Event DPAGO_TelefonoChanged As EventHandler
	Public Event DPAGO_RefGiradorChanged As EventHandler
	Public Event DPAGO_CodigoGiradorChanged As EventHandler
	Public Event DPAGO_NumeroChequeChanged As EventHandler
	Public Event DPAGO_DepositanteChanged As EventHandler
	Public Event DPAGO_EstadoChanged As EventHandler
	Public Event TIPOS_CodModoPagoChanged As EventHandler
	Public Event DPAGO_FechaGiroChanged As EventHandler

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_IdChanged(sender, e)
	End Sub

	Public Sub OnBANCO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent BANCO_IdChanged(sender, e)
	End Sub

	Public Sub OnCUENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CUENT_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_FechaChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_FechaVencChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_FechaVencChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_NumeroChanged(sender, e)
    End Sub
    Public Sub OnCod_ConfirmacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent Cod_ConfirmacionChanged(sender, e)
    End Sub

	Public Sub OnDPAGO_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_ImporteChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_TipoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_TipoCambioChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_LugarGiroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_LugarGiroChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_GlosaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_GlosaChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_AceptanteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_AceptanteChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_DomicilioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_DomicilioChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_LocalidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_LocalidadChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_RUCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_RUCChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_TelefonoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_TelefonoChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_RefGiradorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_RefGiradorChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_CodigoGiradorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_CodigoGiradorChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_NumeroChequeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_NumeroChequeChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_DepositanteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_DepositanteChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_EstadoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodModoPagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodModoPagoChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_FechaGiroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_FechaGiroChanged(sender, e)
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


Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Cotizaciones

#Region " Campos "
	
	Private m_cotiz_codigo As String
	Private m_pvent_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_docve_codigo As String
	Private m_entid_codigo As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codcondicionpago As String
	Private m_tipos_codtipodocumento As String
    Private m_tipos_codtipoorigen As String

    Private m_cotiz_direccion_puntoorigen As String
    Private m_cotiz_direccion_puntodestino As String


    Private m_cotiz_id As Long
    Private m_rutas_id As Long
    Private m_rutas_descripcion As String
    Private m_flete_id As Long
    Private m_ubigo_codigo As String
    Private m_ubigo_codigo_origen As String
    Private m_ubigo_codigo_destino As String
    Private m_vehic_certificado As String
    Private m_cotiz_numero As Integer
	Private m_cotiz_nombrecliente As String
	Private m_cotiz_direccioncliente As String
	Private m_cotiz_fechaflete As Date
	Private m_cotiz_fechadocumento As Date
	Private m_cotiz_pesoentm As Decimal
	Private m_cotiz_montoportm As Decimal
	Private m_cotiz_monto As Decimal
	Private m_cotiz_carga As String
	Private m_cotiz_importeventa As Decimal
	Private m_cotiz_porcentajeigv As Decimal
	Private m_cotiz_importeigv As Decimal
	Private m_cotiz_totalventa As Decimal
	Private m_cotiz_totalpagar As Decimal
	Private m_cotiz_tipocambio As Decimal
	Private m_cotiz_tipocambiosunat As Decimal
	Private m_cotiz_observaciones As String
	Private m_cotiz_notapie As String
	Private m_cotiz_guia As String
	Private m_cotiz_precincigv As Boolean
    Private m_cotiz_codreferencia As String
    Private m_cotiz_valorreferencial As Decimal
    Private m_cotiz_totalvalorreferencial As Decimal
	Private m_cotiz_estado As String
	Private m_cotiz_usrcrea As String
	Private m_cotiz_feccrea As Date
	Private m_cotiz_usrmod As String
	Private m_cotiz_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_Cotizaciones
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
	
	Public Property COTIZ_Codigo() As String
		Get
			return m_cotiz_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_codigo) Then
				If Not m_cotiz_codigo.Equals(value) Then
					m_cotiz_codigo = value
					OnCOTIZ_CodigoChanged(m_cotiz_codigo, EventArgs.Empty)
				End If
			Else
				m_cotiz_codigo = value
				OnCOTIZ_CodigoChanged(m_cotiz_codigo, EventArgs.Empty)
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
    Public Property COTIZ_DireccionPuntoOrigen() As String
        Get
            Return m_cotiz_direccion_puntoorigen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_cotiz_direccion_puntoorigen) Then
                If Not m_cotiz_direccion_puntoorigen.Equals(value) Then
                    m_cotiz_direccion_puntoorigen = value
                    OnCotiz_DireccionPuntoOrigenChanged(m_cotiz_direccion_puntoorigen, EventArgs.Empty)
                End If
            Else
                m_cotiz_direccion_puntoorigen = value
                OnCotiz_DireccionPuntoOrigenChanged(m_cotiz_direccion_puntoorigen, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property COTIZ_DireccionPuntoDestino() As String
        Get
            Return m_cotiz_direccion_puntodestino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_cotiz_direccion_puntodestino) Then
                If Not m_cotiz_direccion_puntodestino.Equals(value) Then
                    m_cotiz_direccion_puntodestino = value
                    OnCotiz_DireccionPuntoDestinoChanged(m_cotiz_direccion_puntodestino, EventArgs.Empty)
                End If
            Else
                m_cotiz_direccion_puntodestino = value
                OnCotiz_DireccionPuntoDestinoChanged(m_cotiz_direccion_puntodestino, EventArgs.Empty)
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

	Public Property COTIZ_Id() As Long
		Get
			return m_cotiz_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_cotiz_id) Then
				If Not m_cotiz_id.Equals(value) Then
					m_cotiz_id = value
					OnCOTIZ_IdChanged(m_cotiz_id, EventArgs.Empty)
				End If
			Else
				m_cotiz_id = value
				OnCOTIZ_IdChanged(m_cotiz_id, EventArgs.Empty)
			End If
		End Set
	End Property




    Public Property FLETE_Id() As Long
        Get
            Return m_flete_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_flete_id) Then
                If Not m_flete_id.Equals(value) Then
                    m_flete_id = value
                    OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
                End If
            Else
                m_flete_id = value
                OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
            End If
        End Set
    End Property

    '<CCampo Identity = "0" ForeignKey="1" PrimaryKey="0" xmlns="RUTAS_Id">RUTAS_Id</CCampo>
    '<CCampo Identity = "0" ForeignKey="1" PrimaryKey="0" xmlns="RUTAS_Descripcion">RUTAS_Descripcion</CCampo>
    '<CCampo Identity = "0" ForeignKey="1" PrimaryKey="0" xmlns="VEHIC_Certificado">VEHIC_Certificado</CCampo>
    '<CCampo Identity = "0" ForeignKey="1" PrimaryKey="0" xmlns="UBIGO_CodigoInicio">UBIGO_CodigoInicio</CCampo>
    '<CCampo Identity = "0" ForeignKey="1" PrimaryKey="0" xmlns="UBIGO_CodigoDestino">UBIGO_CodigoDestino</CCampo>
    Public Property RUTAS_Id() As Long
        Get
            Return m_rutas_id
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_rutas_id) Then
                If Not m_rutas_id.Equals(value) Then
                    m_rutas_id = value
                    OnRUTAS_IdChanged(m_rutas_id, EventArgs.Empty)
                End If
            Else
                m_rutas_id = value
                OnRUTAS_IdChanged(m_rutas_id, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property UBIGO_Codigo() As String
        Get
            Return m_ubigo_codigo
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ubigo_codigo) Then
                If Not m_rutas_id.Equals(value) Then
                    m_ubigo_codigo = value
                    OnUBIGO_CodigoChanged(m_ubigo_codigo, EventArgs.Empty)
                End If
            Else
                m_ubigo_codigo = value
                OnUBIGO_CodigoChanged(m_ubigo_codigo, EventArgs.Empty)
            End If
        End Set
    End Property



    Public Property RUTAS_Descripcion() As Long
        Get
            Return m_rutas_descripcion
        End Get
        Set(ByVal value As Long)
            If Not IsNothing(m_rutas_descripcion) Then
                If Not m_rutas_descripcion.Equals(value) Then
                    m_rutas_descripcion = value
                    OnRUTAS_IdChanged(m_rutas_descripcion, EventArgs.Empty)
                End If
            Else
                m_rutas_descripcion = value
                OnRUTAS_IdChanged(m_rutas_descripcion, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property UBIGO_CodigoOrigen() As String
        Get
            Return m_ubigo_codigo_origen
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ubigo_codigo_origen) Then
                If Not m_ubigo_codigo_origen.Equals(value) Then
                    m_ubigo_codigo_origen = value
                    OnTIPOS_CodTipoOrigenChanged(m_ubigo_codigo_origen, EventArgs.Empty)
                End If
            Else
                m_ubigo_codigo_origen = value
                OnTIPOS_CodTipoOrigenChanged(m_ubigo_codigo_origen, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property UBIGO_CodigoDestino() As String
        Get
            Return m_ubigo_codigo_destino
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_ubigo_codigo_destino) Then
                If Not m_ubigo_codigo_destino.Equals(value) Then
                    m_ubigo_codigo_destino = value
                    OnUBIGO_CodigoDestinoChanged(m_ubigo_codigo_destino, EventArgs.Empty)
                End If
            Else
                m_ubigo_codigo_destino = value
                OnUBIGO_CodigoDestinoChanged(m_ubigo_codigo_destino, EventArgs.Empty)
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
                m_ubigo_codigo_destino = value
                OnVEHIC_CertificadoChanged(m_vehic_certificado, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property COTIZ_Numero() As Integer
		Get
			return m_cotiz_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_cotiz_numero) Then
				If Not m_cotiz_numero.Equals(value) Then
					m_cotiz_numero = value
					OnCOTIZ_NumeroChanged(m_cotiz_numero, EventArgs.Empty)
				End If
			Else
				m_cotiz_numero = value
				OnCOTIZ_NumeroChanged(m_cotiz_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_NombreCliente() As String
		Get
			return m_cotiz_nombrecliente
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_nombrecliente) Then
				If Not m_cotiz_nombrecliente.Equals(value) Then
					m_cotiz_nombrecliente = value
					OnCOTIZ_NombreClienteChanged(m_cotiz_nombrecliente, EventArgs.Empty)
				End If
			Else
				m_cotiz_nombrecliente = value
				OnCOTIZ_NombreClienteChanged(m_cotiz_nombrecliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_DireccionCliente() As String
		Get
			return m_cotiz_direccioncliente
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_direccioncliente) Then
				If Not m_cotiz_direccioncliente.Equals(value) Then
					m_cotiz_direccioncliente = value
					OnCOTIZ_DireccionClienteChanged(m_cotiz_direccioncliente, EventArgs.Empty)
				End If
			Else
				m_cotiz_direccioncliente = value
				OnCOTIZ_DireccionClienteChanged(m_cotiz_direccioncliente, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_FechaFlete() As Date
		Get
			return m_cotiz_fechaflete
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_cotiz_fechaflete) Then
				If Not m_cotiz_fechaflete.Equals(value) Then
					m_cotiz_fechaflete = value
					OnCOTIZ_FechaFleteChanged(m_cotiz_fechaflete, EventArgs.Empty)
				End If
			Else
				m_cotiz_fechaflete = value
				OnCOTIZ_FechaFleteChanged(m_cotiz_fechaflete, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_FechaDocumento() As Date
		Get
			return m_cotiz_fechadocumento
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_cotiz_fechadocumento) Then
				If Not m_cotiz_fechadocumento.Equals(value) Then
					m_cotiz_fechadocumento = value
					OnCOTIZ_FechaDocumentoChanged(m_cotiz_fechadocumento, EventArgs.Empty)
				End If
			Else
				m_cotiz_fechadocumento = value
				OnCOTIZ_FechaDocumentoChanged(m_cotiz_fechadocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_PesoEnTM() As Decimal
		Get
			return m_cotiz_pesoentm
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_pesoentm) Then
				If Not m_cotiz_pesoentm.Equals(value) Then
					m_cotiz_pesoentm = value
					OnCOTIZ_PesoEnTMChanged(m_cotiz_pesoentm, EventArgs.Empty)
				End If
			Else
				m_cotiz_pesoentm = value
				OnCOTIZ_PesoEnTMChanged(m_cotiz_pesoentm, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_MontoPorTM() As Decimal
		Get
			return m_cotiz_montoportm
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_montoportm) Then
				If Not m_cotiz_montoportm.Equals(value) Then
					m_cotiz_montoportm = value
					OnCOTIZ_MontoPorTMChanged(m_cotiz_montoportm, EventArgs.Empty)
				End If
			Else
				m_cotiz_montoportm = value
				OnCOTIZ_MontoPorTMChanged(m_cotiz_montoportm, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_Monto() As Decimal
		Get
			return m_cotiz_monto
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_monto) Then
				If Not m_cotiz_monto.Equals(value) Then
					m_cotiz_monto = value
					OnCOTIZ_MontoChanged(m_cotiz_monto, EventArgs.Empty)
				End If
			Else
				m_cotiz_monto = value
				OnCOTIZ_MontoChanged(m_cotiz_monto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_Carga() As String
		Get
			return m_cotiz_carga
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_carga) Then
				If Not m_cotiz_carga.Equals(value) Then
					m_cotiz_carga = value
					OnCOTIZ_CargaChanged(m_cotiz_carga, EventArgs.Empty)
				End If
			Else
				m_cotiz_carga = value
				OnCOTIZ_CargaChanged(m_cotiz_carga, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_ImporteVenta() As Decimal
		Get
			return m_cotiz_importeventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_importeventa) Then
				If Not m_cotiz_importeventa.Equals(value) Then
					m_cotiz_importeventa = value
					OnCOTIZ_ImporteVentaChanged(m_cotiz_importeventa, EventArgs.Empty)
				End If
			Else
				m_cotiz_importeventa = value
				OnCOTIZ_ImporteVentaChanged(m_cotiz_importeventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_PorcentajeIGV() As Decimal
		Get
			return m_cotiz_porcentajeigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_porcentajeigv) Then
				If Not m_cotiz_porcentajeigv.Equals(value) Then
					m_cotiz_porcentajeigv = value
					OnCOTIZ_PorcentajeIGVChanged(m_cotiz_porcentajeigv, EventArgs.Empty)
				End If
			Else
				m_cotiz_porcentajeigv = value
				OnCOTIZ_PorcentajeIGVChanged(m_cotiz_porcentajeigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_ImporteIgv() As Decimal
		Get
			return m_cotiz_importeigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_importeigv) Then
				If Not m_cotiz_importeigv.Equals(value) Then
					m_cotiz_importeigv = value
					OnCOTIZ_ImporteIgvChanged(m_cotiz_importeigv, EventArgs.Empty)
				End If
			Else
				m_cotiz_importeigv = value
				OnCOTIZ_ImporteIgvChanged(m_cotiz_importeigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_TotalVenta() As Decimal
		Get
			return m_cotiz_totalventa
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_totalventa) Then
				If Not m_cotiz_totalventa.Equals(value) Then
					m_cotiz_totalventa = value
					OnCOTIZ_TotalVentaChanged(m_cotiz_totalventa, EventArgs.Empty)
				End If
			Else
				m_cotiz_totalventa = value
				OnCOTIZ_TotalVentaChanged(m_cotiz_totalventa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_TotalPagar() As Decimal
		Get
			return m_cotiz_totalpagar
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_totalpagar) Then
				If Not m_cotiz_totalpagar.Equals(value) Then
					m_cotiz_totalpagar = value
					OnCOTIZ_TotalPagarChanged(m_cotiz_totalpagar, EventArgs.Empty)
				End If
			Else
				m_cotiz_totalpagar = value
				OnCOTIZ_TotalPagarChanged(m_cotiz_totalpagar, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_TipoCambio() As Decimal
		Get
			return m_cotiz_tipocambio
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_tipocambio) Then
				If Not m_cotiz_tipocambio.Equals(value) Then
					m_cotiz_tipocambio = value
					OnCOTIZ_TipoCambioChanged(m_cotiz_tipocambio, EventArgs.Empty)
				End If
			Else
				m_cotiz_tipocambio = value
				OnCOTIZ_TipoCambioChanged(m_cotiz_tipocambio, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_TipoCambioSunat() As Decimal
		Get
			return m_cotiz_tipocambiosunat
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_cotiz_tipocambiosunat) Then
				If Not m_cotiz_tipocambiosunat.Equals(value) Then
					m_cotiz_tipocambiosunat = value
					OnCOTIZ_TipoCambioSunatChanged(m_cotiz_tipocambiosunat, EventArgs.Empty)
				End If
			Else
				m_cotiz_tipocambiosunat = value
				OnCOTIZ_TipoCambioSunatChanged(m_cotiz_tipocambiosunat, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_Observaciones() As String
		Get
			return m_cotiz_observaciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_observaciones) Then
				If Not m_cotiz_observaciones.Equals(value) Then
					m_cotiz_observaciones = value
					OnCOTIZ_ObservacionesChanged(m_cotiz_observaciones, EventArgs.Empty)
				End If
			Else
				m_cotiz_observaciones = value
				OnCOTIZ_ObservacionesChanged(m_cotiz_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_NotaPie() As String
		Get
			return m_cotiz_notapie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_notapie) Then
				If Not m_cotiz_notapie.Equals(value) Then
					m_cotiz_notapie = value
					OnCOTIZ_NotaPieChanged(m_cotiz_notapie, EventArgs.Empty)
				End If
			Else
				m_cotiz_notapie = value
				OnCOTIZ_NotaPieChanged(m_cotiz_notapie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_Guia() As String
		Get
			return m_cotiz_guia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_guia) Then
				If Not m_cotiz_guia.Equals(value) Then
					m_cotiz_guia = value
					OnCOTIZ_GuiaChanged(m_cotiz_guia, EventArgs.Empty)
				End If
			Else
				m_cotiz_guia = value
				OnCOTIZ_GuiaChanged(m_cotiz_guia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_PrecIncIGV() As Boolean
		Get
			return m_cotiz_precincigv
		End Get
		Set(ByVal value As Boolean)
			If Not m_cotiz_precincigv.Equals(value) Then
				m_cotiz_precincigv = value
				OnCOTIZ_PrecIncIGVChanged(m_cotiz_precincigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_CodReferencia() As String
		Get
			return m_cotiz_codreferencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_codreferencia) Then
				If Not m_cotiz_codreferencia.Equals(value) Then
					m_cotiz_codreferencia = value
					OnCOTIZ_CodReferenciaChanged(m_cotiz_codreferencia, EventArgs.Empty)
				End If
			Else
				m_cotiz_codreferencia = value
				OnCOTIZ_CodReferenciaChanged(m_cotiz_codreferencia, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTIZ_Estado() As String
		Get
			return m_cotiz_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_estado) Then
				If Not m_cotiz_estado.Equals(value) Then
					m_cotiz_estado = value
					OnCOTIZ_EstadoChanged(m_cotiz_estado, EventArgs.Empty)
				End If
			Else
				m_cotiz_estado = value
				OnCOTIZ_EstadoChanged(m_cotiz_estado, EventArgs.Empty)
			End If
		End Set
    End Property
    Public Property COTIZ_ValorReferencial() As Decimal
        Get
            Return m_cotiz_valorreferencial
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cotiz_valorreferencial) Then
                If Not m_cotiz_valorreferencial.Equals(value) Then
                    m_cotiz_valorreferencial = value
                    OnCOTIZ_ValorReferencialChanged(m_cotiz_valorreferencial, EventArgs.Empty)
                End If
            Else
                m_cotiz_valorreferencial = value
                OnCOTIZ_ValorReferencialChanged(m_cotiz_valorreferencial, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property COTIZ_TotalValorReferencial() As Decimal
        Get
            Return m_cotiz_totalvalorreferencial
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_cotiz_totalvalorreferencial) Then
                If Not m_cotiz_totalvalorreferencial.Equals(value) Then
                    m_cotiz_totalvalorreferencial = value
                    OnCOTIZ_TotalValorReferencialChanged(m_cotiz_totalvalorreferencial, EventArgs.Empty)
                End If
            Else
                m_cotiz_totalvalorreferencial = value
                OnCOTIZ_TotalValorReferencialChanged(m_cotiz_totalvalorreferencial, EventArgs.Empty)
            End If
        End Set
    End Property



	Public Property COTIZ_UsrCrea() As String
		Get
			return m_cotiz_usrcrea
		End Get
		Set(ByVal value As String)
			m_cotiz_usrcrea = value
		End Set
	End Property

	Public Property COTIZ_FecCrea() As Date
		Get
			return m_cotiz_feccrea
		End Get
		Set(ByVal value As Date)
			m_cotiz_feccrea = value
		End Set
	End Property

	Public Property COTIZ_UsrMod() As String
		Get
			return m_cotiz_usrmod
		End Get
		Set(ByVal value As String)
			m_cotiz_usrmod = value
		End Set
	End Property

	Public Property COTIZ_FecMod() As Date
		Get
			return m_cotiz_fecmod
		End Get
		Set(ByVal value As Date)
			m_cotiz_fecmod = value
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
			Return "TRAN_Cotizaciones"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event COTIZ_CodigoChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodCondicionPagoChanged As EventHandler
    Public Event TIPOS_CodTipoDocumentoChanged As EventHandler


    Public Event COTIZ_DireccionOrigen As EventHandler
    Public Event COTIZ_DireccionDestino As EventHandler

    Public Event TIPOS_CodTipoOrigenChanged As EventHandler
	Public Event COTIZ_IdChanged As EventHandler
    Public Event RUTAS_IdChanged As EventHandler
    Public Event RUTAS_DescripcionChanged As EventHandler
    Public Event FLETE_IdChanged As EventHandler
    Public Event UBIGO_CodigoChanged As EventHandler
    Public Event UBIGO_CodigoOrigenChanged As EventHandler
    Public Event UBIGO_CodigoDestinoChanged As EventHandler
    Public Event VEHIC_CertificadoChanged As EventHandler
    Public Event COTIZ_NumeroChanged As EventHandler
	Public Event COTIZ_NombreClienteChanged As EventHandler
	Public Event COTIZ_DireccionClienteChanged As EventHandler
	Public Event COTIZ_FechaFleteChanged As EventHandler
	Public Event COTIZ_FechaDocumentoChanged As EventHandler
	Public Event COTIZ_PesoEnTMChanged As EventHandler
	Public Event COTIZ_MontoPorTMChanged As EventHandler
	Public Event COTIZ_MontoChanged As EventHandler
	Public Event COTIZ_CargaChanged As EventHandler
	Public Event COTIZ_ImporteVentaChanged As EventHandler
	Public Event COTIZ_PorcentajeIGVChanged As EventHandler
	Public Event COTIZ_ImporteIgvChanged As EventHandler
	Public Event COTIZ_TotalVentaChanged As EventHandler
	Public Event COTIZ_TotalPagarChanged As EventHandler
	Public Event COTIZ_TipoCambioChanged As EventHandler
	Public Event COTIZ_TipoCambioSunatChanged As EventHandler
	Public Event COTIZ_ObservacionesChanged As EventHandler
	Public Event COTIZ_NotaPieChanged As EventHandler
	Public Event COTIZ_GuiaChanged As EventHandler
	Public Event COTIZ_PrecIncIGVChanged As EventHandler
	Public Event COTIZ_CodReferenciaChanged As EventHandler
    Public Event COTIZ_EstadoChanged As EventHandler
    Public Event COTIZ_ValorReferencialChanged As EventHandler
    Public Event COTIZ_TotalValorReferencialChanged As EventHandler

	Public Sub OnCOTIZ_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
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

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodCondicionPagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodCondicionPagoChanged(sender, e)
	End Sub

    Public Sub OnTIPOS_CodTipoDocumentoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPOS_CodTipoDocumentoChanged(sender, e)
    End Sub


    Public Sub OnCotiz_DireccionPuntoOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent COTIZ_DireccionOrigen(sender, e)
    End Sub

    Public Sub OnCotiz_DireccionPuntoDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent COTIZ_DireccionDestino(sender, e)
    End Sub


    Public Sub OnTIPOS_CodTipoOrigenChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoOrigenChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_IdChanged(sender, e)
	End Sub

    Public Sub OnRUTAS_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent RUTAS_IdChanged(sender, e)
    End Sub
    Public Sub OnRUTAS_DescripcionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent RUTAS_DescripcionChanged(sender, e)
    End Sub
    Public Sub OnUBIGO_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent UBIGO_CodigoChanged(sender, e)
    End Sub
    Public Sub OnUBIGO_CodigoOrigenChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent UBIGO_CodigoOrigenChanged(sender, e)
    End Sub
    Public Sub OnUBIGO_CodigoDestinoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent UBIGO_CodigoDestinoChanged(sender, e)
    End Sub

    Public Sub OnVEHIC_CertificadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent VEHIC_CertificadoChanged(sender, e)
    End Sub
    Public Sub OnFLETE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent FLETE_IdChanged(sender, e)
	End Sub


    Public Sub OnCOTIZ_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_NumeroChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_NombreClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_NombreClienteChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_DireccionClienteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_DireccionClienteChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_FechaFleteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_FechaFleteChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_FechaDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_FechaDocumentoChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_PesoEnTMChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_PesoEnTMChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_MontoPorTMChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_MontoPorTMChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_MontoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_MontoChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_CargaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_CargaChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_ImporteVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_ImporteVentaChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_PorcentajeIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_PorcentajeIGVChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_ImporteIgvChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_ImporteIgvChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_TotalVentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_TotalVentaChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_TotalPagarChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_TotalPagarChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_TipoCambioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_TipoCambioChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_TipoCambioSunatChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_TipoCambioSunatChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_ObservacionesChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_NotaPieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_NotaPieChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_GuiaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_GuiaChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_PrecIncIGVChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_PrecIncIGVChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_CodReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_CodReferenciaChanged(sender, e)
	End Sub

	Public Sub OnCOTIZ_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_EstadoChanged(sender, e)
	End Sub
    Public Sub OnCOTIZ_ValorReferencialChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent COTIZ_ValorReferencialChanged(sender, e)
    End Sub
    Public Sub OnCOTIZ_TotalValorReferencialChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent COTIZ_TotalValorReferencialChanged(sender, e)
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


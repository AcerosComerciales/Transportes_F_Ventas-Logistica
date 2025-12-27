Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EABAS_OrdenesCompra

#Region " Campos "
	
	Private m_ordco_codigo As String
	Private m_almac_id As Short
	Private m_entid_codigoproveedor As String
	Private m_docco_codigo As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtipodocdestino As String
	Private m_tipos_codtipopago As String
	Private m_cotco_codigo As String
	Private m_cotco_codreq As String
	Private m_ordco_id As Long
	Private m_ordco_serie As String
	Private m_ordco_numero As Long
	Private m_ordco_fechadocumento As Date
	Private m_ordco_direccionproveedor As String
	Private m_ordco_atencionproveedor As String
	Private m_ordco_telefonoproveedor As String
	Private m_ordco_correoproveedor As String
	Private m_ordco_condiciones As String
	Private m_ordco_observaciones As String
	Private m_ordco_importecompra As Decimal
	Private m_ordco_importeigv As Decimal
	Private m_ordco_totalcompra As Decimal
	Private m_ordco_pesototal As Decimal
	Private m_ordco_estado As String
	Private m_ordco_usrcrea As String
	Private m_ordco_feccrea As Date
	Private m_ordco_usrmod As String
	Private m_ordco_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_OrdenesCompra
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
	
	Public Property ORDCO_Codigo() As String
		Get
			return m_ordco_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_codigo) Then
				If Not m_ordco_codigo.Equals(value) Then
					m_ordco_codigo = value
					OnORDCO_CodigoChanged(m_ordco_codigo, EventArgs.Empty)
				End If
			Else
				m_ordco_codigo = value
				OnORDCO_CodigoChanged(m_ordco_codigo, EventArgs.Empty)
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

	Public Property ENTID_CodigoProveedor() As String
		Get
			return m_entid_codigoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoproveedor) Then
				If Not m_entid_codigoproveedor.Equals(value) Then
					m_entid_codigoproveedor = value
					OnENTID_CodigoProveedorChanged(m_entid_codigoproveedor, EventArgs.Empty)
				End If
			Else
				m_entid_codigoproveedor = value
				OnENTID_CodigoProveedorChanged(m_entid_codigoproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCCO_Codigo() As String
		Get
			return m_docco_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docco_codigo) Then
				If Not m_docco_codigo.Equals(value) Then
					m_docco_codigo = value
					OnDOCCO_CodigoChanged(m_docco_codigo, EventArgs.Empty)
				End If
			Else
				m_docco_codigo = value
				OnDOCCO_CodigoChanged(m_docco_codigo, EventArgs.Empty)
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

	Public Property TIPOS_CodTipoDocDestino() As String
		Get
			return m_tipos_codtipodocdestino
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipodocdestino) Then
				If Not m_tipos_codtipodocdestino.Equals(value) Then
					m_tipos_codtipodocdestino = value
					OnTIPOS_CodTipoDocDestinoChanged(m_tipos_codtipodocdestino, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipodocdestino = value
				OnTIPOS_CodTipoDocDestinoChanged(m_tipos_codtipodocdestino, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoPago() As String
		Get
			return m_tipos_codtipopago
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipopago) Then
				If Not m_tipos_codtipopago.Equals(value) Then
					m_tipos_codtipopago = value
					OnTIPOS_CodTipoPagoChanged(m_tipos_codtipopago, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipopago = value
				OnTIPOS_CodTipoPagoChanged(m_tipos_codtipopago, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_Codigo() As String
		Get
			return m_cotco_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotco_codigo) Then
				If Not m_cotco_codigo.Equals(value) Then
					m_cotco_codigo = value
					OnCOTCO_CodigoChanged(m_cotco_codigo, EventArgs.Empty)
				End If
			Else
				m_cotco_codigo = value
				OnCOTCO_CodigoChanged(m_cotco_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_CodReq() As String
		Get
			return m_cotco_codreq
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotco_codreq) Then
				If Not m_cotco_codreq.Equals(value) Then
					m_cotco_codreq = value
					OnCOTCO_CodReqChanged(m_cotco_codreq, EventArgs.Empty)
				End If
			Else
				m_cotco_codreq = value
				OnCOTCO_CodReqChanged(m_cotco_codreq, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_Id() As Long
		Get
			return m_ordco_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_ordco_id) Then
				If Not m_ordco_id.Equals(value) Then
					m_ordco_id = value
					OnORDCO_IdChanged(m_ordco_id, EventArgs.Empty)
				End If
			Else
				m_ordco_id = value
				OnORDCO_IdChanged(m_ordco_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_Serie() As String
		Get
			return m_ordco_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_serie) Then
				If Not m_ordco_serie.Equals(value) Then
					m_ordco_serie = value
					OnORDCO_SerieChanged(m_ordco_serie, EventArgs.Empty)
				End If
			Else
				m_ordco_serie = value
				OnORDCO_SerieChanged(m_ordco_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_Numero() As Long
		Get
			return m_ordco_numero
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_ordco_numero) Then
				If Not m_ordco_numero.Equals(value) Then
					m_ordco_numero = value
					OnORDCO_NumeroChanged(m_ordco_numero, EventArgs.Empty)
				End If
			Else
				m_ordco_numero = value
				OnORDCO_NumeroChanged(m_ordco_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_FechaDocumento() As Date
		Get
			return m_ordco_fechadocumento
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_ordco_fechadocumento) Then
				If Not m_ordco_fechadocumento.Equals(value) Then
					m_ordco_fechadocumento = value
					OnORDCO_FechaDocumentoChanged(m_ordco_fechadocumento, EventArgs.Empty)
				End If
			Else
				m_ordco_fechadocumento = value
				OnORDCO_FechaDocumentoChanged(m_ordco_fechadocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_DireccionProveedor() As String
		Get
			return m_ordco_direccionproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_direccionproveedor) Then
				If Not m_ordco_direccionproveedor.Equals(value) Then
					m_ordco_direccionproveedor = value
					OnORDCO_DireccionProveedorChanged(m_ordco_direccionproveedor, EventArgs.Empty)
				End If
			Else
				m_ordco_direccionproveedor = value
				OnORDCO_DireccionProveedorChanged(m_ordco_direccionproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_AtencionProveedor() As String
		Get
			return m_ordco_atencionproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_atencionproveedor) Then
				If Not m_ordco_atencionproveedor.Equals(value) Then
					m_ordco_atencionproveedor = value
					OnORDCO_AtencionProveedorChanged(m_ordco_atencionproveedor, EventArgs.Empty)
				End If
			Else
				m_ordco_atencionproveedor = value
				OnORDCO_AtencionProveedorChanged(m_ordco_atencionproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_TelefonoProveedor() As String
		Get
			return m_ordco_telefonoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_telefonoproveedor) Then
				If Not m_ordco_telefonoproveedor.Equals(value) Then
					m_ordco_telefonoproveedor = value
					OnORDCO_TelefonoProveedorChanged(m_ordco_telefonoproveedor, EventArgs.Empty)
				End If
			Else
				m_ordco_telefonoproveedor = value
				OnORDCO_TelefonoProveedorChanged(m_ordco_telefonoproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_CorreoProveedor() As String
		Get
			return m_ordco_correoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_correoproveedor) Then
				If Not m_ordco_correoproveedor.Equals(value) Then
					m_ordco_correoproveedor = value
					OnORDCO_CorreoProveedorChanged(m_ordco_correoproveedor, EventArgs.Empty)
				End If
			Else
				m_ordco_correoproveedor = value
				OnORDCO_CorreoProveedorChanged(m_ordco_correoproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_Condiciones() As String
		Get
			return m_ordco_condiciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_condiciones) Then
				If Not m_ordco_condiciones.Equals(value) Then
					m_ordco_condiciones = value
					OnORDCO_CondicionesChanged(m_ordco_condiciones, EventArgs.Empty)
				End If
			Else
				m_ordco_condiciones = value
				OnORDCO_CondicionesChanged(m_ordco_condiciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_Observaciones() As String
		Get
			return m_ordco_observaciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_observaciones) Then
				If Not m_ordco_observaciones.Equals(value) Then
					m_ordco_observaciones = value
					OnORDCO_ObservacionesChanged(m_ordco_observaciones, EventArgs.Empty)
				End If
			Else
				m_ordco_observaciones = value
				OnORDCO_ObservacionesChanged(m_ordco_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_ImporteCompra() As Decimal
		Get
			return m_ordco_importecompra
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordco_importecompra) Then
				If Not m_ordco_importecompra.Equals(value) Then
					m_ordco_importecompra = value
					OnORDCO_ImporteCompraChanged(m_ordco_importecompra, EventArgs.Empty)
				End If
			Else
				m_ordco_importecompra = value
				OnORDCO_ImporteCompraChanged(m_ordco_importecompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_ImporteIgv() As Decimal
		Get
			return m_ordco_importeigv
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordco_importeigv) Then
				If Not m_ordco_importeigv.Equals(value) Then
					m_ordco_importeigv = value
					OnORDCO_ImporteIgvChanged(m_ordco_importeigv, EventArgs.Empty)
				End If
			Else
				m_ordco_importeigv = value
				OnORDCO_ImporteIgvChanged(m_ordco_importeigv, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_TotalCompra() As Decimal
		Get
			return m_ordco_totalcompra
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordco_totalcompra) Then
				If Not m_ordco_totalcompra.Equals(value) Then
					m_ordco_totalcompra = value
					OnORDCO_TotalCompraChanged(m_ordco_totalcompra, EventArgs.Empty)
				End If
			Else
				m_ordco_totalcompra = value
				OnORDCO_TotalCompraChanged(m_ordco_totalcompra, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_PesoTotal() As Decimal
		Get
			return m_ordco_pesototal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_ordco_pesototal) Then
				If Not m_ordco_pesototal.Equals(value) Then
					m_ordco_pesototal = value
					OnORDCO_PesoTotalChanged(m_ordco_pesototal, EventArgs.Empty)
				End If
			Else
				m_ordco_pesototal = value
				OnORDCO_PesoTotalChanged(m_ordco_pesototal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_Estado() As String
		Get
			return m_ordco_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ordco_estado) Then
				If Not m_ordco_estado.Equals(value) Then
					m_ordco_estado = value
					OnORDCO_EstadoChanged(m_ordco_estado, EventArgs.Empty)
				End If
			Else
				m_ordco_estado = value
				OnORDCO_EstadoChanged(m_ordco_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ORDCO_UsrCrea() As String
		Get
			return m_ordco_usrcrea
		End Get
		Set(ByVal value As String)
			m_ordco_usrcrea = value
		End Set
	End Property

	Public Property ORDCO_FecCrea() As Date
		Get
			return m_ordco_feccrea
		End Get
		Set(ByVal value As Date)
			m_ordco_feccrea = value
		End Set
	End Property

	Public Property ORDCO_UsrMod() As String
		Get
			return m_ordco_usrmod
		End Get
		Set(ByVal value As String)
			m_ordco_usrmod = value
		End Set
	End Property

	Public Property ORDCO_FecMod() As Date
		Get
			return m_ordco_fecmod
		End Get
		Set(ByVal value As Date)
			m_ordco_fecmod = value
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
			Return "ABAS_OrdenesCompra"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Logistica"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event ORDCO_CodigoChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event DOCCO_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoDocDestinoChanged As EventHandler
	Public Event TIPOS_CodTipoPagoChanged As EventHandler
	Public Event COTCO_CodigoChanged As EventHandler
	Public Event COTCO_CodReqChanged As EventHandler
	Public Event ORDCO_IdChanged As EventHandler
	Public Event ORDCO_SerieChanged As EventHandler
	Public Event ORDCO_NumeroChanged As EventHandler
	Public Event ORDCO_FechaDocumentoChanged As EventHandler
	Public Event ORDCO_DireccionProveedorChanged As EventHandler
	Public Event ORDCO_AtencionProveedorChanged As EventHandler
	Public Event ORDCO_TelefonoProveedorChanged As EventHandler
	Public Event ORDCO_CorreoProveedorChanged As EventHandler
	Public Event ORDCO_CondicionesChanged As EventHandler
	Public Event ORDCO_ObservacionesChanged As EventHandler
	Public Event ORDCO_ImporteCompraChanged As EventHandler
	Public Event ORDCO_ImporteIgvChanged As EventHandler
	Public Event ORDCO_TotalCompraChanged As EventHandler
	Public Event ORDCO_PesoTotalChanged As EventHandler
	Public Event ORDCO_EstadoChanged As EventHandler

	Public Sub OnORDCO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoProveedorChanged(sender, e)
	End Sub

	Public Sub OnDOCCO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoDocDestinoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoDocDestinoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoPagoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoPagoChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_CodReqChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_CodReqChanged(sender, e)
	End Sub

	Public Sub OnORDCO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_IdChanged(sender, e)
	End Sub

	Public Sub OnORDCO_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_SerieChanged(sender, e)
	End Sub

	Public Sub OnORDCO_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_NumeroChanged(sender, e)
	End Sub

	Public Sub OnORDCO_FechaDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_FechaDocumentoChanged(sender, e)
	End Sub

	Public Sub OnORDCO_DireccionProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_DireccionProveedorChanged(sender, e)
	End Sub

	Public Sub OnORDCO_AtencionProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_AtencionProveedorChanged(sender, e)
	End Sub

	Public Sub OnORDCO_TelefonoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_TelefonoProveedorChanged(sender, e)
	End Sub

	Public Sub OnORDCO_CorreoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_CorreoProveedorChanged(sender, e)
	End Sub

	Public Sub OnORDCO_CondicionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_CondicionesChanged(sender, e)
	End Sub

	Public Sub OnORDCO_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_ObservacionesChanged(sender, e)
	End Sub

	Public Sub OnORDCO_ImporteCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_ImporteCompraChanged(sender, e)
	End Sub

	Public Sub OnORDCO_ImporteIgvChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_ImporteIgvChanged(sender, e)
	End Sub

	Public Sub OnORDCO_TotalCompraChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_TotalCompraChanged(sender, e)
	End Sub

	Public Sub OnORDCO_PesoTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_PesoTotalChanged(sender, e)
	End Sub

	Public Sub OnORDCO_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ORDCO_EstadoChanged(sender, e)
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


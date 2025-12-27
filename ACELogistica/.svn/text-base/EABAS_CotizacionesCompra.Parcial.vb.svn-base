Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EABAS_CotizacionesCompra

#Region " Campos "
	
	Private m_cotco_codigo As String
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_almac_id As Short
	Private m_entid_codigoproveedor As String
	Private m_cotco_codreq As String
	Private m_cotco_id As Long
	Private m_cotco_numero As Integer
	Private m_cotco_fechadocumento As Date
	Private m_cotco_direccionproveedor As String
	Private m_cotco_atencionproveedor As String
	Private m_cotco_telefonoproveedor As String
	Private m_cotco_correoproveedor As String
	Private m_cotco_estado As String
	Private m_cotco_usrcrea As String
	Private m_cotco_feccrea As Date
	Private m_cotco_usrmod As String
	Private m_cotco_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_CotizacionesCompra
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

	Public Property COTCO_Id() As Long
		Get
			return m_cotco_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_cotco_id) Then
				If Not m_cotco_id.Equals(value) Then
					m_cotco_id = value
					OnCOTCO_IdChanged(m_cotco_id, EventArgs.Empty)
				End If
			Else
				m_cotco_id = value
				OnCOTCO_IdChanged(m_cotco_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_Numero() As Integer
		Get
			return m_cotco_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_cotco_numero) Then
				If Not m_cotco_numero.Equals(value) Then
					m_cotco_numero = value
					OnCOTCO_NumeroChanged(m_cotco_numero, EventArgs.Empty)
				End If
			Else
				m_cotco_numero = value
				OnCOTCO_NumeroChanged(m_cotco_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_FechaDocumento() As Date
		Get
			return m_cotco_fechadocumento
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_cotco_fechadocumento) Then
				If Not m_cotco_fechadocumento.Equals(value) Then
					m_cotco_fechadocumento = value
					OnCOTCO_FechaDocumentoChanged(m_cotco_fechadocumento, EventArgs.Empty)
				End If
			Else
				m_cotco_fechadocumento = value
				OnCOTCO_FechaDocumentoChanged(m_cotco_fechadocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_DireccionProveedor() As String
		Get
			return m_cotco_direccionproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotco_direccionproveedor) Then
				If Not m_cotco_direccionproveedor.Equals(value) Then
					m_cotco_direccionproveedor = value
					OnCOTCO_DireccionProveedorChanged(m_cotco_direccionproveedor, EventArgs.Empty)
				End If
			Else
				m_cotco_direccionproveedor = value
				OnCOTCO_DireccionProveedorChanged(m_cotco_direccionproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_AtencionProveedor() As String
		Get
			return m_cotco_atencionproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotco_atencionproveedor) Then
				If Not m_cotco_atencionproveedor.Equals(value) Then
					m_cotco_atencionproveedor = value
					OnCOTCO_AtencionProveedorChanged(m_cotco_atencionproveedor, EventArgs.Empty)
				End If
			Else
				m_cotco_atencionproveedor = value
				OnCOTCO_AtencionProveedorChanged(m_cotco_atencionproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_TelefonoProveedor() As String
		Get
			return m_cotco_telefonoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotco_telefonoproveedor) Then
				If Not m_cotco_telefonoproveedor.Equals(value) Then
					m_cotco_telefonoproveedor = value
					OnCOTCO_TelefonoProveedorChanged(m_cotco_telefonoproveedor, EventArgs.Empty)
				End If
			Else
				m_cotco_telefonoproveedor = value
				OnCOTCO_TelefonoProveedorChanged(m_cotco_telefonoproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_CorreoProveedor() As String
		Get
			return m_cotco_correoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotco_correoproveedor) Then
				If Not m_cotco_correoproveedor.Equals(value) Then
					m_cotco_correoproveedor = value
					OnCOTCO_CorreoProveedorChanged(m_cotco_correoproveedor, EventArgs.Empty)
				End If
			Else
				m_cotco_correoproveedor = value
				OnCOTCO_CorreoProveedorChanged(m_cotco_correoproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_Estado() As String
		Get
			return m_cotco_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotco_estado) Then
				If Not m_cotco_estado.Equals(value) Then
					m_cotco_estado = value
					OnCOTCO_EstadoChanged(m_cotco_estado, EventArgs.Empty)
				End If
			Else
				m_cotco_estado = value
				OnCOTCO_EstadoChanged(m_cotco_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COTCO_UsrCrea() As String
		Get
			return m_cotco_usrcrea
		End Get
		Set(ByVal value As String)
			m_cotco_usrcrea = value
		End Set
	End Property

	Public Property COTCO_FecCrea() As Date
		Get
			return m_cotco_feccrea
		End Get
		Set(ByVal value As Date)
			m_cotco_feccrea = value
		End Set
	End Property

	Public Property COTCO_UsrMod() As String
		Get
			return m_cotco_usrmod
		End Get
		Set(ByVal value As String)
			m_cotco_usrmod = value
		End Set
	End Property

	Public Property COTCO_FecMod() As Date
		Get
			return m_cotco_fecmod
		End Get
		Set(ByVal value As Date)
			m_cotco_fecmod = value
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
			Return "ABAS_CotizacionesCompra"
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
	
	Public Event COTCO_CodigoChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event COTCO_CodReqChanged As EventHandler
	Public Event COTCO_IdChanged As EventHandler
	Public Event COTCO_NumeroChanged As EventHandler
	Public Event COTCO_FechaDocumentoChanged As EventHandler
	Public Event COTCO_DireccionProveedorChanged As EventHandler
	Public Event COTCO_AtencionProveedorChanged As EventHandler
	Public Event COTCO_TelefonoProveedorChanged As EventHandler
	Public Event COTCO_CorreoProveedorChanged As EventHandler
	Public Event COTCO_EstadoChanged As EventHandler

	Public Sub OnCOTCO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub

	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoProveedorChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_CodReqChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_CodReqChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_IdChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_NumeroChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_FechaDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_FechaDocumentoChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_DireccionProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_DireccionProveedorChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_AtencionProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_AtencionProveedorChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_TelefonoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_TelefonoProveedorChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_CorreoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_CorreoProveedorChanged(sender, e)
	End Sub

	Public Sub OnCOTCO_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTCO_EstadoChanged(sender, e)
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


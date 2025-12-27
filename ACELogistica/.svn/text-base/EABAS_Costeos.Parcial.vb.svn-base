Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EABAS_Costeos

#Region " Campos "
	
	Private m_docco_codigo As String
	Private m_entid_codigoproveedor As String
	Private m_doccd_item As Short
	Private m_coste_item As Short
	Private m_tipos_codtipocosteo As String
	Private m_tipos_codtipomoneda As String
	Private m_coste_porcentaje As Decimal
	Private m_coste_importe As Decimal
	Private m_coste_codigodocumento As String
	Private m_coste_codigoproveedor As String
	Private m_coste_operacion As Short
	Private m_coste_cantidad As Short
	Private m_artic_codigo As String
	Private m_coste_usrcrea As String
	Private m_coste_feccrea As Date
	Private m_coste_usrmod As String
	Private m_coste_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_Costeos
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

	Public Property DOCCD_Item() As Short
		Get
			return m_doccd_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_doccd_item) Then
				If Not m_doccd_item.Equals(value) Then
					m_doccd_item = value
					OnDOCCD_ItemChanged(m_doccd_item, EventArgs.Empty)
				End If
			Else
				m_doccd_item = value
				OnDOCCD_ItemChanged(m_doccd_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COSTE_Item() As Short
		Get
			return m_coste_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_coste_item) Then
				If Not m_coste_item.Equals(value) Then
					m_coste_item = value
					OnCOSTE_ItemChanged(m_coste_item, EventArgs.Empty)
				End If
			Else
				m_coste_item = value
				OnCOSTE_ItemChanged(m_coste_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoCosteo() As String
		Get
			return m_tipos_codtipocosteo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipocosteo) Then
				If Not m_tipos_codtipocosteo.Equals(value) Then
					m_tipos_codtipocosteo = value
					OnTIPOS_CodTipoCosteoChanged(m_tipos_codtipocosteo, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipocosteo = value
				OnTIPOS_CodTipoCosteoChanged(m_tipos_codtipocosteo, EventArgs.Empty)
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

	Public Property COSTE_Porcentaje() As Decimal
		Get
			return m_coste_porcentaje
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_coste_porcentaje) Then
				If Not m_coste_porcentaje.Equals(value) Then
					m_coste_porcentaje = value
					OnCOSTE_PorcentajeChanged(m_coste_porcentaje, EventArgs.Empty)
				End If
			Else
				m_coste_porcentaje = value
				OnCOSTE_PorcentajeChanged(m_coste_porcentaje, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COSTE_Importe() As Decimal
		Get
			return m_coste_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_coste_importe) Then
				If Not m_coste_importe.Equals(value) Then
					m_coste_importe = value
					OnCOSTE_ImporteChanged(m_coste_importe, EventArgs.Empty)
				End If
			Else
				m_coste_importe = value
				OnCOSTE_ImporteChanged(m_coste_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COSTE_CodigoDocumento() As String
		Get
			return m_coste_codigodocumento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_coste_codigodocumento) Then
				If Not m_coste_codigodocumento.Equals(value) Then
					m_coste_codigodocumento = value
					OnCOSTE_CodigoDocumentoChanged(m_coste_codigodocumento, EventArgs.Empty)
				End If
			Else
				m_coste_codigodocumento = value
				OnCOSTE_CodigoDocumentoChanged(m_coste_codigodocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COSTE_CodigoProveedor() As String
		Get
			return m_coste_codigoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_coste_codigoproveedor) Then
				If Not m_coste_codigoproveedor.Equals(value) Then
					m_coste_codigoproveedor = value
					OnCOSTE_CodigoProveedorChanged(m_coste_codigoproveedor, EventArgs.Empty)
				End If
			Else
				m_coste_codigoproveedor = value
				OnCOSTE_CodigoProveedorChanged(m_coste_codigoproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COSTE_Operacion() As Short
		Get
			return m_coste_operacion
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_coste_operacion) Then
				If Not m_coste_operacion.Equals(value) Then
					m_coste_operacion = value
					OnCOSTE_OperacionChanged(m_coste_operacion, EventArgs.Empty)
				End If
			Else
				m_coste_operacion = value
				OnCOSTE_OperacionChanged(m_coste_operacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COSTE_Cantidad() As Short
		Get
			return m_coste_cantidad
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_coste_cantidad) Then
				If Not m_coste_cantidad.Equals(value) Then
					m_coste_cantidad = value
					OnCOSTE_CantidadChanged(m_coste_cantidad, EventArgs.Empty)
				End If
			Else
				m_coste_cantidad = value
				OnCOSTE_CantidadChanged(m_coste_cantidad, EventArgs.Empty)
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

	Public Property COSTE_UsrCrea() As String
		Get
			return m_coste_usrcrea
		End Get
		Set(ByVal value As String)
			m_coste_usrcrea = value
		End Set
	End Property

	Public Property COSTE_FecCrea() As Date
		Get
			return m_coste_feccrea
		End Get
		Set(ByVal value As Date)
			m_coste_feccrea = value
		End Set
	End Property

	Public Property COSTE_UsrMod() As String
		Get
			return m_coste_usrmod
		End Get
		Set(ByVal value As String)
			m_coste_usrmod = value
		End Set
	End Property

	Public Property COSTE_FecMod() As Date
		Get
			return m_coste_fecmod
		End Get
		Set(ByVal value As Date)
			m_coste_fecmod = value
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
			Return "ABAS_Costeos"
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
	
	Public Event DOCCO_CodigoChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event DOCCD_ItemChanged As EventHandler
	Public Event COSTE_ItemChanged As EventHandler
	Public Event TIPOS_CodTipoCosteoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event COSTE_PorcentajeChanged As EventHandler
	Public Event COSTE_ImporteChanged As EventHandler
	Public Event COSTE_CodigoDocumentoChanged As EventHandler
	Public Event COSTE_CodigoProveedorChanged As EventHandler
	Public Event COSTE_OperacionChanged As EventHandler
	Public Event COSTE_CantidadChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler

	Public Sub OnDOCCO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCO_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoProveedorChanged(sender, e)
	End Sub

	Public Sub OnDOCCD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_ItemChanged(sender, e)
	End Sub

	Public Sub OnCOSTE_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COSTE_ItemChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoCosteoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoCosteoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnCOSTE_PorcentajeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COSTE_PorcentajeChanged(sender, e)
	End Sub

	Public Sub OnCOSTE_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COSTE_ImporteChanged(sender, e)
	End Sub

	Public Sub OnCOSTE_CodigoDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COSTE_CodigoDocumentoChanged(sender, e)
	End Sub

	Public Sub OnCOSTE_CodigoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COSTE_CodigoProveedorChanged(sender, e)
	End Sub

	Public Sub OnCOSTE_OperacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COSTE_OperacionChanged(sender, e)
	End Sub

	Public Sub OnCOSTE_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COSTE_CantidadChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
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


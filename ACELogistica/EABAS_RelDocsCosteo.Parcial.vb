Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EABAS_RelDocsCosteo

#Region " Campos "
	
	Private m_docco_codigo As String
	Private m_doccd_item As Short
	Private m_entid_codigoproveedor As String
	Private m_coste_item As Short
	Private m_docco_codigodetalle As String
	Private m_doccd_itemdetalle As Short
	Private m_rdcos_usrcrea As String
	Private m_rdcos_feccrea As Date
	Private m_rdcos_usrmod As String
	Private m_rdcos_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlABAS_RelDocsCosteo
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
	Public Property DOCCO_CodigoDetalle() As String
		Get
			return m_docco_codigodetalle
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docco_codigodetalle) Then
				If Not m_docco_codigodetalle.Equals(value) Then
					m_docco_codigodetalle = value
					OnDOCCO_CodigoDetalleChanged(m_docco_codigodetalle, EventArgs.Empty)
				End If
			Else
				m_docco_codigodetalle = value
				OnDOCCO_CodigoDetalleChanged(m_docco_codigodetalle, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DOCCD_ItemDetalle() As Short
		Get
			return m_doccd_itemdetalle
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_doccd_itemdetalle) Then
				If Not m_doccd_itemdetalle.Equals(value) Then
					m_doccd_itemdetalle = value
					OnDOCCD_ItemDetalleChanged(m_doccd_itemdetalle, EventArgs.Empty)
				End If
			Else
				m_doccd_itemdetalle = value
				OnDOCCD_ItemDetalleChanged(m_doccd_itemdetalle, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property RDCOS_UsrCrea() As String
		Get
			return m_rdcos_usrcrea
		End Get
		Set(ByVal value As String)
			m_rdcos_usrcrea = value
		End Set
	End Property
	Public Property RDCOS_FecCrea() As Date
		Get
			return m_rdcos_feccrea
		End Get
		Set(ByVal value As Date)
			m_rdcos_feccrea = value
		End Set
	End Property
	Public Property RDCOS_UsrMod() As String
		Get
			return m_rdcos_usrmod
		End Get
		Set(ByVal value As String)
			m_rdcos_usrmod = value
		End Set
	End Property
	Public Property RDCOS_FecMod() As Date
		Get
			return m_rdcos_fecmod
		End Get
		Set(ByVal value As Date)
			m_rdcos_fecmod = value
		End Set
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
			Return "ABAS_RelDocsCosteo"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Logistica"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event DOCCO_CodigoChanged As EventHandler
	Public Event DOCCD_ItemChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event COSTE_ItemChanged As EventHandler
	Public Event DOCCO_CodigoDetalleChanged As EventHandler
	Public Event DOCCD_ItemDetalleChanged As EventHandler
	Public Sub OnDOCCO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCO_CodigoChanged(sender, e)
	End Sub
	Public Sub OnDOCCD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_ItemChanged(sender, e)
	End Sub
	Public Sub OnENTID_CodigoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoProveedorChanged(sender, e)
	End Sub
	Public Sub OnCOSTE_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COSTE_ItemChanged(sender, e)
	End Sub
	Public Sub OnDOCCO_CodigoDetalleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCO_CodigoDetalleChanged(sender, e)
	End Sub
	Public Sub OnDOCCD_ItemDetalleChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCCD_ItemDetalleChanged(sender, e)
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


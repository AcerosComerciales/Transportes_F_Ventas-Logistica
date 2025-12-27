Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EProveedores

#Region " Campos "
	
	Private m_entid_codigo As String
	Private m_prove_atencion As String
	Private m_prove_contacto As String
	Private m_prove_usrcrea As String
	Private m_prove_feccrea As Date
	Private m_prove_usrmod As String
	Private m_prove_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlProveedores
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
	Public Property PROVE_Atencion() As String
		Get
			return m_prove_atencion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_prove_atencion) Then
				If Not m_prove_atencion.Equals(value) Then
					m_prove_atencion = value
					OnPROVE_AtencionChanged(m_prove_atencion, EventArgs.Empty)
				End If
			Else
				m_prove_atencion = value
				OnPROVE_AtencionChanged(m_prove_atencion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PROVE_Contacto() As String
		Get
			return m_prove_contacto
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_prove_contacto) Then
				If Not m_prove_contacto.Equals(value) Then
					m_prove_contacto = value
					OnPROVE_ContactoChanged(m_prove_contacto, EventArgs.Empty)
				End If
			Else
				m_prove_contacto = value
				OnPROVE_ContactoChanged(m_prove_contacto, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PROVE_UsrCrea() As String
		Get
			return m_prove_usrcrea
		End Get
		Set(ByVal value As String)
			m_prove_usrcrea = value
		End Set
	End Property
	Public Property PROVE_FecCrea() As Date
		Get
			return m_prove_feccrea
		End Get
		Set(ByVal value As Date)
			m_prove_feccrea = value
		End Set
	End Property
	Public Property PROVE_UsrMod() As String
		Get
			return m_prove_usrmod
		End Get
		Set(ByVal value As String)
			m_prove_usrmod = value
		End Set
	End Property
	Public Property PROVE_FecMod() As Date
		Get
			return m_prove_fecmod
		End Get
		Set(ByVal value As Date)
			m_prove_fecmod = value
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
			Return "Proveedores"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event PROVE_AtencionChanged As EventHandler
	Public Event PROVE_ContactoChanged As EventHandler
	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub
	Public Sub OnPROVE_AtencionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PROVE_AtencionChanged(sender, e)
	End Sub
	Public Sub OnPROVE_ContactoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PROVE_ContactoChanged(sender, e)
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


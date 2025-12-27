Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ESucursales

#Region " Campos "
	
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_ubigo_codigo As String
	Private m_empre_codigo As String
	Private m_sucur_nombre As String
	Private m_sucur_direccion As String
	Private m_sucur_telefono As String
	Private m_sucur_usrcrea As String
	Private m_sucur_feccrea As Date
	Private m_sucur_usrmod As String
	Private m_sucur_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlSucursales
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
	Public Property UBIGO_Codigo() As String
		Get
			return m_ubigo_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ubigo_codigo) Then
				If Not m_ubigo_codigo.Equals(value) Then
					m_ubigo_codigo = value
					OnUBIGO_CodigoChanged(m_ubigo_codigo, EventArgs.Empty)
				End If
			Else
				m_ubigo_codigo = value
				OnUBIGO_CodigoChanged(m_ubigo_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property EMPRE_Codigo() As String
		Get
			return m_empre_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_empre_codigo) Then
				If Not m_empre_codigo.Equals(value) Then
					m_empre_codigo = value
					OnEMPRE_CodigoChanged(m_empre_codigo, EventArgs.Empty)
				End If
			Else
				m_empre_codigo = value
				OnEMPRE_CodigoChanged(m_empre_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SUCUR_Nombre() As String
		Get
			return m_sucur_nombre
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_sucur_nombre) Then
				If Not m_sucur_nombre.Equals(value) Then
					m_sucur_nombre = value
					OnSUCUR_NombreChanged(m_sucur_nombre, EventArgs.Empty)
				End If
			Else
				m_sucur_nombre = value
				OnSUCUR_NombreChanged(m_sucur_nombre, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SUCUR_Direccion() As String
		Get
			return m_sucur_direccion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_sucur_direccion) Then
				If Not m_sucur_direccion.Equals(value) Then
					m_sucur_direccion = value
					OnSUCUR_DireccionChanged(m_sucur_direccion, EventArgs.Empty)
				End If
			Else
				m_sucur_direccion = value
				OnSUCUR_DireccionChanged(m_sucur_direccion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SUCUR_Telefono() As String
		Get
			return m_sucur_telefono
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_sucur_telefono) Then
				If Not m_sucur_telefono.Equals(value) Then
					m_sucur_telefono = value
					OnSUCUR_TelefonoChanged(m_sucur_telefono, EventArgs.Empty)
				End If
			Else
				m_sucur_telefono = value
				OnSUCUR_TelefonoChanged(m_sucur_telefono, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SUCUR_UsrCrea() As String
		Get
			return m_sucur_usrcrea
		End Get
		Set(ByVal value As String)
			m_sucur_usrcrea = value
		End Set
	End Property
	Public Property SUCUR_FecCrea() As Date
		Get
			return m_sucur_feccrea
		End Get
		Set(ByVal value As Date)
			m_sucur_feccrea = value
		End Set
	End Property
	Public Property SUCUR_UsrMod() As String
		Get
			return m_sucur_usrmod
		End Get
		Set(ByVal value As String)
			m_sucur_usrmod = value
		End Set
	End Property
	Public Property SUCUR_FecMod() As Date
		Get
			return m_sucur_fecmod
		End Get
		Set(ByVal value As Date)
			m_sucur_fecmod = value
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
			Return "Sucursales"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event UBIGO_CodigoChanged As EventHandler
	Public Event EMPRE_CodigoChanged As EventHandler
	Public Event SUCUR_NombreChanged As EventHandler
	Public Event SUCUR_DireccionChanged As EventHandler
	Public Event SUCUR_TelefonoChanged As EventHandler
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnUBIGO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent UBIGO_CodigoChanged(sender, e)
	End Sub
	Public Sub OnEMPRE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent EMPRE_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_NombreChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_NombreChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_DireccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_DireccionChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_TelefonoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_TelefonoChanged(sender, e)
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


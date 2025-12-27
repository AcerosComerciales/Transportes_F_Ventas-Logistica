Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EUbigeos

#Region " Campos "
	
	Private m_ubigo_codigo As String
	Private m_ubigo_codpadre As String
	Private m_ubigo_descripcion As String
	Private m_ubigo_desccorta As String
	Private m_ubigo_protegido As Boolean
	Private m_ubigo_usrcrea As String
	Private m_ubigo_feccrea As Date
	Private m_ubigo_usrmod As String
	Private m_ubigo_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlUbigeos
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
	Public Property UBIGO_CodPadre() As String
		Get
			return m_ubigo_codpadre
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ubigo_codpadre) Then
				If Not m_ubigo_codpadre.Equals(value) Then
					m_ubigo_codpadre = value
					OnUBIGO_CodPadreChanged(m_ubigo_codpadre, EventArgs.Empty)
				End If
			Else
				m_ubigo_codpadre = value
				OnUBIGO_CodPadreChanged(m_ubigo_codpadre, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property UBIGO_Descripcion() As String
		Get
			return m_ubigo_descripcion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ubigo_descripcion) Then
				If Not m_ubigo_descripcion.Equals(value) Then
					m_ubigo_descripcion = value
					OnUBIGO_DescripcionChanged(m_ubigo_descripcion, EventArgs.Empty)
				End If
			Else
				m_ubigo_descripcion = value
				OnUBIGO_DescripcionChanged(m_ubigo_descripcion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property UBIGO_DescCorta() As String
		Get
			return m_ubigo_desccorta
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ubigo_desccorta) Then
				If Not m_ubigo_desccorta.Equals(value) Then
					m_ubigo_desccorta = value
					OnUBIGO_DescCortaChanged(m_ubigo_desccorta, EventArgs.Empty)
				End If
			Else
				m_ubigo_desccorta = value
				OnUBIGO_DescCortaChanged(m_ubigo_desccorta, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property UBIGO_Protegido() As Boolean
		Get
			return m_ubigo_protegido
		End Get
		Set(ByVal value As Boolean)
			If Not m_ubigo_protegido.Equals(value) Then
				m_ubigo_protegido = value
				OnUBIGO_ProtegidoChanged(m_ubigo_protegido, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property UBIGO_UsrCrea() As String
		Get
			return m_ubigo_usrcrea
		End Get
		Set(ByVal value As String)
			m_ubigo_usrcrea = value
		End Set
	End Property
	Public Property UBIGO_FecCrea() As Date
		Get
			return m_ubigo_feccrea
		End Get
		Set(ByVal value As Date)
			m_ubigo_feccrea = value
		End Set
	End Property
	Public Property UBIGO_UsrMod() As String
		Get
			return m_ubigo_usrmod
		End Get
		Set(ByVal value As String)
			m_ubigo_usrmod = value
		End Set
	End Property
	Public Property UBIGO_FecMod() As Date
		Get
			return m_ubigo_fecmod
		End Get
		Set(ByVal value As Date)
			m_ubigo_fecmod = value
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
			Return "Ubigeos"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event UBIGO_CodigoChanged As EventHandler
	Public Event UBIGO_CodPadreChanged As EventHandler
	Public Event UBIGO_DescripcionChanged As EventHandler
	Public Event UBIGO_DescCortaChanged As EventHandler
	Public Event UBIGO_ProtegidoChanged As EventHandler
	Public Sub OnUBIGO_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent UBIGO_CodigoChanged(sender, e)
	End Sub
	Public Sub OnUBIGO_CodPadreChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent UBIGO_CodPadreChanged(sender, e)
	End Sub
	Public Sub OnUBIGO_DescripcionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent UBIGO_DescripcionChanged(sender, e)
	End Sub
	Public Sub OnUBIGO_DescCortaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent UBIGO_DescCortaChanged(sender, e)
	End Sub
	Public Sub OnUBIGO_ProtegidoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent UBIGO_ProtegidoChanged(sender, e)
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


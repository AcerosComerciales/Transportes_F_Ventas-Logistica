Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ELineas

#Region " Campos "
	
	Private m_linea_codigo As String
	Private m_linea_codpadre As String
	Private m_tipos_codtipocomision As String
	Private m_linea_nombre As String
	Private m_linea_usrcrea As String
	Private m_linea_feccrea As Date
	Private m_linea_usrmod As String
	Private m_linea_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlLineas
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
	
	Public Property LINEA_Codigo() As String
		Get
			return m_linea_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_linea_codigo) Then
				If Not m_linea_codigo.Equals(value) Then
					m_linea_codigo = value
					OnLINEA_CodigoChanged(m_linea_codigo, EventArgs.Empty)
				End If
			Else
				m_linea_codigo = value
				OnLINEA_CodigoChanged(m_linea_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property LINEA_CodPadre() As String
		Get
			return m_linea_codpadre
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_linea_codpadre) Then
				If Not m_linea_codpadre.Equals(value) Then
					m_linea_codpadre = value
					OnLINEA_CodPadreChanged(m_linea_codpadre, EventArgs.Empty)
				End If
			Else
				m_linea_codpadre = value
				OnLINEA_CodPadreChanged(m_linea_codpadre, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodTipoComision() As String
		Get
			return m_tipos_codtipocomision
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipocomision) Then
				If Not m_tipos_codtipocomision.Equals(value) Then
					m_tipos_codtipocomision = value
					OnTIPOS_CodTipoComisionChanged(m_tipos_codtipocomision, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipocomision = value
				OnTIPOS_CodTipoComisionChanged(m_tipos_codtipocomision, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property LINEA_Nombre() As String
		Get
			return m_linea_nombre
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_linea_nombre) Then
				If Not m_linea_nombre.Equals(value) Then
					m_linea_nombre = value
					OnLINEA_NombreChanged(m_linea_nombre, EventArgs.Empty)
				End If
			Else
				m_linea_nombre = value
				OnLINEA_NombreChanged(m_linea_nombre, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property LINEA_UsrCrea() As String
		Get
			return m_linea_usrcrea
		End Get
		Set(ByVal value As String)
			m_linea_usrcrea = value
		End Set
	End Property
	Public Property LINEA_FecCrea() As Date
		Get
			return m_linea_feccrea
		End Get
		Set(ByVal value As Date)
			m_linea_feccrea = value
		End Set
	End Property
	Public Property LINEA_UsrMod() As String
		Get
			return m_linea_usrmod
		End Get
		Set(ByVal value As String)
			m_linea_usrmod = value
		End Set
	End Property
	Public Property LINEA_FecMod() As Date
		Get
			return m_linea_fecmod
		End Get
		Set(ByVal value As Date)
			m_linea_fecmod = value
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
			Return "Lineas"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event LINEA_CodigoChanged As EventHandler
	Public Event LINEA_CodPadreChanged As EventHandler
	Public Event TIPOS_CodTipoComisionChanged As EventHandler
	Public Event LINEA_NombreChanged As EventHandler
	Public Sub OnLINEA_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent LINEA_CodigoChanged(sender, e)
	End Sub
	Public Sub OnLINEA_CodPadreChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent LINEA_CodPadreChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodTipoComisionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoComisionChanged(sender, e)
	End Sub
	Public Sub OnLINEA_NombreChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent LINEA_NombreChanged(sender, e)
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

